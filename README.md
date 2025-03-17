# Forecast API

The project consists of two modules: Forecast and Coordinates, as well as a WEB API project ForecastApi as a central point.
The Forecast module is responsible for adding a new forecast for a given location and date, and fetching forecasts for given coordinates with or without a date.
The Coordinates module handles operations such as adding and deleting coordinates, also provides an option to return all saved coordinates.

## Installation

### Clone the repo
```bash
git clone https://github.com/axial123/test-task.git
```
### Download MS SQL Server docker image
```bash
docker pull mcr.microsoft.com/mssql/server
```
### Run DB
```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Str0ng!Passw0rd123" -p 1433:1433 -d mcr.microsoft.com/mssql/server:latest
```

### Apply migrations:
Run below scripts from the root of the ForecastApi project

#### Coordinates module main DB 
```bash
dotnet ef database update --context CoordinatesDbContext
```
#### Coordinates module test DB
```bash
dotnet ef database update --context CoordinatesDbContext -- --environment Testing
```

#### Forecast module main DB 
```bash
dotnet ef database update --context ForecastDbContext
```

## Usage

Run ForecastApi project  
To explore the API, see the ForecastApi.http file at 
```bash
/test-task/Forecast/ForecastApi
```
