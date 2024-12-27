using CodingTracker.AshtonLeeSeloka.Controllers;
using ServiceContracts;
using Spectre.Console;
using static CodingTracker.AshtonLeeSeloka.Models.MenuItems;
namespace CodingTracker.AshtonLeeSeloka.UserInterface;

internal class UserInterface
{

	public void MainMenu() 
	{
		CodingController controller = new CodingController();

		while (true) 
		{
			var userSelection = AnsiConsole.Prompt(
				new SelectionPrompt<MenuOptions>()
				.Title("[blue]Coding Tracker Selection Menu[/]")
				.AddChoices(Enum.GetValues<MenuOptions>())
			 );

			switch (userSelection) 
			{
				case MenuOptions.View_Coding_Sessions:
					break;
				case MenuOptions.Insert_New_Session:
					controller.InsertSession();
					break;
				case MenuOptions.Update_Coding_Session:
					break;
				case MenuOptions.Delete_Coding_Session:
					break;
				case MenuOptions.Generate_Report:
					break;
				case MenuOptions.End_Application:
					AnsiConsole.WriteLine("Good Bye");
					Environment.Exit(0);
					break;
			}
		}
	}
}
