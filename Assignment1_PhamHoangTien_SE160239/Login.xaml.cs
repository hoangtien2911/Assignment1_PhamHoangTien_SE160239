using EmployeeManagementBO.Models;
using EmployeeManagementService;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Assignment1_PhamHoangTien_SE160239
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private IAccountService _accountService;
        private UserMenu _userMenu;
        private ManagerMenu _managerMenu;
        private AdminMenu _adminMenu;
        public Login(UserMenu userMenu, ManagerMenu managerMenu, AdminMenu adminMenu, IAccountService accountService)
        {
            InitializeComponent();
            _accountService = accountService;                       
            _userMenu = userMenu;
            _managerMenu = managerMenu;
            _adminMenu = adminMenu;            
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(passwordBox.Password) && passwordBox.Password.Length > 0)
                txtPassword.Visibility = Visibility.Collapsed;
            else
                txtPassword.Visibility = Visibility.Visible;
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            passwordBox.Focus();
        }

        private void txtUsername_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text) && txtUsername.Text.Length > 0)
                textUsername.Visibility = Visibility.Collapsed;
            else
                textUsername.Visibility = Visibility.Visible;
        }

        private void textUsername_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtUsername.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUsername.Text;
            var password = passwordBox.Password;            
            var account = _accountService.FindAccountByUsernameAndPassword(username, password);
            if (account == null)
            {
                MessageBox.Show("Invalid username or password!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            } else
            {
                string role = account.Role;
                switch (role)
                {
                    case "User":
                        this.Close();
                        _userMenu.SetManagerMenu(_managerMenu);
                        _userMenu.SetAdminMenu(_adminMenu);
                        _userMenu.SetAccount(account);
                        _userMenu.Show();
                        break;
                    case "Manager":
                        this.Close();
                        _managerMenu.SetUserMenu(_userMenu);
                        _managerMenu.SetAdminMenu(_adminMenu);
                        _managerMenu.SetDataInit(account);
                        _managerMenu.Show();
                        break;
                    case "Admin":
                        this.Close();
                        _adminMenu.SetUserMenu(_userMenu);
                        _adminMenu.SetManagerMenu(_managerMenu);
                        _adminMenu.Show();
                        break;
                }
            }
        }
    }
}
