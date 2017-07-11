namespace WinFormAppUtil
{
    partial class ucLocalFileSystem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLocalFileSystem));
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.treeListLocalFile = new DevExpress.XtraTreeList.TreeList();
            this.colFullName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSize = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAttributes = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCheck = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLocalFile)).BeginInit();
            this.SuspendLayout();
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "Folder_Closed.png");
            this.imageCollection1.Images.SetKeyName(1, "Folder_Opened.png");
            this.imageCollection1.Images.SetKeyName(2, "File.png");
            this.imageCollection1.Images.SetKeyName(3, "Local_Disk.png");
            // 
            // treeListLocalFile
            // 
            this.treeListLocalFile.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colFullName,
            this.colName,
            this.colType,
            this.colSize,
            this.colAttributes,
            this.colCheck});
            this.treeListLocalFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListLocalFile.Location = new System.Drawing.Point(0, 0);
            this.treeListLocalFile.Name = "treeListLocalFile";
            this.treeListLocalFile.OptionsBehavior.Editable = false;
            this.treeListLocalFile.OptionsBehavior.EnableFiltering = true;
            this.treeListLocalFile.OptionsPrint.UsePrintStyles = true;
            this.treeListLocalFile.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeListLocalFile.OptionsSelection.MultiSelect = true;
            this.treeListLocalFile.SelectImageList = this.imageCollection1;
            this.treeListLocalFile.Size = new System.Drawing.Size(273, 328);
            this.treeListLocalFile.TabIndex = 4;
            this.treeListLocalFile.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeListLocalFile_MouseDoubleClick);
            this.treeListLocalFile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeListLocalFile_MouseDown);
            this.treeListLocalFile.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treeListLocalFile_MouseMove);
            this.treeListLocalFile.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeListLocalFile_MouseUp);
            // 
            // colFullName
            // 
            this.colFullName.Caption = "colFullName";
            this.colFullName.FieldName = "FullName";
            this.colFullName.Name = "colFullName";
            // 
            // colName
            // 
            this.colName.Caption = "本地文件列表";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 51;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 134;
            // 
            // colType
            // 
            this.colType.Caption = "Type";
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.Width = 117;
            // 
            // colSize
            // 
            this.colSize.Caption = "Size(Bytes)";
            this.colSize.FieldName = "Size";
            this.colSize.Name = "colSize";
            this.colSize.Width = 117;
            // 
            // colAttributes
            // 
            this.colAttributes.Caption = "colAttributes";
            this.colAttributes.FieldName = "Attributes";
            this.colAttributes.Name = "colAttributes";
            // 
            // colCheck
            // 
            this.colCheck.Caption = "colCheck";
            this.colCheck.FieldName = "Check";
            this.colCheck.Name = "colCheck";
            // 
            // ucLocalFileSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeListLocalFile);
            this.Name = "ucLocalFileSystem";
            this.Size = new System.Drawing.Size(273, 328);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLocalFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraTreeList.TreeList treeListLocalFile;

        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colType;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSize;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFullName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAttributes;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCheck;

    }
}
