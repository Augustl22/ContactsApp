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
            this.Text = "ContactsApp";
            this.Size = new Size(660, 451);
            _project = ProjectManager.LoadFromFile(ProjectManager.path);
            if (_project != null)
            {
                int i = 0;
                while (i != _project.ContactsList.Count)
                {
                    ContactsListBox.Items.Add(_project.ContactsList[i].Surname);
                    i++;
                }
            }
            else
            {
                _project = new Project();
            }
        }

        private void AddContact ()
        {
            var newForm = new ContactForm();
            var i = newForm.ShowDialog();
            if (i == DialogResult.OK)
            {
                var Contact = newForm.Contact;
                _project.ContactsList.Add(Contact);
                for (int k = 0; k != _project.ContactsList.Count - 1; k++)
                {
                    ContactsListBox.Items.RemoveAt(0);
                }
                for (int k = 0; k != _project.ContactsList.Count; k++)
                {
                    ContactsListBox.Items.Add(_project.ContactsList[k].Surname);
                }
                ProjectManager.SaveToFile(_project, ProjectManager.path);
            }
        }

        private void EditContact ()
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Выберите запись для редактирования", "Не выбрана запись");
            }
            else
            {

                var selectedContact = _project.ContactsList[selectedIndex];
                var newForm = new ContactForm();
                newForm.Contact = selectedContact;
                var i = newForm.ShowDialog();
                if (i == DialogResult.OK)
                {
                    var updatedContact = newForm.Contact;
                    _project.ContactsList.Insert(selectedIndex, updatedContact);
                    ContactsListBox.Items.Insert(selectedIndex, updatedContact.Surname);
                    _project.ContactsList.RemoveAt(selectedIndex + 1);
                    ContactsListBox.Items.RemoveAt(selectedIndex + 1);

                    for (int k = 0; k != _project.ContactsList.Count; k++)
                    {
                        ContactsListBox.Items.RemoveAt(0);
                    }
                    for (int k = 0; k != _project.ContactsList.Count; k++)
                    {
                        ContactsListBox.Items.Add(_project.ContactsList[k].Surname);
                    }
                    ProjectManager.SaveToFile(_project, ProjectManager.path);
                }
            }
        }

        private void RemoveContact()
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Выберите запись для удаления", "Не выбрана запись");
            }
            else
            {
                Contact contact = _project.ContactsList[selectedIndex];
                SurnameTextBox.Text = contact.Surname;
                var i = MessageBox.Show("Do you really want to remove this contact: " + contact.Surname, "Подтверждение", MessageBoxButtons.OKCancel);
                if (i == DialogResult.OK)
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
            var newForm = new AboutForm();
            newForm.Show();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                var newForm = new AboutForm();
                newForm.Show();
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
