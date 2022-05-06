#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["StudentAPI/LibraryAPI.csproj", "StudentAPI/"]
COPY ["Students.Repo/Repos_Implementation.csproj", "Students.Repo/"]
COPY ["Student.Services/Repos_Interfaces.csproj", "Student.Services/"]
COPY ["Students.Data/Data.csproj", "Students.Data/"]
RUN dotnet restore "StudentAPI/LibraryAPI.csproj"
COPY . .
WORKDIR "/src/StudentAPI"
RUN dotnet build "LibraryAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LibraryAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibraryAPI.dll"]