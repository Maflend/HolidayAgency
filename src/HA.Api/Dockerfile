FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/HA.Api/HA.Api.csproj", "src/HA.Api/"]
COPY ["src/Core/Application/HA.Application/HA.Application.csproj", "src/Core/Application/HA.Application/"]
COPY ["src/Core/Domain/HA.Domain/HA.Domain.csproj", "src/Core/Domain/HA.Domain/"]
COPY ["src/Infrastructure/HA.Infrastructure.EF/HA.Infrastructure.EF.csproj", "src/Infrastructure/HA.Infrastructure.EF/"]
RUN dotnet restore "src/HA.Api/HA.Api.csproj"
COPY . .
WORKDIR "/src/src/HA.Api"
RUN dotnet build "HA.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HA.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HA.Api.dll"]