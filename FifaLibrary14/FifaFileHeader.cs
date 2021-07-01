// Original code created by Rinaldo

using System.IO;

namespace FifaLibrary
{
  public class FifaFileHeader
  {
    private FifaBigFile m_BigFile;
    private uint m_StartPosition;
    private int m_Size;
    private string m_Name;

    public FifaBigFile BigFile
    {
      get
      {
        return this.m_BigFile;
      }
    }

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

    public string Name
    {
      get
      {
        return this.m_Name;
      }
      set
      {
        this.m_Name = value;
      }
    }

    public FifaFileHeader(FifaBigFile bigFile)
    {
      this.m_BigFile = bigFile;
    }

    public FifaFileHeader()
    {
      this.m_BigFile = (FifaBigFile) null;
      this.m_StartPosition = 0U;
      this.m_Name = (string) null;
      this.m_Size = 0;
    }

    public bool Load(BinaryReader r)
    {
      this.m_StartPosition = FifaUtil.SwapEndian(r.ReadUInt32());
      this.m_Size = FifaUtil.SwapEndian(r.ReadInt32());
      this.m_Name = FifaUtil.ReadNullTerminatedString(r);
      return true;
    }

    public bool Save(BinaryWriter w)
    {
      w.Write(FifaUtil.SwapEndian(this.m_StartPosition));
      w.Write(FifaUtil.SwapEndian(this.m_Size));
      FifaUtil.WriteNullTerminatedString(w, this.m_Name);
      return true;
    }
  }
}
