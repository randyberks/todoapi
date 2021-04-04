# Todos Backend Web API
This repo contains a web api built with .NET Core 5 & C# using mysql as the database. 
## Dependencies
* .NET Core 5.0+
* MySQL / MariaDB
## Instructions
1. Clone the repository
2. Edit the `appsettings.json` found in the project root directory to add your database connections values.

    ```json
        "ConnectionStrings": {
        "TodoDbContext": "Server=localhost;User=user;Password=password;Database=todo"
      }

    ```
       
       
    Edit the ***Server (localhost)***, ***User*** ***Password*** and ***Database name***. The database needs to be created before running the code. Eg. `create database todo;`

3. Run the code. The web server runs at `http://localhost:5000/api/todoitems`
## Endpoints
The default endpoint and only controller is `/api/todoitems`. Visit the swagger documentation at `http://localhost:5000/swagger`.
