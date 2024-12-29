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
					TimerInsert();
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
			_dataService.Insert(startDate.ToString(), endDate.ToString(), (float)System.Math.Round(time,2));
			
			
		}

		public void TimerInsert() 
		{
			AnsiConsole.WriteLine("Press [red]Any key[/] to start the timer");
			Console.ReadKey();	
			DateTime startTime = DateTime.Now;
			AnsiConsole.WriteLine("Timer in Progress");
			AnsiConsole.WriteLine("Press [red]Any key[/] to End the timer");
			Console.ReadKey();
			DateTime endTime = DateTime.Now;
			float duation = (float) System.Math.Round( _calculationsService.GetDuration(startTime, endTime),2);
			_dataService.Insert(startTime.ToString("yyyy-MM-dd HH:mm:ss"),endTime.ToString("yyyy-MM-dd HH:mm:ss"),duation);
			AnsiConsole.WriteLine($"Succesfully inserted session with duration of {duation}");
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
