// Original code created by Rinaldo

using FifaControls;
using FifaLibrary;
using Microsoft.DirectX.Direct3D;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace CreationMaster
{
    public class PlayerForm : Form
    {
        private static Color[] c_AccPalette = new Color[14]
        {
      Color.White,
      Color.Black,
      Color.Blue,
      Color.Red,
      Color.Yellow,
      Color.Green,
      Color.Orange,
      Color.Purple,
      Color.Brown,
      Color.Pink,
      Color.Maroon,
      Color.LightBlue,
      Color.Navy,
      Color.Gray
        };
        private static Color[] c_GlovesPalette = new Color[5]
        {
      Color.White,
      Color.Black,
      Color.Yellow,
      Color.Red,
      Color.Navy
        };
        private string m_PlayerCurrentFolder = FifaEnvironment.ExportFolder;
        private NewIdCreator m_NewIdCreator = new NewIdCreator();
        private bool m_AttributesSema = true;
        private bool m_OverallSema = true;
        private bool m_GenericAppearanceSema = true;
        private int m_HairAlfaChannel = 1;
        private IContainer components;
        public PickUpControl pickUpControl;
        private TabControl tabEditPlayer;
        private TabPage pageInfo;
        private TabPage pageSkills;
        private TabPage pageFace;
        private ImageList imageListTabIcons;
        private FlowLayoutPanel flowPanelInfo;
        private GroupBox groupPlayerIdentity;
        private Button buttonGetId;
        private NumericUpDown numericPlayerId;
        private Viewer2D viewer2DPhoto;
        private Button buttonRandomizeIdentity;
        private DateTimePicker dateBirthDate;
        private Label labelBirthdate;
        private Label labelPlayerId;
        private TextBox textSurname;
        private TextBox textFirstName;
        private ComboBox comboCountry;
        private Label labelFirstName;
        private Label labelSurame;
        private Label labelCountry;
        private Label labelCommonName;
        private TextBox textCommonName;
        private TextBox textJerseyName;
        private Label labelJerseyName;
        private BindingSource countryListBindingSource;
        private BindingSource playerBindingSource;
        private GroupBox groupBoxBody;
        private NumericUpDown numericHeight;
        private NumericUpDown numericWeight;
        private Label labelWeight;
        private Label labelBody;
        private DomainUpDown domainPreferredFoot;
        private Label labelHeight;
        private Label labelPreferredFoot;
        private ComboBox comboBody;
        private GroupBox groupBoxLook;
        public NumericUpDown numericShoesDesign;
        private Viewer2D viewer2DShoes;
        private DomainUpDown domainJerseyStyle;
        public NumericUpDown numericShoesBrand;
        private DomainUpDown domainSleeves;
        private PictureBox pictureColorAcc2;
        private PictureBox pictureColorAcc3;
        private PictureBox pictureColorAcc4;
        private PictureBox pictureColorAcc1;
        private ComboBox domainAccessory4;
        private ComboBox domainAccessory3;
        private ComboBox domainAccessory2;
        private ComboBox domainAccessory1;
        private Label labelSleeves;
        private Label labelJerseyStyle;
        private Label labelAccesories;
        private Label labelShoes;
        private Label labelShoesColor;
        private Label labelShoesType;
        private GroupBox groupPlayFirTeam;
        private ListView listViewPlayingTeams;
        private ComboBox comboClubTeam;
        private Button buttonCallNationalTeam;
        private Button buttonRemoveNationalTeam;
        private ImageList imageListTeamLogos;
        private Label labelWinter;
        private ComboBox comboWinterAccessories;
        private ToolTip toolTip;
        private FlowLayoutPanel flowPanelSkills;
        private GroupBox groupGenerateAttributes;
        private Label labelRandomize;
        private NumericUpDown numericRandomize;
        private Button buttonRandomAboveAvg;
        private Button buttonRandomBelowAvg;
        private Button buttonRandomSuperstar;
        private Button buttonRandomVeryGood;
        private Button buttonRandomGood;
        private Button buttonRandomAverage;
        private Button buttonRandomPoor;
        private GroupBox groupGoalkeperSkills;
        private Label labelDiving;
        private Label labelPositioning;
        private Label labelReflexes;
        private Label labelHandling;
        private TrackBar trackDiving;
        private TrackBar trackPositioning;
        private TrackBar trackReflexes;
        private TrackBar trackHandling;
        private NumericUpDown numericGoalkeeperSkills;
        private GroupBox groupDefensiveSkills;
        private NumericUpDown numericDefensiveSkills;
        private Label labelAggression;
        private Label labelMarking;
        private Label labelHeading;
        private TrackBar trackHeading;
        private Label labelTackling;
        private TrackBar trackTackling;
        private TrackBar trackMarking;
        private TrackBar trackAggression;
        private GroupBox groupMidfielderSkills;
        private NumericUpDown numericMidfielderSkills;
        private Label labelBallControl;
        private Label labelCrossing;
        private Label labelLongPassing;
        private TrackBar trackLongPassing;
        private Label labelShortPassing;
        private TrackBar trackShortPassing;
        private TrackBar trackBallControl;
        private TrackBar trackCrossing;
        private GroupBox groupAttackingSkills;
        private NumericUpDown numericAttackingSkills;
        private Label labelDribbling;
        private Label labelLongShot;
        private Label labelFreeKick;
        private Label labelShotPower;
        private Label labelFinishing;
        private TrackBar trackFinishing;
        private TrackBar trackShotPower;
        private TrackBar trackLongShot;
        private TrackBar trackFreeKick;
        private TrackBar trackDribbling;
        private GroupBox groupGenericAttributes;
        private Label labelPlayerPositioning;
        private TrackBar trackPlayerPositioning;
        private Label labelPotential;
        private TrackBar trackPotential;
        private NumericUpDown numericPhysicalSkills;
        private Label labelReactions;
        private Label labelStrength;
        private Label labelStamina;
        private TrackBar trackStamina;
        private Label labelSprintSpeed;
        private TrackBar trackSprintSpeed;
        private Label labelAcceleration;
        private TrackBar trackAcceleration;
        private TrackBar trackStrength;
        private TrackBar trackReactions;
        private Label labelGkKick;
        private TrackBar trackGkKicking;
        private Label labelAgility;
        private TrackBar trackAgility;
        private Label labelBalance;
        private TrackBar trackBalance;
        private Label labelJumping;
        private TrackBar trackJumping;
        private Label labelPenalties;
        private TrackBar trackPenalties;
        private Label labelSliding;
        private TrackBar trackSliding;
        private Label labelVision;
        private TrackBar trackVision;
        private Label labelVolley;
        private TrackBar trackVolley;
        private Label labelOverallrating;
        private TrackBar trackOverallrating;
        private GroupBox groupMental;
        private Label labelFreeKickStart;
        private ComboBox comboFreeKickStart;
        private Label labelPenaltyKick;
        private ComboBox comboPenaltyKick;
        private Label labelPenaltyMove;
        private ComboBox comboPenaltyMove;
        private Label labelPenaltyStart;
        private ComboBox comboPenaltyStart;
        private GroupBox groupFreeKick;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private GroupBox groupGenericFace;
        private GroupBox groupHairModel;
        private ComboBox comboHeadband;
        private ComboBox comboAfro;
        private ComboBox comboLong;
        private ComboBox comboMedium;
        private ComboBox comboModern;
        private ComboBox comboShort;
        private ComboBox comboVeryShort;
        private ComboBox comboShaven;
        private RadioButton radioHeadband;
        private RadioButton radioShaven;
        private RadioButton radioAfro;
        private RadioButton radioLong;
        private RadioButton radioMedium;
        private RadioButton radioModern;
        private RadioButton radioShort;
        private RadioButton radioVeryShort;
        private ComboBox domainHairColor;
        private Label labelHairColor;
        private GroupBox groupHeadModel;
        private ComboBox comboLatinModels;
        private RadioButton radioButtonLatin;
        private ComboBox comboAsiaticModels;
        private RadioButton radioButtonAsiatic;
        private ComboBox comboAfricanModels;
        private RadioButton radioButtonAfrican;
        private RadioButton radioButtonCaucasic;
        private ComboBox comboCaucasicModels;
        private Button buttonRandomizeAppearance;
        private ComboBox comboEyescolor;
        private Label label2;
        private ComboBox comboFacialHairColor;
        private Label labelFacialHairColor;
        private Label label1;
        private ComboBox comboSkintype;
        private Label labelSkintype;
        private ComboBox comboSideburns;
        private Label labelSideburns;
        private ComboBox domainFacialHair;
        private Label labelHeadType;
        private Label labelHairType;
        private Label labelFacialHair;
        private GroupBox groupBox1;
        private Label labelPreferredPositions;
        private ComboBox comboPreferredPosition4;
        private ComboBox comboPreferredPosition3;
        private ComboBox comboPreferredPosition2;
        private ComboBox comboPreferredPosition1;
        private DomainUpDown domainInternationalReputation;
        private Label labelInternationalReputation;
        private Viewer3D viewer3D;
        private ToolStrip tool3D;
        private ToolStripButton buttonShow3DModel;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton buttonImport3DHairModel;
        private ToolStripButton buttonExport3DHairModel;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton buttonRemove3DHeadModel;
        private Label labelEyeBow;
        private ComboBox comboEyeBow;
        private CheckBox checkShowTexures;
        private Viewer2D viewer2DEyeTexture;
        private Viewer2D viewer2DPlayerGui;
        private ComboBox comboWeakFoot;
        private Label labelWeakFoot;
        private CheckBox checkHasGenericFace;
        private GroupBox groupGenericFaceType;
        private ToolStripButton buttonImport3DHeadModel;
        private ToolStripButton buttonExport3DHeadModel;
        private NumericUpDown numericMentalSkills;
        private NumericUpDown numericFreeKickSkills;
        private Label labelCurve;
        private TrackBar trackCurve;
        private Label label3;
        private ComboBox comboGkKickStyle;
        private ImageList imageListStars;
        private Label labelSkillMoves;
        private Label labelSkillsStars;
        private NumericUpDown numericSkillMoves;
        private ToolStripButton toolPhoto;
        private ToolStripSeparator toolStripSeparator3;
        public NumericUpDown numericGkGloves;
        private Label labelGkGloves;
        private ToolStripButton buttonSwitchRenderingMode;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton buttonMoveHairAhead;
        private ToolStripButton buttonMoveHairUp;
        private ToolStripButton buttonMoveHairBack;
        private ToolStripButton buttonMoveHairDown;
        private ToolStripButton buttonSaveHair;
        private ToolStripButton buttonRemoveHairModel;
        private ToolStripButton buttonShowJesey;
        private MultiViewer2D multiViewerHair;
        private GroupBox groupTraits;
        private CheckBox checkLongThrower;
        private CheckBox checkGiantThrower;
        private CheckBox checkAvoidsWeakFoot;
        private CheckBox checkInjuryFree;
        private CheckBox checkPowerFreeKick;
        private CheckBox checkSelfish;
        private CheckBox checkPlaymaker;
        private CheckBox checkTechnicaldribbler;
        private CheckBox checkLeadership;
        private CheckBox checkPuncher;
        private CheckBox checkDiver;
        private CheckBox checkDivesintotackles;
        private CheckBox checkLongshottaker;
        private CheckBox checkHighClubIdentification;
        private CheckBox checkPushesupforcorners;
        private CheckBox checkEarlycrosser;
        private CheckBox checkInjuryProne;
        private CheckBox checkBeatsOffsideTrap;
        private CheckBox checkLongPasser;
        private CheckBox checkFlair;
        private CheckBox checkFinesseShot;
        private CheckBox checkArguesWithOfficials;
        private CheckBox checkSwervePasser;
        private CheckBox checkCornerSpecialist;
        private CheckBox checkPowerHeader;
        private CheckBox checkGkLongThrower;
        private CheckBox checkTeamPlayer;
        private DateTimePicker dateJoiningDate;
        private Label label4;
        private Label label5;
        private ComboBox comboGkSaveStyle;
        private NumericUpDown numericUpDown1;
        private Label label6;
        private NumericUpDown numericUpDown2;
        private Label label7;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown4;
        private DomainUpDown domainSocksStyle;
        private Label label8;
        private ComboBox comboAttackWorkRate;
        private Label label9;
        private ComboBox comboDefensiveWorkrate;
        private Label label10;
        private CheckBox checkTrainingPants;
        private GroupBox groupShoes;
        private NumericUpDown numericSkinTone;
        private Viewer2D viewer2DSkinTexture;
        private Label labelSkinColorInfo;
        private Button buttonRgbHair;
        private GroupBox groupIsLoan;
        private CheckBox checkIsLoan;
        private DateTimePicker dateLoanEnd;
        private Label label11;
        private Label label12;
        private ComboBox comboTeamLoanedFrom;
        private BindingSource teamListBindingSource;
        private Label label1ShoesType;
        private PictureBox pictureColorShoes2;
        private PictureBox pictureColorShoes1;
        private CheckBox checkJerseyFit;
        private Label labelInterception;
        private TrackBar trackInterception;
        private ToolStripButton buttonMoveHairLeft;
        private ToolStripButton buttonMoveHairRight;
        private ToolStripButton buttonMakeHairCloser;
        private ToolStripButton buttonMakeHairWider;
        private GroupBox groupBox2;
        private CheckBox checkGKFlatKick;
        private CheckBox checkDrivenPass;
        private CheckBox checkDivingHeader;
        private CheckBox checkBycicleKick;
        private CheckBox checkChipperPenalty;
        private CheckBox checkStutterPenalty;
        private CheckBox checkFancyFlicks;
        private CheckBox checkFancyPasses;
        private CheckBox checkFancyFeet;
        private CheckBox checkGKOneonOne;
        private CheckBox checkAcrobaticClearance;
        private CheckBox checkSecondWind;
        private CheckBox checkCrowdFavourite;
        private CheckBox checkInflexible;
        private MultiViewer2D multiViewerFace;
        public Player m_CurrentPlayer;
        private TabPage m_CurrentPage;
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
            this.components = (IContainer)new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(PlayerForm));
            this.tabEditPlayer = new TabControl();
            this.pageInfo = new TabPage();
            this.flowPanelInfo = new FlowLayoutPanel();
            this.groupPlayerIdentity = new GroupBox();
            this.labelCommonName = new Label();
            this.textCommonName = new TextBox();
            this.playerBindingSource = new BindingSource(this.components);
            this.textJerseyName = new TextBox();
            this.labelJerseyName = new Label();
            this.buttonGetId = new Button();
            this.viewer2DPhoto = new Viewer2D();
            this.numericPlayerId = new NumericUpDown();
            this.buttonRandomizeIdentity = new Button();
            this.dateBirthDate = new DateTimePicker();
            this.labelBirthdate = new Label();
            this.labelPlayerId = new Label();
            this.textSurname = new TextBox();
            this.textFirstName = new TextBox();
            this.comboCountry = new ComboBox();
            this.countryListBindingSource = new BindingSource(this.components);
            this.labelFirstName = new Label();
            this.labelSurame = new Label();
            this.labelCountry = new Label();
            this.groupBoxBody = new GroupBox();
            this.comboWeakFoot = new ComboBox();
            this.labelWeakFoot = new Label();
            this.comboBody = new ComboBox();
            this.numericHeight = new NumericUpDown();
            this.numericWeight = new NumericUpDown();
            this.labelWeight = new Label();
            this.labelBody = new Label();
            this.domainPreferredFoot = new DomainUpDown();
            this.labelHeight = new Label();
            this.labelPreferredFoot = new Label();
            this.groupBoxLook = new GroupBox();
            this.checkJerseyFit = new CheckBox();
            this.checkTrainingPants = new CheckBox();
            this.domainSocksStyle = new DomainUpDown();
            this.label8 = new Label();
            this.numericGkGloves = new NumericUpDown();
            this.labelGkGloves = new Label();
            this.labelWinter = new Label();
            this.comboWinterAccessories = new ComboBox();
            this.domainJerseyStyle = new DomainUpDown();
            this.domainSleeves = new DomainUpDown();
            this.pictureColorAcc2 = new PictureBox();
            this.pictureColorAcc3 = new PictureBox();
            this.pictureColorAcc4 = new PictureBox();
            this.pictureColorAcc1 = new PictureBox();
            this.domainAccessory4 = new ComboBox();
            this.domainAccessory3 = new ComboBox();
            this.domainAccessory2 = new ComboBox();
            this.domainAccessory1 = new ComboBox();
            this.labelSleeves = new Label();
            this.labelJerseyStyle = new Label();
            this.labelAccesories = new Label();
            this.groupPlayFirTeam = new GroupBox();
            this.groupIsLoan = new GroupBox();
            this.comboTeamLoanedFrom = new ComboBox();
            this.teamListBindingSource = new BindingSource(this.components);
            this.label12 = new Label();
            this.dateLoanEnd = new DateTimePicker();
            this.label11 = new Label();
            this.checkIsLoan = new CheckBox();
            this.dateJoiningDate = new DateTimePicker();
            this.label4 = new Label();
            this.listViewPlayingTeams = new ListView();
            this.imageListTeamLogos = new ImageList(this.components);
            this.comboClubTeam = new ComboBox();
            this.buttonCallNationalTeam = new Button();
            this.buttonRemoveNationalTeam = new Button();
            this.groupShoes = new GroupBox();
            this.label1ShoesType = new Label();
            this.pictureColorShoes2 = new PictureBox();
            this.pictureColorShoes1 = new PictureBox();
            this.numericShoesBrand = new NumericUpDown();
            this.labelShoesType = new Label();
            this.labelShoesColor = new Label();
            this.numericShoesDesign = new NumericUpDown();
            this.viewer2DShoes = new Viewer2D();
            this.labelShoes = new Label();
            this.groupBox1 = new GroupBox();
            this.labelPreferredPositions = new Label();
            this.comboPreferredPosition4 = new ComboBox();
            this.comboPreferredPosition3 = new ComboBox();
            this.comboPreferredPosition2 = new ComboBox();
            this.comboPreferredPosition1 = new ComboBox();
            this.domainInternationalReputation = new DomainUpDown();
            this.labelInternationalReputation = new Label();
            this.pageSkills = new TabPage();
            this.flowPanelSkills = new FlowLayoutPanel();
            this.groupGenerateAttributes = new GroupBox();
            this.labelOverallrating = new Label();
            this.trackOverallrating = new TrackBar();
            this.labelRandomize = new Label();
            this.numericRandomize = new NumericUpDown();
            this.buttonRandomAboveAvg = new Button();
            this.buttonRandomBelowAvg = new Button();
            this.buttonRandomSuperstar = new Button();
            this.buttonRandomVeryGood = new Button();
            this.buttonRandomGood = new Button();
            this.buttonRandomAverage = new Button();
            this.buttonRandomPoor = new Button();
            this.groupGoalkeperSkills = new GroupBox();
            this.label5 = new Label();
            this.comboGkSaveStyle = new ComboBox();
            this.label3 = new Label();
            this.labelGkKick = new Label();
            this.comboGkKickStyle = new ComboBox();
            this.trackGkKicking = new TrackBar();
            this.labelDiving = new Label();
            this.labelPositioning = new Label();
            this.labelReflexes = new Label();
            this.labelHandling = new Label();
            this.trackDiving = new TrackBar();
            this.trackPositioning = new TrackBar();
            this.trackReflexes = new TrackBar();
            this.trackHandling = new TrackBar();
            this.numericGoalkeeperSkills = new NumericUpDown();
            this.groupDefensiveSkills = new GroupBox();
            this.labelInterception = new Label();
            this.trackInterception = new TrackBar();
            this.labelSliding = new Label();
            this.trackSliding = new TrackBar();
            this.numericDefensiveSkills = new NumericUpDown();
            this.labelAggression = new Label();
            this.labelMarking = new Label();
            this.labelTackling = new Label();
            this.trackTackling = new TrackBar();
            this.trackMarking = new TrackBar();
            this.trackAggression = new TrackBar();
            this.groupMidfielderSkills = new GroupBox();
            this.labelCurve = new Label();
            this.trackCurve = new TrackBar();
            this.labelVision = new Label();
            this.trackVision = new TrackBar();
            this.numericMidfielderSkills = new NumericUpDown();
            this.labelBallControl = new Label();
            this.labelCrossing = new Label();
            this.labelLongPassing = new Label();
            this.trackLongPassing = new TrackBar();
            this.labelShortPassing = new Label();
            this.trackShortPassing = new TrackBar();
            this.trackBallControl = new TrackBar();
            this.trackCrossing = new TrackBar();
            this.groupMental = new GroupBox();
            this.comboDefensiveWorkrate = new ComboBox();
            this.label10 = new Label();
            this.comboAttackWorkRate = new ComboBox();
            this.label9 = new Label();
            this.numericMentalSkills = new NumericUpDown();
            this.labelPlayerPositioning = new Label();
            this.labelPotential = new Label();
            this.trackPlayerPositioning = new TrackBar();
            this.trackPotential = new TrackBar();
            this.groupAttackingSkills = new GroupBox();
            this.labelFinishing = new Label();
            this.label6 = new Label();
            this.numericUpDown2 = new NumericUpDown();
            this.numericUpDown1 = new NumericUpDown();
            this.labelHeading = new Label();
            this.trackHeading = new TrackBar();
            this.labelVolley = new Label();
            this.trackVolley = new TrackBar();
            this.numericAttackingSkills = new NumericUpDown();
            this.labelDribbling = new Label();
            this.labelLongShot = new Label();
            this.labelShotPower = new Label();
            this.trackFinishing = new TrackBar();
            this.trackShotPower = new TrackBar();
            this.trackLongShot = new TrackBar();
            this.trackDribbling = new TrackBar();
            this.groupGenericAttributes = new GroupBox();
            this.label7 = new Label();
            this.numericUpDown3 = new NumericUpDown();
            this.numericUpDown4 = new NumericUpDown();
            this.labelJumping = new Label();
            this.labelBalance = new Label();
            this.trackBalance = new TrackBar();
            this.labelAgility = new Label();
            this.trackAgility = new TrackBar();
            this.numericPhysicalSkills = new NumericUpDown();
            this.labelReactions = new Label();
            this.labelStrength = new Label();
            this.labelStamina = new Label();
            this.trackStamina = new TrackBar();
            this.labelSprintSpeed = new Label();
            this.trackSprintSpeed = new TrackBar();
            this.labelAcceleration = new Label();
            this.trackAcceleration = new TrackBar();
            this.trackStrength = new TrackBar();
            this.trackReactions = new TrackBar();
            this.trackJumping = new TrackBar();
            this.groupFreeKick = new GroupBox();
            this.labelSkillsStars = new Label();
            this.imageListStars = new ImageList(this.components);
            this.numericSkillMoves = new NumericUpDown();
            this.labelSkillMoves = new Label();
            this.numericFreeKickSkills = new NumericUpDown();
            this.labelPenalties = new Label();
            this.labelFreeKick = new Label();
            this.trackFreeKick = new TrackBar();
            this.trackPenalties = new TrackBar();
            this.labelPenaltyKick = new Label();
            this.comboPenaltyKick = new ComboBox();
            this.labelPenaltyMove = new Label();
            this.comboPenaltyMove = new ComboBox();
            this.labelFreeKickStart = new Label();
            this.labelPenaltyStart = new Label();
            this.comboFreeKickStart = new ComboBox();
            this.comboPenaltyStart = new ComboBox();
            this.groupTraits = new GroupBox();
            this.groupBox2 = new GroupBox();
            this.checkGKFlatKick = new CheckBox();
            this.checkDrivenPass = new CheckBox();
            this.checkDivingHeader = new CheckBox();
            this.checkBycicleKick = new CheckBox();
            this.checkChipperPenalty = new CheckBox();
            this.checkStutterPenalty = new CheckBox();
            this.checkFancyFlicks = new CheckBox();
            this.checkFancyPasses = new CheckBox();
            this.checkFancyFeet = new CheckBox();
            this.checkGKOneonOne = new CheckBox();
            this.checkAcrobaticClearance = new CheckBox();
            this.checkSecondWind = new CheckBox();
            this.checkCrowdFavourite = new CheckBox();
            this.checkInflexible = new CheckBox();
            this.checkTeamPlayer = new CheckBox();
            this.checkSwervePasser = new CheckBox();
            this.checkCornerSpecialist = new CheckBox();
            this.checkPowerHeader = new CheckBox();
            this.checkGkLongThrower = new CheckBox();
            this.checkLongPasser = new CheckBox();
            this.checkFlair = new CheckBox();
            this.checkFinesseShot = new CheckBox();
            this.checkArguesWithOfficials = new CheckBox();
            this.checkBeatsOffsideTrap = new CheckBox();
            this.checkAvoidsWeakFoot = new CheckBox();
            this.checkInjuryFree = new CheckBox();
            this.checkPowerFreeKick = new CheckBox();
            this.checkSelfish = new CheckBox();
            this.checkPlaymaker = new CheckBox();
            this.checkTechnicaldribbler = new CheckBox();
            this.checkLeadership = new CheckBox();
            this.checkPuncher = new CheckBox();
            this.checkDiver = new CheckBox();
            this.checkDivesintotackles = new CheckBox();
            this.checkLongshottaker = new CheckBox();
            this.checkHighClubIdentification = new CheckBox();
            this.checkPushesupforcorners = new CheckBox();
            this.checkEarlycrosser = new CheckBox();
            this.checkInjuryProne = new CheckBox();
            this.checkGiantThrower = new CheckBox();
            this.checkLongThrower = new CheckBox();
            this.pageFace = new TabPage();
            this.splitContainer1 = new SplitContainer();
            this.splitContainer2 = new SplitContainer();
            this.viewer3D = new Viewer3D();
            this.tool3D = new ToolStrip();
            this.buttonShow3DModel = new ToolStripButton();
            this.buttonSwitchRenderingMode = new ToolStripButton();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.buttonImport3DHeadModel = new ToolStripButton();
            this.buttonExport3DHeadModel = new ToolStripButton();
            this.buttonRemove3DHeadModel = new ToolStripButton();
            this.toolStripSeparator4 = new ToolStripSeparator();
            this.buttonImport3DHairModel = new ToolStripButton();
            this.buttonExport3DHairModel = new ToolStripButton();
            this.buttonRemoveHairModel = new ToolStripButton();
            this.toolStripSeparator5 = new ToolStripSeparator();
            this.buttonMoveHairAhead = new ToolStripButton();
            this.buttonMoveHairBack = new ToolStripButton();
            this.buttonMoveHairUp = new ToolStripButton();
            this.buttonMoveHairDown = new ToolStripButton();
            this.buttonMoveHairLeft = new ToolStripButton();
            this.buttonMoveHairRight = new ToolStripButton();
            this.buttonMakeHairCloser = new ToolStripButton();
            this.buttonMakeHairWider = new ToolStripButton();
            this.buttonSaveHair = new ToolStripButton();
            this.toolStripSeparator2 = new ToolStripSeparator();
            this.toolPhoto = new ToolStripButton();
            this.toolStripSeparator3 = new ToolStripSeparator();
            this.buttonShowJesey = new ToolStripButton();
            this.groupGenericFace = new GroupBox();
            this.groupGenericFaceType = new GroupBox();
            this.labelFacialHair = new Label();
            this.labelEyeBow = new Label();
            this.domainFacialHair = new ComboBox();
            this.comboEyeBow = new ComboBox();
            this.labelSideburns = new Label();
            this.comboSideburns = new ComboBox();
            this.labelSkintype = new Label();
            this.comboSkintype = new ComboBox();
            this.comboFacialHairColor = new ComboBox();
            this.labelFacialHairColor = new Label();
            this.labelSkinColorInfo = new Label();
            this.checkHasGenericFace = new CheckBox();
            this.numericSkinTone = new NumericUpDown();
            this.groupHairModel = new GroupBox();
            this.comboHeadband = new ComboBox();
            this.comboAfro = new ComboBox();
            this.comboLong = new ComboBox();
            this.comboMedium = new ComboBox();
            this.comboModern = new ComboBox();
            this.labelHairColor = new Label();
            this.domainHairColor = new ComboBox();
            this.comboShort = new ComboBox();
            this.comboVeryShort = new ComboBox();
            this.comboShaven = new ComboBox();
            this.radioHeadband = new RadioButton();
            this.radioShaven = new RadioButton();
            this.radioAfro = new RadioButton();
            this.radioLong = new RadioButton();
            this.radioMedium = new RadioButton();
            this.radioModern = new RadioButton();
            this.radioShort = new RadioButton();
            this.radioVeryShort = new RadioButton();
            this.groupHeadModel = new GroupBox();
            this.comboLatinModels = new ComboBox();
            this.radioButtonLatin = new RadioButton();
            this.comboAsiaticModels = new ComboBox();
            this.radioButtonAsiatic = new RadioButton();
            this.comboAfricanModels = new ComboBox();
            this.radioButtonAfrican = new RadioButton();
            this.radioButtonCaucasic = new RadioButton();
            this.comboCaucasicModels = new ComboBox();
            this.buttonRandomizeAppearance = new Button();
            this.labelHeadType = new Label();
            this.label1 = new Label();
            this.labelHairType = new Label();
            this.splitContainer3 = new SplitContainer();
            this.multiViewerFace = new MultiViewer2D();
            this.buttonRgbHair = new Button();
            this.viewer2DSkinTexture = new Viewer2D();
            this.multiViewerHair = new MultiViewer2D();
            this.checkShowTexures = new CheckBox();
            this.viewer2DEyeTexture = new Viewer2D();
            this.comboEyescolor = new ComboBox();
            this.label2 = new Label();
            this.viewer2DPlayerGui = new Viewer2D();
            this.imageListTabIcons = new ImageList(this.components);
            this.toolTip = new ToolTip(this.components);
            this.pickUpControl = new PickUpControl();
            this.tabEditPlayer.SuspendLayout();
            this.pageInfo.SuspendLayout();
            this.flowPanelInfo.SuspendLayout();
            this.groupPlayerIdentity.SuspendLayout();
            ((ISupportInitialize)this.playerBindingSource).BeginInit();
            this.numericPlayerId.BeginInit();
            ((ISupportInitialize)this.countryListBindingSource).BeginInit();
            this.groupBoxBody.SuspendLayout();
            this.numericHeight.BeginInit();
            this.numericWeight.BeginInit();
            this.groupBoxLook.SuspendLayout();
            this.numericGkGloves.BeginInit();
            ((ISupportInitialize)this.pictureColorAcc2).BeginInit();
            ((ISupportInitialize)this.pictureColorAcc3).BeginInit();
            ((ISupportInitialize)this.pictureColorAcc4).BeginInit();
            ((ISupportInitialize)this.pictureColorAcc1).BeginInit();
            this.groupPlayFirTeam.SuspendLayout();
            this.groupIsLoan.SuspendLayout();
            ((ISupportInitialize)this.teamListBindingSource).BeginInit();
            this.groupShoes.SuspendLayout();
            ((ISupportInitialize)this.pictureColorShoes2).BeginInit();
            ((ISupportInitialize)this.pictureColorShoes1).BeginInit();
            this.numericShoesBrand.BeginInit();
            this.numericShoesDesign.BeginInit();
            this.groupBox1.SuspendLayout();
            this.pageSkills.SuspendLayout();
            this.flowPanelSkills.SuspendLayout();
            this.groupGenerateAttributes.SuspendLayout();
            this.trackOverallrating.BeginInit();
            this.numericRandomize.BeginInit();
            this.groupGoalkeperSkills.SuspendLayout();
            this.trackGkKicking.BeginInit();
            this.trackDiving.BeginInit();
            this.trackPositioning.BeginInit();
            this.trackReflexes.BeginInit();
            this.trackHandling.BeginInit();
            this.numericGoalkeeperSkills.BeginInit();
            this.groupDefensiveSkills.SuspendLayout();
            this.trackInterception.BeginInit();
            this.trackSliding.BeginInit();
            this.numericDefensiveSkills.BeginInit();
            this.trackTackling.BeginInit();
            this.trackMarking.BeginInit();
            this.trackAggression.BeginInit();
            this.groupMidfielderSkills.SuspendLayout();
            this.trackCurve.BeginInit();
            this.trackVision.BeginInit();
            this.numericMidfielderSkills.BeginInit();
            this.trackLongPassing.BeginInit();
            this.trackShortPassing.BeginInit();
            this.trackBallControl.BeginInit();
            this.trackCrossing.BeginInit();
            this.groupMental.SuspendLayout();
            this.numericMentalSkills.BeginInit();
            this.trackPlayerPositioning.BeginInit();
            this.trackPotential.BeginInit();
            this.groupAttackingSkills.SuspendLayout();
            this.numericUpDown2.BeginInit();
            this.numericUpDown1.BeginInit();
            this.trackHeading.BeginInit();
            this.trackVolley.BeginInit();
            this.numericAttackingSkills.BeginInit();
            this.trackFinishing.BeginInit();
            this.trackShotPower.BeginInit();
            this.trackLongShot.BeginInit();
            this.trackDribbling.BeginInit();
            this.groupGenericAttributes.SuspendLayout();
            this.numericUpDown3.BeginInit();
            this.numericUpDown4.BeginInit();
            this.trackBalance.BeginInit();
            this.trackAgility.BeginInit();
            this.numericPhysicalSkills.BeginInit();
            this.trackStamina.BeginInit();
            this.trackSprintSpeed.BeginInit();
            this.trackAcceleration.BeginInit();
            this.trackStrength.BeginInit();
            this.trackReactions.BeginInit();
            this.trackJumping.BeginInit();
            this.groupFreeKick.SuspendLayout();
            this.numericSkillMoves.BeginInit();
            this.numericFreeKickSkills.BeginInit();
            this.trackFreeKick.BeginInit();
            this.trackPenalties.BeginInit();
            this.groupTraits.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pageFace.SuspendLayout();
            this.splitContainer1.BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tool3D.SuspendLayout();
            this.groupGenericFace.SuspendLayout();
            this.groupGenericFaceType.SuspendLayout();
            this.numericSkinTone.BeginInit();
            this.groupHairModel.SuspendLayout();
            this.groupHeadModel.SuspendLayout();
            this.splitContainer3.BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            this.tabEditPlayer.Controls.Add((Control)this.pageInfo);
            this.tabEditPlayer.Controls.Add((Control)this.pageSkills);
            this.tabEditPlayer.Controls.Add((Control)this.pageFace);
            this.tabEditPlayer.Dock = DockStyle.Fill;
            this.tabEditPlayer.ImageList = this.imageListTabIcons;
            this.tabEditPlayer.Location = new Point(0, 25);
            this.tabEditPlayer.Name = "tabEditPlayer";
            this.tabEditPlayer.SelectedIndex = 0;
            this.tabEditPlayer.Size = new Size(1357, 807);
            this.tabEditPlayer.TabIndex = 1;
            this.tabEditPlayer.SelectedIndexChanged += new EventHandler(this.tabEditPlayer_SelectedIndexChanged);
            this.pageInfo.Controls.Add((Control)this.flowPanelInfo);
            this.pageInfo.ImageIndex = 0;
            this.pageInfo.Location = new Point(4, 23);
            this.pageInfo.Name = "pageInfo";
            this.pageInfo.Padding = new Padding(3);
            this.pageInfo.Size = new Size(1349, 780);
            this.pageInfo.TabIndex = 0;
            this.pageInfo.Text = "Info";
            this.pageInfo.UseVisualStyleBackColor = true;
            this.flowPanelInfo.AutoScroll = true;
            this.flowPanelInfo.Controls.Add((Control)this.groupPlayerIdentity);
            this.flowPanelInfo.Controls.Add((Control)this.groupBoxBody);
            this.flowPanelInfo.Controls.Add((Control)this.groupBoxLook);
            this.flowPanelInfo.Controls.Add((Control)this.groupPlayFirTeam);
            this.flowPanelInfo.Controls.Add((Control)this.groupShoes);
            this.flowPanelInfo.Controls.Add((Control)this.groupBox1);
            this.flowPanelInfo.Dock = DockStyle.Fill;
            this.flowPanelInfo.FlowDirection = FlowDirection.TopDown;
            this.flowPanelInfo.Location = new Point(3, 3);
            this.flowPanelInfo.Name = "flowPanelInfo";
            this.flowPanelInfo.Size = new Size(1343, 774);
            this.flowPanelInfo.TabIndex = 0;
            this.groupPlayerIdentity.Controls.Add((Control)this.labelCommonName);
            this.groupPlayerIdentity.Controls.Add((Control)this.textCommonName);
            this.groupPlayerIdentity.Controls.Add((Control)this.textJerseyName);
            this.groupPlayerIdentity.Controls.Add((Control)this.labelJerseyName);
            this.groupPlayerIdentity.Controls.Add((Control)this.buttonGetId);
            this.groupPlayerIdentity.Controls.Add((Control)this.viewer2DPhoto);
            this.groupPlayerIdentity.Controls.Add((Control)this.numericPlayerId);
            this.groupPlayerIdentity.Controls.Add((Control)this.buttonRandomizeIdentity);
            this.groupPlayerIdentity.Controls.Add((Control)this.dateBirthDate);
            this.groupPlayerIdentity.Controls.Add((Control)this.labelBirthdate);
            this.groupPlayerIdentity.Controls.Add((Control)this.labelPlayerId);
            this.groupPlayerIdentity.Controls.Add((Control)this.textSurname);
            this.groupPlayerIdentity.Controls.Add((Control)this.textFirstName);
            this.groupPlayerIdentity.Controls.Add((Control)this.comboCountry);
            this.groupPlayerIdentity.Controls.Add((Control)this.labelFirstName);
            this.groupPlayerIdentity.Controls.Add((Control)this.labelSurame);
            this.groupPlayerIdentity.Controls.Add((Control)this.labelCountry);
            this.groupPlayerIdentity.Location = new Point(3, 3);
            this.groupPlayerIdentity.Name = "groupPlayerIdentity";
            this.groupPlayerIdentity.Size = new Size(391, 213);
            this.groupPlayerIdentity.TabIndex = 85;
            this.groupPlayerIdentity.TabStop = false;
            this.groupPlayerIdentity.Text = "Identity Card";
            this.labelCommonName.AutoSize = true;
            this.labelCommonName.ImeMode = ImeMode.NoControl;
            this.labelCommonName.Location = new Point(156, 99);
            this.labelCommonName.Name = "labelCommonName";
            this.labelCommonName.Size = new Size(79, 13);
            this.labelCommonName.TabIndex = 161;
            this.labelCommonName.Text = "Common Name";
            this.labelCommonName.TextAlign = ContentAlignment.MiddleLeft;
            this.textCommonName.DataBindings.Add(new Binding("Text", (object)this.playerBindingSource, "commonname", true));
            this.textCommonName.Location = new Point(247, 96);
            this.textCommonName.Name = "textCommonName";
            this.textCommonName.Size = new Size(131, 20);
            this.textCommonName.TabIndex = 2;
            this.textCommonName.TextAlign = HorizontalAlignment.Right;
            this.textCommonName.TextChanged += new EventHandler(this.textCommonName_TextChanged);
            this.playerBindingSource.DataSource = (object)typeof(Player);
            this.textJerseyName.DataBindings.Add(new Binding("Text", (object)this.playerBindingSource, "playerjerseyname", true));
            this.textJerseyName.Location = new Point(247, 122);
            this.textJerseyName.Name = "textJerseyName";
            this.textJerseyName.Size = new Size(131, 20);
            this.textJerseyName.TabIndex = 3;
            this.textJerseyName.TextAlign = HorizontalAlignment.Right;
            this.labelJerseyName.AutoSize = true;
            this.labelJerseyName.ImeMode = ImeMode.NoControl;
            this.labelJerseyName.Location = new Point(156, 125);
            this.labelJerseyName.Name = "labelJerseyName";
            this.labelJerseyName.Size = new Size(37, 13);
            this.labelJerseyName.TabIndex = 159;
            this.labelJerseyName.Text = "Jersey";
            this.labelJerseyName.TextAlign = ContentAlignment.MiddleLeft;
            this.buttonGetId.Image = (Image)resources.GetObject("buttonGetId.Image");
            this.buttonGetId.Location = new Point(354, 19);
            this.buttonGetId.Name = "buttonGetId";
            this.buttonGetId.Size = new Size(24, 20);
            this.buttonGetId.TabIndex = 156;
            this.buttonGetId.TabStop = false;
            this.buttonGetId.UseVisualStyleBackColor = true;
            this.buttonGetId.Click += new EventHandler(this.buttonGetId_Click);
            this.viewer2DPhoto.AutoTransparency = true;
            this.viewer2DPhoto.BackColor = Color.Transparent;
            this.viewer2DPhoto.ButtonStripVisible = false;
            this.viewer2DPhoto.CurrentBitmap = (Bitmap)null;
            this.viewer2DPhoto.ExtendedFormat = false;
            this.viewer2DPhoto.FullSizeButton = false;
            this.viewer2DPhoto.ImageLayout = ImageLayout.None;
            this.viewer2DPhoto.ImageSize = new Size(128, 128);
            this.viewer2DPhoto.ImageSizeMultiplier = Viewer2D.SizeMultiplier.MiniFace;
            this.viewer2DPhoto.Location = new Point(6, 16);
            this.viewer2DPhoto.Name = "viewer2DPhoto";
            this.viewer2DPhoto.RemoveButton = false;
            this.viewer2DPhoto.ShowButton = false;
            this.viewer2DPhoto.ShowButtonChecked = true;
            this.viewer2DPhoto.Size = new Size(128, 153);
            this.viewer2DPhoto.TabIndex = 125;
            this.viewer2DPhoto.TabStop = false;
            this.numericPlayerId.Location = new Point(248, 19);
            this.numericPlayerId.Maximum = new Decimal(new int[4]
            {
        600000,
        0,
        0,
        0
            });
            this.numericPlayerId.Name = "numericPlayerId";
            this.numericPlayerId.Size = new Size(91, 20);
            this.numericPlayerId.TabIndex = 154;
            this.numericPlayerId.TabStop = false;
            this.numericPlayerId.TextAlign = HorizontalAlignment.Center;
            this.numericPlayerId.Value = new Decimal(new int[4]
            {
        200000,
        0,
        0,
        0
            });
            this.numericPlayerId.ValueChanged += new EventHandler(this.numericPlayerId_ValueChanged);
            this.buttonRandomizeIdentity.ImeMode = ImeMode.NoControl;
            this.buttonRandomizeIdentity.Location = new Point(6, 177);
            this.buttonRandomizeIdentity.Name = "buttonRandomizeIdentity";
            this.buttonRandomizeIdentity.Size = new Size(128, 23);
            this.buttonRandomizeIdentity.TabIndex = 124;
            this.buttonRandomizeIdentity.TabStop = false;
            this.buttonRandomizeIdentity.Text = "Randomize";
            this.buttonRandomizeIdentity.UseVisualStyleBackColor = true;
            this.buttonRandomizeIdentity.Click += new EventHandler(this.buttonRandomizeIdentity_Click);
            this.dateBirthDate.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "birthdate", true));
            this.dateBirthDate.Format = DateTimePickerFormat.Short;
            this.dateBirthDate.Location = new Point(247, 153);
            this.dateBirthDate.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dateBirthDate.MinDate = new DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.dateBirthDate.Name = "dateBirthDate";
            this.dateBirthDate.Size = new Size(131, 20);
            this.dateBirthDate.TabIndex = 4;
            this.dateBirthDate.Value = new DateTime(2006, 12, 31, 0, 0, 0, 0);
            this.labelBirthdate.AutoSize = true;
            this.labelBirthdate.ImeMode = ImeMode.NoControl;
            this.labelBirthdate.Location = new Point(156, 156);
            this.labelBirthdate.Name = "labelBirthdate";
            this.labelBirthdate.Size = new Size(49, 13);
            this.labelBirthdate.TabIndex = 4;
            this.labelBirthdate.Text = "Birthdate";
            this.labelBirthdate.TextAlign = ContentAlignment.MiddleLeft;
            this.labelPlayerId.AutoSize = true;
            this.labelPlayerId.BackColor = Color.Transparent;
            this.labelPlayerId.ImeMode = ImeMode.NoControl;
            this.labelPlayerId.Location = new Point(156, 23);
            this.labelPlayerId.Name = "labelPlayerId";
            this.labelPlayerId.Size = new Size(48, 13);
            this.labelPlayerId.TabIndex = 122;
            this.labelPlayerId.Text = "Player Id";
            this.labelPlayerId.TextAlign = ContentAlignment.MiddleLeft;
            this.textSurname.DataBindings.Add(new Binding("Text", (object)this.playerBindingSource, "lastname", true));
            this.textSurname.Location = new Point(247, 70);
            this.textSurname.Name = "textSurname";
            this.textSurname.Size = new Size(131, 20);
            this.textSurname.TabIndex = 1;
            this.textSurname.TextAlign = HorizontalAlignment.Right;
            this.textSurname.TextChanged += new EventHandler(this.textSurname_TextChanged);
            this.textFirstName.DataBindings.Add(new Binding("Text", (object)this.playerBindingSource, "firstname", true));
            this.textFirstName.Location = new Point(248, 44);
            this.textFirstName.Name = "textFirstName";
            this.textFirstName.Size = new Size(131, 20);
            this.textFirstName.TabIndex = 0;
            this.textFirstName.TextAlign = HorizontalAlignment.Right;
            this.textFirstName.TextChanged += new EventHandler(this.textFirstName_TextChanged);
            this.comboCountry.DataBindings.Add(new Binding("SelectedItem", (object)this.playerBindingSource, "Country", true));
            this.comboCountry.DataSource = (object)this.countryListBindingSource;
            this.comboCountry.ItemHeight = 13;
            this.comboCountry.Location = new Point(247, 179);
            this.comboCountry.MaxLength = (int)short.MaxValue;
            this.comboCountry.Name = "comboCountry";
            this.comboCountry.Size = new Size(131, 21);
            this.comboCountry.TabIndex = 5;
            this.countryListBindingSource.DataSource = (object)typeof(CountryList);
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.ImeMode = ImeMode.NoControl;
            this.labelFirstName.Location = new Point(156, 47);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new Size(57, 13);
            this.labelFirstName.TabIndex = 1;
            this.labelFirstName.Text = "First Name";
            this.labelFirstName.TextAlign = ContentAlignment.MiddleLeft;
            this.labelSurame.AutoSize = true;
            this.labelSurame.ImeMode = ImeMode.NoControl;
            this.labelSurame.Location = new Point(156, 73);
            this.labelSurame.Name = "labelSurame";
            this.labelSurame.Size = new Size(58, 13);
            this.labelSurame.TabIndex = 2;
            this.labelSurame.Text = "Last Name";
            this.labelSurame.TextAlign = ContentAlignment.MiddleLeft;
            this.labelCountry.AutoSize = true;
            this.labelCountry.Cursor = Cursors.Hand;
            this.labelCountry.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Underline, GraphicsUnit.Point, (byte)0);
            this.labelCountry.ForeColor = SystemColors.ActiveCaption;
            this.labelCountry.ImeMode = ImeMode.NoControl;
            this.labelCountry.Location = new Point(156, 182);
            this.labelCountry.Name = "labelCountry";
            this.labelCountry.Size = new Size(43, 13);
            this.labelCountry.TabIndex = 5;
            this.labelCountry.Text = "Country";
            this.labelCountry.TextAlign = ContentAlignment.MiddleLeft;
            this.labelCountry.DoubleClick += new EventHandler(this.labelCountry_DoubleClick);
            this.groupBoxBody.Controls.Add((Control)this.comboWeakFoot);
            this.groupBoxBody.Controls.Add((Control)this.labelWeakFoot);
            this.groupBoxBody.Controls.Add((Control)this.comboBody);
            this.groupBoxBody.Controls.Add((Control)this.numericHeight);
            this.groupBoxBody.Controls.Add((Control)this.numericWeight);
            this.groupBoxBody.Controls.Add((Control)this.labelWeight);
            this.groupBoxBody.Controls.Add((Control)this.labelBody);
            this.groupBoxBody.Controls.Add((Control)this.domainPreferredFoot);
            this.groupBoxBody.Controls.Add((Control)this.labelHeight);
            this.groupBoxBody.Controls.Add((Control)this.labelPreferredFoot);
            this.groupBoxBody.Location = new Point(3, 222);
            this.groupBoxBody.Name = "groupBoxBody";
            this.groupBoxBody.Size = new Size(391, 113);
            this.groupBoxBody.TabIndex = 86;
            this.groupBoxBody.TabStop = false;
            this.groupBoxBody.Text = "Body";
            this.comboWeakFoot.DataBindings.Add(new Binding("SelectedIndex", (object)this.playerBindingSource, "weakfootabilitytypecode", true));
            this.comboWeakFoot.FormattingEnabled = true;
            this.comboWeakFoot.Items.AddRange(new object[5]
            {
        (object) "Very Poor",
        (object) "Poor",
        (object) "Medium",
        (object) "Good",
        (object) "Ambidexter"
            });
            this.comboWeakFoot.Location = new Point(247, 76);
            this.comboWeakFoot.Name = "comboWeakFoot";
            this.comboWeakFoot.Size = new Size(103, 21);
            this.comboWeakFoot.TabIndex = 3;
            this.labelWeakFoot.AutoSize = true;
            this.labelWeakFoot.BackColor = Color.Transparent;
            this.labelWeakFoot.ImeMode = ImeMode.NoControl;
            this.labelWeakFoot.Location = new Point(184, 79);
            this.labelWeakFoot.Name = "labelWeakFoot";
            this.labelWeakFoot.Size = new Size(57, 13);
            this.labelWeakFoot.TabIndex = 54;
            this.labelWeakFoot.Text = "Weak foot";
            this.labelWeakFoot.TextAlign = ContentAlignment.MiddleLeft;
            this.comboBody.DataBindings.Add(new Binding("SelectedIndex", (object)this.playerBindingSource, "bodytypecode", true));
            this.comboBody.FormattingEnabled = true;
            this.comboBody.Items.AddRange(new object[12]
            {
        (object) "Average Height and Lean",
        (object) "Average Height ",
        (object) "Average Height and Muscular",
        (object) "Tall and Lean",
        (object) "Tall",
        (object) "Tall and Muscular",
        (object) "Short and Lean",
        (object) "Short ",
        (object) "Short and Muscular",
        (object) "Very Tall and Lean",
        (object) "Very Tall",
        (object) "Very Tall and Muscular"
            });
            this.comboBody.Location = new Point(71, 46);
            this.comboBody.Name = "comboBody";
            this.comboBody.Size = new Size(279, 21);
            this.comboBody.TabIndex = 4;
            this.numericHeight.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "height", true));
            this.numericHeight.Location = new Point(71, 20);
            this.numericHeight.Maximum = new Decimal(new int[4]
            {
        215,
        0,
        0,
        0
            });
            this.numericHeight.Minimum = new Decimal(new int[4]
            {
        150,
        0,
        0,
        0
            });
            this.numericHeight.Name = "numericHeight";
            this.numericHeight.Size = new Size(103, 20);
            this.numericHeight.TabIndex = 0;
            this.numericHeight.TextAlign = HorizontalAlignment.Center;
            this.numericHeight.Value = new Decimal(new int[4]
            {
        150,
        0,
        0,
        0
            });
            this.numericWeight.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "weight", true));
            this.numericWeight.Location = new Point(247, 20);
            this.numericWeight.Maximum = new Decimal(new int[4]
            {
        115,
        0,
        0,
        0
            });
            this.numericWeight.Minimum = new Decimal(new int[4]
            {
        50,
        0,
        0,
        0
            });
            this.numericWeight.Name = "numericWeight";
            this.numericWeight.Size = new Size(103, 20);
            this.numericWeight.TabIndex = 2;
            this.numericWeight.TextAlign = HorizontalAlignment.Center;
            this.numericWeight.Value = new Decimal(new int[4]
            {
        50,
        0,
        0,
        0
            });
            this.labelWeight.AutoSize = true;
            this.labelWeight.BackColor = Color.Transparent;
            this.labelWeight.ImeMode = ImeMode.NoControl;
            this.labelWeight.Location = new Point(184, 23);
            this.labelWeight.Name = "labelWeight";
            this.labelWeight.Size = new Size(41, 13);
            this.labelWeight.TabIndex = 12;
            this.labelWeight.Text = "Weight";
            this.labelWeight.TextAlign = ContentAlignment.MiddleLeft;
            this.labelBody.AutoSize = true;
            this.labelBody.BackColor = Color.Transparent;
            this.labelBody.ImeMode = ImeMode.NoControl;
            this.labelBody.Location = new Point(6, 48);
            this.labelBody.Name = "labelBody";
            this.labelBody.Size = new Size(31, 13);
            this.labelBody.TabIndex = 26;
            this.labelBody.Text = "Body";
            this.labelBody.TextAlign = ContentAlignment.MiddleLeft;
            this.domainPreferredFoot.DataBindings.Add(new Binding("SelectedIndex", (object)this.playerBindingSource, "preferredfoot", true));
            this.domainPreferredFoot.Items.Add((object)"Right");
            this.domainPreferredFoot.Items.Add((object)"Left");
            this.domainPreferredFoot.Location = new Point(71, 77);
            this.domainPreferredFoot.Name = "domainPreferredFoot";
            this.domainPreferredFoot.Size = new Size(103, 20);
            this.domainPreferredFoot.TabIndex = 1;
            this.domainPreferredFoot.TextAlign = HorizontalAlignment.Center;
            this.domainPreferredFoot.Wrap = true;
            this.labelHeight.AutoSize = true;
            this.labelHeight.BackColor = Color.Transparent;
            this.labelHeight.ImeMode = ImeMode.NoControl;
            this.labelHeight.Location = new Point(6, 23);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new Size(38, 13);
            this.labelHeight.TabIndex = 11;
            this.labelHeight.Text = "Height";
            this.labelHeight.TextAlign = ContentAlignment.MiddleLeft;
            this.labelPreferredFoot.AutoSize = true;
            this.labelPreferredFoot.BackColor = Color.Transparent;
            this.labelPreferredFoot.ImeMode = ImeMode.NoControl;
            this.labelPreferredFoot.Location = new Point(6, 79);
            this.labelPreferredFoot.Name = "labelPreferredFoot";
            this.labelPreferredFoot.Size = new Size(49, 13);
            this.labelPreferredFoot.TabIndex = 49;
            this.labelPreferredFoot.Text = "Best foot";
            this.labelPreferredFoot.TextAlign = ContentAlignment.MiddleLeft;
            this.groupBoxLook.Controls.Add((Control)this.checkJerseyFit);
            this.groupBoxLook.Controls.Add((Control)this.checkTrainingPants);
            this.groupBoxLook.Controls.Add((Control)this.domainSocksStyle);
            this.groupBoxLook.Controls.Add((Control)this.label8);
            this.groupBoxLook.Controls.Add((Control)this.numericGkGloves);
            this.groupBoxLook.Controls.Add((Control)this.labelGkGloves);
            this.groupBoxLook.Controls.Add((Control)this.labelWinter);
            this.groupBoxLook.Controls.Add((Control)this.comboWinterAccessories);
            this.groupBoxLook.Controls.Add((Control)this.domainJerseyStyle);
            this.groupBoxLook.Controls.Add((Control)this.domainSleeves);
            this.groupBoxLook.Controls.Add((Control)this.pictureColorAcc2);
            this.groupBoxLook.Controls.Add((Control)this.pictureColorAcc3);
            this.groupBoxLook.Controls.Add((Control)this.pictureColorAcc4);
            this.groupBoxLook.Controls.Add((Control)this.pictureColorAcc1);
            this.groupBoxLook.Controls.Add((Control)this.domainAccessory4);
            this.groupBoxLook.Controls.Add((Control)this.domainAccessory3);
            this.groupBoxLook.Controls.Add((Control)this.domainAccessory2);
            this.groupBoxLook.Controls.Add((Control)this.domainAccessory1);
            this.groupBoxLook.Controls.Add((Control)this.labelSleeves);
            this.groupBoxLook.Controls.Add((Control)this.labelJerseyStyle);
            this.groupBoxLook.Controls.Add((Control)this.labelAccesories);
            this.groupBoxLook.Location = new Point(3, 341);
            this.groupBoxLook.Name = "groupBoxLook";
            this.groupBoxLook.Size = new Size(391, 280);
            this.groupBoxLook.TabIndex = 87;
            this.groupBoxLook.TabStop = false;
            this.groupBoxLook.Text = "Look";
            this.checkJerseyFit.AutoSize = true;
            this.checkJerseyFit.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "jerseyfit", true));
            this.checkJerseyFit.Location = new Point(280, 18);
            this.checkJerseyFit.Name = "checkJerseyFit";
            this.checkJerseyFit.Size = new Size(70, 17);
            this.checkJerseyFit.TabIndex = 99;
            this.checkJerseyFit.Text = "Jersey Fit";
            this.checkJerseyFit.UseVisualStyleBackColor = true;
            this.checkTrainingPants.AutoSize = true;
            this.checkTrainingPants.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "TrainingPants", true));
            this.checkTrainingPants.Location = new Point(238, 131);
            this.checkTrainingPants.Name = "checkTrainingPants";
            this.checkTrainingPants.Size = new Size(112, 17);
            this.checkTrainingPants.TabIndex = 98;
            this.checkTrainingPants.Text = "GK Training Pants";
            this.checkTrainingPants.UseVisualStyleBackColor = true;
            this.domainSocksStyle.DataBindings.Add(new Binding("SelectedIndex", (object)this.playerBindingSource, "socklengthcode", true));
            this.domainSocksStyle.Items.Add((object)"Normal Socks");
            this.domainSocksStyle.Items.Add((object)"Low Socks");
            this.domainSocksStyle.Items.Add((object)"High Socks");
            this.domainSocksStyle.Location = new Point(108, 70);
            this.domainSocksStyle.Name = "domainSocksStyle";
            this.domainSocksStyle.Size = new Size(242, 20);
            this.domainSocksStyle.TabIndex = 68;
            this.domainSocksStyle.TextAlign = HorizontalAlignment.Center;
            this.domainSocksStyle.Wrap = true;
            this.label8.AutoSize = true;
            this.label8.ImeMode = ImeMode.NoControl;
            this.label8.Location = new Point(6, 72);
            this.label8.Name = "label8";
            this.label8.Size = new Size(63, 13);
            this.label8.TabIndex = 69;
            this.label8.Text = "Socks Style";
            this.label8.TextAlign = ContentAlignment.MiddleLeft;
            this.numericGkGloves.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "gkglovetypecode", true));
            this.numericGkGloves.Location = new Point(108, 130);
            this.numericGkGloves.Maximum = new Decimal(new int[4]
            {
        (int) sbyte.MaxValue,
        0,
        0,
        0
            });
            this.numericGkGloves.Name = "numericGkGloves";
            this.numericGkGloves.Size = new Size(106, 20);
            this.numericGkGloves.TabIndex = 8;
            this.numericGkGloves.TextAlign = HorizontalAlignment.Center;
            this.numericGkGloves.Value = new Decimal(new int[4]
            {
        1,
        0,
        0,
        0
            });
            this.labelGkGloves.AutoSize = true;
            this.labelGkGloves.Cursor = Cursors.Hand;
            this.labelGkGloves.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Underline, GraphicsUnit.Point, (byte)0);
            this.labelGkGloves.ForeColor = SystemColors.ActiveCaption;
            this.labelGkGloves.Location = new Point(10, 132);
            this.labelGkGloves.Name = "labelGkGloves";
            this.labelGkGloves.Size = new Size(58, 13);
            this.labelGkGloves.TabIndex = 67;
            this.labelGkGloves.Text = "GK Gloves";
            this.labelGkGloves.DoubleClick += new EventHandler(this.labelGkGloves_DoubleClick);
            this.labelWinter.AutoSize = true;
            this.labelWinter.ImeMode = ImeMode.NoControl;
            this.labelWinter.Location = new Point(6, 101);
            this.labelWinter.Name = "labelWinter";
            this.labelWinter.Size = new Size(98, 13);
            this.labelWinter.TabIndex = 64;
            this.labelWinter.Text = "Winter Accessories";
            this.labelWinter.TextAlign = ContentAlignment.MiddleLeft;
            this.comboWinterAccessories.DataBindings.Add(new Binding("SelectedIndex", (object)this.playerBindingSource, "hasseasonaljersey", true));
            this.comboWinterAccessories.FormattingEnabled = true;
            this.comboWinterAccessories.Items.AddRange(new object[5]
            {
        (object) "None",
        (object) "Long Sleeves no underarmor stuff",
        (object) "Long Sleeves with underarmor neck",
        (object) "Short sleeves with underarmor arms no neck",
        (object) "Short sleeves with underarmor arms and neck"
            });
            this.comboWinterAccessories.Location = new Point(108, 98);
            this.comboWinterAccessories.Name = "comboWinterAccessories";
            this.comboWinterAccessories.Size = new Size(242, 21);
            this.comboWinterAccessories.TabIndex = 2;
            this.domainJerseyStyle.DataBindings.Add(new Binding("SelectedIndex", (object)this.playerBindingSource, "jerseystylecode", true));
            this.domainJerseyStyle.Items.Add((object)"Normal");
            this.domainJerseyStyle.Items.Add((object)"Untucked");
            this.domainJerseyStyle.Location = new Point(108, 17);
            this.domainJerseyStyle.Name = "domainJerseyStyle";
            this.domainJerseyStyle.Size = new Size(164, 20);
            this.domainJerseyStyle.TabIndex = 1;
            this.domainJerseyStyle.TextAlign = HorizontalAlignment.Center;
            this.domainJerseyStyle.Wrap = true;
            this.domainSleeves.DataBindings.Add(new Binding("SelectedIndex", (object)this.playerBindingSource, "jerseysleevelengthcode", true));
            this.domainSleeves.Items.Add((object)"Short Sleeves ");
            this.domainSleeves.Items.Add((object)"Long Sleeves ");
            this.domainSleeves.Items.Add((object)"Long Sleeves with underarmor neck");
            this.domainSleeves.Items.Add((object)"Short sleeves with underarmor arms no neck");
            this.domainSleeves.Items.Add((object)"Short sleeves with underarmor arms and neck");
            this.domainSleeves.Location = new Point(108, 43);
            this.domainSleeves.Name = "domainSleeves";
            this.domainSleeves.Size = new Size(242, 20);
            this.domainSleeves.TabIndex = 0;
            this.domainSleeves.TextAlign = HorizontalAlignment.Center;
            this.domainSleeves.Wrap = true;
            this.pictureColorAcc2.BorderStyle = BorderStyle.FixedSingle;
            this.pictureColorAcc2.Cursor = Cursors.Hand;
            this.pictureColorAcc2.ImeMode = ImeMode.NoControl;
            this.pictureColorAcc2.Location = new Point(223, 201);
            this.pictureColorAcc2.Name = "pictureColorAcc2";
            this.pictureColorAcc2.Size = new Size(20, 20);
            this.pictureColorAcc2.TabIndex = 55;
            this.pictureColorAcc2.TabStop = false;
            this.pictureColorAcc2.Click += new EventHandler(this.pictureColorAcc2_Click);
            this.pictureColorAcc3.BorderStyle = BorderStyle.FixedSingle;
            this.pictureColorAcc3.Cursor = Cursors.Hand;
            this.pictureColorAcc3.ImeMode = ImeMode.NoControl;
            this.pictureColorAcc3.Location = new Point(223, 227);
            this.pictureColorAcc3.Name = "pictureColorAcc3";
            this.pictureColorAcc3.Size = new Size(20, 20);
            this.pictureColorAcc3.TabIndex = 56;
            this.pictureColorAcc3.TabStop = false;
            this.pictureColorAcc3.Click += new EventHandler(this.pictureColorAcc3_Click);
            this.pictureColorAcc4.BorderStyle = BorderStyle.FixedSingle;
            this.pictureColorAcc4.Cursor = Cursors.Hand;
            this.pictureColorAcc4.ImeMode = ImeMode.NoControl;
            this.pictureColorAcc4.Location = new Point(223, 253);
            this.pictureColorAcc4.Name = "pictureColorAcc4";
            this.pictureColorAcc4.Size = new Size(20, 20);
            this.pictureColorAcc4.TabIndex = 57;
            this.pictureColorAcc4.TabStop = false;
            this.pictureColorAcc4.Click += new EventHandler(this.pictureColorAcc4_Click);
            this.pictureColorAcc1.BorderStyle = BorderStyle.FixedSingle;
            this.pictureColorAcc1.Cursor = Cursors.Hand;
            this.pictureColorAcc1.ImeMode = ImeMode.NoControl;
            this.pictureColorAcc1.Location = new Point(223, 174);
            this.pictureColorAcc1.Name = "pictureColorAcc1";
            this.pictureColorAcc1.Size = new Size(20, 20);
            this.pictureColorAcc1.TabIndex = 45;
            this.pictureColorAcc1.TabStop = false;
            this.pictureColorAcc1.Click += new EventHandler(this.pictureColorAcc1_Click);
            this.domainAccessory4.DataBindings.Add(new Binding("SelectedIndex", (object)this.playerBindingSource, "accessorycode4", true));
            this.domainAccessory4.Items.AddRange(new object[28]
            {
        (object) "None",
        (object) "1 Unused",
        (object) "2 Hearphone",
        (object) "3 Unused",
        (object) "4 Left watch",
        (object) "5 Right watch",
        (object) "6 Left hand tape",
        (object) "7 Right hand tape",
        (object) "8 Left wristle tape",
        (object) "9 Right wristle tape",
        (object) "10 Left knee tape",
        (object) "11 Right knee tape",
        (object) "12 Left knee tutor",
        (object) "13 Right knee tutor",
        (object) "14 Left ankle tape",
        (object) "15 Right ankle tape",
        (object) "16 Gloves",
        (object) "17 Gloves",
        (object) "18 Unused",
        (object) "19 Unused",
        (object) "20 Unused",
        (object) "21 Unused",
        (object) "22 Left finger tape",
        (object) "23 Right finger tape",
        (object) "24 Left wide wristle tape",
        (object) "25 Right wide wristle tape",
        (object) "26 Left bracelet",
        (object) "27 Right bracelet"
            });
            this.domainAccessory4.Location = new Point(12, 252);
            this.domainAccessory4.Name = "domainAccessory4";
            this.domainAccessory4.Size = new Size(197, 21);
            this.domainAccessory4.TabIndex = 7;
            this.domainAccessory3.DataBindings.Add(new Binding("SelectedIndex", (object)this.playerBindingSource, "accessorycode3", true));
            this.domainAccessory3.Items.AddRange(new object[28]
            {
        (object) "None",
        (object) "1 Unused",
        (object) "2 Hearphone",
        (object) "3 Unused",
        (object) "4 Left watch",
        (object) "5 Right watch",
        (object) "6 Left hand tape",
        (object) "7 Right hand tape",
        (object) "8 Left wristle tape",
        (object) "9 Right wristle tape",
        (object) "10 Left knee tape",
        (object) "11 Right knee tape",
        (object) "12 Left knee tutor",
        (object) "13 Right knee tutor",
        (object) "14 Left ankle tape",
        (object) "15 Right ankle tape",
        (object) "16 Gloves",
        (object) "17 Gloves",
        (object) "18 Unused",
        (object) "19 Unused",
        (object) "20 Unused",
        (object) "21 Unused",
        (object) "22 Left finger tape",
        (object) "23 Right finger tape",
        (object) "24 Left wide wristle tape",
        (object) "25 Right wide wristle tape",
        (object) "26 Left bracelet",
        (object) "27 Right bracelet"
            });
            this.domainAccessory3.Location = new Point(12, 226);
            this.domainAccessory3.Name = "domainAccessory3";
            this.domainAccessory3.Size = new Size(197, 21);
            this.domainAccessory3.TabIndex = 6;
            this.domainAccessory2.DataBindings.Add(new Binding("SelectedIndex", (object)this.playerBindingSource, "accessorycode2", true));
            this.domainAccessory2.Items.AddRange(new object[28]
            {
        (object) "None",
        (object) "1 Unused",
        (object) "2 Hearphone",
        (object) "3 Unused",
        (object) "4 Left watch",
        (object) "5 Right watch",
        (object) "6 Left hand tape",
        (object) "7 Right hand tape",
        (object) "8 Left wristle tape",
        (object) "9 Right wristle tape",
        (object) "10 Left knee tape",
        (object) "11 Right knee tape",
        (object) "12 Left knee tutor",
        (object) "13 Right knee tutor",
        (object) "14 Left ankle tape",
        (object) "15 Right ankle tape",
        (object) "16 Gloves",
        (object) "17 Gloves",
        (object) "18 Unused",
        (object) "19 Unused",
        (object) "20 Unused",
        (object) "21 Unused",
        (object) "22 Left finger tape",
        (object) "23 Right finger tape",
        (object) "24 Left wide wristle tape",
        (object) "25 Right wide wristle tape",
        (object) "26 Left bracelet",
        (object) "27 Right bracelet"
            });
            this.domainAccessory2.Location = new Point(12, 200);
            this.domainAccessory2.Name = "domainAccessory2";
            this.domainAccessory2.Size = new Size(197, 21);
            this.domainAccessory2.TabIndex = 5;
            this.domainAccessory1.DataBindings.Add(new Binding("SelectedIndex", (object)this.playerBindingSource, "accessorycode1", true));
            this.domainAccessory1.Items.AddRange(new object[28]
            {
        (object) "None",
        (object) "1 Unused",
        (object) "2 Hearphone",
        (object) "3 Unused",
        (object) "4 Left watch",
        (object) "5 Right watch",
        (object) "6 Left hand tape",
        (object) "7 Right hand tape",
        (object) "8 Left wristle tape",
        (object) "9 Right wristle tape",
        (object) "10 Left knee tape",
        (object) "11 Right knee tape",
        (object) "12 Left knee tutor",
        (object) "13 Right knee tutor",
        (object) "14 Left ankle tape",
        (object) "15 Right ankle tape",
        (object) "16 Gloves",
        (object) "17 Gloves",
        (object) "18 Unused",
        (object) "19 Unused",
        (object) "20 Unused",
        (object) "21 Unused",
        (object) "22 Left finger tape",
        (object) "23 Right finger tape",
        (object) "24 Left wide wristle tape",
        (object) "25 Right wide wristle tape",
        (object) "26 Left bracelet",
        (object) "27 Right bracelet"
            });
            this.domainAccessory1.Location = new Point(12, 173);
            this.domainAccessory1.Name = "domainAccessory1";
            this.domainAccessory1.Size = new Size(197, 21);
            this.domainAccessory1.TabIndex = 4;
            this.labelSleeves.AutoSize = true;
            this.labelSleeves.BackColor = Color.Transparent;
            this.labelSleeves.ImeMode = ImeMode.NoControl;
            this.labelSleeves.Location = new Point(5, 44);
            this.labelSleeves.Name = "labelSleeves";
            this.labelSleeves.Size = new Size(81, 13);
            this.labelSleeves.TabIndex = 35;
            this.labelSleeves.Text = "Sleeves Length";
            this.labelSleeves.TextAlign = ContentAlignment.MiddleLeft;
            this.labelJerseyStyle.AutoSize = true;
            this.labelJerseyStyle.ImeMode = ImeMode.NoControl;
            this.labelJerseyStyle.Location = new Point(5, 19);
            this.labelJerseyStyle.Name = "labelJerseyStyle";
            this.labelJerseyStyle.Size = new Size(63, 13);
            this.labelJerseyStyle.TabIndex = 37;
            this.labelJerseyStyle.Text = "Jersey Style";
            this.labelJerseyStyle.TextAlign = ContentAlignment.MiddleLeft;
            this.labelAccesories.ImeMode = ImeMode.NoControl;
            this.labelAccesories.Location = new Point(42, 154);
            this.labelAccesories.Name = "labelAccesories";
            this.labelAccesories.Size = new Size(136, 20);
            this.labelAccesories.TabIndex = 39;
            this.labelAccesories.Text = "Accesories";
            this.labelAccesories.TextAlign = ContentAlignment.TopCenter;
            this.groupPlayFirTeam.Controls.Add((Control)this.groupIsLoan);
            this.groupPlayFirTeam.Controls.Add((Control)this.checkIsLoan);
            this.groupPlayFirTeam.Controls.Add((Control)this.dateJoiningDate);
            this.groupPlayFirTeam.Controls.Add((Control)this.label4);
            this.groupPlayFirTeam.Controls.Add((Control)this.listViewPlayingTeams);
            this.groupPlayFirTeam.Controls.Add((Control)this.comboClubTeam);
            this.groupPlayFirTeam.Controls.Add((Control)this.buttonCallNationalTeam);
            this.groupPlayFirTeam.Controls.Add((Control)this.buttonRemoveNationalTeam);
            this.groupPlayFirTeam.Location = new Point(400, 3);
            this.groupPlayFirTeam.Name = "groupPlayFirTeam";
            this.groupPlayFirTeam.Size = new Size(243, 213);
            this.groupPlayFirTeam.TabIndex = 88;
            this.groupPlayFirTeam.TabStop = false;
            this.groupPlayFirTeam.Text = "Playing for";
            this.groupIsLoan.Controls.Add((Control)this.comboTeamLoanedFrom);
            this.groupIsLoan.Controls.Add((Control)this.label12);
            this.groupIsLoan.Controls.Add((Control)this.dateLoanEnd);
            this.groupIsLoan.Controls.Add((Control)this.label11);
            this.groupIsLoan.Location = new Point(6, 144);
            this.groupIsLoan.Name = "groupIsLoan";
            this.groupIsLoan.Size = new Size(231, 63);
            this.groupIsLoan.TabIndex = 139;
            this.groupIsLoan.TabStop = false;
            this.groupIsLoan.Visible = false;
            this.comboTeamLoanedFrom.DataBindings.Add(new Binding("SelectedItem", (object)this.playerBindingSource, "TeamLoanedFrom", true));
            this.comboTeamLoanedFrom.DataSource = (object)this.teamListBindingSource;
            this.comboTeamLoanedFrom.ItemHeight = 13;
            this.comboTeamLoanedFrom.Location = new Point(89, 40);
            this.comboTeamLoanedFrom.MaxLength = (int)short.MaxValue;
            this.comboTeamLoanedFrom.Name = "comboTeamLoanedFrom";
            this.comboTeamLoanedFrom.Size = new Size(131, 21);
            this.comboTeamLoanedFrom.TabIndex = 141;
            this.comboTeamLoanedFrom.SelectedIndexChanged += new EventHandler(this.comboTeamLoanedFrom_SelectedIndexChanged);
            this.teamListBindingSource.DataSource = (object)typeof(TeamList);
            this.label12.AutoSize = true;
            this.label12.ImeMode = ImeMode.NoControl;
            this.label12.Location = new Point(7, 43);
            this.label12.Name = "label12";
            this.label12.Size = new Size(69, 13);
            this.label12.TabIndex = 140;
            this.label12.Text = "Loaned From";
            this.label12.TextAlign = ContentAlignment.MiddleLeft;
            this.dateLoanEnd.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "loandateend", true));
            this.dateLoanEnd.Format = DateTimePickerFormat.Short;
            this.dateLoanEnd.Location = new Point(89, 14);
            this.dateLoanEnd.MaxDate = new DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.dateLoanEnd.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateLoanEnd.Name = "dateLoanEnd";
            this.dateLoanEnd.Size = new Size(131, 20);
            this.dateLoanEnd.TabIndex = 139;
            this.dateLoanEnd.Value = new DateTime(2014, 6, 30, 0, 0, 0, 0);
            this.label11.AutoSize = true;
            this.label11.ImeMode = ImeMode.NoControl;
            this.label11.Location = new Point(6, 18);
            this.label11.Name = "label11";
            this.label11.Size = new Size(79, 13);
            this.label11.TabIndex = 138;
            this.label11.Text = "Loan End Date";
            this.label11.TextAlign = ContentAlignment.MiddleLeft;
            this.checkIsLoan.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "IsLoaned", true));
            this.checkIsLoan.Location = new Point(6, 125);
            this.checkIsLoan.Name = "checkIsLoan";
            this.checkIsLoan.RightToLeft = RightToLeft.Yes;
            this.checkIsLoan.Size = new Size(104, 17);
            this.checkIsLoan.TabIndex = 138;
            this.checkIsLoan.Text = "Is Loaned ";
            this.checkIsLoan.TextAlign = ContentAlignment.MiddleRight;
            this.checkIsLoan.UseVisualStyleBackColor = true;
            this.checkIsLoan.CheckedChanged += new EventHandler(this.checkIsLoan_CheckedChanged);
            this.dateJoiningDate.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "joindate", true));
            this.dateJoiningDate.Format = DateTimePickerFormat.Short;
            this.dateJoiningDate.Location = new Point(95, 99);
            this.dateJoiningDate.MaxDate = new DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.dateJoiningDate.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateJoiningDate.Name = "dateJoiningDate";
            this.dateJoiningDate.Size = new Size(131, 20);
            this.dateJoiningDate.TabIndex = 137;
            this.dateJoiningDate.Value = new DateTime(2013, 7, 1, 0, 0, 0, 0);
            this.label4.AutoSize = true;
            this.label4.ImeMode = ImeMode.NoControl;
            this.label4.Location = new Point(5, 103);
            this.label4.Name = "label4";
            this.label4.Size = new Size(66, 13);
            this.label4.TabIndex = 136;
            this.label4.Text = "Joining Date";
            this.label4.TextAlign = ContentAlignment.MiddleLeft;
            this.listViewPlayingTeams.Cursor = Cursors.Hand;
            this.listViewPlayingTeams.FullRowSelect = true;
            this.listViewPlayingTeams.GridLines = true;
            this.listViewPlayingTeams.HideSelection = false;
            this.listViewPlayingTeams.LargeImageList = this.imageListTeamLogos;
            this.listViewPlayingTeams.Location = new Point(6, 19);
            this.listViewPlayingTeams.MultiSelect = false;
            this.listViewPlayingTeams.Name = "listViewPlayingTeams";
            this.listViewPlayingTeams.Size = new Size(231, 71);
            this.listViewPlayingTeams.TabIndex = 135;
            this.listViewPlayingTeams.TabStop = false;
            this.listViewPlayingTeams.UseCompatibleStateImageBehavior = false;
            this.listViewPlayingTeams.DoubleClick += new EventHandler(this.listViewPlayingTeams_DoubleClick);
            this.imageListTeamLogos.ColorDepth = ColorDepth.Depth8Bit;
            this.imageListTeamLogos.ImageSize = new Size(32, 32);
            this.imageListTeamLogos.TransparentColor = Color.Transparent;
            this.comboClubTeam.ItemHeight = 13;
            this.comboClubTeam.Location = new Point(10, 334);
            this.comboClubTeam.MaxLength = (int)short.MaxValue;
            this.comboClubTeam.Name = "comboClubTeam";
            this.comboClubTeam.Size = new Size(100, 21);
            this.comboClubTeam.Sorted = true;
            this.comboClubTeam.TabIndex = 0;
            this.comboClubTeam.Visible = false;
            this.buttonCallNationalTeam.Enabled = false;
            this.buttonCallNationalTeam.ImeMode = ImeMode.NoControl;
            this.buttonCallNationalTeam.Location = new Point(130, 334);
            this.buttonCallNationalTeam.Name = "buttonCallNationalTeam";
            this.buttonCallNationalTeam.Size = new Size(50, 20);
            this.buttonCallNationalTeam.TabIndex = 1;
            this.buttonCallNationalTeam.Text = "Call";
            this.buttonCallNationalTeam.Visible = false;
            this.buttonRemoveNationalTeam.Enabled = false;
            this.buttonRemoveNationalTeam.ImeMode = ImeMode.NoControl;
            this.buttonRemoveNationalTeam.Location = new Point(180, 334);
            this.buttonRemoveNationalTeam.Name = "buttonRemoveNationalTeam";
            this.buttonRemoveNationalTeam.Size = new Size(50, 20);
            this.buttonRemoveNationalTeam.TabIndex = 2;
            this.buttonRemoveNationalTeam.Text = "Remove";
            this.buttonRemoveNationalTeam.Visible = false;
            this.groupShoes.Controls.Add((Control)this.label1ShoesType);
            this.groupShoes.Controls.Add((Control)this.pictureColorShoes2);
            this.groupShoes.Controls.Add((Control)this.pictureColorShoes1);
            this.groupShoes.Controls.Add((Control)this.numericShoesBrand);
            this.groupShoes.Controls.Add((Control)this.labelShoesType);
            this.groupShoes.Controls.Add((Control)this.labelShoesColor);
            this.groupShoes.Controls.Add((Control)this.numericShoesDesign);
            this.groupShoes.Controls.Add((Control)this.viewer2DShoes);
            this.groupShoes.Controls.Add((Control)this.labelShoes);
            this.groupShoes.Location = new Point(400, 222);
            this.groupShoes.Name = "groupShoes";
            this.groupShoes.Size = new Size(243, 178);
            this.groupShoes.TabIndex = 90;
            this.groupShoes.TabStop = false;
            this.groupShoes.Text = "Shoes";
            this.label1ShoesType.AutoSize = true;
            this.label1ShoesType.ImeMode = ImeMode.NoControl;
            this.label1ShoesType.Location = new Point(29, 66);
            this.label1ShoesType.Name = "label1ShoesType";
            this.label1ShoesType.Size = new Size(40, 13);
            this.label1ShoesType.TabIndex = 64;
            this.label1ShoesType.Text = "Design";
            this.label1ShoesType.TextAlign = ContentAlignment.MiddleLeft;
            this.pictureColorShoes2.BorderStyle = BorderStyle.FixedSingle;
            this.pictureColorShoes2.Cursor = Cursors.Hand;
            this.pictureColorShoes2.ImeMode = ImeMode.NoControl;
            this.pictureColorShoes2.Location = new Point(72, 131);
            this.pictureColorShoes2.Name = "pictureColorShoes2";
            this.pictureColorShoes2.Size = new Size(20, 20);
            this.pictureColorShoes2.TabIndex = 63;
            this.pictureColorShoes2.TabStop = false;
            this.pictureColorShoes2.Click += new EventHandler(this.pictureColorShoes2_Click);
            this.pictureColorShoes1.BorderStyle = BorderStyle.FixedSingle;
            this.pictureColorShoes1.Cursor = Cursors.Hand;
            this.pictureColorShoes1.ImeMode = ImeMode.NoControl;
            this.pictureColorShoes1.Location = new Point(12, 131);
            this.pictureColorShoes1.Name = "pictureColorShoes1";
            this.pictureColorShoes1.Size = new Size(20, 20);
            this.pictureColorShoes1.TabIndex = 62;
            this.pictureColorShoes1.TabStop = false;
            this.pictureColorShoes1.Click += new EventHandler(this.pictureColorShoes1_Click);
            this.numericShoesBrand.Location = new Point(12, 36);
            this.numericShoesBrand.Maximum = new Decimal(new int[4]
            {
        (int) byte.MaxValue,
        0,
        0,
        0
            });
            this.numericShoesBrand.Name = "numericShoesBrand";
            this.numericShoesBrand.Size = new Size(80, 20);
            this.numericShoesBrand.TabIndex = 9;
            this.numericShoesBrand.TextAlign = HorizontalAlignment.Center;
            this.numericShoesBrand.Value = new Decimal(new int[4]
            {
        1,
        0,
        0,
        0
            });
            this.numericShoesBrand.ValueChanged += new EventHandler(this.numericShoesBrand_ValueChanged);
            this.labelShoesType.AutoSize = true;
            this.labelShoesType.ImeMode = ImeMode.NoControl;
            this.labelShoesType.Location = new Point(31, 18);
            this.labelShoesType.Name = "labelShoesType";
            this.labelShoesType.Size = new Size(35, 13);
            this.labelShoesType.TabIndex = 60;
            this.labelShoesType.Text = "Brand";
            this.labelShoesType.TextAlign = ContentAlignment.MiddleLeft;
            this.labelShoesColor.AutoSize = true;
            this.labelShoesColor.ImeMode = ImeMode.NoControl;
            this.labelShoesColor.Location = new Point(33, 113);
            this.labelShoesColor.Name = "labelShoesColor";
            this.labelShoesColor.Size = new Size(36, 13);
            this.labelShoesColor.TabIndex = 61;
            this.labelShoesColor.Text = "Colors";
            this.labelShoesColor.TextAlign = ContentAlignment.MiddleLeft;
            this.numericShoesDesign.Location = new Point(12, 82);
            this.numericShoesDesign.Maximum = new Decimal(new int[4]
            {
        3,
        0,
        0,
        0
            });
            this.numericShoesDesign.Name = "numericShoesDesign";
            this.numericShoesDesign.Size = new Size(80, 20);
            this.numericShoesDesign.TabIndex = 10;
            this.numericShoesDesign.TextAlign = HorizontalAlignment.Center;
            this.numericShoesDesign.Value = new Decimal(new int[4]
            {
        1,
        0,
        0,
        0
            });
            this.numericShoesDesign.ValueChanged += new EventHandler(this.numericShoesDesign_ValueChanged);
            this.viewer2DShoes.AutoTransparency = false;
            this.viewer2DShoes.BackColor = Color.Transparent;
            this.viewer2DShoes.ButtonStripVisible = false;
            this.viewer2DShoes.CurrentBitmap = (Bitmap)null;
            this.viewer2DShoes.ExtendedFormat = false;
            this.viewer2DShoes.FullSizeButton = false;
            this.viewer2DShoes.ImageLayout = ImageLayout.Stretch;
            this.viewer2DShoes.ImageSize = new Size(128, 128);
            this.viewer2DShoes.ImageSizeMultiplier = Viewer2D.SizeMultiplier.Double;
            this.viewer2DShoes.Location = new Point(107, 37);
            this.viewer2DShoes.Name = "viewer2DShoes";
            this.viewer2DShoes.RemoveButton = false;
            this.viewer2DShoes.ShowButton = false;
            this.viewer2DShoes.ShowButtonChecked = true;
            this.viewer2DShoes.Size = new Size(128, 128);
            this.viewer2DShoes.TabIndex = 59;
            this.labelShoes.Cursor = Cursors.Hand;
            this.labelShoes.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Underline, GraphicsUnit.Point, (byte)0);
            this.labelShoes.ForeColor = SystemColors.ActiveCaption;
            this.labelShoes.ImeMode = ImeMode.NoControl;
            this.labelShoes.Location = new Point(106, 14);
            this.labelShoes.Name = "labelShoes";
            this.labelShoes.Size = new Size(131, 20);
            this.labelShoes.TabIndex = 47;
            this.labelShoes.Text = "Shoes";
            this.labelShoes.TextAlign = ContentAlignment.MiddleCenter;
            this.labelShoes.DoubleClick += new EventHandler(this.labelShoes_DoubleClick);
            this.groupBox1.Controls.Add((Control)this.labelPreferredPositions);
            this.groupBox1.Controls.Add((Control)this.comboPreferredPosition4);
            this.groupBox1.Controls.Add((Control)this.comboPreferredPosition3);
            this.groupBox1.Controls.Add((Control)this.comboPreferredPosition2);
            this.groupBox1.Controls.Add((Control)this.comboPreferredPosition1);
            this.groupBox1.Controls.Add((Control)this.domainInternationalReputation);
            this.groupBox1.Controls.Add((Control)this.labelInternationalReputation);
            this.groupBox1.Location = new Point(400, 406);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(243, 215);
            this.groupBox1.TabIndex = 89;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Playing Info";
            this.labelPreferredPositions.AutoSize = true;
            this.labelPreferredPositions.ImeMode = ImeMode.NoControl;
            this.labelPreferredPositions.Location = new Point(66, 12);
            this.labelPreferredPositions.Name = "labelPreferredPositions";
            this.labelPreferredPositions.Size = new Size(95, 13);
            this.labelPreferredPositions.TabIndex = 157;
            this.labelPreferredPositions.Text = "Preferred Positions";
            this.labelPreferredPositions.TextAlign = ContentAlignment.MiddleLeft;
            this.comboPreferredPosition4.FormattingEnabled = true;
            this.comboPreferredPosition4.Items.AddRange(new object[29]
            {
        (object) "None",
        (object) "Goalkeeper",
        (object) "Sweeper",
        (object) "Right Wing Back",
        (object) "Right Back",
        (object) "Right Central Back",
        (object) "Central Back",
        (object) "Left Central Back",
        (object) "Left Back",
        (object) "Left Wing Back",
        (object) "Right Defensive Midfielder",
        (object) "Central Defensive Midfielder",
        (object) "Left Defensive Midfielder",
        (object) "Right Midfielder",
        (object) "Right Central Midfielder",
        (object) "Central Midfielder",
        (object) "Left Central Midfielder",
        (object) "Left Midfielder",
        (object) "Right Advanced Midfielder",
        (object) "Central Advanced Midfielder",
        (object) "Left Advanced Midfielder",
        (object) "Right Forward",
        (object) "Central Forward",
        (object) "Left Forward",
        (object) "Right Wing",
        (object) "Right Striker",
        (object) "Central Striker",
        (object) "Left Striker",
        (object) "Left Wing"
            });
            this.comboPreferredPosition4.Location = new Point(18, 121);
            this.comboPreferredPosition4.Name = "comboPreferredPosition4";
            this.comboPreferredPosition4.Size = new Size(208, 21);
            this.comboPreferredPosition4.TabIndex = 3;
            this.comboPreferredPosition4.SelectedIndexChanged += new EventHandler(this.comboPreferredPosition4_SelectedIndexChanged);
            this.comboPreferredPosition3.FormattingEnabled = true;
            this.comboPreferredPosition3.Items.AddRange(new object[29]
            {
        (object) "None",
        (object) "Goalkeeper",
        (object) "Sweeper",
        (object) "Right Wing Back",
        (object) "Right Back",
        (object) "Right Central Back",
        (object) "Central Back",
        (object) "Left Central Back",
        (object) "Left Back",
        (object) "Left Wing Back",
        (object) "Right Defensive Midfielder",
        (object) "Central Defensive Midfielder",
        (object) "Left Defensive Midfielder",
        (object) "Right Midfielder",
        (object) "Right Central Midfielder",
        (object) "Central Midfielder",
        (object) "Left Central Midfielder",
        (object) "Left Midfielder",
        (object) "Right Advanced Midfielder",
        (object) "Central Advanced Midfielder",
        (object) "Left Advanced Midfielder",
        (object) "Right Forward",
        (object) "Central Forward",
        (object) "Left Forward",
        (object) "Right Wing",
        (object) "Right Striker",
        (object) "Central Striker",
        (object) "Left Striker",
        (object) "Left Wing"
            });
            this.comboPreferredPosition3.Location = new Point(17, 94);
            this.comboPreferredPosition3.Name = "comboPreferredPosition3";
            this.comboPreferredPosition3.Size = new Size(208, 21);
            this.comboPreferredPosition3.TabIndex = 2;
            this.comboPreferredPosition3.SelectedIndexChanged += new EventHandler(this.comboPreferredPosition3_SelectedIndexChanged);
            this.comboPreferredPosition2.FormattingEnabled = true;
            this.comboPreferredPosition2.Items.AddRange(new object[29]
            {
        (object) "None",
        (object) "Goalkeeper",
        (object) "Sweeper",
        (object) "Right Wing Back",
        (object) "Right Back",
        (object) "Right Central Back",
        (object) "Central Back",
        (object) "Left Central Back",
        (object) "Left Back",
        (object) "Left Wing Back",
        (object) "Right Defensive Midfielder",
        (object) "Central Defensive Midfielder",
        (object) "Left Defensive Midfielder",
        (object) "Right Midfielder",
        (object) "Right Central Midfielder",
        (object) "Central Midfielder",
        (object) "Left Central Midfielder",
        (object) "Left Midfielder",
        (object) "Right Advanced Midfielder",
        (object) "Central Advanced Midfielder",
        (object) "Left Advanced Midfielder",
        (object) "Right Forward",
        (object) "Central Forward",
        (object) "Left Forward",
        (object) "Right Wing",
        (object) "Right Striker",
        (object) "Central Striker",
        (object) "Left Striker",
        (object) "Left Wing"
            });
            this.comboPreferredPosition2.Location = new Point(17, 67);
            this.comboPreferredPosition2.Name = "comboPreferredPosition2";
            this.comboPreferredPosition2.Size = new Size(208, 21);
            this.comboPreferredPosition2.TabIndex = 1;
            this.comboPreferredPosition2.SelectedIndexChanged += new EventHandler(this.comboPreferredPosition2_SelectedIndexChanged);
            this.comboPreferredPosition1.FormattingEnabled = true;
            this.comboPreferredPosition1.Items.AddRange(new object[29]
            {
        (object) "None",
        (object) "Goalkeeper",
        (object) "Sweeper",
        (object) "Right Wing Back",
        (object) "Right Back",
        (object) "Right Central Back",
        (object) "Central Back",
        (object) "Left Central Back",
        (object) "Left Back",
        (object) "Left Wing Back",
        (object) "Right Defensive Midfielder",
        (object) "Central Defensive Midfielder",
        (object) "Left Defensive Midfielder",
        (object) "Right Midfielder",
        (object) "Right Central Midfielder",
        (object) "Central Midfielder",
        (object) "Left Central Midfielder",
        (object) "Left Midfielder",
        (object) "Right Advanced Midfielder",
        (object) "Central Advanced Midfielder",
        (object) "Left Advanced Midfielder",
        (object) "Right Forward",
        (object) "Central Forward",
        (object) "Left Forward",
        (object) "Right Wing",
        (object) "Right Striker",
        (object) "Central Striker",
        (object) "Left Striker",
        (object) "Left Wing"
            });
            this.comboPreferredPosition1.Location = new Point(17, 40);
            this.comboPreferredPosition1.Name = "comboPreferredPosition1";
            this.comboPreferredPosition1.Size = new Size(208, 21);
            this.comboPreferredPosition1.TabIndex = 0;
            this.comboPreferredPosition1.SelectedIndexChanged += new EventHandler(this.comboPreferredPosition1_SelectedIndexChanged);
            this.domainInternationalReputation.DataBindings.Add(new Binding("SelectedIndex", (object)this.playerBindingSource, "internationalrep", true));
            this.domainInternationalReputation.Items.Add((object)"Poor");
            this.domainInternationalReputation.Items.Add((object)"Medium");
            this.domainInternationalReputation.Items.Add((object)"Good");
            this.domainInternationalReputation.Items.Add((object)"Very Good");
            this.domainInternationalReputation.Items.Add((object)"Superstar");
            this.domainInternationalReputation.Location = new Point(107, 164);
            this.domainInternationalReputation.Name = "domainInternationalReputation";
            this.domainInternationalReputation.Size = new Size(119, 20);
            this.domainInternationalReputation.TabIndex = 4;
            this.domainInternationalReputation.TextAlign = HorizontalAlignment.Center;
            this.domainInternationalReputation.Wrap = true;
            this.labelInternationalReputation.ImeMode = ImeMode.NoControl;
            this.labelInternationalReputation.Location = new Point(14, 152);
            this.labelInternationalReputation.Name = "labelInternationalReputation";
            this.labelInternationalReputation.Size = new Size(87, 41);
            this.labelInternationalReputation.TabIndex = 141;
            this.labelInternationalReputation.Text = "International Reputation";
            this.labelInternationalReputation.TextAlign = ContentAlignment.MiddleLeft;
            this.pageSkills.Controls.Add((Control)this.flowPanelSkills);
            this.pageSkills.ImageIndex = 1;
            this.pageSkills.Location = new Point(4, 23);
            this.pageSkills.Name = "pageSkills";
            this.pageSkills.Padding = new Padding(3);
            this.pageSkills.Size = new Size(1349, 780);
            this.pageSkills.TabIndex = 1;
            this.pageSkills.Text = "Skills";
            this.pageSkills.UseVisualStyleBackColor = true;
            this.flowPanelSkills.AutoScroll = true;
            this.flowPanelSkills.Controls.Add((Control)this.groupGenerateAttributes);
            this.flowPanelSkills.Controls.Add((Control)this.groupGoalkeperSkills);
            this.flowPanelSkills.Controls.Add((Control)this.groupDefensiveSkills);
            this.flowPanelSkills.Controls.Add((Control)this.groupMidfielderSkills);
            this.flowPanelSkills.Controls.Add((Control)this.groupMental);
            this.flowPanelSkills.Controls.Add((Control)this.groupAttackingSkills);
            this.flowPanelSkills.Controls.Add((Control)this.groupGenericAttributes);
            this.flowPanelSkills.Controls.Add((Control)this.groupFreeKick);
            this.flowPanelSkills.Controls.Add((Control)this.groupTraits);
            this.flowPanelSkills.Dock = DockStyle.Fill;
            this.flowPanelSkills.Location = new Point(3, 3);
            this.flowPanelSkills.Name = "flowPanelSkills";
            this.flowPanelSkills.Size = new Size(1343, 774);
            this.flowPanelSkills.TabIndex = 0;
            this.groupGenerateAttributes.BackColor = SystemColors.Control;
            this.groupGenerateAttributes.Controls.Add((Control)this.labelOverallrating);
            this.groupGenerateAttributes.Controls.Add((Control)this.trackOverallrating);
            this.groupGenerateAttributes.Controls.Add((Control)this.labelRandomize);
            this.groupGenerateAttributes.Controls.Add((Control)this.numericRandomize);
            this.groupGenerateAttributes.Controls.Add((Control)this.buttonRandomAboveAvg);
            this.groupGenerateAttributes.Controls.Add((Control)this.buttonRandomBelowAvg);
            this.groupGenerateAttributes.Controls.Add((Control)this.buttonRandomSuperstar);
            this.groupGenerateAttributes.Controls.Add((Control)this.buttonRandomVeryGood);
            this.groupGenerateAttributes.Controls.Add((Control)this.buttonRandomGood);
            this.groupGenerateAttributes.Controls.Add((Control)this.buttonRandomAverage);
            this.groupGenerateAttributes.Controls.Add((Control)this.buttonRandomPoor);
            this.groupGenerateAttributes.Location = new Point(3, 3);
            this.groupGenerateAttributes.Name = "groupGenerateAttributes";
            this.groupGenerateAttributes.Size = new Size(128, 378);
            this.groupGenerateAttributes.TabIndex = 9;
            this.groupGenerateAttributes.TabStop = false;
            this.groupGenerateAttributes.Text = "Random Generation";
            this.labelOverallrating.BackColor = SystemColors.Control;
            this.labelOverallrating.Cursor = Cursors.Arrow;
            this.labelOverallrating.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelOverallrating.ForeColor = Color.Yellow;
            this.labelOverallrating.Image = (Image)resources.GetObject("labelOverallrating.Image");
            this.labelOverallrating.ImeMode = ImeMode.NoControl;
            this.labelOverallrating.Location = new Point(10, 280);
            this.labelOverallrating.Name = "labelOverallrating";
            this.labelOverallrating.Size = new Size(112, 16);
            this.labelOverallrating.TabIndex = 126;
            this.labelOverallrating.Text = "Overall ";
            this.labelOverallrating.TextAlign = ContentAlignment.MiddleCenter;
            this.trackOverallrating.BackColor = SystemColors.Control;
            this.trackOverallrating.Cursor = Cursors.Arrow;
            this.trackOverallrating.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "overallrating", true));
            this.trackOverallrating.ImeMode = ImeMode.NoControl;
            this.trackOverallrating.LargeChange = 10;
            this.trackOverallrating.Location = new Point(2, 288);
            this.trackOverallrating.Maximum = 99;
            this.trackOverallrating.Minimum = 1;
            this.trackOverallrating.Name = "trackOverallrating";
            this.trackOverallrating.Size = new Size(128, 45);
            this.trackOverallrating.TabIndex = 125;
            this.trackOverallrating.TickFrequency = 10;
            this.trackOverallrating.Value = 99;
            this.trackOverallrating.ValueChanged += new EventHandler(this.trackOverallrating_ValueChanged);
            this.labelRandomize.Location = new Point(2, 16);
            this.labelRandomize.Name = "labelRandomize";
            this.labelRandomize.Size = new Size(56, 31);
            this.labelRandomize.TabIndex = 8;
            this.labelRandomize.Text = "Computed Overall";
            this.numericRandomize.Location = new Point(59, 24);
            this.numericRandomize.Maximum = new Decimal(new int[4]
            {
        99,
        0,
        0,
        0
            });
            this.numericRandomize.Minimum = new Decimal(new int[4]
            {
        1,
        0,
        0,
        0
            });
            this.numericRandomize.Name = "numericRandomize";
            this.numericRandomize.Size = new Size(53, 20);
            this.numericRandomize.TabIndex = 0;
            this.numericRandomize.TextAlign = HorizontalAlignment.Center;
            this.numericRandomize.Value = new Decimal(new int[4]
            {
        1,
        0,
        0,
        0
            });
            this.numericRandomize.ValueChanged += new EventHandler(this.numericOverall_ValueChanged);
            this.buttonRandomAboveAvg.ImeMode = ImeMode.NoControl;
            this.buttonRandomAboveAvg.Location = new Point(11, 134);
            this.buttonRandomAboveAvg.Name = "buttonRandomAboveAvg";
            this.buttonRandomAboveAvg.Size = new Size(101, 27);
            this.buttonRandomAboveAvg.TabIndex = 4;
            this.buttonRandomAboveAvg.Text = "Above Avg.";
            this.buttonRandomAboveAvg.Click += new EventHandler(this.buttonRandomAboveAvg_Click);
            this.buttonRandomBelowAvg.ImeMode = ImeMode.NoControl;
            this.buttonRandomBelowAvg.Location = new Point(11, 78);
            this.buttonRandomBelowAvg.Name = "buttonRandomBelowAvg";
            this.buttonRandomBelowAvg.Size = new Size(101, 27);
            this.buttonRandomBelowAvg.TabIndex = 2;
            this.buttonRandomBelowAvg.Text = "Below Avg.";
            this.buttonRandomBelowAvg.Click += new EventHandler(this.buttonRandomBelowAvg_Click);
            this.buttonRandomSuperstar.BackgroundImageLayout = ImageLayout.Center;
            this.buttonRandomSuperstar.ImeMode = ImeMode.NoControl;
            this.buttonRandomSuperstar.Location = new Point(11, 219);
            this.buttonRandomSuperstar.Name = "buttonRandomSuperstar";
            this.buttonRandomSuperstar.Size = new Size(101, 27);
            this.buttonRandomSuperstar.TabIndex = 7;
            this.buttonRandomSuperstar.Text = "Superstar";
            this.buttonRandomSuperstar.Click += new EventHandler(this.buttonRandomSuperstar_Click);
            this.buttonRandomVeryGood.ImeMode = ImeMode.NoControl;
            this.buttonRandomVeryGood.Location = new Point(11, 190);
            this.buttonRandomVeryGood.Name = "buttonRandomVeryGood";
            this.buttonRandomVeryGood.Size = new Size(101, 27);
            this.buttonRandomVeryGood.TabIndex = 6;
            this.buttonRandomVeryGood.Text = "Very Good";
            this.buttonRandomVeryGood.Click += new EventHandler(this.buttonRandomVeryGood_Click);
            this.buttonRandomGood.ImeMode = ImeMode.NoControl;
            this.buttonRandomGood.Location = new Point(11, 162);
            this.buttonRandomGood.Name = "buttonRandomGood";
            this.buttonRandomGood.Size = new Size(101, 27);
            this.buttonRandomGood.TabIndex = 5;
            this.buttonRandomGood.Text = "Good";
            this.buttonRandomGood.Click += new EventHandler(this.buttonRandomGood_Click);
            this.buttonRandomAverage.ImeMode = ImeMode.NoControl;
            this.buttonRandomAverage.Location = new Point(11, 106);
            this.buttonRandomAverage.Name = "buttonRandomAverage";
            this.buttonRandomAverage.Size = new Size(101, 27);
            this.buttonRandomAverage.TabIndex = 3;
            this.buttonRandomAverage.Text = "Average";
            this.buttonRandomAverage.Click += new EventHandler(this.buttonRandomAverage_Click);
            this.buttonRandomPoor.ImeMode = ImeMode.NoControl;
            this.buttonRandomPoor.Location = new Point(11, 50);
            this.buttonRandomPoor.Name = "buttonRandomPoor";
            this.buttonRandomPoor.Size = new Size(101, 27);
            this.buttonRandomPoor.TabIndex = 1;
            this.buttonRandomPoor.Text = "Poor";
            this.buttonRandomPoor.Click += new EventHandler(this.buttonRandomPoor_Click);
            this.groupGoalkeperSkills.BackColor = SystemColors.Control;
            this.groupGoalkeperSkills.Controls.Add((Control)this.label5);
            this.groupGoalkeperSkills.Controls.Add((Control)this.comboGkSaveStyle);
            this.groupGoalkeperSkills.Controls.Add((Control)this.label3);
            this.groupGoalkeperSkills.Controls.Add((Control)this.labelGkKick);
            this.groupGoalkeperSkills.Controls.Add((Control)this.comboGkKickStyle);
            this.groupGoalkeperSkills.Controls.Add((Control)this.trackGkKicking);
            this.groupGoalkeperSkills.Controls.Add((Control)this.labelDiving);
            this.groupGoalkeperSkills.Controls.Add((Control)this.labelPositioning);
            this.groupGoalkeperSkills.Controls.Add((Control)this.labelReflexes);
            this.groupGoalkeperSkills.Controls.Add((Control)this.labelHandling);
            this.groupGoalkeperSkills.Controls.Add((Control)this.trackDiving);
            this.groupGoalkeperSkills.Controls.Add((Control)this.trackPositioning);
            this.groupGoalkeperSkills.Controls.Add((Control)this.trackReflexes);
            this.groupGoalkeperSkills.Controls.Add((Control)this.trackHandling);
            this.groupGoalkeperSkills.Controls.Add((Control)this.numericGoalkeeperSkills);
            this.groupGoalkeperSkills.Location = new Point(137, 3);
            this.groupGoalkeperSkills.Name = "groupGoalkeperSkills";
            this.groupGoalkeperSkills.Size = new Size(140, 378);
            this.groupGoalkeperSkills.TabIndex = 14;
            this.groupGoalkeperSkills.TabStop = false;
            this.groupGoalkeperSkills.Text = "Goalkeeper Skills";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(43, 301);
            this.label5.Name = "label5";
            this.label5.Size = new Size(58, 13);
            this.label5.TabIndex = 96;
            this.label5.Text = "Save Style";
            this.comboGkSaveStyle.DataBindings.Add(new Binding("SelectedIndex", (object)this.playerBindingSource, "gksavetype", true));
            this.comboGkSaveStyle.FormattingEnabled = true;
            this.comboGkSaveStyle.Items.AddRange(new object[2]
            {
        (object) "Traditional",
        (object) "Acrobatic"
            });
            this.comboGkSaveStyle.Location = new Point(7, 317);
            this.comboGkSaveStyle.Name = "comboGkSaveStyle";
            this.comboGkSaveStyle.Size = new Size(124, 21);
            this.comboGkSaveStyle.TabIndex = 95;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(6, 280);
            this.label3.Name = "label3";
            this.label3.Size = new Size(54, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "Kick Style";
            this.labelGkKick.BackColor = SystemColors.Control;
            this.labelGkKick.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelGkKick.ForeColor = Color.Yellow;
            this.labelGkKick.Image = (Image)resources.GetObject("labelGkKick.Image");
            this.labelGkKick.ImeMode = ImeMode.NoControl;
            this.labelGkKick.Location = new Point(14, 232);
            this.labelGkKick.Name = "labelGkKick";
            this.labelGkKick.Size = new Size(112, 16);
            this.labelGkKick.TabIndex = 94;
            this.labelGkKick.Text = "Kicking ";
            this.labelGkKick.TextAlign = ContentAlignment.MiddleCenter;
            this.comboGkKickStyle.DataBindings.Add(new Binding("SelectedIndex", (object)this.playerBindingSource, "gkkickstyle", true));
            this.comboGkKickStyle.FormattingEnabled = true;
            this.comboGkKickStyle.Items.AddRange(new object[4]
            {
        (object) "0",
        (object) "1",
        (object) "2",
        (object) "3"
            });
            this.comboGkKickStyle.Location = new Point(66, 277);
            this.comboGkKickStyle.Name = "comboGkKickStyle";
            this.comboGkKickStyle.Size = new Size(65, 21);
            this.comboGkKickStyle.TabIndex = 7;
            this.trackGkKicking.BackColor = SystemColors.Control;
            this.trackGkKicking.Cursor = Cursors.Default;
            this.trackGkKicking.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "gkkicking", true));
            this.trackGkKicking.ImeMode = ImeMode.NoControl;
            this.trackGkKicking.LargeChange = 10;
            this.trackGkKicking.Location = new Point(6, 240);
            this.trackGkKicking.Maximum = 99;
            this.trackGkKicking.Minimum = 1;
            this.trackGkKicking.Name = "trackGkKicking";
            this.trackGkKicking.Size = new Size(128, 45);
            this.trackGkKicking.TabIndex = 6;
            this.trackGkKicking.TickFrequency = 10;
            this.trackGkKicking.Value = 99;
            this.trackGkKicking.ValueChanged += new EventHandler(this.trackGkKick_ValueChanged);
            this.labelDiving.BackColor = SystemColors.Control;
            this.labelDiving.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelDiving.ForeColor = Color.Yellow;
            this.labelDiving.Image = (Image)resources.GetObject("labelDiving.Image");
            this.labelDiving.ImeMode = ImeMode.NoControl;
            this.labelDiving.Location = new Point(14, 136);
            this.labelDiving.Name = "labelDiving";
            this.labelDiving.Size = new Size(112, 16);
            this.labelDiving.TabIndex = 88;
            this.labelDiving.Text = "Diving ";
            this.labelDiving.TextAlign = ContentAlignment.MiddleCenter;
            this.labelPositioning.BackColor = SystemColors.Control;
            this.labelPositioning.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelPositioning.ForeColor = Color.Yellow;
            this.labelPositioning.Image = (Image)resources.GetObject("labelPositioning.Image");
            this.labelPositioning.ImeMode = ImeMode.NoControl;
            this.labelPositioning.Location = new Point(14, 184);
            this.labelPositioning.Name = "labelPositioning";
            this.labelPositioning.Size = new Size(112, 16);
            this.labelPositioning.TabIndex = 90;
            this.labelPositioning.Text = "Positioning ";
            this.labelPositioning.TextAlign = ContentAlignment.MiddleCenter;
            this.labelReflexes.BackColor = SystemColors.Control;
            this.labelReflexes.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelReflexes.ForeColor = Color.Yellow;
            this.labelReflexes.Image = (Image)resources.GetObject("labelReflexes.Image");
            this.labelReflexes.ImeMode = ImeMode.NoControl;
            this.labelReflexes.Location = new Point(14, 40);
            this.labelReflexes.Name = "labelReflexes";
            this.labelReflexes.Size = new Size(112, 16);
            this.labelReflexes.TabIndex = 84;
            this.labelReflexes.Text = "Reflexes ";
            this.labelReflexes.TextAlign = ContentAlignment.MiddleCenter;
            this.labelHandling.BackColor = SystemColors.Control;
            this.labelHandling.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelHandling.ForeColor = Color.Yellow;
            this.labelHandling.Image = (Image)resources.GetObject("labelHandling.Image");
            this.labelHandling.ImeMode = ImeMode.NoControl;
            this.labelHandling.Location = new Point(14, 88);
            this.labelHandling.Name = "labelHandling";
            this.labelHandling.Size = new Size(112, 16);
            this.labelHandling.TabIndex = 86;
            this.labelHandling.Text = "Handling ";
            this.labelHandling.TextAlign = ContentAlignment.MiddleCenter;
            this.trackDiving.BackColor = SystemColors.Control;
            this.trackDiving.Cursor = Cursors.Default;
            this.trackDiving.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "gkdiving", true));
            this.trackDiving.ImeMode = ImeMode.NoControl;
            this.trackDiving.LargeChange = 10;
            this.trackDiving.Location = new Point(5, 144);
            this.trackDiving.Maximum = 99;
            this.trackDiving.Minimum = 1;
            this.trackDiving.Name = "trackDiving";
            this.trackDiving.Size = new Size(128, 45);
            this.trackDiving.TabIndex = 3;
            this.trackDiving.TickFrequency = 10;
            this.trackDiving.Value = 99;
            this.trackDiving.ValueChanged += new EventHandler(this.trackDiving_ValueChanged);
            this.trackPositioning.BackColor = SystemColors.Control;
            this.trackPositioning.Cursor = Cursors.Default;
            this.trackPositioning.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "gkpositioning", true));
            this.trackPositioning.ImeMode = ImeMode.NoControl;
            this.trackPositioning.LargeChange = 10;
            this.trackPositioning.Location = new Point(6, 195);
            this.trackPositioning.Maximum = 99;
            this.trackPositioning.Minimum = 1;
            this.trackPositioning.Name = "trackPositioning";
            this.trackPositioning.Size = new Size(128, 45);
            this.trackPositioning.TabIndex = 4;
            this.trackPositioning.TickFrequency = 10;
            this.trackPositioning.Value = 99;
            this.trackPositioning.ValueChanged += new EventHandler(this.trackPositioning_ValueChanged);
            this.trackReflexes.BackColor = SystemColors.Control;
            this.trackReflexes.Cursor = Cursors.Default;
            this.trackReflexes.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "gkreflexes", true));
            this.trackReflexes.ImeMode = ImeMode.NoControl;
            this.trackReflexes.LargeChange = 10;
            this.trackReflexes.Location = new Point(6, 48);
            this.trackReflexes.Maximum = 99;
            this.trackReflexes.Minimum = 1;
            this.trackReflexes.Name = "trackReflexes";
            this.trackReflexes.Size = new Size(128, 45);
            this.trackReflexes.TabIndex = 1;
            this.trackReflexes.TickFrequency = 10;
            this.trackReflexes.Value = 99;
            this.trackReflexes.ValueChanged += new EventHandler(this.trackReflexes_ValueChanged);
            this.trackHandling.BackColor = SystemColors.Control;
            this.trackHandling.Cursor = Cursors.Default;
            this.trackHandling.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "gkhandling", true));
            this.trackHandling.ImeMode = ImeMode.NoControl;
            this.trackHandling.LargeChange = 10;
            this.trackHandling.Location = new Point(5, 96);
            this.trackHandling.Maximum = 99;
            this.trackHandling.Minimum = 1;
            this.trackHandling.Name = "trackHandling";
            this.trackHandling.Size = new Size(128, 45);
            this.trackHandling.TabIndex = 2;
            this.trackHandling.TickFrequency = 10;
            this.trackHandling.Value = 99;
            this.trackHandling.ValueChanged += new EventHandler(this.trackHandling_ValueChanged);
            this.numericGoalkeeperSkills.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.numericGoalkeeperSkills.BackColor = Color.Teal;
            this.numericGoalkeeperSkills.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold);
            this.numericGoalkeeperSkills.ForeColor = Color.FromArgb(192, (int)byte.MaxValue, (int)byte.MaxValue);
            this.numericGoalkeeperSkills.Location = new Point(49, 15);
            this.numericGoalkeeperSkills.Maximum = new Decimal(new int[4]
            {
        99,
        0,
        0,
        0
            });
            this.numericGoalkeeperSkills.Minimum = new Decimal(new int[4]
            {
        1,
        0,
        0,
        0
            });
            this.numericGoalkeeperSkills.Name = "numericGoalkeeperSkills";
            this.numericGoalkeeperSkills.Size = new Size(44, 22);
            this.numericGoalkeeperSkills.TabIndex = 0;
            this.numericGoalkeeperSkills.TextAlign = HorizontalAlignment.Center;
            this.numericGoalkeeperSkills.Value = new Decimal(new int[4]
            {
        99,
        0,
        0,
        0
            });
            this.numericGoalkeeperSkills.ValueChanged += new EventHandler(this.numericGoalkeeperSkills_ValueChanged);
            this.groupDefensiveSkills.BackColor = SystemColors.Control;
            this.groupDefensiveSkills.Controls.Add((Control)this.labelInterception);
            this.groupDefensiveSkills.Controls.Add((Control)this.trackInterception);
            this.groupDefensiveSkills.Controls.Add((Control)this.labelSliding);
            this.groupDefensiveSkills.Controls.Add((Control)this.trackSliding);
            this.groupDefensiveSkills.Controls.Add((Control)this.numericDefensiveSkills);
            this.groupDefensiveSkills.Controls.Add((Control)this.labelAggression);
            this.groupDefensiveSkills.Controls.Add((Control)this.labelMarking);
            this.groupDefensiveSkills.Controls.Add((Control)this.labelTackling);
            this.groupDefensiveSkills.Controls.Add((Control)this.trackTackling);
            this.groupDefensiveSkills.Controls.Add((Control)this.trackMarking);
            this.groupDefensiveSkills.Controls.Add((Control)this.trackAggression);
            this.groupDefensiveSkills.Location = new Point(283, 3);
            this.groupDefensiveSkills.Name = "groupDefensiveSkills";
            this.groupDefensiveSkills.Size = new Size(140, 378);
            this.groupDefensiveSkills.TabIndex = 15;
            this.groupDefensiveSkills.TabStop = false;
            this.groupDefensiveSkills.Text = "Defensive Skills";
            this.labelInterception.BackColor = SystemColors.Control;
            this.labelInterception.Cursor = Cursors.Arrow;
            this.labelInterception.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelInterception.ForeColor = Color.Yellow;
            this.labelInterception.Image = (Image)resources.GetObject("labelInterception.Image");
            this.labelInterception.ImeMode = ImeMode.NoControl;
            this.labelInterception.Location = new Point(16, 230);
            this.labelInterception.Name = "labelInterception";
            this.labelInterception.Size = new Size(112, 16);
            this.labelInterception.TabIndex = 102;
            this.labelInterception.Text = "Interception ";
            this.labelInterception.TextAlign = ContentAlignment.MiddleCenter;
            this.trackInterception.BackColor = SystemColors.Control;
            this.trackInterception.Cursor = Cursors.Arrow;
            this.trackInterception.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "interceptions", true));
            this.trackInterception.ImeMode = ImeMode.NoControl;
            this.trackInterception.LargeChange = 10;
            this.trackInterception.Location = new Point(6, 238);
            this.trackInterception.Maximum = 99;
            this.trackInterception.Minimum = 1;
            this.trackInterception.Name = "trackInterception";
            this.trackInterception.Size = new Size(128, 45);
            this.trackInterception.TabIndex = 101;
            this.trackInterception.TickFrequency = 10;
            this.trackInterception.Value = 99;
            this.trackInterception.ValueChanged += new EventHandler(this.trackInterception_ValueChanged);
            this.labelSliding.BackColor = SystemColors.Control;
            this.labelSliding.Cursor = Cursors.Arrow;
            this.labelSliding.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelSliding.ForeColor = Color.Yellow;
            this.labelSliding.Image = (Image)resources.GetObject("labelSliding.Image");
            this.labelSliding.ImeMode = ImeMode.NoControl;
            this.labelSliding.Location = new Point(16, 184);
            this.labelSliding.Name = "labelSliding";
            this.labelSliding.Size = new Size(112, 16);
            this.labelSliding.TabIndex = 100;
            this.labelSliding.Text = "Sliding ";
            this.labelSliding.TextAlign = ContentAlignment.MiddleCenter;
            this.trackSliding.BackColor = SystemColors.Control;
            this.trackSliding.Cursor = Cursors.Arrow;
            this.trackSliding.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "slidingtackle", true));
            this.trackSliding.ImeMode = ImeMode.NoControl;
            this.trackSliding.LargeChange = 10;
            this.trackSliding.Location = new Point(6, 192);
            this.trackSliding.Maximum = 99;
            this.trackSliding.Minimum = 1;
            this.trackSliding.Name = "trackSliding";
            this.trackSliding.Size = new Size(128, 45);
            this.trackSliding.TabIndex = 4;
            this.trackSliding.TickFrequency = 10;
            this.trackSliding.Value = 99;
            this.trackSliding.ValueChanged += new EventHandler(this.trackSliding_ValueChanged);
            this.numericDefensiveSkills.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.numericDefensiveSkills.BackColor = Color.Teal;
            this.numericDefensiveSkills.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold);
            this.numericDefensiveSkills.ForeColor = Color.FromArgb(192, (int)byte.MaxValue, (int)byte.MaxValue);
            this.numericDefensiveSkills.Location = new Point(48, 16);
            this.numericDefensiveSkills.Maximum = new Decimal(new int[4]
            {
        99,
        0,
        0,
        0
            });
            this.numericDefensiveSkills.Minimum = new Decimal(new int[4]
            {
        1,
        0,
        0,
        0
            });
            this.numericDefensiveSkills.Name = "numericDefensiveSkills";
            this.numericDefensiveSkills.Size = new Size(44, 22);
            this.numericDefensiveSkills.TabIndex = 0;
            this.numericDefensiveSkills.TextAlign = HorizontalAlignment.Center;
            this.numericDefensiveSkills.Value = new Decimal(new int[4]
            {
        99,
        0,
        0,
        0
            });
            this.numericDefensiveSkills.ValueChanged += new EventHandler(this.numericDefensiveSkills_ValueChanged);
            this.labelAggression.BackColor = SystemColors.Control;
            this.labelAggression.Cursor = Cursors.Arrow;
            this.labelAggression.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelAggression.ForeColor = Color.Yellow;
            this.labelAggression.Image = (Image)resources.GetObject("labelAggression.Image");
            this.labelAggression.ImeMode = ImeMode.NoControl;
            this.labelAggression.Location = new Point(14, 136);
            this.labelAggression.Name = "labelAggression";
            this.labelAggression.Size = new Size(112, 16);
            this.labelAggression.TabIndex = 67;
            this.labelAggression.Text = "Aggression ";
            this.labelAggression.TextAlign = ContentAlignment.MiddleCenter;
            this.labelMarking.BackColor = SystemColors.Control;
            this.labelMarking.Cursor = Cursors.Arrow;
            this.labelMarking.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelMarking.ForeColor = Color.Yellow;
            this.labelMarking.Image = (Image)resources.GetObject("labelMarking.Image");
            this.labelMarking.ImeMode = ImeMode.NoControl;
            this.labelMarking.Location = new Point(14, 40);
            this.labelMarking.Name = "labelMarking";
            this.labelMarking.Size = new Size(112, 16);
            this.labelMarking.TabIndex = 75;
            this.labelMarking.Text = "Marking ";
            this.labelMarking.TextAlign = ContentAlignment.MiddleCenter;
            this.labelTackling.BackColor = SystemColors.Control;
            this.labelTackling.Cursor = Cursors.Arrow;
            this.labelTackling.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelTackling.ForeColor = Color.Yellow;
            this.labelTackling.Image = (Image)resources.GetObject("labelTackling.Image");
            this.labelTackling.ImeMode = ImeMode.NoControl;
            this.labelTackling.Location = new Point(14, 88);
            this.labelTackling.Name = "labelTackling";
            this.labelTackling.Size = new Size(112, 16);
            this.labelTackling.TabIndex = 77;
            this.labelTackling.Text = "Tackling ";
            this.labelTackling.TextAlign = ContentAlignment.MiddleCenter;
            this.trackTackling.BackColor = SystemColors.Control;
            this.trackTackling.Cursor = Cursors.Arrow;
            this.trackTackling.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "standingtackle", true));
            this.trackTackling.ImeMode = ImeMode.NoControl;
            this.trackTackling.LargeChange = 10;
            this.trackTackling.Location = new Point(6, 96);
            this.trackTackling.Maximum = 99;
            this.trackTackling.Minimum = 1;
            this.trackTackling.Name = "trackTackling";
            this.trackTackling.Size = new Size(128, 45);
            this.trackTackling.TabIndex = 2;
            this.trackTackling.TickFrequency = 10;
            this.trackTackling.Value = 99;
            this.trackTackling.ValueChanged += new EventHandler(this.trackTackling_ValueChanged);
            this.trackMarking.BackColor = SystemColors.Control;
            this.trackMarking.Cursor = Cursors.Arrow;
            this.trackMarking.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "marking", true));
            this.trackMarking.ImeMode = ImeMode.NoControl;
            this.trackMarking.LargeChange = 10;
            this.trackMarking.Location = new Point(6, 48);
            this.trackMarking.Maximum = 99;
            this.trackMarking.Minimum = 1;
            this.trackMarking.Name = "trackMarking";
            this.trackMarking.Size = new Size(128, 45);
            this.trackMarking.TabIndex = 1;
            this.trackMarking.TickFrequency = 10;
            this.trackMarking.Value = 99;
            this.trackMarking.ValueChanged += new EventHandler(this.trackMarking_ValueChanged);
            this.trackAggression.BackColor = SystemColors.Control;
            this.trackAggression.Cursor = Cursors.Arrow;
            this.trackAggression.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "aggression", true));
            this.trackAggression.ImeMode = ImeMode.NoControl;
            this.trackAggression.LargeChange = 10;
            this.trackAggression.Location = new Point(6, 144);
            this.trackAggression.Maximum = 99;
            this.trackAggression.Minimum = 1;
            this.trackAggression.Name = "trackAggression";
            this.trackAggression.Size = new Size(128, 45);
            this.trackAggression.TabIndex = 3;
            this.trackAggression.TickFrequency = 10;
            this.trackAggression.Value = 99;
            this.trackAggression.ValueChanged += new EventHandler(this.trackAggression_ValueChanged);
            this.groupMidfielderSkills.BackColor = SystemColors.Control;
            this.groupMidfielderSkills.Controls.Add((Control)this.labelCurve);
            this.groupMidfielderSkills.Controls.Add((Control)this.trackCurve);
            this.groupMidfielderSkills.Controls.Add((Control)this.labelVision);
            this.groupMidfielderSkills.Controls.Add((Control)this.trackVision);
            this.groupMidfielderSkills.Controls.Add((Control)this.numericMidfielderSkills);
            this.groupMidfielderSkills.Controls.Add((Control)this.labelBallControl);
            this.groupMidfielderSkills.Controls.Add((Control)this.labelCrossing);
            this.groupMidfielderSkills.Controls.Add((Control)this.labelLongPassing);
            this.groupMidfielderSkills.Controls.Add((Control)this.trackLongPassing);
            this.groupMidfielderSkills.Controls.Add((Control)this.labelShortPassing);
            this.groupMidfielderSkills.Controls.Add((Control)this.trackShortPassing);
            this.groupMidfielderSkills.Controls.Add((Control)this.trackBallControl);
            this.groupMidfielderSkills.Controls.Add((Control)this.trackCrossing);
            this.groupMidfielderSkills.Location = new Point(429, 3);
            this.groupMidfielderSkills.Name = "groupMidfielderSkills";
            this.groupMidfielderSkills.Size = new Size(140, 378);
            this.groupMidfielderSkills.TabIndex = 16;
            this.groupMidfielderSkills.TabStop = false;
            this.groupMidfielderSkills.Text = "Midfielder Skills";
            this.labelCurve.BackColor = SystemColors.Control;
            this.labelCurve.Cursor = Cursors.Arrow;
            this.labelCurve.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelCurve.ForeColor = Color.Yellow;
            this.labelCurve.Image = (Image)resources.GetObject("labelCurve.Image");
            this.labelCurve.ImeMode = ImeMode.NoControl;
            this.labelCurve.Location = new Point(11, 280);
            this.labelCurve.Name = "labelCurve";
            this.labelCurve.Size = new Size(112, 16);
            this.labelCurve.TabIndex = 106;
            this.labelCurve.Text = "Curve ";
            this.labelCurve.TextAlign = ContentAlignment.MiddleCenter;
            this.trackCurve.BackColor = SystemColors.Control;
            this.trackCurve.Cursor = Cursors.Arrow;
            this.trackCurve.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "curve", true));
            this.trackCurve.ImeMode = ImeMode.NoControl;
            this.trackCurve.LargeChange = 10;
            this.trackCurve.Location = new Point(1, 288);
            this.trackCurve.Maximum = 99;
            this.trackCurve.Minimum = 1;
            this.trackCurve.Name = "trackCurve";
            this.trackCurve.Size = new Size(128, 45);
            this.trackCurve.TabIndex = 6;
            this.trackCurve.TickFrequency = 10;
            this.trackCurve.Value = 99;
            this.trackCurve.ValueChanged += new EventHandler(this.trackCurve_ValueChanged);
            this.labelVision.BackColor = SystemColors.Control;
            this.labelVision.Cursor = Cursors.Arrow;
            this.labelVision.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelVision.ForeColor = Color.Yellow;
            this.labelVision.Image = (Image)resources.GetObject("labelVision.Image");
            this.labelVision.ImeMode = ImeMode.NoControl;
            this.labelVision.Location = new Point(11, 232);
            this.labelVision.Name = "labelVision";
            this.labelVision.Size = new Size(112, 16);
            this.labelVision.TabIndex = 104;
            this.labelVision.Text = "Vision ";
            this.labelVision.TextAlign = ContentAlignment.MiddleCenter;
            this.trackVision.BackColor = SystemColors.Control;
            this.trackVision.Cursor = Cursors.Arrow;
            this.trackVision.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "vision", true));
            this.trackVision.ImeMode = ImeMode.NoControl;
            this.trackVision.LargeChange = 10;
            this.trackVision.Location = new Point(1, 240);
            this.trackVision.Maximum = 99;
            this.trackVision.Minimum = 1;
            this.trackVision.Name = "trackVision";
            this.trackVision.Size = new Size(128, 45);
            this.trackVision.TabIndex = 5;
            this.trackVision.TickFrequency = 10;
            this.trackVision.Value = 99;
            this.trackVision.ValueChanged += new EventHandler(this.trackVision_ValueChanged);
            this.numericMidfielderSkills.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.numericMidfielderSkills.BackColor = Color.Teal;
            this.numericMidfielderSkills.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold);
            this.numericMidfielderSkills.ForeColor = Color.FromArgb(192, (int)byte.MaxValue, (int)byte.MaxValue);
            this.numericMidfielderSkills.Location = new Point(41, 15);
            this.numericMidfielderSkills.Maximum = new Decimal(new int[4]
            {
        99,
        0,
        0,
        0
            });
            this.numericMidfielderSkills.Minimum = new Decimal(new int[4]
            {
        1,
        0,
        0,
        0
            });
            this.numericMidfielderSkills.Name = "numericMidfielderSkills";
            this.numericMidfielderSkills.Size = new Size(44, 22);
            this.numericMidfielderSkills.TabIndex = 0;
            this.numericMidfielderSkills.TextAlign = HorizontalAlignment.Center;
            this.numericMidfielderSkills.Value = new Decimal(new int[4]
            {
        99,
        0,
        0,
        0
            });
            this.numericMidfielderSkills.ValueChanged += new EventHandler(this.numericMidfielderSkills_ValueChanged);
            this.labelBallControl.BackColor = SystemColors.Control;
            this.labelBallControl.Cursor = Cursors.Arrow;
            this.labelBallControl.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelBallControl.ForeColor = Color.Yellow;
            this.labelBallControl.Image = (Image)resources.GetObject("labelBallControl.Image");
            this.labelBallControl.ImeMode = ImeMode.NoControl;
            this.labelBallControl.Location = new Point(11, 184);
            this.labelBallControl.Name = "labelBallControl";
            this.labelBallControl.Size = new Size(112, 16);
            this.labelBallControl.TabIndex = 79;
            this.labelBallControl.Text = "Ball-Control ";
            this.labelBallControl.TextAlign = ContentAlignment.MiddleCenter;
            this.labelCrossing.BackColor = SystemColors.Control;
            this.labelCrossing.Cursor = Cursors.Arrow;
            this.labelCrossing.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelCrossing.ForeColor = Color.Yellow;
            this.labelCrossing.Image = (Image)resources.GetObject("labelCrossing.Image");
            this.labelCrossing.ImeMode = ImeMode.NoControl;
            this.labelCrossing.Location = new Point(9, 136);
            this.labelCrossing.Name = "labelCrossing";
            this.labelCrossing.Size = new Size(112, 16);
            this.labelCrossing.TabIndex = 84;
            this.labelCrossing.Text = "Crossing ";
            this.labelCrossing.TextAlign = ContentAlignment.MiddleCenter;
            this.labelLongPassing.BackColor = SystemColors.Control;
            this.labelLongPassing.Cursor = Cursors.Arrow;
            this.labelLongPassing.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelLongPassing.ForeColor = Color.Yellow;
            this.labelLongPassing.Image = (Image)resources.GetObject("labelLongPassing.Image");
            this.labelLongPassing.ImeMode = ImeMode.NoControl;
            this.labelLongPassing.Location = new Point(9, 88);
            this.labelLongPassing.Name = "labelLongPassing";
            this.labelLongPassing.Size = new Size(112, 16);
            this.labelLongPassing.TabIndex = 102;
            this.labelLongPassing.Text = "Long-Passing ";
            this.labelLongPassing.TextAlign = ContentAlignment.MiddleCenter;
            this.trackLongPassing.BackColor = SystemColors.Control;
            this.trackLongPassing.Cursor = Cursors.Arrow;
            this.trackLongPassing.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "longpassing", true));
            this.trackLongPassing.ImeMode = ImeMode.NoControl;
            this.trackLongPassing.LargeChange = 10;
            this.trackLongPassing.Location = new Point(1, 96);
            this.trackLongPassing.Maximum = 99;
            this.trackLongPassing.Minimum = 1;
            this.trackLongPassing.Name = "trackLongPassing";
            this.trackLongPassing.Size = new Size(128, 45);
            this.trackLongPassing.TabIndex = 2;
            this.trackLongPassing.TickFrequency = 10;
            this.trackLongPassing.Value = 99;
            this.trackLongPassing.ValueChanged += new EventHandler(this.trackLongPassing_ValueChanged);
            this.labelShortPassing.BackColor = SystemColors.Control;
            this.labelShortPassing.Cursor = Cursors.Arrow;
            this.labelShortPassing.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelShortPassing.ForeColor = Color.Yellow;
            this.labelShortPassing.Image = (Image)resources.GetObject("labelShortPassing.Image");
            this.labelShortPassing.ImeMode = ImeMode.NoControl;
            this.labelShortPassing.Location = new Point(9, 40);
            this.labelShortPassing.Name = "labelShortPassing";
            this.labelShortPassing.Size = new Size(112, 16);
            this.labelShortPassing.TabIndex = 100;
            this.labelShortPassing.Text = "Short-Passing ";
            this.labelShortPassing.TextAlign = ContentAlignment.MiddleCenter;
            this.trackShortPassing.BackColor = SystemColors.Control;
            this.trackShortPassing.Cursor = Cursors.Arrow;
            this.trackShortPassing.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "shortpassing", true));
            this.trackShortPassing.ImeMode = ImeMode.NoControl;
            this.trackShortPassing.LargeChange = 10;
            this.trackShortPassing.Location = new Point(1, 48);
            this.trackShortPassing.Maximum = 99;
            this.trackShortPassing.Minimum = 1;
            this.trackShortPassing.Name = "trackShortPassing";
            this.trackShortPassing.Size = new Size(128, 45);
            this.trackShortPassing.TabIndex = 1;
            this.trackShortPassing.TickFrequency = 10;
            this.trackShortPassing.Value = 99;
            this.trackShortPassing.ValueChanged += new EventHandler(this.trackShortPassing_ValueChanged);
            this.trackBallControl.BackColor = SystemColors.Control;
            this.trackBallControl.Cursor = Cursors.Arrow;
            this.trackBallControl.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "ballcontrol", true));
            this.trackBallControl.ImeMode = ImeMode.NoControl;
            this.trackBallControl.LargeChange = 10;
            this.trackBallControl.Location = new Point(1, 192);
            this.trackBallControl.Maximum = 99;
            this.trackBallControl.Minimum = 1;
            this.trackBallControl.Name = "trackBallControl";
            this.trackBallControl.Size = new Size(128, 45);
            this.trackBallControl.TabIndex = 4;
            this.trackBallControl.TickFrequency = 10;
            this.trackBallControl.Value = 99;
            this.trackBallControl.ValueChanged += new EventHandler(this.trackBallControl_ValueChanged);
            this.trackCrossing.BackColor = SystemColors.Control;
            this.trackCrossing.Cursor = Cursors.Arrow;
            this.trackCrossing.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "crossing", true));
            this.trackCrossing.ImeMode = ImeMode.NoControl;
            this.trackCrossing.LargeChange = 10;
            this.trackCrossing.Location = new Point(1, 144);
            this.trackCrossing.Maximum = 99;
            this.trackCrossing.Minimum = 1;
            this.trackCrossing.Name = "trackCrossing";
            this.trackCrossing.Size = new Size(128, 45);
            this.trackCrossing.TabIndex = 3;
            this.trackCrossing.TickFrequency = 10;
            this.trackCrossing.Value = 99;
            this.trackCrossing.ValueChanged += new EventHandler(this.trackCrossing_ValueChanged);
            this.groupMental.BackColor = SystemColors.Control;
            this.groupMental.Controls.Add((Control)this.comboDefensiveWorkrate);
            this.groupMental.Controls.Add((Control)this.label10);
            this.groupMental.Controls.Add((Control)this.comboAttackWorkRate);
            this.groupMental.Controls.Add((Control)this.label9);
            this.groupMental.Controls.Add((Control)this.numericMentalSkills);
            this.groupMental.Controls.Add((Control)this.labelPlayerPositioning);
            this.groupMental.Controls.Add((Control)this.labelPotential);
            this.groupMental.Controls.Add((Control)this.trackPlayerPositioning);
            this.groupMental.Controls.Add((Control)this.trackPotential);
            this.groupMental.Location = new Point(575, 3);
            this.groupMental.Name = "groupMental";
            this.groupMental.Size = new Size(140, 378);
            this.groupMental.TabIndex = 26;
            this.groupMental.TabStop = false;
            this.groupMental.Text = "Mental Skills";
            this.comboDefensiveWorkrate.DataBindings.Add(new Binding("SelectedIndex", (object)this.playerBindingSource, "defensiveworkrate", true));
            this.comboDefensiveWorkrate.FormattingEnabled = true;
            this.comboDefensiveWorkrate.Items.AddRange(new object[3]
            {
        (object) "Medium",
        (object) "Low",
        (object) "High"
            });
            this.comboDefensiveWorkrate.Location = new Point(12, 190);
            this.comboDefensiveWorkrate.Name = "comboDefensiveWorkrate";
            this.comboDefensiveWorkrate.Size = new Size(103, 21);
            this.comboDefensiveWorkrate.TabIndex = 135;
            this.label10.AutoSize = true;
            this.label10.BackColor = Color.Transparent;
            this.label10.ImeMode = ImeMode.NoControl;
            this.label10.Location = new Point(13, 174);
            this.label10.Name = "label10";
            this.label10.Size = new Size(102, 13);
            this.label10.TabIndex = 136;
            this.label10.Text = "Defensive Workrate";
            this.label10.TextAlign = ContentAlignment.MiddleLeft;
            this.comboAttackWorkRate.DataBindings.Add(new Binding("SelectedIndex", (object)this.playerBindingSource, "attackingworkrate", true));
            this.comboAttackWorkRate.FormattingEnabled = true;
            this.comboAttackWorkRate.Items.AddRange(new object[3]
            {
        (object) "Medium",
        (object) "Low",
        (object) "High"
            });
            this.comboAttackWorkRate.Location = new Point(12, 145);
            this.comboAttackWorkRate.Name = "comboAttackWorkRate";
            this.comboAttackWorkRate.Size = new Size(103, 21);
            this.comboAttackWorkRate.TabIndex = 133;
            this.label9.AutoSize = true;
            this.label9.BackColor = Color.Transparent;
            this.label9.ImeMode = ImeMode.NoControl;
            this.label9.Location = new Point(15, 129);
            this.label9.Name = "label9";
            this.label9.Size = new Size(99, 13);
            this.label9.TabIndex = 134;
            this.label9.Text = "Attacking Workrate";
            this.label9.TextAlign = ContentAlignment.MiddleLeft;
            this.numericMentalSkills.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.numericMentalSkills.BackColor = Color.Teal;
            this.numericMentalSkills.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold);
            this.numericMentalSkills.ForeColor = Color.FromArgb(192, (int)byte.MaxValue, (int)byte.MaxValue);
            this.numericMentalSkills.Location = new Point(44, 13);
            this.numericMentalSkills.Maximum = new Decimal(new int[4]
            {
        99,
        0,
        0,
        0
            });
            this.numericMentalSkills.Minimum = new Decimal(new int[4]
            {
        1,
        0,
        0,
        0
            });
            this.numericMentalSkills.Name = "numericMentalSkills";
            this.numericMentalSkills.Size = new Size(44, 22);
            this.numericMentalSkills.TabIndex = 0;
            this.numericMentalSkills.TextAlign = HorizontalAlignment.Center;
            this.numericMentalSkills.Value = new Decimal(new int[4]
            {
        99,
        0,
        0,
        0
            });
            this.numericMentalSkills.ValueChanged += new EventHandler(this.numericMentalSkills_ValueChanged);
            this.labelPlayerPositioning.BackColor = SystemColors.Control;
            this.labelPlayerPositioning.Cursor = Cursors.Arrow;
            this.labelPlayerPositioning.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelPlayerPositioning.ForeColor = Color.Yellow;
            this.labelPlayerPositioning.Image = (Image)resources.GetObject("labelPlayerPositioning.Image");
            this.labelPlayerPositioning.ImeMode = ImeMode.NoControl;
            this.labelPlayerPositioning.Location = new Point(16, 86);
            this.labelPlayerPositioning.Name = "labelPlayerPositioning";
            this.labelPlayerPositioning.Size = new Size(112, 16);
            this.labelPlayerPositioning.TabIndex = 120;
            this.labelPlayerPositioning.Text = "Positioning ";
            this.labelPlayerPositioning.TextAlign = ContentAlignment.MiddleCenter;
            this.labelPotential.BackColor = SystemColors.Control;
            this.labelPotential.Cursor = Cursors.Arrow;
            this.labelPotential.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelPotential.ForeColor = Color.Yellow;
            this.labelPotential.Image = (Image)resources.GetObject("labelPotential.Image");
            this.labelPotential.ImeMode = ImeMode.NoControl;
            this.labelPotential.Location = new Point(16, 38);
            this.labelPotential.Name = "labelPotential";
            this.labelPotential.Size = new Size(112, 16);
            this.labelPotential.TabIndex = 118;
            this.labelPotential.Text = "Potential ";
            this.labelPotential.TextAlign = ContentAlignment.MiddleCenter;
            this.trackPlayerPositioning.BackColor = SystemColors.Control;
            this.trackPlayerPositioning.Cursor = Cursors.Arrow;
            this.trackPlayerPositioning.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "positioning", true));
            this.trackPlayerPositioning.ImeMode = ImeMode.NoControl;
            this.trackPlayerPositioning.LargeChange = 10;
            this.trackPlayerPositioning.Location = new Point(8, 94);
            this.trackPlayerPositioning.Maximum = 99;
            this.trackPlayerPositioning.Minimum = 1;
            this.trackPlayerPositioning.Name = "trackPlayerPositioning";
            this.trackPlayerPositioning.Size = new Size(128, 45);
            this.trackPlayerPositioning.TabIndex = 3;
            this.trackPlayerPositioning.TickFrequency = 10;
            this.trackPlayerPositioning.Value = 99;
            this.trackPlayerPositioning.ValueChanged += new EventHandler(this.trackPlayerPositioning_ValueChanged);
            this.trackPotential.BackColor = SystemColors.Control;
            this.trackPotential.Cursor = Cursors.Arrow;
            this.trackPotential.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "potential", true));
            this.trackPotential.ImeMode = ImeMode.NoControl;
            this.trackPotential.LargeChange = 10;
            this.trackPotential.Location = new Point(8, 46);
            this.trackPotential.Maximum = 99;
            this.trackPotential.Minimum = 1;
            this.trackPotential.Name = "trackPotential";
            this.trackPotential.Size = new Size(128, 45);
            this.trackPotential.TabIndex = 1;
            this.trackPotential.TickFrequency = 10;
            this.trackPotential.Value = 99;
            this.trackPotential.ValueChanged += new EventHandler(this.trackPotential_ValueChanged);
            this.groupAttackingSkills.BackColor = SystemColors.Control;
            this.groupAttackingSkills.Controls.Add((Control)this.labelFinishing);
            this.groupAttackingSkills.Controls.Add((Control)this.label6);
            this.groupAttackingSkills.Controls.Add((Control)this.numericUpDown2);
            this.groupAttackingSkills.Controls.Add((Control)this.numericUpDown1);
            this.groupAttackingSkills.Controls.Add((Control)this.labelHeading);
            this.groupAttackingSkills.Controls.Add((Control)this.trackHeading);
            this.groupAttackingSkills.Controls.Add((Control)this.labelVolley);
            this.groupAttackingSkills.Controls.Add((Control)this.trackVolley);
            this.groupAttackingSkills.Controls.Add((Control)this.numericAttackingSkills);
            this.groupAttackingSkills.Controls.Add((Control)this.labelDribbling);
            this.groupAttackingSkills.Controls.Add((Control)this.labelLongShot);
            this.groupAttackingSkills.Controls.Add((Control)this.labelShotPower);
            this.groupAttackingSkills.Controls.Add((Control)this.trackFinishing);
            this.groupAttackingSkills.Controls.Add((Control)this.trackShotPower);
            this.groupAttackingSkills.Controls.Add((Control)this.trackLongShot);
            this.groupAttackingSkills.Controls.Add((Control)this.trackDribbling);
            this.groupAttackingSkills.Location = new Point(721, 3);
            this.groupAttackingSkills.Name = "groupAttackingSkills";
            this.groupAttackingSkills.Size = new Size(140, 378);
            this.groupAttackingSkills.TabIndex = 17;
            this.groupAttackingSkills.TabStop = false;
            this.groupAttackingSkills.Text = "Attacking Skills";
            this.labelFinishing.BackColor = SystemColors.Control;
            this.labelFinishing.Cursor = Cursors.Arrow;
            this.labelFinishing.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelFinishing.ForeColor = Color.Yellow;
            this.labelFinishing.Image = (Image)resources.GetObject("labelFinishing.Image");
            this.labelFinishing.ImeMode = ImeMode.NoControl;
            this.labelFinishing.Location = new Point(14, 280);
            this.labelFinishing.Name = "labelFinishing";
            this.labelFinishing.Size = new Size(112, 16);
            this.labelFinishing.TabIndex = 106;
            this.labelFinishing.Text = "Finishing ";
            this.labelFinishing.TextAlign = ContentAlignment.MiddleCenter;
            this.label6.AutoSize = true;
            this.label6.Location = new Point(31, 327);
            this.label6.Name = "label6";
            this.label6.Size = new Size(79, 13);
            this.label6.TabIndex = 121;
            this.label6.Text = "Finishing Styles";
            this.numericUpDown2.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "finishingcode2", true));
            this.numericUpDown2.Location = new Point(74, 348);
            this.numericUpDown2.Maximum = new Decimal(new int[4]
            {
        (int) sbyte.MaxValue,
        0,
        0,
        0
            });
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new Size(58, 20);
            this.numericUpDown2.TabIndex = 120;
            this.numericUpDown2.TextAlign = HorizontalAlignment.Center;
            this.numericUpDown1.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "finishingcode1", true));
            this.numericUpDown1.Location = new Point(10, 348);
            this.numericUpDown1.Maximum = new Decimal(new int[4]
            {
        (int) sbyte.MaxValue,
        0,
        0,
        0
            });
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new Size(58, 20);
            this.numericUpDown1.TabIndex = 119;
            this.numericUpDown1.TextAlign = HorizontalAlignment.Center;
            this.labelHeading.BackColor = SystemColors.Control;
            this.labelHeading.Cursor = Cursors.Arrow;
            this.labelHeading.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelHeading.ForeColor = Color.Yellow;
            this.labelHeading.Image = (Image)resources.GetObject("labelHeading.Image");
            this.labelHeading.ImeMode = ImeMode.NoControl;
            this.labelHeading.Location = new Point(14, 230);
            this.labelHeading.Name = "labelHeading";
            this.labelHeading.Size = new Size(112, 16);
            this.labelHeading.TabIndex = 98;
            this.labelHeading.Text = "Heading ";
            this.labelHeading.TextAlign = ContentAlignment.MiddleCenter;
            this.trackHeading.BackColor = SystemColors.Control;
            this.trackHeading.Cursor = Cursors.Arrow;
            this.trackHeading.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "headingaccuracy", true));
            this.trackHeading.ImeMode = ImeMode.NoControl;
            this.trackHeading.LargeChange = 10;
            this.trackHeading.Location = new Point(6, 238);
            this.trackHeading.Maximum = 99;
            this.trackHeading.Minimum = 1;
            this.trackHeading.Name = "trackHeading";
            this.trackHeading.Size = new Size(128, 45);
            this.trackHeading.TabIndex = 7;
            this.trackHeading.TickFrequency = 10;
            this.trackHeading.Value = 99;
            this.trackHeading.ValueChanged += new EventHandler(this.trackHeading_ValueChanged);
            this.labelVolley.BackColor = SystemColors.Control;
            this.labelVolley.Cursor = Cursors.Arrow;
            this.labelVolley.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelVolley.ForeColor = Color.Yellow;
            this.labelVolley.Image = (Image)resources.GetObject("labelVolley.Image");
            this.labelVolley.ImeMode = ImeMode.NoControl;
            this.labelVolley.Location = new Point(14, 182);
            this.labelVolley.Name = "labelVolley";
            this.labelVolley.Size = new Size(112, 16);
            this.labelVolley.TabIndex = 118;
            this.labelVolley.Text = "Volley ";
            this.labelVolley.TextAlign = ContentAlignment.MiddleCenter;
            this.trackVolley.BackColor = SystemColors.Control;
            this.trackVolley.Cursor = Cursors.Arrow;
            this.trackVolley.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "volleys", true));
            this.trackVolley.ImeMode = ImeMode.NoControl;
            this.trackVolley.LargeChange = 10;
            this.trackVolley.Location = new Point(6, 190);
            this.trackVolley.Maximum = 99;
            this.trackVolley.Minimum = 1;
            this.trackVolley.Name = "trackVolley";
            this.trackVolley.Size = new Size(128, 45);
            this.trackVolley.TabIndex = 6;
            this.trackVolley.TickFrequency = 10;
            this.trackVolley.Value = 99;
            this.trackVolley.ValueChanged += new EventHandler(this.trackVolley_ValueChanged);
            this.numericAttackingSkills.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.numericAttackingSkills.BackColor = Color.Teal;
            this.numericAttackingSkills.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold);
            this.numericAttackingSkills.ForeColor = Color.FromArgb(192, (int)byte.MaxValue, (int)byte.MaxValue);
            this.numericAttackingSkills.Location = new Point(43, 15);
            this.numericAttackingSkills.Maximum = new Decimal(new int[4]
            {
        99,
        0,
        0,
        0
            });
            this.numericAttackingSkills.Minimum = new Decimal(new int[4]
            {
        1,
        0,
        0,
        0
            });
            this.numericAttackingSkills.Name = "numericAttackingSkills";
            this.numericAttackingSkills.Size = new Size(44, 22);
            this.numericAttackingSkills.TabIndex = 0;
            this.numericAttackingSkills.TextAlign = HorizontalAlignment.Center;
            this.numericAttackingSkills.Value = new Decimal(new int[4]
            {
        99,
        0,
        0,
        0
            });
            this.numericAttackingSkills.ValueChanged += new EventHandler(this.numericAttackingSkills_ValueChanged);
            this.labelDribbling.BackColor = SystemColors.Control;
            this.labelDribbling.Cursor = Cursors.Arrow;
            this.labelDribbling.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelDribbling.ForeColor = Color.Yellow;
            this.labelDribbling.Image = (Image)resources.GetObject("labelDribbling.Image");
            this.labelDribbling.ImeMode = ImeMode.NoControl;
            this.labelDribbling.Location = new Point(14, 136);
            this.labelDribbling.Name = "labelDribbling";
            this.labelDribbling.Size = new Size(112, 16);
            this.labelDribbling.TabIndex = 82;
            this.labelDribbling.Text = "Dribbling ";
            this.labelDribbling.TextAlign = ContentAlignment.MiddleCenter;
            this.labelLongShot.BackColor = SystemColors.Control;
            this.labelLongShot.Cursor = Cursors.Arrow;
            this.labelLongShot.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelLongShot.ForeColor = Color.Yellow;
            this.labelLongShot.Image = (Image)resources.GetObject("labelLongShot.Image");
            this.labelLongShot.ImeMode = ImeMode.NoControl;
            this.labelLongShot.Location = new Point(14, 88);
            this.labelLongShot.Name = "labelLongShot";
            this.labelLongShot.Size = new Size(112, 16);
            this.labelLongShot.TabIndex = 104;
            this.labelLongShot.Text = "Long-Shot ";
            this.labelLongShot.TextAlign = ContentAlignment.MiddleCenter;
            this.labelShotPower.BackColor = SystemColors.Control;
            this.labelShotPower.Cursor = Cursors.Arrow;
            this.labelShotPower.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelShotPower.ForeColor = Color.Yellow;
            this.labelShotPower.Image = (Image)resources.GetObject("labelShotPower.Image");
            this.labelShotPower.ImeMode = ImeMode.NoControl;
            this.labelShotPower.Location = new Point(14, 40);
            this.labelShotPower.Name = "labelShotPower";
            this.labelShotPower.Size = new Size(112, 16);
            this.labelShotPower.TabIndex = 108;
            this.labelShotPower.Text = "Shot-Power ";
            this.labelShotPower.TextAlign = ContentAlignment.MiddleCenter;
            this.trackFinishing.BackColor = SystemColors.Control;
            this.trackFinishing.Cursor = Cursors.Arrow;
            this.trackFinishing.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "finishing", true));
            this.trackFinishing.ImeMode = ImeMode.NoControl;
            this.trackFinishing.LargeChange = 10;
            this.trackFinishing.Location = new Point(6, 288);
            this.trackFinishing.Maximum = 99;
            this.trackFinishing.Minimum = 1;
            this.trackFinishing.Name = "trackFinishing";
            this.trackFinishing.Size = new Size(128, 45);
            this.trackFinishing.TabIndex = 1;
            this.trackFinishing.TickFrequency = 10;
            this.trackFinishing.Value = 99;
            this.trackFinishing.ValueChanged += new EventHandler(this.trackFinishing_ValueChanged);
            this.trackShotPower.BackColor = SystemColors.Control;
            this.trackShotPower.Cursor = Cursors.Arrow;
            this.trackShotPower.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "shotpower", true));
            this.trackShotPower.ImeMode = ImeMode.NoControl;
            this.trackShotPower.LargeChange = 10;
            this.trackShotPower.Location = new Point(6, 48);
            this.trackShotPower.Maximum = 99;
            this.trackShotPower.Minimum = 1;
            this.trackShotPower.Name = "trackShotPower";
            this.trackShotPower.Size = new Size(128, 45);
            this.trackShotPower.TabIndex = 2;
            this.trackShotPower.TickFrequency = 10;
            this.trackShotPower.Value = 99;
            this.trackShotPower.ValueChanged += new EventHandler(this.trackShotPower_ValueChanged);
            this.trackLongShot.BackColor = SystemColors.Control;
            this.trackLongShot.Cursor = Cursors.Arrow;
            this.trackLongShot.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "longshots", true));
            this.trackLongShot.ImeMode = ImeMode.NoControl;
            this.trackLongShot.LargeChange = 10;
            this.trackLongShot.Location = new Point(6, 96);
            this.trackLongShot.Maximum = 99;
            this.trackLongShot.Minimum = 1;
            this.trackLongShot.Name = "trackLongShot";
            this.trackLongShot.Size = new Size(128, 45);
            this.trackLongShot.TabIndex = 3;
            this.trackLongShot.TickFrequency = 10;
            this.trackLongShot.Value = 99;
            this.trackLongShot.ValueChanged += new EventHandler(this.trackLongShot_ValueChanged);
            this.trackDribbling.BackColor = SystemColors.Control;
            this.trackDribbling.Cursor = Cursors.Arrow;
            this.trackDribbling.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "dribbling", true));
            this.trackDribbling.ImeMode = ImeMode.NoControl;
            this.trackDribbling.LargeChange = 10;
            this.trackDribbling.Location = new Point(6, 144);
            this.trackDribbling.Maximum = 99;
            this.trackDribbling.Minimum = 1;
            this.trackDribbling.Name = "trackDribbling";
            this.trackDribbling.Size = new Size(128, 45);
            this.trackDribbling.TabIndex = 4;
            this.trackDribbling.TickFrequency = 10;
            this.trackDribbling.Value = 99;
            this.trackDribbling.ValueChanged += new EventHandler(this.trackDribbling_ValueChanged);
            this.groupGenericAttributes.BackColor = SystemColors.Control;
            this.groupGenericAttributes.Controls.Add((Control)this.label7);
            this.groupGenericAttributes.Controls.Add((Control)this.numericUpDown3);
            this.groupGenericAttributes.Controls.Add((Control)this.numericUpDown4);
            this.groupGenericAttributes.Controls.Add((Control)this.labelJumping);
            this.groupGenericAttributes.Controls.Add((Control)this.labelBalance);
            this.groupGenericAttributes.Controls.Add((Control)this.trackBalance);
            this.groupGenericAttributes.Controls.Add((Control)this.labelAgility);
            this.groupGenericAttributes.Controls.Add((Control)this.trackAgility);
            this.groupGenericAttributes.Controls.Add((Control)this.numericPhysicalSkills);
            this.groupGenericAttributes.Controls.Add((Control)this.labelReactions);
            this.groupGenericAttributes.Controls.Add((Control)this.labelStrength);
            this.groupGenericAttributes.Controls.Add((Control)this.labelStamina);
            this.groupGenericAttributes.Controls.Add((Control)this.trackStamina);
            this.groupGenericAttributes.Controls.Add((Control)this.labelSprintSpeed);
            this.groupGenericAttributes.Controls.Add((Control)this.trackSprintSpeed);
            this.groupGenericAttributes.Controls.Add((Control)this.labelAcceleration);
            this.groupGenericAttributes.Controls.Add((Control)this.trackAcceleration);
            this.groupGenericAttributes.Controls.Add((Control)this.trackStrength);
            this.groupGenericAttributes.Controls.Add((Control)this.trackReactions);
            this.groupGenericAttributes.Controls.Add((Control)this.trackJumping);
            this.groupGenericAttributes.Location = new Point(867, 3);
            this.groupGenericAttributes.Name = "groupGenericAttributes";
            this.groupGenericAttributes.Size = new Size(268, 378);
            this.groupGenericAttributes.TabIndex = 18;
            this.groupGenericAttributes.TabStop = false;
            this.groupGenericAttributes.Text = "Physical Skills";
            this.label7.AutoSize = true;
            this.label7.Location = new Point(30, 327);
            this.label7.Name = "label7";
            this.label7.Size = new Size(78, 13);
            this.label7.TabIndex = 133;
            this.label7.Text = "Running Styles";
            this.numericUpDown3.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "runningcode2", true));
            this.numericUpDown3.Location = new Point(73, 348);
            this.numericUpDown3.Maximum = new Decimal(new int[4]
            {
        (int) sbyte.MaxValue,
        0,
        0,
        0
            });
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new Size(58, 20);
            this.numericUpDown3.TabIndex = 132;
            this.numericUpDown3.TextAlign = HorizontalAlignment.Center;
            this.numericUpDown4.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "runningcode1", true));
            this.numericUpDown4.Location = new Point(9, 348);
            this.numericUpDown4.Maximum = new Decimal(new int[4]
            {
        (int) sbyte.MaxValue,
        0,
        0,
        0
            });
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new Size(58, 20);
            this.numericUpDown4.TabIndex = 131;
            this.numericUpDown4.TextAlign = HorizontalAlignment.Center;
            this.labelJumping.BackColor = SystemColors.Control;
            this.labelJumping.Cursor = Cursors.Arrow;
            this.labelJumping.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelJumping.ForeColor = Color.Yellow;
            this.labelJumping.Image = (Image)resources.GetObject("labelJumping.Image");
            this.labelJumping.ImeMode = ImeMode.NoControl;
            this.labelJumping.Location = new Point(12, 280);
            this.labelJumping.Name = "labelJumping";
            this.labelJumping.Size = new Size(112, 16);
            this.labelJumping.TabIndex = 130;
            this.labelJumping.Text = "Jumping ";
            this.labelJumping.TextAlign = ContentAlignment.MiddleCenter;
            this.labelBalance.BackColor = SystemColors.Control;
            this.labelBalance.Cursor = Cursors.Arrow;
            this.labelBalance.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelBalance.ForeColor = Color.Yellow;
            this.labelBalance.Image = (Image)resources.GetObject("labelBalance.Image");
            this.labelBalance.ImeMode = ImeMode.NoControl;
            this.labelBalance.Location = new Point(148, 86);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new Size(112, 16);
            this.labelBalance.TabIndex = 128;
            this.labelBalance.Text = "Balance ";
            this.labelBalance.TextAlign = ContentAlignment.MiddleCenter;
            this.trackBalance.BackColor = SystemColors.Control;
            this.trackBalance.Cursor = Cursors.Arrow;
            this.trackBalance.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "balance", true));
            this.trackBalance.ImeMode = ImeMode.NoControl;
            this.trackBalance.LargeChange = 10;
            this.trackBalance.Location = new Point(140, 94);
            this.trackBalance.Maximum = 99;
            this.trackBalance.Minimum = 1;
            this.trackBalance.Name = "trackBalance";
            this.trackBalance.Size = new Size(128, 45);
            this.trackBalance.TabIndex = 8;
            this.trackBalance.TickFrequency = 10;
            this.trackBalance.Value = 99;
            this.trackBalance.ValueChanged += new EventHandler(this.trackBalance_ValueChanged);
            this.labelAgility.BackColor = SystemColors.Control;
            this.labelAgility.Cursor = Cursors.Arrow;
            this.labelAgility.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelAgility.ForeColor = Color.Yellow;
            this.labelAgility.Image = (Image)resources.GetObject("labelAgility.Image");
            this.labelAgility.ImeMode = ImeMode.NoControl;
            this.labelAgility.Location = new Point(12, 232);
            this.labelAgility.Name = "labelAgility";
            this.labelAgility.Size = new Size(112, 16);
            this.labelAgility.TabIndex = 126;
            this.labelAgility.Text = "Agility ";
            this.labelAgility.TextAlign = ContentAlignment.MiddleCenter;
            this.trackAgility.BackColor = SystemColors.Control;
            this.trackAgility.Cursor = Cursors.Arrow;
            this.trackAgility.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "agility", true));
            this.trackAgility.ImeMode = ImeMode.NoControl;
            this.trackAgility.LargeChange = 10;
            this.trackAgility.Location = new Point(4, 240);
            this.trackAgility.Maximum = 99;
            this.trackAgility.Minimum = 1;
            this.trackAgility.Name = "trackAgility";
            this.trackAgility.Size = new Size(128, 45);
            this.trackAgility.TabIndex = 5;
            this.trackAgility.TickFrequency = 10;
            this.trackAgility.Value = 99;
            this.trackAgility.ValueChanged += new EventHandler(this.trackAgility_ValueChanged);
            this.numericPhysicalSkills.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.numericPhysicalSkills.BackColor = Color.Teal;
            this.numericPhysicalSkills.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold);
            this.numericPhysicalSkills.ForeColor = Color.FromArgb(192, (int)byte.MaxValue, (int)byte.MaxValue);
            this.numericPhysicalSkills.Location = new Point(114, 15);
            this.numericPhysicalSkills.Maximum = new Decimal(new int[4]
            {
        99,
        0,
        0,
        0
            });
            this.numericPhysicalSkills.Minimum = new Decimal(new int[4]
            {
        1,
        0,
        0,
        0
            });
            this.numericPhysicalSkills.Name = "numericPhysicalSkills";
            this.numericPhysicalSkills.Size = new Size(44, 22);
            this.numericPhysicalSkills.TabIndex = 0;
            this.numericPhysicalSkills.TextAlign = HorizontalAlignment.Center;
            this.numericPhysicalSkills.Value = new Decimal(new int[4]
            {
        99,
        0,
        0,
        0
            });
            this.numericPhysicalSkills.ValueChanged += new EventHandler(this.numericGenericSkills_ValueChanged);
            this.labelReactions.BackColor = SystemColors.Control;
            this.labelReactions.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelReactions.ForeColor = Color.Yellow;
            this.labelReactions.Image = (Image)resources.GetObject("labelReactions.Image");
            this.labelReactions.ImeMode = ImeMode.NoControl;
            this.labelReactions.Location = new Point(148, 40);
            this.labelReactions.Name = "labelReactions";
            this.labelReactions.Size = new Size(112, 16);
            this.labelReactions.TabIndex = 82;
            this.labelReactions.Text = "Reactions ";
            this.labelReactions.TextAlign = ContentAlignment.MiddleCenter;
            this.labelStrength.BackColor = SystemColors.Control;
            this.labelStrength.Cursor = Cursors.Arrow;
            this.labelStrength.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelStrength.ForeColor = Color.Yellow;
            this.labelStrength.Image = (Image)resources.GetObject("labelStrength.Image");
            this.labelStrength.ImeMode = ImeMode.NoControl;
            this.labelStrength.Location = new Point(12, 184);
            this.labelStrength.Name = "labelStrength";
            this.labelStrength.Size = new Size(112, 16);
            this.labelStrength.TabIndex = 73;
            this.labelStrength.Text = "Strength ";
            this.labelStrength.TextAlign = ContentAlignment.MiddleCenter;
            this.labelStamina.BackColor = SystemColors.Control;
            this.labelStamina.Cursor = Cursors.Arrow;
            this.labelStamina.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelStamina.ForeColor = Color.Yellow;
            this.labelStamina.Image = (Image)resources.GetObject("labelStamina.Image");
            this.labelStamina.ImeMode = ImeMode.NoControl;
            this.labelStamina.Location = new Point(12, 134);
            this.labelStamina.Name = "labelStamina";
            this.labelStamina.Size = new Size(112, 16);
            this.labelStamina.TabIndex = 71;
            this.labelStamina.Text = "Stamina ";
            this.labelStamina.TextAlign = ContentAlignment.MiddleCenter;
            this.trackStamina.BackColor = SystemColors.Control;
            this.trackStamina.Cursor = Cursors.Arrow;
            this.trackStamina.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "stamina", true));
            this.trackStamina.ImeMode = ImeMode.NoControl;
            this.trackStamina.LargeChange = 10;
            this.trackStamina.Location = new Point(4, 142);
            this.trackStamina.Maximum = 99;
            this.trackStamina.Minimum = 1;
            this.trackStamina.Name = "trackStamina";
            this.trackStamina.Size = new Size(128, 45);
            this.trackStamina.TabIndex = 3;
            this.trackStamina.TickFrequency = 10;
            this.trackStamina.Value = 99;
            this.trackStamina.ValueChanged += new EventHandler(this.trackStamina_ValueChanged);
            this.labelSprintSpeed.BackColor = SystemColors.Control;
            this.labelSprintSpeed.Cursor = Cursors.Arrow;
            this.labelSprintSpeed.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelSprintSpeed.ForeColor = Color.Yellow;
            this.labelSprintSpeed.Image = (Image)resources.GetObject("labelSprintSpeed.Image");
            this.labelSprintSpeed.ImeMode = ImeMode.NoControl;
            this.labelSprintSpeed.Location = new Point(12, 88);
            this.labelSprintSpeed.Name = "labelSprintSpeed";
            this.labelSprintSpeed.Size = new Size(112, 16);
            this.labelSprintSpeed.TabIndex = 69;
            this.labelSprintSpeed.Text = "Sprint-Speed ";
            this.labelSprintSpeed.TextAlign = ContentAlignment.MiddleCenter;
            this.trackSprintSpeed.BackColor = SystemColors.Control;
            this.trackSprintSpeed.Cursor = Cursors.Arrow;
            this.trackSprintSpeed.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "sprintspeed", true));
            this.trackSprintSpeed.ImeMode = ImeMode.NoControl;
            this.trackSprintSpeed.LargeChange = 10;
            this.trackSprintSpeed.Location = new Point(4, 96);
            this.trackSprintSpeed.Maximum = 99;
            this.trackSprintSpeed.Minimum = 1;
            this.trackSprintSpeed.Name = "trackSprintSpeed";
            this.trackSprintSpeed.Size = new Size(128, 45);
            this.trackSprintSpeed.TabIndex = 2;
            this.trackSprintSpeed.TickFrequency = 10;
            this.trackSprintSpeed.Value = 99;
            this.trackSprintSpeed.ValueChanged += new EventHandler(this.trackSprintSpeed_ValueChanged);
            this.labelAcceleration.BackColor = SystemColors.Control;
            this.labelAcceleration.Cursor = Cursors.Arrow;
            this.labelAcceleration.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelAcceleration.ForeColor = Color.Yellow;
            this.labelAcceleration.Image = (Image)resources.GetObject("labelAcceleration.Image");
            this.labelAcceleration.ImeMode = ImeMode.NoControl;
            this.labelAcceleration.Location = new Point(12, 40);
            this.labelAcceleration.Name = "labelAcceleration";
            this.labelAcceleration.Size = new Size(112, 16);
            this.labelAcceleration.TabIndex = 65;
            this.labelAcceleration.Text = "Acceleration ";
            this.labelAcceleration.TextAlign = ContentAlignment.MiddleCenter;
            this.trackAcceleration.BackColor = SystemColors.Control;
            this.trackAcceleration.Cursor = Cursors.Arrow;
            this.trackAcceleration.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "acceleration", true));
            this.trackAcceleration.ImeMode = ImeMode.NoControl;
            this.trackAcceleration.LargeChange = 10;
            this.trackAcceleration.Location = new Point(4, 48);
            this.trackAcceleration.Maximum = 99;
            this.trackAcceleration.Minimum = 1;
            this.trackAcceleration.Name = "trackAcceleration";
            this.trackAcceleration.Size = new Size(128, 45);
            this.trackAcceleration.TabIndex = 1;
            this.trackAcceleration.TickFrequency = 10;
            this.trackAcceleration.Value = 99;
            this.trackAcceleration.ValueChanged += new EventHandler(this.trackAcceleration_ValueChanged);
            this.trackStrength.BackColor = SystemColors.Control;
            this.trackStrength.Cursor = Cursors.Arrow;
            this.trackStrength.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "strength", true));
            this.trackStrength.ImeMode = ImeMode.NoControl;
            this.trackStrength.LargeChange = 10;
            this.trackStrength.Location = new Point(4, 192);
            this.trackStrength.Maximum = 99;
            this.trackStrength.Minimum = 1;
            this.trackStrength.Name = "trackStrength";
            this.trackStrength.Size = new Size(128, 45);
            this.trackStrength.TabIndex = 4;
            this.trackStrength.TickFrequency = 10;
            this.trackStrength.Value = 99;
            this.trackStrength.ValueChanged += new EventHandler(this.trackStrength_ValueChanged);
            this.trackReactions.BackColor = SystemColors.Control;
            this.trackReactions.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "reactions", true));
            this.trackReactions.ImeMode = ImeMode.NoControl;
            this.trackReactions.LargeChange = 10;
            this.trackReactions.Location = new Point(139, 48);
            this.trackReactions.Maximum = 99;
            this.trackReactions.Minimum = 1;
            this.trackReactions.Name = "trackReactions";
            this.trackReactions.Size = new Size(128, 45);
            this.trackReactions.TabIndex = 7;
            this.trackReactions.TickFrequency = 10;
            this.trackReactions.Value = 99;
            this.trackReactions.ValueChanged += new EventHandler(this.trackReactions_ValueChanged);
            this.trackJumping.BackColor = SystemColors.Control;
            this.trackJumping.Cursor = Cursors.Arrow;
            this.trackJumping.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "jumping", true));
            this.trackJumping.ImeMode = ImeMode.NoControl;
            this.trackJumping.LargeChange = 10;
            this.trackJumping.Location = new Point(4, 288);
            this.trackJumping.Maximum = 99;
            this.trackJumping.Minimum = 1;
            this.trackJumping.Name = "trackJumping";
            this.trackJumping.Size = new Size(128, 45);
            this.trackJumping.TabIndex = 6;
            this.trackJumping.TickFrequency = 10;
            this.trackJumping.Value = 99;
            this.trackJumping.ValueChanged += new EventHandler(this.trackJumping_ValueChanged);
            this.groupFreeKick.BackColor = SystemColors.Control;
            this.groupFreeKick.Controls.Add((Control)this.labelSkillsStars);
            this.groupFreeKick.Controls.Add((Control)this.numericSkillMoves);
            this.groupFreeKick.Controls.Add((Control)this.labelSkillMoves);
            this.groupFreeKick.Controls.Add((Control)this.numericFreeKickSkills);
            this.groupFreeKick.Controls.Add((Control)this.labelPenalties);
            this.groupFreeKick.Controls.Add((Control)this.labelFreeKick);
            this.groupFreeKick.Controls.Add((Control)this.trackFreeKick);
            this.groupFreeKick.Controls.Add((Control)this.trackPenalties);
            this.groupFreeKick.Controls.Add((Control)this.labelPenaltyKick);
            this.groupFreeKick.Controls.Add((Control)this.comboPenaltyKick);
            this.groupFreeKick.Controls.Add((Control)this.labelPenaltyMove);
            this.groupFreeKick.Controls.Add((Control)this.comboPenaltyMove);
            this.groupFreeKick.Controls.Add((Control)this.labelFreeKickStart);
            this.groupFreeKick.Controls.Add((Control)this.labelPenaltyStart);
            this.groupFreeKick.Controls.Add((Control)this.comboFreeKickStart);
            this.groupFreeKick.Controls.Add((Control)this.comboPenaltyStart);
            this.groupFreeKick.Location = new Point(3, 387);
            this.groupFreeKick.Name = "groupFreeKick";
            this.groupFreeKick.Size = new Size(250, 309);
            this.groupFreeKick.TabIndex = 28;
            this.groupFreeKick.TabStop = false;
            this.groupFreeKick.Text = "Free Kick Skills";
            this.labelSkillsStars.ImageList = this.imageListStars;
            this.labelSkillsStars.Location = new Point(118, 148);
            this.labelSkillsStars.Name = "labelSkillsStars";
            this.labelSkillsStars.Size = new Size(117, 23);
            this.labelSkillsStars.TabIndex = 156;
            this.imageListStars.ImageStream = (ImageListStreamer)resources.GetObject("imageListStars.ImageStream");
            this.imageListStars.TransparentColor = Color.Fuchsia;
            this.imageListStars.Images.SetKeyName(0, "Stars_1.PNG");
            this.imageListStars.Images.SetKeyName(1, "Stars_2.PNG");
            this.imageListStars.Images.SetKeyName(2, "Stars_3.PNG");
            this.imageListStars.Images.SetKeyName(3, "Stars_4.PNG");
            this.imageListStars.Images.SetKeyName(4, "Stars_5.PNG");
            this.numericSkillMoves.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "skillmoves", true));
            this.numericSkillMoves.Location = new Point(69, 151);
            this.numericSkillMoves.Maximum = new Decimal(new int[4]
            {
        4,
        0,
        0,
        0
            });
            this.numericSkillMoves.Name = "numericSkillMoves";
            this.numericSkillMoves.Size = new Size(43, 20);
            this.numericSkillMoves.TabIndex = 3;
            this.numericSkillMoves.TextAlign = HorizontalAlignment.Center;
            this.numericSkillMoves.ValueChanged += new EventHandler(this.numericSkillMoves_ValueChanged);
            this.labelSkillMoves.AutoSize = true;
            this.labelSkillMoves.Location = new Point(8, 153);
            this.labelSkillMoves.Name = "labelSkillMoves";
            this.labelSkillMoves.Size = new Size(61, 13);
            this.labelSkillMoves.TabIndex = 154;
            this.labelSkillMoves.Text = "Skill Moves";
            this.numericFreeKickSkills.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.numericFreeKickSkills.BackColor = Color.Teal;
            this.numericFreeKickSkills.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold);
            this.numericFreeKickSkills.ForeColor = Color.FromArgb(192, (int)byte.MaxValue, (int)byte.MaxValue);
            this.numericFreeKickSkills.Location = new Point(50, 15);
            this.numericFreeKickSkills.Maximum = new Decimal(new int[4]
            {
        99,
        0,
        0,
        0
            });
            this.numericFreeKickSkills.Minimum = new Decimal(new int[4]
            {
        1,
        0,
        0,
        0
            });
            this.numericFreeKickSkills.Name = "numericFreeKickSkills";
            this.numericFreeKickSkills.Size = new Size(44, 22);
            this.numericFreeKickSkills.TabIndex = 0;
            this.numericFreeKickSkills.TextAlign = HorizontalAlignment.Center;
            this.numericFreeKickSkills.Value = new Decimal(new int[4]
            {
        99,
        0,
        0,
        0
            });
            this.numericFreeKickSkills.ValueChanged += new EventHandler(this.numericFreeKickSkills_ValueChanged);
            this.labelPenalties.BackColor = SystemColors.Control;
            this.labelPenalties.Cursor = Cursors.Arrow;
            this.labelPenalties.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelPenalties.ForeColor = Color.Yellow;
            this.labelPenalties.Image = (Image)resources.GetObject("labelPenalties.Image");
            this.labelPenalties.ImeMode = ImeMode.NoControl;
            this.labelPenalties.Location = new Point(16, 88);
            this.labelPenalties.Name = "labelPenalties";
            this.labelPenalties.Size = new Size(112, 16);
            this.labelPenalties.TabIndex = 116;
            this.labelPenalties.Text = "Penalties ";
            this.labelPenalties.TextAlign = ContentAlignment.MiddleCenter;
            this.labelFreeKick.BackColor = SystemColors.Control;
            this.labelFreeKick.Cursor = Cursors.Arrow;
            this.labelFreeKick.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            this.labelFreeKick.ForeColor = Color.Yellow;
            this.labelFreeKick.Image = (Image)resources.GetObject("labelFreeKick.Image");
            this.labelFreeKick.ImeMode = ImeMode.NoControl;
            this.labelFreeKick.Location = new Point(16, 40);
            this.labelFreeKick.Name = "labelFreeKick";
            this.labelFreeKick.Size = new Size(112, 16);
            this.labelFreeKick.TabIndex = 112;
            this.labelFreeKick.Text = "Free-Kick ";
            this.labelFreeKick.TextAlign = ContentAlignment.MiddleCenter;
            this.trackFreeKick.BackColor = SystemColors.Control;
            this.trackFreeKick.Cursor = Cursors.Arrow;
            this.trackFreeKick.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "freekickaccuracy", true));
            this.trackFreeKick.ImeMode = ImeMode.NoControl;
            this.trackFreeKick.LargeChange = 10;
            this.trackFreeKick.Location = new Point(8, 48);
            this.trackFreeKick.Maximum = 99;
            this.trackFreeKick.Minimum = 1;
            this.trackFreeKick.Name = "trackFreeKick";
            this.trackFreeKick.Size = new Size(128, 45);
            this.trackFreeKick.TabIndex = 1;
            this.trackFreeKick.TickFrequency = 10;
            this.trackFreeKick.Value = 99;
            this.trackFreeKick.ValueChanged += new EventHandler(this.trackFreeKick_ValueChanged);
            this.trackPenalties.BackColor = SystemColors.Control;
            this.trackPenalties.Cursor = Cursors.Arrow;
            this.trackPenalties.DataBindings.Add(new Binding("Value", (object)this.playerBindingSource, "penalties", true));
            this.trackPenalties.ImeMode = ImeMode.NoControl;
            this.trackPenalties.LargeChange = 10;
            this.trackPenalties.Location = new Point(8, 96);
            this.trackPenalties.Maximum = 99;
            this.trackPenalties.Minimum = 1;
            this.trackPenalties.Name = "trackPenalties";
            this.trackPenalties.Size = new Size(128, 45);
            this.trackPenalties.TabIndex = 2;
            this.trackPenalties.TickFrequency = 10;
            this.trackPenalties.Value = 99;
            this.trackPenalties.ValueChanged += new EventHandler(this.trackPenalties_ValueChanged);
            this.labelPenaltyKick.AutoSize = true;
            this.labelPenaltyKick.ImeMode = ImeMode.NoControl;
            this.labelPenaltyKick.Location = new Point(6, 259);
            this.labelPenaltyKick.Name = "labelPenaltyKick";
            this.labelPenaltyKick.Size = new Size(66, 13);
            this.labelPenaltyKick.TabIndex = 153;
            this.labelPenaltyKick.Text = "Penalty Kick";
            this.labelPenaltyKick.TextAlign = ContentAlignment.MiddleLeft;
            this.comboPenaltyKick.DataBindings.Add(new Binding("SelectedIndex", (object)this.playerBindingSource, "animpenaltieskickstylecode", true));
            this.comboPenaltyKick.FormattingEnabled = true;
            this.comboPenaltyKick.Items.AddRange(new object[3]
            {
        (object) "Normal",
        (object) "Finesse Shot",
        (object) "Powerful Shot"
            });
            this.comboPenaltyKick.Location = new Point(89, 253);
            this.comboPenaltyKick.Name = "comboPenaltyKick";
            this.comboPenaltyKick.Size = new Size(139, 21);
            this.comboPenaltyKick.TabIndex = 7;
            this.labelPenaltyMove.AutoSize = true;
            this.labelPenaltyMove.ImeMode = ImeMode.NoControl;
            this.labelPenaltyMove.Location = new Point(6, 235);
            this.labelPenaltyMove.Name = "labelPenaltyMove";
            this.labelPenaltyMove.Size = new Size(72, 13);
            this.labelPenaltyMove.TabIndex = 151;
            this.labelPenaltyMove.Text = "Penalty Move";
            this.labelPenaltyMove.TextAlign = ContentAlignment.MiddleLeft;
            this.comboPenaltyMove.DataBindings.Add(new Binding("SelectedIndex", (object)this.playerBindingSource, "animpenaltiesmotionstylecode", true));
            this.comboPenaltyMove.FormattingEnabled = true;
            this.comboPenaltyMove.Items.AddRange(new object[7]
            {
        (object) "Continuous Motion",
        (object) "Start/Stop Motion",
        (object) "Henry's style",
        (object) "Unknown style",
        (object) "Lampard's style",
        (object) "Podolski's style",
        (object) "Ronaldinho's style"
            });
            this.comboPenaltyMove.Location = new Point(89, 229);
            this.comboPenaltyMove.Name = "comboPenaltyMove";
            this.comboPenaltyMove.Size = new Size(139, 21);
            this.comboPenaltyMove.TabIndex = 6;
            this.labelFreeKickStart.AutoSize = true;
            this.labelFreeKickStart.ImeMode = ImeMode.NoControl;
            this.labelFreeKickStart.Location = new Point(6, 189);
            this.labelFreeKickStart.Name = "labelFreeKickStart";
            this.labelFreeKickStart.Size = new Size(77, 13);
            this.labelFreeKickStart.TabIndex = 147;
            this.labelFreeKickStart.Text = "Free Kick Start";
            this.labelFreeKickStart.TextAlign = ContentAlignment.MiddleLeft;
            this.labelPenaltyStart.AutoSize = true;
            this.labelPenaltyStart.ImeMode = ImeMode.NoControl;
            this.labelPenaltyStart.Location = new Point(6, 212);
            this.labelPenaltyStart.Name = "labelPenaltyStart";
            this.labelPenaltyStart.Size = new Size(67, 13);
            this.labelPenaltyStart.TabIndex = 149;
            this.labelPenaltyStart.Text = "Penalty Start";
            this.labelPenaltyStart.TextAlign = ContentAlignment.MiddleLeft;
            this.comboFreeKickStart.DataBindings.Add(new Binding("SelectedIndex", (object)this.playerBindingSource, "animfreekickstartposcode", true));
            this.comboFreeKickStart.FormattingEnabled = true;
            this.comboFreeKickStart.Items.AddRange(new object[10]
            {
        (object) "Normal",
        (object) "Long run-up",
        (object) "90 degrees from ball",
        (object) "Henry's style",
        (object) "Beckham's style",
        (object) "Lampard's style",
        (object) "Adriano's style",
        (object) "Cristiano Ronaldo's style",
        (object) "Juninho's style",
        (object) "Ronaldinho's style"
            });
            this.comboFreeKickStart.Location = new Point(89, 183);
            this.comboFreeKickStart.Name = "comboFreeKickStart";
            this.comboFreeKickStart.Size = new Size(139, 21);
            this.comboFreeKickStart.TabIndex = 4;
            this.comboPenaltyStart.DataBindings.Add(new Binding("SelectedIndex", (object)this.playerBindingSource, "animpenaltiesstartposcode", true));
            this.comboPenaltyStart.FormattingEnabled = true;
            this.comboPenaltyStart.Items.AddRange(new object[9]
            {
        (object) "Edge of the penalty box",
        (object) "Close to the ball",
        (object) "Outside the penalty box",
        (object) "Henry's style",
        (object) "Unknown style",
        (object) "Lampard's style",
        (object) "Podolski's style",
        (object) "Ronaldinho's style",
        (object) "Cristiano Ronaldo's style"
            });
            this.comboPenaltyStart.Location = new Point(89, 206);
            this.comboPenaltyStart.Name = "comboPenaltyStart";
            this.comboPenaltyStart.Size = new Size(139, 21);
            this.comboPenaltyStart.TabIndex = 5;
            this.groupTraits.Controls.Add((Control)this.groupBox2);
            this.groupTraits.Controls.Add((Control)this.checkGKOneonOne);
            this.groupTraits.Controls.Add((Control)this.checkAcrobaticClearance);
            this.groupTraits.Controls.Add((Control)this.checkSecondWind);
            this.groupTraits.Controls.Add((Control)this.checkCrowdFavourite);
            this.groupTraits.Controls.Add((Control)this.checkInflexible);
            this.groupTraits.Controls.Add((Control)this.checkTeamPlayer);
            this.groupTraits.Controls.Add((Control)this.checkSwervePasser);
            this.groupTraits.Controls.Add((Control)this.checkCornerSpecialist);
            this.groupTraits.Controls.Add((Control)this.checkPowerHeader);
            this.groupTraits.Controls.Add((Control)this.checkGkLongThrower);
            this.groupTraits.Controls.Add((Control)this.checkLongPasser);
            this.groupTraits.Controls.Add((Control)this.checkFlair);
            this.groupTraits.Controls.Add((Control)this.checkFinesseShot);
            this.groupTraits.Controls.Add((Control)this.checkArguesWithOfficials);
            this.groupTraits.Controls.Add((Control)this.checkBeatsOffsideTrap);
            this.groupTraits.Controls.Add((Control)this.checkAvoidsWeakFoot);
            this.groupTraits.Controls.Add((Control)this.checkInjuryFree);
            this.groupTraits.Controls.Add((Control)this.checkPowerFreeKick);
            this.groupTraits.Controls.Add((Control)this.checkSelfish);
            this.groupTraits.Controls.Add((Control)this.checkPlaymaker);
            this.groupTraits.Controls.Add((Control)this.checkTechnicaldribbler);
            this.groupTraits.Controls.Add((Control)this.checkLeadership);
            this.groupTraits.Controls.Add((Control)this.checkPuncher);
            this.groupTraits.Controls.Add((Control)this.checkDiver);
            this.groupTraits.Controls.Add((Control)this.checkDivesintotackles);
            this.groupTraits.Controls.Add((Control)this.checkLongshottaker);
            this.groupTraits.Controls.Add((Control)this.checkHighClubIdentification);
            this.groupTraits.Controls.Add((Control)this.checkPushesupforcorners);
            this.groupTraits.Controls.Add((Control)this.checkEarlycrosser);
            this.groupTraits.Controls.Add((Control)this.checkInjuryProne);
            this.groupTraits.Controls.Add((Control)this.checkGiantThrower);
            this.groupTraits.Controls.Add((Control)this.checkLongThrower);
            this.groupTraits.Location = new Point(259, 387);
            this.groupTraits.Name = "groupTraits";
            this.groupTraits.Size = new Size(619, 309);
            this.groupTraits.TabIndex = 30;
            this.groupTraits.TabStop = false;
            this.groupTraits.Text = "Traits";
            this.groupBox2.Controls.Add((Control)this.checkGKFlatKick);
            this.groupBox2.Controls.Add((Control)this.checkDrivenPass);
            this.groupBox2.Controls.Add((Control)this.checkDivingHeader);
            this.groupBox2.Controls.Add((Control)this.checkBycicleKick);
            this.groupBox2.Controls.Add((Control)this.checkChipperPenalty);
            this.groupBox2.Controls.Add((Control)this.checkStutterPenalty);
            this.groupBox2.Controls.Add((Control)this.checkFancyFlicks);
            this.groupBox2.Controls.Add((Control)this.checkFancyPasses);
            this.groupBox2.Controls.Add((Control)this.checkFancyFeet);
            this.groupBox2.Location = new Point(472, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(130, 284);
            this.groupBox2.TabIndex = 57;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Virtual Pro";
            this.checkGKFlatKick.AutoSize = true;
            this.checkGKFlatKick.BackColor = Color.Transparent;
            this.checkGKFlatKick.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "GkFlatKick", true));
            this.checkGKFlatKick.ImeMode = ImeMode.NoControl;
            this.checkGKFlatKick.Location = new Point(16, 216);
            this.checkGKFlatKick.Name = "checkGKFlatKick";
            this.checkGKFlatKick.Size = new Size(85, 17);
            this.checkGKFlatKick.TabIndex = 51;
            this.checkGKFlatKick.Text = "GK Flat Kick";
            this.checkGKFlatKick.UseVisualStyleBackColor = false;
            this.checkDrivenPass.AutoSize = true;
            this.checkDrivenPass.BackColor = Color.Transparent;
            this.checkDrivenPass.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "DrivenPass", true));
            this.checkDrivenPass.ImeMode = ImeMode.NoControl;
            this.checkDrivenPass.Location = new Point(16, 194);
            this.checkDrivenPass.Name = "checkDrivenPass";
            this.checkDrivenPass.Size = new Size(83, 17);
            this.checkDrivenPass.TabIndex = 50;
            this.checkDrivenPass.Text = "Driven Pass";
            this.checkDrivenPass.UseVisualStyleBackColor = false;
            this.checkDivingHeader.AutoSize = true;
            this.checkDivingHeader.BackColor = Color.Transparent;
            this.checkDivingHeader.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "DivingHeader", true));
            this.checkDivingHeader.ImeMode = ImeMode.NoControl;
            this.checkDivingHeader.Location = new Point(16, 172);
            this.checkDivingHeader.Name = "checkDivingHeader";
            this.checkDivingHeader.Size = new Size(94, 17);
            this.checkDivingHeader.TabIndex = 49;
            this.checkDivingHeader.Text = "Diving Header";
            this.checkDivingHeader.UseVisualStyleBackColor = false;
            this.checkBycicleKick.AutoSize = true;
            this.checkBycicleKick.BackColor = Color.Transparent;
            this.checkBycicleKick.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "BycicleKick", true));
            this.checkBycicleKick.ImeMode = ImeMode.NoControl;
            this.checkBycicleKick.Location = new Point(16, 150);
            this.checkBycicleKick.Name = "checkBycicleKick";
            this.checkBycicleKick.Size = new Size(84, 17);
            this.checkBycicleKick.TabIndex = 48;
            this.checkBycicleKick.Text = "Bycicle Kick";
            this.checkBycicleKick.UseVisualStyleBackColor = false;
            this.checkChipperPenalty.AutoSize = true;
            this.checkChipperPenalty.BackColor = Color.Transparent;
            this.checkChipperPenalty.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "ChipperPenalty", true));
            this.checkChipperPenalty.ImeMode = ImeMode.NoControl;
            this.checkChipperPenalty.Location = new Point(16, 128);
            this.checkChipperPenalty.Name = "checkChipperPenalty";
            this.checkChipperPenalty.Size = new Size(100, 17);
            this.checkChipperPenalty.TabIndex = 47;
            this.checkChipperPenalty.Text = "Chipper Penalty";
            this.checkChipperPenalty.UseVisualStyleBackColor = false;
            this.checkStutterPenalty.AutoSize = true;
            this.checkStutterPenalty.BackColor = Color.Transparent;
            this.checkStutterPenalty.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "StutterPenalty", true));
            this.checkStutterPenalty.ImeMode = ImeMode.NoControl;
            this.checkStutterPenalty.Location = new Point(16, 106);
            this.checkStutterPenalty.Name = "checkStutterPenalty";
            this.checkStutterPenalty.Size = new Size(95, 17);
            this.checkStutterPenalty.TabIndex = 46;
            this.checkStutterPenalty.Text = "Stutter Penalty";
            this.checkStutterPenalty.UseVisualStyleBackColor = false;
            this.checkFancyFlicks.AutoSize = true;
            this.checkFancyFlicks.BackColor = Color.Transparent;
            this.checkFancyFlicks.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "FancyFlicks", true));
            this.checkFancyFlicks.ImeMode = ImeMode.NoControl;
            this.checkFancyFlicks.Location = new Point(16, 84);
            this.checkFancyFlicks.Name = "checkFancyFlicks";
            this.checkFancyFlicks.Size = new Size(85, 17);
            this.checkFancyFlicks.TabIndex = 45;
            this.checkFancyFlicks.Text = "Fancy Flicks";
            this.checkFancyFlicks.UseVisualStyleBackColor = false;
            this.checkFancyPasses.AutoSize = true;
            this.checkFancyPasses.BackColor = Color.Transparent;
            this.checkFancyPasses.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "FancyPasses", true));
            this.checkFancyPasses.ImeMode = ImeMode.NoControl;
            this.checkFancyPasses.Location = new Point(16, 62);
            this.checkFancyPasses.Name = "checkFancyPasses";
            this.checkFancyPasses.Size = new Size(92, 17);
            this.checkFancyPasses.TabIndex = 44;
            this.checkFancyPasses.Text = "Fancy Passes";
            this.checkFancyPasses.UseVisualStyleBackColor = false;
            this.checkFancyFeet.AutoSize = true;
            this.checkFancyFeet.BackColor = Color.Transparent;
            this.checkFancyFeet.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "FancyFeet", true));
            this.checkFancyFeet.ImeMode = ImeMode.NoControl;
            this.checkFancyFeet.Location = new Point(16, 40);
            this.checkFancyFeet.Name = "checkFancyFeet";
            this.checkFancyFeet.Size = new Size(79, 17);
            this.checkFancyFeet.TabIndex = 43;
            this.checkFancyFeet.Text = "Fancy Feet";
            this.checkFancyFeet.UseVisualStyleBackColor = false;
            this.checkGKOneonOne.AutoSize = true;
            this.checkGKOneonOne.BackColor = Color.Transparent;
            this.checkGKOneonOne.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "GkOneOnOne", true));
            this.checkGKOneonOne.ImeMode = ImeMode.NoControl;
            this.checkGKOneonOne.Location = new Point(24, 213);
            this.checkGKOneonOne.Name = "checkGKOneonOne";
            this.checkGKOneonOne.Size = new Size(102, 17);
            this.checkGKOneonOne.TabIndex = 56;
            this.checkGKOneonOne.Text = "GK One on One";
            this.checkGKOneonOne.UseVisualStyleBackColor = false;
            this.checkAcrobaticClearance.AutoSize = true;
            this.checkAcrobaticClearance.BackColor = Color.Transparent;
            this.checkAcrobaticClearance.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "AcrobaticClearance", true));
            this.checkAcrobaticClearance.ImeMode = ImeMode.NoControl;
            this.checkAcrobaticClearance.Location = new Point(24, 235);
            this.checkAcrobaticClearance.Name = "checkAcrobaticClearance";
            this.checkAcrobaticClearance.Size = new Size(122, 17);
            this.checkAcrobaticClearance.TabIndex = 55;
            this.checkAcrobaticClearance.Text = "Acrobatic Clearance";
            this.checkAcrobaticClearance.UseVisualStyleBackColor = false;
            this.checkSecondWind.AutoSize = true;
            this.checkSecondWind.BackColor = Color.Transparent;
            this.checkSecondWind.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "SecondWind", true));
            this.checkSecondWind.ImeMode = ImeMode.NoControl;
            this.checkSecondWind.Location = new Point(24, 81);
            this.checkSecondWind.Name = "checkSecondWind";
            this.checkSecondWind.Size = new Size(91, 17);
            this.checkSecondWind.TabIndex = 54;
            this.checkSecondWind.Text = "Second Wind";
            this.checkSecondWind.UseVisualStyleBackColor = false;
            this.checkCrowdFavourite.AutoSize = true;
            this.checkCrowdFavourite.BackColor = Color.Transparent;
            this.checkCrowdFavourite.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "CrowdFavorite", true));
            this.checkCrowdFavourite.ImeMode = ImeMode.NoControl;
            this.checkCrowdFavourite.Location = new Point(334, 213);
            this.checkCrowdFavourite.Name = "checkCrowdFavourite";
            this.checkCrowdFavourite.Size = new Size(103, 17);
            this.checkCrowdFavourite.TabIndex = 53;
            this.checkCrowdFavourite.Text = "Crowd Favourite";
            this.checkCrowdFavourite.UseVisualStyleBackColor = false;
            this.checkInflexible.AutoSize = true;
            this.checkInflexible.BackColor = Color.Transparent;
            this.checkInflexible.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "Inflexible", true));
            this.checkInflexible.ImeMode = ImeMode.NoControl;
            this.checkInflexible.Location = new Point(334, 191);
            this.checkInflexible.Name = "checkInflexible";
            this.checkInflexible.Size = new Size(67, 17);
            this.checkInflexible.TabIndex = 52;
            this.checkInflexible.Text = "Inflexible";
            this.checkInflexible.UseVisualStyleBackColor = false;
            this.checkTeamPlayer.AutoSize = true;
            this.checkTeamPlayer.BackColor = Color.Transparent;
            this.checkTeamPlayer.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "TeamPlayer", true));
            this.checkTeamPlayer.ImeMode = ImeMode.NoControl;
            this.checkTeamPlayer.Location = new Point(334, 169);
            this.checkTeamPlayer.Name = "checkTeamPlayer";
            this.checkTeamPlayer.Size = new Size(85, 17);
            this.checkTeamPlayer.TabIndex = 51;
            this.checkTeamPlayer.Text = "Team Player";
            this.checkTeamPlayer.UseVisualStyleBackColor = false;
            this.checkSwervePasser.AutoSize = true;
            this.checkSwervePasser.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "SwervePasser", true));
            this.checkSwervePasser.ImeMode = ImeMode.NoControl;
            this.checkSwervePasser.Location = new Point(170, 125);
            this.checkSwervePasser.Name = "checkSwervePasser";
            this.checkSwervePasser.Size = new Size(97, 17);
            this.checkSwervePasser.TabIndex = 50;
            this.checkSwervePasser.Text = "Swerve Passer";
            this.checkSwervePasser.UseVisualStyleBackColor = false;
            this.checkCornerSpecialist.AutoSize = true;
            this.checkCornerSpecialist.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "OutsideFootShot", true));
            this.checkCornerSpecialist.ImeMode = ImeMode.NoControl;
            this.checkCornerSpecialist.Location = new Point(170, 258);
            this.checkCornerSpecialist.Name = "checkCornerSpecialist";
            this.checkCornerSpecialist.Size = new Size(111, 17);
            this.checkCornerSpecialist.TabIndex = 49;
            this.checkCornerSpecialist.Text = "Outside Foot Shot";
            this.checkCornerSpecialist.UseVisualStyleBackColor = false;
            this.checkPowerHeader.AutoSize = true;
            this.checkPowerHeader.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "PowerHeader", true));
            this.checkPowerHeader.ImeMode = ImeMode.NoControl;
            this.checkPowerHeader.Location = new Point(170, 192);
            this.checkPowerHeader.Name = "checkPowerHeader";
            this.checkPowerHeader.Size = new Size(94, 17);
            this.checkPowerHeader.TabIndex = 48;
            this.checkPowerHeader.Text = "Power Header";
            this.checkPowerHeader.UseVisualStyleBackColor = false;
            this.checkGkLongThrower.AutoSize = true;
            this.checkGkLongThrower.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "GkLongThrower", true));
            this.checkGkLongThrower.Location = new Point(24, 191);
            this.checkGkLongThrower.Name = "checkGkLongThrower";
            this.checkGkLongThrower.Size = new Size(110, 17);
            this.checkGkLongThrower.TabIndex = 47;
            this.checkGkLongThrower.Text = "GK Long Thrower";
            this.checkGkLongThrower.UseVisualStyleBackColor = true;
            this.checkLongPasser.AutoSize = true;
            this.checkLongPasser.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "LongPasser", true));
            this.checkLongPasser.ImeMode = ImeMode.NoControl;
            this.checkLongPasser.Location = new Point(170, 103);
            this.checkLongPasser.Name = "checkLongPasser";
            this.checkLongPasser.Size = new Size(85, 17);
            this.checkLongPasser.TabIndex = 46;
            this.checkLongPasser.Text = "Long Passer";
            this.checkLongPasser.UseVisualStyleBackColor = false;
            this.checkFlair.AutoSize = true;
            this.checkFlair.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "Flair", true));
            this.checkFlair.ImeMode = ImeMode.NoControl;
            this.checkFlair.Location = new Point(170, 147);
            this.checkFlair.Name = "checkFlair";
            this.checkFlair.Size = new Size(45, 17);
            this.checkFlair.TabIndex = 45;
            this.checkFlair.Text = "Flair";
            this.checkFlair.UseVisualStyleBackColor = false;
            this.checkFinesseShot.AutoSize = true;
            this.checkFinesseShot.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "FinesseShot", true));
            this.checkFinesseShot.ImeMode = ImeMode.NoControl;
            this.checkFinesseShot.Location = new Point(170, 236);
            this.checkFinesseShot.Name = "checkFinesseShot";
            this.checkFinesseShot.Size = new Size(87, 17);
            this.checkFinesseShot.TabIndex = 44;
            this.checkFinesseShot.Text = "Finesse Shot";
            this.checkFinesseShot.UseVisualStyleBackColor = false;
            this.checkArguesWithOfficials.AutoSize = true;
            this.checkArguesWithOfficials.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "ArguesWithOfficials", true));
            this.checkArguesWithOfficials.ImeMode = ImeMode.NoControl;
            this.checkArguesWithOfficials.Location = new Point(334, 125);
            this.checkArguesWithOfficials.Name = "checkArguesWithOfficials";
            this.checkArguesWithOfficials.Size = new Size(121, 17);
            this.checkArguesWithOfficials.TabIndex = 43;
            this.checkArguesWithOfficials.Text = "Argues with Officials";
            this.checkArguesWithOfficials.UseVisualStyleBackColor = false;
            this.checkBeatsOffsideTrap.AutoSize = true;
            this.checkBeatsOffsideTrap.BackColor = Color.Transparent;
            this.checkBeatsOffsideTrap.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "BeatDefensiveLine", true));
            this.checkBeatsOffsideTrap.ImeMode = ImeMode.NoControl;
            this.checkBeatsOffsideTrap.Location = new Point(334, 59);
            this.checkBeatsOffsideTrap.Name = "checkBeatsOffsideTrap";
            this.checkBeatsOffsideTrap.Size = new Size(114, 17);
            this.checkBeatsOffsideTrap.TabIndex = 42;
            this.checkBeatsOffsideTrap.Text = "Beats Offside Trap";
            this.checkBeatsOffsideTrap.UseVisualStyleBackColor = false;
            this.checkAvoidsWeakFoot.AutoSize = true;
            this.checkAvoidsWeakFoot.BackColor = Color.Transparent;
            this.checkAvoidsWeakFoot.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "AvoidsWeakFoot", true));
            this.checkAvoidsWeakFoot.ImeMode = ImeMode.NoControl;
            this.checkAvoidsWeakFoot.Location = new Point(170, 37);
            this.checkAvoidsWeakFoot.Name = "checkAvoidsWeakFoot";
            this.checkAvoidsWeakFoot.Size = new Size(144, 17);
            this.checkAvoidsWeakFoot.TabIndex = 41;
            this.checkAvoidsWeakFoot.Text = "Avoids Using Weak Foot";
            this.checkAvoidsWeakFoot.UseVisualStyleBackColor = false;
            this.checkInjuryFree.AutoSize = true;
            this.checkInjuryFree.BackColor = Color.Transparent;
            this.checkInjuryFree.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "InjuryFree", true));
            this.checkInjuryFree.ImeMode = ImeMode.NoControl;
            this.checkInjuryFree.Location = new Point(24, 59);
            this.checkInjuryFree.Name = "checkInjuryFree";
            this.checkInjuryFree.Size = new Size(75, 17);
            this.checkInjuryFree.TabIndex = 40;
            this.checkInjuryFree.Text = "Injury Free";
            this.checkInjuryFree.UseVisualStyleBackColor = false;
            this.checkPowerFreeKick.AutoSize = true;
            this.checkPowerFreeKick.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "PowerfulFreeKicks", true));
            this.checkPowerFreeKick.Location = new Point(334, 37);
            this.checkPowerFreeKick.Name = "checkPowerFreeKick";
            this.checkPowerFreeKick.Size = new Size(104, 17);
            this.checkPowerFreeKick.TabIndex = 39;
            this.checkPowerFreeKick.Text = "Power Free Kick";
            this.checkPowerFreeKick.UseVisualStyleBackColor = true;
            this.checkSelfish.AutoSize = true;
            this.checkSelfish.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "Selfish", true));
            this.checkSelfish.ImeMode = ImeMode.NoControl;
            this.checkSelfish.Location = new Point(334, 81);
            this.checkSelfish.Name = "checkSelfish";
            this.checkSelfish.Size = new Size(57, 17);
            this.checkSelfish.TabIndex = 37;
            this.checkSelfish.Text = "Selfish";
            this.checkSelfish.UseVisualStyleBackColor = false;
            this.checkPlaymaker.AutoSize = true;
            this.checkPlaymaker.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "Playmaker", true));
            this.checkPlaymaker.ImeMode = ImeMode.NoControl;
            this.checkPlaymaker.Location = new Point(170, 59);
            this.checkPlaymaker.Name = "checkPlaymaker";
            this.checkPlaymaker.Size = new Size(75, 17);
            this.checkPlaymaker.TabIndex = 33;
            this.checkPlaymaker.Text = "Playmaker";
            this.checkPlaymaker.UseVisualStyleBackColor = false;
            this.checkTechnicaldribbler.AutoSize = true;
            this.checkTechnicaldribbler.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "Technicaldribbler", true));
            this.checkTechnicaldribbler.ImeMode = ImeMode.NoControl;
            this.checkTechnicaldribbler.Location = new Point(170, 169);
            this.checkTechnicaldribbler.Name = "checkTechnicaldribbler";
            this.checkTechnicaldribbler.Size = new Size(112, 17);
            this.checkTechnicaldribbler.TabIndex = 38;
            this.checkTechnicaldribbler.Text = "Technical Dribbler";
            this.checkTechnicaldribbler.UseVisualStyleBackColor = false;
            this.checkLeadership.AutoSize = true;
            this.checkLeadership.BackColor = Color.Transparent;
            this.checkLeadership.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "Leadership", true));
            this.checkLeadership.ImeMode = ImeMode.NoControl;
            this.checkLeadership.Location = new Point(334, 235);
            this.checkLeadership.Name = "checkLeadership";
            this.checkLeadership.Size = new Size(78, 17);
            this.checkLeadership.TabIndex = 36;
            this.checkLeadership.Text = "Leadership";
            this.checkLeadership.UseVisualStyleBackColor = false;
            this.checkPuncher.AutoSize = true;
            this.checkPuncher.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "Puncher", true));
            this.checkPuncher.ImeMode = ImeMode.NoControl;
            this.checkPuncher.Location = new Point(24, 169);
            this.checkPuncher.Name = "checkPuncher";
            this.checkPuncher.Size = new Size(84, 17);
            this.checkPuncher.TabIndex = 34;
            this.checkPuncher.Text = "GK Puncher";
            this.checkPuncher.UseVisualStyleBackColor = false;
            this.checkDiver.AutoSize = true;
            this.checkDiver.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "Diver", true));
            this.checkDiver.ImeMode = ImeMode.NoControl;
            this.checkDiver.Location = new Point(334, 103);
            this.checkDiver.Name = "checkDiver";
            this.checkDiver.Size = new Size(51, 17);
            this.checkDiver.TabIndex = 27;
            this.checkDiver.Text = "Diver";
            this.checkDiver.UseVisualStyleBackColor = false;
            this.checkDivesintotackles.AutoSize = true;
            this.checkDivesintotackles.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "Divesintotackles", true));
            this.checkDivesintotackles.ImeMode = ImeMode.NoControl;
            this.checkDivesintotackles.Location = new Point(24, 257);
            this.checkDivesintotackles.Name = "checkDivesintotackles";
            this.checkDivesintotackles.Size = new Size(114, 17);
            this.checkDivesintotackles.TabIndex = 28;
            this.checkDivesintotackles.Text = "Dives into Tackles";
            this.checkDivesintotackles.UseVisualStyleBackColor = false;
            this.checkLongshottaker.AutoSize = true;
            this.checkLongshottaker.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "LongShotTaker", true));
            this.checkLongshottaker.ImeMode = ImeMode.NoControl;
            this.checkLongshottaker.Location = new Point(170, 214);
            this.checkLongshottaker.Name = "checkLongshottaker";
            this.checkLongshottaker.Size = new Size(106, 17);
            this.checkLongshottaker.TabIndex = 30;
            this.checkLongshottaker.Text = "Long Shot Taker";
            this.checkLongshottaker.UseVisualStyleBackColor = false;
            this.checkHighClubIdentification.AutoSize = true;
            this.checkHighClubIdentification.BackColor = Color.Transparent;
            this.checkHighClubIdentification.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "HighClubIdentification", true));
            this.checkHighClubIdentification.ImeMode = ImeMode.NoControl;
            this.checkHighClubIdentification.Location = new Point(334, 147);
            this.checkHighClubIdentification.Name = "checkHighClubIdentification";
            this.checkHighClubIdentification.Size = new Size(107, 17);
            this.checkHighClubIdentification.TabIndex = 31;
            this.checkHighClubIdentification.Text = "High Club Identif.";
            this.checkHighClubIdentification.UseVisualStyleBackColor = false;
            this.checkPushesupforcorners.AutoSize = true;
            this.checkPushesupforcorners.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "Pushesupforcorners", true));
            this.checkPushesupforcorners.ImeMode = ImeMode.NoControl;
            this.checkPushesupforcorners.Location = new Point(24, 147);
            this.checkPushesupforcorners.Name = "checkPushesupforcorners";
            this.checkPushesupforcorners.Size = new Size(112, 17);
            this.checkPushesupforcorners.TabIndex = 35;
            this.checkPushesupforcorners.Text = "GK Up for Corners";
            this.checkPushesupforcorners.UseVisualStyleBackColor = false;
            this.checkEarlycrosser.AutoSize = true;
            this.checkEarlycrosser.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "Earlycrosser", true));
            this.checkEarlycrosser.ImeMode = ImeMode.NoControl;
            this.checkEarlycrosser.Location = new Point(170, 81);
            this.checkEarlycrosser.Name = "checkEarlycrosser";
            this.checkEarlycrosser.Size = new Size(87, 17);
            this.checkEarlycrosser.TabIndex = 29;
            this.checkEarlycrosser.Text = "Early Crosser";
            this.checkEarlycrosser.UseVisualStyleBackColor = false;
            this.checkInjuryProne.AutoSize = true;
            this.checkInjuryProne.BackColor = Color.Transparent;
            this.checkInjuryProne.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "InjuryProne", true));
            this.checkInjuryProne.ImeMode = ImeMode.NoControl;
            this.checkInjuryProne.Location = new Point(24, 37);
            this.checkInjuryProne.Name = "checkInjuryProne";
            this.checkInjuryProne.Size = new Size(82, 17);
            this.checkInjuryProne.TabIndex = 32;
            this.checkInjuryProne.Text = "Injury Prone";
            this.checkInjuryProne.UseVisualStyleBackColor = false;
            this.checkGiantThrower.AutoSize = true;
            this.checkGiantThrower.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "GiantThrow", true));
            this.checkGiantThrower.Location = new Point(24, 125);
            this.checkGiantThrower.Name = "checkGiantThrower";
            this.checkGiantThrower.Size = new Size(93, 17);
            this.checkGiantThrower.TabIndex = 1;
            this.checkGiantThrower.Text = "Giant Thrower";
            this.checkGiantThrower.UseVisualStyleBackColor = true;
            this.checkLongThrower.AutoSize = true;
            this.checkLongThrower.DataBindings.Add(new Binding("Checked", (object)this.playerBindingSource, "Longthrows", true));
            this.checkLongThrower.Location = new Point(24, 103);
            this.checkLongThrower.Name = "checkLongThrower";
            this.checkLongThrower.Size = new Size(92, 17);
            this.checkLongThrower.TabIndex = 0;
            this.checkLongThrower.Text = "Long Thrower";
            this.checkLongThrower.UseVisualStyleBackColor = true;
            this.pageFace.BackColor = Color.Transparent;
            this.pageFace.Controls.Add((Control)this.splitContainer1);
            this.pageFace.ImageIndex = 2;
            this.pageFace.Location = new Point(4, 23);
            this.pageFace.Name = "pageFace";
            this.pageFace.Size = new Size(1349, 780);
            this.pageFace.TabIndex = 2;
            this.pageFace.Text = "Face";
            this.pageFace.UseVisualStyleBackColor = true;
            this.splitContainer1.BackColor = Color.Transparent;
            this.splitContainer1.Dock = DockStyle.Fill;
            this.splitContainer1.Location = new Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1.Controls.Add((Control)this.splitContainer2);
            this.splitContainer1.Panel2.Controls.Add((Control)this.splitContainer3);
            this.splitContainer1.Size = new Size(1349, 780);
            this.splitContainer1.SplitterDistance = 724;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer2.BackColor = Color.Transparent;
            this.splitContainer2.Dock = DockStyle.Fill;
            this.splitContainer2.Location = new Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = Orientation.Horizontal;
            this.splitContainer2.Panel1.Controls.Add((Control)this.viewer3D);
            this.splitContainer2.Panel1.Controls.Add((Control)this.tool3D);
            this.splitContainer2.Panel2.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add((Control)this.groupGenericFace);
            this.splitContainer2.Size = new Size(724, 780);
            this.splitContainer2.SplitterDistance = 466;
            this.splitContainer2.TabIndex = 0;
            this.viewer3D.AmbientColor = Color.Gray;
            this.viewer3D.BackColor = Color.Gray;
            this.viewer3D.BorderStyle = BorderStyle.Fixed3D;
            this.viewer3D.Dock = DockStyle.Fill;
            this.viewer3D.LightDirectionX = -0.5f;
            this.viewer3D.LightDirectionY = -0.25f;
            this.viewer3D.LightDirectionZ = -1f;
            this.viewer3D.LightX = 30f;
            this.viewer3D.LightY = 180f;
            this.viewer3D.LightZ = 100f;
            this.viewer3D.Location = new Point(0, 0);
            this.viewer3D.Name = "viewer3D";
            this.viewer3D.RotationX = 6.28f;
            this.viewer3D.RotationY = 0.0f;
            this.viewer3D.Size = new Size(724, 441);
            this.viewer3D.TabIndex = 3;
            this.viewer3D.ViewX = 0.0f;
            this.viewer3D.ViewY = 171f;
            this.viewer3D.ViewZ = 49f;
            this.viewer3D.ZbufferRenderState = (bool[])null;
            this.tool3D.Dock = DockStyle.Bottom;
            this.tool3D.GripStyle = ToolStripGripStyle.Hidden;
            this.tool3D.Items.AddRange(new ToolStripItem[24]
            {
        (ToolStripItem) this.buttonShow3DModel,
        (ToolStripItem) this.buttonSwitchRenderingMode,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.buttonImport3DHeadModel,
        (ToolStripItem) this.buttonExport3DHeadModel,
        (ToolStripItem) this.buttonRemove3DHeadModel,
        (ToolStripItem) this.toolStripSeparator4,
        (ToolStripItem) this.buttonImport3DHairModel,
        (ToolStripItem) this.buttonExport3DHairModel,
        (ToolStripItem) this.buttonRemoveHairModel,
        (ToolStripItem) this.toolStripSeparator5,
        (ToolStripItem) this.buttonMoveHairAhead,
        (ToolStripItem) this.buttonMoveHairBack,
        (ToolStripItem) this.buttonMoveHairUp,
        (ToolStripItem) this.buttonMoveHairDown,
        (ToolStripItem) this.buttonMoveHairLeft,
        (ToolStripItem) this.buttonMoveHairRight,
        (ToolStripItem) this.buttonMakeHairCloser,
        (ToolStripItem) this.buttonMakeHairWider,
        (ToolStripItem) this.buttonSaveHair,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.toolPhoto,
        (ToolStripItem) this.toolStripSeparator3,
        (ToolStripItem) this.buttonShowJesey
            });
            this.tool3D.Location = new Point(0, 441);
            this.tool3D.Name = "tool3D";
            this.tool3D.Size = new Size(724, 25);
            this.tool3D.TabIndex = 4;
            this.buttonShow3DModel.CheckOnClick = true;
            this.buttonShow3DModel.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.buttonShow3DModel.Image = (Image)resources.GetObject("buttonShow3DModel.Image");
            this.buttonShow3DModel.ImageTransparentColor = Color.Magenta;
            this.buttonShow3DModel.Name = "buttonShow3DModel";
            this.buttonShow3DModel.Size = new Size(23, 22);
            this.buttonShow3DModel.Text = "Show / Hide";
            this.buttonShow3DModel.Click += new EventHandler(this.buttonShow3DModel_Click);
            this.buttonSwitchRenderingMode.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.buttonSwitchRenderingMode.Image = (Image)resources.GetObject("buttonSwitchRenderingMode.Image");
            this.buttonSwitchRenderingMode.ImageTransparentColor = Color.Magenta;
            this.buttonSwitchRenderingMode.Name = "buttonSwitchRenderingMode";
            this.buttonSwitchRenderingMode.Size = new Size(23, 22);
            this.buttonSwitchRenderingMode.Text = "Switch Rendering Mode";
            this.buttonSwitchRenderingMode.Click += new EventHandler(this.buttonSwitchRenderingMode_Click);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(6, 25);
            this.buttonImport3DHeadModel.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.buttonImport3DHeadModel.Image = (Image)resources.GetObject("buttonImport3DHeadModel.Image");
            this.buttonImport3DHeadModel.ImageTransparentColor = Color.Magenta;
            this.buttonImport3DHeadModel.Name = "buttonImport3DHeadModel";
            this.buttonImport3DHeadModel.Size = new Size(23, 22);
            this.buttonImport3DHeadModel.Text = "Import 3D Head Model";
            this.buttonImport3DHeadModel.Click += new EventHandler(this.buttonImport3DHeadModel_Click);
            this.buttonExport3DHeadModel.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.buttonExport3DHeadModel.Image = (Image)resources.GetObject("buttonExport3DHeadModel.Image");
            this.buttonExport3DHeadModel.ImageTransparentColor = Color.Magenta;
            this.buttonExport3DHeadModel.Name = "buttonExport3DHeadModel";
            this.buttonExport3DHeadModel.Size = new Size(23, 22);
            this.buttonExport3DHeadModel.Text = "Export 3D Head Model";
            this.buttonExport3DHeadModel.Click += new EventHandler(this.buttonExport3DHeadModel_Click);
            this.buttonRemove3DHeadModel.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.buttonRemove3DHeadModel.Image = (Image)resources.GetObject("buttonRemove3DHeadModel.Image");
            this.buttonRemove3DHeadModel.ImageTransparentColor = Color.Magenta;
            this.buttonRemove3DHeadModel.Name = "buttonRemove3DHeadModel";
            this.buttonRemove3DHeadModel.Size = new Size(23, 22);
            this.buttonRemove3DHeadModel.Text = "Remove 3D Head Model";
            this.buttonRemove3DHeadModel.Click += new EventHandler(this.buttonRemove3DModel_Click);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new Size(6, 25);
            this.buttonImport3DHairModel.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.buttonImport3DHairModel.Image = (Image)resources.GetObject("buttonImport3DHairModel.Image");
            this.buttonImport3DHairModel.ImageTransparentColor = Color.Magenta;
            this.buttonImport3DHairModel.Name = "buttonImport3DHairModel";
            this.buttonImport3DHairModel.Size = new Size(23, 22);
            this.buttonImport3DHairModel.Text = "Import 3D Hair Model";
            this.buttonImport3DHairModel.Click += new EventHandler(this.buttonImport3DHairModels_Click);
            this.buttonExport3DHairModel.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.buttonExport3DHairModel.Image = (Image)resources.GetObject("buttonExport3DHairModel.Image");
            this.buttonExport3DHairModel.ImageTransparentColor = Color.Magenta;
            this.buttonExport3DHairModel.Name = "buttonExport3DHairModel";
            this.buttonExport3DHairModel.Size = new Size(23, 22);
            this.buttonExport3DHairModel.Text = "Export 3D Hair Model";
            this.buttonExport3DHairModel.Click += new EventHandler(this.buttonExport3DHairModels_Click);
            this.buttonRemoveHairModel.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.buttonRemoveHairModel.Image = (Image)resources.GetObject("buttonRemoveHairModel.Image");
            this.buttonRemoveHairModel.ImageTransparentColor = Color.Magenta;
            this.buttonRemoveHairModel.Name = "buttonRemoveHairModel";
            this.buttonRemoveHairModel.Size = new Size(23, 22);
            this.buttonRemoveHairModel.Text = "Remove Hair Model";
            this.buttonRemoveHairModel.Click += new EventHandler(this.buttonRemoveHairModel_Click);
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new Size(6, 25);
            this.buttonMoveHairAhead.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.buttonMoveHairAhead.Image = (Image)resources.GetObject("buttonMoveHairAhead.Image");
            this.buttonMoveHairAhead.ImageTransparentColor = Color.Magenta;
            this.buttonMoveHairAhead.Name = "buttonMoveHairAhead";
            this.buttonMoveHairAhead.Size = new Size(23, 22);
            this.buttonMoveHairAhead.Text = "Move Hair Ahead";
            this.buttonMoveHairAhead.Click += new EventHandler(this.buttonAhead_Click);
            this.buttonMoveHairBack.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.buttonMoveHairBack.Image = (Image)resources.GetObject("buttonMoveHairBack.Image");
            this.buttonMoveHairBack.ImageAlign = ContentAlignment.BottomCenter;
            this.buttonMoveHairBack.ImageTransparentColor = Color.Magenta;
            this.buttonMoveHairBack.Name = "buttonMoveHairBack";
            this.buttonMoveHairBack.Size = new Size(23, 22);
            this.buttonMoveHairBack.Text = "Move Hair Back";
            this.buttonMoveHairBack.Click += new EventHandler(this.buttonBack_Click);
            this.buttonMoveHairUp.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.buttonMoveHairUp.Image = (Image)resources.GetObject("buttonMoveHairUp.Image");
            this.buttonMoveHairUp.ImageTransparentColor = Color.Magenta;
            this.buttonMoveHairUp.Name = "buttonMoveHairUp";
            this.buttonMoveHairUp.Size = new Size(23, 22);
            this.buttonMoveHairUp.Text = "Move Hair Up";
            this.buttonMoveHairUp.Click += new EventHandler(this.buttonUp_Click);
            this.buttonMoveHairDown.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.buttonMoveHairDown.Image = (Image)resources.GetObject("buttonMoveHairDown.Image");
            this.buttonMoveHairDown.ImageAlign = ContentAlignment.BottomCenter;
            this.buttonMoveHairDown.ImageTransparentColor = Color.Magenta;
            this.buttonMoveHairDown.Name = "buttonMoveHairDown";
            this.buttonMoveHairDown.Size = new Size(23, 22);
            this.buttonMoveHairDown.Text = "Move Hair Down";
            this.buttonMoveHairDown.Click += new EventHandler(this.buttonDown_Click);
            this.buttonMoveHairLeft.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.buttonMoveHairLeft.Image = (Image)resources.GetObject("buttonMoveHairLeft.Image");
            this.buttonMoveHairLeft.ImageTransparentColor = Color.Magenta;
            this.buttonMoveHairLeft.Name = "buttonMoveHairLeft";
            this.buttonMoveHairLeft.Size = new Size(23, 22);
            this.buttonMoveHairLeft.Text = "Move Hair Left";
            this.buttonMoveHairLeft.Click += new EventHandler(this.buttonMoveHairLeft_Click);
            this.buttonMoveHairRight.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.buttonMoveHairRight.Image = (Image)resources.GetObject("buttonMoveHairRight.Image");
            this.buttonMoveHairRight.ImageTransparentColor = Color.Magenta;
            this.buttonMoveHairRight.Name = "buttonMoveHairRight";
            this.buttonMoveHairRight.Size = new Size(23, 22);
            this.buttonMoveHairRight.Text = "Move Hair Right";
            this.buttonMoveHairRight.Click += new EventHandler(this.buttonMoveHairRight_Click);
            this.buttonMakeHairCloser.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.buttonMakeHairCloser.Image = (Image)resources.GetObject("buttonMakeHairCloser.Image");
            this.buttonMakeHairCloser.ImageTransparentColor = Color.Magenta;
            this.buttonMakeHairCloser.Name = "buttonMakeHairCloser";
            this.buttonMakeHairCloser.Size = new Size(23, 22);
            this.buttonMakeHairCloser.Text = "Make Hair Closer";
            this.buttonMakeHairCloser.Click += new EventHandler(this.buttonMakeHairCloser_Click);
            this.buttonMakeHairWider.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.buttonMakeHairWider.Image = (Image)resources.GetObject("buttonMakeHairWider.Image");
            this.buttonMakeHairWider.ImageTransparentColor = Color.Magenta;
            this.buttonMakeHairWider.Name = "buttonMakeHairWider";
            this.buttonMakeHairWider.Size = new Size(23, 22);
            this.buttonMakeHairWider.Text = "Make Hair Wider";
            this.buttonMakeHairWider.Click += new EventHandler(this.buttonMakeHairWider_Click);
            this.buttonSaveHair.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.buttonSaveHair.Enabled = false;
            this.buttonSaveHair.Image = (Image)resources.GetObject("buttonSaveHair.Image");
            this.buttonSaveHair.ImageTransparentColor = Color.Magenta;
            this.buttonSaveHair.Name = "buttonSaveHair";
            this.buttonSaveHair.Size = new Size(23, 22);
            this.buttonSaveHair.Text = "Save Modified Hair";
            this.buttonSaveHair.Click += new EventHandler(this.buttonSaveHair_Click);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new Size(6, 25);
            this.toolPhoto.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolPhoto.Image = (Image)resources.GetObject("toolPhoto.Image");
            this.toolPhoto.ImageTransparentColor = Color.Magenta;
            this.toolPhoto.Name = "toolPhoto";
            this.toolPhoto.Size = new Size(23, 22);
            this.toolPhoto.Text = "Take a picture";
            this.toolPhoto.Click += new EventHandler(this.toolPhoto_Click);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new Size(6, 25);
            this.buttonShowJesey.Checked = true;
            this.buttonShowJesey.CheckOnClick = true;
            this.buttonShowJesey.CheckState = CheckState.Checked;
            this.buttonShowJesey.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.buttonShowJesey.Image = (Image)resources.GetObject("buttonShowJesey.Image");
            this.buttonShowJesey.ImageTransparentColor = Color.Magenta;
            this.buttonShowJesey.Name = "buttonShowJesey";
            this.buttonShowJesey.Size = new Size(23, 22);
            this.buttonShowJesey.Text = "Show team jersey";
            this.buttonShowJesey.Click += new EventHandler(this.buttonShowJesey_Click);
            this.groupGenericFace.Controls.Add((Control)this.groupGenericFaceType);
            this.groupGenericFace.Controls.Add((Control)this.labelSkinColorInfo);
            this.groupGenericFace.Controls.Add((Control)this.checkHasGenericFace);
            this.groupGenericFace.Controls.Add((Control)this.numericSkinTone);
            this.groupGenericFace.Controls.Add((Control)this.groupHairModel);
            this.groupGenericFace.Controls.Add((Control)this.groupHeadModel);
            this.groupGenericFace.Controls.Add((Control)this.labelHeadType);
            this.groupGenericFace.Controls.Add((Control)this.label1);
            this.groupGenericFace.Controls.Add((Control)this.labelHairType);
            this.groupGenericFace.Location = new Point(8, 3);
            this.groupGenericFace.Name = "groupGenericFace";
            this.groupGenericFace.Size = new Size(610, 262);
            this.groupGenericFace.TabIndex = 86;
            this.groupGenericFace.TabStop = false;
            this.groupGenericFace.Text = "Face Modelling";
            this.groupGenericFaceType.Controls.Add((Control)this.labelFacialHair);
            this.groupGenericFaceType.Controls.Add((Control)this.labelEyeBow);
            this.groupGenericFaceType.Controls.Add((Control)this.domainFacialHair);
            this.groupGenericFaceType.Controls.Add((Control)this.comboEyeBow);
            this.groupGenericFaceType.Controls.Add((Control)this.labelSideburns);
            this.groupGenericFaceType.Controls.Add((Control)this.comboSideburns);
            this.groupGenericFaceType.Controls.Add((Control)this.labelSkintype);
            this.groupGenericFaceType.Controls.Add((Control)this.comboSkintype);
            this.groupGenericFaceType.Controls.Add((Control)this.comboFacialHairColor);
            this.groupGenericFaceType.Controls.Add((Control)this.labelFacialHairColor);
            this.groupGenericFaceType.Location = new Point(381, 39);
            this.groupGenericFaceType.Name = "groupGenericFaceType";
            this.groupGenericFaceType.Size = new Size(200, 217);
            this.groupGenericFaceType.TabIndex = 35;
            this.groupGenericFaceType.TabStop = false;
            this.groupGenericFaceType.Text = "Face Type";
            this.labelFacialHair.AutoSize = true;
            this.labelFacialHair.BackColor = Color.Transparent;
            this.labelFacialHair.ImeMode = ImeMode.NoControl;
            this.labelFacialHair.Location = new Point(6, 123);
            this.labelFacialHair.Name = "labelFacialHair";
            this.labelFacialHair.Size = new Size(57, 13);
            this.labelFacialHair.TabIndex = 15;
            this.labelFacialHair.Text = "Facial Hair";
            this.labelFacialHair.TextAlign = ContentAlignment.MiddleLeft;
            this.labelEyeBow.AutoSize = true;
            this.labelEyeBow.BackColor = Color.Transparent;
            this.labelEyeBow.ImeMode = ImeMode.NoControl;
            this.labelEyeBow.Location = new Point(6, 90);
            this.labelEyeBow.Name = "labelEyeBow";
            this.labelEyeBow.Size = new Size(57, 13);
            this.labelEyeBow.TabIndex = 33;
            this.labelEyeBow.Text = "Eyes Brow";
            this.labelEyeBow.TextAlign = ContentAlignment.MiddleLeft;
            this.domainFacialHair.DropDownStyle = ComboBoxStyle.DropDownList;
            this.domainFacialHair.FormattingEnabled = true;
            this.domainFacialHair.Items.AddRange(new object[8]
            {
        (object) "none",
        (object) "chin beard",
        (object) "chin courtain",
        (object) "goatie",
        (object) "full beard",
        (object) "mustache",
        (object) "stubble",
        (object) "soul patch"
            });
            this.domainFacialHair.Location = new Point(77, 120);
            this.domainFacialHair.Name = "domainFacialHair";
            this.domainFacialHair.Size = new Size(111, 21);
            this.domainFacialHair.TabIndex = 4;
            this.domainFacialHair.SelectedIndexChanged += new EventHandler(this.domainFacialHair_SelectedItemChanged);
            this.comboEyeBow.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboEyeBow.FormattingEnabled = true;
            this.comboEyeBow.Items.AddRange(new object[3]
            {
        (object) "Normal",
        (object) "Big",
        (object) "Thin"
            });
            this.comboEyeBow.Location = new Point(77, 87);
            this.comboEyeBow.Name = "comboEyeBow";
            this.comboEyeBow.Size = new Size(111, 21);
            this.comboEyeBow.TabIndex = 3;
            this.comboEyeBow.SelectedIndexChanged += new EventHandler(this.comboEyeBow_SelectedIndexChanged);
            this.labelSideburns.AutoSize = true;
            this.labelSideburns.BackColor = Color.Transparent;
            this.labelSideburns.ImeMode = ImeMode.NoControl;
            this.labelSideburns.Location = new Point(6, 191);
            this.labelSideburns.Name = "labelSideburns";
            this.labelSideburns.Size = new Size(54, 13);
            this.labelSideburns.TabIndex = 23;
            this.labelSideburns.Text = "Sideburns";
            this.labelSideburns.TextAlign = ContentAlignment.MiddleLeft;
            this.comboSideburns.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboSideburns.FormattingEnabled = true;
            this.comboSideburns.Items.AddRange(new object[2]
            {
        (object) "No",
        (object) "Yes"
            });
            this.comboSideburns.Location = new Point(77, 188);
            this.comboSideburns.Name = "comboSideburns";
            this.comboSideburns.Size = new Size(111, 21);
            this.comboSideburns.TabIndex = 6;
            this.comboSideburns.SelectedIndexChanged += new EventHandler(this.comboSideburns_SelectedIndexChanged);
            this.labelSkintype.AutoSize = true;
            this.labelSkintype.BackColor = Color.Transparent;
            this.labelSkintype.ImeMode = ImeMode.NoControl;
            this.labelSkintype.Location = new Point(6, 54);
            this.labelSkintype.Name = "labelSkintype";
            this.labelSkintype.Size = new Size(55, 13);
            this.labelSkintype.TabIndex = 21;
            this.labelSkintype.Text = "Skin Type";
            this.labelSkintype.TextAlign = ContentAlignment.MiddleLeft;
            this.comboSkintype.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboSkintype.FormattingEnabled = true;
            this.comboSkintype.Items.AddRange(new object[3]
            {
        (object) "Clean",
        (object) "Freckled",
        (object) "Rough"
            });
            this.comboSkintype.Location = new Point(77, 51);
            this.comboSkintype.Name = "comboSkintype";
            this.comboSkintype.Size = new Size(111, 21);
            this.comboSkintype.TabIndex = 1;
            this.comboSkintype.SelectedIndexChanged += new EventHandler(this.comboSkintype_SelectedIndexChanged);
            this.comboFacialHairColor.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboFacialHairColor.FormattingEnabled = true;
            this.comboFacialHairColor.Items.AddRange(new object[5]
            {
        (object) "black",
        (object) "blonde",
        (object) "darker brown",
        (object) "lighter brown",
        (object) "red"
            });
            this.comboFacialHairColor.Location = new Point(77, 154);
            this.comboFacialHairColor.Name = "comboFacialHairColor";
            this.comboFacialHairColor.Size = new Size(111, 21);
            this.comboFacialHairColor.TabIndex = 5;
            this.comboFacialHairColor.SelectedIndexChanged += new EventHandler(this.comboFacialHairColor_SelectedIndexChanged);
            this.labelFacialHairColor.AutoSize = true;
            this.labelFacialHairColor.BackColor = Color.Transparent;
            this.labelFacialHairColor.ImeMode = ImeMode.NoControl;
            this.labelFacialHairColor.Location = new Point(6, 157);
            this.labelFacialHairColor.Name = "labelFacialHairColor";
            this.labelFacialHairColor.Size = new Size(31, 13);
            this.labelFacialHairColor.TabIndex = 17;
            this.labelFacialHairColor.Text = "Color";
            this.labelFacialHairColor.TextAlign = ContentAlignment.MiddleLeft;
            this.labelSkinColorInfo.AutoSize = true;
            this.labelSkinColorInfo.BackColor = Color.Transparent;
            this.labelSkinColorInfo.ImeMode = ImeMode.NoControl;
            this.labelSkinColorInfo.Location = new Point(457, 17);
            this.labelSkinColorInfo.Name = "labelSkinColorInfo";
            this.labelSkinColorInfo.Size = new Size(0, 13);
            this.labelSkinColorInfo.TabIndex = 121;
            this.labelSkinColorInfo.TextAlign = ContentAlignment.MiddleLeft;
            this.checkHasGenericFace.AutoSize = true;
            this.checkHasGenericFace.Location = new Point(154, 17);
            this.checkHasGenericFace.Name = "checkHasGenericFace";
            this.checkHasGenericFace.Size = new Size(112, 17);
            this.checkHasGenericFace.TabIndex = 0;
            this.checkHasGenericFace.Text = "Has Generic Face";
            this.checkHasGenericFace.UseVisualStyleBackColor = true;
            this.checkHasGenericFace.CheckedChanged += new EventHandler(this.checkHasGenericFace_CheckedChanged);
            this.numericSkinTone.Location = new Point(381, 13);
            this.numericSkinTone.Maximum = new Decimal(new int[4]
            {
        256,
        0,
        0,
        0
            });
            this.numericSkinTone.Minimum = new Decimal(new int[4]
            {
        1,
        0,
        0,
        0
            });
            this.numericSkinTone.Name = "numericSkinTone";
            this.numericSkinTone.Size = new Size(61, 20);
            this.numericSkinTone.TabIndex = 120;
            this.numericSkinTone.TextAlign = HorizontalAlignment.Center;
            this.numericSkinTone.Value = new Decimal(new int[4]
            {
        1,
        0,
        0,
        0
            });
            this.numericSkinTone.ValueChanged += new EventHandler(this.numericSkinTone_ValueChanged);
            this.groupHairModel.Controls.Add((Control)this.comboHeadband);
            this.groupHairModel.Controls.Add((Control)this.comboAfro);
            this.groupHairModel.Controls.Add((Control)this.comboLong);
            this.groupHairModel.Controls.Add((Control)this.comboMedium);
            this.groupHairModel.Controls.Add((Control)this.comboModern);
            this.groupHairModel.Controls.Add((Control)this.labelHairColor);
            this.groupHairModel.Controls.Add((Control)this.domainHairColor);
            this.groupHairModel.Controls.Add((Control)this.comboShort);
            this.groupHairModel.Controls.Add((Control)this.comboVeryShort);
            this.groupHairModel.Controls.Add((Control)this.comboShaven);
            this.groupHairModel.Controls.Add((Control)this.radioHeadband);
            this.groupHairModel.Controls.Add((Control)this.radioShaven);
            this.groupHairModel.Controls.Add((Control)this.radioAfro);
            this.groupHairModel.Controls.Add((Control)this.radioLong);
            this.groupHairModel.Controls.Add((Control)this.radioMedium);
            this.groupHairModel.Controls.Add((Control)this.radioModern);
            this.groupHairModel.Controls.Add((Control)this.radioShort);
            this.groupHairModel.Controls.Add((Control)this.radioVeryShort);
            this.groupHairModel.Location = new Point(6, 124);
            this.groupHairModel.Name = "groupHairModel";
            this.groupHairModel.Size = new Size(364, 132);
            this.groupHairModel.TabIndex = 29;
            this.groupHairModel.TabStop = false;
            this.groupHairModel.Text = "Hair Model and Color";
            this.comboHeadband.FormattingEnabled = true;
            this.comboHeadband.Location = new Point(6, 73);
            this.comboHeadband.Name = "comboHeadband";
            this.comboHeadband.Size = new Size(260, 21);
            this.comboHeadband.TabIndex = 0;
            this.comboHeadband.Visible = false;
            this.comboHeadband.SelectedIndexChanged += new EventHandler(this.comboHeadband_SelectedIndexChanged);
            this.comboAfro.FormattingEnabled = true;
            this.comboAfro.Items.AddRange(new object[8]
            {
        (object) "71",
        (object) "4",
        (object) "42",
        (object) "27",
        (object) "5",
        (object) "6",
        (object) "96",
        (object) "3"
            });
            this.comboAfro.Location = new Point(6, 73);
            this.comboAfro.Name = "comboAfro";
            this.comboAfro.Size = new Size(260, 21);
            this.comboAfro.TabIndex = 29;
            this.comboAfro.Visible = false;
            this.comboAfro.SelectedIndexChanged += new EventHandler(this.comboAfro_SelectedIndexChanged);
            this.comboLong.FormattingEnabled = true;
            this.comboLong.Items.AddRange(new object[16]
            {
        (object) "8",
        (object) "9",
        (object) "15",
        (object) "44",
        (object) "84",
        (object) "34",
        (object) "10",
        (object) "33",
        (object) "12",
        (object) "80",
        (object) "11",
        (object) "51",
        (object) "79",
        (object) "53",
        (object) "7",
        (object) "48"
            });
            this.comboLong.Location = new Point(6, 73);
            this.comboLong.Name = "comboLong";
            this.comboLong.Size = new Size(260, 21);
            this.comboLong.TabIndex = 28;
            this.comboLong.Visible = false;
            this.comboLong.SelectedIndexChanged += new EventHandler(this.comboLong_SelectedIndexChanged);
            this.comboMedium.FormattingEnabled = true;
            this.comboMedium.Items.AddRange(new object[27]
            {
        (object) "36",
        (object) "74",
        (object) "13",
        (object) "35",
        (object) "59",
        (object) "69",
        (object) "73",
        (object) "85",
        (object) "93",
        (object) "32",
        (object) "66",
        (object) "67",
        (object) "68",
        (object) "14",
        (object) "20",
        (object) "23",
        (object) "58",
        (object) "62",
        (object) "83",
        (object) "95",
        (object) "22",
        (object) "52",
        (object) "87",
        (object) "98",
        (object) "99",
        (object) "100",
        (object) "103"
            });
            this.comboMedium.Location = new Point(6, 73);
            this.comboMedium.Name = "comboMedium";
            this.comboMedium.Size = new Size(260, 21);
            this.comboMedium.TabIndex = 27;
            this.comboMedium.Visible = false;
            this.comboMedium.SelectedIndexChanged += new EventHandler(this.comboMedium_SelectedIndexChanged);
            this.comboModern.FormattingEnabled = true;
            this.comboModern.Items.AddRange(new object[13]
            {
        (object) "17",
        (object) "18",
        (object) "19",
        (object) "24",
        (object) "39",
        (object) "60",
        (object) "61",
        (object) "63",
        (object) "64",
        (object) "86",
        (object) "88",
        (object) "89",
        (object) "94"
            });
            this.comboModern.Location = new Point(6, 73);
            this.comboModern.Name = "comboModern";
            this.comboModern.Size = new Size(260, 21);
            this.comboModern.TabIndex = 26;
            this.comboModern.Visible = false;
            this.comboModern.SelectedIndexChanged += new EventHandler(this.comboModern_SelectedIndexChanged);
            this.labelHairColor.AutoSize = true;
            this.labelHairColor.BackColor = Color.Transparent;
            this.labelHairColor.ImeMode = ImeMode.NoControl;
            this.labelHairColor.Location = new Point(6, 107);
            this.labelHairColor.Name = "labelHairColor";
            this.labelHairColor.Size = new Size(53, 13);
            this.labelHairColor.TabIndex = 13;
            this.labelHairColor.Text = "Hair Color";
            this.labelHairColor.TextAlign = ContentAlignment.MiddleLeft;
            this.domainHairColor.DropDownStyle = ComboBoxStyle.DropDownList;
            this.domainHairColor.FormattingEnabled = true;
            this.domainHairColor.Items.AddRange(new object[13]
            {
        (object) "Blonde",
        (object) "Black",
        (object) "Ash Blonde",
        (object) "Dark Brown",
        (object) "Platinum Blonde",
        (object) "Light Brown",
        (object) "Brown",
        (object) "Red",
        (object) "White",
        (object) "Gray",
        (object) "Green",
        (object) "Violet",
        (object) "Intense Red"
            });
            this.domainHairColor.Location = new Point(71, 103);
            this.domainHairColor.Name = "domainHairColor";
            this.domainHairColor.Size = new Size(195, 21);
            this.domainHairColor.TabIndex = 1;
            this.domainHairColor.SelectedIndexChanged += new EventHandler(this.domainHairColor_SelectedIndexChanged);
            this.comboShort.FormattingEnabled = true;
            this.comboShort.Items.AddRange(new object[23]
            {
        (object) "2",
        (object) "21",
        (object) "22",
        (object) "30",
        (object) "38",
        (object) "54",
        (object) "57",
        (object) "70",
        (object) "75",
        (object) "78",
        (object) "82",
        (object) "97",
        (object) "101",
        (object) "102",
        (object) "104",
        (object) "105",
        (object) "106",
        (object) "107",
        (object) "108",
        (object) "109",
        (object) "110",
        (object) "111",
        (object) "112"
            });
            this.comboShort.Location = new Point(6, 73);
            this.comboShort.Name = "comboShort";
            this.comboShort.Size = new Size(260, 21);
            this.comboShort.TabIndex = 25;
            this.comboShort.Visible = false;
            this.comboShort.SelectedIndexChanged += new EventHandler(this.comboShort_SelectedIndexChanged);
            this.comboVeryShort.FormattingEnabled = true;
            this.comboVeryShort.Items.AddRange(new object[14]
            {
        (object) "26",
        (object) "29",
        (object) "47",
        (object) "72",
        (object) "92",
        (object) "16",
        (object) "28",
        (object) "31",
        (object) "37",
        (object) "40",
        (object) "45",
        (object) "65",
        (object) "77",
        (object) "90"
            });
            this.comboVeryShort.Location = new Point(6, 73);
            this.comboVeryShort.Name = "comboVeryShort";
            this.comboVeryShort.Size = new Size(260, 21);
            this.comboVeryShort.TabIndex = 24;
            this.comboVeryShort.Visible = false;
            this.comboVeryShort.SelectedIndexChanged += new EventHandler(this.comboVeryShort_SelectedIndexChanged);
            this.comboShaven.FormattingEnabled = true;
            this.comboShaven.Items.AddRange(new object[6]
            {
        (object) "0",
        (object) "25",
        (object) "1",
        (object) "43",
        (object) "41",
        (object) "46"
            });
            this.comboShaven.Location = new Point(6, 73);
            this.comboShaven.Name = "comboShaven";
            this.comboShaven.Size = new Size(260, 21);
            this.comboShaven.TabIndex = 23;
            this.comboShaven.Visible = false;
            this.comboShaven.SelectedIndexChanged += new EventHandler(this.comboShaven_SelectedIndexChanged);
            this.radioHeadband.Appearance = Appearance.Button;
            this.radioHeadband.FlatStyle = FlatStyle.Popup;
            this.radioHeadband.Location = new Point(136, 40);
            this.radioHeadband.Name = "radioHeadband";
            this.radioHeadband.Size = new Size(65, 23);
            this.radioHeadband.TabIndex = 22;
            this.radioHeadband.TabStop = true;
            this.radioHeadband.Tag = (object)this.comboHeadband;
            this.radioHeadband.Text = "Headband";
            this.radioHeadband.TextAlign = ContentAlignment.MiddleCenter;
            this.radioHeadband.UseVisualStyleBackColor = true;
            this.radioHeadband.CheckedChanged += new EventHandler(this.radioHeadband_CheckedChanged);
            this.radioShaven.Appearance = Appearance.Button;
            this.radioShaven.FlatStyle = FlatStyle.Popup;
            this.radioShaven.Location = new Point(6, 17);
            this.radioShaven.Name = "radioShaven";
            this.radioShaven.Size = new Size(65, 23);
            this.radioShaven.TabIndex = 21;
            this.radioShaven.TabStop = true;
            this.radioShaven.Tag = (object)this.comboShaven;
            this.radioShaven.Text = "Shaven";
            this.radioShaven.TextAlign = ContentAlignment.MiddleCenter;
            this.radioShaven.UseVisualStyleBackColor = true;
            this.radioShaven.CheckedChanged += new EventHandler(this.radioShaven_CheckedChanged);
            this.radioAfro.Appearance = Appearance.Button;
            this.radioAfro.FlatStyle = FlatStyle.Popup;
            this.radioAfro.Location = new Point(201, 40);
            this.radioAfro.Name = "radioAfro";
            this.radioAfro.Size = new Size(65, 23);
            this.radioAfro.TabIndex = 20;
            this.radioAfro.TabStop = true;
            this.radioAfro.Tag = (object)this.comboAfro;
            this.radioAfro.Text = "Afro";
            this.radioAfro.TextAlign = ContentAlignment.MiddleCenter;
            this.radioAfro.UseVisualStyleBackColor = true;
            this.radioAfro.CheckedChanged += new EventHandler(this.radioButtonAfro_CheckedChanged);
            this.radioLong.Appearance = Appearance.Button;
            this.radioLong.FlatStyle = FlatStyle.Popup;
            this.radioLong.Location = new Point(71, 40);
            this.radioLong.Name = "radioLong";
            this.radioLong.Size = new Size(65, 23);
            this.radioLong.TabIndex = 19;
            this.radioLong.TabStop = true;
            this.radioLong.Tag = (object)this.comboLong;
            this.radioLong.Text = "Long";
            this.radioLong.TextAlign = ContentAlignment.MiddleCenter;
            this.radioLong.UseVisualStyleBackColor = true;
            this.radioLong.CheckedChanged += new EventHandler(this.radioButtonLong_CheckedChanged);
            this.radioMedium.Appearance = Appearance.Button;
            this.radioMedium.FlatStyle = FlatStyle.Popup;
            this.radioMedium.Location = new Point(6, 40);
            this.radioMedium.Name = "radioMedium";
            this.radioMedium.Size = new Size(65, 23);
            this.radioMedium.TabIndex = 18;
            this.radioMedium.TabStop = true;
            this.radioMedium.Tag = (object)this.comboMedium;
            this.radioMedium.Text = "Medium";
            this.radioMedium.TextAlign = ContentAlignment.MiddleCenter;
            this.radioMedium.UseVisualStyleBackColor = true;
            this.radioMedium.CheckedChanged += new EventHandler(this.radioButtonMedium_CheckedChanged);
            this.radioModern.Appearance = Appearance.Button;
            this.radioModern.FlatStyle = FlatStyle.Popup;
            this.radioModern.Location = new Point(201, 17);
            this.radioModern.Name = "radioModern";
            this.radioModern.Size = new Size(65, 23);
            this.radioModern.TabIndex = 17;
            this.radioModern.TabStop = true;
            this.radioModern.Tag = (object)this.comboModern;
            this.radioModern.Text = "Modern";
            this.radioModern.TextAlign = ContentAlignment.MiddleCenter;
            this.radioModern.UseVisualStyleBackColor = true;
            this.radioModern.CheckedChanged += new EventHandler(this.radioModern_CheckedChanged);
            this.radioShort.Appearance = Appearance.Button;
            this.radioShort.FlatStyle = FlatStyle.Popup;
            this.radioShort.Location = new Point(136, 17);
            this.radioShort.Name = "radioShort";
            this.radioShort.Size = new Size(65, 23);
            this.radioShort.TabIndex = 16;
            this.radioShort.TabStop = true;
            this.radioShort.Tag = (object)this.comboShort;
            this.radioShort.Text = "Short";
            this.radioShort.TextAlign = ContentAlignment.MiddleCenter;
            this.radioShort.UseVisualStyleBackColor = true;
            this.radioShort.CheckedChanged += new EventHandler(this.radioShort_CheckedChanged);
            this.radioVeryShort.Appearance = Appearance.Button;
            this.radioVeryShort.FlatStyle = FlatStyle.Popup;
            this.radioVeryShort.Location = new Point(71, 17);
            this.radioVeryShort.Name = "radioVeryShort";
            this.radioVeryShort.Size = new Size(65, 23);
            this.radioVeryShort.TabIndex = 15;
            this.radioVeryShort.TabStop = true;
            this.radioVeryShort.Tag = (object)this.comboVeryShort;
            this.radioVeryShort.Text = "Very Short";
            this.radioVeryShort.TextAlign = ContentAlignment.MiddleCenter;
            this.radioVeryShort.UseVisualStyleBackColor = true;
            this.radioVeryShort.CheckedChanged += new EventHandler(this.radioVeryShort_CheckedChanged);
            this.groupHeadModel.Controls.Add((Control)this.comboLatinModels);
            this.groupHeadModel.Controls.Add((Control)this.radioButtonLatin);
            this.groupHeadModel.Controls.Add((Control)this.comboAsiaticModels);
            this.groupHeadModel.Controls.Add((Control)this.radioButtonAsiatic);
            this.groupHeadModel.Controls.Add((Control)this.comboAfricanModels);
            this.groupHeadModel.Controls.Add((Control)this.radioButtonAfrican);
            this.groupHeadModel.Controls.Add((Control)this.radioButtonCaucasic);
            this.groupHeadModel.Controls.Add((Control)this.comboCaucasicModels);
            this.groupHeadModel.Controls.Add((Control)this.buttonRandomizeAppearance);
            this.groupHeadModel.Location = new Point(6, 39);
            this.groupHeadModel.Name = "groupHeadModel";
            this.groupHeadModel.Size = new Size(364, 79);
            this.groupHeadModel.TabIndex = 28;
            this.groupHeadModel.TabStop = false;
            this.groupHeadModel.Text = "Head Model";
            this.comboLatinModels.FormattingEnabled = true;
            this.comboLatinModels.Items.AddRange(new object[42]
            {
        (object) "1500",
        (object) "1501",
        (object) "1502",
        (object) "1503",
        (object) "1504",
        (object) "1505",
        (object) "1506",
        (object) "1507",
        (object) "1508",
        (object) "1509",
        (object) "1510",
        (object) "1511",
        (object) "1512",
        (object) "1513",
        (object) "1514",
        (object) "1515",
        (object) "1516",
        (object) "1517",
        (object) "1518",
        (object) "1519",
        (object) "1520",
        (object) "1521",
        (object) "1522",
        (object) "1523",
        (object) "1524",
        (object) "1525",
        (object) "1526",
        (object) "1527",
        (object) "1528",
        (object) "2500",
        (object) "2501",
        (object) "2502",
        (object) "2503",
        (object) "2504",
        (object) "2505",
        (object) "2506",
        (object) "2507",
        (object) "2508",
        (object) "2509",
        (object) "2510",
        (object) "2511",
        (object) "2512"
            });
            this.comboLatinModels.Location = new Point(6, 48);
            this.comboLatinModels.Name = "comboLatinModels";
            this.comboLatinModels.Size = new Size(260, 21);
            this.comboLatinModels.TabIndex = 0;
            this.comboLatinModels.Visible = false;
            this.comboLatinModels.SelectedIndexChanged += new EventHandler(this.comboLatinModels_SelectedIndexChanged);
            this.radioButtonLatin.Appearance = Appearance.Button;
            this.radioButtonLatin.FlatStyle = FlatStyle.Popup;
            this.radioButtonLatin.Location = new Point(201, 19);
            this.radioButtonLatin.Name = "radioButtonLatin";
            this.radioButtonLatin.Size = new Size(65, 23);
            this.radioButtonLatin.TabIndex = 8;
            this.radioButtonLatin.TabStop = true;
            this.radioButtonLatin.Tag = (object)this.comboLatinModels;
            this.radioButtonLatin.Text = "Latin";
            this.radioButtonLatin.TextAlign = ContentAlignment.MiddleCenter;
            this.radioButtonLatin.UseVisualStyleBackColor = true;
            this.radioButtonLatin.CheckedChanged += new EventHandler(this.radioButtonLatin_CheckedChanged);
            this.comboAsiaticModels.FormattingEnabled = true;
            this.comboAsiaticModels.Items.AddRange(new object[33]
            {
        (object) "500",
        (object) "501",
        (object) "502",
        (object) "503",
        (object) "504",
        (object) "505",
        (object) "506",
        (object) "507",
        (object) "508",
        (object) "509",
        (object) "510",
        (object) "511",
        (object) "512",
        (object) "513",
        (object) "514",
        (object) "515",
        (object) "516",
        (object) "517",
        (object) "518",
        (object) "519",
        (object) "520",
        (object) "521",
        (object) "522",
        (object) "523",
        (object) "524",
        (object) "525",
        (object) "526",
        (object) "527",
        (object) "528",
        (object) "529",
        (object) "530",
        (object) "531",
        (object) "532"
            });
            this.comboAsiaticModels.Location = new Point(6, 48);
            this.comboAsiaticModels.Name = "comboAsiaticModels";
            this.comboAsiaticModels.Size = new Size(254, 21);
            this.comboAsiaticModels.TabIndex = 0;
            this.comboAsiaticModels.Visible = false;
            this.comboAsiaticModels.SelectedIndexChanged += new EventHandler(this.comboAsiaticModels_SelectedIndexChanged);
            this.radioButtonAsiatic.Appearance = Appearance.Button;
            this.radioButtonAsiatic.FlatStyle = FlatStyle.Popup;
            this.radioButtonAsiatic.Location = new Point(71, 19);
            this.radioButtonAsiatic.Name = "radioButtonAsiatic";
            this.radioButtonAsiatic.Size = new Size(65, 23);
            this.radioButtonAsiatic.TabIndex = 6;
            this.radioButtonAsiatic.TabStop = true;
            this.radioButtonAsiatic.Tag = (object)this.comboAsiaticModels;
            this.radioButtonAsiatic.Text = "Asiatic";
            this.radioButtonAsiatic.TextAlign = ContentAlignment.MiddleCenter;
            this.radioButtonAsiatic.UseVisualStyleBackColor = true;
            this.radioButtonAsiatic.CheckedChanged += new EventHandler(this.radioButtonAsiatic_CheckedChanged);
            this.comboAfricanModels.FormattingEnabled = true;
            this.comboAfricanModels.Items.AddRange(new object[36]
            {
        (object) "1000",
        (object) "1001",
        (object) "1002",
        (object) "1003",
        (object) "1004",
        (object) "1005",
        (object) "1006",
        (object) "1007",
        (object) "1008",
        (object) "1009",
        (object) "1010",
        (object) "1011",
        (object) "1012",
        (object) "1013",
        (object) "1014",
        (object) "1015",
        (object) "1016",
        (object) "1017",
        (object) "1018",
        (object) "1019",
        (object) "1020",
        (object) "1021",
        (object) "3000",
        (object) "3001",
        (object) "3002",
        (object) "3003",
        (object) "3004",
        (object) "3005",
        (object) "4500",
        (object) "4501",
        (object) "4502",
        (object) "4525",
        (object) "5000",
        (object) "5001",
        (object) "5002",
        (object) "5003"
            });
            this.comboAfricanModels.Location = new Point(6, 48);
            this.comboAfricanModels.Name = "comboAfricanModels";
            this.comboAfricanModels.Size = new Size(254, 21);
            this.comboAfricanModels.TabIndex = 1;
            this.comboAfricanModels.Visible = false;
            this.comboAfricanModels.SelectedIndexChanged += new EventHandler(this.comboAfricanModels_SelectedIndexChanged);
            this.radioButtonAfrican.Appearance = Appearance.Button;
            this.radioButtonAfrican.FlatStyle = FlatStyle.Popup;
            this.radioButtonAfrican.Location = new Point(6, 19);
            this.radioButtonAfrican.Name = "radioButtonAfrican";
            this.radioButtonAfrican.Size = new Size(65, 23);
            this.radioButtonAfrican.TabIndex = 5;
            this.radioButtonAfrican.TabStop = true;
            this.radioButtonAfrican.Tag = (object)this.comboAfricanModels;
            this.radioButtonAfrican.Text = "African";
            this.radioButtonAfrican.TextAlign = ContentAlignment.MiddleCenter;
            this.radioButtonAfrican.UseVisualStyleBackColor = true;
            this.radioButtonAfrican.CheckedChanged += new EventHandler(this.radioButtonAfrican_CheckedChanged);
            this.radioButtonCaucasic.Appearance = Appearance.Button;
            this.radioButtonCaucasic.FlatStyle = FlatStyle.Popup;
            this.radioButtonCaucasic.Location = new Point(136, 19);
            this.radioButtonCaucasic.Name = "radioButtonCaucasic";
            this.radioButtonCaucasic.Size = new Size(65, 23);
            this.radioButtonCaucasic.TabIndex = 7;
            this.radioButtonCaucasic.TabStop = true;
            this.radioButtonCaucasic.Tag = (object)this.comboCaucasicModels;
            this.radioButtonCaucasic.Text = "Caucasian";
            this.radioButtonCaucasic.TextAlign = ContentAlignment.MiddleCenter;
            this.radioButtonCaucasic.UseVisualStyleBackColor = true;
            this.radioButtonCaucasic.CheckedChanged += new EventHandler(this.radioButtonCaucasic_CheckedChanged);
            this.comboCaucasicModels.FormattingEnabled = true;
            this.comboCaucasicModels.Items.AddRange(new object[57]
            {
        (object) "1",
        (object) "2",
        (object) "3",
        (object) "4",
        (object) "5",
        (object) "6",
        (object) "7",
        (object) "8",
        (object) "9",
        (object) "10",
        (object) "11",
        (object) "12",
        (object) "13",
        (object) "14",
        (object) "15",
        (object) "16",
        (object) "17",
        (object) "18",
        (object) "19",
        (object) "20",
        (object) "21",
        (object) "22",
        (object) "23",
        (object) "24",
        (object) "25",
        (object) "2000",
        (object) "2001",
        (object) "2002",
        (object) "2003",
        (object) "2004",
        (object) "2005",
        (object) "2006",
        (object) "2007",
        (object) "2008",
        (object) "2009",
        (object) "2010",
        (object) "2011",
        (object) "2012",
        (object) "2013",
        (object) "2014",
        (object) "2015",
        (object) "2016",
        (object) "2017",
        (object) "2018",
        (object) "2019",
        (object) "2020",
        (object) "2021",
        (object) "3500",
        (object) "3501",
        (object) "3502",
        (object) "3503",
        (object) "3504",
        (object) "3505",
        (object) "4000",
        (object) "4001",
        (object) "4002",
        (object) "4003"
            });
            this.comboCaucasicModels.Location = new Point(6, 48);
            this.comboCaucasicModels.Name = "comboCaucasicModels";
            this.comboCaucasicModels.Size = new Size(254, 21);
            this.comboCaucasicModels.TabIndex = 2;
            this.comboCaucasicModels.Visible = false;
            this.comboCaucasicModels.SelectedIndexChanged += new EventHandler(this.comboCaucasicModels_SelectedIndexChanged);
            this.buttonRandomizeAppearance.ImeMode = ImeMode.NoControl;
            this.buttonRandomizeAppearance.Location = new Point(272, 20);
            this.buttonRandomizeAppearance.Name = "buttonRandomizeAppearance";
            this.buttonRandomizeAppearance.Size = new Size(86, 23);
            this.buttonRandomizeAppearance.TabIndex = 27;
            this.buttonRandomizeAppearance.Text = "Randomize";
            this.buttonRandomizeAppearance.UseVisualStyleBackColor = true;
            this.buttonRandomizeAppearance.Click += new EventHandler(this.buttonRandomizeAppearance_Click);
            this.labelHeadType.BackColor = SystemColors.Control;
            this.labelHeadType.ImeMode = ImeMode.NoControl;
            this.labelHeadType.Location = new Point(185, 132);
            this.labelHeadType.Name = "labelHeadType";
            this.labelHeadType.Size = new Size((int)sbyte.MaxValue, 20);
            this.labelHeadType.TabIndex = 11;
            this.labelHeadType.Text = "Head Model";
            this.labelHeadType.TextAlign = ContentAlignment.MiddleCenter;
            this.label1.AutoSize = true;
            this.label1.BackColor = Color.Transparent;
            this.label1.ImeMode = ImeMode.NoControl;
            this.label1.Location = new Point(320, 15);
            this.label1.Name = "label1";
            this.label1.Size = new Size(55, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Skin Color";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
            this.labelHairType.BackColor = SystemColors.Control;
            this.labelHairType.ImeMode = ImeMode.NoControl;
            this.labelHairType.Location = new Point(16, 204);
            this.labelHairType.Name = "labelHairType";
            this.labelHairType.Size = new Size(119, 20);
            this.labelHairType.TabIndex = 9;
            this.labelHairType.Text = "Hair Model";
            this.labelHairType.TextAlign = ContentAlignment.MiddleLeft;
            this.splitContainer3.BackColor = Color.Transparent;
            this.splitContainer3.Dock = DockStyle.Fill;
            this.splitContainer3.Location = new Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = Orientation.Horizontal;
            this.splitContainer3.Panel1.AutoScroll = true;
            this.splitContainer3.Panel1.Controls.Add((Control)this.multiViewerFace);
            this.splitContainer3.Panel1.Controls.Add((Control)this.buttonRgbHair);
            this.splitContainer3.Panel1.Controls.Add((Control)this.viewer2DSkinTexture);
            this.splitContainer3.Panel1.Controls.Add((Control)this.multiViewerHair);
            this.splitContainer3.Panel1.Controls.Add((Control)this.checkShowTexures);
            this.splitContainer3.Panel1.Controls.Add((Control)this.viewer2DEyeTexture);
            this.splitContainer3.Panel1.Controls.Add((Control)this.comboEyescolor);
            this.splitContainer3.Panel1.Controls.Add((Control)this.label2);
            this.splitContainer3.Panel2.AutoScroll = true;
            this.splitContainer3.Panel2.Controls.Add((Control)this.viewer2DPlayerGui);
            this.splitContainer3.Size = new Size(621, 780);
            this.splitContainer3.SplitterDistance = 570;
            this.splitContainer3.TabIndex = 0;
            this.multiViewerFace.AutoTransparency = false;
            this.multiViewerFace.Bitmaps = (Bitmap[])null;
            this.multiViewerFace.CheckBitmapSize = false;
            this.multiViewerFace.FixedSize = false;
            this.multiViewerFace.FullSizeButton = false;
            this.multiViewerFace.LabelText = "Image n.";
            this.multiViewerFace.Location = new Point(3, 26);
            this.multiViewerFace.Name = "multiViewerFace";
            this.multiViewerFace.ShowDeleteButton = false;
            this.multiViewerFace.Size = new Size(256, 301);
            this.multiViewerFace.TabIndex = 101;
            this.buttonRgbHair.BackgroundImage = (Image)resources.GetObject("buttonRgbHair.BackgroundImage");
            this.buttonRgbHair.BackgroundImageLayout = ImageLayout.Center;
            this.buttonRgbHair.Location = new Point(502, 302);
            this.buttonRgbHair.Name = "buttonRgbHair";
            this.buttonRgbHair.Size = new Size(25, 23);
            this.buttonRgbHair.TabIndex = 100;
            this.toolTip.SetToolTip((Control)this.buttonRgbHair, "Modify the RGB components");
            this.buttonRgbHair.UseVisualStyleBackColor = true;
            this.buttonRgbHair.Click += new EventHandler(this.buttonRgbHair_Click);
            this.viewer2DSkinTexture.AutoTransparency = false;
            this.viewer2DSkinTexture.BackColor = Color.Transparent;
            this.viewer2DSkinTexture.ButtonStripVisible = false;
            this.viewer2DSkinTexture.CurrentBitmap = (Bitmap)null;
            this.viewer2DSkinTexture.ExtendedFormat = false;
            this.viewer2DSkinTexture.FullSizeButton = false;
            this.viewer2DSkinTexture.ImageLayout = ImageLayout.Zoom;
            this.viewer2DSkinTexture.ImageSize = new Size(512, 512);
            this.viewer2DSkinTexture.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
            this.viewer2DSkinTexture.Location = new Point(137, 334);
            this.viewer2DSkinTexture.Name = "viewer2DSkinTexture";
            this.viewer2DSkinTexture.RemoveButton = false;
            this.viewer2DSkinTexture.ShowButton = false;
            this.viewer2DSkinTexture.ShowButtonChecked = true;
            this.viewer2DSkinTexture.Size = new Size(128, 153);
            this.viewer2DSkinTexture.TabIndex = 7;
            this.multiViewerHair.AutoTransparency = false;
            this.multiViewerHair.Bitmaps = (Bitmap[])null;
            this.multiViewerHair.CheckBitmapSize = false;
            this.multiViewerHair.FixedSize = false;
            this.multiViewerHair.FullSizeButton = false;
            this.multiViewerHair.LabelText = "Image n.";
            this.multiViewerHair.Location = new Point(271, 26);
            this.multiViewerHair.Name = "multiViewerHair";
            this.multiViewerHair.ShowDeleteButton = false;
            this.multiViewerHair.Size = new Size(256, 301);
            this.multiViewerHair.TabIndex = 5;
            this.checkShowTexures.AutoSize = true;
            this.checkShowTexures.Location = new Point(3, 7);
            this.checkShowTexures.Name = "checkShowTexures";
            this.checkShowTexures.Size = new Size(97, 17);
            this.checkShowTexures.TabIndex = 0;
            this.checkShowTexures.Text = "Show Textures";
            this.checkShowTexures.UseVisualStyleBackColor = true;
            this.checkShowTexures.CheckedChanged += new EventHandler(this.checkShowTexures_CheckedChanged);
            this.viewer2DEyeTexture.AutoTransparency = false;
            this.viewer2DEyeTexture.BackColor = Color.Transparent;
            this.viewer2DEyeTexture.ButtonStripVisible = false;
            this.viewer2DEyeTexture.CurrentBitmap = (Bitmap)null;
            this.viewer2DEyeTexture.ExtendedFormat = false;
            this.viewer2DEyeTexture.FullSizeButton = false;
            this.viewer2DEyeTexture.ImageLayout = ImageLayout.None;
            this.viewer2DEyeTexture.ImageSize = new Size(128, 128);
            this.viewer2DEyeTexture.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
            this.viewer2DEyeTexture.Location = new Point(3, 334);
            this.viewer2DEyeTexture.Name = "viewer2DEyeTexture";
            this.viewer2DEyeTexture.RemoveButton = false;
            this.viewer2DEyeTexture.ShowButton = false;
            this.viewer2DEyeTexture.ShowButtonChecked = true;
            this.viewer2DEyeTexture.Size = new Size(128, 153);
            this.viewer2DEyeTexture.TabIndex = 4;
            this.comboEyescolor.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboEyescolor.FormattingEnabled = true;
            this.comboEyescolor.Items.AddRange(new object[10]
            {
        (object) "Dark Blue",
        (object) "Light Blue",
        (object) "Dark Brown",
        (object) "Light Brown",
        (object) "Brown and Green",
        (object) "Dark Green",
        (object) "Light Green",
        (object) "Gray",
        (object) "Black",
        (object) "Dark Gray"
            });
            this.comboEyescolor.Location = new Point(3, 493);
            this.comboEyescolor.Name = "comboEyescolor";
            this.comboEyescolor.Size = new Size(128, 21);
            this.comboEyescolor.TabIndex = 2;
            this.comboEyescolor.SelectedIndexChanged += new EventHandler(this.comboEyescolor_SelectedIndexChanged);
            this.label2.AutoSize = true;
            this.label2.BackColor = Color.Transparent;
            this.label2.ImeMode = ImeMode.NoControl;
            this.label2.Location = new Point(43, 522);
            this.label2.Name = "label2";
            this.label2.Size = new Size(57, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Eyes Color";
            this.label2.TextAlign = ContentAlignment.MiddleLeft;
            this.viewer2DPlayerGui.AutoTransparency = true;
            this.viewer2DPlayerGui.BackColor = Color.Transparent;
            this.viewer2DPlayerGui.ButtonStripVisible = false;
            this.viewer2DPlayerGui.CurrentBitmap = (Bitmap)null;
            this.viewer2DPlayerGui.ExtendedFormat = false;
            this.viewer2DPlayerGui.FullSizeButton = false;
            this.viewer2DPlayerGui.ImageLayout = ImageLayout.Zoom;
            this.viewer2DPlayerGui.ImageSize = new Size(128, 128);
            this.viewer2DPlayerGui.ImageSizeMultiplier = Viewer2D.SizeMultiplier.MiniFace;
            this.viewer2DPlayerGui.Location = new Point(3, 4);
            this.viewer2DPlayerGui.Name = "viewer2DPlayerGui";
            this.viewer2DPlayerGui.RemoveButton = false;
            this.viewer2DPlayerGui.ShowButton = false;
            this.viewer2DPlayerGui.ShowButtonChecked = true;
            this.viewer2DPlayerGui.Size = new Size(128, 153);
            this.viewer2DPlayerGui.TabIndex = 126;
            this.imageListTabIcons.ImageStream = (ImageListStreamer)resources.GetObject("imageListTabIcons.ImageStream");
            this.imageListTabIcons.TransparentColor = Color.Fuchsia;
            this.imageListTabIcons.Images.SetKeyName(0, "Info_16.PNG");
            this.imageListTabIcons.Images.SetKeyName(1, "Star_16.PNG");
            this.imageListTabIcons.Images.SetKeyName(2, "Face_16.PNG");
            this.pickUpControl.BackColor = SystemColors.Control;
            this.pickUpControl.CloneButtonEnabled = true;
            this.pickUpControl.CreateButtonEnabled = true;
            this.pickUpControl.CurrentIndex = 0;
            this.pickUpControl.Dock = DockStyle.Top;
            this.pickUpControl.FilterByList = new string[7]
            {
        "All",
        "by Team",
        "by Country",
        "Free Agents",
        "Multi Club",
        "Same Name",
        "Specific Head"
            };
            this.pickUpControl.FilterEnabled = true;
            this.pickUpControl.FilterValues = (IdArrayList[])null;
            this.pickUpControl.Location = new Point(0, 0);
            this.pickUpControl.MainSelectionEnabled = true;
            this.pickUpControl.Name = "pickUpControl";
            this.pickUpControl.ObjectList = (IdArrayList)null;
            this.pickUpControl.RefreshButtonEnabled = true;
            this.pickUpControl.RemoveButtonEnabled = true;
            this.pickUpControl.SearchEnabled = true;
            this.pickUpControl.Size = new Size(1357, 25);
            this.pickUpControl.TabIndex = 0;
            this.pickUpControl.WizardButtonEnabled = false;
            this.pickUpControl.YoungPlayersEnabled = false;
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1357, 832);
            this.Controls.Add((Control)this.tabEditPlayer);
            this.Controls.Add((Control)this.pickUpControl);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "PlayerForm";
            this.Text = "PlayerForm";
            this.Load += new EventHandler(this.PlayerForm_Load);
            this.tabEditPlayer.ResumeLayout(false);
            this.pageInfo.ResumeLayout(false);
            this.flowPanelInfo.ResumeLayout(false);
            this.groupPlayerIdentity.ResumeLayout(false);
            this.groupPlayerIdentity.PerformLayout();
            ((ISupportInitialize)this.playerBindingSource).EndInit();
            this.numericPlayerId.EndInit();
            ((ISupportInitialize)this.countryListBindingSource).EndInit();
            this.groupBoxBody.ResumeLayout(false);
            this.groupBoxBody.PerformLayout();
            this.numericHeight.EndInit();
            this.numericWeight.EndInit();
            this.groupBoxLook.ResumeLayout(false);
            this.groupBoxLook.PerformLayout();
            this.numericGkGloves.EndInit();
            ((ISupportInitialize)this.pictureColorAcc2).EndInit();
            ((ISupportInitialize)this.pictureColorAcc3).EndInit();
            ((ISupportInitialize)this.pictureColorAcc4).EndInit();
            ((ISupportInitialize)this.pictureColorAcc1).EndInit();
            this.groupPlayFirTeam.ResumeLayout(false);
            this.groupPlayFirTeam.PerformLayout();
            this.groupIsLoan.ResumeLayout(false);
            this.groupIsLoan.PerformLayout();
            ((ISupportInitialize)this.teamListBindingSource).EndInit();
            this.groupShoes.ResumeLayout(false);
            this.groupShoes.PerformLayout();
            ((ISupportInitialize)this.pictureColorShoes2).EndInit();
            ((ISupportInitialize)this.pictureColorShoes1).EndInit();
            this.numericShoesBrand.EndInit();
            this.numericShoesDesign.EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pageSkills.ResumeLayout(false);
            this.flowPanelSkills.ResumeLayout(false);
            this.groupGenerateAttributes.ResumeLayout(false);
            this.groupGenerateAttributes.PerformLayout();
            this.trackOverallrating.EndInit();
            this.numericRandomize.EndInit();
            this.groupGoalkeperSkills.ResumeLayout(false);
            this.groupGoalkeperSkills.PerformLayout();
            this.trackGkKicking.EndInit();
            this.trackDiving.EndInit();
            this.trackPositioning.EndInit();
            this.trackReflexes.EndInit();
            this.trackHandling.EndInit();
            this.numericGoalkeeperSkills.EndInit();
            this.groupDefensiveSkills.ResumeLayout(false);
            this.groupDefensiveSkills.PerformLayout();
            this.trackInterception.EndInit();
            this.trackSliding.EndInit();
            this.numericDefensiveSkills.EndInit();
            this.trackTackling.EndInit();
            this.trackMarking.EndInit();
            this.trackAggression.EndInit();
            this.groupMidfielderSkills.ResumeLayout(false);
            this.groupMidfielderSkills.PerformLayout();
            this.trackCurve.EndInit();
            this.trackVision.EndInit();
            this.numericMidfielderSkills.EndInit();
            this.trackLongPassing.EndInit();
            this.trackShortPassing.EndInit();
            this.trackBallControl.EndInit();
            this.trackCrossing.EndInit();
            this.groupMental.ResumeLayout(false);
            this.groupMental.PerformLayout();
            this.numericMentalSkills.EndInit();
            this.trackPlayerPositioning.EndInit();
            this.trackPotential.EndInit();
            this.groupAttackingSkills.ResumeLayout(false);
            this.groupAttackingSkills.PerformLayout();
            this.numericUpDown2.EndInit();
            this.numericUpDown1.EndInit();
            this.trackHeading.EndInit();
            this.trackVolley.EndInit();
            this.numericAttackingSkills.EndInit();
            this.trackFinishing.EndInit();
            this.trackShotPower.EndInit();
            this.trackLongShot.EndInit();
            this.trackDribbling.EndInit();
            this.groupGenericAttributes.ResumeLayout(false);
            this.groupGenericAttributes.PerformLayout();
            this.numericUpDown3.EndInit();
            this.numericUpDown4.EndInit();
            this.trackBalance.EndInit();
            this.trackAgility.EndInit();
            this.numericPhysicalSkills.EndInit();
            this.trackStamina.EndInit();
            this.trackSprintSpeed.EndInit();
            this.trackAcceleration.EndInit();
            this.trackStrength.EndInit();
            this.trackReactions.EndInit();
            this.trackJumping.EndInit();
            this.groupFreeKick.ResumeLayout(false);
            this.groupFreeKick.PerformLayout();
            this.numericSkillMoves.EndInit();
            this.numericFreeKickSkills.EndInit();
            this.trackFreeKick.EndInit();
            this.trackPenalties.EndInit();
            this.groupTraits.ResumeLayout(false);
            this.groupTraits.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pageFace.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tool3D.ResumeLayout(false);
            this.tool3D.PerformLayout();
            this.groupGenericFace.ResumeLayout(false);
            this.groupGenericFace.PerformLayout();
            this.groupGenericFaceType.ResumeLayout(false);
            this.groupGenericFaceType.PerformLayout();
            this.numericSkinTone.EndInit();
            this.groupHairModel.ResumeLayout(false);
            this.groupHairModel.PerformLayout();
            this.groupHeadModel.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        public PlayerForm()
        {
            this.Visible = false;
            this.InitializeComponent();
            this.viewer3D.RotationYCoeff = 1f / 1000f;
            this.comboLatinModels.Items.Clear();
            for (int index = 0; index < GenericHead.c_LatinModels.Length; ++index)
                this.comboLatinModels.Items.Add((object)GenericHead.c_LatinModels[index].ToString());
            this.comboCaucasicModels.Items.Clear();
            for (int index = 0; index < GenericHead.c_CaucasicModels.Length; ++index)
                this.comboCaucasicModels.Items.Add((object)GenericHead.c_CaucasicModels[index].ToString());
            this.comboAfricanModels.Items.Clear();
            for (int index = 0; index < GenericHead.c_AfricanModels.Length; ++index)
                this.comboAfricanModels.Items.Add((object)GenericHead.c_AfricanModels[index].ToString());
            this.comboAsiaticModels.Items.Clear();
            for (int index = 0; index < GenericHead.c_AsiaticModels.Length; ++index)
                this.comboAsiaticModels.Items.Add((object)GenericHead.c_AsiaticModels[index].ToString());
            this.comboShaven.Items.Clear();
            for (int index = 0; index < GenericHead.c_ShavenModels.Length; ++index)
                this.comboShaven.Items.Add((object)GenericHead.c_ShavenModels[index].ToString());
            this.comboVeryShort.Items.Clear();
            for (int index = 0; index < GenericHead.c_VeryShortModels.Length; ++index)
                this.comboVeryShort.Items.Add((object)GenericHead.c_VeryShortModels[index].ToString());
            this.comboShort.Items.Clear();
            for (int index = 0; index < GenericHead.c_ShortModels.Length; ++index)
                this.comboShort.Items.Add((object)GenericHead.c_ShortModels[index].ToString());
            this.comboModern.Items.Clear();
            for (int index = 0; index < GenericHead.c_ModernModels.Length; ++index)
                this.comboModern.Items.Add((object)GenericHead.c_ModernModels[index].ToString());
            this.comboMedium.Items.Clear();
            for (int index = 0; index < GenericHead.c_MediumModels.Length; ++index)
                this.comboMedium.Items.Add((object)GenericHead.c_MediumModels[index].ToString());
            this.comboLong.Items.Clear();
            for (int index = 0; index < GenericHead.c_LongModels.Length; ++index)
                this.comboLong.Items.Add((object)GenericHead.c_LongModels[index].ToString());
            this.comboAfro.Items.Clear();
            for (int index = 0; index < GenericHead.c_AfroModels.Length; ++index)
                this.comboAfro.Items.Add((object)GenericHead.c_AfroModels[index].ToString());
            this.comboHeadband.Items.Clear();
            for (int index = 0; index < GenericHead.c_HeadbendModels.Length; ++index)
                this.comboHeadband.Items.Add((object)GenericHead.c_HeadbendModels[index].ToString());
            this.pickUpControl.SelectObject = new PickUpControl.PickUpCallback(this.SelectPlayer);
            this.pickUpControl.CreateObject = new PickUpControl.PickUpCallback(this.CreatePlayer);
            this.pickUpControl.DeleteObject = new PickUpControl.PickUpCallback(this.DeletePlayer);
            this.pickUpControl.CloneObject = new PickUpControl.PickUpCallback(this.ClonePlayer);
            this.pickUpControl.RefreshObject = new PickUpControl.PickUpCallback(this.RefreshPlayer);
            this.pickUpControl.combo.Sorted = false;
            this.viewer2DPhoto.ButtonStripVisible = true;
            this.viewer2DPlayerGui.ButtonStripVisible = true;
            this.viewer2DShoes.ButtonStripVisible = false;
            this.viewer2DEyeTexture.ButtonStripVisible = true;
            this.viewer2DEyeTexture.ShowButton = true;
            this.viewer2DSkinTexture.ShowButton = true;
            this.viewer2DEyeTexture.ShowButtonChecked = true;
            this.viewer2DSkinTexture.ShowButtonChecked = true;
            this.viewer2DPlayerGui.ButtonStripVisible = true;
            this.viewer2DShoes.ButtonStripVisible = false;
            this.viewer2DEyeTexture.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageEye);
            this.viewer2DEyeTexture.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteImageEye);
            this.viewer2DEyeTexture.ButtonStripVisible = true;
            this.viewer2DEyeTexture.RemoveButton = true;
            this.viewer2DSkinTexture.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageSkin);
            this.viewer2DSkinTexture.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteImageSkin);
            this.viewer2DSkinTexture.ButtonStripVisible = true;
            this.viewer2DSkinTexture.RemoveButton = true;
            this.multiViewerHair.Rx3ExportDelegate = new MultiViewer2D.Rx3ExportHandler(this.ExportRx3HairTextures);
            this.multiViewerHair.Rx3ImportDelegate = new MultiViewer2D.Rx3ImportHandler(this.ImportRx3HairTextures);
            this.multiViewerHair.Rx3SaveDelegate = new MultiViewer2D.Rx3SaveHandler(this.SaveRx3HairTextures);
            this.multiViewerHair.Rx3DeleteDelegate = new MultiViewer2D.Rx3DeleteHandler(this.DeleteRx3HairTextures);
            this.multiViewerHair.ShowDeleteButton = true;
            this.multiViewerFace.Rx3ExportDelegate = new MultiViewer2D.Rx3ExportHandler(this.ExportRx3FaceTextures);
            this.multiViewerFace.Rx3ImportDelegate = new MultiViewer2D.Rx3ImportHandler(this.ImportRx3FaceTextures);
            this.multiViewerFace.Rx3SaveDelegate = new MultiViewer2D.Rx3SaveHandler(this.SaveRx3FaceTextures);
            this.multiViewerFace.Rx3DeleteDelegate = new MultiViewer2D.Rx3DeleteHandler(this.DeleteRx3FaceTextures);
            this.multiViewerFace.ShowDeleteButton = true;
            this.viewer2DPlayerGui.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageMiniface);
            this.viewer2DPlayerGui.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteMiniface);
            this.viewer2DPlayerGui.ButtonStripVisible = true;
            this.viewer2DPlayerGui.RemoveButton = true;
            this.viewer2DPhoto.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageMiniface);
            this.viewer2DPhoto.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteMiniface);
            this.viewer2DPhoto.ButtonStripVisible = true;
            this.viewer2DPhoto.RemoveButton = true;
            this.viewer2DPhoto.ShowButton = true;
            this.viewer2DPhoto.ShowButtonChecked = true;
            this.tool3D.Visible = true;
        }

        private Player CreatePlayer(object sender, object obj)
        {
            DialogResult dialogResult = this.m_NewIdCreator.ShowDialog();
            if (this.m_NewIdCreator.NewObject != null)
                return (Player)this.m_NewIdCreator.NewObject;
            if (dialogResult == DialogResult.OK)
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(5060, this.m_NewIdCreator.NewId);
            }
            return (Player)null;
        }

        private Player DeletePlayer(object sender, object obj)
        {
            Player player = (Player)obj;
            while (player.m_PlayingForTeams.Count > 0)
                ((Team)player.m_PlayingForTeams[0]).RemoveTeamPlayer(player);
            FifaEnvironment.Players.DeletePlayer(player);
            return (Player)null;
        }

        private Player ClonePlayer(object sender, object obj)
        {
            DialogResult dialogResult = this.m_NewIdCreator.ShowDialog();
            if (this.m_NewIdCreator.NewObject != null)
                return (Player)FifaEnvironment.Players.CloneId((IdObject)obj, this.m_NewIdCreator.NewObject);
            if (dialogResult == DialogResult.OK)
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(5060, this.m_NewIdCreator.NewId);
            }
            return (Player)null;
        }

        public Player RefreshPlayer(object sender, object obj)
        {
            this.m_CurrentPlayer.CleanAllHead();
            this.Preset();
            this.ReloadPlayer(this.m_CurrentPlayer);
            return this.m_CurrentPlayer;
        }

        private bool ImportImageEye(object sender, Bitmap bitmap)
        {
            bool flag = this.m_CurrentPlayer.SetEyesTextures(bitmap);
            if (flag)
                this.UpdateAndShowHead3D();
            return flag;
        }

        private bool DeleteImageEye(object sender)
        {
            return this.m_CurrentPlayer.DeleteEyesTexture();
        }

        private bool ImportImageSkin(object sender, Bitmap bitmap)
        {
            bool flag = this.m_CurrentPlayer.SetSkinTextures(bitmap);
            if (flag)
                this.UpdateAndShowHead3D();
            return flag;
        }

        private bool DeleteImageSkin(object sender)
        {
            return this.m_CurrentPlayer.DeleteSkinTexture();
        }

        private bool ExportRx3HairTextures(object sender, string exportDir)
        {
            return FifaEnvironment.ExportFileFromZdata(this.m_CurrentPlayer.HairTexturesFileName(), exportDir);
        }

        private bool SaveRx3HairTextures(object sender, Bitmap[] bitmaps)
        {
            bool flag = this.m_CurrentPlayer.SetHairTextures(bitmaps);
            if (flag)
            {
                this.m_CurrentPlayer.CleanHairTextures();
                this.multiViewerHair.Bitmaps = this.m_CurrentPlayer.GetHairTextures();
                this.multiViewerHair.Enabled = true;
                this.UpdateAndShowHead3D();
            }
            return flag;
        }

        private bool ImportRx3HairTextures(object sender, string rx3FileName)
        {
            bool flag = this.m_CurrentPlayer.SetHairTextures(rx3FileName);
            if (flag)
            {
                this.m_CurrentPlayer.CleanHairTextures();
                this.multiViewerHair.Bitmaps = this.m_CurrentPlayer.GetHairTextures();
                this.multiViewerHair.Enabled = true;
            }
            return flag;
        }

        private bool DeleteRx3HairTextures(object sender)
        {
            bool flag = this.m_CurrentPlayer.DeleteHairTextures();
            int num = flag ? 1 : 0;
            return flag;
        }

        private bool ExportRx3FaceTextures(object sender, string exportDir)
        {
            return FifaEnvironment.ExportFileFromZdata(this.m_CurrentPlayer.FaceTextureFileName(), exportDir);
        }

        private bool SaveRx3FaceTextures(object sender, Bitmap[] bitmaps)
        {
            bool flag = this.m_CurrentPlayer.SetFaceTextures(bitmaps);
            if (flag)
            {
                this.m_CurrentPlayer.CleanFaceTextures();
                this.GetAndShowFaceTexture();
                this.UpdateAndShowHead3D();
            }
            return flag;
        }

        private bool ImportRx3FaceTextures(object sender, string rx3FileName)
        {
            bool flag = this.m_CurrentPlayer.SetFaceTextures(rx3FileName);
            if (flag)
            {
                this.m_CurrentPlayer.CleanFaceTextures();
                this.GetAndShowFaceTexture();
                this.UpdateAndShowHead3D();
            }
            return flag;
        }

        private bool DeleteRx3FaceTextures(object sender)
        {
            bool flag = this.m_CurrentPlayer.DeleteFaceTexture();
            if (flag)
            {
                this.GetAndShowFaceTexture();
                this.UpdateAndShowHead3D();
            }
            return flag;
        }

        private bool ImportImageMiniface(object sender, Bitmap bitmap)
        {
            return this.m_CurrentPlayer.SetPhoto(bitmap);
        }

        private bool DeleteMiniface(object sender)
        {
            return this.m_CurrentPlayer.DeletePhoto();
        }

        public void Clean()
        {
            this.Visible = false;
        }

        private Player SelectPlayer(object sender, object obj)
        {
            Player player = (Player)obj;
            this.LoadPlayer(player);
            return player;
        }

        public void ReloadPlayer(Player player)
        {
            this.m_CurrentPlayer = (Player)null;
            this.LoadPlayer(player);
        }

        public void LoadPlayer(Player player)
        {
            if (!this.m_IsLoaded || this.m_CurrentPlayer == player && this.m_CurrentPage == this.tabEditPlayer.SelectedTab)
                return;
            this.m_Locked = true;
            this.m_CurrentPlayer = player;
            this.buttonSaveHair.Enabled = false;
            this.playerBindingSource.DataSource = (object)this.m_CurrentPlayer;
            this.playerBindingSource.ResetBindings(false);
            this.Refresh();
            this.m_CurrentPage = this.tabEditPlayer.SelectedTab;
            if (this.m_CurrentPage == this.pageInfo)
                this.LoadPlayerInfo();
            else if (this.m_CurrentPage == this.pageSkills)
                this.LoadPlayerSkills();
            else if (this.m_CurrentPage == this.pageFace)
                this.LoadPlayerFace();
            this.m_Locked = false;
        }

        private void LoadPlayerInfo()
        {
            this.numericPlayerId.Value = (Decimal)this.m_CurrentPlayer.Id;
            this.viewer2DPhoto.CurrentBitmap = !this.viewer2DPhoto.ShowButton ? (Bitmap)null : this.m_CurrentPlayer.GetPhoto();
            this.InitListViewPlayingTeams(this.m_CurrentPlayer.m_PlayingForTeams);
            this.pictureColorAcc1.BackColor = PlayerForm.c_AccPalette[this.m_CurrentPlayer.accessorycolourcode1];
            this.pictureColorAcc2.BackColor = PlayerForm.c_AccPalette[this.m_CurrentPlayer.accessorycolourcode2];
            this.pictureColorAcc3.BackColor = PlayerForm.c_AccPalette[this.m_CurrentPlayer.accessorycolourcode3];
            this.pictureColorAcc4.BackColor = PlayerForm.c_AccPalette[this.m_CurrentPlayer.accessorycolourcode4];
            this.comboPreferredPosition1.SelectedIndex = this.m_CurrentPlayer.preferredposition1 + 1;
            this.comboPreferredPosition2.SelectedIndex = this.m_CurrentPlayer.preferredposition2 + 1;
            this.comboPreferredPosition3.SelectedIndex = this.m_CurrentPlayer.preferredposition3 + 1;
            this.comboPreferredPosition4.SelectedIndex = this.m_CurrentPlayer.preferredposition4 + 1;
            this.numericShoesBrand.Value = (Decimal)this.m_CurrentPlayer.shoetypecode;
            this.numericShoesDesign.Value = (Decimal)this.m_CurrentPlayer.shoedesigncode;
            this.pictureColorShoes1.BackColor = Shoes.GetGenericColor(this.m_CurrentPlayer.shoecolorcode1);
            this.pictureColorShoes2.BackColor = Shoes.GetGenericColor(this.m_CurrentPlayer.shoecolorcode2);
            if (this.m_CurrentPlayer.shoetypecode == 0)
            {
                this.numericShoesDesign.Enabled = true;
                this.pictureColorShoes1.Enabled = true;
                this.pictureColorShoes2.Enabled = true;
            }
            else
            {
                this.numericShoesDesign.Enabled = false;
                this.pictureColorShoes1.Enabled = false;
                this.pictureColorShoes2.Enabled = false;
                this.numericShoesDesign.Value = new Decimal(0);
            }
            this.viewer2DShoes.CurrentBitmap = Shoes.GetShoesColorTexture(this.m_CurrentPlayer.shoetypecode, this.m_CurrentPlayer.shoedesigncode);
        }

        private void LoadPlayerSkills()
        {
            this.m_OverallSema = false;
            this.numericRandomize.Value = (Decimal)this.m_CurrentPlayer.GetAverageRoleAttribute();
            this.m_OverallSema = true;
            this.labelSkillsStars.ImageIndex = this.m_CurrentPlayer.skillmoves;
            this.playerBindingSource.ResetBindings(false);
        }

        public void Preset()
        {
            Kit.Prepare3DModels();
            this.m_NewIdCreator.IdList = (IdArrayList)FifaEnvironment.Players;
            this.pickUpControl.FilterValues = new IdArrayList[7]
            {
        (IdArrayList) null,
        (IdArrayList) FifaEnvironment.Teams,
        (IdArrayList) FifaEnvironment.Countries,
        (IdArrayList) FifaEnvironment.FreeAgents,
        (IdArrayList) new MultiClubList(),
        (IdArrayList) new SameNameList(),
        (IdArrayList) new SpecificHeadList()
            };
            this.numericShoesBrand.Maximum = (Decimal)FifaEnvironment.FifaDb.Table[TI.players].TableDescriptor.MaxValues[FI.players_shoetypecode];
            this.numericPlayerId.Maximum = (Decimal)FifaEnvironment.FifaDb.Table[TI.teams].TableDescriptor.MaxValues[FI.teams_captainid];
            this.numericSkinTone.Maximum = (Decimal)FifaEnvironment.FifaDb.Table[TI.players].TableDescriptor.MaxValues[FI.players_skintonecode];
            int year = FifaEnvironment.Year;
            this.countryListBindingSource.DataSource = (object)FifaEnvironment.Countries;
            this.teamListBindingSource.DataSource = (object)FifaEnvironment.Teams;
            this.pickUpControl.ObjectList = (IdArrayList)FifaEnvironment.Players;
        }

        private void InitListViewPlayingTeams(TeamList playingTeams)
        {
            this.listViewPlayingTeams.BeginUpdate();
            this.listViewPlayingTeams.Items.Clear();
            this.imageListTeamLogos.Images.Clear();
            for (int index = 0; index < playingTeams.Count; ++index)
            {
                Team playingTeam = (Team)playingTeams[index];
                Bitmap crest32 = playingTeam.GetCrest32();
                if (crest32 != null)
                    this.imageListTeamLogos.Images.Add(playingTeam.ToString(), (Image)crest32);
                this.listViewPlayingTeams.Items.Add(new ListViewItem(playingTeam.ToString())
                {
                    Tag = (object)playingTeam
                });
                this.listViewPlayingTeams.Items[index].ImageKey = playingTeam.ToString();
            }
            if (this.listViewPlayingTeams.Items.Count > 0)
                this.listViewPlayingTeams.Items[0].Selected = true;
            this.listViewPlayingTeams.EndUpdate();
        }

        private void PlayerForm_Load(object sender, EventArgs e)
        {
            this.m_IsLoaded = true;
            this.Preset();
        }

        private void buttonGetId_Click(object sender, EventArgs e)
        {
            int newId = FifaEnvironment.Players.GetNewId();
            if (newId == -1)
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(5050);
            }
            else
                this.numericPlayerId.Value = (Decimal)newId;
        }

        private void buttonRandomizeIdentity_Click(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.RandomizeIdentity();
            this.LoadPlayer(this.m_CurrentPlayer);
        }

        private void labelCountry_DoubleClick(object sender, EventArgs e)
        {
            if (this.m_CurrentPlayer.Country == null)
                return;
            MainForm.CM.JumpTo((IdObject)this.m_CurrentPlayer.Country);
        }

        private void labelShoes_DoubleClick(object sender, EventArgs e)
        {
            Shoes shoes = (Shoes)FifaEnvironment.Shoes.SearchId(this.m_CurrentPlayer.shoetypecode);
            if (shoes == null)
                return;
            MainForm.CM.JumpTo((IdObject)shoes);
        }

        private void numericPlayerId_ValueChanged(object sender, EventArgs e)
        {
            if (this.m_Locked)
                return;
            int num1 = (int)this.numericPlayerId.Value;
            if (num1 == this.m_CurrentPlayer.Id)
                return;
            if (FifaEnvironment.Players.SearchId(num1) == null)
            {
                FifaEnvironment.Players.ChangeId((IdObject)this.m_CurrentPlayer, num1);
                this.m_CurrentPlayer.ChangeId();
                this.m_CurrentPlayer.m_assetid = num1;
                this.m_CurrentPlayer.CleanFaceTextures();
                this.m_CurrentPlayer.CleanHairTextures();
                this.LoadPlayerFace();
                this.viewer2DPhoto.CurrentBitmap = this.m_CurrentPlayer.GetPhoto();
            }
            else
            {
                int num2 = (int)FifaEnvironment.UserMessages.ShowMessage(1015);
                this.numericPlayerId.Value = (Decimal)this.m_CurrentPlayer.Id;
            }
        }

        private void numericShoesBrand_ValueChanged(object sender, EventArgs e)
        {
            if (this.m_Locked)
                return;
            int shoesBrand = (int)this.numericShoesBrand.Value;
            if (shoesBrand == 0)
            {
                this.m_CurrentPlayer.shoetypecode = shoesBrand;
                this.m_CurrentPlayer.shoecolorcode1 = 0;
                this.m_CurrentPlayer.shoecolorcode2 = 15;
                this.pictureColorShoes1.BackColor = Shoes.ShoesColorPalette[this.m_CurrentPlayer.shoecolorcode1];
                this.pictureColorShoes2.BackColor = Shoes.ShoesColorPalette[this.m_CurrentPlayer.shoecolorcode2];
                this.numericShoesDesign.Enabled = true;
                this.pictureColorShoes1.Enabled = true;
                this.pictureColorShoes2.Enabled = true;
            }
            else
            {
                this.m_CurrentPlayer.shoetypecode = shoesBrand;
                this.numericShoesDesign.Enabled = false;
                this.pictureColorShoes1.Enabled = false;
                this.pictureColorShoes2.Enabled = false;
                this.pictureColorShoes1.BackColor = Color.Transparent;
                this.pictureColorShoes2.BackColor = Color.Transparent;
                this.m_CurrentPlayer.shoedesigncode = 0;
                this.m_CurrentPlayer.shoecolorcode1 = 30;
                this.m_CurrentPlayer.shoecolorcode2 = 31;
                this.numericShoesDesign.Value = new Decimal(0);
            }
            this.viewer2DShoes.CurrentBitmap = Shoes.GetShoesColorTexture(shoesBrand, 0);
        }

        private void numericShoesDesign_ValueChanged(object sender, EventArgs e)
        {
            if (this.m_Locked)
                return;
            int shoesDesign = (int)this.numericShoesDesign.Value;
            this.m_CurrentPlayer.shoedesigncode = shoesDesign;
            if (this.m_CurrentPlayer.shoetypecode != 0)
                return;
            this.viewer2DShoes.CurrentBitmap = Shoes.GetShoesColorTexture(0, shoesDesign);
        }

        private void pictureColorAcc1_Click(object sender, EventArgs e)
        {
            ColorSelector colorSelector = new ColorSelector(PlayerForm.c_AccPalette, this.m_CurrentPlayer.accessorycolourcode1);
            if (colorSelector.ShowDialog() == DialogResult.OK)
            {
                this.m_CurrentPlayer.accessorycolourcode1 = colorSelector.SelectedIndex;
                this.pictureColorAcc1.BackColor = colorSelector.SelectedColor;
            }
            colorSelector.Dispose();
        }

        private void pictureColorAcc2_Click(object sender, EventArgs e)
        {
            ColorSelector colorSelector = new ColorSelector(PlayerForm.c_AccPalette, this.m_CurrentPlayer.accessorycolourcode2);
            if (colorSelector.ShowDialog() == DialogResult.OK)
            {
                this.m_CurrentPlayer.accessorycolourcode2 = colorSelector.SelectedIndex;
                this.pictureColorAcc2.BackColor = colorSelector.SelectedColor;
            }
            colorSelector.Dispose();
        }

        private void pictureColorAcc3_Click(object sender, EventArgs e)
        {
            ColorSelector colorSelector = new ColorSelector(PlayerForm.c_AccPalette, this.m_CurrentPlayer.accessorycolourcode3);
            if (colorSelector.ShowDialog() == DialogResult.OK)
            {
                this.m_CurrentPlayer.accessorycolourcode3 = colorSelector.SelectedIndex;
                this.pictureColorAcc3.BackColor = colorSelector.SelectedColor;
            }
            colorSelector.Dispose();
        }

        private void pictureColorAcc4_Click(object sender, EventArgs e)
        {
            ColorSelector colorSelector = new ColorSelector(PlayerForm.c_AccPalette, this.m_CurrentPlayer.accessorycolourcode4);
            if (colorSelector.ShowDialog() == DialogResult.OK)
            {
                this.m_CurrentPlayer.accessorycolourcode4 = colorSelector.SelectedIndex;
                this.pictureColorAcc4.BackColor = colorSelector.SelectedColor;
            }
            colorSelector.Dispose();
        }

        private void trackReflexes_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.gkreflexes = this.trackReflexes.Value;
            this.labelReflexes.Text = this.labelReflexes.Text.Substring(0, this.labelReflexes.Text.IndexOf(' '));
            Label labelReflexes = this.labelReflexes;
            labelReflexes.Text = labelReflexes.Text + " " + this.m_CurrentPlayer.gkreflexes.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericGoalkeeperSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(0);
            this.m_AttributesSema = true;
        }

        private void trackHandling_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.gkhandling = this.trackHandling.Value;
            this.labelHandling.Text = this.labelHandling.Text.Substring(0, this.labelHandling.Text.IndexOf(' '));
            Label labelHandling = this.labelHandling;
            labelHandling.Text = labelHandling.Text + " " + this.m_CurrentPlayer.gkhandling.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericGoalkeeperSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(0);
            this.m_AttributesSema = true;
        }

        private void trackDiving_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.gkdiving = this.trackDiving.Value;
            this.labelDiving.Text = this.labelDiving.Text.Substring(0, this.labelDiving.Text.IndexOf(' '));
            Label labelDiving = this.labelDiving;
            labelDiving.Text = labelDiving.Text + " " + this.m_CurrentPlayer.gkdiving.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericGoalkeeperSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(0);
            this.m_AttributesSema = true;
        }

        private void trackPositioning_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.gkpositioning = this.trackPositioning.Value;
            this.labelPositioning.Text = this.labelPositioning.Text.Substring(0, this.labelPositioning.Text.IndexOf(' '));
            Label labelPositioning = this.labelPositioning;
            labelPositioning.Text = labelPositioning.Text + " " + this.m_CurrentPlayer.gkpositioning.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericGoalkeeperSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(0);
            this.m_AttributesSema = true;
        }

        private void trackGkKick_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.gkkicking = this.trackGkKicking.Value;
            this.labelGkKick.Text = this.labelGkKick.Text.Substring(0, this.labelGkKick.Text.IndexOf(' '));
            Label labelGkKick = this.labelGkKick;
            labelGkKick.Text = labelGkKick.Text + " " + this.m_CurrentPlayer.gkkicking.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericGoalkeeperSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(0);
            this.m_AttributesSema = true;
        }

        private void trackMarking_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.marking = this.trackMarking.Value;
            this.labelMarking.Text = this.labelMarking.Text.Substring(0, this.labelMarking.Text.IndexOf(' '));
            Label labelMarking = this.labelMarking;
            labelMarking.Text = labelMarking.Text + " " + this.m_CurrentPlayer.marking.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericDefensiveSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(1);
            this.m_AttributesSema = true;
        }

        private void trackTackling_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.standingtackle = this.trackTackling.Value;
            this.labelTackling.Text = this.labelTackling.Text.Substring(0, this.labelTackling.Text.IndexOf(' '));
            Label labelTackling = this.labelTackling;
            labelTackling.Text = labelTackling.Text + " " + this.m_CurrentPlayer.standingtackle.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericDefensiveSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(1);
            this.m_AttributesSema = true;
        }

        private void trackSliding_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.slidingtackle = this.trackSliding.Value;
            this.labelSliding.Text = this.labelSliding.Text.Substring(0, this.labelSliding.Text.IndexOf(' '));
            Label labelSliding = this.labelSliding;
            labelSliding.Text = labelSliding.Text + " " + this.m_CurrentPlayer.slidingtackle.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericDefensiveSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(1);
            this.m_AttributesSema = true;
        }

        private void trackAggression_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.aggression = this.trackAggression.Value;
            this.labelAggression.Text = this.labelAggression.Text.Substring(0, this.labelAggression.Text.IndexOf(' '));
            Label labelAggression = this.labelAggression;
            labelAggression.Text = labelAggression.Text + " " + this.m_CurrentPlayer.aggression.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericDefensiveSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(1);
            this.m_AttributesSema = true;
        }

        private void trackShortPassing_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.shortpassing = this.trackShortPassing.Value;
            this.labelShortPassing.Text = this.labelShortPassing.Text.Substring(0, this.labelShortPassing.Text.IndexOf(' '));
            Label labelShortPassing = this.labelShortPassing;
            labelShortPassing.Text = labelShortPassing.Text + " " + this.m_CurrentPlayer.shortpassing.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericMidfielderSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(2);
            this.m_AttributesSema = true;
        }

        private void trackLongPassing_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.longpassing = this.trackLongPassing.Value;
            this.labelLongPassing.Text = this.labelLongPassing.Text.Substring(0, this.labelLongPassing.Text.IndexOf(' '));
            Label labelLongPassing = this.labelLongPassing;
            labelLongPassing.Text = labelLongPassing.Text + " " + this.m_CurrentPlayer.longpassing.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericMidfielderSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(2);
            this.m_AttributesSema = true;
        }

        private void trackCrossing_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.crossing = this.trackCrossing.Value;
            this.labelCrossing.Text = this.labelCrossing.Text.Substring(0, this.labelCrossing.Text.IndexOf(' '));
            Label labelCrossing = this.labelCrossing;
            labelCrossing.Text = labelCrossing.Text + " " + this.m_CurrentPlayer.crossing.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericMidfielderSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(2);
            this.m_AttributesSema = true;
        }

        private void trackBallControl_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.ballcontrol = this.trackBallControl.Value;
            this.labelBallControl.Text = this.labelBallControl.Text.Substring(0, this.labelBallControl.Text.IndexOf(' '));
            Label labelBallControl = this.labelBallControl;
            labelBallControl.Text = labelBallControl.Text + " " + this.m_CurrentPlayer.ballcontrol.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericMidfielderSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(2);
            this.m_AttributesSema = true;
        }

        private void trackVision_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.vision = this.trackVision.Value;
            this.labelVision.Text = this.labelVision.Text.Substring(0, this.labelVision.Text.IndexOf(' '));
            Label labelVision = this.labelVision;
            labelVision.Text = labelVision.Text + " " + this.m_CurrentPlayer.vision.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericMidfielderSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(2);
            this.m_AttributesSema = true;
        }

        private void trackCurve_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.curve = this.trackCurve.Value;
            this.labelCurve.Text = this.labelCurve.Text.Substring(0, this.labelCurve.Text.IndexOf(' '));
            Label labelCurve = this.labelCurve;
            labelCurve.Text = labelCurve.Text + " " + this.m_CurrentPlayer.curve.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericMidfielderSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(2);
            this.m_AttributesSema = true;
        }

        private void trackHeading_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.headingaccuracy = this.trackHeading.Value;
            this.labelHeading.Text = this.labelHeading.Text.Substring(0, this.labelHeading.Text.IndexOf(' '));
            Label labelHeading = this.labelHeading;
            labelHeading.Text = labelHeading.Text + " " + this.m_CurrentPlayer.headingaccuracy.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericAttackingSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(3);
            this.m_AttributesSema = true;
        }

        private void trackFinishing_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.finishing = this.trackFinishing.Value;
            this.labelFinishing.Text = this.labelFinishing.Text.Substring(0, this.labelFinishing.Text.IndexOf(' '));
            Label labelFinishing = this.labelFinishing;
            labelFinishing.Text = labelFinishing.Text + " " + this.m_CurrentPlayer.finishing.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericAttackingSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(3);
            this.m_AttributesSema = true;
        }

        private void trackShotPower_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.shotpower = this.trackShotPower.Value;
            this.labelShotPower.Text = this.labelShotPower.Text.Substring(0, this.labelShotPower.Text.IndexOf(' '));
            Label labelShotPower = this.labelShotPower;
            labelShotPower.Text = labelShotPower.Text + " " + this.m_CurrentPlayer.shotpower.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericAttackingSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(3);
            this.m_AttributesSema = true;
        }

        private void trackLongShot_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.longshots = this.trackLongShot.Value;
            this.labelLongShot.Text = this.labelLongShot.Text.Substring(0, this.labelLongShot.Text.IndexOf(' '));
            Label labelLongShot = this.labelLongShot;
            labelLongShot.Text = labelLongShot.Text + " " + this.m_CurrentPlayer.longshots.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericAttackingSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(3);
            this.m_AttributesSema = true;
        }

        private void trackFreeKick_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.freekickaccuracy = this.trackFreeKick.Value;
            this.labelFreeKick.Text = this.labelFreeKick.Text.Substring(0, this.labelFreeKick.Text.IndexOf(' '));
            Label labelFreeKick = this.labelFreeKick;
            labelFreeKick.Text = labelFreeKick.Text + " " + this.m_CurrentPlayer.freekickaccuracy.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericFreeKickSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(6);
            this.m_AttributesSema = true;
        }

        private void trackDribbling_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.dribbling = this.trackDribbling.Value;
            this.labelDribbling.Text = this.labelDribbling.Text.Substring(0, this.labelDribbling.Text.IndexOf(' '));
            Label labelDribbling = this.labelDribbling;
            labelDribbling.Text = labelDribbling.Text + " " + this.m_CurrentPlayer.dribbling.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericAttackingSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(3);
            this.m_AttributesSema = true;
        }

        private void trackPenalties_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.penalties = this.trackPenalties.Value;
            this.labelPenalties.Text = this.labelPenalties.Text.Substring(0, this.labelPenalties.Text.IndexOf(' '));
            Label labelPenalties = this.labelPenalties;
            labelPenalties.Text = labelPenalties.Text + " " + this.m_CurrentPlayer.penalties.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericFreeKickSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(6);
            this.m_AttributesSema = true;
        }

        private void trackVolley_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.volleys = this.trackVolley.Value;
            this.labelVolley.Text = this.labelVolley.Text.Substring(0, this.labelVolley.Text.IndexOf(' '));
            Label labelVolley = this.labelVolley;
            labelVolley.Text = labelVolley.Text + " " + this.m_CurrentPlayer.volleys.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericAttackingSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(3);
            this.m_AttributesSema = true;
        }

        private void trackAcceleration_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.acceleration = this.trackAcceleration.Value;
            this.labelAcceleration.Text = this.labelAcceleration.Text.Substring(0, this.labelAcceleration.Text.IndexOf(' '));
            Label labelAcceleration = this.labelAcceleration;
            labelAcceleration.Text = labelAcceleration.Text + " " + this.m_CurrentPlayer.acceleration.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericPhysicalSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(4);
            this.m_AttributesSema = true;
        }

        private void trackSprintSpeed_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.sprintspeed = this.trackSprintSpeed.Value;
            this.labelSprintSpeed.Text = this.labelSprintSpeed.Text.Substring(0, this.labelSprintSpeed.Text.IndexOf(' '));
            Label labelSprintSpeed = this.labelSprintSpeed;
            labelSprintSpeed.Text = labelSprintSpeed.Text + " " + this.m_CurrentPlayer.sprintspeed.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericPhysicalSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(4);
            this.m_AttributesSema = true;
        }

        private void trackStamina_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.stamina = this.trackStamina.Value;
            this.labelStamina.Text = this.labelStamina.Text.Substring(0, this.labelStamina.Text.IndexOf(' '));
            Label labelStamina = this.labelStamina;
            labelStamina.Text = labelStamina.Text + " " + this.m_CurrentPlayer.stamina.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericPhysicalSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(4);
            this.m_AttributesSema = true;
        }

        private void trackStrength_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.strength = this.trackStrength.Value;
            this.labelStrength.Text = this.labelStrength.Text.Substring(0, this.labelStrength.Text.IndexOf(' '));
            Label labelStrength = this.labelStrength;
            labelStrength.Text = labelStrength.Text + " " + this.m_CurrentPlayer.strength.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericPhysicalSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(4);
            this.m_AttributesSema = true;
        }

        private void trackAgility_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.agility = this.trackAgility.Value;
            this.labelAgility.Text = this.labelAgility.Text.Substring(0, this.labelAgility.Text.IndexOf(' '));
            Label labelAgility = this.labelAgility;
            labelAgility.Text = labelAgility.Text + " " + this.m_CurrentPlayer.agility.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericPhysicalSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(4);
            this.m_AttributesSema = true;
        }

        private void trackJumping_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.jumping = this.trackJumping.Value;
            this.labelJumping.Text = this.labelJumping.Text.Substring(0, this.labelJumping.Text.IndexOf(' '));
            Label labelJumping = this.labelJumping;
            labelJumping.Text = labelJumping.Text + " " + this.m_CurrentPlayer.jumping.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericPhysicalSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(4);
            this.m_AttributesSema = true;
        }

        private void trackReactions_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.reactions = this.trackReactions.Value;
            this.labelReactions.Text = this.labelReactions.Text.Substring(0, this.labelReactions.Text.IndexOf(' '));
            Label labelReactions = this.labelReactions;
            labelReactions.Text = labelReactions.Text + " " + this.m_CurrentPlayer.reactions.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericPhysicalSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(4);
            this.m_AttributesSema = true;
        }

        private void trackPotential_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.potential = this.trackPotential.Value;
            this.labelPotential.Text = this.labelPotential.Text.Substring(0, this.labelPotential.Text.IndexOf(' '));
            Label labelPotential = this.labelPotential;
            labelPotential.Text = labelPotential.Text + " " + this.m_CurrentPlayer.potential.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericMentalSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(5);
            this.m_AttributesSema = true;
        }

        private void trackPlayerPositioning_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.positioning = this.trackPlayerPositioning.Value;
            this.labelPlayerPositioning.Text = this.labelPlayerPositioning.Text.Substring(0, this.labelPlayerPositioning.Text.IndexOf(' '));
            Label playerPositioning = this.labelPlayerPositioning;
            playerPositioning.Text = playerPositioning.Text + " " + this.m_CurrentPlayer.positioning.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericMentalSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(5);
            this.m_AttributesSema = true;
        }

        private void trackBalance_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.balance = this.trackBalance.Value;
            this.labelBalance.Text = this.labelBalance.Text.Substring(0, this.labelBalance.Text.IndexOf(' '));
            Label labelBalance = this.labelBalance;
            labelBalance.Text = labelBalance.Text + " " + this.m_CurrentPlayer.balance.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericPhysicalSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(4);
            this.m_AttributesSema = true;
        }

        private void trackOverallrating_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.overallrating = this.trackOverallrating.Value;
            this.labelOverallrating.Text = this.labelOverallrating.Text.Substring(0, this.labelOverallrating.Text.IndexOf(' '));
            Label labelOverallrating = this.labelOverallrating;
            labelOverallrating.Text = labelOverallrating.Text + " " + this.m_CurrentPlayer.overallrating.ToString();
        }

        private void RandomizeAttributes(int level)
        {
            switch (FifaEnvironment.UserMessages.ShowMessage(13))
            {
                case DialogResult.Cancel:
                    break;
                case DialogResult.No:
                    break;
                default:
                    this.m_CurrentPlayer.RandomizeAttributes(level);
                    this.LoadPlayerSkills();
                    break;
            }
        }

        private void buttonRandomPoor_Click(object sender, EventArgs e)
        {
            this.RandomizeAttributes(0);
        }

        private void buttonRandomBelowAvg_Click(object sender, EventArgs e)
        {
            this.RandomizeAttributes(1);
        }

        private void buttonRandomAverage_Click(object sender, EventArgs e)
        {
            this.RandomizeAttributes(2);
        }

        private void buttonRandomAboveAvg_Click(object sender, EventArgs e)
        {
            this.RandomizeAttributes(3);
        }

        private void buttonRandomGood_Click(object sender, EventArgs e)
        {
            this.RandomizeAttributes(4);
        }

        private void buttonRandomVeryGood_Click(object sender, EventArgs e)
        {
            this.RandomizeAttributes(5);
        }

        private void buttonRandomSuperstar_Click(object sender, EventArgs e)
        {
            this.RandomizeAttributes(6);
        }

        private void numericOverall_ValueChanged(object sender, EventArgs e)
        {
            if (this.m_OverallSema)
            {
                this.m_OverallSema = false;
                int num = (int)this.numericRandomize.Value - this.m_CurrentPlayer.GetAverageRoleAttribute();
                if (num == 0)
                    return;
                if (this.numericGoalkeeperSkills.Value + (Decimal)num < new Decimal(100) && this.numericGoalkeeperSkills.Value + (Decimal)num > new Decimal(0))
                    this.numericGoalkeeperSkills.Value += (Decimal)num;
                if (this.numericDefensiveSkills.Value + (Decimal)num < new Decimal(100) && this.numericGoalkeeperSkills.Value + (Decimal)num > new Decimal(0))
                    this.numericDefensiveSkills.Value += (Decimal)num;
                if (this.numericMidfielderSkills.Value + (Decimal)num < new Decimal(100) && this.numericGoalkeeperSkills.Value + (Decimal)num > new Decimal(0))
                    this.numericMidfielderSkills.Value += (Decimal)num;
                if (this.numericAttackingSkills.Value + (Decimal)num < new Decimal(100) && this.numericGoalkeeperSkills.Value + (Decimal)num > new Decimal(0))
                    this.numericAttackingSkills.Value += (Decimal)num;
                if (this.numericPhysicalSkills.Value + (Decimal)num < new Decimal(100) && this.numericGoalkeeperSkills.Value + (Decimal)num > new Decimal(0))
                    this.numericPhysicalSkills.Value += (Decimal)num;
                if (this.numericMentalSkills.Value + (Decimal)num < new Decimal(100) && this.numericGoalkeeperSkills.Value + (Decimal)num > new Decimal(0))
                    this.numericMentalSkills.Value += (Decimal)num;
                if (this.numericFreeKickSkills.Value + (Decimal)num < new Decimal(100) && this.numericGoalkeeperSkills.Value + (Decimal)num > new Decimal(0))
                    this.numericFreeKickSkills.Value += (Decimal)num;
            }
            this.trackOverallrating.Value = (int)this.numericRandomize.Value;
            this.m_OverallSema = true;
        }

        private void numericGoalkeeperSkills_ValueChanged(object sender, EventArgs e)
        {
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            int num1 = (int)this.numericGoalkeeperSkills.Value - this.m_CurrentPlayer.ComputeMeanAttributes(0);
            int num2 = this.trackPositioning.Value + num1;
            this.trackPositioning.Value = num2 < 1 ? 1 : (num2 > 99 ? 99 : num2);
            int num3 = this.trackDiving.Value + num1;
            this.trackDiving.Value = num3 < 1 ? 1 : (num3 > 99 ? 99 : num3);
            int num4 = this.trackHandling.Value + num1;
            this.trackHandling.Value = num4 < 1 ? 1 : (num4 > 99 ? 99 : num4);
            int num5 = this.trackReflexes.Value + num1;
            this.trackReflexes.Value = num5 < 1 ? 1 : (num5 > 99 ? 99 : num5);
            int num6 = this.trackGkKicking.Value + num1;
            this.trackGkKicking.Value = num6 < 1 ? 1 : (num6 > 99 ? 99 : num6);
            this.m_AttributesSema = true;
        }

        private void numericDefensiveSkills_ValueChanged(object sender, EventArgs e)
        {
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            int num1 = (int)this.numericDefensiveSkills.Value - this.m_CurrentPlayer.ComputeMeanAttributes(1);
            int num2 = this.trackAggression.Value + num1;
            this.trackAggression.Value = num2 < 1 ? 1 : (num2 > 99 ? 99 : num2);
            int num3 = this.trackTackling.Value + num1;
            this.trackTackling.Value = num3 < 1 ? 1 : (num3 > 99 ? 99 : num3);
            int num4 = this.trackSliding.Value + num1;
            this.trackSliding.Value = num4 < 1 ? 1 : (num4 > 99 ? 99 : num4);
            int num5 = this.trackMarking.Value + num1;
            this.trackMarking.Value = num5 < 1 ? 1 : (num5 > 99 ? 99 : num5);
            int num6 = this.trackInterception.Value + num1;
            this.trackInterception.Value = num6 < 1 ? 1 : (num6 > 99 ? 99 : num6);
            this.m_AttributesSema = true;
        }

        private void numericMidfielderSkills_ValueChanged(object sender, EventArgs e)
        {
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            int num1 = (int)this.numericMidfielderSkills.Value - this.m_CurrentPlayer.ComputeMeanAttributes(2);
            int num2 = this.trackShortPassing.Value + num1;
            this.trackShortPassing.Value = num2 < 1 ? 1 : (num2 > 99 ? 99 : num2);
            int num3 = this.trackLongPassing.Value + num1;
            this.trackLongPassing.Value = num3 < 1 ? 1 : (num3 > 99 ? 99 : num3);
            int num4 = this.trackCrossing.Value + num1;
            this.trackCrossing.Value = num4 < 1 ? 1 : (num4 > 99 ? 99 : num4);
            int num5 = this.trackBallControl.Value + num1;
            this.trackBallControl.Value = num5 < 1 ? 1 : (num5 > 99 ? 99 : num5);
            int num6 = this.trackVision.Value + num1;
            this.trackVision.Value = num6 < 1 ? 1 : (num6 > 99 ? 99 : num6);
            int num7 = this.trackCurve.Value + num1;
            this.trackCurve.Value = num7 < 1 ? 1 : (num7 > 99 ? 99 : num7);
            this.m_AttributesSema = true;
        }

        private void numericAttackingSkills_ValueChanged(object sender, EventArgs e)
        {
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            int num1 = (int)this.numericAttackingSkills.Value - this.m_CurrentPlayer.ComputeMeanAttributes(3);
            int num2 = this.trackFinishing.Value + num1;
            this.trackFinishing.Value = num2 < 1 ? 1 : (num2 > 99 ? 99 : num2);
            int num3 = this.trackShotPower.Value + num1;
            this.trackShotPower.Value = num3 < 1 ? 1 : (num3 > 99 ? 99 : num3);
            int num4 = this.trackLongShot.Value + num1;
            this.trackLongShot.Value = num4 < 1 ? 1 : (num4 > 99 ? 99 : num4);
            int num5 = this.trackDribbling.Value + num1;
            this.trackDribbling.Value = num5 < 1 ? 1 : (num5 > 99 ? 99 : num5);
            int num6 = this.trackVolley.Value + num1;
            this.trackVolley.Value = num6 < 1 ? 1 : (num6 > 99 ? 99 : num6);
            int num7 = this.trackHeading.Value + num1;
            this.trackHeading.Value = num7 < 1 ? 1 : (num7 > 99 ? 99 : num7);
            int num8 = this.trackFreeKick.Value + num1;
            this.trackFreeKick.Value = num8 < 1 ? 1 : (num8 > 99 ? 99 : num8);
            int num9 = this.trackPenalties.Value + num1;
            this.trackPenalties.Value = num9 < 1 ? 1 : (num9 > 99 ? 99 : num9);
            this.m_AttributesSema = true;
        }

        private void numericFreeKickSkills_ValueChanged(object sender, EventArgs e)
        {
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            int num1 = (int)this.numericFreeKickSkills.Value - this.m_CurrentPlayer.ComputeMeanAttributes(6);
            int num2 = this.trackFreeKick.Value + num1;
            this.trackFreeKick.Value = num2 < 1 ? 1 : (num2 > 99 ? 99 : num2);
            int num3 = this.trackPenalties.Value + num1;
            this.trackPenalties.Value = num3 < 1 ? 1 : (num3 > 99 ? 99 : num3);
            this.m_AttributesSema = true;
        }

        private void numericGenericSkills_ValueChanged(object sender, EventArgs e)
        {
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            int num1 = (int)this.numericPhysicalSkills.Value - this.m_CurrentPlayer.ComputeMeanAttributes(4);
            int num2 = this.trackAcceleration.Value + num1;
            this.trackAcceleration.Value = num2 < 1 ? 1 : (num2 > 99 ? 99 : num2);
            int num3 = this.trackSprintSpeed.Value + num1;
            this.trackSprintSpeed.Value = num3 < 1 ? 1 : (num3 > 99 ? 99 : num3);
            int num4 = this.trackStamina.Value + num1;
            this.trackStamina.Value = num4 < 1 ? 1 : (num4 > 99 ? 99 : num4);
            int num5 = this.trackStrength.Value + num1;
            this.trackStrength.Value = num5 < 1 ? 1 : (num5 > 99 ? 99 : num5);
            int num6 = this.trackAgility.Value + num1;
            this.trackAgility.Value = num6 < 1 ? 1 : (num6 > 99 ? 99 : num6);
            int num7 = this.trackJumping.Value + num1;
            this.trackJumping.Value = num7 < 1 ? 1 : (num7 > 99 ? 99 : num7);
            int num8 = this.trackReactions.Value + num1;
            this.trackReactions.Value = num8 < 1 ? 1 : (num8 > 99 ? 99 : num8);
            int num9 = this.trackBalance.Value + num1;
            this.trackBalance.Value = num9 < 1 ? 1 : (num9 > 99 ? 99 : num9);
            this.m_AttributesSema = true;
        }

        private void numericMentalSkills_ValueChanged(object sender, EventArgs e)
        {
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            int num1 = (int)this.numericMentalSkills.Value - this.m_CurrentPlayer.ComputeMeanAttributes(5);
            int num2 = this.trackPotential.Value + num1;
            this.trackPotential.Value = num2 < 1 ? 1 : (num2 > 99 ? 99 : num2);
            int num3 = this.trackPlayerPositioning.Value + num1;
            this.trackPlayerPositioning.Value = num3 < 1 ? 1 : (num3 > 99 ? 99 : num3);
            this.m_AttributesSema = true;
        }

        private void tabEditPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadPlayer(this.m_CurrentPlayer);
        }

        private void LoadPlayerFace()
        {
            this.m_GenericAppearanceSema = false;
            this.checkHasGenericFace.Checked = this.m_CurrentPlayer.headclasscode != 0;
            this.groupHairModel.Enabled = this.checkHasGenericFace.Checked;
            this.groupHeadModel.Enabled = this.checkHasGenericFace.Checked;
            this.groupGenericFaceType.Enabled = this.checkHasGenericFace.Checked;
            this.buttonRgbHair.Visible = !this.checkHasGenericFace.Checked && this.checkShowTexures.Checked;
            this.numericSkinTone.Value = (Decimal)this.m_CurrentPlayer.skintonecode;
            GenericHead.EHeadModelSet modelSet = GenericHead.GetModelSet(this.m_CurrentPlayer.headtypecode);
            if (modelSet == GenericHead.EHeadModelSet.Unknown)
            {
                modelSet = GenericHead.EHeadModelSet.Caucasic;
                this.m_CurrentPlayer.headtypecode = GenericHead.GetModelId(modelSet, 0);
            }
            int modelSetIndex = GenericHead.GetModelSetIndex(modelSet, this.m_CurrentPlayer.headtypecode);
            switch (modelSet - 1)
            {
                case GenericHead.EHeadModelSet.Unknown:
                    this.comboAfricanModels.SelectedIndex = modelSetIndex;
                    this.radioButtonAfrican.Checked = true;
                    break;
                case GenericHead.EHeadModelSet.African:
                    this.comboAsiaticModels.SelectedIndex = modelSetIndex;
                    this.radioButtonAsiatic.Checked = true;
                    break;
                case GenericHead.EHeadModelSet.Asiatic:
                    this.comboCaucasicModels.SelectedIndex = modelSetIndex;
                    this.radioButtonCaucasic.Checked = true;
                    break;
                case GenericHead.EHeadModelSet.Caucasic:
                    this.comboLatinModels.SelectedIndex = modelSetIndex;
                    this.radioButtonLatin.Checked = true;
                    break;
            }
            GenericHead.EHairModelSet hairModelSet = GenericHead.GetHairModelSet(this.m_CurrentPlayer.hairtypecode);
            int hairModelSetIndex = GenericHead.GetHairModelSetIndex(hairModelSet, this.m_CurrentPlayer.hairtypecode);
            switch (hairModelSet)
            {
                case GenericHead.EHairModelSet.Shaven:
                    this.comboShaven.SelectedIndex = hairModelSetIndex;
                    this.radioShaven.Checked = true;
                    break;
                case GenericHead.EHairModelSet.VeryShort:
                    this.comboVeryShort.SelectedIndex = hairModelSetIndex;
                    this.radioVeryShort.Checked = true;
                    break;
                case GenericHead.EHairModelSet.Short:
                    this.comboShort.SelectedIndex = hairModelSetIndex;
                    this.radioShort.Checked = true;
                    break;
                case GenericHead.EHairModelSet.Modern:
                    this.comboModern.SelectedIndex = hairModelSetIndex;
                    this.radioModern.Checked = true;
                    break;
                case GenericHead.EHairModelSet.Medium:
                    this.comboMedium.SelectedIndex = hairModelSetIndex;
                    this.radioMedium.Checked = true;
                    break;
                case GenericHead.EHairModelSet.Long:
                    this.comboLong.SelectedIndex = hairModelSetIndex;
                    this.radioLong.Checked = true;
                    break;
                case GenericHead.EHairModelSet.Afro:
                    this.comboAfro.SelectedIndex = hairModelSetIndex;
                    this.radioAfro.Checked = true;
                    break;
                case GenericHead.EHairModelSet.Headbend:
                    this.comboHeadband.SelectedIndex = hairModelSetIndex;
                    this.radioHeadband.Checked = true;
                    break;
            }
            this.domainFacialHair.SelectedIndex = this.m_CurrentPlayer.facialhairtypecode;
            this.domainHairColor.SelectedIndex = this.m_CurrentPlayer.haircolorcode;
            this.comboSideburns.SelectedIndex = this.m_CurrentPlayer.sideburnscode;
            this.comboSkintype.SelectedIndex = this.m_CurrentPlayer.skintypecode;
            this.comboEyescolor.SelectedIndex = this.m_CurrentPlayer.eyecolorcode - 1;
            this.comboEyeBow.SelectedIndex = this.m_CurrentPlayer.eyebrowcode;
            this.comboFacialHairColor.SelectedIndex = this.m_CurrentPlayer.facialhaircolorcode;
            this.m_GenericAppearanceSema = true;
            this.viewer2DPlayerGui.CurrentBitmap = this.m_CurrentPlayer.GetPhoto();
            this.GetAndShowTextures();
            this.UpdateAndShowHead3D();
        }

        private void radioButtonAsiatic_CheckedChanged(object sender, EventArgs e)
        {
            if (this.comboAsiaticModels.SelectedIndex < 0)
                this.comboAsiaticModels.SelectedIndex = 0;
            this.comboAsiaticModels.Visible = this.radioButtonAsiatic.Checked;
            if (this.radioButtonAsiatic.Checked)
            {
                this.radioButtonAsiatic.BackColor = Color.LightSkyBlue;
                if (this.m_CurrentPlayer.headtypecode == GenericHead.c_AsiaticModels[this.comboAsiaticModels.SelectedIndex])
                    return;
                this.m_CurrentPlayer.headtypecode = GenericHead.c_AsiaticModels[this.comboAsiaticModels.SelectedIndex];
                if (!this.m_GenericAppearanceSema || !this.buttonShow3DModel.Checked || this.m_CurrentPlayer.HasSpecificHeadModel)
                    return;
                this.UpdateAndShowHead3D();
            }
            else
                this.radioButtonAsiatic.BackColor = Color.Transparent;
        }

        private void radioButtonCaucasic_CheckedChanged(object sender, EventArgs e)
        {
            if (this.comboCaucasicModels.SelectedIndex < 0)
                this.comboCaucasicModels.SelectedIndex = 0;
            this.comboCaucasicModels.Visible = this.radioButtonCaucasic.Checked;
            if (this.radioButtonCaucasic.Checked)
            {
                this.radioButtonCaucasic.BackColor = Color.LightSkyBlue;
                if (this.m_CurrentPlayer.headtypecode == GenericHead.c_CaucasicModels[this.comboCaucasicModels.SelectedIndex])
                    return;
                this.m_CurrentPlayer.headtypecode = GenericHead.c_CaucasicModels[this.comboCaucasicModels.SelectedIndex];
                if (!this.m_GenericAppearanceSema || !this.buttonShow3DModel.Checked || this.m_CurrentPlayer.HasSpecificHeadModel)
                    return;
                this.UpdateAndShowHead3D();
            }
            else
                this.radioButtonCaucasic.BackColor = Color.Transparent;
        }

        private void radioButtonAfrican_CheckedChanged(object sender, EventArgs e)
        {
            if (this.comboAfricanModels.SelectedIndex < 0)
                this.comboAfricanModels.SelectedIndex = 0;
            this.comboAfricanModels.Visible = this.radioButtonAfrican.Checked;
            if (this.radioButtonAfrican.Checked)
            {
                this.radioButtonAfrican.BackColor = Color.LightSkyBlue;
                if (this.m_CurrentPlayer.headtypecode == GenericHead.c_AfricanModels[this.comboAfricanModels.SelectedIndex])
                    return;
                this.m_CurrentPlayer.headtypecode = GenericHead.c_AfricanModels[this.comboAfricanModels.SelectedIndex];
                if (!this.m_GenericAppearanceSema || !this.buttonShow3DModel.Checked || this.m_CurrentPlayer.HasSpecificHeadModel)
                    return;
                this.UpdateAndShowHead3D();
            }
            else
                this.radioButtonAfrican.BackColor = Color.Transparent;
        }

        private void radioButtonLatin_CheckedChanged(object sender, EventArgs e)
        {
            if (this.comboLatinModels.SelectedIndex < 0)
                this.comboLatinModels.SelectedIndex = 0;
            this.comboLatinModels.Visible = this.radioButtonLatin.Checked;
            if (this.radioButtonLatin.Checked)
            {
                this.radioButtonLatin.BackColor = Color.LightSkyBlue;
                if (this.m_CurrentPlayer.headtypecode == GenericHead.c_LatinModels[this.comboLatinModels.SelectedIndex])
                    return;
                this.m_CurrentPlayer.headtypecode = GenericHead.c_LatinModels[this.comboLatinModels.SelectedIndex];
                if (!this.m_GenericAppearanceSema || !this.buttonShow3DModel.Checked || this.m_CurrentPlayer.HasSpecificHeadModel)
                    return;
                this.UpdateAndShowHead3D();
            }
            else
                this.radioButtonLatin.BackColor = Color.Transparent;
        }

        private void comboAsiaticModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.m_GenericAppearanceSema || this.comboAsiaticModels.SelectedIndex < 0)
                return;
            this.m_CurrentPlayer.headtypecode = GenericHead.c_AsiaticModels[this.comboAsiaticModels.SelectedIndex];
            if (!this.buttonShow3DModel.Checked || this.m_CurrentPlayer.HasSpecificHeadModel)
                return;
            this.m_CurrentPlayer.CleanHeadModel();
            this.UpdateAndShowHead3D();
        }

        private void comboAfricanModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.m_GenericAppearanceSema || this.comboAfricanModels.SelectedIndex < 0)
                return;
            this.m_CurrentPlayer.headtypecode = GenericHead.c_AfricanModels[this.comboAfricanModels.SelectedIndex];
            if (!this.buttonShow3DModel.Checked || this.m_CurrentPlayer.HasSpecificHeadModel)
                return;
            this.m_CurrentPlayer.CleanHeadModel();
            this.UpdateAndShowHead3D();
        }

        private void comboCaucasicModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.m_GenericAppearanceSema || this.comboCaucasicModels.SelectedIndex < 0)
                return;
            this.m_CurrentPlayer.headtypecode = GenericHead.c_CaucasicModels[this.comboCaucasicModels.SelectedIndex];
            if (!this.buttonShow3DModel.Checked || this.m_CurrentPlayer.HasSpecificHeadModel)
                return;
            this.m_CurrentPlayer.CleanHeadModel();
            this.UpdateAndShowHead3D();
        }

        private void comboLatinModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.m_GenericAppearanceSema || this.comboLatinModels.SelectedIndex < 0)
                return;
            this.m_CurrentPlayer.headtypecode = GenericHead.c_LatinModels[this.comboLatinModels.SelectedIndex];
            if (!this.buttonShow3DModel.Checked || this.m_CurrentPlayer.HasSpecificHeadModel)
                return;
            this.m_CurrentPlayer.CleanHeadModel();
            this.UpdateAndShowHead3D();
        }

        private void radioButtonAfro_CheckedChanged(object sender, EventArgs e)
        {
            this.radioHair_CheckedChanged(sender, GenericHead.c_AfroModels);
        }

        private void radioButtonLong_CheckedChanged(object sender, EventArgs e)
        {
            this.radioHair_CheckedChanged(sender, GenericHead.c_LongModels);
        }

        private void radioButtonMedium_CheckedChanged(object sender, EventArgs e)
        {
            this.radioHair_CheckedChanged(sender, GenericHead.c_MediumModels);
        }

        private void radioShaven_CheckedChanged(object sender, EventArgs e)
        {
            this.radioHair_CheckedChanged(sender, GenericHead.c_ShavenModels);
        }

        private void radioModern_CheckedChanged(object sender, EventArgs e)
        {
            this.radioHair_CheckedChanged(sender, GenericHead.c_ModernModels);
        }

        private void radioVeryShort_CheckedChanged(object sender, EventArgs e)
        {
            this.radioHair_CheckedChanged(sender, GenericHead.c_VeryShortModels);
        }

        private void radioShort_CheckedChanged(object sender, EventArgs e)
        {
            this.radioHair_CheckedChanged(sender, GenericHead.c_ShortModels);
        }

        private void radioHeadband_CheckedChanged(object sender, EventArgs e)
        {
            this.radioHair_CheckedChanged(sender, GenericHead.c_HeadbendModels);
        }

        private void radioHair_CheckedChanged(object sender, int[] hairMap)
        {
            RadioButton radioButton = (RadioButton)sender;
            ComboBox tag = (ComboBox)radioButton.Tag;
            if (tag.SelectedIndex < 0)
                tag.SelectedIndex = 0;
            tag.Visible = radioButton.Checked;
            if (radioButton.Checked)
            {
                radioButton.BackColor = Color.LightSkyBlue;
                if (this.m_CurrentPlayer.hairtypecode == hairMap[tag.SelectedIndex])
                    return;
                this.m_CurrentPlayer.hairtypecode = hairMap[tag.SelectedIndex];
                if (!this.m_GenericAppearanceSema || !this.buttonShow3DModel.Checked && !this.checkShowTexures.Checked || this.m_CurrentPlayer.HasSpecificHeadModel)
                    return;
                this.m_CurrentPlayer.CleanHairTextures();
                this.GetAndShowHairTexture();
                this.UpdateAndShowHead3D();
            }
            else
                radioButton.BackColor = Color.Transparent;
        }

        private void comboHeadband_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboHair_SelectedIndexChanged(sender, GenericHead.c_HeadbendModels);
        }

        private void comboHair_SelectedIndexChanged(object sender, int[] hairMap)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (!this.m_GenericAppearanceSema || comboBox.SelectedIndex < 0)
                return;
            this.m_CurrentPlayer.hairtypecode = hairMap[comboBox.SelectedIndex];
            if (!this.m_GenericAppearanceSema || !this.buttonShow3DModel.Checked && !this.checkShowTexures.Checked || this.m_CurrentPlayer.HasSpecificHeadModel)
                return;
            this.m_CurrentPlayer.CleanHair();
            this.GetAndShowHairTexture();
            this.UpdateAndShowHead3D();
        }

        private void comboAfro_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboHair_SelectedIndexChanged(sender, GenericHead.c_AfroModels);
        }

        private void comboLong_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboHair_SelectedIndexChanged(sender, GenericHead.c_LongModels);
        }

        private void comboMedium_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboHair_SelectedIndexChanged(sender, GenericHead.c_MediumModels);
        }

        private void comboModern_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboHair_SelectedIndexChanged(sender, GenericHead.c_ModernModels);
        }

        private void comboShaven_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboHair_SelectedIndexChanged(sender, GenericHead.c_ShavenModels);
        }

        private void comboShort_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboHair_SelectedIndexChanged(sender, GenericHead.c_ShortModels);
        }

        private void comboVeryShort_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboHair_SelectedIndexChanged(sender, GenericHead.c_VeryShortModels);
        }

        private void EnableTool3DButtons()
        {
            if (this.m_CurrentPlayer == null)
                return;
            this.buttonImport3DHairModel.Enabled = this.m_CurrentPlayer.HasSpecificHeadModel;
            this.buttonRemoveHairModel.Enabled = this.m_CurrentPlayer.HasSpecificHeadModel;
            this.buttonMoveHairDown.Enabled = this.m_CurrentPlayer.HasSpecificHeadModel;
            this.buttonMoveHairAhead.Enabled = this.m_CurrentPlayer.HasSpecificHeadModel;
            this.buttonMoveHairBack.Enabled = this.m_CurrentPlayer.HasSpecificHeadModel;
            this.buttonMoveHairUp.Enabled = this.m_CurrentPlayer.HasSpecificHeadModel;
            this.buttonMoveHairLeft.Enabled = this.m_CurrentPlayer.HasSpecificHeadModel;
            this.buttonMoveHairRight.Enabled = this.m_CurrentPlayer.HasSpecificHeadModel;
            this.buttonMakeHairCloser.Enabled = this.m_CurrentPlayer.HasSpecificHeadModel;
            this.buttonMakeHairWider.Enabled = this.m_CurrentPlayer.HasSpecificHeadModel;
            this.buttonRemove3DHeadModel.Enabled = this.m_CurrentPlayer.HasSpecificHeadModel;
        }

        private void UpdateAndShowHead3D()
        {
            this.EnableTool3DButtons();
            if (!this.buttonShow3DModel.Checked)
            {
                this.viewer3D.ShowEmpty();
            }
            else
            {
                Bitmap faceTexture = this.m_CurrentPlayer.GetFaceTexture();
                Bitmap eyesTexture = this.m_CurrentPlayer.GetEyesTexture();
                Rx3File headModel = this.m_CurrentPlayer.GetHeadModel();
                if (headModel == null)
                {
                    this.viewer3D.ShowEmpty();
                }
                else
                {
                    Player.s_Model3DHead = (Model3D)null;
                    Player.s_Model3DEyes = (Model3D)null;
                    Player.s_Model3DHairPart4 = (Model3D)null;
                    Player.s_Model3DHairPart5 = (Model3D)null;
                    if (headModel.Rx3VertexArrays[0].nVertex > headModel.Rx3VertexArrays[1].nVertex)
                    {
                        Player.s_Model3DHead = new Model3D(headModel.Rx3IndexArrays[0], headModel.Rx3VertexArrays[0], faceTexture);
                        Player.s_Model3DEyes = new Model3D(headModel.Rx3IndexArrays[1], headModel.Rx3VertexArrays[1], eyesTexture);
                    }
                    else
                    {
                        Player.s_Model3DHead = new Model3D(headModel.Rx3IndexArrays[1], headModel.Rx3VertexArrays[1], faceTexture);
                        Player.s_Model3DEyes = new Model3D(headModel.Rx3IndexArrays[0], headModel.Rx3VertexArrays[0], eyesTexture);
                    }
                    Rx3File hairModel = this.m_CurrentPlayer.GetHairModel();
                    if (hairModel != null)
                    {
                        Bitmap hairColorTexture1 = this.m_CurrentPlayer.GetHairColorTexture();
                        Bitmap hairColorTexture2 = this.m_CurrentPlayer.GetGenericHairColorTexture();
                        Bitmap hairAlfaTexture = this.m_CurrentPlayer.GetHairAlfaTexture();
                        Bitmap bitmap1 = (Bitmap)null;
                        Bitmap bitmap2 = (Bitmap)null;
                        if (hairAlfaTexture != null)
                        {
                            int num1 = hairColorTexture1.Width / hairAlfaTexture.Width;
                            int num2 = hairColorTexture1.Height / hairAlfaTexture.Height;
                            if (hairColorTexture2 != null)
                            {
                                bitmap1 = (Bitmap)GraphicUtil.CanvasSizeBitmapCentered(hairColorTexture1, hairAlfaTexture.Width, hairAlfaTexture.Height).Clone();
                                GraphicUtil.GetAlfaFromChannel(bitmap1, hairAlfaTexture, 4 - this.m_HairAlfaChannel);
                            }
                            if (hairColorTexture1 != null)
                            {
                                bitmap2 = (Bitmap)GraphicUtil.CanvasSizeBitmapCentered(hairColorTexture1, hairAlfaTexture.Width, hairAlfaTexture.Height).Clone();
                                GraphicUtil.GetAlfaFromChannel(bitmap2, hairAlfaTexture, this.m_HairAlfaChannel);
                            }
                        }
                        Rx3IndexArray.TriangleListType = Rx3IndexArray.ETriangleListType.InvertEven;
                        if (hairModel.HairAlfaFlag == 53 || hairModel.HairAlfaFlag == 58)
                        {
                            Player.s_Model3DHairPart4 = new Model3D(hairModel.Rx3IndexArrays[0], hairModel.Rx3VertexArrays[0], bitmap2);
                            if (hairModel.Rx3IndexArrays.Length > 1)
                                Player.s_Model3DHairPart5 = new Model3D(hairModel.Rx3IndexArrays[1], hairModel.Rx3VertexArrays[1], bitmap1);
                        }
                        else if (hairModel.HairAlfaFlag == 50)
                        {
                            Player.s_Model3DHairPart4 = new Model3D(hairModel.Rx3IndexArrays[0], hairModel.Rx3VertexArrays[0], bitmap1);
                            if (hairModel.Rx3IndexArrays.Length > 1)
                                Player.s_Model3DHairPart5 = new Model3D(hairModel.Rx3IndexArrays[1], hairModel.Rx3VertexArrays[1], bitmap2);
                        }
                        else
                        {
                            int num = (int)FifaEnvironment.UserMessages.ShowMessage(14999, "Debug Trap: Unexpected Hair Format");
                            Player.s_Model3DHairPart4 = new Model3D(hairModel.Rx3IndexArrays[0], hairModel.Rx3VertexArrays[0], bitmap2);
                            if (hairModel.Rx3IndexArrays.Length > 1)
                                Player.s_Model3DHairPart5 = new Model3D(hairModel.Rx3IndexArrays[1], hairModel.Rx3VertexArrays[1], bitmap1);
                        }
                    }
                    this.ShowHead3D();
                }
            }
        }

        private void ShowHead3D()
        {
            int nMeshes = 2;
            if (Player.s_Model3DHairPart4 != null)
                nMeshes = 3;
            if (Player.s_Model3DHairPart5 != null)
                nMeshes = 4;
            Kit kit = (Kit)null;
            if (this.buttonShowJesey.Checked && this.m_CurrentPlayer.m_PlayingForTeams.Count > 0)
            {
                Team playingForTeam = (Team)this.m_CurrentPlayer.m_PlayingForTeams[0];
                int num = this.m_CurrentPlayer.preferredposition1 != 0 ? 0 : 2;
                if (num == 2 && playingForTeam.m_KitList.Count < 3)
                {
                    kit = FifaEnvironment.Kits.GetKit(5000 + (playingForTeam.Id & 15), 2);
                }
                else
                {
                    for (int index = 0; index < playingForTeam.m_KitList.Count; ++index)
                    {
                        kit = (Kit)playingForTeam.m_KitList[index];
                        if (kit.kittype == num && kit.year == 0)
                            break;
                    }
                }
                if (kit != null)
                {
                    Bitmap[] kitTextures = kit.GetKitTextures();
                    if (kitTextures != null)
                    {
                        Bitmap bitmap = GraphicUtil.EmbossBitmap(kitTextures[1], Kit.s_JerseyWrinkle);
                        Kit.s_JerseyModel3D[kit.jerseyCollar].TextureBitmap = bitmap;
                    }
                }
            }
            if (kit != null)
                ++nMeshes;
            this.viewer3D.Clean(nMeshes);
            int num1 = 0;
            if (kit != null)
                this.viewer3D.SetMesh(num1++, Kit.s_JerseyModel3D[kit.jerseyCollar]);
            Viewer3D viewer3D1 = this.viewer3D;
            int meshIndex1 = num1;
            int num2 = meshIndex1 + 1;
            Model3D model3Dhead = Player.s_Model3DHead;
            viewer3D1.SetMesh(meshIndex1, model3Dhead);
            Viewer3D viewer3D2 = this.viewer3D;
            int meshIndex2 = num2;
            int num3 = meshIndex2 + 1;
            Model3D model3Deyes = Player.s_Model3DEyes;
            viewer3D2.SetMesh(meshIndex2, model3Deyes);
            if (Player.s_Model3DHairPart4 != null)
                this.viewer3D.SetMesh(num3++, Player.s_Model3DHairPart4, false);
            if (Player.s_Model3DHairPart5 != null)
            {
                Viewer3D viewer3D3 = this.viewer3D;
                int meshIndex3 = num3;
                int num4 = meshIndex3 + 1;
                Model3D model3DhairPart5 = Player.s_Model3DHairPart5;
                viewer3D3.SetMesh(meshIndex3, model3DhairPart5, false);
            }
            this.viewer3D.Render();
        }

        private void GetAndShowTextures()
        {
            this.GetAndShowFaceTexture();
            this.GetAndShowHairTexture();
            this.GetAndShowSkinTexture();
            this.GetAndShowEyeTexture();
        }

        private void GetAndShowSkinTexture()
        {
            if (this.checkShowTexures.Checked && this.viewer2DSkinTexture.ShowButtonChecked)
            {
                this.viewer2DSkinTexture.CurrentBitmap = this.m_CurrentPlayer.GetSkinTexture();
                this.viewer2DSkinTexture.Enabled = true;
            }
            else
            {
                this.viewer2DSkinTexture.CurrentBitmap = (Bitmap)null;
                this.viewer2DSkinTexture.Enabled = false;
            }
        }

        private void GetAndShowEyeTexture()
        {
            if (this.checkShowTexures.Checked && this.viewer2DEyeTexture.ShowButtonChecked)
            {
                this.viewer2DEyeTexture.CurrentBitmap = this.m_CurrentPlayer.GetEyesTexture();
                this.viewer2DEyeTexture.Enabled = true;
            }
            else
            {
                this.viewer2DEyeTexture.CurrentBitmap = (Bitmap)null;
                this.viewer2DEyeTexture.Enabled = false;
            }
        }

        private void GetAndShowFaceTexture()
        {
            if (this.checkShowTexures.Checked)
            {
                Bitmap[] bitmapArray = new Bitmap[Player.GetFaceTexturesNumber()];
                Bitmap[] faceTextures = this.m_CurrentPlayer.GetFaceTextures();
                for (int index = 0; index < bitmapArray.Length; ++index)
                    bitmapArray[index] = faceTextures == null ? (Bitmap)null : (faceTextures.Length <= index || faceTextures[index] == null ? (Bitmap)null : (Bitmap)this.m_CurrentPlayer.GetFaceTextures()[index].Clone());
                this.multiViewerFace.Bitmaps = bitmapArray;
                this.multiViewerFace.Enabled = true;
            }
            else
            {
                this.multiViewerFace.Bitmaps = (Bitmap[])null;
                this.multiViewerFace.Enabled = false;
            }
        }

        private void GetAndShowHairTexture()
        {
            if (this.checkShowTexures.Checked)
            {
                Bitmap[] bitmapArray = new Bitmap[2];
                for (int index = 0; index < bitmapArray.Length; ++index)
                    bitmapArray[index] = this.m_CurrentPlayer.GetHairTextures() == null ? (Bitmap)null : (Bitmap)this.m_CurrentPlayer.GetHairTextures()[index].Clone();
                this.multiViewerHair.Bitmaps = bitmapArray;
                this.multiViewerHair.Enabled = true;
                this.buttonRgbHair.Visible = !this.checkHasGenericFace.Checked;
            }
            else
            {
                this.multiViewerHair.Bitmaps = (Bitmap[])null;
                this.multiViewerHair.Enabled = false;
                this.buttonRgbHair.Visible = false;
            }
        }

        private void domainHairColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.m_GenericAppearanceSema)
                return;
            this.m_CurrentPlayer.haircolorcode = this.domainHairColor.SelectedIndex;
            if (!this.buttonShow3DModel.Checked && !this.checkShowTexures.Checked || this.m_CurrentPlayer.HasSpecificHeadModel)
                return;
            this.m_CurrentPlayer.CleanHairTextures();
            this.GetAndShowHairTexture();
            this.UpdateAndShowHead3D();
        }

        private void comboSkintype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.m_GenericAppearanceSema || this.comboSkintype.SelectedIndex < 0)
                return;
            this.m_CurrentPlayer.skintypecode = this.comboSkintype.SelectedIndex;
            if (!this.buttonShow3DModel.Checked && !this.checkShowTexures.Checked || this.m_CurrentPlayer.HasSpecificHeadModel)
                return;
            this.m_CurrentPlayer.CleanFaceTextures();
            this.GetAndShowFaceTexture();
            this.UpdateAndShowHead3D();
        }

        private void comboEyescolor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.m_GenericAppearanceSema || this.comboEyescolor.SelectedIndex < 0)
                return;
            this.m_CurrentPlayer.eyecolorcode = this.comboEyescolor.SelectedIndex + 1;
            this.m_CurrentPlayer.CleanEyesTexture();
            this.GetAndShowEyeTexture();
            if (!this.buttonShow3DModel.Checked)
                return;
            this.UpdateAndShowHead3D();
        }

        private void domainFacialHair_SelectedItemChanged(object sender, EventArgs e)
        {
            if (!this.m_GenericAppearanceSema)
                return;
            this.m_CurrentPlayer.facialhairtypecode = this.domainFacialHair.SelectedIndex;
            if (!this.buttonShow3DModel.Checked && !this.checkShowTexures.Checked || this.m_CurrentPlayer.HasSpecificHeadModel)
                return;
            this.m_CurrentPlayer.CleanFaceTextures();
            this.GetAndShowFaceTexture();
            this.UpdateAndShowHead3D();
        }

        private void comboFacialHairColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.m_GenericAppearanceSema || this.comboFacialHairColor.SelectedIndex < 0)
                return;
            this.m_CurrentPlayer.facialhaircolorcode = this.comboFacialHairColor.SelectedIndex;
            if (!this.buttonShow3DModel.Checked && !this.checkShowTexures.Checked || this.m_CurrentPlayer.HasSpecificHeadModel)
                return;
            this.m_CurrentPlayer.CleanFaceTextures();
            this.GetAndShowFaceTexture();
            this.UpdateAndShowHead3D();
        }

        private void comboSideburns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.m_GenericAppearanceSema || this.comboSideburns.SelectedIndex < 0)
                return;
            this.m_CurrentPlayer.sideburnscode = this.comboSideburns.SelectedIndex;
            if (!this.buttonShow3DModel.Checked && !this.checkShowTexures.Checked || this.m_CurrentPlayer.HasSpecificHeadModel)
                return;
            this.m_CurrentPlayer.CleanFaceTextures();
            this.GetAndShowFaceTexture();
            this.UpdateAndShowHead3D();
        }

        private void comboEyeBow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.m_GenericAppearanceSema || this.comboEyeBow.SelectedIndex < 0)
                return;
            this.m_CurrentPlayer.eyebrowcode = this.comboEyeBow.SelectedIndex;
            if (!this.buttonShow3DModel.Checked && !this.checkShowTexures.Checked || this.m_CurrentPlayer.HasSpecificHeadModel)
                return;
            this.m_CurrentPlayer.CleanFaceTextures();
            this.GetAndShowFaceTexture();
            this.UpdateAndShowHead3D();
        }

        private void buttonShow3DModel_Click(object sender, EventArgs e)
        {
            this.UpdateAndShowHead3D();
        }

        private void checkShowTexures_CheckedChanged(object sender, EventArgs e)
        {
            this.GetAndShowTextures();
        }

        private void buttonRandomizeAppearance_Click(object sender, EventArgs e)
        {
            if (this.radioButtonAfrican.Checked)
                this.m_CurrentPlayer.RandomizeAfricanAppearance();
            else if (this.radioButtonAsiatic.Checked)
                this.m_CurrentPlayer.RandomizeAsiaticAppearance();
            else if (this.radioButtonCaucasic.Checked)
                this.m_CurrentPlayer.RandomizeCaucasianAppearance();
            else if (this.radioButtonLatin.Checked)
                this.m_CurrentPlayer.RandomizeLatinAppearance();
            this.m_CurrentPlayer.CleanAllHead();
            this.LoadPlayerFace();
            this.m_GenericAppearanceSema = true;
        }

        private void checkHasGenericFace_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_Locked)
                return;
            bool flag = this.checkHasGenericFace.Checked;
            this.m_CurrentPlayer.headclasscode = flag ? 1 : 0;
            this.groupHairModel.Enabled = flag;
            this.groupHeadModel.Enabled = flag;
            this.groupGenericFaceType.Enabled = flag;
            this.buttonRgbHair.Visible = !flag && this.checkShowTexures.Checked;
            this.LoadPlayerFace();
        }

        private void buttonImport3DHairModels_Click(object sender, EventArgs e)
        {
            string rx3FileName1 = FifaEnvironment.BrowseAndCheckModel(ref this.m_PlayerCurrentFolder, "Open 3D-Near Hair Model file", "3D-Near hair model files (*.rx3)|hair_*.rx3");
            if (rx3FileName1 == null)
                return;
            this.m_CurrentPlayer.SetHairModel(rx3FileName1);
            string rx3FileName2 = FifaEnvironment.BrowseAndCheckModel(ref this.m_PlayerCurrentFolder, "Open 3D-Far Hair Model file", "3D-Far hair model files (*.rx3)|hairlod_*.rx3");
            if (rx3FileName2 == null)
                return;
            this.m_CurrentPlayer.SetHairLodModel(rx3FileName2);
            this.m_CurrentPlayer.CleanHairModel();
            this.LoadPlayerFace();
        }

        private void buttonExport3DHairModels_Click(object sender, EventArgs e)
        {
            string fileName1 = this.m_CurrentPlayer.HairModelFileName();
            if (fileName1 != null)
                FifaEnvironment.AskAndExportFromZdata(fileName1, ref this.m_PlayerCurrentFolder);
            string fileName2 = this.m_CurrentPlayer.HairLodModelFileName();
            if (fileName2 == null)
                return;
            FifaEnvironment.AskAndExportFromZdata(fileName2, ref this.m_PlayerCurrentFolder);
        }

        private void buttonRemove3DModel_Click(object sender, EventArgs e)
        {
            if (!this.m_CurrentPlayer.HasSpecificHeadModel)
                return;
            switch (FifaEnvironment.UserMessages.ShowMessage(10))
            {
                case DialogResult.Cancel:
                    break;
                case DialogResult.No:
                    break;
                default:
                    this.m_CurrentPlayer.DeleteHeadModel();
                    this.LoadPlayerFace();
                    break;
            }
        }

        private void buttonImport3DHeadModel_Click(object sender, EventArgs e)
        {
            string rx3FileName = FifaEnvironment.BrowseAndCheckModel(ref this.m_PlayerCurrentFolder, "Open 3D Head Model file", "3D head model files (*.rx3)|head_*.rx3");
            if (rx3FileName == null)
                return;
            this.m_CurrentPlayer.CleanHead();
            this.m_CurrentPlayer.SetHeadModel(rx3FileName);
            this.LoadPlayerFace();
        }

        private void buttonExport3DHeadModel_Click(object sender, EventArgs e)
        {
            string fileName = this.m_CurrentPlayer.HeadModelFileName();
            if (fileName == null)
                return;
            FifaEnvironment.AskAndExportFromZdata(fileName, ref this.m_PlayerCurrentFolder);
        }

        private void comboPreferredPosition1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_Locked || this.comboPreferredPosition1.SelectedIndex < 0)
                return;
            this.m_CurrentPlayer.preferredposition1 = this.comboPreferredPosition1.SelectedIndex - 1;
        }

        private void comboPreferredPosition2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_Locked || this.comboPreferredPosition2.SelectedIndex < 0)
                return;
            this.m_CurrentPlayer.preferredposition2 = this.comboPreferredPosition2.SelectedIndex - 1;
        }

        private void comboPreferredPosition3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_Locked || this.comboPreferredPosition3.SelectedIndex < 0)
                return;
            this.m_CurrentPlayer.preferredposition3 = this.comboPreferredPosition3.SelectedIndex - 1;
        }

        private void comboPreferredPosition4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_Locked || this.comboPreferredPosition4.SelectedIndex < 0)
                return;
            this.m_CurrentPlayer.preferredposition4 = this.comboPreferredPosition4.SelectedIndex - 1;
        }

        private void numericSkillMoves_ValueChanged(object sender, EventArgs e)
        {
            if (this.m_Locked)
                return;
            this.labelSkillsStars.ImageIndex = (int)this.numericSkillMoves.Value;
            this.m_CurrentPlayer.skillmoves = this.labelSkillsStars.ImageIndex;
        }

        private void toolPhoto_Click(object sender, EventArgs e)
        {
            Bitmap bitmap1 = this.viewer3D.Photo();
            int height = bitmap1.Height * 85 / 100;
            int width1 = bitmap1.Width;
            int width2 = width1 < height ? width1 : height;
            Rectangle srcRect = new Rectangle((width1 - width2) / 2, 0, width2, height);
            Rectangle destRect = new Rectangle(0, 0, 128, 128);
            Bitmap srcBitmap = GraphicUtil.MakeAutoTransparent(bitmap1);
            Bitmap bitmap2 = new Bitmap(128, 128, PixelFormat.Format32bppArgb);
            GraphicUtil.RemapRectangle(srcBitmap, srcRect, bitmap2, destRect);
            this.m_CurrentPlayer.SetPhoto(bitmap2);
            this.viewer2DPlayerGui.CurrentBitmap = bitmap2;
        }

        private void labelGkGloves_DoubleClick(object sender, EventArgs e)
        {
            GkGloves gkGloves = (GkGloves)FifaEnvironment.GkGloves.SearchId(this.m_CurrentPlayer.gkglovetypecode);
            if (gkGloves == null)
                return;
            MainForm.CM.JumpTo((IdObject)gkGloves);
        }

        private void buttonSwitchRenderingMode_Click(object sender, EventArgs e)
        {
            this.m_HairAlfaChannel = 4 - this.m_HairAlfaChannel;
            this.UpdateAndShowHead3D();
        }

        private void buttonAhead_Click(object sender, EventArgs e)
        {
            if (Player.s_Model3DHairPart4 != null)
                Player.s_Model3DHairPart4.MoveForward();
            if (Player.s_Model3DHairPart5 != null)
                Player.s_Model3DHairPart5.MoveForward();
            this.buttonSaveHair.Enabled = true;
            this.ShowHead3D();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (Player.s_Model3DHairPart4 != null)
                Player.s_Model3DHairPart4.MoveBack();
            if (Player.s_Model3DHairPart5 != null)
                Player.s_Model3DHairPart5.MoveBack();
            this.buttonSaveHair.Enabled = true;
            this.ShowHead3D();
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            if (Player.s_Model3DHairPart4 != null)
                Player.s_Model3DHairPart4.MoveUp();
            if (Player.s_Model3DHairPart5 != null)
                Player.s_Model3DHairPart5.MoveUp();
            this.buttonSaveHair.Enabled = true;
            this.ShowHead3D();
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            if (Player.s_Model3DHairPart4 != null)
                Player.s_Model3DHairPart4.MoveDown();
            if (Player.s_Model3DHairPart5 != null)
                Player.s_Model3DHairPart5.MoveDown();
            this.buttonSaveHair.Enabled = true;
            this.ShowHead3D();
        }

        private void buttonSaveHair_Click(object sender, EventArgs e)
        {
            CustomVertex.PositionNormalTextured[] newVertex4 = (CustomVertex.PositionNormalTextured[])null;
            CustomVertex.PositionNormalTextured[] newVertex5 = (CustomVertex.PositionNormalTextured[])null;
            if (Player.s_Model3DHairPart4 != null)
                newVertex4 = Player.s_Model3DHairPart4.Vertex;
            if (Player.s_Model3DHairPart5 != null)
                newVertex5 = Player.s_Model3DHairPart5.Vertex;
            this.m_CurrentPlayer.UpdateHairVertex(newVertex4, newVertex5);
            this.buttonSaveHair.Enabled = false;
        }

        private void buttonRemoveHairModel_Click(object sender, EventArgs e)
        {
            if (!this.m_CurrentPlayer.HasSpecificHeadModel)
                return;
            switch (FifaEnvironment.UserMessages.ShowMessage(10))
            {
                case DialogResult.Cancel:
                    break;
                case DialogResult.No:
                    break;
                default:
                    this.m_CurrentPlayer.DeleteHairModel();
                    this.m_CurrentPlayer.DeleteHairLodModel();
                    this.LoadPlayerFace();
                    break;
            }
        }

        private void textFirstName_TextChanged(object sender, EventArgs e)
        {
            if (this.m_Locked)
                return;
            this.m_CurrentPlayer.firstname = this.textFirstName.Text;
            this.pickUpControl.SwitchObject((IdObject)this.m_CurrentPlayer);
        }

        private void textSurname_TextChanged(object sender, EventArgs e)
        {
            if (this.m_Locked)
                return;
            this.m_CurrentPlayer.lastname = this.textSurname.Text;
            if (this.m_CurrentPlayer.commonname == string.Empty)
            {
                this.m_CurrentPlayer.audioname = this.m_CurrentPlayer.lastname;
                this.m_CurrentPlayer.commentaryid = -1;
            }
            this.pickUpControl.SwitchObject((IdObject)this.m_CurrentPlayer);
        }

        private void textCommonName_TextChanged(object sender, EventArgs e)
        {
            if (this.m_Locked)
                return;
            this.m_CurrentPlayer.commonname = this.textCommonName.Text;
            this.m_CurrentPlayer.audioname = this.m_CurrentPlayer.commonname;
            this.m_CurrentPlayer.commentaryid = -1;
            this.pickUpControl.SwitchObject((IdObject)this.m_CurrentPlayer);
        }

        private void buttonShowJesey_Click(object sender, EventArgs e)
        {
            this.ShowHead3D();
        }

        private void listViewPlayingTeams_DoubleClick(object sender, EventArgs e)
        {
            if (this.listViewPlayingTeams.SelectedItems.Count <= 0)
                return;
            Team tag = (Team)this.listViewPlayingTeams.SelectedItems[0].Tag;
            if (tag == null)
                return;
            MainForm.CM.JumpTo((IdObject)tag);
        }

        private void numericSkinTone_ValueChanged(object sender, EventArgs e)
        {
            if (this.m_Locked)
                return;
            int num = (int)this.numericSkinTone.Value;
            this.m_CurrentPlayer.skintonecode = num;
            switch (num)
            {
                case 1:
                    this.labelSkinColorInfo.Text = "Light Pink (not generic face)";
                    break;
                case 2:
                    this.labelSkinColorInfo.Text = "Pink";
                    break;
                case 3:
                    this.labelSkinColorInfo.Text = "Dark Pink (not generic face)";
                    break;
                case 4:
                    this.labelSkinColorInfo.Text = "Light Yellow";
                    break;
                case 5:
                    this.labelSkinColorInfo.Text = "Medium Yellow";
                    break;
                case 6:
                    this.labelSkinColorInfo.Text = "Dark Yellow";
                    break;
                case 7:
                    this.labelSkinColorInfo.Text = "Light Brown";
                    break;
                case 8:
                    this.labelSkinColorInfo.Text = "Medium Brown";
                    break;
                case 9:
                    this.labelSkinColorInfo.Text = "Dark Brown";
                    break;
                default:
                    this.labelSkinColorInfo.Text = "Special";
                    break;
            }
            this.GetAndShowSkinTexture();
            if (this.m_CurrentPlayer.HasSpecificHeadModel)
                return;
            this.m_CurrentPlayer.CleanFaceTextures();
            this.GetAndShowFaceTexture();
            if (!this.buttonShow3DModel.Checked)
                return;
            this.UpdateAndShowHead3D();
        }

        private void buttonRgbHair_Click(object sender, EventArgs e)
        {
            if (this.multiViewerHair.Bitmaps == null)
                return;
            Bitmap bitmap = this.multiViewerHair.Bitmaps[1];
            if (bitmap == null)
                return;
            ModifyHairColor modifyHairColor = new ModifyHairColor(bitmap);
            if (modifyHairColor.ShowDialog() == DialogResult.OK)
            {
                this.multiViewerHair.Bitmaps[1] = modifyHairColor.Bitmap;
                this.multiViewerHair.buttonSave.Enabled = true;
            }
            modifyHairColor.Dispose();
        }

        private void checkIsLoan_CheckedChanged(object sender, EventArgs e)
        {
            this.groupIsLoan.Visible = this.checkIsLoan.Checked;
            if (this.checkIsLoan.Checked)
            {
                if (this.m_CurrentPlayer.TeamLoanedFrom != null)
                    return;
                this.m_CurrentPlayer.loandateend = this.dateLoanEnd.Value;
                this.m_CurrentPlayer.TeamLoanedFrom = (Team)this.comboTeamLoanedFrom.SelectedItem;
            }
            else
            {
                if (this.m_CurrentPlayer.TeamLoanedFrom == null)
                    return;
                this.m_CurrentPlayer.TeamLoanedFrom = (Team)null;
            }
        }

        private void comboTeamLoanedFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboTeamLoanedFrom.SelectedItem != null)
                return;
            this.comboTeamLoanedFrom.Text = string.Empty;
        }

        private void pictureColorShoes1_Click(object sender, EventArgs e)
        {
            ColorSelector colorSelector = new ColorSelector(Shoes.ShoesColorPalette, this.m_CurrentPlayer.shoecolorcode1);
            if (colorSelector.ShowDialog() == DialogResult.OK)
            {
                this.m_CurrentPlayer.shoecolorcode1 = colorSelector.SelectedIndex;
                this.pictureColorShoes1.BackColor = colorSelector.SelectedColor;
            }
            colorSelector.Dispose();
        }

        private void pictureColorShoes2_Click(object sender, EventArgs e)
        {
            ColorSelector colorSelector = new ColorSelector(Shoes.ShoesColorPalette, this.m_CurrentPlayer.shoecolorcode2);
            if (colorSelector.ShowDialog() == DialogResult.OK)
            {
                this.m_CurrentPlayer.shoecolorcode2 = colorSelector.SelectedIndex;
                this.pictureColorShoes2.BackColor = colorSelector.SelectedColor;
            }
            colorSelector.Dispose();
        }

        private void trackInterception_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentPlayer.interceptions = this.trackInterception.Value;
            this.labelInterception.Text = this.labelInterception.Text.Substring(0, this.labelInterception.Text.IndexOf(' '));
            Label labelInterception = this.labelInterception;
            labelInterception.Text = labelInterception.Text + " " + this.m_CurrentPlayer.interceptions.ToString();
            if (!this.m_AttributesSema)
                return;
            this.m_AttributesSema = false;
            this.numericDefensiveSkills.Value = (Decimal)this.m_CurrentPlayer.ComputeMeanAttributes(1);
            this.m_AttributesSema = true;
        }

        private void buttonMoveHairLeft_Click(object sender, EventArgs e)
        {
            if (Player.s_Model3DHairPart4 != null)
                Player.s_Model3DHairPart4.MoveLeft();
            if (Player.s_Model3DHairPart5 != null)
                Player.s_Model3DHairPart5.MoveLeft();
            this.buttonSaveHair.Enabled = true;
            this.ShowHead3D();
        }

        private void buttonMoveHairRight_Click(object sender, EventArgs e)
        {
            if (Player.s_Model3DHairPart4 != null)
                Player.s_Model3DHairPart4.MoveRight();
            if (Player.s_Model3DHairPart5 != null)
                Player.s_Model3DHairPart5.MoveRight();
            this.buttonSaveHair.Enabled = true;
            this.ShowHead3D();
        }

        private void buttonMakeHairCloser_Click(object sender, EventArgs e)
        {
            if (Player.s_Model3DHairPart4 != null)
                Player.s_Model3DHairPart4.MakeCloser();
            if (Player.s_Model3DHairPart5 != null)
                Player.s_Model3DHairPart5.MakeCloser();
            this.buttonSaveHair.Enabled = true;
            this.ShowHead3D();
        }

        private void buttonMakeHairWider_Click(object sender, EventArgs e)
        {
            if (Player.s_Model3DHairPart4 != null)
                Player.s_Model3DHairPart4.MakeWider();
            if (Player.s_Model3DHairPart5 != null)
                Player.s_Model3DHairPart5.MakeWider();
            this.buttonSaveHair.Enabled = true;
            this.ShowHead3D();
        }
    }
}
