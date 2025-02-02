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
/// Lógica de interacción para Login.xaml
/// </summary>
public partial class MainWindow : Window {
    private Chat chatWindow;
    public HubConnection _connection;


    public MainWindow() {
        InitializeComponent();
        InitializeSignalR();
    }

    private async void InitializeSignalR() {
        _connection = new HubConnectionBuilder().WithUrl("").Build();

        _connection.On<string, string>("Receive Message", (user, message) => {
            Dispatcher.Invoke(() => {
                var newMessage = $"{user}: {message}";
                chatWindow.message_list.Items.Add(newMessage);
            });
        });

        try {
            await _connection.StartAsync();
            chatWindow.message_list.Items.Add("Connection Started.");
        }catch(Exception ex) {
            chatWindow.message_list.Items.Add($"Error  {ex.Message}");
        }
    }


}
