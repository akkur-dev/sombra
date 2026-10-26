using Sombra.Domain;
using Sombra.Wpf.ViewModels;

namespace Sombra.Wpf.Interactions;

/// <summary>
/// Абстракция фабрики для создания моделей представления 
/// различных панелей в приложении
/// </summary>
public interface IViewModelFactory
{
    /// <summary>
    /// Создает новую модель представления для панели списка
    /// </summary>
    /// <returns>
    /// Новый экземпляр <see cref="ListPanelViewModel"/>
    /// </returns>
    ListPanelViewModel CreateListPanel();

    /// <summary>
    /// Создает новую модель представления для панели-заглушки
    /// </summary>
    /// <returns>
    /// Новый экземпляр <see cref="EmptyPanelViewModel"/>
    /// </returns>
    EmptyPanelViewModel CreateEmptyPanel();

    /// <summary>
    /// Создает новую модель представления для панели редактирования
    /// </summary>
    /// <remarks>
    /// Для создания новой учетной записи, следует передать 
    /// новый пустой экземпляр <see cref="Credentials"/> в качестве аргумента
    /// </remarks>
    /// <param name="credentials">
    /// Редактируемые данные учетной записи
    /// </param>
    /// <returns>
    /// Новый экземпляр <see cref="EditPanelViewModel"/>
    /// </returns>
    EditPanelViewModel CreateEditPanel(Credentials credentials);

    /// <summary>
    /// Создает новую модель представления для панели просмотра
    /// </summary>
    /// <param name="credentials">
    /// Данные учетной записи для отображения
    /// </param>
    /// <returns>
    /// Новый экземпляр <see cref="ViewPanelViewModel"/>
    /// </returns>
    ViewPanelViewModel CreateViewPanel(Credentials credentials);
}
