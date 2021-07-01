// Original code created by Rinaldo

using System.IO;

namespace FifaLibrary
{
  public class Rx3RawData
  {
    private string m_FileName;
    private bool m_IsFifa14;
    private int m_Rx3bPosition;
    private byte[] m_Preface;
    private byte[][] m_RawData;
    private Rx3Header m_Rx3Header;
    private bool m_SwapEndian;
    private Rx3FileDescriptor[] m_Rx3FileDescriptors;

    public string FileName
    {
      get
      {
        return this.m_FileName;
      }
    }

    public bool IsFifa14
    {
      get
      {
        return this.m_IsFifa14;
      }
    }

    public byte[][] RawData
    {
      get
      {
        return this.m_RawData;
      }
    }

    public Rx3RawData(string fileName)
    {
      this.m_FileName = fileName;
      this.Load(fileName);
    }

    public bool Load(string fileName)
    {
      if (!File.Exists(fileName))
        return false;
      FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);
      BinaryReader r = new BinaryReader((Stream) fileStream);
      bool flag = this.Load(r);
      fileStream.Close();
      r.Close();
      this.m_FileName = fileName;
      return flag;
    }

    public bool Load(BinaryReader r)
    {
      string str = new string(r.ReadChars(4));
      if (str == "Rx3l")
      {
        r.BaseStream.Seek(0L, SeekOrigin.Begin);
        this.m_Rx3bPosition = 0;
        this.m_SwapEndian = false;
        this.m_IsFifa14 = true;
      }
      else if (str != "RX3b")
      {
        r.BaseStream.Seek(0L, SeekOrigin.Begin);
        this.m_Rx3bPosition = 0;
        this.m_SwapEndian = true;
        this.m_IsFifa14 = false;
      }
      else
      {
        r.BaseStream.Position = 68L;
        this.m_Rx3bPosition = FifaUtil.SwapEndian(r.ReadInt32());
        r.BaseStream.Seek(0L, SeekOrigin.Begin);
        this.m_Preface = r.ReadBytes(this.m_Rx3bPosition);
        this.m_SwapEndian = true;
        this.m_IsFifa14 = false;
      }
      this.m_Rx3Header = new Rx3Header(r, this.m_SwapEndian);
      if (this.m_Rx3Header.NFiles == 0)
        return false;
      this.m_Rx3FileDescriptors = new Rx3FileDescriptor[this.m_Rx3Header.NFiles];
      for (int index = 0; index < this.m_Rx3Header.NFiles; ++index)
        this.m_Rx3FileDescriptors[index] = new Rx3FileDescriptor(r, this.m_SwapEndian);
      this.m_RawData = new byte[this.m_Rx3Header.NFiles][];
      for (int index = 0; index < this.m_Rx3Header.NFiles; ++index)
        this.m_RawData[index] = r.ReadBytes(this.m_Rx3FileDescriptors[index].Size);
      return true;
    }

    public bool SetRawData(int index, byte[] rawData)
    {
      int length = rawData.Length;
      int size = this.m_Rx3FileDescriptors[index].Size;
      this.m_Rx3FileDescriptors[index].Size = length;
      int num = length - size;
      for (int index1 = index + 1; index1 < this.m_Rx3FileDescriptors.Length; ++index1)
        this.m_Rx3FileDescriptors[index1].Offset += num;
      this.m_RawData[index] = rawData;
      this.m_Rx3Header.SizeOf_ += num;
      return true;
    }

    public bool Save(string fileName)
    {
      FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);
      BinaryWriter w = new BinaryWriter((Stream) fileStream);
      bool flag = this.Save(w);
      fileStream.Close();
      w.Close();
      this.m_FileName = fileName;
      return flag;
    }

    public virtual bool Save(BinaryWriter w)
    {
      this.m_Rx3Header.Save(w);
      for (int index = 0; index < this.m_Rx3Header.NFiles; ++index)
        this.m_Rx3FileDescriptors[index].Save(w);
      for (int index = 0; index < this.m_Rx3Header.NFiles; ++index)
        w.Write(this.m_RawData[index]);
      return true;
    }
  }
}
