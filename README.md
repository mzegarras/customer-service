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
dotnet add package AWSSDK.SimpleNotificationService --version 3.3.0.27

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

### Generar imagen
```
docker build -t clientesa:14.0.0 .
```

### Tag imagen
```
docker tag clientesa:14.0.0 mzegarra/clientesa:14.0.0
```

### Publicar imagen
```
docker push mzegarra/clientesa:14.0.0
```

### Invcar método save
```
curl -v -H "Content-Type: application/json" -X POST -d '{"Codigo":"Zegarra","Nombres":"Manuel"}'  http://realelb-1395575868.us-east-1.elb.amazonaws.com/api/clientes
```

### Agregar Health Check library
https://www.app-metrics.io/samples/health-code/

```
dotnet add package App.Metrics.AspNetCore.Health.Endpoints --version 2.0.0
```


### Agregar Logging
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?tabs=aspnetcore2x

```
  dotnet add package Microsoft.Extensions.DependencyInjection
  dotnet add package Microsoft.Extensions.Logging
```  

```
curl -v -H "Content-Type: application/json" -X GET http://realelb-1395575868.us-east-1.elb.amazonaws.com/api/clientes
```

### Agregar Mysql
```
dotnet add package MySqlConnector --version 0.38.0
```

### Agregar referencia

```
dotnet add ./Clientes.Services/Clientes.Services.csproj reference ./Clientes.Dao/Clientes.Dao.csproj
```



### Agregar Policy

```
arn:aws:rds-db:<<region>>:<<account-id>>:dbuser:<<dbi-resource-id>>/<<database-user-name>>
```

```
aws rds describe-db-instances \
     --query "DBInstances[*].[DBInstanceIdentifier,DbiResourceId]"
```

```
arn:aws:rds-db:us-east-1:081255659930:dbuser:db-MLLJQKLLUGFUYWB6AJTZ7U6RPE/admin
```

```
{
    "Version": "2012-10-17",
    "Statement": [
        {
            "Effect": "Allow",
            "Action": [
                "rds-db:connect"
            ],
            "Resource": [
                "arn:aws:rds-db:us-east-1:081255659930:dbuser:db-MLLJQKLLUGFUYWB6AJTZ7U6RPE/admin"
            ]
        }
    ]
}
```