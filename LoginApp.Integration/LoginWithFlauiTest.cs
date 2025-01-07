using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Integration;

public class LoginWithFlauiTest
{
    [Fact]
    public void Login_UserNamePassword_Dashboard()
    {
        // Arrange 
        var process = Process.Start("LoginApp.exe");
        var automation = new UIA3Automation();
        var app = FlaUI.Core.Application.Attach(process);
        var mainWindow = app.GetMainWindow(automation).WaitUntilEnabled(new TimeSpan(0, 0, 0, 0, 100));

        var userNameTextBox = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("UserName")).AsTextBox();
        userNameTextBox.Text = "admin";


    }
}
