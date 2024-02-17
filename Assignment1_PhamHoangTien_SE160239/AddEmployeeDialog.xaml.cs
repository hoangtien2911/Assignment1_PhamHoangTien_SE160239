using EmployeeManagementBO.Models;
using EmployeeManagementService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Assignment1_PhamHoangTien_SE160239;

/// <summary>
/// Interaction logic for AddEmployeeDialog.xaml
/// </summary>
public partial class AddEmployeeDialog : Window
{
    private IAccountService _accountService;   
    private IJobService _jobService;
    private IJobHistoryService _jobHistoryService;
    private IDepartmentService _departmentService;
    private IEmployeeService _employeeService;
    private ManagerMenu _managerMenu;
    public AddEmployeeDialog(IAccountService accountService, IDepartmentService departmentService, IJobService jobService, IJobHistoryService jobHistoryService, IEmployeeService employeeService, ManagerMenu managerMenu)
    {
        InitializeComponent();
        _accountService = accountService;
        _jobService = jobService;
        _jobHistoryService = jobHistoryService;
        _departmentService = departmentService;
        cbEmail.ItemsSource = new ObservableCollection<Account>(_accountService.FindAccountsWithNullEmployee());
        cbDepartment.ItemsSource = new ObservableCollection<Department>(_departmentService.GetAll());
        cbJob.ItemsSource = new ObservableCollection<Job>(_jobService.GetAll());
        _employeeService = employeeService;
        _managerMenu = managerMenu;
    }

    private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
    {
        // Get the selected item from the ComboBox
        Account? account = cbEmail.SelectedItem as Account;
        Department? department = cbDepartment.SelectedItem as Department;
        Job? job = cbJob.SelectedItem as Job;
        var date = dpHiredDate.Text.Trim();
        if (string.IsNullOrEmpty(date))
        {
            MessageBox.Show("Please input hired date!", "Error Input", MessageBoxButton.OK);
            return;
        }
        DateTime.TryParse(dpHiredDate.Text.Trim(), out var hiredDate);        
        Employee employee = new Employee
        {
            HiredDate = hiredDate,
            Username = account.Username,
            DepartmentId = department.DepartmentId,
            JobId = job.JobId
        };
        _employeeService.Create(employee);               
        JobHistory jobHistory = new JobHistory();        
        jobHistory.JobId = job.JobId;
        jobHistory.DepartmentId = department.DepartmentId;
        jobHistory.StartedDate = hiredDate;
        jobHistory.EmployeeId = employee.EmployeeId;
        _jobHistoryService.Create(jobHistory);
        _managerMenu.employeesDataGrid.ItemsSource = _employeeService.GetAllIncludeAccountAddressDepartmentJobAndHistory();
        this.Close();
    }
    private void BackToManagerMenuButton_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
    private void dpHiredDate_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        e.Handled = true; // Prevents text input
    }

    private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
            this.DragMove();
    }

    private void Image_MouseUp(object sender, MouseButtonEventArgs e)
    {
        this.Close();
    }
}
