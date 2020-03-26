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

namespace ShopBot
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Logic.GetListProfiles();
            Click_Button(new Profiles(1));

            //DashBoard.Visibility = Visibility.Hidden;

            if (!Logic.GetPath())
            {
                MessageBox.Show("Specify paths in the settings!",
                    "Message",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

        }

        private void AddProfile_Click(object sender, RoutedEventArgs e)
        {
            Click_Button(new AddProfile());
        }

        private void Profiles_Click(object sender, RoutedEventArgs e)
        {
            
             Click_Button(new Profiles(1));
        }

        private void Click_Button(UserControl r)
        {
            this.GridUserControl.Children.Clear();
            this.GridUserControl.Children.Add(r);
        }

        private void Tasks_Click(object sender, RoutedEventArgs e)
        {
            Click_Button(new Tasks());
        }

        private void DashBoard_Click(object sender, RoutedEventArgs e)
        {
            Click_Button(new DashBoard(this.DashBoard.Background, this.DashBoard.BorderBrush, this.DashBoard.BorderThickness, this.DashBoard.Foreground));
        }

        private void nastr_Click(object sender, RoutedEventArgs e)
        {
            Setting f = new Setting();
            f.ShowDialog();
        }

        public static void errorPy(string s)
        {
            //if (Logic.AddTask(Profiles.SelectedIndex, Card.SelectedIndex, Retailers.SelectedIndex, Task_Name.Text, Keywords.Text, Link.Text))
            //{
            //    ClearAll();
            //    MessageBox.Show("The task is saved!",
            //                    "Message",
            //                    MessageBoxButton.OK,
            //                    MessageBoxImage.Information);
            //}
            //else
            //{
            MessageBox.Show(s + " error!",
                            "Message",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
            //}
        }
    }
}
