using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using Moq;
using Sombra.Domain;
using Sombra.Wpf.Interactions;
using Sombra.Wpf.Tests.Helpers;
using Sombra.Wpf.ViewModels;

namespace Sombra.Wpf.Tests
{
    public class ViewPanelViewModelTests
    {
        private readonly Mock<ILogger<ViewEditPanelViewModel>> _mockLogger;

        private const string TEST_RESOURCE_URL = "https://github.com";

        private const string TEST_RESOURCE_LOGIN = "admin";

        public ViewPanelViewModelTests()
        {
            _mockLogger = new();
        }        

        [Fact]
        public void DeleteCommand_SendsDeleteCredentialsMessage()
        {
            // Arrange
            var credentials = new Credentials()
            {
                ResourceUrl = TEST_RESOURCE_URL,
                Login = TEST_RESOURCE_LOGIN
            };

            var messenger = new WeakReferenceMessenger();
            var viewModel = new ViewEditPanelViewModel(_mockLogger.Object, messenger, credentials, false);
            var recipient = new TestMessageRecipient<DeleteCredentialsMessage>(messenger);

            // Act
            viewModel.DeleteCommand.Execute(null);

            // Assert
            Assert.NotNull(recipient.LastMessage);
            Assert.Equal(1, recipient.MessageCount);
            Assert.Equal(TEST_RESOURCE_URL, recipient.LastMessage.Credentials.ResourceUrl);
            Assert.Equal(TEST_RESOURCE_LOGIN, recipient.LastMessage.Credentials.Login);
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

            var isEditing = true;

            var messenger = new WeakReferenceMessenger();
            var viewModel = new ViewEditPanelViewModel(_mockLogger.Object, messenger, credentials, isEditing);
            var recipient = new TestMessageRecipient<SaveCredentialsMessage>(messenger);

            // Act
            viewModel.SaveCommand.Execute(null);

            // Assert
            Assert.NotNull(recipient.LastMessage);
            Assert.Equal(1, recipient.MessageCount);
            Assert.Equal(TEST_RESOURCE_URL, recipient.LastMessage.Credentials.ResourceUrl);
            Assert.Equal(TEST_RESOURCE_LOGIN, recipient.LastMessage.Credentials.Login);
            Assert.NotEqual(isEditing, viewModel.IsEditing);
        }

        [Fact]
        public void EditCommand_SwitchesMode()
        {
            // Arrange

            var isEditing = false;
            var messenger = new WeakReferenceMessenger();
            var viewModel = new ViewEditPanelViewModel(_mockLogger.Object, messenger, new Credentials(), isEditing);

            // Act
            viewModel.EditCommand.Execute(null);

            // Assert
            Assert.NotEqual(isEditing, viewModel.IsEditing);
        }

        [Fact]
        public void CancelCommand_SwitchesMode()
        {
            // Arrange
            var isEditing = true;
            var messenger = new WeakReferenceMessenger();
            var viewModel = new ViewEditPanelViewModel(_mockLogger.Object, messenger, new Credentials(), isEditing);

            // Act
            viewModel.CancelCommand.Execute(null);

            // Assert
            Assert.NotEqual(isEditing, viewModel.IsEditing);
        }
    }
}
