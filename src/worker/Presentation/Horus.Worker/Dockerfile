# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/runtime:8.0-alpine AS base
USER $APP_UID
WORKDIR /app


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["Presentation/Horus.Worker/Horus.Worker.csproj", "Presentation/Horus.Worker/"]
COPY ["Application/Horus.Application/Horus.Application.csproj", "Application/Horus.Application/"]
COPY ["Crosscutting/Horus.Crosscutting/Horus.Crosscutting.csproj", "Crosscutting/Horus.Crosscutting/"]
COPY ["Domain/Horus.Domain/Horus.Domain.csproj", "Domain/Horus.Domain/"]
COPY ["Infrastructure/Horus.Infra.Database/Horus.Infra.Database.csproj", "Infrastructure/Horus.Infra.Database/"]
COPY ["Infrastructure/Horus.Infra.Messaging/Horus.Infra.Messaging.csproj", "Infrastructure/Horus.Infra.Messaging/"]
RUN dotnet restore "./Presentation/Horus.Worker/Horus.Worker.csproj"
COPY . .
WORKDIR "/src/Presentation/Horus.Worker"
RUN dotnet build "./Horus.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Horus.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Horus.Worker.dll"]