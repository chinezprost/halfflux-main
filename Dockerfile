FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HALFFLUX-main-website.csproj", "./"]
RUN dotnet restore "HALFFLUX-main-website.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "HALFFLUX-main-website.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HALFFLUX-main-website.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HALFFLUX-main-website.dll"]
