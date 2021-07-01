// Original code created by Rinaldo

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FifaControls
{
  public class ViewQualRule : UserControl
  {
    private IContainer components;
    private ComboBox comboRule;
    private ComboBox comboTrophy;
    private ComboBox comboLeague1;
    private ComboBox comboTropht2;
    private ComboBox comboTeam;
    private NumericUpDown numeric;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.comboRule = new ComboBox();
      this.comboTrophy = new ComboBox();
      this.comboLeague1 = new ComboBox();
      this.comboTropht2 = new ComboBox();
      this.comboTeam = new ComboBox();
      this.numeric = new NumericUpDown();
      this.numeric.BeginInit();
      this.SuspendLayout();
      this.comboRule.FormattingEnabled = true;
      this.comboRule.Items.AddRange(new object[7]
      {
        (object) "Fill From League",
        (object) "Fill From League with Country Limit",
        (object) "Fill From Competition ",
        (object) "Fill From Competition with Backup Rule",
        (object) "Fill From Competition with  Backup League",
        (object) "Fill with  Specific Team",
        (object) "Fill with  Special Team"
      });
      this.comboRule.Location = new Point(5, 2);
      this.comboRule.Name = "comboRule";
      this.comboRule.Size = new Size(161, 21);
      this.comboRule.TabIndex = 0;
      this.comboTrophy.FormattingEnabled = true;
      this.comboTrophy.Location = new Point(172, 1);
      this.comboTrophy.Name = "comboTrophy";
      this.comboTrophy.Size = new Size(121, 21);
      this.comboTrophy.TabIndex = 1;
      this.comboLeague1.FormattingEnabled = true;
      this.comboLeague1.Location = new Point(299, 1);
      this.comboLeague1.Name = "comboLeague1";
      this.comboLeague1.Size = new Size(121, 21);
      this.comboLeague1.TabIndex = 2;
      this.comboTropht2.FormattingEnabled = true;
      this.comboTropht2.Location = new Point(426, 1);
      this.comboTropht2.Name = "comboTropht2";
      this.comboTropht2.Size = new Size(121, 21);
      this.comboTropht2.TabIndex = 3;
      this.comboTeam.FormattingEnabled = true;
      this.comboTeam.Location = new Point(553, 1);
      this.comboTeam.Name = "comboTeam";
      this.comboTeam.Size = new Size(121, 21);
      this.comboTeam.TabIndex = 4;
      this.numeric.Location = new Point(680, 1);
      this.numeric.Name = "numeric";
      this.numeric.Size = new Size(75, 20);
      this.numeric.TabIndex = 5;
      this.numeric.TextAlign = HorizontalAlignment.Center;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.numeric);
      this.Controls.Add((Control) this.comboTeam);
      this.Controls.Add((Control) this.comboTropht2);
      this.Controls.Add((Control) this.comboLeague1);
      this.Controls.Add((Control) this.comboTrophy);
      this.Controls.Add((Control) this.comboRule);
      this.Name = "ViewQualRule";
      this.Size = new Size(784, 23);
      this.numeric.EndInit();
      this.ResumeLayout(false);
    }

    public ViewQualRule()
    {
      this.InitializeComponent();
    }
  }
}
