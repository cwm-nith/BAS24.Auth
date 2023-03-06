FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["ProductApi/BAS24.Product.Api/BAS24.Product.Api.csproj", "ProductApi/BAS24.Product.Application/BAS24.Product.Application.csproj", "ProductApi/BAS24.Product.Core/BAS24.Product.Core.csproj", "ProductApi/BAS24.Product.Infrastructure/BAS24.Product.Infrastructure.csproj", "./"]

COPY ProductApi/script.sh ./

RUN chmod u+x script.sh
RUN ./script.sh

RUN dotnet restore -v n
COPY ProductApi/. ./
RUN ls
RUN dotnet build -c Release -o /app/build --no-restore
FROM build AS publish
RUN dotnet publish "BAS24.Product.Api/BAS24.Product.Api.csproj" -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY ProductApi/BAS24.Product.Api/BAS24.Product.Api.xml .
#ENV ASPNETCORE_URLS=http://*:8080
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BAS24.Product.Api.dll"]