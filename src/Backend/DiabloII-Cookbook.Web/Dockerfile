FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src
COPY "./src/Backend" "./src"

RUN ls -a

RUN dotnet restore "./src/DiabloII-Cookbook.Web/DiabloII-Cookbook.Web.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "./src/DiabloII-Cookbook.Web/DiabloII-Cookbook.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./src/DiabloII-Cookbook.Web/DiabloII-Cookbook.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DiabloII-Cookbook.Web.dll"]