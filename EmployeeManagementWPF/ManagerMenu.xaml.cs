using EmployeeManagementBO.Models;
using EmployeeManagementService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace EmployeeManagementWPF;

/// <summary>
/// Interaction logic for ManagerMenu.xaml
/// </summary>
public partial class ManagerMenu : Window
{
    private readonly IEmployeeService _employeeService;
    private readonly IAccountService _accountService;
    private readonly IAddressService _addressService;
    private readonly IJobService _jobService;
    private readonly IDepartmentService _departmentService;  
    private readonly IJobHistoryService _jobHistoryService;
    private Account _currentAccount;
    private ChangeInformationDialog _changeInformationDialog;
    private AddEmployeeDialog _addEmployeeDialog;
    private UpdateEmployeeDialog _updateEmployeeDialog;
    private JobHistoryDialog _jobHistoryDialog;
    private Login _login;
    private UserMenu _userMenu;
    private AdminMenu _adminMenu;

    public ManagerMenu(IEmployeeService employeeService, IAccountService accountService, IAddressService addressService, IJobService jobService, IDepartmentService departmentService, IJobHistoryService jobHistoryService)
    {
        InitializeComponent();
        _employeeService = employeeService;
        _accountService = accountService;
        _addressService = addressService;
        _jobService = jobService;
        _departmentService = departmentService;
        _jobHistoryService = jobHistoryService;        
    }

    public void SetUserMenu(UserMenu userMenu)
    {
        _userMenu = userMenu;
    }

    public void SetAdminMenu(AdminMenu adminMenu)
    {
        _adminMenu = adminMenu;
    }

    public void SetDataInit(Account account)
    {
        _currentAccount = account;
        employeesDataGrid.ItemsSource = _employeeService.GetAllIncludeAccountAddressDepartmentJobAndHistory();
        EmployeesButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#447B58"));
    }

    private void EmployeesButton_Click(object sender, RoutedEventArgs e)
    {
        SetButtonBackground(EmployeesButton);
        // Show the grid data of profileGrid 
        ToggleVisibility(true, employeesDataGrid, searchEmployeeGrid, addEmployeeButton);
        employeesDataGrid.ItemsSource = _employeeService.GetAllIncludeAccountAddressDepartmentJobAndHistory();
        // Hide other grids        
        ToggleVisibility(false, profileGrid, jobGrid, deparmentGrid);
    }

    private void UpdateInfoEmployeeButton_Click(object sender, RoutedEventArgs e)
    {        
        Button clickedButton = sender as Button;
        // Access the DataContext of the button to get the associated data item
        Employee employee = clickedButton.DataContext as Employee;
        _updateEmployeeDialog = new UpdateEmployeeDialog(employee, _jobService, _departmentService, _jobHistoryService, _employeeService, _addressService, _accountService, this);
        _updateEmployeeDialog.Show();
    }

    private void JobButton_Click(object sender, RoutedEventArgs e)
    {
        SetButtonBackground(JobButton);
        // Show the grid data of profileGrid 
        ToggleVisibility(true, jobGrid);
        jobGrid.ItemsSource = _jobService.GetAll();
        // Hide other grids        
        ToggleVisibility(false, employeesDataGrid, profileGrid, deparmentGrid, searchEmployeeGrid, addEmployeeButton);
    }

    private void DepartmentButton_Click(object sender, RoutedEventArgs e)
    {
        SetButtonBackground(DepartmentButton);
        // Show the grid data of profileGrid 
        ToggleVisibility(true, deparmentGrid);
        deparmentGrid.ItemsSource = _departmentService.GetAll();
        // Hide other grids        
        ToggleVisibility(false, employeesDataGrid, profileGrid, jobGrid, searchEmployeeGrid, addEmployeeButton);
    }

    private void MyProfileButton_Click(object sender, RoutedEventArgs e)
    {
        SetButtonBackground(MyProfileButton);
        // Show the grid data of profileGrid 
        profileGrid.Visibility = Visibility.Visible;
        profileGrid.ItemsSource = new List<Account> { _currentAccount };
        // Hide other grids
        ToggleVisibility(false, employeesDataGrid, jobGrid, deparmentGrid, searchEmployeeGrid, addEmployeeButton);
    }

    private void ToggleVisibility(bool isVisible, params UIElement[] elements)
    {
        foreach (var element in elements)
        {
            element.Visibility = isVisible ? Visibility.Visible : Visibility.Collapsed;
        }
    }

    private void ChangeProfileButton_Click(object sender, RoutedEventArgs e)
    {
        _changeInformationDialog = new ChangeInformationDialog(_accountService, _addressService, _currentAccount, null, this, null);
        _changeInformationDialog.ShowDialog();
    }

    private void ViewJobHistoryButton_Click(object sender, RoutedEventArgs e)
    {
        Button clickedButton = sender as Button;
        Employee employee = clickedButton.DataContext as Employee;

        if (employee != null)
        {            
            var jobHistories = _jobHistoryService.GetAllJobHistoryIncludeJobAndDepartmentByEmployeeId(employee.EmployeeId);
            _jobHistoryDialog = new JobHistoryDialog();
            _jobHistoryDialog.jobHistoryGrid.ItemsSource = jobHistories;
            _jobHistoryDialog.Show();
        }
    }    

    private void SetButtonBackground(Button clickedButton)
    {
        // Reset background colors of all buttons
        EmployeesButton.Background = Brushes.Transparent;
        MyProfileButton.Background = Brushes.Transparent;
        JobButton.Background = Brushes.Transparent;
        DepartmentButton.Background = Brushes.Transparent;

        // Set the background color of the clicked button
        clickedButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#447B58"));
    }

    private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
    {
        var accounts = _accountService.FindAccountsWithNullEmployee().ToList();
        if (accounts.Count == 0)
        {
            MessageBox.Show("No user found for add new employee!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        else
        {
            _addEmployeeDialog = new AddEmployeeDialog(_accountService, _departmentService, _jobService, _jobHistoryService, _employeeService, this);
            _addEmployeeDialog.ShowDialog();
        }
    }

    private void btnSearchEmployee_Click(object sender, RoutedEventArgs e)
    {
        ComboBoxItem selectedOption = (ComboBoxItem)cbSearch.SelectedItem;

        if (selectedOption != null)
        {
            string? optionTag = selectedOption.Tag as string;
            string searchValue = txtSearch.Text;

            if (optionTag == "Name")
            {
                employeesDataGrid.ItemsSource = _employeeService.GetAllByNameIncludeAccountDepartmentJob(searchValue);
            }
            else if (optionTag == "Email")
            {
                employeesDataGrid.ItemsSource = _employeeService.GetAllByEmailIncludeAccountDepartmentJob(searchValue);
            }
        }
    }

    private void LogoutButton_Click(object sender, RoutedEventArgs e)
    {
        _login = new Login(_userMenu, this, _adminMenu, _accountService);
        this.Hide();
        _login.Show();
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

    private void Button_Close_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
}
