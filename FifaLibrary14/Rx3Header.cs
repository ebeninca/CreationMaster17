// Original code created by Rinaldo

using System.IO;

namespace FifaLibrary
{
  public class Rx3Header
  {
    private string m_Signature;
    private int m_Unknown_04;
    private int m_SizeOf_;
    private int m_NFiles;
    private bool m_SwapEndian;

    public int SizeOf_
    {
      get
      {
        return this.m_SizeOf_;
      }
      set
      {
        this.m_SizeOf_ = value;
      }
    }

    public int NFiles
    {
      get
      {
        return this.m_NFiles;
      }
      set
      {
        this.m_NFiles = value;
      }
    }

    public Rx3Header(BinaryReader r, bool swapEndian)
    {
      this.m_SwapEndian = swapEndian;
      this.Load(r);
    }

    public bool Load(BinaryReader r)
    {
      this.m_Signature = new string(r.ReadChars(4));
      if (this.m_SwapEndian)
      {
        if (!(this.m_Signature == "RX3b"))
          return false;
        this.m_Unknown_04 = FifaUtil.SwapEndian(r.ReadInt32());
        this.m_SizeOf_ = FifaUtil.SwapEndian(r.ReadInt32());
        this.m_NFiles = FifaUtil.SwapEndian(r.ReadInt32());
      }
      else
      {
        if (!(this.m_Signature == "RX3l"))
          return false;
        this.m_Unknown_04 = r.ReadInt32();
        this.m_SizeOf_ = r.ReadInt32();
        this.m_NFiles = r.ReadInt32();
      }
      return true;
    }

    public bool Save(BinaryWriter w)
    {
      if (this.m_SwapEndian)
      {
        w.Write('R');
        w.Write('X');
        w.Write('3');
        w.Write('b');
        w.Write(FifaUtil.SwapEndian(this.m_Unknown_04));
        w.Write(FifaUtil.SwapEndian(this.m_SizeOf_));
        w.Write(FifaUtil.SwapEndian(this.m_NFiles));
      }
      else
      {
        w.Write('R');
        w.Write('X');
        w.Write('3');
        w.Write('l');
        w.Write(this.m_Unknown_04);
        w.Write(this.m_SizeOf_);
        w.Write(this.m_NFiles);
      }
      return true;
    }
  }
}
