# Customer service net core
customer service net core


## Getting Started


### Crear proyecto
```
dotnet new webapi
```

```
dotnet new classlib -o MyWebApp.DataStore
```

### Agregar dependencias
```
dotnet add package log4net --version 2.0.8
```

### Compilar
```
dotnet build
dotnet build --configuration Release
```

### Descargar dependencias

dotnet restore

### Compilar para producción
```
dotnet publish -o obj/Docker/publish -c Release -r linux-x64
```

### Agregar proyecto del tipo library

```
dotnet new classlib
dotnet new classlib -o MyWebApp.DataStore
```

### Agregar referencia

```
dotnet add ./Clientes.Microservice/Clientes.Microservice.csproj reference ./Clientes.Services/Clientes.Services.csproj
```