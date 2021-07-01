// Original code created by Rinaldo

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace FifaLibrary
{
  public class UserOptions : Form
  {
    public bool m_AutoExportFolder = true;
    public bool m_SaveDatabase = true;
    public bool m_SaveGui = true;
    public bool m_SaveZdata = true;
    public bool m_AutoZdata = true;
    public bool m_SaveZdataInFolder = true;
    public bool m_SaveGuiInFolder = true;
    private string m_XmlFileName;
    public string m_ExportFolder;
    public bool m_SpecificZdata;
    public int m_ZdataNumber;
    public bool m_SaveGuiInArchive;
    private IContainer components;
    private TextBox textExportFolder;
    private Button buttonBrowseExportFolder;
    private ToolTip toolTip;
    private CheckBox checkSaveDb;
    private CheckBox checkSaveZdata;
    private CheckBox checkSaveGui;
    private RadioButton radioAutoZdata;
    private RadioButton radioSpecificZdata;
    private NumericUpDown numericZdata;
    private GroupBox groupZdataSelection;
    private GroupBox groupAllowSaving;
    private GroupBox groupGuiSaveOptions;
    private RadioButton radioGuiSaveFolder;
    private RadioButton radioGuiSaveArchive;
    private GroupBox groupExportFolde;
    private Button buttonCancel;
    private Button buttonOK;
    private CheckBox checkAutoExportFolder;
    private Options optionsSet;
    private RadioButton radioZdataSaveFolder;

    public UserOptions()
    {
      this.InitializeComponent();
      this.m_XmlFileName = Environment.CurrentDirectory + "\\Options.xml";
      if (!File.Exists(this.m_XmlFileName))
        return;
      int num = (int) this.optionsSet.ReadXml(this.m_XmlFileName);
      this.LoadOptions();
    }

    public DialogResult ShowOptions()
    {
      this.LoadOptions();
      return this.ShowDialog();
    }

    private void LoadOptions()
    {
      for (int index = 0; index < this.optionsSet.DataTableOpt.Count; ++index)
      {
        string option = this.optionsSet.DataTableOpt[index].Option;
        string str1 = this.optionsSet.DataTableOpt[index].Value;
        int num;
        try
        {
          num = Convert.ToInt32(str1);
        }
        catch
        {
          num = 0;
        }
        bool flag = num != 0;
        string str2 = this.optionsSet.DataTableOpt[index].Default;
        if (option == "ExportFolderAuto")
        {
          this.checkAutoExportFolder.Checked = flag;
          this.m_AutoExportFolder = flag;
          this.textExportFolder.Enabled = !flag;
          this.buttonBrowseExportFolder.Enabled = !flag;
        }
        else if (option == "ExportFolder")
        {
          this.textExportFolder.Text = str1;
          this.m_ExportFolder = str1;
        }
        else if (option == "DatabaseEditing")
        {
          this.checkSaveDb.Checked = flag;
          this.m_SaveDatabase = flag;
        }
        else if (option == "ZdataEditing")
        {
          this.checkSaveZdata.Checked = flag;
          this.m_SaveZdata = flag;
        }
        else if (option == "GuiEditing")
        {
          this.checkSaveGui.Checked = flag;
          this.m_SaveGui = flag;
        }
        else if (option == "AutoZdata")
        {
          this.radioAutoZdata.Checked = flag;
          this.m_AutoZdata = flag;
          if (this.m_AutoZdata)
          {
            this.m_SpecificZdata = false;
            this.m_SaveZdataInFolder = false;
          }
          this.numericZdata.Enabled = this.m_SpecificZdata;
        }
        else if (option == "SpecificZdata")
        {
          this.radioSpecificZdata.Checked = flag;
          this.m_SpecificZdata = flag;
          if (this.m_SpecificZdata)
          {
            this.m_AutoZdata = false;
            this.m_SaveZdataInFolder = false;
          }
          this.numericZdata.Enabled = this.m_SpecificZdata;
        }
        else if (option == "SaveZdataInFolder")
        {
          this.radioZdataSaveFolder.Checked = flag;
          this.m_SaveZdataInFolder = flag;
          if (this.m_SaveZdataInFolder)
          {
            this.m_AutoZdata = false;
            this.m_SpecificZdata = false;
          }
          this.numericZdata.Enabled = this.m_SpecificZdata;
        }
        else if (option == "ZdataNumber")
        {
          this.numericZdata.Value = (Decimal) num;
          this.m_ZdataNumber = num;
        }
        else if (option == "SaveGuiInArchive")
        {
          this.radioGuiSaveArchive.Checked = flag;
          this.m_SaveGuiInArchive = flag;
          this.m_SaveGuiInFolder = !flag;
        }
        else if (option == "SaveGuiInFolder")
        {
          this.radioGuiSaveFolder.Checked = flag;
          this.m_SaveGuiInArchive = !flag;
          this.m_SaveGuiInFolder = flag;
        }
      }
    }

    private void buttonBrowseExportFolder_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      folderBrowserDialog.Description = "Select the export folder";
      folderBrowserDialog.ShowNewFolderButton = true;
      if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
      {
        folderBrowserDialog.Dispose();
      }
      else
      {
        this.textExportFolder.Text = folderBrowserDialog.SelectedPath;
        this.m_ExportFolder = this.textExportFolder.Text;
        folderBrowserDialog.Dispose();
      }
    }

    private void checkEditDb_CheckedChanged(object sender, EventArgs e)
    {
      this.m_SaveDatabase = this.checkSaveDb.Checked;
    }

    private void textExportFolder_TextChanged(object sender, EventArgs e)
    {
      this.m_ExportFolder = this.textExportFolder.Text;
    }

    private void checkEditZdata_CheckedChanged(object sender, EventArgs e)
    {
      this.m_SaveZdata = this.checkSaveZdata.Checked;
    }

    private void checkEditGui_CheckedChanged(object sender, EventArgs e)
    {
      this.m_SaveGui = this.checkSaveGui.Checked;
    }

    private void radioAutoZdata_CheckedChanged(object sender, EventArgs e)
    {
      this.m_AutoZdata = this.radioAutoZdata.Checked;
    }

    private void radioSpecificZdata_CheckedChanged(object sender, EventArgs e)
    {
      this.m_SpecificZdata = this.radioSpecificZdata.Checked;
      this.numericZdata.Enabled = this.radioSpecificZdata.Checked;
    }

    private void numericZdata_ValueChanged(object sender, EventArgs e)
    {
      this.m_ZdataNumber = (int) this.numericZdata.Value;
    }

    private void radioGuiSaveArchive_CheckedChanged(object sender, EventArgs e)
    {
      this.m_SaveGuiInArchive = this.radioGuiSaveArchive.Checked;
    }

    private void radioGuiSaveFolder_CheckedChanged(object sender, EventArgs e)
    {
      this.m_SaveGuiInFolder = this.radioGuiSaveFolder.Checked;
    }

    private void SaveOptions()
    {
      for (int index = 0; index < this.optionsSet.DataTableOpt.Count; ++index)
      {
        string option = this.optionsSet.DataTableOpt[index].Option;
        if (option == "ExportFolderAuto")
          this.optionsSet.DataTableOpt[index].Value = this.m_AutoExportFolder ? "1" : "0";
        else if (option == "ExportFolder")
          this.optionsSet.DataTableOpt[index].Value = this.m_ExportFolder;
        else if (option == "DatabaseEditing")
          this.optionsSet.DataTableOpt[index].Value = this.m_SaveDatabase ? "1" : "0";
        else if (option == "ZdataEditing")
          this.optionsSet.DataTableOpt[index].Value = this.m_SaveZdata ? "1" : "0";
        else if (option == "GuiEditing")
          this.optionsSet.DataTableOpt[index].Value = this.m_SaveGui ? "1" : "0";
        else if (option == "AutoZdata")
          this.optionsSet.DataTableOpt[index].Value = this.m_AutoZdata ? "1" : "0";
        else if (option == "SpecificZdata")
          this.optionsSet.DataTableOpt[index].Value = this.m_SpecificZdata ? "1" : "0";
        else if (option == "ZdataNumber")
          this.optionsSet.DataTableOpt[index].Value = this.m_ZdataNumber.ToString();
        else if (option == "SaveZdataInFolder")
          this.optionsSet.DataTableOpt[index].Value = this.m_SaveZdataInFolder ? "1" : "0";
        else if (option == "SaveGuiInArchive")
          this.optionsSet.DataTableOpt[index].Value = this.m_SaveGuiInArchive ? "1" : "0";
        else if (option == "SaveGuiInFolder")
          this.optionsSet.DataTableOpt[index].Value = this.m_SaveGuiInFolder ? "1" : "0";
      }
      this.optionsSet.WriteXml(this.m_XmlFileName);
    }

    private void buttonOK_Click(object sender, EventArgs e)
    {
      this.SaveOptions();
    }

    private void checkAutoExportFolder_CheckedChanged(object sender, EventArgs e)
    {
      this.m_AutoExportFolder = this.checkAutoExportFolder.Checked;
      this.textExportFolder.Enabled = !this.checkAutoExportFolder.Checked;
      this.buttonBrowseExportFolder.Enabled = !this.checkAutoExportFolder.Checked;
    }

    private void UserOptions_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.SaveOptions();
    }

    private void radioZdataSaveFolder_CheckedChanged(object sender, EventArgs e)
    {
      this.m_SaveZdataInFolder = this.radioZdataSaveFolder.Checked;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager resources = new ComponentResourceManager(typeof (UserOptions));
      this.textExportFolder = new TextBox();
      this.buttonBrowseExportFolder = new Button();
      this.toolTip = new ToolTip(this.components);
      this.checkSaveDb = new CheckBox();
      this.checkSaveZdata = new CheckBox();
      this.checkSaveGui = new CheckBox();
      this.radioAutoZdata = new RadioButton();
      this.radioSpecificZdata = new RadioButton();
      this.numericZdata = new NumericUpDown();
      this.radioGuiSaveArchive = new RadioButton();
      this.radioGuiSaveFolder = new RadioButton();
      this.checkAutoExportFolder = new CheckBox();
      this.radioZdataSaveFolder = new RadioButton();
      this.groupZdataSelection = new GroupBox();
      this.groupAllowSaving = new GroupBox();
      this.groupGuiSaveOptions = new GroupBox();
      this.groupExportFolde = new GroupBox();
      this.buttonCancel = new Button();
      this.buttonOK = new Button();
      this.optionsSet = new Options();
      this.numericZdata.BeginInit();
      this.groupZdataSelection.SuspendLayout();
      this.groupAllowSaving.SuspendLayout();
      this.groupGuiSaveOptions.SuspendLayout();
      this.groupExportFolde.SuspendLayout();
      this.optionsSet.BeginInit();
      this.SuspendLayout();
      resources.ApplyResources((object) this.textExportFolder, "textExportFolder");
      this.textExportFolder.Name = "textExportFolder";
      this.textExportFolder.TextChanged += new EventHandler(this.textExportFolder_TextChanged);
      resources.ApplyResources((object) this.buttonBrowseExportFolder, "buttonBrowseExportFolder");
      this.buttonBrowseExportFolder.Name = "buttonBrowseExportFolder";
      this.buttonBrowseExportFolder.UseVisualStyleBackColor = true;
      this.buttonBrowseExportFolder.Click += new EventHandler(this.buttonBrowseExportFolder_Click);
      resources.ApplyResources((object) this.checkSaveDb, "checkSaveDb");
      this.checkSaveDb.Checked = true;
      this.checkSaveDb.CheckState = CheckState.Checked;
      this.checkSaveDb.Name = "checkSaveDb";
      this.toolTip.SetToolTip((Control) this.checkSaveDb, resources.GetString("checkSaveDb.ToolTip"));
      this.checkSaveDb.UseVisualStyleBackColor = true;
      this.checkSaveDb.CheckedChanged += new EventHandler(this.checkEditDb_CheckedChanged);
      resources.ApplyResources((object) this.checkSaveZdata, "checkSaveZdata");
      this.checkSaveZdata.Checked = true;
      this.checkSaveZdata.CheckState = CheckState.Checked;
      this.checkSaveZdata.Name = "checkSaveZdata";
      this.toolTip.SetToolTip((Control) this.checkSaveZdata, resources.GetString("checkSaveZdata.ToolTip"));
      this.checkSaveZdata.UseVisualStyleBackColor = true;
      this.checkSaveZdata.CheckedChanged += new EventHandler(this.checkEditZdata_CheckedChanged);
      resources.ApplyResources((object) this.checkSaveGui, "checkSaveGui");
      this.checkSaveGui.Checked = true;
      this.checkSaveGui.CheckState = CheckState.Checked;
      this.checkSaveGui.Name = "checkSaveGui";
      this.toolTip.SetToolTip((Control) this.checkSaveGui, resources.GetString("checkSaveGui.ToolTip"));
      this.checkSaveGui.UseVisualStyleBackColor = true;
      this.checkSaveGui.CheckedChanged += new EventHandler(this.checkEditGui_CheckedChanged);
      resources.ApplyResources((object) this.radioAutoZdata, "radioAutoZdata");
      this.radioAutoZdata.Checked = true;
      this.radioAutoZdata.Name = "radioAutoZdata";
      this.radioAutoZdata.TabStop = true;
      this.toolTip.SetToolTip((Control) this.radioAutoZdata, resources.GetString("radioAutoZdata.ToolTip"));
      this.radioAutoZdata.UseVisualStyleBackColor = true;
      this.radioAutoZdata.CheckedChanged += new EventHandler(this.radioAutoZdata_CheckedChanged);
      resources.ApplyResources((object) this.radioSpecificZdata, "radioSpecificZdata");
      this.radioSpecificZdata.Name = "radioSpecificZdata";
      this.radioSpecificZdata.TabStop = true;
      this.toolTip.SetToolTip((Control) this.radioSpecificZdata, resources.GetString("radioSpecificZdata.ToolTip"));
      this.radioSpecificZdata.UseVisualStyleBackColor = true;
      this.radioSpecificZdata.CheckedChanged += new EventHandler(this.radioSpecificZdata_CheckedChanged);
      resources.ApplyResources((object) this.numericZdata, "numericZdata");
      this.numericZdata.Maximum = new Decimal(new int[4]
      {
        98,
        0,
        0,
        0
      });
      this.numericZdata.Minimum = new Decimal(new int[4]
      {
        40,
        0,
        0,
        0
      });
      this.numericZdata.Name = "numericZdata";
      this.toolTip.SetToolTip((Control) this.numericZdata, resources.GetString("numericZdata.ToolTip"));
      this.numericZdata.Value = new Decimal(new int[4]
      {
        49,
        0,
        0,
        0
      });
      this.numericZdata.ValueChanged += new EventHandler(this.numericZdata_ValueChanged);
      resources.ApplyResources((object) this.radioGuiSaveArchive, "radioGuiSaveArchive");
      this.radioGuiSaveArchive.Checked = true;
      this.radioGuiSaveArchive.Name = "radioGuiSaveArchive";
      this.radioGuiSaveArchive.TabStop = true;
      this.toolTip.SetToolTip((Control) this.radioGuiSaveArchive, resources.GetString("radioGuiSaveArchive.ToolTip"));
      this.radioGuiSaveArchive.UseVisualStyleBackColor = true;
      this.radioGuiSaveArchive.CheckedChanged += new EventHandler(this.radioGuiSaveArchive_CheckedChanged);
      resources.ApplyResources((object) this.radioGuiSaveFolder, "radioGuiSaveFolder");
      this.radioGuiSaveFolder.Name = "radioGuiSaveFolder";
      this.toolTip.SetToolTip((Control) this.radioGuiSaveFolder, resources.GetString("radioGuiSaveFolder.ToolTip"));
      this.radioGuiSaveFolder.UseVisualStyleBackColor = true;
      this.radioGuiSaveFolder.CheckedChanged += new EventHandler(this.radioGuiSaveFolder_CheckedChanged);
      resources.ApplyResources((object) this.checkAutoExportFolder, "checkAutoExportFolder");
      this.checkAutoExportFolder.Checked = true;
      this.checkAutoExportFolder.CheckState = CheckState.Checked;
      this.checkAutoExportFolder.Name = "checkAutoExportFolder";
      this.toolTip.SetToolTip((Control) this.checkAutoExportFolder, resources.GetString("checkAutoExportFolder.ToolTip"));
      this.checkAutoExportFolder.UseVisualStyleBackColor = true;
      this.checkAutoExportFolder.CheckedChanged += new EventHandler(this.checkAutoExportFolder_CheckedChanged);
      resources.ApplyResources((object) this.radioZdataSaveFolder, "radioZdataSaveFolder");
      this.radioZdataSaveFolder.Name = "radioZdataSaveFolder";
      this.radioZdataSaveFolder.TabStop = true;
      this.toolTip.SetToolTip((Control) this.radioZdataSaveFolder, resources.GetString("radioZdataSaveFolder.ToolTip"));
      this.radioZdataSaveFolder.UseVisualStyleBackColor = true;
      this.radioZdataSaveFolder.CheckedChanged += new EventHandler(this.radioZdataSaveFolder_CheckedChanged);
      this.groupZdataSelection.BackColor = Color.Transparent;
      this.groupZdataSelection.Controls.Add((Control) this.radioZdataSaveFolder);
      this.groupZdataSelection.Controls.Add((Control) this.numericZdata);
      this.groupZdataSelection.Controls.Add((Control) this.radioAutoZdata);
      this.groupZdataSelection.Controls.Add((Control) this.radioSpecificZdata);
      resources.ApplyResources((object) this.groupZdataSelection, "groupZdataSelection");
      this.groupZdataSelection.Name = "groupZdataSelection";
      this.groupZdataSelection.TabStop = false;
      this.groupAllowSaving.BackColor = Color.Transparent;
      this.groupAllowSaving.Controls.Add((Control) this.checkSaveDb);
      this.groupAllowSaving.Controls.Add((Control) this.checkSaveZdata);
      this.groupAllowSaving.Controls.Add((Control) this.checkSaveGui);
      resources.ApplyResources((object) this.groupAllowSaving, "groupAllowSaving");
      this.groupAllowSaving.Name = "groupAllowSaving";
      this.groupAllowSaving.TabStop = false;
      this.groupGuiSaveOptions.BackColor = Color.Transparent;
      this.groupGuiSaveOptions.Controls.Add((Control) this.radioGuiSaveFolder);
      this.groupGuiSaveOptions.Controls.Add((Control) this.radioGuiSaveArchive);
      resources.ApplyResources((object) this.groupGuiSaveOptions, "groupGuiSaveOptions");
      this.groupGuiSaveOptions.Name = "groupGuiSaveOptions";
      this.groupGuiSaveOptions.TabStop = false;
      this.groupExportFolde.BackColor = Color.Transparent;
      this.groupExportFolde.Controls.Add((Control) this.checkAutoExportFolder);
      this.groupExportFolde.Controls.Add((Control) this.textExportFolder);
      this.groupExportFolde.Controls.Add((Control) this.buttonBrowseExportFolder);
      resources.ApplyResources((object) this.groupExportFolde, "groupExportFolde");
      this.groupExportFolde.Name = "groupExportFolde";
      this.groupExportFolde.TabStop = false;
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      resources.ApplyResources((object) this.buttonCancel, "buttonCancel");
      this.buttonCancel.Name = "buttonCancel";
      this.buttonOK.DialogResult = DialogResult.OK;
      resources.ApplyResources((object) this.buttonOK, "buttonOK");
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
      this.optionsSet.DataSetName = "Options";
      this.optionsSet.Locale = new CultureInfo("");
      this.optionsSet.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      resources.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonOK);
      this.Controls.Add((Control) this.groupExportFolde);
      this.Controls.Add((Control) this.groupGuiSaveOptions);
      this.Controls.Add((Control) this.groupAllowSaving);
      this.Controls.Add((Control) this.groupZdataSelection);
      this.Name = "UserOptions";
      this.FormClosing += new FormClosingEventHandler(this.UserOptions_FormClosing);
      this.numericZdata.EndInit();
      this.groupZdataSelection.ResumeLayout(false);
      this.groupZdataSelection.PerformLayout();
      this.groupAllowSaving.ResumeLayout(false);
      this.groupAllowSaving.PerformLayout();
      this.groupGuiSaveOptions.ResumeLayout(false);
      this.groupGuiSaveOptions.PerformLayout();
      this.groupExportFolde.ResumeLayout(false);
      this.groupExportFolde.PerformLayout();
      this.optionsSet.EndInit();
      this.ResumeLayout(false);
    }
  }
}
