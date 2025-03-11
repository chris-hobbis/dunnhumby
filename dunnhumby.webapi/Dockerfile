FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Dunnhumby.WebAPI/Dunnhumby.WebAPI.csproj", "Dunnhumby.WebAPI/"]
RUN dotnet restore "Dunnhumby.WebAPI/Dunnhumby.WebAPI.csproj"
COPY . .
WORKDIR "/src/Dunnhumby.WebAPI"
RUN dotnet build "Dunnhumby.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Dunnhumby.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dunnhumby.WebAPI.dll"]
