using System;
using System.Windows.Forms;
using System.Windows;
using ContactsApp;
using System.Drawing;

namespace ContactsAppUI
{
    public partial class MainForm : Form
    {
        private Project _project;

        public MainForm()
        {
            InitializeComponent();

            _project = ProjectManager.LoadFromFile(ProjectManager.path);

            foreach (var contact in _project.ContactsList)
            {
                ContactsListBox.Items.Add(contact.Surname);
            }
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
                var Contact = form.Contact;
                _project.ContactsList.Add(Contact);
                ContactsListBox.Items.Add(Contact.Surname);
                ProjectManager.SaveToFile(_project, ProjectManager.path);
            }
        }
        
        /// <summary>
        /// Метод изменения контакта
        /// </summary>
        private void EditContact ()
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Select a contact to edit", "Contact not selected");
            }
            else
            {
                var selectedContact = _project.ContactsList[selectedIndex];
                var form = new ContactForm();
                form.Contact = selectedContact;
                var dialogResult = form.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    var updatedContact = form.Contact;
                    _project.ContactsList.RemoveAt(selectedIndex);
                    ContactsListBox.Items.RemoveAt(selectedIndex);
                    _project.ContactsList.Insert(selectedIndex, updatedContact);
                    ContactsListBox.Items.Insert(selectedIndex, updatedContact.Surname);
                    ProjectManager.SaveToFile(_project, ProjectManager.path);
                }
                
            }
        }

        /// <summary>
        /// Метод удаления контакта
        /// </summary>
        private void RemoveContact()
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Select Contact to delete", "Contact not selected");
            }
            else
            {
                Contact contact = _project.ContactsList[selectedIndex];
                SurnameTextBox.Text = contact.Surname;
                var dialogResult = MessageBox.Show("Do you really want to remove this contact: " + contact.Surname, "Confirmation", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    _project.ContactsList.RemoveAt(selectedIndex);
                    ContactsListBox.Items.RemoveAt(selectedIndex);
                    ProjectManager.SaveToFile(_project, ProjectManager.path);
                }
            }
        }

        private void AddContactButton_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex >= 0)
            {
                Contact contact = _project.ContactsList[selectedIndex];
                SurnameTextBox.Text = contact.Surname;
                NameTextBox.Text = contact.Name;
                BirthdayDateTimePicker.Value = contact.Birthday;
                PhoneTextBox.Text = contact.PhoneNumber.Number.ToString();
                EmailTextBox.Text = contact.Email;
                IdVkTextBox.Text = contact.IdVkontakte;
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
    }
}
