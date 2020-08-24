
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
# COPY ["../Application/Api.Application.csproj", "./Application/"]
# COPY ["../Api.Repository/Api.Repository.csproj", "./Api.Repository/"]
# COPY ["../Api.Models/Api.Models.csproj", "./Api.Models/"]
COPY ["./Application/Api.Application.csproj", "./Application/"]
COPY ["./Api.Repository/Api.Repository.csproj", "./Api.Repository/"]
COPY ["./Api.Models/Api.Models.csproj", "./Api.Models/"]
RUN dotnet restore "Application/Api.Application.csproj"
COPY . .
WORKDIR "/src/Application"
RUN dotnet build "Api.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.Application.dll"]

# FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
# WORKDIR /src

# # Copy csproj and restore as distinct layers
# COPY ["./Application/Api.Application.csproj", "./Application/"]
# COPY ["./Api.Repository/Api.Repository.csproj", "./Api.Repository/"]
# COPY ["./Api.Models/Api.Models.csproj", "./Api.Models/"]
# # COPY ["*.csproj", "./Application/"]
# RUN dotnet restore

# # Copy everything else and build
# COPY . ./
# RUN dotnet publish -c Release -o out

# # Build runtime image
# FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
# WORKDIR /app
# COPY --from=build-env /app/out .
# ENTRYPOINT ["dotnet", "aspnetapp.dll"]