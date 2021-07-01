// Original code created by Rinaldo

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FifaControls
{
  public class FullSizeViewer : Form
  {
    private IContainer components;
    private ToolStrip toolStrip;
    private ToolStripButton toolStripButton1;
    private PictureBox pictureBox;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager resources = new ComponentResourceManager(typeof (FullSizeViewer));
      this.toolStrip = new ToolStrip();
      this.toolStripButton1 = new ToolStripButton();
      this.pictureBox = new PictureBox();
      this.toolStrip.SuspendLayout();
      ((ISupportInitialize) this.pictureBox).BeginInit();
      this.SuspendLayout();
      this.toolStrip.GripStyle = ToolStripGripStyle.Hidden;
      this.toolStrip.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.toolStripButton1
      });
      this.toolStrip.Location = new Point(0, 0);
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.Size = new Size(292, 25);
      this.toolStrip.TabIndex = 0;
      this.toolStrip.Text = "toolStrip";
      this.toolStripButton1.Image = (Image) resources.GetObject("toolStripButton1.Image");
      this.toolStripButton1.ImageScaling = ToolStripItemImageScaling.None;
      this.toolStripButton1.ImageTransparentColor = Color.Magenta;
      this.toolStripButton1.Name = "toolStripButton1";
      this.toolStripButton1.Padding = new Padding(16, 0, 0, 0);
      this.toolStripButton1.Size = new Size(69, 22);
      this.toolStripButton1.Text = "Close";
      this.toolStripButton1.Click += new EventHandler(this.toolStripButton1_Click);
      this.pictureBox.BackgroundImageLayout = ImageLayout.Center;
      this.pictureBox.Dock = DockStyle.Fill;
      this.pictureBox.Location = new Point(0, 25);
      this.pictureBox.Name = "pictureBox";
      this.pictureBox.Size = new Size(292, 241);
      this.pictureBox.TabIndex = 1;
      this.pictureBox.TabStop = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.AutoScroll = true;
      this.BackgroundImageLayout = ImageLayout.Center;
      this.ClientSize = new Size(292, 266);
      this.Controls.Add((Control) this.pictureBox);
      this.Controls.Add((Control) this.toolStrip);
      this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
      this.Name = "FullSizeViewer";
      this.Text = "Full Size Viewer";
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      ((ISupportInitialize) this.pictureBox).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public FullSizeViewer()
    {
      this.InitializeComponent();
    }

    public void SetImage(Image image)
    {
      this.Width = image.Width + 10;
      this.Height = image.Height + 50;
      this.pictureBox.BackgroundImage = image;
    }

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
