# Project Title

Repository pattern project template on dotnet core

## Getting Started

The solution is composed by 2 projects: API and Service. 

In the API project we have the API itself, and the appsettings.json file contains the connection string to
the database in the SQL Server. The SQL Server was run on docker container with the following environment variables:

* SA_PASSWORD = Kranium@336
* ACCEPT_EULA = Y

## Info(On VSCODE)

When running migrations or updating the database, you need to reference the startup project otherwise it won't let you proceed:

You are in the Service directory and wants to add a migration:

`dotnet ef migrations add InitialCreate --startup-project ../API/API.csproj
`
