using BAS24.Api.Dtos.SocialLinks;
using BAS24.Api.Dtos.Stores;
using BAS24.Api.Dtos.Twilio;
using BAS24.Api.Entities.Stores;
using BAS24.Api.Exceptions;
using BAS24.Api.Exceptions.StoreMembers;
using BAS24.Api.Exceptions.Stores;
using BAS24.Api.Exceptions.Twilio;
using BAS24.Api.Exceptions.Users;
using BAS24.Api.IRepositories;
using BAS24.Api.Utils;
using BAS24.Auth.Infrastructure.Postgres;
using BAS24.Auth.Infrastructure.Postgres.Store;
using BAS24.Libs.CQRS.Queries;
using BAS24.Libs.Postgres;
using Microsoft.EntityFrameworkCore;

namespace BAS24.Auth.Infrastructure.Repositories;

public class StoreRepository : IStoreRepository
{
  private readonly IPostgresRepository<StoreTable> _repository;
  private readonly IUserRepository _userRepository;
  private readonly ITwilioRepository _twilioRepository;
  public StoreRepository(IPostgresRepository<StoreTable> repository, IUserRepository userRepository, ITwilioRepository twilioRepository)
  {
    _repository = repository;
    _userRepository = userRepository;
    _twilioRepository = twilioRepository;
  }

  public async Task CreateStoreAsync(StoreEntity entity)
  {
    var strategy = _repository.Context.Database.CreateExecutionStrategy();
    await strategy.ExecuteAsync(async () =>
    {
      await using var t = await _repository.Context.Database.BeginTransactionAsync();
      var user = await _userRepository.GetUserById(entity.OwnerId);
      if (user is null)
      {
        throw new UserNotFoundException();
      }
      var code = GenerateRandomNumber.Create(8);
      if (user.Phones?.Length <= 0) throw new UserDoNotHavePhoneNumberToSendTo();
      try
      {

        // var store = await GetStoreByIdAsync(entity.Id, false);
        // if (store is null) throw new StoreNotFoundException();
        entity.Code = code;
        await _repository.AddAsync(entity.AsTable());
        var data = await _twilioRepository.RequestAsync(new SendSmsDto(user.Phones![0], code));

        if (data is null)
        {
          throw new CodeSendFailedException();
        }
        await t.CommitAsync();
        Console.WriteLine(data.Body);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        await t.RollbackAsync();
        throw new FailedToSendCodeException();
      }
    });

  }

  public Task UpdateStoreAsync(StoreEntity entity)
  {
    return _repository.UpdateAsync(entity.AsTable());
  }

  public async Task ActivateStoreAsync(Guid ownerId, Guid storeId)
  {
    var q = new GetStoreByOwnerDto(ownerId, storeId, false);
    var store = await GetStoreByOwnerAsync(q);
    if (store is null) throw new StoreNotFoundException();
    store.Active = true;
    await UpdateStoreAsync(store);
  }
  
  public async Task VerifyStoreAsync(Guid id, Guid ownerId, string code)
  {
    var q = new GetStoreByOwnerDto(ownerId, id, false);
    var store = await GetStoreByOwnerAsync(q);
    if (store is null) throw new StoreNotFoundException();
    var storeAdmin = store.StoreMembers?
      .FirstOrDefault(i => i.MemberId == ownerId);
    if (storeAdmin is null) throw new StoreMemberNotFoundException();
    if (!storeAdmin.IsAdmin) throw new ForbiddenException();
    if (code != store.Code) throw new StoreCodeVerifyNotValidException();
    store.Active = true;
    store.Code = null;
    await UpdateStoreAsync(store);
  }

  public async Task DeactivateStoreAsync(Guid ownerId, Guid storeId)
  {
    var q = new GetStoreByOwnerDto(ownerId, storeId, true);
    var store = await GetStoreByOwnerAsync(q);
    if (store is null) throw new StoreNotFoundException();
    store.Active = false;
    await UpdateStoreAsync(store);
  }

  public Task DeleteStoreAsync(Guid ownerId, Guid storeId)
  {
    throw new NotImplementedException();
  }

  public Task AddUserToStoreAsync()
  {
    throw new NotImplementedException();
  }

  public Task UpdateUserStoreRoleAsync()
  {
    throw new NotImplementedException();
  }

  public Task RemoveUserFromStoreAsync()
  {
    throw new NotImplementedException();
  }

  public async Task<StoreEntity?> GetStoreByOwnerAsync(GetStoreByOwnerDto dto)
  {
    var store = await _repository.Context.Stores?.Include(i => i.Owner)
      .Include(i=> i.StoreMembers)
      .FirstOrDefaultAsync(i => i.Id == dto.StoreId && i.OwnerId == dto.OwnerId && i.Active == dto.IsActive)!;
    return store?.AsEntity();
  }

  public Task<PagedResult<StoreEntity>> GetStoresByUserAsync(Guid ownerId)
  {
    throw new NotImplementedException();
  }

  public async Task<PagedResult<StoreEntity>> GetAllStoresAsync(GetStoresPageDto dto)
  {
    var q = await _repository.Context
      .Stores?
      // ReSharper disable once SimplifyConditionalTernaryExpression
      .Where(i=> i.Active == dto.Active && (dto.OwnerId == null ? true : i.OwnerId == dto.OwnerId.ToGuid()))
      .AsQueryable()
      .PaginateAsync(dto.Page, dto.Results)!;
    var result = q.Map(i => i.AsEntity());
    return result;
  }

  public async Task<StoreEntity?> GetStoreByIdAsync(Guid id, bool isActive)
  {
    var store = await _repository.FirstOrDefaultAsync(i => i.Id == id && i.Active == isActive);
    return store?.AsEntity();
  }
}
