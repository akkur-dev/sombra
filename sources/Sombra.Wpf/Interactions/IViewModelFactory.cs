using Sombra.Wpf.ViewModels;

namespace Sombra.Wpf.Interactions;

/// <summary>
/// Абстракция фабрики для создания моделей представления 
/// различных панелей в приложении
/// </summary>
public interface IViewModelFactory
{
    /// <summary>
    /// Создает новую модель представления для панеи списка
    /// </summary>
    /// <returns>
    /// Новый экземпляр <see cref="ListPanelViewModel"/>
    /// </returns>
    ListPanelViewModel CreateListPanel();

    /// <summary>
    /// Создает новую модель представления для панеи-заглушки
    /// </summary>
    /// <returns>
    /// Новый экземпляр <see cref="EmptyPanelViewModel"/>
    /// </returns>
    EmptyPanelViewModel CreateEmptyPanel();
}
