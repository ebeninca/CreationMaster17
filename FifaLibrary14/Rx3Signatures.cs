// Original code created by Rinaldo

using System.IO;

namespace FifaLibrary
{
  public class Rx3Signatures
  {
    private int m_Offset;
    private int m_Length;
    private string[] m_Signatures;

    public int Offset
    {
      get
      {
        return this.m_Offset;
      }
      set
      {
        this.m_Offset = value;
      }
    }

    public int Length
    {
      get
      {
        return this.m_Length;
      }
      set
      {
        this.m_Length = value;
      }
    }

    public string[] Signatures
    {
      get
      {
        return this.m_Signatures;
      }
      set
      {
        this.m_Signatures = value;
      }
    }

    public Rx3Signatures(int offset, int length, string[] signatures)
    {
      this.Init(offset, length, signatures);
    }

    private void Init(int offset, int length, string[] signatures)
    {
      this.m_Offset = offset;
      this.m_Length = length;
      this.m_Signatures = signatures;
    }

    public bool Save(BinaryWriter w)
    {
      if (this.m_Signatures == null)
        return false;
      for (int index = 0; index < this.m_Signatures.Length; ++index)
      {
        w.BaseStream.Position = (long) (this.m_Offset + this.m_Length * index + 4);
        w.Write(this.m_Length - 8);
        w.Write(this.m_Signatures[index].ToCharArray(0, this.m_Signatures[index].Length));
        for (int length = this.m_Signatures[index].Length; length < this.m_Length - 8; ++length)
          w.Write((byte) 0);
      }
      return true;
    }
  }
}
