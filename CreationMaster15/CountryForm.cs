// Original code created by Rinaldo

using FifaControls;
using FifaLibrary;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CreationMaster
{
  public class CountryForm : Form
  {
    private static Random m_Randomizer = new Random();
    private string m_NotPresent = "< Not Present >";
    private NewIdCreator m_NewIdCreator = new NewIdCreator();
    private Country m_CurrentCountry;
    private bool m_IsNationalTeamLocked;
    private bool m_IsLoaded;
    private bool m_LockUserChanges;
    private IContainer components;
    private FlowLayoutPanel flowLayoutPanel;
    private GroupBox groupBox;
    private NumericUpDown numericCountryId;
    private ComboBox comboContinent;
    private TextBox textLanguageName;
    private Label labelLanguageName;
    private TextBox textDatabaseCountryName;
    private Label labelDatabaseCountryName;
    private Label labelContinent;
    private Label labelCountrId;
    private Viewer2D viewer2DFlag;
    private Viewer2D viewer2DMiniFlag;
    private ToolTip toolTip;
    private NumericUpDown numericNationalTeam;
    private ComboBox comboNationalTeam;
    private PictureBox pictureNationalTeam;
    private Label labelNationalTeam;
    private Button buttonGetId;
    public PickUpControl pickUpControl;
    private BindingSource countryBindingSource;
    private BindingSource sponsorListBindingSource;
    private GroupBox groupAudio;
    private Label label10;
    private ComboBox comboChants;
    private Label label9;
    private Label label15;
    private Label label14;
    private Label label11;
    private ComboBox comboLanguage;
    private CheckBox checkCanWhistle;
    private CheckBox checkTauntKeeper;
    private ComboBox comboPlayerCall;
    private ComboBox comboCrowdType;
    private ComboBox comboPepper;
    private CheckBox checkTopTier;
    private Viewer2D viewer2DCardFlag;
    private Label label3;
    private Label label2;
    private Label label1;
    private GroupBox groupCountryShape;
    private Viewer2D viewer2DShape;
    private ComboBox comboRegionalTarget;
    private ComboBox comboWorkltarget;
    private Label labeRegionalTarget;
    private Label labelWorldTarget;
    private Label label4;
    private NumericUpDown numericLevel;
    private Label labelContry3Letters;
    private TextBox textLanguageAbbreviation;
    private TextBox textLanguageShortName;
    private Label labelNationShortName;
    private Viewer2D viewer2DFlag512;

    public CountryForm()
    {
      this.Visible = false;
      this.InitializeComponent();
      this.pickUpControl.SelectObject = new PickUpControl.PickUpCallback(this.SelectCountry);
      this.pickUpControl.CreateObject = new PickUpControl.PickUpCallback(this.CreateCountry);
      this.pickUpControl.DeleteObject = new PickUpControl.PickUpCallback(this.DeleteCountry);
      this.pickUpControl.RefreshObject = new PickUpControl.PickUpCallback(this.RefreshCountry);
      this.viewer2DFlag.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageFlag);
      this.viewer2DFlag.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteFlag);
      this.viewer2DFlag.ButtonStripVisible = true;
      this.viewer2DFlag.RemoveButton = true;
      this.viewer2DFlag512.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageFlag512);
      this.viewer2DFlag512.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteFlag512);
      this.viewer2DFlag512.ButtonStripVisible = true;
      this.viewer2DFlag512.RemoveButton = true;
      this.viewer2DMiniFlag.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageMiniFlag);
      this.viewer2DMiniFlag.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteMiniFlag);
      this.viewer2DMiniFlag.ButtonStripVisible = true;
      this.viewer2DMiniFlag.RemoveButton = true;
      this.viewer2DCardFlag.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageCardFlag);
      this.viewer2DCardFlag.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteCardFlag);
      this.viewer2DCardFlag.ButtonStripVisible = true;
      this.viewer2DCardFlag.RemoveButton = true;
      this.viewer2DShape.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageShape);
      this.viewer2DShape.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteShape);
      this.viewer2DShape.ButtonStripVisible = true;
      this.viewer2DShape.RemoveButton = true;
    }

    public void Clean()
    {
      this.Visible = false;
    }

    public void Preset()
    {
      this.m_NewIdCreator.IdList = (IdArrayList) FifaEnvironment.Countries;
      this.comboNationalTeam.Items.Clear();
      this.comboNationalTeam.BeginUpdate();
      this.comboNationalTeam.Items.Add((object) this.m_NotPresent);
      this.comboNationalTeam.Items.AddRange(FifaEnvironment.Teams.ToArray());
      int maxValue = FifaEnvironment.FifaDb.Table[TI.players].TableDescriptor.MaxValues[FI.players_nationality];
      if (maxValue < (int) byte.MaxValue)
        maxValue = (int) byte.MaxValue;
      this.numericCountryId.Maximum = (Decimal) maxValue;
      this.comboNationalTeam.EndUpdate();
      this.pickUpControl.ObjectList = (IdArrayList) FifaEnvironment.Countries;
    }

    public void ReloadCountry(Country country)
    {
      this.m_CurrentCountry = (Country) null;
      this.LoadCountry(country);
    }

    public void LoadCountry(Country country)
    {
      if (!this.m_IsLoaded || this.m_CurrentCountry == country)
        return;
      this.m_LockUserChanges = true;
      this.m_CurrentCountry = country;
      this.countryBindingSource.DataSource = (object) this.m_CurrentCountry;
      this.viewer2DFlag.CurrentBitmap = this.m_CurrentCountry.GetFlag();
      this.viewer2DFlag512.CurrentBitmap = this.m_CurrentCountry.GetFlag512();
      this.viewer2DMiniFlag.CurrentBitmap = this.m_CurrentCountry.GetMiniFlag();
      this.viewer2DCardFlag.CurrentBitmap = this.m_CurrentCountry.GetCardFlag();
      this.viewer2DShape.CurrentBitmap = this.m_CurrentCountry.GetShape();
      this.pictureNationalTeam.BackgroundImage = this.m_CurrentCountry.NationalTeam != null ? (Image) this.m_CurrentCountry.NationalTeam.GetCrest() : (Image) null;
      GC.Collect();
      this.m_LockUserChanges = false;
    }

    private Country SelectCountry(object sender, object obj)
    {
      Country country = (Country) obj;
      this.Refresh();
      this.LoadCountry(country);
      return country;
    }

    private Country CreateCountry(object sender, object obj)
    {
      DialogResult dialogResult = this.m_NewIdCreator.ShowDialog();
      if (this.m_NewIdCreator.NewObject != null)
        return (Country) this.m_NewIdCreator.NewObject;
      if (dialogResult == DialogResult.OK)
      {
        int num = (int) FifaEnvironment.UserMessages.ShowMessage(5060, this.m_NewIdCreator.NewId);
      }
      return (Country) null;
    }

    private Country DeleteCountry(object sender, object obj)
    {
      Country country = (Country) obj;
      FifaEnvironment.Countries.DeleteCountry(country);
      FifaEnvironment.Language.RemoveCountryString(country.Id, Language.ECountryStringType.Full);
      return (Country) null;
    }

    private Country CloneCountry(object sender, object obj)
    {
      return (Country) FifaEnvironment.Countries.CloneId((IdObject) obj);
    }

    public Country RefreshCountry(object sender, object obj)
    {
      this.Preset();
      this.ReloadCountry(this.m_CurrentCountry);
      return this.m_CurrentCountry;
    }

    private bool ImportImageFlag(object sender, Bitmap bitmap)
    {
      return this.m_CurrentCountry.SetFlag(bitmap);
    }

    private bool DeleteFlag(object sender)
    {
      return this.m_CurrentCountry.DeleteFlag();
    }

    private bool ImportImageFlag512(object sender, Bitmap bitmap)
    {
      return this.m_CurrentCountry.SetFlag512(bitmap);
    }

    private bool DeleteFlag512(object sender)
    {
      return this.m_CurrentCountry.DeleteFlag512();
    }

    private bool ImportImageMiniFlag(object sender, Bitmap bitmap)
    {
      return this.m_CurrentCountry.SetMiniFlag(bitmap);
    }

    private bool DeleteMiniFlag(object sender)
    {
      return this.m_CurrentCountry.DeleteMiniFlag();
    }

    private bool ImportImageCardFlag(object sender, Bitmap bitmap)
    {
      return this.m_CurrentCountry.SetCardFlag(bitmap);
    }

    private bool DeleteCardFlag(object sender)
    {
      return this.m_CurrentCountry.DeleteCardFlag();
    }

    private bool ImportImageShape(object sender, Bitmap bitmap)
    {
      return this.m_CurrentCountry.SetShape(bitmap);
    }

    private bool DeleteShape(object sender)
    {
      return this.m_CurrentCountry.DeleteShape();
    }

    private void textLanguageName_TextChanged(object sender, EventArgs e)
    {
      if (this.m_LockUserChanges)
        return;
      this.m_CurrentCountry.LanguageName = this.textLanguageName.Text;
      this.pickUpControl.SwitchObject((IdObject) this.m_CurrentCountry);
    }

    private void numericCountryId_ValueChanged(object sender, EventArgs e)
    {
      int num1 = (int) this.numericCountryId.Value;
      if (num1 == this.m_CurrentCountry.Id)
        return;
      if (FifaEnvironment.Countries.SearchId(num1) == null)
      {
        FifaEnvironment.Countries.ChangeId((IdObject) this.m_CurrentCountry, num1);
        this.ReloadCountry(this.m_CurrentCountry);
      }
      else
      {
        int num2 = (int) FifaEnvironment.UserMessages.ShowMessage(1015);
        this.numericCountryId.Value = (Decimal) this.m_CurrentCountry.Id;
      }
    }

    private void buttonGetId_Click(object sender, EventArgs e)
    {
      int newId = FifaEnvironment.Countries.GetNewId();
      if (newId == -1)
      {
        int num = (int) FifaEnvironment.UserMessages.ShowMessage(5050);
      }
      else
        this.numericCountryId.Value = (Decimal) newId;
    }

    private void numericNationalTeam_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_IsNationalTeamLocked)
        return;
      this.m_IsNationalTeamLocked = true;
      int num1 = (int) this.numericNationalTeam.Value;
      Team nationalTeam = (Team) FifaEnvironment.Teams.SearchId(num1);
      this.comboNationalTeam.SelectedItem = nationalTeam == null ? (object) this.m_NotPresent : (object) nationalTeam;
      if (num1 == this.m_CurrentCountry.NationalTeamId)
        this.m_IsNationalTeamLocked = false;
      else if (num1 > 0 && FifaEnvironment.Countries.SearchNationalTeamId(num1) != null)
      {
        this.numericNationalTeam.Value = (Decimal) this.m_CurrentCountry.NationalTeamId;
        int num2 = (int) FifaEnvironment.UserMessages.ShowMessage(1014);
        this.m_IsNationalTeamLocked = false;
      }
      else
      {
        this.m_CurrentCountry.SetNationalTeam(nationalTeam, num1);
        this.pictureNationalTeam.BackgroundImage = (Image) nationalTeam?.GetCrest();
        this.m_IsNationalTeamLocked = false;
      }
    }

    private void comboNationalTeam_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_IsNationalTeamLocked)
        return;
      this.m_IsNationalTeamLocked = true;
      int nationalTeamId;
      Team nationalTeam;
      if (this.comboNationalTeam.SelectedItem.ToString() == this.m_NotPresent)
      {
        nationalTeamId = -1;
        nationalTeam = (Team) null;
      }
      else
      {
        nationalTeam = (Team) this.comboNationalTeam.SelectedItem;
        nationalTeamId = nationalTeam.Id;
      }
      if (nationalTeam == this.m_CurrentCountry.NationalTeam)
        this.m_IsNationalTeamLocked = false;
      else if (nationalTeamId > 0 && FifaEnvironment.Countries.SearchNationalTeamId(nationalTeamId) != null)
      {
        this.comboNationalTeam.SelectedItem = (object) this.m_CurrentCountry.NationalTeam;
        int num = (int) FifaEnvironment.UserMessages.ShowMessage(1014);
        this.m_IsNationalTeamLocked = false;
      }
      else
      {
        this.numericNationalTeam.Value = (Decimal) nationalTeamId;
        this.m_CurrentCountry.SetNationalTeam(nationalTeam, nationalTeamId);
        this.pictureNationalTeam.BackgroundImage = (Image) nationalTeam?.GetCrest();
        this.m_IsNationalTeamLocked = false;
      }
    }

    private void pictureNationalTeam_DoubleClick(object sender, EventArgs e)
    {
      if (this.m_CurrentCountry.NationalTeam == null)
        return;
      MainForm.CM.JumpTo((IdObject) this.m_CurrentCountry.NationalTeam);
    }

    private void CountryForm_Load(object sender, EventArgs e)
    {
      this.m_IsLoaded = true;
      this.Preset();
    }

    private void numericTeamPrestige_ValueChanged(object sender, EventArgs e)
    {
    }

    private void buttonRandomize1_Click(object sender, EventArgs e)
    {
    }

    private void buttonRandomize2_Click(object sender, EventArgs e)
    {
    }

    private void buttonRandomiz23_Click(object sender, EventArgs e)
    {
    }

    private void buttonRandomize4_Click(object sender, EventArgs e)
    {
    }

    private void buttonSpain_Click(object sender, EventArgs e)
    {
    }

    private void buttonFrance_Click(object sender, EventArgs e)
    {
    }

    private void buttonItaly_Click(object sender, EventArgs e)
    {
    }

    private void buttonGermany_Click(object sender, EventArgs e)
    {
    }

    private void buttonScotland_Click(object sender, EventArgs e)
    {
    }

    private void buttonAustria_Click(object sender, EventArgs e)
    {
    }

    private void buttonBrazil_Click(object sender, EventArgs e)
    {
    }

    private void buttonCzech_Click(object sender, EventArgs e)
    {
    }

    private void buttonKorea_Click(object sender, EventArgs e)
    {
    }

    private void LoadAudio()
    {
      this.comboChants.SelectedIndex = this.m_CurrentCountry.ChantRegionIndex - 1;
      this.comboLanguage.SelectedIndex = this.m_CurrentCountry.PALanguageIndex;
      this.comboPlayerCall.SelectedIndex = this.m_CurrentCountry.PlayerCallPatchBankIndex;
      switch (this.m_CurrentCountry.CrowdBedsRegionIndex)
      {
        case 0:
          this.comboCrowdType.SelectedIndex = 0;
          break;
        case 8:
          this.comboCrowdType.SelectedIndex = 1;
          break;
        case 15:
          this.comboCrowdType.SelectedIndex = 2;
          break;
      }
      this.checkCanWhistle.Checked = this.m_CurrentCountry.TeamCanWhistleIndex == 1;
    }

    private void comboLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.m_CurrentCountry.PALanguageIndex = this.comboLanguage.SelectedIndex;
    }

    private void comboChants_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.m_CurrentCountry.ChantRegionIndex = this.comboChants.SelectedIndex + 1;
    }

    private void comboCrowdType_SelectedIndexChanged(object sender, EventArgs e)
    {
      switch (this.comboCrowdType.SelectedIndex)
      {
        case 0:
          this.m_CurrentCountry.CrowdBedsRegionIndex = 0;
          break;
        case 1:
          this.m_CurrentCountry.CrowdBedsRegionIndex = 8;
          break;
        case 2:
          this.m_CurrentCountry.CrowdBedsRegionIndex = 15;
          break;
      }
    }

    private void comboPlayerCall_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.m_CurrentCountry.PlayerCallPatchBankIndex = this.comboPlayerCall.SelectedIndex;
    }

    private void comboPepper_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void checkTauntKeeper_CheckedChanged(object sender, EventArgs e)
    {
    }

    private void checkCanWhistle_CheckedChanged(object sender, EventArgs e)
    {
      this.m_CurrentCountry.TeamCanWhistleIndex = this.checkCanWhistle.Checked ? 1 : 0;
    }

    private void textLanguageShortName_TextChanged(object sender, EventArgs e)
    {
      if (this.textLanguageShortName.Text.Length <= 15)
        return;
      this.textLanguageShortName.Text = this.textLanguageShortName.Text.Substring(0, 15);
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
      ComponentResourceManager resources = new ComponentResourceManager(typeof (CountryForm));
      this.flowLayoutPanel = new FlowLayoutPanel();
      this.groupBox = new GroupBox();
      this.viewer2DFlag512 = new Viewer2D();
      this.labelContry3Letters = new Label();
      this.textLanguageAbbreviation = new TextBox();
      this.countryBindingSource = new BindingSource(this.components);
      this.textLanguageShortName = new TextBox();
      this.labelNationShortName = new Label();
      this.label4 = new Label();
      this.numericLevel = new NumericUpDown();
      this.comboRegionalTarget = new ComboBox();
      this.comboWorkltarget = new ComboBox();
      this.labeRegionalTarget = new Label();
      this.labelWorldTarget = new Label();
      this.checkTopTier = new CheckBox();
      this.buttonGetId = new Button();
      this.viewer2DFlag = new Viewer2D();
      this.viewer2DCardFlag = new Viewer2D();
      this.pictureNationalTeam = new PictureBox();
      this.viewer2DMiniFlag = new Viewer2D();
      this.comboNationalTeam = new ComboBox();
      this.numericNationalTeam = new NumericUpDown();
      this.numericCountryId = new NumericUpDown();
      this.comboContinent = new ComboBox();
      this.textLanguageName = new TextBox();
      this.labelNationalTeam = new Label();
      this.labelLanguageName = new Label();
      this.textDatabaseCountryName = new TextBox();
      this.labelDatabaseCountryName = new Label();
      this.labelContinent = new Label();
      this.labelCountrId = new Label();
      this.groupCountryShape = new GroupBox();
      this.viewer2DShape = new Viewer2D();
      this.groupAudio = new GroupBox();
      this.label3 = new Label();
      this.label2 = new Label();
      this.label1 = new Label();
      this.comboPepper = new ComboBox();
      this.comboPlayerCall = new ComboBox();
      this.comboCrowdType = new ComboBox();
      this.checkCanWhistle = new CheckBox();
      this.checkTauntKeeper = new CheckBox();
      this.comboLanguage = new ComboBox();
      this.label15 = new Label();
      this.label14 = new Label();
      this.label11 = new Label();
      this.label10 = new Label();
      this.comboChants = new ComboBox();
      this.label9 = new Label();
      this.toolTip = new ToolTip(this.components);
      this.sponsorListBindingSource = new BindingSource(this.components);
      this.pickUpControl = new PickUpControl();
      this.flowLayoutPanel.SuspendLayout();
      this.groupBox.SuspendLayout();
      ((ISupportInitialize) this.countryBindingSource).BeginInit();
      this.numericLevel.BeginInit();
      ((ISupportInitialize) this.pictureNationalTeam).BeginInit();
      this.numericNationalTeam.BeginInit();
      this.numericCountryId.BeginInit();
      this.groupCountryShape.SuspendLayout();
      this.groupAudio.SuspendLayout();
      ((ISupportInitialize) this.sponsorListBindingSource).BeginInit();
      this.SuspendLayout();
      this.flowLayoutPanel.AutoScroll = true;
      this.flowLayoutPanel.Controls.Add((Control) this.groupBox);
      this.flowLayoutPanel.Controls.Add((Control) this.groupCountryShape);
      this.flowLayoutPanel.Controls.Add((Control) this.groupAudio);
      this.flowLayoutPanel.Dock = DockStyle.Fill;
      this.flowLayoutPanel.Location = new Point(0, 25);
      this.flowLayoutPanel.Name = "flowLayoutPanel";
      this.flowLayoutPanel.Size = new Size(1357, 807);
      this.flowLayoutPanel.TabIndex = 0;
      this.groupBox.Controls.Add((Control) this.viewer2DFlag512);
      this.groupBox.Controls.Add((Control) this.labelContry3Letters);
      this.groupBox.Controls.Add((Control) this.textLanguageAbbreviation);
      this.groupBox.Controls.Add((Control) this.textLanguageShortName);
      this.groupBox.Controls.Add((Control) this.labelNationShortName);
      this.groupBox.Controls.Add((Control) this.label4);
      this.groupBox.Controls.Add((Control) this.numericLevel);
      this.groupBox.Controls.Add((Control) this.comboRegionalTarget);
      this.groupBox.Controls.Add((Control) this.comboWorkltarget);
      this.groupBox.Controls.Add((Control) this.labeRegionalTarget);
      this.groupBox.Controls.Add((Control) this.labelWorldTarget);
      this.groupBox.Controls.Add((Control) this.checkTopTier);
      this.groupBox.Controls.Add((Control) this.buttonGetId);
      this.groupBox.Controls.Add((Control) this.viewer2DFlag);
      this.groupBox.Controls.Add((Control) this.viewer2DCardFlag);
      this.groupBox.Controls.Add((Control) this.pictureNationalTeam);
      this.groupBox.Controls.Add((Control) this.viewer2DMiniFlag);
      this.groupBox.Controls.Add((Control) this.comboNationalTeam);
      this.groupBox.Controls.Add((Control) this.numericNationalTeam);
      this.groupBox.Controls.Add((Control) this.numericCountryId);
      this.groupBox.Controls.Add((Control) this.comboContinent);
      this.groupBox.Controls.Add((Control) this.textLanguageName);
      this.groupBox.Controls.Add((Control) this.labelNationalTeam);
      this.groupBox.Controls.Add((Control) this.labelLanguageName);
      this.groupBox.Controls.Add((Control) this.textDatabaseCountryName);
      this.groupBox.Controls.Add((Control) this.labelDatabaseCountryName);
      this.groupBox.Controls.Add((Control) this.labelContinent);
      this.groupBox.Controls.Add((Control) this.labelCountrId);
      this.groupBox.Location = new Point(3, 1);
      this.groupBox.Margin = new Padding(3, 1, 3, 3);
      this.groupBox.Name = "groupBox";
      this.groupBox.Size = new Size(929, 402);
      this.groupBox.TabIndex = 0;
      this.groupBox.TabStop = false;
      this.viewer2DFlag512.AutoTransparency = false;
      this.viewer2DFlag512.BackColor = Color.Transparent;
      this.viewer2DFlag512.ButtonStripVisible = true;
      this.viewer2DFlag512.CurrentBitmap = (Bitmap) null;
      this.viewer2DFlag512.ExtendedFormat = false;
      this.viewer2DFlag512.FullSizeButton = false;
      this.viewer2DFlag512.ImageLayout = ImageLayout.Zoom;
      this.viewer2DFlag512.ImageSize = new Size(512, 512);
      this.viewer2DFlag512.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DFlag512.Location = new Point(659, 14);
      this.viewer2DFlag512.Name = "viewer2DFlag512";
      this.viewer2DFlag512.RemoveButton = false;
      this.viewer2DFlag512.ShowButton = true;
      this.viewer2DFlag512.ShowButtonChecked = true;
      this.viewer2DFlag512.Size = new Size(256, 281);
      this.viewer2DFlag512.TabIndex = 162;
      this.toolTip.SetToolTip((Control) this.viewer2DFlag512, "Country Flag 512 x 512");
      this.labelContry3Letters.AutoSize = true;
      this.labelContry3Letters.BackColor = Color.Transparent;
      this.labelContry3Letters.ImeMode = ImeMode.NoControl;
      this.labelContry3Letters.Location = new Point(6, 109);
      this.labelContry3Letters.Name = "labelContry3Letters";
      this.labelContry3Letters.Size = new Size(66, 13);
      this.labelContry3Letters.TabIndex = 161;
      this.labelContry3Letters.Text = "Abbreviation";
      this.labelContry3Letters.TextAlign = ContentAlignment.MiddleLeft;
      this.textLanguageAbbreviation.DataBindings.Add(new Binding("Text", (object) this.countryBindingSource, "LanguageAbbreviation", true));
      this.textLanguageAbbreviation.Location = new Point(101, 109);
      this.textLanguageAbbreviation.Name = "textLanguageAbbreviation";
      this.textLanguageAbbreviation.Size = new Size(133, 20);
      this.textLanguageAbbreviation.TabIndex = 160;
      this.countryBindingSource.DataSource = (object) typeof (Country);
      this.textLanguageShortName.DataBindings.Add(new Binding("Text", (object) this.countryBindingSource, "LanguageShortName", true));
      this.textLanguageShortName.Location = new Point(101, 84);
      this.textLanguageShortName.Name = "textLanguageShortName";
      this.textLanguageShortName.Size = new Size(133, 20);
      this.textLanguageShortName.TabIndex = 158;
      this.textLanguageShortName.TextChanged += new EventHandler(this.textLanguageShortName_TextChanged);
      this.labelNationShortName.AutoSize = true;
      this.labelNationShortName.BackColor = Color.Transparent;
      this.labelNationShortName.ImeMode = ImeMode.NoControl;
      this.labelNationShortName.Location = new Point(6, 87);
      this.labelNationShortName.Name = "labelNationShortName";
      this.labelNationShortName.Size = new Size(63, 13);
      this.labelNationShortName.TabIndex = 159;
      this.labelNationShortName.Text = "Short Name";
      this.labelNationShortName.TextAlign = ContentAlignment.MiddleLeft;
      this.label4.AutoSize = true;
      this.label4.BackColor = Color.Transparent;
      this.label4.ImeMode = ImeMode.NoControl;
      this.label4.Location = new Point(122, 374);
      this.label4.Name = "label4";
      this.label4.Size = new Size(33, 13);
      this.label4.TabIndex = 157;
      this.label4.Text = "Level";
      this.label4.TextAlign = ContentAlignment.MiddleLeft;
      this.numericLevel.DataBindings.Add(new Binding("Value", (object) this.countryBindingSource, "Level", true));
      this.numericLevel.Location = new Point(161, 372);
      this.numericLevel.Maximum = new Decimal(new int[4]
      {
        7,
        0,
        0,
        0
      });
      this.numericLevel.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericLevel.Name = "numericLevel";
      this.numericLevel.Size = new Size(71, 20);
      this.numericLevel.TabIndex = 156;
      this.numericLevel.TextAlign = HorizontalAlignment.Center;
      this.numericLevel.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.comboRegionalTarget.DataBindings.Add(new Binding("SelectedIndex", (object) this.countryBindingSource, "ContinentalCupTarget", true));
      this.comboRegionalTarget.Font = new Font("Microsoft Sans Serif", 8.25f);
      this.comboRegionalTarget.ItemHeight = 13;
      this.comboRegionalTarget.Items.AddRange(new object[7]
      {
        (object) "N/A",
        (object) "WIN",
        (object) "FINAL",
        (object) "SEMI",
        (object) "QUARTER",
        (object) "KNOCKOUT",
        (object) "QUALIFY"
      });
      this.comboRegionalTarget.Location = new Point(117, 345);
      this.comboRegionalTarget.Name = "comboRegionalTarget";
      this.comboRegionalTarget.Size = new Size(115, 21);
      this.comboRegionalTarget.TabIndex = 155;
      this.comboWorkltarget.DataBindings.Add(new Binding("SelectedIndex", (object) this.countryBindingSource, "WorldCupTarget", true));
      this.comboWorkltarget.Font = new Font("Microsoft Sans Serif", 8.25f);
      this.comboWorkltarget.ItemHeight = 13;
      this.comboWorkltarget.Items.AddRange(new object[7]
      {
        (object) "N/A",
        (object) "WIN",
        (object) "FINAL",
        (object) "SEMI",
        (object) "QUARTER",
        (object) "KNOCKOUT",
        (object) "QUALIFY"
      });
      this.comboWorkltarget.Location = new Point(117, 318);
      this.comboWorkltarget.Name = "comboWorkltarget";
      this.comboWorkltarget.Size = new Size(115, 21);
      this.comboWorkltarget.TabIndex = 154;
      this.labeRegionalTarget.AutoSize = true;
      this.labeRegionalTarget.BackColor = SystemColors.Control;
      this.labeRegionalTarget.ImeMode = ImeMode.NoControl;
      this.labeRegionalTarget.Location = new Point(6, 348);
      this.labeRegionalTarget.Name = "labeRegionalTarget";
      this.labeRegionalTarget.Size = new Size(105, 13);
      this.labeRegionalTarget.TabIndex = 153;
      this.labeRegionalTarget.Text = "Regional Cup Target";
      this.labeRegionalTarget.TextAlign = ContentAlignment.MiddleLeft;
      this.labelWorldTarget.AutoSize = true;
      this.labelWorldTarget.BackColor = SystemColors.Control;
      this.labelWorldTarget.ImeMode = ImeMode.NoControl;
      this.labelWorldTarget.Location = new Point(6, 321);
      this.labelWorldTarget.Name = "labelWorldTarget";
      this.labelWorldTarget.Size = new Size(91, 13);
      this.labelWorldTarget.TabIndex = 152;
      this.labelWorldTarget.Text = "World Cup Target";
      this.labelWorldTarget.TextAlign = ContentAlignment.MiddleLeft;
      this.checkTopTier.DataBindings.Add(new Binding("Checked", (object) this.countryBindingSource, "Top_tier", true));
      this.checkTopTier.Location = new Point(4, 372);
      this.checkTopTier.Name = "checkTopTier";
      this.checkTopTier.RightToLeft = RightToLeft.Yes;
      this.checkTopTier.Size = new Size(107, 18);
      this.checkTopTier.TabIndex = 151;
      this.checkTopTier.Text = "Top tier";
      this.checkTopTier.TextAlign = ContentAlignment.MiddleRight;
      this.checkTopTier.UseVisualStyleBackColor = true;
      this.buttonGetId.Image = (Image) resources.GetObject("buttonGetId.Image");
      this.buttonGetId.Location = new Point(207, 36);
      this.buttonGetId.Name = "buttonGetId";
      this.buttonGetId.Size = new Size(25, 23);
      this.buttonGetId.TabIndex = 150;
      this.toolTip.SetToolTip((Control) this.buttonGetId, "Get a free id");
      this.buttonGetId.UseVisualStyleBackColor = true;
      this.buttonGetId.Click += new EventHandler(this.buttonGetId_Click);
      this.viewer2DFlag.AutoTransparency = true;
      this.viewer2DFlag.BackColor = Color.Transparent;
      this.viewer2DFlag.ButtonStripVisible = true;
      this.viewer2DFlag.CurrentBitmap = (Bitmap) null;
      this.viewer2DFlag.ExtendedFormat = false;
      this.viewer2DFlag.FullSizeButton = false;
      this.viewer2DFlag.ImageLayout = ImageLayout.None;
      this.viewer2DFlag.ImageSize = new Size(256, 256);
      this.viewer2DFlag.ImageSizeMultiplier = Viewer2D.SizeMultiplier.Auto256;
      this.viewer2DFlag.Location = new Point(240, 13);
      this.viewer2DFlag.Name = "viewer2DFlag";
      this.viewer2DFlag.RemoveButton = false;
      this.viewer2DFlag.ShowButton = true;
      this.viewer2DFlag.ShowButtonChecked = true;
      this.viewer2DFlag.Size = new Size(256, 281);
      this.viewer2DFlag.TabIndex = 1;
      this.toolTip.SetToolTip((Control) this.viewer2DFlag, "Country Badge");
      this.viewer2DCardFlag.AutoTransparency = true;
      this.viewer2DCardFlag.BackColor = Color.Transparent;
      this.viewer2DCardFlag.ButtonStripVisible = true;
      this.viewer2DCardFlag.CurrentBitmap = (Bitmap) null;
      this.viewer2DCardFlag.ExtendedFormat = false;
      this.viewer2DCardFlag.FullSizeButton = false;
      this.viewer2DCardFlag.ImageLayout = ImageLayout.None;
      this.viewer2DCardFlag.ImageSize = new Size(256, 256);
      this.viewer2DCardFlag.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DCardFlag.Location = new Point(502, 13);
      this.viewer2DCardFlag.Name = "viewer2DCardFlag";
      this.viewer2DCardFlag.RemoveButton = false;
      this.viewer2DCardFlag.ShowButton = true;
      this.viewer2DCardFlag.ShowButtonChecked = true;
      this.viewer2DCardFlag.Size = new Size(150, 177);
      this.viewer2DCardFlag.TabIndex = 30;
      this.toolTip.SetToolTip((Control) this.viewer2DCardFlag, "Country Flag");
      this.pictureNationalTeam.BackgroundImageLayout = ImageLayout.Zoom;
      this.pictureNationalTeam.BorderStyle = BorderStyle.FixedSingle;
      this.pictureNationalTeam.Cursor = Cursors.Hand;
      this.pictureNationalTeam.ImeMode = ImeMode.NoControl;
      this.pictureNationalTeam.Location = new Point(117, 209);
      this.pictureNationalTeam.Name = "pictureNationalTeam";
      this.pictureNationalTeam.Size = new Size(100, 100);
      this.pictureNationalTeam.TabIndex = 134;
      this.pictureNationalTeam.TabStop = false;
      this.pictureNationalTeam.DoubleClick += new EventHandler(this.pictureNationalTeam_DoubleClick);
      this.viewer2DMiniFlag.AutoTransparency = false;
      this.viewer2DMiniFlag.BackColor = Color.Transparent;
      this.viewer2DMiniFlag.ButtonStripVisible = true;
      this.viewer2DMiniFlag.CurrentBitmap = (Bitmap) null;
      this.viewer2DMiniFlag.ExtendedFormat = false;
      this.viewer2DMiniFlag.FullSizeButton = false;
      this.viewer2DMiniFlag.ImageLayout = ImageLayout.None;
      this.viewer2DMiniFlag.ImageSize = new Size(64, 64);
      this.viewer2DMiniFlag.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DMiniFlag.Location = new Point(502, 230);
      this.viewer2DMiniFlag.Name = "viewer2DMiniFlag";
      this.viewer2DMiniFlag.RemoveButton = false;
      this.viewer2DMiniFlag.ShowButton = true;
      this.viewer2DMiniFlag.ShowButtonChecked = true;
      this.viewer2DMiniFlag.Size = new Size(64, 64);
      this.viewer2DMiniFlag.TabIndex = 2;
      this.comboNationalTeam.ItemHeight = 13;
      this.comboNationalTeam.Location = new Point(101, 182);
      this.comboNationalTeam.MaxLength = (int) short.MaxValue;
      this.comboNationalTeam.Name = "comboNationalTeam";
      this.comboNationalTeam.Size = new Size(133, 21);
      this.comboNationalTeam.Sorted = true;
      this.comboNationalTeam.TabIndex = 132;
      this.toolTip.SetToolTip((Control) this.comboNationalTeam, "Use this to assign to the country an existing national team");
      this.comboNationalTeam.SelectedIndexChanged += new EventHandler(this.comboNationalTeam_SelectedIndexChanged);
      this.numericNationalTeam.DataBindings.Add(new Binding("Value", (object) this.countryBindingSource, "NationalTeamId", true));
      this.numericNationalTeam.Location = new Point(101, 159);
      this.numericNationalTeam.Maximum = new Decimal(new int[4]
      {
        200000,
        0,
        0,
        0
      });
      this.numericNationalTeam.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        int.MinValue
      });
      this.numericNationalTeam.Name = "numericNationalTeam";
      this.numericNationalTeam.Size = new Size(133, 20);
      this.numericNationalTeam.TabIndex = 131;
      this.numericNationalTeam.TextAlign = HorizontalAlignment.Center;
      this.toolTip.SetToolTip((Control) this.numericNationalTeam, "Use this to assign a national team identifier though the national team does not exists");
      this.numericNationalTeam.ValueChanged += new EventHandler(this.numericNationalTeam_ValueChanged);
      this.numericCountryId.DataBindings.Add(new Binding("Value", (object) this.countryBindingSource, "Id", true));
      this.numericCountryId.Location = new Point(101, 37);
      this.numericCountryId.Maximum = new Decimal(new int[4]
      {
        200000,
        0,
        0,
        0
      });
      this.numericCountryId.Name = "numericCountryId";
      this.numericCountryId.Size = new Size(100, 20);
      this.numericCountryId.TabIndex = 143;
      this.numericCountryId.TextAlign = HorizontalAlignment.Center;
      this.numericCountryId.ValueChanged += new EventHandler(this.numericCountryId_ValueChanged);
      this.comboContinent.DataBindings.Add(new Binding("SelectedIndex", (object) this.countryBindingSource, "Confederation", true));
      this.comboContinent.Font = new Font("Microsoft Sans Serif", 8.25f);
      this.comboContinent.ItemHeight = 13;
      this.comboContinent.Items.AddRange(new object[7]
      {
        (object) "None",
        (object) "Europe",
        (object) "Africa",
        (object) "South America",
        (object) "Asia",
        (object) "Oceania",
        (object) "North America"
      });
      this.comboContinent.Location = new Point(101, 135);
      this.comboContinent.Name = "comboContinent";
      this.comboContinent.Size = new Size(133, 21);
      this.comboContinent.TabIndex = 145;
      this.textLanguageName.DataBindings.Add(new Binding("Text", (object) this.countryBindingSource, "LanguageName", true));
      this.textLanguageName.Location = new Point(101, 60);
      this.textLanguageName.Name = "textLanguageName";
      this.textLanguageName.Size = new Size(133, 20);
      this.textLanguageName.TabIndex = 144;
      this.textLanguageName.TextChanged += new EventHandler(this.textLanguageName_TextChanged);
      this.labelNationalTeam.AutoSize = true;
      this.labelNationalTeam.BackColor = SystemColors.Control;
      this.labelNationalTeam.ImeMode = ImeMode.NoControl;
      this.labelNationalTeam.Location = new Point(6, 170);
      this.labelNationalTeam.Name = "labelNationalTeam";
      this.labelNationalTeam.Size = new Size(76, 13);
      this.labelNationalTeam.TabIndex = 133;
      this.labelNationalTeam.Text = "National Team";
      this.labelNationalTeam.TextAlign = ContentAlignment.MiddleLeft;
      this.labelLanguageName.AutoSize = true;
      this.labelLanguageName.BackColor = Color.Transparent;
      this.labelLanguageName.ImeMode = ImeMode.NoControl;
      this.labelLanguageName.Location = new Point(6, 59);
      this.labelLanguageName.Name = "labelLanguageName";
      this.labelLanguageName.Size = new Size(35, 13);
      this.labelLanguageName.TabIndex = 147;
      this.labelLanguageName.Text = "Name";
      this.labelLanguageName.TextAlign = ContentAlignment.MiddleLeft;
      this.textDatabaseCountryName.DataBindings.Add(new Binding("Text", (object) this.countryBindingSource, "DatabaseName", true));
      this.textDatabaseCountryName.Location = new Point(101, 14);
      this.textDatabaseCountryName.Name = "textDatabaseCountryName";
      this.textDatabaseCountryName.Size = new Size(133, 20);
      this.textDatabaseCountryName.TabIndex = 142;
      this.labelDatabaseCountryName.AutoSize = true;
      this.labelDatabaseCountryName.BackColor = Color.Transparent;
      this.labelDatabaseCountryName.ImeMode = ImeMode.NoControl;
      this.labelDatabaseCountryName.Location = new Point(6, 13);
      this.labelDatabaseCountryName.Name = "labelDatabaseCountryName";
      this.labelDatabaseCountryName.Size = new Size(84, 13);
      this.labelDatabaseCountryName.TabIndex = 146;
      this.labelDatabaseCountryName.Text = "Database Name";
      this.labelDatabaseCountryName.TextAlign = ContentAlignment.MiddleLeft;
      this.labelContinent.AutoSize = true;
      this.labelContinent.BackColor = Color.Transparent;
      this.labelContinent.ImeMode = ImeMode.NoControl;
      this.labelContinent.Location = new Point(6, 135);
      this.labelContinent.Name = "labelContinent";
      this.labelContinent.Size = new Size(73, 13);
      this.labelContinent.TabIndex = 148;
      this.labelContinent.Text = "Confederation";
      this.labelContinent.TextAlign = ContentAlignment.MiddleLeft;
      this.labelCountrId.AutoSize = true;
      this.labelCountrId.BackColor = Color.Transparent;
      this.labelCountrId.ImeMode = ImeMode.NoControl;
      this.labelCountrId.Location = new Point(6, 36);
      this.labelCountrId.Name = "labelCountrId";
      this.labelCountrId.Size = new Size(55, 13);
      this.labelCountrId.TabIndex = 149;
      this.labelCountrId.Text = "Country Id";
      this.labelCountrId.TextAlign = ContentAlignment.MiddleLeft;
      this.groupCountryShape.Controls.Add((Control) this.viewer2DShape);
      this.groupCountryShape.Location = new Point(3, 409);
      this.groupCountryShape.Name = "groupCountryShape";
      this.groupCountryShape.Size = new Size(528, 308);
      this.groupCountryShape.TabIndex = 4;
      this.groupCountryShape.TabStop = false;
      this.groupCountryShape.Text = "Map (Shape)";
      this.viewer2DShape.AutoTransparency = true;
      this.viewer2DShape.BackColor = Color.Transparent;
      this.viewer2DShape.ButtonStripVisible = true;
      this.viewer2DShape.CurrentBitmap = (Bitmap) null;
      this.viewer2DShape.ExtendedFormat = false;
      this.viewer2DShape.FullSizeButton = false;
      this.viewer2DShape.ImageLayout = ImageLayout.None;
      this.viewer2DShape.ImageSize = new Size(512, 256);
      this.viewer2DShape.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DShape.Location = new Point(6, 16);
      this.viewer2DShape.Name = "viewer2DShape";
      this.viewer2DShape.RemoveButton = false;
      this.viewer2DShape.ShowButton = true;
      this.viewer2DShape.ShowButtonChecked = true;
      this.viewer2DShape.Size = new Size(512, 281);
      this.viewer2DShape.TabIndex = 2;
      this.toolTip.SetToolTip((Control) this.viewer2DShape, "Country Badge");
      this.groupAudio.Controls.Add((Control) this.label3);
      this.groupAudio.Controls.Add((Control) this.label2);
      this.groupAudio.Controls.Add((Control) this.label1);
      this.groupAudio.Controls.Add((Control) this.comboPepper);
      this.groupAudio.Controls.Add((Control) this.comboPlayerCall);
      this.groupAudio.Controls.Add((Control) this.comboCrowdType);
      this.groupAudio.Controls.Add((Control) this.checkCanWhistle);
      this.groupAudio.Controls.Add((Control) this.checkTauntKeeper);
      this.groupAudio.Controls.Add((Control) this.comboLanguage);
      this.groupAudio.Controls.Add((Control) this.label15);
      this.groupAudio.Controls.Add((Control) this.label14);
      this.groupAudio.Controls.Add((Control) this.label11);
      this.groupAudio.Controls.Add((Control) this.label10);
      this.groupAudio.Controls.Add((Control) this.comboChants);
      this.groupAudio.Controls.Add((Control) this.label9);
      this.groupAudio.Location = new Point(537, 409);
      this.groupAudio.Name = "groupAudio";
      this.groupAudio.Size = new Size(624, 250);
      this.groupAudio.TabIndex = 3;
      this.groupAudio.TabStop = false;
      this.groupAudio.Text = "Audio";
      this.groupAudio.Visible = false;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(11, 219);
      this.label3.Name = "label3";
      this.label3.Size = new Size(55, 13);
      this.label3.TabIndex = 33;
      this.label3.Text = "Reactions";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(11, 192);
      this.label2.Name = "label2";
      this.label2.Size = new Size(46, 13);
      this.label2.TabIndex = 32;
      this.label2.Text = "Heckles";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(9, 165);
      this.label1.Name = "label1";
      this.label1.Size = new Size(54, 13);
      this.label1.TabIndex = 31;
      this.label1.Text = "Ambience";
      this.comboPepper.FormattingEnabled = true;
      this.comboPepper.Items.AddRange(new object[8]
      {
        (object) "Undefined",
        (object) "English",
        (object) "French",
        (object) "Italian",
        (object) "German",
        (object) "Spanish",
        (object) "Scandinavian",
        (object) "Brazilian"
      });
      this.comboPepper.Location = new Point(88, 132);
      this.comboPepper.Name = "comboPepper";
      this.comboPepper.Size = new Size(145, 21);
      this.comboPepper.TabIndex = 29;
      this.comboPepper.SelectedIndexChanged += new EventHandler(this.comboPepper_SelectedIndexChanged);
      this.comboPlayerCall.FormattingEnabled = true;
      this.comboPlayerCall.Items.AddRange(new object[19]
      {
        (object) "English",
        (object) "French",
        (object) "Italian",
        (object) "German",
        (object) "Spanish",
        (object) "Brazilian",
        (object) "Japaneese",
        (object) "Korean",
        (object) "Dutch",
        (object) "Danish",
        (object) "Swedish",
        (object) "Norwegian",
        (object) "Portuguese",
        (object) "Russian",
        (object) "US English",
        (object) "Iranian",
        (object) "Indian",
        (object) "Chineese",
        (object) "Arabic"
      });
      this.comboPlayerCall.Location = new Point(88, 105);
      this.comboPlayerCall.Name = "comboPlayerCall";
      this.comboPlayerCall.Size = new Size(145, 21);
      this.comboPlayerCall.TabIndex = 28;
      this.comboPlayerCall.SelectedIndexChanged += new EventHandler(this.comboPlayerCall_SelectedIndexChanged);
      this.comboCrowdType.FormattingEnabled = true;
      this.comboCrowdType.Items.AddRange(new object[3]
      {
        (object) " 0 = English",
        (object) " 8 = Brazilian",
        (object) "15 = Rest of World"
      });
      this.comboCrowdType.Location = new Point(88, 78);
      this.comboCrowdType.Name = "comboCrowdType";
      this.comboCrowdType.Size = new Size(145, 21);
      this.comboCrowdType.TabIndex = 27;
      this.comboCrowdType.SelectedIndexChanged += new EventHandler(this.comboCrowdType_SelectedIndexChanged);
      this.checkCanWhistle.AutoSize = true;
      this.checkCanWhistle.Location = new Point(259, 48);
      this.checkCanWhistle.Name = "checkCanWhistle";
      this.checkCanWhistle.RightToLeft = RightToLeft.Yes;
      this.checkCanWhistle.Size = new Size(83, 17);
      this.checkCanWhistle.TabIndex = 26;
      this.checkCanWhistle.Text = "Can Whistle";
      this.checkCanWhistle.UseVisualStyleBackColor = true;
      this.checkCanWhistle.CheckedChanged += new EventHandler(this.checkCanWhistle_CheckedChanged);
      this.checkTauntKeeper.AutoSize = true;
      this.checkTauntKeeper.Location = new Point(251, 25);
      this.checkTauntKeeper.Name = "checkTauntKeeper";
      this.checkTauntKeeper.RightToLeft = RightToLeft.Yes;
      this.checkTauntKeeper.Size = new Size(91, 17);
      this.checkTauntKeeper.TabIndex = 25;
      this.checkTauntKeeper.Text = "Taunt Keeper";
      this.checkTauntKeeper.UseVisualStyleBackColor = true;
      this.checkTauntKeeper.CheckedChanged += new EventHandler(this.checkTauntKeeper_CheckedChanged);
      this.comboLanguage.FormattingEnabled = true;
      this.comboLanguage.Items.AddRange(new object[18]
      {
        (object) "English ",
        (object) "French ",
        (object) "German ",
        (object) "Italian ",
        (object) "Spanish from Spain ",
        (object) "Croatian",
        (object) "Czech",
        (object) "Dutch",
        (object) "Greek",
        (object) "Polish ",
        (object) "Russian",
        (object) "Swedish",
        (object) "Turkish",
        (object) "Spanish from Mexico ",
        (object) "Spanish from Argentina ",
        (object) "Brazilian Portuguese",
        (object) "Korean",
        (object) "Japanese"
      });
      this.comboLanguage.Location = new Point(89, 24);
      this.comboLanguage.Name = "comboLanguage";
      this.comboLanguage.Size = new Size(144, 21);
      this.comboLanguage.TabIndex = 24;
      this.comboLanguage.SelectedIndexChanged += new EventHandler(this.comboLanguage_SelectedIndexChanged);
      this.label15.AutoSize = true;
      this.label15.Location = new Point(9, 135);
      this.label15.Name = "label15";
      this.label15.Size = new Size(42, 13);
      this.label15.TabIndex = 23;
      this.label15.Text = "Whistle";
      this.label14.AutoSize = true;
      this.label14.Location = new Point(9, 108);
      this.label14.Name = "label14";
      this.label14.Size = new Size(56, 13);
      this.label14.TabIndex = 22;
      this.label14.Text = "Player Call";
      this.label11.AutoSize = true;
      this.label11.Location = new Point(9, 81);
      this.label11.Name = "label11";
      this.label11.Size = new Size(64, 13);
      this.label11.TabIndex = 19;
      this.label11.Text = "Crowd Type";
      this.label10.AutoSize = true;
      this.label10.Location = new Point(6, 27);
      this.label10.Name = "label10";
      this.label10.Size = new Size(55, 13);
      this.label10.TabIndex = 18;
      this.label10.Text = "Language";
      this.comboChants.FormattingEnabled = true;
      this.comboChants.Items.AddRange(new object[16]
      {
        (object) "English Area",
        (object) "French Area",
        (object) "Italy",
        (object) "German Area",
        (object) "Spain",
        (object) "Scandinavian Area",
        (object) "Rest Of World",
        (object) "Latin America",
        (object) "Brazil",
        (object) "Africa",
        (object) "Asia",
        (object) "Mexico",
        (object) "Denmark",
        (object) "Russian Area",
        (object) "Portugal",
        (object) "Turkey"
      });
      this.comboChants.Location = new Point(89, 51);
      this.comboChants.Name = "comboChants";
      this.comboChants.Size = new Size(144, 21);
      this.comboChants.TabIndex = 17;
      this.comboChants.SelectedIndexChanged += new EventHandler(this.comboChants_SelectedIndexChanged);
      this.label9.AutoSize = true;
      this.label9.Location = new Point(9, 54);
      this.label9.Name = "label9";
      this.label9.Size = new Size(40, 13);
      this.label9.TabIndex = 16;
      this.label9.Text = "Chants";
      this.pickUpControl.BackColor = SystemColors.Control;
      this.pickUpControl.CloneButtonEnabled = false;
      this.pickUpControl.CreateButtonEnabled = true;
      this.pickUpControl.CurrentIndex = 0;
      this.pickUpControl.Dock = DockStyle.Top;
      this.pickUpControl.FilterByList = (string[]) null;
      this.pickUpControl.FilterEnabled = false;
      this.pickUpControl.FilterValues = (IdArrayList[]) null;
      this.pickUpControl.Location = new Point(0, 0);
      this.pickUpControl.MainSelectionEnabled = true;
      this.pickUpControl.Name = "pickUpControl";
      this.pickUpControl.ObjectList = (IdArrayList) null;
      this.pickUpControl.RefreshButtonEnabled = true;
      this.pickUpControl.RemoveButtonEnabled = true;
      this.pickUpControl.SearchEnabled = true;
      this.pickUpControl.Size = new Size(1357, 25);
      this.pickUpControl.TabIndex = 2;
      this.pickUpControl.WizardButtonEnabled = false;
      this.pickUpControl.YoungPlayersEnabled = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1357, 832);
      this.Controls.Add((Control) this.flowLayoutPanel);
      this.Controls.Add((Control) this.pickUpControl);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = "CountryForm";
      this.Text = "Country";
      this.Load += new EventHandler(this.CountryForm_Load);
      this.flowLayoutPanel.ResumeLayout(false);
      this.groupBox.ResumeLayout(false);
      this.groupBox.PerformLayout();
      ((ISupportInitialize) this.countryBindingSource).EndInit();
      this.numericLevel.EndInit();
      ((ISupportInitialize) this.pictureNationalTeam).EndInit();
      this.numericNationalTeam.EndInit();
      this.numericCountryId.EndInit();
      this.groupCountryShape.ResumeLayout(false);
      this.groupAudio.ResumeLayout(false);
      this.groupAudio.PerformLayout();
      ((ISupportInitialize) this.sponsorListBindingSource).EndInit();
      this.ResumeLayout(false);
    }
  }
}
