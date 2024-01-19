FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine as builder
WORKDIR /app
COPY ./backend.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c release -o /out --no-self-contained

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine as base
COPY --from=builder /out /app
ENV ASPNETCORE_HTTP_PORTS=5001
ENTRYPOINT ["dotnet", "/app/backend.dll"]