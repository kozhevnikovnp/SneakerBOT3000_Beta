using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для Tasks.xaml
    /// </summary>
    
    public partial class Tasks : UserControl
    {
        public Tasks()
        {
            InitializeComponent();
            if (Logic.person.Count != 0)
            {
                List<string> mas = new List<string>();
                foreach(Profile x in Logic.person)
                {
                    mas.Add(x.name + " " + x.surname);
                }
                Profiles.ItemsSource = mas;
                Profiles.SelectedIndex = 0;

                //mas.Clear();
                //foreach(ClardPerson x in Logic.person[0].card)
                //{
                //    mas.Add(x.cardNumber);
                //}
                //Card.ItemsSource = mas;
                //Card.SelectedIndex = 0;

                Retailers.ItemsSource = Logic.retailers;
                Retailers.SelectedIndex = 0;
            }
            else
            {
                Tasks_save.Visibility = Visibility.Hidden;
                Clear_all.Visibility = Visibility.Hidden;
            }
        }

        private void Tasks_save_Click(object sender, RoutedEventArgs e)
        {
            //if(Task_Name.Text == ""||
            //Keywords.Text == ""||
            //Link.Text == "")
            //{
            //    MessageBox.Show("Not all fields are filled!",
            //        "Message",
            //        MessageBoxButton.OK,
            //        MessageBoxImage.Error);
            //    return;
            //}
            //Thread at = new Thread(new ThreadStart(Logic.AddTask(Profiles.SelectedIndex, Card.SelectedIndex, Retailers.SelectedIndex, Task_Name.Text, Keywords.Text, Link.Text)));
            //ParameterizedThreadStart.CreateDelegate(void, Logic.AddTask);

            
            Logic.python(Profiles.SelectedIndex, Card.SelectedIndex, Retailers.SelectedIndex, Task_Name.Text, Keywords.Text, Link.Text, time.Text);


        }

        private void Clear_all_Click(object sender, RoutedEventArgs e)
        {
            Retailers.SelectedIndex = 0;
            ClearAll();
        }

        private void ClearAll()
        {
            Card.SelectedIndex = 0;
            Task_Name.Text = "";
            Keywords.Text = "";
            Link.Text = "";
            time.Text = "";
        }

        private void Profiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                List<string> mas = new List<string>();

                foreach (ClardPerson x in Logic.person[Profiles.SelectedIndex].card)
                {
                    mas.Add(x.cardNumber);
                }
                Card.ItemsSource = mas;
                Card.SelectedIndex = 0;
            }
            catch
            {
                return;
            }
        }
    }
}
