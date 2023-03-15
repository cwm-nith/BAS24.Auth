# Current Path

```shell
<project path>/ProductApi/BAS24.Product.Api
```

## Add Migration

```shell
dotnet ef migrations add <Name migrations> --project ../BAS24.Product.Infrastructure/BAS24.Product.Infrastructure.csproj --context PostgresDbContext
```

## Remove current migration that has not applied

```shell
dotnet ef migrations remove --project ../BAS24.Product.Infrastructure/BAS24.Product.Infrastructure.csproj
```

## Apply Migration

```shell
dotnet ef database update --project ../BAS24.Product.Infrastructure/BAS24.Product.Infrastructure.csproj --context PostgresDbContext
```

## ENV
```shell
      - DB_HOST=bas24apiproductdb
      - DB_PORT=5432
      - DB_USER=postgres
      - DB_PASSWORD=postgres
      - DB_NAME=BAS24Product
```