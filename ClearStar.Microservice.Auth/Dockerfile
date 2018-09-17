FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk-nanoserver-sac2016 AS build
WORKDIR /src
COPY *.csproj ClearStar.Microservice.Auth/
RUN dotnet restore ClearStar.Microservice.Auth/ClearStar.Microservice.Auth.csproj
WORKDIR /src/ClearStar.Microservice.Auth
COPY . .
#WORKDIR /src/ClearStar.Microservice.Auth
RUN dotnet build ClearStar.Microservice.Auth.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ClearStar.Microservice.Auth.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ClearStar.Microservice.Auth.dll"]
