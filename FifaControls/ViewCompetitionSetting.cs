// Original code created by Rinaldo

using FifaLibrary;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FifaControls
{
  public class ViewCompetitionSetting : UserControl
  {
    private CompetitionSettings m_CompetitionSettings;
    private string m_Description;
    private int m_Index;
    private bool m_IsSpecific;
    private IContainer components;
    private CheckBox check;
    public Label label;
    public TextBox textBox;

    [Category("User")]
    [System.ComponentModel.Description("Settings")]
    public CompetitionSettings Settings
    {
      get
      {
        return this.m_CompetitionSettings;
      }
      set
      {
        this.m_CompetitionSettings = value;
        if (this.m_CompetitionSettings != null)
        {
          this.textBox.Text = this.m_CompetitionSettings.GetProperty(this.m_Description, this.m_Index, out this.m_IsSpecific);
          this.check.Checked = this.m_IsSpecific;
        }
        else
        {
          this.textBox.Text = string.Empty;
          this.check.Checked = false;
        }
      }
    }

    [System.ComponentModel.Description("Index")]
    [Category("User")]
    public int Index
    {
      get
      {
        return this.m_Index;
      }
      set
      {
        this.m_Index = value;
      }
    }

    [Category("User")]
    [System.ComponentModel.Description("Description")]
    public string Description
    {
      get
      {
        return this.m_Description;
      }
      set
      {
        this.m_Description = value;
        this.label.Text = this.m_Description;
      }
    }

    public ViewCompetitionSetting()
    {
      this.InitializeComponent();
    }

    private void check_CheckedChanged(object sender, EventArgs e)
    {
      if (this.check.Checked)
      {
        this.label.BackColor = Color.LightGreen;
        this.label.ForeColor = Color.Black;
        this.textBox.Enabled = true;
      }
      else
      {
        this.m_CompetitionSettings.UnsetProperty(this.m_Description);
        this.textBox.Text = this.m_CompetitionSettings.GetProperty(this.m_Description, this.m_Index, out this.m_IsSpecific);
        this.textBox.Enabled = false;
        this.label.BackColor = Color.Gray;
        this.label.BackColor = Color.DarkGray;
      }
    }

    private void textBox_TextChanged(object sender, EventArgs e)
    {
      int num = this.check.Checked ? 1 : 0;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.check = new CheckBox();
      this.label = new Label();
      this.textBox = new TextBox();
      this.SuspendLayout();
      this.check.AutoSize = true;
      this.check.Dock = DockStyle.Left;
      this.check.Location = new Point(0, 0);
      this.check.Name = "check";
      this.check.Size = new Size(15, 20);
      this.check.TabIndex = 0;
      this.check.UseVisualStyleBackColor = true;
      this.check.CheckedChanged += new EventHandler(this.check_CheckedChanged);
      this.label.BackColor = Color.Transparent;
      this.label.Dock = DockStyle.Fill;
      this.label.Location = new Point(15, 0);
      this.label.Name = "label";
      this.label.Size = new Size(368, 20);
      this.label.TabIndex = 1;
      this.label.Text = "Description";
      this.label.TextAlign = ContentAlignment.MiddleLeft;
      this.textBox.Dock = DockStyle.Right;
      this.textBox.Location = new Point(266, 0);
      this.textBox.Name = "textBox";
      this.textBox.Size = new Size(117, 20);
      this.textBox.TabIndex = 2;
      this.textBox.TextAlign = HorizontalAlignment.Center;
      this.textBox.TextChanged += new EventHandler(this.textBox_TextChanged);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.textBox);
      this.Controls.Add((Control) this.label);
      this.Controls.Add((Control) this.check);
      this.Name = "CompetitionSetting";
      this.Size = new Size(383, 20);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
