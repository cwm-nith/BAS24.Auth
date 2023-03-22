using BAS24.Libs.CQRS.Commands;
using BAS24.Product.Core.IRepositories;

namespace BAS24.Product.Application.Commands.ExchangeRate.Handler;

public class DeleteExchangeRateCommandHandler:ICommandHandler<DeleteExchangeRateCommand, Guid>
{
  private readonly IExchangeRepository _repository;

  public DeleteExchangeRateCommandHandler(IExchangeRepository repository)
  {
    _repository = repository;
  }

  public async Task HandleAsync(DeleteExchangeRateCommand command, Guid id)
  {
    await _repository.DeleteAsync(id);
  }
}
