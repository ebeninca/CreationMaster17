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
  public class BallForm : Form
  {
    private NewIdCreator m_NewIdCreator = new NewIdCreator();
    private string m_BallCurrentFolder = FifaEnvironment.ExportFolder;
    private Ball m_CurrentBall;
    private bool m_IsLoaded;
    private IContainer components;
    private Viewer3D viewer3D;
    private GroupBox group3D;
    private ToolStrip toolNear3D;
    private ToolStripButton buttonImport3DModel;
    private ToolStripButton buttonExport3DModel;
    private ToolStripButton buttonRemove3DModel;
    public PickUpControl pickUpControl;
    private ToolStripButton buttonShow3DModel;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripSeparator toolStripSeparator2;
    private SplitContainer splitContainer1;
    private SplitContainer splitContainer2;
    private TextBox textBalllName;
    private Label labelBallName;
    private SplitContainer splitContainer3;
    private CheckBox checkIsGenericBall;
    private Viewer2D viewer2DBallPicture;
    private BindingSource ballBindingSource;
    private MultiViewer2D multiViewer2DTextures;
    private TextBox textBox1;
    private Label labelId;
    private ToolStripButton buttonCamera;
    private CheckBox checkBox1;

    public BallForm()
    {
      this.Visible = false;
      this.InitializeComponent();
      this.pickUpControl.SelectObject = new PickUpControl.PickUpCallback(this.SelectBall);
      this.pickUpControl.CreateObject = new PickUpControl.PickUpCallback(this.CreateBall);
      this.pickUpControl.DeleteObject = new PickUpControl.PickUpCallback(this.DeleteBall);
      this.pickUpControl.CloneObject = new PickUpControl.PickUpCallback(this.CloneBall);
      this.pickUpControl.RefreshObject = new PickUpControl.PickUpCallback(this.RefreshBall);
      this.multiViewer2DTextures.Rx3ExportDelegate = new MultiViewer2D.Rx3ExportHandler(this.ExportRx3BallTextures);
      this.multiViewer2DTextures.Rx3ImportDelegate = new MultiViewer2D.Rx3ImportHandler(this.ImportRx3BallTextures);
      this.multiViewer2DTextures.Rx3SaveDelegate = new MultiViewer2D.Rx3SaveHandler(this.SaveRx3BallTextures);
      this.multiViewer2DTextures.Rx3DeleteDelegate = new MultiViewer2D.Rx3DeleteHandler(this.DeleteRx3BallTextures);
      this.viewer2DBallPicture.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageBallPicture);
      this.viewer2DBallPicture.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteImageBallPicture);
      this.viewer2DBallPicture.ButtonStripVisible = true;
      this.viewer2DBallPicture.RemoveButton = true;
    }

    public void Clean()
    {
      this.Visible = false;
    }

    public void Preset()
    {
      this.m_NewIdCreator.IdList = (IdArrayList) FifaEnvironment.Balls;
      this.pickUpControl.ObjectList = (IdArrayList) FifaEnvironment.Balls;
    }

    private bool ImportImageTextures(object sender, Bitmap[] bitmaps)
    {
      bool flag = this.m_CurrentBall.SetBallTextures(bitmaps);
      this.ReloadBall(this.m_CurrentBall);
      return flag;
    }

    private bool ExportFshTexture(object sender)
    {
      return FifaEnvironment.AskAndExportFromZdata(this.m_CurrentBall.BallTextureFileName(), ref this.m_BallCurrentFolder);
    }

    private bool DeleteTexture(object sender)
    {
      bool flag = this.m_CurrentBall.DeleteBallTextures();
      this.ReloadBall(this.m_CurrentBall);
      return flag;
    }

    private void ReloadBall(Ball ball)
    {
      this.m_CurrentBall = (Ball) null;
      this.LoadBall(ball);
    }

    private void LoadBall(Ball ball)
    {
      if (!this.m_IsLoaded || this.m_CurrentBall == ball)
        return;
      this.m_CurrentBall = ball;
      this.ballBindingSource.DataSource = (object) this.m_CurrentBall;
      this.multiViewer2DTextures.Bitmaps = this.m_CurrentBall.GetBallTextures();
      this.viewer2DBallPicture.CurrentBitmap = this.m_CurrentBall.GetBallPicture();
      this.Show3DBall();
      GC.Collect();
    }

    public void Show3DBall()
    {
      if (!this.buttonShow3DModel.Checked)
      {
        this.viewer3D.ShowEmpty();
      }
      else
      {
        Bitmap[] ballTextures = this.m_CurrentBall.GetBallTextures();
        Bitmap textureBitmap = (Bitmap) null;
        if (ballTextures != null)
          textureBitmap = GraphicUtil.EmbossBitmap(ballTextures[0], ballTextures[1]);
        Rx3File ballModel = this.m_CurrentBall.GetBallModel();
        if (textureBitmap == null || ballModel == null)
        {
          this.viewer3D.Clean(1);
        }
        else
        {
          Rx3IndexArray.TriangleListType = Rx3IndexArray.ETriangleListType.InvertEven;
          Model3D model3D = new Model3D(ballModel.Rx3IndexArrays[0], ballModel.Rx3VertexArrays[0], textureBitmap);
          this.viewer3D.Clean(1);
          this.viewer3D.SetMesh(0, model3D);
          this.viewer3D.Render();
        }
      }
    }

    private bool ImportImageBallPicture(object sender, Bitmap bitmap)
    {
      return this.m_CurrentBall.SetBallPicture(bitmap);
    }

    private bool DeleteImageBallPicture(object sender)
    {
      return this.m_CurrentBall.DeleteBallPicture();
    }

    private bool ExportRx3BallTextures(object sender, string exportDir)
    {
      return FifaEnvironment.ExportFileFromZdata(this.m_CurrentBall.BallTextureFileName(), exportDir);
    }

    private bool SaveRx3BallTextures(object sender, Bitmap[] bitmaps)
    {
      bool flag = this.m_CurrentBall.SetBallTextures(bitmaps);
      if (flag)
        this.ReloadBall(this.m_CurrentBall);
      return flag;
    }

    private bool ImportRx3BallTextures(object sender, string rx3FileName)
    {
      bool flag = this.m_CurrentBall.SetBallTextures(rx3FileName);
      if (flag)
        this.ReloadBall(this.m_CurrentBall);
      return flag;
    }

    private bool DeleteRx3BallTextures(object sender)
    {
      bool flag = this.m_CurrentBall.DeleteBallTextures();
      if (flag)
        this.ReloadBall(this.m_CurrentBall);
      return flag;
    }

    private Ball SelectBall(object sender, object obj)
    {
      Ball ball = (Ball) obj;
      this.Refresh();
      this.LoadBall(ball);
      return ball;
    }

    private Ball CreateBall(object sender, object obj)
    {
      DialogResult dialogResult = this.m_NewIdCreator.ShowDialog();
      if (this.m_NewIdCreator.NewObject != null)
        return (Ball) this.m_NewIdCreator.NewObject;
      if (dialogResult == DialogResult.OK)
      {
        int num = (int) FifaEnvironment.UserMessages.ShowMessage(5060, this.m_NewIdCreator.NewId);
      }
      return (Ball) null;
    }

    private Ball DeleteBall(object sender, object obj)
    {
      Ball ball = (Ball) obj;
      ball.DeleteBall();
      FifaEnvironment.Balls.RemoveId((IdObject) ball);
      return (Ball) null;
    }

    private Ball CloneBall(object sender, object obj)
    {
      DialogResult dialogResult = this.m_NewIdCreator.ShowDialog();
      if (this.m_NewIdCreator.NewObject != null)
        return (Ball) FifaEnvironment.Balls.CloneId((IdObject) obj, this.m_NewIdCreator.NewObject);
      if (dialogResult == DialogResult.OK)
      {
        int num = (int) FifaEnvironment.UserMessages.ShowMessage(5060, this.m_NewIdCreator.NewId);
      }
      return (Ball) null;
    }

    public Ball RefreshBall(object sender, object obj)
    {
      this.Preset();
      this.ReloadBall(this.m_CurrentBall);
      return this.m_CurrentBall;
    }

    private void buttonImportNear3DModel_Click(object sender, EventArgs e)
    {
      string srcFileName = FifaEnvironment.BrowseAndCheckModel(ref this.m_BallCurrentFolder, "Open 3D Ball Model file", "3D ball model files (*.rx3)|ball_*.rx3");
      if (srcFileName == null)
        return;
      this.m_CurrentBall.SetBallModel(srcFileName);
      this.ReloadBall(this.m_CurrentBall);
    }

    private void buttonExportNear3DModel_Click(object sender, EventArgs e)
    {
      string fileName = this.m_CurrentBall.BallModelFileName();
      if (fileName == null)
        return;
      FifaEnvironment.AskAndExportFromZdata(fileName, ref this.m_BallCurrentFolder);
    }

    private void buttonRemoveNear3DModel_Click(object sender, EventArgs e)
    {
      this.m_CurrentBall.DeleteBallModel();
      this.ReloadBall(this.m_CurrentBall);
    }

    private void BallForm_Load(object sender, EventArgs e)
    {
      this.m_IsLoaded = true;
      this.Preset();
    }

    private void buttonShow3DModel_Click(object sender, EventArgs e)
    {
      this.Show3DBall();
    }

    private void textBalllName_TextChanged(object sender, EventArgs e)
    {
      this.m_CurrentBall.Name = this.textBalllName.Text;
      this.pickUpControl.SwitchObject((IdObject) this.m_CurrentBall);
    }

    private void buttonCamera_Click(object sender, EventArgs e)
    {
      Bitmap bitmap1 = this.viewer3D.Photo();
      int height1 = bitmap1.Height;
      int width1 = bitmap1.Width;
      if (width1 < height1)
        return;
      int height2 = height1 - height1 / 12;
      int width2 = height2;
      Rectangle srcRect = new Rectangle((width1 - width2) / 2, (height1 - height2) / 2, width2, height2);
      Rectangle destRect = new Rectangle(73, 0, 177, 177);
      Bitmap srcBitmap = GraphicUtil.MakeAutoTransparent(bitmap1);
      Bitmap bitmap2 = new Bitmap(512, 256, PixelFormat.Format32bppArgb);
      GraphicUtil.RemapRectangle(srcBitmap, srcRect, bitmap2, destRect);
      Bitmap overBitmap = new Bitmap(FifaEnvironment.LaunchDir + "\\Templates\\BallShadow.png");
      GraphicUtil.DrawOver(bitmap2, overBitmap);
      this.m_CurrentBall.SetBallPicture(bitmap2);
      this.viewer2DBallPicture.CurrentBitmap = bitmap2;
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
      ComponentResourceManager resources = new ComponentResourceManager(typeof (BallForm));
      this.group3D = new GroupBox();
      this.viewer3D = new Viewer3D();
      this.toolNear3D = new ToolStrip();
      this.buttonShow3DModel = new ToolStripButton();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.buttonImport3DModel = new ToolStripButton();
      this.buttonExport3DModel = new ToolStripButton();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.buttonRemove3DModel = new ToolStripButton();
      this.buttonCamera = new ToolStripButton();
      this.splitContainer1 = new SplitContainer();
      this.splitContainer3 = new SplitContainer();
      this.multiViewer2DTextures = new MultiViewer2D();
      this.checkBox1 = new CheckBox();
      this.ballBindingSource = new BindingSource(this.components);
      this.textBox1 = new TextBox();
      this.labelId = new Label();
      this.checkIsGenericBall = new CheckBox();
      this.labelBallName = new Label();
      this.textBalllName = new TextBox();
      this.splitContainer2 = new SplitContainer();
      this.viewer2DBallPicture = new Viewer2D();
      this.pickUpControl = new PickUpControl();
      this.group3D.SuspendLayout();
      this.toolNear3D.SuspendLayout();
      this.splitContainer1.BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.splitContainer3.BeginInit();
      this.splitContainer3.Panel1.SuspendLayout();
      this.splitContainer3.Panel2.SuspendLayout();
      this.splitContainer3.SuspendLayout();
      ((ISupportInitialize) this.ballBindingSource).BeginInit();
      this.splitContainer2.BeginInit();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      this.SuspendLayout();
      this.group3D.Controls.Add((Control) this.viewer3D);
      this.group3D.Controls.Add((Control) this.toolNear3D);
      this.group3D.Dock = DockStyle.Fill;
      this.group3D.Location = new Point(0, 0);
      this.group3D.Name = "group3D";
      this.group3D.Size = new Size(833, 558);
      this.group3D.TabIndex = 1;
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
      this.viewer3D.Size = new Size(827, 514);
      this.viewer3D.TabIndex = 1;
      this.viewer3D.ViewX = 0.0f;
      this.viewer3D.ViewY = 0.0f;
      this.viewer3D.ViewZ = 30f;
      this.viewer3D.ZbufferRenderState = (bool[]) null;
      this.toolNear3D.Dock = DockStyle.Bottom;
      this.toolNear3D.GripStyle = ToolStripGripStyle.Hidden;
      this.toolNear3D.Items.AddRange(new ToolStripItem[7]
      {
        (ToolStripItem) this.buttonShow3DModel,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.buttonImport3DModel,
        (ToolStripItem) this.buttonExport3DModel,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.buttonRemove3DModel,
        (ToolStripItem) this.buttonCamera
      });
      this.toolNear3D.Location = new Point(3, 530);
      this.toolNear3D.Name = "toolNear3D";
      this.toolNear3D.Size = new Size(827, 25);
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
      this.buttonImport3DModel.Click += new EventHandler(this.buttonImportNear3DModel_Click);
      this.buttonExport3DModel.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonExport3DModel.Image = (Image) resources.GetObject("buttonExport3DModel.Image");
      this.buttonExport3DModel.ImageTransparentColor = Color.Magenta;
      this.buttonExport3DModel.Name = "buttonExport3DModel";
      this.buttonExport3DModel.Size = new Size(23, 22);
      this.buttonExport3DModel.Text = "Export 3D Model";
      this.buttonExport3DModel.Click += new EventHandler(this.buttonExportNear3DModel_Click);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(6, 25);
      this.buttonRemove3DModel.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonRemove3DModel.Image = (Image) resources.GetObject("buttonRemove3DModel.Image");
      this.buttonRemove3DModel.ImageTransparentColor = Color.Magenta;
      this.buttonRemove3DModel.Name = "buttonRemove3DModel";
      this.buttonRemove3DModel.Size = new Size(23, 22);
      this.buttonRemove3DModel.Text = "Remove 3D Model";
      this.buttonRemove3DModel.Click += new EventHandler(this.buttonRemoveNear3DModel_Click);
      this.buttonCamera.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonCamera.Image = (Image) resources.GetObject("buttonCamera.Image");
      this.buttonCamera.ImageTransparentColor = Color.Magenta;
      this.buttonCamera.Name = "buttonCamera";
      this.buttonCamera.Size = new Size(23, 22);
      this.buttonCamera.Text = "Picture";
      this.buttonCamera.Click += new EventHandler(this.buttonCamera_Click);
      this.splitContainer1.BackColor = SystemColors.Control;
      this.splitContainer1.BorderStyle = BorderStyle.Fixed3D;
      this.splitContainer1.Dock = DockStyle.Fill;
      this.splitContainer1.Location = new Point(0, 25);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Panel1.AutoScroll = true;
      this.splitContainer1.Panel1.Controls.Add((Control) this.splitContainer3);
      this.splitContainer1.Panel2.Controls.Add((Control) this.splitContainer2);
      this.splitContainer1.Size = new Size(1357, 807);
      this.splitContainer1.SplitterDistance = 516;
      this.splitContainer1.TabIndex = 2;
      this.splitContainer3.BorderStyle = BorderStyle.Fixed3D;
      this.splitContainer3.Dock = DockStyle.Fill;
      this.splitContainer3.Location = new Point(0, 0);
      this.splitContainer3.Name = "splitContainer3";
      this.splitContainer3.Orientation = Orientation.Horizontal;
      this.splitContainer3.Panel1.AutoScroll = true;
      this.splitContainer3.Panel1.Controls.Add((Control) this.multiViewer2DTextures);
      this.splitContainer3.Panel2.AutoScroll = true;
      this.splitContainer3.Panel2.Controls.Add((Control) this.checkBox1);
      this.splitContainer3.Panel2.Controls.Add((Control) this.textBox1);
      this.splitContainer3.Panel2.Controls.Add((Control) this.labelId);
      this.splitContainer3.Panel2.Controls.Add((Control) this.checkIsGenericBall);
      this.splitContainer3.Panel2.Controls.Add((Control) this.labelBallName);
      this.splitContainer3.Panel2.Controls.Add((Control) this.textBalllName);
      this.splitContainer3.Size = new Size(516, 807);
      this.splitContainer3.SplitterDistance = 562;
      this.splitContainer3.TabIndex = 1;
      this.multiViewer2DTextures.AutoTransparency = false;
      this.multiViewer2DTextures.Bitmaps = (Bitmap[]) null;
      this.multiViewer2DTextures.CheckBitmapSize = true;
      this.multiViewer2DTextures.Dock = DockStyle.Fill;
      this.multiViewer2DTextures.FixedSize = true;
      this.multiViewer2DTextures.FullSizeButton = false;
      this.multiViewer2DTextures.LabelText = "Texture";
      this.multiViewer2DTextures.Location = new Point(0, 0);
      this.multiViewer2DTextures.Name = "multiViewer2DTextures";
      this.multiViewer2DTextures.ShowDeleteButton = true;
      this.multiViewer2DTextures.Size = new Size(512, 558);
      this.multiViewer2DTextures.TabIndex = 0;
      this.checkBox1.AutoSize = true;
      this.checkBox1.DataBindings.Add(new Binding("Checked", (object) this.ballBindingSource, "IsLicensed", true));
      this.checkBox1.Location = new Point(9, 76);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.RightToLeft = RightToLeft.Yes;
      this.checkBox1.Size = new Size(129, 17);
      this.checkBox1.TabIndex = 5;
      this.checkBox1.Text = "Licensed                    ";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.ballBindingSource.DataSource = (object) typeof (Ball);
      this.textBox1.DataBindings.Add(new Binding("Text", (object) this.ballBindingSource, "Id", true));
      this.textBox1.Enabled = false;
      this.textBox1.Location = new Point(65, 3);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(73, 20);
      this.textBox1.TabIndex = 4;
      this.textBox1.TextAlign = HorizontalAlignment.Center;
      this.labelId.AutoSize = true;
      this.labelId.Location = new Point(10, 6);
      this.labelId.Name = "labelId";
      this.labelId.Size = new Size(16, 13);
      this.labelId.TabIndex = 3;
      this.labelId.Text = "Id";
      this.labelId.TextAlign = ContentAlignment.MiddleLeft;
      this.checkIsGenericBall.AutoSize = true;
      this.checkIsGenericBall.DataBindings.Add(new Binding("Checked", (object) this.ballBindingSource, "IsAvailable", true));
      this.checkIsGenericBall.Location = new Point(10, 53);
      this.checkIsGenericBall.Name = "checkIsGenericBall";
      this.checkIsGenericBall.RightToLeft = RightToLeft.Yes;
      this.checkIsGenericBall.Size = new Size(128, 17);
      this.checkIsGenericBall.TabIndex = 2;
      this.checkIsGenericBall.Text = "Visible in Game Menu";
      this.checkIsGenericBall.UseVisualStyleBackColor = true;
      this.labelBallName.AutoSize = true;
      this.labelBallName.Location = new Point(10, 30);
      this.labelBallName.Name = "labelBallName";
      this.labelBallName.Size = new Size(35, 13);
      this.labelBallName.TabIndex = 0;
      this.labelBallName.Text = "Name";
      this.labelBallName.TextAlign = ContentAlignment.MiddleLeft;
      this.textBalllName.DataBindings.Add(new Binding("Text", (object) this.ballBindingSource, "Name", true));
      this.textBalllName.Location = new Point(65, 27);
      this.textBalllName.Name = "textBalllName";
      this.textBalllName.Size = new Size(312, 20);
      this.textBalllName.TabIndex = 1;
      this.textBalllName.TextChanged += new EventHandler(this.textBalllName_TextChanged);
      this.splitContainer2.BorderStyle = BorderStyle.Fixed3D;
      this.splitContainer2.Dock = DockStyle.Fill;
      this.splitContainer2.Location = new Point(0, 0);
      this.splitContainer2.Name = "splitContainer2";
      this.splitContainer2.Orientation = Orientation.Horizontal;
      this.splitContainer2.Panel1.AutoScroll = true;
      this.splitContainer2.Panel1.Controls.Add((Control) this.group3D);
      this.splitContainer2.Panel2.AutoScroll = true;
      this.splitContainer2.Panel2.Controls.Add((Control) this.viewer2DBallPicture);
      this.splitContainer2.Size = new Size(837, 807);
      this.splitContainer2.SplitterDistance = 562;
      this.splitContainer2.TabIndex = 0;
      this.viewer2DBallPicture.AutoTransparency = false;
      this.viewer2DBallPicture.BackColor = Color.Transparent;
      this.viewer2DBallPicture.ButtonStripVisible = true;
      this.viewer2DBallPicture.CurrentBitmap = (Bitmap) null;
      this.viewer2DBallPicture.ExtendedFormat = false;
      this.viewer2DBallPicture.FullSizeButton = false;
      this.viewer2DBallPicture.ImageLayout = ImageLayout.None;
      this.viewer2DBallPicture.ImageSize = new Size(512, 256);
      this.viewer2DBallPicture.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DBallPicture.Location = new Point(3, 3);
      this.viewer2DBallPicture.Name = "viewer2DBallPicture";
      this.viewer2DBallPicture.RemoveButton = false;
      this.viewer2DBallPicture.ShowButton = false;
      this.viewer2DBallPicture.ShowButtonChecked = true;
      this.viewer2DBallPicture.Size = new Size(362, 207);
      this.viewer2DBallPicture.TabIndex = 3;
      this.pickUpControl.BackColor = SystemColors.Control;
      this.pickUpControl.CloneButtonEnabled = true;
      this.pickUpControl.CreateButtonEnabled = false;
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
      this.pickUpControl.SearchEnabled = false;
      this.pickUpControl.Size = new Size(1357, 25);
      this.pickUpControl.TabIndex = 0;
      this.pickUpControl.WizardButtonEnabled = false;
      this.pickUpControl.YoungPlayersEnabled = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1357, 832);
      this.Controls.Add((Control) this.splitContainer1);
      this.Controls.Add((Control) this.pickUpControl);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = "BallForm";
      this.Text = "Ball";
      this.Load += new EventHandler(this.BallForm_Load);
      this.group3D.ResumeLayout(false);
      this.group3D.PerformLayout();
      this.toolNear3D.ResumeLayout(false);
      this.toolNear3D.PerformLayout();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.splitContainer3.Panel1.ResumeLayout(false);
      this.splitContainer3.Panel2.ResumeLayout(false);
      this.splitContainer3.Panel2.PerformLayout();
      this.splitContainer3.EndInit();
      this.splitContainer3.ResumeLayout(false);
      ((ISupportInitialize) this.ballBindingSource).EndInit();
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel2.ResumeLayout(false);
      this.splitContainer2.EndInit();
      this.splitContainer2.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
