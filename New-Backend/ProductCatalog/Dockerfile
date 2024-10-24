# ProductCatalog/Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy solution and project files
COPY . .

# Restore dependencies
ENV ConnectionStrings__ECommerceDatabase=Host=postgres;Port=5432;Database=ECommerce;Username=admin;Password=admin
RUN dotnet restore 
RUN dotnet build 
RUN dotnet publish -c Release -o out

# Final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80 
EXPOSE 443
ENTRYPOINT ["dotnet", "ProductCatalog.WebApi.dll"]
