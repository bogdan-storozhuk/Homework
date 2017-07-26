using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public enum Date
    {
        Day,
        Month,
        Year
    };

    public enum ZodiacSign
    {
        Aries = 1,
        Taurus,
        Gemini,
        Cancer,
        Leo,
        Virgo,
        Libra,
        Scorpio,
        Sagittarius,
        Capricorn,
        Aquarius,
        Pisces
    }

    public enum Month
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
    public partial class MainWindow : Window
    {
        private  int _day;
        private  int _month;
        private  int _year;
        public  int GetDaysOfMonth(Month month)
        {
            if (month == null)
            {
                throw new Exception("Current month does not exist!");
            }

            switch (month)
            {
                case Month.January:
                    return 31;
                case Month.February:
                    return 28;
                case Month.March:
                    return 31;
                case Month.April:
                    return 30;
                case Month.May:
                    return 31;
                case Month.June:
                    return 30;
                case Month.July:
                    return 31;
                case Month.August:
                    return 31;
                case Month.September:
                    return 30;
                case Month.October:
                    return 31;
                case Month.November:
                    return 30;
                case Month.December:
                    return 31;
                default:
                    throw new ArgumentOutOfRangeException("month", month, null);
            }
        }
        public  void DateValidation(string[] numbers, Date date = Date.Day)
        {
            const int MinMonthNumber = 1;
            const int MaxMonthNumber = 12;
            const int MaxYearNumber = 2017;
            const int MinYearNumber = 1900;
            if (date > Date.Year)
            {
                return;
            }
            int day;
            int month;
            int year;
            switch (date)
            {
                case Date.Day:

                    if (!int.TryParse(numbers[(int)Date.Day], out day))
                    {
                        throw new Exception("Can not parse value");
                    }
                    if (!int.TryParse(numbers[(int)Date.Month], out month))
                    {
                        throw new Exception("Can not parse value");
                    }

                    if (day < 1 || day > GetDaysOfMonth((Month)month))
                    {
                        throw new ArgumentOutOfRangeException("day", day, null);
                    }
                    _day = day;
                    break;
                case Date.Month:
                    if (!int.TryParse(numbers[(int)Date.Month], out month))
                    {
                        throw new Exception("Can not parse value");
                    }
                    if (month > MaxMonthNumber || month < MinMonthNumber)
                    {
                        throw new ArgumentOutOfRangeException("month", month, null);
                    }
                    _month = month;
                    break;
                case Date.Year:
                    if (!int.TryParse(numbers[(int)Date.Year], out year))
                    {
                        throw new Exception("Can not parse value");
                    }
                    if (year < MinYearNumber || year > MaxYearNumber)
                    {
                        throw new ArgumentOutOfRangeException("year", year, null);
                    }
                    _year = year;
                    break;

            }

            DateValidation(numbers, ++date);

        }

        public  void EnterBirthday()
        {
            var birthdate = Convert.ToString(EnterTextBox.Text);
            var numbers = birthdate.Split('/');
            if (numbers.Length == 3)
            {
                DateValidation(numbers, Date.Day);
            }
            else
            {
                throw new ArgumentOutOfRangeException("numbersOfDate", numbers, null);
            }

        }

        public  ZodiacSign GetZodiacSign(int days, Month numberOfMonth)
        {

            if (numberOfMonth == null)
            {
                throw new Exception("Current month does not exist!");
            }
            switch (numberOfMonth)
            {
                case Month.January:
                    if (days >= 1 && days <= 20)
                    {
                        return ZodiacSign.Capricorn;
                    }
                    else
                    {
                        return ZodiacSign.Aquarius;
                    }
                case Month.February:
                    if (days >= 1 && days <= 18)
                    {
                        return ZodiacSign.Aquarius;
                    }
                    else
                    {
                        return ZodiacSign.Pisces;
                    }
                case Month.March:
                    if (days >= 1 && days <= 20)
                    {
                        return ZodiacSign.Pisces;
                    }
                    else
                    {
                        return ZodiacSign.Aries;
                    }
                case Month.April:
                    if (days >= 1 && days <= 20)
                    {
                        return ZodiacSign.Aries;
                    }
                    else
                    {
                        return ZodiacSign.Taurus;
                    }
                case Month.May:
                    if (days >= 1 && days <= 20)
                    {
                        return ZodiacSign.Taurus;
                    }
                    else
                    {
                        return ZodiacSign.Gemini;
                    }
                case Month.June:
                    if (days >= 1 && days <= 21)
                    {
                        return ZodiacSign.Gemini;
                    }
                    else
                    {
                        return ZodiacSign.Cancer;
                    }
                case Month.July:
                    if (days >= 1 && days <= 22)
                    {
                        return ZodiacSign.Cancer;
                    }
                    else
                    {
                        return ZodiacSign.Leo;
                    }
                case Month.August:
                    if (days >= 1 && days <= 22)
                    {
                        return ZodiacSign.Leo;
                    }
                    else
                    {
                        return ZodiacSign.Virgo;
                    }
                case Month.September:
                    if (days >= 1 && days <= 22)
                    {
                        return ZodiacSign.Virgo;
                    }
                    else
                    {
                        return ZodiacSign.Libra;
                    }
                case Month.October:
                    if (days >= 1 && days <= 23)
                    {
                        return ZodiacSign.Libra;
                    }
                    else
                    {
                        return ZodiacSign.Scorpio;
                    }
                case Month.November:
                    if (days >= 1 && days <= 22)
                    {
                        return ZodiacSign.Scorpio;
                    }
                    else
                    {
                        return ZodiacSign.Sagittarius;
                    }
                case Month.December:
                    if (days >= 1 && days <= 21)
                    {
                        return ZodiacSign.Sagittarius;
                    }
                    else
                    {
                        return ZodiacSign.Capricorn;
                    }
                default:
                    throw new ArgumentOutOfRangeException("month", numberOfMonth, null);
            }
        }

        public void DisplayZodiacImage(ZodiacSign sign)
        {
            switch (sign)
            {
                case ZodiacSign.Aries:
                    break;
                case ZodiacSign.Taurus:
                    break;
                case ZodiacSign.Gemini:
                    break;
                case ZodiacSign.Cancer:
                    break;
                case ZodiacSign.Leo:
                    break;
                case ZodiacSign.Virgo:
                    break;
                case ZodiacSign.Libra:
                    break;
                case ZodiacSign.Scorpio:
                    break;
                case ZodiacSign.Sagittarius:
                    break;
                case ZodiacSign.Capricorn:
                    break;
                case ZodiacSign.Aquarius:
                    Setimage.Source = new BitmapImage(new Uri(@"D:\Homework_C#\lesson3\task3_2\WpfApplication1\WpfApplication1\images\1.jpg"));
                    break;
                case ZodiacSign.Pisces:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("sign", sign, null);
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
                {
                    EnterBirthday();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Incorrect input");
                   return;
                }

            var currentYear = DateTime.Today.Year;
            var age = currentYear - _year;
            var month = (Month)_month;
            var zodiacSign = GetZodiacSign(_day, month);
            DisplayZodiacImage(zodiacSign);
            AgeLabel.Content = Convert.ToString(age);
            ZodiacSignLabel.Content = zodiacSign.ToString();

        }
    }
}
