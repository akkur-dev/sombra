using CommunityToolkit.Mvvm.ComponentModel;

namespace Sombra.Domain;

/// <summary>
/// Класс модели учетной записи
/// </summary>
public partial class Credentials : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsValid))]
    private string _resourceUrl;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsValid))]
    private string _login;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsValid))]
    private string _password;

    [ObservableProperty]
    private string _notes;

    /// <summary>
    /// Валиден ли текущий экземпляр <see cref="Credentials"/>
    /// </summary>
    public bool IsValid
    {
        get =>  !String.IsNullOrWhiteSpace(ResourceUrl) && 
                !String.IsNullOrWhiteSpace(Login) && 
                !String.IsNullOrWhiteSpace(Password);
    }
}
