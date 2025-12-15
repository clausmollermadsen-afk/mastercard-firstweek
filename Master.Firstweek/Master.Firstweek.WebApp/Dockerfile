FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Master.Firstweek.WebApp/Master.Firstweek.WebApp.csproj", "Master.Firstweek.WebApp/"]
RUN dotnet restore "Master.Firstweek.WebApp/Master.Firstweek.WebApp.csproj"
COPY . .
WORKDIR "/src/Master.Firstweek.WebApp"
RUN dotnet build "./Master.Firstweek.WebApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Master.Firstweek.WebApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Master.Firstweek.WebApp.dll"]
