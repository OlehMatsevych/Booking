FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /src
COPY ["src/Booking.DataAccess/Booking.DataAccess.csproj", "src/Booking.DataAccess/"]
COPY ["src/Booking.API/Setup.sh", "Setup.sh"]

RUN dotnet tool install --global dotnet-ef

RUN dotnet restore "src/Booking.DataAccess/Booking.DataAccess.csproj"
COPY . .
WORKDIR /Booking.DataAccess
RUN ls

RUN /root/.dotnet/tools/dotnet-ef migration add InitialMigration
RUN chmod +x ./Setup.sh
CMD /bin/bash ./Setup.sh