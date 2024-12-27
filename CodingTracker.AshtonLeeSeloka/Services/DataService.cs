using Microsoft.Data.Sqlite;
using ServiceContracts;
using System.Configuration;
using Dapper;

namespace Services
{
	public class DataService : IDataService
	{
		private string? _DBConnectionString = ConfigurationManager.AppSettings.Get("DBConnectionString");


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

		public void Delete()
		{
			throw new NotImplementedException();
		}

		public void Insert(string initial, string final, int period)
		{
			var sqlCommand = "INSERT INTO Coding_Sessions (StartTime, EndTime, Duration) VALUES (@StartTime, @EndTime, @Duration)";
			var connection = new SqliteConnection(_DBConnectionString);
			connection.Execute(sqlCommand, new { StartTime = initial, EndTime = final, Duration = period});
		}

		public void Update()
		{
			throw new NotImplementedException();
		}
	}
}
