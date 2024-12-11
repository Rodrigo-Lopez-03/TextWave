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
/// Lógica de interacción para Login.xaml
/// </summary>
public partial class Login : Window {
    public Login() {
        InitializeComponent();
    }

    private void IniciarSesion_Click(object sender, RoutedEventArgs e) {
        string getID = id.Text;
        string getPass = password.Text;

        if (getID == "100000000" && getPass == "12345678") {
            //NavigationService.Navigate(new Uri("MainWindow.xaml", UriKind.Relative));
        }




    }

    public static void LogIn() {
        
    }
}
