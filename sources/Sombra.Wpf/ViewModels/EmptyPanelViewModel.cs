using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;

namespace Sombra.Wpf.ViewModels;

/// <summary>
/// Модель представления для панели-заглушки
/// </summary>
public partial class EmptyPanelViewModel : ObservableObject
{
    private readonly ILogger<EmptyPanelViewModel> _logger;

    private readonly IMessenger _messenger;

    /// <summary>
    /// Предоставляет новый экземпляр <see cref="EmptyPanelViewModel"/>
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
    public EmptyPanelViewModel(ILogger<EmptyPanelViewModel> logger, IMessenger messenger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
    }
}
