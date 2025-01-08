using CRM.Common.Contracts;
using CRM.Common.Dtos;
using CRM.ViewModels;
using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Xunit;

namespace CRM.Tests.ViewModels
{
    public class MainWindowViewModelTests
    {
        private readonly IDbService _dbServiceMock;
        private readonly MainWindowViewModel _viewModel;

        public MainWindowViewModelTests()
        {
            _dbServiceMock = Substitute.For<IDbService>();
            _dbServiceMock.GetUsers().Returns(new List<UserDto>());
            _viewModel = new MainWindowViewModel(_dbServiceMock);
        }

        [Fact]
        public void Login_ShouldShowDashboard_WhenCredentialsAreCorrect()
        {
            // Arrange
            _viewModel.UserName = "admin";
            _viewModel.Password = "admin";

            // Act
            _viewModel.LoginCommand.Execute();

            // Assert
            _viewModel.LoginPanel.Should().Be(Visibility.Collapsed);
            _viewModel.DashBoardPanel.Should().Be(Visibility.Visible);
            _viewModel.NotificationMessage.Should().Be("Login successful!");
        }

        [Fact]
        public void Login_ShouldShowErrorMessage_WhenCredentialsAreIncorrect()
        {
            // Arrange
            _viewModel.UserName = "user";
            _viewModel.Password = "wrongpassword";

            // Act
            _viewModel.LoginCommand.Execute();

            // Assert
            _viewModel.NotificationMessage.Should().Be("Invalid Username or Password");
        }

        [Fact]
        public void Logout_ShouldShowLoginPanel()
        {
            // Arrange
            _viewModel.LoginPanel = Visibility.Collapsed;
            _viewModel.DashBoardPanel = Visibility.Visible;

            // Act
            _viewModel.LogoutCommand.Execute();

            // Assert
            _viewModel.LoginPanel.Should().Be(Visibility.Visible);
            _viewModel.DashBoardPanel.Should().Be(Visibility.Collapsed);
            _viewModel.NotificationMessage.Should().Be("Logged out successfully!");
        }

        [Fact]
        public void AddUser_ShouldAddNewUser()
        {
            // Arrange
            _viewModel.Users = new ObservableCollection<UserDto>();
            _dbServiceMock.When(service => service.AddUser(Arg.Any<UserDto>())).Do(callInfo =>
            {
                var user = callInfo.Arg<UserDto>();
                _viewModel.ResponseAddedUser(user);
            });

            // Act
            _viewModel.AddCommand.Execute();

            // Assert
            _viewModel.SelectedUser.Should().NotBeNull();
            _viewModel.NotificationMessage.Should().Be("New user added successfully!");
        }

        [Fact]
        public void DeleteUser_ShouldRemoveSelectedUser()
        {
            // Arrange
            var user = new UserDto { Id = 1, FirstName = "John", FamilyName = "Doe", Email = "john.doe@example.com" };
            _viewModel.Users = new ObservableCollection<UserDto> { user };
            _viewModel.SelectedUser = user;
            _dbServiceMock.When(service => service.DeleteUser(Arg.Any<int>())).Do(callInfo =>
            {
                var removed = callInfo.Arg<int>();
                _viewModel.ResponseDeletedUser(user);
            });

            // Act
            _viewModel.DeleteCommand.Execute();

            // Assert
            _viewModel.SelectedUser.Should().BeNull();
            _viewModel.NotificationMessage.Should().Be("User John deleted successfully!");
        }

        [Fact]
        public void SaveUser_FirstName_ShouldUpdateSelectedUser()
        {
            // Arrange
            var user = new UserDto { Id = 1, FirstName = "John", FamilyName = "Doe", Email = "john.doe@example.com" };
            _viewModel.Users = new ObservableCollection<UserDto> { user };
            _viewModel.SelectedUser = user;
            _viewModel.SelectedUser.FirstName = "Johnny";
            _dbServiceMock.When(service => service.UpdateUser(Arg.Any<UserDto>())).Do(callInfo =>
            {
                var updatedUser = callInfo.Arg<UserDto>();
                _viewModel.ResponseUpdatedUser(updatedUser);
            });

            // Act
            _viewModel.SaveCommand.Execute();

            // Assert
            _viewModel.NotificationMessage.Should().Be("User Johnny updated successfully!");
            _viewModel.SelectedUser.FirstName.Should().Be("Johnny");
        }
        [Fact]
        public void DeleteUser_ShouldNotRemoveUser_WhenUserIsNotSelected()
        {
            // Arrange
            var user = new UserDto { Id = 1, FirstName = "John", FamilyName = "Doe", Email = "john.doe@example.com" };
            _viewModel.Users = new ObservableCollection<UserDto> { user };
            _viewModel.SelectedUser = null; // No user is selected
            _dbServiceMock.When(service => service.DeleteUser(Arg.Any<int>())).Do(callInfo =>
            {
                var removed = callInfo.Arg<int>();
                _viewModel.ResponseDeletedUser(user);
            });

            // Act
            _viewModel.DeleteCommand.Execute();

            // Assert
            _viewModel.Users.Should().Contain(user);
            _viewModel.NotificationMessage.Should().Be("No user selected for deletion.");
        }


    }
}
