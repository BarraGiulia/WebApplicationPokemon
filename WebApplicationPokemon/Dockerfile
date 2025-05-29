# Usa l'immagine ufficiale .NET per build
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000

# Usa l'immagine .NET SDK per buildare
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia i file di progetto
COPY *.csproj ./
RUN dotnet restore

# Copia tutto e builda
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Stage finale
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Specifica che deve partire su 0.0.0.0:5000 (come già usi)
ENV ASPNETCORE_URLS=http://0.0.0.0:5000

ENTRYPOINT ["dotnet", "WebApplicationPokemon.dll"]
