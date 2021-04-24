FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src/Backend
COPY . .
RUN dotnet restore "./DiabloII-Cookbook.Web/DiabloII-Cookbook.Web.csproj"
COPY . .
WORKDIR "/src/Backend"
RUN dotnet build "./DiabloII-Cookbook.Web/DiabloII-Cookbook.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./DiabloII-Cookbook.Web/DiabloII-Cookbook.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DiabloII-Cookbook.Web.dll"]