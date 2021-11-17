# MusicTestAPI
a sample api using .net core and docker

# Prerequisites
The prerequisites for running this app are the following
- .NET 5
- Docker
- Visual studio 2019

# How to run it

First you should clone this repository in your machine and then follow this steps
-*Ensure* that the MusicTestAPI.Web is set as the startup project
![image](https://user-images.githubusercontent.com/47477978/142297213-5d00afd9-2c5f-4388-9dd0-7fd692be989d.png)
-Then modify the connection string in the _appsettings.json_ file to match your sql server connection data, *only modify the highlighted part* 
![image](https://user-images.githubusercontent.com/47477978/142297374-560d6404-3774-40b8-a365-00cdb0350a90.png)
**Note: By default this connection string is targeting a sql azure database , you can change it to a local database or to a different cloud provider database**
-Run the database create script that is located in **MusicTestAPI.Data/Scripts/InitialDbCreate.sql**
-Run the initial data populate script that is located in **MusicTestAPI.Data/Scripts/InitialDataPopulate.sql**
![image](https://user-images.githubusercontent.com/47477978/142297891-74dc47b1-9ae6-4eeb-b9df-0033b99983ef.png)

-Then you can run the api clicking the run button in visual studio 2019, this will fire a container instance, and then display the swagger ui in your default browser
![image](https://user-images.githubusercontent.com/47477978/142298729-e9fac576-36c2-4d1b-863a-88c9c5cbeac8.png)
There you can make the requests to the api 

