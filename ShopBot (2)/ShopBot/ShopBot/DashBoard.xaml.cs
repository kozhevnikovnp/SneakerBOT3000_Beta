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
    /// Логика взаимодействия для DashBoard.xaml
    /// </summary>
    public partial class DashBoard : UserControl
    {
        Brush a, b, d;
        Thickness c;
        public DashBoard(Brush aa, Brush bb, Thickness cc, Brush dd)
        {
            InitializeComponent();
            a = aa;
            b = bb;
            c = cc;
            d = dd;
            addTask();
        }

        public void addTask()
        {
            foreach (Profile x in Logic.person)
            {
                foreach (Task y in x.tasks)
                {
                    Button but = new Button();
                    but.Background = a;
                    but.BorderBrush = b;
                    but.BorderThickness = c;
                    but.Foreground = d;
                    but.Height = 27;
                    but.Margin = c;
                    but.Content = x.name + " " + y.Keywords + " " + y.time + " " + y.status;
                    this.stack.Children.Add(but);
                }
            }

        }

    }
}
