FROM microsoft/dotnet:latest
WORKDIR /app
COPY . ./
RUN dotnet restore
ENTRYPOINT ASPNETCORE_ENVIRONMENT=Staging dotnet test Portfolio.Tests/Portfolio.Tests.Integration