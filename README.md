# CRUD-ASP.NETCORE-Dapper-MsSqlServer
It's been such an awesome experience I have by 2 weeks joining with palador! and this is what the little result, 
I was scared before with the new language that I will use which is C# but, it is not that hard! and now I am really getting used to that, so I am bravely posting this project here
and I can't wait for what comes next by me here


this project contains 2 information
* Employee.Api: 
  - this folder contains all the backend code including dapper syntax, you can find it in the Repository folder which is EmployeeRepository.cs file
  - for the Interface also you can find it in the Repository folder which is IEmployeeRepository.cs file 
  - please pay attention to Startup.cs and appsettings.json to change the configuration for your need where it locates or even your database name, change it with your own configuration
* EmployeeApi.Db
  - this folder contains the table and stored procedure that I used for this project, It is unrelated to Employee.Api I still using "connectionstring" to work with that, this folder actually just a simple database project to make us easier when we need to work collaborate with a team, or even not hard to quickly find the data mapping we use with the database, but also we still need the database itself 
  - please just go to dbo folder, ignore the other( I don't know why the other folder comes up after I push it here, but in actual, there's only dbo folder that contains table and stored procedures only)
* Tips: 
  - to make work with .NET framework easier I recommend using visual studio instead of visual studio code because you can use visual studio snippets to easier your time to build these projects, but it also depends on your choice again
