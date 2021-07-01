// Original code created by Rinaldo

using System.ComponentModel;
using System.Windows.Forms;

namespace FifaControls
{
  public class ResizablerControl : UserControl
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
      this.components = (IContainer) new Container();
      this.AutoScaleMode = AutoScaleMode.Font;
    }

    public ResizablerControl()
    {
      this.InitializeComponent();
    }
  }
}
