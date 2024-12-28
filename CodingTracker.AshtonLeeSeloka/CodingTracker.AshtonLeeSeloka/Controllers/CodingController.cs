using CodingTracker.AshtonLeeSeloka.Models;
using CodingTracker.AshtonLeeSeloka.Views;
using Microsoft.Extensions.Hosting;
using ServiceContracts;
using Services;
using Spectre.Console;
using System.Collections;
using static CodingTracker.AshtonLeeSeloka.Models.MenuItems;


namespace CodingTracker.AshtonLeeSeloka.Controllers
{
	public class CodingController
	{
		private DataService _dataService = new DataService();
		private View _view = new View();

		public void InsertSession()
		{
			Console.Clear();
			var selection = _view.InsertSessionView();

			switch (selection) 
			{
				case MenuInsert.Manually_Record_Session:
					Console.WriteLine("smile bitch");
					Console.ReadKey();
					break;
				case MenuInsert.Start_Timer:
					break;
				case MenuInsert.Back:
					break;
			}


			//var startDate = AnsiConsole.Ask<string>("[green]Enter Session start (yyyy-mm-dd HH:mm:ss)[/]");
			//var endDate = AnsiConsole.Ask<string>("[green]Enter Session End (yyyy-mm-dd HH:mm:ss)[/]");
			//int test = 5;
			//_dataService.Insert(startDate, endDate, test);
		}

		public void viewData() 
		{
			Console.Clear();
			List<CodingSession> codingSessions =_dataService.GetAllSessions();
			_view.DisplaySessionView(codingSessions);
		}

		public void DeleteSession()
		{
			List<CodingSession> codingSessions = _dataService.GetAllSessions();
			CodingSession sessionToDelete = _view.DeleteSessionView(codingSessions);
			_dataService.Delete(sessionToDelete);
		}

		public void UpdateSession() 
		{
			List<CodingSession> codingSessions = _dataService.GetAllSessions();
			CodingSession sessionToUpdate = _view.UpdateSessionView(codingSessions);
			_dataService.Update(sessionToUpdate);
		}
	
	
	}
}
