using System;
using System.Globalization;

namespace Framework
{
    public class PersianDateTime
    {
        public static string GetPersianDate()
        {
            DateTime t = DateTime.Now;
            PersianCalendar persian = new PersianCalendar();
            return persian.GetYear(t) + "/" +
                   persian.GetMonth(t) + "/" +
                   persian.GetDayOfMonth(t);
        }
        public static string GetPersianTime()
        {
            DateTime t = DateTime.Now;
            PersianCalendar ps = new PersianCalendar();
            return ps.GetHour(t) + ":" + ps.GetMinute(t); //+ ":" + ps.GetSecond(t);
        }
        public static string ConvertDateTimeToPersianDateTime(DateTime? t)
        {
            PersianCalendar persian = new PersianCalendar();
            return persian.GetYear((DateTime) t) + "/" +
                   persian.GetMonth((DateTime) t) + "/" +
                   persian.GetDayOfMonth((DateTime) t);
        }
        public int GetAge(DateTime birthDate)
        {
            return DateTime.Now.Year - birthDate.Year;
        }
    }
}
