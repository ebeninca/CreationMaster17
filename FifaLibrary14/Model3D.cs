// Original code created by Rinaldo

using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace FifaLibrary
{
  public class Model3D
  {
    private string m_TextureFileName;
    private Bitmap m_TextureBitmap;
    private int m_NVertex;
    private int m_NOriginalVertex;
    private int m_NIndex;
    private int m_NOriginalIndex;
    private bool m_IsTriangleList;
    private CustomVertex.PositionNormalTextured[] m_Vertex;
    private int[] m_Unknown;
    private short[] m_Index;
    private short[] m_IndexStream;
    private int m_NFaces;

    public string TextureFileName
    {
      set
      {
        this.m_TextureFileName = value;
      }
      get
      {
        return this.m_TextureFileName;
      }
    }

    public Bitmap TextureBitmap
    {
      set
      {
        this.m_TextureBitmap = value;
      }
      get
      {
        return this.m_TextureBitmap;
      }
    }

    public int NVertex
    {
      get
      {
        return this.m_NVertex;
      }
    }

    public int NIndex
    {
      get
      {
        return this.m_NIndex;
      }
    }

    public CustomVertex.PositionNormalTextured[] Vertex
    {
      get
      {
        return this.m_Vertex;
      }
    }

    public short[] Index
    {
      get
      {
        return this.m_Index;
      }
    }

    public int NFaces
    {
      get
      {
        return this.m_NFaces;
      }
    }

    public Model3D()
    {
    }

    public Model3D(Rx3IndexArray indexArray, Rx3VertexArray vertexArray)
    {
      this.Initialize(indexArray, vertexArray);
    }

    public Model3D(Rx3IndexArray indexArray, Rx3VertexArray vertexArray, Bitmap textureBitmap)
    {
      this.Initialize(indexArray, vertexArray);
      this.m_TextureBitmap = textureBitmap;
    }

    public void Initialize(Rx3IndexArray indexArray, Rx3VertexArray vertexArray)
    {
      this.SetVertexArray(vertexArray);
      this.SetIndexArray(indexArray);
      this.ComputeNormals();
    }

    private void SetIndexArray(Rx3IndexArray indexArray)
    {
      this.m_NIndex = indexArray.NIndex;
      this.m_NOriginalIndex = this.m_NIndex;
      this.m_IndexStream = indexArray.IndexStream;
      this.m_NFaces = indexArray.nFaces;
      this.m_IsTriangleList = indexArray.IsTriangleList;
      if (!this.m_IsTriangleList)
      {
        this.m_Index = new short[this.m_NIndex];
        for (int index = 0; index < this.m_NIndex; index += 3)
        {
          this.m_Index[index] = this.m_IndexStream[index];
          this.m_Index[index + 1] = this.m_IndexStream[index + 1];
          this.m_Index[index + 2] = this.m_IndexStream[index + 2];
        }
      }
      else
      {
        this.m_Index = new short[this.m_NFaces * 3];
        int num1 = 0;
        int num2 = Rx3IndexArray.TriangleListType == Rx3IndexArray.ETriangleListType.InvertOdd ? 1 : 0;
        for (int index1 = 0; index1 < this.m_NIndex - 2; ++index1)
        {
          short num3 = this.m_IndexStream[index1];
          short num4 = this.m_IndexStream[index1 + 1];
          short num5 = this.m_IndexStream[index1 + 2];
          if ((int) num3 <= this.m_NVertex && (int) num4 <= this.m_NVertex && ((int) num5 <= this.m_NVertex && num3 >= (short) 0) && (num4 >= (short) 0 && num5 >= (short) 0))
          {
            if ((int) num3 != (int) num4 && (int) num4 != (int) num5 && (int) num3 != (int) num5)
            {
              if ((index1 & 1) == num2)
              {
                short[] index2 = this.m_Index;
                int index3 = num1;
                int num6 = index3 + 1;
                int num7 = (int) num3;
                index2[index3] = (short) num7;
                short[] index4 = this.m_Index;
                int index5 = num6;
                int num8 = index5 + 1;
                int num9 = (int) num4;
                index4[index5] = (short) num9;
                short[] index6 = this.m_Index;
                int index7 = num8;
                num1 = index7 + 1;
                int num10 = (int) num5;
                index6[index7] = (short) num10;
              }
              else
              {
                short[] index2 = this.m_Index;
                int index3 = num1;
                int num6 = index3 + 1;
                int num7 = (int) num3;
                index2[index3] = (short) num7;
                short[] index4 = this.m_Index;
                int index5 = num6;
                int num8 = index5 + 1;
                int num9 = (int) num5;
                index4[index5] = (short) num9;
                short[] index6 = this.m_Index;
                int index7 = num8;
                num1 = index7 + 1;
                int num10 = (int) num4;
                index6[index7] = (short) num10;
              }
            }
          }
          else
            break;
        }
        this.m_NIndex = this.m_NFaces * 3;
      }
    }

    private void SetVertexArray(Rx3VertexArray vertexArray)
    {
      this.m_NVertex = vertexArray.nVertex;
      this.m_NOriginalVertex = this.m_NVertex;
      this.m_Vertex = new CustomVertex.PositionNormalTextured[this.m_NVertex];
      for (int index = 0; index < this.m_NVertex; ++index)
      {
        this.m_Vertex[index].X = vertexArray.Vertexes[index].X;
        this.m_Vertex[index].Y = vertexArray.Vertexes[index].Y;
        this.m_Vertex[index].Z = vertexArray.Vertexes[index].Z;
        this.m_Vertex[index].Tu = vertexArray.Vertexes[index].U;
        this.m_Vertex[index].Tv = vertexArray.Vertexes[index].V;
      }
    }

    public Model3D Clone()
    {
      Model3D model3D = (Model3D) this.MemberwiseClone();
      model3D.m_Index = (short[]) this.m_Index.Clone();
      model3D.m_IndexStream = (short[]) this.m_IndexStream.Clone();
      model3D.m_Unknown = (int[]) this.m_Unknown.Clone();
      model3D.m_Vertex = (CustomVertex.PositionNormalTextured[]) this.m_Vertex.Clone();
      return model3D;
    }

    private void ComputeNormals()
    {
      Vector3[] vector3Array = new Vector3[this.m_NVertex];
      int[] numArray = new int[this.m_NVertex];
      for (int index1 = 0; index1 < this.m_NFaces; ++index1)
      {
        int index2 = (int) this.m_Index[index1 * 3];
        int index3 = (int) this.m_Index[index1 * 3 + 1];
        int index4 = (int) this.m_Index[index1 * 3 + 2];
        Vector3 right1 = new Vector3(this.m_Vertex[index2].X, this.m_Vertex[index2].Y, this.m_Vertex[index2].Z);
        Vector3 left1 = new Vector3(this.m_Vertex[index3].X, this.m_Vertex[index3].Y, this.m_Vertex[index3].Z);
        Vector3 left2 = new Vector3(this.m_Vertex[index4].X, this.m_Vertex[index4].Y, this.m_Vertex[index4].Z);
        Vector3 right2 = Vector3.Subtract(left1, right1);
        Vector3 right3 = Vector3.Normalize(Vector3.Cross(Vector3.Subtract(left2, right1), right2));
        vector3Array[index2] = Vector3.Add(vector3Array[index2], right3);
        vector3Array[index3] = Vector3.Add(vector3Array[index3], right3);
        vector3Array[index4] = Vector3.Add(vector3Array[index4], right3);
        ++numArray[index2];
        ++numArray[index3];
        ++numArray[index4];
      }
      for (int index = 0; index < this.m_NVertex; ++index)
      {
        Vector3 vector3 = Vector3.Scale(vector3Array[index], 1f / (float) numArray[index]);
        this.m_Vertex[index].Nx = vector3.X;
        this.m_Vertex[index].Ny = vector3.Y;
        this.m_Vertex[index].Nz = vector3.Z;
      }
    }

    public bool CanMerge(Model3D model)
    {
      return model == null || this.m_NOriginalVertex >= model.NVertex && this.m_NOriginalIndex >= model.NIndex;
    }

    public static bool CanMorphing(Model3D model1, Model3D model2)
    {
      return model1 != null && model2 != null && model1.NVertex == model2.NVertex;
    }

    public bool CanMorphing(Model3D model2)
    {
      return Model3D.CanMorphing(this, model2);
    }

    public bool Merge(Model3D model)
    {
      if (!this.CanMerge(model))
        return false;
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      if (model != null)
      {
        num1 = model.NVertex;
        num2 = model.NIndex;
        num3 = model.NFaces;
      }
      for (int index = num1; index < this.m_NVertex; ++index)
      {
        this.m_Vertex[index].X = 0.0f;
        this.m_Vertex[index].Y = 0.0f;
        this.m_Vertex[index].Z = 0.0f;
        this.m_Vertex[index].Nx = 0.0f;
        this.m_Vertex[index].Ny = 0.0f;
        this.m_Vertex[index].Nz = 0.0f;
        this.m_Vertex[index].Tu = 0.0f;
        this.m_Vertex[index].Tv = 0.0f;
      }
      this.m_NVertex = num1;
      for (int index = 0; index < this.m_NVertex; ++index)
      {
        this.m_Vertex[index].X = model.Vertex[index].X;
        this.m_Vertex[index].Y = model.Vertex[index].Y;
        this.m_Vertex[index].Z = model.Vertex[index].Z;
        this.m_Vertex[index].Nx = model.Vertex[index].Nx;
        this.m_Vertex[index].Ny = model.Vertex[index].Ny;
        this.m_Vertex[index].Nz = model.Vertex[index].Nz;
        this.m_Vertex[index].Tu = model.Vertex[index].Tu;
        this.m_Vertex[index].Tv = model.Vertex[index].Tv;
      }
      for (int index = num2; index < this.m_NIndex; ++index)
        this.m_IndexStream[index] = (short) 0;
      this.m_NIndex = num2;
      for (int index = 0; index < this.m_NIndex; ++index)
        this.m_IndexStream[index] = model.m_IndexStream[index];
      if (num3 < this.m_NFaces)
      {
        for (int index = num3 * 3; index < this.m_NFaces * 3; ++index)
          this.m_Index[index] = (short) 0;
      }
      else
        Array.Resize<short>(ref this.m_Index, num3 * 3);
      this.m_NFaces = num3;
      for (int index = 0; index < this.m_NFaces * 3; ++index)
        this.m_Index[index] = model.m_Index[index];
      return true;
    }

    public bool Morphing(Model3D model, float percent)
    {
      if (!this.CanMorphing(model))
        return false;
      float num = 1f - percent;
      this.m_NVertex = model.NVertex;
      for (int index = 0; index < this.m_NVertex; ++index)
      {
        this.m_Vertex[index].X = (float) ((double) this.m_Vertex[index].X * (double) num + (double) model.Vertex[index].X * (double) percent);
        this.m_Vertex[index].Y = (float) ((double) this.m_Vertex[index].Y * (double) num + (double) model.Vertex[index].Y * (double) percent);
        this.m_Vertex[index].Z = (float) ((double) this.m_Vertex[index].Z * (double) num + (double) model.Vertex[index].Z * (double) percent);
        this.m_Vertex[index].Tu = (float) ((double) this.m_Vertex[index].Tu * (double) num + (double) model.Vertex[index].Tu * (double) percent);
        this.m_Vertex[index].Tv = (float) ((double) this.m_Vertex[index].Tv * (double) num + (double) model.Vertex[index].Tv * (double) percent);
      }
      return true;
    }

    public bool Morphing(Model3D model1, Model3D model2, float percent)
    {
      if (!Model3D.CanMorphing(model1, model2) || !this.CanMorphing(model1))
        return false;
      float num = 1f - percent;
      int nvertex = this.m_NVertex;
      if (model1.NVertex < nvertex)
        nvertex = model1.NVertex;
      if (model2.NVertex < nvertex)
        nvertex = model2.NVertex;
      this.m_NVertex = nvertex;
      for (int index = 0; index < nvertex; ++index)
      {
        this.m_Vertex[index].X = (float) ((double) model1.m_Vertex[index].X * (double) num + (double) model2.Vertex[index].X * (double) percent);
        this.m_Vertex[index].Y = (float) ((double) model1.m_Vertex[index].Y * (double) num + (double) model2.Vertex[index].Y * (double) percent);
        this.m_Vertex[index].Z = (float) ((double) model1.m_Vertex[index].Z * (double) num + (double) model2.Vertex[index].Z * (double) percent);
        this.m_Vertex[index].Tu = (float) ((double) model1.m_Vertex[index].Tu * (double) num + (double) model2.Vertex[index].Tu * (double) percent);
        this.m_Vertex[index].Tv = (float) ((double) model1.m_Vertex[index].Tv * (double) num + (double) model2.Vertex[index].Tv * (double) percent);
      }
      return true;
    }

    public void MoveForward()
    {
      for (int index = 0; index < this.m_NVertex; ++index)
        this.m_Vertex[index].Z += 0.1f;
    }

    public void MoveBack()
    {
      for (int index = 0; index < this.m_NVertex; ++index)
        this.m_Vertex[index].Z -= 0.1f;
    }

    public void MoveUp()
    {
      for (int index = 0; index < this.m_NVertex; ++index)
        this.m_Vertex[index].Y += 0.1f;
    }

    public void MoveDown()
    {
      for (int index = 0; index < this.m_NVertex; ++index)
        this.m_Vertex[index].Y -= 0.1f;
    }

    public void MoveLeft()
    {
      for (int index = 0; index < this.m_NVertex; ++index)
        this.m_Vertex[index].X += 0.1f;
    }

    public void MoveRight()
    {
      for (int index = 0; index < this.m_NVertex; ++index)
        this.m_Vertex[index].X -= 0.1f;
    }

    public void MakeCloser()
    {
      for (int index = 0; index < this.m_NVertex; ++index)
      {
        if ((double) this.m_Vertex[index].X > 0.0)
          this.m_Vertex[index].X -= 0.1f;
        else if ((double) this.m_Vertex[index].X < 0.0)
          this.m_Vertex[index].X += 0.1f;
      }
    }

    public void MakeWider()
    {
      for (int index = 0; index < this.m_NVertex; ++index)
      {
        if ((double) this.m_Vertex[index].X > 0.0)
          this.m_Vertex[index].X += 0.1f;
        else if ((double) this.m_Vertex[index].X < 0.0)
          this.m_Vertex[index].X -= 0.1f;
      }
    }

    public void SaveXFile(string fileName)
    {
      FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
      StreamWriter w = new StreamWriter((Stream) fileStream);
      this.SaveXFile(w);
      w.Close();
      fileStream.Close();
    }

    public void SaveXFile(StreamWriter w)
    {
      if (this.m_NVertex <= 0)
        return;
      w.WriteLine("xof 0303txt 0032");
      w.WriteLine("Mesh {");
      w.WriteLine(" {0};", (object) this.m_NVertex);
      for (int index = 0; index < this.m_NVertex - 1; ++index)
        w.WriteLine(" {0:F6};{1:F6};{2:F6};,", (object) this.m_Vertex[index].X, (object) this.m_Vertex[index].Y, (object) this.m_Vertex[index].Z);
      w.WriteLine(" {0:F6};{1:F6};{2:F6};;", (object) this.m_Vertex[this.m_NVertex - 1].X, (object) this.m_Vertex[this.m_NVertex - 1].Y, (object) this.m_Vertex[this.m_NVertex - 1].Z);
      w.WriteLine(" {0};", (object) this.m_NFaces);
      for (int index = 0; index < this.m_NFaces - 1; ++index)
        w.WriteLine(" 3;{0},{1},{2};,", (object) this.m_Index[index * 3], (object) this.m_Index[index * 3 + 1], (object) this.m_Index[index * 3 + 2]);
      w.WriteLine(" 3;{0},{1},{2};;", (object) this.m_Index[(this.m_NFaces - 1) * 3], (object) this.m_Index[(this.m_NFaces - 1) * 3 + 1], (object) this.m_Index[(this.m_NFaces - 1) * 3 + 2]);
      w.WriteLine(" MeshNormals {");
      w.WriteLine("  {0};", (object) this.m_NVertex);
      for (int index = 0; index < this.m_NVertex - 1; ++index)
        w.WriteLine("  {0:F6};{1:F6};{2:F6};,", (object) this.m_Vertex[index].Nx, (object) this.m_Vertex[index].Ny, (object) this.m_Vertex[index].Nz);
      w.WriteLine("  {0:F6};{1:F6};{2:F6};;", (object) this.m_Vertex[this.m_NVertex - 1].Nx, (object) this.m_Vertex[this.m_NVertex - 1].Ny, (object) this.m_Vertex[this.m_NVertex - 1].Nz);
      w.WriteLine(" {0};", (object) this.m_NFaces);
      for (int index = 0; index < this.m_NFaces - 1; ++index)
        w.WriteLine("  3;{0},{1},{2};,", (object) this.m_Index[index * 3], (object) this.m_Index[index * 3 + 1], (object) this.m_Index[index * 3 + 2]);
      w.WriteLine("  3;{0},{1},{2};;", (object) this.m_Index[(this.m_NFaces - 1) * 3], (object) this.m_Index[(this.m_NFaces - 1) * 3 + 1], (object) this.m_Index[(this.m_NFaces - 1) * 3 + 2]);
      w.WriteLine(" }");
      w.WriteLine(" MeshTextureCoords {");
      w.WriteLine("  {0};", (object) this.m_NVertex);
      for (int index = 0; index < this.m_NVertex - 1; ++index)
        w.WriteLine("  {0:F6};{1:F6};,", (object) this.m_Vertex[index].Tu, (object) this.m_Vertex[index].Tv);
      w.WriteLine("  {0:F6};{1:F6};;", (object) this.m_Vertex[this.m_NVertex - 1].Tu, (object) this.m_Vertex[this.m_NVertex - 1].Tv);
      w.WriteLine(" }");
      w.WriteLine(" MeshMaterialList {");
      w.WriteLine("  1;");
      w.WriteLine("  {0};", (object) this.m_NFaces);
      for (int index = 0; index < this.m_NFaces - 1; ++index)
        w.WriteLine("  0,");
      w.WriteLine("  0;");
      w.WriteLine("  Material {");
      w.WriteLine("   1.000000;1.000000;1.000000;0.000000;;");
      w.WriteLine("   0.000000;");
      w.WriteLine("   0.000000;0.000000;0.000000;;");
      w.WriteLine("   0.000000;0.000000;0.000000;;");
      w.WriteLine("   TextureFilename {");
      w.WriteLine("   \"" + this.m_TextureFileName + "\";");
      w.WriteLine("   }");
      w.WriteLine("  }");
      w.WriteLine(" }");
      w.WriteLine("}");
      this.m_TextureBitmap.Save(this.m_TextureFileName, ImageFormat.Png);
    }

    public void OffsetVertex(int offsetX, int offsetY, int offsetZ)
    {
      if (this.m_Vertex == null || this.m_Vertex.Length < this.m_NOriginalVertex)
        return;
      for (int index = 0; index < this.m_NOriginalVertex; ++index)
      {
        this.m_Vertex[index].X -= (float) offsetX;
        this.m_Vertex[index].Y -= (float) offsetY;
        this.m_Vertex[index].Z -= (float) offsetZ;
      }
    }

    public void Morphing(int[] points, Vector3 symmetryPoint, Vector3 delta)
    {
      for (int index = 0; index < points.Length; ++index)
      {
        int point = points[index];
        if (point >= 0 && point < this.NVertex)
        {
          if ((double) this.Vertex[point].X < (double) symmetryPoint.X)
            this.Vertex[point].X -= delta.X;
          else
            this.Vertex[point].X += delta.X;
          if ((double) this.Vertex[point].Y < (double) symmetryPoint.Y)
            this.Vertex[point].Y -= delta.Y;
          else
            this.Vertex[point].Y += delta.Y;
          if ((double) this.Vertex[point].Z < (double) symmetryPoint.Z)
            this.Vertex[point].Z -= delta.Z;
          else
            this.Vertex[point].Z += delta.Z;
        }
      }
    }
  }
}
