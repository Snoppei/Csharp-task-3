﻿using Microsoft.Win32;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System;
using Prism.Modularity;
using System.Reflection.PortableExecutable;

namespace Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly MainWindowViewModel DataContext;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void OpenButton_click(object sender, RoutedEventArgs e)
        {
            animalPopup.IsOpen = true;
        }

        private void VisibleButtons()
        {
            runButton.Visibility = Visibility.Visible;
            stopButton.Visibility = Visibility.Visible;
            voiceButton.Visibility = Visibility.Visible;
            upTreeButton.Visibility = Visibility.Visible;
            downTreeButton.Visibility = Visibility.Visible;
        }

        private void DogButton(object sender, RoutedEventArgs e)
        {
            animalPopup.IsOpen = false;
            DataContext.CreateClass("lab2_6.Dog");
            info.Text = DataContext.Data;
            VisibleButtons();
        }

        private void PantherButton(object sender, RoutedEventArgs e)
        {
            animalPopup.IsOpen = false;

            DataContext.CreateClass("lab2_6.Panther");
            info.Text = DataContext.Data;
            VisibleButtons();
        }

        private void TurtleButton(object sender, RoutedEventArgs e)
        {
            animalPopup.IsOpen = false;

            DataContext.CreateClass("lab2_6.Turtle");
            info.Text = DataContext.Data;
            VisibleButtons();
        }

        private void RunButton_click(object sender, RoutedEventArgs e)
        {
            DataContext.Run();
            info.Text = DataContext.Data;
        }

        private void StopButton_click(object sender, RoutedEventArgs e)
        {
            DataContext.Stop();
            info.Text = DataContext.Data;
        }

        private void VoiceButton_click(object sender, RoutedEventArgs e)
        {
            DataContext.Voice();
            info.Text = DataContext.Data;
        }

        private void UpButton_click(object sender, RoutedEventArgs e)
        {
            DataContext.Up();
            info.Text = DataContext.Data;
        }

        private void DownButton_click(object sender, RoutedEventArgs e)
        {
            DataContext.Down();
            info.Text = DataContext.Data;
        }

        private async void OpenFile(object? sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "DLL files (*.dll)|*.dll";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                if (File.Exists(filePath))
                {
                    try
                    {
                        Assembly assembly = Assembly.LoadFrom(filePath);
                        MessageBox.Show($"DLL {filePath} uploaded.", "Download DLL", MessageBoxButton.OK, MessageBoxImage.Information);
                        DataContext.Route = filePath;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Err DLL: {ex.Message}", "Err DLL", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"DLL not found: {filePath}", "Err DLL", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            animalButton.Visibility = Visibility.Visible;
            info.Text = DataContext.Data;
        }
    }
}