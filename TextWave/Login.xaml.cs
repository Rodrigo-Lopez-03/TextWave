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
using TextLib;

namespace TextWave; 
/// <summary>
/// Lógica de interacción para Chat.xaml
/// </summary>
public partial class Login : Page {
    private static int? setID;
    static Connection textLib = new Connection();

    public Login() {
        InitializeComponent();
        //main_frame.Navigate(new Uri("Login.xaml", UriKind.Relative));
    }

    private void LogIn_Click(object sender, RoutedEventArgs e) {
        string getID = id.Text;
        string getPass = password.Password;

        bool canLog = true; //textLib.LogIn(getID, getPass);

        if (canLog) {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null) { 
                mainWindow.main_frame.Navigate(new Uri("Chat.xaml", UriKind.Relative));
                setID = Int32.Parse(id.Text);
            }
        }
        else {
            MessageBox.Show("Error al iniciar sesion", 
                "ID o contraseña incorrecta, revisa los campos.");
        }

    }

    private void SignUp_Click(object sender, RoutedEventArgs e) {
        Window popup = new SignUpPopUp();
        popup.Show();
    }

    public int? GetID() {
        if (setID != null)
            return setID;
        else return null;
    }
}
