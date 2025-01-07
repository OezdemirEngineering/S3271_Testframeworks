using System.Diagnostics;
using System.Windows.Automation;
namespace LoginApp.Integration;

public class LoginWithAutomationElementTest
{
    [Fact]
    public void Login_PasswordUserName_Dashboard()
    {
        string appPath = @"LoginApp.exe";
        var process = Process.Start(appPath);
        Thread.Sleep(2000);

        try
        {
            var mainWindow = AutomationElement.RootElement.FindFirst(TreeScope.Children,
                new PropertyCondition(AutomationElement.NameProperty, "MainWindow"));

            var usernameBox = mainWindow.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "UserName"));

            var passwordBox = mainWindow.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "Password"));

            var loginButton = mainWindow.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "LoginButton"));

            if (usernameBox.TryGetCurrentPattern(ValuePattern.Pattern, out var usernamePattern))
            {
                ((ValuePattern)usernamePattern).SetValue("admin");
            }

            if (passwordBox.TryGetCurrentPattern(ValuePattern.Pattern, out var passwordPattern))
            {
                ((ValuePattern)passwordPattern).SetValue("admin");
            }

            if (loginButton.TryGetCurrentPattern(InvokePattern.Pattern, out var loginPattern))
            {
                ((InvokePattern)loginPattern).Invoke();
            }

            Thread.Sleep(1000); // Warten, bis die Aktion abgeschlossen ist

            var dashboardPanel = mainWindow.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "DashBoardTitle"));

            Assert.NotNull(dashboardPanel);
        }
        finally
        {
            if (!process.HasExited)
            {
                process.Kill();
            }
        }
    }
}
