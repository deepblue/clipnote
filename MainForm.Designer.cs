namespace ClipNote
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.restoreClipNoteWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sendClipboardToSpringnoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showQuickInputALTF11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captureScreenALTF10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSpringnotePageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpLink = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.TextboxUrl = new System.Windows.Forms.TextBox();
            this.buttonChange = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.helpText = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.checkBoxAutorun = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabelLogout = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.systemHotkey = new ClipNote.SystemHotkey.SystemHotkey(this.components);
            this.systemHotkey1 = new ClipNote.SystemHotkey.SystemHotkey(this.components);
            this.systemHotkey2 = new ClipNote.SystemHotkey.SystemHotkey(this.components);
            this.trayMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.trayMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "ClipNote";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreClipNoteWindowToolStripMenuItem,
            this.toolStripSeparator2,
            this.sendClipboardToSpringnoteToolStripMenuItem,
            this.showQuickInputALTF11ToolStripMenuItem,
            this.captureScreenALTF10ToolStripMenuItem,
            this.openSpringnotePageToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(331, 148);
            // 
            // restoreClipNoteWindowToolStripMenuItem
            // 
            this.restoreClipNoteWindowToolStripMenuItem.Name = "restoreClipNoteWindowToolStripMenuItem";
            this.restoreClipNoteWindowToolStripMenuItem.Size = new System.Drawing.Size(330, 22);
            this.restoreClipNoteWindowToolStripMenuItem.Text = "클립노트 창 보이기";
            this.restoreClipNoteWindowToolStripMenuItem.Click += new System.EventHandler(this.restoreClipNoteWindowToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(327, 6);
            // 
            // sendClipboardToSpringnoteToolStripMenuItem
            // 
            this.sendClipboardToSpringnoteToolStripMenuItem.Name = "sendClipboardToSpringnoteToolStripMenuItem";
            this.sendClipboardToSpringnoteToolStripMenuItem.Size = new System.Drawing.Size(330, 22);
            this.sendClipboardToSpringnoteToolStripMenuItem.Text = "클립보드 내용을 스프링노트에 저장 (ALT+F12)";
            this.sendClipboardToSpringnoteToolStripMenuItem.Click += new System.EventHandler(this.sendClipboardToSpringnoteToolStripMenuItem_Click);
            // 
            // showQuickInputALTF11ToolStripMenuItem
            // 
            this.showQuickInputALTF11ToolStripMenuItem.Name = "showQuickInputALTF11ToolStripMenuItem";
            this.showQuickInputALTF11ToolStripMenuItem.Size = new System.Drawing.Size(330, 22);
            this.showQuickInputALTF11ToolStripMenuItem.Text = "빠른 메모창 열기 (ALT+F11)";
            this.showQuickInputALTF11ToolStripMenuItem.Click += new System.EventHandler(this.showQuickInputALTF11ToolStripMenuItem_Click);
            // 
            // captureScreenALTF10ToolStripMenuItem
            // 
            this.captureScreenALTF10ToolStripMenuItem.Name = "captureScreenALTF10ToolStripMenuItem";
            this.captureScreenALTF10ToolStripMenuItem.Size = new System.Drawing.Size(330, 22);
            this.captureScreenALTF10ToolStripMenuItem.Text = "화면 캡춰 (ALT+F10)";
            this.captureScreenALTF10ToolStripMenuItem.Click += new System.EventHandler(this.captureScreenALTF10ToolStripMenuItem_Click);
            // 
            // openSpringnotePageToolStripMenuItem
            // 
            this.openSpringnotePageToolStripMenuItem.Name = "openSpringnotePageToolStripMenuItem";
            this.openSpringnotePageToolStripMenuItem.Size = new System.Drawing.Size(330, 22);
            this.openSpringnotePageToolStripMenuItem.Text = "메모 페이지 열기";
            this.openSpringnotePageToolStripMenuItem.Click += new System.EventHandler(this.openSpringnotePageToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(327, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(330, 22);
            this.exitToolStripMenuItem.Text = "종료";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpLink
            // 
            this.helpLink.AutoSize = true;
            this.helpLink.Location = new System.Drawing.Point(273, 59);
            this.helpLink.Name = "helpLink";
            this.helpLink.Size = new System.Drawing.Size(53, 12);
            this.helpLink.TabIndex = 6;
            this.helpLink.TabStop = true;
            this.helpLink.Text = "도움말...";
            this.helpLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.helpLink_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "메모를 남길 페이지 URL을 적어주세요";
            // 
            // TextboxUrl
            // 
            this.TextboxUrl.Location = new System.Drawing.Point(8, 33);
            this.TextboxUrl.Name = "TextboxUrl";
            this.TextboxUrl.Size = new System.Drawing.Size(244, 21);
            this.TextboxUrl.TabIndex = 5;
            this.TextboxUrl.TextChanged += new System.EventHandler(this.TextboxUrl_TextChanged);
            // 
            // buttonChange
            // 
            this.buttonChange.Enabled = false;
            this.buttonChange.Location = new System.Drawing.Point(255, 32);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(59, 21);
            this.buttonChange.TabIndex = 9;
            this.buttonChange.Text = "변경";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "예) http://help.springnote.com/pages/6883";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonChange);
            this.groupBox1.Controls.Add(this.TextboxUrl);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 79);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Page:";
            // 
            // helpText
            // 
            this.helpText.BackColor = System.Drawing.SystemColors.Info;
            this.helpText.Location = new System.Drawing.Point(12, 12);
            this.helpText.Multiline = true;
            this.helpText.Name = "helpText";
            this.helpText.ReadOnly = true;
            this.helpText.Size = new System.Drawing.Size(320, 44);
            this.helpText.TabIndex = 5;
            this.helpText.Text = "1) ALT+F12: 클립보드 내용을 스프링노트로\r\n2) ALT+F11: 빠른 메모 입력창 열기\r\n3) ALT+F10: 화면 캡춰해서 스프링노트로" +
                "";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(257, 233);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "확인";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // checkBoxAutorun
            // 
            this.checkBoxAutorun.AutoSize = true;
            this.checkBoxAutorun.Location = new System.Drawing.Point(6, 20);
            this.checkBoxAutorun.Name = "checkBoxAutorun";
            this.checkBoxAutorun.Size = new System.Drawing.Size(156, 16);
            this.checkBoxAutorun.TabIndex = 0;
            this.checkBoxAutorun.Text = "윈도우 시작시 자동 실행";
            this.checkBoxAutorun.UseVisualStyleBackColor = true;
            this.checkBoxAutorun.CheckedChanged += new System.EventHandler(this.checkBoxAutorun_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "# 다른 계정으로 사용하시려면 ";
            // 
            // linkLabelLogout
            // 
            this.linkLabelLogout.AutoSize = true;
            this.linkLabelLogout.Location = new System.Drawing.Point(185, 156);
            this.linkLabelLogout.Name = "linkLabelLogout";
            this.linkLabelLogout.Size = new System.Drawing.Size(109, 12);
            this.linkLabelLogout.TabIndex = 12;
            this.linkLabelLogout.TabStop = true;
            this.linkLabelLogout.Text = "로그아웃 해주세요.";
            this.linkLabelLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLogout_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxAutorun);
            this.groupBox2.Location = new System.Drawing.Point(12, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 43);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "고급";
            // 
            // systemHotkey
            // 
            this.systemHotkey.Shortcut = System.Windows.Forms.Shortcut.AltF12;
            this.systemHotkey.Pressed += new System.EventHandler(this.systemHotkey_Pressed);
            // 
            // systemHotkey1
            // 
            this.systemHotkey1.Shortcut = System.Windows.Forms.Shortcut.AltF11;
            this.systemHotkey1.Pressed += new System.EventHandler(this.systemHotkey1_Pressed);
            // 
            // systemHotkey2
            // 
            this.systemHotkey2.Shortcut = System.Windows.Forms.Shortcut.AltF10;
            this.systemHotkey2.Pressed += new System.EventHandler(this.systemHotkey2_Pressed);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 261);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.linkLabelLogout);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.helpText);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.helpLink);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(352, 400);
            this.MinimumSize = new System.Drawing.Size(352, 295);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "클립노트 v0.8.1";
            this.Load += new System.EventHandler(this.MainForm_Load_1);
            this.Shown += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.trayMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem restoreClipNoteWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private ClipNote.SystemHotkey.SystemHotkey systemHotkey;
        private ClipNote.SystemHotkey.SystemHotkey systemHotkey1;
        private System.Windows.Forms.ToolStripMenuItem sendClipboardToSpringnoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showQuickInputALTF11ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem openSpringnotePageToolStripMenuItem;
        private ClipNote.SystemHotkey.SystemHotkey systemHotkey2;
        private System.Windows.Forms.ToolStripMenuItem captureScreenALTF10ToolStripMenuItem;
        private System.Windows.Forms.LinkLabel helpLink;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextboxUrl;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox helpText;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.CheckBox checkBoxAutorun;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabelLogout;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

