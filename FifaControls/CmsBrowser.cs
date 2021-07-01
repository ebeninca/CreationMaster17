// Original code created by Rinaldo

using FifaLibrary;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FifaControls
{
  public class CmsBrowser : Form
  {
    private int m_NewId = -1;
    private CmsDataSet m_CmsDataSet = new CmsDataSet();
    private IContainer components;
    private Panel panelBottom;
    private Button button1;
    private Button buttonOK;
    private TreeView treeViewCms;
    public string m_NewName;
    private string m_CmsFileName;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager resources = new ComponentResourceManager(typeof (CmsBrowser));
      this.panelBottom = new Panel();
      this.button1 = new Button();
      this.buttonOK = new Button();
      this.treeViewCms = new TreeView();
      this.panelBottom.SuspendLayout();
      this.SuspendLayout();
      this.panelBottom.BackgroundImage = (Image) resources.GetObject("panelBottom.BackgroundImage");
      this.panelBottom.BackgroundImageLayout = ImageLayout.Stretch;
      this.panelBottom.Controls.Add((Control) this.button1);
      this.panelBottom.Controls.Add((Control) this.buttonOK);
      this.panelBottom.Dock = DockStyle.Bottom;
      this.panelBottom.Location = new Point(0, 337);
      this.panelBottom.Name = "panelBottom";
      this.panelBottom.Size = new Size(285, 34);
      this.panelBottom.TabIndex = 6;
      this.button1.DialogResult = DialogResult.Cancel;
      this.button1.Location = new Point(169, 8);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 23);
      this.button1.TabIndex = 6;
      this.button1.Text = "Cancel";
      this.button1.UseVisualStyleBackColor = true;
      this.buttonOK.DialogResult = DialogResult.OK;
      this.buttonOK.Location = new Point(39, 8);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new Size(75, 23);
      this.buttonOK.TabIndex = 4;
      this.buttonOK.Text = "OK";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.treeViewCms.Dock = DockStyle.Fill;
      this.treeViewCms.Location = new Point(0, 0);
      this.treeViewCms.Name = "treeViewCms";
      this.treeViewCms.Size = new Size(285, 337);
      this.treeViewCms.TabIndex = 7;
      this.treeViewCms.DoubleClick += new EventHandler(this.treeViewCms_DoubleClick);
      this.treeViewCms.AfterSelect += new TreeViewEventHandler(this.treeViewCms_AfterSelect);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(285, 371);
      this.Controls.Add((Control) this.treeViewCms);
      this.Controls.Add((Control) this.panelBottom);
      this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
      this.Name = "CmsBrowser";
      this.Text = "CmsBrowser";
      this.panelBottom.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public int NewId
    {
      get
      {
        return this.m_NewId;
      }
    }

    public string NewName
    {
      get
      {
        return this.m_NewName;
      }
    }

    public string CmsFileName
    {
      set
      {
        this.m_CmsFileName = value;
        if (!File.Exists(this.m_CmsFileName))
          return;
        this.m_CmsDataSet.Tables.Clear();
        this.m_CmsDataSet.Relations.Clear();
        int num = (int) this.m_CmsDataSet.ReadXml(this.m_CmsFileName);
        this.treeViewCms.Nodes.Clear();
        string empty = string.Empty;
        TreeNode treeNode = (TreeNode) null;
        foreach (DataRow row in (InternalDataCollectionBase) this.m_CmsDataSet.Tables["CmsDataTable"].Rows)
        {
          if (row["Group"].ToString() != empty)
          {
            empty = row["Group"].ToString();
            treeNode = this.treeViewCms.Nodes.Add(empty);
          }
          treeNode.Nodes.Add(row["Name"].ToString()).Tag = row["Id"];
        }
      }
    }

    public CmsBrowser()
    {
      this.InitializeComponent();
    }

    private void treeViewCms_AfterSelect(object sender, TreeViewEventArgs e)
    {
      TreeNode selectedNode = this.treeViewCms.SelectedNode;
      if (selectedNode == null)
      {
        this.m_NewId = -1;
        this.m_NewName = (string) null;
      }
      else
      {
        if (selectedNode.Level != 1)
          return;
        this.m_NewId = Convert.ToInt32(this.treeViewCms.SelectedNode.Tag);
        this.m_NewName = selectedNode.Text;
      }
    }

    private void treeViewCms_DoubleClick(object sender, EventArgs e)
    {
      this.buttonOK.PerformClick();
    }
  }
}
