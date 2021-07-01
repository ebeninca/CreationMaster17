// Original code created by Rinaldo

using System.IO;
using zlib;

namespace FifaLibrary
{
  public class FifaFile
  {
    private string m_Name;
    private string m_PhysicalName;
    private uint m_StartPosition;
    private MemoryStream m_ReadMemoryStream;
    private MemoryStream m_WriteMemoryStream;
    private int m_CompressedSize;
    private int m_UncompressedSize;
    private int m_MaxBlockUncompressedSize;
    private ECompressionMode m_RequiredCompression;
    private ECompressionMode m_CurrentCompression;
    private bool m_IsArchived;
    private FifaBigFile m_Archive;
    private bool m_IsInMemory;
    private bool m_IsAnArchive;

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

    public override string ToString()
    {
      return this.m_Name;
    }

    public string PhysicalName
    {
      get
      {
        return this.m_PhysicalName;
      }
      set
      {
        this.m_PhysicalName = value;
      }
    }

    public uint StartPosition
    {
      get
      {
        return this.m_StartPosition;
      }
      set
      {
        this.m_StartPosition = value;
      }
    }

    public int CompressedSize
    {
      get
      {
        return this.m_CompressedSize;
      }
    }

    public int UncompressedSize
    {
      get
      {
        return this.m_UncompressedSize;
      }
    }

    public int BlockInflatedSize
    {
      get
      {
        return this.m_MaxBlockUncompressedSize;
      }
    }

    public ECompressionMode CompressionMode
    {
      get
      {
        return this.m_RequiredCompression;
      }
      set
      {
        this.m_RequiredCompression = value;
      }
    }

    public bool IsToCompress
    {
      get
      {
        return this.m_RequiredCompression != ECompressionMode.None;
      }
    }

    public bool IsCompressed
    {
      get
      {
        return this.m_CurrentCompression != ECompressionMode.None;
      }
    }

    public bool IsArchived
    {
      get
      {
        return this.m_IsArchived;
      }
    }

    public FifaBigFile Archive
    {
      get
      {
        return this.m_Archive;
      }
    }

    public bool IsInMemory
    {
      get
      {
        return this.m_IsInMemory;
      }
    }

    public bool IsAnArchive
    {
      get
      {
        return this.m_IsAnArchive;
      }
    }

    public FifaFile(
      FifaBigFile archive,
      byte[] buffer,
      string name,
      ECompressionMode compressionMode)
    {
      this.Load(archive, buffer, name, compressionMode);
    }

    private void Load(
      FifaBigFile archive,
      byte[] buffer,
      string name,
      ECompressionMode compressionMode)
    {
      this.m_Archive = archive;
      this.m_IsArchived = false;
      this.m_IsInMemory = true;
      this.m_ReadMemoryStream = new MemoryStream(buffer);
      this.m_PhysicalName = (string) null;
      this.m_StartPosition = 0U;
      this.m_Name = name;
      string extension = Path.GetExtension(name);
      extension.ToLower();
      this.m_IsAnArchive = extension == ".big";
      this.m_RequiredCompression = compressionMode;
      this.m_CurrentCompression = ECompressionMode.None;
      this.m_UncompressedSize = buffer.Length;
      if (this.IsToCompress)
        this.m_CompressedSize = -1;
      else
        this.m_CompressedSize = this.m_UncompressedSize;
    }

    public FifaFile(FifaFile fifaFile)
    {
      this.Load(fifaFile);
    }

    private void Load(FifaFile fifaFile)
    {
      this.m_Name = fifaFile.Name;
      this.m_Archive = fifaFile.Archive;
      this.m_IsArchived = fifaFile.IsArchived;
      this.m_IsInMemory = fifaFile.IsInMemory;
      this.m_PhysicalName = fifaFile.PhysicalName;
      this.m_StartPosition = fifaFile.StartPosition;
      this.m_IsAnArchive = true;
      this.m_RequiredCompression = fifaFile.m_RequiredCompression;
      this.m_CurrentCompression = fifaFile.m_CurrentCompression;
      this.m_CompressedSize = fifaFile.CompressedSize;
      this.m_UncompressedSize = fifaFile.UncompressedSize;
      this.m_ReadMemoryStream = fifaFile.m_ReadMemoryStream;
      this.m_WriteMemoryStream = fifaFile.m_WriteMemoryStream;
    }

    public FifaFile(string path, bool isAnArchive)
    {
      this.Load(path, isAnArchive);
    }

    private void Load(string path, bool isAnArchive)
    {
      this.m_Archive = (FifaBigFile) null;
      this.m_IsArchived = false;
      this.m_IsInMemory = false;
      this.m_PhysicalName = path;
      this.m_StartPosition = 0U;
      this.m_Name = Path.GetFileName(path);
      this.m_IsAnArchive = isAnArchive;
      BinaryReader reader = this.GetReader();
      this.m_CompressedSize = this.m_UncompressedSize = (int) reader.BaseStream.Length;
      this.m_CurrentCompression = this.m_RequiredCompression = ECompressionMode.None;
      int num = (int) this.CheckCompressionMode(reader);
      this.ReleaseReader(reader);
    }

    public FifaFile(FifaFileHeader header, BinaryReader r)
    {
      this.Load(header.BigFile, header.StartPosition, header.Size, header.Name, false, r);
    }

    private void Load(
      FifaBigFile archive,
      uint startPosition,
      int size,
      string name,
      bool isAnArchive,
      BinaryReader r)
    {
      this.m_Name = name;
      this.m_Archive = archive;
      this.m_IsArchived = true;
      this.m_IsInMemory = archive.IsInMemory;
      this.m_PhysicalName = this.m_Archive.PhysicalName;
      this.m_StartPosition = startPosition;
      this.m_IsAnArchive = isAnArchive;
      this.m_CompressedSize = this.m_UncompressedSize = size;
      this.m_CurrentCompression = this.m_RequiredCompression = ECompressionMode.Unknown;
      if (size == 0)
        this.m_CurrentCompression = this.m_RequiredCompression = ECompressionMode.None;
      else if (r == null)
      {
        r = this.m_Archive.GetReader();
        r.BaseStream.Position += (long) startPosition;
        int num = (int) this.CheckCompressionMode(r);
        this.ReleaseReader(r);
      }
      else
      {
        r.BaseStream.Position = this.m_Archive == null ? (long) startPosition : (long) (this.m_Archive.StartPosition + startPosition);
        int num = (int) this.CheckCompressionMode(r);
      }
    }

    public void Save(Stream outputStream)
    {
      long position = outputStream.Position;
      if (this.IsToCompress && !this.IsCompressed)
        this.Compress(outputStream);
      else if (!this.IsToCompress && this.IsCompressed)
      {
        this.Decompress(outputStream);
      }
      else
      {
        BinaryReader reader = this.GetReader();
        int count1 = this.IsCompressed ? this.m_CompressedSize : this.m_UncompressedSize;
        for (int count2 = 1048576; count1 > count2; count1 -= count2)
          outputStream.Write(reader.ReadBytes(count2), 0, count2);
        outputStream.Write(reader.ReadBytes(count1), 0, count1);
        this.ReleaseReader(reader);
      }
      if (this.m_Archive != null)
      {
        this.m_PhysicalName = this.m_Archive.PhysicalName;
        this.m_IsArchived = true;
      }
      this.m_StartPosition = (uint) position;
      this.m_ReadMemoryStream = (MemoryStream) null;
      this.m_WriteMemoryStream = (MemoryStream) null;
      this.m_IsInMemory = false;
    }

    public void Save(BinaryWriter w)
    {
      this.Save(w.BaseStream);
    }

    private ECompressionMode CheckCompressionMode(BinaryReader r)
    {
      if (r.BaseStream.Length < 8L)
        return ECompressionMode.None;
      long position = r.BaseStream.Position;
      byte[] numArray1 = r.ReadBytes(8);
      if (numArray1[0] == (byte) 16 && numArray1[1] == (byte) 251)
      {
        this.m_CurrentCompression = ECompressionMode.Compressed_10FB;
        this.m_RequiredCompression = this.m_CurrentCompression;
        this.m_UncompressedSize = ((int) numArray1[2] << 16) + ((int) numArray1[3] << 8) + (int) numArray1[4];
      }
      else
      {
        char[] chArray = new char[8];
        for (int index = 0; index < 8; ++index)
          chArray[index] = (char) numArray1[index];
        string str = new string(chArray);
        if (str.StartsWith("EASF"))
        {
          this.m_CompressedSize = ((int) numArray1[4] << 24) + ((int) numArray1[5] << 16) + ((int) numArray1[6] << 8) + (int) numArray1[7];
          r.ReadBytes(8);
          this.m_CurrentCompression = ECompressionMode.EASF;
          this.m_RequiredCompression = this.m_CurrentCompression;
        }
        else if (str == "chunkzip")
        {
          this.m_UncompressedSize = FifaUtil.SwapEndian(r.ReadInt32());
          this.m_CurrentCompression = ECompressionMode.Chunkzip;
          if (this.m_UncompressedSize == 2)
          {
            this.m_UncompressedSize = FifaUtil.SwapEndian(r.ReadInt32());
            r.ReadInt32();
            r.ReadInt32();
            r.ReadInt32();
            r.ReadInt32();
            r.ReadInt32();
            r.ReadInt32();
            FifaUtil.SwapEndian(r.ReadInt32());
            r.ReadInt32();
            this.m_CurrentCompression = ECompressionMode.Chunkzip2;
            this.m_RequiredCompression = this.m_CurrentCompression;
          }
          else
          {
            this.m_MaxBlockUncompressedSize = FifaUtil.SwapEndian(r.ReadInt32());
            this.m_RequiredCompression = this.m_CurrentCompression;
          }
        }
        else if (str == "chunkref")
        {
          this.m_UncompressedSize = FifaUtil.SwapEndian(r.ReadInt32());
          if (this.m_UncompressedSize == 2)
          {
            this.m_UncompressedSize = FifaUtil.SwapEndian(r.ReadInt32());
            r.ReadInt32();
            r.ReadInt32();
            r.ReadInt32();
            r.ReadInt32();
            r.ReadInt32();
            r.ReadInt32();
            this.m_MaxBlockUncompressedSize = FifaUtil.SwapEndian(r.ReadInt32());
            r.ReadInt32();
            this.m_CurrentCompression = ECompressionMode.Chunkref2;
          }
          else
          {
            FifaUtil.SwapEndian(r.ReadInt32());
            FifaUtil.SwapEndian(r.ReadInt32());
            byte[] numArray2 = r.ReadBytes(8);
            if (numArray2[0] == (byte) 16 && numArray2[1] == (byte) 251)
            {
              this.m_CurrentCompression = ECompressionMode.Chunkref;
              this.m_RequiredCompression = this.m_CurrentCompression;
              this.m_UncompressedSize = ((int) numArray2[2] << 16) + ((int) numArray2[3] << 8) + (int) numArray2[4];
            }
            else
              this.m_CurrentCompression = ECompressionMode.Unknown;
          }
          this.m_RequiredCompression = this.m_CurrentCompression;
        }
        else
        {
          this.m_CurrentCompression = ECompressionMode.None;
          this.m_RequiredCompression = this.m_CurrentCompression;
        }
      }
      r.BaseStream.Position = position;
      return this.m_CurrentCompression;
    }

    public bool IsDds()
    {
      if (Path.GetExtension(this.m_Name) == string.Empty)
      {
        BinaryReader reader = this.GetReader();
        if (this.CompressedSize >= 16)
        {
          byte[] numArray = reader.ReadBytes(16);
          if (numArray[6] == (byte) 68 && numArray[7] == (byte) 68 && numArray[8] == (byte) 83 || numArray[0] == (byte) 68 && numArray[1] == (byte) 68 && numArray[2] == (byte) 83)
            return true;
        }
        this.ReleaseReader(reader);
      }
      return false;
    }

    public bool Decompress(Stream outputStream)
    {
      if (this.m_CurrentCompression == ECompressionMode.None || this.m_CurrentCompression == ECompressionMode.EASF || this.m_CurrentCompression == ECompressionMode.Unknown)
      {
        outputStream.Write(this.Read(), 0, this.m_CompressedSize);
        return false;
      }
      if (this.m_IsArchived)
        this.m_Archive.Decompress();
      switch (this.m_CurrentCompression)
      {
        case ECompressionMode.Compressed_10FB:
          this.Uncompress_10FB(outputStream);
          break;
        case ECompressionMode.Chunkzip:
          this.UnChunkzip(outputStream);
          break;
        case ECompressionMode.Chunkzip2:
          this.UnChunkZip2(outputStream);
          break;
        case ECompressionMode.Chunkref:
          this.UnChunkref(outputStream);
          break;
        case ECompressionMode.Chunkref2:
          this.UnChunkref2(outputStream);
          break;
        case ECompressionMode.EASF:
          this.UnEASF(outputStream);
          break;
      }
      return true;
    }

    public bool Decompress()
    {
      if (this.m_CurrentCompression == ECompressionMode.None)
        return false;
      this.m_ReadMemoryStream = new MemoryStream(this.m_UncompressedSize);
      bool flag = this.Decompress((Stream) this.m_ReadMemoryStream);
      if (flag)
      {
        this.m_CurrentCompression = ECompressionMode.None;
        this.m_IsArchived = false;
        this.m_IsInMemory = true;
        this.m_StartPosition = 0U;
      }
      return flag;
    }

    public bool Compress(Stream outputStream)
    {
      if (this.m_CurrentCompression != ECompressionMode.None)
      {
        outputStream.Write(this.Read(), 0, this.m_CompressedSize);
        return true;
      }
      if (this.m_CurrentCompression == this.m_RequiredCompression)
      {
        outputStream.Write(this.Read(), 0, this.m_CompressedSize);
        return true;
      }
      switch (this.m_RequiredCompression)
      {
        case ECompressionMode.Compressed_10FB:
          this.Compress_10FB(outputStream);
          break;
        case ECompressionMode.Chunkzip:
          this.Chunkzip(outputStream);
          break;
        case ECompressionMode.Chunkref:
          this.Chunkref(outputStream, this.m_UncompressedSize);
          break;
      }
      return true;
    }

    public BinaryReader GetReader()
    {
      BinaryReader binaryReader;
      if (this.m_IsInMemory)
      {
        if (this.m_ReadMemoryStream != null)
        {
          binaryReader = new BinaryReader((Stream) this.m_ReadMemoryStream);
          binaryReader.BaseStream.Position = (long) this.m_StartPosition;
        }
        else
        {
          if (this.m_Archive == null)
            return (BinaryReader) null;
          binaryReader = this.m_Archive.GetReader();
          binaryReader.BaseStream.Position = (long) this.m_StartPosition;
        }
      }
      else
      {
        binaryReader = new BinaryReader((Stream) new FileStream(this.m_PhysicalName, FileMode.Open, FileAccess.Read));
        binaryReader.BaseStream.Position = (long) this.m_StartPosition;
        if (this.m_Archive != null)
          binaryReader.BaseStream.Position += (long) this.m_Archive.StartPosition;
      }
      return binaryReader;
    }

    public void ReleaseReader(BinaryReader r)
    {
      if (this.m_IsInMemory)
        return;
      r.BaseStream.Close();
      r.Close();
    }

    public StreamReader GetStreamReader()
    {
      if (this.m_ReadMemoryStream != null)
        return new StreamReader((Stream) this.m_ReadMemoryStream);
      StreamReader streamReader = this.m_Archive == null ? new StreamReader(this.m_PhysicalName) : this.m_Archive.GetStreamReader();
      streamReader.BaseStream.Position += (long) this.m_StartPosition;
      if (!this.IsCompressed)
        return streamReader;
      this.m_ReadMemoryStream = new MemoryStream();
      this.Decompress((Stream) this.m_ReadMemoryStream);
      this.m_ReadMemoryStream.Seek(0L, SeekOrigin.Begin);
      this.m_StartPosition = 0U;
      this.m_IsInMemory = true;
      return new StreamReader((Stream) this.m_ReadMemoryStream);
    }

    public void ReleaseStreamReader(StreamReader r)
    {
      if (this.m_IsInMemory)
        return;
      r.BaseStream.Close();
      r.Close();
    }

    protected StreamWriter GetStreamWriter(ECompressionMode compressionMode)
    {
      this.m_WriteMemoryStream = new MemoryStream();
      StreamWriter streamWriter = new StreamWriter((Stream) this.m_WriteMemoryStream);
      this.m_IsInMemory = true;
      this.m_IsArchived = false;
      this.m_CurrentCompression = compressionMode;
      return streamWriter;
    }

    protected bool ReleaseStreamWriter(StreamWriter w)
    {
      w.Flush();
      this.m_CompressedSize = this.m_UncompressedSize = (int) this.m_WriteMemoryStream.Length;
      if (this.m_IsInMemory)
      {
        if (!this.IsCompressed)
        {
          if (this.IsToCompress)
          {
            byte[] numArray = this.Compress_10FB(this.m_WriteMemoryStream.GetBuffer());
            if (numArray == null)
            {
              this.m_CurrentCompression = ECompressionMode.None;
              this.m_RequiredCompression = ECompressionMode.None;
              this.m_CompressedSize = this.m_UncompressedSize;
              return false;
            }
            this.m_RequiredCompression = ECompressionMode.Compressed_10FB;
            this.m_CompressedSize = numArray.Length;
          }
        }
        else if (!this.IsToCompress)
        {
          byte[] numArray = FifaFile.Uncompress_10FB(this.m_WriteMemoryStream.GetBuffer());
          if (numArray == null)
          {
            this.m_CurrentCompression = ECompressionMode.None;
            this.m_RequiredCompression = ECompressionMode.None;
            this.m_UncompressedSize = this.m_CompressedSize;
            return false;
          }
          this.m_RequiredCompression = ECompressionMode.None;
          this.m_UncompressedSize = numArray.Length;
        }
        this.m_ReadMemoryStream = this.m_WriteMemoryStream;
        this.m_StartPosition = 0U;
      }
      else
      {
        w.Close();
        if (File.Exists(this.PhysicalName + ".tmp"))
        {
          File.Delete(this.PhysicalName);
          File.Move(this.PhysicalName + ".tmp", this.PhysicalName);
        }
      }
      return true;
    }

    private byte[] Read()
    {
      BinaryReader reader = this.GetReader();
      int count = this.IsCompressed ? this.m_CompressedSize : this.m_UncompressedSize;
      byte[] numArray = reader.ReadBytes(count);
      this.ReleaseReader(reader);
      return numArray;
    }

    protected BinaryWriter GetWriter(int size, ECompressionMode compressionMode)
    {
      this.m_WriteMemoryStream = new MemoryStream(size);
      BinaryWriter binaryWriter = new BinaryWriter((Stream) this.m_WriteMemoryStream);
      this.m_IsInMemory = true;
      this.m_IsArchived = false;
      this.m_CurrentCompression = compressionMode;
      if (this.m_CurrentCompression != ECompressionMode.None)
      {
        this.m_CompressedSize = size;
        this.m_UncompressedSize = -1;
      }
      else
      {
        this.m_UncompressedSize = size;
        this.m_CompressedSize = -1;
      }
      return binaryWriter;
    }

    public BinaryWriter GetWriter()
    {
      if (this.m_Archive == null && this.m_PhysicalName != null)
      {
        BinaryWriter binaryWriter = new BinaryWriter((Stream) new FileStream(this.m_PhysicalName + ".temp", FileMode.Create));
        this.m_IsInMemory = false;
        this.m_IsArchived = false;
        return binaryWriter;
      }
      this.m_WriteMemoryStream = new MemoryStream();
      BinaryWriter binaryWriter1 = new BinaryWriter((Stream) this.m_WriteMemoryStream);
      this.m_IsInMemory = true;
      this.m_IsArchived = false;
      return binaryWriter1;
    }

    public bool ReleaseWriter(BinaryWriter w)
    {
      if (this.m_IsInMemory)
      {
        if (!this.IsCompressed)
        {
          this.m_CompressedSize = -1;
          this.m_UncompressedSize = (int) this.m_WriteMemoryStream.Length;
        }
        else
        {
          this.m_UncompressedSize = -1;
          this.m_CompressedSize = (int) this.m_WriteMemoryStream.Length;
        }
        this.m_ReadMemoryStream = this.m_WriteMemoryStream;
        this.m_StartPosition = 0U;
      }
      else
      {
        w.Close();
        if ((File.GetAttributes(this.PhysicalName) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
          File.SetAttributes(this.PhysicalName, FileAttributes.Archive);
        File.Delete(this.m_PhysicalName);
        File.Move(this.m_PhysicalName + ".temp", this.m_PhysicalName);
      }
      return true;
    }

    public bool Export(string exportDir)
    {
      if (this.m_Name.StartsWith("C:"))
        return false;
      string path = exportDir + "\\" + this.m_Name;
      string directoryName = Path.GetDirectoryName(path);
      Path.GetExtension(path);
      if (!Directory.Exists(directoryName))
        Directory.CreateDirectory(directoryName);
      FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
      BinaryWriter binaryWriter = new BinaryWriter((Stream) fileStream);
      if (this.IsCompressed)
        this.Decompress();
      BinaryReader reader = this.GetReader();
      int count = this.IsCompressed ? this.m_CompressedSize : this.m_UncompressedSize;
      binaryWriter.Write(reader.ReadBytes(count));
      binaryWriter.Close();
      fileStream.Close();
      this.ReleaseReader(reader);
      return true;
    }

    public void Rename(string name)
    {
      this.m_Name = name;
      if (this.Archive != null)
        return;
      string destFileName = Path.GetDirectoryName(this.m_PhysicalName) + "\\" + name;
      File.Move(this.m_PhysicalName, destFileName);
      this.m_PhysicalName = destFileName;
    }

    public bool SetCompressionMode(ECompressionMode compressionMode)
    {
      if (this.m_CurrentCompression == compressionMode)
        return true;
      if (this.m_CurrentCompression != ECompressionMode.None && compressionMode != ECompressionMode.None || (this.m_CurrentCompression != ECompressionMode.None || compressionMode == ECompressionMode.None))
        return false;
      this.m_RequiredCompression = compressionMode;
      this.m_CompressedSize = -1;
      return true;
    }

    private bool Uncompress_10FB(Stream outputStream)
    {
      if (this.m_CompressedSize == -1)
        return false;
      byte[] buffer = FifaFile.Uncompress_10FB(this.Read());
      if (buffer == null)
        return false;
      outputStream.Write(buffer, 0, this.m_UncompressedSize);
      this.m_UncompressedSize = buffer.Length;
      return true;
    }

    private bool UnChunkref(Stream outputStream)
    {
      if (this.m_CompressedSize == -1)
        return false;
      BinaryReader reader = this.GetReader();
      if (new string(reader.ReadChars(8)) != "chunkref")
        return false;
      this.m_UncompressedSize = FifaUtil.SwapEndian(reader.ReadInt32());
      FifaUtil.SwapEndian(reader.ReadInt32());
      int num = 20;
      do
      {
        int count = FifaUtil.SwapEndian(reader.ReadInt32());
        num += 4 + count;
        byte[] buffer = FifaFile.Uncompress_10FB(reader.ReadBytes(count));
        outputStream.Write(buffer, 0, buffer.Length);
      }
      while (num < this.m_CompressedSize);
      this.ReleaseReader(reader);
      return true;
    }

    private bool UnChunkref2(Stream outputStream)
    {
      if (this.m_CompressedSize == -1)
        return false;
      BinaryReader reader = this.GetReader();
      if (new string(reader.ReadChars(8)) != "chunkref")
        return false;
      reader.ReadInt32();
      this.m_UncompressedSize = FifaUtil.SwapEndian(reader.ReadInt32());
      reader.ReadInt32();
      reader.ReadInt32();
      reader.ReadInt32();
      reader.ReadInt32();
      reader.ReadInt32();
      reader.ReadInt32();
      int count = FifaUtil.SwapEndian(reader.ReadInt32());
      reader.ReadInt32();
      byte[] buffer = FifaFile.Uncompress_10FB(reader.ReadBytes(count));
      outputStream.Write(buffer, 0, buffer.Length);
      this.ReleaseReader(reader);
      return true;
    }

    private bool UnChunkZip2(Stream outputStream)
    {
      if (this.m_CompressedSize == -1)
        return false;
      BinaryReader reader = this.GetReader();
      if (new string(reader.ReadChars(8)) != "chunkzip")
        return false;
      reader.ReadInt32();
      this.m_UncompressedSize = FifaUtil.SwapEndian(reader.ReadInt32());
      this.m_MaxBlockUncompressedSize = FifaUtil.SwapEndian(reader.ReadInt32());
      FifaUtil.SwapEndian(reader.ReadInt32());
      FifaUtil.SwapEndian(reader.ReadInt32());
      reader.ReadInt32();
      reader.ReadInt32();
      reader.ReadInt32();
      int num = 40;
      do
      {
        int v = num + 8;
        int count = FifaUtil.RoundUp(v, 16) - v;
        if (count > 0)
        {
          reader.ReadBytes(count);
          v += count;
        }
        int blockCompressedSize = FifaUtil.SwapEndian(reader.ReadInt32());
        reader.ReadInt32();
        num = v + blockCompressedSize;
        this.InflateBlock2(reader.BaseStream, outputStream, blockCompressedSize);
      }
      while (num < this.m_CompressedSize);
      this.ReleaseReader(reader);
      return true;
    }

    private bool UnChunkzip(Stream outputStream)
    {
      if (this.m_CompressedSize == -1)
        return false;
      BinaryReader reader = this.GetReader();
      if (new string(reader.ReadChars(8)) != "chunkzip")
        return false;
      this.m_UncompressedSize = FifaUtil.SwapEndian(reader.ReadInt32());
      this.m_MaxBlockUncompressedSize = FifaUtil.SwapEndian(reader.ReadInt32());
      int num = 16;
      do
      {
        int blockCompressedSize = FifaUtil.SwapEndian(reader.ReadInt32());
        num += 4 + blockCompressedSize;
        this.InflateBlock(reader.BaseStream, outputStream, blockCompressedSize);
      }
      while (num < this.m_CompressedSize);
      this.ReleaseReader(reader);
      return true;
    }

    private bool UnEASF(Stream outputStream)
    {
      if (this.m_CompressedSize == -1)
        return false;
      BinaryReader reader = this.GetReader();
      if (new string(reader.ReadChars(4)) != "EASF")
        return false;
      FifaUtil.SwapEndian(reader.ReadInt32());
      reader.ReadBytes(8);
      this.ReleaseReader(reader);
      return true;
    }

    private void Compress_10FB(Stream outputStream)
    {
      byte[] buffer = this.Compress_10FB(this.Read());
      this.m_CompressedSize = buffer.Length;
      this.m_CurrentCompression = ECompressionMode.Compressed_10FB;
      outputStream.Write(buffer, 0, buffer.Length);
    }

    private void Chunkzip(Stream outputStream)
    {
      this.Chunkzip(outputStream, this.m_UncompressedSize);
    }

    private void Chunkzip(Stream outputStream, int uncompressedSize)
    {
      BinaryReader reader = this.GetReader();
      this.m_UncompressedSize = uncompressedSize;
      this.m_MaxBlockUncompressedSize = 184320;
      BinaryWriter binaryWriter = new BinaryWriter(outputStream);
      long position1 = outputStream.Position;
      binaryWriter.Write('c');
      binaryWriter.Write('h');
      binaryWriter.Write('u');
      binaryWriter.Write('n');
      binaryWriter.Write('k');
      binaryWriter.Write('z');
      binaryWriter.Write('i');
      binaryWriter.Write('p');
      binaryWriter.Write(FifaUtil.SwapEndian(this.m_UncompressedSize));
      binaryWriter.Write(FifaUtil.SwapEndian(this.m_MaxBlockUncompressedSize));
      int num = 0;
      do
      {
        int position2 = (int) outputStream.Position;
        binaryWriter.Write(-1);
        int blockUncompressedSize = this.m_MaxBlockUncompressedSize;
        if (this.m_UncompressedSize - num < this.m_MaxBlockUncompressedSize)
          blockUncompressedSize = this.m_UncompressedSize - num;
        num += blockUncompressedSize;
        int x = this.DeflateBlock(reader.BaseStream, outputStream, blockUncompressedSize);
        int position3 = (int) outputStream.Position;
        outputStream.Position = (long) position2;
        binaryWriter.Write(FifaUtil.SwapEndian(x));
        outputStream.Position = (long) position3;
      }
      while (num < this.m_UncompressedSize);
      this.ReleaseReader(reader);
      this.m_CompressedSize = (int) (outputStream.Position - position1);
    }

    private void Chunkref2(Stream outputStream, int uncompressedSize)
    {
    }

    private void Chunkref(Stream outputStream)
    {
      this.Chunkref(outputStream, this.m_UncompressedSize);
    }

    private void Chunkref(Stream outputStream, int uncompressedSize)
    {
      BinaryReader reader = this.GetReader();
      BinaryWriter binaryWriter = new BinaryWriter(outputStream);
      this.m_UncompressedSize = uncompressedSize;
      this.m_MaxBlockUncompressedSize = 235520;
      long position1 = outputStream.Position;
      binaryWriter.Write('c');
      binaryWriter.Write('h');
      binaryWriter.Write('u');
      binaryWriter.Write('n');
      binaryWriter.Write('k');
      binaryWriter.Write('r');
      binaryWriter.Write('e');
      binaryWriter.Write('f');
      binaryWriter.Write(FifaUtil.SwapEndian(this.m_UncompressedSize));
      binaryWriter.Write(FifaUtil.SwapEndian(this.m_MaxBlockUncompressedSize));
      int num = 0;
      do
      {
        int position2 = (int) outputStream.Position;
        binaryWriter.Write(-1);
        int count = this.m_MaxBlockUncompressedSize;
        if (this.m_UncompressedSize - num < this.m_MaxBlockUncompressedSize)
          count = this.m_UncompressedSize - num;
        num += count;
        byte[] buffer = this.Compress_10FB(reader.ReadBytes(count));
        int length = buffer.Length;
        outputStream.Write(buffer, 0, length);
        long position3 = outputStream.Position;
        outputStream.Position = (long) position2;
        binaryWriter.Write(FifaUtil.SwapEndian(length));
        outputStream.Position = position3;
      }
      while (num < this.m_UncompressedSize);
      this.ReleaseReader(reader);
      this.m_CompressedSize = (int) (outputStream.Position - position1);
      this.m_CurrentCompression = ECompressionMode.Chunkref;
    }

    private void InflateBlock(Stream inputStream, Stream outputStream, int blockCompressedSize)
    {
      ZOutputStream outputStream1 = new ZOutputStream(outputStream);
      FifaFile.CopyStream(inputStream, outputStream1, blockCompressedSize);
    }

    private void InflateBlock2(Stream inputStream, Stream outputStream, int blockCompressedSize)
    {
      ZOutputStream outputStream1 = new ZOutputStream(outputStream);
      FifaFile.CopyStream2(inputStream, outputStream1, blockCompressedSize);
    }

    private int DeflateBlock(Stream inputStream, Stream outputStream, int blockUncompressedSize)
    {
      ZOutputStream outputStream1 = new ZOutputStream(outputStream, -1);
      long position = outputStream.Position;
      FifaFile.CopyStream(inputStream, outputStream1, blockUncompressedSize);
      return (int) (outputStream.Position - position);
    }

    private int Uncompress_10FB_Block(
      Stream inputStream,
      Stream outputStream,
      int blockCompressedSize)
    {
      if (blockCompressedSize == 0)
        return 0;
      byte[] numArray = new byte[blockCompressedSize];
      inputStream.Read(numArray, 0, blockCompressedSize);
      byte[] buffer = FifaFile.Uncompress_10FB(numArray);
      outputStream.Write(buffer, 0, buffer.Length);
      return buffer.Length;
    }

    private int Compress_10FB_Block(
      Stream inputStream,
      Stream outputStream,
      int blockUncompressedSize)
    {
      if (blockUncompressedSize == 0)
        return 0;
      byte[] numArray = new byte[blockUncompressedSize];
      inputStream.Read(numArray, 0, blockUncompressedSize);
      byte[] buffer = this.Compress_10FB(numArray);
      outputStream.Write(buffer, 0, buffer.Length);
      return buffer.Length;
    }

    private static byte[] Uncompress_10FB(byte[] inputBuffer)
    {
      int num1 = 0;
      int num2 = 0;
      int length1 = inputBuffer.Length;
      int num3;
      if (length1 < 8)
      {
        num3 = 1;
        return (byte[]) null;
      }
      int length2 = ((int) inputBuffer[2] << 16) + ((int) inputBuffer[3] << 8) + (int) inputBuffer[4];
      if (length2 > length1 * 128)
      {
        num3 = 2;
        return (byte[]) null;
      }
      byte[] numArray1 = new byte[length2];
      int index1 = ((int) inputBuffer[0] & 1) != 1 ? 5 : 8;
      int index2 = 0;
      while (index1 < length1 && inputBuffer[index1] < (byte) 252)
      {
        byte num4 = inputBuffer[index1++];
        int num5;
        int num6;
        if (((int) num4 & 128) == 0)
        {
          if (index1 + 1 >= length1)
          {
            num2 = 3;
            break;
          }
          num5 = (int) num4 & 3;
          num6 = (((int) num4 & 28) >> 2) + 3;
          num1 = ((int) num4 >> 5 << 8) + (int) inputBuffer[index1++] + 1;
        }
        else if (((int) num4 & 64) == 0)
        {
          if (index1 + 2 >= length1)
          {
            num2 = 4;
            break;
          }
          byte[] numArray2 = inputBuffer;
          int index3 = index1;
          int num7 = index3 + 1;
          byte num8 = numArray2[index3];
          num5 = (int) num8 >> 6 & 3;
          num6 = ((int) num4 & 63) + 4;
          int num9 = ((int) num8 & 63) * 256;
          byte[] numArray3 = inputBuffer;
          int index4 = num7;
          index1 = index4 + 1;
          int num10 = (int) numArray3[index4];
          num1 = num9 + num10 + 1;
        }
        else if (((int) num4 & 32) == 0)
        {
          if (index1 + 3 >= length1)
          {
            num2 = 5;
            break;
          }
          num5 = (int) num4 & 3;
          byte[] numArray2 = inputBuffer;
          int index3 = index1;
          int num7 = index3 + 1;
          byte num8 = numArray2[index3];
          int num9 = (((int) num4 & 16) << 12) + 256 * (int) num8;
          byte[] numArray3 = inputBuffer;
          int index4 = num7;
          int num10 = index4 + 1;
          int num11 = (int) numArray3[index4];
          num1 = num9 + num11 + 1;
          int num12 = ((int) num4 >> 2 & 3) * 256;
          byte[] numArray4 = inputBuffer;
          int index5 = num10;
          index1 = index5 + 1;
          int num13 = (int) numArray4[index5];
          num6 = num12 + num13 + 5;
        }
        else
        {
          num5 = ((int) num4 & 31) * 4 + 4;
          num6 = 0;
        }
        if (index1 + num5 >= length1)
        {
          num2 = 6;
          break;
        }
        if (index2 + num5 + num6 > length2)
        {
          num2 = 7;
          break;
        }
        if (index2 + num5 - num1 < 0)
        {
          num2 = 8;
          break;
        }
        for (int index3 = 0; index3 < num5; ++index3)
          numArray1[index2++] = inputBuffer[index1++];
        for (int index3 = 0; index3 < num6; ++index3)
        {
          numArray1[index2] = numArray1[index2 - num1];
          ++index2;
        }
      }
      if (index1 < length1 && index2 < length2)
      {
        int num4 = (int) inputBuffer[index1] & 3;
        if (index1 + num4 >= length1)
        {
          num2 = 9;
          num4 = 0;
        }
        if (index2 + num4 > length2)
        {
          num2 = 10;
          num4 = 0;
        }
        for (int index3 = 0; index3 < num4; ++index3)
        {
          ++index1;
          numArray1[index2] = inputBuffer[index1];
          ++index2;
        }
      }
      return num2 != 0 || index2 != length2 ? (byte[]) null : numArray1;
    }

    private byte[] Compress_10FB(byte[] inputBuffer)
    {
      int num1 = 0;
      int[] numArray1 = new int[131072];
      for (int index = 0; index < 131072; ++index)
        numArray1[index] = -1;
      int[,] numArray2 = new int[256, 256];
      for (int index1 = 0; index1 < 256; ++index1)
      {
        for (int index2 = 0; index2 < 256; ++index2)
          numArray2[index1, index2] = -1;
      }
      int length1 = inputBuffer.Length;
      byte[] numArray3 = new byte[length1 + 1000];
      numArray3[0] = (byte) 16;
      numArray3[1] = (byte) 251;
      numArray3[2] = (byte) (length1 >> 16);
      numArray3[3] = (byte) (length1 >> 8 & (int) byte.MaxValue);
      numArray3[4] = (byte) (length1 & (int) byte.MaxValue);
      int num2 = 5;
      int index3 = 0;
      int num3 = 0;
      while (index3 < length1 - 1)
      {
        byte num4 = inputBuffer[index3];
        byte num5 = inputBuffer[index3 + 1];
        int num6 = numArray2[(int) num4, (int) num5];
        numArray1[index3 & 131071] = num6;
        numArray2[(int) num4, (int) num5] = index3;
        if (index3 >= num1)
        {
          int num7 = 0;
          int num8 = 0;
          for (int index1 = 0; num6 >= 0 && index3 - num6 < 131072 && index1++ < 100; num6 = numArray1[num6 & 131071])
          {
            int num9 = 2;
            int num10 = num3 + 2;
            if (num10 < length1)
            {
              int num11 = num6 + 2;
              bool flag = false;
              while ((int) inputBuffer[num10++] == (int) inputBuffer[num11++] && num9 < 1028)
              {
                ++num9;
                if (num10 == length1)
                {
                  flag = true;
                  break;
                }
              }
              if (num9 > num7)
              {
                num7 = num9;
                num8 = index3 - num6;
              }
              if (flag || num9 == 1028)
                break;
            }
            else
              break;
          }
          if (num7 > length1 - index3)
            num7 = index3 - length1;
          if (num7 <= 2)
            num7 = 0;
          if (num7 == 3 && num8 > 1024)
            num7 = 0;
          if (num7 == 4 && num8 > 16384)
            num7 = 0;
          if (num7 != 0)
          {
            while (index3 - num1 >= 4)
            {
              int num9 = (index3 - num1) / 4 - 1;
              if (num9 > 27)
                num9 = 27;
              byte[] numArray4 = numArray3;
              int index1 = num2;
              int num10 = index1 + 1;
              int num11 = (int) (byte) (224 + num9);
              numArray4[index1] = (byte) num11;
              int num12 = 4 * num9 + 4;
              for (int index2 = 0; index2 < num12; ++index2)
                numArray3[num10 + index2] = inputBuffer[num1 + index2];
              num1 += num12;
              num2 = num10 + num12;
            }
            int num13 = index3 - num1;
            if (num7 <= 10 && num8 <= 1024)
            {
              byte[] numArray4 = numArray3;
              int index1 = num2;
              int num9 = index1 + 1;
              int num10 = (int) (byte) ((num8 - 1 >> 8 << 5) + (num7 - 3 << 2) + num13);
              numArray4[index1] = (byte) num10;
              byte[] numArray5 = numArray3;
              int index2 = num9;
              num2 = index2 + 1;
              int num11 = (int) (byte) (num8 - 1 & (int) byte.MaxValue);
              numArray5[index2] = (byte) num11;
              while (num13-- != 0)
                numArray3[num2++] = inputBuffer[num1++];
              num1 += num7;
            }
            else if (num7 <= 67 && num8 <= 16384)
            {
              byte[] numArray4 = numArray3;
              int index1 = num2;
              int num9 = index1 + 1;
              int num10 = (int) (byte) (128 + (num7 - 4));
              numArray4[index1] = (byte) num10;
              byte[] numArray5 = numArray3;
              int index2 = num9;
              int num11 = index2 + 1;
              int num12 = (int) (byte) ((num13 << 6) + (num8 - 1 >> 8));
              numArray5[index2] = (byte) num12;
              byte[] numArray6 = numArray3;
              int index4 = num11;
              num2 = index4 + 1;
              int num14 = (int) (byte) (num8 - 1 & (int) byte.MaxValue);
              numArray6[index4] = (byte) num14;
              while (num13-- != 0)
                numArray3[num2++] = inputBuffer[num1++];
              num1 += num7;
            }
            else if (num7 <= 1028 && num8 < 131072)
            {
              int num9 = num8 - 1;
              byte[] numArray4 = numArray3;
              int index1 = num2;
              int num10 = index1 + 1;
              int num11 = (int) (byte) (192 + (num9 >> 16 << 4) + (num7 - 5 >> 8 << 2) + num13);
              numArray4[index1] = (byte) num11;
              byte[] numArray5 = numArray3;
              int index2 = num10;
              int num12 = index2 + 1;
              int num14 = (int) (byte) (num9 >> 8 & (int) byte.MaxValue);
              numArray5[index2] = (byte) num14;
              byte[] numArray6 = numArray3;
              int index4 = num12;
              int num15 = index4 + 1;
              int num16 = (int) (byte) (num9 & (int) byte.MaxValue);
              numArray6[index4] = (byte) num16;
              byte[] numArray7 = numArray3;
              int index5 = num15;
              num2 = index5 + 1;
              int num17 = (int) (byte) (num7 - 5 & (int) byte.MaxValue);
              numArray7[index5] = (byte) num17;
              while (num13-- != 0)
                numArray3[num2++] = inputBuffer[num1++];
              num1 += num7;
            }
          }
        }
        ++index3;
        ++num3;
      }
      int num18 = length1;
      while (num18 - num1 >= 4)
      {
        int num4 = (num18 - num1) / 4 - 1;
        if (num4 > 27)
          num4 = 27;
        byte[] numArray4 = numArray3;
        int index1 = num2;
        int num5 = index1 + 1;
        int num6 = (int) (byte) (224 + num4);
        numArray4[index1] = (byte) num6;
        int num7 = 4 * num4 + 4;
        for (int index2 = 0; index2 < num7; ++index2)
          numArray3[num5 + index2] = inputBuffer[num1 + index2];
        num1 += num7;
        num2 = num5 + num7;
      }
      int num19 = num18 - num1;
      byte[] numArray8 = numArray3;
      int index6 = num2;
      int length2 = index6 + 1;
      int num20 = (int) (byte) (252 + num19);
      numArray8[index6] = (byte) num20;
      while (num19-- != 0)
        numArray3[length2++] = inputBuffer[num1++];
      if (num1 != length1)
        return (byte[]) null;
      byte[] numArray9 = new byte[length2];
      for (int index1 = 0; index1 < length2; ++index1)
        numArray9[index1] = numArray3[index1];
      return numArray9;
    }

    private static void CopyStream(Stream inputStream, ZOutputStream outputStream, int size)
    {
      int offset = 0;
      byte[] buffer = new byte[size + offset];
      inputStream.Read(buffer, offset, size);
      outputStream.Write(buffer, 0, size + offset);
      outputStream.finish();
      outputStream.Flush();
    }

    private static void CopyStream2(Stream inputStream, ZOutputStream outputStream, int size)
    {
      int offset = 2;
      byte[] buffer = new byte[size + offset];
      buffer[0] = (byte) 120;
      buffer[1] = (byte) 218;
      inputStream.Read(buffer, offset, size);
      outputStream.Write(buffer, 0, size + offset);
      outputStream.Flush();
    }
  }
}
