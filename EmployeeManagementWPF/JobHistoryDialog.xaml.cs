using System.Windows;
using System.Windows.Input;

namespace EmployeeManagementWPF;

/// <summary>
/// Interaction logic for JobHistoryDialog.xaml
/// </summary>
public partial class JobHistoryDialog : Window
{
    public JobHistoryDialog()
    {
        InitializeComponent();
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
