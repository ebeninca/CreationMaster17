// Original code created by Rinaldo

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace FifaLibrary
{
  public class FshSection
  {
    public short[] m_Misc = new short[4];
    private Fsh m_Parent;
    private int m_Type;
    public bool m_IsCompressed;
    public bool m_IsBitmap;
    public Bitmap m_Bitmap;
    public bool m_IsPalette;
    public Color[] m_Palette;
    public int m_NextOffset;
    public int m_Size;
    private FshSection m_NextSection;
    public short m_Width;
    public short m_Height;
    public int m_NScales;
    public byte[] m_RawData;
    public byte[] PadData;

    public int Type
    {
      get
      {
        return this.m_Type;
      }
    }

    public FshSection NextSection
    {
      get
      {
        return this.m_NextSection;
      }
    }

    public FshSection(Fsh parent, BinaryReader r, int maxSize)
    {
      this.m_Parent = parent;
      int num = r.ReadInt32();
      this.m_NextOffset = num >> 8 & 16777215;
      maxSize -= this.m_NextOffset;
      this.m_Type = num & (int) sbyte.MaxValue;
      this.m_IsCompressed = (num & 128) != 0;
      this.m_IsPalette = false;
      this.m_Size = this.m_NextOffset == 0 ? maxSize : this.m_NextOffset;
      switch (this.m_Type)
      {
        case 36:
        case 42:
          this.m_Width = r.ReadInt16();
          this.m_Height = r.ReadInt16();
          this.m_Misc[0] = r.ReadInt16();
          this.m_Misc[1] = r.ReadInt16();
          this.m_Misc[2] = r.ReadInt16();
          this.m_Misc[3] = r.ReadInt16();
          this.m_IsPalette = true;
          int count1 = this.m_Size - 16;
          this.m_RawData = r.ReadBytes(count1);
          break;
        case 96:
        case 97:
        case 98:
        case 109:
        case 120:
        case 123:
        case 125:
        case 126:
        case (int) sbyte.MaxValue:
          this.m_Width = r.ReadInt16();
          this.m_Height = r.ReadInt16();
          this.m_Misc[0] = r.ReadInt16();
          this.m_Misc[1] = r.ReadInt16();
          this.m_Misc[2] = r.ReadInt16();
          this.m_Misc[3] = r.ReadInt16();
          this.m_NScales = (int) this.m_Misc[3] >> 12 & 15;
          int count2 = this.m_Size - 16;
          this.m_RawData = r.ReadBytes(count2);
          break;
        case 105:
          this.m_Width = r.ReadInt16();
          this.m_Height = r.ReadInt16();
          this.m_Misc[0] = r.ReadInt16();
          this.m_Misc[1] = r.ReadInt16();
          this.m_Misc[2] = r.ReadInt16();
          this.m_Misc[3] = r.ReadInt16();
          int count3 = this.m_Size - 16;
          this.m_RawData = r.ReadBytes(count3);
          break;
        case 111:
          this.m_Width = r.ReadInt16();
          this.m_Height = r.ReadInt16();
          int count4 = this.m_Size - 8;
          this.m_RawData = r.ReadBytes(count4);
          break;
        case 112:
          int count5 = this.m_Size - 4;
          this.m_RawData = r.ReadBytes(count5);
          break;
        case 124:
          this.m_Width = r.ReadInt16();
          this.m_Height = r.ReadInt16();
          int count6 = this.m_Size - 8;
          this.m_RawData = r.ReadBytes(count6);
          break;
      }
      if (this.m_NextOffset == 0)
        return;
      this.m_NextSection = new FshSection(this.m_Parent, r, maxSize);
    }

    public FshSection(BinaryReader r)
    {
      int count = (int) (r.BaseStream.Length - r.BaseStream.Position);
      this.m_RawData = r.ReadBytes(count);
    }

    public void Save(BinaryWriter w)
    {
      int num = 0 | (this.m_NextOffset & 16777215) << 8 | (this.m_IsCompressed ? 128 : 0) | this.m_Type & (int) sbyte.MaxValue;
      w.Write(num);
      switch (this.m_Type)
      {
        case 36:
        case 42:
        case 96:
        case 97:
        case 98:
        case 105:
        case 109:
        case 120:
        case 123:
        case 125:
        case 126:
        case (int) sbyte.MaxValue:
          w.Write(this.m_Width);
          w.Write(this.m_Height);
          w.Write(this.m_Misc[0]);
          w.Write(this.m_Misc[1]);
          w.Write(this.m_Misc[2]);
          this.m_Misc[3] = (short) ((int) this.m_Misc[3] & 4095 | this.m_NScales << 12);
          w.Write(this.m_Misc[3]);
          w.Write(this.m_RawData);
          break;
        case 111:
        case 124:
          w.Write(this.m_Width);
          w.Write(this.m_Height);
          w.Write(this.m_RawData);
          break;
        case 112:
          w.Write(this.m_RawData);
          break;
      }
      if (this.m_NextOffset == 0)
        return;
      this.m_NextSection.Save(w);
    }

    public Color[] RawDataToPalette()
    {
      if (!this.m_IsPalette)
        return (Color[]) null;
      Color[] colorArray = new Color[(int) this.m_Width];
      switch (this.m_Type)
      {
        case 36:
          for (int index = 0; index < (int) this.m_Width; ++index)
            colorArray[index] = Color.FromArgb((int) this.m_RawData[index * 3], (int) this.m_RawData[index * 3 + 1], (int) this.m_RawData[index * 3 + 2]);
          break;
        case 42:
          for (int index = 0; index < (int) this.m_Width; ++index)
            colorArray[index] = Color.FromArgb((int) this.m_RawData[index * 4], (int) this.m_RawData[index * 4 + 1], (int) this.m_RawData[index * 4 + 2], (int) this.m_RawData[index * 4 + 3]);
          break;
        default:
          return (Color[]) null;
      }
      return colorArray;
    }

    public int ComputeRawDataLength(int width, int height)
    {
      int num1 = 0;
      int num2 = 0;
      for (int index = 0; index <= this.m_NScales; ++index)
      {
        switch (this.m_Type)
        {
          case 96:
            num1 = (width + 3) / 4 * ((height + 3) / 4) * 8;
            break;
          case 97:
          case 98:
            num1 = (width + 3) / 4 * ((height + 3) / 4) * 16;
            break;
          case 109:
          case 120:
          case 126:
            num1 = width * height * 2;
            break;
          case 123:
            num1 = width * height;
            break;
          case 125:
            num1 = width * height * 4;
            break;
          case (int) sbyte.MaxValue:
            num1 = width * height * 3;
            break;
        }
        num2 += num1;
        width /= 2;
        height /= 2;
      }
      int num3 = num2 & 15;
      if (num3 != 0)
        num2 += 16 - num3;
      return num2;
    }

    public Bitmap RawDataToBmp()
    {
      int num1 = this.m_IsCompressed ? 1 : 0;
      this.m_Bitmap = new Bitmap((int) this.m_Width, (int) this.m_Height, PixelFormat.Format32bppArgb);
      Stream stream = (Stream) new MemoryStream(this.m_RawData);
      BinaryReader br = new BinaryReader(stream);
      BinaryWriter binaryWriter = new BinaryWriter(stream);
      switch (this.m_Type)
      {
        case 96:
          this.ReadDxtToBitmap(1, br);
          break;
        case 97:
          this.ReadDxtToBitmap(3, br);
          break;
        case 98:
          this.ReadDxtToBitmap(5, br);
          break;
        case 109:
          for (int y = 0; y < this.m_Bitmap.Height; ++y)
          {
            for (int x = 0; x < this.m_Bitmap.Width; ++x)
            {
              ushort num2 = br.ReadUInt16();
              int blue = ((int) num2 & 15) * 16;
              int green = ((int) num2 >> 4 & 15) * 16;
              int red = ((int) num2 >> 8 & 15) * 16;
              int alpha = ((int) num2 >> 12 & 15) * 16;
              this.m_Bitmap.SetPixel(x, y, Color.FromArgb(alpha, red, green, blue));
            }
          }
          break;
        case 120:
          for (int y = 0; y < this.m_Bitmap.Height; ++y)
          {
            for (int x = 0; x < this.m_Bitmap.Width; ++x)
            {
              ushort num2 = br.ReadUInt16();
              int blue = ((int) num2 & 31) * 8;
              int green = ((int) num2 >> 5 & 63) * 4;
              int red = ((int) num2 >> 11 & 31) * 8;
              this.m_Bitmap.SetPixel(x, y, Color.FromArgb(red, green, blue));
            }
          }
          break;
        case 123:
          for (FshSection nextSection = this.m_NextSection; nextSection != null; nextSection = nextSection.m_NextSection)
          {
            this.m_Palette = nextSection.RawDataToPalette();
            if (this.m_Palette != null)
              break;
          }
          if (this.m_Palette != null)
          {
            for (int y = 0; y < this.m_Bitmap.Height; ++y)
            {
              for (int x = 0; x < this.m_Bitmap.Width; ++x)
              {
                int index = (int) br.ReadByte();
                this.m_Bitmap.SetPixel(x, y, this.m_Palette[index]);
              }
            }
            break;
          }
          break;
        case 125:
          BitmapData bitmapdata = this.m_Bitmap.LockBits(new Rectangle(0, 0, this.m_Bitmap.Width, this.m_Bitmap.Height), ImageLockMode.WriteOnly, this.m_Bitmap.PixelFormat);
          Marshal.Copy(this.m_RawData, 0, bitmapdata.Scan0, this.m_Bitmap.Width * this.m_Bitmap.Height * 4);
          this.m_Bitmap.UnlockBits(bitmapdata);
          break;
        case 126:
          for (int y = 0; y < this.m_Bitmap.Height; ++y)
          {
            for (int x = 0; x < this.m_Bitmap.Width; ++x)
            {
              ushort num2 = br.ReadUInt16();
              int blue = ((int) num2 & 31) * 8;
              int green = ((int) num2 >> 5 & 31) * 8;
              int red = ((int) num2 >> 10 & 31) * 8;
              int alpha = ((int) num2 & 32768) != 0 ? (int) byte.MaxValue : 0;
              this.m_Bitmap.SetPixel(x, y, Color.FromArgb(alpha, red, green, blue));
            }
          }
          break;
        case (int) sbyte.MaxValue:
          for (int y = 0; y < this.m_Bitmap.Height; ++y)
          {
            for (int x = 0; x < this.m_Bitmap.Width; ++x)
            {
              int blue = (int) br.ReadByte();
              int green = (int) br.ReadByte();
              int red = (int) br.ReadByte();
              this.m_Bitmap.SetPixel(x, y, Color.FromArgb(red, green, blue));
            }
          }
          break;
      }
      return this.m_Bitmap;
    }

    public bool WriteBitmap(Bitmap bitmap, BinaryWriter bw)
    {
      switch (this.m_Type)
      {
        case 96:
          return this.WriteBitmapToDxt(bitmap, 1, bw);
        case 97:
          return this.WriteBitmapToDxt(bitmap, 3, bw);
        case 98:
          return this.WriteBitmapToDxt(bitmap, 5, bw);
        case 109:
          for (int y = 0; y < bitmap.Height; ++y)
          {
            for (int x = 0; x < bitmap.Width; ++x)
            {
              Color pixel = bitmap.GetPixel(x, y);
              ushort num = (ushort) ((uint) (ushort) ((uint) (ushort) ((uint) (ushort) (0U | (uint) (ushort) (((int) pixel.B & 240) >> 4)) | (uint) (ushort) ((uint) pixel.G & 240U)) | (uint) (ushort) (((int) pixel.R & 240) << 4)) | (uint) (ushort) (((int) pixel.A & 240) << 8));
              bw.Write(num);
            }
          }
          break;
        case 120:
          for (int y = 0; y < bitmap.Height; ++y)
          {
            for (int x = 0; x < bitmap.Width; ++x)
            {
              Color pixel = bitmap.GetPixel(x, y);
              ushort num = (ushort) ((uint) (ushort) ((uint) (ushort) (0U | (uint) (ushort) (((int) pixel.B & 248) >> 3)) | (uint) (ushort) (((int) pixel.G & 252) << 3)) | (uint) (ushort) (((int) pixel.R & 248) << 8));
              bw.Write(num);
            }
          }
          break;
        case 123:
          if (this.m_Palette == null)
            return false;
          for (int y = 0; y < bitmap.Height; ++y)
          {
            for (int x = 0; x < bitmap.Width; ++x)
            {
              Color pixel = bitmap.GetPixel(x, y);
              byte num = 0;
              for (int index = 0; index < this.m_Palette.Length; ++index)
              {
                if (pixel == this.m_Palette[index])
                {
                  num = (byte) index;
                  break;
                }
              }
              bw.Write(num);
            }
          }
          break;
        case 125:
          for (int y = 0; y < bitmap.Height; ++y)
          {
            for (int x = 0; x < bitmap.Width; ++x)
            {
              Color pixel = bitmap.GetPixel(x, y);
              byte b = pixel.B;
              byte g = pixel.G;
              byte r = pixel.R;
              byte a = pixel.A;
              bw.Write(b);
              bw.Write(g);
              bw.Write(r);
              bw.Write(a);
            }
          }
          break;
        case 126:
          for (int y = 0; y < bitmap.Height; ++y)
          {
            for (int x = 0; x < bitmap.Width; ++x)
            {
              Color pixel = bitmap.GetPixel(x, y);
              byte b = pixel.B;
              byte g = pixel.G;
              byte r = pixel.R;
              byte a = pixel.A;
              ushort num = (ushort) ((uint) (ushort) ((uint) (ushort) (0U | (uint) (ushort) (((int) b & 248) >> 3)) | (uint) (ushort) (((int) g & 248) << 2)) | (uint) (ushort) (((int) r & 248) << 7));
              if (a != (byte) 0)
                num |= (ushort) 32768;
              bw.Write(num);
            }
          }
          break;
        case (int) sbyte.MaxValue:
          for (int y = 0; y < bitmap.Height; ++y)
          {
            for (int x = 0; x < bitmap.Width; ++x)
            {
              Color pixel = bitmap.GetPixel(x, y);
              byte b = pixel.B;
              byte g = pixel.G;
              byte r = pixel.R;
              bw.Write(b);
              bw.Write(g);
              bw.Write(r);
            }
          }
          break;
      }
      return true;
    }

    public bool BitmapToRawData()
    {
      int rawDataLength = this.ComputeRawDataLength(this.m_Bitmap.Width, this.m_Bitmap.Height);
      if (rawDataLength != this.m_RawData.Length)
      {
        this.m_RawData = new byte[rawDataLength];
        this.m_Size = rawDataLength + 16;
        this.m_NextOffset = this.m_NextSection == null ? 0 : this.m_Size;
        this.m_Height = (short) this.m_Bitmap.Height;
        this.m_Width = (short) this.m_Bitmap.Width;
        this.m_Parent.ComputeImageDir();
      }
      BinaryWriter bw = new BinaryWriter((Stream) new MemoryStream(this.m_RawData));
      Bitmap bitmap = this.m_Bitmap;
      int num = (1 << this.m_NScales) - 1;
      if ((this.m_Bitmap.Width & num | this.m_Bitmap.Height & num) != 0)
        this.m_NScales = 0;
      for (int index = 0; index <= this.m_NScales; ++index)
      {
        if (!this.WriteBitmap(bitmap, bw))
          return false;
        if (index < this.m_NScales)
        {
          bitmap = GraphicUtil.ReduceBitmap(bitmap);
          if (bitmap == null)
          {
            this.m_NScales = index - 1;
            break;
          }
        }
      }
      return true;
    }

    public bool ReplaceRawData(byte[] rawData, int width, int height)
    {
      int length = rawData.Length;
      if (length != this.m_RawData.Length)
      {
        this.m_RawData = new byte[length];
        this.m_Size = length + 16;
        this.m_NextOffset = this.m_NextSection == null ? 0 : this.m_Size;
        this.m_Height = (short) width;
        this.m_Width = (short) height;
        this.m_Parent.ComputeImageDir();
      }
      for (int index = 0; index < this.m_RawData.Length; ++index)
        this.m_RawData[index] = rawData[index];
      return true;
    }

    private void ReadDxtToBitmap(int dxtType, BinaryReader br)
    {
      DxtBlock dxtBlock = new DxtBlock(dxtType);
      BitmapData bitmapdata = this.m_Bitmap.LockBits(new Rectangle(0, 0, this.m_Bitmap.Width, this.m_Bitmap.Height), ImageLockMode.WriteOnly, this.m_Bitmap.PixelFormat);
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
    }

    private bool WriteBitmapToDxt(Bitmap bitmap, int dxtType, BinaryWriter bw)
    {
      if ((bitmap.Height & 3 | bitmap.Width & 3) != 0)
        return false;
      DxtBlock dxtBlock = new DxtBlock(dxtType);
      int num1 = (bitmap.Height + 3) / 4;
      int num2 = (bitmap.Width + 3) / 4;
      for (int index1 = 0; index1 < num1; ++index1)
      {
        int y = index1 * 4;
        for (int index2 = 0; index2 < num2; ++index2)
        {
          int x = index2 * 4;
          dxtBlock.Colors[0, 0] = bitmap.GetPixel(x, y);
          dxtBlock.Colors[0, 1] = bitmap.GetPixel(x, y + 1);
          dxtBlock.Colors[0, 2] = bitmap.GetPixel(x, y + 2);
          dxtBlock.Colors[0, 3] = bitmap.GetPixel(x, y + 3);
          dxtBlock.Colors[1, 0] = bitmap.GetPixel(x + 1, y);
          dxtBlock.Colors[1, 1] = bitmap.GetPixel(x + 1, y + 1);
          dxtBlock.Colors[1, 2] = bitmap.GetPixel(x + 1, y + 2);
          dxtBlock.Colors[1, 3] = bitmap.GetPixel(x + 1, y + 3);
          dxtBlock.Colors[2, 0] = bitmap.GetPixel(x + 2, y);
          dxtBlock.Colors[2, 1] = bitmap.GetPixel(x + 2, y + 1);
          dxtBlock.Colors[2, 2] = bitmap.GetPixel(x + 2, y + 2);
          dxtBlock.Colors[2, 3] = bitmap.GetPixel(x + 2, y + 3);
          dxtBlock.Colors[3, 0] = bitmap.GetPixel(x + 3, y);
          dxtBlock.Colors[3, 1] = bitmap.GetPixel(x + 3, y + 1);
          dxtBlock.Colors[3, 2] = bitmap.GetPixel(x + 3, y + 2);
          dxtBlock.Colors[3, 3] = bitmap.GetPixel(x + 3, y + 3);
          dxtBlock.Save(bw);
        }
      }
      return true;
    }

    public bool ReplaceBitmap(Bitmap bitmap)
    {
      if (bitmap == null)
        return false;
      this.m_Bitmap = bitmap;
      this.BitmapToRawData();
      return true;
    }

    public void Hash(string fileName)
    {
      if (this.m_Type != 111)
        return;
      char[] charArray = FifaUtil.ComputeHash(fileName).ToString("x8").ToCharArray();
      for (int index1 = 0; index1 < this.m_RawData.Length - 11; ++index1)
      {
        if (this.m_RawData[index1] == (byte) 44 && this.m_RawData[index1 + 1] == (byte) 48 && this.m_RawData[index1 + 2] == (byte) 120)
        {
          int num = index1 + 3;
          for (int index2 = 0; index2 < 8; ++index2)
            this.m_RawData[num + index2] = (byte) charArray[index2];
          break;
        }
      }
    }
  }
}
