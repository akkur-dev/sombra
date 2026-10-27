using CommunityToolkit.Mvvm.ComponentModel;

namespace Sombra.Domain;

/// <summary>
/// Класс модели учетной записи
/// </summary>
public partial class Credentials : ObservableObject
{
    [ObservableProperty]
    private string _resourceUrl;

    [ObservableProperty]
    private string _login;

    [ObservableProperty]
    private string _password;

    [ObservableProperty]
    private string _notes;

    /// <summary>
    /// Проверяет, валиден ли текущий экземпляр <see cref="Credentials"/>
    /// </summary>
    /// <returns>
    /// Возвращает <see langword="true"/>, 
    /// если все обязательные поля заполнены
    /// </returns>
    public bool IsValid()
    {
        return 
            !String.IsNullOrWhiteSpace(ResourceUrl) && 
            !String.IsNullOrWhiteSpace(Login) && 
            !String.IsNullOrWhiteSpace(Password);
    }
}
