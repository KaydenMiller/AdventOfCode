FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AdventOfCode.Day2/AdventOfCode.Day2.csproj", "AdventOfCode.Day2/"]
RUN dotnet restore "AdventOfCode.Day2/AdventOfCode.Day2.csproj"
COPY . .
WORKDIR "/src/AdventOfCode.Day2"
RUN dotnet build "AdventOfCode.Day2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdventOfCode.Day2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdventOfCode.Day2.dll"]
