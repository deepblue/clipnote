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
        private bool requested = false;

        public LoginForm(Setting setting, MainForm form)
        {
            InitializeComponent();
            this.setting = setting;
            this.mainForm = form;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            requested = true;
            setting.Authorize();

            buttonLogin.Hide();
            buttonAuthorize.Show();

            buttonCancel.Text = "취소";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!requested)
            {
                Application.Exit();
            }
            else
            {
                Clear();
            }
        }

        public void Clear()
        {
            requested = false;
            buttonAuthorize.Hide();
            buttonLogin.Show();
            buttonCancel.Text = "종료";
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
