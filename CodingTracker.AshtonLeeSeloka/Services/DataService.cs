using Microsoft.Data.Sqlite;
using ServiceContracts;
using System.Configuration;
using Dapper;
using CodingTracker.AshtonLeeSeloka.Models;

namespace Services
{
	public class DataService 
	{
		private string? _DBConnectionString = ConfigurationManager.AppSettings.Get("DBConnectionString");
		private List<CodingSession> Sessions = new List<CodingSession>();


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

		public void Delete(CodingSession session)
		{
			var sqlCommand = "DELETE FROM coding_Sessions WHERE Id = @ID";
			var connection = new SqliteConnection(_DBConnectionString);
			connection.Execute(sqlCommand, new { ID = session.Id });


			Console.WriteLine("Deletion of Coding session succesful, Type any Key to exit");
			Console.ReadLine();
			
		}

		public void Insert(string startTime, string endTime, int duration)
		{
			var sqlCommand = "INSERT INTO Coding_Sessions (StartTime, EndTime, Duration) VALUES (@StartTime, @EndTime, @Duration)";
			var connection = new SqliteConnection(_DBConnectionString);
			connection.Execute(sqlCommand, new { StartTime = startTime, EndTime = endTime, Duration = duration});
			Console.WriteLine("Entry inserted Succesfully Press Any Key to exit");
			Console.ReadKey();
		}

		public void Update()
		{
			throw new NotImplementedException();
		}

		public List<CodingSession> GetAllSessions()
		{

			Sessions.Clear();
			
			var sqlCommand = "SELECT * FROM Coding_Sessions";
			var connection = new SqliteConnection(_DBConnectionString);
			var codingSessions = connection.Query<CodingSession>(sqlCommand);

			foreach (var codingSession in codingSessions) 
			{
				
				Sessions.Add(new CodingSession()
				{
					Id = codingSession.Id,
					StartTime = codingSession.StartTime,
					EndTime = codingSession.EndTime,
					Duration = codingSession.Duration,
				});
			}

			return Sessions;

		}
	}
}
