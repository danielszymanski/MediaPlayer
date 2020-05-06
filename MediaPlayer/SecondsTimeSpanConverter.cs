﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

//Converter class

namespace MediaPlayer
{
    [ValueConversion(typeof(double), typeof(TimeSpan))]
    class SecondsTimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double time = (double)value;
            return TimeSpan.FromSeconds(time).ToString("hh\\:mm\\:ss");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
