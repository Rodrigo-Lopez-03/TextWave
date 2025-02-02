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
using Microsoft.AspNetCore.SignalR.Client;

namespace TextWave; 
/// <summary>
/// Lógica de interacción para Chat.xaml
/// </summary>
public partial class Chat : Page {
    private static int? id;
    private static int? userID;
    Login login = new Login();
    MainWindow mainWindow = new MainWindow();


    public Chat() {
        InitializeComponent();
        id = login.GetID();
    }

    private async void SendMessage(object sender, RoutedEventArgs e) {
        if (string.IsNullOrWhiteSpace(text_entry.Text))
            return;
        try {
            await mainWindow._connection.InvokeAsync("SendMessage", "YourUsername", text_entry.Text);
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
        catch (Exception ex){
            message_list.Items.Add($"Error: {ex.Message}");
        }
    }
}
