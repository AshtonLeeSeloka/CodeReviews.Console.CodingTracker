using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace Services
{
	internal class ValidationService
	{
		public string dateFormat = "yyyy-mm-dd HH:mm:ss";
		CultureInfo culture = new CultureInfo("en-UK");



		public bool DateValidation(string date) 
		{
			if(DateTime.TryParseExact(date,dateFormat,culture,DateTimeStyles.None,out _))
				return true;
			else
				return false;
		}

		 
	}
}
