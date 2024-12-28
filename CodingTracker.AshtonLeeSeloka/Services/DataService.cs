using Microsoft.Data.Sqlite;
using ServiceContracts;
using System.Configuration;
using Dapper;
using CodingTracker.AshtonLeeSeloka.Models;
using Spectre.Console;


namespace Services
{
	public class DataService 
	{
		private string? _DBConnectionString = ConfigurationManager.AppSettings.Get("DBConnectionString");
		private List<CodingSession> _Sessions = new List<CodingSession>();
		private CalculationsService _CalculationsService = new CalculationsService();


		/// <summary>
		/// Creates a new Instance of DB Coding_Sessions if not Present
		/// </summary>
		public void CreateDB()
		{
			try 
			{
				using (var connection = new SqliteConnection(_DBConnectionString)) 
				{
					connection.Open();
					var tableCmd = connection.CreateCommand();
					tableCmd.CommandText = @"CREATE TABLE IF NOT EXISTS Coding_Sessions(
																Id INTEGER PRIMARY KEY AUTOINCREMENT,
																StartTime TEXT,
																EndTime TEXT,
																Duration INTEGER)";
					tableCmd.ExecuteNonQuery();
				}
			} 
			catch (Exception ex) 
			{
				Console.Clear();
				Console.WriteLine(ex.Message);
				Console.WriteLine("Type 0 to exit");

			}
		
		}

		/// <summary>
		/// Method to Delete selected CodingSession object
		/// </summary>
		/// <param name="session">Object to be deleted</param>
		public void Delete(CodingSession session)
		{
			var sqlCommand = "DELETE FROM coding_Sessions WHERE Id = @ID";
			var connection = new SqliteConnection(_DBConnectionString);
			connection.Execute(sqlCommand, new { ID = session.Id });


			Console.WriteLine("\nDeletion of Coding session succesful, Type any Key to exit");
			Console.ReadLine();
			
		}

		/// <summary>
		/// Method to Insert user inputs into coding_sessions database
		/// </summary>
		/// <param name="startTime">Session Start Time</param>
		/// <param name="endTime">Session End Time</param>
		/// <param name="duration">Duration of Session</param>
		public void Insert(string startTime, string endTime, int duration)
		{
			var sqlCommand = "INSERT INTO Coding_Sessions (StartTime, EndTime, Duration) VALUES (@StartTime, @EndTime, @Duration)";
			var connection = new SqliteConnection(_DBConnectionString);
			connection.Execute(sqlCommand, new { StartTime = startTime, EndTime = endTime, Duration = duration});
			Console.WriteLine("\nEntry inserted Succesfully Press Any Key to exit");
			Console.ReadKey();
		}

		/// <summary>
		/// Update selected object based on ID 
		/// </summary>
		/// <param name="session">Object to modify</param>
		public void Update(CodingSession session)
		{

			string newStartTime =AnsiConsole.Ask<string>("[green]Enter Updated Session start (yyyy-mm-dd HH:mm:ss)[/]");
			string newEndTime = AnsiConsole.Ask<string>("[green][green]Enter Updated Session End (yyyy-mm-dd HH:mm:ss)[/][/]");
			//int Duration = _CalculationsService.GetDuration(newStartTime, newEndTime);

			var sqlCommand = "UPDATE coding_Sessions SET StartTime = @StartTime,EndTime = @EndTime, Duration = @Duration WHERE Id = @ID ";
			var connection = new SqliteConnection(_DBConnectionString);
			connection.Execute(sqlCommand, new { ID = session.Id, StartTime  = newStartTime, EndTime = newEndTime/*, Duration = Duration*/ });

			Console.WriteLine("\nUpdating of Coding session succesful, Type any Key to exit");
			Console.ReadLine();
		}

		/// <summary>
		/// Gets all sessions in the form of List<CodingSession>
		/// </summary>
		/// <returns>List<CodingSession></returns>
		public List<CodingSession> GetAllSessions()
		{

			_Sessions.Clear();
			
			var sqlCommand = "SELECT * FROM Coding_Sessions";
			var connection = new SqliteConnection(_DBConnectionString);
			var codingSessions = connection.Query<CodingSession>(sqlCommand);

			foreach (var codingSession in codingSessions) 
			{
				
				_Sessions.Add(new CodingSession()
				{
					Id = codingSession.Id,
					StartTime = codingSession.StartTime,
					EndTime = codingSession.EndTime,
					Duration = codingSession.Duration,
				});
			}

			return _Sessions;

		}
	}
}
