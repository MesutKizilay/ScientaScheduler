#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ScientaScheduler.BlazorApp/ScientaScheduler.BlazorApp.csproj", "ScientaScheduler.BlazorApp/"]
COPY ["ScinetaScheduler.Blazor.Library/ScientaScheduler.Blazor.Library.csproj", "ScinetaScheduler.Blazor.Library/"]
RUN dotnet restore "ScientaScheduler.BlazorApp/ScientaScheduler.BlazorApp.csproj"
COPY . .
WORKDIR "/src/ScientaScheduler.BlazorApp"
RUN dotnet build "ScientaScheduler.BlazorApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ScientaScheduler.BlazorApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ScientaScheduler.BlazorApp.dll"]