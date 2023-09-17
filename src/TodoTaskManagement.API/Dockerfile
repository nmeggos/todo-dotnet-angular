FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/TodoTaskManagement.API/TodoTaskManagement.API.csproj", "src/TodoTaskManagement.API/"]
RUN dotnet restore "src/TodoTaskManagement.API/TodoTaskManagement.API.csproj"
COPY . .
WORKDIR "/src/src/TodoTaskManagement.API"
RUN dotnet build "TodoTaskManagement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TodoTaskManagement.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoTaskManagement.API.dll"]
