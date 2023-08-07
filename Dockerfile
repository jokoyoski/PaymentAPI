

# Use the official .NET 7 SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build


WORKDIR /app
# copy csproj and restore as distinct layers
COPY PaymentAPI/*.csproj ./PaymentAPI/
WORKDIR /app/PaymentAPI
RUN dotnet restore

# copy and publish app and libraries
WORKDIR /app/
COPY  PaymentAPI/. ./ PaymentAPI/
WORKDIR /app/PaymentAPI
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/runtime:3.0 AS runtime
WORKDIR /app
COPY --from=build /app/PaymentAPI/out ./
ENTRYPOINT ["dotnet", "dotnetapp.dll"]
