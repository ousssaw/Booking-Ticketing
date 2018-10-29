#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 42237
EXPOSE 44354

FROM microsoft/dotnet:2.1-sdk-nanoserver-sac2016 AS build
WORKDIR /src
COPY ["Booking.Ticketing/Booking.Ticketing.csproj", "Booking.Ticketing/"]
RUN dotnet restore "Booking.Ticketing/Booking.Ticketing.csproj"
COPY . .
WORKDIR "/src/Booking.Ticketing"
RUN dotnet build "Booking.Ticketing.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Booking.Ticketing.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Booking.Ticketing.dll"]