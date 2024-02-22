using EmployeeManagementBO.Models;
using EmployeeManagementService;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EmployeeManagementWPF;

/// <summary>
/// Interaction logic for AddAccountDialog.xaml
/// </summary>
public partial class AddAccountDialog : Window
{
    private readonly IAccountService _accountService;
    private AdminMenu _adminMenu;
    public AddAccountDialog(IAccountService accountService, AdminMenu adminMenu)
    {
        InitializeComponent();
        _accountService = accountService;
        _adminMenu = adminMenu;
    }

    private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
    {
        ComboBoxItem selectedOption = (ComboBoxItem)cbRole.SelectedItem;
        Account? account = ValidateInformation();
        if (selectedOption != null && account != null)
        {
            string? optionTag = selectedOption.Tag as string;            

            if (optionTag == "User")
            {
                account.Role = "User";
            }
            else if (optionTag == "Manager")
            {
                account.Role = "Manager";
            }
            //Check exist email
            if (_accountService.IsExistedEmail(account.Email))
            {
                MessageBox.Show("Email already exist. Please input another email!", "Info", MessageBoxButton.OK);
                return;
            }

            bool isCreated = _accountService.Create(account);
            if (isCreated)
            {
                _adminMenu.accountsDataGrid.ItemsSource = _accountService.GetAllIncludeAddressWithRoleNotAdmin();
                this.Close();
            } else
            {
                MessageBox.Show("Duplicate username. Please check again!", "Error", MessageBoxButton.OK);
                return;
            }
            
        }
    }

    /// <summary>
    /// Validates account information and returns a account object if valid
    /// </summary>    
    /// <returns>Validated Account object or null if validation fails.</returns>
    private Account? ValidateInformation()
    {
        Account account = new Account();
        //Validate username
        var username = txtUsername.Text.Trim();
        if (string.IsNullOrEmpty(username))
        {
            MessageBox.Show("Please input username!", "Error Input", MessageBoxButton.OK);
            return null;
        }
        account.Username = username;

        // Validate password
        var password = txtPassword.Text.Trim();
        Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*\W).{8,}$"); // At least one uppercase letter, one special character, and minimum 8 characters
        if (!regex.IsMatch(password))
        {
            MessageBox.Show("Please input password with min length 8 characters, containing at least one uppercase letter and one special character!", "Error Input", MessageBoxButton.OK);
            return null;
        }
        account.Password = password;

        //Validate email
        var email = txtEmail.Text.Trim();
        if (string.IsNullOrEmpty(email.Trim()))
        {
            MessageBox.Show("Please enter email!", "Error Input", MessageBoxButton.OK);
            return null;
        }
        else
        {
            if (!new EmailAddressAttribute().IsValid(email))
            {
                MessageBox.Show("Please enter valid email!", "Error Input", MessageBoxButton.OK);
                return null;
            }
        }
        account.Email = email;
        
        //Validate fullname
        var fullName = txtFullName.Text.Trim();
        if (string.IsNullOrEmpty(fullName))
        {
            MessageBox.Show("Please input fullname!", "Error Input", MessageBoxButton.OK);
            return null;
        }
        account.FullName = fullName;

        //Validate phone
        var phone = txtPhoneNumber.Text;
        if (!Regex.IsMatch(phone, @"^[0-9\s\+]+$"))
        {
            MessageBox.Show("Please enter valid phone number!", "Error Input", MessageBoxButton.OK);
            return null;
        }
        account.PhoneNumber = phone;
        
        return account;
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
