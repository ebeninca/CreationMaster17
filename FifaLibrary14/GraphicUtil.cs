// Original code created by Rinaldo

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FifaLibrary
{
  public class GraphicUtil
  {
    public static Bitmap ReduceBitmap(Bitmap srcBitmap)
    {
      int width1 = srcBitmap.Width;
      int height1 = srcBitmap.Height;
      if (width1 * height1 == 0)
        return (Bitmap) null;
      int width2 = width1 / 2;
      int height2 = height1 / 2;
      if (width2 == 0)
        width2 = 1;
      if (height2 == 0)
        height2 = 1;
      return GraphicUtil.ResizeBitmap(srcBitmap, width2, height2, InterpolationMode.HighQualityBicubic);
    }

    public static Bitmap RemapBitmap(Bitmap srcBitmap, int destWidth, int destHeight)
    {
      Bitmap bitmap = new Bitmap(destWidth, destHeight, PixelFormat.Format32bppArgb);
      int width = srcBitmap.Width;
      int height = srcBitmap.Height;
      float num1 = (float) width / (float) destWidth;
      float num2 = (float) height / (float) destHeight;
      for (int x = 0; x < destWidth; ++x)
      {
        for (int y = 0; y < destHeight; ++y)
          bitmap.SetPixel(x, y, GraphicUtil.RemapPixel(srcBitmap, (float) x * num1, (float) y * num2));
      }
      return bitmap;
    }

    private static Color RemapPixel(Bitmap srcBitmap, float x, float y)
    {
      int num1 = (int) Math.Floor((double) x);
      int num2 = (int) Math.Floor((double) y);
      int x1 = num1 < srcBitmap.Width ? num1 : srcBitmap.Width - 1;
      int x2 = num1 + 1 < srcBitmap.Width ? num1 + 1 : srcBitmap.Width - 1;
      int y1 = num2 < srcBitmap.Height ? num2 : srcBitmap.Height - 1;
      int y2 = num2 + 1 < srcBitmap.Height ? num2 + 1 : srcBitmap.Height - 1;
      Color pixel1 = srcBitmap.GetPixel(x1, y1);
      Color pixel2 = srcBitmap.GetPixel(x2, y1);
      Color pixel3 = srcBitmap.GetPixel(x1, y2);
      Color pixel4 = srcBitmap.GetPixel(x2, y2);
      float num3 = x - (float) num1;
      float num4 = y - (float) num2;
      float num5 = (float) ((1.0 - (double) num3) * (1.0 - (double) num4));
      float num6 = num3 * (1f - num4);
      float num7 = (1f - num3) * num4;
      float num8 = num3 * num4;
      int red = (int) ((double) pixel1.R * (double) num5 + (double) pixel2.R * (double) num6 + (double) pixel3.R * (double) num7 + (double) pixel4.R * (double) num8);
      int green = (int) ((double) pixel1.G * (double) num5 + (double) pixel2.G * (double) num6 + (double) pixel3.G * (double) num7 + (double) pixel4.G * (double) num8);
      int blue = (int) ((double) pixel1.B * (double) num5 + (double) pixel2.B * (double) num6 + (double) pixel3.B * (double) num7 + (double) pixel4.B * (double) num8);
      return Color.FromArgb((int) ((double) pixel1.A * (double) num5 + (double) pixel2.A * (double) num6 + (double) pixel3.A * (double) num7 + (double) pixel4.A * (double) num8), red, green, blue);
    }

    public static void LoadPictureImage(PictureBox picture, Bitmap bitmap)
    {
      if (bitmap == null)
        picture.Image = (Image) bitmap;
      else if (picture.Width == bitmap.Width && picture.Height == bitmap.Height)
        picture.Image = (Image) bitmap;
      else
        picture.Image = (Image) GraphicUtil.RemapBitmap(bitmap, picture.Width, picture.Height);
    }

    public static Bitmap ResizeBitmap(
      Bitmap sourceBitmap,
      int width,
      int height,
      InterpolationMode interpolationMode)
    {
      if (sourceBitmap == null)
        return (Bitmap) null;
      if (width < 0)
        width = -width;
      if (height < 0)
        height = -height;
      if (width == 0 || height == 0)
        return (Bitmap) null;
      if (sourceBitmap.Width == width && sourceBitmap.Height == height)
        return sourceBitmap;
      Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      graphics.InterpolationMode = interpolationMode;
      graphics.DrawImage((Image) sourceBitmap, new Rectangle(0, 0, width, height), 0, 0, sourceBitmap.Width, sourceBitmap.Height, GraphicsUnit.Pixel);
      graphics.Dispose();
      return bitmap;
    }

    public static Bitmap CanvasSizeBitmap(Bitmap sourceBitmap, int width, int height)
    {
      if (sourceBitmap == null)
        return (Bitmap) null;
      Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      graphics.DrawImage((Image) sourceBitmap, new Rectangle(0, 0, width, height), 0, 0, width, height, GraphicsUnit.Pixel);
      graphics.Dispose();
      return bitmap;
    }

    public static Bitmap CanvasSizeBitmapCentered(Bitmap sourceBitmap, int width, int height)
    {
      if (sourceBitmap == null)
        return (Bitmap) null;
      if (width > sourceBitmap.Width || height > sourceBitmap.Height)
        return (Bitmap) null;
      int num1 = (sourceBitmap.Width - width) / 2;
      int num2 = (sourceBitmap.Height - height) / 2;
      Bitmap bitmap = new Bitmap(width, height, sourceBitmap.PixelFormat);
      Rectangle rect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);
      BitmapData bitmapdata1 = sourceBitmap.LockBits(rect, ImageLockMode.ReadOnly, sourceBitmap.PixelFormat);
      rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
      BitmapData bitmapdata2 = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
      IntPtr scan0_1 = bitmapdata1.Scan0;
      IntPtr scan0_2 = bitmapdata2.Scan0;
      int length1 = sourceBitmap.Width * sourceBitmap.Height;
      int length2 = bitmap.Width * bitmap.Height;
      int[] destination = new int[length1];
      int[] numArray = new int[length2];
      Marshal.Copy(scan0_1, destination, 0, length1);
      Marshal.Copy(scan0_2, numArray, 0, length2);
      int index1 = 0;
      int index2 = num2 * sourceBitmap.Width + num1;
      for (int index3 = 0; index3 < bitmap.Height; ++index3)
      {
        for (int index4 = 0; index4 < bitmap.Width; ++index4)
        {
          numArray[index1] = destination[index2];
          ++index1;
          ++index2;
        }
        index2 += num1 * 2;
      }
      Marshal.Copy(numArray, 0, scan0_2, length2);
      sourceBitmap.UnlockBits(bitmapdata1);
      bitmap.UnlockBits(bitmapdata2);
      return bitmap;
    }

    public static Bitmap Get32bitBitmap(Bitmap sourceBitmap)
    {
      Bitmap bitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height, PixelFormat.Format32bppArgb);
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      graphics.DrawImage((Image) sourceBitmap, 0, 0, sourceBitmap.Width, sourceBitmap.Height);
      graphics.Dispose();
      return bitmap;
    }

    public static bool GetAlfaFromChannel(Bitmap sourceBitmap, Bitmap alfaBitmap, int channel)
    {
      if (sourceBitmap.Width != alfaBitmap.Width || sourceBitmap.Height != alfaBitmap.Height)
        return false;
      Rectangle rect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);
      BitmapData bitmapdata1 = sourceBitmap.LockBits(rect, ImageLockMode.ReadWrite, sourceBitmap.PixelFormat);
      rect = new Rectangle(0, 0, alfaBitmap.Width, alfaBitmap.Height);
      BitmapData bitmapdata2 = alfaBitmap.LockBits(rect, ImageLockMode.ReadOnly, alfaBitmap.PixelFormat);
      IntPtr scan0_1 = bitmapdata1.Scan0;
      IntPtr scan0_2 = bitmapdata2.Scan0;
      int num = sourceBitmap.Width * sourceBitmap.Height;
      byte[] numArray = new byte[num * 4];
      byte[] destination = new byte[num * 4];
      Marshal.Copy(scan0_1, numArray, 0, num * 4);
      Marshal.Copy(scan0_2, destination, 0, num * 4);
      for (int index = 3; index < num * 4; index += 4)
        numArray[index] = destination[index - channel];
      Marshal.Copy(numArray, 0, scan0_1, num * 4);
      sourceBitmap.UnlockBits(bitmapdata1);
      alfaBitmap.UnlockBits(bitmapdata2);
      return true;
    }

    public static bool RemoveAlfaChannel(Bitmap sourceBitmap)
    {
      if (sourceBitmap == null)
        return false;
      Rectangle rect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);
      BitmapData bitmapdata = sourceBitmap.LockBits(rect, ImageLockMode.ReadWrite, sourceBitmap.PixelFormat);
      IntPtr scan0 = bitmapdata.Scan0;
      int num = sourceBitmap.Width * sourceBitmap.Height;
      byte[] numArray = new byte[num * 4];
      Marshal.Copy(scan0, numArray, 0, num * 4);
      for (int index = 3; index < num * 4; index += 4)
        numArray[index] = byte.MaxValue;
      Marshal.Copy(numArray, 0, scan0, num * 4);
      sourceBitmap.UnlockBits(bitmapdata);
      return true;
    }

    public static Bitmap SubSampleBitmap(Bitmap sourceBitmap, int xStep, int yStep)
    {
      if (sourceBitmap == null)
        return (Bitmap) null;
      if (xStep <= 0 || yStep <= 0)
        return (Bitmap) null;
      if (xStep == 1 && yStep == 1)
        return (Bitmap) sourceBitmap.Clone();
      Bitmap bitmap = new Bitmap(sourceBitmap.Width / xStep, sourceBitmap.Height / yStep, sourceBitmap.PixelFormat);
      Rectangle rect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);
      BitmapData bitmapdata1 = sourceBitmap.LockBits(rect, ImageLockMode.ReadOnly, sourceBitmap.PixelFormat);
      rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
      BitmapData bitmapdata2 = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
      IntPtr scan0_1 = bitmapdata1.Scan0;
      IntPtr scan0_2 = bitmapdata2.Scan0;
      int length1 = sourceBitmap.Width * sourceBitmap.Height;
      int length2 = bitmap.Width * bitmap.Height;
      int[] destination = new int[length1];
      int[] numArray = new int[length2];
      Marshal.Copy(scan0_1, destination, 0, length1);
      Marshal.Copy(scan0_2, numArray, 0, length2);
      int index1 = 0;
      int index2 = 0;
      for (int index3 = 0; index3 < bitmap.Height; ++index3)
      {
        for (int index4 = 0; index4 < bitmap.Width; ++index4)
        {
          numArray[index1] = destination[index2];
          ++index1;
          index2 += xStep;
        }
        index2 += (yStep - 1) * sourceBitmap.Width;
      }
      Marshal.Copy(numArray, 0, scan0_2, length2);
      sourceBitmap.UnlockBits(bitmapdata1);
      bitmap.UnlockBits(bitmapdata2);
      return bitmap;
    }

    public static bool ColorizeRGB(
      Bitmap sourceBitmap,
      Color color1,
      Color color2,
      Color color3,
      bool preserveArmBand)
    {
      if (sourceBitmap == null)
        return false;
      Color[,] colorArray = new Color[48, 256];
      preserveArmBand = preserveArmBand && sourceBitmap.Width == 1024 && sourceBitmap.Height == 1024;
      if (preserveArmBand)
      {
        int index = 0;
        for (int y = 975; y <= 1022; ++y)
        {
          int num = 0;
          for (int x = 384; x <= 639; ++x)
            colorArray[index, num++] = sourceBitmap.GetPixel(x, y);
          ++index;
        }
      }
      bool flag = GraphicUtil.ColorizeRGB(sourceBitmap, color1, color2, color3, 0, sourceBitmap.Height);
      if (flag && preserveArmBand)
      {
        int index = 0;
        for (int y = 975; y <= 1022; ++y)
        {
          int num = 0;
          for (int x = 384; x <= 639; ++x)
            sourceBitmap.SetPixel(x, y, colorArray[index, num++]);
          ++index;
        }
      }
      return flag;
    }

    public static bool ColorizeRGB(
      Bitmap sourceBitmap,
      Color color1,
      Color color2,
      Color color3,
      int firstRow,
      int lastRow)
    {
      if (sourceBitmap == null)
        return false;
      Rectangle rect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);
      BitmapData bitmapdata = sourceBitmap.LockBits(rect, ImageLockMode.ReadWrite, sourceBitmap.PixelFormat);
      IntPtr scan0 = bitmapdata.Scan0;
      int num1 = sourceBitmap.Width * sourceBitmap.Height;
      byte[] numArray = new byte[num1 * 4];
      Marshal.Copy(scan0, numArray, 0, num1 * 4);
      for (int index = firstRow * sourceBitmap.Width; index < lastRow * sourceBitmap.Width; ++index)
      {
        int num2 = (int) numArray[index * 4];
        int num3 = (int) numArray[index * 4 + 1];
        int num4 = (int) numArray[index * 4 + 2];
        int num5 = ((int) color1.R * num4 + (int) color2.R * num3 + (int) color3.R * num2) / 226;
        int num6 = ((int) color1.G * num4 + (int) color2.G * num3 + (int) color3.G * num2) / 226;
        int num7 = ((int) color1.B * num4 + (int) color2.B * num3 + (int) color3.B * num2) / 226;
        if (num5 > (int) byte.MaxValue)
          num5 = (int) byte.MaxValue;
        if (num6 > (int) byte.MaxValue)
          num6 = (int) byte.MaxValue;
        if (num7 > (int) byte.MaxValue)
          num7 = (int) byte.MaxValue;
        numArray[index * 4] = (byte) num7;
        numArray[index * 4 + 1] = (byte) num6;
        numArray[index * 4 + 2] = (byte) num5;
      }
      Marshal.Copy(numArray, 0, scan0, num1 * 4);
      sourceBitmap.UnlockBits(bitmapdata);
      return true;
    }

    public static bool PrepareToColorize(Bitmap sourceBitmap, int firstRow, int lastRow)
    {
      if (sourceBitmap == null)
        return false;
      Rectangle rect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);
      BitmapData bitmapdata = sourceBitmap.LockBits(rect, ImageLockMode.ReadWrite, sourceBitmap.PixelFormat);
      IntPtr scan0 = bitmapdata.Scan0;
      int num1 = sourceBitmap.Width * sourceBitmap.Height;
      byte[] numArray = new byte[num1 * 4];
      Marshal.Copy(scan0, numArray, 0, num1 * 4);
      for (int index = firstRow * sourceBitmap.Width; index < lastRow * sourceBitmap.Width; ++index)
      {
        int num2 = (int) numArray[index * 4];
        int num3 = (int) numArray[index * 4 + 1];
        int num4 = (int) numArray[index * 4 + 2];
        while (num4 + num3 + num2 > 226)
        {
          if (num4 > 0)
            --num4;
          if (num3 > 0)
            --num3;
          if (num2 > 0)
            --num2;
        }
        numArray[index * 4] = (byte) num2;
        numArray[index * 4 + 1] = (byte) num3;
        numArray[index * 4 + 2] = (byte) num4;
      }
      Marshal.Copy(numArray, 0, scan0, num1 * 4);
      sourceBitmap.UnlockBits(bitmapdata);
      return true;
    }

    public static Bitmap MultiplyBitmap(Bitmap sourceBitmap, Bitmap multBitmap)
    {
      if (sourceBitmap == null)
        return (Bitmap) null;
      if (multBitmap == null)
        return (Bitmap) sourceBitmap.Clone();
      int length = sourceBitmap.Width * sourceBitmap.Height;
      Rectangle rect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);
      int[] numArray = new int[length];
      int[] destination = new int[length];
      if (multBitmap == null)
        return (Bitmap) sourceBitmap.Clone();
      BitmapData bitmapdata1 = sourceBitmap.LockBits(rect, ImageLockMode.ReadWrite, sourceBitmap.PixelFormat);
      Marshal.Copy(bitmapdata1.Scan0, numArray, 0, length);
      sourceBitmap.UnlockBits(bitmapdata1);
      if (multBitmap.Width != sourceBitmap.Width || multBitmap.Height != sourceBitmap.Height)
        multBitmap = GraphicUtil.ResizeBitmap(multBitmap, sourceBitmap.Width, sourceBitmap.Height, InterpolationMode.Bilinear);
      Marshal.Copy(multBitmap.LockBits(rect, ImageLockMode.ReadWrite, multBitmap.PixelFormat).Scan0, destination, 0, length);
      multBitmap.UnlockBits(bitmapdata1);
      for (int index = 0; index < length; ++index)
      {
        Color color = Color.FromArgb(numArray[index]);
        int num1 = destination[index] & (int) byte.MaxValue;
        int num2 = (int) (((long) destination[index] & 4278190080L) >> 24);
        int num3 = (int) color.R * num1 / (int) byte.MaxValue;
        int num4 = (int) color.G * num1 / (int) byte.MaxValue;
        int num5 = (int) color.B * num1 / (int) byte.MaxValue;
        int num6 = (int) color.A * num2 / (int) byte.MaxValue;
        numArray[index] = ((num6 << 8 | num3) << 8 | num4) << 8 | num5;
      }
      Bitmap bitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height, PixelFormat.Format32bppArgb);
      rect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);
      BitmapData bitmapdata2 = bitmap.LockBits(rect, ImageLockMode.WriteOnly, bitmap.PixelFormat);
      IntPtr scan0 = bitmapdata2.Scan0;
      Marshal.Copy(numArray, 0, scan0, length);
      bitmap.UnlockBits(bitmapdata2);
      return bitmap;
    }

    public static Bitmap MultiplyColorToBitmap(Bitmap sourceBitmap, Color color, int divisor)
    {
      if (sourceBitmap == null)
        return (Bitmap) null;
      int length = sourceBitmap.Width * sourceBitmap.Height;
      Rectangle rect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);
      int[] numArray = new int[length];
      BitmapData bitmapdata1 = sourceBitmap.LockBits(rect, ImageLockMode.ReadWrite, sourceBitmap.PixelFormat);
      Marshal.Copy(bitmapdata1.Scan0, numArray, 0, length);
      sourceBitmap.UnlockBits(bitmapdata1);
      for (int index = 0; index < length; ++index)
      {
        Color color1 = Color.FromArgb(numArray[index]);
        int num1 = (int) color.R * (int) color1.R / divisor;
        int num2 = (int) color.G * (int) color1.G / divisor;
        int num3 = (int) color.B * (int) color1.B / divisor;
        if (num1 > (int) byte.MaxValue)
          num1 = (int) byte.MaxValue;
        if (num2 > (int) byte.MaxValue)
          num2 = (int) byte.MaxValue;
        if (num3 > (int) byte.MaxValue)
          num3 = (int) byte.MaxValue;
        int maxValue = (int) byte.MaxValue;
        numArray[index] = ((maxValue << 8 | num1) << 8 | num2) << 8 | num3;
      }
      Bitmap bitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height, PixelFormat.Format32bppArgb);
      rect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);
      BitmapData bitmapdata2 = bitmap.LockBits(rect, ImageLockMode.WriteOnly, bitmap.PixelFormat);
      IntPtr scan0 = bitmapdata2.Scan0;
      Marshal.Copy(numArray, 0, scan0, length);
      bitmap.UnlockBits(bitmapdata2);
      return bitmap;
    }

    public static Bitmap AddWrinklesBitmap(Bitmap sourceBitmap, Bitmap wrinkleBitmap)
    {
      if (sourceBitmap == null)
        return (Bitmap) null;
      if (wrinkleBitmap == null)
        return (Bitmap) sourceBitmap.Clone();
      int length = sourceBitmap.Width * sourceBitmap.Height;
      Rectangle rect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);
      int[] numArray = new int[length];
      int[] destination = new int[length];
      if (wrinkleBitmap == null)
        return (Bitmap) sourceBitmap.Clone();
      BitmapData bitmapdata1 = sourceBitmap.LockBits(rect, ImageLockMode.ReadWrite, sourceBitmap.PixelFormat);
      Marshal.Copy(bitmapdata1.Scan0, numArray, 0, length);
      sourceBitmap.UnlockBits(bitmapdata1);
      if (wrinkleBitmap.Width != sourceBitmap.Width || wrinkleBitmap.Height != sourceBitmap.Height)
        wrinkleBitmap = GraphicUtil.ResizeBitmap(wrinkleBitmap, sourceBitmap.Width, sourceBitmap.Height, InterpolationMode.Bilinear);
      Marshal.Copy(wrinkleBitmap.LockBits(rect, ImageLockMode.ReadWrite, wrinkleBitmap.PixelFormat).Scan0, destination, 0, length);
      wrinkleBitmap.UnlockBits(bitmapdata1);
      for (int index = 0; index < length; ++index)
      {
        Color color = Color.FromArgb(numArray[index]);
        int num1 = destination[index] & (int) byte.MaxValue;
        int num2 = (int) (((long) destination[index] & 4278190080L) >> 24);
        int num3 = (int) color.R * num1 / (int) byte.MaxValue;
        int num4 = (int) color.G * num1 / (int) byte.MaxValue;
        int num5 = (int) color.B * num1 / (int) byte.MaxValue;
        int num6 = (int) color.A * num2 / (int) byte.MaxValue;
        numArray[index] = ((num6 << 8 | num3) << 8 | num4) << 8 | num5;
      }
      Bitmap bitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height, PixelFormat.Format32bppArgb);
      rect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);
      BitmapData bitmapdata2 = bitmap.LockBits(rect, ImageLockMode.WriteOnly, bitmap.PixelFormat);
      IntPtr scan0 = bitmapdata2.Scan0;
      Marshal.Copy(numArray, 0, scan0, length);
      bitmap.UnlockBits(bitmapdata2);
      return bitmap;
    }

    public static Bitmap EmbossBitmap(Bitmap sourceBitmap, Bitmap embossingBitmap)
    {
      if (sourceBitmap == null)
        return (Bitmap) null;
      if (embossingBitmap == null)
        return (Bitmap) sourceBitmap.Clone();
      int length = sourceBitmap.Width * sourceBitmap.Height;
      Rectangle rect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);
      int[] numArray = new int[length];
      int[] destination = new int[length];
      if (embossingBitmap == null)
        return (Bitmap) sourceBitmap.Clone();
      BitmapData bitmapdata1 = sourceBitmap.LockBits(rect, ImageLockMode.ReadWrite, sourceBitmap.PixelFormat);
      Marshal.Copy(bitmapdata1.Scan0, numArray, 0, length);
      sourceBitmap.UnlockBits(bitmapdata1);
      if (embossingBitmap.Width != sourceBitmap.Width || embossingBitmap.Height != sourceBitmap.Height)
        embossingBitmap = GraphicUtil.ResizeBitmap(embossingBitmap, sourceBitmap.Width, sourceBitmap.Height, InterpolationMode.Bilinear);
      Marshal.Copy(embossingBitmap.LockBits(rect, ImageLockMode.ReadWrite, embossingBitmap.PixelFormat).Scan0, destination, 0, length);
      embossingBitmap.UnlockBits(bitmapdata1);
      for (int index = 0; index < length; ++index)
      {
        Color color = Color.FromArgb(numArray[index]);
        int num1 = ((int) sbyte.MaxValue - ((destination[index] & 65280) >> 8)) / 2;
        int num2 = (int) color.R + num1;
        if (num2 > (int) byte.MaxValue)
          num2 = (int) byte.MaxValue;
        if (num2 < 0)
          num2 = 0;
        int num3 = (int) color.G + num1;
        if (num3 > (int) byte.MaxValue)
          num3 = (int) byte.MaxValue;
        if (num3 < 0)
          num3 = 0;
        int num4 = (int) color.B + num1;
        if (num4 > (int) byte.MaxValue)
          num4 = (int) byte.MaxValue;
        if (num4 < 0)
          num4 = 0;
        int a = (int) color.A;
        numArray[index] = ((a << 8 | num2) << 8 | num3) << 8 | num4;
      }
      Bitmap bitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height, PixelFormat.Format32bppArgb);
      rect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);
      BitmapData bitmapdata2 = bitmap.LockBits(rect, ImageLockMode.WriteOnly, bitmap.PixelFormat);
      IntPtr scan0 = bitmapdata2.Scan0;
      Marshal.Copy(numArray, 0, scan0, length);
      bitmap.UnlockBits(bitmapdata2);
      return bitmap;
    }

    public static Bitmap Overlap(
      Bitmap lowerBitmap,
      Bitmap upperBitmap,
      Rectangle destRectangle)
    {
      if (lowerBitmap == null && upperBitmap == null)
        return (Bitmap) null;
      if (lowerBitmap == null)
        return (Bitmap) upperBitmap.Clone();
      if (upperBitmap == null)
        return (Bitmap) lowerBitmap.Clone();
      Bitmap bitmap1 = GraphicUtil.ResizeBitmap(upperBitmap, destRectangle.Width, destRectangle.Height, InterpolationMode.Bicubic);
      if (bitmap1 == null)
        return lowerBitmap;
      Bitmap bitmap2 = (Bitmap) lowerBitmap.Clone();
      Graphics graphics = Graphics.FromImage((Image) bitmap2);
      graphics.DrawImage((Image) bitmap1, destRectangle.Left, destRectangle.Top);
      graphics.Dispose();
      return bitmap2;
    }

    public static Bitmap ColorizeWhite(Bitmap srcBitmap, Color color)
    {
      if (srcBitmap == null)
        return (Bitmap) null;
      int r = (int) color.R;
      int g = (int) color.G;
      int b = (int) color.B;
      for (int x = 0; x < srcBitmap.Width; ++x)
      {
        for (int y = 0; y < srcBitmap.Height; ++y)
        {
          Color pixel = srcBitmap.GetPixel(x, y);
          if (pixel != Color.FromArgb(0, 0, 0, 0))
            srcBitmap.SetPixel(x, y, Color.FromArgb((int) pixel.A, r, g, b));
        }
      }
      return srcBitmap;
    }

    public static void RemapRectangle(
      Bitmap srcBitmap,
      Rectangle srcRect,
      Bitmap destBitmap,
      Rectangle destRect)
    {
      Graphics graphics = Graphics.FromImage((Image) destBitmap);
      graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
      graphics.DrawImage((Image) srcBitmap, destRect, srcRect, GraphicsUnit.Pixel);
      graphics.Dispose();
    }

    public static void DrawOver(Bitmap belowBitmap, Bitmap overBitmap)
    {
      Graphics graphics = Graphics.FromImage((Image) belowBitmap);
      graphics.DrawImage((Image) overBitmap, 0, 0, overBitmap.Width, overBitmap.Height);
      graphics.Dispose();
    }

    public static Bitmap MakeAutoTransparent(Bitmap bitmap)
    {
      Color pixel = bitmap.GetPixel(0, 0);
      bitmap.MakeTransparent(pixel);
      return bitmap;
    }

    public static Color GetDominantColor(Bitmap bitmap, Rectangle rectangle)
    {
      int[] numArray = new int[256];
      for (int x = rectangle.X; x < rectangle.X + rectangle.Width; ++x)
      {
        for (int y = rectangle.Y; y < rectangle.Y + rectangle.Height; ++y)
        {
          Color pixel = bitmap.GetPixel(x, y);
          ++numArray[(int) pixel.R];
        }
      }
      int num1 = -1;
      int red = 0;
      for (int index = 0; index < 256; ++index)
      {
        if (numArray[index] > num1)
        {
          num1 = numArray[index];
          red = index;
        }
      }
      int num2 = 0;
      int num3 = 0;
      for (int x = rectangle.X; x < rectangle.X + rectangle.Width; ++x)
      {
        for (int y = rectangle.Y; y < rectangle.Y + rectangle.Height; ++y)
        {
          Color pixel = bitmap.GetPixel(x, y);
          if ((int) pixel.R == red)
          {
            num2 += (int) pixel.G;
            num3 += (int) pixel.B;
          }
        }
      }
      int green = num2 / num1;
      int blue = num3 / num1;
      return Color.FromArgb((int) byte.MaxValue, red, green, blue);
    }

    public static Bitmap ColorTuning(
      Bitmap variableBitmap,
      Bitmap referenceBitmap,
      Rectangle rect)
    {
      Color dominantColor1 = GraphicUtil.GetDominantColor(variableBitmap, rect);
      Color dominantColor2 = GraphicUtil.GetDominantColor(referenceBitmap, rect);
      int deltaR = (int) dominantColor2.R - (int) dominantColor1.R;
      int deltaG = (int) dominantColor2.G - (int) dominantColor1.G;
      int deltaB = (int) dominantColor2.B - (int) dominantColor1.B;
      Bitmap bitmap = (Bitmap) variableBitmap.Clone();
      GraphicUtil.AddColorOffset(bitmap, deltaR, deltaG, deltaB);
      return bitmap;
    }

    public static Bitmap ColorTuning(
      Bitmap variableBitmap,
      Rectangle variableRect,
      Bitmap referenceBitmap,
      Rectangle referenceRect)
    {
      Color dominantColor1 = GraphicUtil.GetDominantColor(variableBitmap, variableRect);
      Color dominantColor2 = GraphicUtil.GetDominantColor(referenceBitmap, referenceRect);
      int deltaR = (int) dominantColor2.R - (int) dominantColor1.R;
      int deltaG = (int) dominantColor2.G - (int) dominantColor1.G;
      int deltaB = (int) dominantColor2.B - (int) dominantColor1.B;
      Bitmap bitmap = (Bitmap) variableBitmap.Clone();
      GraphicUtil.AddColorOffset(bitmap, deltaR, deltaG, deltaB);
      return bitmap;
    }

    public static void AddColorOffset(Bitmap bitmap, int deltaR, int deltaG, int deltaB)
    {
      if (bitmap == null)
        return;
      for (int x = 0; x < bitmap.Width; ++x)
      {
        for (int y = 0; y < bitmap.Height; ++y)
        {
          Color pixel = bitmap.GetPixel(x, y);
          int red = (int) pixel.R + deltaR;
          int green = (int) pixel.G + deltaG;
          int blue = (int) pixel.B + deltaB;
          if (red > (int) byte.MaxValue)
            red = (int) byte.MaxValue;
          if (green > (int) byte.MaxValue)
            green = (int) byte.MaxValue;
          if (blue > (int) byte.MaxValue)
            blue = (int) byte.MaxValue;
          if (red < 0)
            red = 0;
          if (green < 0)
            green = 0;
          if (blue < 0)
            blue = 0;
          bitmap.SetPixel(x, y, Color.FromArgb((int) pixel.A, red, green, blue));
        }
      }
    }

    public static Bitmap CreateReferenceBitmap(
      Bitmap sourceBitmap,
      Color c1,
      Color c2,
      Color c3)
    {
      if (sourceBitmap == null)
        return (Bitmap) null;
      int length = sourceBitmap.Width * sourceBitmap.Height;
      Rectangle rect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);
      int[] numArray = new int[length];
      int[] hist = new int[3];
      BitmapData bitmapdata1 = sourceBitmap.LockBits(rect, ImageLockMode.ReadWrite, sourceBitmap.PixelFormat);
      Marshal.Copy(bitmapdata1.Scan0, numArray, 0, length);
      sourceBitmap.UnlockBits(bitmapdata1);
      Color[] refColors = new Color[3]{ c1, c2, c3 };
      int[] rgb = new int[3];
      for (int index = 0; index < length; ++index)
      {
        Color tC = Color.FromArgb(numArray[index]);
        int num1;
        int num2 = num1 = 0;
        int num3 = num1;
        int num4 = num1;
        int num5 = num1;
        if (tC == c1)
        {
          num4 = 226;
          num3 = 0;
          num2 = 0;
          num5 = (int) byte.MaxValue;
        }
        else if (tC == c2)
        {
          num4 = 0;
          num3 = 226;
          num2 = 0;
          num5 = (int) byte.MaxValue;
        }
        else if (tC == c3)
        {
          num4 = 0;
          num3 = 0;
          num2 = 226;
          num5 = (int) byte.MaxValue;
        }
        else if (GraphicUtil.UseColorCombination(refColors, tC, ref rgb, true, hist))
        {
          num4 = rgb[0];
          num3 = rgb[1];
          num2 = rgb[2];
          num5 = (int) byte.MaxValue;
        }
        if (num5 == (int) byte.MaxValue)
        {
          numArray[index] = ((num5 << 8 | num4) << 8 | num3) << 8 | num2;
        }
        else
        {
          int r = (int) tC.R;
          int g = (int) tC.G;
          int b = (int) tC.B;
          int num6 = 0;
          numArray[index] = ((num6 << 8 | r) << 8 | g) << 8 | b;
        }
      }
      for (int index1 = 0; index1 < length; ++index1)
      {
        Color tC = Color.FromArgb(numArray[index1]);
        if (tC.A == (byte) 0)
        {
          int num1 = index1 / sourceBitmap.Width;
          int num2 = index1 - num1 * sourceBitmap.Width;
          hist[0] = hist[1] = hist[2] = 0;
          for (int index2 = -2; index2 <= 2; ++index2)
          {
            for (int index3 = -2; index3 <= 2; ++index3)
            {
              int num3 = num1 + index2;
              int num4 = num2 + index3;
              if (num3 >= 0 && num3 < sourceBitmap.Height && (num4 >= 0 && num4 < sourceBitmap.Width))
              {
                Color color = Color.FromArgb(numArray[num3 * sourceBitmap.Width + num4]);
                if (color.A != (byte) 0)
                {
                  if (color.R != (byte) 0)
                    ++hist[0];
                  else if (color.G != (byte) 0)
                    ++hist[1];
                  else if (color.B != (byte) 0)
                    ++hist[2];
                }
              }
            }
          }
          GraphicUtil.UseColorCombination(refColors, tC, ref rgb, false, hist);
          int num5 = rgb[0];
          int num6 = rgb[1];
          int num7 = rgb[2];
          int maxValue = (int) byte.MaxValue;
          numArray[index1] = ((maxValue << 8 | num5) << 8 | num6) << 8 | num7;
        }
      }
      Bitmap bitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height, PixelFormat.Format32bppArgb);
      rect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);
      BitmapData bitmapdata2 = bitmap.LockBits(rect, ImageLockMode.WriteOnly, bitmap.PixelFormat);
      IntPtr scan0 = bitmapdata2.Scan0;
      Marshal.Copy(numArray, 0, scan0, length);
      bitmap.UnlockBits(bitmapdata2);
      return bitmap;
    }

    public static Bitmap CreateReferenceBitmap(
      Bitmap sourceBitmap,
      Color c1,
      Color c2,
      Color c3,
      bool preserveArmBand)
    {
      Color[,] colorArray = new Color[48, 256];
      preserveArmBand = preserveArmBand && sourceBitmap.Width == 1024 && sourceBitmap.Height == 1024;
      if (preserveArmBand)
      {
        int index = 0;
        for (int y = 975; y <= 1022; ++y)
        {
          int num = 0;
          for (int x = 384; x <= 639; ++x)
            colorArray[index, num++] = sourceBitmap.GetPixel(x, y);
          ++index;
        }
      }
      Bitmap referenceBitmap = GraphicUtil.CreateReferenceBitmap(sourceBitmap, c1, c2, c3);
      if (referenceBitmap != null && preserveArmBand)
      {
        int index = 0;
        for (int y = 975; y <= 1022; ++y)
        {
          int num = 0;
          for (int x = 384; x <= 639; ++x)
            referenceBitmap.SetPixel(x, y, colorArray[index, num++]);
          ++index;
        }
      }
      return referenceBitmap;
    }

    private static bool UseColorCombination(
      Color[] refColors,
      Color tC,
      ref int[] rgb,
      bool useOneColor,
      int[] hist)
    {
      int[] numArray = new int[3];
      rgb[0] = rgb[1] = rgb[2] = 0;
      if (hist[0] + hist[1] + hist[2] != 0)
      {
        if (hist[0] > 0 && hist[1] == 0 && hist[2] == 0)
        {
          rgb[0] = GraphicUtil.UseOneColor(refColors[0], tC);
          return true;
        }
        if (hist[1] > 0 && hist[0] == 0 && hist[2] == 0)
        {
          rgb[1] = GraphicUtil.UseOneColor(refColors[1], tC);
          return true;
        }
        if (hist[2] > 0 && hist[0] == 0 && hist[1] == 0)
        {
          rgb[2] = GraphicUtil.UseOneColor(refColors[2], tC);
          return true;
        }
        if (!useOneColor)
        {
          if (hist[0] >= hist[2] && hist[1] >= hist[2])
          {
            if (GraphicUtil.UseTwoColors(refColors[0], refColors[1], tC, out rgb[0], out rgb[1]))
              return true;
          }
          else if (hist[0] >= hist[1] && hist[2] >= hist[1])
          {
            if (GraphicUtil.UseTwoColors(refColors[0], refColors[2], tC, out rgb[0], out rgb[2]))
              return true;
          }
          else if (hist[1] >= hist[0] && hist[2] >= hist[0] && GraphicUtil.UseTwoColors(refColors[1], refColors[2], tC, out rgb[1], out rgb[2]))
            return true;
        }
      }
      for (int index = 0; index < 3; ++index)
      {
        rgb[index] = 0;
        numArray[index] = ((int) tC.R - (int) refColors[index].R) * ((int) tC.R - (int) refColors[index].R) + ((int) tC.G - (int) refColors[index].G) * ((int) tC.G - (int) refColors[index].G) + ((int) tC.B - (int) refColors[index].B) * ((int) tC.B - (int) refColors[index].B);
        if (refColors[index].A == (byte) 0)
          numArray[index] = int.MaxValue;
      }
      int index1;
      int index2;
      int index3;
      if (numArray[0] <= numArray[1] && numArray[0] <= numArray[2])
      {
        index1 = 0;
        if (numArray[1] < numArray[2])
        {
          index2 = 1;
          index3 = 2;
        }
        else
        {
          index2 = 2;
          index3 = 1;
        }
      }
      else if (numArray[1] <= numArray[0] && numArray[1] <= numArray[2])
      {
        index1 = 1;
        if (numArray[0] < numArray[2])
        {
          index2 = 0;
          index3 = 2;
        }
        else
        {
          index2 = 2;
          index3 = 0;
        }
      }
      else
      {
        index1 = 2;
        if (numArray[0] < numArray[1])
        {
          index2 = 0;
          index3 = 1;
        }
        else
        {
          index2 = 1;
          index3 = 0;
        }
      }
      if (numArray[index1] * 8 < numArray[index2])
      {
        rgb[index1] = GraphicUtil.UseOneColor(refColors[index1], tC);
        return true;
      }
      if (useOneColor)
        return false;
      if (numArray[index1] * 8 > numArray[index2] && GraphicUtil.UseTwoColors(refColors[index1], refColors[index2], tC, out rgb[index1], out rgb[index2]) || numArray[index1] * 8 > numArray[index3] && GraphicUtil.UseTwoColors(refColors[index1], refColors[index3], tC, out rgb[index1], out rgb[index3]))
        return true;
      rgb[index1] = GraphicUtil.UseOneColor(refColors[index1], tC);
      return true;
    }

    private static int UseOneColor(Color refColor, Color targetColor)
    {
      int num1 = ((int) refColor.R + (int) refColor.G + (int) refColor.B) / 3;
      int num2 = ((int) targetColor.R + (int) targetColor.G + (int) targetColor.B) / 3;
      int num3 = num2 <= num1 ? 226 * num2 / num1 : 226 + 30 * (num2 - num1) / ((int) byte.MaxValue - num1);
      if (num3 < 0)
        num3 = 0;
      if (num3 > (int) byte.MaxValue)
        num3 = (int) byte.MaxValue;
      return num3;
    }

    private static bool UseTwoColors(Color c1, Color c2, Color tc, out int w1, out int w2)
    {
      int num1 = Math.Abs((int) c1.R - (int) c2.R);
      int num2 = Math.Abs((int) c1.G - (int) c2.G);
      int num3 = Math.Abs((int) c1.B - (int) c2.B);
      if (num1 >= num2 && num1 >= num3)
      {
        if ((int) c1.R < (int) c2.R)
        {
          w1 = ((int) c2.R - (int) tc.R) * 226 / num1;
          w2 = ((int) tc.R - (int) c1.R) * 226 / num1;
        }
        else
        {
          w1 = ((int) tc.R - (int) c2.R) * 226 / num1;
          w2 = ((int) c1.R - (int) tc.R) * 226 / num1;
        }
      }
      else if (num2 >= num1 && num2 >= num3)
      {
        if ((int) c1.G < (int) c2.G)
        {
          w1 = ((int) c2.G - (int) tc.G) * 226 / num2;
          w2 = ((int) tc.G - (int) c1.G) * 226 / num2;
        }
        else
        {
          w1 = ((int) tc.G - (int) c2.G) * 226 / num2;
          w2 = ((int) c1.G - (int) tc.G) * 226 / num2;
        }
      }
      else if ((int) c1.B < (int) c2.B)
      {
        w1 = ((int) c2.B - (int) tc.B) * 226 / num3;
        w2 = ((int) tc.B - (int) c1.B) * 226 / num3;
      }
      else
      {
        w1 = ((int) tc.B - (int) c2.B) * 226 / num3;
        w2 = ((int) c1.B - (int) tc.B) * 226 / num3;
      }
      if (w1 < 0)
        w1 = 0;
      if (w1 > (int) byte.MaxValue)
        w1 = (int) byte.MaxValue;
      if (w2 < 0)
        w2 = 0;
      if (w2 > (int) byte.MaxValue)
        w2 = (int) byte.MaxValue;
      return w1 >= 0 && w2 >= 0;
    }
  }
}
