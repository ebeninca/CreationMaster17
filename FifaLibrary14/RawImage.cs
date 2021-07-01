// Original code created by Rinaldo

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace FifaLibrary
{
  public class RawImage
  {
    private int m_Width;
    private int m_Height;
    private EImageType m_ImageType;
    protected bool m_SwapEndian;
    private Bitmap m_Bitmap;
    private bool m_NeedToSaveRawData;
    private byte[] m_RawData;
    protected int m_Size;

    public Bitmap Bitmap
    {
      get
      {
        if (this.m_Bitmap == null)
          this.CreateBitmap();
        return this.m_Bitmap;
      }
      set
      {
        this.m_Bitmap = value;
        this.m_NeedToSaveRawData = true;
      }
    }

    public RawImage(int width, int height, EImageType dxtType, int size)
    {
      this.m_Width = width;
      this.m_Height = height;
      this.m_ImageType = dxtType;
      this.m_Size = size;
      this.m_Bitmap = (Bitmap) null;
    }

    public bool Load(BinaryReader r)
    {
      int count = this.m_Size;
      if (this.m_ImageType == EImageType.A8R8G8B8)
        count = this.m_Width * this.m_Height * 4;
      int imageType = (int) this.m_ImageType;
      this.m_RawData = r.ReadBytes(count);
      this.m_NeedToSaveRawData = false;
      return true;
    }

    public bool Save(BinaryWriter w)
    {
      if (this.m_NeedToSaveRawData)
      {
        this.CreateRawData();
        this.m_NeedToSaveRawData = false;
      }
      w.Write(this.m_RawData);
      return true;
    }

    private void CreateBitmap()
    {
      if (this.m_Width < 1)
        this.m_Width = 1;
      if (this.m_Height < 1)
        this.m_Height = 1;
      switch (this.m_ImageType)
      {
        case EImageType.DXT1:
        case EImageType.DXT3:
        case EImageType.DXT5:
          this.m_Bitmap = new Bitmap(this.m_Width, this.m_Height, PixelFormat.Format32bppArgb);
          this.ReadDxtToBitmap();
          break;
        case EImageType.A8R8G8B8:
          this.m_Bitmap = new Bitmap(this.m_Width, this.m_Height, PixelFormat.Format32bppArgb);
          BitmapData bitmapdata = this.m_Bitmap.LockBits(new Rectangle(0, 0, this.m_Bitmap.Width, this.m_Bitmap.Height), ImageLockMode.WriteOnly, this.m_Bitmap.PixelFormat);
          Marshal.Copy(this.m_RawData, 0, bitmapdata.Scan0, this.m_Bitmap.Width * this.m_Bitmap.Height * 4);
          this.m_Bitmap.UnlockBits(bitmapdata);
          break;
        case EImageType.GREY8:
          this.m_Bitmap = new Bitmap(this.m_Width, this.m_Height, PixelFormat.Format32bppArgb);
          int num1 = 0;
          for (int y = 0; y < this.m_Bitmap.Height; ++y)
          {
            for (int x = 0; x < this.m_Bitmap.Width; ++x)
            {
              byte num2 = this.m_RawData[num1++];
              int maxValue = (int) byte.MaxValue;
              int red = (int) num2;
              int green = (int) num2;
              int blue = (int) num2;
              this.m_Bitmap.SetPixel(x, y, Color.FromArgb(maxValue, red, green, blue));
            }
          }
          break;
        case EImageType.GREY8ALFA8:
          this.m_Bitmap = new Bitmap(this.m_Width, this.m_Height, PixelFormat.Format32bppArgb);
          int num3 = 0;
          for (int y = 0; y < this.m_Bitmap.Height; ++y)
          {
            for (int x = 0; x < this.m_Bitmap.Width; ++x)
            {
              byte[] rawData1 = this.m_RawData;
              int index1 = num3;
              int num2 = index1 + 1;
              byte num4 = rawData1[index1];
              byte[] rawData2 = this.m_RawData;
              int index2 = num2;
              num3 = index2 + 1;
              int alpha = (int) rawData2[index2];
              int red = (int) num4;
              int green = (int) num4;
              int blue = (int) num4;
              this.m_Bitmap.SetPixel(x, y, Color.FromArgb(alpha, red, green, blue));
            }
          }
          break;
      }
    }

    private void CreateRawData()
    {
      if (this.m_Width < 1)
        this.m_Width = 1;
      if (this.m_Height < 1)
        this.m_Height = 1;
      switch (this.m_ImageType)
      {
        case EImageType.DXT1:
        case EImageType.DXT3:
        case EImageType.DXT5:
          this.WriteBitmapToDxt();
          break;
        case EImageType.A8R8G8B8:
          this.WriteBitmapToA8R8G8B8();
          break;
        case EImageType.GREY8:
          this.WriteBitmapToGrey8();
          break;
        case EImageType.GREY8ALFA8:
          this.WriteBitmapToGrey8Alfa8();
          break;
      }
    }

    private void ReadDxtToBitmap()
    {
      DxtBlock dxtBlock = new DxtBlock((int) this.m_ImageType);
      MemoryStream memoryStream = new MemoryStream(this.m_RawData);
      BinaryReader br = new BinaryReader((Stream) memoryStream);
      BitmapData bitmapdata = this.m_Bitmap.LockBits(new Rectangle(0, 0, this.m_Width, this.m_Height), ImageLockMode.WriteOnly, this.m_Bitmap.PixelFormat);
      IntPtr scan0 = bitmapdata.Scan0;
      int length = this.m_Bitmap.Width * this.m_Bitmap.Height;
      int[] source = new int[length];
      for (int index1 = 0; index1 < this.m_Bitmap.Height / 4; ++index1)
      {
        for (int index2 = 0; index2 < this.m_Bitmap.Width / 4; ++index2)
        {
          dxtBlock.Load(br);
          int index3 = index1 * 4 * this.m_Bitmap.Width + index2 * 4;
          source[index3] = dxtBlock.Colors[0, 0].ToArgb();
          source[index3 + 1] = dxtBlock.Colors[1, 0].ToArgb();
          source[index3 + 2] = dxtBlock.Colors[2, 0].ToArgb();
          source[index3 + 3] = dxtBlock.Colors[3, 0].ToArgb();
          int index4 = index3 + this.m_Bitmap.Width;
          source[index4] = dxtBlock.Colors[0, 1].ToArgb();
          source[index4 + 1] = dxtBlock.Colors[1, 1].ToArgb();
          source[index4 + 2] = dxtBlock.Colors[2, 1].ToArgb();
          source[index4 + 3] = dxtBlock.Colors[3, 1].ToArgb();
          int index5 = index4 + this.m_Bitmap.Width;
          source[index5] = dxtBlock.Colors[0, 2].ToArgb();
          source[index5 + 1] = dxtBlock.Colors[1, 2].ToArgb();
          source[index5 + 2] = dxtBlock.Colors[2, 2].ToArgb();
          source[index5 + 3] = dxtBlock.Colors[3, 2].ToArgb();
          int index6 = index5 + this.m_Bitmap.Width;
          source[index6] = dxtBlock.Colors[0, 3].ToArgb();
          source[index6 + 1] = dxtBlock.Colors[1, 3].ToArgb();
          source[index6 + 2] = dxtBlock.Colors[2, 3].ToArgb();
          source[index6 + 3] = dxtBlock.Colors[3, 3].ToArgb();
        }
      }
      Marshal.Copy(source, 0, scan0, length);
      this.m_Bitmap.UnlockBits(bitmapdata);
      br.Close();
      memoryStream.Close();
    }

    private void WriteBitmapToA8R8G8B8()
    {
      if (this.m_Bitmap.Height * this.m_Bitmap.Width * 4 > this.m_RawData.Length)
        return;
      int num1 = 0;
      for (int y = 0; y < this.m_Bitmap.Height; ++y)
      {
        for (int x = 0; x < this.m_Bitmap.Width; ++x)
        {
          Color pixel = this.m_Bitmap.GetPixel(x, y);
          byte b = pixel.B;
          byte g = pixel.G;
          byte r = pixel.R;
          byte a = pixel.A;
          byte[] rawData1 = this.m_RawData;
          int index1 = num1;
          int num2 = index1 + 1;
          int num3 = (int) b;
          rawData1[index1] = (byte) num3;
          byte[] rawData2 = this.m_RawData;
          int index2 = num2;
          int num4 = index2 + 1;
          int num5 = (int) g;
          rawData2[index2] = (byte) num5;
          byte[] rawData3 = this.m_RawData;
          int index3 = num4;
          int num6 = index3 + 1;
          int num7 = (int) r;
          rawData3[index3] = (byte) num7;
          byte[] rawData4 = this.m_RawData;
          int index4 = num6;
          num1 = index4 + 1;
          int num8 = (int) a;
          rawData4[index4] = (byte) num8;
        }
      }
    }

    private void WriteBitmapToDxt()
    {
      MemoryStream memoryStream = new MemoryStream(this.m_RawData);
      BinaryWriter bw = new BinaryWriter((Stream) memoryStream);
      DxtBlock dxtBlock = new DxtBlock((int) this.m_ImageType);
      int num1 = (this.m_Bitmap.Height + 3) / 4;
      int num2 = (this.m_Bitmap.Width + 3) / 4;
      if (this.m_Bitmap.Height < 4 || this.m_Bitmap.Width < 4)
      {
        dxtBlock.Colors[0, 0] = Color.FromArgb(0, 128, 128, 128);
        dxtBlock.Colors[0, 1] = Color.FromArgb(0, 128, 128, 128);
        dxtBlock.Colors[0, 2] = Color.FromArgb(0, 128, 128, 128);
        dxtBlock.Colors[0, 3] = Color.FromArgb(0, 128, 128, 128);
        dxtBlock.Colors[1, 0] = Color.FromArgb(0, 128, 128, 128);
        dxtBlock.Colors[1, 1] = Color.FromArgb(0, 128, 128, 128);
        dxtBlock.Colors[1, 2] = Color.FromArgb(0, 128, 128, 128);
        dxtBlock.Colors[1, 3] = Color.FromArgb(0, 128, 128, 128);
        dxtBlock.Colors[2, 0] = Color.FromArgb(0, 128, 128, 128);
        dxtBlock.Colors[2, 1] = Color.FromArgb(0, 128, 128, 128);
        dxtBlock.Colors[2, 2] = Color.FromArgb(0, 128, 128, 128);
        dxtBlock.Colors[2, 3] = Color.FromArgb(0, 128, 128, 128);
        dxtBlock.Colors[3, 0] = Color.FromArgb(0, 128, 128, 128);
        dxtBlock.Colors[3, 1] = Color.FromArgb(0, 128, 128, 128);
        dxtBlock.Colors[3, 2] = Color.FromArgb(0, 128, 128, 128);
        dxtBlock.Colors[3, 3] = Color.FromArgb(0, 128, 128, 128);
        for (int x = 0; x < this.m_Bitmap.Width; ++x)
        {
          for (int y = 0; y < this.m_Bitmap.Height; ++y)
          {
            if (x >= 0 && y >= 0 && (x < 4 && y < 4))
              dxtBlock.Colors[x, y] = this.m_Bitmap.GetPixel(x, y);
          }
        }
        dxtBlock.Save(bw);
      }
      else
      {
        for (int index1 = 0; index1 < num1; ++index1)
        {
          int y = index1 * 4;
          for (int index2 = 0; index2 < num2; ++index2)
          {
            int x = index2 * 4;
            dxtBlock.Colors[0, 0] = this.m_Bitmap.GetPixel(x, y);
            dxtBlock.Colors[0, 1] = this.m_Bitmap.GetPixel(x, y + 1);
            dxtBlock.Colors[0, 2] = this.m_Bitmap.GetPixel(x, y + 2);
            dxtBlock.Colors[0, 3] = this.m_Bitmap.GetPixel(x, y + 3);
            dxtBlock.Colors[1, 0] = this.m_Bitmap.GetPixel(x + 1, y);
            dxtBlock.Colors[1, 1] = this.m_Bitmap.GetPixel(x + 1, y + 1);
            dxtBlock.Colors[1, 2] = this.m_Bitmap.GetPixel(x + 1, y + 2);
            dxtBlock.Colors[1, 3] = this.m_Bitmap.GetPixel(x + 1, y + 3);
            dxtBlock.Colors[2, 0] = this.m_Bitmap.GetPixel(x + 2, y);
            dxtBlock.Colors[2, 1] = this.m_Bitmap.GetPixel(x + 2, y + 1);
            dxtBlock.Colors[2, 2] = this.m_Bitmap.GetPixel(x + 2, y + 2);
            dxtBlock.Colors[2, 3] = this.m_Bitmap.GetPixel(x + 2, y + 3);
            dxtBlock.Colors[3, 0] = this.m_Bitmap.GetPixel(x + 3, y);
            dxtBlock.Colors[3, 1] = this.m_Bitmap.GetPixel(x + 3, y + 1);
            dxtBlock.Colors[3, 2] = this.m_Bitmap.GetPixel(x + 3, y + 2);
            dxtBlock.Colors[3, 3] = this.m_Bitmap.GetPixel(x + 3, y + 3);
            dxtBlock.Save(bw);
          }
        }
      }
      bw.Close();
      memoryStream.Close();
    }

    private void WriteBitmapToGrey8()
    {
      if (this.m_Bitmap.Height * this.m_Bitmap.Width > this.m_RawData.Length)
        return;
      int num = 0;
      for (int y = 0; y < this.m_Bitmap.Height; ++y)
      {
        for (int x = 0; x < this.m_Bitmap.Width; ++x)
        {
          byte b = this.m_Bitmap.GetPixel(x, y).B;
          this.m_RawData[num++] = b;
        }
      }
    }

    private void WriteBitmapToGrey8Alfa8()
    {
      if (this.m_Bitmap.Height * this.m_Bitmap.Width * 4 > this.m_RawData.Length)
        return;
      int num = 0;
      for (int y = 0; y < this.m_Bitmap.Height; ++y)
      {
        for (int x = 0; x < this.m_Bitmap.Width; ++x)
        {
          byte b = this.m_Bitmap.GetPixel(x, y).B;
          this.m_RawData[num++] = b;
        }
      }
    }
  }
}
