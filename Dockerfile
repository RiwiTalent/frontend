﻿# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src
COPY . .
RUN dotnet restore "riwi.csproj"
RUN dotnet publish "riwi.csproj" -c Release -o /app/publish

# Etapa de ejecución con Caddy
FROM caddy:alpine
COPY --from=build /app/publish/wwwroot /usr/share/caddy
