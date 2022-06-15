FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ./WorkflowServer.CallbackApi WorkflowServer.CallbackApi/
RUN dotnet restore WorkflowServer.CallbackApi/WorkflowServer.CallbackApi.csproj --source https://api.nuget.org/v3/index.json
WORKDIR /src/WorkflowServer.CallbackApi
RUN dotnet clean WorkflowServer.CallbackApi.csproj -c Release -o /app
RUN dotnet build WorkflowServer.CallbackApi.csproj -c Release -o /app

FROM build AS publish
WORKDIR /src/WorkflowServer.CallbackApi
RUN dotnet publish WorkflowServer.CallbackApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app/WorkflowServer.CallbackApi
COPY --from=publish /app ./bin

RUN rm -rf ./bin/backups
RUN mkdir ./bin/backups

RUN useradd --user-group --uid 1000 wfs-callback-api
RUN chown -R wfs-callback-api:wfs-callback-api /app

USER wfs-callback-api

WORKDIR /app/WorkflowServer.CallbackApi/bin
ENTRYPOINT ["dotnet", "WorkflowServer.CallbackApi.dll"]
