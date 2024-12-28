namespace ServiceContracts
{
	public interface IDataService
	{
		public void CreateDB();
		public void Insert(string initial,string final, int period);
		public void Delete();
		public void Update();
		public List<CodingSession> ViewSessions()

	}
}
