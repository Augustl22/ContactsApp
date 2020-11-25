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

        private void CancelButton_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.Cancel;
            this.Close();
        }
        /// <summary>
        /// Кнопка OK при добавление контакта
        /// </summary>
        private void OKButton_Click(object sender, EventArgs e)
        {
            long number;
            bool HasError;
            try
            {
                HasError = false;
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
                MessageBox.Show(ex.Message, "Invalid data entry");
                HasError = true;
            }
            if (HasError == false)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        /// <summary>
        /// Считывание фамилии с textbox'a и выделение, если неправильный ввод
        /// </summary>
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
        /// <summary>
        /// Считывание имени с textbox'a и выделение, если неправильный ввод
        /// </summary>
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
        /// <summary>
        /// Считывание даты дня рождения с DateTimePicker'а
        /// </summary>
        private void BirthdayDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Birthday = BirthdayDateTimePicker.Value;
            }
            catch (Exception)
            { }
        }
        /// <summary>
        /// Считывание e-mail с textbox'a и выделение, если неправильный ввод
        /// </summary>
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
        /// <summary>
        /// Считывание IdVk с textbox'a и выделение, если неправильный ввод
        /// </summary>
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
        /// <summary>
        /// Считывание номера телефона с textbox'a и выделение, если неправильный ввод
        /// </summary>
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
