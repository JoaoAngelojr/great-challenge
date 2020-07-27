# Desafio GREAT

Web API desenvolvida para processo seletivo do laboratório GREAT.

## Getting Started

Este projeto foi desenvolvido utilizando .NET Core e EF Core com SQL Server.

### Prerequisites

Você precisará ter instalado:

```
SDK do .NET Core
SQL Server
```

### Installing

Após baixar o projeto, modifique a conexão de banco nos arquivos Startup.cs e greatContext.cs da sua máquina.

A string de conexão estará dessa forma nos arquivos:

```
@"Server=DESKTOP-G9IP2IN;Database=great;Trusted_Connection=True;"
```

Antes de aplicar os migrations, certifique-se de que o dotnet ef está instalado:

```
dotnet tool install --global dotnet-ef
```

Aplique os migrations com o comando:

```
dotnet ef database update
```

Modifique no arquivo Startup.cs o host da aplicação que consumirá a API onde se encontram os campos:

```
HOST_IP_ADDRESS
HOST_ADDRESS
```

## Deployment

Um arquivo Docker foi disponibilizado para criação da imagem. Encontra-se na raiz do projeto.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details