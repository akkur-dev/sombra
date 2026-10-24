using System.Windows;
using System.Windows.Controls;

namespace Sombra.Wpf.Controls;

/// <summary>
/// Контрол заголовка со множеством кнопок
/// </summary>
public sealed class MultiButtonHeader : ItemsControl
{
    /// <summary>
    /// Свойство зависимостей для текста заголовка
    /// </summary>
    public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register(
                nameof(Header), 
                typeof(string), 
                typeof(MultiButtonHeader), 
                new PropertyMetadata(string.Empty));

    /// <summary>
    /// Текст заголовка
    /// </summary>
    public string Header
    {
        get => (string)GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    /// <summary>
    /// Предоставляет новый статический экземпляр <see cref="MultiButtonHeader"/>
    /// </summary>
    static MultiButtonHeader()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(MultiButtonHeader),
            new FrameworkPropertyMetadata(typeof(MultiButtonHeader)));
    }
}
