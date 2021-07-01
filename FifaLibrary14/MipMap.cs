// Original code created by Rinaldo

using System.IO;

namespace FifaLibrary
{
  public class MipMap : RawImage
  {
    private int m_Unknown0;
    private int m_Unknown4;
    private int m_UnknownC;

    public MipMap(int width, int height, EImageType dxtType, bool swapEndian)
      : base(width, height, dxtType, 0)
    {
      this.m_SwapEndian = swapEndian;
    }

    public new bool Load(BinaryReader r)
    {
      if (this.m_SwapEndian)
      {
        this.m_Unknown0 = FifaUtil.SwapEndian(r.ReadInt32());
        this.m_Unknown4 = FifaUtil.SwapEndian(r.ReadInt32());
        this.m_Size = FifaUtil.SwapEndian(r.ReadInt32());
        this.m_UnknownC = FifaUtil.SwapEndian(r.ReadInt32());
        base.Load(r);
      }
      else
      {
        this.m_Unknown0 = r.ReadInt32();
        this.m_Unknown4 = r.ReadInt32();
        this.m_Size = r.ReadInt32();
        this.m_UnknownC = r.ReadInt32();
        base.Load(r);
      }
      return true;
    }

    public new bool Save(BinaryWriter w)
    {
      if (this.m_SwapEndian)
      {
        w.Write(FifaUtil.SwapEndian(this.m_Unknown0));
        w.Write(FifaUtil.SwapEndian(this.m_Unknown4));
        w.Write(FifaUtil.SwapEndian(this.m_Size));
        w.Write(FifaUtil.SwapEndian(this.m_UnknownC));
        base.Save(w);
      }
      else
      {
        w.Write(this.m_Unknown0);
        w.Write(this.m_Unknown4);
        w.Write(this.m_Size);
        w.Write(this.m_UnknownC);
        base.Save(w);
      }
      return true;
    }
  }
}
