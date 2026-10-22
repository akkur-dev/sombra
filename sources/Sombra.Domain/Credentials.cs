using CommunityToolkit.Mvvm.ComponentModel;

namespace Sombra.Domain;

/// <summary>
/// Класс модели учетной записи
/// </summary>
public partial class Credentials : ObservableObject
{
    [ObservableProperty]
    private string _resourceName;

    [ObservableProperty]
    private string _resourceUrl;

    [ObservableProperty]
    private string _login;

    [ObservableProperty]
    private string _password;

    [ObservableProperty]
    private string _notes;
}
