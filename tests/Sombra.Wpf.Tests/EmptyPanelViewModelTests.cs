using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using Moq;
using Sombra.Wpf.Interactions;
using Sombra.Wpf.Tests.Helpers;
using Sombra.Wpf.ViewModels;

namespace Sombra.Wpf.Tests;

public class EmptyPanelViewModelTests
{
    private readonly Mock<ILogger<EmptyPanelViewModel>> _mockLogger = new();

    [Fact]
    public void CreateCommand_SendsCreateCredentialsMessage()
    {
        // Arrange
        var messenger = new WeakReferenceMessenger();
        var viewModel = new EmptyPanelViewModel(_mockLogger.Object, messenger);
        var recipient = new TestMessageRecipient<CreateCredentialsMessage>(messenger);

        // Act
        viewModel.CreateCommand.Execute(null);

        // Assert
        Assert.NotNull(recipient.LastMessage);
        Assert.Equal(1, recipient.MessageCount);
    }
}
