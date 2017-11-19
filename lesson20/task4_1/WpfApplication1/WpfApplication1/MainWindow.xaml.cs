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
using System.ComponentModel.DataAnnotations;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    class Validation
    {
        [Required]
        [StringLength(255),MinLength(4)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        
        public string FirstName { get; set; }
        [Required]
        [StringLength(255),MinLength(4)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string LastName { get; set; }
        [Required]
        [Range(0,31)]
        public int Day { get; set; }
        [Required]
        [Range(1, 12)]
        public int Month { get; set; }
        [Required]
        [Range(1900, 2017)]
        public int Year { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(255),MinLength(4)]
        public string Email { get; set; }
        [Required]
        [Phone]
        [StringLength(12),MinLength(12)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(2000),MinLength(4)]
        public string Info { get; set; }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ErrorsAccured.Content = "";
            var validation = new Validation();
            validation.FirstName = FirstNameTb.Text;
            validation.LastName = LastNameTb.Text;
            try
            {
                validation.Day = Convert.ToInt32(dayTb.Text);
                validation.Month = Convert.ToInt32(monthTb.Text);
                validation.Year = Convert.ToInt32(yearTb.Text);
            }
            catch (Exception ex)
            {
                ErrorsAccured.Content += "Wrong days/month/year input or empty field,\n";
            }
            validation.Email = EmailTb.Text;
            validation.PhoneNumber = PhoneNumberTb.Text;
            validation.Info = AdditionalInfoTb.Text;

            var context = new ValidationContext(validation, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(validation, context, results);

            if (!isValid)
            {
                foreach (var validationResult in results)
                {
                    ErrorsAccured.Content += string.Format("{0},\n", validationResult.ErrorMessage);
                }
            }
        }

        private void MaleRadioButton_Checked(object sender, RoutedEventArgs e)
        {
           
        }

        private void FemaleRadioButton_Checked(object sender, RoutedEventArgs e)
        {
           
        }

        private void dayTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
