using EmployeeManagementBO.Models;
using EmployeeManagementService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeManagementWPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly ServiceProvider _serviceProvider;
    public App()
    {
        ServiceCollection services = new ServiceCollection();
        ConfigureServices(services);
        _serviceProvider = services.BuildServiceProvider();
    }

    private void ConfigureServices(ServiceCollection services)
    {
        //services.AddSingleton<Login>();
        services.AddSingleton<UserMenu>();
        services.AddSingleton<ManagerMenu>();
        services.AddSingleton<AdminMenu>();
        services.AddSingleton<IAccountService, AccountService>();
        services.AddSingleton<IAddressService, AddressService>();
        services.AddSingleton<IDepartmentService, DepartmentService>();
        services.AddSingleton<IEmployeeService, EmployeeService>();
        services.AddSingleton<IJobService, JobService>();
        services.AddSingleton<IJobHistoryService, JobHistoryService>();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var login = new Login(_serviceProvider.GetService<UserMenu>(),
                          _serviceProvider.GetService<ManagerMenu>(),
                          _serviceProvider.GetService<AdminMenu>(),
                          _serviceProvider.GetService<IAccountService>());
        login.Show();
        base.OnStartup(e);
    }
}
