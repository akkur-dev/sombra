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
    /// Проверяет, заполнен ли текущий экземпляр 
    /// <see cref="Credentials"/> данными.
    /// </summary>
    /// <returns>
    /// Возвращает <see langword="true"/>, 
    /// если ни одно поле не содержит валидного текста
    /// </returns>
    public bool IsEmpty()
    {
        return 
            String.IsNullOrWhiteSpace(ResourceUrl) && 
            String.IsNullOrWhiteSpace(Login) && 
            String.IsNullOrWhiteSpace(Password) && 
            String.IsNullOrWhiteSpace(Notes);
    }
}
