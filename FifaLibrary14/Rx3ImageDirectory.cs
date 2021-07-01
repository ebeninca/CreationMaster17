// Original code created by Rinaldo

using System.IO;

namespace FifaLibrary
{
  public class Rx3ImageDirectory
  {
    private int m_NFiles;
    private byte[] m_Padding;
    private FifaLibrary.Rx3ImageHeader[] m_Rx3ImageHeader;
    private bool m_SwapEndian;

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

    public FifaLibrary.Rx3ImageHeader[] Rx3ImageHeader
    {
      get
      {
        return this.m_Rx3ImageHeader;
      }
      set
      {
        this.m_Rx3ImageHeader = value;
      }
    }

    public Rx3ImageDirectory(BinaryReader r, bool swapEndian)
    {
      this.m_SwapEndian = swapEndian;
      this.Load(r);
    }

    public bool Load(BinaryReader r)
    {
      if (this.m_SwapEndian)
      {
        this.m_NFiles = FifaUtil.SwapEndian(r.ReadInt32());
        this.m_Padding = r.ReadBytes(12);
        this.m_Rx3ImageHeader = new FifaLibrary.Rx3ImageHeader[this.m_NFiles];
        for (int index = 0; index < this.m_NFiles; ++index)
          this.m_Rx3ImageHeader[index] = new FifaLibrary.Rx3ImageHeader(r, this.m_SwapEndian);
      }
      else
      {
        this.m_NFiles = r.ReadInt32();
        this.m_Padding = r.ReadBytes(12);
        this.m_Rx3ImageHeader = new FifaLibrary.Rx3ImageHeader[this.m_NFiles];
        for (int index = 0; index < this.m_NFiles; ++index)
          this.m_Rx3ImageHeader[index] = new FifaLibrary.Rx3ImageHeader(r, this.m_SwapEndian);
      }
      return true;
    }

    public bool Save(BinaryWriter w)
    {
      if (this.m_SwapEndian)
      {
        w.Write(FifaUtil.SwapEndian(this.m_NFiles));
        w.Write(this.m_Padding);
        for (int index = 0; index < this.m_NFiles; ++index)
          this.m_Rx3ImageHeader[index].Save(w);
      }
      else
      {
        w.Write(this.m_NFiles);
        w.Write(this.m_Padding);
        for (int index = 0; index < this.m_NFiles; ++index)
          this.m_Rx3ImageHeader[index].Save(w);
      }
      return true;
    }
  }
}
