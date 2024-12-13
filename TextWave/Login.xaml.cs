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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TextWave; 
/// <summary>
/// Lógica de interacción para Chat.xaml
/// </summary>
public partial class Login : Page {
    public Login() {
        InitializeComponent();
        //main_frame.Navigate(new Uri("Login.xaml", UriKind.Relative));
    }

    private void LogIn_Click(object sender, RoutedEventArgs e) {
        string getID = id.Text;
        string getPass = password.Text;


        if (getID == "1" && getPass == "1") {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
                mainWindow.main_frame.Navigate(new Uri("Chat.xaml", UriKind.Relative));
        }
    }

    private void SignUp_Click(object sender, RoutedEventArgs e) { }
}
