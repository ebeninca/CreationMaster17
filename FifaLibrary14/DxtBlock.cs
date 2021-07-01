// Original code created by Rinaldo

using System.Drawing;
using System.IO;

namespace FifaLibrary
{
  public class DxtBlock
  {
    private EImageType m_DxtType;
    private ushort m_Col0;
    private ushort m_Col1;
    private byte m_Alfa0;
    private byte m_Alfa1;
    private int[,] m_ColorLut;
    private int[,] m_AlfaLut;
    private int[,] m_Alfa;
    private int[,] m_TempLut;
    private Color[,] m_Colors;

    public Color[,] Colors
    {
      get
      {
        return this.m_Colors;
      }
      set
      {
        this.m_Colors = value;
      }
    }

    public DxtBlock(int dxtType)
    {
      this.m_ColorLut = new int[4, 4];
      this.m_AlfaLut = new int[4, 4];
      this.m_Colors = new Color[4, 4];
      this.m_Alfa = new int[4, 4];
      this.Init(dxtType);
    }

    public DxtBlock(int dxtType, BinaryReader br)
    {
      this.m_DxtType = (EImageType) dxtType;
      this.m_ColorLut = new int[4, 4];
      this.m_Colors = new Color[4, 4];
      this.Load(br);
    }

    public void Load(BinaryReader br)
    {
      switch (this.m_DxtType)
      {
        case EImageType.DXT1:
          this.ReadColorLut(br);
          break;
        case EImageType.DXT3:
          this.ReadAlfaChannel(br);
          this.ReadColorLut(br);
          break;
        case EImageType.DXT5:
          this.ReadAlfaLut(br);
          this.ReadColorLut(br);
          break;
        default:
          return;
      }
      this.ConvertTo4x4();
    }

    public void Save(BinaryWriter bw)
    {
      this.ConvertFrom4x4();
      switch (this.m_DxtType)
      {
        case EImageType.DXT1:
          this.WriteColorLut(bw);
          break;
        case EImageType.DXT3:
          this.WriteAlfaChannel(bw);
          this.WriteColorLut(bw);
          break;
        case EImageType.DXT5:
          this.WriteAlfaLut(bw);
          this.WriteColorLut(bw);
          break;
      }
    }

    private void Init(int dxtType)
    {
      this.m_DxtType = (EImageType) dxtType;
      this.m_Col0 = (ushort) 0;
      this.m_Col1 = (ushort) 0;
      for (int index1 = 0; index1 < 4; ++index1)
      {
        for (int index2 = 0; index2 < 4; ++index2)
        {
          this.m_ColorLut[index1, index2] = 0;
          this.m_Alfa[index1, index2] = (int) byte.MaxValue;
          this.m_Colors[index1, index2] = Color.FromArgb(0, 0, 0);
        }
      }
    }

    private void ReadAlfaChannel(BinaryReader br)
    {
      for (int index = 0; index < 4; ++index)
      {
        int num = (int) br.ReadInt16();
        this.m_Alfa[0, index] = (num & 15) << 4;
        this.m_Alfa[1, index] = (num >> 4 & 15) << 4;
        this.m_Alfa[2, index] = (num >> 8 & 15) << 4;
        this.m_Alfa[3, index] = (num >> 12 & 15) << 4;
      }
    }

    private void ReadColorLut(BinaryReader br)
    {
      this.m_Col0 = br.ReadUInt16();
      this.m_Col1 = br.ReadUInt16();
      for (int index = 0; index < 4; ++index)
      {
        byte num = br.ReadByte();
        this.m_ColorLut[0, index] = (int) num & 3;
        this.m_ColorLut[1, index] = (int) num >> 2 & 3;
        this.m_ColorLut[2, index] = (int) num >> 4 & 3;
        this.m_ColorLut[3, index] = (int) num >> 6 & 3;
      }
    }

    private void ReadAlfaLut(BinaryReader br)
    {
      this.m_Alfa0 = br.ReadByte();
      this.m_Alfa1 = br.ReadByte();
      byte[] numArray = br.ReadBytes(6);
      ulong num = 0;
      for (int index = 5; index >= 0; --index)
        num = num * 256UL | (ulong) numArray[index];
      for (int index1 = 0; index1 < 4; ++index1)
      {
        for (int index2 = 0; index2 < 4; ++index2)
        {
          this.m_AlfaLut[index2, index1] = (int) ((long) num & 7L);
          num >>= 3;
        }
      }
    }

    private void WriteAlfaChannel(BinaryWriter bw)
    {
      for (int index = 0; index < 4; ++index)
      {
        ushort num = (ushort) ((uint) (ushort) ((uint) (ushort) ((uint) (ushort) ((this.m_Alfa[0, index] & 240) >> 4) | (uint) (ushort) (this.m_Alfa[1, index] & 240)) | (uint) (ushort) ((this.m_Alfa[2, index] & 240) << 4)) | (uint) (ushort) ((this.m_Alfa[3, index] & 240) << 8));
        bw.Write(num);
      }
    }

    private void WriteColorLut(BinaryWriter bw)
    {
      bw.Write(this.m_Col0);
      bw.Write(this.m_Col1);
      for (int index = 0; index < 4; ++index)
      {
        byte num = (byte) ((uint) (byte) ((uint) (byte) ((uint) (byte) (this.m_ColorLut[0, index] & 3) | (uint) (byte) ((this.m_ColorLut[1, index] & 3) << 2)) | (uint) (byte) ((this.m_ColorLut[2, index] & 3) << 4)) | (uint) (byte) ((this.m_ColorLut[3, index] & 3) << 6));
        bw.Write(num);
      }
    }

    private void WriteAlfaLut(BinaryWriter bw)
    {
      bw.Write(this.m_Alfa0);
      bw.Write(this.m_Alfa1);
      ulong num = 0;
      for (int index1 = 3; index1 >= 0; --index1)
      {
        for (int index2 = 3; index2 >= 0; --index2)
          num = num << 3 | (ulong) (uint) (this.m_AlfaLut[index2, index1] & 7);
      }
      byte[] buffer = new byte[6];
      for (int index = 0; index < 6; ++index)
      {
        buffer[index] = (byte) (num & (ulong) byte.MaxValue);
        num >>= 8;
      }
      bw.Write(buffer);
    }

    private void CleanLuts()
    {
      for (int index1 = 0; index1 < 4; ++index1)
      {
        for (int index2 = 0; index2 < 4; ++index2)
        {
          this.m_AlfaLut[index1, index2] = 0;
          this.m_ColorLut[index1, index2] = 0;
        }
      }
    }

    private void ConvertFrom4x4()
    {
      Color[] colorArray = new Color[16];
      bool flag1 = false;
      int index1 = 0;
      int num1 = (int) byte.MaxValue;
      int num2 = 0;
      int nColors = 4;
      for (int index2 = 0; index2 < 4; ++index2)
      {
        for (int index3 = 0; index3 < 4; ++index3)
        {
          uint num3 = (uint) this.m_Colors[index2, index3].ToArgb() & 4294507768U;
          this.m_Colors[index2, index3] = Color.FromArgb((int) num3);
        }
      }
      for (int index2 = 0; index2 < 4; ++index2)
      {
        for (int index3 = 0; index3 < 4; ++index3)
        {
          bool flag2 = false;
          if (this.m_DxtType == EImageType.DXT1)
          {
            if (this.m_Colors[index2, index3].A == (byte) 0)
            {
              flag1 = true;
              nColors = 3;
              continue;
            }
          }
          else
          {
            if ((int) this.m_Colors[index2, index3].A < num1)
              num1 = (int) this.m_Colors[index2, index3].A;
            if ((int) this.m_Colors[index2, index3].A > num2)
              num2 = (int) this.m_Colors[index2, index3].A;
          }
          for (int index4 = 0; index4 < index1; ++index4)
          {
            if ((int) this.m_Colors[index2, index3].R == (int) colorArray[index4].R && (int) this.m_Colors[index2, index3].G == (int) colorArray[index4].G && (int) this.m_Colors[index2, index3].B == (int) colorArray[index4].B)
            {
              flag2 = true;
              break;
            }
          }
          if (!flag2)
          {
            colorArray[index1] = this.m_Colors[index2, index3];
            ++index1;
          }
        }
      }
      int num4 = 16777215;
      this.m_TempLut = new int[4, 4];
      if (this.m_DxtType == EImageType.DXT1 && flag1)
      {
        switch (index1)
        {
          case 0:
            for (int index2 = 0; index2 < 4; ++index2)
            {
              for (int index3 = 0; index3 < 4; ++index3)
                this.m_ColorLut[index2, index3] = 3;
            }
            this.m_Col0 = (ushort) 0;
            this.m_Col1 = (ushort) 0;
            return;
          case 1:
            for (int index2 = 0; index2 < 4; ++index2)
            {
              for (int index3 = 0; index3 < 4; ++index3)
                this.m_ColorLut[index2, index3] = this.m_Colors[index2, index3].A != (byte) 0 ? 0 : 3;
            }
            this.m_Col0 = this.m_Col1 = (ushort) (((int) colorArray[0].R & 248) << 8 | ((int) colorArray[0].G & 252) << 3 | ((int) colorArray[0].B & 248) >> 3);
            return;
          case 2:
            this.m_Col0 = (ushort) (((int) colorArray[0].R & 248) << 8 | ((int) colorArray[0].G & 252) << 3 | ((int) colorArray[0].B & 248) >> 3);
            this.m_Col1 = (ushort) (((int) colorArray[1].R & 248) << 8 | ((int) colorArray[1].G & 252) << 3 | ((int) colorArray[1].B & 248) >> 3);
            if ((int) this.m_Col0 >= (int) this.m_Col1)
            {
              ushort col0 = this.m_Col0;
              this.m_Col0 = this.m_Col1;
              this.m_Col1 = col0;
              Color color = colorArray[0];
              colorArray[0] = colorArray[1];
              colorArray[1] = color;
            }
            for (int index2 = 0; index2 < 4; ++index2)
            {
              for (int index3 = 0; index3 < 4; ++index3)
                this.m_ColorLut[index2, index3] = this.m_Colors[index2, index3].A != (byte) 0 ? (!(this.m_Colors[index2, index3] == colorArray[0]) ? 1 : 0) : 3;
            }
            return;
        }
      }
      this.CleanLuts();
      if (num2 == 0 && num1 == 0)
      {
        this.m_Alfa0 = (byte) 0;
        this.m_Col0 = (ushort) 0;
        this.m_Alfa1 = (byte) 1;
        this.m_Col1 = (ushort) 1;
        index1 = 0;
      }
      if (index1 == 1)
      {
        for (int index2 = 0; index2 < 4; ++index2)
        {
          for (int index3 = 0; index3 < 4; ++index3)
            this.m_ColorLut[index2, index3] = 0;
        }
        this.m_Col0 = this.m_Col1 = (ushort) (((int) colorArray[0].R & 248) << 8 | ((int) colorArray[0].G & 252) << 3 | ((int) colorArray[0].B & 248) >> 3);
      }
      for (int index2 = 0; index2 < index1; ++index2)
      {
        for (int index3 = index2 + 1; index3 < index1; ++index3)
        {
          ushort num3 = (ushort) (((int) colorArray[index2].R & 248) << 8 | ((int) colorArray[index2].G & 252) << 3 | ((int) colorArray[index2].B & 248) >> 3);
          ushort num5 = (ushort) (((int) colorArray[index3].R & 248) << 8 | ((int) colorArray[index3].G & 252) << 3 | ((int) colorArray[index3].B & 248) >> 3);
          ushort num6;
          ushort num7;
          int index4;
          int index5;
          if ((int) num3 < (int) num5)
          {
            num6 = num3;
            num7 = num5;
            index4 = index2;
            index5 = index3;
          }
          else
          {
            num6 = num5;
            num7 = num3;
            index4 = index3;
            index5 = index2;
          }
          if (nColors == 4)
          {
            int num8 = this.ScoreColors(colorArray[index5], colorArray[index4], nColors);
            if (num8 < num4)
            {
              num4 = num8;
              for (int index6 = 0; index6 < 4; ++index6)
              {
                for (int index7 = 0; index7 < 4; ++index7)
                  this.m_ColorLut[index6, index7] = this.m_TempLut[index6, index7];
              }
              this.m_Col0 = num7;
              this.m_Col1 = num6;
              if (num8 == 0)
                break;
            }
          }
          if (this.m_DxtType == EImageType.DXT1)
          {
            int num8 = this.ScoreColors(colorArray[index4], colorArray[index5], 3);
            if (num8 < num4)
            {
              num4 = num8;
              for (int index6 = 0; index6 < 4; ++index6)
              {
                for (int index7 = 0; index7 < 4; ++index7)
                  this.m_ColorLut[index6, index7] = this.m_TempLut[index6, index7];
              }
              this.m_Col0 = num6;
              this.m_Col1 = num7;
              if (num8 == 0)
                break;
            }
          }
        }
      }
      if (this.m_DxtType == EImageType.DXT3 || this.m_DxtType == EImageType.DXT3)
      {
        for (int index2 = 0; index2 < 4; ++index2)
        {
          for (int index3 = 0; index3 < 4; ++index3)
            this.m_Alfa[index2, index3] = (int) this.m_Colors[index2, index3].A & 240;
        }
      }
      if (this.m_DxtType != EImageType.DXT5 && this.m_DxtType != EImageType.DXT5 || num1 == 0 && num2 == 0)
        return;
      this.m_Alfa1 = (byte) num1;
      this.m_Alfa0 = (byte) num2;
      int num9 = num2 - num1;
      int[] numArray = new int[8];
      if (num9 != 0)
      {
        for (int index2 = 2; index2 < 8; ++index2)
          numArray[index2] = ((int) this.m_Alfa0 * (8 - index2) + (int) this.m_Alfa1 * (index2 - 1)) / 7;
      }
      int num10 = num9 / 7 / 2;
      for (int index2 = 0; index2 < 4; ++index2)
      {
        for (int index3 = 0; index3 < 4; ++index3)
        {
          int a = (int) this.m_Colors[index2, index3].A;
          if (a <= num1 + num10)
            this.m_AlfaLut[index2, index3] = 1;
          else if (a >= num2 - num10)
            this.m_AlfaLut[index2, index3] = 0;
          else if (num9 != 0)
          {
            this.m_AlfaLut[index2, index3] = 0;
            for (int index4 = 2; index4 < 8; ++index4)
            {
              if (a > numArray[index4] - num10)
              {
                this.m_AlfaLut[index2, index3] = index4;
                break;
              }
            }
          }
          else
            this.m_AlfaLut[index2, index3] = 0;
        }
      }
    }

    private void ConvertTo4x4()
    {
      int[] numArray1 = new int[8];
      numArray1[0] = (int) this.m_Alfa0;
      numArray1[1] = (int) this.m_Alfa1;
      if (this.m_DxtType == EImageType.DXT5)
      {
        if ((int) this.m_Alfa0 > (int) this.m_Alfa1)
        {
          for (int index = 2; index < 8; ++index)
            numArray1[index] = ((int) this.m_Alfa0 * (8 - index) + (int) this.m_Alfa1 * (index - 1)) / 7;
        }
        else
        {
          for (int index = 2; index < 6; ++index)
            numArray1[index] = ((int) this.m_Alfa0 * (6 - index) + (int) this.m_Alfa1 * (index - 1)) / 5;
          numArray1[6] = 0;
          numArray1[7] = (int) byte.MaxValue;
        }
      }
      if (this.m_DxtType == EImageType.DXT5)
      {
        for (int index1 = 0; index1 < 4; ++index1)
        {
          for (int index2 = 0; index2 < 4; ++index2)
          {
            int index3 = this.m_AlfaLut[index1, index2];
            this.m_Alfa[index1, index2] = numArray1[index3];
          }
        }
      }
      if (this.m_DxtType == EImageType.DXT1)
      {
        for (int index1 = 0; index1 < 4; ++index1)
        {
          for (int index2 = 0; index2 < 4; ++index2)
          {
            int num = this.m_ColorLut[index1, index2];
            this.m_Alfa[index1, index2] = (int) this.m_Col0 > (int) this.m_Col1 || num != 3 ? (int) byte.MaxValue : 0;
          }
        }
      }
      int[] numArray2 = new int[4];
      int[] numArray3 = new int[4];
      int[] numArray4 = new int[4]
      {
        8 * ((int) this.m_Col0 & 31),
        0,
        0,
        0
      };
      numArray3[0] = 4 * ((int) this.m_Col0 >> 5 & 63);
      numArray2[0] = 8 * ((int) this.m_Col0 >> 11);
      numArray4[1] = 8 * ((int) this.m_Col1 & 31);
      numArray3[1] = 4 * ((int) this.m_Col1 >> 5 & 63);
      numArray2[1] = 8 * ((int) this.m_Col1 >> 11);
      if ((int) this.m_Col0 > (int) this.m_Col1 || this.m_DxtType != EImageType.DXT1)
      {
        numArray2[2] = (2 * numArray2[0] + numArray2[1]) / 3;
        numArray3[2] = (2 * numArray3[0] + numArray3[1]) / 3;
        numArray4[2] = (2 * numArray4[0] + numArray4[1]) / 3;
        numArray2[3] = (numArray2[0] + 2 * numArray2[1]) / 3;
        numArray3[3] = (numArray3[0] + 2 * numArray3[1]) / 3;
        numArray4[3] = (numArray4[0] + 2 * numArray4[1]) / 3;
      }
      else
      {
        numArray2[2] = (numArray2[0] + numArray2[1]) / 2;
        numArray3[2] = (numArray3[0] + numArray3[1]) / 2;
        numArray4[2] = (numArray4[0] + numArray4[1]) / 2;
        numArray2[3] = 0;
        numArray3[3] = 0;
        numArray4[3] = 0;
      }
      for (int index1 = 0; index1 < 4; ++index1)
      {
        for (int index2 = 0; index2 < 4; ++index2)
        {
          int index3 = this.m_ColorLut[index1, index2];
          this.m_Colors[index1, index2] = Color.FromArgb(this.m_Alfa[index1, index2], numArray2[index3], numArray3[index3], numArray4[index3]);
        }
      }
    }

    private int[] ComputeInterpolatedAlfa(int alfa0, int alfa1)
    {
      int[] numArray = new int[8];
      numArray[0] = alfa0;
      numArray[1] = alfa1;
      for (int index = 2; index < 8; ++index)
      {
        int num1 = 8 - index;
        int num2 = index - 1;
        numArray[index] = (num1 * alfa0 + num2 * alfa1) / 7;
      }
      return numArray;
    }

    private int[,] ComputeInterpolatedRgb(Color col0, Color col1, int nColors)
    {
      int[,] numArray = new int[4, 3]
      {
        {
          (int) col0.R,
          (int) col0.G,
          (int) col0.B
        },
        {
          (int) col1.R,
          (int) col1.G,
          (int) col1.B
        },
        {
          0,
          0,
          0
        },
        {
          0,
          0,
          0
        }
      };
      if (nColors <= 3)
      {
        nColors = 3;
        for (int index = 2; index < nColors; ++index)
        {
          int num1 = nColors - index;
          int num2 = index - 1;
          numArray[index, 0] = (num1 * (int) col0.R + num2 * (int) col1.R) / 2;
          numArray[index, 1] = (num1 * (int) col0.G + num2 * (int) col1.G) / 2;
          numArray[index, 2] = (num1 * (int) col0.B + num2 * (int) col1.B) / 2;
        }
        numArray[3, 0] = 0;
        numArray[3, 1] = 0;
        numArray[3, 2] = 0;
      }
      else
      {
        nColors = 4;
        for (int index = 2; index < nColors; ++index)
        {
          int num1 = nColors - index;
          int num2 = index - 1;
          numArray[index, 0] = (num1 * (int) col0.R + num2 * (int) col1.R) / 3;
          numArray[index, 1] = (num1 * (int) col0.G + num2 * (int) col1.G) / 3;
          numArray[index, 2] = (num1 * (int) col0.B + num2 * (int) col1.B) / 3;
        }
      }
      return numArray;
    }

    private int ScoreColors(Color col0, Color col1, int nColors)
    {
      int[,] interpolatedRgb = this.ComputeInterpolatedRgb(col0, col1, nColors);
      int num1 = 0;
      for (int index1 = 0; index1 < 4; ++index1)
      {
        for (int index2 = 0; index2 < 4; ++index2)
        {
          int num2 = 16777215;
          int r = (int) this.m_Colors[index1, index2].R;
          int g = (int) this.m_Colors[index1, index2].G;
          int b = (int) this.m_Colors[index1, index2].B;
          if (this.m_Colors[index1, index2].A == (byte) 0 && nColors == 3)
          {
            this.m_TempLut[index1, index2] = 3;
          }
          else
          {
            for (int index3 = 0; index3 < nColors; ++index3)
            {
              int num3 = interpolatedRgb[index3, 0] - r;
              int num4 = interpolatedRgb[index3, 1] - g;
              int num5 = interpolatedRgb[index3, 2] - b;
              int num6 = num3 * num3 + num4 * num4 + num5 * num5;
              if (num6 < num2)
              {
                num2 = num6;
                this.m_TempLut[index1, index2] = index3;
                if (num6 == 0)
                  break;
              }
            }
            num1 += num2;
          }
        }
      }
      return num1;
    }
  }
}
