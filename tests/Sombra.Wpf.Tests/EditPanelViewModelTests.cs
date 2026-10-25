using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using Moq;
using Sombra.Domain;
using Sombra.Wpf.Interactions;
using Sombra.Wpf.Tests.Helpers;
using Sombra.Wpf.ViewModels;

namespace Sombra.Wpf.Tests
{
    public class EditPanelViewModelTests
    {
        private readonly Mock<ILogger<EditPanelViewModel>> _mockLogger;

        private const string TEST_RESOURCE_URL = "https://github.com";

        private const string TEST_RESOURCE_LOGIN = "admin";

        public EditPanelViewModelTests()
        {
            _mockLogger = new();
        }

        [Fact]
        public void SaveCommand_SendsSaveCredentialsMessage()
        {
            // Arrange
            var credentials = new Credentials()
            {
                ResourceUrl = TEST_RESOURCE_URL,
                Login = TEST_RESOURCE_LOGIN
            };

            var messenger = new WeakReferenceMessenger();
            var viewModel = new EditPanelViewModel(_mockLogger.Object, messenger, credentials);
            var recipient = new TestMessageRecipient<SaveCredentialsMessage>(messenger);

            // Act
            viewModel.SaveCommand.Execute(null);

            // Assert
            Assert.NotNull(recipient.LastMessage);
            Assert.Equal(1, recipient.MessageCount);
            Assert.Equal(TEST_RESOURCE_URL, recipient.LastMessage.Credentials.ResourceUrl);
            Assert.Equal(TEST_RESOURCE_LOGIN, recipient.LastMessage.Credentials.Login);
        }

        [Fact]
        public void CancelCommand_SendsCancelEditCredentialsMessage()
        {
            // Arrange
            var messenger = new WeakReferenceMessenger();
            var viewModel = new EditPanelViewModel(_mockLogger.Object, messenger, new Credentials());
            var recipient = new TestMessageRecipient<CancelEditCredentialsMessage>(messenger);

            // Act
            viewModel.CancelCommand.Execute(null);

            // Assert
            Assert.NotNull(recipient.LastMessage);
            Assert.Equal(1, recipient.MessageCount);
        }
    }
}
