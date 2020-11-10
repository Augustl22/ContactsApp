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
        /// Фамилия.
        /// </summary>
        private string _surname;

        /// <summary>
        /// Имя.
        /// </summary>
        private string _name;

        /// <summary>
        /// Дата рождение.
        /// </summary>
        private DateTime _birthday;

        /// <summary>
        /// E-mail.
        /// </summary>
        private string _email;

        /// <summary>
        /// Id в соц. сети "Вконтакте". 
        /// </summary>
        private string _idvk;

        /// <summary>
        /// Номер телефона.
        /// </summary>
        public PhoneNumber PhoneNumber { get; set; }

        /// <summary>
        /// Свойство фамилии.
        /// Устанавливает значение, если длинна фамилии не больше 50 символов и делает первую букву заглавной.
        /// </summary>
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (MaxLength(value, 50))
                {
                    _surname = Char.ToUpper(value[0]) + value.Substring(1);
                }
                else
                {
                    throw new ArgumentException("Фамилия не может превышать 50 символов");
                }
            }

        }

        /// <summary>
        /// Свойство имени.
        /// Устанавливает значение, если длинна имени не больше 50 символов и делает первую букву заглавной.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (MaxLength(value, 50))
                {
                    _name = Char.ToUpper(value[0]) + value.Substring(1);
                }
                else
                {
                    throw new ArgumentException("Имя не может превышать 50 символов");
                }
            }

        }

        /// <summary>
        /// Свойство e-mail.
        /// Устанавливает значение, если длинна email не больше 50 символов.
        /// </summary>
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (MaxLength(value, 50))
                {
                    _email = value;
                }
                else
                {
                    throw new ArgumentException("E-mail не может превышать 50 символов");
                }
            }

        }

        /// <summary>
        /// Свойство ID Вконтакте.
        /// Устанавливает значение, если длинна id не больше 15 символов.
        /// </summary>
        public string IdVkontakte
        {
            get
            {
                return _idvk;
            }
            set
            {
                if (MaxLength(value, 15))
                {
                    _idvk = value;
                }
                else
                {
                    throw new ArgumentException("ID Вконтакте не может превышать 15 символов");
                }
            }

        }

        /// <summary>
        /// Свойство даты рождения.
        /// Устанавливает значение, если дата не менее 1900 года и не более текущей даты.
        /// </summary>
        public DateTime Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                if ((value.Year < 1900) && (value > DateTime.Today))
                {
                    throw new ArgumentException("Дата рождения не может быть меньше 1900 года и больше нынешней даты");
                }
                _birthday = value;
            }
        }

        bool MaxLength (string x, int j)
        {
            return x.Length < j;
        }


        /// <summary>
        /// Метод клонирования объекта данного класса. 
        /// </summary>
        /// <returns>
        /// Возвращает копию объекта данного класса.
        /// </returns>
        public object Clone()
        {
            return new Contact
            {
                Surname = this.Surname,
                Name = this.Name,
                Birthday = this.Birthday,
                Email = this.Email,
                IdVkontakte = this.IdVkontakte,
             };
        }
    }
}
