using System;
using System.Globalization;
using System.Windows.Data;

namespace SubScreenDisplay
{
    public class TimeSpanToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TimeSpan timeSpan)
            {
                return timeSpan.ToString(@"mm\:ss");
            }
            else if (value is double seconds)
            {
                return TimeSpan.FromSeconds(seconds).ToString(@"mm\:ss");
            }
            return "00:00";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ProgressPercentageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double[] values && values.Length == 2)
            {
                double current = values[0];
                double total = values[1];
                
                if (total > 0)
                    return (current / total) * 100;
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class PlayStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isPlaying)
            {
                // 使用 Segoe Fluent Icons 字体中的图标
                return isPlaying ? "\uE769" : "\uE768"; // 暂停图标 : 播放图标
            }
            return "\uE768"; // 默认返回播放图标
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
