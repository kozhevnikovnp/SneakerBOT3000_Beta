using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
//using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShopBot
{
    /// <summary>
    /// Логика взаимодействия для Profiles.xaml
    /// </summary>
    public partial class Profiles : UserControl
    {
        Image def = new Image();
        public Profiles(int i)
        {
            InitializeComponent();
            if (Logic.person.Count != 0)
            {
                def.Source = Photo.Source;
                List<string> mas = new List<string>();
                foreach (Profile x in Logic.person)
                {
                    mas.Add(x.name + " " + x.surname);
                }
                this.Account.ItemsSource = mas;
                this.Account.SelectedIndex = 0;
                AddData(0);
            }
            
        }

        private void ChangePhoto_Click(object sender, RoutedEventArgs e)
        {

            if (Account.SelectedIndex == -1)
            {
                MessageBox.Show("Create a profile!",
                    "Message",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return;
            }

            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();

            ofd.Filter = "|*.jpg|*.png|";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Photo.Source = new BitmapImage(new Uri(ofd.FileName));
                Logic.ChangePhoto(this.Account.SelectedIndex, ofd.FileName);
                Logic.SaveProfiles();
                Logic.GetListProfiles();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(Account.SelectedIndex == -1)
            {
                return;
            }
             if (Name.Text == ""||
                Surname.Text ==""||
                Email.Text == ""||
                Phone.Text==""||
                Zip_Code.Text==""||
                Country.Text==""||
                State.Text==""||
                City.Text==""||
                Address.Text == "")
            {
                MessageBox.Show("Not all fields are filled!",
                    "Message",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return;
            }
            if (Email.Text.ToCharArray().Where(c=>c=='@').Count() != 1)
            {
                MessageBox.Show("Invalid Email!",
                    "Message",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return;
            }

            if(Account.SelectedIndex == -1)
            {
                MessageBox.Show("Create profile!",
                    "Message",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return;
            }
            MessageBoxResult rez = MessageBox.Show("Changes are saved?",
                     "Message",
                     MessageBoxButton.YesNo,
                     MessageBoxImage.Information);
            if (rez == MessageBoxResult.Yes)
            {
                MessageBox.Show("Changes are saved!",
                    "Message",
                    MessageBoxButton.OK);
                Logic.ChangeProfile(Account.SelectedIndex,
                Name.Text,
                Surname.Text,
                Email.Text,
                Phone.Text,
                Zip_Code.Text,
                Country.Text,
                State.Text,
                City.Text,
                Address.Text);
                Logic.SaveProfiles();
                Logic.GetListProfiles();
            }
            
        }

        private void Name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
            char c = Convert.ToChar(e.Text);
            if (Char.IsControl(c))
            {
                Surname.Focus();
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

        private void Surname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char c = Convert.ToChar(e.Text);
            if (Char.IsControl(c))
            {
                Email.Focus();
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

        private void Email_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char c = Convert.ToChar(e.Text);
            if (Char.IsControl(c))
            {
                Phone.Focus();
                return;
            }
            int a = Email.Text.ToCharArray().Where(d => d == '@').Count();
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

        private void Phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char c = Convert.ToChar(e.Text);
            if (Char.IsControl(c))
            {
                Zip_Code.Focus();
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

        private void Zip_Code_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char c = Convert.ToChar(e.Text);
            if (Char.IsControl(c))
            {
                Country.Focus();
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

        private void Country_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char c = Convert.ToChar(e.Text);
            if (Char.IsControl(c))
            {
                State.Focus();
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

        private void State_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char c = Convert.ToChar(e.Text);
            if (Char.IsControl(c))
            {
                City.Focus();
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

        private void City_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char c = Convert.ToChar(e.Text);
            if (Char.IsControl(c))
            {
                Address.Focus();
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

        private void AddData(int i)
        {
            try
            {
                Name.Text = Logic.person[i].name;
                Surname.Text = Logic.person[i].surname;
                Email.Text = Logic.person[i].email;
                Phone.Text = Logic.person[i].phone;
                Zip_Code.Text = Logic.person[i].zip_code;
                Country.Text = Logic.person[i].country;
                State.Text = Logic.person[i].state;
                City.Text = Logic.person[i].city;
                Address.Text = Logic.person[i].adress;
                List<string> mas = new List<string>();
                foreach (ClardPerson x in Logic.person[i].card)
                {
                    mas.Add(x.cardNumber);
                }
                mas.Add("Add card");
                cardProfile.ItemsSource = mas;
                //cardProfile.SelectedIndex = 0;
            }
            catch
            {
                return;
            }
            try
            {
                this.Photo.Source = new BitmapImage(new Uri(Logic.person[i].photo));
            }catch(Exception e)
            {
                this.Photo.Source = def.Source;
            }
        }
        private void Account_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AddData(this.Account.SelectedIndex);
        }

        private void cardProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Card t;
            if (cardProfile.SelectedIndex+1 == cardProfile.Items.Count)
            {
                t = new Card(this.Account.SelectedIndex);
            }
            else
            {
                if (cardProfile.SelectedIndex == -1)
                {
                    return;
                }
                 t = new Card(cardProfile.SelectedIndex,this.Account.SelectedIndex);
            }
            t.ShowDialog();
            AddData(Account.SelectedIndex);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Account.SelectedIndex == -1)
            {
                return;
            }
            MessageBoxResult rez = MessageBox.Show("do you want to delete the profile?",
                     "Message",
                     MessageBoxButton.YesNo,
                     MessageBoxImage.Information);
            if (rez == MessageBoxResult.Yes)
            {
                Logic.DeleteProfile(Account.SelectedIndex);
                MessageBox.Show("Profile deleted!",
                     "Message",
                     MessageBoxButton.OK,
                     MessageBoxImage.Information);
                ClearAll();
                AddData(0);
            }
        }

        private void ClearAll()
        {
            def.Source = Photo.Source;
            List<string> mas = new List<string>();
            foreach (Profile x in Logic.person)
            {
                mas.Add(x.name + " " + x.surname);
            }
            this.Account.ItemsSource = mas;
            this.Account.SelectedIndex = 0;

            Name.Text = "";
            Surname.Text = "";
            Email.Text = "";
            Phone.Text = "";
            Zip_Code.Text = "";
            Country.Text = "";
            State.Text = "";
            City.Text = "";
            Address.Text = "";
            cardProfile.ItemsSource = null;
        }
    }
}
