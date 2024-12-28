using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Services
{
	public class ValidationService
	{
		public string dateFormat = "yyyy-MM-dd HH:mm:ss";
		CultureInfo culture = new CultureInfo("en-US");

		public bool DateValidation(string date) 
		{
			if(DateTime.TryParseExact(date,dateFormat,culture,DateTimeStyles.None,out _))
				return true;
			else
				return false;
		}

		public DateTime ConvertToDateTime(string validatedDate)
		{
			DateTime dateTime = DateTime.ParseExact(validatedDate, dateFormat, culture, DateTimeStyles.None);
			return dateTime;
		}


	}
}
