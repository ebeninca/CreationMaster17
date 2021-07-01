// Original code created by Rinaldo

using System.Drawing;
using System.IO;

namespace FifaLibrary
{
  public class DdsFile
  {
    private string m_Signature;
    private uint m_HeaderSize;
    private uint m_HeaderFlags;
    private int m_Width;
    private int m_Height;
    private int m_PitchOrLinearSize;
    private int m_Depth;
    private int m_MipMapCount;
    private int m_PixelFormatSize;
    private int m_PixelFormatFlag;
    private int m_FourCC;
    private EImageType m_ImageType;
    private int m_RGBBitCount;
    private int m_RBitMask;
    private int m_GBitMask;
    private int m_BBitMask;
    private int m_ABitMask;
    private int m_SurfaceFlags;
    private int m_CubemapFlags;
    private RawImage[] m_RawImages;

    public DdsFile()
    {
    }

    public DdsFile(string fileName)
    {
      this.Load(fileName);
    }

    public DdsFile(FifaFile fifaFile)
    {
      this.Load(fifaFile);
    }

    public DdsFile(BinaryReader r)
    {
      this.Load(r);
    }

    public bool Load(FifaFile fifaFile)
    {
      if (fifaFile.IsCompressed)
        fifaFile.Decompress();
      BinaryReader reader = fifaFile.GetReader();
      bool flag = this.Load(reader);
      fifaFile.ReleaseReader(reader);
      return flag;
    }

    public bool Load(string fileName)
    {
      FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);
      BinaryReader r = new BinaryReader((Stream) fileStream);
      bool flag = this.Load(r);
      fileStream.Close();
      r.Close();
      return flag;
    }

    public bool Load(BinaryReader r)
    {
      this.m_Signature = new string(r.ReadChars(4));
      if (this.m_Signature != "DDS ")
        return false;
      this.m_HeaderSize = r.ReadUInt32();
      this.m_HeaderFlags = r.ReadUInt32();
      this.m_Height = r.ReadInt32();
      this.m_Width = r.ReadInt32();
      this.m_PitchOrLinearSize = r.ReadInt32();
      this.m_Depth = r.ReadInt32();
      this.m_MipMapCount = r.ReadInt32();
      for (int index = 0; index < 11; ++index)
        r.ReadInt32();
      this.m_PixelFormatSize = r.ReadInt32();
      this.m_PixelFormatFlag = r.ReadInt32();
      this.m_FourCC = r.ReadInt32();
      switch (this.m_FourCC)
      {
        case 0:
          this.m_ImageType = EImageType.A8R8G8B8;
          break;
        case 827611204:
          this.m_ImageType = EImageType.DXT1;
          break;
        case 861165636:
          this.m_ImageType = EImageType.DXT3;
          break;
        case 894720068:
          this.m_ImageType = EImageType.DXT5;
          break;
      }
      this.m_RGBBitCount = r.ReadInt32();
      this.m_RBitMask = r.ReadInt32();
      this.m_GBitMask = r.ReadInt32();
      this.m_BBitMask = r.ReadInt32();
      this.m_ABitMask = r.ReadInt32();
      this.m_SurfaceFlags = r.ReadInt32();
      this.m_CubemapFlags = r.ReadInt32();
      for (int index = 0; index < 3; ++index)
        r.ReadInt32();
      if (this.m_MipMapCount > 0)
      {
        int size = this.m_Width / 4 * this.m_Height / 4 * 16;
        int width = this.m_Width;
        int height = this.m_Height;
        this.m_RawImages = new RawImage[this.m_MipMapCount + 1];
        for (int index = 0; index <= this.m_MipMapCount; ++index)
        {
          this.m_RawImages[index] = new RawImage(width, height, this.m_ImageType, size);
          this.m_RawImages[index].Load(r);
          size /= 4;
          width /= 2;
          height /= 2;
        }
      }
      else
      {
        int size = (int) (r.BaseStream.Length - r.BaseStream.Position);
        this.m_RawImages = new RawImage[1];
        this.m_RawImages[0] = new RawImage(this.m_Width, this.m_Height, this.m_ImageType, size);
        this.m_RawImages[0].Load(r);
      }
      return true;
    }

    public bool Save(string fileName)
    {
      FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);
      BinaryWriter w = new BinaryWriter((Stream) fileStream);
      bool flag = this.Save(w);
      fileStream.Close();
      w.Close();
      return flag;
    }

    public bool Save(BinaryWriter w)
    {
      w.Write('D');
      w.Write('D');
      w.Write('S');
      w.Write(' ');
      w.Write(this.m_HeaderSize);
      w.Write(this.m_HeaderFlags);
      w.Write(this.m_Height);
      w.Write(this.m_Width);
      w.Write(this.m_PitchOrLinearSize);
      w.Write(this.m_Depth);
      w.Write(this.m_MipMapCount);
      for (int index = 0; index < 11; ++index)
        w.Write(0);
      w.Write(this.m_PixelFormatSize);
      w.Write(this.m_PixelFormatFlag);
      w.Write(this.m_FourCC);
      w.Write(this.m_RGBBitCount);
      w.Write(this.m_RBitMask);
      w.Write(this.m_GBitMask);
      w.Write(this.m_BBitMask);
      w.Write(this.m_ABitMask);
      w.Write(this.m_SurfaceFlags);
      w.Write(this.m_CubemapFlags);
      for (int index = 0; index < 3; ++index)
        w.Write(0);
      if (this.m_MipMapCount > 0)
      {
        for (int index = 0; index < this.m_MipMapCount + 1; ++index)
          this.m_RawImages[index].Save(w);
      }
      else
        this.m_RawImages[0].Save(w);
      return true;
    }

    public Bitmap GetBitmap()
    {
      return this.m_RawImages != null && this.m_RawImages.Length >= 1 ? this.m_RawImages[0].Bitmap : (Bitmap) null;
    }

    public void ReplaceBitmap(Bitmap bitmap)
    {
      if (this.m_MipMapCount > 0)
      {
        Bitmap srcBitmap = bitmap;
        this.m_RawImages[0].Bitmap = bitmap;
        for (int index = 1; index < this.m_MipMapCount + 1; ++index)
        {
          srcBitmap = GraphicUtil.ReduceBitmap(srcBitmap);
          this.m_RawImages[index].Bitmap = srcBitmap;
        }
      }
      else
        this.m_RawImages[0].Bitmap = bitmap;
    }
  }
}
