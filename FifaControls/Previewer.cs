// Original code created by Rinaldo

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace FifaControls
{
  public class Previewer : UserControl
  {
    private IContainer components;
    private PictureBox pictureBox;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.pictureBox = new PictureBox();
      ((ISupportInitialize) this.pictureBox).BeginInit();
      this.SuspendLayout();
      this.pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
      this.pictureBox.Dock = DockStyle.Fill;
      this.pictureBox.Location = new Point(0, 0);
      this.pictureBox.Name = "pictureBox";
      this.pictureBox.Size = new Size(150, 150);
      this.pictureBox.TabIndex = 0;
      this.pictureBox.TabStop = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.pictureBox);
      this.Name = "Previewer";
      ((ISupportInitialize) this.pictureBox).EndInit();
      this.ResumeLayout(false);
    }

    public Previewer()
    {
      this.InitializeComponent();
    }

    public void Show(Image bitmap, int x, int y, int srcWidth, int srcHeight)
    {
      if (bitmap == null)
      {
        this.pictureBox.BackgroundImage = (Image) null;
      }
      else
      {
        int width = this.pictureBox.Width;
        int height = this.pictureBox.Height;
        if (this.pictureBox.BackgroundImage != null)
          this.pictureBox.BackgroundImage.Dispose();
        this.pictureBox.BackgroundImage = (Image) new Bitmap(this.pictureBox.Width, this.pictureBox.Height, PixelFormat.Format32bppArgb);
        Graphics graphics = Graphics.FromImage(this.pictureBox.BackgroundImage);
        graphics.InterpolationMode = InterpolationMode.Bicubic;
        graphics.DrawImage(bitmap, new Rectangle(0, 0, this.pictureBox.Width, this.pictureBox.Height), new Rectangle(x, y, srcWidth, srcHeight), GraphicsUnit.Pixel);
        graphics.Dispose();
      }
    }
  }
}
