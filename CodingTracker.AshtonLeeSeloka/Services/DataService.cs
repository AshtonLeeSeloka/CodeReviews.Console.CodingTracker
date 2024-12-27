using Microsoft.Data.Sqlite;
using System.Configuration;

namespace Services
{
	public class DataService
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
																Duration TEXT)";
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

	}
}
