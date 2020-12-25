using System;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    class ProjectTests
    {
        public Project PrepareProject()
        {
            var sourceProject = new Project();

            sourceProject.ContactsList.Add(new Contact()
                {
                    Surname = "Пчелкин",
                    Name = "Иван",
                    Birthday = new DateTime(2020, 12, 7, 23, 55, 17),
                    PhoneNumber = new PhoneNumber()
                    {
                        Number = 78901234567
                    },
                    IdVkontakte = "qwerty",
                    Email = "123@gmail.com"
                }
            );

            sourceProject.ContactsList.Add(new Contact()
                {
                    Surname = "Пупкин",
                    Name = "Вася",
                    Birthday = DateTime.Today,
                    PhoneNumber = new PhoneNumber()
                    {
                        Number = 78891234321
                    },
                    IdVkontakte = "qwerty",
                    Email = "123@gmail.com"
                }
            );
            return sourceProject;
        }
        [Test]
        public void BirthdayList_CorrectlyList()
        {
            //Setup
            var sourceProject = PrepareProject();

            //Act
            Project.BirthdayList(sourceProject, DateTime.Today);

            //Assert
            Assert.NotNull(sourceProject.ContactsList);
        }
    }
}
