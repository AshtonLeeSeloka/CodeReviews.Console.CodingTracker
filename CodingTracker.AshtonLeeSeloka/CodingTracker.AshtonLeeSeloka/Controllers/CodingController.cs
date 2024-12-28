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
		private ValidationService _validation = new ValidationService();
		private View _view = new View();

		public void InsertSession()
		{
			Console.Clear();
			var selection = _view.InsertSessionView();

			switch (selection) 
			{
				case MenuInsert.Manually_Record_Session:
					ManualInsert();
					break;
				case MenuInsert.Start_Timer:
					break;
				case MenuInsert.Back:
					break;
			}

		}

		public void ManualInsert() 
		{
			
			
			bool stringOneBool = true;
			bool stringTwoBool = true;

			while (stringOneBool) 
			{
				string? startDateTime = _view.insertDateView("[green]Enter Session start (yyyy-MM-dd HH:mm:ss)[/]");
				if (_validation.DateValidation(startDateTime))
				{
					stringOneBool = false;
					break;
				}
				else 
				{
					Console.Clear();
					Console.WriteLine("Please enter date in correct format (yyyy-MM-dd HH:mm:ss)");
					Console.WriteLine("Press Any key to retry)");
					Console.ReadLine();	
					ManualInsert();
				}
			}

			Console.WriteLine("step 3");
			Console.ReadKey();


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
