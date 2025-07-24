#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/EsportsProfileWebApi.Web/EsportsProfileWebApi.Web.csproj", "src/EsportsProfileWebApi.Web/"]
RUN dotnet restore "src/EsportsProfileWebApi.Web/EsportsProfileWebApi.Web.csproj"
COPY . .
WORKDIR "/src/src/EsportsProfileWebApi.Web"
RUN dotnet build "EsportsProfileWebApi.Web.csproj" -c Release -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EsportsProfileWebApi.Web.csproj" -c Release -o /app/publish \
--self-contained true \
/p:PublishTrimmed=true \
/p:PublishSingleFile=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EsportsProfileWebApi.Web.dll"]