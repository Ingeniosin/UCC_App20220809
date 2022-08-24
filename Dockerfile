FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["App20220809.csproj", "./"]
RUN dotnet restore "App20220809.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "App20220809.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "App20220809.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "App20220809.dll"]
