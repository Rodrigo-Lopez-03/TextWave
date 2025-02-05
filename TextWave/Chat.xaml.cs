using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.AspNetCore.SignalR.Client;

namespace TextWave; 
/// <summary>
/// Lógica de interacción para Chat.xaml
/// </summary>
public partial class Chat : Page {
    MainWindow mainWindow = new MainWindow();
    Login login = new Login();

    private static int? id;
    private readonly static int? userID;

    public Chat() {
        InitializeComponent();
        id = login.GetID();
    }

    private void SendMessage(object sender, RoutedEventArgs e) {
        if (string.IsNullOrWhiteSpace(text_entry.Text))
            return;
        
        SolidColorBrush userBubbleColor = new SolidColorBrush(Colors.SkyBlue);
        SolidColorBrush senderBubbleColor = new SolidColorBrush(Colors.Wheat);
        string message = text_entry.Text;
        text_entry.Clear();

        TextBlock textMessage = new TextBlock {
            Name = "chat_bubble",
            Text = message,
            Background = userBubbleColor,
            Width = 200,
            HorizontalAlignment = HorizontalAlignment.Left,
            TextWrapping = TextWrapping.Wrap,
            Padding = new Thickness(5)
        };

        if (id == userID) {
            textMessage.Background = userBubbleColor;
            textMessage.HorizontalAlignment = HorizontalAlignment.Right;
        }
        else {
            textMessage.Background = senderBubbleColor;
            textMessage.HorizontalAlignment = HorizontalAlignment.Left;
        }



        Canvas.SetRight(textMessage, 10);
        Canvas.SetBottom(textMessage, 35 + textMessage.Height * chat_box.Children.Count);

        chat_box.Children.Add(textMessage);

        Console.WriteLine("Mensaje enviado");
        
    }
}
