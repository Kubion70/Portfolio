FROM node:alpine AS front-builder
WORKDIR /app
COPY . ./
RUN npm install -g @angular/cli@latest
RUN cd Portfolio.ClientApp && rm package-lock.json
RUN cd Portfolio.ClientApp && npm install
RUN cd Portfolio.ClientApp && ng build --prod
FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env
WORKDIR /app
COPY . ./
COPY --from=front-builder /app/Portfolio.ClientApp/dist/portfolio-client-app ./Portfolio.Web/wwwroot
RUN dotnet publish Portfolio.Web -c Release -o /out
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
WORKDIR /app
COPY --from=build-env /out ./
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ASPNETCORE_ENVIRONMENT=Production dotnet Portfolio.Web.dll