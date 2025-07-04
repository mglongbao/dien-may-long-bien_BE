# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build
WORKDIR /app/src

# Restore
COPY ["dien-may-long-bien/dien-may-long-bien.csproj", "dien-may-long-bien/"]
WORKDIR /app/src/dien-may-long-bien
RUN dotnet restore "dien-may-long-bien.csproj"

# Build
# Copy the rest of the application code
COPY ["dien-may-long-bien/", "./"]
WORKDIR /app/src/dien-may-long-bien
RUN dotnet build "dien-may-long-bien.csproj" -c Release -o /app/build

# Stage 2: Publish
FROM build AS publish
WORKDIR /app/src/dien-may-long-bien
RUN dotnet publish "dien-may-long-bien.csproj" -c Release --no-restore -o /app/publish

# Stage 3: Run
FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS base
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8080

ENTRYPOINT [ "dotnet", "dien-may-long-bien.dll" ]
