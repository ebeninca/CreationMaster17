// Original code created by Rinaldo

using System.IO;

namespace FifaLibrary
{
  public class Rx3FileDescriptor
  {
    private uint m_Signature;
    private int m_FileOffset;
    private int m_FileSize;
    private int m_Unknown_0c;
    private bool m_SwapEndian;

    public uint Signature
    {
      get
      {
        return this.m_Signature;
      }
    }

    public int Offset
    {
      get
      {
        return this.m_FileOffset;
      }
      set
      {
        this.m_FileOffset = value;
      }
    }

    public int Size
    {
      get
      {
        return this.m_FileSize;
      }
      set
      {
        this.m_FileSize = value;
      }
    }

    public Rx3FileDescriptor(BinaryReader r, bool swapEndian)
    {
      this.m_SwapEndian = swapEndian;
      this.Load(r);
    }

    public bool Load(BinaryReader r)
    {
      if (this.m_SwapEndian)
      {
        this.m_Signature = FifaUtil.SwapEndian(r.ReadUInt32());
        this.m_FileOffset = FifaUtil.SwapEndian(r.ReadInt32());
        this.m_FileSize = FifaUtil.SwapEndian(r.ReadInt32());
        this.m_Unknown_0c = FifaUtil.SwapEndian(r.ReadInt32());
      }
      else
      {
        this.m_Signature = r.ReadUInt32();
        this.m_FileOffset = r.ReadInt32();
        this.m_FileSize = r.ReadInt32();
        this.m_Unknown_0c = r.ReadInt32();
      }
      return true;
    }

    public bool Save(BinaryWriter w)
    {
      if (this.m_SwapEndian)
      {
        w.Write(FifaUtil.SwapEndian(this.m_Signature));
        w.Write(FifaUtil.SwapEndian(this.m_FileOffset));
        w.Write(FifaUtil.SwapEndian(this.m_FileSize));
        w.Write(FifaUtil.SwapEndian(this.m_Unknown_0c));
      }
      else
      {
        w.Write(this.m_Signature);
        w.Write(this.m_FileOffset);
        w.Write(this.m_FileSize);
        w.Write(this.m_Unknown_0c);
      }
      return true;
    }

    public bool Is3dDirectory()
    {
      return this.m_Signature == 582139446U;
    }

    public bool IsTexture()
    {
      return this.m_Signature == 1879793882U;
    }

    public bool IsImageDirectory()
    {
      return this.m_Signature == 1808827868U;
    }
  }
}
