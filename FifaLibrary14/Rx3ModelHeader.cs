// Original code created by Rinaldo

using System.IO;

namespace FifaLibrary
{
  public class Rx3ModelHeader
  {
    private int m_Unknown_00;
    private int m_Unknown_04;
    private int m_Unknown_08;
    private int m_Unknown_0c;
    private bool m_SwapEndian;

    public Rx3ModelHeader(BinaryReader r, bool swapEndian)
    {
      this.m_SwapEndian = swapEndian;
      this.Load(r);
    }

    public bool Load(BinaryReader r)
    {
      if (this.m_SwapEndian)
      {
        this.m_Unknown_00 = FifaUtil.SwapEndian(r.ReadInt32());
        this.m_Unknown_04 = FifaUtil.SwapEndian(r.ReadInt32());
        this.m_Unknown_08 = r.ReadInt32();
        this.m_Unknown_0c = r.ReadInt32();
      }
      else
      {
        this.m_Unknown_00 = r.ReadInt32();
        this.m_Unknown_04 = r.ReadInt32();
        this.m_Unknown_08 = r.ReadInt32();
        this.m_Unknown_0c = r.ReadInt32();
      }
      return true;
    }

    public bool Save(BinaryWriter w)
    {
      if (this.m_SwapEndian)
      {
        w.Write(FifaUtil.SwapEndian(this.m_Unknown_00));
        w.Write(FifaUtil.SwapEndian(this.m_Unknown_04));
        w.Write(this.m_Unknown_08);
        w.Write(this.m_Unknown_0c);
      }
      else
      {
        w.Write(this.m_Unknown_00);
        w.Write(this.m_Unknown_04);
        w.Write(this.m_Unknown_08);
        w.Write(this.m_Unknown_0c);
      }
      return true;
    }
  }
}
