// Original code created by Rinaldo

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FifaControls
{
  public class NumericStars : UserControl
  {
    public NumericStars.StarsEventHandler ValueChanged;
    private IContainer components;
    private Label label;
    private ImageList imageList;
    public NumericUpDown numericUpDown;

    [Description("Value")]
    [Category("User")]
    public int Value
    {
      get
      {
        return (int) this.numericUpDown.Value;
      }
      set
      {
        this.numericUpDown.Value = (Decimal) value;
      }
    }

    public NumericStars()
    {
      this.InitializeComponent();
    }

    private void numericUpDown_ValueChanged(object sender, EventArgs e)
    {
      int num = (int) this.numericUpDown.Value;
      this.label.ImageIndex = num >= 2 ? (num - 2) / 2 : 0;
      if (this.ValueChanged == null)
        return;
      this.ValueChanged((object) this, num);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager resources = new ComponentResourceManager(typeof (NumericStars));
      this.numericUpDown = new NumericUpDown();
      this.label = new Label();
      this.imageList = new ImageList(this.components);
      this.numericUpDown.BeginInit();
      this.SuspendLayout();
      this.numericUpDown.Location = new Point(0, 0);
      this.numericUpDown.Maximum = new Decimal(new int[4]
      {
        20,
        0,
        0,
        0
      });
      this.numericUpDown.Name = "numericUpDown";
      this.numericUpDown.Size = new Size(66, 20);
      this.numericUpDown.TabIndex = 0;
      this.numericUpDown.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown.ValueChanged += new EventHandler(this.numericUpDown_ValueChanged);
      this.label.ImageIndex = 0;
      this.label.ImageList = this.imageList;
      this.label.Location = new Point(70, 2);
      this.label.Name = "label";
      this.label.Size = new Size(93, 17);
      this.label.TabIndex = 1;
      this.imageList.ImageStream = (ImageListStreamer) resources.GetObject("imageList.ImageStream");
      this.imageList.TransparentColor = Color.Fuchsia;
      this.imageList.Images.SetKeyName(0, "Stars_0_5.PNG");
      this.imageList.Images.SetKeyName(1, "Stars_1.PNG");
      this.imageList.Images.SetKeyName(2, "Stars_1_5.PNG");
      this.imageList.Images.SetKeyName(3, "Stars_2.PNG");
      this.imageList.Images.SetKeyName(4, "Stars_2_5.PNG");
      this.imageList.Images.SetKeyName(5, "Stars_3.PNG");
      this.imageList.Images.SetKeyName(6, "Stars_3_5.PNG");
      this.imageList.Images.SetKeyName(7, "Stars_4.PNG");
      this.imageList.Images.SetKeyName(8, "Stars_4_5.PNG");
      this.imageList.Images.SetKeyName(9, "Stars_5.PNG");
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Transparent;
      this.Controls.Add((Control) this.label);
      this.Controls.Add((Control) this.numericUpDown);
      this.Name = "NumericStars";
      this.Size = new Size(167, 20);
      this.numericUpDown.EndInit();
      this.ResumeLayout(false);
    }

    public delegate void StarsEventHandler(object sender, int value);
  }
}
