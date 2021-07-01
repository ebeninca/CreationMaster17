// Original code created by Rinaldo

using System.IO;

namespace FifaLibrary
{
  public class UgcDirEntry
  {
    private uint m_Offset;
    private string m_FileName;

    public uint Offset
    {
      get
      {
        return this.m_Offset;
      }
    }

    public string FileName
    {
      get
      {
        return this.m_FileName;
      }
    }

    public override string ToString()
    {
      return Path.GetFileName(this.m_FileName);
    }

    public UgcDirEntry(BinaryReader r)
    {
      this.Load(r);
    }

    public bool Load(BinaryReader r)
    {
      r.ReadBytes(16);
      this.m_Offset = r.ReadUInt32();
      int num = (int) r.ReadInt16();
      this.m_FileName = FifaUtil.ReadNullPaddedString(r, 66);
      return true;
    }

    public bool IsPng()
    {
      return this.m_FileName.EndsWith("png");
    }

    public bool IsDb()
    {
      return this.m_FileName.EndsWith("db");
    }
  }
}
