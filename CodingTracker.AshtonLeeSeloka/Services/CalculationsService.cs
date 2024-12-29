using CodingTracker.AshtonLeeSeloka.Models;
namespace Services;

public class CalculationsService
{
	public float GetDuration(DateTime startDate, DateTime endDate)
	{
		float time = (float)((endDate - startDate).TotalHours);
		return time;
	}

	public float? CalculateAverage(List<CodingSession> sessons)
	{
		float? sum = CalculateSum(sessons);
		float numberOfSessions = sessons.Count;
		float? average = sum / numberOfSessions;
		return average;
	}

	public float? CalculateSum(List<CodingSession> sessons)
	{
		float? sum = 0;
		foreach (CodingSession sess in sessons)
		{
			sum = sum + sess.Duration;
		}

		return sum;
	}
}
