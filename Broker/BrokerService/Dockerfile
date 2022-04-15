#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV APP_RABBIT__SERVER__HOSTNAME "broker-rabbitmq"
ENV APP_CONNECTIONSTRING "Server=broker-sqlserver;Database=PUC-Broker;User Id=sa;Password=q1w2e3@db;MultipleActiveResultSets=True"
ENV APP_RABBIT__SERVER__SUFFIX "local"
ENV APP_DB_SCRIPTS "/src/BrokerService.Core/Scripts"
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BrokerService/BrokerService.csproj", "BrokerService/"]
RUN dotnet restore "BrokerService/BrokerService.csproj"
COPY . .
WORKDIR "/src/BrokerService"
RUN dotnet build "BrokerService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BrokerService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BrokerService.dll"]