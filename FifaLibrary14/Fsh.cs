// Original code created by Rinaldo

using System.Drawing;
using System.IO;

namespace FifaLibrary
{
  public class Fsh
  {
    private string m_FileName;
    private string m_DirId;
    private string m_Signature;
    private int m_FileSize;
    private int m_NImages;
    private FifaLibrary.ImageDir[] m_ImageDir;
    private byte[] m_DirPad;
    private FshImage[] m_FshImages;

    public string FileName
    {
      get
      {
        return this.m_FileName;
      }
      set
      {
        this.m_FileName = value;
      }
    }

    public int FileSize
    {
      get
      {
        return this.m_FileSize;
      }
      set
      {
        this.m_FileSize = value;
      }
    }

    public FifaLibrary.ImageDir[] ImageDir
    {
      get
      {
        return this.m_ImageDir;
      }
      set
      {
        this.m_ImageDir = value;
      }
    }

    public FshImage[] FshImages
    {
      get
      {
        return this.m_FshImages;
      }
      set
      {
        this.m_FshImages = value;
      }
    }

    public Fsh(BinaryReader r)
    {
      this.Load(r);
    }

    public Fsh(string filePath)
    {
      this.m_FileName = filePath;
      FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
      if (fileStream == null)
        return;
      BinaryReader r = new BinaryReader((Stream) fileStream);
      if (r == null)
        return;
      this.Load(r);
      r.Close();
      fileStream.Close();
    }

    public bool Load(BinaryReader r)
    {
      if ((int) r.BaseStream.Length < 4)
        return false;
      this.m_Signature = new string(r.ReadChars(4));
      if (this.m_Signature != "SHPI")
        return false;
      this.m_FileSize = r.ReadInt32();
      this.m_NImages = r.ReadInt32();
      this.m_DirId = new string(r.ReadChars(4));
      this.m_ImageDir = new FifaLibrary.ImageDir[this.m_NImages];
      for (int index = 0; index < this.m_NImages; ++index)
        this.m_ImageDir[index] = new FifaLibrary.ImageDir(r);
      int num = this.m_FileSize;
      for (int index = 0; index < this.m_NImages; ++index)
      {
        if (this.m_ImageDir[index].Offset < num)
          num = this.m_ImageDir[index].Offset;
      }
      int count = num - (16 + 8 * this.m_NImages);
      if (count > 0)
        this.m_DirPad = r.ReadBytes(count);
      this.m_FshImages = new FshImage[this.m_NImages];
      for (int index = 0; index < this.m_NImages; ++index)
      {
        int maxSize = index + 1 < this.m_NImages ? this.m_ImageDir[index + 1].Offset - this.m_ImageDir[index].Offset : this.m_FileSize - this.m_ImageDir[index].Offset;
        this.m_FshImages[index] = new FshImage(this, r, maxSize);
      }
      return true;
    }

    public bool Save(BinaryWriter w)
    {
      w.Write('S');
      w.Write('H');
      w.Write('P');
      w.Write('I');
      w.Write(this.m_FileSize);
      w.Write(this.m_NImages);
      char[] charArray = this.m_DirId.ToCharArray();
      w.Write((byte) charArray[0]);
      w.Write((byte) charArray[1]);
      w.Write((byte) charArray[2]);
      w.Write((byte) charArray[3]);
      for (int index = 0; index < this.m_NImages; ++index)
        this.m_ImageDir[index].Save(w);
      if (this.m_DirPad != null)
        w.Write(this.m_DirPad);
      for (int index = 0; index < this.m_NImages; ++index)
        this.m_FshImages[index].Save(w);
      return true;
    }

    public bool Save()
    {
      return this.Save(this.m_FileName);
    }

    public bool Save(string fileName)
    {
      if (fileName == null)
        return false;
      FileStream fileStream = new FileStream(fileName, FileMode.Create);
      BinaryWriter w = new BinaryWriter((Stream) fileStream);
      bool flag = this.Save(w);
      w.Close();
      fileStream.Close();
      return flag;
    }

    public void Hash(string fileName)
    {
      for (int index = 0; index < this.m_NImages; ++index)
        this.m_FshImages[index].Hash(fileName);
    }

    public void ComputeImageDir()
    {
      int offset = this.m_ImageDir[0].Offset;
      for (int index = 0; index < this.m_NImages; ++index)
      {
        this.m_ImageDir[index].Offset = offset;
        offset += this.m_FshImages[index].ComputeLength();
      }
      this.m_FileSize = offset;
    }

    public void ReplaceBitmaps(Bitmap[] bitmaps)
    {
      int num = bitmaps.Length <= this.m_NImages ? bitmaps.Length : this.m_NImages;
      for (int index = 0; index < num; ++index)
        this.m_FshImages[index].ReplaceBitmap(bitmaps[index]);
    }

    public bool ReplaceBitmap(Bitmap bitmap, int index)
    {
      return index < this.m_NImages && this.m_FshImages[index].ReplaceBitmap(bitmap);
    }

    public Bitmap GetBitmap(int index)
    {
      return index < this.m_NImages ? this.m_FshImages[index].Bitmap : (Bitmap) null;
    }

    public Bitmap[] GetBitmaps()
    {
      Bitmap[] bitmapArray = new Bitmap[this.m_NImages];
      for (int index = 0; index < this.m_NImages; ++index)
        bitmapArray[index] = this.m_FshImages[index].Bitmap;
      return bitmapArray;
    }
  }
}
