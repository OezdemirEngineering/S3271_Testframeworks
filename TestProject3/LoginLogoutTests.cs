using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginApp.Tests;

public class LoginLogoutTests
{
    private readonly MainWindowViewModel _mainWindowViewModel;


    public LoginLogoutTests()
    {
        _mainWindowViewModel = new MainWindowViewModel();
    }

    [Fact]
    public void LoginCommand_CorrectUserNamePassword_DashboardVisible()
    {
        //Arrange 
        _mainWindowViewModel.UserName = "admin";
        _mainWindowViewModel.Password = "admin";

        //Act
        _mainWindowViewModel.LoginCommand.Execute();


        // Assert
        _mainWindowViewModel.LoginPanel.Should().Be(Visibility.Collapsed);
        _mainWindowViewModel.DashBoardPanel.Should().Be(Visibility.Visible);
    }

    [Fact]
    public void LogoutCommand_Logout_DashboardInvisible()
    {
        //Arrange 
        _mainWindowViewModel.LoginPanel = Visibility.Collapsed;
        _mainWindowViewModel.DashBoardPanel = Visibility.Visible;

        //Act
        _mainWindowViewModel.LogoutCommand.Execute();

        // Assert
        _mainWindowViewModel.LoginPanel.Should().Be(Visibility.Visible);
        _mainWindowViewModel.DashBoardPanel.Should().Be(Visibility.Collapsed);
    }

}
