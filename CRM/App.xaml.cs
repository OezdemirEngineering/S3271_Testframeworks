using CRM.Backend;
using CRM.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace CRM;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{

    public App()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddTransient<MainWindowViewModel>();
        serviceCollection.AddDbServices();

        ServiceProviderHelper.Provider = serviceCollection.BuildServiceProvider();

    }
}
