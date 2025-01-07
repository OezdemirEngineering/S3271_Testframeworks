using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LoginApplication;

public class MainWindowViewModel : BindableBase
{

    public string Username { get; set; }
    public string Password { get; set; }

    public DelegateCommand LoginCommand => new(Login);


    public MainWindowViewModel()
    {
        Username = "admin";
        Password = "password";
    }
    public void Login()
    {

    }
}
