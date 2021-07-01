// Original code created by Rinaldo

using FifaLibrary;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FifaControls
{
  public class QualifyRuleDialog : Form
  {
    private IContainer components;
    private Button buttonOk;
    private Button buttonCancel;
    private RadioButton radioRule1;
    private RadioButton radioRule2;
    private RadioButton radioRule3;
    private RadioButton radioRule4;
    private RadioButton radioRule5;
    private RadioButton radioRule6;
    private RadioButton radioRule7;
    private ComboBox comboTrophy1;
    private ComboBox comboTrophy2;
    private ComboBox comboLeague;
    private NumericUpDown numericN;
    private ComboBox comboTeam;
    private NumericUpDown numericCountryLimitation;
    private RadioButton radioRule8;
    private Task m_QualifyRule;
    private EQualifyingRule m_Rule;
    private Trophy m_Trophy1;
    private Trophy m_Trophy2;
    private League m_League;
    private Team m_Team;
    private int m_Number;
    private uint m_CountryLimitation;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.buttonOk = new Button();
      this.buttonCancel = new Button();
      this.radioRule1 = new RadioButton();
      this.radioRule2 = new RadioButton();
      this.radioRule3 = new RadioButton();
      this.radioRule4 = new RadioButton();
      this.radioRule5 = new RadioButton();
      this.radioRule6 = new RadioButton();
      this.radioRule7 = new RadioButton();
      this.comboTrophy1 = new ComboBox();
      this.comboTrophy2 = new ComboBox();
      this.comboLeague = new ComboBox();
      this.numericN = new NumericUpDown();
      this.comboTeam = new ComboBox();
      this.numericCountryLimitation = new NumericUpDown();
      this.radioRule8 = new RadioButton();
      this.numericN.BeginInit();
      this.numericCountryLimitation.BeginInit();
      this.SuspendLayout();
      this.buttonOk.DialogResult = DialogResult.OK;
      this.buttonOk.Location = new Point(89, 258);
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.Size = new Size(75, 23);
      this.buttonOk.TabIndex = 0;
      this.buttonOk.Text = "OK";
      this.buttonOk.UseVisualStyleBackColor = true;
      this.buttonOk.Click += new EventHandler(this.buttonOk_Click);
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      this.buttonCancel.Location = new Point(327, 258);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new Size(75, 23);
      this.buttonCancel.TabIndex = 1;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.radioRule1.AutoSize = true;
      this.radioRule1.Location = new Point(12, 12);
      this.radioRule1.Name = "radioRule1";
      this.radioRule1.Size = new Size(193, 17);
      this.radioRule1.TabIndex = 2;
      this.radioRule1.TabStop = true;
      this.radioRule1.Text = "Get the Best N Team(s) of a Trophy";
      this.radioRule1.UseVisualStyleBackColor = true;
      this.radioRule1.CheckedChanged += new EventHandler(this.radioRule1_CheckedChanged);
      this.radioRule2.AutoSize = true;
      this.radioRule2.Location = new Point(12, 35);
      this.radioRule2.Name = "radioRule2";
      this.radioRule2.Size = new Size(303, 17);
      this.radioRule2.TabIndex = 5;
      this.radioRule2.TabStop = true;
      this.radioRule2.Text = "Get the Winner of a Trophy or a Team from another Trophy";
      this.radioRule2.UseVisualStyleBackColor = true;
      this.radioRule2.CheckedChanged += new EventHandler(this.radioRule2_CheckedChanged);
      this.radioRule3.AutoSize = true;
      this.radioRule3.Location = new Point(12, 58);
      this.radioRule3.Name = "radioRule3";
      this.radioRule3.Size = new Size(276, 17);
      this.radioRule3.TabIndex = 7;
      this.radioRule3.TabStop = true;
      this.radioRule3.Text = "Get the Winner of a Trophy or a Team from a League";
      this.radioRule3.UseVisualStyleBackColor = true;
      this.radioRule3.CheckedChanged += new EventHandler(this.radioRule3_CheckedChanged);
      this.radioRule4.AutoSize = true;
      this.radioRule4.Location = new Point(12, 81);
      this.radioRule4.Name = "radioRule4";
      this.radioRule4.Size = new Size(166, 17);
      this.radioRule4.TabIndex = 9;
      this.radioRule4.TabStop = true;
      this.radioRule4.Text = "Get the Teams from a League";
      this.radioRule4.UseVisualStyleBackColor = true;
      this.radioRule4.CheckedChanged += new EventHandler(this.radioRule4_CheckedChanged);
      this.radioRule5.AutoSize = true;
      this.radioRule5.Location = new Point(12, 130);
      this.radioRule5.Name = "radioRule5";
      this.radioRule5.Size = new Size(270, 17);
      this.radioRule5.TabIndex = 9;
      this.radioRule5.TabStop = true;
      this.radioRule5.Text = "Get Team(s) from a League with Country limitation to";
      this.radioRule5.UseVisualStyleBackColor = true;
      this.radioRule5.CheckedChanged += new EventHandler(this.radioRule5_CheckedChanged);
      this.radioRule6.AutoSize = true;
      this.radioRule6.Location = new Point(12, 153);
      this.radioRule6.Name = "radioRule6";
      this.radioRule6.Size = new Size(226, 17);
      this.radioRule6.TabIndex = 11;
      this.radioRule6.TabStop = true;
      this.radioRule6.Text = "Get N Teams from \"Special Teams Group\"";
      this.radioRule6.UseVisualStyleBackColor = true;
      this.radioRule6.CheckedChanged += new EventHandler(this.radioRule6_CheckedChanged);
      this.radioRule7.AutoSize = true;
      this.radioRule7.Location = new Point(12, 176);
      this.radioRule7.Name = "radioRule7";
      this.radioRule7.Size = new Size(209, 17);
      this.radioRule7.TabIndex = 13;
      this.radioRule7.TabStop = true;
      this.radioRule7.Text = "Get a specific Team in a given Position";
      this.radioRule7.UseVisualStyleBackColor = true;
      this.radioRule7.CheckedChanged += new EventHandler(this.radioRule7_CheckedChanged);
      this.comboTrophy1.FormattingEnabled = true;
      this.comboTrophy1.Location = new Point(12, 215);
      this.comboTrophy1.Name = "comboTrophy1";
      this.comboTrophy1.Size = new Size(205, 21);
      this.comboTrophy1.TabIndex = 14;
      this.comboTrophy1.SelectedIndexChanged += new EventHandler(this.comboTrophy1_SelectedIndexChanged);
      this.comboTrophy2.FormattingEnabled = true;
      this.comboTrophy2.Location = new Point(294, 214);
      this.comboTrophy2.Name = "comboTrophy2";
      this.comboTrophy2.Size = new Size(205, 21);
      this.comboTrophy2.TabIndex = 15;
      this.comboTrophy2.SelectedIndexChanged += new EventHandler(this.comboTrophy2_SelectedIndexChanged);
      this.comboLeague.FormattingEnabled = true;
      this.comboLeague.Location = new Point(294, 214);
      this.comboLeague.Name = "comboLeague";
      this.comboLeague.Size = new Size(205, 21);
      this.comboLeague.TabIndex = 16;
      this.comboLeague.SelectedIndexChanged += new EventHandler(this.comboLeague_SelectedIndexChanged);
      this.numericN.Location = new Point(222, 215);
      this.numericN.Name = "numericN";
      this.numericN.Size = new Size(66, 20);
      this.numericN.TabIndex = 17;
      this.numericN.TextAlign = HorizontalAlignment.Center;
      this.numericN.ValueChanged += new EventHandler(this.numericN_ValueChanged);
      this.comboTeam.FormattingEnabled = true;
      this.comboTeam.Location = new Point(12, 215);
      this.comboTeam.Name = "comboTeam";
      this.comboTeam.Size = new Size(204, 21);
      this.comboTeam.TabIndex = 18;
      this.comboTeam.SelectedIndexChanged += new EventHandler(this.comboTeam_SelectedIndexChanged);
      this.numericCountryLimitation.Location = new Point(288, 129);
      this.numericCountryLimitation.Maximum = new Decimal(new int[4]
      {
        8,
        0,
        0,
        0
      });
      this.numericCountryLimitation.Name = "numericCountryLimitation";
      this.numericCountryLimitation.Size = new Size(85, 20);
      this.numericCountryLimitation.TabIndex = 19;
      this.numericCountryLimitation.TextAlign = HorizontalAlignment.Center;
      this.numericCountryLimitation.Value = new Decimal(new int[4]
      {
        4,
        0,
        0,
        0
      });
      this.numericCountryLimitation.ValueChanged += new EventHandler(this.numericCountryLimitation_ValueChanged);
      this.radioRule8.AutoSize = true;
      this.radioRule8.Location = new Point(12, 104);
      this.radioRule8.Name = "radioRule8";
      this.radioRule8.Size = new Size(204, 17);
      this.radioRule8.TabIndex = 20;
      this.radioRule8.TabStop = true;
      this.radioRule8.Text = "Get the Teams from a League in order";
      this.radioRule8.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(512, 301);
      this.Controls.Add((Control) this.radioRule8);
      this.Controls.Add((Control) this.numericCountryLimitation);
      this.Controls.Add((Control) this.comboTeam);
      this.Controls.Add((Control) this.numericN);
      this.Controls.Add((Control) this.comboLeague);
      this.Controls.Add((Control) this.comboTrophy2);
      this.Controls.Add((Control) this.comboTrophy1);
      this.Controls.Add((Control) this.radioRule7);
      this.Controls.Add((Control) this.radioRule6);
      this.Controls.Add((Control) this.radioRule5);
      this.Controls.Add((Control) this.radioRule4);
      this.Controls.Add((Control) this.radioRule3);
      this.Controls.Add((Control) this.radioRule2);
      this.Controls.Add((Control) this.radioRule1);
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonOk);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Name = "QualifyRuleDialog";
      this.Text = "Qualification Rule";
      this.numericN.EndInit();
      this.numericCountryLimitation.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public Task QualifyRule
    {
      get
      {
        return this.m_QualifyRule;
      }
      set
      {
        this.m_QualifyRule = value;
        this.LoadToPanel();
      }
    }

    private void LoadToPanel()
    {
      this.Preset();
      this.m_Rule = this.m_QualifyRule.Rule;
      switch (this.m_Rule)
      {
        case EQualifyingRule.FillFromLeague:
          this.m_League = this.m_QualifyRule.League;
          this.comboLeague.SelectedItem = (object) this.m_League;
          this.radioRule4.Checked = true;
          break;
        case EQualifyingRule.FillFromCompTable:
          this.m_Trophy1 = this.m_QualifyRule.Trophy1;
          this.comboTrophy1.SelectedItem = (object) this.m_Trophy1;
          this.m_Number = this.m_QualifyRule.Parameter2;
          this.numericN.Value = (Decimal) this.m_Number;
          this.radioRule1.Checked = true;
          break;
        case EQualifyingRule.FillFromCompTableBackup:
          this.m_Trophy1 = this.m_QualifyRule.Trophy1;
          this.m_Trophy2 = this.m_QualifyRule.Trophy2;
          this.comboTrophy1.SelectedItem = (object) this.m_Trophy1;
          this.comboTrophy2.SelectedItem = (object) this.m_Trophy2;
          this.radioRule2.Checked = true;
          break;
        case EQualifyingRule.FillFromCompTableBackupLeague:
          this.m_Trophy1 = this.m_QualifyRule.Trophy1;
          this.m_League = this.m_QualifyRule.League;
          this.comboTrophy1.SelectedItem = (object) this.m_Trophy1;
          this.comboLeague.SelectedItem = (object) this.m_League;
          this.radioRule3.Checked = true;
          break;
        case EQualifyingRule.FillFromLeagueMaxFromCountry:
          this.m_League = this.m_QualifyRule.League;
          this.comboLeague.SelectedItem = (object) this.m_League;
          this.m_Number = this.m_QualifyRule.Parameter2;
          this.m_CountryLimitation = (uint) this.m_QualifyRule.Parameter3;
          this.numericN.Value = (Decimal) this.m_Number;
          this.numericCountryLimitation.Value = (Decimal) this.m_CountryLimitation;
          this.radioRule5.Checked = true;
          break;
        case EQualifyingRule.FillFromSpecialTeams:
          this.m_Number = this.m_QualifyRule.Parameter1;
          this.numericN.Value = (Decimal) this.m_Number;
          this.radioRule6.Checked = true;
          break;
        case EQualifyingRule.FillWithTeam:
          this.m_Team = this.m_QualifyRule.Team;
          this.comboTeam.SelectedItem = (object) this.m_Team;
          this.m_Number = this.m_QualifyRule.Parameter1;
          this.numericN.Value = (Decimal) this.m_Number;
          this.radioRule7.Checked = true;
          break;
      }
      this.EnableRule();
    }

    public void Preset()
    {
      if (this.comboTrophy1.Items.Count != FifaEnvironment.CompetitionObjects.Trophies.Count)
      {
        this.comboTrophy1.Items.Clear();
        this.comboTrophy1.Items.AddRange(FifaEnvironment.CompetitionObjects.Trophies.ToArray());
      }
      if (this.comboTrophy2.Items.Count != FifaEnvironment.CompetitionObjects.Trophies.Count)
      {
        this.comboTrophy2.Items.Clear();
        this.comboTrophy2.Items.AddRange(FifaEnvironment.CompetitionObjects.Trophies.ToArray());
      }
      if (this.comboLeague.Items.Count != FifaEnvironment.Leagues.Count)
      {
        this.comboLeague.Items.Clear();
        this.comboLeague.Items.AddRange(FifaEnvironment.Leagues.ToArray());
      }
      if (this.comboTeam.Items.Count == FifaEnvironment.Teams.Count)
        return;
      this.comboTeam.Items.Clear();
      this.comboTeam.Items.AddRange(FifaEnvironment.Teams.ToArray());
    }

    public QualifyRuleDialog()
    {
      this.InitializeComponent();
    }

    private void radioRule1_CheckedChanged(object sender, EventArgs e)
    {
      this.m_Rule = EQualifyingRule.FillFromCompTable;
      this.EnableRule();
    }

    private void radioRule2_CheckedChanged(object sender, EventArgs e)
    {
      this.m_Rule = EQualifyingRule.FillFromCompTableBackup;
      this.EnableRule();
    }

    private void radioRule3_CheckedChanged(object sender, EventArgs e)
    {
      this.m_Rule = EQualifyingRule.FillFromCompTableBackupLeague;
      this.EnableRule();
    }

    private void radioRule4_CheckedChanged(object sender, EventArgs e)
    {
      this.m_Rule = EQualifyingRule.FillFromLeague;
      this.EnableRule();
    }

    private void radioRule5_CheckedChanged(object sender, EventArgs e)
    {
      this.m_Rule = EQualifyingRule.FillFromLeagueMaxFromCountry;
      this.EnableRule();
    }

    private void radioRule6_CheckedChanged(object sender, EventArgs e)
    {
      this.m_Rule = EQualifyingRule.FillFromSpecialTeams;
      this.EnableRule();
    }

    private void radioRule7_CheckedChanged(object sender, EventArgs e)
    {
      this.m_Rule = EQualifyingRule.FillWithTeam;
      this.EnableRule();
    }

    private void radioRule8_CheckedChanged(object sender, EventArgs e)
    {
      this.m_Rule = EQualifyingRule.FillFromLeagueInOrder;
      this.EnableRule();
    }

    private void EnableRule()
    {
      switch (this.m_Rule)
      {
        case EQualifyingRule.FillFromLeague:
          this.comboLeague.SelectedItem = (object) this.m_League;
          this.comboTrophy1.Visible = false;
          this.comboTrophy2.Visible = false;
          this.comboLeague.Visible = true;
          this.comboTeam.Visible = false;
          this.numericN.Visible = false;
          this.numericCountryLimitation.Visible = false;
          break;
        case EQualifyingRule.FillFromLeagueInOrder:
          this.comboLeague.SelectedItem = (object) this.m_League;
          this.comboTrophy1.Visible = false;
          this.comboTrophy2.Visible = false;
          this.comboLeague.Visible = true;
          this.comboTeam.Visible = false;
          this.numericN.Visible = false;
          this.numericCountryLimitation.Visible = false;
          break;
        case EQualifyingRule.FillFromCompTable:
          this.comboTrophy1.SelectedItem = (object) this.m_Trophy1;
          this.numericN.Value = (Decimal) this.m_Number;
          this.comboTrophy1.Visible = true;
          this.comboTrophy2.Visible = false;
          this.comboLeague.Visible = false;
          this.comboTeam.Visible = false;
          this.numericN.Visible = true;
          this.numericCountryLimitation.Visible = false;
          this.m_Trophy1 = (Trophy) this.comboTrophy1.SelectedItem;
          break;
        case EQualifyingRule.FillFromCompTableBackup:
          this.comboTrophy1.SelectedItem = (object) this.m_Trophy1;
          this.comboTrophy2.SelectedItem = (object) this.m_Trophy2;
          this.comboTrophy1.Visible = true;
          this.comboTrophy2.Visible = true;
          this.comboLeague.Visible = false;
          this.comboTeam.Visible = false;
          this.numericN.Visible = false;
          this.numericCountryLimitation.Visible = false;
          break;
        case EQualifyingRule.FillFromCompTableBackupLeague:
          this.comboTrophy1.SelectedItem = (object) this.m_Trophy1;
          this.comboLeague.SelectedItem = (object) this.m_League;
          this.comboTrophy1.Visible = true;
          this.comboTrophy2.Visible = false;
          this.comboLeague.Visible = true;
          this.comboTeam.Visible = false;
          this.numericN.Visible = false;
          this.numericCountryLimitation.Visible = false;
          break;
        case EQualifyingRule.FillFromLeagueMaxFromCountry:
          this.comboLeague.SelectedItem = (object) this.m_League;
          this.numericCountryLimitation.Value = (Decimal) this.m_CountryLimitation;
          this.numericN.Value = (Decimal) this.m_Number;
          this.comboTrophy1.Visible = false;
          this.comboTrophy2.Visible = false;
          this.comboLeague.Visible = true;
          this.comboTeam.Visible = false;
          this.numericN.Visible = true;
          this.numericCountryLimitation.Visible = true;
          break;
        case EQualifyingRule.FillFromSpecialTeams:
          this.numericN.Value = (Decimal) this.m_Number;
          this.comboTrophy1.Visible = false;
          this.comboTrophy2.Visible = false;
          this.comboLeague.Visible = false;
          this.comboTeam.Visible = false;
          this.numericN.Visible = true;
          this.numericCountryLimitation.Visible = false;
          break;
        case EQualifyingRule.FillWithTeam:
          this.comboTeam.SelectedItem = (object) this.m_Team;
          this.numericN.Value = (Decimal) this.m_Number;
          this.comboTrophy1.Visible = false;
          this.comboTrophy2.Visible = false;
          this.comboLeague.Visible = false;
          this.comboTeam.Visible = true;
          this.numericN.Visible = true;
          this.numericCountryLimitation.Visible = false;
          break;
      }
    }

    private void comboTeam_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboTeam.SelectedItem == null)
        return;
      this.m_Team = (Team) this.comboTeam.SelectedItem;
    }

    private void numericN_ValueChanged(object sender, EventArgs e)
    {
      this.m_Number = (int) this.numericN.Value;
    }

    private void comboTrophy1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboTrophy1.SelectedItem == null)
        return;
      this.m_Trophy1 = (Trophy) this.comboTrophy1.SelectedItem;
    }

    private void comboLeague_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboLeague.SelectedItem == null)
        return;
      this.m_League = (League) this.comboLeague.SelectedItem;
    }

    private void comboTrophy2_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboTrophy2.SelectedItem == null)
        return;
      this.m_Trophy2 = (Trophy) this.comboTrophy2.SelectedItem;
    }

    private void buttonOk_Click(object sender, EventArgs e)
    {
      this.m_QualifyRule.Rule = this.m_Rule;
      switch (this.m_Rule)
      {
        case EQualifyingRule.FillFromLeague:
          if (this.m_League == null)
            break;
          this.m_QualifyRule.Parameter1 = this.m_League.Id;
          this.m_QualifyRule.League = this.m_League;
          this.m_QualifyRule.Parameter2 = 0;
          this.m_QualifyRule.Parameter3 = 0;
          break;
        case EQualifyingRule.FillFromCompTable:
          if (this.m_Trophy1 == null)
            break;
          this.m_QualifyRule.Parameter1 = this.m_Trophy1.Id;
          this.m_QualifyRule.Trophy1 = this.m_Trophy1;
          this.m_QualifyRule.Parameter2 = this.m_Number;
          this.m_QualifyRule.Parameter3 = 0;
          break;
        case EQualifyingRule.FillFromCompTableBackup:
          if (this.m_Trophy2 == null || this.m_Trophy1 == null)
            break;
          this.m_QualifyRule.Parameter1 = this.m_Trophy1.Id;
          this.m_QualifyRule.Trophy1 = this.m_Trophy1;
          this.m_QualifyRule.Parameter2 = this.m_Trophy2.Id;
          this.m_QualifyRule.Trophy2 = this.m_Trophy2;
          this.m_QualifyRule.Parameter3 = 1;
          break;
        case EQualifyingRule.FillFromCompTableBackupLeague:
          if (this.m_League == null || this.m_Trophy1 == null)
            break;
          this.m_QualifyRule.Parameter1 = this.m_Trophy1.Id;
          this.m_QualifyRule.Trophy1 = this.m_Trophy1;
          this.m_QualifyRule.Parameter2 = this.m_League.Id;
          this.m_QualifyRule.League = this.m_League;
          this.m_QualifyRule.Parameter3 = 1;
          break;
        case EQualifyingRule.FillFromLeagueMaxFromCountry:
          if (this.m_League == null)
            break;
          this.m_QualifyRule.Parameter1 = this.m_League.Id;
          this.m_QualifyRule.League = this.m_League;
          this.m_QualifyRule.Parameter2 = this.m_Number;
          this.m_QualifyRule.Parameter3 = (int) this.m_CountryLimitation;
          break;
        case EQualifyingRule.FillFromSpecialTeams:
          this.m_QualifyRule.Parameter1 = this.m_Number;
          this.m_QualifyRule.Parameter2 = 0;
          this.m_QualifyRule.Parameter3 = 0;
          break;
        case EQualifyingRule.FillWithTeam:
          if (this.m_Team == null)
            break;
          this.m_QualifyRule.Parameter1 = this.m_Number;
          this.m_QualifyRule.Parameter2 = this.m_Team.Id;
          this.m_QualifyRule.Team = this.m_Team;
          this.m_QualifyRule.Parameter3 = 0;
          break;
      }
    }

    private void numericCountryLimitation_ValueChanged(object sender, EventArgs e)
    {
      this.m_CountryLimitation = (uint) this.numericCountryLimitation.Value;
    }
  }
}
