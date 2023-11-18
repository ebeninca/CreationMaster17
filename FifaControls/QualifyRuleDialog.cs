﻿// Original code created by Rinaldo

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
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private NumericUpDown numericChampionsCountryLimitation;
        private RadioButton radioButton3;
        private Label label13;
        private uint m_CountryLimitation;
        private uint m_ChampionsCountryLimitation;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.radioRule1 = new System.Windows.Forms.RadioButton();
            this.radioRule2 = new System.Windows.Forms.RadioButton();
            this.radioRule3 = new System.Windows.Forms.RadioButton();
            this.radioRule4 = new System.Windows.Forms.RadioButton();
            this.radioRule5 = new System.Windows.Forms.RadioButton();
            this.radioRule6 = new System.Windows.Forms.RadioButton();
            this.radioRule7 = new System.Windows.Forms.RadioButton();
            this.comboTrophy1 = new System.Windows.Forms.ComboBox();
            this.comboTrophy2 = new System.Windows.Forms.ComboBox();
            this.comboLeague = new System.Windows.Forms.ComboBox();
            this.numericN = new System.Windows.Forms.NumericUpDown();
            this.comboTeam = new System.Windows.Forms.ComboBox();
            this.numericCountryLimitation = new System.Windows.Forms.NumericUpDown();
            this.radioRule8 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.numericChampionsCountryLimitation = new System.Windows.Forms.NumericUpDown();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCountryLimitation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericChampionsCountryLimitation)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(89, 346);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(327, 346);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // radioRule1
            // 
            this.radioRule1.AutoSize = true;
            this.radioRule1.Location = new System.Drawing.Point(12, 12);
            this.radioRule1.Name = "radioRule1";
            this.radioRule1.Size = new System.Drawing.Size(193, 17);
            this.radioRule1.TabIndex = 2;
            this.radioRule1.TabStop = true;
            this.radioRule1.Text = "Get the Best N Team(s) of a Trophy";
            this.radioRule1.UseVisualStyleBackColor = true;
            this.radioRule1.CheckedChanged += new System.EventHandler(this.radioRule1_CheckedChanged);
            // 
            // radioRule2
            // 
            this.radioRule2.AutoSize = true;
            this.radioRule2.Location = new System.Drawing.Point(12, 35);
            this.radioRule2.Name = "radioRule2";
            this.radioRule2.Size = new System.Drawing.Size(303, 17);
            this.radioRule2.TabIndex = 5;
            this.radioRule2.TabStop = true;
            this.radioRule2.Text = "Get the Winner of a Trophy or a Team from another Trophy";
            this.radioRule2.UseVisualStyleBackColor = true;
            this.radioRule2.CheckedChanged += new System.EventHandler(this.radioRule2_CheckedChanged);
            // 
            // radioRule3
            // 
            this.radioRule3.AutoSize = true;
            this.radioRule3.Location = new System.Drawing.Point(12, 58);
            this.radioRule3.Name = "radioRule3";
            this.radioRule3.Size = new System.Drawing.Size(276, 17);
            this.radioRule3.TabIndex = 7;
            this.radioRule3.TabStop = true;
            this.radioRule3.Text = "Get the Winner of a Trophy or a Team from a League";
            this.radioRule3.UseVisualStyleBackColor = true;
            this.radioRule3.CheckedChanged += new System.EventHandler(this.radioRule3_CheckedChanged);
            // 
            // radioRule4
            // 
            this.radioRule4.AutoSize = true;
            this.radioRule4.Location = new System.Drawing.Point(12, 81);
            this.radioRule4.Name = "radioRule4";
            this.radioRule4.Size = new System.Drawing.Size(166, 17);
            this.radioRule4.TabIndex = 9;
            this.radioRule4.TabStop = true;
            this.radioRule4.Text = "Get the Teams from a League";
            this.radioRule4.UseVisualStyleBackColor = true;
            this.radioRule4.CheckedChanged += new System.EventHandler(this.radioRule4_CheckedChanged);
            // 
            // radioRule5
            // 
            this.radioRule5.AutoSize = true;
            this.radioRule5.Location = new System.Drawing.Point(12, 129);
            this.radioRule5.Name = "radioRule5";
            this.radioRule5.Size = new System.Drawing.Size(270, 17);
            this.radioRule5.TabIndex = 9;
            this.radioRule5.TabStop = true;
            this.radioRule5.Text = "Get Team(s) from a League with Country limitation to";
            this.radioRule5.UseVisualStyleBackColor = true;
            this.radioRule5.CheckedChanged += new System.EventHandler(this.radioRule5_CheckedChanged);
            // 
            // radioRule6
            // 
            this.radioRule6.AutoSize = true;
            this.radioRule6.Location = new System.Drawing.Point(12, 153);
            this.radioRule6.Name = "radioRule6";
            this.radioRule6.Size = new System.Drawing.Size(226, 17);
            this.radioRule6.TabIndex = 11;
            this.radioRule6.TabStop = true;
            this.radioRule6.Text = "Get N Teams from \"Special Teams Group\"";
            this.radioRule6.UseVisualStyleBackColor = true;
            this.radioRule6.CheckedChanged += new System.EventHandler(this.radioRule6_CheckedChanged);
            // 
            // radioRule7
            // 
            this.radioRule7.AutoSize = true;
            this.radioRule7.Location = new System.Drawing.Point(12, 176);
            this.radioRule7.Name = "radioRule7";
            this.radioRule7.Size = new System.Drawing.Size(209, 17);
            this.radioRule7.TabIndex = 13;
            this.radioRule7.TabStop = true;
            this.radioRule7.Text = "Get a specific Team in a given Position";
            this.radioRule7.UseVisualStyleBackColor = true;
            this.radioRule7.CheckedChanged += new System.EventHandler(this.radioRule7_CheckedChanged);
            // 
            // comboTrophy1
            // 
            this.comboTrophy1.FormattingEnabled = true;
            this.comboTrophy1.Location = new System.Drawing.Point(12, 303);
            this.comboTrophy1.Name = "comboTrophy1";
            this.comboTrophy1.Size = new System.Drawing.Size(205, 21);
            this.comboTrophy1.TabIndex = 14;
            this.comboTrophy1.SelectedIndexChanged += new System.EventHandler(this.comboTrophy1_SelectedIndexChanged);
            // 
            // comboTrophy2
            // 
            this.comboTrophy2.FormattingEnabled = true;
            this.comboTrophy2.Location = new System.Drawing.Point(294, 302);
            this.comboTrophy2.Name = "comboTrophy2";
            this.comboTrophy2.Size = new System.Drawing.Size(205, 21);
            this.comboTrophy2.TabIndex = 15;
            this.comboTrophy2.SelectedIndexChanged += new System.EventHandler(this.comboTrophy2_SelectedIndexChanged);
            // 
            // comboLeague
            // 
            this.comboLeague.FormattingEnabled = true;
            this.comboLeague.Location = new System.Drawing.Point(294, 302);
            this.comboLeague.Name = "comboLeague";
            this.comboLeague.Size = new System.Drawing.Size(205, 21);
            this.comboLeague.TabIndex = 16;
            this.comboLeague.SelectedIndexChanged += new System.EventHandler(this.comboLeague_SelectedIndexChanged);
            // 
            // numericN
            // 
            this.numericN.Location = new System.Drawing.Point(222, 303);
            this.numericN.Name = "numericN";
            this.numericN.Size = new System.Drawing.Size(66, 20);
            this.numericN.TabIndex = 17;
            this.numericN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericN.ValueChanged += new System.EventHandler(this.numericN_ValueChanged);
            // 
            // comboTeam
            // 
            this.comboTeam.FormattingEnabled = true;
            this.comboTeam.Location = new System.Drawing.Point(12, 303);
            this.comboTeam.Name = "comboTeam";
            this.comboTeam.Size = new System.Drawing.Size(204, 21);
            this.comboTeam.TabIndex = 18;
            this.comboTeam.SelectedIndexChanged += new System.EventHandler(this.comboTeam_SelectedIndexChanged);
            // 
            // numericCountryLimitation
            // 
            this.numericCountryLimitation.Location = new System.Drawing.Point(283, 128);
            this.numericCountryLimitation.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericCountryLimitation.Name = "numericCountryLimitation";
            this.numericCountryLimitation.Size = new System.Drawing.Size(66, 20);
            this.numericCountryLimitation.TabIndex = 19;
            this.numericCountryLimitation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericCountryLimitation.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericCountryLimitation.ValueChanged += new System.EventHandler(this.numericCountryLimitation_ValueChanged);
            // 
            // radioRule8
            // 
            this.radioRule8.AutoSize = true;
            this.radioRule8.Location = new System.Drawing.Point(12, 104);
            this.radioRule8.Name = "radioRule8";
            this.radioRule8.Size = new System.Drawing.Size(204, 17);
            this.radioRule8.TabIndex = 20;
            this.radioRule8.TabStop = true;
            this.radioRule8.Text = "Get the Teams from a League in order";
            this.radioRule8.UseVisualStyleBackColor = true;
            this.radioRule8.CheckedChanged += new System.EventHandler(this.radioRule8_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 245);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(196, 17);
            this.radioButton1.TabIndex = 21;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Get the Euro League Playoff Winner";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(12, 268);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(224, 17);
            this.radioButton2.TabIndex = 22;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Get the Euro League Group Stage Winner";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // numericChampionsCountryLimitation
            // 
            this.numericChampionsCountryLimitation.Location = new System.Drawing.Point(283, 221);
            this.numericChampionsCountryLimitation.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericChampionsCountryLimitation.Name = "numericChampionsCountryLimitation";
            this.numericChampionsCountryLimitation.Size = new System.Drawing.Size(66, 20);
            this.numericChampionsCountryLimitation.TabIndex = 24;
            this.numericChampionsCountryLimitation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericChampionsCountryLimitation.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericChampionsCountryLimitation.ValueChanged += new System.EventHandler(this.numericChampionsCountryLimitation_ValueChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(12, 222);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(270, 17);
            this.radioButton3.TabIndex = 23;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Get Team(s) from a League with Country limitation to";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(354, 224);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "for Champions Cup";
            // 
            // QualifyRuleDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 389);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.numericChampionsCountryLimitation);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.radioRule8);
            this.Controls.Add(this.numericCountryLimitation);
            this.Controls.Add(this.comboTeam);
            this.Controls.Add(this.numericN);
            this.Controls.Add(this.comboLeague);
            this.Controls.Add(this.comboTrophy2);
            this.Controls.Add(this.comboTrophy1);
            this.Controls.Add(this.radioRule7);
            this.Controls.Add(this.radioRule6);
            this.Controls.Add(this.radioRule5);
            this.Controls.Add(this.radioRule4);
            this.Controls.Add(this.radioRule3);
            this.Controls.Add(this.radioRule2);
            this.Controls.Add(this.radioRule1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "QualifyRuleDialog";
            this.Text = "Qualification Rule";
            ((System.ComponentModel.ISupportInitialize)(this.numericN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCountryLimitation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericChampionsCountryLimitation)).EndInit();
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
                    this.comboLeague.SelectedItem = (object)this.m_League;
                    this.radioRule4.Checked = true;
                    break;
                case EQualifyingRule.FillFromCompTable:
                    this.m_Trophy1 = this.m_QualifyRule.Trophy1;
                    this.comboTrophy1.SelectedItem = (object)this.m_Trophy1;
                    this.m_Number = this.m_QualifyRule.Parameter2;
                    this.numericN.Value = (Decimal)this.m_Number;
                    this.radioRule1.Checked = true;
                    break;
                case EQualifyingRule.FillFromCompTableBackup:
                    this.m_Trophy1 = this.m_QualifyRule.Trophy1;
                    this.m_Trophy2 = this.m_QualifyRule.Trophy2;
                    this.comboTrophy1.SelectedItem = (object)this.m_Trophy1;
                    this.comboTrophy2.SelectedItem = (object)this.m_Trophy2;
                    this.radioRule2.Checked = true;
                    break;
                case EQualifyingRule.FillFromCompTableBackupLeague:
                    this.m_Trophy1 = this.m_QualifyRule.Trophy1;
                    this.m_League = this.m_QualifyRule.League;
                    this.comboTrophy1.SelectedItem = (object)this.m_Trophy1;
                    this.comboLeague.SelectedItem = (object)this.m_League;
                    this.radioRule3.Checked = true;
                    break;
                case EQualifyingRule.FillFromLeagueMaxFromCountry:
                    this.m_League = this.m_QualifyRule.League;
                    this.comboLeague.SelectedItem = (object)this.m_League;
                    this.m_Number = this.m_QualifyRule.Parameter2;
                    this.m_CountryLimitation = (uint)this.m_QualifyRule.Parameter3;
                    this.numericN.Value = (Decimal)this.m_Number;
                    this.numericCountryLimitation.Value = (Decimal)this.m_CountryLimitation;
                    this.radioRule5.Checked = true;
                    break;
                case EQualifyingRule.FillChampionsCup:
                    this.m_League = this.m_QualifyRule.League;
                    this.comboLeague.SelectedItem = (object)this.m_League;
                    this.m_Number = this.m_QualifyRule.Parameter2;
                    this.m_ChampionsCountryLimitation = (uint)this.m_QualifyRule.Parameter3;
                    this.numericN.Value = (Decimal)this.m_Number;
                    this.numericCountryLimitation.Value = (Decimal)this.m_ChampionsCountryLimitation;
                    this.radioButton3.Checked = true;
                    break;
                case EQualifyingRule.FillFromSpecialTeams:
                    this.m_Number = this.m_QualifyRule.Parameter1;
                    this.numericN.Value = (Decimal)this.m_Number;
                    this.radioRule6.Checked = true;
                    break;
                case EQualifyingRule.FillEuroLeagueWinnerGroupStage:
                    this.m_Number = this.m_QualifyRule.Parameter1;
                    this.numericN.Value = (Decimal)this.m_Number;
                    this.radioButton2.Checked = true;
                    break;
                case EQualifyingRule.FillEuroLeagueWinnerPlayoff:
                    this.m_Number = this.m_QualifyRule.Parameter1;
                    this.numericN.Value = (Decimal)this.m_Number;
                    this.radioButton1.Checked = true;
                    break;
                case EQualifyingRule.FillWithTeam:
                    this.m_Team = this.m_QualifyRule.Team;
                    this.comboTeam.SelectedItem = (object)this.m_Team;
                    this.m_Number = this.m_QualifyRule.Parameter1;
                    this.numericN.Value = (Decimal)this.m_Number;
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.m_Rule = EQualifyingRule.FillEuroLeagueWinnerPlayoff;
            this.EnableRule();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.m_Rule = EQualifyingRule.FillEuroLeagueWinnerGroupStage;
            this.EnableRule();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.m_Rule = EQualifyingRule.FillChampionsCup;
            this.EnableRule();
        }

        private void EnableRule()
        {
            switch (this.m_Rule)
            {
                case EQualifyingRule.FillFromLeague:
                    this.comboLeague.SelectedItem = (object)this.m_League;
                    this.comboTrophy1.Visible = false;
                    this.comboTrophy2.Visible = false;
                    this.comboLeague.Visible = true;
                    this.comboTeam.Visible = false;
                    this.numericN.Visible = false;
                    this.numericCountryLimitation.Visible = false;
                    this.numericChampionsCountryLimitation.Visible = false;
                    break;
                case EQualifyingRule.FillFromLeagueInOrder:
                    this.comboLeague.SelectedItem = (object)this.m_League;
                    this.comboTrophy1.Visible = false;
                    this.comboTrophy2.Visible = false;
                    this.comboLeague.Visible = true;
                    this.comboTeam.Visible = false;
                    this.numericN.Visible = false;
                    this.numericCountryLimitation.Visible = false;
                    this.numericChampionsCountryLimitation.Visible = false;
                    break;
                case EQualifyingRule.FillFromCompTable:
                    this.comboTrophy1.SelectedItem = (object)this.m_Trophy1;
                    this.numericN.Value = (Decimal)this.m_Number;
                    this.comboTrophy1.Visible = true;
                    this.comboTrophy2.Visible = false;
                    this.comboLeague.Visible = false;
                    this.comboTeam.Visible = false;
                    this.numericN.Visible = true;
                    this.numericCountryLimitation.Visible = false;
                    this.numericChampionsCountryLimitation.Visible = false;
                    this.m_Trophy1 = (Trophy)this.comboTrophy1.SelectedItem;
                    break;
                case EQualifyingRule.FillFromCompTableBackup:
                    this.comboTrophy1.SelectedItem = (object)this.m_Trophy1;
                    this.comboTrophy2.SelectedItem = (object)this.m_Trophy2;
                    this.comboTrophy1.Visible = true;
                    this.comboTrophy2.Visible = true;
                    this.comboLeague.Visible = false;
                    this.comboTeam.Visible = false;
                    this.numericN.Visible = false;
                    this.numericCountryLimitation.Visible = false;
                    this.numericChampionsCountryLimitation.Visible = false;
                    break;
                case EQualifyingRule.FillFromCompTableBackupLeague:
                    this.comboTrophy1.SelectedItem = (object)this.m_Trophy1;
                    this.comboLeague.SelectedItem = (object)this.m_League;
                    this.comboTrophy1.Visible = true;
                    this.comboTrophy2.Visible = false;
                    this.comboLeague.Visible = true;
                    this.comboTeam.Visible = false;
                    this.numericN.Visible = false;
                    this.numericCountryLimitation.Visible = false;
                    this.numericChampionsCountryLimitation.Visible = false;
                    break;
                case EQualifyingRule.FillFromLeagueMaxFromCountry:
                    this.comboLeague.SelectedItem = (object)this.m_League;
                    this.numericCountryLimitation.Value = (Decimal)this.m_CountryLimitation;
                    this.numericN.Value = (Decimal)this.m_Number;
                    this.comboTrophy1.Visible = false;
                    this.comboTrophy2.Visible = false;
                    this.comboLeague.Visible = true;
                    this.comboTeam.Visible = false;
                    this.numericN.Visible = true;
                    this.numericCountryLimitation.Visible = true;
                    this.numericChampionsCountryLimitation.Visible = false;
                    break;
                case EQualifyingRule.FillChampionsCup:
                    this.comboLeague.SelectedItem = (object)this.m_League;
                    this.numericChampionsCountryLimitation.Value = (Decimal)this.m_ChampionsCountryLimitation;
                    this.numericN.Value = (Decimal)this.m_Number;
                    this.comboTrophy1.Visible = false;
                    this.comboTrophy2.Visible = false;
                    this.comboLeague.Visible = true;
                    this.comboTeam.Visible = false;
                    this.numericN.Visible = true;
                    this.numericCountryLimitation.Visible = false;
                    this.numericChampionsCountryLimitation.Visible = true;
                    break;
                case EQualifyingRule.FillFromSpecialTeams:
                    this.numericN.Value = (Decimal)this.m_Number;
                    this.comboTrophy1.Visible = false;
                    this.comboTrophy2.Visible = false;
                    this.comboLeague.Visible = false;
                    this.comboTeam.Visible = false;
                    this.numericN.Visible = true;
                    this.numericCountryLimitation.Visible = false;
                    this.numericChampionsCountryLimitation.Visible = false;
                    break;
                case EQualifyingRule.FillEuroLeagueWinnerGroupStage:
                case EQualifyingRule.FillEuroLeagueWinnerPlayoff:
                    this.numericN.Value = 0;
                    this.comboTrophy1.Visible = false;
                    this.comboTrophy2.Visible = false;
                    this.comboLeague.Visible = false;
                    this.comboTeam.Visible = false;
                    this.numericN.Visible = false;
                    this.numericCountryLimitation.Visible = false;
                    this.numericChampionsCountryLimitation.Visible = false;
                    break;
                case EQualifyingRule.FillWithTeam:
                    this.comboTeam.SelectedItem = (object)this.m_Team;
                    this.numericN.Value = (Decimal)this.m_Number;
                    this.comboTrophy1.Visible = false;
                    this.comboTrophy2.Visible = false;
                    this.comboLeague.Visible = false;
                    this.comboTeam.Visible = true;
                    this.numericN.Visible = true;
                    this.numericCountryLimitation.Visible = false;
                    this.numericChampionsCountryLimitation.Visible = false;
                    break;
            }
        }

        private void comboTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboTeam.SelectedItem == null)
                return;
            this.m_Team = (Team)this.comboTeam.SelectedItem;
        }

        private void numericN_ValueChanged(object sender, EventArgs e)
        {
            this.m_Number = (int)this.numericN.Value;
        }

        private void comboTrophy1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboTrophy1.SelectedItem == null)
                return;
            this.m_Trophy1 = (Trophy)this.comboTrophy1.SelectedItem;
        }

        private void comboLeague_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboLeague.SelectedItem == null)
                return;
            this.m_League = (League)this.comboLeague.SelectedItem;
        }

        private void comboTrophy2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboTrophy2.SelectedItem == null)
                return;
            this.m_Trophy2 = (Trophy)this.comboTrophy2.SelectedItem;
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
                    this.m_QualifyRule.Parameter3 = (int)this.m_CountryLimitation;
                    break;
                case EQualifyingRule.FillChampionsCup:
                    if (this.m_League == null)
                        break;
                    this.m_QualifyRule.Parameter1 = this.m_League.Id;
                    this.m_QualifyRule.League = this.m_League;
                    this.m_QualifyRule.Parameter2 = this.m_Number;
                    this.m_QualifyRule.Parameter3 = (int)this.m_ChampionsCountryLimitation;
                    break;
                case EQualifyingRule.FillFromSpecialTeams:
                    this.m_QualifyRule.Parameter1 = this.m_Number;
                    this.m_QualifyRule.Parameter2 = 0;
                    this.m_QualifyRule.Parameter3 = 0;
                    break;
                case EQualifyingRule.FillEuroLeagueWinnerPlayoff:
                case EQualifyingRule.FillEuroLeagueWinnerGroupStage:
                    this.m_QualifyRule.Parameter1 = 0;
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
            this.m_CountryLimitation = (uint)this.numericCountryLimitation.Value;
        }

        private void numericChampionsCountryLimitation_ValueChanged(object sender, EventArgs e)
        {
            this.m_ChampionsCountryLimitation = (uint)this.numericChampionsCountryLimitation.Value;
        }
    }
}
