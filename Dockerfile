FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# copy sln and csproj
COPY *.sln .
COPY ZipApi/*.csproj ./ZipApi/
COPY EFRepository/*.csproj ./EFRepository/
RUN dotnet restore

# copy all 
COPY ZipApi/. ./ZipApi/
COPY EFRepository/. ./EFRepository/
WORKDIR /source/ZipApi
RUN dotnet publish -c release -o /app --no-restore

# stage image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "ZipApi.dll"]