using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using Sombra.Domain;
using Sombra.Wpf.Interactions;
using System.Windows;

namespace Sombra.Wpf.ViewModels;

/// <summary>
/// Модель представления для панели просмотра/редактирования
/// </summary>
public partial class ViewEditPanelViewModel : ObservableObject
{
    private readonly ILogger<ViewEditPanelViewModel> _logger;

    private readonly IMessenger _messenger;

    [ObservableProperty]
    private Credentials _credentials;

    [ObservableProperty]
    private bool _isEditing;

    /// <summary>
    /// Предоставляет новый экземпляр <see cref="ViewEditPanelViewModel"/>
    /// </summary>
    /// <param name="logger">
    /// Логгер для данной модели представления
    /// </param>
    /// <param name="messenger">
    /// Мессенджер для обмена данными между VM
    /// </param>
    /// <param name="credentials">
    /// Модель учетных данных для отображения
    /// </param>
    /// <param name="isEditing">
    /// Открывать ли панель в режиме редактирования
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Переданный в аргумент объект не существует в памяти
    /// </exception>
    public ViewEditPanelViewModel(ILogger<ViewEditPanelViewModel> logger, IMessenger messenger, Credentials credentials, bool isEditing)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _logger.LogInformation("Создание нового экземпляра {ViewModelType}", nameof(ViewEditPanelViewModel));

        _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
        _credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
        _isEditing = isEditing;
    }

    [RelayCommand]
    private void Copy(string text)
    {
        if (!String.IsNullOrWhiteSpace(text))
        {
            Clipboard.SetText(text);
        }
    }

    [RelayCommand]
    private void Edit()
    {
        _logger.LogInformation("Запрос на редактирование учетной записи к {Url}", Credentials.ResourceUrl);
        IsEditing = true;
    }

    [RelayCommand]
    private void Delete()
    {
        _logger.LogInformation("Удаление учетной записи к {Url}", Credentials.ResourceUrl);
        _messenger.Send(new DeleteCredentialsMessage(Credentials));
    }

    [RelayCommand]
    private void Save()
    {
        _logger.LogInformation("Сохранение изменений учетной записи к {Url}", Credentials.ResourceUrl);        
        _messenger.Send(new SaveCredentialsMessage(Credentials));
        IsEditing = false;
    }

    [RelayCommand]
    private void Cancel()
    {
        _logger.LogInformation("Отмена редактирования учетной записи к {Url}", Credentials.ResourceUrl);
        IsEditing = false;
    }
}
