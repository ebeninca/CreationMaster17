// Original code created by Rinaldo

using FifaLibrary;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CreationMaster
{
  public class ModifyHairColor : Form
  {
    private IContainer components;
    private PictureBox pictureBox;
    private Button buttonOk;
    private Button buttonCancel;
    private TrackBar trackBarRed;
    private Label label4;
    private TrackBar trackBarGreen;
    private TrackBar trackBarBlue;
    private Label label5;
    private Label label6;
    private Label label7;
    private Button buttonReset;
    private Bitmap m_InputBitmap;
    private Bitmap m_PreviewBitmap;
    private Bitmap m_OutputBitmap;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.pictureBox = new PictureBox();
      this.buttonOk = new Button();
      this.buttonCancel = new Button();
      this.trackBarRed = new TrackBar();
      this.label4 = new Label();
      this.trackBarGreen = new TrackBar();
      this.trackBarBlue = new TrackBar();
      this.label5 = new Label();
      this.label6 = new Label();
      this.label7 = new Label();
      this.buttonReset = new Button();
      ((ISupportInitialize) this.pictureBox).BeginInit();
      this.trackBarRed.BeginInit();
      this.trackBarGreen.BeginInit();
      this.trackBarBlue.BeginInit();
      this.SuspendLayout();
      this.pictureBox.BackgroundImageLayout = ImageLayout.Zoom;
      this.pictureBox.Location = new Point(12, 12);
      this.pictureBox.Name = "pictureBox";
      this.pictureBox.Size = new Size(256, 256);
      this.pictureBox.TabIndex = 0;
      this.pictureBox.TabStop = false;
      this.buttonOk.DialogResult = DialogResult.OK;
      this.buttonOk.Location = new Point(12, 433);
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.Size = new Size(75, 23);
      this.buttonOk.TabIndex = 1;
      this.buttonOk.Text = "OK";
      this.buttonOk.UseVisualStyleBackColor = true;
      this.buttonOk.Click += new EventHandler(this.buttonOk_Click);
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      this.buttonCancel.Location = new Point(197, 433);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new Size(75, 23);
      this.buttonCancel.TabIndex = 2;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.trackBarRed.LargeChange = 25;
      this.trackBarRed.Location = new Point(55, 315);
      this.trackBarRed.Maximum = 250;
      this.trackBarRed.Minimum = -250;
      this.trackBarRed.Name = "trackBarRed";
      this.trackBarRed.Size = new Size(217, 45);
      this.trackBarRed.TabIndex = 6;
      this.trackBarRed.TickFrequency = 25;
      this.trackBarRed.MouseUp += new MouseEventHandler(this.trackBar_MouseUp);
      this.label4.AutoSize = true;
      this.label4.Location = new Point(158, 414);
      this.label4.Name = "label4";
      this.label4.Size = new Size(13, 13);
      this.label4.TabIndex = 7;
      this.label4.Text = "0";
      this.trackBarGreen.LargeChange = 25;
      this.trackBarGreen.Location = new Point(55, 347);
      this.trackBarGreen.Maximum = 250;
      this.trackBarGreen.Minimum = -250;
      this.trackBarGreen.Name = "trackBarGreen";
      this.trackBarGreen.Size = new Size(217, 45);
      this.trackBarGreen.TabIndex = 8;
      this.trackBarGreen.TickFrequency = 25;
      this.trackBarGreen.MouseUp += new MouseEventHandler(this.trackBar_MouseUp);
      this.trackBarBlue.LargeChange = 25;
      this.trackBarBlue.Location = new Point(55, 382);
      this.trackBarBlue.Maximum = 250;
      this.trackBarBlue.Minimum = -250;
      this.trackBarBlue.Name = "trackBarBlue";
      this.trackBarBlue.Size = new Size(217, 45);
      this.trackBarBlue.TabIndex = 9;
      this.trackBarBlue.TickFrequency = 25;
      this.trackBarBlue.MouseUp += new MouseEventHandler(this.trackBar_MouseUp);
      this.label5.BackColor = Color.FromArgb(0, 0, 192);
      this.label5.ForeColor = Color.White;
      this.label5.Location = new Point(9, 386);
      this.label5.Name = "label5";
      this.label5.Size = new Size(40, 14);
      this.label5.TabIndex = 12;
      this.label5.Text = "Blue";
      this.label5.TextAlign = ContentAlignment.MiddleCenter;
      this.label6.BackColor = Color.FromArgb(0, 192, 0);
      this.label6.ForeColor = Color.White;
      this.label6.Location = new Point(9, 350);
      this.label6.Name = "label6";
      this.label6.Size = new Size(40, 14);
      this.label6.TabIndex = 11;
      this.label6.Text = "Green";
      this.label6.TextAlign = ContentAlignment.MiddleCenter;
      this.label7.BackColor = Color.Red;
      this.label7.ForeColor = Color.White;
      this.label7.Location = new Point(9, 318);
      this.label7.Name = "label7";
      this.label7.Size = new Size(40, 14);
      this.label7.TabIndex = 10;
      this.label7.Text = "Red";
      this.label7.TextAlign = ContentAlignment.MiddleCenter;
      this.buttonReset.Location = new Point(124, 286);
      this.buttonReset.Name = "buttonReset";
      this.buttonReset.Size = new Size(75, 23);
      this.buttonReset.TabIndex = 13;
      this.buttonReset.Text = "Reset";
      this.buttonReset.UseVisualStyleBackColor = true;
      this.buttonReset.Click += new EventHandler(this.buttonReset_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(280, 479);
      this.Controls.Add((Control) this.buttonReset);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.label7);
      this.Controls.Add((Control) this.trackBarBlue);
      this.Controls.Add((Control) this.trackBarGreen);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.trackBarRed);
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonOk);
      this.Controls.Add((Control) this.pictureBox);
      this.Name = "ModifyHairColor";
      this.Text = "Modify Hair Color";
      ((ISupportInitialize) this.pictureBox).EndInit();
      this.trackBarRed.EndInit();
      this.trackBarGreen.EndInit();
      this.trackBarBlue.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public Bitmap Bitmap
    {
      get
      {
        return this.m_OutputBitmap;
      }
    }

    public ModifyHairColor(Bitmap inputBitmap)
    {
      this.InitializeComponent();
      this.trackBarRed.Value = 0;
      this.trackBarGreen.Value = 0;
      this.trackBarBlue.Value = 0;
      this.m_InputBitmap = inputBitmap;
      this.m_PreviewBitmap = GraphicUtil.SubSampleBitmap(inputBitmap, 2, 2);
      this.m_OutputBitmap = (Bitmap) this.m_PreviewBitmap.Clone();
      this.Colorize(this.m_PreviewBitmap, this.m_OutputBitmap, false);
      this.pictureBox.BackgroundImage = (Image) this.m_OutputBitmap;
      this.pictureBox.Refresh();
    }

    private void Colorize(Bitmap sourceBitmap, Bitmap destBitmap, bool preserveAlfa)
    {
      if (sourceBitmap == null || sourceBitmap.PixelFormat != PixelFormat.Format32bppArgb)
        return;
      Cursor.Current = Cursors.WaitCursor;
      int length = sourceBitmap.Width * sourceBitmap.Height;
      int[] numArray = new int[length];
      Rectangle rect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);
      BitmapData bitmapdata1 = sourceBitmap.LockBits(rect, ImageLockMode.WriteOnly, this.m_InputBitmap.PixelFormat);
      Marshal.Copy(bitmapdata1.Scan0, numArray, 0, length);
      sourceBitmap.UnlockBits(bitmapdata1);
      for (int index = 0; index < length; ++index)
      {
        Color color = Color.FromArgb(numArray[index]);
        int r = (int) color.R;
        int g = (int) color.G;
        int b = (int) color.B;
        int a = (int) color.A;
        int red = r + this.trackBarRed.Value;
        int green = g + this.trackBarGreen.Value;
        int blue = b + this.trackBarBlue.Value;
        if (red > (int) byte.MaxValue)
          red = (int) byte.MaxValue;
        if (green > (int) byte.MaxValue)
          green = (int) byte.MaxValue;
        if (blue > (int) byte.MaxValue)
          blue = (int) byte.MaxValue;
        if (red < 0)
          red = 0;
        if (green < 0)
          green = 0;
        if (blue < 0)
          blue = 0;
        numArray[index] = !preserveAlfa ? Color.FromArgb((int) byte.MaxValue, red, green, blue).ToArgb() : Color.FromArgb(a, red, green, blue).ToArgb();
      }
      rect = new Rectangle(0, 0, destBitmap.Width, this.m_OutputBitmap.Height);
      BitmapData bitmapdata2 = destBitmap.LockBits(rect, ImageLockMode.WriteOnly, this.m_OutputBitmap.PixelFormat);
      IntPtr scan0 = bitmapdata2.Scan0;
      Marshal.Copy(numArray, 0, scan0, length);
      destBitmap.UnlockBits(bitmapdata2);
      Cursor.Current = Cursors.Default;
    }

    private void trackBar_MouseUp(object sender, MouseEventArgs e)
    {
      this.Colorize(this.m_PreviewBitmap, this.m_OutputBitmap, false);
      this.pictureBox.BackgroundImage = (Image) this.m_OutputBitmap;
      this.pictureBox.Refresh();
    }

    private void buttonReset_Click(object sender, EventArgs e)
    {
      this.trackBarRed.Value = 0;
      this.trackBarGreen.Value = 0;
      this.trackBarBlue.Value = 0;
      this.Colorize(this.m_PreviewBitmap, this.m_OutputBitmap, false);
      this.pictureBox.BackgroundImage = (Image) this.m_OutputBitmap;
      this.pictureBox.Refresh();
    }

    private void buttonOk_Click(object sender, EventArgs e)
    {
      this.m_OutputBitmap = (Bitmap) this.m_InputBitmap.Clone();
      this.Colorize(this.m_InputBitmap, this.m_OutputBitmap, true);
    }
  }
}
