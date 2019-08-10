FROM node:alpine AS front-builder
WORKDIR /app
COPY . ./
RUN npm install -g @angular/cli@latest
RUN cd Portfolio.ClientApp && rm package-lock.json
RUN cd Portfolio.ClientApp && npm install
RUN cd Portfolio.ClientApp && ng build --prod
FROM microsoft/dotnet:latest AS build-env
WORKDIR /app
COPY . ./
COPY --from=front-builder /app/Portfolio.ClientApp/dist/portfolio-client-app ./Portfolio.Web/wwwroot
RUN dotnet publish Portfolio.Web -c Release -o out
FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/Portfolio.Web/out/ ./
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ASPNETCORE_ENVIRONMENT=Production dotnet Portfolio.Web.dll