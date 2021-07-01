// Original code created by Rinaldo

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FifaControls
{
  public class LabeledTrack : UserControl
  {
    private string m_LabelText = string.Empty;
    public LabeledTrack.ValueChangedHandler ValueChanged;
    private IContainer components;
    private Label label;
    private TrackBar track;

    [Description("Label")]
    [Category("User")]
    public string LabelText
    {
      get
      {
        return this.m_LabelText;
      }
      set
      {
        this.m_LabelText = value;
        if (value.Contains(" "))
          value.Replace(' ', '-');
        this.label.Text = this.m_LabelText + " " + this.track.Value.ToString();
      }
    }

    [Description("Value")]
    [Category("User")]
    public int Value
    {
      get
      {
        return this.track.Value;
      }
      set
      {
        this.track.Value = value;
      }
    }

    public LabeledTrack()
    {
      this.InitializeComponent();
    }

    private void track_ValueChanged(object sender, EventArgs e)
    {
      this.label.Text = this.m_LabelText + " " + this.track.Value.ToString();
      if (this.ValueChanged == null)
        return;
      this.ValueChanged(sender, this.track.Value);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager resources = new ComponentResourceManager(typeof (LabeledTrack));
      this.label = new Label();
      this.track = new TrackBar();
      this.track.BeginInit();
      this.SuspendLayout();
      this.label.BackColor = SystemColors.Control;
      this.label.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
      this.label.ForeColor = Color.Yellow;
      this.label.Image = (Image) resources.GetObject("label.Image");
      this.label.ImeMode = ImeMode.NoControl;
      this.label.Location = new Point(1, -1);
      this.label.Name = "label";
      this.label.Size = new Size(100, 16);
      this.label.TabIndex = 90;
      this.label.Text = "Name";
      this.label.TextAlign = ContentAlignment.MiddleCenter;
      this.track.BackColor = SystemColors.Control;
      this.track.Cursor = Cursors.Default;
      this.track.ImeMode = ImeMode.NoControl;
      this.track.LargeChange = 10;
      this.track.Location = new Point(-7, 6);
      this.track.Maximum = 99;
      this.track.Minimum = 1;
      this.track.Name = "track";
      this.track.Size = new Size(116, 45);
      this.track.TabIndex = 89;
      this.track.TickFrequency = 10;
      this.track.Value = 99;
      this.track.ValueChanged += new EventHandler(this.track_ValueChanged);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.label);
      this.Controls.Add((Control) this.track);
      this.Name = "LabeledTrack";
      this.Size = new Size(104, 45);
      this.track.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public delegate void ValueChangedHandler(object sender, int value);
  }
}
