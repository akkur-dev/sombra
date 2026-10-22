using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;

namespace Sombra.Wpf.ViewModels;

/// <summary>
/// Модель представления для панели списка
/// </summary>
public partial class ListPanelViewModel : ObservableObject
{
    private readonly ILogger<ListPanelViewModel> _logger;

    private readonly IMessenger _messenger;

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
    }
}
