// Original code created by Rinaldo

using FifaLibrary;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FifaControls
{
  public class NewIdCreator : Form
  {
    private int m_NewId = -1;
    private CmsDataSet m_CmsDataSet = new CmsDataSet();
    private IContainer components;
    private RadioButton radioAuto;
    private RadioButton radioSpacificId;
    private RadioButton radioCms;
    private TreeView treeViewCms;
    private Button buttonOK;
    private Button button1;
    private NumericUpDown numericSpecificId;
    private TextBox textCms;
    private Label labelMinMax;
    private IdObject m_NewObject;
    public string m_NewName;
    private string m_CmsFileName;
    private IdArrayList m_IdArrayList;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager resources = new ComponentResourceManager(typeof (NewIdCreator));
      this.radioAuto = new RadioButton();
      this.radioSpacificId = new RadioButton();
      this.radioCms = new RadioButton();
      this.treeViewCms = new TreeView();
      this.buttonOK = new Button();
      this.button1 = new Button();
      this.numericSpecificId = new NumericUpDown();
      this.textCms = new TextBox();
      this.labelMinMax = new Label();
      this.numericSpecificId.BeginInit();
      this.SuspendLayout();
      this.radioAuto.AutoSize = true;
      this.radioAuto.BackColor = Color.Transparent;
      this.radioAuto.BackgroundImageLayout = ImageLayout.Stretch;
      this.radioAuto.Checked = true;
      this.radioAuto.Location = new Point(0, 5);
      this.radioAuto.Name = "radioAuto";
      this.radioAuto.Padding = new Padding(10, 0, 0, 0);
      this.radioAuto.Size = new Size(82, 17);
      this.radioAuto.TabIndex = 0;
      this.radioAuto.TabStop = true;
      this.radioAuto.Text = "Automatic";
      this.radioAuto.UseVisualStyleBackColor = false;
      this.radioAuto.CheckedChanged += new EventHandler(this.radioAuto_CheckedChanged);
      this.radioSpacificId.AutoSize = true;
      this.radioSpacificId.BackColor = Color.Transparent;
      this.radioSpacificId.BackgroundImageLayout = ImageLayout.Stretch;
      this.radioSpacificId.Location = new Point(0, 31);
      this.radioSpacificId.Name = "radioSpacificId";
      this.radioSpacificId.Padding = new Padding(10, 0, 0, 0);
      this.radioSpacificId.Size = new Size(85, 17);
      this.radioSpacificId.TabIndex = 1;
      this.radioSpacificId.Text = "Specific Id";
      this.radioSpacificId.UseVisualStyleBackColor = false;
      this.radioSpacificId.CheckedChanged += new EventHandler(this.radioSpacificId_CheckedChanged);
      this.radioCms.BackColor = Color.Transparent;
      this.radioCms.BackgroundImageLayout = ImageLayout.Stretch;
      this.radioCms.Enabled = false;
      this.radioCms.Location = new Point(26, 122);
      this.radioCms.Name = "radioCms";
      this.radioCms.Padding = new Padding(10, 0, 0, 0);
      this.radioCms.Size = new Size(232, 24);
      this.radioCms.TabIndex = 2;
      this.radioCms.Text = "Browse CMS";
      this.radioCms.UseVisualStyleBackColor = false;
      this.radioCms.Visible = false;
      this.radioCms.CheckedChanged += new EventHandler(this.radioCms_CheckedChanged);
      this.treeViewCms.Location = new Point(53, 170);
      this.treeViewCms.Name = "treeViewCms";
      this.treeViewCms.Size = new Size(194, 49);
      this.treeViewCms.TabIndex = 3;
      this.treeViewCms.Visible = false;
      this.treeViewCms.AfterSelect += new TreeViewEventHandler(this.treeViewCms_AfterSelect);
      this.buttonOK.DialogResult = DialogResult.OK;
      this.buttonOK.Location = new Point(36, 66);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new Size(75, 23);
      this.buttonOK.TabIndex = 4;
      this.buttonOK.Text = "OK";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
      this.button1.DialogResult = DialogResult.Cancel;
      this.button1.Location = new Point(169, 66);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 23);
      this.button1.TabIndex = 6;
      this.button1.Text = "Cancel";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.numericSpecificId.Location = new Point(102, 29);
      this.numericSpecificId.Name = "numericSpecificId";
      this.numericSpecificId.Size = new Size(87, 20);
      this.numericSpecificId.TabIndex = 6;
      this.numericSpecificId.TextAlign = HorizontalAlignment.Center;
      this.numericSpecificId.ValueChanged += new EventHandler(this.numericSpecificId_ValueChanged);
      this.textCms.BackColor = Color.White;
      this.textCms.Location = new Point(116, 122);
      this.textCms.Name = "textCms";
      this.textCms.ReadOnly = true;
      this.textCms.Size = new Size(97, 20);
      this.textCms.TabIndex = 7;
      this.textCms.Visible = false;
      this.labelMinMax.AutoSize = true;
      this.labelMinMax.BackColor = Color.Transparent;
      this.labelMinMax.Location = new Point(195, 33);
      this.labelMinMax.Name = "labelMinMax";
      this.labelMinMax.Size = new Size(82, 13);
      this.labelMinMax.TabIndex = 8;
      this.labelMinMax.Text = "50000 - 300000";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImage = (Image) resources.GetObject("$this.BackgroundImage");
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(293, 103);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.labelMinMax);
      this.Controls.Add((Control) this.buttonOK);
      this.Controls.Add((Control) this.textCms);
      this.Controls.Add((Control) this.numericSpecificId);
      this.Controls.Add((Control) this.treeViewCms);
      this.Controls.Add((Control) this.radioCms);
      this.Controls.Add((Control) this.radioSpacificId);
      this.Controls.Add((Control) this.radioAuto);
      this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
      this.Name = "NewIdCreator";
      this.Text = "New Id Selector";
      this.numericSpecificId.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public int NewId
    {
      get
      {
        return this.m_NewId;
      }
    }

    public IdObject NewObject
    {
      get
      {
        return this.m_NewObject;
      }
    }

    public string NewName
    {
      get
      {
        return this.m_NewName;
      }
    }

    public IdArrayList IdList
    {
      set
      {
        this.m_IdArrayList = value;
        if (this.m_IdArrayList != null)
        {
          this.numericSpecificId.Minimum = (Decimal) this.m_IdArrayList.MinId;
          this.numericSpecificId.Maximum = (Decimal) this.m_IdArrayList.MaxId;
          this.labelMinMax.Text = this.m_IdArrayList.MinId.ToString() + " - " + this.m_IdArrayList.MaxId.ToString();
          if (this.numericSpecificId.Value < this.numericSpecificId.Minimum)
          {
            this.numericSpecificId.Value = this.numericSpecificId.Minimum;
          }
          else
          {
            if (!(this.numericSpecificId.Value > this.numericSpecificId.Maximum))
              return;
            this.numericSpecificId.Value = this.numericSpecificId.Maximum;
          }
        }
        else
        {
          this.numericSpecificId.Minimum = new Decimal(-1);
          this.numericSpecificId.Maximum = new Decimal(-1);
          this.numericSpecificId.Value = new Decimal(-1);
        }
      }
    }

    public NewIdCreator()
    {
      this.InitializeComponent();
      this.numericSpecificId.Enabled = this.radioSpacificId.Checked;
    }

    private void radioSpacificId_CheckedChanged(object sender, EventArgs e)
    {
      this.numericSpecificId.Enabled = this.radioSpacificId.Checked;
      if (!this.radioSpacificId.Checked)
        return;
      this.m_NewId = (int) this.numericSpecificId.Value;
      this.m_NewName = (string) null;
    }

    private void radioAuto_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radioAuto.Checked)
        return;
      this.m_NewId = -1;
      this.m_NewName = (string) null;
    }

    private void numericSpecificId_ValueChanged(object sender, EventArgs e)
    {
      if (!this.radioSpacificId.Checked)
        return;
      this.m_NewId = (int) this.numericSpecificId.Value;
      this.m_NewName = (string) null;
    }

    private void buttonOK_Click(object sender, EventArgs e)
    {
      if (this.m_IdArrayList == null)
        this.m_NewObject = (IdObject) null;
      else
        this.m_NewObject = this.m_NewId < 0 ? this.m_IdArrayList.CreateNewId() : this.m_IdArrayList.CreateNewId(this.m_NewId);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.m_NewObject = (IdObject) null;
    }

    private void radioCms_CheckedChanged(object sender, EventArgs e)
    {
      this.textCms.Enabled = this.radioCms.Checked;
      this.treeViewCms.Enabled = this.radioCms.Checked;
      if (!this.radioCms.Checked)
        return;
      this.treeViewCms_AfterSelect((object) null, (TreeViewEventArgs) null);
    }

    private void treeViewCms_AfterSelect(object sender, TreeViewEventArgs e)
    {
      TreeNode selectedNode = this.treeViewCms.SelectedNode;
      if (selectedNode == null)
      {
        this.m_NewId = -1;
        this.textCms.Text = string.Empty;
        this.m_NewName = (string) null;
      }
      else
      {
        if (selectedNode.Level != 1)
          return;
        this.m_NewId = Convert.ToInt32(this.treeViewCms.SelectedNode.Tag);
        this.textCms.Text = selectedNode.Text;
        this.m_NewName = this.textCms.Text;
      }
    }
  }
}
