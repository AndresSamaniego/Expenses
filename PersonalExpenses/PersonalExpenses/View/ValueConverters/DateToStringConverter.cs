using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace PersonalExpenses.View.ValueConverters
{
    public class DateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime fecha = (DateTime)value;

            var difference = DateTime.Now - fecha;

            if (difference.TotalMinutes < 60)
                return $"Hace {difference.TotalMinutes:0} minutes";
            if (difference.TotalHours < 24)
                return $"Hace {difference.TotalHours:0} horas";
            if (difference.TotalHours < 48)
                return "Ayer";
            if (difference.TotalDays < 7)
                return $"Hace {difference.TotalDays:0} dias";

            return $"{fecha:d}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateTime.Now;
        }
    }
}
