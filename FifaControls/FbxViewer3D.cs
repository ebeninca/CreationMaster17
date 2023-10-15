// Original code created by Rinaldo

using FifaLibrary;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Pipes;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FifaControls
{
    public class FbxViewer3D : UserControl
    {
        private IContainer components;
        private int m_ObjectId = -1;
        private string m_FilesPath;
        private ObjectTypeServerPort m_ObjectType;
        private string m_XFileMesh;
        private string[] m_Meshes;
        private Bitmap[] m_Textures;
        private Color m_AmbientColor;

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        [DllImport("user32.dll")]
        internal static extern bool EnumChildWindows(IntPtr hwnd, WindowEnumProc func, IntPtr lParam);

        internal delegate int WindowEnumProc(IntPtr hwnd, IntPtr lparam);
        private Process process3dRender;
        private IntPtr _unityHWND = IntPtr.Zero;

        private readonly int PW_CLIENTONLY = 0x1;
        private readonly int PW_RENDERFULLCONTENT = 0x2;

        public Color AmbientColor { get => m_AmbientColor; set => m_AmbientColor = value; }
        public Bitmap[] Textures { get => m_Textures; set => m_Textures = value; }
        public int ObjectId { get => m_ObjectId; set => m_ObjectId = value; }
        public ObjectTypeServerPort ObjectType { get => m_ObjectType; set => m_ObjectType = value; }
        public string FilesPath { get => m_FilesPath; set => m_FilesPath = value; }

        private NamedPipeClientStream clientStream;

        public FbxViewer3D()
        {
            this.InitializeComponent();
            this.InitializeGraphics();
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
            this.m_AmbientColor = System.Drawing.Color.Gray;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Name = "FbxViewer3D";
            this.Size = new System.Drawing.Size(774, 416);
            this.Resize += new System.EventHandler(this.Resize3DWindow);
            this.ResumeLayout(false);

        }

        public bool InitializeGraphics()
        {
            return true;
        }

        public void ShowEmpty()
        {
            if (process3dRender != null)
            {
                CloseConnection();
                process3dRender.Kill();
                process3dRender = null;
            }

            this.Controls.Clear();
            this.Refresh();
        }

        public void Render()
        {

            if (this.m_Textures == null || this.m_ObjectId == -1 || this.m_FilesPath == null)
                return;

            Bitmap textureBitmap = (Bitmap)null;
            textureBitmap = GraphicUtil.EmbossBitmap(this.m_Textures[0], this.m_Textures[1]);
            textureBitmap.Save(this.m_FilesPath + "_emboss.png", ImageFormat.Png);

            if (textureBitmap == null)
            {
                this.Controls.Clear();
                this.Refresh();
                return;
            }

            if (process3dRender == null)
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
                //ask to start the TCPServer for future communications to render objects
                process3dRender.StartInfo.Arguments += "-runServer " + (int)this.ObjectType + " ";

                process3dRender.StartInfo.UseShellExecute = true;
                process3dRender.StartInfo.CreateNoWindow = false;
                process3dRender.StartInfo.WindowStyle = ProcessWindowStyle.Normal;

                process3dRender.Start();
                process3dRender.WaitForInputIdle();

                SetParent(process3dRender.MainWindowHandle, this.Handle);
                //needed to make the screen resize work correclty
                EnumChildWindows(this.Handle, WindowEnum, IntPtr.Zero);
            }
            else
            {
                //reusing the same process just sending a new message
                ConnectTcpServer();
                SendMessage();
            }
        }

        private int WindowEnum(IntPtr hwnd, IntPtr lparam)
        {
            _unityHWND = hwnd;
            return 0;
        }

        private TcpClient client;
        private NetworkStream stream;

        private void ConnectTcpServer()
        {
            if (client == null)
            {
                client = new TcpClient("localhost", (int)this.ObjectType);
            }
            stream = client.GetStream();
        }

        private void SendMessage()
        {
            string data = "-mesh \"" + this.m_FilesPath + "_mesh.fbx\" ";
            data += "-color \"" + this.m_FilesPath + "_color.png\" ";
            data += "-coeff \"" + this.m_FilesPath + "_coeff.png\" ";
            data += "-normal \"" + this.m_FilesPath + "_normal.png\" ";
            data += "-emboss \"" + this.m_FilesPath + "_emboss.png\" ";

            byte[] messageBytes = Encoding.UTF8.GetBytes(data);
            stream.Write(messageBytes, 0, messageBytes.Length);

            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            Console.WriteLine("TCP RESPONSE >>>" + response);
        }

        private void CloseConnection()
        {
            client?.Close();
            client = null;
        }

        public Bitmap Photo()
        {
            try
            {
                RECT rc = new RECT();
                GetWindowRect(this.Handle, ref rc);

                int width = rc.Right - rc.Left;
                int height = rc.Bottom - rc.Top;
                Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
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

        private void Resize3DWindow(object sender, EventArgs e)
        {
            this.Resize3DWindow();
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public void Resize3DWindow()
        {
            if (process3dRender != null)
            {
                process3dRender.Refresh();
                bool success = MoveWindow(_unityHWND, 0, 0, this.Width, this.Height, true);
                if (!success)
                {
                    int err = Marshal.GetLastWin32Error();
                    Console.WriteLine("ERROR CODE >> " + err);
                    return;
                }
            }
        }

        public void Clean()
        {
            this.m_FilesPath = null;
            this.m_ObjectId = -1;
            this.m_Textures = null;
            this.m_XFileMesh = null;
            this.m_Meshes = null;
            this.BackColor = System.Drawing.Color.Gray;
            this.m_AmbientColor = System.Drawing.Color.Gray;

            if (process3dRender != null)
            {
                process3dRender.Kill();
                process3dRender = null;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (process3dRender != null)
            {
                CloseConnection();
                process3dRender.Kill();
                process3dRender = null;
            }
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        public enum ObjectTypeServerPort : Int16
        {
            Ball = 7779,
            Kit = 7778,
            Shoe = 7777,
            Face = 7776,
            Referee = 7775,
            Manager = 7774,
            Glove = 7773
        }
    }
}
