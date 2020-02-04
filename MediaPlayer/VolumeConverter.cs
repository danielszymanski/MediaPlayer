using System;
using System.Globalization;
using System.Windows.Data;

namespace MediaPlayer
{
    [ValueConversion(typeof(double), typeof(int))]
    class VolumeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double volume = (double)value;
            return Math.Round(volume * 100);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
