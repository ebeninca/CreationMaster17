// Original code created by Rinaldo

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FifaControls
{
  public class RgbControl : Form
  {
    private Bitmap m_InputBitmap;
    private Bitmap m_OutputBitmap;
    private Control m_Caller;
    private int m_MouseStatus;
    private IContainer components;
    private TrackBar trackBarRed;
    private Label label1;
    private Label label2;
    private TrackBar trackBarGreen;
    private Label label3;
    private TrackBar trackBarBlue;
    private Button buttonOk;
    private Button buttonCancel;
    private Button buttonReset;

    public RgbControl(Bitmap inputBitmap, Control caller)
    {
      if (inputBitmap == null)
        return;
      this.m_OutputBitmap = inputBitmap;
      this.m_InputBitmap = (Bitmap) inputBitmap.Clone();
      this.m_Caller = caller;
      this.InitializeComponent();
    }

    private void Colorize()
    {
      if (this.m_InputBitmap == null || this.m_InputBitmap.PixelFormat != PixelFormat.Format32bppArgb)
        return;
      Cursor.Current = Cursors.WaitCursor;
      int length = this.m_InputBitmap.Width * this.m_InputBitmap.Height;
      int[] numArray = new int[length];
      Rectangle rect = new Rectangle(0, 0, this.m_InputBitmap.Width, this.m_InputBitmap.Height);
      BitmapData bitmapdata1 = this.m_InputBitmap.LockBits(rect, ImageLockMode.WriteOnly, this.m_InputBitmap.PixelFormat);
      Marshal.Copy(bitmapdata1.Scan0, numArray, 0, length);
      this.m_InputBitmap.UnlockBits(bitmapdata1);
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
        numArray[index] = Color.FromArgb(a, red, green, blue).ToArgb();
      }
      rect = new Rectangle(0, 0, this.m_OutputBitmap.Width, this.m_OutputBitmap.Height);
      BitmapData bitmapdata2 = this.m_OutputBitmap.LockBits(rect, ImageLockMode.WriteOnly, this.m_OutputBitmap.PixelFormat);
      IntPtr scan0 = bitmapdata2.Scan0;
      Marshal.Copy(numArray, 0, scan0, length);
      this.m_OutputBitmap.UnlockBits(bitmapdata2);
      Cursor.Current = Cursors.Default;
      this.FindForm().Refresh();
      this.m_Caller.Refresh();
    }

    private void buttonOk_Click(object sender, EventArgs e)
    {
      this.m_InputBitmap = this.m_OutputBitmap;
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      this.m_OutputBitmap = this.m_InputBitmap;
    }

    private void trackBarRed_Scroll(object sender, EventArgs e)
    {
    }

    private void trackBarRed_MouseDown(object sender, MouseEventArgs e)
    {
      this.m_MouseStatus = -1;
    }

    private void trackBarRed_MouseUp(object sender, MouseEventArgs e)
    {
      this.m_MouseStatus = 0;
      this.Colorize();
    }

    private void buttonReset_Click(object sender, EventArgs e)
    {
      this.trackBarRed.Value = 0;
      this.trackBarGreen.Value = 0;
      this.trackBarBlue.Value = 0;
      this.Colorize();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.trackBarRed = new TrackBar();
      this.label1 = new Label();
      this.label2 = new Label();
      this.trackBarGreen = new TrackBar();
      this.label3 = new Label();
      this.trackBarBlue = new TrackBar();
      this.buttonOk = new Button();
      this.buttonCancel = new Button();
      this.buttonReset = new Button();
      this.trackBarRed.BeginInit();
      this.trackBarGreen.BeginInit();
      this.trackBarBlue.BeginInit();
      this.SuspendLayout();
      this.trackBarRed.BackColor = SystemColors.Control;
      this.trackBarRed.LargeChange = 16;
      this.trackBarRed.Location = new Point(36, 12);
      this.trackBarRed.Maximum = 64;
      this.trackBarRed.Minimum = -64;
      this.trackBarRed.Name = "trackBarRed";
      this.trackBarRed.Size = new Size(268, 45);
      this.trackBarRed.TabIndex = 0;
      this.trackBarRed.TickFrequency = 8;
      this.trackBarRed.Scroll += new EventHandler(this.trackBarRed_Scroll);
      this.trackBarRed.MouseDown += new MouseEventHandler(this.trackBarRed_MouseDown);
      this.trackBarRed.MouseUp += new MouseEventHandler(this.trackBarRed_MouseUp);
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Red;
      this.label1.ForeColor = Color.White;
      this.label1.Location = new Point(3, 21);
      this.label1.Name = "label1";
      this.label1.Size = new Size(27, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Red";
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.FromArgb(0, 192, 0);
      this.label2.ForeColor = Color.White;
      this.label2.Location = new Point(3, 57);
      this.label2.Name = "label2";
      this.label2.Size = new Size(36, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Green";
      this.trackBarGreen.BackColor = SystemColors.Control;
      this.trackBarGreen.LargeChange = 16;
      this.trackBarGreen.Location = new Point(36, 48);
      this.trackBarGreen.Maximum = 64;
      this.trackBarGreen.Minimum = -64;
      this.trackBarGreen.Name = "trackBarGreen";
      this.trackBarGreen.Size = new Size(268, 45);
      this.trackBarGreen.TabIndex = 2;
      this.trackBarGreen.TickFrequency = 8;
      this.trackBarGreen.Scroll += new EventHandler(this.trackBarRed_Scroll);
      this.trackBarGreen.MouseDown += new MouseEventHandler(this.trackBarRed_MouseDown);
      this.trackBarGreen.MouseUp += new MouseEventHandler(this.trackBarRed_MouseUp);
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.FromArgb(0, 0, 192);
      this.label3.ForeColor = Color.White;
      this.label3.Location = new Point(3, 95);
      this.label3.Name = "label3";
      this.label3.Size = new Size(28, 13);
      this.label3.TabIndex = 5;
      this.label3.Text = "Blue";
      this.trackBarBlue.BackColor = SystemColors.Control;
      this.trackBarBlue.LargeChange = 16;
      this.trackBarBlue.Location = new Point(36, 86);
      this.trackBarBlue.Maximum = 64;
      this.trackBarBlue.Minimum = -64;
      this.trackBarBlue.Name = "trackBarBlue";
      this.trackBarBlue.Size = new Size(268, 45);
      this.trackBarBlue.TabIndex = 4;
      this.trackBarBlue.TickFrequency = 8;
      this.trackBarBlue.Scroll += new EventHandler(this.trackBarRed_Scroll);
      this.trackBarBlue.MouseDown += new MouseEventHandler(this.trackBarRed_MouseDown);
      this.trackBarBlue.MouseUp += new MouseEventHandler(this.trackBarRed_MouseUp);
      this.buttonOk.DialogResult = DialogResult.OK;
      this.buttonOk.Location = new Point(58, 159);
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.Size = new Size(75, 23);
      this.buttonOk.TabIndex = 6;
      this.buttonOk.Text = "OK";
      this.buttonOk.UseVisualStyleBackColor = true;
      this.buttonOk.Click += new EventHandler(this.buttonOk_Click);
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      this.buttonCancel.Location = new Point(203, 159);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new Size(75, 23);
      this.buttonCancel.TabIndex = 7;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
      this.buttonReset.Location = new Point(131, 130);
      this.buttonReset.Name = "buttonReset";
      this.buttonReset.Size = new Size(75, 23);
      this.buttonReset.TabIndex = 8;
      this.buttonReset.Text = "Reset";
      this.buttonReset.UseVisualStyleBackColor = true;
      this.buttonReset.Click += new EventHandler(this.buttonReset_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(310, 194);
      this.Controls.Add((Control) this.buttonReset);
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonOk);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.trackBarBlue);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.trackBarGreen);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.trackBarRed);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = "RgbControl";
      this.Text = nameof (RgbControl);
      this.trackBarRed.EndInit();
      this.trackBarGreen.EndInit();
      this.trackBarBlue.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
