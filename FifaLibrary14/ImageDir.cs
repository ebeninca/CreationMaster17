// Original code created by Rinaldo

using System.IO;

namespace FifaLibrary
{
  public class ImageDir
  {
    private string m_Name;
    private int m_Offset;

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

    public ImageDir(BinaryReader r)
    {
      this.m_Name = new string(r.ReadChars(4));
      this.m_Offset = r.ReadInt32();
    }

    public void Save(BinaryWriter w)
    {
      char[] charArray = this.m_Name.ToCharArray();
      w.Write((byte) charArray[0]);
      w.Write((byte) charArray[1]);
      w.Write((byte) charArray[2]);
      w.Write((byte) charArray[3]);
      w.Write(this.m_Offset);
    }
  }
}
