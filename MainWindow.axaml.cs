using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AvaloniaApplication1;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        string login = TextBox.Text;
        string password = TextBox1.Text;


        if (login == "admin" && password == "admin")
        {
            AdminWorm admin = new AdminWorm();
            admin.Show();
            this.Hide();
        }
       
        else if (login == "client" && password == "client")
        {
            ClientWorm client = new ClientWorm();
            client.Show();
            this.Hide();
        }
    }
}