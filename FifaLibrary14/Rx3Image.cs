// Original code created by Rinaldo

using System.Drawing;
using System.IO;

namespace FifaLibrary
{
  public class Rx3Image
  {
    private Rx3ImageHeader m_Header;
    private MipMap[] m_MipMapImage;
    private bool m_SwapEndian;

    public Rx3ImageHeader Header
    {
      get
      {
        return this.m_Header;
      }
      set
      {
        this.m_Header = value;
      }
    }

    public Bitmap GetBitmap()
    {
      return this.m_MipMapImage[0].Bitmap;
    }

    public Bitmap GetBitmap(int mipMapLevel)
    {
      return mipMapLevel >= this.m_MipMapImage.Length ? (Bitmap) null : this.m_MipMapImage[mipMapLevel].Bitmap;
    }

    public bool SetBitmap(Bitmap bitmap)
    {
      if (bitmap == null || bitmap.Width != (int) this.m_Header.Width || bitmap.Width != (int) this.m_Header.Width)
        return false;
      Bitmap srcBitmap = bitmap;
      this.m_MipMapImage[0].Bitmap = srcBitmap;
      for (int index = 1; index < (int) this.m_Header.NMipMaps; ++index)
      {
        srcBitmap = GraphicUtil.ReduceBitmap(srcBitmap);
        this.m_MipMapImage[index].Bitmap = srcBitmap;
      }
      return true;
    }

    public Rx3Image(BinaryReader r, bool swapEndian)
    {
      this.m_SwapEndian = swapEndian;
      this.m_Header = new Rx3ImageHeader(r, this.m_SwapEndian);
      this.Load(r);
    }

    public bool Load(BinaryReader r)
    {
      this.m_MipMapImage = new MipMap[(int) this.m_Header.NMipMaps];
      int width = (int) this.m_Header.Width;
      int height = (int) this.m_Header.Height;
      for (int index = 0; index < (int) this.m_Header.NMipMaps; ++index)
      {
        this.m_MipMapImage[index] = new MipMap(width, height, this.m_Header.ImageType, this.m_SwapEndian);
        this.m_MipMapImage[index].Load(r);
        width /= 2;
        height /= 2;
      }
      return true;
    }

    public bool Save(BinaryWriter w)
    {
      this.m_Header.Save(w);
      for (int index = 0; index < (int) this.m_Header.NMipMaps; ++index)
        this.m_MipMapImage[index].Save(w);
      return true;
    }
  }
}
