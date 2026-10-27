using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using Sombra.Domain;
using Sombra.Wpf.Interactions;

namespace Sombra.Wpf.ViewModels;

/// <summary>
/// Модель представления главного окна
/// </summary>
public partial class MainViewModel : ObservableObject
{
    private readonly ILogger<MainViewModel> _logger;

    private readonly IMessenger _messenger;

    private readonly IViewModelFactory _panelFactory;

    [ObservableProperty]
    private ListPanelViewModel _listPanel;

    [ObservableProperty]
    private object _credentialsPanel;

    /// <summary>
    /// Предоставляет новый экземпляр <see cref="MainViewModel"/>
    /// </summary>
    /// <param name="logger">
    /// Логгер для данной модели представления
    /// </param>
    /// <param name="messenger">
    /// Мессенджер для обмена данными между VM
    /// </param>
    /// <param name="panelFactory">
    /// Фабрика моделей представления для панелей
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Переданный в аргумент объект не существует в памяти
    /// </exception>
    public MainViewModel(ILogger<MainViewModel> logger, IMessenger messenger, IViewModelFactory panelFactory)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _logger.LogInformation("Создание нового экземпляра {ViewModelType}", nameof(MainViewModel));

        _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
        _panelFactory = panelFactory ?? throw new ArgumentNullException(nameof(panelFactory));

        ListPanel = _panelFactory.CreateListPanel();
        CredentialsPanel = _panelFactory.CreateEmptyPanel();

        _messenger.Register<CreateCredentialsMessage>(this, (r, m) =>
        {
            CredentialsPanel = _panelFactory.CreateViewEditPanel(new Credentials(), true);
        });
    }
}
