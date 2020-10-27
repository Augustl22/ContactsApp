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
        /// номер телефона
        /// </summary>
        private long _number;

        /// <summary>
        /// свойство номера телефона 
        /// устанавливает значение если номер телефона длинной 11 цифр и первая цифра 7
        /// </summary>
        public long Number
        {
            get => _number;
            set
            {
                if ((value.ToString().Length == 11) && (value.ToString()[0] == '7'))
                {
                    _number = value;
                }
                else
                {
                    throw new ArgumentException("Номер телефона введен не корректно");
                }
            }
        }
    }
}
    