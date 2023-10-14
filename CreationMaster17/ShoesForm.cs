// Original code created by Rinaldo


using FifaControls;
using FifaLibrary;
using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;


namespace CreationMaster
{
    public class ShoesForm : Form
    {
        private NewIdCreator m_NewIdCreator = new NewIdCreator();
        private string m_ShoesCurrentFolder = FifaEnvironment.ExportFolder;
        private Shoes m_CurrentShoes;
        private bool m_IsLoaded;
        private IContainer components;
        public PickUpControl pickUpControl;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer3;
        private MultiViewer2D multiViewer2DShoesColor;
        private GroupBox group3D;
        private FbxViewer3D viewer3D;
        private ToolStrip tool3DModel;
        private ToolStripButton buttonShow3DModel;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton buttonImport3DModel;
        private ToolStripButton buttonExport3DModel;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton buttonRemove3DModel;
        private Panel panel1;
        private Label label1;
        public NumericUpDown numericShoesColor;
        private TextBox textShoesName;
        private TextBox textShoesType;
        private Label labelId;
        private CheckBox checkIsAvailableInStore;

        public ShoesForm()
        {
            this.Visible = false;
            this.InitializeComponent();
            this.pickUpControl.SelectObject = new PickUpControl.PickUpCallback(this.SelectShoes);
            this.pickUpControl.CreateObject = new PickUpControl.PickUpCallback(this.CreateShoes);
            this.pickUpControl.DeleteObject = new PickUpControl.PickUpCallback(this.DeleteShoes);
            this.pickUpControl.CloneObject = new PickUpControl.PickUpCallback(this.CloneShoes);
            this.pickUpControl.RefreshObject = new PickUpControl.PickUpCallback(this.RefreshShoes);
            this.pickUpControl.combo.Sorted = false;
            this.multiViewer2DShoesColor.Rx3ExportDelegate = new MultiViewer2D.Rx3ExportHandler(this.ExportRx3ShoesColor);
            this.multiViewer2DShoesColor.Rx3ImportDelegate = new MultiViewer2D.Rx3ImportHandler(this.ImportRx3ShoesColor);
            this.multiViewer2DShoesColor.Rx3SaveDelegate = new MultiViewer2D.Rx3SaveHandler(this.SaveBitmapShoesColor);
            this.multiViewer2DShoesColor.Rx3DeleteDelegate = new MultiViewer2D.Rx3DeleteHandler(this.DeleteShoesColor);
        }

        public void Clean()
        {
            this.Visible = false;
        }

        public void Preset()
        {
            this.m_NewIdCreator.IdList = (IdArrayList)FifaEnvironment.Shoes;
            this.pickUpControl.ObjectList = (IdArrayList)FifaEnvironment.Shoes;
        }

        private Shoes SelectShoes(object sender, object obj)
        {
            Shoes shoes = (Shoes)obj;
            this.Refresh();
            this.LoadShoes(shoes);
            return shoes;
        }

        private Shoes CreateShoes(object sender, object obj)
        {
            DialogResult dialogResult = this.m_NewIdCreator.ShowDialog();
            if (this.m_NewIdCreator.NewObject != null)
                return (Shoes)this.m_NewIdCreator.NewObject;
            if (dialogResult == DialogResult.OK)
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(5060, this.m_NewIdCreator.NewId);
            }
            return (Shoes)null;
        }

        private Shoes DeleteShoes(object sender, object obj)
        {
            Shoes shoes = (Shoes)obj;
            Shoes.DeleteShoes(shoes.Id, 0);
            FifaEnvironment.Shoes.RemoveId((IdObject)shoes);
            return (Shoes)null;
        }

        private Shoes CloneShoes(object sender, object obj)
        {
            DialogResult dialogResult = this.m_NewIdCreator.ShowDialog();
            if (this.m_NewIdCreator.NewObject != null)
                return (Shoes)FifaEnvironment.Shoes.CloneId((IdObject)obj, this.m_NewIdCreator.NewObject);
            if (dialogResult == DialogResult.OK)
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(5060, this.m_NewIdCreator.NewId);
            }
            return (Shoes)null;
        }

        public Shoes RefreshShoes(object sender, object obj)
        {
            this.Preset();
            this.ReloadShoes(this.m_CurrentShoes);
            return this.m_CurrentShoes;
        }

        private bool SaveBitmapShoesColor(object sender, Bitmap[] bitmaps)
        {
            bool flag = Shoes.SetShoesTextures(this.m_CurrentShoes.Id, (int)this.numericShoesColor.Value, bitmaps);
            this.ReloadShoes(this.m_CurrentShoes);
            return flag;
        }

        private bool ExportRx3ShoesColor(object sender, string exportDir)
        {
            return Shoes.ExportShoesTextures(this.m_CurrentShoes.Id, (int)this.numericShoesColor.Value, exportDir);
        }

        private bool ImportRx3ShoesColor(object sender, string rx3FileName)
        {
            bool flag = Shoes.ImportShoesTextures(this.m_CurrentShoes.Id, (int)this.numericShoesColor.Value, rx3FileName);
            if (flag)
                this.ReloadShoes(this.m_CurrentShoes);
            return flag;
        }

        private bool DeleteShoesColor(object sender)
        {
            bool flag = Shoes.DeleteShoesTextures(this.m_CurrentShoes.Id, (int)this.numericShoesColor.Value);
            if (flag)
                this.ReloadShoes(this.m_CurrentShoes);
            return flag;
        }

        private void LoadShoes(Shoes shoes)
        {
            if (!this.m_IsLoaded || this.m_CurrentShoes == shoes)
                return;
            this.m_CurrentShoes = shoes;
            Bitmap[] bitmapArray = new Bitmap[3];
            int shoesDesign;
            if (this.m_CurrentShoes.Id == 0)
            {
                this.numericShoesColor.Enabled = true;
                shoesDesign = (int)this.numericShoesColor.Value;
            }
            else
            {
                this.numericShoesColor.Enabled = false;
                this.numericShoesColor.Value = new Decimal(0);
                shoesDesign = 0;
            }
            this.multiViewer2DShoesColor.Bitmaps = Shoes.GetShoesTextures(shoes.Id, shoesDesign);
            this.textShoesName.Text = this.m_CurrentShoes.Name;
            this.textShoesType.Text = this.m_CurrentShoes.Id.ToString();
            this.checkIsAvailableInStore.Checked = this.m_CurrentShoes.IsAvailableinStore;
            this.Show3DShoes();
            GC.Collect();
        }

        private void ReloadShoes(Shoes shoes)
        {
            this.m_CurrentShoes = (Shoes)null;
            this.LoadShoes(shoes);
        }

        public void Show3DShoes()
        {
            if (!this.buttonShow3DModel.Checked)
            {
                this.viewer3D.ShowEmpty();
            }
            else
            {
                Bitmap[] shoesTextures = Shoes.GetShoesTextures(this.m_CurrentShoes.Id, (int)this.numericShoesColor.Value);
                if (shoesTextures == null)
                {
                    this.viewer3D.ShowEmpty();
                }
                else
                {
                    Bitmap textureBitmap = GraphicUtil.EmbossBitmap(shoesTextures[0], shoesTextures[1]);
                    Rx3File shoesModel = Shoes.GetShoesModel(this.m_CurrentShoes.Id);
                    /*if (textureBitmap == null || shoesModel == null)
                    {
                        this.viewer3D.Clean(1);
                    }
                    else
                    {
                        Model3D model3D = new Model3D(shoesModel.Rx3IndexArrays[0], shoesModel.Rx3VertexArrays[0], textureBitmap);
                        this.viewer3D.Clean(2);
                        this.viewer3D.SetMesh(0, model3D);
                        this.viewer3D.Render();
                    }*/
                }
            }
        }

        private void ShoesForm_Load(object sender, EventArgs e)
        {
            this.m_IsLoaded = true;
            this.Preset();
        }

        private void buttonExportNear3DModel_Click(object sender, EventArgs e)
        {
            string fileName = Shoes.ShoesModelFileName(this.m_CurrentShoes.Id);
            if (fileName == null)
                return;
            FifaEnvironment.AskAndExportFromZdata(fileName, ref this.m_ShoesCurrentFolder);
        }

        private void buttonRemoveNear3DModel_Click(object sender, EventArgs e)
        {
            Shoes.DeleteShoesModel(this.m_CurrentShoes.Id);
            this.ReloadShoes(this.m_CurrentShoes);
        }

        private void buttonShow3DModel_Click(object sender, EventArgs e)
        {
            this.Show3DShoes();
        }

        private void numericShoesColor_ValueChanged(object sender, EventArgs e)
        {
            if (this.m_CurrentShoes.Id != 0)
                return;
            this.ReloadShoes(this.m_CurrentShoes);
        }

        private void buttonExport3DModel_Click(object sender, EventArgs e)
        {
            string fileName = Shoes.ShoesModelFileName(this.m_CurrentShoes.Id);
            if (fileName == null)
                return;
            FifaEnvironment.AskAndExportFromZdata(fileName, ref this.m_ShoesCurrentFolder);
        }

        private void buttonImport3DModel_Click(object sender, EventArgs e)
        {
            string rx3FileName = FifaEnvironment.BrowseAndCheckModel(ref this.m_ShoesCurrentFolder, "Open 3D Shoes Model file", "3D shoes model files (*.rx3)|shoe_*.rx3");
            if (rx3FileName == null)
                return;
            Shoes.SetShoesModel(this.m_CurrentShoes.Id, rx3FileName);
            this.ReloadShoes(this.m_CurrentShoes);
        }

        private void buttonRemove3DModel_Click(object sender, EventArgs e)
        {
            Shoes.DeleteShoesModel(this.m_CurrentShoes.Id);
            this.ReloadShoes(this.m_CurrentShoes);
        }

        private void textShoesName_TextChanged(object sender, EventArgs e)
        {
            if (!(this.textShoesName.Text != this.m_CurrentShoes.Name))
                return;
            this.m_CurrentShoes.Name = this.textShoesName.Text;
        }

        private void checkIsAvailableInStore_CheckedChanged(object sender, EventArgs e)
        {
            this.m_CurrentShoes.IsAvailableinStore = this.checkIsAvailableInStore.Checked;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(ShoesForm));
            this.splitContainer1 = new SplitContainer();
            this.splitContainer3 = new SplitContainer();
            this.group3D = new GroupBox();
            this.viewer3D = new FbxViewer3D();
            this.tool3DModel = new ToolStrip();
            this.buttonShow3DModel = new ToolStripButton();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.buttonImport3DModel = new ToolStripButton();
            this.buttonExport3DModel = new ToolStripButton();
            this.toolStripSeparator2 = new ToolStripSeparator();
            this.buttonRemove3DModel = new ToolStripButton();
            this.panel1 = new Panel();
            this.textShoesType = new TextBox();
            this.labelId = new Label();
            this.textShoesName = new TextBox();
            this.numericShoesColor = new NumericUpDown();
            this.label1 = new Label();
            this.multiViewer2DShoesColor = new MultiViewer2D();
            this.pickUpControl = new PickUpControl();
            this.checkIsAvailableInStore = new CheckBox();
            this.splitContainer1.BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer3.BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.group3D.SuspendLayout();
            this.tool3DModel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.numericShoesColor.BeginInit();
            this.SuspendLayout();
            this.splitContainer1.Dock = DockStyle.Fill;
            this.splitContainer1.Location = new Point(260, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1.Controls.Add((Control)this.splitContainer3);
            this.splitContainer1.Size = new Size(776, 755);
            this.splitContainer1.SplitterDistance = 685;
            this.splitContainer1.TabIndex = 2;
            this.splitContainer3.Dock = DockStyle.Fill;
            this.splitContainer3.Location = new Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = Orientation.Horizontal;
            this.splitContainer3.Panel1.Controls.Add((Control)this.group3D);
            this.splitContainer3.Size = new Size(685, 755);
            this.splitContainer3.SplitterDistance = 586;
            this.splitContainer3.TabIndex = 0;
            this.group3D.Controls.Add((Control)this.viewer3D);
            this.group3D.Controls.Add((Control)this.tool3DModel);
            this.group3D.Dock = DockStyle.Fill;
            this.group3D.Location = new Point(0, 0);
            this.group3D.Name = "group3D";
            this.group3D.Size = new Size(685, 586);
            this.group3D.TabIndex = 2;
            this.group3D.TabStop = false;
            this.group3D.Text = "3D Model";
            this.viewer3D.AmbientColor = Color.DimGray;
            this.viewer3D.BackColor = Color.Gray;
            this.viewer3D.BorderStyle = BorderStyle.Fixed3D;
            this.viewer3D.Dock = DockStyle.Fill;
            /*this.viewer3D.LightDirectionX = 0.5f;
            this.viewer3D.LightDirectionY = -0.25f;
            this.viewer3D.LightDirectionZ = -1f;
            this.viewer3D.LightX = -30f;
            this.viewer3D.LightY = 10f;
            this.viewer3D.LightZ = 50f;
            this.viewer3D.Location = new Point(3, 16);
            this.viewer3D.Name = "viewer3D";
            this.viewer3D.RotationX = 0.43f;
            this.viewer3D.RotationY = 0.23f;
            this.viewer3D.RotationYCoeff = 0.01f;
            this.viewer3D.Size = new Size(679, 542);
            this.viewer3D.TabIndex = 1;
            this.viewer3D.ViewX = 0.0f;
            this.viewer3D.ViewY = 0.0f;
            this.viewer3D.ViewZ = 58f;
            this.viewer3D.ZbufferRenderState = (bool[])null;*/
            this.tool3DModel.Dock = DockStyle.Bottom;
            this.tool3DModel.GripStyle = ToolStripGripStyle.Hidden;
            this.tool3DModel.Items.AddRange(new ToolStripItem[6]
            {
        (ToolStripItem) this.buttonShow3DModel,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.buttonImport3DModel,
        (ToolStripItem) this.buttonExport3DModel,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.buttonRemove3DModel
            });
            this.tool3DModel.Location = new Point(3, 558);
            this.tool3DModel.Name = "tool3DModel";
            this.tool3DModel.Size = new Size(679, 25);
            this.tool3DModel.TabIndex = 2;
            this.buttonShow3DModel.CheckOnClick = true;
            this.buttonShow3DModel.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.buttonShow3DModel.Image = (Image)resources.GetObject("buttonShow3DModel.Image");
            this.buttonShow3DModel.ImageTransparentColor = Color.Magenta;
            this.buttonShow3DModel.Name = "buttonShow3DModel";
            this.buttonShow3DModel.Size = new Size(23, 22);
            this.buttonShow3DModel.Text = "Show / Hide";
            this.buttonShow3DModel.Click += new EventHandler(this.buttonShow3DModel_Click);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(6, 25);
            this.buttonImport3DModel.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.buttonImport3DModel.Image = (Image)resources.GetObject("buttonImport3DModel.Image");
            this.buttonImport3DModel.ImageTransparentColor = Color.Magenta;
            this.buttonImport3DModel.Name = "buttonImport3DModel";
            this.buttonImport3DModel.Size = new Size(23, 22);
            this.buttonImport3DModel.Text = "Import 3D Model";
            this.buttonImport3DModel.Click += new EventHandler(this.buttonImport3DModel_Click);
            this.buttonExport3DModel.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.buttonExport3DModel.Image = (Image)resources.GetObject("buttonExport3DModel.Image");
            this.buttonExport3DModel.ImageTransparentColor = Color.Magenta;
            this.buttonExport3DModel.Name = "buttonExport3DModel";
            this.buttonExport3DModel.Size = new Size(23, 22);
            this.buttonExport3DModel.Text = "Export 3D Model";
            this.buttonExport3DModel.Click += new EventHandler(this.buttonExport3DModel_Click);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new Size(6, 25);
            this.buttonRemove3DModel.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.buttonRemove3DModel.Image = (Image)resources.GetObject("buttonRemove3DModel.Image");
            this.buttonRemove3DModel.ImageTransparentColor = Color.Magenta;
            this.buttonRemove3DModel.Name = "buttonRemove3DModel";
            this.buttonRemove3DModel.Size = new Size(23, 22);
            this.buttonRemove3DModel.Text = "Remove 3D Model";
            this.buttonRemove3DModel.Click += new EventHandler(this.buttonRemove3DModel_Click);
            this.panel1.Controls.Add((Control)this.checkIsAvailableInStore);
            this.panel1.Controls.Add((Control)this.textShoesType);
            this.panel1.Controls.Add((Control)this.labelId);
            this.panel1.Controls.Add((Control)this.textShoesName);
            this.panel1.Controls.Add((Control)this.numericShoesColor);
            this.panel1.Controls.Add((Control)this.label1);
            this.panel1.Controls.Add((Control)this.multiViewer2DShoesColor);
            this.panel1.Dock = DockStyle.Left;
            this.panel1.Location = new Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(260, 755);
            this.panel1.TabIndex = 3;
            this.textShoesType.Enabled = false;
            this.textShoesType.Location = new Point(51, 363);
            this.textShoesType.Name = "textShoesType";
            this.textShoesType.Size = new Size(73, 20);
            this.textShoesType.TabIndex = 65;
            this.textShoesType.TextAlign = HorizontalAlignment.Center;
            this.labelId.AutoSize = true;
            this.labelId.Location = new Point(10, 366);
            this.labelId.Name = "labelId";
            this.labelId.Size = new Size(16, 13);
            this.labelId.TabIndex = 64;
            this.labelId.Text = "Id";
            this.labelId.TextAlign = ContentAlignment.MiddleLeft;
            this.textShoesName.Location = new Point(7, 337);
            this.textShoesName.Name = "textShoesName";
            this.textShoesName.Size = new Size(250, 20);
            this.textShoesName.TabIndex = 0;
            this.textShoesName.TextChanged += new EventHandler(this.textShoesName_TextChanged);
            this.numericShoesColor.Location = new Point(51, 3);
            this.numericShoesColor.Maximum = new Decimal(new int[4]
            {
        31,
        0,
        0,
        0
            });
            this.numericShoesColor.Name = "numericShoesColor";
            this.numericShoesColor.Size = new Size(76, 20);
            this.numericShoesColor.TabIndex = 63;
            this.numericShoesColor.TextAlign = HorizontalAlignment.Center;
            this.numericShoesColor.Value = new Decimal(new int[4]
            {
        1,
        0,
        0,
        0
            });
            this.numericShoesColor.ValueChanged += new EventHandler(this.numericShoesColor_ValueChanged);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new Size(31, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Color";
            this.multiViewer2DShoesColor.AutoTransparency = false;
            this.multiViewer2DShoesColor.Bitmaps = (Bitmap[])null;
            this.multiViewer2DShoesColor.CheckBitmapSize = true;
            this.multiViewer2DShoesColor.FixedSize = true;
            this.multiViewer2DShoesColor.FullSizeButton = false;
            this.multiViewer2DShoesColor.LabelText = "Texture";
            this.multiViewer2DShoesColor.Location = new Point(3, 28);
            this.multiViewer2DShoesColor.Name = "multiViewer2DShoesColor";
            this.multiViewer2DShoesColor.ShowDeleteButton = true;
            this.multiViewer2DShoesColor.Size = new Size(256, 303);
            this.multiViewer2DShoesColor.TabIndex = 1;
            this.pickUpControl.BackColor = SystemColors.Control;
            this.pickUpControl.CloneButtonEnabled = true;
            this.pickUpControl.CreateButtonEnabled = false;
            this.pickUpControl.CurrentIndex = 0;
            this.pickUpControl.Dock = DockStyle.Top;
            this.pickUpControl.FilterByList = (string[])null;
            this.pickUpControl.FilterEnabled = false;
            this.pickUpControl.FilterValues = (IdArrayList[])null;
            this.pickUpControl.Location = new Point(0, 0);
            this.pickUpControl.MainSelectionEnabled = true;
            this.pickUpControl.Name = "pickUpControl";
            this.pickUpControl.ObjectList = (IdArrayList)null;
            this.pickUpControl.RefreshButtonEnabled = true;
            this.pickUpControl.RemoveButtonEnabled = true;
            this.pickUpControl.SearchEnabled = false;
            this.pickUpControl.Size = new Size(1036, 25);
            this.pickUpControl.TabIndex = 1;
            this.pickUpControl.WizardButtonEnabled = false;
            this.pickUpControl.YoungPlayersEnabled = false;
            this.checkIsAvailableInStore.AutoSize = true;
            this.checkIsAvailableInStore.Location = new Point(139, 365);
            this.checkIsAvailableInStore.Name = "checkIsAvailableInStore";
            this.checkIsAvailableInStore.Size = new Size(80, 17);
            this.checkIsAvailableInStore.TabIndex = 0;
            this.checkIsAvailableInStore.Text = "Is Available";
            this.checkIsAvailableInStore.UseVisualStyleBackColor = true;
            this.checkIsAvailableInStore.CheckedChanged += new EventHandler(this.checkIsAvailableInStore_CheckedChanged);
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1036, 780);
            this.Controls.Add((Control)this.splitContainer1);
            this.Controls.Add((Control)this.panel1);
            this.Controls.Add((Control)this.pickUpControl);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "ShoesForm";
            this.Text = "ShoesForm";
            this.Load += new EventHandler(this.ShoesForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.group3D.ResumeLayout(false);
            this.group3D.PerformLayout();
            this.tool3DModel.ResumeLayout(false);
            this.tool3DModel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.numericShoesColor.EndInit();
            this.ResumeLayout(false);
        }
    }
}
