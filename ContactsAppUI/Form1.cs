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
            var project = new Project();
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

         
            //Сериализация.
            Project serialize = new Project { Contacts = { Contact } };
            ProjectManager.SaveToFile(serialize, ProjectManager.path);

            //Десериализация.
            Project deserialize = ProjectManager.LoadFromFile(ProjectManager.path);
        }
    }
}
