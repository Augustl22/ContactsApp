using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс контакт
    /// </summary>
    public class Contact : ICloneable
    {
        /// <summary>
        /// фамилия контакта
        /// </summary>
        private string _surname;

        /// <summary>
        /// имя контакта
        /// </summary>
        private string _name;

        /// <summary>
        /// номер телефона контакта
        /// </summary>
        public PhoneNumber PhoneNumber { get; set; }

        /// <summary>
        /// дата рождение контакта
        /// </summary>
        private DateTime _birthday;

        /// <summary>
        /// E-mail контакта
        /// </summary>
        private string _email;

        /// <summary>
        /// id в соц. сети "Вконтакте" контакта 
        /// </summary>
        private string _idvk;

        /// <summary>
        /// свойство фамилии
        /// устанавливает значение если длинна фамилии не больше 50 символов и делает первую букву заглавной
        /// </summary>
        public string Surname
        {
            get => _surname;
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Фамилия не может превышать 50 символов");
                }
                _surname = Char.ToUpper(value[0]) + value.Substring(1);
            }

        }

        /// <summary>
        /// свойство имени
        /// устанавливает значение если длинна имени не больше 50 символов и делает первую букву заглавной
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Имя не может превышать 50 символов");
                }
                _name = Char.ToUpper(value[0]) + value.Substring(1);
            }

        }

        /// <summary>
        /// свойство e-mail
        /// устанавливает значение если длинна email не больше 50 символов
        /// </summary>
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

        /// <summary>
        /// свойство ID Вконтакте
        /// устанавливает значение если длинна id не больше 15 символов
        /// </summary>
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

        /// <summary>
        /// свойство даты рождения контакта
        /// устанавливает значение если дата не менее 1900 года и не более текущей даты
        /// </summary>
        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                if ((value.Year < 1900) && (value > DateTime.Today))
                {
                    throw new ArgumentException("Дата рождения не может быть меньше 1900 года и больше нынешней даты");
                }
                _birthday = value;
            }
        }

        /// <summary>
        /// метод клонирования объекта данного класса 
        /// </summary>
        /// <returns>
        /// Возвращает копию объекта данного класса
        /// </returns>
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
