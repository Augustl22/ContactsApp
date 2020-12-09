using System;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class ContactTests
    {
        [Test]
        public void Surname_GoodSurname_ReturnsSameSurname()
        {
            //Setup
            var contact = new Contact();
            var sourceSurname = "Пчелкин";
            var expectedName = sourceSurname;

            //Act
            contact.Surname = sourceSurname;
            var actualSurname = contact.Surname;

            //Assert
            Assert.AreEqual(expectedName, actualSurname);
        }

        [Test]
        public void Surname_TooLongSurname_ThrowsException()
        {
            //Setup
            var contact = new Contact();
            var sourceSurname = "123456789012345678901234567890123456789012345678901";

            //Assert
            Assert.Throws<ArgumentException>
            (
                () =>
                {
                    //Act
                    contact.Surname = sourceSurname;
                }
            );
        }

        [Test]
        public void Surname_EmptySurname_ThrowsException()
        {
            //Setup
            var contact = new Contact();
            var sourceSurname = "";

            //Assert
            Assert.Throws<ArgumentException>
            (
                () =>
                {
                    //Act
                    contact.Surname = sourceSurname;
                }
            );
        }

        [Test]
        public void Name_TooLongName_ThrowsException()
        {
            //Setup
            var contact = new Contact();
            var sourceName = "123456789012345678901234567890123456789012345678901";

            //Assert
            Assert.Throws<ArgumentException>
            (
                () =>
                {
                    //Act
                    contact.Name = sourceName;
                }
            );
        }

        [Test]
        public void Name_EmptyName_ThrowsException()
        {
            //Setup
            var contact = new Contact();
            var sourceName = "";

            //Assert
            Assert.Throws<ArgumentException>
            (
                () =>
                {
                    //Act
                    contact.Name = sourceName;
                }
            );
        }

        [Test]
        public void CloneContact_Correctly()
        {
            //Setup
            Contact sourceContact;
            sourceContact = new Contact();
            sourceContact.PhoneNumber.Number = 71122334455;
            sourceContact.Birthday = new DateTime(2020,12,8);
            sourceContact.Email = "123@gmail.com";
            sourceContact.IdVkontakte = "qwerty";
            sourceContact.Name = "Вася";
            sourceContact.Surname = "Пупкин";

            //Act
            var exectedContact = (Contact)sourceContact.Clone();

            //Assert
            Assert.Multiple(() =>
            {
                    Assert.AreEqual(sourceContact.Surname, exectedContact.Surname);
                    Assert.AreEqual(sourceContact.Name, exectedContact.Name);
                    Assert.AreEqual(sourceContact.Birthday, exectedContact.Birthday);
                    Assert.AreEqual(sourceContact.PhoneNumber.Number, exectedContact.PhoneNumber.Number);
                    Assert.AreEqual(sourceContact.IdVkontakte, exectedContact.IdVkontakte);
                    Assert.AreEqual(sourceContact.Email, exectedContact.Email);
            });
        }

        [Test]
        public void Birthday_FutureBadBirthday_ThrowsException()
        {
            //Setup
            var contact = new Contact();
            var badDay = new DateTime(2100, 12, 8);

            //Assert
            Assert.Throws<ArgumentException>
            (
                () =>
                {
                    //Act
                    contact.Birthday = badDay;
                }
            );
        }

        [Test]
        public void Birthday_PastBadBirthday_ThrowsException()
        {
            //Setup
            var contact = new Contact();
            var badDay = new DateTime(1800, 12, 8);

            //Assert
            Assert.Throws<ArgumentException>
            (
                () =>
                {
                    //Act
                    contact.Birthday = badDay;
                }
            );
        }

        [Test]
        public void Email_TooLongEmail_ThrowsException()
        {
            //Setup
            var contact = new Contact();
            var sourceEmail = "123456789012345678901234567890123456789012345678901@gmail.com";

            //Assert
            Assert.Throws<ArgumentException>
            (
                () =>
                {
                    //Act
                    contact.Email = sourceEmail;
                }
            );

        }

        [Test]
        public void IdVkontakte_TooLongIdVkontakte_ThrowsException()
        {
            //Setup
            var contact = new Contact();
            var sourceIdVk = "qwertyqwertyqwertyqwerty";

            //Assert
            Assert.Throws<ArgumentException>
            (
                () =>
                {
                    //Act
                    contact.IdVkontakte = sourceIdVk;
                }
            );

        }
    }
}
