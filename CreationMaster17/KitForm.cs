// Original code created by Rinaldo

using FifaControls;
using FifaLibrary;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CreationMaster
{
    public class KitForm : Form
    {
        private static Color[] c_ColorPalette = new Color[20]
        {
      Color.Transparent,
      Color.White,
      Color.Black,
      Color.Blue,
      Color.Red,
      Color.Yellow,
      Color.Green,
      Color.Orange,
      Color.DarkViolet,
      Color.FromArgb(90, 60, 30),
      Color.Pink,
      Color.DarkRed,
      Color.LightSkyBlue,
      Color.DarkBlue,
      Color.Gray,
      Color.FromArgb(200, 200, 100),
      Color.FromArgb(160, 140, 85),
      Color.Gold,
      Color.OrangeRed,
      Color.ForestGreen
        };
        private SolidBrush m_FontBrush = new SolidBrush(Color.Black);
        private NewKitCreator m_NewKitCreator = new NewKitCreator();
        private string m_FontnameCurrentFolder = FifaEnvironment.ExportFolder;
        private float[] m_CopyPosition = new float[32];
        private PrivateFontCollection m_FontCollection;
        private Graphics m_FontGraphics;
        private Kit m_CurrentKit;
        private bool m_IsLoaded;
        private bool m_UpdatingLock;
        private bool m_PositionsLock;
        private IContainer components;
        public PickUpControl pickUpControl;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer3;
        private Viewer2D viewer2DMinikit;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer4;
        private SplitContainer splitContainer5;
        private MultiViewer2D multiViewer2DKit;
        private MultiViewer2D multiViewer2DJerseyNumbers;
        private MultiViewer2D multiViewer2DShortsNumbers;
        private GroupBox group3D;
        private FbxViewer3D viewer3D;
        private ToolStrip toolNear3D;
        private ToolStripButton buttonShow3DModel;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton buttonCamera;
        private FlowLayoutPanel flowPanel;
        private NumericUpDown numericCollar;
        private GroupBox groupCollar;
        private Label labelCollar;
        private BindingSource kitBindingSource;
        private CheckBox checkHasBackname;
        private CheckBox checkFrontNumber;
        private CheckBox checkShortsNumber;
        private Label labelNameFont;
        private NumericUpDown numericNameFont;
        private Label label1;
        private ComboBox comboNameLayout;
        private NumericUpDown numericShortsNumberFont;
        private NumericUpDown numericJerseyNumberFont;
        private PictureBox pictureNameColor;
        private ColorDialog colorDialog;
        private PictureBox pictureTeamTerColor;
        private PictureBox pictureTeamPrimColor;
        private PictureBox pictureTeamSecColor;
        private GroupBox groupName;
        private CheckBox checkHasAdvertising;
        private NumericUpDown numericBottom;
        private NumericUpDown numericTop;
        private NumericUpDown numericLeft;
        private NumericUpDown numericRight;
        private ComboBox comboKitType;
        private ComboBox comboTeam;
        private BindingSource teamListBindingSource;
        private Label labelKitType;
        private Label labelTeam;
        private Label label2;
        private GroupBox groupPositions;
        private CheckBox checkLink;
        private Label label3;
        private ComboBox comboBox1;
        private ToolStrip toolStrip3D;
        private ToolStripButton buttonFrontNumber;
        private ToolStripButton buttonShortsBadge;
        private ToolStripButton buttonJerseyBadge;
        private ToolStripButton buttonShortsNumber;
        private ToolStripButton buttonBackName;
        private ToolStripButton buttonBackNumber;
        private ToolStripButton buttonNameCurvature;
        private ToolStripButton buttonRefresh3D;
        private ToolStripButton buttonShowNumbers3D;
        private FontDialog fontDialog;
        private ToolStrip toolStripNameFont;
        private ToolStripButton buttonPreviewNameFont;
        private ToolStripButton buttonImportNameFont;
        private ToolStripButton buttonExportNameFont;
        private ToolStripButton buttonDeleteNameFont;
        private Process processFontView;
        private ToolStripButton buttonCopyPositions;
        private ToolStripButton buttonPastePositions;
        private FontDialog fontDialog1;
        private CheckBox checkIsFitting;
        private ImageList imageListCollar;
        private Label labelCollarImage;
        private PictureBox pictureFont;
        private NumericUpDown numericTeamId;
        private Label labelTeamId;
        private PictureBox pictureJerseyNumberColorPrim;
        private PictureBox pictureJerseyNumberColorSec;
        private PictureBox pictureJerseyNumberColorTer;
        private PictureBox pictureShortsNumberColorPrim;
        private PictureBox pictureShortsNumberColorSec;
        private PictureBox pictureShortsNumberColorTer;
        private CheckBox checkBoxIsEmbargoed;
        private Label labelFont;

        public KitForm()
        {
            this.Visible = false;
            this.InitializeComponent();
            this.m_FontGraphics = this.pictureFont.CreateGraphics();
            this.m_FontGraphics.Clear(Color.White);
            this.pickUpControl.SelectObject = new PickUpControl.PickUpCallback(this.SelectKit);
            this.pickUpControl.DeleteObject = new PickUpControl.PickUpCallback(this.DeleteKit);
            this.pickUpControl.CloneObject = new PickUpControl.PickUpCallback(this.CloneKit);
            this.pickUpControl.RefreshObject = new PickUpControl.PickUpCallback(this.RefreshKit);
            this.viewer2DMinikit.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageMinikit);
            this.viewer2DMinikit.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteMinikit);
            this.viewer2DMinikit.ButtonStripVisible = true;
            this.viewer2DMinikit.RemoveButton = true;
            this.multiViewer2DKit.Rx3ExportDelegate = new MultiViewer2D.Rx3ExportHandler(this.ExportRx3Kit);
            this.multiViewer2DKit.Rx3ImportDelegate = new MultiViewer2D.Rx3ImportHandler(this.ImportRx3Kit);
            this.multiViewer2DKit.Rx3SaveDelegate = new MultiViewer2D.Rx3SaveHandler(this.SaveBitmapsKit);
            this.multiViewer2DKit.Rx3DeleteDelegate = new MultiViewer2D.Rx3DeleteHandler(this.DeleteRx3Kit);
            this.multiViewer2DJerseyNumbers.Rx3ExportDelegate = new MultiViewer2D.Rx3ExportHandler(this.ExportRx3JerseyNumbers);
            this.multiViewer2DJerseyNumbers.Rx3ImportDelegate = new MultiViewer2D.Rx3ImportHandler(this.ImportRx3JerseyNumbers);
            this.multiViewer2DJerseyNumbers.Rx3SaveDelegate = new MultiViewer2D.Rx3SaveHandler(this.SaveBitmapsJerseyNumbers);
            this.multiViewer2DJerseyNumbers.Rx3DeleteDelegate = new MultiViewer2D.Rx3DeleteHandler(this.DeleteRx3JerseyNumbers);
            this.multiViewer2DJerseyNumbers.ShowDeleteButton = true;
            this.multiViewer2DShortsNumbers.Rx3ExportDelegate = new MultiViewer2D.Rx3ExportHandler(this.ExportRx3ShortsNumbers);
            this.multiViewer2DShortsNumbers.Rx3ImportDelegate = new MultiViewer2D.Rx3ImportHandler(this.ImportRx3ShortsNumbers);
            this.multiViewer2DShortsNumbers.Rx3SaveDelegate = new MultiViewer2D.Rx3SaveHandler(this.SaveBitmapsShortsNumbers);
            this.multiViewer2DShortsNumbers.Rx3DeleteDelegate = new MultiViewer2D.Rx3DeleteHandler(this.DeleteRx3ShortsNumbers);
            this.multiViewer2DShortsNumbers.ShowDeleteButton = true;
            for (int index = 0; index < 32; ++index)
                this.m_CopyPosition[index] = 0.0f;
        }

        private FontFamily LoadFontFamily(string fileName, out PrivateFontCollection _myFonts)
        {
            _myFonts = new PrivateFontCollection();
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[fileStream.Length];
            fileStream.Read(buffer, 0, buffer.Length);
            fileStream.Close();
            IntPtr memory = Marshal.UnsafeAddrOfPinnedArrayElement((Array)buffer, 0);
            _myFonts.AddMemoryFont(memory, buffer.Length);
            return _myFonts.Families[0];
        }

        public void Clean()
        {
            this.Visible = false;
        }

        public Kit RefreshKit(object sender, object obj)
        {
            this.Preset();
            this.ReloadKit(this.m_CurrentKit);
            return this.m_CurrentKit;
        }

        public void Preset()
        {
            //Kit.Prepare3DModels();
            this.m_NewKitCreator.SetTeams(FifaEnvironment.Teams);
            this.m_NewKitCreator.KitList = FifaEnvironment.Kits;
            Table table = FifaEnvironment.FifaDb.Table[TI.teamkits];
            this.numericShortsNumberFont.Maximum = (Decimal)table.TableDescriptor.MaxValues[FI.teamkits_shortsnumberfonttype];
            this.numericJerseyNumberFont.Maximum = (Decimal)table.TableDescriptor.MaxValues[FI.teamkits_numberfonttype];
            this.numericNameFont.Maximum = (Decimal)table.TableDescriptor.MaxValues[FI.teamkits_jerseynamefonttype];
            this.pickUpControl.FilterValues = new IdArrayList[4]
            {
        (IdArrayList) null,
        (IdArrayList) FifaEnvironment.Teams,
        (IdArrayList) FifaEnvironment.Leagues,
        (IdArrayList) FifaEnvironment.Countries
            };
            this.teamListBindingSource.DataSource = (object)FifaEnvironment.Teams;
            this.comboTeam.DataSource = (object)this.teamListBindingSource;
            this.pickUpControl.ObjectList = (IdArrayList)FifaEnvironment.Kits;
            this.checkIsFitting.Visible = FifaEnvironment.Year > 14;
        }

        private Kit SelectKit(object sender, object obj)
        {
            Kit kit = (Kit)obj;
            this.LoadKit(kit);
            return kit;
        }

        private Kit CloneKit(object sender, object obj)
        {
            this.m_NewKitCreator.SetTeams(FifaEnvironment.Teams);
            this.m_NewKitCreator.SourceKit = this.m_CurrentKit;
            DialogResult dialogResult = this.m_NewKitCreator.ShowDialog();
            if (this.m_NewKitCreator.NewKit == null)
            {
                if (dialogResult == DialogResult.OK)
                {
                    int num = (int)FifaEnvironment.UserMessages.ShowMessage(5060, this.m_NewKitCreator.NewId);
                }
                return (Kit)null;
            }
          ((Kit)obj).CloneTextures(this.m_NewKitCreator.NewKit);
            return this.m_NewKitCreator.NewKit;
        }

        private Kit DeleteKit(object sender, object obj)
        {
            FifaEnvironment.Kits.DeleteKit((Kit)obj);
            this.m_CurrentKit = (Kit)null;
            return (Kit)null;
        }

        public void LoadKit(Kit kit)
        {
            if (!this.m_IsLoaded || this.m_CurrentKit == kit)
                return;
            this.m_UpdatingLock = true;
            this.m_CurrentKit = kit;
            this.kitBindingSource.DataSource = (object)this.m_CurrentKit;
            this.multiViewer2DKit.Bitmaps = this.m_CurrentKit.GetKitTextures();

            this.multiViewer2DJerseyNumbers.Bitmaps = NumberFont.GetNumberFont(m_CurrentKit.jerseyNumberFont);
            //this.multiViewer2DJerseyNumbers.SetBitmaps(NumberFont.GetNumberFont(m_CurrentKit.jerseyNumberFont), m_CurrentKit.JerseyNumberColorPrim, m_CurrentKit.JerseyNumberColorSec, m_CurrentKit.JerseyNumberColorTer);

            this.multiViewer2DShortsNumbers.Bitmaps = NumberFont.GetNumberFont(m_CurrentKit.shortsNumberFont);
            //this.multiViewer2DShortsNumbers.SetBitmaps(NumberFont.GetNumberFont(this.m_CurrentKit.shortsNumberFont), m_CurrentKit.JerseyNumberColorPrim, m_CurrentKit.JerseyNumberColorSec, m_CurrentKit.JerseyNumberColorTer);

            this.viewer2DMinikit.CurrentBitmap = this.m_CurrentKit.GetMiniKit();
            this.labelCollarImage.ImageIndex = kit.jerseyCollar;
            this.LoadPositions();
            this.Show3DKit();
            this.ShowFont();
            this.m_UpdatingLock = false;
        }

        public void LoadPositions()
        {
            this.m_PositionsLock = true;
            if (this.m_CurrentKit.Positions == null)
            {
                this.EnablePositions(false);
            }
            else
            {
                if (this.buttonBackName.Checked)
                    this.VerifyAndLoadPositions(12);
                else if (this.buttonBackNumber.Checked)
                    this.VerifyAndLoadPositions(4);
                else if (this.buttonNameCurvature.Checked)
                {
                    this.numericLeft.Value = (Decimal)this.m_CurrentKit.Positions[17];
                    this.numericTop.Value = (Decimal)this.m_CurrentKit.Positions[21];
                    this.numericRight.Value = new Decimal(0);
                    this.numericBottom.Value = new Decimal(0);
                    this.EnablePositions(true);
                }
                else if (this.buttonFrontNumber.Checked)
                    this.VerifyAndLoadPositions(8);
                else if (this.buttonJerseyBadge.Checked)
                    this.VerifyAndLoadPositions(0);
                else if (this.buttonShortsBadge.Checked)
                    this.VerifyAndLoadPositions(24);
                else if (this.buttonShortsNumber.Checked)
                    this.VerifyAndLoadPositions(28);
                else
                    this.EnablePositions(false);
                this.m_PositionsLock = false;
            }
        }

        public void VerifyAndLoadPositions(int startingIndex)
        {
            if ((double)this.m_CurrentKit.Positions[startingIndex] < 0.0)
                this.m_CurrentKit.Positions[startingIndex] = 0.0f;
            if ((double)this.m_CurrentKit.Positions[startingIndex] > 1.0)
                this.m_CurrentKit.Positions[startingIndex] = 1f;
            if ((double)this.m_CurrentKit.Positions[startingIndex + 1] < 0.0)
                this.m_CurrentKit.Positions[startingIndex + 1] = 0.0f;
            if ((double)this.m_CurrentKit.Positions[startingIndex + 1] > 1.0)
                this.m_CurrentKit.Positions[startingIndex + 1] = 1f;
            if ((double)this.m_CurrentKit.Positions[startingIndex + 2] < 0.0)
                this.m_CurrentKit.Positions[startingIndex + 2] = 0.0f;
            if ((double)this.m_CurrentKit.Positions[startingIndex + 2] > 1.0)
                this.m_CurrentKit.Positions[startingIndex + 2] = 1f;
            if ((double)this.m_CurrentKit.Positions[startingIndex + 3] < 0.0)
                this.m_CurrentKit.Positions[startingIndex + 3] = 0.0f;
            if ((double)this.m_CurrentKit.Positions[startingIndex + 3] > 1.0)
                this.m_CurrentKit.Positions[startingIndex + 3] = 1f;
            this.numericLeft.Value = (Decimal)this.m_CurrentKit.Positions[startingIndex];
            this.numericTop.Value = (Decimal)this.m_CurrentKit.Positions[startingIndex + 1];
            this.numericRight.Value = (Decimal)this.m_CurrentKit.Positions[startingIndex + 2];
            this.numericBottom.Value = (Decimal)this.m_CurrentKit.Positions[startingIndex + 3];
            this.EnablePositions(true);
        }

        public void ChangePositions()
        {
            if (this.m_PositionsLock)
                return;
            if (!this.multiViewer2DKit.buttonSave.Enabled)
                this.multiViewer2DKit.buttonSave.Enabled = true;
            if (this.buttonBackName.Checked)
            {
                if (this.checkLink.Checked)
                {
                    float num1 = (float)this.numericLeft.Value - this.m_CurrentKit.Positions[12];
                    this.m_CurrentKit.Positions[12] += num1;
                    this.m_CurrentKit.Positions[14] += num1;
                    float num2 = (float)this.numericTop.Value - this.m_CurrentKit.Positions[13];
                    this.m_CurrentKit.Positions[13] += num2;
                    this.m_CurrentKit.Positions[15] += num2;
                }
                else
                {
                    this.m_CurrentKit.Positions[12] = (float)this.numericLeft.Value;
                    this.m_CurrentKit.Positions[13] = (float)this.numericTop.Value;
                    this.m_CurrentKit.Positions[14] = (float)this.numericRight.Value;
                    this.m_CurrentKit.Positions[15] = (float)this.numericBottom.Value;
                }
                this.CheckPositions();
                this.LoadPositions();
            }
            else if (this.buttonBackNumber.Checked)
            {
                if (this.checkLink.Checked)
                {
                    float num1 = (float)this.numericLeft.Value - this.m_CurrentKit.Positions[4];
                    this.m_CurrentKit.Positions[4] += num1;
                    this.m_CurrentKit.Positions[6] += num1;
                    float num2 = (float)this.numericTop.Value - this.m_CurrentKit.Positions[5];
                    this.m_CurrentKit.Positions[5] += num2;
                    this.m_CurrentKit.Positions[7] += num2;
                }
                else
                {
                    this.m_CurrentKit.Positions[4] = (float)this.numericLeft.Value;
                    this.m_CurrentKit.Positions[5] = (float)this.numericTop.Value;
                    this.m_CurrentKit.Positions[6] = (float)this.numericRight.Value;
                    this.m_CurrentKit.Positions[7] = (float)this.numericBottom.Value;
                }
                this.CheckPositions();
                this.LoadPositions();
            }
            else if (this.buttonNameCurvature.Checked)
            {
                this.m_CurrentKit.Positions[17] = (float)this.numericLeft.Value;
                this.m_CurrentKit.Positions[21] = (float)this.numericTop.Value;
                this.CheckPositions();
                this.LoadPositions();
            }
            else if (this.buttonFrontNumber.Checked)
            {
                if (this.checkLink.Checked)
                {
                    float num1 = (float)this.numericLeft.Value - this.m_CurrentKit.Positions[8];
                    this.m_CurrentKit.Positions[8] += num1;
                    this.m_CurrentKit.Positions[10] += num1;
                    float num2 = (float)this.numericTop.Value - this.m_CurrentKit.Positions[9];
                    this.m_CurrentKit.Positions[9] += num2;
                    this.m_CurrentKit.Positions[11] += num2;
                }
                else
                {
                    this.m_CurrentKit.Positions[8] = (float)this.numericLeft.Value;
                    this.m_CurrentKit.Positions[9] = (float)this.numericTop.Value;
                    this.m_CurrentKit.Positions[10] = (float)this.numericRight.Value;
                    this.m_CurrentKit.Positions[11] = (float)this.numericBottom.Value;
                }
                this.CheckPositions();
                this.LoadPositions();
            }
            else if (this.buttonJerseyBadge.Checked)
            {
                if (this.checkLink.Checked)
                {
                    float num1 = (float)this.numericLeft.Value - this.m_CurrentKit.Positions[0];
                    this.m_CurrentKit.Positions[0] += num1;
                    this.m_CurrentKit.Positions[2] += num1;
                    float num2 = (float)this.numericTop.Value - this.m_CurrentKit.Positions[1];
                    this.m_CurrentKit.Positions[1] += num2;
                    this.m_CurrentKit.Positions[3] += num2;
                }
                else
                {
                    this.m_CurrentKit.Positions[0] = (float)this.numericLeft.Value;
                    this.m_CurrentKit.Positions[1] = (float)this.numericTop.Value;
                    this.m_CurrentKit.Positions[2] = (float)this.numericRight.Value;
                    this.m_CurrentKit.Positions[3] = (float)this.numericBottom.Value;
                }
                this.CheckPositions();
                this.LoadPositions();
            }
            else if (this.buttonShortsBadge.Checked)
            {
                if (this.checkLink.Checked)
                {
                    float num1 = (float)this.numericLeft.Value - this.m_CurrentKit.Positions[24];
                    this.m_CurrentKit.Positions[24] += num1;
                    this.m_CurrentKit.Positions[26] += num1;
                    float num2 = (float)this.numericTop.Value - this.m_CurrentKit.Positions[25];
                    this.m_CurrentKit.Positions[25] += num2;
                    this.m_CurrentKit.Positions[27] += num2;
                }
                else
                {
                    this.m_CurrentKit.Positions[24] = (float)this.numericLeft.Value;
                    this.m_CurrentKit.Positions[25] = (float)this.numericTop.Value;
                    this.m_CurrentKit.Positions[26] = (float)this.numericRight.Value;
                    this.m_CurrentKit.Positions[27] = (float)this.numericBottom.Value;
                }
                this.CheckPositions();
                this.LoadPositions();
            }
            else
            {
                if (!this.buttonShortsNumber.Checked)
                    return;
                if (this.checkLink.Checked)
                {
                    float num1 = (float)this.numericLeft.Value - this.m_CurrentKit.Positions[28];
                    this.m_CurrentKit.Positions[28] += num1;
                    this.m_CurrentKit.Positions[30] += num1;
                    float num2 = (float)this.numericTop.Value - this.m_CurrentKit.Positions[29];
                    this.m_CurrentKit.Positions[29] += num2;
                    this.m_CurrentKit.Positions[31] += num2;
                }
                else
                {
                    this.m_CurrentKit.Positions[28] = (float)this.numericLeft.Value;
                    this.m_CurrentKit.Positions[29] = (float)this.numericTop.Value;
                    this.m_CurrentKit.Positions[30] = (float)this.numericRight.Value;
                    this.m_CurrentKit.Positions[31] = (float)this.numericBottom.Value;
                }
                this.CheckPositions();
                this.LoadPositions();
            }
        }

        public void CheckPositions()
        {
            for (int index = 0; index < 32; ++index)
            {
                if ((double)this.m_CurrentKit.Positions[index] < 0.0)
                    this.m_CurrentKit.Positions[index] = 0.0f;
                if ((double)this.m_CurrentKit.Positions[index] > 1.0)
                    this.m_CurrentKit.Positions[index] = 1f;
            }
        }

        private void EnablePositions(bool enabled)
        {
            if (!enabled)
            {
                this.numericLeft.Enabled = enabled;
                this.numericTop.Enabled = enabled;
                this.numericRight.Enabled = enabled;
                this.numericBottom.Enabled = enabled;
            }
            else if (this.checkLink.Checked || this.buttonNameCurvature.Checked)
            {
                this.numericLeft.Enabled = enabled;
                this.numericTop.Enabled = enabled;
                this.numericRight.Enabled = !enabled;
                this.numericBottom.Enabled = !enabled;
            }
            else
            {
                this.numericLeft.Enabled = enabled;
                this.numericTop.Enabled = enabled;
                this.numericRight.Enabled = enabled;
                this.numericBottom.Enabled = enabled;
            }
        }

        public void ReloadKit(Kit kit)
        {
            this.m_CurrentKit = (Kit)null;
            this.LoadKit(kit);
        }

        private void KitForm_Load(object sender, EventArgs e)
        {
            this.m_IsLoaded = true;
            this.Preset();
        }

        private bool ImportImageMinikit(object sender, Bitmap bitmap)
        {
            return this.m_CurrentKit.SetMiniKit(bitmap);
        }

        private bool DeleteMinikit(object sender)
        {
            return this.m_CurrentKit.DeleteMiniKit();
        }

        private bool SaveBitmapsKit(object sender, Bitmap[] bitmaps)
        {
            bool flag = this.m_CurrentKit.SetKitTextures(bitmaps);
            this.ReloadKit(this.m_CurrentKit);
            return flag;
        }

        private bool ExportRx3Kit(object sender, string exportDir)
        {
            return this.m_CurrentKit.ExportKitTextures(exportDir);
        }

        private bool ImportRx3Kit(object sender, string rx3FileName)
        {
            bool flag = this.m_CurrentKit.ImportKitTextures(rx3FileName);
            if (flag)
                this.ReloadKit(this.m_CurrentKit);
            return flag;
        }

        private bool DeleteRx3Kit(object sender)
        {
            bool flag = this.m_CurrentKit.DeleteKitTextures();
            if (flag)
                this.ReloadKit(this.m_CurrentKit);
            return flag;
        }

        private bool SaveBitmapsJerseyNumbers(object sender, Bitmap[] bitmaps)
        {
            bool flag = NumberFont.SetNumberFont(this.m_CurrentKit.jerseyNumberFont, bitmaps);
            if (flag)
                this.ReloadKit(this.m_CurrentKit);
            return flag;
        }

        private bool ExportRx3JerseyNumbers(object sender, string exportDir)
        {
            return NumberFont.Export(this.m_CurrentKit.jerseyNumberFont, exportDir);
        }

        private bool ImportRx3JerseyNumbers(object sender, string rx3FileName)
        {
            bool flag = NumberFont.Import(this.m_CurrentKit.jerseyNumberFont, rx3FileName);
            if (flag)
                this.ReloadKit(this.m_CurrentKit);
            return flag;
        }

        private bool DeleteRx3JerseyNumbers(object sender)
        {
            bool flag = NumberFont.Delete(this.m_CurrentKit.jerseyNumberFont);
            if (flag)
                this.ReloadKit(this.m_CurrentKit);
            return flag;
        }

        private bool SaveBitmapsShortsNumbers(object sender, Bitmap[] bitmaps)
        {
            bool flag = NumberFont.SetNumberFont(this.m_CurrentKit.shortsNumberFont, bitmaps);
            if (flag)
                this.ReloadKit(this.m_CurrentKit);
            return flag;
        }

        private bool ExportRx3ShortsNumbers(object sender, string exportDir)
        {
            return NumberFont.Export(this.m_CurrentKit.shortsNumberFont, exportDir);
        }

        private bool ImportRx3ShortsNumbers(object sender, string rx3FileName)
        {
            bool flag = NumberFont.Import(this.m_CurrentKit.shortsNumberFont, rx3FileName);
            if (flag)
                this.ReloadKit(this.m_CurrentKit);
            return flag;
        }

        private bool DeleteRx3ShortsNumbers(object sender)
        {
            bool flag = NumberFont.Delete(this.m_CurrentKit.shortsNumberFont);
            if (flag)
                this.ReloadKit(this.m_CurrentKit);
            return flag;
        }

        public void Show3DKit()
        {
            if (!this.buttonShow3DModel.Checked)
            {
                this.viewer3D.ShowEmpty();
            }
            else
            {
                Bitmap[] kitTextures = this.m_CurrentKit.GetKitTextures();
                if (kitTextures == null)
                {
                    this.viewer3D.ShowEmpty();
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Bitmap bitmap1 = (Bitmap)null;
                    Bitmap bitmap2 = (Bitmap)null;
                    if (kitTextures != null)
                    {
                        bitmap1 = kitTextures[1];
                        bitmap2 = kitTextures[3];
                    }
                    Rectangle destRectangle1 = new Rectangle((int)((double)bitmap2.Width * (double)this.m_CurrentKit.Positions[24]), (int)((double)bitmap2.Height * (double)this.m_CurrentKit.Positions[25]), (int)((double)bitmap2.Width * ((double)this.m_CurrentKit.Positions[26] - (double)this.m_CurrentKit.Positions[24])), (int)((double)bitmap2.Height * ((double)this.m_CurrentKit.Positions[27] - (double)this.m_CurrentKit.Positions[25])));
                    if (destRectangle1.Width > 0 && destRectangle1.Height > 0)
                        bitmap2 = GraphicUtil.Overlap(bitmap2, kitTextures[0], destRectangle1);
                    Rectangle destRectangle2 = new Rectangle((int)((double)bitmap1.Width * (double)this.m_CurrentKit.Positions[0]), (int)((double)bitmap1.Height * (double)this.m_CurrentKit.Positions[1]), (int)((double)bitmap1.Width * ((double)this.m_CurrentKit.Positions[2] - (double)this.m_CurrentKit.Positions[0])), (int)((double)bitmap1.Height * ((double)this.m_CurrentKit.Positions[3] - (double)this.m_CurrentKit.Positions[1])));
                    if (destRectangle2.Width > 0 && destRectangle2.Height > 0)
                        bitmap1 = GraphicUtil.Overlap(bitmap1, kitTextures[0], destRectangle2);
                    if (this.buttonShowNumbers3D.Checked && this.m_CurrentKit.jerseyBackName)
                    {
                        Bitmap srcBitmap = new Bitmap(FifaEnvironment.LaunchDir + "\\Templates\\PlayerName.png");
                        if (srcBitmap != null)
                        {
                            Bitmap upperBitmap = GraphicUtil.ColorizeWhite(srcBitmap, this.pictureNameColor.BackColor);
                            Rectangle destRectangle3 = new Rectangle((int)((double)bitmap1.Width * (double)this.m_CurrentKit.Positions[14]), (int)((double)bitmap1.Height * (double)this.m_CurrentKit.Positions[15]), (int)((double)bitmap1.Width * ((double)this.m_CurrentKit.Positions[12] - (double)this.m_CurrentKit.Positions[14])), (int)((double)bitmap1.Height * ((double)this.m_CurrentKit.Positions[13] - (double)this.m_CurrentKit.Positions[15])));
                            if (destRectangle3.Width > 0 && destRectangle3.Height > 0)
                                bitmap1 = GraphicUtil.Overlap(bitmap1, upperBitmap, destRectangle3);
                        }
                    }
                    if (this.buttonShowNumbers3D.Checked)
                    {
                        if (this.multiViewer2DShortsNumbers.GetCurrentBitmap() != null && this.m_CurrentKit.shortsNumber)
                        {
                            destRectangle1 = new Rectangle((int)((double)bitmap2.Width * (double)this.m_CurrentKit.Positions[28]), (int)((double)bitmap2.Height * (double)this.m_CurrentKit.Positions[29]), (int)((double)bitmap2.Width * ((double)this.m_CurrentKit.Positions[30] - (double)this.m_CurrentKit.Positions[28])), (int)((double)bitmap2.Height * ((double)this.m_CurrentKit.Positions[31] - (double)this.m_CurrentKit.Positions[29])));
                            Bitmap upperBitmap = (Bitmap)this.multiViewer2DShortsNumbers.GetCurrentBitmap().Clone();
                            if (upperBitmap != null && destRectangle1.Width > 0 && destRectangle1.Height > 0)
                                bitmap2 = GraphicUtil.Overlap(bitmap2, upperBitmap, destRectangle1);
                        }
                        if (this.multiViewer2DJerseyNumbers.GetCurrentBitmap() != null)
                        {
                            Bitmap upperBitmap = (Bitmap)this.multiViewer2DJerseyNumbers.GetCurrentBitmap().Clone();
                            if (this.m_CurrentKit.jerseyFrontNumber)
                            {
                                destRectangle2 = new Rectangle((int)((double)bitmap1.Width * (double)this.m_CurrentKit.Positions[8]), (int)((double)bitmap1.Height * (double)this.m_CurrentKit.Positions[9]), (int)((double)bitmap1.Width * ((double)this.m_CurrentKit.Positions[10] - (double)this.m_CurrentKit.Positions[8])), (int)((double)bitmap1.Height * ((double)this.m_CurrentKit.Positions[11] - (double)this.m_CurrentKit.Positions[9])));
                                if (upperBitmap != null && destRectangle2.Width > 0 && destRectangle2.Height > 0)
                                    bitmap1 = GraphicUtil.Overlap(bitmap1, upperBitmap, destRectangle2);
                            }
                            destRectangle2 = new Rectangle((int)((double)bitmap1.Width * (double)this.m_CurrentKit.Positions[6]), (int)((double)bitmap1.Height * (double)this.m_CurrentKit.Positions[7]), (int)((double)bitmap1.Width * ((double)this.m_CurrentKit.Positions[4] - (double)this.m_CurrentKit.Positions[6])), (int)((double)bitmap1.Height * ((double)this.m_CurrentKit.Positions[5] - (double)this.m_CurrentKit.Positions[7])));
                            if (upperBitmap != null && destRectangle2.Width > 0 && destRectangle2.Height > 0)
                            {
                                upperBitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                bitmap1 = GraphicUtil.Overlap(bitmap1, upperBitmap, destRectangle2);
                            }
                        }
                    }
                    Bitmap bitmap3 = GraphicUtil.EmbossBitmap(bitmap1, Kit.s_JerseyWrinkle);
                    Bitmap bitmap4 = GraphicUtil.EmbossBitmap(bitmap2, Kit.s_ShortsWrinkle);
                    /*Kit.s_JerseyModel3D[this.m_CurrentKit.jerseyCollar].TextureBitmap = bitmap3;
                    Kit.s_ShortsModel3D.TextureBitmap = bitmap4;
                    Kit.s_SocksModel3D.TextureBitmap = bitmap4;
                    this.viewer3D.Clean(3);
                    this.viewer3D.SetMesh(0, Kit.s_JerseyModel3D[this.m_CurrentKit.jerseyCollar]);
                    this.viewer3D.SetMesh(1, Kit.s_ShortsModel3D);
                    this.viewer3D.SetMesh(2, Kit.s_SocksModel3D);*/
                    this.viewer3D.Render();
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void buttonShow3DModel_Click(object sender, EventArgs e)
        {
            this.Show3DKit();
        }

        private void numericCollar_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentKit.jerseyCollar = (int)this.numericCollar.Value;
            this.labelCollarImage.ImageIndex = this.m_CurrentKit.jerseyCollar;
        }

        private void pictureNameColor_Click(object sender, EventArgs e)
        {
            this.colorDialog.Color = this.pictureNameColor.BackColor;
            int num = (int)this.colorDialog.ShowDialog();
            this.pictureNameColor.BackColor = this.colorDialog.Color;
            this.m_CurrentKit.JerseyNameColor = this.colorDialog.Color;
        }

        /*private void pictureJerseyNumberColor_Click(object sender, EventArgs e)
        {
            this.colorDialog.Color = this.pictureJerseyNumberColorPrim.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.pictureJerseyNumberColorPrim.BackColor = this.colorDialog.Color;
                this.m_CurrentKit.JerseyNumberColorPrim = this.colorDialog.Color;
                if (!this.m_UpdatingLock)
                {
                    this.m_UpdatingLock = true;
                    this.multiViewer2DJerseyNumbers.Bitmaps = NumberFont.GetNumberFont(this.m_CurrentKit.jerseyNumberFont);
                    this.m_UpdatingLock = false;
                }
            }
            colorDialog.Dispose();
        }

        private void pictureShortsNumberColor_Click(object sender, EventArgs e)
        {
            this.colorDialog.Color = this.pictureShortsNumberColorPrim.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.pictureShortsNumberColorPrim.BackColor = this.colorDialog.Color;
                this.m_CurrentKit.ShortsNumberColorPrim = this.colorDialog.Color;
                if (!this.m_UpdatingLock)
                {
                    this.m_UpdatingLock = true;
                    this.multiViewer2DJerseyNumbers.Bitmaps = NumberFont.GetNumberFont(this.m_CurrentKit.shortsNumberFont);
                    this.m_UpdatingLock = false;
                }
            }
            colorDialog.Dispose();
        }*/

        private void pictureTeamPrimColor_Click(object sender, EventArgs e)
        {
            this.colorDialog.Color = this.pictureTeamPrimColor.BackColor;
            int num = (int)this.colorDialog.ShowDialog();
            this.pictureTeamPrimColor.BackColor = this.colorDialog.Color;
            this.m_CurrentKit.TeamColor1 = this.colorDialog.Color;
        }

        private void pictureTeamSecColor_Click(object sender, EventArgs e)
        {
            this.colorDialog.Color = this.pictureTeamSecColor.BackColor;
            int num = (int)this.colorDialog.ShowDialog();
            this.pictureTeamSecColor.BackColor = this.colorDialog.Color;
            this.m_CurrentKit.TeamColor2 = this.colorDialog.Color;
        }

        private void pictureTeamTerColor_Click(object sender, EventArgs e)
        {
            this.colorDialog.Color = this.pictureTeamTerColor.BackColor;
            int num = (int)this.colorDialog.ShowDialog();
            this.pictureTeamTerColor.BackColor = this.colorDialog.Color;
            this.m_CurrentKit.TeamColor3 = this.colorDialog.Color;
        }

        private void numericJerseyNumberFont_ValueChanged(object sender, EventArgs e)
        {
            if (this.m_UpdatingLock)
                return;
            this.m_UpdatingLock = true;
            this.m_CurrentKit.jerseyNumberFont = (int)this.numericJerseyNumberFont.Value;
            this.multiViewer2DJerseyNumbers.Bitmaps = NumberFont.GetNumberFont(this.m_CurrentKit.jerseyNumberFont);
            this.m_UpdatingLock = false;
        }

        private void numericShortsNumberFont_ValueChanged(object sender, EventArgs e)
        {
            if (this.m_UpdatingLock)
                return;
            this.m_UpdatingLock = true;
            this.m_CurrentKit.shortsNumberFont = (int)this.numericShortsNumberFont.Value;
            this.multiViewer2DShortsNumbers.Bitmaps = NumberFont.GetNumberFont(this.m_CurrentKit.shortsNumberFont);
            this.m_UpdatingLock = false;
        }

        private void buttonCamera_Click(object sender, EventArgs e)
        {
            Bitmap bitmap1 = this.viewer3D.Photo();
            int height = bitmap1.Height * 3 / 4;
            int width1 = bitmap1.Width;
            int width2 = width1 < height * 6 / 6 ? width1 : height * 6 / 6;
            Rectangle srcRect = new Rectangle((width1 - width2) / 2, 0, width2, height);
            Rectangle destRect = new Rectangle(22, 22, 212, 212);
            Bitmap srcBitmap = GraphicUtil.MakeAutoTransparent(bitmap1);
            Bitmap bitmap2 = new Bitmap(256, 256, PixelFormat.Format32bppArgb);
            GraphicUtil.RemapRectangle(srcBitmap, srcRect, bitmap2, destRect);
            this.m_CurrentKit.SetMiniKit(bitmap2);
            this.viewer2DMinikit.CurrentBitmap = bitmap2;
        }

        private void radioPosition_Click(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked)
                return;
            this.LoadPositions();
        }

        private void numericPositions_ValueChanged(object sender, EventArgs e)
        {
            this.ChangePositions();
        }

        private void checkLink_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadPositions();
        }

        private void buttonPositions_Click(object sender, EventArgs e)
        {
            ToolStripButton toolStripButton = (ToolStripButton)sender;
            if (!toolStripButton.Checked)
                return;
            if (this.buttonBackName.Checked && this.buttonBackName != toolStripButton)
                this.buttonBackName.Checked = false;
            if (this.buttonBackNumber.Checked && this.buttonBackNumber != toolStripButton)
                this.buttonBackNumber.Checked = false;
            if (this.buttonFrontNumber.Checked && this.buttonFrontNumber != toolStripButton)
                this.buttonFrontNumber.Checked = false;
            if (this.buttonJerseyBadge.Checked && this.buttonJerseyBadge != toolStripButton)
                this.buttonJerseyBadge.Checked = false;
            if (this.buttonNameCurvature.Checked && this.buttonNameCurvature != toolStripButton)
                this.buttonNameCurvature.Checked = false;
            if (this.buttonShortsBadge.Checked && this.buttonShortsBadge != toolStripButton)
                this.buttonShortsBadge.Checked = false;
            if (this.buttonShortsNumber.Checked && this.buttonShortsNumber != toolStripButton)
                this.buttonShortsNumber.Checked = false;
            this.LoadPositions();
        }

        private void buttonSavePositions_Click(object sender, EventArgs e)
        {
        }

        private void buttonRefresh3D_Click(object sender, EventArgs e)
        {
            this.Show3DKit();
        }

        private void buttonShowNumbers3D_Click(object sender, EventArgs e)
        {
            this.Show3DKit();
        }

        private void ShowFont()
        {
            int num = (int)this.numericNameFont.Value;
            string fileName = FifaEnvironment.ExportFolder + "\\" + NameFont.NameFontFileName(num);
            Font font = (Font)null;
            if (NameFont.Export(num, FifaEnvironment.ExportFolder))
            {
                FontFamily family = this.LoadFontFamily(fileName, out this.m_FontCollection);
                if (family.IsStyleAvailable(FontStyle.Regular))
                    font = new Font(family, 15f, FontStyle.Regular);
                else if (family.IsStyleAvailable(FontStyle.Bold))
                    font = new Font(family, 15f, FontStyle.Bold);
                else if (family.IsStyleAvailable(FontStyle.Italic))
                    font = new Font(family, 15f, FontStyle.Italic);
                else if (family.IsStyleAvailable(FontStyle.Strikeout))
                    font = new Font(family, 15f, FontStyle.Strikeout);
                else if (family.IsStyleAvailable(FontStyle.Underline))
                    font = new Font(family, 15f, FontStyle.Underline);
                string s = family.Name + "\r\n" + "abcdefghijklmnopqrstuvwxyz\r\nABCDEFGHIJKLMNOPQRSTUVWXYZ";
                if (font != null)
                {
                    this.m_FontGraphics.Clear(Color.White);
                    this.m_FontGraphics.DrawString(s, font, (Brush)this.m_FontBrush, 0.0f, 0.0f);
                }
                else
                    this.m_FontGraphics.Clear(Color.White);
            }
            else
                this.m_FontGraphics.Clear(Color.White);
        }

        private void buttonPreviewNameFont_Click(object sender, EventArgs e)
        {
            int num = (int)this.numericNameFont.Value;
            string filePath = FifaEnvironment.ExportFolder + "\\" + NameFont.NameFontFileName(num);
            bool flag = true;
            if (!FifaUtil.IsFileLocked(filePath))
                flag = NameFont.Export(num, FifaEnvironment.ExportFolder);
            if (!flag || filePath == null)
                return;
            this.processFontView.StartInfo.WorkingDirectory = FifaEnvironment.LaunchDir;
            this.processFontView.StartInfo.FileName = "fontview";
            this.processFontView.StartInfo.CreateNoWindow = true;
            this.processFontView.StartInfo.UseShellExecute = false;
            this.processFontView.StartInfo.Arguments = filePath;
            this.processFontView.StartInfo.RedirectStandardOutput = false;
            this.processFontView.Start();
            this.processFontView.WaitForExit();
        }

        private void buttonImportNameFont_Click(object sender, EventArgs e)
        {
            int style = (int)this.numericNameFont.Value;
            string srcFileName = FifaEnvironment.BrowseAndCheckTtf(ref this.m_FontnameCurrentFolder);
            if (srcFileName == null)
                return;
            NameFont.Import(style, srcFileName);
            this.ShowFont();
        }

        private void buttonExportNameFont_Click(object sender, EventArgs e)
        {
            NameFont.Export((int)this.numericNameFont.Value, FifaEnvironment.ExportFolder);
        }

        private void buttonDeleteNameFont_Click(object sender, EventArgs e)
        {
            NameFont.Delete((int)this.numericNameFont.Value);
            this.ShowFont();
        }

        private void checkFrontNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_UpdatingLock)
                return;
            this.m_CurrentKit.jerseyFrontNumber = this.checkFrontNumber.Checked;
        }

        private void checkShortsNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_UpdatingLock)
                return;
            this.m_CurrentKit.shortsNumber = this.checkShortsNumber.Checked;
        }

        private void checkHasBackname_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_UpdatingLock)
                return;
            this.m_CurrentKit.jerseyBackName = this.checkHasBackname.Checked;
        }

        private void buttonCopyPositions_Click(object sender, EventArgs e)
        {
            for (int index = 0; index < 32; ++index)
                this.m_CopyPosition[index] = this.m_CurrentKit.Positions[index];
        }

        private void buttonPastePositions_Click(object sender, EventArgs e)
        {
            for (int index = 0; index < 32; ++index)
                this.m_CurrentKit.Positions[index] = this.m_CopyPosition[index];
            this.LoadPositions();
            if (this.multiViewer2DKit.buttonSave.Enabled)
                return;
            this.multiViewer2DKit.buttonSave.Enabled = true;
        }

        private void labelTeam_DoubleClick(object sender, EventArgs e)
        {
            if (this.m_CurrentKit.Team == null)
                return;
            MainForm.CM.JumpTo((IdObject)this.m_CurrentKit.Team);
        }

        private void buttonShowFont_Click(object sender, EventArgs e)
        {
            int num = (int)this.fontDialog.ShowDialog();
        }

        private void numericNameFont_ValueChanged(object sender, EventArgs e)
        {
            if (this.m_UpdatingLock)
                return;
            this.ShowFont();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void pictureJerseyNumberColorPrim_Click(object sender, EventArgs e)
        {
            this.colorDialog.Color = this.pictureJerseyNumberColorPrim.BackColor;
            int num = (int)this.colorDialog.ShowDialog();
            this.pictureJerseyNumberColorPrim.BackColor = this.colorDialog.Color;
            this.m_CurrentKit.JerseyNumberColorPrim = this.colorDialog.Color;
        }

        private void pictureJerseyNumberColorSec_Click(object sender, EventArgs e)
        {
            this.colorDialog.Color = this.pictureJerseyNumberColorSec.BackColor;
            int num = (int)this.colorDialog.ShowDialog();
            this.pictureJerseyNumberColorSec.BackColor = this.colorDialog.Color;
            this.m_CurrentKit.JerseyNumberColorSec = this.colorDialog.Color;
        }

        private void pictureJerseyNumberColorTer_Click(object sender, EventArgs e)
        {
            this.colorDialog.Color = this.pictureJerseyNumberColorTer.BackColor;
            int num = (int)this.colorDialog.ShowDialog();
            this.pictureJerseyNumberColorTer.BackColor = this.colorDialog.Color;
            this.m_CurrentKit.JerseyNumberColorTer = this.colorDialog.Color;
        }

        private void pictureShortsNumberColorPrim_Click(object sender, EventArgs e)
        {
            this.colorDialog.Color = this.pictureShortsNumberColorPrim.BackColor;
            int num = (int)this.colorDialog.ShowDialog();
            this.pictureShortsNumberColorPrim.BackColor = this.colorDialog.Color;
            this.m_CurrentKit.ShortsNumberColorPrim = this.colorDialog.Color;
        }

        private void pictureShortsNumberColorSec_Click(object sender, EventArgs e)
        {
            this.colorDialog.Color = this.pictureShortsNumberColorSec.BackColor;
            int num = (int)this.colorDialog.ShowDialog();
            this.pictureShortsNumberColorSec.BackColor = this.colorDialog.Color;
            this.m_CurrentKit.ShortsNumberColorSec = this.colorDialog.Color;
        }

        private void pictureShortsNumberColorTer_Click(object sender, EventArgs e)
        {
            this.colorDialog.Color = this.pictureShortsNumberColorTer.BackColor;
            int num = (int)this.colorDialog.ShowDialog();
            this.pictureShortsNumberColorTer.BackColor = this.colorDialog.Color;
            this.m_CurrentKit.ShortsNumberColorTer = this.colorDialog.Color;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KitForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.multiViewer2DKit = new FifaControls.MultiViewer2D();
            this.groupPositions = new System.Windows.Forms.GroupBox();
            this.toolStrip3D = new System.Windows.Forms.ToolStrip();
            this.buttonJerseyBadge = new System.Windows.Forms.ToolStripButton();
            this.buttonFrontNumber = new System.Windows.Forms.ToolStripButton();
            this.buttonBackName = new System.Windows.Forms.ToolStripButton();
            this.buttonNameCurvature = new System.Windows.Forms.ToolStripButton();
            this.buttonShortsNumber = new System.Windows.Forms.ToolStripButton();
            this.buttonShortsBadge = new System.Windows.Forms.ToolStripButton();
            this.buttonBackNumber = new System.Windows.Forms.ToolStripButton();
            this.buttonCopyPositions = new System.Windows.Forms.ToolStripButton();
            this.buttonPastePositions = new System.Windows.Forms.ToolStripButton();
            this.numericBottom = new System.Windows.Forms.NumericUpDown();
            this.numericTop = new System.Windows.Forms.NumericUpDown();
            this.numericRight = new System.Windows.Forms.NumericUpDown();
            this.numericLeft = new System.Windows.Forms.NumericUpDown();
            this.checkLink = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxIsEmbargoed = new System.Windows.Forms.CheckBox();
            this.kitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.numericTeamId = new System.Windows.Forms.NumericUpDown();
            this.labelTeamId = new System.Windows.Forms.Label();
            this.labelKitType = new System.Windows.Forms.Label();
            this.labelTeam = new System.Windows.Forms.Label();
            this.comboTeam = new System.Windows.Forms.ComboBox();
            this.teamListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboKitType = new System.Windows.Forms.ComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.group3D = new System.Windows.Forms.GroupBox();
            this.viewer3D = new FifaControls.FbxViewer3D();
            this.toolNear3D = new System.Windows.Forms.ToolStrip();
            this.buttonShow3DModel = new System.Windows.Forms.ToolStripButton();
            this.buttonRefresh3D = new System.Windows.Forms.ToolStripButton();
            this.buttonShowNumbers3D = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonCamera = new System.Windows.Forms.ToolStripButton();
            this.pictureShortsNumberColorTer = new System.Windows.Forms.PictureBox();
            this.pictureShortsNumberColorSec = new System.Windows.Forms.PictureBox();
            this.pictureShortsNumberColorPrim = new System.Windows.Forms.PictureBox();
            this.pictureJerseyNumberColorTer = new System.Windows.Forms.PictureBox();
            this.multiViewer2DShortsNumbers = new FifaControls.MultiViewer2D();
            this.pictureJerseyNumberColorSec = new System.Windows.Forms.PictureBox();
            this.pictureJerseyNumberColorPrim = new System.Windows.Forms.PictureBox();
            this.numericShortsNumberFont = new System.Windows.Forms.NumericUpDown();
            this.multiViewer2DJerseyNumbers = new FifaControls.MultiViewer2D();
            this.checkShortsNumber = new System.Windows.Forms.CheckBox();
            this.checkFrontNumber = new System.Windows.Forms.CheckBox();
            this.numericJerseyNumberFont = new System.Windows.Forms.NumericUpDown();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.viewer2DMinikit = new FifaControls.Viewer2D();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.groupCollar = new System.Windows.Forms.GroupBox();
            this.labelCollarImage = new System.Windows.Forms.Label();
            this.imageListCollar = new System.Windows.Forms.ImageList(this.components);
            this.checkIsFitting = new System.Windows.Forms.CheckBox();
            this.checkHasAdvertising = new System.Windows.Forms.CheckBox();
            this.pictureTeamTerColor = new System.Windows.Forms.PictureBox();
            this.pictureTeamPrimColor = new System.Windows.Forms.PictureBox();
            this.pictureTeamSecColor = new System.Windows.Forms.PictureBox();
            this.labelCollar = new System.Windows.Forms.Label();
            this.numericCollar = new System.Windows.Forms.NumericUpDown();
            this.groupName = new System.Windows.Forms.GroupBox();
            this.labelFont = new System.Windows.Forms.Label();
            this.toolStripNameFont = new System.Windows.Forms.ToolStrip();
            this.buttonPreviewNameFont = new System.Windows.Forms.ToolStripButton();
            this.buttonImportNameFont = new System.Windows.Forms.ToolStripButton();
            this.buttonDeleteNameFont = new System.Windows.Forms.ToolStripButton();
            this.buttonExportNameFont = new System.Windows.Forms.ToolStripButton();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkHasBackname = new System.Windows.Forms.CheckBox();
            this.numericNameFont = new System.Windows.Forms.NumericUpDown();
            this.labelNameFont = new System.Windows.Forms.Label();
            this.pictureNameColor = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboNameLayout = new System.Windows.Forms.ComboBox();
            this.pictureFont = new System.Windows.Forms.PictureBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            // 
            // colorDialog
            // 
            this.colorDialog.FullOpen = true;
            this.colorDialog.SolidColorOnly = true;
            this.pickUpControl = new FifaControls.PickUpControl();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.processFontView = new System.Diagnostics.Process();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupPositions.SuspendLayout();
            this.toolStrip3D.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTeamId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.group3D.SuspendLayout();
            this.toolNear3D.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureShortsNumberColorTer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureShortsNumberColorSec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureShortsNumberColorPrim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureJerseyNumberColorTer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureJerseyNumberColorSec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureJerseyNumberColorPrim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericShortsNumberFont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericJerseyNumberFont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.flowPanel.SuspendLayout();
            this.groupCollar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTeamTerColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTeamPrimColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTeamSecColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCollar)).BeginInit();
            this.groupName.SuspendLayout();
            this.toolStripNameFont.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericNameFont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureNameColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFont)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1357, 807);
            this.splitContainer1.SplitterDistance = 516;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.multiViewer2DKit);
            this.splitContainer3.Panel1.Controls.Add(this.groupPositions);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.checkBoxIsEmbargoed);
            this.splitContainer3.Panel2.Controls.Add(this.numericTeamId);
            this.splitContainer3.Panel2.Controls.Add(this.labelTeamId);
            this.splitContainer3.Panel2.Controls.Add(this.labelKitType);
            this.splitContainer3.Panel2.Controls.Add(this.labelTeam);
            this.splitContainer3.Panel2.Controls.Add(this.comboTeam);
            this.splitContainer3.Panel2.Controls.Add(this.comboKitType);
            this.splitContainer3.Size = new System.Drawing.Size(516, 807);
            this.splitContainer3.SplitterDistance = 683;
            this.splitContainer3.TabIndex = 0;
            // 
            // multiViewer2DKit
            // 
            this.multiViewer2DKit.AutoTransparency = false;
            this.multiViewer2DKit.Bitmaps = null;
            this.multiViewer2DKit.CheckBitmapSize = true;
            this.multiViewer2DKit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiViewer2DKit.FixedSize = false;
            this.multiViewer2DKit.FullSizeButton = true;
            this.multiViewer2DKit.LabelText = "Image n.";
            this.multiViewer2DKit.Location = new System.Drawing.Point(0, 0);
            this.multiViewer2DKit.Name = "multiViewer2DKit";
            this.multiViewer2DKit.ShowDeleteButton = true;
            this.multiViewer2DKit.Size = new System.Drawing.Size(512, 513);
            this.multiViewer2DKit.TabIndex = 0;
            // 
            // groupPositions
            // 
            this.groupPositions.Controls.Add(this.toolStrip3D);
            this.groupPositions.Controls.Add(this.numericBottom);
            this.groupPositions.Controls.Add(this.numericTop);
            this.groupPositions.Controls.Add(this.numericRight);
            this.groupPositions.Controls.Add(this.numericLeft);
            this.groupPositions.Controls.Add(this.checkLink);
            this.groupPositions.Controls.Add(this.label2);
            this.groupPositions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPositions.Location = new System.Drawing.Point(0, 513);
            this.groupPositions.Name = "groupPositions";
            this.groupPositions.Size = new System.Drawing.Size(512, 166);
            this.groupPositions.TabIndex = 3;
            this.groupPositions.TabStop = false;
            this.groupPositions.Text = "Positions";
            // 
            // toolStrip3D
            // 
            this.toolStrip3D.AutoSize = false;
            this.toolStrip3D.CanOverflow = false;
            this.toolStrip3D.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip3D.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3D.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonJerseyBadge,
            this.buttonFrontNumber,
            this.buttonBackName,
            this.buttonNameCurvature,
            this.buttonShortsNumber,
            this.buttonShortsBadge,
            this.buttonBackNumber,
            this.buttonCopyPositions,
            this.buttonPastePositions});
            this.toolStrip3D.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip3D.Location = new System.Drawing.Point(3, 16);
            this.toolStrip3D.Name = "toolStrip3D";
            this.toolStrip3D.Size = new System.Drawing.Size(201, 147);
            this.toolStrip3D.TabIndex = 190;
            this.toolStrip3D.Text = "toolStrip1";
            // 
            // buttonJerseyBadge
            // 
            this.buttonJerseyBadge.AutoToolTip = false;
            this.buttonJerseyBadge.Checked = true;
            this.buttonJerseyBadge.CheckOnClick = true;
            this.buttonJerseyBadge.CheckState = System.Windows.Forms.CheckState.Checked;
            this.buttonJerseyBadge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonJerseyBadge.Image = ((System.Drawing.Image)(resources.GetObject("buttonJerseyBadge.Image")));
            this.buttonJerseyBadge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonJerseyBadge.Name = "buttonJerseyBadge";
            this.buttonJerseyBadge.Size = new System.Drawing.Size(105, 21);
            this.buttonJerseyBadge.Text = "  Jersey Badge  ";
            this.buttonJerseyBadge.Click += new System.EventHandler(this.buttonPositions_Click);
            // 
            // buttonFrontNumber
            // 
            this.buttonFrontNumber.AutoToolTip = false;
            this.buttonFrontNumber.CheckOnClick = true;
            this.buttonFrontNumber.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonFrontNumber.Image = ((System.Drawing.Image)(resources.GetObject("buttonFrontNumber.Image")));
            this.buttonFrontNumber.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonFrontNumber.Name = "buttonFrontNumber";
            this.buttonFrontNumber.Size = new System.Drawing.Size(102, 21);
            this.buttonFrontNumber.Text = " Front Number ";
            this.buttonFrontNumber.Click += new System.EventHandler(this.buttonPositions_Click);
            // 
            // buttonBackName
            // 
            this.buttonBackName.AutoToolTip = false;
            this.buttonBackName.CheckOnClick = true;
            this.buttonBackName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonBackName.Image = ((System.Drawing.Image)(resources.GetObject("buttonBackName.Image")));
            this.buttonBackName.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonBackName.Name = "buttonBackName";
            this.buttonBackName.Size = new System.Drawing.Size(101, 21);
            this.buttonBackName.Text = "   Back Name   ";
            this.buttonBackName.Click += new System.EventHandler(this.buttonPositions_Click);
            // 
            // buttonNameCurvature
            // 
            this.buttonNameCurvature.AutoToolTip = false;
            this.buttonNameCurvature.CheckOnClick = true;
            this.buttonNameCurvature.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonNameCurvature.Image = ((System.Drawing.Image)(resources.GetObject("buttonNameCurvature.Image")));
            this.buttonNameCurvature.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonNameCurvature.Name = "buttonNameCurvature";
            this.buttonNameCurvature.Size = new System.Drawing.Size(107, 21);
            this.buttonNameCurvature.Text = "Name Curvature";
            this.buttonNameCurvature.Click += new System.EventHandler(this.buttonPositions_Click);
            // 
            // buttonShortsNumber
            // 
            this.buttonShortsNumber.AutoToolTip = false;
            this.buttonShortsNumber.CheckOnClick = true;
            this.buttonShortsNumber.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonShortsNumber.Image = ((System.Drawing.Image)(resources.GetObject("buttonShortsNumber.Image")));
            this.buttonShortsNumber.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonShortsNumber.Name = "buttonShortsNumber";
            this.buttonShortsNumber.Size = new System.Drawing.Size(101, 21);
            this.buttonShortsNumber.Text = "Shorts Number";
            this.buttonShortsNumber.Click += new System.EventHandler(this.buttonPositions_Click);
            // 
            // buttonShortsBadge
            // 
            this.buttonShortsBadge.AutoToolTip = false;
            this.buttonShortsBadge.CheckOnClick = true;
            this.buttonShortsBadge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonShortsBadge.Image = ((System.Drawing.Image)(resources.GetObject("buttonShortsBadge.Image")));
            this.buttonShortsBadge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonShortsBadge.Name = "buttonShortsBadge";
            this.buttonShortsBadge.Size = new System.Drawing.Size(98, 21);
            this.buttonShortsBadge.Text = " Shorts Badge ";
            this.buttonShortsBadge.Click += new System.EventHandler(this.buttonPositions_Click);
            // 
            // buttonBackNumber
            // 
            this.buttonBackNumber.AutoToolTip = false;
            this.buttonBackNumber.CheckOnClick = true;
            this.buttonBackNumber.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonBackNumber.Image = ((System.Drawing.Image)(resources.GetObject("buttonBackNumber.Image")));
            this.buttonBackNumber.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonBackNumber.Name = "buttonBackNumber";
            this.buttonBackNumber.Size = new System.Drawing.Size(98, 21);
            this.buttonBackNumber.Text = " Back Number ";
            this.buttonBackNumber.Click += new System.EventHandler(this.buttonPositions_Click);
            // 
            // buttonCopyPositions
            // 
            this.buttonCopyPositions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonCopyPositions.Image = ((System.Drawing.Image)(resources.GetObject("buttonCopyPositions.Image")));
            this.buttonCopyPositions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonCopyPositions.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.buttonCopyPositions.Name = "buttonCopyPositions";
            this.buttonCopyPositions.Size = new System.Drawing.Size(23, 20);
            this.buttonCopyPositions.Text = "Copy All Positions";
            this.buttonCopyPositions.Click += new System.EventHandler(this.buttonCopyPositions_Click);
            // 
            // buttonPastePositions
            // 
            this.buttonPastePositions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPastePositions.Image = ((System.Drawing.Image)(resources.GetObject("buttonPastePositions.Image")));
            this.buttonPastePositions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPastePositions.Name = "buttonPastePositions";
            this.buttonPastePositions.Size = new System.Drawing.Size(23, 20);
            this.buttonPastePositions.Text = "Paste All Positions";
            this.buttonPastePositions.Click += new System.EventHandler(this.buttonPastePositions_Click);
            // 
            // numericBottom
            // 
            this.numericBottom.DecimalPlaces = 3;
            this.numericBottom.Enabled = false;
            this.numericBottom.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericBottom.Location = new System.Drawing.Point(302, 74);
            this.numericBottom.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numericBottom.Name = "numericBottom";
            this.numericBottom.Size = new System.Drawing.Size(64, 20);
            this.numericBottom.TabIndex = 178;
            this.numericBottom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericBottom.ValueChanged += new System.EventHandler(this.numericPositions_ValueChanged);
            // 
            // numericTop
            // 
            this.numericTop.DecimalPlaces = 3;
            this.numericTop.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericTop.Location = new System.Drawing.Point(300, 17);
            this.numericTop.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numericTop.Name = "numericTop";
            this.numericTop.Size = new System.Drawing.Size(64, 20);
            this.numericTop.TabIndex = 174;
            this.numericTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericTop.ValueChanged += new System.EventHandler(this.numericPositions_ValueChanged);
            // 
            // numericRight
            // 
            this.numericRight.DecimalPlaces = 3;
            this.numericRight.Enabled = false;
            this.numericRight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericRight.Location = new System.Drawing.Point(359, 44);
            this.numericRight.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numericRight.Name = "numericRight";
            this.numericRight.Size = new System.Drawing.Size(64, 20);
            this.numericRight.TabIndex = 172;
            this.numericRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericRight.ValueChanged += new System.EventHandler(this.numericPositions_ValueChanged);
            // 
            // numericLeft
            // 
            this.numericLeft.DecimalPlaces = 3;
            this.numericLeft.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericLeft.Location = new System.Drawing.Point(237, 46);
            this.numericLeft.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numericLeft.Name = "numericLeft";
            this.numericLeft.Size = new System.Drawing.Size(64, 20);
            this.numericLeft.TabIndex = 173;
            this.numericLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericLeft.ValueChanged += new System.EventHandler(this.numericPositions_ValueChanged);
            // 
            // checkLink
            // 
            this.checkLink.AutoSize = true;
            this.checkLink.Checked = true;
            this.checkLink.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkLink.Location = new System.Drawing.Point(307, 47);
            this.checkLink.Name = "checkLink";
            this.checkLink.Size = new System.Drawing.Size(46, 17);
            this.checkLink.TabIndex = 189;
            this.checkLink.Text = "Link";
            this.checkLink.UseVisualStyleBackColor = true;
            this.checkLink.CheckedChanged += new System.EventHandler(this.checkLink_CheckedChanged);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(263, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 56);
            this.label2.TabIndex = 188;
            // 
            // checkBoxIsEmbargoed
            // 
            this.checkBoxIsEmbargoed.AutoSize = true;
            this.checkBoxIsEmbargoed.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.kitBindingSource, "IsEmbargoed", true, DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxIsEmbargoed.Location = new System.Drawing.Point(230, 36);
            this.checkBoxIsEmbargoed.Name = "checkBoxIsEmbargoed";
            this.checkBoxIsEmbargoed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxIsEmbargoed.Size = new System.Drawing.Size(91, 17);
            this.checkBoxIsEmbargoed.TabIndex = 153;
            this.checkBoxIsEmbargoed.Text = "Is Embargoed";
            this.checkBoxIsEmbargoed.UseVisualStyleBackColor = true;
            // 
            // kitBindingSource
            // 
            this.kitBindingSource.DataSource = typeof(FifaLibrary.Kit);
            // 
            // numericTeamId
            // 
            this.numericTeamId.BackColor = System.Drawing.SystemColors.Window;
            this.numericTeamId.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.kitBindingSource, "teamid", true));
            this.numericTeamId.Enabled = false;
            this.numericTeamId.Location = new System.Drawing.Point(106, 35);
            this.numericTeamId.Maximum = new decimal(new int[] {
            300000,
            0,
            0,
            0});
            this.numericTeamId.Name = "numericTeamId";
            this.numericTeamId.ReadOnly = true;
            this.numericTeamId.Size = new System.Drawing.Size(98, 20);
            this.numericTeamId.TabIndex = 11;
            this.numericTeamId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelTeamId
            // 
            this.labelTeamId.AutoSize = true;
            this.labelTeamId.Location = new System.Drawing.Point(10, 42);
            this.labelTeamId.Name = "labelTeamId";
            this.labelTeamId.Size = new System.Drawing.Size(46, 13);
            this.labelTeamId.TabIndex = 4;
            this.labelTeamId.Text = "Team Id";
            // 
            // labelKitType
            // 
            this.labelKitType.AutoSize = true;
            this.labelKitType.Location = new System.Drawing.Point(227, 11);
            this.labelKitType.Name = "labelKitType";
            this.labelKitType.Size = new System.Drawing.Size(19, 13);
            this.labelKitType.TabIndex = 3;
            this.labelKitType.Text = "Kit";
            // 
            // labelTeam
            // 
            this.labelTeam.AutoSize = true;
            this.labelTeam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTeam.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelTeam.Location = new System.Drawing.Point(10, 11);
            this.labelTeam.Name = "labelTeam";
            this.labelTeam.Size = new System.Drawing.Size(34, 13);
            this.labelTeam.TabIndex = 2;
            this.labelTeam.Text = "Team";
            this.labelTeam.DoubleClick += new System.EventHandler(this.labelTeam_DoubleClick);
            // 
            // comboTeam
            // 
            this.comboTeam.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.kitBindingSource, "Team", true));
            this.comboTeam.DataSource = this.teamListBindingSource;
            this.comboTeam.Enabled = false;
            this.comboTeam.FormattingEnabled = true;
            this.comboTeam.Location = new System.Drawing.Point(50, 8);
            this.comboTeam.Name = "comboTeam";
            this.comboTeam.Size = new System.Drawing.Size(154, 21);
            this.comboTeam.TabIndex = 0;
            // 
            // teamListBindingSource
            // 
            this.teamListBindingSource.DataSource = typeof(FifaLibrary.TeamList);
            // 
            // comboKitType
            // 
            this.comboKitType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.kitBindingSource, "kittype", true));
            this.comboKitType.Enabled = false;
            this.comboKitType.FormattingEnabled = true;
            this.comboKitType.Items.AddRange(new object[] {
            "Home",
            "Away",
            "Goalkeeper",
            "3rd",
            "4th",
            "5th",
            "6th",
            "7th",
            "8th",
            "9th",
            "10th"});
            this.comboKitType.Location = new System.Drawing.Point(271, 8);
            this.comboKitType.Name = "comboKitType";
            this.comboKitType.Size = new System.Drawing.Size(114, 21);
            this.comboKitType.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer2.Size = new System.Drawing.Size(837, 807);
            this.splitContainer2.SplitterDistance = 430;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.group3D);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.AutoScroll = true;
            this.splitContainer4.Panel2.Controls.Add(this.pictureShortsNumberColorTer);
            this.splitContainer4.Panel2.Controls.Add(this.pictureShortsNumberColorSec);
            this.splitContainer4.Panel2.Controls.Add(this.pictureShortsNumberColorPrim);
            this.splitContainer4.Panel2.Controls.Add(this.pictureJerseyNumberColorTer);
            this.splitContainer4.Panel2.Controls.Add(this.multiViewer2DShortsNumbers);
            this.splitContainer4.Panel2.Controls.Add(this.pictureJerseyNumberColorSec);
            this.splitContainer4.Panel2.Controls.Add(this.pictureJerseyNumberColorPrim);
            this.splitContainer4.Panel2.Controls.Add(this.numericShortsNumberFont);
            this.splitContainer4.Panel2.Controls.Add(this.multiViewer2DJerseyNumbers);
            this.splitContainer4.Panel2.Controls.Add(this.checkShortsNumber);
            this.splitContainer4.Panel2.Controls.Add(this.checkFrontNumber);
            this.splitContainer4.Panel2.Controls.Add(this.numericJerseyNumberFont);
            this.splitContainer4.Size = new System.Drawing.Size(430, 807);
            this.splitContainer4.SplitterDistance = 577;
            this.splitContainer4.TabIndex = 0;
            // 
            // group3D
            // 
            this.group3D.Controls.Add(this.viewer3D);
            this.group3D.Controls.Add(this.toolNear3D);
            this.group3D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group3D.Location = new System.Drawing.Point(0, 0);
            this.group3D.Name = "group3D";
            this.group3D.Size = new System.Drawing.Size(426, 573);
            this.group3D.TabIndex = 2;
            this.group3D.TabStop = false;
            this.group3D.Text = "3D Model";
            // 
            // viewer3D
            // 
            this.viewer3D.AmbientColor = System.Drawing.Color.White;
            this.viewer3D.BackColor = System.Drawing.Color.Gray;
            this.viewer3D.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.viewer3D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer3D.FilesPath = null;
            this.viewer3D.Location = new System.Drawing.Point(3, 16);
            this.viewer3D.Name = "viewer3D";
            this.viewer3D.ObjectId = -1;
            this.viewer3D.ObjectType = FifaControls.FbxViewer3D.ObjectTypeServerPort.Kit;
            this.viewer3D.Size = new System.Drawing.Size(420, 529);
            this.viewer3D.TabIndex = 0;
            this.viewer3D.Textures = null;
            // 
            // toolNear3D
            // 
            this.toolNear3D.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolNear3D.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolNear3D.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonShow3DModel,
            this.buttonRefresh3D,
            this.buttonShowNumbers3D,
            this.toolStripSeparator1,
            this.buttonCamera});
            this.toolNear3D.Location = new System.Drawing.Point(3, 545);
            this.toolNear3D.Name = "toolNear3D";
            this.toolNear3D.Size = new System.Drawing.Size(420, 25);
            this.toolNear3D.TabIndex = 2;
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
            // buttonRefresh3D
            // 
            this.buttonRefresh3D.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRefresh3D.Image = ((System.Drawing.Image)(resources.GetObject("buttonRefresh3D.Image")));
            this.buttonRefresh3D.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRefresh3D.Name = "buttonRefresh3D";
            this.buttonRefresh3D.Size = new System.Drawing.Size(23, 22);
            this.buttonRefresh3D.Text = "Refresh 3D View";
            this.buttonRefresh3D.Click += new System.EventHandler(this.buttonRefresh3D_Click);
            // 
            // buttonShowNumbers3D
            // 
            this.buttonShowNumbers3D.CheckOnClick = true;
            this.buttonShowNumbers3D.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonShowNumbers3D.Image = ((System.Drawing.Image)(resources.GetObject("buttonShowNumbers3D.Image")));
            this.buttonShowNumbers3D.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonShowNumbers3D.Name = "buttonShowNumbers3D";
            this.buttonShowNumbers3D.Size = new System.Drawing.Size(23, 22);
            this.buttonShowNumbers3D.Text = "Show Numbers";
            this.buttonShowNumbers3D.Click += new System.EventHandler(this.buttonShowNumbers3D_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonCamera
            // 
            this.buttonCamera.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonCamera.Image = ((System.Drawing.Image)(resources.GetObject("buttonCamera.Image")));
            this.buttonCamera.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonCamera.Name = "buttonCamera";
            this.buttonCamera.Size = new System.Drawing.Size(23, 22);
            this.buttonCamera.Text = "Take a picture for minikit";
            this.buttonCamera.Click += new System.EventHandler(this.buttonCamera_Click);
            // 
            // pictureShortsNumberColorTer
            // 
            this.pictureShortsNumberColorTer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureShortsNumberColorTer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureShortsNumberColorTer.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", this.kitBindingSource, "ShortsNumberColorTer", true));
            this.pictureShortsNumberColorTer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureShortsNumberColorTer.Location = new System.Drawing.Point(358, 151);
            this.pictureShortsNumberColorTer.Name = "pictureShortsNumberColorTer";
            this.pictureShortsNumberColorTer.Size = new System.Drawing.Size(24, 24);
            this.pictureShortsNumberColorTer.TabIndex = 156;
            this.pictureShortsNumberColorTer.TabStop = false;
            this.pictureShortsNumberColorTer.Click += new System.EventHandler(this.pictureShortsNumberColorTer_Click);
            // 
            // pictureShortsNumberColorSec
            // 
            this.pictureShortsNumberColorSec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureShortsNumberColorSec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureShortsNumberColorSec.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", this.kitBindingSource, "ShortsNumberColorSec", true));
            this.pictureShortsNumberColorSec.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureShortsNumberColorSec.Location = new System.Drawing.Point(358, 121);
            this.pictureShortsNumberColorSec.Name = "pictureShortsNumberColorSec";
            this.pictureShortsNumberColorSec.Size = new System.Drawing.Size(24, 24);
            this.pictureShortsNumberColorSec.TabIndex = 155;
            this.pictureShortsNumberColorSec.TabStop = false;
            this.pictureShortsNumberColorSec.Click += new System.EventHandler(this.pictureShortsNumberColorSec_Click);
            // 
            // pictureShortsNumberColorPrim
            // 
            this.pictureShortsNumberColorPrim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureShortsNumberColorPrim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureShortsNumberColorPrim.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", this.kitBindingSource, "ShortsNumberColorPrim", true));
            this.pictureShortsNumberColorPrim.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureShortsNumberColorPrim.Location = new System.Drawing.Point(358, 91);
            this.pictureShortsNumberColorPrim.Name = "pictureShortsNumberColorPrim";
            this.pictureShortsNumberColorPrim.Size = new System.Drawing.Size(24, 24);
            this.pictureShortsNumberColorPrim.TabIndex = 154;
            this.pictureShortsNumberColorPrim.TabStop = false;
            this.pictureShortsNumberColorPrim.Click += new System.EventHandler(this.pictureShortsNumberColorPrim_Click);
            // 
            // pictureJerseyNumberColorTer
            // 
            this.pictureJerseyNumberColorTer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureJerseyNumberColorTer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureJerseyNumberColorTer.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", this.kitBindingSource, "JerseyNumberColorTer", true));
            this.pictureJerseyNumberColorTer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureJerseyNumberColorTer.Location = new System.Drawing.Point(151, 151);
            this.pictureJerseyNumberColorTer.Name = "pictureJerseyNumberColorTer";
            this.pictureJerseyNumberColorTer.Size = new System.Drawing.Size(24, 24);
            this.pictureJerseyNumberColorTer.TabIndex = 153;
            this.pictureJerseyNumberColorTer.TabStop = false;
            this.pictureJerseyNumberColorTer.Click += new System.EventHandler(this.pictureJerseyNumberColorTer_Click);
            // 
            // multiViewer2DShortsNumbers
            // 
            this.multiViewer2DShortsNumbers.AutoTransparency = true;
            this.multiViewer2DShortsNumbers.Bitmaps = null;
            this.multiViewer2DShortsNumbers.CheckBitmapSize = true;
            this.multiViewer2DShortsNumbers.FixedSize = false;
            this.multiViewer2DShortsNumbers.FullSizeButton = false;
            this.multiViewer2DShortsNumbers.LabelText = "Shorts";
            this.multiViewer2DShortsNumbers.Location = new System.Drawing.Point(220, 37);
            this.multiViewer2DShortsNumbers.Name = "multiViewer2DShortsNumbers";
            this.multiViewer2DShortsNumbers.ShowDeleteButton = false;
            this.multiViewer2DShortsNumbers.Size = new System.Drawing.Size(132, 178);
            this.multiViewer2DShortsNumbers.TabIndex = 1;
            // 
            // pictureJerseyNumberColorSec
            // 
            this.pictureJerseyNumberColorSec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureJerseyNumberColorSec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureJerseyNumberColorSec.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", this.kitBindingSource, "JerseyNumberColorSec", true));
            this.pictureJerseyNumberColorSec.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureJerseyNumberColorSec.Location = new System.Drawing.Point(151, 121);
            this.pictureJerseyNumberColorSec.Name = "pictureJerseyNumberColorSec";
            this.pictureJerseyNumberColorSec.Size = new System.Drawing.Size(24, 24);
            this.pictureJerseyNumberColorSec.TabIndex = 152;
            this.pictureJerseyNumberColorSec.TabStop = false;
            this.pictureJerseyNumberColorSec.Click += new System.EventHandler(this.pictureJerseyNumberColorSec_Click);
            // 
            // pictureJerseyNumberColorPrim
            // 
            this.pictureJerseyNumberColorPrim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureJerseyNumberColorPrim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureJerseyNumberColorPrim.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", this.kitBindingSource, "JerseyNumberColorPrim", true));
            this.pictureJerseyNumberColorPrim.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureJerseyNumberColorPrim.Location = new System.Drawing.Point(151, 91);
            this.pictureJerseyNumberColorPrim.Name = "pictureJerseyNumberColorPrim";
            this.pictureJerseyNumberColorPrim.Size = new System.Drawing.Size(24, 24);
            this.pictureJerseyNumberColorPrim.TabIndex = 151;
            this.pictureJerseyNumberColorPrim.TabStop = false;
            this.pictureJerseyNumberColorPrim.Click += new System.EventHandler(this.pictureJerseyNumberColorPrim_Click);
            // 
            // numericShortsNumberFont
            // 
            this.numericShortsNumberFont.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.kitBindingSource, "shortsNumberFont", true));
            this.numericShortsNumberFont.Location = new System.Drawing.Point(358, 65);
            this.numericShortsNumberFont.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericShortsNumberFont.Name = "numericShortsNumberFont";
            this.numericShortsNumberFont.Size = new System.Drawing.Size(55, 20);
            this.numericShortsNumberFont.TabIndex = 12;
            this.numericShortsNumberFont.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericShortsNumberFont.ValueChanged += new System.EventHandler(this.numericShortsNumberFont_ValueChanged);
            // 
            // multiViewer2DJerseyNumbers
            // 
            this.multiViewer2DJerseyNumbers.AutoTransparency = true;
            this.multiViewer2DJerseyNumbers.Bitmaps = null;
            this.multiViewer2DJerseyNumbers.CheckBitmapSize = true;
            this.multiViewer2DJerseyNumbers.FixedSize = false;
            this.multiViewer2DJerseyNumbers.FullSizeButton = false;
            this.multiViewer2DJerseyNumbers.LabelText = "Jersey";
            this.multiViewer2DJerseyNumbers.Location = new System.Drawing.Point(13, 37);
            this.multiViewer2DJerseyNumbers.Name = "multiViewer2DJerseyNumbers";
            this.multiViewer2DJerseyNumbers.ShowDeleteButton = false;
            this.multiViewer2DJerseyNumbers.Size = new System.Drawing.Size(132, 178);
            this.multiViewer2DJerseyNumbers.TabIndex = 0;
            // 
            // checkShortsNumber
            // 
            this.checkShortsNumber.AutoSize = true;
            this.checkShortsNumber.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.kitBindingSource, "shortsNumber", true));
            this.checkShortsNumber.Location = new System.Drawing.Point(220, 20);
            this.checkShortsNumber.Name = "checkShortsNumber";
            this.checkShortsNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkShortsNumber.Size = new System.Drawing.Size(117, 17);
            this.checkShortsNumber.TabIndex = 4;
            this.checkShortsNumber.Text = "Shorts Number       ";
            this.checkShortsNumber.UseVisualStyleBackColor = true;
            this.checkShortsNumber.CheckedChanged += new System.EventHandler(this.checkShortsNumber_CheckedChanged);
            // 
            // checkFrontNumber
            // 
            this.checkFrontNumber.AutoSize = true;
            this.checkFrontNumber.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.kitBindingSource, "jerseyFrontNumber", true));
            this.checkFrontNumber.Location = new System.Drawing.Point(13, 20);
            this.checkFrontNumber.Name = "checkFrontNumber";
            this.checkFrontNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkFrontNumber.Size = new System.Drawing.Size(105, 17);
            this.checkFrontNumber.TabIndex = 3;
            this.checkFrontNumber.Text = "Front Number     ";
            this.checkFrontNumber.UseVisualStyleBackColor = true;
            this.checkFrontNumber.CheckedChanged += new System.EventHandler(this.checkFrontNumber_CheckedChanged);
            // 
            // numericJerseyNumberFont
            // 
            this.numericJerseyNumberFont.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.kitBindingSource, "jerseyNumberFont", true));
            this.numericJerseyNumberFont.Location = new System.Drawing.Point(151, 65);
            this.numericJerseyNumberFont.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericJerseyNumberFont.Name = "numericJerseyNumberFont";
            this.numericJerseyNumberFont.Size = new System.Drawing.Size(55, 20);
            this.numericJerseyNumberFont.TabIndex = 10;
            this.numericJerseyNumberFont.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericJerseyNumberFont.ValueChanged += new System.EventHandler(this.numericJerseyNumberFont_ValueChanged);
            // 
            // splitContainer5
            // 
            this.splitContainer5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.viewer2DMinikit);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.flowPanel);
            this.splitContainer5.Size = new System.Drawing.Size(403, 807);
            this.splitContainer5.SplitterDistance = 298;
            this.splitContainer5.TabIndex = 0;
            // 
            // viewer2DMinikit
            // 
            this.viewer2DMinikit.AutoTransparency = true;
            this.viewer2DMinikit.BackColor = System.Drawing.Color.Transparent;
            this.viewer2DMinikit.ButtonStripVisible = true;
            this.viewer2DMinikit.CurrentBitmap = null;
            this.viewer2DMinikit.ExtendedFormat = false;
            this.viewer2DMinikit.FullSizeButton = false;
            this.viewer2DMinikit.ImageLayout = System.Windows.Forms.ImageLayout.None;
            this.viewer2DMinikit.ImageSize = new System.Drawing.Size(256, 256);
            this.viewer2DMinikit.ImageSizeMultiplier = FifaControls.Viewer2D.SizeMultiplier.None;
            this.viewer2DMinikit.Location = new System.Drawing.Point(0, 0);
            this.viewer2DMinikit.Name = "viewer2DMinikit";
            this.viewer2DMinikit.RemoveButton = true;
            this.viewer2DMinikit.ShowButton = true;
            this.viewer2DMinikit.ShowButtonChecked = true;
            this.viewer2DMinikit.Size = new System.Drawing.Size(256, 281);
            this.viewer2DMinikit.TabIndex = 0;
            // 
            // flowPanel
            // 
            this.flowPanel.AutoScroll = true;
            this.flowPanel.Controls.Add(this.groupCollar);
            this.flowPanel.Controls.Add(this.groupName);
            this.flowPanel.Controls.Add(this.pictureFont);
            this.flowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanel.Location = new System.Drawing.Point(0, 0);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(399, 501);
            this.flowPanel.TabIndex = 0;
            // 
            // groupCollar
            // 
            this.groupCollar.Controls.Add(this.labelCollarImage);
            this.groupCollar.Controls.Add(this.checkIsFitting);
            this.groupCollar.Controls.Add(this.checkHasAdvertising);
            this.groupCollar.Controls.Add(this.pictureTeamTerColor);
            this.groupCollar.Controls.Add(this.pictureTeamPrimColor);
            this.groupCollar.Controls.Add(this.pictureTeamSecColor);
            this.groupCollar.Controls.Add(this.labelCollar);
            this.groupCollar.Controls.Add(this.numericCollar);
            this.groupCollar.Location = new System.Drawing.Point(3, 3);
            this.groupCollar.Name = "groupCollar";
            this.groupCollar.Size = new System.Drawing.Size(386, 173);
            this.groupCollar.TabIndex = 1;
            this.groupCollar.TabStop = false;
            this.groupCollar.Text = "Jersey";
            // 
            // labelCollarImage
            // 
            this.labelCollarImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCollarImage.ImageList = this.imageListCollar;
            this.labelCollarImage.Location = new System.Drawing.Point(9, 44);
            this.labelCollarImage.Name = "labelCollarImage";
            this.labelCollarImage.Size = new System.Drawing.Size(210, 120);
            this.labelCollarImage.TabIndex = 154;
            // 
            // imageListCollar
            // 
            this.imageListCollar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListCollar.ImageStream")));
            this.imageListCollar.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListCollar.Images.SetKeyName(0, "collar00.png");
            this.imageListCollar.Images.SetKeyName(1, "collar1.png");
            this.imageListCollar.Images.SetKeyName(2, "collar2.png");
            this.imageListCollar.Images.SetKeyName(3, "collar3.png");
            this.imageListCollar.Images.SetKeyName(4, "collar4.png");
            this.imageListCollar.Images.SetKeyName(5, "collar5.png");
            this.imageListCollar.Images.SetKeyName(6, "collar6.png");
            this.imageListCollar.Images.SetKeyName(7, "collar7.png");
            this.imageListCollar.Images.SetKeyName(8, "collar8.png");
            this.imageListCollar.Images.SetKeyName(9, "collar9.png");
            this.imageListCollar.Images.SetKeyName(10, "collar10.png");
            this.imageListCollar.Images.SetKeyName(11, "collar11.png");
            this.imageListCollar.Images.SetKeyName(12, "collar12.png");
            this.imageListCollar.Images.SetKeyName(13, "collar13.png");
            this.imageListCollar.Images.SetKeyName(14, "collar14.png");
            this.imageListCollar.Images.SetKeyName(15, "collar15.png");
            // 
            // checkIsFitting
            // 
            this.checkIsFitting.AutoSize = true;
            this.checkIsFitting.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.kitBindingSource, "jerseyfit", true, DataSourceUpdateMode.OnPropertyChanged));
            this.checkIsFitting.Location = new System.Drawing.Point(245, 42);
            this.checkIsFitting.Name = "checkIsFitting";
            this.checkIsFitting.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkIsFitting.Size = new System.Drawing.Size(65, 17);
            this.checkIsFitting.TabIndex = 152;
            this.checkIsFitting.Text = "Is Fitting";
            this.checkIsFitting.UseVisualStyleBackColor = true;
            // 
            // checkHasAdvertising
            // 
            this.checkHasAdvertising.AutoSize = true;
            this.checkHasAdvertising.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.kitBindingSource, "hasadvertisingkit", true, DataSourceUpdateMode.OnPropertyChanged));
            this.checkHasAdvertising.Location = new System.Drawing.Point(246, 19);
            this.checkHasAdvertising.Name = "checkHasAdvertising";
            this.checkHasAdvertising.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkHasAdvertising.Size = new System.Drawing.Size(118, 17);
            this.checkHasAdvertising.TabIndex = 151;
            this.checkHasAdvertising.Text = "Has Advertising      ";
            this.checkHasAdvertising.UseVisualStyleBackColor = true;
            // 
            // pictureTeamTerColor
            // 
            this.pictureTeamTerColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureTeamTerColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureTeamTerColor.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", this.kitBindingSource, "TeamColor3", true));
            this.pictureTeamTerColor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureTeamTerColor.Location = new System.Drawing.Point(329, 98);
            this.pictureTeamTerColor.Name = "pictureTeamTerColor";
            this.pictureTeamTerColor.Size = new System.Drawing.Size(24, 24);
            this.pictureTeamTerColor.TabIndex = 150;
            this.pictureTeamTerColor.TabStop = false;
            this.pictureTeamTerColor.Click += new System.EventHandler(this.pictureTeamTerColor_Click);
            // 
            // pictureTeamPrimColor
            // 
            this.pictureTeamPrimColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureTeamPrimColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureTeamPrimColor.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", this.kitBindingSource, "TeamColor1", true));
            this.pictureTeamPrimColor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureTeamPrimColor.Location = new System.Drawing.Point(255, 98);
            this.pictureTeamPrimColor.Name = "pictureTeamPrimColor";
            this.pictureTeamPrimColor.Size = new System.Drawing.Size(24, 24);
            this.pictureTeamPrimColor.TabIndex = 148;
            this.pictureTeamPrimColor.TabStop = false;
            this.pictureTeamPrimColor.Click += new System.EventHandler(this.pictureTeamPrimColor_Click);
            // 
            // pictureTeamSecColor
            // 
            this.pictureTeamSecColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureTeamSecColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureTeamSecColor.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", this.kitBindingSource, "TeamColor2", true));
            this.pictureTeamSecColor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureTeamSecColor.Location = new System.Drawing.Point(292, 98);
            this.pictureTeamSecColor.Name = "pictureTeamSecColor";
            this.pictureTeamSecColor.Size = new System.Drawing.Size(24, 24);
            this.pictureTeamSecColor.TabIndex = 149;
            this.pictureTeamSecColor.TabStop = false;
            this.pictureTeamSecColor.Click += new System.EventHandler(this.pictureTeamSecColor_Click);
            // 
            // labelCollar
            // 
            this.labelCollar.AutoSize = true;
            this.labelCollar.Location = new System.Drawing.Point(6, 21);
            this.labelCollar.Name = "labelCollar";
            this.labelCollar.Size = new System.Drawing.Size(33, 13);
            this.labelCollar.TabIndex = 1;
            this.labelCollar.Text = "Collar";
            // 
            // numericCollar
            // 
            this.numericCollar.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.kitBindingSource, "jerseyCollar", true));
            this.numericCollar.Location = new System.Drawing.Point(111, 14);
            this.numericCollar.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericCollar.Name = "numericCollar";
            this.numericCollar.Size = new System.Drawing.Size(108, 20);
            this.numericCollar.TabIndex = 0;
            this.numericCollar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericCollar.ValueChanged += new System.EventHandler(this.numericCollar_ValueChanged);
            // 
            // groupName
            // 
            this.groupName.Controls.Add(this.labelFont);
            this.groupName.Controls.Add(this.toolStripNameFont);
            this.groupName.Controls.Add(this.label3);
            this.groupName.Controls.Add(this.comboBox1);
            this.groupName.Controls.Add(this.checkHasBackname);
            this.groupName.Controls.Add(this.numericNameFont);
            this.groupName.Controls.Add(this.labelNameFont);
            this.groupName.Controls.Add(this.pictureNameColor);
            this.groupName.Controls.Add(this.label1);
            this.groupName.Controls.Add(this.comboNameLayout);
            this.groupName.Location = new System.Drawing.Point(3, 182);
            this.groupName.Name = "groupName";
            this.groupName.Size = new System.Drawing.Size(386, 151);
            this.groupName.TabIndex = 2;
            this.groupName.TabStop = false;
            this.groupName.Text = "Name";
            // 
            // labelFont
            // 
            this.labelFont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelFont.Location = new System.Drawing.Point(265, 42);
            this.labelFont.Name = "labelFont";
            this.labelFont.Size = new System.Drawing.Size(100, 92);
            this.labelFont.TabIndex = 5;
            this.labelFont.Visible = false;
            // 
            // toolStripNameFont
            // 
            this.toolStripNameFont.AutoSize = false;
            this.toolStripNameFont.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripNameFont.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripNameFont.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonPreviewNameFont,
            this.buttonImportNameFont,
            this.buttonDeleteNameFont,
            this.buttonExportNameFont});
            this.toolStripNameFont.Location = new System.Drawing.Point(9, 66);
            this.toolStripNameFont.Name = "toolStripNameFont";
            this.toolStripNameFont.Size = new System.Drawing.Size(241, 25);
            this.toolStripNameFont.TabIndex = 148;
            // 
            // buttonPreviewNameFont
            // 
            this.buttonPreviewNameFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPreviewNameFont.Image = ((System.Drawing.Image)(resources.GetObject("buttonPreviewNameFont.Image")));
            this.buttonPreviewNameFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPreviewNameFont.Margin = new System.Windows.Forms.Padding(70, 1, 0, 2);
            this.buttonPreviewNameFont.Name = "buttonPreviewNameFont";
            this.buttonPreviewNameFont.Size = new System.Drawing.Size(23, 22);
            this.buttonPreviewNameFont.Text = "Preview Font";
            this.buttonPreviewNameFont.Visible = false;
            this.buttonPreviewNameFont.Click += new System.EventHandler(this.buttonPreviewNameFont_Click);
            // 
            // buttonImportNameFont
            // 
            this.buttonImportNameFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonImportNameFont.Image = ((System.Drawing.Image)(resources.GetObject("buttonImportNameFont.Image")));
            this.buttonImportNameFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonImportNameFont.Name = "buttonImportNameFont";
            this.buttonImportNameFont.Size = new System.Drawing.Size(23, 22);
            this.buttonImportNameFont.Text = "Import Font";
            this.buttonImportNameFont.Click += new System.EventHandler(this.buttonImportNameFont_Click);
            // 
            // buttonDeleteNameFont
            // 
            this.buttonDeleteNameFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonDeleteNameFont.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeleteNameFont.Image")));
            this.buttonDeleteNameFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDeleteNameFont.Name = "buttonDeleteNameFont";
            this.buttonDeleteNameFont.Size = new System.Drawing.Size(23, 22);
            this.buttonDeleteNameFont.Text = "Remove Font";
            this.buttonDeleteNameFont.Click += new System.EventHandler(this.buttonDeleteNameFont_Click);
            // 
            // buttonExportNameFont
            // 
            this.buttonExportNameFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonExportNameFont.Image = ((System.Drawing.Image)(resources.GetObject("buttonExportNameFont.Image")));
            this.buttonExportNameFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonExportNameFont.Name = "buttonExportNameFont";
            this.buttonExportNameFont.Size = new System.Drawing.Size(23, 22);
            this.buttonExportNameFont.Text = "Export";
            this.buttonExportNameFont.Visible = false;
            this.buttonExportNameFont.Click += new System.EventHandler(this.buttonExportNameFont_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 146;
            this.label3.Text = "Font Case";
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.kitBindingSource, "jerseyNameFontCase", true));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "UPPER CASE",
            "lower case",
            "Mixed Case"});
            this.comboBox1.Location = new System.Drawing.Point(139, 102);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(108, 21);
            this.comboBox1.TabIndex = 147;
            // 
            // checkHasBackname
            // 
            this.checkHasBackname.AutoSize = true;
            this.checkHasBackname.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.kitBindingSource, "jerseyBackName", true, DataSourceUpdateMode.OnPropertyChanged));
            this.checkHasBackname.Location = new System.Drawing.Point(9, 19);
            this.checkHasBackname.Name = "checkHasBackname";
            this.checkHasBackname.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkHasBackname.Size = new System.Drawing.Size(112, 17);
            this.checkHasBackname.TabIndex = 2;
            this.checkHasBackname.Text = "Back Name          ";
            this.checkHasBackname.UseVisualStyleBackColor = true;
            this.checkHasBackname.CheckedChanged += new System.EventHandler(this.checkHasBackname_CheckedChanged);
            // 
            // numericNameFont
            // 
            this.numericNameFont.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.kitBindingSource, "jerseyNameFont", true));
            this.numericNameFont.Location = new System.Drawing.Point(139, 42);
            this.numericNameFont.Maximum = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.numericNameFont.Name = "numericNameFont";
            this.numericNameFont.Size = new System.Drawing.Size(108, 20);
            this.numericNameFont.TabIndex = 5;
            this.numericNameFont.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericNameFont.ValueChanged += new System.EventHandler(this.numericNameFont_ValueChanged);
            // 
            // labelNameFont
            // 
            this.labelNameFont.AutoSize = true;
            this.labelNameFont.Location = new System.Drawing.Point(6, 48);
            this.labelNameFont.Name = "labelNameFont";
            this.labelNameFont.Size = new System.Drawing.Size(55, 13);
            this.labelNameFont.TabIndex = 6;
            this.labelNameFont.Text = "Font Type";
            // 
            // pictureNameColor
            // 
            this.pictureNameColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureNameColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureNameColor.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", this.kitBindingSource, "JerseyNameColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pictureNameColor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureNameColor.Location = new System.Drawing.Point(139, 12);
            this.pictureNameColor.Name = "pictureNameColor";
            this.pictureNameColor.Size = new System.Drawing.Size(24, 24);
            this.pictureNameColor.TabIndex = 145;
            this.pictureNameColor.TabStop = false;
            this.pictureNameColor.Click += new System.EventHandler(this.pictureNameColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Layout";
            // 
            // comboNameLayout
            // 
            this.comboNameLayout.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.kitBindingSource, "jerseyNameLayout", true));
            this.comboNameLayout.FormattingEnabled = true;
            this.comboNameLayout.Items.AddRange(new object[] {
            "Straight",
            "Curved"});
            this.comboNameLayout.Location = new System.Drawing.Point(139, 128);
            this.comboNameLayout.Name = "comboNameLayout";
            this.comboNameLayout.Size = new System.Drawing.Size(108, 21);
            this.comboNameLayout.TabIndex = 8;
            // 
            // pictureFont
            // 
            this.pictureFont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureFont.Location = new System.Drawing.Point(3, 339);
            this.pictureFont.Name = "pictureFont";
            this.pictureFont.Size = new System.Drawing.Size(386, 152);
            this.pictureFont.TabIndex = 4;
            this.pictureFont.TabStop = false;
            // 
            // pickUpControl
            // 
            this.pickUpControl.BackColor = System.Drawing.SystemColors.Control;
            this.pickUpControl.CloneButtonEnabled = true;
            this.pickUpControl.CreateButtonEnabled = false;
            this.pickUpControl.CurrentIndex = 0;
            this.pickUpControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pickUpControl.FilterByList = new string[] {
        "All",
        "by Team",
        "by League",
        "by Country"};
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
            // fontDialog
            // 
            this.fontDialog.Color = System.Drawing.SystemColors.ControlText;
            // 
            // processFontView
            // 
            this.processFontView.StartInfo.Domain = "";
            this.processFontView.StartInfo.LoadUserProfile = false;
            this.processFontView.StartInfo.Password = null;
            this.processFontView.StartInfo.StandardErrorEncoding = null;
            this.processFontView.StartInfo.StandardOutputEncoding = null;
            this.processFontView.StartInfo.UserName = "";
            this.processFontView.SynchronizingObject = this;
            // 
            // fontDialog1
            // 
            this.fontDialog1.Color = System.Drawing.SystemColors.ControlText;
            // 
            // KitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1357, 832);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pickUpControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KitForm";
            this.Text = "KitForm";
            this.Load += new System.EventHandler(this.KitForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupPositions.ResumeLayout(false);
            this.groupPositions.PerformLayout();
            this.toolStrip3D.ResumeLayout(false);
            this.toolStrip3D.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTeamId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamListBindingSource)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.group3D.ResumeLayout(false);
            this.group3D.PerformLayout();
            this.toolNear3D.ResumeLayout(false);
            this.toolNear3D.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureShortsNumberColorTer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureShortsNumberColorSec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureShortsNumberColorPrim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureJerseyNumberColorTer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureJerseyNumberColorSec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureJerseyNumberColorPrim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericShortsNumberFont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericJerseyNumberFont)).EndInit();
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.flowPanel.ResumeLayout(false);
            this.groupCollar.ResumeLayout(false);
            this.groupCollar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTeamTerColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTeamPrimColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTeamSecColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCollar)).EndInit();
            this.groupName.ResumeLayout(false);
            this.groupName.PerformLayout();
            this.toolStripNameFont.ResumeLayout(false);
            this.toolStripNameFont.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericNameFont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureNameColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFont)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
