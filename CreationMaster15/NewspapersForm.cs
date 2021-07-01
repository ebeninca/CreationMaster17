// Original code created by Rinaldo

using FifaControls;
using FifaLibrary;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CreationMaster
{
  public class NewspapersForm : Form
  {
    private int m_CurrentNewspaperId;
    private int m_CurrentCmSponsorId;
    private IContainer components;
    private PickUpControl pickUpControl;
    private Viewer2D viewer2DNewspaper;
    private NumericUpDown numericNewspaper1;
    private Label labelNewpaper;
    private GroupBox groupNewspaper;
    private GroupBox groupCmSponsor;
    private Viewer2D viewer2DCmSponsor;
    private NumericUpDown numericCmSponsor;
    private Viewer2D viewer2DCmSponsorSmall;
    private GroupBox groupSpecificTeamNews;
    private ComboBox comboTeamAvailable;
    private Viewer2D viewer2DTeamNews;
    private NumericUpDown numericTeamNewsCounter;
    private ComboBox comboTeamNewsType;
    private ToolTip toolTip1;

    public NewspapersForm()
    {
      this.Visible = false;
      this.InitializeComponent();
      this.pickUpControl.RefreshObject = new PickUpControl.PickUpCallback(this.RefreshNewspapers);
      this.viewer2DNewspaper.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageNewspapers);
      this.viewer2DNewspaper.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteImageNewspapers);
      this.viewer2DNewspaper.ButtonStripVisible = true;
      this.viewer2DNewspaper.RemoveButton = true;
      this.viewer2DCmSponsor.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageCmSponsor);
      this.viewer2DCmSponsor.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteImageCmSponsor);
      this.viewer2DCmSponsor.ButtonStripVisible = true;
      this.viewer2DCmSponsor.RemoveButton = true;
      this.viewer2DCmSponsorSmall.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageCmSponsorSmall);
      this.viewer2DCmSponsorSmall.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteImageCmSponsorSmall);
      this.viewer2DCmSponsorSmall.ButtonStripVisible = true;
      this.viewer2DCmSponsorSmall.RemoveButton = true;
      this.viewer2DTeamNews.ImageImport = new Viewer2D.ImageImportHandler(this.ImportImageTeamNews);
      this.viewer2DTeamNews.ImageDelete = new Viewer2D.ImageDeleteHandler(this.DeleteImageTeamNews);
      this.viewer2DTeamNews.ButtonStripVisible = true;
      this.viewer2DTeamNews.RemoveButton = true;
      this.comboTeamNewsType.SelectedIndex = 0;
      this.Preset();
    }

    public void Clean()
    {
      this.Visible = false;
    }

    public void Preset()
    {
      if (!this.Visible)
        return;
      if (FifaEnvironment.Year == 14)
      {
        this.viewer2DCmSponsor.ImageSize = new Size(256, 64);
        this.numericCmSponsor.Maximum = new Decimal(19);
        this.viewer2DCmSponsorSmall.Visible = true;
        this.viewer2DTeamNews.ImageSize = new Size(512, 512);
      }
      else
      {
        this.viewer2DCmSponsorSmall.Visible = false;
        this.viewer2DTeamNews.ImageSize = new Size(668, 580);
      }
      if (this.comboTeamAvailable.Items.Count == FifaEnvironment.Teams.Count)
        return;
      this.comboTeamAvailable.Items.Clear();
      this.comboTeamAvailable.Items.AddRange(FifaEnvironment.Teams.ToArray());
    }

    public IdObject RefreshNewspapers(object sender, object obj)
    {
      this.Preset();
      this.LoadNews();
      return (IdObject) null;
    }

    private void LoadTeamNews()
    {
      Team selectedItem = (Team) this.comboTeamAvailable.SelectedItem;
      if (selectedItem == null)
      {
        this.viewer2DTeamNews.CurrentBitmap = (Bitmap) null;
      }
      else
      {
        int id = selectedItem.Id;
        int selectedIndex = this.comboTeamNewsType.SelectedIndex;
        if (selectedIndex < 0)
        {
          this.viewer2DTeamNews.CurrentBitmap = (Bitmap) null;
        }
        else
        {
          int order = (int) this.numericTeamNewsCounter.Value;
          this.viewer2DTeamNews.CurrentBitmap = TeamNews.GetTeamNews(id, selectedIndex, order);
        }
      }
    }

    private void LoadNews()
    {
      this.numericNewspaper1.Value = (Decimal) this.m_CurrentNewspaperId;
      this.viewer2DNewspaper.CurrentBitmap = Newspaper.GetNewspaper(this.m_CurrentNewspaperId);
      this.numericCmSponsor.Value = (Decimal) this.m_CurrentCmSponsorId;
      this.viewer2DCmSponsor.CurrentBitmap = CmSponsor.GetCmSponsor(this.m_CurrentCmSponsorId);
      if (FifaEnvironment.Year == 14)
        this.viewer2DCmSponsorSmall.CurrentBitmap = CmSponsor.GetCmSponsorSmall(this.m_CurrentCmSponsorId);
      this.LoadTeamNews();
    }

    private bool ImportImageNewspapers(object sender, Bitmap bitmap)
    {
      return Newspaper.SetNewspaper(this.m_CurrentNewspaperId, bitmap);
    }

    private bool DeleteImageNewspapers(object sender)
    {
      return FifaEnvironment.DeleteFromZdata(Newspaper.NewspaperBigFileName(this.m_CurrentNewspaperId));
    }

    private bool ImportImageCmSponsor(object sender, Bitmap bitmap)
    {
      return CmSponsor.SetCmSponsor(this.m_CurrentCmSponsorId, bitmap);
    }

    private bool DeleteImageCmSponsor(object sender)
    {
      bool flag = CmSponsor.DeleteCmSponsor(this.m_CurrentCmSponsorId);
      if (flag)
        this.LoadNews();
      return flag;
    }

    private bool ImportImageTeamNews(object sender, Bitmap bitmap)
    {
      Team selectedItem = (Team) this.comboTeamAvailable.SelectedItem;
      if (selectedItem == null)
      {
        this.viewer2DTeamNews.CurrentBitmap = (Bitmap) null;
        return false;
      }
      int id = selectedItem.Id;
      int selectedIndex = this.comboTeamNewsType.SelectedIndex;
      if (selectedIndex < 0)
      {
        this.viewer2DTeamNews.CurrentBitmap = (Bitmap) null;
        return false;
      }
      int order = (int) this.numericTeamNewsCounter.Value;
      return TeamNews.SetTeamNews(id, selectedIndex, order, bitmap);
    }

    private bool DeleteImageTeamNews(object sender)
    {
      Team selectedItem = (Team) this.comboTeamAvailable.SelectedItem;
      if (selectedItem == null)
      {
        this.viewer2DTeamNews.CurrentBitmap = (Bitmap) null;
        return false;
      }
      int id = selectedItem.Id;
      int selectedIndex = this.comboTeamNewsType.SelectedIndex;
      if (selectedIndex < 0)
      {
        this.viewer2DTeamNews.CurrentBitmap = (Bitmap) null;
        return false;
      }
      int order = (int) this.numericTeamNewsCounter.Value;
      bool flag = TeamNews.DeleteTeamNews(id, selectedIndex, order);
      if (flag)
        this.LoadNews();
      return flag;
    }

    private bool ImportImageCmSponsorSmall(object sender, Bitmap bitmap)
    {
      return CmSponsor.SetCmSponsorSmall(this.m_CurrentCmSponsorId, bitmap);
    }

    private bool DeleteImageCmSponsorSmall(object sender)
    {
      return FifaEnvironment.DeleteFromZdata(CmSponsor.CmSponsorSmallBigFileName(this.m_CurrentCmSponsorId));
    }

    private void NewspapersForm_Load(object sender, EventArgs e)
    {
      this.Preset();
      this.LoadNews();
    }

    private void numericNewspaper(object sender, EventArgs e)
    {
      this.m_CurrentNewspaperId = (int) this.numericNewspaper1.Value;
      this.viewer2DNewspaper.CurrentBitmap = Newspaper.GetNewspaper(this.m_CurrentNewspaperId);
    }

    private void numericCmSponsor_ValueChanged(object sender, EventArgs e)
    {
      this.m_CurrentCmSponsorId = (int) this.numericCmSponsor.Value;
      this.viewer2DCmSponsor.CurrentBitmap = CmSponsor.GetCmSponsor(this.m_CurrentCmSponsorId);
      if (FifaEnvironment.Year != 14)
        return;
      this.viewer2DCmSponsorSmall.CurrentBitmap = CmSponsor.GetCmSponsorSmall(this.m_CurrentCmSponsorId);
    }

    private void comboTeamNewsType_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.LoadTeamNews();
    }

    private void numericTeamNewsCounter_ValueChanged(object sender, EventArgs e)
    {
      this.LoadTeamNews();
    }

    private void comboTeamAvailable_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.LoadTeamNews();
    }

    private void groupSpecificTeamNews_Paint(object sender, PaintEventArgs e)
    {
      if (this.comboTeamAvailable.Items.Count != 0)
        return;
      this.Preset();
      this.LoadNews();
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
      this.numericNewspaper1 = new NumericUpDown();
      this.labelNewpaper = new Label();
      this.groupNewspaper = new GroupBox();
      this.viewer2DNewspaper = new Viewer2D();
      this.groupCmSponsor = new GroupBox();
      this.viewer2DCmSponsorSmall = new Viewer2D();
      this.numericCmSponsor = new NumericUpDown();
      this.viewer2DCmSponsor = new Viewer2D();
      this.groupSpecificTeamNews = new GroupBox();
      this.viewer2DTeamNews = new Viewer2D();
      this.numericTeamNewsCounter = new NumericUpDown();
      this.comboTeamNewsType = new ComboBox();
      this.comboTeamAvailable = new ComboBox();
      this.pickUpControl = new PickUpControl();
      this.toolTip1 = new ToolTip(this.components);
      this.numericNewspaper1.BeginInit();
      this.groupNewspaper.SuspendLayout();
      this.groupCmSponsor.SuspendLayout();
      this.numericCmSponsor.BeginInit();
      this.groupSpecificTeamNews.SuspendLayout();
      this.numericTeamNewsCounter.BeginInit();
      this.SuspendLayout();
      this.numericNewspaper1.Location = new Point(85, 176);
      this.numericNewspaper1.Maximum = new Decimal(new int[4]
      {
        14,
        0,
        0,
        0
      });
      this.numericNewspaper1.Name = "numericNewspaper1";
      this.numericNewspaper1.RightToLeft = RightToLeft.No;
      this.numericNewspaper1.Size = new Size(66, 20);
      this.numericNewspaper1.TabIndex = 2;
      this.numericNewspaper1.TextAlign = HorizontalAlignment.Center;
      this.numericNewspaper1.ValueChanged += new EventHandler(this.numericNewspaper);
      this.labelNewpaper.AutoSize = true;
      this.labelNewpaper.BackColor = Color.Transparent;
      this.labelNewpaper.Location = new Point(6, 178);
      this.labelNewpaper.Name = "labelNewpaper";
      this.labelNewpaper.Size = new Size(73, 13);
      this.labelNewpaper.TabIndex = 3;
      this.labelNewpaper.Text = "Newspaper n.";
      this.groupNewspaper.Controls.Add((Control) this.viewer2DNewspaper);
      this.groupNewspaper.Controls.Add((Control) this.labelNewpaper);
      this.groupNewspaper.Controls.Add((Control) this.numericNewspaper1);
      this.groupNewspaper.Location = new Point(12, 31);
      this.groupNewspaper.Name = "groupNewspaper";
      this.groupNewspaper.Size = new Size(524, 201);
      this.groupNewspaper.TabIndex = 4;
      this.groupNewspaper.TabStop = false;
      this.groupNewspaper.Text = "Newspapers";
      this.viewer2DNewspaper.AutoTransparency = false;
      this.viewer2DNewspaper.BackColor = Color.Transparent;
      this.viewer2DNewspaper.ButtonStripVisible = true;
      this.viewer2DNewspaper.CurrentBitmap = (Bitmap) null;
      this.viewer2DNewspaper.ExtendedFormat = false;
      this.viewer2DNewspaper.FullSizeButton = false;
      this.viewer2DNewspaper.ImageLayout = ImageLayout.None;
      this.viewer2DNewspaper.ImageSize = new Size(1024, 128);
      this.viewer2DNewspaper.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DNewspaper.Location = new Point(6, 19);
      this.viewer2DNewspaper.Name = "viewer2DNewspaper";
      this.viewer2DNewspaper.RemoveButton = false;
      this.viewer2DNewspaper.ShowButton = true;
      this.viewer2DNewspaper.ShowButtonChecked = true;
      this.viewer2DNewspaper.Size = new Size(512, 153);
      this.viewer2DNewspaper.TabIndex = 1;
      this.toolTip1.SetToolTip((Control) this.viewer2DNewspaper, "Import 1024 x 128 image");
      this.groupCmSponsor.Controls.Add((Control) this.viewer2DCmSponsorSmall);
      this.groupCmSponsor.Controls.Add((Control) this.numericCmSponsor);
      this.groupCmSponsor.Controls.Add((Control) this.viewer2DCmSponsor);
      this.groupCmSponsor.Location = new Point(12, 238);
      this.groupCmSponsor.Name = "groupCmSponsor";
      this.groupCmSponsor.Size = new Size(524, 216);
      this.groupCmSponsor.TabIndex = 5;
      this.groupCmSponsor.TabStop = false;
      this.groupCmSponsor.Text = "News Sponsor";
      this.viewer2DCmSponsorSmall.AutoTransparency = false;
      this.viewer2DCmSponsorSmall.BackColor = Color.Transparent;
      this.viewer2DCmSponsorSmall.ButtonStripVisible = true;
      this.viewer2DCmSponsorSmall.CurrentBitmap = (Bitmap) null;
      this.viewer2DCmSponsorSmall.ExtendedFormat = false;
      this.viewer2DCmSponsorSmall.FullSizeButton = false;
      this.viewer2DCmSponsorSmall.ImageLayout = ImageLayout.Center;
      this.viewer2DCmSponsorSmall.ImageSize = new Size(256, 32);
      this.viewer2DCmSponsorSmall.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DCmSponsorSmall.Location = new Point(3, 138);
      this.viewer2DCmSponsorSmall.Name = "viewer2DCmSponsorSmall";
      this.viewer2DCmSponsorSmall.RemoveButton = false;
      this.viewer2DCmSponsorSmall.ShowButton = true;
      this.viewer2DCmSponsorSmall.ShowButtonChecked = true;
      this.viewer2DCmSponsorSmall.Size = new Size(256, 64);
      this.viewer2DCmSponsorSmall.TabIndex = 4;
      this.toolTip1.SetToolTip((Control) this.viewer2DCmSponsorSmall, "Import 256 x 32 image");
      this.viewer2DCmSponsorSmall.Visible = false;
      this.numericCmSponsor.Location = new Point(3, 114);
      this.numericCmSponsor.Maximum = new Decimal(new int[4]
      {
        21,
        0,
        0,
        0
      });
      this.numericCmSponsor.Name = "numericCmSponsor";
      this.numericCmSponsor.RightToLeft = RightToLeft.No;
      this.numericCmSponsor.Size = new Size(66, 20);
      this.numericCmSponsor.TabIndex = 3;
      this.numericCmSponsor.TextAlign = HorizontalAlignment.Center;
      this.numericCmSponsor.ValueChanged += new EventHandler(this.numericCmSponsor_ValueChanged);
      this.viewer2DCmSponsor.AutoTransparency = false;
      this.viewer2DCmSponsor.BackColor = Color.Transparent;
      this.viewer2DCmSponsor.ButtonStripVisible = true;
      this.viewer2DCmSponsor.CurrentBitmap = (Bitmap) null;
      this.viewer2DCmSponsor.ExtendedFormat = false;
      this.viewer2DCmSponsor.FullSizeButton = false;
      this.viewer2DCmSponsor.ImageLayout = ImageLayout.Center;
      this.viewer2DCmSponsor.ImageSize = new Size(512, 64);
      this.viewer2DCmSponsor.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DCmSponsor.Location = new Point(6, 19);
      this.viewer2DCmSponsor.Name = "viewer2DCmSponsor";
      this.viewer2DCmSponsor.RemoveButton = true;
      this.viewer2DCmSponsor.ShowButton = true;
      this.viewer2DCmSponsor.ShowButtonChecked = true;
      this.viewer2DCmSponsor.Size = new Size(512, 96);
      this.viewer2DCmSponsor.TabIndex = 2;
      this.toolTip1.SetToolTip((Control) this.viewer2DCmSponsor, "Import 512 x 64 image");
      this.groupSpecificTeamNews.Controls.Add((Control) this.viewer2DTeamNews);
      this.groupSpecificTeamNews.Controls.Add((Control) this.numericTeamNewsCounter);
      this.groupSpecificTeamNews.Controls.Add((Control) this.comboTeamNewsType);
      this.groupSpecificTeamNews.Controls.Add((Control) this.comboTeamAvailable);
      this.groupSpecificTeamNews.Location = new Point(536, 31);
      this.groupSpecificTeamNews.Name = "groupSpecificTeamNews";
      this.groupSpecificTeamNews.Size = new Size(347, 423);
      this.groupSpecificTeamNews.TabIndex = 6;
      this.groupSpecificTeamNews.TabStop = false;
      this.groupSpecificTeamNews.Text = "Specific Team News";
      this.groupSpecificTeamNews.Paint += new PaintEventHandler(this.groupSpecificTeamNews_Paint);
      this.viewer2DTeamNews.AutoTransparency = false;
      this.viewer2DTeamNews.BackColor = Color.Transparent;
      this.viewer2DTeamNews.ButtonStripVisible = true;
      this.viewer2DTeamNews.CurrentBitmap = (Bitmap) null;
      this.viewer2DTeamNews.ExtendedFormat = false;
      this.viewer2DTeamNews.FullSizeButton = true;
      this.viewer2DTeamNews.ImageLayout = ImageLayout.Zoom;
      this.viewer2DTeamNews.ImageSize = new Size(668, 550);
      this.viewer2DTeamNews.ImageSizeMultiplier = Viewer2D.SizeMultiplier.None;
      this.viewer2DTeamNews.Location = new Point(6, 101);
      this.viewer2DTeamNews.Name = "viewer2DTeamNews";
      this.viewer2DTeamNews.RemoveButton = true;
      this.viewer2DTeamNews.ShowButton = true;
      this.viewer2DTeamNews.ShowButtonChecked = true;
      this.viewer2DTeamNews.Size = new Size(334, 315);
      this.viewer2DTeamNews.TabIndex = 3;
      this.toolTip1.SetToolTip((Control) this.viewer2DTeamNews, "Import 668 x 550 image");
      this.numericTeamNewsCounter.Location = new Point(173, 57);
      this.numericTeamNewsCounter.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericTeamNewsCounter.Name = "numericTeamNewsCounter";
      this.numericTeamNewsCounter.Size = new Size(71, 20);
      this.numericTeamNewsCounter.TabIndex = 2;
      this.numericTeamNewsCounter.TextAlign = HorizontalAlignment.Center;
      this.numericTeamNewsCounter.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericTeamNewsCounter.ValueChanged += new EventHandler(this.numericTeamNewsCounter_ValueChanged);
      this.comboTeamNewsType.FormattingEnabled = true;
      this.comboTeamNewsType.Items.AddRange(new object[3]
      {
        (object) "Neutral",
        (object) "Celebrating",
        (object) "Disappointed"
      });
      this.comboTeamNewsType.Location = new Point(6, 56);
      this.comboTeamNewsType.Name = "comboTeamNewsType";
      this.comboTeamNewsType.Size = new Size(121, 21);
      this.comboTeamNewsType.TabIndex = 1;
      this.comboTeamNewsType.SelectedIndexChanged += new EventHandler(this.comboTeamNewsType_SelectedIndexChanged);
      this.comboTeamAvailable.FormattingEnabled = true;
      this.comboTeamAvailable.Location = new Point(6, 19);
      this.comboTeamAvailable.Name = "comboTeamAvailable";
      this.comboTeamAvailable.Size = new Size(238, 21);
      this.comboTeamAvailable.Sorted = true;
      this.comboTeamAvailable.TabIndex = 0;
      this.comboTeamAvailable.SelectedIndexChanged += new EventHandler(this.comboTeamAvailable_SelectedIndexChanged);
      this.pickUpControl.BackColor = SystemColors.Control;
      this.pickUpControl.CloneButtonEnabled = false;
      this.pickUpControl.CreateButtonEnabled = false;
      this.pickUpControl.CurrentIndex = 0;
      this.pickUpControl.Dock = DockStyle.Top;
      this.pickUpControl.FilterByList = (string[]) null;
      this.pickUpControl.FilterEnabled = false;
      this.pickUpControl.FilterValues = (IdArrayList[]) null;
      this.pickUpControl.Location = new Point(0, 0);
      this.pickUpControl.MainSelectionEnabled = false;
      this.pickUpControl.Name = "pickUpControl";
      this.pickUpControl.ObjectList = (IdArrayList) null;
      this.pickUpControl.RefreshButtonEnabled = true;
      this.pickUpControl.RemoveButtonEnabled = false;
      this.pickUpControl.SearchEnabled = false;
      this.pickUpControl.Size = new Size(1165, 25);
      this.pickUpControl.TabIndex = 0;
      this.pickUpControl.WizardButtonEnabled = false;
      this.pickUpControl.YoungPlayersEnabled = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImageLayout = ImageLayout.Center;
      this.ClientSize = new Size(1165, 798);
      this.Controls.Add((Control) this.groupSpecificTeamNews);
      this.Controls.Add((Control) this.groupCmSponsor);
      this.Controls.Add((Control) this.groupNewspaper);
      this.Controls.Add((Control) this.pickUpControl);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = "NewspapersForm";
      this.Text = nameof (NewspapersForm);
      this.numericNewspaper1.EndInit();
      this.groupNewspaper.ResumeLayout(false);
      this.groupNewspaper.PerformLayout();
      this.groupCmSponsor.ResumeLayout(false);
      this.numericCmSponsor.EndInit();
      this.groupSpecificTeamNews.ResumeLayout(false);
      this.numericTeamNewsCounter.EndInit();
      this.ResumeLayout(false);
    }
  }
}
