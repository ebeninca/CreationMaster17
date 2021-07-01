// Original code created by Rinaldo

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace FifaControls
{
  public class AboutForm : Form
  {
    private IContainer components;
    public PictureBox pictureBox;
    public Label labelProduct;
    public Label labelRelease;
    private LinkLabel linkFifaMaster;
    private Button buttonCountinue;
    public Label label2;
    public Label label1;
    private LinkLabel linkLabel1;
    private LinkLabel linkLabel2;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager resources = new ComponentResourceManager(typeof (AboutForm));
      this.pictureBox = new PictureBox();
      this.labelProduct = new Label();
      this.labelRelease = new Label();
      this.linkFifaMaster = new LinkLabel();
      this.buttonCountinue = new Button();
      this.label2 = new Label();
      this.label1 = new Label();
      this.linkLabel1 = new LinkLabel();
      this.linkLabel2 = new LinkLabel();
      ((ISupportInitialize) this.pictureBox).BeginInit();
      this.SuspendLayout();
      this.pictureBox.BackgroundImage = (Image) resources.GetObject("pictureBox.BackgroundImage");
      this.pictureBox.BackgroundImageLayout = ImageLayout.Center;
      this.pictureBox.Dock = DockStyle.Top;
      this.pictureBox.Location = new Point(0, 0);
      this.pictureBox.Name = "pictureBox";
      this.pictureBox.Size = new Size(502, 97);
      this.pictureBox.TabIndex = 0;
      this.pictureBox.TabStop = false;
      this.labelProduct.AutoSize = true;
      this.labelProduct.BackColor = Color.Transparent;
      this.labelProduct.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelProduct.Location = new Point(11, 118);
      this.labelProduct.Name = "labelProduct";
      this.labelProduct.Size = new Size(110, 20);
      this.labelProduct.TabIndex = 1;
      this.labelProduct.Text = "Product Name";
      this.labelRelease.AutoSize = true;
      this.labelRelease.BackColor = Color.Transparent;
      this.labelRelease.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelRelease.Location = new Point(12, 148);
      this.labelRelease.Name = "labelRelease";
      this.labelRelease.Size = new Size(68, 20);
      this.labelRelease.TabIndex = 2;
      this.labelRelease.Text = "Release";
      this.linkFifaMaster.AutoSize = true;
      this.linkFifaMaster.BackColor = Color.Transparent;
      this.linkFifaMaster.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.linkFifaMaster.Location = new Point(164, 370);
      this.linkFifaMaster.Name = "linkFifaMaster";
      this.linkFifaMaster.Size = new Size(177, 20);
      this.linkFifaMaster.TabIndex = 3;
      this.linkFifaMaster.TabStop = true;
      this.linkFifaMaster.Text = "Fifa Master Home Page";
      this.linkFifaMaster.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkFifaMaster_LinkClicked);
      this.buttonCountinue.DialogResult = DialogResult.OK;
      this.buttonCountinue.Location = new Point(211, 403);
      this.buttonCountinue.Name = "buttonCountinue";
      this.buttonCountinue.Size = new Size(75, 23);
      this.buttonCountinue.TabIndex = 4;
      this.buttonCountinue.Text = "Continue";
      this.buttonCountinue.UseVisualStyleBackColor = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.Teal;
      this.label2.Location = new Point(13, 180);
      this.label2.Name = "label2";
      this.label2.Size = new Size(478, 84);
      this.label2.TabIndex = 6;
      this.label2.Text = resources.GetString("label2.Text");
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.Teal;
      this.label1.Location = new Point(13, 296);
      this.label1.Name = "label1";
      this.label1.Size = new Size(478, 74);
      this.label1.TabIndex = 7;
      this.label1.Text = resources.GetString("label1.Text");
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.BackColor = Color.Transparent;
      this.linkLabel1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.linkLabel1.Location = new Point(87, 264);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(48, 20);
      this.linkLabel1.TabIndex = 8;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "ABIO";
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      this.linkLabel2.AutoSize = true;
      this.linkLabel2.BackColor = Color.Transparent;
      this.linkLabel2.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.linkLabel2.Location = new Point(327, 264);
      this.linkLabel2.Name = "linkLabel2";
      this.linkLabel2.Size = new Size(69, 20);
      this.linkLabel2.TabIndex = 9;
      this.linkLabel2.TabStop = true;
      this.linkLabel2.Text = "UNICEF";
      this.linkLabel2.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImage = (Image) resources.GetObject("$this.BackgroundImage");
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(502, 438);
      this.Controls.Add((Control) this.linkLabel2);
      this.Controls.Add((Control) this.linkLabel1);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.buttonCountinue);
      this.Controls.Add((Control) this.linkFifaMaster);
      this.Controls.Add((Control) this.labelRelease);
      this.Controls.Add((Control) this.labelProduct);
      this.Controls.Add((Control) this.pictureBox);
      this.Controls.Add((Control) this.label1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) resources.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AboutForm";
      this.Text = " About Info";
      ((ISupportInitialize) this.pictureBox).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public AboutForm()
    {
      this.InitializeComponent();
    }

    private void linkFifaMaster_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      try
      {
        this.VisitLink();
      }
      catch (Exception ex)
      {
      }
    }

    private void VisitLink()
    {
      Process.Start("http://www.fifa-master.com");
    }

    private void VisitAbio()
    {
      Process.Start("http://www.abio.org");
    }

    private void VisitUnicef()
    {
      Process.Start("http://www.unicef.org");
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      try
      {
        this.VisitAbio();
      }
      catch (Exception ex)
      {
      }
    }

    private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      try
      {
        this.VisitUnicef();
      }
      catch (Exception ex)
      {
      }
    }
  }
}
