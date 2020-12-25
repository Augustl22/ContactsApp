using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Список контактов в файле
        /// </summary>
        private Project _project;
        
        /// <summary>
        /// Отображаемый список контактов
        /// </summary>
        private List<Contact> _displayedContacts = new List<Contact>();

        /// <summary>
        /// Главное окто приложения
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            _project = ProjectManager.LoadFromFile(ProjectManager.path);
            _displayedContacts = _project.ContactsList;
            SortListBox();
            ShowBirthdayReminder();
        }

        /// <summary>
        /// Метод добавления контакта
        /// </summary>
        private void AddContact()
        {
            var form = new ContactForm();
            var dialogResult = form.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                var contact = form.Contact;
                _project.ContactsList.Add(contact);
                _displayedContacts.Add(contact);
                ContactsListBox.Items.Add(contact.Surname);
                ProjectManager.SaveToFile(_project, ProjectManager.path);
                SortListBox();
                var viewContact = _displayedContacts.IndexOf(contact);
                ContactsListBox.SetSelected(viewContact, true);
            }
            ShowBirthdayReminder();
        }

        /// <summary>
        /// Метод изменения контакта
        /// </summary>
        private void EditContact()
        {

            var selectedIndex = ContactsListBox.SelectedIndex;

            if (selectedIndex == -1)
            {
                MessageBox.Show("Select a contact to edit", "Contact not selected");
            }
            else
            {
                var selectedContact = _displayedContacts[selectedIndex];
                var form = new ContactForm();
                form.Contact = selectedContact;
                var dialogResult = form.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    var updatedContact = form.Contact;
                    var projectIndex = _project.ContactsList.IndexOf(selectedContact);
                    _project.ContactsList.RemoveAt(projectIndex);
                    _displayedContacts.RemoveAt(selectedIndex);
                    ContactsListBox.Items.RemoveAt(selectedIndex);
                    _project.ContactsList.Insert(projectIndex, updatedContact);
                    _displayedContacts.Insert(selectedIndex, updatedContact);
                    ContactsListBox.Items.Insert(selectedIndex, updatedContact.Surname);
                    FindTextBox.Clear();
                    ProjectManager.SaveToFile(_project, ProjectManager.path);
                    SortListBox();
                    var viewContact = _displayedContacts.IndexOf(updatedContact);
                    ContactsListBox.SetSelected(viewContact, true);

                }
            }
            ShowBirthdayReminder();
        }

        /// <summary>
        /// Метод удаления контакта
        /// </summary>
        private void RemoveContact()
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Select the entry to delete", "No entry");
            }
            else
            {
                Contact contact = _displayedContacts[selectedIndex];
                SurnameTextBox.Text = contact.Surname;
                var dialogResult = MessageBox.Show("Do you really want to remove this contact: " + contact.Surname, "Confirmation", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    var ProjectIndex = _project.ContactsList.IndexOf(contact);
                    _displayedContacts.RemoveAt(selectedIndex);
                    _project.ContactsList.RemoveAt(ProjectIndex);
                    ContactsListBox.Items.RemoveAt(selectedIndex);
                    ProjectManager.SaveToFile(_project, ProjectManager.path);
                }
            }
            ShowBirthdayReminder();
        }

        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex >= 0)
            {
                Contact contact = _displayedContacts[selectedIndex];
                ChangeSelectContact(contact);
            }
            else
            {
                SurnameTextBox.Text = "";
                NameTextBox.Text = "";
                BirthdayDateTimePicker.Value = DateTime.Today;
                PhoneTextBox.Text = "";
                EmailTextBox.Text = "";
                IdVkTextBox.Text = "";
            }
        }
        private void ChangeSelectContact(Contact contact)
        {
            SurnameTextBox.Text = contact.Surname;
            NameTextBox.Text = contact.Name;
            BirthdayDateTimePicker.Value = contact.Birthday;
            PhoneTextBox.Text = contact.PhoneNumber.Number.ToString();
            EmailTextBox.Text = contact.Email;
            IdVkTextBox.Text = contact.IdVkontakte;
        }

        private void ShowBirthdayReminder()
        {
            BirthdaytextBox.Clear();
            Project birthPeople = Project.BirthdayList(_project, DateTime.Today);
            for (int i = 0; i != birthPeople.ContactsList.Count; i++)
            {
                BirthdaytextBox.Text = BirthdaytextBox.Text + birthPeople.ContactsList[i].Surname;
                if (i + 1 == birthPeople.ContactsList.Count)
                {
                    BirthdaytextBox.Text = BirthdaytextBox.Text + ".";
                }
                else
                {
                    BirthdaytextBox.Text = BirthdaytextBox.Text + ", ";
                }
            }

            var isVible = BirthdaytextBox.Text == "";

            BirthdayTodayLabel.Visible = !isVible;
            BirthdaytextBox.Visible = !isVible;
            BirthpictureBox.Visible = !isVible;

        }

        private void SortListBox()
        {

            _displayedContacts = Project.SortList(_displayedContacts);

            ContactsListBox.Items.Clear();

            foreach (var contact in _displayedContacts)
            {
                ContactsListBox.Items.Add(contact.Surname);
            }
        }

        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            if (FindTextBox.Text == "")
            {
                _displayedContacts = _project.ContactsList;
                SortListBox();
            }
            else
            {
                _displayedContacts = _project.ContactsList;
                _displayedContacts = Project.FindBySearch(_displayedContacts, FindTextBox.Text);
                if (_displayedContacts == null)
                {
                    ContactsListBox.Items.Clear();
                }
                else
                {
                    SortListBox();
                }
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        private void EditContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        private void RemoveContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveContact();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AboutForm();
            form.Show();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                var form = new AboutForm();
                form.Show();
            }
        }

        private void EditContactButton_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        private void RemoveContactButton_Click(object sender, EventArgs e)
        {
            RemoveContact();
        }

        private void AddContactButton_Click(object sender, EventArgs e)
        {
            AddContact();
        }
    }
}