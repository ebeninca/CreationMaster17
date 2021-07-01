// Original code created by Rinaldo

using System.Drawing;
using System.IO;

namespace FifaLibrary
{
  public class FshImage
  {
    private FshSection m_MainSection;
    private Fsh m_Parent;

    public Bitmap Bitmap
    {
      get
      {
        return this.m_MainSection.m_Bitmap;
      }
    }

    public FshImage(Fsh parent, BinaryReader r, int maxSize)
    {
      this.m_Parent = parent;
      this.m_MainSection = new FshSection(parent, r, maxSize);
      this.m_MainSection.RawDataToBmp();
    }

    public void Save(BinaryWriter w)
    {
      this.m_MainSection.Save(w);
    }

    public bool ReplaceBitmap(Bitmap bitmap)
    {
      return this.m_MainSection.ReplaceBitmap(bitmap);
    }

    public bool ReplaceRawData(byte[] rawData, int width, int height)
    {
      return this.m_MainSection.ReplaceRawData(rawData, width, height);
    }

    public byte[] GetRawData()
    {
      return this.m_MainSection.m_RawData;
    }

    public void Hash(string fileName)
    {
      for (FshSection nextSection = this.m_MainSection.NextSection; nextSection != null; nextSection = nextSection.NextSection)
      {
        if (nextSection.Type == 111)
        {
          nextSection.Hash(fileName);
          break;
        }
      }
    }

    public int ComputeLength()
    {
      int size = this.m_MainSection.m_Size;
      for (FshSection nextSection = this.m_MainSection.NextSection; nextSection != null; nextSection = nextSection.NextSection)
        size += nextSection.m_Size;
      return size;
    }
  }
}
