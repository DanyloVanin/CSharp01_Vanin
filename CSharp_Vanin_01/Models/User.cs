using System;

namespace CSharp_Vanin_01.Models
{
    internal class User
    {
        private DateTime _birthDate;
        private string _age;
        private string _westernZodiac;
        private string _chineseZodiac;

        #region Properties

        public DateTime BirthDate
        {
            get => _birthDate;
            set => _birthDate = value;
        }

        public string Age
        {
            get => _age;
            set => _age = value;
        }

        public string WesternZodiac
        {
            get => _westernZodiac;
            set => _westernZodiac = value;
        }

        public string ChineseZodiac
        {
            get => _chineseZodiac;
            set => _chineseZodiac = value;
        }
        #endregion
    }
}