FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["src/Shoreline/Shoreline.csproj", "src/Shoreline/"]
COPY ["src/Shoreline.Commands/Shoreline.Commands.csproj", "src/Shoreline.Commands/"]
COPY ["src/Shoreline.Providers.Discord/Shoreline.Providers.Discord.csproj", "src/Shoreline.Providers.Discord/"]

COPY src/ .
RUN dotnet build "Shoreline.Providers.Discord/Shoreline.Providers.Discord.csproj" -c $BUILD_CONFIGURATION -o /app/build --no-incremental

FROM build AS publish
RUN dotnet publish "Shoreline.Providers.Discord/Shoreline.Providers.Discord.csproj" -c $BUILD_CONFIGURATION --no-build -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shoreline.Providers.Discord.dll"]