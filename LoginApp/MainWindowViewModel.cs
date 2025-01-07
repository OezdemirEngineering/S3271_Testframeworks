using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginApp;

public class MainWindowViewModel : BindableBase
{

    private Visibility _loginPanel =  Visibility.Visible;
    private Visibility _dashBoardPanel = Visibility.Collapsed;
    public string UserName { get; set; }
    public string Password { get; set; }

    public Visibility LoginPanel 
    { 
        get => _loginPanel; 
        set => SetProperty(ref _loginPanel, value);
    } 
    public Visibility DashBoardPanel
    {
        get => _dashBoardPanel;
        set => SetProperty(ref _dashBoardPanel, value);
    }

    public DelegateCommand LoginCommand { get; set; }

    public DelegateCommand LogoutCommand { get; set; }

    public MainWindowViewModel()
    {
        LoginCommand = new DelegateCommand(Login);
        LogoutCommand = new DelegateCommand(Logout);

        UserName = "admin";
        Password = "admin";
    }

    private void Logout()
    {
        LoginPanel = Visibility.Visible;
        DashBoardPanel = Visibility.Collapsed;
    }

    private void Login()
    {
        if (UserName == "admin" && Password == "admin")
        {
            LoginPanel = Visibility.Collapsed;
            DashBoardPanel = Visibility.Visible;
        }
        else
        {
            MessageBox.Show("Invalid Username or Password");
        }
    }
}
