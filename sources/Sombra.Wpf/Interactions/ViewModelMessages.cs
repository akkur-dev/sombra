using Sombra.Domain;

namespace Sombra.Wpf.Interactions;

/// <summary>
/// Сообщение о создании новой учетной записи
/// </summary>
public sealed record CreateCredentialsMessage();

/// <summary>
/// Сообщение о редактировании существующей учетной записи
/// </summary>
/// <param name="Credentials">
/// Редактируемая учетная запись
/// </param>
public sealed record EditCredentialsMessage(Credentials Credentials);

/// <summary>
/// Сообщение об отмене редактирования учетной записи
/// </summary>
public sealed record CancelEditCredentialsMessage();

/// <summary>
/// Сообщение о сохранении учетной записи
/// </summary>
/// <param name="Credentials">
/// Сохраняемая учетная запись
/// </param>
public sealed record SaveCredentialsMessage(Credentials Credentials);

/// <summary>
/// Сообщение об удалении учетной записи
/// </summary>
/// <param name="Credentials">
/// Удаляемая учетная запись
/// </param>
public sealed record DeleteCredentialsMessage(Credentials Credentials);
