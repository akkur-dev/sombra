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
    /// Создает новую модель представления для панели просмотра и редактирования
    /// </summary>
    /// <remarks>
    /// Для создания новой учетной записи, следует передать 
    /// новый пустой экземпляр <see cref="Credentials"/> в качестве аргумента
    /// </remarks>
    /// <param name="credentials">
    /// Редактируемые данные учетной записи
    /// </param>
    /// <param name="isEditing">
    /// Открывать ли панель в режиме редактирования
    /// </param>
    /// <returns>
    /// Новый экземпляр <see cref="ViewEditPanelViewModel"/>
    /// </returns>
    ViewEditPanelViewModel CreateViewEditPanel(Credentials credentials, bool isEditing);
}
