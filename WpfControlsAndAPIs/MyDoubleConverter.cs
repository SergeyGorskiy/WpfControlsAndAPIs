using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Converters;

namespace WpfControlsAndAPIs
{
    public class MyDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double v = (double)value;
            return (int)v;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}