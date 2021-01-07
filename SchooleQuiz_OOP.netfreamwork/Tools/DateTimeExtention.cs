using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SchooleQuiz_OOP.Tools
{
    public static class DateTimeExtention
    {
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar persian = new PersianCalendar();
            return $"{persian.GetYear(value)}/{persian.GetMonth(value)}/{persian.GetDayOfMonth(value)} - {value.ToString("hh:mm tt")}";
        }
    }
}
