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
    /// Логика взаимодействия для Card.xaml
    /// </summary>
    public partial class Card : Window
    {
        int ind;
        int prof = -1;

        public Card(int i, int p)
        {
            InitializeComponent();
            ind = i;
            prof = p;
            CardNumber.Text = Logic.person[p].card[i].cardNumber;
            ExpiryDate.Text = Logic.person[p].card[i].date;
            CardHolderName.Text = Logic.person[p].card[i].holder;
            CVV.Text = Logic.person[p].card[i].cvv;
        }
        public Card(int i)
        {
            InitializeComponent();
            ind = i;
            deleteCard.Visibility = Visibility.Hidden;
        }

        private void OKPaymentInfo_Click(object sender, RoutedEventArgs e)
        {
            // show message
            if(CardNumber.Text.ToCharArray().Where(c=>Char.IsDigit(c)).Count() < 16)
            {
                MessageBox.Show("The card number is incorrect!",
                    "Message",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            if (ExpiryDate.Text.Length != 5)
            {
                MessageBox.Show("The date is incorrect!",
                    "Message",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            if (CardHolderName.Text == "")
            {
                MessageBox.Show("Specify the owner of the card!",
                    "Message",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            if (CVV.Text.Length != 3)
            {
                MessageBox.Show("CVV specified incorrectly!",
                    "Message",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("The card is saved!",
                    "Message",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            if (prof != -1)
            {
                Logic.person[prof].card[ind].cardNumber = CardNumber.Text;
                Logic.person[prof].card[ind].date = ExpiryDate.Text;
                Logic.person[prof].card[ind].holder = CardHolderName.Text ;
                Logic.person[prof].card[ind].cvv = CVV.Text;
            }
            else
            {
                Logic.person[ind].AddCard(CardNumber.Text,
                ExpiryDate.Text,
                CardHolderName.Text,
                CVV.Text);
            }
            Logic.SaveProfiles();
            Logic.GetListProfiles();
            
            this.Close();
        }

        private void CancelPaymentInfo_Click(object sender, RoutedEventArgs e)
        {
            if(prof != -1)
            {
                this.Close();
            }
            else
            {
                MessageBoxResult rez = MessageBox.Show("Данные не будут сохранены",
                     "Message",
                     MessageBoxButton.YesNo,
                     MessageBoxImage.Information);
                if (rez == MessageBoxResult.Yes)
                {
                    this.Close();
                }

            }

        }

        private void CardNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char c = Convert.ToChar(e.Text);
            if (Char.IsControl(c))
            {
                ExpiryDate.Focus();
                return;
            }
            int a = CardNumber.Text.ToCharArray().Where(f=>f!=' ').Count();
            if (Char.IsDigit(c) && a <= 15)
            {
                if(a%4 == 0 && a!=0)
                {
                    CardNumber.Text+=" ";
                    CardNumber.SelectionStart = CardNumber.Text.Length;
                    CardHolderName.Focus();
                    CardNumber.Focus();
                }
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void ExpiryDate_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char c = Convert.ToChar(e.Text);
            if (Char.IsControl(c))
            {
                CardHolderName.Focus();
                return;
            }
            int a = ExpiryDate.Text.ToCharArray().Where(f => Char.IsDigit(f)).Count();
            if (Char.IsSurrogate(c) || Char.IsDigit(c) && a <= 3)
            {
                if (a % 2 == 0 && a != 0)
                {
                    ExpiryDate.Text += "/";
                    ExpiryDate.SelectionStart = ExpiryDate.Text.Length;
                    CardHolderName.Focus();
                    ExpiryDate.Focus();
                }
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void CardHolderName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char c = Convert.ToChar(e.Text);
            if (Char.IsControl(c))
            {
                CVV.Focus();
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

        private void CVV_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char c = Convert.ToChar(e.Text);
            if (Char.IsControl(c))
            {
                OKPaymentInfo.Focus();
                return;
            }
            int a = CVV.Text.ToCharArray().Where(t=>Char.IsDigit(t)).Count();
            if (Char.IsSurrogate(c) || Char.IsDigit(c) && a < 3)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void deleteCard_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult rez = MessageBox.Show("The card will be deleted",
                     "Message",
                     MessageBoxButton.YesNo,
                     MessageBoxImage.Information);
            if (rez == MessageBoxResult.Yes)
            {
                Logic.DeleteCard(ind, prof);
                this.Close();
            }
        }
    }
}
