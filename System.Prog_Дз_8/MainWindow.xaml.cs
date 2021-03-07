using Microsoft.Win32;
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

namespace System.Prog_Дз_8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int selectedColor = 1;
        int selectedFontSize = 12;
        public MainWindow()
        {
            InitializeComponent();
            OpenProgramChangeProgram();
        }

        public void EditColor()
        {
            if (selectedColor == 1) 
            { 
                dockPanel.Background = new SolidColorBrush(Colors.Black);
                mainMenu.Background = new SolidColorBrush(Colors.Black);
                foreach (MenuItem item in mainMenu.Items)
                {
                    foreach (MenuItem item2 in item.Items)
                    {
                        item2.Background = new SolidColorBrush(Colors.Black);
                        item2.Foreground = new SolidColorBrush(Colors.White);
                        item2.BorderBrush = new SolidColorBrush(Colors.Black);
                    }
                    item.Background = new SolidColorBrush(Colors.Black);
                    item.Foreground = new SolidColorBrush(Colors.White);
                }
            }
            else if (selectedColor == 0)
            {
                dockPanel.Background = new SolidColorBrush(Colors.White);
                mainMenu.Background = new SolidColorBrush(Colors.White);
                foreach (MenuItem item in mainMenu.Items)
                {
                    item.Background = new SolidColorBrush(Colors.White);
                    foreach (MenuItem item2 in item.Items)
                    {
                        item2.Background = new SolidColorBrush(Colors.White);
                        item2.Foreground = new SolidColorBrush(Colors.Black);
                        item2.BorderBrush = new SolidColorBrush(Colors.White);
                    }
                    item.Background = new SolidColorBrush(Colors.White);
                    item.Foreground = new SolidColorBrush(Colors.Black);
                }
            }
        }

        private void BlackThemeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            selectedColor = 1;

            EditColor();
        }

        private void WhiteThemeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            selectedColor = 0;

            EditColor();
        }

        private void SystemThemeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            selectedColor = (int)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize","ColorPrevalence", null);

            EditColor();
        }
        public void EditFontSize()
        {
            mainMenu.FontSize = selectedFontSize;
            foreach (MenuItem item in mainMenu.Items)
            {
                foreach (MenuItem item2 in item.Items)
                {
                    item2.FontSize = selectedFontSize;
                }
                item.FontSize = selectedFontSize;
            }
        }
        private void Size8MenuItem_Click(object sender, RoutedEventArgs e)
        {
            selectedFontSize = 8;

            EditFontSize();
        }

        private void Size14MenuItem_Click(object sender, RoutedEventArgs e)
        {
            selectedFontSize = 14;

            EditFontSize();
        }

        private void Size20MenuItem_Click(object sender, RoutedEventArgs e)
        {
            selectedFontSize = 20;

            EditFontSize();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            EditRegister();
        }
        public void EditRegister()
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey key1 = currentUserKey.CreateSubKey("VisualProgramSettings");
            key1.SetValue("Theme", selectedColor, RegistryValueKind.DWord);
            key1.SetValue("FontSize", selectedFontSize, RegistryValueKind.DWord);
            key1.Close();
        }
        public void OpenProgramChangeProgram()
        {
            try
            {
                selectedColor = (int)Registry.GetValue(@"HKEY_CURRENT_USER\VisualProgramSettings", "Theme", null);
                selectedFontSize = (int)Registry.GetValue(@"HKEY_CURRENT_USER\VisualProgramSettings", "FontSize", null);

                EditColor();
                EditFontSize();
            }
            catch (Exception)
            {}
            
        }

       
    }
}
