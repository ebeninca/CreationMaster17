// Original code created by Rinaldo

using FifaLibrary;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FifaControls
{
  public class AdvanceRuleDialog : Form
  {
    private Rank m_Rule;
    private Trophy m_Trophy;
    private Stage m_Stage;
    private Group m_Group;
    private IContainer components;
    private ComboBox comboTrophy;
    private Panel panel1;
    private Button buttonCancel;
    private Button buttonOk;
    private ComboBox comboStage;
    private ComboBox comboGroup;
    private ComboBox comboTeam;

    public AdvanceRuleDialog()
    {
      this.InitializeComponent();
    }

    public Rank Rule
    {
      get
      {
        return this.m_Rule;
      }
      set
      {
        this.m_Rule = value;
        this.LoadToPanel();
      }
    }

    public void Preset()
    {
      if (this.comboTrophy.Items.Count == FifaEnvironment.CompetitionObjects.Trophies.Count)
        return;
      this.comboTrophy.Items.Clear();
      this.comboTrophy.Items.AddRange(FifaEnvironment.CompetitionObjects.Trophies.ToArray());
    }

    private void LoadToPanel()
    {
      this.Preset();
      Group group1 = (Group) null;
      if (this.m_Rule.MoveFrom != null)
      {
        group1 = this.m_Rule.MoveFrom.Group;
        if (group1 != null)
          this.m_Trophy = group1.ParentTrophy;
      }
      if (group1 == null)
        group1 = this.m_Rule.Group;
      if (this.m_Trophy == null)
        this.m_Trophy = this.m_Rule.Group.ParentTrophy;
      this.comboTrophy.SelectedItem = (object) this.m_Trophy;
      this.comboStage.Items.Clear();
      foreach (Stage stage in (ArrayList) this.m_Trophy.Stages)
        this.comboStage.Items.Add((object) stage);
      this.m_Stage = group1 == null ? this.m_Rule.Group.ParentStage : group1.ParentStage;
      this.comboStage.SelectedItem = (object) this.m_Stage;
      this.comboGroup.Items.Clear();
      foreach (Group group2 in (ArrayList) this.m_Stage.Groups)
        this.comboGroup.Items.Add((object) group2);
      this.m_Group = group1;
      this.comboGroup.SelectedItem = (object) group1;
      this.comboTeam.Items.Clear();
      foreach (Rank rank in (ArrayList) this.m_Group.Ranks)
        this.comboTeam.Items.Add((object) rank);
      this.comboTeam.SelectedItem = (object) this.m_Rule.MoveFrom;
    }

    private void comboTrophy_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboTrophy.SelectedItem == this.m_Trophy)
        return;
      this.m_Trophy = (Trophy) this.comboTrophy.SelectedItem;
      this.comboStage.Items.Clear();
      foreach (Stage stage in (ArrayList) this.m_Trophy.Stages)
        this.comboStage.Items.Add((object) stage);
      this.comboStage.SelectedIndex = 0;
    }

    private void comboStage_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboStage.SelectedItem == this.m_Stage)
        return;
      this.m_Stage = (Stage) this.comboStage.SelectedItem;
      this.comboGroup.Items.Clear();
      foreach (Group group in (ArrayList) this.m_Stage.Groups)
        this.comboGroup.Items.Add((object) group);
      if (this.m_Stage.Groups.Count < 1)
        return;
      this.comboGroup.SelectedIndex = 0;
    }

    private void comboGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboGroup.SelectedItem == this.m_Group)
        return;
      this.m_Group = (Group) this.comboGroup.SelectedItem;
      this.comboTeam.Items.Clear();
      foreach (Rank rank in (ArrayList) this.m_Group.Ranks)
        this.comboTeam.Items.Add((object) rank);
      this.comboTeam.SelectedIndex = 0;
    }

    private void comboTeam_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.m_Rule.MoveFrom = (Rank) this.comboTeam.SelectedItem;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.comboTrophy = new ComboBox();
      this.panel1 = new Panel();
      this.buttonCancel = new Button();
      this.buttonOk = new Button();
      this.comboStage = new ComboBox();
      this.comboGroup = new ComboBox();
      this.comboTeam = new ComboBox();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.comboTrophy.FormattingEnabled = true;
      this.comboTrophy.Location = new Point(12, 12);
      this.comboTrophy.Name = "comboTrophy";
      this.comboTrophy.Size = new Size(351, 21);
      this.comboTrophy.TabIndex = 15;
      this.comboTrophy.SelectedIndexChanged += new EventHandler(this.comboTrophy_SelectedIndexChanged);
      this.panel1.Controls.Add((Control) this.buttonCancel);
      this.panel1.Controls.Add((Control) this.buttonOk);
      this.panel1.Dock = DockStyle.Bottom;
      this.panel1.Location = new Point(0, 134);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(375, 50);
      this.panel1.TabIndex = 17;
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      this.buttonCancel.Location = new Point(236, 15);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new Size(75, 23);
      this.buttonCancel.TabIndex = 3;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonOk.DialogResult = DialogResult.OK;
      this.buttonOk.Location = new Point(54, 15);
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.Size = new Size(75, 23);
      this.buttonOk.TabIndex = 2;
      this.buttonOk.Text = "OK";
      this.buttonOk.UseVisualStyleBackColor = true;
      this.comboStage.FormattingEnabled = true;
      this.comboStage.Location = new Point(12, 39);
      this.comboStage.Name = "comboStage";
      this.comboStage.Size = new Size(351, 21);
      this.comboStage.TabIndex = 18;
      this.comboStage.SelectedIndexChanged += new EventHandler(this.comboStage_SelectedIndexChanged);
      this.comboGroup.FormattingEnabled = true;
      this.comboGroup.Location = new Point(12, 66);
      this.comboGroup.Name = "comboGroup";
      this.comboGroup.Size = new Size(351, 21);
      this.comboGroup.TabIndex = 19;
      this.comboGroup.SelectedIndexChanged += new EventHandler(this.comboGroup_SelectedIndexChanged);
      this.comboTeam.FormattingEnabled = true;
      this.comboTeam.Location = new Point(12, 93);
      this.comboTeam.Name = "comboTeam";
      this.comboTeam.Size = new Size(351, 21);
      this.comboTeam.TabIndex = 20;
      this.comboTeam.SelectedIndexChanged += new EventHandler(this.comboTeam_SelectedIndexChanged);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(375, 184);
      this.Controls.Add((Control) this.comboTeam);
      this.Controls.Add((Control) this.comboGroup);
      this.Controls.Add((Control) this.comboStage);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.comboTrophy);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Name = "AdvanceRuleDialog";
      this.Text = "Advance Rule";
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
