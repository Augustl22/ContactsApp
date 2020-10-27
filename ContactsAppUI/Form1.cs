using System;
using System.Windows.Forms;
using System.Windows;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Contact Contact = new Contact();
            Contact.Surname = textBox2.Text;
            Contact.Name = textBox3.Text;
            Contact.Birthday = dateTimePicker1.Value;
            Contact.PhoneNumber = new PhoneNumber { Number = Convert.ToInt64(textBox4.Text) };
            Contact.Email = textBox5.Text;
            Contact.IdVkontakte = textBox6.Text;

            string default_path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/ContactApp/";

            //Сериализация
            Project serialize = new Project { Contacts = { Contact } };
            ProjectManager.SaveToFile(serialize, default_path);

            //Десериализация
            Project deserialize = ProjectManager.LoadFromFile(default_path);
        }
    }
}
