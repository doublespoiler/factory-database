# Factory Manager

#### By Skylan Lew

#### Independent Project 10 for Epicodus

## Technologies Used

- C#
- .NET 5
- ASP.NET Core MVC
- Entity
- MySQL
- Javascript
- HTML

## Description

This application allows the user to track machines and mechanics for a slot machine repair factory using a MySQL database.

The user can create Mechanics, and Machines. After mechanics and machines have been made, relationships can be assigned.

Mechanics and Machines can be edited, where any information about them may be changed, except for their ID.

Mechanics and Machines may be deleted.

The individual links between mechanics and machines may also be deleted.

Deleting a Mechanic also deletes the links to their Machines, but not the Machines themselves, and vice versa.

## Setup/Installation Requirements

- Import `skylan_lew.sql` as a new schema with name `skylan_lew`
- Create a file named `appsettings.json` in the project folder `/Factory/`
- Put the following code inside `appsettings.json`, making sure to set your uid and pwd:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=skylan_lew;uid=YOURUSERNAME;pwd=YOURPASSWORD;"
  }
}
```

### Requires

- [.NET 5](https://dotnet.microsoft.com/en-us/download/dotnet/5.0) - <https://dotnet.microsoft.com/en-us/download/dotnet/5.0>
- MySQL - Recommend [MySQL Workbench](https://dev.mysql.com/downloads/workbench/)

### Download/Run Instructions (git)

- clone: `$ git clone https://github.com/doublespoiler/factory-database.git` or Code>Download ZIP
- navigate to project folder: `$ cd /Factory`
- restore: `$ dotnet restore`
- build: `$ dotnet build`
- run: `$ dotnet run`

## Known Bugs

## License

[MIT](https://choosealicense.com/licenses/mit/)
`[MIT](https://choosealicense.com/licenses/mit/)`

Copyright (c) 2022 Skylan Lew
