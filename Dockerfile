FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ImprocPetrsuWeb.sln .
COPY ImprocPetrsu.Web/ImprocPetrsu.Web.csproj ImprocPetrsu.Web/ImprocPetrsu.Web.csproj
COPY ImprocPetrsuWrapper/ImprocPetrsuWrapper.csproj ImprocPetrsuWrapper/ImprocPetrsuWrapper.csproj
RUN dotnet restore

# Copy everything else and build
COPY . ./
WORKDIR /app/ImprocPetrsu.Web
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/ImprocPetrsu.Web/out .
ENTRYPOINT ["ASPNETCORE_URLS=http://*:$PORT", "dotnet", "ImprocPetrsu.Web.dll"]
