using EmployeeManagementBO.Models;
using EmployeeManagementService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
/// Interaction logic for JobInfoDialog.xaml
/// </summary>
public partial class JobInfoDialog : Window
{
    private IJobService _jobService;
    private AdminMenu _adminMenu;
    private Job _currentJob;

    public Job? CurrentJob
    {
        get => _currentJob;
        set => _currentJob = value;
    }
    public JobInfoDialog(string mode, Job job, IJobService jobService, AdminMenu adminMenu)
    {
        InitializeComponent();
        DataContext = this;
        _jobService = jobService;
        _adminMenu = adminMenu;
        btnMode.Content = mode;
        CurrentJob = job;
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
        var job = ValidateInformation(CurrentJob);
        if (job != null)
        {
            _jobService.Create(job);
            _adminMenu.jobGrid.ItemsSource = _jobService.GetAll();
            this.Close();
        }
    }

    private void btnUpdate_Click(object sender, RoutedEventArgs e)
    {
        var job = ValidateInformation(CurrentJob);
        if (job != null)
        {
            _jobService.Update(job);
            _adminMenu.jobGrid.ItemsSource = _jobService.GetAll();
            this.Close();
        }
    }

    /// <summary>
    /// Validates job information and returns a job object if valid
    /// </summary>
    /// <param name="job">An job information to update.</param>
    /// <returns>Validated Job object or null if validation fails.</returns>
    private Job? ValidateInformation(Job? job = null)
    {
        Job? newJob = job ?? new Job();
        //Validate job title
        var jobTitle = txtJobTitle.Text.Trim();
        if (string.IsNullOrEmpty(jobTitle))
        {
            MessageBox.Show("Please input job title!", "Error Input", MessageBoxButton.OK);
            return null;
        }
        newJob.JobTitle = jobTitle;

        //Validate salary
        var salary = txtSalary.Text;
        if (string.IsNullOrEmpty(salary))
        {
            MessageBox.Show("Please input salary!", "Error Input", MessageBoxButton.OK);
            return null;
        }
        if (!int.TryParse(salary, out var parseSalary))
        {
            MessageBox.Show("Please input salary type number!", "Error Input", MessageBoxButton.OK);
            return null;
        }
        newJob.Salary = parseSalary;

        return newJob;
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
