using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using Sombra.Domain;

namespace Sombra.Wpf.ViewModels;

/// <summary>
/// Модель представления для панели редактирования
/// </summary>
public partial class EditPanelViewModel : ObservableObject
{
    private readonly ILogger<EditPanelViewModel> _logger;

    private readonly IMessenger _messenger;

    [ObservableProperty]
    private Credentials _credentials;

    /// <summary>
    /// Предоставляет новый экземпляр <see cref="EditPanelViewModel"/>
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
    public EditPanelViewModel(ILogger<EditPanelViewModel> logger, IMessenger messenger, Credentials credentials)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));

        Credentials = credentials;
    }
}
