using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class MainForm : Form
    {
        private Project _project;
        private List<Contact> _sortProjectList = new List<Contact>();


        public MainForm()
        {
            InitializeComponent();

            _project = ProjectManager.LoadFromFile(ProjectManager.path);
            _sortProjectList = _project.ContactsList;
            SortListBox();
            BirthdayReminder();
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
                _sortProjectList.Add(contact);
                ContactsListBox.Items.Add(contact.Surname);
                ProjectManager.SaveToFile(_project, ProjectManager.path);
            }
            SortListBox();
            BirthdayReminder();
        }

        /// <summary>
        /// Метод изменения контакта
        /// </summary>
        private void EditContact()
        {

            var selectedViewedIndex = ContactsListBox.SelectedIndex;

            if (selectedViewedIndex == -1)
            {
                MessageBox.Show("Select the entry to edit", "No entry");
            }
            else
            {
                var selectedContact = _sortProjectList[selectedViewedIndex];
                var form = new ContactForm();
                form.Contact = selectedContact;
                var dialogResult = form.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    var updatedContact = form.Contact;
                    var ProjectIndex = _project.ContactsList.IndexOf(selectedContact);
                    _project.ContactsList.RemoveAt(ProjectIndex);
                    _sortProjectList.RemoveAt(selectedViewedIndex);
                    ContactsListBox.Items.RemoveAt(selectedViewedIndex);
                    _project.ContactsList.Insert(ProjectIndex, updatedContact);
                    _sortProjectList.Insert(selectedViewedIndex, updatedContact);
                    ContactsListBox.Items.Insert(selectedViewedIndex, updatedContact.Surname);
                    ProjectManager.SaveToFile(_project, ProjectManager.path);
                    ContactsListBox.SetSelected(ProjectIndex, true);
                    SortListBox();

                }
            }
            SortListBox();
            BirthdayReminder();
        }

        /// <summary>
        /// Метод удаления контакта
        /// </summary>
        private void RemoveContact()
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("ВSelect the entry to delete", "No entry");
            }
            else
            {
                Contact contact = _sortProjectList[selectedIndex];
                SurnameTextBox.Text = contact.Surname;
                var dialogResult = MessageBox.Show("Delete this entry?", "Confirm", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    var ProjectIndex = _project.ContactsList.IndexOf(contact);
                    _sortProjectList.RemoveAt(selectedIndex);
                    _project.ContactsList.RemoveAt(ProjectIndex);
                    ContactsListBox.Items.RemoveAt(selectedIndex);
                    ProjectManager.SaveToFile(_project, ProjectManager.path);
                }
            }
            BirthdayReminder();
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
                Contact contact = _sortProjectList[selectedIndex];
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

        public void BirthdayReminder()
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

            if (BirthdaytextBox.Text == "")
            {
                BirthpictureBox.Visible = false;
                BirthdayTodayLabel.Visible = false;
                BirthdaytextBox.Visible = false;
            }
            else
            {
                BirthdayTodayLabel.Visible = true;
                BirthdaytextBox.Visible = true;
                BirthpictureBox.Visible = true;
            }
        }

        public void SortListBox()
        {
            _sortProjectList = Project.SortList(_sortProjectList);

            ContactsListBox.Items.Clear();

            foreach (var contact in _sortProjectList)
            {
                ContactsListBox.Items.Add(contact.Surname);
            }
        }

        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            if (FindTextBox.Text == "")
            {
                _sortProjectList = _project.ContactsList;
                SortListBox();
            }
            else
            {
                _sortProjectList = _project.ContactsList;
                _sortProjectList = Project.FindBySearch(_sortProjectList, FindTextBox.Text);
                if (_sortProjectList == null)
                {
                    ContactsListBox.Items.Clear();
                }
                else
                {
                    SortListBox();
                }
            }
        }
    }
}