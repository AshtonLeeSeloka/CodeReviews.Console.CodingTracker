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
- SQLite Database
  -A SQLite Database is used to store all user Inputs.
  -The Program automatically creates a Databse if one is not present
   

## Lessons Learnt

## Resources
* Seperation of concerns [Article](https://www.thecsharpacademy.com/article/30005/separation-of-concerns-csharp)
* OOP [Crash Course](https://www.thecsharpacademy.com/course/1/article/1/500000/false)
* Spectre Console [Documentation](https://spectreconsole.net/)
* Dapper ORM [Documentation](https://www.learndapper.com/)
