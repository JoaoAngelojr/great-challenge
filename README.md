# Desafio GREAT

Web API developed for Group of Computer Networks, Software Engineering and Systems (GREat) hiring process.

## Getting Started

This project was developed using .NET Core 3.1 and EF Core with SQL Server.

### Prerequisites

You will need to have installed:

```
.NET Core SDK
SQL Server
```

### Installing

After downloading the project, modify the data base connection in the Startup.cs and greatContext.cs files on your machine.

The connection string will look like this in the files:

```
@"Server=DESKTOP-G9IP2IN;Database=great;Trusted_Connection=True;"
```

Before applying migrations, make sure that dotnet ef is installed:

```
dotnet tool install --global dotnet-ef
```

Aplique os migrations com o comando:

```
dotnet ef database update
```

In the Startup.cs file, modify the host of the application that will consume the API where the fields are located:

```
HOST_IP_ADDRESS
HOST_ADDRESS
```

## Deployment

A Docker file is available to create the image. It is at the root of the project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details