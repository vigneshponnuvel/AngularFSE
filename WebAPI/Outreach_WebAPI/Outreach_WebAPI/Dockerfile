FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Outreach_WebAPI/Outreach_WebAPI.csproj", "Outreach_WebAPI/"]
RUN dotnet restore "Outreach_WebAPI/Outreach_WebAPI.csproj"
COPY . .
WORKDIR "/src/Outreach_WebAPI"
RUN dotnet build "Outreach_WebAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Outreach_WebAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Outreach_WebAPI.dll"]