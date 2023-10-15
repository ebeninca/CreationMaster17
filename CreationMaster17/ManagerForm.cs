// Original code created by Rinaldo

using FifaControls;
using FifaLibrary;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CreationMaster
{
    public class ManagerForm : Form
    {
        private int m_CurrentSkin = 2;
        private IContainer components;
        private SplitContainer splitContainer1;
        private Viewer2D viewer2DManager;
        private Label labellManagerSkin;
        private NumericUpDown numericManagerColor;
        private GroupBox group3D;
        private FbxViewer3D viewer3D;
        private ToolStrip toolNear3D;
        private ToolStripButton buttonShow3DModel;
        private Label label2;
        private Label label1;
        private CheckBox checkManagerCoat;
        private ComboBox comboManagerDress;
        private ComboBox comboManagerSkin;
        private ToolStripComboBox comboManagerBodyType;
        private int m_CurrentDress;
        private int m_CurrentColor;
        private int m_CurrentCoat;
        private int m_Body;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.checkManagerCoat = new System.Windows.Forms.CheckBox();
            this.comboManagerDress = new System.Windows.Forms.ComboBox();
            this.comboManagerSkin = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericManagerColor = new System.Windows.Forms.NumericUpDown();
            this.labellManagerSkin = new System.Windows.Forms.Label();
            this.viewer2DManager = new FifaControls.Viewer2D();
            this.group3D = new System.Windows.Forms.GroupBox();
            this.viewer3D = new FifaControls.FbxViewer3D();
            this.toolNear3D = new System.Windows.Forms.ToolStrip();
            this.buttonShow3DModel = new System.Windows.Forms.ToolStripButton();
            this.comboManagerBodyType = new System.Windows.Forms.ToolStripComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericManagerColor)).BeginInit();
            this.group3D.SuspendLayout();
            this.toolNear3D.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.checkManagerCoat);
            this.splitContainer1.Panel1.Controls.Add(this.comboManagerDress);
            this.splitContainer1.Panel1.Controls.Add(this.comboManagerSkin);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.numericManagerColor);
            this.splitContainer1.Panel1.Controls.Add(this.labellManagerSkin);
            this.splitContainer1.Panel1.Controls.Add(this.viewer2DManager);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.group3D);
            this.splitContainer1.Size = new System.Drawing.Size(1024, 780);
            this.splitContainer1.SplitterDistance = 539;
            this.splitContainer1.TabIndex = 0;
            // 
            // checkManagerCoat
            // 
            this.checkManagerCoat.Location = new System.Drawing.Point(9, 89);
            this.checkManagerCoat.Name = "checkManagerCoat";
            this.checkManagerCoat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkManagerCoat.Size = new System.Drawing.Size(173, 24);
            this.checkManagerCoat.TabIndex = 87;
            this.checkManagerCoat.Text = "Winter Coat";
            this.checkManagerCoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkManagerCoat.UseVisualStyleBackColor = true;
            this.checkManagerCoat.CheckedChanged += new System.EventHandler(this.checkManagerCoat_CheckedChanged);
            // 
            // comboManagerDress
            // 
            this.comboManagerDress.FormattingEnabled = true;
            this.comboManagerDress.Items.AddRange(new object[] {
            "Jacket",
            "Shirt",
            "Sportswear"});
            this.comboManagerDress.Location = new System.Drawing.Point(121, 36);
            this.comboManagerDress.Name = "comboManagerDress";
            this.comboManagerDress.Size = new System.Drawing.Size(121, 21);
            this.comboManagerDress.TabIndex = 85;
            this.comboManagerDress.SelectedIndexChanged += new System.EventHandler(this.comboManagerDress_SelectedIndexChanged);
            // 
            // comboManagerSkin
            // 
            this.comboManagerSkin.FormattingEnabled = true;
            this.comboManagerSkin.Items.AddRange(new object[] {
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
            this.comboManagerSkin.Location = new System.Drawing.Point(121, 9);
            this.comboManagerSkin.Name = "comboManagerSkin";
            this.comboManagerSkin.Size = new System.Drawing.Size(121, 21);
            this.comboManagerSkin.TabIndex = 84;
            this.comboManagerSkin.SelectedIndexChanged += new System.EventHandler(this.comboManagerSkin_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 82;
            this.label2.Text = "Dress Color";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 81;
            this.label1.Text = "Dress Type";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericManagerColor
            // 
            this.numericManagerColor.Location = new System.Drawing.Point(121, 63);
            this.numericManagerColor.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericManagerColor.Name = "numericManagerColor";
            this.numericManagerColor.Size = new System.Drawing.Size(121, 20);
            this.numericManagerColor.TabIndex = 79;
            this.numericManagerColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericManagerColor.ValueChanged += new System.EventHandler(this.numericManager3_ValueChanged);
            // 
            // labellManagerSkin
            // 
            this.labellManagerSkin.AutoSize = true;
            this.labellManagerSkin.BackColor = System.Drawing.SystemColors.Control;
            this.labellManagerSkin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labellManagerSkin.Location = new System.Drawing.Point(11, 12);
            this.labellManagerSkin.Name = "labellManagerSkin";
            this.labellManagerSkin.Size = new System.Drawing.Size(28, 13);
            this.labellManagerSkin.TabIndex = 76;
            this.labellManagerSkin.Text = "Skin";
            this.labellManagerSkin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // viewer2DManager
            // 
            this.viewer2DManager.AutoTransparency = false;
            this.viewer2DManager.BackColor = System.Drawing.Color.Transparent;
            this.viewer2DManager.ButtonStripVisible = true;
            this.viewer2DManager.CurrentBitmap = null;
            this.viewer2DManager.ExtendedFormat = false;
            this.viewer2DManager.FullSizeButton = true;
            this.viewer2DManager.ImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.viewer2DManager.ImageSize = new System.Drawing.Size(1024, 1024);
            this.viewer2DManager.ImageSizeMultiplier = FifaControls.Viewer2D.SizeMultiplier.None;
            this.viewer2DManager.Location = new System.Drawing.Point(14, 127);
            this.viewer2DManager.Name = "viewer2DManager";
            this.viewer2DManager.RemoveButton = false;
            this.viewer2DManager.ShowButton = false;
            this.viewer2DManager.ShowButtonChecked = true;
            this.viewer2DManager.Size = new System.Drawing.Size(512, 537);
            this.viewer2DManager.TabIndex = 3;
            this.viewer2DManager.TabStop = false;
            // 
            // group3D
            // 
            this.group3D.Controls.Add(this.viewer3D);
            this.group3D.Controls.Add(this.toolNear3D);
            this.group3D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group3D.Location = new System.Drawing.Point(0, 0);
            this.group3D.Name = "group3D";
            this.group3D.Size = new System.Drawing.Size(481, 780);
            this.group3D.TabIndex = 2;
            this.group3D.TabStop = false;
            this.group3D.Text = "3D Model";
            // 
            // viewer3D
            // 
            this.viewer3D.AmbientColor = System.Drawing.Color.Black;
            this.viewer3D.BackColor = System.Drawing.Color.Gray;
            this.viewer3D.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.viewer3D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer3D.FilesPath = null;
            this.viewer3D.Location = new System.Drawing.Point(3, 16);
            this.viewer3D.Name = "viewer3D";
            this.viewer3D.ObjectId = -1;
            this.viewer3D.ObjectType = FifaControls.FbxViewer3D.ObjectTypeServerPort.Manager;
            this.viewer3D.Size = new System.Drawing.Size(475, 736);
            this.viewer3D.TabIndex = 0;
            this.viewer3D.Textures = null;
            // 
            // toolNear3D
            // 
            this.toolNear3D.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolNear3D.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolNear3D.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonShow3DModel,
            this.comboManagerBodyType});
            this.toolNear3D.Location = new System.Drawing.Point(3, 752);
            this.toolNear3D.Name = "toolNear3D";
            this.toolNear3D.Size = new System.Drawing.Size(475, 25);
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
            // comboManagerBodyType
            // 
            this.comboManagerBodyType.Items.AddRange(new object[] {
            "Average",
            "Lean",
            "Stocky"});
            this.comboManagerBodyType.Name = "comboManagerBodyType";
            this.comboManagerBodyType.Size = new System.Drawing.Size(121, 25);
            this.comboManagerBodyType.SelectedIndexChanged += new System.EventHandler(this.comboManagerBodyType_SelectedIndexChanged);
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 780);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManagerForm";
            this.Text = "ManagerForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericManagerColor)).EndInit();
            this.group3D.ResumeLayout(false);
            this.group3D.PerformLayout();
            this.toolNear3D.ResumeLayout(false);
            this.toolNear3D.PerformLayout();
            this.ResumeLayout(false);

        }

        public ManagerForm()
        {
            this.InitializeComponent();
            this.viewer2DManager.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageManager);
            this.viewer2DManager.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteManager);
            this.viewer2DManager.ButtonStripVisible = true;
            this.viewer2DManager.RemoveButton = true;
            if (this.comboManagerBodyType.SelectedIndex >= 0)
                return;
            this.comboManagerBodyType.SelectedIndex = 0;
        }

        public void Clean()
        {
            this.Visible = false;
        }

        private void ShowManager()
        {
            this.viewer2DManager.CurrentBitmap = Manager.GetManagerTextures(this.m_CurrentDress, this.m_CurrentSkin, this.m_CurrentColor, this.m_CurrentCoat);
            this.Show3DManager();
        }

        private void LoadManager()
        {
            this.ShowManager();
        }

        private void numericManager3_ValueChanged(object sender, EventArgs e)
        {
            this.m_CurrentColor = (int)this.numericManagerColor.Value;
            this.ShowManager();
        }

        private void buttonShow3DModel_Click(object sender, EventArgs e)
        {
            this.Show3DManager();
        }

        public void Show3DManager()
        {
            if (!this.buttonShow3DModel.Checked)
            {
                this.viewer3D.ShowEmpty();
            }
            else
            {
                Bitmap currentBitmap = this.viewer2DManager.CurrentBitmap;
                if (currentBitmap == null)
                {
                    this.viewer3D.ShowEmpty();
                }
                else
                {
                    Rx3File managerModel = Manager.GetManagerModel(this.m_CurrentDress, this.m_Body, this.m_CurrentCoat);
                    /*if (currentBitmap == null || managerModel == null)
                    {
                      this.viewer3D.Clean(1);
                    }
                    else
                    {
                      Rx3IndexArray.TriangleListType = Rx3IndexArray.ETriangleListType.InvertEven;
                      Model3D model3D = new Model3D(managerModel.Rx3IndexArrays[0], managerModel.Rx3VertexArrays[0], currentBitmap);
                      this.viewer3D.Clean(1);
                      this.viewer3D.SetMesh(0, model3D);
                      this.viewer3D.Render();
                    }*/
                }
            }
        }

        private void comboManagerSkin_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.m_CurrentSkin = this.comboManagerSkin.SelectedIndex + 1;
            this.ShowManager();
        }

        private void comboManagerDress_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.m_CurrentDress = this.comboManagerDress.SelectedIndex;
            this.ShowManager();
        }

        private void checkManagerCoat_CheckedChanged(object sender, EventArgs e)
        {
            this.m_CurrentCoat = this.checkManagerCoat.Checked ? 1 : 0;
            this.ShowManager();
        }

        private bool ImportImageManager(object sender, Bitmap bitmap)
        {
            return Manager.SetManager(this.m_CurrentDress, this.m_CurrentSkin, this.m_CurrentColor, this.m_CurrentCoat, bitmap);
        }

        private bool DeleteManager(object sender)
        {
            return Manager.DeleteManagerTexture(this.m_CurrentDress, this.m_CurrentSkin, this.m_CurrentColor, this.m_CurrentCoat);
        }

        private void comboManagerBodyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboManagerBodyType.SelectedIndex < 0)
                return;
            this.m_Body = this.comboManagerBodyType.SelectedIndex;
            this.ShowManager();
        }
    }
}
