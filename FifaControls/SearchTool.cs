// Original code created by Rinaldo

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FifaControls
{
  public class SearchTool : UserControl
  {
    private SearchTool.SearchMode m_SearchMode = SearchTool.SearchMode.SearchContaining;
    private IContainer components;
    private ToolStrip toolStrip;
    public ToolStripTextBox textBox;
    public ToolStripButton buttonSearchExact;
    public ToolStripButton buttonSearchStart;
    public ToolStripButton buttonSearchContain;
    public ToolStripButton buttonCaseSensitive;
    private ArrayList m_ObjectList;
    private object m_FoundObject;
    private bool m_HasFound;
    private bool m_CaseSensitive;
    private int m_CurrentIndex;
    private string m_Pattern;
    [Description("Search done.")]
    [Category("Event")]
    public SearchTool.SearchEventHandler CallBack;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager resources = new ComponentResourceManager(typeof (SearchTool));
      this.toolStrip = new ToolStrip();
      this.textBox = new ToolStripTextBox();
      this.buttonCaseSensitive = new ToolStripButton();
      this.buttonSearchContain = new ToolStripButton();
      this.buttonSearchStart = new ToolStripButton();
      this.buttonSearchExact = new ToolStripButton();
      this.toolStrip.SuspendLayout();
      this.SuspendLayout();
      this.toolStrip.GripStyle = ToolStripGripStyle.Hidden;
      this.toolStrip.Items.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.buttonCaseSensitive,
        (ToolStripItem) this.textBox,
        (ToolStripItem) this.buttonSearchExact,
        (ToolStripItem) this.buttonSearchStart,
        (ToolStripItem) this.buttonSearchContain
      });
      this.toolStrip.Location = new Point(0, 0);
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.Size = new Size(345, 25);
      this.toolStrip.TabIndex = 0;
      this.toolStrip.Text = "toolStrip";
      this.textBox.Name = "textBox";
      this.textBox.Size = new Size(200, 25);
      this.textBox.ToolTipText = "Type the string to search";
      this.textBox.KeyDown += new KeyEventHandler(this.textBox_KeyDown);
      this.buttonCaseSensitive.CheckOnClick = true;
      this.buttonCaseSensitive.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonCaseSensitive.Image = (Image) resources.GetObject("buttonCaseSensitive.Image");
      this.buttonCaseSensitive.ImageTransparentColor = Color.Magenta;
      this.buttonCaseSensitive.Name = "buttonCaseSensitive";
      this.buttonCaseSensitive.RightToLeft = RightToLeft.No;
      this.buttonCaseSensitive.Size = new Size(23, 22);
      this.buttonCaseSensitive.ToolTipText = "case sensitive search";
      this.buttonCaseSensitive.Click += new EventHandler(this.buttonCaseSensitive_Click);
      this.buttonSearchContain.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonSearchContain.Image = (Image) resources.GetObject("buttonSearchContain.Image");
      this.buttonSearchContain.ImageTransparentColor = Color.Magenta;
      this.buttonSearchContain.Name = "buttonSearchContain";
      this.buttonSearchContain.Size = new Size(23, 22);
      this.buttonSearchContain.Text = "Search if contains";
      this.buttonSearchContain.Click += new EventHandler(this.buttonSearchContain_Click);
      this.buttonSearchStart.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonSearchStart.Image = (Image) resources.GetObject("buttonSearchStart.Image");
      this.buttonSearchStart.ImageTransparentColor = Color.Magenta;
      this.buttonSearchStart.Name = "buttonSearchStart";
      this.buttonSearchStart.Size = new Size(23, 22);
      this.buttonSearchStart.Text = "Search if starts with";
      this.buttonSearchStart.Click += new EventHandler(this.buttonSearchStart_Click);
      this.buttonSearchExact.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonSearchExact.Image = (Image) resources.GetObject("buttonSearchExact.Image");
      this.buttonSearchExact.ImageTransparentColor = Color.Magenta;
      this.buttonSearchExact.Name = "buttonSearchExact";
      this.buttonSearchExact.Size = new Size(23, 22);
      this.buttonSearchExact.Text = "Search exactly";
      this.buttonSearchExact.Click += new EventHandler(this.buttonSearchExact_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.AutoSize = true;
      this.Controls.Add((Control) this.toolStrip);
      this.Name = "SearchTool";
      this.Size = new Size(345, 25);
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    [Description("Width of the text box.")]
    [Category("User")]
    public int TextWidth
    {
      get
      {
        return this.textBox.Width;
      }
      set
      {
        this.textBox.Size = new Size(value, this.textBox.Height);
      }
    }

    public ArrayList ObjectList
    {
      get
      {
        return this.m_ObjectList;
      }
      set
      {
        this.m_ObjectList = value;
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
        return this.m_CurrentIndex;
      }
      set
      {
        this.m_CurrentIndex = value;
      }
    }

    public SearchTool()
    {
      this.InitializeComponent();
    }

    private void textBox_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyValue != 13)
        return;
      this.Search();
    }

    private void buttonSearchExact_Click(object sender, EventArgs e)
    {
      this.m_SearchMode = SearchTool.SearchMode.SearchExact;
      this.Search();
    }

    private void buttonSearchStart_Click(object sender, EventArgs e)
    {
      this.m_SearchMode = SearchTool.SearchMode.SearchStarting;
      this.Search();
    }

    private void buttonSearchContain_Click(object sender, EventArgs e)
    {
      this.m_SearchMode = SearchTool.SearchMode.SearchContaining;
      this.Search();
    }

    public bool Search()
    {
      this.m_Pattern = this.textBox.Text;
      if (!this.IsCaseSensitive)
        this.m_Pattern = this.m_Pattern.ToLower();
      int index = this.m_CurrentIndex + 1;
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
            case SearchTool.SearchMode.SearchExact:
              this.m_HasFound = lower.ToString().Equals(this.m_Pattern);
              break;
            case SearchTool.SearchMode.SearchStarting:
              this.m_HasFound = lower.ToString().StartsWith(this.m_Pattern);
              break;
            case SearchTool.SearchMode.SearchContaining:
              this.m_HasFound = lower.Contains(this.m_Pattern);
              break;
          }
          if (this.m_HasFound)
          {
            this.m_FoundObject = this.m_ObjectList[index];
            this.m_CurrentIndex = index;
            if (this.CallBack != null)
              this.CallBack((object) this, this.m_FoundObject);
            return true;
          }
          if (index != this.m_CurrentIndex)
            ++index;
          else
            goto label_17;
        }
        while (index != this.m_ObjectList.Count);
        index = 0;
      }
label_17:
      this.m_FoundObject = (object) null;
      this.CallBack((object) this, (object) null);
      return false;
    }

    private void buttonCaseSensitive_Click(object sender, EventArgs e)
    {
      this.m_CaseSensitive = this.buttonCaseSensitive.Checked;
    }

    private enum SearchMode
    {
      SearchExact,
      SearchStarting,
      SearchContaining,
    }

    public delegate void SearchEventHandler(object sender, object obj);
  }
}
