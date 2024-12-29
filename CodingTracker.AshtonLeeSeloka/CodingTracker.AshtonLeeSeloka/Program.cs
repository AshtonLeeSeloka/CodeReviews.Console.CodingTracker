using CodingTracker.AshtonLeeSeloka.UserInterface;
using Services;

DataService _DB =  new DataService();
_DB.CreateDB();
UserInterface userInterface = new UserInterface();
userInterface.MainMenu();
