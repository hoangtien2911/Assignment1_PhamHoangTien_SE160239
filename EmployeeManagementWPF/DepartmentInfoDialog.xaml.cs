using EmployeeManagementBO.Models;
using EmployeeManagementService;
using System.Windows;
using System.Windows.Input;

namespace EmployeeManagementWPF;

/// <summary>
/// Interaction logic for DepartmentInfoDialog.xaml
/// </summary>
public partial class DepartmentInfoDialog : Window
{

    private IDepartmentService _departmentService;
    private AdminMenu _adminMenu;
    private Department _currentDepartment;

    public Department? CurrentDepartment
    {
        get => _currentDepartment;
        set => _currentDepartment = value;
    }
    public DepartmentInfoDialog(string mode, Department department, IDepartmentService departmentService, AdminMenu adminMenu)
    {
        InitializeComponent();
        DataContext = this;
        _departmentService = departmentService;
        _adminMenu = adminMenu;
        btnMode.Content = mode;
        CurrentDepartment = department;
        if (mode == "Create")
        {
            btnMode.Click += btnCreate_Click;
        }
        if (mode == "Update")
        {
            btnMode.Click += btnUpdate_Click;
        }
    }

    private void btnCreate_Click(object sender, RoutedEventArgs e)
    {
        var department = ValidateInformation(CurrentDepartment);
        if (department != null)
        {
            _departmentService.Create(department);
            _adminMenu.deparmentGrid.ItemsSource = _departmentService.GetAll();
            this.Close();
        }
    }

    private void btnUpdate_Click(object sender, RoutedEventArgs e)
    {
        var department = ValidateInformation(CurrentDepartment);
        if (department != null)
        {
            _departmentService.Update(department);
            _adminMenu.deparmentGrid.ItemsSource = _departmentService.GetAll();
            this.Close();
        }
    }

    /// <summary>
    /// Validates department information and returns a deparment object if valid
    /// </summary>
    /// <param name="department">An department information to update.</param>
    /// <returns>Validated department object or null if validation fails.</returns>
    private Department? ValidateInformation(Department? department = null)
    {
        Department? newDepartment = department ?? new Department();
        //Validate department name
        var departmentName = txtDepartmentName.Text.Trim();
        if (string.IsNullOrEmpty(departmentName))
        {
            MessageBox.Show("Please input department name!", "Error Input", MessageBoxButton.OK);
            return null;
        }
        newDepartment.DepartmentName = departmentName;
        return newDepartment;
    }

    private void BackToAdminMenuButton_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
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
