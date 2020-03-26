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

namespace ShopBot
{
    /// <summary>
    /// Логика взаимодействия для Setting.xaml
    /// </summary>
    public partial class Setting : Window
    {
        public Setting()
        {
            InitializeComponent();

            path.Text = Logic.pathFile.path;
            file.Text = Logic.pathFile.file;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (path.Text == "")
            {
                MessageBox.Show("Specify the path to python.exe!",
                    "Message",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            if (file.Text == "")
            {
                MessageBox.Show("Specify the path to file.py!",
                    "Message",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            Logic.pathFile.path = path.Text;
            Logic.pathFile.file = file.Text;
            Logic.SavePath();

            this.Close();
        }
    }
}
