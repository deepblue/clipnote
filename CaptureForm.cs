// This file is GuyThiebaut's work and licensed under The Code Project Open License (CPOL) 
// Thank you~
// http://www.codeproject.com/KB/cs/TeboScreen.aspx 

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ClipNote
    {

    public partial class CaptureForm : Form
        {
        #region:::::::::::::::::::::::::::::::::::::::::::Form level declarations:::::::::::::::::::::::::::::::::::::::::::
        public bool LeftButtonDown = false;

        public Point ClickPoint = new Point();
        public Point CurrentTopLeft = new Point();
        public Point CurrentBottomRight = new Point();

        Graphics g;
        Pen MyPen = new Pen(Color.Blue, 1);
        Pen EraserPen = new Pen(Color.FromArgb(255, 255, 192), 1);

        Form MyParentForm;
        bool ParantFormVisible;
        ClipboardSender clipboardSender;
        NotifyIcon notifyIcon;
        #endregion

        #region:::::::::::::::::::::::::::::::::::::::::::Mouse Event Handlers & Drawing Initialization:::::::::::::::::::::::::::::::::::::::::::
        public CaptureForm(Form frm, bool visible, ClipboardSender clipboardSender, NotifyIcon notifyIcon)
            {

            InitializeComponent();
            this.MouseDown += new MouseEventHandler(mouse_Click);
            this.MouseUp += new MouseEventHandler(mouse_Up);
            this.MouseMove += new MouseEventHandler(mouse_Move);
            MyPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            g = this.CreateGraphics();

            MyParentForm = frm;
            ParantFormVisible = visible;
            this.clipboardSender = clipboardSender;
            this.notifyIcon = notifyIcon;
            }
        #endregion

        #region:::::::::::::::::::::::::::::::::::::::::::Exit Button:::::::::::::::::::::::::::::::::::::::::::
        private void button1_Click(object sender, EventArgs e)
            {
            Close();
            }
        #endregion
        #region:::::::::::::::::::::::::::::::::::::::::::Mouse Buttons:::::::::::::::::::::::::::::::::::::::::::
        private void mouse_Click(object sender, MouseEventArgs e)
            {
            g.Clear(Color.FromArgb(255, 255, 192));
            LeftButtonDown = true;
            ClickPoint = new Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y);
            }

        private void mouse_Up(object sender, MouseEventArgs e)
        {
            LeftButtonDown = false;
            this.Hide();

            string tempFilename = System.IO.Path.GetTempPath() + "ScreenFromClipNote.png";
            if (!SaveScreen(tempFilename))
                return;

            DialogResult ret = MessageBox.Show("선택한 영역을 저장하시겠습니까?", "ClipNote", MessageBoxButtons.YesNo);
            if (ret == DialogResult.Yes)
            {
                try
                {
                    clipboardSender.SendImage(tempFilename);
                    notifyIcon.ShowBalloonTip(10 * 1000, "Screenshot appended.", "Screenshot appended at " + DateTime.Now, ToolTipIcon.Info);
                }
                catch (Exception ex)
                {
                    notifyIcon.ShowBalloonTip(15 * 1000, "Error occured", ex.Message, ToolTipIcon.Warning);
                }
            }

            if(ParantFormVisible)
            {
                MyParentForm.Show();
            }
        }
        #endregion

        #region:::::::::::::::::::::::::::::::::::::::::::Drawing the rectangular selection window:::::::::::::::::::::::::::::::::::::::::::
        private void mouse_Move(object sender, MouseEventArgs e)
            {

            //Resize (actually delete then re-draw) the rectangle if the left mouse button is held down
            if (LeftButtonDown)
                {

                //Erase the previous rectangle
                g.DrawRectangle(EraserPen, CurrentTopLeft.X, CurrentTopLeft.Y, CurrentBottomRight.X - CurrentTopLeft.X, CurrentBottomRight.Y - CurrentTopLeft.Y);

                //Calculate X Coordinates
                if (Cursor.Position.X < ClickPoint.X)
                    {
                    CurrentTopLeft.X = Cursor.Position.X;
                    CurrentBottomRight.X = ClickPoint.X;
                    }
                else
                    {
                    CurrentTopLeft.X = ClickPoint.X;
                    CurrentBottomRight.X = Cursor.Position.X;
                    }

                //Calculate Y Coordinates
                if (Cursor.Position.Y < ClickPoint.Y)
                    {
                    CurrentTopLeft.Y = Cursor.Position.Y;
                    CurrentBottomRight.Y = ClickPoint.Y;
                    }
                else
                    {
                    CurrentTopLeft.Y = ClickPoint.Y;
                    CurrentBottomRight.Y = Cursor.Position.Y;
                    }

                //Draw a new rectangle
                g.DrawRectangle(MyPen, CurrentTopLeft.X, CurrentTopLeft.Y, CurrentBottomRight.X - CurrentTopLeft.X, CurrentBottomRight.Y - CurrentTopLeft.Y);

                }

            }
        #endregion

        #region:::::::::::::::::::::::::::::::::::::::::::SaveScreen:::::::::::::::::::::::::::::::::::::::::::
        private bool SaveScreen(string path)
        {

            Point StartPoint = new Point(CurrentTopLeft.X, CurrentTopLeft.Y);
            Rectangle bounds = new Rectangle(CurrentTopLeft.X, CurrentTopLeft.Y, CurrentBottomRight.X - CurrentTopLeft.X, CurrentBottomRight.Y - CurrentTopLeft.Y);
            if (bounds.Width > 0 && bounds.Height > 0)
            {
                CaptureImage(StartPoint, Point.Empty, bounds, path);
                return true;
            }
            return false;
        }

        private void CaptureImage(Point SourcePoint, Point DestinationPoint, Rectangle SelectionRectangle, string FilePath)
        {
            using (Bitmap bitmap = new Bitmap(SelectionRectangle.Width, SelectionRectangle.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(SourcePoint, DestinationPoint, SelectionRectangle.Size);
                }
                bitmap.Save(FilePath, ImageFormat.Png);
            }
        }
        #endregion

        }
    }