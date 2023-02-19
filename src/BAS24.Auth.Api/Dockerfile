FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BAS24.Auth.Api/BAS24.Auth.Api.csproj", "BAS24.Auth.Api/"]
RUN dotnet restore "BAS24.Auth.Api/BAS24.Auth.Api.csproj"
COPY . .
WORKDIR "/src/BAS24.Auth.Api"
RUN dotnet build "BAS24.Auth.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BAS24.Auth.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BAS24.Auth.Api.dll"]
