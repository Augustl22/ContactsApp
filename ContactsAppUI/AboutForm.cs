using System;
using System.Windows.Forms;

namespace ContactsAppUI
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void GitHubLinkLabel_Click(object sender, EventArgs e)
        {
            var url = GitHubLinkLabel.Text;
            System.Diagnostics.Process.Start(url);
        }
    }
}