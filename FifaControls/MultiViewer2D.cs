// Original code created by Rinaldo

using FifaLibrary;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace FifaControls
{
  public class MultiViewer2D : UserControl
  {
    private static FullSizeViewer s_FullSizeViewer = new FullSizeViewer();
    private string m_InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
    private bool m_AutoTransparency;
    private bool m_CheckBitmapSize;
    private bool m_FixedSize;
    public MultiViewer2D.Rx3SaveHandler Rx3SaveDelegate;
    public MultiViewer2D.Rx3ExportHandler Rx3ExportDelegate;
    public MultiViewer2D.Rx3ImportHandler Rx3ImportDelegate;
    public MultiViewer2D.Rx3DeleteHandler Rx3DeleteDelegate;
    private int m_CurrentIndex;
    private Bitmap[] m_Bitmaps;
    private bool m_NeedToSave;
    private IContainer components;
    private Label label;
    private NumericUpDown numeric;
    private ToolStrip toolStrip;
    public ToolStripButton buttonImportImage;
    public ToolStripButton buttonExportImage;
    public ToolStripButton buttonImportRx3;
    public ToolStripButton buttonExportRx3;
    private ToolStripTextBox textSize;
    public PictureBox pictureBox;
    public ToolStripButton buttonSave;
    private FolderBrowserDialog folderBrowserDialog;
    private OpenFileDialog openFileDialogBmp;
    private OpenFileDialog openFileDialogRx3;
    private SaveFileDialog saveFileDialogBmp;
    private Label labelOf;
    private ToolStripButton buttonRemoveRx3;
    public ToolStripButton buttonFullSize;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripSeparator toolStripSeparator2;

    [Description("Auto Transparency.")]
    [Category("User")]
    public bool AutoTransparency
    {
      get
      {
        return this.m_AutoTransparency;
      }
      set
      {
        this.m_AutoTransparency = value;
      }
    }

    [Category("User")]
    [Description("Check for bitmap size.")]
    public bool CheckBitmapSize
    {
      get
      {
        return this.m_CheckBitmapSize;
      }
      set
      {
        this.m_CheckBitmapSize = value;
      }
    }

    [Category("User")]
    [Description("Label text.")]
    public string LabelText
    {
      get
      {
        return this.label.Text;
      }
      set
      {
        this.label.Text = value;
      }
    }

    [Description("Show Delete Button.")]
    [Category("User")]
    public bool ShowDeleteButton
    {
      get
      {
        return this.buttonRemoveRx3.Visible;
      }
      set
      {
        this.buttonRemoveRx3.Visible = value;
      }
    }

    [Category("User")]
    [Description("Full Size Button Visible.")]
    public bool FullSizeButton
    {
      get
      {
        return this.buttonFullSize.Visible;
      }
      set
      {
        this.buttonFullSize.Visible = value;
      }
    }

    [Description("Fixed size.")]
    [Category("User")]
    public bool FixedSize
    {
      get
      {
        return this.m_FixedSize;
      }
      set
      {
        this.m_FixedSize = value;
      }
    }

    [Description("Bitmaps.")]
    [Category("User")]
    public Bitmap[] Bitmaps
    {
      get
      {
        return this.m_Bitmaps;
      }
      set
      {
        this.m_Bitmaps = value;
        if (this.m_Bitmaps != null)
        {
          this.numeric.Maximum = (Decimal) this.m_Bitmaps.Length;
          this.labelOf.Text = "/" + this.m_Bitmaps.Length.ToString();
          if (this.m_CurrentIndex >= this.m_Bitmaps.Length)
            this.m_CurrentIndex = 0;
          else
            this.numeric_ValueChanged((object) null, (EventArgs) null);
        }
        else
        {
          this.m_CurrentIndex = 0;
          this.numeric_ValueChanged((object) null, (EventArgs) null);
        }
        this.m_NeedToSave = false;
      }
    }

    public Bitmap GetCurrentBitmap()
    {
      return this.m_Bitmaps != null && this.m_CurrentIndex < this.m_Bitmaps.Length ? this.m_Bitmaps[this.m_CurrentIndex] : (Bitmap) null;
    }

    private string InitialDirectory
    {
      get
      {
        return this.m_InitialDirectory;
      }
      set
      {
        this.folderBrowserDialog.SelectedPath = value;
        this.openFileDialogBmp.InitialDirectory = value;
        this.openFileDialogRx3.InitialDirectory = value;
        this.saveFileDialogBmp.InitialDirectory = value;
        this.m_InitialDirectory = value;
      }
    }

    public MultiViewer2D()
    {
      this.InitializeComponent();
    }

    private void numeric_ValueChanged(object sender, EventArgs e)
    {
      this.m_CurrentIndex = (int) this.numeric.Value - 1;
      if (this.m_Bitmaps != null && this.m_Bitmaps[this.m_CurrentIndex] != null)
      {
        this.pictureBox.BackgroundImage = (Image) this.m_Bitmaps[this.m_CurrentIndex];
        this.textSize.Text = this.m_Bitmaps[this.m_CurrentIndex].Width.ToString() + " x " + (object) this.m_Bitmaps[this.m_CurrentIndex].Height;
        this.AdjustImageLayout();
      }
      else
        this.pictureBox.BackgroundImage = (Image) null;
    }

    private void buttonImportImage_Click(object sender, EventArgs e)
    {
      this.ImportImage();
    }

    private void ImportImage()
    {
      Bitmap bitmap = this.BrowseAndCheckBitmap();
      this.Refresh();
      if (bitmap == null)
        return;
      this.pictureBox.BackgroundImage = (Image) bitmap;
      this.m_NeedToSave = true;
      this.buttonSave.Enabled = true;
      if (this.m_Bitmaps == null)
        this.m_Bitmaps = new Bitmap[(int) this.numeric.Maximum];
      this.m_Bitmaps[this.m_CurrentIndex] = bitmap;
    }

    private Bitmap BrowseAndCheckBitmap()
    {
      this.openFileDialogBmp.CheckFileExists = true;
      this.openFileDialogBmp.Multiselect = false;
      this.openFileDialogBmp.InitialDirectory = this.m_InitialDirectory;
      this.openFileDialogBmp.RestoreDirectory = true;
      this.openFileDialogBmp.Filter = "Image Files (*.bmp;*.png)|*.bmp;*.png";
      this.openFileDialogBmp.FilterIndex = 1;
      this.openFileDialogBmp.Title = "Open Image File";
      if (this.openFileDialogBmp.ShowDialog() != DialogResult.OK)
        return (Bitmap) null;
      string fileName = this.openFileDialogBmp.FileName;
      this.InitialDirectory = Path.GetDirectoryName(fileName);
      Bitmap bitmap1 = new Bitmap(fileName);
      if (bitmap1 == null)
        return (Bitmap) null;
      Cursor.Current = Cursors.WaitCursor;
      this.FindForm().Refresh();
      if (this.m_CheckBitmapSize && this.m_Bitmaps != null && (this.m_Bitmaps[this.m_CurrentIndex] != null && this.m_CurrentIndex >= 0) && this.m_CurrentIndex < this.m_Bitmaps.Length)
      {
        int width = this.m_Bitmaps[this.m_CurrentIndex].Width;
        int height = this.m_Bitmaps[this.m_CurrentIndex].Height;
        if ((bitmap1.Width != width || bitmap1.Height != height) && (bitmap1.Width != width || bitmap1.Height != height))
        {
          Cursor.Current = Cursors.Default;
          int num = (int) FifaEnvironment.UserMessages.ShowMessage(5015);
          return (Bitmap) null;
        }
      }
      if (this.m_AutoTransparency && Path.GetExtension(fileName).ToLower() == ".bmp")
      {
        Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height, PixelFormat.Format32bppArgb);
        Color pixel1 = bitmap1.GetPixel(0, 0);
        Color color = Color.FromArgb(0, 0, 0, 0);
        for (int x = 0; x < bitmap1.Width; ++x)
        {
          for (int y = 0; y < bitmap1.Height; ++y)
          {
            Color pixel2 = bitmap1.GetPixel(x, y);
            if (pixel2 == pixel1)
              bitmap2.SetPixel(x, y, color);
            else
              bitmap2.SetPixel(x, y, pixel2);
          }
        }
        Cursor.Current = Cursors.Default;
        return bitmap2;
      }
      Cursor.Current = Cursors.Default;
      return bitmap1;
    }

    private void buttonExportImage_Click(object sender, EventArgs e)
    {
      this.ExportImage();
    }

    private void ExportImage()
    {
      this.AskAndSaveBitmap((Bitmap) this.pictureBox.BackgroundImage);
    }

    private bool AskAndSaveBitmap(Bitmap bitmap)
    {
      if (bitmap == null)
        return false;
      this.saveFileDialogBmp.InitialDirectory = this.m_InitialDirectory;
      if (this.saveFileDialogBmp.ShowDialog() != DialogResult.OK)
        return false;
      string extension = Path.GetExtension(this.saveFileDialogBmp.FileName);
      this.InitialDirectory = Path.GetDirectoryName(this.saveFileDialogBmp.FileName);
      ImageFormat format;
      if (extension.ToLower() == ".bmp")
      {
        format = ImageFormat.Bmp;
        Color pixel = bitmap.GetPixel(0, 0);
        for (int x = bitmap.Width - 1; x >= 0; --x)
        {
          for (int y = bitmap.Height - 1; y >= 0; --y)
          {
            if (bitmap.GetPixel(x, y).A < (byte) 192)
              bitmap.SetPixel(x, y, pixel);
          }
        }
      }
      else
      {
        if (!(extension.ToLower() == ".png"))
          return false;
        format = ImageFormat.Png;
      }
      bitmap.Save(this.saveFileDialogBmp.FileName, format);
      return true;
    }

    private void buttonImportFsh_Click(object sender, EventArgs e)
    {
      this.ImportRx3();
    }

    private void ImportRx3()
    {
      string rx3FileName = this.BrowseRx3();
      if (rx3FileName == null)
        return;
      if (this.Rx3ImportDelegate != null)
      {
        int num = this.Rx3ImportDelegate((object) this, rx3FileName) ? 1 : 0;
      }
      this.m_NeedToSave = false;
      this.buttonSave.Enabled = false;
    }

    private string BrowseRx3()
    {
      this.openFileDialogRx3.InitialDirectory = this.m_InitialDirectory;
      if (this.openFileDialogRx3.ShowDialog() != DialogResult.OK)
        return (string) null;
      string fileName = this.openFileDialogRx3.FileName;
      this.InitialDirectory = Path.GetDirectoryName(fileName);
      return fileName;
    }

    private string BrowseExportingFolder()
    {
      this.folderBrowserDialog.Description = "Select the export folder";
      this.folderBrowserDialog.ShowNewFolderButton = true;
      if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
        return this.folderBrowserDialog.SelectedPath;
      this.folderBrowserDialog.Dispose();
      return (string) null;
    }

    private void buttonExportRx3_Click(object sender, EventArgs e)
    {
      this.ExportRx3File();
    }

    private void ExportRx3File()
    {
      string exportDir = this.BrowseExportingFolder();
      if (exportDir == null || this.Rx3ExportDelegate == null)
        return;
      int num = this.Rx3ExportDelegate((object) this, exportDir) ? 1 : 0;
    }

    private void buttonSave_Click(object sender, EventArgs e)
    {
      Cursor.Current = Cursors.WaitCursor;
      if (this.Rx3SaveDelegate != null)
      {
        int num = this.Rx3SaveDelegate(sender, this.m_Bitmaps) ? 1 : 0;
      }
      this.m_NeedToSave = false;
      this.buttonSave.Enabled = false;
      Cursor.Current = Cursors.Default;
    }

    private void MultiViewer2D_Resize(object sender, EventArgs e)
    {
      this.AdjustImageLayout();
    }

    private void AdjustImageLayout()
    {
      int num1 = 128;
      int num2 = 128;
      if (this.m_Bitmaps != null && this.m_Bitmaps[this.m_CurrentIndex] != null)
      {
        num1 = this.m_Bitmaps[this.m_CurrentIndex].Width;
        num2 = this.m_Bitmaps[this.m_CurrentIndex].Height;
      }
      if (this.pictureBox.Width < num1 || this.pictureBox.Height < num2)
        this.pictureBox.BackgroundImageLayout = ImageLayout.Zoom;
      else
        this.pictureBox.BackgroundImageLayout = ImageLayout.Center;
    }

    private void buttonFullSize_Click(object sender, EventArgs e)
    {
      if (this.m_Bitmaps[this.m_CurrentIndex] == null)
        return;
      MultiViewer2D.s_FullSizeViewer.SetImage((Image) this.m_Bitmaps[this.m_CurrentIndex]);
      int num = (int) MultiViewer2D.s_FullSizeViewer.ShowDialog();
    }

    private void buttonRemoveRx3_Click(object sender, EventArgs e)
    {
      this.m_Bitmaps = (Bitmap[]) null;
      this.pictureBox.BackgroundImage = (Image) null;
      this.m_CurrentIndex = 0;
      this.numeric.Value = new Decimal(1);
      if (this.Rx3DeleteDelegate == null)
        return;
      int num = this.Rx3DeleteDelegate((object) this) ? 1 : 0;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager resources = new ComponentResourceManager(typeof (MultiViewer2D));
      this.label = new Label();
      this.numeric = new NumericUpDown();
      this.toolStrip = new ToolStrip();
      this.buttonSave = new ToolStripButton();
      this.buttonImportImage = new ToolStripButton();
      this.buttonExportImage = new ToolStripButton();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.buttonImportRx3 = new ToolStripButton();
      this.buttonExportRx3 = new ToolStripButton();
      this.buttonRemoveRx3 = new ToolStripButton();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.buttonFullSize = new ToolStripButton();
      this.textSize = new ToolStripTextBox();
      this.pictureBox = new PictureBox();
      this.folderBrowserDialog = new FolderBrowserDialog();
      this.openFileDialogBmp = new OpenFileDialog();
      this.openFileDialogRx3 = new OpenFileDialog();
      this.saveFileDialogBmp = new SaveFileDialog();
      this.labelOf = new Label();
      this.numeric.BeginInit();
      this.toolStrip.SuspendLayout();
      ((ISupportInitialize) this.pictureBox).BeginInit();
      this.SuspendLayout();
      this.label.Dock = DockStyle.Top;
      this.label.Location = new Point(0, 0);
      this.label.Name = "label";
      this.label.Size = new Size(257, 20);
      this.label.TabIndex = 0;
      this.label.Text = "Image n.";
      this.label.TextAlign = ContentAlignment.MiddleLeft;
      this.numeric.Location = new Point(49, 0);
      this.numeric.Maximum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numeric.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numeric.Name = "numeric";
      this.numeric.Size = new Size(54, 20);
      this.numeric.TabIndex = 1;
      this.numeric.TextAlign = HorizontalAlignment.Center;
      this.numeric.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numeric.ValueChanged += new EventHandler(this.numeric_ValueChanged);
      this.toolStrip.Dock = DockStyle.Bottom;
      this.toolStrip.GripStyle = ToolStripGripStyle.Hidden;
      this.toolStrip.Items.AddRange(new ToolStripItem[10]
      {
        (ToolStripItem) this.buttonSave,
        (ToolStripItem) this.buttonImportImage,
        (ToolStripItem) this.buttonExportImage,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.buttonImportRx3,
        (ToolStripItem) this.buttonExportRx3,
        (ToolStripItem) this.buttonRemoveRx3,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.buttonFullSize,
        (ToolStripItem) this.textSize
      });
      this.toolStrip.Location = new Point(0, 248);
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.Size = new Size(257, 25);
      this.toolStrip.TabIndex = 2;
      this.buttonSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonSave.Enabled = false;
      this.buttonSave.Image = (Image) resources.GetObject("buttonSave.Image");
      this.buttonSave.ImageTransparentColor = Color.Magenta;
      this.buttonSave.Name = "buttonSave";
      this.buttonSave.Size = new Size(23, 22);
      this.buttonSave.Text = "Save";
      this.buttonSave.Click += new EventHandler(this.buttonSave_Click);
      this.buttonImportImage.AutoSize = false;
      this.buttonImportImage.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonImportImage.Image = (Image) resources.GetObject("buttonImportImage.Image");
      this.buttonImportImage.ImageTransparentColor = Color.Magenta;
      this.buttonImportImage.Name = "buttonImportImage";
      this.buttonImportImage.Size = new Size(20, 22);
      this.buttonImportImage.Text = "Import Image";
      this.buttonImportImage.Click += new EventHandler(this.buttonImportImage_Click);
      this.buttonExportImage.AutoSize = false;
      this.buttonExportImage.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonExportImage.Image = (Image) resources.GetObject("buttonExportImage.Image");
      this.buttonExportImage.ImageTransparentColor = Color.Magenta;
      this.buttonExportImage.Name = "buttonExportImage";
      this.buttonExportImage.Size = new Size(20, 22);
      this.buttonExportImage.Text = "Export Image";
      this.buttonExportImage.Click += new EventHandler(this.buttonExportImage_Click);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(6, 25);
      this.buttonImportRx3.AutoSize = false;
      this.buttonImportRx3.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonImportRx3.Image = (Image) resources.GetObject("buttonImportRx3.Image");
      this.buttonImportRx3.ImageTransparentColor = Color.Magenta;
      this.buttonImportRx3.Name = "buttonImportRx3";
      this.buttonImportRx3.Size = new Size(20, 22);
      this.buttonImportRx3.Text = "Import Rx3";
      this.buttonImportRx3.Click += new EventHandler(this.buttonImportFsh_Click);
      this.buttonExportRx3.AutoSize = false;
      this.buttonExportRx3.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonExportRx3.Image = (Image) resources.GetObject("buttonExportRx3.Image");
      this.buttonExportRx3.ImageTransparentColor = Color.Magenta;
      this.buttonExportRx3.Name = "buttonExportRx3";
      this.buttonExportRx3.Size = new Size(20, 22);
      this.buttonExportRx3.Text = "Export as Rx3";
      this.buttonExportRx3.Click += new EventHandler(this.buttonExportRx3_Click);
      this.buttonRemoveRx3.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonRemoveRx3.Image = (Image) resources.GetObject("buttonRemoveRx3.Image");
      this.buttonRemoveRx3.ImageTransparentColor = Color.Magenta;
      this.buttonRemoveRx3.Name = "buttonRemoveRx3";
      this.buttonRemoveRx3.Size = new Size(23, 22);
      this.buttonRemoveRx3.Text = "Remove";
      this.buttonRemoveRx3.Click += new EventHandler(this.buttonRemoveRx3_Click);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(6, 25);
      this.buttonFullSize.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonFullSize.Image = (Image) resources.GetObject("buttonFullSize.Image");
      this.buttonFullSize.ImageTransparentColor = Color.Magenta;
      this.buttonFullSize.Name = "buttonFullSize";
      this.buttonFullSize.Size = new Size(23, 22);
      this.buttonFullSize.Text = "View Full Size";
      this.buttonFullSize.Visible = false;
      this.buttonFullSize.Click += new EventHandler(this.buttonFullSize_Click);
      this.textSize.BackColor = Color.White;
      this.textSize.Name = "textSize";
      this.textSize.ReadOnly = true;
      this.textSize.Size = new Size(70, 25);
      this.textSize.Text = "1024 x 1024";
      this.textSize.TextBoxTextAlign = HorizontalAlignment.Center;
      this.pictureBox.BackgroundImageLayout = ImageLayout.Center;
      this.pictureBox.BorderStyle = BorderStyle.FixedSingle;
      this.pictureBox.Dock = DockStyle.Fill;
      this.pictureBox.Location = new Point(0, 20);
      this.pictureBox.Name = "pictureBox";
      this.pictureBox.Size = new Size(257, 228);
      this.pictureBox.TabIndex = 3;
      this.pictureBox.TabStop = false;
      this.openFileDialogBmp.Filter = "Image Files (*.bmp;*.png)|*.bmp;*.png";
      this.openFileDialogBmp.Title = "Open Image File";
      this.openFileDialogRx3.Filter = "rx3 files (*.rx3)|*.rx3";
      this.openFileDialogRx3.Title = "Open rx3 file";
      this.saveFileDialogBmp.Filter = "bmp files (*.bmp)|*.bmp|png files (*.png)|*.png";
      this.saveFileDialogBmp.FilterIndex = 2;
      this.saveFileDialogBmp.Title = "Save image as .bmp or .png";
      this.labelOf.AutoSize = true;
      this.labelOf.Location = new Point(107, 4);
      this.labelOf.Name = "labelOf";
      this.labelOf.Size = new Size(19, 13);
      this.labelOf.TabIndex = 4;
      this.labelOf.Text = "of ";
      this.Controls.Add((Control) this.labelOf);
      this.Controls.Add((Control) this.pictureBox);
      this.Controls.Add((Control) this.toolStrip);
      this.Controls.Add((Control) this.numeric);
      this.Controls.Add((Control) this.label);
      this.Name = "MultiViewer2D";
      this.Size = new Size(257, 273);
      this.Resize += new EventHandler(this.MultiViewer2D_Resize);
      this.numeric.EndInit();
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      ((ISupportInitialize) this.pictureBox).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public delegate bool Rx3SaveHandler(object sender, Bitmap[] bitmaps);

    public delegate bool Rx3ImportHandler(object sender, string rx3FileName);

    public delegate bool Rx3ExportHandler(object sender, string exportDir);

    public delegate bool Rx3DeleteHandler(object sender);
  }
}
