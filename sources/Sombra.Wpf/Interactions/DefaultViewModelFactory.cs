using Microsoft.Extensions.DependencyInjection;
using Sombra.Domain;
using Sombra.Wpf.ViewModels;

namespace Sombra.Wpf.Interactions;

/// <summary>
/// Фабрика для создания моделей представления по умолчанию
/// </summary>
public sealed class DefaultViewModelFactory : IViewModelFactory
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Предоставляет новый экземпляр <see cref="DefaultViewModelFactory"/>
    /// </summary>
    /// <param name="serviceProvider">
    /// Провайдер зависимостей
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Переданный в аргумент объект не существует в памяти
    /// </exception>
    public DefaultViewModelFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }

    /// <inheritdoc/>
    public EditPanelViewModel CreateEditPanel(Credentials credentials)
    {
        return ActivatorUtilities.CreateInstance<EditPanelViewModel>(_serviceProvider, credentials);
    }

    /// <inheritdoc/>
    public EmptyPanelViewModel CreateEmptyPanel()
    {
        return ActivatorUtilities.CreateInstance<EmptyPanelViewModel>(_serviceProvider);
    }

    /// <inheritdoc/>
    public ListPanelViewModel CreateListPanel()
    {
        return ActivatorUtilities.CreateInstance<ListPanelViewModel>(_serviceProvider);
    }

    /// <inheritdoc/>
    public ViewPanelViewModel CreateViewPanel(Credentials credentials)
    {
        return ActivatorUtilities.CreateInstance<ViewPanelViewModel>(_serviceProvider, credentials);
    }
}
