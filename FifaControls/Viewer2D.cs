// Original code created by Rinaldo

using FifaLibrary;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace FifaControls
{
  public class Viewer2D : UserControl
  {
    private static FullSizeViewer s_FullSizeViewer = new FullSizeViewer();
    private string m_InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
    private IContainer components;
    public PictureBox picture;
    private ToolStrip toolStrip;
    private ToolStripTextBox textSize;
    private OpenFileDialog openFileDialog;
    public ToolStripButton buttonImportImage;
    public ToolStripButton buttonExportImage;
    public ToolStripButton buttonRemove;
    public ToolStripButton buttonFullSize;
    private ToolStripButton buttonShow;
    private ContextMenuStrip contextMenuStrip;
    private ToolStripMenuItem importImageToolStripMenuItem;
    private ToolStripMenuItem exportImageToolStripMenuItem;
    private ToolStripMenuItem removeToolStripMenuItem;
    private Size m_ImageSize;
    private Viewer2D.SizeMultiplier m_ImageSizeMultiplier;
    private bool m_AutoTransparency;
    private bool m_ExtendedFormat;
    private Bitmap m_Bitmap;
    public Viewer2D.ImageImportHandler ImageImport;
    public Viewer2D.ImageDeleteHandler ImageDelete;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager resources = new ComponentResourceManager(typeof (Viewer2D));
      this.picture = new PictureBox();
      this.contextMenuStrip = new ContextMenuStrip(this.components);
      this.importImageToolStripMenuItem = new ToolStripMenuItem();
      this.exportImageToolStripMenuItem = new ToolStripMenuItem();
      this.removeToolStripMenuItem = new ToolStripMenuItem();
      this.toolStrip = new ToolStrip();
      this.buttonShow = new ToolStripButton();
      this.buttonImportImage = new ToolStripButton();
      this.buttonExportImage = new ToolStripButton();
      this.buttonFullSize = new ToolStripButton();
      this.buttonRemove = new ToolStripButton();
      this.textSize = new ToolStripTextBox();
      this.openFileDialog = new OpenFileDialog();
      ((ISupportInitialize) this.picture).BeginInit();
      this.contextMenuStrip.SuspendLayout();
      this.toolStrip.SuspendLayout();
      this.SuspendLayout();
      this.picture.BackColor = SystemColors.Control;
      this.picture.BackgroundImageLayout = ImageLayout.None;
      this.picture.BorderStyle = BorderStyle.FixedSingle;
      this.picture.ContextMenuStrip = this.contextMenuStrip;
      this.picture.Dock = DockStyle.Fill;
      this.picture.Location = new Point(0, 0);
      this.picture.Name = "picture";
      this.picture.Size = new Size(197, 187);
      this.picture.TabIndex = 0;
      this.picture.TabStop = false;
      this.contextMenuStrip.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.importImageToolStripMenuItem,
        (ToolStripItem) this.exportImageToolStripMenuItem,
        (ToolStripItem) this.removeToolStripMenuItem
      });
      this.contextMenuStrip.Name = "contextMenuStrip";
      this.contextMenuStrip.Size = new Size(147, 70);
      this.importImageToolStripMenuItem.Image = (Image) resources.GetObject("importImageToolStripMenuItem.Image");
      this.importImageToolStripMenuItem.ImageTransparentColor = Color.Fuchsia;
      this.importImageToolStripMenuItem.Name = "importImageToolStripMenuItem";
      this.importImageToolStripMenuItem.Size = new Size(146, 22);
      this.importImageToolStripMenuItem.Text = "Import Image";
      this.importImageToolStripMenuItem.Click += new EventHandler(this.buttonImportImage_Click);
      this.exportImageToolStripMenuItem.Image = (Image) resources.GetObject("exportImageToolStripMenuItem.Image");
      this.exportImageToolStripMenuItem.ImageTransparentColor = Color.Fuchsia;
      this.exportImageToolStripMenuItem.Name = "exportImageToolStripMenuItem";
      this.exportImageToolStripMenuItem.Size = new Size(146, 22);
      this.exportImageToolStripMenuItem.Text = "Export Image";
      this.exportImageToolStripMenuItem.Click += new EventHandler(this.buttonExportImage_Click);
      this.removeToolStripMenuItem.Image = (Image) resources.GetObject("removeToolStripMenuItem.Image");
      this.removeToolStripMenuItem.ImageTransparentColor = Color.Fuchsia;
      this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
      this.removeToolStripMenuItem.Size = new Size(146, 22);
      this.removeToolStripMenuItem.Text = "Remove";
      this.removeToolStripMenuItem.Click += new EventHandler(this.buttonRemove_Click);
      this.toolStrip.Dock = DockStyle.Bottom;
      this.toolStrip.GripStyle = ToolStripGripStyle.Hidden;
      this.toolStrip.Items.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) this.buttonShow,
        (ToolStripItem) this.buttonImportImage,
        (ToolStripItem) this.buttonExportImage,
        (ToolStripItem) this.buttonFullSize,
        (ToolStripItem) this.buttonRemove,
        (ToolStripItem) this.textSize
      });
      this.toolStrip.Location = new Point(0, 187);
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.Size = new Size(197, 25);
      this.toolStrip.TabIndex = 2;
      this.toolStrip.Text = "toolStrip1";
      this.buttonShow.Checked = true;
      this.buttonShow.CheckOnClick = true;
      this.buttonShow.CheckState = CheckState.Checked;
      this.buttonShow.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonShow.Image = (Image) resources.GetObject("buttonShow.Image");
      this.buttonShow.ImageTransparentColor = Color.Magenta;
      this.buttonShow.Name = "buttonShow";
      this.buttonShow.Size = new Size(23, 22);
      this.buttonShow.Text = "Show / Hide";
      this.buttonShow.Click += new EventHandler(this.buttonShow_Click);
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
      this.buttonFullSize.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonFullSize.Image = (Image) resources.GetObject("buttonFullSize.Image");
      this.buttonFullSize.ImageTransparentColor = Color.Magenta;
      this.buttonFullSize.Name = "buttonFullSize";
      this.buttonFullSize.Size = new Size(23, 22);
      this.buttonFullSize.Text = "View Full Size";
      this.buttonFullSize.Visible = false;
      this.buttonFullSize.Click += new EventHandler(this.buttonFullSize_Click);
      this.buttonRemove.AutoSize = false;
      this.buttonRemove.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.buttonRemove.Image = (Image) resources.GetObject("buttonRemove.Image");
      this.buttonRemove.ImageTransparentColor = Color.Magenta;
      this.buttonRemove.Name = "buttonRemove";
      this.buttonRemove.Size = new Size(20, 22);
      this.buttonRemove.Text = "Remove";
      this.buttonRemove.Visible = false;
      this.buttonRemove.Click += new EventHandler(this.buttonRemove_Click);
      this.textSize.BackColor = Color.White;
      this.textSize.Name = "textSize";
      this.textSize.ReadOnly = true;
      this.textSize.Size = new Size(65, 25);
      this.textSize.Text = "1024 x 1024";
      this.textSize.TextBoxTextAlign = HorizontalAlignment.Center;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Transparent;
      this.Controls.Add((Control) this.picture);
      this.Controls.Add((Control) this.toolStrip);
      this.Name = "Viewer2D";
      this.Size = new Size(197, 212);
      ((ISupportInitialize) this.picture).EndInit();
      this.contextMenuStrip.ResumeLayout(false);
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    [Category("User")]
    [Description("Image Size.")]
    public Size ImageSize
    {
      get
      {
        return this.m_ImageSize;
      }
      set
      {
        this.m_ImageSize = value;
      }
    }

    [Description("Image Alternative Size Multiplier.")]
    [Category("User")]
    public Viewer2D.SizeMultiplier ImageSizeMultiplier
    {
      get
      {
        return this.m_ImageSizeMultiplier;
      }
      set
      {
        this.m_ImageSizeMultiplier = value;
      }
    }

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

    [Description("Remove Button Visible.")]
    [Category("User")]
    public bool RemoveButton
    {
      get
      {
        return this.buttonRemove.Visible;
      }
      set
      {
        this.buttonRemove.Visible = value;
      }
    }

    [Description("Show Button Visible.")]
    [Category("User")]
    public bool ShowButton
    {
      get
      {
        return this.buttonShow.Visible;
      }
      set
      {
        this.buttonShow.Visible = value;
      }
    }

    [Category("User")]
    [Description("Show Button Checked.")]
    public bool ShowButtonChecked
    {
      get
      {
        return this.buttonShow.Checked;
      }
      set
      {
        this.buttonShow.Checked = value;
      }
    }

    [Category("User")]
    [Description("Button strip visible.")]
    public bool ButtonStripVisible
    {
      get
      {
        return this.toolStrip.Visible;
      }
      set
      {
        this.toolStrip.Visible = value;
      }
    }

    [Category("User")]
    [Description("Extended Format")]
    public bool ExtendedFormat
    {
      get
      {
        return this.m_ExtendedFormat;
      }
      set
      {
        this.m_ExtendedFormat = value;
      }
    }

    public Bitmap CurrentBitmap
    {
      get
      {
        return this.m_Bitmap;
      }
      set
      {
        this.m_Bitmap = value;
        if (!this.buttonShow.Checked)
          return;
        this.picture.BackgroundImage = (Image) value;
        this.EnableButtons();
      }
    }

    [Category("User")]
    [Description("Image Layout.")]
    public ImageLayout ImageLayout
    {
      get
      {
        return this.picture.BackgroundImageLayout;
      }
      set
      {
        this.picture.BackgroundImageLayout = value;
      }
    }

    public string CurrentFolder
    {
      set
      {
        this.m_InitialDirectory = value;
      }
    }

    public Viewer2D()
    {
      this.InitializeComponent();
    }

    private void buttonImportImage_Click(object sender, EventArgs e)
    {
      this.ImportImage();
    }

    private void menuImportImage_Click(object sender, EventArgs e)
    {
      this.ImportImage();
    }

    private void ImportImage()
    {
      Bitmap bitmap = this.BrowseAndCheckBitmap();
      if (bitmap == null)
        return;
      if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
        bitmap = GraphicUtil.Get32bitBitmap(bitmap);
      if (this.ImageImport != null && !this.ImageImport((object) this, bitmap))
        return;
      this.CurrentBitmap = bitmap;
      this.Refresh();
    }

    private Bitmap BrowseAndCheckBitmap()
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.CheckFileExists = true;
      openFileDialog.Multiselect = false;
      openFileDialog.InitialDirectory = this.m_InitialDirectory;
      openFileDialog.RestoreDirectory = true;
      if (this.m_ExtendedFormat)
        openFileDialog.Filter = "Image Files (*.bmp;*.png;*.jpg)|*.bmp;*.png;*.jpg";
      else
        openFileDialog.Filter = "Image Files (*.bmp;*.png)|*.bmp;*.png";
      openFileDialog.FilterIndex = 1;
      openFileDialog.Title = "Open Image File";
      if (openFileDialog.ShowDialog() != DialogResult.OK)
      {
        openFileDialog.Dispose();
        return (Bitmap) null;
      }
      string fileName = openFileDialog.FileName;
      this.m_InitialDirectory = Path.GetDirectoryName(fileName);
      openFileDialog.Dispose();
      Bitmap bitmap = new Bitmap(fileName);
      if (bitmap == null)
        return (Bitmap) null;
      Cursor.Current = Cursors.WaitCursor;
      this.FindForm().Refresh();
      int num1 = this.m_ImageSize.Width;
      int num2 = this.m_ImageSize.Height;
      if (bitmap.Width != num1 || bitmap.Height != num2)
      {
        switch (this.m_ImageSizeMultiplier)
        {
          case Viewer2D.SizeMultiplier.OneAndHalf:
            num1 += num1 / 2;
            num2 += num2 / 2;
            break;
          case Viewer2D.SizeMultiplier.Double:
            num1 *= 2;
            num2 *= 2;
            break;
          case Viewer2D.SizeMultiplier.Half:
            num1 /= 2;
            num2 /= 2;
            break;
          case Viewer2D.SizeMultiplier.Kit:
            if (bitmap.Width == 512 && bitmap.Height == 512 || bitmap.Width == 768 && bitmap.Height == 768 || bitmap.Width == 1024 && bitmap.Height == 1024)
            {
              num1 = bitmap.Width;
              num2 = bitmap.Height;
              break;
            }
            break;
          case Viewer2D.SizeMultiplier.MiniFace:
            int width = bitmap.Width;
            int height = bitmap.Height;
            if (bitmap.PixelFormat == PixelFormat.Format24bppRgb || bitmap.PixelFormat == PixelFormat.Format32bppArgb)
            {
              num1 = 128;
              num2 = 128;
              bitmap = GraphicUtil.ResizeBitmap(GraphicUtil.MakeAutoTransparent(bitmap), 128, 128, InterpolationMode.HighQualityBilinear);
              break;
            }
            if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
              return (Bitmap) null;
            num1 = 128;
            num2 = 128;
            bitmap = GraphicUtil.ResizeBitmap(bitmap, 128, 128, InterpolationMode.HighQualityBilinear);
            break;
          case Viewer2D.SizeMultiplier.Auto256:
            num1 = bitmap.Width;
            num2 = bitmap.Height;
            if (num1 != 256 || num2 != 256)
            {
              if (bitmap.PixelFormat == PixelFormat.Format32bppArgb)
              {
                num1 = 256;
                num2 = 256;
                bitmap = GraphicUtil.ResizeBitmap(bitmap, 256, 256, InterpolationMode.HighQualityBilinear);
                break;
              }
              if (bitmap.PixelFormat == PixelFormat.Format24bppRgb)
              {
                num1 = 256;
                num2 = 256;
                bitmap = GraphicUtil.ResizeBitmap(GraphicUtil.MakeAutoTransparent(bitmap), 256, 256, InterpolationMode.HighQualityBilinear);
                break;
              }
              break;
            }
            break;
        }
        if (this.m_ImageSizeMultiplier != Viewer2D.SizeMultiplier.Free && (bitmap.Width != num1 || bitmap.Height != num2))
        {
          Cursor.Current = Cursors.Default;
          int num3 = (int) FifaEnvironment.UserMessages.ShowMessage(5015);
          return (Bitmap) null;
        }
      }
      if (this.m_AutoTransparency && Path.GetExtension(fileName).ToLower() == ".bmp")
        bitmap = GraphicUtil.MakeAutoTransparent(bitmap);
      Cursor.Current = Cursors.Default;
      return bitmap;
    }

    private void buttonRemove_Click(object sender, EventArgs e)
    {
      this.RemoveImage();
    }

    private void RemoveImage()
    {
      this.picture.BackgroundImage = (Image) null;
      this.CurrentBitmap = (Bitmap) null;
      if (this.ImageDelete == null)
        return;
      int num = this.ImageDelete((object) this) ? 1 : 0;
    }

    private void buttonExportImage_Click(object sender, EventArgs e)
    {
      this.ExportImage();
    }

    private void ExportImage()
    {
      this.AskAndSaveBitmap(this.m_Bitmap);
    }

    private bool AskAndSaveBitmap(Bitmap bitmap)
    {
      if (bitmap == null)
        return false;
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Filter = "bmp files (*.bmp)|*.bmp|png files (*.png)|*.png";
      saveFileDialog.InitialDirectory = this.m_InitialDirectory;
      saveFileDialog.FilterIndex = 2;
      saveFileDialog.Title = "Save picture as .bmp or .png";
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
      {
        saveFileDialog.Dispose();
        return false;
      }
      Cursor.Current = Cursors.WaitCursor;
      this.FindForm().Refresh();
      string extension = Path.GetExtension(saveFileDialog.FileName);
      this.m_InitialDirectory = Path.GetDirectoryName(saveFileDialog.FileName);
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
      else if (extension.ToLower() == ".png")
      {
        format = ImageFormat.Png;
      }
      else
      {
        Cursor.Current = Cursors.Default;
        return false;
      }
      string fileName = saveFileDialog.FileName;
      bitmap.Save(saveFileDialog.FileName, format);
      saveFileDialog.Dispose();
      Cursor.Current = Cursors.Default;
      return true;
    }

    public void DisposeBitmap()
    {
      if (this.picture.BackgroundImage == null)
        return;
      this.picture.BackgroundImage.Dispose();
      this.picture.BackgroundImage = (Image) null;
    }

    private void buttonFullSize_Click(object sender, EventArgs e)
    {
      if (this.m_Bitmap == null)
        return;
      Viewer2D.s_FullSizeViewer.SetImage((Image) this.m_Bitmap);
      int num = (int) Viewer2D.s_FullSizeViewer.ShowDialog();
    }

    private void buttonShow_Click(object sender, EventArgs e)
    {
      this.EnableButtons();
    }

    private void EnableButtons()
    {
      bool flag = this.buttonShow.Checked && this.m_Bitmap != null;
      this.buttonExportImage.Enabled = flag;
      this.buttonFullSize.Enabled = flag;
      this.buttonRemove.Enabled = flag;
      if (!flag)
      {
        this.textSize.Text = string.Empty;
        this.picture.BackgroundImage = (Image) null;
      }
      else
      {
        this.textSize.Text = this.m_Bitmap.Width.ToString() + " x " + this.m_Bitmap.Height.ToString();
        this.picture.BackgroundImage = (Image) this.m_Bitmap;
      }
      this.picture.Enabled = this.buttonShow.Checked;
      this.buttonImportImage.Enabled = true;
    }

    public enum SizeMultiplier
    {
      None,
      OneAndHalf,
      Double,
      Half,
      Kit,
      MiniFace,
      Auto256,
      Free,
    }

    public delegate bool ImageImportHandler(object sender, Bitmap bitmap);

    public delegate bool ImageDeleteHandler(object sender);
  }
}
