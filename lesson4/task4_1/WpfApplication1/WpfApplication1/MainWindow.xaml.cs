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
using  System.Text.RegularExpressions;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public bool DataValidation()
        {
            const char dateSeparator = '/';
            if (!Regex.IsMatch(FirstNameTb.Text, @"^[a-zA-Z]+$"))
            {
                return false;
            }
            if (!Regex.IsMatch(LastNameTb.Text, @"^[a-zA-Z]+$"))
            {
                return false;
            }
            var birthdate = Convert.ToString(BirthDateTb.Text);
            var numbers = birthdate.Split(dateSeparator);
            if (numbers.Length != 3)
            {
                return false;
            }
            if (Convert.ToInt32(numbers[0]) < 0 || Convert.ToInt32(numbers[0])>32)
            {
                return false;
            }
            if (Convert.ToInt32(numbers[1]) < 0 || Convert.ToInt32(numbers[1]) > 13)
            {
                return false;
            }
            if (Convert.ToInt32(numbers[2]) < 1900 || Convert.ToInt32(numbers[2]) > 2017)
            {
                return false;
            }
            if (!Regex.IsMatch(EmailTb.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                return false;
            }
            if (PhoneNumberTb.Text.Length!= 12)
            {
                return false;
            }
            return true;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DataValidation())
            {
                resultLabel.Content = "Validation completed";
            }
            else
            {
                resultLabel.Content = "Wrong input";
            }
        }

        private void MaleRadioButton_Checked(object sender, RoutedEventArgs e)
        {
           
        }

        private void FemaleRadioButton_Checked(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
