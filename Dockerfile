FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
EXPOSE 80
WORKDIR /app

# Copy .csproj and restore as distinct layers
COPY ["UsersCRUD.WebUI/UsersCRUD.WebUI.csproj", "UsersCRUD.WebUI/"]
COPY ["UsersCRUD.Domain/UsersCRUD.Domain.csproj", "UsersCRUD.Domain/"]
COPY ["UsersCRUD.Infrastructure/UsersCRUD.Infrastructure.csproj", "UsersCRUD.Infrastructure/"]

RUN dotnet restore "UsersCRUD.WebUI/UsersCRUD.WebUI.csproj"

# Copy the remaining source code and build the app
COPY . .
RUN dotnet build -c Debug -o /app/build

# Use dotnet watch for hot-reload during development
ENTRYPOINT ["dotnet", "watch", "--non-interactive", "run", "--project=UsersCRUD.WebUI/",  "--urls=http://0.0.0.0:80"]

