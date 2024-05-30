# Zone Test

The soloution is developed using Asp.net Core MVC.

## Technologies ane librairies used

1. .NET 8
2.  Jquery
3.  Datatable      
5.  Bootstrap
6.  MediatR
7.  AutoMapper
8.  InMemory database
9.  Entity Framework 
10. The project template is created usign ASp.NET MVC template through Visual Studio
11. The pagination is enabled and it does server side rendering - It takes the data that is needed to display
12. Two hosts - Web API and Client App

# Known issues 
1. The InMemory database does not support Iqueryable hence used the Ienumerable
2. Unit testing code is not written for all classes
3. Integration code is not written for all classes
4. Exception handling not done   

# Instruction to run the application 
1. Extract the Zone.Zip into you local folder
2. Open ZoneProject.sln in Visual Studio 2022 and .NET 8 should have been installed
3. Run F5
4. Click the Initial load to validate the pagination

# Available Features
 1. The zone can be created
 2. DNS records can be created for the zone
 3. The DNs records can be deleted
 4. Zone can be deleted
