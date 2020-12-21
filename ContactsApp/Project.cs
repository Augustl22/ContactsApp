using System;
using System.Collections.Generic;

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

        public static Project SortList(Project contacts)
        {
            contacts.ContactsList.Sort((x, y) => String.Compare(x.Surname, y.Surname));
            return contacts;
        }

        public static Project FindBySearch(Project contacts, string find)
        {
            Project searchList = new Project();
            var search = Char.ToUpper(find[0]) + find.Substring(1);
            for (int i = 0; i < contacts.ContactsList.Count; i++)
            {
                if (contacts.ContactsList[i].Surname.Contains(search) || contacts.ContactsList[i].Name.Contains(search))
                {
                    searchList.ContactsList.Add(contacts.ContactsList[i]);
                }
            }
            if (searchList.ContactsList.Count == 0)
            {
                return null;
            }

            SortList(searchList);
            return searchList;
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