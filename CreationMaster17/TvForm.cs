// Original code created by Rinaldo

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CreationMaster
{
  public class TvForm : Form
  {
    private IContainer components;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager resources = new ComponentResourceManager(typeof (TvForm));
      this.SuspendLayout();
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImage = (Image) resources.GetObject("$this.BackgroundImage");
      this.BackgroundImageLayout = ImageLayout.Center;
      this.ClientSize = new Size(1165, 798);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = "TvForm";
      this.Text = "TvForm";
      this.ResumeLayout(false);
    }

    public TvForm()
    {
      this.InitializeComponent();
    }

    public void Clean()
    {
      this.Visible = false;
    }
  }
}
