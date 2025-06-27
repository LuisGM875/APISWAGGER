# Etapa de build
  FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
  WORKDIR /src
  COPY . .
  RUN ls -l /src
  RUN dotnet restore APISWAGGER/APISWAGGER.csproj
  RUN dotnet publish APISWAGGER/APISWAGGER.csproj -c Release -o /app/publish

  # Etapa de runtime
  FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
  WORKDIR /app
  COPY --from=build /app/publish .
  ENV ASPNETCORE_URLS=http://+:80
  EXPOSE 80
  ENTRYPOINT ["dotnet", "APISWAGGER.dll"]