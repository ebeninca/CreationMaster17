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
  public class TeamForm : Form
  {
    private NewIdCreator m_NewIdCreator = new NewIdCreator();
    private Point m_LabelLocation = new Point(0, 0);
    private int m_BoundRight = 250;
    private int m_BoundBottom = 350;
    private IContainer components;
    public PickUpControl pickUpControl;
    private TabControl tableEditTeam;
    private TabPage pageTeamGeneric;
    private FlowLayoutPanel flowPanelTeamGeneric;
    private TabPage pageTeamRoster;
    private GroupBox groupBoxName;
    private TextBox textScoreBoardName;
    private TextBox textDatabaseTeamName;
    private TextBox textFullTeamName;
    private TextBox textStandardTeamName;
    private TextBox textShortTeamName;
    private Label labelDatabaseTeamName;
    private Label labelFullTeamName;
    private Label labelStandardTeamName;
    private Label labelShortTeamName;
    private Label labelScoreBoardName;
    private BindingSource teamBindingSource;
    private ToolTip toolTip;
    private GroupBox groupBox1;
    private ComboBox comboStadiums;
    private BindingSource stadiumListBindingSource;
    private Label labelStadium;
    private TextBox textStadiumName;
    private Label labelStadiumName;
    private GroupBox groupBox3;
    private ComboBox comboTeamCountry;
    private Label labelTeamCountry;
    private BindingSource countryListBindingSource;
    private Label labelOpponent;
    private BindingSource teamListBindingSource;
    private NumericStars numericStarsInternationalPrestige;
    private NumericStars numericStarsDomesticPrestige;
    private Label labelDomesticPrestige;
    private NumericUpDown numericInitialBudget;
    private Label labelInternationalPrestige;
    private Label labelInitialBudget;
    private PictureBox pictureTeamPrimColor;
    private PictureBox pictureTeamSecColor;
    private PictureBox pictureTeamTerColor;
    private ColorDialog colorDialog;
    private TabPage pageTeamAdboard;
    private TabPage pageTeamFlags;
    private BindingSource ballListBindingSource;
    public NumericUpDown numericAdboards;
    private Viewer2D viewer2DAdboards_0;
    private Label labelAdboard;
    private Viewer2D viewer2DBanners;
    private PictureBox pictureBall;
    private GroupBox groupAvailablePlayers;
    private ListView listViewPlayersAvailable;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    private ColumnHeader columnHeader3;
    private ColumnHeader columnHeader4;
    private Panel panelAvailablePlayersTop;
    private Button buttonTransferFrom;
    private PickUpControl pickUpAvailablePlayers;
    private Button buttonCall;
    private Label labelAvailablePlayerStars;
    private Label labelRosterNameFrom;
    private PictureBox pictureAvailablePlayer;
    private GroupBox groupTeamPlayers;
    private ListView listViewTeamPlayers;
    private ColumnHeader columnRosterNum;
    private ColumnHeader columnRosterSurname;
    private ColumnHeader columnRosterFirstName;
    private ColumnHeader columnRosterYearContract;
    private ColumnHeader columnPreferredRole;
    private ColumnHeader columnAverageAttributes;
    private Panel panelTeamPlayersTop;
    private NumericUpDown numericRosterYear;
    private Label labelTeamPlayerStars;
    private Label labelRosterName;
    private ComboBox comboRosterNumber;
    private Button buttonTransferPlayer;
    private Button buttonRosterLetFree;
    private Label labelRosterNumber;
    private ImageList imageListStars;
    private Label label1;
    private NumericUpDown numericBall;
    private Button buttonGetId;
    private NumericUpDown numericTeamId;
    private Label labelTeamId;
    private DateTimePicker dateJoiningDate;
    private Label labelJoiningDate;
    private BindingSource formationListBindingSource;
    private ImageList imageListPlayers;
    private Viewer2D viewer2DCrest32;
    private Viewer2D viewer2DCrestLarge;
    private Viewer2D viewer2DCrest16;
    private GroupBox groupBox2;
    private Label label15;
    private Button buttonReplicateLogo;
    private GroupBox groupManager;
    private TextBox textBox3;
    private Label label17;
    private TextBox textBox2;
    private Label label16;
    private ImageList imageListArrows;
    private GroupBox groupLastYear;
    private CheckBox checkIsChampion;
    private Label label19;
    private Label label18;
    private NumericUpDown numericPositionLastYear;
    private ComboBox comboPrevLeague;
    private BindingSource leagueListBindingSource;
    private Label labelLeague;
    private ComboBox comboTeamLeague;
    private BindingSource prevLeagueListBindingSource;
    private ComboBox comboRivalTeam;
    private ComboBox comboObjective;
    private Label labelObjective;
    private Label labelProbObjective;
    private Label labelMaxObjective;
    private ComboBox comboProbObjective;
    private ComboBox comboMaxOnjective;
    private GroupBox groupTeamTraits;
    private CheckBox checkShortOutBack;
    private CheckBox checkMoreAttackingAtHome;
    private CheckBox checkCenterBacksSplit;
    private CheckBox checkSwitchWingers;
    private CheckBox checkKeepUpPressure;
    private CheckBox checkDefendLead;
    private CheckBox checkConsistentLineup;
    private CheckBox checkSquadRotation;
    private CheckBox checkLoyalBoard;
    private CheckBox checkImpatientBoard;
    private Viewer2D viewer2DCrest50;
    private Button buttonMinusContract;
    private Button buttonPlusContract;
    private GroupBox groupTeamPlayerTuning;
    private Button buttonTeamPlayerMinus;
    private Button buttonTeamPlayerPlus;
    private GroupBox groupContract;
    private GroupBox groupFlag;
    private Label labelFlag1;
    private ImageList imageListFlags;
    private Label labelFlag4;
    private Label labelFlag3;
    private Label labelFlag2;
    private CheckBox checkFlag4;
    private CheckBox checkFlag3;
    private CheckBox checkFlag2;
    private CheckBox checkFlag1;
    private PictureBox pictureBox4;
    private Label label22;
    private PictureBox pictureFlagBlue;
    private PictureBox pictureFlagRed;
    private PictureBox pictureFlagGreen;
    private Button buttonCreateFlags;
    private CheckBox checkHasSpecificAdboard;
    private GroupBox groupLocation;
    private Label label25;
    private Label label24;
    private Label label23;
    private MultiViewer2D multiViewer2DFlags15;
    private Panel panel1;
    private Label labelPos33U;
    private Label labelPos33T;
    private Label labelPos33S;
    private Label labelPos33R;
    private Label labelPos33Q;
    private Label labelPos33O;
    private Label labelPos33P;
    private Label labelPos33N;
    private Label labelPos33M;
    private Label labelPos33L;
    private Label labelPos33K;
    private Label labelPos33J;
    private Label labelPos33H;
    private Label labelPos33I;
    private Label labelPos33G;
    private Label labelPos33F;
    private Label labelPos33E;
    private Label labelPos33D;
    private Label labelPos33C;
    private Label labelPos33A;
    private Label labelPos33B;
    private Label labelPos32G;
    private Label labelPos32F;
    private Label labelPos32E;
    private Label labelPos32D;
    private Label labelPos32C;
    private Label labelPos32A;
    private Label labelPos32B;
    private Label labelPos26;
    private Label labelPos27;
    private Label labelPos21;
    private Label labelPos22;
    private Label labelPos23;
    private Label labelPos24;
    private Label labelPos25;
    private Label labelPos14;
    private Label labelPos15;
    private Label labelPos16;
    private Label labelPos17;
    private Label labelPos18;
    private Label labelPos20;
    private Label labelPos19;
    private Label labelPos9;
    private Label labelPos10;
    private Label labelPos11;
    private Label labelPos12;
    private Label labelPos13;
    private Label labelPos2;
    private Label labelPos3;
    private Label labelPos4;
    private Label labelPos5;
    private Label labelPos6;
    private Label labelPos8;
    private Label labelPos7;
    private Label labelPos0;
    private Label labelPos1;
    private Label label20;
    private NumericUpDown numericUpDown2;
    private ComboBox comboDEFLine;
    private NumericUpDown numericDefteamwidth;
    private NumericUpDown numericDefaggression;
    private NumericUpDown numericDefmentality;
    private Label labelDefdefendeline;
    private Label labelDefteamwidth;
    private Label labelDefaggression;
    private Label labelDefmentality;
    private ComboBox comboCCPositioning;
    private NumericUpDown numericCcshooting;
    private NumericUpDown numericCccrossing;
    private NumericUpDown numericCcpassing;
    private Label labelCcpositioning;
    private Label labelCcshooting;
    private Label labelCccrossing;
    private Label labelCcpassing;
    private ComboBox comboBUSPositioning;
    private NumericUpDown numericBuspassing;
    private NumericUpDown numericBusbuildupspeed;
    private Label labelBuspositioning;
    private Label labelBuspassing;
    private Label labelBusbuildupspeed;
    private GroupBox groupBox6;
    private GroupBox groupBox5;
    private GroupBox groupBox4;
    private Label labelRightFreeKickText;
    private Label labelRightFreeKick;
    private Label labelLeftFreeKickText;
    private Label labelLeftFreeKick;
    private GroupBox groupFormation;
    private ComboBox comboGenericFormations;
    private RadioButton radioUseSpecificFormation;
    private RadioButton radioUseGenericFormation;
    private Label labelLongKick;
    private Label labelLomgKickText;
    private Label labelRightCornerText;
    private Label labelCaptainTetx;
    private Label labelLeftCornertext;
    private Label labelRightCorner;
    private Label labelCaptain;
    private Label labelLeftCorner;
    private Label labelFreeKickText;
    private Label labelPenaltyText;
    private Label labelPenalty;
    private Label labelFreeKick;
    private Label labelTeamFormationName;
    private Label label2;
    private Viewer2D viewer2DPhoto;
    private Label label3;
    private TextBox textTeamName7;
    private NumericUpDown numericUtcOffset;
    private NumericUpDown numericLongitude;
    private NumericUpDown numericLatitude;
    public Team m_CurrentTeam;
    private TabPage m_CurrentPage;
    private Formation m_CurrentFormation;
    private Formation m_BackupSpecificFormation;
    private bool m_IsLoaded;
    private TeamPlayer m_CurrentTeamPlayer;
    private Player m_CurrentAvailablePlayer;
    private Team m_CurrentAvailableTeam;
    private bool m_AvailablePlayerLocked;
    private bool m_ChangeNumberFlag;
    private Label m_DraggedLabel;
    private int m_BoundLeft;
    private int m_BoundTop;
    private bool m_LockUserChanges;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager resources = new ComponentResourceManager(typeof (TeamForm));
      this.tableEditTeam = new TabControl();
      this.pageTeamGeneric = new TabPage();
      this.flowPanelTeamGeneric = new FlowLayoutPanel();
      this.groupBox2 = new GroupBox();
      this.viewer2DCrest50 = new Viewer2D();
      this.buttonReplicateLogo = new Button();
      this.viewer2DCrestLarge = new Viewer2D();
      this.viewer2DCrest16 = new Viewer2D();
      this.viewer2DCrest32 = new Viewer2D();
      this.groupBoxName = new GroupBox();
      this.label3 = new Label();
      this.textTeamName7 = new TextBox();
      this.teamBindingSource = new BindingSource(this.components);
      this.textScoreBoardName = new TextBox();
      this.textDatabaseTeamName = new TextBox();
      this.textFullTeamName = new TextBox();
      this.textStandardTeamName = new TextBox();
      this.textShortTeamName = new TextBox();
      this.labelDatabaseTeamName = new Label();
      this.labelFullTeamName = new Label();
      this.labelStandardTeamName = new Label();
      this.labelShortTeamName = new Label();
      this.labelScoreBoardName = new Label();
      this.groupBox1 = new GroupBox();
      this.textStadiumName = new TextBox();
      this.labelStadiumName = new Label();
      this.comboStadiums = new ComboBox();
      this.stadiumListBindingSource = new BindingSource(this.components);
      this.labelStadium = new Label();
      this.groupManager = new GroupBox();
      this.textBox3 = new TextBox();
      this.label17 = new Label();
      this.textBox2 = new TextBox();
      this.label16 = new Label();
      this.groupBox3 = new GroupBox();
      this.labelProbObjective = new Label();
      this.labelMaxObjective = new Label();
      this.comboProbObjective = new ComboBox();
      this.comboMaxOnjective = new ComboBox();
      this.comboObjective = new ComboBox();
      this.labelObjective = new Label();
      this.comboTeamLeague = new ComboBox();
      this.leagueListBindingSource = new BindingSource(this.components);
      this.labelLeague = new Label();
      this.label15 = new Label();
      this.buttonGetId = new Button();
      this.pictureTeamTerColor = new PictureBox();
      this.label1 = new Label();
      this.comboRivalTeam = new ComboBox();
      this.pictureTeamPrimColor = new PictureBox();
      this.pictureTeamSecColor = new PictureBox();
      this.numericTeamId = new NumericUpDown();
      this.numericBall = new NumericUpDown();
      this.labelTeamId = new Label();
      this.pictureBall = new PictureBox();
      this.comboTeamCountry = new ComboBox();
      this.countryListBindingSource = new BindingSource(this.components);
      this.numericStarsInternationalPrestige = new NumericStars();
      this.labelTeamCountry = new Label();
      this.labelOpponent = new Label();
      this.labelDomesticPrestige = new Label();
      this.numericStarsDomesticPrestige = new NumericStars();
      this.labelInitialBudget = new Label();
      this.labelInternationalPrestige = new Label();
      this.numericInitialBudget = new NumericUpDown();
      this.groupLastYear = new GroupBox();
      this.comboPrevLeague = new ComboBox();
      this.numericPositionLastYear = new NumericUpDown();
      this.checkIsChampion = new CheckBox();
      this.label19 = new Label();
      this.label18 = new Label();
      this.groupLocation = new GroupBox();
      this.numericUtcOffset = new NumericUpDown();
      this.numericLongitude = new NumericUpDown();
      this.numericLatitude = new NumericUpDown();
      this.label25 = new Label();
      this.label24 = new Label();
      this.label23 = new Label();
      this.groupTeamTraits = new GroupBox();
      this.checkShortOutBack = new CheckBox();
      this.checkMoreAttackingAtHome = new CheckBox();
      this.checkCenterBacksSplit = new CheckBox();
      this.checkSwitchWingers = new CheckBox();
      this.checkKeepUpPressure = new CheckBox();
      this.checkDefendLead = new CheckBox();
      this.checkConsistentLineup = new CheckBox();
      this.checkSquadRotation = new CheckBox();
      this.checkLoyalBoard = new CheckBox();
      this.checkImpatientBoard = new CheckBox();
      this.pageTeamRoster = new TabPage();
      this.groupBox6 = new GroupBox();
      this.labelCcpositioning = new Label();
      this.labelCcpassing = new Label();
      this.labelCccrossing = new Label();
      this.labelCcshooting = new Label();
      this.numericCcpassing = new NumericUpDown();
      this.numericCccrossing = new NumericUpDown();
      this.numericCcshooting = new NumericUpDown();
      this.comboCCPositioning = new ComboBox();
      this.groupBox5 = new GroupBox();
      this.labelBuspositioning = new Label();
      this.labelBusbuildupspeed = new Label();
      this.labelBuspassing = new Label();
      this.numericBusbuildupspeed = new NumericUpDown();
      this.numericBuspassing = new NumericUpDown();
      this.comboBUSPositioning = new ComboBox();
      this.numericUpDown2 = new NumericUpDown();
      this.label20 = new Label();
      this.groupBox4 = new GroupBox();
      this.labelDefdefendeline = new Label();
      this.labelDefmentality = new Label();
      this.labelDefaggression = new Label();
      this.labelDefteamwidth = new Label();
      this.numericDefmentality = new NumericUpDown();
      this.numericDefaggression = new NumericUpDown();
      this.numericDefteamwidth = new NumericUpDown();
      this.comboDEFLine = new ComboBox();
      this.labelRightFreeKickText = new Label();
      this.labelRightFreeKick = new Label();
      this.labelLeftFreeKickText = new Label();
      this.labelLeftFreeKick = new Label();
      this.groupFormation = new GroupBox();
      this.labelTeamFormationName = new Label();
      this.comboGenericFormations = new ComboBox();
      this.radioUseSpecificFormation = new RadioButton();
      this.radioUseGenericFormation = new RadioButton();
      this.labelLongKick = new Label();
      this.labelLomgKickText = new Label();
      this.labelRightCornerText = new Label();
      this.labelCaptainTetx = new Label();
      this.labelLeftCornertext = new Label();
      this.labelRightCorner = new Label();
      this.labelCaptain = new Label();
      this.labelLeftCorner = new Label();
      this.labelFreeKickText = new Label();
      this.labelPenaltyText = new Label();
      this.labelPenalty = new Label();
      this.labelFreeKick = new Label();
      this.panel1 = new Panel();
      this.labelPos33U = new Label();
      this.labelPos33T = new Label();
      this.labelPos33S = new Label();
      this.labelPos33R = new Label();
      this.labelPos33Q = new Label();
      this.labelPos33O = new Label();
      this.labelPos33P = new Label();
      this.labelPos33N = new Label();
      this.labelPos33M = new Label();
      this.labelPos33L = new Label();
      this.labelPos33K = new Label();
      this.labelPos33J = new Label();
      this.labelPos33H = new Label();
      this.labelPos33I = new Label();
      this.labelPos33G = new Label();
      this.labelPos33F = new Label();
      this.labelPos33E = new Label();
      this.labelPos33D = new Label();
      this.labelPos33C = new Label();
      this.labelPos33A = new Label();
      this.labelPos33B = new Label();
      this.labelPos32G = new Label();
      this.labelPos32F = new Label();
      this.labelPos32E = new Label();
      this.labelPos32D = new Label();
      this.labelPos32C = new Label();
      this.labelPos32A = new Label();
      this.labelPos32B = new Label();
      this.labelPos26 = new Label();
      this.labelPos27 = new Label();
      this.labelPos21 = new Label();
      this.labelPos22 = new Label();
      this.labelPos23 = new Label();
      this.labelPos24 = new Label();
      this.labelPos25 = new Label();
      this.labelPos14 = new Label();
      this.labelPos15 = new Label();
      this.labelPos16 = new Label();
      this.labelPos17 = new Label();
      this.labelPos18 = new Label();
      this.labelPos20 = new Label();
      this.labelPos19 = new Label();
      this.labelPos9 = new Label();
      this.labelPos10 = new Label();
      this.labelPos11 = new Label();
      this.labelPos12 = new Label();
      this.labelPos13 = new Label();
      this.labelPos2 = new Label();
      this.labelPos3 = new Label();
      this.labelPos4 = new Label();
      this.labelPos5 = new Label();
      this.labelPos6 = new Label();
      this.labelPos8 = new Label();
      this.labelPos7 = new Label();
      this.labelPos0 = new Label();
      this.labelPos1 = new Label();
      this.groupAvailablePlayers = new GroupBox();
      this.listViewPlayersAvailable = new ListView();
      this.columnHeader1 = new ColumnHeader();
      this.columnHeader2 = new ColumnHeader();
      this.columnHeader3 = new ColumnHeader();
      this.columnHeader4 = new ColumnHeader();
      this.panelAvailablePlayersTop = new Panel();
      this.buttonTransferFrom = new Button();
      this.pickUpAvailablePlayers = new PickUpControl();
      this.buttonCall = new Button();
      this.labelAvailablePlayerStars = new Label();
      this.imageListStars = new ImageList(this.components);
      this.labelRosterNameFrom = new Label();
      this.pictureAvailablePlayer = new PictureBox();
      this.groupTeamPlayers = new GroupBox();
      this.listViewTeamPlayers = new ListView();
      this.columnRosterNum = new ColumnHeader();
      this.columnRosterSurname = new ColumnHeader();
      this.columnRosterFirstName = new ColumnHeader();
      this.columnRosterYearContract = new ColumnHeader();
      this.columnPreferredRole = new ColumnHeader();
      this.columnAverageAttributes = new ColumnHeader();
      this.panelTeamPlayersTop = new Panel();
      this.viewer2DPhoto = new Viewer2D();
      this.groupTeamPlayerTuning = new GroupBox();
      this.buttonTeamPlayerMinus = new Button();
      this.buttonTeamPlayerPlus = new Button();
      this.labelTeamPlayerStars = new Label();
      this.groupContract = new GroupBox();
      this.label2 = new Label();
      this.buttonPlusContract = new Button();
      this.buttonMinusContract = new Button();
      this.dateJoiningDate = new DateTimePicker();
      this.numericRosterYear = new NumericUpDown();
      this.labelJoiningDate = new Label();
      this.labelRosterName = new Label();
      this.comboRosterNumber = new ComboBox();
      this.buttonTransferPlayer = new Button();
      this.buttonRosterLetFree = new Button();
      this.labelRosterNumber = new Label();
      this.pageTeamAdboard = new TabPage();
      this.numericAdboards = new NumericUpDown();
      this.checkHasSpecificAdboard = new CheckBox();
      this.labelAdboard = new Label();
      this.viewer2DAdboards_0 = new Viewer2D();
      this.pageTeamFlags = new TabPage();
      this.groupFlag = new GroupBox();
      this.multiViewer2DFlags15 = new MultiViewer2D();
      this.buttonCreateFlags = new Button();
      this.pictureBox4 = new PictureBox();
      this.label22 = new Label();
      this.pictureFlagBlue = new PictureBox();
      this.pictureFlagRed = new PictureBox();
      this.pictureFlagGreen = new PictureBox();
      this.checkFlag4 = new CheckBox();
      this.checkFlag3 = new CheckBox();
      this.checkFlag2 = new CheckBox();
      this.checkFlag1 = new CheckBox();
      this.labelFlag4 = new Label();
      this.imageListFlags = new ImageList(this.components);
      this.labelFlag3 = new Label();
      this.labelFlag2 = new Label();
      this.labelFlag1 = new Label();
      this.viewer2DBanners = new Viewer2D();
      this.toolTip = new ToolTip(this.components);
      this.colorDialog = new ColorDialog();
      this.imageListPlayers = new ImageList(this.components);
      this.imageListArrows = new ImageList(this.components);
      this.pickUpControl = new PickUpControl();
      this.teamListBindingSource = new BindingSource(this.components);
      this.formationListBindingSource = new BindingSource(this.components);
      this.ballListBindingSource = new BindingSource(this.components);
      this.prevLeagueListBindingSource = new BindingSource(this.components);
      this.tableEditTeam.SuspendLayout();
      this.pageTeamGeneric.SuspendLayout();
      this.flowPanelTeamGeneric.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBoxName.SuspendLayout();
      ((ISupportInitialize) this.teamBindingSource).BeginInit();
      this.groupBox1.SuspendLayout();
      ((ISupportInitialize) this.stadiumListBindingSource).BeginInit();
      this.groupManager.SuspendLayout();
      this.groupBox3.SuspendLayout();
      ((ISupportInitialize) this.leagueListBindingSource).BeginInit();
      ((ISupportInitialize) this.pictureTeamTerColor).BeginInit();
      ((ISupportInitialize) this.pictureTeamPrimColor).BeginInit();
      ((ISupportInitialize) this.pictureTeamSecColor).BeginInit();
      this.numericTeamId.BeginInit();
      this.numericBall.BeginInit();
      ((ISupportInitialize) this.pictureBall).BeginInit();
      ((ISupportInitialize) this.countryListBindingSource).BeginInit();
      this.numericInitialBudget.BeginInit();
      this.groupLastYear.SuspendLayout();
      this.numericPositionLastYear.BeginInit();
      this.groupLocation.SuspendLayout();
      this.numericUtcOffset.BeginInit();
      this.numericLongitude.BeginInit();
      this.numericLatitude.BeginInit();
      this.groupTeamTraits.SuspendLayout();
      this.pageTeamRoster.SuspendLayout();
      this.groupBox6.SuspendLayout();
      this.numericCcpassing.BeginInit();
      this.numericCccrossing.BeginInit();
      this.numericCcshooting.BeginInit();
      this.groupBox5.SuspendLayout();
      this.numericBusbuildupspeed.BeginInit();
      this.numericBuspassing.BeginInit();
      this.numericUpDown2.BeginInit();
      this.groupBox4.SuspendLayout();
      this.numericDefmentality.BeginInit();
      this.numericDefaggression.BeginInit();
      this.numericDefteamwidth.BeginInit();
      this.groupFormation.SuspendLayout();
      this.panel1.SuspendLayout();
      this.groupAvailablePlayers.SuspendLayout();
      this.panelAvailablePlayersTop.SuspendLayout();
      ((ISupportInitialize) this.pictureAvailablePlayer).BeginInit();
      this.groupTeamPlayers.SuspendLayout();
      this.panelTeamPlayersTop.SuspendLayout();
      this.groupTeamPlayerTuning.SuspendLayout();
      this.groupContract.SuspendLayout();
      this.numericRosterYear.BeginInit();
      this.pageTeamAdboard.SuspendLayout();
      this.numericAdboards.BeginInit();
      this.pageTeamFlags.SuspendLayout();
      this.groupFlag.SuspendLayout();
      ((ISupportInitialize) this.pictureBox4).BeginInit();
      ((ISupportInitialize) this.pictureFlagBlue).BeginInit();
      ((ISupportInitialize) this.pictureFlagRed).BeginInit();
      ((ISupportInitialize) this.pictureFlagGreen).BeginInit();
      ((ISupportInitialize) this.teamListBindingSource).BeginInit();
      ((ISupportInitialize) this.formationListBindingSource).BeginInit();
      ((ISupportInitialize) this.ballListBindingSource).BeginInit();
      ((ISupportInitialize) this.prevLeagueListBindingSource).BeginInit();
      this.SuspendLayout();
      this.tableEditTeam.Controls.Add((Control) this.pageTeamGeneric);
      this.tableEditTeam.Controls.Add((Control) this.pageTeamRoster);
      this.tableEditTeam.Controls.Add((Control) this.pageTeamAdboard);
      this.tableEditTeam.Controls.Add((Control) this.pageTeamFlags);
      this.tableEditTeam.Dock = DockStyle.Fill;
      this.tableEditTeam.Location = new Point(0, 25);
      this.tableEditTeam.Name = "tableEditTeam";
      this.tableEditTeam.SelectedIndex = 0;
      this.tableEditTeam.Size = new Size(1357, 807);
      this.tableEditTeam.TabIndex = 5;
      this.tableEditTeam.SelectedIndexChanged += new EventHandler(this.tableEditTeam_SelectedIndexChanged);
      this.pageTeamGeneric.AutoScroll = true;
      this.pageTeamGeneric.Controls.Add((Control) this.flowPanelTeamGeneric);
      this.pageTeamGeneric.Location = new Point(4, 22);
      this.pageTeamGeneric.Name = "pageTeamGeneric";
      this.pageTeamGeneric.Padding = new Padding(3);
      this.pageTeamGeneric.Size = new Size(1349, 781);
      this.pageTeamGeneric.TabIndex = 0;
      this.pageTeamGeneric.Text = "Generic";
      this.pageTeamGeneric.UseVisualStyleBackColor = true;
      this.flowPanelTeamGeneric.AutoScroll = true;
      this.flowPanelTeamGeneric.Controls.Add((Control) this.groupBox2);
      this.flowPanelTeamGeneric.Controls.Add((Control) this.groupBoxName);
      this.flowPanelTeamGeneric.Controls.Add((Control) this.groupBox1);
      this.flowPanelTeamGeneric.Controls.Add((Control) this.groupManager);
      this.flowPanelTeamGeneric.Controls.Add((Control) this.groupBox3);
      this.flowPanelTeamGeneric.Controls.Add((Control) this.groupLastYear);
      this.flowPanelTeamGeneric.Controls.Add((Control) this.groupLocation);
      this.flowPanelTeamGeneric.Controls.Add((Control) this.groupTeamTraits);
      this.flowPanelTeamGeneric.Dock = DockStyle.Fill;
      this.flowPanelTeamGeneric.FlowDirection = FlowDirection.TopDown;
      this.flowPanelTeamGeneric.Location = new Point(3, 3);
      this.flowPanelTeamGeneric.Name = "flowPanelTeamGeneric";
      this.flowPanelTeamGeneric.Size = new Size(1343, 775);
      this.flowPanelTeamGeneric.TabIndex = 0;
      this.groupBox2.Controls.Add((Control) this.viewer2DCrest50);
      this.groupBox2.Controls.Add((Control) this.buttonReplicateLogo);
      this.groupBox2.Controls.Add((Control) this.viewer2DCrestLarge);
      this.groupBox2.Controls.Add((Control) this.viewer2DCrest16);
      this.groupBox2.Controls.Add((Control) this.viewer2DCrest32);
      this.groupBox2.Location = new Point(3, 3);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(270, 445);
      this.groupBox2.TabIndex = 12;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Logos";
      this.viewer2DCrest50.AutoTransparency = true;
      this.viewer2DCrest50.BackColor = Color.Transparent;
      this.viewer2DCrest50.ButtonStripVisible = false;
      this.viewer2DCrest50.CurrentBitmap = (Bitmap) null;
      this.viewer2DCrest50.ExtendedFormat = false;
      this.viewer2DCrest50.FullSizeButton = false;
      this.viewer2DCrest50.ImageLayout = ImageLayout.Center;
      this.viewer2DCrest50.ImageSize = new Size(64, 64);
      this.viewer2DCrest50.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DCrest50.Location = new Point(7, 306);
      this.viewer2DCrest50.Name = "viewer2DCrest50";
      this.viewer2DCrest50.RemoveButton = false;
      this.viewer2DCrest50.ShowButton = false;
      this.viewer2DCrest50.ShowButtonChecked = true;
      this.viewer2DCrest50.Size = new Size(64, 89);
      this.viewer2DCrest50.TabIndex = 151;
      this.viewer2DCrest50.TabStop = false;
      this.toolTip.SetToolTip((Control) this.viewer2DCrest50, "Crest 50x50");
      this.buttonReplicateLogo.Location = new Point(78, 403);
      this.buttonReplicateLogo.Name = "buttonReplicateLogo";
      this.buttonReplicateLogo.Size = new Size(117, 25);
      this.buttonReplicateLogo.TabIndex = 150;
      this.buttonReplicateLogo.Text = "Replicate";
      this.buttonReplicateLogo.UseVisualStyleBackColor = true;
      this.buttonReplicateLogo.Click += new EventHandler(this.buttonReplicateLogo_Click);
      this.viewer2DCrestLarge.AutoTransparency = true;
      this.viewer2DCrestLarge.BackColor = Color.Transparent;
      this.viewer2DCrestLarge.ButtonStripVisible = false;
      this.viewer2DCrestLarge.CurrentBitmap = (Bitmap) null;
      this.viewer2DCrestLarge.ExtendedFormat = false;
      this.viewer2DCrestLarge.FullSizeButton = false;
      this.viewer2DCrestLarge.ImageLayout = ImageLayout.None;
      this.viewer2DCrestLarge.ImageSize = new Size(256, 256);
      this.viewer2DCrestLarge.ImageSizeMultiplier = Viewer2D.SizeMultiplier.Auto256;
      this.viewer2DCrestLarge.Location = new Point(6, 19);
      this.viewer2DCrestLarge.Name = "viewer2DCrestLarge";
      this.viewer2DCrestLarge.RemoveButton = false;
      this.viewer2DCrestLarge.ShowButton = false;
      this.viewer2DCrestLarge.ShowButtonChecked = true;
      this.viewer2DCrestLarge.Size = new Size(256, 281);
      this.viewer2DCrestLarge.TabIndex = 149;
      this.viewer2DCrestLarge.TabStop = false;
      this.toolTip.SetToolTip((Control) this.viewer2DCrestLarge, "Country Map");
      this.viewer2DCrest16.AutoTransparency = true;
      this.viewer2DCrest16.BackColor = Color.Transparent;
      this.viewer2DCrest16.ButtonStripVisible = false;
      this.viewer2DCrest16.CurrentBitmap = (Bitmap) null;
      this.viewer2DCrest16.ExtendedFormat = false;
      this.viewer2DCrest16.FullSizeButton = false;
      this.viewer2DCrest16.ImageLayout = ImageLayout.Center;
      this.viewer2DCrest16.ImageSize = new Size(16, 16);
      this.viewer2DCrest16.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DCrest16.Location = new Point(194, 306);
      this.viewer2DCrest16.Name = "viewer2DCrest16";
      this.viewer2DCrest16.RemoveButton = false;
      this.viewer2DCrest16.ShowButton = false;
      this.viewer2DCrest16.ShowButtonChecked = true;
      this.viewer2DCrest16.Size = new Size(64, 89);
      this.viewer2DCrest16.TabIndex = 148;
      this.viewer2DCrest16.TabStop = false;
      this.toolTip.SetToolTip((Control) this.viewer2DCrest16, "Crest 16x16");
      this.viewer2DCrest32.AutoTransparency = true;
      this.viewer2DCrest32.BackColor = Color.Transparent;
      this.viewer2DCrest32.ButtonStripVisible = false;
      this.viewer2DCrest32.CurrentBitmap = (Bitmap) null;
      this.viewer2DCrest32.ExtendedFormat = false;
      this.viewer2DCrest32.FullSizeButton = false;
      this.viewer2DCrest32.ImageLayout = ImageLayout.Center;
      this.viewer2DCrest32.ImageSize = new Size(32, 32);
      this.viewer2DCrest32.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DCrest32.Location = new Point(102, 306);
      this.viewer2DCrest32.Name = "viewer2DCrest32";
      this.viewer2DCrest32.RemoveButton = false;
      this.viewer2DCrest32.ShowButton = false;
      this.viewer2DCrest32.ShowButtonChecked = true;
      this.viewer2DCrest32.Size = new Size(64, 89);
      this.viewer2DCrest32.TabIndex = 147;
      this.viewer2DCrest32.TabStop = false;
      this.toolTip.SetToolTip((Control) this.viewer2DCrest32, "Crest 32x32");
      this.groupBoxName.Controls.Add((Control) this.label3);
      this.groupBoxName.Controls.Add((Control) this.textTeamName7);
      this.groupBoxName.Controls.Add((Control) this.textScoreBoardName);
      this.groupBoxName.Controls.Add((Control) this.textDatabaseTeamName);
      this.groupBoxName.Controls.Add((Control) this.textFullTeamName);
      this.groupBoxName.Controls.Add((Control) this.textStandardTeamName);
      this.groupBoxName.Controls.Add((Control) this.textShortTeamName);
      this.groupBoxName.Controls.Add((Control) this.labelDatabaseTeamName);
      this.groupBoxName.Controls.Add((Control) this.labelFullTeamName);
      this.groupBoxName.Controls.Add((Control) this.labelStandardTeamName);
      this.groupBoxName.Controls.Add((Control) this.labelShortTeamName);
      this.groupBoxName.Controls.Add((Control) this.labelScoreBoardName);
      this.groupBoxName.Location = new Point(3, 454);
      this.groupBoxName.Name = "groupBoxName";
      this.groupBoxName.Size = new Size(270, 160);
      this.groupBoxName.TabIndex = 0;
      this.groupBoxName.TabStop = false;
      this.groupBoxName.Text = "Name";
      this.label3.Cursor = Cursors.Hand;
      this.label3.ImeMode = ImeMode.NoControl;
      this.label3.Location = new Point(4, 107);
      this.label3.Name = "label3";
      this.label3.Size = new Size(88, 20);
      this.label3.TabIndex = 56;
      this.label3.Text = "Name (7 chars)";
      this.label3.TextAlign = ContentAlignment.MiddleLeft;
      this.toolTip.SetToolTip((Control) this.label3, "Double click to fill automatically");
      this.label3.Click += new EventHandler(this.label3_Click);
      this.label3.DoubleClick += new EventHandler(this.labelTeamName7_DoubleClick);
      this.textTeamName7.DataBindings.Add(new Binding("Text", (object) this.teamBindingSource, "TeamNameAbbr7", true));
      this.textTeamName7.Location = new Point(98, 107);
      this.textTeamName7.Name = "textTeamName7";
      this.textTeamName7.Size = new Size(160, 20);
      this.textTeamName7.TabIndex = 4;
      this.textTeamName7.TextChanged += new EventHandler(this.textTeamName7_TextChanged);
      this.teamBindingSource.DataSource = (object) typeof (Team);
      this.textScoreBoardName.DataBindings.Add(new Binding("Text", (object) this.teamBindingSource, "TeamNameAbbr3", true));
      this.textScoreBoardName.Location = new Point(98, 130);
      this.textScoreBoardName.Name = "textScoreBoardName";
      this.textScoreBoardName.Size = new Size(160, 20);
      this.textScoreBoardName.TabIndex = 5;
      this.textScoreBoardName.TextAlign = HorizontalAlignment.Center;
      this.textDatabaseTeamName.DataBindings.Add(new Binding("Text", (object) this.teamBindingSource, "DatabaseName", true));
      this.textDatabaseTeamName.Location = new Point(98, 15);
      this.textDatabaseTeamName.Name = "textDatabaseTeamName";
      this.textDatabaseTeamName.Size = new Size(160, 20);
      this.textDatabaseTeamName.TabIndex = 0;
      this.textFullTeamName.DataBindings.Add(new Binding("Text", (object) this.teamBindingSource, "TeamNameFull", true));
      this.textFullTeamName.Location = new Point(98, 38);
      this.textFullTeamName.Name = "textFullTeamName";
      this.textFullTeamName.Size = new Size(160, 20);
      this.textFullTeamName.TabIndex = 1;
      this.textStandardTeamName.DataBindings.Add(new Binding("Text", (object) this.teamBindingSource, "TeamNameAbbr15", true));
      this.textStandardTeamName.Location = new Point(98, 61);
      this.textStandardTeamName.Name = "textStandardTeamName";
      this.textStandardTeamName.Size = new Size(160, 20);
      this.textStandardTeamName.TabIndex = 2;
      this.textStandardTeamName.TextChanged += new EventHandler(this.textStandardTeamName_TextChanged);
      this.textShortTeamName.DataBindings.Add(new Binding("Text", (object) this.teamBindingSource, "TeamNameAbbr10", true));
      this.textShortTeamName.Location = new Point(98, 84);
      this.textShortTeamName.Name = "textShortTeamName";
      this.textShortTeamName.Size = new Size(160, 20);
      this.textShortTeamName.TabIndex = 3;
      this.textShortTeamName.TextChanged += new EventHandler(this.textShortTeamName_TextChanged);
      this.labelDatabaseTeamName.ImeMode = ImeMode.NoControl;
      this.labelDatabaseTeamName.Location = new Point(4, 15);
      this.labelDatabaseTeamName.Name = "labelDatabaseTeamName";
      this.labelDatabaseTeamName.Size = new Size(89, 20);
      this.labelDatabaseTeamName.TabIndex = 4;
      this.labelDatabaseTeamName.Text = "Database Name";
      this.labelDatabaseTeamName.TextAlign = ContentAlignment.MiddleLeft;
      this.labelFullTeamName.ImeMode = ImeMode.NoControl;
      this.labelFullTeamName.Location = new Point(4, 38);
      this.labelFullTeamName.Name = "labelFullTeamName";
      this.labelFullTeamName.Size = new Size(87, 20);
      this.labelFullTeamName.TabIndex = 52;
      this.labelFullTeamName.Text = "Full Name";
      this.labelFullTeamName.TextAlign = ContentAlignment.MiddleLeft;
      this.labelStandardTeamName.Cursor = Cursors.Hand;
      this.labelStandardTeamName.ImeMode = ImeMode.NoControl;
      this.labelStandardTeamName.Location = new Point(4, 61);
      this.labelStandardTeamName.Name = "labelStandardTeamName";
      this.labelStandardTeamName.Size = new Size(93, 20);
      this.labelStandardTeamName.TabIndex = 5;
      this.labelStandardTeamName.Text = "Name (15 chars)";
      this.labelStandardTeamName.TextAlign = ContentAlignment.MiddleLeft;
      this.toolTip.SetToolTip((Control) this.labelStandardTeamName, "Double click to fill automatically");
      this.labelStandardTeamName.DoubleClick += new EventHandler(this.labelStandardTeamName_DoubleClick);
      this.labelShortTeamName.Cursor = Cursors.Hand;
      this.labelShortTeamName.ImeMode = ImeMode.NoControl;
      this.labelShortTeamName.Location = new Point(4, 84);
      this.labelShortTeamName.Name = "labelShortTeamName";
      this.labelShortTeamName.Size = new Size(93, 20);
      this.labelShortTeamName.TabIndex = 6;
      this.labelShortTeamName.Text = "Name (10 chars)";
      this.labelShortTeamName.TextAlign = ContentAlignment.MiddleLeft;
      this.toolTip.SetToolTip((Control) this.labelShortTeamName, "Double click to fill automatically");
      this.labelShortTeamName.DoubleClick += new EventHandler(this.textShortTeamName_Click);
      this.labelScoreBoardName.ImeMode = ImeMode.NoControl;
      this.labelScoreBoardName.Location = new Point(4, 130);
      this.labelScoreBoardName.Name = "labelScoreBoardName";
      this.labelScoreBoardName.Size = new Size(88, 20);
      this.labelScoreBoardName.TabIndex = 54;
      this.labelScoreBoardName.Text = "Score Board";
      this.labelScoreBoardName.TextAlign = ContentAlignment.MiddleLeft;
      this.groupBox1.Controls.Add((Control) this.textStadiumName);
      this.groupBox1.Controls.Add((Control) this.labelStadiumName);
      this.groupBox1.Controls.Add((Control) this.comboStadiums);
      this.groupBox1.Controls.Add((Control) this.labelStadium);
      this.groupBox1.Location = new Point(3, 620);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(270, 67);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Stadium";
      this.textStadiumName.DataBindings.Add(new Binding("Text", (object) this.teamBindingSource, "stadiumcustomname", true));
      this.textStadiumName.Location = new Point(98, 41);
      this.textStadiumName.Name = "textStadiumName";
      this.textStadiumName.Size = new Size(160, 20);
      this.textStadiumName.TabIndex = 1;
      this.textStadiumName.TextChanged += new EventHandler(this.textStadiumName_TextChanged);
      this.labelStadiumName.ImeMode = ImeMode.NoControl;
      this.labelStadiumName.Location = new Point(0, 41);
      this.labelStadiumName.Name = "labelStadiumName";
      this.labelStadiumName.Size = new Size(90, 20);
      this.labelStadiumName.TabIndex = 73;
      this.labelStadiumName.Text = "Stadium Name";
      this.labelStadiumName.TextAlign = ContentAlignment.MiddleLeft;
      this.comboStadiums.DataBindings.Add(new Binding("SelectedItem", (object) this.teamBindingSource, "Stadium", true, DataSourceUpdateMode.OnPropertyChanged));
      this.comboStadiums.DataSource = (object) this.stadiumListBindingSource;
      this.comboStadiums.Location = new Point(98, 15);
      this.comboStadiums.Name = "comboStadiums";
      this.comboStadiums.Size = new Size(160, 21);
      this.comboStadiums.TabIndex = 0;
      this.stadiumListBindingSource.DataSource = (object) typeof (StadiumList);
      this.labelStadium.Cursor = Cursors.Hand;
      this.labelStadium.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Underline, GraphicsUnit.Point, (byte) 0);
      this.labelStadium.ForeColor = SystemColors.ActiveCaption;
      this.labelStadium.ImeMode = ImeMode.NoControl;
      this.labelStadium.Location = new Point(0, 15);
      this.labelStadium.Name = "labelStadium";
      this.labelStadium.Size = new Size(101, 20);
      this.labelStadium.TabIndex = 71;
      this.labelStadium.Text = "Stadium Model";
      this.labelStadium.TextAlign = ContentAlignment.MiddleLeft;
      this.labelStadium.DoubleClick += new EventHandler(this.labelTeamStadium_DoubleClick);
      this.groupManager.Controls.Add((Control) this.textBox3);
      this.groupManager.Controls.Add((Control) this.label17);
      this.groupManager.Controls.Add((Control) this.textBox2);
      this.groupManager.Controls.Add((Control) this.label16);
      this.groupManager.Location = new Point(3, 693);
      this.groupManager.Name = "groupManager";
      this.groupManager.Size = new Size(270, 72);
      this.groupManager.TabIndex = 2;
      this.groupManager.TabStop = false;
      this.groupManager.Text = "Manager";
      this.textBox3.DataBindings.Add(new Binding("Text", (object) this.teamBindingSource, "ManagerSurname", true));
      this.textBox3.Location = new Point(98, 40);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new Size(160, 20);
      this.textBox3.TabIndex = 1;
      this.label17.ImeMode = ImeMode.NoControl;
      this.label17.Location = new Point(6, 40);
      this.label17.Name = "label17";
      this.label17.Size = new Size(90, 20);
      this.label17.TabIndex = 77;
      this.label17.Text = "Surname";
      this.label17.TextAlign = ContentAlignment.MiddleLeft;
      this.textBox2.DataBindings.Add(new Binding("Text", (object) this.teamBindingSource, "ManagerFirstName", true));
      this.textBox2.Location = new Point(98, 16);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(160, 20);
      this.textBox2.TabIndex = 0;
      this.label16.ImeMode = ImeMode.NoControl;
      this.label16.Location = new Point(6, 16);
      this.label16.Name = "label16";
      this.label16.Size = new Size(90, 20);
      this.label16.TabIndex = 75;
      this.label16.Text = "First Name";
      this.label16.TextAlign = ContentAlignment.MiddleLeft;
      this.groupBox3.Controls.Add((Control) this.labelProbObjective);
      this.groupBox3.Controls.Add((Control) this.labelMaxObjective);
      this.groupBox3.Controls.Add((Control) this.comboProbObjective);
      this.groupBox3.Controls.Add((Control) this.comboMaxOnjective);
      this.groupBox3.Controls.Add((Control) this.comboObjective);
      this.groupBox3.Controls.Add((Control) this.labelObjective);
      this.groupBox3.Controls.Add((Control) this.comboTeamLeague);
      this.groupBox3.Controls.Add((Control) this.labelLeague);
      this.groupBox3.Controls.Add((Control) this.label15);
      this.groupBox3.Controls.Add((Control) this.buttonGetId);
      this.groupBox3.Controls.Add((Control) this.pictureTeamTerColor);
      this.groupBox3.Controls.Add((Control) this.label1);
      this.groupBox3.Controls.Add((Control) this.comboRivalTeam);
      this.groupBox3.Controls.Add((Control) this.pictureTeamPrimColor);
      this.groupBox3.Controls.Add((Control) this.pictureTeamSecColor);
      this.groupBox3.Controls.Add((Control) this.numericTeamId);
      this.groupBox3.Controls.Add((Control) this.numericBall);
      this.groupBox3.Controls.Add((Control) this.labelTeamId);
      this.groupBox3.Controls.Add((Control) this.pictureBall);
      this.groupBox3.Controls.Add((Control) this.comboTeamCountry);
      this.groupBox3.Controls.Add((Control) this.numericStarsInternationalPrestige);
      this.groupBox3.Controls.Add((Control) this.labelTeamCountry);
      this.groupBox3.Controls.Add((Control) this.labelOpponent);
      this.groupBox3.Controls.Add((Control) this.labelDomesticPrestige);
      this.groupBox3.Controls.Add((Control) this.numericStarsDomesticPrestige);
      this.groupBox3.Controls.Add((Control) this.labelInitialBudget);
      this.groupBox3.Controls.Add((Control) this.labelInternationalPrestige);
      this.groupBox3.Controls.Add((Control) this.numericInitialBudget);
      this.groupBox3.Location = new Point(279, 3);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(270, 451);
      this.groupBox3.TabIndex = 3;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Info";
      this.labelProbObjective.ImeMode = ImeMode.NoControl;
      this.labelProbObjective.Location = new Point(7, 251);
      this.labelProbObjective.Name = "labelProbObjective";
      this.labelProbObjective.Size = new Size(85, 20);
      this.labelProbObjective.TabIndex = 154;
      this.labelProbObjective.Text = "Probable";
      this.labelProbObjective.TextAlign = ContentAlignment.MiddleLeft;
      this.labelMaxObjective.ImeMode = ImeMode.NoControl;
      this.labelMaxObjective.Location = new Point(7, 222);
      this.labelMaxObjective.Name = "labelMaxObjective";
      this.labelMaxObjective.Size = new Size(85, 20);
      this.labelMaxObjective.TabIndex = 153;
      this.labelMaxObjective.Text = "Highest";
      this.labelMaxObjective.TextAlign = ContentAlignment.MiddleLeft;
      this.comboProbObjective.FormattingEnabled = true;
      this.comboProbObjective.Items.AddRange(new object[17]
      {
        (object) "Win the League Title",
        (object) "Qualify for Champions' Cup",
        (object) "Qualify for Euro League",
        (object) "Finish Mid Table",
        (object) "Avoid Relegation",
        (object) "Avoid Finish in Bottom Part",
        (object) "Gain Automatic Promotion",
        (object) "Fight For Promotion",
        (object) "Achieve a High Finish",
        (object) "Fight for the League Title",
        (object) "Qualify For Europe",
        (object) "Run for the Playoffs",
        (object) "Reach the Wildcard Stage.",
        (object) "Reach the Quarter Final",
        (object) "Reach the Playoff Semi Final",
        (object) "Reach the Playoff Final",
        (object) "Become the Playoff Champion"
      });
      this.comboProbObjective.Location = new Point(89, 250);
      this.comboProbObjective.Name = "comboProbObjective";
      this.comboProbObjective.Size = new Size(167, 21);
      this.comboProbObjective.TabIndex = 8;
      this.comboProbObjective.SelectedIndexChanged += new EventHandler(this.comboProbObjective_SelectedIndexChanged);
      this.comboMaxOnjective.FormattingEnabled = true;
      this.comboMaxOnjective.Items.AddRange(new object[17]
      {
        (object) "Win the League Title",
        (object) "Qualify for Champions' Cup",
        (object) "Qualify for Euro League",
        (object) "Finish Mid Table",
        (object) "Avoid Relegation",
        (object) "Avoid Finish in Bottom Part",
        (object) "Gain Automatic Promotion",
        (object) "Fight For Promotion",
        (object) "Achieve a High Finish",
        (object) "Fight for the League Title",
        (object) "Qualify For Europe",
        (object) "Run for the Playoffs",
        (object) "Reach the Wildcard Stage.",
        (object) "Reach the Quarter Final",
        (object) "Reach the Playoff Semi Final",
        (object) "Reach the Playoff Final",
        (object) "Become the Playoff Champion"
      });
      this.comboMaxOnjective.Location = new Point(91, 223);
      this.comboMaxOnjective.Name = "comboMaxOnjective";
      this.comboMaxOnjective.Size = new Size(167, 21);
      this.comboMaxOnjective.TabIndex = 7;
      this.comboMaxOnjective.SelectedIndexChanged += new EventHandler(this.comboMaxOnjective_SelectedIndexChanged);
      this.comboObjective.FormattingEnabled = true;
      this.comboObjective.Items.AddRange(new object[17]
      {
        (object) "Win the League Title",
        (object) "Qualify for Champions' Cup",
        (object) "Qualify for Euro League",
        (object) "Finish Mid Table",
        (object) "Avoid Relegation",
        (object) "Avoid Finish in Bottom Part",
        (object) "Gain Automatic Promotion",
        (object) "Fight For Promotion",
        (object) "Achieve a High Finish",
        (object) "Fight for the League Title",
        (object) "Qualify For Europe",
        (object) "Run for the Playoffs",
        (object) "Reach the Wildcard Stage.",
        (object) "Reach the Quarter Final",
        (object) "Reach the Playoff Semi Final",
        (object) "Reach the Playoff Final",
        (object) "Become the Playoff Champion"
      });
      this.comboObjective.Location = new Point(91, 196);
      this.comboObjective.Name = "comboObjective";
      this.comboObjective.Size = new Size(167, 21);
      this.comboObjective.TabIndex = 6;
      this.comboObjective.SelectedIndexChanged += new EventHandler(this.comboObjective_SelectedIndexChanged);
      this.labelObjective.ImeMode = ImeMode.NoControl;
      this.labelObjective.Location = new Point(7, 194);
      this.labelObjective.Name = "labelObjective";
      this.labelObjective.Size = new Size(85, 20);
      this.labelObjective.TabIndex = 149;
      this.labelObjective.Text = "Objective";
      this.labelObjective.TextAlign = ContentAlignment.MiddleLeft;
      this.comboTeamLeague.DataBindings.Add(new Binding("SelectedItem", (object) this.teamBindingSource, "League", true));
      this.comboTeamLeague.DataSource = (object) this.leagueListBindingSource;
      this.comboTeamLeague.Enabled = false;
      this.comboTeamLeague.Location = new Point(91, 98);
      this.comboTeamLeague.Name = "comboTeamLeague";
      this.comboTeamLeague.Size = new Size(167, 21);
      this.comboTeamLeague.TabIndex = 2;
      this.comboTeamLeague.SelectedIndexChanged += new EventHandler(this.comboTeamLeague_SelectedIndexChanged);
      this.leagueListBindingSource.DataSource = (object) typeof (LeagueList);
      this.labelLeague.AutoSize = true;
      this.labelLeague.Cursor = Cursors.Hand;
      this.labelLeague.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Underline, GraphicsUnit.Point, (byte) 0);
      this.labelLeague.ForeColor = SystemColors.ActiveCaption;
      this.labelLeague.ImeMode = ImeMode.NoControl;
      this.labelLeague.Location = new Point(6, 101);
      this.labelLeague.Name = "labelLeague";
      this.labelLeague.Size = new Size(43, 13);
      this.labelLeague.TabIndex = 148;
      this.labelLeague.Text = "League";
      this.labelLeague.TextAlign = ContentAlignment.MiddleLeft;
      this.toolTip.SetToolTip((Control) this.labelLeague, "For changing the league go to the league page.");
      this.labelLeague.DoubleClick += new EventHandler(this.labelTeamLeague_DoubleClick);
      this.label15.AutoSize = true;
      this.label15.BackColor = Color.Transparent;
      this.label15.ImeMode = ImeMode.NoControl;
      this.label15.Location = new Point(6, 26);
      this.label15.Name = "label15";
      this.label15.Size = new Size(36, 13);
      this.label15.TabIndex = 147;
      this.label15.Text = "Colors";
      this.label15.TextAlign = ContentAlignment.TopCenter;
      this.buttonGetId.Image = (Image) resources.GetObject("buttonGetId.Image");
      this.buttonGetId.Location = new Point(182, 45);
      this.buttonGetId.Name = "buttonGetId";
      this.buttonGetId.Size = new Size(28, 24);
      this.buttonGetId.TabIndex = 6;
      this.buttonGetId.TabStop = false;
      this.buttonGetId.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.buttonGetId.UseVisualStyleBackColor = true;
      this.buttonGetId.Click += new EventHandler(this.buttonGetId_Click);
      this.pictureTeamTerColor.BorderStyle = BorderStyle.FixedSingle;
      this.pictureTeamTerColor.Cursor = Cursors.Hand;
      this.pictureTeamTerColor.DataBindings.Add(new Binding("BackColor", (object) this.teamBindingSource, "TeamColor3", true));
      this.pictureTeamTerColor.ImeMode = ImeMode.NoControl;
      this.pictureTeamTerColor.Location = new Point(165, 19);
      this.pictureTeamTerColor.Name = "pictureTeamTerColor";
      this.pictureTeamTerColor.Size = new Size(24, 24);
      this.pictureTeamTerColor.TabIndex = 146;
      this.pictureTeamTerColor.TabStop = false;
      this.pictureTeamTerColor.Click += new EventHandler(this.pictureTeamTerColor_Click);
      this.label1.Cursor = Cursors.Hand;
      this.label1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Underline);
      this.label1.ForeColor = SystemColors.ActiveCaption;
      this.label1.ImeMode = ImeMode.NoControl;
      this.label1.Location = new Point(6, 305);
      this.label1.Name = "label1";
      this.label1.Size = new Size(85, 20);
      this.label1.TabIndex = 96;
      this.label1.Text = "Ball Number";
      this.label1.TextAlign = ContentAlignment.MiddleLeft;
      this.label1.DoubleClick += new EventHandler(this.labelBall_DoubleClick);
      this.comboRivalTeam.FormattingEnabled = true;
      this.comboRivalTeam.Location = new Point(89, 282);
      this.comboRivalTeam.Name = "comboRivalTeam";
      this.comboRivalTeam.Size = new Size(169, 21);
      this.comboRivalTeam.TabIndex = 9;
      this.comboRivalTeam.SelectedIndexChanged += new EventHandler(this.comboRivalTeam_SelectedIndexChanged);
      this.pictureTeamPrimColor.BorderStyle = BorderStyle.FixedSingle;
      this.pictureTeamPrimColor.Cursor = Cursors.Hand;
      this.pictureTeamPrimColor.DataBindings.Add(new Binding("BackColor", (object) this.teamBindingSource, "TeamColor1", true));
      this.pictureTeamPrimColor.ImeMode = ImeMode.NoControl;
      this.pictureTeamPrimColor.Location = new Point(91, 19);
      this.pictureTeamPrimColor.Name = "pictureTeamPrimColor";
      this.pictureTeamPrimColor.Size = new Size(24, 24);
      this.pictureTeamPrimColor.TabIndex = 144;
      this.pictureTeamPrimColor.TabStop = false;
      this.pictureTeamPrimColor.Click += new EventHandler(this.pictureTeamPrimColor_Click);
      this.pictureTeamSecColor.BorderStyle = BorderStyle.FixedSingle;
      this.pictureTeamSecColor.Cursor = Cursors.Hand;
      this.pictureTeamSecColor.DataBindings.Add(new Binding("BackColor", (object) this.teamBindingSource, "TeamColor2", true));
      this.pictureTeamSecColor.ImeMode = ImeMode.NoControl;
      this.pictureTeamSecColor.Location = new Point(128, 19);
      this.pictureTeamSecColor.Name = "pictureTeamSecColor";
      this.pictureTeamSecColor.Size = new Size(24, 24);
      this.pictureTeamSecColor.TabIndex = 145;
      this.pictureTeamSecColor.TabStop = false;
      this.pictureTeamSecColor.Click += new EventHandler(this.pictureTeamSecColor_Click);
      this.numericTeamId.Location = new Point(91, 47);
      this.numericTeamId.Maximum = new Decimal(new int[4]
      {
        200000,
        0,
        0,
        0
      });
      this.numericTeamId.Name = "numericTeamId";
      this.numericTeamId.Size = new Size(87, 20);
      this.numericTeamId.TabIndex = 0;
      this.numericTeamId.TextAlign = HorizontalAlignment.Center;
      this.numericTeamId.Value = new Decimal(new int[4]
      {
        200000,
        0,
        0,
        0
      });
      this.numericTeamId.ValueChanged += new EventHandler(this.numericTeamId_ValueChanged);
      this.numericBall.DataBindings.Add(new Binding("Value", (object) this.teamBindingSource, "balltype", true));
      this.numericBall.Location = new Point(167, 307);
      this.numericBall.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericBall.Name = "numericBall";
      this.numericBall.Size = new Size(91, 20);
      this.numericBall.TabIndex = 10;
      this.numericBall.TextAlign = HorizontalAlignment.Center;
      this.numericBall.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericBall.ValueChanged += new EventHandler(this.numericBall_ValueChanged);
      this.labelTeamId.AutoSize = true;
      this.labelTeamId.BackColor = Color.Transparent;
      this.labelTeamId.ImeMode = ImeMode.NoControl;
      this.labelTeamId.Location = new Point(6, 51);
      this.labelTeamId.Name = "labelTeamId";
      this.labelTeamId.Size = new Size(46, 13);
      this.labelTeamId.TabIndex = 5;
      this.labelTeamId.Text = "Team Id";
      this.labelTeamId.TextAlign = ContentAlignment.TopCenter;
      this.pictureBall.BackgroundImageLayout = ImageLayout.Zoom;
      this.pictureBall.Location = new Point(9, 331);
      this.pictureBall.Name = "pictureBall";
      this.pictureBall.Size = new Size(249, 110);
      this.pictureBall.TabIndex = 5;
      this.pictureBall.TabStop = false;
      this.comboTeamCountry.DataBindings.Add(new Binding("SelectedItem", (object) this.teamBindingSource, "Country", true));
      this.comboTeamCountry.DataSource = (object) this.countryListBindingSource;
      this.comboTeamCountry.Location = new Point(91, 73);
      this.comboTeamCountry.Name = "comboTeamCountry";
      this.comboTeamCountry.Size = new Size(167, 21);
      this.comboTeamCountry.TabIndex = 1;
      this.comboTeamCountry.SelectedIndexChanged += new EventHandler(this.comboTeamCountry_SelectedIndexChanged);
      this.countryListBindingSource.DataSource = (object) typeof (CountryList);
      this.numericStarsInternationalPrestige.BackColor = Color.Transparent;
      this.numericStarsInternationalPrestige.DataBindings.Add(new Binding("Value", (object) this.teamBindingSource, "internationalprestige", true));
      this.numericStarsInternationalPrestige.Location = new Point(91, 147);
      this.numericStarsInternationalPrestige.Name = "numericStarsInternationalPrestige";
      this.numericStarsInternationalPrestige.Size = new Size(167, 20);
      this.numericStarsInternationalPrestige.TabIndex = 4;
      this.numericStarsInternationalPrestige.Value = 0;
      this.labelTeamCountry.AutoSize = true;
      this.labelTeamCountry.Cursor = Cursors.Hand;
      this.labelTeamCountry.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Underline, GraphicsUnit.Point, (byte) 0);
      this.labelTeamCountry.ForeColor = SystemColors.ActiveCaption;
      this.labelTeamCountry.ImeMode = ImeMode.NoControl;
      this.labelTeamCountry.Location = new Point(6, 73);
      this.labelTeamCountry.Name = "labelTeamCountry";
      this.labelTeamCountry.Size = new Size(43, 13);
      this.labelTeamCountry.TabIndex = 122;
      this.labelTeamCountry.Text = "Country";
      this.labelTeamCountry.TextAlign = ContentAlignment.MiddleLeft;
      this.labelTeamCountry.DoubleClick += new EventHandler(this.labelTeamCountry_DoubleClick);
      this.labelOpponent.Cursor = Cursors.Hand;
      this.labelOpponent.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Underline, GraphicsUnit.Point, (byte) 0);
      this.labelOpponent.ForeColor = SystemColors.ActiveCaption;
      this.labelOpponent.ImeMode = ImeMode.NoControl;
      this.labelOpponent.Location = new Point(6, 281);
      this.labelOpponent.Name = "labelOpponent";
      this.labelOpponent.Size = new Size(86, 20);
      this.labelOpponent.TabIndex = 124;
      this.labelOpponent.Text = "Opponent Team";
      this.labelOpponent.TextAlign = ContentAlignment.MiddleLeft;
      this.labelOpponent.DoubleClick += new EventHandler(this.labelOpponent_DoubleClick);
      this.labelDomesticPrestige.BackColor = Color.Transparent;
      this.labelDomesticPrestige.ImeMode = ImeMode.NoControl;
      this.labelDomesticPrestige.Location = new Point(6, 123);
      this.labelDomesticPrestige.Name = "labelDomesticPrestige";
      this.labelDomesticPrestige.Size = new Size(85, 20);
      this.labelDomesticPrestige.TabIndex = 103;
      this.labelDomesticPrestige.Text = "Domestic";
      this.labelDomesticPrestige.TextAlign = ContentAlignment.MiddleLeft;
      this.numericStarsDomesticPrestige.BackColor = Color.Transparent;
      this.numericStarsDomesticPrestige.DataBindings.Add(new Binding("Value", (object) this.teamBindingSource, "domesticprestige", true));
      this.numericStarsDomesticPrestige.Location = new Point(91, 123);
      this.numericStarsDomesticPrestige.Name = "numericStarsDomesticPrestige";
      this.numericStarsDomesticPrestige.Size = new Size(167, 20);
      this.numericStarsDomesticPrestige.TabIndex = 3;
      this.numericStarsDomesticPrestige.Value = 0;
      this.labelInitialBudget.ImeMode = ImeMode.NoControl;
      this.labelInitialBudget.Location = new Point(6, 171);
      this.labelInitialBudget.Name = "labelInitialBudget";
      this.labelInitialBudget.Size = new Size(85, 20);
      this.labelInitialBudget.TabIndex = 95;
      this.labelInitialBudget.Text = "Budget";
      this.labelInitialBudget.TextAlign = ContentAlignment.MiddleLeft;
      this.labelInternationalPrestige.BackColor = Color.Transparent;
      this.labelInternationalPrestige.ImeMode = ImeMode.NoControl;
      this.labelInternationalPrestige.Location = new Point(6, 147);
      this.labelInternationalPrestige.Name = "labelInternationalPrestige";
      this.labelInternationalPrestige.Size = new Size(84, 20);
      this.labelInternationalPrestige.TabIndex = 101;
      this.labelInternationalPrestige.Text = "International";
      this.labelInternationalPrestige.TextAlign = ContentAlignment.MiddleLeft;
      this.numericInitialBudget.DataBindings.Add(new Binding("Value", (object) this.teamBindingSource, "transferbudget", true));
      this.numericInitialBudget.Increment = new Decimal(new int[4]
      {
        100000,
        0,
        0,
        0
      });
      this.numericInitialBudget.Location = new Point(91, 171);
      this.numericInitialBudget.Maximum = new Decimal(new int[4]
      {
        100000000,
        0,
        0,
        0
      });
      this.numericInitialBudget.Name = "numericInitialBudget";
      this.numericInitialBudget.Size = new Size(167, 20);
      this.numericInitialBudget.TabIndex = 5;
      this.numericInitialBudget.TextAlign = HorizontalAlignment.Center;
      this.numericInitialBudget.ThousandsSeparator = true;
      this.numericInitialBudget.Value = new Decimal(new int[4]
      {
        10000000,
        0,
        0,
        0
      });
      this.groupLastYear.Controls.Add((Control) this.comboPrevLeague);
      this.groupLastYear.Controls.Add((Control) this.numericPositionLastYear);
      this.groupLastYear.Controls.Add((Control) this.checkIsChampion);
      this.groupLastYear.Controls.Add((Control) this.label19);
      this.groupLastYear.Controls.Add((Control) this.label18);
      this.groupLastYear.Location = new Point(279, 460);
      this.groupLastYear.Name = "groupLastYear";
      this.groupLastYear.Size = new Size(270, 101);
      this.groupLastYear.TabIndex = 4;
      this.groupLastYear.TabStop = false;
      this.groupLastYear.Text = "Last Year Performance";
      this.comboPrevLeague.DataBindings.Add(new Binding("SelectedItem", (object) this.teamBindingSource, "PrevLeague", true));
      this.comboPrevLeague.DataSource = (object) this.leagueListBindingSource;
      this.comboPrevLeague.Location = new Point(97, 18);
      this.comboPrevLeague.Name = "comboPrevLeague";
      this.comboPrevLeague.Size = new Size(167, 21);
      this.comboPrevLeague.TabIndex = 0;
      this.comboPrevLeague.SelectedIndexChanged += new EventHandler(this.comboPrevLeague_SelectedIndexChanged);
      this.numericPositionLastYear.DataBindings.Add(new Binding("Value", (object) this.teamBindingSource, "previousyeartableposition", true));
      this.numericPositionLastYear.Location = new Point(97, 42);
      this.numericPositionLastYear.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericPositionLastYear.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericPositionLastYear.Name = "numericPositionLastYear";
      this.numericPositionLastYear.Size = new Size(63, 20);
      this.numericPositionLastYear.TabIndex = 1;
      this.numericPositionLastYear.TextAlign = HorizontalAlignment.Center;
      this.numericPositionLastYear.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.checkIsChampion.AutoSize = true;
      this.checkIsChampion.DataBindings.Add(new Binding("Checked", (object) this.teamBindingSource, "IsChampion", true));
      this.checkIsChampion.Location = new Point(6, 68);
      this.checkIsChampion.Name = "checkIsChampion";
      this.checkIsChampion.RightToLeft = RightToLeft.Yes;
      this.checkIsChampion.Size = new Size(117, 17);
      this.checkIsChampion.TabIndex = 2;
      this.checkIsChampion.Text = "Is Champion           ";
      this.checkIsChampion.UseVisualStyleBackColor = true;
      this.label19.AutoSize = true;
      this.label19.BackColor = Color.Transparent;
      this.label19.ImeMode = ImeMode.NoControl;
      this.label19.Location = new Point(6, 44);
      this.label19.Name = "label19";
      this.label19.Size = new Size(44, 13);
      this.label19.TabIndex = 149;
      this.label19.Text = "Position";
      this.label19.TextAlign = ContentAlignment.MiddleCenter;
      this.label18.AutoSize = true;
      this.label18.BackColor = Color.Transparent;
      this.label18.ImeMode = ImeMode.NoControl;
      this.label18.Location = new Point(7, 21);
      this.label18.Name = "label18";
      this.label18.Size = new Size(43, 13);
      this.label18.TabIndex = 148;
      this.label18.Text = "League";
      this.label18.TextAlign = ContentAlignment.MiddleCenter;
      this.groupLocation.Controls.Add((Control) this.numericUtcOffset);
      this.groupLocation.Controls.Add((Control) this.numericLongitude);
      this.groupLocation.Controls.Add((Control) this.numericLatitude);
      this.groupLocation.Controls.Add((Control) this.label25);
      this.groupLocation.Controls.Add((Control) this.label24);
      this.groupLocation.Controls.Add((Control) this.label23);
      this.groupLocation.Location = new Point(279, 567);
      this.groupLocation.Name = "groupLocation";
      this.groupLocation.Size = new Size(270, 102);
      this.groupLocation.TabIndex = 162;
      this.groupLocation.TabStop = false;
      this.groupLocation.Text = "Location";
      this.numericUtcOffset.DataBindings.Add(new Binding("Value", (object) this.teamBindingSource, "utcoffset", true));
      this.numericUtcOffset.Location = new Point(91, 73);
      this.numericUtcOffset.Maximum = new Decimal(new int[4]
      {
        13,
        0,
        0,
        0
      });
      this.numericUtcOffset.Minimum = new Decimal(new int[4]
      {
        12,
        0,
        0,
        int.MinValue
      });
      this.numericUtcOffset.Name = "numericUtcOffset";
      this.numericUtcOffset.Size = new Size(87, 20);
      this.numericUtcOffset.TabIndex = 154;
      this.numericUtcOffset.TextAlign = HorizontalAlignment.Center;
      this.numericUtcOffset.ValueChanged += new EventHandler(this.numericUtcOffset_ValueChanged);
      this.numericLongitude.DataBindings.Add(new Binding("Value", (object) this.teamBindingSource, "longitude", true));
      this.numericLongitude.Location = new Point(91, 45);
      this.numericLongitude.Maximum = new Decimal(new int[4]
      {
        180,
        0,
        0,
        0
      });
      this.numericLongitude.Minimum = new Decimal(new int[4]
      {
        180,
        0,
        0,
        int.MinValue
      });
      this.numericLongitude.Name = "numericLongitude";
      this.numericLongitude.Size = new Size(87, 20);
      this.numericLongitude.TabIndex = 153;
      this.numericLongitude.TextAlign = HorizontalAlignment.Center;
      this.numericLongitude.ValueChanged += new EventHandler(this.numericLongitude_ValueChanged);
      this.numericLatitude.DataBindings.Add(new Binding("Value", (object) this.teamBindingSource, "latitude", true));
      this.numericLatitude.Location = new Point(91, 19);
      this.numericLatitude.Maximum = new Decimal(new int[4]
      {
        90,
        0,
        0,
        0
      });
      this.numericLatitude.Minimum = new Decimal(new int[4]
      {
        90,
        0,
        0,
        int.MinValue
      });
      this.numericLatitude.Name = "numericLatitude";
      this.numericLatitude.Size = new Size(87, 20);
      this.numericLatitude.TabIndex = 152;
      this.numericLatitude.TextAlign = HorizontalAlignment.Center;
      this.numericLatitude.ValueChanged += new EventHandler(this.numericLatitude_ValueChanged);
      this.label25.AutoSize = true;
      this.label25.BackColor = Color.Transparent;
      this.label25.ImeMode = ImeMode.NoControl;
      this.label25.Location = new Point(6, 73);
      this.label25.Name = "label25";
      this.label25.Size = new Size(55, 13);
      this.label25.TabIndex = 151;
      this.label25.Text = "UTC Time";
      this.label25.TextAlign = ContentAlignment.MiddleCenter;
      this.label24.AutoSize = true;
      this.label24.BackColor = Color.Transparent;
      this.label24.ImeMode = ImeMode.NoControl;
      this.label24.Location = new Point(6, 48);
      this.label24.Name = "label24";
      this.label24.Size = new Size(54, 13);
      this.label24.TabIndex = 150;
      this.label24.Text = "Longitude";
      this.label24.TextAlign = ContentAlignment.MiddleCenter;
      this.label23.AutoSize = true;
      this.label23.BackColor = Color.Transparent;
      this.label23.ImeMode = ImeMode.NoControl;
      this.label23.Location = new Point(6, 24);
      this.label23.Name = "label23";
      this.label23.Size = new Size(45, 13);
      this.label23.TabIndex = 149;
      this.label23.Text = "Latitude";
      this.label23.TextAlign = ContentAlignment.MiddleCenter;
      this.groupTeamTraits.Controls.Add((Control) this.checkShortOutBack);
      this.groupTeamTraits.Controls.Add((Control) this.checkMoreAttackingAtHome);
      this.groupTeamTraits.Controls.Add((Control) this.checkCenterBacksSplit);
      this.groupTeamTraits.Controls.Add((Control) this.checkSwitchWingers);
      this.groupTeamTraits.Controls.Add((Control) this.checkKeepUpPressure);
      this.groupTeamTraits.Controls.Add((Control) this.checkDefendLead);
      this.groupTeamTraits.Controls.Add((Control) this.checkConsistentLineup);
      this.groupTeamTraits.Controls.Add((Control) this.checkSquadRotation);
      this.groupTeamTraits.Controls.Add((Control) this.checkLoyalBoard);
      this.groupTeamTraits.Controls.Add((Control) this.checkImpatientBoard);
      this.groupTeamTraits.Location = new Point(555, 3);
      this.groupTeamTraits.Name = "groupTeamTraits";
      this.groupTeamTraits.Size = new Size(270, 209);
      this.groupTeamTraits.TabIndex = 161;
      this.groupTeamTraits.TabStop = false;
      this.groupTeamTraits.Text = "Team Traits";
      this.checkShortOutBack.AutoSize = true;
      this.checkShortOutBack.BackColor = Color.Transparent;
      this.checkShortOutBack.DataBindings.Add(new Binding("Checked", (object) this.teamBindingSource, "ShortOutBack", true));
      this.checkShortOutBack.ImeMode = ImeMode.NoControl;
      this.checkShortOutBack.Location = new Point(83, 170);
      this.checkShortOutBack.Name = "checkShortOutBack";
      this.checkShortOutBack.Size = new Size(99, 17);
      this.checkShortOutBack.TabIndex = 9;
      this.checkShortOutBack.Text = "Short Out Back";
      this.checkShortOutBack.UseVisualStyleBackColor = false;
      this.checkMoreAttackingAtHome.AutoSize = true;
      this.checkMoreAttackingAtHome.BackColor = Color.Transparent;
      this.checkMoreAttackingAtHome.DataBindings.Add(new Binding("Checked", (object) this.teamBindingSource, "MoreAttackingAtHome", true));
      this.checkMoreAttackingAtHome.ImeMode = ImeMode.NoControl;
      this.checkMoreAttackingAtHome.Location = new Point(83, 148);
      this.checkMoreAttackingAtHome.Name = "checkMoreAttackingAtHome";
      this.checkMoreAttackingAtHome.Size = new Size(142, 17);
      this.checkMoreAttackingAtHome.TabIndex = 8;
      this.checkMoreAttackingAtHome.Text = "More Attacking At Home";
      this.checkMoreAttackingAtHome.UseVisualStyleBackColor = false;
      this.checkCenterBacksSplit.AutoSize = true;
      this.checkCenterBacksSplit.BackColor = Color.Transparent;
      this.checkCenterBacksSplit.DataBindings.Add(new Binding("Checked", (object) this.teamBindingSource, "CenterBacksSplit", true));
      this.checkCenterBacksSplit.ImeMode = ImeMode.NoControl;
      this.checkCenterBacksSplit.Location = new Point(83, 126);
      this.checkCenterBacksSplit.Name = "checkCenterBacksSplit";
      this.checkCenterBacksSplit.Size = new Size(113, 17);
      this.checkCenterBacksSplit.TabIndex = 7;
      this.checkCenterBacksSplit.Text = "Center Backs Split";
      this.checkCenterBacksSplit.UseVisualStyleBackColor = false;
      this.checkSwitchWingers.AutoSize = true;
      this.checkSwitchWingers.BackColor = Color.Transparent;
      this.checkSwitchWingers.DataBindings.Add(new Binding("Checked", (object) this.teamBindingSource, "SwitchWingers", true));
      this.checkSwitchWingers.ImeMode = ImeMode.NoControl;
      this.checkSwitchWingers.Location = new Point(83, 104);
      this.checkSwitchWingers.Name = "checkSwitchWingers";
      this.checkSwitchWingers.Size = new Size(100, 17);
      this.checkSwitchWingers.TabIndex = 6;
      this.checkSwitchWingers.Text = "Switch Wingers";
      this.checkSwitchWingers.UseVisualStyleBackColor = false;
      this.checkKeepUpPressure.AutoSize = true;
      this.checkKeepUpPressure.BackColor = Color.Transparent;
      this.checkKeepUpPressure.DataBindings.Add(new Binding("Checked", (object) this.teamBindingSource, "KeepUpPressure", true));
      this.checkKeepUpPressure.ImeMode = ImeMode.NoControl;
      this.checkKeepUpPressure.Location = new Point(142, 65);
      this.checkKeepUpPressure.Name = "checkKeepUpPressure";
      this.checkKeepUpPressure.Size = new Size(112, 17);
      this.checkKeepUpPressure.TabIndex = 5;
      this.checkKeepUpPressure.Text = "Keep Up Pressure";
      this.checkKeepUpPressure.UseVisualStyleBackColor = false;
      this.checkDefendLead.AutoSize = true;
      this.checkDefendLead.BackColor = Color.Transparent;
      this.checkDefendLead.DataBindings.Add(new Binding("Checked", (object) this.teamBindingSource, "DefendLead", true));
      this.checkDefendLead.ImeMode = ImeMode.NoControl;
      this.checkDefendLead.Location = new Point(19, 65);
      this.checkDefendLead.Name = "checkDefendLead";
      this.checkDefendLead.Size = new Size(88, 17);
      this.checkDefendLead.TabIndex = 2;
      this.checkDefendLead.Text = "Defend Lead";
      this.checkDefendLead.UseVisualStyleBackColor = false;
      this.checkConsistentLineup.AutoSize = true;
      this.checkConsistentLineup.BackColor = Color.Transparent;
      this.checkConsistentLineup.DataBindings.Add(new Binding("Checked", (object) this.teamBindingSource, "ConsistentLineup", true));
      this.checkConsistentLineup.ImeMode = ImeMode.NoControl;
      this.checkConsistentLineup.Location = new Point(142, 42);
      this.checkConsistentLineup.Name = "checkConsistentLineup";
      this.checkConsistentLineup.Size = new Size(110, 17);
      this.checkConsistentLineup.TabIndex = 4;
      this.checkConsistentLineup.Text = "Consistent Lineup";
      this.checkConsistentLineup.UseVisualStyleBackColor = false;
      this.checkSquadRotation.AutoSize = true;
      this.checkSquadRotation.BackColor = Color.Transparent;
      this.checkSquadRotation.DataBindings.Add(new Binding("Checked", (object) this.teamBindingSource, "SquadRotation", true));
      this.checkSquadRotation.ImeMode = ImeMode.NoControl;
      this.checkSquadRotation.Location = new Point(19, 42);
      this.checkSquadRotation.Name = "checkSquadRotation";
      this.checkSquadRotation.Size = new Size(100, 17);
      this.checkSquadRotation.TabIndex = 1;
      this.checkSquadRotation.Text = "Squad Rotation";
      this.checkSquadRotation.UseVisualStyleBackColor = false;
      this.checkLoyalBoard.AutoSize = true;
      this.checkLoyalBoard.BackColor = Color.Transparent;
      this.checkLoyalBoard.DataBindings.Add(new Binding("Checked", (object) this.teamBindingSource, "LoyalBoard", true));
      this.checkLoyalBoard.ImeMode = ImeMode.NoControl;
      this.checkLoyalBoard.Location = new Point(142, 19);
      this.checkLoyalBoard.Name = "checkLoyalBoard";
      this.checkLoyalBoard.Size = new Size(82, 17);
      this.checkLoyalBoard.TabIndex = 3;
      this.checkLoyalBoard.Text = "Loyal Board";
      this.checkLoyalBoard.UseVisualStyleBackColor = false;
      this.checkImpatientBoard.AutoSize = true;
      this.checkImpatientBoard.BackColor = Color.Transparent;
      this.checkImpatientBoard.DataBindings.Add(new Binding("Checked", (object) this.teamBindingSource, "ImpatientBoard", true));
      this.checkImpatientBoard.ImeMode = ImeMode.NoControl;
      this.checkImpatientBoard.Location = new Point(19, 19);
      this.checkImpatientBoard.Name = "checkImpatientBoard";
      this.checkImpatientBoard.Size = new Size(100, 17);
      this.checkImpatientBoard.TabIndex = 0;
      this.checkImpatientBoard.Text = "Impatient Board";
      this.checkImpatientBoard.UseVisualStyleBackColor = false;
      this.pageTeamRoster.AutoScroll = true;
      this.pageTeamRoster.Controls.Add((Control) this.groupBox6);
      this.pageTeamRoster.Controls.Add((Control) this.groupBox5);
      this.pageTeamRoster.Controls.Add((Control) this.groupBox4);
      this.pageTeamRoster.Controls.Add((Control) this.labelRightFreeKickText);
      this.pageTeamRoster.Controls.Add((Control) this.labelRightFreeKick);
      this.pageTeamRoster.Controls.Add((Control) this.labelLeftFreeKickText);
      this.pageTeamRoster.Controls.Add((Control) this.labelLeftFreeKick);
      this.pageTeamRoster.Controls.Add((Control) this.groupFormation);
      this.pageTeamRoster.Controls.Add((Control) this.labelLongKick);
      this.pageTeamRoster.Controls.Add((Control) this.labelLomgKickText);
      this.pageTeamRoster.Controls.Add((Control) this.labelRightCornerText);
      this.pageTeamRoster.Controls.Add((Control) this.labelCaptainTetx);
      this.pageTeamRoster.Controls.Add((Control) this.labelLeftCornertext);
      this.pageTeamRoster.Controls.Add((Control) this.labelRightCorner);
      this.pageTeamRoster.Controls.Add((Control) this.labelCaptain);
      this.pageTeamRoster.Controls.Add((Control) this.labelLeftCorner);
      this.pageTeamRoster.Controls.Add((Control) this.labelFreeKickText);
      this.pageTeamRoster.Controls.Add((Control) this.labelPenaltyText);
      this.pageTeamRoster.Controls.Add((Control) this.labelPenalty);
      this.pageTeamRoster.Controls.Add((Control) this.labelFreeKick);
      this.pageTeamRoster.Controls.Add((Control) this.panel1);
      this.pageTeamRoster.Controls.Add((Control) this.groupAvailablePlayers);
      this.pageTeamRoster.Controls.Add((Control) this.groupTeamPlayers);
      this.pageTeamRoster.Location = new Point(4, 22);
      this.pageTeamRoster.Name = "pageTeamRoster";
      this.pageTeamRoster.Padding = new Padding(3);
      this.pageTeamRoster.Size = new Size(1349, 781);
      this.pageTeamRoster.TabIndex = 1;
      this.pageTeamRoster.Text = "Roster";
      this.pageTeamRoster.UseVisualStyleBackColor = true;
      this.groupBox6.Controls.Add((Control) this.labelCcpositioning);
      this.groupBox6.Controls.Add((Control) this.labelCcpassing);
      this.groupBox6.Controls.Add((Control) this.labelCccrossing);
      this.groupBox6.Controls.Add((Control) this.labelCcshooting);
      this.groupBox6.Controls.Add((Control) this.numericCcpassing);
      this.groupBox6.Controls.Add((Control) this.numericCccrossing);
      this.groupBox6.Controls.Add((Control) this.numericCcshooting);
      this.groupBox6.Controls.Add((Control) this.comboCCPositioning);
      this.groupBox6.Location = new Point(970, 630);
      this.groupBox6.Name = "groupBox6";
      this.groupBox6.Size = new Size(230, 128);
      this.groupBox6.TabIndex = 272;
      this.groupBox6.TabStop = false;
      this.groupBox6.Text = "Chance Creation";
      this.labelCcpositioning.AutoSize = true;
      this.labelCcpositioning.ImeMode = ImeMode.NoControl;
      this.labelCcpositioning.Location = new Point(6, 22);
      this.labelCcpositioning.Name = "labelCcpositioning";
      this.labelCcpositioning.Size = new Size(98, 13);
      this.labelCcpositioning.TabIndex = 240;
      this.labelCcpositioning.Text = "Chance Positioning";
      this.labelCcpositioning.TextAlign = ContentAlignment.MiddleLeft;
      this.labelCcpassing.AutoSize = true;
      this.labelCcpassing.ImeMode = ImeMode.NoControl;
      this.labelCcpassing.Location = new Point(6, 49);
      this.labelCcpassing.Name = "labelCcpassing";
      this.labelCcpassing.Size = new Size(110, 13);
      this.labelCcpassing.TabIndex = 237;
      this.labelCcpassing.Text = "Passing (Safe - Risky)";
      this.labelCcpassing.TextAlign = ContentAlignment.MiddleLeft;
      this.labelCccrossing.AutoSize = true;
      this.labelCccrossing.ImeMode = ImeMode.NoControl;
      this.labelCccrossing.Location = new Point(6, 73);
      this.labelCccrossing.Name = "labelCccrossing";
      this.labelCccrossing.Size = new Size(107, 13);
      this.labelCccrossing.TabIndex = 238;
      this.labelCccrossing.Text = "Crossing (Little - Lots)";
      this.labelCccrossing.TextAlign = ContentAlignment.MiddleLeft;
      this.labelCcshooting.AutoSize = true;
      this.labelCcshooting.ImeMode = ImeMode.NoControl;
      this.labelCcshooting.Location = new Point(6, 97);
      this.labelCcshooting.Name = "labelCcshooting";
      this.labelCcshooting.Size = new Size(109, 13);
      this.labelCcshooting.TabIndex = 239;
      this.labelCcshooting.Text = "Shooting (Little - Lots)";
      this.labelCcshooting.TextAlign = ContentAlignment.MiddleLeft;
      this.numericCcpassing.DataBindings.Add(new Binding("Value", (object) this.teamBindingSource, "ccpassing", true));
      this.numericCcpassing.Location = new Point(160, 45);
      this.numericCcpassing.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericCcpassing.Name = "numericCcpassing";
      this.numericCcpassing.Size = new Size(64, 20);
      this.numericCcpassing.TabIndex = 234;
      this.numericCcpassing.TextAlign = HorizontalAlignment.Center;
      this.numericCcpassing.Value = new Decimal(new int[4]
      {
        50,
        0,
        0,
        0
      });
      this.numericCccrossing.DataBindings.Add(new Binding("Value", (object) this.teamBindingSource, "cccrossing", true));
      this.numericCccrossing.Location = new Point(160, 69);
      this.numericCccrossing.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericCccrossing.Name = "numericCccrossing";
      this.numericCccrossing.Size = new Size(64, 20);
      this.numericCccrossing.TabIndex = 235;
      this.numericCccrossing.TextAlign = HorizontalAlignment.Center;
      this.numericCccrossing.Value = new Decimal(new int[4]
      {
        50,
        0,
        0,
        0
      });
      this.numericCcshooting.DataBindings.Add(new Binding("Value", (object) this.teamBindingSource, "ccshooting", true));
      this.numericCcshooting.Location = new Point(160, 93);
      this.numericCcshooting.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericCcshooting.Name = "numericCcshooting";
      this.numericCcshooting.Size = new Size(64, 20);
      this.numericCcshooting.TabIndex = 236;
      this.numericCcshooting.TextAlign = HorizontalAlignment.Center;
      this.numericCcshooting.Value = new Decimal(new int[4]
      {
        50,
        0,
        0,
        0
      });
      this.comboCCPositioning.DataBindings.Add(new Binding("SelectedIndex", (object) this.teamBindingSource, "ccpositioning", true));
      this.comboCCPositioning.FormattingEnabled = true;
      this.comboCCPositioning.Items.AddRange(new object[2]
      {
        (object) "Organized",
        (object) "Free Form"
      });
      this.comboCCPositioning.Location = new Point(110, 18);
      this.comboCCPositioning.Name = "comboCCPositioning";
      this.comboCCPositioning.Size = new Size(114, 21);
      this.comboCCPositioning.TabIndex = 233;
      this.comboCCPositioning.SelectedIndexChanged += new EventHandler(this.comboCCPositioning_SelectedIndexChanged);
      this.groupBox5.Controls.Add((Control) this.labelBuspositioning);
      this.groupBox5.Controls.Add((Control) this.labelBusbuildupspeed);
      this.groupBox5.Controls.Add((Control) this.labelBuspassing);
      this.groupBox5.Controls.Add((Control) this.numericBusbuildupspeed);
      this.groupBox5.Controls.Add((Control) this.numericBuspassing);
      this.groupBox5.Controls.Add((Control) this.comboBUSPositioning);
      this.groupBox5.Controls.Add((Control) this.numericUpDown2);
      this.groupBox5.Controls.Add((Control) this.label20);
      this.groupBox5.Location = new Point(734, 627);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Size = new Size(230, 128);
      this.groupBox5.TabIndex = 271;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "Build Up";
      this.labelBuspositioning.AutoSize = true;
      this.labelBuspositioning.ImeMode = ImeMode.NoControl;
      this.labelBuspositioning.Location = new Point(6, 25);
      this.labelBuspositioning.Name = "labelBuspositioning";
      this.labelBuspositioning.Size = new Size(101, 13);
      this.labelBuspositioning.TabIndex = 231;
      this.labelBuspositioning.Text = "Build Up Positioning";
      this.labelBuspositioning.TextAlign = ContentAlignment.MiddleLeft;
      this.labelBusbuildupspeed.AutoSize = true;
      this.labelBusbuildupspeed.ImeMode = ImeMode.NoControl;
      this.labelBusbuildupspeed.Location = new Point(6, 52);
      this.labelBusbuildupspeed.Name = "labelBusbuildupspeed";
      this.labelBusbuildupspeed.Size = new Size(109, 13);
      this.labelBusbuildupspeed.TabIndex = 229;
      this.labelBusbuildupspeed.Text = "Speed (Patient - Fast)";
      this.labelBusbuildupspeed.TextAlign = ContentAlignment.MiddleLeft;
      this.labelBuspassing.AutoSize = true;
      this.labelBuspassing.ImeMode = ImeMode.NoControl;
      this.labelBuspassing.Location = new Point(6, 76);
      this.labelBuspassing.Name = "labelBuspassing";
      this.labelBuspassing.Size = new Size(105, 13);
      this.labelBuspassing.TabIndex = 230;
      this.labelBuspassing.Text = "Passing (Short-Long)";
      this.labelBuspassing.TextAlign = ContentAlignment.MiddleLeft;
      this.numericBusbuildupspeed.DataBindings.Add(new Binding("Value", (object) this.teamBindingSource, "busbuildupspeed", true));
      this.numericBusbuildupspeed.Location = new Point(161, 48);
      this.numericBusbuildupspeed.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericBusbuildupspeed.Name = "numericBusbuildupspeed";
      this.numericBusbuildupspeed.Size = new Size(64, 20);
      this.numericBusbuildupspeed.TabIndex = 226;
      this.numericBusbuildupspeed.TextAlign = HorizontalAlignment.Center;
      this.numericBusbuildupspeed.Value = new Decimal(new int[4]
      {
        50,
        0,
        0,
        0
      });
      this.numericBuspassing.DataBindings.Add(new Binding("Value", (object) this.teamBindingSource, "buspassing", true));
      this.numericBuspassing.Location = new Point(161, 72);
      this.numericBuspassing.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericBuspassing.Name = "numericBuspassing";
      this.numericBuspassing.Size = new Size(64, 20);
      this.numericBuspassing.TabIndex = 227;
      this.numericBuspassing.TextAlign = HorizontalAlignment.Center;
      this.numericBuspassing.Value = new Decimal(new int[4]
      {
        50,
        0,
        0,
        0
      });
      this.comboBUSPositioning.DataBindings.Add(new Binding("SelectedIndex", (object) this.teamBindingSource, "buspositioning", true));
      this.comboBUSPositioning.FormattingEnabled = true;
      this.comboBUSPositioning.Items.AddRange(new object[2]
      {
        (object) "Organized",
        (object) "Free Form"
      });
      this.comboBUSPositioning.Location = new Point(116, 21);
      this.comboBUSPositioning.Name = "comboBUSPositioning";
      this.comboBUSPositioning.Size = new Size(109, 21);
      this.comboBUSPositioning.TabIndex = 228;
      this.comboBUSPositioning.SelectedIndexChanged += new EventHandler(this.comboBUSPositioning_SelectedIndexChanged);
      this.numericUpDown2.DataBindings.Add(new Binding("Value", (object) this.teamBindingSource, "busdribbling", true));
      this.numericUpDown2.Location = new Point(161, 96);
      this.numericUpDown2.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown2.Name = "numericUpDown2";
      this.numericUpDown2.Size = new Size(64, 20);
      this.numericUpDown2.TabIndex = 250;
      this.numericUpDown2.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown2.Value = new Decimal(new int[4]
      {
        50,
        0,
        0,
        0
      });
      this.label20.AutoSize = true;
      this.label20.ImeMode = ImeMode.NoControl;
      this.label20.Location = new Point(6, 100);
      this.label20.Name = "label20";
      this.label20.Size = new Size(108, 13);
      this.label20.TabIndex = 251;
      this.label20.Text = "Dribbling (Little - Lots)";
      this.label20.TextAlign = ContentAlignment.MiddleLeft;
      this.groupBox4.Controls.Add((Control) this.labelDefdefendeline);
      this.groupBox4.Controls.Add((Control) this.labelDefmentality);
      this.groupBox4.Controls.Add((Control) this.labelDefaggression);
      this.groupBox4.Controls.Add((Control) this.labelDefteamwidth);
      this.groupBox4.Controls.Add((Control) this.numericDefmentality);
      this.groupBox4.Controls.Add((Control) this.numericDefaggression);
      this.groupBox4.Controls.Add((Control) this.numericDefteamwidth);
      this.groupBox4.Controls.Add((Control) this.comboDEFLine);
      this.groupBox4.Location = new Point(970, 493);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new Size(230, 128);
      this.groupBox4.TabIndex = 270;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Defense";
      this.labelDefdefendeline.AutoSize = true;
      this.labelDefdefendeline.ImeMode = ImeMode.NoControl;
      this.labelDefdefendeline.Location = new Point(6, 22);
      this.labelDefdefendeline.Name = "labelDefdefendeline";
      this.labelDefdefendeline.Size = new Size(71, 13);
      this.labelDefdefendeline.TabIndex = 248;
      this.labelDefdefendeline.Text = "Defende Line";
      this.labelDefdefendeline.TextAlign = ContentAlignment.MiddleLeft;
      this.labelDefmentality.AutoSize = true;
      this.labelDefmentality.ImeMode = ImeMode.NoControl;
      this.labelDefmentality.Location = new Point(6, 49);
      this.labelDefmentality.Name = "labelDefmentality";
      this.labelDefmentality.Size = new Size(104, 13);
      this.labelDefmentality.TabIndex = 245;
      this.labelDefmentality.Text = "Position (Deep-High)";
      this.labelDefmentality.TextAlign = ContentAlignment.MiddleLeft;
      this.labelDefaggression.AutoSize = true;
      this.labelDefaggression.ImeMode = ImeMode.NoControl;
      this.labelDefaggression.Location = new Point(6, 73);
      this.labelDefaggression.Name = "labelDefaggression";
      this.labelDefaggression.Size = new Size(113, 13);
      this.labelDefaggression.TabIndex = 246;
      this.labelDefaggression.Text = "Aggression (Low-High)";
      this.labelDefaggression.TextAlign = ContentAlignment.MiddleLeft;
      this.labelDefteamwidth.AutoSize = true;
      this.labelDefteamwidth.ImeMode = ImeMode.NoControl;
      this.labelDefteamwidth.Location = new Point(6, 97);
      this.labelDefteamwidth.Name = "labelDefteamwidth";
      this.labelDefteamwidth.Size = new Size(106, 13);
      this.labelDefteamwidth.TabIndex = 247;
      this.labelDefteamwidth.Text = "Width (Narrow-Wide)";
      this.labelDefteamwidth.TextAlign = ContentAlignment.MiddleLeft;
      this.numericDefmentality.DataBindings.Add(new Binding("Value", (object) this.teamBindingSource, "defmentality", true));
      this.numericDefmentality.Location = new Point(160, 47);
      this.numericDefmentality.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericDefmentality.Name = "numericDefmentality";
      this.numericDefmentality.Size = new Size(64, 20);
      this.numericDefmentality.TabIndex = 242;
      this.numericDefmentality.TextAlign = HorizontalAlignment.Center;
      this.numericDefmentality.Value = new Decimal(new int[4]
      {
        50,
        0,
        0,
        0
      });
      this.numericDefaggression.DataBindings.Add(new Binding("Value", (object) this.teamBindingSource, "defaggression", true));
      this.numericDefaggression.Location = new Point(160, 71);
      this.numericDefaggression.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericDefaggression.Name = "numericDefaggression";
      this.numericDefaggression.Size = new Size(64, 20);
      this.numericDefaggression.TabIndex = 243;
      this.numericDefaggression.TextAlign = HorizontalAlignment.Center;
      this.numericDefaggression.Value = new Decimal(new int[4]
      {
        50,
        0,
        0,
        0
      });
      this.numericDefteamwidth.DataBindings.Add(new Binding("Value", (object) this.teamBindingSource, "defteamwidth", true));
      this.numericDefteamwidth.Location = new Point(160, 95);
      this.numericDefteamwidth.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericDefteamwidth.Name = "numericDefteamwidth";
      this.numericDefteamwidth.Size = new Size(64, 20);
      this.numericDefteamwidth.TabIndex = 244;
      this.numericDefteamwidth.TextAlign = HorizontalAlignment.Center;
      this.numericDefteamwidth.Value = new Decimal(new int[4]
      {
        50,
        0,
        0,
        0
      });
      this.comboDEFLine.DataBindings.Add(new Binding("SelectedIndex", (object) this.teamBindingSource, "defdefenderline", true));
      this.comboDEFLine.FormattingEnabled = true;
      this.comboDEFLine.Items.AddRange(new object[2]
      {
        (object) "Cover",
        (object) "Offside Trap"
      });
      this.comboDEFLine.Location = new Point(102, 19);
      this.comboDEFLine.Name = "comboDEFLine";
      this.comboDEFLine.Size = new Size(122, 21);
      this.comboDEFLine.TabIndex = 241;
      this.comboDEFLine.SelectedIndexChanged += new EventHandler(this.comboDEFLine_SelectedIndexChanged);
      this.labelRightFreeKickText.BackColor = Color.Transparent;
      this.labelRightFreeKickText.ImeMode = ImeMode.NoControl;
      this.labelRightFreeKickText.Location = new Point(1213, 400);
      this.labelRightFreeKickText.Name = "labelRightFreeKickText";
      this.labelRightFreeKickText.Size = new Size(85, 16);
      this.labelRightFreeKickText.TabIndex = 269;
      this.labelRightFreeKickText.Text = "Right Free Kick";
      this.labelRightFreeKickText.TextAlign = ContentAlignment.MiddleCenter;
      this.labelRightFreeKick.AllowDrop = true;
      this.labelRightFreeKick.BackColor = Color.Transparent;
      this.labelRightFreeKick.BorderStyle = BorderStyle.Fixed3D;
      this.labelRightFreeKick.Cursor = Cursors.Arrow;
      this.labelRightFreeKick.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelRightFreeKick.ForeColor = SystemColors.ControlText;
      this.labelRightFreeKick.ImeMode = ImeMode.NoControl;
      this.labelRightFreeKick.Location = new Point(1213, 416);
      this.labelRightFreeKick.Name = "labelRightFreeKick";
      this.labelRightFreeKick.Size = new Size(85, 38);
      this.labelRightFreeKick.TabIndex = 268;
      this.labelRightFreeKick.Text = "Name";
      this.labelRightFreeKick.TextAlign = ContentAlignment.MiddleCenter;
      this.labelRightFreeKick.DragDrop += new DragEventHandler(this.labelSpecial_DragDrop);
      this.labelRightFreeKick.DragEnter += new DragEventHandler(this.labelSpecial_DragEnter);
      this.labelLeftFreeKickText.BackColor = Color.Transparent;
      this.labelLeftFreeKickText.ImeMode = ImeMode.NoControl;
      this.labelLeftFreeKickText.Location = new Point(1213, 344);
      this.labelLeftFreeKickText.Name = "labelLeftFreeKickText";
      this.labelLeftFreeKickText.Size = new Size(85, 16);
      this.labelLeftFreeKickText.TabIndex = 267;
      this.labelLeftFreeKickText.Text = "Left Free Kicks";
      this.labelLeftFreeKickText.TextAlign = ContentAlignment.MiddleCenter;
      this.labelLeftFreeKick.AllowDrop = true;
      this.labelLeftFreeKick.BackColor = Color.Transparent;
      this.labelLeftFreeKick.BorderStyle = BorderStyle.Fixed3D;
      this.labelLeftFreeKick.Cursor = Cursors.Arrow;
      this.labelLeftFreeKick.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelLeftFreeKick.ForeColor = SystemColors.ControlText;
      this.labelLeftFreeKick.ImeMode = ImeMode.NoControl;
      this.labelLeftFreeKick.Location = new Point(1213, 360);
      this.labelLeftFreeKick.Name = "labelLeftFreeKick";
      this.labelLeftFreeKick.Size = new Size(85, 38);
      this.labelLeftFreeKick.TabIndex = 266;
      this.labelLeftFreeKick.Text = "Name";
      this.labelLeftFreeKick.TextAlign = ContentAlignment.MiddleCenter;
      this.labelLeftFreeKick.DragDrop += new DragEventHandler(this.labelSpecial_DragDrop);
      this.labelLeftFreeKick.DragEnter += new DragEventHandler(this.labelSpecial_DragEnter);
      this.groupFormation.Controls.Add((Control) this.labelTeamFormationName);
      this.groupFormation.Controls.Add((Control) this.comboGenericFormations);
      this.groupFormation.Controls.Add((Control) this.radioUseSpecificFormation);
      this.groupFormation.Controls.Add((Control) this.radioUseGenericFormation);
      this.groupFormation.Location = new Point(732, 493);
      this.groupFormation.Name = "groupFormation";
      this.groupFormation.Size = new Size(232, 128);
      this.groupFormation.TabIndex = 265;
      this.groupFormation.TabStop = false;
      this.groupFormation.Text = "Formation";
      this.labelTeamFormationName.Cursor = Cursors.Hand;
      this.labelTeamFormationName.Dock = DockStyle.Top;
      this.labelTeamFormationName.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, (byte) 0);
      this.labelTeamFormationName.ForeColor = SystemColors.ActiveCaption;
      this.labelTeamFormationName.Location = new Point(3, 16);
      this.labelTeamFormationName.Name = "labelTeamFormationName";
      this.labelTeamFormationName.Size = new Size(226, 13);
      this.labelTeamFormationName.TabIndex = 130;
      this.labelTeamFormationName.Text = "Formation Name";
      this.labelTeamFormationName.TextAlign = ContentAlignment.MiddleCenter;
      this.labelTeamFormationName.DoubleClick += new EventHandler(this.labelTeamFormationName_DoubleClick);
      this.comboGenericFormations.FormattingEnabled = true;
      this.comboGenericFormations.Location = new Point(11, 89);
      this.comboGenericFormations.Name = "comboGenericFormations";
      this.comboGenericFormations.Size = new Size(211, 21);
      this.comboGenericFormations.TabIndex = 129;
      this.comboGenericFormations.SelectedIndexChanged += new EventHandler(this.comboGenericFormations_SelectedIndexChanged);
      this.radioUseSpecificFormation.AutoSize = true;
      this.radioUseSpecificFormation.Location = new Point(6, 37);
      this.radioUseSpecificFormation.Name = "radioUseSpecificFormation";
      this.radioUseSpecificFormation.Size = new Size(112, 17);
      this.radioUseSpecificFormation.TabIndex = 128;
      this.radioUseSpecificFormation.Text = "Specific Formation";
      this.radioUseSpecificFormation.UseVisualStyleBackColor = true;
      this.radioUseSpecificFormation.CheckedChanged += new EventHandler(this.radioUseSpecificFormation_CheckedChanged);
      this.radioUseGenericFormation.AutoSize = true;
      this.radioUseGenericFormation.Checked = true;
      this.radioUseGenericFormation.Location = new Point(6, 55);
      this.radioUseGenericFormation.Name = "radioUseGenericFormation";
      this.radioUseGenericFormation.Size = new Size(108, 17);
      this.radioUseGenericFormation.TabIndex = (int) sbyte.MaxValue;
      this.radioUseGenericFormation.TabStop = true;
      this.radioUseGenericFormation.Text = "Generic formation";
      this.radioUseGenericFormation.UseVisualStyleBackColor = true;
      this.radioUseGenericFormation.CheckedChanged += new EventHandler(this.radioUseGenericFormation_CheckedChanged);
      this.labelLongKick.AllowDrop = true;
      this.labelLongKick.BackColor = Color.Transparent;
      this.labelLongKick.BorderStyle = BorderStyle.Fixed3D;
      this.labelLongKick.Cursor = Cursors.Arrow;
      this.labelLongKick.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelLongKick.ForeColor = SystemColors.ControlText;
      this.labelLongKick.ImeMode = ImeMode.NoControl;
      this.labelLongKick.Location = new Point(1213, 247);
      this.labelLongKick.Name = "labelLongKick";
      this.labelLongKick.Size = new Size(85, 38);
      this.labelLongKick.TabIndex = 264;
      this.labelLongKick.Text = "Name";
      this.labelLongKick.TextAlign = ContentAlignment.MiddleCenter;
      this.labelLongKick.DragDrop += new DragEventHandler(this.labelSpecial_DragDrop);
      this.labelLongKick.DragEnter += new DragEventHandler(this.labelSpecial_DragEnter);
      this.labelLomgKickText.BackColor = Color.Transparent;
      this.labelLomgKickText.ImeMode = ImeMode.NoControl;
      this.labelLomgKickText.Location = new Point(1213, 231);
      this.labelLomgKickText.Name = "labelLomgKickText";
      this.labelLomgKickText.Size = new Size(85, 16);
      this.labelLomgKickText.TabIndex = 263;
      this.labelLomgKickText.Text = "Long Kicks";
      this.labelLomgKickText.TextAlign = ContentAlignment.MiddleCenter;
      this.labelRightCornerText.BackColor = Color.Transparent;
      this.labelRightCornerText.ImeMode = ImeMode.NoControl;
      this.labelRightCornerText.Location = new Point(1213, 118);
      this.labelRightCornerText.Name = "labelRightCornerText";
      this.labelRightCornerText.Size = new Size(85, 16);
      this.labelRightCornerText.TabIndex = 262;
      this.labelRightCornerText.Text = "Right Corner";
      this.labelRightCornerText.TextAlign = ContentAlignment.MiddleCenter;
      this.labelCaptainTetx.BackColor = Color.Transparent;
      this.labelCaptainTetx.ImeMode = ImeMode.NoControl;
      this.labelCaptainTetx.Location = new Point(1213, 2);
      this.labelCaptainTetx.Name = "labelCaptainTetx";
      this.labelCaptainTetx.Size = new Size(85, 16);
      this.labelCaptainTetx.TabIndex = 253;
      this.labelCaptainTetx.Text = "Captain";
      this.labelCaptainTetx.TextAlign = ContentAlignment.MiddleCenter;
      this.labelLeftCornertext.BackColor = Color.Transparent;
      this.labelLeftCornertext.ImeMode = ImeMode.NoControl;
      this.labelLeftCornertext.Location = new Point(1213, 60);
      this.labelLeftCornertext.Name = "labelLeftCornertext";
      this.labelLeftCornertext.Size = new Size(85, 16);
      this.labelLeftCornertext.TabIndex = 261;
      this.labelLeftCornertext.Text = "Left Corner";
      this.labelLeftCornertext.TextAlign = ContentAlignment.MiddleCenter;
      this.labelRightCorner.AllowDrop = true;
      this.labelRightCorner.BackColor = Color.Transparent;
      this.labelRightCorner.BorderStyle = BorderStyle.Fixed3D;
      this.labelRightCorner.Cursor = Cursors.Arrow;
      this.labelRightCorner.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelRightCorner.ForeColor = SystemColors.ControlText;
      this.labelRightCorner.ImeMode = ImeMode.NoControl;
      this.labelRightCorner.Location = new Point(1213, 134);
      this.labelRightCorner.Name = "labelRightCorner";
      this.labelRightCorner.Size = new Size(85, 38);
      this.labelRightCorner.TabIndex = 258;
      this.labelRightCorner.Text = "Name";
      this.labelRightCorner.TextAlign = ContentAlignment.MiddleCenter;
      this.labelRightCorner.DragDrop += new DragEventHandler(this.labelSpecial_DragDrop);
      this.labelRightCorner.DragEnter += new DragEventHandler(this.labelSpecial_DragEnter);
      this.labelCaptain.AllowDrop = true;
      this.labelCaptain.BackColor = Color.Transparent;
      this.labelCaptain.BorderStyle = BorderStyle.Fixed3D;
      this.labelCaptain.Cursor = Cursors.Arrow;
      this.labelCaptain.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelCaptain.ForeColor = SystemColors.ControlText;
      this.labelCaptain.ImeMode = ImeMode.NoControl;
      this.labelCaptain.Location = new Point(1213, 18);
      this.labelCaptain.Name = "labelCaptain";
      this.labelCaptain.Size = new Size(85, 38);
      this.labelCaptain.TabIndex = 254;
      this.labelCaptain.Text = "Name";
      this.labelCaptain.TextAlign = ContentAlignment.MiddleCenter;
      this.labelCaptain.DragDrop += new DragEventHandler(this.labelSpecial_DragDrop);
      this.labelCaptain.DragEnter += new DragEventHandler(this.labelSpecial_DragEnter);
      this.labelLeftCorner.AllowDrop = true;
      this.labelLeftCorner.BackColor = Color.Transparent;
      this.labelLeftCorner.BorderStyle = BorderStyle.Fixed3D;
      this.labelLeftCorner.Cursor = Cursors.Arrow;
      this.labelLeftCorner.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelLeftCorner.ForeColor = SystemColors.ControlText;
      this.labelLeftCorner.ImeMode = ImeMode.NoControl;
      this.labelLeftCorner.Location = new Point(1213, 76);
      this.labelLeftCorner.Name = "labelLeftCorner";
      this.labelLeftCorner.Size = new Size(85, 38);
      this.labelLeftCorner.TabIndex = 257;
      this.labelLeftCorner.Text = "Name";
      this.labelLeftCorner.TextAlign = ContentAlignment.MiddleCenter;
      this.labelLeftCorner.DragDrop += new DragEventHandler(this.labelSpecial_DragDrop);
      this.labelLeftCorner.DragEnter += new DragEventHandler(this.labelSpecial_DragEnter);
      this.labelFreeKickText.BackColor = Color.Transparent;
      this.labelFreeKickText.ImeMode = ImeMode.NoControl;
      this.labelFreeKickText.Location = new Point(1213, 288);
      this.labelFreeKickText.Name = "labelFreeKickText";
      this.labelFreeKickText.Size = new Size(85, 16);
      this.labelFreeKickText.TabIndex = 260;
      this.labelFreeKickText.Text = "Free Kicks";
      this.labelFreeKickText.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPenaltyText.BackColor = Color.Transparent;
      this.labelPenaltyText.ImeMode = ImeMode.NoControl;
      this.labelPenaltyText.Location = new Point(1213, 175);
      this.labelPenaltyText.Name = "labelPenaltyText";
      this.labelPenaltyText.Size = new Size(85, 16);
      this.labelPenaltyText.TabIndex = 259;
      this.labelPenaltyText.Text = "Penalty";
      this.labelPenaltyText.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPenalty.AllowDrop = true;
      this.labelPenalty.BackColor = Color.Transparent;
      this.labelPenalty.BorderStyle = BorderStyle.Fixed3D;
      this.labelPenalty.Cursor = Cursors.Arrow;
      this.labelPenalty.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPenalty.ForeColor = SystemColors.ControlText;
      this.labelPenalty.ImeMode = ImeMode.NoControl;
      this.labelPenalty.Location = new Point(1213, 191);
      this.labelPenalty.Name = "labelPenalty";
      this.labelPenalty.Size = new Size(85, 38);
      this.labelPenalty.TabIndex = (int) byte.MaxValue;
      this.labelPenalty.Text = "Name";
      this.labelPenalty.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPenalty.DragDrop += new DragEventHandler(this.labelSpecial_DragDrop);
      this.labelPenalty.DragEnter += new DragEventHandler(this.labelSpecial_DragEnter);
      this.labelFreeKick.AllowDrop = true;
      this.labelFreeKick.BackColor = Color.Transparent;
      this.labelFreeKick.BorderStyle = BorderStyle.Fixed3D;
      this.labelFreeKick.Cursor = Cursors.Arrow;
      this.labelFreeKick.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelFreeKick.ForeColor = SystemColors.ControlText;
      this.labelFreeKick.ImeMode = ImeMode.NoControl;
      this.labelFreeKick.Location = new Point(1213, 304);
      this.labelFreeKick.Name = "labelFreeKick";
      this.labelFreeKick.Size = new Size(85, 38);
      this.labelFreeKick.TabIndex = 256;
      this.labelFreeKick.Text = "Name";
      this.labelFreeKick.TextAlign = ContentAlignment.MiddleCenter;
      this.labelFreeKick.DragDrop += new DragEventHandler(this.labelSpecial_DragDrop);
      this.labelFreeKick.DragEnter += new DragEventHandler(this.labelSpecial_DragEnter);
      this.panel1.BackColor = SystemColors.Control;
      this.panel1.BackgroundImage = (Image) resources.GetObject("panel1.BackgroundImage");
      this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.labelPos33U);
      this.panel1.Controls.Add((Control) this.labelPos33T);
      this.panel1.Controls.Add((Control) this.labelPos33S);
      this.panel1.Controls.Add((Control) this.labelPos33R);
      this.panel1.Controls.Add((Control) this.labelPos33Q);
      this.panel1.Controls.Add((Control) this.labelPos33O);
      this.panel1.Controls.Add((Control) this.labelPos33P);
      this.panel1.Controls.Add((Control) this.labelPos33N);
      this.panel1.Controls.Add((Control) this.labelPos33M);
      this.panel1.Controls.Add((Control) this.labelPos33L);
      this.panel1.Controls.Add((Control) this.labelPos33K);
      this.panel1.Controls.Add((Control) this.labelPos33J);
      this.panel1.Controls.Add((Control) this.labelPos33H);
      this.panel1.Controls.Add((Control) this.labelPos33I);
      this.panel1.Controls.Add((Control) this.labelPos33G);
      this.panel1.Controls.Add((Control) this.labelPos33F);
      this.panel1.Controls.Add((Control) this.labelPos33E);
      this.panel1.Controls.Add((Control) this.labelPos33D);
      this.panel1.Controls.Add((Control) this.labelPos33C);
      this.panel1.Controls.Add((Control) this.labelPos33A);
      this.panel1.Controls.Add((Control) this.labelPos33B);
      this.panel1.Controls.Add((Control) this.labelPos32G);
      this.panel1.Controls.Add((Control) this.labelPos32F);
      this.panel1.Controls.Add((Control) this.labelPos32E);
      this.panel1.Controls.Add((Control) this.labelPos32D);
      this.panel1.Controls.Add((Control) this.labelPos32C);
      this.panel1.Controls.Add((Control) this.labelPos32A);
      this.panel1.Controls.Add((Control) this.labelPos32B);
      this.panel1.Controls.Add((Control) this.labelPos26);
      this.panel1.Controls.Add((Control) this.labelPos27);
      this.panel1.Controls.Add((Control) this.labelPos21);
      this.panel1.Controls.Add((Control) this.labelPos22);
      this.panel1.Controls.Add((Control) this.labelPos23);
      this.panel1.Controls.Add((Control) this.labelPos24);
      this.panel1.Controls.Add((Control) this.labelPos25);
      this.panel1.Controls.Add((Control) this.labelPos14);
      this.panel1.Controls.Add((Control) this.labelPos15);
      this.panel1.Controls.Add((Control) this.labelPos16);
      this.panel1.Controls.Add((Control) this.labelPos17);
      this.panel1.Controls.Add((Control) this.labelPos18);
      this.panel1.Controls.Add((Control) this.labelPos20);
      this.panel1.Controls.Add((Control) this.labelPos19);
      this.panel1.Controls.Add((Control) this.labelPos9);
      this.panel1.Controls.Add((Control) this.labelPos10);
      this.panel1.Controls.Add((Control) this.labelPos11);
      this.panel1.Controls.Add((Control) this.labelPos12);
      this.panel1.Controls.Add((Control) this.labelPos13);
      this.panel1.Controls.Add((Control) this.labelPos2);
      this.panel1.Controls.Add((Control) this.labelPos3);
      this.panel1.Controls.Add((Control) this.labelPos4);
      this.panel1.Controls.Add((Control) this.labelPos5);
      this.panel1.Controls.Add((Control) this.labelPos6);
      this.panel1.Controls.Add((Control) this.labelPos8);
      this.panel1.Controls.Add((Control) this.labelPos7);
      this.panel1.Controls.Add((Control) this.labelPos0);
      this.panel1.Controls.Add((Control) this.labelPos1);
      this.panel1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
      this.panel1.Location = new Point(732, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(477, 484);
      this.panel1.TabIndex = 150;
      this.labelPos33U.AllowDrop = true;
      this.labelPos33U.Anchor = AnchorStyles.Top;
      this.labelPos33U.BackColor = Color.Transparent;
      this.labelPos33U.Cursor = Cursors.Hand;
      this.labelPos33U.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos33U.ForeColor = Color.Black;
      this.labelPos33U.ImeMode = ImeMode.NoControl;
      this.labelPos33U.Location = new Point(407, 437);
      this.labelPos33U.Name = "labelPos33U";
      this.labelPos33U.Size = new Size(68, 40);
      this.labelPos33U.TabIndex = 59;
      this.labelPos33U.Text = "Tribune";
      this.labelPos33U.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos33U.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos33U.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos33U.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos33T.AllowDrop = true;
      this.labelPos33T.Anchor = AnchorStyles.Top;
      this.labelPos33T.BackColor = Color.Transparent;
      this.labelPos33T.Cursor = Cursors.Hand;
      this.labelPos33T.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos33T.ForeColor = Color.Black;
      this.labelPos33T.ImeMode = ImeMode.NoControl;
      this.labelPos33T.Location = new Point(339, 437);
      this.labelPos33T.Name = "labelPos33T";
      this.labelPos33T.Size = new Size(68, 40);
      this.labelPos33T.TabIndex = 58;
      this.labelPos33T.Text = "Tribune";
      this.labelPos33T.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos33T.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos33T.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos33T.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos33S.AllowDrop = true;
      this.labelPos33S.Anchor = AnchorStyles.Top;
      this.labelPos33S.BackColor = Color.Transparent;
      this.labelPos33S.Cursor = Cursors.Hand;
      this.labelPos33S.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos33S.ForeColor = Color.Black;
      this.labelPos33S.ImeMode = ImeMode.NoControl;
      this.labelPos33S.Location = new Point(271, 437);
      this.labelPos33S.Name = "labelPos33S";
      this.labelPos33S.Size = new Size(68, 40);
      this.labelPos33S.TabIndex = 57;
      this.labelPos33S.Text = "Tribune";
      this.labelPos33S.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos33S.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos33S.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos33S.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos33R.AllowDrop = true;
      this.labelPos33R.Anchor = AnchorStyles.Top;
      this.labelPos33R.BackColor = Color.Transparent;
      this.labelPos33R.Cursor = Cursors.Hand;
      this.labelPos33R.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos33R.ForeColor = Color.Black;
      this.labelPos33R.ImeMode = ImeMode.NoControl;
      this.labelPos33R.Location = new Point(203, 437);
      this.labelPos33R.Name = "labelPos33R";
      this.labelPos33R.Size = new Size(68, 40);
      this.labelPos33R.TabIndex = 56;
      this.labelPos33R.Text = "Tribune";
      this.labelPos33R.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos33R.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos33R.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos33R.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos33Q.AllowDrop = true;
      this.labelPos33Q.Anchor = AnchorStyles.Top;
      this.labelPos33Q.BackColor = Color.Transparent;
      this.labelPos33Q.Cursor = Cursors.Hand;
      this.labelPos33Q.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos33Q.ForeColor = Color.Black;
      this.labelPos33Q.ImeMode = ImeMode.NoControl;
      this.labelPos33Q.Location = new Point(135, 437);
      this.labelPos33Q.Name = "labelPos33Q";
      this.labelPos33Q.Size = new Size(68, 40);
      this.labelPos33Q.TabIndex = 55;
      this.labelPos33Q.Text = "Tribune";
      this.labelPos33Q.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos33Q.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos33Q.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos33Q.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos33O.AllowDrop = true;
      this.labelPos33O.Anchor = AnchorStyles.Top;
      this.labelPos33O.BackColor = Color.Transparent;
      this.labelPos33O.Cursor = Cursors.Hand;
      this.labelPos33O.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos33O.ForeColor = Color.Black;
      this.labelPos33O.ImeMode = ImeMode.NoControl;
      this.labelPos33O.Location = new Point(-1, 437);
      this.labelPos33O.Name = "labelPos33O";
      this.labelPos33O.Size = new Size(68, 40);
      this.labelPos33O.TabIndex = 54;
      this.labelPos33O.Text = "Tribune";
      this.labelPos33O.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos33O.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos33O.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos33O.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos33P.AllowDrop = true;
      this.labelPos33P.Anchor = AnchorStyles.Top;
      this.labelPos33P.BackColor = Color.Transparent;
      this.labelPos33P.Cursor = Cursors.Hand;
      this.labelPos33P.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos33P.ForeColor = Color.Black;
      this.labelPos33P.ImeMode = ImeMode.NoControl;
      this.labelPos33P.Location = new Point(67, 437);
      this.labelPos33P.Name = "labelPos33P";
      this.labelPos33P.Size = new Size(68, 40);
      this.labelPos33P.TabIndex = 53;
      this.labelPos33P.Text = "Tribune";
      this.labelPos33P.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos33P.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos33P.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos33P.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos33N.AllowDrop = true;
      this.labelPos33N.Anchor = AnchorStyles.Top;
      this.labelPos33N.BackColor = Color.Transparent;
      this.labelPos33N.Cursor = Cursors.Hand;
      this.labelPos33N.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos33N.ForeColor = Color.Black;
      this.labelPos33N.ImeMode = ImeMode.NoControl;
      this.labelPos33N.Location = new Point(407, 397);
      this.labelPos33N.Name = "labelPos33N";
      this.labelPos33N.Size = new Size(68, 40);
      this.labelPos33N.TabIndex = 52;
      this.labelPos33N.Text = "Tribune";
      this.labelPos33N.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos33N.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos33N.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos33N.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos33M.AllowDrop = true;
      this.labelPos33M.Anchor = AnchorStyles.Top;
      this.labelPos33M.BackColor = Color.Transparent;
      this.labelPos33M.Cursor = Cursors.Hand;
      this.labelPos33M.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos33M.ForeColor = Color.Black;
      this.labelPos33M.ImeMode = ImeMode.NoControl;
      this.labelPos33M.Location = new Point(339, 397);
      this.labelPos33M.Name = "labelPos33M";
      this.labelPos33M.Size = new Size(68, 40);
      this.labelPos33M.TabIndex = 51;
      this.labelPos33M.Text = "Tribune";
      this.labelPos33M.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos33M.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos33M.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos33M.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos33L.AllowDrop = true;
      this.labelPos33L.Anchor = AnchorStyles.Top;
      this.labelPos33L.BackColor = Color.Transparent;
      this.labelPos33L.Cursor = Cursors.Hand;
      this.labelPos33L.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos33L.ForeColor = Color.Black;
      this.labelPos33L.ImeMode = ImeMode.NoControl;
      this.labelPos33L.Location = new Point(271, 397);
      this.labelPos33L.Name = "labelPos33L";
      this.labelPos33L.Size = new Size(68, 40);
      this.labelPos33L.TabIndex = 50;
      this.labelPos33L.Text = "Tribune";
      this.labelPos33L.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos33L.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos33L.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos33L.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos33K.AllowDrop = true;
      this.labelPos33K.Anchor = AnchorStyles.Top;
      this.labelPos33K.BackColor = Color.Transparent;
      this.labelPos33K.Cursor = Cursors.Hand;
      this.labelPos33K.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos33K.ForeColor = Color.Black;
      this.labelPos33K.ImeMode = ImeMode.NoControl;
      this.labelPos33K.Location = new Point(203, 397);
      this.labelPos33K.Name = "labelPos33K";
      this.labelPos33K.Size = new Size(68, 40);
      this.labelPos33K.TabIndex = 49;
      this.labelPos33K.Text = "Tribune";
      this.labelPos33K.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos33K.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos33K.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos33K.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos33J.AllowDrop = true;
      this.labelPos33J.Anchor = AnchorStyles.Top;
      this.labelPos33J.BackColor = Color.Transparent;
      this.labelPos33J.Cursor = Cursors.Hand;
      this.labelPos33J.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos33J.ForeColor = Color.Black;
      this.labelPos33J.ImeMode = ImeMode.NoControl;
      this.labelPos33J.Location = new Point(135, 397);
      this.labelPos33J.Name = "labelPos33J";
      this.labelPos33J.Size = new Size(68, 40);
      this.labelPos33J.TabIndex = 48;
      this.labelPos33J.Text = "Tribune";
      this.labelPos33J.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos33J.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos33J.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos33J.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos33H.AllowDrop = true;
      this.labelPos33H.Anchor = AnchorStyles.Top;
      this.labelPos33H.BackColor = Color.Transparent;
      this.labelPos33H.Cursor = Cursors.Hand;
      this.labelPos33H.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos33H.ForeColor = Color.Black;
      this.labelPos33H.ImeMode = ImeMode.NoControl;
      this.labelPos33H.Location = new Point(-1, 397);
      this.labelPos33H.Name = "labelPos33H";
      this.labelPos33H.Size = new Size(68, 40);
      this.labelPos33H.TabIndex = 47;
      this.labelPos33H.Text = "Tribune";
      this.labelPos33H.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos33H.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos33H.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos33H.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos33I.AllowDrop = true;
      this.labelPos33I.Anchor = AnchorStyles.Top;
      this.labelPos33I.BackColor = Color.Transparent;
      this.labelPos33I.Cursor = Cursors.Hand;
      this.labelPos33I.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos33I.ForeColor = Color.Black;
      this.labelPos33I.ImeMode = ImeMode.NoControl;
      this.labelPos33I.Location = new Point(67, 397);
      this.labelPos33I.Name = "labelPos33I";
      this.labelPos33I.Size = new Size(68, 40);
      this.labelPos33I.TabIndex = 46;
      this.labelPos33I.Text = "Tribune";
      this.labelPos33I.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos33I.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos33I.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos33I.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos33G.AllowDrop = true;
      this.labelPos33G.Anchor = AnchorStyles.Top;
      this.labelPos33G.BackColor = Color.Transparent;
      this.labelPos33G.Cursor = Cursors.Hand;
      this.labelPos33G.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos33G.ForeColor = Color.Black;
      this.labelPos33G.ImeMode = ImeMode.NoControl;
      this.labelPos33G.Location = new Point(407, 357);
      this.labelPos33G.Name = "labelPos33G";
      this.labelPos33G.Size = new Size(68, 40);
      this.labelPos33G.TabIndex = 45;
      this.labelPos33G.Text = "Tribune";
      this.labelPos33G.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos33G.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos33G.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos33G.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos33F.AllowDrop = true;
      this.labelPos33F.Anchor = AnchorStyles.Top;
      this.labelPos33F.BackColor = Color.Transparent;
      this.labelPos33F.Cursor = Cursors.Hand;
      this.labelPos33F.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos33F.ForeColor = Color.Black;
      this.labelPos33F.ImeMode = ImeMode.NoControl;
      this.labelPos33F.Location = new Point(339, 357);
      this.labelPos33F.Name = "labelPos33F";
      this.labelPos33F.Size = new Size(68, 40);
      this.labelPos33F.TabIndex = 44;
      this.labelPos33F.Text = "Tribune";
      this.labelPos33F.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos33F.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos33F.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos33F.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos33E.AllowDrop = true;
      this.labelPos33E.Anchor = AnchorStyles.Top;
      this.labelPos33E.BackColor = Color.Transparent;
      this.labelPos33E.Cursor = Cursors.Hand;
      this.labelPos33E.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos33E.ForeColor = Color.Black;
      this.labelPos33E.ImeMode = ImeMode.NoControl;
      this.labelPos33E.Location = new Point(271, 357);
      this.labelPos33E.Name = "labelPos33E";
      this.labelPos33E.Size = new Size(68, 40);
      this.labelPos33E.TabIndex = 43;
      this.labelPos33E.Text = "Tribune";
      this.labelPos33E.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos33E.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos33E.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos33E.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos33D.AllowDrop = true;
      this.labelPos33D.Anchor = AnchorStyles.Top;
      this.labelPos33D.BackColor = Color.Transparent;
      this.labelPos33D.Cursor = Cursors.Hand;
      this.labelPos33D.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos33D.ForeColor = Color.Black;
      this.labelPos33D.ImeMode = ImeMode.NoControl;
      this.labelPos33D.Location = new Point(203, 357);
      this.labelPos33D.Name = "labelPos33D";
      this.labelPos33D.Size = new Size(68, 40);
      this.labelPos33D.TabIndex = 42;
      this.labelPos33D.Text = "Tribune";
      this.labelPos33D.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos33D.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos33D.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos33D.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos33C.AllowDrop = true;
      this.labelPos33C.Anchor = AnchorStyles.Top;
      this.labelPos33C.BackColor = Color.Transparent;
      this.labelPos33C.Cursor = Cursors.Hand;
      this.labelPos33C.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos33C.ForeColor = Color.Black;
      this.labelPos33C.ImeMode = ImeMode.NoControl;
      this.labelPos33C.Location = new Point(135, 357);
      this.labelPos33C.Name = "labelPos33C";
      this.labelPos33C.Size = new Size(68, 40);
      this.labelPos33C.TabIndex = 41;
      this.labelPos33C.Text = "Tribune";
      this.labelPos33C.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos33C.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos33C.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos33C.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos33A.AllowDrop = true;
      this.labelPos33A.Anchor = AnchorStyles.Top;
      this.labelPos33A.BackColor = Color.Transparent;
      this.labelPos33A.Cursor = Cursors.Hand;
      this.labelPos33A.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos33A.ForeColor = Color.Black;
      this.labelPos33A.ImeMode = ImeMode.NoControl;
      this.labelPos33A.Location = new Point(-1, 357);
      this.labelPos33A.Name = "labelPos33A";
      this.labelPos33A.Size = new Size(68, 40);
      this.labelPos33A.TabIndex = 40;
      this.labelPos33A.Text = "Tribune";
      this.labelPos33A.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos33A.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos33A.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos33A.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos33B.AllowDrop = true;
      this.labelPos33B.Anchor = AnchorStyles.Top;
      this.labelPos33B.BackColor = Color.Transparent;
      this.labelPos33B.Cursor = Cursors.Hand;
      this.labelPos33B.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos33B.ForeColor = Color.Black;
      this.labelPos33B.ImeMode = ImeMode.NoControl;
      this.labelPos33B.Location = new Point(67, 357);
      this.labelPos33B.Name = "labelPos33B";
      this.labelPos33B.Size = new Size(68, 40);
      this.labelPos33B.TabIndex = 39;
      this.labelPos33B.Text = "Tribune";
      this.labelPos33B.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos33B.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos33B.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos33B.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos32G.AllowDrop = true;
      this.labelPos32G.Anchor = AnchorStyles.Top;
      this.labelPos32G.BackColor = Color.Transparent;
      this.labelPos32G.Cursor = Cursors.Hand;
      this.labelPos32G.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos32G.ForeColor = Color.Black;
      this.labelPos32G.ImeMode = ImeMode.NoControl;
      this.labelPos32G.Location = new Point(407, 313);
      this.labelPos32G.Name = "labelPos32G";
      this.labelPos32G.Size = new Size(68, 40);
      this.labelPos32G.TabIndex = 38;
      this.labelPos32G.Text = "Bench";
      this.labelPos32G.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos32G.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos32G.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos32G.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos32F.AllowDrop = true;
      this.labelPos32F.Anchor = AnchorStyles.Top;
      this.labelPos32F.BackColor = Color.Transparent;
      this.labelPos32F.Cursor = Cursors.Hand;
      this.labelPos32F.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos32F.ForeColor = Color.Black;
      this.labelPos32F.ImeMode = ImeMode.NoControl;
      this.labelPos32F.Location = new Point(339, 313);
      this.labelPos32F.Name = "labelPos32F";
      this.labelPos32F.Size = new Size(68, 40);
      this.labelPos32F.TabIndex = 37;
      this.labelPos32F.Text = "Bench";
      this.labelPos32F.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos32F.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos32F.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos32F.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos32E.AllowDrop = true;
      this.labelPos32E.Anchor = AnchorStyles.Top;
      this.labelPos32E.BackColor = Color.Transparent;
      this.labelPos32E.Cursor = Cursors.Hand;
      this.labelPos32E.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos32E.ForeColor = Color.Black;
      this.labelPos32E.ImeMode = ImeMode.NoControl;
      this.labelPos32E.Location = new Point(271, 313);
      this.labelPos32E.Name = "labelPos32E";
      this.labelPos32E.Size = new Size(68, 40);
      this.labelPos32E.TabIndex = 36;
      this.labelPos32E.Text = "Bench";
      this.labelPos32E.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos32E.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos32E.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos32E.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos32D.AllowDrop = true;
      this.labelPos32D.Anchor = AnchorStyles.Top;
      this.labelPos32D.BackColor = Color.Transparent;
      this.labelPos32D.Cursor = Cursors.Hand;
      this.labelPos32D.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos32D.ForeColor = Color.Black;
      this.labelPos32D.ImeMode = ImeMode.NoControl;
      this.labelPos32D.Location = new Point(203, 313);
      this.labelPos32D.Name = "labelPos32D";
      this.labelPos32D.Size = new Size(68, 40);
      this.labelPos32D.TabIndex = 35;
      this.labelPos32D.Text = "Bench";
      this.labelPos32D.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos32D.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos32D.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos32D.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos32C.AllowDrop = true;
      this.labelPos32C.Anchor = AnchorStyles.Top;
      this.labelPos32C.BackColor = Color.Transparent;
      this.labelPos32C.Cursor = Cursors.Hand;
      this.labelPos32C.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos32C.ForeColor = Color.Black;
      this.labelPos32C.ImeMode = ImeMode.NoControl;
      this.labelPos32C.Location = new Point(135, 313);
      this.labelPos32C.Name = "labelPos32C";
      this.labelPos32C.Size = new Size(68, 40);
      this.labelPos32C.TabIndex = 34;
      this.labelPos32C.Text = "Bench";
      this.labelPos32C.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos32C.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos32C.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos32C.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos32A.AllowDrop = true;
      this.labelPos32A.Anchor = AnchorStyles.Top;
      this.labelPos32A.BackColor = Color.Transparent;
      this.labelPos32A.Cursor = Cursors.Hand;
      this.labelPos32A.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos32A.ForeColor = Color.Black;
      this.labelPos32A.ImeMode = ImeMode.NoControl;
      this.labelPos32A.Location = new Point(-1, 313);
      this.labelPos32A.Name = "labelPos32A";
      this.labelPos32A.Size = new Size(68, 40);
      this.labelPos32A.TabIndex = 33;
      this.labelPos32A.Text = "Bench";
      this.labelPos32A.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos32A.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos32A.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos32A.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos32B.AllowDrop = true;
      this.labelPos32B.Anchor = AnchorStyles.Top;
      this.labelPos32B.BackColor = Color.Transparent;
      this.labelPos32B.Cursor = Cursors.Hand;
      this.labelPos32B.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos32B.ForeColor = Color.Black;
      this.labelPos32B.ImeMode = ImeMode.NoControl;
      this.labelPos32B.Location = new Point(67, 313);
      this.labelPos32B.Name = "labelPos32B";
      this.labelPos32B.Size = new Size(68, 40);
      this.labelPos32B.TabIndex = 32;
      this.labelPos32B.Text = "Bench";
      this.labelPos32B.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos32B.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos32B.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos32B.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos26.AllowDrop = true;
      this.labelPos26.Anchor = AnchorStyles.Top;
      this.labelPos26.BackColor = Color.Transparent;
      this.labelPos26.Cursor = Cursors.Hand;
      this.labelPos26.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos26.ForeColor = Color.White;
      this.labelPos26.ImeMode = ImeMode.NoControl;
      this.labelPos26.Location = new Point(286, 264);
      this.labelPos26.Name = "labelPos26";
      this.labelPos26.Size = new Size(95, 40);
      this.labelPos26.TabIndex = 28;
      this.labelPos26.Text = "LS";
      this.labelPos26.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos26.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos26.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos26.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos27.AllowDrop = true;
      this.labelPos27.Anchor = AnchorStyles.Top;
      this.labelPos27.BackColor = Color.Transparent;
      this.labelPos27.Cursor = Cursors.Hand;
      this.labelPos27.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos27.ForeColor = Color.White;
      this.labelPos27.ImeMode = ImeMode.NoControl;
      this.labelPos27.Location = new Point(380, 249);
      this.labelPos27.Name = "labelPos27";
      this.labelPos27.Size = new Size(95, 40);
      this.labelPos27.TabIndex = 27;
      this.labelPos27.Text = "LW";
      this.labelPos27.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos27.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos27.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos27.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos21.AllowDrop = true;
      this.labelPos21.Anchor = AnchorStyles.Top;
      this.labelPos21.BackColor = Color.Transparent;
      this.labelPos21.Cursor = Cursors.Hand;
      this.labelPos21.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos21.ForeColor = Color.White;
      this.labelPos21.ImeMode = ImeMode.NoControl;
      this.labelPos21.Location = new Point(191, 228);
      this.labelPos21.Name = "labelPos21";
      this.labelPos21.Size = new Size(95, 40);
      this.labelPos21.TabIndex = 25;
      this.labelPos21.Text = "CF";
      this.labelPos21.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos21.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos21.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos21.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos22.AllowDrop = true;
      this.labelPos22.Anchor = AnchorStyles.Top;
      this.labelPos22.BackColor = Color.Transparent;
      this.labelPos22.Cursor = Cursors.Hand;
      this.labelPos22.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos22.ForeColor = Color.White;
      this.labelPos22.ImeMode = ImeMode.NoControl;
      this.labelPos22.Location = new Point(286, 230);
      this.labelPos22.Name = "labelPos22";
      this.labelPos22.Size = new Size(95, 40);
      this.labelPos22.TabIndex = 24;
      this.labelPos22.Text = "LF";
      this.labelPos22.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos22.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos22.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos22.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos23.AllowDrop = true;
      this.labelPos23.Anchor = AnchorStyles.Top;
      this.labelPos23.BackColor = Color.Transparent;
      this.labelPos23.Cursor = Cursors.Hand;
      this.labelPos23.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos23.ForeColor = Color.White;
      this.labelPos23.ImeMode = ImeMode.NoControl;
      this.labelPos23.Location = new Point(1, 249);
      this.labelPos23.Name = "labelPos23";
      this.labelPos23.Size = new Size(95, 40);
      this.labelPos23.TabIndex = 23;
      this.labelPos23.Text = "RW";
      this.labelPos23.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos23.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos23.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos23.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos24.AllowDrop = true;
      this.labelPos24.Anchor = AnchorStyles.Top;
      this.labelPos24.BackColor = Color.Transparent;
      this.labelPos24.Cursor = Cursors.Hand;
      this.labelPos24.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos24.ForeColor = Color.White;
      this.labelPos24.ImeMode = ImeMode.NoControl;
      this.labelPos24.Location = new Point(96, 264);
      this.labelPos24.Name = "labelPos24";
      this.labelPos24.Size = new Size(95, 40);
      this.labelPos24.TabIndex = 22;
      this.labelPos24.Text = "RS";
      this.labelPos24.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos24.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos24.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos24.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos25.AllowDrop = true;
      this.labelPos25.Anchor = AnchorStyles.Top;
      this.labelPos25.BackColor = Color.Transparent;
      this.labelPos25.Cursor = Cursors.Hand;
      this.labelPos25.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos25.ForeColor = Color.White;
      this.labelPos25.ImeMode = ImeMode.NoControl;
      this.labelPos25.Location = new Point(191, 264);
      this.labelPos25.Name = "labelPos25";
      this.labelPos25.Size = new Size(95, 40);
      this.labelPos25.TabIndex = 21;
      this.labelPos25.Text = "ST";
      this.labelPos25.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos25.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos25.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos25.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos14.AllowDrop = true;
      this.labelPos14.Anchor = AnchorStyles.Top;
      this.labelPos14.BackColor = Color.Transparent;
      this.labelPos14.Cursor = Cursors.Hand;
      this.labelPos14.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos14.ForeColor = Color.White;
      this.labelPos14.ImeMode = ImeMode.NoControl;
      this.labelPos14.Location = new Point(191, 150);
      this.labelPos14.Name = "labelPos14";
      this.labelPos14.Size = new Size(95, 40);
      this.labelPos14.TabIndex = 20;
      this.labelPos14.Text = "CM";
      this.labelPos14.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos14.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos14.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos14.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos15.AllowDrop = true;
      this.labelPos15.Anchor = AnchorStyles.Top;
      this.labelPos15.BackColor = Color.Transparent;
      this.labelPos15.Cursor = Cursors.Hand;
      this.labelPos15.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos15.ForeColor = Color.White;
      this.labelPos15.ImeMode = ImeMode.NoControl;
      this.labelPos15.Location = new Point(286, 150);
      this.labelPos15.Name = "labelPos15";
      this.labelPos15.Size = new Size(95, 40);
      this.labelPos15.TabIndex = 19;
      this.labelPos15.Text = "LCM";
      this.labelPos15.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos15.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos15.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos15.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos16.AllowDrop = true;
      this.labelPos16.Anchor = AnchorStyles.Top;
      this.labelPos16.BackColor = Color.Transparent;
      this.labelPos16.Cursor = Cursors.Hand;
      this.labelPos16.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos16.ForeColor = Color.White;
      this.labelPos16.ImeMode = ImeMode.NoControl;
      this.labelPos16.Location = new Point(381, 151);
      this.labelPos16.Name = "labelPos16";
      this.labelPos16.Size = new Size(95, 40);
      this.labelPos16.TabIndex = 18;
      this.labelPos16.Text = "LM";
      this.labelPos16.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos16.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos16.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos16.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos17.AllowDrop = true;
      this.labelPos17.Anchor = AnchorStyles.Top;
      this.labelPos17.BackColor = Color.Transparent;
      this.labelPos17.Cursor = Cursors.Hand;
      this.labelPos17.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos17.ForeColor = Color.White;
      this.labelPos17.ImeMode = ImeMode.NoControl;
      this.labelPos17.Location = new Point(56, 190);
      this.labelPos17.Name = "labelPos17";
      this.labelPos17.Size = new Size(95, 40);
      this.labelPos17.TabIndex = 17;
      this.labelPos17.Text = "RAM";
      this.labelPos17.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos17.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos17.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos17.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos18.AllowDrop = true;
      this.labelPos18.Anchor = AnchorStyles.Top;
      this.labelPos18.BackColor = Color.Transparent;
      this.labelPos18.Cursor = Cursors.Hand;
      this.labelPos18.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos18.ForeColor = Color.White;
      this.labelPos18.ImeMode = ImeMode.NoControl;
      this.labelPos18.Location = new Point(191, 188);
      this.labelPos18.Name = "labelPos18";
      this.labelPos18.Size = new Size(95, 40);
      this.labelPos18.TabIndex = 16;
      this.labelPos18.Text = "CAM";
      this.labelPos18.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos18.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos18.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos18.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos20.AllowDrop = true;
      this.labelPos20.Anchor = AnchorStyles.Top;
      this.labelPos20.BackColor = Color.Transparent;
      this.labelPos20.Cursor = Cursors.Hand;
      this.labelPos20.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos20.ForeColor = Color.White;
      this.labelPos20.ImeMode = ImeMode.NoControl;
      this.labelPos20.Location = new Point(96, 228);
      this.labelPos20.Name = "labelPos20";
      this.labelPos20.Size = new Size(95, 40);
      this.labelPos20.TabIndex = 15;
      this.labelPos20.Text = "RF";
      this.labelPos20.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos20.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos20.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos20.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos19.AllowDrop = true;
      this.labelPos19.Anchor = AnchorStyles.Top;
      this.labelPos19.BackColor = Color.Transparent;
      this.labelPos19.Cursor = Cursors.Hand;
      this.labelPos19.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos19.ForeColor = Color.White;
      this.labelPos19.ImeMode = ImeMode.NoControl;
      this.labelPos19.Location = new Point(326, 190);
      this.labelPos19.Name = "labelPos19";
      this.labelPos19.Size = new Size(95, 40);
      this.labelPos19.TabIndex = 14;
      this.labelPos19.Text = "LAM";
      this.labelPos19.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos19.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos19.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos19.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos9.AllowDrop = true;
      this.labelPos9.Anchor = AnchorStyles.Top;
      this.labelPos9.BackColor = Color.Transparent;
      this.labelPos9.Cursor = Cursors.Hand;
      this.labelPos9.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos9.ForeColor = Color.White;
      this.labelPos9.ImeMode = ImeMode.NoControl;
      this.labelPos9.Location = new Point(96, 110);
      this.labelPos9.Name = "labelPos9";
      this.labelPos9.Size = new Size(95, 40);
      this.labelPos9.TabIndex = 13;
      this.labelPos9.Text = "RDM";
      this.labelPos9.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos9.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos9.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos9.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos10.AllowDrop = true;
      this.labelPos10.Anchor = AnchorStyles.Top;
      this.labelPos10.BackColor = Color.Transparent;
      this.labelPos10.Cursor = Cursors.Hand;
      this.labelPos10.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos10.ForeColor = Color.White;
      this.labelPos10.ImeMode = ImeMode.NoControl;
      this.labelPos10.Location = new Point(191, 110);
      this.labelPos10.Name = "labelPos10";
      this.labelPos10.Size = new Size(95, 40);
      this.labelPos10.TabIndex = 12;
      this.labelPos10.Text = "CDM";
      this.labelPos10.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos10.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos10.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos10.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos11.AllowDrop = true;
      this.labelPos11.Anchor = AnchorStyles.Top;
      this.labelPos11.BackColor = Color.Transparent;
      this.labelPos11.Cursor = Cursors.Hand;
      this.labelPos11.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos11.ForeColor = Color.White;
      this.labelPos11.ImeMode = ImeMode.NoControl;
      this.labelPos11.Location = new Point(286, 110);
      this.labelPos11.Name = "labelPos11";
      this.labelPos11.Size = new Size(95, 40);
      this.labelPos11.TabIndex = 11;
      this.labelPos11.Text = "LDM";
      this.labelPos11.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos11.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos11.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos11.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos12.AllowDrop = true;
      this.labelPos12.Anchor = AnchorStyles.Top;
      this.labelPos12.BackColor = Color.Transparent;
      this.labelPos12.Cursor = Cursors.Hand;
      this.labelPos12.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos12.ForeColor = Color.White;
      this.labelPos12.ImeMode = ImeMode.NoControl;
      this.labelPos12.Location = new Point(1, 150);
      this.labelPos12.Name = "labelPos12";
      this.labelPos12.Size = new Size(95, 40);
      this.labelPos12.TabIndex = 10;
      this.labelPos12.Text = "RM";
      this.labelPos12.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos12.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos12.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos12.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos13.AllowDrop = true;
      this.labelPos13.Anchor = AnchorStyles.Top;
      this.labelPos13.BackColor = Color.Transparent;
      this.labelPos13.Cursor = Cursors.Hand;
      this.labelPos13.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos13.ForeColor = Color.White;
      this.labelPos13.ImeMode = ImeMode.NoControl;
      this.labelPos13.Location = new Point(96, 150);
      this.labelPos13.Name = "labelPos13";
      this.labelPos13.Size = new Size(95, 40);
      this.labelPos13.TabIndex = 9;
      this.labelPos13.Text = "RCM";
      this.labelPos13.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos13.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos13.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos13.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos2.AllowDrop = true;
      this.labelPos2.Anchor = AnchorStyles.Top;
      this.labelPos2.BackColor = Color.Transparent;
      this.labelPos2.Cursor = Cursors.Hand;
      this.labelPos2.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos2.ForeColor = Color.White;
      this.labelPos2.ImeMode = ImeMode.NoControl;
      this.labelPos2.Location = new Point(1, 95);
      this.labelPos2.Name = "labelPos2";
      this.labelPos2.Size = new Size(95, 40);
      this.labelPos2.TabIndex = 8;
      this.labelPos2.Text = "RWB";
      this.labelPos2.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos2.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos2.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos2.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos3.AllowDrop = true;
      this.labelPos3.Anchor = AnchorStyles.Top;
      this.labelPos3.BackColor = Color.Transparent;
      this.labelPos3.Cursor = Cursors.Hand;
      this.labelPos3.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos3.ForeColor = Color.White;
      this.labelPos3.ImeMode = ImeMode.NoControl;
      this.labelPos3.Location = new Point(1, 70);
      this.labelPos3.Name = "labelPos3";
      this.labelPos3.Size = new Size(95, 40);
      this.labelPos3.TabIndex = 7;
      this.labelPos3.Text = "RB";
      this.labelPos3.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos3.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos3.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos3.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos4.AllowDrop = true;
      this.labelPos4.Anchor = AnchorStyles.Top;
      this.labelPos4.BackColor = Color.Transparent;
      this.labelPos4.Cursor = Cursors.Hand;
      this.labelPos4.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos4.ForeColor = Color.White;
      this.labelPos4.ImeMode = ImeMode.NoControl;
      this.labelPos4.Location = new Point(96, 70);
      this.labelPos4.Name = "labelPos4";
      this.labelPos4.Size = new Size(95, 40);
      this.labelPos4.TabIndex = 6;
      this.labelPos4.Text = "RCB";
      this.labelPos4.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos4.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos4.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos4.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos5.AllowDrop = true;
      this.labelPos5.Anchor = AnchorStyles.Top;
      this.labelPos5.BackColor = Color.Transparent;
      this.labelPos5.Cursor = Cursors.Hand;
      this.labelPos5.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos5.ForeColor = Color.White;
      this.labelPos5.ImeMode = ImeMode.NoControl;
      this.labelPos5.Location = new Point(191, 70);
      this.labelPos5.Name = "labelPos5";
      this.labelPos5.Size = new Size(95, 40);
      this.labelPos5.TabIndex = 5;
      this.labelPos5.Text = "CB";
      this.labelPos5.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos5.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos5.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos5.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos6.AllowDrop = true;
      this.labelPos6.Anchor = AnchorStyles.Top;
      this.labelPos6.BackColor = Color.Transparent;
      this.labelPos6.Cursor = Cursors.Hand;
      this.labelPos6.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos6.ForeColor = Color.White;
      this.labelPos6.ImeMode = ImeMode.NoControl;
      this.labelPos6.Location = new Point(286, 70);
      this.labelPos6.Name = "labelPos6";
      this.labelPos6.Size = new Size(95, 40);
      this.labelPos6.TabIndex = 4;
      this.labelPos6.Text = "LCB";
      this.labelPos6.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos6.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos6.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos6.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos8.AllowDrop = true;
      this.labelPos8.Anchor = AnchorStyles.Top;
      this.labelPos8.BackColor = Color.Transparent;
      this.labelPos8.Cursor = Cursors.Hand;
      this.labelPos8.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos8.ForeColor = Color.White;
      this.labelPos8.ImeMode = ImeMode.NoControl;
      this.labelPos8.Location = new Point(381, 95);
      this.labelPos8.Name = "labelPos8";
      this.labelPos8.Size = new Size(95, 40);
      this.labelPos8.TabIndex = 3;
      this.labelPos8.Text = "LWB";
      this.labelPos8.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos8.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos8.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos8.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos7.AllowDrop = true;
      this.labelPos7.Anchor = AnchorStyles.Top;
      this.labelPos7.BackColor = Color.Transparent;
      this.labelPos7.Cursor = Cursors.Hand;
      this.labelPos7.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos7.ForeColor = Color.White;
      this.labelPos7.ImeMode = ImeMode.NoControl;
      this.labelPos7.Location = new Point(381, 70);
      this.labelPos7.Name = "labelPos7";
      this.labelPos7.Size = new Size(95, 40);
      this.labelPos7.TabIndex = 2;
      this.labelPos7.Text = "LB";
      this.labelPos7.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos7.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos7.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos7.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos0.AllowDrop = true;
      this.labelPos0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.labelPos0.BackColor = Color.Transparent;
      this.labelPos0.Cursor = Cursors.Hand;
      this.labelPos0.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos0.ForeColor = Color.White;
      this.labelPos0.ImeMode = ImeMode.NoControl;
      this.labelPos0.Location = new Point(191, 0);
      this.labelPos0.Name = "labelPos0";
      this.labelPos0.Size = new Size(95, 40);
      this.labelPos0.TabIndex = 0;
      this.labelPos0.Text = "GK";
      this.labelPos0.TextAlign = ContentAlignment.MiddleCenter;
      this.labelPos0.DragDrop += new DragEventHandler(this.labelPos_DragDrop);
      this.labelPos0.DragEnter += new DragEventHandler(this.labelPos_DragEnter);
      this.labelPos0.MouseDown += new MouseEventHandler(this.labelPos_MouseDown);
      this.labelPos1.AllowDrop = true;
      this.labelPos1.Anchor = AnchorStyles.Top;
      this.labelPos1.BackColor = Color.Transparent;
      this.labelPos1.Cursor = Cursors.Hand;
      this.labelPos1.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
      this.labelPos1.ForeColor = Color.White;
      this.labelPos1.ImeMode = ImeMode.NoControl;
      this.labelPos1.Location = new Point(191, 40);
      this.labelPos1.Name = "labelPos1";
      this.labelPos1.Size = new Size(95, 40);
      this.labelPos1.TabIndex = 1;
      this.labelPos1.Text = "SW";
      this.labelPos1.TextAlign = ContentAlignment.MiddleCenter;
      this.groupAvailablePlayers.BackColor = SystemColors.Control;
      this.groupAvailablePlayers.Controls.Add((Control) this.listViewPlayersAvailable);
      this.groupAvailablePlayers.Controls.Add((Control) this.panelAvailablePlayersTop);
      this.groupAvailablePlayers.Dock = DockStyle.Left;
      this.groupAvailablePlayers.Location = new Point(388, 3);
      this.groupAvailablePlayers.Name = "groupAvailablePlayers";
      this.groupAvailablePlayers.Size = new Size(341, 775);
      this.groupAvailablePlayers.TabIndex = 3;
      this.groupAvailablePlayers.TabStop = false;
      this.groupAvailablePlayers.Text = "Available Players";
      this.listViewPlayersAvailable.AllowColumnReorder = true;
      this.listViewPlayersAvailable.Columns.AddRange(new ColumnHeader[4]
      {
        this.columnHeader1,
        this.columnHeader2,
        this.columnHeader3,
        this.columnHeader4
      });
      this.listViewPlayersAvailable.Cursor = Cursors.Hand;
      this.listViewPlayersAvailable.Dock = DockStyle.Fill;
      this.listViewPlayersAvailable.Font = new Font("Microsoft Sans Serif", 8.25f);
      this.listViewPlayersAvailable.FullRowSelect = true;
      this.listViewPlayersAvailable.GridLines = true;
      this.listViewPlayersAvailable.HideSelection = false;
      this.listViewPlayersAvailable.Location = new Point(3, 214);
      this.listViewPlayersAvailable.MultiSelect = false;
      this.listViewPlayersAvailable.Name = "listViewPlayersAvailable";
      this.listViewPlayersAvailable.Size = new Size(335, 558);
      this.listViewPlayersAvailable.TabIndex = 4;
      this.listViewPlayersAvailable.UseCompatibleStateImageBehavior = false;
      this.listViewPlayersAvailable.View = View.Details;
      this.listViewPlayersAvailable.ColumnClick += new ColumnClickEventHandler(this.listView_ColumnClick);
      this.listViewPlayersAvailable.SelectedIndexChanged += new EventHandler(this.listViewPlayersAvailable_SelectedIndexChanged);
      this.listViewPlayersAvailable.DoubleClick += new EventHandler(this.listViewPlayersAvailable_DoubleClick);
      this.columnHeader1.Text = "Surname";
      this.columnHeader1.Width = 108;
      this.columnHeader2.Text = "First Name";
      this.columnHeader2.Width = 108;
      this.columnHeader3.Text = "Role";
      this.columnHeader3.TextAlign = HorizontalAlignment.Center;
      this.columnHeader3.Width = 42;
      this.columnHeader4.Text = "Avg.";
      this.columnHeader4.TextAlign = HorizontalAlignment.Center;
      this.columnHeader4.Width = 42;
      this.panelAvailablePlayersTop.BackColor = Color.Transparent;
      this.panelAvailablePlayersTop.Controls.Add((Control) this.buttonTransferFrom);
      this.panelAvailablePlayersTop.Controls.Add((Control) this.pickUpAvailablePlayers);
      this.panelAvailablePlayersTop.Controls.Add((Control) this.buttonCall);
      this.panelAvailablePlayersTop.Controls.Add((Control) this.labelAvailablePlayerStars);
      this.panelAvailablePlayersTop.Controls.Add((Control) this.labelRosterNameFrom);
      this.panelAvailablePlayersTop.Controls.Add((Control) this.pictureAvailablePlayer);
      this.panelAvailablePlayersTop.Dock = DockStyle.Top;
      this.panelAvailablePlayersTop.Location = new Point(3, 16);
      this.panelAvailablePlayersTop.Name = "panelAvailablePlayersTop";
      this.panelAvailablePlayersTop.Size = new Size(335, 198);
      this.panelAvailablePlayersTop.TabIndex = 149;
      this.buttonTransferFrom.ImeMode = ImeMode.NoControl;
      this.buttonTransferFrom.Location = new Point(12, 9);
      this.buttonTransferFrom.Name = "buttonTransferFrom";
      this.buttonTransferFrom.Size = new Size(68, 50);
      this.buttonTransferFrom.TabIndex = 0;
      this.buttonTransferFrom.Text = "Transfer <<";
      this.buttonTransferFrom.UseVisualStyleBackColor = true;
      this.buttonTransferFrom.Click += new EventHandler(this.buttonTransferFrom_Click);
      this.pickUpAvailablePlayers.BackColor = SystemColors.Control;
      this.pickUpAvailablePlayers.CloneButtonEnabled = false;
      this.pickUpAvailablePlayers.CreateButtonEnabled = false;
      this.pickUpAvailablePlayers.CurrentIndex = 0;
      this.pickUpAvailablePlayers.Dock = DockStyle.Bottom;
      this.pickUpAvailablePlayers.FilterByList = new string[5]
      {
        "All",
        "By Team",
        "By Country",
        "By Role",
        "Free Agent"
      };
      this.pickUpAvailablePlayers.FilterEnabled = true;
      this.pickUpAvailablePlayers.FilterValues = (IdArrayList[]) null;
      this.pickUpAvailablePlayers.Location = new Point(0, 173);
      this.pickUpAvailablePlayers.MainSelectionEnabled = false;
      this.pickUpAvailablePlayers.Name = "pickUpAvailablePlayers";
      this.pickUpAvailablePlayers.ObjectList = (IdArrayList) null;
      this.pickUpAvailablePlayers.RefreshButtonEnabled = false;
      this.pickUpAvailablePlayers.RemoveButtonEnabled = false;
      this.pickUpAvailablePlayers.SearchEnabled = false;
      this.pickUpAvailablePlayers.Size = new Size(335, 25);
      this.pickUpAvailablePlayers.TabIndex = 148;
      this.pickUpAvailablePlayers.WizardButtonEnabled = false;
      this.pickUpAvailablePlayers.YoungPlayersEnabled = false;
      this.buttonCall.Enabled = false;
      this.buttonCall.ImeMode = ImeMode.NoControl;
      this.buttonCall.Location = new Point(12, 68);
      this.buttonCall.Name = "buttonCall";
      this.buttonCall.Size = new Size(68, 50);
      this.buttonCall.TabIndex = 1;
      this.buttonCall.Text = "     Call       <<";
      this.buttonCall.UseVisualStyleBackColor = true;
      this.buttonCall.Click += new EventHandler(this.buttonCall_Click);
      this.labelAvailablePlayerStars.ImageAlign = ContentAlignment.MiddleLeft;
      this.labelAvailablePlayerStars.ImageIndex = 9;
      this.labelAvailablePlayerStars.ImageList = this.imageListStars;
      this.labelAvailablePlayerStars.Location = new Point(203, 142);
      this.labelAvailablePlayerStars.Name = "labelAvailablePlayerStars";
      this.labelAvailablePlayerStars.Size = new Size(101, 20);
      this.labelAvailablePlayerStars.TabIndex = 147;
      this.labelAvailablePlayerStars.TextAlign = ContentAlignment.MiddleLeft;
      this.imageListStars.ImageStream = (ImageListStreamer) resources.GetObject("imageListStars.ImageStream");
      this.imageListStars.TransparentColor = Color.Fuchsia;
      this.imageListStars.Images.SetKeyName(0, "Stars_0_5.PNG");
      this.imageListStars.Images.SetKeyName(1, "Stars_1.PNG");
      this.imageListStars.Images.SetKeyName(2, "Stars_1_5.PNG");
      this.imageListStars.Images.SetKeyName(3, "Stars_2.PNG");
      this.imageListStars.Images.SetKeyName(4, "Stars_2_5.PNG");
      this.imageListStars.Images.SetKeyName(5, "Stars_3.PNG");
      this.imageListStars.Images.SetKeyName(6, "Stars_3_5.PNG");
      this.imageListStars.Images.SetKeyName(7, "Stars_4.PNG");
      this.imageListStars.Images.SetKeyName(8, "Stars_4_5.PNG");
      this.imageListStars.Images.SetKeyName(9, "Stars_5.PNG");
      this.labelRosterNameFrom.BackColor = SystemColors.Control;
      this.labelRosterNameFrom.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelRosterNameFrom.ImeMode = ImeMode.NoControl;
      this.labelRosterNameFrom.Location = new Point(41, 142);
      this.labelRosterNameFrom.Name = "labelRosterNameFrom";
      this.labelRosterNameFrom.Size = new Size(156, 20);
      this.labelRosterNameFrom.TabIndex = 144;
      this.labelRosterNameFrom.TextAlign = ContentAlignment.MiddleCenter;
      this.pictureAvailablePlayer.Location = new Point(131, 6);
      this.pictureAvailablePlayer.Name = "pictureAvailablePlayer";
      this.pictureAvailablePlayer.Size = new Size(128, 128);
      this.pictureAvailablePlayer.TabIndex = 146;
      this.pictureAvailablePlayer.TabStop = false;
      this.groupTeamPlayers.BackColor = SystemColors.Control;
      this.groupTeamPlayers.Controls.Add((Control) this.listViewTeamPlayers);
      this.groupTeamPlayers.Controls.Add((Control) this.panelTeamPlayersTop);
      this.groupTeamPlayers.Dock = DockStyle.Left;
      this.groupTeamPlayers.Location = new Point(3, 3);
      this.groupTeamPlayers.Name = "groupTeamPlayers";
      this.groupTeamPlayers.Size = new Size(385, 775);
      this.groupTeamPlayers.TabIndex = 0;
      this.groupTeamPlayers.TabStop = false;
      this.groupTeamPlayers.Text = "Team Players";
      this.listViewTeamPlayers.AllowDrop = true;
      this.listViewTeamPlayers.Columns.AddRange(new ColumnHeader[6]
      {
        this.columnRosterNum,
        this.columnRosterSurname,
        this.columnRosterFirstName,
        this.columnRosterYearContract,
        this.columnPreferredRole,
        this.columnAverageAttributes
      });
      this.listViewTeamPlayers.Cursor = Cursors.Hand;
      this.listViewTeamPlayers.Dock = DockStyle.Fill;
      this.listViewTeamPlayers.FullRowSelect = true;
      this.listViewTeamPlayers.GridLines = true;
      this.listViewTeamPlayers.HideSelection = false;
      this.listViewTeamPlayers.Location = new Point(3, 214);
      this.listViewTeamPlayers.MultiSelect = false;
      this.listViewTeamPlayers.Name = "listViewTeamPlayers";
      this.listViewTeamPlayers.Size = new Size(379, 558);
      this.listViewTeamPlayers.TabIndex = 8;
      this.listViewTeamPlayers.UseCompatibleStateImageBehavior = false;
      this.listViewTeamPlayers.View = View.Details;
      this.listViewTeamPlayers.ColumnClick += new ColumnClickEventHandler(this.listView_ColumnClick);
      this.listViewTeamPlayers.SelectedIndexChanged += new EventHandler(this.listViewTeamPlayers_SelectedIndexChanged);
      this.listViewTeamPlayers.DoubleClick += new EventHandler(this.listViewTeamPlayers_DoubleClick);
      this.columnRosterNum.Text = "N.";
      this.columnRosterNum.Width = 25;
      this.columnRosterSurname.Text = "Surname";
      this.columnRosterSurname.Width = 90;
      this.columnRosterFirstName.Text = "First Name";
      this.columnRosterFirstName.Width = 90;
      this.columnRosterYearContract.Text = "Y.C.";
      this.columnRosterYearContract.Width = 42;
      this.columnPreferredRole.Text = "Role";
      this.columnPreferredRole.TextAlign = HorizontalAlignment.Center;
      this.columnPreferredRole.Width = 44;
      this.columnAverageAttributes.Text = "Overall";
      this.columnAverageAttributes.TextAlign = HorizontalAlignment.Center;
      this.columnAverageAttributes.Width = 52;
      this.panelTeamPlayersTop.Controls.Add((Control) this.viewer2DPhoto);
      this.panelTeamPlayersTop.Controls.Add((Control) this.groupTeamPlayerTuning);
      this.panelTeamPlayersTop.Controls.Add((Control) this.groupContract);
      this.panelTeamPlayersTop.Controls.Add((Control) this.labelRosterName);
      this.panelTeamPlayersTop.Controls.Add((Control) this.comboRosterNumber);
      this.panelTeamPlayersTop.Controls.Add((Control) this.buttonTransferPlayer);
      this.panelTeamPlayersTop.Controls.Add((Control) this.buttonRosterLetFree);
      this.panelTeamPlayersTop.Controls.Add((Control) this.labelRosterNumber);
      this.panelTeamPlayersTop.Dock = DockStyle.Top;
      this.panelTeamPlayersTop.Location = new Point(3, 16);
      this.panelTeamPlayersTop.Name = "panelTeamPlayersTop";
      this.panelTeamPlayersTop.Size = new Size(379, 198);
      this.panelTeamPlayersTop.TabIndex = 132;
      this.toolTip.SetToolTip((Control) this.panelTeamPlayersTop, "Add 1 year of contract to all player");
      this.viewer2DPhoto.AutoTransparency = true;
      this.viewer2DPhoto.BackColor = Color.Transparent;
      this.viewer2DPhoto.ButtonStripVisible = false;
      this.viewer2DPhoto.CurrentBitmap = (Bitmap) null;
      this.viewer2DPhoto.ExtendedFormat = false;
      this.viewer2DPhoto.FullSizeButton = false;
      this.viewer2DPhoto.ImageLayout = ImageLayout.None;
      this.viewer2DPhoto.ImageSize = new Size(128, 128);
      this.viewer2DPhoto.ImageSizeMultiplier = Viewer2D.SizeMultiplier.MiniFace;
      this.viewer2DPhoto.Location = new Point(19, 6);
      this.viewer2DPhoto.Name = "viewer2DPhoto";
      this.viewer2DPhoto.RemoveButton = false;
      this.viewer2DPhoto.ShowButton = false;
      this.viewer2DPhoto.ShowButtonChecked = true;
      this.viewer2DPhoto.Size = new Size(128, 153);
      this.viewer2DPhoto.TabIndex = 162;
      this.viewer2DPhoto.TabStop = false;
      this.groupTeamPlayerTuning.Controls.Add((Control) this.buttonTeamPlayerMinus);
      this.groupTeamPlayerTuning.Controls.Add((Control) this.buttonTeamPlayerPlus);
      this.groupTeamPlayerTuning.Controls.Add((Control) this.labelTeamPlayerStars);
      this.groupTeamPlayerTuning.Location = new Point(164, 132);
      this.groupTeamPlayerTuning.Name = "groupTeamPlayerTuning";
      this.groupTeamPlayerTuning.Size = new Size(212, 60);
      this.groupTeamPlayerTuning.TabIndex = 161;
      this.groupTeamPlayerTuning.TabStop = false;
      this.groupTeamPlayerTuning.Text = "Rating";
      this.toolTip.SetToolTip((Control) this.groupTeamPlayerTuning, "Increase all players overall");
      this.buttonTeamPlayerMinus.BackgroundImage = (Image) resources.GetObject("buttonTeamPlayerMinus.BackgroundImage");
      this.buttonTeamPlayerMinus.BackgroundImageLayout = ImageLayout.Center;
      this.buttonTeamPlayerMinus.Location = new Point(156, 9);
      this.buttonTeamPlayerMinus.Name = "buttonTeamPlayerMinus";
      this.buttonTeamPlayerMinus.Size = new Size(48, 48);
      this.buttonTeamPlayerMinus.TabIndex = 1;
      this.toolTip.SetToolTip((Control) this.buttonTeamPlayerMinus, "Decrease all players overall");
      this.buttonTeamPlayerMinus.UseVisualStyleBackColor = false;
      this.buttonTeamPlayerMinus.Click += new EventHandler(this.buttonTeamPlayerMinus_Click);
      this.buttonTeamPlayerPlus.BackgroundImage = (Image) resources.GetObject("buttonTeamPlayerPlus.BackgroundImage");
      this.buttonTeamPlayerPlus.BackgroundImageLayout = ImageLayout.Center;
      this.buttonTeamPlayerPlus.Location = new Point(103, 9);
      this.buttonTeamPlayerPlus.Name = "buttonTeamPlayerPlus";
      this.buttonTeamPlayerPlus.Size = new Size(48, 48);
      this.buttonTeamPlayerPlus.TabIndex = 0;
      this.toolTip.SetToolTip((Control) this.buttonTeamPlayerPlus, "Increase all players overall");
      this.buttonTeamPlayerPlus.UseVisualStyleBackColor = false;
      this.buttonTeamPlayerPlus.Click += new EventHandler(this.buttonTeamPlayerPlus_Click);
      this.labelTeamPlayerStars.ImageAlign = ContentAlignment.MiddleLeft;
      this.labelTeamPlayerStars.ImageIndex = 9;
      this.labelTeamPlayerStars.ImageList = this.imageListStars;
      this.labelTeamPlayerStars.Location = new Point(3, 23);
      this.labelTeamPlayerStars.Name = "labelTeamPlayerStars";
      this.labelTeamPlayerStars.Size = new Size(101, 20);
      this.labelTeamPlayerStars.TabIndex = 5;
      this.labelTeamPlayerStars.TextAlign = ContentAlignment.MiddleLeft;
      this.groupContract.Controls.Add((Control) this.label2);
      this.groupContract.Controls.Add((Control) this.buttonPlusContract);
      this.groupContract.Controls.Add((Control) this.buttonMinusContract);
      this.groupContract.Controls.Add((Control) this.dateJoiningDate);
      this.groupContract.Controls.Add((Control) this.numericRosterYear);
      this.groupContract.Controls.Add((Control) this.labelJoiningDate);
      this.groupContract.Location = new Point(155, 25);
      this.groupContract.Name = "groupContract";
      this.groupContract.Size = new Size(136, 107);
      this.groupContract.TabIndex = 136;
      this.groupContract.TabStop = false;
      this.groupContract.Text = "Contract";
      this.label2.AutoSize = true;
      this.label2.ImeMode = ImeMode.NoControl;
      this.label2.Location = new Point(6, 18);
      this.label2.Name = "label2";
      this.label2.Size = new Size(28, 13);
      this.label2.TabIndex = 136;
      this.label2.Text = "Until";
      this.label2.TextAlign = ContentAlignment.MiddleLeft;
      this.buttonPlusContract.BackgroundImage = (Image) resources.GetObject("buttonPlusContract.BackgroundImage");
      this.buttonPlusContract.BackgroundImageLayout = ImageLayout.Center;
      this.buttonPlusContract.Location = new Point(38, 62);
      this.buttonPlusContract.Name = "buttonPlusContract";
      this.buttonPlusContract.Size = new Size(40, 40);
      this.buttonPlusContract.TabIndex = 134;
      this.toolTip.SetToolTip((Control) this.buttonPlusContract, "Increase 1 year of contract to all players");
      this.buttonPlusContract.UseVisualStyleBackColor = false;
      this.buttonPlusContract.Click += new EventHandler(this.buttonPlusContract_Click);
      this.buttonMinusContract.BackgroundImage = (Image) resources.GetObject("buttonMinusContract.BackgroundImage");
      this.buttonMinusContract.BackgroundImageLayout = ImageLayout.Center;
      this.buttonMinusContract.Location = new Point(90, 62);
      this.buttonMinusContract.Name = "buttonMinusContract";
      this.buttonMinusContract.Size = new Size(40, 40);
      this.buttonMinusContract.TabIndex = 135;
      this.toolTip.SetToolTip((Control) this.buttonMinusContract, "Decrease 1 year of contract to all players");
      this.buttonMinusContract.UseVisualStyleBackColor = false;
      this.buttonMinusContract.Click += new EventHandler(this.buttonMinusContract_Click);
      this.dateJoiningDate.Format = DateTimePickerFormat.Short;
      this.dateJoiningDate.Location = new Point(38, 42);
      this.dateJoiningDate.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
      this.dateJoiningDate.MinDate = new DateTime(1800, 1, 1, 0, 0, 0, 0);
      this.dateJoiningDate.Name = "dateJoiningDate";
      this.dateJoiningDate.Size = new Size(92, 20);
      this.dateJoiningDate.TabIndex = 132;
      this.dateJoiningDate.Value = new DateTime(2006, 12, 31, 0, 0, 0, 0);
      this.dateJoiningDate.ValueChanged += new EventHandler(this.dateJoiningDate_ValueChanged);
      this.numericRosterYear.Location = new Point(38, 16);
      this.numericRosterYear.Maximum = new Decimal(new int[4]
      {
        2030,
        0,
        0,
        0
      });
      this.numericRosterYear.Minimum = new Decimal(new int[4]
      {
        2005,
        0,
        0,
        0
      });
      this.numericRosterYear.Name = "numericRosterYear";
      this.numericRosterYear.Size = new Size(92, 20);
      this.numericRosterYear.TabIndex = 3;
      this.numericRosterYear.TextAlign = HorizontalAlignment.Center;
      this.numericRosterYear.Value = new Decimal(new int[4]
      {
        2005,
        0,
        0,
        0
      });
      this.numericRosterYear.ValueChanged += new EventHandler(this.numericRosterYear_ValueChanged);
      this.labelJoiningDate.AutoSize = true;
      this.labelJoiningDate.ImeMode = ImeMode.NoControl;
      this.labelJoiningDate.Location = new Point(8, 42);
      this.labelJoiningDate.Name = "labelJoiningDate";
      this.labelJoiningDate.Size = new Size(26, 13);
      this.labelJoiningDate.TabIndex = 133;
      this.labelJoiningDate.Text = "Join";
      this.labelJoiningDate.TextAlign = ContentAlignment.MiddleLeft;
      this.labelRosterName.BackColor = SystemColors.Control;
      this.labelRosterName.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelRosterName.ImeMode = ImeMode.NoControl;
      this.labelRosterName.Location = new Point(4, 162);
      this.labelRosterName.Name = "labelRosterName";
      this.labelRosterName.Size = new Size(159, 20);
      this.labelRosterName.TabIndex = 4;
      this.labelRosterName.TextAlign = ContentAlignment.MiddleCenter;
      this.comboRosterNumber.FormattingEnabled = true;
      this.comboRosterNumber.Location = new Point(197, 6);
      this.comboRosterNumber.Name = "comboRosterNumber";
      this.comboRosterNumber.Size = new Size(67, 21);
      this.comboRosterNumber.TabIndex = 2;
      this.comboRosterNumber.SelectedIndexChanged += new EventHandler(this.comboRosterNumber_SelectedIndexChanged);
      this.buttonTransferPlayer.ImeMode = ImeMode.NoControl;
      this.buttonTransferPlayer.Location = new Point(297, 6);
      this.buttonTransferPlayer.Name = "buttonTransferPlayer";
      this.buttonTransferPlayer.Size = new Size(68, 50);
      this.buttonTransferPlayer.TabIndex = 0;
      this.buttonTransferPlayer.Text = "Transfer >>";
      this.buttonTransferPlayer.UseVisualStyleBackColor = true;
      this.buttonTransferPlayer.Click += new EventHandler(this.buttonTransferPlayer_Click);
      this.buttonRosterLetFree.ImeMode = ImeMode.NoControl;
      this.buttonRosterLetFree.Location = new Point(297, 68);
      this.buttonRosterLetFree.Name = "buttonRosterLetFree";
      this.buttonRosterLetFree.Size = new Size(68, 50);
      this.buttonRosterLetFree.TabIndex = 1;
      this.buttonRosterLetFree.Text = "Let Free >>";
      this.buttonRosterLetFree.UseVisualStyleBackColor = true;
      this.buttonRosterLetFree.Click += new EventHandler(this.buttonRosterLetFree_Click);
      this.labelRosterNumber.AutoSize = true;
      this.labelRosterNumber.BackColor = SystemColors.Control;
      this.labelRosterNumber.ImeMode = ImeMode.NoControl;
      this.labelRosterNumber.Location = new Point(167, 9);
      this.labelRosterNumber.Name = "labelRosterNumber";
      this.labelRosterNumber.Size = new Size(18, 13);
      this.labelRosterNumber.TabIndex = 6;
      this.labelRosterNumber.Text = "N.";
      this.labelRosterNumber.TextAlign = ContentAlignment.MiddleLeft;
      this.pageTeamAdboard.AutoScroll = true;
      this.pageTeamAdboard.Controls.Add((Control) this.numericAdboards);
      this.pageTeamAdboard.Controls.Add((Control) this.checkHasSpecificAdboard);
      this.pageTeamAdboard.Controls.Add((Control) this.labelAdboard);
      this.pageTeamAdboard.Controls.Add((Control) this.viewer2DAdboards_0);
      this.pageTeamAdboard.Location = new Point(4, 22);
      this.pageTeamAdboard.Name = "pageTeamAdboard";
      this.pageTeamAdboard.Size = new Size(1349, 781);
      this.pageTeamAdboard.TabIndex = 2;
      this.pageTeamAdboard.Text = "Adboards";
      this.pageTeamAdboard.UseVisualStyleBackColor = true;
      this.numericAdboards.Location = new Point(115, 32);
      this.numericAdboards.Maximum = new Decimal(new int[4]
      {
        245,
        0,
        0,
        0
      });
      this.numericAdboards.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericAdboards.Name = "numericAdboards";
      this.numericAdboards.Size = new Size(112, 20);
      this.numericAdboards.TabIndex = 0;
      this.numericAdboards.TextAlign = HorizontalAlignment.Center;
      this.numericAdboards.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericAdboards.ValueChanged += new EventHandler(this.numericAdboards_ValueChanged);
      this.checkHasSpecificAdboard.AutoSize = true;
      this.checkHasSpecificAdboard.Location = new Point(25, 9);
      this.checkHasSpecificAdboard.Name = "checkHasSpecificAdboard";
      this.checkHasSpecificAdboard.Size = new Size(129, 17);
      this.checkHasSpecificAdboard.TabIndex = 5;
      this.checkHasSpecificAdboard.Text = "Has Specific Adboard";
      this.toolTip.SetToolTip((Control) this.checkHasSpecificAdboard, "Create an Adboard specific for this team");
      this.checkHasSpecificAdboard.UseVisualStyleBackColor = true;
      this.checkHasSpecificAdboard.CheckedChanged += new EventHandler(this.checkHasSpecificAdboard_CheckedChanged);
      this.labelAdboard.AutoSize = true;
      this.labelAdboard.Location = new Point(22, 34);
      this.labelAdboard.Name = "labelAdboard";
      this.labelAdboard.Size = new Size(87, 13);
      this.labelAdboard.TabIndex = 4;
      this.labelAdboard.Text = "Adboard Number";
      this.viewer2DAdboards_0.AutoTransparency = false;
      this.viewer2DAdboards_0.BackColor = Color.Transparent;
      this.viewer2DAdboards_0.ButtonStripVisible = false;
      this.viewer2DAdboards_0.CurrentBitmap = (Bitmap) null;
      this.viewer2DAdboards_0.ExtendedFormat = false;
      this.viewer2DAdboards_0.FullSizeButton = false;
      this.viewer2DAdboards_0.ImageLayout = ImageLayout.Zoom;
      this.viewer2DAdboards_0.ImageSize = new Size(512, 1024);
      this.viewer2DAdboards_0.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DAdboards_0.Location = new Point(8, 58);
      this.viewer2DAdboards_0.Name = "viewer2DAdboards_0";
      this.viewer2DAdboards_0.RemoveButton = false;
      this.viewer2DAdboards_0.ShowButton = false;
      this.viewer2DAdboards_0.ShowButtonChecked = true;
      this.viewer2DAdboards_0.Size = new Size(256, 537);
      this.viewer2DAdboards_0.TabIndex = 3;
      this.pageTeamFlags.AutoScroll = true;
      this.pageTeamFlags.Controls.Add((Control) this.groupFlag);
      this.pageTeamFlags.Controls.Add((Control) this.viewer2DBanners);
      this.pageTeamFlags.Location = new Point(4, 22);
      this.pageTeamFlags.Name = "pageTeamFlags";
      this.pageTeamFlags.Size = new Size(1349, 781);
      this.pageTeamFlags.TabIndex = 3;
      this.pageTeamFlags.Text = "Flags";
      this.pageTeamFlags.UseVisualStyleBackColor = true;
      this.groupFlag.Controls.Add((Control) this.multiViewer2DFlags15);
      this.groupFlag.Controls.Add((Control) this.buttonCreateFlags);
      this.groupFlag.Controls.Add((Control) this.pictureBox4);
      this.groupFlag.Controls.Add((Control) this.label22);
      this.groupFlag.Controls.Add((Control) this.pictureFlagBlue);
      this.groupFlag.Controls.Add((Control) this.pictureFlagRed);
      this.groupFlag.Controls.Add((Control) this.pictureFlagGreen);
      this.groupFlag.Controls.Add((Control) this.checkFlag4);
      this.groupFlag.Controls.Add((Control) this.checkFlag3);
      this.groupFlag.Controls.Add((Control) this.checkFlag2);
      this.groupFlag.Controls.Add((Control) this.checkFlag1);
      this.groupFlag.Controls.Add((Control) this.labelFlag4);
      this.groupFlag.Controls.Add((Control) this.labelFlag3);
      this.groupFlag.Controls.Add((Control) this.labelFlag2);
      this.groupFlag.Controls.Add((Control) this.labelFlag1);
      this.groupFlag.Location = new Point(526, 3);
      this.groupFlag.Name = "groupFlag";
      this.groupFlag.Size = new Size(532, 405);
      this.groupFlag.TabIndex = 2;
      this.groupFlag.TabStop = false;
      this.groupFlag.Text = "Flags";
      this.multiViewer2DFlags15.AutoTransparency = false;
      this.multiViewer2DFlags15.Bitmaps = (Bitmap[]) null;
      this.multiViewer2DFlags15.CheckBitmapSize = true;
      this.multiViewer2DFlags15.FixedSize = false;
      this.multiViewer2DFlags15.FullSizeButton = false;
      this.multiViewer2DFlags15.LabelText = "Flag n.";
      this.multiViewer2DFlags15.Location = new Point(6, 19);
      this.multiViewer2DFlags15.Name = "multiViewer2DFlags15";
      this.multiViewer2DFlags15.ShowDeleteButton = false;
      this.multiViewer2DFlags15.Size = new Size(514, 302);
      this.multiViewer2DFlags15.TabIndex = 154;
      this.buttonCreateFlags.Location = new Point(403, 335);
      this.buttonCreateFlags.Name = "buttonCreateFlags";
      this.buttonCreateFlags.Size = new Size(104, 55);
      this.buttonCreateFlags.TabIndex = 153;
      this.buttonCreateFlags.Text = "Create Flags";
      this.buttonCreateFlags.UseVisualStyleBackColor = true;
      this.buttonCreateFlags.Click += new EventHandler(this.buttonCreateFlags_Click);
      this.pictureBox4.BackgroundImage = (Image) resources.GetObject("pictureBox4.BackgroundImage");
      this.pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
      this.pictureBox4.Location = new Point(286, 347);
      this.pictureBox4.Name = "pictureBox4";
      this.pictureBox4.Size = new Size(98, 13);
      this.pictureBox4.TabIndex = 152;
      this.pictureBox4.TabStop = false;
      this.label22.AutoSize = true;
      this.label22.BackColor = Color.Transparent;
      this.label22.ImeMode = ImeMode.NoControl;
      this.label22.Location = new Point(320, 331);
      this.label22.Name = "label22";
      this.label22.Size = new Size(36, 13);
      this.label22.TabIndex = 151;
      this.label22.Text = "Colors";
      this.label22.TextAlign = ContentAlignment.TopCenter;
      this.pictureFlagBlue.BorderStyle = BorderStyle.FixedSingle;
      this.pictureFlagBlue.Cursor = Cursors.Hand;
      this.pictureFlagBlue.DataBindings.Add(new Binding("BackColor", (object) this.teamBindingSource, "TeamColor3", true));
      this.pictureFlagBlue.ImeMode = ImeMode.NoControl;
      this.pictureFlagBlue.Location = new Point(360, 366);
      this.pictureFlagBlue.Name = "pictureFlagBlue";
      this.pictureFlagBlue.Size = new Size(24, 24);
      this.pictureFlagBlue.TabIndex = 150;
      this.pictureFlagBlue.TabStop = false;
      this.pictureFlagBlue.Click += new EventHandler(this.pictureFlagBlue_Click);
      this.pictureFlagRed.BorderStyle = BorderStyle.FixedSingle;
      this.pictureFlagRed.Cursor = Cursors.Hand;
      this.pictureFlagRed.DataBindings.Add(new Binding("BackColor", (object) this.teamBindingSource, "TeamColor1", true));
      this.pictureFlagRed.ImeMode = ImeMode.NoControl;
      this.pictureFlagRed.Location = new Point(286, 366);
      this.pictureFlagRed.Name = "pictureFlagRed";
      this.pictureFlagRed.Size = new Size(24, 24);
      this.pictureFlagRed.TabIndex = 148;
      this.pictureFlagRed.TabStop = false;
      this.pictureFlagRed.Click += new EventHandler(this.pictureFlagRed_Click);
      this.pictureFlagGreen.BorderStyle = BorderStyle.FixedSingle;
      this.pictureFlagGreen.Cursor = Cursors.Hand;
      this.pictureFlagGreen.DataBindings.Add(new Binding("BackColor", (object) this.teamBindingSource, "TeamColor2", true));
      this.pictureFlagGreen.ImeMode = ImeMode.NoControl;
      this.pictureFlagGreen.Location = new Point(323, 366);
      this.pictureFlagGreen.Name = "pictureFlagGreen";
      this.pictureFlagGreen.Size = new Size(24, 24);
      this.pictureFlagGreen.TabIndex = 149;
      this.pictureFlagGreen.TabStop = false;
      this.pictureFlagGreen.Click += new EventHandler(this.pictureFlagGreen_Click);
      this.checkFlag4.AutoSize = true;
      this.checkFlag4.Checked = true;
      this.checkFlag4.CheckState = CheckState.Checked;
      this.checkFlag4.Location = new Point(223, 335);
      this.checkFlag4.Name = "checkFlag4";
      this.checkFlag4.Size = new Size(15, 14);
      this.checkFlag4.TabIndex = 7;
      this.toolTip.SetToolTip((Control) this.checkFlag4, "Check to add logo to the flag");
      this.checkFlag4.UseVisualStyleBackColor = true;
      this.checkFlag3.AutoSize = true;
      this.checkFlag3.Checked = true;
      this.checkFlag3.CheckState = CheckState.Checked;
      this.checkFlag3.Location = new Point(159, 335);
      this.checkFlag3.Name = "checkFlag3";
      this.checkFlag3.Size = new Size(15, 14);
      this.checkFlag3.TabIndex = 6;
      this.toolTip.SetToolTip((Control) this.checkFlag3, "Check to add logo to the flag");
      this.checkFlag3.UseVisualStyleBackColor = true;
      this.checkFlag2.AutoSize = true;
      this.checkFlag2.Checked = true;
      this.checkFlag2.CheckState = CheckState.Checked;
      this.checkFlag2.Location = new Point(95, 335);
      this.checkFlag2.Name = "checkFlag2";
      this.checkFlag2.Size = new Size(15, 14);
      this.checkFlag2.TabIndex = 5;
      this.toolTip.SetToolTip((Control) this.checkFlag2, "Check to add logo to the flag");
      this.checkFlag2.UseVisualStyleBackColor = true;
      this.checkFlag1.AutoSize = true;
      this.checkFlag1.Checked = true;
      this.checkFlag1.CheckState = CheckState.Checked;
      this.checkFlag1.Location = new Point(29, 335);
      this.checkFlag1.Name = "checkFlag1";
      this.checkFlag1.Size = new Size(15, 14);
      this.checkFlag1.TabIndex = 4;
      this.toolTip.SetToolTip((Control) this.checkFlag1, "Check to add logo to the flag");
      this.checkFlag1.UseVisualStyleBackColor = true;
      this.labelFlag4.BorderStyle = BorderStyle.FixedSingle;
      this.labelFlag4.ImageIndex = 10;
      this.labelFlag4.ImageList = this.imageListFlags;
      this.labelFlag4.Location = new Point(207, 358);
      this.labelFlag4.Name = "labelFlag4";
      this.labelFlag4.Size = new Size(50, 30);
      this.labelFlag4.TabIndex = 3;
      this.toolTip.SetToolTip((Control) this.labelFlag4, "Click to change flag style");
      this.labelFlag4.Click += new EventHandler(this.labelFlag1_Click);
      this.imageListFlags.ImageStream = (ImageListStreamer) resources.GetObject("imageListFlags.ImageStream");
      this.imageListFlags.TransparentColor = Color.Transparent;
      this.imageListFlags.Images.SetKeyName(0, "gf1.png");
      this.imageListFlags.Images.SetKeyName(1, "gf2.png");
      this.imageListFlags.Images.SetKeyName(2, "gf3.png");
      this.imageListFlags.Images.SetKeyName(3, "gf4.png");
      this.imageListFlags.Images.SetKeyName(4, "gf5.png");
      this.imageListFlags.Images.SetKeyName(5, "gf6.png");
      this.imageListFlags.Images.SetKeyName(6, "gf7.png");
      this.imageListFlags.Images.SetKeyName(7, "gf8.png");
      this.imageListFlags.Images.SetKeyName(8, "gf9.png");
      this.imageListFlags.Images.SetKeyName(9, "gf10.png");
      this.imageListFlags.Images.SetKeyName(10, "gf11.png");
      this.imageListFlags.Images.SetKeyName(11, "gf13.png");
      this.imageListFlags.Images.SetKeyName(12, "gf15.png");
      this.labelFlag3.BorderStyle = BorderStyle.FixedSingle;
      this.labelFlag3.ImageIndex = 2;
      this.labelFlag3.ImageList = this.imageListFlags;
      this.labelFlag3.Location = new Point(142, 358);
      this.labelFlag3.Name = "labelFlag3";
      this.labelFlag3.Size = new Size(50, 30);
      this.labelFlag3.TabIndex = 2;
      this.toolTip.SetToolTip((Control) this.labelFlag3, "Click to change flag style");
      this.labelFlag3.Click += new EventHandler(this.labelFlag1_Click);
      this.labelFlag2.BorderStyle = BorderStyle.FixedSingle;
      this.labelFlag2.ImageIndex = 1;
      this.labelFlag2.ImageList = this.imageListFlags;
      this.labelFlag2.Location = new Point(77, 358);
      this.labelFlag2.Name = "labelFlag2";
      this.labelFlag2.Size = new Size(50, 30);
      this.labelFlag2.TabIndex = 1;
      this.toolTip.SetToolTip((Control) this.labelFlag2, "Click to change flag style");
      this.labelFlag2.Click += new EventHandler(this.labelFlag1_Click);
      this.labelFlag1.BorderStyle = BorderStyle.FixedSingle;
      this.labelFlag1.ImageIndex = 0;
      this.labelFlag1.ImageList = this.imageListFlags;
      this.labelFlag1.Location = new Point(12, 358);
      this.labelFlag1.Name = "labelFlag1";
      this.labelFlag1.Size = new Size(50, 30);
      this.labelFlag1.TabIndex = 0;
      this.toolTip.SetToolTip((Control) this.labelFlag1, "Click to change flag style");
      this.labelFlag1.Click += new EventHandler(this.labelFlag1_Click);
      this.viewer2DBanners.AutoTransparency = false;
      this.viewer2DBanners.BackColor = Color.Transparent;
      this.viewer2DBanners.ButtonStripVisible = false;
      this.viewer2DBanners.CurrentBitmap = (Bitmap) null;
      this.viewer2DBanners.ExtendedFormat = false;
      this.viewer2DBanners.FullSizeButton = false;
      this.viewer2DBanners.ImageLayout = ImageLayout.Zoom;
      this.viewer2DBanners.ImageSize = new Size(1024, 512);
      this.viewer2DBanners.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DBanners.Location = new Point(8, 3);
      this.viewer2DBanners.Name = "viewer2DBanners";
      this.viewer2DBanners.RemoveButton = false;
      this.viewer2DBanners.ShowButton = false;
      this.viewer2DBanners.ShowButtonChecked = true;
      this.viewer2DBanners.Size = new Size(512, 281);
      this.viewer2DBanners.TabIndex = 0;
      this.colorDialog.FullOpen = true;
      this.colorDialog.SolidColorOnly = true;
      this.imageListPlayers.ImageStream = (ImageListStreamer) resources.GetObject("imageListPlayers.ImageStream");
      this.imageListPlayers.TransparentColor = Color.Fuchsia;
      this.imageListPlayers.Images.SetKeyName(0, "P1.png");
      this.imageListPlayers.Images.SetKeyName(1, "P2.png");
      this.imageListPlayers.Images.SetKeyName(2, "P3.png");
      this.imageListPlayers.Images.SetKeyName(3, "p4.png");
      this.imageListPlayers.Images.SetKeyName(4, "p5.png");
      this.imageListPlayers.Images.SetKeyName(5, "p6.png");
      this.imageListPlayers.Images.SetKeyName(6, "p7.png");
      this.imageListPlayers.Images.SetKeyName(7, "p8.png");
      this.imageListPlayers.Images.SetKeyName(8, "P9.png");
      this.imageListPlayers.Images.SetKeyName(9, "P10.png");
      this.imageListPlayers.Images.SetKeyName(10, "p11.png");
      this.imageListPlayers.Images.SetKeyName(11, "Pnull.png");
      this.imageListArrows.ImageStream = (ImageListStreamer) resources.GetObject("imageListArrows.ImageStream");
      this.imageListArrows.TransparentColor = Color.Fuchsia;
      this.imageListArrows.Images.SetKeyName(0, "Move0Yellow.PNG");
      this.imageListArrows.Images.SetKeyName(1, "Move1Yellow.PNG");
      this.imageListArrows.Images.SetKeyName(2, "Move2tYellow.PNG");
      this.imageListArrows.Images.SetKeyName(3, "Move3Yellow.PNG");
      this.imageListArrows.Images.SetKeyName(4, "Move4Yellow.PNG");
      this.imageListArrows.Images.SetKeyName(5, "Move5Yellow.PNG");
      this.imageListArrows.Images.SetKeyName(6, "Move6Yellow.PNG");
      this.imageListArrows.Images.SetKeyName(7, "Move7Yellow.PNG");
      this.imageListArrows.Images.SetKeyName(8, "Move8tYellow.PNG");
      this.imageListArrows.Images.SetKeyName(9, "Move0Red.PNG");
      this.imageListArrows.Images.SetKeyName(10, "Move1Red.PNG");
      this.imageListArrows.Images.SetKeyName(11, "Move2Red.PNG");
      this.imageListArrows.Images.SetKeyName(12, "Move3Red.PNG");
      this.imageListArrows.Images.SetKeyName(13, "Move4Red.PNG");
      this.imageListArrows.Images.SetKeyName(14, "Move5Red.PNG");
      this.imageListArrows.Images.SetKeyName(15, "Move6Red.PNG");
      this.imageListArrows.Images.SetKeyName(16, "Move7Red.PNG");
      this.imageListArrows.Images.SetKeyName(17, "Move8Red.PNG");
      this.imageListArrows.Images.SetKeyName(18, "Move0Blue.PNG");
      this.imageListArrows.Images.SetKeyName(19, "Move1Blue.PNG");
      this.imageListArrows.Images.SetKeyName(20, "Move2Blue.PNG");
      this.imageListArrows.Images.SetKeyName(21, "Move3Blue.PNG");
      this.imageListArrows.Images.SetKeyName(22, "Move4Blue.PNG");
      this.imageListArrows.Images.SetKeyName(23, "Move5Blue.PNG");
      this.imageListArrows.Images.SetKeyName(24, "Move6Blue.PNG");
      this.imageListArrows.Images.SetKeyName(25, "Move7Blue.PNG");
      this.imageListArrows.Images.SetKeyName(26, "Move8Blue.PNG");
      this.imageListArrows.Images.SetKeyName(27, "Move0White.PNG");
      this.imageListArrows.Images.SetKeyName(28, "Move1White.PNG");
      this.imageListArrows.Images.SetKeyName(29, "Move2White.PNG");
      this.imageListArrows.Images.SetKeyName(30, "Move3White.PNG");
      this.imageListArrows.Images.SetKeyName(31, "Move4White.PNG");
      this.imageListArrows.Images.SetKeyName(32, "Move5White.PNG");
      this.imageListArrows.Images.SetKeyName(33, "Move6White.PNG");
      this.imageListArrows.Images.SetKeyName(34, "Move7White.PNG");
      this.imageListArrows.Images.SetKeyName(35, "Move8White.PNG");
      this.pickUpControl.BackColor = SystemColors.Control;
      this.pickUpControl.CloneButtonEnabled = false;
      this.pickUpControl.CreateButtonEnabled = true;
      this.pickUpControl.CurrentIndex = 0;
      this.pickUpControl.Dock = DockStyle.Top;
      this.pickUpControl.FilterByList = new string[3]
      {
        "All",
        "by League",
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
      this.pickUpControl.Size = new Size(1357, 25);
      this.pickUpControl.TabIndex = 4;
      this.pickUpControl.WizardButtonEnabled = false;
      this.pickUpControl.YoungPlayersEnabled = false;
      this.teamListBindingSource.DataSource = (object) typeof (TeamList);
      this.formationListBindingSource.DataSource = (object) typeof (FormationList);
      this.ballListBindingSource.DataSource = (object) typeof (BallList);
      this.prevLeagueListBindingSource.DataSource = (object) typeof (LeagueList);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1357, 832);
      this.Controls.Add((Control) this.tableEditTeam);
      this.Controls.Add((Control) this.pickUpControl);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = "TeamForm";
      this.Text = "TeamForm";
      this.Load += new EventHandler(this.TeamForm_Load);
      this.tableEditTeam.ResumeLayout(false);
      this.pageTeamGeneric.ResumeLayout(false);
      this.flowPanelTeamGeneric.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBoxName.ResumeLayout(false);
      this.groupBoxName.PerformLayout();
      ((ISupportInitialize) this.teamBindingSource).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((ISupportInitialize) this.stadiumListBindingSource).EndInit();
      this.groupManager.ResumeLayout(false);
      this.groupManager.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      ((ISupportInitialize) this.leagueListBindingSource).EndInit();
      ((ISupportInitialize) this.pictureTeamTerColor).EndInit();
      ((ISupportInitialize) this.pictureTeamPrimColor).EndInit();
      ((ISupportInitialize) this.pictureTeamSecColor).EndInit();
      this.numericTeamId.EndInit();
      this.numericBall.EndInit();
      ((ISupportInitialize) this.pictureBall).EndInit();
      ((ISupportInitialize) this.countryListBindingSource).EndInit();
      this.numericInitialBudget.EndInit();
      this.groupLastYear.ResumeLayout(false);
      this.groupLastYear.PerformLayout();
      this.numericPositionLastYear.EndInit();
      this.groupLocation.ResumeLayout(false);
      this.groupLocation.PerformLayout();
      this.numericUtcOffset.EndInit();
      this.numericLongitude.EndInit();
      this.numericLatitude.EndInit();
      this.groupTeamTraits.ResumeLayout(false);
      this.groupTeamTraits.PerformLayout();
      this.pageTeamRoster.ResumeLayout(false);
      this.groupBox6.ResumeLayout(false);
      this.groupBox6.PerformLayout();
      this.numericCcpassing.EndInit();
      this.numericCccrossing.EndInit();
      this.numericCcshooting.EndInit();
      this.groupBox5.ResumeLayout(false);
      this.groupBox5.PerformLayout();
      this.numericBusbuildupspeed.EndInit();
      this.numericBuspassing.EndInit();
      this.numericUpDown2.EndInit();
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.numericDefmentality.EndInit();
      this.numericDefaggression.EndInit();
      this.numericDefteamwidth.EndInit();
      this.groupFormation.ResumeLayout(false);
      this.groupFormation.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.groupAvailablePlayers.ResumeLayout(false);
      this.panelAvailablePlayersTop.ResumeLayout(false);
      ((ISupportInitialize) this.pictureAvailablePlayer).EndInit();
      this.groupTeamPlayers.ResumeLayout(false);
      this.panelTeamPlayersTop.ResumeLayout(false);
      this.panelTeamPlayersTop.PerformLayout();
      this.groupTeamPlayerTuning.ResumeLayout(false);
      this.groupContract.ResumeLayout(false);
      this.groupContract.PerformLayout();
      this.numericRosterYear.EndInit();
      this.pageTeamAdboard.ResumeLayout(false);
      this.pageTeamAdboard.PerformLayout();
      this.numericAdboards.EndInit();
      this.pageTeamFlags.ResumeLayout(false);
      this.groupFlag.ResumeLayout(false);
      this.groupFlag.PerformLayout();
      ((ISupportInitialize) this.pictureBox4).EndInit();
      ((ISupportInitialize) this.pictureFlagBlue).EndInit();
      ((ISupportInitialize) this.pictureFlagRed).EndInit();
      ((ISupportInitialize) this.pictureFlagGreen).EndInit();
      ((ISupportInitialize) this.teamListBindingSource).EndInit();
      ((ISupportInitialize) this.formationListBindingSource).EndInit();
      ((ISupportInitialize) this.ballListBindingSource).EndInit();
      ((ISupportInitialize) this.prevLeagueListBindingSource).EndInit();
      this.ResumeLayout(false);
    }

    public TeamForm()
    {
      this.Visible = false;
      this.InitializeComponent();
      this.pickUpControl.SelectObject = new PickUpControl.PickUpCallback(this.SelectTeam);
      this.pickUpControl.CreateObject = new PickUpControl.PickUpCallback(this.CreateTeam);
      this.pickUpControl.DeleteObject = new PickUpControl.PickUpCallback(this.DeleteTeam);
      this.pickUpControl.RefreshObject = new PickUpControl.PickUpCallback(this.RefreshTeam);
      this.viewer2DCrestLarge.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageCrest);
      this.viewer2DCrestLarge.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteCrest);
      this.viewer2DCrestLarge.ButtonStripVisible = true;
      this.viewer2DCrestLarge.RemoveButton = true;
      this.viewer2DCrest50.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageCrest50);
      this.viewer2DCrest50.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteCrest50);
      this.viewer2DCrest50.ButtonStripVisible = true;
      this.viewer2DCrest50.RemoveButton = true;
      this.viewer2DCrest32.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageCrest32);
      this.viewer2DCrest32.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteCrest32);
      this.viewer2DCrest32.ButtonStripVisible = true;
      this.viewer2DCrest32.RemoveButton = true;
      this.viewer2DCrest16.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageCrest16);
      this.viewer2DCrest16.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteCrest16);
      this.viewer2DCrest16.ButtonStripVisible = true;
      this.viewer2DCrest16.RemoveButton = true;
      this.viewer2DAdboards_0.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageAdboard_0);
      this.viewer2DAdboards_0.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteAdboard_0);
      this.viewer2DAdboards_0.ButtonStripVisible = true;
      this.viewer2DAdboards_0.FullSizeButton = true;
      this.viewer2DAdboards_0.RemoveButton = true;
      this.viewer2DAdboards_0.ShowButton = true;
      this.viewer2DAdboards_0.ShowButtonChecked = true;
      this.viewer2DBanners.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageBanners);
      this.viewer2DBanners.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteImageBanners);
      this.viewer2DBanners.ButtonStripVisible = true;
      this.viewer2DBanners.RemoveButton = true;
      this.multiViewer2DFlags15.Rx3ImportDelegate = new MultiViewer2D.Rx3ImportHandler(this.ImportRx3Flags);
      this.multiViewer2DFlags15.Rx3ExportDelegate = new MultiViewer2D.Rx3ExportHandler(this.ExportRx3Flags);
      this.multiViewer2DFlags15.Rx3SaveDelegate = new MultiViewer2D.Rx3SaveHandler(this.SaveRx3Flags);
      this.multiViewer2DFlags15.Rx3DeleteDelegate = new MultiViewer2D.Rx3DeleteHandler(this.DeleteRx3Flags);
      this.viewer2DPhoto.ButtonStripVisible = true;
      this.viewer2DPhoto.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageMiniface);
      this.viewer2DPhoto.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteMiniface);
      this.viewer2DPhoto.ButtonStripVisible = true;
      this.viewer2DPhoto.RemoveButton = true;
      this.viewer2DPhoto.ShowButton = true;
      this.viewer2DPhoto.ShowButtonChecked = true;
      this.pickUpAvailablePlayers.FilterChanged = new PickUpControl.PickUpCallback(this.AvailablePlayersFilterChanged);
    }

    private void tableEditTeam_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.tableEditTeam.SelectedIndex < 0)
        return;
      this.UpdateCurrentPage();
    }

    public void UpdateCurrentPage()
    {
      this.m_CurrentPage = this.tableEditTeam.SelectedTab;
      if (this.m_CurrentPage == this.pageTeamAdboard)
        this.LoadAdboardPage();
      else if (this.m_CurrentPage == this.pageTeamFlags)
        this.LoadFlagsPage();
      else if (this.m_CurrentPage == this.pageTeamGeneric)
      {
        this.LoadGenericPage();
      }
      else
      {
        if (this.m_CurrentPage != this.pageTeamRoster)
          return;
        this.LoadRosterPage();
      }
    }

    private bool ImportImageCrest(object sender, Bitmap bitmap)
    {
      this.m_CurrentTeam.SetCrestDark(bitmap);
      return this.m_CurrentTeam.SetCrest(bitmap);
    }

    private bool DeleteCrest(object sender)
    {
      return this.m_CurrentTeam.DeleteCrest();
    }

    private bool ImportImageCrest50(object sender, Bitmap bitmap)
    {
      this.m_CurrentTeam.SetCrest50Dark(bitmap);
      return this.m_CurrentTeam.SetCrest50(bitmap);
    }

    private bool DeleteCrest50(object sender)
    {
      this.m_CurrentTeam.DeleteCrest50Dark();
      return this.m_CurrentTeam.DeleteCrest50();
    }

    private bool ImportImageCrest32(object sender, Bitmap bitmap)
    {
      this.m_CurrentTeam.SetCrest32Dark(bitmap);
      return this.m_CurrentTeam.SetCrest32(bitmap);
    }

    private bool DeleteCrest32(object sender)
    {
      this.m_CurrentTeam.DeleteCrest32Dark();
      return this.m_CurrentTeam.DeleteCrest32();
    }

    private bool ImportImageCrest16(object sender, Bitmap bitmap)
    {
      this.m_CurrentTeam.SetCrest16Dark(bitmap);
      return this.m_CurrentTeam.SetCrest16(bitmap);
    }

    private bool DeleteCrest16(object sender)
    {
      this.m_CurrentTeam.DeleteCrest16Dark();
      return this.m_CurrentTeam.DeleteCrest16();
    }

    public void Clean()
    {
      this.Visible = false;
    }

    private bool ImportImageAdboard_0(object sender, Bitmap bitmap)
    {
      return this.m_CurrentTeam.SetAdboard(bitmap);
    }

    private bool DeleteAdboard_0(object sender)
    {
      return Adboard.DeleteAdboard(this.m_CurrentTeam.adboardid);
    }

    private bool ImportImageBanners(object sender, Bitmap bitmap)
    {
      return this.m_CurrentTeam.SetBanner(bitmap);
    }

    private bool DeleteImageBanners(object sender)
    {
      return this.m_CurrentTeam.DeleteBanner();
    }

    private bool ImportRx3Flags(object sender, string rx3FileName)
    {
      return this.m_CurrentTeam.SetFlags(rx3FileName);
    }

    private bool ExportRx3Flags(object sender, string exportDir)
    {
      return this.m_CurrentTeam.ExportFlags(exportDir);
    }

    private bool SaveRx3Flags(object sender, Bitmap[] bitmaps)
    {
      return this.m_CurrentTeam.SetFlags(bitmaps);
    }

    private bool DeleteRx3Flags(object sender)
    {
      return this.m_CurrentTeam.DeleteFlag();
    }

    private bool ImportImageMiniface(object sender, Bitmap bitmap)
    {
      return this.m_CurrentTeamPlayer.Player.SetPhoto(bitmap);
    }

    private bool DeleteMiniface(object sender)
    {
      return this.m_CurrentTeamPlayer.Player.DeletePhoto();
    }

    private Team SelectTeam(object sender, object obj)
    {
      Team team = (Team) obj;
      this.Refresh();
      this.LoadTeam(team);
      return team;
    }

    private Team CreateTeam(object sender, object obj)
    {
      DialogResult dialogResult = this.m_NewIdCreator.ShowDialog();
      if (this.m_NewIdCreator.NewObject == null)
      {
        if (dialogResult == DialogResult.OK)
        {
          int num = (int) FifaEnvironment.UserMessages.ShowMessage(5060, this.m_NewIdCreator.NewId);
        }
        return (Team) null;
      }
      Team newObject = (Team) this.m_NewIdCreator.NewObject;
      if (this.m_NewIdCreator.NewName != null && newObject != null)
      {
        newObject.TeamNameFull = this.m_NewIdCreator.NewName;
        newObject.DatabaseName = this.m_NewIdCreator.NewName;
        newObject.TeamNameAbbr15 = newObject.TeamNameFull.Length <= 15 ? newObject.TeamNameFull : newObject.TeamNameFull.Substring(0, 15);
        newObject.TeamNameAbbr10 = newObject.TeamNameFull.Length <= 10 ? newObject.TeamNameFull : newObject.TeamNameFull.Substring(0, 10);
        newObject.TeamNameAbbr3 = newObject.TeamNameFull.Length <= 3 ? newObject.TeamNameFull : newObject.TeamNameFull.Substring(0, 3).ToUpper();
      }
      Formation formation = (Formation) null;
      foreach (Formation genericFormation in (ArrayList) FifaEnvironment.GenericFormations)
      {
        if (genericFormation.Name.StartsWith("4-4-2"))
        {
          formation = genericFormation;
          break;
        }
      }
      if (formation == null)
        formation = (Formation) FifaEnvironment.GenericFormations[0];
      if (formation != null)
      {
        newObject.Formation = formation;
        newObject.formationid = formation.Id;
      }
      if (this.m_CurrentTeam != null)
      {
        newObject.Country = this.m_CurrentTeam.Country;
        newObject.adboardid = this.m_CurrentTeam.adboardid;
        newObject.balltype = this.m_CurrentTeam.balltype;
        newObject.Stadium = this.m_CurrentTeam.Stadium;
        newObject.RivalTeam = this.m_CurrentTeam.RivalTeam;
      }
      switch (FifaEnvironment.UserMessages.ShowMessage(15))
      {
        case DialogResult.Cancel:
        case DialogResult.No:
          return newObject;
        default:
          TeamPlayer[] teamPlayerArray = new TeamPlayer[32];
          for (int index = 0; index < 32; ++index)
          {
            Player newId = (Player) FifaEnvironment.Players.CreateNewId();
            if (newId != null)
            {
              if (this.m_CurrentTeam.Country != null)
                newId.Country = this.m_CurrentTeam.Country;
              teamPlayerArray[index] = new TeamPlayer(newId);
              newId.preferredposition1 = index >= 11 ? newObject.Formation.PlayingRoles[index * 3 % 11].Id : newObject.Formation.PlayingRoles[index].Id;
              newObject.AddTeamPlayer(teamPlayerArray[index]);
            }
            else
              break;
          }
          newObject.AssignRoles();
          newObject.AssignBench();
          newObject.AssignCaptain();
          newObject.AssignFreeKick();
          newObject.AssignPenalty();
          newObject.AssignLeftCorner();
          newObject.AssignRightCorner();
          goto case DialogResult.Cancel;
      }
    }

    private Team DeleteTeam(object sender, object obj)
    {
      Team team = (Team) obj;
      switch (FifaEnvironment.UserMessages.ShowMessage(30))
      {
        case DialogResult.Cancel:
        case DialogResult.No:
          foreach (IdObject kit in (ArrayList) team.m_KitList)
            FifaEnvironment.Kits.RemoveId(kit);
          if (team.League != null)
            team.League.RemoveTeam(team);
          FifaEnvironment.Teams.DeleteTeam(team);
          this.m_CurrentTeam = (Team) null;
          return (Team) null;
        default:
          IEnumerator enumerator = team.Roster.GetEnumerator();
          try
          {
            while (enumerator.MoveNext())
            {
              TeamPlayer current = (TeamPlayer) enumerator.Current;
              if (current.Player.m_PlayingForTeams.Count <= 1)
                FifaEnvironment.Players.RemoveId(current.Player.Id);
              else
                current.Player.NotPlayFor(team);
            }
            goto case DialogResult.Cancel;
          }
          finally
          {
            if (enumerator is IDisposable disposable)
              disposable.Dispose();
          }
      }
    }

    public Team RefreshTeam(object sender, object obj)
    {
      this.Preset();
      this.ReloadTeam(this.m_CurrentTeam);
      return this.m_CurrentTeam;
    }

    public void ReloadTeam(Team team)
    {
      this.m_CurrentTeam = (Team) null;
      this.LoadTeam(team);
    }

    public void LoadTeam(Team team)
    {
      if (!this.m_IsLoaded || this.m_CurrentTeam == team && this.m_CurrentPage == this.tableEditTeam.SelectedTab)
        return;
      this.m_CurrentTeam = team;
      this.teamBindingSource.DataSource = (object) this.m_CurrentTeam;
      this.UpdateCurrentPage();
      GC.Collect();
    }

    public void LoadGenericPage()
    {
      this.numericTeamId.Value = (Decimal) this.m_CurrentTeam.Id;
      this.comboRivalTeam.SelectedItem = (object) this.m_CurrentTeam.RivalTeam;
      this.comboObjective.SelectedIndex = this.m_CurrentTeam.objective;
      this.comboMaxOnjective.SelectedIndex = this.m_CurrentTeam.highestpossible;
      this.comboProbObjective.SelectedIndex = this.m_CurrentTeam.highestprobable;
      this.teamBindingSource.ResetBindings(false);
      this.viewer2DCrestLarge.CurrentBitmap = this.m_CurrentTeam.GetCrest();
      this.viewer2DCrest50.CurrentBitmap = this.m_CurrentTeam.GetCrest50();
      this.viewer2DCrest32.CurrentBitmap = this.m_CurrentTeam.GetCrest32();
      this.viewer2DCrest16.CurrentBitmap = this.m_CurrentTeam.GetCrest16();
    }

    public void LoadAdboardPage()
    {
      if (this.m_CurrentTeam == null)
      {
        this.viewer2DAdboards_0.CurrentBitmap = (Bitmap) null;
      }
      else
      {
        this.m_LockUserChanges = true;
        this.viewer2DAdboards_0.CurrentBitmap = this.m_CurrentTeam.GetAdboard();
        this.checkHasSpecificAdboard.Checked = this.m_CurrentTeam.HasSpecifiAdboard;
        this.numericAdboards.Enabled = !this.m_CurrentTeam.HasSpecifiAdboard;
        this.numericAdboards.Value = (Decimal) this.m_CurrentTeam.adboardid;
        this.m_LockUserChanges = false;
      }
    }

    public void LoadFlagsPage()
    {
      this.viewer2DBanners.CurrentBitmap = this.m_CurrentTeam.GetBanner();
      this.multiViewer2DFlags15.Bitmaps = this.m_CurrentTeam.GetFlags();
      this.pictureFlagRed.BackColor = this.m_CurrentTeam.TeamColor1;
      this.pictureFlagGreen.BackColor = this.m_CurrentTeam.TeamColor2;
      this.pictureFlagBlue.BackColor = this.m_CurrentTeam.TeamColor3;
    }

    public void LoadRosterPage()
    {
      this.InitListViewTeamPlayers(this.m_CurrentTeam.Roster);
      this.m_CurrentFormation = this.m_CurrentTeam.Formation;
      this.m_BackupSpecificFormation = (Formation) null;
      if (this.m_CurrentFormation == null)
        return;
      this.m_LockUserChanges = true;
      if (this.m_CurrentFormation.IsGeneric())
      {
        this.radioUseGenericFormation.Checked = true;
        this.comboGenericFormations.SelectedItem = (object) this.m_CurrentFormation;
      }
      else
        this.radioUseSpecificFormation.Checked = true;
      this.comboGenericFormations.Visible = this.radioUseGenericFormation.Checked;
      this.labelTeamFormationName.Text = this.m_CurrentFormation.ToString();
      this.InitVisualFormation(this.m_CurrentTeam.Roster);
      this.m_LockUserChanges = false;
    }

    public void Preset()
    {
      this.m_NewIdCreator.IdList = (IdArrayList) FifaEnvironment.Teams;
      this.pickUpControl.FilterValues = new IdArrayList[3]
      {
        (IdArrayList) null,
        (IdArrayList) FifaEnvironment.Leagues,
        (IdArrayList) FifaEnvironment.Countries
      };
      this.numericBall.Maximum = (Decimal) FifaEnvironment.FifaDb.Table[TI.teams].TableDescriptor.MaxValues[FI.teams_balltype];
      this.numericAdboards.Maximum = (Decimal) FifaEnvironment.FifaDb.Table[TI.teams].TableDescriptor.MaxValues[FI.teams_adboardid];
      this.numericTeamId.Maximum = (Decimal) FifaEnvironment.FifaDb.Table[TI.teams].TableDescriptor.MaxValues[FI.teams_teamid];
      this.teamListBindingSource.DataSource = (object) FifaEnvironment.Teams;
      this.comboRivalTeam.DataSource = (object) this.teamListBindingSource;
      this.teamListBindingSource.ResetBindings(false);
      this.stadiumListBindingSource.DataSource = (object) FifaEnvironment.Stadiums;
      this.comboStadiums.DataSource = (object) this.stadiumListBindingSource;
      this.stadiumListBindingSource.ResetBindings(false);
      this.countryListBindingSource.DataSource = (object) FifaEnvironment.Countries;
      this.comboTeamCountry.DataSource = (object) this.countryListBindingSource;
      this.countryListBindingSource.ResetBindings(false);
      this.leagueListBindingSource.DataSource = (object) FifaEnvironment.Leagues;
      this.prevLeagueListBindingSource.DataSource = (object) FifaEnvironment.Leagues;
      this.comboTeamLeague.DataSource = (object) this.leagueListBindingSource;
      this.comboPrevLeague.DataSource = (object) this.prevLeagueListBindingSource;
      this.leagueListBindingSource.ResetBindings(false);
      this.prevLeagueListBindingSource.ResetBindings(false);
      this.pickUpAvailablePlayers.FilterValues = new IdArrayList[5]
      {
        (IdArrayList) null,
        (IdArrayList) FifaEnvironment.Teams,
        (IdArrayList) FifaEnvironment.Countries,
        (IdArrayList) FifaEnvironment.Roles,
        (IdArrayList) FifaEnvironment.FreeAgents
      };
      this.pickUpAvailablePlayers.comboFilterValue.Width = 300;
      this.comboGenericFormations.Items.Clear();
      foreach (Formation formation in (ArrayList) FifaEnvironment.Formations)
      {
        if (formation.IsGeneric() && formation.formations_issweeper == 0)
          this.comboGenericFormations.Items.Add((object) formation);
      }
      this.pickUpControl.ObjectList = (IdArrayList) FifaEnvironment.Teams;
      this.labelRightFreeKickText.Visible = FifaEnvironment.Year > 14;
      this.labelLeftFreeKickText.Visible = FifaEnvironment.Year > 14;
      this.labelLeftFreeKick.Visible = FifaEnvironment.Year > 14;
      this.labelRightFreeKick.Visible = FifaEnvironment.Year > 14;
      this.checkHasSpecificAdboard.Enabled = FifaEnvironment.Year > 14;
    }

    public void RefreshComboBoxes()
    {
      if (this.comboRivalTeam.Items.Count == FifaEnvironment.Teams.Count)
        return;
      this.comboRivalTeam.Items.Clear();
      this.comboRivalTeam.Items.AddRange(FifaEnvironment.Teams.ToArray());
    }

    private void TeamForm_Load(object sender, EventArgs e)
    {
      this.m_IsLoaded = true;
      this.Preset();
    }

    private void numericTeamId_ValueChanged(object sender, EventArgs e)
    {
      int num1 = (int) this.numericTeamId.Value;
      if (num1 == this.m_CurrentTeam.Id)
        return;
      if (FifaEnvironment.Teams.SearchId(num1) == null)
      {
        FifaEnvironment.Teams.ChangeId((IdObject) this.m_CurrentTeam, num1);
        this.m_CurrentTeam.assetid = num1;
        this.m_CurrentTeam.m_KitList = new KitList();
        this.m_CurrentTeam.LinkKits(FifaEnvironment.Kits);
        foreach (Kit kit in (ArrayList) this.m_CurrentTeam.m_KitList)
          kit.Team = this.m_CurrentTeam;
        if (this.m_CurrentFormation != null)
          this.m_CurrentFormation.Team = this.m_CurrentTeam;
        this.LoadGenericPage();
        this.LoadFlagsPage();
      }
      else
      {
        int num2 = (int) FifaEnvironment.UserMessages.ShowMessage(1015);
        this.numericTeamId.Value = (Decimal) this.m_CurrentTeam.Id;
      }
    }

    private void buttonGetId_Click(object sender, EventArgs e)
    {
      int newId = FifaEnvironment.Teams.GetNewId();
      if (newId == -1)
      {
        int num = (int) FifaEnvironment.UserMessages.ShowMessage(5050);
      }
      else
        this.numericTeamId.Value = (Decimal) newId;
    }

    private void pictureTeamPrimColor_Click(object sender, EventArgs e)
    {
      this.colorDialog.Color = this.pictureTeamPrimColor.BackColor;
      int num = (int) this.colorDialog.ShowDialog();
      this.pictureTeamPrimColor.BackColor = this.colorDialog.Color;
      this.m_CurrentTeam.TeamColor1 = this.colorDialog.Color;
    }

    private void pictureTeamSecColor_Click(object sender, EventArgs e)
    {
      this.colorDialog.Color = this.pictureTeamSecColor.BackColor;
      int num = (int) this.colorDialog.ShowDialog();
      this.pictureTeamSecColor.BackColor = this.colorDialog.Color;
      this.m_CurrentTeam.TeamColor2 = this.colorDialog.Color;
    }

    private void pictureTeamTerColor_Click(object sender, EventArgs e)
    {
      this.colorDialog.Color = this.pictureTeamTerColor.BackColor;
      int num = (int) this.colorDialog.ShowDialog();
      this.pictureTeamTerColor.BackColor = this.colorDialog.Color;
      this.m_CurrentTeam.TeamColor3 = this.colorDialog.Color;
    }

    private void numericAdboards_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockUserChanges)
        return;
      if (this.m_CurrentTeam == null)
      {
        this.viewer2DAdboards_0.CurrentBitmap = (Bitmap) null;
      }
      else
      {
        this.m_CurrentTeam.adboardid = (int) this.numericAdboards.Value;
        this.viewer2DAdboards_0.CurrentBitmap = this.m_CurrentTeam.GetAdboard();
      }
    }

    private void InitListViewTeamPlayers(Roster roster)
    {
      this.listViewTeamPlayers.BeginUpdate();
      this.listViewTeamPlayers.Items.Clear();
      for (int index = 0; index < roster.Count; ++index)
      {
        TeamPlayer teamPlayer = (TeamPlayer) roster[index];
        this.listViewTeamPlayers.Items.Add(new ListViewItem(FifaUtil.PadBlanks(teamPlayer.m_jerseynumber.ToString(), 2))
        {
          Tag = (object) teamPlayer,
          SubItems = {
            teamPlayer.Player.Name,
            teamPlayer.Player.firstname,
            teamPlayer.Player.contractvaliduntil.ToString(),
            teamPlayer.Player.GetRoleAcronym(),
            teamPlayer.Player.overallrating.ToString()
          }
        });
      }
      if (this.listViewTeamPlayers.Items.Count > 0)
      {
        this.listViewTeamPlayers.Items[0].Selected = true;
      }
      else
      {
        this.m_CurrentTeamPlayer = (TeamPlayer) null;
        this.CleanRosterTeamPlayer();
      }
      this.listViewTeamPlayers.EndUpdate();
    }

    private void InitListViewPlayersAvailable(Team team, Country country, bool showFreeAgents)
    {
      if (this.m_AvailablePlayerLocked)
        return;
      this.m_AvailablePlayerLocked = true;
      bool flag = true;
      IComparer listViewItemSorter = this.listViewPlayersAvailable.ListViewItemSorter;
      this.listViewPlayersAvailable.ListViewItemSorter = (IComparer) null;
      this.listViewPlayersAvailable.BeginUpdate();
      this.listViewPlayersAvailable.Items.Clear();
      for (int index = 0; index < FifaEnvironment.Players.Count; ++index)
      {
        Player player = (Player) FifaEnvironment.Players[index];
        if ((!flag || player.Id < 400000 || player.Id >= 500000) && ((!showFreeAgents || player.m_PlayingForTeams.Count <= 0) && (team == null || player.IsPlayingFor(team))) && (country == null || player.Country == country))
        {
          ListViewItem listViewItem = new ListViewItem(player.Name);
          listViewItem.Tag = (object) player;
          listViewItem.SubItems.Add(player.firstname);
          string roleAcronym = player.GetRoleAcronym();
          listViewItem.SubItems.Add(roleAcronym);
          int averageRoleAttribute = player.GetAverageRoleAttribute();
          listViewItem.SubItems.Add(averageRoleAttribute.ToString());
          this.listViewPlayersAvailable.Items.Add(listViewItem);
        }
      }
      if (this.listViewPlayersAvailable.Items.Count > 0)
        this.listViewPlayersAvailable.Items[0].Selected = true;
      this.listViewPlayersAvailable.EndUpdate();
      this.EnableRosterButtons();
      this.listViewPlayersAvailable.ListViewItemSorter = listViewItemSorter;
      this.m_AvailablePlayerLocked = false;
    }

    private void InitListViewPlayersAvailable(IdObject filterObject, bool excludeYoung)
    {
      if (this.m_AvailablePlayerLocked)
        return;
      this.m_AvailablePlayerLocked = true;
      IComparer listViewItemSorter = this.listViewPlayersAvailable.ListViewItemSorter;
      this.listViewPlayersAvailable.ListViewItemSorter = (IComparer) null;
      this.listViewPlayersAvailable.BeginUpdate();
      this.listViewPlayersAvailable.Items.Clear();
      PlayerList playerList = (PlayerList) FifaEnvironment.Players.Filter(filterObject);
      for (int index = 0; index < playerList.Count; ++index)
      {
        Player player = (Player) playerList[index];
        if (player.Id <= 400000 || !excludeYoung)
        {
          ListViewItem listViewItem = new ListViewItem(player.Name);
          listViewItem.Tag = (object) player;
          listViewItem.SubItems.Add(player.firstname);
          string roleAcronym = player.GetRoleAcronym();
          listViewItem.SubItems.Add(roleAcronym);
          int averageRoleAttribute = player.GetAverageRoleAttribute();
          listViewItem.SubItems.Add(averageRoleAttribute.ToString());
          this.listViewPlayersAvailable.Items.Add(listViewItem);
        }
      }
      if (this.listViewPlayersAvailable.Items.Count > 0)
        this.listViewPlayersAvailable.Items[0].Selected = true;
      this.listViewPlayersAvailable.EndUpdate();
      this.EnableRosterButtons();
      this.listViewPlayersAvailable.ListViewItemSorter = listViewItemSorter;
      this.m_AvailablePlayerLocked = false;
    }

    private void EnableRosterButtons()
    {
      if (this.m_CurrentTeamPlayer != null)
      {
        this.buttonRosterLetFree.Enabled = true;
        if (this.m_CurrentAvailableTeam != null && this.m_CurrentAvailableTeam != this.m_CurrentTeam && this.m_CurrentAvailableTeam.Id != 0)
          this.buttonTransferPlayer.Enabled = true;
        else
          this.buttonTransferPlayer.Enabled = false;
      }
      else
      {
        this.buttonTransferPlayer.Enabled = false;
        this.buttonRosterLetFree.Enabled = false;
      }
      if (this.m_CurrentAvailablePlayer == null)
      {
        this.buttonTransferFrom.Enabled = false;
        this.buttonCall.Enabled = false;
      }
      else if (this.m_CurrentAvailablePlayer.IsPlayingFor(this.m_CurrentTeam))
      {
        this.buttonTransferFrom.Enabled = false;
        this.buttonCall.Enabled = false;
      }
      else
      {
        this.buttonTransferFrom.Enabled = true;
        this.buttonCall.Enabled = true;
      }
    }

    private void CleanRosterTeamPlayer()
    {
      this.labelRosterName.Text = string.Empty;
      this.comboRosterNumber.Items.Clear();
      this.comboRosterNumber.Text = string.Empty;
      this.numericRosterYear.Value = new Decimal(2014);
      this.viewer2DPhoto.CurrentBitmap = (Bitmap) null;
      this.labelTeamPlayerStars.ImageIndex = 0;
    }

    private void buttonTransferFrom_Click(object sender, EventArgs e)
    {
      Team team = (Team) null;
      if (this.m_CurrentAvailableTeam != null)
      {
        team = this.m_CurrentAvailableTeam;
      }
      else
      {
        for (int index = 0; index < this.m_CurrentAvailablePlayer.m_PlayingForTeams.Count; ++index)
        {
          Team playingForTeam = (Team) this.m_CurrentAvailablePlayer.m_PlayingForTeams[index];
          if (!playingForTeam.IsNationalTeam())
          {
            team = playingForTeam;
            break;
          }
        }
      }
      team?.RemoveTeamPlayer(this.m_CurrentAvailablePlayer);
      this.m_CurrentTeam.AddTeamPlayer(this.m_CurrentAvailablePlayer);
      this.InitListViewTeamPlayers(this.m_CurrentTeam.Roster);
      this.InitVisualFormation(this.m_CurrentTeam.Roster);
      if (this.m_CurrentAvailableTeam != null)
        this.InitListViewPlayersAvailable((IdObject) this.m_CurrentAvailableTeam, false);
      this.EnableRosterButtons();
    }

    private void buttonCall_Click(object sender, EventArgs e)
    {
      this.m_CurrentTeam.AddTeamPlayer(this.m_CurrentAvailablePlayer);
      this.InitListViewTeamPlayers(this.m_CurrentTeam.Roster);
      this.InitVisualFormation(this.m_CurrentTeam.Roster);
      this.EnableRosterButtons();
    }

    private void buttonRosterLetFree_Click(object sender, EventArgs e)
    {
      this.m_CurrentTeam.RemoveTeamPlayer(this.m_CurrentTeamPlayer);
      this.InitListViewTeamPlayers(this.m_CurrentTeam.Roster);
      this.InitVisualFormation(this.m_CurrentTeam.Roster);
      this.EnableRosterButtons();
    }

    private void listViewTeamPlayers_DoubleClick(object sender, EventArgs e)
    {
      if (this.listViewTeamPlayers.SelectedItems.Count <= 0)
        return;
      TeamPlayer tag = (TeamPlayer) this.listViewTeamPlayers.SelectedItems[0].Tag;
      if (tag == null)
        return;
      Player player = tag.Player;
      if (player == null)
        return;
      MainForm.CM.JumpTo((IdObject) player);
    }

    private void listViewTeamPlayers_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.listViewTeamPlayers.SelectedItems.Count <= 0)
        return;
      TeamPlayer tag = (TeamPlayer) this.listViewTeamPlayers.SelectedItems[0].Tag;
      if (this.m_CurrentTeamPlayer == tag)
        return;
      this.m_ChangeNumberFlag = false;
      this.m_CurrentTeamPlayer = tag;
      if (this.m_CurrentTeamPlayer != null)
      {
        this.comboRosterNumber.Items.Clear();
        this.comboRosterNumber.Items.Add((object) this.m_CurrentTeamPlayer.m_jerseynumber.ToString());
        this.comboRosterNumber.Items.AddRange((object[]) this.m_CurrentTeam.Roster.GetFreeNumbers());
        this.comboRosterNumber.SelectedIndex = 0;
        this.labelRosterName.Text = this.m_CurrentTeamPlayer.Player.Name;
        this.numericRosterYear.Value = (Decimal) this.m_CurrentTeamPlayer.Player.contractvaliduntil;
        this.dateJoiningDate.Value = this.m_CurrentTeamPlayer.Player.joindate;
        this.viewer2DPhoto.CurrentBitmap = this.m_CurrentTeamPlayer.Player.GetPhoto();
        int num = (this.m_CurrentTeamPlayer.Player.GetAverageRoleAttribute() - 45) / 5;
        if (num < 0)
          num = 0;
        if (num > 9)
          num = 9;
        this.labelTeamPlayerStars.ImageIndex = num;
        this.EnableRosterButtons();
      }
      else
      {
        this.CleanRosterTeamPlayer();
        this.EnableRosterButtons();
      }
      this.m_ChangeNumberFlag = true;
    }

    private void buttonTransferPlayer_Click(object sender, EventArgs e)
    {
      this.m_CurrentTeam.RemoveTeamPlayer(this.m_CurrentTeamPlayer);
      this.m_CurrentAvailableTeam.AddTeamPlayer(this.m_CurrentTeamPlayer);
      this.InitListViewTeamPlayers(this.m_CurrentTeam.Roster);
      this.InitListViewPlayersAvailable(this.m_CurrentAvailableTeam, (Country) null, false);
      this.EnableRosterButtons();
      this.InitVisualFormation(this.m_CurrentTeam.Roster);
    }

    private Team AvailablePlayersFilterChanged(object sender, object obj)
    {
      if (this.m_AvailablePlayerLocked)
        return (Team) null;
      this.m_CurrentAvailableTeam = (Team) null;
      if (obj != null && obj.GetType().Name == "Team")
        this.m_CurrentAvailableTeam = (Team) obj;
      this.InitListViewPlayersAvailable((IdObject) obj, false);
      return (Team) null;
    }

    private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      ListView listView = (ListView) sender;
      SortOrder sortOrder = listView.Sorting != SortOrder.Ascending ? SortOrder.Ascending : SortOrder.Descending;
      listView.Sorting = sortOrder;
      listView.ListViewItemSorter = (IComparer) new ListViewItemComparer(e.Column, sortOrder);
    }

    private void listViewPlayersAvailable_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.listViewPlayersAvailable.SelectedItems.Count < 1)
        return;
      this.m_CurrentAvailablePlayer = (Player) this.listViewPlayersAvailable.SelectedItems[0].Tag;
      this.labelRosterNameFrom.Text = this.m_CurrentAvailablePlayer.Name;
      this.pictureAvailablePlayer.Image = (Image) this.m_CurrentAvailablePlayer.GetPhoto();
      int num = (this.m_CurrentAvailablePlayer.GetAverageRoleAttribute() - 45) / 5;
      if (num < 0)
        num = 0;
      if (num > 9)
        num = 9;
      this.labelAvailablePlayerStars.ImageIndex = num;
      this.EnableRosterButtons();
    }

    private void listViewPlayersAvailable_DoubleClick(object sender, EventArgs e)
    {
      if (this.listViewPlayersAvailable.SelectedItems.Count <= 0)
        return;
      Player tag = (Player) this.listViewPlayersAvailable.SelectedItems[0].Tag;
      if (tag == null)
        return;
      MainForm.CM.JumpTo((IdObject) tag);
    }

    private void numericBall_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_CurrentTeam == null)
        return;
      this.m_CurrentTeam.balltype = (int) this.numericBall.Value;
      this.pictureBall.BackgroundImage = (Image) Ball.GetBallPicture(this.m_CurrentTeam.balltype);
    }

    private void labelTeamCountry_DoubleClick(object sender, EventArgs e)
    {
      if (this.m_CurrentTeam.Country == null)
        return;
      MainForm.CM.JumpTo((IdObject) this.m_CurrentTeam.Country);
    }

    private void labelTeamLeague_DoubleClick(object sender, EventArgs e)
    {
      if (this.m_CurrentTeam.League == null)
        return;
      MainForm.CM.JumpTo((IdObject) this.m_CurrentTeam.League);
    }

    private void labelTeamStadium_DoubleClick(object sender, EventArgs e)
    {
      if (this.m_CurrentTeam.Stadium == null)
        return;
      MainForm.CM.JumpTo((IdObject) this.m_CurrentTeam.Stadium);
    }

    private void labelOpponent_DoubleClick(object sender, EventArgs e)
    {
      if (this.m_CurrentTeam.RivalTeam == null)
        return;
      MainForm.CM.JumpTo((IdObject) this.m_CurrentTeam.RivalTeam);
    }

    private void labelBall_DoubleClick(object sender, EventArgs e)
    {
      Ball ball = (Ball) FifaEnvironment.Balls.SearchId(this.m_CurrentTeam.balltype);
      if (ball == null)
        return;
      MainForm.CM.JumpTo((IdObject) ball);
    }

    private void comboRosterNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.m_ChangeNumberFlag)
        return;
      this.m_ChangeNumberFlag = false;
      string selectedItem = (string) this.comboRosterNumber.SelectedItem;
      this.m_CurrentTeamPlayer.m_jerseynumber = Convert.ToInt32(selectedItem);
      this.listViewTeamPlayers.SelectedItems[0].SubItems[0] = new ListViewItem.ListViewSubItem(this.listViewTeamPlayers.SelectedItems[0], selectedItem);
      this.m_ChangeNumberFlag = true;
    }

    private void numericRosterYear_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_CurrentTeamPlayer == null)
        return;
      this.m_CurrentTeamPlayer.Player.contractvaliduntil = (int) this.numericRosterYear.Value;
      this.listViewTeamPlayers.SelectedItems[0].SubItems[3] = new ListViewItem.ListViewSubItem(this.listViewTeamPlayers.SelectedItems[0], this.m_CurrentTeamPlayer.Player.contractvaliduntil.ToString());
    }

    private void comboTeamCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void dateJoiningDate_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_CurrentTeamPlayer == null)
        return;
      this.m_CurrentTeamPlayer.Player.joindate = this.dateJoiningDate.Value;
    }

    private void InitVisualFormation(Roster roster)
    {
      Formation currentFormation = this.m_CurrentFormation;
      if (currentFormation != null)
      {
        this.labelPos0.Visible = currentFormation.IsRoleUsed(ERole.Goalkeeper);
        this.labelPos1.Visible = currentFormation.IsRoleUsed(ERole.Sweeper);
        this.labelPos2.Visible = currentFormation.IsRoleUsed(ERole.Right_Wing_Back);
        this.labelPos3.Visible = currentFormation.IsRoleUsed(ERole.Right_Back);
        this.labelPos4.Visible = currentFormation.IsRoleUsed(ERole.Right_Central_Back);
        this.labelPos5.Visible = currentFormation.IsRoleUsed(ERole.Central_Back);
        this.labelPos6.Visible = currentFormation.IsRoleUsed(ERole.Left_Central_Back);
        this.labelPos7.Visible = currentFormation.IsRoleUsed(ERole.Left_Back);
        this.labelPos8.Visible = currentFormation.IsRoleUsed(ERole.Left_Wing_Back);
        this.labelPos9.Visible = currentFormation.IsRoleUsed(ERole.Right_Defensive_Midfielder);
        this.labelPos10.Visible = currentFormation.IsRoleUsed(ERole.Central_Defensive_Midfielder);
        this.labelPos11.Visible = currentFormation.IsRoleUsed(ERole.Left_Defensive_Midfielder);
        this.labelPos12.Visible = currentFormation.IsRoleUsed(ERole.Right_Midfielder);
        this.labelPos13.Visible = currentFormation.IsRoleUsed(ERole.Right_Central_Midfielder);
        this.labelPos14.Visible = currentFormation.IsRoleUsed(ERole.Central_Midfielder);
        this.labelPos15.Visible = currentFormation.IsRoleUsed(ERole.Left_Central_Midfielder);
        this.labelPos16.Visible = currentFormation.IsRoleUsed(ERole.Left_Midfielder);
        this.labelPos17.Visible = currentFormation.IsRoleUsed(ERole.Right_Advanced_Midfielder);
        this.labelPos18.Visible = currentFormation.IsRoleUsed(ERole.Central_Advanced_Midfielder);
        this.labelPos19.Visible = currentFormation.IsRoleUsed(ERole.Left_Advanced_Midfielder);
        this.labelPos20.Visible = currentFormation.IsRoleUsed(ERole.Right_Forward);
        this.labelPos21.Visible = currentFormation.IsRoleUsed(ERole.Central_Forward);
        this.labelPos22.Visible = currentFormation.IsRoleUsed(ERole.Left_Forward);
        this.labelPos23.Visible = currentFormation.IsRoleUsed(ERole.Right_Wing);
        this.labelPos24.Visible = currentFormation.IsRoleUsed(ERole.Right_Striker);
        this.labelPos25.Visible = currentFormation.IsRoleUsed(ERole.Central_Striker);
        this.labelPos26.Visible = currentFormation.IsRoleUsed(ERole.Left_Striker);
        this.labelPos27.Visible = currentFormation.IsRoleUsed(ERole.Left_Wing);
        this.labelPos32A.Visible = true;
        this.labelPos32B.Visible = true;
        this.labelPos32C.Visible = true;
        this.labelPos32D.Visible = true;
        this.labelPos32E.Visible = true;
        this.labelPos32F.Visible = true;
        this.labelPos32G.Visible = true;
        this.labelPos33A.Visible = true;
        this.labelPos33B.Visible = true;
        this.labelPos33C.Visible = true;
        this.labelPos33D.Visible = true;
        this.labelPos33E.Visible = true;
        this.labelPos33F.Visible = true;
        this.labelPos33G.Visible = true;
        this.labelPos33H.Visible = true;
        this.labelPos33I.Visible = true;
        this.labelPos33J.Visible = true;
        this.labelPos33K.Visible = true;
        this.labelPos33L.Visible = true;
        this.labelPos33M.Visible = true;
        this.labelPos33N.Visible = true;
        this.labelPos33O.Visible = true;
        this.labelPos33P.Visible = true;
        this.labelPos33Q.Visible = true;
        this.labelPos33R.Visible = true;
        this.labelPos33S.Visible = true;
        this.labelPos33T.Visible = true;
        this.labelPos33U.Visible = true;
      }
      else
      {
        this.labelPos0.Visible = false;
        this.labelPos1.Visible = false;
        this.labelPos2.Visible = false;
        this.labelPos3.Visible = false;
        this.labelPos4.Visible = false;
        this.labelPos5.Visible = false;
        this.labelPos6.Visible = false;
        this.labelPos7.Visible = false;
        this.labelPos8.Visible = false;
        this.labelPos9.Visible = false;
        this.labelPos10.Visible = false;
        this.labelPos11.Visible = false;
        this.labelPos12.Visible = false;
        this.labelPos13.Visible = false;
        this.labelPos14.Visible = false;
        this.labelPos15.Visible = false;
        this.labelPos16.Visible = false;
        this.labelPos17.Visible = false;
        this.labelPos18.Visible = false;
        this.labelPos19.Visible = false;
        this.labelPos20.Visible = false;
        this.labelPos21.Visible = false;
        this.labelPos22.Visible = false;
        this.labelPos23.Visible = false;
        this.labelPos24.Visible = false;
        this.labelPos25.Visible = false;
        this.labelPos26.Visible = false;
        this.labelPos27.Visible = false;
        this.labelPos32A.Visible = false;
        this.labelPos32B.Visible = false;
        this.labelPos32C.Visible = false;
        this.labelPos32D.Visible = false;
        this.labelPos32E.Visible = false;
        this.labelPos32F.Visible = false;
        this.labelPos32G.Visible = false;
        this.labelPos33A.Visible = false;
        this.labelPos33B.Visible = false;
        this.labelPos33C.Visible = false;
        this.labelPos33D.Visible = false;
        this.labelPos33E.Visible = false;
        this.labelPos33F.Visible = false;
        this.labelPos33G.Visible = false;
        this.labelPos33H.Visible = false;
        this.labelPos33I.Visible = false;
        this.labelPos33J.Visible = false;
        this.labelPos33K.Visible = false;
        this.labelPos33L.Visible = false;
        this.labelPos33M.Visible = false;
        this.labelPos33N.Visible = false;
        this.labelPos33O.Visible = false;
        this.labelPos33P.Visible = false;
        this.labelPos33Q.Visible = false;
        this.labelPos33R.Visible = false;
        this.labelPos33S.Visible = false;
        this.labelPos33T.Visible = false;
        this.labelPos33U.Visible = false;
      }
      this.labelPos0.Text = this.labelPos1.Text = this.labelPos2.Text = this.labelPos3.Text = this.labelPos4.Text = this.labelPos5.Text = this.labelPos6.Text = this.labelPos7.Text = this.labelPos8.Text = this.labelPos9.Text = this.labelPos10.Text = this.labelPos11.Text = this.labelPos12.Text = this.labelPos13.Text = this.labelPos14.Text = this.labelPos15.Text = this.labelPos16.Text = this.labelPos17.Text = this.labelPos18.Text = this.labelPos19.Text = this.labelPos20.Text = this.labelPos21.Text = this.labelPos22.Text = this.labelPos23.Text = this.labelPos24.Text = this.labelPos25.Text = this.labelPos26.Text = this.labelPos27.Text = this.labelPos32A.Text = this.labelPos32B.Text = this.labelPos32C.Text = this.labelPos32D.Text = this.labelPos32E.Text = this.labelPos32F.Text = this.labelPos32G.Text = this.labelPos33A.Text = this.labelPos33B.Text = this.labelPos33C.Text = this.labelPos33D.Text = this.labelPos33E.Text = this.labelPos33F.Text = this.labelPos33G.Text = this.labelPos33H.Text = this.labelPos33I.Text = this.labelPos33J.Text = this.labelPos33K.Text = this.labelPos33L.Text = this.labelPos33M.Text = this.labelPos33N.Text = this.labelPos33O.Text = this.labelPos33P.Text = this.labelPos33Q.Text = this.labelPos33R.Text = this.labelPos33S.Text = this.labelPos33T.Text = this.labelPos33U.Text = "______";
      this.labelPos0.Tag = (object) new TeamPlayer(ERole.Goalkeeper);
      this.labelPos1.Tag = (object) new TeamPlayer(ERole.Sweeper);
      this.labelPos2.Tag = (object) new TeamPlayer(ERole.Right_Wing_Back);
      this.labelPos3.Tag = (object) new TeamPlayer(ERole.Right_Back);
      this.labelPos4.Tag = (object) new TeamPlayer(ERole.Right_Central_Back);
      this.labelPos5.Tag = (object) new TeamPlayer(ERole.Central_Back);
      this.labelPos6.Tag = (object) new TeamPlayer(ERole.Left_Central_Back);
      this.labelPos7.Tag = (object) new TeamPlayer(ERole.Left_Back);
      this.labelPos8.Tag = (object) new TeamPlayer(ERole.Left_Wing_Back);
      this.labelPos9.Tag = (object) new TeamPlayer(ERole.Right_Defensive_Midfielder);
      this.labelPos10.Tag = (object) new TeamPlayer(ERole.Central_Defensive_Midfielder);
      this.labelPos11.Tag = (object) new TeamPlayer(ERole.Left_Defensive_Midfielder);
      this.labelPos12.Tag = (object) new TeamPlayer(ERole.Right_Midfielder);
      this.labelPos13.Tag = (object) new TeamPlayer(ERole.Right_Central_Midfielder);
      this.labelPos14.Tag = (object) new TeamPlayer(ERole.Central_Midfielder);
      this.labelPos15.Tag = (object) new TeamPlayer(ERole.Left_Central_Midfielder);
      this.labelPos16.Tag = (object) new TeamPlayer(ERole.Left_Midfielder);
      this.labelPos17.Tag = (object) new TeamPlayer(ERole.Right_Advanced_Midfielder);
      this.labelPos18.Tag = (object) new TeamPlayer(ERole.Central_Advanced_Midfielder);
      this.labelPos19.Tag = (object) new TeamPlayer(ERole.Left_Advanced_Midfielder);
      this.labelPos20.Tag = (object) new TeamPlayer(ERole.Right_Forward);
      this.labelPos21.Tag = (object) new TeamPlayer(ERole.Central_Forward);
      this.labelPos22.Tag = (object) new TeamPlayer(ERole.Left_Forward);
      this.labelPos23.Tag = (object) new TeamPlayer(ERole.Right_Wing);
      this.labelPos24.Tag = (object) new TeamPlayer(ERole.Right_Striker);
      this.labelPos25.Tag = (object) new TeamPlayer(ERole.Central_Striker);
      this.labelPos26.Tag = (object) new TeamPlayer(ERole.Left_Striker);
      this.labelPos27.Tag = (object) new TeamPlayer(ERole.Left_Wing);
      this.labelPos32A.Tag = (object) new TeamPlayer(ERole.Substitute);
      this.labelPos32B.Tag = (object) new TeamPlayer(ERole.Substitute);
      this.labelPos32C.Tag = (object) new TeamPlayer(ERole.Substitute);
      this.labelPos32D.Tag = (object) new TeamPlayer(ERole.Substitute);
      this.labelPos32E.Tag = (object) new TeamPlayer(ERole.Substitute);
      this.labelPos32F.Tag = (object) new TeamPlayer(ERole.Substitute);
      this.labelPos32G.Tag = (object) new TeamPlayer(ERole.Substitute);
      this.labelPos33A.Tag = (object) new TeamPlayer(ERole.Tribune);
      this.labelPos33B.Tag = (object) new TeamPlayer(ERole.Tribune);
      this.labelPos33C.Tag = (object) new TeamPlayer(ERole.Tribune);
      this.labelPos33D.Tag = (object) new TeamPlayer(ERole.Tribune);
      this.labelPos33E.Tag = (object) new TeamPlayer(ERole.Tribune);
      this.labelPos33F.Tag = (object) new TeamPlayer(ERole.Tribune);
      this.labelPos33G.Tag = (object) new TeamPlayer(ERole.Tribune);
      this.labelPos33H.Tag = (object) new TeamPlayer(ERole.Tribune);
      this.labelPos33I.Tag = (object) new TeamPlayer(ERole.Tribune);
      this.labelPos33J.Tag = (object) new TeamPlayer(ERole.Tribune);
      this.labelPos33K.Tag = (object) new TeamPlayer(ERole.Tribune);
      this.labelPos33L.Tag = (object) new TeamPlayer(ERole.Tribune);
      this.labelPos33M.Tag = (object) new TeamPlayer(ERole.Tribune);
      this.labelPos33N.Tag = (object) new TeamPlayer(ERole.Tribune);
      this.labelPos33O.Tag = (object) new TeamPlayer(ERole.Tribune);
      this.labelPos33P.Tag = (object) new TeamPlayer(ERole.Tribune);
      this.labelPos33Q.Tag = (object) new TeamPlayer(ERole.Tribune);
      this.labelPos33R.Tag = (object) new TeamPlayer(ERole.Tribune);
      this.labelPos33S.Tag = (object) new TeamPlayer(ERole.Tribune);
      this.labelPos33T.Tag = (object) new TeamPlayer(ERole.Tribune);
      this.labelPos33U.Tag = (object) new TeamPlayer(ERole.Tribune);
      int num1 = 0;
      int num2 = 0;
      for (int index = 0; index < roster.Count; ++index)
      {
        TeamPlayer teamPlayer = (TeamPlayer) roster[index];
        switch (teamPlayer.position)
        {
          case 0:
            this.labelPos0.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos0.Visible = true;
            this.labelPos0.Tag = (object) teamPlayer;
            break;
          case 1:
            this.labelPos1.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos1.Visible = true;
            this.labelPos1.Tag = (object) teamPlayer;
            break;
          case 2:
            this.labelPos2.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos2.Visible = true;
            this.labelPos2.Tag = (object) teamPlayer;
            break;
          case 3:
            this.labelPos3.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos3.Visible = true;
            this.labelPos3.Tag = (object) teamPlayer;
            break;
          case 4:
            this.labelPos4.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos4.Visible = true;
            this.labelPos4.Tag = (object) teamPlayer;
            break;
          case 5:
            this.labelPos5.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos5.Visible = true;
            this.labelPos5.Tag = (object) teamPlayer;
            break;
          case 6:
            this.labelPos6.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos6.Visible = true;
            this.labelPos6.Tag = (object) teamPlayer;
            break;
          case 7:
            this.labelPos7.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos7.Visible = true;
            this.labelPos7.Tag = (object) teamPlayer;
            break;
          case 8:
            this.labelPos8.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos8.Visible = true;
            this.labelPos8.Tag = (object) teamPlayer;
            break;
          case 9:
            this.labelPos9.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos9.Visible = true;
            this.labelPos9.Tag = (object) teamPlayer;
            break;
          case 10:
            this.labelPos10.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos10.Visible = true;
            this.labelPos10.Tag = (object) teamPlayer;
            break;
          case 11:
            this.labelPos11.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos11.Visible = true;
            this.labelPos11.Tag = (object) teamPlayer;
            break;
          case 12:
            this.labelPos12.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos12.Visible = true;
            this.labelPos12.Tag = (object) teamPlayer;
            break;
          case 13:
            this.labelPos13.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos13.Visible = true;
            this.labelPos13.Tag = (object) teamPlayer;
            break;
          case 14:
            this.labelPos14.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos14.Visible = true;
            this.labelPos14.Tag = (object) teamPlayer;
            break;
          case 15:
            this.labelPos15.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos15.Visible = true;
            this.labelPos15.Tag = (object) teamPlayer;
            break;
          case 16:
            this.labelPos16.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos16.Visible = true;
            this.labelPos16.Tag = (object) teamPlayer;
            break;
          case 17:
            this.labelPos17.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos17.Visible = true;
            this.labelPos17.Tag = (object) teamPlayer;
            break;
          case 18:
            this.labelPos18.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos18.Visible = true;
            this.labelPos18.Tag = (object) teamPlayer;
            break;
          case 19:
            this.labelPos19.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos19.Visible = true;
            this.labelPos19.Tag = (object) teamPlayer;
            break;
          case 20:
            this.labelPos20.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos20.Visible = true;
            this.labelPos20.Tag = (object) teamPlayer;
            break;
          case 21:
            this.labelPos21.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos21.Visible = true;
            this.labelPos21.Tag = (object) teamPlayer;
            break;
          case 22:
            this.labelPos22.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos22.Visible = true;
            this.labelPos22.Tag = (object) teamPlayer;
            break;
          case 23:
            this.labelPos23.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos23.Visible = true;
            this.labelPos23.Tag = (object) teamPlayer;
            break;
          case 24:
            this.labelPos24.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos24.Visible = true;
            this.labelPos24.Tag = (object) teamPlayer;
            break;
          case 25:
            this.labelPos25.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos25.Visible = true;
            this.labelPos25.Tag = (object) teamPlayer;
            break;
          case 26:
            this.labelPos26.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos26.Visible = true;
            this.labelPos26.Tag = (object) teamPlayer;
            break;
          case 27:
            this.labelPos27.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
            this.labelPos27.Visible = true;
            this.labelPos27.Tag = (object) teamPlayer;
            break;
          case 28:
            switch (num1)
            {
              case 0:
                this.labelPos32A.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos32A.Visible = true;
                this.labelPos32A.Tag = (object) teamPlayer;
                break;
              case 1:
                this.labelPos32B.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos32B.Visible = true;
                this.labelPos32B.Tag = (object) teamPlayer;
                break;
              case 2:
                this.labelPos32C.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos32C.Visible = true;
                this.labelPos32C.Tag = (object) teamPlayer;
                break;
              case 3:
                this.labelPos32D.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos32D.Visible = true;
                this.labelPos32D.Tag = (object) teamPlayer;
                break;
              case 4:
                this.labelPos32E.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos32E.Visible = true;
                this.labelPos32E.Tag = (object) teamPlayer;
                break;
              case 5:
                this.labelPos32F.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos32F.Visible = true;
                this.labelPos32F.Tag = (object) teamPlayer;
                break;
              case 6:
                this.labelPos32G.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos32G.Visible = true;
                this.labelPos32G.Tag = (object) teamPlayer;
                break;
              case 7:
                teamPlayer.position = 29;
                --num1;
                --index;
                break;
            }
            ++num1;
            break;
          case 29:
            switch (num2)
            {
              case 0:
                this.labelPos33A.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos33A.Visible = true;
                this.labelPos33A.Tag = (object) teamPlayer;
                break;
              case 1:
                this.labelPos33B.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos33B.Visible = true;
                this.labelPos33B.Tag = (object) teamPlayer;
                break;
              case 2:
                this.labelPos33C.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos33C.Visible = true;
                this.labelPos33C.Tag = (object) teamPlayer;
                break;
              case 3:
                this.labelPos33D.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos33D.Visible = true;
                this.labelPos33D.Tag = (object) teamPlayer;
                break;
              case 4:
                this.labelPos33E.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos33E.Visible = true;
                this.labelPos33E.Tag = (object) teamPlayer;
                break;
              case 5:
                this.labelPos33F.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos33F.Visible = true;
                this.labelPos33F.Tag = (object) teamPlayer;
                break;
              case 6:
                this.labelPos33G.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos33G.Visible = true;
                this.labelPos33G.Tag = (object) teamPlayer;
                break;
              case 7:
                this.labelPos33H.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos33H.Visible = true;
                this.labelPos33H.Tag = (object) teamPlayer;
                break;
              case 8:
                this.labelPos33I.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos33I.Visible = true;
                this.labelPos33I.Tag = (object) teamPlayer;
                break;
              case 9:
                this.labelPos33J.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos33J.Visible = true;
                this.labelPos33J.Tag = (object) teamPlayer;
                break;
              case 10:
                this.labelPos33K.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos33K.Visible = true;
                this.labelPos33K.Tag = (object) teamPlayer;
                break;
              case 11:
                this.labelPos33L.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos33L.Visible = true;
                this.labelPos33L.Tag = (object) teamPlayer;
                break;
              case 12:
                this.labelPos33M.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos33M.Visible = true;
                this.labelPos33M.Tag = (object) teamPlayer;
                break;
              case 13:
                this.labelPos33N.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos33N.Visible = true;
                this.labelPos33N.Tag = (object) teamPlayer;
                break;
              case 14:
                this.labelPos33O.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos33O.Visible = true;
                this.labelPos33O.Tag = (object) teamPlayer;
                break;
              case 15:
                this.labelPos33P.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos33P.Visible = true;
                this.labelPos33P.Tag = (object) teamPlayer;
                break;
              case 16:
                this.labelPos33Q.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos33Q.Visible = true;
                this.labelPos33Q.Tag = (object) teamPlayer;
                break;
              case 17:
                this.labelPos33R.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos33R.Visible = true;
                this.labelPos33R.Tag = (object) teamPlayer;
                break;
              case 18:
                this.labelPos33S.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos33S.Visible = true;
                this.labelPos33S.Tag = (object) teamPlayer;
                break;
              case 19:
                this.labelPos33T.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos33T.Visible = true;
                this.labelPos33T.Tag = (object) teamPlayer;
                break;
              case 20:
                this.labelPos33U.Text = teamPlayer.m_jerseynumber.ToString() + "\n" + teamPlayer.Player.Name;
                this.labelPos33U.Visible = true;
                this.labelPos33U.Tag = (object) teamPlayer;
                break;
              default:
                int num3 = (int) FifaEnvironment.UserMessages.ShowMessage(5021);
                break;
            }
            ++num2;
            break;
        }
      }
      this.InitSpecialPlayers(this.m_CurrentTeam);
    }

    private void InitSpecialPlayers(Team team)
    {
      if (team == null)
        return;
      if (team.PlayerCaptain != null)
        this.labelCaptain.Text = team.PlayerCaptain.Name;
      else
        this.labelCaptain.Text = "______";
      if (team.PlayerPenalty != null)
        this.labelPenalty.Text = team.PlayerPenalty.Name;
      else
        this.labelPenalty.Text = "______";
      if (team.PlayerFreeKick != null)
        this.labelFreeKick.Text = team.PlayerFreeKick.Name;
      else
        this.labelFreeKick.Text = "______";
      if (FifaEnvironment.Year > 14)
      {
        if (team.PlayerRightFreeKick != null)
          this.labelRightFreeKick.Text = team.PlayerRightFreeKick.Name;
        else
          this.labelRightFreeKick.Text = "______";
        if (team.PlayerLeftFreeKick != null)
          this.labelLeftFreeKick.Text = team.PlayerLeftFreeKick.Name;
        else
          this.labelLeftFreeKick.Text = "______";
      }
      if (team.PlayerLongKick != null)
        this.labelLongKick.Text = team.PlayerLongKick.Name;
      else
        this.labelLongKick.Text = "______";
      if (team.PlayerLeftCorner != null)
        this.labelLeftCorner.Text = team.PlayerLeftCorner.Name;
      else
        this.labelLeftCorner.Text = "______";
      if (team.PlayerRightCorner != null)
        this.labelRightCorner.Text = team.PlayerRightCorner.Name;
      else
        this.labelRightCorner.Text = "______";
    }

    private void labelSpecial_DragEnter(object sender, DragEventArgs e)
    {
      e.Effect = DragDropEffects.Copy;
    }

    private void labelSpecial_DragDrop(object sender, DragEventArgs e)
    {
      Label label = (Label) sender;
      TeamPlayer tag = (TeamPlayer) this.m_DraggedLabel.Tag;
      label.Text = tag.Player.Name;
      if (label == this.labelCaptain)
      {
        this.m_CurrentTeam.PlayerCaptain = tag.Player;
        this.m_CurrentTeam.captainid = this.m_CurrentTeam.PlayerCaptain.Id;
      }
      else if (label == this.labelPenalty)
      {
        this.m_CurrentTeam.PlayerPenalty = tag.Player;
        this.m_CurrentTeam.penaltytakerid = this.m_CurrentTeam.PlayerPenalty.Id;
      }
      else if (label == this.labelFreeKick)
      {
        this.m_CurrentTeam.PlayerFreeKick = tag.Player;
        this.m_CurrentTeam.freekicktakerid = this.m_CurrentTeam.PlayerFreeKick.Id;
      }
      else if (label == this.labelLeftFreeKick)
      {
        this.m_CurrentTeam.PlayerLeftFreeKick = tag.Player;
        this.m_CurrentTeam.leftfreekicktakerid = this.m_CurrentTeam.PlayerLeftFreeKick.Id;
      }
      else if (label == this.labelRightFreeKick)
      {
        this.m_CurrentTeam.PlayerRightFreeKick = tag.Player;
        this.m_CurrentTeam.rightfreekicktakerid = this.m_CurrentTeam.PlayerRightFreeKick.Id;
      }
      else if (label == this.labelLongKick)
      {
        this.m_CurrentTeam.PlayerLongKick = tag.Player;
        this.m_CurrentTeam.longkicktakerid = this.m_CurrentTeam.PlayerLongKick.Id;
      }
      else if (label == this.labelLeftCorner)
      {
        this.m_CurrentTeam.PlayerLeftCorner = tag.Player;
        this.m_CurrentTeam.leftcornerkicktakerid = this.m_CurrentTeam.PlayerLeftCorner.Id;
      }
      else
      {
        if (label != this.labelRightCorner)
          return;
        this.m_CurrentTeam.PlayerRightCorner = tag.Player;
        this.m_CurrentTeam.rightcornerkicktakerid = this.m_CurrentTeam.PlayerRightCorner.Id;
      }
    }

    private void labelPos_MouseDown(object sender, MouseEventArgs e)
    {
      Label label = (Label) sender;
      if (label.Text == "______")
        return;
      this.m_DraggedLabel = label;
      if (this.listViewTeamPlayers.SelectedItems.Count > 0)
        this.listViewTeamPlayers.SelectedItems[0].Selected = false;
      TeamPlayer tag = (TeamPlayer) this.m_DraggedLabel.Tag;
      for (int index = 0; index < this.listViewTeamPlayers.Items.Count; ++index)
      {
        ListViewItem listViewItem = this.listViewTeamPlayers.Items[index];
        if (listViewItem.Tag == tag)
        {
          listViewItem.Selected = true;
          break;
        }
      }
      int num = (int) this.m_DraggedLabel.DoDragDrop((object) this.m_DraggedLabel.Text, DragDropEffects.Copy | DragDropEffects.Move);
    }

    private void labelPos_DragDrop(object sender, DragEventArgs e)
    {
      Label label = (Label) sender;
      TeamPlayer tag1 = (TeamPlayer) this.m_DraggedLabel.Tag;
      string text = this.m_DraggedLabel.Text;
      this.m_DraggedLabel.Text = label.Text;
      label.Text = text;
      TeamPlayer tag2 = (TeamPlayer) label.Tag;
      int position = tag1.position;
      tag1.position = tag2.position;
      tag2.position = position;
      TeamPlayer teamPlayer = tag1;
      this.m_DraggedLabel.Tag = (object) tag2;
      label.Tag = (object) teamPlayer;
    }

    private void labelPos_DragEnter(object sender, DragEventArgs e)
    {
      e.Effect = DragDropEffects.Move;
    }

    private void listViewRoster_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      ListView listView = (ListView) sender;
      SortOrder sortOrder = listView.Sorting != SortOrder.Ascending ? SortOrder.Ascending : SortOrder.Descending;
      listView.Sorting = sortOrder;
      listView.ListViewItemSorter = (IComparer) new ListViewItemComparer(e.Column, sortOrder);
    }

    private void radioUseSpecificFormation_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockUserChanges || !this.radioUseSpecificFormation.Checked)
        return;
      int newId = FifaEnvironment.Formations.GetNewId();
      if (newId < 0)
      {
        int num = (int) FifaEnvironment.UserMessages.ShowMessage(5043);
        this.radioUseGenericFormation.Checked = true;
      }
      else
      {
        Formation formation1 = this.m_BackupSpecificFormation == null ? this.m_CurrentFormation : this.m_BackupSpecificFormation;
        if (formation1 == null)
          return;
        Formation formation2 = (Formation) formation1.Clone(newId);
        FifaEnvironment.Formations.InsertId((IdObject) formation2);
        this.m_CurrentTeam.Formation = formation2;
        this.m_CurrentFormation = formation2;
        this.m_CurrentTeam.formationid = formation2.Id;
        this.m_CurrentFormation.Team = this.m_CurrentTeam;
        if (this.m_BackupSpecificFormation != null)
          this.m_CurrentTeam.AssignTitolarToRoles(formation2);
        this.InitVisualFormation(this.m_CurrentTeam.Roster);
        this.labelTeamFormationName.Text = this.m_CurrentFormation.ToString();
      }
    }

    private void radioUseGenericFormation_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockUserChanges)
        return;
      if (this.radioUseGenericFormation.Checked)
      {
        if (this.m_CurrentFormation != null && !this.m_CurrentFormation.IsGeneric())
        {
          this.m_BackupSpecificFormation = this.m_CurrentFormation;
          FifaEnvironment.Formations.RemoveId((IdObject) this.m_CurrentFormation);
        }
        if (this.comboGenericFormations.SelectedIndex < 0)
          this.comboGenericFormations.SelectedIndex = 0;
        Formation selectedItem = (Formation) this.comboGenericFormations.SelectedItem;
        this.m_CurrentTeam.Formation = selectedItem;
        this.m_CurrentFormation = selectedItem;
        this.m_CurrentTeam.formationid = selectedItem.Id;
        this.m_CurrentTeam.AssignTitolarToRoles(selectedItem);
        this.InitVisualFormation(this.m_CurrentTeam.Roster);
        this.labelTeamFormationName.Text = this.m_CurrentFormation.ToString();
      }
      this.comboGenericFormations.Visible = this.radioUseGenericFormation.Checked;
    }

    private void comboGenericFormations_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockUserChanges || this.comboGenericFormations.SelectedIndex < 0)
        return;
      Formation selectedItem = (Formation) this.comboGenericFormations.SelectedItem;
      if (selectedItem == null || selectedItem == this.m_CurrentTeam.Formation)
        return;
      this.m_CurrentTeam.Formation = selectedItem;
      this.m_CurrentFormation = selectedItem;
      this.m_CurrentTeam.formationid = selectedItem.Id;
      this.m_CurrentTeam.AssignTitolarToRoles(selectedItem);
      this.InitVisualFormation(this.m_CurrentTeam.Roster);
      this.labelTeamFormationName.Text = this.m_CurrentFormation.ToString();
    }

    private int ComputeOffensiveImageIndex(int roleIndex)
    {
      return this.ComputeOffensiveImageIndex(this.m_CurrentFormation.PlayingRoles[roleIndex]);
    }

    private int ComputeOffensiveImageIndex(PlayingRole playingRole)
    {
      EPlayingDirection offDirection0 = playingRole.OffDirection0;
      EPlayingIntensity offIntensity = playingRole.OffIntensity;
      int num = 0;
      switch (offIntensity)
      {
        case EPlayingIntensity.Normal:
          num = 0;
          break;
        case EPlayingIntensity.Poor:
          num = 9;
          break;
        case EPlayingIntensity.Intense:
          num = 18;
          break;
        case EPlayingIntensity.UsePlayer:
          num = 27;
          break;
      }
      switch (offDirection0)
      {
        case EPlayingDirection.Standing:
          num = num;
          break;
        case EPlayingDirection.Left:
          num += 3;
          break;
        case EPlayingDirection.DiagonalLeft:
          num += 2;
          break;
        case EPlayingDirection.Stright:
          ++num;
          break;
        case EPlayingDirection.DiagonalRight:
          num += 8;
          break;
        case EPlayingDirection.Right:
          num += 7;
          break;
      }
      return num;
    }

    private int ComputeDefensiveImageIndex(int roleIndex)
    {
      return this.ComputeDefensiveImageIndex(this.m_CurrentFormation.PlayingRoles[roleIndex]);
    }

    private int ComputeDefensiveImageIndex(PlayingRole playingRole)
    {
      EPlayingDirection defDirection0 = playingRole.DefDirection0;
      EPlayingIntensity defIntensity = playingRole.DefIntensity;
      int num = 0;
      switch (defIntensity)
      {
        case EPlayingIntensity.Normal:
          num = 0;
          break;
        case EPlayingIntensity.Poor:
          num = 9;
          break;
        case EPlayingIntensity.Intense:
          num = 18;
          break;
        case EPlayingIntensity.UsePlayer:
          num = 27;
          break;
      }
      switch (defDirection0)
      {
        case EPlayingDirection.Standing:
          num = num;
          break;
        case EPlayingDirection.Left:
          num += 3;
          break;
        case EPlayingDirection.DiagonalLeft:
          num += 4;
          break;
        case EPlayingDirection.Stright:
          num += 5;
          break;
        case EPlayingDirection.DiagonalRight:
          num += 6;
          break;
        case EPlayingDirection.Right:
          num += 7;
          break;
      }
      return num;
    }

    private void MovePicture(MouseEventArgs e, Label picture)
    {
      int num1 = e.X - 8;
      int num2 = e.Y - 8;
      this.m_LabelLocation.X = picture.Location.X + num1;
      this.m_LabelLocation.Y = picture.Location.Y + num2;
      if (this.m_LabelLocation.X < this.m_BoundLeft)
        this.m_LabelLocation.X = this.m_BoundLeft;
      if (this.m_LabelLocation.X > this.m_BoundRight)
        this.m_LabelLocation.X = this.m_BoundRight;
      if (this.m_LabelLocation.Y < this.m_BoundTop)
        this.m_LabelLocation.Y = this.m_BoundTop;
      if (this.m_LabelLocation.Y > this.m_BoundBottom)
        this.m_LabelLocation.Y = this.m_BoundBottom;
      picture.Location = this.m_LabelLocation;
    }

    private EPlayingDirection ClickToAttackRole(EventArgs e)
    {
      int x = ((MouseEventArgs) e).X;
      int y = ((MouseEventArgs) e).Y;
      return x >= 16 ? (x >= 32 ? (y >= 16 ? (y >= 32 ? EPlayingDirection.DiagonalLeft : EPlayingDirection.Left) : EPlayingDirection.Left) : (y >= 16 ? (y >= 32 ? EPlayingDirection.Stright : EPlayingDirection.Standing) : EPlayingDirection.Standing)) : (y >= 16 ? (y >= 32 ? EPlayingDirection.DiagonalRight : EPlayingDirection.Right) : EPlayingDirection.Right);
    }

    private EPlayingDirection ClickToDefenseRole(EventArgs e)
    {
      int x = ((MouseEventArgs) e).X;
      int y = ((MouseEventArgs) e).Y;
      return x >= 16 ? (x >= 32 ? (y >= 16 ? (y >= 32 ? EPlayingDirection.Left : EPlayingDirection.Left) : EPlayingDirection.DiagonalLeft) : (y >= 16 ? (y >= 32 ? EPlayingDirection.Standing : EPlayingDirection.Standing) : EPlayingDirection.Stright)) : (y >= 16 ? (y >= 32 ? EPlayingDirection.Right : EPlayingDirection.Right) : EPlayingDirection.DiagonalRight);
    }

    private void buttonReplicateLogo_Click(object sender, EventArgs e)
    {
      Bitmap currentBitmap = this.viewer2DCrestLarge.CurrentBitmap;
      Rectangle srcRect = new Rectangle(0, 0, 256, 256);
      Bitmap bitmap1 = new Bitmap(64, 64, PixelFormat.Format32bppPArgb);
      Bitmap bitmap2 = new Bitmap(32, 32, PixelFormat.Format32bppPArgb);
      Bitmap bitmap3 = new Bitmap(16, 16, PixelFormat.Format32bppPArgb);
      Rectangle destRect1 = new Rectangle(0, 0, 50, 50);
      Rectangle destRect2 = new Rectangle(0, 0, 32, 32);
      Rectangle destRect3 = new Rectangle(0, 0, 16, 16);
      GraphicUtil.RemapRectangle(currentBitmap, srcRect, bitmap1, destRect1);
      GraphicUtil.RemapRectangle(currentBitmap, srcRect, bitmap2, destRect2);
      GraphicUtil.RemapRectangle(currentBitmap, srcRect, bitmap3, destRect3);
      this.m_CurrentTeam.SetCrest16(bitmap3);
      this.m_CurrentTeam.SetCrest16Dark(bitmap3);
      this.viewer2DCrest16.CurrentBitmap = bitmap3;
      this.m_CurrentTeam.SetCrest32(bitmap2);
      this.m_CurrentTeam.SetCrest32Dark(bitmap2);
      this.viewer2DCrest32.CurrentBitmap = bitmap2;
      this.m_CurrentTeam.SetCrest50(bitmap1);
      this.m_CurrentTeam.SetCrest50Dark(bitmap1);
      this.viewer2DCrest50.CurrentBitmap = bitmap1;
    }

    private void textStadiumName_TextChanged(object sender, EventArgs e)
    {
      if (this.textStadiumName.Text.Length <= 30)
        return;
      this.textStadiumName.Text = this.textStadiumName.Text.Substring(0, 30);
    }

    private void comboTeamLeague_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboTeamLeague.SelectedItem != null)
        return;
      this.comboTeamLeague.Text = string.Empty;
    }

    private void comboPrevLeague_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboPrevLeague.SelectedItem != null)
        return;
      this.comboPrevLeague.Text = string.Empty;
    }

    private void textShortTeamName_TextChanged(object sender, EventArgs e)
    {
      if (this.textShortTeamName.Text.Length <= 10)
        return;
      this.textShortTeamName.Text = this.textShortTeamName.Text.Substring(0, 10);
    }

    private void textTeamName7_TextChanged(object sender, EventArgs e)
    {
      if (this.textTeamName7.Text.Length <= 7)
        return;
      this.textTeamName7.Text = this.textTeamName7.Text.Substring(0, 7);
    }

    private void textStandardTeamName_TextChanged(object sender, EventArgs e)
    {
      if (this.textShortTeamName.Text.Length <= 15)
        return;
      this.textShortTeamName.Text = this.textShortTeamName.Text.Substring(0, 15);
    }

    private void comboRivalTeam_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_CurrentTeam == null)
        return;
      Team selectedItem = (Team) this.comboRivalTeam.SelectedItem;
      if (selectedItem == this.m_CurrentTeam.RivalTeam)
        return;
      this.m_CurrentTeam.RivalTeam = selectedItem;
    }

    private void comboObjective_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_CurrentTeam == null || this.comboObjective.SelectedIndex < 0 || this.comboObjective.SelectedIndex == this.m_CurrentTeam.objective)
        return;
      this.m_CurrentTeam.objective = this.comboObjective.SelectedIndex;
    }

    private void comboMaxOnjective_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_CurrentTeam == null || this.comboMaxOnjective.SelectedIndex < 0 || this.comboMaxOnjective.SelectedIndex == this.m_CurrentTeam.highestpossible)
        return;
      this.m_CurrentTeam.highestpossible = this.comboMaxOnjective.SelectedIndex;
    }

    private void comboProbObjective_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_CurrentTeam == null || this.comboProbObjective.SelectedIndex < 0 || this.comboProbObjective.SelectedIndex == this.m_CurrentTeam.highestprobable)
        return;
      this.m_CurrentTeam.highestprobable = this.comboProbObjective.SelectedIndex;
    }

    private void buttonTeamPlayerPlus_Click(object sender, EventArgs e)
    {
      int selectedIndex = this.listViewTeamPlayers.SelectedIndices[0];
      foreach (TeamPlayer teamPlayer in (ArrayList) this.m_CurrentTeam.Roster)
        teamPlayer.Player.ChangeSkills(1);
      this.LoadRosterPage();
      if (selectedIndex < 0)
        return;
      this.listViewTeamPlayers.Items[selectedIndex].Selected = true;
    }

    private void buttonTeamPlayerMinus_Click(object sender, EventArgs e)
    {
      int selectedIndex = this.listViewTeamPlayers.SelectedIndices[0];
      foreach (TeamPlayer teamPlayer in (ArrayList) this.m_CurrentTeam.Roster)
        teamPlayer.Player.ChangeSkills(-1);
      this.LoadRosterPage();
      if (selectedIndex < 0)
        return;
      this.listViewTeamPlayers.Items[selectedIndex].Selected = true;
    }

    private void buttonPlusContract_Click(object sender, EventArgs e)
    {
      if (this.m_CurrentTeam == null || this.m_CurrentTeam.Roster == null)
        return;
      int selectedIndex = this.listViewTeamPlayers.SelectedIndices[0];
      foreach (TeamPlayer teamPlayer in (ArrayList) this.m_CurrentTeam.Roster)
        ++teamPlayer.Player.contractvaliduntil;
      this.LoadRosterPage();
      if (selectedIndex < 0)
        return;
      this.listViewTeamPlayers.Items[selectedIndex].Selected = true;
    }

    private void buttonMinusContract_Click(object sender, EventArgs e)
    {
      if (this.m_CurrentTeam == null || this.m_CurrentTeam.Roster == null)
        return;
      int selectedIndex = this.listViewTeamPlayers.SelectedIndices[0];
      foreach (TeamPlayer teamPlayer in (ArrayList) this.m_CurrentTeam.Roster)
        --teamPlayer.Player.contractvaliduntil;
      this.LoadRosterPage();
      if (selectedIndex < 0)
        return;
      this.listViewTeamPlayers.Items[selectedIndex].Selected = true;
    }

    private void labelFlag1_Click(object sender, EventArgs e)
    {
      Label label = (Label) sender;
      MouseEventArgs mouseEventArgs = (MouseEventArgs) e;
      if (mouseEventArgs.Button == MouseButtons.Left)
      {
        if (label.ImageIndex == label.ImageList.Images.Count - 1)
          label.ImageIndex = 0;
        else
          ++label.ImageIndex;
      }
      else
      {
        if (mouseEventArgs.Button != MouseButtons.Right)
          return;
        if (label.ImageIndex == 0)
          label.ImageIndex = label.ImageList.Images.Count - 1;
        else
          --label.ImageIndex;
      }
    }

    private void pictureFlagRed_Click(object sender, EventArgs e)
    {
      this.colorDialog.Color = this.pictureFlagRed.BackColor;
      int num = (int) this.colorDialog.ShowDialog();
      this.pictureFlagRed.BackColor = this.colorDialog.Color;
      this.m_CurrentTeam.TeamColor1 = this.colorDialog.Color;
    }

    private void pictureFlagGreen_Click(object sender, EventArgs e)
    {
      this.colorDialog.Color = this.pictureFlagGreen.BackColor;
      int num = (int) this.colorDialog.ShowDialog();
      this.pictureFlagGreen.BackColor = this.colorDialog.Color;
      this.m_CurrentTeam.TeamColor2 = this.colorDialog.Color;
    }

    private void pictureFlagBlue_Click(object sender, EventArgs e)
    {
      this.colorDialog.Color = this.pictureFlagBlue.BackColor;
      int num = (int) this.colorDialog.ShowDialog();
      this.pictureFlagBlue.BackColor = this.colorDialog.Color;
      this.m_CurrentTeam.TeamColor3 = this.colorDialog.Color;
    }

    private void buttonCreateFlags_Click(object sender, EventArgs e)
    {
      if (this.m_CurrentTeam == null)
        return;
      Bitmap[] bitmaps = new Bitmap[4];
      Bitmap crest = this.m_CurrentTeam.GetCrest();
      Rectangle rectangle = new Rectangle(0, 0, 256, 256);
      Rectangle destRectangle = new Rectangle(160, 32, 192, 192);
      string filename1 = FifaEnvironment.LaunchDir + "\\Templates\\" + Team.GenericFlagFileName(this.labelFlag1.ImageIndex + 1);
      bitmaps[0] = new Bitmap(filename1);
      GraphicUtil.ColorizeRGB(bitmaps[0], this.pictureFlagRed.BackColor, this.pictureFlagGreen.BackColor, this.pictureFlagBlue.BackColor, false);
      if (this.checkFlag1.Checked)
        bitmaps[0] = GraphicUtil.Overlap(bitmaps[0], crest, destRectangle);
      string filename2 = FifaEnvironment.LaunchDir + "\\Templates\\" + Team.GenericFlagFileName(this.labelFlag2.ImageIndex + 1);
      bitmaps[1] = new Bitmap(filename2);
      GraphicUtil.ColorizeRGB(bitmaps[1], this.pictureFlagRed.BackColor, this.pictureFlagGreen.BackColor, this.pictureFlagBlue.BackColor, false);
      if (this.checkFlag2.Checked)
        bitmaps[1] = GraphicUtil.Overlap(bitmaps[1], crest, destRectangle);
      destRectangle = new Rectangle(32, 32, 192, 192);
      string filename3 = FifaEnvironment.LaunchDir + "\\Templates\\" + Team.GenericFlagFileName(this.labelFlag3.ImageIndex + 1);
      bitmaps[2] = new Bitmap(filename3);
      GraphicUtil.ColorizeRGB(bitmaps[2], this.pictureFlagRed.BackColor, this.pictureFlagGreen.BackColor, this.pictureFlagBlue.BackColor, false);
      if (this.checkFlag3.Checked)
        bitmaps[2] = GraphicUtil.Overlap(bitmaps[2], crest, destRectangle);
      string filename4 = FifaEnvironment.LaunchDir + "\\Templates\\" + Team.GenericFlagFileName(this.labelFlag4.ImageIndex + 1);
      bitmaps[3] = new Bitmap(filename4);
      GraphicUtil.ColorizeRGB(bitmaps[3], this.pictureFlagRed.BackColor, this.pictureFlagGreen.BackColor, this.pictureFlagBlue.BackColor, false);
      if (this.checkFlag4.Checked)
        bitmaps[3] = GraphicUtil.Overlap(bitmaps[3], crest, destRectangle);
      this.m_CurrentTeam.SetFlags(bitmaps);
      this.multiViewer2DFlags15.Bitmaps = this.m_CurrentTeam.GetFlags();
    }

    private void comboDEFLine_SelectedIndexChanged(object sender, EventArgs e)
    {
      int num = this.m_LockUserChanges ? 1 : 0;
    }

    private void comboBUSPositioning_SelectedIndexChanged(object sender, EventArgs e)
    {
      int num = this.m_LockUserChanges ? 1 : 0;
    }

    private void comboCCPositioning_SelectedIndexChanged(object sender, EventArgs e)
    {
      int num = this.m_LockUserChanges ? 1 : 0;
    }

    private void checkHasSpecificAdboard_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockUserChanges)
        return;
      if (this.checkHasSpecificAdboard.Checked)
        this.m_CurrentTeam.CreateSpecificAdboard();
      else
        this.m_CurrentTeam.DeleteSpecificAdboard();
    }

    private void labelTeamFormationName_DoubleClick(object sender, EventArgs e)
    {
      if (this.m_CurrentTeam.Formation == null)
        return;
      MainForm.CM.JumpTo((IdObject) this.m_CurrentTeam.Formation);
    }

    private void labelStandardTeamName_DoubleClick(object sender, EventArgs e)
    {
      this.m_CurrentTeam.TeamNameAbbr15 = this.m_CurrentTeam.TeamNameFull.Length <= 15 ? this.m_CurrentTeam.TeamNameFull : this.m_CurrentTeam.TeamNameFull.Substring(0, 15);
      this.textStandardTeamName.Text = this.m_CurrentTeam.TeamNameAbbr15;
    }

    private void textShortTeamName_Click(object sender, EventArgs e)
    {
      this.m_CurrentTeam.TeamNameAbbr10 = this.m_CurrentTeam.TeamNameFull.Length <= 10 ? this.m_CurrentTeam.TeamNameFull : this.m_CurrentTeam.TeamNameFull.Substring(0, 10);
      this.textShortTeamName.Text = this.m_CurrentTeam.TeamNameAbbr10;
    }

    private void labelTeamName7_DoubleClick(object sender, EventArgs e)
    {
      this.m_CurrentTeam.TeamNameAbbr7 = this.m_CurrentTeam.TeamNameFull.Length <= 7 ? this.m_CurrentTeam.TeamNameFull : this.m_CurrentTeam.TeamNameFull.Substring(0, 7);
      this.textTeamName7.Text = this.m_CurrentTeam.TeamNameAbbr7;
    }

    private void label3_Click(object sender, EventArgs e)
    {
    }

    private void numericLatitude_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockUserChanges)
        return;
      this.m_CurrentTeam.latitude = (int) this.numericLatitude.Value;
    }

    private void numericLongitude_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockUserChanges)
        return;
      this.m_CurrentTeam.longitude = (int) this.numericLongitude.Value;
    }

    private void numericUtcOffset_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockUserChanges)
        return;
      this.m_CurrentTeam.utcoffset = (int) this.numericUtcOffset.Value;
    }
  }
}
