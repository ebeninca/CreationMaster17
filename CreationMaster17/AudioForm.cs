// Original code created by Rinaldo

using FifaControls;
using FifaLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CreationMaster
{
  public class AudioForm : Form
  {
    private int m_CurrentDictionaryKey = 900000;
    private AudioForm.SearchMode m_SearchMode = AudioForm.SearchMode.SearchContaining;
    private IContainer components;
    public PickUpControl pickUpControl;
    private GroupBox groupAudio;
    private GroupBox groupNameDictionary;
    private ListView listViewNameDictionary;
    private ColumnHeader columnNameId;
    private ColumnHeader columnSurname;
    private NumericUpDown numericNameDictionary;
    private ToolStrip toolStripSearchnameDictionary;
    private ToolStripSeparator toolStripSeparator6;
    private ToolStripButton buttonFindNameExact;
    private ToolStripButton buttonFindNameStart;
    private ToolStripButton buttonFindNameAny;
    private ToolStrip toolStripNameDictionary;
    private ToolStripSeparator toolStripSeparator7;
    public ToolStripButton buttonAddName;
    public ToolStripButton buttonReplaceName;
    public ToolStripButton buttonRemoveName;
    private TextBox textKnownAs;
    private Label label13;
    private ToolStripTextBox textNameDictionary;
    private Button buttonSearchSurnameId;
    private ToolStripTextBox textSearchNameDictionary;
    private ToolStripLabel toolStripLabel1;
    private Label label1;
    private TextBox textPlayerId;
    private Button buttonSearchPlayerId;
    private ToolTip toolTip;
    private TextBox textSurnameSoundId;
    private Button buttonSetSound;
    private Button buttonDeleteSound;
    private GroupBox groupPlayerInfo;
    private Label labelCommonName;
    private TextBox textCommonName;
    private Viewer2D viewer2DPhoto;
    private TextBox textSurname;
    private TextBox textFirstName;
    private Label labelFirstName;
    private Label labelSurame;
    private TextBox textAudioName;
    private Label label3;
    private Label label2;
    private bool m_IsLoaded;
    public Player m_CurrentPlayer;
    private KeyValuePair<int, string> m_SelectedDictionaryName;
    private string m_CurrentDictionaryName;
    private string m_Pattern;
    private int m_CurrentSearchIndex;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager resources = new ComponentResourceManager(typeof (AudioForm));
      this.groupAudio = new GroupBox();
      this.textAudioName = new TextBox();
      this.label3 = new Label();
      this.label2 = new Label();
      this.buttonDeleteSound = new Button();
      this.buttonSetSound = new Button();
      this.textSurnameSoundId = new TextBox();
      this.buttonSearchPlayerId = new Button();
      this.textPlayerId = new TextBox();
      this.label1 = new Label();
      this.buttonSearchSurnameId = new Button();
      this.textKnownAs = new TextBox();
      this.label13 = new Label();
      this.groupNameDictionary = new GroupBox();
      this.numericNameDictionary = new NumericUpDown();
      this.listViewNameDictionary = new ListView();
      this.columnNameId = new ColumnHeader();
      this.columnSurname = new ColumnHeader();
      this.toolStripNameDictionary = new ToolStrip();
      this.textNameDictionary = new ToolStripTextBox();
      this.toolStripSeparator7 = new ToolStripSeparator();
      this.buttonAddName = new ToolStripButton();
      this.buttonReplaceName = new ToolStripButton();
      this.buttonRemoveName = new ToolStripButton();
      this.toolStripSearchnameDictionary = new ToolStrip();
      this.toolStripLabel1 = new ToolStripLabel();
      this.textSearchNameDictionary = new ToolStripTextBox();
      this.toolStripSeparator6 = new ToolStripSeparator();
      this.buttonFindNameExact = new ToolStripButton();
      this.buttonFindNameStart = new ToolStripButton();
      this.buttonFindNameAny = new ToolStripButton();
      this.toolTip = new ToolTip(this.components);
      this.pickUpControl = new PickUpControl();
      this.groupPlayerInfo = new GroupBox();
      this.labelCommonName = new Label();
      this.textCommonName = new TextBox();
      this.viewer2DPhoto = new Viewer2D();
      this.textSurname = new TextBox();
      this.textFirstName = new TextBox();
      this.labelFirstName = new Label();
      this.labelSurame = new Label();
      this.groupAudio.SuspendLayout();
      this.groupNameDictionary.SuspendLayout();
      this.numericNameDictionary.BeginInit();
      this.toolStripNameDictionary.SuspendLayout();
      this.toolStripSearchnameDictionary.SuspendLayout();
      this.groupPlayerInfo.SuspendLayout();
      this.SuspendLayout();
      this.groupAudio.Controls.Add((Control) this.textAudioName);
      this.groupAudio.Controls.Add((Control) this.label3);
      this.groupAudio.Controls.Add((Control) this.label2);
      this.groupAudio.Controls.Add((Control) this.buttonDeleteSound);
      this.groupAudio.Controls.Add((Control) this.buttonSetSound);
      this.groupAudio.Controls.Add((Control) this.textSurnameSoundId);
      this.groupAudio.Controls.Add((Control) this.buttonSearchPlayerId);
      this.groupAudio.Controls.Add((Control) this.textPlayerId);
      this.groupAudio.Controls.Add((Control) this.label1);
      this.groupAudio.Controls.Add((Control) this.buttonSearchSurnameId);
      this.groupAudio.Controls.Add((Control) this.textKnownAs);
      this.groupAudio.Controls.Add((Control) this.label13);
      this.groupAudio.Location = new Point(12, 40);
      this.groupAudio.Name = "groupAudio";
      this.groupAudio.Size = new Size(302, 149);
      this.groupAudio.TabIndex = 92;
      this.groupAudio.TabStop = false;
      this.groupAudio.Text = "Player Audio";
      this.textAudioName.BackColor = Color.White;
      this.textAudioName.Location = new Point(88, 104);
      this.textAudioName.Name = "textAudioName";
      this.textAudioName.ReadOnly = true;
      this.textAudioName.Size = new Size(148, 20);
      this.textAudioName.TabIndex = 110;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(6, 107);
      this.label3.Name = "label3";
      this.label3.Size = new Size(65, 13);
      this.label3.TabIndex = 109;
      this.label3.Text = "Audio Name";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(6, 55);
      this.label2.Name = "label2";
      this.label2.Size = new Size(55, 13);
      this.label2.TabIndex = 108;
      this.label2.Text = "Known As";
      this.buttonDeleteSound.BackgroundImage = (Image) resources.GetObject("buttonDeleteSound.BackgroundImage");
      this.buttonDeleteSound.BackgroundImageLayout = ImageLayout.Center;
      this.buttonDeleteSound.Location = new Point(211, 76);
      this.buttonDeleteSound.Name = "buttonDeleteSound";
      this.buttonDeleteSound.Size = new Size(25, 23);
      this.buttonDeleteSound.TabIndex = 107;
      this.toolTip.SetToolTip((Control) this.buttonDeleteSound, "Remove the generic audio associated to this name");
      this.buttonDeleteSound.UseVisualStyleBackColor = true;
      this.buttonDeleteSound.Click += new EventHandler(this.buttonDeleteSound_Click);
      this.buttonSetSound.BackgroundImage = (Image) resources.GetObject("buttonSetSound.BackgroundImage");
      this.buttonSetSound.BackgroundImageLayout = ImageLayout.Center;
      this.buttonSetSound.Enabled = false;
      this.buttonSetSound.Location = new Point(242, 71);
      this.buttonSetSound.Name = "buttonSetSound";
      this.buttonSetSound.Size = new Size(50, 59);
      this.buttonSetSound.TabIndex = 106;
      this.buttonSetSound.UseVisualStyleBackColor = true;
      this.buttonSetSound.Click += new EventHandler(this.buttonSetSound_Click);
      this.textSurnameSoundId.BackColor = Color.White;
      this.textSurnameSoundId.Location = new Point(88, 78);
      this.textSurnameSoundId.Name = "textSurnameSoundId";
      this.textSurnameSoundId.ReadOnly = true;
      this.textSurnameSoundId.Size = new Size(86, 20);
      this.textSurnameSoundId.TabIndex = 105;
      this.textSurnameSoundId.TextAlign = HorizontalAlignment.Center;
      this.buttonSearchPlayerId.BackgroundImage = (Image) resources.GetObject("buttonSearchPlayerId.BackgroundImage");
      this.buttonSearchPlayerId.BackgroundImageLayout = ImageLayout.Center;
      this.buttonSearchPlayerId.Location = new Point(180, 23);
      this.buttonSearchPlayerId.Name = "buttonSearchPlayerId";
      this.buttonSearchPlayerId.Size = new Size(25, 23);
      this.buttonSearchPlayerId.TabIndex = 104;
      this.toolTip.SetToolTip((Control) this.buttonSearchPlayerId, "Search specific audio for this player");
      this.buttonSearchPlayerId.UseVisualStyleBackColor = true;
      this.buttonSearchPlayerId.Click += new EventHandler(this.buttonSearchPlayerId_Click);
      this.textPlayerId.BackColor = Color.White;
      this.textPlayerId.Location = new Point(88, 25);
      this.textPlayerId.Name = "textPlayerId";
      this.textPlayerId.ReadOnly = true;
      this.textPlayerId.Size = new Size(86, 20);
      this.textPlayerId.TabIndex = 103;
      this.textPlayerId.TextAlign = HorizontalAlignment.Center;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(6, 28);
      this.label1.Name = "label1";
      this.label1.Size = new Size(48, 13);
      this.label1.TabIndex = 102;
      this.label1.Text = "Player Id";
      this.buttonSearchSurnameId.BackgroundImage = (Image) resources.GetObject("buttonSearchSurnameId.BackgroundImage");
      this.buttonSearchSurnameId.BackgroundImageLayout = ImageLayout.Center;
      this.buttonSearchSurnameId.Location = new Point(180, 76);
      this.buttonSearchSurnameId.Name = "buttonSearchSurnameId";
      this.buttonSearchSurnameId.Size = new Size(25, 23);
      this.buttonSearchSurnameId.TabIndex = 101;
      this.toolTip.SetToolTip((Control) this.buttonSearchSurnameId, "Search generic audio for this name");
      this.buttonSearchSurnameId.UseVisualStyleBackColor = true;
      this.buttonSearchSurnameId.Click += new EventHandler(this.buttonSearchSurnameId_Click);
      this.textKnownAs.BackColor = Color.White;
      this.textKnownAs.Location = new Point(88, 52);
      this.textKnownAs.Name = "textKnownAs";
      this.textKnownAs.ReadOnly = true;
      this.textKnownAs.Size = new Size(148, 20);
      this.textKnownAs.TabIndex = 2;
      this.label13.AutoSize = true;
      this.label13.Location = new Point(6, 81);
      this.label13.Name = "label13";
      this.label13.Size = new Size(46, 13);
      this.label13.TabIndex = 1;
      this.label13.Text = "Audio Id";
      this.groupNameDictionary.Controls.Add((Control) this.numericNameDictionary);
      this.groupNameDictionary.Controls.Add((Control) this.listViewNameDictionary);
      this.groupNameDictionary.Controls.Add((Control) this.toolStripNameDictionary);
      this.groupNameDictionary.Controls.Add((Control) this.toolStripSearchnameDictionary);
      this.groupNameDictionary.Location = new Point(320, 40);
      this.groupNameDictionary.Name = "groupNameDictionary";
      this.groupNameDictionary.Size = new Size(364, 736);
      this.groupNameDictionary.TabIndex = 3;
      this.groupNameDictionary.TabStop = false;
      this.groupNameDictionary.Text = "Names Dictionary";
      this.numericNameDictionary.Location = new Point(6, 44);
      this.numericNameDictionary.Maximum = new Decimal(new int[4]
      {
        1000000,
        0,
        0,
        0
      });
      this.numericNameDictionary.Name = "numericNameDictionary";
      this.numericNameDictionary.Size = new Size(80, 20);
      this.numericNameDictionary.TabIndex = 126;
      this.numericNameDictionary.TextAlign = HorizontalAlignment.Center;
      this.numericNameDictionary.ThousandsSeparator = true;
      this.numericNameDictionary.Value = new Decimal(new int[4]
      {
        900000,
        0,
        0,
        0
      });
      this.numericNameDictionary.ValueChanged += new EventHandler(this.numericNameDictionary_ValueChanged);
      this.listViewNameDictionary.AllowDrop = true;
      this.listViewNameDictionary.Columns.AddRange(new ColumnHeader[2]
      {
        this.columnNameId,
        this.columnSurname
      });
      this.listViewNameDictionary.Cursor = Cursors.Hand;
      this.listViewNameDictionary.Dock = DockStyle.Fill;
      this.listViewNameDictionary.FullRowSelect = true;
      this.listViewNameDictionary.GridLines = true;
      this.listViewNameDictionary.HideSelection = false;
      this.listViewNameDictionary.Location = new Point(3, 66);
      this.listViewNameDictionary.MultiSelect = false;
      this.listViewNameDictionary.Name = "listViewNameDictionary";
      this.listViewNameDictionary.Size = new Size(358, 667);
      this.listViewNameDictionary.TabIndex = 9;
      this.listViewNameDictionary.UseCompatibleStateImageBehavior = false;
      this.listViewNameDictionary.View = View.Details;
      this.listViewNameDictionary.ColumnClick += new ColumnClickEventHandler(this.listViewNameDictionary_ColumnClick);
      this.listViewNameDictionary.SelectedIndexChanged += new EventHandler(this.listViewNameDictionary_SelectedIndexChanged);
      this.columnNameId.Text = "N.";
      this.columnNameId.Width = 88;
      this.columnSurname.Text = "Name";
      this.columnSurname.Width = 154;
      this.toolStripNameDictionary.BackgroundImage = (Image) resources.GetObject("toolStripNameDictionary.BackgroundImage");
      this.toolStripNameDictionary.GripStyle = ToolStripGripStyle.Hidden;
      this.toolStripNameDictionary.Items.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.textNameDictionary,
        (ToolStripItem) this.toolStripSeparator7,
        (ToolStripItem) this.buttonAddName,
        (ToolStripItem) this.buttonReplaceName,
        (ToolStripItem) this.buttonRemoveName
      });
      this.toolStripNameDictionary.Location = new Point(3, 41);
      this.toolStripNameDictionary.Name = "toolStripNameDictionary";
      this.toolStripNameDictionary.Size = new Size(358, 25);
      this.toolStripNameDictionary.TabIndex = (int) sbyte.MaxValue;
      this.toolStripNameDictionary.Text = "toolStrip1";
      this.textNameDictionary.Margin = new Padding(90, 0, 1, 0);
      this.textNameDictionary.Name = "textNameDictionary";
      this.textNameDictionary.Size = new Size(150, 25);
      this.textNameDictionary.TextChanged += new EventHandler(this.textNameDictionary_TextChanged);
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      this.toolStripSeparator7.Size = new Size(6, 25);
      this.buttonAddName.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonAddName.Enabled = false;
      this.buttonAddName.Image = (Image) resources.GetObject("buttonAddName.Image");
      this.buttonAddName.ImageTransparentColor = Color.Magenta;
      this.buttonAddName.Name = "buttonAddName";
      this.buttonAddName.Size = new Size(23, 22);
      this.buttonAddName.Text = "Add";
      this.buttonAddName.ToolTipText = "Add to the Names Directory";
      this.buttonAddName.Click += new EventHandler(this.buttonAddName_Click);
      this.buttonReplaceName.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonReplaceName.Enabled = false;
      this.buttonReplaceName.Image = (Image) resources.GetObject("buttonReplaceName.Image");
      this.buttonReplaceName.ImageTransparentColor = Color.Magenta;
      this.buttonReplaceName.Name = "buttonReplaceName";
      this.buttonReplaceName.Size = new Size(23, 22);
      this.buttonReplaceName.Text = "Replace";
      this.buttonReplaceName.ToolTipText = "Replace in the Names Directory";
      this.buttonReplaceName.Click += new EventHandler(this.buttonReplaceName_Click);
      this.buttonRemoveName.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonRemoveName.Enabled = false;
      this.buttonRemoveName.Image = (Image) resources.GetObject("buttonRemoveName.Image");
      this.buttonRemoveName.ImageTransparentColor = Color.Magenta;
      this.buttonRemoveName.Name = "buttonRemoveName";
      this.buttonRemoveName.Size = new Size(23, 22);
      this.buttonRemoveName.Text = "Remove";
      this.buttonRemoveName.ToolTipText = "Remove from the Names Directory";
      this.buttonRemoveName.Click += new EventHandler(this.buttonRemoveName_Click);
      this.toolStripSearchnameDictionary.BackgroundImage = (Image) resources.GetObject("toolStripSearchnameDictionary.BackgroundImage");
      this.toolStripSearchnameDictionary.GripStyle = ToolStripGripStyle.Hidden;
      this.toolStripSearchnameDictionary.Items.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) this.toolStripLabel1,
        (ToolStripItem) this.textSearchNameDictionary,
        (ToolStripItem) this.toolStripSeparator6,
        (ToolStripItem) this.buttonFindNameExact,
        (ToolStripItem) this.buttonFindNameStart,
        (ToolStripItem) this.buttonFindNameAny
      });
      this.toolStripSearchnameDictionary.Location = new Point(3, 16);
      this.toolStripSearchnameDictionary.Name = "toolStripSearchnameDictionary";
      this.toolStripSearchnameDictionary.Size = new Size(358, 25);
      this.toolStripSearchnameDictionary.TabIndex = 125;
      this.toolStripLabel1.AutoSize = false;
      this.toolStripLabel1.Name = "toolStripLabel1";
      this.toolStripLabel1.Size = new Size(90, 22);
      this.toolStripLabel1.Text = "Search";
      this.textSearchNameDictionary.Margin = new Padding(0, 0, 1, 0);
      this.textSearchNameDictionary.Name = "textSearchNameDictionary";
      this.textSearchNameDictionary.Size = new Size(150, 25);
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      this.toolStripSeparator6.Size = new Size(6, 25);
      this.buttonFindNameExact.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonFindNameExact.Image = (Image) resources.GetObject("buttonFindNameExact.Image");
      this.buttonFindNameExact.ImageTransparentColor = Color.Magenta;
      this.buttonFindNameExact.Name = "buttonFindNameExact";
      this.buttonFindNameExact.Size = new Size(23, 22);
      this.buttonFindNameExact.Text = "Search Exactly";
      this.buttonFindNameExact.Click += new EventHandler(this.buttonFindNameExact_Click);
      this.buttonFindNameStart.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonFindNameStart.Image = (Image) resources.GetObject("buttonFindNameStart.Image");
      this.buttonFindNameStart.ImageTransparentColor = Color.Magenta;
      this.buttonFindNameStart.Name = "buttonFindNameStart";
      this.buttonFindNameStart.Size = new Size(23, 22);
      this.buttonFindNameStart.Text = "Search if starting with";
      this.buttonFindNameStart.Click += new EventHandler(this.buttonFindNameStart_Click);
      this.buttonFindNameAny.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonFindNameAny.Image = (Image) resources.GetObject("buttonFindNameAny.Image");
      this.buttonFindNameAny.ImageTransparentColor = Color.Magenta;
      this.buttonFindNameAny.Name = "buttonFindNameAny";
      this.buttonFindNameAny.Size = new Size(23, 22);
      this.buttonFindNameAny.Text = "Search if containing";
      this.buttonFindNameAny.Click += new EventHandler(this.buttonFindNameAny_Click);
      this.pickUpControl.BackColor = SystemColors.Control;
      this.pickUpControl.CloneButtonEnabled = false;
      this.pickUpControl.CreateButtonEnabled = false;
      this.pickUpControl.CurrentIndex = 0;
      this.pickUpControl.Dock = DockStyle.Top;
      this.pickUpControl.FilterByList = new string[4]
      {
        "All",
        "by Team",
        "by Country",
        "Free Agents"
      };
      this.pickUpControl.FilterEnabled = true;
      this.pickUpControl.FilterValues = (IdArrayList[]) null;
      this.pickUpControl.Location = new Point(0, 0);
      this.pickUpControl.MainSelectionEnabled = true;
      this.pickUpControl.Name = "pickUpControl";
      this.pickUpControl.ObjectList = (IdArrayList) null;
      this.pickUpControl.RefreshButtonEnabled = true;
      this.pickUpControl.RemoveButtonEnabled = false;
      this.pickUpControl.SearchEnabled = true;
      this.pickUpControl.Size = new Size(1165, 25);
      this.pickUpControl.TabIndex = 1;
      this.pickUpControl.WizardButtonEnabled = false;
      this.pickUpControl.YoungPlayersEnabled = false;
      this.groupPlayerInfo.Controls.Add((Control) this.labelCommonName);
      this.groupPlayerInfo.Controls.Add((Control) this.textCommonName);
      this.groupPlayerInfo.Controls.Add((Control) this.viewer2DPhoto);
      this.groupPlayerInfo.Controls.Add((Control) this.textSurname);
      this.groupPlayerInfo.Controls.Add((Control) this.textFirstName);
      this.groupPlayerInfo.Controls.Add((Control) this.labelFirstName);
      this.groupPlayerInfo.Controls.Add((Control) this.labelSurame);
      this.groupPlayerInfo.Location = new Point(12, 195);
      this.groupPlayerInfo.Name = "groupPlayerInfo";
      this.groupPlayerInfo.Size = new Size(292, 160);
      this.groupPlayerInfo.TabIndex = 93;
      this.groupPlayerInfo.TabStop = false;
      this.labelCommonName.AutoSize = true;
      this.labelCommonName.ImeMode = ImeMode.NoControl;
      this.labelCommonName.Location = new Point(148, 106);
      this.labelCommonName.Name = "labelCommonName";
      this.labelCommonName.Size = new Size(79, 13);
      this.labelCommonName.TabIndex = 168;
      this.labelCommonName.Text = "Common Name";
      this.labelCommonName.TextAlign = ContentAlignment.MiddleLeft;
      this.textCommonName.BackColor = Color.White;
      this.textCommonName.Location = new Point(147, 122);
      this.textCommonName.Name = "textCommonName";
      this.textCommonName.ReadOnly = true;
      this.textCommonName.Size = new Size(131, 20);
      this.textCommonName.TabIndex = 166;
      this.textCommonName.TextAlign = HorizontalAlignment.Right;
      this.viewer2DPhoto.AutoTransparency = false;
      this.viewer2DPhoto.BackColor = Color.Transparent;
      this.viewer2DPhoto.ButtonStripVisible = false;
      this.viewer2DPhoto.CurrentBitmap = (Bitmap) null;
      this.viewer2DPhoto.ExtendedFormat = false;
      this.viewer2DPhoto.FullSizeButton = false;
      this.viewer2DPhoto.ImageLayout = ImageLayout.None;
      this.viewer2DPhoto.ImageSize = new Size(128, 128);
      this.viewer2DPhoto.ImageSizeMultiplier = Viewer2D.SizeMultiplier.MiniFace;
      this.viewer2DPhoto.Location = new Point(6, 19);
      this.viewer2DPhoto.Name = "viewer2DPhoto";
      this.viewer2DPhoto.RemoveButton = false;
      this.viewer2DPhoto.ShowButton = false;
      this.viewer2DPhoto.ShowButtonChecked = true;
      this.viewer2DPhoto.Size = new Size(128, 128);
      this.viewer2DPhoto.TabIndex = 167;
      this.viewer2DPhoto.TabStop = false;
      this.textSurname.BackColor = Color.White;
      this.textSurname.Location = new Point(147, 83);
      this.textSurname.Name = "textSurname";
      this.textSurname.ReadOnly = true;
      this.textSurname.Size = new Size(131, 20);
      this.textSurname.TabIndex = 163;
      this.textSurname.TextAlign = HorizontalAlignment.Right;
      this.textFirstName.BackColor = Color.White;
      this.textFirstName.Location = new Point(147, 44);
      this.textFirstName.Name = "textFirstName";
      this.textFirstName.ReadOnly = true;
      this.textFirstName.Size = new Size(131, 20);
      this.textFirstName.TabIndex = 162;
      this.textFirstName.TextAlign = HorizontalAlignment.Right;
      this.labelFirstName.AutoSize = true;
      this.labelFirstName.ImeMode = ImeMode.NoControl;
      this.labelFirstName.Location = new Point(148, 28);
      this.labelFirstName.Name = "labelFirstName";
      this.labelFirstName.Size = new Size(57, 13);
      this.labelFirstName.TabIndex = 164;
      this.labelFirstName.Text = "First Name";
      this.labelFirstName.TextAlign = ContentAlignment.MiddleLeft;
      this.labelSurame.AutoSize = true;
      this.labelSurame.ImeMode = ImeMode.NoControl;
      this.labelSurame.Location = new Point(148, 67);
      this.labelSurame.Name = "labelSurame";
      this.labelSurame.Size = new Size(58, 13);
      this.labelSurame.TabIndex = 165;
      this.labelSurame.Text = "Last Name";
      this.labelSurame.TextAlign = ContentAlignment.MiddleLeft;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1165, 798);
      this.Controls.Add((Control) this.groupPlayerInfo);
      this.Controls.Add((Control) this.groupNameDictionary);
      this.Controls.Add((Control) this.groupAudio);
      this.Controls.Add((Control) this.pickUpControl);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = "AudioForm";
      this.Text = "aUDIOForm";
      this.Load += new EventHandler(this.AudioForm_Load);
      this.groupAudio.ResumeLayout(false);
      this.groupAudio.PerformLayout();
      this.groupNameDictionary.ResumeLayout(false);
      this.groupNameDictionary.PerformLayout();
      this.numericNameDictionary.EndInit();
      this.toolStripNameDictionary.ResumeLayout(false);
      this.toolStripNameDictionary.PerformLayout();
      this.toolStripSearchnameDictionary.ResumeLayout(false);
      this.toolStripSearchnameDictionary.PerformLayout();
      this.groupPlayerInfo.ResumeLayout(false);
      this.groupPlayerInfo.PerformLayout();
      this.ResumeLayout(false);
    }

    public AudioForm()
    {
      this.InitializeComponent();
      this.pickUpControl.SelectObject = new PickUpControl.PickUpCallback(this.SelectPlayerAudio);
      this.viewer2DPhoto.ButtonStripVisible = false;
    }

    public void Clean()
    {
      this.Visible = false;
    }

    public void Preset()
    {
      this.pickUpControl.FilterValues = new IdArrayList[5]
      {
        (IdArrayList) null,
        (IdArrayList) FifaEnvironment.Teams,
        (IdArrayList) FifaEnvironment.Countries,
        (IdArrayList) FifaEnvironment.FreeAgents,
        null
      };
      this.pickUpControl.ObjectList = (IdArrayList) FifaEnvironment.Players;
    }

    private void AudioForm_Load(object sender, EventArgs e)
    {
      this.m_IsLoaded = true;
      this.Preset();
      this.LoadNameDictionary();
    }

    public void LoadPlayerAudio(Player player)
    {
      if (!this.m_IsLoaded)
        return;
      this.m_CurrentPlayer = player;
      this.textKnownAs.Text = this.m_CurrentPlayer.audioname;
      this.textPlayerId.Text = this.m_CurrentPlayer.Id.ToString();
      string str = (string) null;
      FifaEnvironment.NameDictionary.TryGetValue(this.m_CurrentPlayer.Id, out str);
      if (str != null)
        this.textSurnameSoundId.Text = this.m_CurrentPlayer.Id.ToString();
      else if (str == null)
      {
        FifaEnvironment.NameDictionary.TryGetValue(this.m_CurrentPlayer.commentaryid, out str);
        if (str != null)
          this.textSurnameSoundId.Text = this.m_CurrentPlayer.commentaryid.ToString();
        else
          this.textSurnameSoundId.Text = "Not Assigned";
      }
      this.textAudioName.Text = str;
      this.viewer2DPhoto.CurrentBitmap = this.m_CurrentPlayer.GetPhoto();
      this.textFirstName.Text = this.m_CurrentPlayer.firstname;
      this.textSurname.Text = this.m_CurrentPlayer.lastname;
      this.textCommonName.Text = this.m_CurrentPlayer.commonname;
      this.EnableDictionaryButtons();
    }

    public void LoadNameDictionary()
    {
      if (!this.m_IsLoaded)
        return;
      this.listViewNameDictionary.BeginUpdate();
      this.listViewNameDictionary.Items.Clear();
      foreach (KeyValuePair<int, string> name in (Dictionary<int, string>) FifaEnvironment.NameDictionary)
      {
        int key = name.Key;
        string str = name.Value;
        this.listViewNameDictionary.Items.Add(new ListViewItem(key.ToString().PadLeft(6))
        {
          SubItems = {
            str
          },
          Tag = (object) name
        });
      }
      this.listViewNameDictionary.EndUpdate();
    }

    private Player SelectPlayerAudio(object sender, object obj)
    {
      Player player = (Player) obj;
      this.LoadPlayerAudio(player);
      return player;
    }

    private void listViewNameDictionary_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      ListView listView = (ListView) sender;
      SortOrder sortOrder = listView.Sorting != SortOrder.Ascending ? SortOrder.Ascending : SortOrder.Descending;
      listView.Sorting = sortOrder;
      listView.ListViewItemSorter = (IComparer) new ListViewItemComparer(e.Column, sortOrder);
      this.KeepSelectedNameVisible();
    }

    private void listViewNameDictionary_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.listViewNameDictionary.SelectedItems.Count <= 0)
        return;
      this.ShowSelectedNameDictionary();
      this.EnableDictionaryButtons();
    }

    private void numericNameDictionary_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_CurrentDictionaryKey == (int) this.numericNameDictionary.Value)
        return;
      this.m_CurrentDictionaryKey = (int) this.numericNameDictionary.Value;
      if (!this.SelectNameDictionaryItem(this.m_CurrentDictionaryKey))
        this.textNameDictionary.Text = "<Unknown>";
      else
        this.KeepSelectedNameVisible();
      this.EnableDictionaryButtons();
    }

    private void textNameDictionary_TextChanged(object sender, EventArgs e)
    {
      if (this.m_CurrentDictionaryName == this.textNameDictionary.Text)
        return;
      this.m_CurrentDictionaryName = this.textNameDictionary.Text;
      this.EnableDictionaryButtons();
    }

    private void EnableDictionaryButtons()
    {
      this.buttonSearchSurnameId.Enabled = this.buttonDeleteSound.Enabled = this.m_CurrentPlayer.commentaryid > 900000;
      if (this.m_CurrentDictionaryKey == 900000)
      {
        this.buttonReplaceName.Enabled = false;
        this.buttonRemoveName.Enabled = false;
        this.buttonAddName.Enabled = false;
        this.buttonSetSound.Enabled = false;
      }
      else if (FifaEnvironment.NameDictionary.ContainsKey(this.m_CurrentDictionaryKey))
      {
        this.buttonRemoveName.Enabled = true;
        this.buttonAddName.Enabled = false;
        string str;
        if (!FifaEnvironment.NameDictionary.TryGetValue(this.m_CurrentDictionaryKey, out str))
          return;
        if (str == this.m_CurrentDictionaryName)
        {
          this.buttonReplaceName.Enabled = false;
          this.buttonSetSound.Enabled = this.m_CurrentDictionaryKey > 900000;
        }
        else
        {
          this.buttonReplaceName.Enabled = true;
          this.buttonSetSound.Enabled = false;
        }
      }
      else
      {
        this.buttonRemoveName.Enabled = false;
        this.buttonReplaceName.Enabled = false;
        this.buttonAddName.Enabled = true;
        this.buttonSetSound.Enabled = false;
      }
    }

    private bool SelectNameDictionaryItem(int commentaryid)
    {
      if (this.listViewNameDictionary.SelectedItems.Count > 0)
        this.listViewNameDictionary.SelectedItems[0].Selected = false;
      for (int index = 0; index < this.listViewNameDictionary.Items.Count; ++index)
      {
        if (((KeyValuePair<int, string>) this.listViewNameDictionary.Items[index].Tag).Key == commentaryid)
        {
          this.listViewNameDictionary.Items[index].Selected = true;
          if (index > 8)
            this.listViewNameDictionary.TopItem = this.listViewNameDictionary.Items[index - 8];
          return true;
        }
      }
      return false;
    }

    private void KeepSelectedNameVisible()
    {
      if (this.listViewNameDictionary.SelectedItems.Count <= 0)
        return;
      int selectedIndex = this.listViewNameDictionary.SelectedIndices[0];
      if (selectedIndex <= 8)
        return;
      this.listViewNameDictionary.TopItem = this.listViewNameDictionary.Items[selectedIndex - 8];
    }

    private void ShowSelectedNameDictionary()
    {
      if (this.listViewNameDictionary.SelectedItems.Count <= 0)
        return;
      this.m_SelectedDictionaryName = (KeyValuePair<int, string>) this.listViewNameDictionary.SelectedItems[0].Tag;
      this.m_CurrentDictionaryKey = this.m_SelectedDictionaryName.Key;
      this.m_CurrentDictionaryName = this.m_SelectedDictionaryName.Value;
      this.numericNameDictionary.Value = (Decimal) this.m_CurrentDictionaryKey;
      this.textNameDictionary.Text = this.m_CurrentDictionaryName;
    }

    private void buttonFindNameExact_Click(object sender, EventArgs e)
    {
      this.m_SearchMode = AudioForm.SearchMode.SearchExact;
      this.Search();
    }

    private void buttonFindNameStart_Click(object sender, EventArgs e)
    {
      this.m_SearchMode = AudioForm.SearchMode.SearchStarting;
      this.Search();
    }

    private void buttonFindNameAny_Click(object sender, EventArgs e)
    {
      this.m_SearchMode = AudioForm.SearchMode.SearchContaining;
      this.Search();
    }

    public bool Search()
    {
      bool flag = false;
      if (this.textSearchNameDictionary.Text == null || this.textSearchNameDictionary.Text == string.Empty)
        return false;
      this.m_Pattern = this.textSearchNameDictionary.Text;
      this.m_Pattern = this.m_Pattern.ToLower();
      int index = this.m_CurrentSearchIndex + 1;
      if (index >= this.listViewNameDictionary.Items.Count)
        index = 0;
      while (true)
      {
        do
        {
          KeyValuePair<int, string> tag = (KeyValuePair<int, string>) this.listViewNameDictionary.Items[index].Tag;
          string lower = tag.Value.ToLower();
          switch (this.m_SearchMode)
          {
            case AudioForm.SearchMode.SearchExact:
              flag = lower.ToString().Equals(this.m_Pattern);
              break;
            case AudioForm.SearchMode.SearchStarting:
              flag = lower.ToString().StartsWith(this.m_Pattern);
              break;
            case AudioForm.SearchMode.SearchContaining:
              flag = lower.Contains(this.m_Pattern);
              break;
          }
          if (flag)
          {
            this.m_CurrentSearchIndex = index;
            this.numericNameDictionary.Value = (Decimal) tag.Key;
            return true;
          }
          if (index != this.m_CurrentSearchIndex)
            ++index;
          else
            goto label_13;
        }
        while (index != this.listViewNameDictionary.Items.Count);
        index = 0;
      }
label_13:
      return false;
    }

    private void buttonAddName_Click(object sender, EventArgs e)
    {
      FifaEnvironment.NameDictionary.Add(this.m_CurrentDictionaryKey, this.m_CurrentDictionaryName);
      ListViewItem listViewItem = new ListViewItem(this.m_CurrentDictionaryKey.ToString().PadLeft(6));
      listViewItem.SubItems.Add(this.m_CurrentDictionaryName);
      KeyValuePair<int, string> keyValuePair = new KeyValuePair<int, string>(this.m_CurrentDictionaryKey, this.m_CurrentDictionaryName);
      listViewItem.Tag = (object) keyValuePair;
      this.listViewNameDictionary.Items.Add(listViewItem);
      this.SelectNameDictionaryItem(this.m_CurrentDictionaryKey);
      this.EnableDictionaryButtons();
    }

    private void buttonRemoveName_Click(object sender, EventArgs e)
    {
      FifaEnvironment.NameDictionary.Remove(this.m_CurrentDictionaryKey);
      for (int index = 0; index < this.listViewNameDictionary.Items.Count; ++index)
      {
        if (((KeyValuePair<int, string>) this.listViewNameDictionary.Items[index].Tag).Key == this.m_CurrentDictionaryKey)
        {
          this.listViewNameDictionary.Items.RemoveAt(index);
          this.EnableDictionaryButtons();
          break;
        }
      }
    }

    private void buttonReplaceName_Click(object sender, EventArgs e)
    {
      FifaEnvironment.NameDictionary.Remove(this.m_CurrentDictionaryKey);
      FifaEnvironment.NameDictionary.Add(this.m_CurrentDictionaryKey, this.m_CurrentDictionaryName);
      for (int index = 0; index < this.listViewNameDictionary.Items.Count; ++index)
      {
        if (((KeyValuePair<int, string>) this.listViewNameDictionary.Items[index].Tag).Key == this.m_CurrentDictionaryKey)
        {
          this.listViewNameDictionary.Items[index].SubItems[1].Text = this.m_CurrentDictionaryName;
          this.EnableDictionaryButtons();
          break;
        }
      }
    }

    private void buttonSearchPlayerId_Click(object sender, EventArgs e)
    {
      this.numericNameDictionary.Value = (Decimal) this.m_CurrentPlayer.Id;
    }

    private void buttonSearchSurnameId_Click(object sender, EventArgs e)
    {
      if (this.m_CurrentPlayer.commentaryid == 900000)
        return;
      this.numericNameDictionary.Value = (Decimal) this.m_CurrentPlayer.commentaryid;
    }

    private void buttonDeleteSound_Click(object sender, EventArgs e)
    {
      FifaEnvironment.Players.SetGenericAudio(this.m_CurrentPlayer.audioname, 900000);
      this.LoadPlayerAudio(this.m_CurrentPlayer);
    }

    private void buttonSetSound_Click(object sender, EventArgs e)
    {
      FifaEnvironment.Players.SetGenericAudio(this.m_CurrentPlayer.audioname, this.m_CurrentDictionaryKey);
      this.LoadPlayerAudio(this.m_CurrentPlayer);
    }

    private enum SearchMode
    {
      SearchExact,
      SearchStarting,
      SearchContaining,
    }
  }
}
