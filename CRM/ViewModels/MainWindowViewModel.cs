using CRM.Backend;
using CRM.Common.Contracts;
using CRM.Common.Dtos;
using System.Collections.ObjectModel;
using System.Windows;

namespace CRM.ViewModels;

public class MainWindowViewModel : BindableBase
{
    private Visibility _loginPanel = Visibility.Visible;
    private Visibility _dashBoardPanel = Visibility.Collapsed;
    private UserDto _selectedUser;
    private string _notificationMessage;
    private IDbService _dbService;

    public string UserName { get; set; }
    public string Password { get; set; }

    public string NotificationMessage
    {
        get => _notificationMessage;
        set => SetProperty(ref _notificationMessage, value);
    }

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

    public ObservableCollection<UserDto> Users { get; set; }

    public UserDto SelectedUser
    {
        get => _selectedUser;
        set => SetProperty(ref _selectedUser, value);
    }

    public void ResponseAddedUser(UserDto user)
    {
        Users.Add(user);
        SelectedUser = user;
        NotificationMessage = "New user added successfully!";
    }

    public void ResponseDeletedUser(UserDto user)
    {
        Users.Remove(user);
        SelectedUser = null; // Clear selection
        NotificationMessage = $"User {user.FirstName} deleted successfully!";
    }

    public void ResponseUpdatedUser(UserDto user)
    {
        NotificationMessage = $"User {user.FirstName} updated successfully!";
        SelectedUser.FirstName = user.FirstName;
        SelectedUser.FamilyName = user.FamilyName;
        SelectedUser.Email = user.Email;
    }

    public DelegateCommand LoginCommand => new DelegateCommand(Login);
    public DelegateCommand LogoutCommand => new DelegateCommand(Logout);
    public DelegateCommand<UserDto> EditCommand { get; set; }
    public DelegateCommand AddCommand => new DelegateCommand(AddUser);
    public DelegateCommand DeleteCommand => new DelegateCommand(DeleteUser);
    public DelegateCommand SaveCommand => new DelegateCommand(SaveUser);

    public MainWindowViewModel(IDbService dbService)
    {
        _dbService = dbService;
        _dbService.UserAdded += ResponseAddedUser;
        _dbService.UserRemoved += ResponseDeletedUser;
        _dbService.UserUpdated += ResponseUpdatedUser;


        Users = new ObservableCollection<UserDto>(_dbService.GetUsers());
    }

    private void Login()
    {
        if (UserName == "admin" && Password == "admin")
        {
            LoginPanel = Visibility.Collapsed;
            DashBoardPanel = Visibility.Visible;
            NotificationMessage = "Login successful!";
        }
        else
        {
            NotificationMessage = "Invalid Username or Password";
        }
    }

    private void Logout()
    {
        LoginPanel = Visibility.Visible;
        DashBoardPanel = Visibility.Collapsed;
        NotificationMessage = "Logged out successfully!";
    }

    private void AddUser()
    {
        var newUser = new UserDto
        {
            Id = Users.Count > 0 ? Users[^1].Id + 1 : 1, // Auto-increment ID
            FirstName = "New",
            FamilyName = "User",
            Email = "new.user@example.com"
        };
        _dbService.AddUser(newUser);
    }

    private void DeleteUser()
    {
        if (SelectedUser != null)
        {     
            NotificationMessage = $"User {SelectedUser.FirstName} deleted successfully!";
            _dbService.UpdateUser(SelectedUser);
        }
        else
        {
            NotificationMessage = "Please select a user to delete.";
        }
    }

    private void SaveUser()
    {
        _dbService.UpdateUser(SelectedUser);
    }
}
