# Music-Store-API
Test API developed using .Net Core with EF and SQL Server Database.

## Setup

- Install SQL Server Database inside the [/DataBase/](https://github.com/carlos0202/Music-Store-API/tree/master/DataBase/) folder.
  + Run script [/DataBase/MusicStoreDB_Schema.sql](/DataBase/MusicStoreDB_Schema.sql) to setup database structure.
  + Run script [/DataBase/MusicStoreDB_Data.sql](/DataBase/MusicStoreDB_Data.sql) to install seed data for testing purposes.
  + The database included has the following relationships defined:
    ![/assets/db-diagram.PNG](/assets/db-diagram.PNG)

- Update connection string info inside *appsettings.json* file. Default connection string connects to LocalDB instance using MusicDB as database name. Update highlighted key to match your wanted connection string named `Context`.

![/assets/default-config.PNG](/assets/default-config.PNG)

- Open project using MS Visual Studio 2019 and restore all nuget packages to run or debug the solution.
  + The project includes a swaggerUI configuration to allow testing endpoints without the need of any external tools. The appearance of the wellcome screen of the API is the swaggerUI view as follows:
  ![/assets/swagger-view.PNG](/assets/swagger-view.png)
  
  + The unit tests have been configured using xunit and moq. The successful run of all the tests should produce a window like the following picture: 
   ![/assets/unit-tests.PNG](/assets/unit-tests.PNG)
   
## The main solution to open all the projects related to the API is inside the directory [/Music-Store-API/](/Music-Store-API) using the name `Music-Store-API.sln`.
