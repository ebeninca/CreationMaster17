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
    private Viewer3D viewer3D;
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
      ComponentResourceManager resources = new ComponentResourceManager(typeof (ManagerForm));
      this.splitContainer1 = new SplitContainer();
      this.checkManagerCoat = new CheckBox();
      this.comboManagerDress = new ComboBox();
      this.comboManagerSkin = new ComboBox();
      this.label2 = new Label();
      this.label1 = new Label();
      this.numericManagerColor = new NumericUpDown();
      this.labellManagerSkin = new Label();
      this.viewer2DManager = new Viewer2D();
      this.group3D = new GroupBox();
      this.viewer3D = new Viewer3D();
      this.toolNear3D = new ToolStrip();
      this.buttonShow3DModel = new ToolStripButton();
      this.comboManagerBodyType = new ToolStripComboBox();
      this.splitContainer1.BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.numericManagerColor.BeginInit();
      this.group3D.SuspendLayout();
      this.toolNear3D.SuspendLayout();
      this.SuspendLayout();
      this.splitContainer1.Dock = DockStyle.Fill;
      this.splitContainer1.Location = new Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Panel1.Controls.Add((Control) this.checkManagerCoat);
      this.splitContainer1.Panel1.Controls.Add((Control) this.comboManagerDress);
      this.splitContainer1.Panel1.Controls.Add((Control) this.comboManagerSkin);
      this.splitContainer1.Panel1.Controls.Add((Control) this.label2);
      this.splitContainer1.Panel1.Controls.Add((Control) this.label1);
      this.splitContainer1.Panel1.Controls.Add((Control) this.numericManagerColor);
      this.splitContainer1.Panel1.Controls.Add((Control) this.labellManagerSkin);
      this.splitContainer1.Panel1.Controls.Add((Control) this.viewer2DManager);
      this.splitContainer1.Panel2.Controls.Add((Control) this.group3D);
      this.splitContainer1.Size = new Size(1024, 780);
      this.splitContainer1.SplitterDistance = 539;
      this.splitContainer1.TabIndex = 0;
      this.checkManagerCoat.Location = new Point(9, 89);
      this.checkManagerCoat.Name = "checkManagerCoat";
      this.checkManagerCoat.RightToLeft = RightToLeft.Yes;
      this.checkManagerCoat.Size = new Size(173, 24);
      this.checkManagerCoat.TabIndex = 87;
      this.checkManagerCoat.Text = "Winter Coat";
      this.checkManagerCoat.TextAlign = ContentAlignment.MiddleRight;
      this.checkManagerCoat.UseVisualStyleBackColor = true;
      this.checkManagerCoat.CheckedChanged += new EventHandler(this.checkManagerCoat_CheckedChanged);
      this.comboManagerDress.FormattingEnabled = true;
      this.comboManagerDress.Items.AddRange(new object[3]
      {
        (object) "Jacket",
        (object) "Shirt",
        (object) "Sportswear"
      });
      this.comboManagerDress.Location = new Point(121, 36);
      this.comboManagerDress.Name = "comboManagerDress";
      this.comboManagerDress.Size = new Size(121, 21);
      this.comboManagerDress.TabIndex = 85;
      this.comboManagerDress.SelectedIndexChanged += new EventHandler(this.comboManagerDress_SelectedIndexChanged);
      this.comboManagerSkin.FormattingEnabled = true;
      this.comboManagerSkin.Items.AddRange(new object[10]
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
      this.comboManagerSkin.Location = new Point(121, 9);
      this.comboManagerSkin.Name = "comboManagerSkin";
      this.comboManagerSkin.Size = new Size(121, 21);
      this.comboManagerSkin.TabIndex = 84;
      this.comboManagerSkin.SelectedIndexChanged += new EventHandler(this.comboManagerSkin_SelectedIndexChanged);
      this.label2.AutoSize = true;
      this.label2.BackColor = SystemColors.Control;
      this.label2.ImeMode = ImeMode.NoControl;
      this.label2.Location = new Point(12, 67);
      this.label2.Name = "label2";
      this.label2.Size = new Size(61, 13);
      this.label2.TabIndex = 82;
      this.label2.Text = "Dress Color";
      this.label2.TextAlign = ContentAlignment.MiddleLeft;
      this.label1.AutoSize = true;
      this.label1.BackColor = SystemColors.Control;
      this.label1.ImeMode = ImeMode.NoControl;
      this.label1.Location = new Point(12, 39);
      this.label1.Name = "label1";
      this.label1.Size = new Size(61, 13);
      this.label1.TabIndex = 81;
      this.label1.Text = "Dress Type";
      this.label1.TextAlign = ContentAlignment.MiddleLeft;
      this.numericManagerColor.Location = new Point(121, 63);
      this.numericManagerColor.Maximum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericManagerColor.Name = "numericManagerColor";
      this.numericManagerColor.Size = new Size(121, 20);
      this.numericManagerColor.TabIndex = 79;
      this.numericManagerColor.TextAlign = HorizontalAlignment.Center;
      this.numericManagerColor.ValueChanged += new EventHandler(this.numericManager3_ValueChanged);
      this.labellManagerSkin.AutoSize = true;
      this.labellManagerSkin.BackColor = SystemColors.Control;
      this.labellManagerSkin.ImeMode = ImeMode.NoControl;
      this.labellManagerSkin.Location = new Point(11, 12);
      this.labellManagerSkin.Name = "labellManagerSkin";
      this.labellManagerSkin.Size = new Size(28, 13);
      this.labellManagerSkin.TabIndex = 76;
      this.labellManagerSkin.Text = "Skin";
      this.labellManagerSkin.TextAlign = ContentAlignment.MiddleLeft;
      this.viewer2DManager.AutoTransparency = false;
      this.viewer2DManager.BackColor = Color.Transparent;
      this.viewer2DManager.ButtonStripVisible = true;
      this.viewer2DManager.CurrentBitmap = (Bitmap) null;
      this.viewer2DManager.ExtendedFormat = false;
      this.viewer2DManager.FullSizeButton = true;
      this.viewer2DManager.ImageLayout = ImageLayout.Zoom;
      this.viewer2DManager.ImageSize = new Size(1024, 1024);
      this.viewer2DManager.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DManager.Location = new Point(14, (int) sbyte.MaxValue);
      this.viewer2DManager.Name = "viewer2DManager";
      this.viewer2DManager.RemoveButton = false;
      this.viewer2DManager.ShowButton = false;
      this.viewer2DManager.ShowButtonChecked = true;
      this.viewer2DManager.Size = new Size(512, 537);
      this.viewer2DManager.TabIndex = 3;
      this.viewer2DManager.TabStop = false;
      this.group3D.Controls.Add((Control) this.viewer3D);
      this.group3D.Controls.Add((Control) this.toolNear3D);
      this.group3D.Dock = DockStyle.Fill;
      this.group3D.Location = new Point(0, 0);
      this.group3D.Name = "group3D";
      this.group3D.Size = new Size(481, 780);
      this.group3D.TabIndex = 2;
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
      this.viewer3D.LightY = 180f;
      this.viewer3D.LightZ = 30f;
      this.viewer3D.Location = new Point(3, 16);
      this.viewer3D.Name = "viewer3D";
      this.viewer3D.RotationX = 0.0f;
      this.viewer3D.RotationY = 6.28f;
      this.viewer3D.RotationYCoeff = 0.01f;
      this.viewer3D.Size = new Size(475, 736);
      this.viewer3D.TabIndex = 1;
      this.viewer3D.ViewX = 0.0f;
      this.viewer3D.ViewY = 90f;
      this.viewer3D.ViewZ = 270f;
      this.viewer3D.ZbufferRenderState = (bool[]) null;
      this.toolNear3D.Dock = DockStyle.Bottom;
      this.toolNear3D.GripStyle = ToolStripGripStyle.Hidden;
      this.toolNear3D.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.buttonShow3DModel,
        (ToolStripItem) this.comboManagerBodyType
      });
      this.toolNear3D.Location = new Point(3, 752);
      this.toolNear3D.Name = "toolNear3D";
      this.toolNear3D.Size = new Size(475, 25);
      this.toolNear3D.TabIndex = 2;
      this.buttonShow3DModel.CheckOnClick = true;
      this.buttonShow3DModel.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonShow3DModel.Image = (Image) resources.GetObject("buttonShow3DModel.Image");
      this.buttonShow3DModel.ImageTransparentColor = Color.Magenta;
      this.buttonShow3DModel.Name = "buttonShow3DModel";
      this.buttonShow3DModel.Size = new Size(23, 22);
      this.buttonShow3DModel.Text = "Show / Hide";
      this.buttonShow3DModel.Click += new EventHandler(this.buttonShow3DModel_Click);
      this.comboManagerBodyType.Items.AddRange(new object[3]
      {
        (object) "Average",
        (object) "Lean",
        (object) "Stocky"
      });
      this.comboManagerBodyType.Name = "comboManagerBodyType";
      this.comboManagerBodyType.Size = new Size(121, 25);
      this.comboManagerBodyType.SelectedIndexChanged += new EventHandler(this.comboManagerBodyType_SelectedIndexChanged);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1024, 780);
      this.Controls.Add((Control) this.splitContainer1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = "ManagerForm";
      this.Text = "ManagerForm";
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.numericManagerColor.EndInit();
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
      this.m_CurrentColor = (int) this.numericManagerColor.Value;
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
          if (currentBitmap == null || managerModel == null)
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
          }
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
