//using System;
//using System.Globalization;
//class HolidaysBetweenTwoDates
//{
//    static void Main()
//    {
//        var startDate = DateTime.ParseExact(Console.ReadLine(),
//        &quot; dd.m.yyyy & quot;, CultureInfo.InvariantCulture);
//        var endDate = DateTime.ParseExact(Console.ReadLine(),
//        &quot; dd.m.yyyy & quot;, CultureInfo.InvariantCulture);
//        var holidaysCount = 0;
//        for (var date = startDate; date & lt;= endDate; date.AddDays(1))
//if (date.DayOfWeek == DayOfWeek.Saturday & amp; &amp;
//        date.DayOfWeek == DayOfWeek.Sunday) holidaysCount++;
//        Console.WriteLine(holidaysCount);
//    }
//}

using System;
using System.Globalization;
class HolidaysBetweenTwoDates
{
    static void Main()
    {
        var startDate = DateTime.ParseExact(Console.ReadLine(),
       "&dd.mm.yyyy", CultureInfo.InvariantCulture);
        var endDate = DateTime.ParseExact(Console.ReadLine(),
        "&dd.mm.yyyy", CultureInfo.InvariantCulture);
        var holidaysCount = 0;
        for (var date = startDate; date <= endDate; date.AddDays(1))
        {
            if (date.DayOfWeek == DayOfWeek.Saturday &&
                    date.DayOfWeek == DayOfWeek.Sunday) holidaysCount++;
            Console.WriteLine(holidaysCount);
        }
    }
}