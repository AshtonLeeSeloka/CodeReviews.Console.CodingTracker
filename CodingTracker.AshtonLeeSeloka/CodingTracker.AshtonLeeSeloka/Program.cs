using CodingTracker.AshtonLeeSeloka.UserInterface;
using Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

//Creating DB IF not Present
DataService _DB =  new DataService();
_DB.CreateDB();


UserInterface userInterface = new UserInterface();
userInterface.MainMenu();
