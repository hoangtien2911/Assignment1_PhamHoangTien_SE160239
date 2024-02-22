using EmployeeManagementBO.Models;
using EmployeeManagementService;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace EmployeeManagementWPF;

/// <summary>
/// Interaction logic for UpdateEmployeeDialog.xaml
/// </summary>
public partial class UpdateEmployeeDialog : Window
{
    private readonly IJobService _jobService;
    private readonly IDepartmentService _departmentService;
    private readonly IJobHistoryService _jobHistoryService;
    private readonly IEmployeeService _employeeService;
    private readonly IAddressService _addressService;
    private readonly IAccountService _accountService;
    private ManagerMenu _managerMenu;
    public Employee CurrentEmployee { get; set; }
    public ObservableCollection<Department> Departments { get; set; }
    public ObservableCollection<Job> Jobs { get; set; }
    public int SelectedDepartment { get; set; }
    public int SelectedJob { get; set; }

    public UpdateEmployeeDialog(Employee employee, IJobService jobService, IDepartmentService departmentService, IJobHistoryService jobHistoryService, IEmployeeService employeeService, IAddressService addressService, IAccountService accountService, ManagerMenu managerMenu)
    {
        InitializeComponent();
        DataContext = this;
        CurrentEmployee = employee;
        _jobService = jobService;
        _departmentService = departmentService;
        _jobHistoryService = jobHistoryService;
        _employeeService = employeeService;
        _addressService = addressService;
        _accountService = accountService;
        _managerMenu = managerMenu;
        Departments = new ObservableCollection<Department>(_departmentService.GetAll());
        Jobs = new ObservableCollection<Job>(_jobService.GetAll());
        SelectedDepartment = Departments.IndexOf(Departments.First(department => department.DepartmentId == CurrentEmployee.Department.DepartmentId));
        SelectedJob = Jobs.IndexOf(Jobs.First(job => job.JobId == CurrentEmployee.Job.JobId));        
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

    private void UpdateInformationButton_Click(object sender, RoutedEventArgs e)
    {
        Employee? employee = ValidateInformation(CurrentEmployee);        
        if (employee != null)
        {
            if (employee.Account != null)
            {                
                if (employee.Account.Address != null && employee.Account.AddressId != null)
                {
                    _addressService.Update(employee.Account.Address);
                } else if (employee.Account.Address != null && employee.Account.AddressId == null)
                {
                    employee.Account.AddressId = _addressService.Create(employee.Account.Address)?.AddressId;
                }
                _accountService.Update(employee.Account);
            }            
            Job? job = cbJob.SelectedItem as Job;
            Department? department = cbDepartment.SelectedItem as Department;
            if (department != null && job != null)
            {
                if (!CurrentEmployee.Job.JobId.Equals(job.JobId) || !CurrentEmployee.Department.DepartmentId.Equals(department.DepartmentId))
                {
                    //Update end date of old job
                    JobHistory lastJobHistory = CurrentEmployee.JobHistories.OrderByDescending(jh => jh.JobHistoryId)
                                    .First();
                    lastJobHistory.EndedDate = DateTime.Now;
                    _jobHistoryService.Update(lastJobHistory);

                    //Add new job history
                    JobHistory newJobHistory = new JobHistory();
                    newJobHistory.StartedDate = DateTime.Now;
                    newJobHistory.JobId = job.JobId;
                    newJobHistory.DepartmentId = department.DepartmentId;
                    newJobHistory.EmployeeId = employee.EmployeeId;                    
                    //Update employee data
                    _jobHistoryService.Create(newJobHistory);                    
                    var employeeUpdate = _employeeService.GetEmployeeByUserName(employee.Username);
                    employeeUpdate.JobId = job.JobId;                    
                    employeeUpdate.DepartmentId = department.DepartmentId;
                    _employeeService.Update(employeeUpdate);       
                }
            }
            
            _managerMenu.employeesDataGrid.ItemsSource = _employeeService.GetAllIncludeAccountAddressDepartmentJobAndHistory();
            this.Close();
        }
    }

    private Employee? ValidateInformation(Employee employee)
    {
        //Validate fullname
        var fullName = txtFullName.Text.Trim();
        if (string.IsNullOrEmpty(fullName))
        {
            MessageBox.Show("Please input fullname!", "Error Input", MessageBoxButton.OK);
            return null;
        }
        employee.Account.FullName = fullName;

        //Validate phone
        var phone = txtPhoneNumber.Text;
        if (!Regex.IsMatch(phone, @"^[0-9\s\+]+$"))
        {
            MessageBox.Show("Please enter valid phone number!", "Error Input", MessageBoxButton.OK);
            return null;
        }
        employee.Account.PhoneNumber = phone;

        if (txtStreet.Text.Trim().Length > 0 || txtWard.Text.Trim().Length > 0 || txtCity.Text.Trim().Length > 0 || txtProvince.Text.Trim().Length > 0)
        {
            if (employee.Account.Address == null)
            {
                var address = new Address();
                address.Street = txtStreet.Text.Trim();
                address.Ward = txtWard.Text.Trim();
                address.City = txtCity.Text.Trim();
                address.Province = txtProvince.Text.Trim();
                employee.Account.Address = address;
            }
            else
            {
                employee.Account.Address.Street = txtStreet.Text.Trim();
                employee.Account.Address.Ward = txtWard.Text.Trim();
                employee.Account.Address.City = txtCity.Text.Trim();
                employee.Account.Address.Province = txtProvince.Text.Trim();
            }
        }
        return employee;
    }

    private void BackToManagerMenuButton_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}
