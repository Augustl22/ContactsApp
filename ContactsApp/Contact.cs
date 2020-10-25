using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    public class Contact : ICloneable
    {
        private string _surname;

        private string _name;

        public PhoneNumber PhoneNumber { get; set; }

        private DateTime _birthday;

        private string _email;

        private string _idvk;

        public string Surname
        {
            get => _surname;
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Фамилия не может превышать 50 символов");
                }
                if (value.Length != 0) { _surname = Char.ToUpper(value[0]) + value.Substring(1); }
            }

        }

        public string Name
        {
            get => _name;
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Имя не может превышать 50 символов");
                }
                if (value.Length != 0) { _name = Char.ToUpper(value[0]) + value.Substring(1); }
            }

        }

        public string Email
        {
            get => _email;
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("E-mail не может превышать 50 символов");
                }
                _email = value;
            }

        }

        public string IdVkontakte
        {
            get => _idvk;
            set
            {
                if (value.Length > 15)
                {
                    throw new ArgumentException("ID Вконтакте не может превышать 15 символов");
                }
                _idvk = value;
            }

        }

        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                if((value.Year < 1900) && (value > DateTime.Today))
                {
                    throw new ArgumentException("Дата рождения не может быть меньше 1900 года и больше нынешней даты");
                }
                _birthday = value;
            }
        }


        public object Clone()
        {
            var phoneNumber = new PhoneNumber { Number = this.PhoneNumber.Number };
            return new Contact
            {
                Surname = this.Surname,
                Name = this.Name,
                Birthday = this.Birthday,
                Email = this.Email,
                IdVkontakte = this.IdVkontakte,
                PhoneNumber = phoneNumber
            };
        }
    }
}
