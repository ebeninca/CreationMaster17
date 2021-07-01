// Original code created by Rinaldo

using System.IO;

namespace FifaLibrary
{
  public class Rx3ImageHeader
  {
    private int m_FileSize;
    private byte m_Unknown_04;
    private byte m_ImageType;
    private short m_Unknown_06;
    private short m_Width;
    private short m_Height;
    private short m_Unknown_0C;
    private short m_NMipMaps;
    private bool m_SwapEndian;

    public int FileSize
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

    public EImageType ImageType
    {
      get
      {
        return (EImageType) this.m_ImageType;
      }
      set
      {
        this.m_ImageType = (byte) value;
      }
    }

    public short Width
    {
      get
      {
        return this.m_Width;
      }
      set
      {
        this.m_Width = value;
      }
    }

    public short Height
    {
      get
      {
        return this.m_Height;
      }
      set
      {
        this.m_Height = value;
      }
    }

    public short NMipMaps
    {
      get
      {
        return this.m_NMipMaps;
      }
      set
      {
        this.m_NMipMaps = value;
      }
    }

    public Rx3ImageHeader(BinaryReader r, bool swapEndian)
    {
      this.m_SwapEndian = swapEndian;
      this.Load(r);
    }

    public bool Load(BinaryReader r)
    {
      if (this.m_SwapEndian)
      {
        this.m_FileSize = FifaUtil.SwapEndian(r.ReadInt32());
        this.m_Unknown_04 = r.ReadByte();
        this.m_ImageType = r.ReadByte();
        this.m_Unknown_06 = FifaUtil.SwapEndian(r.ReadInt16());
        this.m_Width = FifaUtil.SwapEndian(r.ReadInt16());
        this.m_Height = FifaUtil.SwapEndian(r.ReadInt16());
        this.m_Unknown_0C = FifaUtil.SwapEndian(r.ReadInt16());
        this.m_NMipMaps = FifaUtil.SwapEndian(r.ReadInt16());
      }
      else
      {
        this.m_FileSize = r.ReadInt32();
        this.m_Unknown_04 = r.ReadByte();
        this.m_ImageType = r.ReadByte();
        this.m_Unknown_06 = r.ReadInt16();
        this.m_Width = r.ReadInt16();
        this.m_Height = r.ReadInt16();
        this.m_Unknown_0C = r.ReadInt16();
        this.m_NMipMaps = r.ReadInt16();
      }
      return true;
    }

    public bool Save(BinaryWriter w)
    {
      if (this.m_SwapEndian)
      {
        w.Write(FifaUtil.SwapEndian(this.m_FileSize));
        w.Write(this.m_Unknown_04);
        w.Write(this.m_ImageType);
        w.Write(FifaUtil.SwapEndian(this.m_Unknown_06));
        w.Write(FifaUtil.SwapEndian(this.m_Width));
        w.Write(FifaUtil.SwapEndian(this.m_Height));
        w.Write(FifaUtil.SwapEndian(this.m_Unknown_0C));
        w.Write(FifaUtil.SwapEndian(this.m_NMipMaps));
      }
      else
      {
        w.Write(this.m_FileSize);
        w.Write(this.m_Unknown_04);
        w.Write(this.m_ImageType);
        w.Write(this.m_Unknown_06);
        w.Write(this.m_Width);
        w.Write(this.m_Height);
        w.Write(this.m_Unknown_0C);
        w.Write(this.m_NMipMaps);
      }
      return true;
    }
  }
}
