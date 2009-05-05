using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClipNote
{
    public partial class LoginForm : Form
    {
        private Setting setting;
        private MainForm mainForm;

        public LoginForm(Setting setting, MainForm form)
        {
            InitializeComponent();
            this.setting = setting;
            this.mainForm = form;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            setting.Authorize();

            buttonLogin.Hide();
            buttonAuthorize.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonAuthorize_Click(object sender, EventArgs e)
        {
            try
            {
                setting.GetAccessToken();
                Hide();

                mainForm.Initialize();
                mainForm.Show();
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("로그인하지 못햇습니다");
                buttonAuthorize.Hide();
                buttonLogin.Show();
                buttonLogin.Focus();
            }
        }
    }
}
