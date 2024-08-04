FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Shoreline.Providers.Discord.csproj", "./"]
RUN dotnet restore "Shoreline.Providers.Discord.csproj"
COPY . .
RUN dotnet build "Shoreline.Providers.Discord.csproj" -c $BUILD_CONFIGURATION -o /app/build --no-incremental

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Shoreline.Providers.Discord.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shoreline.Providers.Discord.dll"]