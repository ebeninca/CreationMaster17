// Original code created by Rinaldo

using FifaLibrary;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FifaControls
{
    public class Viewer3D : UserControl
    {
        private PresentParameters m_PresentParams = new PresentParameters();
        private float m_ViewY = 100f;
        private float m_ViewZ = 100f;
        private float m_StartViewY = 100f;
        private float m_StartViewZ = 100f;
        private float m_LightY = 100f;
        private float m_LightZ = 100f;
        private float m_RotationYCoeff = 0.01f;
        private IContainer components;
        private Device m_Device;
        private Mesh m_XFileMesh;
        private Mesh[] m_Meshes;
        private Texture[] m_Textures;
        private Material[] m_Materials;
        private ExtendedMaterial[] m_ExtendedMaterials;
        private bool[] m_ZbufferRenderState;
        private bool pause;
        private int m_MouseState;
        private float m_RotationY;
        private float m_RotationX;
        private float m_ViewX;
        private float m_LightDirectionX;
        private float m_LightDirectionY;
        private float m_LightDirectionZ;
        private float m_StartViewX;
        private float m_StartRotationY;
        private float m_StartRotationX;
        private float m_LightX;
        private float m_MinX;
        private float m_MinY;
        private float m_MinZ;
        private float m_MaxX;
        private float m_MaxY;
        private float m_MaxZ;
        private string m_XFileName;
        private string m_XFilePath;
        private Color m_AmbientColor;
        private int m_MouseX;
        private int m_MouseY;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Gray;
            this.BorderStyle = BorderStyle.Fixed3D;
            this.Name = "Viewer3D";
            this.Size = new Size(305, 284);
            this.DoubleClick += new EventHandler(this.Viewer3D_DoubleClick);
            this.MouseDown += new MouseEventHandler(this.Viewer3D_MouseDown);
            this.MouseMove += new MouseEventHandler(this.Viewer3D_MouseMove);
            this.MouseUp += new MouseEventHandler(this.Viewer3D_MouseUp);
            this.ResumeLayout(false);
        }

        public bool[] ZbufferRenderState
        {
            get
            {
                return this.m_ZbufferRenderState;
            }
            set
            {
                this.m_ZbufferRenderState = value;
            }
        }

        public float RotationYCoeff
        {
            get
            {
                return this.m_RotationYCoeff;
            }
            set
            {
                this.m_RotationYCoeff = value;
            }
        }

        public float ViewX
        {
            get
            {
                return this.m_StartViewX;
            }
            set
            {
                this.m_ViewX = value;
                this.m_StartViewX = value;
            }
        }

        public float ViewY
        {
            get
            {
                return this.m_StartViewY;
            }
            set
            {
                this.m_ViewY = value;
                this.m_StartViewY = value;
            }
        }

        public float ViewZ
        {
            get
            {
                return this.m_StartViewZ;
            }
            set
            {
                this.m_ViewZ = value;
                this.m_StartViewZ = value;
            }
        }

        public float RotationX
        {
            get
            {
                return this.m_StartRotationX;
            }
            set
            {
                this.m_RotationX = value;
                this.m_StartRotationX = value;
            }
        }

        public float RotationY
        {
            get
            {
                return this.m_StartRotationY;
            }
            set
            {
                this.m_RotationY = value;
                this.m_StartRotationY = value;
            }
        }

        public float LightDirectionZ
        {
            get
            {
                return this.m_LightDirectionZ;
            }
            set
            {
                this.m_LightDirectionZ = value;
            }
        }

        public float LightDirectionY
        {
            get
            {
                return this.m_LightDirectionY;
            }
            set
            {
                this.m_LightDirectionY = value;
            }
        }

        public float LightDirectionX
        {
            get
            {
                return this.m_LightDirectionX;
            }
            set
            {
                this.m_LightDirectionX = value;
            }
        }

        public float LightX
        {
            get
            {
                return this.m_LightX;
            }
            set
            {
                this.m_LightX = value;
            }
        }

        public float LightY
        {
            get
            {
                return this.m_LightY;
            }
            set
            {
                this.m_LightY = value;
            }
        }

        public float LightZ
        {
            get
            {
                return this.m_LightZ;
            }
            set
            {
                this.m_LightZ = value;
            }
        }

        public Color AmbientColor
        {
            get
            {
                return this.m_AmbientColor;
            }
            set
            {
                this.m_AmbientColor = value;
            }
        }

        public Viewer3D()
        {
            this.InitializeComponent();
            if (this.InitializeHardwareGraphics())
                return;
            this.InitializeSoftwareGraphics();
        }

        public bool InitializeHardwareGraphics()
        {
            try
            {
                this.m_PresentParams.Windowed = true;
                this.m_PresentParams.SwapEffect = SwapEffect.Discard;
                this.m_PresentParams.EnableAutoDepthStencil = true;
                this.m_PresentParams.AutoDepthStencilFormat = DepthFormat.D16;
                this.m_Device = new Device(0, DeviceType.Hardware, (Control)this, CreateFlags.HardwareVertexProcessing, new PresentParameters[1]
                {
          this.m_PresentParams
                });
                this.m_Device.DeviceReset += new EventHandler(this.OnResetDevice);
                this.OnResetDevice((object)this.m_Device, (EventArgs)null);
                this.pause = false;
            }
            catch (DirectXException ex)
            {
                return false;
            }
            return true;
        }

        public bool InitializeSoftwareGraphics()
        {
            try
            {
                this.m_PresentParams.Windowed = true;
                this.m_PresentParams.SwapEffect = SwapEffect.Discard;
                this.m_PresentParams.EnableAutoDepthStencil = true;
                this.m_PresentParams.AutoDepthStencilFormat = DepthFormat.D16;
                this.m_Device = new Device(0, DeviceType.Hardware, (Control)this, CreateFlags.SoftwareVertexProcessing | CreateFlags.FpuPreserve, new PresentParameters[1]
                {
          this.m_PresentParams
                });
                this.m_Device.DeviceReset += new EventHandler(this.OnResetDevice);
                this.OnResetDevice((object)this.m_Device, (EventArgs)null);
                this.pause = false;
            }
            catch (DirectXException ex)
            {
                return false;
            }
            return true;
        }

        public void ShowEmpty()
        {
            this.m_Materials = (Material[])null;
            this.Render();
        }

        public void Show3D(string xFileName)
        {
            try
            {
                this.m_XFileName = Path.GetFileName(xFileName);
                this.m_XFilePath = Path.GetDirectoryName(xFileName);
                string currentDirectory = Environment.CurrentDirectory;
                Directory.SetCurrentDirectory(this.m_XFilePath);
                if (this.m_XFileMesh != (Mesh)null)
                    this.m_XFileMesh.Dispose();
                if (this.m_ExtendedMaterials != null && this.m_Textures != null)
                {
                    for (int index = 0; index < this.m_ExtendedMaterials.Length; ++index)
                    {
                        if (this.m_Textures[index] != (Texture)null)
                            this.m_Textures[index].Dispose();
                    }
                }
                this.m_XFileMesh = Mesh.FromFile(this.m_XFileName, MeshFlags.Managed, this.m_Device, out this.m_ExtendedMaterials);
                this.m_Textures = new Texture[this.m_ExtendedMaterials.Length];
                this.m_Materials = new Material[this.m_ExtendedMaterials.Length];
                for (int index = 0; index < this.m_ExtendedMaterials.Length; ++index)
                {
                    this.m_Materials[index] = this.m_ExtendedMaterials[index].Material3D;
                    this.m_Materials[index].Ambient = this.m_Materials[index].Diffuse;
                    if (this.m_Textures[index] != (Texture)null)
                        this.m_Textures[index].Dispose();
                    this.m_Textures[index] = TextureLoader.FromFile(this.m_Device, this.m_ExtendedMaterials[index].TextureFilename);
                }
                this.Render();
                Directory.SetCurrentDirectory(currentDirectory);
            }
            catch (DirectXException ex)
            {
                this.m_Materials = (Material[])null;
                this.m_Textures = (Texture[])null;
                this.Render();
            }
        }

        public void Show3D(Bitmap bitmap, int partIndex)
        {
            if (partIndex < 0)
                return;
            if (partIndex >= this.m_Textures.Length)
                return;
            try
            {
                this.m_Textures[partIndex] = Texture.FromBitmap(this.m_Device, bitmap, Usage.Points, Pool.Default);
                this.m_Textures[partIndex].Dispose();
                this.Render();
            }
            catch (DirectXException ex)
            {
                this.m_Materials = (Material[])null;
                this.m_Textures = (Texture[])null;
                this.Render();
            }
        }

        public void Show3D(Bitmap bitmap)
        {
            try
            {
                Texture texture = new Texture(this.m_Device, bitmap, Usage.RenderTarget, Pool.Managed);
                for (int index = 0; index < this.m_Textures.Length; ++index)
                    this.m_Textures[index] = texture;
                this.Render();
            }
            catch (DirectXException ex)
            {
                this.m_Materials = (Material[])null;
                this.m_Textures = (Texture[])null;
                this.Render();
            }
        }

        private void OnResetDevice(object sender, EventArgs e)
        {
            this.m_Device.RenderState.ZBufferEnable = true;
            this.m_Device.RenderState.ZBufferFunction = Compare.Less;
            this.m_Device.RenderState.ZBufferWriteEnable = true;
            this.m_Device.RenderState.AlphaBlendEnable = true;
            this.m_Device.RenderState.AlphaTestEnable = false;
            this.m_Device.RenderState.AlphaFunction = Compare.Always;
            this.m_Device.RenderState.BlendOperation = BlendOperation.Add;
            this.m_Device.RenderState.SourceBlend = Blend.SourceAlpha;
            this.m_Device.RenderState.DestinationBlend = Blend.InvSourceAlpha;
            this.m_Device.RenderState.AlphaBlendOperation = BlendOperation.Max;
            this.m_Device.RenderState.AlphaSourceBlend = Blend.One;
            this.m_Device.RenderState.AlphaDestinationBlend = Blend.One;
            this.m_Device.RenderState.StencilEnable = false;
            this.m_Device.RenderState.FillMode = FillMode.Solid;
            this.m_Device.RenderState.CullMode = Cull.None;
            this.m_Device.RenderState.SpecularEnable = false;
            this.m_Device.RenderState.SpecularMaterialSource = ColorSource.Material;
            this.m_Device.RenderState.Ambient = this.m_AmbientColor;
            this.m_Device.Lights[0].Type = LightType.Directional;
            this.m_Device.Lights[0].Position = new Vector3(this.m_LightX, this.m_LightY, this.m_LightZ);
            this.m_Device.Lights[0].Diffuse = Color.White;
            this.m_Device.Lights[0].Direction = new Vector3(this.m_LightDirectionX, this.m_LightDirectionY, this.m_LightDirectionZ);
            this.m_Device.Lights[0].Enabled = true;
            this.m_Device.RenderState.Lighting = true;
        }

        private void SetupMatrices()
        {
            this.m_Device.Transform.World = Matrix.RotationYawPitchRoll(this.m_RotationY, this.m_RotationX, 0.0f);
            this.m_Device.Transform.View = Matrix.LookAtLH(new Vector3(this.m_ViewX, this.m_ViewY, this.m_ViewZ), new Vector3(this.m_ViewX, this.m_ViewY, 0.0f), new Vector3(0.0f, 1f, 0.0f));
            this.m_Device.Transform.Projection = Matrix.PerspectiveFovLH(0.7853982f, (float)this.Width / (float)this.Height, 1f, 1000f);
        }

        public void Render()
        {
            if (this.m_Device == (Device)null)
                return;
            if (this.pause)
                return;
            try
            {
                this.m_Device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Gray, 1f, 0);
                this.m_Device.Lights[0].Type = LightType.Directional;
                this.m_Device.Lights[0].Position = new Vector3(this.m_LightX, this.m_LightY, this.m_LightZ);
                this.m_Device.Lights[0].Diffuse = Color.White;
                this.m_Device.Lights[0].Direction = new Vector3(this.m_LightDirectionX, this.m_LightDirectionY, this.m_LightDirectionZ);
                this.m_Device.Lights[0].Enabled = true;
                this.m_Device.RenderState.Ambient = this.m_AmbientColor;
                this.m_Device.BeginScene();
                this.SetupMatrices();
                this.m_Device.SetSamplerState(0, SamplerStageStates.MinFilter, (int)Filter.Linear);
                this.m_Device.SetSamplerState(0, SamplerStageStates.MagFilter, (int)Filter.Linear);
                this.m_Device.SetSamplerState(0, SamplerStageStates.MipFilter, (int)Filter.Linear);
                if (this.m_XFileMesh != (Mesh)null && this.m_Materials != null)
                {
                    this.m_Device.RenderState.ZBufferWriteEnable = true;
                    for (int index = 0; index < this.m_Materials.Length; ++index)
                    {
                        int attributeID = index;
                        this.m_Device.Material = this.m_Materials[attributeID];
                        this.m_Device.SetTexture(0, (BaseTexture)this.m_Textures[attributeID]);
                        if (this.m_Materials.Length == 6 && (index == 4 || index == 5))
                            this.m_Device.RenderState.ZBufferWriteEnable = false;
                        this.m_XFileMesh.DrawSubset(attributeID);
                    }
                }
                if (this.m_Meshes != null && this.m_Materials != null)
                {
                    for (int index = 0; index < this.m_Meshes.Length; ++index)
                    {
                        this.m_Device.RenderState.ZBufferWriteEnable = this.m_ZbufferRenderState[index];
                        if (this.m_Meshes[index] != (Mesh)null)
                        {
                            this.m_Device.Material = this.m_Materials[index];
                            this.m_Device.SetTexture(0, (BaseTexture)this.m_Textures[index]);
                            
                            this.m_Meshes[index].DrawSubset(0);
                        }
                    }
                }
                this.m_Device.EndScene();
                this.m_Device.Present();
            }
            catch (DirectXException ex)
            {
            }
        }

        private void Viewer3D_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    this.m_MouseState = 1;
                    this.m_MouseX = e.X;
                    this.m_MouseY = e.Y;
                    break;
                case MouseButtons.Right:
                    this.m_MouseState = 2;
                    this.m_MouseX = e.X;
                    this.m_MouseY = e.Y;
                    break;
                case MouseButtons.Middle:
                    this.m_MouseState = 4;
                    this.m_MouseX = e.X;
                    this.m_MouseY = e.Y;
                    break;
            }
            this.Render();
        }

        private void Viewer3D_MouseUp(object sender, MouseEventArgs e)
        {
            this.m_MouseState = 0;
        }

        private void Viewer3D_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.m_MouseState == 0)
            {
                int delta = e.Delta;
            }
            else
            {
                bool flag = false;
                switch (this.m_MouseState)
                {
                    case 0:
                        return;
                    case 1:
                        int num1 = e.X - this.m_MouseX;
                        int num2 = e.Y - this.m_MouseY;
                        this.m_RotationY -= (float)num1 * 0.01f;
                        while ((double)this.m_RotationY < 0.0)
                            this.m_RotationY += 6.28f;
                        while ((double)this.m_RotationY > 6.28000020980835)
                            this.m_RotationY -= 6.28f;
                        this.m_RotationX += (float)num2 * this.m_RotationYCoeff;
                        while ((double)this.m_RotationX < 0.0)
                            this.m_RotationX += 6.28f;
                        while ((double)this.m_RotationX > 6.28000020980835)
                            this.m_RotationX -= 6.28f;
                        flag = true;
                        break;
                    case 2:
                        int num3 = e.X - this.m_MouseX;
                        this.m_ViewZ -= (float)(e.Y - this.m_MouseY) * 0.2f;
                        if ((double)this.m_ViewZ < -1000.0)
                            this.m_ViewZ = -1000f;
                        if ((double)this.m_ViewZ > 1000.0)
                            this.m_ViewZ = 1000f;
                        flag = true;
                        break;
                    case 4:
                        int num4 = e.X - this.m_MouseX;
                        int num5 = e.Y - this.m_MouseY;
                        this.m_ViewX += (float)num4 * 0.2f;
                        if ((double)this.m_ViewX < -1000.0)
                            this.m_ViewX = -1000f;
                        if ((double)this.m_ViewX > 1000.0)
                            this.m_ViewX = 1000f;
                        this.m_ViewY += (float)num5 * 0.2f;
                        if ((double)this.m_ViewY < -1000.0)
                            this.m_ViewY = -1000f;
                        if ((double)this.m_ViewY > 1000.0)
                            this.m_ViewY = 1000f;
                        flag = true;
                        break;
                }
                this.m_MouseX = e.X;
                this.m_MouseY = e.Y;
                if (!flag)
                    return;
                this.Render();
            }
        }

        private void Viewer3D_DoubleClick(object sender, EventArgs e)
        {
            this.m_RotationY = this.m_StartRotationY;
            this.m_RotationX = this.m_StartRotationX;
            this.m_ViewX = this.m_StartViewX;
            this.m_ViewY = this.m_StartViewY;
            this.m_ViewZ = this.m_StartViewZ;
            this.Render();
        }

        public Bitmap Photo()
        {
            try
            {
                Surface backBuffer = this.m_Device.GetBackBuffer(0, 0, BackBufferType.Mono);
                Bitmap bitmap = new Bitmap((Stream)SurfaceLoader.SaveToStream(ImageFileFormat.Bmp, backBuffer));
                backBuffer.Dispose();
                return bitmap;
            }
            catch
            {
                return (Bitmap)null;
            }
        }

        public void Clean(int nMeshes)
        {
            if (this.m_XFileMesh != (Mesh)null)
            {
                this.m_XFileMesh.Dispose();
                this.m_XFileMesh = (Mesh)null;
            }
            if (this.m_Textures != null)
            {
                for (int index = 0; index < this.m_Textures.Length; ++index)
                {
                    if (this.m_Textures[index] != (Texture)null)
                        this.m_Textures[index].Dispose();
                }
                this.m_Textures = (Texture[])null;
            }
            if (this.m_Meshes != null)
            {
                for (int index = 0; index < this.m_Meshes.Length; ++index)
                {
                    if (this.m_Meshes[index] != (Mesh)null)
                        this.m_Meshes[index].Dispose();
                }
            }
            this.m_Meshes = new Mesh[nMeshes];
            if (nMeshes != 0)
            {
                this.m_Textures = new Texture[nMeshes];
                this.m_Materials = new Material[nMeshes];
                this.m_ZbufferRenderState = new bool[nMeshes];
                for (int index = 0; index < nMeshes; ++index)
                {
                    this.m_ZbufferRenderState[index] = true;
                    this.m_Materials[index].Ambient = Color.FromArgb(0, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                    this.m_Materials[index].Diffuse = Color.FromArgb(0, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                    this.m_Materials[index].Specular = Color.FromArgb(0, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                }
            }
            this.CleanBoundingBox();
        }

        public void SetMesh(int meshIndex, Model3D model3D)
        {
            this.SetMesh(meshIndex, model3D, true);
        }

        public void SetMesh(int meshIndex, Model3D model3D, bool zBufferState)
        {
            try
            {
                this.UpdateBoundingBox(model3D.Vertex);
                this.m_Meshes[meshIndex] = new Mesh(model3D.NFaces, model3D.NVertex, MeshFlags.Managed, VertexFormats.PositionNormal | VertexFormats.Texture1, this.m_Device);
                this.m_Meshes[meshIndex].SetIndexBufferData((object)model3D.Index, LockFlags.None);
                this.m_Meshes[meshIndex].SetVertexBufferData((object)model3D.Vertex, LockFlags.None);
                Texture texture = Texture.FromBitmap(this.m_Device, model3D.TextureBitmap, Usage.None, Pool.Managed);
                this.m_Textures[meshIndex] = texture;
                this.m_ZbufferRenderState[meshIndex] = zBufferState;
            }
            catch
            {
            }
        }

        private void UpdateBoundingBox(CustomVertex.PositionNormalTextured[] Vertex)
        {
            for (int index = 0; index < Vertex.Length; ++index)
            {
                if ((double)Vertex[index].X < (double)this.m_MinX)
                    this.m_MinX = Vertex[index].X;
                if ((double)Vertex[index].X > (double)this.m_MaxX)
                    this.m_MaxX = Vertex[index].X;
                if ((double)Vertex[index].Y < (double)this.m_MinY)
                    this.m_MinY = Vertex[index].Y;
                if ((double)Vertex[index].Y > (double)this.m_MaxY)
                    this.m_MaxY = Vertex[index].Y;
                if ((double)Vertex[index].Z < (double)this.m_MinZ)
                    this.m_MinZ = Vertex[index].Z;
                if ((double)Vertex[index].Z > (double)this.m_MaxZ)
                    this.m_MaxZ = Vertex[index].Z;
            }
        }

        private void CleanBoundingBox()
        {
            this.m_MinX = float.MaxValue;
            this.m_MinY = float.MaxValue;
            this.m_MinZ = float.MaxValue;
            this.m_MaxX = float.MinValue;
            this.m_MaxY = float.MinValue;
            this.m_MaxZ = float.MinValue;
        }

        private void AutoView()
        {
            this.m_ViewX = (float)(((double)this.m_MinX + (double)this.m_MaxX) / 2.0);
            this.m_ViewY = (float)(((double)this.m_MinY + (double)this.m_MaxY) / 2.0);
            this.m_ViewZ = this.m_MaxZ * 3f;
        }
    }
}
