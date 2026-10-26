using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using Sombra.Domain;

namespace Sombra.Wpf.ViewModels;

/// <summary>
/// Модель представления для панели просмотра
/// </summary>
public partial class ViewPanelViewModel : ObservableObject
{
    private readonly ILogger<ViewPanelViewModel> _logger;

    private IMessenger _messenger;

    [ObservableProperty]
    private Credentials _credentials;

    /// <summary>
    /// Предоставляет новый экземпляр <see cref="ViewPanelViewModel"/>
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
    public ViewPanelViewModel(ILogger<ViewPanelViewModel> logger, IMessenger messenger, Credentials credentials)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
        _credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
    }
}
