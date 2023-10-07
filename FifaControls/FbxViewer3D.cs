// Original code created by Rinaldo

using FifaLibrary;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace FifaControls
{
    public class FbxViewer3D : UserControl
    {
        private IContainer components;
        private int m_ObjectId = -1;
        private string m_FilesPath;
        private string m_XFileMesh;
        private string[] m_Meshes;
        private Bitmap[] m_Textures;
        private Color m_AmbientColor;
        private Process process3dRender;
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);

        protected override void Dispose(bool disposing)
        {
            if (process3dRender != null)
            {
                process3dRender.Kill();
                process3dRender = null;
            }
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FbxViewer3D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.m_AmbientColor = Color.DimGray;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Name = "FbxViewer3D";
            this.Size = new System.Drawing.Size(712, 492);
            this.ResumeLayout(false);

        }

        public Color AmbientColor { get => m_AmbientColor; set => m_AmbientColor = value; }
        public Bitmap[] Textures { get => m_Textures; set => m_Textures = value; }
        public int ObjectId { get => m_ObjectId; set => m_ObjectId = value; }
        public string FilesPath { get => m_FilesPath; set => m_FilesPath = value; }

        public FbxViewer3D()
        {
            this.InitializeComponent();
            this.InitializeGraphics();
        }

        public bool InitializeGraphics()
        {
            return true;
        }

        public void ShowEmpty()
        {
            this.Controls.Clear();
            this.Refresh();
            this.Render();
        }

        public void Render()
        {
            if (process3dRender != null)
            {
                process3dRender.Kill();
                process3dRender = null;
            }

            if (this.m_Textures == null || this.m_ObjectId == -1 || this.m_FilesPath == null)
                return;

            Bitmap[] ballTextures = this.m_Textures;
            Bitmap textureBitmap = (Bitmap)null;
            if (ballTextures != null)
                textureBitmap = GraphicUtil.EmbossBitmap(ballTextures[0], ballTextures[1]);

            textureBitmap.Save(this.m_FilesPath + "_emboss.png", ImageFormat.Png);

            if (textureBitmap == null)
            {
                this.Controls.Clear();
                this.Refresh();
            }
            else
            {
                //Start embedded Unity Application
                process3dRender = new Process();
                process3dRender.StartInfo.FileName = Application.StartupPath + "\\3dRender\\Fbx3dRenderSmall.exe";
                process3dRender.StartInfo.Arguments = "-parentHWND " + this.Handle.ToInt32() + " " + Environment.CommandLine + " ";
                process3dRender.StartInfo.Arguments += "-mesh \"" + this.m_FilesPath + "_mesh.fbx\" ";
                process3dRender.StartInfo.Arguments += "-color \"" + this.m_FilesPath + "_color.png\" ";
                process3dRender.StartInfo.Arguments += "-coeff \"" + this.m_FilesPath + "_coeff.png\" ";
                process3dRender.StartInfo.Arguments += "-normal \"" + this.m_FilesPath + "_normal.png\" ";
                process3dRender.StartInfo.Arguments += "-emboss \"" + this.m_FilesPath + "_emboss.png\" ";
                process3dRender.StartInfo.UseShellExecute = true;
                process3dRender.StartInfo.CreateNoWindow = true;

                process3dRender.Start();
                process3dRender.WaitForInputIdle();

                SetParent(process3dRender.MainWindowHandle, this.Handle);
            }
        }

        public Bitmap Photo()
        {
            try
            {
                RECT rc;
                GetWindowRect(this.Handle, out rc);
                int PW_CLIENTONLY = 0x1; int PW_RENDERFULLCONTENT = 0x2;

                Bitmap bmp = new Bitmap(rc.Width, rc.Height, PixelFormat.Format32bppArgb);
                Graphics gfxBmp = Graphics.FromImage(bmp);
                IntPtr hdcBitmap = gfxBmp.GetHdc();

                PrintWindow(this.Handle, hdcBitmap, PW_CLIENTONLY | PW_RENDERFULLCONTENT);

                gfxBmp.ReleaseHdc(hdcBitmap);
                gfxBmp.Dispose();

                return bmp;
            }
            catch
            {
                return (Bitmap)null;
            }
        }

        public void Clean()
        {
            this.m_FilesPath = null;
            this.m_ObjectId = -1;
            this.m_Textures = null;
            this.m_XFileMesh = null;
            this.m_Meshes = null;
            this.m_AmbientColor = Color.DimGray;

            if (process3dRender != null)
            {
                process3dRender.Kill();
                process3dRender = null;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            private int _Left;
            private int _Top;
            private int _Right;
            private int _Bottom;

            public RECT(RECT Rectangle) : this(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom)
            {
            }
            public RECT(int Left, int Top, int Right, int Bottom)
            {
                _Left = Left;
                _Top = Top;
                _Right = Right;
                _Bottom = Bottom;
            }

            public int X
            {
                get { return _Left; }
                set { _Left = value; }
            }
            public int Y
            {
                get { return _Top; }
                set { _Top = value; }
            }
            public int Left
            {
                get { return _Left; }
                set { _Left = value; }
            }
            public int Top
            {
                get { return _Top; }
                set { _Top = value; }
            }
            public int Right
            {
                get { return _Right; }
                set { _Right = value; }
            }
            public int Bottom
            {
                get { return _Bottom; }
                set { _Bottom = value; }
            }
            public int Height
            {
                get { return _Bottom - _Top; }
                set { _Bottom = value + _Top; }
            }
            public int Width
            {
                get { return _Right - _Left; }
                set { _Right = value + _Left; }
            }
            public Point Location
            {
                get { return new Point(Left, Top); }
                set
                {
                    _Left = value.X;
                    _Top = value.Y;
                }
            }
            public Size Size
            {
                get { return new Size(Width, Height); }
                set
                {
                    _Right = value.Width + _Left;
                    _Bottom = value.Height + _Top;
                }
            }

            public static implicit operator Rectangle(RECT Rectangle)
            {
                return new Rectangle(Rectangle.Left, Rectangle.Top, Rectangle.Width, Rectangle.Height);
            }
            public static implicit operator RECT(Rectangle Rectangle)
            {
                return new RECT(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom);
            }
            public static bool operator ==(RECT Rectangle1, RECT Rectangle2)
            {
                return Rectangle1.Equals(Rectangle2);
            }
            public static bool operator !=(RECT Rectangle1, RECT Rectangle2)
            {
                return !Rectangle1.Equals(Rectangle2);
            }

            public override string ToString()
            {
                return "{Left: " + _Left + "; " + "Top: " + _Top + "; Right: " + _Right + "; Bottom: " + _Bottom + "}";
            }

            public override int GetHashCode()
            {
                return ToString().GetHashCode();
            }

            public bool Equals(RECT Rectangle)
            {
                return Rectangle.Left == _Left && Rectangle.Top == _Top && Rectangle.Right == _Right && Rectangle.Bottom == _Bottom;
            }

            public override bool Equals(object Object)
            {
                if (Object is RECT)
                {
                    return Equals((RECT)Object);
                }
                else if (Object is Rectangle)
                {
                    return Equals(new RECT((Rectangle)Object));
                }

                return false;
            }
        }
    }
}
