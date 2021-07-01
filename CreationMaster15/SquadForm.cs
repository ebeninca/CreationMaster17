// Original code created by Rinaldo

using FifaLibrary;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CreationMaster
{
  public class SquadForm : Form
  {
    private IContainer components;
    private Panel panelBottom;
    private Button button1;
    private Button buttonOK;
    private TreeView treeTurns;
    private ComboBox comboTrophy;
    public Rank m_Rank;
    private Trophy m_LastSelectedTrophy;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.panelBottom = new Panel();
      this.button1 = new Button();
      this.buttonOK = new Button();
      this.treeTurns = new TreeView();
      this.comboTrophy = new ComboBox();
      this.panelBottom.SuspendLayout();
      this.SuspendLayout();
      this.panelBottom.Controls.Add((Control) this.button1);
      this.panelBottom.Controls.Add((Control) this.buttonOK);
      this.panelBottom.Dock = DockStyle.Bottom;
      this.panelBottom.Location = new Point(0, 441);
      this.panelBottom.Name = "panelBottom";
      this.panelBottom.Size = new Size(304, 42);
      this.panelBottom.TabIndex = 5;
      this.button1.DialogResult = DialogResult.Cancel;
      this.button1.ImeMode = ImeMode.NoControl;
      this.button1.Location = new Point(178, 9);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 23);
      this.button1.TabIndex = 1;
      this.button1.Text = "Cancel";
      this.button1.UseVisualStyleBackColor = true;
      this.buttonOK.DialogResult = DialogResult.OK;
      this.buttonOK.Enabled = false;
      this.buttonOK.ImeMode = ImeMode.NoControl;
      this.buttonOK.Location = new Point(30, 9);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new Size(75, 23);
      this.buttonOK.TabIndex = 0;
      this.buttonOK.Text = "OK";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.treeTurns.Dock = DockStyle.Fill;
      this.treeTurns.Location = new Point(0, 21);
      this.treeTurns.Name = "treeTurns";
      this.treeTurns.Size = new Size(304, 462);
      this.treeTurns.TabIndex = 4;
      this.treeTurns.DoubleClick += new EventHandler(this.treeTurns_DoubleClick);
      this.treeTurns.AfterSelect += new TreeViewEventHandler(this.treeTurns_AfterSelect);
      this.comboTrophy.Dock = DockStyle.Top;
      this.comboTrophy.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboTrophy.FormattingEnabled = true;
      this.comboTrophy.Location = new Point(0, 0);
      this.comboTrophy.MaxDropDownItems = 16;
      this.comboTrophy.Name = "comboTournament";
      this.comboTrophy.Size = new Size(304, 21);
      this.comboTrophy.Sorted = true;
      this.comboTrophy.TabIndex = 3;
      this.comboTrophy.SelectedIndexChanged += new EventHandler(this.comboTrophy_SelectedIndexChanged);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(304, 483);
      this.Controls.Add((Control) this.panelBottom);
      this.Controls.Add((Control) this.treeTurns);
      this.Controls.Add((Control) this.comboTrophy);
      this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
      this.Name = "SquadForm";
      this.Text = "Team Form";
      this.panelBottom.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public SquadForm(Trophy currentTrophy)
    {
      this.InitializeComponent();
      if (this.m_LastSelectedTrophy == null)
        this.m_LastSelectedTrophy = currentTrophy;
      this.Initialize();
    }

    public void Initialize()
    {
      this.comboTrophy.Items.Clear();
      foreach (Trophy competitionObject in (ArrayList) FifaEnvironment.CompetitionObjects)
      {
        if (competitionObject.TypeNumber == 3)
          this.comboTrophy.Items.Add((object) competitionObject);
      }
      this.comboTrophy.SelectedItem = (object) this.m_LastSelectedTrophy;
    }

    private void comboTrophy_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.m_LastSelectedTrophy = (Trophy) this.comboTrophy.SelectedItem;
      this.treeTurns.Nodes.Clear();
      TreeNode treeNode1 = (TreeNode) null;
      foreach (Stage stage in (ArrayList) this.m_LastSelectedTrophy.Stages)
      {
        treeNode1 = this.treeTurns.Nodes.Add(stage.ToString());
        treeNode1.Tag = (object) stage;
        if (stage.Groups.Count > 1)
        {
          foreach (Group group in (ArrayList) stage.Groups)
          {
            TreeNode treeNode2 = treeNode1.Nodes.Add(group.ToString());
            treeNode2.Tag = (object) group;
            foreach (Rank rank in (ArrayList) group.Ranks)
              treeNode2.Nodes.Add(rank.ToString()).Tag = (object) rank;
          }
        }
        else
        {
          foreach (Rank rank in (ArrayList) ((Group) stage.Groups[0]).Ranks)
            treeNode1.Nodes.Add(rank.ToString()).Tag = (object) rank;
        }
      }
      treeNode1?.Expand();
    }

    private void treeTurns_AfterSelect(object sender, TreeViewEventArgs e)
    {
      if (this.treeTurns.SelectedNode.Tag.GetType().FullName == "FifaLibrary.Squad")
      {
        this.buttonOK.Enabled = true;
        this.m_Rank = (Rank) this.treeTurns.SelectedNode.Tag;
      }
      else
        this.buttonOK.Enabled = false;
    }

    private void treeTurns_DoubleClick(object sender, EventArgs e)
    {
      if (this.treeTurns.SelectedNode.Tag.GetType().FullName == "FifaLibrary.Squad")
      {
        this.buttonOK.Enabled = true;
        this.m_Rank = (Rank) this.treeTurns.SelectedNode.Tag;
        this.buttonOK.PerformClick();
      }
      else
        this.buttonOK.Enabled = false;
    }
  }
}
