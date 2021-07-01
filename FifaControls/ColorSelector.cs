// Original code created by Rinaldo

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FifaControls
{
  public class ColorSelector : Form
  {
    private Button buttonOK;
    private Button buttonCancel;
    private PictureBox pictureSelectedColor;
    private IContainer components;
    private Color m_SelectedColor;
    private Color[] m_Palette;
    private int m_SelectedIndex;
    private PictureBox pictureBoxHidden;
    private RadioButton[] m_RadioButtons;

    public Color SelectedColor
    {
      get
      {
        return this.m_SelectedColor;
      }
    }

    public int SelectedIndex
    {
      get
      {
        return this.m_SelectedIndex;
      }
    }

    public ColorSelector(Color[] palette, int selectedIndex)
    {
      this.InitializeComponent();
      this.m_Palette = palette;
      if (selectedIndex < 0 || selectedIndex >= palette.Length)
        selectedIndex = 0;
      this.m_SelectedColor = this.m_Palette[selectedIndex];
      this.pictureSelectedColor.BackColor = this.m_SelectedColor;
      this.Height = 20 * ((palette.Length - 1) / 8) + 92;
      this.buttonOK.Location = new Point(16, this.Height - 56);
      this.buttonCancel.Location = new Point(104, this.Height - 56);
      int x = 32;
      int y = 8;
      this.m_RadioButtons = new RadioButton[palette.Length];
      for (int index = 0; index < palette.Length; ++index)
      {
        this.m_RadioButtons[index] = new RadioButton();
        this.m_RadioButtons[index].Location = new Point(x, y);
        x += 20;
        if ((index + 1) % 8 == 0)
        {
          x = 32;
          y += 20;
        }
        this.m_RadioButtons[index].BackColor = palette[index];
        if (palette[index] == Color.Transparent)
          this.m_RadioButtons[index].BackgroundImage = this.pictureBoxHidden.BackgroundImage;
        if (index == selectedIndex)
          this.m_RadioButtons[index].Checked = true;
        this.m_RadioButtons[index].Appearance = Appearance.Button;
        this.m_RadioButtons[index].Text = string.Empty;
        this.m_RadioButtons[index].Width = this.m_RadioButtons[index].Height = 18;
        this.m_RadioButtons[index].Visible = true;
        this.m_RadioButtons[index].CheckedChanged += new EventHandler(this.radio_CheckedChanged);
        this.Controls.Add((Control) this.m_RadioButtons[index]);
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
      ComponentResourceManager resources = new ComponentResourceManager(typeof (ColorSelector));
      this.buttonOK = new Button();
      this.buttonCancel = new Button();
      this.pictureSelectedColor = new PictureBox();
      this.pictureBoxHidden = new PictureBox();
      ((ISupportInitialize) this.pictureSelectedColor).BeginInit();
      ((ISupportInitialize) this.pictureBoxHidden).BeginInit();
      this.SuspendLayout();
      this.buttonOK.DialogResult = DialogResult.OK;
      resources.ApplyResources((object) this.buttonOK, "buttonOK");
      this.buttonOK.Name = "buttonOK";
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      this.buttonCancel.ForeColor = SystemColors.ControlText;
      resources.ApplyResources((object) this.buttonCancel, "buttonCancel");
      this.buttonCancel.Name = "buttonCancel";
      this.pictureSelectedColor.BorderStyle = BorderStyle.FixedSingle;
      resources.ApplyResources((object) this.pictureSelectedColor, "pictureSelectedColor");
      this.pictureSelectedColor.Name = "pictureSelectedColor";
      this.pictureSelectedColor.TabStop = false;
      resources.ApplyResources((object) this.pictureBoxHidden, "pictureBoxHidden");
      this.pictureBoxHidden.BorderStyle = BorderStyle.FixedSingle;
      this.pictureBoxHidden.Name = "pictureBoxHidden";
      this.pictureBoxHidden.TabStop = false;
      this.AcceptButton = (IButtonControl) this.buttonOK;
      resources.ApplyResources((object) this, "$this");
      this.CancelButton = (IButtonControl) this.buttonCancel;
      this.Controls.Add((Control) this.pictureBoxHidden);
      this.Controls.Add((Control) this.pictureSelectedColor);
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonOK);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = "ColorSelector";
      ((ISupportInitialize) this.pictureSelectedColor).EndInit();
      ((ISupportInitialize) this.pictureBoxHidden).EndInit();
      this.ResumeLayout(false);
    }

    private void radio_CheckedChanged(object sender, EventArgs e)
    {
      RadioButton radioButton = (RadioButton) sender;
      if (!radioButton.Checked)
        return;
      this.pictureSelectedColor.BackColor = radioButton.BackColor;
      this.m_SelectedColor = radioButton.BackColor;
      if (this.m_SelectedColor == Color.Transparent)
        this.pictureSelectedColor.BackgroundImage = this.pictureBoxHidden.BackgroundImage;
      else
        this.pictureSelectedColor.BackgroundImage = (Image) null;
      for (int index = 0; index < this.m_Palette.Length; ++index)
      {
        if (this.pictureSelectedColor.BackColor == this.m_RadioButtons[index].BackColor)
        {
          this.m_SelectedIndex = index;
          break;
        }
      }
    }
  }
}
