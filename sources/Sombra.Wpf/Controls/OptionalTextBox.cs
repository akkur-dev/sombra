using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace Sombra.Wpf.Controls;

/// <summary>
/// Контрол поля ввода с опциями и опциональным заголовком
/// </summary>
public sealed class OptionalTextBox : Control
{
    /// <summary>
    /// Свойство зависимостей для текста заголовка
    /// </summary>
    public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register(
                nameof(Header), 
                typeof(string), 
                typeof(OptionalTextBox), 
                new PropertyMetadata(string.Empty));

    /// <summary>
    /// Свойство зависимостей для кнопок опций в заголовке
    /// </summary>
    public static readonly DependencyProperty OptionButtonsProperty =
        DependencyProperty.Register(
            nameof(OptionButtons), 
            typeof(IEnumerable), 
            typeof(OptionalTextBox), 
            new PropertyMetadata(null));

    /// <summary>
    /// Свойство зависимостей для текста в поле ввода
    /// </summary>
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
            nameof(Text), 
            typeof(string), 
            typeof(OptionalTextBox),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    /// <summary>
    /// Свойство зависимостей для поддержки многострочного ввода посредством клавиши RETURN
    /// </summary>
    public static readonly DependencyProperty AcceptsReturnProperty =
        DependencyProperty.Register(
            nameof(AcceptsReturn), 
            typeof(bool), 
            typeof(OptionalTextBox), 
            new PropertyMetadata(false));

    /// <summary>
    /// Свойство зависимостей для переноса текста
    /// </summary>
    public static readonly DependencyProperty TextWrappingProperty =
        DependencyProperty.Register(
            nameof(TextWrapping), 
            typeof(TextWrapping), 
            typeof(OptionalTextBox), 
            new PropertyMetadata(TextWrapping.NoWrap));

    /// <summary>
    /// Свойство зависимостей для переключения режимов "чтение - редактирование"
    /// </summary>
    public static readonly DependencyProperty IsReadOnlyProperty =
        DependencyProperty.Register(
            nameof(IsReadOnly),
            typeof(bool),
            typeof(OptionalTextBox),
            new PropertyMetadata(false));

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
    public IEnumerable OptionButtons
    {
        get => (IEnumerable)GetValue(OptionButtonsProperty);
        set => SetValue(OptionButtonsProperty, value);
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
    /// Используется ли поле ввода только для чтения
    /// </summary>
    public bool IsReadOnly
    {
        get => (bool)GetValue(IsReadOnlyProperty);
        set => SetValue(IsReadOnlyProperty, value);
    }

    /// <summary>
    /// Предоставляет новый статический экземпляр <see cref="HeaderedTextBox"/>
    /// </summary>
    static OptionalTextBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(OptionalTextBox),
            new FrameworkPropertyMetadata(typeof(OptionalTextBox)));
    }
}
