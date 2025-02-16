FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ChampManReborn.Domain/ChampManReborn.Domain.csproj", "ChampManReborn.Domain/"]
RUN dotnet restore "ChampManReborn.Domain/ChampManReborn.Domain.csproj"
COPY . .
WORKDIR "/src/ChampManReborn.Domain"
RUN dotnet build "ChampManReborn.Domain.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ChampManReborn.Domain.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChampManReborn.Domain.dll"]
