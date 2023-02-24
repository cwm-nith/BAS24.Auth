FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY BAS24.Auth.sln .
#COPY data ./

COPY */*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ${file%.*}/ && mv $file ${file%.*}/; done

RUN dotnet restore -v n
COPY . .
RUN dotnet build -c Release -o /app/build --no-restore

FROM build AS publish
RUN dotnet publish "Api/Api.csproj" -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://*:8080
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]