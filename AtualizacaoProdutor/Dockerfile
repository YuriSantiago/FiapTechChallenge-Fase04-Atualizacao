FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia todas as pastas necessárias
COPY Core ./Core
COPY AtualizacaoProdutor ./AtualizacaoProdutor

WORKDIR /src/AtualizacaoProdutor

RUN dotnet restore AtualizacaoProdutor.csproj
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "AtualizacaoProdutor.dll"]