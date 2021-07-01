// Original code created by Rinaldo

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FifaControls
{
  public class ModelManager : UserControl
  {
    private IContainer components;
    private ToolStrip toolStrip1;
    public Viewer3D viewer;
    public ToolStripButton buttonShow;
    public ToolStripButton buttonImport;
    public ToolStripButton buttonExport;
    public ToolStripButton buttonRemove;

    public ModelManager()
    {
      this.InitializeComponent();
    }

    private void buttonShow_Click(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager resources = new ComponentResourceManager(typeof (ModelManager));
      this.toolStrip1 = new ToolStrip();
      this.buttonShow = new ToolStripButton();
      this.buttonImport = new ToolStripButton();
      this.buttonExport = new ToolStripButton();
      this.buttonRemove = new ToolStripButton();
      this.viewer = new Viewer3D();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      this.toolStrip1.Dock = DockStyle.Bottom;
      this.toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
      this.toolStrip1.Items.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.buttonShow,
        (ToolStripItem) this.buttonImport,
        (ToolStripItem) this.buttonExport,
        (ToolStripItem) this.buttonRemove
      });
      this.toolStrip1.Location = new Point(0, 285);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new Size(324, 25);
      this.toolStrip1.TabIndex = 0;
      this.toolStrip1.Text = "toolStrip";
      this.buttonShow.Checked = true;
      this.buttonShow.CheckOnClick = true;
      this.buttonShow.CheckState = CheckState.Checked;
      this.buttonShow.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonShow.Image = (Image) resources.GetObject("buttonShow.Image");
      this.buttonShow.ImageTransparentColor = Color.Magenta;
      this.buttonShow.Name = "buttonShow";
      this.buttonShow.Size = new Size(23, 22);
      this.buttonShow.Text = "Show / Hide";
      this.buttonShow.Click += new EventHandler(this.buttonShow_Click);
      this.buttonImport.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonImport.Image = (Image) resources.GetObject("buttonImport.Image");
      this.buttonImport.ImageTransparentColor = Color.Magenta;
      this.buttonImport.Name = "buttonImport";
      this.buttonImport.Size = new Size(23, 22);
      this.buttonImport.Text = "Import 3D Model";
      this.buttonExport.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonExport.Image = (Image) resources.GetObject("buttonExport.Image");
      this.buttonExport.ImageTransparentColor = Color.Magenta;
      this.buttonExport.Name = "buttonExport";
      this.buttonExport.Size = new Size(23, 22);
      this.buttonExport.Text = "Export 3D Model";
      this.buttonRemove.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonRemove.Image = (Image) resources.GetObject("buttonRemove.Image");
      this.buttonRemove.ImageTransparentColor = Color.Magenta;
      this.buttonRemove.Name = "buttonRemove";
      this.buttonRemove.Size = new Size(23, 22);
      this.buttonRemove.Text = "Remove 3D Model";
      this.viewer.BackColor = Color.Gray;
      this.viewer.BorderStyle = BorderStyle.Fixed3D;
      this.viewer.Dock = DockStyle.Fill;
      this.viewer.LightDirectionZ = 0.0f;
      this.viewer.LightX = 0.0f;
      this.viewer.LightY = 100f;
      this.viewer.LightZ = 100f;
      this.viewer.Location = new Point(0, 0);
      this.viewer.Name = "viewer";
      this.viewer.RotationX = 0.0f;
      this.viewer.RotationY = 0.0f;
      this.viewer.Size = new Size(324, 285);
      this.viewer.TabIndex = 1;
      this.viewer.ViewX = 0.0f;
      this.viewer.ViewY = 100f;
      this.viewer.ViewZ = 100f;
      this.viewer.ZbufferRenderState = (bool[]) null;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.viewer);
      this.Controls.Add((Control) this.toolStrip1);
      this.Name = "ModelManager";
      this.Size = new Size(324, 310);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public delegate bool ModelExportHandler(object sender, string rx3FileName);

    public delegate bool ModelImportHandler(object sender, string rx3FileName);

    public delegate bool ModelDeleteHandler(object sender, string rx3FileName);
  }
}
