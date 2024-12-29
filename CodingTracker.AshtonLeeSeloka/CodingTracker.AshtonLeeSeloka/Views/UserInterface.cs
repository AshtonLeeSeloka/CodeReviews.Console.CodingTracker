using CodingTracker.AshtonLeeSeloka.Controllers;
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
			AnsiConsole.Clear();
			var userSelection = AnsiConsole.Prompt(
				new SelectionPrompt<MenuOptions>()
				.Title("[blue]Coding Tracker Selection Menu[/]")
				.AddChoices(Enum.GetValues<MenuOptions>())
			 );

			switch (userSelection)
			{
				case MenuOptions.View_Coding_Sessions:
					controller.ViewData();
					break;
				case MenuOptions.Insert_New_Session:
					controller.InsertSession();
					break;
				case MenuOptions.Update_Coding_Session:
					controller.UpdateSession();
					break;
				case MenuOptions.Delete_Coding_Session:
					controller.DeleteSession();
					break;
				case MenuOptions.Generate_Report:
					controller.GenerateReport();
					break;
				case MenuOptions.End_Application:
					AnsiConsole.WriteLine("Good Bye");
					Environment.Exit(0);
					break;
			}
		}
	}
}
