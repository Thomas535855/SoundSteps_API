# Gebruik de Linux versie van .NET SDK voor de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
# Expose de poorten
EXPOSE 8080
EXPOSE 8081
EXPOSE 443

# Gebruik de Linux versie van .NET SDK voor de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Kopieer de .csproj bestanden van alle projecten met de juiste relatieve paden
COPY ["SoundSteps.DAL/SoundSteps.DAL.csproj", "SoundSteps.DAL/"]
COPY ["SoundSteps.Interface/SoundSteps.Interface.csproj", "SoundSteps.Interface/"]
COPY ["Soundsteps.Logic/SoundSteps.Logic.csproj", "Soundsteps.Logic/"]
COPY ["SoundSteps.Test/SoundSteps.Test.csproj", "SoundSteps.Test/"]
COPY ["SoundSteps.API/SoundSteps.API.csproj", "SoundSteps.API/"]

# Voer 'dotnet restore' uit voor de SoundSteps.API.csproj om alle afhankelijkheden te herstellen
RUN dotnet restore "SoundSteps.API/SoundSteps.API.csproj"

# Kopieer de rest van de bronbestanden
COPY . .

# Stel de werkdirectory in op het SoundSteps.API project
WORKDIR "/src/SoundSteps.API"

# Bouw de applicatie
RUN dotnet build "SoundSteps.API.csproj" -c ${BUILD_CONFIGURATION} -o /app/build

# Publiceer de applicatie
FROM build AS publish
RUN dotnet publish "SoundSteps.API.csproj" -c ${BUILD_CONFIGURATION} -o /app/publish /p:UseAppHost=false

# Gebruik de .NET runtime image voor de laatste fase
FROM base AS final
WORKDIR /app

# Kopieer de gepubliceerde bestanden van de build fase
COPY --from=publish /app/publish .

# Maak een nieuwe gebruiker aan en draai de applicatie met deze gebruiker
RUN adduser --disabled-password --gecos '' appuser
USER appuser

# Zet het entrypoint om de applicatie te starten
ENTRYPOINT ["dotnet", "SoundSteps.API.dll"]
