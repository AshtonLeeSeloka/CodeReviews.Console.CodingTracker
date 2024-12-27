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

		//public CodingController(IDataService dataService)
		//{
		//	_dataService = dataService;
		//}

		

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
			_dataService.View();
		
		}
	}
}
