using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace Sombra.Wpf.Controls;

/// <summary>
/// Контрол поля ввода с заголовком и опциями 
/// </summary>
public sealed class HeaderedTextBox : Control
{
    /// <summary>
    /// Свойство зависимостей для текста заголовка
    /// </summary>
    public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register(
                nameof(Header), 
                typeof(string), 
                typeof(HeaderedTextBox), 
                new PropertyMetadata(string.Empty));

    /// <summary>
    /// Свойство зависимостей для кнопок опций в заголовке
    /// </summary>
    public static readonly DependencyProperty HeaderButtonsProperty =
        DependencyProperty.Register(
            nameof(HeaderButtons), 
            typeof(IEnumerable), 
            typeof(HeaderedTextBox), 
            new PropertyMetadata(null));

    /// <summary>
    /// Свойство зависимостей для текста в поле ввода
    /// </summary>
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
            nameof(Text), 
            typeof(string), 
            typeof(HeaderedTextBox),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    /// <summary>
    /// Свойство зависимостей для поддержки многострочного ввода посредством клавиши RETURN
    /// </summary>
    public static readonly DependencyProperty AcceptsReturnProperty =
        DependencyProperty.Register(
            nameof(AcceptsReturn), 
            typeof(bool), 
            typeof(HeaderedTextBox), 
            new PropertyMetadata(false));

    /// <summary>
    /// Свойство зависимостей для переноса текста
    /// </summary>
    public static readonly DependencyProperty TextWrappingProperty =
        DependencyProperty.Register(
            nameof(TextWrapping), 
            typeof(TextWrapping), 
            typeof(HeaderedTextBox), 
            new PropertyMetadata(TextWrapping.NoWrap));

    /// <summary>
    /// Текст заголовка
    /// </summary>
    public string Header
    {
        get => (string)GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }
    
    /// <summary>
    /// Коллекция кнопок-опций заголовка
    /// </summary>
    public IEnumerable HeaderButtons
    {
        get => (IEnumerable)GetValue(HeaderButtonsProperty);
        set => SetValue(HeaderButtonsProperty, value);
    }
    
    /// <summary>
    /// Текст в поле ввода
    /// </summary>
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    
    /// <summary>
    /// Поддержка многострочного ввода посредством клавиши RETURN
    /// </summary>
    public bool AcceptsReturn
    {
        get => (bool)GetValue(AcceptsReturnProperty);
        set => SetValue(AcceptsReturnProperty, value);
    }

    /// <summary>
    /// Опции переноса текста
    /// </summary>
    public TextWrapping TextWrapping
    {
        get => (TextWrapping)GetValue(TextWrappingProperty);
        set => SetValue(TextWrappingProperty, value);
    }

    /// <summary>
    /// Предоставляет новый статический экземпляр <see cref="HeaderedTextBox"/>
    /// </summary>
    static HeaderedTextBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(HeaderedTextBox),
            new FrameworkPropertyMetadata(typeof(HeaderedTextBox)));
    }
}
