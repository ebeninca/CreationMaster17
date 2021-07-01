// Original code created by Rinaldo

using System.IO;

namespace FifaLibrary
{
  public class HuffmannTree
  {
    private ushort[] m_EncodingValue = new ushort[256];
    private byte[] m_nBitsForEncoding = new byte[256];
    private byte[,] m_Child;
    private byte[,] m_Leaf;
    private int m_NNodes;

    public int NNodes
    {
      get
      {
        return this.m_NNodes;
      }
      set
      {
        this.m_NNodes = value;
      }
    }

    public int Size
    {
      get
      {
        return this.m_NNodes * 4;
      }
    }

    public HuffmannTree(int nNodes)
    {
      this.m_NNodes = nNodes;
      this.m_Child = new byte[this.m_NNodes, 2];
      this.m_Leaf = new byte[this.m_NNodes, 2];
      for (int index = 0; index < this.m_NNodes; ++index)
      {
        this.m_Child[index, 0] = (byte) 0;
        this.m_Child[index, 1] = (byte) 0;
        this.m_Leaf[index, 0] = (byte) 0;
        this.m_Leaf[index, 1] = (byte) 0;
      }
    }

    public void Load(DbReader r)
    {
      for (int index = 0; index < this.m_NNodes; ++index)
      {
        this.m_Child[index, 0] = r.ReadByte();
        this.m_Leaf[index, 0] = r.ReadByte();
        this.m_Child[index, 1] = r.ReadByte();
        this.m_Leaf[index, 1] = r.ReadByte();
      }
      this.BuildEncodingTable();
    }

    public void Save(BinaryWriter w)
    {
      for (int index = 0; index < this.m_NNodes; ++index)
      {
        w.Write(this.m_Child[index, 0]);
        w.Write(this.m_Leaf[index, 0]);
        w.Write(this.m_Child[index, 1]);
        w.Write(this.m_Leaf[index, 1]);
      }
    }

    private void BuildEncodingTable()
    {
      ushort[] numArray1 = new ushort[this.m_NNodes];
      byte[] numArray2 = new byte[this.m_NNodes];
      for (int index = 0; index < this.m_NNodes; ++index)
      {
        ushort num1 = (ushort) ((uint) numArray1[index] * 2U);
        byte num2 = (byte) ((uint) numArray2[index] + 1U);
        byte num3 = this.m_Child[index, 0];
        if (num3 != (byte) 0)
        {
          numArray1[(int) num3] = num1;
          numArray2[(int) num3] = num2;
        }
        else
        {
          byte num4 = this.m_Leaf[index, 0];
          this.m_EncodingValue[(int) num4] = num1;
          this.m_nBitsForEncoding[(int) num4] = num2;
        }
        ushort num5 = (ushort) ((uint) num1 + 1U);
        byte num6 = this.m_Child[index, 1];
        if (num6 != (byte) 0)
        {
          numArray1[(int) num6] = num5;
          numArray2[(int) num6] = num2;
        }
        else
        {
          byte num4 = this.m_Leaf[index, 1];
          this.m_EncodingValue[(int) num4] = num5;
          this.m_nBitsForEncoding[(int) num4] = num2;
        }
      }
    }

    public string ReadString(DbReader r, int outputLength)
    {
      int num1 = 0;
      int index1 = 0;
      if (outputLength <= 0)
        return string.Empty;
      byte[] bytes;
      if (this.m_NNodes == 0)
      {
        bytes = r.ReadBytes(outputLength);
      }
      else
      {
        bytes = new byte[outputLength];
        do
        {
          byte num2 = r.ReadByte();
          for (int index2 = 7; index2 >= 0; --index2)
          {
            int index3 = (int) num2 >> index2 & 1;
            int num3 = (int) this.m_Child[index1, index3];
            if (num3 == 0)
            {
              bytes[num1++] = this.m_Leaf[index1, index3];
              if (num1 != outputLength)
                index1 = 0;
              else
                break;
            }
            else
              index1 = num3;
          }
        }
        while (num1 < outputLength);
      }
      return FifaUtil.ConvertBytesToString(bytes);
    }

    public int WriteString(BinaryWriter w, string str, bool longString)
    {
      switch (str)
      {
        case "":
        case null:
          return 0;
        default:
          byte[] bytes = FifaUtil.ConvertStringToBytes(str);
          int num1;
          if (longString)
          {
            ushort length = (ushort) bytes.Length;
            w.Write(FifaUtil.SwapEndian(length));
            num1 = 2;
          }
          else
          {
            w.Write((byte) bytes.Length);
            num1 = 1;
          }
          if (this.m_NNodes == 0)
          {
            w.Write(bytes);
            return num1 + bytes.Length;
          }
          int num2 = 7;
          byte num3 = 0;
          for (int index1 = 0; index1 < bytes.Length; ++index1)
          {
            byte num4 = bytes[index1];
            int num5 = (int) this.m_EncodingValue[(int) num4];
            int num6 = (int) this.m_nBitsForEncoding[(int) num4];
            if (num6 == 0)
            {
              num5 = (int) this.m_EncodingValue[32];
              num6 = (int) this.m_nBitsForEncoding[32];
            }
            for (int index2 = num6 - 1; index2 >= 0; --index2)
            {
              if ((num5 & 1 << index2) != 0)
                num3 += (byte) (1 << num2);
              --num2;
              if (num2 == -1)
              {
                num2 = 7;
                w.Write(num3);
                ++num1;
                num3 = (byte) 0;
              }
            }
          }
          w.Write(num3);
          return num1 + 1;
      }
    }
  }
}
