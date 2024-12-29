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
		private CalculationsService _calculationsService = new CalculationsService();
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
			
			DateTime startDate = _validation.GetValidatedDate("start");
			DateTime endDate = _validation.GetValidatedDate("end");

			while (startDate > endDate) 
			{
				Console.WriteLine("End date value cannot be earlier than start date value, press any key to re-enter session end value");
				Console.ReadKey();
				endDate = _validation.GetValidatedDate("end");
			}

			float time = _calculationsService.GetDuration(startDate, endDate);
			Console.WriteLine($"The duration in Hours {time}");
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
