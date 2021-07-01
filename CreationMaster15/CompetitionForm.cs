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
  public class CompetitionForm : Form
  {
    private NewIdCreator m_NewIdCreator = new NewIdCreator();
    private Label[] m_QRLabels = new Label[48];
    private Label[] m_AdvanceLabels = new Label[48];
    private Label[] m_UpdateTableLabels = new Label[24];
    private ComboBox[] m_SpecialTeamCombos = new ComboBox[4];
    private ComboBox[] m_StadiumCombos = new ComboBox[12];
    private QualifyRuleDialog m_QualifyRuleDialog = new QualifyRuleDialog();
    private AdvanceRuleDialog m_AdvanceRuleDialog = new AdvanceRuleDialog();
    private RankingRuleDialog m_RankingRuleDialog = new RankingRuleDialog();
    private NumericUpDown[] m_RainProb = new NumericUpDown[12];
    private NumericUpDown[] m_SnowProb = new NumericUpDown[12];
    private NumericUpDown[] m_OvercastProb = new NumericUpDown[12];
    private ComboBox[] m_SunsetTime = new ComboBox[12];
    private ComboBox[] m_NightTime = new ComboBox[12];
    private Panel[] m_InitTeamPanel = new Panel[24];
    private ComboBox[] m_InitTeamCombo = new ComboBox[24];
    private string m_TrophyCurrentFolder = FifaEnvironment.ExportFolder;
    private bool m_IsLoaded;
    private CompobjList m_Competitions;
    private World m_CurrentWorld;
    private Confederation m_CurrentConfederation;
    private Nation m_CurrentNation;
    private Trophy m_CurrentTrophy;
    private Trophy m_ClipboardTrophy;
    private Stage m_CurrentStage;
    private Group m_CurrentGroup;
    private Compobj m_CurrentCompobj;
    private Schedule m_CurrentStageSchedule;
    private Schedule m_CurrentGroupSchedule;
    private bool m_Locked;
    private bool m_LockTree;
    private bool m_LockToPanel;
    private int m_NUpdateTableLabels;
    private Nation m_ClipboardNation;
    private Stage m_ClipboardStageForSchedule;
    private Group m_ClipboardGroupForSchedule;
    private Group m_ClipboardGroup;
    private IContainer components;
    private TreeView treeWorld;
    private GroupBox groupConfederation;
    private Label labelConfStartMonth;
    private ComboBox comboConfederationStartingMonth;
    private GroupBox groupNation;
    private GroupBox groupTrophy;
    private GroupBox groupStage;
    private ComboBox comboNationStartMonth;
    private NumericUpDown numericNationYellowsStored;
    private ComboBox comboNationStandingsRules;
    private CheckBox checkNationStandingsRules;
    private ComboBox comboCountry;
    private Label labelDatabaseCountry;
    private ToolTip toolTip;
    private Label labelCompetitionType;
    private Label labelAssetId;
    private Label labelMatchImportance;
    private CheckBox checkTrophyStandingsRules;
    private CheckBox checkPromotionLeague;
    private CheckBox checkRelegationLeague;
    private GroupBox groupSchedule;
    private GroupBox groupPromotionRelegation;
    private CheckBox checkForceSchedule;
    private TextBox textTrophyLongName;
    private TextBox textTrophyShortName;
    private Label labeTrophylLongName;
    private Label labelTrophyShortName;
    private Button buttonGetId;
    private NumericUpDown numericAssetId;
    private ComboBox comboCompetitionType;
    private NumericUpDown numericImportance;
    private ComboBox comboTrophyStandingRules;
    private ComboBox comboRelegationLeague;
    private ComboBox comboPromotionLeague;
    private ComboBox comboSchedForce;
    private ToolStrip toolCompetitionTree;
    private SplitContainer splitContainer1;
    private Panel panelCompObj;
    private Label label1;
    private Label label3;
    private TextBox textLanguageKey;
    private Label label2;
    private TextBox textFourCharName;
    private NumericUpDown numericNTeams;
    private Label label4;
    private Panel panelQualificationRules;
    private Panel panelAdvancement;
    private TabControl tabCompetitions;
    private TabPage pageConfederation;
    private TabPage pageNation;
    private TabPage pageTrophy;
    private TabPage pageStage;
    private TabPage pageGroup;
    private TabPage pageWorld;
    private GroupBox groupGroup;
    private CheckBox checkScheduleConflicts;
    private GroupBox groupBenchPlayers;
    private RadioButton radioBench7Players;
    private RadioButton radioBench5Players;
    private Label label6;
    private Label label5;
    private ComboBox comboStageType;
    private Label label7;
    private GroupBox groupPlayStage;
    private ComboBox comboMatchSituation;
    private Label label8;
    private GroupBox groupSetupStage;
    private NumericUpDown numericPrizeMoney;
    private Label label9;
    private NumericUpDown numericMoneyDrop;
    private Label label10;
    private CheckBox checkRandomDraw;
    private CheckBox checkMaxteamsgroup;
    private CheckBox checkMaxteamsassoc;
    private CheckBox checkCalccompavgs;
    private CheckBox checkMatchReplay;
    private CheckBox checkClausuraSchedule;
    private NumericUpDown numericStartYear;
    private Label label13;
    private GroupBox groupBox2;
    private ComboBox comboSpecialTeam1;
    private ComboBox comboSpecialTeam4;
    private ComboBox comboSpecialTeam3;
    private ComboBox comboSpecialTeam2;
    private GroupBox groupStadiums;
    private ComboBox comboStadium12;
    private ComboBox comboStadium11;
    private ComboBox comboStadium10;
    private ComboBox comboStadium9;
    private ComboBox comboStadium8;
    private ComboBox comboStadium7;
    private ComboBox comboStadium6;
    private ComboBox comboStadium5;
    private ComboBox comboStadium4;
    private ComboBox comboStadium3;
    private ComboBox comboStadium2;
    private ComboBox comboStadium1;
    private NumericUpDown numericStageRef;
    private NumericUpDown numericStandingKeep;
    private CheckBox checkStandingKeep;
    private NumericUpDown numericKeepPointsPercentage;
    private CheckBox checkKeepPointsPercentage;
    private ComboBox comboSpecialKo2Rule;
    private CheckBox checkSpecialKo2Rule;
    private ComboBox comboSpecialKo1Rule;
    private CheckBox checkSpecialKo1Rule;
    private NumericUpDown numericRegularSeason;
    private NumericUpDown numericStandingsRank;
    private CheckBox checkStandingsRank;
    private GroupBox groupInfoColors;
    private CheckBox checkInfoColorAdvance;
    private CheckBox checkInfoColorPromotion;
    private CheckBox checkInfoColorPossiblePromotion;
    private CheckBox checkInfoColorRelegation;
    private CheckBox checkInfoColorPossibleRelegation;
    private CheckBox checkInfoColorEuropa;
    private CheckBox checkInfoColorChampions;
    private CheckBox checkInfoColorChamp;
    private Label label12;
    private Label label11;
    private NumericUpDown numericColorAdvanceMax;
    private NumericUpDown numericColorAdvanceMin;
    private NumericUpDown numericColorPromotionMax;
    private NumericUpDown numericColorPromotionMin;
    private NumericUpDown numericColorPossiblePromotionMax;
    private NumericUpDown numericColorPossiblePromotionMin;
    private NumericUpDown numericColorRelegationMax;
    private NumericUpDown numericColorRelegationMin;
    private NumericUpDown numericColorPossibleRelegationMax;
    private NumericUpDown numericColorPossibleRelegationMin;
    private NumericUpDown numericColorEuropaMax;
    private NumericUpDown numericColorEuropaMin;
    private NumericUpDown numericColorChampionsMax;
    private NumericUpDown numericColorChampionsMin;
    private GroupBox groupSlots;
    private NumericUpDown numericPossiblePromotionMax;
    private CheckBox checkInfoPossiblePromotion;
    private NumericUpDown numericPossiblePromotionMin;
    private NumericUpDown numericPromotionMax;
    private NumericUpDown numericPromotionMin;
    private NumericUpDown numericRelegationMax;
    private NumericUpDown numericRelegationMin;
    private NumericUpDown numericPossibleRelegationMax;
    private NumericUpDown numericPossibleRelegationMin;
    private Label label15;
    private Label label16;
    private CheckBox checkInfoPromotion;
    private CheckBox checkInfoRelegation;
    private CheckBox checkInfoPossibleRelegation;
    private CheckBox checkInfoChamp;
    private ComboBox comboLanguageKey;
    private GroupBox groupWeather;
    private Label label28;
    private Label label27;
    private Label label26;
    private Label label25;
    private Label label24;
    private Label label23;
    private Label label22;
    private Label label21;
    private Label label20;
    private Label label19;
    private Label label18;
    private Label label17;
    private ComboBox comboBox23;
    private ComboBox comboBox24;
    private NumericUpDown numericUpDown34;
    private NumericUpDown numericUpDown35;
    private NumericUpDown numericUpDown36;
    private ComboBox comboBox21;
    private ComboBox comboBox22;
    private NumericUpDown numericUpDown31;
    private NumericUpDown numericUpDown32;
    private NumericUpDown numericUpDown33;
    private ComboBox comboBox19;
    private ComboBox comboBox20;
    private NumericUpDown numericUpDown28;
    private NumericUpDown numericUpDown29;
    private NumericUpDown numericUpDown30;
    private ComboBox comboBox17;
    private ComboBox comboBox18;
    private NumericUpDown numericUpDown25;
    private NumericUpDown numericUpDown26;
    private NumericUpDown numericUpDown27;
    private ComboBox comboBox15;
    private ComboBox comboBox16;
    private NumericUpDown numericUpDown22;
    private NumericUpDown numericUpDown23;
    private NumericUpDown numericUpDown24;
    private ComboBox comboBox13;
    private ComboBox comboBox14;
    private NumericUpDown numericUpDown19;
    private NumericUpDown numericUpDown20;
    private NumericUpDown numericUpDown21;
    private ComboBox comboBox11;
    private ComboBox comboBox12;
    private NumericUpDown numericUpDown16;
    private NumericUpDown numericUpDown17;
    private NumericUpDown numericUpDown18;
    private ComboBox comboBox9;
    private ComboBox comboBox10;
    private NumericUpDown numericUpDown13;
    private NumericUpDown numericUpDown14;
    private NumericUpDown numericUpDown15;
    private ComboBox comboBox7;
    private ComboBox comboBox8;
    private NumericUpDown numericUpDown10;
    private NumericUpDown numericUpDown11;
    private NumericUpDown numericUpDown12;
    private ComboBox comboBox5;
    private ComboBox comboBox6;
    private NumericUpDown numericUpDown7;
    private NumericUpDown numericUpDown8;
    private NumericUpDown numericUpDown9;
    private ComboBox comboBox3;
    private ComboBox comboBox4;
    private NumericUpDown numericUpDown4;
    private NumericUpDown numericUpDown5;
    private NumericUpDown numericUpDown6;
    private ComboBox comboBox1;
    private ComboBox comboBox2;
    private NumericUpDown numericUpDown1;
    private NumericUpDown numericUpDown2;
    private NumericUpDown numericUpDown3;
    private Label label33;
    private Label label32;
    private Label label31;
    private Label label30;
    private Label label29;
    private ToolStrip toolWeather;
    private ToolStripButton buttonCopyWeather;
    private ToolStripButton buttonPasteWeather;
    private GroupBox groupStageSchedules;
    private TreeView treeStageSchedule;
    private ToolStrip toolStageSchedule;
    private Panel panelStageScheduleDetails;
    private Label label37;
    private Label label36;
    private Label label35;
    private Label label34;
    private ComboBox comboStageTime;
    private NumericUpDown numericStageMaxGames;
    private NumericUpDown numericStageMinGames;
    private DateTimePicker dateStagePicker;
    private GroupBox groupStageScheduleDetails;
    private GroupBox groupGroupScheduke;
    private TreeView treeGroupSchedule;
    private Panel panelGroupScheduleDetails;
    private GroupBox groupGroupScheduleDetails;
    private DateTimePicker dateGroupPicker;
    private Label label38;
    private NumericUpDown numericGroupMinGames;
    private Label label39;
    private NumericUpDown numericGroupMaxGames;
    private Label label40;
    private ComboBox comboGroupTime;
    private Label label41;
    private ToolStrip toolGroupSchedule;
    private NumericUpDown numericNumGames;
    private Label label14;
    private GroupBox groupPlayGroup;
    private ToolStripButton buttonAddTrophy;
    private ToolStripButton buttonDeleteTrophy;
    private ToolStripButton buttonAddStage;
    private ToolStripButton buttonDeleteStage;
    private ToolStripButton buttonAddGroup;
    private ToolStripButton buttonDeleteGroup;
    private ToolStripButton buttonAddNatiom;
    private ToolStripButton buttonDeleteNation;
    private ToolStripButton buttonPasteTrophy;
    private ToolStripButton buttonCopyTrophy;
    private GroupBox groupRules;
    private ToolStrip toolRules;
    private ToolStripButton buttonAddRule;
    private ToolStripButton buttonRemoveRule;
    private ToolStripButton buttonCopyGroupCalendar;
    private ToolStripButton buttonPasteGroupCalendar;
    private ToolStripButton buttonNewGroupLeg;
    private ToolStripButton buttonRemoveGroupLeg;
    private ToolStripButton buttonGroupAddTime;
    private ToolStripButton buttonGroupRemoveTime;
    private ToolStripButton buttonCopyStageCalendar;
    private ToolStripButton buttonPasteStageCalendar;
    private ToolStripButton buttonNeewStageLeg;
    private ToolStripButton buttonDeleteStageLeg;
    private ToolStripButton buttonStageAddTime;
    private ToolStripButton buttonStageRemoveTime;
    private ToolStripButton buttonCleanStageCalendar;
    private ToolStripButton buttonCleanGroupCalendar;
    private Viewer2D viewer2DTrophy256;
    private Label label66;
    private TextBox textUniqueId;
    private Label label67;
    private NumericUpDown numericBall;
    private PictureBox pictureBall;
    private GroupBox group3D;
    private Viewer3D viewer3D;
    private ToolStrip toolNear3D;
    private ToolStripButton buttonShow3DModel;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton buttonImport3DModel;
    private ToolStripButton buttonExport3DModel;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripButton buttonRemove3DModel;
    private TabControl tabTrophy;
    private TabPage tabPageTrophyStructure;
    private TabPage tabPageTrophyGraphics;
    private GroupBox groupGraphics;
    private MultiViewer2D multiViewer2DTextures;
    private Button buttonReplicateTrophy128;
    private Viewer2D viewer2DTrophy128;
    private GroupBox groupInternationalschedule;
    private NumericUpDown numericInternationalPeriodicity;
    private Label label69;
    private Label label68;
    private NumericUpDown numericInternationalFirstYear;
    private TabPage tabPageRankingTable;
    private GroupBox groupInitTeams;
    private Panel panelInitTeam24;
    private ComboBox comboInitTeam24;
    private Label label65;
    private Panel panelInitTeam23;
    private ComboBox comboInitTeam23;
    private Label label64;
    private Panel panelInitTeam22;
    private ComboBox comboInitTeam22;
    private Label label63;
    private Panel panelInitTeam21;
    private ComboBox comboInitTeam21;
    private Label label62;
    private Panel panelInitTeam20;
    private ComboBox comboInitTeam20;
    private Label label61;
    private Panel panelInitTeam19;
    private ComboBox comboInitTeam19;
    private Label label60;
    private Panel panelInitTeam18;
    private ComboBox comboInitTeam18;
    private Label label59;
    private Panel panelInitTeam17;
    private ComboBox comboInitTeam17;
    private Label label58;
    private Panel panelInitTeam16;
    private ComboBox comboInitTeam16;
    private Label label57;
    private Panel panelInitTeam15;
    private ComboBox comboInitTeam15;
    private Label label56;
    private Panel panelInitTeam14;
    private ComboBox comboInitTeam14;
    private Label label55;
    private Panel panelInitTeam13;
    private ComboBox comboInitTeam13;
    private Label label54;
    private Panel panelInitTeam12;
    private ComboBox comboInitTeam12;
    private Label label53;
    private Panel panelInitTeam11;
    private ComboBox comboInitTeam11;
    private Label label52;
    private Panel panelInitTeam10;
    private ComboBox comboInitTeam10;
    private Label label51;
    private Panel panelInitTeam9;
    private ComboBox comboInitTeam9;
    private Label label50;
    private Panel panelInitTeam8;
    private ComboBox comboInitTeam8;
    private Label label49;
    private Panel panelInitTeam7;
    private ComboBox comboInitTeam7;
    private Label label48;
    private Panel panelInitTeam6;
    private ComboBox comboInitTeam6;
    private Label label47;
    private Panel panelInitTeam5;
    private ComboBox comboInitTeam5;
    private Label label46;
    private Panel panelInitTeam4;
    private ComboBox comboInitTeam4;
    private Label label45;
    private Panel panelInitTeam3;
    private ComboBox comboInitTeam3;
    private Label label44;
    private Panel panelInitTeam2;
    private ComboBox comboInitTeam2;
    private Label label43;
    private Panel panelInitTeam1;
    private ComboBox comboInitTeam1;
    private Label label42;
    private Label labelUpdateTable24;
    private Label labelUpdateTable23;
    private Label labelUpdateTable22;
    private Label labelUpdateTable21;
    private Label labelUpdateTable20;
    private Label labelUpdateTable19;
    private Label labelUpdateTable18;
    private Label labelUpdateTable17;
    private Label labelUpdateTable16;
    private Label labelUpdateTable15;
    private Label labelUpdateTable14;
    private Label labelUpdateTable13;
    private Label labelUpdateTable12;
    private Label labelUpdateTable11;
    private Label labelUpdateTable10;
    private Label labelUpdateTable9;
    private Label labelUpdateTable8;
    private Label labelUpdateTable7;
    private Label labelUpdateTable6;
    private Label labelUpdateTable5;
    private Label labelUpdateTable4;
    private Label labelUpdateTable3;
    private Label labelUpdateTable2;
    private Label labelUpdateTable1;
    private Label label70;
    private NumericUpDown numericUpdateTableEntries;
    private CheckBox checkUpdateLeagueStats;
    private ComboBox comboLeagueStats;
    private CheckBox checkClearLeagueStats;
    private GroupBox groupLeaguetasks;
    private CheckBox checkUpdateLeagueTable;
    private ComboBox comboStageStandingRules;
    private CheckBox checkStageStandingsRules;
    private Label label71;
    private ComboBox comboTrophyStartMonth;
    private CheckBox checkRandomDrawEvent;
    private ToolStripComboBox comboTargetLeague;
    private TextBox textLanguageName;
    private ToolStripButton buttonStageSortLegs;
    private ToolStripButton buttongroupSortLegs;
    private CheckBox checkScheduleUseDates;
    private NumericUpDown numericKeepPointsStageRef;
    private Button buttonReplicateTropy;
    private Viewer2D viewer2DTrophy;

    public CompetitionForm()
    {
      this.Visible = false;
      this.InitializeComponent();
      for (int index = 47; index >= 0; --index)
      {
        this.m_QRLabels[index] = new Label();
        this.m_QRLabels[index].Location = new Point(2, 58 + 20 * index);
        this.m_QRLabels[index].Name = "labelQR" + index.ToString();
        this.m_QRLabels[index].Text = "labelQR" + index.ToString();
        this.m_QRLabels[index].Size = new Size(480, 19);
        this.m_QRLabels[index].Dock = DockStyle.None;
        this.m_QRLabels[index].BorderStyle = BorderStyle.None;
        this.m_QRLabels[index].Cursor = Cursors.Hand;
        this.panelQualificationRules.Controls.Add((Control) this.m_QRLabels[index]);
        this.m_QRLabels[index].Click += new EventHandler(this.labelQR_Click);
      }
      for (int index = 47; index >= 0; --index)
      {
        this.m_AdvanceLabels[index] = new Label();
        this.m_AdvanceLabels[index].Location = new Point(4, 28 + 20 * index);
        this.m_AdvanceLabels[index].Name = "labelAdvancemenet" + index.ToString();
        this.m_AdvanceLabels[index].Text = "label advancement " + index.ToString();
        this.m_AdvanceLabels[index].Size = new Size(120, 19);
        this.m_AdvanceLabels[index].Dock = DockStyle.Top;
        this.m_AdvanceLabels[index].Cursor = Cursors.Hand;
        this.panelAdvancement.Controls.Add((Control) this.m_AdvanceLabels[index]);
        this.m_AdvanceLabels[index].Click += new EventHandler(this.labelAdvance_Click);
      }
      this.m_UpdateTableLabels[0] = this.labelUpdateTable1;
      this.m_UpdateTableLabels[1] = this.labelUpdateTable2;
      this.m_UpdateTableLabels[2] = this.labelUpdateTable3;
      this.m_UpdateTableLabels[3] = this.labelUpdateTable4;
      this.m_UpdateTableLabels[4] = this.labelUpdateTable5;
      this.m_UpdateTableLabels[5] = this.labelUpdateTable6;
      this.m_UpdateTableLabels[6] = this.labelUpdateTable7;
      this.m_UpdateTableLabels[7] = this.labelUpdateTable8;
      this.m_UpdateTableLabels[8] = this.labelUpdateTable9;
      this.m_UpdateTableLabels[9] = this.labelUpdateTable10;
      this.m_UpdateTableLabels[10] = this.labelUpdateTable11;
      this.m_UpdateTableLabels[11] = this.labelUpdateTable12;
      this.m_UpdateTableLabels[12] = this.labelUpdateTable13;
      this.m_UpdateTableLabels[13] = this.labelUpdateTable14;
      this.m_UpdateTableLabels[14] = this.labelUpdateTable15;
      this.m_UpdateTableLabels[15] = this.labelUpdateTable16;
      this.m_UpdateTableLabels[16] = this.labelUpdateTable17;
      this.m_UpdateTableLabels[17] = this.labelUpdateTable18;
      this.m_UpdateTableLabels[18] = this.labelUpdateTable19;
      this.m_UpdateTableLabels[19] = this.labelUpdateTable20;
      this.m_UpdateTableLabels[20] = this.labelUpdateTable21;
      this.m_UpdateTableLabels[21] = this.labelUpdateTable22;
      this.m_UpdateTableLabels[22] = this.labelUpdateTable23;
      this.m_UpdateTableLabels[23] = this.labelUpdateTable24;
      this.m_SpecialTeamCombos[0] = this.comboSpecialTeam1;
      this.m_SpecialTeamCombos[1] = this.comboSpecialTeam2;
      this.m_SpecialTeamCombos[2] = this.comboSpecialTeam3;
      this.m_SpecialTeamCombos[3] = this.comboSpecialTeam4;
      this.m_StadiumCombos[0] = this.comboStadium1;
      this.m_StadiumCombos[1] = this.comboStadium2;
      this.m_StadiumCombos[2] = this.comboStadium3;
      this.m_StadiumCombos[3] = this.comboStadium4;
      this.m_StadiumCombos[4] = this.comboStadium5;
      this.m_StadiumCombos[5] = this.comboStadium6;
      this.m_StadiumCombos[6] = this.comboStadium7;
      this.m_StadiumCombos[7] = this.comboStadium8;
      this.m_StadiumCombos[8] = this.comboStadium9;
      this.m_StadiumCombos[9] = this.comboStadium10;
      this.m_StadiumCombos[10] = this.comboStadium11;
      this.m_StadiumCombos[11] = this.comboStadium12;
      this.m_OvercastProb[0] = this.numericUpDown1;
      this.m_SnowProb[0] = this.numericUpDown2;
      this.m_RainProb[0] = this.numericUpDown3;
      this.m_OvercastProb[1] = this.numericUpDown4;
      this.m_SnowProb[1] = this.numericUpDown5;
      this.m_RainProb[1] = this.numericUpDown6;
      this.m_OvercastProb[2] = this.numericUpDown7;
      this.m_SnowProb[2] = this.numericUpDown8;
      this.m_RainProb[2] = this.numericUpDown9;
      this.m_OvercastProb[3] = this.numericUpDown10;
      this.m_SnowProb[3] = this.numericUpDown11;
      this.m_RainProb[3] = this.numericUpDown12;
      this.m_OvercastProb[4] = this.numericUpDown13;
      this.m_SnowProb[4] = this.numericUpDown14;
      this.m_RainProb[4] = this.numericUpDown15;
      this.m_OvercastProb[5] = this.numericUpDown16;
      this.m_SnowProb[5] = this.numericUpDown17;
      this.m_RainProb[5] = this.numericUpDown18;
      this.m_OvercastProb[6] = this.numericUpDown19;
      this.m_SnowProb[6] = this.numericUpDown20;
      this.m_RainProb[6] = this.numericUpDown21;
      this.m_OvercastProb[7] = this.numericUpDown22;
      this.m_SnowProb[7] = this.numericUpDown23;
      this.m_RainProb[7] = this.numericUpDown24;
      this.m_OvercastProb[8] = this.numericUpDown25;
      this.m_SnowProb[8] = this.numericUpDown26;
      this.m_RainProb[8] = this.numericUpDown27;
      this.m_OvercastProb[9] = this.numericUpDown28;
      this.m_SnowProb[9] = this.numericUpDown29;
      this.m_RainProb[9] = this.numericUpDown30;
      this.m_OvercastProb[10] = this.numericUpDown31;
      this.m_SnowProb[10] = this.numericUpDown32;
      this.m_RainProb[10] = this.numericUpDown33;
      this.m_OvercastProb[11] = this.numericUpDown34;
      this.m_SnowProb[11] = this.numericUpDown35;
      this.m_RainProb[11] = this.numericUpDown36;
      for (int index = 0; index < 12; ++index)
      {
        this.m_OvercastProb[index].ValueChanged += new EventHandler(this.weatherProb_ValueChanged);
        this.m_SnowProb[index].ValueChanged += new EventHandler(this.weatherProb_ValueChanged);
        this.m_RainProb[index].ValueChanged += new EventHandler(this.weatherProb_ValueChanged);
      }
      this.m_NightTime[0] = this.comboBox1;
      this.m_SunsetTime[0] = this.comboBox2;
      this.m_NightTime[1] = this.comboBox3;
      this.m_SunsetTime[1] = this.comboBox4;
      this.m_NightTime[2] = this.comboBox5;
      this.m_SunsetTime[2] = this.comboBox6;
      this.m_NightTime[3] = this.comboBox7;
      this.m_SunsetTime[3] = this.comboBox8;
      this.m_NightTime[4] = this.comboBox9;
      this.m_SunsetTime[4] = this.comboBox10;
      this.m_NightTime[5] = this.comboBox11;
      this.m_SunsetTime[5] = this.comboBox12;
      this.m_NightTime[6] = this.comboBox13;
      this.m_SunsetTime[6] = this.comboBox14;
      this.m_NightTime[7] = this.comboBox15;
      this.m_SunsetTime[7] = this.comboBox16;
      this.m_NightTime[8] = this.comboBox17;
      this.m_SunsetTime[8] = this.comboBox18;
      this.m_NightTime[9] = this.comboBox19;
      this.m_SunsetTime[9] = this.comboBox20;
      this.m_NightTime[10] = this.comboBox21;
      this.m_SunsetTime[10] = this.comboBox22;
      this.m_NightTime[11] = this.comboBox23;
      this.m_SunsetTime[11] = this.comboBox24;
      for (int index = 0; index < 12; ++index)
      {
        this.m_NightTime[index].SelectedIndexChanged += new EventHandler(this.dayTime_SelectedIndexChanged);
        this.m_SunsetTime[index].SelectedIndexChanged += new EventHandler(this.dayTime_SelectedIndexChanged);
      }
      this.m_InitTeamPanel[0] = this.panelInitTeam1;
      this.m_InitTeamPanel[1] = this.panelInitTeam2;
      this.m_InitTeamPanel[2] = this.panelInitTeam3;
      this.m_InitTeamPanel[3] = this.panelInitTeam4;
      this.m_InitTeamPanel[4] = this.panelInitTeam5;
      this.m_InitTeamPanel[5] = this.panelInitTeam6;
      this.m_InitTeamPanel[6] = this.panelInitTeam7;
      this.m_InitTeamPanel[7] = this.panelInitTeam8;
      this.m_InitTeamPanel[8] = this.panelInitTeam9;
      this.m_InitTeamPanel[9] = this.panelInitTeam10;
      this.m_InitTeamPanel[10] = this.panelInitTeam11;
      this.m_InitTeamPanel[11] = this.panelInitTeam12;
      this.m_InitTeamPanel[12] = this.panelInitTeam13;
      this.m_InitTeamPanel[13] = this.panelInitTeam14;
      this.m_InitTeamPanel[14] = this.panelInitTeam15;
      this.m_InitTeamPanel[15] = this.panelInitTeam16;
      this.m_InitTeamPanel[16] = this.panelInitTeam17;
      this.m_InitTeamPanel[17] = this.panelInitTeam18;
      this.m_InitTeamPanel[18] = this.panelInitTeam19;
      this.m_InitTeamPanel[19] = this.panelInitTeam20;
      this.m_InitTeamPanel[20] = this.panelInitTeam21;
      this.m_InitTeamPanel[21] = this.panelInitTeam22;
      this.m_InitTeamPanel[22] = this.panelInitTeam23;
      this.m_InitTeamPanel[23] = this.panelInitTeam24;
      this.m_InitTeamCombo[0] = this.comboInitTeam1;
      this.m_InitTeamCombo[1] = this.comboInitTeam2;
      this.m_InitTeamCombo[2] = this.comboInitTeam3;
      this.m_InitTeamCombo[3] = this.comboInitTeam4;
      this.m_InitTeamCombo[4] = this.comboInitTeam5;
      this.m_InitTeamCombo[5] = this.comboInitTeam6;
      this.m_InitTeamCombo[6] = this.comboInitTeam7;
      this.m_InitTeamCombo[7] = this.comboInitTeam8;
      this.m_InitTeamCombo[8] = this.comboInitTeam9;
      this.m_InitTeamCombo[9] = this.comboInitTeam10;
      this.m_InitTeamCombo[10] = this.comboInitTeam11;
      this.m_InitTeamCombo[11] = this.comboInitTeam12;
      this.m_InitTeamCombo[12] = this.comboInitTeam13;
      this.m_InitTeamCombo[13] = this.comboInitTeam14;
      this.m_InitTeamCombo[14] = this.comboInitTeam15;
      this.m_InitTeamCombo[15] = this.comboInitTeam16;
      this.m_InitTeamCombo[16] = this.comboInitTeam17;
      this.m_InitTeamCombo[17] = this.comboInitTeam18;
      this.m_InitTeamCombo[18] = this.comboInitTeam19;
      this.m_InitTeamCombo[19] = this.comboInitTeam20;
      this.m_InitTeamCombo[20] = this.comboInitTeam21;
      this.m_InitTeamCombo[21] = this.comboInitTeam22;
      this.m_InitTeamCombo[22] = this.comboInitTeam23;
      this.m_InitTeamCombo[23] = this.comboInitTeam24;
      for (int index = 0; index < this.m_InitTeamCombo.Length; ++index)
        this.m_InitTeamCombo[index].SelectedIndexChanged += new EventHandler(this.comboInitTeam_SelectedIndexChanged);
      for (int index = 0; index < 24; ++index)
        this.m_InitTeamPanel[index].Visible = false;
      this.viewer2DTrophy.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageTrophy);
      this.viewer2DTrophy.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteTrophy);
      this.viewer2DTrophy.ButtonStripVisible = true;
      this.viewer2DTrophy.RemoveButton = true;
      this.viewer2DTrophy256.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageTrophy256);
      this.viewer2DTrophy256.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteTrophy256);
      this.viewer2DTrophy256.ButtonStripVisible = true;
      this.viewer2DTrophy256.RemoveButton = true;
      this.viewer2DTrophy128.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageTrophySmall);
      this.viewer2DTrophy128.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteTrophySmall);
      this.viewer2DTrophy128.ButtonStripVisible = true;
      this.viewer2DTrophy128.RemoveButton = true;
      this.multiViewer2DTextures.Rx3ExportDelegate = new MultiViewer2D.Rx3ExportHandler(this.ExportRx3TrophyTextures);
      this.multiViewer2DTextures.Rx3ImportDelegate = new MultiViewer2D.Rx3ImportHandler(this.ImportRx3TrophyTextures);
      this.multiViewer2DTextures.Rx3SaveDelegate = new MultiViewer2D.Rx3SaveHandler(this.SaveRx3TrophyTextures);
    }

    public void Clean()
    {
      this.Visible = false;
    }

    private Trophy SelectTrophy(object sender, object obj)
    {
      Trophy trophy = (Trophy) obj;
      this.Refresh();
      this.LoadTrophy(trophy);
      return trophy;
    }

    private bool ImportImageTrophy(object sender, Bitmap bitmap)
    {
      return this.m_CurrentTrophy.SetTrophy(bitmap);
    }

    private bool DeleteTrophy(object sender)
    {
      return this.m_CurrentTrophy.DeleteTrophy();
    }

    private bool ImportImageTrophy256(object sender, Bitmap bitmap)
    {
      return this.m_CurrentTrophy.SetTrophy256(bitmap);
    }

    private bool DeleteTrophy256(object sender)
    {
      return this.m_CurrentTrophy.DeleteTrophy256();
    }

    private bool ImportImageTrophySmall(object sender, Bitmap bitmap)
    {
      return this.m_CurrentTrophy.SetTrophy128(bitmap);
    }

    private bool DeleteTrophySmall(object sender)
    {
      return this.m_CurrentTrophy.DeleteTrophy128();
    }

    private bool ExportRx3TrophyTextures(object sender, string exportDir)
    {
      return FifaEnvironment.ExportFileFromZdata(this.m_CurrentTrophy.TexturesFileName(), exportDir);
    }

    private bool SaveRx3TrophyTextures(object sender, Bitmap[] bitmaps)
    {
      bool flag = this.m_CurrentTrophy.SetTextures(bitmaps);
      if (flag)
        this.ReloadTrophy(this.m_CurrentTrophy);
      return flag;
    }

    private bool ImportRx3TrophyTextures(object sender, string rx3FileName)
    {
      bool flag = this.m_CurrentTrophy.SetTextures(rx3FileName);
      if (flag)
        this.ReloadTrophy(this.m_CurrentTrophy);
      return flag;
    }

    public void LoadCompetitions()
    {
      this.WorldStructureToPanel();
    }

    public void LoadTrophy(Trophy trophy)
    {
      if (!this.m_IsLoaded || this.m_CurrentTrophy == trophy)
        return;
      this.m_Locked = true;
      this.m_CurrentTrophy = trophy;
      this.m_Locked = false;
      this.TrophyToPanel();
    }

    public void Preset()
    {
      if (FifaEnvironment.Year == 14)
      {
        this.viewer2DTrophy128.Visible = true;
        this.viewer2DTrophy.Visible = false;
        this.buttonReplicateTrophy128.Visible = true;
        this.buttonReplicateTropy.Visible = false;
      }
      else
      {
        this.viewer2DTrophy128.Visible = false;
        this.viewer2DTrophy.Visible = true;
        this.buttonReplicateTrophy128.Visible = false;
        this.buttonReplicateTropy.Visible = true;
      }
      this.m_NewIdCreator.IdList = (IdArrayList) FifaEnvironment.CompetitionObjects.Trophies;
      Schedule.s_BaseDate = FifaEnvironment.Year != 14 ? new DateTime(2013, 12, 29, 0, 0, 0) : new DateTime(2012, 12, 30, 0, 0, 0);
      if (this.comboCountry.Items.Count != FifaEnvironment.Countries.Count)
      {
        this.comboCountry.Items.Clear();
        this.comboCountry.Items.AddRange(FifaEnvironment.Countries.ToArray());
      }
      if (this.comboPromotionLeague.Items.Count != FifaEnvironment.Leagues.Count + 1)
      {
        this.comboPromotionLeague.Items.Clear();
        this.comboPromotionLeague.Items.Add((object) "None");
        this.comboPromotionLeague.Items.AddRange(FifaEnvironment.Leagues.ToArray());
      }
      if (this.comboRelegationLeague.Items.Count != FifaEnvironment.Leagues.Count + 1)
      {
        this.comboRelegationLeague.Items.Clear();
        this.comboRelegationLeague.Items.Add((object) "None");
        this.comboRelegationLeague.Items.AddRange(FifaEnvironment.Leagues.ToArray());
      }
      if (this.comboTargetLeague.Items.Count != FifaEnvironment.Leagues.Count + 1)
      {
        this.comboTargetLeague.Items.Clear();
        this.comboTargetLeague.Items.Add((object) "None");
        this.comboTargetLeague.Items.AddRange(FifaEnvironment.Leagues.ToArray());
        this.comboTargetLeague.SelectedIndex = 0;
      }
      if (this.comboLeagueStats.Items.Count != FifaEnvironment.Leagues.Count + 1)
      {
        this.comboLeagueStats.Items.Clear();
        this.comboLeagueStats.Items.AddRange(FifaEnvironment.Leagues.ToArray());
      }
      if (this.comboSpecialTeam1.Items.Count != FifaEnvironment.Teams.Count + 1)
      {
        for (int index = 0; index < 4; ++index)
        {
          this.m_SpecialTeamCombos[index].Items.Clear();
          this.m_SpecialTeamCombos[index].Items.Add((object) "<None>");
          this.m_SpecialTeamCombos[index].Items.AddRange(FifaEnvironment.Teams.ToArray());
        }
      }
      if (this.comboStadium1.Items.Count != FifaEnvironment.Stadiums.Count)
      {
        for (int index = 0; index < 12; ++index)
        {
          this.m_StadiumCombos[index].Items.Clear();
          this.m_StadiumCombos[index].Items.Add((object) "<Auto>");
          this.m_StadiumCombos[index].Items.AddRange(FifaEnvironment.Stadiums.ToArray());
        }
      }
      if (this.comboSchedForce.Items.Count != FifaEnvironment.CompetitionObjects.Trophies.Count)
      {
        this.comboSchedForce.Items.Clear();
        this.comboSchedForce.Items.AddRange(FifaEnvironment.CompetitionObjects.Trophies.ToArray());
      }
      if (this.comboLanguageKey.Items.Count != CompobjList.s_Descriptions.Count)
      {
        this.comboLanguageKey.Items.Clear();
        this.comboLanguageKey.Items.AddRange(CompobjList.s_Descriptions.ToArray());
      }
      if (this.m_InitTeamCombo[0].Items.Count != FifaEnvironment.Teams.Count + 1)
      {
        for (int index = 0; index < this.m_InitTeamCombo.Length; ++index)
        {
          this.m_InitTeamCombo[index].Items.Clear();
          this.m_InitTeamCombo[index].Items.Add((object) "<Unknown>");
          this.m_InitTeamCombo[index].Items.AddRange(FifaEnvironment.Teams.ToArray());
        }
      }
      this.m_Competitions = FifaEnvironment.CompetitionObjects;
      this.m_CurrentWorld = this.m_Competitions.World;
      this.numericBall.Maximum = (Decimal) FifaEnvironment.FifaDb.Table[TI.teamballs].TableDescriptor.MaxValues[FI.teamballs_ballid];
    }

    private void CompetitionsForm_Load(object sender, EventArgs e)
    {
      this.m_IsLoaded = true;
      this.Preset();
      this.LoadCompetitions();
    }

    public void ReloadCompetitions()
    {
      this.Preset();
      this.CompetitionToPanel();
    }

    public void ReloadTrophy(Trophy trophy)
    {
      this.m_CurrentTrophy = (Trophy) null;
      this.LoadTrophy(trophy);
    }

    public void WorldStructureToPanel()
    {
      this.treeWorld.Nodes.Clear();
      TreeNode treeNode1 = this.treeWorld.Nodes.Add(this.m_CurrentWorld.ToString());
      treeNode1.Tag = (object) this.m_CurrentWorld;
      treeNode1.ForeColor = Color.Black;
      foreach (Trophy trophy in (ArrayList) this.m_CurrentWorld.Trophies)
      {
        TreeNode treeNode2 = treeNode1.Nodes.Add(trophy.ToString());
        treeNode2.Tag = (object) trophy;
        treeNode2.ForeColor = Color.DarkGreen;
        foreach (Stage stage in (ArrayList) trophy.Stages)
        {
          TreeNode treeNode3 = treeNode2.Nodes.Add(stage.ToString());
          treeNode3.Tag = (object) stage;
          treeNode3.ForeColor = Color.Magenta;
          foreach (Group group in (ArrayList) stage.Groups)
          {
            TreeNode treeNode4 = treeNode3.Nodes.Add(group.ToString());
            treeNode4.Tag = (object) group;
            treeNode4.ForeColor = Color.Brown;
          }
        }
      }
      foreach (Confederation confederation in (ArrayList) this.m_CurrentWorld.Confederations)
      {
        TreeNode treeNode2 = treeNode1.Nodes.Add(confederation.ToString());
        treeNode2.Tag = (object) confederation;
        treeNode2.ForeColor = Color.Red;
        foreach (Trophy trophy in (ArrayList) confederation.Trophies)
        {
          TreeNode treeNode3 = treeNode2.Nodes.Add(trophy.ToString());
          treeNode3.Tag = (object) trophy;
          treeNode3.ForeColor = Color.DarkGreen;
          foreach (Stage stage in (ArrayList) trophy.Stages)
          {
            TreeNode treeNode4 = treeNode3.Nodes.Add(stage.ToString());
            treeNode4.Tag = (object) stage;
            treeNode4.ForeColor = Color.Magenta;
            foreach (Group group1 in (ArrayList) stage.Groups)
            {
              TreeNode treeNode5 = treeNode4.Nodes.Add(group1.ToString());
              treeNode5.Tag = (object) group1;
              treeNode5.ForeColor = Color.Brown;
              foreach (Group group2 in (ArrayList) group1.Groups)
              {
                TreeNode treeNode6 = treeNode5.Nodes.Add(group2.ToString());
                treeNode6.Tag = (object) group2;
                treeNode6.ForeColor = Color.Brown;
              }
            }
          }
        }
        foreach (Nation nation in (ArrayList) confederation.Nations)
        {
          TreeNode treeNode3 = treeNode2.Nodes.Add(nation.ToString());
          treeNode3.Tag = (object) nation;
          treeNode3.ForeColor = Color.Blue;
          foreach (Trophy trophy in (ArrayList) nation.Trophies)
          {
            TreeNode treeNode4 = treeNode3.Nodes.Add(trophy.ToString());
            treeNode4.Tag = (object) trophy;
            treeNode4.ForeColor = Color.DarkGreen;
            foreach (Stage stage in (ArrayList) trophy.Stages)
            {
              TreeNode treeNode5 = treeNode4.Nodes.Add(stage.ToString());
              treeNode5.Tag = (object) stage;
              treeNode5.ForeColor = Color.Magenta;
              foreach (Group group1 in (ArrayList) stage.Groups)
              {
                TreeNode treeNode6 = treeNode5.Nodes.Add(group1.ToString());
                treeNode6.Tag = (object) group1;
                treeNode6.ForeColor = Color.Brown;
                foreach (Group group2 in (ArrayList) group1.Groups)
                {
                  TreeNode treeNode7 = treeNode6.Nodes.Add(group2.ToString());
                  treeNode7.Tag = (object) group2;
                  treeNode7.ForeColor = Color.Brown;
                }
              }
            }
          }
        }
      }
      this.treeWorld.SelectedNode = this.treeWorld.Nodes[0];
    }

    public void WorldToPanel()
    {
      this.m_LockToPanel = true;
      this.panelCompObj.Enabled = true;
      this.textUniqueId.Text = this.m_CurrentWorld.Id.ToString();
      this.textFourCharName.Text = this.m_CurrentWorld.TypeString;
      this.textLanguageKey.Text = this.m_CurrentWorld.Description;
      this.textLanguageName.Text = this.m_CurrentWorld.Description;
      this.textFourCharName.Enabled = false;
      this.textLanguageKey.Enabled = false;
      this.textLanguageName.Enabled = false;
      this.comboLanguageKey.Visible = false;
      this.numericStartYear.Value = (Decimal) this.m_CurrentWorld.Settings.m_schedule_year_start;
      this.m_LockToPanel = false;
    }

    public void ConfederationToPanel()
    {
      if (this.m_CurrentConfederation == null)
      {
        this.panelCompObj.Enabled = false;
        this.groupConfederation.Visible = false;
      }
      else
      {
        this.m_LockToPanel = true;
        this.groupConfederation.Visible = true;
        this.panelCompObj.Enabled = true;
        this.textUniqueId.Text = this.m_CurrentConfederation.Id.ToString();
        this.textFourCharName.Text = this.m_CurrentConfederation.TypeString;
        this.textLanguageKey.Text = this.m_CurrentConfederation.Description;
        this.textLanguageName.Text = string.Empty;
        this.textFourCharName.Enabled = false;
        this.textLanguageKey.Enabled = false;
        this.textLanguageName.Enabled = false;
        this.comboLanguageKey.Visible = false;
        this.groupConfederation.Text = "Confederation: " + this.m_CurrentConfederation.ToString();
        this.comboConfederationStartingMonth.Text = this.m_CurrentConfederation.Settings.GetProperty("schedule_seasonstartmonth", 0, out bool _);
        this.m_LockToPanel = false;
      }
    }

    public void NationToPanel()
    {
      if (this.m_CurrentNation == null)
      {
        this.panelCompObj.Enabled = false;
        this.groupNation.Visible = false;
      }
      else
      {
        this.m_LockToPanel = true;
        this.groupNation.Visible = true;
        this.panelCompObj.Enabled = true;
        this.textUniqueId.Text = this.m_CurrentNation.Id.ToString();
        this.textFourCharName.Text = this.m_CurrentNation.TypeString;
        this.textLanguageKey.Text = this.m_CurrentNation.Description;
        if (this.m_CurrentNation.Country != null)
          this.textLanguageName.Text = this.m_CurrentNation.Country.LanguageName;
        else
          this.textLanguageName.Text = (string) null;
        this.textFourCharName.Enabled = true;
        this.textLanguageKey.Enabled = false;
        this.textLanguageName.Enabled = false;
        this.comboLanguageKey.Visible = false;
        this.groupNation.Text = "Nation: " + this.m_CurrentNation.ToString();
        this.comboCountry.SelectedItem = (object) this.m_CurrentNation.Country;
        if (this.m_CurrentNation.Country == null)
          this.comboCountry.Text = string.Empty;
        this.comboNationStartMonth.Visible = true;
        bool isSpecific;
        this.comboNationStartMonth.Text = this.m_CurrentNation.Settings.GetProperty("schedule_seasonstartmonth", 0, out isSpecific);
        this.numericNationYellowsStored.Visible = true;
        this.numericNationYellowsStored.Value = (Decimal) Convert.ToInt32(this.m_CurrentNation.Settings.GetProperty("rule_numyellowstored", 0, out isSpecific));
        isSpecific = this.m_CurrentNation.Settings.m_StandingsSort >= 0;
        this.comboNationStandingsRules.Visible = isSpecific;
        if (isSpecific)
          this.comboNationStandingsRules.SelectedIndex = this.m_CurrentNation.Settings.m_StandingsSort;
        this.checkNationStandingsRules.Checked = isSpecific;
        for (int index = 0; index < 12; ++index)
        {
          this.m_RainProb[index].Value = (Decimal) this.m_CurrentNation.RainProb[index];
          this.m_SnowProb[index].Value = (Decimal) this.m_CurrentNation.SnowProb[index];
          this.m_OvercastProb[index].Value = (Decimal) this.m_CurrentNation.OvercastProb[index];
          switch (this.m_CurrentNation.SunsetTime[index])
          {
            case 1630:
              this.m_SunsetTime[index].SelectedIndex = 1;
              break;
            case 1700:
              this.m_SunsetTime[index].SelectedIndex = 2;
              break;
            case 1730:
              this.m_SunsetTime[index].SelectedIndex = 3;
              break;
            case 1800:
              this.m_SunsetTime[index].SelectedIndex = 4;
              break;
            case 1830:
              this.m_SunsetTime[index].SelectedIndex = 5;
              break;
            case 1900:
              this.m_SunsetTime[index].SelectedIndex = 6;
              break;
            case 1930:
              this.m_SunsetTime[index].SelectedIndex = 7;
              break;
            case 2000:
              this.m_SunsetTime[index].SelectedIndex = 8;
              break;
            case 2030:
              this.m_SunsetTime[index].SelectedIndex = 9;
              break;
            case 2100:
              this.m_SunsetTime[index].SelectedIndex = 10;
              break;
            default:
              this.m_SunsetTime[index].SelectedIndex = 0;
              break;
          }
          switch (this.m_CurrentNation.DarkTime[index])
          {
            case 1600:
              this.m_NightTime[index].SelectedIndex = 0;
              break;
            case 1630:
              this.m_NightTime[index].SelectedIndex = 1;
              break;
            case 1700:
              this.m_NightTime[index].SelectedIndex = 2;
              break;
            case 1730:
              this.m_NightTime[index].SelectedIndex = 3;
              break;
            case 1800:
              this.m_NightTime[index].SelectedIndex = 4;
              break;
            case 1830:
              this.m_NightTime[index].SelectedIndex = 5;
              break;
            case 1900:
              this.m_NightTime[index].SelectedIndex = 6;
              break;
            case 1930:
              this.m_NightTime[index].SelectedIndex = 7;
              break;
            case 2000:
              this.m_NightTime[index].SelectedIndex = 8;
              break;
            case 2030:
              this.m_NightTime[index].SelectedIndex = 9;
              break;
            case 2100:
              this.m_NightTime[index].SelectedIndex = 10;
              break;
          }
        }
        this.m_LockToPanel = false;
      }
    }

    public void StageToPanel()
    {
      if (this.m_CurrentStage == null)
      {
        this.panelCompObj.Enabled = false;
        this.groupStage.Visible = false;
      }
      else
      {
        this.m_LockToPanel = true;
        this.groupStage.Visible = true;
        this.panelCompObj.Enabled = true;
        this.textUniqueId.Text = this.m_CurrentStage.Id.ToString();
        this.textFourCharName.Text = this.m_CurrentStage.TypeString;
        this.textLanguageKey.Text = this.m_CurrentStage.Description;
        this.textLanguageName.Text = this.m_CurrentStage.GetLanguageName();
        this.comboLanguageKey.SelectedItem = (object) this.m_CurrentStage.Description;
        this.textFourCharName.Enabled = true;
        this.textLanguageKey.Enabled = true;
        this.textLanguageName.Enabled = true;
        this.comboLanguageKey.Visible = true;
        this.comboStageType.Text = this.m_CurrentStage.Settings.m_match_stagetype;
        bool flag1 = this.m_CurrentStage.Settings.m_StandingsSort >= 0;
        this.comboStageStandingRules.Visible = flag1;
        if (flag1)
          this.comboStageStandingRules.SelectedIndex = this.m_CurrentStage.Settings.m_StandingsSort;
        this.checkStageStandingsRules.Checked = flag1;
        if (this.m_CurrentStage.Settings.Advance_standingskeep != -1)
          this.numericStandingKeep.Value = (Decimal) this.m_CurrentStage.Settings.Advance_standingskeep;
        this.checkStandingKeep.Checked = this.m_CurrentStage.Settings.Advance_standingskeep != -1;
        this.numericStandingKeep.Visible = this.checkStandingKeep.Checked;
        if (this.m_CurrentStage.Settings.Advance_standingsrank != -1)
          this.numericStandingsRank.Value = (Decimal) this.m_CurrentStage.Settings.Advance_standingsrank;
        this.checkStandingsRank.Checked = this.m_CurrentStage.Settings.Advance_standingsrank != -1;
        this.numericStandingsRank.Visible = this.checkStandingsRank.Checked;
        if (this.m_CurrentStage.Settings.m_match_stagetype != "SETUP")
        {
          this.groupSetupStage.Visible = false;
          this.groupPlayStage.Visible = true;
          this.comboMatchSituation.Text = this.m_CurrentStage.Settings.m_match_matchsituation;
          this.checkMatchReplay.Checked = this.m_CurrentStage.Settings.m_schedule_matchreplay != -1;
          this.numericPrizeMoney.Value = (Decimal) this.m_CurrentStage.Settings.m_info_prize_money;
          this.numericMoneyDrop.Value = (Decimal) this.m_CurrentStage.Settings.m_info_prize_money_drop;
          this.checkMaxteamsgroup.Checked = this.m_CurrentStage.Settings.m_advance_maxteamsgroup != -1;
          this.numericStageRef.Visible = this.checkMaxteamsgroup.Checked;
          this.numericStageRef.Value = (Decimal) this.m_CurrentStage.Settings.Advance_maxteamsstageref;
          this.checkMaxteamsassoc.Checked = this.m_CurrentStage.Settings.m_advance_maxteamsassoc != -1;
          this.checkClausuraSchedule.Checked = this.m_CurrentStage.Settings.m_schedule_reversed != -1;
          this.checkRandomDrawEvent.Checked = this.m_CurrentStage.Settings.m_advance_random_draw_event != -1;
          bool flag2 = this.m_CurrentStage.Settings.m_EndRuleKo1Leg != -1;
          this.comboSpecialKo1Rule.Visible = flag2;
          if (flag2)
            this.comboSpecialKo1Rule.SelectedIndex = this.m_CurrentStage.Settings.m_EndRuleKo1Leg;
          this.checkSpecialKo1Rule.Checked = flag2;
          bool flag3 = this.m_CurrentStage.Settings.m_EndRuleKo2Leg2 != -1;
          this.comboSpecialKo2Rule.Visible = flag3;
          if (flag3)
            this.comboSpecialKo2Rule.SelectedIndex = this.m_CurrentStage.Settings.m_EndRuleKo2Leg2;
          this.checkSpecialKo2Rule.Checked = flag3;
          this.numericRegularSeason.Visible = this.m_CurrentStage.Settings.m_EndRuleKo2Leg2 == 3;
          if (this.numericRegularSeason.Visible)
            this.numericRegularSeason.Value = (Decimal) this.m_CurrentStage.Settings.Standings_checkrank;
          for (int index = 0; index < 12; ++index)
          {
            Stadium stadium = (Stadium) null;
            if (this.m_CurrentStage.Settings.m_match_stadium != null && this.m_CurrentStage.Settings.m_match_stadium[index] > 0)
            {
              stadium = (Stadium) FifaEnvironment.Stadiums.SearchId(this.m_CurrentStage.Settings.m_match_stadium[index]);
              if (stadium != null)
                this.m_StadiumCombos[index].SelectedItem = (object) stadium;
            }
            if (stadium == null)
              this.m_StadiumCombos[index].SelectedIndex = 0;
          }
          this.treeStageSchedule.Nodes.Clear();
          this.groupStageScheduleDetails.Visible = false;
          this.buttonStageAddTime.Enabled = false;
          this.buttonStageRemoveTime.Enabled = false;
          this.buttonDeleteStageLeg.Enabled = false;
          for (int legId = 1; legId < 46; ++legId)
          {
            Schedule[] legSchedule = this.m_CurrentStage.GetLegSchedule(legId);
            if (legSchedule != null)
            {
              TreeNode treeNode = this.treeStageSchedule.Nodes.Add("Leg " + legId.ToString());
              treeNode.ForeColor = Color.DarkGreen;
              for (int index = 0; index < legSchedule.Length; ++index)
                treeNode.Nodes.Add(legSchedule[index].Date.ToString("f")).Tag = (object) legSchedule[index];
            }
            else
              break;
          }
        }
        else
        {
          this.groupSetupStage.Visible = true;
          this.groupPlayStage.Visible = false;
          this.checkRandomDraw.Checked = this.m_CurrentStage.Settings.m_advance_randomdraw != -1;
          this.checkCalccompavgs.Checked = this.m_CurrentStage.Settings.m_advance_calccompavgs != -1;
          for (int index = 0; index < 4; ++index)
          {
            Team team = (Team) null;
            if (this.m_CurrentStage.Settings.m_info_special_team_id[index] != 0)
            {
              team = (Team) FifaEnvironment.Teams.SearchId(this.m_CurrentStage.Settings.m_info_special_team_id[index]);
              if (team != null)
                this.m_SpecialTeamCombos[index].SelectedItem = (object) team;
            }
            if (team == null)
              this.m_SpecialTeamCombos[index].SelectedIndex = 0;
          }
        }
        this.checkKeepPointsPercentage.Checked = this.m_CurrentStage.Settings.Advance_pointskeep != -1;
        this.numericKeepPointsPercentage.Visible = this.checkKeepPointsPercentage.Checked;
        this.numericKeepPointsStageRef.Visible = this.checkKeepPointsPercentage.Checked;
        if (this.m_CurrentStage.Settings.m_advance_pointskeeppercentage != -1)
          this.numericKeepPointsPercentage.Value = (Decimal) this.m_CurrentStage.Settings.m_advance_pointskeeppercentage;
        if (this.m_CurrentStage.Settings.Advance_pointskeep != -1)
          this.numericKeepPointsStageRef.Value = (Decimal) this.m_CurrentStage.Settings.Advance_pointskeep;
        this.groupLeaguetasks.Visible = this.m_CurrentStage.Settings.m_match_matchsituation == "LEAGUE";
        if (this.m_CurrentStage.Settings.m_match_matchsituation == "LEAGUE")
        {
          Task task1 = this.m_CurrentStage.SearchTask("start", "ClearLeagueStats", -1, -1, -1);
          League league = (League) null;
          this.checkClearLeagueStats.Checked = task1 != null;
          if (task1 != null)
            league = task1.League;
          Task task2 = this.m_CurrentStage.SearchTask("end", "UpdateLeagueStats", -1, -1, -1);
          this.checkUpdateLeagueStats.Checked = task2 != null;
          if (task2 != null)
            league = task2.League;
          Task task3 = this.m_CurrentStage.SearchTask("end", "UpdateLeagueTable", -1, -1, -1);
          this.checkUpdateLeagueTable.Checked = task3 != null;
          if (task3 != null)
            league = task3.League;
          if (league != null)
            this.comboLeagueStats.SelectedItem = (object) league;
        }
        this.m_LockToPanel = false;
      }
    }

    public void GroupToPanel()
    {
      if (this.m_CurrentGroup == null)
      {
        this.panelCompObj.Enabled = false;
        this.groupGroup.Visible = false;
      }
      else
      {
        this.m_LockToPanel = true;
        this.groupGroup.Visible = true;
        this.panelCompObj.Enabled = true;
        this.textUniqueId.Text = this.m_CurrentGroup.Id.ToString();
        this.textFourCharName.Text = this.m_CurrentGroup.TypeString;
        this.textLanguageKey.Text = this.m_CurrentGroup.Description;
        this.textLanguageName.Text = this.m_CurrentGroup.LanguageName;
        this.textFourCharName.Enabled = true;
        this.textLanguageKey.Enabled = true;
        this.textLanguageName.Enabled = true;
        this.comboLanguageKey.Visible = false;
        this.numericNTeams.Value = (Decimal) (this.m_CurrentGroup.Ranks.Count - 1);
        Stage parentStage = this.m_CurrentGroup.ParentStage;
        Trophy trophy = parentStage.Trophy;
        int index1 = 0;
        if (parentStage.TypeString == "S1")
        {
          this.panelQualificationRules.Visible = true;
          this.panelAdvancement.Visible = false;
          this.groupRules.Text = "Qualification Rules";
          for (int index2 = 0; index2 < this.m_CurrentGroup.m_NStartTasks; ++index2)
          {
            this.m_QRLabels[index1].Text = this.m_CurrentGroup.m_StartTask[index2].ToString();
            this.m_QRLabels[index1].Tag = (object) this.m_CurrentGroup.m_StartTask[index2];
            this.m_QRLabels[index1].Enabled = true;
            ++index1;
          }
          for (; index1 < this.m_QRLabels.Length; ++index1)
          {
            this.m_QRLabels[index1].Enabled = false;
            this.m_QRLabels[index1].Text = string.Empty;
          }
        }
        else
        {
          this.panelQualificationRules.Visible = false;
          this.panelAdvancement.Visible = true;
          this.groupRules.Text = "Advancement Rules";
          for (int index2 = 1; index2 < this.m_CurrentGroup.Ranks.Count; ++index2)
          {
            Rank rank = (Rank) this.m_CurrentGroup.Ranks[index2];
            this.m_AdvanceLabels[index2 - 1].Text = rank.GetFromRankString();
            this.m_AdvanceLabels[index2 - 1].Visible = true;
            this.m_AdvanceLabels[index2 - 1].Tag = (object) rank;
          }
          for (int index2 = this.m_CurrentGroup.Ranks.Count - 1; index2 < this.m_AdvanceLabels.Length; ++index2)
            this.m_AdvanceLabels[index2].Visible = false;
        }
        if (parentStage.Settings.m_match_stagetype == "LEAGUE")
        {
          this.groupInfoColors.Visible = true;
          this.checkInfoColorChamp.Checked = this.m_CurrentGroup.Settings.m_info_color_slot_champ == 1;
          int min;
          int max;
          this.m_CurrentGroup.Settings.GetInfoColorSlotChampCup(out min, out max);
          if (min == -1 || max == -1)
          {
            this.checkInfoColorChampions.Checked = false;
            this.numericColorChampionsMin.Visible = false;
            this.numericColorChampionsMax.Visible = false;
          }
          else
          {
            this.checkInfoColorChampions.Checked = true;
            this.numericColorChampionsMin.Visible = true;
            this.numericColorChampionsMax.Visible = true;
            this.numericColorChampionsMin.Value = (Decimal) min;
            this.numericColorChampionsMax.Value = (Decimal) max;
          }
          this.m_CurrentGroup.Settings.GetInfoColorSlotEuroLeague(out min, out max);
          if (min == -1 || max == -1)
          {
            this.checkInfoColorEuropa.Checked = false;
            this.numericColorEuropaMin.Visible = false;
            this.numericColorEuropaMax.Visible = false;
          }
          else
          {
            this.checkInfoColorEuropa.Checked = true;
            this.numericColorEuropaMin.Visible = true;
            this.numericColorEuropaMax.Visible = true;
            this.numericColorEuropaMin.Value = (Decimal) min;
            this.numericColorEuropaMax.Value = (Decimal) max;
          }
          this.m_CurrentGroup.Settings.GetInfoColorSlotReleg(out min, out max);
          if (min == -1 || max == -1)
          {
            this.checkInfoColorRelegation.Checked = false;
            this.numericColorRelegationMin.Visible = false;
            this.numericColorRelegationMax.Visible = false;
          }
          else
          {
            this.checkInfoColorRelegation.Checked = true;
            this.numericColorRelegationMin.Visible = true;
            this.numericColorRelegationMax.Visible = true;
            this.numericColorRelegationMin.Value = (Decimal) min;
            this.numericColorRelegationMax.Value = (Decimal) max;
          }
          this.m_CurrentGroup.Settings.GetInfoColorSlotRelegPoss(out min, out max);
          if (min == -1 || max == -1)
          {
            this.checkInfoColorPossibleRelegation.Checked = false;
            this.numericColorPossibleRelegationMin.Visible = false;
            this.numericColorPossibleRelegationMax.Visible = false;
          }
          else
          {
            this.checkInfoColorPossibleRelegation.Checked = true;
            this.numericColorPossibleRelegationMin.Visible = true;
            this.numericColorPossibleRelegationMax.Visible = true;
            this.numericColorPossibleRelegationMin.Value = (Decimal) min;
            this.numericColorPossibleRelegationMax.Value = (Decimal) max;
          }
          this.m_CurrentGroup.Settings.GetInfoColorSlotPromo(out min, out max);
          if (min == -1 || max == -1)
          {
            this.checkInfoColorPromotion.Checked = false;
            this.numericColorPromotionMin.Visible = false;
            this.numericColorPromotionMax.Visible = false;
          }
          else
          {
            this.checkInfoColorPromotion.Checked = true;
            this.numericColorPromotionMin.Visible = true;
            this.numericColorPromotionMax.Visible = true;
            this.numericColorPromotionMin.Value = (Decimal) min;
            this.numericColorPromotionMax.Value = (Decimal) max;
          }
          this.m_CurrentGroup.Settings.GetInfoColorSlotPromoPoss(out min, out max);
          if (min == -1 || max == -1)
          {
            this.checkInfoColorPossiblePromotion.Checked = false;
            this.numericColorPossiblePromotionMin.Visible = false;
            this.numericColorPossiblePromotionMax.Visible = false;
          }
          else
          {
            this.checkInfoColorPossiblePromotion.Checked = true;
            this.numericColorPossiblePromotionMin.Visible = true;
            this.numericColorPossiblePromotionMax.Visible = true;
            this.numericColorPossiblePromotionMin.Value = (Decimal) min;
            this.numericColorPossiblePromotionMax.Value = (Decimal) max;
          }
          this.m_CurrentGroup.Settings.GetInfoColorSlotAdvGroup(out min, out max);
          if (min == -1 || max == -1)
          {
            this.checkInfoColorAdvance.Checked = false;
            this.numericColorAdvanceMin.Visible = false;
            this.numericColorAdvanceMax.Visible = false;
          }
          else
          {
            this.checkInfoColorAdvance.Checked = true;
            this.numericColorAdvanceMin.Visible = true;
            this.numericColorAdvanceMax.Visible = true;
            this.numericColorAdvanceMin.Value = (Decimal) min;
            this.numericColorAdvanceMax.Value = (Decimal) max;
          }
        }
        else
          this.groupInfoColors.Visible = false;
        if (parentStage.Settings.m_match_stagetype == "SETUP")
        {
          this.groupPlayGroup.Visible = false;
          this.groupSlots.Visible = false;
          this.groupGroupScheduke.Visible = false;
        }
        else
        {
          this.groupPlayGroup.Visible = true;
          this.groupGroupScheduke.Visible = true;
          if (this.m_CurrentGroup.Settings.m_num_games <= 0)
            this.m_CurrentGroup.Settings.m_num_games = 1;
          this.numericNumGames.Value = (Decimal) this.m_CurrentGroup.Settings.m_num_games;
          this.treeGroupSchedule.Nodes.Clear();
          this.groupGroupScheduleDetails.Visible = false;
          this.buttonGroupAddTime.Enabled = false;
          this.buttonGroupRemoveTime.Enabled = false;
          this.buttonRemoveGroupLeg.Enabled = false;
          for (int legId = 1; legId < 46; ++legId)
          {
            Schedule[] legSchedule = this.m_CurrentGroup.GetLegSchedule(legId);
            if (legSchedule != null)
            {
              TreeNode treeNode = this.treeGroupSchedule.Nodes.Add("Leg " + legId.ToString());
              treeNode.ForeColor = Color.DarkGreen;
              for (int index2 = 0; index2 < legSchedule.Length; ++index2)
                treeNode.Nodes.Add(legSchedule[index2].Date.ToString("f")).Tag = (object) legSchedule[index2];
            }
          }
          this.groupSlots.Visible = true;
          this.checkInfoChamp.Checked = this.m_CurrentGroup.Settings.m_info_slot_champ == 1;
          int min;
          int max;
          this.m_CurrentGroup.Settings.GetInfoSlotReleg(out min, out max);
          if (min == -1 || max == -1)
          {
            this.checkInfoRelegation.Checked = false;
            this.numericRelegationMin.Visible = false;
            this.numericRelegationMax.Visible = false;
          }
          else
          {
            this.checkInfoRelegation.Checked = true;
            this.numericRelegationMin.Visible = true;
            this.numericRelegationMax.Visible = true;
            this.numericRelegationMin.Value = (Decimal) min;
            this.numericRelegationMax.Value = (Decimal) max;
          }
          this.m_CurrentGroup.Settings.GetInfoSlotRelegPoss(out min, out max);
          if (min == -1 || max == -1)
          {
            this.checkInfoPossibleRelegation.Checked = false;
            this.numericPossibleRelegationMin.Visible = false;
            this.numericPossibleRelegationMax.Visible = false;
          }
          else
          {
            this.checkInfoPossibleRelegation.Checked = true;
            this.numericPossibleRelegationMin.Visible = true;
            this.numericPossibleRelegationMax.Visible = true;
            this.numericPossibleRelegationMin.Value = (Decimal) min;
            this.numericPossibleRelegationMax.Value = (Decimal) max;
          }
          this.m_CurrentGroup.Settings.GetInfoSlotPromo(out min, out max);
          if (min == -1 || max == -1)
          {
            this.checkInfoPromotion.Checked = false;
            this.numericPromotionMin.Visible = false;
            this.numericPromotionMax.Visible = false;
          }
          else
          {
            this.checkInfoPromotion.Checked = true;
            this.numericPromotionMin.Visible = true;
            this.numericPromotionMax.Visible = true;
            this.numericPromotionMin.Value = (Decimal) min;
            this.numericPromotionMax.Value = (Decimal) max;
          }
          this.m_CurrentGroup.Settings.GetInfoSlotPromoPoss(out min, out max);
          if (min == -1 || max == -1)
          {
            this.checkInfoPossiblePromotion.Checked = false;
            this.numericPossiblePromotionMin.Visible = false;
            this.numericPossiblePromotionMax.Visible = false;
          }
          else
          {
            this.checkInfoPossiblePromotion.Checked = true;
            this.numericPossiblePromotionMin.Visible = true;
            this.numericPossiblePromotionMax.Visible = true;
            this.numericPossiblePromotionMin.Value = (Decimal) min;
            this.numericPossiblePromotionMax.Value = (Decimal) max;
          }
        }
        this.m_LockToPanel = false;
      }
    }

    public void TrophyStructureToPanel()
    {
      if (this.m_CurrentTrophy == null)
      {
        this.groupTrophy.Visible = false;
      }
      else
      {
        this.groupTrophy.Visible = true;
        this.groupTrophy.Text = this.m_CurrentTrophy.ShortName;
        this.textTrophyLongName.Text = this.m_CurrentTrophy.LongName;
        this.textTrophyShortName.Text = this.m_CurrentTrophy.ShortName;
        this.numericAssetId.Value = (Decimal) this.m_CurrentTrophy.Settings.m_asset_id;
        this.numericBall.Value = (Decimal) this.m_CurrentTrophy.ballid;
        this.comboCompetitionType.SelectedItem = (object) this.m_CurrentTrophy.Settings.m_comp_type;
        this.checkScheduleConflicts.Checked = this.m_CurrentTrophy.Settings.m_schedule_checkconflict == 1;
        bool flag1 = this.m_CurrentTrophy.Settings.TrophyForcecomp != null;
        this.comboSchedForce.Visible = flag1;
        if (flag1)
          this.comboSchedForce.SelectedItem = (object) this.m_CurrentTrophy.Settings.TrophyForcecomp;
        this.checkForceSchedule.Checked = flag1;
        this.checkScheduleUseDates.Checked = this.m_CurrentTrophy.Settings.m_schedule_use_dates_comp != -1;
        if (this.m_CurrentTrophy.Settings.m_match_matchimportance == -1)
          this.m_CurrentTrophy.Settings.m_match_matchimportance = 25;
        this.numericImportance.Value = (Decimal) this.m_CurrentTrophy.Settings.m_match_matchimportance;
        bool flag2 = this.m_CurrentTrophy.Settings.LeaguePromo != null;
        this.comboPromotionLeague.Visible = flag2;
        if (flag2)
          this.comboPromotionLeague.SelectedItem = (object) this.m_CurrentTrophy.Settings.LeaguePromo;
        this.checkPromotionLeague.Checked = flag2;
        bool flag3 = this.m_CurrentTrophy.Settings.LeagueReleg != null;
        this.comboRelegationLeague.Visible = flag3;
        if (flag3)
          this.comboRelegationLeague.SelectedItem = (object) this.m_CurrentTrophy.Settings.LeagueReleg;
        this.checkRelegationLeague.Checked = flag3;
        bool flag4 = this.m_CurrentTrophy.Settings.m_rule_numsubsbench != -1;
        this.radioBench5Players.Checked = flag4;
        this.radioBench7Players.Checked = !flag4;
        bool isSpecific = this.m_CurrentTrophy.Settings.m_StandingsSort >= 0;
        this.comboTrophyStandingRules.Visible = isSpecific;
        if (isSpecific)
          this.comboTrophyStandingRules.SelectedIndex = this.m_CurrentTrophy.Settings.m_StandingsSort;
        this.checkTrophyStandingsRules.Checked = isSpecific;
        if (this.m_CurrentTrophy.Settings.m_comp_type == "INTERCUP" || this.m_CurrentTrophy.Settings.m_comp_type == "INTERQUAL")
        {
          this.groupInternationalschedule.Visible = true;
          this.numericInternationalFirstYear.Value = (Decimal) this.m_CurrentTrophy.Settings.m_schedule_year_start;
          this.numericInternationalPeriodicity.Value = (Decimal) this.m_CurrentTrophy.Settings.m_schedule_year_offset;
          this.comboNationStartMonth.Visible = true;
          this.comboTrophyStartMonth.Text = this.m_CurrentTrophy.Settings.GetProperty("schedule_seasonstartmonth", 0, out isSpecific);
        }
        else
          this.groupInternationalschedule.Visible = false;
      }
    }

    public void TrophyGraphicsToPanel()
    {
      this.viewer2DTrophy256.CurrentBitmap = this.m_CurrentTrophy.GetTrophy256();
      if (FifaEnvironment.Year == 14)
        this.viewer2DTrophy128.CurrentBitmap = this.m_CurrentTrophy.GetTrophy128();
      else
        this.viewer2DTrophy.CurrentBitmap = this.m_CurrentTrophy.GetTrophy();
      this.multiViewer2DTextures.Bitmaps = this.m_CurrentTrophy.GetTextures();
      this.Show3DTrophy();
    }

    public void TrophyRankingToPanel()
    {
      this.m_NUpdateTableLabels = 0;
      for (int index = 0; index < 24; ++index)
      {
        Task task = this.m_CurrentTrophy.SearchTask("end", "UpdateTable", -1, -1, index + 1);
        if (task != null)
        {
          this.m_UpdateTableLabels[index].Text = task.ToString();
          this.m_UpdateTableLabels[index].Tag = (object) task;
          ++this.m_NUpdateTableLabels;
        }
        else
          break;
      }
      this.numericUpdateTableEntries.Value = (Decimal) this.m_NUpdateTableLabels;
      for (int index = 0; index < 24; ++index)
        this.m_InitTeamPanel[index].Visible = index < this.m_NUpdateTableLabels;
      for (int index = 0; index < this.m_NUpdateTableLabels; ++index)
      {
        InitTeam initTeam = this.m_CurrentTrophy.InitTeamArray[index];
        Team team = (Team) null;
        if (initTeam != null)
          team = initTeam.Team;
        if (team != null)
          this.m_InitTeamCombo[index].SelectedItem = (object) initTeam.Team;
        else
          this.m_InitTeamCombo[index].SelectedIndex = 0;
      }
    }

    public void TrophyToPanel()
    {
      if (this.m_CurrentTrophy == null)
      {
        this.panelCompObj.Enabled = false;
        this.groupTrophy.Visible = false;
        this.groupGraphics.Visible = false;
        this.groupInitTeams.Visible = false;
      }
      else
      {
        this.m_LockToPanel = true;
        this.panelCompObj.Enabled = true;
        this.groupTrophy.Visible = true;
        this.groupGraphics.Visible = true;
        this.groupInitTeams.Visible = true;
        this.textUniqueId.Text = this.m_CurrentTrophy.Id.ToString();
        this.textFourCharName.Text = this.m_CurrentTrophy.TypeString;
        this.textLanguageKey.Text = this.m_CurrentTrophy.Description;
        this.textLanguageName.Text = this.m_CurrentTrophy.ShortName;
        this.textFourCharName.Enabled = true;
        this.textLanguageKey.Enabled = false;
        this.textLanguageName.Enabled = false;
        this.comboLanguageKey.Visible = false;
        if (this.tabTrophy.SelectedIndex == 0)
          this.TrophyStructureToPanel();
        else if (this.tabTrophy.SelectedIndex == 1)
          this.TrophyRankingToPanel();
        else if (this.tabTrophy.SelectedIndex == 2)
          this.TrophyGraphicsToPanel();
        this.m_LockToPanel = false;
      }
    }

    public void Show3DTrophy()
    {
      if (!this.buttonShow3DModel.Checked)
      {
        this.viewer3D.ShowEmpty();
      }
      else
      {
        Bitmap[] textures = this.m_CurrentTrophy.GetTextures();
        Bitmap textureBitmap = (Bitmap) null;
        if (textures != null)
          textureBitmap = GraphicUtil.EmbossBitmap(textures[0], textures[1]);
        Rx3File model = this.m_CurrentTrophy.GetModel();
        if (textureBitmap == null || model == null)
        {
          this.viewer3D.Clean(1);
        }
        else
        {
          Rx3IndexArray.TriangleListType = Rx3IndexArray.ETriangleListType.InvertEven;
          this.viewer3D.Clean(model.Rx3VertexArrays.Length);
          for (int meshIndex = 0; meshIndex < model.Rx3VertexArrays.Length; ++meshIndex)
          {
            Model3D model3D = new Model3D(model.Rx3IndexArrays[meshIndex], model.Rx3VertexArrays[meshIndex], textureBitmap);
            this.viewer3D.SetMesh(meshIndex, model3D);
          }
          this.viewer3D.Render();
        }
      }
    }

    private void treeWorld_AfterSelect(object sender, TreeViewEventArgs e)
    {
      if (this.treeWorld.SelectedNode == null)
        return;
      this.m_CurrentCompobj = (Compobj) this.treeWorld.SelectedNode.Tag;
      if (!this.m_LockTree)
      {
        this.m_LockTree = true;
        if (this.m_CurrentCompobj.IsGroup())
        {
          this.m_CurrentGroup = (Group) this.treeWorld.SelectedNode.Tag;
          this.m_CurrentStage = this.m_CurrentGroup.ParentStage;
          this.m_CurrentTrophy = this.m_CurrentStage.Trophy;
          this.m_CurrentNation = this.m_CurrentTrophy.Nation;
          this.m_CurrentConfederation = this.m_CurrentNation == null ? this.m_CurrentTrophy.Confederation : this.m_CurrentNation.Confederation;
          if (this.tabCompetitions.SelectedTab == this.pageGroup)
            this.GroupToPanel();
          this.tabCompetitions.SelectedTab = this.pageGroup;
          this.treeWorld.Select();
        }
        else if (this.m_CurrentCompobj.IsStage())
        {
          this.m_CurrentStage = (Stage) this.treeWorld.SelectedNode.Tag;
          this.m_CurrentGroup = (Group) null;
          this.m_CurrentTrophy = this.m_CurrentStage.Trophy;
          this.m_CurrentNation = this.m_CurrentTrophy.Nation;
          this.m_CurrentConfederation = this.m_CurrentNation == null ? this.m_CurrentTrophy.Confederation : this.m_CurrentNation.Confederation;
          if (this.tabCompetitions.SelectedTab == this.pageStage)
            this.StageToPanel();
          this.tabCompetitions.SelectedTab = this.pageStage;
          this.treeWorld.Select();
        }
        else if (this.m_CurrentCompobj.IsTrophy())
        {
          this.m_CurrentTrophy = (Trophy) this.treeWorld.SelectedNode.Tag;
          this.m_CurrentStage = (Stage) null;
          this.m_CurrentGroup = (Group) null;
          this.m_CurrentNation = this.m_CurrentTrophy.Nation;
          this.m_CurrentConfederation = this.m_CurrentNation == null ? this.m_CurrentTrophy.Confederation : this.m_CurrentNation.Confederation;
          if (this.tabCompetitions.SelectedTab == this.pageTrophy)
            this.TrophyToPanel();
          this.tabCompetitions.SelectedTab = this.pageTrophy;
          this.treeWorld.Select();
        }
        else if (this.m_CurrentCompobj.IsNation())
        {
          this.m_CurrentNation = (Nation) this.treeWorld.SelectedNode.Tag;
          this.m_CurrentTrophy = (Trophy) null;
          this.m_CurrentStage = (Stage) null;
          this.m_CurrentGroup = (Group) null;
          this.m_CurrentConfederation = this.m_CurrentNation.Confederation;
          if (this.tabCompetitions.SelectedTab == this.pageNation)
            this.NationToPanel();
          this.tabCompetitions.SelectedTab = this.pageNation;
          this.treeWorld.Select();
        }
        else if (this.m_CurrentCompobj.IsConfederation())
        {
          this.m_CurrentConfederation = (Confederation) this.treeWorld.SelectedNode.Tag;
          this.m_CurrentNation = (Nation) null;
          this.m_CurrentTrophy = (Trophy) null;
          this.m_CurrentStage = (Stage) null;
          this.m_CurrentGroup = (Group) null;
          if (this.tabCompetitions.SelectedTab == this.pageConfederation)
            this.ConfederationToPanel();
          this.tabCompetitions.SelectedTab = this.pageConfederation;
          this.treeWorld.Select();
        }
        else if (this.m_CurrentCompobj.IsWorld())
        {
          this.m_CurrentConfederation = (Confederation) null;
          this.m_CurrentNation = (Nation) null;
          this.m_CurrentTrophy = (Trophy) null;
          this.m_CurrentStage = (Stage) null;
          this.m_CurrentGroup = (Group) null;
          if (this.tabCompetitions.SelectedTab == this.pageWorld)
            this.WorldToPanel();
          this.tabCompetitions.SelectedTab = this.pageWorld;
          this.treeWorld.Select();
        }
        this.m_LockTree = false;
      }
      this.EnableToolWorld();
    }

    private void comboConfederationStartingMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.comboConfederationStartingMonth.SelectedItem == null)
        return;
      this.m_CurrentConfederation.Settings.m_schedule_seasonstartmonth = (string) this.comboConfederationStartingMonth.SelectedItem;
    }

    private void comboNationStartMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.comboNationStartMonth.SelectedItem == null)
        return;
      this.m_CurrentNation.Settings.m_schedule_seasonstartmonth = (string) this.comboNationStartMonth.SelectedItem;
    }

    private void numericYellowsStored_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentNation.Settings.m_rule_numyellowstored = (int) this.numericNationYellowsStored.Value;
    }

    private void checkNationStandingsRules_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.comboNationStandingsRules.Visible = this.checkNationStandingsRules.Checked;
      if (this.checkNationStandingsRules.Checked)
        this.m_CurrentNation.Settings.m_StandingsSort = this.comboNationStandingsRules.SelectedIndex;
      else
        this.m_CurrentNation.Settings.m_StandingsSort = -1;
    }

    private void comboNationStandingsRules_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentNation.Settings.m_StandingsSort = this.comboNationStandingsRules.SelectedIndex;
    }

    private void comboCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.comboCountry.SelectedItem == null)
        return;
      Country selectedItem = (Country) this.comboCountry.SelectedItem;
      if (this.m_CurrentNation.Country == selectedItem || selectedItem == null)
        return;
      this.m_CurrentNation.Country = selectedItem;
      this.m_CurrentNation.Description = FifaEnvironment.Language.GetCountryConventionalString(selectedItem.Id, Language.ECountryStringType.Full);
      this.NationToPanel();
    }

    private void textTrophyLongName_TextChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentTrophy.LongName = this.textTrophyLongName.Text;
      this.treeWorld.SelectedNode.Text = this.m_CurrentTrophy.ToString();
    }

    private void textTrophyShortName_TextChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentTrophy.ShortName = this.textTrophyShortName.Text;
      this.treeWorld.SelectedNode.Text = this.m_CurrentTrophy.ToString();
      this.textLanguageName.Text = this.m_CurrentTrophy.ShortName;
      this.m_CurrentTrophy.SetLanguageName(this.m_CurrentTrophy.ShortName);
    }

    private void buttonGetId_Click(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.numericAssetId.Value = (Decimal) Trophy.AutoAsset();
    }

    private void numericAssetId_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.m_Locked)
        return;
      int assetId = (int) this.numericAssetId.Value;
      if (assetId == this.m_CurrentTrophy.Settings.m_asset_id)
        return;
      this.m_Locked = true;
      foreach (Compobj competitionObject in (ArrayList) FifaEnvironment.CompetitionObjects)
      {
        if (competitionObject.IsTrophy() && competitionObject.Settings.m_asset_id == assetId)
        {
          int num = (int) FifaEnvironment.UserMessages.ShowMessage(1015);
          this.numericAssetId.Value = (Decimal) this.m_CurrentTrophy.Settings.m_asset_id;
          this.m_Locked = false;
          return;
        }
      }
      this.m_CurrentTrophy.Settings.m_asset_id = assetId;
      this.m_CurrentTrophy.Description = FifaEnvironment.Language.GetTournamentConventionalString(assetId, Language.ETournamentStringType.Abbr15);
      this.textLanguageKey.Text = this.m_CurrentTrophy.Description;
      this.textFourCharName.Text = "C" + this.m_CurrentTrophy.Settings.m_asset_id.ToString();
      this.TrophyGraphicsToPanel();
      this.m_Locked = false;
    }

    private void comboCompetitionType_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.m_CurrentTrophy.Settings.m_comp_type == (string) this.comboCompetitionType.SelectedItem)
        return;
      this.m_CurrentTrophy.Settings.m_comp_type = (string) this.comboCompetitionType.SelectedItem;
      this.TrophyToPanel();
    }

    private void numericImportance_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentTrophy.Settings.m_match_matchimportance = (int) this.numericImportance.Value;
    }

    private void comboPromotionLeague_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.comboPromotionLeague.SelectedIndex < 0)
        return;
      if (this.comboPromotionLeague.SelectedIndex == 0)
        this.m_CurrentTrophy.Settings.LeaguePromo = (League) null;
      else
        this.m_CurrentTrophy.Settings.LeaguePromo = (League) this.comboPromotionLeague.SelectedItem;
    }

    private void comboRelegationLeague_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.comboRelegationLeague.SelectedIndex < 0)
        return;
      if (this.comboRelegationLeague.SelectedIndex == 0)
        this.m_CurrentTrophy.Settings.LeagueReleg = (League) null;
      else
        this.m_CurrentTrophy.Settings.LeagueReleg = (League) this.comboRelegationLeague.SelectedItem;
    }

    private void checkForceSchedule_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.comboSchedForce.Visible = this.checkForceSchedule.Checked;
      if (this.checkForceSchedule.Checked)
      {
        if (this.comboSchedForce.SelectedItem == null)
          this.comboSchedForce.SelectedItem = this.comboSchedForce.Items[0];
        this.m_CurrentTrophy.Settings.TrophyForcecomp = (Trophy) this.comboSchedForce.SelectedItem;
      }
      else
        this.m_CurrentTrophy.Settings.TrophyForcecomp = (Trophy) null;
    }

    private void checkTrophyStandingsRules_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.comboTrophyStandingRules.Visible = this.checkTrophyStandingsRules.Checked;
      if (this.checkTrophyStandingsRules.Checked)
        this.m_CurrentTrophy.Settings.m_StandingsSort = this.comboTrophyStandingRules.SelectedIndex;
      else
        this.m_CurrentTrophy.Settings.m_StandingsSort = -1;
    }

    private void comboTrophyStandingRules_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.comboTrophyStandingRules.SelectedIndex < 0)
        return;
      this.m_CurrentTrophy.Settings.m_StandingsSort = this.comboTrophyStandingRules.SelectedIndex;
    }

    private void comboSchedForce_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.comboSchedForce.SelectedItem == null)
        return;
      this.m_CurrentTrophy.Settings.TrophyForcecomp = (Trophy) this.comboSchedForce.SelectedItem;
    }

    private void checkPromotionLeague_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.comboPromotionLeague.Visible = this.checkPromotionLeague.Checked;
      if (this.checkPromotionLeague.Checked)
        this.m_CurrentTrophy.Settings.LeaguePromo = (League) this.comboPromotionLeague.SelectedItem;
      else
        this.m_CurrentTrophy.Settings.LeaguePromo = (League) null;
    }

    private void checkRelegationLeague_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.comboRelegationLeague.Visible = this.checkRelegationLeague.Checked;
      if (this.checkRelegationLeague.Checked)
        this.m_CurrentTrophy.Settings.LeagueReleg = (League) this.comboRelegationLeague.SelectedItem;
      else
        this.m_CurrentTrophy.Settings.LeagueReleg = (League) null;
    }

    private void checkScheduleConflicts_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentTrophy.Settings.m_schedule_checkconflict = this.checkScheduleConflicts.Checked ? 1 : -1;
    }

    private void radioBench5Players_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || !this.radioBench5Players.Checked)
        return;
      this.m_CurrentTrophy.Settings.m_rule_numsubsbench = 5;
    }

    private void radioBench7Players_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || !this.radioBench7Players.Checked)
        return;
      this.m_CurrentTrophy.Settings.m_rule_numsubsbench = -1;
    }

    private void comboStageType_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.comboStageType.SelectedItem == null)
        return;
      this.m_CurrentStage.Settings.m_match_stagetype = (string) this.comboStageType.SelectedItem;
      this.StageToPanel();
    }

    private void comboMatchSituation_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.comboStageType.SelectedItem == null)
        return;
      this.m_CurrentStage.Settings.m_match_matchsituation = (string) this.comboMatchSituation.SelectedItem;
      this.m_CurrentStage.Settings.m_schedule_matchreplay = this.m_CurrentStage.Settings.m_match_matchsituation == "REPLAY" ? 1 : -1;
    }

    private void numericPrizeMoney_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentStage.Settings.m_info_prize_money = (int) this.numericPrizeMoney.Value;
    }

    private void numericMoneyDrop_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentStage.Settings.m_info_prize_money_drop = (int) this.numericMoneyDrop.Value;
    }

    private void numericStartYear_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentWorld.Settings.m_schedule_year_start = (int) this.numericStartYear.Value;
    }

    private void numericNumGames_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentStage.Settings.m_num_games = (int) this.numericNumGames.Value;
    }

    private void comboSpecialTeam1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.SetSpecialTeam(0);
    }

    private void comboSpecialTeam2_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.SetSpecialTeam(1);
    }

    private void comboSpecialTeam3_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.SetSpecialTeam(2);
    }

    private void comboSpecialTeam4_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.SetSpecialTeam(3);
    }

    private void SetSpecialTeam(int index)
    {
      if (this.m_SpecialTeamCombos[index].SelectedIndex == 0)
      {
        this.m_CurrentStage.Settings.m_info_special_team_id[index] = -1;
      }
      else
      {
        Team selectedItem = (Team) this.m_SpecialTeamCombos[index].SelectedItem;
        this.m_CurrentStage.Settings.m_info_special_team_id[index] = selectedItem.Id;
      }
    }

    private void SetMatchStadium(int index)
    {
      if (this.m_StadiumCombos[index].SelectedIndex == 0)
      {
        if (this.m_CurrentStage.Settings.m_match_stadium == null)
          return;
        this.m_CurrentStage.Settings.m_match_stadium[index] = -1;
      }
      else
      {
        Stadium selectedItem = (Stadium) this.m_StadiumCombos[index].SelectedItem;
        if (selectedItem == null || this.m_CurrentStage.Settings.m_match_stadium != null && this.m_CurrentStage.Settings.m_match_stadium[index] == selectedItem.Id)
          return;
        this.m_CurrentStage.Settings.SetProperty("match_stadium", index, selectedItem.Id.ToString());
      }
    }

    private void comboStadium1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.SetMatchStadium(0);
    }

    private void comboStadium2_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.SetMatchStadium(1);
    }

    private void comboStadium3_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.SetMatchStadium(2);
    }

    private void comboStadium4_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.SetMatchStadium(3);
    }

    private void comboStadium5_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.SetMatchStadium(4);
    }

    private void comboStadium6_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.SetMatchStadium(5);
    }

    private void comboStadium7_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.SetMatchStadium(6);
    }

    private void comboStadium8_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.SetMatchStadium(7);
    }

    private void comboStadium9_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.SetMatchStadium(8);
    }

    private void comboStadium10_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.SetMatchStadium(9);
    }

    private void comboStadium11_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.SetMatchStadium(10);
    }

    private void comboStadium12_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.SetMatchStadium(11);
    }

    private void checkMaxteamsgroup_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentStage.Settings.m_advance_maxteamsgroup = this.checkMaxteamsgroup.Checked ? 1 : -1;
      this.numericStageRef.Visible = this.checkMaxteamsgroup.Checked;
      if (this.m_CurrentStage.Settings.m_advance_maxteamsgroup == -1)
        this.m_CurrentStage.Settings.Advance_maxteamsstageref = -1;
      else
        this.numericStageRef.Value = (Decimal) this.m_CurrentStage.Settings.Advance_maxteamsstageref;
    }

    private void checkStandingKeep_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentStage.Settings.Advance_standingskeep = this.checkStandingKeep.Checked ? (int) this.numericStandingKeep.Value : -1;
      this.numericStandingKeep.Visible = this.checkStandingKeep.Checked;
      this.m_CurrentStage.Settings.Advance_standingskeep = this.checkStandingKeep.Checked ? (int) this.numericStandingKeep.Value : -1;
    }

    private void checkKeepPointsPercentage_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.numericKeepPointsPercentage.Visible = this.checkKeepPointsPercentage.Checked;
      this.numericKeepPointsStageRef.Visible = this.checkKeepPointsPercentage.Checked;
      if (this.checkKeepPointsPercentage.Checked == (this.m_CurrentStage.Settings.Advance_pointskeep != -1))
        return;
      if (!this.checkKeepPointsPercentage.Checked)
      {
        this.m_CurrentStage.Settings.Advance_pointskeep = -1;
        this.m_CurrentStage.Settings.m_advance_pointskeeppercentage = -1;
      }
      else
      {
        this.m_CurrentStage.Settings.Advance_pointskeep = this.m_CurrentStage.Id;
        this.m_CurrentStage.Settings.m_advance_pointskeeppercentage = 50;
        this.numericKeepPointsPercentage.Value = new Decimal(50);
        this.numericKeepPointsStageRef.Value = (Decimal) this.m_CurrentStage.Id;
      }
    }

    private void numericStandingKeep_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.m_CurrentStage.Settings.Advance_standingskeep == (int) this.numericStandingKeep.Value)
        return;
      this.m_CurrentStage.Settings.Advance_standingskeep = this.checkStandingKeep.Checked ? (int) this.numericStandingKeep.Value : -1;
    }

    private void numericKeepPointsPercentage_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentStage.Settings.m_advance_pointskeeppercentage = this.checkKeepPointsPercentage.Checked ? (int) this.numericKeepPointsPercentage.Value : -1;
    }

    private void checkSpecialKo1Rule_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.comboSpecialKo1Rule.Visible = this.checkSpecialKo1Rule.Checked;
      if (this.checkSpecialKo1Rule.Checked)
        this.m_CurrentStage.Settings.m_EndRuleKo1Leg = this.comboSpecialKo1Rule.SelectedIndex;
      else
        this.m_CurrentStage.Settings.m_EndRuleKo1Leg = -1;
    }

    private void checkSpecialKo2Rule_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.comboSpecialKo2Rule.Visible = this.checkSpecialKo2Rule.Checked;
      if (this.checkSpecialKo2Rule.Checked)
        this.m_CurrentStage.Settings.m_EndRuleKo2Leg2 = this.comboSpecialKo2Rule.SelectedIndex;
      else
        this.m_CurrentStage.Settings.m_EndRuleKo2Leg2 = -1;
    }

    private void comboSpecialKo1Rule_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.comboSpecialKo1Rule.SelectedIndex < 0)
        return;
      this.m_CurrentStage.Settings.m_EndRuleKo1Leg = this.comboSpecialKo1Rule.SelectedIndex;
    }

    private void comboSpecialKo2Rule_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.comboSpecialKo2Rule.SelectedIndex < 0)
        return;
      this.m_CurrentStage.Settings.m_EndRuleKo2Leg2 = this.comboSpecialKo2Rule.SelectedIndex;
      this.numericRegularSeason.Visible = this.m_CurrentStage.Settings.m_EndRuleKo2Leg2 == 3;
    }

    private void numericRegularSeason_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.m_CurrentStage.Settings.Standings_checkrank == (int) this.numericRegularSeason.Value)
        return;
      this.m_CurrentStage.Settings.Standings_checkrank = (int) this.numericRegularSeason.Value;
    }

    private void checkStandingsRank_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentStage.Settings.Advance_standingsrank = this.checkStandingsRank.Checked ? (int) this.numericStandingsRank.Value : -1;
      this.numericStandingsRank.Visible = this.checkStandingsRank.Checked;
      this.m_CurrentStage.Settings.Advance_standingsrank = this.checkStandingsRank.Checked ? (int) this.numericStandingsRank.Value : -1;
    }

    private void numericStandingsRank_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.m_CurrentStage.Settings.Advance_standingsrank == (int) this.numericStandingsRank.Value)
        return;
      this.m_CurrentStage.Settings.Advance_standingsrank = this.checkStandingsRank.Checked ? (int) this.numericStandingsRank.Value : -1;
    }

    private void checkInfoColorChamp_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentGroup.Settings.m_info_color_slot_champ = this.checkInfoColorChamp.Checked ? 1 : -1;
    }

    private void numericColorChampionsMin_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      int min1 = (int) this.numericColorChampionsMin.Value;
      int max = (int) this.numericColorChampionsMax.Value;
      int min2;
      this.m_CurrentGroup.Settings.GetInfoColorSlotChampCup(out min2, out int _);
      if (min1 == min2 || this.m_CurrentGroup.Settings.SetInfoColorSlotChampCup(min1, max))
        return;
      this.numericColorChampionsMin.Value = (Decimal) min2;
    }

    private void numericColorChampionsMax_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      int min = (int) this.numericColorChampionsMin.Value;
      int max1 = (int) this.numericColorChampionsMax.Value;
      int max2;
      this.m_CurrentGroup.Settings.GetInfoColorSlotChampCup(out int _, out max2);
      if (max1 == max2 || this.m_CurrentGroup.Settings.SetInfoColorSlotChampCup(min, max1))
        return;
      this.numericColorChampionsMax.Value = (Decimal) max2;
    }

    private void numericColorEuropaMin_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      int min1 = (int) this.numericColorEuropaMin.Value;
      int max1 = (int) this.numericColorEuropaMax.Value;
      int min2;
      int max2;
      this.m_CurrentGroup.Settings.GetInfoColorSlotEuroLeague(out min2, out max2);
      if (min1 == min2 && max1 == max2 || this.m_CurrentGroup.Settings.SetInfoColorSlotEuroLeague(min1, max1))
        return;
      this.numericColorEuropaMin.Value = (Decimal) min2;
    }

    private void numericColorEuropaMax_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      int min1 = (int) this.numericColorEuropaMin.Value;
      int max1 = (int) this.numericColorEuropaMax.Value;
      int min2;
      int max2;
      this.m_CurrentGroup.Settings.GetInfoColorSlotEuroLeague(out min2, out max2);
      if (min1 == min2 && max1 == max2 || this.m_CurrentGroup.Settings.SetInfoColorSlotEuroLeague(min1, max1))
        return;
      this.numericColorEuropaMax.Value = (Decimal) max2;
    }

    private void numericColorPossibleRelegationMin_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      int min1 = (int) this.numericColorPossibleRelegationMin.Value;
      int max1 = (int) this.numericColorPossibleRelegationMax.Value;
      int min2;
      int max2;
      this.m_CurrentGroup.Settings.GetInfoColorSlotRelegPoss(out min2, out max2);
      if (min1 == min2 && max1 == max2 || this.m_CurrentGroup.Settings.SetInfoColorSlotRelegPoss(min1, max1))
        return;
      this.numericColorPossibleRelegationMin.Value = (Decimal) min2;
    }

    private void numericColorPossibleRelegationMax_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      int min1 = (int) this.numericColorPossibleRelegationMin.Value;
      int max1 = (int) this.numericColorPossibleRelegationMax.Value;
      int min2;
      int max2;
      this.m_CurrentGroup.Settings.GetInfoColorSlotRelegPoss(out min2, out max2);
      if (min1 == min2 && max1 == max2 || this.m_CurrentGroup.Settings.SetInfoColorSlotRelegPoss(min1, max1))
        return;
      this.numericColorPossibleRelegationMax.Value = (Decimal) max2;
    }

    private void numericColorRelegationMin_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      int min1 = (int) this.numericColorRelegationMin.Value;
      int max1 = (int) this.numericColorRelegationMax.Value;
      int min2;
      int max2;
      this.m_CurrentGroup.Settings.GetInfoColorSlotReleg(out min2, out max2);
      if (min1 == min2 && max1 == max2 || this.m_CurrentGroup.Settings.SetInfoColorSlotReleg(min1, max1))
        return;
      this.numericColorRelegationMin.Value = (Decimal) min2;
    }

    private void numericColorRelegationMax_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      int min1 = (int) this.numericColorRelegationMin.Value;
      int max1 = (int) this.numericColorRelegationMax.Value;
      int min2;
      int max2;
      this.m_CurrentGroup.Settings.GetInfoColorSlotReleg(out min2, out max2);
      if (min1 == min2 && max1 == max2 || this.m_CurrentGroup.Settings.SetInfoColorSlotReleg(min1, max1))
        return;
      this.numericColorRelegationMax.Value = (Decimal) max2;
    }

    private void numericColorPromotionMin_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      int min1 = (int) this.numericColorPromotionMin.Value;
      int max1 = (int) this.numericColorPromotionMax.Value;
      int min2;
      int max2;
      this.m_CurrentGroup.Settings.GetInfoColorSlotPromo(out min2, out max2);
      if (min1 == min2 && max1 == max2 || this.m_CurrentGroup.Settings.SetInfoColorSlotPromo(min1, max1))
        return;
      this.numericColorPromotionMin.Value = (Decimal) min2;
    }

    private void numericColorPromotionMax_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      int min1 = (int) this.numericColorPromotionMin.Value;
      int max1 = (int) this.numericColorPromotionMax.Value;
      int min2;
      int max2;
      this.m_CurrentGroup.Settings.GetInfoColorSlotPromo(out min2, out max2);
      if (min1 == min2 && max1 == max2 || this.m_CurrentGroup.Settings.SetInfoColorSlotPromo(min1, max1))
        return;
      this.numericColorPromotionMax.Value = (Decimal) max2;
    }

    private void numericColorPossiblePromotionMin_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      int min1 = (int) this.numericColorPossiblePromotionMin.Value;
      int max1 = (int) this.numericColorPossiblePromotionMax.Value;
      int min2;
      int max2;
      this.m_CurrentGroup.Settings.GetInfoColorSlotPromoPoss(out min2, out max2);
      if (min1 == min2 && max1 == max2 || this.m_CurrentGroup.Settings.SetInfoColorSlotPromoPoss(min1, max1))
        return;
      this.numericColorPossiblePromotionMin.Value = (Decimal) min2;
    }

    private void numericColorPossiblePromotionMax_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      int min1 = (int) this.numericColorPossiblePromotionMin.Value;
      int max1 = (int) this.numericColorPossiblePromotionMax.Value;
      int min2;
      int max2;
      this.m_CurrentGroup.Settings.GetInfoColorSlotPromoPoss(out min2, out max2);
      if (min1 == min2 && max1 == max2 || this.m_CurrentGroup.Settings.SetInfoColorSlotPromoPoss(min1, max1))
        return;
      this.numericColorPossiblePromotionMax.Value = (Decimal) max2;
    }

    private void numericColorAdvanceMin_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      int min1 = (int) this.numericColorAdvanceMin.Value;
      int max1 = (int) this.numericColorAdvanceMax.Value;
      int min2;
      int max2;
      this.m_CurrentGroup.Settings.GetInfoColorSlotAdvGroup(out min2, out max2);
      if (min1 == min2 && max1 == max2 || this.m_CurrentGroup.Settings.SetInfoColorSlotAdvGroup(min1, max1))
        return;
      this.numericColorAdvanceMin.Value = (Decimal) min2;
    }

    private void numericColorAdvanceMax_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      int min1 = (int) this.numericColorAdvanceMin.Value;
      int max1 = (int) this.numericColorAdvanceMax.Value;
      int min2;
      int max2;
      this.m_CurrentGroup.Settings.GetInfoColorSlotAdvGroup(out min2, out max2);
      if (min1 == min2 && max1 == max2 || this.m_CurrentGroup.Settings.SetInfoColorSlotAdvGroup(min1, max1))
        return;
      this.numericColorAdvanceMax.Value = (Decimal) max2;
    }

    private void checkInfoColorChampions_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.numericColorChampionsMin.Visible = this.numericColorChampionsMax.Visible = this.checkInfoColorChampions.Checked;
      if (this.checkInfoColorChampions.Checked)
      {
        int min;
        int max;
        this.m_CurrentGroup.Settings.GetInfoColorSlotChampCup(out min, out max);
        if (min <= 0 || max <= 0)
          min = max = 1;
        this.numericColorChampionsMax.Value = (Decimal) min;
        this.numericColorChampionsMax.Value = (Decimal) max;
      }
      else
        this.m_CurrentGroup.Settings.SetInfoColorSlotChampCup(-1, -1);
    }

    private void checkInfoColorEuropa_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.numericColorEuropaMin.Visible = this.numericColorEuropaMax.Visible = this.checkInfoColorEuropa.Checked;
      if (this.checkInfoColorEuropa.Checked)
      {
        int min;
        int max;
        this.m_CurrentGroup.Settings.GetInfoColorSlotEuroLeague(out min, out max);
        if (min <= 0 || max <= 0)
          min = max = 1;
        this.numericColorEuropaMin.Value = (Decimal) min;
        this.numericColorEuropaMax.Value = (Decimal) max;
      }
      else
        this.m_CurrentGroup.Settings.SetInfoColorSlotEuroLeague(-1, -1);
    }

    private void checkInfoColorPossibleRelegation_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.numericColorPossibleRelegationMin.Visible = this.numericColorPossibleRelegationMax.Visible = this.checkInfoColorPossibleRelegation.Checked;
      if (this.checkInfoColorPossibleRelegation.Checked)
      {
        int min;
        int max;
        this.m_CurrentGroup.Settings.GetInfoColorSlotRelegPoss(out min, out max);
        if (min <= 0 || max <= 0)
          min = max = 1;
        this.numericColorPossibleRelegationMin.Value = (Decimal) min;
        this.numericColorPossibleRelegationMax.Value = (Decimal) max;
      }
      else
        this.m_CurrentGroup.Settings.SetInfoColorSlotRelegPoss(-1, -1);
    }

    private void checkInfoColorRelegation_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.numericColorRelegationMin.Visible = this.numericColorRelegationMax.Visible = this.checkInfoColorRelegation.Checked;
      if (this.checkInfoColorRelegation.Checked)
      {
        int min;
        int max;
        this.m_CurrentGroup.Settings.GetInfoColorSlotReleg(out min, out max);
        if (min <= 0 || max <= 0)
          min = max = 1;
        this.numericColorRelegationMin.Value = (Decimal) min;
        this.numericColorRelegationMax.Value = (Decimal) max;
      }
      else
        this.m_CurrentGroup.Settings.SetInfoColorSlotReleg(-1, -1);
    }

    private void checkInfoColorPromotion_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.numericColorPromotionMin.Visible = this.numericColorPromotionMax.Visible = this.checkInfoColorPromotion.Checked;
      if (this.checkInfoColorPromotion.Checked)
      {
        int min;
        int max;
        this.m_CurrentGroup.Settings.GetInfoColorSlotPromo(out min, out max);
        if (min <= 0 || max <= 0)
          min = max = 1;
        this.numericColorPromotionMin.Value = (Decimal) min;
        this.numericColorPromotionMax.Value = (Decimal) max;
      }
      else
        this.m_CurrentGroup.Settings.SetInfoColorSlotPromo(-1, -1);
    }

    private void checkInfoColorPossiblePromotion_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.numericColorPossiblePromotionMin.Visible = this.numericColorPossiblePromotionMax.Visible = this.checkInfoColorPossiblePromotion.Checked;
      if (this.checkInfoColorPossiblePromotion.Checked)
      {
        int min;
        int max;
        this.m_CurrentGroup.Settings.GetInfoColorSlotPromoPoss(out min, out max);
        if (min <= 0 || max <= 0)
          min = max = 1;
        this.numericColorPossiblePromotionMin.Value = (Decimal) min;
        this.numericColorPossiblePromotionMax.Value = (Decimal) max;
      }
      else
        this.m_CurrentGroup.Settings.SetInfoColorSlotPromoPoss(-1, -1);
    }

    private void checkInfoColorAdvance_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.numericColorAdvanceMin.Visible = this.numericColorAdvanceMax.Visible = this.checkInfoColorAdvance.Checked;
      if (this.checkInfoColorAdvance.Checked)
      {
        int min;
        int max;
        this.m_CurrentGroup.Settings.GetInfoColorSlotAdvGroup(out min, out max);
        if (min <= 0 || max <= 0)
          min = max = 1;
        this.numericColorAdvanceMin.Value = (Decimal) min;
        this.numericColorAdvanceMax.Value = (Decimal) max;
      }
      else
        this.m_CurrentGroup.Settings.SetInfoColorSlotAdvGroup(-1, -1);
    }

    private void labelQR_Click(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      Label label = (Label) sender;
      Task tag = (Task) label.Tag;
      this.m_QualifyRuleDialog.QualifyRule = tag;
      if (this.m_QualifyRuleDialog.ShowDialog() != DialogResult.OK)
        return;
      label.Tag = (object) tag;
      label.Text = tag.ToString();
    }

    private void labelAdvance_Click(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      Rank tag = (Rank) ((Control) sender).Tag;
      Rank rank = new Rank(tag.Group, tag.Id);
      rank.MoveFrom = tag.MoveFrom;
      this.m_AdvanceRuleDialog.Rule = rank;
      if (this.m_AdvanceRuleDialog.ShowDialog() != DialogResult.OK)
        return;
      if (rank.MoveFrom != tag.MoveFrom)
      {
        if (tag.MoveFrom != null && tag.MoveFrom.Id != 0)
          tag.MoveFrom.MoveTo = (Rank) null;
        if (rank.MoveFrom.Id != 0)
        {
          if (rank.MoveFrom.MoveTo == null)
          {
            rank.MoveFrom.MoveTo = tag;
          }
          else
          {
            rank.MoveFrom.MoveTo.MoveFrom = (Rank) null;
            rank.MoveFrom.MoveTo = tag;
          }
        }
        tag.MoveFrom = rank.MoveFrom;
      }
      this.GroupToPanel();
    }

    private void textLanguageKey_TextChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.m_CurrentCompobj == null)
        return;
      if (this.m_CurrentCompobj.IsTrophy())
      {
        this.m_CurrentTrophy.Description = this.textLanguageKey.Text;
      }
      else
      {
        if (!this.m_CurrentCompobj.IsGroup())
          return;
        this.m_CurrentGroup.Description = this.textLanguageKey.Text;
      }
    }

    private void textFourCharName_TextChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.m_CurrentCompobj == null || this.m_CurrentCompobj.TypeString == this.textFourCharName.Text)
        return;
      if (this.textFourCharName.Text.Length > 4)
      {
        this.textFourCharName.Text = this.textFourCharName.Text.Substring(0, 4);
      }
      else
      {
        this.m_CurrentCompobj.TypeString = this.textFourCharName.Text;
        if (this.m_CurrentCompobj.IsNation())
          this.treeWorld.SelectedNode.Text = this.m_CurrentCompobj.TypeString;
        if (!this.m_CurrentCompobj.IsGroup())
          return;
        this.treeWorld.SelectedNode.Text = this.m_CurrentCompobj.TypeString;
      }
    }

    private TreeNode SelectWorldTreeNode(Compobj compobj)
    {
      if (compobj == null)
      {
        this.treeWorld.SelectedNode = (TreeNode) null;
        return (TreeNode) null;
      }
      TreeNode treeNode = this.RecusiveSearchNode(this.treeWorld.TopNode, compobj);
      this.treeWorld.SelectedNode = treeNode;
      return treeNode;
    }

    private TreeNode RecusiveSearchNode(TreeNode node, Compobj compobj)
    {
      if ((Compobj) node.Tag == compobj)
        return node;
      foreach (TreeNode node1 in node.Nodes)
      {
        TreeNode treeNode = this.RecusiveSearchNode(node1, compobj);
        if (treeNode != null)
          return treeNode;
      }
      return (TreeNode) null;
    }

    private void textLanguageName_TextChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.m_CurrentCompobj == null)
        return;
      if (this.m_CurrentCompobj.IsTrophy())
        this.m_CurrentTrophy.ShortName = this.textLanguageName.Text;
      else if (this.m_CurrentCompobj.IsStage())
      {
        if (this.m_CurrentStage.GetLanguageName() != this.textLanguageName.Text)
          this.m_CurrentStage.SetLanguageName(this.textLanguageName.Text);
        string str = this.m_CurrentStage.ToString();
        if (!(this.treeWorld.SelectedNode.Text != str))
          return;
        this.treeWorld.SelectedNode.Text = str;
      }
      else
      {
        if (!this.m_CurrentCompobj.IsGroup())
          return;
        this.m_CurrentGroup.LanguageName = this.textLanguageName.Text;
      }
    }

    private void comboLanguageKey_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.comboLanguageKey.SelectedItem == null || !(this.comboLanguageKey.SelectedItem.ToString() != this.m_CurrentStage.Description))
        return;
      this.m_CurrentStage.Description = (string) this.comboLanguageKey.SelectedItem;
      this.textLanguageName.Text = FifaEnvironment.Language.GetString(this.m_CurrentStage.Description);
      this.treeWorld.SelectedNode.Text = this.m_CurrentStage.ToString();
    }

    private void buttonCopyWeather_Click(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_ClipboardNation = this.m_CurrentNation;
      this.buttonPasteWeather.Enabled = true;
    }

    private void buttonPasteWeather_Click(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.m_ClipboardNation == null)
        return;
      for (int index = 0; index < 12; ++index)
      {
        this.m_CurrentNation.DryProb[index] = this.m_ClipboardNation.DryProb[index];
        this.m_CurrentNation.RainProb[index] = this.m_ClipboardNation.RainProb[index];
        this.m_CurrentNation.SnowProb[index] = this.m_ClipboardNation.SnowProb[index];
        this.m_CurrentNation.OvercastProb[index] = this.m_ClipboardNation.OvercastProb[index];
        this.m_CurrentNation.SunsetTime[index] = this.m_ClipboardNation.SunsetTime[index];
        this.m_CurrentNation.DarkTime[index] = this.m_ClipboardNation.DarkTime[index];
      }
      this.NationToPanel();
    }

    private void weatherProb_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      NumericUpDown numericUpDown = (NumericUpDown) sender;
      for (int index = 0; index < 12; ++index)
      {
        if (numericUpDown == this.m_RainProb[index])
        {
          this.m_CurrentNation.RainProb[index] = (int) numericUpDown.Value;
          if (this.m_CurrentNation.SnowProb[index] > 100 - this.m_CurrentNation.RainProb[index])
          {
            this.m_CurrentNation.SnowProb[index] = 100 - this.m_CurrentNation.RainProb[index];
            this.m_SnowProb[index].Value = (Decimal) this.m_CurrentNation.SnowProb[index];
          }
        }
        else if (numericUpDown == this.m_SnowProb[index])
        {
          this.m_CurrentNation.SnowProb[index] = (int) numericUpDown.Value;
          if (this.m_CurrentNation.RainProb[index] > 100 - this.m_CurrentNation.SnowProb[index])
          {
            this.m_CurrentNation.RainProb[index] = 100 - this.m_CurrentNation.SnowProb[index];
            this.m_RainProb[index].Value = (Decimal) this.m_CurrentNation.RainProb[index];
          }
        }
        else if (numericUpDown == this.m_OvercastProb[index])
          this.m_CurrentNation.OvercastProb[index] = (int) numericUpDown.Value;
        if (this.m_CurrentNation.DryProb[index] != 100 - (this.m_CurrentNation.SnowProb[index] + this.m_CurrentNation.RainProb[index]))
          this.m_CurrentNation.DryProb[index] = 100 - (this.m_CurrentNation.SnowProb[index] + this.m_CurrentNation.RainProb[index]);
      }
    }

    private void dayTime_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      ComboBox comboBox = (ComboBox) sender;
      for (int index = 0; index < 12; ++index)
      {
        if (comboBox == this.m_SunsetTime[index])
        {
          switch (comboBox.SelectedIndex)
          {
            case 0:
              this.m_CurrentNation.SunsetTime[index] = 1600;
              continue;
            case 1:
              this.m_CurrentNation.SunsetTime[index] = 1630;
              continue;
            case 2:
              this.m_CurrentNation.SunsetTime[index] = 1700;
              continue;
            case 3:
              this.m_CurrentNation.SunsetTime[index] = 1730;
              continue;
            case 4:
              this.m_CurrentNation.SunsetTime[index] = 1800;
              continue;
            case 5:
              this.m_CurrentNation.SunsetTime[index] = 1830;
              continue;
            case 6:
              this.m_CurrentNation.SunsetTime[index] = 1900;
              continue;
            case 7:
              this.m_CurrentNation.SunsetTime[index] = 1930;
              continue;
            case 8:
              this.m_CurrentNation.SunsetTime[index] = 2000;
              continue;
            case 9:
              this.m_CurrentNation.SunsetTime[index] = 2030;
              continue;
            case 10:
              this.m_CurrentNation.SunsetTime[index] = 2100;
              continue;
            default:
              continue;
          }
        }
        else if (comboBox == this.m_NightTime[index])
        {
          switch (comboBox.SelectedIndex)
          {
            case 0:
              this.m_CurrentNation.DarkTime[index] = 1600;
              continue;
            case 1:
              this.m_CurrentNation.DarkTime[index] = 1630;
              continue;
            case 2:
              this.m_CurrentNation.DarkTime[index] = 1700;
              continue;
            case 3:
              this.m_CurrentNation.DarkTime[index] = 1730;
              continue;
            case 4:
              this.m_CurrentNation.DarkTime[index] = 1800;
              continue;
            case 5:
              this.m_CurrentNation.DarkTime[index] = 1830;
              continue;
            case 6:
              this.m_CurrentNation.DarkTime[index] = 1900;
              continue;
            case 7:
              this.m_CurrentNation.DarkTime[index] = 1930;
              continue;
            case 8:
              this.m_CurrentNation.DarkTime[index] = 2000;
              continue;
            case 9:
              this.m_CurrentNation.DarkTime[index] = 2030;
              continue;
            case 10:
              this.m_CurrentNation.DarkTime[index] = 2100;
              continue;
            default:
              continue;
          }
        }
      }
    }

    private void treeStageSchedule_AfterSelect(object sender, TreeViewEventArgs e)
    {
      if (this.m_LockToPanel || this.treeStageSchedule.SelectedNode == null)
        return;
      if (this.treeStageSchedule.SelectedNode.Tag == null)
      {
        this.groupStageScheduleDetails.Visible = false;
        this.buttonStageAddTime.Enabled = false;
        this.buttonStageRemoveTime.Enabled = false;
        this.buttonDeleteStageLeg.Enabled = false;
      }
      else
      {
        this.m_CurrentStageSchedule = (Schedule) this.treeStageSchedule.SelectedNode.Tag;
        this.buttonDeleteStageLeg.Enabled = true;
        this.StageScheduleToPanel();
      }
    }

    private void StageScheduleToPanel()
    {
      this.groupStageScheduleDetails.Visible = true;
      this.buttonStageAddTime.Enabled = true;
      this.buttonStageRemoveTime.Enabled = true;
      this.dateStagePicker.Value = this.m_CurrentStageSchedule.Date;
      this.numericStageMinGames.Value = (Decimal) this.m_CurrentStageSchedule.MinGames;
      this.numericStageMaxGames.Value = (Decimal) this.m_CurrentStageSchedule.MaxGames;
      this.comboStageTime.SelectedIndex = this.m_CurrentStageSchedule.TimeIndex;
    }

    private void numericStageMinGames_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentStageSchedule.MinGames = (int) this.numericStageMinGames.Value;
    }

    private void numericStageMaxGames_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentStageSchedule.MaxGames = (int) this.numericStageMaxGames.Value;
    }

    private void comboStageTime_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.comboStageTime.SelectedIndex < 0 || this.comboStageTime.SelectedIndex == this.m_CurrentStageSchedule.TimeIndex)
        return;
      this.m_CurrentStageSchedule.TimeIndex = this.comboStageTime.SelectedIndex;
      this.treeStageSchedule.SelectedNode.Text = this.m_CurrentStageSchedule.Date.ToString("f");
    }

    private void dateStagePicker_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.dateStagePicker.Value == this.m_CurrentStageSchedule.Date)
        return;
      this.m_CurrentStageSchedule.Date = this.dateStagePicker.Value;
      this.treeStageSchedule.SelectedNode.Text = this.m_CurrentStageSchedule.Date.ToString("f");
    }

    private void GroupScheduleToPanel()
    {
      this.groupGroupScheduleDetails.Visible = true;
      this.buttonGroupAddTime.Enabled = true;
      this.buttonGroupRemoveTime.Enabled = true;
      this.dateGroupPicker.Value = this.m_CurrentGroupSchedule.Date;
      this.numericGroupMinGames.Value = (Decimal) this.m_CurrentGroupSchedule.MinGames;
      this.numericGroupMaxGames.Value = (Decimal) this.m_CurrentGroupSchedule.MaxGames;
      this.comboGroupTime.SelectedIndex = this.m_CurrentGroupSchedule.TimeIndex;
    }

    private void dateGroupPicker_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.dateGroupPicker.Value == this.m_CurrentGroupSchedule.Date)
        return;
      this.m_CurrentGroupSchedule.Date = this.dateGroupPicker.Value;
      this.treeGroupSchedule.SelectedNode.Text = this.m_CurrentGroupSchedule.Date.ToString("f");
    }

    private void comboGroupTime_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.comboGroupTime.SelectedIndex < 0 || this.comboGroupTime.SelectedIndex == this.m_CurrentGroupSchedule.TimeIndex)
        return;
      this.m_CurrentGroupSchedule.TimeIndex = this.comboGroupTime.SelectedIndex;
      this.treeGroupSchedule.SelectedNode.Text = this.m_CurrentGroupSchedule.Date.ToString("f");
    }

    private void numericGroupMinGames_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentGroupSchedule.MinGames = (int) this.numericGroupMinGames.Value;
    }

    private void numericGroupMaxGames_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentGroupSchedule.MaxGames = (int) this.numericGroupMaxGames.Value;
    }

    private void treeGroupSchedule_AfterSelect(object sender, TreeViewEventArgs e)
    {
      if (this.m_LockToPanel || this.treeGroupSchedule.SelectedNode == null)
        return;
      if (this.treeGroupSchedule.SelectedNode.Tag == null)
      {
        this.groupGroupScheduleDetails.Visible = false;
        this.buttonGroupAddTime.Enabled = false;
        this.buttonGroupRemoveTime.Enabled = false;
        this.buttonRemoveGroupLeg.Enabled = false;
      }
      else
      {
        this.m_CurrentGroupSchedule = (Schedule) this.treeGroupSchedule.SelectedNode.Tag;
        this.buttonRemoveGroupLeg.Enabled = true;
        this.GroupScheduleToPanel();
      }
    }

    private void comboInitTeam_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      ComboBox comboBox = (ComboBox) sender;
      for (int orderId = 0; orderId < 24; ++orderId)
      {
        if (comboBox == this.m_InitTeamCombo[orderId])
        {
          InitTeam initTeam = this.m_CurrentTrophy.InitTeamArray[orderId];
          if (initTeam == null)
          {
            initTeam = new InitTeam(orderId, -1);
            this.m_CurrentTrophy.InitTeamArray[orderId] = initTeam;
          }
          if (initTeam != null)
            initTeam.Team = comboBox.SelectedIndex != 0 ? (Team) comboBox.SelectedItem : (Team) null;
        }
      }
    }

    private void numericNTeams_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.m_CurrentGroup == null || this.numericNTeams.Value == (Decimal) (this.m_CurrentGroup.Ranks.Count - 1))
        return;
      if (this.numericNTeams.Value >= (Decimal) this.m_CurrentGroup.Ranks.Count)
      {
        for (int count = this.m_CurrentGroup.Ranks.Count; (Decimal) count <= this.numericNTeams.Value; ++count)
          this.m_CurrentGroup.AddRank();
      }
      else
      {
        for (int index = this.m_CurrentGroup.Ranks.Count - 1; (Decimal) index > this.numericNTeams.Value; --index)
          this.m_CurrentGroup.RemoveRank();
      }
      this.GroupToPanel();
    }

    private void numericNumGames_ValueChanged_1(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentGroup.Settings.m_num_games = (int) this.numericNumGames.Value;
    }

    private void EnableToolWorld()
    {
      if (this.m_CurrentCompobj == null || this.m_CurrentCompobj.IsWorld())
      {
        this.buttonAddNatiom.Visible = false;
        this.buttonDeleteNation.Visible = false;
        this.buttonAddTrophy.Visible = true;
        this.buttonPasteTrophy.Visible = true;
        this.comboTargetLeague.Visible = true;
        this.buttonCopyTrophy.Visible = false;
        this.buttonDeleteTrophy.Visible = false;
        this.buttonAddStage.Visible = false;
        this.buttonDeleteStage.Visible = false;
        this.buttonAddGroup.Visible = false;
        this.buttonDeleteGroup.Visible = false;
      }
      else if (this.m_CurrentCompobj.IsConfederation())
      {
        this.buttonAddNatiom.Visible = true;
        this.buttonDeleteNation.Visible = false;
        this.buttonAddTrophy.Visible = true;
        this.buttonPasteTrophy.Visible = true;
        this.comboTargetLeague.Visible = true;
        this.buttonCopyTrophy.Visible = false;
        this.buttonDeleteTrophy.Visible = false;
        this.buttonAddStage.Visible = false;
        this.buttonDeleteStage.Visible = false;
        this.buttonAddGroup.Visible = false;
        this.buttonDeleteGroup.Visible = false;
      }
      else if (this.m_CurrentCompobj.IsNation())
      {
        this.buttonAddNatiom.Visible = false;
        this.buttonDeleteNation.Visible = true;
        this.buttonAddTrophy.Visible = true;
        this.buttonPasteTrophy.Visible = true;
        this.comboTargetLeague.Visible = true;
        this.buttonCopyTrophy.Visible = false;
        this.buttonDeleteTrophy.Visible = false;
        this.buttonAddStage.Visible = false;
        this.buttonDeleteStage.Visible = false;
        this.buttonAddGroup.Visible = false;
        this.buttonDeleteGroup.Visible = false;
      }
      else if (this.m_CurrentCompobj.IsTrophy())
      {
        this.buttonAddNatiom.Visible = false;
        this.buttonDeleteNation.Visible = false;
        this.buttonAddTrophy.Visible = false;
        this.buttonPasteTrophy.Visible = false;
        this.comboTargetLeague.Visible = false;
        this.buttonCopyTrophy.Visible = true;
        this.buttonDeleteTrophy.Visible = true;
        this.buttonAddStage.Visible = false;
        this.buttonDeleteStage.Visible = false;
        this.buttonAddGroup.Visible = false;
        this.buttonDeleteGroup.Visible = false;
      }
      else if (this.m_CurrentCompobj.IsStage())
      {
        this.buttonAddNatiom.Visible = false;
        this.buttonDeleteNation.Visible = false;
        this.buttonAddTrophy.Visible = false;
        this.buttonPasteTrophy.Visible = false;
        this.comboTargetLeague.Visible = false;
        this.buttonCopyTrophy.Visible = false;
        this.buttonDeleteTrophy.Visible = false;
        this.buttonAddStage.Visible = true;
        this.buttonDeleteStage.Visible = true;
        this.buttonAddGroup.Visible = false;
        this.buttonDeleteGroup.Visible = false;
      }
      else
      {
        if (!this.m_CurrentCompobj.IsGroup())
          return;
        this.buttonAddNatiom.Visible = false;
        this.buttonDeleteNation.Visible = false;
        this.buttonAddTrophy.Visible = false;
        this.buttonPasteTrophy.Visible = false;
        this.comboTargetLeague.Visible = false;
        this.buttonCopyTrophy.Visible = false;
        this.buttonDeleteTrophy.Visible = false;
        this.buttonAddStage.Visible = false;
        this.buttonDeleteStage.Visible = false;
        this.buttonAddGroup.Visible = true;
        this.buttonDeleteGroup.Visible = true;
      }
    }

    private void labelDatabaseCountry_DoubleClick(object sender, EventArgs e)
    {
      if (this.m_CurrentNation.Country == null)
        return;
      MainForm.CM.JumpTo((IdObject) this.m_CurrentNation.Country);
    }

    private void buttonAddNatiom_Click(object sender, EventArgs e)
    {
      Nation nation = new Nation(FifaEnvironment.CompetitionObjects.GetNewId(), "COUN", "NationName_XXX", (Compobj) this.m_CurrentConfederation);
      this.m_CurrentConfederation.Nations.Add((object) nation);
      FifaEnvironment.CompetitionObjects.Add((object) nation);
      nation.Settings.m_schedule_seasonstartmonth = this.m_CurrentConfederation.Settings.m_schedule_seasonstartmonth;
      nation.Settings.m_rule_numyellowstored = 3;
      TreeNode treeNode = this.treeWorld.SelectedNode.Nodes.Add(nation.ToString());
      treeNode.Tag = (object) nation;
      treeNode.ForeColor = Color.Blue;
      this.treeWorld.SelectedNode = treeNode;
      this.treeWorld.Refresh();
    }

    private void buttonDeleteNation_Click(object sender, EventArgs e)
    {
      this.m_CurrentConfederation = (Confederation) this.m_CurrentNation.ParentObj;
      foreach (Trophy trophy in (ArrayList) this.m_CurrentNation.Trophies)
      {
        foreach (Stage stage in (ArrayList) trophy.Stages)
        {
          foreach (IdObject group in (ArrayList) stage.Groups)
            this.m_Competitions.RemoveId(group);
          this.m_Competitions.RemoveId((IdObject) stage);
        }
        this.m_Competitions.RemoveId((IdObject) trophy);
      }
      this.m_CurrentConfederation.Nations.RemoveId((IdObject) this.m_CurrentNation);
      this.treeWorld.SelectedNode.Remove();
    }

    private void buttonAddTrophy_Click(object sender, EventArgs e)
    {
      int newId = FifaEnvironment.CompetitionObjects.GetNewId();
      int assetId = Trophy.AutoAsset();
      string conventionalString = FifaEnvironment.Language.GetTournamentConventionalString(assetId, Language.ETournamentStringType.Abbr15);
      string typeString = "C" + assetId.ToString();
      Trophy trophy = new Trophy(newId, typeString, conventionalString, this.m_CurrentCompobj);
      this.m_CurrentCompobj.Trophies.Add((object) trophy);
      this.m_Competitions.Add((object) trophy);
      trophy.Settings.m_asset_id = assetId;
      trophy.Settings.m_rule_numsubsbench = 5;
      trophy.Settings.m_match_matchimportance = 25;
      trophy.Settings.m_comp_type = "LEAGUE";
      if (!trophy.InsertStage(0))
        return;
      Stage stage = (Stage) trophy.Stages[0];
      stage.InsertGroup(0);
      Group group = (Group) stage.Groups[0];
      TreeNode treeNode1 = this.treeWorld.SelectedNode.Nodes.Add(trophy.ToString());
      treeNode1.Tag = (object) trophy;
      treeNode1.ForeColor = Color.DarkGreen;
      TreeNode treeNode2 = treeNode1.Nodes.Add(stage.ToString());
      treeNode2.Tag = (object) stage;
      treeNode2.ForeColor = Color.Magenta;
      TreeNode treeNode3 = treeNode2.Nodes.Add(group.ToString());
      treeNode3.Tag = (object) group;
      treeNode3.ForeColor = Color.DarkRed;
      this.treeWorld.SelectedNode = treeNode1;
      this.Preset();
      this.treeWorld.Refresh();
    }

    private void buttonDeleteTrophy_Click(object sender, EventArgs e)
    {
      if (this.m_CurrentTrophy.ParentObj.IsConfederation())
      {
        this.m_CurrentConfederation = (Confederation) this.m_CurrentTrophy.ParentObj;
        this.m_CurrentConfederation.Trophies.RemoveId((IdObject) this.m_CurrentTrophy);
      }
      else if (this.m_CurrentTrophy.ParentObj.IsNation())
      {
        this.m_CurrentNation = (Nation) this.m_CurrentTrophy.ParentObj;
        this.m_CurrentNation.Trophies.RemoveId((IdObject) this.m_CurrentTrophy);
      }
      else if (this.m_CurrentTrophy.ParentObj.IsWorld())
        this.m_CurrentWorld.Trophies.RemoveId((IdObject) this.m_CurrentTrophy);
      foreach (Stage stage in (ArrayList) this.m_CurrentTrophy.Stages)
      {
        foreach (IdObject group in (ArrayList) stage.Groups)
          this.m_Competitions.RemoveId(group);
        this.m_Competitions.RemoveId((IdObject) stage);
      }
      this.m_Competitions.RemoveId((IdObject) this.m_CurrentTrophy);
      this.treeWorld.SelectedNode.Remove();
      this.Preset();
    }

    private Stage CreateFirstStage(Trophy parentTrophy)
    {
      return !parentTrophy.InsertStage(0) ? (Stage) null : (Stage) parentTrophy.Stages[0];
    }

    private Group CreateFirstGroup(Stage parentStage)
    {
      Group group = new Group(FifaEnvironment.CompetitionObjects.GetNewId(), "G1", "FCE_Setup_Group", (Compobj) parentStage);
      parentStage.Groups.Add((object) group);
      FifaEnvironment.CompetitionObjects.Add((object) group);
      group.Settings.m_num_games = 1;
      return group;
    }

    private void buttonAddStage_Click(object sender, EventArgs e)
    {
      int num = this.m_CurrentTrophy.Stages.IndexOf((object) this.m_CurrentStage);
      if (num < 0)
        return;
      int index = num + 1;
      if (!this.m_CurrentTrophy.InsertStage(index))
        return;
      this.m_CurrentStage = (Stage) this.m_CurrentTrophy.Stages[index];
      this.m_Competitions.Add((object) this.m_CurrentStage);
      this.m_CurrentStage.InsertGroup(0);
      Group group = (Group) this.m_CurrentStage.Groups[0];
      this.m_Competitions.Add((object) group);
      TreeNode treeNode1 = this.treeWorld.SelectedNode.Parent.Nodes.Insert(index, this.m_CurrentStage.ToString());
      treeNode1.ForeColor = Color.Magenta;
      treeNode1.Tag = (object) this.m_CurrentStage;
      TreeNode treeNode2 = treeNode1.Nodes.Add(group.ToString());
      treeNode2.Tag = (object) group;
      treeNode2.ForeColor = Color.DarkRed;
      this.treeWorld.SelectedNode = treeNode1;
      this.Preset();
    }

    private void buttonDeleteStage_Click(object sender, EventArgs e)
    {
      foreach (Group group in (ArrayList) this.m_CurrentStage.Groups)
      {
        for (int index = 1; index < group.Ranks.Count; ++index)
        {
          Rank rank = (Rank) group.Ranks[index];
          if (rank.MoveFrom != null)
            rank.MoveFrom.MoveTo = (Rank) null;
          if (rank.MoveTo != null)
            rank.MoveTo.MoveFrom = (Rank) null;
        }
        this.m_Competitions.RemoveId((IdObject) group);
      }
      this.m_Competitions.RemoveId((IdObject) this.m_CurrentStage);
      this.m_CurrentTrophy.RemoveStage(this.m_CurrentStage);
      this.treeWorld.SelectedNode.Remove();
      this.Preset();
    }

    private void checkCalccompavgs_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentStage.Settings.m_advance_calccompavgs = this.checkCalccompavgs.Checked ? 1 : -1;
    }

    private void checkRandomDraw_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentStage.Settings.m_advance_randomdraw = this.checkRandomDraw.Checked ? 1 : -1;
    }

    private void buttonAddGroup_Click(object sender, EventArgs e)
    {
      if (this.m_CurrentGroup == null)
        return;
      this.m_ClipboardGroup = this.m_CurrentGroup;
      int num = this.m_CurrentStage.Groups.IndexOf((object) this.m_CurrentGroup);
      if (num < 0)
        return;
      int index = num + 1;
      if (!this.m_CurrentStage.InsertGroup(index))
        return;
      this.m_CurrentGroup = (Group) this.m_CurrentStage.Groups[index];
      this.m_Competitions.Add((object) this.m_CurrentGroup);
      for (int orderId = 1; orderId < this.m_ClipboardGroup.Ranks.Count; ++orderId)
      {
        Rank rank1 = new Rank(this.m_CurrentGroup, orderId);
        Rank rank2 = (Rank) this.m_ClipboardGroup.Ranks[orderId];
        if (rank2.MoveFrom != null && rank2.MoveFrom.Id == 0)
          rank1.MoveFrom = rank2.MoveFrom;
        this.m_CurrentGroup.Ranks.Add((object) rank1);
      }
      this.m_CurrentGroup.Settings.m_num_games = this.m_ClipboardGroup.Settings.m_num_games;
      TreeNode treeNode = this.treeWorld.SelectedNode.Parent.Nodes.Insert(index, this.m_CurrentGroup.ToString());
      treeNode.ForeColor = Color.Brown;
      treeNode.Tag = (object) this.m_CurrentGroup;
      this.treeWorld.SelectedNode = treeNode;
      foreach (TreeNode node in this.treeWorld.SelectedNode.Parent.Nodes)
        node.Text = ((Group) node.Tag).ToString();
      this.Preset();
    }

    private void buttonDeleteGroup_Click(object sender, EventArgs e)
    {
      if (this.m_CurrentGroup == null)
        return;
      for (int index = 1; index < this.m_CurrentGroup.Ranks.Count; ++index)
      {
        Rank rank = (Rank) this.m_CurrentGroup.Ranks[index];
        if (rank.MoveFrom != null)
          rank.MoveFrom.MoveTo = (Rank) null;
        if (rank.MoveTo != null)
          rank.MoveTo.MoveFrom = (Rank) null;
      }
      this.m_CurrentStage.RemoveGroup(this.m_CurrentGroup);
      this.m_Competitions.RemoveId((IdObject) this.m_CurrentGroup);
      TreeNode parent = this.treeWorld.SelectedNode.Parent;
      this.treeWorld.SelectedNode.Remove();
      foreach (TreeNode node in parent.Nodes)
        node.Text = ((Group) node.Tag).ToString();
      this.Preset();
    }

    private void buttonCopyTrophy_Click(object sender, EventArgs e)
    {
      this.m_ClipboardTrophy = this.m_CurrentTrophy;
      this.buttonPasteTrophy.Enabled = this.m_ClipboardTrophy != null;
      this.comboTargetLeague.Enabled = this.buttonPasteTrophy.Enabled;
    }

    private void buttonPasteTrophy_Click(object sender, EventArgs e)
    {
      if (this.m_ClipboardTrophy == null)
        return;
      bool flag = false;
      if (this.m_ClipboardTrophy.Stages != null && ((Compobj) this.m_ClipboardTrophy.Stages[0]).Settings.m_match_stagetype == "LEAGUE")
        flag = true;
      int newId = FifaEnvironment.CompetitionObjects.GetNewId();
      League targetLeague = (League) null;
      if (this.comboTargetLeague.SelectedIndex > 0)
        targetLeague = (League) this.comboTargetLeague.SelectedItem;
      int assetId = !flag || targetLeague == null ? Trophy.AutoAsset() : targetLeague.Id;
      string conventionalString = FifaEnvironment.Language.GetTournamentConventionalString(assetId, Language.ETournamentStringType.Abbr15);
      string typeString = "C" + assetId.ToString();
      Trophy newTrophy = new Trophy(newId, typeString, conventionalString, this.m_CurrentCompobj);
      this.m_CurrentCompobj.Trophies.Add((object) newTrophy);
      this.m_Competitions.Add((object) newTrophy);
      newTrophy.Settings.m_asset_id = assetId;
      newTrophy.Settings.m_rule_numsubsbench = this.m_ClipboardTrophy.Settings.m_rule_numsubsbench;
      newTrophy.Settings.m_match_matchimportance = this.m_ClipboardTrophy.Settings.m_match_matchimportance;
      newTrophy.Settings.m_comp_type = this.m_ClipboardTrophy.Settings.m_comp_type;
      newTrophy.Settings.m_StandingsSort = this.m_ClipboardTrophy.Settings.m_StandingsSort;
      newTrophy.Settings.m_schedule_checkconflict = this.m_ClipboardTrophy.Settings.m_schedule_checkconflict;
      newTrophy.Settings.TrophyCompdependency = this.m_ClipboardTrophy.Settings.TrophyCompdependency;
      newTrophy.Settings.TrophyForcecomp = this.m_ClipboardTrophy.Settings.TrophyForcecomp;
      newTrophy.Settings.LeaguePromo = this.m_ClipboardTrophy.Settings.LeaguePromo;
      newTrophy.Settings.LeagueReleg = this.m_ClipboardTrophy.Settings.LeagueReleg;
      TreeNode treeNode1 = this.treeWorld.SelectedNode.Nodes.Add(newTrophy.ToString());
      treeNode1.Tag = (object) newTrophy;
      treeNode1.ForeColor = Color.DarkGreen;
      for (int index1 = 0; index1 < this.m_ClipboardTrophy.Stages.Count; ++index1)
      {
        newTrophy.AddStage();
        Stage stage1 = (Stage) newTrophy.Stages[index1];
        Stage stage2 = (Stage) this.m_ClipboardTrophy.Stages[index1];
        if (stage2.Schedules != null)
        {
          foreach (Schedule schedule1 in (ArrayList) stage2.Schedules)
          {
            Schedule schedule2 = new Schedule(stage1, schedule1.Day, schedule1.Leg, schedule1.MinGames, schedule1.MaxGames, schedule1.Time);
            stage1.AddSchedule(schedule2);
          }
        }
        stage1.Description = stage2.Description;
        stage1.Settings.m_match_stagetype = stage2.Settings.m_match_stagetype;
        stage1.Settings.m_match_matchsituation = stage2.Settings.m_match_matchsituation;
        stage1.Settings.m_schedule_matchreplay = stage2.Settings.m_schedule_matchreplay;
        stage1.Settings.m_info_prize_money = stage2.Settings.m_info_prize_money;
        stage1.Settings.m_info_prize_money_drop = stage2.Settings.m_info_prize_money_drop;
        stage1.Settings.m_advance_maxteamsassoc = stage2.Settings.m_advance_maxteamsassoc;
        stage1.Settings.m_advance_maxteamsgroup = stage2.Settings.m_advance_maxteamsgroup;
        stage1.Settings.m_schedule_reversed = stage2.Settings.m_schedule_reversed;
        stage1.Settings.Advance_standingskeep = stage2.Settings.Advance_standingskeep;
        stage1.Settings.Advance_pointskeep = stage2.Settings.Advance_pointskeep;
        stage1.Settings.m_advance_pointskeeppercentage = stage2.Settings.m_advance_pointskeeppercentage;
        stage1.Settings.Advance_standingsrank = stage2.Settings.Advance_standingsrank;
        stage1.Settings.m_EndRuleKo1Leg = stage2.Settings.m_EndRuleKo1Leg;
        stage1.Settings.m_EndRuleKo2Leg2 = stage2.Settings.m_EndRuleKo2Leg2;
        stage1.Settings.Standings_checkrank = stage2.Settings.Standings_checkrank;
        stage1.Settings.m_advance_randomdraw = stage2.Settings.m_advance_randomdraw;
        stage1.Settings.m_advance_calccompavgs = stage2.Settings.m_advance_calccompavgs;
        stage2.CopyTasks(stage1, targetLeague);
        TreeNode treeNode2 = treeNode1.Nodes.Add(stage1.ToString());
        treeNode2.Tag = (object) stage1;
        treeNode2.ForeColor = Color.Magenta;
        for (int groupIndex = 0; groupIndex < stage2.Groups.Count; ++groupIndex)
        {
          stage1.InsertGroup(groupIndex);
          Group group1 = (Group) stage1.Groups[groupIndex];
          Group group2 = (Group) stage2.Groups[groupIndex];
          TreeNode treeNode3 = treeNode2.Nodes.Add(group1.ToString());
          treeNode3.Tag = (object) group1;
          treeNode3.ForeColor = Color.DarkRed;
          if (group2.Schedules != null)
          {
            foreach (Schedule schedule1 in (ArrayList) group2.Schedules)
            {
              Schedule schedule2 = new Schedule(group1, schedule1.Day, schedule1.Leg, schedule1.MinGames, schedule1.MaxGames, schedule1.Time);
              group1.AddSchedule(schedule2);
            }
          }
          group1.Description = group2.Description;
          for (int index2 = 1; index2 < group2.Ranks.Count; ++index2)
          {
            group1.AddRank();
            Rank rank1 = (Rank) group2.Ranks[index2];
            Rank rank2 = (Rank) group1.Ranks[index2];
          }
          group1.Settings.m_num_games = group2.Settings.m_num_games;
          group1.Settings.m_StandingsSort = group2.Settings.m_StandingsSort;
          group1.Settings.m_info_color_slot_champ = group2.Settings.m_info_color_slot_champ;
          group1.Settings.m_info_slot_champ = group2.Settings.m_info_slot_champ;
          int min;
          int max;
          group2.Settings.GetInfoColorSlotChampCup(out min, out max);
          group1.Settings.SetInfoColorSlotChampCup(min, max);
          group2.Settings.GetInfoColorSlotEuroLeague(out min, out max);
          group1.Settings.SetInfoColorSlotEuroLeague(min, max);
          group2.Settings.GetInfoColorSlotRelegPoss(out min, out max);
          group1.Settings.SetInfoColorSlotRelegPoss(min, max);
          group2.Settings.GetInfoColorSlotReleg(out min, out max);
          group1.Settings.SetInfoColorSlotReleg(min, max);
          group2.Settings.GetInfoColorSlotPromo(out min, out max);
          group1.Settings.SetInfoColorSlotPromo(min, max);
          group2.Settings.GetInfoColorSlotPromoPoss(out min, out max);
          group1.Settings.SetInfoColorSlotPromoPoss(min, max);
          group2.Settings.GetInfoColorSlotAdvGroup(out min, out max);
          group1.Settings.SetInfoColorSlotAdvGroup(min, max);
          group2.Settings.GetInfoSlotRelegPoss(out min, out max);
          group1.Settings.SetInfoSlotRelegPoss(min, max);
          group2.Settings.GetInfoSlotReleg(out min, out max);
          group1.Settings.SetInfoSlotReleg(min, max);
          group2.Settings.GetInfoSlotPromo(out min, out max);
          group1.Settings.SetInfoSlotPromo(min, max);
          group2.Settings.GetInfoSlotPromoPoss(out min, out max);
          group1.Settings.SetInfoSlotPromoPoss(min, max);
          group2.CopyTasks(group1, targetLeague);
        }
      }
      this.m_ClipboardTrophy.CopyTasks(newTrophy, targetLeague);
      newTrophy.LinkCompetitions();
      for (int index1 = 0; index1 < this.m_ClipboardTrophy.Stages.Count; ++index1)
      {
        Stage stage1 = (Stage) newTrophy.Stages[index1];
        Stage stage2 = (Stage) this.m_ClipboardTrophy.Stages[index1];
        stage1.LinkCompetitions();
        for (int index2 = 0; index2 < stage2.Groups.Count; ++index2)
        {
          Group group1 = (Group) stage1.Groups[index2];
          Group group2 = (Group) stage2.Groups[index2];
          group1.LinkCompetitions();
          for (int index3 = 1; index3 < group2.Ranks.Count; ++index3)
          {
            Rank rank1 = (Rank) group2.Ranks[index3];
            Rank rank2 = (Rank) group1.Ranks[index3];
            if (rank1.MoveFrom != null)
            {
              int num = rank1.MoveFrom.Group.Id - rank1.Group.Id;
              Compobj compobj = (Compobj) this.m_Competitions.SearchId(rank2.Group.Id + num);
              if (compobj.IsGroup())
              {
                Group group3 = (Group) compobj;
                if (group3 != null && group3.Ranks.Count > rank1.MoveFrom.Id)
                  rank2.MoveFrom = (Rank) group3.Ranks[rank1.MoveFrom.Id];
              }
            }
            if (rank1.MoveTo != null)
            {
              int num = rank1.MoveTo.Group.Id - rank1.Group.Id;
              Compobj compobj = (Compobj) this.m_Competitions.SearchId(rank2.Group.Id + num);
              if (compobj != null && compobj.IsGroup())
              {
                Group group3 = (Group) compobj;
                if (group3 != null)
                  rank2.MoveTo = (Rank) group3.Ranks[rank1.MoveTo.Id];
              }
            }
          }
        }
      }
      this.treeWorld.SelectedNode = treeNode1;
      this.Preset();
      this.treeWorld.Refresh();
    }

    private void buttonCopyStageCalendar_Click(object sender, EventArgs e)
    {
      if (this.m_CurrentStage.NSchedule == 0)
        return;
      this.m_ClipboardStageForSchedule = this.m_CurrentStage;
      this.m_ClipboardGroupForSchedule = (Group) null;
      this.buttonPasteStageCalendar.Enabled = true;
      this.buttonPasteGroupCalendar.Enabled = true;
    }

    private void buttonPasteStageCalendar_Click(object sender, EventArgs e)
    {
      if (this.m_ClipboardStageForSchedule != null && this.m_CurrentStage != this.m_ClipboardStageForSchedule)
      {
        this.m_CurrentStage.RemoveAllSchedules();
        foreach (Schedule schedule in (ArrayList) this.m_ClipboardStageForSchedule.Schedules)
          this.m_CurrentStage.AddSchedule(new Schedule(this.m_CurrentStage, schedule.Day, schedule.Leg, schedule.MinGames, schedule.MaxGames, schedule.Time));
        this.StageToPanel();
      }
      else
      {
        if (this.m_ClipboardGroupForSchedule == null || this.m_ClipboardGroupForSchedule.NSchedule == 0)
          return;
        this.m_CurrentStage.RemoveAllSchedules();
        foreach (Schedule schedule in (ArrayList) this.m_ClipboardGroupForSchedule.Schedules)
          this.m_CurrentStage.AddSchedule(new Schedule(this.m_CurrentStage, schedule.Day, schedule.Leg, schedule.MinGames, schedule.MaxGames, schedule.Time));
        this.StageToPanel();
      }
    }

    private void buttonNewStageLeg_Click(object sender, EventArgs e)
    {
      int dayDelay = 7;
      this.m_CurrentStageSchedule = this.m_CurrentStageSchedule == null || this.m_CurrentStage.Schedules == null || this.m_CurrentStage.Schedules.Count == 0 ? this.m_CurrentStage.AppendLeg(dayDelay) : this.m_CurrentStage.Schedules.DuplicatetLeg(this.m_CurrentStageSchedule.Leg, dayDelay);
      this.StageToPanel();
    }

    private void buttonDeleteStageLeg_Click(object sender, EventArgs e)
    {
      if (this.m_CurrentStageSchedule == null)
        return;
      this.m_CurrentStage.Schedules.RemoveLeg(this.m_CurrentStageSchedule.Leg);
      this.m_CurrentStageSchedule = (Schedule) null;
      this.StageToPanel();
    }

    private void buttonStageAddTime_Click(object sender, EventArgs e)
    {
      if (this.m_CurrentStage == null || this.m_CurrentStageSchedule == null)
        return;
      this.m_CurrentStage.CloneSchedule(this.m_CurrentStageSchedule, 100);
      this.StageToPanel();
    }

    private void buttonStageRemoveTime_Click(object sender, EventArgs e)
    {
      if (this.m_CurrentStage == null || this.m_CurrentStageSchedule == null)
        return;
      this.m_CurrentStage.DeleteSchedule(this.m_CurrentStageSchedule);
      this.m_CurrentStageSchedule = (Schedule) null;
      this.StageToPanel();
    }

    private void buttonCopyGroupCalendar_Click(object sender, EventArgs e)
    {
      if (this.m_CurrentGroup.NSchedule <= 0)
        return;
      this.m_ClipboardStageForSchedule = (Stage) null;
      this.m_ClipboardGroupForSchedule = this.m_CurrentGroup;
      this.buttonPasteStageCalendar.Enabled = true;
      this.buttonPasteGroupCalendar.Enabled = true;
    }

    private void buttonPasteGroupCalendar_Click(object sender, EventArgs e)
    {
      if (this.m_ClipboardStageForSchedule != null && this.m_ClipboardStageForSchedule.NSchedule != 0)
      {
        this.m_CurrentGroup.RemoveAllSchedules();
        foreach (Schedule schedule in (ArrayList) this.m_ClipboardStageForSchedule.Schedules)
          this.m_CurrentGroup.AddSchedule(new Schedule(this.m_CurrentGroup, schedule.Day, schedule.Leg, schedule.MinGames, schedule.MaxGames, schedule.Time));
        this.GroupToPanel();
      }
      else
      {
        if (this.m_ClipboardGroupForSchedule == null || this.m_ClipboardGroupForSchedule == this.m_CurrentGroup)
          return;
        this.m_CurrentGroup.RemoveAllSchedules();
        foreach (Schedule schedule in (ArrayList) this.m_ClipboardGroupForSchedule.Schedules)
          this.m_CurrentGroup.AddSchedule(new Schedule(this.m_CurrentGroup, schedule.Day, schedule.Leg, schedule.MinGames, schedule.MaxGames, schedule.Time));
        this.GroupToPanel();
      }
    }

    private void buttonGroupAddTime_Click(object sender, EventArgs e)
    {
      if (this.m_CurrentGroup == null || this.m_CurrentGroupSchedule == null)
        return;
      this.m_CurrentGroup.CloneSchedule(this.m_CurrentGroupSchedule, 100);
      this.GroupToPanel();
    }

    private void buttonGroupRemoveTime_Click(object sender, EventArgs e)
    {
      if (this.m_CurrentGroup == null || this.m_CurrentGroupSchedule == null)
        return;
      this.m_CurrentGroup.DeleteSchedule(this.m_CurrentGroupSchedule);
      this.m_CurrentGroupSchedule = (Schedule) null;
      this.GroupToPanel();
    }

    private void buttonAddRule_Click(object sender, EventArgs e)
    {
      this.m_CurrentGroup.AddTask(new Task("start", "", this.m_CurrentGroup.Id, 0, 0, 0)
      {
        Group = this.m_CurrentGroup
      });
      this.GroupToPanel();
    }

    private void buttonRemoveRule_Click(object sender, EventArgs e)
    {
      this.m_CurrentGroup.RemoveLastTask("start");
      this.GroupToPanel();
    }

    private void checkInfoChamp_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentGroup.Settings.m_info_slot_champ = this.checkInfoChamp.Checked ? 1 : -1;
    }

    private void checkInfoPossibleRelegation_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.numericPossibleRelegationMin.Visible = this.numericPossibleRelegationMax.Visible = this.checkInfoPossibleRelegation.Checked;
      if (this.checkInfoPossibleRelegation.Checked)
      {
        int min;
        int max;
        this.m_CurrentGroup.Settings.GetInfoSlotRelegPoss(out min, out max);
        if (min <= 0 || max <= 0)
          min = max = 1;
        this.numericPossibleRelegationMin.Value = (Decimal) min;
        this.numericPossibleRelegationMax.Value = (Decimal) max;
      }
      else
        this.m_CurrentGroup.Settings.SetInfoSlotRelegPoss(-1, -1);
    }

    private void checkInfoRelegation_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.numericRelegationMin.Visible = this.numericRelegationMax.Visible = this.checkInfoRelegation.Checked;
      if (this.checkInfoRelegation.Checked)
      {
        int min;
        int max;
        this.m_CurrentGroup.Settings.GetInfoSlotReleg(out min, out max);
        if (min <= 0 || max <= 0)
          min = max = 1;
        this.numericRelegationMin.Value = (Decimal) min;
        this.numericRelegationMax.Value = (Decimal) max;
      }
      else
        this.m_CurrentGroup.Settings.SetInfoSlotReleg(-1, -1);
    }

    private void checkInfoPromotion_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.numericPromotionMin.Visible = this.numericPromotionMax.Visible = this.checkInfoPromotion.Checked;
      if (this.checkInfoPromotion.Checked)
      {
        int min;
        int max;
        this.m_CurrentGroup.Settings.GetInfoSlotPromo(out min, out max);
        if (min <= 0 || max <= 0)
          min = max = 1;
        this.numericPromotionMin.Value = (Decimal) min;
        this.numericPromotionMax.Value = (Decimal) max;
      }
      else
        this.m_CurrentGroup.Settings.SetInfoSlotPromo(-1, -1);
    }

    private void checkInfoPossiblePromotion_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.numericPossiblePromotionMin.Visible = this.numericPossiblePromotionMax.Visible = this.checkInfoPossiblePromotion.Checked;
      if (this.checkInfoPossiblePromotion.Checked)
      {
        int min;
        int max;
        this.m_CurrentGroup.Settings.GetInfoSlotPromoPoss(out min, out max);
        if (min <= 0 || max <= 0)
          min = max = 1;
        this.numericPossiblePromotionMin.Value = (Decimal) min;
        this.numericPossiblePromotionMax.Value = (Decimal) max;
      }
      else
        this.m_CurrentGroup.Settings.SetInfoSlotPromoPoss(-1, -1);
    }

    private void numericPossibleRelegationMin_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      int min1 = (int) this.numericPossibleRelegationMin.Value;
      int max1 = (int) this.numericPossibleRelegationMax.Value;
      int min2;
      int max2;
      this.m_CurrentGroup.Settings.GetInfoSlotRelegPoss(out min2, out max2);
      if (min1 == min2 && max1 == max2 || this.m_CurrentGroup.Settings.SetInfoSlotRelegPoss(min1, max1))
        return;
      this.numericPossibleRelegationMin.Value = (Decimal) min2;
    }

    private void numericRelegationMin_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      int min1 = (int) this.numericRelegationMin.Value;
      int max1 = (int) this.numericRelegationMax.Value;
      int min2;
      int max2;
      this.m_CurrentGroup.Settings.GetInfoSlotReleg(out min2, out max2);
      if (min1 == min2 && max1 == max2 || this.m_CurrentGroup.Settings.SetInfoSlotReleg(min1, max1))
        return;
      this.numericRelegationMin.Value = (Decimal) min2;
    }

    private void numericPromotionMin_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      int min1 = (int) this.numericPromotionMin.Value;
      int max1 = (int) this.numericPromotionMax.Value;
      int min2;
      int max2;
      this.m_CurrentGroup.Settings.GetInfoSlotPromo(out min2, out max2);
      if (min1 == min2 && max1 == max2 || this.m_CurrentGroup.Settings.SetInfoSlotPromo(min1, max1))
        return;
      this.numericPromotionMin.Value = (Decimal) min2;
    }

    private void numericPossiblePromotionMin_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      int min1 = (int) this.numericPossiblePromotionMin.Value;
      int max1 = (int) this.numericPossiblePromotionMax.Value;
      int min2;
      int max2;
      this.m_CurrentGroup.Settings.GetInfoSlotPromoPoss(out min2, out max2);
      if (min1 == min2 && max1 == max2 || this.m_CurrentGroup.Settings.SetInfoSlotPromoPoss(min1, max1))
        return;
      this.numericPossiblePromotionMin.Value = (Decimal) min2;
    }

    private void numericPossibleRelegationMax_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      int min1 = (int) this.numericPossibleRelegationMin.Value;
      int max1 = (int) this.numericPossibleRelegationMax.Value;
      int min2;
      int max2;
      this.m_CurrentGroup.Settings.GetInfoSlotRelegPoss(out min2, out max2);
      if (min1 == min2 && max1 == max2 || this.m_CurrentGroup.Settings.SetInfoSlotRelegPoss(min1, max1))
        return;
      this.numericPossibleRelegationMax.Value = (Decimal) max2;
    }

    private void numericRelegationMax_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      int min1 = (int) this.numericRelegationMin.Value;
      int max1 = (int) this.numericRelegationMax.Value;
      int min2;
      int max2;
      this.m_CurrentGroup.Settings.GetInfoSlotReleg(out min2, out max2);
      if (min1 == min2 && max1 == max2 || this.m_CurrentGroup.Settings.SetInfoSlotReleg(min1, max1))
        return;
      this.numericRelegationMax.Value = (Decimal) max2;
    }

    private void numericPromotionMax_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      int min1 = (int) this.numericPromotionMin.Value;
      int max1 = (int) this.numericPromotionMax.Value;
      int min2;
      int max2;
      this.m_CurrentGroup.Settings.GetInfoSlotPromo(out min2, out max2);
      if (min1 == min2 && max1 == max2 || this.m_CurrentGroup.Settings.SetInfoSlotPromo(min1, max1))
        return;
      this.numericPromotionMax.Value = (Decimal) max2;
    }

    private void numericPossiblePromotionMax_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      int min1 = (int) this.numericPossiblePromotionMin.Value;
      int max1 = (int) this.numericPossiblePromotionMax.Value;
      int min2;
      int max2;
      this.m_CurrentGroup.Settings.GetInfoSlotPromoPoss(out min2, out max2);
      if (min1 == min2 && max1 == max2 || this.m_CurrentGroup.Settings.SetInfoSlotPromoPoss(min1, max1))
        return;
      this.numericPossiblePromotionMax.Value = (Decimal) max2;
    }

    private void buttonCleanGroupCalendar_Click(object sender, EventArgs e)
    {
      if (this.m_CurrentGroup == null)
        return;
      this.m_CurrentGroup.RemoveAllSchedules();
      this.GroupToPanel();
    }

    private void buttonCleanStageCalendar_Click(object sender, EventArgs e)
    {
      if (this.m_CurrentStage == null)
        return;
      this.m_CurrentStage.RemoveAllSchedules();
      this.StageToPanel();
    }

    private void buttonNewGroupLeg_Click(object sender, EventArgs e)
    {
      int dayDelay = 7;
      this.m_CurrentGroupSchedule = this.m_CurrentGroupSchedule == null || this.m_CurrentGroup.Schedules.Count == 0 ? this.m_CurrentGroup.AppendLeg(dayDelay) : this.m_CurrentGroup.Schedules.DuplicatetLeg(this.m_CurrentGroupSchedule.Leg, dayDelay);
      this.GroupToPanel();
    }

    private void buttonRemoveGroupLeg_Click(object sender, EventArgs e)
    {
      if (this.m_CurrentGroupSchedule == null)
        return;
      this.m_CurrentGroup.Schedules.RemoveLeg(this.m_CurrentGroupSchedule.Leg);
      this.m_CurrentGroupSchedule = (Schedule) null;
      this.GroupToPanel();
    }

    private void checkMatchReplay_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentStage.Settings.m_schedule_matchreplay = this.checkMatchReplay.Checked ? 1 : -1;
    }

    private void checkMaxteamsassoc_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentStage.Settings.m_advance_maxteamsassoc = this.checkMaxteamsassoc.Checked ? 1 : -1;
    }

    private void numericStageRef_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.m_CurrentStage.Settings.Advance_maxteamsstageref == (int) this.numericStageRef.Value)
        return;
      this.m_CurrentStage.Settings.Advance_maxteamsstageref = (int) this.numericStageRef.Value;
    }

    private void checkClausuraSchedule_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentStage.Settings.m_schedule_reversed = this.checkClausuraSchedule.Checked ? 1 : -1;
    }

    private void probUpDown_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      NumericUpDown numericUpDown = (NumericUpDown) sender;
      string tag = (string) numericUpDown.Tag;
      if (tag == null)
        return;
      int int32 = Convert.ToInt32(tag.Substring(1));
      if (tag.StartsWith("R"))
        this.m_CurrentNation.RainProb[int32] = (int) numericUpDown.Value;
      else if (tag.StartsWith("S"))
      {
        this.m_CurrentNation.SnowProb[int32] = (int) numericUpDown.Value;
      }
      else
      {
        if (!tag.StartsWith("O"))
          return;
        this.m_CurrentNation.OvercastProb[int32] = (int) numericUpDown.Value;
      }
    }

    private void TimeComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      ComboBox comboBox = (ComboBox) sender;
      string tag = (string) comboBox.Tag;
      if (tag == null)
        return;
      int int32 = Convert.ToInt32(tag.Substring(1));
      if (tag.StartsWith("U"))
      {
        this.m_CurrentNation.SunsetTime[int32] = this.ConvertIndexToTime(comboBox.SelectedIndex);
      }
      else
      {
        if (!tag.StartsWith("N"))
          return;
        this.m_CurrentNation.DarkTime[int32] = this.ConvertIndexToTime(comboBox.SelectedIndex);
      }
    }

    private int ConvertIndexToTime(int index)
    {
      switch (index)
      {
        case 0:
          return 1600;
        case 1:
          return 1630;
        case 2:
          return 1700;
        case 3:
          return 1730;
        case 4:
          return 1800;
        case 5:
          return 1830;
        case 6:
          return 1900;
        case 7:
          return 1930;
        case 8:
          return 2000;
        case 9:
          return 2030;
        case 10:
          return 2100;
        default:
          return 0;
      }
    }

    private void numericBall_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.m_CurrentTrophy == null)
        return;
      this.m_CurrentTrophy.ballid = (int) this.numericBall.Value;
      int ballId = (int) this.numericBall.Value;
      if (ballId >= 0)
        this.pictureBall.BackgroundImage = (Image) Ball.GetBallPicture(ballId);
      else
        this.pictureBall.BackgroundImage = (Image) null;
    }

    private void buttonReplicateTrophy128_Click(object sender, EventArgs e)
    {
      Bitmap currentBitmap = this.viewer2DTrophy256.CurrentBitmap;
      Rectangle srcRect = new Rectangle(0, 0, 256, 256);
      Bitmap bitmap = new Bitmap(128, 128, PixelFormat.Format32bppPArgb);
      Rectangle destRect = new Rectangle(0, 0, 128, 128);
      GraphicUtil.RemapRectangle(currentBitmap, srcRect, bitmap, destRect);
      this.m_CurrentTrophy.SetTrophy128(bitmap);
      this.viewer2DTrophy128.CurrentBitmap = bitmap;
    }

    private void buttonShow3DModel_Click(object sender, EventArgs e)
    {
      this.Show3DTrophy();
    }

    private void buttonImport3DModel_Click(object sender, EventArgs e)
    {
      string rx3FileName = FifaEnvironment.BrowseAndCheckModel(ref this.m_TrophyCurrentFolder, "Open 3D Trophy Model file", "3D trophy model files (*.rx3)|trophy_*.rx3");
      if (rx3FileName == null)
        return;
      this.m_CurrentTrophy.SetModel(rx3FileName);
      this.ReloadTrophy(this.m_CurrentTrophy);
    }

    private void buttonExport3DModel_Click(object sender, EventArgs e)
    {
      string fileName = this.m_CurrentTrophy.ModelFileName();
      if (fileName == null)
        return;
      FifaEnvironment.AskAndExportFromZdata(fileName, ref this.m_TrophyCurrentFolder);
    }

    private void buttonRemove3DModel_Click(object sender, EventArgs e)
    {
      this.m_CurrentTrophy.DeleteModel();
      this.ReloadTrophy(this.m_CurrentTrophy);
    }

    private void tabTrophy_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.ReloadTrophy(this.m_CurrentTrophy);
    }

    private void labelUpdateTable_Click(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      Label label = (Label) sender;
      int num = -1;
      Task tag = (Task) label.Tag;
      for (int index = 0; index < this.m_UpdateTableLabels.Length; ++index)
      {
        if (label == this.m_UpdateTableLabels[index])
        {
          num = index;
          break;
        }
      }
      if (num == -1)
        return;
      this.m_RankingRuleDialog.Rank = tag == null || tag.Group == null || (tag.Group.Ranks == null || tag.Parameter2 >= tag.Group.Ranks.Count) ? new Rank((Group) ((Compobj) this.m_CurrentTrophy.Stages[0]).Groups[0], 1) : (Rank) tag.Group.Ranks[tag.Parameter2];
      if (this.m_RankingRuleDialog.ShowDialog() == DialogResult.OK)
      {
        Task task = new Task("end", "UpdateTable", this.m_CurrentTrophy.Id, this.m_RankingRuleDialog.Rank.Group.Id, this.m_RankingRuleDialog.Rank.Id, num + 1);
        task.LinkTrophy(this.m_CurrentTrophy);
        label.Tag = (object) task;
        if (tag == null)
          this.m_CurrentTrophy.AddTask(task);
        else
          this.m_CurrentTrophy.ReplaceTask(tag, task);
      }
      this.TrophyRankingToPanel();
    }

    private void numericUpdateTableEntries_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.numericUpdateTableEntries.Value == (Decimal) this.m_NUpdateTableLabels)
        return;
      for (int index = 0; index < 24; ++index)
        this.m_InitTeamPanel[index].Visible = (Decimal) index < this.numericUpdateTableEntries.Value;
      int num = (int) this.numericUpdateTableEntries.Value;
      if (num < this.m_NUpdateTableLabels)
      {
        for (int index = num; index < this.m_NUpdateTableLabels; ++index)
        {
          Task tag = (Task) this.m_UpdateTableLabels[index].Tag;
          if (tag != null)
          {
            this.m_CurrentTrophy.RemoveTask(tag);
            this.m_UpdateTableLabels[index].Tag = (object) null;
            this.m_UpdateTableLabels[index].Text = (string) null;
          }
        }
      }
      else
      {
        for (int nupdateTableLabels = this.m_NUpdateTableLabels; nupdateTableLabels < num; ++nupdateTableLabels)
        {
          this.m_UpdateTableLabels[nupdateTableLabels].Tag = (object) null;
          this.m_UpdateTableLabels[nupdateTableLabels].Text = (string) null;
        }
      }
      this.m_NUpdateTableLabels = num;
    }

    private void numericInternationalFirstYear_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentTrophy.Settings.m_schedule_year_start = (int) this.numericInternationalFirstYear.Value;
    }

    private void numericInternationalPeriodicity_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentTrophy.Settings.m_schedule_year_offset = (int) this.numericInternationalPeriodicity.Value;
    }

    private void checkClearLeagueStats_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.comboLeagueStats.Visible = this.checkClearLeagueStats.Checked || this.checkUpdateLeagueStats.Checked || this.checkUpdateLeagueTable.Checked;
      if (this.checkClearLeagueStats.Checked)
      {
        League selectedItem = (League) this.comboLeagueStats.SelectedItem;
        if (selectedItem == null)
          return;
        Task task = new Task("start", "ClearLeagueStats", this.m_CurrentStage.Id, selectedItem.Id, 0, 0);
        task.LinkStage(this.m_CurrentStage);
        int index = this.m_CurrentStage.SearchTaskIndex("start", "ClearLeagueStats", -1, -1, -1);
        if (index >= 0)
          this.m_CurrentStage.ReplaceTask(task, index);
        else
          this.m_CurrentStage.AddTask(task);
      }
      else
        this.m_CurrentStage.RemoveTask("start", "ClearLeagueStats", -1, -1, -1);
    }

    private void checkUpdateLeagueStats_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.comboLeagueStats.Visible = this.checkClearLeagueStats.Checked || this.checkUpdateLeagueStats.Checked || this.checkUpdateLeagueTable.Checked;
      if (this.checkUpdateLeagueStats.Checked)
      {
        League selectedItem = (League) this.comboLeagueStats.SelectedItem;
        if (selectedItem == null)
          return;
        Task task = new Task("end", "UpdateLeagueStats", this.m_CurrentStage.Id, selectedItem.Id, 0, 0);
        task.LinkStage(this.m_CurrentStage);
        int index = this.m_CurrentStage.SearchTaskIndex("end", "UpdateLeagueStats", -1, -1, -1);
        if (index >= 0)
          this.m_CurrentStage.ReplaceTask(task, index);
        else
          this.m_CurrentStage.AddTask(task);
      }
      else
        this.m_CurrentStage.RemoveTask("end", "UpdateLeagueStats", -1, -1, -1);
    }

    private void checkUpdateLeagueTable_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.comboLeagueStats.Visible = this.checkClearLeagueStats.Checked || this.checkUpdateLeagueStats.Checked || this.checkUpdateLeagueTable.Checked;
      if (this.checkUpdateLeagueTable.Checked)
      {
        League selectedItem = (League) this.comboLeagueStats.SelectedItem;
        if (selectedItem == null)
          return;
        Task task = new Task("end", "UpdateLeagueTable", this.m_CurrentStage.Id, selectedItem.Id, 0, 0);
        task.LinkStage(this.m_CurrentStage);
        int index = this.m_CurrentStage.SearchTaskIndex("end", "UpdateLeagueTable", -1, -1, -1);
        if (index >= 0)
          this.m_CurrentStage.ReplaceTask(task, index);
        else
          this.m_CurrentStage.AddTask(task);
      }
      else
        this.m_CurrentStage.RemoveTask("end", "UpdateLeagueTable", -1, -1, -1);
    }

    private void comboLeagueStats_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      League selectedItem = (League) this.comboLeagueStats.SelectedItem;
      if (selectedItem == null)
        return;
      if (this.checkClearLeagueStats.Checked)
      {
        Task task = new Task("start", "ClearLeagueStats", this.m_CurrentStage.Id, selectedItem.Id, 0, 0);
        task.LinkStage(this.m_CurrentStage);
        int index = this.m_CurrentStage.SearchTaskIndex("end", "ClearLeagueStats", -1, -1, -1);
        if (index >= 0)
          this.m_CurrentStage.ReplaceTask(task, index);
        else
          this.m_CurrentStage.AddTask(task);
      }
      else
        this.m_CurrentStage.RemoveTask("end", "ClearLeagueStats", -1, -1, -1);
      if (this.checkUpdateLeagueStats.Checked)
      {
        Task task = new Task("end", "UpdateLeagueStats", this.m_CurrentStage.Id, selectedItem.Id, 0, 0);
        task.LinkStage(this.m_CurrentStage);
        int index = this.m_CurrentStage.SearchTaskIndex("end", "UpdateLeagueStats", -1, -1, -1);
        if (index >= 0)
          this.m_CurrentStage.ReplaceTask(task, index);
        else
          this.m_CurrentStage.AddTask(task);
      }
      else
        this.m_CurrentStage.RemoveTask("end", "UpdateLeagueStats", -1, -1, -1);
      if (this.checkUpdateLeagueTable.Checked)
      {
        Task task = new Task("end", "UpdateLeagueTable", this.m_CurrentStage.Id, selectedItem.Id, 0, 0);
        task.LinkStage(this.m_CurrentStage);
        int index = this.m_CurrentStage.SearchTaskIndex("end", "UpdateLeagueTable", -1, -1, -1);
        if (index >= 0)
          this.m_CurrentStage.ReplaceTask(task, index);
        else
          this.m_CurrentStage.AddTask(task);
      }
      else
        this.m_CurrentStage.RemoveTask("end", "UpdateLeagueTable", -1, -1, -1);
    }

    private void checkStageStandingsRules_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.comboStageStandingRules.Visible = this.checkStageStandingsRules.Checked;
      if (this.checkStageStandingsRules.Checked)
        this.m_CurrentStage.Settings.m_StandingsSort = this.comboStageStandingRules.SelectedIndex;
      else
        this.m_CurrentStage.Settings.m_StandingsSort = -1;
    }

    private void comboStageStandingRules_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.comboStageStandingRules.SelectedIndex < 0)
        return;
      this.m_CurrentStage.Settings.m_StandingsSort = this.comboStageStandingRules.SelectedIndex;
    }

    private void comboTrophyStartMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.comboTrophyStartMonth.SelectedItem == null)
        return;
      this.m_CurrentTrophy.Settings.m_schedule_seasonstartmonth = (string) this.comboTrophyStartMonth.SelectedItem;
    }

    private void checkRandomDrawEvent_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel)
        return;
      this.m_CurrentStage.Settings.m_advance_random_draw_event = this.checkRandomDrawEvent.Checked ? 1 : -1;
    }

    private void tabCompetitions_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.m_LockTree)
      {
        this.m_LockTree = true;
        if (this.tabCompetitions.SelectedTab == this.pageWorld)
          this.SelectWorldTreeNode((Compobj) this.m_CurrentWorld);
        else if (this.tabCompetitions.SelectedTab == this.pageConfederation)
          this.SelectWorldTreeNode((Compobj) this.m_CurrentConfederation);
        else if (this.tabCompetitions.SelectedTab == this.pageNation)
          this.SelectWorldTreeNode((Compobj) this.m_CurrentNation);
        else if (this.tabCompetitions.SelectedTab == this.pageTrophy)
          this.SelectWorldTreeNode((Compobj) this.m_CurrentTrophy);
        else if (this.tabCompetitions.SelectedTab == this.pageStage)
          this.SelectWorldTreeNode((Compobj) this.m_CurrentStage);
        else if (this.tabCompetitions.SelectedTab == this.pageGroup)
          this.SelectWorldTreeNode((Compobj) this.m_CurrentGroup);
        this.m_LockTree = false;
      }
      this.CompetitionToPanel();
    }

    private void CompetitionToPanel()
    {
      if (this.tabCompetitions.SelectedTab == this.pageWorld)
        this.WorldToPanel();
      else if (this.tabCompetitions.SelectedTab == this.pageConfederation)
        this.ConfederationToPanel();
      else if (this.tabCompetitions.SelectedTab == this.pageNation)
        this.NationToPanel();
      else if (this.tabCompetitions.SelectedTab == this.pageTrophy)
        this.TrophyToPanel();
      else if (this.tabCompetitions.SelectedTab == this.pageStage)
      {
        this.StageToPanel();
      }
      else
      {
        if (this.tabCompetitions.SelectedTab != this.pageGroup)
          return;
        this.GroupToPanel();
      }
    }

    private void buttongroupSortLegs_Click(object sender, EventArgs e)
    {
      if (this.m_CurrentGroup == null || this.m_CurrentGroup.Schedules == null)
        return;
      this.m_CurrentGroup.Schedules.RenumberLegs();
      this.GroupToPanel();
    }

    private void buttonStageSortLegs_Click(object sender, EventArgs e)
    {
      if (this.m_CurrentStage == null || this.m_CurrentStage.Schedules == null)
        return;
      this.m_CurrentStage.Schedules.RenumberLegs();
      this.StageToPanel();
    }

    private void checkScheduleUseDates_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.checkScheduleUseDates.Checked == (this.m_CurrentTrophy.Settings.m_schedule_use_dates_comp != -1))
        return;
      this.m_CurrentTrophy.Settings.m_schedule_use_dates_comp = this.checkScheduleUseDates.Checked ? FifaEnvironment.CompetitionObjects.GetInternationalFriendlyId() : -1;
    }

    private void numericKeepPointsStageRef_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_LockToPanel || this.m_CurrentStage.Settings.Advance_pointskeep == (int) this.numericKeepPointsStageRef.Value)
        return;
      this.m_CurrentStage.Settings.Advance_pointskeep = (int) this.numericKeepPointsStageRef.Value;
    }

    private void buttonReplicateTropy_Click(object sender, EventArgs e)
    {
      Bitmap currentBitmap = this.viewer2DTrophy256.CurrentBitmap;
      Rectangle srcRect = new Rectangle(0, 0, 256, 256);
      Bitmap bitmap = new Bitmap(256, 256, PixelFormat.Format32bppPArgb);
      Rectangle destRect = new Rectangle(0, 0, 192, 192);
      GraphicUtil.RemapRectangle(currentBitmap, srcRect, bitmap, destRect);
      this.m_CurrentTrophy.SetTrophy(bitmap);
      this.viewer2DTrophy.CurrentBitmap = bitmap;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager resources = new ComponentResourceManager(typeof (CompetitionForm));
      this.treeWorld = new TreeView();
      this.groupConfederation = new GroupBox();
      this.comboConfederationStartingMonth = new ComboBox();
      this.labelConfStartMonth = new Label();
      this.groupNation = new GroupBox();
      this.groupWeather = new GroupBox();
      this.toolWeather = new ToolStrip();
      this.buttonCopyWeather = new ToolStripButton();
      this.buttonPasteWeather = new ToolStripButton();
      this.comboBox23 = new ComboBox();
      this.comboBox24 = new ComboBox();
      this.numericUpDown34 = new NumericUpDown();
      this.numericUpDown35 = new NumericUpDown();
      this.numericUpDown36 = new NumericUpDown();
      this.comboBox21 = new ComboBox();
      this.comboBox22 = new ComboBox();
      this.numericUpDown31 = new NumericUpDown();
      this.numericUpDown32 = new NumericUpDown();
      this.numericUpDown33 = new NumericUpDown();
      this.comboBox19 = new ComboBox();
      this.comboBox20 = new ComboBox();
      this.numericUpDown28 = new NumericUpDown();
      this.numericUpDown29 = new NumericUpDown();
      this.numericUpDown30 = new NumericUpDown();
      this.comboBox17 = new ComboBox();
      this.comboBox18 = new ComboBox();
      this.numericUpDown25 = new NumericUpDown();
      this.numericUpDown26 = new NumericUpDown();
      this.numericUpDown27 = new NumericUpDown();
      this.comboBox15 = new ComboBox();
      this.comboBox16 = new ComboBox();
      this.numericUpDown22 = new NumericUpDown();
      this.numericUpDown23 = new NumericUpDown();
      this.numericUpDown24 = new NumericUpDown();
      this.comboBox13 = new ComboBox();
      this.comboBox14 = new ComboBox();
      this.numericUpDown19 = new NumericUpDown();
      this.numericUpDown20 = new NumericUpDown();
      this.numericUpDown21 = new NumericUpDown();
      this.comboBox11 = new ComboBox();
      this.comboBox12 = new ComboBox();
      this.numericUpDown16 = new NumericUpDown();
      this.numericUpDown17 = new NumericUpDown();
      this.numericUpDown18 = new NumericUpDown();
      this.comboBox9 = new ComboBox();
      this.comboBox10 = new ComboBox();
      this.numericUpDown13 = new NumericUpDown();
      this.numericUpDown14 = new NumericUpDown();
      this.numericUpDown15 = new NumericUpDown();
      this.comboBox7 = new ComboBox();
      this.comboBox8 = new ComboBox();
      this.numericUpDown10 = new NumericUpDown();
      this.numericUpDown11 = new NumericUpDown();
      this.numericUpDown12 = new NumericUpDown();
      this.comboBox5 = new ComboBox();
      this.comboBox6 = new ComboBox();
      this.numericUpDown7 = new NumericUpDown();
      this.numericUpDown8 = new NumericUpDown();
      this.numericUpDown9 = new NumericUpDown();
      this.comboBox3 = new ComboBox();
      this.comboBox4 = new ComboBox();
      this.numericUpDown4 = new NumericUpDown();
      this.numericUpDown5 = new NumericUpDown();
      this.numericUpDown6 = new NumericUpDown();
      this.comboBox1 = new ComboBox();
      this.comboBox2 = new ComboBox();
      this.numericUpDown1 = new NumericUpDown();
      this.numericUpDown2 = new NumericUpDown();
      this.numericUpDown3 = new NumericUpDown();
      this.label33 = new Label();
      this.label32 = new Label();
      this.label31 = new Label();
      this.label30 = new Label();
      this.label29 = new Label();
      this.label28 = new Label();
      this.label27 = new Label();
      this.label26 = new Label();
      this.label25 = new Label();
      this.label24 = new Label();
      this.label23 = new Label();
      this.label22 = new Label();
      this.label21 = new Label();
      this.label20 = new Label();
      this.label19 = new Label();
      this.label18 = new Label();
      this.label17 = new Label();
      this.label6 = new Label();
      this.label5 = new Label();
      this.labelDatabaseCountry = new Label();
      this.comboCountry = new ComboBox();
      this.comboNationStandingsRules = new ComboBox();
      this.checkNationStandingsRules = new CheckBox();
      this.numericNationYellowsStored = new NumericUpDown();
      this.comboNationStartMonth = new ComboBox();
      this.groupTrophy = new GroupBox();
      this.groupInternationalschedule = new GroupBox();
      this.label71 = new Label();
      this.comboTrophyStartMonth = new ComboBox();
      this.numericInternationalPeriodicity = new NumericUpDown();
      this.label69 = new Label();
      this.label68 = new Label();
      this.numericInternationalFirstYear = new NumericUpDown();
      this.label67 = new Label();
      this.numericBall = new NumericUpDown();
      this.pictureBall = new PictureBox();
      this.groupBenchPlayers = new GroupBox();
      this.radioBench7Players = new RadioButton();
      this.radioBench5Players = new RadioButton();
      this.comboTrophyStandingRules = new ComboBox();
      this.labelTrophyShortName = new Label();
      this.labelMatchImportance = new Label();
      this.labelCompetitionType = new Label();
      this.numericImportance = new NumericUpDown();
      this.labelAssetId = new Label();
      this.comboCompetitionType = new ComboBox();
      this.checkTrophyStandingsRules = new CheckBox();
      this.buttonGetId = new Button();
      this.groupPromotionRelegation = new GroupBox();
      this.comboRelegationLeague = new ComboBox();
      this.comboPromotionLeague = new ComboBox();
      this.checkPromotionLeague = new CheckBox();
      this.checkRelegationLeague = new CheckBox();
      this.numericAssetId = new NumericUpDown();
      this.groupSchedule = new GroupBox();
      this.checkScheduleUseDates = new CheckBox();
      this.checkScheduleConflicts = new CheckBox();
      this.comboSchedForce = new ComboBox();
      this.checkForceSchedule = new CheckBox();
      this.textTrophyLongName = new TextBox();
      this.labeTrophylLongName = new Label();
      this.textTrophyShortName = new TextBox();
      this.groupStage = new GroupBox();
      this.groupSetupStage = new GroupBox();
      this.checkRandomDraw = new CheckBox();
      this.groupBox2 = new GroupBox();
      this.comboSpecialTeam4 = new ComboBox();
      this.comboSpecialTeam3 = new ComboBox();
      this.comboSpecialTeam2 = new ComboBox();
      this.comboSpecialTeam1 = new ComboBox();
      this.checkCalccompavgs = new CheckBox();
      this.groupPlayStage = new GroupBox();
      this.numericKeepPointsStageRef = new NumericUpDown();
      this.checkRandomDrawEvent = new CheckBox();
      this.groupLeaguetasks = new GroupBox();
      this.checkUpdateLeagueTable = new CheckBox();
      this.comboLeagueStats = new ComboBox();
      this.checkUpdateLeagueStats = new CheckBox();
      this.checkClearLeagueStats = new CheckBox();
      this.groupStageSchedules = new GroupBox();
      this.treeStageSchedule = new TreeView();
      this.panelStageScheduleDetails = new Panel();
      this.groupStageScheduleDetails = new GroupBox();
      this.dateStagePicker = new DateTimePicker();
      this.label37 = new Label();
      this.numericStageMinGames = new NumericUpDown();
      this.label36 = new Label();
      this.numericStageMaxGames = new NumericUpDown();
      this.label35 = new Label();
      this.comboStageTime = new ComboBox();
      this.label34 = new Label();
      this.toolStageSchedule = new ToolStrip();
      this.buttonCopyStageCalendar = new ToolStripButton();
      this.buttonPasteStageCalendar = new ToolStripButton();
      this.buttonCleanStageCalendar = new ToolStripButton();
      this.buttonNeewStageLeg = new ToolStripButton();
      this.buttonDeleteStageLeg = new ToolStripButton();
      this.buttonStageAddTime = new ToolStripButton();
      this.buttonStageRemoveTime = new ToolStripButton();
      this.buttonStageSortLegs = new ToolStripButton();
      this.numericRegularSeason = new NumericUpDown();
      this.comboSpecialKo2Rule = new ComboBox();
      this.checkSpecialKo2Rule = new CheckBox();
      this.comboSpecialKo1Rule = new ComboBox();
      this.checkSpecialKo1Rule = new CheckBox();
      this.numericKeepPointsPercentage = new NumericUpDown();
      this.checkKeepPointsPercentage = new CheckBox();
      this.numericStageRef = new NumericUpDown();
      this.checkClausuraSchedule = new CheckBox();
      this.groupStadiums = new GroupBox();
      this.comboStadium12 = new ComboBox();
      this.comboStadium11 = new ComboBox();
      this.comboStadium10 = new ComboBox();
      this.comboStadium9 = new ComboBox();
      this.comboStadium8 = new ComboBox();
      this.comboStadium7 = new ComboBox();
      this.comboStadium6 = new ComboBox();
      this.comboStadium5 = new ComboBox();
      this.comboStadium4 = new ComboBox();
      this.comboStadium3 = new ComboBox();
      this.comboStadium2 = new ComboBox();
      this.comboStadium1 = new ComboBox();
      this.checkMaxteamsgroup = new CheckBox();
      this.checkMatchReplay = new CheckBox();
      this.numericMoneyDrop = new NumericUpDown();
      this.checkMaxteamsassoc = new CheckBox();
      this.label10 = new Label();
      this.numericPrizeMoney = new NumericUpDown();
      this.label9 = new Label();
      this.comboMatchSituation = new ComboBox();
      this.label8 = new Label();
      this.comboStageStandingRules = new ComboBox();
      this.checkStageStandingsRules = new CheckBox();
      this.numericStandingsRank = new NumericUpDown();
      this.checkStandingsRank = new CheckBox();
      this.comboStageType = new ComboBox();
      this.label7 = new Label();
      this.numericStandingKeep = new NumericUpDown();
      this.checkStandingKeep = new CheckBox();
      this.toolTip = new ToolTip(this.components);
      this.toolCompetitionTree = new ToolStrip();
      this.buttonAddTrophy = new ToolStripButton();
      this.buttonDeleteTrophy = new ToolStripButton();
      this.buttonAddStage = new ToolStripButton();
      this.buttonDeleteStage = new ToolStripButton();
      this.buttonAddGroup = new ToolStripButton();
      this.buttonDeleteGroup = new ToolStripButton();
      this.buttonAddNatiom = new ToolStripButton();
      this.buttonDeleteNation = new ToolStripButton();
      this.buttonPasteTrophy = new ToolStripButton();
      this.buttonCopyTrophy = new ToolStripButton();
      this.comboTargetLeague = new ToolStripComboBox();
      this.splitContainer1 = new SplitContainer();
      this.tabCompetitions = new TabControl();
      this.pageWorld = new TabPage();
      this.numericStartYear = new NumericUpDown();
      this.label13 = new Label();
      this.pageConfederation = new TabPage();
      this.pageNation = new TabPage();
      this.pageTrophy = new TabPage();
      this.tabTrophy = new TabControl();
      this.tabPageTrophyStructure = new TabPage();
      this.tabPageRankingTable = new TabPage();
      this.groupInitTeams = new GroupBox();
      this.label70 = new Label();
      this.numericUpdateTableEntries = new NumericUpDown();
      this.panelInitTeam24 = new Panel();
      this.labelUpdateTable24 = new Label();
      this.comboInitTeam24 = new ComboBox();
      this.label65 = new Label();
      this.panelInitTeam23 = new Panel();
      this.labelUpdateTable23 = new Label();
      this.comboInitTeam23 = new ComboBox();
      this.label64 = new Label();
      this.panelInitTeam22 = new Panel();
      this.labelUpdateTable22 = new Label();
      this.comboInitTeam22 = new ComboBox();
      this.label63 = new Label();
      this.panelInitTeam21 = new Panel();
      this.labelUpdateTable21 = new Label();
      this.comboInitTeam21 = new ComboBox();
      this.label62 = new Label();
      this.panelInitTeam20 = new Panel();
      this.labelUpdateTable20 = new Label();
      this.comboInitTeam20 = new ComboBox();
      this.label61 = new Label();
      this.panelInitTeam19 = new Panel();
      this.labelUpdateTable19 = new Label();
      this.comboInitTeam19 = new ComboBox();
      this.label60 = new Label();
      this.panelInitTeam18 = new Panel();
      this.labelUpdateTable18 = new Label();
      this.comboInitTeam18 = new ComboBox();
      this.label59 = new Label();
      this.panelInitTeam17 = new Panel();
      this.labelUpdateTable17 = new Label();
      this.comboInitTeam17 = new ComboBox();
      this.label58 = new Label();
      this.panelInitTeam16 = new Panel();
      this.labelUpdateTable16 = new Label();
      this.comboInitTeam16 = new ComboBox();
      this.label57 = new Label();
      this.panelInitTeam15 = new Panel();
      this.labelUpdateTable15 = new Label();
      this.comboInitTeam15 = new ComboBox();
      this.label56 = new Label();
      this.panelInitTeam14 = new Panel();
      this.labelUpdateTable14 = new Label();
      this.comboInitTeam14 = new ComboBox();
      this.label55 = new Label();
      this.panelInitTeam13 = new Panel();
      this.labelUpdateTable13 = new Label();
      this.comboInitTeam13 = new ComboBox();
      this.label54 = new Label();
      this.panelInitTeam12 = new Panel();
      this.labelUpdateTable12 = new Label();
      this.comboInitTeam12 = new ComboBox();
      this.label53 = new Label();
      this.panelInitTeam11 = new Panel();
      this.labelUpdateTable11 = new Label();
      this.comboInitTeam11 = new ComboBox();
      this.label52 = new Label();
      this.panelInitTeam10 = new Panel();
      this.labelUpdateTable10 = new Label();
      this.comboInitTeam10 = new ComboBox();
      this.label51 = new Label();
      this.panelInitTeam9 = new Panel();
      this.labelUpdateTable9 = new Label();
      this.comboInitTeam9 = new ComboBox();
      this.label50 = new Label();
      this.panelInitTeam8 = new Panel();
      this.labelUpdateTable8 = new Label();
      this.comboInitTeam8 = new ComboBox();
      this.label49 = new Label();
      this.panelInitTeam7 = new Panel();
      this.labelUpdateTable7 = new Label();
      this.comboInitTeam7 = new ComboBox();
      this.label48 = new Label();
      this.panelInitTeam6 = new Panel();
      this.labelUpdateTable6 = new Label();
      this.comboInitTeam6 = new ComboBox();
      this.label47 = new Label();
      this.panelInitTeam5 = new Panel();
      this.labelUpdateTable5 = new Label();
      this.comboInitTeam5 = new ComboBox();
      this.label46 = new Label();
      this.panelInitTeam4 = new Panel();
      this.labelUpdateTable4 = new Label();
      this.comboInitTeam4 = new ComboBox();
      this.label45 = new Label();
      this.panelInitTeam3 = new Panel();
      this.labelUpdateTable3 = new Label();
      this.comboInitTeam3 = new ComboBox();
      this.label44 = new Label();
      this.panelInitTeam2 = new Panel();
      this.labelUpdateTable2 = new Label();
      this.comboInitTeam2 = new ComboBox();
      this.label43 = new Label();
      this.panelInitTeam1 = new Panel();
      this.labelUpdateTable1 = new Label();
      this.comboInitTeam1 = new ComboBox();
      this.label42 = new Label();
      this.tabPageTrophyGraphics = new TabPage();
      this.groupGraphics = new GroupBox();
      this.buttonReplicateTropy = new Button();
      this.viewer2DTrophy = new Viewer2D();
      this.buttonReplicateTrophy128 = new Button();
      this.viewer2DTrophy128 = new Viewer2D();
      this.multiViewer2DTextures = new MultiViewer2D();
      this.group3D = new GroupBox();
      this.viewer3D = new Viewer3D();
      this.toolNear3D = new ToolStrip();
      this.buttonShow3DModel = new ToolStripButton();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.buttonImport3DModel = new ToolStripButton();
      this.buttonExport3DModel = new ToolStripButton();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.buttonRemove3DModel = new ToolStripButton();
      this.viewer2DTrophy256 = new Viewer2D();
      this.pageStage = new TabPage();
      this.pageGroup = new TabPage();
      this.groupGroup = new GroupBox();
      this.groupRules = new GroupBox();
      this.panelQualificationRules = new Panel();
      this.toolRules = new ToolStrip();
      this.buttonAddRule = new ToolStripButton();
      this.buttonRemoveRule = new ToolStripButton();
      this.panelAdvancement = new Panel();
      this.groupPlayGroup = new GroupBox();
      this.numericNumGames = new NumericUpDown();
      this.label14 = new Label();
      this.groupGroupScheduke = new GroupBox();
      this.treeGroupSchedule = new TreeView();
      this.panelGroupScheduleDetails = new Panel();
      this.groupGroupScheduleDetails = new GroupBox();
      this.dateGroupPicker = new DateTimePicker();
      this.label38 = new Label();
      this.numericGroupMinGames = new NumericUpDown();
      this.label39 = new Label();
      this.numericGroupMaxGames = new NumericUpDown();
      this.label40 = new Label();
      this.comboGroupTime = new ComboBox();
      this.label41 = new Label();
      this.toolGroupSchedule = new ToolStrip();
      this.buttonCopyGroupCalendar = new ToolStripButton();
      this.buttonPasteGroupCalendar = new ToolStripButton();
      this.buttonCleanGroupCalendar = new ToolStripButton();
      this.buttonNewGroupLeg = new ToolStripButton();
      this.buttonRemoveGroupLeg = new ToolStripButton();
      this.buttonGroupAddTime = new ToolStripButton();
      this.buttonGroupRemoveTime = new ToolStripButton();
      this.buttongroupSortLegs = new ToolStripButton();
      this.groupSlots = new GroupBox();
      this.numericPossiblePromotionMax = new NumericUpDown();
      this.checkInfoPossiblePromotion = new CheckBox();
      this.numericPossiblePromotionMin = new NumericUpDown();
      this.numericPromotionMax = new NumericUpDown();
      this.numericPromotionMin = new NumericUpDown();
      this.numericRelegationMax = new NumericUpDown();
      this.numericRelegationMin = new NumericUpDown();
      this.numericPossibleRelegationMax = new NumericUpDown();
      this.numericPossibleRelegationMin = new NumericUpDown();
      this.label15 = new Label();
      this.label16 = new Label();
      this.checkInfoPromotion = new CheckBox();
      this.checkInfoRelegation = new CheckBox();
      this.checkInfoPossibleRelegation = new CheckBox();
      this.checkInfoChamp = new CheckBox();
      this.groupInfoColors = new GroupBox();
      this.numericColorPossiblePromotionMax = new NumericUpDown();
      this.checkInfoColorPossiblePromotion = new CheckBox();
      this.numericColorAdvanceMax = new NumericUpDown();
      this.numericColorPossiblePromotionMin = new NumericUpDown();
      this.numericColorAdvanceMin = new NumericUpDown();
      this.numericColorPromotionMax = new NumericUpDown();
      this.numericColorPromotionMin = new NumericUpDown();
      this.numericColorRelegationMax = new NumericUpDown();
      this.numericColorRelegationMin = new NumericUpDown();
      this.numericColorPossibleRelegationMax = new NumericUpDown();
      this.numericColorPossibleRelegationMin = new NumericUpDown();
      this.numericColorEuropaMax = new NumericUpDown();
      this.numericColorEuropaMin = new NumericUpDown();
      this.numericColorChampionsMax = new NumericUpDown();
      this.numericColorChampionsMin = new NumericUpDown();
      this.label12 = new Label();
      this.label11 = new Label();
      this.checkInfoColorAdvance = new CheckBox();
      this.checkInfoColorPromotion = new CheckBox();
      this.checkInfoColorRelegation = new CheckBox();
      this.checkInfoColorPossibleRelegation = new CheckBox();
      this.checkInfoColorEuropa = new CheckBox();
      this.checkInfoColorChampions = new CheckBox();
      this.checkInfoColorChamp = new CheckBox();
      this.label4 = new Label();
      this.numericNTeams = new NumericUpDown();
      this.panelCompObj = new Panel();
      this.textLanguageName = new TextBox();
      this.label66 = new Label();
      this.textUniqueId = new TextBox();
      this.comboLanguageKey = new ComboBox();
      this.label3 = new Label();
      this.textLanguageKey = new TextBox();
      this.label2 = new Label();
      this.textFourCharName = new TextBox();
      this.label1 = new Label();
      this.groupConfederation.SuspendLayout();
      this.groupNation.SuspendLayout();
      this.groupWeather.SuspendLayout();
      this.toolWeather.SuspendLayout();
      this.numericUpDown34.BeginInit();
      this.numericUpDown35.BeginInit();
      this.numericUpDown36.BeginInit();
      this.numericUpDown31.BeginInit();
      this.numericUpDown32.BeginInit();
      this.numericUpDown33.BeginInit();
      this.numericUpDown28.BeginInit();
      this.numericUpDown29.BeginInit();
      this.numericUpDown30.BeginInit();
      this.numericUpDown25.BeginInit();
      this.numericUpDown26.BeginInit();
      this.numericUpDown27.BeginInit();
      this.numericUpDown22.BeginInit();
      this.numericUpDown23.BeginInit();
      this.numericUpDown24.BeginInit();
      this.numericUpDown19.BeginInit();
      this.numericUpDown20.BeginInit();
      this.numericUpDown21.BeginInit();
      this.numericUpDown16.BeginInit();
      this.numericUpDown17.BeginInit();
      this.numericUpDown18.BeginInit();
      this.numericUpDown13.BeginInit();
      this.numericUpDown14.BeginInit();
      this.numericUpDown15.BeginInit();
      this.numericUpDown10.BeginInit();
      this.numericUpDown11.BeginInit();
      this.numericUpDown12.BeginInit();
      this.numericUpDown7.BeginInit();
      this.numericUpDown8.BeginInit();
      this.numericUpDown9.BeginInit();
      this.numericUpDown4.BeginInit();
      this.numericUpDown5.BeginInit();
      this.numericUpDown6.BeginInit();
      this.numericUpDown1.BeginInit();
      this.numericUpDown2.BeginInit();
      this.numericUpDown3.BeginInit();
      this.numericNationYellowsStored.BeginInit();
      this.groupTrophy.SuspendLayout();
      this.groupInternationalschedule.SuspendLayout();
      this.numericInternationalPeriodicity.BeginInit();
      this.numericInternationalFirstYear.BeginInit();
      this.numericBall.BeginInit();
      ((ISupportInitialize) this.pictureBall).BeginInit();
      this.groupBenchPlayers.SuspendLayout();
      this.numericImportance.BeginInit();
      this.groupPromotionRelegation.SuspendLayout();
      this.numericAssetId.BeginInit();
      this.groupSchedule.SuspendLayout();
      this.groupStage.SuspendLayout();
      this.groupSetupStage.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupPlayStage.SuspendLayout();
      this.numericKeepPointsStageRef.BeginInit();
      this.groupLeaguetasks.SuspendLayout();
      this.groupStageSchedules.SuspendLayout();
      this.panelStageScheduleDetails.SuspendLayout();
      this.groupStageScheduleDetails.SuspendLayout();
      this.numericStageMinGames.BeginInit();
      this.numericStageMaxGames.BeginInit();
      this.toolStageSchedule.SuspendLayout();
      this.numericRegularSeason.BeginInit();
      this.numericKeepPointsPercentage.BeginInit();
      this.numericStageRef.BeginInit();
      this.groupStadiums.SuspendLayout();
      this.numericMoneyDrop.BeginInit();
      this.numericPrizeMoney.BeginInit();
      this.numericStandingsRank.BeginInit();
      this.numericStandingKeep.BeginInit();
      this.toolCompetitionTree.SuspendLayout();
      this.splitContainer1.BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.tabCompetitions.SuspendLayout();
      this.pageWorld.SuspendLayout();
      this.numericStartYear.BeginInit();
      this.pageConfederation.SuspendLayout();
      this.pageNation.SuspendLayout();
      this.pageTrophy.SuspendLayout();
      this.tabTrophy.SuspendLayout();
      this.tabPageTrophyStructure.SuspendLayout();
      this.tabPageRankingTable.SuspendLayout();
      this.groupInitTeams.SuspendLayout();
      this.numericUpdateTableEntries.BeginInit();
      this.panelInitTeam24.SuspendLayout();
      this.panelInitTeam23.SuspendLayout();
      this.panelInitTeam22.SuspendLayout();
      this.panelInitTeam21.SuspendLayout();
      this.panelInitTeam20.SuspendLayout();
      this.panelInitTeam19.SuspendLayout();
      this.panelInitTeam18.SuspendLayout();
      this.panelInitTeam17.SuspendLayout();
      this.panelInitTeam16.SuspendLayout();
      this.panelInitTeam15.SuspendLayout();
      this.panelInitTeam14.SuspendLayout();
      this.panelInitTeam13.SuspendLayout();
      this.panelInitTeam12.SuspendLayout();
      this.panelInitTeam11.SuspendLayout();
      this.panelInitTeam10.SuspendLayout();
      this.panelInitTeam9.SuspendLayout();
      this.panelInitTeam8.SuspendLayout();
      this.panelInitTeam7.SuspendLayout();
      this.panelInitTeam6.SuspendLayout();
      this.panelInitTeam5.SuspendLayout();
      this.panelInitTeam4.SuspendLayout();
      this.panelInitTeam3.SuspendLayout();
      this.panelInitTeam2.SuspendLayout();
      this.panelInitTeam1.SuspendLayout();
      this.tabPageTrophyGraphics.SuspendLayout();
      this.groupGraphics.SuspendLayout();
      this.group3D.SuspendLayout();
      this.toolNear3D.SuspendLayout();
      this.pageStage.SuspendLayout();
      this.pageGroup.SuspendLayout();
      this.groupGroup.SuspendLayout();
      this.groupRules.SuspendLayout();
      this.panelQualificationRules.SuspendLayout();
      this.toolRules.SuspendLayout();
      this.groupPlayGroup.SuspendLayout();
      this.numericNumGames.BeginInit();
      this.groupGroupScheduke.SuspendLayout();
      this.panelGroupScheduleDetails.SuspendLayout();
      this.groupGroupScheduleDetails.SuspendLayout();
      this.numericGroupMinGames.BeginInit();
      this.numericGroupMaxGames.BeginInit();
      this.toolGroupSchedule.SuspendLayout();
      this.groupSlots.SuspendLayout();
      this.numericPossiblePromotionMax.BeginInit();
      this.numericPossiblePromotionMin.BeginInit();
      this.numericPromotionMax.BeginInit();
      this.numericPromotionMin.BeginInit();
      this.numericRelegationMax.BeginInit();
      this.numericRelegationMin.BeginInit();
      this.numericPossibleRelegationMax.BeginInit();
      this.numericPossibleRelegationMin.BeginInit();
      this.groupInfoColors.SuspendLayout();
      this.numericColorPossiblePromotionMax.BeginInit();
      this.numericColorAdvanceMax.BeginInit();
      this.numericColorPossiblePromotionMin.BeginInit();
      this.numericColorAdvanceMin.BeginInit();
      this.numericColorPromotionMax.BeginInit();
      this.numericColorPromotionMin.BeginInit();
      this.numericColorRelegationMax.BeginInit();
      this.numericColorRelegationMin.BeginInit();
      this.numericColorPossibleRelegationMax.BeginInit();
      this.numericColorPossibleRelegationMin.BeginInit();
      this.numericColorEuropaMax.BeginInit();
      this.numericColorEuropaMin.BeginInit();
      this.numericColorChampionsMax.BeginInit();
      this.numericColorChampionsMin.BeginInit();
      this.numericNTeams.BeginInit();
      this.panelCompObj.SuspendLayout();
      this.SuspendLayout();
      this.treeWorld.Dock = DockStyle.Fill;
      this.treeWorld.FullRowSelect = true;
      this.treeWorld.HideSelection = false;
      this.treeWorld.Location = new Point(0, 52);
      this.treeWorld.Name = "treeWorld";
      this.treeWorld.Size = new Size(285, 728);
      this.treeWorld.TabIndex = 6;
      this.treeWorld.AfterSelect += new TreeViewEventHandler(this.treeWorld_AfterSelect);
      this.groupConfederation.Controls.Add((Control) this.comboConfederationStartingMonth);
      this.groupConfederation.Controls.Add((Control) this.labelConfStartMonth);
      this.groupConfederation.Location = new Point(3, 3);
      this.groupConfederation.Name = "groupConfederation";
      this.groupConfederation.Size = new Size(291, 71);
      this.groupConfederation.TabIndex = 7;
      this.groupConfederation.TabStop = false;
      this.groupConfederation.Text = "Confederation";
      this.groupConfederation.Visible = false;
      this.comboConfederationStartingMonth.FormattingEnabled = true;
      this.comboConfederationStartingMonth.Items.AddRange(new object[12]
      {
        (object) "JAN",
        (object) "FEB",
        (object) "MAR",
        (object) "APR",
        (object) "MAY",
        (object) "JUN",
        (object) "JUL",
        (object) "AUG",
        (object) "SEP",
        (object) "OCT",
        (object) "NOV",
        (object) "DEC"
      });
      this.comboConfederationStartingMonth.Location = new Point(162, 21);
      this.comboConfederationStartingMonth.Name = "comboConfederationStartingMonth";
      this.comboConfederationStartingMonth.Size = new Size(90, 21);
      this.comboConfederationStartingMonth.TabIndex = 1;
      this.comboConfederationStartingMonth.SelectedIndexChanged += new EventHandler(this.comboConfederationStartingMonth_SelectedIndexChanged);
      this.labelConfStartMonth.AutoSize = true;
      this.labelConfStartMonth.Location = new Point(6, 27);
      this.labelConfStartMonth.Name = "labelConfStartMonth";
      this.labelConfStartMonth.Size = new Size(101, 13);
      this.labelConfStartMonth.TabIndex = 0;
      this.labelConfStartMonth.Text = "Season Start Month";
      this.groupNation.Controls.Add((Control) this.groupWeather);
      this.groupNation.Controls.Add((Control) this.label6);
      this.groupNation.Controls.Add((Control) this.label5);
      this.groupNation.Controls.Add((Control) this.labelDatabaseCountry);
      this.groupNation.Controls.Add((Control) this.comboCountry);
      this.groupNation.Controls.Add((Control) this.comboNationStandingsRules);
      this.groupNation.Controls.Add((Control) this.checkNationStandingsRules);
      this.groupNation.Controls.Add((Control) this.numericNationYellowsStored);
      this.groupNation.Controls.Add((Control) this.comboNationStartMonth);
      this.groupNation.Location = new Point(3, 3);
      this.groupNation.Name = "groupNation";
      this.groupNation.Size = new Size(495, 599);
      this.groupNation.TabIndex = 8;
      this.groupNation.TabStop = false;
      this.groupNation.Text = "Nation";
      this.groupNation.Visible = false;
      this.groupWeather.Controls.Add((Control) this.toolWeather);
      this.groupWeather.Controls.Add((Control) this.comboBox23);
      this.groupWeather.Controls.Add((Control) this.comboBox24);
      this.groupWeather.Controls.Add((Control) this.numericUpDown34);
      this.groupWeather.Controls.Add((Control) this.numericUpDown35);
      this.groupWeather.Controls.Add((Control) this.numericUpDown36);
      this.groupWeather.Controls.Add((Control) this.comboBox21);
      this.groupWeather.Controls.Add((Control) this.comboBox22);
      this.groupWeather.Controls.Add((Control) this.numericUpDown31);
      this.groupWeather.Controls.Add((Control) this.numericUpDown32);
      this.groupWeather.Controls.Add((Control) this.numericUpDown33);
      this.groupWeather.Controls.Add((Control) this.comboBox19);
      this.groupWeather.Controls.Add((Control) this.comboBox20);
      this.groupWeather.Controls.Add((Control) this.numericUpDown28);
      this.groupWeather.Controls.Add((Control) this.numericUpDown29);
      this.groupWeather.Controls.Add((Control) this.numericUpDown30);
      this.groupWeather.Controls.Add((Control) this.comboBox17);
      this.groupWeather.Controls.Add((Control) this.comboBox18);
      this.groupWeather.Controls.Add((Control) this.numericUpDown25);
      this.groupWeather.Controls.Add((Control) this.numericUpDown26);
      this.groupWeather.Controls.Add((Control) this.numericUpDown27);
      this.groupWeather.Controls.Add((Control) this.comboBox15);
      this.groupWeather.Controls.Add((Control) this.comboBox16);
      this.groupWeather.Controls.Add((Control) this.numericUpDown22);
      this.groupWeather.Controls.Add((Control) this.numericUpDown23);
      this.groupWeather.Controls.Add((Control) this.numericUpDown24);
      this.groupWeather.Controls.Add((Control) this.comboBox13);
      this.groupWeather.Controls.Add((Control) this.comboBox14);
      this.groupWeather.Controls.Add((Control) this.numericUpDown19);
      this.groupWeather.Controls.Add((Control) this.numericUpDown20);
      this.groupWeather.Controls.Add((Control) this.numericUpDown21);
      this.groupWeather.Controls.Add((Control) this.comboBox11);
      this.groupWeather.Controls.Add((Control) this.comboBox12);
      this.groupWeather.Controls.Add((Control) this.numericUpDown16);
      this.groupWeather.Controls.Add((Control) this.numericUpDown17);
      this.groupWeather.Controls.Add((Control) this.numericUpDown18);
      this.groupWeather.Controls.Add((Control) this.comboBox9);
      this.groupWeather.Controls.Add((Control) this.comboBox10);
      this.groupWeather.Controls.Add((Control) this.numericUpDown13);
      this.groupWeather.Controls.Add((Control) this.numericUpDown14);
      this.groupWeather.Controls.Add((Control) this.numericUpDown15);
      this.groupWeather.Controls.Add((Control) this.comboBox7);
      this.groupWeather.Controls.Add((Control) this.comboBox8);
      this.groupWeather.Controls.Add((Control) this.numericUpDown10);
      this.groupWeather.Controls.Add((Control) this.numericUpDown11);
      this.groupWeather.Controls.Add((Control) this.numericUpDown12);
      this.groupWeather.Controls.Add((Control) this.comboBox5);
      this.groupWeather.Controls.Add((Control) this.comboBox6);
      this.groupWeather.Controls.Add((Control) this.numericUpDown7);
      this.groupWeather.Controls.Add((Control) this.numericUpDown8);
      this.groupWeather.Controls.Add((Control) this.numericUpDown9);
      this.groupWeather.Controls.Add((Control) this.comboBox3);
      this.groupWeather.Controls.Add((Control) this.comboBox4);
      this.groupWeather.Controls.Add((Control) this.numericUpDown4);
      this.groupWeather.Controls.Add((Control) this.numericUpDown5);
      this.groupWeather.Controls.Add((Control) this.numericUpDown6);
      this.groupWeather.Controls.Add((Control) this.comboBox1);
      this.groupWeather.Controls.Add((Control) this.comboBox2);
      this.groupWeather.Controls.Add((Control) this.numericUpDown1);
      this.groupWeather.Controls.Add((Control) this.numericUpDown2);
      this.groupWeather.Controls.Add((Control) this.numericUpDown3);
      this.groupWeather.Controls.Add((Control) this.label33);
      this.groupWeather.Controls.Add((Control) this.label32);
      this.groupWeather.Controls.Add((Control) this.label31);
      this.groupWeather.Controls.Add((Control) this.label30);
      this.groupWeather.Controls.Add((Control) this.label29);
      this.groupWeather.Controls.Add((Control) this.label28);
      this.groupWeather.Controls.Add((Control) this.label27);
      this.groupWeather.Controls.Add((Control) this.label26);
      this.groupWeather.Controls.Add((Control) this.label25);
      this.groupWeather.Controls.Add((Control) this.label24);
      this.groupWeather.Controls.Add((Control) this.label23);
      this.groupWeather.Controls.Add((Control) this.label22);
      this.groupWeather.Controls.Add((Control) this.label21);
      this.groupWeather.Controls.Add((Control) this.label20);
      this.groupWeather.Controls.Add((Control) this.label19);
      this.groupWeather.Controls.Add((Control) this.label18);
      this.groupWeather.Controls.Add((Control) this.label17);
      this.groupWeather.Location = new Point(17, 146);
      this.groupWeather.Name = "groupWeather";
      this.groupWeather.Size = new Size(466, 443);
      this.groupWeather.TabIndex = 12;
      this.groupWeather.TabStop = false;
      this.groupWeather.Text = "Weather";
      this.toolWeather.GripStyle = ToolStripGripStyle.Hidden;
      this.toolWeather.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.buttonCopyWeather,
        (ToolStripItem) this.buttonPasteWeather
      });
      this.toolWeather.Location = new Point(3, 16);
      this.toolWeather.Name = "toolWeather";
      this.toolWeather.Size = new Size(460, 55);
      this.toolWeather.TabIndex = 77;
      this.buttonCopyWeather.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonCopyWeather.Image = (Image) resources.GetObject("buttonCopyWeather.Image");
      this.buttonCopyWeather.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonCopyWeather.ImageTransparentColor = Color.Magenta;
      this.buttonCopyWeather.Name = "buttonCopyWeather";
      this.buttonCopyWeather.Size = new Size(52, 52);
      this.buttonCopyWeather.Text = "Copy Weather";
      this.buttonCopyWeather.Click += new EventHandler(this.buttonCopyWeather_Click);
      this.buttonPasteWeather.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonPasteWeather.Enabled = false;
      this.buttonPasteWeather.Image = (Image) resources.GetObject("buttonPasteWeather.Image");
      this.buttonPasteWeather.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonPasteWeather.ImageTransparentColor = Color.Magenta;
      this.buttonPasteWeather.Name = "buttonPasteWeather";
      this.buttonPasteWeather.Size = new Size(52, 52);
      this.buttonPasteWeather.Text = "Paste Weather";
      this.buttonPasteWeather.Click += new EventHandler(this.buttonPasteWeather_Click);
      this.comboBox23.FormattingEnabled = true;
      this.comboBox23.Items.AddRange(new object[11]
      {
        (object) "16.00",
        (object) "16.30",
        (object) "17.00",
        (object) "17.30",
        (object) "18.00",
        (object) "18.30",
        (object) "19.00",
        (object) "19.30",
        (object) "20.00",
        (object) "20.30",
        (object) "21.00"
      });
      this.comboBox23.Location = new Point(377, 402);
      this.comboBox23.Name = "comboBox23";
      this.comboBox23.Size = new Size(69, 21);
      this.comboBox23.TabIndex = 76;
      this.comboBox23.Tag = (object) "N11";
      this.comboBox23.SelectedIndexChanged += new EventHandler(this.TimeComboBox_SelectedIndexChanged);
      this.comboBox24.FormattingEnabled = true;
      this.comboBox24.Items.AddRange(new object[11]
      {
        (object) "16.00",
        (object) "16.30",
        (object) "17.00",
        (object) "17.30",
        (object) "18.00",
        (object) "18.30",
        (object) "19.00",
        (object) "19.30",
        (object) "20.00",
        (object) "20.30",
        (object) "21.00"
      });
      this.comboBox24.Location = new Point(291, 402);
      this.comboBox24.Name = "comboBox24";
      this.comboBox24.Size = new Size(69, 21);
      this.comboBox24.TabIndex = 75;
      this.comboBox24.Tag = (object) "U11";
      this.comboBox24.SelectedIndexChanged += new EventHandler(this.TimeComboBox_SelectedIndexChanged);
      this.numericUpDown34.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown34.Location = new Point(218, 402);
      this.numericUpDown34.Name = "numericUpDown34";
      this.numericUpDown34.Size = new Size(56, 20);
      this.numericUpDown34.TabIndex = 74;
      this.numericUpDown34.Tag = (object) "O11";
      this.numericUpDown34.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown34.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.numericUpDown35.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown35.Location = new Point(145, 402);
      this.numericUpDown35.Name = "numericUpDown35";
      this.numericUpDown35.Size = new Size(56, 20);
      this.numericUpDown35.TabIndex = 73;
      this.numericUpDown35.Tag = (object) "S11";
      this.numericUpDown35.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown35.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.numericUpDown36.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown36.Location = new Point(72, 402);
      this.numericUpDown36.Name = "numericUpDown36";
      this.numericUpDown36.Size = new Size(56, 20);
      this.numericUpDown36.TabIndex = 72;
      this.numericUpDown36.Tag = (object) "R11";
      this.numericUpDown36.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown36.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.comboBox21.FormattingEnabled = true;
      this.comboBox21.Items.AddRange(new object[11]
      {
        (object) "16.00",
        (object) "16.30",
        (object) "17.00",
        (object) "17.30",
        (object) "18.00",
        (object) "18.30",
        (object) "19.00",
        (object) "19.30",
        (object) "20.00",
        (object) "20.30",
        (object) "21.00"
      });
      this.comboBox21.Location = new Point(377, 375);
      this.comboBox21.Name = "comboBox21";
      this.comboBox21.Size = new Size(69, 21);
      this.comboBox21.TabIndex = 71;
      this.comboBox21.Tag = (object) "N10";
      this.comboBox21.SelectedIndexChanged += new EventHandler(this.TimeComboBox_SelectedIndexChanged);
      this.comboBox22.FormattingEnabled = true;
      this.comboBox22.Items.AddRange(new object[11]
      {
        (object) "16.00",
        (object) "16.30",
        (object) "17.00",
        (object) "17.30",
        (object) "18.00",
        (object) "18.30",
        (object) "19.00",
        (object) "19.30",
        (object) "20.00",
        (object) "20.30",
        (object) "21.00"
      });
      this.comboBox22.Location = new Point(291, 375);
      this.comboBox22.Name = "comboBox22";
      this.comboBox22.Size = new Size(69, 21);
      this.comboBox22.TabIndex = 70;
      this.comboBox22.Tag = (object) "U10";
      this.comboBox22.SelectedIndexChanged += new EventHandler(this.TimeComboBox_SelectedIndexChanged);
      this.numericUpDown31.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown31.Location = new Point(218, 375);
      this.numericUpDown31.Name = "numericUpDown31";
      this.numericUpDown31.Size = new Size(56, 20);
      this.numericUpDown31.TabIndex = 69;
      this.numericUpDown31.Tag = (object) "O10";
      this.numericUpDown31.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown31.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.numericUpDown32.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown32.Location = new Point(145, 375);
      this.numericUpDown32.Name = "numericUpDown32";
      this.numericUpDown32.Size = new Size(56, 20);
      this.numericUpDown32.TabIndex = 68;
      this.numericUpDown32.Tag = (object) "S10";
      this.numericUpDown32.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown32.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.numericUpDown33.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown33.Location = new Point(72, 375);
      this.numericUpDown33.Name = "numericUpDown33";
      this.numericUpDown33.Size = new Size(56, 20);
      this.numericUpDown33.TabIndex = 67;
      this.numericUpDown33.Tag = (object) "R10";
      this.numericUpDown33.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown33.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.comboBox19.FormattingEnabled = true;
      this.comboBox19.Items.AddRange(new object[11]
      {
        (object) "16.00",
        (object) "16.30",
        (object) "17.00",
        (object) "17.30",
        (object) "18.00",
        (object) "18.30",
        (object) "19.00",
        (object) "19.30",
        (object) "20.00",
        (object) "20.30",
        (object) "21.00"
      });
      this.comboBox19.Location = new Point(377, 348);
      this.comboBox19.Name = "comboBox19";
      this.comboBox19.Size = new Size(69, 21);
      this.comboBox19.TabIndex = 66;
      this.comboBox19.Tag = (object) "N09";
      this.comboBox19.SelectedIndexChanged += new EventHandler(this.TimeComboBox_SelectedIndexChanged);
      this.comboBox20.FormattingEnabled = true;
      this.comboBox20.Items.AddRange(new object[11]
      {
        (object) "16.00",
        (object) "16.30",
        (object) "17.00",
        (object) "17.30",
        (object) "18.00",
        (object) "18.30",
        (object) "19.00",
        (object) "19.30",
        (object) "20.00",
        (object) "20.30",
        (object) "21.00"
      });
      this.comboBox20.Location = new Point(291, 348);
      this.comboBox20.Name = "comboBox20";
      this.comboBox20.Size = new Size(69, 21);
      this.comboBox20.TabIndex = 65;
      this.comboBox20.Tag = (object) "U09";
      this.comboBox20.SelectedIndexChanged += new EventHandler(this.TimeComboBox_SelectedIndexChanged);
      this.numericUpDown28.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown28.Location = new Point(218, 348);
      this.numericUpDown28.Name = "numericUpDown28";
      this.numericUpDown28.Size = new Size(56, 20);
      this.numericUpDown28.TabIndex = 64;
      this.numericUpDown28.Tag = (object) "O9";
      this.numericUpDown28.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown28.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.numericUpDown29.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown29.Location = new Point(145, 348);
      this.numericUpDown29.Name = "numericUpDown29";
      this.numericUpDown29.Size = new Size(56, 20);
      this.numericUpDown29.TabIndex = 63;
      this.numericUpDown29.Tag = (object) "S9";
      this.numericUpDown29.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown29.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.numericUpDown30.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown30.Location = new Point(72, 348);
      this.numericUpDown30.Name = "numericUpDown30";
      this.numericUpDown30.Size = new Size(56, 20);
      this.numericUpDown30.TabIndex = 62;
      this.numericUpDown30.Tag = (object) "R9";
      this.numericUpDown30.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown30.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.comboBox17.FormattingEnabled = true;
      this.comboBox17.Items.AddRange(new object[11]
      {
        (object) "16.00",
        (object) "16.30",
        (object) "17.00",
        (object) "17.30",
        (object) "18.00",
        (object) "18.30",
        (object) "19.00",
        (object) "19.30",
        (object) "20.00",
        (object) "20.30",
        (object) "21.00"
      });
      this.comboBox17.Location = new Point(377, 321);
      this.comboBox17.Name = "comboBox17";
      this.comboBox17.Size = new Size(69, 21);
      this.comboBox17.TabIndex = 61;
      this.comboBox17.Tag = (object) "N08";
      this.comboBox17.SelectedIndexChanged += new EventHandler(this.TimeComboBox_SelectedIndexChanged);
      this.comboBox18.FormattingEnabled = true;
      this.comboBox18.Items.AddRange(new object[11]
      {
        (object) "16.00",
        (object) "16.30",
        (object) "17.00",
        (object) "17.30",
        (object) "18.00",
        (object) "18.30",
        (object) "19.00",
        (object) "19.30",
        (object) "20.00",
        (object) "20.30",
        (object) "21.00"
      });
      this.comboBox18.Location = new Point(291, 321);
      this.comboBox18.Name = "comboBox18";
      this.comboBox18.Size = new Size(69, 21);
      this.comboBox18.TabIndex = 60;
      this.comboBox18.Tag = (object) "U08";
      this.comboBox18.SelectedIndexChanged += new EventHandler(this.TimeComboBox_SelectedIndexChanged);
      this.numericUpDown25.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown25.Location = new Point(218, 321);
      this.numericUpDown25.Name = "numericUpDown25";
      this.numericUpDown25.Size = new Size(56, 20);
      this.numericUpDown25.TabIndex = 59;
      this.numericUpDown25.Tag = (object) "O8";
      this.numericUpDown25.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown25.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.numericUpDown26.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown26.Location = new Point(145, 321);
      this.numericUpDown26.Name = "numericUpDown26";
      this.numericUpDown26.Size = new Size(56, 20);
      this.numericUpDown26.TabIndex = 58;
      this.numericUpDown26.Tag = (object) "S8";
      this.numericUpDown26.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown26.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.numericUpDown27.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown27.Location = new Point(72, 321);
      this.numericUpDown27.Name = "numericUpDown27";
      this.numericUpDown27.Size = new Size(56, 20);
      this.numericUpDown27.TabIndex = 57;
      this.numericUpDown27.Tag = (object) "R8";
      this.numericUpDown27.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown27.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.comboBox15.FormattingEnabled = true;
      this.comboBox15.Items.AddRange(new object[11]
      {
        (object) "16.00",
        (object) "16.30",
        (object) "17.00",
        (object) "17.30",
        (object) "18.00",
        (object) "18.30",
        (object) "19.00",
        (object) "19.30",
        (object) "20.00",
        (object) "20.30",
        (object) "21.00"
      });
      this.comboBox15.Location = new Point(377, 294);
      this.comboBox15.Name = "comboBox15";
      this.comboBox15.Size = new Size(69, 21);
      this.comboBox15.TabIndex = 56;
      this.comboBox15.Tag = (object) "N07";
      this.comboBox15.SelectedIndexChanged += new EventHandler(this.TimeComboBox_SelectedIndexChanged);
      this.comboBox16.FormattingEnabled = true;
      this.comboBox16.Items.AddRange(new object[11]
      {
        (object) "16.00",
        (object) "16.30",
        (object) "17.00",
        (object) "17.30",
        (object) "18.00",
        (object) "18.30",
        (object) "19.00",
        (object) "19.30",
        (object) "20.00",
        (object) "20.30",
        (object) "21.00"
      });
      this.comboBox16.Location = new Point(291, 294);
      this.comboBox16.Name = "comboBox16";
      this.comboBox16.Size = new Size(69, 21);
      this.comboBox16.TabIndex = 55;
      this.comboBox16.Tag = (object) "U07";
      this.comboBox16.SelectedIndexChanged += new EventHandler(this.TimeComboBox_SelectedIndexChanged);
      this.numericUpDown22.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown22.Location = new Point(218, 294);
      this.numericUpDown22.Name = "numericUpDown22";
      this.numericUpDown22.Size = new Size(56, 20);
      this.numericUpDown22.TabIndex = 54;
      this.numericUpDown22.Tag = (object) "O7";
      this.numericUpDown22.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown22.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.numericUpDown23.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown23.Location = new Point(145, 294);
      this.numericUpDown23.Name = "numericUpDown23";
      this.numericUpDown23.Size = new Size(56, 20);
      this.numericUpDown23.TabIndex = 53;
      this.numericUpDown23.Tag = (object) "S7";
      this.numericUpDown23.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown23.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.numericUpDown24.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown24.Location = new Point(72, 294);
      this.numericUpDown24.Name = "numericUpDown24";
      this.numericUpDown24.Size = new Size(56, 20);
      this.numericUpDown24.TabIndex = 52;
      this.numericUpDown24.Tag = (object) "R7";
      this.numericUpDown24.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown24.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.comboBox13.FormattingEnabled = true;
      this.comboBox13.Items.AddRange(new object[11]
      {
        (object) "16.00",
        (object) "16.30",
        (object) "17.00",
        (object) "17.30",
        (object) "18.00",
        (object) "18.30",
        (object) "19.00",
        (object) "19.30",
        (object) "20.00",
        (object) "20.30",
        (object) "21.00"
      });
      this.comboBox13.Location = new Point(377, 267);
      this.comboBox13.Name = "comboBox13";
      this.comboBox13.Size = new Size(69, 21);
      this.comboBox13.TabIndex = 51;
      this.comboBox13.Tag = (object) "N06";
      this.comboBox13.SelectedIndexChanged += new EventHandler(this.TimeComboBox_SelectedIndexChanged);
      this.comboBox14.FormattingEnabled = true;
      this.comboBox14.Items.AddRange(new object[11]
      {
        (object) "16.00",
        (object) "16.30",
        (object) "17.00",
        (object) "17.30",
        (object) "18.00",
        (object) "18.30",
        (object) "19.00",
        (object) "19.30",
        (object) "20.00",
        (object) "20.30",
        (object) "21.00"
      });
      this.comboBox14.Location = new Point(291, 267);
      this.comboBox14.Name = "comboBox14";
      this.comboBox14.Size = new Size(69, 21);
      this.comboBox14.TabIndex = 50;
      this.comboBox14.Tag = (object) "U06";
      this.comboBox14.SelectedIndexChanged += new EventHandler(this.TimeComboBox_SelectedIndexChanged);
      this.numericUpDown19.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown19.Location = new Point(218, 267);
      this.numericUpDown19.Name = "numericUpDown19";
      this.numericUpDown19.Size = new Size(56, 20);
      this.numericUpDown19.TabIndex = 49;
      this.numericUpDown19.Tag = (object) "O6";
      this.numericUpDown19.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown19.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.numericUpDown20.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown20.Location = new Point(145, 267);
      this.numericUpDown20.Name = "numericUpDown20";
      this.numericUpDown20.Size = new Size(56, 20);
      this.numericUpDown20.TabIndex = 48;
      this.numericUpDown20.Tag = (object) "S6";
      this.numericUpDown20.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown20.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.numericUpDown21.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown21.Location = new Point(72, 267);
      this.numericUpDown21.Name = "numericUpDown21";
      this.numericUpDown21.Size = new Size(56, 20);
      this.numericUpDown21.TabIndex = 47;
      this.numericUpDown21.Tag = (object) "R6";
      this.numericUpDown21.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown21.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.comboBox11.FormattingEnabled = true;
      this.comboBox11.Items.AddRange(new object[11]
      {
        (object) "16.00",
        (object) "16.30",
        (object) "17.00",
        (object) "17.30",
        (object) "18.00",
        (object) "18.30",
        (object) "19.00",
        (object) "19.30",
        (object) "20.00",
        (object) "20.30",
        (object) "21.00"
      });
      this.comboBox11.Location = new Point(377, 240);
      this.comboBox11.Name = "comboBox11";
      this.comboBox11.Size = new Size(69, 21);
      this.comboBox11.TabIndex = 46;
      this.comboBox11.Tag = (object) "N05";
      this.comboBox11.SelectedIndexChanged += new EventHandler(this.TimeComboBox_SelectedIndexChanged);
      this.comboBox12.FormattingEnabled = true;
      this.comboBox12.Items.AddRange(new object[11]
      {
        (object) "16.00",
        (object) "16.30",
        (object) "17.00",
        (object) "17.30",
        (object) "18.00",
        (object) "18.30",
        (object) "19.00",
        (object) "19.30",
        (object) "20.00",
        (object) "20.30",
        (object) "21.00"
      });
      this.comboBox12.Location = new Point(291, 240);
      this.comboBox12.Name = "comboBox12";
      this.comboBox12.Size = new Size(69, 21);
      this.comboBox12.TabIndex = 45;
      this.comboBox12.Tag = (object) "U05";
      this.comboBox12.SelectedIndexChanged += new EventHandler(this.TimeComboBox_SelectedIndexChanged);
      this.numericUpDown16.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown16.Location = new Point(218, 240);
      this.numericUpDown16.Name = "numericUpDown16";
      this.numericUpDown16.Size = new Size(56, 20);
      this.numericUpDown16.TabIndex = 44;
      this.numericUpDown16.Tag = (object) "O5";
      this.numericUpDown16.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown16.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.numericUpDown17.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown17.Location = new Point(145, 240);
      this.numericUpDown17.Name = "numericUpDown17";
      this.numericUpDown17.Size = new Size(56, 20);
      this.numericUpDown17.TabIndex = 43;
      this.numericUpDown17.Tag = (object) "S5";
      this.numericUpDown17.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown17.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.numericUpDown18.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown18.Location = new Point(72, 240);
      this.numericUpDown18.Name = "numericUpDown18";
      this.numericUpDown18.Size = new Size(56, 20);
      this.numericUpDown18.TabIndex = 42;
      this.numericUpDown18.Tag = (object) "R5";
      this.numericUpDown18.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown18.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.comboBox9.FormattingEnabled = true;
      this.comboBox9.Items.AddRange(new object[11]
      {
        (object) "16.00",
        (object) "16.30",
        (object) "17.00",
        (object) "17.30",
        (object) "18.00",
        (object) "18.30",
        (object) "19.00",
        (object) "19.30",
        (object) "20.00",
        (object) "20.30",
        (object) "21.00"
      });
      this.comboBox9.Location = new Point(377, 213);
      this.comboBox9.Name = "comboBox9";
      this.comboBox9.Size = new Size(69, 21);
      this.comboBox9.TabIndex = 41;
      this.comboBox9.Tag = (object) "N04";
      this.comboBox9.SelectedIndexChanged += new EventHandler(this.TimeComboBox_SelectedIndexChanged);
      this.comboBox10.FormattingEnabled = true;
      this.comboBox10.Items.AddRange(new object[11]
      {
        (object) "16.00",
        (object) "16.30",
        (object) "17.00",
        (object) "17.30",
        (object) "18.00",
        (object) "18.30",
        (object) "19.00",
        (object) "19.30",
        (object) "20.00",
        (object) "20.30",
        (object) "21.00"
      });
      this.comboBox10.Location = new Point(291, 213);
      this.comboBox10.Name = "comboBox10";
      this.comboBox10.Size = new Size(69, 21);
      this.comboBox10.TabIndex = 40;
      this.comboBox10.Tag = (object) "U04";
      this.comboBox10.SelectedIndexChanged += new EventHandler(this.TimeComboBox_SelectedIndexChanged);
      this.numericUpDown13.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown13.Location = new Point(218, 213);
      this.numericUpDown13.Name = "numericUpDown13";
      this.numericUpDown13.Size = new Size(56, 20);
      this.numericUpDown13.TabIndex = 39;
      this.numericUpDown13.Tag = (object) "O4";
      this.numericUpDown13.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown13.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.numericUpDown14.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown14.Location = new Point(145, 213);
      this.numericUpDown14.Name = "numericUpDown14";
      this.numericUpDown14.Size = new Size(56, 20);
      this.numericUpDown14.TabIndex = 38;
      this.numericUpDown14.Tag = (object) "S4";
      this.numericUpDown14.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown14.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.numericUpDown15.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown15.Location = new Point(72, 213);
      this.numericUpDown15.Name = "numericUpDown15";
      this.numericUpDown15.Size = new Size(56, 20);
      this.numericUpDown15.TabIndex = 37;
      this.numericUpDown15.Tag = (object) "R4";
      this.numericUpDown15.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown15.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.comboBox7.FormattingEnabled = true;
      this.comboBox7.Items.AddRange(new object[11]
      {
        (object) "16.00",
        (object) "16.30",
        (object) "17.00",
        (object) "17.30",
        (object) "18.00",
        (object) "18.30",
        (object) "19.00",
        (object) "19.30",
        (object) "20.00",
        (object) "20.30",
        (object) "21.00"
      });
      this.comboBox7.Location = new Point(378, 186);
      this.comboBox7.Name = "comboBox7";
      this.comboBox7.Size = new Size(69, 21);
      this.comboBox7.TabIndex = 36;
      this.comboBox7.Tag = (object) "N03";
      this.comboBox7.SelectedIndexChanged += new EventHandler(this.TimeComboBox_SelectedIndexChanged);
      this.comboBox8.FormattingEnabled = true;
      this.comboBox8.Items.AddRange(new object[11]
      {
        (object) "16.00",
        (object) "16.30",
        (object) "17.00",
        (object) "17.30",
        (object) "18.00",
        (object) "18.30",
        (object) "19.00",
        (object) "19.30",
        (object) "20.00",
        (object) "20.30",
        (object) "21.00"
      });
      this.comboBox8.Location = new Point(292, 186);
      this.comboBox8.Name = "comboBox8";
      this.comboBox8.Size = new Size(69, 21);
      this.comboBox8.TabIndex = 35;
      this.comboBox8.Tag = (object) "U03";
      this.comboBox8.SelectedIndexChanged += new EventHandler(this.TimeComboBox_SelectedIndexChanged);
      this.numericUpDown10.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown10.Location = new Point(219, 186);
      this.numericUpDown10.Name = "numericUpDown10";
      this.numericUpDown10.Size = new Size(56, 20);
      this.numericUpDown10.TabIndex = 34;
      this.numericUpDown10.Tag = (object) "O3";
      this.numericUpDown10.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown10.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.numericUpDown11.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown11.Location = new Point(146, 186);
      this.numericUpDown11.Name = "numericUpDown11";
      this.numericUpDown11.Size = new Size(56, 20);
      this.numericUpDown11.TabIndex = 33;
      this.numericUpDown11.Tag = (object) "S3";
      this.numericUpDown11.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown11.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.numericUpDown12.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown12.Location = new Point(73, 186);
      this.numericUpDown12.Name = "numericUpDown12";
      this.numericUpDown12.Size = new Size(56, 20);
      this.numericUpDown12.TabIndex = 32;
      this.numericUpDown12.Tag = (object) "R3";
      this.numericUpDown12.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown12.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.comboBox5.FormattingEnabled = true;
      this.comboBox5.Items.AddRange(new object[11]
      {
        (object) "16.00",
        (object) "16.30",
        (object) "17.00",
        (object) "17.30",
        (object) "18.00",
        (object) "18.30",
        (object) "19.00",
        (object) "19.30",
        (object) "20.00",
        (object) "20.30",
        (object) "21.00"
      });
      this.comboBox5.Location = new Point(377, 159);
      this.comboBox5.Name = "comboBox5";
      this.comboBox5.Size = new Size(69, 21);
      this.comboBox5.TabIndex = 31;
      this.comboBox5.Tag = (object) "N02";
      this.comboBox5.SelectedIndexChanged += new EventHandler(this.TimeComboBox_SelectedIndexChanged);
      this.comboBox6.FormattingEnabled = true;
      this.comboBox6.Items.AddRange(new object[11]
      {
        (object) "16.00",
        (object) "16.30",
        (object) "17.00",
        (object) "17.30",
        (object) "18.00",
        (object) "18.30",
        (object) "19.00",
        (object) "19.30",
        (object) "20.00",
        (object) "20.30",
        (object) "21.00"
      });
      this.comboBox6.Location = new Point(291, 159);
      this.comboBox6.Name = "comboBox6";
      this.comboBox6.Size = new Size(69, 21);
      this.comboBox6.TabIndex = 30;
      this.comboBox6.Tag = (object) "U02";
      this.comboBox6.SelectedIndexChanged += new EventHandler(this.TimeComboBox_SelectedIndexChanged);
      this.numericUpDown7.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown7.Location = new Point(218, 159);
      this.numericUpDown7.Name = "numericUpDown7";
      this.numericUpDown7.Size = new Size(56, 20);
      this.numericUpDown7.TabIndex = 29;
      this.numericUpDown7.Tag = (object) "O2";
      this.numericUpDown7.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown7.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.numericUpDown8.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown8.Location = new Point(145, 159);
      this.numericUpDown8.Name = "numericUpDown8";
      this.numericUpDown8.Size = new Size(56, 20);
      this.numericUpDown8.TabIndex = 28;
      this.numericUpDown8.Tag = (object) "S2";
      this.numericUpDown8.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown8.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.numericUpDown9.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown9.Location = new Point(72, 159);
      this.numericUpDown9.Name = "numericUpDown9";
      this.numericUpDown9.Size = new Size(56, 20);
      this.numericUpDown9.TabIndex = 27;
      this.numericUpDown9.Tag = (object) "R2";
      this.numericUpDown9.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown9.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.comboBox3.FormattingEnabled = true;
      this.comboBox3.Items.AddRange(new object[11]
      {
        (object) "16.00",
        (object) "16.30",
        (object) "17.00",
        (object) "17.30",
        (object) "18.00",
        (object) "18.30",
        (object) "19.00",
        (object) "19.30",
        (object) "20.00",
        (object) "20.30",
        (object) "21.00"
      });
      this.comboBox3.Location = new Point(377, 131);
      this.comboBox3.Name = "comboBox3";
      this.comboBox3.Size = new Size(69, 21);
      this.comboBox3.TabIndex = 26;
      this.comboBox3.Tag = (object) "N01";
      this.comboBox3.SelectedIndexChanged += new EventHandler(this.TimeComboBox_SelectedIndexChanged);
      this.comboBox4.FormattingEnabled = true;
      this.comboBox4.Items.AddRange(new object[11]
      {
        (object) "16.00",
        (object) "16.30",
        (object) "17.00",
        (object) "17.30",
        (object) "18.00",
        (object) "18.30",
        (object) "19.00",
        (object) "19.30",
        (object) "20.00",
        (object) "20.30",
        (object) "21.00"
      });
      this.comboBox4.Location = new Point(291, 131);
      this.comboBox4.Name = "comboBox4";
      this.comboBox4.Size = new Size(69, 21);
      this.comboBox4.TabIndex = 25;
      this.comboBox4.Tag = (object) "U01";
      this.comboBox4.SelectedIndexChanged += new EventHandler(this.TimeComboBox_SelectedIndexChanged);
      this.numericUpDown4.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown4.Location = new Point(218, 131);
      this.numericUpDown4.Name = "numericUpDown4";
      this.numericUpDown4.Size = new Size(56, 20);
      this.numericUpDown4.TabIndex = 24;
      this.numericUpDown4.Tag = (object) "O1";
      this.numericUpDown4.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown4.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.numericUpDown5.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown5.Location = new Point(145, 131);
      this.numericUpDown5.Name = "numericUpDown5";
      this.numericUpDown5.Size = new Size(56, 20);
      this.numericUpDown5.TabIndex = 23;
      this.numericUpDown5.Tag = (object) "S1";
      this.numericUpDown5.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown5.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.numericUpDown6.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown6.Location = new Point(72, 131);
      this.numericUpDown6.Name = "numericUpDown6";
      this.numericUpDown6.Size = new Size(56, 20);
      this.numericUpDown6.TabIndex = 22;
      this.numericUpDown6.Tag = (object) "R1";
      this.numericUpDown6.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown6.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[11]
      {
        (object) "16.00",
        (object) "16.30",
        (object) "17.00",
        (object) "17.30",
        (object) "18.00",
        (object) "18.30",
        (object) "19.00",
        (object) "19.30",
        (object) "20.00",
        (object) "20.30",
        (object) "21.00"
      });
      this.comboBox1.Location = new Point(378, 105);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(69, 21);
      this.comboBox1.TabIndex = 21;
      this.comboBox1.Tag = (object) "N00";
      this.comboBox1.SelectedIndexChanged += new EventHandler(this.TimeComboBox_SelectedIndexChanged);
      this.comboBox2.FormattingEnabled = true;
      this.comboBox2.Items.AddRange(new object[11]
      {
        (object) "16.00",
        (object) "16.30",
        (object) "17.00",
        (object) "17.30",
        (object) "18.00",
        (object) "18.30",
        (object) "19.00",
        (object) "19.30",
        (object) "20.00",
        (object) "20.30",
        (object) "21.00"
      });
      this.comboBox2.Location = new Point(292, 105);
      this.comboBox2.Name = "comboBox2";
      this.comboBox2.Size = new Size(69, 21);
      this.comboBox2.TabIndex = 20;
      this.comboBox2.Tag = (object) "U00";
      this.comboBox2.SelectedIndexChanged += new EventHandler(this.TimeComboBox_SelectedIndexChanged);
      this.numericUpDown1.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown1.Location = new Point(219, 105);
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new Size(56, 20);
      this.numericUpDown1.TabIndex = 19;
      this.numericUpDown1.Tag = (object) "O0";
      this.numericUpDown1.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown1.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.numericUpDown2.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown2.Location = new Point(146, 105);
      this.numericUpDown2.Name = "numericUpDown2";
      this.numericUpDown2.Size = new Size(56, 20);
      this.numericUpDown2.TabIndex = 18;
      this.numericUpDown2.Tag = (object) "S0";
      this.numericUpDown2.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown2.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.numericUpDown3.Increment = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDown3.Location = new Point(73, 105);
      this.numericUpDown3.Name = "numericUpDown3";
      this.numericUpDown3.Size = new Size(56, 20);
      this.numericUpDown3.TabIndex = 17;
      this.numericUpDown3.Tag = (object) "R0";
      this.numericUpDown3.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown3.ValueChanged += new EventHandler(this.probUpDown_ValueChanged);
      this.label33.AutoSize = true;
      this.label33.Location = new Point(204, 88);
      this.label33.Name = "label33";
      this.label33.Size = new Size(85, 13);
      this.label33.TabIndex = 16;
      this.label33.Text = "Overcast\\Sunny";
      this.label32.AutoSize = true;
      this.label32.Location = new Point(306, 88);
      this.label32.Name = "label32";
      this.label32.Size = new Size(40, 13);
      this.label32.TabIndex = 15;
      this.label32.Text = "Sunset";
      this.label31.AutoSize = true;
      this.label31.Location = new Point(396, 88);
      this.label31.Name = "label31";
      this.label31.Size = new Size(32, 13);
      this.label31.TabIndex = 14;
      this.label31.Text = "Night";
      this.label30.AutoSize = true;
      this.label30.Location = new Point(142, 88);
      this.label30.Name = "label30";
      this.label30.Size = new Size(62, 13);
      this.label30.TabIndex = 13;
      this.label30.Text = "Snow Prob.";
      this.label29.AutoSize = true;
      this.label29.Location = new Point(72, 88);
      this.label29.Name = "label29";
      this.label29.Size = new Size(57, 13);
      this.label29.TabIndex = 12;
      this.label29.Text = "Rain Prob.";
      this.label28.AutoSize = true;
      this.label28.Location = new Point(20, 404);
      this.label28.Name = "label28";
      this.label28.Size = new Size(29, 13);
      this.label28.TabIndex = 11;
      this.label28.Text = "DEC";
      this.label27.AutoSize = true;
      this.label27.Location = new Point(21, 377);
      this.label27.Name = "label27";
      this.label27.Size = new Size(30, 13);
      this.label27.TabIndex = 10;
      this.label27.Text = "NOV";
      this.label26.AutoSize = true;
      this.label26.Location = new Point(21, 350);
      this.label26.Name = "label26";
      this.label26.Size = new Size(29, 13);
      this.label26.TabIndex = 9;
      this.label26.Text = "OCT";
      this.label25.AutoSize = true;
      this.label25.Location = new Point(21, 323);
      this.label25.Name = "label25";
      this.label25.Size = new Size(28, 13);
      this.label25.TabIndex = 8;
      this.label25.Text = "SEP";
      this.label24.AutoSize = true;
      this.label24.Location = new Point(21, 296);
      this.label24.Name = "label24";
      this.label24.Size = new Size(30, 13);
      this.label24.TabIndex = 7;
      this.label24.Text = "AUG";
      this.label23.AutoSize = true;
      this.label23.Location = new Point(21, 269);
      this.label23.Name = "label23";
      this.label23.Size = new Size(26, 13);
      this.label23.TabIndex = 6;
      this.label23.Text = "JUL";
      this.label22.AutoSize = true;
      this.label22.Location = new Point(21, 242);
      this.label22.Name = "label22";
      this.label22.Size = new Size(28, 13);
      this.label22.TabIndex = 5;
      this.label22.Text = "JUN";
      this.label21.AutoSize = true;
      this.label21.Location = new Point(21, 215);
      this.label21.Name = "label21";
      this.label21.Size = new Size(30, 13);
      this.label21.TabIndex = 4;
      this.label21.Text = "MAY";
      this.label20.AutoSize = true;
      this.label20.Location = new Point(21, 188);
      this.label20.Name = "label20";
      this.label20.Size = new Size(29, 13);
      this.label20.TabIndex = 3;
      this.label20.Text = "APR";
      this.label19.AutoSize = true;
      this.label19.Location = new Point(21, 161);
      this.label19.Name = "label19";
      this.label19.Size = new Size(31, 13);
      this.label19.TabIndex = 2;
      this.label19.Text = "MAR";
      this.label18.AutoSize = true;
      this.label18.Location = new Point(21, 134);
      this.label18.Name = "label18";
      this.label18.Size = new Size(27, 13);
      this.label18.TabIndex = 1;
      this.label18.Text = "FEB";
      this.label17.AutoSize = true;
      this.label17.Location = new Point(21, 107);
      this.label17.Name = "label17";
      this.label17.Size = new Size(27, 13);
      this.label17.TabIndex = 0;
      this.label17.Text = "JAN";
      this.label6.AutoSize = true;
      this.label6.Location = new Point(12, 83);
      this.label6.Name = "label6";
      this.label6.Size = new Size(77, 13);
      this.label6.TabIndex = 11;
      this.label6.Text = "Yellows Stored";
      this.label5.AutoSize = true;
      this.label5.Location = new Point(12, 53);
      this.label5.Name = "label5";
      this.label5.Size = new Size(101, 13);
      this.label5.TabIndex = 10;
      this.label5.Text = "Season Start Month";
      this.labelDatabaseCountry.AutoSize = true;
      this.labelDatabaseCountry.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Underline, GraphicsUnit.Point, (byte) 0);
      this.labelDatabaseCountry.ForeColor = SystemColors.ActiveCaption;
      this.labelDatabaseCountry.Location = new Point(12, 25);
      this.labelDatabaseCountry.Name = "labelDatabaseCountry";
      this.labelDatabaseCountry.Size = new Size(92, 13);
      this.labelDatabaseCountry.TabIndex = 9;
      this.labelDatabaseCountry.Text = "Database Country";
      this.labelDatabaseCountry.DoubleClick += new EventHandler(this.labelDatabaseCountry_DoubleClick);
      this.comboCountry.FormattingEnabled = true;
      this.comboCountry.Location = new Point(153, 22);
      this.comboCountry.Name = "comboCountry";
      this.comboCountry.Size = new Size(162, 21);
      this.comboCountry.TabIndex = 8;
      this.comboCountry.SelectedIndexChanged += new EventHandler(this.comboCountry_SelectedIndexChanged);
      this.comboNationStandingsRules.FormattingEnabled = true;
      this.comboNationStandingsRules.Items.AddRange(new object[6]
      {
        (object) "Points, Goals, Wins",
        (object) "Points. Wins, Goals",
        (object) "Points, Head To Head, Goals",
        (object) "Team Rating",
        (object) "Previous Ranking",
        (object) "Points, Goals, Head To Head"
      });
      this.comboNationStandingsRules.Location = new Point(153, 105);
      this.comboNationStandingsRules.Name = "comboNationStandingsRules";
      this.comboNationStandingsRules.Size = new Size(162, 21);
      this.comboNationStandingsRules.TabIndex = 6;
      this.comboNationStandingsRules.SelectedIndexChanged += new EventHandler(this.comboNationStandingsRules_SelectedIndexChanged);
      this.checkNationStandingsRules.Appearance = Appearance.Button;
      this.checkNationStandingsRules.Location = new Point(15, 105);
      this.checkNationStandingsRules.Name = "checkNationStandingsRules";
      this.checkNationStandingsRules.Size = new Size(131, 23);
      this.checkNationStandingsRules.TabIndex = 5;
      this.checkNationStandingsRules.Text = "Special Standing Rules";
      this.toolTip.SetToolTip((Control) this.checkNationStandingsRules, "Default value is: Points, Goals");
      this.checkNationStandingsRules.UseVisualStyleBackColor = true;
      this.checkNationStandingsRules.CheckedChanged += new EventHandler(this.checkNationStandingsRules_CheckedChanged);
      this.numericNationYellowsStored.Location = new Point(153, 79);
      this.numericNationYellowsStored.Maximum = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericNationYellowsStored.Minimum = new Decimal(new int[4]
      {
        2,
        0,
        0,
        0
      });
      this.numericNationYellowsStored.Name = "numericNationYellowsStored";
      this.numericNationYellowsStored.Size = new Size(86, 20);
      this.numericNationYellowsStored.TabIndex = 4;
      this.numericNationYellowsStored.TextAlign = HorizontalAlignment.Center;
      this.numericNationYellowsStored.Value = new Decimal(new int[4]
      {
        2,
        0,
        0,
        0
      });
      this.numericNationYellowsStored.ValueChanged += new EventHandler(this.numericYellowsStored_ValueChanged);
      this.comboNationStartMonth.FormattingEnabled = true;
      this.comboNationStartMonth.Items.AddRange(new object[12]
      {
        (object) "JAN",
        (object) "FEB",
        (object) "MAR",
        (object) "APR",
        (object) "MAY",
        (object) "JUN",
        (object) "JUL",
        (object) "AUG",
        (object) "SEP",
        (object) "OCT",
        (object) "NOV",
        (object) "DEC"
      });
      this.comboNationStartMonth.Location = new Point(153, 50);
      this.comboNationStartMonth.Name = "comboNationStartMonth";
      this.comboNationStartMonth.Size = new Size(90, 21);
      this.comboNationStartMonth.TabIndex = 2;
      this.comboNationStartMonth.SelectedIndexChanged += new EventHandler(this.comboNationStartMonth_SelectedIndexChanged);
      this.groupTrophy.Controls.Add((Control) this.groupInternationalschedule);
      this.groupTrophy.Controls.Add((Control) this.label67);
      this.groupTrophy.Controls.Add((Control) this.numericBall);
      this.groupTrophy.Controls.Add((Control) this.pictureBall);
      this.groupTrophy.Controls.Add((Control) this.groupBenchPlayers);
      this.groupTrophy.Controls.Add((Control) this.comboTrophyStandingRules);
      this.groupTrophy.Controls.Add((Control) this.labelTrophyShortName);
      this.groupTrophy.Controls.Add((Control) this.labelMatchImportance);
      this.groupTrophy.Controls.Add((Control) this.labelCompetitionType);
      this.groupTrophy.Controls.Add((Control) this.numericImportance);
      this.groupTrophy.Controls.Add((Control) this.labelAssetId);
      this.groupTrophy.Controls.Add((Control) this.comboCompetitionType);
      this.groupTrophy.Controls.Add((Control) this.checkTrophyStandingsRules);
      this.groupTrophy.Controls.Add((Control) this.buttonGetId);
      this.groupTrophy.Controls.Add((Control) this.groupPromotionRelegation);
      this.groupTrophy.Controls.Add((Control) this.numericAssetId);
      this.groupTrophy.Controls.Add((Control) this.groupSchedule);
      this.groupTrophy.Controls.Add((Control) this.textTrophyLongName);
      this.groupTrophy.Controls.Add((Control) this.labeTrophylLongName);
      this.groupTrophy.Controls.Add((Control) this.textTrophyShortName);
      this.groupTrophy.FlatStyle = FlatStyle.Flat;
      this.groupTrophy.Location = new Point(3, 3);
      this.groupTrophy.Name = "groupTrophy";
      this.groupTrophy.Size = new Size(532, 587);
      this.groupTrophy.TabIndex = 9;
      this.groupTrophy.TabStop = false;
      this.groupTrophy.Text = "Trophy";
      this.groupTrophy.Visible = false;
      this.groupInternationalschedule.Controls.Add((Control) this.label71);
      this.groupInternationalschedule.Controls.Add((Control) this.comboTrophyStartMonth);
      this.groupInternationalschedule.Controls.Add((Control) this.numericInternationalPeriodicity);
      this.groupInternationalschedule.Controls.Add((Control) this.label69);
      this.groupInternationalschedule.Controls.Add((Control) this.label68);
      this.groupInternationalschedule.Controls.Add((Control) this.numericInternationalFirstYear);
      this.groupInternationalschedule.Location = new Point(8, 474);
      this.groupInternationalschedule.Name = "groupInternationalschedule";
      this.groupInternationalschedule.Size = new Size(347, 90);
      this.groupInternationalschedule.TabIndex = 167;
      this.groupInternationalschedule.TabStop = false;
      this.groupInternationalschedule.Text = "International Schedule";
      this.label71.AutoSize = true;
      this.label71.Location = new Point(6, 66);
      this.label71.Name = "label71";
      this.label71.Size = new Size(62, 13);
      this.label71.TabIndex = 163;
      this.label71.Text = "Start Month";
      this.comboTrophyStartMonth.FormattingEnabled = true;
      this.comboTrophyStartMonth.Items.AddRange(new object[12]
      {
        (object) "JAN",
        (object) "FEB",
        (object) "MAR",
        (object) "APR",
        (object) "MAY",
        (object) "JUN",
        (object) "JUL",
        (object) "AUG",
        (object) "SEP",
        (object) "OCT",
        (object) "NOV",
        (object) "DEC"
      });
      this.comboTrophyStartMonth.Location = new Point(79, 63);
      this.comboTrophyStartMonth.Name = "comboTrophyStartMonth";
      this.comboTrophyStartMonth.Size = new Size(90, 21);
      this.comboTrophyStartMonth.TabIndex = 162;
      this.comboTrophyStartMonth.SelectedIndexChanged += new EventHandler(this.comboTrophyStartMonth_SelectedIndexChanged);
      this.numericInternationalPeriodicity.Location = new Point(79, 41);
      this.numericInternationalPeriodicity.Maximum = new Decimal(new int[4]
      {
        4,
        0,
        0,
        0
      });
      this.numericInternationalPeriodicity.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        int.MinValue
      });
      this.numericInternationalPeriodicity.Name = "numericInternationalPeriodicity";
      this.numericInternationalPeriodicity.Size = new Size(90, 20);
      this.numericInternationalPeriodicity.TabIndex = 161;
      this.numericInternationalPeriodicity.TextAlign = HorizontalAlignment.Center;
      this.numericInternationalPeriodicity.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericInternationalPeriodicity.ValueChanged += new EventHandler(this.numericInternationalPeriodicity_ValueChanged);
      this.label69.AutoSize = true;
      this.label69.Location = new Point(6, 43);
      this.label69.Name = "label69";
      this.label69.Size = new Size(55, 13);
      this.label69.TabIndex = 160;
      this.label69.Text = "Periodicity";
      this.toolTip.SetToolTip((Control) this.label69, "Set a number between 0 and 100");
      this.label68.AutoSize = true;
      this.label68.Location = new Point(6, 20);
      this.label68.Name = "label68";
      this.label68.Size = new Size(51, 13);
      this.label68.TabIndex = 158;
      this.label68.Text = "First Year";
      this.toolTip.SetToolTip((Control) this.label68, "Set a number between 0 and 100");
      this.numericInternationalFirstYear.Location = new Point(79, 18);
      this.numericInternationalFirstYear.Maximum = new Decimal(new int[4]
      {
        2018,
        0,
        0,
        0
      });
      this.numericInternationalFirstYear.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        int.MinValue
      });
      this.numericInternationalFirstYear.Name = "numericInternationalFirstYear";
      this.numericInternationalFirstYear.Size = new Size(90, 20);
      this.numericInternationalFirstYear.TabIndex = 159;
      this.numericInternationalFirstYear.TextAlign = HorizontalAlignment.Center;
      this.numericInternationalFirstYear.Value = new Decimal(new int[4]
      {
        2013,
        0,
        0,
        0
      });
      this.numericInternationalFirstYear.ValueChanged += new EventHandler(this.numericInternationalFirstYear_ValueChanged);
      this.label67.Cursor = Cursors.Default;
      this.label67.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label67.ForeColor = SystemColors.ControlText;
      this.label67.ImeMode = ImeMode.NoControl;
      this.label67.Location = new Point(367, 22);
      this.label67.Name = "label67";
      this.label67.Size = new Size(51, 20);
      this.label67.TabIndex = 166;
      this.label67.Text = "Ball";
      this.label67.TextAlign = ContentAlignment.MiddleLeft;
      this.numericBall.Location = new Point(424, 21);
      this.numericBall.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        int.MinValue
      });
      this.numericBall.Name = "numericBall";
      this.numericBall.Size = new Size(91, 20);
      this.numericBall.TabIndex = 165;
      this.numericBall.TextAlign = HorizontalAlignment.Center;
      this.numericBall.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericBall.ValueChanged += new EventHandler(this.numericBall_ValueChanged);
      this.pictureBall.BackgroundImageLayout = ImageLayout.Zoom;
      this.pictureBall.Location = new Point(363, 46);
      this.pictureBall.Name = "pictureBall";
      this.pictureBall.Size = new Size(152, 110);
      this.pictureBall.TabIndex = 164;
      this.pictureBall.TabStop = false;
      this.groupBenchPlayers.Controls.Add((Control) this.radioBench7Players);
      this.groupBenchPlayers.Controls.Add((Control) this.radioBench5Players);
      this.groupBenchPlayers.Location = new Point(6, 418);
      this.groupBenchPlayers.Name = "groupBenchPlayers";
      this.groupBenchPlayers.Size = new Size(349, 50);
      this.groupBenchPlayers.TabIndex = 161;
      this.groupBenchPlayers.TabStop = false;
      this.groupBenchPlayers.Text = "Bench Players";
      this.radioBench7Players.AutoSize = true;
      this.radioBench7Players.Location = new Point(110, 19);
      this.radioBench7Players.Name = "radioBench7Players";
      this.radioBench7Players.Size = new Size(68, 17);
      this.radioBench7Players.TabIndex = 1;
      this.radioBench7Players.TabStop = true;
      this.radioBench7Players.Text = "7 Players";
      this.radioBench7Players.UseVisualStyleBackColor = true;
      this.radioBench7Players.CheckedChanged += new EventHandler(this.radioBench7Players_CheckedChanged);
      this.radioBench5Players.AutoSize = true;
      this.radioBench5Players.Location = new Point(9, 19);
      this.radioBench5Players.Name = "radioBench5Players";
      this.radioBench5Players.Size = new Size(68, 17);
      this.radioBench5Players.TabIndex = 0;
      this.radioBench5Players.TabStop = true;
      this.radioBench5Players.Text = "5 Players";
      this.radioBench5Players.UseVisualStyleBackColor = true;
      this.radioBench5Players.CheckedChanged += new EventHandler(this.radioBench5Players_CheckedChanged);
      this.comboTrophyStandingRules.FormattingEnabled = true;
      this.comboTrophyStandingRules.Items.AddRange(new object[6]
      {
        (object) "Points, Goals, Wins",
        (object) "Points. Wins, Goals",
        (object) "Points, Head To Head, Goals",
        (object) "Team Rating",
        (object) "Previous Ranking",
        (object) "Points, Goals, Head To Head"
      });
      this.comboTrophyStandingRules.Location = new Point(164, 157);
      this.comboTrophyStandingRules.Name = "comboTrophyStandingRules";
      this.comboTrophyStandingRules.Size = new Size(185, 21);
      this.comboTrophyStandingRules.TabIndex = 160;
      this.comboTrophyStandingRules.SelectedIndexChanged += new EventHandler(this.comboTrophyStandingRules_SelectedIndexChanged);
      this.labelTrophyShortName.AutoSize = true;
      this.labelTrophyShortName.Location = new Point(15, 30);
      this.labelTrophyShortName.Name = "labelTrophyShortName";
      this.labelTrophyShortName.Size = new Size(63, 13);
      this.labelTrophyShortName.TabIndex = 22;
      this.labelTrophyShortName.Text = "Short Name";
      this.labelMatchImportance.AutoSize = true;
      this.labelMatchImportance.Location = new Point(15, 133);
      this.labelMatchImportance.Name = "labelMatchImportance";
      this.labelMatchImportance.Size = new Size(93, 13);
      this.labelMatchImportance.TabIndex = 14;
      this.labelMatchImportance.Text = "Match Importance";
      this.toolTip.SetToolTip((Control) this.labelMatchImportance, "Set a number between 0 and 100");
      this.labelCompetitionType.AutoSize = true;
      this.labelCompetitionType.Location = new Point(16, 107);
      this.labelCompetitionType.Name = "labelCompetitionType";
      this.labelCompetitionType.Size = new Size(89, 13);
      this.labelCompetitionType.TabIndex = 10;
      this.labelCompetitionType.Text = "Competition Type";
      this.numericImportance.Location = new Point(164, 131);
      this.numericImportance.Name = "numericImportance";
      this.numericImportance.Size = new Size(68, 20);
      this.numericImportance.TabIndex = 157;
      this.numericImportance.TextAlign = HorizontalAlignment.Center;
      this.numericImportance.ValueChanged += new EventHandler(this.numericImportance_ValueChanged);
      this.labelAssetId.AutoSize = true;
      this.labelAssetId.Location = new Point(16, 85);
      this.labelAssetId.Name = "labelAssetId";
      this.labelAssetId.Size = new Size(45, 13);
      this.labelAssetId.TabIndex = 12;
      this.labelAssetId.Text = "Asset Id";
      this.comboCompetitionType.FormattingEnabled = true;
      this.comboCompetitionType.Items.AddRange(new object[8]
      {
        (object) "FRIENDLY",
        (object) "LEAGUE",
        (object) "PLAYOFF",
        (object) "CUP",
        (object) "SUPERCUP",
        (object) "INTERCUP",
        (object) "INTERQUAL",
        (object) "INTERFRIENDLY"
      });
      this.comboCompetitionType.Location = new Point(164, 104);
      this.comboCompetitionType.Name = "comboCompetitionType";
      this.comboCompetitionType.Size = new Size(185, 21);
      this.comboCompetitionType.TabIndex = 156;
      this.comboCompetitionType.SelectedIndexChanged += new EventHandler(this.comboCompetitionType_SelectedIndexChanged);
      this.checkTrophyStandingsRules.Appearance = Appearance.Button;
      this.checkTrophyStandingsRules.Location = new Point(15, 157);
      this.checkTrophyStandingsRules.Name = "checkTrophyStandingsRules";
      this.checkTrophyStandingsRules.Size = new Size(136, 23);
      this.checkTrophyStandingsRules.TabIndex = 15;
      this.checkTrophyStandingsRules.Text = "Special Standing Rules";
      this.toolTip.SetToolTip((Control) this.checkTrophyStandingsRules, "By default use the value defined by the Nation");
      this.checkTrophyStandingsRules.UseVisualStyleBackColor = true;
      this.checkTrophyStandingsRules.CheckedChanged += new EventHandler(this.checkTrophyStandingsRules_CheckedChanged);
      this.buttonGetId.BackgroundImage = (Image) resources.GetObject("buttonGetId.BackgroundImage");
      this.buttonGetId.BackgroundImageLayout = ImageLayout.None;
      this.buttonGetId.Location = new Point(324, 76);
      this.buttonGetId.Name = "buttonGetId";
      this.buttonGetId.Size = new Size(25, 23);
      this.buttonGetId.TabIndex = 155;
      this.buttonGetId.UseVisualStyleBackColor = true;
      this.buttonGetId.Click += new EventHandler(this.buttonGetId_Click);
      this.groupPromotionRelegation.Controls.Add((Control) this.comboRelegationLeague);
      this.groupPromotionRelegation.Controls.Add((Control) this.comboPromotionLeague);
      this.groupPromotionRelegation.Controls.Add((Control) this.checkPromotionLeague);
      this.groupPromotionRelegation.Controls.Add((Control) this.checkRelegationLeague);
      this.groupPromotionRelegation.Location = new Point(6, 321);
      this.groupPromotionRelegation.Name = "groupPromotionRelegation";
      this.groupPromotionRelegation.Size = new Size(349, 91);
      this.groupPromotionRelegation.TabIndex = 20;
      this.groupPromotionRelegation.TabStop = false;
      this.groupPromotionRelegation.Text = "Promotions and Relegations";
      this.comboRelegationLeague.FormattingEnabled = true;
      this.comboRelegationLeague.Location = new Point(155, 51);
      this.comboRelegationLeague.Name = "comboRelegationLeague";
      this.comboRelegationLeague.Size = new Size(185, 21);
      this.comboRelegationLeague.TabIndex = 19;
      this.comboRelegationLeague.SelectedIndexChanged += new EventHandler(this.comboRelegationLeague_SelectedIndexChanged);
      this.comboPromotionLeague.FormattingEnabled = true;
      this.comboPromotionLeague.Location = new Point(155, 20);
      this.comboPromotionLeague.Name = "comboPromotionLeague";
      this.comboPromotionLeague.Size = new Size(185, 21);
      this.comboPromotionLeague.TabIndex = 18;
      this.comboPromotionLeague.SelectedIndexChanged += new EventHandler(this.comboPromotionLeague_SelectedIndexChanged);
      this.checkPromotionLeague.Appearance = Appearance.Button;
      this.checkPromotionLeague.Location = new Point(6, 20);
      this.checkPromotionLeague.Name = "checkPromotionLeague";
      this.checkPromotionLeague.Size = new Size(139, 23);
      this.checkPromotionLeague.TabIndex = 16;
      this.checkPromotionLeague.Text = "Promote To";
      this.checkPromotionLeague.UseVisualStyleBackColor = true;
      this.checkPromotionLeague.CheckedChanged += new EventHandler(this.checkPromotionLeague_CheckedChanged);
      this.checkRelegationLeague.Appearance = Appearance.Button;
      this.checkRelegationLeague.Location = new Point(6, 52);
      this.checkRelegationLeague.Name = "checkRelegationLeague";
      this.checkRelegationLeague.Size = new Size(139, 23);
      this.checkRelegationLeague.TabIndex = 17;
      this.checkRelegationLeague.Text = "Relegate To";
      this.checkRelegationLeague.UseVisualStyleBackColor = true;
      this.checkRelegationLeague.CheckedChanged += new EventHandler(this.checkRelegationLeague_CheckedChanged);
      this.numericAssetId.Location = new Point(164, 76);
      this.numericAssetId.Maximum = new Decimal(new int[4]
      {
        200000,
        0,
        0,
        0
      });
      this.numericAssetId.Name = "numericAssetId";
      this.numericAssetId.Size = new Size(146, 20);
      this.numericAssetId.TabIndex = 154;
      this.numericAssetId.TextAlign = HorizontalAlignment.Center;
      this.numericAssetId.ValueChanged += new EventHandler(this.numericAssetId_ValueChanged);
      this.groupSchedule.Controls.Add((Control) this.checkScheduleUseDates);
      this.groupSchedule.Controls.Add((Control) this.checkScheduleConflicts);
      this.groupSchedule.Controls.Add((Control) this.comboSchedForce);
      this.groupSchedule.Controls.Add((Control) this.checkForceSchedule);
      this.groupSchedule.Location = new Point(9, 186);
      this.groupSchedule.Name = "groupSchedule";
      this.groupSchedule.Size = new Size(349, 108);
      this.groupSchedule.TabIndex = 21;
      this.groupSchedule.TabStop = false;
      this.groupSchedule.Text = "Schedule";
      this.checkScheduleUseDates.AutoSize = true;
      this.checkScheduleUseDates.Location = new Point(10, 80);
      this.checkScheduleUseDates.Name = "checkScheduleUseDates";
      this.checkScheduleUseDates.Size = new Size(176, 17);
      this.checkScheduleUseDates.TabIndex = 162;
      this.checkScheduleUseDates.Text = "Use International Friendly Dates";
      this.toolTip.SetToolTip((Control) this.checkScheduleUseDates, "Check this if you want to use the schedule dates of International friendlies");
      this.checkScheduleUseDates.UseVisualStyleBackColor = true;
      this.checkScheduleUseDates.CheckedChanged += new EventHandler(this.checkScheduleUseDates_CheckedChanged);
      this.checkScheduleConflicts.AutoSize = true;
      this.checkScheduleConflicts.Location = new Point(9, 19);
      this.checkScheduleConflicts.Name = "checkScheduleConflicts";
      this.checkScheduleConflicts.Size = new Size(148, 17);
      this.checkScheduleConflicts.TabIndex = 161;
      this.checkScheduleConflicts.Text = "Check Schedule Conflicts";
      this.toolTip.SetToolTip((Control) this.checkScheduleConflicts, "Check this box for international competitions");
      this.checkScheduleConflicts.UseVisualStyleBackColor = true;
      this.checkScheduleConflicts.CheckedChanged += new EventHandler(this.checkScheduleConflicts_CheckedChanged);
      this.comboSchedForce.FormattingEnabled = true;
      this.comboSchedForce.Location = new Point(153, 45);
      this.comboSchedForce.Name = "comboSchedForce";
      this.comboSchedForce.Size = new Size(185, 21);
      this.comboSchedForce.TabIndex = 22;
      this.comboSchedForce.SelectedIndexChanged += new EventHandler(this.comboSchedForce_SelectedIndexChanged);
      this.checkForceSchedule.Appearance = Appearance.Button;
      this.checkForceSchedule.Location = new Point(4, 43);
      this.checkForceSchedule.Name = "checkForceSchedule";
      this.checkForceSchedule.Size = new Size(136, 23);
      this.checkForceSchedule.TabIndex = 19;
      this.checkForceSchedule.Text = "Force Schedule of";
      this.toolTip.SetToolTip((Control) this.checkForceSchedule, "Select a competition that must be scheduled after the completion of this trophy");
      this.checkForceSchedule.UseVisualStyleBackColor = true;
      this.checkForceSchedule.CheckedChanged += new EventHandler(this.checkForceSchedule_CheckedChanged);
      this.textTrophyLongName.Location = new Point(164, 50);
      this.textTrophyLongName.Name = "textTrophyLongName";
      this.textTrophyLongName.Size = new Size(185, 20);
      this.textTrophyLongName.TabIndex = 25;
      this.textTrophyLongName.TextChanged += new EventHandler(this.textTrophyLongName_TextChanged);
      this.labeTrophylLongName.AutoSize = true;
      this.labeTrophylLongName.Location = new Point(16, 57);
      this.labeTrophylLongName.Name = "labeTrophylLongName";
      this.labeTrophylLongName.Size = new Size(62, 13);
      this.labeTrophylLongName.TabIndex = 23;
      this.labeTrophylLongName.Text = "Long Name";
      this.textTrophyShortName.Location = new Point(164, 23);
      this.textTrophyShortName.Name = "textTrophyShortName";
      this.textTrophyShortName.Size = new Size(185, 20);
      this.textTrophyShortName.TabIndex = 24;
      this.textTrophyShortName.TextChanged += new EventHandler(this.textTrophyShortName_TextChanged);
      this.groupStage.Controls.Add((Control) this.groupSetupStage);
      this.groupStage.Controls.Add((Control) this.groupPlayStage);
      this.groupStage.Controls.Add((Control) this.comboStageStandingRules);
      this.groupStage.Controls.Add((Control) this.checkStageStandingsRules);
      this.groupStage.Controls.Add((Control) this.numericStandingsRank);
      this.groupStage.Controls.Add((Control) this.checkStandingsRank);
      this.groupStage.Controls.Add((Control) this.comboStageType);
      this.groupStage.Controls.Add((Control) this.label7);
      this.groupStage.Controls.Add((Control) this.numericStandingKeep);
      this.groupStage.Controls.Add((Control) this.checkStandingKeep);
      this.groupStage.Location = new Point(0, 0);
      this.groupStage.Name = "groupStage";
      this.groupStage.Size = new Size(790, 724);
      this.groupStage.TabIndex = 10;
      this.groupStage.TabStop = false;
      this.groupStage.Text = "Stage";
      this.groupStage.Visible = false;
      this.groupSetupStage.Controls.Add((Control) this.checkRandomDraw);
      this.groupSetupStage.Controls.Add((Control) this.groupBox2);
      this.groupSetupStage.Controls.Add((Control) this.checkCalccompavgs);
      this.groupSetupStage.Location = new Point(8, 75);
      this.groupSetupStage.Name = "groupSetupStage";
      this.groupSetupStage.Size = new Size(468, 157);
      this.groupSetupStage.TabIndex = 17;
      this.groupSetupStage.TabStop = false;
      this.groupSetupStage.Text = "Setup Stage";
      this.checkRandomDraw.AutoSize = true;
      this.checkRandomDraw.Location = new Point(9, 19);
      this.checkRandomDraw.Name = "checkRandomDraw";
      this.checkRandomDraw.Size = new Size(94, 17);
      this.checkRandomDraw.TabIndex = 20;
      this.checkRandomDraw.Text = "Random Draw";
      this.checkRandomDraw.UseVisualStyleBackColor = true;
      this.checkRandomDraw.CheckedChanged += new EventHandler(this.checkRandomDraw_CheckedChanged);
      this.groupBox2.Controls.Add((Control) this.comboSpecialTeam4);
      this.groupBox2.Controls.Add((Control) this.comboSpecialTeam3);
      this.groupBox2.Controls.Add((Control) this.comboSpecialTeam2);
      this.groupBox2.Controls.Add((Control) this.comboSpecialTeam1);
      this.groupBox2.Location = new Point(180, 15);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(176, 134);
      this.groupBox2.TabIndex = 19;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Special Teams";
      this.comboSpecialTeam4.FormattingEnabled = true;
      this.comboSpecialTeam4.Location = new Point(9, 100);
      this.comboSpecialTeam4.Name = "comboSpecialTeam4";
      this.comboSpecialTeam4.Size = new Size(157, 21);
      this.comboSpecialTeam4.TabIndex = 29;
      this.comboSpecialTeam4.SelectedIndexChanged += new EventHandler(this.comboSpecialTeam4_SelectedIndexChanged);
      this.comboSpecialTeam3.FormattingEnabled = true;
      this.comboSpecialTeam3.Location = new Point(9, 73);
      this.comboSpecialTeam3.Name = "comboSpecialTeam3";
      this.comboSpecialTeam3.Size = new Size(157, 21);
      this.comboSpecialTeam3.TabIndex = 28;
      this.comboSpecialTeam3.SelectedIndexChanged += new EventHandler(this.comboSpecialTeam3_SelectedIndexChanged);
      this.comboSpecialTeam2.FormattingEnabled = true;
      this.comboSpecialTeam2.Location = new Point(9, 46);
      this.comboSpecialTeam2.Name = "comboSpecialTeam2";
      this.comboSpecialTeam2.Size = new Size(157, 21);
      this.comboSpecialTeam2.TabIndex = 27;
      this.comboSpecialTeam2.SelectedIndexChanged += new EventHandler(this.comboSpecialTeam2_SelectedIndexChanged);
      this.comboSpecialTeam1.FormattingEnabled = true;
      this.comboSpecialTeam1.Location = new Point(9, 19);
      this.comboSpecialTeam1.Name = "comboSpecialTeam1";
      this.comboSpecialTeam1.Size = new Size(157, 21);
      this.comboSpecialTeam1.TabIndex = 26;
      this.comboSpecialTeam1.SelectedIndexChanged += new EventHandler(this.comboSpecialTeam1_SelectedIndexChanged);
      this.checkCalccompavgs.AutoSize = true;
      this.checkCalccompavgs.Location = new Point(9, 42);
      this.checkCalccompavgs.Name = "checkCalccompavgs";
      this.checkCalccompavgs.Size = new Size(160, 17);
      this.checkCalccompavgs.TabIndex = 0;
      this.checkCalccompavgs.Text = "Sort by Competition Average";
      this.checkCalccompavgs.UseVisualStyleBackColor = true;
      this.checkCalccompavgs.CheckedChanged += new EventHandler(this.checkCalccompavgs_CheckedChanged);
      this.groupPlayStage.Controls.Add((Control) this.numericKeepPointsStageRef);
      this.groupPlayStage.Controls.Add((Control) this.checkRandomDrawEvent);
      this.groupPlayStage.Controls.Add((Control) this.groupLeaguetasks);
      this.groupPlayStage.Controls.Add((Control) this.groupStageSchedules);
      this.groupPlayStage.Controls.Add((Control) this.numericRegularSeason);
      this.groupPlayStage.Controls.Add((Control) this.comboSpecialKo2Rule);
      this.groupPlayStage.Controls.Add((Control) this.checkSpecialKo2Rule);
      this.groupPlayStage.Controls.Add((Control) this.comboSpecialKo1Rule);
      this.groupPlayStage.Controls.Add((Control) this.checkSpecialKo1Rule);
      this.groupPlayStage.Controls.Add((Control) this.numericKeepPointsPercentage);
      this.groupPlayStage.Controls.Add((Control) this.checkKeepPointsPercentage);
      this.groupPlayStage.Controls.Add((Control) this.numericStageRef);
      this.groupPlayStage.Controls.Add((Control) this.checkClausuraSchedule);
      this.groupPlayStage.Controls.Add((Control) this.groupStadiums);
      this.groupPlayStage.Controls.Add((Control) this.checkMaxteamsgroup);
      this.groupPlayStage.Controls.Add((Control) this.checkMatchReplay);
      this.groupPlayStage.Controls.Add((Control) this.numericMoneyDrop);
      this.groupPlayStage.Controls.Add((Control) this.checkMaxteamsassoc);
      this.groupPlayStage.Controls.Add((Control) this.label10);
      this.groupPlayStage.Controls.Add((Control) this.numericPrizeMoney);
      this.groupPlayStage.Controls.Add((Control) this.label9);
      this.groupPlayStage.Controls.Add((Control) this.comboMatchSituation);
      this.groupPlayStage.Controls.Add((Control) this.label8);
      this.groupPlayStage.Location = new Point(8, 75);
      this.groupPlayStage.Name = "groupPlayStage";
      this.groupPlayStage.Size = new Size(776, 643);
      this.groupPlayStage.TabIndex = 18;
      this.groupPlayStage.TabStop = false;
      this.groupPlayStage.Text = "Play Stage";
      this.numericKeepPointsStageRef.BackColor = Color.Yellow;
      this.numericKeepPointsStageRef.Location = new Point(126, 286);
      this.numericKeepPointsStageRef.Maximum = new Decimal(new int[4]
      {
        100000,
        0,
        0,
        0
      });
      this.numericKeepPointsStageRef.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        int.MinValue
      });
      this.numericKeepPointsStageRef.Name = "numericKeepPointsStageRef";
      this.numericKeepPointsStageRef.Size = new Size(83, 20);
      this.numericKeepPointsStageRef.TabIndex = 174;
      this.numericKeepPointsStageRef.TextAlign = HorizontalAlignment.Center;
      this.toolTip.SetToolTip((Control) this.numericKeepPointsStageRef, "Set this value to the id of the stage from where to keep points");
      this.numericKeepPointsStageRef.ValueChanged += new EventHandler(this.numericKeepPointsStageRef_ValueChanged);
      this.checkRandomDrawEvent.AutoSize = true;
      this.checkRandomDrawEvent.Location = new Point(9, 238);
      this.checkRandomDrawEvent.Name = "checkRandomDrawEvent";
      this.checkRandomDrawEvent.Size = new Size(125, 17);
      this.checkRandomDrawEvent.TabIndex = 173;
      this.checkRandomDrawEvent.Text = "Random Draw Event";
      this.checkRandomDrawEvent.UseVisualStyleBackColor = true;
      this.checkRandomDrawEvent.CheckedChanged += new EventHandler(this.checkRandomDrawEvent_CheckedChanged);
      this.groupLeaguetasks.Controls.Add((Control) this.checkUpdateLeagueTable);
      this.groupLeaguetasks.Controls.Add((Control) this.comboLeagueStats);
      this.groupLeaguetasks.Controls.Add((Control) this.checkUpdateLeagueStats);
      this.groupLeaguetasks.Controls.Add((Control) this.checkClearLeagueStats);
      this.groupLeaguetasks.Location = new Point(3, 431);
      this.groupLeaguetasks.Name = "groupLeaguetasks";
      this.groupLeaguetasks.Size = new Size(358, 125);
      this.groupLeaguetasks.TabIndex = 172;
      this.groupLeaguetasks.TabStop = false;
      this.groupLeaguetasks.Text = "League Actions";
      this.checkUpdateLeagueTable.Location = new Point(6, 96);
      this.checkUpdateLeagueTable.Name = "checkUpdateLeagueTable";
      this.checkUpdateLeagueTable.Size = new Size(139, 23);
      this.checkUpdateLeagueTable.TabIndex = 172;
      this.checkUpdateLeagueTable.Text = "Update League Table";
      this.toolTip.SetToolTip((Control) this.checkUpdateLeagueTable, "Check this only for normal league tournaments");
      this.checkUpdateLeagueTable.UseVisualStyleBackColor = true;
      this.checkUpdateLeagueTable.CheckedChanged += new EventHandler(this.checkUpdateLeagueTable_CheckedChanged);
      this.comboLeagueStats.FormattingEnabled = true;
      this.comboLeagueStats.Location = new Point(6, 19);
      this.comboLeagueStats.Name = "comboLeagueStats";
      this.comboLeagueStats.Size = new Size(346, 21);
      this.comboLeagueStats.TabIndex = 170;
      this.comboLeagueStats.SelectedIndexChanged += new EventHandler(this.comboLeagueStats_SelectedIndexChanged);
      this.checkUpdateLeagueStats.Location = new Point(6, 71);
      this.checkUpdateLeagueStats.Name = "checkUpdateLeagueStats";
      this.checkUpdateLeagueStats.Size = new Size(139, 23);
      this.checkUpdateLeagueStats.TabIndex = 171;
      this.checkUpdateLeagueStats.Text = "Update League Stats";
      this.toolTip.SetToolTip((Control) this.checkUpdateLeagueStats, "Check this for \"Aperture\" and \"Clausura\" tournaments.");
      this.checkUpdateLeagueStats.UseVisualStyleBackColor = true;
      this.checkUpdateLeagueStats.CheckedChanged += new EventHandler(this.checkUpdateLeagueStats_CheckedChanged);
      this.checkClearLeagueStats.Location = new Point(6, 46);
      this.checkClearLeagueStats.Name = "checkClearLeagueStats";
      this.checkClearLeagueStats.Size = new Size(139, 23);
      this.checkClearLeagueStats.TabIndex = 169;
      this.checkClearLeagueStats.Text = "Clear League Stats";
      this.toolTip.SetToolTip((Control) this.checkClearLeagueStats, "Check this only for \"Apertura\" tournaments");
      this.checkClearLeagueStats.UseVisualStyleBackColor = true;
      this.checkClearLeagueStats.CheckedChanged += new EventHandler(this.checkClearLeagueStats_CheckedChanged);
      this.groupStageSchedules.Controls.Add((Control) this.treeStageSchedule);
      this.groupStageSchedules.Controls.Add((Control) this.panelStageScheduleDetails);
      this.groupStageSchedules.Controls.Add((Control) this.toolStageSchedule);
      this.groupStageSchedules.Location = new Point(466, 0);
      this.groupStageSchedules.Name = "groupStageSchedules";
      this.groupStageSchedules.Size = new Size(305, 646);
      this.groupStageSchedules.TabIndex = 19;
      this.groupStageSchedules.TabStop = false;
      this.groupStageSchedules.Text = "Schedules";
      this.treeStageSchedule.Dock = DockStyle.Fill;
      this.treeStageSchedule.FullRowSelect = true;
      this.treeStageSchedule.HideSelection = false;
      this.treeStageSchedule.Location = new Point(3, 220);
      this.treeStageSchedule.Name = "treeStageSchedule";
      this.treeStageSchedule.Size = new Size(299, 423);
      this.treeStageSchedule.TabIndex = 7;
      this.treeStageSchedule.AfterSelect += new TreeViewEventHandler(this.treeStageSchedule_AfterSelect);
      this.panelStageScheduleDetails.Controls.Add((Control) this.groupStageScheduleDetails);
      this.panelStageScheduleDetails.Dock = DockStyle.Top;
      this.panelStageScheduleDetails.Location = new Point(3, 126);
      this.panelStageScheduleDetails.Name = "panelStageScheduleDetails";
      this.panelStageScheduleDetails.Size = new Size(299, 94);
      this.panelStageScheduleDetails.TabIndex = 8;
      this.groupStageScheduleDetails.Controls.Add((Control) this.dateStagePicker);
      this.groupStageScheduleDetails.Controls.Add((Control) this.label37);
      this.groupStageScheduleDetails.Controls.Add((Control) this.numericStageMinGames);
      this.groupStageScheduleDetails.Controls.Add((Control) this.label36);
      this.groupStageScheduleDetails.Controls.Add((Control) this.numericStageMaxGames);
      this.groupStageScheduleDetails.Controls.Add((Control) this.label35);
      this.groupStageScheduleDetails.Controls.Add((Control) this.comboStageTime);
      this.groupStageScheduleDetails.Controls.Add((Control) this.label34);
      this.groupStageScheduleDetails.Location = new Point(3, 0);
      this.groupStageScheduleDetails.Name = "groupStageScheduleDetails";
      this.groupStageScheduleDetails.Size = new Size(264, 90);
      this.groupStageScheduleDetails.TabIndex = 25;
      this.groupStageScheduleDetails.TabStop = false;
      this.dateStagePicker.Location = new Point(12, 13);
      this.dateStagePicker.Name = "dateStagePicker";
      this.dateStagePicker.Size = new Size(241, 20);
      this.dateStagePicker.TabIndex = 17;
      this.dateStagePicker.ValueChanged += new EventHandler(this.dateStagePicker_ValueChanged);
      this.label37.AutoSize = true;
      this.label37.Location = new Point(65, 70);
      this.label37.Name = "label37";
      this.label37.Size = new Size(26, 13);
      this.label37.TabIndex = 24;
      this.label37.Text = "min:";
      this.numericStageMinGames.Location = new Point(95, 65);
      this.numericStageMinGames.Maximum = new Decimal(new int[4]
      {
        80,
        0,
        0,
        0
      });
      this.numericStageMinGames.Name = "numericStageMinGames";
      this.numericStageMinGames.Size = new Size(60, 20);
      this.numericStageMinGames.TabIndex = 18;
      this.numericStageMinGames.TextAlign = HorizontalAlignment.Center;
      this.numericStageMinGames.Value = new Decimal(new int[4]
      {
        12,
        0,
        0,
        0
      });
      this.numericStageMinGames.ValueChanged += new EventHandler(this.numericStageMinGames_ValueChanged);
      this.label36.AutoSize = true;
      this.label36.Location = new Point(162, 70);
      this.label36.Name = "label36";
      this.label36.Size = new Size(29, 13);
      this.label36.TabIndex = 23;
      this.label36.Text = "max:";
      this.numericStageMaxGames.Location = new Point(193, 65);
      this.numericStageMaxGames.Maximum = new Decimal(new int[4]
      {
        80,
        0,
        0,
        0
      });
      this.numericStageMaxGames.Name = "numericStageMaxGames";
      this.numericStageMaxGames.Size = new Size(60, 20);
      this.numericStageMaxGames.TabIndex = 19;
      this.numericStageMaxGames.TextAlign = HorizontalAlignment.Center;
      this.numericStageMaxGames.Value = new Decimal(new int[4]
      {
        30,
        0,
        0,
        0
      });
      this.numericStageMaxGames.ValueChanged += new EventHandler(this.numericStageMaxGames_ValueChanged);
      this.label35.AutoSize = true;
      this.label35.Location = new Point(16, 70);
      this.label35.Name = "label35";
      this.label35.Size = new Size(40, 13);
      this.label35.TabIndex = 22;
      this.label35.Text = "Games";
      this.comboStageTime.FormattingEnabled = true;
      this.comboStageTime.Items.AddRange(new object[47]
      {
        (object) "12.00",
        (object) "12.15",
        (object) "12.30",
        (object) "12.45",
        (object) "13.00",
        (object) "13.15",
        (object) "13.30",
        (object) "13.45",
        (object) "14.00",
        (object) "14.15",
        (object) "14.30",
        (object) "14.45",
        (object) "15.00",
        (object) "15.15",
        (object) "15.30",
        (object) "15.45",
        (object) "16.00",
        (object) "16.15",
        (object) "16.30",
        (object) "16.45",
        (object) "17.00",
        (object) "17.15",
        (object) "17.30",
        (object) "17.45",
        (object) "18.00",
        (object) "18.15",
        (object) "18.30",
        (object) "18.45",
        (object) "19.00",
        (object) "19.15",
        (object) "19.30",
        (object) "19.45",
        (object) "20.00",
        (object) "20.15",
        (object) "20.30",
        (object) "20.45",
        (object) "21.00",
        (object) "21.15",
        (object) "21.30",
        (object) "21.45",
        (object) "22.00",
        (object) "22.15",
        (object) "22.30",
        (object) "22.45",
        (object) "23.00",
        (object) "23.15",
        (object) "23.30"
      });
      this.comboStageTime.Location = new Point(60, 38);
      this.comboStageTime.Name = "comboStageTime";
      this.comboStageTime.Size = new Size(121, 21);
      this.comboStageTime.TabIndex = 20;
      this.comboStageTime.SelectedIndexChanged += new EventHandler(this.comboStageTime_SelectedIndexChanged);
      this.label34.AutoSize = true;
      this.label34.Location = new Point(16, 41);
      this.label34.Name = "label34";
      this.label34.Size = new Size(30, 13);
      this.label34.TabIndex = 21;
      this.label34.Text = "Time";
      this.toolStageSchedule.Items.AddRange(new ToolStripItem[8]
      {
        (ToolStripItem) this.buttonCopyStageCalendar,
        (ToolStripItem) this.buttonPasteStageCalendar,
        (ToolStripItem) this.buttonCleanStageCalendar,
        (ToolStripItem) this.buttonNeewStageLeg,
        (ToolStripItem) this.buttonDeleteStageLeg,
        (ToolStripItem) this.buttonStageAddTime,
        (ToolStripItem) this.buttonStageRemoveTime,
        (ToolStripItem) this.buttonStageSortLegs
      });
      this.toolStageSchedule.LayoutStyle = ToolStripLayoutStyle.Flow;
      this.toolStageSchedule.Location = new Point(3, 16);
      this.toolStageSchedule.Name = "toolStageSchedule";
      this.toolStageSchedule.Size = new Size(299, 110);
      this.toolStageSchedule.TabIndex = 0;
      this.buttonCopyStageCalendar.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonCopyStageCalendar.Image = (Image) resources.GetObject("buttonCopyStageCalendar.Image");
      this.buttonCopyStageCalendar.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonCopyStageCalendar.ImageTransparentColor = Color.Magenta;
      this.buttonCopyStageCalendar.Name = "buttonCopyStageCalendar";
      this.buttonCopyStageCalendar.Size = new Size(52, 52);
      this.buttonCopyStageCalendar.Text = "Copy Calendar";
      this.buttonCopyStageCalendar.Click += new EventHandler(this.buttonCopyStageCalendar_Click);
      this.buttonPasteStageCalendar.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonPasteStageCalendar.Enabled = false;
      this.buttonPasteStageCalendar.Image = (Image) resources.GetObject("buttonPasteStageCalendar.Image");
      this.buttonPasteStageCalendar.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonPasteStageCalendar.ImageTransparentColor = Color.Magenta;
      this.buttonPasteStageCalendar.Name = "buttonPasteStageCalendar";
      this.buttonPasteStageCalendar.Size = new Size(52, 52);
      this.buttonPasteStageCalendar.Text = "Paste Calendar";
      this.buttonPasteStageCalendar.Click += new EventHandler(this.buttonPasteStageCalendar_Click);
      this.buttonCleanStageCalendar.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonCleanStageCalendar.Image = (Image) resources.GetObject("buttonCleanStageCalendar.Image");
      this.buttonCleanStageCalendar.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonCleanStageCalendar.ImageTransparentColor = Color.Magenta;
      this.buttonCleanStageCalendar.Name = "buttonCleanStageCalendar";
      this.buttonCleanStageCalendar.Size = new Size(52, 52);
      this.buttonCleanStageCalendar.Text = "Clean Calendar";
      this.buttonCleanStageCalendar.Click += new EventHandler(this.buttonCleanStageCalendar_Click);
      this.buttonNeewStageLeg.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonNeewStageLeg.Image = (Image) resources.GetObject("buttonNeewStageLeg.Image");
      this.buttonNeewStageLeg.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonNeewStageLeg.ImageTransparentColor = Color.Magenta;
      this.buttonNeewStageLeg.Name = "buttonNeewStageLeg";
      this.buttonNeewStageLeg.Size = new Size(52, 52);
      this.buttonNeewStageLeg.Text = "New Leg";
      this.buttonNeewStageLeg.Click += new EventHandler(this.buttonNewStageLeg_Click);
      this.buttonDeleteStageLeg.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonDeleteStageLeg.Image = (Image) resources.GetObject("buttonDeleteStageLeg.Image");
      this.buttonDeleteStageLeg.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonDeleteStageLeg.ImageTransparentColor = Color.Magenta;
      this.buttonDeleteStageLeg.Name = "buttonDeleteStageLeg";
      this.buttonDeleteStageLeg.Size = new Size(52, 52);
      this.buttonDeleteStageLeg.Text = "Remove Leg";
      this.buttonDeleteStageLeg.Click += new EventHandler(this.buttonDeleteStageLeg_Click);
      this.buttonStageAddTime.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonStageAddTime.Image = (Image) resources.GetObject("buttonStageAddTime.Image");
      this.buttonStageAddTime.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonStageAddTime.ImageTransparentColor = Color.Magenta;
      this.buttonStageAddTime.Name = "buttonStageAddTime";
      this.buttonStageAddTime.Size = new Size(52, 52);
      this.buttonStageAddTime.Text = "Add Time";
      this.buttonStageAddTime.Click += new EventHandler(this.buttonStageAddTime_Click);
      this.buttonStageRemoveTime.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonStageRemoveTime.Image = (Image) resources.GetObject("buttonStageRemoveTime.Image");
      this.buttonStageRemoveTime.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonStageRemoveTime.ImageTransparentColor = Color.Magenta;
      this.buttonStageRemoveTime.Name = "buttonStageRemoveTime";
      this.buttonStageRemoveTime.Size = new Size(52, 52);
      this.buttonStageRemoveTime.Text = "Remove Time";
      this.buttonStageRemoveTime.Click += new EventHandler(this.buttonStageRemoveTime_Click);
      this.buttonStageSortLegs.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonStageSortLegs.Image = (Image) resources.GetObject("buttonStageSortLegs.Image");
      this.buttonStageSortLegs.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonStageSortLegs.ImageTransparentColor = Color.Magenta;
      this.buttonStageSortLegs.Name = "buttonStageSortLegs";
      this.buttonStageSortLegs.Size = new Size(52, 52);
      this.buttonStageSortLegs.Text = "Sort Legs By date";
      this.buttonStageSortLegs.Click += new EventHandler(this.buttonStageSortLegs_Click);
      this.numericRegularSeason.BackColor = Color.Yellow;
      this.numericRegularSeason.Location = new Point(367, 402);
      this.numericRegularSeason.Maximum = new Decimal(new int[4]
      {
        100000,
        0,
        0,
        0
      });
      this.numericRegularSeason.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        int.MinValue
      });
      this.numericRegularSeason.Name = "numericRegularSeason";
      this.numericRegularSeason.Size = new Size(83, 20);
      this.numericRegularSeason.TabIndex = 165;
      this.numericRegularSeason.TextAlign = HorizontalAlignment.Center;
      this.numericRegularSeason.Visible = false;
      this.numericRegularSeason.ValueChanged += new EventHandler(this.numericRegularSeason_ValueChanged);
      this.comboSpecialKo2Rule.FormattingEnabled = true;
      this.comboSpecialKo2Rule.Items.AddRange(new object[4]
      {
        (object) "Away Goal Rule, Extra Time, Penalties ",
        (object) "Extra Time, Penalties (No Away Goal Rule)",
        (object) "Penalties",
        (object) "Regular Season Rank"
      });
      this.comboSpecialKo2Rule.Location = new Point(152, 402);
      this.comboSpecialKo2Rule.Name = "comboSpecialKo2Rule";
      this.comboSpecialKo2Rule.Size = new Size(209, 21);
      this.comboSpecialKo2Rule.TabIndex = 164;
      this.comboSpecialKo2Rule.SelectedIndexChanged += new EventHandler(this.comboSpecialKo2Rule_SelectedIndexChanged);
      this.checkSpecialKo2Rule.Appearance = Appearance.Button;
      this.checkSpecialKo2Rule.Location = new Point(3, 402);
      this.checkSpecialKo2Rule.Name = "checkSpecialKo2Rule";
      this.checkSpecialKo2Rule.Size = new Size(136, 23);
      this.checkSpecialKo2Rule.TabIndex = 163;
      this.checkSpecialKo2Rule.Text = "Special Tie Rule 2 Legs";
      this.toolTip.SetToolTip((Control) this.checkSpecialKo2Rule, "By default use the value defined by the Nation");
      this.checkSpecialKo2Rule.UseVisualStyleBackColor = true;
      this.checkSpecialKo2Rule.CheckedChanged += new EventHandler(this.checkSpecialKo2Rule_CheckedChanged);
      this.comboSpecialKo1Rule.FormattingEnabled = true;
      this.comboSpecialKo1Rule.Items.AddRange(new object[3]
      {
        (object) "Extra Time, Penalties",
        (object) "Penalties",
        (object) "Replay"
      });
      this.comboSpecialKo1Rule.Location = new Point(152, 373);
      this.comboSpecialKo1Rule.Name = "comboSpecialKo1Rule";
      this.comboSpecialKo1Rule.Size = new Size(209, 21);
      this.comboSpecialKo1Rule.TabIndex = 162;
      this.comboSpecialKo1Rule.SelectedIndexChanged += new EventHandler(this.comboSpecialKo1Rule_SelectedIndexChanged);
      this.checkSpecialKo1Rule.Appearance = Appearance.Button;
      this.checkSpecialKo1Rule.Location = new Point(3, 373);
      this.checkSpecialKo1Rule.Name = "checkSpecialKo1Rule";
      this.checkSpecialKo1Rule.Size = new Size(136, 23);
      this.checkSpecialKo1Rule.TabIndex = 161;
      this.checkSpecialKo1Rule.Text = "Special Tie Rule 1 Leg";
      this.toolTip.SetToolTip((Control) this.checkSpecialKo1Rule, "By default use the value defined by the Nation");
      this.checkSpecialKo1Rule.UseVisualStyleBackColor = true;
      this.checkSpecialKo1Rule.CheckedChanged += new EventHandler(this.checkSpecialKo1Rule_CheckedChanged);
      this.numericKeepPointsPercentage.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericKeepPointsPercentage.Location = new Point(126, 260);
      this.numericKeepPointsPercentage.Name = "numericKeepPointsPercentage";
      this.numericKeepPointsPercentage.Size = new Size(83, 20);
      this.numericKeepPointsPercentage.TabIndex = 29;
      this.numericKeepPointsPercentage.TextAlign = HorizontalAlignment.Center;
      this.numericKeepPointsPercentage.ValueChanged += new EventHandler(this.numericKeepPointsPercentage_ValueChanged);
      this.checkKeepPointsPercentage.AutoSize = true;
      this.checkKeepPointsPercentage.Location = new Point(9, 261);
      this.checkKeepPointsPercentage.Name = "checkKeepPointsPercentage";
      this.checkKeepPointsPercentage.Size = new Size(94, 17);
      this.checkKeepPointsPercentage.TabIndex = 28;
      this.checkKeepPointsPercentage.Text = "Keep Points %";
      this.checkKeepPointsPercentage.UseVisualStyleBackColor = true;
      this.checkKeepPointsPercentage.CheckedChanged += new EventHandler(this.checkKeepPointsPercentage_CheckedChanged);
      this.numericStageRef.BackColor = Color.Yellow;
      this.numericStageRef.Location = new Point(126, 190);
      this.numericStageRef.Maximum = new Decimal(new int[4]
      {
        100000,
        0,
        0,
        0
      });
      this.numericStageRef.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        int.MinValue
      });
      this.numericStageRef.Name = "numericStageRef";
      this.numericStageRef.Size = new Size(83, 20);
      this.numericStageRef.TabIndex = 22;
      this.numericStageRef.TextAlign = HorizontalAlignment.Center;
      this.toolTip.SetToolTip((Control) this.numericStageRef, "Set this value to the id of the stage containing the groups");
      this.numericStageRef.ValueChanged += new EventHandler(this.numericStageRef_ValueChanged);
      this.checkClausuraSchedule.AutoSize = true;
      this.checkClausuraSchedule.Location = new Point(9, 215);
      this.checkClausuraSchedule.Name = "checkClausuraSchedule";
      this.checkClausuraSchedule.Size = new Size(115, 17);
      this.checkClausuraSchedule.TabIndex = 23;
      this.checkClausuraSchedule.Text = "Clausura Schedule";
      this.checkClausuraSchedule.UseVisualStyleBackColor = true;
      this.checkClausuraSchedule.CheckedChanged += new EventHandler(this.checkClausuraSchedule_CheckedChanged);
      this.groupStadiums.Controls.Add((Control) this.comboStadium12);
      this.groupStadiums.Controls.Add((Control) this.comboStadium11);
      this.groupStadiums.Controls.Add((Control) this.comboStadium10);
      this.groupStadiums.Controls.Add((Control) this.comboStadium9);
      this.groupStadiums.Controls.Add((Control) this.comboStadium8);
      this.groupStadiums.Controls.Add((Control) this.comboStadium7);
      this.groupStadiums.Controls.Add((Control) this.comboStadium6);
      this.groupStadiums.Controls.Add((Control) this.comboStadium5);
      this.groupStadiums.Controls.Add((Control) this.comboStadium4);
      this.groupStadiums.Controls.Add((Control) this.comboStadium3);
      this.groupStadiums.Controls.Add((Control) this.comboStadium2);
      this.groupStadiums.Controls.Add((Control) this.comboStadium1);
      this.groupStadiums.Location = new Point(228, 16);
      this.groupStadiums.Name = "groupStadiums";
      this.groupStadiums.Size = new Size(222, 347);
      this.groupStadiums.TabIndex = 20;
      this.groupStadiums.TabStop = false;
      this.groupStadiums.Text = "Stadiums";
      this.comboStadium12.FormattingEnabled = true;
      this.comboStadium12.Location = new Point(17, 319);
      this.comboStadium12.Name = "comboStadium12";
      this.comboStadium12.Size = new Size(200, 21);
      this.comboStadium12.TabIndex = 11;
      this.comboStadium12.SelectedIndexChanged += new EventHandler(this.comboStadium12_SelectedIndexChanged);
      this.comboStadium11.FormattingEnabled = true;
      this.comboStadium11.Location = new Point(17, 292);
      this.comboStadium11.Name = "comboStadium11";
      this.comboStadium11.Size = new Size(200, 21);
      this.comboStadium11.TabIndex = 10;
      this.comboStadium11.SelectedIndexChanged += new EventHandler(this.comboStadium11_SelectedIndexChanged);
      this.comboStadium10.FormattingEnabled = true;
      this.comboStadium10.Location = new Point(16, 265);
      this.comboStadium10.Name = "comboStadium10";
      this.comboStadium10.Size = new Size(200, 21);
      this.comboStadium10.TabIndex = 9;
      this.comboStadium10.SelectedIndexChanged += new EventHandler(this.comboStadium10_SelectedIndexChanged);
      this.comboStadium9.FormattingEnabled = true;
      this.comboStadium9.Location = new Point(16, 238);
      this.comboStadium9.Name = "comboStadium9";
      this.comboStadium9.Size = new Size(200, 21);
      this.comboStadium9.TabIndex = 8;
      this.comboStadium9.SelectedIndexChanged += new EventHandler(this.comboStadium9_SelectedIndexChanged);
      this.comboStadium8.FormattingEnabled = true;
      this.comboStadium8.Location = new Point(16, 211);
      this.comboStadium8.Name = "comboStadium8";
      this.comboStadium8.Size = new Size(200, 21);
      this.comboStadium8.TabIndex = 7;
      this.comboStadium8.SelectedIndexChanged += new EventHandler(this.comboStadium8_SelectedIndexChanged);
      this.comboStadium7.FormattingEnabled = true;
      this.comboStadium7.Location = new Point(17, 184);
      this.comboStadium7.Name = "comboStadium7";
      this.comboStadium7.Size = new Size(200, 21);
      this.comboStadium7.TabIndex = 6;
      this.comboStadium7.SelectedIndexChanged += new EventHandler(this.comboStadium7_SelectedIndexChanged);
      this.comboStadium6.FormattingEnabled = true;
      this.comboStadium6.Location = new Point(17, 157);
      this.comboStadium6.Name = "comboStadium6";
      this.comboStadium6.Size = new Size(200, 21);
      this.comboStadium6.TabIndex = 5;
      this.comboStadium6.SelectedIndexChanged += new EventHandler(this.comboStadium6_SelectedIndexChanged);
      this.comboStadium5.FormattingEnabled = true;
      this.comboStadium5.Location = new Point(16, 130);
      this.comboStadium5.Name = "comboStadium5";
      this.comboStadium5.Size = new Size(200, 21);
      this.comboStadium5.TabIndex = 4;
      this.comboStadium5.SelectedIndexChanged += new EventHandler(this.comboStadium5_SelectedIndexChanged);
      this.comboStadium4.FormattingEnabled = true;
      this.comboStadium4.Location = new Point(17, 103);
      this.comboStadium4.Name = "comboStadium4";
      this.comboStadium4.Size = new Size(200, 21);
      this.comboStadium4.TabIndex = 3;
      this.comboStadium4.SelectedIndexChanged += new EventHandler(this.comboStadium4_SelectedIndexChanged);
      this.comboStadium3.FormattingEnabled = true;
      this.comboStadium3.Location = new Point(16, 76);
      this.comboStadium3.Name = "comboStadium3";
      this.comboStadium3.Size = new Size(200, 21);
      this.comboStadium3.TabIndex = 2;
      this.comboStadium3.SelectedIndexChanged += new EventHandler(this.comboStadium3_SelectedIndexChanged);
      this.comboStadium2.FormattingEnabled = true;
      this.comboStadium2.Location = new Point(16, 49);
      this.comboStadium2.Name = "comboStadium2";
      this.comboStadium2.Size = new Size(200, 21);
      this.comboStadium2.TabIndex = 1;
      this.comboStadium2.SelectedIndexChanged += new EventHandler(this.comboStadium2_SelectedIndexChanged);
      this.comboStadium1.FormattingEnabled = true;
      this.comboStadium1.Location = new Point(17, 22);
      this.comboStadium1.Name = "comboStadium1";
      this.comboStadium1.Size = new Size(200, 21);
      this.comboStadium1.TabIndex = 0;
      this.comboStadium1.SelectedIndexChanged += new EventHandler(this.comboStadium1_SelectedIndexChanged);
      this.checkMaxteamsgroup.AutoSize = true;
      this.checkMaxteamsgroup.Location = new Point(9, 191);
      this.checkMaxteamsgroup.Name = "checkMaxteamsgroup";
      this.checkMaxteamsgroup.Size = new Size(111, 17);
      this.checkMaxteamsgroup.TabIndex = 2;
      this.checkMaxteamsgroup.Text = "Avoid same group";
      this.checkMaxteamsgroup.UseVisualStyleBackColor = true;
      this.checkMaxteamsgroup.CheckedChanged += new EventHandler(this.checkMaxteamsgroup_CheckedChanged);
      this.checkMatchReplay.AutoSize = true;
      this.checkMatchReplay.Location = new Point(9, 145);
      this.checkMatchReplay.Name = "checkMatchReplay";
      this.checkMatchReplay.Size = new Size(92, 17);
      this.checkMatchReplay.TabIndex = 22;
      this.checkMatchReplay.Text = "Match Replay";
      this.checkMatchReplay.UseVisualStyleBackColor = true;
      this.checkMatchReplay.CheckedChanged += new EventHandler(this.checkMatchReplay_CheckedChanged);
      this.numericMoneyDrop.Location = new Point(135, 86);
      this.numericMoneyDrop.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        int.MinValue
      });
      this.numericMoneyDrop.Name = "numericMoneyDrop";
      this.numericMoneyDrop.Size = new Size(83, 20);
      this.numericMoneyDrop.TabIndex = 21;
      this.numericMoneyDrop.TextAlign = HorizontalAlignment.Center;
      this.numericMoneyDrop.ValueChanged += new EventHandler(this.numericMoneyDrop_ValueChanged);
      this.checkMaxteamsassoc.AutoSize = true;
      this.checkMaxteamsassoc.Location = new Point(9, 168);
      this.checkMaxteamsassoc.Name = "checkMaxteamsassoc";
      this.checkMaxteamsassoc.Size = new Size(122, 17);
      this.checkMaxteamsassoc.TabIndex = 1;
      this.checkMaxteamsassoc.Text = "Avoid Same Country";
      this.checkMaxteamsassoc.UseVisualStyleBackColor = true;
      this.checkMaxteamsassoc.CheckedChanged += new EventHandler(this.checkMaxteamsassoc_CheckedChanged);
      this.label10.AutoSize = true;
      this.label10.Location = new Point(6, 90);
      this.label10.Name = "label10";
      this.label10.Size = new Size(123, 13);
      this.label10.TabIndex = 20;
      this.label10.Text = "Money Drop Percentage";
      this.numericPrizeMoney.Increment = new Decimal(new int[4]
      {
        1000,
        0,
        0,
        0
      });
      this.numericPrizeMoney.Location = new Point(97, 60);
      this.numericPrizeMoney.Maximum = new Decimal(new int[4]
      {
        20000000,
        0,
        0,
        0
      });
      this.numericPrizeMoney.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        int.MinValue
      });
      this.numericPrizeMoney.Name = "numericPrizeMoney";
      this.numericPrizeMoney.Size = new Size(120, 20);
      this.numericPrizeMoney.TabIndex = 19;
      this.numericPrizeMoney.TextAlign = HorizontalAlignment.Center;
      this.numericPrizeMoney.ValueChanged += new EventHandler(this.numericPrizeMoney_ValueChanged);
      this.label9.AutoSize = true;
      this.label9.Location = new Point(6, 67);
      this.label9.Name = "label9";
      this.label9.Size = new Size(65, 13);
      this.label9.TabIndex = 18;
      this.label9.Text = "Prize Money";
      this.comboMatchSituation.FormattingEnabled = true;
      this.comboMatchSituation.Items.AddRange(new object[11]
      {
        (object) "FRIENDLY",
        (object) "LEAGUE",
        (object) "QUALIFY",
        (object) "GROUP",
        (object) "ROUND16",
        (object) "ROUNDX",
        (object) "QUARTER",
        (object) "SEMI",
        (object) "FINAL",
        (object) "THIRDPLACE",
        (object) "REPLAY"
      });
      this.comboMatchSituation.Location = new Point(97, 23);
      this.comboMatchSituation.Name = "comboMatchSituation";
      this.comboMatchSituation.Size = new Size(121, 21);
      this.comboMatchSituation.TabIndex = 17;
      this.comboMatchSituation.SelectedIndexChanged += new EventHandler(this.comboMatchSituation_SelectedIndexChanged);
      this.label8.AutoSize = true;
      this.label8.Location = new Point(6, 26);
      this.label8.Name = "label8";
      this.label8.Size = new Size(81, 13);
      this.label8.TabIndex = 16;
      this.label8.Text = "Match Situation";
      this.comboStageStandingRules.FormattingEnabled = true;
      this.comboStageStandingRules.Items.AddRange(new object[6]
      {
        (object) "Points, Goals, Wins",
        (object) "Points. Wins, Goals",
        (object) "Points, Head To Head, Goals",
        (object) "Team Rating",
        (object) "Previous Ranking",
        (object) "Points, Goals, Head To Head"
      });
      this.comboStageStandingRules.Location = new Point(155, 46);
      this.comboStageStandingRules.Name = "comboStageStandingRules";
      this.comboStageStandingRules.Size = new Size(185, 21);
      this.comboStageStandingRules.TabIndex = 162;
      this.comboStageStandingRules.SelectedIndexChanged += new EventHandler(this.comboStageStandingRules_SelectedIndexChanged);
      this.checkStageStandingsRules.Appearance = Appearance.Button;
      this.checkStageStandingsRules.Location = new Point(6, 46);
      this.checkStageStandingsRules.Name = "checkStageStandingsRules";
      this.checkStageStandingsRules.Size = new Size(136, 23);
      this.checkStageStandingsRules.TabIndex = 161;
      this.checkStageStandingsRules.Text = "Special Standing Rules";
      this.toolTip.SetToolTip((Control) this.checkStageStandingsRules, "By default use the value defined by the Nation");
      this.checkStageStandingsRules.UseVisualStyleBackColor = true;
      this.checkStageStandingsRules.CheckedChanged += new EventHandler(this.checkStageStandingsRules_CheckedChanged);
      this.numericStandingsRank.BackColor = Color.Yellow;
      this.numericStandingsRank.Location = new Point(480, 46);
      this.numericStandingsRank.Maximum = new Decimal(new int[4]
      {
        100000,
        0,
        0,
        0
      });
      this.numericStandingsRank.Name = "numericStandingsRank";
      this.numericStandingsRank.Size = new Size(83, 20);
      this.numericStandingsRank.TabIndex = 167;
      this.numericStandingsRank.TextAlign = HorizontalAlignment.Center;
      this.numericStandingsRank.ValueChanged += new EventHandler(this.numericStandingsRank_ValueChanged);
      this.checkStandingsRank.AutoSize = true;
      this.checkStandingsRank.Location = new Point(363, 47);
      this.checkStandingsRank.Name = "checkStandingsRank";
      this.checkStandingsRank.Size = new Size(102, 17);
      this.checkStandingsRank.TabIndex = 166;
      this.checkStandingsRank.Text = "Standings Rank";
      this.checkStandingsRank.UseVisualStyleBackColor = true;
      this.checkStandingsRank.CheckedChanged += new EventHandler(this.checkStandingsRank_CheckedChanged);
      this.comboStageType.FormattingEnabled = true;
      this.comboStageType.Items.AddRange(new object[5]
      {
        (object) "SETUP",
        (object) "FRIENDLY",
        (object) "LEAGUE",
        (object) "KO1LEG",
        (object) "KO2LEGS"
      });
      this.comboStageType.Location = new Point(106, 20);
      this.comboStageType.Name = "comboStageType";
      this.comboStageType.Size = new Size(121, 21);
      this.comboStageType.TabIndex = 15;
      this.comboStageType.SelectedIndexChanged += new EventHandler(this.comboStageType_SelectedIndexChanged);
      this.label7.AutoSize = true;
      this.label7.Location = new Point(6, 26);
      this.label7.Name = "label7";
      this.label7.Size = new Size(62, 13);
      this.label7.TabIndex = 14;
      this.label7.Text = "Stage Type";
      this.numericStandingKeep.BackColor = Color.Yellow;
      this.numericStandingKeep.Location = new Point(480, 20);
      this.numericStandingKeep.Maximum = new Decimal(new int[4]
      {
        100000,
        0,
        0,
        0
      });
      this.numericStandingKeep.Name = "numericStandingKeep";
      this.numericStandingKeep.Size = new Size(83, 20);
      this.numericStandingKeep.TabIndex = 27;
      this.numericStandingKeep.TextAlign = HorizontalAlignment.Center;
      this.numericStandingKeep.ValueChanged += new EventHandler(this.numericStandingKeep_ValueChanged);
      this.checkStandingKeep.AutoSize = true;
      this.checkStandingKeep.Location = new Point(363, 21);
      this.checkStandingKeep.Name = "checkStandingKeep";
      this.checkStandingKeep.Size = new Size(99, 17);
      this.checkStandingKeep.TabIndex = 26;
      this.checkStandingKeep.Text = "Keep standings";
      this.checkStandingKeep.UseVisualStyleBackColor = true;
      this.checkStandingKeep.CheckedChanged += new EventHandler(this.checkStandingKeep_CheckedChanged);
      this.toolCompetitionTree.AutoSize = false;
      this.toolCompetitionTree.GripStyle = ToolStripGripStyle.Hidden;
      this.toolCompetitionTree.Items.AddRange(new ToolStripItem[11]
      {
        (ToolStripItem) this.buttonAddTrophy,
        (ToolStripItem) this.buttonDeleteTrophy,
        (ToolStripItem) this.buttonAddStage,
        (ToolStripItem) this.buttonDeleteStage,
        (ToolStripItem) this.buttonAddGroup,
        (ToolStripItem) this.buttonDeleteGroup,
        (ToolStripItem) this.buttonAddNatiom,
        (ToolStripItem) this.buttonDeleteNation,
        (ToolStripItem) this.buttonPasteTrophy,
        (ToolStripItem) this.buttonCopyTrophy,
        (ToolStripItem) this.comboTargetLeague
      });
      this.toolCompetitionTree.Location = new Point(0, 0);
      this.toolCompetitionTree.Name = "toolCompetitionTree";
      this.toolCompetitionTree.Size = new Size(285, 52);
      this.toolCompetitionTree.TabIndex = 14;
      this.toolCompetitionTree.Text = "stripToolWorld";
      this.buttonAddTrophy.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonAddTrophy.Image = (Image) resources.GetObject("buttonAddTrophy.Image");
      this.buttonAddTrophy.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonAddTrophy.ImageTransparentColor = Color.Transparent;
      this.buttonAddTrophy.Name = "buttonAddTrophy";
      this.buttonAddTrophy.Size = new Size(52, 49);
      this.buttonAddTrophy.Text = "Add Trophy";
      this.buttonAddTrophy.Visible = false;
      this.buttonAddTrophy.Click += new EventHandler(this.buttonAddTrophy_Click);
      this.buttonDeleteTrophy.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonDeleteTrophy.Image = (Image) resources.GetObject("buttonDeleteTrophy.Image");
      this.buttonDeleteTrophy.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonDeleteTrophy.ImageTransparentColor = Color.Magenta;
      this.buttonDeleteTrophy.Name = "buttonDeleteTrophy";
      this.buttonDeleteTrophy.Size = new Size(52, 49);
      this.buttonDeleteTrophy.Text = "Delete Trophy";
      this.buttonDeleteTrophy.Visible = false;
      this.buttonDeleteTrophy.Click += new EventHandler(this.buttonDeleteTrophy_Click);
      this.buttonAddStage.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonAddStage.Image = (Image) resources.GetObject("buttonAddStage.Image");
      this.buttonAddStage.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonAddStage.ImageTransparentColor = Color.Magenta;
      this.buttonAddStage.Name = "buttonAddStage";
      this.buttonAddStage.Size = new Size(52, 49);
      this.buttonAddStage.Text = "Add Stage";
      this.buttonAddStage.Visible = false;
      this.buttonAddStage.Click += new EventHandler(this.buttonAddStage_Click);
      this.buttonDeleteStage.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonDeleteStage.Image = (Image) resources.GetObject("buttonDeleteStage.Image");
      this.buttonDeleteStage.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonDeleteStage.ImageTransparentColor = Color.Magenta;
      this.buttonDeleteStage.Name = "buttonDeleteStage";
      this.buttonDeleteStage.Size = new Size(52, 49);
      this.buttonDeleteStage.Text = "Delete Stage";
      this.buttonDeleteStage.Visible = false;
      this.buttonDeleteStage.Click += new EventHandler(this.buttonDeleteStage_Click);
      this.buttonAddGroup.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonAddGroup.Image = (Image) resources.GetObject("buttonAddGroup.Image");
      this.buttonAddGroup.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonAddGroup.ImageTransparentColor = Color.Magenta;
      this.buttonAddGroup.Name = "buttonAddGroup";
      this.buttonAddGroup.Size = new Size(52, 49);
      this.buttonAddGroup.Text = "Add Group";
      this.buttonAddGroup.Visible = false;
      this.buttonAddGroup.Click += new EventHandler(this.buttonAddGroup_Click);
      this.buttonDeleteGroup.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonDeleteGroup.Image = (Image) resources.GetObject("buttonDeleteGroup.Image");
      this.buttonDeleteGroup.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonDeleteGroup.ImageTransparentColor = Color.Magenta;
      this.buttonDeleteGroup.Name = "buttonDeleteGroup";
      this.buttonDeleteGroup.Size = new Size(52, 49);
      this.buttonDeleteGroup.Text = "Delete Group";
      this.buttonDeleteGroup.Visible = false;
      this.buttonDeleteGroup.Click += new EventHandler(this.buttonDeleteGroup_Click);
      this.buttonAddNatiom.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonAddNatiom.Image = (Image) resources.GetObject("buttonAddNatiom.Image");
      this.buttonAddNatiom.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonAddNatiom.ImageTransparentColor = Color.Magenta;
      this.buttonAddNatiom.Name = "buttonAddNatiom";
      this.buttonAddNatiom.Size = new Size(52, 49);
      this.buttonAddNatiom.Text = "Add Nation";
      this.buttonAddNatiom.Visible = false;
      this.buttonAddNatiom.Click += new EventHandler(this.buttonAddNatiom_Click);
      this.buttonDeleteNation.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonDeleteNation.Image = (Image) resources.GetObject("buttonDeleteNation.Image");
      this.buttonDeleteNation.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonDeleteNation.ImageTransparentColor = Color.Magenta;
      this.buttonDeleteNation.Name = "buttonDeleteNation";
      this.buttonDeleteNation.Size = new Size(52, 49);
      this.buttonDeleteNation.Text = "Delete Nation";
      this.buttonDeleteNation.Visible = false;
      this.buttonDeleteNation.Click += new EventHandler(this.buttonDeleteNation_Click);
      this.buttonPasteTrophy.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonPasteTrophy.Enabled = false;
      this.buttonPasteTrophy.Image = (Image) resources.GetObject("buttonPasteTrophy.Image");
      this.buttonPasteTrophy.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonPasteTrophy.ImageTransparentColor = Color.Magenta;
      this.buttonPasteTrophy.Name = "buttonPasteTrophy";
      this.buttonPasteTrophy.Size = new Size(52, 49);
      this.buttonPasteTrophy.Text = "Paste Trophy";
      this.buttonPasteTrophy.Visible = false;
      this.buttonPasteTrophy.Click += new EventHandler(this.buttonPasteTrophy_Click);
      this.buttonCopyTrophy.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonCopyTrophy.Image = (Image) resources.GetObject("buttonCopyTrophy.Image");
      this.buttonCopyTrophy.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonCopyTrophy.ImageTransparentColor = Color.Magenta;
      this.buttonCopyTrophy.Name = "buttonCopyTrophy";
      this.buttonCopyTrophy.Size = new Size(52, 49);
      this.buttonCopyTrophy.Text = "Copy Trophy";
      this.buttonCopyTrophy.Visible = false;
      this.buttonCopyTrophy.Click += new EventHandler(this.buttonCopyTrophy_Click);
      this.comboTargetLeague.Enabled = false;
      this.comboTargetLeague.Name = "comboTargetLeague";
      this.comboTargetLeague.Size = new Size(125, 52);
      this.comboTargetLeague.ToolTipText = "Select Target League for \"Paste Trophy\"";
      this.splitContainer1.Dock = DockStyle.Fill;
      this.splitContainer1.Location = new Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Panel1.AutoScroll = true;
      this.splitContainer1.Panel1.Controls.Add((Control) this.treeWorld);
      this.splitContainer1.Panel1.Controls.Add((Control) this.toolCompetitionTree);
      this.splitContainer1.Panel2.AutoScroll = true;
      this.splitContainer1.Panel2.Controls.Add((Control) this.tabCompetitions);
      this.splitContainer1.Panel2.Controls.Add((Control) this.panelCompObj);
      this.splitContainer1.Size = new Size(1087, 780);
      this.splitContainer1.SplitterDistance = 285;
      this.splitContainer1.TabIndex = 15;
      this.tabCompetitions.Controls.Add((Control) this.pageWorld);
      this.tabCompetitions.Controls.Add((Control) this.pageConfederation);
      this.tabCompetitions.Controls.Add((Control) this.pageNation);
      this.tabCompetitions.Controls.Add((Control) this.pageTrophy);
      this.tabCompetitions.Controls.Add((Control) this.pageStage);
      this.tabCompetitions.Controls.Add((Control) this.pageGroup);
      this.tabCompetitions.Dock = DockStyle.Fill;
      this.tabCompetitions.Location = new Point(0, 30);
      this.tabCompetitions.Name = "tabCompetitions";
      this.tabCompetitions.SelectedIndex = 0;
      this.tabCompetitions.Size = new Size(798, 750);
      this.tabCompetitions.TabIndex = 6;
      this.tabCompetitions.SelectedIndexChanged += new EventHandler(this.tabCompetitions_SelectedIndexChanged);
      this.pageWorld.Controls.Add((Control) this.numericStartYear);
      this.pageWorld.Controls.Add((Control) this.label13);
      this.pageWorld.Location = new Point(4, 22);
      this.pageWorld.Name = "pageWorld";
      this.pageWorld.Padding = new Padding(3);
      this.pageWorld.Size = new Size(790, 724);
      this.pageWorld.TabIndex = 5;
      this.pageWorld.Text = "FIFA";
      this.pageWorld.UseVisualStyleBackColor = true;
      this.numericStartYear.Location = new Point(118, 30);
      this.numericStartYear.Maximum = new Decimal(new int[4]
      {
        9999,
        0,
        0,
        0
      });
      this.numericStartYear.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        int.MinValue
      });
      this.numericStartYear.Name = "numericStartYear";
      this.numericStartYear.Size = new Size(120, 20);
      this.numericStartYear.TabIndex = 21;
      this.numericStartYear.TextAlign = HorizontalAlignment.Center;
      this.numericStartYear.Value = new Decimal(new int[4]
      {
        2010,
        0,
        0,
        0
      });
      this.numericStartYear.ValueChanged += new EventHandler(this.numericStartYear_ValueChanged);
      this.label13.AutoSize = true;
      this.label13.Location = new Point(27, 37);
      this.label13.Name = "label13";
      this.label13.Size = new Size(54, 13);
      this.label13.TabIndex = 20;
      this.label13.Text = "Year Start";
      this.pageConfederation.Controls.Add((Control) this.groupConfederation);
      this.pageConfederation.Location = new Point(4, 22);
      this.pageConfederation.Name = "pageConfederation";
      this.pageConfederation.Padding = new Padding(3);
      this.pageConfederation.Size = new Size(790, 724);
      this.pageConfederation.TabIndex = 0;
      this.pageConfederation.Text = "Confederation";
      this.pageConfederation.UseVisualStyleBackColor = true;
      this.pageNation.AutoScroll = true;
      this.pageNation.Controls.Add((Control) this.groupNation);
      this.pageNation.Location = new Point(4, 22);
      this.pageNation.Name = "pageNation";
      this.pageNation.Padding = new Padding(3);
      this.pageNation.Size = new Size(790, 724);
      this.pageNation.TabIndex = 1;
      this.pageNation.Text = "Nation";
      this.pageNation.UseVisualStyleBackColor = true;
      this.pageTrophy.AutoScroll = true;
      this.pageTrophy.Controls.Add((Control) this.tabTrophy);
      this.pageTrophy.Location = new Point(4, 22);
      this.pageTrophy.Name = "pageTrophy";
      this.pageTrophy.Size = new Size(790, 724);
      this.pageTrophy.TabIndex = 2;
      this.pageTrophy.Text = "Trophy";
      this.pageTrophy.UseVisualStyleBackColor = true;
      this.tabTrophy.Controls.Add((Control) this.tabPageTrophyStructure);
      this.tabTrophy.Controls.Add((Control) this.tabPageRankingTable);
      this.tabTrophy.Controls.Add((Control) this.tabPageTrophyGraphics);
      this.tabTrophy.Dock = DockStyle.Fill;
      this.tabTrophy.Location = new Point(0, 0);
      this.tabTrophy.Name = "tabTrophy";
      this.tabTrophy.SelectedIndex = 0;
      this.tabTrophy.Size = new Size(790, 724);
      this.tabTrophy.TabIndex = 10;
      this.tabTrophy.SelectedIndexChanged += new EventHandler(this.tabTrophy_SelectedIndexChanged);
      this.tabPageTrophyStructure.Controls.Add((Control) this.groupTrophy);
      this.tabPageTrophyStructure.Location = new Point(4, 22);
      this.tabPageTrophyStructure.Name = "tabPageTrophyStructure";
      this.tabPageTrophyStructure.Padding = new Padding(3);
      this.tabPageTrophyStructure.Size = new Size(782, 698);
      this.tabPageTrophyStructure.TabIndex = 0;
      this.tabPageTrophyStructure.Text = "Structure";
      this.tabPageTrophyStructure.UseVisualStyleBackColor = true;
      this.tabPageRankingTable.Controls.Add((Control) this.groupInitTeams);
      this.tabPageRankingTable.Location = new Point(4, 22);
      this.tabPageRankingTable.Name = "tabPageRankingTable";
      this.tabPageRankingTable.Size = new Size(782, 698);
      this.tabPageRankingTable.TabIndex = 2;
      this.tabPageRankingTable.Text = "Ranking Table";
      this.tabPageRankingTable.UseVisualStyleBackColor = true;
      this.groupInitTeams.Controls.Add((Control) this.label70);
      this.groupInitTeams.Controls.Add((Control) this.numericUpdateTableEntries);
      this.groupInitTeams.Controls.Add((Control) this.panelInitTeam24);
      this.groupInitTeams.Controls.Add((Control) this.panelInitTeam23);
      this.groupInitTeams.Controls.Add((Control) this.panelInitTeam22);
      this.groupInitTeams.Controls.Add((Control) this.panelInitTeam21);
      this.groupInitTeams.Controls.Add((Control) this.panelInitTeam20);
      this.groupInitTeams.Controls.Add((Control) this.panelInitTeam19);
      this.groupInitTeams.Controls.Add((Control) this.panelInitTeam18);
      this.groupInitTeams.Controls.Add((Control) this.panelInitTeam17);
      this.groupInitTeams.Controls.Add((Control) this.panelInitTeam16);
      this.groupInitTeams.Controls.Add((Control) this.panelInitTeam15);
      this.groupInitTeams.Controls.Add((Control) this.panelInitTeam14);
      this.groupInitTeams.Controls.Add((Control) this.panelInitTeam13);
      this.groupInitTeams.Controls.Add((Control) this.panelInitTeam12);
      this.groupInitTeams.Controls.Add((Control) this.panelInitTeam11);
      this.groupInitTeams.Controls.Add((Control) this.panelInitTeam10);
      this.groupInitTeams.Controls.Add((Control) this.panelInitTeam9);
      this.groupInitTeams.Controls.Add((Control) this.panelInitTeam8);
      this.groupInitTeams.Controls.Add((Control) this.panelInitTeam7);
      this.groupInitTeams.Controls.Add((Control) this.panelInitTeam6);
      this.groupInitTeams.Controls.Add((Control) this.panelInitTeam5);
      this.groupInitTeams.Controls.Add((Control) this.panelInitTeam4);
      this.groupInitTeams.Controls.Add((Control) this.panelInitTeam3);
      this.groupInitTeams.Controls.Add((Control) this.panelInitTeam2);
      this.groupInitTeams.Controls.Add((Control) this.panelInitTeam1);
      this.groupInitTeams.Location = new Point(10, 3);
      this.groupInitTeams.Name = "groupInitTeams";
      this.groupInitTeams.Size = new Size(522, 657);
      this.groupInitTeams.TabIndex = 163;
      this.groupInitTeams.TabStop = false;
      this.groupInitTeams.Text = "Ranking";
      this.label70.AutoSize = true;
      this.label70.Location = new Point(12, 18);
      this.label70.Name = "label70";
      this.label70.Size = new Size(75, 13);
      this.label70.TabIndex = 24;
      this.label70.Text = "N. of Positions";
      this.numericUpdateTableEntries.Location = new Point(108, 14);
      this.numericUpdateTableEntries.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericUpdateTableEntries.Name = "numericUpdateTableEntries";
      this.numericUpdateTableEntries.Size = new Size(74, 20);
      this.numericUpdateTableEntries.TabIndex = 25;
      this.numericUpdateTableEntries.TextAlign = HorizontalAlignment.Center;
      this.numericUpdateTableEntries.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpdateTableEntries.ValueChanged += new EventHandler(this.numericUpdateTableEntries_ValueChanged);
      this.panelInitTeam24.Controls.Add((Control) this.labelUpdateTable24);
      this.panelInitTeam24.Controls.Add((Control) this.comboInitTeam24);
      this.panelInitTeam24.Controls.Add((Control) this.label65);
      this.panelInitTeam24.Location = new Point(7, 618);
      this.panelInitTeam24.Name = "panelInitTeam24";
      this.panelInitTeam24.Size = new Size(500, 25);
      this.panelInitTeam24.TabIndex = 23;
      this.labelUpdateTable24.BorderStyle = BorderStyle.FixedSingle;
      this.labelUpdateTable24.Cursor = Cursors.Hand;
      this.labelUpdateTable24.Dock = DockStyle.Fill;
      this.labelUpdateTable24.Location = new Point(28, 0);
      this.labelUpdateTable24.Name = "labelUpdateTable24";
      this.labelUpdateTable24.Size = new Size(292, 25);
      this.labelUpdateTable24.TabIndex = 4;
      this.labelUpdateTable24.TextAlign = ContentAlignment.MiddleLeft;
      this.labelUpdateTable24.Click += new EventHandler(this.labelUpdateTable_Click);
      this.comboInitTeam24.Dock = DockStyle.Right;
      this.comboInitTeam24.FormattingEnabled = true;
      this.comboInitTeam24.Location = new Point(320, 0);
      this.comboInitTeam24.Name = "comboInitTeam24";
      this.comboInitTeam24.Size = new Size(180, 21);
      this.comboInitTeam24.Sorted = true;
      this.comboInitTeam24.TabIndex = 1;
      this.label65.Dock = DockStyle.Left;
      this.label65.Location = new Point(0, 0);
      this.label65.Name = "label65";
      this.label65.Size = new Size(28, 25);
      this.label65.TabIndex = 0;
      this.label65.Text = "24.";
      this.label65.TextAlign = ContentAlignment.MiddleLeft;
      this.panelInitTeam23.Controls.Add((Control) this.labelUpdateTable23);
      this.panelInitTeam23.Controls.Add((Control) this.comboInitTeam23);
      this.panelInitTeam23.Controls.Add((Control) this.label64);
      this.panelInitTeam23.Location = new Point(7, 593);
      this.panelInitTeam23.Name = "panelInitTeam23";
      this.panelInitTeam23.Size = new Size(500, 25);
      this.panelInitTeam23.TabIndex = 22;
      this.labelUpdateTable23.BorderStyle = BorderStyle.FixedSingle;
      this.labelUpdateTable23.Cursor = Cursors.Hand;
      this.labelUpdateTable23.Dock = DockStyle.Fill;
      this.labelUpdateTable23.Location = new Point(28, 0);
      this.labelUpdateTable23.Name = "labelUpdateTable23";
      this.labelUpdateTable23.Size = new Size(292, 25);
      this.labelUpdateTable23.TabIndex = 4;
      this.labelUpdateTable23.TextAlign = ContentAlignment.MiddleLeft;
      this.labelUpdateTable23.Click += new EventHandler(this.labelUpdateTable_Click);
      this.comboInitTeam23.Dock = DockStyle.Right;
      this.comboInitTeam23.FormattingEnabled = true;
      this.comboInitTeam23.Location = new Point(320, 0);
      this.comboInitTeam23.Name = "comboInitTeam23";
      this.comboInitTeam23.Size = new Size(180, 21);
      this.comboInitTeam23.Sorted = true;
      this.comboInitTeam23.TabIndex = 1;
      this.label64.Dock = DockStyle.Left;
      this.label64.Location = new Point(0, 0);
      this.label64.Name = "label64";
      this.label64.Size = new Size(28, 25);
      this.label64.TabIndex = 0;
      this.label64.Text = "23.";
      this.label64.TextAlign = ContentAlignment.MiddleLeft;
      this.panelInitTeam22.Controls.Add((Control) this.labelUpdateTable22);
      this.panelInitTeam22.Controls.Add((Control) this.comboInitTeam22);
      this.panelInitTeam22.Controls.Add((Control) this.label63);
      this.panelInitTeam22.Location = new Point(7, 568);
      this.panelInitTeam22.Name = "panelInitTeam22";
      this.panelInitTeam22.Size = new Size(500, 25);
      this.panelInitTeam22.TabIndex = 21;
      this.labelUpdateTable22.BorderStyle = BorderStyle.FixedSingle;
      this.labelUpdateTable22.Cursor = Cursors.Hand;
      this.labelUpdateTable22.Dock = DockStyle.Fill;
      this.labelUpdateTable22.Location = new Point(28, 0);
      this.labelUpdateTable22.Name = "labelUpdateTable22";
      this.labelUpdateTable22.Size = new Size(292, 25);
      this.labelUpdateTable22.TabIndex = 4;
      this.labelUpdateTable22.TextAlign = ContentAlignment.MiddleLeft;
      this.labelUpdateTable22.Click += new EventHandler(this.labelUpdateTable_Click);
      this.comboInitTeam22.Dock = DockStyle.Right;
      this.comboInitTeam22.FormattingEnabled = true;
      this.comboInitTeam22.Location = new Point(320, 0);
      this.comboInitTeam22.Name = "comboInitTeam22";
      this.comboInitTeam22.Size = new Size(180, 21);
      this.comboInitTeam22.Sorted = true;
      this.comboInitTeam22.TabIndex = 1;
      this.label63.Dock = DockStyle.Left;
      this.label63.Location = new Point(0, 0);
      this.label63.Name = "label63";
      this.label63.Size = new Size(28, 25);
      this.label63.TabIndex = 0;
      this.label63.Text = "22.";
      this.label63.TextAlign = ContentAlignment.MiddleLeft;
      this.panelInitTeam21.Controls.Add((Control) this.labelUpdateTable21);
      this.panelInitTeam21.Controls.Add((Control) this.comboInitTeam21);
      this.panelInitTeam21.Controls.Add((Control) this.label62);
      this.panelInitTeam21.Location = new Point(7, 543);
      this.panelInitTeam21.Name = "panelInitTeam21";
      this.panelInitTeam21.Size = new Size(500, 25);
      this.panelInitTeam21.TabIndex = 20;
      this.labelUpdateTable21.BorderStyle = BorderStyle.FixedSingle;
      this.labelUpdateTable21.Cursor = Cursors.Hand;
      this.labelUpdateTable21.Dock = DockStyle.Fill;
      this.labelUpdateTable21.Location = new Point(28, 0);
      this.labelUpdateTable21.Name = "labelUpdateTable21";
      this.labelUpdateTable21.Size = new Size(292, 25);
      this.labelUpdateTable21.TabIndex = 4;
      this.labelUpdateTable21.TextAlign = ContentAlignment.MiddleLeft;
      this.labelUpdateTable21.Click += new EventHandler(this.labelUpdateTable_Click);
      this.comboInitTeam21.Dock = DockStyle.Right;
      this.comboInitTeam21.FormattingEnabled = true;
      this.comboInitTeam21.Location = new Point(320, 0);
      this.comboInitTeam21.Name = "comboInitTeam21";
      this.comboInitTeam21.Size = new Size(180, 21);
      this.comboInitTeam21.Sorted = true;
      this.comboInitTeam21.TabIndex = 1;
      this.label62.Dock = DockStyle.Left;
      this.label62.Location = new Point(0, 0);
      this.label62.Name = "label62";
      this.label62.Size = new Size(28, 25);
      this.label62.TabIndex = 0;
      this.label62.Text = "21.";
      this.label62.TextAlign = ContentAlignment.MiddleLeft;
      this.panelInitTeam20.Controls.Add((Control) this.labelUpdateTable20);
      this.panelInitTeam20.Controls.Add((Control) this.comboInitTeam20);
      this.panelInitTeam20.Controls.Add((Control) this.label61);
      this.panelInitTeam20.Location = new Point(7, 518);
      this.panelInitTeam20.Name = "panelInitTeam20";
      this.panelInitTeam20.Size = new Size(500, 25);
      this.panelInitTeam20.TabIndex = 19;
      this.labelUpdateTable20.BorderStyle = BorderStyle.FixedSingle;
      this.labelUpdateTable20.Cursor = Cursors.Hand;
      this.labelUpdateTable20.Dock = DockStyle.Fill;
      this.labelUpdateTable20.Location = new Point(28, 0);
      this.labelUpdateTable20.Name = "labelUpdateTable20";
      this.labelUpdateTable20.Size = new Size(292, 25);
      this.labelUpdateTable20.TabIndex = 4;
      this.labelUpdateTable20.TextAlign = ContentAlignment.MiddleLeft;
      this.labelUpdateTable20.Click += new EventHandler(this.labelUpdateTable_Click);
      this.comboInitTeam20.Dock = DockStyle.Right;
      this.comboInitTeam20.FormattingEnabled = true;
      this.comboInitTeam20.Location = new Point(320, 0);
      this.comboInitTeam20.Name = "comboInitTeam20";
      this.comboInitTeam20.Size = new Size(180, 21);
      this.comboInitTeam20.Sorted = true;
      this.comboInitTeam20.TabIndex = 1;
      this.label61.Dock = DockStyle.Left;
      this.label61.Location = new Point(0, 0);
      this.label61.Name = "label61";
      this.label61.Size = new Size(28, 25);
      this.label61.TabIndex = 0;
      this.label61.Text = "20.";
      this.label61.TextAlign = ContentAlignment.MiddleLeft;
      this.panelInitTeam19.Controls.Add((Control) this.labelUpdateTable19);
      this.panelInitTeam19.Controls.Add((Control) this.comboInitTeam19);
      this.panelInitTeam19.Controls.Add((Control) this.label60);
      this.panelInitTeam19.Location = new Point(7, 493);
      this.panelInitTeam19.Name = "panelInitTeam19";
      this.panelInitTeam19.Size = new Size(500, 25);
      this.panelInitTeam19.TabIndex = 18;
      this.labelUpdateTable19.BorderStyle = BorderStyle.FixedSingle;
      this.labelUpdateTable19.Cursor = Cursors.Hand;
      this.labelUpdateTable19.Dock = DockStyle.Fill;
      this.labelUpdateTable19.Location = new Point(28, 0);
      this.labelUpdateTable19.Name = "labelUpdateTable19";
      this.labelUpdateTable19.Size = new Size(292, 25);
      this.labelUpdateTable19.TabIndex = 4;
      this.labelUpdateTable19.TextAlign = ContentAlignment.MiddleLeft;
      this.labelUpdateTable19.Click += new EventHandler(this.labelUpdateTable_Click);
      this.comboInitTeam19.Dock = DockStyle.Right;
      this.comboInitTeam19.FormattingEnabled = true;
      this.comboInitTeam19.Location = new Point(320, 0);
      this.comboInitTeam19.Name = "comboInitTeam19";
      this.comboInitTeam19.Size = new Size(180, 21);
      this.comboInitTeam19.Sorted = true;
      this.comboInitTeam19.TabIndex = 1;
      this.label60.Dock = DockStyle.Left;
      this.label60.Location = new Point(0, 0);
      this.label60.Name = "label60";
      this.label60.Size = new Size(28, 25);
      this.label60.TabIndex = 0;
      this.label60.Text = "19.";
      this.label60.TextAlign = ContentAlignment.MiddleLeft;
      this.panelInitTeam18.Controls.Add((Control) this.labelUpdateTable18);
      this.panelInitTeam18.Controls.Add((Control) this.comboInitTeam18);
      this.panelInitTeam18.Controls.Add((Control) this.label59);
      this.panelInitTeam18.Location = new Point(7, 468);
      this.panelInitTeam18.Name = "panelInitTeam18";
      this.panelInitTeam18.Size = new Size(500, 25);
      this.panelInitTeam18.TabIndex = 17;
      this.labelUpdateTable18.BorderStyle = BorderStyle.FixedSingle;
      this.labelUpdateTable18.Cursor = Cursors.Hand;
      this.labelUpdateTable18.Dock = DockStyle.Fill;
      this.labelUpdateTable18.Location = new Point(28, 0);
      this.labelUpdateTable18.Name = "labelUpdateTable18";
      this.labelUpdateTable18.Size = new Size(292, 25);
      this.labelUpdateTable18.TabIndex = 4;
      this.labelUpdateTable18.TextAlign = ContentAlignment.MiddleLeft;
      this.labelUpdateTable18.Click += new EventHandler(this.labelUpdateTable_Click);
      this.comboInitTeam18.Dock = DockStyle.Right;
      this.comboInitTeam18.FormattingEnabled = true;
      this.comboInitTeam18.Location = new Point(320, 0);
      this.comboInitTeam18.Name = "comboInitTeam18";
      this.comboInitTeam18.Size = new Size(180, 21);
      this.comboInitTeam18.Sorted = true;
      this.comboInitTeam18.TabIndex = 1;
      this.label59.Dock = DockStyle.Left;
      this.label59.Location = new Point(0, 0);
      this.label59.Name = "label59";
      this.label59.Size = new Size(28, 25);
      this.label59.TabIndex = 0;
      this.label59.Text = "18.";
      this.label59.TextAlign = ContentAlignment.MiddleLeft;
      this.panelInitTeam17.Controls.Add((Control) this.labelUpdateTable17);
      this.panelInitTeam17.Controls.Add((Control) this.comboInitTeam17);
      this.panelInitTeam17.Controls.Add((Control) this.label58);
      this.panelInitTeam17.Location = new Point(7, 443);
      this.panelInitTeam17.Name = "panelInitTeam17";
      this.panelInitTeam17.Size = new Size(500, 25);
      this.panelInitTeam17.TabIndex = 16;
      this.labelUpdateTable17.BorderStyle = BorderStyle.FixedSingle;
      this.labelUpdateTable17.Cursor = Cursors.Hand;
      this.labelUpdateTable17.Dock = DockStyle.Fill;
      this.labelUpdateTable17.Location = new Point(28, 0);
      this.labelUpdateTable17.Name = "labelUpdateTable17";
      this.labelUpdateTable17.Size = new Size(292, 25);
      this.labelUpdateTable17.TabIndex = 4;
      this.labelUpdateTable17.TextAlign = ContentAlignment.MiddleLeft;
      this.labelUpdateTable17.Click += new EventHandler(this.labelUpdateTable_Click);
      this.comboInitTeam17.Dock = DockStyle.Right;
      this.comboInitTeam17.FormattingEnabled = true;
      this.comboInitTeam17.Location = new Point(320, 0);
      this.comboInitTeam17.Name = "comboInitTeam17";
      this.comboInitTeam17.Size = new Size(180, 21);
      this.comboInitTeam17.Sorted = true;
      this.comboInitTeam17.TabIndex = 1;
      this.label58.Dock = DockStyle.Left;
      this.label58.Location = new Point(0, 0);
      this.label58.Name = "label58";
      this.label58.Size = new Size(28, 25);
      this.label58.TabIndex = 0;
      this.label58.Text = "17.";
      this.label58.TextAlign = ContentAlignment.MiddleLeft;
      this.panelInitTeam16.Controls.Add((Control) this.labelUpdateTable16);
      this.panelInitTeam16.Controls.Add((Control) this.comboInitTeam16);
      this.panelInitTeam16.Controls.Add((Control) this.label57);
      this.panelInitTeam16.Location = new Point(6, 417);
      this.panelInitTeam16.Name = "panelInitTeam16";
      this.panelInitTeam16.Size = new Size(500, 25);
      this.panelInitTeam16.TabIndex = 15;
      this.labelUpdateTable16.BorderStyle = BorderStyle.FixedSingle;
      this.labelUpdateTable16.Cursor = Cursors.Hand;
      this.labelUpdateTable16.Dock = DockStyle.Fill;
      this.labelUpdateTable16.Location = new Point(28, 0);
      this.labelUpdateTable16.Name = "labelUpdateTable16";
      this.labelUpdateTable16.Size = new Size(292, 25);
      this.labelUpdateTable16.TabIndex = 4;
      this.labelUpdateTable16.TextAlign = ContentAlignment.MiddleLeft;
      this.labelUpdateTable16.Click += new EventHandler(this.labelUpdateTable_Click);
      this.comboInitTeam16.Dock = DockStyle.Right;
      this.comboInitTeam16.FormattingEnabled = true;
      this.comboInitTeam16.Location = new Point(320, 0);
      this.comboInitTeam16.Name = "comboInitTeam16";
      this.comboInitTeam16.Size = new Size(180, 21);
      this.comboInitTeam16.Sorted = true;
      this.comboInitTeam16.TabIndex = 1;
      this.label57.Dock = DockStyle.Left;
      this.label57.Location = new Point(0, 0);
      this.label57.Name = "label57";
      this.label57.Size = new Size(28, 25);
      this.label57.TabIndex = 0;
      this.label57.Text = "16.";
      this.label57.TextAlign = ContentAlignment.MiddleLeft;
      this.panelInitTeam15.Controls.Add((Control) this.labelUpdateTable15);
      this.panelInitTeam15.Controls.Add((Control) this.comboInitTeam15);
      this.panelInitTeam15.Controls.Add((Control) this.label56);
      this.panelInitTeam15.Location = new Point(6, 392);
      this.panelInitTeam15.Name = "panelInitTeam15";
      this.panelInitTeam15.Size = new Size(500, 25);
      this.panelInitTeam15.TabIndex = 14;
      this.labelUpdateTable15.BorderStyle = BorderStyle.FixedSingle;
      this.labelUpdateTable15.Cursor = Cursors.Hand;
      this.labelUpdateTable15.Dock = DockStyle.Fill;
      this.labelUpdateTable15.Location = new Point(28, 0);
      this.labelUpdateTable15.Name = "labelUpdateTable15";
      this.labelUpdateTable15.Size = new Size(292, 25);
      this.labelUpdateTable15.TabIndex = 4;
      this.labelUpdateTable15.TextAlign = ContentAlignment.MiddleLeft;
      this.labelUpdateTable15.Click += new EventHandler(this.labelUpdateTable_Click);
      this.comboInitTeam15.Dock = DockStyle.Right;
      this.comboInitTeam15.FormattingEnabled = true;
      this.comboInitTeam15.Location = new Point(320, 0);
      this.comboInitTeam15.Name = "comboInitTeam15";
      this.comboInitTeam15.Size = new Size(180, 21);
      this.comboInitTeam15.Sorted = true;
      this.comboInitTeam15.TabIndex = 1;
      this.label56.Dock = DockStyle.Left;
      this.label56.Location = new Point(0, 0);
      this.label56.Name = "label56";
      this.label56.Size = new Size(28, 25);
      this.label56.TabIndex = 0;
      this.label56.Text = "15.";
      this.label56.TextAlign = ContentAlignment.MiddleLeft;
      this.panelInitTeam14.Controls.Add((Control) this.labelUpdateTable14);
      this.panelInitTeam14.Controls.Add((Control) this.comboInitTeam14);
      this.panelInitTeam14.Controls.Add((Control) this.label55);
      this.panelInitTeam14.Location = new Point(6, 367);
      this.panelInitTeam14.Name = "panelInitTeam14";
      this.panelInitTeam14.Size = new Size(500, 25);
      this.panelInitTeam14.TabIndex = 13;
      this.labelUpdateTable14.BorderStyle = BorderStyle.FixedSingle;
      this.labelUpdateTable14.Cursor = Cursors.Hand;
      this.labelUpdateTable14.Dock = DockStyle.Fill;
      this.labelUpdateTable14.Location = new Point(28, 0);
      this.labelUpdateTable14.Name = "labelUpdateTable14";
      this.labelUpdateTable14.Size = new Size(292, 25);
      this.labelUpdateTable14.TabIndex = 4;
      this.labelUpdateTable14.TextAlign = ContentAlignment.MiddleLeft;
      this.labelUpdateTable14.Click += new EventHandler(this.labelUpdateTable_Click);
      this.comboInitTeam14.Dock = DockStyle.Right;
      this.comboInitTeam14.FormattingEnabled = true;
      this.comboInitTeam14.Location = new Point(320, 0);
      this.comboInitTeam14.Name = "comboInitTeam14";
      this.comboInitTeam14.Size = new Size(180, 21);
      this.comboInitTeam14.Sorted = true;
      this.comboInitTeam14.TabIndex = 1;
      this.label55.Dock = DockStyle.Left;
      this.label55.Location = new Point(0, 0);
      this.label55.Name = "label55";
      this.label55.Size = new Size(28, 25);
      this.label55.TabIndex = 0;
      this.label55.Text = "14.";
      this.label55.TextAlign = ContentAlignment.MiddleLeft;
      this.panelInitTeam13.Controls.Add((Control) this.labelUpdateTable13);
      this.panelInitTeam13.Controls.Add((Control) this.comboInitTeam13);
      this.panelInitTeam13.Controls.Add((Control) this.label54);
      this.panelInitTeam13.Location = new Point(6, 342);
      this.panelInitTeam13.Name = "panelInitTeam13";
      this.panelInitTeam13.Size = new Size(500, 25);
      this.panelInitTeam13.TabIndex = 12;
      this.labelUpdateTable13.BorderStyle = BorderStyle.FixedSingle;
      this.labelUpdateTable13.Cursor = Cursors.Hand;
      this.labelUpdateTable13.Dock = DockStyle.Fill;
      this.labelUpdateTable13.Location = new Point(28, 0);
      this.labelUpdateTable13.Name = "labelUpdateTable13";
      this.labelUpdateTable13.Size = new Size(292, 25);
      this.labelUpdateTable13.TabIndex = 4;
      this.labelUpdateTable13.TextAlign = ContentAlignment.MiddleLeft;
      this.labelUpdateTable13.Click += new EventHandler(this.labelUpdateTable_Click);
      this.comboInitTeam13.Dock = DockStyle.Right;
      this.comboInitTeam13.FormattingEnabled = true;
      this.comboInitTeam13.Location = new Point(320, 0);
      this.comboInitTeam13.Name = "comboInitTeam13";
      this.comboInitTeam13.Size = new Size(180, 21);
      this.comboInitTeam13.Sorted = true;
      this.comboInitTeam13.TabIndex = 1;
      this.label54.Dock = DockStyle.Left;
      this.label54.Location = new Point(0, 0);
      this.label54.Name = "label54";
      this.label54.Size = new Size(28, 25);
      this.label54.TabIndex = 0;
      this.label54.Text = "13.";
      this.label54.TextAlign = ContentAlignment.MiddleLeft;
      this.panelInitTeam12.Controls.Add((Control) this.labelUpdateTable12);
      this.panelInitTeam12.Controls.Add((Control) this.comboInitTeam12);
      this.panelInitTeam12.Controls.Add((Control) this.label53);
      this.panelInitTeam12.Location = new Point(6, 317);
      this.panelInitTeam12.Name = "panelInitTeam12";
      this.panelInitTeam12.Size = new Size(501, 25);
      this.panelInitTeam12.TabIndex = 11;
      this.labelUpdateTable12.BorderStyle = BorderStyle.FixedSingle;
      this.labelUpdateTable12.Cursor = Cursors.Hand;
      this.labelUpdateTable12.Dock = DockStyle.Fill;
      this.labelUpdateTable12.Location = new Point(28, 0);
      this.labelUpdateTable12.Name = "labelUpdateTable12";
      this.labelUpdateTable12.Size = new Size(293, 25);
      this.labelUpdateTable12.TabIndex = 4;
      this.labelUpdateTable12.TextAlign = ContentAlignment.MiddleLeft;
      this.labelUpdateTable12.Click += new EventHandler(this.labelUpdateTable_Click);
      this.comboInitTeam12.Dock = DockStyle.Right;
      this.comboInitTeam12.FormattingEnabled = true;
      this.comboInitTeam12.Location = new Point(321, 0);
      this.comboInitTeam12.Name = "comboInitTeam12";
      this.comboInitTeam12.Size = new Size(180, 21);
      this.comboInitTeam12.Sorted = true;
      this.comboInitTeam12.TabIndex = 1;
      this.label53.Dock = DockStyle.Left;
      this.label53.Location = new Point(0, 0);
      this.label53.Name = "label53";
      this.label53.Size = new Size(28, 25);
      this.label53.TabIndex = 0;
      this.label53.Text = "12.";
      this.label53.TextAlign = ContentAlignment.MiddleLeft;
      this.panelInitTeam11.Controls.Add((Control) this.labelUpdateTable11);
      this.panelInitTeam11.Controls.Add((Control) this.comboInitTeam11);
      this.panelInitTeam11.Controls.Add((Control) this.label52);
      this.panelInitTeam11.Location = new Point(6, 292);
      this.panelInitTeam11.Name = "panelInitTeam11";
      this.panelInitTeam11.Size = new Size(501, 25);
      this.panelInitTeam11.TabIndex = 10;
      this.labelUpdateTable11.BorderStyle = BorderStyle.FixedSingle;
      this.labelUpdateTable11.Cursor = Cursors.Hand;
      this.labelUpdateTable11.Dock = DockStyle.Fill;
      this.labelUpdateTable11.Location = new Point(28, 0);
      this.labelUpdateTable11.Name = "labelUpdateTable11";
      this.labelUpdateTable11.Size = new Size(293, 25);
      this.labelUpdateTable11.TabIndex = 4;
      this.labelUpdateTable11.TextAlign = ContentAlignment.MiddleLeft;
      this.labelUpdateTable11.Click += new EventHandler(this.labelUpdateTable_Click);
      this.comboInitTeam11.Dock = DockStyle.Right;
      this.comboInitTeam11.FormattingEnabled = true;
      this.comboInitTeam11.Location = new Point(321, 0);
      this.comboInitTeam11.Name = "comboInitTeam11";
      this.comboInitTeam11.Size = new Size(180, 21);
      this.comboInitTeam11.Sorted = true;
      this.comboInitTeam11.TabIndex = 1;
      this.label52.Dock = DockStyle.Left;
      this.label52.Location = new Point(0, 0);
      this.label52.Name = "label52";
      this.label52.Size = new Size(28, 25);
      this.label52.TabIndex = 0;
      this.label52.Text = "11.";
      this.label52.TextAlign = ContentAlignment.MiddleLeft;
      this.panelInitTeam10.Controls.Add((Control) this.labelUpdateTable10);
      this.panelInitTeam10.Controls.Add((Control) this.comboInitTeam10);
      this.panelInitTeam10.Controls.Add((Control) this.label51);
      this.panelInitTeam10.Location = new Point(6, 267);
      this.panelInitTeam10.Name = "panelInitTeam10";
      this.panelInitTeam10.Size = new Size(501, 25);
      this.panelInitTeam10.TabIndex = 9;
      this.labelUpdateTable10.BorderStyle = BorderStyle.FixedSingle;
      this.labelUpdateTable10.Cursor = Cursors.Hand;
      this.labelUpdateTable10.Dock = DockStyle.Fill;
      this.labelUpdateTable10.Location = new Point(28, 0);
      this.labelUpdateTable10.Name = "labelUpdateTable10";
      this.labelUpdateTable10.Size = new Size(293, 25);
      this.labelUpdateTable10.TabIndex = 4;
      this.labelUpdateTable10.TextAlign = ContentAlignment.MiddleLeft;
      this.labelUpdateTable10.Click += new EventHandler(this.labelUpdateTable_Click);
      this.comboInitTeam10.Dock = DockStyle.Right;
      this.comboInitTeam10.FormattingEnabled = true;
      this.comboInitTeam10.Location = new Point(321, 0);
      this.comboInitTeam10.Name = "comboInitTeam10";
      this.comboInitTeam10.Size = new Size(180, 21);
      this.comboInitTeam10.Sorted = true;
      this.comboInitTeam10.TabIndex = 1;
      this.label51.Dock = DockStyle.Left;
      this.label51.Location = new Point(0, 0);
      this.label51.Name = "label51";
      this.label51.Size = new Size(28, 25);
      this.label51.TabIndex = 0;
      this.label51.Text = "10.";
      this.label51.TextAlign = ContentAlignment.MiddleLeft;
      this.panelInitTeam9.Controls.Add((Control) this.labelUpdateTable9);
      this.panelInitTeam9.Controls.Add((Control) this.comboInitTeam9);
      this.panelInitTeam9.Controls.Add((Control) this.label50);
      this.panelInitTeam9.Location = new Point(6, 242);
      this.panelInitTeam9.Name = "panelInitTeam9";
      this.panelInitTeam9.Size = new Size(501, 25);
      this.panelInitTeam9.TabIndex = 8;
      this.labelUpdateTable9.BorderStyle = BorderStyle.FixedSingle;
      this.labelUpdateTable9.Cursor = Cursors.Hand;
      this.labelUpdateTable9.Dock = DockStyle.Fill;
      this.labelUpdateTable9.Location = new Point(29, 0);
      this.labelUpdateTable9.Name = "labelUpdateTable9";
      this.labelUpdateTable9.Size = new Size(292, 25);
      this.labelUpdateTable9.TabIndex = 4;
      this.labelUpdateTable9.TextAlign = ContentAlignment.MiddleLeft;
      this.labelUpdateTable9.Click += new EventHandler(this.labelUpdateTable_Click);
      this.comboInitTeam9.Dock = DockStyle.Right;
      this.comboInitTeam9.FormattingEnabled = true;
      this.comboInitTeam9.Location = new Point(321, 0);
      this.comboInitTeam9.Name = "comboInitTeam9";
      this.comboInitTeam9.Size = new Size(180, 21);
      this.comboInitTeam9.Sorted = true;
      this.comboInitTeam9.TabIndex = 1;
      this.label50.Dock = DockStyle.Left;
      this.label50.Location = new Point(0, 0);
      this.label50.Name = "label50";
      this.label50.Size = new Size(29, 25);
      this.label50.TabIndex = 0;
      this.label50.Text = " 9.";
      this.label50.TextAlign = ContentAlignment.MiddleLeft;
      this.panelInitTeam8.Controls.Add((Control) this.labelUpdateTable8);
      this.panelInitTeam8.Controls.Add((Control) this.comboInitTeam8);
      this.panelInitTeam8.Controls.Add((Control) this.label49);
      this.panelInitTeam8.Location = new Point(6, 215);
      this.panelInitTeam8.Name = "panelInitTeam8";
      this.panelInitTeam8.Size = new Size(501, 25);
      this.panelInitTeam8.TabIndex = 7;
      this.labelUpdateTable8.BorderStyle = BorderStyle.FixedSingle;
      this.labelUpdateTable8.Cursor = Cursors.Hand;
      this.labelUpdateTable8.Dock = DockStyle.Fill;
      this.labelUpdateTable8.Location = new Point(29, 0);
      this.labelUpdateTable8.Name = "labelUpdateTable8";
      this.labelUpdateTable8.Size = new Size(292, 25);
      this.labelUpdateTable8.TabIndex = 4;
      this.labelUpdateTable8.TextAlign = ContentAlignment.MiddleLeft;
      this.labelUpdateTable8.Click += new EventHandler(this.labelUpdateTable_Click);
      this.comboInitTeam8.Dock = DockStyle.Right;
      this.comboInitTeam8.FormattingEnabled = true;
      this.comboInitTeam8.Location = new Point(321, 0);
      this.comboInitTeam8.Name = "comboInitTeam8";
      this.comboInitTeam8.Size = new Size(180, 21);
      this.comboInitTeam8.Sorted = true;
      this.comboInitTeam8.TabIndex = 1;
      this.label49.Dock = DockStyle.Left;
      this.label49.Location = new Point(0, 0);
      this.label49.Name = "label49";
      this.label49.Size = new Size(29, 25);
      this.label49.TabIndex = 0;
      this.label49.Text = " 8.";
      this.label49.TextAlign = ContentAlignment.MiddleLeft;
      this.panelInitTeam7.Controls.Add((Control) this.labelUpdateTable7);
      this.panelInitTeam7.Controls.Add((Control) this.comboInitTeam7);
      this.panelInitTeam7.Controls.Add((Control) this.label48);
      this.panelInitTeam7.Location = new Point(6, 190);
      this.panelInitTeam7.Name = "panelInitTeam7";
      this.panelInitTeam7.Size = new Size(501, 25);
      this.panelInitTeam7.TabIndex = 6;
      this.labelUpdateTable7.BorderStyle = BorderStyle.FixedSingle;
      this.labelUpdateTable7.Cursor = Cursors.Hand;
      this.labelUpdateTable7.Dock = DockStyle.Fill;
      this.labelUpdateTable7.Location = new Point(29, 0);
      this.labelUpdateTable7.Name = "labelUpdateTable7";
      this.labelUpdateTable7.Size = new Size(292, 25);
      this.labelUpdateTable7.TabIndex = 4;
      this.labelUpdateTable7.TextAlign = ContentAlignment.MiddleLeft;
      this.labelUpdateTable7.Click += new EventHandler(this.labelUpdateTable_Click);
      this.comboInitTeam7.Dock = DockStyle.Right;
      this.comboInitTeam7.FormattingEnabled = true;
      this.comboInitTeam7.Location = new Point(321, 0);
      this.comboInitTeam7.Name = "comboInitTeam7";
      this.comboInitTeam7.Size = new Size(180, 21);
      this.comboInitTeam7.Sorted = true;
      this.comboInitTeam7.TabIndex = 1;
      this.label48.Dock = DockStyle.Left;
      this.label48.Location = new Point(0, 0);
      this.label48.Name = "label48";
      this.label48.Size = new Size(29, 25);
      this.label48.TabIndex = 0;
      this.label48.Text = " 7.";
      this.label48.TextAlign = ContentAlignment.MiddleLeft;
      this.panelInitTeam6.Controls.Add((Control) this.labelUpdateTable6);
      this.panelInitTeam6.Controls.Add((Control) this.comboInitTeam6);
      this.panelInitTeam6.Controls.Add((Control) this.label47);
      this.panelInitTeam6.Location = new Point(6, 165);
      this.panelInitTeam6.Name = "panelInitTeam6";
      this.panelInitTeam6.Size = new Size(501, 25);
      this.panelInitTeam6.TabIndex = 5;
      this.labelUpdateTable6.BorderStyle = BorderStyle.FixedSingle;
      this.labelUpdateTable6.Cursor = Cursors.Hand;
      this.labelUpdateTable6.Dock = DockStyle.Fill;
      this.labelUpdateTable6.Location = new Point(29, 0);
      this.labelUpdateTable6.Name = "labelUpdateTable6";
      this.labelUpdateTable6.Size = new Size(292, 25);
      this.labelUpdateTable6.TabIndex = 4;
      this.labelUpdateTable6.TextAlign = ContentAlignment.MiddleLeft;
      this.labelUpdateTable6.Click += new EventHandler(this.labelUpdateTable_Click);
      this.comboInitTeam6.Dock = DockStyle.Right;
      this.comboInitTeam6.FormattingEnabled = true;
      this.comboInitTeam6.Location = new Point(321, 0);
      this.comboInitTeam6.Name = "comboInitTeam6";
      this.comboInitTeam6.Size = new Size(180, 21);
      this.comboInitTeam6.Sorted = true;
      this.comboInitTeam6.TabIndex = 1;
      this.label47.Dock = DockStyle.Left;
      this.label47.Location = new Point(0, 0);
      this.label47.Name = "label47";
      this.label47.Size = new Size(29, 25);
      this.label47.TabIndex = 0;
      this.label47.Text = " 6.";
      this.label47.TextAlign = ContentAlignment.MiddleLeft;
      this.panelInitTeam5.Controls.Add((Control) this.labelUpdateTable5);
      this.panelInitTeam5.Controls.Add((Control) this.comboInitTeam5);
      this.panelInitTeam5.Controls.Add((Control) this.label46);
      this.panelInitTeam5.Location = new Point(6, 140);
      this.panelInitTeam5.Name = "panelInitTeam5";
      this.panelInitTeam5.Size = new Size(501, 25);
      this.panelInitTeam5.TabIndex = 4;
      this.labelUpdateTable5.BorderStyle = BorderStyle.FixedSingle;
      this.labelUpdateTable5.Cursor = Cursors.Hand;
      this.labelUpdateTable5.Dock = DockStyle.Fill;
      this.labelUpdateTable5.Location = new Point(29, 0);
      this.labelUpdateTable5.Name = "labelUpdateTable5";
      this.labelUpdateTable5.Size = new Size(292, 25);
      this.labelUpdateTable5.TabIndex = 4;
      this.labelUpdateTable5.TextAlign = ContentAlignment.MiddleLeft;
      this.labelUpdateTable5.Click += new EventHandler(this.labelUpdateTable_Click);
      this.comboInitTeam5.Dock = DockStyle.Right;
      this.comboInitTeam5.FormattingEnabled = true;
      this.comboInitTeam5.Location = new Point(321, 0);
      this.comboInitTeam5.Name = "comboInitTeam5";
      this.comboInitTeam5.Size = new Size(180, 21);
      this.comboInitTeam5.Sorted = true;
      this.comboInitTeam5.TabIndex = 1;
      this.label46.Dock = DockStyle.Left;
      this.label46.Location = new Point(0, 0);
      this.label46.Name = "label46";
      this.label46.Size = new Size(29, 25);
      this.label46.TabIndex = 0;
      this.label46.Text = " 5.";
      this.label46.TextAlign = ContentAlignment.MiddleLeft;
      this.panelInitTeam4.Controls.Add((Control) this.labelUpdateTable4);
      this.panelInitTeam4.Controls.Add((Control) this.comboInitTeam4);
      this.panelInitTeam4.Controls.Add((Control) this.label45);
      this.panelInitTeam4.Location = new Point(6, 115);
      this.panelInitTeam4.Name = "panelInitTeam4";
      this.panelInitTeam4.Size = new Size(501, 25);
      this.panelInitTeam4.TabIndex = 3;
      this.labelUpdateTable4.BorderStyle = BorderStyle.FixedSingle;
      this.labelUpdateTable4.Cursor = Cursors.Hand;
      this.labelUpdateTable4.Dock = DockStyle.Fill;
      this.labelUpdateTable4.Location = new Point(29, 0);
      this.labelUpdateTable4.Name = "labelUpdateTable4";
      this.labelUpdateTable4.Size = new Size(292, 25);
      this.labelUpdateTable4.TabIndex = 4;
      this.labelUpdateTable4.TextAlign = ContentAlignment.MiddleLeft;
      this.labelUpdateTable4.Click += new EventHandler(this.labelUpdateTable_Click);
      this.comboInitTeam4.Dock = DockStyle.Right;
      this.comboInitTeam4.FormattingEnabled = true;
      this.comboInitTeam4.Location = new Point(321, 0);
      this.comboInitTeam4.Name = "comboInitTeam4";
      this.comboInitTeam4.Size = new Size(180, 21);
      this.comboInitTeam4.Sorted = true;
      this.comboInitTeam4.TabIndex = 1;
      this.label45.Dock = DockStyle.Left;
      this.label45.Location = new Point(0, 0);
      this.label45.Name = "label45";
      this.label45.Size = new Size(29, 25);
      this.label45.TabIndex = 0;
      this.label45.Text = " 4.";
      this.label45.TextAlign = ContentAlignment.MiddleLeft;
      this.panelInitTeam3.Controls.Add((Control) this.labelUpdateTable3);
      this.panelInitTeam3.Controls.Add((Control) this.comboInitTeam3);
      this.panelInitTeam3.Controls.Add((Control) this.label44);
      this.panelInitTeam3.Location = new Point(6, 90);
      this.panelInitTeam3.Name = "panelInitTeam3";
      this.panelInitTeam3.Size = new Size(501, 25);
      this.panelInitTeam3.TabIndex = 2;
      this.labelUpdateTable3.BorderStyle = BorderStyle.FixedSingle;
      this.labelUpdateTable3.Cursor = Cursors.Hand;
      this.labelUpdateTable3.Dock = DockStyle.Fill;
      this.labelUpdateTable3.Location = new Point(29, 0);
      this.labelUpdateTable3.Name = "labelUpdateTable3";
      this.labelUpdateTable3.Size = new Size(292, 25);
      this.labelUpdateTable3.TabIndex = 4;
      this.labelUpdateTable3.TextAlign = ContentAlignment.MiddleLeft;
      this.labelUpdateTable3.Click += new EventHandler(this.labelUpdateTable_Click);
      this.comboInitTeam3.Dock = DockStyle.Right;
      this.comboInitTeam3.FormattingEnabled = true;
      this.comboInitTeam3.Location = new Point(321, 0);
      this.comboInitTeam3.Name = "comboInitTeam3";
      this.comboInitTeam3.Size = new Size(180, 21);
      this.comboInitTeam3.Sorted = true;
      this.comboInitTeam3.TabIndex = 1;
      this.label44.Dock = DockStyle.Left;
      this.label44.Location = new Point(0, 0);
      this.label44.Name = "label44";
      this.label44.Size = new Size(29, 25);
      this.label44.TabIndex = 0;
      this.label44.Text = " 3.";
      this.label44.TextAlign = ContentAlignment.MiddleLeft;
      this.panelInitTeam2.Controls.Add((Control) this.labelUpdateTable2);
      this.panelInitTeam2.Controls.Add((Control) this.comboInitTeam2);
      this.panelInitTeam2.Controls.Add((Control) this.label43);
      this.panelInitTeam2.Location = new Point(6, 65);
      this.panelInitTeam2.Name = "panelInitTeam2";
      this.panelInitTeam2.Size = new Size(501, 25);
      this.panelInitTeam2.TabIndex = 1;
      this.labelUpdateTable2.BorderStyle = BorderStyle.FixedSingle;
      this.labelUpdateTable2.Cursor = Cursors.Hand;
      this.labelUpdateTable2.Dock = DockStyle.Fill;
      this.labelUpdateTable2.Location = new Point(29, 0);
      this.labelUpdateTable2.Name = "labelUpdateTable2";
      this.labelUpdateTable2.Size = new Size(292, 25);
      this.labelUpdateTable2.TabIndex = 3;
      this.labelUpdateTable2.TextAlign = ContentAlignment.MiddleLeft;
      this.labelUpdateTable2.Click += new EventHandler(this.labelUpdateTable_Click);
      this.comboInitTeam2.Dock = DockStyle.Right;
      this.comboInitTeam2.FormattingEnabled = true;
      this.comboInitTeam2.Location = new Point(321, 0);
      this.comboInitTeam2.Name = "comboInitTeam2";
      this.comboInitTeam2.Size = new Size(180, 21);
      this.comboInitTeam2.Sorted = true;
      this.comboInitTeam2.TabIndex = 1;
      this.label43.Dock = DockStyle.Left;
      this.label43.Location = new Point(0, 0);
      this.label43.Name = "label43";
      this.label43.Size = new Size(29, 25);
      this.label43.TabIndex = 0;
      this.label43.Text = " 2.";
      this.label43.TextAlign = ContentAlignment.MiddleLeft;
      this.panelInitTeam1.Controls.Add((Control) this.labelUpdateTable1);
      this.panelInitTeam1.Controls.Add((Control) this.comboInitTeam1);
      this.panelInitTeam1.Controls.Add((Control) this.label42);
      this.panelInitTeam1.Location = new Point(6, 40);
      this.panelInitTeam1.Name = "panelInitTeam1";
      this.panelInitTeam1.Size = new Size(501, 25);
      this.panelInitTeam1.TabIndex = 0;
      this.labelUpdateTable1.BorderStyle = BorderStyle.FixedSingle;
      this.labelUpdateTable1.Cursor = Cursors.Hand;
      this.labelUpdateTable1.Dock = DockStyle.Fill;
      this.labelUpdateTable1.Location = new Point(29, 0);
      this.labelUpdateTable1.Name = "labelUpdateTable1";
      this.labelUpdateTable1.Size = new Size(292, 25);
      this.labelUpdateTable1.TabIndex = 2;
      this.labelUpdateTable1.TextAlign = ContentAlignment.MiddleLeft;
      this.labelUpdateTable1.Click += new EventHandler(this.labelUpdateTable_Click);
      this.comboInitTeam1.Dock = DockStyle.Right;
      this.comboInitTeam1.FormattingEnabled = true;
      this.comboInitTeam1.Location = new Point(321, 0);
      this.comboInitTeam1.Name = "comboInitTeam1";
      this.comboInitTeam1.Size = new Size(180, 21);
      this.comboInitTeam1.Sorted = true;
      this.comboInitTeam1.TabIndex = 1;
      this.label42.Dock = DockStyle.Left;
      this.label42.Location = new Point(0, 0);
      this.label42.Name = "label42";
      this.label42.Size = new Size(29, 25);
      this.label42.TabIndex = 0;
      this.label42.Text = " 1.";
      this.label42.TextAlign = ContentAlignment.MiddleLeft;
      this.tabPageTrophyGraphics.Controls.Add((Control) this.groupGraphics);
      this.tabPageTrophyGraphics.Location = new Point(4, 22);
      this.tabPageTrophyGraphics.Name = "tabPageTrophyGraphics";
      this.tabPageTrophyGraphics.Padding = new Padding(3);
      this.tabPageTrophyGraphics.Size = new Size(782, 698);
      this.tabPageTrophyGraphics.TabIndex = 1;
      this.tabPageTrophyGraphics.Text = "Graphics";
      this.tabPageTrophyGraphics.UseVisualStyleBackColor = true;
      this.groupGraphics.Controls.Add((Control) this.buttonReplicateTropy);
      this.groupGraphics.Controls.Add((Control) this.viewer2DTrophy);
      this.groupGraphics.Controls.Add((Control) this.buttonReplicateTrophy128);
      this.groupGraphics.Controls.Add((Control) this.viewer2DTrophy128);
      this.groupGraphics.Controls.Add((Control) this.multiViewer2DTextures);
      this.groupGraphics.Controls.Add((Control) this.group3D);
      this.groupGraphics.Controls.Add((Control) this.viewer2DTrophy256);
      this.groupGraphics.Location = new Point(3, 3);
      this.groupGraphics.Name = "groupGraphics";
      this.groupGraphics.Size = new Size(721, 627);
      this.groupGraphics.TabIndex = 0;
      this.groupGraphics.TabStop = false;
      this.groupGraphics.Text = "Graphics";
      this.buttonReplicateTropy.Location = new Point(448, 276);
      this.buttonReplicateTropy.Name = "buttonReplicateTropy";
      this.buttonReplicateTropy.Size = new Size(75, 23);
      this.buttonReplicateTropy.TabIndex = 172;
      this.buttonReplicateTropy.Text = "Replicate";
      this.buttonReplicateTropy.UseVisualStyleBackColor = true;
      this.buttonReplicateTropy.Click += new EventHandler(this.buttonReplicateTropy_Click);
      this.viewer2DTrophy.AutoTransparency = true;
      this.viewer2DTrophy.BackColor = Color.Transparent;
      this.viewer2DTrophy.ButtonStripVisible = false;
      this.viewer2DTrophy.CurrentBitmap = (Bitmap) null;
      this.viewer2DTrophy.ExtendedFormat = false;
      this.viewer2DTrophy.FullSizeButton = false;
      this.viewer2DTrophy.ImageLayout = ImageLayout.None;
      this.viewer2DTrophy.ImageSize = new Size(256, 256);
      this.viewer2DTrophy.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DTrophy.Location = new Point(271, 19);
      this.viewer2DTrophy.Name = "viewer2DTrophy";
      this.viewer2DTrophy.RemoveButton = false;
      this.viewer2DTrophy.ShowButton = false;
      this.viewer2DTrophy.ShowButtonChecked = true;
      this.viewer2DTrophy.Size = new Size(256, 281);
      this.viewer2DTrophy.TabIndex = 171;
      this.buttonReplicateTrophy128.Location = new Point(563, 179);
      this.buttonReplicateTrophy128.Name = "buttonReplicateTrophy128";
      this.buttonReplicateTrophy128.Size = new Size(75, 23);
      this.buttonReplicateTrophy128.TabIndex = 170;
      this.buttonReplicateTrophy128.Text = "Replicate";
      this.buttonReplicateTrophy128.UseVisualStyleBackColor = true;
      this.buttonReplicateTrophy128.Click += new EventHandler(this.buttonReplicateTrophy128_Click);
      this.viewer2DTrophy128.AutoTransparency = true;
      this.viewer2DTrophy128.BackColor = Color.Transparent;
      this.viewer2DTrophy128.ButtonStripVisible = false;
      this.viewer2DTrophy128.CurrentBitmap = (Bitmap) null;
      this.viewer2DTrophy128.ExtendedFormat = false;
      this.viewer2DTrophy128.FullSizeButton = false;
      this.viewer2DTrophy128.ImageLayout = ImageLayout.None;
      this.viewer2DTrophy128.ImageSize = new Size(128, 128);
      this.viewer2DTrophy128.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DTrophy128.Location = new Point(533, 20);
      this.viewer2DTrophy128.Name = "viewer2DTrophy128";
      this.viewer2DTrophy128.RemoveButton = false;
      this.viewer2DTrophy128.ShowButton = false;
      this.viewer2DTrophy128.ShowButtonChecked = true;
      this.viewer2DTrophy128.Size = new Size(128, 153);
      this.viewer2DTrophy128.TabIndex = 169;
      this.multiViewer2DTextures.AutoTransparency = false;
      this.multiViewer2DTextures.Bitmaps = (Bitmap[]) null;
      this.multiViewer2DTextures.CheckBitmapSize = true;
      this.multiViewer2DTextures.FixedSize = true;
      this.multiViewer2DTextures.FullSizeButton = false;
      this.multiViewer2DTextures.LabelText = "Texture";
      this.multiViewer2DTextures.Location = new Point(6, 314);
      this.multiViewer2DTextures.Name = "multiViewer2DTextures";
      this.multiViewer2DTextures.ShowDeleteButton = false;
      this.multiViewer2DTextures.Size = new Size(256, 306);
      this.multiViewer2DTextures.TabIndex = 168;
      this.group3D.Controls.Add((Control) this.viewer3D);
      this.group3D.Controls.Add((Control) this.toolNear3D);
      this.group3D.Location = new Point(268, 306);
      this.group3D.Name = "group3D";
      this.group3D.Size = new Size(445, 314);
      this.group3D.TabIndex = 167;
      this.group3D.TabStop = false;
      this.group3D.Text = "3D Model";
      this.viewer3D.AmbientColor = Color.Black;
      this.viewer3D.BackColor = Color.Gray;
      this.viewer3D.BorderStyle = BorderStyle.Fixed3D;
      this.viewer3D.Dock = DockStyle.Fill;
      this.viewer3D.LightDirectionX = 0.5f;
      this.viewer3D.LightDirectionY = -0.25f;
      this.viewer3D.LightDirectionZ = -1f;
      this.viewer3D.LightX = -30f;
      this.viewer3D.LightY = 10f;
      this.viewer3D.LightZ = 30f;
      this.viewer3D.Location = new Point(3, 16);
      this.viewer3D.Name = "viewer3D";
      this.viewer3D.RotationX = 0.0f;
      this.viewer3D.RotationY = 0.0f;
      this.viewer3D.RotationYCoeff = 0.01f;
      this.viewer3D.Size = new Size(439, 270);
      this.viewer3D.TabIndex = 1;
      this.viewer3D.ViewX = 0.0f;
      this.viewer3D.ViewY = 35f;
      this.viewer3D.ViewZ = 105f;
      this.viewer3D.ZbufferRenderState = (bool[]) null;
      this.toolNear3D.Dock = DockStyle.Bottom;
      this.toolNear3D.GripStyle = ToolStripGripStyle.Hidden;
      this.toolNear3D.Items.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) this.buttonShow3DModel,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.buttonImport3DModel,
        (ToolStripItem) this.buttonExport3DModel,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.buttonRemove3DModel
      });
      this.toolNear3D.Location = new Point(3, 286);
      this.toolNear3D.Name = "toolNear3D";
      this.toolNear3D.Size = new Size(439, 25);
      this.toolNear3D.TabIndex = 2;
      this.buttonShow3DModel.CheckOnClick = true;
      this.buttonShow3DModel.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonShow3DModel.Image = (Image) resources.GetObject("buttonShow3DModel.Image");
      this.buttonShow3DModel.ImageTransparentColor = Color.Magenta;
      this.buttonShow3DModel.Name = "buttonShow3DModel";
      this.buttonShow3DModel.Size = new Size(23, 22);
      this.buttonShow3DModel.Text = "Show / Hide";
      this.buttonShow3DModel.Click += new EventHandler(this.buttonShow3DModel_Click);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(6, 25);
      this.buttonImport3DModel.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonImport3DModel.Image = (Image) resources.GetObject("buttonImport3DModel.Image");
      this.buttonImport3DModel.ImageTransparentColor = Color.Magenta;
      this.buttonImport3DModel.Name = "buttonImport3DModel";
      this.buttonImport3DModel.Size = new Size(23, 22);
      this.buttonImport3DModel.Text = "Import 3D Model";
      this.buttonImport3DModel.Click += new EventHandler(this.buttonImport3DModel_Click);
      this.buttonExport3DModel.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonExport3DModel.Image = (Image) resources.GetObject("buttonExport3DModel.Image");
      this.buttonExport3DModel.ImageTransparentColor = Color.Magenta;
      this.buttonExport3DModel.Name = "buttonExport3DModel";
      this.buttonExport3DModel.Size = new Size(23, 22);
      this.buttonExport3DModel.Text = "Export 3D Model";
      this.buttonExport3DModel.Click += new EventHandler(this.buttonExport3DModel_Click);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(6, 25);
      this.buttonRemove3DModel.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonRemove3DModel.Image = (Image) resources.GetObject("buttonRemove3DModel.Image");
      this.buttonRemove3DModel.ImageTransparentColor = Color.Magenta;
      this.buttonRemove3DModel.Name = "buttonRemove3DModel";
      this.buttonRemove3DModel.Size = new Size(23, 22);
      this.buttonRemove3DModel.Text = "Remove 3D Model";
      this.buttonRemove3DModel.Click += new EventHandler(this.buttonRemove3DModel_Click);
      this.viewer2DTrophy256.AutoTransparency = true;
      this.viewer2DTrophy256.BackColor = Color.Transparent;
      this.viewer2DTrophy256.ButtonStripVisible = false;
      this.viewer2DTrophy256.CurrentBitmap = (Bitmap) null;
      this.viewer2DTrophy256.ExtendedFormat = false;
      this.viewer2DTrophy256.FullSizeButton = false;
      this.viewer2DTrophy256.ImageLayout = ImageLayout.None;
      this.viewer2DTrophy256.ImageSize = new Size(256, 256);
      this.viewer2DTrophy256.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DTrophy256.Location = new Point(6, 20);
      this.viewer2DTrophy256.Name = "viewer2DTrophy256";
      this.viewer2DTrophy256.RemoveButton = false;
      this.viewer2DTrophy256.ShowButton = false;
      this.viewer2DTrophy256.ShowButtonChecked = true;
      this.viewer2DTrophy256.Size = new Size(256, 281);
      this.viewer2DTrophy256.TabIndex = 163;
      this.pageStage.AutoScroll = true;
      this.pageStage.Controls.Add((Control) this.groupStage);
      this.pageStage.Location = new Point(4, 22);
      this.pageStage.Name = "pageStage";
      this.pageStage.Size = new Size(790, 724);
      this.pageStage.TabIndex = 3;
      this.pageStage.Text = "Stage";
      this.pageStage.UseVisualStyleBackColor = true;
      this.pageGroup.AutoScroll = true;
      this.pageGroup.Controls.Add((Control) this.groupGroup);
      this.pageGroup.Location = new Point(4, 22);
      this.pageGroup.Name = "pageGroup";
      this.pageGroup.Size = new Size(790, 724);
      this.pageGroup.TabIndex = 4;
      this.pageGroup.Text = "Group";
      this.pageGroup.UseVisualStyleBackColor = true;
      this.groupGroup.Controls.Add((Control) this.groupRules);
      this.groupGroup.Controls.Add((Control) this.groupPlayGroup);
      this.groupGroup.Controls.Add((Control) this.groupGroupScheduke);
      this.groupGroup.Controls.Add((Control) this.groupSlots);
      this.groupGroup.Controls.Add((Control) this.groupInfoColors);
      this.groupGroup.Controls.Add((Control) this.label4);
      this.groupGroup.Controls.Add((Control) this.numericNTeams);
      this.groupGroup.Location = new Point(0, 0);
      this.groupGroup.Name = "groupGroup";
      this.groupGroup.Size = new Size(790, 724);
      this.groupGroup.TabIndex = 17;
      this.groupGroup.TabStop = false;
      this.groupGroup.Text = "Group";
      this.groupGroup.Visible = false;
      this.groupRules.Controls.Add((Control) this.panelQualificationRules);
      this.groupRules.Controls.Add((Control) this.panelAdvancement);
      this.groupRules.Location = new Point(6, 47);
      this.groupRules.Name = "groupRules";
      this.groupRules.Size = new Size(509, 472);
      this.groupRules.TabIndex = 39;
      this.groupRules.TabStop = false;
      this.groupRules.Text = "Rules";
      this.panelQualificationRules.AutoScroll = true;
      this.panelQualificationRules.Controls.Add((Control) this.toolRules);
      this.panelQualificationRules.Dock = DockStyle.Fill;
      this.panelQualificationRules.Location = new Point(3, 16);
      this.panelQualificationRules.Name = "panelQualificationRules";
      this.panelQualificationRules.Size = new Size(503, 453);
      this.panelQualificationRules.TabIndex = 15;
      this.toolRules.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.buttonAddRule,
        (ToolStripItem) this.buttonRemoveRule
      });
      this.toolRules.Location = new Point(0, 0);
      this.toolRules.Name = "toolRules";
      this.toolRules.Size = new Size(503, 55);
      this.toolRules.TabIndex = 17;
      this.buttonAddRule.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonAddRule.Image = (Image) resources.GetObject("buttonAddRule.Image");
      this.buttonAddRule.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonAddRule.ImageTransparentColor = Color.Magenta;
      this.buttonAddRule.Name = "buttonAddRule";
      this.buttonAddRule.Size = new Size(52, 52);
      this.buttonAddRule.Text = "Add Qualification Rule";
      this.buttonAddRule.Click += new EventHandler(this.buttonAddRule_Click);
      this.buttonRemoveRule.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonRemoveRule.Image = (Image) resources.GetObject("buttonRemoveRule.Image");
      this.buttonRemoveRule.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonRemoveRule.ImageTransparentColor = Color.Magenta;
      this.buttonRemoveRule.Name = "buttonRemoveRule";
      this.buttonRemoveRule.Size = new Size(52, 52);
      this.buttonRemoveRule.Text = "Remove Qualification Rule";
      this.buttonRemoveRule.Click += new EventHandler(this.buttonRemoveRule_Click);
      this.panelAdvancement.AutoScroll = true;
      this.panelAdvancement.Dock = DockStyle.Fill;
      this.panelAdvancement.Location = new Point(3, 16);
      this.panelAdvancement.Name = "panelAdvancement";
      this.panelAdvancement.Size = new Size(503, 453);
      this.panelAdvancement.TabIndex = 16;
      this.groupPlayGroup.Controls.Add((Control) this.numericNumGames);
      this.groupPlayGroup.Controls.Add((Control) this.label14);
      this.groupPlayGroup.Location = new Point(169, 11);
      this.groupPlayGroup.Name = "groupPlayGroup";
      this.groupPlayGroup.Size = new Size(172, 34);
      this.groupPlayGroup.TabIndex = 37;
      this.groupPlayGroup.TabStop = false;
      this.numericNumGames.Location = new Point(78, 10);
      this.numericNumGames.Maximum = new Decimal(new int[4]
      {
        4,
        0,
        0,
        0
      });
      this.numericNumGames.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericNumGames.Name = "numericNumGames";
      this.numericNumGames.Size = new Size(83, 20);
      this.numericNumGames.TabIndex = 36;
      this.numericNumGames.TextAlign = HorizontalAlignment.Center;
      this.numericNumGames.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericNumGames.ValueChanged += new EventHandler(this.numericNumGames_ValueChanged_1);
      this.label14.AutoSize = true;
      this.label14.Location = new Point(6, 14);
      this.label14.Name = "label14";
      this.label14.Size = new Size(66, 13);
      this.label14.TabIndex = 35;
      this.label14.Text = "N. of Games";
      this.groupGroupScheduke.Controls.Add((Control) this.treeGroupSchedule);
      this.groupGroupScheduke.Controls.Add((Control) this.panelGroupScheduleDetails);
      this.groupGroupScheduke.Controls.Add((Control) this.toolGroupSchedule);
      this.groupGroupScheduke.Location = new Point(520, 11);
      this.groupGroupScheduke.Name = "groupGroupScheduke";
      this.groupGroupScheduke.Size = new Size(267, 707);
      this.groupGroupScheduke.TabIndex = 34;
      this.groupGroupScheduke.TabStop = false;
      this.groupGroupScheduke.Text = "Schedules";
      this.treeGroupSchedule.FullRowSelect = true;
      this.treeGroupSchedule.HideSelection = false;
      this.treeGroupSchedule.Location = new Point(3, 220);
      this.treeGroupSchedule.Name = "treeGroupSchedule";
      this.treeGroupSchedule.Size = new Size(264, 487);
      this.treeGroupSchedule.TabIndex = 7;
      this.treeGroupSchedule.AfterSelect += new TreeViewEventHandler(this.treeGroupSchedule_AfterSelect);
      this.panelGroupScheduleDetails.Controls.Add((Control) this.groupGroupScheduleDetails);
      this.panelGroupScheduleDetails.Dock = DockStyle.Top;
      this.panelGroupScheduleDetails.Location = new Point(3, 126);
      this.panelGroupScheduleDetails.Name = "panelGroupScheduleDetails";
      this.panelGroupScheduleDetails.Size = new Size(261, 94);
      this.panelGroupScheduleDetails.TabIndex = 8;
      this.groupGroupScheduleDetails.Controls.Add((Control) this.dateGroupPicker);
      this.groupGroupScheduleDetails.Controls.Add((Control) this.label38);
      this.groupGroupScheduleDetails.Controls.Add((Control) this.numericGroupMinGames);
      this.groupGroupScheduleDetails.Controls.Add((Control) this.label39);
      this.groupGroupScheduleDetails.Controls.Add((Control) this.numericGroupMaxGames);
      this.groupGroupScheduleDetails.Controls.Add((Control) this.label40);
      this.groupGroupScheduleDetails.Controls.Add((Control) this.comboGroupTime);
      this.groupGroupScheduleDetails.Controls.Add((Control) this.label41);
      this.groupGroupScheduleDetails.Location = new Point(3, -2);
      this.groupGroupScheduleDetails.Name = "groupGroupScheduleDetails";
      this.groupGroupScheduleDetails.Size = new Size(261, 92);
      this.groupGroupScheduleDetails.TabIndex = 25;
      this.groupGroupScheduleDetails.TabStop = false;
      this.dateGroupPicker.Location = new Point(12, 13);
      this.dateGroupPicker.Name = "dateGroupPicker";
      this.dateGroupPicker.Size = new Size(241, 20);
      this.dateGroupPicker.TabIndex = 17;
      this.dateGroupPicker.ValueChanged += new EventHandler(this.dateGroupPicker_ValueChanged);
      this.label38.AutoSize = true;
      this.label38.Location = new Point(65, 70);
      this.label38.Name = "label38";
      this.label38.Size = new Size(26, 13);
      this.label38.TabIndex = 24;
      this.label38.Text = "min:";
      this.numericGroupMinGames.Location = new Point(95, 65);
      this.numericGroupMinGames.Maximum = new Decimal(new int[4]
      {
        80,
        0,
        0,
        0
      });
      this.numericGroupMinGames.Name = "numericGroupMinGames";
      this.numericGroupMinGames.Size = new Size(60, 20);
      this.numericGroupMinGames.TabIndex = 18;
      this.numericGroupMinGames.TextAlign = HorizontalAlignment.Center;
      this.numericGroupMinGames.Value = new Decimal(new int[4]
      {
        12,
        0,
        0,
        0
      });
      this.numericGroupMinGames.ValueChanged += new EventHandler(this.numericGroupMinGames_ValueChanged);
      this.label39.AutoSize = true;
      this.label39.Location = new Point(162, 70);
      this.label39.Name = "label39";
      this.label39.Size = new Size(29, 13);
      this.label39.TabIndex = 23;
      this.label39.Text = "max:";
      this.numericGroupMaxGames.Location = new Point(193, 65);
      this.numericGroupMaxGames.Maximum = new Decimal(new int[4]
      {
        80,
        0,
        0,
        0
      });
      this.numericGroupMaxGames.Name = "numericGroupMaxGames";
      this.numericGroupMaxGames.Size = new Size(60, 20);
      this.numericGroupMaxGames.TabIndex = 19;
      this.numericGroupMaxGames.TextAlign = HorizontalAlignment.Center;
      this.numericGroupMaxGames.Value = new Decimal(new int[4]
      {
        30,
        0,
        0,
        0
      });
      this.numericGroupMaxGames.ValueChanged += new EventHandler(this.numericGroupMaxGames_ValueChanged);
      this.label40.AutoSize = true;
      this.label40.Location = new Point(16, 70);
      this.label40.Name = "label40";
      this.label40.Size = new Size(40, 13);
      this.label40.TabIndex = 22;
      this.label40.Text = "Games";
      this.comboGroupTime.FormattingEnabled = true;
      this.comboGroupTime.Items.AddRange(new object[41]
      {
        (object) "12.00",
        (object) "12.15",
        (object) "12.30",
        (object) "12.45",
        (object) "13.00",
        (object) "13.15",
        (object) "13.30",
        (object) "13.45",
        (object) "14.00",
        (object) "14.15",
        (object) "14.30",
        (object) "14.45",
        (object) "15.00",
        (object) "15.15",
        (object) "15.30",
        (object) "15.45",
        (object) "16.00",
        (object) "16.15",
        (object) "16.30",
        (object) "16.45",
        (object) "17.00",
        (object) "17.15",
        (object) "17.30",
        (object) "17.45",
        (object) "18.00",
        (object) "18.15",
        (object) "18.30",
        (object) "18.45",
        (object) "19.00",
        (object) "19.15",
        (object) "19.30",
        (object) "19.45",
        (object) "20.00",
        (object) "20.15",
        (object) "20.30",
        (object) "20.45",
        (object) "21.00",
        (object) "21.15",
        (object) "21.30",
        (object) "21.45",
        (object) "22.00"
      });
      this.comboGroupTime.Location = new Point(60, 38);
      this.comboGroupTime.Name = "comboGroupTime";
      this.comboGroupTime.Size = new Size(121, 21);
      this.comboGroupTime.TabIndex = 20;
      this.comboGroupTime.SelectedIndexChanged += new EventHandler(this.comboGroupTime_SelectedIndexChanged);
      this.label41.AutoSize = true;
      this.label41.Location = new Point(16, 41);
      this.label41.Name = "label41";
      this.label41.Size = new Size(30, 13);
      this.label41.TabIndex = 21;
      this.label41.Text = "Time";
      this.toolGroupSchedule.Items.AddRange(new ToolStripItem[8]
      {
        (ToolStripItem) this.buttonCopyGroupCalendar,
        (ToolStripItem) this.buttonPasteGroupCalendar,
        (ToolStripItem) this.buttonCleanGroupCalendar,
        (ToolStripItem) this.buttonNewGroupLeg,
        (ToolStripItem) this.buttonRemoveGroupLeg,
        (ToolStripItem) this.buttonGroupAddTime,
        (ToolStripItem) this.buttonGroupRemoveTime,
        (ToolStripItem) this.buttongroupSortLegs
      });
      this.toolGroupSchedule.LayoutStyle = ToolStripLayoutStyle.Flow;
      this.toolGroupSchedule.Location = new Point(3, 16);
      this.toolGroupSchedule.Name = "toolGroupSchedule";
      this.toolGroupSchedule.Size = new Size(261, 110);
      this.toolGroupSchedule.TabIndex = 0;
      this.buttonCopyGroupCalendar.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonCopyGroupCalendar.Image = (Image) resources.GetObject("buttonCopyGroupCalendar.Image");
      this.buttonCopyGroupCalendar.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonCopyGroupCalendar.ImageTransparentColor = Color.Magenta;
      this.buttonCopyGroupCalendar.Name = "buttonCopyGroupCalendar";
      this.buttonCopyGroupCalendar.Size = new Size(52, 52);
      this.buttonCopyGroupCalendar.Text = "Copy Calendar";
      this.buttonCopyGroupCalendar.Click += new EventHandler(this.buttonCopyGroupCalendar_Click);
      this.buttonPasteGroupCalendar.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonPasteGroupCalendar.Enabled = false;
      this.buttonPasteGroupCalendar.Image = (Image) resources.GetObject("buttonPasteGroupCalendar.Image");
      this.buttonPasteGroupCalendar.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonPasteGroupCalendar.ImageTransparentColor = Color.Magenta;
      this.buttonPasteGroupCalendar.Name = "buttonPasteGroupCalendar";
      this.buttonPasteGroupCalendar.Size = new Size(52, 52);
      this.buttonPasteGroupCalendar.Text = "Paste Calendar";
      this.buttonPasteGroupCalendar.Click += new EventHandler(this.buttonPasteGroupCalendar_Click);
      this.buttonCleanGroupCalendar.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonCleanGroupCalendar.Image = (Image) resources.GetObject("buttonCleanGroupCalendar.Image");
      this.buttonCleanGroupCalendar.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonCleanGroupCalendar.ImageTransparentColor = Color.Magenta;
      this.buttonCleanGroupCalendar.Name = "buttonCleanGroupCalendar";
      this.buttonCleanGroupCalendar.Size = new Size(52, 52);
      this.buttonCleanGroupCalendar.Text = "Clean Calendar";
      this.buttonCleanGroupCalendar.Click += new EventHandler(this.buttonCleanGroupCalendar_Click);
      this.buttonNewGroupLeg.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonNewGroupLeg.Image = (Image) resources.GetObject("buttonNewGroupLeg.Image");
      this.buttonNewGroupLeg.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonNewGroupLeg.ImageTransparentColor = Color.Magenta;
      this.buttonNewGroupLeg.Name = "buttonNewGroupLeg";
      this.buttonNewGroupLeg.Size = new Size(52, 52);
      this.buttonNewGroupLeg.Text = "New Leg";
      this.buttonNewGroupLeg.Click += new EventHandler(this.buttonNewGroupLeg_Click);
      this.buttonRemoveGroupLeg.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonRemoveGroupLeg.Image = (Image) resources.GetObject("buttonRemoveGroupLeg.Image");
      this.buttonRemoveGroupLeg.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonRemoveGroupLeg.ImageTransparentColor = Color.Magenta;
      this.buttonRemoveGroupLeg.Name = "buttonRemoveGroupLeg";
      this.buttonRemoveGroupLeg.Size = new Size(52, 52);
      this.buttonRemoveGroupLeg.Text = "Remove Leg";
      this.buttonRemoveGroupLeg.Click += new EventHandler(this.buttonRemoveGroupLeg_Click);
      this.buttonGroupAddTime.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonGroupAddTime.Image = (Image) resources.GetObject("buttonGroupAddTime.Image");
      this.buttonGroupAddTime.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonGroupAddTime.ImageTransparentColor = Color.Magenta;
      this.buttonGroupAddTime.Name = "buttonGroupAddTime";
      this.buttonGroupAddTime.Size = new Size(52, 52);
      this.buttonGroupAddTime.Text = "Add Time";
      this.buttonGroupAddTime.Click += new EventHandler(this.buttonGroupAddTime_Click);
      this.buttonGroupRemoveTime.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonGroupRemoveTime.Image = (Image) resources.GetObject("buttonGroupRemoveTime.Image");
      this.buttonGroupRemoveTime.ImageScaling = ToolStripItemImageScaling.None;
      this.buttonGroupRemoveTime.ImageTransparentColor = Color.Magenta;
      this.buttonGroupRemoveTime.Name = "buttonGroupRemoveTime";
      this.buttonGroupRemoveTime.Size = new Size(52, 52);
      this.buttonGroupRemoveTime.Text = "Remove Time";
      this.buttonGroupRemoveTime.Click += new EventHandler(this.buttonGroupRemoveTime_Click);
      this.buttongroupSortLegs.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttongroupSortLegs.Image = (Image) resources.GetObject("buttongroupSortLegs.Image");
      this.buttongroupSortLegs.ImageScaling = ToolStripItemImageScaling.None;
      this.buttongroupSortLegs.ImageTransparentColor = Color.Magenta;
      this.buttongroupSortLegs.Name = "buttongroupSortLegs";
      this.buttongroupSortLegs.Size = new Size(52, 52);
      this.buttongroupSortLegs.Text = "Sort Legs By date";
      this.buttongroupSortLegs.Click += new EventHandler(this.buttongroupSortLegs_Click);
      this.groupSlots.Controls.Add((Control) this.numericPossiblePromotionMax);
      this.groupSlots.Controls.Add((Control) this.checkInfoPossiblePromotion);
      this.groupSlots.Controls.Add((Control) this.numericPossiblePromotionMin);
      this.groupSlots.Controls.Add((Control) this.numericPromotionMax);
      this.groupSlots.Controls.Add((Control) this.numericPromotionMin);
      this.groupSlots.Controls.Add((Control) this.numericRelegationMax);
      this.groupSlots.Controls.Add((Control) this.numericRelegationMin);
      this.groupSlots.Controls.Add((Control) this.numericPossibleRelegationMax);
      this.groupSlots.Controls.Add((Control) this.numericPossibleRelegationMin);
      this.groupSlots.Controls.Add((Control) this.label15);
      this.groupSlots.Controls.Add((Control) this.label16);
      this.groupSlots.Controls.Add((Control) this.checkInfoPromotion);
      this.groupSlots.Controls.Add((Control) this.checkInfoRelegation);
      this.groupSlots.Controls.Add((Control) this.checkInfoPossibleRelegation);
      this.groupSlots.Controls.Add((Control) this.checkInfoChamp);
      this.groupSlots.Location = new Point(263, 525);
      this.groupSlots.Name = "groupSlots";
      this.groupSlots.Size = new Size(252, 193);
      this.groupSlots.TabIndex = 33;
      this.groupSlots.TabStop = false;
      this.groupSlots.Text = "Slots";
      this.numericPossiblePromotionMax.Location = new Point(185, 105);
      this.numericPossiblePromotionMax.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericPossiblePromotionMax.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericPossiblePromotionMax.Name = "numericPossiblePromotionMax";
      this.numericPossiblePromotionMax.Size = new Size(61, 20);
      this.numericPossiblePromotionMax.TabIndex = 54;
      this.numericPossiblePromotionMax.TextAlign = HorizontalAlignment.Center;
      this.numericPossiblePromotionMax.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericPossiblePromotionMax.ValueChanged += new EventHandler(this.numericPossiblePromotionMax_ValueChanged);
      this.checkInfoPossiblePromotion.AutoSize = true;
      this.checkInfoPossiblePromotion.Location = new Point(5, 106);
      this.checkInfoPossiblePromotion.Name = "checkInfoPossiblePromotion";
      this.checkInfoPossiblePromotion.Size = new Size(115, 17);
      this.checkInfoPossiblePromotion.TabIndex = 45;
      this.checkInfoPossiblePromotion.Text = "Possible Promotion";
      this.checkInfoPossiblePromotion.UseVisualStyleBackColor = true;
      this.checkInfoPossiblePromotion.CheckedChanged += new EventHandler(this.checkInfoPossiblePromotion_CheckedChanged);
      this.numericPossiblePromotionMin.Location = new Point(120, 105);
      this.numericPossiblePromotionMin.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericPossiblePromotionMin.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericPossiblePromotionMin.Name = "numericPossiblePromotionMin";
      this.numericPossiblePromotionMin.Size = new Size(61, 20);
      this.numericPossiblePromotionMin.TabIndex = 53;
      this.numericPossiblePromotionMin.TextAlign = HorizontalAlignment.Center;
      this.numericPossiblePromotionMin.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericPossiblePromotionMin.ValueChanged += new EventHandler(this.numericPossiblePromotionMin_ValueChanged);
      this.numericPromotionMax.Location = new Point(185, 83);
      this.numericPromotionMax.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericPromotionMax.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericPromotionMax.Name = "numericPromotionMax";
      this.numericPromotionMax.Size = new Size(61, 20);
      this.numericPromotionMax.TabIndex = 56;
      this.numericPromotionMax.TextAlign = HorizontalAlignment.Center;
      this.numericPromotionMax.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericPromotionMax.ValueChanged += new EventHandler(this.numericPromotionMax_ValueChanged);
      this.numericPromotionMin.Location = new Point(120, 83);
      this.numericPromotionMin.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericPromotionMin.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericPromotionMin.Name = "numericPromotionMin";
      this.numericPromotionMin.Size = new Size(61, 20);
      this.numericPromotionMin.TabIndex = 55;
      this.numericPromotionMin.TextAlign = HorizontalAlignment.Center;
      this.numericPromotionMin.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericPromotionMin.ValueChanged += new EventHandler(this.numericPromotionMin_ValueChanged);
      this.numericRelegationMax.Location = new Point(185, 61);
      this.numericRelegationMax.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericRelegationMax.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericRelegationMax.Name = "numericRelegationMax";
      this.numericRelegationMax.Size = new Size(61, 20);
      this.numericRelegationMax.TabIndex = 52;
      this.numericRelegationMax.TextAlign = HorizontalAlignment.Center;
      this.numericRelegationMax.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericRelegationMax.ValueChanged += new EventHandler(this.numericRelegationMax_ValueChanged);
      this.numericRelegationMin.Location = new Point(120, 61);
      this.numericRelegationMin.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericRelegationMin.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericRelegationMin.Name = "numericRelegationMin";
      this.numericRelegationMin.Size = new Size(61, 20);
      this.numericRelegationMin.TabIndex = 51;
      this.numericRelegationMin.TextAlign = HorizontalAlignment.Center;
      this.numericRelegationMin.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericRelegationMin.ValueChanged += new EventHandler(this.numericRelegationMin_ValueChanged);
      this.numericPossibleRelegationMax.Location = new Point(185, 39);
      this.numericPossibleRelegationMax.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericPossibleRelegationMax.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericPossibleRelegationMax.Name = "numericPossibleRelegationMax";
      this.numericPossibleRelegationMax.Size = new Size(61, 20);
      this.numericPossibleRelegationMax.TabIndex = 50;
      this.numericPossibleRelegationMax.TextAlign = HorizontalAlignment.Center;
      this.numericPossibleRelegationMax.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericPossibleRelegationMax.ValueChanged += new EventHandler(this.numericPossibleRelegationMax_ValueChanged);
      this.numericPossibleRelegationMin.Location = new Point(120, 39);
      this.numericPossibleRelegationMin.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericPossibleRelegationMin.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericPossibleRelegationMin.Name = "numericPossibleRelegationMin";
      this.numericPossibleRelegationMin.Size = new Size(61, 20);
      this.numericPossibleRelegationMin.TabIndex = 49;
      this.numericPossibleRelegationMin.TextAlign = HorizontalAlignment.Center;
      this.numericPossibleRelegationMin.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericPossibleRelegationMin.ValueChanged += new EventHandler(this.numericPossibleRelegationMin_ValueChanged);
      this.label15.AutoSize = true;
      this.label15.Location = new Point(196, 23);
      this.label15.Name = "label15";
      this.label15.Size = new Size(39, 13);
      this.label15.TabIndex = 48;
      this.label15.Text = "to pos.";
      this.label16.AutoSize = true;
      this.label16.Location = new Point(125, 23);
      this.label16.Name = "label16";
      this.label16.Size = new Size(50, 13);
      this.label16.TabIndex = 47;
      this.label16.Text = "from pos.";
      this.checkInfoPromotion.AutoSize = true;
      this.checkInfoPromotion.Location = new Point(5, 84);
      this.checkInfoPromotion.Name = "checkInfoPromotion";
      this.checkInfoPromotion.Size = new Size(73, 17);
      this.checkInfoPromotion.TabIndex = 46;
      this.checkInfoPromotion.Text = "Promotion";
      this.checkInfoPromotion.UseVisualStyleBackColor = true;
      this.checkInfoPromotion.CheckedChanged += new EventHandler(this.checkInfoPromotion_CheckedChanged);
      this.checkInfoRelegation.AutoSize = true;
      this.checkInfoRelegation.Location = new Point(5, 62);
      this.checkInfoRelegation.Name = "checkInfoRelegation";
      this.checkInfoRelegation.Size = new Size(77, 17);
      this.checkInfoRelegation.TabIndex = 44;
      this.checkInfoRelegation.Text = "Relegation";
      this.checkInfoRelegation.UseVisualStyleBackColor = true;
      this.checkInfoRelegation.CheckedChanged += new EventHandler(this.checkInfoRelegation_CheckedChanged);
      this.checkInfoPossibleRelegation.AutoSize = true;
      this.checkInfoPossibleRelegation.Location = new Point(5, 40);
      this.checkInfoPossibleRelegation.Name = "checkInfoPossibleRelegation";
      this.checkInfoPossibleRelegation.Size = new Size(119, 17);
      this.checkInfoPossibleRelegation.TabIndex = 43;
      this.checkInfoPossibleRelegation.Text = "Possible Relegation";
      this.checkInfoPossibleRelegation.UseVisualStyleBackColor = true;
      this.checkInfoPossibleRelegation.CheckedChanged += new EventHandler(this.checkInfoPossibleRelegation_CheckedChanged);
      this.checkInfoChamp.AutoSize = true;
      this.checkInfoChamp.Location = new Point(5, 19);
      this.checkInfoChamp.Name = "checkInfoChamp";
      this.checkInfoChamp.Size = new Size(60, 17);
      this.checkInfoChamp.TabIndex = 42;
      this.checkInfoChamp.Text = "Winner";
      this.checkInfoChamp.UseVisualStyleBackColor = true;
      this.checkInfoChamp.CheckedChanged += new EventHandler(this.checkInfoChamp_CheckedChanged);
      this.groupInfoColors.Controls.Add((Control) this.numericColorPossiblePromotionMax);
      this.groupInfoColors.Controls.Add((Control) this.checkInfoColorPossiblePromotion);
      this.groupInfoColors.Controls.Add((Control) this.numericColorAdvanceMax);
      this.groupInfoColors.Controls.Add((Control) this.numericColorPossiblePromotionMin);
      this.groupInfoColors.Controls.Add((Control) this.numericColorAdvanceMin);
      this.groupInfoColors.Controls.Add((Control) this.numericColorPromotionMax);
      this.groupInfoColors.Controls.Add((Control) this.numericColorPromotionMin);
      this.groupInfoColors.Controls.Add((Control) this.numericColorRelegationMax);
      this.groupInfoColors.Controls.Add((Control) this.numericColorRelegationMin);
      this.groupInfoColors.Controls.Add((Control) this.numericColorPossibleRelegationMax);
      this.groupInfoColors.Controls.Add((Control) this.numericColorPossibleRelegationMin);
      this.groupInfoColors.Controls.Add((Control) this.numericColorEuropaMax);
      this.groupInfoColors.Controls.Add((Control) this.numericColorEuropaMin);
      this.groupInfoColors.Controls.Add((Control) this.numericColorChampionsMax);
      this.groupInfoColors.Controls.Add((Control) this.numericColorChampionsMin);
      this.groupInfoColors.Controls.Add((Control) this.label12);
      this.groupInfoColors.Controls.Add((Control) this.label11);
      this.groupInfoColors.Controls.Add((Control) this.checkInfoColorAdvance);
      this.groupInfoColors.Controls.Add((Control) this.checkInfoColorPromotion);
      this.groupInfoColors.Controls.Add((Control) this.checkInfoColorRelegation);
      this.groupInfoColors.Controls.Add((Control) this.checkInfoColorPossibleRelegation);
      this.groupInfoColors.Controls.Add((Control) this.checkInfoColorEuropa);
      this.groupInfoColors.Controls.Add((Control) this.checkInfoColorChampions);
      this.groupInfoColors.Controls.Add((Control) this.checkInfoColorChamp);
      this.groupInfoColors.Location = new Point(5, 525);
      this.groupInfoColors.Name = "groupInfoColors";
      this.groupInfoColors.Size = new Size(254, 193);
      this.groupInfoColors.TabIndex = 32;
      this.groupInfoColors.TabStop = false;
      this.groupInfoColors.Text = "Colors";
      this.numericColorPossiblePromotionMax.Location = new Point(188, 144);
      this.numericColorPossiblePromotionMax.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericColorPossiblePromotionMax.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorPossiblePromotionMax.Name = "numericColorPossiblePromotionMax";
      this.numericColorPossiblePromotionMax.Size = new Size(61, 20);
      this.numericColorPossiblePromotionMax.TabIndex = 39;
      this.numericColorPossiblePromotionMax.TextAlign = HorizontalAlignment.Center;
      this.numericColorPossiblePromotionMax.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorPossiblePromotionMax.ValueChanged += new EventHandler(this.numericColorPossiblePromotionMax_ValueChanged);
      this.checkInfoColorPossiblePromotion.AutoSize = true;
      this.checkInfoColorPossiblePromotion.Location = new Point(6, 145);
      this.checkInfoColorPossiblePromotion.Name = "checkInfoColorPossiblePromotion";
      this.checkInfoColorPossiblePromotion.Size = new Size(115, 17);
      this.checkInfoColorPossiblePromotion.TabIndex = 5;
      this.checkInfoColorPossiblePromotion.Text = "Possible Promotion";
      this.checkInfoColorPossiblePromotion.UseVisualStyleBackColor = true;
      this.checkInfoColorPossiblePromotion.CheckedChanged += new EventHandler(this.checkInfoColorPossiblePromotion_CheckedChanged);
      this.numericColorAdvanceMax.Location = new Point(188, 166);
      this.numericColorAdvanceMax.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericColorAdvanceMax.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorAdvanceMax.Name = "numericColorAdvanceMax";
      this.numericColorAdvanceMax.Size = new Size(61, 20);
      this.numericColorAdvanceMax.TabIndex = 43;
      this.numericColorAdvanceMax.TextAlign = HorizontalAlignment.Center;
      this.numericColorAdvanceMax.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorAdvanceMax.ValueChanged += new EventHandler(this.numericColorAdvanceMax_ValueChanged);
      this.numericColorPossiblePromotionMin.Location = new Point(122, 144);
      this.numericColorPossiblePromotionMin.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericColorPossiblePromotionMin.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorPossiblePromotionMin.Name = "numericColorPossiblePromotionMin";
      this.numericColorPossiblePromotionMin.Size = new Size(61, 20);
      this.numericColorPossiblePromotionMin.TabIndex = 38;
      this.numericColorPossiblePromotionMin.TextAlign = HorizontalAlignment.Center;
      this.numericColorPossiblePromotionMin.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorPossiblePromotionMin.ValueChanged += new EventHandler(this.numericColorPossiblePromotionMin_ValueChanged);
      this.numericColorAdvanceMin.Location = new Point(122, 166);
      this.numericColorAdvanceMin.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericColorAdvanceMin.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorAdvanceMin.Name = "numericColorAdvanceMin";
      this.numericColorAdvanceMin.Size = new Size(61, 20);
      this.numericColorAdvanceMin.TabIndex = 42;
      this.numericColorAdvanceMin.TextAlign = HorizontalAlignment.Center;
      this.numericColorAdvanceMin.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorAdvanceMin.ValueChanged += new EventHandler(this.numericColorAdvanceMin_ValueChanged);
      this.numericColorPromotionMax.Location = new Point(188, 122);
      this.numericColorPromotionMax.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericColorPromotionMax.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorPromotionMax.Name = "numericColorPromotionMax";
      this.numericColorPromotionMax.Size = new Size(61, 20);
      this.numericColorPromotionMax.TabIndex = 41;
      this.numericColorPromotionMax.TextAlign = HorizontalAlignment.Center;
      this.numericColorPromotionMax.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorPromotionMax.ValueChanged += new EventHandler(this.numericColorPromotionMax_ValueChanged);
      this.numericColorPromotionMin.Location = new Point(122, 122);
      this.numericColorPromotionMin.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericColorPromotionMin.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorPromotionMin.Name = "numericColorPromotionMin";
      this.numericColorPromotionMin.Size = new Size(61, 20);
      this.numericColorPromotionMin.TabIndex = 40;
      this.numericColorPromotionMin.TextAlign = HorizontalAlignment.Center;
      this.numericColorPromotionMin.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorPromotionMin.ValueChanged += new EventHandler(this.numericColorPromotionMin_ValueChanged);
      this.numericColorRelegationMax.Location = new Point(188, 100);
      this.numericColorRelegationMax.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericColorRelegationMax.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorRelegationMax.Name = "numericColorRelegationMax";
      this.numericColorRelegationMax.Size = new Size(61, 20);
      this.numericColorRelegationMax.TabIndex = 37;
      this.numericColorRelegationMax.TextAlign = HorizontalAlignment.Center;
      this.numericColorRelegationMax.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorRelegationMax.ValueChanged += new EventHandler(this.numericColorRelegationMax_ValueChanged);
      this.numericColorRelegationMin.Location = new Point(122, 100);
      this.numericColorRelegationMin.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericColorRelegationMin.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorRelegationMin.Name = "numericColorRelegationMin";
      this.numericColorRelegationMin.Size = new Size(61, 20);
      this.numericColorRelegationMin.TabIndex = 36;
      this.numericColorRelegationMin.TextAlign = HorizontalAlignment.Center;
      this.numericColorRelegationMin.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorRelegationMin.ValueChanged += new EventHandler(this.numericColorRelegationMin_ValueChanged);
      this.numericColorPossibleRelegationMax.Location = new Point(188, 78);
      this.numericColorPossibleRelegationMax.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericColorPossibleRelegationMax.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorPossibleRelegationMax.Name = "numericColorPossibleRelegationMax";
      this.numericColorPossibleRelegationMax.Size = new Size(61, 20);
      this.numericColorPossibleRelegationMax.TabIndex = 35;
      this.numericColorPossibleRelegationMax.TextAlign = HorizontalAlignment.Center;
      this.numericColorPossibleRelegationMax.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorPossibleRelegationMax.ValueChanged += new EventHandler(this.numericColorPossibleRelegationMax_ValueChanged);
      this.numericColorPossibleRelegationMin.Location = new Point(122, 78);
      this.numericColorPossibleRelegationMin.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericColorPossibleRelegationMin.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorPossibleRelegationMin.Name = "numericColorPossibleRelegationMin";
      this.numericColorPossibleRelegationMin.Size = new Size(61, 20);
      this.numericColorPossibleRelegationMin.TabIndex = 34;
      this.numericColorPossibleRelegationMin.TextAlign = HorizontalAlignment.Center;
      this.numericColorPossibleRelegationMin.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorPossibleRelegationMin.ValueChanged += new EventHandler(this.numericColorPossibleRelegationMin_ValueChanged);
      this.numericColorEuropaMax.Location = new Point(188, 56);
      this.numericColorEuropaMax.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericColorEuropaMax.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorEuropaMax.Name = "numericColorEuropaMax";
      this.numericColorEuropaMax.Size = new Size(61, 20);
      this.numericColorEuropaMax.TabIndex = 33;
      this.numericColorEuropaMax.TextAlign = HorizontalAlignment.Center;
      this.numericColorEuropaMax.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorEuropaMax.ValueChanged += new EventHandler(this.numericColorEuropaMax_ValueChanged);
      this.numericColorEuropaMin.Location = new Point(122, 56);
      this.numericColorEuropaMin.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericColorEuropaMin.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorEuropaMin.Name = "numericColorEuropaMin";
      this.numericColorEuropaMin.Size = new Size(61, 20);
      this.numericColorEuropaMin.TabIndex = 32;
      this.numericColorEuropaMin.TextAlign = HorizontalAlignment.Center;
      this.numericColorEuropaMin.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorEuropaMin.ValueChanged += new EventHandler(this.numericColorEuropaMin_ValueChanged);
      this.numericColorChampionsMax.Location = new Point(188, 34);
      this.numericColorChampionsMax.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericColorChampionsMax.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorChampionsMax.Name = "numericColorChampionsMax";
      this.numericColorChampionsMax.Size = new Size(61, 20);
      this.numericColorChampionsMax.TabIndex = 31;
      this.numericColorChampionsMax.TextAlign = HorizontalAlignment.Center;
      this.numericColorChampionsMax.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorChampionsMax.ValueChanged += new EventHandler(this.numericColorChampionsMax_ValueChanged);
      this.numericColorChampionsMin.Location = new Point(122, 34);
      this.numericColorChampionsMin.Maximum = new Decimal(new int[4]
      {
        24,
        0,
        0,
        0
      });
      this.numericColorChampionsMin.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorChampionsMin.Name = "numericColorChampionsMin";
      this.numericColorChampionsMin.Size = new Size(61, 20);
      this.numericColorChampionsMin.TabIndex = 30;
      this.numericColorChampionsMin.TextAlign = HorizontalAlignment.Center;
      this.numericColorChampionsMin.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericColorChampionsMin.ValueChanged += new EventHandler(this.numericColorChampionsMin_ValueChanged);
      this.label12.AutoSize = true;
      this.label12.Location = new Point(199, 19);
      this.label12.Name = "label12";
      this.label12.Size = new Size(39, 13);
      this.label12.TabIndex = 9;
      this.label12.Text = "to pos.";
      this.label11.AutoSize = true;
      this.label11.Location = new Point((int) sbyte.MaxValue, 19);
      this.label11.Name = "label11";
      this.label11.Size = new Size(50, 13);
      this.label11.TabIndex = 8;
      this.label11.Text = "from pos.";
      this.checkInfoColorAdvance.AutoSize = true;
      this.checkInfoColorAdvance.Location = new Point(6, 167);
      this.checkInfoColorAdvance.Name = "checkInfoColorAdvance";
      this.checkInfoColorAdvance.Size = new Size(69, 17);
      this.checkInfoColorAdvance.TabIndex = 7;
      this.checkInfoColorAdvance.Text = "Advance";
      this.checkInfoColorAdvance.UseVisualStyleBackColor = true;
      this.checkInfoColorAdvance.CheckedChanged += new EventHandler(this.checkInfoColorAdvance_CheckedChanged);
      this.checkInfoColorPromotion.AutoSize = true;
      this.checkInfoColorPromotion.Location = new Point(6, 123);
      this.checkInfoColorPromotion.Name = "checkInfoColorPromotion";
      this.checkInfoColorPromotion.Size = new Size(73, 17);
      this.checkInfoColorPromotion.TabIndex = 6;
      this.checkInfoColorPromotion.Text = "Promotion";
      this.checkInfoColorPromotion.UseVisualStyleBackColor = true;
      this.checkInfoColorPromotion.CheckedChanged += new EventHandler(this.checkInfoColorPromotion_CheckedChanged);
      this.checkInfoColorRelegation.AutoSize = true;
      this.checkInfoColorRelegation.Location = new Point(6, 101);
      this.checkInfoColorRelegation.Name = "checkInfoColorRelegation";
      this.checkInfoColorRelegation.Size = new Size(77, 17);
      this.checkInfoColorRelegation.TabIndex = 4;
      this.checkInfoColorRelegation.Text = "Relegation";
      this.checkInfoColorRelegation.UseVisualStyleBackColor = true;
      this.checkInfoColorRelegation.CheckedChanged += new EventHandler(this.checkInfoColorRelegation_CheckedChanged);
      this.checkInfoColorPossibleRelegation.AutoSize = true;
      this.checkInfoColorPossibleRelegation.Location = new Point(6, 79);
      this.checkInfoColorPossibleRelegation.Name = "checkInfoColorPossibleRelegation";
      this.checkInfoColorPossibleRelegation.Size = new Size(119, 17);
      this.checkInfoColorPossibleRelegation.TabIndex = 3;
      this.checkInfoColorPossibleRelegation.Text = "Possible Relegation";
      this.checkInfoColorPossibleRelegation.UseVisualStyleBackColor = true;
      this.checkInfoColorPossibleRelegation.CheckedChanged += new EventHandler(this.checkInfoColorPossibleRelegation_CheckedChanged);
      this.checkInfoColorEuropa.AutoSize = true;
      this.checkInfoColorEuropa.Location = new Point(6, 57);
      this.checkInfoColorEuropa.Name = "checkInfoColorEuropa";
      this.checkInfoColorEuropa.Size = new Size(99, 17);
      this.checkInfoColorEuropa.TabIndex = 2;
      this.checkInfoColorEuropa.Text = "Europa League";
      this.checkInfoColorEuropa.UseVisualStyleBackColor = true;
      this.checkInfoColorEuropa.CheckedChanged += new EventHandler(this.checkInfoColorEuropa_CheckedChanged);
      this.checkInfoColorChampions.AutoSize = true;
      this.checkInfoColorChampions.Location = new Point(6, 35);
      this.checkInfoColorChampions.Name = "checkInfoColorChampions";
      this.checkInfoColorChampions.Size = new Size(117, 17);
      this.checkInfoColorChampions.TabIndex = 1;
      this.checkInfoColorChampions.Text = "Champions League";
      this.checkInfoColorChampions.UseVisualStyleBackColor = true;
      this.checkInfoColorChampions.CheckedChanged += new EventHandler(this.checkInfoColorChampions_CheckedChanged);
      this.checkInfoColorChamp.AutoSize = true;
      this.checkInfoColorChamp.Location = new Point(6, 15);
      this.checkInfoColorChamp.Name = "checkInfoColorChamp";
      this.checkInfoColorChamp.Size = new Size(60, 17);
      this.checkInfoColorChamp.TabIndex = 0;
      this.checkInfoColorChamp.Text = "Winner";
      this.checkInfoColorChamp.UseVisualStyleBackColor = true;
      this.checkInfoColorChamp.CheckedChanged += new EventHandler(this.checkInfoColorChamp_CheckedChanged);
      this.label4.AutoSize = true;
      this.label4.Location = new Point(6, 25);
      this.label4.Name = "label4";
      this.label4.Size = new Size(65, 13);
      this.label4.TabIndex = 13;
      this.label4.Text = "N. of Teams";
      this.numericNTeams.Location = new Point(89, 21);
      this.numericNTeams.Maximum = new Decimal(new int[4]
      {
        128,
        0,
        0,
        0
      });
      this.numericNTeams.Name = "numericNTeams";
      this.numericNTeams.Size = new Size(74, 20);
      this.numericNTeams.TabIndex = 14;
      this.numericNTeams.TextAlign = HorizontalAlignment.Center;
      this.numericNTeams.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericNTeams.ValueChanged += new EventHandler(this.numericNTeams_ValueChanged);
      this.panelCompObj.Controls.Add((Control) this.textLanguageName);
      this.panelCompObj.Controls.Add((Control) this.label66);
      this.panelCompObj.Controls.Add((Control) this.textUniqueId);
      this.panelCompObj.Controls.Add((Control) this.comboLanguageKey);
      this.panelCompObj.Controls.Add((Control) this.label3);
      this.panelCompObj.Controls.Add((Control) this.textLanguageKey);
      this.panelCompObj.Controls.Add((Control) this.label2);
      this.panelCompObj.Controls.Add((Control) this.textFourCharName);
      this.panelCompObj.Controls.Add((Control) this.label1);
      this.panelCompObj.Dock = DockStyle.Top;
      this.panelCompObj.Location = new Point(0, 0);
      this.panelCompObj.Name = "panelCompObj";
      this.panelCompObj.Size = new Size(798, 30);
      this.panelCompObj.TabIndex = 0;
      this.textLanguageName.Location = new Point(626, 5);
      this.textLanguageName.Name = "textLanguageName";
      this.textLanguageName.Size = new Size(168, 20);
      this.textLanguageName.TabIndex = 7;
      this.textLanguageName.TextChanged += new EventHandler(this.textLanguageName_TextChanged);
      this.label66.AutoSize = true;
      this.label66.Location = new Point(7, 8);
      this.label66.Name = "label66";
      this.label66.Size = new Size(19, 13);
      this.label66.TabIndex = 2;
      this.label66.Text = "Id.";
      this.textUniqueId.Enabled = false;
      this.textUniqueId.Location = new Point(29, 4);
      this.textUniqueId.Name = "textUniqueId";
      this.textUniqueId.Size = new Size(51, 20);
      this.textUniqueId.TabIndex = 3;
      this.comboLanguageKey.FormattingEnabled = true;
      this.comboLanguageKey.Location = new Point(343, 4);
      this.comboLanguageKey.Name = "comboLanguageKey";
      this.comboLanguageKey.Size = new Size(185, 21);
      this.comboLanguageKey.TabIndex = 6;
      this.comboLanguageKey.SelectedIndexChanged += new EventHandler(this.comboLanguageKey_SelectedIndexChanged);
      this.label3.AutoSize = true;
      this.label3.Location = new Point(534, 7);
      this.label3.Name = "label3";
      this.label3.Size = new Size(86, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Language Name";
      this.textLanguageKey.Location = new Point(343, 4);
      this.textLanguageKey.Name = "textLanguageKey";
      this.textLanguageKey.Size = new Size(185, 20);
      this.textLanguageKey.TabIndex = 3;
      this.textLanguageKey.TextChanged += new EventHandler(this.textLanguageKey_TextChanged);
      this.label2.AutoSize = true;
      this.label2.Location = new Point(261, 7);
      this.label2.Name = "label2";
      this.label2.Size = new Size(76, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Language Key";
      this.textFourCharName.Location = new Point(173, 4);
      this.textFourCharName.Name = "textFourCharName";
      this.textFourCharName.Size = new Size(72, 20);
      this.textFourCharName.TabIndex = 1;
      this.textFourCharName.TextAlign = HorizontalAlignment.Center;
      this.textFourCharName.TextChanged += new EventHandler(this.textFourCharName_TextChanged);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(93, 7);
      this.label1.Name = "label1";
      this.label1.Size = new Size(74, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "4 Chars Name";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImageLayout = ImageLayout.Center;
      this.ClientSize = new Size(1087, 780);
      this.Controls.Add((Control) this.splitContainer1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = "CompetitionForm";
      this.Text = "TrophyForm";
      this.Load += new EventHandler(this.CompetitionsForm_Load);
      this.groupConfederation.ResumeLayout(false);
      this.groupConfederation.PerformLayout();
      this.groupNation.ResumeLayout(false);
      this.groupNation.PerformLayout();
      this.groupWeather.ResumeLayout(false);
      this.groupWeather.PerformLayout();
      this.toolWeather.ResumeLayout(false);
      this.toolWeather.PerformLayout();
      this.numericUpDown34.EndInit();
      this.numericUpDown35.EndInit();
      this.numericUpDown36.EndInit();
      this.numericUpDown31.EndInit();
      this.numericUpDown32.EndInit();
      this.numericUpDown33.EndInit();
      this.numericUpDown28.EndInit();
      this.numericUpDown29.EndInit();
      this.numericUpDown30.EndInit();
      this.numericUpDown25.EndInit();
      this.numericUpDown26.EndInit();
      this.numericUpDown27.EndInit();
      this.numericUpDown22.EndInit();
      this.numericUpDown23.EndInit();
      this.numericUpDown24.EndInit();
      this.numericUpDown19.EndInit();
      this.numericUpDown20.EndInit();
      this.numericUpDown21.EndInit();
      this.numericUpDown16.EndInit();
      this.numericUpDown17.EndInit();
      this.numericUpDown18.EndInit();
      this.numericUpDown13.EndInit();
      this.numericUpDown14.EndInit();
      this.numericUpDown15.EndInit();
      this.numericUpDown10.EndInit();
      this.numericUpDown11.EndInit();
      this.numericUpDown12.EndInit();
      this.numericUpDown7.EndInit();
      this.numericUpDown8.EndInit();
      this.numericUpDown9.EndInit();
      this.numericUpDown4.EndInit();
      this.numericUpDown5.EndInit();
      this.numericUpDown6.EndInit();
      this.numericUpDown1.EndInit();
      this.numericUpDown2.EndInit();
      this.numericUpDown3.EndInit();
      this.numericNationYellowsStored.EndInit();
      this.groupTrophy.ResumeLayout(false);
      this.groupTrophy.PerformLayout();
      this.groupInternationalschedule.ResumeLayout(false);
      this.groupInternationalschedule.PerformLayout();
      this.numericInternationalPeriodicity.EndInit();
      this.numericInternationalFirstYear.EndInit();
      this.numericBall.EndInit();
      ((ISupportInitialize) this.pictureBall).EndInit();
      this.groupBenchPlayers.ResumeLayout(false);
      this.groupBenchPlayers.PerformLayout();
      this.numericImportance.EndInit();
      this.groupPromotionRelegation.ResumeLayout(false);
      this.numericAssetId.EndInit();
      this.groupSchedule.ResumeLayout(false);
      this.groupSchedule.PerformLayout();
      this.groupStage.ResumeLayout(false);
      this.groupStage.PerformLayout();
      this.groupSetupStage.ResumeLayout(false);
      this.groupSetupStage.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupPlayStage.ResumeLayout(false);
      this.groupPlayStage.PerformLayout();
      this.numericKeepPointsStageRef.EndInit();
      this.groupLeaguetasks.ResumeLayout(false);
      this.groupStageSchedules.ResumeLayout(false);
      this.groupStageSchedules.PerformLayout();
      this.panelStageScheduleDetails.ResumeLayout(false);
      this.groupStageScheduleDetails.ResumeLayout(false);
      this.groupStageScheduleDetails.PerformLayout();
      this.numericStageMinGames.EndInit();
      this.numericStageMaxGames.EndInit();
      this.toolStageSchedule.ResumeLayout(false);
      this.toolStageSchedule.PerformLayout();
      this.numericRegularSeason.EndInit();
      this.numericKeepPointsPercentage.EndInit();
      this.numericStageRef.EndInit();
      this.groupStadiums.ResumeLayout(false);
      this.numericMoneyDrop.EndInit();
      this.numericPrizeMoney.EndInit();
      this.numericStandingsRank.EndInit();
      this.numericStandingKeep.EndInit();
      this.toolCompetitionTree.ResumeLayout(false);
      this.toolCompetitionTree.PerformLayout();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.tabCompetitions.ResumeLayout(false);
      this.pageWorld.ResumeLayout(false);
      this.pageWorld.PerformLayout();
      this.numericStartYear.EndInit();
      this.pageConfederation.ResumeLayout(false);
      this.pageNation.ResumeLayout(false);
      this.pageTrophy.ResumeLayout(false);
      this.tabTrophy.ResumeLayout(false);
      this.tabPageTrophyStructure.ResumeLayout(false);
      this.tabPageRankingTable.ResumeLayout(false);
      this.groupInitTeams.ResumeLayout(false);
      this.groupInitTeams.PerformLayout();
      this.numericUpdateTableEntries.EndInit();
      this.panelInitTeam24.ResumeLayout(false);
      this.panelInitTeam23.ResumeLayout(false);
      this.panelInitTeam22.ResumeLayout(false);
      this.panelInitTeam21.ResumeLayout(false);
      this.panelInitTeam20.ResumeLayout(false);
      this.panelInitTeam19.ResumeLayout(false);
      this.panelInitTeam18.ResumeLayout(false);
      this.panelInitTeam17.ResumeLayout(false);
      this.panelInitTeam16.ResumeLayout(false);
      this.panelInitTeam15.ResumeLayout(false);
      this.panelInitTeam14.ResumeLayout(false);
      this.panelInitTeam13.ResumeLayout(false);
      this.panelInitTeam12.ResumeLayout(false);
      this.panelInitTeam11.ResumeLayout(false);
      this.panelInitTeam10.ResumeLayout(false);
      this.panelInitTeam9.ResumeLayout(false);
      this.panelInitTeam8.ResumeLayout(false);
      this.panelInitTeam7.ResumeLayout(false);
      this.panelInitTeam6.ResumeLayout(false);
      this.panelInitTeam5.ResumeLayout(false);
      this.panelInitTeam4.ResumeLayout(false);
      this.panelInitTeam3.ResumeLayout(false);
      this.panelInitTeam2.ResumeLayout(false);
      this.panelInitTeam1.ResumeLayout(false);
      this.tabPageTrophyGraphics.ResumeLayout(false);
      this.groupGraphics.ResumeLayout(false);
      this.group3D.ResumeLayout(false);
      this.group3D.PerformLayout();
      this.toolNear3D.ResumeLayout(false);
      this.toolNear3D.PerformLayout();
      this.pageStage.ResumeLayout(false);
      this.pageGroup.ResumeLayout(false);
      this.groupGroup.ResumeLayout(false);
      this.groupGroup.PerformLayout();
      this.groupRules.ResumeLayout(false);
      this.panelQualificationRules.ResumeLayout(false);
      this.panelQualificationRules.PerformLayout();
      this.toolRules.ResumeLayout(false);
      this.toolRules.PerformLayout();
      this.groupPlayGroup.ResumeLayout(false);
      this.groupPlayGroup.PerformLayout();
      this.numericNumGames.EndInit();
      this.groupGroupScheduke.ResumeLayout(false);
      this.groupGroupScheduke.PerformLayout();
      this.panelGroupScheduleDetails.ResumeLayout(false);
      this.groupGroupScheduleDetails.ResumeLayout(false);
      this.groupGroupScheduleDetails.PerformLayout();
      this.numericGroupMinGames.EndInit();
      this.numericGroupMaxGames.EndInit();
      this.toolGroupSchedule.ResumeLayout(false);
      this.toolGroupSchedule.PerformLayout();
      this.groupSlots.ResumeLayout(false);
      this.groupSlots.PerformLayout();
      this.numericPossiblePromotionMax.EndInit();
      this.numericPossiblePromotionMin.EndInit();
      this.numericPromotionMax.EndInit();
      this.numericPromotionMin.EndInit();
      this.numericRelegationMax.EndInit();
      this.numericRelegationMin.EndInit();
      this.numericPossibleRelegationMax.EndInit();
      this.numericPossibleRelegationMin.EndInit();
      this.groupInfoColors.ResumeLayout(false);
      this.groupInfoColors.PerformLayout();
      this.numericColorPossiblePromotionMax.EndInit();
      this.numericColorAdvanceMax.EndInit();
      this.numericColorPossiblePromotionMin.EndInit();
      this.numericColorAdvanceMin.EndInit();
      this.numericColorPromotionMax.EndInit();
      this.numericColorPromotionMin.EndInit();
      this.numericColorRelegationMax.EndInit();
      this.numericColorRelegationMin.EndInit();
      this.numericColorPossibleRelegationMax.EndInit();
      this.numericColorPossibleRelegationMin.EndInit();
      this.numericColorEuropaMax.EndInit();
      this.numericColorEuropaMin.EndInit();
      this.numericColorChampionsMax.EndInit();
      this.numericColorChampionsMin.EndInit();
      this.numericNTeams.EndInit();
      this.panelCompObj.ResumeLayout(false);
      this.panelCompObj.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
