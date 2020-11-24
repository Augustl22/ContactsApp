using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
