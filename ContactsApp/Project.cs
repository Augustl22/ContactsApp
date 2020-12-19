using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс проект
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Список контактов
        /// </summary>
        public List<Contact> ContactsList = new List<Contact>();

        public static Project BirthdayList(Project birthPeople, DateTime today)
        {
            Project birthproject = new Project();
            for (int i = 0; i < birthPeople.ContactsList.Count; i++)
            {
                if ((birthPeople.ContactsList[i].Birthday.Day == today.Day) &&
                    (birthPeople.ContactsList[i].Birthday.Month == today.Month))
                {
                    birthproject.ContactsList.Add(birthPeople.ContactsList[i]);
                }
            }
            return birthproject;
        }
    }
}