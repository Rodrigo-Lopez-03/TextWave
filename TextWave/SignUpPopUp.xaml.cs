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
using System.Windows.Shapes;

namespace TextWave {
    /// <summary>
    /// Lógica de interacción para SignUpPopUp.xaml
    /// </summary>
    public partial class SignUpPopUp : Window {
        public SignUpPopUp() {
            InitializeComponent();
        }

        public void SignUp() {
            string getName = name_entry.Text;
            string getEmail = email_entry.Text;
            string getPassword = password_entry.Text;
            string? generateID = "";
            var rand = new Random();
            var textLib = new TextLib.Connection();

            if (getName != "" && getEmail != "" && getPassword != "") {
                generateID = textLib.CreateUser(getName, getEmail, getPassword);
                MessageBox.Show("Usuario creado exitosamente", $"Tu ID es: {generateID}");
            }
            else {
                MessageBox.Show("Datos incorrectos", 
                    "Faltan datos o algun campo es incorrecto, revisa los campos");
            }
        }
    }
}
