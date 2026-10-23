using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Sombra.Wpf.Converters;

/// <summary>
/// Конвертер наличия или отсутствия элементов коллекции в значение <see cref="Visibility"/>
/// </summary>
public sealed class CollectionToVisibilityConverter : IValueConverter
{
    /// <inheritdoc/>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var hasItems = value is ICollectionView c && !c.IsEmpty;
        var isInvert = string.Equals(parameter as string, "Invert", StringComparison.OrdinalIgnoreCase);

        if (isInvert)
        {
            hasItems = !hasItems;
        }

        return hasItems 
            ? Visibility.Visible 
            : Visibility.Collapsed;
    }

    /// <inheritdoc/>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
