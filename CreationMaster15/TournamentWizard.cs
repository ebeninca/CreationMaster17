// Original code created by Rinaldo

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CreationMaster
{
  public class TournamentWizard : Form
  {
    private int m_TournamentStructure;
    private int m_LeagueGames;
    private int m_PreliminaryGames;
    private int m_GroupGames;
    private int m_KnockOutGames;
    private int m_FinalGames;
    private int m_NTeams;
    private int m_NPreliminaryTeams;
    private int m_NKnockOutTeams;
    private int m_NTeamsInGroups;
    private int m_NGroups;
    private int m_NTeamsPerGroup;
    private IContainer components;
    private Button buttonCancel;
    private Button buttonOK;
    private GroupBox groupKO;
    private NumericUpDown numericFinalGames;
    private NumericUpDown numericKOGames;
    private DomainUpDown domainNTeamsKO;
    private Label labelFinalGames;
    private Label labelNTeamsKO;
    private Label labelKnockOutGames;
    private GroupBox groupGroups;
    private NumericUpDown numericGamesPerGroup;
    private NumericUpDown numericTeamsPerGroup;
    private DomainUpDown domainNGroups;
    private Label labelGamesPerGroup;
    private Label labelNumberofGroups;
    private Label labelTeamPerGroup;
    private GroupBox groupPreliminary;
    private NumericUpDown numericPrelimGames;
    private NumericUpDown numericPreliminaryTeams;
    private Label labelNumberofGames;
    private Label labelPrelimNTeams;
    private GroupBox groupStructure;
    private RadioButton radioEuro2008;
    private RadioButton radioEuro2004;
    private RadioButton radioWC2006;
    private RadioButton radioPGKO;
    private RadioButton radioPKO;
    private RadioButton radioGKO;
    private RadioButton radioKO;
    private RadioButton radioLeague;
    private NumericUpDown numericNTeams;
    private Label labelNumberofTeams;
    private GroupBox groupLeague;
    private NumericUpDown numericLeagueGames;
    private Label labelLeagueGames;
    private GroupBox groupQualification;
    private Label labelLeagueReadHelp;

    public int TournamentStructure
    {
      get
      {
        return this.m_TournamentStructure;
      }
    }

    public int LeagueGames
    {
      get
      {
        return this.m_LeagueGames;
      }
    }

    public int PreliminaryGames
    {
      get
      {
        return this.m_PreliminaryGames;
      }
    }

    public int GroupGames
    {
      get
      {
        return this.m_GroupGames;
      }
    }

    public int KnockOutGames
    {
      get
      {
        return this.m_KnockOutGames;
      }
    }

    public int FinalGames
    {
      get
      {
        return this.m_FinalGames;
      }
    }

    public int NTeams
    {
      get
      {
        return this.m_NTeams;
      }
    }

    public int NPreliminaryTeams
    {
      get
      {
        return this.m_NPreliminaryTeams;
      }
    }

    public int NKnockOutTeams
    {
      get
      {
        return this.m_NKnockOutTeams;
      }
    }

    public int NTeamsInGroups
    {
      get
      {
        return this.m_NTeamsInGroups;
      }
    }

    public int NGroups
    {
      get
      {
        return this.m_NGroups;
      }
    }

    public int NTeamsPerGroup
    {
      get
      {
        return this.m_NTeamsPerGroup;
      }
    }

    public TournamentWizard()
    {
      this.InitializeComponent();
      this.m_NTeams = 3;
      this.m_TournamentStructure = 0;
      this.m_LeagueGames = 1;
      this.m_NKnockOutTeams = 2;
      this.m_KnockOutGames = 1;
      this.m_FinalGames = 1;
      this.m_NGroups = 1;
      this.m_NTeamsPerGroup = 0;
      this.m_GroupGames = 1;
      this.m_NPreliminaryTeams = 0;
      this.m_PreliminaryGames = 2;
    }

    private void numericNTeams_ValueChanged(object sender, EventArgs e)
    {
      this.m_NTeams = (int) this.numericNTeams.Value;
      this.InitOptions();
      this.ToPanel();
    }

    private void ToPanel()
    {
      this.RadioToPanel();
      this.OptionsToPanel();
      this.OkButtonToPanel();
    }

    private void RadioToPanel()
    {
      if (this.numericNTeams.Value >= new Decimal(3) && this.numericNTeams.Value <= new Decimal(24))
      {
        this.radioLeague.Enabled = true;
      }
      else
      {
        this.radioLeague.Enabled = false;
        this.radioLeague.Checked = false;
      }
      if (this.numericNTeams.Value == new Decimal(2) || this.numericNTeams.Value == new Decimal(4) || (this.numericNTeams.Value == new Decimal(8) || this.numericNTeams.Value == new Decimal(16)) || (this.numericNTeams.Value == new Decimal(32) || this.numericNTeams.Value == new Decimal(64)))
      {
        this.radioKO.Enabled = true;
      }
      else
      {
        this.radioKO.Enabled = false;
        this.radioKO.Checked = false;
      }
      if (this.numericNTeams.Value >= new Decimal(3))
      {
        if (this.numericNTeams.Value <= new Decimal(16) || ((int) this.numericNTeams.Value & 1) == 0 && this.numericNTeams.Value <= new Decimal(32) || ((int) this.numericNTeams.Value & 3) == 0 && this.numericNTeams.Value <= new Decimal(64))
        {
          this.radioGKO.Enabled = true;
        }
        else
        {
          this.radioGKO.Enabled = false;
          this.radioGKO.Checked = false;
        }
      }
      else
      {
        this.radioGKO.Enabled = false;
        this.radioGKO.Checked = false;
      }
      if (this.numericNTeams.Value >= new Decimal(3) && this.numericNTeams.Value != new Decimal(4) && (this.numericNTeams.Value != new Decimal(8) && this.numericNTeams.Value != new Decimal(16)) && (this.numericNTeams.Value != new Decimal(32) && this.numericNTeams.Value != new Decimal(64)))
      {
        this.radioPKO.Enabled = true;
      }
      else
      {
        this.radioPKO.Enabled = false;
        this.radioPKO.Checked = false;
      }
      if (this.numericNTeams.Value > new Decimal(8) && this.numericNTeams.Value != new Decimal(16) && (this.numericNTeams.Value != new Decimal(32) && this.numericNTeams.Value != new Decimal(64)))
      {
        this.radioPGKO.Enabled = true;
      }
      else
      {
        this.radioPGKO.Enabled = false;
        this.radioPGKO.Checked = false;
      }
    }

    private void OkButtonToPanel()
    {
      if (this.radioLeague.Checked || this.radioKO.Checked || (this.radioPKO.Checked || this.radioGKO.Checked) || (this.radioPGKO.Checked || this.radioWC2006.Checked || (this.radioEuro2008.Checked || this.radioEuro2004.Checked)))
        this.buttonOK.Enabled = true;
      else
        this.buttonOK.Enabled = false;
    }

    private void OptionsToPanel()
    {
      if (this.radioKO.Checked || this.radioGKO.Checked || (this.radioPKO.Checked || this.radioPGKO.Checked))
      {
        this.groupKO.Enabled = this.groupKO.Visible = true;
        this.KOToPanel();
      }
      else
        this.groupKO.Visible = false;
      if (this.radioPKO.Checked || this.radioPGKO.Checked)
      {
        this.groupPreliminary.Enabled = this.groupPreliminary.Visible = true;
        this.PreliminaryToPanel();
      }
      else
        this.groupPreliminary.Visible = false;
      if (this.radioGKO.Checked || this.radioPGKO.Checked)
      {
        this.groupGroups.Enabled = this.groupGroups.Visible = true;
        this.GroupToPanel();
      }
      else
        this.groupGroups.Visible = false;
      if (this.radioLeague.Checked)
      {
        this.groupLeague.Visible = true;
        this.LeagueToPanel();
      }
      else
        this.groupLeague.Visible = false;
      if (this.radioWC2006.Checked || this.radioEuro2008.Checked || this.radioEuro2004.Checked)
      {
        this.groupQualification.Visible = true;
        this.groupGroups.Visible = false;
        this.groupKO.Visible = false;
        this.groupGroups.Enabled = false;
        this.groupKO.Enabled = false;
      }
      else
        this.groupQualification.Visible = false;
    }

    private void GroupToPanel()
    {
      this.domainNGroups.SelectedItem = (object) this.m_NGroups.ToString();
      this.domainNGroups.Text = this.m_NGroups.ToString();
      this.numericTeamsPerGroup.Value = (Decimal) this.m_NTeamsPerGroup;
      this.numericGamesPerGroup.Value = (Decimal) this.m_GroupGames;
    }

    private void KOToPanel()
    {
      this.domainNTeamsKO.SelectedItem = (object) this.m_NKnockOutTeams.ToString();
      this.domainNTeamsKO.Text = this.m_NKnockOutTeams.ToString();
      this.numericFinalGames.Value = (Decimal) this.m_FinalGames;
      this.numericKOGames.Value = (Decimal) this.m_KnockOutGames;
    }

    private void PreliminaryToPanel()
    {
      this.numericPrelimGames.Value = (Decimal) this.m_PreliminaryGames;
      this.numericPreliminaryTeams.Value = (Decimal) this.m_NPreliminaryTeams;
    }

    private void LeagueToPanel()
    {
      this.numericLeagueGames.Value = (Decimal) this.m_LeagueGames;
    }

    private void InitOptions()
    {
      this.InitGroupsOptions();
      this.InitKnockOutOptions();
    }

    private void InitGroupsOptions()
    {
      switch (this.m_TournamentStructure)
      {
        case 3:
          this.domainNGroups.Items.Clear();
          this.m_NTeamsInGroups = this.m_NTeams;
          if (this.m_NTeamsInGroups % 16 == 0 && this.m_NTeamsInGroups >= 48)
          {
            this.domainNGroups.Items.Add((object) "16");
            this.m_NGroups = 16;
          }
          if (this.m_NTeamsInGroups % 8 == 0 && this.m_NTeamsInGroups >= 24)
          {
            this.domainNGroups.Items.Add((object) "8");
            this.m_NGroups = 8;
          }
          if (this.m_NTeamsInGroups % 4 == 0 && this.m_NTeamsInGroups >= 12 && this.m_NTeamsInGroups <= 64)
          {
            this.domainNGroups.Items.Add((object) "4");
            this.m_NGroups = 4;
          }
          if (this.m_NTeamsInGroups % 2 == 0 && this.m_NTeamsInGroups >= 6 && this.m_NTeamsInGroups <= 32)
          {
            this.domainNGroups.Items.Add((object) "2");
            this.m_NGroups = 2;
          }
          if (this.m_NTeamsInGroups <= 16)
          {
            this.domainNGroups.Items.Add((object) "1");
            this.m_NGroups = 1;
          }
          this.domainNGroups.SelectedItem = (object) this.m_NGroups.ToString();
          this.m_NTeamsPerGroup = this.m_NTeamsInGroups / this.m_NGroups;
          break;
        case 4:
          this.m_NTeamsInGroups = (int) Math.Pow(2.0, Math.Floor(Math.Log((double) this.m_NTeams - 1.0, 2.0)));
          this.domainNGroups.Items.Clear();
          if (this.m_NTeamsInGroups % 8 == 0 && this.m_NTeamsInGroups >= 24)
          {
            this.domainNGroups.Items.Add((object) "8");
            this.m_NGroups = 8;
          }
          if (this.m_NTeamsInGroups % 4 == 0 && this.m_NTeamsInGroups >= 12 && this.m_NTeamsInGroups <= 64)
          {
            this.domainNGroups.Items.Add((object) "4");
            this.m_NGroups = 4;
          }
          if (this.m_NTeamsInGroups % 2 == 0 && this.m_NTeamsInGroups >= 6 && this.m_NTeamsInGroups <= 32)
          {
            this.domainNGroups.Items.Add((object) "2");
            this.m_NGroups = 2;
          }
          if (this.m_NTeamsInGroups <= 16)
          {
            this.domainNGroups.Items.Add((object) "1");
            this.m_NGroups = 1;
          }
          this.domainNGroups.SelectedItem = (object) this.m_NGroups.ToString();
          this.m_NTeamsPerGroup = this.m_NTeamsInGroups / this.m_NGroups;
          this.m_NPreliminaryTeams = (this.m_NTeams - this.m_NTeamsInGroups) * 2;
          break;
      }
    }

    private void InitKnockOutOptions()
    {
      switch (this.m_TournamentStructure)
      {
        case 1:
        case 2:
          this.m_NKnockOutTeams = (int) Math.Pow(2.0, Math.Floor(Math.Log((double) this.numericNTeams.Value, 2.0)));
          this.domainNTeamsKO.Items.Clear();
          this.domainNTeamsKO.Items.Add((object) this.m_NKnockOutTeams.ToString());
          this.domainNTeamsKO.Enabled = false;
          this.domainNTeamsKO.SelectedItem = (object) this.m_NKnockOutTeams.ToString();
          this.m_NPreliminaryTeams = (this.m_NTeams - this.m_NKnockOutTeams) * 2;
          break;
        case 3:
          int num1 = (int) Math.Pow(2.0, Math.Floor(Math.Log((double) this.m_NTeams - 1.0, 2.0)));
          this.domainNTeamsKO.Items.Clear();
          if (num1 >= 32 && 32 >= this.m_NGroups)
            this.domainNTeamsKO.Items.Add((object) "32");
          if (num1 >= 16 && 16 >= this.m_NGroups)
            this.domainNTeamsKO.Items.Add((object) "16");
          if (num1 >= 8 && 8 >= this.m_NGroups)
            this.domainNTeamsKO.Items.Add((object) "8");
          if (num1 >= 4 && 4 >= this.m_NGroups)
            this.domainNTeamsKO.Items.Add((object) "4");
          if (num1 >= 2 && 2 >= this.m_NGroups)
            this.domainNTeamsKO.Items.Add((object) "2");
          this.domainNTeamsKO.Enabled = true;
          this.m_NKnockOutTeams = this.m_NGroups * 2;
          this.domainNTeamsKO.SelectedItem = (object) this.m_NKnockOutTeams.ToString();
          break;
        case 4:
          int num2 = (int) Math.Pow(2.0, Math.Floor(Math.Log((double) (this.m_NTeamsInGroups - 1), 2.0)));
          this.domainNTeamsKO.Items.Clear();
          if (num2 >= 32 && 32 >= this.m_NGroups)
            this.domainNTeamsKO.Items.Add((object) "32");
          if (num2 >= 16 && 16 >= this.m_NGroups)
            this.domainNTeamsKO.Items.Add((object) "16");
          if (num2 >= 8 && 8 >= this.m_NGroups)
            this.domainNTeamsKO.Items.Add((object) "8");
          if (num2 >= 4 && 4 >= this.m_NGroups)
            this.domainNTeamsKO.Items.Add((object) "4");
          if (num2 >= 2 && 2 >= this.m_NGroups)
            this.domainNTeamsKO.Items.Add((object) "2");
          this.domainNTeamsKO.Enabled = true;
          this.m_NKnockOutTeams = this.m_NGroups * 2;
          this.domainNTeamsKO.SelectedItem = (object) this.m_NKnockOutTeams.ToString();
          break;
      }
    }

    private void InitKOToPanel()
    {
      if (this.m_TournamentStructure == 1 || this.m_TournamentStructure == 2)
      {
        this.m_NKnockOutTeams = (int) Math.Pow(2.0, Math.Floor(Math.Log((double) this.numericNTeams.Value, 2.0)));
        this.domainNTeamsKO.Enabled = true;
        this.domainNTeamsKO.Items.Clear();
        this.domainNTeamsKO.Items.Add((object) this.m_NKnockOutTeams.ToString());
        this.domainNTeamsKO.SelectedIndex = 0;
        this.m_NPreliminaryTeams = (this.m_NTeams - this.m_NKnockOutTeams) * 2;
        this.KOToPanel();
        if (this.m_TournamentStructure != 2)
          return;
        this.PreliminaryToPanel();
      }
      else if (this.m_TournamentStructure == 3)
      {
        this.m_NKnockOutTeams = (int) Math.Pow(2.0, Math.Floor(Math.Log((double) this.m_NTeams - 1.0, 2.0)));
        this.domainNTeamsKO.Items.Clear();
        if (this.m_NKnockOutTeams >= 2 && 2 > this.m_NGroups)
          this.domainNTeamsKO.Items.Add((object) "2");
        if (this.m_NKnockOutTeams >= 4 && 4 > this.m_NGroups)
          this.domainNTeamsKO.Items.Add((object) "4");
        if (this.m_NKnockOutTeams >= 8 && 8 > this.m_NGroups)
          this.domainNTeamsKO.Items.Add((object) "8");
        if (this.m_NKnockOutTeams >= 16 && 16 > this.m_NGroups)
          this.domainNTeamsKO.Items.Add((object) "16");
        if (this.m_NKnockOutTeams >= 32 && 32 > this.m_NGroups)
          this.domainNTeamsKO.Items.Add((object) "32");
        this.domainNTeamsKO.SelectedIndex = 0;
        this.domainNTeamsKO.Enabled = true;
        this.KOToPanel();
      }
      else
      {
        int tournamentStructure = this.m_TournamentStructure;
      }
    }

    private void InitGroupsToPanel()
    {
      if (this.m_TournamentStructure == 3)
      {
        this.domainNGroups.Items.Clear();
        if (this.m_NTeams <= 16)
          this.domainNGroups.Items.Add((object) "1");
        if (this.m_NTeams % 2 == 0 && this.m_NTeams >= 6)
          this.domainNGroups.Items.Add((object) "2");
        if (this.m_NTeams % 4 == 0 && this.m_NTeams >= 12)
          this.domainNGroups.Items.Add((object) "4");
        if (this.m_NTeams % 8 == 0 && this.m_NTeams >= 24)
          this.domainNGroups.Items.Add((object) "8");
        this.domainNGroups.SelectedIndex = 0;
        this.numericTeamsPerGroup.Enabled = false;
        this.GroupToPanel();
      }
      else
      {
        int tournamentStructure = this.m_TournamentStructure;
      }
    }

    private void radioLeague_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radioLeague.Checked)
        return;
      this.m_TournamentStructure = 0;
      this.ToPanel();
    }

    private void radioKO_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radioKO.Checked)
        return;
      this.m_TournamentStructure = 1;
      this.InitKnockOutOptions();
      this.ToPanel();
    }

    private void radioPKO_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radioPKO.Checked)
        return;
      this.m_TournamentStructure = 2;
      this.InitKnockOutOptions();
      this.ToPanel();
    }

    private void radioGKO_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radioGKO.Checked)
        return;
      this.m_TournamentStructure = 3;
      this.InitGroupsOptions();
      this.InitKnockOutOptions();
      this.ToPanel();
    }

    private void radioPGKO_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radioPGKO.Checked)
        return;
      this.m_TournamentStructure = 4;
      this.InitGroupsOptions();
      this.InitKnockOutOptions();
      this.ToPanel();
    }

    private void radioWC2006_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radioWC2006.Checked)
        return;
      this.m_TournamentStructure = 5;
      this.ToPanel();
    }

    private void radioEuro2004_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radioEuro2004.Checked)
        return;
      this.m_TournamentStructure = 7;
      this.ToPanel();
    }

    private void radioEuro2008_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radioEuro2008.Checked)
        return;
      this.m_TournamentStructure = 6;
      this.ToPanel();
    }

    private void domainNTeamsKO_SelectedItemChanged(object sender, EventArgs e)
    {
      if (this.domainNTeamsKO.SelectedItem == null)
        return;
      string str = this.domainNTeamsKO.SelectedItem.ToString();
      if (str == "2")
        this.m_NKnockOutTeams = 2;
      if (str == "4")
        this.m_NKnockOutTeams = 4;
      if (str == "8")
        this.m_NKnockOutTeams = 8;
      if (str == "16")
        this.m_NKnockOutTeams = 16;
      if (str == "32")
        this.m_NKnockOutTeams = 32;
      if (str == "64")
        this.m_NKnockOutTeams = 64;
      if (this.m_TournamentStructure != 2)
        return;
      this.m_NPreliminaryTeams = (this.m_NTeams - this.m_NKnockOutTeams) * 2;
    }

    private void domainNGroups_SelectedItemChanged(object sender, EventArgs e)
    {
      if (this.domainNGroups.SelectedItem == null)
        return;
      string str = this.domainNGroups.SelectedItem.ToString();
      if (str == "1")
        this.m_NGroups = 1;
      if (str == "2")
        this.m_NGroups = 2;
      if (str == "4")
        this.m_NGroups = 4;
      if (str == "8")
        this.m_NGroups = 8;
      if (str == "16")
        this.m_NGroups = 16;
      this.InitKnockOutOptions();
      if (this.m_TournamentStructure == 3)
      {
        this.m_NTeamsPerGroup = this.m_NTeamsInGroups / this.m_NGroups;
        this.GroupToPanel();
        this.KOToPanel();
      }
      if (this.m_TournamentStructure != 4)
        return;
      this.m_NTeamsPerGroup = this.m_NTeamsInGroups / this.m_NGroups;
      this.m_NPreliminaryTeams = (this.m_NTeams - this.m_NTeamsInGroups) * 2;
      this.GroupToPanel();
      this.KOToPanel();
      this.PreliminaryToPanel();
    }

    private void numericPrelimGames_ValueChanged(object sender, EventArgs e)
    {
      this.m_PreliminaryGames = (int) this.numericPrelimGames.Value;
    }

    private void numericGamesPerGroup_ValueChanged(object sender, EventArgs e)
    {
      this.m_GroupGames = (int) this.numericGamesPerGroup.Value;
    }

    private void numericKOGames_ValueChanged(object sender, EventArgs e)
    {
      this.m_KnockOutGames = (int) this.numericKOGames.Value;
    }

    private void numericFinalGames_ValueChanged(object sender, EventArgs e)
    {
      this.m_FinalGames = (int) this.numericFinalGames.Value;
    }

    private void numericLeagueGames_ValueChanged(object sender, EventArgs e)
    {
      this.m_LeagueGames = (int) this.numericLeagueGames.Value;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.buttonCancel = new Button();
      this.buttonOK = new Button();
      this.groupKO = new GroupBox();
      this.numericFinalGames = new NumericUpDown();
      this.numericKOGames = new NumericUpDown();
      this.domainNTeamsKO = new DomainUpDown();
      this.labelFinalGames = new Label();
      this.labelNTeamsKO = new Label();
      this.labelKnockOutGames = new Label();
      this.groupGroups = new GroupBox();
      this.numericGamesPerGroup = new NumericUpDown();
      this.numericTeamsPerGroup = new NumericUpDown();
      this.domainNGroups = new DomainUpDown();
      this.labelGamesPerGroup = new Label();
      this.labelNumberofGroups = new Label();
      this.labelTeamPerGroup = new Label();
      this.groupPreliminary = new GroupBox();
      this.numericPrelimGames = new NumericUpDown();
      this.numericPreliminaryTeams = new NumericUpDown();
      this.labelNumberofGames = new Label();
      this.labelPrelimNTeams = new Label();
      this.groupStructure = new GroupBox();
      this.radioEuro2008 = new RadioButton();
      this.radioEuro2004 = new RadioButton();
      this.radioWC2006 = new RadioButton();
      this.radioPGKO = new RadioButton();
      this.radioPKO = new RadioButton();
      this.radioGKO = new RadioButton();
      this.radioKO = new RadioButton();
      this.radioLeague = new RadioButton();
      this.numericNTeams = new NumericUpDown();
      this.labelNumberofTeams = new Label();
      this.groupLeague = new GroupBox();
      this.numericLeagueGames = new NumericUpDown();
      this.labelLeagueGames = new Label();
      this.groupQualification = new GroupBox();
      this.labelLeagueReadHelp = new Label();
      this.groupKO.SuspendLayout();
      this.numericFinalGames.BeginInit();
      this.numericKOGames.BeginInit();
      this.groupGroups.SuspendLayout();
      this.numericGamesPerGroup.BeginInit();
      this.numericTeamsPerGroup.BeginInit();
      this.groupPreliminary.SuspendLayout();
      this.numericPrelimGames.BeginInit();
      this.numericPreliminaryTeams.BeginInit();
      this.groupStructure.SuspendLayout();
      this.numericNTeams.BeginInit();
      this.groupLeague.SuspendLayout();
      this.numericLeagueGames.BeginInit();
      this.groupQualification.SuspendLayout();
      this.SuspendLayout();
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      this.buttonCancel.ImeMode = ImeMode.NoControl;
      this.buttonCancel.Location = new Point(389, 334);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new Size(94, 44);
      this.buttonCancel.TabIndex = 150;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonOK.DialogResult = DialogResult.OK;
      this.buttonOK.ImeMode = ImeMode.NoControl;
      this.buttonOK.Location = new Point(179, 334);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new Size(94, 44);
      this.buttonOK.TabIndex = 148;
      this.buttonOK.Text = "Create Tournament";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.groupKO.Controls.Add((Control) this.numericFinalGames);
      this.groupKO.Controls.Add((Control) this.numericKOGames);
      this.groupKO.Controls.Add((Control) this.domainNTeamsKO);
      this.groupKO.Controls.Add((Control) this.labelFinalGames);
      this.groupKO.Controls.Add((Control) this.labelNTeamsKO);
      this.groupKO.Controls.Add((Control) this.labelKnockOutGames);
      this.groupKO.Location = new Point(439, 184);
      this.groupKO.Name = "groupKO";
      this.groupKO.Size = new Size(200, 144);
      this.groupKO.TabIndex = 147;
      this.groupKO.TabStop = false;
      this.groupKO.Text = "Knock Out Stage Options";
      this.groupKO.Visible = false;
      this.numericFinalGames.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.numericFinalGames.Location = new Point(125, 91);
      this.numericFinalGames.Maximum = new Decimal(new int[4]
      {
        2,
        0,
        0,
        0
      });
      this.numericFinalGames.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericFinalGames.Name = "numericFinalGames";
      this.numericFinalGames.ReadOnly = true;
      this.numericFinalGames.Size = new Size(69, 20);
      this.numericFinalGames.TabIndex = 133;
      this.numericFinalGames.TextAlign = HorizontalAlignment.Center;
      this.numericFinalGames.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericFinalGames.ValueChanged += new EventHandler(this.numericFinalGames_ValueChanged);
      this.numericKOGames.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.numericKOGames.Location = new Point(125, 61);
      this.numericKOGames.Maximum = new Decimal(new int[4]
      {
        2,
        0,
        0,
        0
      });
      this.numericKOGames.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericKOGames.Name = "numericKOGames";
      this.numericKOGames.ReadOnly = true;
      this.numericKOGames.Size = new Size(69, 20);
      this.numericKOGames.TabIndex = 132;
      this.numericKOGames.TextAlign = HorizontalAlignment.Center;
      this.numericKOGames.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericKOGames.ValueChanged += new EventHandler(this.numericKOGames_ValueChanged);
      this.domainNTeamsKO.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.domainNTeamsKO.Items.Add((object) "2");
      this.domainNTeamsKO.Items.Add((object) "4");
      this.domainNTeamsKO.Items.Add((object) "8");
      this.domainNTeamsKO.Items.Add((object) "16");
      this.domainNTeamsKO.Items.Add((object) "32");
      this.domainNTeamsKO.Items.Add((object) "64");
      this.domainNTeamsKO.Location = new Point(125, 29);
      this.domainNTeamsKO.Name = "domainNTeamsKO";
      this.domainNTeamsKO.ReadOnly = true;
      this.domainNTeamsKO.Size = new Size(69, 20);
      this.domainNTeamsKO.TabIndex = 131;
      this.domainNTeamsKO.Wrap = true;
      this.domainNTeamsKO.SelectedItemChanged += new EventHandler(this.domainNTeamsKO_SelectedItemChanged);
      this.labelFinalGames.BackColor = SystemColors.ControlLight;
      this.labelFinalGames.ImeMode = ImeMode.NoControl;
      this.labelFinalGames.Location = new Point(6, 89);
      this.labelFinalGames.Name = "labelFinalGames";
      this.labelFinalGames.Size = new Size(188, 20);
      this.labelFinalGames.TabIndex = 130;
      this.labelFinalGames.Text = "Final Games";
      this.labelFinalGames.TextAlign = ContentAlignment.MiddleLeft;
      this.labelNTeamsKO.BackColor = SystemColors.ControlLight;
      this.labelNTeamsKO.ImeMode = ImeMode.NoControl;
      this.labelNTeamsKO.Location = new Point(6, 29);
      this.labelNTeamsKO.Name = "labelNTeamsKO";
      this.labelNTeamsKO.Size = new Size(188, 20);
      this.labelNTeamsKO.TabIndex = 129;
      this.labelNTeamsKO.Text = "Number of Teams";
      this.labelNTeamsKO.TextAlign = ContentAlignment.MiddleLeft;
      this.labelKnockOutGames.BackColor = SystemColors.ControlLight;
      this.labelKnockOutGames.ImeMode = ImeMode.NoControl;
      this.labelKnockOutGames.Location = new Point(6, 59);
      this.labelKnockOutGames.Name = "labelKnockOutGames";
      this.labelKnockOutGames.Size = new Size(188, 20);
      this.labelKnockOutGames.TabIndex = 128;
      this.labelKnockOutGames.Text = "Knock Out Games";
      this.labelKnockOutGames.TextAlign = ContentAlignment.MiddleLeft;
      this.groupGroups.Controls.Add((Control) this.numericGamesPerGroup);
      this.groupGroups.Controls.Add((Control) this.numericTeamsPerGroup);
      this.groupGroups.Controls.Add((Control) this.domainNGroups);
      this.groupGroups.Controls.Add((Control) this.labelGamesPerGroup);
      this.groupGroups.Controls.Add((Control) this.labelNumberofGroups);
      this.groupGroups.Controls.Add((Control) this.labelTeamPerGroup);
      this.groupGroups.Location = new Point(230, 184);
      this.groupGroups.Name = "groupGroups";
      this.groupGroups.Size = new Size(200, 144);
      this.groupGroups.TabIndex = 146;
      this.groupGroups.TabStop = false;
      this.groupGroups.Text = "Groups Stage Options";
      this.groupGroups.Visible = false;
      this.numericGamesPerGroup.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.numericGamesPerGroup.Location = new Point(125, 86);
      this.numericGamesPerGroup.Maximum = new Decimal(new int[4]
      {
        2,
        0,
        0,
        0
      });
      this.numericGamesPerGroup.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericGamesPerGroup.Name = "numericGamesPerGroup";
      this.numericGamesPerGroup.ReadOnly = true;
      this.numericGamesPerGroup.Size = new Size(69, 20);
      this.numericGamesPerGroup.TabIndex = 130;
      this.numericGamesPerGroup.TextAlign = HorizontalAlignment.Center;
      this.numericGamesPerGroup.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericGamesPerGroup.ValueChanged += new EventHandler(this.numericGamesPerGroup_ValueChanged);
      this.numericTeamsPerGroup.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.numericTeamsPerGroup.Enabled = false;
      this.numericTeamsPerGroup.Location = new Point(125, 56);
      this.numericTeamsPerGroup.Maximum = new Decimal(new int[4]
      {
        16,
        0,
        0,
        0
      });
      this.numericTeamsPerGroup.Minimum = new Decimal(new int[4]
      {
        3,
        0,
        0,
        0
      });
      this.numericTeamsPerGroup.Name = "numericTeamsPerGroup";
      this.numericTeamsPerGroup.ReadOnly = true;
      this.numericTeamsPerGroup.Size = new Size(69, 20);
      this.numericTeamsPerGroup.TabIndex = 129;
      this.numericTeamsPerGroup.TextAlign = HorizontalAlignment.Center;
      this.numericTeamsPerGroup.Value = new Decimal(new int[4]
      {
        3,
        0,
        0,
        0
      });
      this.domainNGroups.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.domainNGroups.Items.Add((object) "1");
      this.domainNGroups.Items.Add((object) "2");
      this.domainNGroups.Items.Add((object) "4");
      this.domainNGroups.Items.Add((object) "8");
      this.domainNGroups.Location = new Point(125, 26);
      this.domainNGroups.Name = "domainNGroups";
      this.domainNGroups.ReadOnly = true;
      this.domainNGroups.Size = new Size(69, 20);
      this.domainNGroups.TabIndex = 128;
      this.domainNGroups.Wrap = true;
      this.domainNGroups.SelectedItemChanged += new EventHandler(this.domainNGroups_SelectedItemChanged);
      this.labelGamesPerGroup.BackColor = SystemColors.ControlLight;
      this.labelGamesPerGroup.ImeMode = ImeMode.NoControl;
      this.labelGamesPerGroup.Location = new Point(6, 86);
      this.labelGamesPerGroup.Name = "labelGamesPerGroup";
      this.labelGamesPerGroup.Size = new Size(188, 20);
      this.labelGamesPerGroup.TabIndex = (int) sbyte.MaxValue;
      this.labelGamesPerGroup.Text = "Number of Games";
      this.labelGamesPerGroup.TextAlign = ContentAlignment.MiddleLeft;
      this.labelNumberofGroups.BackColor = SystemColors.ControlLight;
      this.labelNumberofGroups.ImeMode = ImeMode.NoControl;
      this.labelNumberofGroups.Location = new Point(6, 26);
      this.labelNumberofGroups.Name = "labelNumberofGroups";
      this.labelNumberofGroups.Size = new Size(188, 20);
      this.labelNumberofGroups.TabIndex = 126;
      this.labelNumberofGroups.Text = "Number of Groups";
      this.labelNumberofGroups.TextAlign = ContentAlignment.MiddleLeft;
      this.labelTeamPerGroup.BackColor = SystemColors.ControlLight;
      this.labelTeamPerGroup.ImeMode = ImeMode.NoControl;
      this.labelTeamPerGroup.Location = new Point(6, 56);
      this.labelTeamPerGroup.Name = "labelTeamPerGroup";
      this.labelTeamPerGroup.Size = new Size(188, 20);
      this.labelTeamPerGroup.TabIndex = 125;
      this.labelTeamPerGroup.Text = "Teams per Group";
      this.labelTeamPerGroup.TextAlign = ContentAlignment.MiddleLeft;
      this.groupPreliminary.Controls.Add((Control) this.numericPrelimGames);
      this.groupPreliminary.Controls.Add((Control) this.numericPreliminaryTeams);
      this.groupPreliminary.Controls.Add((Control) this.labelNumberofGames);
      this.groupPreliminary.Controls.Add((Control) this.labelPrelimNTeams);
      this.groupPreliminary.Location = new Point(15, 184);
      this.groupPreliminary.Name = "groupPreliminary";
      this.groupPreliminary.Size = new Size(200, 144);
      this.groupPreliminary.TabIndex = 144;
      this.groupPreliminary.TabStop = false;
      this.groupPreliminary.Text = "Preliminary Stage Options";
      this.groupPreliminary.Visible = false;
      this.numericPrelimGames.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.numericPrelimGames.Location = new Point(125, 56);
      this.numericPrelimGames.Maximum = new Decimal(new int[4]
      {
        2,
        0,
        0,
        0
      });
      this.numericPrelimGames.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericPrelimGames.Name = "numericPrelimGames";
      this.numericPrelimGames.ReadOnly = true;
      this.numericPrelimGames.Size = new Size(69, 20);
      this.numericPrelimGames.TabIndex = (int) sbyte.MaxValue;
      this.numericPrelimGames.TextAlign = HorizontalAlignment.Center;
      this.numericPrelimGames.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericPrelimGames.ValueChanged += new EventHandler(this.numericPrelimGames_ValueChanged);
      this.numericPreliminaryTeams.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.numericPreliminaryTeams.Enabled = false;
      this.numericPreliminaryTeams.Location = new Point(125, 26);
      this.numericPreliminaryTeams.Maximum = new Decimal(new int[4]
      {
        64,
        0,
        0,
        0
      });
      this.numericPreliminaryTeams.Minimum = new Decimal(new int[4]
      {
        2,
        0,
        0,
        0
      });
      this.numericPreliminaryTeams.Name = "numericPreliminaryTeams";
      this.numericPreliminaryTeams.ReadOnly = true;
      this.numericPreliminaryTeams.Size = new Size(69, 20);
      this.numericPreliminaryTeams.TabIndex = 126;
      this.numericPreliminaryTeams.TextAlign = HorizontalAlignment.Center;
      this.numericPreliminaryTeams.Value = new Decimal(new int[4]
      {
        3,
        0,
        0,
        0
      });
      this.labelNumberofGames.BackColor = SystemColors.ControlLight;
      this.labelNumberofGames.ImeMode = ImeMode.NoControl;
      this.labelNumberofGames.Location = new Point(6, 56);
      this.labelNumberofGames.Name = "labelNumberofGames";
      this.labelNumberofGames.Size = new Size(188, 20);
      this.labelNumberofGames.TabIndex = 125;
      this.labelNumberofGames.Text = "Number of Games";
      this.labelNumberofGames.TextAlign = ContentAlignment.MiddleLeft;
      this.labelPrelimNTeams.BackColor = SystemColors.ControlLight;
      this.labelPrelimNTeams.ImeMode = ImeMode.NoControl;
      this.labelPrelimNTeams.Location = new Point(6, 26);
      this.labelPrelimNTeams.Name = "labelPrelimNTeams";
      this.labelPrelimNTeams.Size = new Size(188, 20);
      this.labelPrelimNTeams.TabIndex = 124;
      this.labelPrelimNTeams.Text = "Number of Teams";
      this.labelPrelimNTeams.TextAlign = ContentAlignment.MiddleLeft;
      this.groupStructure.Controls.Add((Control) this.radioEuro2008);
      this.groupStructure.Controls.Add((Control) this.radioEuro2004);
      this.groupStructure.Controls.Add((Control) this.radioWC2006);
      this.groupStructure.Controls.Add((Control) this.radioPGKO);
      this.groupStructure.Controls.Add((Control) this.radioPKO);
      this.groupStructure.Controls.Add((Control) this.radioGKO);
      this.groupStructure.Controls.Add((Control) this.radioKO);
      this.groupStructure.Controls.Add((Control) this.radioLeague);
      this.groupStructure.Location = new Point(15, 35);
      this.groupStructure.Name = "groupStructure";
      this.groupStructure.Size = new Size(624, 117);
      this.groupStructure.TabIndex = 143;
      this.groupStructure.TabStop = false;
      this.groupStructure.Text = "Tournament Structure";
      this.radioEuro2008.AutoSize = true;
      this.radioEuro2008.ImeMode = ImeMode.NoControl;
      this.radioEuro2008.Location = new Point(439, 79);
      this.radioEuro2008.Name = "radioEuro2008";
      this.radioEuro2008.Size = new Size(109, 17);
      this.radioEuro2008.TabIndex = 7;
      this.radioEuro2008.TabStop = true;
      this.radioEuro2008.Text = "Euro 2008 Format";
      this.radioEuro2008.UseVisualStyleBackColor = true;
      this.radioEuro2008.CheckedChanged += new EventHandler(this.radioEuro2008_CheckedChanged);
      this.radioEuro2004.AutoSize = true;
      this.radioEuro2004.ImeMode = ImeMode.NoControl;
      this.radioEuro2004.Location = new Point(439, 56);
      this.radioEuro2004.Name = "radioEuro2004";
      this.radioEuro2004.Size = new Size(109, 17);
      this.radioEuro2004.TabIndex = 6;
      this.radioEuro2004.TabStop = true;
      this.radioEuro2004.Text = "Euro 2004 Format";
      this.radioEuro2004.UseVisualStyleBackColor = true;
      this.radioEuro2004.CheckedChanged += new EventHandler(this.radioEuro2004_CheckedChanged);
      this.radioWC2006.AutoSize = true;
      this.radioWC2006.ImeMode = ImeMode.NoControl;
      this.radioWC2006.Location = new Point(439, 33);
      this.radioWC2006.Name = "radioWC2006";
      this.radioWC2006.Size = new Size(78, 17);
      this.radioWC2006.TabIndex = 5;
      this.radioWC2006.TabStop = true;
      this.radioWC2006.Text = "WC Format";
      this.radioWC2006.UseVisualStyleBackColor = true;
      this.radioWC2006.CheckedChanged += new EventHandler(this.radioWC2006_CheckedChanged);
      this.radioPGKO.AutoSize = true;
      this.radioPGKO.ImeMode = ImeMode.NoControl;
      this.radioPGKO.Location = new Point(195, 79);
      this.radioPGKO.Name = "radioPGKO";
      this.radioPGKO.Size = new Size(210, 17);
      this.radioPGKO.TabIndex = 4;
      this.radioPGKO.TabStop = true;
      this.radioPGKO.Text = "Preliminary + Group Stage + Knock Out";
      this.radioPGKO.UseVisualStyleBackColor = true;
      this.radioPGKO.CheckedChanged += new EventHandler(this.radioPGKO_CheckedChanged);
      this.radioPKO.AutoSize = true;
      this.radioPKO.ImeMode = ImeMode.NoControl;
      this.radioPKO.Location = new Point(195, 56);
      this.radioPKO.Name = "radioPKO";
      this.radioPKO.Size = new Size(138, 17);
      this.radioPKO.TabIndex = 3;
      this.radioPKO.TabStop = true;
      this.radioPKO.Text = "Preliminary + Knock Out";
      this.radioPKO.UseVisualStyleBackColor = true;
      this.radioPKO.CheckedChanged += new EventHandler(this.radioPKO_CheckedChanged);
      this.radioGKO.AutoSize = true;
      this.radioGKO.ImeMode = ImeMode.NoControl;
      this.radioGKO.Location = new Point(28, 79);
      this.radioGKO.Name = "radioGKO";
      this.radioGKO.Size = new Size(151, 17);
      this.radioGKO.TabIndex = 2;
      this.radioGKO.TabStop = true;
      this.radioGKO.Text = "Groups Stage + Knock out";
      this.radioGKO.UseVisualStyleBackColor = true;
      this.radioGKO.CheckedChanged += new EventHandler(this.radioGKO_CheckedChanged);
      this.radioKO.AutoSize = true;
      this.radioKO.ImeMode = ImeMode.NoControl;
      this.radioKO.Location = new Point(28, 56);
      this.radioKO.Name = "radioKO";
      this.radioKO.Size = new Size(76, 17);
      this.radioKO.TabIndex = 1;
      this.radioKO.TabStop = true;
      this.radioKO.Text = "Knock Out";
      this.radioKO.UseVisualStyleBackColor = true;
      this.radioKO.CheckedChanged += new EventHandler(this.radioKO_CheckedChanged);
      this.radioLeague.AutoSize = true;
      this.radioLeague.Checked = true;
      this.radioLeague.ImeMode = ImeMode.NoControl;
      this.radioLeague.Location = new Point(28, 33);
      this.radioLeague.Name = "radioLeague";
      this.radioLeague.Size = new Size(61, 17);
      this.radioLeague.TabIndex = 0;
      this.radioLeague.TabStop = true;
      this.radioLeague.Text = "League";
      this.radioLeague.UseVisualStyleBackColor = true;
      this.radioLeague.CheckedChanged += new EventHandler(this.radioLeague_CheckedChanged);
      this.numericNTeams.Location = new Point(140, 9);
      this.numericNTeams.Maximum = new Decimal(new int[4]
      {
        64,
        0,
        0,
        0
      });
      this.numericNTeams.Minimum = new Decimal(new int[4]
      {
        3,
        0,
        0,
        0
      });
      this.numericNTeams.Name = "numericNTeams";
      this.numericNTeams.Size = new Size(60, 20);
      this.numericNTeams.TabIndex = 141;
      this.numericNTeams.TextAlign = HorizontalAlignment.Center;
      this.numericNTeams.Value = new Decimal(new int[4]
      {
        3,
        0,
        0,
        0
      });
      this.numericNTeams.ValueChanged += new EventHandler(this.numericNTeams_ValueChanged);
      this.labelNumberofTeams.BackColor = SystemColors.ControlLight;
      this.labelNumberofTeams.ImeMode = ImeMode.NoControl;
      this.labelNumberofTeams.Location = new Point(12, 9);
      this.labelNumberofTeams.Name = "labelNumberofTeams";
      this.labelNumberofTeams.Size = new Size(188, 20);
      this.labelNumberofTeams.TabIndex = 142;
      this.labelNumberofTeams.Text = "Number of Teams";
      this.labelNumberofTeams.TextAlign = ContentAlignment.MiddleLeft;
      this.groupLeague.Controls.Add((Control) this.numericLeagueGames);
      this.groupLeague.Controls.Add((Control) this.labelLeagueGames);
      this.groupLeague.Location = new Point(15, 184);
      this.groupLeague.Name = "groupLeague";
      this.groupLeague.Size = new Size(200, 144);
      this.groupLeague.TabIndex = 149;
      this.groupLeague.TabStop = false;
      this.groupLeague.Text = "League Options";
      this.groupLeague.Visible = false;
      this.numericLeagueGames.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.numericLeagueGames.Location = new Point(125, 26);
      this.numericLeagueGames.Maximum = new Decimal(new int[4]
      {
        2,
        0,
        0,
        0
      });
      this.numericLeagueGames.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericLeagueGames.Name = "numericLeagueGames";
      this.numericLeagueGames.ReadOnly = true;
      this.numericLeagueGames.Size = new Size(69, 20);
      this.numericLeagueGames.TabIndex = 129;
      this.numericLeagueGames.TextAlign = HorizontalAlignment.Center;
      this.numericLeagueGames.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.labelLeagueGames.BackColor = SystemColors.ControlLight;
      this.labelLeagueGames.ImeMode = ImeMode.NoControl;
      this.labelLeagueGames.Location = new Point(6, 26);
      this.labelLeagueGames.Name = "labelLeagueGames";
      this.labelLeagueGames.Size = new Size(188, 20);
      this.labelLeagueGames.TabIndex = 128;
      this.labelLeagueGames.Text = "Number of Games";
      this.labelLeagueGames.TextAlign = ContentAlignment.MiddleLeft;
      this.groupQualification.Controls.Add((Control) this.labelLeagueReadHelp);
      this.groupQualification.Location = new Point(15, 184);
      this.groupQualification.Name = "groupQualification";
      this.groupQualification.Size = new Size(200, 144);
      this.groupQualification.TabIndex = 145;
      this.groupQualification.TabStop = false;
      this.groupQualification.Text = "Special Format";
      this.groupQualification.Visible = false;
      this.labelLeagueReadHelp.BackColor = SystemColors.Control;
      this.labelLeagueReadHelp.ImeMode = ImeMode.NoControl;
      this.labelLeagueReadHelp.Location = new Point(6, 62);
      this.labelLeagueReadHelp.Name = "labelLeagueReadHelp";
      this.labelLeagueReadHelp.Size = new Size(188, 20);
      this.labelLeagueReadHelp.TabIndex = (int) sbyte.MaxValue;
      this.labelLeagueReadHelp.Text = "See the Help";
      this.labelLeagueReadHelp.TextAlign = ContentAlignment.MiddleCenter;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(649, 384);
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonOK);
      this.Controls.Add((Control) this.groupKO);
      this.Controls.Add((Control) this.groupGroups);
      this.Controls.Add((Control) this.groupPreliminary);
      this.Controls.Add((Control) this.groupStructure);
      this.Controls.Add((Control) this.numericNTeams);
      this.Controls.Add((Control) this.labelNumberofTeams);
      this.Controls.Add((Control) this.groupLeague);
      this.Controls.Add((Control) this.groupQualification);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = "TournamentWizard";
      this.Text = nameof (TournamentWizard);
      this.groupKO.ResumeLayout(false);
      this.numericFinalGames.EndInit();
      this.numericKOGames.EndInit();
      this.groupGroups.ResumeLayout(false);
      this.numericGamesPerGroup.EndInit();
      this.numericTeamsPerGroup.EndInit();
      this.groupPreliminary.ResumeLayout(false);
      this.numericPrelimGames.EndInit();
      this.numericPreliminaryTeams.EndInit();
      this.groupStructure.ResumeLayout(false);
      this.groupStructure.PerformLayout();
      this.numericNTeams.EndInit();
      this.groupLeague.ResumeLayout(false);
      this.numericLeagueGames.EndInit();
      this.groupQualification.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
