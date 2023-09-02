#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR ../src
COPY ["FIAPPOSTECH_FASE2.API/FIAPPOSTECH_FASE2.API.csproj", "src/FIAPPOSTECH_FASE2.API/"]
COPY ["src/FIAPPOSTECH_FASE2.DTO/FIAPPOSTECH_FASE2.DTO.csproj", "src/FIAPPOSTECH_FASE2.DTO/"]
COPY ["src/FIAPPOSTECH_FASE2.DOMAIN/FIAPPOSTECH_FASE2.DOMAIN.csproj", "src/FIAPPOSTECH_FASE2.DOMAIN/"]
COPY ["src/FIAPPOSTECH_FASE2.Services/FIAPPOSTECH_FASE2.Services.csproj", "src/FIAPPOSTECH_FASE2.Services/"]
COPY ["src/FIAPPOSTECH_FASE2.Infra/FIAPPOSTECH_FASE2.Infra.csproj", "src/FIAPPOSTECH_FASE2.Infra/"]
RUN dotnet restore "src/FIAPPOSTECH_FASE2.API/FIAPPOSTECH_FASE2.API.csproj"
COPY . .
WORKDIR "/src/src/FIAPPOSTECH_FASE2.API"
RUN dotnet build "FIAPPOSTECH_FASE2.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FIAPPOSTECH_FASE2.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FIAPPOSTECH_FASE2.API.dll"]