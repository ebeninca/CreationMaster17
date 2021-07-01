// Original code created by Rinaldo

using FifaLibrary;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FifaControls
{
  public class PickUpControl : UserControl
  {
    private bool m_MainSelectionEnabled = true;
    private bool m_SearchEnabled = true;
    private bool m_CreateButtonEnabled = true;
    private bool m_RemoveButtonEnabled = true;
    private bool m_CloneButtonEnabled = true;
    private bool m_RefreshButtonEnabled = true;
    private int m_CurrentObject = -1;
    private int m_CurrentFilterBy = -1;
    private PickUpControl.SearchMode m_SearchMode = PickUpControl.SearchMode.SearchContaining;
    private IdArrayList m_ObjectList;
    private bool m_FilterEnabled;
    private bool m_YoungPlayersEnabled;
    private bool m_WizardButtonEnabled;
    private string[] m_FilterByList;
    private IdArrayList[] m_FilterValues;
    private int[] m_FilterIndex;
    [Description("Handle selected object change.")]
    [Category("User")]
    public PickUpControl.PickUpCallback SelectObject;
    public PickUpControl.PickUpCallback CreateObject;
    public PickUpControl.PickUpCallback DeleteObject;
    public PickUpControl.PickUpCallback CloneObject;
    public PickUpControl.PickUpCallback FilterChanged;
    public PickUpControl.PickUpCallback WizardObject;
    public PickUpControl.PickUpCallback RefreshObject;
    private bool m_SwitchSema;
    private object m_FoundObject;
    private bool m_HasFound;
    private bool m_CaseSensitive;
    private int m_CurrentSearchIndex;
    private string m_Pattern;
    private IContainer components;
    private ToolStrip toolStrip;
    private ToolStripSeparator separatorBegin;
    private ToolStripSeparator separatorSearch;
    private ToolStripSeparator separatorButtons;
    public ToolStripComboBox combo;
    public ToolStripButton buttonCaseSensitive;
    public ToolStripTextBox textSearch;
    public ToolStripButton buttonSearchContain;
    public ToolStripButton buttonSearchExactly;
    public ToolStripButton buttonSearchStart;
    public ToolStripButton buttonNew;
    public ToolStripButton buttonRemove;
    public ToolStripButton buttonClone;
    public ToolStripLabel labelFilter;
    public ToolStripComboBox comboFilterBy;
    public ToolStripComboBox comboFilterValue;
    public ToolStripSeparator separatorFilter;
    private ToolStripButton buttonWizard;
    private ToolStripButton buttonRefresh;

    [Description("Array List to show")]
    [Category("User")]
    public IdArrayList ObjectList
    {
      get
      {
        return this.m_ObjectList;
      }
      set
      {
        object selectedItem = this.combo.SelectedItem;
        this.m_ObjectList = value;
        if (this.m_ObjectList != null)
          this.FilterObjects();
        else
          this.combo.Items.Clear();
      }
    }

    [Category("User")]
    [Description("Enable the main selection combo box")]
    public bool MainSelectionEnabled
    {
      get
      {
        return this.m_MainSelectionEnabled;
      }
      set
      {
        this.m_MainSelectionEnabled = value;
        this.combo.Visible = value;
        this.separatorBegin.Visible = value;
      }
    }

    [Description("Enable the filter tools")]
    [Category("User")]
    public bool FilterEnabled
    {
      get
      {
        return this.m_FilterEnabled;
      }
      set
      {
        this.m_FilterEnabled = value;
        this.labelFilter.Visible = value;
        this.comboFilterBy.Visible = value;
        this.comboFilterValue.Visible = value;
        this.separatorFilter.Visible = value;
      }
    }

    [Description("Enable the Young Players chack")]
    [Category("User")]
    public bool YoungPlayersEnabled
    {
      get
      {
        return this.m_YoungPlayersEnabled;
      }
      set
      {
        this.m_YoungPlayersEnabled = value;
      }
    }

    [Description("Enable the search tools")]
    [Category("User")]
    public bool SearchEnabled
    {
      get
      {
        return this.m_SearchEnabled;
      }
      set
      {
        this.m_SearchEnabled = value;
        this.buttonSearchContain.Visible = value;
        this.buttonSearchExactly.Visible = value;
        this.buttonSearchStart.Visible = value;
        this.textSearch.Visible = value;
        this.buttonCaseSensitive.Visible = value;
        this.separatorSearch.Visible = value;
      }
    }

    [Category("User")]
    [Description("Enable the create button")]
    public bool CreateButtonEnabled
    {
      get
      {
        return this.m_CreateButtonEnabled;
      }
      set
      {
        this.m_CreateButtonEnabled = value;
        this.buttonNew.Visible = value;
        this.separatorButtons.Visible = this.m_CreateButtonEnabled || this.m_RemoveButtonEnabled || this.m_CloneButtonEnabled;
      }
    }

    [Category("User")]
    [Description("Enable the create button")]
    public bool RemoveButtonEnabled
    {
      get
      {
        return this.m_RemoveButtonEnabled;
      }
      set
      {
        this.m_RemoveButtonEnabled = value;
        this.buttonRemove.Visible = value;
        this.separatorButtons.Visible = this.m_CreateButtonEnabled || this.m_RemoveButtonEnabled || this.m_CloneButtonEnabled;
      }
    }

    [Category("User")]
    [Description("Enable the create button")]
    public bool CloneButtonEnabled
    {
      get
      {
        return this.m_CloneButtonEnabled;
      }
      set
      {
        this.m_CloneButtonEnabled = value;
        this.buttonClone.Visible = value;
        this.separatorButtons.Visible = this.m_CreateButtonEnabled || this.m_RemoveButtonEnabled || this.m_CloneButtonEnabled;
      }
    }

    [Description("Enable the refresh button")]
    [Category("User")]
    public bool RefreshButtonEnabled
    {
      get
      {
        return this.m_RefreshButtonEnabled;
      }
      set
      {
        this.m_RefreshButtonEnabled = value;
        this.buttonRefresh.Visible = value;
      }
    }

    [Category("User")]
    [Description("Enable the wizard button")]
    public bool WizardButtonEnabled
    {
      get
      {
        return this.m_WizardButtonEnabled;
      }
      set
      {
        this.m_WizardButtonEnabled = value;
        this.buttonWizard.Visible = value;
        this.separatorButtons.Visible = this.m_CreateButtonEnabled || this.m_RemoveButtonEnabled || this.m_CloneButtonEnabled;
      }
    }

    [Category("User")]
    [Description("Filter by list")]
    public string[] FilterByList
    {
      get
      {
        return this.m_FilterByList;
      }
      set
      {
        this.m_FilterByList = value;
        this.comboFilterBy.Items.Clear();
        if (this.m_FilterByList == null)
          return;
        this.comboFilterBy.Items.AddRange((object[]) this.m_FilterByList);
        this.comboFilterBy.SelectedIndex = 0;
        this.m_FilterIndex = new int[this.m_FilterByList.Length];
      }
    }

    [Category("User")]
    [Description("Filter values")]
    public IdArrayList[] FilterValues
    {
      get
      {
        return this.m_FilterValues;
      }
      set
      {
        this.m_FilterValues = value;
      }
    }

    public object FoundObject
    {
      get
      {
        return this.m_FoundObject;
      }
    }

    public bool HasFound
    {
      get
      {
        return this.m_HasFound;
      }
    }

    public bool IsCaseSensitive
    {
      get
      {
        return this.m_CaseSensitive;
      }
    }

    public int CurrentIndex
    {
      get
      {
        return this.m_CurrentSearchIndex;
      }
      set
      {
        this.m_CurrentSearchIndex = value;
      }
    }

    public PickUpControl()
    {
      this.InitializeComponent();
    }

    public void SwitchObject(IdObject idObject)
    {
      this.m_SwitchSema = true;
      int index = this.combo.Items.IndexOf((object) idObject);
      if (index >= 0)
      {
        this.combo.Items.RemoveAt(index);
        this.combo.Items.Insert(index, (object) idObject);
        this.combo.SelectedItem = (object) idObject;
      }
      this.m_SwitchSema = false;
    }

    private void combo_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_SwitchSema)
        return;
      this.m_CurrentObject = this.combo.SelectedIndex;
      if (this.SelectObject == null || this.combo.SelectedItem == null)
        return;
      Cursor.Current = Cursors.WaitCursor;
      IdObject idObject = this.SelectObject(sender, this.combo.SelectedItem);
      Cursor.Current = Cursors.Default;
    }

    private void buttonNew_Click(object sender, EventArgs e)
    {
      if (this.CreateObject == null)
        return;
      IdObject idObject = this.CreateObject(sender, (object) e);
      if (idObject == null)
        return;
      this.combo.Items.Add((object) idObject);
      this.combo.SelectedItem = (object) idObject;
    }

    private void buttonDelete_Click(object sender, EventArgs e)
    {
      IdObject selectedItem = (IdObject) this.combo.SelectedItem;
      if (selectedItem == null)
        return;
      if (this.DeleteObject != null)
      {
        IdObject idObject = this.DeleteObject(sender, (object) selectedItem);
      }
      int index = this.combo.Items.IndexOf((object) selectedItem);
      this.combo.Items.RemoveAt(index);
      if (index < this.combo.Items.Count)
      {
        this.combo.SelectedIndex = index;
      }
      else
      {
        if (this.combo.Items.Count <= 0)
          return;
        this.combo.SelectedIndex = this.combo.Items.Count - 1;
      }
    }

    private void buttonClone_Click(object sender, EventArgs e)
    {
      if (this.CloneObject == null)
        return;
      IdObject selectedItem = (IdObject) this.combo.SelectedItem;
      if (selectedItem == null)
        return;
      IdObject idObject = this.CloneObject(sender, (object) selectedItem);
      if (idObject == null)
        return;
      this.combo.Items.Add((object) idObject);
      this.combo.SelectedItem = (object) idObject;
    }

    private void buttonCaseSensitive_Click(object sender, EventArgs e)
    {
      this.m_CaseSensitive = this.buttonCaseSensitive.Checked;
    }

    private void textBox_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyValue != 13)
        return;
      this.Search();
    }

    private void buttonSearchExact_Click(object sender, EventArgs e)
    {
      this.m_SearchMode = PickUpControl.SearchMode.SearchExact;
      this.Search();
    }

    private void buttonSearchStart_Click(object sender, EventArgs e)
    {
      this.m_SearchMode = PickUpControl.SearchMode.SearchStarting;
      this.Search();
    }

    private void buttonSearchContain_Click(object sender, EventArgs e)
    {
      this.m_SearchMode = PickUpControl.SearchMode.SearchContaining;
      this.Search();
    }

    public bool Search()
    {
      this.m_Pattern = this.textSearch.Text;
      if (!this.IsCaseSensitive)
        this.m_Pattern = this.m_Pattern.ToLower();
      int index = this.m_CurrentSearchIndex + 1;
      if (index == this.m_ObjectList.Count)
        index = 0;
      while (true)
      {
        do
        {
          string lower = this.m_ObjectList[index].ToString();
          if (!this.IsCaseSensitive)
            lower = lower.ToLower();
          switch (this.m_SearchMode)
          {
            case PickUpControl.SearchMode.SearchExact:
              this.m_HasFound = lower.ToString().Equals(this.m_Pattern);
              break;
            case PickUpControl.SearchMode.SearchStarting:
              this.m_HasFound = lower.ToString().StartsWith(this.m_Pattern);
              break;
            case PickUpControl.SearchMode.SearchContaining:
              this.m_HasFound = lower.Contains(this.m_Pattern);
              break;
          }
          if (this.m_HasFound)
          {
            this.m_FoundObject = this.m_ObjectList[index];
            this.m_CurrentSearchIndex = index;
            this.combo.SelectedItem = this.m_FoundObject;
            return true;
          }
          if (index != this.m_CurrentSearchIndex)
            ++index;
          else
            goto label_15;
        }
        while (index != this.m_ObjectList.Count);
        index = 0;
      }
label_15:
      this.m_FoundObject = (object) null;
      return false;
    }

    private void comboFilterBy_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboFilterBy.SelectedIndex < 0)
        return;
      if (this.comboFilterBy.SelectedIndex == 0)
      {
        this.comboFilterValue.Items.Clear();
        this.comboFilterValue.Enabled = false;
        this.combo.Items.Clear();
        if (this.FilterChanged != null)
        {
          IdObject idObject = this.FilterChanged(sender, (object) null);
        }
        this.FilterObjects();
        this.m_CurrentFilterBy = 0;
      }
      else
      {
        int selectedIndex = this.comboFilterBy.SelectedIndex;
        this.comboFilterValue.Items.Clear();
        if (this.m_FilterValues[selectedIndex] != null)
        {
          this.comboFilterValue.Items.AddRange(this.m_FilterValues[selectedIndex].ToArray());
          this.comboFilterValue.Enabled = true;
          if (this.m_FilterIndex[selectedIndex] < this.comboFilterValue.Items.Count)
          {
            this.comboFilterValue.SelectedIndex = this.m_FilterIndex[selectedIndex];
          }
          else
          {
            this.m_FilterIndex[selectedIndex] = 0;
            this.comboFilterValue.SelectedIndex = this.m_FilterIndex[selectedIndex];
          }
        }
        if (this.FilterChanged != null)
        {
          IdObject idObject = this.FilterChanged(sender, this.comboFilterValue.SelectedItem);
        }
        this.m_CurrentFilterBy = this.comboFilterBy.SelectedIndex;
      }
    }

    private void comboFilterValue_SelectedIndexChanged(object sender, EventArgs e)
    {
      int selectedIndex = this.comboFilterBy.SelectedIndex;
      if (selectedIndex == this.m_CurrentFilterBy && (this.comboFilterValue.SelectedIndex < 0 || this.comboFilterValue.SelectedIndex == this.m_FilterIndex[selectedIndex]))
        return;
      this.m_FilterIndex[selectedIndex] = this.comboFilterValue.SelectedIndex;
      if (this.FilterChanged != null)
      {
        IdObject idObject = this.FilterChanged(sender, this.comboFilterValue.SelectedItem);
      }
      this.FilterObjects();
    }

    private void FilterObjects()
    {
      if (this.m_ObjectList == null)
        return;
      object selectedItem = this.combo.SelectedItem;
      IdArrayList idArrayList = this.m_ObjectList.Filter((IdObject) this.comboFilterValue.SelectedItem);
      this.combo.BeginUpdate();
      this.combo.Items.Clear();
      this.combo.Items.AddRange(idArrayList.ToArray());
      this.combo.EndUpdate();
      if (selectedItem != null)
        this.combo.SelectedItem = selectedItem;
      if (this.combo.SelectedIndex >= 0)
        return;
      if (this.combo.Items.Count != 0)
        this.combo.SelectedIndex = 0;
      else
        this.combo.Text = string.Empty;
    }

    private void buttonWizard_Click(object sender, EventArgs e)
    {
      if (this.WizardObject == null)
        return;
      IdObject idObject = this.WizardObject(sender, (object) e);
      if (idObject == null)
        return;
      this.combo.Items.Add((object) idObject);
      this.combo.SelectedItem = (object) idObject;
    }

    private void buttonRefresh_Click(object sender, EventArgs e)
    {
      if (this.RefreshObject == null)
        return;
      IdObject idObject = this.RefreshObject(sender, (object) e);
    }

    private void buttonYoungPlayer_CheckedChanged(object sender, EventArgs e)
    {
      this.FilterObjects();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager resources = new ComponentResourceManager(typeof (PickUpControl));
      this.toolStrip = new ToolStrip();
      this.separatorBegin = new ToolStripSeparator();
      this.combo = new ToolStripComboBox();
      this.buttonRefresh = new ToolStripButton();
      this.separatorSearch = new ToolStripSeparator();
      this.buttonCaseSensitive = new ToolStripButton();
      this.textSearch = new ToolStripTextBox();
      this.buttonSearchExactly = new ToolStripButton();
      this.buttonSearchStart = new ToolStripButton();
      this.buttonSearchContain = new ToolStripButton();
      this.separatorButtons = new ToolStripSeparator();
      this.buttonNew = new ToolStripButton();
      this.buttonRemove = new ToolStripButton();
      this.buttonClone = new ToolStripButton();
      this.buttonWizard = new ToolStripButton();
      this.separatorFilter = new ToolStripSeparator();
      this.labelFilter = new ToolStripLabel();
      this.comboFilterBy = new ToolStripComboBox();
      this.comboFilterValue = new ToolStripComboBox();
      this.toolStrip.SuspendLayout();
      this.SuspendLayout();
      this.toolStrip.AllowItemReorder = true;
      this.toolStrip.BackColor = SystemColors.Control;
      this.toolStrip.BackgroundImage = (Image) resources.GetObject("toolStrip.BackgroundImage");
      this.toolStrip.GripStyle = ToolStripGripStyle.Hidden;
      this.toolStrip.Items.AddRange(new ToolStripItem[18]
      {
        (ToolStripItem) this.separatorBegin,
        (ToolStripItem) this.combo,
        (ToolStripItem) this.buttonRefresh,
        (ToolStripItem) this.separatorSearch,
        (ToolStripItem) this.buttonCaseSensitive,
        (ToolStripItem) this.textSearch,
        (ToolStripItem) this.buttonSearchExactly,
        (ToolStripItem) this.buttonSearchStart,
        (ToolStripItem) this.buttonSearchContain,
        (ToolStripItem) this.separatorButtons,
        (ToolStripItem) this.buttonNew,
        (ToolStripItem) this.buttonRemove,
        (ToolStripItem) this.buttonClone,
        (ToolStripItem) this.buttonWizard,
        (ToolStripItem) this.separatorFilter,
        (ToolStripItem) this.labelFilter,
        (ToolStripItem) this.comboFilterBy,
        (ToolStripItem) this.comboFilterValue
      });
      this.toolStrip.Location = new Point(0, 0);
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.Size = new Size(920, 25);
      this.toolStrip.TabIndex = 2;
      this.toolStrip.Text = "toolStrip";
      this.separatorBegin.Name = "separatorBegin";
      this.separatorBegin.Size = new Size(6, 25);
      this.combo.DropDownHeight = 256;
      this.combo.IntegralHeight = false;
      this.combo.MaxDropDownItems = 16;
      this.combo.Name = "combo";
      this.combo.Size = new Size(200, 25);
      this.combo.Sorted = true;
      this.combo.SelectedIndexChanged += new EventHandler(this.combo_SelectedIndexChanged);
      this.buttonRefresh.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonRefresh.Image = (Image) resources.GetObject("buttonRefresh.Image");
      this.buttonRefresh.ImageTransparentColor = Color.Magenta;
      this.buttonRefresh.Name = "buttonRefresh";
      this.buttonRefresh.Size = new Size(23, 22);
      this.buttonRefresh.Text = "Refresh";
      this.buttonRefresh.Click += new EventHandler(this.buttonRefresh_Click);
      this.separatorSearch.Name = "separatorSearch";
      this.separatorSearch.Size = new Size(6, 25);
      this.buttonCaseSensitive.CheckOnClick = true;
      this.buttonCaseSensitive.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonCaseSensitive.Image = (Image) resources.GetObject("buttonCaseSensitive.Image");
      this.buttonCaseSensitive.ImageTransparentColor = Color.Magenta;
      this.buttonCaseSensitive.Name = "buttonCaseSensitive";
      this.buttonCaseSensitive.Size = new Size(23, 22);
      this.buttonCaseSensitive.Text = "Case sensitive";
      this.buttonCaseSensitive.Click += new EventHandler(this.buttonCaseSensitive_Click);
      this.textSearch.Name = "textSearch";
      this.textSearch.Size = new Size(150, 25);
      this.textSearch.KeyDown += new KeyEventHandler(this.textBox_KeyDown);
      this.buttonSearchExactly.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonSearchExactly.Image = (Image) resources.GetObject("buttonSearchExactly.Image");
      this.buttonSearchExactly.ImageTransparentColor = Color.Magenta;
      this.buttonSearchExactly.Name = "buttonSearchExactly";
      this.buttonSearchExactly.Size = new Size(23, 22);
      this.buttonSearchExactly.Text = "Search Exactly";
      this.buttonSearchExactly.Click += new EventHandler(this.buttonSearchExact_Click);
      this.buttonSearchStart.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonSearchStart.Image = (Image) resources.GetObject("buttonSearchStart.Image");
      this.buttonSearchStart.ImageTransparentColor = Color.Magenta;
      this.buttonSearchStart.Name = "buttonSearchStart";
      this.buttonSearchStart.Size = new Size(23, 22);
      this.buttonSearchStart.Text = "Search if starts";
      this.buttonSearchStart.Click += new EventHandler(this.buttonSearchStart_Click);
      this.buttonSearchContain.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonSearchContain.Image = (Image) resources.GetObject("buttonSearchContain.Image");
      this.buttonSearchContain.ImageTransparentColor = Color.Magenta;
      this.buttonSearchContain.Name = "buttonSearchContain";
      this.buttonSearchContain.Size = new Size(23, 22);
      this.buttonSearchContain.Text = "Search if contains";
      this.buttonSearchContain.Click += new EventHandler(this.buttonSearchContain_Click);
      this.separatorButtons.Name = "separatorButtons";
      this.separatorButtons.Size = new Size(6, 25);
      this.buttonNew.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonNew.Image = (Image) resources.GetObject("buttonNew.Image");
      this.buttonNew.ImageTransparentColor = Color.Magenta;
      this.buttonNew.Name = "buttonNew";
      this.buttonNew.Size = new Size(23, 22);
      this.buttonNew.Text = "Create";
      this.buttonNew.Click += new EventHandler(this.buttonNew_Click);
      this.buttonRemove.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonRemove.Image = (Image) resources.GetObject("buttonRemove.Image");
      this.buttonRemove.ImageTransparentColor = Color.Magenta;
      this.buttonRemove.Name = "buttonRemove";
      this.buttonRemove.Size = new Size(23, 22);
      this.buttonRemove.Text = "Remove";
      this.buttonRemove.Click += new EventHandler(this.buttonDelete_Click);
      this.buttonClone.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonClone.Image = (Image) resources.GetObject("buttonClone.Image");
      this.buttonClone.ImageTransparentColor = Color.Magenta;
      this.buttonClone.Name = "buttonClone";
      this.buttonClone.Size = new Size(23, 22);
      this.buttonClone.Text = "Clone";
      this.buttonClone.Click += new EventHandler(this.buttonClone_Click);
      this.buttonWizard.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonWizard.Image = (Image) resources.GetObject("buttonWizard.Image");
      this.buttonWizard.ImageTransparentColor = Color.Magenta;
      this.buttonWizard.Name = "buttonWizard";
      this.buttonWizard.Size = new Size(23, 22);
      this.buttonWizard.Text = "Wizard";
      this.buttonWizard.Visible = false;
      this.buttonWizard.Click += new EventHandler(this.buttonWizard_Click);
      this.separatorFilter.Name = "separatorFilter";
      this.separatorFilter.Size = new Size(6, 25);
      this.separatorFilter.Visible = false;
      this.labelFilter.Name = "labelFilter";
      this.labelFilter.Size = new Size(33, 22);
      this.labelFilter.Text = "Filter";
      this.labelFilter.Visible = false;
      this.comboFilterBy.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboFilterBy.Name = "comboFilterBy";
      this.comboFilterBy.Size = new Size(120, 25);
      this.comboFilterBy.Visible = false;
      this.comboFilterBy.SelectedIndexChanged += new EventHandler(this.comboFilterBy_SelectedIndexChanged);
      this.comboFilterValue.Name = "comboFilterValue";
      this.comboFilterValue.Size = new Size(160, 25);
      this.comboFilterValue.Sorted = true;
      this.comboFilterValue.Visible = false;
      this.comboFilterValue.SelectedIndexChanged += new EventHandler(this.comboFilterValue_SelectedIndexChanged);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = SystemColors.Control;
      this.Controls.Add((Control) this.toolStrip);
      this.Name = "PickUpControl";
      this.Size = new Size(920, 25);
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public delegate IdObject PickUpCallback(object sender, object obj);

    private enum SearchMode
    {
      SearchExact,
      SearchStarting,
      SearchContaining,
    }
  }
}
