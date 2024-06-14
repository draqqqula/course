FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["./Libs/Core/*.csproj", "./Libs/Core/"]
COPY ["QuestionApi/Dal/*.csproj", "QuestionApi/Dal/"]
COPY ["QuestionApi/Logic/*.csproj", "QuestionApi/Logic/"]
COPY ["QuestionApi/Api/*.csproj", "QuestionApi/Api/"]
RUN dotnet restore "QuestionApi/Api/Api.csproj"
COPY . .

WORKDIR "/src/QuestionApi/Api"
RUN dotnet build "Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]