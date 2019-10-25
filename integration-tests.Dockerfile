FROM mcr.microsoft.com/dotnet/core/sdk:3.0
WORKDIR /app
COPY . ./
RUN dotnet restore
ENTRYPOINT ASPNETCORE_ENVIRONMENT=Staging dotnet test Portfolio.Tests/Portfolio.Tests.Integration