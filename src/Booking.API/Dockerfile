#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Booking.API/Booking.API.csproj", "src/Booking.API/"]
COPY ["src/Booking.Common/Booking.Common.csproj", "src/Booking.Common/"]
COPY ["src/Booking.Messaging.Receive/Booking.Messaging.Receive.csproj", "src/Booking.Messaging.Receive/"]
COPY ["src/Booking.DataAccess/Booking.DataAccess.csproj", "src/Booking.DataAccess/"]
COPY ["src/Booking.Core/Booking.Core.csproj", "src/Booking.Core/"]
COPY ["src/Booking.Application/Booking.Application.csproj", "src/Booking.Application/"]

RUN dotnet restore "src/Booking.API/Booking.API.csproj"

COPY . .
WORKDIR "/src/src/Booking.API"
RUN dotnet build "Booking.API.csproj" -c Release -o /app/build
#todo: 
FROM build AS publish
RUN dotnet publish "Booking.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Booking.API.dll"]