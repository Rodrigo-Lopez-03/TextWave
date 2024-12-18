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
public partial class Chat : Page {
    private static int? id;
    Login login = new Login();
    public Chat() {
        InitializeComponent();
        id = login.GetID();
    }

    private void SendMessage(object sender, RoutedEventArgs e) {
        if (string.IsNullOrWhiteSpace(text_entry.Text))
            return;
        SolidColorBrush bubbleColor = new SolidColorBrush(Colors.SkyBlue);
        string message = text_entry.Text;
        text_entry.Clear();

        TextBlock textMessage = new TextBlock {
            Name = "chat_bubble",
            Text = message,
            Background = bubbleColor,
            Width = 200,
            HorizontalAlignment = HorizontalAlignment.Left,
            TextWrapping = TextWrapping.Wrap,
            Padding = new Thickness(5)
        };

        Canvas.SetRight(textMessage, 10);
        Canvas.SetBottom(textMessage, 35 + textMessage.Height * chat_box.Children.Count);

        chat_box.Children.Add(textMessage);

        Console.WriteLine("Mensaje enviado");
    }
}
