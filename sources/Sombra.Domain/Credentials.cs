using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sombra.Domain;

/// <summary>
/// Класс модели учетной записи
/// </summary>
public partial class Credentials : ObservableValidator
{
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Поле 'URL' не может быть пустым")]
    [Url(ErrorMessage = "Введите валидный URL (например, https://github.com)")]
    [NotifyPropertyChangedFor(nameof(IsValid))]
    private string _resourceUrl;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Поле 'Логин' не может быть пустым")]
    [NotifyPropertyChangedFor(nameof(IsValid))]
    private string _login;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Поле 'Пароль' не может быть пустым")]
    [NotifyPropertyChangedFor(nameof(IsValid))]
    private string _password;

    [ObservableProperty]
    private string _notes;

    /// <summary>
    /// Валиден ли текущий экземпляр <see cref="Credentials"/>
    /// </summary>
    public bool IsValid => !HasErrors;
}
