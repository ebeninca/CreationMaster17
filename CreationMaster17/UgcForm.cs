// Original code created by Rinaldo

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CreationMaster
{
  public class UgcForm : Form
  {
    private IContainer components;
    private Button buttonImport;
    private Button buttonCancel;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.buttonImport = new Button();
      this.buttonCancel = new Button();
      this.SuspendLayout();
      this.buttonImport.DialogResult = DialogResult.OK;
      this.buttonImport.Location = new Point(133, 334);
      this.buttonImport.Name = "buttonImport";
      this.buttonImport.Size = new Size(75, 23);
      this.buttonImport.TabIndex = 0;
      this.buttonImport.Text = "Import";
      this.buttonImport.UseVisualStyleBackColor = true;
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      this.buttonCancel.Location = new Point(561, 333);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new Size(75, 23);
      this.buttonCancel.TabIndex = 1;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(764, 389);
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonImport);
      this.Name = "UgcForm";
      this.Text = "UgcForm";
      this.ResumeLayout(false);
    }

    public UgcForm()
    {
      this.InitializeComponent();
    }
  }
}
