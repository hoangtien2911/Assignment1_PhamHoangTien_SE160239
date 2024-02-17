using EmployeeManagementBO.Models;
using EmployeeManagementService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assignment1_PhamHoangTien_SE160239;

/// <summary>
/// Interaction logic for UserMenu.xaml
/// </summary>
public partial class UserMenu : Window
{
    private IAccountService _accountService;    
    private IEmployeeService _employeeService;
    private IJobHistoryService _jobHistoryService;
    private IAddressService _addressService;
    private ChangeInformationDialog _changeInformationDialog;
    private Account _currentAccount;
    private Login _login;
    public ManagerMenu _managerMenu;
    public AdminMenu _adminMenu;

    public UserMenu(IAccountService accountService, IEmployeeService employeeService, IJobHistoryService jobHistoryService, IAddressService addressService)
    {
        InitializeComponent();
        _accountService = accountService;                     
        _employeeService = employeeService;
        _jobHistoryService = jobHistoryService;
        _addressService = addressService;
    }

    public void SetAccount(Account account)
    {
        _currentAccount = account;
        EmployeeFullName.Text = account.FullName;
        profileGrid.ItemsSource = new List<Account> { _currentAccount};
        MyProfileButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#447B58"));
    }

    public void SetManagerMenu(ManagerMenu managerMenu)
    {
        _managerMenu = managerMenu;
    }

    public void SetAdminMenu(AdminMenu adminMenu)
    {
        _adminMenu = adminMenu;
    }

    private void MyJobButton_Click(object sender, RoutedEventArgs e)
    {
        var employee = _employeeService.GetEmployeeByUserNameIncludeJobAndDepartment(_currentAccount.Username);
        if (employee == null)
        {
            MessageBox.Show("No job available", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        } 
        else
        {
            SetButtonBackground(MyJobButton);
            // Show the grid data of jobGrid 
            jobGrid.Visibility = Visibility.Visible;
            jobGrid.ItemsSource = new List<Employee> { employee };
            // Hide other grids
            ToggleVisibility(false, profileGrid, jobHistoryGrid);
        }
        
    }

    private void MyProfileButton_Click(object sender, RoutedEventArgs e)
    {
        SetButtonBackground(MyProfileButton);
        // Show the grid data of profileGrid 
        profileGrid.Visibility = Visibility.Visible;
        profileGrid.ItemsSource = new List<Account> { _currentAccount };
        // Hide other grids
        ToggleVisibility(false, jobGrid, jobHistoryGrid);
    }

    private void JobHistoryButton_Click(object sender, RoutedEventArgs e)
    {
        var employee = _employeeService.GetEmployeeByUserName(_currentAccount.Username);
        if (employee == null)
        {
            MessageBox.Show("No job history available", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        } 
        else
        {
            SetButtonBackground(JobHistoryButton);
            // Show the grid data of profileGrid 
            jobHistoryGrid.Visibility = Visibility.Visible;
            jobHistoryGrid.ItemsSource = _jobHistoryService.GetAllJobHistoryIncludeJobAndDepartmentByEmployeeId(employee.EmployeeId);
            // Hide other grids
            ToggleVisibility(false, jobGrid, profileGrid);
        }
    }

    private void ChangeProfileButton_Click(object sender, RoutedEventArgs e)
    {
        _changeInformationDialog = new ChangeInformationDialog(_accountService, _addressService, _currentAccount, this, null, null);
        _changeInformationDialog.ShowDialog();
    }


    private void Button_Close_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }


    private bool IsMaximize = false;
    private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ClickCount == 2)
        {
            if (IsMaximize)
            {
                this.WindowState = WindowState.Normal;
                this.Width = 1080;
                this.Height = 720;

                IsMaximize = false;
            }
            else
            {
                this.WindowState = WindowState.Maximized;

                IsMaximize = true;
            }
        }
    }

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
        {
            this.DragMove();
        }
    }

    private void SetButtonBackground(Button clickedButton)
    {
        // Reset background colors of all buttons
        MyJobButton.Background = Brushes.Transparent;
        MyProfileButton.Background = Brushes.Transparent;
        JobHistoryButton.Background = Brushes.Transparent;

        // Set the background color of the clicked button
        clickedButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#447B58"));
    }

    private void ToggleVisibility(bool isVisible, params UIElement[] elements)
    {
        foreach (var element in elements)
        {
            element.Visibility = isVisible ? Visibility.Visible : Visibility.Collapsed;
        }
    }

    private void LogoutButton_Click(object sender, RoutedEventArgs e)
    {
        _login = new Login(this, _managerMenu, _adminMenu, _accountService);
        this.Hide();
        _login.Show();
    }
}
