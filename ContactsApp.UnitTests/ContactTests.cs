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
        public void Name_GoodName_ReturnsName()
        {
            //Setup
            var contact = new Contact();
            var sourceName = "Иван";
            var expectedName = sourceName;

            //Act
            contact.Name = sourceName;
            var actualSurname = contact.Name;

            //Assert
            Assert.AreEqual(expectedName, actualSurname);
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
    }
}
