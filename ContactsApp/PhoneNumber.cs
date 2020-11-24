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
    public class PhoneNumber : ICloneable
    {
        /// <summary>
        /// Номер телефона.
        /// </summary>
        private long _number;
        public PhoneNumber() { }

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
                if ((value.ToString().Length == 11) && (value.ToString()[0] == '7'))
                {
                    _number = value;
                }
                else
                {
                    throw new ArgumentException("Номер телефона должен начинаться с 7 и иметь длинну в 11 цифр ");
                }
            }
        }
        
        public object Clone()
        {
            return new PhoneNumber
            {
                Number = this.Number
            };
        }
    }
}
    