using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using CSharp_Vanin_01.Annotations;
using CSharp_Vanin_01.Models;
using CSharp_Vanin_01.Tools;

namespace CSharp_Vanin_01.ViewModels
{
    internal class BirthdayAnalyzerViewModel: INotifyPropertyChanged
    {
        #region Fields

        private readonly User _user;
        private RelayCommand<object> _analyzeDateCommand;
        #endregion

        #region Properties

        public DateTime Date
        {
            get => _user.BirthDate;
            set
            {
                _user.BirthDate = value;
                OnPropertyChanged();
            }
        }
        public string Age
        {
            get => $"Total age: {_user.Age} ";
            set
            {
                _user.Age = value;
                OnPropertyChanged();
            }
        }
        public string WesternZodiac
        {
            get => $"Western Zodiac: {_user.WesternZodiac}";
            set
            {
                _user.WesternZodiac = value;
                OnPropertyChanged();
            }
        }
        public string ChineseZodiac
        {
            get => $"Chinese Zodiac: {_user.ChineseZodiac}";
            set
            {
                _user.ChineseZodiac = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand<object> AnalyzeDateCommand
        {
            get
            {
                return _analyzeDateCommand ??= new RelayCommand<object>(AnalyzeBirthDate);
            }
        }
        #endregion

        internal BirthdayAnalyzerViewModel()
        {
            _user = new User();
            Date = DateTime.Today;
        }
        private async void AnalyzeBirthDate(object o)
        {
           await Task.Run(() =>
            {
                try
                {
                    Age=CountAge();
                    ChineseZodiac=FindChineseZodiac();
                    WesternZodiac=FindWesternZodiac();
                    CheckIfBirthday();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            });
        }
        private string CountAge()
        {
           DateTime currentDate = DateTime.Today;
           int daysOfLife = (currentDate - Date).Days;
           int years = daysOfLife / 365;
           if(daysOfLife<0 || years>135) throw new ArgumentException("Wrong Date!");
           return years.ToString();
        }
        private string FindChineseZodiac()
        {
            return (Date.Year % 12) switch
            {
                0 => "Monkey",
                1 => "Rooster",
                2 => "Dog",
                3 => "Pig",
                4 => "Rat",
                5 => "Ox",
                6 => "Tiger",
                7 => "Rabbit",
                8 => "Dragon",
                9 => "Snake",
                10 => "Horse",
                _ => "Goat"
            };
        }
        private string FindWesternZodiac()
        {
            int day = Date.Day;
            return Date.Month switch
            {
                1 => (day < 20 ? "Capricorn" : "Aquarius"),
                2 => (day < 19 ? "Aquarius" : "Pisces"),
                3 => (day < 21 ? "Pisces" : "Aries"),
                4 => (day < 20 ? "Aries" : "Taurus"),
                5 => (day < 21 ? "Taurus" : "Gemini"),
                6 => (day < 21 ? "Gemini" : "Cancer"),
                7 => (day < 23 ? "Cancer" : "Leo"),
                8 => (day < 23 ? "Leo" : "Virgo"),
                9 => (day < 23 ? "Virgo" : "Libra"),
                10 => (day < 23 ? "Libra" : "Scorpio"),
                11 => (day < 22 ? "Scorpio" : "Sagittarius"),
                _ => (day < 22 ? "Sagittarius" : "Capricorn")
            };
        }
        private void CheckIfBirthday()
        {
            if (DateTime.Today.Month == Date.Month && DateTime.Today.Day == Date.Day) MessageBox.Show("Happy Birthday!");
        }

        #region INotifyPropertyImplementation
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
