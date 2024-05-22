using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        private string date;
        public string Date { get; set; }

        public int FindDifference(string[] dateOne, string[] dateTwo)
        {
            int YearOne = int.Parse(dateOne[0]);
            int YearTwo = int.Parse(dateTwo[0]);
            int monthOne = int.Parse(dateOne[1]);
            int monthTwo = int.Parse(dateTwo[1]);
            int dayOne = int.Parse(dateOne[2]);
            int dayTwo = int.Parse(dateTwo[2]);

            DateTime date1 = new DateTime(YearOne, monthOne, dayOne);
            DateTime date2 = new DateTime(YearTwo, monthTwo, dayTwo);

            TimeSpan t = date2.Subtract(date1);
            int result = (int)t.TotalDays;

            return Math.Abs(result);
        }
    }
}
