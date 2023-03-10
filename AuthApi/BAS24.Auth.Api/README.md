# Current Path

```shell
<project path>/src/BAS24.Auth.Api
```

## Add Migration

```shell
dotnet ef migrations add <Name migrations> --project ../BAS24.Auth.Infrastructure/BAS24.Auth.Infrastructure.csproj --context PostgresDbContext
```

## Remove current migration that has not applied

```shell
dotnet ef migrations remove --project ../BAS24.Auth.Infrastructure/BAS24.Auth.Infrastructure.csproj
```

## Apply Migration

```shell
dotnet ef database update --project ../BAS24.Auth.Infrastructure/BAS24.Auth.Infrastructure.csproj --context PostgresDbContext
```

## ENV
```shell
      - DB_HOST=bas24apiauthdb
      - DB_PORT=5432
      - DB_USER=postgres
      - DB_PASSWORD=postgres
      - DB_NAME=BAS24Auth
```