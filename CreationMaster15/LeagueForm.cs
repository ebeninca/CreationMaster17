// Original code created by Rinaldo

using FifaControls;
using FifaLibrary;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace CreationMaster
{
  public class LeagueForm : Form
  {
    private NewIdCreator m_NewIdCreator = new NewIdCreator();
    private IContainer components;
    public PickUpControl pickUpControl;
    private FlowLayoutPanel flowPanel;
    private GroupBox groupBoxTeams;
    private ListView listViewPlayingTeams;
    private ToolStrip toolStripTeamAvailable;
    private ToolStripSeparator separatorBegin;
    public ToolStripComboBox comboTeamAvailable;
    private ToolStripSeparator separatorButtons;
    public ToolStripButton buttonAddTeam;
    public ToolStripButton buttonReplaceTeam;
    public ToolStripButton buttonRemoveTeam;
    private ToolStripSeparator separatorShowLogo;
    private ToolStripButton checkShowTeamLogo;
    private GroupBox groupBoxNames;
    private TextBox textLeagueFullName;
    private Label labelLeagueFullName;
    private TextBox textLeagueShortName;
    private Label labelLeagueShortName;
    private TextBox textDatabaseLeagueName;
    private Label labelDatabaseLeagueName;
    private GroupBox groupBox3;
    private Label labelLeagueId;
    private Button buttonGetId;
    private ComboBox comboLeagueCountry;
    private NumericUpDown numericLeagueId;
    private Label labelCountry;
    private Label labelLeagueLevel;
    private NumericUpDown numericLeagueLevel;
    private ImageList imageListTeamLogos;
    private BindingSource leagueBindingSource;
    private BindingSource countryListBindingSource;
    private Viewer2D viewer2DLeagueTinyLogo;
    private Button buttonreplicateLeagueTinyLogo;
    private Viewer2D viewer2DLeagueAnimLogo;
    private Viewer2D viewer2DLeagueSmallLogo;
    private Button buttonreplicateLeagueSmallLogo;
    private GroupBox groupSwitchLeagues;
    private Label labelThisLeague;
    private Button buttonSwitchLeagueIds;
    private ComboBox comboSwitchLeagues;
    private GroupBox groupLeaguePlayerTuning;
    private Button buttonLeaguePlayerMinus;
    private Button buttonLeaguePlayerPlus;
    private CheckBox checkReplayLogo;
    private GroupBox groupBox1;
    private NumericUpDown numericBoardOutcome5;
    private Label label4;
    private NumericUpDown numericBoardOutcome4;
    private Label label5;
    private NumericUpDown numericBoardOutcome3;
    private Label label3;
    private NumericUpDown numericBoardOutcome2;
    private Label label2;
    private NumericUpDown numericBoardOutcome1;
    private Label label1;
    private Viewer2D viewer2DLeague512x128Logo;
    private Button buttonreplicateLeagueLogo512x128;
    private League m_CurrentLeague;
    private bool m_IsLoaded;
    private bool m_Locked;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager resources = new ComponentResourceManager(typeof (LeagueForm));
      this.flowPanel = new FlowLayoutPanel();
      this.groupBoxTeams = new GroupBox();
      this.listViewPlayingTeams = new ListView();
      this.imageListTeamLogos = new ImageList(this.components);
      this.toolStripTeamAvailable = new ToolStrip();
      this.separatorBegin = new ToolStripSeparator();
      this.comboTeamAvailable = new ToolStripComboBox();
      this.separatorButtons = new ToolStripSeparator();
      this.buttonAddTeam = new ToolStripButton();
      this.buttonReplaceTeam = new ToolStripButton();
      this.buttonRemoveTeam = new ToolStripButton();
      this.separatorShowLogo = new ToolStripSeparator();
      this.checkShowTeamLogo = new ToolStripButton();
      this.groupBox3 = new GroupBox();
      this.buttonreplicateLeagueLogo512x128 = new Button();
      this.viewer2DLeague512x128Logo = new Viewer2D();
      this.buttonreplicateLeagueSmallLogo = new Button();
      this.buttonreplicateLeagueTinyLogo = new Button();
      this.viewer2DLeagueTinyLogo = new Viewer2D();
      this.viewer2DLeagueSmallLogo = new Viewer2D();
      this.viewer2DLeagueAnimLogo = new Viewer2D();
      this.groupBoxNames = new GroupBox();
      this.checkReplayLogo = new CheckBox();
      this.textLeagueFullName = new TextBox();
      this.leagueBindingSource = new BindingSource(this.components);
      this.labelLeagueFullName = new Label();
      this.labelLeagueId = new Label();
      this.buttonGetId = new Button();
      this.groupBox1 = new GroupBox();
      this.numericBoardOutcome5 = new NumericUpDown();
      this.label4 = new Label();
      this.numericBoardOutcome4 = new NumericUpDown();
      this.label5 = new Label();
      this.numericBoardOutcome3 = new NumericUpDown();
      this.label3 = new Label();
      this.numericBoardOutcome2 = new NumericUpDown();
      this.label2 = new Label();
      this.numericBoardOutcome1 = new NumericUpDown();
      this.label1 = new Label();
      this.textLeagueShortName = new TextBox();
      this.labelLeagueShortName = new Label();
      this.textDatabaseLeagueName = new TextBox();
      this.comboLeagueCountry = new ComboBox();
      this.labelDatabaseLeagueName = new Label();
      this.numericLeagueId = new NumericUpDown();
      this.numericLeagueLevel = new NumericUpDown();
      this.labelCountry = new Label();
      this.labelLeagueLevel = new Label();
      this.groupSwitchLeagues = new GroupBox();
      this.labelThisLeague = new Label();
      this.buttonSwitchLeagueIds = new Button();
      this.comboSwitchLeagues = new ComboBox();
      this.groupLeaguePlayerTuning = new GroupBox();
      this.buttonLeaguePlayerMinus = new Button();
      this.buttonLeaguePlayerPlus = new Button();
      this.pickUpControl = new PickUpControl();
      this.countryListBindingSource = new BindingSource(this.components);
      this.flowPanel.SuspendLayout();
      this.groupBoxTeams.SuspendLayout();
      this.toolStripTeamAvailable.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBoxNames.SuspendLayout();
      ((ISupportInitialize) this.leagueBindingSource).BeginInit();
      this.groupBox1.SuspendLayout();
      this.numericBoardOutcome5.BeginInit();
      this.numericBoardOutcome4.BeginInit();
      this.numericBoardOutcome3.BeginInit();
      this.numericBoardOutcome2.BeginInit();
      this.numericBoardOutcome1.BeginInit();
      this.numericLeagueId.BeginInit();
      this.numericLeagueLevel.BeginInit();
      this.groupSwitchLeagues.SuspendLayout();
      this.groupLeaguePlayerTuning.SuspendLayout();
      ((ISupportInitialize) this.countryListBindingSource).BeginInit();
      this.SuspendLayout();
      this.flowPanel.AutoScroll = true;
      this.flowPanel.Controls.Add((Control) this.groupBoxTeams);
      this.flowPanel.Controls.Add((Control) this.groupBox3);
      this.flowPanel.Controls.Add((Control) this.groupBoxNames);
      this.flowPanel.Controls.Add((Control) this.groupSwitchLeagues);
      this.flowPanel.Controls.Add((Control) this.groupLeaguePlayerTuning);
      this.flowPanel.Dock = DockStyle.Fill;
      this.flowPanel.Location = new Point(0, 25);
      this.flowPanel.Name = "flowPanel";
      this.flowPanel.Size = new Size(1165, 755);
      this.flowPanel.TabIndex = 2;
      this.groupBoxTeams.Controls.Add((Control) this.listViewPlayingTeams);
      this.groupBoxTeams.Controls.Add((Control) this.toolStripTeamAvailable);
      this.groupBoxTeams.Location = new Point(3, 3);
      this.groupBoxTeams.Name = "groupBoxTeams";
      this.groupBoxTeams.Size = new Size(467, 454);
      this.groupBoxTeams.TabIndex = 0;
      this.groupBoxTeams.TabStop = false;
      this.groupBoxTeams.Text = "Teams";
      this.listViewPlayingTeams.Cursor = Cursors.Hand;
      this.listViewPlayingTeams.Dock = DockStyle.Fill;
      this.listViewPlayingTeams.FullRowSelect = true;
      this.listViewPlayingTeams.GridLines = true;
      this.listViewPlayingTeams.HideSelection = false;
      this.listViewPlayingTeams.LargeImageList = this.imageListTeamLogos;
      this.listViewPlayingTeams.Location = new Point(3, 41);
      this.listViewPlayingTeams.MultiSelect = false;
      this.listViewPlayingTeams.Name = "listViewPlayingTeams";
      this.listViewPlayingTeams.Size = new Size(461, 410);
      this.listViewPlayingTeams.TabIndex = 0;
      this.listViewPlayingTeams.UseCompatibleStateImageBehavior = false;
      this.listViewPlayingTeams.DoubleClick += new EventHandler(this.listViewPlayingTeams_DoubleClick);
      this.imageListTeamLogos.ColorDepth = ColorDepth.Depth8Bit;
      this.imageListTeamLogos.ImageSize = new Size(32, 32);
      this.imageListTeamLogos.TransparentColor = Color.Transparent;
      this.toolStripTeamAvailable.GripStyle = ToolStripGripStyle.Hidden;
      this.toolStripTeamAvailable.Items.AddRange(new ToolStripItem[8]
      {
        (ToolStripItem) this.separatorBegin,
        (ToolStripItem) this.comboTeamAvailable,
        (ToolStripItem) this.separatorButtons,
        (ToolStripItem) this.buttonAddTeam,
        (ToolStripItem) this.buttonReplaceTeam,
        (ToolStripItem) this.buttonRemoveTeam,
        (ToolStripItem) this.separatorShowLogo,
        (ToolStripItem) this.checkShowTeamLogo
      });
      this.toolStripTeamAvailable.Location = new Point(3, 16);
      this.toolStripTeamAvailable.Name = "toolStripTeamAvailable";
      this.toolStripTeamAvailable.Size = new Size(461, 25);
      this.toolStripTeamAvailable.TabIndex = 124;
      this.separatorBegin.Name = "separatorBegin";
      this.separatorBegin.Size = new Size(6, 25);
      this.comboTeamAvailable.DropDownHeight = 256;
      this.comboTeamAvailable.IntegralHeight = false;
      this.comboTeamAvailable.MaxDropDownItems = 16;
      this.comboTeamAvailable.Name = "comboTeamAvailable";
      this.comboTeamAvailable.Size = new Size(150, 25);
      this.separatorButtons.Name = "separatorButtons";
      this.separatorButtons.Size = new Size(6, 25);
      this.buttonAddTeam.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonAddTeam.Image = (Image) resources.GetObject("buttonAddTeam.Image");
      this.buttonAddTeam.ImageTransparentColor = Color.Magenta;
      this.buttonAddTeam.Name = "buttonAddTeam";
      this.buttonAddTeam.Size = new Size(23, 22);
      this.buttonAddTeam.Text = "Add";
      this.buttonAddTeam.Click += new EventHandler(this.buttonAddTeam_Click);
      this.buttonReplaceTeam.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonReplaceTeam.Image = (Image) resources.GetObject("buttonReplaceTeam.Image");
      this.buttonReplaceTeam.ImageTransparentColor = Color.Magenta;
      this.buttonReplaceTeam.Name = "buttonReplaceTeam";
      this.buttonReplaceTeam.Size = new Size(23, 22);
      this.buttonReplaceTeam.Text = "Replace";
      this.buttonReplaceTeam.Click += new EventHandler(this.buttonReplaceTeam_Click);
      this.buttonRemoveTeam.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonRemoveTeam.Image = (Image) resources.GetObject("buttonRemoveTeam.Image");
      this.buttonRemoveTeam.ImageTransparentColor = Color.Magenta;
      this.buttonRemoveTeam.Name = "buttonRemoveTeam";
      this.buttonRemoveTeam.Size = new Size(23, 22);
      this.buttonRemoveTeam.Text = "Remove";
      this.buttonRemoveTeam.Click += new EventHandler(this.buttonRemoveTeam_Click);
      this.separatorShowLogo.Name = "separatorShowLogo";
      this.separatorShowLogo.Size = new Size(6, 25);
      this.checkShowTeamLogo.Checked = true;
      this.checkShowTeamLogo.CheckOnClick = true;
      this.checkShowTeamLogo.CheckState = CheckState.Checked;
      this.checkShowTeamLogo.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.checkShowTeamLogo.Image = (Image) resources.GetObject("checkShowTeamLogo.Image");
      this.checkShowTeamLogo.ImageTransparentColor = Color.Magenta;
      this.checkShowTeamLogo.Name = "checkShowTeamLogo";
      this.checkShowTeamLogo.Size = new Size(103, 22);
      this.checkShowTeamLogo.Text = "Show Team Logo";
      this.checkShowTeamLogo.Click += new EventHandler(this.checkShowTeamLogo_CheckedChanged);
      this.groupBox3.Controls.Add((Control) this.buttonreplicateLeagueLogo512x128);
      this.groupBox3.Controls.Add((Control) this.viewer2DLeague512x128Logo);
      this.groupBox3.Controls.Add((Control) this.buttonreplicateLeagueSmallLogo);
      this.groupBox3.Controls.Add((Control) this.buttonreplicateLeagueTinyLogo);
      this.groupBox3.Controls.Add((Control) this.viewer2DLeagueTinyLogo);
      this.groupBox3.Controls.Add((Control) this.viewer2DLeagueSmallLogo);
      this.groupBox3.Controls.Add((Control) this.viewer2DLeagueAnimLogo);
      this.groupBox3.Location = new Point(476, 3);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(532, 454);
      this.groupBox3.TabIndex = 3;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Logos";
      this.buttonreplicateLeagueLogo512x128.Location = new Point(138, 426);
      this.buttonreplicateLeagueLogo512x128.Name = "buttonreplicateLeagueLogo512x128";
      this.buttonreplicateLeagueLogo512x128.Size = new Size(70, 23);
      this.buttonreplicateLeagueLogo512x128.TabIndex = 159;
      this.buttonreplicateLeagueLogo512x128.Text = "Replicate";
      this.buttonreplicateLeagueLogo512x128.UseVisualStyleBackColor = true;
      this.buttonreplicateLeagueLogo512x128.Click += new EventHandler(this.buttonreplicateLeagueLogo512x128_Click);
      this.viewer2DLeague512x128Logo.AutoTransparency = true;
      this.viewer2DLeague512x128Logo.BackColor = Color.Transparent;
      this.viewer2DLeague512x128Logo.ButtonStripVisible = true;
      this.viewer2DLeague512x128Logo.CurrentBitmap = (Bitmap) null;
      this.viewer2DLeague512x128Logo.ExtendedFormat = false;
      this.viewer2DLeague512x128Logo.FullSizeButton = false;
      this.viewer2DLeague512x128Logo.ImageLayout = ImageLayout.None;
      this.viewer2DLeague512x128Logo.ImageSize = new Size(512, 128);
      this.viewer2DLeague512x128Logo.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DLeague512x128Logo.Location = new Point(6, 297);
      this.viewer2DLeague512x128Logo.Name = "viewer2DLeague512x128Logo";
      this.viewer2DLeague512x128Logo.RemoveButton = true;
      this.viewer2DLeague512x128Logo.ShowButton = false;
      this.viewer2DLeague512x128Logo.ShowButtonChecked = true;
      this.viewer2DLeague512x128Logo.Size = new Size(512, 153);
      this.viewer2DLeague512x128Logo.TabIndex = 158;
      this.buttonreplicateLeagueSmallLogo.Location = new Point(399, 268);
      this.buttonreplicateLeagueSmallLogo.Name = "buttonreplicateLeagueSmallLogo";
      this.buttonreplicateLeagueSmallLogo.Size = new Size(70, 23);
      this.buttonreplicateLeagueSmallLogo.TabIndex = 158;
      this.buttonreplicateLeagueSmallLogo.Text = "Replicate";
      this.buttonreplicateLeagueSmallLogo.UseVisualStyleBackColor = true;
      this.buttonreplicateLeagueSmallLogo.Click += new EventHandler(this.buttonreplicateLeagueSmallLogo_Click);
      this.buttonreplicateLeagueTinyLogo.Location = new Point(399, 85);
      this.buttonreplicateLeagueTinyLogo.Name = "buttonreplicateLeagueTinyLogo";
      this.buttonreplicateLeagueTinyLogo.Size = new Size(75, 23);
      this.buttonreplicateLeagueTinyLogo.TabIndex = 3;
      this.buttonreplicateLeagueTinyLogo.Text = "Replicate";
      this.buttonreplicateLeagueTinyLogo.UseVisualStyleBackColor = true;
      this.buttonreplicateLeagueTinyLogo.Click += new EventHandler(this.buttonreplicateLeagueTinyLogo_Click);
      this.viewer2DLeagueTinyLogo.AutoTransparency = true;
      this.viewer2DLeagueTinyLogo.BackColor = Color.Transparent;
      this.viewer2DLeagueTinyLogo.ButtonStripVisible = true;
      this.viewer2DLeagueTinyLogo.CurrentBitmap = (Bitmap) null;
      this.viewer2DLeagueTinyLogo.ExtendedFormat = false;
      this.viewer2DLeagueTinyLogo.FullSizeButton = false;
      this.viewer2DLeagueTinyLogo.ImageLayout = ImageLayout.None;
      this.viewer2DLeagueTinyLogo.ImageSize = new Size(256, 64);
      this.viewer2DLeagueTinyLogo.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DLeagueTinyLogo.Location = new Point(268, 19);
      this.viewer2DLeagueTinyLogo.Name = "viewer2DLeagueTinyLogo";
      this.viewer2DLeagueTinyLogo.RemoveButton = true;
      this.viewer2DLeagueTinyLogo.ShowButton = false;
      this.viewer2DLeagueTinyLogo.ShowButtonChecked = true;
      this.viewer2DLeagueTinyLogo.Size = new Size(256, 89);
      this.viewer2DLeagueTinyLogo.TabIndex = 2;
      this.viewer2DLeagueSmallLogo.AutoTransparency = true;
      this.viewer2DLeagueSmallLogo.BackColor = Color.Transparent;
      this.viewer2DLeagueSmallLogo.ButtonStripVisible = true;
      this.viewer2DLeagueSmallLogo.CurrentBitmap = (Bitmap) null;
      this.viewer2DLeagueSmallLogo.ExtendedFormat = false;
      this.viewer2DLeagueSmallLogo.FullSizeButton = false;
      this.viewer2DLeagueSmallLogo.ImageLayout = ImageLayout.None;
      this.viewer2DLeagueSmallLogo.ImageSize = new Size(256, 256);
      this.viewer2DLeagueSmallLogo.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DLeagueSmallLogo.Location = new Point(268, 114);
      this.viewer2DLeagueSmallLogo.Name = "viewer2DLeagueSmallLogo";
      this.viewer2DLeagueSmallLogo.RemoveButton = true;
      this.viewer2DLeagueSmallLogo.ShowButton = false;
      this.viewer2DLeagueSmallLogo.ShowButtonChecked = true;
      this.viewer2DLeagueSmallLogo.Size = new Size(201, 177);
      this.viewer2DLeagueSmallLogo.TabIndex = 157;
      this.viewer2DLeagueAnimLogo.AutoTransparency = true;
      this.viewer2DLeagueAnimLogo.BackColor = Color.Transparent;
      this.viewer2DLeagueAnimLogo.ButtonStripVisible = true;
      this.viewer2DLeagueAnimLogo.CurrentBitmap = (Bitmap) null;
      this.viewer2DLeagueAnimLogo.ExtendedFormat = false;
      this.viewer2DLeagueAnimLogo.FullSizeButton = false;
      this.viewer2DLeagueAnimLogo.ImageLayout = ImageLayout.None;
      this.viewer2DLeagueAnimLogo.ImageSize = new Size(256, 256);
      this.viewer2DLeagueAnimLogo.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DLeagueAnimLogo.Location = new Point(6, 19);
      this.viewer2DLeagueAnimLogo.Name = "viewer2DLeagueAnimLogo";
      this.viewer2DLeagueAnimLogo.RemoveButton = true;
      this.viewer2DLeagueAnimLogo.ShowButton = false;
      this.viewer2DLeagueAnimLogo.ShowButtonChecked = true;
      this.viewer2DLeagueAnimLogo.Size = new Size(256, 281);
      this.viewer2DLeagueAnimLogo.TabIndex = 156;
      this.groupBoxNames.Controls.Add((Control) this.checkReplayLogo);
      this.groupBoxNames.Controls.Add((Control) this.textLeagueFullName);
      this.groupBoxNames.Controls.Add((Control) this.labelLeagueFullName);
      this.groupBoxNames.Controls.Add((Control) this.labelLeagueId);
      this.groupBoxNames.Controls.Add((Control) this.buttonGetId);
      this.groupBoxNames.Controls.Add((Control) this.groupBox1);
      this.groupBoxNames.Controls.Add((Control) this.textLeagueShortName);
      this.groupBoxNames.Controls.Add((Control) this.labelLeagueShortName);
      this.groupBoxNames.Controls.Add((Control) this.textDatabaseLeagueName);
      this.groupBoxNames.Controls.Add((Control) this.comboLeagueCountry);
      this.groupBoxNames.Controls.Add((Control) this.labelDatabaseLeagueName);
      this.groupBoxNames.Controls.Add((Control) this.numericLeagueId);
      this.groupBoxNames.Controls.Add((Control) this.numericLeagueLevel);
      this.groupBoxNames.Controls.Add((Control) this.labelCountry);
      this.groupBoxNames.Controls.Add((Control) this.labelLeagueLevel);
      this.groupBoxNames.Location = new Point(3, 463);
      this.groupBoxNames.Name = "groupBoxNames";
      this.groupBoxNames.Size = new Size(531, 173);
      this.groupBoxNames.TabIndex = 1;
      this.groupBoxNames.TabStop = false;
      this.groupBoxNames.Text = "Names and Other Information";
      this.checkReplayLogo.AutoSize = true;
      this.checkReplayLogo.Location = new Point(171, 188);
      this.checkReplayLogo.Name = "checkReplayLogo";
      this.checkReplayLogo.Size = new Size(165, 17);
      this.checkReplayLogo.TabIndex = 159;
      this.checkReplayLogo.Text = "Use EA Sport default 3D logo";
      this.checkReplayLogo.UseVisualStyleBackColor = true;
      this.checkReplayLogo.Visible = false;
      this.checkReplayLogo.CheckedChanged += new EventHandler(this.checkReplayLogo_CheckedChanged);
      this.textLeagueFullName.DataBindings.Add(new Binding("Text", (object) this.leagueBindingSource, "LongName", true));
      this.textLeagueFullName.Location = new Point(91, 60);
      this.textLeagueFullName.Name = "textLeagueFullName";
      this.textLeagueFullName.Size = new Size(192, 20);
      this.textLeagueFullName.TabIndex = 116;
      this.leagueBindingSource.DataSource = (object) typeof (League);
      this.labelLeagueFullName.ImeMode = ImeMode.NoControl;
      this.labelLeagueFullName.Location = new Point(6, 60);
      this.labelLeagueFullName.Name = "labelLeagueFullName";
      this.labelLeagueFullName.Size = new Size(79, 20);
      this.labelLeagueFullName.TabIndex = 120;
      this.labelLeagueFullName.Text = "Long Name";
      this.labelLeagueFullName.TextAlign = ContentAlignment.MiddleLeft;
      this.labelLeagueId.AutoSize = true;
      this.labelLeagueId.BackColor = Color.Transparent;
      this.labelLeagueId.ImeMode = ImeMode.NoControl;
      this.labelLeagueId.Location = new Point(6, 90);
      this.labelLeagueId.Name = "labelLeagueId";
      this.labelLeagueId.Size = new Size(55, 13);
      this.labelLeagueId.TabIndex = 152;
      this.labelLeagueId.Text = "League Id";
      this.labelLeagueId.TextAlign = ContentAlignment.MiddleLeft;
      this.buttonGetId.BackgroundImage = (Image) resources.GetObject("buttonGetId.BackgroundImage");
      this.buttonGetId.BackgroundImageLayout = ImageLayout.None;
      this.buttonGetId.Location = new Point(229, 90);
      this.buttonGetId.Name = "buttonGetId";
      this.buttonGetId.Size = new Size(25, 23);
      this.buttonGetId.TabIndex = 153;
      this.buttonGetId.UseVisualStyleBackColor = true;
      this.buttonGetId.Click += new EventHandler(this.buttonGetId_Click);
      this.groupBox1.Controls.Add((Control) this.numericBoardOutcome5);
      this.groupBox1.Controls.Add((Control) this.label4);
      this.groupBox1.Controls.Add((Control) this.numericBoardOutcome4);
      this.groupBox1.Controls.Add((Control) this.label5);
      this.groupBox1.Controls.Add((Control) this.numericBoardOutcome3);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.numericBoardOutcome2);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.numericBoardOutcome1);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Location = new Point(292, 19);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(239, 139);
      this.groupBox1.TabIndex = 160;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Position necessary to achieve objectives";
      this.numericBoardOutcome5.Location = new Point(164, 110);
      this.numericBoardOutcome5.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericBoardOutcome5.Name = "numericBoardOutcome5";
      this.numericBoardOutcome5.Size = new Size(60, 20);
      this.numericBoardOutcome5.TabIndex = 9;
      this.numericBoardOutcome5.TextAlign = HorizontalAlignment.Center;
      this.numericBoardOutcome5.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericBoardOutcome5.ValueChanged += new EventHandler(this.numericBoardOutcome5_ValueChanged);
      this.label4.AutoSize = true;
      this.label4.Location = new Point(6, 112);
      this.label4.Name = "label4";
      this.label4.Size = new Size(154, 13);
      this.label4.TabIndex = 8;
      this.label4.Text = "Avoid Relegation or Low Class.";
      this.label4.TextAlign = ContentAlignment.MiddleLeft;
      this.numericBoardOutcome4.Location = new Point(164, 88);
      this.numericBoardOutcome4.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericBoardOutcome4.Name = "numericBoardOutcome4";
      this.numericBoardOutcome4.Size = new Size(60, 20);
      this.numericBoardOutcome4.TabIndex = 7;
      this.numericBoardOutcome4.TextAlign = HorizontalAlignment.Center;
      this.numericBoardOutcome4.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericBoardOutcome4.ValueChanged += new EventHandler(this.numericBoardOutcome4_ValueChanged);
      this.label5.AutoSize = true;
      this.label5.Location = new Point(6, 90);
      this.label5.Name = "label5";
      this.label5.Size = new Size(108, 13);
      this.label5.TabIndex = 6;
      this.label5.Text = "Medium Classification";
      this.label5.TextAlign = ContentAlignment.MiddleLeft;
      this.numericBoardOutcome3.Location = new Point(164, 66);
      this.numericBoardOutcome3.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericBoardOutcome3.Name = "numericBoardOutcome3";
      this.numericBoardOutcome3.Size = new Size(60, 20);
      this.numericBoardOutcome3.TabIndex = 5;
      this.numericBoardOutcome3.TextAlign = HorizontalAlignment.Center;
      this.numericBoardOutcome3.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericBoardOutcome3.ValueChanged += new EventHandler(this.numericBoardOutcome3_ValueChanged);
      this.label3.AutoSize = true;
      this.label3.Location = new Point(6, 68);
      this.label3.Name = "label3";
      this.label3.Size = new Size(148, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Europa League or High Class.";
      this.label3.TextAlign = ContentAlignment.MiddleLeft;
      this.numericBoardOutcome2.Location = new Point(164, 44);
      this.numericBoardOutcome2.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericBoardOutcome2.Name = "numericBoardOutcome2";
      this.numericBoardOutcome2.Size = new Size(60, 20);
      this.numericBoardOutcome2.TabIndex = 3;
      this.numericBoardOutcome2.TextAlign = HorizontalAlignment.Center;
      this.numericBoardOutcome2.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericBoardOutcome2.ValueChanged += new EventHandler(this.numericBoardOutcome2_ValueChanged);
      this.label2.AutoSize = true;
      this.label2.Location = new Point(6, 46);
      this.label2.Name = "label2";
      this.label2.Size = new Size(145, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Champions League or Playoff";
      this.label2.TextAlign = ContentAlignment.MiddleLeft;
      this.numericBoardOutcome1.Location = new Point(164, 22);
      this.numericBoardOutcome1.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericBoardOutcome1.Name = "numericBoardOutcome1";
      this.numericBoardOutcome1.Size = new Size(60, 20);
      this.numericBoardOutcome1.TabIndex = 1;
      this.numericBoardOutcome1.TextAlign = HorizontalAlignment.Center;
      this.numericBoardOutcome1.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericBoardOutcome1.ValueChanged += new EventHandler(this.numericBoardOutcome1_ValueChanged);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(6, 24);
      this.label1.Name = "label1";
      this.label1.Size = new Size(119, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Win or Direct Promotion";
      this.label1.TextAlign = ContentAlignment.MiddleLeft;
      this.textLeagueShortName.DataBindings.Add(new Binding("Text", (object) this.leagueBindingSource, "ShortName", true));
      this.textLeagueShortName.Location = new Point(91, 37);
      this.textLeagueShortName.Name = "textLeagueShortName";
      this.textLeagueShortName.Size = new Size(192, 20);
      this.textLeagueShortName.TabIndex = 1;
      this.textLeagueShortName.TextChanged += new EventHandler(this.textLeagueShortName_TextChanged);
      this.labelLeagueShortName.ImeMode = ImeMode.NoControl;
      this.labelLeagueShortName.Location = new Point(6, 37);
      this.labelLeagueShortName.Name = "labelLeagueShortName";
      this.labelLeagueShortName.Size = new Size(79, 20);
      this.labelLeagueShortName.TabIndex = 119;
      this.labelLeagueShortName.Text = "Name";
      this.labelLeagueShortName.TextAlign = ContentAlignment.MiddleLeft;
      this.textDatabaseLeagueName.DataBindings.Add(new Binding("Text", (object) this.leagueBindingSource, "leaguename", true));
      this.textDatabaseLeagueName.Location = new Point(91, 15);
      this.textDatabaseLeagueName.Name = "textDatabaseLeagueName";
      this.textDatabaseLeagueName.Size = new Size(192, 20);
      this.textDatabaseLeagueName.TabIndex = 0;
      this.comboLeagueCountry.Location = new Point(90, 142);
      this.comboLeagueCountry.Name = "comboLeagueCountry";
      this.comboLeagueCountry.Size = new Size(193, 21);
      this.comboLeagueCountry.TabIndex = 3;
      this.comboLeagueCountry.SelectedIndexChanged += new EventHandler(this.comboLeagueCountry_SelectedIndexChanged);
      this.labelDatabaseLeagueName.ImeMode = ImeMode.NoControl;
      this.labelDatabaseLeagueName.Location = new Point(6, 15);
      this.labelDatabaseLeagueName.Name = "labelDatabaseLeagueName";
      this.labelDatabaseLeagueName.Size = new Size(97, 20);
      this.labelDatabaseLeagueName.TabIndex = 54;
      this.labelDatabaseLeagueName.Text = "Database Name";
      this.labelDatabaseLeagueName.TextAlign = ContentAlignment.MiddleLeft;
      this.numericLeagueId.Location = new Point(91, 90);
      this.numericLeagueId.Maximum = new Decimal(new int[4]
      {
        200000,
        0,
        0,
        0
      });
      this.numericLeagueId.Name = "numericLeagueId";
      this.numericLeagueId.Size = new Size(132, 20);
      this.numericLeagueId.TabIndex = 0;
      this.numericLeagueId.TextAlign = HorizontalAlignment.Center;
      this.numericLeagueId.ValueChanged += new EventHandler(this.numericLeagueId_ValueChanged);
      this.numericLeagueLevel.DataBindings.Add(new Binding("Value", (object) this.leagueBindingSource, "level", true));
      this.numericLeagueLevel.Location = new Point(91, 116);
      this.numericLeagueLevel.Maximum = new Decimal(new int[4]
      {
        7,
        0,
        0,
        0
      });
      this.numericLeagueLevel.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericLeagueLevel.Name = "numericLeagueLevel";
      this.numericLeagueLevel.Size = new Size(66, 20);
      this.numericLeagueLevel.TabIndex = 1;
      this.numericLeagueLevel.TextAlign = HorizontalAlignment.Center;
      this.numericLeagueLevel.ThousandsSeparator = true;
      this.numericLeagueLevel.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.labelCountry.AutoSize = true;
      this.labelCountry.Cursor = Cursors.Hand;
      this.labelCountry.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Underline, GraphicsUnit.Point, (byte) 0);
      this.labelCountry.ForeColor = SystemColors.ActiveCaption;
      this.labelCountry.ImeMode = ImeMode.NoControl;
      this.labelCountry.Location = new Point(6, 145);
      this.labelCountry.Name = "labelCountry";
      this.labelCountry.Size = new Size(43, 13);
      this.labelCountry.TabIndex = 123;
      this.labelCountry.Text = "Country";
      this.labelCountry.TextAlign = ContentAlignment.MiddleLeft;
      this.labelCountry.DoubleClick += new EventHandler(this.labelCountry_DoubleClick);
      this.labelLeagueLevel.AutoSize = true;
      this.labelLeagueLevel.BackColor = SystemColors.Control;
      this.labelLeagueLevel.ImeMode = ImeMode.NoControl;
      this.labelLeagueLevel.Location = new Point(6, 118);
      this.labelLeagueLevel.Name = "labelLeagueLevel";
      this.labelLeagueLevel.Size = new Size(33, 13);
      this.labelLeagueLevel.TabIndex = 108;
      this.labelLeagueLevel.Text = "Level";
      this.labelLeagueLevel.TextAlign = ContentAlignment.MiddleLeft;
      this.groupSwitchLeagues.Controls.Add((Control) this.labelThisLeague);
      this.groupSwitchLeagues.Controls.Add((Control) this.buttonSwitchLeagueIds);
      this.groupSwitchLeagues.Controls.Add((Control) this.comboSwitchLeagues);
      this.groupSwitchLeagues.Location = new Point(540, 463);
      this.groupSwitchLeagues.Name = "groupSwitchLeagues";
      this.groupSwitchLeagues.Size = new Size(237, 139);
      this.groupSwitchLeagues.TabIndex = 158;
      this.groupSwitchLeagues.TabStop = false;
      this.groupSwitchLeagues.Text = "Switch League Ids";
      this.groupSwitchLeagues.Visible = false;
      this.labelThisLeague.BorderStyle = BorderStyle.FixedSingle;
      this.labelThisLeague.Enabled = false;
      this.labelThisLeague.Location = new Point(24, 22);
      this.labelThisLeague.Name = "labelThisLeague";
      this.labelThisLeague.Size = new Size(202, 21);
      this.labelThisLeague.TabIndex = 159;
      this.labelThisLeague.Text = "League name";
      this.labelThisLeague.TextAlign = ContentAlignment.MiddleCenter;
      this.buttonSwitchLeagueIds.Cursor = Cursors.Hand;
      this.buttonSwitchLeagueIds.Enabled = false;
      this.buttonSwitchLeagueIds.Image = (Image) resources.GetObject("buttonSwitchLeagueIds.Image");
      this.buttonSwitchLeagueIds.Location = new Point(87, 48);
      this.buttonSwitchLeagueIds.Name = "buttonSwitchLeagueIds";
      this.buttonSwitchLeagueIds.Size = new Size(71, 54);
      this.buttonSwitchLeagueIds.TabIndex = 158;
      this.buttonSwitchLeagueIds.UseVisualStyleBackColor = true;
      this.buttonSwitchLeagueIds.Click += new EventHandler(this.buttonSwitchLeagueIds_Click);
      this.comboSwitchLeagues.FormattingEnabled = true;
      this.comboSwitchLeagues.Location = new Point(24, 108);
      this.comboSwitchLeagues.Name = "comboSwitchLeagues";
      this.comboSwitchLeagues.Size = new Size(202, 21);
      this.comboSwitchLeagues.TabIndex = 157;
      this.comboSwitchLeagues.SelectedIndexChanged += new EventHandler(this.comboSwitchLeagues_SelectedIndexChanged);
      this.groupLeaguePlayerTuning.Controls.Add((Control) this.buttonLeaguePlayerMinus);
      this.groupLeaguePlayerTuning.Controls.Add((Control) this.buttonLeaguePlayerPlus);
      this.groupLeaguePlayerTuning.Location = new Point(783, 463);
      this.groupLeaguePlayerTuning.Name = "groupLeaguePlayerTuning";
      this.groupLeaguePlayerTuning.Size = new Size(167, 139);
      this.groupLeaguePlayerTuning.TabIndex = 159;
      this.groupLeaguePlayerTuning.TabStop = false;
      this.groupLeaguePlayerTuning.Text = "Player Overall Tuning";
      this.buttonLeaguePlayerMinus.Cursor = Cursors.Hand;
      this.buttonLeaguePlayerMinus.Image = (Image) resources.GetObject("buttonLeaguePlayerMinus.Image");
      this.buttonLeaguePlayerMinus.Location = new Point(90, 43);
      this.buttonLeaguePlayerMinus.Name = "buttonLeaguePlayerMinus";
      this.buttonLeaguePlayerMinus.Size = new Size(64, 64);
      this.buttonLeaguePlayerMinus.TabIndex = 1;
      this.buttonLeaguePlayerMinus.UseVisualStyleBackColor = false;
      this.buttonLeaguePlayerMinus.Click += new EventHandler(this.buttonLeaguePlayerMinus_Click);
      this.buttonLeaguePlayerPlus.Cursor = Cursors.Hand;
      this.buttonLeaguePlayerPlus.Image = (Image) resources.GetObject("buttonLeaguePlayerPlus.Image");
      this.buttonLeaguePlayerPlus.Location = new Point(11, 43);
      this.buttonLeaguePlayerPlus.Name = "buttonLeaguePlayerPlus";
      this.buttonLeaguePlayerPlus.Size = new Size(64, 64);
      this.buttonLeaguePlayerPlus.TabIndex = 0;
      this.buttonLeaguePlayerPlus.UseVisualStyleBackColor = false;
      this.buttonLeaguePlayerPlus.Click += new EventHandler(this.buttonLeaguePlayerPlus_Click);
      this.pickUpControl.BackColor = SystemColors.Control;
      this.pickUpControl.CloneButtonEnabled = false;
      this.pickUpControl.CreateButtonEnabled = true;
      this.pickUpControl.CurrentIndex = 0;
      this.pickUpControl.Dock = DockStyle.Top;
      this.pickUpControl.FilterByList = new string[2]
      {
        "All",
        "by Country"
      };
      this.pickUpControl.FilterEnabled = true;
      this.pickUpControl.FilterValues = (IdArrayList[]) null;
      this.pickUpControl.Location = new Point(0, 0);
      this.pickUpControl.MainSelectionEnabled = true;
      this.pickUpControl.Name = "pickUpControl";
      this.pickUpControl.ObjectList = (IdArrayList) null;
      this.pickUpControl.RefreshButtonEnabled = true;
      this.pickUpControl.RemoveButtonEnabled = true;
      this.pickUpControl.SearchEnabled = true;
      this.pickUpControl.Size = new Size(1165, 25);
      this.pickUpControl.TabIndex = 1;
      this.pickUpControl.WizardButtonEnabled = false;
      this.pickUpControl.YoungPlayersEnabled = false;
      this.countryListBindingSource.DataSource = (object) typeof (CountryList);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1165, 780);
      this.Controls.Add((Control) this.flowPanel);
      this.Controls.Add((Control) this.pickUpControl);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = "LeagueForm";
      this.Text = "LeagueForm";
      this.Load += new EventHandler(this.LeagueForm_Load);
      this.flowPanel.ResumeLayout(false);
      this.groupBoxTeams.ResumeLayout(false);
      this.groupBoxTeams.PerformLayout();
      this.toolStripTeamAvailable.ResumeLayout(false);
      this.toolStripTeamAvailable.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBoxNames.ResumeLayout(false);
      this.groupBoxNames.PerformLayout();
      ((ISupportInitialize) this.leagueBindingSource).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.numericBoardOutcome5.EndInit();
      this.numericBoardOutcome4.EndInit();
      this.numericBoardOutcome3.EndInit();
      this.numericBoardOutcome2.EndInit();
      this.numericBoardOutcome1.EndInit();
      this.numericLeagueId.EndInit();
      this.numericLeagueLevel.EndInit();
      this.groupSwitchLeagues.ResumeLayout(false);
      this.groupLeaguePlayerTuning.ResumeLayout(false);
      ((ISupportInitialize) this.countryListBindingSource).EndInit();
      this.ResumeLayout(false);
    }

    public LeagueForm()
    {
      this.Visible = false;
      this.InitializeComponent();
      this.pickUpControl.SelectObject = new PickUpControl.PickUpCallback(this.SelectLeague);
      this.pickUpControl.CreateObject = new PickUpControl.PickUpCallback(this.CreateLeague);
      this.pickUpControl.DeleteObject = new PickUpControl.PickUpCallback(this.DeleteLeague);
      this.pickUpControl.RefreshObject = new PickUpControl.PickUpCallback(this.RefreshLeague);
      this.viewer2DLeagueTinyLogo.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageLeagueTinyLogo);
      this.viewer2DLeagueTinyLogo.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteLeagueTinyLogo);
      this.viewer2DLeagueTinyLogo.ButtonStripVisible = true;
      this.viewer2DLeagueTinyLogo.RemoveButton = true;
      this.viewer2DLeagueAnimLogo.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageLeagueAnimLogo);
      this.viewer2DLeagueAnimLogo.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteLeagueAnimLogo);
      this.viewer2DLeagueAnimLogo.ButtonStripVisible = true;
      this.viewer2DLeagueAnimLogo.RemoveButton = true;
      this.viewer2DLeagueSmallLogo.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageLeagueSmallLogo);
      this.viewer2DLeagueSmallLogo.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteLeagueSmallLogo);
      this.viewer2DLeagueSmallLogo.ButtonStripVisible = true;
      this.viewer2DLeagueSmallLogo.RemoveButton = true;
      this.viewer2DLeague512x128Logo.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageLeagueLogo512x128);
      this.viewer2DLeague512x128Logo.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteLeagueLogo512x128);
      this.viewer2DLeague512x128Logo.ButtonStripVisible = true;
      this.viewer2DLeague512x128Logo.RemoveButton = true;
    }

    public void Clean()
    {
      this.Visible = false;
    }

    public void Preset()
    {
      this.m_NewIdCreator.IdList = (IdArrayList) FifaEnvironment.Leagues;
      this.buttonreplicateLeagueSmallLogo.Visible = this.viewer2DLeagueSmallLogo.Visible = FifaEnvironment.Year == 14;
      this.buttonreplicateLeagueLogo512x128.Visible = this.viewer2DLeague512x128Logo.Visible = FifaEnvironment.Year > 14;
      this.pickUpControl.FilterValues = new IdArrayList[2]
      {
        (IdArrayList) null,
        (IdArrayList) FifaEnvironment.Countries
      };
      this.numericLeagueId.Maximum = (Decimal) FifaEnvironment.Leagues.MaxId;
      this.RefreshComboBoxes();
      this.pickUpControl.ObjectList = (IdArrayList) FifaEnvironment.Leagues;
    }

    public void RefreshComboBoxes()
    {
      if (this.comboTeamAvailable.Items.Count != FifaEnvironment.Teams.Count)
      {
        this.comboTeamAvailable.Items.Clear();
        this.comboTeamAvailable.Items.AddRange(FifaEnvironment.Teams.ToArray());
      }
      if (this.comboLeagueCountry.Items.Count != FifaEnvironment.Countries.Count + 1)
      {
        this.comboLeagueCountry.Items.Clear();
        this.comboLeagueCountry.Items.Add((object) "None");
        this.comboLeagueCountry.Items.AddRange(FifaEnvironment.Countries.ToArray());
      }
      if (this.comboSwitchLeagues.Items.Count == FifaEnvironment.Leagues.Count + 1)
        return;
      this.comboSwitchLeagues.Items.Clear();
      this.comboSwitchLeagues.Items.AddRange(FifaEnvironment.Leagues.ToArray());
    }

    private League SelectLeague(object sender, object obj)
    {
      League league = (League) obj;
      this.Refresh();
      this.LoadLeague(league);
      return league;
    }

    private League CreateLeague(object sender, object obj)
    {
      DialogResult dialogResult = this.m_NewIdCreator.ShowDialog();
      if (this.m_NewIdCreator.NewObject == null)
      {
        if (dialogResult == DialogResult.OK)
        {
          int num = (int) FifaEnvironment.UserMessages.ShowMessage(5060, this.m_NewIdCreator.NewId);
        }
        return (League) null;
      }
      League newObject = (League) this.m_NewIdCreator.NewObject;
      if (this.m_NewIdCreator.NewName != null && newObject != null)
      {
        newObject.leaguename = this.m_NewIdCreator.NewName;
        newObject.ShortName = newObject.leaguename;
      }
      return newObject;
    }

    private League DeleteLeague(object sender, object obj)
    {
      FifaEnvironment.Leagues.DeleteLeague((League) obj);
      this.m_CurrentLeague = (League) null;
      return (League) null;
    }

    public League RefreshLeague(object sender, object obj)
    {
      this.Preset();
      this.ReloadLeague(this.m_CurrentLeague);
      return this.m_CurrentLeague;
    }

    private bool ImportImageLeagueLogo512x128(object sender, Bitmap bitmap)
    {
      this.m_CurrentLeague.SetLogo512x128Dark(bitmap);
      return this.m_CurrentLeague.SetLogo512x128(bitmap);
    }

    private bool DeleteLeagueLogo512x128(object sender)
    {
      this.m_CurrentLeague.DeleteLogo512x128Dark();
      return this.m_CurrentLeague.DeleteLogo512x128();
    }

    private bool ImportImageLeagueTinyLogo(object sender, Bitmap bitmap)
    {
      this.m_CurrentLeague.SetTinyLogoDark(bitmap);
      return this.m_CurrentLeague.SetTinyLogo(bitmap);
    }

    private bool DeleteLeagueTinyLogo(object sender)
    {
      this.m_CurrentLeague.DeleteTinyLogoDark();
      return this.m_CurrentLeague.DeleteTinyLogo();
    }

    private bool ImportImageLeagueAnimLogo(object sender, Bitmap bitmap)
    {
      this.m_CurrentLeague.SetAnimLogoDark(bitmap);
      return this.m_CurrentLeague.SetAnimLogo(bitmap);
    }

    private bool DeleteLeagueAnimLogo(object sender)
    {
      return this.m_CurrentLeague.DeleteAnimLogo();
    }

    private bool ImportImageLeagueSmallLogo(object sender, Bitmap bitmap)
    {
      this.m_CurrentLeague.SetSmallLogoDark(bitmap);
      return this.m_CurrentLeague.SetSmallLogo(bitmap);
    }

    private bool DeleteLeagueSmallLogo(object sender)
    {
      return this.m_CurrentLeague.DeleteSmallLogo();
    }

    public void ReloadLeague(League league)
    {
      this.m_CurrentLeague = (League) null;
      this.LoadLeague(league);
    }

    public void LoadLeague(League league)
    {
      if (!this.m_IsLoaded || this.m_CurrentLeague == league)
        return;
      this.m_Locked = true;
      this.m_CurrentLeague = league;
      this.leagueBindingSource.DataSource = (object) this.m_CurrentLeague;
      this.comboTeamAvailable.Text = "";
      this.numericLeagueId.Value = (Decimal) this.m_CurrentLeague.Id;
      if (this.m_CurrentLeague.Country == null)
        this.comboLeagueCountry.SelectedIndex = 0;
      else
        this.comboLeagueCountry.SelectedItem = (object) this.m_CurrentLeague.Country;
      this.InitListViewPlayingTeams(league.PlayingTeams);
      this.viewer2DLeagueTinyLogo.CurrentBitmap = league.GetTinyLogo();
      this.viewer2DLeagueAnimLogo.CurrentBitmap = league.GetAnimLogo();
      this.viewer2DLeagueSmallLogo.CurrentBitmap = league.GetSmallLogo();
      this.viewer2DLeague512x128Logo.CurrentBitmap = league.GetLogo512x128();
      this.labelThisLeague.Text = league.ShortName;
      this.buttonSwitchLeagueIds.Enabled = this.comboSwitchLeagues.SelectedItem != null;
      this.checkReplayLogo.Checked = this.m_CurrentLeague.IsReplayLogoPatched();
      this.numericBoardOutcome1.Value = (Decimal) this.m_CurrentLeague.boardoutcomes[0];
      this.numericBoardOutcome2.Value = (Decimal) this.m_CurrentLeague.boardoutcomes[1];
      this.numericBoardOutcome3.Value = (Decimal) this.m_CurrentLeague.boardoutcomes[2];
      this.numericBoardOutcome4.Value = (Decimal) this.m_CurrentLeague.boardoutcomes[3];
      this.numericBoardOutcome5.Value = (Decimal) this.m_CurrentLeague.boardoutcomes[4];
      this.m_Locked = false;
    }

    private void InitListViewPlayingTeams(TeamList playingTeams)
    {
      this.listViewPlayingTeams.BeginUpdate();
      this.listViewPlayingTeams.Items.Clear();
      this.imageListTeamLogos.Images.Clear();
      for (int index = 0; index < playingTeams.Count; ++index)
      {
        Team playingTeam = (Team) playingTeams[index];
        Bitmap bitmap = (Bitmap) null;
        if (this.checkShowTeamLogo.Checked)
          bitmap = playingTeam.GetCrest32();
        if (bitmap != null)
          this.imageListTeamLogos.Images.Add(playingTeam.ToString(), (Image) bitmap);
        this.listViewPlayingTeams.Items.Add(new ListViewItem(playingTeam.ToString())
        {
          Tag = (object) playingTeam
        });
        this.listViewPlayingTeams.Items[index].ImageKey = playingTeam.ToString();
      }
      if (this.listViewPlayingTeams.Items.Count > 0)
        this.listViewPlayingTeams.Items[0].Selected = true;
      this.listViewPlayingTeams.EndUpdate();
    }

    private void textLeagueShortName_TextChanged(object sender, EventArgs e)
    {
      if (this.m_Locked)
        return;
      this.m_CurrentLeague.ShortName = this.textLeagueShortName.Text;
      this.pickUpControl.SwitchObject((IdObject) this.m_CurrentLeague);
    }

    private void textLeagueFullName_TextChanged(object sender, EventArgs e)
    {
      if (this.m_Locked)
        return;
      this.m_CurrentLeague.LongName = this.textLeagueFullName.Text;
    }

    private void numericLeagueId_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_Locked)
        return;
      int num1 = (int) this.numericLeagueId.Value;
      if (num1 == this.m_CurrentLeague.Id)
        return;
      if (FifaEnvironment.Leagues.SearchId(num1) == null)
      {
        FifaEnvironment.Leagues.ChangeId((IdObject) this.m_CurrentLeague, num1);
        this.viewer2DLeagueSmallLogo.CurrentBitmap = this.m_CurrentLeague.GetSmallLogo();
        this.viewer2DLeagueTinyLogo.CurrentBitmap = this.m_CurrentLeague.GetTinyLogo();
        this.viewer2DLeagueAnimLogo.CurrentBitmap = this.m_CurrentLeague.GetAnimLogo();
      }
      else
      {
        int num2 = (int) FifaEnvironment.UserMessages.ShowMessage(1015);
        this.numericLeagueId.Value = (Decimal) this.m_CurrentLeague.Id;
      }
    }

    private void buttonGetId_Click(object sender, EventArgs e)
    {
      int newId = FifaEnvironment.Leagues.GetNewId();
      if (newId == -1)
      {
        int num = (int) FifaEnvironment.UserMessages.ShowMessage(5050);
      }
      else
        this.numericLeagueId.Value = (Decimal) newId;
    }

    private void checkShowTeamLogo_CheckedChanged(object sender, EventArgs e)
    {
      this.InitListViewPlayingTeams(this.m_CurrentLeague.PlayingTeams);
    }

    private int GetTeamIndex(Team team)
    {
      for (int index = 0; index < this.listViewPlayingTeams.Items.Count; ++index)
      {
        if (this.listViewPlayingTeams.Items[index].Tag == team)
          return index;
      }
      return -1;
    }

    private bool AddTeam()
    {
      if (this.comboTeamAvailable.SelectedItem == null)
      {
        int num = (int) FifaEnvironment.UserMessages.ShowMessage(1000);
        return false;
      }
      Team selectedItem = (Team) this.comboTeamAvailable.SelectedItem;
      ListViewItem listViewItem = new ListViewItem(selectedItem.ToString(), selectedItem.ToString());
      listViewItem.Tag = (object) selectedItem;
      if (this.GetTeamIndex(selectedItem) >= 0)
      {
        int num = (int) FifaEnvironment.UserMessages.ShowMessage(1001);
        return false;
      }
      if (this.checkShowTeamLogo.Checked)
      {
        Bitmap crest32 = selectedItem.GetCrest32();
        if (crest32 != null)
          this.imageListTeamLogos.Images.Add(selectedItem.ToString(), (Image) crest32);
        if (crest32 != null)
          this.imageListTeamLogos.Images.Add(selectedItem.ToString(), (Image) crest32);
      }
      this.listViewPlayingTeams.Items.Add(listViewItem);
      this.m_CurrentLeague.AddTeam(selectedItem);
      return true;
    }

    private void buttonAddTeam_Click(object sender, EventArgs e)
    {
      this.AddTeam();
    }

    private bool RemoveTeam()
    {
      if (this.listViewPlayingTeams.SelectedItems.Count <= 0)
      {
        int num = (int) FifaEnvironment.UserMessages.ShowMessage(1002);
        return false;
      }
      Team tag = (Team) this.listViewPlayingTeams.SelectedItems[0].Tag;
      if (tag == null)
        return false;
      int teamIndex = this.GetTeamIndex(tag);
      if (teamIndex < 0)
        return false;
      this.listViewPlayingTeams.Items.RemoveAt(teamIndex);
      this.imageListTeamLogos.Images.RemoveByKey(tag.ToString());
      this.m_CurrentLeague.RemoveTeam(tag);
      return true;
    }

    private void buttonRemoveTeam_Click(object sender, EventArgs e)
    {
      this.RemoveTeam();
    }

    private void buttonReplaceTeam_Click(object sender, EventArgs e)
    {
      if (!this.RemoveTeam())
        return;
      this.AddTeam();
    }

    private void listViewPlayingTeams_DoubleClick(object sender, EventArgs e)
    {
      if (this.listViewPlayingTeams.SelectedItems.Count <= 0)
        return;
      Team tag = (Team) this.listViewPlayingTeams.SelectedItems[0].Tag;
      if (tag == null)
        return;
      MainForm.CM.JumpTo((IdObject) tag);
    }

    private void labelCountry_DoubleClick(object sender, EventArgs e)
    {
      if (this.m_CurrentLeague.Country == null)
        return;
      MainForm.CM.JumpTo((IdObject) this.m_CurrentLeague.Country);
    }

    private void LeagueForm_Load(object sender, EventArgs e)
    {
      this.m_IsLoaded = true;
      this.Preset();
    }

    private void comboLeagueCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboLeagueCountry.SelectedIndex < 0)
        return;
      if (this.comboLeagueCountry.SelectedIndex == 0)
        this.m_CurrentLeague.Country = (Country) null;
      else
        this.m_CurrentLeague.Country = (Country) this.comboLeagueCountry.SelectedItem;
    }

    private void buttonreplicateLeagueTinyLogo_Click(object sender, EventArgs e)
    {
      Bitmap currentBitmap = this.viewer2DLeagueAnimLogo.CurrentBitmap;
      Bitmap bitmap = new Bitmap(256, 64, PixelFormat.Format32bppPArgb);
      Rectangle srcRect = new Rectangle(0, 0, 256, 256);
      Rectangle destRect = new Rectangle(145, 0, 64, 64);
      GraphicUtil.RemapRectangle(currentBitmap, srcRect, bitmap, destRect);
      this.m_CurrentLeague.SetTinyLogo(bitmap);
      this.m_CurrentLeague.SetTinyLogoDark(bitmap);
      this.viewer2DLeagueTinyLogo.CurrentBitmap = bitmap;
    }

    private void buttonreplicateLeagueLogo512x128_Click(object sender, EventArgs e)
    {
      Bitmap currentBitmap = this.viewer2DLeagueAnimLogo.CurrentBitmap;
      Bitmap bitmap = new Bitmap(512, 128, PixelFormat.Format32bppPArgb);
      Rectangle srcRect = new Rectangle(0, 0, 256, 256);
      Rectangle destRect = new Rectangle(192, 0, 128, 128);
      GraphicUtil.RemapRectangle(currentBitmap, srcRect, bitmap, destRect);
      destRect = new Rectangle(32, 0, 128, 128);
      GraphicUtil.RemapRectangle(currentBitmap, srcRect, bitmap, destRect);
      destRect = new Rectangle(352, 0, 128, 128);
      GraphicUtil.RemapRectangle(currentBitmap, srcRect, bitmap, destRect);
      this.m_CurrentLeague.SetLogo512x128(bitmap);
      this.m_CurrentLeague.SetLogo512x128Dark(bitmap);
      this.viewer2DLeague512x128Logo.CurrentBitmap = bitmap;
    }

    private void buttonreplicateLeagueSmallLogo_Click(object sender, EventArgs e)
    {
      Bitmap currentBitmap = this.viewer2DLeagueAnimLogo.CurrentBitmap;
      Bitmap bitmap = new Bitmap(256, 256, PixelFormat.Format32bppPArgb);
      Rectangle srcRect = new Rectangle(0, 0, 256, 256);
      Rectangle destRect = new Rectangle(25, 0, 150, 150);
      GraphicUtil.RemapRectangle(currentBitmap, srcRect, bitmap, destRect);
      this.m_CurrentLeague.SetSmallLogo(bitmap);
      this.m_CurrentLeague.SetSmallLogoDark(bitmap);
      this.viewer2DLeagueSmallLogo.CurrentBitmap = bitmap;
    }

    private void comboSwitchLeagues_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.buttonSwitchLeagueIds.Enabled = this.comboSwitchLeagues.SelectedItem != null;
    }

    private void buttonSwitchLeagueIds_Click(object sender, EventArgs e)
    {
      League selectedItem = (League) this.comboSwitchLeagues.SelectedItem;
      if (selectedItem == null || selectedItem == this.m_CurrentLeague)
        return;
      Bitmap animLogo1 = this.m_CurrentLeague.GetAnimLogo();
      Bitmap smallLogo1 = this.m_CurrentLeague.GetSmallLogo();
      Bitmap tinyLogo1 = this.m_CurrentLeague.GetTinyLogo();
      Bitmap animLogo2 = selectedItem.GetAnimLogo();
      Bitmap smallLogo2 = selectedItem.GetSmallLogo();
      Bitmap tinyLogo2 = selectedItem.GetTinyLogo();
      Trophy trophy1 = FifaEnvironment.CompetitionObjects.SearchTrophy(this.m_CurrentLeague.Id);
      Trophy trophy2 = FifaEnvironment.CompetitionObjects.SearchTrophy(selectedItem.Id);
      Bitmap bitmap1 = (Bitmap) null;
      Bitmap bitmap2 = (Bitmap) null;
      Bitmap[] bitmaps1 = (Bitmap[]) null;
      string rx3FileName1 = (string) null;
      if (trophy1 != null)
      {
        bitmap1 = trophy1.GetTrophy256();
        bitmap2 = trophy1.GetTrophy128();
        bitmaps1 = trophy1.GetTextures();
        rx3FileName1 = trophy1.ExportModelFile();
      }
      Bitmap bitmap3 = (Bitmap) null;
      Bitmap bitmap4 = (Bitmap) null;
      Bitmap[] bitmaps2 = (Bitmap[]) null;
      string rx3FileName2 = (string) null;
      if (trophy2 != null)
      {
        bitmap3 = trophy2.GetTrophy256();
        bitmap4 = trophy2.GetTrophy128();
        bitmaps2 = trophy2.GetTextures();
        rx3FileName2 = trophy2.ExportModelFile();
      }
      int id = this.m_CurrentLeague.Id;
      this.m_CurrentLeague.Id = selectedItem.Id;
      selectedItem.Id = id;
      this.m_CurrentLeague.SetAnimLogo(animLogo1);
      this.m_CurrentLeague.SetAnimLogoDark(animLogo1);
      this.m_CurrentLeague.SetSmallLogo(smallLogo1);
      this.m_CurrentLeague.SetSmallLogoDark(smallLogo1);
      this.m_CurrentLeague.SetTinyLogo(tinyLogo1);
      this.m_CurrentLeague.SetTinyLogoDark(tinyLogo1);
      selectedItem.SetAnimLogo(animLogo2);
      selectedItem.SetAnimLogoDark(animLogo2);
      selectedItem.SetSmallLogo(smallLogo2);
      selectedItem.SetSmallLogoDark(smallLogo2);
      selectedItem.SetTinyLogo(tinyLogo2);
      selectedItem.SetTinyLogoDark(tinyLogo2);
      if (trophy1 != null)
      {
        trophy1.Settings.m_asset_id[0] = selectedItem.Id;
        trophy1.SetTrophy256(bitmap1);
        trophy1.SetTrophy128(bitmap2);
        trophy1.Settings.m_asset_id[0] = this.m_CurrentLeague.Id;
        trophy1.TypeString = "C" + this.m_CurrentLeague.Id.ToString();
        trophy1.Description = FifaEnvironment.Language.GetTournamentConventionalString(this.m_CurrentLeague.Id, Language.ETournamentStringType.Abbr15);
        trophy1.SetTextures(bitmaps1);
        trophy1.SetModel(rx3FileName1);
      }
      if (trophy2 != null)
      {
        trophy2.Settings.m_asset_id[0] = id;
        trophy2.SetTrophy256(bitmap3);
        trophy2.SetTrophy128(bitmap4);
        trophy2.Settings.m_asset_id[0] = selectedItem.Id;
        trophy2.TypeString = "C" + selectedItem.Id.ToString();
        trophy2.Description = FifaEnvironment.Language.GetTournamentConventionalString(selectedItem.Id, Language.ETournamentStringType.Abbr15);
        trophy2.SetTextures(bitmaps2);
        trophy2.SetModel(rx3FileName2);
      }
      this.numericLeagueId.Value = (Decimal) this.m_CurrentLeague.Id;
      MainForm.CM.m_TrophyForm.ReloadCompetitions();
      this.Preset();
    }

    private void buttonLeaguePlayerPlus_Click(object sender, EventArgs e)
    {
      foreach (Team playingTeam in (ArrayList) this.m_CurrentLeague.PlayingTeams)
      {
        foreach (TeamPlayer teamPlayer in (ArrayList) playingTeam.Roster)
          teamPlayer.Player.ChangeSkills(1);
      }
    }

    private void buttonLeaguePlayerMinus_Click(object sender, EventArgs e)
    {
      foreach (Team playingTeam in (ArrayList) this.m_CurrentLeague.PlayingTeams)
      {
        foreach (TeamPlayer teamPlayer in (ArrayList) playingTeam.Roster)
          teamPlayer.Player.ChangeSkills(-1);
      }
    }

    private void checkReplayLogo_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkReplayLogo.Checked == this.m_CurrentLeague.IsReplayLogoPatched())
        return;
      if (this.checkReplayLogo.Checked)
        this.m_CurrentLeague.CreateReplayLogoPatch();
      else
        this.m_CurrentLeague.RemoveReplayLogoPatch();
    }

    private void numericBoardOutcome1_ValueChanged(object sender, EventArgs e)
    {
      this.m_CurrentLeague.boardoutcomes[0] = (int) this.numericBoardOutcome1.Value;
    }

    private void numericBoardOutcome2_ValueChanged(object sender, EventArgs e)
    {
      this.m_CurrentLeague.boardoutcomes[1] = (int) this.numericBoardOutcome2.Value;
    }

    private void numericBoardOutcome3_ValueChanged(object sender, EventArgs e)
    {
      this.m_CurrentLeague.boardoutcomes[2] = (int) this.numericBoardOutcome3.Value;
    }

    private void numericBoardOutcome4_ValueChanged(object sender, EventArgs e)
    {
      this.m_CurrentLeague.boardoutcomes[3] = (int) this.numericBoardOutcome4.Value;
    }

    private void numericBoardOutcome5_ValueChanged(object sender, EventArgs e)
    {
      this.m_CurrentLeague.boardoutcomes[4] = (int) this.numericBoardOutcome5.Value;
    }
  }
}
