# Estágio de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["src/AgroSolutions.Identity.Service.Api/AgroSolutions.Identity.Service.Api.csproj", "src/AgroSolutions.Identity.Service.Api/"]
COPY ["src/AgroSolutions.Identity.Service.Application/AgroSolutions.Identity.Service.Application.csproj", "src/AgroSolutions.Identity.Service.Application/"]
COPY ["src/AgroSolutions.Identity.Service.Domain/AgroSolutions.Identity.Service.Domain.csproj", "src/AgroSolutions.Identity.Service.Domain/"]
COPY ["src/AgroSolutions.Identity.Service.Infra/AgroSolutions.Identity.Service.Infra.csproj", "src/AgroSolutions.Identity.Service.Infra/"]

# Restaurar dependências
RUN dotnet restore "src/AgroSolutions.Identity.Service.Api/AgroSolutions.Identity.Service.Api.csproj"

# Copiar tudo
COPY . .

# Build
WORKDIR "/src/src/AgroSolutions.Identity.Service.Api"
RUN dotnet build "AgroSolutions.Identity.Service.Api.csproj" -c Release -o /app/build

# Estágio de publicação
FROM build AS publish
RUN dotnet publish "AgroSolutions.Identity.Service.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Estágio final
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN apt-get update && apt-get install -y wget && rm -rf /var/lib/apt/lists/*
ENTRYPOINT ["dotnet", "AgroSolutions.Identity.Service.Api.dll"]
