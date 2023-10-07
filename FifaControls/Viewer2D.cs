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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Viewer2D));
            this.picture = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.importImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.buttonShow = new System.Windows.Forms.ToolStripButton();
            this.buttonImportImage = new System.Windows.Forms.ToolStripButton();
            this.buttonExportImage = new System.Windows.Forms.ToolStripButton();
            this.buttonFullSize = new System.Windows.Forms.ToolStripButton();
            this.buttonRemove = new System.Windows.Forms.ToolStripButton();
            this.textSize = new System.Windows.Forms.ToolStripTextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // picture
            // 
            this.picture.BackColor = System.Drawing.SystemColors.Control;
            this.picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture.ContextMenuStrip = this.contextMenuStrip;
            this.picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picture.Location = new System.Drawing.Point(0, 0);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(197, 187);
            this.picture.TabIndex = 0;
            this.picture.TabStop = false;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importImageToolStripMenuItem,
            this.exportImageToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(147, 70);
            // 
            // importImageToolStripMenuItem
            // 
            this.importImageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("importImageToolStripMenuItem.Image")));
            this.importImageToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.importImageToolStripMenuItem.Name = "importImageToolStripMenuItem";
            this.importImageToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.importImageToolStripMenuItem.Text = "Import Image";
            this.importImageToolStripMenuItem.Click += new System.EventHandler(this.buttonImportImage_Click);
            // 
            // exportImageToolStripMenuItem
            // 
            this.exportImageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportImageToolStripMenuItem.Image")));
            this.exportImageToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.exportImageToolStripMenuItem.Name = "exportImageToolStripMenuItem";
            this.exportImageToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exportImageToolStripMenuItem.Text = "Export Image";
            this.exportImageToolStripMenuItem.Click += new System.EventHandler(this.buttonExportImage_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removeToolStripMenuItem.Image")));
            this.removeToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonShow,
            this.buttonImportImage,
            this.buttonExportImage,
            this.buttonFullSize,
            this.buttonRemove,
            this.textSize});
            this.toolStrip.Location = new System.Drawing.Point(0, 187);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(197, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            // 
            // buttonShow
            // 
            this.buttonShow.Checked = true;
            this.buttonShow.CheckOnClick = true;
            this.buttonShow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.buttonShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonShow.Image = ((System.Drawing.Image)(resources.GetObject("buttonShow.Image")));
            this.buttonShow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(23, 22);
            this.buttonShow.Text = "Show / Hide";
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // buttonImportImage
            // 
            this.buttonImportImage.AutoSize = false;
            this.buttonImportImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonImportImage.Image = ((System.Drawing.Image)(resources.GetObject("buttonImportImage.Image")));
            this.buttonImportImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonImportImage.Name = "buttonImportImage";
            this.buttonImportImage.Size = new System.Drawing.Size(20, 22);
            this.buttonImportImage.Text = "Import Image";
            this.buttonImportImage.Click += new System.EventHandler(this.buttonImportImage_Click);
            // 
            // buttonExportImage
            // 
            this.buttonExportImage.AutoSize = false;
            this.buttonExportImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonExportImage.Image = ((System.Drawing.Image)(resources.GetObject("buttonExportImage.Image")));
            this.buttonExportImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonExportImage.Name = "buttonExportImage";
            this.buttonExportImage.Size = new System.Drawing.Size(20, 22);
            this.buttonExportImage.Text = "Export Image";
            this.buttonExportImage.Click += new System.EventHandler(this.buttonExportImage_Click);
            // 
            // buttonFullSize
            // 
            this.buttonFullSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonFullSize.Image = ((System.Drawing.Image)(resources.GetObject("buttonFullSize.Image")));
            this.buttonFullSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonFullSize.Name = "buttonFullSize";
            this.buttonFullSize.Size = new System.Drawing.Size(23, 22);
            this.buttonFullSize.Text = "View Full Size";
            this.buttonFullSize.Visible = false;
            this.buttonFullSize.Click += new System.EventHandler(this.buttonFullSize_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.AutoSize = false;
            this.buttonRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRemove.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemove.Image")));
            this.buttonRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(20, 22);
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.Visible = false;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // textSize
            // 
            this.textSize.BackColor = System.Drawing.Color.White;
            this.textSize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textSize.Name = "textSize";
            this.textSize.ReadOnly = true;
            this.textSize.Size = new System.Drawing.Size(65, 25);
            this.textSize.Text = "1024 x 1024";
            this.textSize.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Viewer2D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.picture);
            this.Controls.Add(this.toolStrip);
            this.Name = "Viewer2D";
            this.Size = new System.Drawing.Size(197, 212);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
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
