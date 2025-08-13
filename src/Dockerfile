FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /
COPY . .
WORKDIR /SeaBattle.API
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
EXPOSE 80
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SeaBattle.API.dll", "--urls", "http://0.0.0.0:80"]
