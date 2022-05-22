#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Starter/Starter.csproj", "Starter/"]
RUN dotnet restore "Starter/Starter.csproj"
COPY . .
WORKDIR "/src/Starter"
RUN dotnet build "Starter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Starter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Starter.dll"]