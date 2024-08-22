# Construção da API
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-api
WORKDIR /app

COPY ./Cod3rsGrowth.sln ./
COPY ./Cod3rsGrowth.Domain/*.csproj ./Cod3rsGrowth.Domain/
COPY ./Cod3rsGrowth.Infra/*.csproj ./Cod3rsGrowth.Infra/
COPY ./Cod3rsGrowth.Service/*.csproj ./Cod3rsGrowth.Service/
COPY ./Cod3rsGrowth.Web/*.csproj ./Cod3rsGrowth.Web/

RUN dotnet restore

COPY . ./
RUN dotnet publish ./Cod3rsGrowth.Web/Cod3rsGrowth.Web.csproj -c Release -o /app/out


# Construção do UI5
FROM node:18 AS build-ui
WORKDIR /app

COPY ./Cod3rsGrowth.Web/wwwroot/package.json ./Cod3rsGrowth.Web/wwwroot/package-lock.json ./
RUN npm install

COPY ./Cod3rsGrowth.Web/wwwroot ./
RUN npm run build


# Montagem da Imagem
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

COPY --from=build-api /app/out ./
COPY --from=build-ui /app/dist ./wwwroot

EXPOSE 80
ENTRYPOINT ["dotnet", "Cod3rsGrowth.Web.dll"]