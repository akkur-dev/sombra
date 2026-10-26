using CommunityToolkit.Mvvm.Messaging;

namespace Sombra.Wpf.Tests.Helpers;

/// <summary>
/// Тестовый получатель сообщений конкретного типа
/// </summary>
/// <typeparam name="TMessage">
/// Тип получаемого сообщения
/// </typeparam>
public sealed class TestMessageRecipient<TMessage> where TMessage: class
{
    /// <summary>
    /// Последнее полученное сообщение
    /// </summary>
    public TMessage LastMessage { get; private set; }

    /// <summary>
    /// Счетчик полученных сообщений
    /// </summary>
    public int MessageCount { get; private set; }

    /// <summary>
    /// Предоставляет новый экземпляр <see cref="TestMessageRecipient{TMessage}"/>
    /// </summary>
    /// <param name="messenger">
    /// Мессенджер для обмена данными
    /// </param>
    public TestMessageRecipient(IMessenger messenger)
    {
        messenger.Register<TestMessageRecipient<TMessage>, TMessage>(this, (recipient, message) =>
        {
            recipient.LastMessage = message;
            recipient.MessageCount++;
        });
    }
}
