#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MusicTestAPI/MusicTestAPI.Web/MusicTestAPI.Web.csproj", "MusicTestAPI/MusicTestAPI.Web/"]
RUN dotnet restore "MusicTestAPI/MusicTestAPI.Web/MusicTestAPI.Web.csproj"
COPY . .
WORKDIR "/src/MusicTestAPI/MusicTestAPI.Web"
RUN dotnet build "MusicTestAPI.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MusicTestAPI.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MusicTestAPI.Web.dll"]