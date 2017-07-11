using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVX.DataModel;

namespace IVX.Live.MainForm.View
{
    public partial class ucTaskInfo : DevComponents.DotNetBar.ItemContainer
    {
        [Category("event")]
        public new event EventHandler Click;
        
        [Category("event")]
        public new event EventHandler DBClick;

        DevComponents.DotNetBar.LabelItem label;
        DevComponents.DotNetBar.ButtonItem image;
        DevComponents.DotNetBar.ProgressBarItem progress;
        public ucTaskInfo()
        {
            InitializeComponent();
            label = new DevComponents.DotNetBar.LabelItem();
            label.Text = "name";
            label.Width = 100;
            label.WordWrap = false;
            image = new DevComponents.DotNetBar.ButtonItem();
            //image.Name = "itemContainer";
            image.Image = Properties.Resources.bkpng;
            image.FixedSize = new System.Drawing.Size(100, 58);
            image.ImageFixedSize = new System.Drawing.Size(96, 54);
            image.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            image.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            progress = new DevComponents.DotNetBar.ProgressBarItem();
            progress.Value = 1000;
            progress.Text = "已完成";
            progress.TextVisible = true;
            progress.Maximum = 1000;
            progress.Size = new System.Drawing.Size(100, 20);
            this.SubItems.Add(label);
            this.SubItems.Add(image);
            this.SubItems.Add(progress);
            this.FixedSize = new System.Drawing.Size(100, 100);
            this.MultiLine = true;
            //image.AutoCheckOnClick = true;
            this.image.Click += new EventHandler(image_Click);
            this.image.DoubleClick += new EventHandler(image_DoubleClick);
        }

        void image_DoubleClick(object sender, EventArgs e)
        {
            if (DBClick != null)
                DBClick(this, e);
        }

        void image_Click(object sender, EventArgs e)
        {
            if (Click != null)
                Click(this, e);
        }

        public override string Text
        {
            get { return label.Text; }
            set { label.Text = value; }
        }
        public override string Tooltip
        {
            get
            {
                return image.Tooltip;
            }
            set
            {
                image.Tooltip = value;
            }
        }
        public int Progress 
        {
            get
            {
                return progress.Value;
            }
            set
            {
                progress.Value = value;
            }
        }
        private E_VDA_TASK_STATUS m_taskStat = 0;
        public E_VDA_TASK_STATUS TaskStat
        {
            get 
            {
                return m_taskStat;
            }
            set 
            {
                m_taskStat = value;
                string msg = DataModel.Constant.TaskStatusInfos.Single(item => item.Status == value).Name;
                progress.Text = msg;
            }
        }

        public uint TaskId { get; set; }
        public bool Checked
        {
            get { return image.Checked; }
            set { image.Checked = value; }
        }

    }
}
