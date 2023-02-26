FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["AuthApi/BAS24.Auth.Api/BAS24.Auth.Api.csproj", "AuthApi/BAS24.Auth.Application/BAS24.Auth.Application.csproj", "AuthApi/BAS24.Auth.Core/BAS24.Auth.Core.csproj", "AuthApi/BAS24.Auth.Infrastructure/BAS24.Auth.Infrastructure.csproj", "./"]

COPY AuthApi/script.sh ./

#RUN dotnet new sln --name BAS24.Auth
##RUN for file in $(ls *.csproj); do dotnet sln add ${file}; done
#RUN for file in $(ls *.csproj); do mkdir -p ${file%.*}/ && mv $file ${file%.*}/; done
#RUN for file in $(ls); do if [${file} -ne "BAS24.Auth.sln"] then; dotnet sln add "${file}/${file}.csproj";fi; done
RUN chmod u+x script.sh
RUN ./script.sh

RUN dotnet restore -v n
COPY AuthApi/. ./
RUN ls
RUN dotnet build -c Release -o /app/build --no-restore
FROM build AS publish
RUN dotnet publish "BAS24.Auth.Api/BAS24.Auth.Api.csproj" -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY AuthApi/BAS24.Auth.Api/BAS24.Auth.Api.xml .
#ENV ASPNETCORE_URLS=http://*:8080
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BAS24.Auth.Api.dll"]