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
    /// Логика взаимодействия для AddProfile.xaml
    /// </summary>
    public partial class AddProfile : UserControl
    {
        public AddProfile()
        {
            InitializeComponent();
        }

        private void Go_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text == "" ||
                TextBox2.Text == "" ||
                TextBox3.Text == "" ||
                TextBox4.Text == "" ||
                TextBox5.Text == "" ||
                TextBox6.Text == "" ||
                TextBox7.Text == "" ||
                TextBox8.Text == "" ||
                TextBox9.Text == "")
            {
                MessageBox.Show("Not all fields are filled!",
                    "Message",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            if (TextBox3.Text.ToCharArray().Where(c => c == '@').Count() != 1)
            {
                MessageBox.Show("Invalid Email",
                    "Message",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            MessageBoxResult rez = MessageBox.Show("Save?",
                     "Message",
                     MessageBoxButton.YesNo,
                     MessageBoxImage.Information);
            if (rez == MessageBoxResult.Yes)
            {
                Logic.AddProfile(
                    TextBox1.Text,
                    TextBox2.Text,
                    TextBox3.Text,
                    TextBox4.Text,
                    TextBox5.Text,
                    TextBox6.Text,
                    TextBox7.Text,
                    TextBox8.Text,
                    TextBox9.Text);
                Logic.SaveProfiles();
                Logic.GetListProfiles();
                Card c = new Card(Logic.person.Count-1);
                c.ShowDialog();
                ClearAll();
                Logic.SaveProfiles();
                Logic.GetListProfiles();
                
            }

        }

        private void TextBox2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char c = Convert.ToChar(e.Text);
            if (Char.IsControl(c))
            {
                TextBox3.Focus();
                return;
            }
            if (Char.IsLetter(c) || Char.IsSurrogate(c))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char c = Convert.ToChar(e.Text);
            if (Char.IsControl(c))
            {
                TextBox2.Focus();
                return;
            }
            if (Char.IsLetter(c) || Char.IsSurrogate(c))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox3_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char c = Convert.ToChar(e.Text);
            if (Char.IsControl(c))
            {
                TextBox4.Focus();
                return;
            }
            int a = TextBox3.Text.ToCharArray().Where(d => d == '@').Count();
            if (c == '@')
            {
                if (a == 0)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
                return;
            }
            e.Handled = false;
        }

        private void TextBox4_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char c = Convert.ToChar(e.Text);
            if (Char.IsControl(c))
            {
                TextBox5.Focus();
                return;
            }
            if (Char.IsSurrogate(c) || Char.IsDigit(c))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox5_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char c = Convert.ToChar(e.Text);
            if (Char.IsControl(c))
            {
                TextBox6.Focus();
                return;
            }
            if (Char.IsSurrogate(c) || Char.IsDigit(c))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox6_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char c = Convert.ToChar(e.Text);
            if (Char.IsControl(c))
            {
                TextBox7.Focus();
                return;
            }
            if (Char.IsLetter(c) || Char.IsSurrogate(c))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox7_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char c = Convert.ToChar(e.Text);
            if (Char.IsControl(c))
            {
                TextBox8.Focus();
                return;
            }
            if (Char.IsLetter(c) || Char.IsSurrogate(c))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox8_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char c = Convert.ToChar(e.Text);
            if (Char.IsControl(c))
            {
                TextBox9.Focus();
                return;
            }
            if (Char.IsLetter(c) || Char.IsSurrogate(c))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox9_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char c = Convert.ToChar(e.Text);
            if (Char.IsControl(c))
            {
                Go.Focus();
                return;
            }
            e.Handled = false;
        }

        private void ClearAll()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
        }
    }
}
