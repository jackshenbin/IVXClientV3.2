using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace IVX.Live.MainForm.UILogics
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public class FormBase : DevComponents.DotNetBar.Office2007Form
    {
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private bool isMove = false;
		private PictureBox pictureBox3;
        private DevComponents.DotNetBar.Controls.Line line1;
        private DevComponents.DotNetBar.Controls.Line line2;
        private DevComponents.DotNetBar.Controls.Line line3;
		private DevComponents.DotNetBar.Controls.Line line4;
		private DevComponents.DotNetBar.Bar bar1;
        private System.Drawing.Point startPoint = new System.Drawing.Point();

        Rectangle lastWinRect = new Rectangle();
        FormWindowState m_WindowState = FormWindowState.Normal;
        public new FormWindowState WindowState
        {
            get { return FormBorderStyle == System.Windows.Forms.FormBorderStyle.None ? m_WindowState : base.WindowState; }
            set
            {
                if (FormBorderStyle == System.Windows.Forms.FormBorderStyle.None)
                {
                    switch (value)
                    {
                        case FormWindowState.Maximized:
                            Rectangle newrect = Screen.GetWorkingArea(MousePosition);
                            if (newrect != new Rectangle(this.Location, this.Size))
                                lastWinRect = new Rectangle(this.Location, this.Size);
                            this.Location = newrect.Location;
                            this.Size = newrect.Size;
                            pictureBox3.BringToFront();
                            bar1.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.None;
                            break;
                        case FormWindowState.Minimized:
                            base.WindowState = FormWindowState.Minimized;
                            break;
                        case FormWindowState.Normal:
                            this.Location = lastWinRect.Location;
                            this.Size = lastWinRect.Size;
                            pictureBox2.BringToFront();
                            if (pictureBox4.Visible)
                                bar1.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.ResizeHandle;

                            break;
                        default:
                            break;
                    }
                    m_WindowState = value;
                }
                else
                    base.WindowState = value;
            }
        }



        public bool ShowStatusBar { get { return bar1.Visible; } set { bar1.Visible = value; } }
        public FormBase()
            : base()
        {
            InitializeComponent();
            lastWinRect = new Rectangle(this.Location, this.Size);

            this.EnableGlass = false;
            if ((Program.PRODUCT_TYPE & Framework.Environment.E_PRODUCT_TYPE.NO_LOGO) > 0)
            {
                Assembly asm = Assembly.GetExecutingAssembly();

                string customization1 = Path.Combine(Directory.GetParent(asm.Location).FullName, "custom.png");
                string customization2 = Path.Combine(Directory.GetParent(asm.Location).FullName, "custom.jpg");
                string customization3 = Path.Combine(Directory.GetParent(asm.Location).FullName, "custom.bmp");
                if (System.IO.File.Exists(customization1))
                {
                    panelEx2.Style.BackgroundImage = new System.Drawing.Bitmap(customization1);
                }
                else if (System.IO.File.Exists(customization2))
                {
                    panelEx2.Style.BackgroundImage = new System.Drawing.Bitmap(customization2);
                }
                else if (System.IO.File.Exists(customization3))
                {
                    panelEx2.Style.BackgroundImage = new System.Drawing.Bitmap(customization3);
                }
                else
                {
                    panelEx2.Style.BackgroundImage = null;
                    labelX1.Left -= panelEx2.Width;
                }
            }
            
        }



        public virtual void UpdateUI() 
        {
            throw new NotImplementedException();

        }
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                labelX1.Text= base.Text= value;
            }
        }
        public virtual void Clear()
        {
            throw new NotImplementedException();
        }

        public virtual void DoAction(object action)
        {
            throw new NotImplementedException();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBase));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.line2 = new DevComponents.DotNetBar.Controls.Line();
            this.line3 = new DevComponents.DotNetBar.Controls.Line();
            this.line4 = new DevComponents.DotNetBar.Controls.Line();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelEx1.SuspendLayout();
            this.panelEx3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.ButtonShadow;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.panelEx3);
            this.panelEx1.Controls.Add(this.panelEx2);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(1, 1);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(865, 43);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.DimGray;
            this.panelEx1.Style.BackColor2.Color = System.Drawing.Color.LightGray;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 1;
            this.panelEx1.DoubleClick += new System.EventHandler(this.panelEx1_DoubleClick);
            this.panelEx1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panelEx1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panelEx1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // labelX1
            // 
            this.labelX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelX1.Location = new System.Drawing.Point(92, 10);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(633, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.DoubleClick += new System.EventHandler(this.panelEx1_DoubleClick);
            this.labelX1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.labelX1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.labelX1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.pictureBox2);
            this.panelEx3.Controls.Add(this.pictureBox3);
            this.panelEx3.Controls.Add(this.pictureBox4);
            this.panelEx3.Controls.Add(this.pictureBox1);
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelEx3.Location = new System.Drawing.Point(763, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(102, 43);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.Color = System.Drawing.Color.DimGray;
            this.panelEx3.Style.BackColor2.Color = System.Drawing.Color.LightGray;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 3;
            this.panelEx3.DoubleClick += new System.EventHandler(this.panelEx1_DoubleClick);
            this.panelEx3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panelEx3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panelEx3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelEx2.Location = new System.Drawing.Point(0, 0);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(82, 43);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.Color = System.Drawing.Color.DimGray;
            this.panelEx2.Style.BackColor2.Color = System.Drawing.Color.LightGray;
            this.panelEx2.Style.BackgroundImage = global::IVX.Live.MainForm.Properties.Resources.bocom;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 2;
            this.panelEx2.DoubleClick += new System.EventHandler(this.panelEx2_DoubleClick);
            this.panelEx2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panelEx2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panelEx2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // line1
            // 
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.line1.Location = new System.Drawing.Point(0, 0);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(867, 1);
            this.line1.TabIndex = 6;
            this.line1.Text = "line1";
            // 
            // line2
            // 
            this.line2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.line2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.line2.Location = new System.Drawing.Point(0, 694);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(867, 1);
            this.line2.TabIndex = 6;
            this.line2.Text = "line1";
            // 
            // line3
            // 
            this.line3.Dock = System.Windows.Forms.DockStyle.Left;
            this.line3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.line3.Location = new System.Drawing.Point(0, 1);
            this.line3.Name = "line3";
            this.line3.Size = new System.Drawing.Size(1, 667);
            this.line3.TabIndex = 6;
            this.line3.Text = "line1";
            this.line3.VerticalLine = true;
            // 
            // line4
            // 
            this.line4.Dock = System.Windows.Forms.DockStyle.Right;
            this.line4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.line4.Location = new System.Drawing.Point(866, 1);
            this.line4.Name = "line4";
            this.line4.Size = new System.Drawing.Size(1, 667);
            this.line4.TabIndex = 6;
            this.line4.Text = "line1";
            this.line4.VerticalLine = true;
            // 
            // bar1
            // 
            this.bar1.AccessibleDescription = "DotNetBar Bar (bar1)";
            this.bar1.AccessibleName = "DotNetBar Bar";
            this.bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.StatusBar;
            this.bar1.AntiAlias = true;
            this.bar1.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.ResizeHandle;
            this.bar1.Location = new System.Drawing.Point(0, 668);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(867, 26);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 5;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            this.bar1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::IVX.Live.MainForm.Properties.Resources.最大化;
            this.pictureBox2.Location = new System.Drawing.Point(36, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 21);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::IVX.Live.MainForm.Properties.Resources.窗口化;
            this.pictureBox3.Location = new System.Drawing.Point(36, 11);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 21);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::IVX.Live.MainForm.Properties.Resources.最小化;
            this.pictureBox4.Location = new System.Drawing.Point(6, 11);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(30, 21);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::IVX.Live.MainForm.Properties.Resources.关闭;
            this.pictureBox1.Location = new System.Drawing.Point(66, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FormBase
            // 
            this.ClientSize = new System.Drawing.Size(867, 695);
            this.ControlBox = false;
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.line4);
            this.Controls.Add(this.line3);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.line2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "FormBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelEx1.ResumeLayout(false);
            this.panelEx3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        public void UseMdiDefaultWindow(bool stat)
        {
            panelEx1.Visible = !stat;
            FormBorderStyle =stat?  System.Windows.Forms.FormBorderStyle.Sizable: System.Windows.Forms.FormBorderStyle.None;
            ControlBox = stat;
            ShowStatusBar = !stat;
            if (stat)
            {
                line1.Visible = line2.Visible = line3.Visible = line4.Visible = false; 
            }
        }
        public void SetWindowState(FormWindowState stat)
        {
            if (stat == FormWindowState.Normal)
                pictureBox3.BringToFront();
            else
                pictureBox2.BringToFront();
        }
        public void SetWindowSizeable(bool stat)
		{
			if (!stat) 
			{
				bar1.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.None;
			}
			pictureBox2.Visible = pictureBox3.Visible = pictureBox4.Visible = stat;
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox2.BringToFront();
            this.WindowState = FormWindowState.Normal;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox3.BringToFront();
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            startPoint = e.Location;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false; startPoint = new System.Drawing.Point();
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove)
            {
                int x = e.Location.X - startPoint.X;
                int y = e.Location.Y - startPoint.Y;
                this.Location = new System.Drawing.Point(this.Location.X + x, this.Location.Y + y);
            }
        }

        private void panelEx1_DoubleClick(object sender, EventArgs e)
        {
            if ((pictureBox3.Visible ==false )&&( pictureBox2.Visible == false))
                return;

            if (this.WindowState == FormWindowState.Maximized)
            {
                pictureBox2.BringToFront();
                this.WindowState = FormWindowState.Normal;

            }
            else
            {
                pictureBox3.BringToFront();
                this.WindowState = FormWindowState.Maximized;

            }
        }

        private void panelEx2_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                //System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle, System.Drawing.Color.White, BackColor, System.Drawing.Drawing2D.LinearGradientMode.Vertical);
                //this.CreateGraphics().FillRegion(brush,Region);
                base.OnPaint(e);
            }
            catch
            { this.Invalidate(); }
		}
    }

}
