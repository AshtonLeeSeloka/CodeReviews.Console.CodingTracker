using CodingTracker.AshtonLeeSeloka.UserInterface;
using Services;


//Creating DB IF not Present
DataService _DB =  new DataService();
_DB.CreateDB();


UserInterface userInterface = new UserInterface();
userInterface.MainMenu();
