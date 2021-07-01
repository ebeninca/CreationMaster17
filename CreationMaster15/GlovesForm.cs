// Original code created by Rinaldo

using FifaControls;
using FifaLibrary;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CreationMaster
{
  public class GlovesForm : Form
  {
    private NewIdCreator m_NewIdCreator = new NewIdCreator();
    private GkGloves m_CurrentGkGloves;
    private bool m_IsLoaded;
    private IContainer components;
    public PickUpControl pickUpControl;
    private SplitContainer splitContainer1;
    private SplitContainer splitContainer2;
    private MultiViewer2D multiViewer2DGkGloves;
    private Viewer3D viewer3D;
    private ToolStrip toolNear3D;
    private ToolStripButton buttonShow3DModel;
    private ToolStripSeparator toolStripSeparator1;

    public GlovesForm()
    {
      this.Visible = false;
      this.InitializeComponent();
      this.pickUpControl.SelectObject = new PickUpControl.PickUpCallback(this.SelectGkGloves);
      this.pickUpControl.CreateObject = new PickUpControl.PickUpCallback(this.CreateGkGloves);
      this.pickUpControl.DeleteObject = new PickUpControl.PickUpCallback(this.DeleteGkGloves);
      this.pickUpControl.CloneObject = new PickUpControl.PickUpCallback(this.CloneGkGloves);
      this.pickUpControl.RefreshObject = new PickUpControl.PickUpCallback(this.RefreshGkGloves);
      this.multiViewer2DGkGloves.Rx3ExportDelegate = new MultiViewer2D.Rx3ExportHandler(this.ExportRx3GkGloves);
      this.multiViewer2DGkGloves.Rx3ImportDelegate = new MultiViewer2D.Rx3ImportHandler(this.ImportRx3GkGloves);
      this.multiViewer2DGkGloves.Rx3SaveDelegate = new MultiViewer2D.Rx3SaveHandler(this.SaveBitmapGkGloves);
      this.multiViewer2DGkGloves.Rx3DeleteDelegate = new MultiViewer2D.Rx3DeleteHandler(this.DeleteRx3GkGloves);
    }

    public void Clean()
    {
      this.Visible = false;
    }

    public void Preset()
    {
      this.m_NewIdCreator.IdList = (IdArrayList) FifaEnvironment.GkGloves;
      this.pickUpControl.ObjectList = (IdArrayList) FifaEnvironment.GkGloves;
    }

    private GkGloves SelectGkGloves(object sender, object obj)
    {
      GkGloves gkgloves = (GkGloves) obj;
      this.Refresh();
      this.LoadGkGloves(gkgloves);
      return gkgloves;
    }

    private GkGloves CreateGkGloves(object sender, object obj)
    {
      DialogResult dialogResult = this.m_NewIdCreator.ShowDialog();
      if (this.m_NewIdCreator.NewObject != null)
        return (GkGloves) this.m_NewIdCreator.NewObject;
      if (dialogResult == DialogResult.OK)
      {
        int num = (int) FifaEnvironment.UserMessages.ShowMessage(5060, this.m_NewIdCreator.NewId);
      }
      return (GkGloves) null;
    }

    private GkGloves DeleteGkGloves(object sender, object obj)
    {
      GkGloves gkGloves = (GkGloves) obj;
      GkGloves.DeleteGkGlovesTextures(gkGloves.Id);
      FifaEnvironment.GkGloves.RemoveId((IdObject) gkGloves);
      return (GkGloves) null;
    }

    private GkGloves CloneGkGloves(object sender, object obj)
    {
      DialogResult dialogResult = this.m_NewIdCreator.ShowDialog();
      if (this.m_NewIdCreator.NewObject != null)
        return (GkGloves) FifaEnvironment.GkGloves.CloneId((IdObject) obj, this.m_NewIdCreator.NewObject);
      if (dialogResult == DialogResult.OK)
      {
        int num = (int) FifaEnvironment.UserMessages.ShowMessage(5060, this.m_NewIdCreator.NewId);
      }
      return (GkGloves) null;
    }

    public GkGloves RefreshGkGloves(object sender, object obj)
    {
      this.Preset();
      this.ReloadGkGloves(this.m_CurrentGkGloves);
      return this.m_CurrentGkGloves;
    }

    private void LoadGkGloves(GkGloves gkgloves)
    {
      if (!this.m_IsLoaded || this.m_CurrentGkGloves == gkgloves)
        return;
      this.m_CurrentGkGloves = gkgloves;
      this.multiViewer2DGkGloves.Bitmaps = GkGloves.GetGkGlovesTextures(gkgloves.Id);
      this.Show3DGkGloves();
      GC.Collect();
    }

    private void ReloadGkGloves(GkGloves gkgloves)
    {
      this.m_CurrentGkGloves = (GkGloves) null;
      this.LoadGkGloves(gkgloves);
    }

    public void Show3DGkGloves()
    {
      if (!this.buttonShow3DModel.Checked)
      {
        this.viewer3D.ShowEmpty();
      }
      else
      {
        Bitmap[] gkGlovesTextures = GkGloves.GetGkGlovesTextures(this.m_CurrentGkGloves.Id);
        Bitmap bitmap = GraphicUtil.EmbossBitmap(gkGlovesTextures[0], gkGlovesTextures[1]);
        if (bitmap == null || GkGloves.GkGlovesModel == null)
        {
          this.viewer3D.Clean(1);
        }
        else
        {
          GkGloves.GkGlovesModel.TextureBitmap = bitmap;
          this.viewer3D.Clean(1);
          this.viewer3D.SetMesh(0, GkGloves.GkGlovesModel);
          this.viewer3D.Render();
        }
      }
    }

    private bool SaveBitmapGkGloves(object sender, Bitmap[] bitmaps)
    {
      bool flag = GkGloves.SetGkGlovesTextures(this.m_CurrentGkGloves.Id, bitmaps);
      this.ReloadGkGloves(this.m_CurrentGkGloves);
      return flag;
    }

    private bool ExportRx3GkGloves(object sender, string exportDir)
    {
      return GkGloves.ExportGkGlovesTextures(this.m_CurrentGkGloves.Id, exportDir);
    }

    private bool ImportRx3GkGloves(object sender, string rx3FileName)
    {
      bool flag = GkGloves.SetGkGlovesTextures(this.m_CurrentGkGloves.Id, rx3FileName);
      if (flag)
        this.ReloadGkGloves(this.m_CurrentGkGloves);
      return flag;
    }

    private bool DeleteRx3GkGloves(object sender)
    {
      bool flag = GkGloves.DeleteGkGlovesTextures(this.m_CurrentGkGloves.Id);
      if (flag)
        this.ReloadGkGloves(this.m_CurrentGkGloves);
      return flag;
    }

    private void GkGlovesForm_Load(object sender, EventArgs e)
    {
      this.m_IsLoaded = true;
      this.Preset();
    }

    private void buttonShow3DModel_Click(object sender, EventArgs e)
    {
      this.Show3DGkGloves();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager resources = new ComponentResourceManager(typeof (GlovesForm));
      this.splitContainer1 = new SplitContainer();
      this.multiViewer2DGkGloves = new MultiViewer2D();
      this.splitContainer2 = new SplitContainer();
      this.viewer3D = new Viewer3D();
      this.toolNear3D = new ToolStrip();
      this.buttonShow3DModel = new ToolStripButton();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.pickUpControl = new PickUpControl();
      this.splitContainer1.BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.splitContainer2.BeginInit();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      this.toolNear3D.SuspendLayout();
      this.SuspendLayout();
      this.splitContainer1.Dock = DockStyle.Fill;
      this.splitContainer1.Location = new Point(0, 25);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Panel1.Controls.Add((Control) this.multiViewer2DGkGloves);
      this.splitContainer1.Panel2.Controls.Add((Control) this.splitContainer2);
      this.splitContainer1.Size = new Size(1165, 773);
      this.splitContainer1.SplitterDistance = 516;
      this.splitContainer1.TabIndex = 1;
      this.multiViewer2DGkGloves.AutoTransparency = false;
      this.multiViewer2DGkGloves.Bitmaps = (Bitmap[]) null;
      this.multiViewer2DGkGloves.CheckBitmapSize = true;
      this.multiViewer2DGkGloves.FixedSize = false;
      this.multiViewer2DGkGloves.FullSizeButton = false;
      this.multiViewer2DGkGloves.LabelText = "Image n.";
      this.multiViewer2DGkGloves.Location = new Point(3, 6);
      this.multiViewer2DGkGloves.Name = "multiViewer2DGkGloves";
      this.multiViewer2DGkGloves.ShowDeleteButton = true;
      this.multiViewer2DGkGloves.Size = new Size(512, 552);
      this.multiViewer2DGkGloves.TabIndex = 0;
      this.multiViewer2DGkGloves.Load += new EventHandler(this.GkGlovesForm_Load);
      this.splitContainer2.Dock = DockStyle.Fill;
      this.splitContainer2.Location = new Point(0, 0);
      this.splitContainer2.Name = "splitContainer2";
      this.splitContainer2.Orientation = Orientation.Horizontal;
      this.splitContainer2.Panel1.Controls.Add((Control) this.viewer3D);
      this.splitContainer2.Panel1.Controls.Add((Control) this.toolNear3D);
      this.splitContainer2.Size = new Size(645, 773);
      this.splitContainer2.SplitterDistance = 503;
      this.splitContainer2.TabIndex = 0;
      this.viewer3D.AmbientColor = Color.White;
      this.viewer3D.BackColor = Color.Gray;
      this.viewer3D.BorderStyle = BorderStyle.Fixed3D;
      this.viewer3D.Dock = DockStyle.Fill;
      this.viewer3D.LightDirectionX = 0.0f;
      this.viewer3D.LightDirectionY = 0.0f;
      this.viewer3D.LightDirectionZ = -1f;
      this.viewer3D.LightX = 100f;
      this.viewer3D.LightY = 10f;
      this.viewer3D.LightZ = 100f;
      this.viewer3D.Location = new Point(0, 0);
      this.viewer3D.Name = "viewer3D";
      this.viewer3D.RotationX = 0.18f;
      this.viewer3D.RotationY = 0.93f;
      this.viewer3D.RotationYCoeff = 0.01f;
      this.viewer3D.Size = new Size(645, 478);
      this.viewer3D.TabIndex = 3;
      this.viewer3D.ViewX = 12f;
      this.viewer3D.ViewY = 110f;
      this.viewer3D.ViewZ = 114.2f;
      this.viewer3D.ZbufferRenderState = (bool[]) null;
      this.toolNear3D.Dock = DockStyle.Bottom;
      this.toolNear3D.GripStyle = ToolStripGripStyle.Hidden;
      this.toolNear3D.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.buttonShow3DModel,
        (ToolStripItem) this.toolStripSeparator1
      });
      this.toolNear3D.Location = new Point(0, 478);
      this.toolNear3D.Name = "toolNear3D";
      this.toolNear3D.Size = new Size(645, 25);
      this.toolNear3D.TabIndex = 4;
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
      this.pickUpControl.Size = new Size(1165, 25);
      this.pickUpControl.TabIndex = 0;
      this.pickUpControl.WizardButtonEnabled = false;
      this.pickUpControl.YoungPlayersEnabled = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImageLayout = ImageLayout.Center;
      this.ClientSize = new Size(1165, 798);
      this.Controls.Add((Control) this.splitContainer1);
      this.Controls.Add((Control) this.pickUpControl);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = "GlovesForm";
      this.Text = "GlovesForm";
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel1.PerformLayout();
      this.splitContainer2.EndInit();
      this.splitContainer2.ResumeLayout(false);
      this.toolNear3D.ResumeLayout(false);
      this.toolNear3D.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
