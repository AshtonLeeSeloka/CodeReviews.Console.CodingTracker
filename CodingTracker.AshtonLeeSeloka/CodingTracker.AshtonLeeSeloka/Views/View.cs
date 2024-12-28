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
		public void ViewSessions(List<CodingSession> sessions) 
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

	}
}
