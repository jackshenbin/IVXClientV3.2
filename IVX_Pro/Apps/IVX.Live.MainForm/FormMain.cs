using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Globalization;
using IVX.DataModel;

namespace IVX.Live.MainForm
{
    public partial class FormMain : DevComponents.DotNetBar.RibbonForm
    {
        IVX.Live.MainForm.UILogics.ContentPageController c;

        public FormMain()
        {
            InitializeComponent();
            c = new UILogics.ContentPageController();
        }

        private void AppCommandTheme_Executed(object sender, EventArgs e)
        {
            ICommandSource source = sender as ICommandSource;
            if (source.CommandParameter is string)
            {
                eStyle style = (eStyle)Enum.Parse(typeof(eStyle), source.CommandParameter.ToString());
                // Using StyleManager change the style and color tinting
                if (style == eStyle.Metro)
                {
                    // More customization is needed for Metro
                    // Capitalize App Button and tab
                    ////////buttonFile.Text = buttonFile.Text.ToUpper();
                    foreach (BaseItem item in RibbonControl.Items)
                    {
                        // Ribbon Control may contain items other than tabs so that needs to be taken in account
                        RibbonTabItem tab = item as RibbonTabItem;
                        if (tab != null)
                            tab.Text = tab.Text.ToUpper();
                    }

                    ////////buttonFile.BackstageTabEnabled = true; // Use Backstage for Metro

                    ribbonControl1.RibbonStripFont = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    StyleManager.MetroColorGeneratorParameters = DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters.DarkBlue;

                    // Adjust size of switch button to match Metro styling
                    //////////switchButtonItem1.SwitchWidth = 12;
                    //////////switchButtonItem1.ButtonWidth = 42;
                    //////////switchButtonItem1.ButtonHeight = 19;

                    StyleManager.Style = eStyle.Metro; // BOOM
                }
                else
                {
                    // If previous style was Metro we need to update other properties as well
                    if (StyleManager.Style == eStyle.Metro)
                    {
                        ribbonControl1.RibbonStripFont = null;
                        // Fix capitalization App Button and tab
                        ////////buttonFile.Text = ToTitleCase(buttonFile.Text);
                        foreach (BaseItem item in RibbonControl.Items)
                        {
                            // Ribbon Control may contain items other than tabs so that needs to be taken in account
                            RibbonTabItem tab = item as RibbonTabItem;
                            if (tab != null)
                                tab.Text = ToTitleCase(tab.Text);
                        }
                        // Adjust size of switch button to match Office styling
                        //////switchButtonItem1.SwitchWidth = 28;
                        //////switchButtonItem1.ButtonWidth = 62;
                        //////switchButtonItem1.ButtonHeight = 20;
                    }

                    StyleManager.ChangeStyle(style, Color.Empty);
                    ////////if (style == eStyle.Office2007Black || style == eStyle.Office2007Blue || style == eStyle.Office2007Silver || style == eStyle.Office2007VistaGlass)
                    ////////    buttonFile.BackstageTabEnabled = false;
                    ////////else
                    ////////    buttonFile.BackstageTabEnabled = true;
                }
            }
            else if (source.CommandParameter is Color)
            {
                if (StyleManager.Style == eStyle.Metro)
                    StyleManager.MetroColorGeneratorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(Color.White, (Color)source.CommandParameter);
                else
                    StyleManager.ColorTint = (Color)source.CommandParameter;
            }
        }


        private string ToTitleCase(string text)
        {
            if (text.Contains("&"))
            {
                int ampPosition = text.IndexOf('&');
                text = text.Replace("&", "");
                text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
                if (ampPosition > 0)
                    text = text.Substring(0, ampPosition) + "&" + text.Substring(ampPosition);
                else
                    text = "&" + text;
                return text;
            }
            else
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        }

        private void buttonItem20_Click(object sender, EventArgs e)
        {
            IVX.Live.MainForm.UILogics.FormBase f = c.GetContentPage("FormSearch");
            f.MdiParent = this;
            f.Show();
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            IVX.Live.MainForm.UILogics.FormBase f = c.GetContentPage("FormAddFtpTask");
            f.WindowState = FormWindowState.Normal;
            f.Size = this.Size;
            f.StartPosition = FormStartPosition.CenterParent;

            f.ShowDialog();
            IVX.Live.MainForm.UILogics.FormBase f1 = c.GetContentPage("FormTaskManagement");
            f1.MdiParent = this;
            this.ActivateMdiChild(f1);
            f1.Show();

        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            List<BaseItem> removelist = new List<BaseItem>();
            foreach (BaseItem item in ribbonControl1.Items)
            {
                DevComponents.DotNetBar.RibbonTabItem p = item as DevComponents.DotNetBar.RibbonTabItem;
                if (p != null)
                {
                    removelist.Add(item);
                    ribbonControl1.Controls.Remove(p.Panel);
                }
            }
            ribbonControl1.Items.RemoveRange(removelist.ToArray());

            new System.Threading.Thread(thLogin).Start();
        }

        private void thLogin()
        {
            System.Threading.Thread.Sleep(200);
            DoLogin();  
        }
        private void DoLogin()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(DoLogin));
            }
            else
            {
                IVX.Live.MainForm.UILogics.FormBase f = c.GetContentPage("FormLogin");
                f.WindowState = FormWindowState.Normal;
                f.StartPosition = FormStartPosition.CenterParent;
                if (f.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    this.Close();
                }
                else
                {
                    BuildMenu();
                }
            }
        }
        int tapindex = 100;
        private void BuildMenu()
        {

            //ribbonControl1.Controls.Clear();
            //ribbonControl1.SuspendLayout();
            Dictionary<string, List<SystemMenu>> dt = Framework.Environment.GetSystemMenu();
            List<BaseItem> list = new List<BaseItem>();
            foreach (var item in dt)
            {
                DevComponents.DotNetBar.RibbonTabItem ribbonTabItem = new RibbonTabItem();
                DevComponents.DotNetBar.RibbonPanel ribbonPanel = new RibbonPanel();
                ribbonTabItem.Name = "ribbonTabItem"+item.Key;
                ribbonTabItem.Panel = ribbonPanel;
                ribbonTabItem.Text = item.Key;
                ribbonPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
                List<Control> barlist = new List<Control>();
                foreach (var item1 in item.Value)
                {
                    DevComponents.DotNetBar.RibbonBar ribbonBar = new RibbonBar();
                    ribbonBar.AutoOverflowEnabled = true;
                    ribbonBar.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
                    ribbonBar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
                    ribbonBar.ContainerControlProcessDialogKey = true;
                    ribbonBar.Dock = System.Windows.Forms.DockStyle.Left;
                    DevComponents.DotNetBar.ButtonItem buttonItem = new ButtonItem();
                    buttonItem.Name = "buttonItem" + item1.Title;
                    buttonItem.SubItemsExpandWidth = 14;
                    buttonItem.Text = item1.Title;
                    buttonItem.Click += new System.EventHandler(buttonItem_Click);
                    buttonItem.Tooltip = item1.Discription;
                    buttonItem.Tag = item1;
                    
                    ribbonBar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] { buttonItem });
                    ribbonBar.Location = new System.Drawing.Point(3, 0);
                    ribbonBar.Name = "ribbonBar" + item1.Title;
                    ribbonBar.Size = new System.Drawing.Size(67, 95);
                    ribbonBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
                    ribbonBar.Text = item1.Title;
                    ribbonBar.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
                    ribbonBar.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
                    ribbonBar.TabIndex = tapindex++;
                    barlist.Add(ribbonBar);
                }
                ribbonPanel.Controls.AddRange(barlist.ToArray());
                for (int i = 0; i < ribbonPanel.Controls.Count; i++)
                {
                    ribbonPanel.Controls.SetChildIndex(barlist[i], i);
                }
                ribbonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
                ribbonPanel.Location = new System.Drawing.Point(0, 53);
                ribbonPanel.Name = "ribbonPanel" + item.Key;
                ribbonPanel.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
                ribbonPanel.Size = new System.Drawing.Size(1029, 98);
                ribbonPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
                ribbonPanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
                ribbonPanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
                //ribbonPanel.BringToFront();
                list.Add(ribbonTabItem);
                ribbonControl1.Controls.Add(ribbonPanel);
            }
            ribbonControl1.Items.InsertRange(0, list.ToArray());
            ribbonControl1.SelectFirstVisibleRibbonTab();
            ribbonControl1.Refresh();
            
        }


        private void buttonItem_Click(object sender, EventArgs e)
        {
            ButtonItem bt = sender as ButtonItem;
            if (bt == null)
                return;
            SystemMenu menu = bt.Tag as SystemMenu;
            if (bt != null)
            {
                IVX.Live.MainForm.UILogics.FormBase f = c.GetContentPage(menu.URL);
                if (f == null)
                    return;
                if (menu.IsDialog)
                {
                    f.WindowState = FormWindowState.Normal;
                    f.Size = this.Size;
                    f.StartPosition = FormStartPosition.CenterParent;
                    f.ShowDialog();
                }
                else
                {
                    f.MdiParent = this;
                    this.ActivateMdiChild(f);
                    f.Show();
                }
                if (!string.IsNullOrEmpty(menu.ParentURL))
                {
                    IVX.Live.MainForm.UILogics.FormBase f1 = c.GetContentPage(menu.ParentURL);
                    f1.MdiParent = this;
                    this.ActivateMdiChild(f1);
                    f1.Show();
                    f1.UpdateUI();
                }
            }
        }


        private void buttonItem2_Click(object sender, EventArgs e)
        {
            IVX.Live.MainForm.UILogics.FormBase f = c.GetContentPage("FormAddLocalTask");
            f.WindowState = FormWindowState.Normal;
            f.Size = this.Size;
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
            IVX.Live.MainForm.UILogics.FormBase f1 = c.GetContentPage("FormTaskManagement");
            f1.MdiParent = this;
            this.ActivateMdiChild(f1);
            f1.Show();

        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            IVX.Live.MainForm.UILogics.FormBase f = c.GetContentPage("FormTaskManagement");
            f.MdiParent = this;
            f.Show();

        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            IVX.Live.MainForm.UILogics.FormBase f = c.GetContentPage("FormAddPlatTask");
            f.WindowState = FormWindowState.Normal;
            f.Dock = DockStyle.None;
            f.Size = this.Size;
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
            IVX.Live.MainForm.UILogics.FormBase f1 = c.GetContentPage("FormTaskManagement");
            f1.MdiParent = this;
            this.ActivateMdiChild(f1);
            f1.Show();

        }

    }
}
