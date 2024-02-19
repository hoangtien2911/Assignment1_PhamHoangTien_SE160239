using EmployeeManagementBO.Models;
using EmployeeManagementService;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace EmployeeManagementWPF;

/// <summary>
/// Interaction logic for AdminMenu.xaml
/// </summary>
public partial class AdminMenu : Window
{
    private IAccountService _accountService;
    private IJobService _jobService;
    private IDepartmentService _departmentService;
    private IAddressService _addressService;
    private IJobHistoryService _jobHistoryService;
    private AddAccountDialog _addAccountDialog;
    private JobInfoDialog _jobInfoDialog;
    private DepartmentInfoDialog _departmentInfoDialog;
    private Login _login;
    private UserMenu _userMenu;
    private ManagerMenu _managerMenu;
    private ChangeInformationDialog _changeInformationDialog;
    private JobHistoryDialog _jobHistoryDialog;

    public AdminMenu(IAccountService accountService, IJobService jobService, IJobHistoryService jobHistoryService, IDepartmentService departmentService, IAddressService addressService)
    {
        _accountService = accountService;
        _jobService = jobService;
        _jobHistoryService = jobHistoryService;
        _departmentService = departmentService;
        InitializeComponent();
        AccountsButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#447B58"));
        accountsDataGrid.ItemsSource = _accountService.GetAllIncludeAddressWithRoleNotAdmin();
        _addressService = addressService;
    }

    public void SetUserMenu(UserMenu userMenu)
    {
        _userMenu = userMenu;
    }

    public void SetManagerMenu(ManagerMenu managerMenu)
    {
        _managerMenu = managerMenu;
    }

    private void AccountsButton_Click(object sender, RoutedEventArgs e)
    {
        SetButtonBackground(AccountsButton);
        // Show the grid data of profileGrid 
        ToggleVisibility(true, accountsDataGrid, searchAccountGrid, addAccountButton);
        accountsDataGrid.ItemsSource = _accountService.GetAllIncludeAddressWithRoleNotAdmin();
        // Hide other grids        
        ToggleVisibility(false, jobGrid, deparmentGrid, addJobButton, addDepartmentButton);
    }

    private void JobButton_Click(object sender, RoutedEventArgs e)
    {
        SetButtonBackground(JobButton);
        // Show the grid data of profileGrid 
        ToggleVisibility(true, jobGrid, addJobButton);
        jobGrid.ItemsSource = _jobService.GetAll();
        // Hide other grids        
        ToggleVisibility(false, accountsDataGrid, deparmentGrid, searchAccountGrid, addAccountButton, addDepartmentButton);
    }

    private void DepartmentButton_Click(object sender, RoutedEventArgs e)
    {
        SetButtonBackground(DepartmentButton);
        // Show the grid data of profileGrid 
        ToggleVisibility(true, deparmentGrid, addDepartmentButton);
        deparmentGrid.ItemsSource = _departmentService.GetAll();
        // Hide other grids        
        ToggleVisibility(false, accountsDataGrid, jobGrid, searchAccountGrid, addAccountButton, addJobButton);
    }

    private void SearchAccount_Click(object sender, RoutedEventArgs e)
    {
        ComboBoxItem selectedOption = (ComboBoxItem)cbSearch.SelectedItem;

        if (selectedOption != null)
        {
            string? optionTag = selectedOption.Tag as string;
            string searchValue = txtSearch.Text;

            if (optionTag == "Name")
            {
                accountsDataGrid.ItemsSource = _accountService.FindAccountIncludeAddressByFullname(searchValue);
            }
            else if (optionTag == "Email")
            {
                accountsDataGrid.ItemsSource = _accountService.FindAccountIncludeAddressByEmail(searchValue);
            }
        }
    }
    
    private void ChangeAccountInfoButton_Click(object sender, RoutedEventArgs e)
    {
        Button clickedButton = sender as Button;        
        Account account = clickedButton.DataContext as Account;
        _changeInformationDialog = new ChangeInformationDialog(_accountService, _addressService, account, null, null, this);
        _changeInformationDialog.ShowDialog();        
    }

    private void ViewJobHistoryButton_Click(object sender, RoutedEventArgs e)
    {
        Button clickedButton = sender as Button;
        Account account = clickedButton.DataContext as Account;
        
        if (account != null && account.Role.ToLower() == "user")
        {
            var employee = _accountService.FindAccountIncludeEmployeeByUsername(account.Username).Employee;            
            if (employee != null)
            {
                var jobHistories = _jobHistoryService.GetAllJobHistoryIncludeJobAndDepartmentByEmployeeId(employee.EmployeeId);
                _jobHistoryDialog = new JobHistoryDialog();
                _jobHistoryDialog.jobHistoryGrid.ItemsSource = jobHistories;
                _jobHistoryDialog.Show();
            } else
            {
                MessageBox.Show(account.Username + " is not yet an employee.");
            }
            
        }
        else
        {            
            MessageBox.Show("Manager role not have job history.");
        }
    }    

    private void DeleteAccountButton_Click(object sender, RoutedEventArgs e)
    {
        Button clickedButton = sender as Button;
        Account account = clickedButton.DataContext as Account;
        if (account != null)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this account?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                account.DeleteFlag = 1;
                _accountService.Update(account);
                accountsDataGrid.ItemsSource = _accountService.GetAllIncludeAddressWithRoleNotAdmin();
            }
        }
        accountsDataGrid.ItemsSource = _accountService.GetAllIncludeAddressWithRoleNotAdmin();
    }    

    private void AddAccountButton_Click(object sender, RoutedEventArgs e)
    {
        _addAccountDialog = new AddAccountDialog(_accountService, this);
        _addAccountDialog.ShowDialog();
    }

    private void AddJobButton_Click(object sender, RoutedEventArgs e)
    {
        _jobInfoDialog = new JobInfoDialog("Create", null, _jobService, this);
        _jobInfoDialog.ShowDialog();
    }

    private void AddDepartmentButton_Click(object sender, RoutedEventArgs e)
    {
        _departmentInfoDialog = new DepartmentInfoDialog("Create", null, _departmentService, this);
        _departmentInfoDialog.ShowDialog();
    }

    private void UpdateJobButton_Click(object sender, RoutedEventArgs e)
    {
        Button clickedButton = sender as Button;       
        Job job = clickedButton.DataContext as Job;
        _jobInfoDialog = new JobInfoDialog("Update", job, _jobService, this);
        _jobInfoDialog.ShowDialog();
    }

    private void UpdateDepartmentButton_Click(object sender, RoutedEventArgs e)
    {
        Button clickedButton = sender as Button;
        Department department = clickedButton.DataContext as Department;
        _departmentInfoDialog = new DepartmentInfoDialog("Update", department, _departmentService, this);
        _departmentInfoDialog.ShowDialog();
    }

    private void LogoutButton_Click(object sender, RoutedEventArgs e)
    {
        _login = new Login(_userMenu, _managerMenu, this, _accountService);
        this.Hide();
        _login.Show();
    }

    private void ToggleVisibility(bool isVisible, params UIElement[] elements)
    {
        foreach (var element in elements)
        {
            element.Visibility = isVisible ? Visibility.Visible : Visibility.Collapsed;
        }
    }

    private void SetButtonBackground(Button clickedButton)
    {
        // Reset background colors of all buttons
        AccountsButton.Background = Brushes.Transparent;
        DepartmentButton.Background = Brushes.Transparent;
        JobButton.Background = Brushes.Transparent;

        // Set the background color of the clicked button
        clickedButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#447B58"));
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
