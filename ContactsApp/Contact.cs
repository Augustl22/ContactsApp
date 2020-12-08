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
                if (value.Length == 0)
                {
                    throw new ArgumentException("Surname is required");
                }
                if (MaxLength(value, 50))
                {
                    _surname = Char.ToUpper(value[0]) + value.Substring(1);
                }
                else
                {
                    throw new ArgumentException("Surname cannot exceed 50 symbols");
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
                if (value.Length == 0)
                {
                    throw new ArgumentException("Name is required");
                }
                if (MaxLength(value, 50))
                {
                    _name = Char.ToUpper(value[0]) + value.Substring(1);
                }
                else
                {
                    throw new ArgumentException("Name cannot exceed 50 symbols");
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
                    throw new ArgumentException("E-mail cannot exceed 50 symbols");
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
                    throw new ArgumentException("IDVkontakte cannot exceed 50 symbols");
                }
            }

        }
        public PhoneNumber PhoneNumber { get; set; } = new PhoneNumber();

        public Contact() { }

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
                if ((value.Year < 1900))
                {
                    throw new ArgumentException("Date of birth cannot be less than 1900");

                }
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Date of birth cannot be greater than the current date");
                }
                _birthday = value;
            }
        }

        bool MaxLength(string x, int j)
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
            PhoneNumber phoneNumber = new PhoneNumber { Number = this.PhoneNumber.Number };
            return new Contact
            {
                PhoneNumber = phoneNumber,
                Surname = this.Surname,
                Name = this.Name,
                Birthday = this.Birthday,
                Email = this.Email,
                IdVkontakte = this.IdVkontakte,
            };
        }
    }
}
