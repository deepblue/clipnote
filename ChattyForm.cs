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
    public partial class ChattyForm : Form
    {
        private ClipboardSender clipboardSender;
        private NotifyIcon notifyIcon;

        public ChattyForm(ClipboardSender sender, NotifyIcon notifyIcon)
        {
            InitializeComponent();
            this.clipboardSender = sender;
            this.notifyIcon = notifyIcon;
        }

        public void Clear()
        {
            inputTextBox.Text = "";
        }

        private void ChattyForm_Activated(object sender, EventArgs e)
        {
            inputTextBox.Focus();
        }

        private void inputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                Close();
                SendText();
            }
        }

        private void SendText()
        {
            try
            {
                clipboardSender.SendText(inputTextBox.Text);
                notifyIcon.ShowBalloonTip(10 * 1000, "Text appended.", "Text appended at " + DateTime.Now, ToolTipIcon.Info);
            }
            catch (Exception ex)
            {
                notifyIcon.ShowBalloonTip(15 * 1000, "Error occured", ex.Message, ToolTipIcon.Warning);
            }
        }
    }
}
