// Original code created by Rinaldo

using FifaControls;
using FifaLibrary;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace CreationMaster
{
  public class PatchLoaderForm : Form
  {
    private DataSet m_FifaDataSet = new DataSet("FIFA14");
    private DataSet m_LangDataSet = new DataSet("LANG14");
    private Patch m_PatchDataSet = new Patch();
    private IContainer components;
    private MenuStrip mainMenu;
    private ToolStrip toolMain;
    private ToolStripButton buttonLoadPatch;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton buttonImportPatch;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripButton buttonExitCreator;
    private ToolStripButton buttonSelectAllObjects;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripButton buttonDeselectAllObjects;
    private ToolStripButton stripButtonPreview;
    private ToolStripMenuItem patchToolStripMenuItem;
    private ToolStripMenuItem openToolStripMenuItem;
    private ToolStripMenuItem importToolStripMenuItem;
    private ToolStripMenuItem exitToolStripMenuItem;
    private Panel panelLeft;
    private CheckBox checkCMS;
    private GroupBox groupPatchOptions;
    private TabControl tabPatchOptions;
    private TabPage pagePlayerOptions;
    public CheckBox checkPlayerMiniface;
    public CheckBox checkPlayerHead;
    public CheckBox checkPlayerDatabase;
    private TabPage pageTeamOptions;
    public CheckBox checkTeamFlags;
    public CheckBox checkTeamBanner;
    public CheckBox checkTeamLogo;
    public CheckBox checkTeamDatabase;
    private TabPage pageLeagueOptions;
    public CheckBox checkLeagueLogo;
    public CheckBox checkLeagueDatabase;
    private TabPage pageCountryOptions;
    public CheckBox checkCountryDatabase;
    public CheckBox checkCountryFlag;
    private TabPage pageStadiumOptions;
    public CheckBox checkStadiumModel;
    public CheckBox checkStadiumPreview;
    public CheckBox checkStadiumDatabase;
    private TabPage pageKitOptions;
    public CheckBox checkKitDatabase;
    private TextBox textDescription;
    private Label labelDescription;
    private TextBox textPatchVersion;
    private Label labelPatchVersion;
    private TextBox textPatchName;
    private Label labelPatchName;
    private SplitContainer splitContainer1;
    private StatusStrip statusBar;
    private ToolStripStatusLabel statusLabel;
    private ListView listViewPatch;
    private ColumnHeader columnItem;
    private ColumnHeader columnType;
    private ColumnHeader columnPatchId;
    private ColumnHeader columnComment;
    private Panel panelRight;
    private TabControl tabPreview;
    private TabPage pageViewer2D;
    private Panel panelGraphicGroups;
    private GroupBox groupBall;
    private RadioButton radioBallPreview;
    private RadioButton radioBallTexture;
    private GroupBox groupCountry;
    private RadioButton radioCountryMainFlag;
    private RadioButton radioCountryMiniflag;
    private GroupBox groupPlayer;
    private RadioButton radioFaceTexture;
    private RadioButton radioMiniHead;
    private GroupBox groupLeague;
    private GroupBox groupTeam;
    private RadioButton radioTeamFlags;
    private RadioButton radioTeamBanners;
    private GroupBox groupStadium;
    private RadioButton radioStadiumGuiSunset;
    private RadioButton radioStadiumGuiOvercast;
    private RadioButton radioStadiumGuiClearDay;
    private RadioButton radioStadium3D;
    private RadioButton radioStadiumGuiNight;
    private GroupBox groupAdboards;
    private RadioButton radioAdboard1;
    private PictureBox pictureBox1;
    private GroupBox groupReplaceSelection;
    private ComboBox comboReplaceKit;
    private Label labelCmsCreated;
    private Label labelCmsReplaced;
    private TextBox textCmsReplaced;
    private ComboBox comboReplaceMowingPattern;
    private RadioButton radioCmsItem;
    private ComboBox comboReplaceGkGloves;
    private ComboBox comboReplaceNet;
    private ComboBox comboReplaceShoes;
    private ComboBox comboReplaceNamesFont;
    private ComboBox comboReplaceNumberFont;
    private ComboBox comboReplaceAdboard;
    private ComboBox comboReplaceBall;
    private ComboBox comboReplaceReferee;
    private ComboBox comboReplaceSponsor;
    private ComboBox comboReplaceFormation;
    private ComboBox comboReplaceTournament;
    private ComboBox comboReplaceStadium;
    private ComboBox comboReplaceCountry;
    private ComboBox comboReplaceLeague;
    private ComboBox comboReplacePlayer;
    private ComboBox comboReplaceTeam;
    private RadioButton radioReplaceItem;
    private RadioButton radioCreateItem;
    private Label labelDetails;
    private TabPage pageMultiViewer2D;
    public CheckBox checkMinikits;
    public CheckBox checkKits;
    private Viewer2D viewer2D;
    private MultiViewer2D multiViewer2D;
    private RadioButton radioEyesTexture;
    private RadioButton radioHairTextures;
    private RadioButton radioHairColorTexture;
    private GroupBox groupKit;
    private RadioButton radioKitKit;
    private RadioButton radioKitMinikit;
    private GroupBox groupShoes;
    private RadioButton radioShoesColor;
    private RadioButton radioStadiumPreview;
    private GroupBox groupTod;
    private ColumnHeader columnImportId;
    private ComboBox comboReplaceLicensedTournament;
    private RadioButton radioCountryCard;
    private RadioButton radioLeagueTinyLogo;
    private RadioButton radioLeagueSmallLogo;
    private RadioButton radioLeagueAnimLogo;
    private RadioButton radioTeamCrest16;
    private RadioButton radioTeamCrest32;
    private RadioButton radioTeamCrestLarge;
    private RadioButton radioLeagueLogo512x128;
    private RadioButton radioCountryFlag512x512;
    private RadioButton radioCountryMap;
    public CheckBox checkCountryMap;
    private RadioButton radioTeamCrest50;
    private GroupBox groupDualClub;
    public RadioButton radioPutInBothTeams;
    public RadioButton radioTransferToNewTeam;
    public RadioButton radioLeaveInExistingTeam;
    private ToolStripSeparator toolStripSeparator4;
    private ToolStripButton buttonSelectNewObjects;
    public string m_TempFolder;
    private int m_PatchYear;
    private bool m_IsCmsPatch;
    private int m_PatchDatabaseVersion;
    private bool m_IsLastObjectCrossReferenced;
    private PatchedObject m_CurrentPatchedObject;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager resources = new ComponentResourceManager(typeof (PatchLoaderForm));
      this.mainMenu = new MenuStrip();
      this.patchToolStripMenuItem = new ToolStripMenuItem();
      this.openToolStripMenuItem = new ToolStripMenuItem();
      this.importToolStripMenuItem = new ToolStripMenuItem();
      this.exitToolStripMenuItem = new ToolStripMenuItem();
      this.toolMain = new ToolStrip();
      this.buttonLoadPatch = new ToolStripButton();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.buttonImportPatch = new ToolStripButton();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.buttonExitCreator = new ToolStripButton();
      this.buttonSelectAllObjects = new ToolStripButton();
      this.toolStripSeparator3 = new ToolStripSeparator();
      this.buttonDeselectAllObjects = new ToolStripButton();
      this.toolStripSeparator4 = new ToolStripSeparator();
      this.buttonSelectNewObjects = new ToolStripButton();
      this.stripButtonPreview = new ToolStripButton();
      this.panelLeft = new Panel();
      this.textDescription = new TextBox();
      this.groupPatchOptions = new GroupBox();
      this.tabPatchOptions = new TabControl();
      this.pagePlayerOptions = new TabPage();
      this.groupDualClub = new GroupBox();
      this.radioPutInBothTeams = new RadioButton();
      this.radioTransferToNewTeam = new RadioButton();
      this.radioLeaveInExistingTeam = new RadioButton();
      this.checkPlayerMiniface = new CheckBox();
      this.checkPlayerHead = new CheckBox();
      this.checkPlayerDatabase = new CheckBox();
      this.pageTeamOptions = new TabPage();
      this.checkTeamFlags = new CheckBox();
      this.checkTeamBanner = new CheckBox();
      this.checkTeamLogo = new CheckBox();
      this.checkTeamDatabase = new CheckBox();
      this.pageLeagueOptions = new TabPage();
      this.checkLeagueLogo = new CheckBox();
      this.checkLeagueDatabase = new CheckBox();
      this.pageStadiumOptions = new TabPage();
      this.checkStadiumModel = new CheckBox();
      this.checkStadiumPreview = new CheckBox();
      this.checkStadiumDatabase = new CheckBox();
      this.pageKitOptions = new TabPage();
      this.checkMinikits = new CheckBox();
      this.checkKits = new CheckBox();
      this.checkKitDatabase = new CheckBox();
      this.pageCountryOptions = new TabPage();
      this.checkCountryMap = new CheckBox();
      this.checkCountryDatabase = new CheckBox();
      this.checkCountryFlag = new CheckBox();
      this.textPatchVersion = new TextBox();
      this.textPatchName = new TextBox();
      this.labelDescription = new Label();
      this.checkCMS = new CheckBox();
      this.labelPatchVersion = new Label();
      this.labelPatchName = new Label();
      this.statusBar = new StatusStrip();
      this.statusLabel = new ToolStripStatusLabel();
      this.splitContainer1 = new SplitContainer();
      this.listViewPatch = new ListView();
      this.columnItem = new ColumnHeader();
      this.columnType = new ColumnHeader();
      this.columnPatchId = new ColumnHeader();
      this.columnImportId = new ColumnHeader();
      this.columnComment = new ColumnHeader();
      this.panelRight = new Panel();
      this.tabPreview = new TabControl();
      this.pageViewer2D = new TabPage();
      this.viewer2D = new Viewer2D();
      this.pageMultiViewer2D = new TabPage();
      this.multiViewer2D = new MultiViewer2D();
      this.panelGraphicGroups = new Panel();
      this.groupTeam = new GroupBox();
      this.radioTeamCrest50 = new RadioButton();
      this.radioTeamCrest16 = new RadioButton();
      this.radioTeamCrest32 = new RadioButton();
      this.radioTeamCrestLarge = new RadioButton();
      this.radioTeamFlags = new RadioButton();
      this.radioTeamBanners = new RadioButton();
      this.groupLeague = new GroupBox();
      this.radioLeagueLogo512x128 = new RadioButton();
      this.radioLeagueAnimLogo = new RadioButton();
      this.radioLeagueTinyLogo = new RadioButton();
      this.radioLeagueSmallLogo = new RadioButton();
      this.groupStadium = new GroupBox();
      this.radioStadiumPreview = new RadioButton();
      this.groupTod = new GroupBox();
      this.radioStadiumGuiNight = new RadioButton();
      this.radioStadiumGuiSunset = new RadioButton();
      this.radioStadiumGuiOvercast = new RadioButton();
      this.radioStadiumGuiClearDay = new RadioButton();
      this.radioStadium3D = new RadioButton();
      this.groupShoes = new GroupBox();
      this.radioShoesColor = new RadioButton();
      this.groupBall = new GroupBox();
      this.radioBallPreview = new RadioButton();
      this.radioBallTexture = new RadioButton();
      this.groupCountry = new GroupBox();
      this.radioCountryMap = new RadioButton();
      this.radioCountryFlag512x512 = new RadioButton();
      this.radioCountryCard = new RadioButton();
      this.radioCountryMainFlag = new RadioButton();
      this.radioCountryMiniflag = new RadioButton();
      this.groupAdboards = new GroupBox();
      this.radioAdboard1 = new RadioButton();
      this.groupKit = new GroupBox();
      this.radioKitKit = new RadioButton();
      this.radioKitMinikit = new RadioButton();
      this.groupPlayer = new GroupBox();
      this.radioHairTextures = new RadioButton();
      this.radioHairColorTexture = new RadioButton();
      this.radioEyesTexture = new RadioButton();
      this.radioFaceTexture = new RadioButton();
      this.radioMiniHead = new RadioButton();
      this.pictureBox1 = new PictureBox();
      this.groupReplaceSelection = new GroupBox();
      this.comboReplaceLicensedTournament = new ComboBox();
      this.comboReplaceKit = new ComboBox();
      this.labelCmsCreated = new Label();
      this.labelCmsReplaced = new Label();
      this.textCmsReplaced = new TextBox();
      this.comboReplaceMowingPattern = new ComboBox();
      this.radioCmsItem = new RadioButton();
      this.comboReplaceGkGloves = new ComboBox();
      this.comboReplaceNet = new ComboBox();
      this.comboReplaceShoes = new ComboBox();
      this.comboReplaceNamesFont = new ComboBox();
      this.comboReplaceNumberFont = new ComboBox();
      this.comboReplaceAdboard = new ComboBox();
      this.comboReplaceBall = new ComboBox();
      this.comboReplaceReferee = new ComboBox();
      this.comboReplaceSponsor = new ComboBox();
      this.comboReplaceFormation = new ComboBox();
      this.comboReplaceTournament = new ComboBox();
      this.comboReplaceStadium = new ComboBox();
      this.comboReplaceCountry = new ComboBox();
      this.comboReplaceLeague = new ComboBox();
      this.comboReplacePlayer = new ComboBox();
      this.comboReplaceTeam = new ComboBox();
      this.radioReplaceItem = new RadioButton();
      this.radioCreateItem = new RadioButton();
      this.labelDetails = new Label();
      this.mainMenu.SuspendLayout();
      this.toolMain.SuspendLayout();
      this.panelLeft.SuspendLayout();
      this.groupPatchOptions.SuspendLayout();
      this.tabPatchOptions.SuspendLayout();
      this.pagePlayerOptions.SuspendLayout();
      this.groupDualClub.SuspendLayout();
      this.pageTeamOptions.SuspendLayout();
      this.pageLeagueOptions.SuspendLayout();
      this.pageStadiumOptions.SuspendLayout();
      this.pageKitOptions.SuspendLayout();
      this.pageCountryOptions.SuspendLayout();
      this.statusBar.SuspendLayout();
      this.splitContainer1.BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.panelRight.SuspendLayout();
      this.tabPreview.SuspendLayout();
      this.pageViewer2D.SuspendLayout();
      this.pageMultiViewer2D.SuspendLayout();
      this.panelGraphicGroups.SuspendLayout();
      this.groupTeam.SuspendLayout();
      this.groupLeague.SuspendLayout();
      this.groupStadium.SuspendLayout();
      this.groupTod.SuspendLayout();
      this.groupShoes.SuspendLayout();
      this.groupBall.SuspendLayout();
      this.groupCountry.SuspendLayout();
      this.groupAdboards.SuspendLayout();
      this.groupKit.SuspendLayout();
      this.groupPlayer.SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.groupReplaceSelection.SuspendLayout();
      this.SuspendLayout();
      this.mainMenu.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.patchToolStripMenuItem
      });
      this.mainMenu.Location = new Point(0, 0);
      this.mainMenu.Name = "mainMenu";
      this.mainMenu.Size = new Size(1157, 24);
      this.mainMenu.TabIndex = 0;
      this.mainMenu.Text = "menuStrip1";
      this.patchToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.openToolStripMenuItem,
        (ToolStripItem) this.importToolStripMenuItem,
        (ToolStripItem) this.exitToolStripMenuItem
      });
      this.patchToolStripMenuItem.Name = "patchToolStripMenuItem";
      this.patchToolStripMenuItem.Size = new Size(49, 20);
      this.patchToolStripMenuItem.Text = "Patch";
      this.openToolStripMenuItem.Image = (Image) resources.GetObject("openToolStripMenuItem.Image");
      this.openToolStripMenuItem.ImageTransparentColor = Color.Fuchsia;
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.Size = new Size(110, 22);
      this.openToolStripMenuItem.Text = "Open";
      this.openToolStripMenuItem.Click += new EventHandler(this.openToolStripMenuItem_Click);
      this.importToolStripMenuItem.Enabled = false;
      this.importToolStripMenuItem.Image = (Image) resources.GetObject("importToolStripMenuItem.Image");
      this.importToolStripMenuItem.ImageTransparentColor = Color.Fuchsia;
      this.importToolStripMenuItem.Name = "importToolStripMenuItem";
      this.importToolStripMenuItem.Size = new Size(110, 22);
      this.importToolStripMenuItem.Text = "Import";
      this.importToolStripMenuItem.Click += new EventHandler(this.importToolStripMenuItem_Click);
      this.exitToolStripMenuItem.Image = (Image) resources.GetObject("exitToolStripMenuItem.Image");
      this.exitToolStripMenuItem.ImageTransparentColor = Color.Fuchsia;
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new Size(110, 22);
      this.exitToolStripMenuItem.Text = "Exit";
      this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
      this.toolMain.GripStyle = ToolStripGripStyle.Hidden;
      this.toolMain.Items.AddRange(new ToolStripItem[11]
      {
        (ToolStripItem) this.buttonLoadPatch,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.buttonImportPatch,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.buttonExitCreator,
        (ToolStripItem) this.buttonSelectAllObjects,
        (ToolStripItem) this.toolStripSeparator3,
        (ToolStripItem) this.buttonDeselectAllObjects,
        (ToolStripItem) this.toolStripSeparator4,
        (ToolStripItem) this.buttonSelectNewObjects,
        (ToolStripItem) this.stripButtonPreview
      });
      this.toolMain.Location = new Point(0, 24);
      this.toolMain.Name = "toolMain";
      this.toolMain.Size = new Size(1157, 25);
      this.toolMain.TabIndex = 1;
      this.toolMain.Text = "toolStrip1";
      this.buttonLoadPatch.Image = (Image) resources.GetObject("buttonLoadPatch.Image");
      this.buttonLoadPatch.ImageTransparentColor = Color.Magenta;
      this.buttonLoadPatch.Margin = new Padding(10, 1, 0, 2);
      this.buttonLoadPatch.Name = "buttonLoadPatch";
      this.buttonLoadPatch.Size = new Size(62, 22);
      this.buttonLoadPatch.Text = "Open  ";
      this.buttonLoadPatch.Click += new EventHandler(this.buttonLoadPatch_Click);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(6, 25);
      this.buttonImportPatch.Enabled = false;
      this.buttonImportPatch.Image = (Image) resources.GetObject("buttonImportPatch.Image");
      this.buttonImportPatch.ImageTransparentColor = Color.Magenta;
      this.buttonImportPatch.Margin = new Padding(10, 1, 0, 2);
      this.buttonImportPatch.Name = "buttonImportPatch";
      this.buttonImportPatch.Size = new Size(63, 22);
      this.buttonImportPatch.Text = "Import";
      this.buttonImportPatch.Click += new EventHandler(this.buttonImportPatch_Click);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(6, 25);
      this.buttonExitCreator.Image = (Image) resources.GetObject("buttonExitCreator.Image");
      this.buttonExitCreator.ImageTransparentColor = Color.Magenta;
      this.buttonExitCreator.Margin = new Padding(10, 1, 0, 2);
      this.buttonExitCreator.Name = "buttonExitCreator";
      this.buttonExitCreator.Size = new Size(45, 22);
      this.buttonExitCreator.Text = "Exit";
      this.buttonExitCreator.Click += new EventHandler(this.buttonExitCreator_Click);
      this.buttonSelectAllObjects.Image = (Image) resources.GetObject("buttonSelectAllObjects.Image");
      this.buttonSelectAllObjects.ImageTransparentColor = Color.Magenta;
      this.buttonSelectAllObjects.Margin = new Padding(120, 1, 0, 2);
      this.buttonSelectAllObjects.Name = "buttonSelectAllObjects";
      this.buttonSelectAllObjects.Size = new Size(75, 22);
      this.buttonSelectAllObjects.Text = "Select All";
      this.buttonSelectAllObjects.Click += new EventHandler(this.buttonSelectAll_Click);
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new Size(6, 25);
      this.buttonDeselectAllObjects.Image = (Image) resources.GetObject("buttonDeselectAllObjects.Image");
      this.buttonDeselectAllObjects.ImageTransparentColor = Color.Magenta;
      this.buttonDeselectAllObjects.Margin = new Padding(10, 1, 0, 2);
      this.buttonDeselectAllObjects.Name = "buttonDeselectAllObjects";
      this.buttonDeselectAllObjects.Size = new Size(88, 22);
      this.buttonDeselectAllObjects.Text = "Deselect All";
      this.buttonDeselectAllObjects.Click += new EventHandler(this.buttonDeselectAll_Click);
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new Size(6, 25);
      this.buttonSelectNewObjects.Image = (Image) resources.GetObject("buttonSelectNewObjects.Image");
      this.buttonSelectNewObjects.ImageTransparentColor = Color.Transparent;
      this.buttonSelectNewObjects.Margin = new Padding(10, 1, 0, 2);
      this.buttonSelectNewObjects.Name = "buttonSelectNewObjects";
      this.buttonSelectNewObjects.Size = new Size(93, 22);
      this.buttonSelectNewObjects.Text = "Select if new";
      this.buttonSelectNewObjects.Click += new EventHandler(this.buttonSelectNewObjects_Click);
      this.stripButtonPreview.CheckOnClick = true;
      this.stripButtonPreview.Image = (Image) resources.GetObject("stripButtonPreview.Image");
      this.stripButtonPreview.ImageTransparentColor = Color.Magenta;
      this.stripButtonPreview.Margin = new Padding(310, 1, 0, 2);
      this.stripButtonPreview.Name = "stripButtonPreview";
      this.stripButtonPreview.Size = new Size(68, 22);
      this.stripButtonPreview.Text = "Preview";
      this.stripButtonPreview.Click += new EventHandler(this.stripButtonPreview_Click);
      this.panelLeft.AutoScroll = true;
      this.panelLeft.Controls.Add((Control) this.textDescription);
      this.panelLeft.Controls.Add((Control) this.groupPatchOptions);
      this.panelLeft.Controls.Add((Control) this.textPatchVersion);
      this.panelLeft.Controls.Add((Control) this.textPatchName);
      this.panelLeft.Controls.Add((Control) this.labelDescription);
      this.panelLeft.Controls.Add((Control) this.checkCMS);
      this.panelLeft.Controls.Add((Control) this.labelPatchVersion);
      this.panelLeft.Controls.Add((Control) this.labelPatchName);
      this.panelLeft.Dock = DockStyle.Left;
      this.panelLeft.Location = new Point(0, 49);
      this.panelLeft.Name = "panelLeft";
      this.panelLeft.Size = new Size(300, 675);
      this.panelLeft.TabIndex = 2;
      this.textDescription.BackColor = Color.White;
      this.textDescription.Enabled = false;
      this.textDescription.Location = new Point(9, 102);
      this.textDescription.Multiline = true;
      this.textDescription.Name = "textDescription";
      this.textDescription.Size = new Size(281, 200);
      this.textDescription.TabIndex = 33;
      this.groupPatchOptions.Controls.Add((Control) this.tabPatchOptions);
      this.groupPatchOptions.Dock = DockStyle.Fill;
      this.groupPatchOptions.Location = new Point(0, 311);
      this.groupPatchOptions.Name = "groupPatchOptions";
      this.groupPatchOptions.RightToLeft = RightToLeft.No;
      this.groupPatchOptions.Size = new Size(300, 364);
      this.groupPatchOptions.TabIndex = 34;
      this.groupPatchOptions.TabStop = false;
      this.groupPatchOptions.Text = "Import Options";
      this.tabPatchOptions.Controls.Add((Control) this.pagePlayerOptions);
      this.tabPatchOptions.Controls.Add((Control) this.pageTeamOptions);
      this.tabPatchOptions.Controls.Add((Control) this.pageLeagueOptions);
      this.tabPatchOptions.Controls.Add((Control) this.pageStadiumOptions);
      this.tabPatchOptions.Controls.Add((Control) this.pageKitOptions);
      this.tabPatchOptions.Controls.Add((Control) this.pageCountryOptions);
      this.tabPatchOptions.Dock = DockStyle.Fill;
      this.tabPatchOptions.ItemSize = new Size(80, 20);
      this.tabPatchOptions.Location = new Point(3, 16);
      this.tabPatchOptions.Multiline = true;
      this.tabPatchOptions.Name = "tabPatchOptions";
      this.tabPatchOptions.SelectedIndex = 0;
      this.tabPatchOptions.Size = new Size(294, 345);
      this.tabPatchOptions.SizeMode = TabSizeMode.FillToRight;
      this.tabPatchOptions.TabIndex = 8;
      this.pagePlayerOptions.Controls.Add((Control) this.groupDualClub);
      this.pagePlayerOptions.Controls.Add((Control) this.checkPlayerMiniface);
      this.pagePlayerOptions.Controls.Add((Control) this.checkPlayerHead);
      this.pagePlayerOptions.Controls.Add((Control) this.checkPlayerDatabase);
      this.pagePlayerOptions.Location = new Point(4, 44);
      this.pagePlayerOptions.Name = "pagePlayerOptions";
      this.pagePlayerOptions.Padding = new Padding(3);
      this.pagePlayerOptions.Size = new Size(286, 297);
      this.pagePlayerOptions.TabIndex = 0;
      this.pagePlayerOptions.Text = "Players";
      this.pagePlayerOptions.UseVisualStyleBackColor = true;
      this.groupDualClub.Controls.Add((Control) this.radioPutInBothTeams);
      this.groupDualClub.Controls.Add((Control) this.radioTransferToNewTeam);
      this.groupDualClub.Controls.Add((Control) this.radioLeaveInExistingTeam);
      this.groupDualClub.Location = new Point(20, 101);
      this.groupDualClub.Name = "groupDualClub";
      this.groupDualClub.Size = new Size(239, 100);
      this.groupDualClub.TabIndex = 3;
      this.groupDualClub.TabStop = false;
      this.groupDualClub.Text = "Double Club Option";
      this.radioPutInBothTeams.AutoSize = true;
      this.radioPutInBothTeams.Checked = true;
      this.radioPutInBothTeams.Location = new Point(8, 65);
      this.radioPutInBothTeams.Name = "radioPutInBothTeams";
      this.radioPutInBothTeams.Size = new Size(107, 17);
      this.radioPutInBothTeams.TabIndex = 6;
      this.radioPutInBothTeams.TabStop = true;
      this.radioPutInBothTeams.Text = "Put in both teams";
      this.radioPutInBothTeams.UseVisualStyleBackColor = true;
      this.radioTransferToNewTeam.AutoSize = true;
      this.radioTransferToNewTeam.Location = new Point(8, 42);
      this.radioTransferToNewTeam.Name = "radioTransferToNewTeam";
      this.radioTransferToNewTeam.Size = new Size(125, 17);
      this.radioTransferToNewTeam.TabIndex = 5;
      this.radioTransferToNewTeam.Text = "Transfer to new team";
      this.radioTransferToNewTeam.UseVisualStyleBackColor = true;
      this.radioLeaveInExistingTeam.AutoSize = true;
      this.radioLeaveInExistingTeam.Location = new Point(8, 19);
      this.radioLeaveInExistingTeam.Name = "radioLeaveInExistingTeam";
      this.radioLeaveInExistingTeam.Size = new Size(128, 17);
      this.radioLeaveInExistingTeam.TabIndex = 4;
      this.radioLeaveInExistingTeam.Text = "Leave in current team";
      this.radioLeaveInExistingTeam.UseVisualStyleBackColor = true;
      this.checkPlayerMiniface.AutoSize = true;
      this.checkPlayerMiniface.Checked = true;
      this.checkPlayerMiniface.CheckState = CheckState.Checked;
      this.checkPlayerMiniface.ImeMode = ImeMode.NoControl;
      this.checkPlayerMiniface.Location = new Point(20, 66);
      this.checkPlayerMiniface.Name = "checkPlayerMiniface";
      this.checkPlayerMiniface.Size = new Size(66, 17);
      this.checkPlayerMiniface.TabIndex = 2;
      this.checkPlayerMiniface.Text = "Miniface";
      this.checkPlayerMiniface.UseVisualStyleBackColor = true;
      this.checkPlayerHead.AutoSize = true;
      this.checkPlayerHead.Checked = true;
      this.checkPlayerHead.CheckState = CheckState.Checked;
      this.checkPlayerHead.ImeMode = ImeMode.NoControl;
      this.checkPlayerHead.Location = new Point(20, 43);
      this.checkPlayerHead.Name = "checkPlayerHead";
      this.checkPlayerHead.Size = new Size(93, 17);
      this.checkPlayerHead.TabIndex = 1;
      this.checkPlayerHead.Text = "Specific Head";
      this.checkPlayerHead.UseVisualStyleBackColor = true;
      this.checkPlayerDatabase.AutoSize = true;
      this.checkPlayerDatabase.Checked = true;
      this.checkPlayerDatabase.CheckState = CheckState.Checked;
      this.checkPlayerDatabase.ImeMode = ImeMode.NoControl;
      this.checkPlayerDatabase.Location = new Point(20, 20);
      this.checkPlayerDatabase.Name = "checkPlayerDatabase";
      this.checkPlayerDatabase.Size = new Size(123, 17);
      this.checkPlayerDatabase.TabIndex = 0;
      this.checkPlayerDatabase.Text = "Database player info";
      this.checkPlayerDatabase.UseVisualStyleBackColor = true;
      this.pageTeamOptions.Controls.Add((Control) this.checkTeamFlags);
      this.pageTeamOptions.Controls.Add((Control) this.checkTeamBanner);
      this.pageTeamOptions.Controls.Add((Control) this.checkTeamLogo);
      this.pageTeamOptions.Controls.Add((Control) this.checkTeamDatabase);
      this.pageTeamOptions.Location = new Point(4, 44);
      this.pageTeamOptions.Name = "pageTeamOptions";
      this.pageTeamOptions.Padding = new Padding(3);
      this.pageTeamOptions.Size = new Size(286, 297);
      this.pageTeamOptions.TabIndex = 1;
      this.pageTeamOptions.Text = "Teams";
      this.pageTeamOptions.UseVisualStyleBackColor = true;
      this.checkTeamFlags.AutoSize = true;
      this.checkTeamFlags.Checked = true;
      this.checkTeamFlags.CheckState = CheckState.Checked;
      this.checkTeamFlags.ImeMode = ImeMode.NoControl;
      this.checkTeamFlags.Location = new Point(20, 89);
      this.checkTeamFlags.Name = "checkTeamFlags";
      this.checkTeamFlags.Size = new Size(51, 17);
      this.checkTeamFlags.TabIndex = 5;
      this.checkTeamFlags.Text = "Flags";
      this.checkTeamFlags.UseVisualStyleBackColor = true;
      this.checkTeamBanner.AutoSize = true;
      this.checkTeamBanner.Checked = true;
      this.checkTeamBanner.CheckState = CheckState.Checked;
      this.checkTeamBanner.ImeMode = ImeMode.NoControl;
      this.checkTeamBanner.Location = new Point(20, 66);
      this.checkTeamBanner.Name = "checkTeamBanner";
      this.checkTeamBanner.Size = new Size(65, 17);
      this.checkTeamBanner.TabIndex = 3;
      this.checkTeamBanner.Text = "Banners";
      this.checkTeamBanner.UseVisualStyleBackColor = true;
      this.checkTeamLogo.AutoSize = true;
      this.checkTeamLogo.Checked = true;
      this.checkTeamLogo.CheckState = CheckState.Checked;
      this.checkTeamLogo.ImeMode = ImeMode.NoControl;
      this.checkTeamLogo.Location = new Point(20, 43);
      this.checkTeamLogo.Name = "checkTeamLogo";
      this.checkTeamLogo.Size = new Size(50, 17);
      this.checkTeamLogo.TabIndex = 2;
      this.checkTeamLogo.Text = "Logo";
      this.checkTeamLogo.UseVisualStyleBackColor = true;
      this.checkTeamDatabase.AutoSize = true;
      this.checkTeamDatabase.Checked = true;
      this.checkTeamDatabase.CheckState = CheckState.Checked;
      this.checkTeamDatabase.ImeMode = ImeMode.NoControl;
      this.checkTeamDatabase.Location = new Point(20, 20);
      this.checkTeamDatabase.Name = "checkTeamDatabase";
      this.checkTeamDatabase.Size = new Size(118, 17);
      this.checkTeamDatabase.TabIndex = 1;
      this.checkTeamDatabase.Text = "Database team info";
      this.checkTeamDatabase.UseVisualStyleBackColor = true;
      this.pageLeagueOptions.Controls.Add((Control) this.checkLeagueLogo);
      this.pageLeagueOptions.Controls.Add((Control) this.checkLeagueDatabase);
      this.pageLeagueOptions.Location = new Point(4, 44);
      this.pageLeagueOptions.Name = "pageLeagueOptions";
      this.pageLeagueOptions.Size = new Size(286, 297);
      this.pageLeagueOptions.TabIndex = 2;
      this.pageLeagueOptions.Text = "Leagues";
      this.pageLeagueOptions.UseVisualStyleBackColor = true;
      this.checkLeagueLogo.AutoSize = true;
      this.checkLeagueLogo.Checked = true;
      this.checkLeagueLogo.CheckState = CheckState.Checked;
      this.checkLeagueLogo.ImeMode = ImeMode.NoControl;
      this.checkLeagueLogo.Location = new Point(20, 43);
      this.checkLeagueLogo.Name = "checkLeagueLogo";
      this.checkLeagueLogo.Size = new Size(50, 17);
      this.checkLeagueLogo.TabIndex = 10;
      this.checkLeagueLogo.Text = "Logo";
      this.checkLeagueLogo.UseVisualStyleBackColor = true;
      this.checkLeagueDatabase.AutoSize = true;
      this.checkLeagueDatabase.Checked = true;
      this.checkLeagueDatabase.CheckState = CheckState.Checked;
      this.checkLeagueDatabase.ImeMode = ImeMode.NoControl;
      this.checkLeagueDatabase.Location = new Point(20, 20);
      this.checkLeagueDatabase.Name = "checkLeagueDatabase";
      this.checkLeagueDatabase.Size = new Size((int) sbyte.MaxValue, 17);
      this.checkLeagueDatabase.TabIndex = 9;
      this.checkLeagueDatabase.Text = "Database league info";
      this.checkLeagueDatabase.UseVisualStyleBackColor = true;
      this.pageStadiumOptions.Controls.Add((Control) this.checkStadiumModel);
      this.pageStadiumOptions.Controls.Add((Control) this.checkStadiumPreview);
      this.pageStadiumOptions.Controls.Add((Control) this.checkStadiumDatabase);
      this.pageStadiumOptions.Location = new Point(4, 44);
      this.pageStadiumOptions.Name = "pageStadiumOptions";
      this.pageStadiumOptions.Size = new Size(286, 297);
      this.pageStadiumOptions.TabIndex = 6;
      this.pageStadiumOptions.Text = "Stadiums";
      this.pageStadiumOptions.ToolTipText = "Check the stadium elements that you want to import (if present)";
      this.pageStadiumOptions.UseVisualStyleBackColor = true;
      this.checkStadiumModel.AutoSize = true;
      this.checkStadiumModel.Checked = true;
      this.checkStadiumModel.CheckState = CheckState.Checked;
      this.checkStadiumModel.ImeMode = ImeMode.NoControl;
      this.checkStadiumModel.Location = new Point(20, 43);
      this.checkStadiumModel.Name = "checkStadiumModel";
      this.checkStadiumModel.Size = new Size(71, 17);
      this.checkStadiumModel.TabIndex = 19;
      this.checkStadiumModel.Text = "3D model";
      this.checkStadiumModel.UseVisualStyleBackColor = true;
      this.checkStadiumPreview.AutoSize = true;
      this.checkStadiumPreview.Checked = true;
      this.checkStadiumPreview.CheckState = CheckState.Checked;
      this.checkStadiumPreview.ImeMode = ImeMode.NoControl;
      this.checkStadiumPreview.Location = new Point(20, 66);
      this.checkStadiumPreview.Name = "checkStadiumPreview";
      this.checkStadiumPreview.Size = new Size(99, 17);
      this.checkStadiumPreview.TabIndex = 17;
      this.checkStadiumPreview.Text = "Preview picture";
      this.checkStadiumPreview.UseVisualStyleBackColor = true;
      this.checkStadiumDatabase.AutoSize = true;
      this.checkStadiumDatabase.Checked = true;
      this.checkStadiumDatabase.CheckState = CheckState.Checked;
      this.checkStadiumDatabase.ImeMode = ImeMode.NoControl;
      this.checkStadiumDatabase.Location = new Point(20, 20);
      this.checkStadiumDatabase.Name = "checkStadiumDatabase";
      this.checkStadiumDatabase.Size = new Size(131, 17);
      this.checkStadiumDatabase.TabIndex = 16;
      this.checkStadiumDatabase.Text = "Database stadium info";
      this.checkStadiumDatabase.UseVisualStyleBackColor = true;
      this.pageKitOptions.Controls.Add((Control) this.checkMinikits);
      this.pageKitOptions.Controls.Add((Control) this.checkKits);
      this.pageKitOptions.Controls.Add((Control) this.checkKitDatabase);
      this.pageKitOptions.Location = new Point(4, 44);
      this.pageKitOptions.Name = "pageKitOptions";
      this.pageKitOptions.Size = new Size(286, 297);
      this.pageKitOptions.TabIndex = 5;
      this.pageKitOptions.Text = "Kits";
      this.pageKitOptions.UseVisualStyleBackColor = true;
      this.checkMinikits.AutoSize = true;
      this.checkMinikits.Checked = true;
      this.checkMinikits.CheckState = CheckState.Checked;
      this.checkMinikits.ImeMode = ImeMode.NoControl;
      this.checkMinikits.Location = new Point(20, 43);
      this.checkMinikits.Name = "checkMinikits";
      this.checkMinikits.Size = new Size(61, 17);
      this.checkMinikits.TabIndex = 9;
      this.checkMinikits.Text = "Minikits";
      this.checkMinikits.UseVisualStyleBackColor = true;
      this.checkKits.AutoSize = true;
      this.checkKits.Checked = true;
      this.checkKits.CheckState = CheckState.Checked;
      this.checkKits.ImeMode = ImeMode.NoControl;
      this.checkKits.Location = new Point(20, 20);
      this.checkKits.Name = "checkKits";
      this.checkKits.Size = new Size(43, 17);
      this.checkKits.TabIndex = 8;
      this.checkKits.Text = "Kits";
      this.checkKits.UseVisualStyleBackColor = true;
      this.checkKitDatabase.AutoSize = true;
      this.checkKitDatabase.Checked = true;
      this.checkKitDatabase.CheckState = CheckState.Checked;
      this.checkKitDatabase.ImeMode = ImeMode.NoControl;
      this.checkKitDatabase.Location = new Point(154, 43);
      this.checkKitDatabase.Name = "checkKitDatabase";
      this.checkKitDatabase.Size = new Size(106, 17);
      this.checkKitDatabase.TabIndex = 2;
      this.checkKitDatabase.Text = "Database kit info";
      this.checkKitDatabase.UseVisualStyleBackColor = true;
      this.checkKitDatabase.Visible = false;
      this.pageCountryOptions.Controls.Add((Control) this.checkCountryMap);
      this.pageCountryOptions.Controls.Add((Control) this.checkCountryDatabase);
      this.pageCountryOptions.Controls.Add((Control) this.checkCountryFlag);
      this.pageCountryOptions.Location = new Point(4, 44);
      this.pageCountryOptions.Name = "pageCountryOptions";
      this.pageCountryOptions.Size = new Size(286, 297);
      this.pageCountryOptions.TabIndex = 3;
      this.pageCountryOptions.Text = "Countries";
      this.pageCountryOptions.UseVisualStyleBackColor = true;
      this.checkCountryMap.AutoSize = true;
      this.checkCountryMap.Checked = true;
      this.checkCountryMap.CheckState = CheckState.Checked;
      this.checkCountryMap.ImeMode = ImeMode.NoControl;
      this.checkCountryMap.Location = new Point(20, 66);
      this.checkCountryMap.Name = "checkCountryMap";
      this.checkCountryMap.Size = new Size(47, 17);
      this.checkCountryMap.TabIndex = 3;
      this.checkCountryMap.Text = "Map";
      this.checkCountryMap.UseVisualStyleBackColor = true;
      this.checkCountryDatabase.AutoSize = true;
      this.checkCountryDatabase.Checked = true;
      this.checkCountryDatabase.CheckState = CheckState.Checked;
      this.checkCountryDatabase.ImeMode = ImeMode.NoControl;
      this.checkCountryDatabase.Location = new Point(20, 20);
      this.checkCountryDatabase.Name = "checkCountryDatabase";
      this.checkCountryDatabase.Size = new Size(130, 17);
      this.checkCountryDatabase.TabIndex = 1;
      this.checkCountryDatabase.Text = "Database country info";
      this.checkCountryDatabase.UseVisualStyleBackColor = true;
      this.checkCountryFlag.AutoSize = true;
      this.checkCountryFlag.Checked = true;
      this.checkCountryFlag.CheckState = CheckState.Checked;
      this.checkCountryFlag.ImeMode = ImeMode.NoControl;
      this.checkCountryFlag.Location = new Point(20, 43);
      this.checkCountryFlag.Name = "checkCountryFlag";
      this.checkCountryFlag.Size = new Size(51, 17);
      this.checkCountryFlag.TabIndex = 0;
      this.checkCountryFlag.Text = "Flags";
      this.checkCountryFlag.UseVisualStyleBackColor = true;
      this.textPatchVersion.BackColor = Color.White;
      this.textPatchVersion.Enabled = false;
      this.textPatchVersion.Location = new Point(76, 33);
      this.textPatchVersion.Name = "textPatchVersion";
      this.textPatchVersion.Size = new Size(213, 20);
      this.textPatchVersion.TabIndex = 31;
      this.textPatchVersion.TextAlign = HorizontalAlignment.Center;
      this.textPatchName.BackColor = Color.White;
      this.textPatchName.Enabled = false;
      this.textPatchName.Location = new Point(77, 5);
      this.textPatchName.Name = "textPatchName";
      this.textPatchName.Size = new Size(213, 20);
      this.textPatchName.TabIndex = 29;
      this.textPatchName.TextAlign = HorizontalAlignment.Center;
      this.labelDescription.Dock = DockStyle.Top;
      this.labelDescription.ImeMode = ImeMode.NoControl;
      this.labelDescription.Location = new Point(0, 84);
      this.labelDescription.Name = "labelDescription";
      this.labelDescription.Size = new Size(300, 227);
      this.labelDescription.TabIndex = 32;
      this.labelDescription.Text = "Description";
      this.labelDescription.TextAlign = ContentAlignment.TopCenter;
      this.checkCMS.CheckAlign = ContentAlignment.MiddleCenter;
      this.checkCMS.Dock = DockStyle.Top;
      this.checkCMS.Enabled = false;
      this.checkCMS.Location = new Point(0, 56);
      this.checkCMS.Name = "checkCMS";
      this.checkCMS.Size = new Size(300, 28);
      this.checkCMS.TabIndex = 35;
      this.checkCMS.Text = "CMS 14 Compliant";
      this.checkCMS.UseVisualStyleBackColor = true;
      this.checkCMS.Visible = false;
      this.labelPatchVersion.Dock = DockStyle.Top;
      this.labelPatchVersion.ImeMode = ImeMode.NoControl;
      this.labelPatchVersion.Location = new Point(0, 28);
      this.labelPatchVersion.Name = "labelPatchVersion";
      this.labelPatchVersion.Size = new Size(300, 28);
      this.labelPatchVersion.TabIndex = 30;
      this.labelPatchVersion.Text = "Patch Version";
      this.labelPatchVersion.TextAlign = ContentAlignment.MiddleLeft;
      this.labelPatchName.Dock = DockStyle.Top;
      this.labelPatchName.ImeMode = ImeMode.NoControl;
      this.labelPatchName.Location = new Point(0, 0);
      this.labelPatchName.Name = "labelPatchName";
      this.labelPatchName.Size = new Size(300, 28);
      this.labelPatchName.TabIndex = 28;
      this.labelPatchName.Text = "Patch Name";
      this.labelPatchName.TextAlign = ContentAlignment.MiddleLeft;
      this.statusBar.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.statusLabel
      });
      this.statusBar.Location = new Point(0, 724);
      this.statusBar.Name = "statusBar";
      this.statusBar.Size = new Size(1157, 22);
      this.statusBar.TabIndex = 3;
      this.statusBar.Text = "statusStrip1";
      this.statusLabel.Name = "statusLabel";
      this.statusLabel.Size = new Size(39, 17);
      this.statusLabel.Text = "Ready";
      this.splitContainer1.Dock = DockStyle.Fill;
      this.splitContainer1.Location = new Point(300, 49);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Panel1.Controls.Add((Control) this.listViewPatch);
      this.splitContainer1.Panel2.Controls.Add((Control) this.panelRight);
      this.splitContainer1.Size = new Size(857, 675);
      this.splitContainer1.SplitterDistance = 468;
      this.splitContainer1.TabIndex = 3;
      this.splitContainer1.TabStop = false;
      this.listViewPatch.AllowColumnReorder = true;
      this.listViewPatch.CheckBoxes = true;
      this.listViewPatch.Columns.AddRange(new ColumnHeader[5]
      {
        this.columnItem,
        this.columnType,
        this.columnPatchId,
        this.columnImportId,
        this.columnComment
      });
      this.listViewPatch.Dock = DockStyle.Fill;
      this.listViewPatch.Font = new Font("Microsoft Sans Serif", 8.25f);
      this.listViewPatch.FullRowSelect = true;
      this.listViewPatch.GridLines = true;
      this.listViewPatch.HideSelection = false;
      this.listViewPatch.Location = new Point(0, 0);
      this.listViewPatch.Name = "listViewPatch";
      this.listViewPatch.Size = new Size(468, 675);
      this.listViewPatch.TabIndex = 28;
      this.listViewPatch.UseCompatibleStateImageBehavior = false;
      this.listViewPatch.View = View.Details;
      this.listViewPatch.SelectedIndexChanged += new EventHandler(this.listViewPatch_SelectedIndexChanged);
      this.columnItem.Text = "Name";
      this.columnItem.Width = 136;
      this.columnType.Text = "Type";
      this.columnType.Width = 68;
      this.columnPatchId.Text = "Patch Id";
      this.columnPatchId.TextAlign = HorizontalAlignment.Center;
      this.columnPatchId.Width = 55;
      this.columnImportId.Text = "Import As";
      this.columnImportId.TextAlign = HorizontalAlignment.Center;
      this.columnComment.Text = "Comment";
      this.columnComment.TextAlign = HorizontalAlignment.Center;
      this.columnComment.Width = 121;
      this.panelRight.AutoScroll = true;
      this.panelRight.Controls.Add((Control) this.tabPreview);
      this.panelRight.Controls.Add((Control) this.panelGraphicGroups);
      this.panelRight.Controls.Add((Control) this.pictureBox1);
      this.panelRight.Controls.Add((Control) this.groupReplaceSelection);
      this.panelRight.Controls.Add((Control) this.labelDetails);
      this.panelRight.Dock = DockStyle.Fill;
      this.panelRight.Location = new Point(0, 0);
      this.panelRight.Name = "panelRight";
      this.panelRight.Size = new Size(385, 675);
      this.panelRight.TabIndex = 4;
      this.tabPreview.Controls.Add((Control) this.pageViewer2D);
      this.tabPreview.Controls.Add((Control) this.pageMultiViewer2D);
      this.tabPreview.Dock = DockStyle.Fill;
      this.tabPreview.Location = new Point(0, 230);
      this.tabPreview.Name = "tabPreview";
      this.tabPreview.SelectedIndex = 0;
      this.tabPreview.Size = new Size(385, 445);
      this.tabPreview.TabIndex = 53;
      this.pageViewer2D.Controls.Add((Control) this.viewer2D);
      this.pageViewer2D.Location = new Point(4, 22);
      this.pageViewer2D.Name = "pageViewer2D";
      this.pageViewer2D.Padding = new Padding(3);
      this.pageViewer2D.Size = new Size(377, 419);
      this.pageViewer2D.TabIndex = 0;
      this.pageViewer2D.Text = "UI Art Assets";
      this.pageViewer2D.UseVisualStyleBackColor = true;
      this.viewer2D.AutoTransparency = false;
      this.viewer2D.BackColor = Color.Transparent;
      this.viewer2D.ButtonStripVisible = false;
      this.viewer2D.CurrentBitmap = (Bitmap) null;
      this.viewer2D.Dock = DockStyle.Fill;
      this.viewer2D.ExtendedFormat = false;
      this.viewer2D.FullSizeButton = false;
      this.viewer2D.ImageLayout = ImageLayout.None;
      this.viewer2D.ImageSize = new Size(0, 0);
      this.viewer2D.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2D.Location = new Point(3, 3);
      this.viewer2D.Name = "viewer2D";
      this.viewer2D.RemoveButton = false;
      this.viewer2D.ShowButton = false;
      this.viewer2D.ShowButtonChecked = true;
      this.viewer2D.Size = new Size(371, 413);
      this.viewer2D.TabIndex = 0;
      this.pageMultiViewer2D.Controls.Add((Control) this.multiViewer2D);
      this.pageMultiViewer2D.Location = new Point(4, 22);
      this.pageMultiViewer2D.Name = "pageMultiViewer2D";
      this.pageMultiViewer2D.Size = new Size(377, 419);
      this.pageMultiViewer2D.TabIndex = 2;
      this.pageMultiViewer2D.Text = "Scene Assets";
      this.pageMultiViewer2D.UseVisualStyleBackColor = true;
      this.multiViewer2D.AutoTransparency = false;
      this.multiViewer2D.Bitmaps = (Bitmap[]) null;
      this.multiViewer2D.CheckBitmapSize = false;
      this.multiViewer2D.Dock = DockStyle.Fill;
      this.multiViewer2D.FixedSize = false;
      this.multiViewer2D.FullSizeButton = false;
      this.multiViewer2D.LabelText = "Image n.";
      this.multiViewer2D.Location = new Point(0, 0);
      this.multiViewer2D.Name = "multiViewer2D";
      this.multiViewer2D.ShowDeleteButton = false;
      this.multiViewer2D.Size = new Size(377, 419);
      this.multiViewer2D.TabIndex = 0;
      this.panelGraphicGroups.Controls.Add((Control) this.groupTeam);
      this.panelGraphicGroups.Controls.Add((Control) this.groupLeague);
      this.panelGraphicGroups.Controls.Add((Control) this.groupStadium);
      this.panelGraphicGroups.Controls.Add((Control) this.groupShoes);
      this.panelGraphicGroups.Controls.Add((Control) this.groupBall);
      this.panelGraphicGroups.Controls.Add((Control) this.groupCountry);
      this.panelGraphicGroups.Controls.Add((Control) this.groupAdboards);
      this.panelGraphicGroups.Controls.Add((Control) this.groupKit);
      this.panelGraphicGroups.Controls.Add((Control) this.groupPlayer);
      this.panelGraphicGroups.Dock = DockStyle.Top;
      this.panelGraphicGroups.Location = new Point(0, 126);
      this.panelGraphicGroups.Name = "panelGraphicGroups";
      this.panelGraphicGroups.Size = new Size(385, 104);
      this.panelGraphicGroups.TabIndex = 52;
      this.panelGraphicGroups.Visible = false;
      this.groupTeam.Controls.Add((Control) this.radioTeamCrest50);
      this.groupTeam.Controls.Add((Control) this.radioTeamCrest16);
      this.groupTeam.Controls.Add((Control) this.radioTeamCrest32);
      this.groupTeam.Controls.Add((Control) this.radioTeamCrestLarge);
      this.groupTeam.Controls.Add((Control) this.radioTeamFlags);
      this.groupTeam.Controls.Add((Control) this.radioTeamBanners);
      this.groupTeam.Location = new Point(5, 5);
      this.groupTeam.Name = "groupTeam";
      this.groupTeam.Size = new Size(240, 90);
      this.groupTeam.TabIndex = 41;
      this.groupTeam.TabStop = false;
      this.groupTeam.Text = "Team";
      this.groupTeam.Visible = false;
      this.radioTeamCrest50.AutoSize = true;
      this.radioTeamCrest50.ImeMode = ImeMode.NoControl;
      this.radioTeamCrest50.Location = new Point(123, 16);
      this.radioTeamCrest50.Name = "radioTeamCrest50";
      this.radioTeamCrest50.Size = new Size(87, 17);
      this.radioTeamCrest50.TabIndex = 14;
      this.radioTeamCrest50.Text = "Crest 50 x 50";
      this.radioTeamCrest50.UseVisualStyleBackColor = true;
      this.radioTeamCrest50.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.radioTeamCrest16.AutoSize = true;
      this.radioTeamCrest16.ImeMode = ImeMode.NoControl;
      this.radioTeamCrest16.Location = new Point(123, 58);
      this.radioTeamCrest16.Name = "radioTeamCrest16";
      this.radioTeamCrest16.Size = new Size(87, 17);
      this.radioTeamCrest16.TabIndex = 13;
      this.radioTeamCrest16.Text = "Crest 16 x 16";
      this.radioTeamCrest16.UseVisualStyleBackColor = true;
      this.radioTeamCrest16.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.radioTeamCrest32.AutoSize = true;
      this.radioTeamCrest32.ImeMode = ImeMode.NoControl;
      this.radioTeamCrest32.Location = new Point(123, 37);
      this.radioTeamCrest32.Name = "radioTeamCrest32";
      this.radioTeamCrest32.Size = new Size(87, 17);
      this.radioTeamCrest32.TabIndex = 12;
      this.radioTeamCrest32.Text = "Crest 32 x 32";
      this.radioTeamCrest32.UseVisualStyleBackColor = true;
      this.radioTeamCrest32.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.radioTeamCrestLarge.AutoSize = true;
      this.radioTeamCrestLarge.Checked = true;
      this.radioTeamCrestLarge.ImeMode = ImeMode.NoControl;
      this.radioTeamCrestLarge.Location = new Point(6, 16);
      this.radioTeamCrestLarge.Name = "radioTeamCrestLarge";
      this.radioTeamCrestLarge.Size = new Size(49, 17);
      this.radioTeamCrestLarge.TabIndex = 11;
      this.radioTeamCrestLarge.TabStop = true;
      this.radioTeamCrestLarge.Text = "Crest";
      this.radioTeamCrestLarge.UseVisualStyleBackColor = true;
      this.radioTeamCrestLarge.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.radioTeamFlags.AutoSize = true;
      this.radioTeamFlags.ImeMode = ImeMode.NoControl;
      this.radioTeamFlags.Location = new Point(7, 59);
      this.radioTeamFlags.Name = "radioTeamFlags";
      this.radioTeamFlags.Size = new Size(50, 17);
      this.radioTeamFlags.TabIndex = 10;
      this.radioTeamFlags.Text = "Flags";
      this.radioTeamFlags.UseVisualStyleBackColor = true;
      this.radioTeamFlags.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.radioTeamBanners.AutoSize = true;
      this.radioTeamBanners.ImeMode = ImeMode.NoControl;
      this.radioTeamBanners.Location = new Point(7, 37);
      this.radioTeamBanners.Name = "radioTeamBanners";
      this.radioTeamBanners.Size = new Size(64, 17);
      this.radioTeamBanners.TabIndex = 9;
      this.radioTeamBanners.Text = "Banners";
      this.radioTeamBanners.UseVisualStyleBackColor = true;
      this.radioTeamBanners.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.groupLeague.Controls.Add((Control) this.radioLeagueLogo512x128);
      this.groupLeague.Controls.Add((Control) this.radioLeagueAnimLogo);
      this.groupLeague.Controls.Add((Control) this.radioLeagueTinyLogo);
      this.groupLeague.Controls.Add((Control) this.radioLeagueSmallLogo);
      this.groupLeague.Location = new Point(5, 5);
      this.groupLeague.Name = "groupLeague";
      this.groupLeague.Size = new Size(240, 90);
      this.groupLeague.TabIndex = 49;
      this.groupLeague.TabStop = false;
      this.groupLeague.Text = "League";
      this.groupLeague.Visible = false;
      this.radioLeagueLogo512x128.AutoSize = true;
      this.radioLeagueLogo512x128.ImeMode = ImeMode.NoControl;
      this.radioLeagueLogo512x128.Location = new Point(105, 19);
      this.radioLeagueLogo512x128.Name = "radioLeagueLogo512x128";
      this.radioLeagueLogo512x128.Size = new Size(99, 17);
      this.radioLeagueLogo512x128.TabIndex = 4;
      this.radioLeagueLogo512x128.Text = "Logo 512 x 128";
      this.radioLeagueLogo512x128.UseVisualStyleBackColor = true;
      this.radioLeagueLogo512x128.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.radioLeagueAnimLogo.AutoSize = true;
      this.radioLeagueAnimLogo.Checked = true;
      this.radioLeagueAnimLogo.ImeMode = ImeMode.NoControl;
      this.radioLeagueAnimLogo.Location = new Point(7, 19);
      this.radioLeagueAnimLogo.Name = "radioLeagueAnimLogo";
      this.radioLeagueAnimLogo.Size = new Size(75, 17);
      this.radioLeagueAnimLogo.TabIndex = 3;
      this.radioLeagueAnimLogo.TabStop = true;
      this.radioLeagueAnimLogo.Text = "Main Logo";
      this.radioLeagueAnimLogo.UseVisualStyleBackColor = true;
      this.radioLeagueAnimLogo.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.radioLeagueTinyLogo.AutoSize = true;
      this.radioLeagueTinyLogo.ImeMode = ImeMode.NoControl;
      this.radioLeagueTinyLogo.Location = new Point(6, 45);
      this.radioLeagueTinyLogo.Name = "radioLeagueTinyLogo";
      this.radioLeagueTinyLogo.Size = new Size(72, 17);
      this.radioLeagueTinyLogo.TabIndex = 2;
      this.radioLeagueTinyLogo.Text = "Tiny Logo";
      this.radioLeagueTinyLogo.UseVisualStyleBackColor = true;
      this.radioLeagueTinyLogo.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.radioLeagueSmallLogo.AutoSize = true;
      this.radioLeagueSmallLogo.ImeMode = ImeMode.NoControl;
      this.radioLeagueSmallLogo.Location = new Point(105, 44);
      this.radioLeagueSmallLogo.Name = "radioLeagueSmallLogo";
      this.radioLeagueSmallLogo.Size = new Size(77, 17);
      this.radioLeagueSmallLogo.TabIndex = 1;
      this.radioLeagueSmallLogo.Text = "Small Logo";
      this.radioLeagueSmallLogo.UseVisualStyleBackColor = true;
      this.radioLeagueSmallLogo.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.groupStadium.Controls.Add((Control) this.radioStadiumPreview);
      this.groupStadium.Controls.Add((Control) this.groupTod);
      this.groupStadium.Controls.Add((Control) this.radioStadium3D);
      this.groupStadium.Location = new Point(5, 5);
      this.groupStadium.Name = "groupStadium";
      this.groupStadium.Size = new Size(240, 90);
      this.groupStadium.TabIndex = 45;
      this.groupStadium.TabStop = false;
      this.groupStadium.Text = "Stadium";
      this.groupStadium.Visible = false;
      this.radioStadiumPreview.AutoSize = true;
      this.radioStadiumPreview.Checked = true;
      this.radioStadiumPreview.ImeMode = ImeMode.NoControl;
      this.radioStadiumPreview.Location = new Point(7, 16);
      this.radioStadiumPreview.Name = "radioStadiumPreview";
      this.radioStadiumPreview.Size = new Size(63, 17);
      this.radioStadiumPreview.TabIndex = 12;
      this.radioStadiumPreview.TabStop = true;
      this.radioStadiumPreview.Text = "Preview";
      this.radioStadiumPreview.UseVisualStyleBackColor = true;
      this.radioStadiumPreview.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.groupTod.Controls.Add((Control) this.radioStadiumGuiNight);
      this.groupTod.Controls.Add((Control) this.radioStadiumGuiSunset);
      this.groupTod.Controls.Add((Control) this.radioStadiumGuiOvercast);
      this.groupTod.Controls.Add((Control) this.radioStadiumGuiClearDay);
      this.groupTod.Location = new Point(130, 7);
      this.groupTod.Name = "groupTod";
      this.groupTod.Size = new Size(104, 83);
      this.groupTod.TabIndex = 11;
      this.groupTod.TabStop = false;
      this.groupTod.Text = "Time of Day";
      this.radioStadiumGuiNight.AutoSize = true;
      this.radioStadiumGuiNight.ImeMode = ImeMode.NoControl;
      this.radioStadiumGuiNight.Location = new Point(7, 47);
      this.radioStadiumGuiNight.Name = "radioStadiumGuiNight";
      this.radioStadiumGuiNight.Size = new Size(50, 17);
      this.radioStadiumGuiNight.TabIndex = 10;
      this.radioStadiumGuiNight.TabStop = true;
      this.radioStadiumGuiNight.Text = "Night";
      this.radioStadiumGuiNight.UseVisualStyleBackColor = true;
      this.radioStadiumGuiNight.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.radioStadiumGuiSunset.AutoSize = true;
      this.radioStadiumGuiSunset.ImeMode = ImeMode.NoControl;
      this.radioStadiumGuiSunset.Location = new Point(7, 63);
      this.radioStadiumGuiSunset.Name = "radioStadiumGuiSunset";
      this.radioStadiumGuiSunset.Size = new Size(58, 17);
      this.radioStadiumGuiSunset.TabIndex = 9;
      this.radioStadiumGuiSunset.TabStop = true;
      this.radioStadiumGuiSunset.Text = "Sunset";
      this.radioStadiumGuiSunset.UseVisualStyleBackColor = true;
      this.radioStadiumGuiSunset.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.radioStadiumGuiOvercast.AutoSize = true;
      this.radioStadiumGuiOvercast.Checked = true;
      this.radioStadiumGuiOvercast.ImeMode = ImeMode.NoControl;
      this.radioStadiumGuiOvercast.Location = new Point(7, 14);
      this.radioStadiumGuiOvercast.Name = "radioStadiumGuiOvercast";
      this.radioStadiumGuiOvercast.Size = new Size(90, 17);
      this.radioStadiumGuiOvercast.TabIndex = 6;
      this.radioStadiumGuiOvercast.TabStop = true;
      this.radioStadiumGuiOvercast.Text = "Overcast Day";
      this.radioStadiumGuiOvercast.UseVisualStyleBackColor = true;
      this.radioStadiumGuiOvercast.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.radioStadiumGuiClearDay.AutoSize = true;
      this.radioStadiumGuiClearDay.ImeMode = ImeMode.NoControl;
      this.radioStadiumGuiClearDay.Location = new Point(7, 30);
      this.radioStadiumGuiClearDay.Name = "radioStadiumGuiClearDay";
      this.radioStadiumGuiClearDay.Size = new Size(71, 17);
      this.radioStadiumGuiClearDay.TabIndex = 7;
      this.radioStadiumGuiClearDay.TabStop = true;
      this.radioStadiumGuiClearDay.Text = "Clear Day";
      this.radioStadiumGuiClearDay.UseVisualStyleBackColor = true;
      this.radioStadiumGuiClearDay.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.radioStadium3D.AutoSize = true;
      this.radioStadium3D.ImeMode = ImeMode.NoControl;
      this.radioStadium3D.Location = new Point(7, 37);
      this.radioStadium3D.Name = "radioStadium3D";
      this.radioStadium3D.Size = new Size(83, 17);
      this.radioStadium3D.TabIndex = 8;
      this.radioStadium3D.TabStop = true;
      this.radioStadium3D.Text = "3D Textures";
      this.radioStadium3D.UseVisualStyleBackColor = true;
      this.radioStadium3D.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.groupShoes.Controls.Add((Control) this.radioShoesColor);
      this.groupShoes.Location = new Point(5, 5);
      this.groupShoes.Name = "groupShoes";
      this.groupShoes.Size = new Size(240, 90);
      this.groupShoes.TabIndex = 52;
      this.groupShoes.TabStop = false;
      this.groupShoes.Text = "Shoes";
      this.groupShoes.Visible = false;
      this.radioShoesColor.AutoSize = true;
      this.radioShoesColor.Checked = true;
      this.radioShoesColor.ImeMode = ImeMode.NoControl;
      this.radioShoesColor.Location = new Point(6, 19);
      this.radioShoesColor.Name = "radioShoesColor";
      this.radioShoesColor.Size = new Size(93, 17);
      this.radioShoesColor.TabIndex = 9;
      this.radioShoesColor.TabStop = true;
      this.radioShoesColor.Text = "Color Textures";
      this.radioShoesColor.UseVisualStyleBackColor = true;
      this.radioShoesColor.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.groupBall.Controls.Add((Control) this.radioBallPreview);
      this.groupBall.Controls.Add((Control) this.radioBallTexture);
      this.groupBall.Location = new Point(5, 5);
      this.groupBall.Name = "groupBall";
      this.groupBall.Size = new Size(240, 90);
      this.groupBall.TabIndex = 47;
      this.groupBall.TabStop = false;
      this.groupBall.Text = "Ball";
      this.groupBall.Visible = false;
      this.radioBallPreview.AutoSize = true;
      this.radioBallPreview.ImeMode = ImeMode.NoControl;
      this.radioBallPreview.Location = new Point(6, 42);
      this.radioBallPreview.Name = "radioBallPreview";
      this.radioBallPreview.Size = new Size(63, 17);
      this.radioBallPreview.TabIndex = 4;
      this.radioBallPreview.TabStop = true;
      this.radioBallPreview.Text = "Preview";
      this.radioBallPreview.UseVisualStyleBackColor = true;
      this.radioBallPreview.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.radioBallTexture.AutoSize = true;
      this.radioBallTexture.Checked = true;
      this.radioBallTexture.ImeMode = ImeMode.NoControl;
      this.radioBallTexture.Location = new Point(6, 19);
      this.radioBallTexture.Name = "radioBallTexture";
      this.radioBallTexture.Size = new Size(66, 17);
      this.radioBallTexture.TabIndex = 3;
      this.radioBallTexture.TabStop = true;
      this.radioBallTexture.Text = "Textures";
      this.radioBallTexture.UseVisualStyleBackColor = true;
      this.radioBallTexture.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.groupCountry.Controls.Add((Control) this.radioCountryMap);
      this.groupCountry.Controls.Add((Control) this.radioCountryFlag512x512);
      this.groupCountry.Controls.Add((Control) this.radioCountryCard);
      this.groupCountry.Controls.Add((Control) this.radioCountryMainFlag);
      this.groupCountry.Controls.Add((Control) this.radioCountryMiniflag);
      this.groupCountry.Location = new Point(5, 5);
      this.groupCountry.Name = "groupCountry";
      this.groupCountry.Size = new Size(240, 90);
      this.groupCountry.TabIndex = 48;
      this.groupCountry.TabStop = false;
      this.groupCountry.Text = "Country";
      this.groupCountry.Visible = false;
      this.radioCountryMap.AutoSize = true;
      this.radioCountryMap.ImeMode = ImeMode.NoControl;
      this.radioCountryMap.Location = new Point(100, 47);
      this.radioCountryMap.Name = "radioCountryMap";
      this.radioCountryMap.Size = new Size(46, 17);
      this.radioCountryMap.TabIndex = 7;
      this.radioCountryMap.Text = "Map";
      this.radioCountryMap.UseVisualStyleBackColor = false;
      this.radioCountryMap.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.radioCountryFlag512x512.AutoSize = true;
      this.radioCountryFlag512x512.ImeMode = ImeMode.NoControl;
      this.radioCountryFlag512x512.Location = new Point(99, 22);
      this.radioCountryFlag512x512.Name = "radioCountryFlag512x512";
      this.radioCountryFlag512x512.Size = new Size(95, 17);
      this.radioCountryFlag512x512.TabIndex = 6;
      this.radioCountryFlag512x512.Text = "Flag 512 x 512";
      this.radioCountryFlag512x512.UseVisualStyleBackColor = false;
      this.radioCountryFlag512x512.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.radioCountryCard.AutoSize = true;
      this.radioCountryCard.ImeMode = ImeMode.NoControl;
      this.radioCountryCard.Location = new Point(6, 68);
      this.radioCountryCard.Name = "radioCountryCard";
      this.radioCountryCard.Size = new Size(47, 17);
      this.radioCountryCard.TabIndex = 5;
      this.radioCountryCard.Text = "Card";
      this.radioCountryCard.UseVisualStyleBackColor = true;
      this.radioCountryCard.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.radioCountryMainFlag.AutoSize = true;
      this.radioCountryMainFlag.Checked = true;
      this.radioCountryMainFlag.ImeMode = ImeMode.NoControl;
      this.radioCountryMainFlag.Location = new Point(6, 22);
      this.radioCountryMainFlag.Name = "radioCountryMainFlag";
      this.radioCountryMainFlag.Size = new Size(71, 17);
      this.radioCountryMainFlag.TabIndex = 4;
      this.radioCountryMainFlag.TabStop = true;
      this.radioCountryMainFlag.Text = "Main Flag";
      this.radioCountryMainFlag.UseVisualStyleBackColor = false;
      this.radioCountryMainFlag.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.radioCountryMiniflag.AutoSize = true;
      this.radioCountryMiniflag.ImeMode = ImeMode.NoControl;
      this.radioCountryMiniflag.Location = new Point(6, 45);
      this.radioCountryMiniflag.Name = "radioCountryMiniflag";
      this.radioCountryMiniflag.Size = new Size(61, 17);
      this.radioCountryMiniflag.TabIndex = 2;
      this.radioCountryMiniflag.Text = "Miniflag";
      this.radioCountryMiniflag.UseVisualStyleBackColor = true;
      this.radioCountryMiniflag.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.groupAdboards.Controls.Add((Control) this.radioAdboard1);
      this.groupAdboards.Location = new Point(5, 5);
      this.groupAdboards.Name = "groupAdboards";
      this.groupAdboards.Size = new Size(240, 90);
      this.groupAdboards.TabIndex = 46;
      this.groupAdboards.TabStop = false;
      this.groupAdboards.Text = "Adboards";
      this.groupAdboards.Visible = false;
      this.radioAdboard1.AutoSize = true;
      this.radioAdboard1.Checked = true;
      this.radioAdboard1.ImeMode = ImeMode.NoControl;
      this.radioAdboard1.Location = new Point(6, 19);
      this.radioAdboard1.Name = "radioAdboard1";
      this.radioAdboard1.Size = new Size(61, 17);
      this.radioAdboard1.TabIndex = 9;
      this.radioAdboard1.TabStop = true;
      this.radioAdboard1.Text = "Texture";
      this.radioAdboard1.UseVisualStyleBackColor = true;
      this.radioAdboard1.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.groupKit.Controls.Add((Control) this.radioKitKit);
      this.groupKit.Controls.Add((Control) this.radioKitMinikit);
      this.groupKit.Location = new Point(5, 5);
      this.groupKit.Name = "groupKit";
      this.groupKit.Size = new Size(240, 90);
      this.groupKit.TabIndex = 51;
      this.groupKit.TabStop = false;
      this.groupKit.Text = "Kit";
      this.groupKit.Visible = false;
      this.radioKitKit.AutoSize = true;
      this.radioKitKit.Checked = true;
      this.radioKitKit.ImeMode = ImeMode.NoControl;
      this.radioKitKit.Location = new Point(6, 22);
      this.radioKitKit.Name = "radioKitKit";
      this.radioKitKit.Size = new Size(81, 17);
      this.radioKitKit.TabIndex = 4;
      this.radioKitKit.TabStop = true;
      this.radioKitKit.Text = "Kit Textures";
      this.radioKitKit.UseVisualStyleBackColor = false;
      this.radioKitKit.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.radioKitMinikit.AutoSize = true;
      this.radioKitMinikit.ImeMode = ImeMode.NoControl;
      this.radioKitMinikit.Location = new Point(6, 45);
      this.radioKitMinikit.Name = "radioKitMinikit";
      this.radioKitMinikit.Size = new Size(55, 17);
      this.radioKitMinikit.TabIndex = 2;
      this.radioKitMinikit.TabStop = true;
      this.radioKitMinikit.Text = "Minikit";
      this.radioKitMinikit.UseVisualStyleBackColor = true;
      this.radioKitMinikit.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.groupPlayer.Controls.Add((Control) this.radioHairTextures);
      this.groupPlayer.Controls.Add((Control) this.radioHairColorTexture);
      this.groupPlayer.Controls.Add((Control) this.radioEyesTexture);
      this.groupPlayer.Controls.Add((Control) this.radioFaceTexture);
      this.groupPlayer.Controls.Add((Control) this.radioMiniHead);
      this.groupPlayer.Location = new Point(5, 5);
      this.groupPlayer.Name = "groupPlayer";
      this.groupPlayer.Size = new Size(240, 90);
      this.groupPlayer.TabIndex = 50;
      this.groupPlayer.TabStop = false;
      this.groupPlayer.Text = "Player";
      this.groupPlayer.Visible = false;
      this.radioHairTextures.AutoSize = true;
      this.radioHairTextures.ImeMode = ImeMode.NoControl;
      this.radioHairTextures.Location = new Point(116, 44);
      this.radioHairTextures.Name = "radioHairTextures";
      this.radioHairTextures.Size = new Size(83, 17);
      this.radioHairTextures.TabIndex = 52;
      this.radioHairTextures.TabStop = true;
      this.radioHairTextures.Text = "Hair Texture";
      this.radioHairTextures.UseVisualStyleBackColor = true;
      this.radioHairTextures.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.radioHairColorTexture.AutoSize = true;
      this.radioHairColorTexture.ImeMode = ImeMode.NoControl;
      this.radioHairColorTexture.Location = new Point(116, 24);
      this.radioHairColorTexture.Name = "radioHairColorTexture";
      this.radioHairColorTexture.Size = new Size(110, 17);
      this.radioHairColorTexture.TabIndex = 51;
      this.radioHairColorTexture.TabStop = true;
      this.radioHairColorTexture.Text = "Hair Color Texture";
      this.radioHairColorTexture.UseVisualStyleBackColor = true;
      this.radioHairColorTexture.Visible = false;
      this.radioHairColorTexture.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.radioEyesTexture.AutoSize = true;
      this.radioEyesTexture.ImeMode = ImeMode.NoControl;
      this.radioEyesTexture.Location = new Point(12, 62);
      this.radioEyesTexture.Name = "radioEyesTexture";
      this.radioEyesTexture.Size = new Size(87, 17);
      this.radioEyesTexture.TabIndex = 2;
      this.radioEyesTexture.TabStop = true;
      this.radioEyesTexture.Text = "Eyes Texture";
      this.radioEyesTexture.UseVisualStyleBackColor = true;
      this.radioEyesTexture.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.radioFaceTexture.AutoSize = true;
      this.radioFaceTexture.ImeMode = ImeMode.NoControl;
      this.radioFaceTexture.Location = new Point(12, 42);
      this.radioFaceTexture.Name = "radioFaceTexture";
      this.radioFaceTexture.Size = new Size(88, 17);
      this.radioFaceTexture.TabIndex = 1;
      this.radioFaceTexture.TabStop = true;
      this.radioFaceTexture.Text = "Face Texture";
      this.radioFaceTexture.UseVisualStyleBackColor = true;
      this.radioFaceTexture.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.radioMiniHead.AutoSize = true;
      this.radioMiniHead.Checked = true;
      this.radioMiniHead.ImeMode = ImeMode.NoControl;
      this.radioMiniHead.Location = new Point(12, 20);
      this.radioMiniHead.Name = "radioMiniHead";
      this.radioMiniHead.Size = new Size(73, 17);
      this.radioMiniHead.TabIndex = 0;
      this.radioMiniHead.TabStop = true;
      this.radioMiniHead.Text = "Mini Head";
      this.radioMiniHead.UseVisualStyleBackColor = true;
      this.radioMiniHead.CheckedChanged += new EventHandler(this.radioViewer_CheckedChanged);
      this.pictureBox1.ImeMode = ImeMode.NoControl;
      this.pictureBox1.Location = new Point(-267, 197);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(267, 236);
      this.pictureBox1.TabIndex = 38;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Visible = false;
      this.groupReplaceSelection.BackColor = SystemColors.Control;
      this.groupReplaceSelection.Controls.Add((Control) this.comboReplaceLicensedTournament);
      this.groupReplaceSelection.Controls.Add((Control) this.comboReplaceKit);
      this.groupReplaceSelection.Controls.Add((Control) this.labelCmsCreated);
      this.groupReplaceSelection.Controls.Add((Control) this.labelCmsReplaced);
      this.groupReplaceSelection.Controls.Add((Control) this.textCmsReplaced);
      this.groupReplaceSelection.Controls.Add((Control) this.comboReplaceMowingPattern);
      this.groupReplaceSelection.Controls.Add((Control) this.radioCmsItem);
      this.groupReplaceSelection.Controls.Add((Control) this.comboReplaceGkGloves);
      this.groupReplaceSelection.Controls.Add((Control) this.comboReplaceNet);
      this.groupReplaceSelection.Controls.Add((Control) this.comboReplaceShoes);
      this.groupReplaceSelection.Controls.Add((Control) this.comboReplaceNamesFont);
      this.groupReplaceSelection.Controls.Add((Control) this.comboReplaceNumberFont);
      this.groupReplaceSelection.Controls.Add((Control) this.comboReplaceAdboard);
      this.groupReplaceSelection.Controls.Add((Control) this.comboReplaceBall);
      this.groupReplaceSelection.Controls.Add((Control) this.comboReplaceReferee);
      this.groupReplaceSelection.Controls.Add((Control) this.comboReplaceSponsor);
      this.groupReplaceSelection.Controls.Add((Control) this.comboReplaceFormation);
      this.groupReplaceSelection.Controls.Add((Control) this.comboReplaceTournament);
      this.groupReplaceSelection.Controls.Add((Control) this.comboReplaceStadium);
      this.groupReplaceSelection.Controls.Add((Control) this.comboReplaceCountry);
      this.groupReplaceSelection.Controls.Add((Control) this.comboReplaceLeague);
      this.groupReplaceSelection.Controls.Add((Control) this.comboReplacePlayer);
      this.groupReplaceSelection.Controls.Add((Control) this.comboReplaceTeam);
      this.groupReplaceSelection.Controls.Add((Control) this.radioReplaceItem);
      this.groupReplaceSelection.Controls.Add((Control) this.radioCreateItem);
      this.groupReplaceSelection.Dock = DockStyle.Top;
      this.groupReplaceSelection.Location = new Point(0, 15);
      this.groupReplaceSelection.Name = "groupReplaceSelection";
      this.groupReplaceSelection.Size = new Size(385, 111);
      this.groupReplaceSelection.TabIndex = 37;
      this.groupReplaceSelection.TabStop = false;
      this.groupReplaceSelection.Text = "Replace Selection";
      this.comboReplaceLicensedTournament.FormattingEnabled = true;
      this.comboReplaceLicensedTournament.Location = new Point(82, 39);
      this.comboReplaceLicensedTournament.MaxDropDownItems = 20;
      this.comboReplaceLicensedTournament.Name = "comboReplaceLicensedTournament";
      this.comboReplaceLicensedTournament.Size = new Size(178, 21);
      this.comboReplaceLicensedTournament.TabIndex = 42;
      this.comboReplaceLicensedTournament.Visible = false;
      this.comboReplaceLicensedTournament.SelectedIndexChanged += new EventHandler(this.comboReplace_SelectedIndexChanged);
      this.comboReplaceKit.FormattingEnabled = true;
      this.comboReplaceKit.Location = new Point(82, 39);
      this.comboReplaceKit.MaxDropDownItems = 20;
      this.comboReplaceKit.Name = "comboReplaceKit";
      this.comboReplaceKit.Size = new Size(178, 21);
      this.comboReplaceKit.TabIndex = 41;
      this.comboReplaceKit.Visible = false;
      this.comboReplaceKit.SelectedIndexChanged += new EventHandler(this.comboReplace_SelectedIndexChanged);
      this.labelCmsCreated.AutoSize = true;
      this.labelCmsCreated.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
      this.labelCmsCreated.ForeColor = Color.Green;
      this.labelCmsCreated.ImeMode = ImeMode.NoControl;
      this.labelCmsCreated.Location = new Point(14, 87);
      this.labelCmsCreated.Name = "labelCmsCreated";
      this.labelCmsCreated.Size = new Size(44, 13);
      this.labelCmsCreated.TabIndex = 40;
      this.labelCmsCreated.Text = "Create";
      this.labelCmsCreated.Visible = false;
      this.labelCmsReplaced.AutoSize = true;
      this.labelCmsReplaced.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
      this.labelCmsReplaced.ForeColor = Color.Red;
      this.labelCmsReplaced.ImeMode = ImeMode.NoControl;
      this.labelCmsReplaced.Location = new Point(14, 87);
      this.labelCmsReplaced.Name = "labelCmsReplaced";
      this.labelCmsReplaced.Size = new Size(54, 13);
      this.labelCmsReplaced.TabIndex = 22;
      this.labelCmsReplaced.Text = "Replace";
      this.labelCmsReplaced.Visible = false;
      this.textCmsReplaced.BackColor = Color.White;
      this.textCmsReplaced.Location = new Point(81, 84);
      this.textCmsReplaced.Name = "textCmsReplaced";
      this.textCmsReplaced.ReadOnly = true;
      this.textCmsReplaced.Size = new Size(178, 20);
      this.textCmsReplaced.TabIndex = 21;
      this.textCmsReplaced.Visible = false;
      this.comboReplaceMowingPattern.FormattingEnabled = true;
      this.comboReplaceMowingPattern.Location = new Point(81, 39);
      this.comboReplaceMowingPattern.MaxDropDownItems = 20;
      this.comboReplaceMowingPattern.Name = "comboReplaceMowingPattern";
      this.comboReplaceMowingPattern.Size = new Size(178, 21);
      this.comboReplaceMowingPattern.TabIndex = 20;
      this.comboReplaceMowingPattern.Visible = false;
      this.comboReplaceMowingPattern.SelectedIndexChanged += new EventHandler(this.comboReplace_SelectedIndexChanged);
      this.radioCmsItem.AutoSize = true;
      this.radioCmsItem.ImeMode = ImeMode.NoControl;
      this.radioCmsItem.Location = new Point(10, 64);
      this.radioCmsItem.Name = "radioCmsItem";
      this.radioCmsItem.Size = new Size(87, 17);
      this.radioCmsItem.TabIndex = 19;
      this.radioCmsItem.TabStop = true;
      this.radioCmsItem.Text = "Use Patch Id";
      this.radioCmsItem.UseVisualStyleBackColor = true;
      this.radioCmsItem.CheckedChanged += new EventHandler(this.radioUsePatchItem_CheckedChanged);
      this.comboReplaceGkGloves.FormattingEnabled = true;
      this.comboReplaceGkGloves.Location = new Point(81, 39);
      this.comboReplaceGkGloves.MaxDropDownItems = 20;
      this.comboReplaceGkGloves.Name = "comboReplaceGkGloves";
      this.comboReplaceGkGloves.Size = new Size(178, 21);
      this.comboReplaceGkGloves.TabIndex = 18;
      this.comboReplaceGkGloves.Visible = false;
      this.comboReplaceGkGloves.SelectedIndexChanged += new EventHandler(this.comboReplace_SelectedIndexChanged);
      this.comboReplaceNet.FormattingEnabled = true;
      this.comboReplaceNet.Location = new Point(81, 39);
      this.comboReplaceNet.MaxDropDownItems = 20;
      this.comboReplaceNet.Name = "comboReplaceNet";
      this.comboReplaceNet.Size = new Size(178, 21);
      this.comboReplaceNet.TabIndex = 17;
      this.comboReplaceNet.Visible = false;
      this.comboReplaceNet.SelectedIndexChanged += new EventHandler(this.comboReplace_SelectedIndexChanged);
      this.comboReplaceShoes.FormattingEnabled = true;
      this.comboReplaceShoes.Location = new Point(81, 39);
      this.comboReplaceShoes.MaxDropDownItems = 20;
      this.comboReplaceShoes.Name = "comboReplaceShoes";
      this.comboReplaceShoes.Size = new Size(178, 21);
      this.comboReplaceShoes.TabIndex = 16;
      this.comboReplaceShoes.Visible = false;
      this.comboReplaceShoes.SelectedIndexChanged += new EventHandler(this.comboReplace_SelectedIndexChanged);
      this.comboReplaceNamesFont.FormattingEnabled = true;
      this.comboReplaceNamesFont.Location = new Point(81, 39);
      this.comboReplaceNamesFont.MaxDropDownItems = 20;
      this.comboReplaceNamesFont.Name = "comboReplaceNamesFont";
      this.comboReplaceNamesFont.Size = new Size(178, 21);
      this.comboReplaceNamesFont.TabIndex = 15;
      this.comboReplaceNamesFont.Visible = false;
      this.comboReplaceNamesFont.SelectedIndexChanged += new EventHandler(this.comboReplace_SelectedIndexChanged);
      this.comboReplaceNumberFont.FormattingEnabled = true;
      this.comboReplaceNumberFont.Location = new Point(81, 39);
      this.comboReplaceNumberFont.MaxDropDownItems = 20;
      this.comboReplaceNumberFont.Name = "comboReplaceNumberFont";
      this.comboReplaceNumberFont.Size = new Size(178, 21);
      this.comboReplaceNumberFont.TabIndex = 14;
      this.comboReplaceNumberFont.Visible = false;
      this.comboReplaceNumberFont.SelectedIndexChanged += new EventHandler(this.comboReplace_SelectedIndexChanged);
      this.comboReplaceAdboard.FormattingEnabled = true;
      this.comboReplaceAdboard.Location = new Point(81, 39);
      this.comboReplaceAdboard.MaxDropDownItems = 20;
      this.comboReplaceAdboard.Name = "comboReplaceAdboard";
      this.comboReplaceAdboard.Size = new Size(178, 21);
      this.comboReplaceAdboard.TabIndex = 13;
      this.comboReplaceAdboard.Visible = false;
      this.comboReplaceAdboard.SelectedIndexChanged += new EventHandler(this.comboReplace_SelectedIndexChanged);
      this.comboReplaceBall.FormattingEnabled = true;
      this.comboReplaceBall.Location = new Point(81, 39);
      this.comboReplaceBall.MaxDropDownItems = 20;
      this.comboReplaceBall.Name = "comboReplaceBall";
      this.comboReplaceBall.Size = new Size(178, 21);
      this.comboReplaceBall.TabIndex = 12;
      this.comboReplaceBall.Visible = false;
      this.comboReplaceBall.SelectedIndexChanged += new EventHandler(this.comboReplace_SelectedIndexChanged);
      this.comboReplaceReferee.FormattingEnabled = true;
      this.comboReplaceReferee.Location = new Point(81, 39);
      this.comboReplaceReferee.MaxDropDownItems = 20;
      this.comboReplaceReferee.Name = "comboReplaceReferee";
      this.comboReplaceReferee.Size = new Size(178, 21);
      this.comboReplaceReferee.TabIndex = 11;
      this.comboReplaceReferee.Visible = false;
      this.comboReplaceReferee.SelectedIndexChanged += new EventHandler(this.comboReplace_SelectedIndexChanged);
      this.comboReplaceSponsor.FormattingEnabled = true;
      this.comboReplaceSponsor.Location = new Point(81, 39);
      this.comboReplaceSponsor.MaxDropDownItems = 20;
      this.comboReplaceSponsor.Name = "comboReplaceSponsor";
      this.comboReplaceSponsor.Size = new Size(178, 21);
      this.comboReplaceSponsor.TabIndex = 10;
      this.comboReplaceSponsor.Visible = false;
      this.comboReplaceSponsor.SelectedIndexChanged += new EventHandler(this.comboReplace_SelectedIndexChanged);
      this.comboReplaceFormation.FormattingEnabled = true;
      this.comboReplaceFormation.Location = new Point(81, 39);
      this.comboReplaceFormation.MaxDropDownItems = 20;
      this.comboReplaceFormation.Name = "comboReplaceFormation";
      this.comboReplaceFormation.Size = new Size(178, 21);
      this.comboReplaceFormation.TabIndex = 9;
      this.comboReplaceFormation.Visible = false;
      this.comboReplaceFormation.SelectedIndexChanged += new EventHandler(this.comboReplace_SelectedIndexChanged);
      this.comboReplaceTournament.FormattingEnabled = true;
      this.comboReplaceTournament.Location = new Point(81, 39);
      this.comboReplaceTournament.MaxDropDownItems = 20;
      this.comboReplaceTournament.Name = "comboReplaceTournament";
      this.comboReplaceTournament.Size = new Size(178, 21);
      this.comboReplaceTournament.TabIndex = 8;
      this.comboReplaceTournament.Visible = false;
      this.comboReplaceTournament.SelectedIndexChanged += new EventHandler(this.comboReplace_SelectedIndexChanged);
      this.comboReplaceStadium.FormattingEnabled = true;
      this.comboReplaceStadium.Location = new Point(81, 39);
      this.comboReplaceStadium.MaxDropDownItems = 20;
      this.comboReplaceStadium.Name = "comboReplaceStadium";
      this.comboReplaceStadium.Size = new Size(178, 21);
      this.comboReplaceStadium.TabIndex = 7;
      this.comboReplaceStadium.Visible = false;
      this.comboReplaceStadium.SelectedIndexChanged += new EventHandler(this.comboReplace_SelectedIndexChanged);
      this.comboReplaceCountry.FormattingEnabled = true;
      this.comboReplaceCountry.Location = new Point(81, 39);
      this.comboReplaceCountry.MaxDropDownItems = 20;
      this.comboReplaceCountry.Name = "comboReplaceCountry";
      this.comboReplaceCountry.Size = new Size(178, 21);
      this.comboReplaceCountry.TabIndex = 6;
      this.comboReplaceCountry.Visible = false;
      this.comboReplaceCountry.SelectedIndexChanged += new EventHandler(this.comboReplace_SelectedIndexChanged);
      this.comboReplaceLeague.FormattingEnabled = true;
      this.comboReplaceLeague.Location = new Point(81, 39);
      this.comboReplaceLeague.Name = "comboReplaceLeague";
      this.comboReplaceLeague.Size = new Size(178, 21);
      this.comboReplaceLeague.TabIndex = 5;
      this.comboReplaceLeague.Visible = false;
      this.comboReplaceLeague.SelectedIndexChanged += new EventHandler(this.comboReplace_SelectedIndexChanged);
      this.comboReplacePlayer.FormattingEnabled = true;
      this.comboReplacePlayer.Location = new Point(81, 39);
      this.comboReplacePlayer.MaxDropDownItems = 20;
      this.comboReplacePlayer.Name = "comboReplacePlayer";
      this.comboReplacePlayer.Size = new Size(178, 21);
      this.comboReplacePlayer.TabIndex = 4;
      this.comboReplacePlayer.Visible = false;
      this.comboReplacePlayer.SelectedIndexChanged += new EventHandler(this.comboReplace_SelectedIndexChanged);
      this.comboReplaceTeam.FormattingEnabled = true;
      this.comboReplaceTeam.Location = new Point(81, 39);
      this.comboReplaceTeam.MaxDropDownItems = 20;
      this.comboReplaceTeam.Name = "comboReplaceTeam";
      this.comboReplaceTeam.Size = new Size(178, 21);
      this.comboReplaceTeam.TabIndex = 3;
      this.comboReplaceTeam.Visible = false;
      this.comboReplaceTeam.SelectedIndexChanged += new EventHandler(this.comboReplace_SelectedIndexChanged);
      this.radioReplaceItem.AutoSize = true;
      this.radioReplaceItem.ImeMode = ImeMode.NoControl;
      this.radioReplaceItem.Location = new Point(10, 39);
      this.radioReplaceItem.Name = "radioReplaceItem";
      this.radioReplaceItem.Size = new Size(65, 17);
      this.radioReplaceItem.TabIndex = 1;
      this.radioReplaceItem.TabStop = true;
      this.radioReplaceItem.Text = "Replace";
      this.radioReplaceItem.UseVisualStyleBackColor = true;
      this.radioReplaceItem.CheckedChanged += new EventHandler(this.radioReplaceItem_CheckedChanged);
      this.radioCreateItem.AutoSize = true;
      this.radioCreateItem.ImeMode = ImeMode.NoControl;
      this.radioCreateItem.Location = new Point(10, 16);
      this.radioCreateItem.Name = "radioCreateItem";
      this.radioCreateItem.Size = new Size(56, 17);
      this.radioCreateItem.TabIndex = 0;
      this.radioCreateItem.TabStop = true;
      this.radioCreateItem.Text = "Create";
      this.radioCreateItem.UseVisualStyleBackColor = true;
      this.radioCreateItem.CheckedChanged += new EventHandler(this.radioCreateItem_CheckedChanged);
      this.labelDetails.Dock = DockStyle.Top;
      this.labelDetails.ImeMode = ImeMode.NoControl;
      this.labelDetails.Location = new Point(0, 0);
      this.labelDetails.Name = "labelDetails";
      this.labelDetails.Size = new Size(385, 15);
      this.labelDetails.TabIndex = 41;
      this.labelDetails.Text = "Details";
      this.labelDetails.TextAlign = ContentAlignment.BottomCenter;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1157, 746);
      this.Controls.Add((Control) this.splitContainer1);
      this.Controls.Add((Control) this.panelLeft);
      this.Controls.Add((Control) this.toolMain);
      this.Controls.Add((Control) this.mainMenu);
      this.Controls.Add((Control) this.statusBar);
      this.Icon = (Icon) resources.GetObject("$this.Icon");
      this.MainMenuStrip = this.mainMenu;
      this.Name = "PatchLoaderForm";
      this.Text = " CM-Patch Loader";
      this.Load += new EventHandler(this.PatchLoaderForm_Load);
      this.mainMenu.ResumeLayout(false);
      this.mainMenu.PerformLayout();
      this.toolMain.ResumeLayout(false);
      this.toolMain.PerformLayout();
      this.panelLeft.ResumeLayout(false);
      this.panelLeft.PerformLayout();
      this.groupPatchOptions.ResumeLayout(false);
      this.tabPatchOptions.ResumeLayout(false);
      this.pagePlayerOptions.ResumeLayout(false);
      this.pagePlayerOptions.PerformLayout();
      this.groupDualClub.ResumeLayout(false);
      this.groupDualClub.PerformLayout();
      this.pageTeamOptions.ResumeLayout(false);
      this.pageTeamOptions.PerformLayout();
      this.pageLeagueOptions.ResumeLayout(false);
      this.pageLeagueOptions.PerformLayout();
      this.pageStadiumOptions.ResumeLayout(false);
      this.pageStadiumOptions.PerformLayout();
      this.pageKitOptions.ResumeLayout(false);
      this.pageKitOptions.PerformLayout();
      this.pageCountryOptions.ResumeLayout(false);
      this.pageCountryOptions.PerformLayout();
      this.statusBar.ResumeLayout(false);
      this.statusBar.PerformLayout();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.panelRight.ResumeLayout(false);
      this.tabPreview.ResumeLayout(false);
      this.pageViewer2D.ResumeLayout(false);
      this.pageMultiViewer2D.ResumeLayout(false);
      this.panelGraphicGroups.ResumeLayout(false);
      this.groupTeam.ResumeLayout(false);
      this.groupTeam.PerformLayout();
      this.groupLeague.ResumeLayout(false);
      this.groupLeague.PerformLayout();
      this.groupStadium.ResumeLayout(false);
      this.groupStadium.PerformLayout();
      this.groupTod.ResumeLayout(false);
      this.groupTod.PerformLayout();
      this.groupShoes.ResumeLayout(false);
      this.groupShoes.PerformLayout();
      this.groupBall.ResumeLayout(false);
      this.groupBall.PerformLayout();
      this.groupCountry.ResumeLayout(false);
      this.groupCountry.PerformLayout();
      this.groupAdboards.ResumeLayout(false);
      this.groupAdboards.PerformLayout();
      this.groupKit.ResumeLayout(false);
      this.groupKit.PerformLayout();
      this.groupPlayer.ResumeLayout(false);
      this.groupPlayer.PerformLayout();
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.groupReplaceSelection.ResumeLayout(false);
      this.groupReplaceSelection.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public int PatchYear
    {
      get
      {
        return this.m_PatchYear;
      }
    }

    public bool IsLastObjectCrossReferenced
    {
      get
      {
        return this.m_IsLastObjectCrossReferenced;
      }
    }

    public PatchLoaderForm()
    {
      this.InitializeComponent();
      this.m_FifaDataSet.Locale = CultureInfo.InvariantCulture;
      this.m_LangDataSet.Locale = CultureInfo.InvariantCulture;
      this.m_PatchDataSet.Locale = CultureInfo.InvariantCulture;
      this.InitPatchLoaderForm();
    }

    private void buttonLoadPatch_Click(object sender, EventArgs e)
    {
      this.OpenPatch();
    }

    private void OpenPatch()
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.CheckFileExists = true;
      openFileDialog.Title = "Open Creation Master Patch file";
      openFileDialog.Filter = "Creation Master Patch (*.cmp)|*.cmp";
      openFileDialog.FilterIndex = 1;
      openFileDialog.Multiselect = false;
      if (openFileDialog.ShowDialog() != DialogResult.OK)
      {
        openFileDialog.Dispose();
      }
      else
      {
        string fileName = openFileDialog.FileName;
        openFileDialog.Dispose();
        if (!File.Exists(fileName))
          return;
        this.Refresh();
        Cursor.Current = Cursors.WaitCursor;
        if (Directory.Exists(this.m_TempFolder))
          Directory.Delete(this.m_TempFolder, true);
        Directory.CreateDirectory(this.m_TempFolder);
        FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        ZipFile zipFile = new ZipFile(fileName);
        ZipInputStream zip = new ZipInputStream((Stream) fileStream);
        this.ZipExtractAllFiles(zip, this.m_TempFolder);
        zip.Close();
        bool flag = this.OpenCM12();
        this.buttonImportPatch.Enabled = flag;
        this.importToolStripMenuItem.Enabled = flag;
        Cursor.Current = Cursors.Default;
      }
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.OpenPatch();
    }

    private void ZipExtractSingleFile(ZipInputStream zip, ZipEntry zipEntry, string exportFolder)
    {
      string path = exportFolder + "\\" + Path.GetDirectoryName(zipEntry.Name);
      if (!(Path.GetFileName(zipEntry.Name) != string.Empty))
        return;
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);
      FileStream fileStream = File.Create(exportFolder + "\\" + zipEntry.Name);
      byte[] buffer = new byte[2048];
      while (true)
      {
        int count = zip.Read(buffer, 0, buffer.Length);
        if (count > 0)
          fileStream.Write(buffer, 0, count);
        else
          break;
      }
      fileStream.Close();
    }

    private void ZipExtractAllFiles(ZipInputStream zip, string exportFolder)
    {
      ZipEntry nextEntry;
      while ((nextEntry = zip.GetNextEntry()) != null)
        this.ZipExtractSingleFile(zip, nextEntry, exportFolder);
    }

    private void RemoveAllNewObjects()
    {
      foreach (ListViewItem listViewItem in this.listViewPatch.Items)
        ((PatchedObject) listViewItem.Tag).RemoveNewObject();
    }

    private void RemoveAllUnusedObjects()
    {
      foreach (ListViewItem listViewItem in this.listViewPatch.Items)
      {
        PatchedObject tag = (PatchedObject) listViewItem.Tag;
        if (!listViewItem.Checked)
          tag.RemoveNewObject();
        else
          tag.RemoveNewObjectIfUnused();
      }
    }

    private bool OpenCM12()
    {
      this.statusLabel.Text = "Loading...";
      this.statusBar.Refresh();
      this.m_FifaDataSet.Locale = CultureInfo.InvariantCulture;
      this.m_LangDataSet.Locale = CultureInfo.InvariantCulture;
      this.m_PatchDataSet.Locale = CultureInfo.InvariantCulture;
      this.m_PatchDataSet.Tables.Clear();
      this.m_FifaDataSet.Tables.Clear();
      this.m_LangDataSet.Tables.Clear();
      int num1 = (int) this.m_PatchDataSet.ReadXml(this.m_TempFolder + "\\Patch.xml");
      int num2 = (int) this.m_FifaDataSet.ReadXml(this.m_TempFolder + "\\fifa.xml");
      int num3 = (int) this.m_LangDataSet.ReadXml(this.m_TempFolder + "\\lang.xml");
      if (this.m_FifaDataSet.DataSetName != "FIFA14" && this.m_FifaDataSet.DataSetName != "FIFA15")
      {
        int num4 = (int) FifaEnvironment.UserMessages.ShowMessage(1032);
        return false;
      }
      if (this.m_FifaDataSet.DataSetName == "FIFA14")
        this.m_PatchYear = 14;
      else if (this.m_FifaDataSet.DataSetName == "FIFA15")
        this.m_PatchYear = 15;
      this.comboReplaceTeam.Items.Clear();
      this.comboReplaceTeam.Items.AddRange(FifaEnvironment.Teams.ToArray());
      this.comboReplaceTeam.Sorted = true;
      this.comboReplacePlayer.Items.Clear();
      this.comboReplacePlayer.Items.AddRange(FifaEnvironment.Players.ToArray());
      this.comboReplacePlayer.Sorted = true;
      this.comboReplaceLeague.Items.Clear();
      this.comboReplaceLeague.Items.AddRange(FifaEnvironment.Leagues.ToArray());
      this.comboReplaceLeague.Sorted = true;
      this.comboReplaceCountry.Items.Clear();
      this.comboReplaceCountry.Items.AddRange(FifaEnvironment.Countries.ToArray());
      this.comboReplaceCountry.Sorted = true;
      this.comboReplaceStadium.Items.Clear();
      this.comboReplaceStadium.Items.AddRange(FifaEnvironment.Stadiums.ToArray());
      this.comboReplaceStadium.Sorted = true;
      this.comboReplaceReferee.Items.Clear();
      this.comboReplaceReferee.Items.AddRange(FifaEnvironment.Referees.ToArray());
      this.comboReplaceReferee.Sorted = true;
      this.comboReplaceFormation.Items.Clear();
      this.comboReplaceFormation.Items.AddRange(FifaEnvironment.Formations.ToArray());
      this.comboReplaceBall.Items.Clear();
      this.comboReplaceBall.Items.AddRange(FifaEnvironment.Balls.ToArray());
      this.comboReplaceAdboard.Items.Clear();
      this.comboReplaceAdboard.Items.AddRange(FifaEnvironment.Adboards.ToArray());
      this.comboReplaceNumberFont.Items.Clear();
      this.comboReplaceNumberFont.Items.AddRange(FifaEnvironment.NumberFonts.ToArray());
      this.comboReplaceNamesFont.Items.Clear();
      this.comboReplaceNamesFont.Items.AddRange(FifaEnvironment.NameFonts.ToArray());
      this.comboReplaceShoes.Items.Clear();
      this.comboReplaceShoes.Items.AddRange(FifaEnvironment.Shoes.ToArray());
      this.comboReplaceNet.Items.Clear();
      this.comboReplaceNet.Items.AddRange(FifaEnvironment.Nets.ToArray());
      this.comboReplaceGkGloves.Items.Clear();
      this.comboReplaceGkGloves.Items.AddRange(FifaEnvironment.GkGloves.ToArray());
      this.comboReplaceMowingPattern.Items.Clear();
      this.comboReplaceMowingPattern.Items.AddRange(FifaEnvironment.MowingPatterns.ToArray());
      this.comboReplaceKit.Items.Clear();
      this.comboReplaceKit.Items.AddRange(FifaEnvironment.Kits.ToArray());
      this.labelDetails.Text = "Patch created for " + this.m_FifaDataSet.DataSetName;
      this.panelLeft.Enabled = true;
      this.panelRight.Enabled = true;
      this.textPatchName.Text = (string) this.m_PatchDataSet.Tables["PatchIdentity"].Rows[0].ItemArray[0];
      this.textPatchVersion.Text = (string) this.m_PatchDataSet.Tables["PatchIdentity"].Rows[0].ItemArray[1];
      this.textDescription.Text = (string) this.m_PatchDataSet.Tables["PatchIdentity"].Rows[0].ItemArray[2];
      string str = (string) this.m_PatchDataSet.Tables["PatchIdentity"].Rows[0].ItemArray[3];
      this.m_PatchDatabaseVersion = str == null || !(str != string.Empty) ? 0 : Convert.ToInt32(str);
      this.m_IsCmsPatch = this.m_PatchDataSet.Tables["PatchIdentity"].Rows[0].ItemArray.Length <= 4 || (string) this.m_PatchDataSet.Tables["PatchIdentity"].Rows[0].ItemArray[4] == "CMS 14";
      this.checkCMS.Checked = this.m_IsCmsPatch;
      this.listViewPatch.Items.Clear();
      foreach (DataRow row in (InternalDataCollectionBase) this.m_PatchDataSet.Tables["PatchElements"].Rows)
      {
        int length = row.ItemArray.Length;
        string[] items = new string[5]
        {
          null,
          null,
          null,
          null,
          (string) row.ItemArray[0]
        };
        items[3] = string.Empty;
        items[1] = (string) row.ItemArray[1];
        items[2] = (string) row.ItemArray[2];
        items[0] = (string) row.ItemArray[3];
        int int32 = Convert.ToInt32(items[2]);
        PatchedObject patchedObject = new PatchedObject(items[1], items[0], int32);
        patchedObject.AssignReplacedObject(this.m_IsCmsPatch);
        this.listViewPatch.Items.Add(new ListViewItem(items)
        {
          Tag = (object) patchedObject
        });
      }
      foreach (ListViewItem listViewItem in this.listViewPatch.Items)
        ((PatchedObject) listViewItem.Tag).AssignNewCmsObject(this.m_IsCmsPatch);
      foreach (ListViewItem owner in this.listViewPatch.Items)
      {
        PatchedObject tag = (PatchedObject) owner.Tag;
        tag.AssignNewObject(this.m_IsCmsPatch);
        owner.ForeColor = tag.GetColor();
        owner.Checked = owner.ForeColor == Color.Green;
        owner.SubItems[3] = new ListViewItem.ListViewSubItem(owner, tag.ImportId.ToString());
      }
      this.statusLabel.Text = "Ready";
      this.statusBar.Refresh();
      return true;
    }

    public bool IsItemChecked(string type, string name)
    {
      foreach (ListViewItem listViewItem in this.listViewPatch.Items)
      {
        PatchedObject tag = (PatchedObject) listViewItem.Tag;
        if (tag.GetObjectType() == type && tag.Name == name)
          return listViewItem.Checked;
      }
      return false;
    }

    private void InitPatchLoaderForm()
    {
      this.m_TempFolder = FifaEnvironment.TempFolder + "\\Patch";
      this.listViewPatch.Items.Clear();
      this.buttonImportPatch.Enabled = false;
      this.panelGraphicGroups.Visible = false;
      this.tabPreview.Visible = false;
      this.stripButtonPreview.Checked = false;
      this.labelDetails.Text = string.Empty;
      this.textPatchName.Text = string.Empty;
      this.textPatchVersion.Text = string.Empty;
      this.textDescription.Text = string.Empty;
      this.viewer2D.CurrentBitmap = (Bitmap) null;
      this.multiViewer2D.Bitmaps = (Bitmap[]) null;
    }

    public int CrossReference(string type, int id)
    {
      foreach (ListViewItem listViewItem in this.listViewPatch.Items)
      {
        PatchedObject tag = (PatchedObject) listViewItem.Tag;
        if (tag.Id == id && tag.GetObjectType() == type)
        {
          this.m_IsLastObjectCrossReferenced = true;
          return tag.ImportId;
        }
      }
      this.m_IsLastObjectCrossReferenced = false;
      return id;
    }

    private void listViewPatch_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.listViewPatch.SelectedItems.Count <= 0)
        return;
      this.m_CurrentPatchedObject = (PatchedObject) this.listViewPatch.SelectedItems[0].Tag;
      this.radioCreateItem.Checked = this.m_CurrentPatchedObject.IsUsedNewObject();
      this.radioReplaceItem.Checked = this.m_CurrentPatchedObject.IsUsedFittingObject();
      this.radioCmsItem.Checked = this.m_CurrentPatchedObject.IsUsedCmsObject();
      this.UpdateComboReplace(this.m_CurrentPatchedObject);
      this.UpdateTextCms(this.m_CurrentPatchedObject);
      this.SelectViewerRadio();
      this.Preview();
    }

    private void UpdateTextCms(PatchedObject patchedObject)
    {
      if (patchedObject.IsUsedCmsObject())
      {
        this.textCmsReplaced.Text = patchedObject.CmsObject.ToString();
        this.textCmsReplaced.Visible = !patchedObject.IsCmsNew;
        this.labelCmsCreated.Visible = patchedObject.IsCmsNew;
        this.labelCmsCreated.Text = "Create with id = " + (object) patchedObject.ImportId;
        this.labelCmsReplaced.Visible = !patchedObject.IsCmsNew;
      }
      else
      {
        this.textCmsReplaced.Visible = false;
        this.labelCmsCreated.Visible = false;
        this.labelCmsReplaced.Visible = false;
      }
    }

    private void UpdateComboReplace(PatchedObject patchedObject)
    {
      string type = patchedObject.Type;
      int id = patchedObject.Id;
      object replacedObject = patchedObject.ReplacedObject;
      if (this.comboReplacePlayer.Visible = type == "Player" && patchedObject.IsUsedFittingObject())
        this.comboReplacePlayer.SelectedItem = patchedObject.ReplacedObject;
      if (this.comboReplaceTeam.Visible = type == "Team" && patchedObject.IsUsedFittingObject())
        this.comboReplaceTeam.SelectedItem = patchedObject.ReplacedObject;
      if (this.comboReplaceLeague.Visible = type == "League" && patchedObject.IsUsedFittingObject())
        this.comboReplaceLeague.SelectedItem = patchedObject.ReplacedObject;
      if (this.comboReplaceCountry.Visible = type == "Country" && patchedObject.IsUsedFittingObject())
        this.comboReplaceCountry.SelectedItem = patchedObject.ReplacedObject;
      if (this.comboReplaceStadium.Visible = type == "Stadium" && patchedObject.IsUsedFittingObject())
        this.comboReplaceStadium.SelectedItem = patchedObject.ReplacedObject;
      if (this.comboReplaceReferee.Visible = type == "Referee" && patchedObject.IsUsedFittingObject())
        this.comboReplaceReferee.SelectedItem = patchedObject.ReplacedObject;
      if (this.comboReplaceFormation.Visible = type == "Formation" && patchedObject.IsUsedFittingObject())
        this.comboReplaceFormation.SelectedItem = patchedObject.ReplacedObject;
      if (this.comboReplaceSponsor.Visible = type == "Sponsor" && patchedObject.IsUsedFittingObject())
        this.comboReplaceSponsor.SelectedItem = patchedObject.ReplacedObject;
      if (this.comboReplaceBall.Visible = type == "Ball" && patchedObject.IsUsedFittingObject())
        this.comboReplaceBall.SelectedItem = patchedObject.ReplacedObject;
      if (this.comboReplaceAdboard.Visible = type == "Adboard" && patchedObject.IsUsedFittingObject())
        this.comboReplaceAdboard.SelectedItem = patchedObject.ReplacedObject;
      if (this.comboReplaceNumberFont.Visible = type == "NumberFont" && patchedObject.IsUsedFittingObject())
        this.comboReplaceNumberFont.SelectedItem = patchedObject.ReplacedObject;
      if (this.comboReplaceNamesFont.Visible = type == "NameFont" && patchedObject.IsUsedFittingObject())
        this.comboReplaceNamesFont.SelectedItem = patchedObject.ReplacedObject;
      if (this.comboReplaceShoes.Visible = type == "Shoes" && patchedObject.IsUsedFittingObject())
        this.comboReplaceShoes.SelectedItem = patchedObject.ReplacedObject;
      if (this.comboReplaceNet.Visible = type == "Net" && patchedObject.IsUsedFittingObject())
        this.comboReplaceNet.SelectedItem = patchedObject.ReplacedObject;
      if (this.comboReplaceGkGloves.Visible = type == "GkGloves" && patchedObject.IsUsedFittingObject())
        this.comboReplaceGkGloves.SelectedItem = patchedObject.ReplacedObject;
      if (this.comboReplaceMowingPattern.Visible = type == "MowingPattern" && patchedObject.IsUsedFittingObject())
        this.comboReplaceMowingPattern.SelectedItem = patchedObject.ReplacedObject;
      if (!(this.comboReplaceKit.Visible = type == "Kit" && patchedObject.IsUsedFittingObject()))
        return;
      this.comboReplaceKit.SelectedItem = patchedObject.ReplacedObject;
    }

    private void SelectViewerRadio()
    {
      string text = this.listViewPatch.SelectedItems[0].SubItems[1].Text;
      this.groupPlayer.Visible = text == "Player";
      this.groupTeam.Visible = text == "Team";
      this.groupLeague.Visible = text == "League";
      this.groupStadium.Visible = text == "Stadium";
      this.groupCountry.Visible = text == "Country";
      this.groupBall.Visible = text == "Ball";
      this.groupShoes.Visible = text == "Shoes";
      this.groupAdboards.Visible = text == "Adboard";
      this.groupKit.Visible = text == "Kit";
      if (!this.stripButtonPreview.Checked)
        return;
      this.Preview();
    }

    private void radioViewer_CheckedChanged(object sender, EventArgs e)
    {
      if (!((RadioButton) sender).Checked)
        return;
      this.Preview();
    }

    private void buttonSelectAll_Click(object sender, EventArgs e)
    {
      foreach (ListViewItem listViewItem in this.listViewPatch.Items)
        listViewItem.Checked = true;
    }

    private void buttonDeselectAll_Click(object sender, EventArgs e)
    {
      foreach (ListViewItem listViewItem in this.listViewPatch.Items)
        listViewItem.Checked = false;
    }

    private void radioCreateItem_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radioCreateItem.Checked || this.listViewPatch.SelectedItems.Count <= 0)
        return;
      ListViewItem selectedItem = this.listViewPatch.SelectedItems[0];
      PatchedObject tag = (PatchedObject) selectedItem.Tag;
      tag.UseNewObject();
      if (!tag.IsUsedNewObject())
      {
        this.radioCreateItem.Checked = false;
        this.radioCmsItem.Checked = false;
        this.radioReplaceItem.Checked = true;
      }
      selectedItem.ForeColor = tag.GetColor();
      selectedItem.SubItems[3] = new ListViewItem.ListViewSubItem(selectedItem, tag.ImportId.ToString());
      this.UpdateComboReplace(tag);
      this.UpdateTextCms(tag);
    }

    private void radioReplaceItem_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radioReplaceItem.Checked || this.listViewPatch.SelectedItems.Count <= 0)
        return;
      ListViewItem selectedItem = this.listViewPatch.SelectedItems[0];
      PatchedObject tag = (PatchedObject) selectedItem.Tag;
      tag.UseReplacedObject();
      selectedItem.ForeColor = tag.GetColor();
      selectedItem.SubItems[3] = new ListViewItem.ListViewSubItem(selectedItem, tag.ImportId.ToString());
      this.UpdateComboReplace(tag);
      this.UpdateTextCms(tag);
    }

    private void radioUsePatchItem_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radioCmsItem.Checked || this.listViewPatch.SelectedItems.Count <= 0)
        return;
      ListViewItem selectedItem = this.listViewPatch.SelectedItems[0];
      PatchedObject tag = (PatchedObject) selectedItem.Tag;
      tag.UsePatchId();
      selectedItem.ForeColor = tag.GetColor();
      selectedItem.SubItems[3] = new ListViewItem.ListViewSubItem(selectedItem, tag.ImportId.ToString());
      this.UpdateComboReplace(tag);
      this.UpdateTextCms(tag);
    }

    private void stripButtonPreview_Click(object sender, EventArgs e)
    {
      if (!this.stripButtonPreview.Checked)
      {
        this.tabPreview.Visible = false;
        this.panelGraphicGroups.Visible = false;
      }
      else
      {
        this.tabPreview.Visible = true;
        this.panelGraphicGroups.Visible = true;
        this.Preview();
      }
    }

    private void Preview()
    {
      if (!this.stripButtonPreview.Checked)
      {
        this.tabPreview.Visible = false;
      }
      else
      {
        if (this.listViewPatch.SelectedItems.Count <= 0)
          return;
        ListViewItem selectedItem = this.listViewPatch.SelectedItems[0];
        string text = selectedItem.SubItems[1].Text;
        int int32 = Convert.ToInt32(selectedItem.SubItems[2].Text);
        if (text == "Country")
        {
          if (this.radioCountryMainFlag.Checked)
          {
            string bigFileName = this.m_TempFolder + "\\" + Country.FlagBigFileName(int32);
            this.viewer2D.picture.BackgroundImageLayout = ImageLayout.Center;
            this.ShowBigFile(bigFileName);
          }
          else if (this.radioCountryMiniflag.Checked)
          {
            string bigFileName = this.m_TempFolder + "\\" + Country.MiniFlagBigFileName(int32);
            this.viewer2D.picture.BackgroundImageLayout = ImageLayout.Center;
            this.ShowBigFile(bigFileName);
          }
          else if (this.radioCountryFlag512x512.Checked)
          {
            string ddsFileName = this.m_TempFolder + "\\" + Country.Flag512DdsFileName(int32);
            this.viewer2D.picture.BackgroundImageLayout = ImageLayout.Center;
            this.ShowDdsFile(ddsFileName);
          }
          else
          {
            if (!this.radioCountryCard.Checked)
              return;
            string ddsFileName = this.m_TempFolder + "\\" + Country.ShapeFileName(int32);
            this.viewer2D.picture.BackgroundImageLayout = ImageLayout.Center;
            this.ShowDdsFile(ddsFileName);
          }
        }
        else if (text == "League")
        {
          if (this.radioLeagueTinyLogo.Checked)
          {
            string ddsFileName = this.m_TempFolder + "\\" + League.TinyLogoDdsFileName(int32, this.m_PatchYear);
            this.viewer2D.picture.BackgroundImageLayout = ImageLayout.Center;
            this.ShowDdsFile(ddsFileName);
          }
          else if (this.radioLeagueAnimLogo.Checked)
          {
            string ddsFileName = this.m_TempFolder + "\\" + League.AnimLogoDdsFileName(int32, this.m_PatchYear);
            this.viewer2D.picture.BackgroundImageLayout = ImageLayout.Center;
            this.ShowDdsFile(ddsFileName);
          }
          else if (this.radioLeagueSmallLogo.Checked)
          {
            string ddsFileName = this.m_TempFolder + "\\" + League.SmallLogoDdsFileName(int32);
            this.viewer2D.picture.BackgroundImageLayout = ImageLayout.Center;
            this.ShowDdsFile(ddsFileName);
          }
          else
          {
            if (!this.radioLeagueLogo512x128.Checked)
              return;
            string ddsFileName = this.m_TempFolder + "\\" + League.Logo512x128DdsFileName(int32);
            this.viewer2D.picture.BackgroundImageLayout = ImageLayout.Center;
            this.ShowDdsFile(ddsFileName);
          }
        }
        else if (text == "Team")
        {
          if (this.radioTeamBanners.Checked)
            this.ShowRx3File(this.m_TempFolder + "\\" + Team.BannerFileName(int32));
          else if (this.radioTeamFlags.Checked)
            this.ShowRx3File(this.m_TempFolder + "\\" + Team.FlagFileName(int32));
          else if (this.radioTeamCrestLarge.Checked)
          {
            string ddsFileName = this.m_TempFolder + "\\" + Team.CrestDdsFileName(int32, this.m_PatchYear);
            this.viewer2D.picture.BackgroundImageLayout = ImageLayout.Center;
            this.ShowDdsFile(ddsFileName);
          }
          else if (this.radioTeamCrest50.Checked)
          {
            string ddsFileName = this.m_TempFolder + "\\" + Team.Crest50DdsFileName(int32, this.m_PatchYear);
            this.viewer2D.picture.BackgroundImageLayout = ImageLayout.Center;
            this.ShowDdsFile(ddsFileName);
          }
          else if (this.radioTeamCrest32.Checked)
          {
            string ddsFileName = this.m_TempFolder + "\\" + Team.Crest32DdsFileName(int32, this.m_PatchYear);
            this.viewer2D.picture.BackgroundImageLayout = ImageLayout.Center;
            this.ShowDdsFile(ddsFileName);
          }
          else
          {
            if (!this.radioTeamCrest16.Checked)
              return;
            string ddsFileName = this.m_TempFolder + "\\" + Team.Crest16DdsFileName(int32, this.m_PatchYear);
            this.viewer2D.picture.BackgroundImageLayout = ImageLayout.Center;
            this.ShowDdsFile(ddsFileName);
          }
        }
        else if (text == "Player")
        {
          if (this.radioEyesTexture.Checked)
            this.ShowRx3File(this.m_TempFolder + "\\" + Player.SpecificEyesTextureFileName(int32));
          else if (this.radioFaceTexture.Checked)
            this.ShowRx3File(this.m_TempFolder + "\\" + Player.SpecificFaceTextureFileName(int32));
          else if (this.radioHairTextures.Checked)
          {
            this.ShowRx3File(this.m_TempFolder + "\\" + Player.SpecificHairTexturesFileName(int32));
          }
          else
          {
            if (!this.radioMiniHead.Checked)
              return;
            string ddsFileName = this.m_TempFolder + "\\" + Player.SpecificPhotoDdsFileName(int32);
            this.viewer2D.picture.BackgroundImageLayout = ImageLayout.Center;
            this.ShowDdsFile(ddsFileName);
          }
        }
        else if (text == "Kit")
        {
          int teamid = int32 / 10;
          int kittype = int32 - 10 * teamid;
          if (this.radioKitKit.Checked)
          {
            this.ShowRx3File(this.m_TempFolder + "\\" + Kit.KitTextureFileName(teamid, kittype, 0));
          }
          else
          {
            if (!this.radioKitMinikit.Checked)
              return;
            string ddsFileName = this.m_TempFolder + "\\" + Kit.MiniKitDdsFileName(teamid, kittype, 0);
            this.viewer2D.picture.BackgroundImageLayout = ImageLayout.Center;
            this.ShowDdsFile(ddsFileName);
          }
        }
        else if (text == "NumberFont")
        {
          int styleId = int32 / 20;
          int colorId = int32 - 20 * styleId;
          this.ShowRx3File(this.m_TempFolder + "\\" + NumberFont.NumberFontFileName(styleId, colorId, null));
        }
        else if (text == "Net")
          this.ShowRx3File(this.m_TempFolder + "\\" + Net.NetFileName(int32));
        else if (text == "MowingPattern")
          this.ShowRx3File(this.m_TempFolder + "\\" + MowingPattern.MowingPatternFileName(int32));
        else if (text == "Adboard")
          this.ShowRx3File(this.m_TempFolder + "\\" + Adboard.AdboardFileName(int32));
        else if (text == "Shoes")
          this.ShowRx3File(this.m_TempFolder + "\\" + Shoes.ShoesTexturesFileName(int32, 0));
        else if (text == "Ball")
        {
          if (this.radioBallTexture.Checked)
          {
            this.ShowRx3File(this.m_TempFolder + "\\" + Ball.BallTextureFileNameList(int32)[0]);
          }
          else
          {
            if (!this.radioBallPreview.Checked || FifaEnvironment.Year != 14)
              return;
            string bigFileName = this.m_TempFolder + "\\" + Ball.BallPictureBigFileName(int32);
            this.viewer2D.picture.BackgroundImageLayout = ImageLayout.Center;
            this.ShowBigFile(bigFileName);
          }
        }
        else if (text == "Stadium")
        {
          int timeofday = 0;
          if (this.radioStadiumGuiOvercast.Checked)
            timeofday = 0;
          if (this.radioStadiumGuiClearDay.Checked)
            timeofday = 1;
          if (this.radioStadiumGuiNight.Checked)
            timeofday = 3;
          if (this.radioStadiumGuiSunset.Checked)
            timeofday = 4;
          if (this.radioStadium3D.Checked)
          {
            if (timeofday != 1 && timeofday != 3)
              return;
            this.ShowRx3File(this.m_TempFolder + "\\" + Stadium.TexturesFileName(int32, timeofday));
          }
          else
          {
            if (!this.radioStadiumPreview.Checked)
              return;
            string bigFileName = this.m_TempFolder + "\\" + Stadium.PreviewBigFileName(int32, timeofday);
            this.viewer2D.picture.BackgroundImageLayout = ImageLayout.Zoom;
            this.ShowBigFile(bigFileName);
          }
        }
        else
        {
          if (text == "Sponsor")
            return;
          if (text == "GkGloves")
            this.ShowRx3File(this.m_TempFolder + "\\" + GkGloves.GkGlovesTextureFileName(int32));
          else
            this.tabPreview.Visible = false;
        }
      }
    }

    private void ShowBigFile(string bigFileName)
    {
      this.tabPreview.SelectedIndex = 0;
      this.viewer2D.CurrentBitmap = FifaEnvironment.GetBitmapFromBigFile(bigFileName);
      this.tabPreview.Visible = this.viewer2D.CurrentBitmap != null;
    }

    private void ShowDdsFile(string ddsFileName)
    {
      this.tabPreview.SelectedIndex = 0;
      this.viewer2D.CurrentBitmap = FifaEnvironment.GetBitmapFromDdsFile(ddsFileName);
      this.tabPreview.Visible = this.viewer2D.CurrentBitmap != null;
    }

    private void ShowRx3File(string rx3FileName)
    {
      this.tabPreview.SelectedIndex = 1;
      this.multiViewer2D.Bitmaps = FifaEnvironment.GetBitmapsFromRx3File(rx3FileName);
      this.tabPreview.Visible = this.multiViewer2D.Bitmaps != null;
    }

    private void PatchLoaderForm_Load(object sender, EventArgs e)
    {
      this.InitPatchLoaderForm();
    }

    private void buttonImportPatch_Click(object sender, EventArgs e)
    {
      this.ImportPatch();
    }

    private void importToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.ImportPatch();
    }

    private void ImportPatch()
    {
      this.RemoveAllUnusedObjects();
      PatchedObject.Initialize();
      PatchedObject.SetLanguageDataSet(this.m_LangDataSet);
      if (!PatchedObject.SetFifaDataSet(this.m_FifaDataSet))
        return;
      PatchedObject.s_PlayerCrossReferenceRequired = false;
      PatchedObject.s_TeamCrossReferenceRequired = false;
      PatchedObject.s_CountryCrossReferenceRequired = false;
      PatchedObject.s_ShoesCrossReferenceRequired = false;
      PatchedObject.s_AdboardCrossReferenceRequired = false;
      PatchedObject.s_BallCrossReferenceRequired = false;
      foreach (ListViewItem listViewItem in this.listViewPatch.Items)
      {
        PatchedObject tag = (PatchedObject) listViewItem.Tag;
        if (listViewItem.Checked && tag.ImportId != tag.Id)
        {
          if (tag.Type == "Player")
            PatchedObject.s_PlayerCrossReferenceRequired = true;
          else if (tag.Type == "Team")
            PatchedObject.s_TeamCrossReferenceRequired = true;
          else if (tag.Type == "Shoes")
            PatchedObject.s_ShoesCrossReferenceRequired = true;
          else if (tag.Type == "Country")
            PatchedObject.s_CountryCrossReferenceRequired = true;
          else if (tag.Type == "Ball")
            PatchedObject.s_BallCrossReferenceRequired = true;
          else if (tag.Type == "Adboard")
            PatchedObject.s_AdboardCrossReferenceRequired = true;
        }
      }
      foreach (ListViewItem listViewItem in this.listViewPatch.Items)
      {
        PatchedObject tag = (PatchedObject) listViewItem.Tag;
        if (listViewItem.Checked)
        {
          this.statusLabel.Text = "Importing " + tag.Name;
          this.statusBar.Refresh();
          tag.Import();
        }
      }
      int num = (int) FifaEnvironment.UserMessages.ShowMessage(15005);
      this.Close();
    }

    private void buttonExitCreator_Click(object sender, EventArgs e)
    {
      this.RemoveAllNewObjects();
      this.Close();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.RemoveAllNewObjects();
      this.Close();
    }

    private void comboReplace_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.listViewPatch.SelectedItems.Count <= 0)
        return;
      ListViewItem selectedItem = this.listViewPatch.SelectedItems[0];
      PatchedObject tag = (PatchedObject) selectedItem.Tag;
      ComboBox comboBox = (ComboBox) sender;
      tag.ReplacedObject = comboBox.SelectedItem;
      selectedItem.SubItems[3] = new ListViewItem.ListViewSubItem(selectedItem, tag.ImportId.ToString());
    }

    private void buttonSelectNewObjects_Click(object sender, EventArgs e)
    {
      foreach (ListViewItem listViewItem in this.listViewPatch.Items)
        listViewItem.Checked = listViewItem.ForeColor == Color.Green;
    }
  }
}
