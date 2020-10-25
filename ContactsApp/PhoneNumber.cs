using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    public class PhoneNumber
    {
        private long _number;

        public long Number
        {
            get => _number;
            set
            {
                if((value.ToString().Length == 11) && (value.ToString()[0] == '7'))
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
