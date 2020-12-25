namespace ContactsAppUI
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.YearAndAuthorLabel = new System.Windows.Forms.Label();
            this.GitHubLabel = new System.Windows.Forms.Label();
            this.AuthorNameLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.ProgramNameLabel = new System.Windows.Forms.Label();
            this.GitHubLinkLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.EmailLinkLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // YearAndAuthorLabel
            // 
            this.YearAndAuthorLabel.AutoSize = true;
            this.YearAndAuthorLabel.Location = new System.Drawing.Point(15, 292);
            this.YearAndAuthorLabel.Name = "YearAndAuthorLabel";
            this.YearAndAuthorLabel.Size = new System.Drawing.Size(120, 13);
            this.YearAndAuthorLabel.TabIndex = 9;
            this.YearAndAuthorLabel.Text = "2020 Mochalov Vladimir";
            // 
            // GitHubLabel
            // 
            this.GitHubLabel.AutoSize = true;
            this.GitHubLabel.Location = new System.Drawing.Point(15, 175);
            this.GitHubLabel.Name = "GitHubLabel";
            this.GitHubLabel.Size = new System.Drawing.Size(46, 13);
            this.GitHubLabel.TabIndex = 8;
            this.GitHubLabel.Text = "GitHub: ";
            // 
            // AuthorNameLabel
            // 
            this.AuthorNameLabel.AutoSize = true;
            this.AuthorNameLabel.Location = new System.Drawing.Point(15, 93);
            this.AuthorNameLabel.Name = "AuthorNameLabel";
            this.AuthorNameLabel.Size = new System.Drawing.Size(130, 13);
            this.AuthorNameLabel.TabIndex = 7;
            this.AuthorNameLabel.Text = "Author: Mochalov Vladimir";
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(15, 52);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(43, 13);
            this.VersionLabel.TabIndex = 6;
            this.VersionLabel.Text = "v. 1.0.0";
            // 
            // ProgramNameLabel
            // 
            this.ProgramNameLabel.AutoSize = true;
            this.ProgramNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProgramNameLabel.Location = new System.Drawing.Point(12, 9);
            this.ProgramNameLabel.Name = "ProgramNameLabel";
            this.ProgramNameLabel.Size = new System.Drawing.Size(182, 31);
            this.ProgramNameLabel.TabIndex = 5;
            this.ProgramNameLabel.Text = "ContactsApp";
            // 
            // GitHubLinkLabel
            // 
            this.GitHubLinkLabel.AutoSize = true;
            this.GitHubLinkLabel.BackColor = System.Drawing.SystemColors.Control;
            this.GitHubLinkLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GitHubLinkLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.GitHubLinkLabel.Location = new System.Drawing.Point(67, 175);
            this.GitHubLinkLabel.Name = "GitHubLinkLabel";
            this.GitHubLinkLabel.Size = new System.Drawing.Size(213, 13);
            this.GitHubLinkLabel.TabIndex = 10;
            this.GitHubLinkLabel.Text = "https://github.com/Augustl22/ContactsApp";
            this.GitHubLinkLabel.Click += new System.EventHandler(this.GitHubLinkLabel_Click);
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(15, 153);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(103, 13);
            this.EmailLabel.TabIndex = 11;
            this.EmailLabel.Text = "e-mail for feedback: ";
            // 
            // EmailLinkLabel
            // 
            this.EmailLinkLabel.AutoSize = true;
            this.EmailLinkLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.EmailLinkLabel.Location = new System.Drawing.Point(124, 153);
            this.EmailLinkLabel.Name = "EmailLinkLabel";
            this.EmailLinkLabel.Size = new System.Drawing.Size(129, 13);
            this.EmailLinkLabel.TabIndex = 12;
            this.EmailLinkLabel.Text = "mochalovv09@gmail.com";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 324);
            this.Controls.Add(this.EmailLinkLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.GitHubLinkLabel);
            this.Controls.Add(this.YearAndAuthorLabel);
            this.Controls.Add(this.GitHubLabel);
            this.Controls.Add(this.AuthorNameLabel);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.ProgramNameLabel);
            this.MaximumSize = new System.Drawing.Size(324, 363);
            this.MinimumSize = new System.Drawing.Size(324, 363);
            this.Name = "AboutForm";
            this.Text = "About";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label YearAndAuthorLabel;
        private System.Windows.Forms.Label GitHubLabel;
        private System.Windows.Forms.Label AuthorNameLabel;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label ProgramNameLabel;
        private System.Windows.Forms.Label GitHubLinkLabel;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label EmailLinkLabel;
    }
}