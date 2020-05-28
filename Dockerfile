FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy sln first
COPY *.sln ./

# copy project files in & restore
COPY TestApi/TestApi.csproj TestApi/
COPY Core/Core.csproj Core/
COPY Infrastructure/Infrastructure.csproj Infrastructure/
RUN dotnet restore

# copy in everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
# RUN dotnet publish -c Release -o out
# CMD ["dotnet", "run"]

ENTRYPOINT ["dotnet", "TestApi.dll"]