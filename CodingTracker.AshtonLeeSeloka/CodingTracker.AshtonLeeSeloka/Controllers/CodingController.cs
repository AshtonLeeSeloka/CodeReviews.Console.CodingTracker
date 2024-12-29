using CodingTracker.AshtonLeeSeloka.Models;
using CodingTracker.AshtonLeeSeloka.Views;
using Services;
using Spectre.Console;
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
			_dataService.Insert(startDate.ToString(), endDate.ToString(), (float)System.Math.Round(time, 2));


		}

		public void TimerInsert()
		{
			AnsiConsole.WriteLine("Press Any key to start the timer");
			Console.ReadKey();
			Console.Clear();

			DateTime startTime = DateTime.Now;

			AnsiConsole.WriteLine("Timer in Progress");
			AnsiConsole.WriteLine("Press Any key to End the timer");
			Console.ReadKey();

			DateTime endTime = DateTime.Now;

			string startTimeAsString = startTime.ToString("yyyy/MM/dd HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
			string endTimeAsString = startTime.ToString("yyyy/MM/dd HH:mm:ss", new System.Globalization.CultureInfo("en-US"));

			float duation = (float)System.Math.Round(_calculationsService.GetDuration(startTime, endTime), 2);
			_dataService.Insert(startTimeAsString, endTimeAsString, duation);
			AnsiConsole.WriteLine($"Succesfully inserted session with duration of {duation}");
			Console.ReadKey();
		}

		public void ViewData()
		{
			Console.Clear();
			List<CodingSession> codingSessions = _dataService.GetAllSessions();
			_view.DisplaySessionView(codingSessions);

			var selection = _view.DisplayViewSelection();

			switch (selection)
			{
				case MenuViewData.View_in_descending_order:
					DateDescendingSessions(codingSessions);
					break;
				case MenuViewData.View_in_ascending_order:

					DateAscendingSession(codingSessions);
					break;
				case MenuViewData.Back:
					break;
			}

		}

		public void DateAscendingSession(List<CodingSession> codingSessions)
		{
			codingSessions.Sort((x, y) => x.StartTime.CompareTo(y.StartTime));
			_view.DisplaySessionView(codingSessions);
			Console.WriteLine("Press any key to return");
			Console.ReadKey();

		}

		public void DateDescendingSessions(List<CodingSession> codingSessions)
		{

			codingSessions.Sort((x, y) => DateTime.Parse(y.StartTime).CompareTo(DateTime.Parse(x.StartTime)));
			//codingSessions.OrderByDescending(x => DateTime.Parse(x.StartTime));
			_view.DisplaySessionView(codingSessions);
			Console.WriteLine("Press any key to return");
			Console.ReadKey();

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

		public void GenerateReport()
		{
			Console.Clear();
			var selection = _view.ReportMenuView();

			switch (selection)
			{
				case MenuItems.MenuReport.View_All_Data:
					ReportAllSessions();
					break;
				case MenuItems.MenuReport.Specify_Report_Range:
					ReportRangeSessions();
					break;
			}

		}

		public void ReportAllSessions()
		{
			List<CodingSession> codingSessions = _dataService.GetAllSessions();
			codingSessions.Sort((x, y) => x.StartTime.CompareTo(y.StartTime));

			_view.DisplaySessionView(codingSessions);

			float? sum = _calculationsService.CalculateSum(codingSessions);
			float? avg = _calculationsService.CalculateAverage(codingSessions);
			int entries = codingSessions.Count();
			string? startDate = codingSessions[0].StartTime;
			string? endDate = codingSessions[(entries - 1)].EndTime;

			_view.DisplayAllReportDataView(startDate, endDate, entries, avg, sum);
		}

		public void ReportRangeSessions()
		{
			List<CodingSession> session = _dataService.GetAllSessions();
			DateTime startDate = _validation.GetValidatedDate("start");
			DateTime endDate = _validation.GetValidatedDate("end");

			while (startDate > endDate)
			{
				Console.WriteLine("End date value cannot be earlier than start date value, press any key to re-enter session end value");
				Console.ReadKey();
				endDate = _validation.GetValidatedDate("end");
			}

			for (int i = 0; i < session.Count; i++)
			{
				DateTime iStart = DateTime.Parse(session[i].StartTime);
				DateTime iEnd = DateTime.Parse(session[i].StartTime);

				if (iStart < startDate || iEnd > endDate)
				{
					session.RemoveAt(i);
				}


			}

			session.Sort((x, y) => x.StartTime.CompareTo(y.StartTime));

			_view.DisplaySessionView(session);
			float? sum = _calculationsService.CalculateSum(session);
			float? avg = _calculationsService.CalculateAverage(session);
			int entries = session.Count();
			string? startDateRange = session[0].StartTime;
			string? endDateRange = session[(entries - 1)].EndTime;
			_view.DisplayAllReportDataView(startDateRange, endDateRange, entries, avg, sum);


		}


	}
}
