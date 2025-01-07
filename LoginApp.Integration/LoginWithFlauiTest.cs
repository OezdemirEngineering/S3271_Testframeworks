using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace LoginApp.Integration;

public class LoginWithFlauiTest : IDisposable
{
    public Window _mainWindow;

    public LoginWithFlauiTest()
    {
        var process = Process.Start("LoginApp.exe");
        var automation = new UIA3Automation();
        var app = FlaUI.Core.Application.Attach(process);
        _mainWindow = app.GetMainWindow(automation).WaitUntilEnabled(new TimeSpan(0, 0, 0, 0, 100));
    }


    [Fact]
    public void Login_UserNamePassword_Dashboard()
    {
        // Arrange 
        var userNameTextBox = _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("UserName")).AsTextBox();
        var passwordTextBox = _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("Password")).AsTextBox();
        var loginButton = _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("LoginButton")).AsButton();

        // Act
        userNameTextBox.Text = "admin";
        passwordTextBox.Text = "admin";
        loginButton.Click();


        // Assert
        var dashboard = _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("DashBoardTitle")).AsTextBox();
       
        dashboard.Should().NotBeNull();
    }

    public void Dispose()
    {
        _mainWindow.Close();
    }
}
