# Avaliacao2KaduFloresta-CSharp
Avaliação C# (Locadora de Filmes em MVC)

### To use Database
If you like use database, install MariaDB and configure your credentials on `Repositories/Repository.cs`
Is necessary install this steps:
1. `dotnet tool install dotnet-ef -g --version 3.1.1`
2. `dotnet add package Pomelo.EntityFrameworkCore.MySql`
3. `dotnet add package Pomelo.EntityFrameworkCore.MySql.Desing`
4. `dotnet add package Microsoft.EntityFrameworkCore`
5. `dotnet add package Microsoft.EntityFrameworkCore.Desing`
6. `dotnet ef migrations add InitialDB`
7. `dotnet ef database update`
