# ASP.NET backend

## how to start project

- dotnet new webapp

- dotnet new package [package name]

  - dotnet new Npgsql
  - dotnet new Npgsql.Microsoft.EntityFrameworkCore.PostgreSQL
  - dotnet new Microsoft.EntityFrameworkCore.Design

- create a new database and new table with PostgreSQL

- dotnet ef dbcontext scaffold "Hostname=localhost;Port=5432;Database=db_school_management;Username=postgres;Password=password;Pooling=true" Npgsql.EntityFrameworkCore.PostgreSQL

- dotnet ef migrations add Init --context SchoolContext

- dotnet ef migrations script --context SchoolContext

- dotnet build
<!-- 
- dotnet run -->
