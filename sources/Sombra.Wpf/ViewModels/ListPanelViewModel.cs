using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using Sombra.Domain;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace Sombra.Wpf.ViewModels;

/// <summary>
/// Модель представления для панели списка
/// </summary>
public partial class ListPanelViewModel : ObservableObject
{
    private readonly ILogger<ListPanelViewModel> _logger;

    private readonly IMessenger _messenger;

    private ObservableCollection<Credentials> _credentials;

    [ObservableProperty]
    private string _searchText;

    [ObservableProperty]
    private Credentials _selectedCredentials;

    /// <summary>
    /// Представление списка учетных записей
    /// </summary>
    public ICollectionView CredentialsView { get; }

    /// <summary>
    /// Предоставляет новый экземпляр <see cref="ListPanelViewModel"/>
    /// </summary>
    /// <param name="logger">
    /// Логгер для данной модели представления
    /// </param>
    /// <param name="messenger">
    /// Мессенджер для обмена данными между VM
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Переданный в аргумент объект не существует в памяти
    /// </exception>
    public ListPanelViewModel(ILogger<ListPanelViewModel> logger, IMessenger messenger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));

        _credentials = new ObservableCollection<Credentials>()
        {
            new Credentials { ResourceName = "Test", ResourceUrl = "https://test.com" },
            new Credentials { ResourceName = "Test", ResourceUrl = "https://test.com" },
            new Credentials { ResourceName = "Test", ResourceUrl = "https://test.com" },
            new Credentials { ResourceName = "Test", ResourceUrl = "https://test.com" },
            new Credentials { ResourceName = "Test", ResourceUrl = "https://test.com" },
            new Credentials { ResourceName = "Test", ResourceUrl = "https://test.com" },
            new Credentials { ResourceName = "Test", ResourceUrl = "https://test.com" },
            new Credentials { ResourceName = "Test", ResourceUrl = "https://test.com" },
            new Credentials { ResourceName = "Test", ResourceUrl = "https://test.com" },
            new Credentials { ResourceName = "Test", ResourceUrl = "https://test.com" },
        };

        CredentialsView = CollectionViewSource.GetDefaultView(_credentials);
        CredentialsView.SortDescriptions.Clear();

        var sortLastNameDesc = new SortDescription(nameof(Credentials.ResourceName), ListSortDirection.Ascending);

        CredentialsView.SortDescriptions.Add(sortLastNameDesc);
        CredentialsView.Filter = FilterCredentials;
    }

    /// <summary>
    /// Обрабатывает изменение текста в поисковой строке
    /// </summary>
    /// <param name="value">
    /// Содержимое поисковой строки
    /// </param>
    partial void OnSearchTextChanged(string value)
    {
        CredentialsView.Refresh();
    }

    /// <summary>
    /// Обрабатывает смену выделенной учетной записи в списке
    /// </summary>
    /// <param name="value">
    /// Выделенная учетная запись
    /// </param>
    /// <remarks>
    /// До момента реализации сообщений мессенджера, метод ничего не делает
    /// </remarks>
    partial void OnSelectedCredentialsChanged(Credentials value)
    { }

    /// <summary>
    /// Фильтрует модели учетных записей в списке
    /// </summary>
    /// <param name="obj">
    /// Проверяемая модель
    /// </param>
    /// <returns>
    /// Возвращает <see langword="true"/>, 
    /// если модель содержит введенную поисковую строку 
    /// в имени или URL ресурса
    /// </returns>
    private bool FilterCredentials(object obj)
    {
        return obj is Credentials e &&
             (string.IsNullOrWhiteSpace(SearchText) ||
             e.ResourceName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
             e.ResourceUrl.Contains(SearchText, StringComparison.OrdinalIgnoreCase));
    }
}
