using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Springnote;

namespace ClipNote
{
    public partial class MainForm : Form
    {
        private Setting setting;
        private LoginForm frmLogin;
        private ChattyForm frmChatty;
        private Regex urlPattern;
        private ClipboardSender clipboardSender;

        private bool TimeToExit = false;


        public MainForm(bool minimized)
        {
            InitializeComponent();

            this.setting = Setting.Load(Application.LocalUserAppDataPath);
            this.urlPattern = new Regex("^https?://([A-Za-z0-9-].*?).springnote.com/pages/([0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            this.clipboardSender = new ClipboardSender(this.Handle, this.setting);

            if (minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        public void Initialize()
        {
            TextboxUrl.Text = setting.pageUrl;
        }

        private void ShowLoginForm()
        {
            Hide();

            if (this.frmLogin == null)
            {
                this.frmLogin = new LoginForm(setting, this);
            }
            else
            {
                this.frmLogin.Clear();
            }

            this.frmLogin.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!this.setting.IsLoggedIn())
            {
                ShowLoginForm();
            }
            else 
            {
                Initialize();
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            Match m = urlPattern.Match(TextboxUrl.Text);
            
            if (m != Match.Empty)
            {
                string noteName = m.Groups[1].ToString();
                string pageId = m.Groups[2].ToString();

                try
                {
                    Note note = new Note(noteName, setting.GetConsumer());


                    Page page = note.FindPage(pageId);
                    DialogResult ret = MessageBox.Show("제목이 \"" + page.Title + "\"인 페이지가 맞습니까?", "ClipNote", MessageBoxButtons.YesNo);
                    if (ret == DialogResult.Yes)
                    {
                        setting.pageUrl = TextboxUrl.Text;
                        setting.pageId = pageId;
                        setting.noteName = noteName;
                        setting.Save();
                    }
                }
                catch (System.Net.WebException)
                {
                    MessageBox.Show("페이지를 읽을 수 없습니다. 잘못된 주소가 분명합니다.");
                }
            }
        }

        private void TextboxUrl_TextChanged(object sender, EventArgs e)
        {
            Match m = urlPattern.Match(TextboxUrl.Text);
            buttonChange.Enabled = (m != Match.Empty);
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (!this.Visible)
                this.Show();
            if (!this.Focus())
                this.Activate();

            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void restoreClipNoteWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon_DoubleClick(sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TimeToExit = true;
            Close();
        }

        private void helpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://mashups.springnote.com/pages/1711340");
        }

        private void systemHotkey_Pressed(object sender, EventArgs e)
        {
            try
            {
                clipboardSender.Execute();
                notifyIcon.ShowBalloonTip(10 * 1000, "Clipboard appended.", "Clipboard Item appended at " + DateTime.Now, ToolTipIcon.Info);
            }
            catch (Exception ex)
            {
                notifyIcon.ShowBalloonTip(15 * 1000, "Error occured", ex.Message, ToolTipIcon.Warning);
            }
        }

        private void systemHotkey1_Pressed(object sender, EventArgs e)
        {
            if (this.frmChatty == null)
            {
                this.frmChatty = new ChattyForm(clipboardSender, notifyIcon);
            }

            frmChatty.Clear();
            frmChatty.ShowDialog();
            frmChatty.Focus();
        }

        private void sendClipboardToSpringnoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            systemHotkey_Pressed(sender, e);
        }

        private void showQuickInputALTF11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            systemHotkey1_Pressed(sender, e);

        }

        private void openSpringnotePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(setting.pageUrl);
        }

        private void systemHotkey2_Pressed(object sender, EventArgs e)
        {
            bool visible = this.Visible;
            if(visible) 
                this.Hide();
            CaptureForm frm = new CaptureForm(this, visible, clipboardSender, notifyIcon);
            frm.Show();
            frm.Focus();
        }

        private void captureScreenALTF10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            systemHotkey2_Pressed(sender, e);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((!this.TimeToExit) && (e.CloseReason == CloseReason.UserClosing))
            {
                notifyIcon.ShowBalloonTip(10 * 1000, "ClipNote", "ClipNote has minimized here, to the System Tray as an Icon.", ToolTipIcon.Info);

                this.WindowState = FormWindowState.Minimized;
                if (this.Visible)
                    this.Hide();

                e.Cancel = true;
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.Visible && (this.WindowState == FormWindowState.Minimized))
            {
                this.Hide();
            }
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized && this.Visible)
                this.Hide();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        private void linkLabelLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            setting.ClearSession();
            TextboxUrl.Clear();
            ShowLoginForm();
        }

        private void checkBoxAutorun_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAutorun.Checked)
            {
                setting.SetAutorun(Application.ExecutablePath.ToString());
            }
            else
            {
                setting.ClearAutorun();
            }
        }
    }
}
