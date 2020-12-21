using System;
using System.Collections.Generic;
using System.Linq;

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

        public static List<Contact> SortList(List<Contact> contacts)
        {
            return contacts.OrderBy(contact => contact.Surname).ToList();
        }

        public static List<Contact> FindBySearch(List<Contact> contacts, string find)
        {
            List<Contact> returnList = new List<Contact>();
            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].Surname.Contains(find) || contacts[i].Name.Contains(find))
                {
                    returnList.Add(contacts[i]);
                }
            }

            if (returnList.Count == 0)
            {
                return returnList;
            }

            SortList(returnList);
            return returnList;
        }

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