using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class ContactForm : Form
    {
        private Contact _contact = new Contact();

        public ContactForm()
        {
            InitializeComponent();
        }

        public Contact Contact
        {
            get
            {
                return _contact;
            }

            set
            {
                _contact = (Contact)value.Clone();
                UpdateContact();
            }
        }

        private void UpdateContact()
        {
            if (_contact != null)
            {
                SurnameTextBox.Text = _contact.Surname;
                NameTextBox.Text = _contact.Name;
                BirthdayDateTimePicker.Value = _contact.Birthday;
                PhoneTextBox.Text = _contact.PhoneNumber.Number.ToString();
                EmailTextBox.Text = _contact.Email;
                IdVkTextBox.Text = _contact.IdVkontakte;
            }
        }

        private void CancleButton_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            long number;
            bool flag;
            try
            {
                flag = true;
                _contact.Surname = SurnameTextBox.Text;
                _contact.Name = NameTextBox.Text;
                _contact.Birthday = BirthdayDateTimePicker.Value;
                long.TryParse(PhoneTextBox.Text, out number);
                _contact.PhoneNumber = new PhoneNumber { Number = Convert.ToInt64(PhoneTextBox.Text) };
                _contact.Email = EmailTextBox.Text;
                _contact.IdVkontakte = IdVkTextBox.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неверный ввод данных");
                flag = false;
            }
            if (flag == true)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Surname = SurnameTextBox.Text;
                SurnameTextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                SurnameTextBox.BackColor = Color.LightSalmon;
            }
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Name = NameTextBox.Text;
                NameTextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                NameTextBox.BackColor = Color.LightSalmon;
            }
        }

        private void BirthdayDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Birthday = BirthdayDateTimePicker.Value;
            }
            catch (Exception)
            { }
        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Email = EmailTextBox.Text;
                EmailTextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                EmailTextBox.BackColor = Color.LightSalmon;
            }
        }

        private void IdVkTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.IdVkontakte = IdVkTextBox.Text;
                IdVkTextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                IdVkTextBox.BackColor = Color.LightSalmon;
            }
        }

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            long number;
            try
            {
                long.TryParse(PhoneTextBox.Text, out number);
                _contact.PhoneNumber.Number = number;
                PhoneTextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                PhoneTextBox.BackColor = Color.LightSalmon;
            }
        }
    }
}
