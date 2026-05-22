using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace MiniZotero.Converters
{
    public sealed class StarredBrushConverter : IValueConverter
    {
        private static readonly IBrush StarredBrush = new SolidColorBrush(Color.Parse("#FACC15"));
        private static readonly IBrush DefaultBrush = new SolidColorBrush(Color.Parse("#AAB6C6"));

        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value is true ? StarredBrush : DefaultBrush;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
