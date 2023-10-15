// Original code created by Rinaldo

using FifaControls;
using FifaLibrary;
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
        private FbxViewer3D viewer3D;
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
        private RadioButton radioFemale;
        private RadioButton radioMale;
        private NumericUpDown numericEmotion;
        private Label label13;
        private bool m_Locked;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerForm));
            this.tabEditPlayer = new System.Windows.Forms.TabControl();
            this.pageInfo = new System.Windows.Forms.TabPage();
            this.flowPanelInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.groupPlayerIdentity = new System.Windows.Forms.GroupBox();
            this.radioFemale = new System.Windows.Forms.RadioButton();
            this.playerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.radioMale = new System.Windows.Forms.RadioButton();
            this.labelCommonName = new System.Windows.Forms.Label();
            this.textCommonName = new System.Windows.Forms.TextBox();
            this.textJerseyName = new System.Windows.Forms.TextBox();
            this.labelJerseyName = new System.Windows.Forms.Label();
            this.buttonGetId = new System.Windows.Forms.Button();
            this.viewer2DPhoto = new FifaControls.Viewer2D();
            this.numericPlayerId = new System.Windows.Forms.NumericUpDown();
            this.buttonRandomizeIdentity = new System.Windows.Forms.Button();
            this.dateBirthDate = new System.Windows.Forms.DateTimePicker();
            this.labelBirthdate = new System.Windows.Forms.Label();
            this.labelPlayerId = new System.Windows.Forms.Label();
            this.textSurname = new System.Windows.Forms.TextBox();
            this.textFirstName = new System.Windows.Forms.TextBox();
            this.comboCountry = new System.Windows.Forms.ComboBox();
            this.countryListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelFirstName = new System.Windows.Forms.Label();
            this.labelSurame = new System.Windows.Forms.Label();
            this.labelCountry = new System.Windows.Forms.Label();
            this.groupBoxBody = new System.Windows.Forms.GroupBox();
            this.comboWeakFoot = new System.Windows.Forms.ComboBox();
            this.labelWeakFoot = new System.Windows.Forms.Label();
            this.comboBody = new System.Windows.Forms.ComboBox();
            this.numericHeight = new System.Windows.Forms.NumericUpDown();
            this.numericWeight = new System.Windows.Forms.NumericUpDown();
            this.labelWeight = new System.Windows.Forms.Label();
            this.labelBody = new System.Windows.Forms.Label();
            this.domainPreferredFoot = new System.Windows.Forms.DomainUpDown();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelPreferredFoot = new System.Windows.Forms.Label();
            this.groupBoxLook = new System.Windows.Forms.GroupBox();
            this.checkJerseyFit = new System.Windows.Forms.CheckBox();
            this.checkTrainingPants = new System.Windows.Forms.CheckBox();
            this.domainSocksStyle = new System.Windows.Forms.DomainUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericGkGloves = new System.Windows.Forms.NumericUpDown();
            this.labelGkGloves = new System.Windows.Forms.Label();
            this.labelWinter = new System.Windows.Forms.Label();
            this.comboWinterAccessories = new System.Windows.Forms.ComboBox();
            this.domainJerseyStyle = new System.Windows.Forms.DomainUpDown();
            this.domainSleeves = new System.Windows.Forms.DomainUpDown();
            this.pictureColorAcc2 = new System.Windows.Forms.PictureBox();
            this.pictureColorAcc3 = new System.Windows.Forms.PictureBox();
            this.pictureColorAcc4 = new System.Windows.Forms.PictureBox();
            this.pictureColorAcc1 = new System.Windows.Forms.PictureBox();
            this.domainAccessory4 = new System.Windows.Forms.ComboBox();
            this.domainAccessory3 = new System.Windows.Forms.ComboBox();
            this.domainAccessory2 = new System.Windows.Forms.ComboBox();
            this.domainAccessory1 = new System.Windows.Forms.ComboBox();
            this.labelSleeves = new System.Windows.Forms.Label();
            this.labelJerseyStyle = new System.Windows.Forms.Label();
            this.labelAccesories = new System.Windows.Forms.Label();
            this.groupPlayFirTeam = new System.Windows.Forms.GroupBox();
            this.groupIsLoan = new System.Windows.Forms.GroupBox();
            this.comboTeamLoanedFrom = new System.Windows.Forms.ComboBox();
            this.teamListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.dateLoanEnd = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.checkIsLoan = new System.Windows.Forms.CheckBox();
            this.dateJoiningDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.listViewPlayingTeams = new System.Windows.Forms.ListView();
            this.imageListTeamLogos = new System.Windows.Forms.ImageList(this.components);
            this.comboClubTeam = new System.Windows.Forms.ComboBox();
            this.buttonCallNationalTeam = new System.Windows.Forms.Button();
            this.buttonRemoveNationalTeam = new System.Windows.Forms.Button();
            this.groupShoes = new System.Windows.Forms.GroupBox();
            this.label1ShoesType = new System.Windows.Forms.Label();
            this.pictureColorShoes2 = new System.Windows.Forms.PictureBox();
            this.pictureColorShoes1 = new System.Windows.Forms.PictureBox();
            this.numericShoesBrand = new System.Windows.Forms.NumericUpDown();
            this.labelShoesType = new System.Windows.Forms.Label();
            this.labelShoesColor = new System.Windows.Forms.Label();
            this.numericShoesDesign = new System.Windows.Forms.NumericUpDown();
            this.viewer2DShoes = new FifaControls.Viewer2D();
            this.labelShoes = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelPreferredPositions = new System.Windows.Forms.Label();
            this.comboPreferredPosition4 = new System.Windows.Forms.ComboBox();
            this.comboPreferredPosition3 = new System.Windows.Forms.ComboBox();
            this.comboPreferredPosition2 = new System.Windows.Forms.ComboBox();
            this.comboPreferredPosition1 = new System.Windows.Forms.ComboBox();
            this.domainInternationalReputation = new System.Windows.Forms.DomainUpDown();
            this.labelInternationalReputation = new System.Windows.Forms.Label();
            this.pageSkills = new System.Windows.Forms.TabPage();
            this.flowPanelSkills = new System.Windows.Forms.FlowLayoutPanel();
            this.groupGenerateAttributes = new System.Windows.Forms.GroupBox();
            this.labelOverallrating = new System.Windows.Forms.Label();
            this.trackOverallrating = new System.Windows.Forms.TrackBar();
            this.labelRandomize = new System.Windows.Forms.Label();
            this.numericRandomize = new System.Windows.Forms.NumericUpDown();
            this.buttonRandomAboveAvg = new System.Windows.Forms.Button();
            this.buttonRandomBelowAvg = new System.Windows.Forms.Button();
            this.buttonRandomSuperstar = new System.Windows.Forms.Button();
            this.buttonRandomVeryGood = new System.Windows.Forms.Button();
            this.buttonRandomGood = new System.Windows.Forms.Button();
            this.buttonRandomAverage = new System.Windows.Forms.Button();
            this.buttonRandomPoor = new System.Windows.Forms.Button();
            this.groupGoalkeperSkills = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboGkSaveStyle = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelGkKick = new System.Windows.Forms.Label();
            this.comboGkKickStyle = new System.Windows.Forms.ComboBox();
            this.trackGkKicking = new System.Windows.Forms.TrackBar();
            this.labelDiving = new System.Windows.Forms.Label();
            this.labelPositioning = new System.Windows.Forms.Label();
            this.labelReflexes = new System.Windows.Forms.Label();
            this.labelHandling = new System.Windows.Forms.Label();
            this.trackDiving = new System.Windows.Forms.TrackBar();
            this.trackPositioning = new System.Windows.Forms.TrackBar();
            this.trackReflexes = new System.Windows.Forms.TrackBar();
            this.trackHandling = new System.Windows.Forms.TrackBar();
            this.numericGoalkeeperSkills = new System.Windows.Forms.NumericUpDown();
            this.groupDefensiveSkills = new System.Windows.Forms.GroupBox();
            this.labelInterception = new System.Windows.Forms.Label();
            this.trackInterception = new System.Windows.Forms.TrackBar();
            this.labelSliding = new System.Windows.Forms.Label();
            this.trackSliding = new System.Windows.Forms.TrackBar();
            this.numericDefensiveSkills = new System.Windows.Forms.NumericUpDown();
            this.labelAggression = new System.Windows.Forms.Label();
            this.labelMarking = new System.Windows.Forms.Label();
            this.labelTackling = new System.Windows.Forms.Label();
            this.trackTackling = new System.Windows.Forms.TrackBar();
            this.trackMarking = new System.Windows.Forms.TrackBar();
            this.trackAggression = new System.Windows.Forms.TrackBar();
            this.groupMidfielderSkills = new System.Windows.Forms.GroupBox();
            this.labelCurve = new System.Windows.Forms.Label();
            this.trackCurve = new System.Windows.Forms.TrackBar();
            this.labelVision = new System.Windows.Forms.Label();
            this.trackVision = new System.Windows.Forms.TrackBar();
            this.numericMidfielderSkills = new System.Windows.Forms.NumericUpDown();
            this.labelBallControl = new System.Windows.Forms.Label();
            this.labelCrossing = new System.Windows.Forms.Label();
            this.labelLongPassing = new System.Windows.Forms.Label();
            this.trackLongPassing = new System.Windows.Forms.TrackBar();
            this.labelShortPassing = new System.Windows.Forms.Label();
            this.trackShortPassing = new System.Windows.Forms.TrackBar();
            this.trackBallControl = new System.Windows.Forms.TrackBar();
            this.trackCrossing = new System.Windows.Forms.TrackBar();
            this.groupMental = new System.Windows.Forms.GroupBox();
            this.numericEmotion = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.comboDefensiveWorkrate = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboAttackWorkRate = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numericMentalSkills = new System.Windows.Forms.NumericUpDown();
            this.labelPlayerPositioning = new System.Windows.Forms.Label();
            this.labelPotential = new System.Windows.Forms.Label();
            this.trackPlayerPositioning = new System.Windows.Forms.TrackBar();
            this.trackPotential = new System.Windows.Forms.TrackBar();
            this.groupAttackingSkills = new System.Windows.Forms.GroupBox();
            this.labelFinishing = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.labelHeading = new System.Windows.Forms.Label();
            this.trackHeading = new System.Windows.Forms.TrackBar();
            this.labelVolley = new System.Windows.Forms.Label();
            this.trackVolley = new System.Windows.Forms.TrackBar();
            this.numericAttackingSkills = new System.Windows.Forms.NumericUpDown();
            this.labelDribbling = new System.Windows.Forms.Label();
            this.labelLongShot = new System.Windows.Forms.Label();
            this.labelShotPower = new System.Windows.Forms.Label();
            this.trackFinishing = new System.Windows.Forms.TrackBar();
            this.trackShotPower = new System.Windows.Forms.TrackBar();
            this.trackLongShot = new System.Windows.Forms.TrackBar();
            this.trackDribbling = new System.Windows.Forms.TrackBar();
            this.groupGenericAttributes = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.labelJumping = new System.Windows.Forms.Label();
            this.labelBalance = new System.Windows.Forms.Label();
            this.trackBalance = new System.Windows.Forms.TrackBar();
            this.labelAgility = new System.Windows.Forms.Label();
            this.trackAgility = new System.Windows.Forms.TrackBar();
            this.numericPhysicalSkills = new System.Windows.Forms.NumericUpDown();
            this.labelReactions = new System.Windows.Forms.Label();
            this.labelStrength = new System.Windows.Forms.Label();
            this.labelStamina = new System.Windows.Forms.Label();
            this.trackStamina = new System.Windows.Forms.TrackBar();
            this.labelSprintSpeed = new System.Windows.Forms.Label();
            this.trackSprintSpeed = new System.Windows.Forms.TrackBar();
            this.labelAcceleration = new System.Windows.Forms.Label();
            this.trackAcceleration = new System.Windows.Forms.TrackBar();
            this.trackStrength = new System.Windows.Forms.TrackBar();
            this.trackReactions = new System.Windows.Forms.TrackBar();
            this.trackJumping = new System.Windows.Forms.TrackBar();
            this.groupFreeKick = new System.Windows.Forms.GroupBox();
            this.labelSkillsStars = new System.Windows.Forms.Label();
            this.imageListStars = new System.Windows.Forms.ImageList(this.components);
            this.numericSkillMoves = new System.Windows.Forms.NumericUpDown();
            this.labelSkillMoves = new System.Windows.Forms.Label();
            this.numericFreeKickSkills = new System.Windows.Forms.NumericUpDown();
            this.labelPenalties = new System.Windows.Forms.Label();
            this.labelFreeKick = new System.Windows.Forms.Label();
            this.trackFreeKick = new System.Windows.Forms.TrackBar();
            this.trackPenalties = new System.Windows.Forms.TrackBar();
            this.labelPenaltyKick = new System.Windows.Forms.Label();
            this.comboPenaltyKick = new System.Windows.Forms.ComboBox();
            this.labelPenaltyMove = new System.Windows.Forms.Label();
            this.comboPenaltyMove = new System.Windows.Forms.ComboBox();
            this.labelFreeKickStart = new System.Windows.Forms.Label();
            this.labelPenaltyStart = new System.Windows.Forms.Label();
            this.comboFreeKickStart = new System.Windows.Forms.ComboBox();
            this.comboPenaltyStart = new System.Windows.Forms.ComboBox();
            this.groupTraits = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkGKFlatKick = new System.Windows.Forms.CheckBox();
            this.checkDrivenPass = new System.Windows.Forms.CheckBox();
            this.checkDivingHeader = new System.Windows.Forms.CheckBox();
            this.checkBycicleKick = new System.Windows.Forms.CheckBox();
            this.checkChipperPenalty = new System.Windows.Forms.CheckBox();
            this.checkStutterPenalty = new System.Windows.Forms.CheckBox();
            this.checkFancyFlicks = new System.Windows.Forms.CheckBox();
            this.checkFancyPasses = new System.Windows.Forms.CheckBox();
            this.checkFancyFeet = new System.Windows.Forms.CheckBox();
            this.checkGKOneonOne = new System.Windows.Forms.CheckBox();
            this.checkAcrobaticClearance = new System.Windows.Forms.CheckBox();
            this.checkSecondWind = new System.Windows.Forms.CheckBox();
            this.checkCrowdFavourite = new System.Windows.Forms.CheckBox();
            this.checkInflexible = new System.Windows.Forms.CheckBox();
            this.checkTeamPlayer = new System.Windows.Forms.CheckBox();
            this.checkSwervePasser = new System.Windows.Forms.CheckBox();
            this.checkCornerSpecialist = new System.Windows.Forms.CheckBox();
            this.checkPowerHeader = new System.Windows.Forms.CheckBox();
            this.checkGkLongThrower = new System.Windows.Forms.CheckBox();
            this.checkLongPasser = new System.Windows.Forms.CheckBox();
            this.checkFlair = new System.Windows.Forms.CheckBox();
            this.checkFinesseShot = new System.Windows.Forms.CheckBox();
            this.checkArguesWithOfficials = new System.Windows.Forms.CheckBox();
            this.checkBeatsOffsideTrap = new System.Windows.Forms.CheckBox();
            this.checkAvoidsWeakFoot = new System.Windows.Forms.CheckBox();
            this.checkInjuryFree = new System.Windows.Forms.CheckBox();
            this.checkPowerFreeKick = new System.Windows.Forms.CheckBox();
            this.checkSelfish = new System.Windows.Forms.CheckBox();
            this.checkPlaymaker = new System.Windows.Forms.CheckBox();
            this.checkTechnicaldribbler = new System.Windows.Forms.CheckBox();
            this.checkLeadership = new System.Windows.Forms.CheckBox();
            this.checkPuncher = new System.Windows.Forms.CheckBox();
            this.checkDiver = new System.Windows.Forms.CheckBox();
            this.checkDivesintotackles = new System.Windows.Forms.CheckBox();
            this.checkLongshottaker = new System.Windows.Forms.CheckBox();
            this.checkHighClubIdentification = new System.Windows.Forms.CheckBox();
            this.checkPushesupforcorners = new System.Windows.Forms.CheckBox();
            this.checkEarlycrosser = new System.Windows.Forms.CheckBox();
            this.checkInjuryProne = new System.Windows.Forms.CheckBox();
            this.checkGiantThrower = new System.Windows.Forms.CheckBox();
            this.checkLongThrower = new System.Windows.Forms.CheckBox();
            this.pageFace = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.viewer3D = new FifaControls.FbxViewer3D();
            this.tool3D = new System.Windows.Forms.ToolStrip();
            this.buttonShow3DModel = new System.Windows.Forms.ToolStripButton();
            this.buttonSwitchRenderingMode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonImport3DHeadModel = new System.Windows.Forms.ToolStripButton();
            this.buttonExport3DHeadModel = new System.Windows.Forms.ToolStripButton();
            this.buttonRemove3DHeadModel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonImport3DHairModel = new System.Windows.Forms.ToolStripButton();
            this.buttonExport3DHairModel = new System.Windows.Forms.ToolStripButton();
            this.buttonRemoveHairModel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonMoveHairAhead = new System.Windows.Forms.ToolStripButton();
            this.buttonMoveHairBack = new System.Windows.Forms.ToolStripButton();
            this.buttonMoveHairUp = new System.Windows.Forms.ToolStripButton();
            this.buttonMoveHairDown = new System.Windows.Forms.ToolStripButton();
            this.buttonMoveHairLeft = new System.Windows.Forms.ToolStripButton();
            this.buttonMoveHairRight = new System.Windows.Forms.ToolStripButton();
            this.buttonMakeHairCloser = new System.Windows.Forms.ToolStripButton();
            this.buttonMakeHairWider = new System.Windows.Forms.ToolStripButton();
            this.buttonSaveHair = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPhoto = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonShowJesey = new System.Windows.Forms.ToolStripButton();
            this.groupGenericFace = new System.Windows.Forms.GroupBox();
            this.groupGenericFaceType = new System.Windows.Forms.GroupBox();
            this.labelFacialHair = new System.Windows.Forms.Label();
            this.labelEyeBow = new System.Windows.Forms.Label();
            this.domainFacialHair = new System.Windows.Forms.ComboBox();
            this.comboEyeBow = new System.Windows.Forms.ComboBox();
            this.labelSideburns = new System.Windows.Forms.Label();
            this.comboSideburns = new System.Windows.Forms.ComboBox();
            this.labelSkintype = new System.Windows.Forms.Label();
            this.comboSkintype = new System.Windows.Forms.ComboBox();
            this.comboFacialHairColor = new System.Windows.Forms.ComboBox();
            this.labelFacialHairColor = new System.Windows.Forms.Label();
            this.labelSkinColorInfo = new System.Windows.Forms.Label();
            this.checkHasGenericFace = new System.Windows.Forms.CheckBox();
            this.numericSkinTone = new System.Windows.Forms.NumericUpDown();
            this.groupHairModel = new System.Windows.Forms.GroupBox();
            this.comboHeadband = new System.Windows.Forms.ComboBox();
            this.comboAfro = new System.Windows.Forms.ComboBox();
            this.comboLong = new System.Windows.Forms.ComboBox();
            this.comboMedium = new System.Windows.Forms.ComboBox();
            this.comboModern = new System.Windows.Forms.ComboBox();
            this.labelHairColor = new System.Windows.Forms.Label();
            this.domainHairColor = new System.Windows.Forms.ComboBox();
            this.comboShort = new System.Windows.Forms.ComboBox();
            this.comboVeryShort = new System.Windows.Forms.ComboBox();
            this.comboShaven = new System.Windows.Forms.ComboBox();
            this.radioHeadband = new System.Windows.Forms.RadioButton();
            this.radioShaven = new System.Windows.Forms.RadioButton();
            this.radioAfro = new System.Windows.Forms.RadioButton();
            this.radioLong = new System.Windows.Forms.RadioButton();
            this.radioMedium = new System.Windows.Forms.RadioButton();
            this.radioModern = new System.Windows.Forms.RadioButton();
            this.radioShort = new System.Windows.Forms.RadioButton();
            this.radioVeryShort = new System.Windows.Forms.RadioButton();
            this.groupHeadModel = new System.Windows.Forms.GroupBox();
            this.comboLatinModels = new System.Windows.Forms.ComboBox();
            this.radioButtonLatin = new System.Windows.Forms.RadioButton();
            this.comboAsiaticModels = new System.Windows.Forms.ComboBox();
            this.radioButtonAsiatic = new System.Windows.Forms.RadioButton();
            this.comboAfricanModels = new System.Windows.Forms.ComboBox();
            this.radioButtonAfrican = new System.Windows.Forms.RadioButton();
            this.radioButtonCaucasic = new System.Windows.Forms.RadioButton();
            this.comboCaucasicModels = new System.Windows.Forms.ComboBox();
            this.buttonRandomizeAppearance = new System.Windows.Forms.Button();
            this.labelHeadType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelHairType = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.multiViewerFace = new FifaControls.MultiViewer2D();
            this.buttonRgbHair = new System.Windows.Forms.Button();
            this.viewer2DSkinTexture = new FifaControls.Viewer2D();
            this.multiViewerHair = new FifaControls.MultiViewer2D();
            this.checkShowTexures = new System.Windows.Forms.CheckBox();
            this.viewer2DEyeTexture = new FifaControls.Viewer2D();
            this.comboEyescolor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.viewer2DPlayerGui = new FifaControls.Viewer2D();
            this.imageListTabIcons = new System.Windows.Forms.ImageList(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pickUpControl = new FifaControls.PickUpControl();
            this.tabEditPlayer.SuspendLayout();
            this.pageInfo.SuspendLayout();
            this.flowPanelInfo.SuspendLayout();
            this.groupPlayerIdentity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPlayerId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryListBindingSource)).BeginInit();
            this.groupBoxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWeight)).BeginInit();
            this.groupBoxLook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericGkGloves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureColorAcc2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureColorAcc3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureColorAcc4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureColorAcc1)).BeginInit();
            this.groupPlayFirTeam.SuspendLayout();
            this.groupIsLoan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teamListBindingSource)).BeginInit();
            this.groupShoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureColorShoes2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureColorShoes1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericShoesBrand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericShoesDesign)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pageSkills.SuspendLayout();
            this.flowPanelSkills.SuspendLayout();
            this.groupGenerateAttributes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackOverallrating)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRandomize)).BeginInit();
            this.groupGoalkeperSkills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackGkKicking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackDiving)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPositioning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackReflexes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackHandling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGoalkeeperSkills)).BeginInit();
            this.groupDefensiveSkills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackInterception)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSliding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDefensiveSkills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTackling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackMarking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAggression)).BeginInit();
            this.groupMidfielderSkills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackCurve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackVision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMidfielderSkills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackLongPassing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackShortPassing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBallControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackCrossing)).BeginInit();
            this.groupMental.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericEmotion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMentalSkills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPlayerPositioning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPotential)).BeginInit();
            this.groupAttackingSkills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackHeading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackVolley)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAttackingSkills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackFinishing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackShotPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackLongShot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackDribbling)).BeginInit();
            this.groupGenericAttributes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAgility)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPhysicalSkills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackStamina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSprintSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAcceleration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackStrength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackReactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackJumping)).BeginInit();
            this.groupFreeKick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSkillMoves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFreeKickSkills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackFreeKick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPenalties)).BeginInit();
            this.groupTraits.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pageFace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tool3D.SuspendLayout();
            this.groupGenericFace.SuspendLayout();
            this.groupGenericFaceType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSkinTone)).BeginInit();
            this.groupHairModel.SuspendLayout();
            this.groupHeadModel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabEditPlayer
            // 
            this.tabEditPlayer.Controls.Add(this.pageInfo);
            this.tabEditPlayer.Controls.Add(this.pageSkills);
            this.tabEditPlayer.Controls.Add(this.pageFace);
            this.tabEditPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabEditPlayer.ImageList = this.imageListTabIcons;
            this.tabEditPlayer.Location = new System.Drawing.Point(0, 25);
            this.tabEditPlayer.Name = "tabEditPlayer";
            this.tabEditPlayer.SelectedIndex = 0;
            this.tabEditPlayer.Size = new System.Drawing.Size(1357, 807);
            this.tabEditPlayer.TabIndex = 1;
            this.tabEditPlayer.SelectedIndexChanged += new System.EventHandler(this.tabEditPlayer_SelectedIndexChanged);
            // 
            // pageInfo
            // 
            this.pageInfo.Controls.Add(this.flowPanelInfo);
            this.pageInfo.ImageIndex = 0;
            this.pageInfo.Location = new System.Drawing.Point(4, 23);
            this.pageInfo.Name = "pageInfo";
            this.pageInfo.Padding = new System.Windows.Forms.Padding(3);
            this.pageInfo.Size = new System.Drawing.Size(1349, 780);
            this.pageInfo.TabIndex = 0;
            this.pageInfo.Text = "Info";
            this.pageInfo.UseVisualStyleBackColor = true;
            // 
            // flowPanelInfo
            // 
            this.flowPanelInfo.AutoScroll = true;
            this.flowPanelInfo.Controls.Add(this.groupPlayerIdentity);
            this.flowPanelInfo.Controls.Add(this.groupBoxBody);
            this.flowPanelInfo.Controls.Add(this.groupBoxLook);
            this.flowPanelInfo.Controls.Add(this.groupPlayFirTeam);
            this.flowPanelInfo.Controls.Add(this.groupShoes);
            this.flowPanelInfo.Controls.Add(this.groupBox1);
            this.flowPanelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelInfo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanelInfo.Location = new System.Drawing.Point(3, 3);
            this.flowPanelInfo.Name = "flowPanelInfo";
            this.flowPanelInfo.Size = new System.Drawing.Size(1343, 774);
            this.flowPanelInfo.TabIndex = 0;
            // 
            // groupPlayerIdentity
            // 
            this.groupPlayerIdentity.Controls.Add(this.radioFemale);
            this.groupPlayerIdentity.Controls.Add(this.radioMale);
            this.groupPlayerIdentity.Controls.Add(this.labelCommonName);
            this.groupPlayerIdentity.Controls.Add(this.textCommonName);
            this.groupPlayerIdentity.Controls.Add(this.textJerseyName);
            this.groupPlayerIdentity.Controls.Add(this.labelJerseyName);
            this.groupPlayerIdentity.Controls.Add(this.buttonGetId);
            this.groupPlayerIdentity.Controls.Add(this.viewer2DPhoto);
            this.groupPlayerIdentity.Controls.Add(this.numericPlayerId);
            this.groupPlayerIdentity.Controls.Add(this.buttonRandomizeIdentity);
            this.groupPlayerIdentity.Controls.Add(this.dateBirthDate);
            this.groupPlayerIdentity.Controls.Add(this.labelBirthdate);
            this.groupPlayerIdentity.Controls.Add(this.labelPlayerId);
            this.groupPlayerIdentity.Controls.Add(this.textSurname);
            this.groupPlayerIdentity.Controls.Add(this.textFirstName);
            this.groupPlayerIdentity.Controls.Add(this.comboCountry);
            this.groupPlayerIdentity.Controls.Add(this.labelFirstName);
            this.groupPlayerIdentity.Controls.Add(this.labelSurame);
            this.groupPlayerIdentity.Controls.Add(this.labelCountry);
            this.groupPlayerIdentity.Location = new System.Drawing.Point(3, 3);
            this.groupPlayerIdentity.Name = "groupPlayerIdentity";
            this.groupPlayerIdentity.Size = new System.Drawing.Size(391, 239);
            this.groupPlayerIdentity.TabIndex = 85;
            this.groupPlayerIdentity.TabStop = false;
            this.groupPlayerIdentity.Text = "Identity Card";
            // 
            // radioFemale
            // 
            this.radioFemale.AutoSize = true;
            this.radioFemale.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "Female", true));
            this.radioFemale.Location = new System.Drawing.Point(316, 207);
            this.radioFemale.Name = "radioFemale";
            this.radioFemale.Size = new System.Drawing.Size(59, 17);
            this.radioFemale.TabIndex = 163;
            this.radioFemale.TabStop = true;
            this.radioFemale.Text = "Female";
            this.radioFemale.UseVisualStyleBackColor = true;
            this.radioFemale.CheckedChanged += new System.EventHandler(this.radioFemale_CheckedChanged);
            // 
            // playerBindingSource
            // 
            this.playerBindingSource.DataSource = typeof(FifaLibrary.Player);
            // 
            // radioMale
            // 
            this.radioMale.AutoSize = true;
            this.radioMale.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "Male", true));
            this.radioMale.Location = new System.Drawing.Point(259, 207);
            this.radioMale.Name = "radioMale";
            this.radioMale.Size = new System.Drawing.Size(48, 17);
            this.radioMale.TabIndex = 162;
            this.radioMale.TabStop = true;
            this.radioMale.Text = "Male";
            this.radioMale.UseVisualStyleBackColor = true;
            // 
            // labelCommonName
            // 
            this.labelCommonName.AutoSize = true;
            this.labelCommonName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCommonName.Location = new System.Drawing.Point(156, 99);
            this.labelCommonName.Name = "labelCommonName";
            this.labelCommonName.Size = new System.Drawing.Size(79, 13);
            this.labelCommonName.TabIndex = 161;
            this.labelCommonName.Text = "Common Name";
            this.labelCommonName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textCommonName
            // 
            this.textCommonName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.playerBindingSource, "commonname", true));
            this.textCommonName.Location = new System.Drawing.Point(247, 96);
            this.textCommonName.Name = "textCommonName";
            this.textCommonName.Size = new System.Drawing.Size(131, 20);
            this.textCommonName.TabIndex = 2;
            this.textCommonName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textCommonName.TextChanged += new System.EventHandler(this.textCommonName_TextChanged);
            // 
            // textJerseyName
            // 
            this.textJerseyName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.playerBindingSource, "playerjerseyname", true));
            this.textJerseyName.Location = new System.Drawing.Point(247, 122);
            this.textJerseyName.Name = "textJerseyName";
            this.textJerseyName.Size = new System.Drawing.Size(131, 20);
            this.textJerseyName.TabIndex = 3;
            this.textJerseyName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelJerseyName
            // 
            this.labelJerseyName.AutoSize = true;
            this.labelJerseyName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelJerseyName.Location = new System.Drawing.Point(156, 125);
            this.labelJerseyName.Name = "labelJerseyName";
            this.labelJerseyName.Size = new System.Drawing.Size(37, 13);
            this.labelJerseyName.TabIndex = 159;
            this.labelJerseyName.Text = "Jersey";
            this.labelJerseyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonGetId
            // 
            this.buttonGetId.Image = ((System.Drawing.Image)(resources.GetObject("buttonGetId.Image")));
            this.buttonGetId.Location = new System.Drawing.Point(354, 19);
            this.buttonGetId.Name = "buttonGetId";
            this.buttonGetId.Size = new System.Drawing.Size(24, 20);
            this.buttonGetId.TabIndex = 156;
            this.buttonGetId.TabStop = false;
            this.buttonGetId.UseVisualStyleBackColor = true;
            this.buttonGetId.Click += new System.EventHandler(this.buttonGetId_Click);
            // 
            // viewer2DPhoto
            // 
            this.viewer2DPhoto.AutoTransparency = true;
            this.viewer2DPhoto.BackColor = System.Drawing.Color.Transparent;
            this.viewer2DPhoto.ButtonStripVisible = false;
            this.viewer2DPhoto.CurrentBitmap = null;
            this.viewer2DPhoto.ExtendedFormat = false;
            this.viewer2DPhoto.FullSizeButton = false;
            this.viewer2DPhoto.ImageLayout = System.Windows.Forms.ImageLayout.None;
            this.viewer2DPhoto.ImageSize = new System.Drawing.Size(128, 128);
            this.viewer2DPhoto.ImageSizeMultiplier = FifaControls.Viewer2D.SizeMultiplier.MiniFace;
            this.viewer2DPhoto.Location = new System.Drawing.Point(6, 16);
            this.viewer2DPhoto.Name = "viewer2DPhoto";
            this.viewer2DPhoto.RemoveButton = false;
            this.viewer2DPhoto.ShowButton = false;
            this.viewer2DPhoto.ShowButtonChecked = true;
            this.viewer2DPhoto.Size = new System.Drawing.Size(128, 153);
            this.viewer2DPhoto.TabIndex = 125;
            this.viewer2DPhoto.TabStop = false;
            // 
            // numericPlayerId
            // 
            this.numericPlayerId.Location = new System.Drawing.Point(248, 19);
            this.numericPlayerId.Maximum = new decimal(new int[] {
            600000,
            0,
            0,
            0});
            this.numericPlayerId.Name = "numericPlayerId";
            this.numericPlayerId.Size = new System.Drawing.Size(91, 20);
            this.numericPlayerId.TabIndex = 154;
            this.numericPlayerId.TabStop = false;
            this.numericPlayerId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericPlayerId.Value = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.numericPlayerId.ValueChanged += new System.EventHandler(this.numericPlayerId_ValueChanged);
            // 
            // buttonRandomizeIdentity
            // 
            this.buttonRandomizeIdentity.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonRandomizeIdentity.Location = new System.Drawing.Point(6, 177);
            this.buttonRandomizeIdentity.Name = "buttonRandomizeIdentity";
            this.buttonRandomizeIdentity.Size = new System.Drawing.Size(128, 23);
            this.buttonRandomizeIdentity.TabIndex = 124;
            this.buttonRandomizeIdentity.TabStop = false;
            this.buttonRandomizeIdentity.Text = "Randomize";
            this.buttonRandomizeIdentity.UseVisualStyleBackColor = true;
            this.buttonRandomizeIdentity.Click += new System.EventHandler(this.buttonRandomizeIdentity_Click);
            // 
            // dateBirthDate
            // 
            this.dateBirthDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "birthdate", true));
            this.dateBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateBirthDate.Location = new System.Drawing.Point(247, 153);
            this.dateBirthDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dateBirthDate.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.dateBirthDate.Name = "dateBirthDate";
            this.dateBirthDate.Size = new System.Drawing.Size(131, 20);
            this.dateBirthDate.TabIndex = 4;
            this.dateBirthDate.Value = new System.DateTime(2006, 12, 31, 0, 0, 0, 0);
            // 
            // labelBirthdate
            // 
            this.labelBirthdate.AutoSize = true;
            this.labelBirthdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelBirthdate.Location = new System.Drawing.Point(156, 156);
            this.labelBirthdate.Name = "labelBirthdate";
            this.labelBirthdate.Size = new System.Drawing.Size(49, 13);
            this.labelBirthdate.TabIndex = 4;
            this.labelBirthdate.Text = "Birthdate";
            this.labelBirthdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPlayerId
            // 
            this.labelPlayerId.AutoSize = true;
            this.labelPlayerId.BackColor = System.Drawing.Color.Transparent;
            this.labelPlayerId.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelPlayerId.Location = new System.Drawing.Point(156, 23);
            this.labelPlayerId.Name = "labelPlayerId";
            this.labelPlayerId.Size = new System.Drawing.Size(48, 13);
            this.labelPlayerId.TabIndex = 122;
            this.labelPlayerId.Text = "Player Id";
            this.labelPlayerId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textSurname
            // 
            this.textSurname.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.playerBindingSource, "lastname", true));
            this.textSurname.Location = new System.Drawing.Point(247, 70);
            this.textSurname.Name = "textSurname";
            this.textSurname.Size = new System.Drawing.Size(131, 20);
            this.textSurname.TabIndex = 1;
            this.textSurname.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textSurname.TextChanged += new System.EventHandler(this.textSurname_TextChanged);
            // 
            // textFirstName
            // 
            this.textFirstName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.playerBindingSource, "firstname", true));
            this.textFirstName.Location = new System.Drawing.Point(248, 44);
            this.textFirstName.Name = "textFirstName";
            this.textFirstName.Size = new System.Drawing.Size(131, 20);
            this.textFirstName.TabIndex = 0;
            this.textFirstName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textFirstName.TextChanged += new System.EventHandler(this.textFirstName_TextChanged);
            // 
            // comboCountry
            // 
            this.comboCountry.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.playerBindingSource, "Country", true));
            this.comboCountry.DataSource = this.countryListBindingSource;
            this.comboCountry.ItemHeight = 13;
            this.comboCountry.Location = new System.Drawing.Point(247, 179);
            this.comboCountry.MaxLength = 32767;
            this.comboCountry.Name = "comboCountry";
            this.comboCountry.Size = new System.Drawing.Size(131, 21);
            this.comboCountry.TabIndex = 5;
            // 
            // countryListBindingSource
            // 
            this.countryListBindingSource.DataSource = typeof(FifaLibrary.CountryList);
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelFirstName.Location = new System.Drawing.Point(156, 47);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(57, 13);
            this.labelFirstName.TabIndex = 1;
            this.labelFirstName.Text = "First Name";
            this.labelFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSurame
            // 
            this.labelSurame.AutoSize = true;
            this.labelSurame.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelSurame.Location = new System.Drawing.Point(156, 73);
            this.labelSurame.Name = "labelSurame";
            this.labelSurame.Size = new System.Drawing.Size(58, 13);
            this.labelSurame.TabIndex = 2;
            this.labelSurame.Text = "Last Name";
            this.labelSurame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCountry
            // 
            this.labelCountry.AutoSize = true;
            this.labelCountry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCountry.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelCountry.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCountry.Location = new System.Drawing.Point(156, 182);
            this.labelCountry.Name = "labelCountry";
            this.labelCountry.Size = new System.Drawing.Size(43, 13);
            this.labelCountry.TabIndex = 5;
            this.labelCountry.Text = "Country";
            this.labelCountry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelCountry.DoubleClick += new System.EventHandler(this.labelCountry_DoubleClick);
            // 
            // groupBoxBody
            // 
            this.groupBoxBody.Controls.Add(this.comboWeakFoot);
            this.groupBoxBody.Controls.Add(this.labelWeakFoot);
            this.groupBoxBody.Controls.Add(this.comboBody);
            this.groupBoxBody.Controls.Add(this.numericHeight);
            this.groupBoxBody.Controls.Add(this.numericWeight);
            this.groupBoxBody.Controls.Add(this.labelWeight);
            this.groupBoxBody.Controls.Add(this.labelBody);
            this.groupBoxBody.Controls.Add(this.domainPreferredFoot);
            this.groupBoxBody.Controls.Add(this.labelHeight);
            this.groupBoxBody.Controls.Add(this.labelPreferredFoot);
            this.groupBoxBody.Location = new System.Drawing.Point(3, 248);
            this.groupBoxBody.Name = "groupBoxBody";
            this.groupBoxBody.Size = new System.Drawing.Size(391, 113);
            this.groupBoxBody.TabIndex = 86;
            this.groupBoxBody.TabStop = false;
            this.groupBoxBody.Text = "Body";
            // 
            // comboWeakFoot
            // 
            this.comboWeakFoot.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.playerBindingSource, "weakfootabilitytypecode", true));
            this.comboWeakFoot.FormattingEnabled = true;
            this.comboWeakFoot.Items.AddRange(new object[] {
            "Very Poor",
            "Poor",
            "Medium",
            "Good",
            "Ambidexter"});
            this.comboWeakFoot.Location = new System.Drawing.Point(247, 76);
            this.comboWeakFoot.Name = "comboWeakFoot";
            this.comboWeakFoot.Size = new System.Drawing.Size(103, 21);
            this.comboWeakFoot.TabIndex = 3;
            // 
            // labelWeakFoot
            // 
            this.labelWeakFoot.AutoSize = true;
            this.labelWeakFoot.BackColor = System.Drawing.Color.Transparent;
            this.labelWeakFoot.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelWeakFoot.Location = new System.Drawing.Point(184, 79);
            this.labelWeakFoot.Name = "labelWeakFoot";
            this.labelWeakFoot.Size = new System.Drawing.Size(57, 13);
            this.labelWeakFoot.TabIndex = 54;
            this.labelWeakFoot.Text = "Weak foot";
            this.labelWeakFoot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBody
            // 
            this.comboBody.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.playerBindingSource, "bodytypecode", true));
            this.comboBody.FormattingEnabled = true;
            this.comboBody.Items.AddRange(new object[] {
            "Average Height and Lean",
            "Average Height ",
            "Average Height and Muscular",
            "Tall and Lean",
            "Tall",
            "Tall and Muscular",
            "Short and Lean",
            "Short ",
            "Short and Muscular",
            "Very Tall and Lean",
            "Very Tall",
            "Very Tall and Muscular"});
            this.comboBody.Location = new System.Drawing.Point(71, 46);
            this.comboBody.Name = "comboBody";
            this.comboBody.Size = new System.Drawing.Size(279, 21);
            this.comboBody.TabIndex = 4;
            // 
            // numericHeight
            // 
            this.numericHeight.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "height", true));
            this.numericHeight.Location = new System.Drawing.Point(71, 20);
            this.numericHeight.Maximum = new decimal(new int[] {
            215,
            0,
            0,
            0});
            this.numericHeight.Minimum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numericHeight.Name = "numericHeight";
            this.numericHeight.Size = new System.Drawing.Size(103, 20);
            this.numericHeight.TabIndex = 0;
            this.numericHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericHeight.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // numericWeight
            // 
            this.numericWeight.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "weight", true));
            this.numericWeight.Location = new System.Drawing.Point(247, 20);
            this.numericWeight.Maximum = new decimal(new int[] {
            115,
            0,
            0,
            0});
            this.numericWeight.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericWeight.Name = "numericWeight";
            this.numericWeight.Size = new System.Drawing.Size(103, 20);
            this.numericWeight.TabIndex = 2;
            this.numericWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericWeight.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // labelWeight
            // 
            this.labelWeight.AutoSize = true;
            this.labelWeight.BackColor = System.Drawing.Color.Transparent;
            this.labelWeight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelWeight.Location = new System.Drawing.Point(184, 23);
            this.labelWeight.Name = "labelWeight";
            this.labelWeight.Size = new System.Drawing.Size(41, 13);
            this.labelWeight.TabIndex = 12;
            this.labelWeight.Text = "Weight";
            this.labelWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBody
            // 
            this.labelBody.AutoSize = true;
            this.labelBody.BackColor = System.Drawing.Color.Transparent;
            this.labelBody.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelBody.Location = new System.Drawing.Point(6, 48);
            this.labelBody.Name = "labelBody";
            this.labelBody.Size = new System.Drawing.Size(31, 13);
            this.labelBody.TabIndex = 26;
            this.labelBody.Text = "Body";
            this.labelBody.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // domainPreferredFoot
            // 
            this.domainPreferredFoot.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.playerBindingSource, "preferredfoot", true));
            this.domainPreferredFoot.Items.Add("Right");
            this.domainPreferredFoot.Items.Add("Left");
            this.domainPreferredFoot.Location = new System.Drawing.Point(71, 77);
            this.domainPreferredFoot.Name = "domainPreferredFoot";
            this.domainPreferredFoot.Size = new System.Drawing.Size(103, 20);
            this.domainPreferredFoot.TabIndex = 1;
            this.domainPreferredFoot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.domainPreferredFoot.Wrap = true;
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.BackColor = System.Drawing.Color.Transparent;
            this.labelHeight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelHeight.Location = new System.Drawing.Point(6, 23);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(38, 13);
            this.labelHeight.TabIndex = 11;
            this.labelHeight.Text = "Height";
            this.labelHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPreferredFoot
            // 
            this.labelPreferredFoot.AutoSize = true;
            this.labelPreferredFoot.BackColor = System.Drawing.Color.Transparent;
            this.labelPreferredFoot.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelPreferredFoot.Location = new System.Drawing.Point(6, 79);
            this.labelPreferredFoot.Name = "labelPreferredFoot";
            this.labelPreferredFoot.Size = new System.Drawing.Size(49, 13);
            this.labelPreferredFoot.TabIndex = 49;
            this.labelPreferredFoot.Text = "Best foot";
            this.labelPreferredFoot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxLook
            // 
            this.groupBoxLook.Controls.Add(this.checkJerseyFit);
            this.groupBoxLook.Controls.Add(this.checkTrainingPants);
            this.groupBoxLook.Controls.Add(this.domainSocksStyle);
            this.groupBoxLook.Controls.Add(this.label8);
            this.groupBoxLook.Controls.Add(this.numericGkGloves);
            this.groupBoxLook.Controls.Add(this.labelGkGloves);
            this.groupBoxLook.Controls.Add(this.labelWinter);
            this.groupBoxLook.Controls.Add(this.comboWinterAccessories);
            this.groupBoxLook.Controls.Add(this.domainJerseyStyle);
            this.groupBoxLook.Controls.Add(this.domainSleeves);
            this.groupBoxLook.Controls.Add(this.pictureColorAcc2);
            this.groupBoxLook.Controls.Add(this.pictureColorAcc3);
            this.groupBoxLook.Controls.Add(this.pictureColorAcc4);
            this.groupBoxLook.Controls.Add(this.pictureColorAcc1);
            this.groupBoxLook.Controls.Add(this.domainAccessory4);
            this.groupBoxLook.Controls.Add(this.domainAccessory3);
            this.groupBoxLook.Controls.Add(this.domainAccessory2);
            this.groupBoxLook.Controls.Add(this.domainAccessory1);
            this.groupBoxLook.Controls.Add(this.labelSleeves);
            this.groupBoxLook.Controls.Add(this.labelJerseyStyle);
            this.groupBoxLook.Controls.Add(this.labelAccesories);
            this.groupBoxLook.Location = new System.Drawing.Point(3, 367);
            this.groupBoxLook.Name = "groupBoxLook";
            this.groupBoxLook.Size = new System.Drawing.Size(391, 280);
            this.groupBoxLook.TabIndex = 87;
            this.groupBoxLook.TabStop = false;
            this.groupBoxLook.Text = "Look";
            // 
            // checkJerseyFit
            // 
            this.checkJerseyFit.AutoSize = true;
            this.checkJerseyFit.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "jerseyfit", true));
            this.checkJerseyFit.Location = new System.Drawing.Point(280, 18);
            this.checkJerseyFit.Name = "checkJerseyFit";
            this.checkJerseyFit.Size = new System.Drawing.Size(70, 17);
            this.checkJerseyFit.TabIndex = 99;
            this.checkJerseyFit.Text = "Jersey Fit";
            this.checkJerseyFit.UseVisualStyleBackColor = true;
            // 
            // checkTrainingPants
            // 
            this.checkTrainingPants.AutoSize = true;
            this.checkTrainingPants.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "TrainingPants", true));
            this.checkTrainingPants.Location = new System.Drawing.Point(238, 131);
            this.checkTrainingPants.Name = "checkTrainingPants";
            this.checkTrainingPants.Size = new System.Drawing.Size(112, 17);
            this.checkTrainingPants.TabIndex = 98;
            this.checkTrainingPants.Text = "GK Training Pants";
            this.checkTrainingPants.UseVisualStyleBackColor = true;
            // 
            // domainSocksStyle
            // 
            this.domainSocksStyle.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.playerBindingSource, "socklengthcode", true));
            this.domainSocksStyle.Items.Add("Normal Socks");
            this.domainSocksStyle.Items.Add("Low Socks");
            this.domainSocksStyle.Items.Add("High Socks");
            this.domainSocksStyle.Location = new System.Drawing.Point(108, 70);
            this.domainSocksStyle.Name = "domainSocksStyle";
            this.domainSocksStyle.Size = new System.Drawing.Size(242, 20);
            this.domainSocksStyle.TabIndex = 68;
            this.domainSocksStyle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.domainSocksStyle.Wrap = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(6, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 69;
            this.label8.Text = "Socks Style";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericGkGloves
            // 
            this.numericGkGloves.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "gkglovetypecode", true));
            this.numericGkGloves.Location = new System.Drawing.Point(108, 130);
            this.numericGkGloves.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.numericGkGloves.Name = "numericGkGloves";
            this.numericGkGloves.Size = new System.Drawing.Size(106, 20);
            this.numericGkGloves.TabIndex = 8;
            this.numericGkGloves.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericGkGloves.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelGkGloves
            // 
            this.labelGkGloves.AutoSize = true;
            this.labelGkGloves.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelGkGloves.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGkGloves.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelGkGloves.Location = new System.Drawing.Point(10, 132);
            this.labelGkGloves.Name = "labelGkGloves";
            this.labelGkGloves.Size = new System.Drawing.Size(58, 13);
            this.labelGkGloves.TabIndex = 67;
            this.labelGkGloves.Text = "GK Gloves";
            this.labelGkGloves.DoubleClick += new System.EventHandler(this.labelGkGloves_DoubleClick);
            // 
            // labelWinter
            // 
            this.labelWinter.AutoSize = true;
            this.labelWinter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelWinter.Location = new System.Drawing.Point(6, 101);
            this.labelWinter.Name = "labelWinter";
            this.labelWinter.Size = new System.Drawing.Size(98, 13);
            this.labelWinter.TabIndex = 64;
            this.labelWinter.Text = "Winter Accessories";
            this.labelWinter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboWinterAccessories
            // 
            this.comboWinterAccessories.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.playerBindingSource, "hasseasonaljersey", true));
            this.comboWinterAccessories.FormattingEnabled = true;
            this.comboWinterAccessories.Items.AddRange(new object[] {
            "None",
            "Long Sleeves no underarmor stuff",
            "Long Sleeves with underarmor neck",
            "Short sleeves with underarmor arms no neck",
            "Short sleeves with underarmor arms and neck"});
            this.comboWinterAccessories.Location = new System.Drawing.Point(108, 98);
            this.comboWinterAccessories.Name = "comboWinterAccessories";
            this.comboWinterAccessories.Size = new System.Drawing.Size(242, 21);
            this.comboWinterAccessories.TabIndex = 2;
            // 
            // domainJerseyStyle
            // 
            this.domainJerseyStyle.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.playerBindingSource, "jerseystylecode", true));
            this.domainJerseyStyle.Items.Add("Normal");
            this.domainJerseyStyle.Items.Add("Untucked");
            this.domainJerseyStyle.Location = new System.Drawing.Point(108, 17);
            this.domainJerseyStyle.Name = "domainJerseyStyle";
            this.domainJerseyStyle.Size = new System.Drawing.Size(164, 20);
            this.domainJerseyStyle.TabIndex = 1;
            this.domainJerseyStyle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.domainJerseyStyle.Wrap = true;
            // 
            // domainSleeves
            // 
            this.domainSleeves.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.playerBindingSource, "jerseysleevelengthcode", true));
            this.domainSleeves.Items.Add("Short Sleeves ");
            this.domainSleeves.Items.Add("Long Sleeves ");
            this.domainSleeves.Items.Add("Long Sleeves with underarmor neck");
            this.domainSleeves.Items.Add("Short sleeves with underarmor arms no neck");
            this.domainSleeves.Items.Add("Short sleeves with underarmor arms and neck");
            this.domainSleeves.Location = new System.Drawing.Point(108, 43);
            this.domainSleeves.Name = "domainSleeves";
            this.domainSleeves.Size = new System.Drawing.Size(242, 20);
            this.domainSleeves.TabIndex = 0;
            this.domainSleeves.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.domainSleeves.Wrap = true;
            // 
            // pictureColorAcc2
            // 
            this.pictureColorAcc2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureColorAcc2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureColorAcc2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureColorAcc2.Location = new System.Drawing.Point(223, 201);
            this.pictureColorAcc2.Name = "pictureColorAcc2";
            this.pictureColorAcc2.Size = new System.Drawing.Size(20, 20);
            this.pictureColorAcc2.TabIndex = 55;
            this.pictureColorAcc2.TabStop = false;
            this.pictureColorAcc2.Click += new System.EventHandler(this.pictureColorAcc2_Click);
            // 
            // pictureColorAcc3
            // 
            this.pictureColorAcc3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureColorAcc3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureColorAcc3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureColorAcc3.Location = new System.Drawing.Point(223, 227);
            this.pictureColorAcc3.Name = "pictureColorAcc3";
            this.pictureColorAcc3.Size = new System.Drawing.Size(20, 20);
            this.pictureColorAcc3.TabIndex = 56;
            this.pictureColorAcc3.TabStop = false;
            this.pictureColorAcc3.Click += new System.EventHandler(this.pictureColorAcc3_Click);
            // 
            // pictureColorAcc4
            // 
            this.pictureColorAcc4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureColorAcc4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureColorAcc4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureColorAcc4.Location = new System.Drawing.Point(223, 253);
            this.pictureColorAcc4.Name = "pictureColorAcc4";
            this.pictureColorAcc4.Size = new System.Drawing.Size(20, 20);
            this.pictureColorAcc4.TabIndex = 57;
            this.pictureColorAcc4.TabStop = false;
            this.pictureColorAcc4.Click += new System.EventHandler(this.pictureColorAcc4_Click);
            // 
            // pictureColorAcc1
            // 
            this.pictureColorAcc1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureColorAcc1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureColorAcc1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureColorAcc1.Location = new System.Drawing.Point(223, 174);
            this.pictureColorAcc1.Name = "pictureColorAcc1";
            this.pictureColorAcc1.Size = new System.Drawing.Size(20, 20);
            this.pictureColorAcc1.TabIndex = 45;
            this.pictureColorAcc1.TabStop = false;
            this.pictureColorAcc1.Click += new System.EventHandler(this.pictureColorAcc1_Click);
            // 
            // domainAccessory4
            // 
            this.domainAccessory4.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.playerBindingSource, "accessorycode4", true));
            this.domainAccessory4.Items.AddRange(new object[] {
            "None",
            "1 Unused",
            "2 Hearphone",
            "3 Unused",
            "4 Left watch",
            "5 Right watch",
            "6 Left hand tape",
            "7 Right hand tape",
            "8 Left wristle tape",
            "9 Right wristle tape",
            "10 Left knee tape",
            "11 Right knee tape",
            "12 Left knee tutor",
            "13 Right knee tutor",
            "14 Left ankle tape",
            "15 Right ankle tape",
            "16 Gloves",
            "17 Gloves",
            "18 Unused",
            "19 Unused",
            "20 Unused",
            "21 Unused",
            "22 Left finger tape",
            "23 Right finger tape",
            "24 Left wide wristle tape",
            "25 Right wide wristle tape",
            "26 Left bracelet",
            "27 Right bracelet"});
            this.domainAccessory4.Location = new System.Drawing.Point(12, 252);
            this.domainAccessory4.Name = "domainAccessory4";
            this.domainAccessory4.Size = new System.Drawing.Size(197, 21);
            this.domainAccessory4.TabIndex = 7;
            // 
            // domainAccessory3
            // 
            this.domainAccessory3.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.playerBindingSource, "accessorycode3", true));
            this.domainAccessory3.Items.AddRange(new object[] {
            "None",
            "1 Unused",
            "2 Hearphone",
            "3 Unused",
            "4 Left watch",
            "5 Right watch",
            "6 Left hand tape",
            "7 Right hand tape",
            "8 Left wristle tape",
            "9 Right wristle tape",
            "10 Left knee tape",
            "11 Right knee tape",
            "12 Left knee tutor",
            "13 Right knee tutor",
            "14 Left ankle tape",
            "15 Right ankle tape",
            "16 Gloves",
            "17 Gloves",
            "18 Unused",
            "19 Unused",
            "20 Unused",
            "21 Unused",
            "22 Left finger tape",
            "23 Right finger tape",
            "24 Left wide wristle tape",
            "25 Right wide wristle tape",
            "26 Left bracelet",
            "27 Right bracelet"});
            this.domainAccessory3.Location = new System.Drawing.Point(12, 226);
            this.domainAccessory3.Name = "domainAccessory3";
            this.domainAccessory3.Size = new System.Drawing.Size(197, 21);
            this.domainAccessory3.TabIndex = 6;
            // 
            // domainAccessory2
            // 
            this.domainAccessory2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.playerBindingSource, "accessorycode2", true));
            this.domainAccessory2.Items.AddRange(new object[] {
            "None",
            "1 Unused",
            "2 Hearphone",
            "3 Unused",
            "4 Left watch",
            "5 Right watch",
            "6 Left hand tape",
            "7 Right hand tape",
            "8 Left wristle tape",
            "9 Right wristle tape",
            "10 Left knee tape",
            "11 Right knee tape",
            "12 Left knee tutor",
            "13 Right knee tutor",
            "14 Left ankle tape",
            "15 Right ankle tape",
            "16 Gloves",
            "17 Gloves",
            "18 Unused",
            "19 Unused",
            "20 Unused",
            "21 Unused",
            "22 Left finger tape",
            "23 Right finger tape",
            "24 Left wide wristle tape",
            "25 Right wide wristle tape",
            "26 Left bracelet",
            "27 Right bracelet"});
            this.domainAccessory2.Location = new System.Drawing.Point(12, 200);
            this.domainAccessory2.Name = "domainAccessory2";
            this.domainAccessory2.Size = new System.Drawing.Size(197, 21);
            this.domainAccessory2.TabIndex = 5;
            // 
            // domainAccessory1
            // 
            this.domainAccessory1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.playerBindingSource, "accessorycode1", true));
            this.domainAccessory1.Items.AddRange(new object[] {
            "None",
            "1 Unused",
            "2 Hearphone",
            "3 Unused",
            "4 Left watch",
            "5 Right watch",
            "6 Left hand tape",
            "7 Right hand tape",
            "8 Left wristle tape",
            "9 Right wristle tape",
            "10 Left knee tape",
            "11 Right knee tape",
            "12 Left knee tutor",
            "13 Right knee tutor",
            "14 Left ankle tape",
            "15 Right ankle tape",
            "16 Gloves",
            "17 Gloves",
            "18 Unused",
            "19 Unused",
            "20 Unused",
            "21 Unused",
            "22 Left finger tape",
            "23 Right finger tape",
            "24 Left wide wristle tape",
            "25 Right wide wristle tape",
            "26 Left bracelet",
            "27 Right bracelet"});
            this.domainAccessory1.Location = new System.Drawing.Point(12, 173);
            this.domainAccessory1.Name = "domainAccessory1";
            this.domainAccessory1.Size = new System.Drawing.Size(197, 21);
            this.domainAccessory1.TabIndex = 4;
            // 
            // labelSleeves
            // 
            this.labelSleeves.AutoSize = true;
            this.labelSleeves.BackColor = System.Drawing.Color.Transparent;
            this.labelSleeves.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelSleeves.Location = new System.Drawing.Point(5, 44);
            this.labelSleeves.Name = "labelSleeves";
            this.labelSleeves.Size = new System.Drawing.Size(81, 13);
            this.labelSleeves.TabIndex = 35;
            this.labelSleeves.Text = "Sleeves Length";
            this.labelSleeves.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelJerseyStyle
            // 
            this.labelJerseyStyle.AutoSize = true;
            this.labelJerseyStyle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelJerseyStyle.Location = new System.Drawing.Point(5, 19);
            this.labelJerseyStyle.Name = "labelJerseyStyle";
            this.labelJerseyStyle.Size = new System.Drawing.Size(63, 13);
            this.labelJerseyStyle.TabIndex = 37;
            this.labelJerseyStyle.Text = "Jersey Style";
            this.labelJerseyStyle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAccesories
            // 
            this.labelAccesories.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelAccesories.Location = new System.Drawing.Point(42, 154);
            this.labelAccesories.Name = "labelAccesories";
            this.labelAccesories.Size = new System.Drawing.Size(136, 20);
            this.labelAccesories.TabIndex = 39;
            this.labelAccesories.Text = "Accesories";
            this.labelAccesories.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupPlayFirTeam
            // 
            this.groupPlayFirTeam.Controls.Add(this.groupIsLoan);
            this.groupPlayFirTeam.Controls.Add(this.checkIsLoan);
            this.groupPlayFirTeam.Controls.Add(this.dateJoiningDate);
            this.groupPlayFirTeam.Controls.Add(this.label4);
            this.groupPlayFirTeam.Controls.Add(this.listViewPlayingTeams);
            this.groupPlayFirTeam.Controls.Add(this.comboClubTeam);
            this.groupPlayFirTeam.Controls.Add(this.buttonCallNationalTeam);
            this.groupPlayFirTeam.Controls.Add(this.buttonRemoveNationalTeam);
            this.groupPlayFirTeam.Location = new System.Drawing.Point(400, 3);
            this.groupPlayFirTeam.Name = "groupPlayFirTeam";
            this.groupPlayFirTeam.Size = new System.Drawing.Size(243, 213);
            this.groupPlayFirTeam.TabIndex = 88;
            this.groupPlayFirTeam.TabStop = false;
            this.groupPlayFirTeam.Text = "Playing for";
            // 
            // groupIsLoan
            // 
            this.groupIsLoan.Controls.Add(this.comboTeamLoanedFrom);
            this.groupIsLoan.Controls.Add(this.label12);
            this.groupIsLoan.Controls.Add(this.dateLoanEnd);
            this.groupIsLoan.Controls.Add(this.label11);
            this.groupIsLoan.Location = new System.Drawing.Point(6, 144);
            this.groupIsLoan.Name = "groupIsLoan";
            this.groupIsLoan.Size = new System.Drawing.Size(231, 63);
            this.groupIsLoan.TabIndex = 139;
            this.groupIsLoan.TabStop = false;
            this.groupIsLoan.Visible = false;
            // 
            // comboTeamLoanedFrom
            // 
            this.comboTeamLoanedFrom.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.playerBindingSource, "TeamLoanedFrom", true));
            this.comboTeamLoanedFrom.DataSource = this.teamListBindingSource;
            this.comboTeamLoanedFrom.ItemHeight = 13;
            this.comboTeamLoanedFrom.Location = new System.Drawing.Point(89, 40);
            this.comboTeamLoanedFrom.MaxLength = 32767;
            this.comboTeamLoanedFrom.Name = "comboTeamLoanedFrom";
            this.comboTeamLoanedFrom.Size = new System.Drawing.Size(131, 21);
            this.comboTeamLoanedFrom.TabIndex = 141;
            this.comboTeamLoanedFrom.SelectedIndexChanged += new System.EventHandler(this.comboTeamLoanedFrom_SelectedIndexChanged);
            // 
            // teamListBindingSource
            // 
            this.teamListBindingSource.DataSource = typeof(FifaLibrary.TeamList);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(7, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 140;
            this.label12.Text = "Loaned From";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateLoanEnd
            // 
            this.dateLoanEnd.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "loandateend", true));
            this.dateLoanEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateLoanEnd.Location = new System.Drawing.Point(89, 14);
            this.dateLoanEnd.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.dateLoanEnd.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateLoanEnd.Name = "dateLoanEnd";
            this.dateLoanEnd.Size = new System.Drawing.Size(131, 20);
            this.dateLoanEnd.TabIndex = 139;
            this.dateLoanEnd.Value = new System.DateTime(2014, 6, 30, 0, 0, 0, 0);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(6, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 138;
            this.label11.Text = "Loan End Date";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkIsLoan
            // 
            this.checkIsLoan.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "IsLoaned", true));
            this.checkIsLoan.Location = new System.Drawing.Point(6, 125);
            this.checkIsLoan.Name = "checkIsLoan";
            this.checkIsLoan.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkIsLoan.Size = new System.Drawing.Size(104, 17);
            this.checkIsLoan.TabIndex = 138;
            this.checkIsLoan.Text = "Is Loaned ";
            this.checkIsLoan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkIsLoan.UseVisualStyleBackColor = true;
            this.checkIsLoan.CheckedChanged += new System.EventHandler(this.checkIsLoan_CheckedChanged);
            // 
            // dateJoiningDate
            // 
            this.dateJoiningDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "joindate", true));
            this.dateJoiningDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateJoiningDate.Location = new System.Drawing.Point(95, 99);
            this.dateJoiningDate.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.dateJoiningDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateJoiningDate.Name = "dateJoiningDate";
            this.dateJoiningDate.Size = new System.Drawing.Size(131, 20);
            this.dateJoiningDate.TabIndex = 137;
            this.dateJoiningDate.Value = new System.DateTime(2013, 7, 1, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(5, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 136;
            this.label4.Text = "Joining Date";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listViewPlayingTeams
            // 
            this.listViewPlayingTeams.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listViewPlayingTeams.FullRowSelect = true;
            this.listViewPlayingTeams.GridLines = true;
            this.listViewPlayingTeams.HideSelection = false;
            this.listViewPlayingTeams.LargeImageList = this.imageListTeamLogos;
            this.listViewPlayingTeams.Location = new System.Drawing.Point(6, 19);
            this.listViewPlayingTeams.MultiSelect = false;
            this.listViewPlayingTeams.Name = "listViewPlayingTeams";
            this.listViewPlayingTeams.Size = new System.Drawing.Size(231, 71);
            this.listViewPlayingTeams.TabIndex = 135;
            this.listViewPlayingTeams.TabStop = false;
            this.listViewPlayingTeams.UseCompatibleStateImageBehavior = false;
            this.listViewPlayingTeams.DoubleClick += new System.EventHandler(this.listViewPlayingTeams_DoubleClick);
            // 
            // imageListTeamLogos
            // 
            this.imageListTeamLogos.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListTeamLogos.ImageSize = new System.Drawing.Size(32, 32);
            this.imageListTeamLogos.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // comboClubTeam
            // 
            this.comboClubTeam.ItemHeight = 13;
            this.comboClubTeam.Location = new System.Drawing.Point(10, 334);
            this.comboClubTeam.MaxLength = 32767;
            this.comboClubTeam.Name = "comboClubTeam";
            this.comboClubTeam.Size = new System.Drawing.Size(100, 21);
            this.comboClubTeam.Sorted = true;
            this.comboClubTeam.TabIndex = 0;
            this.comboClubTeam.Visible = false;
            // 
            // buttonCallNationalTeam
            // 
            this.buttonCallNationalTeam.Enabled = false;
            this.buttonCallNationalTeam.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonCallNationalTeam.Location = new System.Drawing.Point(130, 334);
            this.buttonCallNationalTeam.Name = "buttonCallNationalTeam";
            this.buttonCallNationalTeam.Size = new System.Drawing.Size(50, 20);
            this.buttonCallNationalTeam.TabIndex = 1;
            this.buttonCallNationalTeam.Text = "Call";
            this.buttonCallNationalTeam.Visible = false;
            // 
            // buttonRemoveNationalTeam
            // 
            this.buttonRemoveNationalTeam.Enabled = false;
            this.buttonRemoveNationalTeam.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonRemoveNationalTeam.Location = new System.Drawing.Point(180, 334);
            this.buttonRemoveNationalTeam.Name = "buttonRemoveNationalTeam";
            this.buttonRemoveNationalTeam.Size = new System.Drawing.Size(50, 20);
            this.buttonRemoveNationalTeam.TabIndex = 2;
            this.buttonRemoveNationalTeam.Text = "Remove";
            this.buttonRemoveNationalTeam.Visible = false;
            // 
            // groupShoes
            // 
            this.groupShoes.Controls.Add(this.label1ShoesType);
            this.groupShoes.Controls.Add(this.pictureColorShoes2);
            this.groupShoes.Controls.Add(this.pictureColorShoes1);
            this.groupShoes.Controls.Add(this.numericShoesBrand);
            this.groupShoes.Controls.Add(this.labelShoesType);
            this.groupShoes.Controls.Add(this.labelShoesColor);
            this.groupShoes.Controls.Add(this.numericShoesDesign);
            this.groupShoes.Controls.Add(this.viewer2DShoes);
            this.groupShoes.Controls.Add(this.labelShoes);
            this.groupShoes.Location = new System.Drawing.Point(400, 222);
            this.groupShoes.Name = "groupShoes";
            this.groupShoes.Size = new System.Drawing.Size(243, 178);
            this.groupShoes.TabIndex = 90;
            this.groupShoes.TabStop = false;
            this.groupShoes.Text = "Shoes";
            // 
            // label1ShoesType
            // 
            this.label1ShoesType.AutoSize = true;
            this.label1ShoesType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1ShoesType.Location = new System.Drawing.Point(29, 66);
            this.label1ShoesType.Name = "label1ShoesType";
            this.label1ShoesType.Size = new System.Drawing.Size(40, 13);
            this.label1ShoesType.TabIndex = 64;
            this.label1ShoesType.Text = "Design";
            this.label1ShoesType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureColorShoes2
            // 
            this.pictureColorShoes2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureColorShoes2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureColorShoes2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureColorShoes2.Location = new System.Drawing.Point(72, 131);
            this.pictureColorShoes2.Name = "pictureColorShoes2";
            this.pictureColorShoes2.Size = new System.Drawing.Size(20, 20);
            this.pictureColorShoes2.TabIndex = 63;
            this.pictureColorShoes2.TabStop = false;
            this.pictureColorShoes2.Click += new System.EventHandler(this.pictureColorShoes2_Click);
            // 
            // pictureColorShoes1
            // 
            this.pictureColorShoes1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureColorShoes1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureColorShoes1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureColorShoes1.Location = new System.Drawing.Point(12, 131);
            this.pictureColorShoes1.Name = "pictureColorShoes1";
            this.pictureColorShoes1.Size = new System.Drawing.Size(20, 20);
            this.pictureColorShoes1.TabIndex = 62;
            this.pictureColorShoes1.TabStop = false;
            this.pictureColorShoes1.Click += new System.EventHandler(this.pictureColorShoes1_Click);
            // 
            // numericShoesBrand
            // 
            this.numericShoesBrand.Location = new System.Drawing.Point(12, 36);
            this.numericShoesBrand.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericShoesBrand.Name = "numericShoesBrand";
            this.numericShoesBrand.Size = new System.Drawing.Size(80, 20);
            this.numericShoesBrand.TabIndex = 9;
            this.numericShoesBrand.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericShoesBrand.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericShoesBrand.ValueChanged += new System.EventHandler(this.numericShoesBrand_ValueChanged);
            // 
            // labelShoesType
            // 
            this.labelShoesType.AutoSize = true;
            this.labelShoesType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelShoesType.Location = new System.Drawing.Point(31, 18);
            this.labelShoesType.Name = "labelShoesType";
            this.labelShoesType.Size = new System.Drawing.Size(35, 13);
            this.labelShoesType.TabIndex = 60;
            this.labelShoesType.Text = "Brand";
            this.labelShoesType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelShoesColor
            // 
            this.labelShoesColor.AutoSize = true;
            this.labelShoesColor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelShoesColor.Location = new System.Drawing.Point(33, 113);
            this.labelShoesColor.Name = "labelShoesColor";
            this.labelShoesColor.Size = new System.Drawing.Size(36, 13);
            this.labelShoesColor.TabIndex = 61;
            this.labelShoesColor.Text = "Colors";
            this.labelShoesColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericShoesDesign
            // 
            this.numericShoesDesign.Location = new System.Drawing.Point(12, 82);
            this.numericShoesDesign.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericShoesDesign.Name = "numericShoesDesign";
            this.numericShoesDesign.Size = new System.Drawing.Size(80, 20);
            this.numericShoesDesign.TabIndex = 10;
            this.numericShoesDesign.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericShoesDesign.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericShoesDesign.ValueChanged += new System.EventHandler(this.numericShoesDesign_ValueChanged);
            // 
            // viewer2DShoes
            // 
            this.viewer2DShoes.AutoTransparency = false;
            this.viewer2DShoes.BackColor = System.Drawing.Color.Transparent;
            this.viewer2DShoes.ButtonStripVisible = false;
            this.viewer2DShoes.CurrentBitmap = null;
            this.viewer2DShoes.ExtendedFormat = false;
            this.viewer2DShoes.FullSizeButton = false;
            this.viewer2DShoes.ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.viewer2DShoes.ImageSize = new System.Drawing.Size(128, 128);
            this.viewer2DShoes.ImageSizeMultiplier = FifaControls.Viewer2D.SizeMultiplier.Double;
            this.viewer2DShoes.Location = new System.Drawing.Point(107, 37);
            this.viewer2DShoes.Name = "viewer2DShoes";
            this.viewer2DShoes.RemoveButton = false;
            this.viewer2DShoes.ShowButton = false;
            this.viewer2DShoes.ShowButtonChecked = true;
            this.viewer2DShoes.Size = new System.Drawing.Size(128, 128);
            this.viewer2DShoes.TabIndex = 59;
            // 
            // labelShoes
            // 
            this.labelShoes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelShoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelShoes.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelShoes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelShoes.Location = new System.Drawing.Point(106, 14);
            this.labelShoes.Name = "labelShoes";
            this.labelShoes.Size = new System.Drawing.Size(131, 20);
            this.labelShoes.TabIndex = 47;
            this.labelShoes.Text = "Shoes";
            this.labelShoes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelShoes.DoubleClick += new System.EventHandler(this.labelShoes_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelPreferredPositions);
            this.groupBox1.Controls.Add(this.comboPreferredPosition4);
            this.groupBox1.Controls.Add(this.comboPreferredPosition3);
            this.groupBox1.Controls.Add(this.comboPreferredPosition2);
            this.groupBox1.Controls.Add(this.comboPreferredPosition1);
            this.groupBox1.Controls.Add(this.domainInternationalReputation);
            this.groupBox1.Controls.Add(this.labelInternationalReputation);
            this.groupBox1.Location = new System.Drawing.Point(400, 406);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 215);
            this.groupBox1.TabIndex = 89;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Playing Info";
            // 
            // labelPreferredPositions
            // 
            this.labelPreferredPositions.AutoSize = true;
            this.labelPreferredPositions.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelPreferredPositions.Location = new System.Drawing.Point(66, 12);
            this.labelPreferredPositions.Name = "labelPreferredPositions";
            this.labelPreferredPositions.Size = new System.Drawing.Size(95, 13);
            this.labelPreferredPositions.TabIndex = 157;
            this.labelPreferredPositions.Text = "Preferred Positions";
            this.labelPreferredPositions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboPreferredPosition4
            // 
            this.comboPreferredPosition4.FormattingEnabled = true;
            this.comboPreferredPosition4.Items.AddRange(new object[] {
            "None",
            "Goalkeeper",
            "Sweeper",
            "Right Wing Back",
            "Right Back",
            "Right Central Back",
            "Central Back",
            "Left Central Back",
            "Left Back",
            "Left Wing Back",
            "Right Defensive Midfielder",
            "Central Defensive Midfielder",
            "Left Defensive Midfielder",
            "Right Midfielder",
            "Right Central Midfielder",
            "Central Midfielder",
            "Left Central Midfielder",
            "Left Midfielder",
            "Right Advanced Midfielder",
            "Central Advanced Midfielder",
            "Left Advanced Midfielder",
            "Right Forward",
            "Central Forward",
            "Left Forward",
            "Right Wing",
            "Right Striker",
            "Central Striker",
            "Left Striker",
            "Left Wing"});
            this.comboPreferredPosition4.Location = new System.Drawing.Point(18, 121);
            this.comboPreferredPosition4.Name = "comboPreferredPosition4";
            this.comboPreferredPosition4.Size = new System.Drawing.Size(208, 21);
            this.comboPreferredPosition4.TabIndex = 3;
            this.comboPreferredPosition4.SelectedIndexChanged += new System.EventHandler(this.comboPreferredPosition4_SelectedIndexChanged);
            // 
            // comboPreferredPosition3
            // 
            this.comboPreferredPosition3.FormattingEnabled = true;
            this.comboPreferredPosition3.Items.AddRange(new object[] {
            "None",
            "Goalkeeper",
            "Sweeper",
            "Right Wing Back",
            "Right Back",
            "Right Central Back",
            "Central Back",
            "Left Central Back",
            "Left Back",
            "Left Wing Back",
            "Right Defensive Midfielder",
            "Central Defensive Midfielder",
            "Left Defensive Midfielder",
            "Right Midfielder",
            "Right Central Midfielder",
            "Central Midfielder",
            "Left Central Midfielder",
            "Left Midfielder",
            "Right Advanced Midfielder",
            "Central Advanced Midfielder",
            "Left Advanced Midfielder",
            "Right Forward",
            "Central Forward",
            "Left Forward",
            "Right Wing",
            "Right Striker",
            "Central Striker",
            "Left Striker",
            "Left Wing"});
            this.comboPreferredPosition3.Location = new System.Drawing.Point(17, 94);
            this.comboPreferredPosition3.Name = "comboPreferredPosition3";
            this.comboPreferredPosition3.Size = new System.Drawing.Size(208, 21);
            this.comboPreferredPosition3.TabIndex = 2;
            this.comboPreferredPosition3.SelectedIndexChanged += new System.EventHandler(this.comboPreferredPosition3_SelectedIndexChanged);
            // 
            // comboPreferredPosition2
            // 
            this.comboPreferredPosition2.FormattingEnabled = true;
            this.comboPreferredPosition2.Items.AddRange(new object[] {
            "None",
            "Goalkeeper",
            "Sweeper",
            "Right Wing Back",
            "Right Back",
            "Right Central Back",
            "Central Back",
            "Left Central Back",
            "Left Back",
            "Left Wing Back",
            "Right Defensive Midfielder",
            "Central Defensive Midfielder",
            "Left Defensive Midfielder",
            "Right Midfielder",
            "Right Central Midfielder",
            "Central Midfielder",
            "Left Central Midfielder",
            "Left Midfielder",
            "Right Advanced Midfielder",
            "Central Advanced Midfielder",
            "Left Advanced Midfielder",
            "Right Forward",
            "Central Forward",
            "Left Forward",
            "Right Wing",
            "Right Striker",
            "Central Striker",
            "Left Striker",
            "Left Wing"});
            this.comboPreferredPosition2.Location = new System.Drawing.Point(17, 67);
            this.comboPreferredPosition2.Name = "comboPreferredPosition2";
            this.comboPreferredPosition2.Size = new System.Drawing.Size(208, 21);
            this.comboPreferredPosition2.TabIndex = 1;
            this.comboPreferredPosition2.SelectedIndexChanged += new System.EventHandler(this.comboPreferredPosition2_SelectedIndexChanged);
            // 
            // comboPreferredPosition1
            // 
            this.comboPreferredPosition1.FormattingEnabled = true;
            this.comboPreferredPosition1.Items.AddRange(new object[] {
            "None",
            "Goalkeeper",
            "Sweeper",
            "Right Wing Back",
            "Right Back",
            "Right Central Back",
            "Central Back",
            "Left Central Back",
            "Left Back",
            "Left Wing Back",
            "Right Defensive Midfielder",
            "Central Defensive Midfielder",
            "Left Defensive Midfielder",
            "Right Midfielder",
            "Right Central Midfielder",
            "Central Midfielder",
            "Left Central Midfielder",
            "Left Midfielder",
            "Right Advanced Midfielder",
            "Central Advanced Midfielder",
            "Left Advanced Midfielder",
            "Right Forward",
            "Central Forward",
            "Left Forward",
            "Right Wing",
            "Right Striker",
            "Central Striker",
            "Left Striker",
            "Left Wing"});
            this.comboPreferredPosition1.Location = new System.Drawing.Point(17, 40);
            this.comboPreferredPosition1.Name = "comboPreferredPosition1";
            this.comboPreferredPosition1.Size = new System.Drawing.Size(208, 21);
            this.comboPreferredPosition1.TabIndex = 0;
            this.comboPreferredPosition1.SelectedIndexChanged += new System.EventHandler(this.comboPreferredPosition1_SelectedIndexChanged);
            // 
            // domainInternationalReputation
            // 
            this.domainInternationalReputation.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.playerBindingSource, "internationalrep", true));
            this.domainInternationalReputation.Items.Add("Poor");
            this.domainInternationalReputation.Items.Add("Medium");
            this.domainInternationalReputation.Items.Add("Good");
            this.domainInternationalReputation.Items.Add("Very Good");
            this.domainInternationalReputation.Items.Add("Superstar");
            this.domainInternationalReputation.Location = new System.Drawing.Point(107, 164);
            this.domainInternationalReputation.Name = "domainInternationalReputation";
            this.domainInternationalReputation.Size = new System.Drawing.Size(119, 20);
            this.domainInternationalReputation.TabIndex = 4;
            this.domainInternationalReputation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.domainInternationalReputation.Wrap = true;
            // 
            // labelInternationalReputation
            // 
            this.labelInternationalReputation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelInternationalReputation.Location = new System.Drawing.Point(14, 152);
            this.labelInternationalReputation.Name = "labelInternationalReputation";
            this.labelInternationalReputation.Size = new System.Drawing.Size(87, 41);
            this.labelInternationalReputation.TabIndex = 141;
            this.labelInternationalReputation.Text = "International Reputation";
            this.labelInternationalReputation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pageSkills
            // 
            this.pageSkills.Controls.Add(this.flowPanelSkills);
            this.pageSkills.ImageIndex = 1;
            this.pageSkills.Location = new System.Drawing.Point(4, 23);
            this.pageSkills.Name = "pageSkills";
            this.pageSkills.Padding = new System.Windows.Forms.Padding(3);
            this.pageSkills.Size = new System.Drawing.Size(1349, 780);
            this.pageSkills.TabIndex = 1;
            this.pageSkills.Text = "Skills";
            this.pageSkills.UseVisualStyleBackColor = true;
            // 
            // flowPanelSkills
            // 
            this.flowPanelSkills.AutoScroll = true;
            this.flowPanelSkills.Controls.Add(this.groupGenerateAttributes);
            this.flowPanelSkills.Controls.Add(this.groupGoalkeperSkills);
            this.flowPanelSkills.Controls.Add(this.groupDefensiveSkills);
            this.flowPanelSkills.Controls.Add(this.groupMidfielderSkills);
            this.flowPanelSkills.Controls.Add(this.groupMental);
            this.flowPanelSkills.Controls.Add(this.groupAttackingSkills);
            this.flowPanelSkills.Controls.Add(this.groupGenericAttributes);
            this.flowPanelSkills.Controls.Add(this.groupFreeKick);
            this.flowPanelSkills.Controls.Add(this.groupTraits);
            this.flowPanelSkills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelSkills.Location = new System.Drawing.Point(3, 3);
            this.flowPanelSkills.Name = "flowPanelSkills";
            this.flowPanelSkills.Size = new System.Drawing.Size(1343, 774);
            this.flowPanelSkills.TabIndex = 0;
            // 
            // groupGenerateAttributes
            // 
            this.groupGenerateAttributes.BackColor = System.Drawing.SystemColors.Control;
            this.groupGenerateAttributes.Controls.Add(this.labelOverallrating);
            this.groupGenerateAttributes.Controls.Add(this.trackOverallrating);
            this.groupGenerateAttributes.Controls.Add(this.labelRandomize);
            this.groupGenerateAttributes.Controls.Add(this.numericRandomize);
            this.groupGenerateAttributes.Controls.Add(this.buttonRandomAboveAvg);
            this.groupGenerateAttributes.Controls.Add(this.buttonRandomBelowAvg);
            this.groupGenerateAttributes.Controls.Add(this.buttonRandomSuperstar);
            this.groupGenerateAttributes.Controls.Add(this.buttonRandomVeryGood);
            this.groupGenerateAttributes.Controls.Add(this.buttonRandomGood);
            this.groupGenerateAttributes.Controls.Add(this.buttonRandomAverage);
            this.groupGenerateAttributes.Controls.Add(this.buttonRandomPoor);
            this.groupGenerateAttributes.Location = new System.Drawing.Point(3, 3);
            this.groupGenerateAttributes.Name = "groupGenerateAttributes";
            this.groupGenerateAttributes.Size = new System.Drawing.Size(128, 378);
            this.groupGenerateAttributes.TabIndex = 9;
            this.groupGenerateAttributes.TabStop = false;
            this.groupGenerateAttributes.Text = "Random Generation";
            // 
            // labelOverallrating
            // 
            this.labelOverallrating.BackColor = System.Drawing.SystemColors.Control;
            this.labelOverallrating.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelOverallrating.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelOverallrating.ForeColor = System.Drawing.Color.Yellow;
            this.labelOverallrating.Image = ((System.Drawing.Image)(resources.GetObject("labelOverallrating.Image")));
            this.labelOverallrating.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelOverallrating.Location = new System.Drawing.Point(10, 280);
            this.labelOverallrating.Name = "labelOverallrating";
            this.labelOverallrating.Size = new System.Drawing.Size(112, 16);
            this.labelOverallrating.TabIndex = 126;
            this.labelOverallrating.Text = "Overall ";
            this.labelOverallrating.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackOverallrating
            // 
            this.trackOverallrating.BackColor = System.Drawing.SystemColors.Control;
            this.trackOverallrating.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackOverallrating.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "overallrating", true));
            this.trackOverallrating.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackOverallrating.LargeChange = 10;
            this.trackOverallrating.Location = new System.Drawing.Point(2, 288);
            this.trackOverallrating.Maximum = 99;
            this.trackOverallrating.Minimum = 1;
            this.trackOverallrating.Name = "trackOverallrating";
            this.trackOverallrating.Size = new System.Drawing.Size(128, 45);
            this.trackOverallrating.TabIndex = 125;
            this.trackOverallrating.TickFrequency = 10;
            this.trackOverallrating.Value = 99;
            this.trackOverallrating.ValueChanged += new System.EventHandler(this.trackOverallrating_ValueChanged);
            // 
            // labelRandomize
            // 
            this.labelRandomize.Location = new System.Drawing.Point(2, 16);
            this.labelRandomize.Name = "labelRandomize";
            this.labelRandomize.Size = new System.Drawing.Size(56, 31);
            this.labelRandomize.TabIndex = 8;
            this.labelRandomize.Text = "Computed Overall";
            // 
            // numericRandomize
            // 
            this.numericRandomize.Location = new System.Drawing.Point(59, 24);
            this.numericRandomize.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericRandomize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericRandomize.Name = "numericRandomize";
            this.numericRandomize.Size = new System.Drawing.Size(53, 20);
            this.numericRandomize.TabIndex = 0;
            this.numericRandomize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericRandomize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericRandomize.ValueChanged += new System.EventHandler(this.numericOverall_ValueChanged);
            // 
            // buttonRandomAboveAvg
            // 
            this.buttonRandomAboveAvg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonRandomAboveAvg.Location = new System.Drawing.Point(11, 134);
            this.buttonRandomAboveAvg.Name = "buttonRandomAboveAvg";
            this.buttonRandomAboveAvg.Size = new System.Drawing.Size(101, 27);
            this.buttonRandomAboveAvg.TabIndex = 4;
            this.buttonRandomAboveAvg.Text = "Above Avg.";
            this.buttonRandomAboveAvg.Click += new System.EventHandler(this.buttonRandomAboveAvg_Click);
            // 
            // buttonRandomBelowAvg
            // 
            this.buttonRandomBelowAvg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonRandomBelowAvg.Location = new System.Drawing.Point(11, 78);
            this.buttonRandomBelowAvg.Name = "buttonRandomBelowAvg";
            this.buttonRandomBelowAvg.Size = new System.Drawing.Size(101, 27);
            this.buttonRandomBelowAvg.TabIndex = 2;
            this.buttonRandomBelowAvg.Text = "Below Avg.";
            this.buttonRandomBelowAvg.Click += new System.EventHandler(this.buttonRandomBelowAvg_Click);
            // 
            // buttonRandomSuperstar
            // 
            this.buttonRandomSuperstar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonRandomSuperstar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonRandomSuperstar.Location = new System.Drawing.Point(11, 219);
            this.buttonRandomSuperstar.Name = "buttonRandomSuperstar";
            this.buttonRandomSuperstar.Size = new System.Drawing.Size(101, 27);
            this.buttonRandomSuperstar.TabIndex = 7;
            this.buttonRandomSuperstar.Text = "Superstar";
            this.buttonRandomSuperstar.Click += new System.EventHandler(this.buttonRandomSuperstar_Click);
            // 
            // buttonRandomVeryGood
            // 
            this.buttonRandomVeryGood.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonRandomVeryGood.Location = new System.Drawing.Point(11, 190);
            this.buttonRandomVeryGood.Name = "buttonRandomVeryGood";
            this.buttonRandomVeryGood.Size = new System.Drawing.Size(101, 27);
            this.buttonRandomVeryGood.TabIndex = 6;
            this.buttonRandomVeryGood.Text = "Very Good";
            this.buttonRandomVeryGood.Click += new System.EventHandler(this.buttonRandomVeryGood_Click);
            // 
            // buttonRandomGood
            // 
            this.buttonRandomGood.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonRandomGood.Location = new System.Drawing.Point(11, 162);
            this.buttonRandomGood.Name = "buttonRandomGood";
            this.buttonRandomGood.Size = new System.Drawing.Size(101, 27);
            this.buttonRandomGood.TabIndex = 5;
            this.buttonRandomGood.Text = "Good";
            this.buttonRandomGood.Click += new System.EventHandler(this.buttonRandomGood_Click);
            // 
            // buttonRandomAverage
            // 
            this.buttonRandomAverage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonRandomAverage.Location = new System.Drawing.Point(11, 106);
            this.buttonRandomAverage.Name = "buttonRandomAverage";
            this.buttonRandomAverage.Size = new System.Drawing.Size(101, 27);
            this.buttonRandomAverage.TabIndex = 3;
            this.buttonRandomAverage.Text = "Average";
            this.buttonRandomAverage.Click += new System.EventHandler(this.buttonRandomAverage_Click);
            // 
            // buttonRandomPoor
            // 
            this.buttonRandomPoor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonRandomPoor.Location = new System.Drawing.Point(11, 50);
            this.buttonRandomPoor.Name = "buttonRandomPoor";
            this.buttonRandomPoor.Size = new System.Drawing.Size(101, 27);
            this.buttonRandomPoor.TabIndex = 1;
            this.buttonRandomPoor.Text = "Poor";
            this.buttonRandomPoor.Click += new System.EventHandler(this.buttonRandomPoor_Click);
            // 
            // groupGoalkeperSkills
            // 
            this.groupGoalkeperSkills.BackColor = System.Drawing.SystemColors.Control;
            this.groupGoalkeperSkills.Controls.Add(this.label5);
            this.groupGoalkeperSkills.Controls.Add(this.comboGkSaveStyle);
            this.groupGoalkeperSkills.Controls.Add(this.label3);
            this.groupGoalkeperSkills.Controls.Add(this.labelGkKick);
            this.groupGoalkeperSkills.Controls.Add(this.comboGkKickStyle);
            this.groupGoalkeperSkills.Controls.Add(this.trackGkKicking);
            this.groupGoalkeperSkills.Controls.Add(this.labelDiving);
            this.groupGoalkeperSkills.Controls.Add(this.labelPositioning);
            this.groupGoalkeperSkills.Controls.Add(this.labelReflexes);
            this.groupGoalkeperSkills.Controls.Add(this.labelHandling);
            this.groupGoalkeperSkills.Controls.Add(this.trackDiving);
            this.groupGoalkeperSkills.Controls.Add(this.trackPositioning);
            this.groupGoalkeperSkills.Controls.Add(this.trackReflexes);
            this.groupGoalkeperSkills.Controls.Add(this.trackHandling);
            this.groupGoalkeperSkills.Controls.Add(this.numericGoalkeeperSkills);
            this.groupGoalkeperSkills.Location = new System.Drawing.Point(137, 3);
            this.groupGoalkeperSkills.Name = "groupGoalkeperSkills";
            this.groupGoalkeperSkills.Size = new System.Drawing.Size(140, 378);
            this.groupGoalkeperSkills.TabIndex = 14;
            this.groupGoalkeperSkills.TabStop = false;
            this.groupGoalkeperSkills.Text = "Goalkeeper Skills";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 96;
            this.label5.Text = "Save Style";
            // 
            // comboGkSaveStyle
            // 
            this.comboGkSaveStyle.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.playerBindingSource, "gksavetype", true));
            this.comboGkSaveStyle.FormattingEnabled = true;
            this.comboGkSaveStyle.Items.AddRange(new object[] {
            "Traditional",
            "Acrobatic"});
            this.comboGkSaveStyle.Location = new System.Drawing.Point(7, 317);
            this.comboGkSaveStyle.Name = "comboGkSaveStyle";
            this.comboGkSaveStyle.Size = new System.Drawing.Size(124, 21);
            this.comboGkSaveStyle.TabIndex = 95;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "Kick Style";
            // 
            // labelGkKick
            // 
            this.labelGkKick.BackColor = System.Drawing.SystemColors.Control;
            this.labelGkKick.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelGkKick.ForeColor = System.Drawing.Color.Yellow;
            this.labelGkKick.Image = ((System.Drawing.Image)(resources.GetObject("labelGkKick.Image")));
            this.labelGkKick.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelGkKick.Location = new System.Drawing.Point(14, 232);
            this.labelGkKick.Name = "labelGkKick";
            this.labelGkKick.Size = new System.Drawing.Size(112, 16);
            this.labelGkKick.TabIndex = 94;
            this.labelGkKick.Text = "Kicking ";
            this.labelGkKick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboGkKickStyle
            // 
            this.comboGkKickStyle.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.playerBindingSource, "gkkickstyle", true));
            this.comboGkKickStyle.FormattingEnabled = true;
            this.comboGkKickStyle.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.comboGkKickStyle.Location = new System.Drawing.Point(66, 277);
            this.comboGkKickStyle.Name = "comboGkKickStyle";
            this.comboGkKickStyle.Size = new System.Drawing.Size(65, 21);
            this.comboGkKickStyle.TabIndex = 7;
            // 
            // trackGkKicking
            // 
            this.trackGkKicking.BackColor = System.Drawing.SystemColors.Control;
            this.trackGkKicking.Cursor = System.Windows.Forms.Cursors.Default;
            this.trackGkKicking.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "gkkicking", true));
            this.trackGkKicking.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackGkKicking.LargeChange = 10;
            this.trackGkKicking.Location = new System.Drawing.Point(6, 240);
            this.trackGkKicking.Maximum = 99;
            this.trackGkKicking.Minimum = 1;
            this.trackGkKicking.Name = "trackGkKicking";
            this.trackGkKicking.Size = new System.Drawing.Size(128, 45);
            this.trackGkKicking.TabIndex = 6;
            this.trackGkKicking.TickFrequency = 10;
            this.trackGkKicking.Value = 99;
            this.trackGkKicking.ValueChanged += new System.EventHandler(this.trackGkKick_ValueChanged);
            // 
            // labelDiving
            // 
            this.labelDiving.BackColor = System.Drawing.SystemColors.Control;
            this.labelDiving.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelDiving.ForeColor = System.Drawing.Color.Yellow;
            this.labelDiving.Image = ((System.Drawing.Image)(resources.GetObject("labelDiving.Image")));
            this.labelDiving.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelDiving.Location = new System.Drawing.Point(14, 136);
            this.labelDiving.Name = "labelDiving";
            this.labelDiving.Size = new System.Drawing.Size(112, 16);
            this.labelDiving.TabIndex = 88;
            this.labelDiving.Text = "Diving ";
            this.labelDiving.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPositioning
            // 
            this.labelPositioning.BackColor = System.Drawing.SystemColors.Control;
            this.labelPositioning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelPositioning.ForeColor = System.Drawing.Color.Yellow;
            this.labelPositioning.Image = ((System.Drawing.Image)(resources.GetObject("labelPositioning.Image")));
            this.labelPositioning.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelPositioning.Location = new System.Drawing.Point(14, 184);
            this.labelPositioning.Name = "labelPositioning";
            this.labelPositioning.Size = new System.Drawing.Size(112, 16);
            this.labelPositioning.TabIndex = 90;
            this.labelPositioning.Text = "Positioning ";
            this.labelPositioning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelReflexes
            // 
            this.labelReflexes.BackColor = System.Drawing.SystemColors.Control;
            this.labelReflexes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelReflexes.ForeColor = System.Drawing.Color.Yellow;
            this.labelReflexes.Image = ((System.Drawing.Image)(resources.GetObject("labelReflexes.Image")));
            this.labelReflexes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelReflexes.Location = new System.Drawing.Point(14, 40);
            this.labelReflexes.Name = "labelReflexes";
            this.labelReflexes.Size = new System.Drawing.Size(112, 16);
            this.labelReflexes.TabIndex = 84;
            this.labelReflexes.Text = "Reflexes ";
            this.labelReflexes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHandling
            // 
            this.labelHandling.BackColor = System.Drawing.SystemColors.Control;
            this.labelHandling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelHandling.ForeColor = System.Drawing.Color.Yellow;
            this.labelHandling.Image = ((System.Drawing.Image)(resources.GetObject("labelHandling.Image")));
            this.labelHandling.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelHandling.Location = new System.Drawing.Point(14, 88);
            this.labelHandling.Name = "labelHandling";
            this.labelHandling.Size = new System.Drawing.Size(112, 16);
            this.labelHandling.TabIndex = 86;
            this.labelHandling.Text = "Handling ";
            this.labelHandling.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackDiving
            // 
            this.trackDiving.BackColor = System.Drawing.SystemColors.Control;
            this.trackDiving.Cursor = System.Windows.Forms.Cursors.Default;
            this.trackDiving.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "gkdiving", true));
            this.trackDiving.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackDiving.LargeChange = 10;
            this.trackDiving.Location = new System.Drawing.Point(5, 144);
            this.trackDiving.Maximum = 99;
            this.trackDiving.Minimum = 1;
            this.trackDiving.Name = "trackDiving";
            this.trackDiving.Size = new System.Drawing.Size(128, 45);
            this.trackDiving.TabIndex = 3;
            this.trackDiving.TickFrequency = 10;
            this.trackDiving.Value = 99;
            this.trackDiving.ValueChanged += new System.EventHandler(this.trackDiving_ValueChanged);
            // 
            // trackPositioning
            // 
            this.trackPositioning.BackColor = System.Drawing.SystemColors.Control;
            this.trackPositioning.Cursor = System.Windows.Forms.Cursors.Default;
            this.trackPositioning.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "gkpositioning", true));
            this.trackPositioning.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackPositioning.LargeChange = 10;
            this.trackPositioning.Location = new System.Drawing.Point(6, 195);
            this.trackPositioning.Maximum = 99;
            this.trackPositioning.Minimum = 1;
            this.trackPositioning.Name = "trackPositioning";
            this.trackPositioning.Size = new System.Drawing.Size(128, 45);
            this.trackPositioning.TabIndex = 4;
            this.trackPositioning.TickFrequency = 10;
            this.trackPositioning.Value = 99;
            this.trackPositioning.ValueChanged += new System.EventHandler(this.trackPositioning_ValueChanged);
            // 
            // trackReflexes
            // 
            this.trackReflexes.BackColor = System.Drawing.SystemColors.Control;
            this.trackReflexes.Cursor = System.Windows.Forms.Cursors.Default;
            this.trackReflexes.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "gkreflexes", true));
            this.trackReflexes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackReflexes.LargeChange = 10;
            this.trackReflexes.Location = new System.Drawing.Point(6, 48);
            this.trackReflexes.Maximum = 99;
            this.trackReflexes.Minimum = 1;
            this.trackReflexes.Name = "trackReflexes";
            this.trackReflexes.Size = new System.Drawing.Size(128, 45);
            this.trackReflexes.TabIndex = 1;
            this.trackReflexes.TickFrequency = 10;
            this.trackReflexes.Value = 99;
            this.trackReflexes.ValueChanged += new System.EventHandler(this.trackReflexes_ValueChanged);
            // 
            // trackHandling
            // 
            this.trackHandling.BackColor = System.Drawing.SystemColors.Control;
            this.trackHandling.Cursor = System.Windows.Forms.Cursors.Default;
            this.trackHandling.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "gkhandling", true));
            this.trackHandling.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackHandling.LargeChange = 10;
            this.trackHandling.Location = new System.Drawing.Point(5, 96);
            this.trackHandling.Maximum = 99;
            this.trackHandling.Minimum = 1;
            this.trackHandling.Name = "trackHandling";
            this.trackHandling.Size = new System.Drawing.Size(128, 45);
            this.trackHandling.TabIndex = 2;
            this.trackHandling.TickFrequency = 10;
            this.trackHandling.Value = 99;
            this.trackHandling.ValueChanged += new System.EventHandler(this.trackHandling_ValueChanged);
            // 
            // numericGoalkeeperSkills
            // 
            this.numericGoalkeeperSkills.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericGoalkeeperSkills.BackColor = System.Drawing.Color.Teal;
            this.numericGoalkeeperSkills.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.numericGoalkeeperSkills.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.numericGoalkeeperSkills.Location = new System.Drawing.Point(49, 15);
            this.numericGoalkeeperSkills.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericGoalkeeperSkills.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericGoalkeeperSkills.Name = "numericGoalkeeperSkills";
            this.numericGoalkeeperSkills.Size = new System.Drawing.Size(44, 22);
            this.numericGoalkeeperSkills.TabIndex = 0;
            this.numericGoalkeeperSkills.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericGoalkeeperSkills.Value = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericGoalkeeperSkills.ValueChanged += new System.EventHandler(this.numericGoalkeeperSkills_ValueChanged);
            // 
            // groupDefensiveSkills
            // 
            this.groupDefensiveSkills.BackColor = System.Drawing.SystemColors.Control;
            this.groupDefensiveSkills.Controls.Add(this.labelInterception);
            this.groupDefensiveSkills.Controls.Add(this.trackInterception);
            this.groupDefensiveSkills.Controls.Add(this.labelSliding);
            this.groupDefensiveSkills.Controls.Add(this.trackSliding);
            this.groupDefensiveSkills.Controls.Add(this.numericDefensiveSkills);
            this.groupDefensiveSkills.Controls.Add(this.labelAggression);
            this.groupDefensiveSkills.Controls.Add(this.labelMarking);
            this.groupDefensiveSkills.Controls.Add(this.labelTackling);
            this.groupDefensiveSkills.Controls.Add(this.trackTackling);
            this.groupDefensiveSkills.Controls.Add(this.trackMarking);
            this.groupDefensiveSkills.Controls.Add(this.trackAggression);
            this.groupDefensiveSkills.Location = new System.Drawing.Point(283, 3);
            this.groupDefensiveSkills.Name = "groupDefensiveSkills";
            this.groupDefensiveSkills.Size = new System.Drawing.Size(140, 378);
            this.groupDefensiveSkills.TabIndex = 15;
            this.groupDefensiveSkills.TabStop = false;
            this.groupDefensiveSkills.Text = "Defensive Skills";
            // 
            // labelInterception
            // 
            this.labelInterception.BackColor = System.Drawing.SystemColors.Control;
            this.labelInterception.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelInterception.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelInterception.ForeColor = System.Drawing.Color.Yellow;
            this.labelInterception.Image = ((System.Drawing.Image)(resources.GetObject("labelInterception.Image")));
            this.labelInterception.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelInterception.Location = new System.Drawing.Point(16, 230);
            this.labelInterception.Name = "labelInterception";
            this.labelInterception.Size = new System.Drawing.Size(112, 16);
            this.labelInterception.TabIndex = 102;
            this.labelInterception.Text = "Interception ";
            this.labelInterception.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackInterception
            // 
            this.trackInterception.BackColor = System.Drawing.SystemColors.Control;
            this.trackInterception.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackInterception.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "interceptions", true));
            this.trackInterception.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackInterception.LargeChange = 10;
            this.trackInterception.Location = new System.Drawing.Point(6, 238);
            this.trackInterception.Maximum = 99;
            this.trackInterception.Minimum = 1;
            this.trackInterception.Name = "trackInterception";
            this.trackInterception.Size = new System.Drawing.Size(128, 45);
            this.trackInterception.TabIndex = 101;
            this.trackInterception.TickFrequency = 10;
            this.trackInterception.Value = 99;
            this.trackInterception.ValueChanged += new System.EventHandler(this.trackInterception_ValueChanged);
            // 
            // labelSliding
            // 
            this.labelSliding.BackColor = System.Drawing.SystemColors.Control;
            this.labelSliding.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelSliding.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelSliding.ForeColor = System.Drawing.Color.Yellow;
            this.labelSliding.Image = ((System.Drawing.Image)(resources.GetObject("labelSliding.Image")));
            this.labelSliding.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelSliding.Location = new System.Drawing.Point(16, 184);
            this.labelSliding.Name = "labelSliding";
            this.labelSliding.Size = new System.Drawing.Size(112, 16);
            this.labelSliding.TabIndex = 100;
            this.labelSliding.Text = "Sliding ";
            this.labelSliding.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackSliding
            // 
            this.trackSliding.BackColor = System.Drawing.SystemColors.Control;
            this.trackSliding.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackSliding.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "slidingtackle", true));
            this.trackSliding.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackSliding.LargeChange = 10;
            this.trackSliding.Location = new System.Drawing.Point(6, 192);
            this.trackSliding.Maximum = 99;
            this.trackSliding.Minimum = 1;
            this.trackSliding.Name = "trackSliding";
            this.trackSliding.Size = new System.Drawing.Size(128, 45);
            this.trackSliding.TabIndex = 4;
            this.trackSliding.TickFrequency = 10;
            this.trackSliding.Value = 99;
            this.trackSliding.ValueChanged += new System.EventHandler(this.trackSliding_ValueChanged);
            // 
            // numericDefensiveSkills
            // 
            this.numericDefensiveSkills.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericDefensiveSkills.BackColor = System.Drawing.Color.Teal;
            this.numericDefensiveSkills.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.numericDefensiveSkills.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.numericDefensiveSkills.Location = new System.Drawing.Point(48, 16);
            this.numericDefensiveSkills.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericDefensiveSkills.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericDefensiveSkills.Name = "numericDefensiveSkills";
            this.numericDefensiveSkills.Size = new System.Drawing.Size(44, 22);
            this.numericDefensiveSkills.TabIndex = 0;
            this.numericDefensiveSkills.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericDefensiveSkills.Value = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericDefensiveSkills.ValueChanged += new System.EventHandler(this.numericDefensiveSkills_ValueChanged);
            // 
            // labelAggression
            // 
            this.labelAggression.BackColor = System.Drawing.SystemColors.Control;
            this.labelAggression.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelAggression.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelAggression.ForeColor = System.Drawing.Color.Yellow;
            this.labelAggression.Image = ((System.Drawing.Image)(resources.GetObject("labelAggression.Image")));
            this.labelAggression.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelAggression.Location = new System.Drawing.Point(14, 136);
            this.labelAggression.Name = "labelAggression";
            this.labelAggression.Size = new System.Drawing.Size(112, 16);
            this.labelAggression.TabIndex = 67;
            this.labelAggression.Text = "Aggression ";
            this.labelAggression.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMarking
            // 
            this.labelMarking.BackColor = System.Drawing.SystemColors.Control;
            this.labelMarking.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelMarking.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelMarking.ForeColor = System.Drawing.Color.Yellow;
            this.labelMarking.Image = ((System.Drawing.Image)(resources.GetObject("labelMarking.Image")));
            this.labelMarking.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelMarking.Location = new System.Drawing.Point(14, 40);
            this.labelMarking.Name = "labelMarking";
            this.labelMarking.Size = new System.Drawing.Size(112, 16);
            this.labelMarking.TabIndex = 75;
            this.labelMarking.Text = "Marking ";
            this.labelMarking.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTackling
            // 
            this.labelTackling.BackColor = System.Drawing.SystemColors.Control;
            this.labelTackling.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelTackling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelTackling.ForeColor = System.Drawing.Color.Yellow;
            this.labelTackling.Image = ((System.Drawing.Image)(resources.GetObject("labelTackling.Image")));
            this.labelTackling.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelTackling.Location = new System.Drawing.Point(14, 88);
            this.labelTackling.Name = "labelTackling";
            this.labelTackling.Size = new System.Drawing.Size(112, 16);
            this.labelTackling.TabIndex = 77;
            this.labelTackling.Text = "Tackling ";
            this.labelTackling.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackTackling
            // 
            this.trackTackling.BackColor = System.Drawing.SystemColors.Control;
            this.trackTackling.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackTackling.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "standingtackle", true));
            this.trackTackling.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackTackling.LargeChange = 10;
            this.trackTackling.Location = new System.Drawing.Point(6, 96);
            this.trackTackling.Maximum = 99;
            this.trackTackling.Minimum = 1;
            this.trackTackling.Name = "trackTackling";
            this.trackTackling.Size = new System.Drawing.Size(128, 45);
            this.trackTackling.TabIndex = 2;
            this.trackTackling.TickFrequency = 10;
            this.trackTackling.Value = 99;
            this.trackTackling.ValueChanged += new System.EventHandler(this.trackTackling_ValueChanged);
            // 
            // trackMarking
            // 
            this.trackMarking.BackColor = System.Drawing.SystemColors.Control;
            this.trackMarking.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackMarking.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "marking", true));
            this.trackMarking.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackMarking.LargeChange = 10;
            this.trackMarking.Location = new System.Drawing.Point(6, 48);
            this.trackMarking.Maximum = 99;
            this.trackMarking.Minimum = 1;
            this.trackMarking.Name = "trackMarking";
            this.trackMarking.Size = new System.Drawing.Size(128, 45);
            this.trackMarking.TabIndex = 1;
            this.trackMarking.TickFrequency = 10;
            this.trackMarking.Value = 99;
            this.trackMarking.ValueChanged += new System.EventHandler(this.trackMarking_ValueChanged);
            // 
            // trackAggression
            // 
            this.trackAggression.BackColor = System.Drawing.SystemColors.Control;
            this.trackAggression.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackAggression.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "aggression", true));
            this.trackAggression.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackAggression.LargeChange = 10;
            this.trackAggression.Location = new System.Drawing.Point(6, 144);
            this.trackAggression.Maximum = 99;
            this.trackAggression.Minimum = 1;
            this.trackAggression.Name = "trackAggression";
            this.trackAggression.Size = new System.Drawing.Size(128, 45);
            this.trackAggression.TabIndex = 3;
            this.trackAggression.TickFrequency = 10;
            this.trackAggression.Value = 99;
            this.trackAggression.ValueChanged += new System.EventHandler(this.trackAggression_ValueChanged);
            // 
            // groupMidfielderSkills
            // 
            this.groupMidfielderSkills.BackColor = System.Drawing.SystemColors.Control;
            this.groupMidfielderSkills.Controls.Add(this.labelCurve);
            this.groupMidfielderSkills.Controls.Add(this.trackCurve);
            this.groupMidfielderSkills.Controls.Add(this.labelVision);
            this.groupMidfielderSkills.Controls.Add(this.trackVision);
            this.groupMidfielderSkills.Controls.Add(this.numericMidfielderSkills);
            this.groupMidfielderSkills.Controls.Add(this.labelBallControl);
            this.groupMidfielderSkills.Controls.Add(this.labelCrossing);
            this.groupMidfielderSkills.Controls.Add(this.labelLongPassing);
            this.groupMidfielderSkills.Controls.Add(this.trackLongPassing);
            this.groupMidfielderSkills.Controls.Add(this.labelShortPassing);
            this.groupMidfielderSkills.Controls.Add(this.trackShortPassing);
            this.groupMidfielderSkills.Controls.Add(this.trackBallControl);
            this.groupMidfielderSkills.Controls.Add(this.trackCrossing);
            this.groupMidfielderSkills.Location = new System.Drawing.Point(429, 3);
            this.groupMidfielderSkills.Name = "groupMidfielderSkills";
            this.groupMidfielderSkills.Size = new System.Drawing.Size(140, 378);
            this.groupMidfielderSkills.TabIndex = 16;
            this.groupMidfielderSkills.TabStop = false;
            this.groupMidfielderSkills.Text = "Midfielder Skills";
            // 
            // labelCurve
            // 
            this.labelCurve.BackColor = System.Drawing.SystemColors.Control;
            this.labelCurve.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelCurve.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelCurve.ForeColor = System.Drawing.Color.Yellow;
            this.labelCurve.Image = ((System.Drawing.Image)(resources.GetObject("labelCurve.Image")));
            this.labelCurve.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCurve.Location = new System.Drawing.Point(11, 280);
            this.labelCurve.Name = "labelCurve";
            this.labelCurve.Size = new System.Drawing.Size(112, 16);
            this.labelCurve.TabIndex = 106;
            this.labelCurve.Text = "Curve ";
            this.labelCurve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackCurve
            // 
            this.trackCurve.BackColor = System.Drawing.SystemColors.Control;
            this.trackCurve.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackCurve.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "curve", true));
            this.trackCurve.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackCurve.LargeChange = 10;
            this.trackCurve.Location = new System.Drawing.Point(1, 288);
            this.trackCurve.Maximum = 99;
            this.trackCurve.Minimum = 1;
            this.trackCurve.Name = "trackCurve";
            this.trackCurve.Size = new System.Drawing.Size(128, 45);
            this.trackCurve.TabIndex = 6;
            this.trackCurve.TickFrequency = 10;
            this.trackCurve.Value = 99;
            this.trackCurve.ValueChanged += new System.EventHandler(this.trackCurve_ValueChanged);
            // 
            // labelVision
            // 
            this.labelVision.BackColor = System.Drawing.SystemColors.Control;
            this.labelVision.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelVision.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelVision.ForeColor = System.Drawing.Color.Yellow;
            this.labelVision.Image = ((System.Drawing.Image)(resources.GetObject("labelVision.Image")));
            this.labelVision.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelVision.Location = new System.Drawing.Point(11, 232);
            this.labelVision.Name = "labelVision";
            this.labelVision.Size = new System.Drawing.Size(112, 16);
            this.labelVision.TabIndex = 104;
            this.labelVision.Text = "Vision ";
            this.labelVision.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackVision
            // 
            this.trackVision.BackColor = System.Drawing.SystemColors.Control;
            this.trackVision.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackVision.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "vision", true));
            this.trackVision.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackVision.LargeChange = 10;
            this.trackVision.Location = new System.Drawing.Point(1, 240);
            this.trackVision.Maximum = 99;
            this.trackVision.Minimum = 1;
            this.trackVision.Name = "trackVision";
            this.trackVision.Size = new System.Drawing.Size(128, 45);
            this.trackVision.TabIndex = 5;
            this.trackVision.TickFrequency = 10;
            this.trackVision.Value = 99;
            this.trackVision.ValueChanged += new System.EventHandler(this.trackVision_ValueChanged);
            // 
            // numericMidfielderSkills
            // 
            this.numericMidfielderSkills.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericMidfielderSkills.BackColor = System.Drawing.Color.Teal;
            this.numericMidfielderSkills.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.numericMidfielderSkills.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.numericMidfielderSkills.Location = new System.Drawing.Point(41, 15);
            this.numericMidfielderSkills.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericMidfielderSkills.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericMidfielderSkills.Name = "numericMidfielderSkills";
            this.numericMidfielderSkills.Size = new System.Drawing.Size(44, 22);
            this.numericMidfielderSkills.TabIndex = 0;
            this.numericMidfielderSkills.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericMidfielderSkills.Value = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericMidfielderSkills.ValueChanged += new System.EventHandler(this.numericMidfielderSkills_ValueChanged);
            // 
            // labelBallControl
            // 
            this.labelBallControl.BackColor = System.Drawing.SystemColors.Control;
            this.labelBallControl.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelBallControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelBallControl.ForeColor = System.Drawing.Color.Yellow;
            this.labelBallControl.Image = ((System.Drawing.Image)(resources.GetObject("labelBallControl.Image")));
            this.labelBallControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelBallControl.Location = new System.Drawing.Point(11, 184);
            this.labelBallControl.Name = "labelBallControl";
            this.labelBallControl.Size = new System.Drawing.Size(112, 16);
            this.labelBallControl.TabIndex = 79;
            this.labelBallControl.Text = "Ball-Control ";
            this.labelBallControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCrossing
            // 
            this.labelCrossing.BackColor = System.Drawing.SystemColors.Control;
            this.labelCrossing.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelCrossing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelCrossing.ForeColor = System.Drawing.Color.Yellow;
            this.labelCrossing.Image = ((System.Drawing.Image)(resources.GetObject("labelCrossing.Image")));
            this.labelCrossing.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCrossing.Location = new System.Drawing.Point(9, 136);
            this.labelCrossing.Name = "labelCrossing";
            this.labelCrossing.Size = new System.Drawing.Size(112, 16);
            this.labelCrossing.TabIndex = 84;
            this.labelCrossing.Text = "Crossing ";
            this.labelCrossing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLongPassing
            // 
            this.labelLongPassing.BackColor = System.Drawing.SystemColors.Control;
            this.labelLongPassing.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelLongPassing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelLongPassing.ForeColor = System.Drawing.Color.Yellow;
            this.labelLongPassing.Image = ((System.Drawing.Image)(resources.GetObject("labelLongPassing.Image")));
            this.labelLongPassing.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelLongPassing.Location = new System.Drawing.Point(9, 88);
            this.labelLongPassing.Name = "labelLongPassing";
            this.labelLongPassing.Size = new System.Drawing.Size(112, 16);
            this.labelLongPassing.TabIndex = 102;
            this.labelLongPassing.Text = "Long-Passing ";
            this.labelLongPassing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackLongPassing
            // 
            this.trackLongPassing.BackColor = System.Drawing.SystemColors.Control;
            this.trackLongPassing.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackLongPassing.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "longpassing", true));
            this.trackLongPassing.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackLongPassing.LargeChange = 10;
            this.trackLongPassing.Location = new System.Drawing.Point(1, 96);
            this.trackLongPassing.Maximum = 99;
            this.trackLongPassing.Minimum = 1;
            this.trackLongPassing.Name = "trackLongPassing";
            this.trackLongPassing.Size = new System.Drawing.Size(128, 45);
            this.trackLongPassing.TabIndex = 2;
            this.trackLongPassing.TickFrequency = 10;
            this.trackLongPassing.Value = 99;
            this.trackLongPassing.ValueChanged += new System.EventHandler(this.trackLongPassing_ValueChanged);
            // 
            // labelShortPassing
            // 
            this.labelShortPassing.BackColor = System.Drawing.SystemColors.Control;
            this.labelShortPassing.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelShortPassing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelShortPassing.ForeColor = System.Drawing.Color.Yellow;
            this.labelShortPassing.Image = ((System.Drawing.Image)(resources.GetObject("labelShortPassing.Image")));
            this.labelShortPassing.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelShortPassing.Location = new System.Drawing.Point(9, 40);
            this.labelShortPassing.Name = "labelShortPassing";
            this.labelShortPassing.Size = new System.Drawing.Size(112, 16);
            this.labelShortPassing.TabIndex = 100;
            this.labelShortPassing.Text = "Short-Passing ";
            this.labelShortPassing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackShortPassing
            // 
            this.trackShortPassing.BackColor = System.Drawing.SystemColors.Control;
            this.trackShortPassing.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackShortPassing.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "shortpassing", true));
            this.trackShortPassing.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackShortPassing.LargeChange = 10;
            this.trackShortPassing.Location = new System.Drawing.Point(1, 48);
            this.trackShortPassing.Maximum = 99;
            this.trackShortPassing.Minimum = 1;
            this.trackShortPassing.Name = "trackShortPassing";
            this.trackShortPassing.Size = new System.Drawing.Size(128, 45);
            this.trackShortPassing.TabIndex = 1;
            this.trackShortPassing.TickFrequency = 10;
            this.trackShortPassing.Value = 99;
            this.trackShortPassing.ValueChanged += new System.EventHandler(this.trackShortPassing_ValueChanged);
            // 
            // trackBallControl
            // 
            this.trackBallControl.BackColor = System.Drawing.SystemColors.Control;
            this.trackBallControl.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackBallControl.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "ballcontrol", true));
            this.trackBallControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackBallControl.LargeChange = 10;
            this.trackBallControl.Location = new System.Drawing.Point(1, 192);
            this.trackBallControl.Maximum = 99;
            this.trackBallControl.Minimum = 1;
            this.trackBallControl.Name = "trackBallControl";
            this.trackBallControl.Size = new System.Drawing.Size(128, 45);
            this.trackBallControl.TabIndex = 4;
            this.trackBallControl.TickFrequency = 10;
            this.trackBallControl.Value = 99;
            this.trackBallControl.ValueChanged += new System.EventHandler(this.trackBallControl_ValueChanged);
            // 
            // trackCrossing
            // 
            this.trackCrossing.BackColor = System.Drawing.SystemColors.Control;
            this.trackCrossing.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackCrossing.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "crossing", true));
            this.trackCrossing.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackCrossing.LargeChange = 10;
            this.trackCrossing.Location = new System.Drawing.Point(1, 144);
            this.trackCrossing.Maximum = 99;
            this.trackCrossing.Minimum = 1;
            this.trackCrossing.Name = "trackCrossing";
            this.trackCrossing.Size = new System.Drawing.Size(128, 45);
            this.trackCrossing.TabIndex = 3;
            this.trackCrossing.TickFrequency = 10;
            this.trackCrossing.Value = 99;
            this.trackCrossing.ValueChanged += new System.EventHandler(this.trackCrossing_ValueChanged);
            // 
            // groupMental
            // 
            this.groupMental.BackColor = System.Drawing.SystemColors.Control;
            this.groupMental.Controls.Add(this.numericEmotion);
            this.groupMental.Controls.Add(this.label13);
            this.groupMental.Controls.Add(this.comboDefensiveWorkrate);
            this.groupMental.Controls.Add(this.label10);
            this.groupMental.Controls.Add(this.comboAttackWorkRate);
            this.groupMental.Controls.Add(this.label9);
            this.groupMental.Controls.Add(this.numericMentalSkills);
            this.groupMental.Controls.Add(this.labelPlayerPositioning);
            this.groupMental.Controls.Add(this.labelPotential);
            this.groupMental.Controls.Add(this.trackPlayerPositioning);
            this.groupMental.Controls.Add(this.trackPotential);
            this.groupMental.Location = new System.Drawing.Point(575, 3);
            this.groupMental.Name = "groupMental";
            this.groupMental.Size = new System.Drawing.Size(140, 378);
            this.groupMental.TabIndex = 26;
            this.groupMental.TabStop = false;
            this.groupMental.Text = "Mental Skills";
            // 
            // numericEmotion
            // 
            this.numericEmotion.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "emotion", true));
            this.numericEmotion.Location = new System.Drawing.Point(69, 235);
            this.numericEmotion.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericEmotion.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericEmotion.Name = "numericEmotion";
            this.numericEmotion.Size = new System.Drawing.Size(43, 20);
            this.numericEmotion.TabIndex = 155;
            this.numericEmotion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericEmotion.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 238);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 13);
            this.label13.TabIndex = 156;
            this.label13.Text = "Emotion";
            // 
            // comboDefensiveWorkrate
            // 
            this.comboDefensiveWorkrate.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.playerBindingSource, "defensiveworkrate", true));
            this.comboDefensiveWorkrate.FormattingEnabled = true;
            this.comboDefensiveWorkrate.Items.AddRange(new object[] {
            "Medium",
            "Low",
            "High"});
            this.comboDefensiveWorkrate.Location = new System.Drawing.Point(12, 190);
            this.comboDefensiveWorkrate.Name = "comboDefensiveWorkrate";
            this.comboDefensiveWorkrate.Size = new System.Drawing.Size(103, 21);
            this.comboDefensiveWorkrate.TabIndex = 135;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(13, 174);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 13);
            this.label10.TabIndex = 136;
            this.label10.Text = "Defensive Workrate";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboAttackWorkRate
            // 
            this.comboAttackWorkRate.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.playerBindingSource, "attackingworkrate", true));
            this.comboAttackWorkRate.FormattingEnabled = true;
            this.comboAttackWorkRate.Items.AddRange(new object[] {
            "Medium",
            "Low",
            "High"});
            this.comboAttackWorkRate.Location = new System.Drawing.Point(12, 145);
            this.comboAttackWorkRate.Name = "comboAttackWorkRate";
            this.comboAttackWorkRate.Size = new System.Drawing.Size(103, 21);
            this.comboAttackWorkRate.TabIndex = 133;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(15, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 134;
            this.label9.Text = "Attacking Workrate";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericMentalSkills
            // 
            this.numericMentalSkills.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericMentalSkills.BackColor = System.Drawing.Color.Teal;
            this.numericMentalSkills.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.numericMentalSkills.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.numericMentalSkills.Location = new System.Drawing.Point(44, 13);
            this.numericMentalSkills.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericMentalSkills.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericMentalSkills.Name = "numericMentalSkills";
            this.numericMentalSkills.Size = new System.Drawing.Size(44, 22);
            this.numericMentalSkills.TabIndex = 0;
            this.numericMentalSkills.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericMentalSkills.Value = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericMentalSkills.ValueChanged += new System.EventHandler(this.numericMentalSkills_ValueChanged);
            // 
            // labelPlayerPositioning
            // 
            this.labelPlayerPositioning.BackColor = System.Drawing.SystemColors.Control;
            this.labelPlayerPositioning.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelPlayerPositioning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelPlayerPositioning.ForeColor = System.Drawing.Color.Yellow;
            this.labelPlayerPositioning.Image = ((System.Drawing.Image)(resources.GetObject("labelPlayerPositioning.Image")));
            this.labelPlayerPositioning.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelPlayerPositioning.Location = new System.Drawing.Point(16, 86);
            this.labelPlayerPositioning.Name = "labelPlayerPositioning";
            this.labelPlayerPositioning.Size = new System.Drawing.Size(112, 16);
            this.labelPlayerPositioning.TabIndex = 120;
            this.labelPlayerPositioning.Text = "Positioning ";
            this.labelPlayerPositioning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPotential
            // 
            this.labelPotential.BackColor = System.Drawing.SystemColors.Control;
            this.labelPotential.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelPotential.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelPotential.ForeColor = System.Drawing.Color.Yellow;
            this.labelPotential.Image = ((System.Drawing.Image)(resources.GetObject("labelPotential.Image")));
            this.labelPotential.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelPotential.Location = new System.Drawing.Point(16, 38);
            this.labelPotential.Name = "labelPotential";
            this.labelPotential.Size = new System.Drawing.Size(112, 16);
            this.labelPotential.TabIndex = 118;
            this.labelPotential.Text = "Potential ";
            this.labelPotential.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackPlayerPositioning
            // 
            this.trackPlayerPositioning.BackColor = System.Drawing.SystemColors.Control;
            this.trackPlayerPositioning.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackPlayerPositioning.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "positioning", true));
            this.trackPlayerPositioning.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackPlayerPositioning.LargeChange = 10;
            this.trackPlayerPositioning.Location = new System.Drawing.Point(8, 94);
            this.trackPlayerPositioning.Maximum = 99;
            this.trackPlayerPositioning.Minimum = 1;
            this.trackPlayerPositioning.Name = "trackPlayerPositioning";
            this.trackPlayerPositioning.Size = new System.Drawing.Size(128, 45);
            this.trackPlayerPositioning.TabIndex = 3;
            this.trackPlayerPositioning.TickFrequency = 10;
            this.trackPlayerPositioning.Value = 99;
            this.trackPlayerPositioning.ValueChanged += new System.EventHandler(this.trackPlayerPositioning_ValueChanged);
            // 
            // trackPotential
            // 
            this.trackPotential.BackColor = System.Drawing.SystemColors.Control;
            this.trackPotential.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackPotential.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "potential", true));
            this.trackPotential.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackPotential.LargeChange = 10;
            this.trackPotential.Location = new System.Drawing.Point(8, 46);
            this.trackPotential.Maximum = 99;
            this.trackPotential.Minimum = 1;
            this.trackPotential.Name = "trackPotential";
            this.trackPotential.Size = new System.Drawing.Size(128, 45);
            this.trackPotential.TabIndex = 1;
            this.trackPotential.TickFrequency = 10;
            this.trackPotential.Value = 99;
            this.trackPotential.ValueChanged += new System.EventHandler(this.trackPotential_ValueChanged);
            // 
            // groupAttackingSkills
            // 
            this.groupAttackingSkills.BackColor = System.Drawing.SystemColors.Control;
            this.groupAttackingSkills.Controls.Add(this.labelFinishing);
            this.groupAttackingSkills.Controls.Add(this.label6);
            this.groupAttackingSkills.Controls.Add(this.numericUpDown2);
            this.groupAttackingSkills.Controls.Add(this.numericUpDown1);
            this.groupAttackingSkills.Controls.Add(this.labelHeading);
            this.groupAttackingSkills.Controls.Add(this.trackHeading);
            this.groupAttackingSkills.Controls.Add(this.labelVolley);
            this.groupAttackingSkills.Controls.Add(this.trackVolley);
            this.groupAttackingSkills.Controls.Add(this.numericAttackingSkills);
            this.groupAttackingSkills.Controls.Add(this.labelDribbling);
            this.groupAttackingSkills.Controls.Add(this.labelLongShot);
            this.groupAttackingSkills.Controls.Add(this.labelShotPower);
            this.groupAttackingSkills.Controls.Add(this.trackFinishing);
            this.groupAttackingSkills.Controls.Add(this.trackShotPower);
            this.groupAttackingSkills.Controls.Add(this.trackLongShot);
            this.groupAttackingSkills.Controls.Add(this.trackDribbling);
            this.groupAttackingSkills.Location = new System.Drawing.Point(721, 3);
            this.groupAttackingSkills.Name = "groupAttackingSkills";
            this.groupAttackingSkills.Size = new System.Drawing.Size(140, 378);
            this.groupAttackingSkills.TabIndex = 17;
            this.groupAttackingSkills.TabStop = false;
            this.groupAttackingSkills.Text = "Attacking Skills";
            // 
            // labelFinishing
            // 
            this.labelFinishing.BackColor = System.Drawing.SystemColors.Control;
            this.labelFinishing.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelFinishing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelFinishing.ForeColor = System.Drawing.Color.Yellow;
            this.labelFinishing.Image = ((System.Drawing.Image)(resources.GetObject("labelFinishing.Image")));
            this.labelFinishing.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelFinishing.Location = new System.Drawing.Point(14, 280);
            this.labelFinishing.Name = "labelFinishing";
            this.labelFinishing.Size = new System.Drawing.Size(112, 16);
            this.labelFinishing.TabIndex = 106;
            this.labelFinishing.Text = "Finishing ";
            this.labelFinishing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 327);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 121;
            this.label6.Text = "Finishing Styles";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "finishingcode2", true));
            this.numericUpDown2.Location = new System.Drawing.Point(74, 348);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown2.TabIndex = 120;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "finishingcode1", true));
            this.numericUpDown1.Location = new System.Drawing.Point(10, 348);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown1.TabIndex = 119;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelHeading
            // 
            this.labelHeading.BackColor = System.Drawing.SystemColors.Control;
            this.labelHeading.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelHeading.ForeColor = System.Drawing.Color.Yellow;
            this.labelHeading.Image = ((System.Drawing.Image)(resources.GetObject("labelHeading.Image")));
            this.labelHeading.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelHeading.Location = new System.Drawing.Point(14, 230);
            this.labelHeading.Name = "labelHeading";
            this.labelHeading.Size = new System.Drawing.Size(112, 16);
            this.labelHeading.TabIndex = 98;
            this.labelHeading.Text = "Heading ";
            this.labelHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackHeading
            // 
            this.trackHeading.BackColor = System.Drawing.SystemColors.Control;
            this.trackHeading.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackHeading.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "headingaccuracy", true));
            this.trackHeading.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackHeading.LargeChange = 10;
            this.trackHeading.Location = new System.Drawing.Point(6, 238);
            this.trackHeading.Maximum = 99;
            this.trackHeading.Minimum = 1;
            this.trackHeading.Name = "trackHeading";
            this.trackHeading.Size = new System.Drawing.Size(128, 45);
            this.trackHeading.TabIndex = 7;
            this.trackHeading.TickFrequency = 10;
            this.trackHeading.Value = 99;
            this.trackHeading.ValueChanged += new System.EventHandler(this.trackHeading_ValueChanged);
            // 
            // labelVolley
            // 
            this.labelVolley.BackColor = System.Drawing.SystemColors.Control;
            this.labelVolley.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelVolley.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelVolley.ForeColor = System.Drawing.Color.Yellow;
            this.labelVolley.Image = ((System.Drawing.Image)(resources.GetObject("labelVolley.Image")));
            this.labelVolley.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelVolley.Location = new System.Drawing.Point(14, 182);
            this.labelVolley.Name = "labelVolley";
            this.labelVolley.Size = new System.Drawing.Size(112, 16);
            this.labelVolley.TabIndex = 118;
            this.labelVolley.Text = "Volley ";
            this.labelVolley.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackVolley
            // 
            this.trackVolley.BackColor = System.Drawing.SystemColors.Control;
            this.trackVolley.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackVolley.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "volleys", true));
            this.trackVolley.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackVolley.LargeChange = 10;
            this.trackVolley.Location = new System.Drawing.Point(6, 190);
            this.trackVolley.Maximum = 99;
            this.trackVolley.Minimum = 1;
            this.trackVolley.Name = "trackVolley";
            this.trackVolley.Size = new System.Drawing.Size(128, 45);
            this.trackVolley.TabIndex = 6;
            this.trackVolley.TickFrequency = 10;
            this.trackVolley.Value = 99;
            this.trackVolley.ValueChanged += new System.EventHandler(this.trackVolley_ValueChanged);
            // 
            // numericAttackingSkills
            // 
            this.numericAttackingSkills.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericAttackingSkills.BackColor = System.Drawing.Color.Teal;
            this.numericAttackingSkills.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.numericAttackingSkills.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.numericAttackingSkills.Location = new System.Drawing.Point(43, 15);
            this.numericAttackingSkills.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericAttackingSkills.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericAttackingSkills.Name = "numericAttackingSkills";
            this.numericAttackingSkills.Size = new System.Drawing.Size(44, 22);
            this.numericAttackingSkills.TabIndex = 0;
            this.numericAttackingSkills.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericAttackingSkills.Value = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericAttackingSkills.ValueChanged += new System.EventHandler(this.numericAttackingSkills_ValueChanged);
            // 
            // labelDribbling
            // 
            this.labelDribbling.BackColor = System.Drawing.SystemColors.Control;
            this.labelDribbling.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelDribbling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelDribbling.ForeColor = System.Drawing.Color.Yellow;
            this.labelDribbling.Image = ((System.Drawing.Image)(resources.GetObject("labelDribbling.Image")));
            this.labelDribbling.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelDribbling.Location = new System.Drawing.Point(14, 136);
            this.labelDribbling.Name = "labelDribbling";
            this.labelDribbling.Size = new System.Drawing.Size(112, 16);
            this.labelDribbling.TabIndex = 82;
            this.labelDribbling.Text = "Dribbling ";
            this.labelDribbling.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLongShot
            // 
            this.labelLongShot.BackColor = System.Drawing.SystemColors.Control;
            this.labelLongShot.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelLongShot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelLongShot.ForeColor = System.Drawing.Color.Yellow;
            this.labelLongShot.Image = ((System.Drawing.Image)(resources.GetObject("labelLongShot.Image")));
            this.labelLongShot.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelLongShot.Location = new System.Drawing.Point(14, 88);
            this.labelLongShot.Name = "labelLongShot";
            this.labelLongShot.Size = new System.Drawing.Size(112, 16);
            this.labelLongShot.TabIndex = 104;
            this.labelLongShot.Text = "Long-Shot ";
            this.labelLongShot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelShotPower
            // 
            this.labelShotPower.BackColor = System.Drawing.SystemColors.Control;
            this.labelShotPower.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelShotPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelShotPower.ForeColor = System.Drawing.Color.Yellow;
            this.labelShotPower.Image = ((System.Drawing.Image)(resources.GetObject("labelShotPower.Image")));
            this.labelShotPower.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelShotPower.Location = new System.Drawing.Point(14, 40);
            this.labelShotPower.Name = "labelShotPower";
            this.labelShotPower.Size = new System.Drawing.Size(112, 16);
            this.labelShotPower.TabIndex = 108;
            this.labelShotPower.Text = "Shot-Power ";
            this.labelShotPower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackFinishing
            // 
            this.trackFinishing.BackColor = System.Drawing.SystemColors.Control;
            this.trackFinishing.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackFinishing.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "finishing", true));
            this.trackFinishing.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackFinishing.LargeChange = 10;
            this.trackFinishing.Location = new System.Drawing.Point(6, 288);
            this.trackFinishing.Maximum = 99;
            this.trackFinishing.Minimum = 1;
            this.trackFinishing.Name = "trackFinishing";
            this.trackFinishing.Size = new System.Drawing.Size(128, 45);
            this.trackFinishing.TabIndex = 1;
            this.trackFinishing.TickFrequency = 10;
            this.trackFinishing.Value = 99;
            this.trackFinishing.ValueChanged += new System.EventHandler(this.trackFinishing_ValueChanged);
            // 
            // trackShotPower
            // 
            this.trackShotPower.BackColor = System.Drawing.SystemColors.Control;
            this.trackShotPower.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackShotPower.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "shotpower", true));
            this.trackShotPower.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackShotPower.LargeChange = 10;
            this.trackShotPower.Location = new System.Drawing.Point(6, 48);
            this.trackShotPower.Maximum = 99;
            this.trackShotPower.Minimum = 1;
            this.trackShotPower.Name = "trackShotPower";
            this.trackShotPower.Size = new System.Drawing.Size(128, 45);
            this.trackShotPower.TabIndex = 2;
            this.trackShotPower.TickFrequency = 10;
            this.trackShotPower.Value = 99;
            this.trackShotPower.ValueChanged += new System.EventHandler(this.trackShotPower_ValueChanged);
            // 
            // trackLongShot
            // 
            this.trackLongShot.BackColor = System.Drawing.SystemColors.Control;
            this.trackLongShot.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackLongShot.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "longshots", true));
            this.trackLongShot.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackLongShot.LargeChange = 10;
            this.trackLongShot.Location = new System.Drawing.Point(6, 96);
            this.trackLongShot.Maximum = 99;
            this.trackLongShot.Minimum = 1;
            this.trackLongShot.Name = "trackLongShot";
            this.trackLongShot.Size = new System.Drawing.Size(128, 45);
            this.trackLongShot.TabIndex = 3;
            this.trackLongShot.TickFrequency = 10;
            this.trackLongShot.Value = 99;
            this.trackLongShot.ValueChanged += new System.EventHandler(this.trackLongShot_ValueChanged);
            // 
            // trackDribbling
            // 
            this.trackDribbling.BackColor = System.Drawing.SystemColors.Control;
            this.trackDribbling.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackDribbling.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "dribbling", true));
            this.trackDribbling.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackDribbling.LargeChange = 10;
            this.trackDribbling.Location = new System.Drawing.Point(6, 144);
            this.trackDribbling.Maximum = 99;
            this.trackDribbling.Minimum = 1;
            this.trackDribbling.Name = "trackDribbling";
            this.trackDribbling.Size = new System.Drawing.Size(128, 45);
            this.trackDribbling.TabIndex = 4;
            this.trackDribbling.TickFrequency = 10;
            this.trackDribbling.Value = 99;
            this.trackDribbling.ValueChanged += new System.EventHandler(this.trackDribbling_ValueChanged);
            // 
            // groupGenericAttributes
            // 
            this.groupGenericAttributes.BackColor = System.Drawing.SystemColors.Control;
            this.groupGenericAttributes.Controls.Add(this.label7);
            this.groupGenericAttributes.Controls.Add(this.numericUpDown3);
            this.groupGenericAttributes.Controls.Add(this.numericUpDown4);
            this.groupGenericAttributes.Controls.Add(this.labelJumping);
            this.groupGenericAttributes.Controls.Add(this.labelBalance);
            this.groupGenericAttributes.Controls.Add(this.trackBalance);
            this.groupGenericAttributes.Controls.Add(this.labelAgility);
            this.groupGenericAttributes.Controls.Add(this.trackAgility);
            this.groupGenericAttributes.Controls.Add(this.numericPhysicalSkills);
            this.groupGenericAttributes.Controls.Add(this.labelReactions);
            this.groupGenericAttributes.Controls.Add(this.labelStrength);
            this.groupGenericAttributes.Controls.Add(this.labelStamina);
            this.groupGenericAttributes.Controls.Add(this.trackStamina);
            this.groupGenericAttributes.Controls.Add(this.labelSprintSpeed);
            this.groupGenericAttributes.Controls.Add(this.trackSprintSpeed);
            this.groupGenericAttributes.Controls.Add(this.labelAcceleration);
            this.groupGenericAttributes.Controls.Add(this.trackAcceleration);
            this.groupGenericAttributes.Controls.Add(this.trackStrength);
            this.groupGenericAttributes.Controls.Add(this.trackReactions);
            this.groupGenericAttributes.Controls.Add(this.trackJumping);
            this.groupGenericAttributes.Location = new System.Drawing.Point(867, 3);
            this.groupGenericAttributes.Name = "groupGenericAttributes";
            this.groupGenericAttributes.Size = new System.Drawing.Size(268, 378);
            this.groupGenericAttributes.TabIndex = 18;
            this.groupGenericAttributes.TabStop = false;
            this.groupGenericAttributes.Text = "Physical Skills";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 327);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 133;
            this.label7.Text = "Running Styles";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "runningcode2", true));
            this.numericUpDown3.Location = new System.Drawing.Point(73, 348);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown3.TabIndex = 132;
            this.numericUpDown3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "runningcode1", true));
            this.numericUpDown4.Location = new System.Drawing.Point(9, 348);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown4.TabIndex = 131;
            this.numericUpDown4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelJumping
            // 
            this.labelJumping.BackColor = System.Drawing.SystemColors.Control;
            this.labelJumping.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelJumping.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelJumping.ForeColor = System.Drawing.Color.Yellow;
            this.labelJumping.Image = ((System.Drawing.Image)(resources.GetObject("labelJumping.Image")));
            this.labelJumping.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelJumping.Location = new System.Drawing.Point(12, 280);
            this.labelJumping.Name = "labelJumping";
            this.labelJumping.Size = new System.Drawing.Size(112, 16);
            this.labelJumping.TabIndex = 130;
            this.labelJumping.Text = "Jumping ";
            this.labelJumping.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBalance
            // 
            this.labelBalance.BackColor = System.Drawing.SystemColors.Control;
            this.labelBalance.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelBalance.ForeColor = System.Drawing.Color.Yellow;
            this.labelBalance.Image = ((System.Drawing.Image)(resources.GetObject("labelBalance.Image")));
            this.labelBalance.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelBalance.Location = new System.Drawing.Point(148, 86);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(112, 16);
            this.labelBalance.TabIndex = 128;
            this.labelBalance.Text = "Balance ";
            this.labelBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBalance
            // 
            this.trackBalance.BackColor = System.Drawing.SystemColors.Control;
            this.trackBalance.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackBalance.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "balance", true));
            this.trackBalance.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackBalance.LargeChange = 10;
            this.trackBalance.Location = new System.Drawing.Point(140, 94);
            this.trackBalance.Maximum = 99;
            this.trackBalance.Minimum = 1;
            this.trackBalance.Name = "trackBalance";
            this.trackBalance.Size = new System.Drawing.Size(128, 45);
            this.trackBalance.TabIndex = 8;
            this.trackBalance.TickFrequency = 10;
            this.trackBalance.Value = 99;
            this.trackBalance.ValueChanged += new System.EventHandler(this.trackBalance_ValueChanged);
            // 
            // labelAgility
            // 
            this.labelAgility.BackColor = System.Drawing.SystemColors.Control;
            this.labelAgility.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelAgility.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelAgility.ForeColor = System.Drawing.Color.Yellow;
            this.labelAgility.Image = ((System.Drawing.Image)(resources.GetObject("labelAgility.Image")));
            this.labelAgility.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelAgility.Location = new System.Drawing.Point(12, 232);
            this.labelAgility.Name = "labelAgility";
            this.labelAgility.Size = new System.Drawing.Size(112, 16);
            this.labelAgility.TabIndex = 126;
            this.labelAgility.Text = "Agility ";
            this.labelAgility.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackAgility
            // 
            this.trackAgility.BackColor = System.Drawing.SystemColors.Control;
            this.trackAgility.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackAgility.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "agility", true));
            this.trackAgility.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackAgility.LargeChange = 10;
            this.trackAgility.Location = new System.Drawing.Point(4, 240);
            this.trackAgility.Maximum = 99;
            this.trackAgility.Minimum = 1;
            this.trackAgility.Name = "trackAgility";
            this.trackAgility.Size = new System.Drawing.Size(128, 45);
            this.trackAgility.TabIndex = 5;
            this.trackAgility.TickFrequency = 10;
            this.trackAgility.Value = 99;
            this.trackAgility.ValueChanged += new System.EventHandler(this.trackAgility_ValueChanged);
            // 
            // numericPhysicalSkills
            // 
            this.numericPhysicalSkills.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericPhysicalSkills.BackColor = System.Drawing.Color.Teal;
            this.numericPhysicalSkills.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.numericPhysicalSkills.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.numericPhysicalSkills.Location = new System.Drawing.Point(114, 15);
            this.numericPhysicalSkills.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericPhysicalSkills.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericPhysicalSkills.Name = "numericPhysicalSkills";
            this.numericPhysicalSkills.Size = new System.Drawing.Size(44, 22);
            this.numericPhysicalSkills.TabIndex = 0;
            this.numericPhysicalSkills.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericPhysicalSkills.Value = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericPhysicalSkills.ValueChanged += new System.EventHandler(this.numericGenericSkills_ValueChanged);
            // 
            // labelReactions
            // 
            this.labelReactions.BackColor = System.Drawing.SystemColors.Control;
            this.labelReactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelReactions.ForeColor = System.Drawing.Color.Yellow;
            this.labelReactions.Image = ((System.Drawing.Image)(resources.GetObject("labelReactions.Image")));
            this.labelReactions.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelReactions.Location = new System.Drawing.Point(148, 40);
            this.labelReactions.Name = "labelReactions";
            this.labelReactions.Size = new System.Drawing.Size(112, 16);
            this.labelReactions.TabIndex = 82;
            this.labelReactions.Text = "Reactions ";
            this.labelReactions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStrength
            // 
            this.labelStrength.BackColor = System.Drawing.SystemColors.Control;
            this.labelStrength.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelStrength.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelStrength.ForeColor = System.Drawing.Color.Yellow;
            this.labelStrength.Image = ((System.Drawing.Image)(resources.GetObject("labelStrength.Image")));
            this.labelStrength.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelStrength.Location = new System.Drawing.Point(12, 184);
            this.labelStrength.Name = "labelStrength";
            this.labelStrength.Size = new System.Drawing.Size(112, 16);
            this.labelStrength.TabIndex = 73;
            this.labelStrength.Text = "Strength ";
            this.labelStrength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStamina
            // 
            this.labelStamina.BackColor = System.Drawing.SystemColors.Control;
            this.labelStamina.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelStamina.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelStamina.ForeColor = System.Drawing.Color.Yellow;
            this.labelStamina.Image = ((System.Drawing.Image)(resources.GetObject("labelStamina.Image")));
            this.labelStamina.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelStamina.Location = new System.Drawing.Point(12, 134);
            this.labelStamina.Name = "labelStamina";
            this.labelStamina.Size = new System.Drawing.Size(112, 16);
            this.labelStamina.TabIndex = 71;
            this.labelStamina.Text = "Stamina ";
            this.labelStamina.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackStamina
            // 
            this.trackStamina.BackColor = System.Drawing.SystemColors.Control;
            this.trackStamina.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackStamina.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "stamina", true));
            this.trackStamina.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackStamina.LargeChange = 10;
            this.trackStamina.Location = new System.Drawing.Point(4, 142);
            this.trackStamina.Maximum = 99;
            this.trackStamina.Minimum = 1;
            this.trackStamina.Name = "trackStamina";
            this.trackStamina.Size = new System.Drawing.Size(128, 45);
            this.trackStamina.TabIndex = 3;
            this.trackStamina.TickFrequency = 10;
            this.trackStamina.Value = 99;
            this.trackStamina.ValueChanged += new System.EventHandler(this.trackStamina_ValueChanged);
            // 
            // labelSprintSpeed
            // 
            this.labelSprintSpeed.BackColor = System.Drawing.SystemColors.Control;
            this.labelSprintSpeed.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelSprintSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelSprintSpeed.ForeColor = System.Drawing.Color.Yellow;
            this.labelSprintSpeed.Image = ((System.Drawing.Image)(resources.GetObject("labelSprintSpeed.Image")));
            this.labelSprintSpeed.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelSprintSpeed.Location = new System.Drawing.Point(12, 88);
            this.labelSprintSpeed.Name = "labelSprintSpeed";
            this.labelSprintSpeed.Size = new System.Drawing.Size(112, 16);
            this.labelSprintSpeed.TabIndex = 69;
            this.labelSprintSpeed.Text = "Sprint-Speed ";
            this.labelSprintSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackSprintSpeed
            // 
            this.trackSprintSpeed.BackColor = System.Drawing.SystemColors.Control;
            this.trackSprintSpeed.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackSprintSpeed.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "sprintspeed", true));
            this.trackSprintSpeed.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackSprintSpeed.LargeChange = 10;
            this.trackSprintSpeed.Location = new System.Drawing.Point(4, 96);
            this.trackSprintSpeed.Maximum = 99;
            this.trackSprintSpeed.Minimum = 1;
            this.trackSprintSpeed.Name = "trackSprintSpeed";
            this.trackSprintSpeed.Size = new System.Drawing.Size(128, 45);
            this.trackSprintSpeed.TabIndex = 2;
            this.trackSprintSpeed.TickFrequency = 10;
            this.trackSprintSpeed.Value = 99;
            this.trackSprintSpeed.ValueChanged += new System.EventHandler(this.trackSprintSpeed_ValueChanged);
            // 
            // labelAcceleration
            // 
            this.labelAcceleration.BackColor = System.Drawing.SystemColors.Control;
            this.labelAcceleration.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelAcceleration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelAcceleration.ForeColor = System.Drawing.Color.Yellow;
            this.labelAcceleration.Image = ((System.Drawing.Image)(resources.GetObject("labelAcceleration.Image")));
            this.labelAcceleration.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelAcceleration.Location = new System.Drawing.Point(12, 40);
            this.labelAcceleration.Name = "labelAcceleration";
            this.labelAcceleration.Size = new System.Drawing.Size(112, 16);
            this.labelAcceleration.TabIndex = 65;
            this.labelAcceleration.Text = "Acceleration ";
            this.labelAcceleration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackAcceleration
            // 
            this.trackAcceleration.BackColor = System.Drawing.SystemColors.Control;
            this.trackAcceleration.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackAcceleration.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "acceleration", true));
            this.trackAcceleration.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackAcceleration.LargeChange = 10;
            this.trackAcceleration.Location = new System.Drawing.Point(4, 48);
            this.trackAcceleration.Maximum = 99;
            this.trackAcceleration.Minimum = 1;
            this.trackAcceleration.Name = "trackAcceleration";
            this.trackAcceleration.Size = new System.Drawing.Size(128, 45);
            this.trackAcceleration.TabIndex = 1;
            this.trackAcceleration.TickFrequency = 10;
            this.trackAcceleration.Value = 99;
            this.trackAcceleration.ValueChanged += new System.EventHandler(this.trackAcceleration_ValueChanged);
            // 
            // trackStrength
            // 
            this.trackStrength.BackColor = System.Drawing.SystemColors.Control;
            this.trackStrength.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackStrength.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "strength", true));
            this.trackStrength.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackStrength.LargeChange = 10;
            this.trackStrength.Location = new System.Drawing.Point(4, 192);
            this.trackStrength.Maximum = 99;
            this.trackStrength.Minimum = 1;
            this.trackStrength.Name = "trackStrength";
            this.trackStrength.Size = new System.Drawing.Size(128, 45);
            this.trackStrength.TabIndex = 4;
            this.trackStrength.TickFrequency = 10;
            this.trackStrength.Value = 99;
            this.trackStrength.ValueChanged += new System.EventHandler(this.trackStrength_ValueChanged);
            // 
            // trackReactions
            // 
            this.trackReactions.BackColor = System.Drawing.SystemColors.Control;
            this.trackReactions.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "reactions", true));
            this.trackReactions.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackReactions.LargeChange = 10;
            this.trackReactions.Location = new System.Drawing.Point(139, 48);
            this.trackReactions.Maximum = 99;
            this.trackReactions.Minimum = 1;
            this.trackReactions.Name = "trackReactions";
            this.trackReactions.Size = new System.Drawing.Size(128, 45);
            this.trackReactions.TabIndex = 7;
            this.trackReactions.TickFrequency = 10;
            this.trackReactions.Value = 99;
            this.trackReactions.ValueChanged += new System.EventHandler(this.trackReactions_ValueChanged);
            // 
            // trackJumping
            // 
            this.trackJumping.BackColor = System.Drawing.SystemColors.Control;
            this.trackJumping.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackJumping.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "jumping", true));
            this.trackJumping.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackJumping.LargeChange = 10;
            this.trackJumping.Location = new System.Drawing.Point(4, 288);
            this.trackJumping.Maximum = 99;
            this.trackJumping.Minimum = 1;
            this.trackJumping.Name = "trackJumping";
            this.trackJumping.Size = new System.Drawing.Size(128, 45);
            this.trackJumping.TabIndex = 6;
            this.trackJumping.TickFrequency = 10;
            this.trackJumping.Value = 99;
            this.trackJumping.ValueChanged += new System.EventHandler(this.trackJumping_ValueChanged);
            // 
            // groupFreeKick
            // 
            this.groupFreeKick.BackColor = System.Drawing.SystemColors.Control;
            this.groupFreeKick.Controls.Add(this.labelSkillsStars);
            this.groupFreeKick.Controls.Add(this.numericSkillMoves);
            this.groupFreeKick.Controls.Add(this.labelSkillMoves);
            this.groupFreeKick.Controls.Add(this.numericFreeKickSkills);
            this.groupFreeKick.Controls.Add(this.labelPenalties);
            this.groupFreeKick.Controls.Add(this.labelFreeKick);
            this.groupFreeKick.Controls.Add(this.trackFreeKick);
            this.groupFreeKick.Controls.Add(this.trackPenalties);
            this.groupFreeKick.Controls.Add(this.labelPenaltyKick);
            this.groupFreeKick.Controls.Add(this.comboPenaltyKick);
            this.groupFreeKick.Controls.Add(this.labelPenaltyMove);
            this.groupFreeKick.Controls.Add(this.comboPenaltyMove);
            this.groupFreeKick.Controls.Add(this.labelFreeKickStart);
            this.groupFreeKick.Controls.Add(this.labelPenaltyStart);
            this.groupFreeKick.Controls.Add(this.comboFreeKickStart);
            this.groupFreeKick.Controls.Add(this.comboPenaltyStart);
            this.groupFreeKick.Location = new System.Drawing.Point(3, 387);
            this.groupFreeKick.Name = "groupFreeKick";
            this.groupFreeKick.Size = new System.Drawing.Size(250, 309);
            this.groupFreeKick.TabIndex = 28;
            this.groupFreeKick.TabStop = false;
            this.groupFreeKick.Text = "Free Kick Skills";
            // 
            // labelSkillsStars
            // 
            this.labelSkillsStars.ImageList = this.imageListStars;
            this.labelSkillsStars.Location = new System.Drawing.Point(118, 148);
            this.labelSkillsStars.Name = "labelSkillsStars";
            this.labelSkillsStars.Size = new System.Drawing.Size(117, 23);
            this.labelSkillsStars.TabIndex = 156;
            // 
            // imageListStars
            // 
            this.imageListStars.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListStars.ImageStream")));
            this.imageListStars.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageListStars.Images.SetKeyName(0, "Stars_1.PNG");
            this.imageListStars.Images.SetKeyName(1, "Stars_2.PNG");
            this.imageListStars.Images.SetKeyName(2, "Stars_3.PNG");
            this.imageListStars.Images.SetKeyName(3, "Stars_4.PNG");
            this.imageListStars.Images.SetKeyName(4, "Stars_5.PNG");
            // 
            // numericSkillMoves
            // 
            this.numericSkillMoves.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "skillmoves", true));
            this.numericSkillMoves.Location = new System.Drawing.Point(69, 151);
            this.numericSkillMoves.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericSkillMoves.Name = "numericSkillMoves";
            this.numericSkillMoves.Size = new System.Drawing.Size(43, 20);
            this.numericSkillMoves.TabIndex = 3;
            this.numericSkillMoves.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericSkillMoves.ValueChanged += new System.EventHandler(this.numericSkillMoves_ValueChanged);
            // 
            // labelSkillMoves
            // 
            this.labelSkillMoves.AutoSize = true;
            this.labelSkillMoves.Location = new System.Drawing.Point(8, 153);
            this.labelSkillMoves.Name = "labelSkillMoves";
            this.labelSkillMoves.Size = new System.Drawing.Size(61, 13);
            this.labelSkillMoves.TabIndex = 154;
            this.labelSkillMoves.Text = "Skill Moves";
            // 
            // numericFreeKickSkills
            // 
            this.numericFreeKickSkills.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericFreeKickSkills.BackColor = System.Drawing.Color.Teal;
            this.numericFreeKickSkills.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.numericFreeKickSkills.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.numericFreeKickSkills.Location = new System.Drawing.Point(50, 15);
            this.numericFreeKickSkills.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericFreeKickSkills.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericFreeKickSkills.Name = "numericFreeKickSkills";
            this.numericFreeKickSkills.Size = new System.Drawing.Size(44, 22);
            this.numericFreeKickSkills.TabIndex = 0;
            this.numericFreeKickSkills.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericFreeKickSkills.Value = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericFreeKickSkills.ValueChanged += new System.EventHandler(this.numericFreeKickSkills_ValueChanged);
            // 
            // labelPenalties
            // 
            this.labelPenalties.BackColor = System.Drawing.SystemColors.Control;
            this.labelPenalties.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelPenalties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelPenalties.ForeColor = System.Drawing.Color.Yellow;
            this.labelPenalties.Image = ((System.Drawing.Image)(resources.GetObject("labelPenalties.Image")));
            this.labelPenalties.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelPenalties.Location = new System.Drawing.Point(16, 88);
            this.labelPenalties.Name = "labelPenalties";
            this.labelPenalties.Size = new System.Drawing.Size(112, 16);
            this.labelPenalties.TabIndex = 116;
            this.labelPenalties.Text = "Penalties ";
            this.labelPenalties.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFreeKick
            // 
            this.labelFreeKick.BackColor = System.Drawing.SystemColors.Control;
            this.labelFreeKick.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelFreeKick.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelFreeKick.ForeColor = System.Drawing.Color.Yellow;
            this.labelFreeKick.Image = ((System.Drawing.Image)(resources.GetObject("labelFreeKick.Image")));
            this.labelFreeKick.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelFreeKick.Location = new System.Drawing.Point(16, 40);
            this.labelFreeKick.Name = "labelFreeKick";
            this.labelFreeKick.Size = new System.Drawing.Size(112, 16);
            this.labelFreeKick.TabIndex = 112;
            this.labelFreeKick.Text = "Free-Kick ";
            this.labelFreeKick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackFreeKick
            // 
            this.trackFreeKick.BackColor = System.Drawing.SystemColors.Control;
            this.trackFreeKick.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackFreeKick.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "freekickaccuracy", true));
            this.trackFreeKick.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackFreeKick.LargeChange = 10;
            this.trackFreeKick.Location = new System.Drawing.Point(8, 48);
            this.trackFreeKick.Maximum = 99;
            this.trackFreeKick.Minimum = 1;
            this.trackFreeKick.Name = "trackFreeKick";
            this.trackFreeKick.Size = new System.Drawing.Size(128, 45);
            this.trackFreeKick.TabIndex = 1;
            this.trackFreeKick.TickFrequency = 10;
            this.trackFreeKick.Value = 99;
            this.trackFreeKick.ValueChanged += new System.EventHandler(this.trackFreeKick_ValueChanged);
            // 
            // trackPenalties
            // 
            this.trackPenalties.BackColor = System.Drawing.SystemColors.Control;
            this.trackPenalties.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackPenalties.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "penalties", true));
            this.trackPenalties.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackPenalties.LargeChange = 10;
            this.trackPenalties.Location = new System.Drawing.Point(8, 96);
            this.trackPenalties.Maximum = 99;
            this.trackPenalties.Minimum = 1;
            this.trackPenalties.Name = "trackPenalties";
            this.trackPenalties.Size = new System.Drawing.Size(128, 45);
            this.trackPenalties.TabIndex = 2;
            this.trackPenalties.TickFrequency = 10;
            this.trackPenalties.Value = 99;
            this.trackPenalties.ValueChanged += new System.EventHandler(this.trackPenalties_ValueChanged);
            // 
            // labelPenaltyKick
            // 
            this.labelPenaltyKick.AutoSize = true;
            this.labelPenaltyKick.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelPenaltyKick.Location = new System.Drawing.Point(6, 259);
            this.labelPenaltyKick.Name = "labelPenaltyKick";
            this.labelPenaltyKick.Size = new System.Drawing.Size(66, 13);
            this.labelPenaltyKick.TabIndex = 153;
            this.labelPenaltyKick.Text = "Penalty Kick";
            this.labelPenaltyKick.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboPenaltyKick
            // 
            this.comboPenaltyKick.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.playerBindingSource, "animpenaltieskickstylecode", true));
            this.comboPenaltyKick.FormattingEnabled = true;
            this.comboPenaltyKick.Items.AddRange(new object[] {
            "Normal",
            "Finesse Shot",
            "Powerful Shot"});
            this.comboPenaltyKick.Location = new System.Drawing.Point(89, 253);
            this.comboPenaltyKick.Name = "comboPenaltyKick";
            this.comboPenaltyKick.Size = new System.Drawing.Size(139, 21);
            this.comboPenaltyKick.TabIndex = 7;
            // 
            // labelPenaltyMove
            // 
            this.labelPenaltyMove.AutoSize = true;
            this.labelPenaltyMove.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelPenaltyMove.Location = new System.Drawing.Point(6, 235);
            this.labelPenaltyMove.Name = "labelPenaltyMove";
            this.labelPenaltyMove.Size = new System.Drawing.Size(72, 13);
            this.labelPenaltyMove.TabIndex = 151;
            this.labelPenaltyMove.Text = "Penalty Move";
            this.labelPenaltyMove.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboPenaltyMove
            // 
            this.comboPenaltyMove.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.playerBindingSource, "animpenaltiesmotionstylecode", true));
            this.comboPenaltyMove.FormattingEnabled = true;
            this.comboPenaltyMove.Items.AddRange(new object[] {
            "Continuous Motion",
            "Start/Stop Motion",
            "Henry\'s style",
            "Unknown style",
            "Lampard\'s style",
            "Podolski\'s style",
            "Ronaldinho\'s style"});
            this.comboPenaltyMove.Location = new System.Drawing.Point(89, 229);
            this.comboPenaltyMove.Name = "comboPenaltyMove";
            this.comboPenaltyMove.Size = new System.Drawing.Size(139, 21);
            this.comboPenaltyMove.TabIndex = 6;
            // 
            // labelFreeKickStart
            // 
            this.labelFreeKickStart.AutoSize = true;
            this.labelFreeKickStart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelFreeKickStart.Location = new System.Drawing.Point(6, 189);
            this.labelFreeKickStart.Name = "labelFreeKickStart";
            this.labelFreeKickStart.Size = new System.Drawing.Size(77, 13);
            this.labelFreeKickStart.TabIndex = 147;
            this.labelFreeKickStart.Text = "Free Kick Start";
            this.labelFreeKickStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPenaltyStart
            // 
            this.labelPenaltyStart.AutoSize = true;
            this.labelPenaltyStart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelPenaltyStart.Location = new System.Drawing.Point(6, 212);
            this.labelPenaltyStart.Name = "labelPenaltyStart";
            this.labelPenaltyStart.Size = new System.Drawing.Size(67, 13);
            this.labelPenaltyStart.TabIndex = 149;
            this.labelPenaltyStart.Text = "Penalty Start";
            this.labelPenaltyStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboFreeKickStart
            // 
            this.comboFreeKickStart.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.playerBindingSource, "animfreekickstartposcode", true));
            this.comboFreeKickStart.FormattingEnabled = true;
            this.comboFreeKickStart.Items.AddRange(new object[] {
            "Normal",
            "Long run-up",
            "90 degrees from ball",
            "Henry\'s style",
            "Beckham\'s style",
            "Lampard\'s style",
            "Adriano\'s style",
            "Cristiano Ronaldo\'s style",
            "Juninho\'s style",
            "Ronaldinho\'s style"});
            this.comboFreeKickStart.Location = new System.Drawing.Point(89, 183);
            this.comboFreeKickStart.Name = "comboFreeKickStart";
            this.comboFreeKickStart.Size = new System.Drawing.Size(139, 21);
            this.comboFreeKickStart.TabIndex = 4;
            // 
            // comboPenaltyStart
            // 
            this.comboPenaltyStart.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.playerBindingSource, "animpenaltiesstartposcode", true));
            this.comboPenaltyStart.FormattingEnabled = true;
            this.comboPenaltyStart.Items.AddRange(new object[] {
            "Edge of the penalty box",
            "Close to the ball",
            "Outside the penalty box",
            "Henry\'s style",
            "Unknown style",
            "Lampard\'s style",
            "Podolski\'s style",
            "Ronaldinho\'s style",
            "Cristiano Ronaldo\'s style"});
            this.comboPenaltyStart.Location = new System.Drawing.Point(89, 206);
            this.comboPenaltyStart.Name = "comboPenaltyStart";
            this.comboPenaltyStart.Size = new System.Drawing.Size(139, 21);
            this.comboPenaltyStart.TabIndex = 5;
            // 
            // groupTraits
            // 
            this.groupTraits.Controls.Add(this.groupBox2);
            this.groupTraits.Controls.Add(this.checkGKOneonOne);
            this.groupTraits.Controls.Add(this.checkAcrobaticClearance);
            this.groupTraits.Controls.Add(this.checkSecondWind);
            this.groupTraits.Controls.Add(this.checkCrowdFavourite);
            this.groupTraits.Controls.Add(this.checkInflexible);
            this.groupTraits.Controls.Add(this.checkTeamPlayer);
            this.groupTraits.Controls.Add(this.checkSwervePasser);
            this.groupTraits.Controls.Add(this.checkCornerSpecialist);
            this.groupTraits.Controls.Add(this.checkPowerHeader);
            this.groupTraits.Controls.Add(this.checkGkLongThrower);
            this.groupTraits.Controls.Add(this.checkLongPasser);
            this.groupTraits.Controls.Add(this.checkFlair);
            this.groupTraits.Controls.Add(this.checkFinesseShot);
            this.groupTraits.Controls.Add(this.checkArguesWithOfficials);
            this.groupTraits.Controls.Add(this.checkBeatsOffsideTrap);
            this.groupTraits.Controls.Add(this.checkAvoidsWeakFoot);
            this.groupTraits.Controls.Add(this.checkInjuryFree);
            this.groupTraits.Controls.Add(this.checkPowerFreeKick);
            this.groupTraits.Controls.Add(this.checkSelfish);
            this.groupTraits.Controls.Add(this.checkPlaymaker);
            this.groupTraits.Controls.Add(this.checkTechnicaldribbler);
            this.groupTraits.Controls.Add(this.checkLeadership);
            this.groupTraits.Controls.Add(this.checkPuncher);
            this.groupTraits.Controls.Add(this.checkDiver);
            this.groupTraits.Controls.Add(this.checkDivesintotackles);
            this.groupTraits.Controls.Add(this.checkLongshottaker);
            this.groupTraits.Controls.Add(this.checkHighClubIdentification);
            this.groupTraits.Controls.Add(this.checkPushesupforcorners);
            this.groupTraits.Controls.Add(this.checkEarlycrosser);
            this.groupTraits.Controls.Add(this.checkInjuryProne);
            this.groupTraits.Controls.Add(this.checkGiantThrower);
            this.groupTraits.Controls.Add(this.checkLongThrower);
            this.groupTraits.Location = new System.Drawing.Point(259, 387);
            this.groupTraits.Name = "groupTraits";
            this.groupTraits.Size = new System.Drawing.Size(619, 309);
            this.groupTraits.TabIndex = 30;
            this.groupTraits.TabStop = false;
            this.groupTraits.Text = "Traits";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkGKFlatKick);
            this.groupBox2.Controls.Add(this.checkDrivenPass);
            this.groupBox2.Controls.Add(this.checkDivingHeader);
            this.groupBox2.Controls.Add(this.checkBycicleKick);
            this.groupBox2.Controls.Add(this.checkChipperPenalty);
            this.groupBox2.Controls.Add(this.checkStutterPenalty);
            this.groupBox2.Controls.Add(this.checkFancyFlicks);
            this.groupBox2.Controls.Add(this.checkFancyPasses);
            this.groupBox2.Controls.Add(this.checkFancyFeet);
            this.groupBox2.Location = new System.Drawing.Point(472, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(130, 284);
            this.groupBox2.TabIndex = 57;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Virtual Pro";
            // 
            // checkGKFlatKick
            // 
            this.checkGKFlatKick.AutoSize = true;
            this.checkGKFlatKick.BackColor = System.Drawing.Color.Transparent;
            this.checkGKFlatKick.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "GkFlatKick", true));
            this.checkGKFlatKick.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkGKFlatKick.Location = new System.Drawing.Point(16, 216);
            this.checkGKFlatKick.Name = "checkGKFlatKick";
            this.checkGKFlatKick.Size = new System.Drawing.Size(85, 17);
            this.checkGKFlatKick.TabIndex = 51;
            this.checkGKFlatKick.Text = "GK Flat Kick";
            this.checkGKFlatKick.UseVisualStyleBackColor = false;
            // 
            // checkDrivenPass
            // 
            this.checkDrivenPass.AutoSize = true;
            this.checkDrivenPass.BackColor = System.Drawing.Color.Transparent;
            this.checkDrivenPass.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "DrivenPass", true));
            this.checkDrivenPass.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkDrivenPass.Location = new System.Drawing.Point(16, 194);
            this.checkDrivenPass.Name = "checkDrivenPass";
            this.checkDrivenPass.Size = new System.Drawing.Size(83, 17);
            this.checkDrivenPass.TabIndex = 50;
            this.checkDrivenPass.Text = "Driven Pass";
            this.checkDrivenPass.UseVisualStyleBackColor = false;
            // 
            // checkDivingHeader
            // 
            this.checkDivingHeader.AutoSize = true;
            this.checkDivingHeader.BackColor = System.Drawing.Color.Transparent;
            this.checkDivingHeader.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "DivingHeader", true));
            this.checkDivingHeader.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkDivingHeader.Location = new System.Drawing.Point(16, 172);
            this.checkDivingHeader.Name = "checkDivingHeader";
            this.checkDivingHeader.Size = new System.Drawing.Size(94, 17);
            this.checkDivingHeader.TabIndex = 49;
            this.checkDivingHeader.Text = "Diving Header";
            this.checkDivingHeader.UseVisualStyleBackColor = false;
            // 
            // checkBycicleKick
            // 
            this.checkBycicleKick.AutoSize = true;
            this.checkBycicleKick.BackColor = System.Drawing.Color.Transparent;
            this.checkBycicleKick.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "BycicleKick", true));
            this.checkBycicleKick.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBycicleKick.Location = new System.Drawing.Point(16, 150);
            this.checkBycicleKick.Name = "checkBycicleKick";
            this.checkBycicleKick.Size = new System.Drawing.Size(84, 17);
            this.checkBycicleKick.TabIndex = 48;
            this.checkBycicleKick.Text = "Bycicle Kick";
            this.checkBycicleKick.UseVisualStyleBackColor = false;
            // 
            // checkChipperPenalty
            // 
            this.checkChipperPenalty.AutoSize = true;
            this.checkChipperPenalty.BackColor = System.Drawing.Color.Transparent;
            this.checkChipperPenalty.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "ChipperPenalty", true));
            this.checkChipperPenalty.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkChipperPenalty.Location = new System.Drawing.Point(16, 128);
            this.checkChipperPenalty.Name = "checkChipperPenalty";
            this.checkChipperPenalty.Size = new System.Drawing.Size(100, 17);
            this.checkChipperPenalty.TabIndex = 47;
            this.checkChipperPenalty.Text = "Chipper Penalty";
            this.checkChipperPenalty.UseVisualStyleBackColor = false;
            // 
            // checkStutterPenalty
            // 
            this.checkStutterPenalty.AutoSize = true;
            this.checkStutterPenalty.BackColor = System.Drawing.Color.Transparent;
            this.checkStutterPenalty.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "StutterPenalty", true));
            this.checkStutterPenalty.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkStutterPenalty.Location = new System.Drawing.Point(16, 106);
            this.checkStutterPenalty.Name = "checkStutterPenalty";
            this.checkStutterPenalty.Size = new System.Drawing.Size(95, 17);
            this.checkStutterPenalty.TabIndex = 46;
            this.checkStutterPenalty.Text = "Stutter Penalty";
            this.checkStutterPenalty.UseVisualStyleBackColor = false;
            // 
            // checkFancyFlicks
            // 
            this.checkFancyFlicks.AutoSize = true;
            this.checkFancyFlicks.BackColor = System.Drawing.Color.Transparent;
            this.checkFancyFlicks.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "FancyFlicks", true));
            this.checkFancyFlicks.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkFancyFlicks.Location = new System.Drawing.Point(16, 84);
            this.checkFancyFlicks.Name = "checkFancyFlicks";
            this.checkFancyFlicks.Size = new System.Drawing.Size(85, 17);
            this.checkFancyFlicks.TabIndex = 45;
            this.checkFancyFlicks.Text = "Fancy Flicks";
            this.checkFancyFlicks.UseVisualStyleBackColor = false;
            // 
            // checkFancyPasses
            // 
            this.checkFancyPasses.AutoSize = true;
            this.checkFancyPasses.BackColor = System.Drawing.Color.Transparent;
            this.checkFancyPasses.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "FancyPasses", true));
            this.checkFancyPasses.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkFancyPasses.Location = new System.Drawing.Point(16, 62);
            this.checkFancyPasses.Name = "checkFancyPasses";
            this.checkFancyPasses.Size = new System.Drawing.Size(92, 17);
            this.checkFancyPasses.TabIndex = 44;
            this.checkFancyPasses.Text = "Fancy Passes";
            this.checkFancyPasses.UseVisualStyleBackColor = false;
            // 
            // checkFancyFeet
            // 
            this.checkFancyFeet.AutoSize = true;
            this.checkFancyFeet.BackColor = System.Drawing.Color.Transparent;
            this.checkFancyFeet.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "FancyFeet", true));
            this.checkFancyFeet.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkFancyFeet.Location = new System.Drawing.Point(16, 40);
            this.checkFancyFeet.Name = "checkFancyFeet";
            this.checkFancyFeet.Size = new System.Drawing.Size(79, 17);
            this.checkFancyFeet.TabIndex = 43;
            this.checkFancyFeet.Text = "Fancy Feet";
            this.checkFancyFeet.UseVisualStyleBackColor = false;
            // 
            // checkGKOneonOne
            // 
            this.checkGKOneonOne.AutoSize = true;
            this.checkGKOneonOne.BackColor = System.Drawing.Color.Transparent;
            this.checkGKOneonOne.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "GkOneOnOne", true));
            this.checkGKOneonOne.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkGKOneonOne.Location = new System.Drawing.Point(24, 213);
            this.checkGKOneonOne.Name = "checkGKOneonOne";
            this.checkGKOneonOne.Size = new System.Drawing.Size(102, 17);
            this.checkGKOneonOne.TabIndex = 56;
            this.checkGKOneonOne.Text = "GK One on One";
            this.checkGKOneonOne.UseVisualStyleBackColor = false;
            // 
            // checkAcrobaticClearance
            // 
            this.checkAcrobaticClearance.AutoSize = true;
            this.checkAcrobaticClearance.BackColor = System.Drawing.Color.Transparent;
            this.checkAcrobaticClearance.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "AcrobaticClearance", true));
            this.checkAcrobaticClearance.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkAcrobaticClearance.Location = new System.Drawing.Point(24, 235);
            this.checkAcrobaticClearance.Name = "checkAcrobaticClearance";
            this.checkAcrobaticClearance.Size = new System.Drawing.Size(122, 17);
            this.checkAcrobaticClearance.TabIndex = 55;
            this.checkAcrobaticClearance.Text = "Acrobatic Clearance";
            this.checkAcrobaticClearance.UseVisualStyleBackColor = false;
            // 
            // checkSecondWind
            // 
            this.checkSecondWind.AutoSize = true;
            this.checkSecondWind.BackColor = System.Drawing.Color.Transparent;
            this.checkSecondWind.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "SecondWind", true));
            this.checkSecondWind.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkSecondWind.Location = new System.Drawing.Point(24, 81);
            this.checkSecondWind.Name = "checkSecondWind";
            this.checkSecondWind.Size = new System.Drawing.Size(91, 17);
            this.checkSecondWind.TabIndex = 54;
            this.checkSecondWind.Text = "Second Wind";
            this.checkSecondWind.UseVisualStyleBackColor = false;
            // 
            // checkCrowdFavourite
            // 
            this.checkCrowdFavourite.AutoSize = true;
            this.checkCrowdFavourite.BackColor = System.Drawing.Color.Transparent;
            this.checkCrowdFavourite.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "CrowdFavorite", true));
            this.checkCrowdFavourite.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkCrowdFavourite.Location = new System.Drawing.Point(334, 213);
            this.checkCrowdFavourite.Name = "checkCrowdFavourite";
            this.checkCrowdFavourite.Size = new System.Drawing.Size(103, 17);
            this.checkCrowdFavourite.TabIndex = 53;
            this.checkCrowdFavourite.Text = "Crowd Favourite";
            this.checkCrowdFavourite.UseVisualStyleBackColor = false;
            // 
            // checkInflexible
            // 
            this.checkInflexible.AutoSize = true;
            this.checkInflexible.BackColor = System.Drawing.Color.Transparent;
            this.checkInflexible.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "Inflexible", true));
            this.checkInflexible.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkInflexible.Location = new System.Drawing.Point(334, 191);
            this.checkInflexible.Name = "checkInflexible";
            this.checkInflexible.Size = new System.Drawing.Size(67, 17);
            this.checkInflexible.TabIndex = 52;
            this.checkInflexible.Text = "Inflexible";
            this.checkInflexible.UseVisualStyleBackColor = false;
            // 
            // checkTeamPlayer
            // 
            this.checkTeamPlayer.AutoSize = true;
            this.checkTeamPlayer.BackColor = System.Drawing.Color.Transparent;
            this.checkTeamPlayer.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "TeamPlayer", true));
            this.checkTeamPlayer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkTeamPlayer.Location = new System.Drawing.Point(334, 169);
            this.checkTeamPlayer.Name = "checkTeamPlayer";
            this.checkTeamPlayer.Size = new System.Drawing.Size(85, 17);
            this.checkTeamPlayer.TabIndex = 51;
            this.checkTeamPlayer.Text = "Team Player";
            this.checkTeamPlayer.UseVisualStyleBackColor = false;
            // 
            // checkSwervePasser
            // 
            this.checkSwervePasser.AutoSize = true;
            this.checkSwervePasser.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "SwervePasser", true));
            this.checkSwervePasser.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkSwervePasser.Location = new System.Drawing.Point(170, 125);
            this.checkSwervePasser.Name = "checkSwervePasser";
            this.checkSwervePasser.Size = new System.Drawing.Size(97, 17);
            this.checkSwervePasser.TabIndex = 50;
            this.checkSwervePasser.Text = "Swerve Passer";
            this.checkSwervePasser.UseVisualStyleBackColor = false;
            // 
            // checkCornerSpecialist
            // 
            this.checkCornerSpecialist.AutoSize = true;
            this.checkCornerSpecialist.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "OutsideFootShot", true));
            this.checkCornerSpecialist.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkCornerSpecialist.Location = new System.Drawing.Point(170, 258);
            this.checkCornerSpecialist.Name = "checkCornerSpecialist";
            this.checkCornerSpecialist.Size = new System.Drawing.Size(111, 17);
            this.checkCornerSpecialist.TabIndex = 49;
            this.checkCornerSpecialist.Text = "Outside Foot Shot";
            this.checkCornerSpecialist.UseVisualStyleBackColor = false;
            // 
            // checkPowerHeader
            // 
            this.checkPowerHeader.AutoSize = true;
            this.checkPowerHeader.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "PowerHeader", true));
            this.checkPowerHeader.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkPowerHeader.Location = new System.Drawing.Point(170, 192);
            this.checkPowerHeader.Name = "checkPowerHeader";
            this.checkPowerHeader.Size = new System.Drawing.Size(94, 17);
            this.checkPowerHeader.TabIndex = 48;
            this.checkPowerHeader.Text = "Power Header";
            this.checkPowerHeader.UseVisualStyleBackColor = false;
            // 
            // checkGkLongThrower
            // 
            this.checkGkLongThrower.AutoSize = true;
            this.checkGkLongThrower.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "GkLongThrower", true));
            this.checkGkLongThrower.Location = new System.Drawing.Point(24, 191);
            this.checkGkLongThrower.Name = "checkGkLongThrower";
            this.checkGkLongThrower.Size = new System.Drawing.Size(110, 17);
            this.checkGkLongThrower.TabIndex = 47;
            this.checkGkLongThrower.Text = "GK Long Thrower";
            this.checkGkLongThrower.UseVisualStyleBackColor = true;
            // 
            // checkLongPasser
            // 
            this.checkLongPasser.AutoSize = true;
            this.checkLongPasser.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "LongPasser", true));
            this.checkLongPasser.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkLongPasser.Location = new System.Drawing.Point(170, 103);
            this.checkLongPasser.Name = "checkLongPasser";
            this.checkLongPasser.Size = new System.Drawing.Size(85, 17);
            this.checkLongPasser.TabIndex = 46;
            this.checkLongPasser.Text = "Long Passer";
            this.checkLongPasser.UseVisualStyleBackColor = false;
            // 
            // checkFlair
            // 
            this.checkFlair.AutoSize = true;
            this.checkFlair.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "Flair", true));
            this.checkFlair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkFlair.Location = new System.Drawing.Point(170, 147);
            this.checkFlair.Name = "checkFlair";
            this.checkFlair.Size = new System.Drawing.Size(45, 17);
            this.checkFlair.TabIndex = 45;
            this.checkFlair.Text = "Flair";
            this.checkFlair.UseVisualStyleBackColor = false;
            // 
            // checkFinesseShot
            // 
            this.checkFinesseShot.AutoSize = true;
            this.checkFinesseShot.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "FinesseShot", true));
            this.checkFinesseShot.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkFinesseShot.Location = new System.Drawing.Point(170, 236);
            this.checkFinesseShot.Name = "checkFinesseShot";
            this.checkFinesseShot.Size = new System.Drawing.Size(87, 17);
            this.checkFinesseShot.TabIndex = 44;
            this.checkFinesseShot.Text = "Finesse Shot";
            this.checkFinesseShot.UseVisualStyleBackColor = false;
            // 
            // checkArguesWithOfficials
            // 
            this.checkArguesWithOfficials.AutoSize = true;
            this.checkArguesWithOfficials.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "ArguesWithOfficials", true));
            this.checkArguesWithOfficials.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkArguesWithOfficials.Location = new System.Drawing.Point(334, 125);
            this.checkArguesWithOfficials.Name = "checkArguesWithOfficials";
            this.checkArguesWithOfficials.Size = new System.Drawing.Size(121, 17);
            this.checkArguesWithOfficials.TabIndex = 43;
            this.checkArguesWithOfficials.Text = "Argues with Officials";
            this.checkArguesWithOfficials.UseVisualStyleBackColor = false;
            // 
            // checkBeatsOffsideTrap
            // 
            this.checkBeatsOffsideTrap.AutoSize = true;
            this.checkBeatsOffsideTrap.BackColor = System.Drawing.Color.Transparent;
            this.checkBeatsOffsideTrap.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "BeatDefensiveLine", true));
            this.checkBeatsOffsideTrap.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBeatsOffsideTrap.Location = new System.Drawing.Point(334, 59);
            this.checkBeatsOffsideTrap.Name = "checkBeatsOffsideTrap";
            this.checkBeatsOffsideTrap.Size = new System.Drawing.Size(114, 17);
            this.checkBeatsOffsideTrap.TabIndex = 42;
            this.checkBeatsOffsideTrap.Text = "Beats Offside Trap";
            this.checkBeatsOffsideTrap.UseVisualStyleBackColor = false;
            // 
            // checkAvoidsWeakFoot
            // 
            this.checkAvoidsWeakFoot.AutoSize = true;
            this.checkAvoidsWeakFoot.BackColor = System.Drawing.Color.Transparent;
            this.checkAvoidsWeakFoot.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "AvoidsWeakFoot", true));
            this.checkAvoidsWeakFoot.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkAvoidsWeakFoot.Location = new System.Drawing.Point(170, 37);
            this.checkAvoidsWeakFoot.Name = "checkAvoidsWeakFoot";
            this.checkAvoidsWeakFoot.Size = new System.Drawing.Size(144, 17);
            this.checkAvoidsWeakFoot.TabIndex = 41;
            this.checkAvoidsWeakFoot.Text = "Avoids Using Weak Foot";
            this.checkAvoidsWeakFoot.UseVisualStyleBackColor = false;
            // 
            // checkInjuryFree
            // 
            this.checkInjuryFree.AutoSize = true;
            this.checkInjuryFree.BackColor = System.Drawing.Color.Transparent;
            this.checkInjuryFree.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "InjuryFree", true));
            this.checkInjuryFree.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkInjuryFree.Location = new System.Drawing.Point(24, 59);
            this.checkInjuryFree.Name = "checkInjuryFree";
            this.checkInjuryFree.Size = new System.Drawing.Size(75, 17);
            this.checkInjuryFree.TabIndex = 40;
            this.checkInjuryFree.Text = "Injury Free";
            this.checkInjuryFree.UseVisualStyleBackColor = false;
            // 
            // checkPowerFreeKick
            // 
            this.checkPowerFreeKick.AutoSize = true;
            this.checkPowerFreeKick.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "PowerfulFreeKicks", true));
            this.checkPowerFreeKick.Location = new System.Drawing.Point(334, 37);
            this.checkPowerFreeKick.Name = "checkPowerFreeKick";
            this.checkPowerFreeKick.Size = new System.Drawing.Size(104, 17);
            this.checkPowerFreeKick.TabIndex = 39;
            this.checkPowerFreeKick.Text = "Power Free Kick";
            this.checkPowerFreeKick.UseVisualStyleBackColor = true;
            // 
            // checkSelfish
            // 
            this.checkSelfish.AutoSize = true;
            this.checkSelfish.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "Selfish", true));
            this.checkSelfish.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkSelfish.Location = new System.Drawing.Point(334, 81);
            this.checkSelfish.Name = "checkSelfish";
            this.checkSelfish.Size = new System.Drawing.Size(57, 17);
            this.checkSelfish.TabIndex = 37;
            this.checkSelfish.Text = "Selfish";
            this.checkSelfish.UseVisualStyleBackColor = false;
            // 
            // checkPlaymaker
            // 
            this.checkPlaymaker.AutoSize = true;
            this.checkPlaymaker.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "Playmaker", true));
            this.checkPlaymaker.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkPlaymaker.Location = new System.Drawing.Point(170, 59);
            this.checkPlaymaker.Name = "checkPlaymaker";
            this.checkPlaymaker.Size = new System.Drawing.Size(75, 17);
            this.checkPlaymaker.TabIndex = 33;
            this.checkPlaymaker.Text = "Playmaker";
            this.checkPlaymaker.UseVisualStyleBackColor = false;
            // 
            // checkTechnicaldribbler
            // 
            this.checkTechnicaldribbler.AutoSize = true;
            this.checkTechnicaldribbler.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "Technicaldribbler", true));
            this.checkTechnicaldribbler.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkTechnicaldribbler.Location = new System.Drawing.Point(170, 169);
            this.checkTechnicaldribbler.Name = "checkTechnicaldribbler";
            this.checkTechnicaldribbler.Size = new System.Drawing.Size(112, 17);
            this.checkTechnicaldribbler.TabIndex = 38;
            this.checkTechnicaldribbler.Text = "Technical Dribbler";
            this.checkTechnicaldribbler.UseVisualStyleBackColor = false;
            // 
            // checkLeadership
            // 
            this.checkLeadership.AutoSize = true;
            this.checkLeadership.BackColor = System.Drawing.Color.Transparent;
            this.checkLeadership.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "Leadership", true));
            this.checkLeadership.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkLeadership.Location = new System.Drawing.Point(334, 235);
            this.checkLeadership.Name = "checkLeadership";
            this.checkLeadership.Size = new System.Drawing.Size(78, 17);
            this.checkLeadership.TabIndex = 36;
            this.checkLeadership.Text = "Leadership";
            this.checkLeadership.UseVisualStyleBackColor = false;
            // 
            // checkPuncher
            // 
            this.checkPuncher.AutoSize = true;
            this.checkPuncher.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "Puncher", true));
            this.checkPuncher.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkPuncher.Location = new System.Drawing.Point(24, 169);
            this.checkPuncher.Name = "checkPuncher";
            this.checkPuncher.Size = new System.Drawing.Size(84, 17);
            this.checkPuncher.TabIndex = 34;
            this.checkPuncher.Text = "GK Puncher";
            this.checkPuncher.UseVisualStyleBackColor = false;
            // 
            // checkDiver
            // 
            this.checkDiver.AutoSize = true;
            this.checkDiver.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "Diver", true));
            this.checkDiver.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkDiver.Location = new System.Drawing.Point(334, 103);
            this.checkDiver.Name = "checkDiver";
            this.checkDiver.Size = new System.Drawing.Size(51, 17);
            this.checkDiver.TabIndex = 27;
            this.checkDiver.Text = "Diver";
            this.checkDiver.UseVisualStyleBackColor = false;
            // 
            // checkDivesintotackles
            // 
            this.checkDivesintotackles.AutoSize = true;
            this.checkDivesintotackles.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "Divesintotackles", true));
            this.checkDivesintotackles.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkDivesintotackles.Location = new System.Drawing.Point(24, 257);
            this.checkDivesintotackles.Name = "checkDivesintotackles";
            this.checkDivesintotackles.Size = new System.Drawing.Size(114, 17);
            this.checkDivesintotackles.TabIndex = 28;
            this.checkDivesintotackles.Text = "Dives into Tackles";
            this.checkDivesintotackles.UseVisualStyleBackColor = false;
            // 
            // checkLongshottaker
            // 
            this.checkLongshottaker.AutoSize = true;
            this.checkLongshottaker.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "LongShotTaker", true));
            this.checkLongshottaker.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkLongshottaker.Location = new System.Drawing.Point(170, 214);
            this.checkLongshottaker.Name = "checkLongshottaker";
            this.checkLongshottaker.Size = new System.Drawing.Size(106, 17);
            this.checkLongshottaker.TabIndex = 30;
            this.checkLongshottaker.Text = "Long Shot Taker";
            this.checkLongshottaker.UseVisualStyleBackColor = false;
            // 
            // checkHighClubIdentification
            // 
            this.checkHighClubIdentification.AutoSize = true;
            this.checkHighClubIdentification.BackColor = System.Drawing.Color.Transparent;
            this.checkHighClubIdentification.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "HighClubIdentification", true));
            this.checkHighClubIdentification.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkHighClubIdentification.Location = new System.Drawing.Point(334, 147);
            this.checkHighClubIdentification.Name = "checkHighClubIdentification";
            this.checkHighClubIdentification.Size = new System.Drawing.Size(107, 17);
            this.checkHighClubIdentification.TabIndex = 31;
            this.checkHighClubIdentification.Text = "High Club Identif.";
            this.checkHighClubIdentification.UseVisualStyleBackColor = false;
            // 
            // checkPushesupforcorners
            // 
            this.checkPushesupforcorners.AutoSize = true;
            this.checkPushesupforcorners.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "Pushesupforcorners", true));
            this.checkPushesupforcorners.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkPushesupforcorners.Location = new System.Drawing.Point(24, 147);
            this.checkPushesupforcorners.Name = "checkPushesupforcorners";
            this.checkPushesupforcorners.Size = new System.Drawing.Size(112, 17);
            this.checkPushesupforcorners.TabIndex = 35;
            this.checkPushesupforcorners.Text = "GK Up for Corners";
            this.checkPushesupforcorners.UseVisualStyleBackColor = false;
            // 
            // checkEarlycrosser
            // 
            this.checkEarlycrosser.AutoSize = true;
            this.checkEarlycrosser.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "Earlycrosser", true));
            this.checkEarlycrosser.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkEarlycrosser.Location = new System.Drawing.Point(170, 81);
            this.checkEarlycrosser.Name = "checkEarlycrosser";
            this.checkEarlycrosser.Size = new System.Drawing.Size(87, 17);
            this.checkEarlycrosser.TabIndex = 29;
            this.checkEarlycrosser.Text = "Early Crosser";
            this.checkEarlycrosser.UseVisualStyleBackColor = false;
            // 
            // checkInjuryProne
            // 
            this.checkInjuryProne.AutoSize = true;
            this.checkInjuryProne.BackColor = System.Drawing.Color.Transparent;
            this.checkInjuryProne.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "InjuryProne", true));
            this.checkInjuryProne.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkInjuryProne.Location = new System.Drawing.Point(24, 37);
            this.checkInjuryProne.Name = "checkInjuryProne";
            this.checkInjuryProne.Size = new System.Drawing.Size(82, 17);
            this.checkInjuryProne.TabIndex = 32;
            this.checkInjuryProne.Text = "Injury Prone";
            this.checkInjuryProne.UseVisualStyleBackColor = false;
            // 
            // checkGiantThrower
            // 
            this.checkGiantThrower.AutoSize = true;
            this.checkGiantThrower.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "GiantThrow", true));
            this.checkGiantThrower.Location = new System.Drawing.Point(24, 125);
            this.checkGiantThrower.Name = "checkGiantThrower";
            this.checkGiantThrower.Size = new System.Drawing.Size(93, 17);
            this.checkGiantThrower.TabIndex = 1;
            this.checkGiantThrower.Text = "Giant Thrower";
            this.checkGiantThrower.UseVisualStyleBackColor = true;
            // 
            // checkLongThrower
            // 
            this.checkLongThrower.AutoSize = true;
            this.checkLongThrower.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.playerBindingSource, "Longthrows", true));
            this.checkLongThrower.Location = new System.Drawing.Point(24, 103);
            this.checkLongThrower.Name = "checkLongThrower";
            this.checkLongThrower.Size = new System.Drawing.Size(92, 17);
            this.checkLongThrower.TabIndex = 0;
            this.checkLongThrower.Text = "Long Thrower";
            this.checkLongThrower.UseVisualStyleBackColor = true;
            // 
            // pageFace
            // 
            this.pageFace.BackColor = System.Drawing.Color.Transparent;
            this.pageFace.Controls.Add(this.splitContainer1);
            this.pageFace.ImageIndex = 2;
            this.pageFace.Location = new System.Drawing.Point(4, 23);
            this.pageFace.Name = "pageFace";
            this.pageFace.Size = new System.Drawing.Size(1349, 780);
            this.pageFace.TabIndex = 2;
            this.pageFace.Text = "Face";
            this.pageFace.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1349, 780);
            this.splitContainer1.SplitterDistance = 724;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.viewer3D);
            this.splitContainer2.Panel1.Controls.Add(this.tool3D);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(this.groupGenericFace);
            this.splitContainer2.Size = new System.Drawing.Size(724, 780);
            this.splitContainer2.SplitterDistance = 466;
            this.splitContainer2.TabIndex = 0;
            // 
            // viewer3D
            // 
            this.viewer3D.AmbientColor = System.Drawing.Color.Gray;
            this.viewer3D.BackColor = System.Drawing.Color.Gray;
            this.viewer3D.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.viewer3D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer3D.FilesPath = null;
            this.viewer3D.Location = new System.Drawing.Point(0, 0);
            this.viewer3D.Name = "viewer3D";
            this.viewer3D.ObjectId = -1;
            this.viewer3D.ObjectType = FifaControls.FbxViewer3D.ObjectTypeServerPort.Player;
            this.viewer3D.Size = new System.Drawing.Size(724, 441);
            this.viewer3D.TabIndex = 0;
            this.viewer3D.Textures = null;
            // 
            // tool3D
            // 
            this.tool3D.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tool3D.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tool3D.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonShow3DModel,
            this.buttonSwitchRenderingMode,
            this.toolStripSeparator1,
            this.buttonImport3DHeadModel,
            this.buttonExport3DHeadModel,
            this.buttonRemove3DHeadModel,
            this.toolStripSeparator4,
            this.buttonImport3DHairModel,
            this.buttonExport3DHairModel,
            this.buttonRemoveHairModel,
            this.toolStripSeparator5,
            this.buttonMoveHairAhead,
            this.buttonMoveHairBack,
            this.buttonMoveHairUp,
            this.buttonMoveHairDown,
            this.buttonMoveHairLeft,
            this.buttonMoveHairRight,
            this.buttonMakeHairCloser,
            this.buttonMakeHairWider,
            this.buttonSaveHair,
            this.toolStripSeparator2,
            this.toolPhoto,
            this.toolStripSeparator3,
            this.buttonShowJesey});
            this.tool3D.Location = new System.Drawing.Point(0, 441);
            this.tool3D.Name = "tool3D";
            this.tool3D.Size = new System.Drawing.Size(724, 25);
            this.tool3D.TabIndex = 4;
            // 
            // buttonShow3DModel
            // 
            this.buttonShow3DModel.CheckOnClick = true;
            this.buttonShow3DModel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonShow3DModel.Image = ((System.Drawing.Image)(resources.GetObject("buttonShow3DModel.Image")));
            this.buttonShow3DModel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonShow3DModel.Name = "buttonShow3DModel";
            this.buttonShow3DModel.Size = new System.Drawing.Size(23, 22);
            this.buttonShow3DModel.Text = "Show / Hide";
            this.buttonShow3DModel.Click += new System.EventHandler(this.buttonShow3DModel_Click);
            // 
            // buttonSwitchRenderingMode
            // 
            this.buttonSwitchRenderingMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonSwitchRenderingMode.Image = ((System.Drawing.Image)(resources.GetObject("buttonSwitchRenderingMode.Image")));
            this.buttonSwitchRenderingMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSwitchRenderingMode.Name = "buttonSwitchRenderingMode";
            this.buttonSwitchRenderingMode.Size = new System.Drawing.Size(23, 22);
            this.buttonSwitchRenderingMode.Text = "Switch Rendering Mode";
            this.buttonSwitchRenderingMode.Click += new System.EventHandler(this.buttonSwitchRenderingMode_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonImport3DHeadModel
            // 
            this.buttonImport3DHeadModel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonImport3DHeadModel.Image = ((System.Drawing.Image)(resources.GetObject("buttonImport3DHeadModel.Image")));
            this.buttonImport3DHeadModel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonImport3DHeadModel.Name = "buttonImport3DHeadModel";
            this.buttonImport3DHeadModel.Size = new System.Drawing.Size(23, 22);
            this.buttonImport3DHeadModel.Text = "Import 3D Head Model";
            this.buttonImport3DHeadModel.Click += new System.EventHandler(this.buttonImport3DHeadModel_Click);
            // 
            // buttonExport3DHeadModel
            // 
            this.buttonExport3DHeadModel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonExport3DHeadModel.Image = ((System.Drawing.Image)(resources.GetObject("buttonExport3DHeadModel.Image")));
            this.buttonExport3DHeadModel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonExport3DHeadModel.Name = "buttonExport3DHeadModel";
            this.buttonExport3DHeadModel.Size = new System.Drawing.Size(23, 22);
            this.buttonExport3DHeadModel.Text = "Export 3D Head Model";
            this.buttonExport3DHeadModel.Click += new System.EventHandler(this.buttonExport3DHeadModel_Click);
            // 
            // buttonRemove3DHeadModel
            // 
            this.buttonRemove3DHeadModel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRemove3DHeadModel.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemove3DHeadModel.Image")));
            this.buttonRemove3DHeadModel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRemove3DHeadModel.Name = "buttonRemove3DHeadModel";
            this.buttonRemove3DHeadModel.Size = new System.Drawing.Size(23, 22);
            this.buttonRemove3DHeadModel.Text = "Remove 3D Head Model";
            this.buttonRemove3DHeadModel.Click += new System.EventHandler(this.buttonRemove3DModel_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonImport3DHairModel
            // 
            this.buttonImport3DHairModel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonImport3DHairModel.Image = ((System.Drawing.Image)(resources.GetObject("buttonImport3DHairModel.Image")));
            this.buttonImport3DHairModel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonImport3DHairModel.Name = "buttonImport3DHairModel";
            this.buttonImport3DHairModel.Size = new System.Drawing.Size(23, 22);
            this.buttonImport3DHairModel.Text = "Import 3D Hair Model";
            this.buttonImport3DHairModel.Click += new System.EventHandler(this.buttonImport3DHairModels_Click);
            // 
            // buttonExport3DHairModel
            // 
            this.buttonExport3DHairModel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonExport3DHairModel.Image = ((System.Drawing.Image)(resources.GetObject("buttonExport3DHairModel.Image")));
            this.buttonExport3DHairModel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonExport3DHairModel.Name = "buttonExport3DHairModel";
            this.buttonExport3DHairModel.Size = new System.Drawing.Size(23, 22);
            this.buttonExport3DHairModel.Text = "Export 3D Hair Model";
            this.buttonExport3DHairModel.Click += new System.EventHandler(this.buttonExport3DHairModels_Click);
            // 
            // buttonRemoveHairModel
            // 
            this.buttonRemoveHairModel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRemoveHairModel.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemoveHairModel.Image")));
            this.buttonRemoveHairModel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRemoveHairModel.Name = "buttonRemoveHairModel";
            this.buttonRemoveHairModel.Size = new System.Drawing.Size(23, 22);
            this.buttonRemoveHairModel.Text = "Remove Hair Model";
            this.buttonRemoveHairModel.Click += new System.EventHandler(this.buttonRemoveHairModel_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonMoveHairAhead
            // 
            this.buttonMoveHairAhead.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonMoveHairAhead.Image = ((System.Drawing.Image)(resources.GetObject("buttonMoveHairAhead.Image")));
            this.buttonMoveHairAhead.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonMoveHairAhead.Name = "buttonMoveHairAhead";
            this.buttonMoveHairAhead.Size = new System.Drawing.Size(23, 22);
            this.buttonMoveHairAhead.Text = "Move Hair Ahead";
            this.buttonMoveHairAhead.Click += new System.EventHandler(this.buttonAhead_Click);
            // 
            // buttonMoveHairBack
            // 
            this.buttonMoveHairBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonMoveHairBack.Image = ((System.Drawing.Image)(resources.GetObject("buttonMoveHairBack.Image")));
            this.buttonMoveHairBack.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonMoveHairBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonMoveHairBack.Name = "buttonMoveHairBack";
            this.buttonMoveHairBack.Size = new System.Drawing.Size(23, 22);
            this.buttonMoveHairBack.Text = "Move Hair Back";
            this.buttonMoveHairBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonMoveHairUp
            // 
            this.buttonMoveHairUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonMoveHairUp.Image = ((System.Drawing.Image)(resources.GetObject("buttonMoveHairUp.Image")));
            this.buttonMoveHairUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonMoveHairUp.Name = "buttonMoveHairUp";
            this.buttonMoveHairUp.Size = new System.Drawing.Size(23, 22);
            this.buttonMoveHairUp.Text = "Move Hair Up";
            this.buttonMoveHairUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonMoveHairDown
            // 
            this.buttonMoveHairDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonMoveHairDown.Image = ((System.Drawing.Image)(resources.GetObject("buttonMoveHairDown.Image")));
            this.buttonMoveHairDown.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonMoveHairDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonMoveHairDown.Name = "buttonMoveHairDown";
            this.buttonMoveHairDown.Size = new System.Drawing.Size(23, 22);
            this.buttonMoveHairDown.Text = "Move Hair Down";
            this.buttonMoveHairDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonMoveHairLeft
            // 
            this.buttonMoveHairLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonMoveHairLeft.Image = ((System.Drawing.Image)(resources.GetObject("buttonMoveHairLeft.Image")));
            this.buttonMoveHairLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonMoveHairLeft.Name = "buttonMoveHairLeft";
            this.buttonMoveHairLeft.Size = new System.Drawing.Size(23, 22);
            this.buttonMoveHairLeft.Text = "Move Hair Left";
            this.buttonMoveHairLeft.Click += new System.EventHandler(this.buttonMoveHairLeft_Click);
            // 
            // buttonMoveHairRight
            // 
            this.buttonMoveHairRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonMoveHairRight.Image = ((System.Drawing.Image)(resources.GetObject("buttonMoveHairRight.Image")));
            this.buttonMoveHairRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonMoveHairRight.Name = "buttonMoveHairRight";
            this.buttonMoveHairRight.Size = new System.Drawing.Size(23, 22);
            this.buttonMoveHairRight.Text = "Move Hair Right";
            this.buttonMoveHairRight.Click += new System.EventHandler(this.buttonMoveHairRight_Click);
            // 
            // buttonMakeHairCloser
            // 
            this.buttonMakeHairCloser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonMakeHairCloser.Image = ((System.Drawing.Image)(resources.GetObject("buttonMakeHairCloser.Image")));
            this.buttonMakeHairCloser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonMakeHairCloser.Name = "buttonMakeHairCloser";
            this.buttonMakeHairCloser.Size = new System.Drawing.Size(23, 22);
            this.buttonMakeHairCloser.Text = "Make Hair Closer";
            this.buttonMakeHairCloser.Click += new System.EventHandler(this.buttonMakeHairCloser_Click);
            // 
            // buttonMakeHairWider
            // 
            this.buttonMakeHairWider.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonMakeHairWider.Image = ((System.Drawing.Image)(resources.GetObject("buttonMakeHairWider.Image")));
            this.buttonMakeHairWider.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonMakeHairWider.Name = "buttonMakeHairWider";
            this.buttonMakeHairWider.Size = new System.Drawing.Size(23, 22);
            this.buttonMakeHairWider.Text = "Make Hair Wider";
            this.buttonMakeHairWider.Click += new System.EventHandler(this.buttonMakeHairWider_Click);
            // 
            // buttonSaveHair
            // 
            this.buttonSaveHair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonSaveHair.Enabled = false;
            this.buttonSaveHair.Image = ((System.Drawing.Image)(resources.GetObject("buttonSaveHair.Image")));
            this.buttonSaveHair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSaveHair.Name = "buttonSaveHair";
            this.buttonSaveHair.Size = new System.Drawing.Size(23, 22);
            this.buttonSaveHair.Text = "Save Modified Hair";
            this.buttonSaveHair.Click += new System.EventHandler(this.buttonSaveHair_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolPhoto
            // 
            this.toolPhoto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolPhoto.Image = ((System.Drawing.Image)(resources.GetObject("toolPhoto.Image")));
            this.toolPhoto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPhoto.Name = "toolPhoto";
            this.toolPhoto.Size = new System.Drawing.Size(23, 22);
            this.toolPhoto.Text = "Take a picture";
            this.toolPhoto.Click += new System.EventHandler(this.toolPhoto_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonShowJesey
            // 
            this.buttonShowJesey.Checked = true;
            this.buttonShowJesey.CheckOnClick = true;
            this.buttonShowJesey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.buttonShowJesey.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonShowJesey.Image = ((System.Drawing.Image)(resources.GetObject("buttonShowJesey.Image")));
            this.buttonShowJesey.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonShowJesey.Name = "buttonShowJesey";
            this.buttonShowJesey.Size = new System.Drawing.Size(23, 22);
            this.buttonShowJesey.Text = "Show team jersey";
            this.buttonShowJesey.Click += new System.EventHandler(this.buttonShowJesey_Click);
            // 
            // groupGenericFace
            // 
            this.groupGenericFace.Controls.Add(this.groupGenericFaceType);
            this.groupGenericFace.Controls.Add(this.labelSkinColorInfo);
            this.groupGenericFace.Controls.Add(this.checkHasGenericFace);
            this.groupGenericFace.Controls.Add(this.numericSkinTone);
            this.groupGenericFace.Controls.Add(this.groupHairModel);
            this.groupGenericFace.Controls.Add(this.groupHeadModel);
            this.groupGenericFace.Controls.Add(this.labelHeadType);
            this.groupGenericFace.Controls.Add(this.label1);
            this.groupGenericFace.Controls.Add(this.labelHairType);
            this.groupGenericFace.Location = new System.Drawing.Point(8, 3);
            this.groupGenericFace.Name = "groupGenericFace";
            this.groupGenericFace.Size = new System.Drawing.Size(610, 262);
            this.groupGenericFace.TabIndex = 86;
            this.groupGenericFace.TabStop = false;
            this.groupGenericFace.Text = "Face Modelling";
            // 
            // groupGenericFaceType
            // 
            this.groupGenericFaceType.Controls.Add(this.labelFacialHair);
            this.groupGenericFaceType.Controls.Add(this.labelEyeBow);
            this.groupGenericFaceType.Controls.Add(this.domainFacialHair);
            this.groupGenericFaceType.Controls.Add(this.comboEyeBow);
            this.groupGenericFaceType.Controls.Add(this.labelSideburns);
            this.groupGenericFaceType.Controls.Add(this.comboSideburns);
            this.groupGenericFaceType.Controls.Add(this.labelSkintype);
            this.groupGenericFaceType.Controls.Add(this.comboSkintype);
            this.groupGenericFaceType.Controls.Add(this.comboFacialHairColor);
            this.groupGenericFaceType.Controls.Add(this.labelFacialHairColor);
            this.groupGenericFaceType.Location = new System.Drawing.Point(381, 39);
            this.groupGenericFaceType.Name = "groupGenericFaceType";
            this.groupGenericFaceType.Size = new System.Drawing.Size(200, 217);
            this.groupGenericFaceType.TabIndex = 35;
            this.groupGenericFaceType.TabStop = false;
            this.groupGenericFaceType.Text = "Face Type";
            // 
            // labelFacialHair
            // 
            this.labelFacialHair.AutoSize = true;
            this.labelFacialHair.BackColor = System.Drawing.Color.Transparent;
            this.labelFacialHair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelFacialHair.Location = new System.Drawing.Point(6, 123);
            this.labelFacialHair.Name = "labelFacialHair";
            this.labelFacialHair.Size = new System.Drawing.Size(57, 13);
            this.labelFacialHair.TabIndex = 15;
            this.labelFacialHair.Text = "Facial Hair";
            this.labelFacialHair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelEyeBow
            // 
            this.labelEyeBow.AutoSize = true;
            this.labelEyeBow.BackColor = System.Drawing.Color.Transparent;
            this.labelEyeBow.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelEyeBow.Location = new System.Drawing.Point(6, 90);
            this.labelEyeBow.Name = "labelEyeBow";
            this.labelEyeBow.Size = new System.Drawing.Size(57, 13);
            this.labelEyeBow.TabIndex = 33;
            this.labelEyeBow.Text = "Eyes Brow";
            this.labelEyeBow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // domainFacialHair
            // 
            this.domainFacialHair.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.domainFacialHair.FormattingEnabled = true;
            this.domainFacialHair.Items.AddRange(new object[] {
            "none",
            "chin beard",
            "chin courtain",
            "goatie",
            "full beard",
            "mustache",
            "stubble",
            "soul patch"});
            this.domainFacialHair.Location = new System.Drawing.Point(77, 120);
            this.domainFacialHair.Name = "domainFacialHair";
            this.domainFacialHair.Size = new System.Drawing.Size(111, 21);
            this.domainFacialHair.TabIndex = 4;
            this.domainFacialHair.SelectedIndexChanged += new System.EventHandler(this.domainFacialHair_SelectedItemChanged);
            // 
            // comboEyeBow
            // 
            this.comboEyeBow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEyeBow.FormattingEnabled = true;
            this.comboEyeBow.Items.AddRange(new object[] {
            "Normal",
            "Big",
            "Thin"});
            this.comboEyeBow.Location = new System.Drawing.Point(77, 87);
            this.comboEyeBow.Name = "comboEyeBow";
            this.comboEyeBow.Size = new System.Drawing.Size(111, 21);
            this.comboEyeBow.TabIndex = 3;
            this.comboEyeBow.SelectedIndexChanged += new System.EventHandler(this.comboEyeBow_SelectedIndexChanged);
            // 
            // labelSideburns
            // 
            this.labelSideburns.AutoSize = true;
            this.labelSideburns.BackColor = System.Drawing.Color.Transparent;
            this.labelSideburns.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelSideburns.Location = new System.Drawing.Point(6, 191);
            this.labelSideburns.Name = "labelSideburns";
            this.labelSideburns.Size = new System.Drawing.Size(54, 13);
            this.labelSideburns.TabIndex = 23;
            this.labelSideburns.Text = "Sideburns";
            this.labelSideburns.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboSideburns
            // 
            this.comboSideburns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSideburns.FormattingEnabled = true;
            this.comboSideburns.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.comboSideburns.Location = new System.Drawing.Point(77, 188);
            this.comboSideburns.Name = "comboSideburns";
            this.comboSideburns.Size = new System.Drawing.Size(111, 21);
            this.comboSideburns.TabIndex = 6;
            this.comboSideburns.SelectedIndexChanged += new System.EventHandler(this.comboSideburns_SelectedIndexChanged);
            // 
            // labelSkintype
            // 
            this.labelSkintype.AutoSize = true;
            this.labelSkintype.BackColor = System.Drawing.Color.Transparent;
            this.labelSkintype.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelSkintype.Location = new System.Drawing.Point(6, 54);
            this.labelSkintype.Name = "labelSkintype";
            this.labelSkintype.Size = new System.Drawing.Size(55, 13);
            this.labelSkintype.TabIndex = 21;
            this.labelSkintype.Text = "Skin Type";
            this.labelSkintype.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboSkintype
            // 
            this.comboSkintype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSkintype.FormattingEnabled = true;
            this.comboSkintype.Items.AddRange(new object[] {
            "Clean",
            "Freckled",
            "Rough"});
            this.comboSkintype.Location = new System.Drawing.Point(77, 51);
            this.comboSkintype.Name = "comboSkintype";
            this.comboSkintype.Size = new System.Drawing.Size(111, 21);
            this.comboSkintype.TabIndex = 1;
            this.comboSkintype.SelectedIndexChanged += new System.EventHandler(this.comboSkintype_SelectedIndexChanged);
            // 
            // comboFacialHairColor
            // 
            this.comboFacialHairColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFacialHairColor.FormattingEnabled = true;
            this.comboFacialHairColor.Items.AddRange(new object[] {
            "black",
            "blonde",
            "darker brown",
            "lighter brown",
            "red"});
            this.comboFacialHairColor.Location = new System.Drawing.Point(77, 154);
            this.comboFacialHairColor.Name = "comboFacialHairColor";
            this.comboFacialHairColor.Size = new System.Drawing.Size(111, 21);
            this.comboFacialHairColor.TabIndex = 5;
            this.comboFacialHairColor.SelectedIndexChanged += new System.EventHandler(this.comboFacialHairColor_SelectedIndexChanged);
            // 
            // labelFacialHairColor
            // 
            this.labelFacialHairColor.AutoSize = true;
            this.labelFacialHairColor.BackColor = System.Drawing.Color.Transparent;
            this.labelFacialHairColor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelFacialHairColor.Location = new System.Drawing.Point(6, 157);
            this.labelFacialHairColor.Name = "labelFacialHairColor";
            this.labelFacialHairColor.Size = new System.Drawing.Size(31, 13);
            this.labelFacialHairColor.TabIndex = 17;
            this.labelFacialHairColor.Text = "Color";
            this.labelFacialHairColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSkinColorInfo
            // 
            this.labelSkinColorInfo.AutoSize = true;
            this.labelSkinColorInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelSkinColorInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelSkinColorInfo.Location = new System.Drawing.Point(457, 17);
            this.labelSkinColorInfo.Name = "labelSkinColorInfo";
            this.labelSkinColorInfo.Size = new System.Drawing.Size(0, 13);
            this.labelSkinColorInfo.TabIndex = 121;
            this.labelSkinColorInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkHasGenericFace
            // 
            this.checkHasGenericFace.AutoSize = true;
            this.checkHasGenericFace.Location = new System.Drawing.Point(154, 17);
            this.checkHasGenericFace.Name = "checkHasGenericFace";
            this.checkHasGenericFace.Size = new System.Drawing.Size(112, 17);
            this.checkHasGenericFace.TabIndex = 0;
            this.checkHasGenericFace.Text = "Has Generic Face";
            this.checkHasGenericFace.UseVisualStyleBackColor = true;
            this.checkHasGenericFace.CheckedChanged += new System.EventHandler(this.checkHasGenericFace_CheckedChanged);
            // 
            // numericSkinTone
            // 
            this.numericSkinTone.Location = new System.Drawing.Point(381, 13);
            this.numericSkinTone.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericSkinTone.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericSkinTone.Name = "numericSkinTone";
            this.numericSkinTone.Size = new System.Drawing.Size(61, 20);
            this.numericSkinTone.TabIndex = 120;
            this.numericSkinTone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericSkinTone.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericSkinTone.ValueChanged += new System.EventHandler(this.numericSkinTone_ValueChanged);
            // 
            // groupHairModel
            // 
            this.groupHairModel.Controls.Add(this.comboHeadband);
            this.groupHairModel.Controls.Add(this.comboAfro);
            this.groupHairModel.Controls.Add(this.comboLong);
            this.groupHairModel.Controls.Add(this.comboMedium);
            this.groupHairModel.Controls.Add(this.comboModern);
            this.groupHairModel.Controls.Add(this.labelHairColor);
            this.groupHairModel.Controls.Add(this.domainHairColor);
            this.groupHairModel.Controls.Add(this.comboShort);
            this.groupHairModel.Controls.Add(this.comboVeryShort);
            this.groupHairModel.Controls.Add(this.comboShaven);
            this.groupHairModel.Controls.Add(this.radioHeadband);
            this.groupHairModel.Controls.Add(this.radioShaven);
            this.groupHairModel.Controls.Add(this.radioAfro);
            this.groupHairModel.Controls.Add(this.radioLong);
            this.groupHairModel.Controls.Add(this.radioMedium);
            this.groupHairModel.Controls.Add(this.radioModern);
            this.groupHairModel.Controls.Add(this.radioShort);
            this.groupHairModel.Controls.Add(this.radioVeryShort);
            this.groupHairModel.Location = new System.Drawing.Point(6, 124);
            this.groupHairModel.Name = "groupHairModel";
            this.groupHairModel.Size = new System.Drawing.Size(364, 132);
            this.groupHairModel.TabIndex = 29;
            this.groupHairModel.TabStop = false;
            this.groupHairModel.Text = "Hair Model and Color";
            // 
            // comboHeadband
            // 
            this.comboHeadband.FormattingEnabled = true;
            this.comboHeadband.Location = new System.Drawing.Point(6, 73);
            this.comboHeadband.Name = "comboHeadband";
            this.comboHeadband.Size = new System.Drawing.Size(260, 21);
            this.comboHeadband.TabIndex = 0;
            this.comboHeadband.Visible = false;
            this.comboHeadband.SelectedIndexChanged += new System.EventHandler(this.comboHeadband_SelectedIndexChanged);
            // 
            // comboAfro
            // 
            this.comboAfro.FormattingEnabled = true;
            this.comboAfro.Items.AddRange(new object[] {
            "71",
            "4",
            "42",
            "27",
            "5",
            "6",
            "96",
            "3"});
            this.comboAfro.Location = new System.Drawing.Point(6, 73);
            this.comboAfro.Name = "comboAfro";
            this.comboAfro.Size = new System.Drawing.Size(260, 21);
            this.comboAfro.TabIndex = 29;
            this.comboAfro.Visible = false;
            this.comboAfro.SelectedIndexChanged += new System.EventHandler(this.comboAfro_SelectedIndexChanged);
            // 
            // comboLong
            // 
            this.comboLong.FormattingEnabled = true;
            this.comboLong.Items.AddRange(new object[] {
            "8",
            "9",
            "15",
            "44",
            "84",
            "34",
            "10",
            "33",
            "12",
            "80",
            "11",
            "51",
            "79",
            "53",
            "7",
            "48"});
            this.comboLong.Location = new System.Drawing.Point(6, 73);
            this.comboLong.Name = "comboLong";
            this.comboLong.Size = new System.Drawing.Size(260, 21);
            this.comboLong.TabIndex = 28;
            this.comboLong.Visible = false;
            this.comboLong.SelectedIndexChanged += new System.EventHandler(this.comboLong_SelectedIndexChanged);
            // 
            // comboMedium
            // 
            this.comboMedium.FormattingEnabled = true;
            this.comboMedium.Items.AddRange(new object[] {
            "36",
            "74",
            "13",
            "35",
            "59",
            "69",
            "73",
            "85",
            "93",
            "32",
            "66",
            "67",
            "68",
            "14",
            "20",
            "23",
            "58",
            "62",
            "83",
            "95",
            "22",
            "52",
            "87",
            "98",
            "99",
            "100",
            "103"});
            this.comboMedium.Location = new System.Drawing.Point(6, 73);
            this.comboMedium.Name = "comboMedium";
            this.comboMedium.Size = new System.Drawing.Size(260, 21);
            this.comboMedium.TabIndex = 27;
            this.comboMedium.Visible = false;
            this.comboMedium.SelectedIndexChanged += new System.EventHandler(this.comboMedium_SelectedIndexChanged);
            // 
            // comboModern
            // 
            this.comboModern.FormattingEnabled = true;
            this.comboModern.Items.AddRange(new object[] {
            "17",
            "18",
            "19",
            "24",
            "39",
            "60",
            "61",
            "63",
            "64",
            "86",
            "88",
            "89",
            "94"});
            this.comboModern.Location = new System.Drawing.Point(6, 73);
            this.comboModern.Name = "comboModern";
            this.comboModern.Size = new System.Drawing.Size(260, 21);
            this.comboModern.TabIndex = 26;
            this.comboModern.Visible = false;
            this.comboModern.SelectedIndexChanged += new System.EventHandler(this.comboModern_SelectedIndexChanged);
            // 
            // labelHairColor
            // 
            this.labelHairColor.AutoSize = true;
            this.labelHairColor.BackColor = System.Drawing.Color.Transparent;
            this.labelHairColor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelHairColor.Location = new System.Drawing.Point(6, 107);
            this.labelHairColor.Name = "labelHairColor";
            this.labelHairColor.Size = new System.Drawing.Size(53, 13);
            this.labelHairColor.TabIndex = 13;
            this.labelHairColor.Text = "Hair Color";
            this.labelHairColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // domainHairColor
            // 
            this.domainHairColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.domainHairColor.FormattingEnabled = true;
            this.domainHairColor.Items.AddRange(new object[] {
            "Blonde",
            "Black",
            "Ash Blonde",
            "Dark Brown",
            "Platinum Blonde",
            "Light Brown",
            "Brown",
            "Red",
            "White",
            "Gray",
            "Green",
            "Violet",
            "Intense Red"});
            this.domainHairColor.Location = new System.Drawing.Point(71, 103);
            this.domainHairColor.Name = "domainHairColor";
            this.domainHairColor.Size = new System.Drawing.Size(195, 21);
            this.domainHairColor.TabIndex = 1;
            this.domainHairColor.SelectedIndexChanged += new System.EventHandler(this.domainHairColor_SelectedIndexChanged);
            // 
            // comboShort
            // 
            this.comboShort.FormattingEnabled = true;
            this.comboShort.Items.AddRange(new object[] {
            "2",
            "21",
            "22",
            "30",
            "38",
            "54",
            "57",
            "70",
            "75",
            "78",
            "82",
            "97",
            "101",
            "102",
            "104",
            "105",
            "106",
            "107",
            "108",
            "109",
            "110",
            "111",
            "112"});
            this.comboShort.Location = new System.Drawing.Point(6, 73);
            this.comboShort.Name = "comboShort";
            this.comboShort.Size = new System.Drawing.Size(260, 21);
            this.comboShort.TabIndex = 25;
            this.comboShort.Visible = false;
            this.comboShort.SelectedIndexChanged += new System.EventHandler(this.comboShort_SelectedIndexChanged);
            // 
            // comboVeryShort
            // 
            this.comboVeryShort.FormattingEnabled = true;
            this.comboVeryShort.Items.AddRange(new object[] {
            "26",
            "29",
            "47",
            "72",
            "92",
            "16",
            "28",
            "31",
            "37",
            "40",
            "45",
            "65",
            "77",
            "90"});
            this.comboVeryShort.Location = new System.Drawing.Point(6, 73);
            this.comboVeryShort.Name = "comboVeryShort";
            this.comboVeryShort.Size = new System.Drawing.Size(260, 21);
            this.comboVeryShort.TabIndex = 24;
            this.comboVeryShort.Visible = false;
            this.comboVeryShort.SelectedIndexChanged += new System.EventHandler(this.comboVeryShort_SelectedIndexChanged);
            // 
            // comboShaven
            // 
            this.comboShaven.FormattingEnabled = true;
            this.comboShaven.Items.AddRange(new object[] {
            "0",
            "25",
            "1",
            "43",
            "41",
            "46"});
            this.comboShaven.Location = new System.Drawing.Point(6, 73);
            this.comboShaven.Name = "comboShaven";
            this.comboShaven.Size = new System.Drawing.Size(260, 21);
            this.comboShaven.TabIndex = 23;
            this.comboShaven.Visible = false;
            this.comboShaven.SelectedIndexChanged += new System.EventHandler(this.comboShaven_SelectedIndexChanged);
            // 
            // radioHeadband
            // 
            this.radioHeadband.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioHeadband.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radioHeadband.Location = new System.Drawing.Point(136, 40);
            this.radioHeadband.Name = "radioHeadband";
            this.radioHeadband.Size = new System.Drawing.Size(65, 23);
            this.radioHeadband.TabIndex = 22;
            this.radioHeadband.TabStop = true;
            this.radioHeadband.Tag = this.comboHeadband;
            this.radioHeadband.Text = "Headband";
            this.radioHeadband.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioHeadband.UseVisualStyleBackColor = true;
            this.radioHeadband.CheckedChanged += new System.EventHandler(this.radioHeadband_CheckedChanged);
            // 
            // radioShaven
            // 
            this.radioShaven.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioShaven.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radioShaven.Location = new System.Drawing.Point(6, 17);
            this.radioShaven.Name = "radioShaven";
            this.radioShaven.Size = new System.Drawing.Size(65, 23);
            this.radioShaven.TabIndex = 21;
            this.radioShaven.TabStop = true;
            this.radioShaven.Tag = this.comboShaven;
            this.radioShaven.Text = "Shaven";
            this.radioShaven.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioShaven.UseVisualStyleBackColor = true;
            this.radioShaven.CheckedChanged += new System.EventHandler(this.radioShaven_CheckedChanged);
            // 
            // radioAfro
            // 
            this.radioAfro.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioAfro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radioAfro.Location = new System.Drawing.Point(201, 40);
            this.radioAfro.Name = "radioAfro";
            this.radioAfro.Size = new System.Drawing.Size(65, 23);
            this.radioAfro.TabIndex = 20;
            this.radioAfro.TabStop = true;
            this.radioAfro.Tag = this.comboAfro;
            this.radioAfro.Text = "Afro";
            this.radioAfro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioAfro.UseVisualStyleBackColor = true;
            this.radioAfro.CheckedChanged += new System.EventHandler(this.radioButtonAfro_CheckedChanged);
            // 
            // radioLong
            // 
            this.radioLong.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioLong.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radioLong.Location = new System.Drawing.Point(71, 40);
            this.radioLong.Name = "radioLong";
            this.radioLong.Size = new System.Drawing.Size(65, 23);
            this.radioLong.TabIndex = 19;
            this.radioLong.TabStop = true;
            this.radioLong.Tag = this.comboLong;
            this.radioLong.Text = "Long";
            this.radioLong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioLong.UseVisualStyleBackColor = true;
            this.radioLong.CheckedChanged += new System.EventHandler(this.radioButtonLong_CheckedChanged);
            // 
            // radioMedium
            // 
            this.radioMedium.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioMedium.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radioMedium.Location = new System.Drawing.Point(6, 40);
            this.radioMedium.Name = "radioMedium";
            this.radioMedium.Size = new System.Drawing.Size(65, 23);
            this.radioMedium.TabIndex = 18;
            this.radioMedium.TabStop = true;
            this.radioMedium.Tag = this.comboMedium;
            this.radioMedium.Text = "Medium";
            this.radioMedium.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioMedium.UseVisualStyleBackColor = true;
            this.radioMedium.CheckedChanged += new System.EventHandler(this.radioButtonMedium_CheckedChanged);
            // 
            // radioModern
            // 
            this.radioModern.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioModern.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radioModern.Location = new System.Drawing.Point(201, 17);
            this.radioModern.Name = "radioModern";
            this.radioModern.Size = new System.Drawing.Size(65, 23);
            this.radioModern.TabIndex = 17;
            this.radioModern.TabStop = true;
            this.radioModern.Tag = this.comboModern;
            this.radioModern.Text = "Modern";
            this.radioModern.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioModern.UseVisualStyleBackColor = true;
            this.radioModern.CheckedChanged += new System.EventHandler(this.radioModern_CheckedChanged);
            // 
            // radioShort
            // 
            this.radioShort.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioShort.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radioShort.Location = new System.Drawing.Point(136, 17);
            this.radioShort.Name = "radioShort";
            this.radioShort.Size = new System.Drawing.Size(65, 23);
            this.radioShort.TabIndex = 16;
            this.radioShort.TabStop = true;
            this.radioShort.Tag = this.comboShort;
            this.radioShort.Text = "Short";
            this.radioShort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioShort.UseVisualStyleBackColor = true;
            this.radioShort.CheckedChanged += new System.EventHandler(this.radioShort_CheckedChanged);
            // 
            // radioVeryShort
            // 
            this.radioVeryShort.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioVeryShort.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radioVeryShort.Location = new System.Drawing.Point(71, 17);
            this.radioVeryShort.Name = "radioVeryShort";
            this.radioVeryShort.Size = new System.Drawing.Size(65, 23);
            this.radioVeryShort.TabIndex = 15;
            this.radioVeryShort.TabStop = true;
            this.radioVeryShort.Tag = this.comboVeryShort;
            this.radioVeryShort.Text = "Very Short";
            this.radioVeryShort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioVeryShort.UseVisualStyleBackColor = true;
            this.radioVeryShort.CheckedChanged += new System.EventHandler(this.radioVeryShort_CheckedChanged);
            // 
            // groupHeadModel
            // 
            this.groupHeadModel.Controls.Add(this.comboLatinModels);
            this.groupHeadModel.Controls.Add(this.radioButtonLatin);
            this.groupHeadModel.Controls.Add(this.comboAsiaticModels);
            this.groupHeadModel.Controls.Add(this.radioButtonAsiatic);
            this.groupHeadModel.Controls.Add(this.comboAfricanModels);
            this.groupHeadModel.Controls.Add(this.radioButtonAfrican);
            this.groupHeadModel.Controls.Add(this.radioButtonCaucasic);
            this.groupHeadModel.Controls.Add(this.comboCaucasicModels);
            this.groupHeadModel.Controls.Add(this.buttonRandomizeAppearance);
            this.groupHeadModel.Location = new System.Drawing.Point(6, 39);
            this.groupHeadModel.Name = "groupHeadModel";
            this.groupHeadModel.Size = new System.Drawing.Size(364, 79);
            this.groupHeadModel.TabIndex = 28;
            this.groupHeadModel.TabStop = false;
            this.groupHeadModel.Text = "Head Model";
            // 
            // comboLatinModels
            // 
            this.comboLatinModels.FormattingEnabled = true;
            this.comboLatinModels.Items.AddRange(new object[] {
            "1500",
            "1501",
            "1502",
            "1503",
            "1504",
            "1505",
            "1506",
            "1507",
            "1508",
            "1509",
            "1510",
            "1511",
            "1512",
            "1513",
            "1514",
            "1515",
            "1516",
            "1517",
            "1518",
            "1519",
            "1520",
            "1521",
            "1522",
            "1523",
            "1524",
            "1525",
            "1526",
            "1527",
            "1528",
            "2500",
            "2501",
            "2502",
            "2503",
            "2504",
            "2505",
            "2506",
            "2507",
            "2508",
            "2509",
            "2510",
            "2511",
            "2512"});
            this.comboLatinModels.Location = new System.Drawing.Point(6, 48);
            this.comboLatinModels.Name = "comboLatinModels";
            this.comboLatinModels.Size = new System.Drawing.Size(260, 21);
            this.comboLatinModels.TabIndex = 0;
            this.comboLatinModels.Visible = false;
            this.comboLatinModels.SelectedIndexChanged += new System.EventHandler(this.comboLatinModels_SelectedIndexChanged);
            // 
            // radioButtonLatin
            // 
            this.radioButtonLatin.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonLatin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radioButtonLatin.Location = new System.Drawing.Point(201, 19);
            this.radioButtonLatin.Name = "radioButtonLatin";
            this.radioButtonLatin.Size = new System.Drawing.Size(65, 23);
            this.radioButtonLatin.TabIndex = 8;
            this.radioButtonLatin.TabStop = true;
            this.radioButtonLatin.Tag = this.comboLatinModels;
            this.radioButtonLatin.Text = "Latin";
            this.radioButtonLatin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonLatin.UseVisualStyleBackColor = true;
            this.radioButtonLatin.CheckedChanged += new System.EventHandler(this.radioButtonLatin_CheckedChanged);
            // 
            // comboAsiaticModels
            // 
            this.comboAsiaticModels.FormattingEnabled = true;
            this.comboAsiaticModels.Items.AddRange(new object[] {
            "500",
            "501",
            "502",
            "503",
            "504",
            "505",
            "506",
            "507",
            "508",
            "509",
            "510",
            "511",
            "512",
            "513",
            "514",
            "515",
            "516",
            "517",
            "518",
            "519",
            "520",
            "521",
            "522",
            "523",
            "524",
            "525",
            "526",
            "527",
            "528",
            "529",
            "530",
            "531",
            "532"});
            this.comboAsiaticModels.Location = new System.Drawing.Point(6, 48);
            this.comboAsiaticModels.Name = "comboAsiaticModels";
            this.comboAsiaticModels.Size = new System.Drawing.Size(254, 21);
            this.comboAsiaticModels.TabIndex = 0;
            this.comboAsiaticModels.Visible = false;
            this.comboAsiaticModels.SelectedIndexChanged += new System.EventHandler(this.comboAsiaticModels_SelectedIndexChanged);
            // 
            // radioButtonAsiatic
            // 
            this.radioButtonAsiatic.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonAsiatic.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radioButtonAsiatic.Location = new System.Drawing.Point(71, 19);
            this.radioButtonAsiatic.Name = "radioButtonAsiatic";
            this.radioButtonAsiatic.Size = new System.Drawing.Size(65, 23);
            this.radioButtonAsiatic.TabIndex = 6;
            this.radioButtonAsiatic.TabStop = true;
            this.radioButtonAsiatic.Tag = this.comboAsiaticModels;
            this.radioButtonAsiatic.Text = "Asiatic";
            this.radioButtonAsiatic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonAsiatic.UseVisualStyleBackColor = true;
            this.radioButtonAsiatic.CheckedChanged += new System.EventHandler(this.radioButtonAsiatic_CheckedChanged);
            // 
            // comboAfricanModels
            // 
            this.comboAfricanModels.FormattingEnabled = true;
            this.comboAfricanModels.Items.AddRange(new object[] {
            "1000",
            "1001",
            "1002",
            "1003",
            "1004",
            "1005",
            "1006",
            "1007",
            "1008",
            "1009",
            "1010",
            "1011",
            "1012",
            "1013",
            "1014",
            "1015",
            "1016",
            "1017",
            "1018",
            "1019",
            "1020",
            "1021",
            "3000",
            "3001",
            "3002",
            "3003",
            "3004",
            "3005",
            "4500",
            "4501",
            "4502",
            "4525",
            "5000",
            "5001",
            "5002",
            "5003"});
            this.comboAfricanModels.Location = new System.Drawing.Point(6, 48);
            this.comboAfricanModels.Name = "comboAfricanModels";
            this.comboAfricanModels.Size = new System.Drawing.Size(254, 21);
            this.comboAfricanModels.TabIndex = 1;
            this.comboAfricanModels.Visible = false;
            this.comboAfricanModels.SelectedIndexChanged += new System.EventHandler(this.comboAfricanModels_SelectedIndexChanged);
            // 
            // radioButtonAfrican
            // 
            this.radioButtonAfrican.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonAfrican.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radioButtonAfrican.Location = new System.Drawing.Point(6, 19);
            this.radioButtonAfrican.Name = "radioButtonAfrican";
            this.radioButtonAfrican.Size = new System.Drawing.Size(65, 23);
            this.radioButtonAfrican.TabIndex = 5;
            this.radioButtonAfrican.TabStop = true;
            this.radioButtonAfrican.Tag = this.comboAfricanModels;
            this.radioButtonAfrican.Text = "African";
            this.radioButtonAfrican.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonAfrican.UseVisualStyleBackColor = true;
            this.radioButtonAfrican.CheckedChanged += new System.EventHandler(this.radioButtonAfrican_CheckedChanged);
            // 
            // radioButtonCaucasic
            // 
            this.radioButtonCaucasic.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonCaucasic.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radioButtonCaucasic.Location = new System.Drawing.Point(136, 19);
            this.radioButtonCaucasic.Name = "radioButtonCaucasic";
            this.radioButtonCaucasic.Size = new System.Drawing.Size(65, 23);
            this.radioButtonCaucasic.TabIndex = 7;
            this.radioButtonCaucasic.TabStop = true;
            this.radioButtonCaucasic.Tag = this.comboCaucasicModels;
            this.radioButtonCaucasic.Text = "Caucasian";
            this.radioButtonCaucasic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonCaucasic.UseVisualStyleBackColor = true;
            this.radioButtonCaucasic.CheckedChanged += new System.EventHandler(this.radioButtonCaucasic_CheckedChanged);
            // 
            // comboCaucasicModels
            // 
            this.comboCaucasicModels.FormattingEnabled = true;
            this.comboCaucasicModels.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "2000",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "3500",
            "3501",
            "3502",
            "3503",
            "3504",
            "3505",
            "4000",
            "4001",
            "4002",
            "4003"});
            this.comboCaucasicModels.Location = new System.Drawing.Point(6, 48);
            this.comboCaucasicModels.Name = "comboCaucasicModels";
            this.comboCaucasicModels.Size = new System.Drawing.Size(254, 21);
            this.comboCaucasicModels.TabIndex = 2;
            this.comboCaucasicModels.Visible = false;
            this.comboCaucasicModels.SelectedIndexChanged += new System.EventHandler(this.comboCaucasicModels_SelectedIndexChanged);
            // 
            // buttonRandomizeAppearance
            // 
            this.buttonRandomizeAppearance.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonRandomizeAppearance.Location = new System.Drawing.Point(272, 20);
            this.buttonRandomizeAppearance.Name = "buttonRandomizeAppearance";
            this.buttonRandomizeAppearance.Size = new System.Drawing.Size(86, 23);
            this.buttonRandomizeAppearance.TabIndex = 27;
            this.buttonRandomizeAppearance.Text = "Randomize";
            this.buttonRandomizeAppearance.UseVisualStyleBackColor = true;
            this.buttonRandomizeAppearance.Click += new System.EventHandler(this.buttonRandomizeAppearance_Click);
            // 
            // labelHeadType
            // 
            this.labelHeadType.BackColor = System.Drawing.SystemColors.Control;
            this.labelHeadType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelHeadType.Location = new System.Drawing.Point(185, 132);
            this.labelHeadType.Name = "labelHeadType";
            this.labelHeadType.Size = new System.Drawing.Size(127, 20);
            this.labelHeadType.TabIndex = 11;
            this.labelHeadType.Text = "Head Model";
            this.labelHeadType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(320, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Skin Color";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelHairType
            // 
            this.labelHairType.BackColor = System.Drawing.SystemColors.Control;
            this.labelHairType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelHairType.Location = new System.Drawing.Point(16, 204);
            this.labelHairType.Name = "labelHairType";
            this.labelHairType.Size = new System.Drawing.Size(119, 20);
            this.labelHairType.TabIndex = 9;
            this.labelHairType.Text = "Hair Model";
            this.labelHairType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.AutoScroll = true;
            this.splitContainer3.Panel1.Controls.Add(this.multiViewerFace);
            this.splitContainer3.Panel1.Controls.Add(this.buttonRgbHair);
            this.splitContainer3.Panel1.Controls.Add(this.viewer2DSkinTexture);
            this.splitContainer3.Panel1.Controls.Add(this.multiViewerHair);
            this.splitContainer3.Panel1.Controls.Add(this.checkShowTexures);
            this.splitContainer3.Panel1.Controls.Add(this.viewer2DEyeTexture);
            this.splitContainer3.Panel1.Controls.Add(this.comboEyescolor);
            this.splitContainer3.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.AutoScroll = true;
            this.splitContainer3.Panel2.Controls.Add(this.viewer2DPlayerGui);
            this.splitContainer3.Size = new System.Drawing.Size(621, 780);
            this.splitContainer3.SplitterDistance = 570;
            this.splitContainer3.TabIndex = 0;
            // 
            // multiViewerFace
            // 
            this.multiViewerFace.AutoTransparency = false;
            this.multiViewerFace.Bitmaps = null;
            this.multiViewerFace.CheckBitmapSize = false;
            this.multiViewerFace.FixedSize = false;
            this.multiViewerFace.FullSizeButton = false;
            this.multiViewerFace.LabelText = "Image n.";
            this.multiViewerFace.Location = new System.Drawing.Point(3, 26);
            this.multiViewerFace.Name = "multiViewerFace";
            this.multiViewerFace.ShowDeleteButton = false;
            this.multiViewerFace.Size = new System.Drawing.Size(256, 301);
            this.multiViewerFace.TabIndex = 101;
            // 
            // buttonRgbHair
            // 
            this.buttonRgbHair.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRgbHair.BackgroundImage")));
            this.buttonRgbHair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonRgbHair.Location = new System.Drawing.Point(502, 302);
            this.buttonRgbHair.Name = "buttonRgbHair";
            this.buttonRgbHair.Size = new System.Drawing.Size(25, 23);
            this.buttonRgbHair.TabIndex = 100;
            this.toolTip.SetToolTip(this.buttonRgbHair, "Modify the RGB components");
            this.buttonRgbHair.UseVisualStyleBackColor = true;
            this.buttonRgbHair.Click += new System.EventHandler(this.buttonRgbHair_Click);
            // 
            // viewer2DSkinTexture
            // 
            this.viewer2DSkinTexture.AutoTransparency = false;
            this.viewer2DSkinTexture.BackColor = System.Drawing.Color.Transparent;
            this.viewer2DSkinTexture.ButtonStripVisible = false;
            this.viewer2DSkinTexture.CurrentBitmap = null;
            this.viewer2DSkinTexture.ExtendedFormat = false;
            this.viewer2DSkinTexture.FullSizeButton = false;
            this.viewer2DSkinTexture.ImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.viewer2DSkinTexture.ImageSize = new System.Drawing.Size(512, 512);
            this.viewer2DSkinTexture.ImageSizeMultiplier = FifaControls.Viewer2D.SizeMultiplier.None;
            this.viewer2DSkinTexture.Location = new System.Drawing.Point(137, 334);
            this.viewer2DSkinTexture.Name = "viewer2DSkinTexture";
            this.viewer2DSkinTexture.RemoveButton = false;
            this.viewer2DSkinTexture.ShowButton = false;
            this.viewer2DSkinTexture.ShowButtonChecked = true;
            this.viewer2DSkinTexture.Size = new System.Drawing.Size(128, 153);
            this.viewer2DSkinTexture.TabIndex = 7;
            // 
            // multiViewerHair
            // 
            this.multiViewerHair.AutoTransparency = false;
            this.multiViewerHair.Bitmaps = null;
            this.multiViewerHair.CheckBitmapSize = false;
            this.multiViewerHair.FixedSize = false;
            this.multiViewerHair.FullSizeButton = false;
            this.multiViewerHair.LabelText = "Image n.";
            this.multiViewerHair.Location = new System.Drawing.Point(271, 26);
            this.multiViewerHair.Name = "multiViewerHair";
            this.multiViewerHair.ShowDeleteButton = false;
            this.multiViewerHair.Size = new System.Drawing.Size(256, 301);
            this.multiViewerHair.TabIndex = 5;
            // 
            // checkShowTexures
            // 
            this.checkShowTexures.AutoSize = true;
            this.checkShowTexures.Location = new System.Drawing.Point(3, 7);
            this.checkShowTexures.Name = "checkShowTexures";
            this.checkShowTexures.Size = new System.Drawing.Size(97, 17);
            this.checkShowTexures.TabIndex = 0;
            this.checkShowTexures.Text = "Show Textures";
            this.checkShowTexures.UseVisualStyleBackColor = true;
            this.checkShowTexures.CheckedChanged += new System.EventHandler(this.checkShowTexures_CheckedChanged);
            // 
            // viewer2DEyeTexture
            // 
            this.viewer2DEyeTexture.AutoTransparency = false;
            this.viewer2DEyeTexture.BackColor = System.Drawing.Color.Transparent;
            this.viewer2DEyeTexture.ButtonStripVisible = false;
            this.viewer2DEyeTexture.CurrentBitmap = null;
            this.viewer2DEyeTexture.ExtendedFormat = false;
            this.viewer2DEyeTexture.FullSizeButton = false;
            this.viewer2DEyeTexture.ImageLayout = System.Windows.Forms.ImageLayout.None;
            this.viewer2DEyeTexture.ImageSize = new System.Drawing.Size(128, 128);
            this.viewer2DEyeTexture.ImageSizeMultiplier = FifaControls.Viewer2D.SizeMultiplier.None;
            this.viewer2DEyeTexture.Location = new System.Drawing.Point(3, 334);
            this.viewer2DEyeTexture.Name = "viewer2DEyeTexture";
            this.viewer2DEyeTexture.RemoveButton = false;
            this.viewer2DEyeTexture.ShowButton = false;
            this.viewer2DEyeTexture.ShowButtonChecked = true;
            this.viewer2DEyeTexture.Size = new System.Drawing.Size(128, 153);
            this.viewer2DEyeTexture.TabIndex = 4;
            // 
            // comboEyescolor
            // 
            this.comboEyescolor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEyescolor.FormattingEnabled = true;
            this.comboEyescolor.Items.AddRange(new object[] {
            "Dark Blue",
            "Light Blue",
            "Dark Brown",
            "Light Brown",
            "Brown and Green",
            "Dark Green",
            "Light Green",
            "Gray",
            "Black",
            "Dark Gray"});
            this.comboEyescolor.Location = new System.Drawing.Point(3, 493);
            this.comboEyescolor.Name = "comboEyescolor";
            this.comboEyescolor.Size = new System.Drawing.Size(128, 21);
            this.comboEyescolor.TabIndex = 2;
            this.comboEyescolor.SelectedIndexChanged += new System.EventHandler(this.comboEyescolor_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(43, 522);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Eyes Color";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // viewer2DPlayerGui
            // 
            this.viewer2DPlayerGui.AutoTransparency = true;
            this.viewer2DPlayerGui.BackColor = System.Drawing.Color.Transparent;
            this.viewer2DPlayerGui.ButtonStripVisible = false;
            this.viewer2DPlayerGui.CurrentBitmap = null;
            this.viewer2DPlayerGui.ExtendedFormat = false;
            this.viewer2DPlayerGui.FullSizeButton = false;
            this.viewer2DPlayerGui.ImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.viewer2DPlayerGui.ImageSize = new System.Drawing.Size(128, 128);
            this.viewer2DPlayerGui.ImageSizeMultiplier = FifaControls.Viewer2D.SizeMultiplier.MiniFace;
            this.viewer2DPlayerGui.Location = new System.Drawing.Point(3, 4);
            this.viewer2DPlayerGui.Name = "viewer2DPlayerGui";
            this.viewer2DPlayerGui.RemoveButton = false;
            this.viewer2DPlayerGui.ShowButton = false;
            this.viewer2DPlayerGui.ShowButtonChecked = true;
            this.viewer2DPlayerGui.Size = new System.Drawing.Size(128, 153);
            this.viewer2DPlayerGui.TabIndex = 126;
            // 
            // imageListTabIcons
            // 
            this.imageListTabIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTabIcons.ImageStream")));
            this.imageListTabIcons.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageListTabIcons.Images.SetKeyName(0, "Info_16.PNG");
            this.imageListTabIcons.Images.SetKeyName(1, "Star_16.PNG");
            this.imageListTabIcons.Images.SetKeyName(2, "Face_16.PNG");
            // 
            // pickUpControl
            // 
            this.pickUpControl.BackColor = System.Drawing.SystemColors.Control;
            this.pickUpControl.CloneButtonEnabled = true;
            this.pickUpControl.CreateButtonEnabled = true;
            this.pickUpControl.CurrentIndex = 0;
            this.pickUpControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pickUpControl.FilterByList = new string[] {
        "All",
        "by Team",
        "by Country",
        "Free Agents",
        "Multi Club",
        "Same Name",
        "Specific Head"};
            this.pickUpControl.FilterEnabled = true;
            this.pickUpControl.FilterValues = null;
            this.pickUpControl.Location = new System.Drawing.Point(0, 0);
            this.pickUpControl.MainSelectionEnabled = true;
            this.pickUpControl.Name = "pickUpControl";
            this.pickUpControl.ObjectList = null;
            this.pickUpControl.RefreshButtonEnabled = true;
            this.pickUpControl.RemoveButtonEnabled = true;
            this.pickUpControl.SearchEnabled = true;
            this.pickUpControl.Size = new System.Drawing.Size(1357, 25);
            this.pickUpControl.TabIndex = 0;
            this.pickUpControl.WizardButtonEnabled = false;
            this.pickUpControl.YoungPlayersEnabled = false;
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 832);
            this.Controls.Add(this.tabEditPlayer);
            this.Controls.Add(this.pickUpControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PlayerForm";
            this.Text = "PlayerForm";
            this.Load += new System.EventHandler(this.PlayerForm_Load);
            this.tabEditPlayer.ResumeLayout(false);
            this.pageInfo.ResumeLayout(false);
            this.flowPanelInfo.ResumeLayout(false);
            this.groupPlayerIdentity.ResumeLayout(false);
            this.groupPlayerIdentity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPlayerId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryListBindingSource)).EndInit();
            this.groupBoxBody.ResumeLayout(false);
            this.groupBoxBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWeight)).EndInit();
            this.groupBoxLook.ResumeLayout(false);
            this.groupBoxLook.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericGkGloves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureColorAcc2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureColorAcc3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureColorAcc4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureColorAcc1)).EndInit();
            this.groupPlayFirTeam.ResumeLayout(false);
            this.groupPlayFirTeam.PerformLayout();
            this.groupIsLoan.ResumeLayout(false);
            this.groupIsLoan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teamListBindingSource)).EndInit();
            this.groupShoes.ResumeLayout(false);
            this.groupShoes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureColorShoes2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureColorShoes1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericShoesBrand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericShoesDesign)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pageSkills.ResumeLayout(false);
            this.flowPanelSkills.ResumeLayout(false);
            this.groupGenerateAttributes.ResumeLayout(false);
            this.groupGenerateAttributes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackOverallrating)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRandomize)).EndInit();
            this.groupGoalkeperSkills.ResumeLayout(false);
            this.groupGoalkeperSkills.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackGkKicking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackDiving)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPositioning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackReflexes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackHandling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGoalkeeperSkills)).EndInit();
            this.groupDefensiveSkills.ResumeLayout(false);
            this.groupDefensiveSkills.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackInterception)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSliding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDefensiveSkills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTackling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackMarking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAggression)).EndInit();
            this.groupMidfielderSkills.ResumeLayout(false);
            this.groupMidfielderSkills.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackCurve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackVision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMidfielderSkills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackLongPassing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackShortPassing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBallControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackCrossing)).EndInit();
            this.groupMental.ResumeLayout(false);
            this.groupMental.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericEmotion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMentalSkills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPlayerPositioning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPotential)).EndInit();
            this.groupAttackingSkills.ResumeLayout(false);
            this.groupAttackingSkills.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackHeading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackVolley)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAttackingSkills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackFinishing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackShotPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackLongShot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackDribbling)).EndInit();
            this.groupGenericAttributes.ResumeLayout(false);
            this.groupGenericAttributes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAgility)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPhysicalSkills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackStamina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSprintSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAcceleration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackStrength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackReactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackJumping)).EndInit();
            this.groupFreeKick.ResumeLayout(false);
            this.groupFreeKick.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSkillMoves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFreeKickSkills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackFreeKick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPenalties)).EndInit();
            this.groupTraits.ResumeLayout(false);
            this.groupTraits.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pageFace.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tool3D.ResumeLayout(false);
            this.tool3D.PerformLayout();
            this.groupGenericFace.ResumeLayout(false);
            this.groupGenericFace.PerformLayout();
            this.groupGenericFaceType.ResumeLayout(false);
            this.groupGenericFaceType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSkinTone)).EndInit();
            this.groupHairModel.ResumeLayout(false);
            this.groupHairModel.PerformLayout();
            this.groupHeadModel.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public PlayerForm()
        {
            this.Visible = false;
            this.InitializeComponent();
            //this.viewer3D.RotationYCoeff = 1f / 1000f;
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
            //Kit.Prepare3DModels();
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
                    /*Player.s_Model3DHead = (Model3D)null;
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
                    }*/
                    this.ShowHead3D();
                }
            }
        }

        private void ShowHead3D()
        {
            int nMeshes = 2;
            //if (Player.s_Model3DHairPart4 != null)
            //    nMeshes = 3;
            //if (Player.s_Model3DHairPart5 != null)
            //    nMeshes = 4;
           
            /*Kit kit = (Kit)null;
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
            }*/
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
            /*if (Player.s_Model3DHairPart4 != null)
                Player.s_Model3DHairPart4.MoveForward();
            if (Player.s_Model3DHairPart5 != null)
                Player.s_Model3DHairPart5.MoveForward();
            this.buttonSaveHair.Enabled = true;
            this.ShowHead3D();*/
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            /*if (Player.s_Model3DHairPart4 != null)
                Player.s_Model3DHairPart4.MoveBack();
            if (Player.s_Model3DHairPart5 != null)
                Player.s_Model3DHairPart5.MoveBack();
            this.buttonSaveHair.Enabled = true;
            this.ShowHead3D();*/
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            /*if (Player.s_Model3DHairPart4 != null)
                Player.s_Model3DHairPart4.MoveUp();
            if (Player.s_Model3DHairPart5 != null)
                Player.s_Model3DHairPart5.MoveUp();
            this.buttonSaveHair.Enabled = true;
            this.ShowHead3D();*/
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            /*if (Player.s_Model3DHairPart4 != null)
                Player.s_Model3DHairPart4.MoveDown();
            if (Player.s_Model3DHairPart5 != null)
                Player.s_Model3DHairPart5.MoveDown();
            this.buttonSaveHair.Enabled = true;
            this.ShowHead3D();*/
        }

        private void buttonSaveHair_Click(object sender, EventArgs e)
        {
            /*CustomVertex.PositionNormalTextured[] newVertex4 = (CustomVertex.PositionNormalTextured[])null;
            CustomVertex.PositionNormalTextured[] newVertex5 = (CustomVertex.PositionNormalTextured[])null;
            if (Player.s_Model3DHairPart4 != null)
                newVertex4 = Player.s_Model3DHairPart4.Vertex;
            if (Player.s_Model3DHairPart5 != null)
                newVertex5 = Player.s_Model3DHairPart5.Vertex;
            this.m_CurrentPlayer.UpdateHairVertex(newVertex4, newVertex5);
            this.buttonSaveHair.Enabled = false;*/
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
            /*if (Player.s_Model3DHairPart4 != null)
                Player.s_Model3DHairPart4.MoveLeft();
            if (Player.s_Model3DHairPart5 != null)
                Player.s_Model3DHairPart5.MoveLeft();
            this.buttonSaveHair.Enabled = true;
            this.ShowHead3D();*/
        }

        private void buttonMoveHairRight_Click(object sender, EventArgs e)
        {
            /*if (Player.s_Model3DHairPart4 != null)
                Player.s_Model3DHairPart4.MoveRight();
            if (Player.s_Model3DHairPart5 != null)
                Player.s_Model3DHairPart5.MoveRight();
            this.buttonSaveHair.Enabled = true;
            this.ShowHead3D();*/
        }

        private void buttonMakeHairCloser_Click(object sender, EventArgs e)
        {
            /*if (Player.s_Model3DHairPart4 != null)
                Player.s_Model3DHairPart4.MakeCloser();
            if (Player.s_Model3DHairPart5 != null)
                Player.s_Model3DHairPart5.MakeCloser();
            this.buttonSaveHair.Enabled = true;
            this.ShowHead3D();*/
        }

        private void buttonMakeHairWider_Click(object sender, EventArgs e)
        {
            /*if (Player.s_Model3DHairPart4 != null)
                Player.s_Model3DHairPart4.MakeWider();
            if (Player.s_Model3DHairPart5 != null)
                Player.s_Model3DHairPart5.MakeWider();
            this.buttonSaveHair.Enabled = true;
            this.ShowHead3D();*/
        }

        private void radioFemale_CheckedChanged(object sender, EventArgs e)
        {
            /*if (this.comboFemaleModels.SelectedIndex < 0)
              this.comboFemaleModels.SelectedIndex = 0;
            this.comboFemaleModels.Visible = this.radioButtonFemale.Checked;
            if (this.radioButtonFemale.Checked)
            {
              this.radioButtonFemale.BackColor = Color.LightSkyBlue;
              if (this.m_CurrentPlayer.headtypecode == GenericHead.c_FemaleModels[this.comboFemaleModels.SelectedIndex])
                return;
              this.m_CurrentPlayer.headtypecode = GenericHead.c_FemaleModels[this.comboFemaleModels.SelectedIndex];
              if (!this.m_GenericAppearanceSema || !this.buttonShow3DModel.Checked || this.m_CurrentPlayer.HasSpecificHeadModel)
                return;
              this.UpdateAndShowHead3D();
            }
            else
              this.radioButtonFemale.BackColor = Color.Transparent;*/
        }
    }
}
