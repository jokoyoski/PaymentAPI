FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the .csproj and restore the dependencies
COPY PaymentAPI/*.csproj ./PaymentAPI/
COPY PaymentAPI.Data/*.csproj ./PaymentAPI.Data/
COPY PaymentAPI.Domain/*.csproj ./PaymentAPI.Domain/
COPY PaymentAPI.Shared/*.csproj ./PaymentAPI.Shared/

RUN dotnet restore ./PaymentAPI/PaymentAPI.csproj

# Copy the rest of the source code
COPY . .

# Build the application
RUN dotnet build ./PaymentAPI/PaymentAPI.csproj -c Release -o /app/build

# Publish the application
RUN dotnet publish ./PaymentAPI/PaymentAPI.csproj -c Release -o /app/publish

# Create the final image with the published application
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PaymentAPI.dll"]
