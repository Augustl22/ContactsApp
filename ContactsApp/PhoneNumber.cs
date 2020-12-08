using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс номера телефона
    /// </summary>
    public class PhoneNumber 
    {
        /// <summary>
        /// Номер телефона.
        /// </summary>
        private long _number;
        //public PhoneNumber() { }

        /// <summary>
        /// Cвойство номера телефона. 
        /// Устанавливает значение, если номер телефона длинной 11 цифр и первая цифра 7.
        /// </summary>
        public long Number
        {
            get
            {
                return _number;
            }
            set
            {
                if (value.ToString().Length == 0)
                {
                    throw new ArgumentException("Phone number is required");
                }
                if ((value.ToString().Length == 11) && (value.ToString()[0] == '7'))
                {
                    _number = value;
                }
                else
                {
                    throw new ArgumentException("Phone number must start with 7 and be 11 digits long ");
                }
            }
        }

    }
}
    