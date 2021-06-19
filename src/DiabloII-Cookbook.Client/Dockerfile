#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DiabloII-Cookbook.Client/DiabloII-Cookbook.Client.csproj", "DiabloII-Cookbook.Client/"]
COPY ["DiabloII-Cookbook/DiabloII-Cookbook.Api.csproj", "DiabloII-Cookbook/"]
RUN dotnet restore "DiabloII-Cookbook.Client/DiabloII-Cookbook.Client.csproj"
COPY . .
WORKDIR "/src/DiabloII-Cookbook.Client"
RUN dotnet build "DiabloII-Cookbook.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DiabloII-Cookbook.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DiabloII-Cookbook.Client.dll"]