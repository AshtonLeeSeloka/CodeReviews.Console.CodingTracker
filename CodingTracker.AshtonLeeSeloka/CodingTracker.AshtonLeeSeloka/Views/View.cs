using CodingTracker.AshtonLeeSeloka.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace CodingTracker.AshtonLeeSeloka.Views
{
	public class View
	{
		public void DisplaySessionView(List<CodingSession> sessions) 
		{
			Console.Clear();
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
			AnsiConsole.WriteLine("\nPress any Key to exit");
			Console.ReadKey();
		}
		public CodingSession DeleteSessionView(List<CodingSession> sessions) 
		{
			CodingSession SessionToDelete = AnsiConsole.Prompt(
			new SelectionPrompt<CodingSession>()
			.Title("Select Session to [red]Remove[/]")
			.UseConverter(s => $"[yellow]Session ID: {s.Id}, Start Time: {s.StartTime}, End Time: {s.EndTime} with duration of {s.Duration} minutes[/]")
			.AddChoices(sessions));

			return SessionToDelete;
		}
	}
}
