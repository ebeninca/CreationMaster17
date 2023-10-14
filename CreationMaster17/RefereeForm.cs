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
      this.components = (IContainer)new Container();
      ComponentResourceManager resources = new ComponentResourceManager(typeof(RefereeForm));
      this.splitContainer1 = new SplitContainer();
      this.flowLayoutPanel1 = new FlowLayoutPanel();
      this.groupIdentity = new GroupBox();
      this.groupShoes = new GroupBox();
      this.label1ShoesType = new Label();
      this.pictureColorShoes2 = new PictureBox();
      this.refereeBindingSource = new BindingSource(this.components);
      this.pictureColorShoes1 = new PictureBox();
      this.numericShoesBrand = new NumericUpDown();
      this.labelShoesType = new Label();
      this.labelShoesColor = new Label();
      this.numericShoesDesign = new NumericUpDown();
      this.viewer2DShoes = new Viewer2D();
      this.labelShoes = new Label();
      this.comboBox1 = new ComboBox();
      this.label3 = new Label();
      this.comboStyle = new ComboBox();
      this.labelStyle = new Label();
      this.domainSleeves = new DomainUpDown();
      this.labelSleeves = new Label();
      this.comboBody = new ComboBox();
      this.numericHeight = new NumericUpDown();
      this.numericWeight = new NumericUpDown();
      this.labelWeight = new Label();
      this.labelBody = new Label();
      this.labelHeight = new Label();
      this.buttonGetId = new Button();
      this.numericRefereeId = new NumericUpDown();
      this.buttonRandomizeIdentity = new Button();
      this.dateBirthDate = new DateTimePicker();
      this.labelBirthdate = new Label();
      this.labelRefereeId = new Label();
      this.textSurname = new TextBox();
      this.textFirstName = new TextBox();
      this.comboCountry = new ComboBox();
      this.countryListBindingSource = new BindingSource(this.components);
      this.labelFirstName = new Label();
      this.labelSurame = new Label();
      this.labelCountry = new Label();
      this.groupLeagues = new GroupBox();
      this.comboLeague4 = new ComboBox();
      this.comboLeague7 = new ComboBox();
      this.comboLeague5 = new ComboBox();
      this.comboLeague6 = new ComboBox();
      this.comboLeague0 = new ComboBox();
      this.comboLeague3 = new ComboBox();
      this.comboLeague1 = new ComboBox();
      this.comboLeague2 = new ComboBox();
      this.viewer2DPlayerGui = new Viewer2D();
      this.splitContainer2 = new SplitContainer();
      this.viewer3D = new FbxViewer3D();
      this.tool3D = new ToolStrip();
      this.buttonShow3DModel = new ToolStripButton();
      this.buttonSwitchRenderingMode = new ToolStripButton();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.toolPhoto = new ToolStripButton();
      this.groupGenericFace = new GroupBox();
      this.groupTextureInfo = new GroupBox();
      this.comboSkinColor = new ComboBox();
      this.labelFacialHair = new Label();
      this.labelEyeBow = new Label();
      this.domainFacialHair = new ComboBox();
      this.comboEyeBow = new ComboBox();
      this.labelSideburns = new Label();
      this.comboSideburns = new ComboBox();
      this.labelSkintype = new Label();
      this.comboEyescolor = new ComboBox();
      this.comboSkintype = new ComboBox();
      this.label2 = new Label();
      this.label1 = new Label();
      this.comboFacialHairColor = new ComboBox();
      this.labelFacialHairColor = new Label();
      this.groupHairModel = new GroupBox();
      this.comboHeadband = new ComboBox();
      this.comboAfro = new ComboBox();
      this.comboLong = new ComboBox();
      this.comboMedium = new ComboBox();
      this.comboModern = new ComboBox();
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
      this.domainHairColor = new ComboBox();
      this.labelHairColor = new Label();
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
      this.labelHairType = new Label();
      this.pickUpControl = new PickUpControl();
      this.splitContainer1.BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.flowLayoutPanel1.SuspendLayout();
      this.groupIdentity.SuspendLayout();
      this.groupShoes.SuspendLayout();
      ((ISupportInitialize)this.pictureColorShoes2).BeginInit();
      ((ISupportInitialize)this.refereeBindingSource).BeginInit();
      ((ISupportInitialize)this.pictureColorShoes1).BeginInit();
      this.numericShoesBrand.BeginInit();
      this.numericShoesDesign.BeginInit();
      this.numericHeight.BeginInit();
      this.numericWeight.BeginInit();
      this.numericRefereeId.BeginInit();
      ((ISupportInitialize)this.countryListBindingSource).BeginInit();
      this.groupLeagues.SuspendLayout();
      this.splitContainer2.BeginInit();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      this.tool3D.SuspendLayout();
      this.groupGenericFace.SuspendLayout();
      this.groupTextureInfo.SuspendLayout();
      this.groupHairModel.SuspendLayout();
      this.groupHeadModel.SuspendLayout();
      this.SuspendLayout();
      this.splitContainer1.Dock = DockStyle.Fill;
      this.splitContainer1.Location = new Point(0, 25);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Panel1.AutoScroll = true;
      this.splitContainer1.Panel1.Controls.Add((Control)this.flowLayoutPanel1);
      this.splitContainer1.Panel2.Controls.Add((Control)this.splitContainer2);
      this.splitContainer1.Size = new Size(1357, 807);
      this.splitContainer1.SplitterDistance = 527;
      this.splitContainer1.TabIndex = 2;
      this.flowLayoutPanel1.Controls.Add((Control)this.groupIdentity);
      this.flowLayoutPanel1.Controls.Add((Control)this.groupLeagues);
      this.flowLayoutPanel1.Controls.Add((Control)this.viewer2DPlayerGui);
      this.flowLayoutPanel1.Dock = DockStyle.Fill;
      this.flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
      this.flowLayoutPanel1.Location = new Point(0, 0);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new Size(527, 807);
      this.flowLayoutPanel1.TabIndex = 0;
      this.groupIdentity.Controls.Add((Control)this.groupShoes);
      this.groupIdentity.Controls.Add((Control)this.comboBox1);
      this.groupIdentity.Controls.Add((Control)this.label3);
      this.groupIdentity.Controls.Add((Control)this.comboStyle);
      this.groupIdentity.Controls.Add((Control)this.labelStyle);
      this.groupIdentity.Controls.Add((Control)this.domainSleeves);
      this.groupIdentity.Controls.Add((Control)this.labelSleeves);
      this.groupIdentity.Controls.Add((Control)this.comboBody);
      this.groupIdentity.Controls.Add((Control)this.numericHeight);
      this.groupIdentity.Controls.Add((Control)this.numericWeight);
      this.groupIdentity.Controls.Add((Control)this.labelWeight);
      this.groupIdentity.Controls.Add((Control)this.labelBody);
      this.groupIdentity.Controls.Add((Control)this.labelHeight);
      this.groupIdentity.Controls.Add((Control)this.buttonGetId);
      this.groupIdentity.Controls.Add((Control)this.numericRefereeId);
      this.groupIdentity.Controls.Add((Control)this.buttonRandomizeIdentity);
      this.groupIdentity.Controls.Add((Control)this.dateBirthDate);
      this.groupIdentity.Controls.Add((Control)this.labelBirthdate);
      this.groupIdentity.Controls.Add((Control)this.labelRefereeId);
      this.groupIdentity.Controls.Add((Control)this.textSurname);
      this.groupIdentity.Controls.Add((Control)this.textFirstName);
      this.groupIdentity.Controls.Add((Control)this.comboCountry);
      this.groupIdentity.Controls.Add((Control)this.labelFirstName);
      this.groupIdentity.Controls.Add((Control)this.labelSurame);
      this.groupIdentity.Controls.Add((Control)this.labelCountry);
      this.groupIdentity.Location = new Point(3, 3);
      this.groupIdentity.Name = "groupIdentity";
      this.groupIdentity.Size = new Size(512, 301);
      this.groupIdentity.TabIndex = 0;
      this.groupIdentity.TabStop = false;
      this.groupIdentity.Text = "Identity";
      this.groupShoes.Controls.Add((Control)this.label1ShoesType);
      this.groupShoes.Controls.Add((Control)this.pictureColorShoes2);
      this.groupShoes.Controls.Add((Control)this.pictureColorShoes1);
      this.groupShoes.Controls.Add((Control)this.numericShoesBrand);
      this.groupShoes.Controls.Add((Control)this.labelShoesType);
      this.groupShoes.Controls.Add((Control)this.labelShoesColor);
      this.groupShoes.Controls.Add((Control)this.numericShoesDesign);
      this.groupShoes.Controls.Add((Control)this.viewer2DShoes);
      this.groupShoes.Controls.Add((Control)this.labelShoes);
      this.groupShoes.Location = new Point(251, 15);
      this.groupShoes.Name = "groupShoes";
      this.groupShoes.Size = new Size(243, 178);
      this.groupShoes.TabIndex = 189;
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
      this.pictureColorShoes2.DataBindings.Add(new Binding("BackColor", (object)this.refereeBindingSource, "shoecolorcode2", true));
      this.pictureColorShoes2.ImeMode = ImeMode.NoControl;
      this.pictureColorShoes2.Location = new Point(72, 131);
      this.pictureColorShoes2.Name = "pictureColorShoes2";
      this.pictureColorShoes2.Size = new Size(20, 20);
      this.pictureColorShoes2.TabIndex = 63;
      this.pictureColorShoes2.TabStop = false;
      this.pictureColorShoes2.Click += new EventHandler(this.pictureColorShoes2_Click);
      this.refereeBindingSource.DataSource = (object)typeof(Referee);
      this.pictureColorShoes1.BorderStyle = BorderStyle.FixedSingle;
      this.pictureColorShoes1.Cursor = Cursors.Hand;
      this.pictureColorShoes1.DataBindings.Add(new Binding("BackColor", (object)this.refereeBindingSource, "shoecolorcode1", true));
      this.pictureColorShoes1.ImeMode = ImeMode.NoControl;
      this.pictureColorShoes1.Location = new Point(12, 131);
      this.pictureColorShoes1.Name = "pictureColorShoes1";
      this.pictureColorShoes1.Size = new Size(20, 20);
      this.pictureColorShoes1.TabIndex = 62;
      this.pictureColorShoes1.TabStop = false;
      this.pictureColorShoes1.Click += new EventHandler(this.pictureColorShoes1_Click);
      this.numericShoesBrand.DataBindings.Add(new Binding("Value", (object)this.refereeBindingSource, "shoetypecode", true));
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
      this.numericShoesDesign.DataBindings.Add(new Binding("Value", (object)this.refereeBindingSource, "shoedesigncode", true));
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
      this.comboBox1.DataBindings.Add(new Binding("SelectedIndex", (object)this.refereeBindingSource, "cardstrictness", true));
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[3]
      {
        (object) "Tolerant",
        (object) "Balanced",
        (object) "Easy Card"
      });
      this.comboBox1.Location = new Point(95, 253);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(132, 21);
      this.comboBox1.TabIndex = 188;
      this.label3.AutoSize = true;
      this.label3.ImeMode = ImeMode.NoControl;
      this.label3.Location = new Point(9, 256);
      this.label3.Name = "label3";
      this.label3.Size = new Size(60, 13);
      this.label3.TabIndex = 187;
      this.label3.Text = "Cards Style";
      this.label3.TextAlign = ContentAlignment.MiddleLeft;
      this.comboStyle.DataBindings.Add(new Binding("SelectedIndex", (object)this.refereeBindingSource, "foulstrictness", true));
      this.comboStyle.FormattingEnabled = true;
      this.comboStyle.Items.AddRange(new object[3]
      {
        (object) "Let Play",
        (object) "Balanced",
        (object) "Easy Whistle"
      });
      this.comboStyle.Location = new Point(96, 226);
      this.comboStyle.Name = "comboStyle";
      this.comboStyle.Size = new Size(132, 21);
      this.comboStyle.TabIndex = 186;
      this.labelStyle.AutoSize = true;
      this.labelStyle.ImeMode = ImeMode.NoControl;
      this.labelStyle.Location = new Point(9, 229);
      this.labelStyle.Name = "labelStyle";
      this.labelStyle.Size = new Size(58, 13);
      this.labelStyle.TabIndex = 185;
      this.labelStyle.Text = "Fouls Style";
      this.labelStyle.TextAlign = ContentAlignment.MiddleLeft;
      this.domainSleeves.DataBindings.Add(new Binding("SelectedIndex", (object)this.refereeBindingSource, "jerseysleevelengthcode", true));
      this.domainSleeves.Items.Add((object)"Short");
      this.domainSleeves.Items.Add((object)"Long");
      this.domainSleeves.Location = new Point(362, 242);
      this.domainSleeves.Name = "domainSleeves";
      this.domainSleeves.Size = new Size(132, 20);
      this.domainSleeves.TabIndex = 175;
      this.domainSleeves.TextAlign = HorizontalAlignment.Center;
      this.domainSleeves.Wrap = true;
      this.labelSleeves.AutoSize = true;
      this.labelSleeves.BackColor = Color.Transparent;
      this.labelSleeves.ImeMode = ImeMode.NoControl;
      this.labelSleeves.Location = new Point(261, 244);
      this.labelSleeves.Name = "labelSleeves";
      this.labelSleeves.Size = new Size(81, 13);
      this.labelSleeves.TabIndex = 176;
      this.labelSleeves.Text = "Sleeves Length";
      this.labelSleeves.TextAlign = ContentAlignment.MiddleLeft;
      this.comboBody.DataBindings.Add(new Binding("SelectedIndex", (object)this.refereeBindingSource, "bodytypecode", true));
      this.comboBody.FormattingEnabled = true;
      this.comboBody.Items.AddRange(new object[3]
      {
        (object) "Small",
        (object) "Normal",
        (object) "Big"
      });
      this.comboBody.Location = new Point(97, 199);
      this.comboBody.Name = "comboBody";
      this.comboBody.Size = new Size(132, 21);
      this.comboBody.TabIndex = 174;
      this.numericHeight.DataBindings.Add(new Binding("Value", (object)this.refereeBindingSource, "height", true));
      this.numericHeight.Location = new Point(97, 147);
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
      this.numericHeight.Size = new Size(132, 20);
      this.numericHeight.TabIndex = 169;
      this.numericHeight.TextAlign = HorizontalAlignment.Center;
      this.numericHeight.Value = new Decimal(new int[4]
      {
        150,
        0,
        0,
        0
      });
      this.numericWeight.DataBindings.Add(new Binding("Value", (object)this.refereeBindingSource, "weight", true));
      this.numericWeight.Location = new Point(97, 173);
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
      this.numericWeight.Size = new Size(132, 20);
      this.numericWeight.TabIndex = 170;
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
      this.labelWeight.Location = new Point(7, 175);
      this.labelWeight.Name = "labelWeight";
      this.labelWeight.Size = new Size(41, 13);
      this.labelWeight.TabIndex = 172;
      this.labelWeight.Text = "Weight";
      this.labelWeight.TextAlign = ContentAlignment.MiddleLeft;
      this.labelBody.AutoSize = true;
      this.labelBody.BackColor = Color.Transparent;
      this.labelBody.ImeMode = ImeMode.NoControl;
      this.labelBody.Location = new Point(6, 202);
      this.labelBody.Name = "labelBody";
      this.labelBody.Size = new Size(31, 13);
      this.labelBody.TabIndex = 173;
      this.labelBody.Text = "Body";
      this.labelBody.TextAlign = ContentAlignment.MiddleLeft;
      this.labelHeight.AutoSize = true;
      this.labelHeight.BackColor = Color.Transparent;
      this.labelHeight.ImeMode = ImeMode.NoControl;
      this.labelHeight.Location = new Point(6, 149);
      this.labelHeight.Name = "labelHeight";
      this.labelHeight.Size = new Size(38, 13);
      this.labelHeight.TabIndex = 171;
      this.labelHeight.Text = "Height";
      this.labelHeight.TextAlign = ContentAlignment.MiddleLeft;
      this.buttonGetId.Location = new Point(204, 17);
      this.buttonGetId.Name = "buttonGetId";
      this.buttonGetId.Size = new Size(24, 20);
      this.buttonGetId.TabIndex = 168;
      this.buttonGetId.Text = "...";
      this.buttonGetId.UseVisualStyleBackColor = true;
      this.buttonGetId.Click += new EventHandler(this.buttonGetId_Click);
      this.numericRefereeId.Location = new Point(98, 17);
      this.numericRefereeId.Maximum = new Decimal(new int[4]
      {
        600000,
        0,
        0,
        0
      });
      this.numericRefereeId.Name = "numericRefereeId";
      this.numericRefereeId.Size = new Size(91, 20);
      this.numericRefereeId.TabIndex = 167;
      this.numericRefereeId.TextAlign = HorizontalAlignment.Center;
      this.numericRefereeId.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericRefereeId.ValueChanged += new EventHandler(this.numericRefereeId_ValueChanged);
      this.buttonRandomizeIdentity.ImeMode = ImeMode.NoControl;
      this.buttonRandomizeIdentity.Location = new Point(264, 268);
      this.buttonRandomizeIdentity.Name = "buttonRandomizeIdentity";
      this.buttonRandomizeIdentity.Size = new Size(230, 23);
      this.buttonRandomizeIdentity.TabIndex = 166;
      this.buttonRandomizeIdentity.Text = "Randomize";
      this.buttonRandomizeIdentity.UseVisualStyleBackColor = true;
      this.buttonRandomizeIdentity.Visible = false;
      this.buttonRandomizeIdentity.Click += new EventHandler(this.buttonRandomizeIdentity_Click);
      this.dateBirthDate.DataBindings.Add(new Binding("Value", (object)this.refereeBindingSource, "birthdate", true));
      this.dateBirthDate.Format = DateTimePickerFormat.Short;
      this.dateBirthDate.Location = new Point(97, 94);
      this.dateBirthDate.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
      this.dateBirthDate.MinDate = new DateTime(1800, 1, 1, 0, 0, 0, 0);
      this.dateBirthDate.Name = "dateBirthDate";
      this.dateBirthDate.Size = new Size(131, 20);
      this.dateBirthDate.TabIndex = 161;
      this.dateBirthDate.Value = new DateTime(2006, 12, 31, 0, 0, 0, 0);
      this.labelBirthdate.AutoSize = true;
      this.labelBirthdate.ImeMode = ImeMode.NoControl;
      this.labelBirthdate.Location = new Point(7, 98);
      this.labelBirthdate.Name = "labelBirthdate";
      this.labelBirthdate.Size = new Size(49, 13);
      this.labelBirthdate.TabIndex = 163;
      this.labelBirthdate.Text = "Birthdate";
      this.labelBirthdate.TextAlign = ContentAlignment.MiddleLeft;
      this.labelRefereeId.AutoSize = true;
      this.labelRefereeId.BackColor = Color.Transparent;
      this.labelRefereeId.ImeMode = ImeMode.NoControl;
      this.labelRefereeId.Location = new Point(7, 21);
      this.labelRefereeId.Name = "labelRefereeId";
      this.labelRefereeId.Size = new Size(57, 13);
      this.labelRefereeId.TabIndex = 165;
      this.labelRefereeId.Text = "Referee Id";
      this.labelRefereeId.TextAlign = ContentAlignment.MiddleLeft;
      this.textSurname.DataBindings.Add(new Binding("Text", (object)this.refereeBindingSource, "surname", true));
      this.textSurname.Location = new Point(97, 68);
      this.textSurname.Name = "textSurname";
      this.textSurname.Size = new Size(131, 20);
      this.textSurname.TabIndex = 159;
      this.textSurname.TextAlign = HorizontalAlignment.Right;
      this.textSurname.TextChanged += new EventHandler(this.textSurname_TextChanged);
      this.textFirstName.DataBindings.Add(new Binding("Text", (object)this.refereeBindingSource, "firstname", true));
      this.textFirstName.Location = new Point(98, 42);
      this.textFirstName.Name = "textFirstName";
      this.textFirstName.Size = new Size(131, 20);
      this.textFirstName.TabIndex = 157;
      this.textFirstName.TextAlign = HorizontalAlignment.Right;
      this.textFirstName.TextChanged += new EventHandler(this.textFirstName_TextChanged);
      this.comboCountry.DataBindings.Add(new Binding("SelectedItem", (object)this.refereeBindingSource, "Country", true));
      this.comboCountry.DataSource = (object)this.countryListBindingSource;
      this.comboCountry.ItemHeight = 13;
      this.comboCountry.Location = new Point(97, 120);
      this.comboCountry.MaxLength = (int)short.MaxValue;
      this.comboCountry.Name = "comboCountry";
      this.comboCountry.Size = new Size(131, 21);
      this.comboCountry.TabIndex = 162;
      this.countryListBindingSource.DataSource = (object)typeof(CountryList);
      this.labelFirstName.AutoSize = true;
      this.labelFirstName.ImeMode = ImeMode.NoControl;
      this.labelFirstName.Location = new Point(7, 45);
      this.labelFirstName.Name = "labelFirstName";
      this.labelFirstName.Size = new Size(57, 13);
      this.labelFirstName.TabIndex = 158;
      this.labelFirstName.Text = "First Name";
      this.labelFirstName.TextAlign = ContentAlignment.MiddleLeft;
      this.labelSurame.AutoSize = true;
      this.labelSurame.ImeMode = ImeMode.NoControl;
      this.labelSurame.Location = new Point(6, 71);
      this.labelSurame.Name = "labelSurame";
      this.labelSurame.Size = new Size(58, 13);
      this.labelSurame.TabIndex = 160;
      this.labelSurame.Text = "Last Name";
      this.labelSurame.TextAlign = ContentAlignment.MiddleLeft;
      this.labelCountry.AutoSize = true;
      this.labelCountry.Cursor = Cursors.Hand;
      this.labelCountry.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Underline, GraphicsUnit.Point, (byte)0);
      this.labelCountry.ForeColor = SystemColors.ActiveCaption;
      this.labelCountry.ImeMode = ImeMode.NoControl;
      this.labelCountry.Location = new Point(7, 119);
      this.labelCountry.Name = "labelCountry";
      this.labelCountry.Size = new Size(43, 13);
      this.labelCountry.TabIndex = 164;
      this.labelCountry.Text = "Country";
      this.labelCountry.TextAlign = ContentAlignment.MiddleLeft;
      this.labelCountry.DoubleClick += new EventHandler(this.labelCountry_DoubleClick);
      this.groupLeagues.Controls.Add((Control)this.comboLeague4);
      this.groupLeagues.Controls.Add((Control)this.comboLeague7);
      this.groupLeagues.Controls.Add((Control)this.comboLeague5);
      this.groupLeagues.Controls.Add((Control)this.comboLeague6);
      this.groupLeagues.Controls.Add((Control)this.comboLeague0);
      this.groupLeagues.Controls.Add((Control)this.comboLeague3);
      this.groupLeagues.Controls.Add((Control)this.comboLeague1);
      this.groupLeagues.Controls.Add((Control)this.comboLeague2);
      this.groupLeagues.Location = new Point(3, 310);
      this.groupLeagues.Name = "groupLeagues";
      this.groupLeagues.Size = new Size(512, 134);
      this.groupLeagues.TabIndex = 192;
      this.groupLeagues.TabStop = false;
      this.groupLeagues.Text = "Leagues";
      this.comboLeague4.FormattingEnabled = true;
      this.comboLeague4.Location = new Point(264, 19);
      this.comboLeague4.Name = "comboLeague4";
      this.comboLeague4.Size = new Size(204, 21);
      this.comboLeague4.TabIndex = 192;
      this.comboLeague4.SelectedIndexChanged += new EventHandler(this.comboLeague4_SelectedIndexChanged);
      this.comboLeague7.FormattingEnabled = true;
      this.comboLeague7.Location = new Point(264, 99);
      this.comboLeague7.Name = "comboLeague7";
      this.comboLeague7.Size = new Size(204, 21);
      this.comboLeague7.TabIndex = 195;
      this.comboLeague7.SelectedIndexChanged += new EventHandler(this.comboLeague7_SelectedIndexChanged);
      this.comboLeague5.FormattingEnabled = true;
      this.comboLeague5.Location = new Point(264, 46);
      this.comboLeague5.Name = "comboLeague5";
      this.comboLeague5.Size = new Size(204, 21);
      this.comboLeague5.TabIndex = 193;
      this.comboLeague5.SelectedIndexChanged += new EventHandler(this.comboLeague5_SelectedIndexChanged);
      this.comboLeague6.FormattingEnabled = true;
      this.comboLeague6.Location = new Point(264, 73);
      this.comboLeague6.Name = "comboLeague6";
      this.comboLeague6.Size = new Size(204, 21);
      this.comboLeague6.TabIndex = 194;
      this.comboLeague6.SelectedIndexChanged += new EventHandler(this.comboLeague6_SelectedIndexChanged);
      this.comboLeague0.FormattingEnabled = true;
      this.comboLeague0.Location = new Point(9, 19);
      this.comboLeague0.Name = "comboLeague0";
      this.comboLeague0.Size = new Size(204, 21);
      this.comboLeague0.TabIndex = 183;
      this.comboLeague0.SelectedIndexChanged += new EventHandler(this.comboLeague0_SelectedIndexChanged);
      this.comboLeague3.FormattingEnabled = true;
      this.comboLeague3.Location = new Point(9, 99);
      this.comboLeague3.Name = "comboLeague3";
      this.comboLeague3.Size = new Size(204, 21);
      this.comboLeague3.TabIndex = 191;
      this.comboLeague3.SelectedIndexChanged += new EventHandler(this.comboLeague3_SelectedIndexChanged);
      this.comboLeague1.FormattingEnabled = true;
      this.comboLeague1.Location = new Point(9, 46);
      this.comboLeague1.Name = "comboLeague1";
      this.comboLeague1.Size = new Size(204, 21);
      this.comboLeague1.TabIndex = 189;
      this.comboLeague1.SelectedIndexChanged += new EventHandler(this.comboLeague1_SelectedIndexChanged);
      this.comboLeague2.FormattingEnabled = true;
      this.comboLeague2.Location = new Point(9, 73);
      this.comboLeague2.Name = "comboLeague2";
      this.comboLeague2.Size = new Size(204, 21);
      this.comboLeague2.TabIndex = 190;
      this.comboLeague2.SelectedIndexChanged += new EventHandler(this.comboLeague2_SelectedIndexChanged);
      this.viewer2DPlayerGui.AutoTransparency = true;
      this.viewer2DPlayerGui.BackColor = Color.Transparent;
      this.viewer2DPlayerGui.ButtonStripVisible = true;
      this.viewer2DPlayerGui.CurrentBitmap = (Bitmap)null;
      this.viewer2DPlayerGui.ExtendedFormat = false;
      this.viewer2DPlayerGui.FullSizeButton = false;
      this.viewer2DPlayerGui.ImageLayout = ImageLayout.None;
      this.viewer2DPlayerGui.ImageSize = new Size(256, 256);
      this.viewer2DPlayerGui.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DPlayerGui.Location = new Point(3, 450);
      this.viewer2DPlayerGui.Name = "viewer2DPlayerGui";
      this.viewer2DPlayerGui.RemoveButton = false;
      this.viewer2DPlayerGui.ShowButton = false;
      this.viewer2DPlayerGui.ShowButtonChecked = true;
      this.viewer2DPlayerGui.Size = new Size(256, 225);
      this.viewer2DPlayerGui.TabIndex = 193;
      this.splitContainer2.Dock = DockStyle.Fill;
      this.splitContainer2.Location = new Point(0, 0);
      this.splitContainer2.Name = "splitContainer2";
      this.splitContainer2.Orientation = Orientation.Horizontal;
      this.splitContainer2.Panel1.Controls.Add((Control)this.viewer3D);
      this.splitContainer2.Panel1.Controls.Add((Control)this.tool3D);
      this.splitContainer2.Panel2.AutoScroll = true;
      this.splitContainer2.Panel2.Controls.Add((Control)this.groupGenericFace);
      this.splitContainer2.Size = new Size(826, 807);
      this.splitContainer2.SplitterDistance = 483;
      this.splitContainer2.TabIndex = 0;
      this.viewer3D.AmbientColor = Color.Gray;
      this.viewer3D.BackColor = Color.Gray;
      this.viewer3D.BorderStyle = BorderStyle.Fixed3D;
      this.viewer3D.Dock = DockStyle.Fill;
      /*this.viewer3D.LightDirectionX = -0.5f;
      this.viewer3D.LightDirectionY = -0.25f;
      this.viewer3D.LightDirectionZ = -1f;
      this.viewer3D.LightX = 30f;
      this.viewer3D.LightY = 180f;
      this.viewer3D.LightZ = 100f;
      this.viewer3D.Location = new Point(0, 0);
      this.viewer3D.Name = "viewer3D";
      this.viewer3D.RotationX = 6.28f;
      this.viewer3D.RotationY = 0.0f;
      this.viewer3D.Size = new Size(826, 458);
      this.viewer3D.TabIndex = 5;
      this.viewer3D.ViewX = 0.0f;
      this.viewer3D.ViewY = 171f;
      this.viewer3D.ViewZ = 49f;
      this.viewer3D.ZbufferRenderState = (bool[])null;*/
      this.tool3D.Dock = DockStyle.Bottom;
      this.tool3D.GripStyle = ToolStripGripStyle.Hidden;
      this.tool3D.Items.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.buttonShow3DModel,
        (ToolStripItem) this.buttonSwitchRenderingMode,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.toolPhoto
      });
      this.tool3D.Location = new Point(0, 458);
      this.tool3D.Name = "tool3D";
      this.tool3D.Size = new Size(826, 25);
      this.tool3D.TabIndex = 6;
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
      this.toolPhoto.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolPhoto.Image = (Image)resources.GetObject("toolPhoto.Image");
      this.toolPhoto.ImageTransparentColor = Color.Magenta;
      this.toolPhoto.Name = "toolPhoto";
      this.toolPhoto.Size = new Size(23, 22);
      this.toolPhoto.Text = "Take a picture";
      this.toolPhoto.Click += new EventHandler(this.toolPhoto_Click);
      this.groupGenericFace.Controls.Add((Control)this.groupTextureInfo);
      this.groupGenericFace.Controls.Add((Control)this.groupHairModel);
      this.groupGenericFace.Controls.Add((Control)this.groupHeadModel);
      this.groupGenericFace.Controls.Add((Control)this.labelHeadType);
      this.groupGenericFace.Controls.Add((Control)this.labelHairType);
      this.groupGenericFace.Location = new Point(3, 3);
      this.groupGenericFace.Name = "groupGenericFace";
      this.groupGenericFace.Size = new Size(590, 246);
      this.groupGenericFace.TabIndex = 87;
      this.groupGenericFace.TabStop = false;
      this.groupGenericFace.Text = "Face Modelling";
      this.groupTextureInfo.Controls.Add((Control)this.comboSkinColor);
      this.groupTextureInfo.Controls.Add((Control)this.labelFacialHair);
      this.groupTextureInfo.Controls.Add((Control)this.labelEyeBow);
      this.groupTextureInfo.Controls.Add((Control)this.domainFacialHair);
      this.groupTextureInfo.Controls.Add((Control)this.comboEyeBow);
      this.groupTextureInfo.Controls.Add((Control)this.labelSideburns);
      this.groupTextureInfo.Controls.Add((Control)this.comboSideburns);
      this.groupTextureInfo.Controls.Add((Control)this.labelSkintype);
      this.groupTextureInfo.Controls.Add((Control)this.comboEyescolor);
      this.groupTextureInfo.Controls.Add((Control)this.comboSkintype);
      this.groupTextureInfo.Controls.Add((Control)this.label2);
      this.groupTextureInfo.Controls.Add((Control)this.label1);
      this.groupTextureInfo.Controls.Add((Control)this.comboFacialHairColor);
      this.groupTextureInfo.Controls.Add((Control)this.labelFacialHairColor);
      this.groupTextureInfo.Location = new Point(381, 19);
      this.groupTextureInfo.Name = "groupTextureInfo";
      this.groupTextureInfo.Size = new Size(200, 217);
      this.groupTextureInfo.TabIndex = 35;
      this.groupTextureInfo.TabStop = false;
      this.groupTextureInfo.Text = "Face Type";
      this.comboSkinColor.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboSkinColor.FormattingEnabled = true;
      this.comboSkinColor.Items.AddRange(new object[10]
      {
        (object) "1 = unused",
        (object) "Pink",
        (object) "3 = unused",
        (object) "Llight Yellow",
        (object) "Medium Yellow",
        (object) "Dark Yellow",
        (object) "7 = unused",
        (object) "Light Brown",
        (object) "Medium Brown",
        (object) "Dark brown"
      });
      this.comboSkinColor.Location = new Point(77, 22);
      this.comboSkinColor.Name = "comboSkinColor";
      this.comboSkinColor.Size = new Size(111, 21);
      this.comboSkinColor.TabIndex = 20;
      this.comboSkinColor.SelectedIndexChanged += new EventHandler(this.comboSkinColor_SelectedIndexChanged);
      this.labelFacialHair.AutoSize = true;
      this.labelFacialHair.BackColor = SystemColors.Control;
      this.labelFacialHair.ImeMode = ImeMode.NoControl;
      this.labelFacialHair.Location = new Point(6, 136);
      this.labelFacialHair.Name = "labelFacialHair";
      this.labelFacialHair.Size = new Size(57, 13);
      this.labelFacialHair.TabIndex = 15;
      this.labelFacialHair.Text = "Facial Hair";
      this.labelFacialHair.TextAlign = ContentAlignment.MiddleLeft;
      this.labelEyeBow.AutoSize = true;
      this.labelEyeBow.BackColor = SystemColors.Control;
      this.labelEyeBow.ImeMode = ImeMode.NoControl;
      this.labelEyeBow.Location = new Point(6, 108);
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
      this.domainFacialHair.Location = new Point(77, 133);
      this.domainFacialHair.Name = "domainFacialHair";
      this.domainFacialHair.Size = new Size(111, 21);
      this.domainFacialHair.TabIndex = 16;
      this.domainFacialHair.SelectedIndexChanged += new EventHandler(this.domainFacialHair_SelectedItemChanged);
      this.comboEyeBow.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboEyeBow.FormattingEnabled = true;
      this.comboEyeBow.Items.AddRange(new object[3]
      {
        (object) "Normal",
        (object) "Big",
        (object) "Thin"
      });
      this.comboEyeBow.Location = new Point(77, 105);
      this.comboEyeBow.Name = "comboEyeBow";
      this.comboEyeBow.Size = new Size(111, 21);
      this.comboEyeBow.TabIndex = 32;
      this.comboEyeBow.SelectedIndexChanged += new EventHandler(this.comboEyeBow_SelectedIndexChanged);
      this.labelSideburns.AutoSize = true;
      this.labelSideburns.BackColor = SystemColors.Control;
      this.labelSideburns.ImeMode = ImeMode.NoControl;
      this.labelSideburns.Location = new Point(6, 192);
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
      this.comboSideburns.Location = new Point(77, 189);
      this.comboSideburns.Name = "comboSideburns";
      this.comboSideburns.Size = new Size(111, 21);
      this.comboSideburns.TabIndex = 24;
      this.comboSideburns.SelectedIndexChanged += new EventHandler(this.comboSideburns_SelectedIndexChanged);
      this.labelSkintype.AutoSize = true;
      this.labelSkintype.BackColor = SystemColors.Control;
      this.labelSkintype.ImeMode = ImeMode.NoControl;
      this.labelSkintype.Location = new Point(6, 52);
      this.labelSkintype.Name = "labelSkintype";
      this.labelSkintype.Size = new Size(55, 13);
      this.labelSkintype.TabIndex = 21;
      this.labelSkintype.Text = "Skin Type";
      this.labelSkintype.TextAlign = ContentAlignment.MiddleLeft;
      this.comboEyescolor.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboEyescolor.FormattingEnabled = true;
      this.comboEyescolor.Items.AddRange(new object[7]
      {
        (object) "Dark Blue",
        (object) "Light Blue",
        (object) "Dark Brown",
        (object) "Light Brown",
        (object) "Dark Green",
        (object) "Gray",
        (object) "Light Green"
      });
      this.comboEyescolor.Location = new Point(77, 77);
      this.comboEyescolor.Name = "comboEyescolor";
      this.comboEyescolor.Size = new Size(111, 21);
      this.comboEyescolor.TabIndex = 26;
      this.comboEyescolor.SelectedIndexChanged += new EventHandler(this.comboEyescolor_SelectedIndexChanged);
      this.comboSkintype.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboSkintype.FormattingEnabled = true;
      this.comboSkintype.Items.AddRange(new object[3]
      {
        (object) "Clean",
        (object) "Freckled",
        (object) "Rough"
      });
      this.comboSkintype.Location = new Point(77, 49);
      this.comboSkintype.Name = "comboSkintype";
      this.comboSkintype.Size = new Size(111, 21);
      this.comboSkintype.TabIndex = 22;
      this.comboSkintype.SelectedIndexChanged += new EventHandler(this.comboSkintype_SelectedIndexChanged);
      this.label2.AutoSize = true;
      this.label2.BackColor = SystemColors.Control;
      this.label2.ImeMode = ImeMode.NoControl;
      this.label2.Location = new Point(6, 80);
      this.label2.Name = "label2";
      this.label2.Size = new Size(57, 13);
      this.label2.TabIndex = 25;
      this.label2.Text = "Eyes Color";
      this.label2.TextAlign = ContentAlignment.MiddleLeft;
      this.label1.AutoSize = true;
      this.label1.BackColor = SystemColors.Control;
      this.label1.ImeMode = ImeMode.NoControl;
      this.label1.Location = new Point(6, 27);
      this.label1.Name = "label1";
      this.label1.Size = new Size(55, 13);
      this.label1.TabIndex = 19;
      this.label1.Text = "Skin Color";
      this.label1.TextAlign = ContentAlignment.MiddleLeft;
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
      this.comboFacialHairColor.Location = new Point(77, 161);
      this.comboFacialHairColor.Name = "comboFacialHairColor";
      this.comboFacialHairColor.Size = new Size(111, 21);
      this.comboFacialHairColor.TabIndex = 18;
      this.comboFacialHairColor.SelectedIndexChanged += new EventHandler(this.comboFacialHairColor_SelectedIndexChanged);
      this.labelFacialHairColor.AutoSize = true;
      this.labelFacialHairColor.BackColor = SystemColors.Control;
      this.labelFacialHairColor.ImeMode = ImeMode.NoControl;
      this.labelFacialHairColor.Location = new Point(6, 164);
      this.labelFacialHairColor.Name = "labelFacialHairColor";
      this.labelFacialHairColor.Size = new Size(31, 13);
      this.labelFacialHairColor.TabIndex = 17;
      this.labelFacialHairColor.Text = "Color";
      this.labelFacialHairColor.TextAlign = ContentAlignment.MiddleLeft;
      this.groupHairModel.Controls.Add((Control)this.comboHeadband);
      this.groupHairModel.Controls.Add((Control)this.comboAfro);
      this.groupHairModel.Controls.Add((Control)this.comboLong);
      this.groupHairModel.Controls.Add((Control)this.comboMedium);
      this.groupHairModel.Controls.Add((Control)this.comboModern);
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
      this.groupHairModel.Controls.Add((Control)this.domainHairColor);
      this.groupHairModel.Controls.Add((Control)this.labelHairColor);
      this.groupHairModel.Location = new Point(6, 104);
      this.groupHairModel.Name = "groupHairModel";
      this.groupHairModel.Size = new Size(364, 132);
      this.groupHairModel.TabIndex = 29;
      this.groupHairModel.TabStop = false;
      this.groupHairModel.Text = "Hair Model";
      this.comboHeadband.FormattingEnabled = true;
      this.comboHeadband.Items.AddRange(new object[6]
      {
        (object) "55",
        (object) "56",
        (object) "76",
        (object) "81",
        (object) "49",
        (object) "91"
      });
      this.comboHeadband.Location = new Point(6, 76);
      this.comboHeadband.Name = "comboHeadband";
      this.comboHeadband.Size = new Size(260, 21);
      this.comboHeadband.TabIndex = 30;
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
      this.comboAfro.Location = new Point(6, 76);
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
      this.comboLong.Location = new Point(6, 76);
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
      this.comboMedium.Location = new Point(6, 76);
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
      this.comboModern.Location = new Point(6, 76);
      this.comboModern.Name = "comboModern";
      this.comboModern.Size = new Size(260, 21);
      this.comboModern.TabIndex = 26;
      this.comboModern.Visible = false;
      this.comboModern.SelectedIndexChanged += new EventHandler(this.comboModern_SelectedIndexChanged);
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
      this.comboShort.Location = new Point(6, 76);
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
      this.comboVeryShort.Location = new Point(6, 76);
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
      this.comboShaven.Location = new Point(6, 76);
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
      this.domainHairColor.DropDownStyle = ComboBoxStyle.DropDownList;
      this.domainHairColor.FormattingEnabled = true;
      this.domainHairColor.Items.AddRange(new object[12]
      {
        (object) "Blonde",
        (object) "Black",
        (object) "Dark Blonde",
        (object) "Dark Brown",
        (object) "Light Blonde",
        (object) "Light Brown",
        (object) "Brown",
        (object) "Red",
        (object) "White",
        (object) "Gray",
        (object) "Green",
        (object) "Violet"
      });
      this.domainHairColor.Location = new Point(155, 102);
      this.domainHairColor.Name = "domainHairColor";
      this.domainHairColor.Size = new Size(111, 21);
      this.domainHairColor.TabIndex = 14;
      this.domainHairColor.SelectedIndexChanged += new EventHandler(this.domainHairColor_SelectedIndexChanged);
      this.labelHairColor.BackColor = SystemColors.Control;
      this.labelHairColor.ImeMode = ImeMode.NoControl;
      this.labelHairColor.Location = new Point(6, 101);
      this.labelHairColor.Name = "labelHairColor";
      this.labelHairColor.Size = new Size(103, 20);
      this.labelHairColor.TabIndex = 13;
      this.labelHairColor.Text = "Hair Color";
      this.labelHairColor.TextAlign = ContentAlignment.MiddleLeft;
      this.groupHeadModel.Controls.Add((Control)this.comboLatinModels);
      this.groupHeadModel.Controls.Add((Control)this.radioButtonLatin);
      this.groupHeadModel.Controls.Add((Control)this.comboAsiaticModels);
      this.groupHeadModel.Controls.Add((Control)this.radioButtonAsiatic);
      this.groupHeadModel.Controls.Add((Control)this.comboAfricanModels);
      this.groupHeadModel.Controls.Add((Control)this.radioButtonAfrican);
      this.groupHeadModel.Controls.Add((Control)this.radioButtonCaucasic);
      this.groupHeadModel.Controls.Add((Control)this.comboCaucasicModels);
      this.groupHeadModel.Controls.Add((Control)this.buttonRandomizeAppearance);
      this.groupHeadModel.Location = new Point(6, 19);
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
      this.comboLatinModels.TabIndex = 3;
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
      this.buttonRandomizeAppearance.Location = new Point(272, 18);
      this.buttonRandomizeAppearance.Name = "buttonRandomizeAppearance";
      this.buttonRandomizeAppearance.Size = new Size(86, 23);
      this.buttonRandomizeAppearance.TabIndex = 27;
      this.buttonRandomizeAppearance.Text = "Randomize";
      this.buttonRandomizeAppearance.UseVisualStyleBackColor = true;
      this.buttonRandomizeAppearance.Click += new EventHandler(this.buttonRandomizeAppearance_Click);
      this.labelHeadType.BackColor = SystemColors.Control;
      this.labelHeadType.ImeMode = ImeMode.NoControl;
      this.labelHeadType.Location = new Point(185, 112);
      this.labelHeadType.Name = "labelHeadType";
      this.labelHeadType.Size = new Size((int)sbyte.MaxValue, 20);
      this.labelHeadType.TabIndex = 11;
      this.labelHeadType.Text = "Head Model";
      this.labelHeadType.TextAlign = ContentAlignment.MiddleCenter;
      this.labelHairType.BackColor = SystemColors.Control;
      this.labelHairType.ImeMode = ImeMode.NoControl;
      this.labelHairType.Location = new Point(16, 184);
      this.labelHairType.Name = "labelHairType";
      this.labelHairType.Size = new Size(119, 20);
      this.labelHairType.TabIndex = 9;
      this.labelHairType.Text = "Hair Model";
      this.labelHairType.TextAlign = ContentAlignment.MiddleLeft;
      this.pickUpControl.BackColor = SystemColors.Control;
      this.pickUpControl.CloneButtonEnabled = true;
      this.pickUpControl.CreateButtonEnabled = true;
      this.pickUpControl.CurrentIndex = 0;
      this.pickUpControl.Dock = DockStyle.Top;
      this.pickUpControl.FilterByList = new string[3]
      {
        "All",
        "by Country",
        "by League"
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
      this.pickUpControl.TabIndex = 1;
      this.pickUpControl.WizardButtonEnabled = false;
      this.pickUpControl.YoungPlayersEnabled = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImageLayout = ImageLayout.Center;
      this.ClientSize = new Size(1357, 832);
      this.Controls.Add((Control)this.splitContainer1);
      this.Controls.Add((Control)this.pickUpControl);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = "RefereeForm";
      this.Text = "RefereeForm";
      this.Load += new EventHandler(this.RefereeForm_Load);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.flowLayoutPanel1.ResumeLayout(false);
      this.groupIdentity.ResumeLayout(false);
      this.groupIdentity.PerformLayout();
      this.groupShoes.ResumeLayout(false);
      this.groupShoes.PerformLayout();
      ((ISupportInitialize)this.pictureColorShoes2).EndInit();
      ((ISupportInitialize)this.refereeBindingSource).EndInit();
      ((ISupportInitialize)this.pictureColorShoes1).EndInit();
      this.numericShoesBrand.EndInit();
      this.numericShoesDesign.EndInit();
      this.numericHeight.EndInit();
      this.numericWeight.EndInit();
      this.numericRefereeId.EndInit();
      ((ISupportInitialize)this.countryListBindingSource).EndInit();
      this.groupLeagues.ResumeLayout(false);
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel1.PerformLayout();
      this.splitContainer2.Panel2.ResumeLayout(false);
      this.splitContainer2.EndInit();
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
