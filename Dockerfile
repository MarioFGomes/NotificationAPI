FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /app

COPY . ./

RUN dotnet restore

RUN dotnet build -c Release --no-restore

RUN dotnet publish -c Release -o out --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /app

COPY --from=build /app/out ./

EXPOSE 80

ENTRYPOINT ["dotnet", "Notification.API.dll"]