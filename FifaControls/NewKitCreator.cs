// Original code created by Rinaldo

using FifaLibrary;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FifaControls
{
  public class NewKitCreator : Form
  {
    private int m_NewId = -1;
    private IContainer components;
    private Button button1;
    private Button buttonOK;
    private Label labelTeam;
    private Label labelKitType;
    private ComboBox comboKitTypes;
    private ComboBox comboTeams;
    private Kit m_NewKit;
    private Kit m_SourceKit;
    private Team m_Team;
    private int m_KitType;
    private KitList m_KitList;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager resources = new ComponentResourceManager(typeof (NewKitCreator));
      this.button1 = new Button();
      this.buttonOK = new Button();
      this.labelTeam = new Label();
      this.labelKitType = new Label();
      this.comboKitTypes = new ComboBox();
      this.comboTeams = new ComboBox();
      this.SuspendLayout();
      this.button1.DialogResult = DialogResult.Cancel;
      this.button1.Location = new Point(174, 121);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 23);
      this.button1.TabIndex = 8;
      this.button1.Text = "Cancel";
      this.button1.UseVisualStyleBackColor = true;
      this.buttonOK.DialogResult = DialogResult.OK;
      this.buttonOK.Location = new Point(49, 121);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new Size(75, 23);
      this.buttonOK.TabIndex = 7;
      this.buttonOK.Text = "OK";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
      this.labelTeam.AutoSize = true;
      this.labelTeam.BackColor = Color.Transparent;
      this.labelTeam.Location = new Point(23, 31);
      this.labelTeam.Name = "labelTeam";
      this.labelTeam.Size = new Size(34, 13);
      this.labelTeam.TabIndex = 9;
      this.labelTeam.Text = "Team";
      this.labelKitType.AutoSize = true;
      this.labelKitType.BackColor = Color.Transparent;
      this.labelKitType.Location = new Point(23, 63);
      this.labelKitType.Name = "labelKitType";
      this.labelKitType.Size = new Size(42, 13);
      this.labelKitType.TabIndex = 10;
      this.labelKitType.Text = "Kit type";
      this.comboKitTypes.FormattingEnabled = true;
      this.comboKitTypes.Items.AddRange(new object[11]
      {
        (object) "Home",
        (object) "Away",
        (object) "Goalkeeper",
        (object) "3rd Kit",
        (object) "4th Kit",
        (object) "Referee",
        (object) "6th Kit",
        (object) "7th Kit",
        (object) "8th Kit",
        (object) "9th Kit",
        (object) "10th Kit"
      });
      this.comboKitTypes.Location = new Point(91, 60);
      this.comboKitTypes.Name = "comboKitTypes";
      this.comboKitTypes.Size = new Size(178, 21);
      this.comboKitTypes.TabIndex = 11;
      this.comboKitTypes.SelectedIndexChanged += new EventHandler(this.comboKitTypes_SelectedIndexChanged);
      this.comboTeams.FormattingEnabled = true;
      this.comboTeams.Location = new Point(91, 28);
      this.comboTeams.Name = "comboTeams";
      this.comboTeams.Size = new Size(178, 21);
      this.comboTeams.TabIndex = 12;
      this.comboTeams.SelectedIndexChanged += new EventHandler(this.comboTeams_SelectedIndexChanged);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImage = (Image) resources.GetObject("$this.BackgroundImage");
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(292, 169);
      this.Controls.Add((Control) this.comboTeams);
      this.Controls.Add((Control) this.comboKitTypes);
      this.Controls.Add((Control) this.labelKitType);
      this.Controls.Add((Control) this.labelTeam);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.buttonOK);
      this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
      this.Name = "NewKitCreator";
      this.Text = "NewKitSelector";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public NewKitCreator()
    {
      this.InitializeComponent();
    }

    public Kit NewKit
    {
      get
      {
        return this.m_NewKit;
      }
    }

    public int NewId
    {
      get
      {
        return this.m_NewId;
      }
    }

    public Kit SourceKit
    {
      set
      {
        this.m_SourceKit = value;
        this.m_Team = this.m_SourceKit.Team;
        this.m_KitType = this.m_SourceKit.kittype;
        this.comboTeams.SelectedItem = (object) this.Team;
        this.comboKitTypes.SelectedIndex = this.m_KitType;
      }
    }

    public Team Team
    {
      get
      {
        return this.m_Team;
      }
    }

    public int KitType
    {
      get
      {
        return this.m_KitType;
      }
    }

    public void SetTeams(TeamList teamList)
    {
      this.comboTeams.Items.Clear();
      this.comboTeams.Items.AddRange(teamList.ToArray());
    }

    public KitList KitList
    {
      set
      {
        this.m_KitList = value;
      }
    }

    private void buttonOK_Click(object sender, EventArgs e)
    {
      if (this.m_KitList == null)
        this.m_NewKit = (Kit) null;
      else if (this.m_KitList.Exists(this.m_Team.Id, this.m_KitType))
      {
        this.m_NewKit = (Kit) null;
      }
      else
      {
        this.m_NewKit = (Kit) this.m_KitList.CloneId((IdObject) this.m_SourceKit);
        if (this.m_NewKit == null)
          return;
        this.m_NewKit.Team = this.m_Team;
        this.m_NewKit.kittype = this.m_KitType;
        this.m_SourceKit.CloneTextures(this.m_NewKit);
        if (this.m_SourceKit.Positions == null)
          return;
        for (int index = 0; index < this.m_SourceKit.Positions.Length; ++index)
          this.m_NewKit.Positions[index] = this.m_SourceKit.Positions[index];
      }
    }

    private void comboTeams_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboTeams.SelectedItem == null)
        return;
      this.m_Team = (Team) this.comboTeams.SelectedItem;
    }

    private void comboKitTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboKitTypes.SelectedIndex < 0)
        return;
      this.m_KitType = this.comboKitTypes.SelectedIndex;
    }
  }
}
