using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public class CalculationsService
	{
		public float GetDuration(DateTime startDate, DateTime endDate) 
		{
			float time = Convert.ToInt32((endDate-startDate).TotalHours);
			Console.WriteLine(time);
			return time;
		
		}
	}
}
