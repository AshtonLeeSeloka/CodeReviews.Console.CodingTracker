using CodingTracker.AshtonLeeSeloka.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using static CodingTracker.AshtonLeeSeloka.Models.MenuItems;

namespace CodingTracker.AshtonLeeSeloka.Views
{
	public class View
	{
		public MenuItems.MenuInsert InsertSessionView() 
		{
			var selectedOption = AnsiConsole.Prompt(
				new SelectionPrompt<MenuInsert>()
				.Title("[green]How Would you like to record this session?[/]")
				.AddChoices(Enum.GetValues<MenuInsert>())
				);
			return selectedOption;
		}

		public MenuItems.MenuViewData DisplayViewSelection() 
		{
			var selectedOption = AnsiConsole.Prompt(
			new SelectionPrompt<MenuViewData>()
			.Title("[green]Select how you would like to filter data[/]")
			.AddChoices(Enum.GetValues<MenuViewData>())
			);

			return selectedOption;
		}

		public MenuItems.MenuAscending DisplayViewSelectionAscending()
		{
			var selectedOption = AnsiConsole.Prompt(
			new SelectionPrompt<MenuAscending>()
			.Title("[green]Select how you would like to filter data[/]")
			.AddChoices(Enum.GetValues<MenuAscending>())
			);

			return selectedOption;
		}

		public MenuItems.MenuDescending DisplayViewSelectionDecending()
		{
			var selectedOption = AnsiConsole.Prompt(
			new SelectionPrompt<MenuDescending>()
			.Title("[green]Select how you would like to filter data[/]")
			.AddChoices(Enum.GetValues<MenuDescending>())
			);

			return selectedOption;
		}

		public string insertDateView(string message) 
		{
			string dateValue = AnsiConsole.Ask<string>(message);
			
			
			return dateValue;
		}

		public void DisplaySessionView(List<CodingSession> sessions) 
		{

			Console.Clear();
			Console.WriteLine("Session Entries\n");

			List<CodingSession> codingSessions =sessions;

			var table = new Table();
			table.Border(TableBorder.Rounded);

			table.AddColumn("[green]Id[/]");
			table.AddColumn("[green]Start Time[/]");
			table.AddColumn("[green]End Time[/]");
			table.AddColumn("[green]Duration[/]");

			foreach (var codingSession in codingSessions)
			{
				table.AddRow(
					$"[cyan]{codingSession.Id.ToString()}[/]",
					$"[yellow] {codingSession.StartTime}[/]",
					$"[yellow] {codingSession.EndTime}[/]",
					$"[yellow] {codingSession.Duration}[/]"
				);
			}

			AnsiConsole.Write(table);

		}



		public void DisplayAllReportDataView(string? startDate, string? endDate,int numberOfRecords, float? average, float? sum) 
		{
			var table = new Table();
			table.Border(TableBorder.Rounded);

			AnsiConsole.WriteLine("\nReport Data\n");
			table.AddColumn("[green]Starting Date[/]");
			table.AddColumn("[green]Ending Date[/]");
			table.AddColumn("[green]Number of Records in period[/]");
			table.AddColumn("[green]Average hours per session[/]");
			table.AddColumn("[green]Total hours per period[/]");

			table.AddRow(
						$"[cyan]{startDate}[/]",
						$"[yellow] {endDate}[/]",
						$"[yellow] {numberOfRecords}[/]",
						$"[yellow] {average}[/]",
						$"[yellow] {sum}[/]"
						);

			AnsiConsole.Write(table);
			AnsiConsole.WriteLine("\nPress any Key to exit");
			Console.ReadKey();
		}

		public CodingSession DeleteSessionView(List<CodingSession> sessions) 
		{
			CodingSession SessionToDelete = AnsiConsole.Prompt(
			new SelectionPrompt<CodingSession>()
			.Title("Select Session to [red]Remove[/]")
			.UseConverter(s => $"[yellow]Session ID: {s.Id}, Start Time: {s.StartTime}, End Time: {s.EndTime} with duration of {s.Duration} hours[/]")
			.AddChoices(sessions));
			return SessionToDelete;
		}

		public CodingSession UpdateSessionView(List<CodingSession> sessions) 
		{
			CodingSession SessionToDelete = AnsiConsole.Prompt(
			new SelectionPrompt<CodingSession>()
			.Title("Select Session to [green]Update[/]")
			.UseConverter(s => $"[yellow]Session ID: {s.Id}, Start Time: {s.StartTime}, End Time: {s.EndTime} with duration of {s.Duration} hours[/]")
			.AddChoices(sessions));

			return SessionToDelete;

		}

		public MenuItems.MenuReport ReportMenuView()
		{
			var selectedOption = AnsiConsole.Prompt(
				new SelectionPrompt<MenuReport>()
				.Title("[green]Select Reporting option[/]")
				.AddChoices(Enum.GetValues<MenuReport>())
				);
			return selectedOption;
		}


	}
}
