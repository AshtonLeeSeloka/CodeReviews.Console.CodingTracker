using CodingTracker.AshtonLeeSeloka.Models;
using Microsoft.Extensions.Hosting;
using ServiceContracts;
using Services;
using Spectre.Console;
using System.Collections;


namespace CodingTracker.AshtonLeeSeloka.Controllers
{
	public class CodingController
	{
		private DataService _dataService = new DataService();

		public void InsertSession()
		{
			Console.Clear();
			var startDate = AnsiConsole.Ask<string>("[green]Enter Session start (yyyy-mm-dd HH:mm:ss)[/]");
			var endDate = AnsiConsole.Ask<string>("[green]Enter Session End (yyyy-mm-dd HH:mm:ss)[/]");
			int test = 5;
			_dataService.Insert(startDate, endDate, test);
		}
		public void viewData() 
		{
			Console.Clear();
			List<CodingSession> codingSessions =_dataService.ViewSessions();

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
			AnsiConsole.WriteLine("\nPress any Key to exit");
			Console.ReadKey();
		}
	}
}
