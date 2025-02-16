FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ChampManReborn.Infrastructure/ChampManReborn.Infrastructure.csproj", "ChampManReborn.Infrastructure/"]
RUN dotnet restore "ChampManReborn.Infrastructure/ChampManReborn.Infrastructure.csproj"
COPY . .
WORKDIR "/src/ChampManReborn.Infrastructure"
RUN dotnet build "ChampManReborn.Infrastructure.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ChampManReborn.Infrastructure.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChampManReborn.Infrastructure.dll"]
