// Original code created by Rinaldo

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FifaControls
{
  public class WeatherSelector : UserControl
  {
    private int month = -1;
    public WeatherSelector.WeatherEventHandler ValueChanged;
    private IContainer components;
    private Label labelPicture;
    private ImageList imageListWeather;
    public Label labelText;

    [Description("Header")]
    [Category("User")]
    public string Header
    {
      get
      {
        return this.labelText.Text;
      }
      set
      {
        this.labelText.Text = value;
        if (this.labelText.Text == "Jan")
          this.month = 0;
        else if (this.labelText.Text == "Feb")
          this.month = 1;
        else if (this.labelText.Text == "Mar")
          this.month = 2;
        else if (this.labelText.Text == "Apr")
          this.month = 3;
        else if (this.labelText.Text == "May")
          this.month = 4;
        else if (this.labelText.Text == "Jun")
          this.month = 5;
        else if (this.labelText.Text == "Jul")
          this.month = 6;
        else if (this.labelText.Text == "Aug")
          this.month = 7;
        else if (this.labelText.Text == "Sep")
          this.month = 8;
        else if (this.labelText.Text == "Oct")
          this.month = 9;
        else if (this.labelText.Text == "Nov")
        {
          this.month = 10;
        }
        else
        {
          if (!(this.labelText.Text == "Dec"))
            return;
          this.month = 11;
        }
      }
    }

    public WeatherSelector()
    {
      this.InitializeComponent();
    }

    private void label1_Click(object sender, EventArgs e)
    {
      if (((MouseEventArgs) e).Button == MouseButtons.Left)
      {
        if (this.labelPicture.ImageIndex < 4)
          ++this.labelPicture.ImageIndex;
        else
          this.labelPicture.ImageIndex = 0;
      }
      else if (this.labelPicture.ImageIndex > 0)
        --this.labelPicture.ImageIndex;
      else
        this.labelPicture.ImageIndex = 4;
      if (this.ValueChanged == null)
        return;
      this.ValueChanged((object) this, this.Value, this.month);
    }

    public int Value
    {
      get
      {
        return this.labelPicture.ImageIndex;
      }
      set
      {
        if (value < 0)
          this.labelPicture.ImageIndex = 0;
        else if (value > 4)
          this.labelPicture.ImageIndex = 4;
        else
          this.labelPicture.ImageIndex = value;
      }
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
      ComponentResourceManager resources = new ComponentResourceManager(typeof (WeatherSelector));
      this.labelPicture = new Label();
      this.imageListWeather = new ImageList(this.components);
      this.labelText = new Label();
      this.SuspendLayout();
      this.labelPicture.BorderStyle = BorderStyle.Fixed3D;
      this.labelPicture.Dock = DockStyle.Bottom;
      this.labelPicture.ImageIndex = 0;
      this.labelPicture.ImageList = this.imageListWeather;
      this.labelPicture.Location = new Point(0, 15);
      this.labelPicture.Name = "labelPicture";
      this.labelPicture.Size = new Size(40, 30);
      this.labelPicture.TabIndex = 2;
      this.labelPicture.Click += new EventHandler(this.label1_Click);
      this.imageListWeather.ImageStream = (ImageListStreamer) resources.GetObject("imageListWeather.ImageStream");
      this.imageListWeather.TransparentColor = Color.Transparent;
      this.imageListWeather.Images.SetKeyName(0, "Weather_0.PNG");
      this.imageListWeather.Images.SetKeyName(1, "Weather_1.PNG");
      this.imageListWeather.Images.SetKeyName(2, "Weather_2.PNG");
      this.imageListWeather.Images.SetKeyName(3, "Weather_3.PNG");
      this.imageListWeather.Images.SetKeyName(4, "Weather_4.PNG");
      this.labelText.BorderStyle = BorderStyle.FixedSingle;
      this.labelText.Dock = DockStyle.Top;
      this.labelText.Location = new Point(0, 0);
      this.labelText.Name = "labelText";
      this.labelText.Size = new Size(40, 15);
      this.labelText.TabIndex = 3;
      this.labelText.Text = "TEX";
      this.labelText.TextAlign = ContentAlignment.MiddleCenter;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Transparent;
      this.Controls.Add((Control) this.labelPicture);
      this.Controls.Add((Control) this.labelText);
      this.Name = "WeatherSelector";
      this.Size = new Size(40, 45);
      this.ResumeLayout(false);
    }

    public delegate void WeatherEventHandler(object sender, int value, int month);
  }
}
