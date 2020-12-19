using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class PhoneNumberTest
    {
        [Test]
        public void PhoneNumber_TooLongPhoneNumber_ThrowException()
        {
            //Setup
            var PhoneNumber = new PhoneNumber();
            long sourceNumber = 112233445566;

            //Assert
            Assert.Throws<ArgumentException>
            (
                () =>
                {
                    //Act
                    PhoneNumber.Number = sourceNumber;
                });
        }

        [Test]
        public void PhoneNumber_BadPhoneNumber_ThrowException()
        {
            //Setup
            var PhoneNumber = new PhoneNumber();
            long sourceNumber = 11223344556;

            //Assert
            Assert.Throws<ArgumentException>
            (
                () =>
                {
                    //Act
                    PhoneNumber.Number = sourceNumber;
                });
        }
    }
}
