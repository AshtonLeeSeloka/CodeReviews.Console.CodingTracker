# Coding Tracker

## Requirments
- [x] To Display Data "Spectre.Console" library should be used.
- [x] You should tell the user the specific format you want the date and time to be logged and not allow any other format.
- [x] Database path and connection strings must be stored in a configuration file.
- [x] You'll need to create a "CodingSession" class in a separate file. It will contain the properties of your coding session: Id, StartTime, EndTime, Duration
- [x] The user shouldn't input the duration of the session. It should be calculated based on the Start and End times, in a separate method.
- [x] The user should be able to input the start and end times manually.
- [x] You need to use Dapper ORM for the data access instead of ADO.NET.
- [x] When reading from the database, you can't use an anonymous object, you have to read your table into a List of Coding Sessions.
- [x] Follow the DRY Principle, and avoid code repetition.

## Features
* SQLite Database
  - A SQLite Database is used to store all user Inputs.
  - The Program automatically creates a Databse if one is not present.
    
* Console UI created using Spectre.Console
  - User may interact with the console using arrow keys.
  - Tables are utilised to neatly display information.
  - Use of colours to emphasis information.
 
![Main Menu UI](https://github.com/AshtonLeeSeloka/CodeReviews.Console.CodingTracker/blob/5d06ca15a2ca279b83a74ebccf74dc6e58aa422d/CodingTracker.AshtonLeeSeloka/CodingTracker.AshtonLeeSeloka/wwwRoot/Screenshot%202024-12-29%20203006.png)

![Table Example](https://github.com/AshtonLeeSeloka/CodeReviews.Console.CodingTracker/blob/5d06ca15a2ca279b83a74ebccf74dc6e58aa422d/CodingTracker.AshtonLeeSeloka/CodingTracker.AshtonLeeSeloka/wwwRoot/Screenshot%202024-12-29%20203043.png)
   
* Database CRUD operations using Dapper.
  - Time and Date information can be: 
    - Captured and saved to the database.
    - Modified.
    - Deleted.
    - Inserted.
    
* User Input Validation
  - User Input is validated before any operations are performed against input.
  - The TryParseExact() methood is used to ensure compliance with required format of yyyy/MM/dd HH:mm:ss.

* Reporting of user Data
  - Calculate sum and average inputs for all data.
  - Calculate sum and average over user specified period.
  - Values are displayed in atable format using Spectre.Console.
 
  
## Lessons Learnt

#### Working with DateTime
- I experienced some challenges in correctly formatting and converting DateTime objects to strings and vise versa.
- Through this project I am now more capable of both converting and performing operations agains DateTime objects.

#### Dapper
- This is my first project using Dapper, I found myself a little confused in the initial stages.
- After reading some documentation I can see the benefit of an ORM like dapper over ADO.NET.
- Dapper Greatly simplifies All Crud operations and I am more confident in using it for my future project.

#### Spectre.Console
- Utilising the basic functionality of Spectre.Console to Display information.

### Resources
* Seperation of concerns [Article](https://www.thecsharpacademy.com/article/30005/separation-of-concerns-csharp)
* OOP [Crash Course](https://www.thecsharpacademy.com/course/1/article/1/500000/false)
* Spectre Console [Documentation](https://spectreconsole.net/)
* Dapper ORM [Documentation](https://www.learndapper.com/)
* Medium Article [DateTime in C#](https://medium.com/@Has_San/datetime-in-c-1aef47db4feb)
* Microsoft [DateTime Documentation](https://learn.microsoft.com/en-us/dotnet/api/system.datetime?view=net-9.0)
