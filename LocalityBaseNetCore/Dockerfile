FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["LocalityBaseNetCore/LocalityBaseNetCore.csproj", "LocalityBaseNetCore/"]
RUN dotnet restore "LocalityBaseNetCore/LocalityBaseNetCore.csproj"
COPY . .
WORKDIR "/src/LocalityBaseNetCore"
RUN dotnet build "LocalityBaseNetCore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LocalityBaseNetCore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LocalityBaseNetCore.dll"]