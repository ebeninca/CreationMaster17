// Original code created by Rinaldo

using System.IO;

namespace FifaLibrary
{
  public class Rx3IndexArray
  {
    private static Rx3IndexArray.ETriangleListType s_TriangleListType;
    private int m_Size;
    private int m_nIndex;
    private int m_SizeOfIndex;
    private int m_Unknown;
    private int m_nFaces;
    private short[] m_IndexStream;
    private bool m_IsTriangleList;
    private bool m_SwapEndian;

    public static Rx3IndexArray.ETriangleListType TriangleListType
    {
      get
      {
        return Rx3IndexArray.s_TriangleListType;
      }
      set
      {
        Rx3IndexArray.s_TriangleListType = value;
      }
    }

    public int NIndex
    {
      get
      {
        return this.m_nIndex;
      }
    }

    public int nFaces
    {
      get
      {
        return this.m_nFaces;
      }
    }

    public short[] IndexStream
    {
      get
      {
        return this.m_IndexStream;
      }
    }

    public bool IsTriangleList
    {
      get
      {
        return this.m_IsTriangleList;
      }
    }

    public Rx3IndexArray(BinaryReader r, bool swapEndian)
    {
      this.m_SwapEndian = swapEndian;
      this.Load(r);
    }

    public bool Load(BinaryReader r)
    {
      if (this.m_SwapEndian)
      {
        this.m_Size = FifaUtil.SwapEndian(r.ReadInt32());
        this.m_nIndex = FifaUtil.SwapEndian(r.ReadInt32());
        this.m_SizeOfIndex = r.ReadInt32();
        this.m_Unknown = r.ReadInt32();
        this.m_IndexStream = new short[this.m_nIndex];
        for (int index = 0; index < this.m_nIndex; ++index)
          this.m_IndexStream[index] = FifaUtil.SwapEndian(r.ReadInt16());
      }
      else
      {
        this.m_Size = r.ReadInt32();
        this.m_nIndex = r.ReadInt32();
        this.m_SizeOfIndex = r.ReadInt32();
        this.m_Unknown = r.ReadInt32();
        this.m_IndexStream = new short[this.m_nIndex];
        for (int index = 0; index < this.m_nIndex; ++index)
          this.m_IndexStream[index] = r.ReadInt16();
      }
      this.m_IsTriangleList = false;
      this.m_nFaces = this.m_nIndex / 3;
      if (this.m_nFaces * 3 != this.m_nIndex)
      {
        this.m_IsTriangleList = true;
      }
      else
      {
        for (int index = 0; index < this.nFaces; ++index)
        {
          short num1 = this.m_IndexStream[index * 3];
          short num2 = this.m_IndexStream[index * 3 + 1];
          short num3 = this.m_IndexStream[index * 3 + 2];
          if ((int) num1 == (int) num2 || (int) num2 == (int) num3 || (int) num1 == (int) num3)
          {
            this.m_IsTriangleList = true;
            break;
          }
        }
      }
      if (this.m_IsTriangleList)
      {
        this.m_nFaces = 0;
        for (int index = 0; index < this.m_nIndex - 2; ++index)
        {
          short num1 = this.m_IndexStream[index];
          short num2 = this.m_IndexStream[index + 1];
          short num3 = this.m_IndexStream[index + 2];
          if ((int) num1 != (int) num2 && (int) num2 != (int) num3 && (int) num1 != (int) num3)
            ++this.m_nFaces;
        }
      }
      return true;
    }

    public bool Save(BinaryWriter w)
    {
      if (this.m_SwapEndian)
      {
        w.Write(FifaUtil.SwapEndian(this.m_Size));
        w.Write(FifaUtil.SwapEndian(this.m_nIndex));
        w.Write(this.m_SizeOfIndex);
        w.Write(this.m_Unknown);
        for (int index = 0; index < this.m_nIndex; ++index)
          w.Write(FifaUtil.SwapEndian(this.m_IndexStream[index]));
      }
      else
      {
        w.Write(this.m_Size);
        w.Write(this.m_nIndex);
        w.Write(this.m_SizeOfIndex);
        w.Write(this.m_Unknown);
        for (int index = 0; index < this.m_nIndex; ++index)
          w.Write(this.m_IndexStream[index]);
      }
      return true;
    }

    public enum ETriangleListType
    {
      InvertOdd,
      InvertEven,
    }
  }
}
