// Original code created by Rinaldo

using FifaControls;
using FifaLibrary;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
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
        private FbxViewer3D fbxViewer3D;
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
            this.m_NewIdCreator.IdList = (IdArrayList)FifaEnvironment.Balls;
            this.pickUpControl.ObjectList = (IdArrayList)FifaEnvironment.Balls;
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
            this.m_CurrentBall = (Ball)null;
            this.LoadBall(ball);
        }

        private void LoadBall(Ball ball)
        {
            fbxViewer3D.Focus();
            if (!this.m_IsLoaded || this.m_CurrentBall == ball)
                return;

            this.m_CurrentBall = ball;
            this.ballBindingSource.DataSource = (object)this.m_CurrentBall;

            try
            {
                this.multiViewer2DTextures.Bitmaps = this.m_CurrentBall.GetBallTextures();
                this.viewer2DBallPicture.CurrentBitmap = this.m_CurrentBall.GetBallPicture();
            }
            catch (Exception e)
            {
                FifaEnvironment.UserMessages.ShowMessage(3000, e.Message, true, this);
                return;
            }

            if (this.multiViewer2DTextures.Bitmaps == null || this.viewer2DBallPicture.CurrentBitmap == null)
                return;

            this.Show3DBall();
            GC.Collect();
        }

        public void Show3DBall()
        {
            if (!this.buttonShow3DModel.Checked)
            {
                fbxViewer3D.ShowEmpty();
                return;
            }

            fbxViewer3D.Textures = this.multiViewer2DTextures.Bitmaps;
            fbxViewer3D.FilesPath = FifaEnvironment.GameDir + "Content\\Character\\ball\\ball_" + this.m_CurrentBall.Id.ToString() + "\\ball_" + this.m_CurrentBall.Id.ToString();
            fbxViewer3D.ObjectId = this.m_CurrentBall.Id;
            fbxViewer3D.ObjectType = FbxViewer3D.ObjectTypeServerPort.Ball;

            fbxViewer3D.Render();
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
            Ball ball = (Ball)obj;
            this.Refresh();
            this.LoadBall(ball);
            return ball;
        }

        private Ball CreateBall(object sender, object obj)
        {
            DialogResult dialogResult = this.m_NewIdCreator.ShowDialog();
            if (this.m_NewIdCreator.NewObject != null)
                return (Ball)this.m_NewIdCreator.NewObject;
            if (dialogResult == DialogResult.OK)
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(5060, this.m_NewIdCreator.NewId);
            }
            return (Ball)null;
        }

        private Ball DeleteBall(object sender, object obj)
        {
            Ball ball = (Ball)obj;
            ball.DeleteBall();
            FifaEnvironment.Balls.RemoveId((IdObject)ball);
            return (Ball)null;
        }

        private Ball CloneBall(object sender, object obj)
        {
            DialogResult dialogResult = this.m_NewIdCreator.ShowDialog();
            if (this.m_NewIdCreator.NewObject != null)
                return (Ball)FifaEnvironment.Balls.CloneId((IdObject)obj, this.m_NewIdCreator.NewObject);
            if (dialogResult == DialogResult.OK)
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(5060, this.m_NewIdCreator.NewId);
            }
            return (Ball)null;
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
            this.pickUpControl.SwitchObject((IdObject)this.m_CurrentBall);
        }

        private void buttonCamera_Click(object sender, EventArgs e)
        {
            Bitmap bitmap1 = fbxViewer3D.Photo();

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BallForm));
            this.group3D = new System.Windows.Forms.GroupBox();
            this.fbxViewer3D = new FifaControls.FbxViewer3D();
            this.toolNear3D = new System.Windows.Forms.ToolStrip();
            this.buttonShow3DModel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonImport3DModel = new System.Windows.Forms.ToolStripButton();
            this.buttonExport3DModel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonRemove3DModel = new System.Windows.Forms.ToolStripButton();
            this.buttonCamera = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.multiViewer2DTextures = new FifaControls.MultiViewer2D();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ballBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelId = new System.Windows.Forms.Label();
            this.checkIsGenericBall = new System.Windows.Forms.CheckBox();
            this.labelBallName = new System.Windows.Forms.Label();
            this.textBalllName = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.viewer2DBallPicture = new FifaControls.Viewer2D();
            this.pickUpControl = new FifaControls.PickUpControl();
            this.group3D.SuspendLayout();
            this.toolNear3D.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ballBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // group3D
            // 
            this.group3D.Controls.Add(this.fbxViewer3D);
            this.group3D.Controls.Add(this.toolNear3D);
            this.group3D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group3D.Location = new System.Drawing.Point(0, 0);
            this.group3D.Name = "group3D";
            this.group3D.Size = new System.Drawing.Size(833, 558);
            this.group3D.TabIndex = 1;
            this.group3D.TabStop = false;
            this.group3D.Text = "3D Model";
            // 
            // fbxViewer3D
            // 
            this.fbxViewer3D.AmbientColor = System.Drawing.Color.Gray;
            this.fbxViewer3D.AutoSize = true;
            this.fbxViewer3D.BackColor = System.Drawing.Color.Gray;
            this.fbxViewer3D.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fbxViewer3D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fbxViewer3D.FilesPath = null;
            this.fbxViewer3D.Location = new System.Drawing.Point(3, 16);
            this.fbxViewer3D.Name = "fbxViewer3D";
            this.fbxViewer3D.ObjectId = -1;
            this.fbxViewer3D.ObjectType = FifaControls.FbxViewer3D.ObjectTypeServerPort.Ball;
            this.fbxViewer3D.Size = new System.Drawing.Size(827, 514);
            this.fbxViewer3D.TabIndex = 3;
            this.fbxViewer3D.Textures = null;
            // 
            // toolNear3D
            // 
            this.toolNear3D.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolNear3D.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolNear3D.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonShow3DModel,
            this.toolStripSeparator1,
            this.buttonImport3DModel,
            this.buttonExport3DModel,
            this.toolStripSeparator2,
            this.buttonRemove3DModel,
            this.buttonCamera});
            this.toolNear3D.Location = new System.Drawing.Point(3, 530);
            this.toolNear3D.Name = "toolNear3D";
            this.toolNear3D.Size = new System.Drawing.Size(827, 25);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonImport3DModel
            // 
            this.buttonImport3DModel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonImport3DModel.Image = ((System.Drawing.Image)(resources.GetObject("buttonImport3DModel.Image")));
            this.buttonImport3DModel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonImport3DModel.Name = "buttonImport3DModel";
            this.buttonImport3DModel.Size = new System.Drawing.Size(23, 22);
            this.buttonImport3DModel.Text = "Import 3D Model";
            this.buttonImport3DModel.Click += new System.EventHandler(this.buttonImportNear3DModel_Click);
            // 
            // buttonExport3DModel
            // 
            this.buttonExport3DModel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonExport3DModel.Image = ((System.Drawing.Image)(resources.GetObject("buttonExport3DModel.Image")));
            this.buttonExport3DModel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonExport3DModel.Name = "buttonExport3DModel";
            this.buttonExport3DModel.Size = new System.Drawing.Size(23, 22);
            this.buttonExport3DModel.Text = "Export 3D Model";
            this.buttonExport3DModel.Click += new System.EventHandler(this.buttonExportNear3DModel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonRemove3DModel
            // 
            this.buttonRemove3DModel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRemove3DModel.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemove3DModel.Image")));
            this.buttonRemove3DModel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRemove3DModel.Name = "buttonRemove3DModel";
            this.buttonRemove3DModel.Size = new System.Drawing.Size(23, 22);
            this.buttonRemove3DModel.Text = "Remove 3D Model";
            this.buttonRemove3DModel.Click += new System.EventHandler(this.buttonRemoveNear3DModel_Click);
            // 
            // buttonCamera
            // 
            this.buttonCamera.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonCamera.Image = ((System.Drawing.Image)(resources.GetObject("buttonCamera.Image")));
            this.buttonCamera.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonCamera.Name = "buttonCamera";
            this.buttonCamera.Size = new System.Drawing.Size(23, 22);
            this.buttonCamera.Text = "Picture";
            this.buttonCamera.Click += new System.EventHandler(this.buttonCamera_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
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
            this.splitContainer3.Panel1.AutoScroll = true;
            this.splitContainer3.Panel1.Controls.Add(this.multiViewer2DTextures);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.AutoScroll = true;
            this.splitContainer3.Panel2.Controls.Add(this.checkBox1);
            this.splitContainer3.Panel2.Controls.Add(this.textBox1);
            this.splitContainer3.Panel2.Controls.Add(this.labelId);
            this.splitContainer3.Panel2.Controls.Add(this.checkIsGenericBall);
            this.splitContainer3.Panel2.Controls.Add(this.labelBallName);
            this.splitContainer3.Panel2.Controls.Add(this.textBalllName);
            this.splitContainer3.Size = new System.Drawing.Size(516, 807);
            this.splitContainer3.SplitterDistance = 562;
            this.splitContainer3.TabIndex = 1;
            // 
            // multiViewer2DTextures
            // 
            this.multiViewer2DTextures.AutoTransparency = false;
            this.multiViewer2DTextures.Bitmaps = null;
            this.multiViewer2DTextures.CheckBitmapSize = true;
            this.multiViewer2DTextures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiViewer2DTextures.FixedSize = true;
            this.multiViewer2DTextures.FullSizeButton = false;
            this.multiViewer2DTextures.LabelText = "Texture";
            this.multiViewer2DTextures.Location = new System.Drawing.Point(0, 0);
            this.multiViewer2DTextures.Name = "multiViewer2DTextures";
            this.multiViewer2DTextures.ShowDeleteButton = true;
            this.multiViewer2DTextures.Size = new System.Drawing.Size(512, 558);
            this.multiViewer2DTextures.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.ballBindingSource, "IsLicensed", true, DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox1.Location = new System.Drawing.Point(9, 76);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox1.Size = new System.Drawing.Size(129, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Licensed                    ";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // ballBindingSource
            // 
            this.ballBindingSource.DataSource = typeof(FifaLibrary.Ball);
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ballBindingSource, "Id", true));
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(65, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(73, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(10, 6);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(16, 13);
            this.labelId.TabIndex = 3;
            this.labelId.Text = "Id";
            this.labelId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkIsGenericBall
            // 
            this.checkIsGenericBall.AutoSize = true;
            this.checkIsGenericBall.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.ballBindingSource, "IsAvailable", true, DataSourceUpdateMode.OnPropertyChanged));
            this.checkIsGenericBall.Location = new System.Drawing.Point(10, 53);
            this.checkIsGenericBall.Name = "checkIsGenericBall";
            this.checkIsGenericBall.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkIsGenericBall.Size = new System.Drawing.Size(128, 17);
            this.checkIsGenericBall.TabIndex = 2;
            this.checkIsGenericBall.Text = "Visible in Game Menu";
            this.checkIsGenericBall.UseVisualStyleBackColor = true;
            // 
            // labelBallName
            // 
            this.labelBallName.AutoSize = true;
            this.labelBallName.Location = new System.Drawing.Point(10, 30);
            this.labelBallName.Name = "labelBallName";
            this.labelBallName.Size = new System.Drawing.Size(35, 13);
            this.labelBallName.TabIndex = 0;
            this.labelBallName.Text = "Name";
            this.labelBallName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBalllName
            // 
            this.textBalllName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ballBindingSource, "Name", true));
            this.textBalllName.Location = new System.Drawing.Point(65, 27);
            this.textBalllName.Name = "textBalllName";
            this.textBalllName.Size = new System.Drawing.Size(312, 20);
            this.textBalllName.TabIndex = 1;
            this.textBalllName.TextChanged += new System.EventHandler(this.textBalllName_TextChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AutoScroll = true;
            this.splitContainer2.Panel1.Controls.Add(this.group3D);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(this.viewer2DBallPicture);
            this.splitContainer2.Size = new System.Drawing.Size(837, 807);
            this.splitContainer2.SplitterDistance = 562;
            this.splitContainer2.TabIndex = 0;
            // 
            // viewer2DBallPicture
            // 
            this.viewer2DBallPicture.AutoTransparency = false;
            this.viewer2DBallPicture.BackColor = System.Drawing.Color.Transparent;
            this.viewer2DBallPicture.ButtonStripVisible = true;
            this.viewer2DBallPicture.CurrentBitmap = null;
            this.viewer2DBallPicture.ExtendedFormat = false;
            this.viewer2DBallPicture.FullSizeButton = false;
            this.viewer2DBallPicture.ImageLayout = System.Windows.Forms.ImageLayout.None;
            this.viewer2DBallPicture.ImageSize = new System.Drawing.Size(512, 256);
            this.viewer2DBallPicture.ImageSizeMultiplier = FifaControls.Viewer2D.SizeMultiplier.None;
            this.viewer2DBallPicture.Location = new System.Drawing.Point(3, 3);
            this.viewer2DBallPicture.Name = "viewer2DBallPicture";
            this.viewer2DBallPicture.RemoveButton = false;
            this.viewer2DBallPicture.ShowButton = false;
            this.viewer2DBallPicture.ShowButtonChecked = true;
            this.viewer2DBallPicture.Size = new System.Drawing.Size(362, 207);
            this.viewer2DBallPicture.TabIndex = 3;
            // 
            // pickUpControl
            // 
            this.pickUpControl.BackColor = System.Drawing.SystemColors.Control;
            this.pickUpControl.CloneButtonEnabled = true;
            this.pickUpControl.CreateButtonEnabled = false;
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
            this.pickUpControl.SearchEnabled = false;
            this.pickUpControl.Size = new System.Drawing.Size(1357, 25);
            this.pickUpControl.TabIndex = 0;
            this.pickUpControl.WizardButtonEnabled = false;
            this.pickUpControl.YoungPlayersEnabled = false;
            // 
            // BallForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 832);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pickUpControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BallForm";
            this.Text = "Ball";
            this.Load += new System.EventHandler(this.BallForm_Load);
            this.group3D.ResumeLayout(false);
            this.group3D.PerformLayout();
            this.toolNear3D.ResumeLayout(false);
            this.toolNear3D.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ballBindingSource)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
