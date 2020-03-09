FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["AppDockerLnx/AppDockerLnx.csproj", "AppDockerLnx/"]
RUN dotnet restore "AppDockerLnx/AppDockerLnx.csproj"
COPY . .
WORKDIR "/src/AppDockerLnx"
RUN dotnet build "AppDockerLnx.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AppDockerLnx.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AppDockerLnx.dll"]