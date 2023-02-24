FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY BAS24.Auth.sln ./

#COPY BAS24.Auth.Api/BAS24.Auth.Api.xml .

COPY */*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ${file%.*}/ && mv $file ${file%.*}/; done

RUN dotnet restore -v n
COPY . ./
RUN dotnet build -c Release -o /app/build --no-restore

FROM build AS publish
RUN dotnet publish "BAS24.Auth.Api/BAS24.Auth.Api.csproj" -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY BAS24.Auth.Api/BAS24.Auth.Api.xml .
ENV ASPNETCORE_URLS=http://*:8080
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BAS24.Auth.Api.dll"]