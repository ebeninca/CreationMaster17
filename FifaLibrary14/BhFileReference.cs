// Original code created by Rinaldo

using System.IO;

namespace FifaLibrary
{
  public class BhFileReference
  {
    private uint m_StartPosition;
    private int m_Size;
    private int m_UncompressedSize;
    private ulong m_Hash;

    public uint StartPosition
    {
      get
      {
        return this.m_StartPosition;
      }
      set
      {
        this.m_StartPosition = value;
      }
    }

    public int Size
    {
      get
      {
        return this.m_Size;
      }
      set
      {
        this.m_Size = value;
      }
    }

    public int UncompressedSize
    {
      get
      {
        return this.m_UncompressedSize;
      }
      set
      {
        this.m_UncompressedSize = value;
      }
    }

    public ulong Hash
    {
      get
      {
        return this.m_Hash;
      }
      set
      {
        this.m_Hash = value;
      }
    }

    public BhFileReference(uint startPosition, int size, int uncompressedSize, string name)
    {
      this.m_StartPosition = startPosition;
      this.m_Size = size;
      this.m_UncompressedSize = uncompressedSize;
      if (this.m_UncompressedSize != 0)
        this.m_Size = (this.m_Size + 15 >> 4) * 16;
      this.m_Hash = FifaUtil.ComputeBhHash(name);
    }

    public BhFileReference()
    {
    }

    public bool Load(BinaryReader r)
    {
      this.m_StartPosition = FifaUtil.SwapEndian(r.ReadUInt32());
      this.m_Size = FifaUtil.SwapEndian(r.ReadInt32());
      this.m_UncompressedSize = FifaUtil.SwapEndian(r.ReadInt32());
      this.m_Hash = FifaUtil.SwapEndian(r.ReadUInt64());
      return true;
    }

    public bool Save(BinaryWriter w)
    {
      w.Write(FifaUtil.SwapEndian(this.m_StartPosition));
      w.Write(FifaUtil.SwapEndian(this.m_Size));
      w.Write(FifaUtil.SwapEndian(this.m_UncompressedSize));
      w.Write(FifaUtil.SwapEndian(this.m_Hash));
      return true;
    }

    public void Hide()
    {
      this.m_Hash = 0UL;
    }

    public bool IsHidden()
    {
      return this.m_Hash == 0UL;
    }

    public void Restore(string name)
    {
      this.m_Hash = FifaUtil.ComputeBhHash(name);
    }
  }
}
