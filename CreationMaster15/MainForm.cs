// Original code created by Rinaldo

using CreationMaster.Properties;
using FifaControls;
using FifaLibrary;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CreationMaster
{
    public class MainForm : Form
    {
        private AboutForm m_AboutForm = new AboutForm();
        private IContainer components;
        private MenuStrip menuStrip;
        private StatusStrip statusStrip;
        private ToolStripProgressBar progressBar;
        private ToolStripStatusLabel statusBar;
        private ToolStripMenuItem menuFile;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem menuAbout;
        private ToolStripMenuItem menuHelp;
        private SplitContainer splitVert;
        private SplitContainer splitHoriz;
        private ToolStrip toolStripBottom;
        private ToolStripButton buttonShowBottom;
        private ToolStripButton buttonHideBottom;
        private ToolStripMenuItem menuOpenFifa14;
        private ToolStrip toolStripMain;
        private ToolStrip toolStripRight;
        private ToolStripButton buttonShowRight;
        private ToolStripButton buttonHideRight;
        private ToolStripLabel stripLabelRight;
        private ToolStripLabel stripLabelBottom;
        private Panel panelMain;
        private ToolStripMenuItem menuOpenLang14;
        private ToolStripMenuItem menuOpenAll;
        private ToolStripMenuItem menuSave;
        private ToolStripMenuItem menuClose;
        private ToolStripMenuItem menuExit;
        private OpenFileDialog openFifaDialog;
        private OpenFileDialog openLangDialog;
        private FolderBrowserDialog browserDialog;
        private ToolStripMenuItem menuTools;
        private ToolStripMenuItem menuEnableAllMessages;
        private ToolStripMenuItem menuOptions;
        private ToolStripMenuItem menuRegenerate;
        private ToolStripMenuItem menuExpandDatabase;
        private Panel panelBottom;
        private Panel panelRight;
        private ToolStripMenuItem menuOpenDebug;
        private ToolTip toolTip;
        private ToolStripMenuItem menuPatch;
        private ToolStripMenuItem menuCreatePatch;
        private ToolStripMenuItem menuLoadPatch;
        private ToolStripMenuItem menuRemoveKidProtection;
        private ToolStripMenuItem menuCleanFAT;
        private ToolStripMenuItem menuHelpCms;
        private ToolStripMenuItem menuRemoveAllLongTeamNames;
        private ToolStripMenuItem genericToolStripMenuItem;
        private ToolStripMenuItem adboardsToolStripMenuItem;
        private ToolStripMenuItem ballsToolStripMenuItem;
        private ToolStripMenuItem bootsToolStripMenuItem;
        private ToolStripMenuItem countryToolStripMenuItem;
        private ToolStripMenuItem fontsToolStripMenuItem;
        private ToolStripMenuItem formationsToolStripMenuItem;
        private ToolStripMenuItem leaguesToolStripMenuItem;
        private ToolStripMenuItem stadiumsToolStripMenuItem;
        private ToolStripMenuItem teamsToolStripMenuItem;
        private ToolStripMenuItem tournamentsToolStripMenuItem;
        private ToolStripButton buttonCountry;
        private ToolStripButton buttonLeague;
        private ToolStripButton buttonTeam;
        private ToolStripButton buttonPlayer;
        private ToolStripButton buttonStadium;
        private ToolStripButton buttonTournament;
        private ToolStripButton buttonReferee;
        private ToolStripButton buttonBall;
        private ToolStripButton buttonShoes;
        private ToolStripButton buttonManager;
        private ToolStripButton buttonFormation;
        private ToolStripButton buttonTv;
        private ToolStripButton buttonNewspaper;
        private ToolStripButton buttonGloves;
        private ToolStripButton buttonSponsor;
        private ToolStripButton buttonKit;
        private ToolStripMenuItem menuUgc;
        private ToolStripMenuItem menuImportUgc;
        private ToolStripMenuItem menuImportUgcWothKits;
        private ToolStripMenuItem menuImportUgcKits;
        private ToolStripMenuItem menuReopen;
        private ToolStripButton buttonAudio;
        private ToolStripMenuItem menuUpdateDB;
        private ToolStripMenuItem menuOnlineDBFifa14;
        private ToolStripMenuItem menuAlignLanguageDB;
        private ToolStripMenuItem menuImportUgcPlayers;
        private ToolStripMenuItem menuMinimizeNamesTable;
        private ToolStripMenuItem menuOpenFifa15;
        private ToolStripMenuItem menuOnlineDBFifa15;
        private ToolStripMenuItem menuOpenLang15;
        private ToolStripMenuItem menuPreserveOriginalNames;
        public static MainForm CM;
        private int m_SplitterDistanceRight;
        private int m_SplitterDistanceBottom;
        private bool m_OpenFileFlag;
        private bool m_IsShiftPressed;
        private bool m_IsCtrlPressed;
        private bool m_IsAltPressed;
        public FormationForm m_FormationForm;
        public CountryForm m_CountryForm;
        public TeamForm m_TeamForm;
        public KitForm m_KitForm;
        public BallForm m_BallForm;
        public ManagerForm m_ManagerForm;
        public LeagueForm m_LeagueForm;
        public ShoesForm m_ShoesForm;
        public TvForm m_TvForm;
        public NewspapersForm m_NewspapersForm;
        public RefereeForm m_RefereeForm;
        public CompetitionForm m_TrophyForm;
        public PlayerForm m_PlayerForm;
        public StadiumForm m_StadiumForm;
        public GlovesForm m_GlovesForm;
        public AudioForm m_AudioForm;
        public static PatchCreatorForm m_PatchCreatorForm;
        public static PatchLoaderForm m_PatchLoaderForm;
        private string m_XmlDbFileName;
        private string m_UgcFileName;
        private UgcFile m_UgcFile;
        private string m_OnlineDbFileName;
        private CareerFile m_OnlineDbFile;
        private DbFile m_OnlineDb;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
      this.menuOpenFifa15 = new System.Windows.Forms.ToolStripMenuItem();
      this.menuOpenLang15 = new System.Windows.Forms.ToolStripMenuItem();
      this.menuOpenFifa14 = new System.Windows.Forms.ToolStripMenuItem();
      this.menuOpenLang14 = new System.Windows.Forms.ToolStripMenuItem();
      this.menuOpenAll = new System.Windows.Forms.ToolStripMenuItem();
      this.menuReopen = new System.Windows.Forms.ToolStripMenuItem();
      this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
      this.menuClose = new System.Windows.Forms.ToolStripMenuItem();
      this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
      this.menuOpenDebug = new System.Windows.Forms.ToolStripMenuItem();
      this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
      this.menuEnableAllMessages = new System.Windows.Forms.ToolStripMenuItem();
      this.menuOptions = new System.Windows.Forms.ToolStripMenuItem();
      this.menuRegenerate = new System.Windows.Forms.ToolStripMenuItem();
      this.menuExpandDatabase = new System.Windows.Forms.ToolStripMenuItem();
      this.menuRemoveKidProtection = new System.Windows.Forms.ToolStripMenuItem();
      this.menuCleanFAT = new System.Windows.Forms.ToolStripMenuItem();
      this.menuRemoveAllLongTeamNames = new System.Windows.Forms.ToolStripMenuItem();
      this.menuAlignLanguageDB = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMinimizeNamesTable = new System.Windows.Forms.ToolStripMenuItem();
      this.menuPreserveOriginalNames = new System.Windows.Forms.ToolStripMenuItem();
      this.menuPatch = new System.Windows.Forms.ToolStripMenuItem();
      this.menuCreatePatch = new System.Windows.Forms.ToolStripMenuItem();
      this.menuLoadPatch = new System.Windows.Forms.ToolStripMenuItem();
      this.menuUgc = new System.Windows.Forms.ToolStripMenuItem();
      this.menuImportUgc = new System.Windows.Forms.ToolStripMenuItem();
      this.menuImportUgcWothKits = new System.Windows.Forms.ToolStripMenuItem();
      this.menuImportUgcKits = new System.Windows.Forms.ToolStripMenuItem();
      this.menuImportUgcPlayers = new System.Windows.Forms.ToolStripMenuItem();
      this.menuUpdateDB = new System.Windows.Forms.ToolStripMenuItem();
      this.menuOnlineDBFifa14 = new System.Windows.Forms.ToolStripMenuItem();
      this.menuOnlineDBFifa15 = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
      this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
      this.menuHelpCms = new System.Windows.Forms.ToolStripMenuItem();
      this.genericToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.adboardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ballsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.bootsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.countryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.fontsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.formationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.leaguesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.stadiumsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.teamsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tournamentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
      this.statusBar = new System.Windows.Forms.ToolStripStatusLabel();
      this.splitVert = new System.Windows.Forms.SplitContainer();
      this.splitHoriz = new System.Windows.Forms.SplitContainer();
      this.panelMain = new System.Windows.Forms.Panel();
      this.panelBottom = new System.Windows.Forms.Panel();
      this.toolStripBottom = new System.Windows.Forms.ToolStrip();
      this.buttonShowBottom = new System.Windows.Forms.ToolStripButton();
      this.buttonHideBottom = new System.Windows.Forms.ToolStripButton();
      this.stripLabelBottom = new System.Windows.Forms.ToolStripLabel();
      this.panelRight = new System.Windows.Forms.Panel();
      this.toolStripRight = new System.Windows.Forms.ToolStrip();
      this.buttonShowRight = new System.Windows.Forms.ToolStripButton();
      this.buttonHideRight = new System.Windows.Forms.ToolStripButton();
      this.stripLabelRight = new System.Windows.Forms.ToolStripLabel();
      this.toolStripMain = new System.Windows.Forms.ToolStrip();
      this.buttonCountry = new System.Windows.Forms.ToolStripButton();
      this.buttonLeague = new System.Windows.Forms.ToolStripButton();
      this.buttonTeam = new System.Windows.Forms.ToolStripButton();
      this.buttonKit = new System.Windows.Forms.ToolStripButton();
      this.buttonPlayer = new System.Windows.Forms.ToolStripButton();
      this.buttonStadium = new System.Windows.Forms.ToolStripButton();
      this.buttonTournament = new System.Windows.Forms.ToolStripButton();
      this.buttonReferee = new System.Windows.Forms.ToolStripButton();
      this.buttonBall = new System.Windows.Forms.ToolStripButton();
      this.buttonShoes = new System.Windows.Forms.ToolStripButton();
      this.buttonManager = new System.Windows.Forms.ToolStripButton();
      this.buttonFormation = new System.Windows.Forms.ToolStripButton();
      this.buttonSponsor = new System.Windows.Forms.ToolStripButton();
      this.buttonTv = new System.Windows.Forms.ToolStripButton();
      this.buttonNewspaper = new System.Windows.Forms.ToolStripButton();
      this.buttonGloves = new System.Windows.Forms.ToolStripButton();
      this.buttonAudio = new System.Windows.Forms.ToolStripButton();
      this.openFifaDialog = new System.Windows.Forms.OpenFileDialog();
      this.openLangDialog = new System.Windows.Forms.OpenFileDialog();
      this.browserDialog = new System.Windows.Forms.FolderBrowserDialog();
      this.toolTip = new System.Windows.Forms.ToolTip(this.components);
      this.menuStrip.SuspendLayout();
      this.statusStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitVert)).BeginInit();
      this.splitVert.Panel1.SuspendLayout();
      this.splitVert.Panel2.SuspendLayout();
      this.splitVert.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitHoriz)).BeginInit();
      this.splitHoriz.Panel1.SuspendLayout();
      this.splitHoriz.Panel2.SuspendLayout();
      this.splitHoriz.SuspendLayout();
      this.toolStripBottom.SuspendLayout();
      this.toolStripRight.SuspendLayout();
      this.toolStripMain.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip
      // 
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuTools,
            this.menuPatch,
            this.menuUgc,
            this.menuUpdateDB,
            this.helpToolStripMenuItem});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(1384, 24);
      this.menuStrip.TabIndex = 0;
      this.menuStrip.Text = "menuStrip1";
      // 
      // menuFile
      // 
      this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpenFifa15,
            this.menuOpenLang15,
            this.menuOpenFifa14,
            this.menuOpenLang14,
            this.menuOpenAll,
            this.menuReopen,
            this.menuSave,
            this.menuClose,
            this.menuExit,
            this.menuOpenDebug});
      this.menuFile.Name = "menuFile";
      this.menuFile.Size = new System.Drawing.Size(37, 20);
      this.menuFile.Text = "File";
      // 
      // menuOpenFifa15
      // 
      this.menuOpenFifa15.Image = ((System.Drawing.Image)(resources.GetObject("menuOpenFifa15.Image")));
      this.menuOpenFifa15.ImageTransparentColor = System.Drawing.Color.Fuchsia;
      this.menuOpenFifa15.Name = "menuOpenFifa15";
      this.menuOpenFifa15.Size = new System.Drawing.Size(181, 22);
      this.menuOpenFifa15.Text = "Open - FIFA 15";
      this.menuOpenFifa15.Click += new System.EventHandler(this.menuOpenFifa15Demo_Click);
      // 
      // menuOpenLang15
      // 
      this.menuOpenLang15.Image = ((System.Drawing.Image)(resources.GetObject("menuOpenLang15.Image")));
      this.menuOpenLang15.Name = "menuOpenLang15";
      this.menuOpenLang15.Size = new System.Drawing.Size(181, 22);
      this.menuOpenLang15.Text = "Open - Select lan.db";
      this.menuOpenLang15.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
      // 
      // menuOpenFifa14
      // 
      this.menuOpenFifa14.Image = ((System.Drawing.Image)(resources.GetObject("menuOpenFifa14.Image")));
      this.menuOpenFifa14.ImageTransparentColor = System.Drawing.Color.Fuchsia;
      this.menuOpenFifa14.Name = "menuOpenFifa14";
      this.menuOpenFifa14.Size = new System.Drawing.Size(181, 22);
      this.menuOpenFifa14.Text = "Open - FIFA 14";
      this.menuOpenFifa14.Click += new System.EventHandler(this.menuOpenFifa_Click);
      // 
      // menuOpenLang14
      // 
      this.menuOpenLang14.Image = ((System.Drawing.Image)(resources.GetObject("menuOpenLang14.Image")));
      this.menuOpenLang14.Name = "menuOpenLang14";
      this.menuOpenLang14.Size = new System.Drawing.Size(181, 22);
      this.menuOpenLang14.Text = "Open - Select lan.db";
      this.menuOpenLang14.Click += new System.EventHandler(this.openSelectLandbToolStripMenuItem_Click);
      // 
      // menuOpenAll
      // 
      this.menuOpenAll.Image = ((System.Drawing.Image)(resources.GetObject("menuOpenAll.Image")));
      this.menuOpenAll.ImageTransparentColor = System.Drawing.Color.Fuchsia;
      this.menuOpenAll.Name = "menuOpenAll";
      this.menuOpenAll.Size = new System.Drawing.Size(181, 22);
      this.menuOpenAll.Text = "Open - Select all";
      this.menuOpenAll.Click += new System.EventHandler(this.openSelectAllToolStripMenuItem_Click);
      // 
      // menuReopen
      // 
      this.menuReopen.Name = "menuReopen";
      this.menuReopen.Size = new System.Drawing.Size(181, 22);
      this.menuReopen.Text = "Open - Recent";
      this.menuReopen.Click += new System.EventHandler(this.menuReopen_Click);
      // 
      // menuSave
      // 
      this.menuSave.Enabled = false;
      this.menuSave.Image = ((System.Drawing.Image)(resources.GetObject("menuSave.Image")));
      this.menuSave.ImageTransparentColor = System.Drawing.Color.Fuchsia;
      this.menuSave.Name = "menuSave";
      this.menuSave.Size = new System.Drawing.Size(181, 22);
      this.menuSave.Text = "Save";
      this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
      // 
      // menuClose
      // 
      this.menuClose.Enabled = false;
      this.menuClose.Image = ((System.Drawing.Image)(resources.GetObject("menuClose.Image")));
      this.menuClose.ImageTransparentColor = System.Drawing.Color.Fuchsia;
      this.menuClose.Name = "menuClose";
      this.menuClose.Size = new System.Drawing.Size(181, 22);
      this.menuClose.Text = "Close";
      this.menuClose.Click += new System.EventHandler(this.menuClose_Click);
      // 
      // menuExit
      // 
      this.menuExit.Image = ((System.Drawing.Image)(resources.GetObject("menuExit.Image")));
      this.menuExit.ImageTransparentColor = System.Drawing.Color.Fuchsia;
      this.menuExit.Name = "menuExit";
      this.menuExit.Size = new System.Drawing.Size(181, 22);
      this.menuExit.Text = "Exit";
      this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
      // 
      // menuOpenDebug
      // 
      this.menuOpenDebug.Name = "menuOpenDebug";
      this.menuOpenDebug.Size = new System.Drawing.Size(181, 22);
      this.menuOpenDebug.Text = "Open - Demo";
      this.menuOpenDebug.Visible = false;
      // 
      // menuTools
      // 
      this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEnableAllMessages,
            this.menuOptions,
            this.menuRegenerate,
            this.menuExpandDatabase,
            this.menuRemoveKidProtection,
            this.menuCleanFAT,
            this.menuRemoveAllLongTeamNames,
            this.menuAlignLanguageDB,
            this.menuMinimizeNamesTable,
            this.menuPreserveOriginalNames});
      this.menuTools.Name = "menuTools";
      this.menuTools.Size = new System.Drawing.Size(46, 20);
      this.menuTools.Text = "Tools";
      // 
      // menuEnableAllMessages
      // 
      this.menuEnableAllMessages.Image = ((System.Drawing.Image)(resources.GetObject("menuEnableAllMessages.Image")));
      this.menuEnableAllMessages.ImageTransparentColor = System.Drawing.Color.Fuchsia;
      this.menuEnableAllMessages.Name = "menuEnableAllMessages";
      this.menuEnableAllMessages.Size = new System.Drawing.Size(238, 22);
      this.menuEnableAllMessages.Text = "Enable all messages";
      this.menuEnableAllMessages.Click += new System.EventHandler(this.menuEnableAllMessages_Click);
      // 
      // menuOptions
      // 
      this.menuOptions.Image = ((System.Drawing.Image)(resources.GetObject("menuOptions.Image")));
      this.menuOptions.ImageTransparentColor = System.Drawing.Color.Fuchsia;
      this.menuOptions.Name = "menuOptions";
      this.menuOptions.Size = new System.Drawing.Size(238, 22);
      this.menuOptions.Text = "Options";
      this.menuOptions.Visible = false;
      this.menuOptions.Click += new System.EventHandler(this.menuOptions_Click);
      // 
      // menuRegenerate
      // 
      this.menuRegenerate.Image = ((System.Drawing.Image)(resources.GetObject("menuRegenerate.Image")));
      this.menuRegenerate.ImageTransparentColor = System.Drawing.Color.Fuchsia;
      this.menuRegenerate.Name = "menuRegenerate";
      this.menuRegenerate.Size = new System.Drawing.Size(238, 22);
      this.menuRegenerate.Text = "Regenerate BH";
      this.menuRegenerate.Click += new System.EventHandler(this.menuRegenerate_Click);
      // 
      // menuExpandDatabase
      // 
      this.menuExpandDatabase.Image = ((System.Drawing.Image)(resources.GetObject("menuExpandDatabase.Image")));
      this.menuExpandDatabase.ImageTransparentColor = System.Drawing.Color.Fuchsia;
      this.menuExpandDatabase.Name = "menuExpandDatabase";
      this.menuExpandDatabase.Size = new System.Drawing.Size(238, 22);
      this.menuExpandDatabase.Text = "Expand Database";
      this.menuExpandDatabase.Click += new System.EventHandler(this.menuExpandDatabase_Click);
      // 
      // menuRemoveKidProtection
      // 
      this.menuRemoveKidProtection.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.menuRemoveKidProtection.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.menuRemoveKidProtection.Name = "menuRemoveKidProtection";
      this.menuRemoveKidProtection.Size = new System.Drawing.Size(238, 22);
      this.menuRemoveKidProtection.Text = "Remove \"Kid Protection\" Kits";
      this.menuRemoveKidProtection.Visible = false;
      this.menuRemoveKidProtection.Click += new System.EventHandler(this.menuRemoveKidProtection_Click);
      // 
      // menuCleanFAT
      // 
      this.menuCleanFAT.Image = ((System.Drawing.Image)(resources.GetObject("menuCleanFAT.Image")));
      this.menuCleanFAT.ImageTransparentColor = System.Drawing.Color.Fuchsia;
      this.menuCleanFAT.Name = "menuCleanFAT";
      this.menuCleanFAT.Size = new System.Drawing.Size(238, 22);
      this.menuCleanFAT.Text = "Clean FAT";
      this.menuCleanFAT.Visible = false;
      this.menuCleanFAT.Click += new System.EventHandler(this.menuCleanFAT_Click);
      // 
      // menuRemoveAllLongTeamNames
      // 
      this.menuRemoveAllLongTeamNames.Name = "menuRemoveAllLongTeamNames";
      this.menuRemoveAllLongTeamNames.Size = new System.Drawing.Size(238, 22);
      this.menuRemoveAllLongTeamNames.Text = "Remove All Long Team Names";
      this.menuRemoveAllLongTeamNames.Visible = false;
      this.menuRemoveAllLongTeamNames.Click += new System.EventHandler(this.removeAllLongTeamNames_Click);
      // 
      // menuAlignLanguageDB
      // 
      this.menuAlignLanguageDB.Name = "menuAlignLanguageDB";
      this.menuAlignLanguageDB.Size = new System.Drawing.Size(238, 22);
      this.menuAlignLanguageDB.Text = "Align Language DB";
      this.menuAlignLanguageDB.Click += new System.EventHandler(this.menuAlignLanguageDB_Click);
      // 
      // menuMinimizeNamesTable
      // 
      this.menuMinimizeNamesTable.Name = "menuMinimizeNamesTable";
      this.menuMinimizeNamesTable.Size = new System.Drawing.Size(238, 22);
      this.menuMinimizeNamesTable.Text = "Minimize Player Names Table";
      this.menuMinimizeNamesTable.ToolTipText = "Reserve more room in the player names table for created players but makes the dat" +
    "abase not compatible with online gaming . ";
      this.menuMinimizeNamesTable.Click += new System.EventHandler(this.minimizeNamesTableToolStripMenuItem_Click);
      // 
      // menuPreserveOriginalNames
      // 
      this.menuPreserveOriginalNames.Name = "menuPreserveOriginalNames";
      this.menuPreserveOriginalNames.Size = new System.Drawing.Size(238, 22);
      this.menuPreserveOriginalNames.Text = "Preserve Original Player Names";
      this.menuPreserveOriginalNames.ToolTipText = "Preserve all the names originally present in the player names table, in this way " +
    "the database will be compatible with online gaming but the space of names for ne" +
    "w players will be reduced. ";
      this.menuPreserveOriginalNames.Click += new System.EventHandler(this.menuPreserveOriginalNames_Click);
      // 
      // menuPatch
      // 
      this.menuPatch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCreatePatch,
            this.menuLoadPatch});
      this.menuPatch.Name = "menuPatch";
      this.menuPatch.Size = new System.Drawing.Size(49, 20);
      this.menuPatch.Text = "Patch";
      // 
      // menuCreatePatch
      // 
      this.menuCreatePatch.Image = ((System.Drawing.Image)(resources.GetObject("menuCreatePatch.Image")));
      this.menuCreatePatch.ImageTransparentColor = System.Drawing.Color.Fuchsia;
      this.menuCreatePatch.Name = "menuCreatePatch";
      this.menuCreatePatch.Size = new System.Drawing.Size(108, 22);
      this.menuCreatePatch.Text = "Create";
      this.menuCreatePatch.Click += new System.EventHandler(this.menuCreatePatch_Click);
      // 
      // menuLoadPatch
      // 
      this.menuLoadPatch.Image = ((System.Drawing.Image)(resources.GetObject("menuLoadPatch.Image")));
      this.menuLoadPatch.ImageTransparentColor = System.Drawing.Color.Fuchsia;
      this.menuLoadPatch.Name = "menuLoadPatch";
      this.menuLoadPatch.Size = new System.Drawing.Size(108, 22);
      this.menuLoadPatch.Text = "Load";
      this.menuLoadPatch.Click += new System.EventHandler(this.menuLoadPatch_Click);
      // 
      // menuUgc
      // 
      this.menuUgc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuImportUgc,
            this.menuImportUgcWothKits,
            this.menuImportUgcKits,
            this.menuImportUgcPlayers});
      this.menuUgc.Name = "menuUgc";
      this.menuUgc.Size = new System.Drawing.Size(81, 20);
      this.menuUgc.Text = "UG Content";
      // 
      // menuImportUgc
      // 
      this.menuImportUgc.Image = ((System.Drawing.Image)(resources.GetObject("menuImportUgc.Image")));
      this.menuImportUgc.ImageTransparentColor = System.Drawing.Color.Fuchsia;
      this.menuImportUgc.Name = "menuImportUgc";
      this.menuImportUgc.Size = new System.Drawing.Size(176, 22);
      this.menuImportUgc.Text = "Import DB only";
      this.menuImportUgc.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
      // 
      // menuImportUgcWothKits
      // 
      this.menuImportUgcWothKits.Name = "menuImportUgcWothKits";
      this.menuImportUgcWothKits.Size = new System.Drawing.Size(176, 22);
      this.menuImportUgcWothKits.Text = "Import DB and KITS";
      this.menuImportUgcWothKits.Click += new System.EventHandler(this.importDBAndKITSToolStripMenuItem_Click);
      // 
      // menuImportUgcKits
      // 
      this.menuImportUgcKits.Name = "menuImportUgcKits";
      this.menuImportUgcKits.Size = new System.Drawing.Size(176, 22);
      this.menuImportUgcKits.Text = "Import KITS only";
      this.menuImportUgcKits.Click += new System.EventHandler(this.importKITSOmlyToolStripMenuItem_Click);
      // 
      // menuImportUgcPlayers
      // 
      this.menuImportUgcPlayers.Name = "menuImportUgcPlayers";
      this.menuImportUgcPlayers.Size = new System.Drawing.Size(176, 22);
      this.menuImportUgcPlayers.Text = "Import Players only";
      this.menuImportUgcPlayers.Click += new System.EventHandler(this.menuImportUgcPlayers_Click);
      // 
      // menuUpdateDB
      // 
      this.menuUpdateDB.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOnlineDBFifa14,
            this.menuOnlineDBFifa15});
      this.menuUpdateDB.Name = "menuUpdateDB";
      this.menuUpdateDB.Size = new System.Drawing.Size(98, 20);
      this.menuUpdateDB.Text = "Update Rosters";
      // 
      // menuOnlineDBFifa14
      // 
      this.menuOnlineDBFifa14.Name = "menuOnlineDBFifa14";
      this.menuOnlineDBFifa14.Size = new System.Drawing.Size(167, 22);
      this.menuOnlineDBFifa14.Text = "Online DB FIFA 14";
      this.menuOnlineDBFifa14.Click += new System.EventHandler(this.menuOnlineDBFifa14_Click);
      // 
      // menuOnlineDBFifa15
      // 
      this.menuOnlineDBFifa15.Name = "menuOnlineDBFifa15";
      this.menuOnlineDBFifa15.Size = new System.Drawing.Size(167, 22);
      this.menuOnlineDBFifa15.Text = "Online DB FIFA 15";
      this.menuOnlineDBFifa15.Click += new System.EventHandler(this.menuOnlineDBFifa15_Click);
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelp,
            this.menuAbout,
            this.menuHelpCms});
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.helpToolStripMenuItem.Text = "Help";
      // 
      // menuHelp
      // 
      this.menuHelp.Image = ((System.Drawing.Image)(resources.GetObject("menuHelp.Image")));
      this.menuHelp.ImageTransparentColor = System.Drawing.Color.Fuchsia;
      this.menuHelp.Name = "menuHelp";
      this.menuHelp.Size = new System.Drawing.Size(107, 22);
      this.menuHelp.Text = "Help";
      this.menuHelp.Click += new System.EventHandler(this.menuHelp_Click);
      // 
      // menuAbout
      // 
      this.menuAbout.Image = ((System.Drawing.Image)(resources.GetObject("menuAbout.Image")));
      this.menuAbout.ImageTransparentColor = System.Drawing.Color.Fuchsia;
      this.menuAbout.Name = "menuAbout";
      this.menuAbout.Size = new System.Drawing.Size(107, 22);
      this.menuAbout.Text = "About";
      this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
      // 
      // menuHelpCms
      // 
      this.menuHelpCms.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.genericToolStripMenuItem,
            this.adboardsToolStripMenuItem,
            this.ballsToolStripMenuItem,
            this.bootsToolStripMenuItem,
            this.countryToolStripMenuItem,
            this.fontsToolStripMenuItem,
            this.formationsToolStripMenuItem,
            this.leaguesToolStripMenuItem,
            this.stadiumsToolStripMenuItem,
            this.teamsToolStripMenuItem,
            this.tournamentsToolStripMenuItem});
      this.menuHelpCms.Name = "menuHelpCms";
      this.menuHelpCms.Size = new System.Drawing.Size(107, 22);
      this.menuHelpCms.Text = "CMS";
      this.menuHelpCms.Visible = false;
      // 
      // genericToolStripMenuItem
      // 
      this.genericToolStripMenuItem.Name = "genericToolStripMenuItem";
      this.genericToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
      this.genericToolStripMenuItem.Text = "Generic";
      this.genericToolStripMenuItem.Click += new System.EventHandler(this.menuHelpCms_Click);
      // 
      // adboardsToolStripMenuItem
      // 
      this.adboardsToolStripMenuItem.Name = "adboardsToolStripMenuItem";
      this.adboardsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
      this.adboardsToolStripMenuItem.Text = "Adboards";
      this.adboardsToolStripMenuItem.Click += new System.EventHandler(this.adboardsToolStripMenuItem_Click);
      // 
      // ballsToolStripMenuItem
      // 
      this.ballsToolStripMenuItem.Name = "ballsToolStripMenuItem";
      this.ballsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
      this.ballsToolStripMenuItem.Text = "Balls";
      this.ballsToolStripMenuItem.Click += new System.EventHandler(this.ballsToolStripMenuItem_Click);
      // 
      // bootsToolStripMenuItem
      // 
      this.bootsToolStripMenuItem.Name = "bootsToolStripMenuItem";
      this.bootsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
      this.bootsToolStripMenuItem.Text = "Boots";
      this.bootsToolStripMenuItem.Click += new System.EventHandler(this.bootsToolStripMenuItem_Click);
      // 
      // countryToolStripMenuItem
      // 
      this.countryToolStripMenuItem.Name = "countryToolStripMenuItem";
      this.countryToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
      this.countryToolStripMenuItem.Text = "Country";
      this.countryToolStripMenuItem.Click += new System.EventHandler(this.countryToolStripMenuItem_Click);
      // 
      // fontsToolStripMenuItem
      // 
      this.fontsToolStripMenuItem.Name = "fontsToolStripMenuItem";
      this.fontsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
      this.fontsToolStripMenuItem.Text = "Fonts";
      this.fontsToolStripMenuItem.Click += new System.EventHandler(this.fontsToolStripMenuItem_Click);
      // 
      // formationsToolStripMenuItem
      // 
      this.formationsToolStripMenuItem.Name = "formationsToolStripMenuItem";
      this.formationsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
      this.formationsToolStripMenuItem.Text = "Formations";
      this.formationsToolStripMenuItem.Click += new System.EventHandler(this.formationsToolStripMenuItem_Click);
      // 
      // leaguesToolStripMenuItem
      // 
      this.leaguesToolStripMenuItem.Name = "leaguesToolStripMenuItem";
      this.leaguesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
      this.leaguesToolStripMenuItem.Text = "Leagues";
      this.leaguesToolStripMenuItem.Click += new System.EventHandler(this.leaguesToolStripMenuItem_Click);
      // 
      // stadiumsToolStripMenuItem
      // 
      this.stadiumsToolStripMenuItem.Name = "stadiumsToolStripMenuItem";
      this.stadiumsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
      this.stadiumsToolStripMenuItem.Text = "Stadiums";
      this.stadiumsToolStripMenuItem.Click += new System.EventHandler(this.stadiumsToolStripMenuItem_Click);
      // 
      // teamsToolStripMenuItem
      // 
      this.teamsToolStripMenuItem.Name = "teamsToolStripMenuItem";
      this.teamsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
      this.teamsToolStripMenuItem.Text = "Teams";
      this.teamsToolStripMenuItem.Click += new System.EventHandler(this.teamsToolStripMenuItem_Click);
      // 
      // tournamentsToolStripMenuItem
      // 
      this.tournamentsToolStripMenuItem.Name = "tournamentsToolStripMenuItem";
      this.tournamentsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
      this.tournamentsToolStripMenuItem.Text = "Tournaments";
      this.tournamentsToolStripMenuItem.Click += new System.EventHandler(this.tournamentsToolStripMenuItem_Click);
      // 
      // statusStrip
      // 
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.statusBar});
      this.statusStrip.Location = new System.Drawing.Point(0, 859);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(1384, 22);
      this.statusStrip.TabIndex = 1;
      this.statusStrip.Text = "statusStrip1";
      // 
      // progressBar
      // 
      this.progressBar.Name = "progressBar";
      this.progressBar.Size = new System.Drawing.Size(100, 16);
      this.progressBar.Visible = false;
      // 
      // statusBar
      // 
      this.statusBar.Name = "statusBar";
      this.statusBar.Size = new System.Drawing.Size(39, 17);
      this.statusBar.Text = "Ready";
      // 
      // splitVert
      // 
      this.splitVert.BackColor = System.Drawing.Color.Blue;
      this.splitVert.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitVert.Enabled = false;
      this.splitVert.IsSplitterFixed = true;
      this.splitVert.Location = new System.Drawing.Point(0, 79);
      this.splitVert.Name = "splitVert";
      // 
      // splitVert.Panel1
      // 
      this.splitVert.Panel1.Controls.Add(this.splitHoriz);
      // 
      // splitVert.Panel2
      // 
      this.splitVert.Panel2.BackColor = System.Drawing.Color.LightSkyBlue;
      this.splitVert.Panel2.Controls.Add(this.panelRight);
      this.splitVert.Panel2.Controls.Add(this.toolStripRight);
      this.splitVert.Size = new System.Drawing.Size(1384, 780);
      this.splitVert.SplitterDistance = 1355;
      this.splitVert.SplitterWidth = 2;
      this.splitVert.TabIndex = 2;
      // 
      // splitHoriz
      // 
      this.splitHoriz.BackColor = System.Drawing.Color.Blue;
      this.splitHoriz.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitHoriz.IsSplitterFixed = true;
      this.splitHoriz.Location = new System.Drawing.Point(0, 0);
      this.splitHoriz.Name = "splitHoriz";
      this.splitHoriz.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitHoriz.Panel1
      // 
      this.splitHoriz.Panel1.BackColor = System.Drawing.SystemColors.Control;
      this.splitHoriz.Panel1.Controls.Add(this.panelMain);
      // 
      // splitHoriz.Panel2
      // 
      this.splitHoriz.Panel2.BackColor = System.Drawing.Color.LightSkyBlue;
      this.splitHoriz.Panel2.Controls.Add(this.panelBottom);
      this.splitHoriz.Panel2.Controls.Add(this.toolStripBottom);
      this.splitHoriz.Size = new System.Drawing.Size(1355, 780);
      this.splitHoriz.SplitterDistance = 750;
      this.splitHoriz.SplitterWidth = 2;
      this.splitHoriz.TabIndex = 0;
      // 
      // panelMain
      // 
      this.panelMain.BackColor = System.Drawing.Color.LightSkyBlue;
      this.panelMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelMain.Location = new System.Drawing.Point(0, 0);
      this.panelMain.Name = "panelMain";
      this.panelMain.Size = new System.Drawing.Size(1355, 750);
      this.panelMain.TabIndex = 1;
      // 
      // panelBottom
      // 
      this.panelBottom.AutoScroll = true;
      this.panelBottom.AutoSize = true;
      this.panelBottom.BackColor = System.Drawing.Color.LightSkyBlue;
      this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelBottom.Location = new System.Drawing.Point(0, 25);
      this.panelBottom.Name = "panelBottom";
      this.panelBottom.Size = new System.Drawing.Size(1355, 3);
      this.panelBottom.TabIndex = 1;
      // 
      // toolStripBottom
      // 
      this.toolStripBottom.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.toolStripBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonShowBottom,
            this.buttonHideBottom,
            this.stripLabelBottom});
      this.toolStripBottom.Location = new System.Drawing.Point(0, 0);
      this.toolStripBottom.Name = "toolStripBottom";
      this.toolStripBottom.Size = new System.Drawing.Size(1355, 25);
      this.toolStripBottom.TabIndex = 0;
      this.toolStripBottom.Text = "toolBottom";
      // 
      // buttonShowBottom
      // 
      this.buttonShowBottom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonShowBottom.Image = ((System.Drawing.Image)(resources.GetObject("buttonShowBottom.Image")));
      this.buttonShowBottom.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonShowBottom.Name = "buttonShowBottom";
      this.buttonShowBottom.Size = new System.Drawing.Size(23, 22);
      this.buttonShowBottom.Text = "show";
      this.buttonShowBottom.Click += new System.EventHandler(this.buttonShowBottom_Click);
      // 
      // buttonHideBottom
      // 
      this.buttonHideBottom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonHideBottom.Image = ((System.Drawing.Image)(resources.GetObject("buttonHideBottom.Image")));
      this.buttonHideBottom.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonHideBottom.Name = "buttonHideBottom";
      this.buttonHideBottom.Size = new System.Drawing.Size(23, 22);
      this.buttonHideBottom.Text = "hide";
      this.buttonHideBottom.Visible = false;
      this.buttonHideBottom.Click += new System.EventHandler(this.buttonHideBottom_Click);
      // 
      // stripLabelBottom
      // 
      this.stripLabelBottom.Name = "stripLabelBottom";
      this.stripLabelBottom.Size = new System.Drawing.Size(41, 22);
      this.stripLabelBottom.Text = "Empty";
      // 
      // panelRight
      // 
      this.panelRight.AutoScroll = true;
      this.panelRight.BackColor = System.Drawing.Color.LightSkyBlue;
      this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelRight.Location = new System.Drawing.Point(24, 0);
      this.panelRight.Name = "panelRight";
      this.panelRight.Size = new System.Drawing.Size(3, 780);
      this.panelRight.TabIndex = 2;
      // 
      // toolStripRight
      // 
      this.toolStripRight.Dock = System.Windows.Forms.DockStyle.Left;
      this.toolStripRight.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.toolStripRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonShowRight,
            this.buttonHideRight,
            this.stripLabelRight});
      this.toolStripRight.Location = new System.Drawing.Point(0, 0);
      this.toolStripRight.Name = "toolStripRight";
      this.toolStripRight.Size = new System.Drawing.Size(24, 780);
      this.toolStripRight.TabIndex = 1;
      this.toolStripRight.Text = "toolBottom";
      // 
      // buttonShowRight
      // 
      this.buttonShowRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonShowRight.Image = ((System.Drawing.Image)(resources.GetObject("buttonShowRight.Image")));
      this.buttonShowRight.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonShowRight.Name = "buttonShowRight";
      this.buttonShowRight.Size = new System.Drawing.Size(21, 20);
      this.buttonShowRight.Text = "show";
      this.buttonShowRight.Click += new System.EventHandler(this.buttonShowRight_Click);
      // 
      // buttonHideRight
      // 
      this.buttonHideRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonHideRight.Image = ((System.Drawing.Image)(resources.GetObject("buttonHideRight.Image")));
      this.buttonHideRight.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonHideRight.Name = "buttonHideRight";
      this.buttonHideRight.Size = new System.Drawing.Size(21, 20);
      this.buttonHideRight.Text = "hide";
      this.buttonHideRight.Visible = false;
      this.buttonHideRight.Click += new System.EventHandler(this.buttonHideRight_Click);
      // 
      // stripLabelRight
      // 
      this.stripLabelRight.Name = "stripLabelRight";
      this.stripLabelRight.Size = new System.Drawing.Size(21, 41);
      this.stripLabelRight.Text = "Empty";
      this.stripLabelRight.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
      // 
      // toolStripMain
      // 
      this.toolStripMain.Enabled = false;
      this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonCountry,
            this.buttonLeague,
            this.buttonTeam,
            this.buttonKit,
            this.buttonPlayer,
            this.buttonStadium,
            this.buttonTournament,
            this.buttonReferee,
            this.buttonBall,
            this.buttonShoes,
            this.buttonManager,
            this.buttonFormation,
            this.buttonSponsor,
            this.buttonTv,
            this.buttonNewspaper,
            this.buttonGloves,
            this.buttonAudio});
      this.toolStripMain.Location = new System.Drawing.Point(0, 24);
      this.toolStripMain.Name = "toolStripMain";
      this.toolStripMain.Size = new System.Drawing.Size(1384, 55);
      this.toolStripMain.TabIndex = 0;
      this.toolStripMain.Text = "toolStripMain";
      this.toolTip.SetToolTip(this.toolStripMain, "Click and use Shift, Ctrl and Alt keys to activate a different window");
      // 
      // buttonCountry
      // 
      this.buttonCountry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonCountry.Image = ((System.Drawing.Image)(resources.GetObject("buttonCountry.Image")));
      this.buttonCountry.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.buttonCountry.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonCountry.Name = "buttonCountry";
      this.buttonCountry.Size = new System.Drawing.Size(52, 52);
      this.buttonCountry.Text = "Country";
      this.buttonCountry.ToolTipText = "Country";
      this.buttonCountry.Click += new System.EventHandler(this.buttonMain_Click);
      // 
      // buttonLeague
      // 
      this.buttonLeague.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonLeague.Image = ((System.Drawing.Image)(resources.GetObject("buttonLeague.Image")));
      this.buttonLeague.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.buttonLeague.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonLeague.Name = "buttonLeague";
      this.buttonLeague.Size = new System.Drawing.Size(52, 52);
      this.buttonLeague.Text = "League";
      this.buttonLeague.Click += new System.EventHandler(this.buttonMain_Click);
      // 
      // buttonTeam
      // 
      this.buttonTeam.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonTeam.Image = ((System.Drawing.Image)(resources.GetObject("buttonTeam.Image")));
      this.buttonTeam.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.buttonTeam.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonTeam.Name = "buttonTeam";
      this.buttonTeam.Size = new System.Drawing.Size(52, 52);
      this.buttonTeam.Text = "Team";
      this.buttonTeam.Click += new System.EventHandler(this.buttonMain_Click);
      // 
      // buttonKit
      // 
      this.buttonKit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonKit.Image = ((System.Drawing.Image)(resources.GetObject("buttonKit.Image")));
      this.buttonKit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.buttonKit.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonKit.Name = "buttonKit";
      this.buttonKit.Size = new System.Drawing.Size(47, 52);
      this.buttonKit.Text = "Kits";
      this.buttonKit.Click += new System.EventHandler(this.buttonMain_Click);
      // 
      // buttonPlayer
      // 
      this.buttonPlayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonPlayer.Image = ((System.Drawing.Image)(resources.GetObject("buttonPlayer.Image")));
      this.buttonPlayer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.buttonPlayer.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonPlayer.Name = "buttonPlayer";
      this.buttonPlayer.Size = new System.Drawing.Size(52, 52);
      this.buttonPlayer.Text = "Player";
      this.buttonPlayer.Click += new System.EventHandler(this.buttonMain_Click);
      // 
      // buttonStadium
      // 
      this.buttonStadium.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonStadium.Image = ((System.Drawing.Image)(resources.GetObject("buttonStadium.Image")));
      this.buttonStadium.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.buttonStadium.ImageTransparentColor = System.Drawing.Color.White;
      this.buttonStadium.Name = "buttonStadium";
      this.buttonStadium.Size = new System.Drawing.Size(52, 52);
      this.buttonStadium.Text = "Stadium";
      this.buttonStadium.ToolTipText = "Stadium";
      this.buttonStadium.Click += new System.EventHandler(this.buttonMain_Click);
      // 
      // buttonTournament
      // 
      this.buttonTournament.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonTournament.Image = ((System.Drawing.Image)(resources.GetObject("buttonTournament.Image")));
      this.buttonTournament.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.buttonTournament.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonTournament.Name = "buttonTournament";
      this.buttonTournament.Size = new System.Drawing.Size(52, 52);
      this.buttonTournament.Text = "Tournament in Manager Mode";
      this.buttonTournament.ToolTipText = "Tournament";
      this.buttonTournament.Click += new System.EventHandler(this.buttonMain_Click);
      // 
      // buttonReferee
      // 
      this.buttonReferee.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonReferee.Image = ((System.Drawing.Image)(resources.GetObject("buttonReferee.Image")));
      this.buttonReferee.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.buttonReferee.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonReferee.Name = "buttonReferee";
      this.buttonReferee.Size = new System.Drawing.Size(52, 52);
      this.buttonReferee.Text = "Referee";
      this.buttonReferee.Click += new System.EventHandler(this.buttonMain_Click);
      // 
      // buttonBall
      // 
      this.buttonBall.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonBall.Image = ((System.Drawing.Image)(resources.GetObject("buttonBall.Image")));
      this.buttonBall.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.buttonBall.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonBall.Name = "buttonBall";
      this.buttonBall.Size = new System.Drawing.Size(52, 52);
      this.buttonBall.Text = "Ball";
      this.buttonBall.Click += new System.EventHandler(this.buttonMain_Click);
      // 
      // buttonShoes
      // 
      this.buttonShoes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonShoes.Image = ((System.Drawing.Image)(resources.GetObject("buttonShoes.Image")));
      this.buttonShoes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.buttonShoes.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonShoes.Name = "buttonShoes";
      this.buttonShoes.Size = new System.Drawing.Size(52, 52);
      this.buttonShoes.Text = "Boots";
      this.buttonShoes.Click += new System.EventHandler(this.buttonMain_Click);
      // 
      // buttonManager
      // 
      this.buttonManager.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonManager.Image = ((System.Drawing.Image)(resources.GetObject("buttonManager.Image")));
      this.buttonManager.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.buttonManager.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonManager.Name = "buttonManager";
      this.buttonManager.Size = new System.Drawing.Size(52, 52);
      this.buttonManager.Text = "Manager";
      this.buttonManager.Click += new System.EventHandler(this.buttonMain_Click);
      // 
      // buttonFormation
      // 
      this.buttonFormation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonFormation.Image = ((System.Drawing.Image)(resources.GetObject("buttonFormation.Image")));
      this.buttonFormation.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.buttonFormation.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonFormation.Name = "buttonFormation";
      this.buttonFormation.Size = new System.Drawing.Size(52, 52);
      this.buttonFormation.Text = "Generic Formations";
      this.buttonFormation.Click += new System.EventHandler(this.buttonMain_Click);
      // 
      // buttonSponsor
      // 
      this.buttonSponsor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonSponsor.Image = ((System.Drawing.Image)(resources.GetObject("buttonSponsor.Image")));
      this.buttonSponsor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.buttonSponsor.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonSponsor.Name = "buttonSponsor";
      this.buttonSponsor.Size = new System.Drawing.Size(52, 52);
      this.buttonSponsor.Text = "Sponsor";
      this.buttonSponsor.Visible = false;
      this.buttonSponsor.Click += new System.EventHandler(this.buttonMain_Click);
      // 
      // buttonTv
      // 
      this.buttonTv.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonTv.Image = ((System.Drawing.Image)(resources.GetObject("buttonTv.Image")));
      this.buttonTv.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.buttonTv.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonTv.Name = "buttonTv";
      this.buttonTv.Size = new System.Drawing.Size(52, 52);
      this.buttonTv.Text = "TV";
      this.buttonTv.Visible = false;
      this.buttonTv.Click += new System.EventHandler(this.buttonMain_Click);
      // 
      // buttonNewspaper
      // 
      this.buttonNewspaper.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonNewspaper.Image = ((System.Drawing.Image)(resources.GetObject("buttonNewspaper.Image")));
      this.buttonNewspaper.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.buttonNewspaper.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonNewspaper.Name = "buttonNewspaper";
      this.buttonNewspaper.Size = new System.Drawing.Size(52, 52);
      this.buttonNewspaper.Text = "Newspaper";
      this.buttonNewspaper.Click += new System.EventHandler(this.buttonMain_Click);
      // 
      // buttonGloves
      // 
      this.buttonGloves.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonGloves.Image = ((System.Drawing.Image)(resources.GetObject("buttonGloves.Image")));
      this.buttonGloves.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.buttonGloves.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonGloves.Name = "buttonGloves";
      this.buttonGloves.Size = new System.Drawing.Size(52, 52);
      this.buttonGloves.Text = "Gloves and accessories";
      this.buttonGloves.Click += new System.EventHandler(this.buttonMain_Click);
      // 
      // buttonAudio
      // 
      this.buttonAudio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.buttonAudio.Image = ((System.Drawing.Image)(resources.GetObject("buttonAudio.Image")));
      this.buttonAudio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.buttonAudio.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.buttonAudio.Name = "buttonAudio";
      this.buttonAudio.Size = new System.Drawing.Size(52, 52);
      this.buttonAudio.Text = "Audio";
      this.buttonAudio.Click += new System.EventHandler(this.buttonMain_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1384, 881);
      this.Controls.Add(this.splitVert);
      this.Controls.Add(this.statusStrip);
      this.Controls.Add(this.toolStripMain);
      this.Controls.Add(this.menuStrip);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.IsMdiContainer = true;
      this.MainMenuStrip = this.menuStrip;
      this.MinimumSize = new System.Drawing.Size(200, 200);
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Creation Master 17 Legacy (2023.10)";
      this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.splitVert.Panel1.ResumeLayout(false);
      this.splitVert.Panel2.ResumeLayout(false);
      this.splitVert.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitVert)).EndInit();
      this.splitVert.ResumeLayout(false);
      this.splitHoriz.Panel1.ResumeLayout(false);
      this.splitHoriz.Panel2.ResumeLayout(false);
      this.splitHoriz.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitHoriz)).EndInit();
      this.splitHoriz.ResumeLayout(false);
      this.toolStripBottom.ResumeLayout(false);
      this.toolStripBottom.PerformLayout();
      this.toolStripRight.ResumeLayout(false);
      this.toolStripRight.PerformLayout();
      this.toolStripMain.ResumeLayout(false);
      this.toolStripMain.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        public MainForm()
        {
            this.InitializeComponent();
            // UPDATE 2021.1
            int desiredWidth = 1400;
            int desiredHeight = 920;
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            if (screenWidth < 1400) // 1366x768, 1280x1024, 1280x720
            {
                if (screenWidth > 1300)
                    desiredWidth = 1300;
                else
                    desiredWidth = 1200;
            }
            if (screenHeight < 920) // 1600x900, 1440x900, 1366x768, 1280x720
            {
                if (screenHeight > 800)
                    desiredHeight = 800;
                else
                    desiredHeight = 700;
            }
            if (desiredWidth != 1400 || desiredHeight != 920)
                this.ClientSize = new System.Drawing.Size(desiredWidth - 16, desiredHeight - 39);
            // ---
            this.m_SplitterDistanceBottom = this.splitHoriz.Height * 2 / 3;
            this.m_SplitterDistanceRight = this.splitVert.Width * 3 / 4;
            FifaEnvironment.InitializeDefault();
            this.CreateForms();
            MainForm.CM = this;
            this.EnablePanels(false);
            this.EnableMenus();
        }

        private void CreateForms()
        {
            this.m_FormationForm = new FormationForm();
            this.m_FormationForm.MdiParent = (Form)this;
            this.m_FormationForm.Dock = DockStyle.Fill;
            this.m_CountryForm = new CountryForm();
            this.m_CountryForm.MdiParent = (Form)this;
            this.m_CountryForm.Dock = DockStyle.Fill;
            this.m_TeamForm = new TeamForm();
            this.m_TeamForm.MdiParent = (Form)this;
            this.m_TeamForm.Dock = DockStyle.Fill;
            this.m_KitForm = new KitForm();
            this.m_KitForm.MdiParent = (Form)this;
            this.m_KitForm.Dock = DockStyle.Fill;
            this.m_BallForm = new BallForm();
            this.m_BallForm.MdiParent = (Form)this;
            this.m_BallForm.Dock = DockStyle.Fill;
            this.m_ManagerForm = new ManagerForm();
            this.m_ManagerForm.MdiParent = (Form)this;
            this.m_ManagerForm.Dock = DockStyle.Fill;
            this.m_LeagueForm = new LeagueForm();
            this.m_LeagueForm.MdiParent = (Form)this;
            this.m_LeagueForm.Dock = DockStyle.Fill;
            this.m_ShoesForm = new ShoesForm();
            this.m_ShoesForm.MdiParent = (Form)this;
            this.m_ShoesForm.Dock = DockStyle.Fill;
            this.m_TvForm = new TvForm();
            this.m_TvForm.MdiParent = (Form)this;
            this.m_TvForm.Dock = DockStyle.Fill;
            this.m_NewspapersForm = new NewspapersForm();
            this.m_NewspapersForm.MdiParent = (Form)this;
            this.m_NewspapersForm.Dock = DockStyle.Fill;
            this.m_RefereeForm = new RefereeForm();
            this.m_RefereeForm.MdiParent = (Form)this;
            this.m_RefereeForm.Dock = DockStyle.Fill;
            this.m_TrophyForm = new CompetitionForm();
            this.m_TrophyForm.MdiParent = (Form)this;
            this.m_TrophyForm.Dock = DockStyle.Fill;
            this.m_PlayerForm = new PlayerForm();
            this.m_PlayerForm.MdiParent = (Form)this;
            this.m_PlayerForm.Dock = DockStyle.Fill;
            this.m_StadiumForm = new StadiumForm();
            this.m_StadiumForm.MdiParent = (Form)this;
            this.m_StadiumForm.Dock = DockStyle.Fill;
            this.m_GlovesForm = new GlovesForm();
            this.m_GlovesForm.MdiParent = (Form)this;
            this.m_GlovesForm.Dock = DockStyle.Fill;
            this.m_AudioForm = new AudioForm();
            this.m_AudioForm.MdiParent = (Form)this;
            this.m_AudioForm.Dock = DockStyle.Fill;
            MainForm.m_PatchCreatorForm = new PatchCreatorForm();
            MainForm.m_PatchLoaderForm = new PatchLoaderForm();
        }

        private void DestroyForms()
        {
            this.m_FormationForm.Dispose();
            this.m_CountryForm.Dispose();
            this.m_TeamForm.Dispose();
            this.m_KitForm.Dispose();
            this.m_BallForm.Dispose();
            this.m_ManagerForm.Dispose();
            this.m_LeagueForm.Dispose();
            this.m_ShoesForm.Dispose();
            this.m_TvForm.Dispose();
            this.m_NewspapersForm.Dispose();
            this.m_RefereeForm.Dispose();
            this.m_TrophyForm.Dispose();
            this.m_PlayerForm.Dispose();
            this.m_StadiumForm.Dispose();
            this.m_GlovesForm.Dispose();
            this.m_AudioForm.Dispose();
        }

        private void EnablePanels(bool enable)
        {
            this.splitVert.Enabled = enable;
        }

        private void EnableMenus()
        {
            if (this.m_OpenFileFlag)
            {
                this.menuOpenFifa15.Enabled = false;
                this.menuOpenFifa14.Enabled = false;
                this.menuOpenAll.Enabled = false;
                this.menuOpenLang14.Enabled = false;
                this.menuOpenLang15.Enabled = false;
                this.menuReopen.Enabled = false;
                this.menuSave.Enabled = true;
                this.menuClose.Enabled = true;
                this.menuOptions.Enabled = false;
                this.menuRegenerate.Enabled = true;
                this.menuExpandDatabase.Enabled = true;
                this.menuAlignLanguageDB.Enabled = true;
                this.menuCleanFAT.Enabled = true;
                this.menuRemoveKidProtection.Enabled = true;
                this.toolStripMain.Enabled = true;
                this.menuPatch.Enabled = true;
                this.menuRemoveAllLongTeamNames.Enabled = true;
                this.menuUgc.Enabled = FifaEnvironment.Year == 14;
                this.menuUpdateDB.Enabled = true;
                this.menuOnlineDBFifa14.Visible = FifaEnvironment.Year == 14;
                this.menuOnlineDBFifa15.Visible = FifaEnvironment.Year != 14;
                this.menuEnableAllMessages.Enabled = true;
                this.menuMinimizeNamesTable.Enabled = true;
                this.menuPreserveOriginalNames.Enabled = true;
            }
            else
            {
                this.menuOpenFifa15.Enabled = true;
                this.menuOpenFifa14.Enabled = true;
                this.menuOpenAll.Enabled = true;
                this.menuOpenLang14.Enabled = true;
                this.menuOpenLang15.Enabled = true;
                this.menuReopen.Enabled = true;
                this.menuSave.Enabled = false;
                this.menuClose.Enabled = false;
                this.menuOptions.Enabled = true;
                this.menuRegenerate.Enabled = false;
                this.menuExpandDatabase.Enabled = false;
                this.menuAlignLanguageDB.Enabled = false;
                this.menuCleanFAT.Enabled = false;
                this.menuRemoveKidProtection.Enabled = false;
                this.toolStripMain.Enabled = false;
                this.menuPatch.Enabled = false;
                this.menuRemoveAllLongTeamNames.Enabled = false;
                this.menuUgc.Enabled = false;
                this.menuUpdateDB.Enabled = false;
                this.menuEnableAllMessages.Enabled = false;
                this.menuMinimizeNamesTable.Enabled = false;
                this.menuPreserveOriginalNames.Enabled = false;
            }
            this.menuExit.Enabled = true;
        }

        private void ShowFormOnPanel(Form form, Panel panel)
        {
            panel.Controls.Clear();
            panel.Controls.Add((Control)form);
            form.Show();
            if (this.panelBottom.Controls.Count == 0)
                this.stripLabelBottom.Text = "Empty";
            else
                this.stripLabelBottom.Text = this.panelBottom.Controls[0].Text;
            if (this.panelRight.Controls.Count == 0)
                this.stripLabelRight.Text = "Empty";
            else
                this.stripLabelRight.Text = this.panelRight.Controls[0].Text;
        }

        public void JumpTo(IdObject idObject)
        {
            Panel panel = this.m_IsAltPressed ? this.panelRight : (this.m_IsCtrlPressed ? this.panelBottom : this.panelMain);
            if (idObject.GetType().Name == "Player")
            {
                Player player = (Player)idObject;
                if (!this.m_PlayerForm.pickUpControl.combo.Items.Contains((object)player))
                    this.m_PlayerForm.pickUpControl.combo.Items.Add((object)player);
                this.m_PlayerForm.pickUpControl.combo.SelectedItem = (object)player;
                this.ShowFormOnPanel((Form)this.m_PlayerForm, panel);
            }
            if (idObject.GetType().Name == "Team")
            {
                Team team = (Team)idObject;
                if (!this.m_TeamForm.pickUpControl.combo.Items.Contains((object)team))
                    this.m_TeamForm.pickUpControl.combo.Items.Add((object)team);
                this.m_TeamForm.pickUpControl.combo.SelectedItem = (object)team;
                this.ShowFormOnPanel((Form)this.m_TeamForm, panel);
            }
            if (idObject.GetType().Name == "Kit")
            {
                Kit kit = (Kit)idObject;
                if (!this.m_KitForm.pickUpControl.combo.Items.Contains((object)kit))
                    this.m_KitForm.pickUpControl.combo.Items.Add((object)kit);
                this.m_KitForm.pickUpControl.combo.SelectedItem = (object)kit;
                this.ShowFormOnPanel((Form)this.m_KitForm, panel);
            }
            if (idObject.GetType().Name == "League")
            {
                League league = (League)idObject;
                if (!this.m_LeagueForm.pickUpControl.combo.Items.Contains((object)league))
                    this.m_LeagueForm.pickUpControl.combo.Items.Add((object)league);
                this.m_LeagueForm.pickUpControl.combo.SelectedItem = (object)league;
                this.ShowFormOnPanel((Form)this.m_LeagueForm, panel);
            }
            if (idObject.GetType().Name == "Country")
            {
                Country country = (Country)idObject;
                if (!this.m_CountryForm.pickUpControl.combo.Items.Contains((object)country))
                    this.m_CountryForm.pickUpControl.combo.Items.Add((object)country);
                this.m_CountryForm.pickUpControl.combo.SelectedItem = (object)country;
                this.ShowFormOnPanel((Form)this.m_CountryForm, panel);
            }
            if (idObject.GetType().Name == "Trophy")
                this.ShowFormOnPanel((Form)this.m_TrophyForm, panel);
            if (idObject.GetType().Name == "Stadium")
            {
                Stadium stadium = (Stadium)idObject;
                if (!this.m_StadiumForm.pickUpControl.combo.Items.Contains((object)stadium))
                    this.m_StadiumForm.pickUpControl.combo.Items.Add((object)stadium);
                this.m_StadiumForm.pickUpControl.combo.SelectedItem = (object)stadium;
                this.ShowFormOnPanel((Form)this.m_StadiumForm, panel);
            }
            if (idObject.GetType().Name == "Formation")
            {
                Formation formation = (Formation)idObject;
                if (!this.m_FormationForm.pickUpControl.combo.Items.Contains((object)formation))
                    this.m_FormationForm.pickUpControl.combo.Items.Add((object)formation);
                this.m_FormationForm.pickUpControl.combo.SelectedItem = (object)formation;
                this.ShowFormOnPanel((Form)this.m_FormationForm, panel);
            }
            if (idObject.GetType().Name == "Ball")
            {
                Ball ball = (Ball)idObject;
                if (!this.m_BallForm.pickUpControl.combo.Items.Contains((object)ball))
                    this.m_BallForm.pickUpControl.combo.Items.Add((object)ball);
                this.m_BallForm.pickUpControl.combo.SelectedItem = (object)ball;
                this.ShowFormOnPanel((Form)this.m_BallForm, panel);
            }
            if (idObject.GetType().Name == "Shoes")
            {
                Shoes shoes = (Shoes)idObject;
                if (!this.m_ShoesForm.pickUpControl.combo.Items.Contains((object)shoes))
                    this.m_ShoesForm.pickUpControl.combo.Items.Add((object)shoes);
                this.m_ShoesForm.pickUpControl.combo.SelectedItem = (object)shoes;
                this.ShowFormOnPanel((Form)this.m_ShoesForm, panel);
            }
            if (!(idObject.GetType().Name == "GkGloves"))
                return;
            GkGloves gkGloves = (GkGloves)idObject;
            if (!this.m_GlovesForm.pickUpControl.combo.Items.Contains((object)gkGloves))
                this.m_GlovesForm.pickUpControl.combo.Items.Add((object)gkGloves);
            this.m_GlovesForm.pickUpControl.combo.SelectedItem = (object)gkGloves;
            this.ShowFormOnPanel((Form)this.m_GlovesForm, panel);
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            this.m_AboutForm.labelProduct.Text = "Creation Master 15 (2021)";
            this.m_AboutForm.labelRelease.Text = "Version 15.1";
            int num = (int)this.m_AboutForm.ShowDialog();
        }

        private void buttonShowBottom_Click(object sender, EventArgs e)
        {
            this.toolStripBottom.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStripBottom.Dock = DockStyle.Left;
            this.splitHoriz.SplitterDistance = this.m_SplitterDistanceBottom;
            this.splitHoriz.IsSplitterFixed = false;
            this.buttonShowBottom.Visible = false;
            this.stripLabelBottom.TextDirection = ToolStripTextDirection.Vertical90;
            this.buttonHideBottom.Visible = true;
        }

        private void buttonHideBottom_Click(object sender, EventArgs e)
        {
            this.toolStripBottom.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripBottom.Dock = DockStyle.Bottom;
            this.toolStripBottom.AutoSize = true;
            this.m_SplitterDistanceBottom = this.splitHoriz.SplitterDistance;
            this.splitHoriz.SplitterDistance = this.splitHoriz.Height - 23;
            this.splitHoriz.IsSplitterFixed = true;
            this.buttonShowBottom.Visible = true;
            this.stripLabelBottom.TextDirection = ToolStripTextDirection.Horizontal;
            this.buttonHideBottom.Visible = false;
        }

        private void buttonShowRight_Click(object sender, EventArgs e)
        {
            this.toolStripRight.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripRight.Dock = DockStyle.Top;
            this.toolStripRight.AutoSize = true;
            this.splitVert.SplitterDistance = this.m_SplitterDistanceRight;
            this.splitVert.IsSplitterFixed = false;
            this.buttonShowRight.Visible = false;
            this.stripLabelRight.TextDirection = ToolStripTextDirection.Horizontal;
            this.buttonHideRight.Visible = true;
        }

        private void buttonHideRight_Click(object sender, EventArgs e)
        {
            this.toolStripRight.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStripRight.Dock = DockStyle.Right;
            this.m_SplitterDistanceRight = this.splitVert.SplitterDistance;
            this.splitVert.SplitterDistance = this.splitVert.Width - 23;
            this.splitVert.IsSplitterFixed = true;
            this.buttonShowRight.Visible = true;
            this.stripLabelRight.TextDirection = ToolStripTextDirection.Vertical90;
            this.buttonHideRight.Visible = false;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.splitHoriz.IsSplitterFixed && this.splitHoriz.Height >= 23)
                this.splitHoriz.SplitterDistance = this.splitHoriz.Height - 23;
            if (!this.splitVert.IsSplitterFixed || this.splitVert.Width < 23)
                return;
            this.splitVert.SplitterDistance = this.splitVert.Width - 23;
        }

        private void menuOpenFifa_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (!this.InitializeFifaEnvironment(14))
                return;
            this.Refresh();
            this.Open();
            Cursor.Current = Cursors.Default;
        }

        private void menuOpenFifa15Demo_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (!this.InitializeFifaEnvironment(15))
                return;
            this.Refresh();
            this.Open();
            Cursor.Current = Cursors.Default;
        }

        private bool InitializeFifaEnvironment(int year, string rootDir)
        {
            bool flag = false;
            if (year > 0)
                flag = FifaEnvironment.Initialize(year, rootDir);
            else if (rootDir != null)
            {
                if (rootDir.Contains("14"))
                    flag = FifaEnvironment.Initialize(14, rootDir);
                if (rootDir.Contains("15"))
                    flag = FifaEnvironment.Initialize(15, rootDir);
                if (rootDir.Contains("17"))
                    flag = FifaEnvironment.Initialize(17, rootDir);
            }
            if (!flag)
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(10004);
            }
            return flag;
        }

        private bool InitializeFifaEnvironment(int year)
        {
            return this.InitializeFifaEnvironment(year, (string)null);
        }

        private bool InitializeFifaEnvironment(string rootDir)
        {
            return this.InitializeFifaEnvironment(-1, rootDir);
        }

        private void Open()
        {
            if (!FifaEnvironment.Open(this.statusBar))
                return;
            this.m_OpenFileFlag = true;
            Settings.Default.RootDir = FifaEnvironment.RootDir;
            Settings.Default.FifaDbFileName = FifaEnvironment.FifaDbFileName;
            Settings.Default.FifaXmlFileName = FifaEnvironment.FifaXmlFileName;
            Settings.Default.LangDbFileName = FifaEnvironment.LangDbFileName;
            Settings.Default.LangXmlFileName = FifaEnvironment.LangXmlFileName;
            Settings.Default.Save();
            this.EnablePanels(true);
            this.EnableMenus();
        }

        private void buttonMain_Click(object sender, EventArgs e)
        {
            ToolStripButton toolStripButton = (ToolStripButton)sender;
            Panel panel = this.m_IsAltPressed ? this.panelRight : (this.m_IsCtrlPressed ? this.panelBottom : this.panelMain);
            if (toolStripButton == this.buttonCountry)
                this.ShowFormOnPanel((Form)this.m_CountryForm, panel);
            if (toolStripButton == this.buttonTeam)
                this.ShowFormOnPanel((Form)this.m_TeamForm, panel);
            if (toolStripButton == this.buttonKit)
                this.ShowFormOnPanel((Form)this.m_KitForm, panel);
            if (toolStripButton == this.buttonFormation)
                this.ShowFormOnPanel((Form)this.m_FormationForm, panel);
            if (toolStripButton == this.buttonBall)
                this.ShowFormOnPanel((Form)this.m_BallForm, panel);
            if (toolStripButton == this.buttonManager)
                this.ShowFormOnPanel((Form)this.m_ManagerForm, panel);
            if (toolStripButton == this.buttonLeague)
                this.ShowFormOnPanel((Form)this.m_LeagueForm, panel);
            if (toolStripButton == this.buttonShoes)
                this.ShowFormOnPanel((Form)this.m_ShoesForm, panel);
            if (toolStripButton == this.buttonTv)
                this.ShowFormOnPanel((Form)this.m_TvForm, panel);
            if (toolStripButton == this.buttonNewspaper)
                this.ShowFormOnPanel((Form)this.m_NewspapersForm, panel);
            if (toolStripButton == this.buttonReferee)
                this.ShowFormOnPanel((Form)this.m_RefereeForm, panel);
            if (toolStripButton == this.buttonTournament)
                this.ShowFormOnPanel((Form)this.m_TrophyForm, panel);
            if (toolStripButton == this.buttonStadium)
                this.ShowFormOnPanel((Form)this.m_StadiumForm, panel);
            if (toolStripButton == this.buttonPlayer)
                this.ShowFormOnPanel((Form)this.m_PlayerForm, panel);
            if (toolStripButton == this.buttonGloves)
                this.ShowFormOnPanel((Form)this.m_GlovesForm, panel);
            if (toolStripButton != this.buttonAudio)
                return;
            this.ShowFormOnPanel((Form)this.m_AudioForm, panel);
        }

        private void openSelectLandbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.InitializeFifaEnvironment(14) || !this.AskUserOpenLangDatabase())
                return;
            this.Open();
        }

        private void openSelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.AskUserOpen())
                return;
            this.Open();
        }

        private bool AskUserOpen()
        {
            string rootDir = this.AskUserOpenRootFolder();
            if (rootDir == null || !this.InitializeFifaEnvironment(rootDir))
                return false;
            if (!FifaEnvironment.OpenFat())
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(10003);
                return false;
            }
            FifaEnvironment.ExtractMainDatabase();
            if (!this.AskUserOpenMainDatabase())
                return false;
            if (!FifaEnvironment.OpenFifaDb())
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(10000);
                return false;
            }
            FifaEnvironment.ExtractLangDatabase();
            if (!this.AskUserOpenLangDatabase())
                return false;
            if (FifaEnvironment.OpenLangDb())
                return true;
            int num1 = (int)FifaEnvironment.UserMessages.ShowMessage(10035);
            return false;
        }

        private bool AskUserOpenLangDatabase()
        {
            this.openLangDialog.CheckFileExists = true;
            this.openLangDialog.InitialDirectory = FifaEnvironment.GameDir + "data\\loc\\";
            this.openLangDialog.Filter = "db files (*.db)|*.db";
            this.openLangDialog.FilterIndex = 1;
            this.openLangDialog.Title = "Open Language Database";
            if (this.openLangDialog.ShowDialog() != DialogResult.OK)
                return false;
            FifaEnvironment.LangDbFileName = this.openLangDialog.FileName;
            FifaEnvironment.LangXmlFileName = this.openLangDialog.FileName.Replace(".db", "-meta.xml");
            return true;
        }

        private string AskUserOpenRootFolder()
        {
            this.browserDialog.Description = "Select the root folder of FIFA";
            this.browserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            this.browserDialog.ShowNewFolderButton = false;
            this.browserDialog.SelectedPath = FifaEnvironment.RootDir;
            return this.browserDialog.ShowDialog() != DialogResult.OK ? (string)null : this.browserDialog.SelectedPath;
        }

        private bool AskUserOpenMainDatabase()
        {
            return this.BrowseXml() && this.BrowseDB();
        }

        private bool BrowseDB()
        {
            this.openFifaDialog.InitialDirectory = FifaEnvironment.GameDir + "data\\db\\";
            this.openFifaDialog.Filter = "db files (*.db)|*.db";
            this.openFifaDialog.FilterIndex = 1;
            this.openFifaDialog.Title = "Open Database File";
            bool flag = false;
            if (this.openFifaDialog.ShowDialog() == DialogResult.OK)
            {
                FifaEnvironment.FifaDbFileName = this.openFifaDialog.FileName;
                flag = true;
            }
            return flag;
        }

        private bool BrowseXmlDb()
        {
            this.openFifaDialog.InitialDirectory = FifaEnvironment.GameDir + "data\\db\\";
            this.openFifaDialog.Filter = "xml files (*.xml)|*.xml";
            this.openFifaDialog.FilterIndex = 1;
            this.openFifaDialog.Title = "Open XML Descriptor File";
            bool flag = false;
            if (this.openFifaDialog.ShowDialog() == DialogResult.OK)
            {
                this.m_XmlDbFileName = this.openFifaDialog.FileName;
                flag = true;
            }
            return flag;
        }

        private bool BrowseXml()
        {
            this.openFifaDialog.InitialDirectory = FifaEnvironment.GameDir + "data\\db\\";
            this.openFifaDialog.Filter = "xml files (*.xml)|*.xml";
            this.openFifaDialog.FilterIndex = 1;
            this.openFifaDialog.Title = "Open XML Descriptor File";
            bool flag = false;
            if (this.openFifaDialog.ShowDialog() == DialogResult.OK)
            {
                FifaEnvironment.FifaXmlFileName = this.openFifaDialog.FileName;
                flag = true;
            }
            return flag;
        }

        private void menuSave_Click(object sender, EventArgs e)
        {
            if (!this.m_OpenFileFlag)
                return;
            Cursor.Current = Cursors.WaitCursor;
            this.Refresh();
            this.SaveFiles();
            this.statusBar.Text = "Ready - Save completed!";
            Cursor.Current = Cursors.Default;
        }

        private void menuClose_Click(object sender, EventArgs e)
        {
            if (!this.AskAndSave())
                return;
            this.CloseFile();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.AskAndExit();
        }

        private bool AskAndSave()
        {
            switch (FifaEnvironment.UserMessages.ShowMessage(1))
            {
                case DialogResult.OK:
                case DialogResult.No:
                    return true;
                case DialogResult.Yes:
                    this.SaveFiles();
                    return true;
                default:
                    return false;
            }
        }

        private void AskAndExit()
        {
            if (this.m_OpenFileFlag)
            {
                if (!this.AskAndSave())
                    return;
                this.m_OpenFileFlag = false;
                Application.Exit();
            }
            else
                Application.Exit();
        }

        private void SaveFiles()
        {
            FifaEnvironment.Save(this.statusBar);
        }

        private void CloseFile()
        {
            this.m_OpenFileFlag = false;
            this.m_CountryForm.Clean();
            this.m_LeagueForm.Clean();
            this.m_TeamForm.Clean();
            this.m_KitForm.Clean();
            this.m_PlayerForm.Clean();
            this.m_StadiumForm.Clean();
            this.m_RefereeForm.Clean();
            this.m_FormationForm.Clean();
            this.m_TrophyForm.Clean();
            this.m_ManagerForm.Clean();
            this.m_TvForm.Clean();
            this.m_ShoesForm.Clean();
            this.m_BallForm.Clean();
            this.m_GlovesForm.Clean();
            this.m_AudioForm.Clean();
            this.DestroyForms();
            this.CreateForms();
            this.EnableMenus();
            this.EnablePanels(false);
        }

        private void menuOptions_Click(object sender, EventArgs e)
        {
            FifaEnvironment.ShowOptions();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            this.m_IsShiftPressed = (keyData & Keys.Shift) != Keys.None;
            this.m_IsCtrlPressed = (keyData & Keys.Control) != Keys.None;
            this.m_IsAltPressed = (keyData & Keys.Alt) != Keys.None;
            return false;
        }

        private void menuExpandDatabase_Click(object sender, EventArgs e)
        {
            if (FifaEnvironment.FifaDb.NTables != 133)
            {
                int num1 = (int)FifaEnvironment.UserMessages.ShowMessage(5049);
            }
            else
            {
                int num2 = (int)FifaEnvironment.UserMessages.ShowMessage(FifaEnvironment.FifaDb.Expand() ? 1010 : 1011);
            }
        }

        private void menuEnableAllMessages_Click(object sender, EventArgs e)
        {
            if (FifaEnvironment.UserMessages == null)
                return;
            FifaEnvironment.UserMessages.EnableMessages(true);
        }

        private void menuRegenerate_Click(object sender, EventArgs e)
        {
            switch (FifaEnvironment.UserMessages.ShowMessage(14))
            {
                case DialogResult.Cancel:
                    break;
                case DialogResult.No:
                    break;
                default:
                    if (FifaEnvironment.FifaFat == null)
                        break;
                    this.statusBar.Text = "Regenerating bh files";
                    Cursor.Current = Cursors.WaitCursor;
                    this.Refresh();
                    FifaEnvironment.FifaFat.RegenerateAllBh(true);
                    Cursor.Current = Cursors.Default;
                    this.statusBar.Text = "Ready";
                    break;
            }
        }

        private void menuHelp_Click(object sender, EventArgs e)
        {
            string str = FifaEnvironment.LaunchDir + "\\CreationMaster.htm";
            if (!File.Exists(str))
                return;
            Help.ShowHelp((Control)this, str);
        }

        private void menuCreatePatch_Click(object sender, EventArgs e)
        {
            switch (FifaEnvironment.UserMessages.ShowMessage(19))
            {
                case DialogResult.OK:
                case DialogResult.Yes:
                    this.SaveFiles();
                    break;
                case DialogResult.Cancel:
                    return;
            }
            int num = (int)MainForm.m_PatchCreatorForm.ShowDialog();
        }

        private void menuLoadPatch_Click(object sender, EventArgs e)
        {
            int num = (int)MainForm.m_PatchLoaderForm.ShowDialog();
            this.statusBar.Text = "Updating windows ...";
            this.statusBar.Text = "Ready";
        }

        private void menuRemoveKidProtection_Click(object sender, EventArgs e)
        {
        }

        private void menuCleanFAT_Click(object sender, EventArgs e)
        {
        }

        private void menuHelpCms_Click(object sender, EventArgs e)
        {
        }

        private void removeAllLongTeamNames_Click(object sender, EventArgs e)
        {
        }

        private void adboardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ballsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void bootsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void countryToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void fontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void formationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void leaguesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void stadiumsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void teamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void tournamentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FifaEnvironment.FifaXmlFileName != null)
                this.m_XmlDbFileName = FifaEnvironment.FifaXmlFileName;
            else if (!this.BrowseXmlDb())
                return;
            if (!this.BrowseUgc() || !this.OpenUgcFile())
                return;
            switch (FifaEnvironment.UserMessages.ShowMessage(29))
            {
                case DialogResult.Cancel:
                    break;
                case DialogResult.No:
                    break;
                default:
                    Cursor.Current = Cursors.WaitCursor;
                    this.m_UgcFile.Import(this.m_XmlDbFileName, false, this.statusBar);
                    Cursor.Current = Cursors.Default;
                    break;
            }
        }

        private void importDBAndKITSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FifaEnvironment.FifaXmlFileName != null)
                this.m_XmlDbFileName = FifaEnvironment.FifaXmlFileName;
            else if (!this.BrowseXmlDb())
                return;
            if (!this.BrowseUgc() || !this.OpenUgcFile())
                return;
            switch (FifaEnvironment.UserMessages.ShowMessage(29))
            {
                case DialogResult.Cancel:
                    break;
                case DialogResult.No:
                    break;
                default:
                    Cursor.Current = Cursors.WaitCursor;
                    this.m_UgcFile.Import(this.m_XmlDbFileName, true, this.statusBar);
                    Cursor.Current = Cursors.Default;
                    break;
            }
        }

        private bool OpenUgcFile()
        {
            if (this.m_UgcFileName == null)
                return false;
            this.m_UgcFile = new UgcFile(this.m_UgcFileName);
            if (this.m_UgcFile == null)
                return false;
            for (int fileIndex = 0; fileIndex < this.m_UgcFile.NFiles; ++fileIndex)
                this.m_UgcFile.Extract(fileIndex, FifaEnvironment.TempFolder);
            return true;
        }

        private bool BrowseUgc()
        {
            this.openFifaDialog = new OpenFileDialog();
            this.openFifaDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\FIFA 14";
            this.openFifaDialog.Filter = "UGC Files|UG*.*";
            this.openFifaDialog.FilterIndex = 1;
            this.openFifaDialog.Title = "Open User Generated Content file";
            bool flag = false;
            if (this.openFifaDialog.ShowDialog() == DialogResult.OK)
            {
                this.m_UgcFileName = this.openFifaDialog.FileName;
                flag = true;
            }
            return flag;
        }

        private void importKITSOmlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FifaEnvironment.FifaXmlFileName != null)
                this.m_XmlDbFileName = FifaEnvironment.FifaXmlFileName;
            else if (!this.BrowseXmlDb())
                return;
            if (!this.BrowseUgc() || !this.OpenUgcFile())
                return;
            switch (FifaEnvironment.UserMessages.ShowMessage(29))
            {
                case DialogResult.Cancel:
                    break;
                case DialogResult.No:
                    break;
                default:
                    Cursor.Current = Cursors.WaitCursor;
                    this.m_UgcFile.ImportKitGraphics(this.m_XmlDbFileName, this.statusBar);
                    Cursor.Current = Cursors.Default;
                    break;
            }
        }

        private void menuReopen_Click(object sender, EventArgs e)
        {
            if (Settings.Default.RootDir == null || !(Settings.Default.RootDir != string.Empty) || (Settings.Default.FifaDbFileName == null || !(Settings.Default.FifaDbFileName != string.Empty)) || (Settings.Default.LangXmlFileName == null || !(Settings.Default.FifaXmlFileName != string.Empty) || (Settings.Default.LangDbFileName == null || !(Settings.Default.LangDbFileName != string.Empty))) || (Settings.Default.LangXmlFileName == null || !(Settings.Default.LangXmlFileName != string.Empty) || !this.InitializeFifaEnvironment(Settings.Default.RootDir)))
                return;
            Cursor.Current = Cursors.WaitCursor;
            FifaEnvironment.FifaDbFileName = Settings.Default.FifaDbFileName;
            FifaEnvironment.FifaXmlFileName = Settings.Default.FifaXmlFileName;
            FifaEnvironment.LangDbFileName = Settings.Default.LangDbFileName;
            FifaEnvironment.LangXmlFileName = Settings.Default.LangXmlFileName;
            this.Refresh();
            this.Open();
            Cursor.Current = Cursors.Default;
        }

        private void menuOnlineDBFifa14_Click(object sender, EventArgs e)
        {
            if (FifaEnvironment.FifaXmlFileName != null)
                this.m_XmlDbFileName = FifaEnvironment.FifaXmlFileName;
            else if (!this.BrowseXmlDb())
                return;
            if (!this.BrowseOnline())
                return;
            Cursor.Current = Cursors.WaitCursor;
            this.m_OnlineDbFile = new CareerFile(this.m_OnlineDbFileName, this.m_XmlDbFileName);
            Cursor.Current = Cursors.Default;
            if (this.m_OnlineDbFile == null)
                return;
            this.m_OnlineDb = this.m_OnlineDbFile.Databases[0];
            this.MergeOnlineDb();
        }

        private bool MergeOnlineDb()
        {
            if (this.m_OnlineDb == null)
                return false;
            Table table1 = this.m_OnlineDb.GetTable("dcplayernames");
            Table table2 = this.m_OnlineDb.GetTable("teamplayerlinks");
            Table table3 = this.m_OnlineDb.GetTable("formations");
            Table table4 = this.m_OnlineDb.GetTable("teams");
            Table table5 = this.m_OnlineDb.GetTable("playerloans");
            Table table6 = this.m_OnlineDb.GetTable("manager");
            Table table7 = this.m_OnlineDb.GetTable("players");
            Table table8 = this.m_OnlineDb.GetTable("previousteam");
            Table table9 = FifaEnvironment.OriginalFifaDb.GetTable("playernames");
            if (table1 == null || table2 == null || (table3 == null || table4 == null) || (table5 == null || table6 == null || (table7 == null || table8 == null)))
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(10036);
                return false;
            }
            for (int index = 0; index < table7.NValidRecords; ++index)
            {
                Record record = table7.Records[index];
                if (FifaEnvironment.Players.SearchId(record.IntField[FI.players_playerid]) == null)
                {
                    Player player = new Player(record);
                    player.UpdatePlayername(table1, table9);
                    FifaEnvironment.Players.InsertId((IdObject)player);
                }
            }
            FifaEnvironment.Players.FillFromPlayerloans(table5);
            FifaEnvironment.Players.FillFromPreviousTeam(table8);
            for (int index = 0; index < table3.NValidRecords; ++index)
            {
                Record record = table3.Records[index];
                int num = record.IntField[FI.formations_teamid];
                int id = record.IntField[FI.formations_formationid];
                if (num >= 0)
                {
                    Formation formation = (Formation)FifaEnvironment.Formations.SearchId(id);
                    if (formation != null)
                        formation.Load(record);
                    else
                        FifaEnvironment.Formations.InsertId((IdObject)new Formation(record));
                }
            }
            for (int index = 0; index < table4.NValidRecords; ++index)
            {
                Record record = table4.Records[index];
                Team team = (Team)FifaEnvironment.Teams.SearchId(record.IntField[FI.teams_teamid]);
                if (team != null)
                {
                    team.Roster.ResetToEmpty();
                    team.Load(record);
                }
            }
            FifaEnvironment.Teams.FillFromTeamPlayerLinks(table2);
            FifaEnvironment.Teams.FillFromFormations(table3);
            FifaEnvironment.Teams.FillFromManager(table6);
            FifaEnvironment.Players.LinkTeam(FifaEnvironment.Teams);
            FifaEnvironment.Players.LinkCountry(FifaEnvironment.Countries);
            FifaEnvironment.Teams.LinkPlayer(FifaEnvironment.Players);
            FifaEnvironment.Teams.LinkOpponent(FifaEnvironment.Teams);
            FifaEnvironment.Teams.LinkFormation(FifaEnvironment.Formations);
            int num1 = (int)FifaEnvironment.UserMessages.ShowMessage(15007);
            return true;
        }

        private bool BrowseOnline()
        {
            this.openFifaDialog = new OpenFileDialog();
            this.openFifaDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\FIFA 14";
            this.openFifaDialog.Filter = "Online Files|Squad*.*;FutSquads*.*;MatchDay*.*";
            this.openFifaDialog.FilterIndex = 1;
            this.openFifaDialog.Title = "Open DB Update file";
            bool flag = false;
            if (this.openFifaDialog.ShowDialog() == DialogResult.OK)
            {
                this.m_OnlineDbFileName = this.openFifaDialog.FileName;
                flag = true;
            }
            this.openFifaDialog.Dispose();
            return flag;
        }

        private bool BrowseOnlineFifa15()
        {
            this.openFifaDialog = new OpenFileDialog();
            this.openFifaDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\FIFA 15\\0\\FIFA15";
            this.openFifaDialog.Filter = "Online Files|DATA*";
            this.openFifaDialog.FilterIndex = 1;
            this.openFifaDialog.Title = "Open DB Update file";
            bool flag = false;
            if (this.openFifaDialog.ShowDialog() == DialogResult.OK)
            {
                this.m_OnlineDbFileName = this.openFifaDialog.FileName;
                flag = true;
            }
            this.openFifaDialog.Dispose();
            return flag;
        }

        private void uGContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FifaEnvironment.FifaXmlFileName != null)
                this.m_XmlDbFileName = FifaEnvironment.FifaXmlFileName;
            else if (!this.BrowseXmlDb())
                return;
            if (!this.BrowseUgc() || !this.OpenUgcFile())
                return;
            switch (FifaEnvironment.UserMessages.ShowMessage(29))
            {
                case DialogResult.Cancel:
                    break;
                case DialogResult.No:
                    break;
                default:
                    Cursor.Current = Cursors.WaitCursor;
                    this.m_UgcFile.UpdateRosters(this.m_XmlDbFileName, false, this.statusBar);
                    Cursor.Current = Cursors.Default;
                    break;
            }
        }

        private void menuAlignLanguageDB_Click(object sender, EventArgs e)
        {
            this.openLangDialog.CheckFileExists = true;
            this.openLangDialog.InitialDirectory = FifaEnvironment.GameDir + "data\\loc\\";
            this.openLangDialog.Filter = "db files (*.db)|*.db";
            this.openLangDialog.FilterIndex = 1;
            this.openLangDialog.Title = "Open Language Database";
            if (this.openLangDialog.ShowDialog() != DialogResult.OK)
                return;
            string fileName = this.openLangDialog.FileName;
            if (fileName == FifaEnvironment.LangDbFileName)
                return;
            DbFile dbFile = new DbFile(fileName, FifaEnvironment.LangXmlFileName);
            if (dbFile == null)
                return;
            Table table1 = FifaEnvironment.LangDb.Table[0];
            Table table2 = dbFile.Table[0];
            int index1 = 0;
            int[] numArray = new int[table1.NValidRecords];
            string[] strArray1 = new string[table1.NValidRecords];
            string[] strArray2 = new string[table1.NValidRecords];
            Cursor.Current = Cursors.WaitCursor;
            this.statusBar.Text = "Analizing the language database...";
            this.Refresh();
            for (int index2 = 0; index2 < table1.NValidRecords; ++index2)
            {
                Record record = table1.Records[index2];
                bool flag = false;
                for (int index3 = 0; index3 < table2.NValidRecords; ++index3)
                {
                    if (table1.Records[index3].IntField[FI.language_hashid] == record.IntField[FI.language_hashid])
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    numArray[index1] = record.IntField[FI.language_hashid];
                    strArray1[index1] = record.CompressedString[FI.language_sourcetext];
                    strArray2[index1] = record.CompressedString[FI.language_stringid];
                    ++index1;
                }
            }
            Cursor.Current = Cursors.Default;
            if (index1 > 0)
            {
                int nvalidRecords = table2.NValidRecords;
                table2.ResizeRecords(table2.NValidRecords + index1);
                for (int index2 = 0; index2 < index1; ++index2)
                {
                    table2.Records[nvalidRecords].IntField[FI.language_hashid] = numArray[index2];
                    table2.Records[nvalidRecords].CompressedString[FI.language_sourcetext] = strArray1[index2];
                    table2.Records[nvalidRecords].CompressedString[FI.language_stringid] = strArray2[index2];
                    ++nvalidRecords;
                }
                dbFile.SaveDb();
                this.statusBar.Text = fileName + " has been aligned.";
            }
            else
                this.statusBar.Text = fileName + " was already aligned.";
        }

        private void menuImportUgcPlayers_Click(object sender, EventArgs e)
        {
            if (FifaEnvironment.FifaXmlFileName != null)
                this.m_XmlDbFileName = FifaEnvironment.FifaXmlFileName;
            else if (!this.BrowseXmlDb())
                return;
            if (!this.BrowseUgc() || !this.OpenUgcFile())
                return;
            switch (FifaEnvironment.UserMessages.ShowMessage(29))
            {
                case DialogResult.Cancel:
                    break;
                case DialogResult.No:
                    break;
                default:
                    Cursor.Current = Cursors.WaitCursor;
                    this.m_UgcFile.ImportPlayers(this.m_XmlDbFileName, false, this.statusBar);
                    Cursor.Current = Cursors.Default;
                    break;
            }
        }

        private void minimizeNamesTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            foreach (PlayerName playerNames in (ArrayList)FifaEnvironment.PlayerNamesList)
                playerNames.IsOriginal = false;
            foreach (Player player in (ArrayList)FifaEnvironment.Players)
            {
                player.firstname = player.firstname.Trim();
                foreach (PlayerName playerNames in (ArrayList)FifaEnvironment.PlayerNamesList)
                {
                    if (playerNames.Text == player.firstname)
                    {
                        if (player.firstnameid != playerNames.Id)
                        {
                            if (playerNames.CommentaryId == 900000)
                            {
                                FifaEnvironment.PlayerNamesList.RemoveId(player.firstnameid);
                                player.firstnameid = playerNames.Id;
                                break;
                            }
                            break;
                        }
                        break;
                    }
                }
                player.lastname = player.lastname.Trim();
                foreach (PlayerName playerNames in (ArrayList)FifaEnvironment.PlayerNamesList)
                {
                    if (playerNames.Text == player.lastname)
                    {
                        if (player.lastnameid != playerNames.Id)
                        {
                            if (playerNames.CommentaryId == 900000)
                            {
                                FifaEnvironment.PlayerNamesList.RemoveId(player.lastnameid);
                                player.lastnameid = playerNames.Id;
                                break;
                            }
                            break;
                        }
                        break;
                    }
                }
                player.commonname = player.commonname.Trim();
                if (player.commonnameid != 0)
                {
                    if (player.commonname.IndexOf('.') >= 0)
                    {
                        if (player.playerjerseynameid == player.commonnameid)
                        {
                            player.playerjerseynameid = player.lastnameid;
                            player.playerjerseyname = player.lastname;
                        }
                        player.commonname = string.Empty;
                        player.commonnameid = 0;
                    }
                    else if (player.playerjerseynameid != player.commonnameid)
                    {
                        player.playerjerseynameid = player.commonnameid;
                        player.playerjerseyname = player.commonname;
                    }
                }
                foreach (PlayerName playerNames in (ArrayList)FifaEnvironment.PlayerNamesList)
                {
                    if (playerNames.Text == player.commonname)
                    {
                        if (player.commonnameid != playerNames.Id)
                        {
                            if (playerNames.CommentaryId == 900000)
                            {
                                FifaEnvironment.PlayerNamesList.RemoveId(player.commonnameid);
                                player.commonnameid = playerNames.Id;
                                break;
                            }
                            break;
                        }
                        break;
                    }
                }
                player.playerjerseyname = player.playerjerseyname.Trim();
                foreach (PlayerName playerNames in (ArrayList)FifaEnvironment.PlayerNamesList)
                {
                    if (playerNames.Text == player.playerjerseyname)
                    {
                        if (player.playerjerseynameid != playerNames.Id)
                        {
                            if (playerNames.CommentaryId == 900000)
                            {
                                FifaEnvironment.PlayerNamesList.RemoveId(player.playerjerseynameid);
                                player.playerjerseynameid = playerNames.Id;
                                break;
                            }
                            break;
                        }
                        break;
                    }
                }
            }
            foreach (Player player in (ArrayList)FifaEnvironment.Players)
            {
                if (player.firstnameid >= 29000)
                {
                    FifaEnvironment.PlayerNamesList.RemoveId(player.firstnameid);
                    player.firstnameid = FifaEnvironment.PlayerNamesList.GetKey(player.firstname);
                }
                if (player.lastnameid >= 29000)
                {
                    FifaEnvironment.PlayerNamesList.RemoveId(player.lastnameid);
                    player.lastnameid = FifaEnvironment.PlayerNamesList.GetKey(player.lastname);
                }
                if (player.commonnameid >= 29000)
                {
                    FifaEnvironment.PlayerNamesList.RemoveId(player.commonnameid);
                    player.commonnameid = FifaEnvironment.PlayerNamesList.GetKey(player.commonname);
                }
                if (player.playerjerseynameid >= 29000)
                {
                    FifaEnvironment.PlayerNamesList.RemoveId(player.playerjerseynameid);
                    player.playerjerseynameid = FifaEnvironment.PlayerNamesList.GetKey(player.playerjerseyname);
                }
            }
            Cursor.Current = Cursors.Default;
            this.statusBar.Text = "Names updated, " + (29000 - FifaEnvironment.PlayerNamesList.Count).ToString() + " names still availbale. Ready!";
            int num = (int)FifaEnvironment.UserMessages.ShowMessage(1036);
        }

        private void menuPreserveOriginalNames_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.statusBar.Text = "Comparing current names with original names...";
            this.Refresh();
            for (int index = 0; index < FifaEnvironment.PlayerNamesList.Count; ++index)
            {
                PlayerName playerNames = (PlayerName)FifaEnvironment.PlayerNamesList[index];
                PlayerName playerName = (PlayerName)FifaEnvironment.OriginalPlayerNamesList.SearchId(playerNames.Id);
                if (playerName != null)
                {
                    if (playerName.Text != playerNames.Text)
                    {
                        FifaEnvironment.PlayerNamesList.RemoveId(playerNames.Id);
                        playerName.IsOriginal = true;
                        FifaEnvironment.PlayerNamesList.InsertId((IdObject)playerName);
                        playerNames.Id = FifaEnvironment.PlayerNamesList.GetNewId();
                        FifaEnvironment.PlayerNamesList.InsertId((IdObject)playerNames);
                    }
                    else
                    {
                        playerNames.IsOriginal = true;
                        playerNames.CommentaryId = playerName.CommentaryId;
                    }
                }
            }
            this.statusBar.Text = "Recovering missed original names ...";
            this.Refresh();
            for (int index = 0; index < FifaEnvironment.OriginalPlayerNamesList.Count; ++index)
            {
                PlayerName originalPlayerNames = (PlayerName)FifaEnvironment.OriginalPlayerNamesList[index];
                if ((PlayerName)FifaEnvironment.PlayerNamesList.SearchId(originalPlayerNames.Id) == null)
                {
                    originalPlayerNames.IsOriginal = true;
                    FifaEnvironment.PlayerNamesList.InsertId((IdObject)originalPlayerNames);
                }
            }
            this.statusBar.Text = "Updating player names...";
            this.Refresh();
            foreach (Player player in (ArrayList)FifaEnvironment.Players)
            {
                PlayerName playerName1 = FifaEnvironment.OriginalPlayerNamesList.SearchName(player.firstname);
                if (playerName1 != null)
                {
                    player.firstnameid = playerName1.Id;
                }
                else
                {
                    PlayerName playerName2 = FifaEnvironment.PlayerNamesList.SearchName(player.firstname);
                    if (playerName2 != null)
                        player.firstnameid = playerName2.Id;
                }
                PlayerName playerName3 = FifaEnvironment.OriginalPlayerNamesList.SearchName(player.lastname);
                if (playerName3 != null)
                {
                    player.lastnameid = playerName3.Id;
                }
                else
                {
                    PlayerName playerName2 = FifaEnvironment.PlayerNamesList.SearchName(player.lastname);
                    if (playerName2 != null)
                        player.lastnameid = playerName2.Id;
                }
                PlayerName playerName4 = FifaEnvironment.OriginalPlayerNamesList.SearchName(player.commonname);
                if (playerName4 != null)
                {
                    player.commonnameid = playerName4.Id;
                }
                else
                {
                    PlayerName playerName2 = FifaEnvironment.PlayerNamesList.SearchName(player.commonname);
                    if (playerName2 != null)
                        player.commonnameid = playerName2.Id;
                }
                PlayerName playerName5 = FifaEnvironment.OriginalPlayerNamesList.SearchName(player.playerjerseyname);
                if (playerName5 != null)
                {
                    player.playerjerseynameid = playerName5.Id;
                }
                else
                {
                    PlayerName playerName2 = FifaEnvironment.PlayerNamesList.SearchName(player.playerjerseyname);
                    if (playerName2 != null)
                        player.playerjerseynameid = playerName2.Id;
                }
                player.UpdateNamesAndCommentary();
            }
            this.statusBar.Text = "Names updated, " + (29000 - FifaEnvironment.PlayerNamesList.Count).ToString() + " names still availbale. Ready!";
            Cursor.Current = Cursors.Default;
            int num = (int)FifaEnvironment.UserMessages.ShowMessage(1036);
        }

        private string RemoveDottedInitial(string text)
        {
            while (text.IndexOf('.') == 1)
                text = text.Substring(2);
            return text;
        }

        private void menuOnlineDBFifa15_Click(object sender, EventArgs e)
        {
            if (FifaEnvironment.FifaXmlFileName != null)
                this.m_XmlDbFileName = FifaEnvironment.FifaXmlFileName;
            else if (!this.BrowseXmlDb())
                return;
            if (!this.BrowseOnlineFifa15())
                return;
            Cursor.Current = Cursors.WaitCursor;
            this.m_OnlineDbFile = new CareerFile(this.m_OnlineDbFileName, this.m_XmlDbFileName);
            Cursor.Current = Cursors.Default;
            if (this.m_OnlineDbFile == null)
                return;
            if (this.m_OnlineDbFile.Databases[1] != null || this.m_OnlineDbFile.Databases[2] != null || this.m_OnlineDbFile.Databases[3] != null)
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(10036);
            }
            else
            {
                this.m_OnlineDb = this.m_OnlineDbFile.Databases[0];
                this.MergeOnlineDb();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!this.InitializeFifaEnvironment(15) || !this.AskUserOpenLangDatabase())
                return;
            this.Open();
        }
    }
}
