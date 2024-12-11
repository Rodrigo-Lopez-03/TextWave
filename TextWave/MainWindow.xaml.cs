﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TextWeb;
using TextLib;


namespace TextWave; 
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    
    public MainWindow() {
        InitializeComponent();
        main_frame.Navigate(new Uri("Login.xaml", UriKind.Relative));
    }
}