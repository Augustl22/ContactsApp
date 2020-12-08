using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ContactsApp;


namespace ContactsApp.UnitTests
{
    using NUnit.Framework;

    [TestFixture]
    class ProjectManagerTests
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
                Birthday = new DateTime(2020, 12, 7, 23, 55, 17),
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
        public void SaveToFile_CorrectProject_FileSavedCorrectly()
        {
            //Setup
            var sourceProject = PrepareProject();

            var location = Assembly.GetExecutingAssembly().Location;
            var testDataFolder = Path.GetDirectoryName(location) + "/TestData/";
            var actualFilename = testDataFolder + @"ContactsApp.notes";
            var expectedFilename = testDataFolder + "expectedProject.notes";
            if (File.Exists(actualFilename))
            {
                File.Delete(actualFilename);
            }

            //Act
            ProjectManager.SaveToFile(sourceProject, testDataFolder);

            //Assert
            var actualFileContent = File.ReadAllText(actualFilename);
            var expectedFileContent = File.ReadAllText(expectedFilename);
            Assert.AreEqual(expectedFileContent, actualFileContent);
        }

        [Test]
        public void LoadToFile_CorrectProject_FileLoadCorrectly()
        {
            //Setup
            var sourceProject = PrepareProject();

            var location = Assembly.GetExecutingAssembly().Location;
            var testDataFolder = Path.GetDirectoryName(location) + @"\TestData\";
            var expectedFilename = testDataFolder + "\\ContactsApp.notes";

            //Act
            var actualFilename = ProjectManager.LoadFromFile(testDataFolder);
            
            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(sourceProject.ContactsList.Count, actualFilename.ContactsList.Count);
                for (int i = 0; i != sourceProject.ContactsList.Count; i++)
                {
                    Assert.AreEqual(sourceProject.ContactsList[i].Surname, actualFilename.ContactsList[i].Surname);
                    Assert.AreEqual(sourceProject.ContactsList[i].Name, actualFilename.ContactsList[i].Name);
                    Assert.AreEqual(sourceProject.ContactsList[i].Birthday, actualFilename.ContactsList[i].Birthday);
                    Assert.AreEqual(sourceProject.ContactsList[i].PhoneNumber.Number, actualFilename.ContactsList[i].PhoneNumber.Number);
                    Assert.AreEqual(sourceProject.ContactsList[i].IdVkontakte, actualFilename.ContactsList[i].IdVkontakte);
                    Assert.AreEqual(sourceProject.ContactsList[i].Email, actualFilename.ContactsList[i].Email);
                }

            });
        }

        [Test]
        public void LoadToFile_Catch()
        {
            //Setup

            var location = Assembly.GetExecutingAssembly().Location;
            var testDataFolder = Path.GetDirectoryName(location) + @"\TestData\";
            var expectedFilename = testDataFolder + "\\ContactsApp.notes";

            //Act
            var actualFilename = ProjectManager.LoadFromFile(expectedFilename);

            //Assert
            Assert.IsNotNull(actualFilename);

        }

        [Test]
        public void LoadToFile()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            var testDataFolder = Path.GetDirectoryName(location) + @"\TestData\EmptyFile\";
            ProjectManager.LoadFromFile(testDataFolder);
        }


    }
}

