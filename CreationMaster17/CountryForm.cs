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
        private PictureBox pictureNationalTeam;
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
        private Label label3;
        private Label label2;
        private Label label1;
        private GroupBox groupCountryShape;
        private Viewer2D viewer2DShape;
        private ComboBox comboRegionalTarget;
        private ComboBox comboWorldCupTarget;
        private Label labeRegionalTarget;
        private Label labelWorldTarget;
        private Label label4;
        private NumericUpDown numericLevel;
        private Label labelContry3Letters;
        private TextBox textLanguageAbbreviation;
        private TextBox textLanguageShortName;
        private Label labelNationShortName;
        private Label label5;
        private TextBox textCountryISO;
        private GroupBox groupBox1;
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
            this.m_NewIdCreator.IdList = (IdArrayList)FifaEnvironment.Countries;
            //this.comboNationalTeam.Items.Clear();
            //this.comboNationalTeam.BeginUpdate();
            //this.comboNationalTeam.Items.Add((object) this.m_NotPresent);
            //this.comboNationalTeam.Items.AddRange(FifaEnvironment.Teams.ToArray());
            int maxValue = FifaEnvironment.FifaDb.Table[TI.players].TableDescriptor.MaxValues[FI.players_nationality];
            if (maxValue < (int)byte.MaxValue)
                maxValue = (int)byte.MaxValue;
            this.numericCountryId.Maximum = (Decimal)maxValue;
            //this.comboNationalTeam.EndUpdate();
            this.pickUpControl.ObjectList = (IdArrayList)FifaEnvironment.Countries;
        }

        public void ReloadCountry(Country country)
        {
            this.m_CurrentCountry = (Country)null;
            this.LoadCountry(country);
        }

        public void LoadCountry(Country country)
        {
            if (!this.m_IsLoaded || this.m_CurrentCountry == country)
                return;
            this.m_LockUserChanges = true;
            this.m_CurrentCountry = country;
            this.countryBindingSource.DataSource = (object)this.m_CurrentCountry;
            this.viewer2DFlag.CurrentBitmap = this.m_CurrentCountry.GetFlag();
            this.viewer2DFlag512.CurrentBitmap = this.m_CurrentCountry.GetFlag512();
            this.viewer2DMiniFlag.CurrentBitmap = this.m_CurrentCountry.GetMiniFlag();
            this.viewer2DShape.CurrentBitmap = this.m_CurrentCountry.GetShape();
            this.pictureNationalTeam.BackgroundImage = this.m_CurrentCountry.NationalTeam != null ? (Image)this.m_CurrentCountry.NationalTeam.GetCrest() : (Image)null;
            GC.Collect();
            this.m_LockUserChanges = false;
        }

        private Country SelectCountry(object sender, object obj)
        {
            Country country = (Country)obj;
            this.Refresh();
            this.LoadCountry(country);
            return country;
        }

        private Country CreateCountry(object sender, object obj)
        {
            DialogResult dialogResult = this.m_NewIdCreator.ShowDialog();
            if (this.m_NewIdCreator.NewObject != null)
                return (Country)this.m_NewIdCreator.NewObject;
            if (dialogResult == DialogResult.OK)
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(5060, this.m_NewIdCreator.NewId);
            }
            return (Country)null;
        }

        private Country DeleteCountry(object sender, object obj)
        {
            Country country = (Country)obj;
            FifaEnvironment.Countries.DeleteCountry(country);
            FifaEnvironment.Language.RemoveCountryString(country.Id, Language.ECountryStringType.Full);
            return (Country)null;
        }

        private Country CloneCountry(object sender, object obj)
        {
            return (Country)FifaEnvironment.Countries.CloneId((IdObject)obj);
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
            this.pickUpControl.SwitchObject((IdObject)this.m_CurrentCountry);
        }

        private void numericCountryId_ValueChanged(object sender, EventArgs e)
        {
            int num1 = (int)this.numericCountryId.Value;
            if (num1 == this.m_CurrentCountry.Id)
                return;
            if (FifaEnvironment.Countries.SearchId(num1) == null)
            {
                FifaEnvironment.Countries.ChangeId((IdObject)this.m_CurrentCountry, num1);
                this.ReloadCountry(this.m_CurrentCountry);
            }
            else
            {
                int num2 = (int)FifaEnvironment.UserMessages.ShowMessage(1015);
                this.numericCountryId.Value = (Decimal)this.m_CurrentCountry.Id;
            }
        }

        private void buttonGetId_Click(object sender, EventArgs e)
        {
            int newId = FifaEnvironment.Countries.GetNewId();
            if (newId == -1)
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(5050);
            }
            else
                this.numericCountryId.Value = (Decimal)newId;
        }

        private void pictureNationalTeam_DoubleClick(object sender, EventArgs e)
        {
            if (this.m_CurrentCountry.NationalTeam == null)
                return;
            MainForm.CM.JumpTo((IdObject)this.m_CurrentCountry.NationalTeam);
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CountryForm));
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureNationalTeam = new System.Windows.Forms.PictureBox();
            this.comboWorldCupTarget = new System.Windows.Forms.ComboBox();
            this.countryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelWorldTarget = new System.Windows.Forms.Label();
            this.labeRegionalTarget = new System.Windows.Forms.Label();
            this.comboRegionalTarget = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textCountryISO = new System.Windows.Forms.TextBox();
            this.viewer2DFlag512 = new FifaControls.Viewer2D();
            this.labelContry3Letters = new System.Windows.Forms.Label();
            this.textLanguageAbbreviation = new System.Windows.Forms.TextBox();
            this.textLanguageShortName = new System.Windows.Forms.TextBox();
            this.labelNationShortName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericLevel = new System.Windows.Forms.NumericUpDown();
            this.checkTopTier = new System.Windows.Forms.CheckBox();
            this.buttonGetId = new System.Windows.Forms.Button();
            this.viewer2DFlag = new FifaControls.Viewer2D();
            this.viewer2DMiniFlag = new FifaControls.Viewer2D();
            this.numericCountryId = new System.Windows.Forms.NumericUpDown();
            this.comboContinent = new System.Windows.Forms.ComboBox();
            this.textLanguageName = new System.Windows.Forms.TextBox();
            this.labelLanguageName = new System.Windows.Forms.Label();
            this.textDatabaseCountryName = new System.Windows.Forms.TextBox();
            this.labelDatabaseCountryName = new System.Windows.Forms.Label();
            this.labelContinent = new System.Windows.Forms.Label();
            this.labelCountrId = new System.Windows.Forms.Label();
            this.groupCountryShape = new System.Windows.Forms.GroupBox();
            this.viewer2DShape = new FifaControls.Viewer2D();
            this.groupAudio = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboPepper = new System.Windows.Forms.ComboBox();
            this.comboPlayerCall = new System.Windows.Forms.ComboBox();
            this.comboCrowdType = new System.Windows.Forms.ComboBox();
            this.checkCanWhistle = new System.Windows.Forms.CheckBox();
            this.checkTauntKeeper = new System.Windows.Forms.CheckBox();
            this.comboLanguage = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboChants = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.sponsorListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pickUpControl = new FifaControls.PickUpControl();
            this.flowLayoutPanel.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureNationalTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCountryId)).BeginInit();
            this.groupCountryShape.SuspendLayout();
            this.groupAudio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sponsorListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Controls.Add(this.groupBox);
            this.flowLayoutPanel.Controls.Add(this.groupCountryShape);
            this.flowLayoutPanel.Controls.Add(this.groupAudio);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 25);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(1357, 807);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.groupBox1);
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.textCountryISO);
            this.groupBox.Controls.Add(this.viewer2DFlag512);
            this.groupBox.Controls.Add(this.labelContry3Letters);
            this.groupBox.Controls.Add(this.textLanguageAbbreviation);
            this.groupBox.Controls.Add(this.textLanguageShortName);
            this.groupBox.Controls.Add(this.labelNationShortName);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.numericLevel);
            this.groupBox.Controls.Add(this.checkTopTier);
            this.groupBox.Controls.Add(this.buttonGetId);
            this.groupBox.Controls.Add(this.viewer2DFlag);
            this.groupBox.Controls.Add(this.viewer2DMiniFlag);
            this.groupBox.Controls.Add(this.numericCountryId);
            this.groupBox.Controls.Add(this.comboContinent);
            this.groupBox.Controls.Add(this.textLanguageName);
            this.groupBox.Controls.Add(this.labelLanguageName);
            this.groupBox.Controls.Add(this.textDatabaseCountryName);
            this.groupBox.Controls.Add(this.labelDatabaseCountryName);
            this.groupBox.Controls.Add(this.labelContinent);
            this.groupBox.Controls.Add(this.labelCountrId);
            this.groupBox.Location = new System.Drawing.Point(3, 1);
            this.groupBox.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(800, 442);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureNationalTeam);
            this.groupBox1.Controls.Add(this.comboWorldCupTarget);
            this.groupBox1.Controls.Add(this.labelWorldTarget);
            this.groupBox1.Controls.Add(this.labeRegionalTarget);
            this.groupBox1.Controls.Add(this.comboRegionalTarget);
            this.groupBox1.Location = new System.Drawing.Point(4, 245);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 191);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "National Team";
            // 
            // pictureNationalTeam
            // 
            this.pictureNationalTeam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureNationalTeam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureNationalTeam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureNationalTeam.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureNationalTeam.Location = new System.Drawing.Point(115, 16);
            this.pictureNationalTeam.Name = "pictureNationalTeam";
            this.pictureNationalTeam.Size = new System.Drawing.Size(100, 100);
            this.pictureNationalTeam.TabIndex = 134;
            this.pictureNationalTeam.TabStop = false;
            this.pictureNationalTeam.DoubleClick += new System.EventHandler(this.pictureNationalTeam_DoubleClick);
            // 
            // comboWorldCupTarget
            // 
            this.comboWorldCupTarget.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.countryBindingSource, "WorldCupTarget", true, DataSourceUpdateMode.OnPropertyChanged));
            this.comboWorldCupTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.comboWorldCupTarget.ItemHeight = 13;
            this.comboWorldCupTarget.Items.AddRange(new object[] {
            "N/A",
            "WIN",
            "FINAL",
            "SEMI",
            "QUARTER",
            "KNOCKOUT",
            "QUALIFY"});
            this.comboWorldCupTarget.Location = new System.Drawing.Point(108, 125);
            this.comboWorldCupTarget.Name = "comboWorldCupTarget";
            this.comboWorldCupTarget.Size = new System.Drawing.Size(115, 21);
            this.comboWorldCupTarget.TabIndex = 154;
            // 
            // countryBindingSource
            // 
            this.countryBindingSource.DataSource = typeof(FifaLibrary.Country);
            // 
            // labelWorldTarget
            // 
            this.labelWorldTarget.AutoSize = true;
            this.labelWorldTarget.BackColor = System.Drawing.SystemColors.Control;
            this.labelWorldTarget.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelWorldTarget.Location = new System.Drawing.Point(2, 129);
            this.labelWorldTarget.Name = "labelWorldTarget";
            this.labelWorldTarget.Size = new System.Drawing.Size(91, 13);
            this.labelWorldTarget.TabIndex = 152;
            this.labelWorldTarget.Text = "World Cup Target";
            this.labelWorldTarget.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labeRegionalTarget
            // 
            this.labeRegionalTarget.AutoSize = true;
            this.labeRegionalTarget.BackColor = System.Drawing.SystemColors.Control;
            this.labeRegionalTarget.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labeRegionalTarget.Location = new System.Drawing.Point(1, 160);
            this.labeRegionalTarget.Name = "labeRegionalTarget";
            this.labeRegionalTarget.Size = new System.Drawing.Size(105, 13);
            this.labeRegionalTarget.TabIndex = 153;
            this.labeRegionalTarget.Text = "Regional Cup Target";
            this.labeRegionalTarget.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboRegionalTarget
            // 
            this.comboRegionalTarget.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.countryBindingSource, "ContinentalCupTarget", true, DataSourceUpdateMode.OnPropertyChanged));
            this.comboRegionalTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.comboRegionalTarget.ItemHeight = 13;
            this.comboRegionalTarget.Items.AddRange(new object[] {
            "N/A",
            "WIN",
            "FINAL",
            "SEMI",
            "QUARTER",
            "KNOCKOUT",
            "QUALIFY"});
            this.comboRegionalTarget.Location = new System.Drawing.Point(108, 156);
            this.comboRegionalTarget.Name = "comboRegionalTarget";
            this.comboRegionalTarget.Size = new System.Drawing.Size(115, 21);
            this.comboRegionalTarget.TabIndex = 155;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(6, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 164;
            this.label5.Text = "ISO Country Code";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textCountryISO
            // 
            this.textCountryISO.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.countryBindingSource, "ISOCountryCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textCountryISO.Location = new System.Drawing.Point(117, 164);
            this.textCountryISO.Name = "textCountryISO";
            this.textCountryISO.Size = new System.Drawing.Size(117, 20);
            this.textCountryISO.TabIndex = 163;
            this.textCountryISO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // viewer2DFlag512
            // 
            this.viewer2DFlag512.AutoTransparency = false;
            this.viewer2DFlag512.BackColor = System.Drawing.Color.Transparent;
            this.viewer2DFlag512.ButtonStripVisible = true;
            this.viewer2DFlag512.CurrentBitmap = null;
            this.viewer2DFlag512.ExtendedFormat = false;
            this.viewer2DFlag512.FullSizeButton = false;
            this.viewer2DFlag512.ImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.viewer2DFlag512.ImageSize = new System.Drawing.Size(512, 512);
            this.viewer2DFlag512.ImageSizeMultiplier = FifaControls.Viewer2D.SizeMultiplier.None;
            this.viewer2DFlag512.Location = new System.Drawing.Point(525, 14);
            this.viewer2DFlag512.Name = "viewer2DFlag512";
            this.viewer2DFlag512.RemoveButton = false;
            this.viewer2DFlag512.ShowButton = true;
            this.viewer2DFlag512.ShowButtonChecked = true;
            this.viewer2DFlag512.Size = new System.Drawing.Size(256, 281);
            this.viewer2DFlag512.TabIndex = 162;
            this.toolTip.SetToolTip(this.viewer2DFlag512, "Country Flag 512 x 512");
            // 
            // labelContry3Letters
            // 
            this.labelContry3Letters.AutoSize = true;
            this.labelContry3Letters.BackColor = System.Drawing.Color.Transparent;
            this.labelContry3Letters.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelContry3Letters.Location = new System.Drawing.Point(6, 116);
            this.labelContry3Letters.Name = "labelContry3Letters";
            this.labelContry3Letters.Size = new System.Drawing.Size(66, 13);
            this.labelContry3Letters.TabIndex = 161;
            this.labelContry3Letters.Text = "Abbreviation";
            this.labelContry3Letters.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textLanguageAbbreviation
            // 
            this.textLanguageAbbreviation.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.countryBindingSource, "LanguageAbbreviation", true, DataSourceUpdateMode.OnPropertyChanged));
            this.textLanguageAbbreviation.Location = new System.Drawing.Point(101, 112);
            this.textLanguageAbbreviation.Name = "textLanguageAbbreviation";
            this.textLanguageAbbreviation.Size = new System.Drawing.Size(133, 20);
            this.textLanguageAbbreviation.TabIndex = 160;
            // 
            // textLanguageShortName
            // 
            this.textLanguageShortName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.countryBindingSource, "LanguageShortName", true));
            this.textLanguageShortName.Location = new System.Drawing.Point(101, 87);
            this.textLanguageShortName.Name = "textLanguageShortName";
            this.textLanguageShortName.Size = new System.Drawing.Size(133, 20);
            this.textLanguageShortName.TabIndex = 158;
            this.textLanguageShortName.TextChanged += new System.EventHandler(this.textLanguageShortName_TextChanged);
            // 
            // labelNationShortName
            // 
            this.labelNationShortName.AutoSize = true;
            this.labelNationShortName.BackColor = System.Drawing.Color.Transparent;
            this.labelNationShortName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelNationShortName.Location = new System.Drawing.Point(6, 91);
            this.labelNationShortName.Name = "labelNationShortName";
            this.labelNationShortName.Size = new System.Drawing.Size(63, 13);
            this.labelNationShortName.TabIndex = 159;
            this.labelNationShortName.Text = "Short Name";
            this.labelNationShortName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(7, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 157;
            this.label4.Text = "Level";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericLevel
            // 
            this.numericLevel.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.countryBindingSource, "Level", true));
            this.numericLevel.Location = new System.Drawing.Point(117, 192);
            this.numericLevel.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericLevel.Name = "numericLevel";
            this.numericLevel.Size = new System.Drawing.Size(117, 20);
            this.numericLevel.TabIndex = 156;
            this.numericLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericLevel.ValueChanged += new System.EventHandler(this.numericLevel_ValueChanged);
            // 
            // checkTopTier
            // 
            this.checkTopTier.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.countryBindingSource, "Top_tier", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkTopTier.Location = new System.Drawing.Point(4, 221);
            this.checkTopTier.Name = "checkTopTier";
            this.checkTopTier.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkTopTier.Size = new System.Drawing.Size(169, 18);
            this.checkTopTier.TabIndex = 151;
            this.checkTopTier.Text = "Top tier";
            this.checkTopTier.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkTopTier.UseVisualStyleBackColor = true;
            // 
            // buttonGetId
            // 
            this.buttonGetId.Image = ((System.Drawing.Image)(resources.GetObject("buttonGetId.Image")));
            this.buttonGetId.Location = new System.Drawing.Point(207, 38);
            this.buttonGetId.Name = "buttonGetId";
            this.buttonGetId.Size = new System.Drawing.Size(25, 23);
            this.buttonGetId.TabIndex = 150;
            this.toolTip.SetToolTip(this.buttonGetId, "Get a free id");
            this.buttonGetId.UseVisualStyleBackColor = true;
            this.buttonGetId.Click += new System.EventHandler(this.buttonGetId_Click);
            // 
            // viewer2DFlag
            // 
            this.viewer2DFlag.AutoTransparency = true;
            this.viewer2DFlag.BackColor = System.Drawing.Color.Transparent;
            this.viewer2DFlag.ButtonStripVisible = true;
            this.viewer2DFlag.CurrentBitmap = null;
            this.viewer2DFlag.ExtendedFormat = false;
            this.viewer2DFlag.FullSizeButton = false;
            this.viewer2DFlag.ImageLayout = System.Windows.Forms.ImageLayout.None;
            this.viewer2DFlag.ImageSize = new System.Drawing.Size(256, 256);
            this.viewer2DFlag.ImageSizeMultiplier = FifaControls.Viewer2D.SizeMultiplier.Auto256;
            this.viewer2DFlag.Location = new System.Drawing.Point(240, 13);
            this.viewer2DFlag.Name = "viewer2DFlag";
            this.viewer2DFlag.RemoveButton = false;
            this.viewer2DFlag.ShowButton = true;
            this.viewer2DFlag.ShowButtonChecked = true;
            this.viewer2DFlag.Size = new System.Drawing.Size(256, 281);
            this.viewer2DFlag.TabIndex = 1;
            this.toolTip.SetToolTip(this.viewer2DFlag, "Country Badge");
            // 
            // viewer2DMiniFlag
            // 
            this.viewer2DMiniFlag.AutoTransparency = false;
            this.viewer2DMiniFlag.BackColor = System.Drawing.Color.Transparent;
            this.viewer2DMiniFlag.ButtonStripVisible = true;
            this.viewer2DMiniFlag.CurrentBitmap = null;
            this.viewer2DMiniFlag.ExtendedFormat = false;
            this.viewer2DMiniFlag.FullSizeButton = false;
            this.viewer2DMiniFlag.ImageLayout = System.Windows.Forms.ImageLayout.None;
            this.viewer2DMiniFlag.ImageSize = new System.Drawing.Size(64, 64);
            this.viewer2DMiniFlag.ImageSizeMultiplier = FifaControls.Viewer2D.SizeMultiplier.None;
            this.viewer2DMiniFlag.Location = new System.Drawing.Point(238, 313);
            this.viewer2DMiniFlag.Name = "viewer2DMiniFlag";
            this.viewer2DMiniFlag.RemoveButton = false;
            this.viewer2DMiniFlag.ShowButton = true;
            this.viewer2DMiniFlag.ShowButtonChecked = true;
            this.viewer2DMiniFlag.Size = new System.Drawing.Size(64, 64);
            this.viewer2DMiniFlag.TabIndex = 2;
            // 
            // numericCountryId
            // 
            this.numericCountryId.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.countryBindingSource, "Id", true));
            this.numericCountryId.Location = new System.Drawing.Point(101, 39);
            this.numericCountryId.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.numericCountryId.Name = "numericCountryId";
            this.numericCountryId.Size = new System.Drawing.Size(100, 20);
            this.numericCountryId.TabIndex = 143;
            this.numericCountryId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericCountryId.ValueChanged += new System.EventHandler(this.numericCountryId_ValueChanged);
            // 
            // comboContinent
            // 
            this.comboContinent.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.countryBindingSource, "Confederation", true, DataSourceUpdateMode.OnPropertyChanged));
            this.comboContinent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.comboContinent.ItemHeight = 13;
            this.comboContinent.Items.AddRange(new object[] {
            "None",
            "Europe",
            "Africa",
            "South America",
            "Asia",
            "Oceania",
            "North America"});
            this.comboContinent.Location = new System.Drawing.Point(101, 138);
            this.comboContinent.Name = "comboContinent";
            this.comboContinent.Size = new System.Drawing.Size(133, 21);
            this.comboContinent.TabIndex = 145;
            // 
            // textLanguageName
            // 
            this.textLanguageName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.countryBindingSource, "LanguageName", true));
            this.textLanguageName.Location = new System.Drawing.Point(101, 63);
            this.textLanguageName.Name = "textLanguageName";
            this.textLanguageName.Size = new System.Drawing.Size(133, 20);
            this.textLanguageName.TabIndex = 144;
            this.textLanguageName.TextChanged += new System.EventHandler(this.textLanguageName_TextChanged);
            // 
            // labelLanguageName
            // 
            this.labelLanguageName.AutoSize = true;
            this.labelLanguageName.BackColor = System.Drawing.Color.Transparent;
            this.labelLanguageName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelLanguageName.Location = new System.Drawing.Point(6, 67);
            this.labelLanguageName.Name = "labelLanguageName";
            this.labelLanguageName.Size = new System.Drawing.Size(35, 13);
            this.labelLanguageName.TabIndex = 147;
            this.labelLanguageName.Text = "Name";
            this.labelLanguageName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textDatabaseCountryName
            // 
            this.textDatabaseCountryName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.countryBindingSource, "DatabaseName", true, DataSourceUpdateMode.OnPropertyChanged));
            this.textDatabaseCountryName.Location = new System.Drawing.Point(101, 14);
            this.textDatabaseCountryName.Name = "textDatabaseCountryName";
            this.textDatabaseCountryName.Size = new System.Drawing.Size(133, 20);
            this.textDatabaseCountryName.TabIndex = 142;
            // 
            // labelDatabaseCountryName
            // 
            this.labelDatabaseCountryName.AutoSize = true;
            this.labelDatabaseCountryName.BackColor = System.Drawing.Color.Transparent;
            this.labelDatabaseCountryName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelDatabaseCountryName.Location = new System.Drawing.Point(6, 17);
            this.labelDatabaseCountryName.Name = "labelDatabaseCountryName";
            this.labelDatabaseCountryName.Size = new System.Drawing.Size(84, 13);
            this.labelDatabaseCountryName.TabIndex = 146;
            this.labelDatabaseCountryName.Text = "Database Name";
            this.labelDatabaseCountryName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelContinent
            // 
            this.labelContinent.AutoSize = true;
            this.labelContinent.BackColor = System.Drawing.Color.Transparent;
            this.labelContinent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelContinent.Location = new System.Drawing.Point(6, 143);
            this.labelContinent.Name = "labelContinent";
            this.labelContinent.Size = new System.Drawing.Size(73, 13);
            this.labelContinent.TabIndex = 148;
            this.labelContinent.Text = "Confederation";
            this.labelContinent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCountrId
            // 
            this.labelCountrId.AutoSize = true;
            this.labelCountrId.BackColor = System.Drawing.Color.Transparent;
            this.labelCountrId.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCountrId.Location = new System.Drawing.Point(6, 42);
            this.labelCountrId.Name = "labelCountrId";
            this.labelCountrId.Size = new System.Drawing.Size(55, 13);
            this.labelCountrId.TabIndex = 149;
            this.labelCountrId.Text = "Country Id";
            this.labelCountrId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupCountryShape
            // 
            this.groupCountryShape.Controls.Add(this.viewer2DShape);
            this.groupCountryShape.Location = new System.Drawing.Point(809, 3);
            this.groupCountryShape.Name = "groupCountryShape";
            this.groupCountryShape.Size = new System.Drawing.Size(528, 308);
            this.groupCountryShape.TabIndex = 4;
            this.groupCountryShape.TabStop = false;
            this.groupCountryShape.Text = "Map (Shape)";
            // 
            // viewer2DShape
            // 
            this.viewer2DShape.AutoTransparency = true;
            this.viewer2DShape.BackColor = System.Drawing.Color.Transparent;
            this.viewer2DShape.ButtonStripVisible = true;
            this.viewer2DShape.CurrentBitmap = null;
            this.viewer2DShape.ExtendedFormat = false;
            this.viewer2DShape.FullSizeButton = false;
            this.viewer2DShape.ImageLayout = System.Windows.Forms.ImageLayout.None;
            this.viewer2DShape.ImageSize = new System.Drawing.Size(512, 256);
            this.viewer2DShape.ImageSizeMultiplier = FifaControls.Viewer2D.SizeMultiplier.None;
            this.viewer2DShape.Location = new System.Drawing.Point(6, 16);
            this.viewer2DShape.Name = "viewer2DShape";
            this.viewer2DShape.RemoveButton = false;
            this.viewer2DShape.ShowButton = true;
            this.viewer2DShape.ShowButtonChecked = true;
            this.viewer2DShape.Size = new System.Drawing.Size(512, 281);
            this.viewer2DShape.TabIndex = 2;
            this.toolTip.SetToolTip(this.viewer2DShape, "Country Badge");
            // 
            // groupAudio
            // 
            this.groupAudio.Controls.Add(this.label3);
            this.groupAudio.Controls.Add(this.label2);
            this.groupAudio.Controls.Add(this.label1);
            this.groupAudio.Controls.Add(this.comboPepper);
            this.groupAudio.Controls.Add(this.comboPlayerCall);
            this.groupAudio.Controls.Add(this.comboCrowdType);
            this.groupAudio.Controls.Add(this.checkCanWhistle);
            this.groupAudio.Controls.Add(this.checkTauntKeeper);
            this.groupAudio.Controls.Add(this.comboLanguage);
            this.groupAudio.Controls.Add(this.label15);
            this.groupAudio.Controls.Add(this.label14);
            this.groupAudio.Controls.Add(this.label11);
            this.groupAudio.Controls.Add(this.label10);
            this.groupAudio.Controls.Add(this.comboChants);
            this.groupAudio.Controls.Add(this.label9);
            this.groupAudio.Location = new System.Drawing.Point(3, 449);
            this.groupAudio.Name = "groupAudio";
            this.groupAudio.Size = new System.Drawing.Size(624, 250);
            this.groupAudio.TabIndex = 3;
            this.groupAudio.TabStop = false;
            this.groupAudio.Text = "Audio";
            this.groupAudio.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Reactions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Heckles";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Ambience";
            // 
            // comboPepper
            // 
            this.comboPepper.FormattingEnabled = true;
            this.comboPepper.Items.AddRange(new object[] {
            "Undefined",
            "English",
            "French",
            "Italian",
            "German",
            "Spanish",
            "Scandinavian",
            "Brazilian"});
            this.comboPepper.Location = new System.Drawing.Point(88, 132);
            this.comboPepper.Name = "comboPepper";
            this.comboPepper.Size = new System.Drawing.Size(145, 21);
            this.comboPepper.TabIndex = 29;
            this.comboPepper.SelectedIndexChanged += new System.EventHandler(this.comboPepper_SelectedIndexChanged);
            // 
            // comboPlayerCall
            // 
            this.comboPlayerCall.FormattingEnabled = true;
            this.comboPlayerCall.Items.AddRange(new object[] {
            "English",
            "French",
            "Italian",
            "German",
            "Spanish",
            "Brazilian",
            "Japaneese",
            "Korean",
            "Dutch",
            "Danish",
            "Swedish",
            "Norwegian",
            "Portuguese",
            "Russian",
            "US English",
            "Iranian",
            "Indian",
            "Chineese",
            "Arabic"});
            this.comboPlayerCall.Location = new System.Drawing.Point(88, 105);
            this.comboPlayerCall.Name = "comboPlayerCall";
            this.comboPlayerCall.Size = new System.Drawing.Size(145, 21);
            this.comboPlayerCall.TabIndex = 28;
            this.comboPlayerCall.SelectedIndexChanged += new System.EventHandler(this.comboPlayerCall_SelectedIndexChanged);
            // 
            // comboCrowdType
            // 
            this.comboCrowdType.FormattingEnabled = true;
            this.comboCrowdType.Items.AddRange(new object[] {
            " 0 = English",
            " 8 = Brazilian",
            "15 = Rest of World"});
            this.comboCrowdType.Location = new System.Drawing.Point(88, 78);
            this.comboCrowdType.Name = "comboCrowdType";
            this.comboCrowdType.Size = new System.Drawing.Size(145, 21);
            this.comboCrowdType.TabIndex = 27;
            this.comboCrowdType.SelectedIndexChanged += new System.EventHandler(this.comboCrowdType_SelectedIndexChanged);
            // 
            // checkCanWhistle
            // 
            this.checkCanWhistle.AutoSize = true;
            this.checkCanWhistle.Location = new System.Drawing.Point(259, 48);
            this.checkCanWhistle.Name = "checkCanWhistle";
            this.checkCanWhistle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkCanWhistle.Size = new System.Drawing.Size(83, 17);
            this.checkCanWhistle.TabIndex = 26;
            this.checkCanWhistle.Text = "Can Whistle";
            this.checkCanWhistle.UseVisualStyleBackColor = true;
            this.checkCanWhistle.CheckedChanged += new System.EventHandler(this.checkCanWhistle_CheckedChanged);
            // 
            // checkTauntKeeper
            // 
            this.checkTauntKeeper.AutoSize = true;
            this.checkTauntKeeper.Location = new System.Drawing.Point(251, 25);
            this.checkTauntKeeper.Name = "checkTauntKeeper";
            this.checkTauntKeeper.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkTauntKeeper.Size = new System.Drawing.Size(91, 17);
            this.checkTauntKeeper.TabIndex = 25;
            this.checkTauntKeeper.Text = "Taunt Keeper";
            this.checkTauntKeeper.UseVisualStyleBackColor = true;
            this.checkTauntKeeper.CheckedChanged += new System.EventHandler(this.checkTauntKeeper_CheckedChanged);
            // 
            // comboLanguage
            // 
            this.comboLanguage.FormattingEnabled = true;
            this.comboLanguage.Items.AddRange(new object[] {
            "English ",
            "French ",
            "German ",
            "Italian ",
            "Spanish from Spain ",
            "Croatian",
            "Czech",
            "Dutch",
            "Greek",
            "Polish ",
            "Russian",
            "Swedish",
            "Turkish",
            "Spanish from Mexico ",
            "Spanish from Argentina ",
            "Brazilian Portuguese",
            "Korean",
            "Japanese"});
            this.comboLanguage.Location = new System.Drawing.Point(89, 24);
            this.comboLanguage.Name = "comboLanguage";
            this.comboLanguage.Size = new System.Drawing.Size(144, 21);
            this.comboLanguage.TabIndex = 24;
            this.comboLanguage.SelectedIndexChanged += new System.EventHandler(this.comboLanguage_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 135);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 13);
            this.label15.TabIndex = 23;
            this.label15.Text = "Whistle";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 108);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 22;
            this.label14.Text = "Player Call";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Crowd Type";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Language";
            // 
            // comboChants
            // 
            this.comboChants.FormattingEnabled = true;
            this.comboChants.Items.AddRange(new object[] {
            "English Area",
            "French Area",
            "Italy",
            "German Area",
            "Spain",
            "Scandinavian Area",
            "Rest Of World",
            "Latin America",
            "Brazil",
            "Africa",
            "Asia",
            "Mexico",
            "Denmark",
            "Russian Area",
            "Portugal",
            "Turkey"});
            this.comboChants.Location = new System.Drawing.Point(89, 51);
            this.comboChants.Name = "comboChants";
            this.comboChants.Size = new System.Drawing.Size(144, 21);
            this.comboChants.TabIndex = 17;
            this.comboChants.SelectedIndexChanged += new System.EventHandler(this.comboChants_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Chants";
            // 
            // pickUpControl
            // 
            this.pickUpControl.BackColor = System.Drawing.SystemColors.Control;
            this.pickUpControl.CloneButtonEnabled = false;
            this.pickUpControl.CreateButtonEnabled = true;
            this.pickUpControl.CurrentIndex = 0;
            this.pickUpControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pickUpControl.FilterByList = null;
            this.pickUpControl.FilterEnabled = false;
            this.pickUpControl.FilterValues = null;
            this.pickUpControl.Location = new System.Drawing.Point(0, 0);
            this.pickUpControl.MainSelectionEnabled = true;
            this.pickUpControl.Name = "pickUpControl";
            this.pickUpControl.ObjectList = null;
            this.pickUpControl.RefreshButtonEnabled = true;
            this.pickUpControl.RemoveButtonEnabled = true;
            this.pickUpControl.SearchEnabled = true;
            this.pickUpControl.Size = new System.Drawing.Size(1357, 25);
            this.pickUpControl.TabIndex = 2;
            this.pickUpControl.WizardButtonEnabled = false;
            this.pickUpControl.YoungPlayersEnabled = false;
            // 
            // CountryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 832);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.pickUpControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CountryForm";
            this.Text = "Country";
            this.Load += new System.EventHandler(this.CountryForm_Load);
            this.flowLayoutPanel.ResumeLayout(false);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureNationalTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCountryId)).EndInit();
            this.groupCountryShape.ResumeLayout(false);
            this.groupAudio.ResumeLayout(false);
            this.groupAudio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sponsorListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        private void numericLevel_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentCountry.Level = (int)this.numericLevel.Value;
        }
    }
}
