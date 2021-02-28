FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Outlay_Statistic.csproj", "./"]
RUN dotnet restore "Outlay_Statistic.csproj"
COPY . .
RUN dotnet build "Outlay_Statistic.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Outlay_Statistic.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Outlay_Statistic.dll"]
