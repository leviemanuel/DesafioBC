#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TesteBC.Api/TesteBC.Api.csproj", "TesteBC.Api/"]
RUN dotnet restore "TesteBC.Api/TesteBC.Api.csproj"
COPY . .
WORKDIR "/src/TesteBC.Api"
RUN dotnet build "TesteBC.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TesteBC.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TesteBC.Api.dll"]