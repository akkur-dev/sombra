using Sombra.Domain;

namespace Sombra.Wpf.Interactions;

/// <summary>
/// Сообщение о создании новой учетной записи
/// </summary>
public sealed record CreateCredentialsMessage();

/// <summary>
/// Сообщение об изменении существующей учетной записи
/// </summary>
/// <param name="Credentials">
/// Обновленная учетная запись
/// </param>
public sealed record SaveCredentialsMessage(Credentials Credentials);

/// <summary>
/// Сообщение о редактировании учетной записи
/// </summary>
/// <param name="Credentials">
/// Редактируемая учетная запись
/// </param>
public sealed record EditCredentialsMessage(Credentials Credentials);

/// <summary>
/// Сообщение об удалении учетной записи
/// </summary>
/// <param name="Credentials">
/// Удаляемая учетная запись
/// </param>
public sealed record DeleteCredentialsMessage(Credentials Credentials);
