using EmployeeManagementBO.Models;
using EmployeeManagementService;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace EmployeeManagementWPF;

/// <summary>
/// Interaction logic for ChangeInformationDialog.xaml
/// </summary>
public partial class ChangeInformationDialog : Window
{
    private IAccountService _accountService;
    private IAddressService _addressService;
    private Account _currentAccount;
    private UserMenu _userMenu;
    private ManagerMenu _managerMenu;
    private AdminMenu _adminMenu;

    public Account CurrentAccount
    {
        get => _currentAccount;
        set => _currentAccount = value;
    }

    public ChangeInformationDialog(IAccountService accountService, IAddressService addressService, Account account, UserMenu userMenu, ManagerMenu managerMenu, AdminMenu adminMenu)
    {
        InitializeComponent();
        DataContext = this;
        _accountService = accountService;
        _addressService = addressService;
        _currentAccount = account; 
        _userMenu = userMenu;
        _managerMenu = managerMenu;
        _adminMenu = adminMenu;
    }

    private void UpdateInformationButton_Click(object sender, RoutedEventArgs e)
    {
        var account = ValidateInformation(CurrentAccount);
        if (account != null)
        {
            var address = account.Address;
            if (address != null && account.AddressId == null)
            {
                account.AddressId = _addressService.Create(address)?.AddressId;
            } 
            else if (address != null && account.AddressId != null) 
            {
                _addressService.Update(address);
            }
            _accountService.Update(account);
        }
        if (_userMenu != null)
        {
            _userMenu.profileGrid.ItemsSource = new List<Account> { _accountService.FindAccountByUsername(_currentAccount.Username) };
            this.Close();
        }
        if (_managerMenu != null)
        {
            _managerMenu.profileGrid.ItemsSource = new List<Account> { _accountService.FindAccountByUsername(_currentAccount.Username) };
            this.Close();
        }
        if (_adminMenu != null)
        {
            _adminMenu.accountsDataGrid.ItemsSource = _accountService.GetAllIncludeAddressWithRoleNotAdmin();
            this.Close();
        }
    }

    private void BackToUserMenuButton_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    /// <summary>
    /// Validates account information and returns a account object if valid
    /// </summary>
    /// <param name="account">An account information to update.</param>
    /// <returns>Validated Account object or null if validation fails.</returns>
    private Account? ValidateInformation(Account account)
    {        
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

        if (txtStreet.Text.Trim().Length > 0 || txtWard.Text.Trim().Length > 0 || txtCity.Text.Trim().Length > 0 || txtProvince.Text.Trim().Length > 0)
        {
            if (account.Address == null)
            {
                var address = new Address();
                address.Street = txtStreet.Text.Trim();
                address.Ward = txtWard.Text.Trim();
                address.City = txtCity.Text.Trim();
                address.Province = txtProvince.Text.Trim();
                account.Address = address;
            } else
            {
                account.Address.Street = txtStreet.Text.Trim();
                account.Address.Ward = txtWard.Text.Trim();
                account.Address.City = txtCity.Text.Trim();
                account.Address.Province = txtProvince.Text.Trim();
            }           
        }
        return account;
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
