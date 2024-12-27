using Microsoft.Extensions.Hosting;
using Spectre.Console;
using System.Collections;


namespace CodingTracker.AshtonLeeSeloka.Controllers
{
	public class CodingController
	{
		public CodingController()
		{

		}

		public void InsertSession()
		{
			Console.Clear();
			var startDate = AnsiConsole.Ask<string>("[green]Enter Session start (yyyy-mm-dd HH:mm:ss)[/]");
			var endDate = AnsiConsole.Ask<string>("[green]Enter Session End (yyyy-mm-dd HH:mm:ss)[/]");


		}
	}
}
