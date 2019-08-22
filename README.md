
# REST-API-.Net-Core
Example of a full REST API build using .Net Core 2.2 and C#

## Install Packages
```
dotnet restore
```

## Migrations 
```
dotnet ef database update
```

## Build 
```
dotnet build
```

## Run 
```
 dotnet run --environment "Production"
```

## API List
```
GET     /api/commands
GET     /api/commands/{id}
POST    /api/commands
PUT     /api/commands/{id}
DELETE  /api/commands/{id}
```

## Application Architecture
![Application Architecture](/application_architecture.jpg)