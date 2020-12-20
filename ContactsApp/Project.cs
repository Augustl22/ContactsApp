using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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

        public static Project SortList(Project contacts)
        {
            if (contacts != null)
            {
                contacts.ContactsList.Sort((x, y) => String.Compare(x.Surname, y.Surname));
            }
            return contacts;
        }

        public static Project FindBySearch(Project contacts, string find)
        {
            Project searchList = new Project();
            if (contacts != null)
            {
                for (int i = 0; i < contacts.ContactsList.Count; i++)
                {
                    if (contacts.ContactsList[i].Surname.Contains(find) || contacts.ContactsList[i].Name.Contains(find))
                    {
                        searchList.ContactsList.Add(contacts.ContactsList[i]);
                    }
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