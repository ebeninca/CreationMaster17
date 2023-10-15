// Original code created by Rinaldo

using FifaControls;
using FifaLibrary;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace CreationMaster
{
  public class RefereeForm : Form
  {
    private string m_RefereeCurrentFolder = FifaEnvironment.ExportFolder;
    private string m_NotPresent = "< None >";
    private NewIdCreator m_NewIdCreator = new NewIdCreator();
    private bool m_GenericAppearanceSema = true;
    private int m_HairAlfaChannel = 1;
    private Referee m_CurrentReferee;
    private bool m_IsLoaded;
    private bool m_Locked;
    private IContainer components;
    public PickUpControl pickUpControl;
    private SplitContainer splitContainer1;
    private FlowLayoutPanel flowLayoutPanel1;
    private SplitContainer splitContainer2;
    private GroupBox groupIdentity;
    private Button buttonGetId;
    private NumericUpDown numericRefereeId;
    private Button buttonRandomizeIdentity;
    private DateTimePicker dateBirthDate;
    private Label labelBirthdate;
    private Label labelRefereeId;
    private TextBox textSurname;
    private TextBox textFirstName;
    private ComboBox comboCountry;
    private Label labelFirstName;
    private Label labelSurame;
    private Label labelCountry;
    private BindingSource refereeBindingSource;
    private BindingSource countryListBindingSource;
    private ComboBox comboBody;
    private NumericUpDown numericHeight;
    private NumericUpDown numericWeight;
    private Label labelWeight;
    private Label labelBody;
    private Label labelHeight;
    private DomainUpDown domainSleeves;
    private Label labelSleeves;
    private ComboBox comboLeague0;
    private ComboBox comboStyle;
    private Label labelStyle;
    private FbxViewer3D viewer3D;
    private ToolStrip tool3D;
    private ToolStripButton buttonShow3DModel;
    private ToolStripSeparator toolStripSeparator1;
    private GroupBox groupGenericFace;
    private GroupBox groupTextureInfo;
    private ComboBox comboSkinColor;
    private Label labelFacialHair;
    private Label labelEyeBow;
    private ComboBox domainFacialHair;
    private ComboBox comboEyeBow;
    private Label labelSideburns;
    private ComboBox comboSideburns;
    private Label labelSkintype;
    private ComboBox comboEyescolor;
    private ComboBox comboSkintype;
    private Label label2;
    private Label label1;
    private ComboBox comboFacialHairColor;
    private Label labelFacialHairColor;
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
    private Label labelHeadType;
    private Label labelHairType;
    private ToolStripButton buttonSwitchRenderingMode;
    private ComboBox comboBox1;
    private Label label3;
    private ComboBox comboLeague1;
    private ComboBox comboLeague2;
    private ComboBox comboLeague3;
    private GroupBox groupLeagues;
    private ComboBox comboLeague4;
    private ComboBox comboLeague7;
    private ComboBox comboLeague5;
    private ComboBox comboLeague6;
    private Viewer2D viewer2DPlayerGui;
    private ToolStripButton toolPhoto;
    private GroupBox groupShoes;
    private Label label1ShoesType;
    private PictureBox pictureColorShoes2;
    private PictureBox pictureColorShoes1;
    public NumericUpDown numericShoesBrand;
    private Label labelShoesType;
    private Label labelShoesColor;
    public NumericUpDown numericShoesDesign;
    private Viewer2D viewer2DShoes;
    private Label labelShoes;

    public RefereeForm()
    {
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
      this.pickUpControl.SelectObject = new PickUpControl.PickUpCallback(this.SelectReferee);
      this.pickUpControl.CreateObject = new PickUpControl.PickUpCallback(this.CreateReferee);
      this.pickUpControl.DeleteObject = new PickUpControl.PickUpCallback(this.DeleteReferee);
      this.pickUpControl.CloneObject = new PickUpControl.PickUpCallback(this.CloneReferee);
      this.pickUpControl.RefreshObject = new PickUpControl.PickUpCallback(this.RefreshReferee);
      this.pickUpControl.combo.Sorted = false;
      this.viewer2DShoes.ButtonStripVisible = false;
      this.viewer2DPlayerGui.ButtonStripVisible = true;
      this.viewer2DPlayerGui.ShowButton = true;
      this.viewer2DPlayerGui.ShowButtonChecked = false;
      this.viewer2DPlayerGui.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageMiniface);
      this.viewer2DPlayerGui.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteMiniface);
      this.viewer2DPlayerGui.ButtonStripVisible = true;
      this.viewer2DPlayerGui.RemoveButton = true;
    }

    private Referee SelectReferee(object sender, object obj)
    {
      Referee referee = (Referee)obj;
      this.LoadReferee(referee);
      return referee;
    }

    private Referee CreateReferee(object sender, object obj)
    {
      DialogResult dialogResult = this.m_NewIdCreator.ShowDialog();
      if (this.m_NewIdCreator.NewObject != null)
        return (Referee)this.m_NewIdCreator.NewObject;
      if (dialogResult == DialogResult.OK)
      {
        int num = (int)FifaEnvironment.UserMessages.ShowMessage(5060, this.m_NewIdCreator.NewId);
      }
      return (Referee)null;
    }

    private Referee DeleteReferee(object sender, object obj)
    {
      FifaEnvironment.Referees.DeleteReferee((Referee)obj);
      return (Referee)null;
    }

    private Referee CloneReferee(object sender, object obj)
    {
      return (Referee)FifaEnvironment.Referees.CloneId((IdObject)obj);
    }

    public Referee RefreshReferee(object sender, object obj)
    {
      this.Preset();
      this.ReloadReferee(this.m_CurrentReferee);
      return this.m_CurrentReferee;
    }

    public void ReloadReferee(Referee referee)
    {
      this.m_CurrentReferee = (Referee)null;
      this.LoadReferee(referee);
    }

    public void LoadReferee(Referee referee)
    {
      if (!this.m_IsLoaded || this.m_CurrentReferee == referee)
        return;
      this.m_Locked = true;
      this.m_CurrentReferee = referee;
      this.refereeBindingSource.DataSource = (object)this.m_CurrentReferee;
      this.Refresh();
      this.LoadRefereeInfo();
      this.LoadRefereeFace();
      this.m_Locked = false;
    }

    private void LoadRefereeInfo()
    {
      this.m_Locked = true;
      this.numericRefereeId.Value = (Decimal)this.m_CurrentReferee.Id;
      if (this.m_CurrentReferee.Leagues[0] == null)
        this.comboLeague0.SelectedIndex = 0;
      else
        this.comboLeague0.SelectedItem = (object)this.m_CurrentReferee.Leagues[0];
      if (this.m_CurrentReferee.Leagues[1] == null)
        this.comboLeague1.SelectedIndex = 0;
      else
        this.comboLeague1.SelectedItem = (object)this.m_CurrentReferee.Leagues[1];
      if (this.m_CurrentReferee.Leagues[2] == null)
        this.comboLeague2.SelectedIndex = 0;
      else
        this.comboLeague2.SelectedItem = (object)this.m_CurrentReferee.Leagues[2];
      if (this.m_CurrentReferee.Leagues[3] == null)
        this.comboLeague3.SelectedIndex = 0;
      else
        this.comboLeague3.SelectedItem = (object)this.m_CurrentReferee.Leagues[3];
      if (this.m_CurrentReferee.Leagues[4] == null)
        this.comboLeague4.SelectedIndex = 0;
      else
        this.comboLeague4.SelectedItem = (object)this.m_CurrentReferee.Leagues[4];
      if (this.m_CurrentReferee.Leagues[5] == null)
        this.comboLeague5.SelectedIndex = 0;
      else
        this.comboLeague5.SelectedItem = (object)this.m_CurrentReferee.Leagues[5];
      if (this.m_CurrentReferee.Leagues[6] == null)
        this.comboLeague6.SelectedIndex = 0;
      else
        this.comboLeague6.SelectedItem = (object)this.m_CurrentReferee.Leagues[6];
      if (this.m_CurrentReferee.Leagues[7] == null)
        this.comboLeague7.SelectedIndex = 0;
      else
        this.comboLeague7.SelectedItem = (object)this.m_CurrentReferee.Leagues[7];
      this.numericShoesBrand.Value = (Decimal)this.m_CurrentReferee.shoetypecode;
      this.numericShoesDesign.Value = (Decimal)this.m_CurrentReferee.shoedesigncode;
      this.pictureColorShoes1.BackColor = Shoes.GetGenericColor(this.m_CurrentReferee.shoecolorcode1);
      this.pictureColorShoes2.BackColor = Shoes.GetGenericColor(this.m_CurrentReferee.shoecolorcode2);
      if (this.m_CurrentReferee.shoetypecode == 0)
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
      this.viewer2DShoes.CurrentBitmap = Shoes.GetShoesColorTexture(this.m_CurrentReferee.shoetypecode, this.m_CurrentReferee.shoedesigncode);
      this.m_Locked = false;
    }

    public void Clean()
    {
      this.Visible = false;
    }

    public void Preset()
    {
      //Kit.Prepare3DModels();
      this.m_NewIdCreator.IdList = (IdArrayList)FifaEnvironment.Referees;
      this.pickUpControl.FilterValues = new IdArrayList[3]
      {
        (IdArrayList) null,
        (IdArrayList) FifaEnvironment.Countries,
        (IdArrayList) FifaEnvironment.Leagues
      };
      this.numericShoesBrand.Maximum = (Decimal)FifaEnvironment.FifaDb.Table[TI.referee].TableDescriptor.MaxValues[FI.referee_shoetypecode];
      this.numericRefereeId.Maximum = (Decimal)FifaEnvironment.FifaDb.Table[TI.referee].TableDescriptor.MaxValues[FI.referee_refereeid];
      this.comboLeague0.Items.Clear();
      this.comboLeague0.BeginUpdate();
      this.comboLeague0.Items.Add((object)this.m_NotPresent);
      this.comboLeague0.Items.AddRange(FifaEnvironment.Leagues.ToArray());
      this.comboLeague0.EndUpdate();
      this.comboLeague1.Items.Clear();
      this.comboLeague1.BeginUpdate();
      this.comboLeague1.Items.Add((object)this.m_NotPresent);
      this.comboLeague1.Items.AddRange(FifaEnvironment.Leagues.ToArray());
      this.comboLeague1.EndUpdate();
      this.comboLeague2.Items.Clear();
      this.comboLeague2.BeginUpdate();
      this.comboLeague2.Items.Add((object)this.m_NotPresent);
      this.comboLeague2.Items.AddRange(FifaEnvironment.Leagues.ToArray());
      this.comboLeague2.EndUpdate();
      this.comboLeague3.Items.Clear();
      this.comboLeague3.BeginUpdate();
      this.comboLeague3.Items.Add((object)this.m_NotPresent);
      this.comboLeague3.Items.AddRange(FifaEnvironment.Leagues.ToArray());
      this.comboLeague3.EndUpdate();
      this.comboLeague4.Items.Clear();
      this.comboLeague4.BeginUpdate();
      this.comboLeague4.Items.Add((object)this.m_NotPresent);
      this.comboLeague4.Items.AddRange(FifaEnvironment.Leagues.ToArray());
      this.comboLeague4.EndUpdate();
      this.comboLeague5.Items.Clear();
      this.comboLeague5.BeginUpdate();
      this.comboLeague5.Items.Add((object)this.m_NotPresent);
      this.comboLeague5.Items.AddRange(FifaEnvironment.Leagues.ToArray());
      this.comboLeague5.EndUpdate();
      this.comboLeague6.Items.Clear();
      this.comboLeague6.BeginUpdate();
      this.comboLeague6.Items.Add((object)this.m_NotPresent);
      this.comboLeague6.Items.AddRange(FifaEnvironment.Leagues.ToArray());
      this.comboLeague6.EndUpdate();
      this.comboLeague7.Items.Clear();
      this.comboLeague7.BeginUpdate();
      this.comboLeague7.Items.Add((object)this.m_NotPresent);
      this.comboLeague7.Items.AddRange(FifaEnvironment.Leagues.ToArray());
      this.comboLeague7.EndUpdate();
      this.countryListBindingSource.DataSource = (object)FifaEnvironment.Countries;
      this.viewer2DPlayerGui.Visible = FifaEnvironment.Year == 14;
      this.toolPhoto.Visible = FifaEnvironment.Year == 14;
      this.pickUpControl.ObjectList = (IdArrayList)FifaEnvironment.Referees;
    }

    private void numericRefereeId_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_CurrentReferee == null)
        return;
      int num1 = (int)this.numericRefereeId.Value;
      if (num1 == this.m_CurrentReferee.Id)
        return;
      if (FifaEnvironment.Referees.SearchId(num1) == null)
      {
        FifaEnvironment.Referees.ChangeId((IdObject)this.m_CurrentReferee, num1);
        this.m_CurrentReferee.Id = num1;
        this.m_CurrentReferee.CleanFaceTexture();
        this.m_CurrentReferee.CleanHairTextures();
        this.LoadRefereeFace();
      }
      else
      {
        int num2 = (int)FifaEnvironment.UserMessages.ShowMessage(1015);
        this.numericRefereeId.Value = (Decimal)this.m_CurrentReferee.Id;
      }
    }

    private void LoadRefereeFace()
    {
      this.m_GenericAppearanceSema = false;
      GenericHead.EHeadModelSet modelSet = GenericHead.GetModelSet(this.m_CurrentReferee.headtypecode);
      if (modelSet == GenericHead.EHeadModelSet.Unknown)
      {
        modelSet = GenericHead.EHeadModelSet.Caucasic;
        this.m_CurrentReferee.headtypecode = GenericHead.GetModelId(modelSet, 0);
      }
      int modelSetIndex = GenericHead.GetModelSetIndex(modelSet, this.m_CurrentReferee.headtypecode);
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
      GenericHead.EHairModelSet hairModelSet = GenericHead.GetHairModelSet(this.m_CurrentReferee.hairtypecode);
      int hairModelSetIndex = GenericHead.GetHairModelSetIndex(hairModelSet, this.m_CurrentReferee.hairtypecode);
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
      this.domainFacialHair.SelectedIndex = this.m_CurrentReferee.facialhairtypecode;
      this.domainHairColor.SelectedIndex = this.m_CurrentReferee.haircolorcode;
      this.comboSideburns.SelectedIndex = this.m_CurrentReferee.sideburnscode;
      this.comboSkintype.SelectedIndex = this.m_CurrentReferee.skintypecode;
      this.comboSkinColor.SelectedIndex = this.m_CurrentReferee.skintonecode - 1;
      this.comboEyescolor.SelectedIndex = this.m_CurrentReferee.eyecolorcode - 1;
      this.comboEyeBow.SelectedIndex = this.m_CurrentReferee.eyebrowcode;
      this.comboFacialHairColor.SelectedIndex = this.m_CurrentReferee.facialhaircolorcode;
      this.m_GenericAppearanceSema = true;
      if (FifaEnvironment.Year == 14)
        this.viewer2DPlayerGui.CurrentBitmap = this.m_CurrentReferee.GetPhoto();
      this.UpdateAndShowHead3D();
    }

    private void toolPhoto_Click(object sender, EventArgs e)
    {
      Bitmap bitmap1 = this.viewer3D.Photo();
      int height = bitmap1.Height;
      int width1 = bitmap1.Width;
      int width2 = width1 < height * 17 / 16 ? width1 : height * 5 / 4;
      Rectangle srcRect = new Rectangle((width1 - width2) / 2, 0, width2, height);
      Rectangle destRect = new Rectangle(0, 10, 256, 190);
      Bitmap srcBitmap = GraphicUtil.MakeAutoTransparent(bitmap1);
      Bitmap bitmap2 = new Bitmap(256, 256, PixelFormat.Format32bppArgb);
      GraphicUtil.RemapRectangle(srcBitmap, srcRect, bitmap2, destRect);
      this.m_CurrentReferee.SetPhoto(bitmap2);
      this.viewer2DPlayerGui.CurrentBitmap = bitmap2;
    }

    private bool ImportImageMiniface(object sender, Bitmap bitmap)
    {
      return this.m_CurrentReferee.SetPhoto(bitmap);
    }

    private bool DeleteMiniface(object sender)
    {
      return this.m_CurrentReferee.DeletePhoto();
    }

    private void buttonGetId_Click(object sender, EventArgs e)
    {
      int newId = FifaEnvironment.Referees.GetNewId();
      if (newId == -1)
      {
        int num = (int)FifaEnvironment.UserMessages.ShowMessage(5050);
      }
      else
        this.numericRefereeId.Value = (Decimal)newId;
    }

    private void labelCountry_DoubleClick(object sender, EventArgs e)
    {
      if (this.m_CurrentReferee.Country == null)
        return;
      MainForm.CM.JumpTo((IdObject)this.m_CurrentReferee.Country);
    }

    private void RefereeForm_Load(object sender, EventArgs e)
    {
      this.m_IsLoaded = true;
      this.Preset();
    }

    private void radioButtonAsiatic_CheckedChanged(object sender, EventArgs e)
    {
      if (this.comboAsiaticModels.SelectedIndex < 0)
        this.comboAsiaticModels.SelectedIndex = 0;
      this.comboAsiaticModels.Visible = this.radioButtonAsiatic.Checked;
      if (this.radioButtonAsiatic.Checked)
      {
        this.radioButtonAsiatic.BackColor = Color.LightSkyBlue;
        if (this.m_CurrentReferee.headtypecode == GenericHead.c_AsiaticModels[this.comboAsiaticModels.SelectedIndex])
          return;
        this.m_CurrentReferee.headtypecode = GenericHead.c_AsiaticModels[this.comboAsiaticModels.SelectedIndex];
        if (!this.m_GenericAppearanceSema || !this.buttonShow3DModel.Checked)
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
        if (this.m_CurrentReferee.headtypecode == GenericHead.c_CaucasicModels[this.comboCaucasicModels.SelectedIndex])
          return;
        this.m_CurrentReferee.headtypecode = GenericHead.c_CaucasicModels[this.comboCaucasicModels.SelectedIndex];
        if (!this.m_GenericAppearanceSema || !this.buttonShow3DModel.Checked)
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
        if (this.m_CurrentReferee.headtypecode == GenericHead.c_AfricanModels[this.comboAfricanModels.SelectedIndex])
          return;
        this.m_CurrentReferee.headtypecode = GenericHead.c_AfricanModels[this.comboAfricanModels.SelectedIndex];
        if (!this.m_GenericAppearanceSema || !this.buttonShow3DModel.Checked)
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
        if (this.m_CurrentReferee.headtypecode == GenericHead.c_LatinModels[this.comboLatinModels.SelectedIndex])
          return;
        this.m_CurrentReferee.headtypecode = GenericHead.c_LatinModels[this.comboLatinModels.SelectedIndex];
        if (!this.m_GenericAppearanceSema || !this.buttonShow3DModel.Checked)
          return;
        this.UpdateAndShowHead3D();
      }
      else
        this.radioButtonLatin.BackColor = Color.Transparent;
    }

    private void UpdateAndShowHead3D()
    {
      if (!this.buttonShow3DModel.Checked)
      {
        this.viewer3D.ShowEmpty();
      }
      else
      {
        Bitmap faceTexture = this.m_CurrentReferee.GetFaceTexture();
        Bitmap eyesTexture = this.m_CurrentReferee.GetEyesTexture();
        Rx3File headModel = this.m_CurrentReferee.GetHeadModel();
        if (headModel == null)
        {
          this.viewer3D.ShowEmpty();
        }
        else
        {
          /*Player.s_Model3DHead = new Model3D(headModel.Rx3IndexArrays[0], headModel.Rx3VertexArrays[0], faceTexture);
          Player.s_Model3DEyes = new Model3D(headModel.Rx3IndexArrays[1], headModel.Rx3VertexArrays[1], eyesTexture);
          Player.s_Model3DHairPart4 = (Model3D)null;
          Player.s_Model3DHairPart5 = (Model3D)null;
          if (headModel.Rx3VertexArrays[0].nVertex > headModel.Rx3VertexArrays[1].nVertex)
          {
            Player.s_Model3DHead = new Model3D(headModel.Rx3IndexArrays[0], headModel.Rx3VertexArrays[0], faceTexture);
            Player.s_Model3DEyes = new Model3D(headModel.Rx3IndexArrays[1], headModel.Rx3VertexArrays[1], eyesTexture);
          }
          else
          {
            Player.s_Model3DHead = new Model3D(headModel.Rx3IndexArrays[0], headModel.Rx3VertexArrays[0], eyesTexture);
            Player.s_Model3DEyes = new Model3D(headModel.Rx3IndexArrays[1], headModel.Rx3VertexArrays[1], faceTexture);
          }*/
          Rx3File hairModel = this.m_CurrentReferee.GetHairModel();
          if (hairModel != null)
          {
            Bitmap hairColorTexture = this.m_CurrentReferee.GetHairColorTexture();
            Bitmap hairAlfaTexture = this.m_CurrentReferee.GetHairAlfaTexture();
            Bitmap bitmap1 = (Bitmap)null;
            Bitmap bitmap2 = (Bitmap)null;
            if (hairColorTexture != null && hairAlfaTexture != null)
            {
              Bitmap bitmap3 = GraphicUtil.ResizeBitmap(hairColorTexture, hairAlfaTexture.Width, hairAlfaTexture.Height, InterpolationMode.Bilinear);
              bitmap1 = (Bitmap)bitmap3.Clone();
              GraphicUtil.GetAlfaFromChannel(bitmap1, hairAlfaTexture, this.m_HairAlfaChannel);
              bitmap2 = (Bitmap)bitmap3.Clone();
              GraphicUtil.GetAlfaFromChannel(bitmap2, hairAlfaTexture, 4 - this.m_HairAlfaChannel);
            }
            Rx3IndexArray.TriangleListType = Rx3IndexArray.ETriangleListType.InvertEven;
            //Player.s_Model3DHairPart4 = new Model3D(hairModel.Rx3IndexArrays[0], hairModel.Rx3VertexArrays[0], bitmap1);
            //if (hairModel.Rx3IndexArrays.Length > 1)
            //  Player.s_Model3DHairPart5 = new Model3D(hairModel.Rx3IndexArrays[1], hairModel.Rx3VertexArrays[1], bitmap2);
          }
          this.ShowHead3D();
        }
      }
    }

    private void ShowHead3D()
    {
      /*int nMeshes = 2;
      if (Player.s_Model3DHairPart4 != null)
        nMeshes = 3;
      if (Player.s_Model3DHairPart5 != null)
        nMeshes = 4;
      Kit kit = FifaEnvironment.Kits.GetKit(6004, 5);
      if (kit != null)
      {
        Bitmap bitmap = GraphicUtil.EmbossBitmap(kit.GetKitTextures()[1], Kit.s_JerseyWrinkle);
        Kit.s_JerseyModel3D[kit.jerseyCollar].TextureBitmap = bitmap;
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
        if (this.m_CurrentReferee.hairtypecode == hairMap[tag.SelectedIndex])
          return;
        this.m_CurrentReferee.hairtypecode = hairMap[tag.SelectedIndex];
        if (!this.m_GenericAppearanceSema || !this.buttonShow3DModel.Checked)
          return;
        this.m_CurrentReferee.CleanHairTextures();
        this.UpdateAndShowHead3D();
      }
      else
        radioButton.BackColor = Color.Transparent;
    }

    private void comboAsiaticModels_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.m_GenericAppearanceSema || this.comboAsiaticModels.SelectedIndex < 0)
        return;
      this.m_CurrentReferee.headtypecode = GenericHead.c_AsiaticModels[this.comboAsiaticModels.SelectedIndex];
      if (!this.buttonShow3DModel.Checked)
        return;
      this.m_CurrentReferee.CleanHeadModel();
      this.UpdateAndShowHead3D();
    }

    private void comboAfricanModels_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.m_GenericAppearanceSema || this.comboAfricanModels.SelectedIndex < 0)
        return;
      this.m_CurrentReferee.headtypecode = GenericHead.c_AfricanModels[this.comboAfricanModels.SelectedIndex];
      if (!this.buttonShow3DModel.Checked)
        return;
      this.m_CurrentReferee.CleanHeadModel();
      this.UpdateAndShowHead3D();
    }

    private void comboCaucasicModels_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.m_GenericAppearanceSema || this.comboCaucasicModels.SelectedIndex < 0)
        return;
      this.m_CurrentReferee.headtypecode = GenericHead.c_CaucasicModels[this.comboCaucasicModels.SelectedIndex];
      if (!this.buttonShow3DModel.Checked)
        return;
      this.m_CurrentReferee.CleanHeadModel();
      this.UpdateAndShowHead3D();
    }

    private void comboLatinModels_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.m_GenericAppearanceSema || this.comboLatinModels.SelectedIndex < 0)
        return;
      this.m_CurrentReferee.headtypecode = GenericHead.c_LatinModels[this.comboLatinModels.SelectedIndex];
      if (!this.buttonShow3DModel.Checked)
        return;
      this.m_CurrentReferee.CleanHeadModel();
      this.UpdateAndShowHead3D();
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
      this.m_CurrentReferee.hairtypecode = hairMap[comboBox.SelectedIndex];
      if (!this.m_GenericAppearanceSema || !this.buttonShow3DModel.Checked)
        return;
      this.m_CurrentReferee.CleanHair();
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

    private void domainHairColor_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.m_GenericAppearanceSema)
        return;
      this.m_CurrentReferee.haircolorcode = this.domainHairColor.SelectedIndex;
      if (!this.buttonShow3DModel.Checked)
        return;
      this.m_CurrentReferee.CleanHairTextures();
      this.UpdateAndShowHead3D();
    }

    private void buttonShow3DModel_Click(object sender, EventArgs e)
    {
      this.UpdateAndShowHead3D();
    }

    private void comboSkintype_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.m_GenericAppearanceSema || this.comboSkintype.SelectedIndex < 0)
        return;
      this.m_CurrentReferee.skintypecode = this.comboSkintype.SelectedIndex;
      if (!this.buttonShow3DModel.Checked)
        return;
      this.m_CurrentReferee.CleanFaceTexture();
      this.UpdateAndShowHead3D();
    }

    private void comboSkinColor_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.m_GenericAppearanceSema || this.comboSkinColor.SelectedIndex < 0)
        return;
      this.m_CurrentReferee.skintonecode = this.comboSkinColor.SelectedIndex + 1;
      if (!this.buttonShow3DModel.Checked)
        return;
      this.m_CurrentReferee.CleanFaceTexture();
      this.UpdateAndShowHead3D();
    }

    private void comboEyescolor_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.m_GenericAppearanceSema || this.comboEyescolor.SelectedIndex < 0)
        return;
      this.m_CurrentReferee.eyecolorcode = this.comboEyescolor.SelectedIndex + 1;
      this.m_CurrentReferee.CleanEyesTexture();
      if (!this.buttonShow3DModel.Checked)
        return;
      this.UpdateAndShowHead3D();
    }

    private void domainFacialHair_SelectedItemChanged(object sender, EventArgs e)
    {
      if (!this.m_GenericAppearanceSema)
        return;
      this.m_CurrentReferee.facialhairtypecode = this.domainFacialHair.SelectedIndex;
      if (!this.buttonShow3DModel.Checked)
        return;
      this.m_CurrentReferee.CleanFaceTexture();
      this.UpdateAndShowHead3D();
    }

    private void comboFacialHairColor_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.m_GenericAppearanceSema || this.comboFacialHairColor.SelectedIndex < 0)
        return;
      this.m_CurrentReferee.facialhaircolorcode = this.comboFacialHairColor.SelectedIndex;
      if (!this.buttonShow3DModel.Checked)
        return;
      this.m_CurrentReferee.CleanFaceTexture();
      this.UpdateAndShowHead3D();
    }

    private void comboSideburns_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.m_GenericAppearanceSema || this.comboSideburns.SelectedIndex < 0)
        return;
      this.m_CurrentReferee.sideburnscode = this.comboSideburns.SelectedIndex;
      if (!this.buttonShow3DModel.Checked)
        return;
      this.m_CurrentReferee.CleanFaceTexture();
      this.UpdateAndShowHead3D();
    }

    private void comboEyeBow_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.m_GenericAppearanceSema || this.comboEyeBow.SelectedIndex < 0)
        return;
      this.m_CurrentReferee.eyebrowcode = this.comboEyeBow.SelectedIndex;
      if (!this.buttonShow3DModel.Checked)
        return;
      this.m_CurrentReferee.CleanFaceTexture();
      this.UpdateAndShowHead3D();
    }

    private void buttonRandomizeIdentity_Click(object sender, EventArgs e)
    {
    }

    private void buttonRandomizeAppearance_Click(object sender, EventArgs e)
    {
      if (this.radioButtonAfrican.Checked)
        this.m_CurrentReferee.RandomizeAfricanAppearance();
      else if (this.radioButtonAsiatic.Checked)
        this.m_CurrentReferee.RandomizeAsiaticAppearance();
      else if (this.radioButtonCaucasic.Checked)
        this.m_CurrentReferee.RandomizeCaucasianAppearance();
      else if (this.radioButtonLatin.Checked)
        this.m_CurrentReferee.RandomizeLatinAppearance();
      this.m_CurrentReferee.CleanAllHead();
      this.LoadRefereeFace();
      this.m_GenericAppearanceSema = true;
    }

    private void buttonSwitchRenderingMode_Click(object sender, EventArgs e)
    {
      this.m_HairAlfaChannel = 4 - this.m_HairAlfaChannel;
      this.UpdateAndShowHead3D();
    }

    private void textFirstName_TextChanged(object sender, EventArgs e)
    {
      if (this.m_Locked)
        return;
      this.m_CurrentReferee.firstname = this.textFirstName.Text;
      this.pickUpControl.SwitchObject((IdObject)this.m_CurrentReferee);
    }

    private void textSurname_TextChanged(object sender, EventArgs e)
    {
      if (this.m_Locked)
        return;
      this.m_CurrentReferee.surname = this.textSurname.Text;
      this.pickUpControl.SwitchObject((IdObject)this.m_CurrentReferee);
    }

    private void comboLeague0_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboLeague0.SelectedIndex == 0)
      {
        this.m_CurrentReferee.Leagues[0] = (League)null;
        this.m_CurrentReferee.leagueids[0] = 0;
      }
      else
      {
        League selectedItem = (League)this.comboLeague0.SelectedItem;
        this.m_CurrentReferee.Leagues[0] = selectedItem;
        this.m_CurrentReferee.leagueids[0] = selectedItem.Id;
      }
    }

    private void comboLeague1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboLeague1.SelectedIndex == 0)
      {
        this.m_CurrentReferee.Leagues[1] = (League)null;
        this.m_CurrentReferee.leagueids[1] = 0;
      }
      else
      {
        League selectedItem = (League)this.comboLeague1.SelectedItem;
        this.m_CurrentReferee.Leagues[1] = selectedItem;
        this.m_CurrentReferee.leagueids[1] = selectedItem.Id;
      }
    }

    private void comboLeague2_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboLeague2.SelectedIndex == 0)
      {
        this.m_CurrentReferee.Leagues[2] = (League)null;
        this.m_CurrentReferee.leagueids[2] = 0;
      }
      else
      {
        League selectedItem = (League)this.comboLeague2.SelectedItem;
        this.m_CurrentReferee.Leagues[2] = selectedItem;
        this.m_CurrentReferee.leagueids[2] = selectedItem.Id;
      }
    }

    private void comboLeague3_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboLeague3.SelectedIndex == 0)
      {
        this.m_CurrentReferee.Leagues[3] = (League)null;
        this.m_CurrentReferee.leagueids[3] = 0;
      }
      else
      {
        League selectedItem = (League)this.comboLeague3.SelectedItem;
        this.m_CurrentReferee.Leagues[3] = selectedItem;
        this.m_CurrentReferee.leagueids[3] = selectedItem.Id;
      }
    }

    private void comboLeague4_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboLeague4.SelectedIndex == 0)
      {
        this.m_CurrentReferee.Leagues[4] = (League)null;
        this.m_CurrentReferee.leagueids[4] = 0;
      }
      else
      {
        League selectedItem = (League)this.comboLeague4.SelectedItem;
        this.m_CurrentReferee.Leagues[4] = selectedItem;
        this.m_CurrentReferee.leagueids[4] = selectedItem.Id;
      }
    }

    private void comboLeague5_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboLeague5.SelectedIndex == 0)
      {
        this.m_CurrentReferee.Leagues[5] = (League)null;
        this.m_CurrentReferee.leagueids[5] = 0;
      }
      else
      {
        League selectedItem = (League)this.comboLeague5.SelectedItem;
        this.m_CurrentReferee.Leagues[5] = selectedItem;
        this.m_CurrentReferee.leagueids[5] = selectedItem.Id;
      }
    }

    private void comboLeague6_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboLeague6.SelectedIndex == 0)
      {
        this.m_CurrentReferee.Leagues[6] = (League)null;
        this.m_CurrentReferee.leagueids[6] = 0;
      }
      else
      {
        League selectedItem = (League)this.comboLeague6.SelectedItem;
        this.m_CurrentReferee.Leagues[6] = selectedItem;
        this.m_CurrentReferee.leagueids[6] = selectedItem.Id;
      }
    }

    private void comboLeague7_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboLeague7.SelectedIndex == 0)
      {
        this.m_CurrentReferee.Leagues[7] = (League)null;
        this.m_CurrentReferee.leagueids[7] = 0;
      }
      else
      {
        League selectedItem = (League)this.comboLeague7.SelectedItem;
        this.m_CurrentReferee.Leagues[7] = selectedItem;
        this.m_CurrentReferee.leagueids[7] = selectedItem.Id;
      }
    }

    private void labelShoes_DoubleClick(object sender, EventArgs e)
    {
      Shoes shoes = (Shoes)FifaEnvironment.Shoes.SearchId(this.m_CurrentReferee.shoetypecode);
      if (shoes == null)
        return;
      MainForm.CM.JumpTo((IdObject)shoes);
    }

    private void numericShoesBrand_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_Locked)
        return;
      int shoesBrand = (int)this.numericShoesBrand.Value;
      if (shoesBrand == 0)
      {
        this.m_CurrentReferee.shoetypecode = shoesBrand;
        this.m_CurrentReferee.shoecolorcode1 = 0;
        this.m_CurrentReferee.shoecolorcode2 = 15;
        this.pictureColorShoes1.BackColor = Shoes.ShoesColorPalette[this.m_CurrentReferee.shoecolorcode1];
        this.pictureColorShoes2.BackColor = Shoes.ShoesColorPalette[this.m_CurrentReferee.shoecolorcode2];
        this.numericShoesDesign.Enabled = true;
        this.pictureColorShoes1.Enabled = true;
        this.pictureColorShoes2.Enabled = true;
      }
      else
      {
        this.m_CurrentReferee.shoetypecode = shoesBrand;
        this.numericShoesDesign.Enabled = false;
        this.pictureColorShoes1.Enabled = false;
        this.pictureColorShoes2.Enabled = false;
        this.pictureColorShoes1.BackColor = Color.Transparent;
        this.pictureColorShoes2.BackColor = Color.Transparent;
        this.m_CurrentReferee.shoedesigncode = 0;
        this.m_CurrentReferee.shoecolorcode1 = 30;
        this.m_CurrentReferee.shoecolorcode2 = 31;
        this.numericShoesDesign.Value = new Decimal(0);
      }
      this.viewer2DShoes.CurrentBitmap = Shoes.GetShoesColorTexture(shoesBrand, 0);
    }

    private void numericShoesDesign_ValueChanged(object sender, EventArgs e)
    {
      if (this.m_Locked)
        return;
      int shoesDesign = (int)this.numericShoesDesign.Value;
      this.m_CurrentReferee.shoedesigncode = shoesDesign;
      if (this.m_CurrentReferee.shoetypecode != 0)
        return;
      this.viewer2DShoes.CurrentBitmap = Shoes.GetShoesColorTexture(0, shoesDesign);
    }

    private void pictureColorShoes1_Click(object sender, EventArgs e)
    {
      ColorSelector colorSelector = new ColorSelector(Shoes.ShoesColorPalette, this.m_CurrentReferee.shoecolorcode1);
      if (colorSelector.ShowDialog() == DialogResult.OK)
      {
        this.m_CurrentReferee.shoecolorcode1 = colorSelector.SelectedIndex;
        this.pictureColorShoes1.BackColor = colorSelector.SelectedColor;
      }
      colorSelector.Dispose();
    }

    private void pictureColorShoes2_Click(object sender, EventArgs e)
    {
      ColorSelector colorSelector = new ColorSelector(Shoes.ShoesColorPalette, this.m_CurrentReferee.shoecolorcode2);
      if (colorSelector.ShowDialog() == DialogResult.OK)
      {
        this.m_CurrentReferee.shoecolorcode2 = colorSelector.SelectedIndex;
        this.pictureColorShoes2.BackColor = colorSelector.SelectedColor;
      }
      colorSelector.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RefereeForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupIdentity = new System.Windows.Forms.GroupBox();
            this.groupShoes = new System.Windows.Forms.GroupBox();
            this.label1ShoesType = new System.Windows.Forms.Label();
            this.pictureColorShoes2 = new System.Windows.Forms.PictureBox();
            this.refereeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pictureColorShoes1 = new System.Windows.Forms.PictureBox();
            this.numericShoesBrand = new System.Windows.Forms.NumericUpDown();
            this.labelShoesType = new System.Windows.Forms.Label();
            this.labelShoesColor = new System.Windows.Forms.Label();
            this.numericShoesDesign = new System.Windows.Forms.NumericUpDown();
            this.viewer2DShoes = new FifaControls.Viewer2D();
            this.labelShoes = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboStyle = new System.Windows.Forms.ComboBox();
            this.labelStyle = new System.Windows.Forms.Label();
            this.domainSleeves = new System.Windows.Forms.DomainUpDown();
            this.labelSleeves = new System.Windows.Forms.Label();
            this.comboBody = new System.Windows.Forms.ComboBox();
            this.numericHeight = new System.Windows.Forms.NumericUpDown();
            this.numericWeight = new System.Windows.Forms.NumericUpDown();
            this.labelWeight = new System.Windows.Forms.Label();
            this.labelBody = new System.Windows.Forms.Label();
            this.labelHeight = new System.Windows.Forms.Label();
            this.buttonGetId = new System.Windows.Forms.Button();
            this.numericRefereeId = new System.Windows.Forms.NumericUpDown();
            this.buttonRandomizeIdentity = new System.Windows.Forms.Button();
            this.dateBirthDate = new System.Windows.Forms.DateTimePicker();
            this.labelBirthdate = new System.Windows.Forms.Label();
            this.labelRefereeId = new System.Windows.Forms.Label();
            this.textSurname = new System.Windows.Forms.TextBox();
            this.textFirstName = new System.Windows.Forms.TextBox();
            this.comboCountry = new System.Windows.Forms.ComboBox();
            this.countryListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelFirstName = new System.Windows.Forms.Label();
            this.labelSurame = new System.Windows.Forms.Label();
            this.labelCountry = new System.Windows.Forms.Label();
            this.groupLeagues = new System.Windows.Forms.GroupBox();
            this.comboLeague4 = new System.Windows.Forms.ComboBox();
            this.comboLeague7 = new System.Windows.Forms.ComboBox();
            this.comboLeague5 = new System.Windows.Forms.ComboBox();
            this.comboLeague6 = new System.Windows.Forms.ComboBox();
            this.comboLeague0 = new System.Windows.Forms.ComboBox();
            this.comboLeague3 = new System.Windows.Forms.ComboBox();
            this.comboLeague1 = new System.Windows.Forms.ComboBox();
            this.comboLeague2 = new System.Windows.Forms.ComboBox();
            this.viewer2DPlayerGui = new FifaControls.Viewer2D();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.viewer3D = new FifaControls.FbxViewer3D();
            this.tool3D = new System.Windows.Forms.ToolStrip();
            this.buttonShow3DModel = new System.Windows.Forms.ToolStripButton();
            this.buttonSwitchRenderingMode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPhoto = new System.Windows.Forms.ToolStripButton();
            this.groupGenericFace = new System.Windows.Forms.GroupBox();
            this.groupTextureInfo = new System.Windows.Forms.GroupBox();
            this.comboSkinColor = new System.Windows.Forms.ComboBox();
            this.labelFacialHair = new System.Windows.Forms.Label();
            this.labelEyeBow = new System.Windows.Forms.Label();
            this.domainFacialHair = new System.Windows.Forms.ComboBox();
            this.comboEyeBow = new System.Windows.Forms.ComboBox();
            this.labelSideburns = new System.Windows.Forms.Label();
            this.comboSideburns = new System.Windows.Forms.ComboBox();
            this.labelSkintype = new System.Windows.Forms.Label();
            this.comboEyescolor = new System.Windows.Forms.ComboBox();
            this.comboSkintype = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboFacialHairColor = new System.Windows.Forms.ComboBox();
            this.labelFacialHairColor = new System.Windows.Forms.Label();
            this.groupHairModel = new System.Windows.Forms.GroupBox();
            this.comboHeadband = new System.Windows.Forms.ComboBox();
            this.comboAfro = new System.Windows.Forms.ComboBox();
            this.comboLong = new System.Windows.Forms.ComboBox();
            this.comboMedium = new System.Windows.Forms.ComboBox();
            this.comboModern = new System.Windows.Forms.ComboBox();
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
            this.domainHairColor = new System.Windows.Forms.ComboBox();
            this.labelHairColor = new System.Windows.Forms.Label();
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
            this.labelHairType = new System.Windows.Forms.Label();
            this.pickUpControl = new FifaControls.PickUpControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupIdentity.SuspendLayout();
            this.groupShoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureColorShoes2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refereeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureColorShoes1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericShoesBrand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericShoesDesign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRefereeId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryListBindingSource)).BeginInit();
            this.groupLeagues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tool3D.SuspendLayout();
            this.groupGenericFace.SuspendLayout();
            this.groupTextureInfo.SuspendLayout();
            this.groupHairModel.SuspendLayout();
            this.groupHeadModel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1357, 807);
            this.splitContainer1.SplitterDistance = 527;
            this.splitContainer1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupIdentity);
            this.flowLayoutPanel1.Controls.Add(this.groupLeagues);
            this.flowLayoutPanel1.Controls.Add(this.viewer2DPlayerGui);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(527, 807);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // groupIdentity
            // 
            this.groupIdentity.Controls.Add(this.groupShoes);
            this.groupIdentity.Controls.Add(this.comboBox1);
            this.groupIdentity.Controls.Add(this.label3);
            this.groupIdentity.Controls.Add(this.comboStyle);
            this.groupIdentity.Controls.Add(this.labelStyle);
            this.groupIdentity.Controls.Add(this.domainSleeves);
            this.groupIdentity.Controls.Add(this.labelSleeves);
            this.groupIdentity.Controls.Add(this.comboBody);
            this.groupIdentity.Controls.Add(this.numericHeight);
            this.groupIdentity.Controls.Add(this.numericWeight);
            this.groupIdentity.Controls.Add(this.labelWeight);
            this.groupIdentity.Controls.Add(this.labelBody);
            this.groupIdentity.Controls.Add(this.labelHeight);
            this.groupIdentity.Controls.Add(this.buttonGetId);
            this.groupIdentity.Controls.Add(this.numericRefereeId);
            this.groupIdentity.Controls.Add(this.buttonRandomizeIdentity);
            this.groupIdentity.Controls.Add(this.dateBirthDate);
            this.groupIdentity.Controls.Add(this.labelBirthdate);
            this.groupIdentity.Controls.Add(this.labelRefereeId);
            this.groupIdentity.Controls.Add(this.textSurname);
            this.groupIdentity.Controls.Add(this.textFirstName);
            this.groupIdentity.Controls.Add(this.comboCountry);
            this.groupIdentity.Controls.Add(this.labelFirstName);
            this.groupIdentity.Controls.Add(this.labelSurame);
            this.groupIdentity.Controls.Add(this.labelCountry);
            this.groupIdentity.Location = new System.Drawing.Point(3, 3);
            this.groupIdentity.Name = "groupIdentity";
            this.groupIdentity.Size = new System.Drawing.Size(512, 301);
            this.groupIdentity.TabIndex = 0;
            this.groupIdentity.TabStop = false;
            this.groupIdentity.Text = "Identity";
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
            this.groupShoes.Location = new System.Drawing.Point(251, 15);
            this.groupShoes.Name = "groupShoes";
            this.groupShoes.Size = new System.Drawing.Size(243, 178);
            this.groupShoes.TabIndex = 189;
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
            this.pictureColorShoes2.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", this.refereeBindingSource, "shoecolorcode2", true));
            this.pictureColorShoes2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureColorShoes2.Location = new System.Drawing.Point(72, 131);
            this.pictureColorShoes2.Name = "pictureColorShoes2";
            this.pictureColorShoes2.Size = new System.Drawing.Size(20, 20);
            this.pictureColorShoes2.TabIndex = 63;
            this.pictureColorShoes2.TabStop = false;
            this.pictureColorShoes2.Click += new System.EventHandler(this.pictureColorShoes2_Click);
            // 
            // refereeBindingSource
            // 
            this.refereeBindingSource.DataSource = typeof(FifaLibrary.Referee);
            // 
            // pictureColorShoes1
            // 
            this.pictureColorShoes1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureColorShoes1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureColorShoes1.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", this.refereeBindingSource, "shoecolorcode1", true));
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
            this.numericShoesBrand.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.refereeBindingSource, "shoetypecode", true));
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
            this.numericShoesDesign.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.refereeBindingSource, "shoedesigncode", true));
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
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.refereeBindingSource, "cardstrictness", true));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Tolerant",
            "Balanced",
            "Easy Card"});
            this.comboBox1.Location = new System.Drawing.Point(95, 253);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(132, 21);
            this.comboBox1.TabIndex = 188;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(9, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 187;
            this.label3.Text = "Cards Style";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboStyle
            // 
            this.comboStyle.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.refereeBindingSource, "foulstrictness", true));
            this.comboStyle.FormattingEnabled = true;
            this.comboStyle.Items.AddRange(new object[] {
            "Let Play",
            "Balanced",
            "Easy Whistle"});
            this.comboStyle.Location = new System.Drawing.Point(96, 226);
            this.comboStyle.Name = "comboStyle";
            this.comboStyle.Size = new System.Drawing.Size(132, 21);
            this.comboStyle.TabIndex = 186;
            // 
            // labelStyle
            // 
            this.labelStyle.AutoSize = true;
            this.labelStyle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelStyle.Location = new System.Drawing.Point(9, 229);
            this.labelStyle.Name = "labelStyle";
            this.labelStyle.Size = new System.Drawing.Size(58, 13);
            this.labelStyle.TabIndex = 185;
            this.labelStyle.Text = "Fouls Style";
            this.labelStyle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // domainSleeves
            // 
            this.domainSleeves.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.refereeBindingSource, "jerseysleevelengthcode", true));
            this.domainSleeves.Items.Add("Short");
            this.domainSleeves.Items.Add("Long");
            this.domainSleeves.Location = new System.Drawing.Point(362, 242);
            this.domainSleeves.Name = "domainSleeves";
            this.domainSleeves.Size = new System.Drawing.Size(132, 20);
            this.domainSleeves.TabIndex = 175;
            this.domainSleeves.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.domainSleeves.Wrap = true;
            // 
            // labelSleeves
            // 
            this.labelSleeves.AutoSize = true;
            this.labelSleeves.BackColor = System.Drawing.Color.Transparent;
            this.labelSleeves.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelSleeves.Location = new System.Drawing.Point(261, 244);
            this.labelSleeves.Name = "labelSleeves";
            this.labelSleeves.Size = new System.Drawing.Size(81, 13);
            this.labelSleeves.TabIndex = 176;
            this.labelSleeves.Text = "Sleeves Length";
            this.labelSleeves.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBody
            // 
            this.comboBody.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.refereeBindingSource, "bodytypecode", true));
            this.comboBody.FormattingEnabled = true;
            this.comboBody.Items.AddRange(new object[] {
            "Small",
            "Normal",
            "Big"});
            this.comboBody.Location = new System.Drawing.Point(97, 199);
            this.comboBody.Name = "comboBody";
            this.comboBody.Size = new System.Drawing.Size(132, 21);
            this.comboBody.TabIndex = 174;
            // 
            // numericHeight
            // 
            this.numericHeight.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.refereeBindingSource, "height", true));
            this.numericHeight.Location = new System.Drawing.Point(97, 147);
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
            this.numericHeight.Size = new System.Drawing.Size(132, 20);
            this.numericHeight.TabIndex = 169;
            this.numericHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericHeight.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // numericWeight
            // 
            this.numericWeight.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.refereeBindingSource, "weight", true));
            this.numericWeight.Location = new System.Drawing.Point(97, 173);
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
            this.numericWeight.Size = new System.Drawing.Size(132, 20);
            this.numericWeight.TabIndex = 170;
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
            this.labelWeight.Location = new System.Drawing.Point(7, 175);
            this.labelWeight.Name = "labelWeight";
            this.labelWeight.Size = new System.Drawing.Size(41, 13);
            this.labelWeight.TabIndex = 172;
            this.labelWeight.Text = "Weight";
            this.labelWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBody
            // 
            this.labelBody.AutoSize = true;
            this.labelBody.BackColor = System.Drawing.Color.Transparent;
            this.labelBody.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelBody.Location = new System.Drawing.Point(6, 202);
            this.labelBody.Name = "labelBody";
            this.labelBody.Size = new System.Drawing.Size(31, 13);
            this.labelBody.TabIndex = 173;
            this.labelBody.Text = "Body";
            this.labelBody.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.BackColor = System.Drawing.Color.Transparent;
            this.labelHeight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelHeight.Location = new System.Drawing.Point(6, 149);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(38, 13);
            this.labelHeight.TabIndex = 171;
            this.labelHeight.Text = "Height";
            this.labelHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonGetId
            // 
            this.buttonGetId.Location = new System.Drawing.Point(204, 17);
            this.buttonGetId.Name = "buttonGetId";
            this.buttonGetId.Size = new System.Drawing.Size(24, 20);
            this.buttonGetId.TabIndex = 168;
            this.buttonGetId.Text = "...";
            this.buttonGetId.UseVisualStyleBackColor = true;
            this.buttonGetId.Click += new System.EventHandler(this.buttonGetId_Click);
            // 
            // numericRefereeId
            // 
            this.numericRefereeId.Location = new System.Drawing.Point(98, 17);
            this.numericRefereeId.Maximum = new decimal(new int[] {
            600000,
            0,
            0,
            0});
            this.numericRefereeId.Name = "numericRefereeId";
            this.numericRefereeId.Size = new System.Drawing.Size(91, 20);
            this.numericRefereeId.TabIndex = 167;
            this.numericRefereeId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericRefereeId.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericRefereeId.ValueChanged += new System.EventHandler(this.numericRefereeId_ValueChanged);
            // 
            // buttonRandomizeIdentity
            // 
            this.buttonRandomizeIdentity.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonRandomizeIdentity.Location = new System.Drawing.Point(264, 268);
            this.buttonRandomizeIdentity.Name = "buttonRandomizeIdentity";
            this.buttonRandomizeIdentity.Size = new System.Drawing.Size(230, 23);
            this.buttonRandomizeIdentity.TabIndex = 166;
            this.buttonRandomizeIdentity.Text = "Randomize";
            this.buttonRandomizeIdentity.UseVisualStyleBackColor = true;
            this.buttonRandomizeIdentity.Visible = false;
            this.buttonRandomizeIdentity.Click += new System.EventHandler(this.buttonRandomizeIdentity_Click);
            // 
            // dateBirthDate
            // 
            this.dateBirthDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.refereeBindingSource, "birthdate", true));
            this.dateBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateBirthDate.Location = new System.Drawing.Point(97, 94);
            this.dateBirthDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dateBirthDate.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.dateBirthDate.Name = "dateBirthDate";
            this.dateBirthDate.Size = new System.Drawing.Size(131, 20);
            this.dateBirthDate.TabIndex = 161;
            this.dateBirthDate.Value = new System.DateTime(2006, 12, 31, 0, 0, 0, 0);
            // 
            // labelBirthdate
            // 
            this.labelBirthdate.AutoSize = true;
            this.labelBirthdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelBirthdate.Location = new System.Drawing.Point(7, 98);
            this.labelBirthdate.Name = "labelBirthdate";
            this.labelBirthdate.Size = new System.Drawing.Size(49, 13);
            this.labelBirthdate.TabIndex = 163;
            this.labelBirthdate.Text = "Birthdate";
            this.labelBirthdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRefereeId
            // 
            this.labelRefereeId.AutoSize = true;
            this.labelRefereeId.BackColor = System.Drawing.Color.Transparent;
            this.labelRefereeId.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelRefereeId.Location = new System.Drawing.Point(7, 21);
            this.labelRefereeId.Name = "labelRefereeId";
            this.labelRefereeId.Size = new System.Drawing.Size(57, 13);
            this.labelRefereeId.TabIndex = 165;
            this.labelRefereeId.Text = "Referee Id";
            this.labelRefereeId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textSurname
            // 
            this.textSurname.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.refereeBindingSource, "surname", true));
            this.textSurname.Location = new System.Drawing.Point(97, 68);
            this.textSurname.Name = "textSurname";
            this.textSurname.Size = new System.Drawing.Size(131, 20);
            this.textSurname.TabIndex = 159;
            this.textSurname.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textSurname.TextChanged += new System.EventHandler(this.textSurname_TextChanged);
            // 
            // textFirstName
            // 
            this.textFirstName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.refereeBindingSource, "firstname", true));
            this.textFirstName.Location = new System.Drawing.Point(98, 42);
            this.textFirstName.Name = "textFirstName";
            this.textFirstName.Size = new System.Drawing.Size(131, 20);
            this.textFirstName.TabIndex = 157;
            this.textFirstName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textFirstName.TextChanged += new System.EventHandler(this.textFirstName_TextChanged);
            // 
            // comboCountry
            // 
            this.comboCountry.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.refereeBindingSource, "Country", true));
            this.comboCountry.DataSource = this.countryListBindingSource;
            this.comboCountry.ItemHeight = 13;
            this.comboCountry.Location = new System.Drawing.Point(97, 120);
            this.comboCountry.MaxLength = 32767;
            this.comboCountry.Name = "comboCountry";
            this.comboCountry.Size = new System.Drawing.Size(131, 21);
            this.comboCountry.TabIndex = 162;
            // 
            // countryListBindingSource
            // 
            this.countryListBindingSource.DataSource = typeof(FifaLibrary.CountryList);
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelFirstName.Location = new System.Drawing.Point(7, 45);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(57, 13);
            this.labelFirstName.TabIndex = 158;
            this.labelFirstName.Text = "First Name";
            this.labelFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSurame
            // 
            this.labelSurame.AutoSize = true;
            this.labelSurame.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelSurame.Location = new System.Drawing.Point(6, 71);
            this.labelSurame.Name = "labelSurame";
            this.labelSurame.Size = new System.Drawing.Size(58, 13);
            this.labelSurame.TabIndex = 160;
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
            this.labelCountry.Location = new System.Drawing.Point(7, 119);
            this.labelCountry.Name = "labelCountry";
            this.labelCountry.Size = new System.Drawing.Size(43, 13);
            this.labelCountry.TabIndex = 164;
            this.labelCountry.Text = "Country";
            this.labelCountry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelCountry.DoubleClick += new System.EventHandler(this.labelCountry_DoubleClick);
            // 
            // groupLeagues
            // 
            this.groupLeagues.Controls.Add(this.comboLeague4);
            this.groupLeagues.Controls.Add(this.comboLeague7);
            this.groupLeagues.Controls.Add(this.comboLeague5);
            this.groupLeagues.Controls.Add(this.comboLeague6);
            this.groupLeagues.Controls.Add(this.comboLeague0);
            this.groupLeagues.Controls.Add(this.comboLeague3);
            this.groupLeagues.Controls.Add(this.comboLeague1);
            this.groupLeagues.Controls.Add(this.comboLeague2);
            this.groupLeagues.Location = new System.Drawing.Point(3, 310);
            this.groupLeagues.Name = "groupLeagues";
            this.groupLeagues.Size = new System.Drawing.Size(512, 134);
            this.groupLeagues.TabIndex = 192;
            this.groupLeagues.TabStop = false;
            this.groupLeagues.Text = "Leagues";
            // 
            // comboLeague4
            // 
            this.comboLeague4.FormattingEnabled = true;
            this.comboLeague4.Location = new System.Drawing.Point(264, 19);
            this.comboLeague4.Name = "comboLeague4";
            this.comboLeague4.Size = new System.Drawing.Size(204, 21);
            this.comboLeague4.TabIndex = 192;
            this.comboLeague4.SelectedIndexChanged += new System.EventHandler(this.comboLeague4_SelectedIndexChanged);
            // 
            // comboLeague7
            // 
            this.comboLeague7.FormattingEnabled = true;
            this.comboLeague7.Location = new System.Drawing.Point(264, 99);
            this.comboLeague7.Name = "comboLeague7";
            this.comboLeague7.Size = new System.Drawing.Size(204, 21);
            this.comboLeague7.TabIndex = 195;
            this.comboLeague7.SelectedIndexChanged += new System.EventHandler(this.comboLeague7_SelectedIndexChanged);
            // 
            // comboLeague5
            // 
            this.comboLeague5.FormattingEnabled = true;
            this.comboLeague5.Location = new System.Drawing.Point(264, 46);
            this.comboLeague5.Name = "comboLeague5";
            this.comboLeague5.Size = new System.Drawing.Size(204, 21);
            this.comboLeague5.TabIndex = 193;
            this.comboLeague5.SelectedIndexChanged += new System.EventHandler(this.comboLeague5_SelectedIndexChanged);
            // 
            // comboLeague6
            // 
            this.comboLeague6.FormattingEnabled = true;
            this.comboLeague6.Location = new System.Drawing.Point(264, 73);
            this.comboLeague6.Name = "comboLeague6";
            this.comboLeague6.Size = new System.Drawing.Size(204, 21);
            this.comboLeague6.TabIndex = 194;
            this.comboLeague6.SelectedIndexChanged += new System.EventHandler(this.comboLeague6_SelectedIndexChanged);
            // 
            // comboLeague0
            // 
            this.comboLeague0.FormattingEnabled = true;
            this.comboLeague0.Location = new System.Drawing.Point(9, 19);
            this.comboLeague0.Name = "comboLeague0";
            this.comboLeague0.Size = new System.Drawing.Size(204, 21);
            this.comboLeague0.TabIndex = 183;
            this.comboLeague0.SelectedIndexChanged += new System.EventHandler(this.comboLeague0_SelectedIndexChanged);
            // 
            // comboLeague3
            // 
            this.comboLeague3.FormattingEnabled = true;
            this.comboLeague3.Location = new System.Drawing.Point(9, 99);
            this.comboLeague3.Name = "comboLeague3";
            this.comboLeague3.Size = new System.Drawing.Size(204, 21);
            this.comboLeague3.TabIndex = 191;
            this.comboLeague3.SelectedIndexChanged += new System.EventHandler(this.comboLeague3_SelectedIndexChanged);
            // 
            // comboLeague1
            // 
            this.comboLeague1.FormattingEnabled = true;
            this.comboLeague1.Location = new System.Drawing.Point(9, 46);
            this.comboLeague1.Name = "comboLeague1";
            this.comboLeague1.Size = new System.Drawing.Size(204, 21);
            this.comboLeague1.TabIndex = 189;
            this.comboLeague1.SelectedIndexChanged += new System.EventHandler(this.comboLeague1_SelectedIndexChanged);
            // 
            // comboLeague2
            // 
            this.comboLeague2.FormattingEnabled = true;
            this.comboLeague2.Location = new System.Drawing.Point(9, 73);
            this.comboLeague2.Name = "comboLeague2";
            this.comboLeague2.Size = new System.Drawing.Size(204, 21);
            this.comboLeague2.TabIndex = 190;
            this.comboLeague2.SelectedIndexChanged += new System.EventHandler(this.comboLeague2_SelectedIndexChanged);
            // 
            // viewer2DPlayerGui
            // 
            this.viewer2DPlayerGui.AutoTransparency = true;
            this.viewer2DPlayerGui.BackColor = System.Drawing.Color.Transparent;
            this.viewer2DPlayerGui.ButtonStripVisible = true;
            this.viewer2DPlayerGui.CurrentBitmap = null;
            this.viewer2DPlayerGui.ExtendedFormat = false;
            this.viewer2DPlayerGui.FullSizeButton = false;
            this.viewer2DPlayerGui.ImageLayout = System.Windows.Forms.ImageLayout.None;
            this.viewer2DPlayerGui.ImageSize = new System.Drawing.Size(256, 256);
            this.viewer2DPlayerGui.ImageSizeMultiplier = FifaControls.Viewer2D.SizeMultiplier.None;
            this.viewer2DPlayerGui.Location = new System.Drawing.Point(3, 450);
            this.viewer2DPlayerGui.Name = "viewer2DPlayerGui";
            this.viewer2DPlayerGui.RemoveButton = false;
            this.viewer2DPlayerGui.ShowButton = false;
            this.viewer2DPlayerGui.ShowButtonChecked = true;
            this.viewer2DPlayerGui.Size = new System.Drawing.Size(256, 225);
            this.viewer2DPlayerGui.TabIndex = 193;
            // 
            // splitContainer2
            // 
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
            this.splitContainer2.Size = new System.Drawing.Size(826, 807);
            this.splitContainer2.SplitterDistance = 483;
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
            this.viewer3D.ObjectType = FifaControls.FbxViewer3D.ObjectTypeServerPort.Referee;
            this.viewer3D.Size = new System.Drawing.Size(826, 458);
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
            this.toolPhoto});
            this.tool3D.Location = new System.Drawing.Point(0, 458);
            this.tool3D.Name = "tool3D";
            this.tool3D.Size = new System.Drawing.Size(826, 25);
            this.tool3D.TabIndex = 6;
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
            // groupGenericFace
            // 
            this.groupGenericFace.Controls.Add(this.groupTextureInfo);
            this.groupGenericFace.Controls.Add(this.groupHairModel);
            this.groupGenericFace.Controls.Add(this.groupHeadModel);
            this.groupGenericFace.Controls.Add(this.labelHeadType);
            this.groupGenericFace.Controls.Add(this.labelHairType);
            this.groupGenericFace.Location = new System.Drawing.Point(3, 3);
            this.groupGenericFace.Name = "groupGenericFace";
            this.groupGenericFace.Size = new System.Drawing.Size(590, 246);
            this.groupGenericFace.TabIndex = 87;
            this.groupGenericFace.TabStop = false;
            this.groupGenericFace.Text = "Face Modelling";
            // 
            // groupTextureInfo
            // 
            this.groupTextureInfo.Controls.Add(this.comboSkinColor);
            this.groupTextureInfo.Controls.Add(this.labelFacialHair);
            this.groupTextureInfo.Controls.Add(this.labelEyeBow);
            this.groupTextureInfo.Controls.Add(this.domainFacialHair);
            this.groupTextureInfo.Controls.Add(this.comboEyeBow);
            this.groupTextureInfo.Controls.Add(this.labelSideburns);
            this.groupTextureInfo.Controls.Add(this.comboSideburns);
            this.groupTextureInfo.Controls.Add(this.labelSkintype);
            this.groupTextureInfo.Controls.Add(this.comboEyescolor);
            this.groupTextureInfo.Controls.Add(this.comboSkintype);
            this.groupTextureInfo.Controls.Add(this.label2);
            this.groupTextureInfo.Controls.Add(this.label1);
            this.groupTextureInfo.Controls.Add(this.comboFacialHairColor);
            this.groupTextureInfo.Controls.Add(this.labelFacialHairColor);
            this.groupTextureInfo.Location = new System.Drawing.Point(381, 19);
            this.groupTextureInfo.Name = "groupTextureInfo";
            this.groupTextureInfo.Size = new System.Drawing.Size(200, 217);
            this.groupTextureInfo.TabIndex = 35;
            this.groupTextureInfo.TabStop = false;
            this.groupTextureInfo.Text = "Face Type";
            // 
            // comboSkinColor
            // 
            this.comboSkinColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSkinColor.FormattingEnabled = true;
            this.comboSkinColor.Items.AddRange(new object[] {
            "1 = unused",
            "Pink",
            "3 = unused",
            "Llight Yellow",
            "Medium Yellow",
            "Dark Yellow",
            "7 = unused",
            "Light Brown",
            "Medium Brown",
            "Dark brown"});
            this.comboSkinColor.Location = new System.Drawing.Point(77, 22);
            this.comboSkinColor.Name = "comboSkinColor";
            this.comboSkinColor.Size = new System.Drawing.Size(111, 21);
            this.comboSkinColor.TabIndex = 20;
            this.comboSkinColor.SelectedIndexChanged += new System.EventHandler(this.comboSkinColor_SelectedIndexChanged);
            // 
            // labelFacialHair
            // 
            this.labelFacialHair.AutoSize = true;
            this.labelFacialHair.BackColor = System.Drawing.SystemColors.Control;
            this.labelFacialHair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelFacialHair.Location = new System.Drawing.Point(6, 136);
            this.labelFacialHair.Name = "labelFacialHair";
            this.labelFacialHair.Size = new System.Drawing.Size(57, 13);
            this.labelFacialHair.TabIndex = 15;
            this.labelFacialHair.Text = "Facial Hair";
            this.labelFacialHair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelEyeBow
            // 
            this.labelEyeBow.AutoSize = true;
            this.labelEyeBow.BackColor = System.Drawing.SystemColors.Control;
            this.labelEyeBow.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelEyeBow.Location = new System.Drawing.Point(6, 108);
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
            this.domainFacialHair.Location = new System.Drawing.Point(77, 133);
            this.domainFacialHair.Name = "domainFacialHair";
            this.domainFacialHair.Size = new System.Drawing.Size(111, 21);
            this.domainFacialHair.TabIndex = 16;
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
            this.comboEyeBow.Location = new System.Drawing.Point(77, 105);
            this.comboEyeBow.Name = "comboEyeBow";
            this.comboEyeBow.Size = new System.Drawing.Size(111, 21);
            this.comboEyeBow.TabIndex = 32;
            this.comboEyeBow.SelectedIndexChanged += new System.EventHandler(this.comboEyeBow_SelectedIndexChanged);
            // 
            // labelSideburns
            // 
            this.labelSideburns.AutoSize = true;
            this.labelSideburns.BackColor = System.Drawing.SystemColors.Control;
            this.labelSideburns.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelSideburns.Location = new System.Drawing.Point(6, 192);
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
            this.comboSideburns.Location = new System.Drawing.Point(77, 189);
            this.comboSideburns.Name = "comboSideburns";
            this.comboSideburns.Size = new System.Drawing.Size(111, 21);
            this.comboSideburns.TabIndex = 24;
            this.comboSideburns.SelectedIndexChanged += new System.EventHandler(this.comboSideburns_SelectedIndexChanged);
            // 
            // labelSkintype
            // 
            this.labelSkintype.AutoSize = true;
            this.labelSkintype.BackColor = System.Drawing.SystemColors.Control;
            this.labelSkintype.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelSkintype.Location = new System.Drawing.Point(6, 52);
            this.labelSkintype.Name = "labelSkintype";
            this.labelSkintype.Size = new System.Drawing.Size(55, 13);
            this.labelSkintype.TabIndex = 21;
            this.labelSkintype.Text = "Skin Type";
            this.labelSkintype.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            "Dark Green",
            "Gray",
            "Light Green"});
            this.comboEyescolor.Location = new System.Drawing.Point(77, 77);
            this.comboEyescolor.Name = "comboEyescolor";
            this.comboEyescolor.Size = new System.Drawing.Size(111, 21);
            this.comboEyescolor.TabIndex = 26;
            this.comboEyescolor.SelectedIndexChanged += new System.EventHandler(this.comboEyescolor_SelectedIndexChanged);
            // 
            // comboSkintype
            // 
            this.comboSkintype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSkintype.FormattingEnabled = true;
            this.comboSkintype.Items.AddRange(new object[] {
            "Clean",
            "Freckled",
            "Rough"});
            this.comboSkintype.Location = new System.Drawing.Point(77, 49);
            this.comboSkintype.Name = "comboSkintype";
            this.comboSkintype.Size = new System.Drawing.Size(111, 21);
            this.comboSkintype.TabIndex = 22;
            this.comboSkintype.SelectedIndexChanged += new System.EventHandler(this.comboSkintype_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(6, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Eyes Color";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Skin Color";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.comboFacialHairColor.Location = new System.Drawing.Point(77, 161);
            this.comboFacialHairColor.Name = "comboFacialHairColor";
            this.comboFacialHairColor.Size = new System.Drawing.Size(111, 21);
            this.comboFacialHairColor.TabIndex = 18;
            this.comboFacialHairColor.SelectedIndexChanged += new System.EventHandler(this.comboFacialHairColor_SelectedIndexChanged);
            // 
            // labelFacialHairColor
            // 
            this.labelFacialHairColor.AutoSize = true;
            this.labelFacialHairColor.BackColor = System.Drawing.SystemColors.Control;
            this.labelFacialHairColor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelFacialHairColor.Location = new System.Drawing.Point(6, 164);
            this.labelFacialHairColor.Name = "labelFacialHairColor";
            this.labelFacialHairColor.Size = new System.Drawing.Size(31, 13);
            this.labelFacialHairColor.TabIndex = 17;
            this.labelFacialHairColor.Text = "Color";
            this.labelFacialHairColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupHairModel
            // 
            this.groupHairModel.Controls.Add(this.comboHeadband);
            this.groupHairModel.Controls.Add(this.comboAfro);
            this.groupHairModel.Controls.Add(this.comboLong);
            this.groupHairModel.Controls.Add(this.comboMedium);
            this.groupHairModel.Controls.Add(this.comboModern);
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
            this.groupHairModel.Controls.Add(this.domainHairColor);
            this.groupHairModel.Controls.Add(this.labelHairColor);
            this.groupHairModel.Location = new System.Drawing.Point(6, 104);
            this.groupHairModel.Name = "groupHairModel";
            this.groupHairModel.Size = new System.Drawing.Size(364, 132);
            this.groupHairModel.TabIndex = 29;
            this.groupHairModel.TabStop = false;
            this.groupHairModel.Text = "Hair Model";
            // 
            // comboHeadband
            // 
            this.comboHeadband.FormattingEnabled = true;
            this.comboHeadband.Items.AddRange(new object[] {
            "55",
            "56",
            "76",
            "81",
            "49",
            "91"});
            this.comboHeadband.Location = new System.Drawing.Point(6, 76);
            this.comboHeadband.Name = "comboHeadband";
            this.comboHeadband.Size = new System.Drawing.Size(260, 21);
            this.comboHeadband.TabIndex = 30;
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
            this.comboAfro.Location = new System.Drawing.Point(6, 76);
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
            this.comboLong.Location = new System.Drawing.Point(6, 76);
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
            this.comboMedium.Location = new System.Drawing.Point(6, 76);
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
            this.comboModern.Location = new System.Drawing.Point(6, 76);
            this.comboModern.Name = "comboModern";
            this.comboModern.Size = new System.Drawing.Size(260, 21);
            this.comboModern.TabIndex = 26;
            this.comboModern.Visible = false;
            this.comboModern.SelectedIndexChanged += new System.EventHandler(this.comboModern_SelectedIndexChanged);
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
            this.comboShort.Location = new System.Drawing.Point(6, 76);
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
            this.comboVeryShort.Location = new System.Drawing.Point(6, 76);
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
            this.comboShaven.Location = new System.Drawing.Point(6, 76);
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
            // domainHairColor
            // 
            this.domainHairColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.domainHairColor.FormattingEnabled = true;
            this.domainHairColor.Items.AddRange(new object[] {
            "Blonde",
            "Black",
            "Dark Blonde",
            "Dark Brown",
            "Light Blonde",
            "Light Brown",
            "Brown",
            "Red",
            "White",
            "Gray",
            "Green",
            "Violet"});
            this.domainHairColor.Location = new System.Drawing.Point(155, 102);
            this.domainHairColor.Name = "domainHairColor";
            this.domainHairColor.Size = new System.Drawing.Size(111, 21);
            this.domainHairColor.TabIndex = 14;
            this.domainHairColor.SelectedIndexChanged += new System.EventHandler(this.domainHairColor_SelectedIndexChanged);
            // 
            // labelHairColor
            // 
            this.labelHairColor.BackColor = System.Drawing.SystemColors.Control;
            this.labelHairColor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelHairColor.Location = new System.Drawing.Point(6, 101);
            this.labelHairColor.Name = "labelHairColor";
            this.labelHairColor.Size = new System.Drawing.Size(103, 20);
            this.labelHairColor.TabIndex = 13;
            this.labelHairColor.Text = "Hair Color";
            this.labelHairColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.groupHeadModel.Location = new System.Drawing.Point(6, 19);
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
            this.comboLatinModels.TabIndex = 3;
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
            this.buttonRandomizeAppearance.Location = new System.Drawing.Point(272, 18);
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
            this.labelHeadType.Location = new System.Drawing.Point(185, 112);
            this.labelHeadType.Name = "labelHeadType";
            this.labelHeadType.Size = new System.Drawing.Size(127, 20);
            this.labelHeadType.TabIndex = 11;
            this.labelHeadType.Text = "Head Model";
            this.labelHeadType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHairType
            // 
            this.labelHairType.BackColor = System.Drawing.SystemColors.Control;
            this.labelHairType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelHairType.Location = new System.Drawing.Point(16, 184);
            this.labelHairType.Name = "labelHairType";
            this.labelHairType.Size = new System.Drawing.Size(119, 20);
            this.labelHairType.TabIndex = 9;
            this.labelHairType.Text = "Hair Model";
            this.labelHairType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
        "by Country",
        "by League"};
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
            this.pickUpControl.TabIndex = 1;
            this.pickUpControl.WizardButtonEnabled = false;
            this.pickUpControl.YoungPlayersEnabled = false;
            // 
            // RefereeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1357, 832);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pickUpControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RefereeForm";
            this.Text = "RefereeForm";
            this.Load += new System.EventHandler(this.RefereeForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupIdentity.ResumeLayout(false);
            this.groupIdentity.PerformLayout();
            this.groupShoes.ResumeLayout(false);
            this.groupShoes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureColorShoes2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refereeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureColorShoes1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericShoesBrand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericShoesDesign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRefereeId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryListBindingSource)).EndInit();
            this.groupLeagues.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tool3D.ResumeLayout(false);
            this.tool3D.PerformLayout();
            this.groupGenericFace.ResumeLayout(false);
            this.groupTextureInfo.ResumeLayout(false);
            this.groupTextureInfo.PerformLayout();
            this.groupHairModel.ResumeLayout(false);
            this.groupHeadModel.ResumeLayout(false);
            this.ResumeLayout(false);

    }
  }
}
