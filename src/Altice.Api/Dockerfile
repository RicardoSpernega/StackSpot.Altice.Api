FROM ubuntu:c27987afd3fd

RUN useradd −u 8877 nonroot
USER nonroot

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /
COPY ./ /

RUN dotnet restore "./src/Altice.Api/Altice.Api.csproj"
RUN dotnet build "./src/Altice.Api/Altice.Api.csproj"
RUN dotnet test "Altice.Api.sln"

FROM build AS publish
RUN dotnet publish "./src/Altice.Api/Altice.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Altice.Api.dll"]