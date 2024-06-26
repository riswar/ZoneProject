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
3. Right click on the Zone Project Solution file
4. Go to Properties
5. Select "Multiple startup projects"
6. Select Zone Client then Select Start on Action Column
7. Select Zone Api then Select Start on Action Column
8. Click Apply
9. Run F5
10. Click the Initial load to validate the pagination (It may take a few seconds as it inserts the data in loop from Client to API

# How to update the port # if it is needed for API

1. Open launchSettings.JSON file on ZoneApi project --> Properties --> launchSettings.JSON
2. Look JSON property applicationUrl at profiles --> https--> applicationUrl
3. Replace port # 7124 to xxxx
4. Open Program.cs in ZoneClient project (This is to replace the port where it is referenced)
5. Update Port # from 7124 to xxxx(that is used on step 3), make sure sure it is updated on two places ( Line # 10 & 14)

# How to update the port # if it is needed for Client Project

1. Open launchSettings.JSON file on ZoneClient project --> Properties --> launchSettings.JSON
2. Look JSON property applicationUrl at profiles --> https--> applicationUrl
3. Replace port # 7296 to yyyy
   
# Available Features
 1. The zone can be created
 2. DNS records can be created for the zone
 3. The DNs records can be deleted
 4. Zone can be deleted

# Appendix
    
## Successfull application Screenshot

### 1. API Screen on Development Mode
   ![image](https://github.com/riswar/ZoneProject/assets/33431575/7998812b-ba79-4590-a96f-a6cfeb950d91)
### 2. Client app Screen
![image](https://github.com/riswar/ZoneProject/assets/33431575/32667bb6-11d1-471f-9742-657272061e94)

### 3. After Initial Load 

   1. Click Initial Load
   2. It takes to new page with informatin
   3. Click Zone Client
      
![image](https://github.com/riswar/ZoneProject/assets/33431575/0cbe08ec-2607-42a6-95ec-17ad42a1dd11)



