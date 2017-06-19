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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListBoxTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (type.SelectedItem as ListBoxItem);
            switch (selectedItem.Content.ToString())
            {
                case "INT":
                    ShowIntValue();
                    break;
                case "LONG":
                    ShowLongValue();
                    break;
                case "FLOAT":
                    ShowFloatValue();
                    break;
                case "DOUBLE":
                    ShowDoubleValue();
                    break;
                case "DECIMAL":
                    ShowDecimalValue();
                    break;
                case "STRING":
                    ShowStringValue();
                    break;
                case "CHAR":
                    ShowCharValue();
                    break;
                case "BOOL":
                    ShowBoolValue();
                    break;
            }

        }
        private void ShowIntValue()
        {
            value.Text = int.MaxValue.ToString();
            value1.Text = int.MinValue.ToString();
            value3.Text = default(int).ToString();
        }

        private void ShowLongValue()
        {
            value.Text = long.MaxValue.ToString();
            value1.Text = long.MinValue.ToString();
            value3.Text = default(long).ToString();
        }

        private void ShowFloatValue()
        {
            value.Text = float.MaxValue.ToString();
            value1.Text = float.MinValue.ToString();
            value3.Text = default(float).ToString();
        }

        private void ShowDoubleValue()
        {
            value.Text = double.MaxValue.ToString();
            value1.Text = double.MinValue.ToString();
            value3.Text = default(double).ToString();
        }

        private void ShowDecimalValue()
        {
            value.Text = decimal.MaxValue.ToString();
            value1.Text = decimal.MinValue.ToString();
            value3.Text = default(decimal).ToString();
        }

        private void ShowStringValue()
        {
            value.Text = "";
            value1.Text = "";
            value3.Text = default(string);
        }

        private void ShowCharValue()
        {
            value.Text = "";
            value1.Text = "";
            value3.Text = default(char).ToString();
        }

        private void ShowBoolValue()
        {
            value.Text = "";
            value1.Text = "";
            value3.Text = default(bool).ToString();
        }

    }
}
