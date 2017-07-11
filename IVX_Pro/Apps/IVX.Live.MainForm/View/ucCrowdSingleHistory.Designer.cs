namespace IVX.Live.MainForm.View
{
    partial class ucCrowdSingleHistory
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCrowdSingleHistory));
            this.playIndex = new DevComponents.DotNetBar.LabelX();
            this.trackBarEx1 = new WinFormAppUtil.Controls.TrackBarEx();
            this.stepDownBtn = new DevComponents.DotNetBar.ButtonX();
            this.playBtn = new DevComponents.DotNetBar.ButtonX();
            this.stepUpBtn = new DevComponents.DotNetBar.ButtonX();
            this.LabelTime = new DevComponents.DotNetBar.LabelX();
            this.m_singleCrowdInfo = new IVX.Live.MainForm.View.ucSingleCrowdInfo();
            this.radioFast = new System.Windows.Forms.RadioButton();
            this.radioNormal = new System.Windows.Forms.RadioButton();
            this.radioSlow = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // playIndex
            // 
            // 
            // 
            // 
            this.playIndex.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.playIndex.Dock = System.Windows.Forms.DockStyle.Left;
            this.playIndex.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.playIndex.ForeColor = System.Drawing.Color.RoyalBlue;
            this.playIndex.Location = new System.Drawing.Point(0, 0);
            this.playIndex.Name = "playIndex";
            this.playIndex.SingleLineColor = System.Drawing.SystemColors.ActiveCaption;
            this.playIndex.Size = new System.Drawing.Size(91, 44);
            this.playIndex.TabIndex = 0;
            this.playIndex.Text = "00/00";
            // 
            // trackBarEx1
            // 
            this.trackBarEx1.BackColor = System.Drawing.Color.Transparent;
            this.trackBarEx1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("trackBarEx1.BackgroundImage")));
            this.trackBarEx1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.trackBarEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackBarEx1.Location = new System.Drawing.Point(0, 509);
            this.trackBarEx1.MaxValue = ((long)(1000));
            this.trackBarEx1.Name = "trackBarEx1";
            this.trackBarEx1.Size = new System.Drawing.Size(810, 7);
            this.trackBarEx1.TabIndex = 3;
            this.trackBarEx1.Value = ((long)(0));
            this.trackBarEx1.ValueChanged += new System.EventHandler(this.trackBarEx1_ValueChanged);
            this.trackBarEx1.ValueChangedByMouse += new System.EventHandler(this.trackBarEx1_ValueChangedByMouse);
            this.trackBarEx1.Load += new System.EventHandler(this.trackBarEx1_Load);
            // 
            // stepDownBtn
            // 
            this.stepDownBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.stepDownBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.stepDownBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.stepDownBtn.Enabled = false;
            this.stepDownBtn.Image = ((System.Drawing.Image)(resources.GetObject("stepDownBtn.Image")));
            this.stepDownBtn.Location = new System.Drawing.Point(63, 7);
            this.stepDownBtn.Name = "stepDownBtn";
            this.stepDownBtn.Size = new System.Drawing.Size(34, 36);
            this.stepDownBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.stepDownBtn.TabIndex = 0;
            this.stepDownBtn.Click += new System.EventHandler(this.stepDownBtn_Click_1);
            // 
            // playBtn
            // 
            this.playBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.playBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.playBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.playBtn.Enabled = false;
            this.playBtn.Image = global::IVX.Live.MainForm.Properties.Resources.播放1;
            this.playBtn.Location = new System.Drawing.Point(23, 7);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(34, 36);
            this.playBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.playBtn.TabIndex = 0;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // stepUpBtn
            // 
            this.stepUpBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.stepUpBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.stepUpBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.stepUpBtn.Enabled = false;
            this.stepUpBtn.Image = ((System.Drawing.Image)(resources.GetObject("stepUpBtn.Image")));
            this.stepUpBtn.Location = new System.Drawing.Point(103, 7);
            this.stepUpBtn.Name = "stepUpBtn";
            this.stepUpBtn.Size = new System.Drawing.Size(34, 36);
            this.stepUpBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.stepUpBtn.TabIndex = 0;
            this.stepUpBtn.Click += new System.EventHandler(this.stepUpBtn_Click_1);
            // 
            // LabelTime
            // 
            // 
            // 
            // 
            this.LabelTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.LabelTime.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelTime.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LabelTime.Location = new System.Drawing.Point(164, 0);
            this.LabelTime.Name = "LabelTime";
            this.LabelTime.Size = new System.Drawing.Size(270, 44);
            this.LabelTime.TabIndex = 10;
            this.LabelTime.Text = "0000-00-00 00:00:00";
            // 
            // m_singleCrowdInfo
            // 
            this.m_singleCrowdInfo.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.m_singleCrowdInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_singleCrowdInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_singleCrowdInfo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_singleCrowdInfo.Location = new System.Drawing.Point(0, 0);
            this.m_singleCrowdInfo.Name = "m_singleCrowdInfo";
            this.m_singleCrowdInfo.Size = new System.Drawing.Size(810, 509);
            this.m_singleCrowdInfo.TabIndex = 0;
            this.m_singleCrowdInfo.Load += new System.EventHandler(this.m_singleCrowdInfo_Load);
            // 
            // radioFast
            // 
            this.radioFast.AutoSize = true;
            this.radioFast.Location = new System.Drawing.Point(152, 16);
            this.radioFast.Name = "radioFast";
            this.radioFast.Size = new System.Drawing.Size(71, 16);
            this.radioFast.TabIndex = 0;
            this.radioFast.Text = "快速播放";
            this.radioFast.UseVisualStyleBackColor = true;
            this.radioFast.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioNormal
            // 
            this.radioNormal.AutoSize = true;
            this.radioNormal.Checked = true;
            this.radioNormal.Location = new System.Drawing.Point(77, 16);
            this.radioNormal.Name = "radioNormal";
            this.radioNormal.Size = new System.Drawing.Size(71, 16);
            this.radioNormal.TabIndex = 0;
            this.radioNormal.TabStop = true;
            this.radioNormal.Text = "正常播放";
            this.radioNormal.UseVisualStyleBackColor = true;
            this.radioNormal.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioSlow
            // 
            this.radioSlow.AutoSize = true;
            this.radioSlow.Location = new System.Drawing.Point(3, 16);
            this.radioSlow.Name = "radioSlow";
            this.radioSlow.Size = new System.Drawing.Size(71, 16);
            this.radioSlow.TabIndex = 0;
            this.radioSlow.Text = "慢速播放";
            this.radioSlow.UseVisualStyleBackColor = true;
            this.radioSlow.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioSlow);
            this.panel2.Controls.Add(this.radioNormal);
            this.panel2.Controls.Add(this.radioFast);
            this.panel2.Location = new System.Drawing.Point(143, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(224, 44);
            this.panel2.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.stepUpBtn, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.playBtn, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.stepDownBtn, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 516);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(810, 50);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.playIndex);
            this.panel1.Controls.Add(this.LabelTime);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(373, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 44);
            this.panel1.TabIndex = 12;
            // 
            // ucCrowdSingleHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.m_singleCrowdInfo);
            this.Controls.Add(this.trackBarEx1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucCrowdSingleHistory";
            this.Size = new System.Drawing.Size(810, 566);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WinFormAppUtil.Controls.TrackBarEx trackBarEx1;
        private ucSingleCrowdInfo m_singleCrowdInfo;
        private DevComponents.DotNetBar.ButtonX stepDownBtn;
        private DevComponents.DotNetBar.ButtonX playBtn;
        private DevComponents.DotNetBar.ButtonX stepUpBtn;
        private DevComponents.DotNetBar.LabelX playIndex;
        private DevComponents.DotNetBar.LabelX LabelTime;
        private System.Windows.Forms.RadioButton radioFast;
        private System.Windows.Forms.RadioButton radioNormal;
        private System.Windows.Forms.RadioButton radioSlow;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;


    }
}
