FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ImprocPetrsuWebApi.sln .
COPY ImprocPetrsu.WebApi/ImprocPetrsu.WebApi.csproj ImprocPetrsu.WebApi/ImprocPetrsu.WebApi.csproj
COPY ImprocPetrsu.Bindings/ImprocPetrsu.Bindings.csproj ImprocPetrsu.Bindings/ImprocPetrsu.Bindings.csproj
RUN dotnet restore

# Copy everything else and build
COPY . ./
WORKDIR /app/ImprocPetrsu.WebApi
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/ImprocPetrsu.WebApi/out .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet ImprocPetrsu.WebApi.dll
