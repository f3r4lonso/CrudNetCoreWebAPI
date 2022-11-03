CrudNetCoreWebAPI

#.NetCore 6
#EntityFramework
#Swagger test UI
#SQL Server Express
#Dependency injection

database deploy:

1) go to file appsettings.json and modify the DefaultConnection String

2) go to Package Manager Console:

A- Install EntityFramework if you dont have it
PM> dotnet tol install --global dotnet-ef

B- Create a migration Script in order to Update your local database
PM> dotnet migration add MicrationScriptName

C- Update or Create your local Databaase
PM> dotnet database update

Buil and Run
