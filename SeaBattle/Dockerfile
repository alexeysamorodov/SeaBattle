#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["SeaBattle/SeaBattle.csproj", "SeaBattle/"]
RUN dotnet restore "SeaBattle/SeaBattle.csproj"
COPY . .
WORKDIR "/src/SeaBattle"
RUN dotnet build "SeaBattle.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "SeaBattle.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SeaBattle.dll"]