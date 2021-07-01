// Original code created by Rinaldo

using FifaControls;
using FifaLibrary;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CreationMaster
{
  public class StadiumForm : Form
  {
    private NewIdCreator m_NewIdCreator = new NewIdCreator();
    private string m_Undefined = "< Undefined >";
    private Stadium m_CurrentStadium;
    private Stadium m_CopyStadium;
    private TabPage m_CurrentPage;
    private bool m_IsLoaded;
    private bool m_Locked;
    private IContainer components;
    public PickUpControl pickUpControl;
    private TabControl tabEsitStadium;
    private TabPage pageStadiumGeneral;
    private TabPage pageStadiumModel;
    private FlowLayoutPanel flowLayoutPanel1;
    private GroupBox groupBox1;
    private Button buttonGetId;
    private NumericUpDown numericStadiumId;
    private ComboBox comboHomeTeam;
    private TextBox textDatabaseStadiumName;
    private PictureBox pictureHomeTeam;
    private Label labelDatabaseStadiumName;
    private TextBox textLocalStadiumName;
    private Label labelLocalStadiumName;
    private Label labelStadiumId;
    private DomainUpDown domainStadiumType;
    private NumericUpDown numericYearBuilt;
    private NumericUpDown numericCapacity;
    private Label labelCapacity;
    private Label labelYearBuilt;
    private Label labelStadiumType;
    private NumericUpDown numericCrowdColor;
    private Label labelCrowdColor;
    private ComboBox comboCountry;
    private Label labelCountry;
    private CheckBox checkOrientation;
    private GroupBox groupMowingPattern;
    public NumericUpDown numericMowing;
    private Viewer2D viewer2DMowing;
    private GroupBox groupBox3;
    private Viewer2D viewer2DNet;
    public NumericUpDown numericNet;
    private CheckBox checkDeepNet;
    private GroupBox groupAdboards;
    private Label label1;
    private Label labelAdboardEndLine;
    private NumericUpDown numericSideLineDistance;
    private NumericUpDown numericEndLineDistance;
    private GroupBox groupTimeAndWeather;
    private CheckBox checkCloudyDay;
    private CheckBox checkSunnyDay;
    private ComboBox comboDayWeather;
    private CheckBox checkNight;
    private CheckBox checkSunset;
    private Label label2;
    private FlowLayoutPanel flowLayoutPanel2;
    private MultiViewer2D multiViewer2DTextures;
    private MultiViewer2D multiViewer2DCoverMap;
    private GroupBox groupBox5;
    private GroupBox groupBox6;
    private GroupBox groupPolice;
    private Viewer2D viewer2DPolice;
    private ComboBox comboPolice;
    private Button buttonCopyCrowd;
    private BindingSource stadiumListBindingSource;
    private GroupBox groupLights;
    private Label label3;
    private ComboBox comboStadiumLights;
    private Button buttonCopyLights;
    private TabPage pageStadiumPreview;
    private GroupBox groupEnvironment;
    private GroupBox groupBox4;
    private Viewer2D viewer2DPreviewLarge;
    private Viewer2D viewer2DPreview;
    private GroupBox groupBox2;
    private RadioButton radioPreviewOvercast;
    private RadioButton radioPreviewClearDay;
    private RadioButton radioPreviewSunset;
    private RadioButton radioPreviewNight;
    private GroupBox groupBox7;
    private RadioButton radioModelClearDay;
    private RadioButton radioModelSunset;
    private RadioButton radioModelNight;
    private RadioButton radioModelOvercast;
    private GroupBox groupCamera;
    public NumericUpDown numericCameraZoom;
    public NumericUpDown numericCameraHeight;
    private Label label4;
    private Label label5;
    public NumericUpDown numericAdboardType;
    private Label label6;

    public StadiumForm()
    {
      this.Visible = false;
      this.InitializeComponent();
      this.pickUpControl.SelectObject = new PickUpControl.PickUpCallback(this.SelectStadium);
      this.pickUpControl.DeleteObject = new PickUpControl.PickUpCallback(this.DeleteStadium);
      this.pickUpControl.CloneObject = new PickUpControl.PickUpCallback(this.CloneStadium);
      this.pickUpControl.RefreshObject = new PickUpControl.PickUpCallback(this.RefreshStadium);
      this.viewer2DPreview.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImagePreview);
      this.viewer2DPreview.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeletePreview);
      this.viewer2DPreview.ButtonStripVisible = true;
      this.viewer2DPreview.RemoveButton = true;
      this.viewer2DPreviewLarge.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImagePreviewLarge);
      this.viewer2DPreviewLarge.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeletePreviewLarge);
      this.viewer2DPreviewLarge.ButtonStripVisible = true;
      this.viewer2DPreviewLarge.RemoveButton = true;
      this.viewer2DMowing.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageMowing);
      this.viewer2DMowing.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteMowing);
      this.viewer2DMowing.ButtonStripVisible = true;
      this.viewer2DMowing.RemoveButton = true;
      this.viewer2DNet.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageNet);
      this.viewer2DNet.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteNet);
      this.viewer2DNet.ButtonStripVisible = true;
      this.viewer2DNet.RemoveButton = true;
      this.viewer2DPolice.ButtonStripVisible = false;
      this.multiViewer2DTextures.Rx3ExportDelegate = new MultiViewer2D.Rx3ExportHandler(this.ExportRx3StadiumTextures);
      this.multiViewer2DTextures.Rx3ImportDelegate = new MultiViewer2D.Rx3ImportHandler(this.ImportRx3StadiumTextures);
      this.multiViewer2DTextures.Rx3SaveDelegate = new MultiViewer2D.Rx3SaveHandler(this.SaveRx3StadiumTextures);
      this.multiViewer2DTextures.Rx3DeleteDelegate = new MultiViewer2D.Rx3DeleteHandler(this.DeleteRx3StadiumTextures);
      this.multiViewer2DTextures.ShowDeleteButton = true;
      if (FifaEnvironment.Year != 14)
        return;
      this.viewer2DMowing.ImageSize = new Size(1024, 1024);
      this.viewer2DPolice.ImageSize = new Size(256, 256);
    }

    public void Clean()
    {
      this.Visible = false;
    }

    public void Preset()
    {
      this.m_NewIdCreator.IdList = (IdArrayList) FifaEnvironment.Stadiums;
      this.numericStadiumId.Maximum = (Decimal) FifaEnvironment.Stadiums.MaxId;
      this.numericMowing.Maximum = (Decimal) FifaEnvironment.FifaDb.Table[TI.stadiums].TableDescriptor.MaxValues[FI.stadiums_stadiummowpattern_code];
      this.numericNet.Maximum = (Decimal) FifaEnvironment.FifaDb.Table[TI.stadiums].TableDescriptor.MaxValues[FI.stadiums_stadiumgoalnetstyle];
      this.pickUpControl.FilterValues = new IdArrayList[2]
      {
        (IdArrayList) null,
        (IdArrayList) FifaEnvironment.Countries
      };
      this.RefreshComboBoxes();
      this.stadiumListBindingSource.DataSource = (object) FifaEnvironment.Stadiums;
      this.pickUpControl.ObjectList = (IdArrayList) FifaEnvironment.Stadiums;
      if (FifaEnvironment.Year != 2014)
        return;
      this.viewer2DMowing.ImageSize = new Size(1024, 1024);
    }

    public void RefreshComboBoxes()
    {
      if (this.comboCountry.Items.Count != FifaEnvironment.Countries.Count + 1)
      {
        this.comboCountry.Items.Clear();
        this.comboCountry.Items.Add((object) "None");
        this.comboCountry.Items.AddRange(FifaEnvironment.Countries.ToArray());
      }
      if (this.comboHomeTeam.Items.Count == FifaEnvironment.Teams.Count + 1)
        return;
      this.comboHomeTeam.Items.Clear();
      this.comboHomeTeam.Items.Add((object) this.m_Undefined);
      this.comboHomeTeam.Items.AddRange(FifaEnvironment.Teams.ToArray());
    }

    private void StadiumForm_Load(object sender, EventArgs e)
    {
      this.m_IsLoaded = true;
      this.Preset();
    }

    private Stadium SelectStadium(object sender, object obj)
    {
      Stadium stadium = (Stadium) obj;
      this.Refresh();
      this.LoadStadium(stadium);
      return stadium;
    }

    private Stadium DeleteStadium(object sender, object obj)
    {
      FifaEnvironment.Stadiums.DeleteStadium((Stadium) obj);
      this.m_CurrentStadium = (Stadium) null;
      return (Stadium) null;
    }

    private Stadium CloneStadium(object sender, object obj)
    {
      DialogResult dialogResult = this.m_NewIdCreator.ShowDialog();
      if (this.m_NewIdCreator.NewObject != null)
        return (Stadium) FifaEnvironment.Stadiums.CloneId((IdObject) obj, this.m_NewIdCreator.NewObject);
      if (dialogResult == DialogResult.OK)
      {
        int num = (int) FifaEnvironment.UserMessages.ShowMessage(5060, this.m_NewIdCreator.NewId);
      }
      return (Stadium) null;
    }

    public Stadium RefreshStadium(object sender, object obj)
    {
      this.Preset();
      this.ReloadStadium(this.m_CurrentStadium);
      return this.m_CurrentStadium;
    }

    public void ReloadStadium(Stadium stadium)
    {
      this.m_CurrentStadium = (Stadium) null;
      this.LoadStadium(stadium);
    }

    private bool ImportImagePreview(object sender, Bitmap bitmap)
    {
      int timeofday = this.CurrentPreviewTimeOfDay();
      return timeofday >= 0 && this.m_CurrentStadium.SetPreview(timeofday, bitmap);
    }

    private bool DeletePreview(object sender)
    {
      int timeofday = this.CurrentPreviewTimeOfDay();
      return timeofday >= 0 && this.m_CurrentStadium.DeletePreview(timeofday);
    }

    private bool ImportImagePreviewLarge(object sender, Bitmap bitmap)
    {
      int timeofday = this.CurrentPreviewTimeOfDay();
      return timeofday >= 0 && this.m_CurrentStadium.SetPreviewLarge(timeofday, bitmap);
    }

    private bool DeletePreviewLarge(object sender)
    {
      int timeofday = this.CurrentPreviewTimeOfDay();
      return timeofday >= 0 && this.m_CurrentStadium.DeletePreviewLarge(timeofday);
    }

    private bool ImportImageNet(object sender, Bitmap bitmap)
    {
      return this.m_CurrentStadium.SetNet(bitmap);
    }

    private bool DeleteNet(object sender)
    {
      return this.m_CurrentStadium.DeleteNet();
    }

    private bool ImportImageMowing(object sender, Bitmap bitmap)
    {
      return this.m_CurrentStadium.SetMowingPattern(bitmap);
    }

    private bool DeleteMowing(object sender)
    {
      return this.m_CurrentStadium.DeleteMowingPattern();
    }

    private bool ImportImagePolice(object sender, Bitmap bitmap)
    {
      return this.m_CurrentStadium.SetPolice(bitmap);
    }

    private bool DeletePolice(object sender)
    {
      return this.m_CurrentStadium.DeletePolice();
    }

    private bool ExportRx3StadiumTextures(object sender, string exportDir)
    {
      int timeofday = this.CurrentModelTimeOfDay();
      return timeofday >= 0 && FifaEnvironment.ExportFileFromZdata(this.m_CurrentStadium.TexturesFileName(timeofday), exportDir);
    }

    private bool SaveRx3StadiumTextures(object sender, Bitmap[] bitmaps)
    {
      int timeofday = this.CurrentModelTimeOfDay();
      if (timeofday < 0)
        return false;
      bool flag = this.m_CurrentStadium.SetTextures(timeofday, bitmaps);
      if (flag)
        this.ReloadStadium(this.m_CurrentStadium);
      return flag;
    }

    private bool ImportRx3StadiumTextures(object sender, string rx3FileName)
    {
      int timeofday = this.CurrentModelTimeOfDay();
      if (timeofday < 0)
        return false;
      bool flag = this.m_CurrentStadium.SetTextures(timeofday, rx3FileName);
      if (flag)
        this.ReloadStadium(this.m_CurrentStadium);
      return flag;
    }

    private bool DeleteRx3StadiumTextures(object sender)
    {
      int timeofday = this.CurrentModelTimeOfDay();
      if (timeofday < 0)
        return false;
      bool flag = this.m_CurrentStadium.DeleteContainer(timeofday);
      if (flag)
        this.ReloadStadium(this.m_CurrentStadium);
      return flag;
    }

    public void LoadStadium(Stadium stadium)
    {
      if (!this.m_IsLoaded || this.m_CurrentStadium == stadium && this.m_CurrentPage == this.tabEsitStadium.SelectedTab)
        return;
      this.m_CurrentStadium = stadium;
      this.m_CurrentPage = this.tabEsitStadium.SelectedTab;
      if (this.m_CurrentPage == this.pageStadiumGeneral)
        this.LoadStadiumGeneral();
      else if (this.m_CurrentPage == this.pageStadiumModel)
      {
        this.LoadStadiumModel();
      }
      else
      {
        if (this.m_CurrentPage != this.pageStadiumPreview)
          return;
        this.LoadStadiumPreview();
      }
    }

    public void LoadStadiumModel()
    {
      this.m_Locked = true;
      this.AdjustPreviewModelRadio();
      int timeofday = this.CurrentModelTimeOfDay();
      if (timeofday < 0)
      {
        this.multiViewer2DTextures.Bitmaps = (Bitmap[]) null;
        this.multiViewer2DCoverMap.Bitmaps = (Bitmap[]) null;
      }
      else
      {
        Cursor.Current = Cursors.WaitCursor;
        this.multiViewer2DTextures.Bitmaps = this.m_CurrentStadium.GetTextures(timeofday);
        this.EnableCopyButtons();
        Cursor.Current = Cursors.Default;
        this.m_Locked = false;
      }
    }

    public void LoadStadiumPreview()
    {
      this.m_Locked = true;
      this.AdjustPreviewWeatherRadio();
      int timeofday = this.CurrentPreviewTimeOfDay();
      if (timeofday < 0)
      {
        this.viewer2DPreview.CurrentBitmap = (Bitmap) null;
        this.viewer2DPreviewLarge.CurrentBitmap = (Bitmap) null;
      }
      else
      {
        Cursor.Current = Cursors.WaitCursor;
        this.viewer2DPreview.CurrentBitmap = this.m_CurrentStadium.GetPreview(timeofday);
        this.viewer2DPreviewLarge.CurrentBitmap = this.m_CurrentStadium.GetPreviewLarge(timeofday);
        Cursor.Current = Cursors.Default;
        this.m_Locked = false;
      }
    }

    private int CurrentModelTimeOfDay()
    {
      int num = -1;
      if (this.radioModelClearDay.Checked)
        num = 1;
      if (this.radioModelNight.Checked)
        num = 3;
      if (this.radioModelOvercast.Checked)
        num = 0;
      if (this.radioModelSunset.Checked)
        num = 4;
      return num;
    }

    private int CurrentPreviewTimeOfDay()
    {
      int num = -1;
      if (this.radioPreviewClearDay.Checked)
        num = 1;
      if (this.radioPreviewNight.Checked)
        num = 3;
      if (this.radioPreviewOvercast.Checked)
        num = 0;
      if (this.radioPreviewSunset.Checked)
        num = 4;
      return num;
    }

    private void AdjustPreviewWeatherRadio()
    {
      this.radioPreviewClearDay.Enabled = true;
      this.radioPreviewNight.Enabled = true;
      this.radioPreviewOvercast.Enabled = true;
      this.radioPreviewSunset.Enabled = true;
      this.CurrentPreviewTimeOfDay();
    }

    private void AdjustPreviewModelRadio()
    {
      this.radioPreviewClearDay.Enabled = true;
      this.radioPreviewNight.Enabled = true;
      this.radioPreviewOvercast.Enabled = true;
      this.radioPreviewSunset.Enabled = true;
      this.CurrentModelTimeOfDay();
    }

    public void LoadStadiumGeneral()
    {
      this.m_Locked = true;
      this.textDatabaseStadiumName.Text = this.m_CurrentStadium.name;
      this.textLocalStadiumName.Text = this.m_CurrentStadium.LocalName;
      this.numericStadiumId.Value = (Decimal) this.m_CurrentStadium.Id;
      this.numericCapacity.Value = (Decimal) this.m_CurrentStadium.capacity;
      this.numericYearBuilt.Value = (Decimal) this.m_CurrentStadium.yearbuilt;
      this.numericCrowdColor.Value = (Decimal) this.m_CurrentStadium.seatcolor;
      this.checkOrientation.Checked = this.m_CurrentStadium.sectionfacedbydefault == 1;
      this.domainStadiumType.SelectedIndex = this.m_CurrentStadium.stadiumtype;
      this.numericEndLineDistance.Value = (Decimal) this.m_CurrentStadium.adboardendlinedistance;
      this.numericSideLineDistance.Value = (Decimal) this.m_CurrentStadium.adboardsidelinedistance;
      this.numericMowing.Value = (Decimal) this.m_CurrentStadium.MowingPatternId;
      this.numericNet.Value = (Decimal) this.m_CurrentStadium.NetColor;
      this.comboPolice.SelectedIndex = this.m_CurrentStadium.policetypecode;
      this.checkSunnyDay.Checked = this.m_CurrentStadium.HasSunnyDay();
      this.checkCloudyDay.Checked = this.m_CurrentStadium.HasCloudyDay();
      this.checkSunset.Checked = this.m_CurrentStadium.HasSunset();
      this.checkNight.Checked = this.m_CurrentStadium.HasNight();
      this.checkDeepNet.Checked = this.m_CurrentStadium.IsDeepNet;
      if (this.m_CurrentStadium.Country == null)
        this.comboCountry.SelectedIndex = 0;
      else
        this.comboCountry.SelectedItem = (object) this.m_CurrentStadium.Country;
      this.comboDayWeather.SelectedIndex = this.m_CurrentStadium.GetWeather();
      if (this.m_CurrentStadium.hometeamid == 0 || this.m_CurrentStadium.HomeTeam == null)
      {
        this.comboHomeTeam.SelectedItem = (object) this.m_Undefined;
        this.pictureHomeTeam.BackgroundImage = (Image) null;
      }
      else
      {
        this.comboHomeTeam.SelectedItem = (object) this.m_CurrentStadium.HomeTeam;
        this.pictureHomeTeam.BackgroundImage = (Image) this.m_CurrentStadium.HomeTeam.GetCrest();
      }
      this.viewer2DPolice.CurrentBitmap = this.m_CurrentStadium.GetPolice();
      this.numericCameraHeight.Value = (Decimal) this.m_CurrentStadium.cameraheight;
      this.numericCameraZoom.Value = (Decimal) this.m_CurrentStadium.camerazoom;
      this.numericAdboardType.Value = (Decimal) this.m_CurrentStadium.adboardtype;
      this.m_Locked = false;
    }

    private void labelCountry_DoubleClick(object sender, EventArgs e)
    {
      if (this.m_CurrentStadium.Country == null)
        return;
      MainForm.CM.JumpTo((IdObject) this.m_CurrentStadium.Country);
    }

    private void textDatabaseStadiumName_TextChanged(object sender, EventArgs e)
    {
      if (this.m_Locked)
        return;
      this.m_CurrentStadium.name = this.textDatabaseStadiumName.Text;
      this.pickUpControl.SwitchObject((IdObject) this.m_CurrentStadium);
    }

    private void textLocalStadiumName_TextChanged(object sender, EventArgs e)
    {
      if (this.m_Locked)
        return;
      this.m_CurrentStadium.LocalName = this.textLocalStadiumName.Text;
    }

    private void numericCapacity_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_Locked)
        return;
      this.m_CurrentStadium.capacity = (int) this.numericCapacity.Value;
    }

    private void numericYearBuilt_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_Locked)
        return;
      this.m_CurrentStadium.yearbuilt = (int) this.numericYearBuilt.Value;
    }

    private void domainStadiumType_SelectedItemChanged(object sender, EventArgs e)
    {
      if (this.m_Locked)
        return;
      this.m_CurrentStadium.stadiumtype = this.domainStadiumType.SelectedIndex;
    }

    private void numericStadiumId_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_Locked)
        return;
      int num1 = (int) this.numericStadiumId.Value;
      if (num1 == this.m_CurrentStadium.Id)
        return;
      if (FifaEnvironment.Stadiums.SearchId(num1) == null)
      {
        FifaEnvironment.Stadiums.ChangeId((IdObject) this.m_CurrentStadium, num1);
      }
      else
      {
        int num2 = (int) FifaEnvironment.UserMessages.ShowMessage(1015);
        this.numericStadiumId.Value = (Decimal) this.m_CurrentStadium.Id;
      }
    }

    private void buttonGetId_Click(object sender, EventArgs e)
    {
      int newId = FifaEnvironment.Stadiums.GetNewId();
      if (newId == -1)
      {
        int num = (int) FifaEnvironment.UserMessages.ShowMessage(5050);
      }
      else
        this.numericStadiumId.Value = (Decimal) newId;
    }

    private void comboHomeTeam_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_Locked)
        return;
      if (this.comboHomeTeam.SelectedIndex == 0)
      {
        this.m_CurrentStadium.hometeamid = 0;
        this.m_CurrentStadium.HomeTeam = (Team) null;
        this.pictureHomeTeam.Image = (Image) null;
      }
      else
      {
        Team selectedItem = (Team) this.comboHomeTeam.SelectedItem;
        this.m_CurrentStadium.hometeamid = selectedItem.Id;
        this.m_CurrentStadium.HomeTeam = selectedItem;
        this.pictureHomeTeam.Image = (Image) selectedItem.GetCrest32();
      }
    }

    private void comboCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_Locked || this.comboCountry.SelectedIndex < 0)
        return;
      if (this.comboCountry.SelectedIndex == 0)
        this.m_CurrentStadium.Country = (Country) null;
      else
        this.m_CurrentStadium.Country = (Country) this.comboCountry.SelectedItem;
    }

    private void numericCrowdColor_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_Locked)
        return;
      this.m_CurrentStadium.seatcolor = (int) this.numericCrowdColor.Value;
    }

    private void numericEndLineDistance_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_Locked)
        return;
      this.m_CurrentStadium.adboardendlinedistance = (int) this.numericEndLineDistance.Value;
    }

    private void numericSideLineDistance_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_Locked)
        return;
      this.m_CurrentStadium.adboardsidelinedistance = (int) this.numericSideLineDistance.Value;
    }

    private void numericMowing_ValueChanged(object sender, EventArgs e)
    {
      this.m_CurrentStadium.MowingPatternId = (int) this.numericMowing.Value;
      this.viewer2DMowing.DisposeBitmap();
      this.viewer2DMowing.CurrentBitmap = this.m_CurrentStadium.GetMowingPattern();
    }

    private void numericNet_ValueChanged(object sender, EventArgs e)
    {
      this.m_CurrentStadium.NetColor = (int) this.numericNet.Value;
      this.viewer2DNet.CurrentBitmap = this.m_CurrentStadium.GetNet();
    }

    private void radioModelOvercast_CheckedChanged(object sender, EventArgs e)
    {
      this.LoadStadiumModel();
    }

    private void radioModelClearDay_CheckedChanged(object sender, EventArgs e)
    {
      this.LoadStadiumModel();
    }

    private void radioModelNight_CheckedChanged(object sender, EventArgs e)
    {
      this.LoadStadiumModel();
    }

    private void radioModelSunset_CheckedChanged(object sender, EventArgs e)
    {
      this.LoadStadiumModel();
    }

    private void tabEsitStadium_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.LoadStadium(this.m_CurrentStadium);
    }

    private void checkDeepNet_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_Locked)
        return;
      this.m_CurrentStadium.IsDeepNet = this.checkDeepNet.Checked;
    }

    private void checkOrientation_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_Locked)
        return;
      this.m_CurrentStadium.sectionfacedbydefault = this.checkOrientation.Checked ? 1 : 0;
    }

    private void comboDayWeather_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_Locked || this.comboDayWeather.SelectedIndex < 0)
        return;
      this.m_CurrentStadium.SetWeather(this.comboDayWeather.SelectedIndex);
    }

    private void checkSunnyDay_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_Locked)
        return;
      this.m_CurrentStadium.SetSunnyDay(this.checkSunnyDay.Checked);
    }

    private void checkCloudyDay_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_Locked)
        return;
      this.m_CurrentStadium.SetCloudyDay(this.checkCloudyDay.Checked);
    }

    private void checkSunset_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_Locked)
        return;
      this.m_CurrentStadium.SetSunset(this.checkSunset.Checked);
    }

    private void checkNight_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_Locked)
        return;
      this.m_CurrentStadium.SetNight(this.checkNight.Checked);
    }

    private void comboPolice_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_Locked || this.m_CurrentStadium.policetypecode == this.comboPolice.SelectedIndex)
        return;
      this.m_CurrentStadium.policetypecode = this.comboPolice.SelectedIndex;
      this.viewer2DPolice.CurrentBitmap = this.m_CurrentStadium.GetPolice();
    }

    private void EnableCopyButtons()
    {
      this.m_CopyStadium = (Stadium) this.comboStadiumLights.SelectedItem;
      int timeofday = this.CurrentModelTimeOfDay();
      bool flag1 = false;
      if (this.m_CopyStadium != null)
        flag1 = FifaEnvironment.IsFilePresent(Stadium.GlaresLightFileNames(this.m_CopyStadium.Id)[0]);
      this.buttonCopyLights.Enabled = flag1;
      bool flag2 = false;
      if (this.m_CopyStadium != null)
        flag2 = FifaEnvironment.IsFilePresent(Stadium.CrowdFileName(this.m_CopyStadium.Id, timeofday));
      this.buttonCopyCrowd.Enabled = flag2;
    }

    private void comboStadiumLights_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.EnableCopyButtons();
    }

    private void buttonCopyCrowd_Click(object sender, EventArgs e)
    {
      int timeofday = this.CurrentModelTimeOfDay();
      if (timeofday < 0 || this.m_CopyStadium == null)
        return;
      this.m_CopyStadium.CloneCrowd(this.m_CurrentStadium.Id, timeofday);
    }

    private void buttonCopyLights_Click(object sender, EventArgs e)
    {
      if (this.CurrentModelTimeOfDay() < 0 || this.m_CopyStadium == null)
        return;
      this.m_CopyStadium.CloneGlares(this.m_CurrentStadium.Id);
    }

    private void pictureHomeTeam_DoubleClick(object sender, EventArgs e)
    {
      if (this.m_CurrentStadium.HomeTeam == null)
        return;
      MainForm.CM.JumpTo((IdObject) this.m_CurrentStadium.HomeTeam);
    }

    private void radioPreviewOvercast_CheckedChanged(object sender, EventArgs e)
    {
      this.LoadStadiumPreview();
    }

    private void radioPreviewClearDay_CheckedChanged(object sender, EventArgs e)
    {
      this.LoadStadiumPreview();
    }

    private void radioPreviewlNight_CheckedChanged(object sender, EventArgs e)
    {
      this.LoadStadiumPreview();
    }

    private void radioPreviewSunset_CheckedChanged(object sender, EventArgs e)
    {
      this.LoadStadiumPreview();
    }

    private void numericCameraHeight_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_Locked)
        return;
      this.m_CurrentStadium.cameraheight = (int) this.numericCameraHeight.Value;
    }

    private void numericCameraZoom_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_Locked)
        return;
      this.m_CurrentStadium.camerazoom = (int) this.numericCameraZoom.Value;
    }

    private void numericAdboardType_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_Locked)
        return;
      this.m_CurrentStadium.adboardtype = (int) this.numericAdboardType.Value;
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
      ComponentResourceManager resources = new ComponentResourceManager(typeof (StadiumForm));
      this.tabEsitStadium = new TabControl();
      this.pageStadiumGeneral = new TabPage();
      this.flowLayoutPanel1 = new FlowLayoutPanel();
      this.groupBox1 = new GroupBox();
      this.checkOrientation = new CheckBox();
      this.comboCountry = new ComboBox();
      this.labelCountry = new Label();
      this.numericCrowdColor = new NumericUpDown();
      this.labelCrowdColor = new Label();
      this.buttonGetId = new Button();
      this.numericStadiumId = new NumericUpDown();
      this.comboHomeTeam = new ComboBox();
      this.textDatabaseStadiumName = new TextBox();
      this.pictureHomeTeam = new PictureBox();
      this.labelDatabaseStadiumName = new Label();
      this.textLocalStadiumName = new TextBox();
      this.labelLocalStadiumName = new Label();
      this.labelStadiumId = new Label();
      this.domainStadiumType = new DomainUpDown();
      this.numericYearBuilt = new NumericUpDown();
      this.numericCapacity = new NumericUpDown();
      this.labelCapacity = new Label();
      this.labelYearBuilt = new Label();
      this.labelStadiumType = new Label();
      this.groupMowingPattern = new GroupBox();
      this.numericMowing = new NumericUpDown();
      this.viewer2DMowing = new Viewer2D();
      this.groupBox3 = new GroupBox();
      this.checkDeepNet = new CheckBox();
      this.viewer2DNet = new Viewer2D();
      this.numericNet = new NumericUpDown();
      this.groupBox6 = new GroupBox();
      this.groupCamera = new GroupBox();
      this.numericCameraZoom = new NumericUpDown();
      this.numericCameraHeight = new NumericUpDown();
      this.label4 = new Label();
      this.label5 = new Label();
      this.groupAdboards = new GroupBox();
      this.numericAdboardType = new NumericUpDown();
      this.label6 = new Label();
      this.numericSideLineDistance = new NumericUpDown();
      this.numericEndLineDistance = new NumericUpDown();
      this.label1 = new Label();
      this.labelAdboardEndLine = new Label();
      this.groupTimeAndWeather = new GroupBox();
      this.label2 = new Label();
      this.comboDayWeather = new ComboBox();
      this.checkNight = new CheckBox();
      this.checkSunset = new CheckBox();
      this.checkCloudyDay = new CheckBox();
      this.checkSunnyDay = new CheckBox();
      this.groupPolice = new GroupBox();
      this.comboPolice = new ComboBox();
      this.viewer2DPolice = new Viewer2D();
      this.pageStadiumPreview = new TabPage();
      this.groupEnvironment = new GroupBox();
      this.groupBox4 = new GroupBox();
      this.viewer2DPreviewLarge = new Viewer2D();
      this.viewer2DPreview = new Viewer2D();
      this.groupBox2 = new GroupBox();
      this.radioPreviewOvercast = new RadioButton();
      this.radioPreviewClearDay = new RadioButton();
      this.radioPreviewSunset = new RadioButton();
      this.radioPreviewNight = new RadioButton();
      this.pageStadiumModel = new TabPage();
      this.flowLayoutPanel2 = new FlowLayoutPanel();
      this.groupBox7 = new GroupBox();
      this.radioModelOvercast = new RadioButton();
      this.radioModelClearDay = new RadioButton();
      this.radioModelSunset = new RadioButton();
      this.radioModelNight = new RadioButton();
      this.multiViewer2DTextures = new MultiViewer2D();
      this.groupLights = new GroupBox();
      this.buttonCopyLights = new Button();
      this.comboStadiumLights = new ComboBox();
      this.stadiumListBindingSource = new BindingSource(this.components);
      this.buttonCopyCrowd = new Button();
      this.label3 = new Label();
      this.groupBox5 = new GroupBox();
      this.multiViewer2DCoverMap = new MultiViewer2D();
      this.pickUpControl = new PickUpControl();
      this.tabEsitStadium.SuspendLayout();
      this.pageStadiumGeneral.SuspendLayout();
      this.flowLayoutPanel1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.numericCrowdColor.BeginInit();
      this.numericStadiumId.BeginInit();
      ((ISupportInitialize) this.pictureHomeTeam).BeginInit();
      this.numericYearBuilt.BeginInit();
      this.numericCapacity.BeginInit();
      this.groupMowingPattern.SuspendLayout();
      this.numericMowing.BeginInit();
      this.groupBox3.SuspendLayout();
      this.numericNet.BeginInit();
      this.groupBox6.SuspendLayout();
      this.groupCamera.SuspendLayout();
      this.numericCameraZoom.BeginInit();
      this.numericCameraHeight.BeginInit();
      this.groupAdboards.SuspendLayout();
      this.numericAdboardType.BeginInit();
      this.numericSideLineDistance.BeginInit();
      this.numericEndLineDistance.BeginInit();
      this.groupTimeAndWeather.SuspendLayout();
      this.groupPolice.SuspendLayout();
      this.pageStadiumPreview.SuspendLayout();
      this.groupEnvironment.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.pageStadiumModel.SuspendLayout();
      this.flowLayoutPanel2.SuspendLayout();
      this.groupBox7.SuspendLayout();
      this.groupLights.SuspendLayout();
      ((ISupportInitialize) this.stadiumListBindingSource).BeginInit();
      this.groupBox5.SuspendLayout();
      this.SuspendLayout();
      this.tabEsitStadium.Controls.Add((Control) this.pageStadiumGeneral);
      this.tabEsitStadium.Controls.Add((Control) this.pageStadiumPreview);
      this.tabEsitStadium.Controls.Add((Control) this.pageStadiumModel);
      this.tabEsitStadium.Dock = DockStyle.Fill;
      this.tabEsitStadium.Location = new Point(0, 25);
      this.tabEsitStadium.Name = "tabEsitStadium";
      this.tabEsitStadium.SelectedIndex = 0;
      this.tabEsitStadium.Size = new Size(1357, 807);
      this.tabEsitStadium.TabIndex = 2;
      this.tabEsitStadium.SelectedIndexChanged += new EventHandler(this.tabEsitStadium_SelectedIndexChanged);
      this.pageStadiumGeneral.Controls.Add((Control) this.flowLayoutPanel1);
      this.pageStadiumGeneral.Location = new Point(4, 22);
      this.pageStadiumGeneral.Name = "pageStadiumGeneral";
      this.pageStadiumGeneral.Padding = new Padding(3);
      this.pageStadiumGeneral.Size = new Size(1349, 781);
      this.pageStadiumGeneral.TabIndex = 0;
      this.pageStadiumGeneral.Text = "General";
      this.pageStadiumGeneral.UseVisualStyleBackColor = true;
      this.flowLayoutPanel1.AutoScroll = true;
      this.flowLayoutPanel1.BackColor = SystemColors.Control;
      this.flowLayoutPanel1.Controls.Add((Control) this.groupBox1);
      this.flowLayoutPanel1.Controls.Add((Control) this.groupMowingPattern);
      this.flowLayoutPanel1.Controls.Add((Control) this.groupBox3);
      this.flowLayoutPanel1.Controls.Add((Control) this.groupBox6);
      this.flowLayoutPanel1.Controls.Add((Control) this.groupPolice);
      this.flowLayoutPanel1.Dock = DockStyle.Fill;
      this.flowLayoutPanel1.Location = new Point(3, 3);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new Size(1343, 775);
      this.flowLayoutPanel1.TabIndex = 0;
      this.groupBox1.BackColor = SystemColors.Control;
      this.groupBox1.Controls.Add((Control) this.checkOrientation);
      this.groupBox1.Controls.Add((Control) this.comboCountry);
      this.groupBox1.Controls.Add((Control) this.labelCountry);
      this.groupBox1.Controls.Add((Control) this.numericCrowdColor);
      this.groupBox1.Controls.Add((Control) this.labelCrowdColor);
      this.groupBox1.Controls.Add((Control) this.buttonGetId);
      this.groupBox1.Controls.Add((Control) this.numericStadiumId);
      this.groupBox1.Controls.Add((Control) this.comboHomeTeam);
      this.groupBox1.Controls.Add((Control) this.textDatabaseStadiumName);
      this.groupBox1.Controls.Add((Control) this.pictureHomeTeam);
      this.groupBox1.Controls.Add((Control) this.labelDatabaseStadiumName);
      this.groupBox1.Controls.Add((Control) this.textLocalStadiumName);
      this.groupBox1.Controls.Add((Control) this.labelLocalStadiumName);
      this.groupBox1.Controls.Add((Control) this.labelStadiumId);
      this.groupBox1.Controls.Add((Control) this.domainStadiumType);
      this.groupBox1.Controls.Add((Control) this.numericYearBuilt);
      this.groupBox1.Controls.Add((Control) this.numericCapacity);
      this.groupBox1.Controls.Add((Control) this.labelCapacity);
      this.groupBox1.Controls.Add((Control) this.labelYearBuilt);
      this.groupBox1.Controls.Add((Control) this.labelStadiumType);
      this.groupBox1.Location = new Point(3, 3);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(265, 339);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Info";
      this.checkOrientation.AutoSize = true;
      this.checkOrientation.Location = new Point(9, 214);
      this.checkOrientation.Name = "checkOrientation";
      this.checkOrientation.RightToLeft = RightToLeft.Yes;
      this.checkOrientation.Size = new Size(122, 17);
      this.checkOrientation.TabIndex = 8;
      this.checkOrientation.Text = "Opposite Orientation";
      this.checkOrientation.UseVisualStyleBackColor = true;
      this.checkOrientation.CheckedChanged += new EventHandler(this.checkOrientation_CheckedChanged);
      this.comboCountry.Location = new Point(118, 177);
      this.comboCountry.Name = "comboCountry";
      this.comboCountry.Size = new Size(137, 21);
      this.comboCountry.TabIndex = 7;
      this.comboCountry.SelectedIndexChanged += new EventHandler(this.comboCountry_SelectedIndexChanged);
      this.labelCountry.AutoSize = true;
      this.labelCountry.Cursor = Cursors.Hand;
      this.labelCountry.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Underline, GraphicsUnit.Point, (byte) 0);
      this.labelCountry.ForeColor = SystemColors.ActiveCaption;
      this.labelCountry.ImeMode = ImeMode.NoControl;
      this.labelCountry.Location = new Point(6, 180);
      this.labelCountry.Name = "labelCountry";
      this.labelCountry.Size = new Size(43, 13);
      this.labelCountry.TabIndex = 125;
      this.labelCountry.Text = "Country";
      this.labelCountry.TextAlign = ContentAlignment.MiddleLeft;
      this.labelCountry.Click += new EventHandler(this.labelCountry_DoubleClick);
      this.numericCrowdColor.Location = new Point(118, 152);
      this.numericCrowdColor.Maximum = new Decimal(new int[4]
      {
        8,
        0,
        0,
        0
      });
      this.numericCrowdColor.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericCrowdColor.Name = "numericCrowdColor";
      this.numericCrowdColor.Size = new Size(136, 20);
      this.numericCrowdColor.TabIndex = 6;
      this.numericCrowdColor.TextAlign = HorizontalAlignment.Center;
      this.numericCrowdColor.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericCrowdColor.ValueChanged += new EventHandler(this.numericCrowdColor_ValueChanged);
      this.labelCrowdColor.AutoSize = true;
      this.labelCrowdColor.BackColor = SystemColors.Control;
      this.labelCrowdColor.ImeMode = ImeMode.NoControl;
      this.labelCrowdColor.Location = new Point(6, 154);
      this.labelCrowdColor.Name = "labelCrowdColor";
      this.labelCrowdColor.Size = new Size(59, 13);
      this.labelCrowdColor.TabIndex = 122;
      this.labelCrowdColor.Text = "Seat Color ";
      this.labelCrowdColor.TextAlign = ContentAlignment.MiddleLeft;
      this.buttonGetId.BackgroundImage = (Image) resources.GetObject("buttonGetId.BackgroundImage");
      this.buttonGetId.BackgroundImageLayout = ImageLayout.Center;
      this.buttonGetId.Location = new Point(225, 59);
      this.buttonGetId.Name = "buttonGetId";
      this.buttonGetId.Size = new Size(24, 24);
      this.buttonGetId.TabIndex = 1;
      this.buttonGetId.TabStop = false;
      this.buttonGetId.UseVisualStyleBackColor = true;
      this.buttonGetId.Click += new EventHandler(this.buttonGetId_Click);
      this.numericStadiumId.Location = new Point(118, 61);
      this.numericStadiumId.Maximum = new Decimal(new int[4]
      {
        200000,
        0,
        0,
        0
      });
      this.numericStadiumId.Name = "numericStadiumId";
      this.numericStadiumId.Size = new Size(100, 20);
      this.numericStadiumId.TabIndex = 2;
      this.numericStadiumId.TextAlign = HorizontalAlignment.Center;
      this.numericStadiumId.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericStadiumId.ValueChanged += new EventHandler(this.numericStadiumId_ValueChanged);
      this.comboHomeTeam.ItemHeight = 13;
      this.comboHomeTeam.Location = new Point(155, 304);
      this.comboHomeTeam.MaxLength = (int) short.MaxValue;
      this.comboHomeTeam.Name = "comboHomeTeam";
      this.comboHomeTeam.Size = new Size(100, 21);
      this.comboHomeTeam.Sorted = true;
      this.comboHomeTeam.TabIndex = 9;
      this.comboHomeTeam.SelectedIndexChanged += new EventHandler(this.comboHomeTeam_SelectedIndexChanged);
      this.textDatabaseStadiumName.Location = new Point(118, 16);
      this.textDatabaseStadiumName.Name = "textDatabaseStadiumName";
      this.textDatabaseStadiumName.Size = new Size(136, 20);
      this.textDatabaseStadiumName.TabIndex = 0;
      this.textDatabaseStadiumName.TextChanged += new EventHandler(this.textDatabaseStadiumName_TextChanged);
      this.pictureHomeTeam.BackgroundImageLayout = ImageLayout.Zoom;
      this.pictureHomeTeam.BorderStyle = BorderStyle.FixedSingle;
      this.pictureHomeTeam.Cursor = Cursors.Hand;
      this.pictureHomeTeam.ImeMode = ImeMode.NoControl;
      this.pictureHomeTeam.Location = new Point(155, 204);
      this.pictureHomeTeam.Name = "pictureHomeTeam";
      this.pictureHomeTeam.Size = new Size(100, 100);
      this.pictureHomeTeam.TabIndex = 68;
      this.pictureHomeTeam.TabStop = false;
      this.pictureHomeTeam.DoubleClick += new EventHandler(this.pictureHomeTeam_DoubleClick);
      this.labelDatabaseStadiumName.AutoSize = true;
      this.labelDatabaseStadiumName.BackColor = SystemColors.Control;
      this.labelDatabaseStadiumName.ImeMode = ImeMode.NoControl;
      this.labelDatabaseStadiumName.Location = new Point(6, 16);
      this.labelDatabaseStadiumName.Name = "labelDatabaseStadiumName";
      this.labelDatabaseStadiumName.Size = new Size(84, 13);
      this.labelDatabaseStadiumName.TabIndex = 1;
      this.labelDatabaseStadiumName.Text = "Database Name";
      this.labelDatabaseStadiumName.TextAlign = ContentAlignment.MiddleLeft;
      this.textLocalStadiumName.Location = new Point(118, 38);
      this.textLocalStadiumName.Name = "textLocalStadiumName";
      this.textLocalStadiumName.Size = new Size(136, 20);
      this.textLocalStadiumName.TabIndex = 1;
      this.textLocalStadiumName.TextChanged += new EventHandler(this.textLocalStadiumName_TextChanged);
      this.labelLocalStadiumName.AutoSize = true;
      this.labelLocalStadiumName.BackColor = SystemColors.Control;
      this.labelLocalStadiumName.ImeMode = ImeMode.NoControl;
      this.labelLocalStadiumName.Location = new Point(6, 37);
      this.labelLocalStadiumName.Name = "labelLocalStadiumName";
      this.labelLocalStadiumName.Size = new Size(35, 13);
      this.labelLocalStadiumName.TabIndex = 2;
      this.labelLocalStadiumName.Text = "Name";
      this.labelLocalStadiumName.TextAlign = ContentAlignment.MiddleLeft;
      this.labelStadiumId.AutoSize = true;
      this.labelStadiumId.BackColor = SystemColors.Control;
      this.labelStadiumId.ImeMode = ImeMode.NoControl;
      this.labelStadiumId.Location = new Point(6, 63);
      this.labelStadiumId.Name = "labelStadiumId";
      this.labelStadiumId.Size = new Size(57, 13);
      this.labelStadiumId.TabIndex = 121;
      this.labelStadiumId.Text = "Stadium Id";
      this.labelStadiumId.TextAlign = ContentAlignment.MiddleLeft;
      this.domainStadiumType.Items.Add((object) "Official");
      this.domainStadiumType.Items.Add((object) "Training");
      this.domainStadiumType.Location = new Point(118, 129);
      this.domainStadiumType.Name = "domainStadiumType";
      this.domainStadiumType.Size = new Size(136, 20);
      this.domainStadiumType.TabIndex = 5;
      this.domainStadiumType.TextAlign = HorizontalAlignment.Center;
      this.domainStadiumType.Wrap = true;
      this.domainStadiumType.SelectedItemChanged += new EventHandler(this.domainStadiumType_SelectedItemChanged);
      this.numericYearBuilt.Location = new Point(118, 106);
      this.numericYearBuilt.Maximum = new Decimal(new int[4]
      {
        2050,
        0,
        0,
        0
      });
      this.numericYearBuilt.Minimum = new Decimal(new int[4]
      {
        1800,
        0,
        0,
        0
      });
      this.numericYearBuilt.Name = "numericYearBuilt";
      this.numericYearBuilt.Size = new Size(136, 20);
      this.numericYearBuilt.TabIndex = 4;
      this.numericYearBuilt.TextAlign = HorizontalAlignment.Center;
      this.numericYearBuilt.Value = new Decimal(new int[4]
      {
        1800,
        0,
        0,
        0
      });
      this.numericYearBuilt.ValueChanged += new EventHandler(this.numericYearBuilt_ValueChanged);
      this.numericCapacity.Increment = new Decimal(new int[4]
      {
        1000,
        0,
        0,
        0
      });
      this.numericCapacity.Location = new Point(118, 84);
      this.numericCapacity.Maximum = new Decimal(new int[4]
      {
        200000,
        0,
        0,
        0
      });
      this.numericCapacity.Name = "numericCapacity";
      this.numericCapacity.Size = new Size(136, 20);
      this.numericCapacity.TabIndex = 3;
      this.numericCapacity.TextAlign = HorizontalAlignment.Center;
      this.numericCapacity.ThousandsSeparator = true;
      this.numericCapacity.ValueChanged += new EventHandler(this.numericCapacity_ValueChanged);
      this.labelCapacity.AutoSize = true;
      this.labelCapacity.BackColor = SystemColors.Control;
      this.labelCapacity.ImeMode = ImeMode.NoControl;
      this.labelCapacity.Location = new Point(6, 84);
      this.labelCapacity.Name = "labelCapacity";
      this.labelCapacity.Size = new Size(48, 13);
      this.labelCapacity.TabIndex = 70;
      this.labelCapacity.Text = "Capacity";
      this.labelCapacity.TextAlign = ContentAlignment.MiddleLeft;
      this.labelYearBuilt.AutoSize = true;
      this.labelYearBuilt.BackColor = SystemColors.Control;
      this.labelYearBuilt.ImeMode = ImeMode.NoControl;
      this.labelYearBuilt.Location = new Point(6, 106);
      this.labelYearBuilt.Name = "labelYearBuilt";
      this.labelYearBuilt.Size = new Size(52, 13);
      this.labelYearBuilt.TabIndex = 72;
      this.labelYearBuilt.Text = "Year Built";
      this.labelYearBuilt.TextAlign = ContentAlignment.MiddleLeft;
      this.labelStadiumType.AutoSize = true;
      this.labelStadiumType.BackColor = SystemColors.Control;
      this.labelStadiumType.ImeMode = ImeMode.NoControl;
      this.labelStadiumType.Location = new Point(6, 129);
      this.labelStadiumType.Name = "labelStadiumType";
      this.labelStadiumType.Size = new Size(31, 13);
      this.labelStadiumType.TabIndex = 74;
      this.labelStadiumType.Text = "Type";
      this.labelStadiumType.TextAlign = ContentAlignment.MiddleLeft;
      this.groupMowingPattern.BackColor = SystemColors.Control;
      this.groupMowingPattern.Controls.Add((Control) this.numericMowing);
      this.groupMowingPattern.Controls.Add((Control) this.viewer2DMowing);
      this.groupMowingPattern.Location = new Point(274, 3);
      this.groupMowingPattern.Name = "groupMowingPattern";
      this.groupMowingPattern.Size = new Size(266, 339);
      this.groupMowingPattern.TabIndex = 1;
      this.groupMowingPattern.TabStop = false;
      this.groupMowingPattern.Text = "Mowing Pattern";
      this.numericMowing.Location = new Point(6, 19);
      this.numericMowing.Maximum = new Decimal(new int[4]
      {
        13,
        0,
        0,
        0
      });
      this.numericMowing.Name = "numericMowing";
      this.numericMowing.Size = new Size(64, 20);
      this.numericMowing.TabIndex = 0;
      this.numericMowing.TextAlign = HorizontalAlignment.Center;
      this.numericMowing.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericMowing.ValueChanged += new EventHandler(this.numericMowing_ValueChanged);
      this.viewer2DMowing.AutoTransparency = false;
      this.viewer2DMowing.BackColor = Color.Transparent;
      this.viewer2DMowing.ButtonStripVisible = false;
      this.viewer2DMowing.CurrentBitmap = (Bitmap) null;
      this.viewer2DMowing.ExtendedFormat = false;
      this.viewer2DMowing.FullSizeButton = false;
      this.viewer2DMowing.ImageLayout = ImageLayout.Zoom;
      this.viewer2DMowing.ImageSize = new Size(1024, 2048);
      this.viewer2DMowing.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DMowing.Location = new Point(6, 45);
      this.viewer2DMowing.Name = "viewer2DMowing";
      this.viewer2DMowing.RemoveButton = false;
      this.viewer2DMowing.ShowButton = false;
      this.viewer2DMowing.ShowButtonChecked = true;
      this.viewer2DMowing.Size = new Size(256, 281);
      this.viewer2DMowing.TabIndex = 1;
      this.viewer2DMowing.TabStop = false;
      this.groupBox3.BackColor = SystemColors.Control;
      this.groupBox3.Controls.Add((Control) this.checkDeepNet);
      this.groupBox3.Controls.Add((Control) this.viewer2DNet);
      this.groupBox3.Controls.Add((Control) this.numericNet);
      this.groupBox3.Location = new Point(546, 3);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(152, 339);
      this.groupBox3.TabIndex = 2;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Net";
      this.checkDeepNet.AutoSize = true;
      this.checkDeepNet.Location = new Point(14, 214);
      this.checkDeepNet.Name = "checkDeepNet";
      this.checkDeepNet.Size = new Size(72, 17);
      this.checkDeepNet.TabIndex = 1;
      this.checkDeepNet.Text = "Deep Net";
      this.checkDeepNet.UseVisualStyleBackColor = true;
      this.checkDeepNet.CheckedChanged += new EventHandler(this.checkDeepNet_CheckedChanged);
      this.viewer2DNet.AutoTransparency = true;
      this.viewer2DNet.BackColor = Color.Transparent;
      this.viewer2DNet.ButtonStripVisible = false;
      this.viewer2DNet.CurrentBitmap = (Bitmap) null;
      this.viewer2DNet.ExtendedFormat = false;
      this.viewer2DNet.FullSizeButton = false;
      this.viewer2DNet.ImageLayout = ImageLayout.Tile;
      this.viewer2DNet.ImageSize = new Size(128, 128);
      this.viewer2DNet.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DNet.Location = new Point(14, 44);
      this.viewer2DNet.Name = "viewer2DNet";
      this.viewer2DNet.RemoveButton = false;
      this.viewer2DNet.ShowButton = false;
      this.viewer2DNet.ShowButtonChecked = true;
      this.viewer2DNet.Size = new Size(128, 153);
      this.viewer2DNet.TabIndex = 1;
      this.viewer2DNet.TabStop = false;
      this.numericNet.Location = new Point(14, 19);
      this.numericNet.Maximum = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericNet.Name = "numericNet";
      this.numericNet.Size = new Size(64, 20);
      this.numericNet.TabIndex = 0;
      this.numericNet.TextAlign = HorizontalAlignment.Center;
      this.numericNet.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericNet.ValueChanged += new EventHandler(this.numericNet_ValueChanged);
      this.groupBox6.Controls.Add((Control) this.groupCamera);
      this.groupBox6.Controls.Add((Control) this.groupAdboards);
      this.groupBox6.Controls.Add((Control) this.groupTimeAndWeather);
      this.groupBox6.Location = new Point(704, 3);
      this.groupBox6.Name = "groupBox6";
      this.groupBox6.Size = new Size(202, 339);
      this.groupBox6.TabIndex = 3;
      this.groupBox6.TabStop = false;
      this.groupCamera.Controls.Add((Control) this.numericCameraZoom);
      this.groupCamera.Controls.Add((Control) this.numericCameraHeight);
      this.groupCamera.Controls.Add((Control) this.label4);
      this.groupCamera.Controls.Add((Control) this.label5);
      this.groupCamera.Location = new Point(6, 229);
      this.groupCamera.Name = "groupCamera";
      this.groupCamera.Size = new Size(192, 73);
      this.groupCamera.TabIndex = 2;
      this.groupCamera.TabStop = false;
      this.groupCamera.Text = "Camera";
      this.numericCameraZoom.Location = new Point(106, 45);
      this.numericCameraZoom.Maximum = new Decimal(new int[4]
      {
        15,
        0,
        0,
        0
      });
      this.numericCameraZoom.Name = "numericCameraZoom";
      this.numericCameraZoom.Size = new Size(80, 20);
      this.numericCameraZoom.TabIndex = 119;
      this.numericCameraZoom.TextAlign = HorizontalAlignment.Center;
      this.numericCameraZoom.Value = new Decimal(new int[4]
      {
        7,
        0,
        0,
        0
      });
      this.numericCameraZoom.ValueChanged += new EventHandler(this.numericCameraZoom_ValueChanged);
      this.numericCameraHeight.Location = new Point(106, 19);
      this.numericCameraHeight.Maximum = new Decimal(new int[4]
      {
        31,
        0,
        0,
        0
      });
      this.numericCameraHeight.Name = "numericCameraHeight";
      this.numericCameraHeight.Size = new Size(80, 20);
      this.numericCameraHeight.TabIndex = 118;
      this.numericCameraHeight.TextAlign = HorizontalAlignment.Center;
      this.numericCameraHeight.Value = new Decimal(new int[4]
      {
        15,
        0,
        0,
        0
      });
      this.numericCameraHeight.ValueChanged += new EventHandler(this.numericCameraHeight_ValueChanged);
      this.label4.AutoSize = true;
      this.label4.ImeMode = ImeMode.NoControl;
      this.label4.Location = new Point(3, 47);
      this.label4.Name = "label4";
      this.label4.Size = new Size(34, 13);
      this.label4.TabIndex = 117;
      this.label4.Text = "Zoom";
      this.label4.TextAlign = ContentAlignment.MiddleLeft;
      this.label5.AutoSize = true;
      this.label5.ImeMode = ImeMode.NoControl;
      this.label5.Location = new Point(3, 21);
      this.label5.Name = "label5";
      this.label5.Size = new Size(38, 13);
      this.label5.TabIndex = 116;
      this.label5.Text = "Height";
      this.label5.TextAlign = ContentAlignment.MiddleLeft;
      this.groupAdboards.BackColor = SystemColors.Control;
      this.groupAdboards.Controls.Add((Control) this.numericAdboardType);
      this.groupAdboards.Controls.Add((Control) this.label6);
      this.groupAdboards.Controls.Add((Control) this.numericSideLineDistance);
      this.groupAdboards.Controls.Add((Control) this.numericEndLineDistance);
      this.groupAdboards.Controls.Add((Control) this.label1);
      this.groupAdboards.Controls.Add((Control) this.labelAdboardEndLine);
      this.groupAdboards.Location = new Point(6, 13);
      this.groupAdboards.Name = "groupAdboards";
      this.groupAdboards.Size = new Size(192, 106);
      this.groupAdboards.TabIndex = 0;
      this.groupAdboards.TabStop = false;
      this.groupAdboards.Text = "Adboards";
      this.numericAdboardType.Location = new Point(106, 26);
      this.numericAdboardType.Maximum = new Decimal(new int[4]
      {
        3,
        0,
        0,
        0
      });
      this.numericAdboardType.Name = "numericAdboardType";
      this.numericAdboardType.Size = new Size(80, 20);
      this.numericAdboardType.TabIndex = 119;
      this.numericAdboardType.TextAlign = HorizontalAlignment.Center;
      this.numericAdboardType.ValueChanged += new EventHandler(this.numericAdboardType_ValueChanged);
      this.label6.AutoSize = true;
      this.label6.ImeMode = ImeMode.NoControl;
      this.label6.Location = new Point(7, 28);
      this.label6.Name = "label6";
      this.label6.Size = new Size(31, 13);
      this.label6.TabIndex = 116;
      this.label6.Text = "Type";
      this.label6.TextAlign = ContentAlignment.MiddleLeft;
      this.numericSideLineDistance.Location = new Point(106, 79);
      this.numericSideLineDistance.Maximum = new Decimal(new int[4]
      {
        2000,
        0,
        0,
        0
      });
      this.numericSideLineDistance.Name = "numericSideLineDistance";
      this.numericSideLineDistance.Size = new Size(82, 20);
      this.numericSideLineDistance.TabIndex = 1;
      this.numericSideLineDistance.TextAlign = HorizontalAlignment.Center;
      this.numericSideLineDistance.Value = new Decimal(new int[4]
      {
        500,
        0,
        0,
        0
      });
      this.numericSideLineDistance.ValueChanged += new EventHandler(this.numericSideLineDistance_ValueChanged);
      this.numericEndLineDistance.Location = new Point(106, 53);
      this.numericEndLineDistance.Maximum = new Decimal(new int[4]
      {
        2000,
        0,
        0,
        0
      });
      this.numericEndLineDistance.Name = "numericEndLineDistance";
      this.numericEndLineDistance.Size = new Size(82, 20);
      this.numericEndLineDistance.TabIndex = 0;
      this.numericEndLineDistance.TextAlign = HorizontalAlignment.Center;
      this.numericEndLineDistance.Value = new Decimal(new int[4]
      {
        500,
        0,
        0,
        0
      });
      this.numericEndLineDistance.ValueChanged += new EventHandler(this.numericEndLineDistance_ValueChanged);
      this.label1.AutoSize = true;
      this.label1.ImeMode = ImeMode.NoControl;
      this.label1.Location = new Point(7, 81);
      this.label1.Name = "label1";
      this.label1.Size = new Size(96, 13);
      this.label1.TabIndex = 115;
      this.label1.Text = "Side Line Distance";
      this.label1.TextAlign = ContentAlignment.MiddleLeft;
      this.labelAdboardEndLine.AutoSize = true;
      this.labelAdboardEndLine.ImeMode = ImeMode.NoControl;
      this.labelAdboardEndLine.Location = new Point(7, 55);
      this.labelAdboardEndLine.Name = "labelAdboardEndLine";
      this.labelAdboardEndLine.Size = new Size(94, 13);
      this.labelAdboardEndLine.TabIndex = 114;
      this.labelAdboardEndLine.Text = "End Line Distance";
      this.labelAdboardEndLine.TextAlign = ContentAlignment.MiddleLeft;
      this.groupTimeAndWeather.BackColor = SystemColors.Control;
      this.groupTimeAndWeather.Controls.Add((Control) this.label2);
      this.groupTimeAndWeather.Controls.Add((Control) this.comboDayWeather);
      this.groupTimeAndWeather.Controls.Add((Control) this.checkNight);
      this.groupTimeAndWeather.Controls.Add((Control) this.checkSunset);
      this.groupTimeAndWeather.Controls.Add((Control) this.checkCloudyDay);
      this.groupTimeAndWeather.Controls.Add((Control) this.checkSunnyDay);
      this.groupTimeAndWeather.Location = new Point(6, 125);
      this.groupTimeAndWeather.Name = "groupTimeAndWeather";
      this.groupTimeAndWeather.Size = new Size(192, 98);
      this.groupTimeAndWeather.TabIndex = 1;
      this.groupTimeAndWeather.TabStop = false;
      this.groupTimeAndWeather.Text = "Time and Weather";
      this.label2.AutoSize = true;
      this.label2.ImeMode = ImeMode.NoControl;
      this.label2.Location = new Point(6, 74);
      this.label2.Name = "label2";
      this.label2.Size = new Size(48, 13);
      this.label2.TabIndex = 116;
      this.label2.Text = "Weather";
      this.label2.TextAlign = ContentAlignment.MiddleLeft;
      this.comboDayWeather.FormattingEnabled = true;
      this.comboDayWeather.Items.AddRange(new object[3]
      {
        (object) "Dry",
        (object) "Can Rain",
        (object) "Can Snow"
      });
      this.comboDayWeather.Location = new Point(69, 71);
      this.comboDayWeather.Name = "comboDayWeather";
      this.comboDayWeather.Size = new Size(117, 21);
      this.comboDayWeather.TabIndex = 4;
      this.comboDayWeather.SelectedIndexChanged += new EventHandler(this.comboDayWeather_SelectedIndexChanged);
      this.checkNight.AutoSize = true;
      this.checkNight.Location = new Point(6, 48);
      this.checkNight.Name = "checkNight";
      this.checkNight.RightToLeft = RightToLeft.No;
      this.checkNight.Size = new Size(51, 17);
      this.checkNight.TabIndex = 3;
      this.checkNight.Text = "Night";
      this.checkNight.UseVisualStyleBackColor = true;
      this.checkNight.CheckedChanged += new EventHandler(this.checkNight_CheckedChanged);
      this.checkSunset.AutoSize = true;
      this.checkSunset.Location = new Point(97, 48);
      this.checkSunset.Name = "checkSunset";
      this.checkSunset.RightToLeft = RightToLeft.No;
      this.checkSunset.Size = new Size(59, 17);
      this.checkSunset.TabIndex = 2;
      this.checkSunset.Text = "Sunset";
      this.checkSunset.UseVisualStyleBackColor = true;
      this.checkSunset.Visible = false;
      this.checkSunset.CheckedChanged += new EventHandler(this.checkSunset_CheckedChanged);
      this.checkCloudyDay.AutoSize = true;
      this.checkCloudyDay.Location = new Point(97, 25);
      this.checkCloudyDay.Name = "checkCloudyDay";
      this.checkCloudyDay.RightToLeft = RightToLeft.No;
      this.checkCloudyDay.Size = new Size(91, 17);
      this.checkCloudyDay.TabIndex = 1;
      this.checkCloudyDay.Text = "Overcast Day";
      this.checkCloudyDay.UseVisualStyleBackColor = true;
      this.checkCloudyDay.Visible = false;
      this.checkCloudyDay.CheckedChanged += new EventHandler(this.checkCloudyDay_CheckedChanged);
      this.checkSunnyDay.AutoSize = true;
      this.checkSunnyDay.Location = new Point(6, 25);
      this.checkSunnyDay.Name = "checkSunnyDay";
      this.checkSunnyDay.RightToLeft = RightToLeft.No;
      this.checkSunnyDay.Size = new Size(45, 17);
      this.checkSunnyDay.TabIndex = 0;
      this.checkSunnyDay.Text = "Day";
      this.checkSunnyDay.UseVisualStyleBackColor = true;
      this.checkSunnyDay.CheckedChanged += new EventHandler(this.checkSunnyDay_CheckedChanged);
      this.groupPolice.Controls.Add((Control) this.comboPolice);
      this.groupPolice.Controls.Add((Control) this.viewer2DPolice);
      this.groupPolice.Location = new Point(912, 3);
      this.groupPolice.Name = "groupPolice";
      this.groupPolice.Size = new Size(270, 339);
      this.groupPolice.TabIndex = 4;
      this.groupPolice.TabStop = false;
      this.groupPolice.Text = "Police";
      this.comboPolice.FormattingEnabled = true;
      this.comboPolice.Items.AddRange(new object[11]
      {
        (object) "0 = None",
        (object) "1 = English Police",
        (object) "2 = French Police",
        (object) "3 = Italian Police",
        (object) "4 = German Police",
        (object) "5 = Spanish Police",
        (object) "6 = Mexican Police",
        (object) "7 = Asiatic Traits Police",
        (object) "8 = African Traits Police",
        (object) "9 = CaucasicTraits Police",
        (object) "10 = ArabicTraits Police"
      });
      this.comboPolice.Location = new Point(32, 17);
      this.comboPolice.Name = "comboPolice";
      this.comboPolice.Size = new Size(207, 21);
      this.comboPolice.TabIndex = 126;
      this.comboPolice.SelectedIndexChanged += new EventHandler(this.comboPolice_SelectedIndexChanged);
      this.viewer2DPolice.AutoTransparency = false;
      this.viewer2DPolice.BackColor = Color.Transparent;
      this.viewer2DPolice.ButtonStripVisible = false;
      this.viewer2DPolice.CurrentBitmap = (Bitmap) null;
      this.viewer2DPolice.ExtendedFormat = false;
      this.viewer2DPolice.FullSizeButton = false;
      this.viewer2DPolice.ImageLayout = ImageLayout.Zoom;
      this.viewer2DPolice.ImageSize = new Size(1024, 1024);
      this.viewer2DPolice.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DPolice.Location = new Point(7, 44);
      this.viewer2DPolice.Name = "viewer2DPolice";
      this.viewer2DPolice.RemoveButton = false;
      this.viewer2DPolice.ShowButton = false;
      this.viewer2DPolice.ShowButtonChecked = true;
      this.viewer2DPolice.Size = new Size(256, 256);
      this.viewer2DPolice.TabIndex = 2;
      this.viewer2DPolice.TabStop = false;
      this.pageStadiumPreview.Controls.Add((Control) this.groupEnvironment);
      this.pageStadiumPreview.Location = new Point(4, 22);
      this.pageStadiumPreview.Name = "pageStadiumPreview";
      this.pageStadiumPreview.Size = new Size(1349, 781);
      this.pageStadiumPreview.TabIndex = 2;
      this.pageStadiumPreview.Text = "Preview";
      this.pageStadiumPreview.UseVisualStyleBackColor = true;
      this.groupEnvironment.BackColor = SystemColors.Control;
      this.groupEnvironment.Controls.Add((Control) this.groupBox4);
      this.groupEnvironment.Controls.Add((Control) this.groupBox2);
      this.groupEnvironment.Dock = DockStyle.Fill;
      this.groupEnvironment.Location = new Point(0, 0);
      this.groupEnvironment.Name = "groupEnvironment";
      this.groupEnvironment.Size = new Size(1349, 781);
      this.groupEnvironment.TabIndex = 104;
      this.groupEnvironment.TabStop = false;
      this.groupBox4.Controls.Add((Control) this.viewer2DPreviewLarge);
      this.groupBox4.Controls.Add((Control) this.viewer2DPreview);
      this.groupBox4.Location = new Point(6, 69);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new Size(1039, 595);
      this.groupBox4.TabIndex = 107;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Preview";
      this.viewer2DPreviewLarge.AutoTransparency = false;
      this.viewer2DPreviewLarge.BackColor = Color.Transparent;
      this.viewer2DPreviewLarge.ButtonStripVisible = false;
      this.viewer2DPreviewLarge.CurrentBitmap = (Bitmap) null;
      this.viewer2DPreviewLarge.ExtendedFormat = false;
      this.viewer2DPreviewLarge.FullSizeButton = false;
      this.viewer2DPreviewLarge.ImageLayout = ImageLayout.None;
      this.viewer2DPreviewLarge.ImageSize = new Size(1024, 512);
      this.viewer2DPreviewLarge.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DPreviewLarge.Location = new Point(2, 282);
      this.viewer2DPreviewLarge.Name = "viewer2DPreviewLarge";
      this.viewer2DPreviewLarge.RemoveButton = false;
      this.viewer2DPreviewLarge.ShowButton = false;
      this.viewer2DPreviewLarge.ShowButtonChecked = true;
      this.viewer2DPreviewLarge.Size = new Size(1024, 300);
      this.viewer2DPreviewLarge.TabIndex = 106;
      this.viewer2DPreview.AutoTransparency = false;
      this.viewer2DPreview.BackColor = Color.Transparent;
      this.viewer2DPreview.ButtonStripVisible = false;
      this.viewer2DPreview.CurrentBitmap = (Bitmap) null;
      this.viewer2DPreview.ExtendedFormat = false;
      this.viewer2DPreview.FullSizeButton = false;
      this.viewer2DPreview.ImageLayout = ImageLayout.None;
      this.viewer2DPreview.ImageSize = new Size(1024, 256);
      this.viewer2DPreview.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DPreview.Location = new Point(2, 16);
      this.viewer2DPreview.Name = "viewer2DPreview";
      this.viewer2DPreview.RemoveButton = false;
      this.viewer2DPreview.ShowButton = false;
      this.viewer2DPreview.ShowButtonChecked = true;
      this.viewer2DPreview.Size = new Size(605, 260);
      this.viewer2DPreview.TabIndex = 105;
      this.groupBox2.Controls.Add((Control) this.radioPreviewOvercast);
      this.groupBox2.Controls.Add((Control) this.radioPreviewClearDay);
      this.groupBox2.Controls.Add((Control) this.radioPreviewSunset);
      this.groupBox2.Controls.Add((Control) this.radioPreviewNight);
      this.groupBox2.Location = new Point(6, 13);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(607, 50);
      this.groupBox2.TabIndex = 106;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Environment";
      this.radioPreviewOvercast.AutoSize = true;
      this.radioPreviewOvercast.ImeMode = ImeMode.NoControl;
      this.radioPreviewOvercast.Location = new Point(6, 19);
      this.radioPreviewOvercast.Name = "radioPreviewOvercast";
      this.radioPreviewOvercast.Size = new Size(90, 17);
      this.radioPreviewOvercast.TabIndex = 99;
      this.radioPreviewOvercast.Text = "Overcast Day";
      this.radioPreviewOvercast.UseVisualStyleBackColor = true;
      this.radioPreviewOvercast.CheckedChanged += new EventHandler(this.radioPreviewOvercast_CheckedChanged);
      this.radioPreviewClearDay.AutoSize = true;
      this.radioPreviewClearDay.Checked = true;
      this.radioPreviewClearDay.ImeMode = ImeMode.NoControl;
      this.radioPreviewClearDay.Location = new Point(176, 19);
      this.radioPreviewClearDay.Name = "radioPreviewClearDay";
      this.radioPreviewClearDay.Size = new Size(71, 17);
      this.radioPreviewClearDay.TabIndex = 100;
      this.radioPreviewClearDay.TabStop = true;
      this.radioPreviewClearDay.Text = "Clear Day";
      this.radioPreviewClearDay.UseVisualStyleBackColor = true;
      this.radioPreviewClearDay.CheckedChanged += new EventHandler(this.radioPreviewClearDay_CheckedChanged);
      this.radioPreviewSunset.AutoSize = true;
      this.radioPreviewSunset.ImeMode = ImeMode.NoControl;
      this.radioPreviewSunset.Location = new Point(485, 19);
      this.radioPreviewSunset.Name = "radioPreviewSunset";
      this.radioPreviewSunset.Size = new Size(58, 17);
      this.radioPreviewSunset.TabIndex = 98;
      this.radioPreviewSunset.Text = "Sunset";
      this.radioPreviewSunset.UseVisualStyleBackColor = true;
      this.radioPreviewSunset.CheckedChanged += new EventHandler(this.radioPreviewSunset_CheckedChanged);
      this.radioPreviewNight.AutoSize = true;
      this.radioPreviewNight.ImeMode = ImeMode.NoControl;
      this.radioPreviewNight.Location = new Point(340, 19);
      this.radioPreviewNight.Name = "radioPreviewNight";
      this.radioPreviewNight.Size = new Size(50, 17);
      this.radioPreviewNight.TabIndex = 101;
      this.radioPreviewNight.Text = "Night";
      this.radioPreviewNight.UseVisualStyleBackColor = true;
      this.radioPreviewNight.CheckedChanged += new EventHandler(this.radioPreviewlNight_CheckedChanged);
      this.pageStadiumModel.Controls.Add((Control) this.flowLayoutPanel2);
      this.pageStadiumModel.Location = new Point(4, 22);
      this.pageStadiumModel.Name = "pageStadiumModel";
      this.pageStadiumModel.Padding = new Padding(3);
      this.pageStadiumModel.Size = new Size(1349, 781);
      this.pageStadiumModel.TabIndex = 1;
      this.pageStadiumModel.Text = "Model";
      this.pageStadiumModel.UseVisualStyleBackColor = true;
      this.flowLayoutPanel2.AutoScroll = true;
      this.flowLayoutPanel2.BackColor = SystemColors.Control;
      this.flowLayoutPanel2.Controls.Add((Control) this.groupBox7);
      this.flowLayoutPanel2.Controls.Add((Control) this.multiViewer2DTextures);
      this.flowLayoutPanel2.Controls.Add((Control) this.groupLights);
      this.flowLayoutPanel2.Controls.Add((Control) this.groupBox5);
      this.flowLayoutPanel2.Dock = DockStyle.Fill;
      this.flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
      this.flowLayoutPanel2.Location = new Point(3, 3);
      this.flowLayoutPanel2.Name = "flowLayoutPanel2";
      this.flowLayoutPanel2.Size = new Size(1343, 775);
      this.flowLayoutPanel2.TabIndex = 104;
      this.groupBox7.Controls.Add((Control) this.radioModelOvercast);
      this.groupBox7.Controls.Add((Control) this.radioModelClearDay);
      this.groupBox7.Controls.Add((Control) this.radioModelSunset);
      this.groupBox7.Controls.Add((Control) this.radioModelNight);
      this.groupBox7.Location = new Point(3, 3);
      this.groupBox7.Name = "groupBox7";
      this.groupBox7.Size = new Size(512, 50);
      this.groupBox7.TabIndex = 110;
      this.groupBox7.TabStop = false;
      this.groupBox7.Text = "Environment";
      this.radioModelOvercast.AutoSize = true;
      this.radioModelOvercast.ImeMode = ImeMode.NoControl;
      this.radioModelOvercast.Location = new Point(6, 19);
      this.radioModelOvercast.Name = "radioModelOvercast";
      this.radioModelOvercast.Size = new Size(90, 17);
      this.radioModelOvercast.TabIndex = 99;
      this.radioModelOvercast.Text = "Overcast Day";
      this.radioModelOvercast.UseVisualStyleBackColor = true;
      this.radioModelOvercast.Visible = false;
      this.radioModelOvercast.CheckedChanged += new EventHandler(this.radioModelOvercast_CheckedChanged);
      this.radioModelClearDay.AutoSize = true;
      this.radioModelClearDay.Checked = true;
      this.radioModelClearDay.ImeMode = ImeMode.NoControl;
      this.radioModelClearDay.Location = new Point((int) sbyte.MaxValue, 19);
      this.radioModelClearDay.Name = "radioModelClearDay";
      this.radioModelClearDay.Size = new Size(44, 17);
      this.radioModelClearDay.TabIndex = 100;
      this.radioModelClearDay.TabStop = true;
      this.radioModelClearDay.Text = "Day";
      this.radioModelClearDay.UseVisualStyleBackColor = true;
      this.radioModelClearDay.CheckedChanged += new EventHandler(this.radioModelClearDay_CheckedChanged);
      this.radioModelSunset.AutoSize = true;
      this.radioModelSunset.ImeMode = ImeMode.NoControl;
      this.radioModelSunset.Location = new Point(375, 19);
      this.radioModelSunset.Name = "radioModelSunset";
      this.radioModelSunset.Size = new Size(58, 17);
      this.radioModelSunset.TabIndex = 98;
      this.radioModelSunset.Text = "Sunset";
      this.radioModelSunset.UseVisualStyleBackColor = true;
      this.radioModelSunset.Visible = false;
      this.radioModelSunset.CheckedChanged += new EventHandler(this.radioModelSunset_CheckedChanged);
      this.radioModelNight.AutoSize = true;
      this.radioModelNight.ImeMode = ImeMode.NoControl;
      this.radioModelNight.Location = new Point((int) byte.MaxValue, 19);
      this.radioModelNight.Name = "radioModelNight";
      this.radioModelNight.Size = new Size(50, 17);
      this.radioModelNight.TabIndex = 101;
      this.radioModelNight.Text = "Night";
      this.radioModelNight.UseVisualStyleBackColor = true;
      this.radioModelNight.CheckedChanged += new EventHandler(this.radioModelNight_CheckedChanged);
      this.multiViewer2DTextures.AutoTransparency = false;
      this.multiViewer2DTextures.BackColor = SystemColors.Control;
      this.multiViewer2DTextures.Bitmaps = (Bitmap[]) null;
      this.multiViewer2DTextures.CheckBitmapSize = false;
      this.multiViewer2DTextures.FixedSize = false;
      this.multiViewer2DTextures.FullSizeButton = false;
      this.multiViewer2DTextures.LabelText = "Image n.";
      this.multiViewer2DTextures.Location = new Point(3, 59);
      this.multiViewer2DTextures.Name = "multiViewer2DTextures";
      this.multiViewer2DTextures.ShowDeleteButton = false;
      this.multiViewer2DTextures.Size = new Size(512, 552);
      this.multiViewer2DTextures.TabIndex = 104;
      this.groupLights.Controls.Add((Control) this.buttonCopyLights);
      this.groupLights.Controls.Add((Control) this.comboStadiumLights);
      this.groupLights.Controls.Add((Control) this.buttonCopyCrowd);
      this.groupLights.Controls.Add((Control) this.label3);
      this.groupLights.Location = new Point(3, 617);
      this.groupLights.Name = "groupLights";
      this.groupLights.Size = new Size(289, 131);
      this.groupLights.TabIndex = 111;
      this.groupLights.TabStop = false;
      this.groupLights.Text = "Crowd";
      this.buttonCopyLights.Enabled = false;
      this.buttonCopyLights.Image = (Image) resources.GetObject("buttonCopyLights.Image");
      this.buttonCopyLights.ImageAlign = ContentAlignment.MiddleLeft;
      this.buttonCopyLights.Location = new Point(17, 95);
      this.buttonCopyLights.Name = "buttonCopyLights";
      this.buttonCopyLights.Size = new Size(247, 25);
      this.buttonCopyLights.TabIndex = 104;
      this.buttonCopyLights.Text = "Copy Lights Positions and Textures";
      this.buttonCopyLights.UseVisualStyleBackColor = true;
      this.buttonCopyLights.Visible = false;
      this.buttonCopyLights.Click += new EventHandler(this.buttonCopyLights_Click);
      this.comboStadiumLights.DataSource = (object) this.stadiumListBindingSource;
      this.comboStadiumLights.FormattingEnabled = true;
      this.comboStadiumLights.Location = new Point(17, 37);
      this.comboStadiumLights.Name = "comboStadiumLights";
      this.comboStadiumLights.Size = new Size(247, 21);
      this.comboStadiumLights.TabIndex = 2;
      this.comboStadiumLights.SelectedIndexChanged += new EventHandler(this.comboStadiumLights_SelectedIndexChanged);
      this.stadiumListBindingSource.DataSource = (object) typeof (StadiumList);
      this.buttonCopyCrowd.Enabled = false;
      this.buttonCopyCrowd.Image = (Image) resources.GetObject("buttonCopyCrowd.Image");
      this.buttonCopyCrowd.ImageAlign = ContentAlignment.MiddleLeft;
      this.buttonCopyCrowd.Location = new Point(17, 64);
      this.buttonCopyCrowd.Name = "buttonCopyCrowd";
      this.buttonCopyCrowd.Size = new Size(247, 25);
      this.buttonCopyCrowd.TabIndex = 102;
      this.buttonCopyCrowd.Text = "Copy Crowd Placemenet Data";
      this.buttonCopyCrowd.UseVisualStyleBackColor = true;
      this.buttonCopyCrowd.Click += new EventHandler(this.buttonCopyCrowd_Click);
      this.label3.AutoSize = true;
      this.label3.Location = new Point(62, 16);
      this.label3.Name = "label3";
      this.label3.Size = new Size(146, 13);
      this.label3.TabIndex = 1;
      this.label3.Text = "Select a stadium to copy from";
      this.groupBox5.Controls.Add((Control) this.multiViewer2DCoverMap);
      this.groupBox5.Location = new Point(521, 3);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Size = new Size(312, 604);
      this.groupBox5.TabIndex = 109;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "Shadow Map";
      this.groupBox5.Visible = false;
      this.multiViewer2DCoverMap.AutoTransparency = false;
      this.multiViewer2DCoverMap.Bitmaps = (Bitmap[]) null;
      this.multiViewer2DCoverMap.CheckBitmapSize = false;
      this.multiViewer2DCoverMap.FixedSize = false;
      this.multiViewer2DCoverMap.FullSizeButton = false;
      this.multiViewer2DCoverMap.LabelText = "Image n.";
      this.multiViewer2DCoverMap.Location = new Point(6, 19);
      this.multiViewer2DCoverMap.Name = "multiViewer2DCoverMap";
      this.multiViewer2DCoverMap.ShowDeleteButton = false;
      this.multiViewer2DCoverMap.Size = new Size(301, 346);
      this.multiViewer2DCoverMap.TabIndex = 108;
      this.multiViewer2DCoverMap.Visible = false;
      this.pickUpControl.BackColor = SystemColors.Control;
      this.pickUpControl.CloneButtonEnabled = true;
      this.pickUpControl.CreateButtonEnabled = false;
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
      this.pickUpControl.Size = new Size(1357, 25);
      this.pickUpControl.TabIndex = 0;
      this.pickUpControl.WizardButtonEnabled = false;
      this.pickUpControl.YoungPlayersEnabled = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImageLayout = ImageLayout.Center;
      this.ClientSize = new Size(1357, 832);
      this.Controls.Add((Control) this.tabEsitStadium);
      this.Controls.Add((Control) this.pickUpControl);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = "StadiumForm";
      this.Text = nameof (StadiumForm);
      this.Load += new EventHandler(this.StadiumForm_Load);
      this.tabEsitStadium.ResumeLayout(false);
      this.pageStadiumGeneral.ResumeLayout(false);
      this.flowLayoutPanel1.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.numericCrowdColor.EndInit();
      this.numericStadiumId.EndInit();
      ((ISupportInitialize) this.pictureHomeTeam).EndInit();
      this.numericYearBuilt.EndInit();
      this.numericCapacity.EndInit();
      this.groupMowingPattern.ResumeLayout(false);
      this.numericMowing.EndInit();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.numericNet.EndInit();
      this.groupBox6.ResumeLayout(false);
      this.groupCamera.ResumeLayout(false);
      this.groupCamera.PerformLayout();
      this.numericCameraZoom.EndInit();
      this.numericCameraHeight.EndInit();
      this.groupAdboards.ResumeLayout(false);
      this.groupAdboards.PerformLayout();
      this.numericAdboardType.EndInit();
      this.numericSideLineDistance.EndInit();
      this.numericEndLineDistance.EndInit();
      this.groupTimeAndWeather.ResumeLayout(false);
      this.groupTimeAndWeather.PerformLayout();
      this.groupPolice.ResumeLayout(false);
      this.pageStadiumPreview.ResumeLayout(false);
      this.groupEnvironment.ResumeLayout(false);
      this.groupBox4.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.pageStadiumModel.ResumeLayout(false);
      this.flowLayoutPanel2.ResumeLayout(false);
      this.groupBox7.ResumeLayout(false);
      this.groupBox7.PerformLayout();
      this.groupLights.ResumeLayout(false);
      this.groupLights.PerformLayout();
      ((ISupportInitialize) this.stadiumListBindingSource).EndInit();
      this.groupBox5.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
