using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public  int RandomNumber;

        public  bool GuessNumber()
        {
            var random = new Random();
            RandomNumber = random.Next(1, 10);
            if (Convert.ToInt32(EnterNumberTb.Text) == RandomNumber)
            {
                return true;
            }
            return false;
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var matched = GuessNumber();
                if (!matched)
                {
                    OutputTb.Content = string.Format("Generated number:{0}", RandomNumber);
                    return;
                }
            }
            catch (FormatException)
            {
                OutputTb.Content = "Incorrect input";
                return;
            }
            catch (ArgumentNullException)
            {
                OutputTb.Content = "Incorrect input";
                return;
            }
            catch (Exception ex)
            {
                OutputTb.Content = "Unknown error "+ex.Message;
                return;
            }

            OutputTb.Content = string.Format("Success:{0}={1}", RandomNumber, EnterNumberTb.Text);
        }
    }
}
