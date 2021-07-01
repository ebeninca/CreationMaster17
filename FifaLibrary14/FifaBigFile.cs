// Original code created by Rinaldo

using System;
using System.Collections;
using System.IO;

namespace FifaLibrary
{
  public class FifaBigFile : FifaFile
  {
    private static FifaBigFile.StringComparer s_StringComparer = new FifaBigFile.StringComparer();
    private int m_Alignement = 16;
    private int m_TotalFileSize;
    private int m_NFiles;
    private int m_HeaderSize;
    private FifaFileHeader[] m_Headers;
    private FifaFile[] m_Files;
    private byte[] m_EndSignature;

    public int NFiles
    {
      get
      {
        return this.m_NFiles;
      }
    }

    public FifaFileHeader[] Headers
    {
      get
      {
        return this.m_Headers;
      }
    }

    public FifaFile[] Files
    {
      get
      {
        return this.m_Files;
      }
    }

    private int EstimateAlignement()
    {
      int num = 256;
      for (int index = 0; index < this.m_NFiles; ++index)
      {
        int alignementLong = FifaUtil.ComputeAlignementLong((long) this.m_Headers[index].StartPosition);
        if (alignementLong < num)
          num = alignementLong;
      }
      return num;
    }

    public FifaBigFile(FifaFile fifaFile)
      : base(fifaFile)
    {
      if (this.IsCompressed)
        this.Decompress();
      BinaryReader reader = this.GetReader();
      this.Load(reader);
      this.ReleaseReader(reader);
    }

    public FifaBigFile(string fileName)
      : base(fileName, true)
    {
      if (this.IsCompressed)
        this.Decompress();
      BinaryReader reader = this.GetReader();
      this.Load(reader);
      this.ReleaseReader(reader);
    }

    private bool Load(BinaryReader r)
    {
      char[] chArray = r.ReadChars(4);
      if (chArray[0] != 'B' || chArray[1] != 'I' || chArray[2] != 'G' || chArray[3] != 'F' && chArray[3] != '4')
        return false;
      this.m_TotalFileSize = r.ReadInt32();
      this.m_NFiles = FifaUtil.SwapEndian(r.ReadInt32());
      this.m_HeaderSize = FifaUtil.SwapEndian(r.ReadInt32());
      this.m_Headers = new FifaFileHeader[this.m_NFiles];
      this.m_Files = new FifaFile[this.m_NFiles];
      for (int index = 0; index < this.m_NFiles; ++index)
      {
        this.m_Headers[index] = new FifaFileHeader(this);
        this.m_Headers[index].Load(r);
      }
      if (this.m_HeaderSize == (int) r.BaseStream.Position + 8)
        this.m_EndSignature = r.ReadBytes(8);
      this.m_Alignement = this.EstimateAlignement();
      return true;
    }

    public bool LoadArchivedFiles()
    {
      BinaryReader reader = this.GetReader();
      this.m_Files = new FifaFile[this.m_NFiles];
      for (int index = 0; index < this.m_NFiles; ++index)
        this.m_Files[index] = new FifaFile(this.m_Headers[index], reader);
      this.ReleaseReader(reader);
      return true;
    }

    public bool LoadArchivedFile(int fileIndex)
    {
      if (fileIndex < 0 || fileIndex >= this.m_NFiles)
        return false;
      BinaryReader reader = this.GetReader();
      this.m_Files[fileIndex] = new FifaFile(this.m_Headers[fileIndex], reader);
      this.ReleaseReader(reader);
      return true;
    }

    public FifaFile[] GetArchivedFiles(string searchPattern, bool useFullPath)
    {
      bool[] flagArray = new bool[this.m_NFiles];
      int length = 0;
      for (int index = 0; index < this.m_NFiles; ++index)
      {
        string str = this.m_Headers[index].Name;
        if (!useFullPath)
          str = Path.GetFileName(str);
        if (flagArray[index] = FifaUtil.CompareWildcardString(searchPattern, str))
          ++length;
      }
      FifaFile[] fifaFileArray = new FifaFile[length];
      if (length == 0)
        return fifaFileArray;
      BinaryReader r = (BinaryReader) null;
      for (int index = 0; index < this.m_NFiles; ++index)
      {
        if (flagArray[index] && this.m_Files[index] == null)
        {
          r = this.GetReader();
          break;
        }
      }
      int num = 0;
      for (int index = 0; index < this.m_NFiles; ++index)
      {
        if (flagArray[index])
        {
          if (this.m_Files[index] == null)
            this.m_Files[index] = new FifaFile(this.m_Headers[index], r);
          fifaFileArray[num++] = this.m_Files[index];
        }
      }
      if (r != null)
        this.ReleaseReader(r);
      return fifaFileArray;
    }

    public string[] GetArchivedFileNames(string searchPattern, bool useFullPath)
    {
      bool[] flagArray = new bool[this.m_NFiles];
      int length = 0;
      for (int index = 0; index < this.m_NFiles; ++index)
      {
        string str = this.m_Headers[index].Name;
        if (!useFullPath)
          str = Path.GetFileName(str);
        if (flagArray[index] = FifaUtil.CompareWildcardString(searchPattern, str))
          ++length;
      }
      string[] strArray = new string[length];
      int num = 0;
      for (int index = 0; index < this.m_NFiles; ++index)
      {
        if (flagArray[index])
          strArray[num++] = this.m_Headers[index].Name;
      }
      return strArray;
    }

    public FifaFile GetArchivedFile(string fileName, bool useFullPath)
    {
      FifaFile[] archivedFiles = this.GetArchivedFiles(fileName, useFullPath);
      if (archivedFiles.Length == 0)
        return (FifaFile) null;
      return archivedFiles.Length > 1 ? (FifaFile) null : archivedFiles[0];
    }

    public int GetArchivedFileIndex(string fileName, bool useFullPath)
    {
      if (!useFullPath)
        fileName = Path.GetFileName(fileName);
      for (int index = 0; index < this.m_NFiles; ++index)
      {
        if (FifaUtil.CompareWildcardString(fileName, this.m_Headers[index].Name))
          return index;
      }
      return -1;
    }

    public FifaFile GetArchivedFile(int fileIndex)
    {
      if (fileIndex < 0 || fileIndex >= this.NFiles)
        return (FifaFile) null;
      if (this.m_Files[fileIndex] == null)
      {
        BinaryReader reader = this.GetReader();
        this.m_Files[fileIndex] = new FifaFile(this.m_Headers[fileIndex], reader);
        this.ReleaseReader(reader);
      }
      return this.m_Files[fileIndex];
    }

    public bool Export(string fileName, string exportDir)
    {
      FifaFile archivedFile = this.GetArchivedFile(fileName, true);
      return archivedFile != null && archivedFile.UncompressedSize != 0 && archivedFile.Export(exportDir);
    }

    public bool Export(int fileIndex, string exportDir)
    {
      FifaFile archivedFile = this.GetArchivedFile(fileIndex);
      return archivedFile != null && archivedFile.UncompressedSize != 0 && archivedFile.Export(exportDir);
    }

    public bool Export(string[] fileNames, string exportDir)
    {
      bool flag1 = false;
      if (fileNames.Length == 0)
        return false;
      for (int index = 0; index < fileNames.Length; ++index)
      {
        bool flag2 = this.Export(fileNames[index], exportDir);
        flag1 = flag1 || flag2;
      }
      return flag1;
    }

    public void ImportReplacingFile(string path, int fileIndex)
    {
      FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
      BinaryReader binaryReader = new BinaryReader((Stream) fileStream);
      byte[] buffer = binaryReader.ReadBytes((int) binaryReader.BaseStream.Length);
      fileStream.Close();
      binaryReader.Close();
      FifaFile archivedFile = this.GetArchivedFile(fileIndex);
      if (archivedFile.CompressionMode == ECompressionMode.Chunkzip2)
        this.m_Files[fileIndex] = new FifaFile(this, buffer, archivedFile.Name, ECompressionMode.None);
      else
        this.m_Files[fileIndex] = new FifaFile(this, buffer, archivedFile.Name, archivedFile.CompressionMode);
    }

    public int ImportNewFile(string path, ECompressionMode compressionMode)
    {
      string fileName = Path.GetFileName(path);
      return this.ImportNewFileAs(path, fileName, compressionMode);
    }

    public int ImportNewFileAs(string path, string archivedName, ECompressionMode compressionMode)
    {
      if (this.m_Files == null || this.m_Files.Length <= this.m_NFiles + 1)
        this.Resize(this.m_NFiles + 32);
      FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
      BinaryReader binaryReader = new BinaryReader((Stream) fileStream);
      byte[] buffer = binaryReader.ReadBytes((int) binaryReader.BaseStream.Length);
      fileStream.Close();
      binaryReader.Close();
      this.m_Files[this.m_NFiles] = new FifaFile(this, buffer, archivedName, compressionMode);
      ++this.m_NFiles;
      return this.m_NFiles - 1;
    }

    public void ImportFile(string path, ECompressionMode compressionMode)
    {
      int archivedFileIndex = this.GetArchivedFileIndex(Path.GetFileName(path), true);
      if (archivedFileIndex != -1)
        this.ImportReplacingFile(path, archivedFileIndex);
      else
        this.ImportNewFile(path, compressionMode);
    }

    public void ImportFileAs(string path, string archivedName, ECompressionMode compressionMode)
    {
      int archivedFileIndex = this.GetArchivedFileIndex(archivedName, true);
      if (archivedFileIndex != -1)
        this.ImportReplacingFile(path, archivedFileIndex);
      else
        this.ImportNewFileAs(path, archivedName, compressionMode);
    }

    public void Resize(int nFiles)
    {
      if (this.m_NFiles == 0)
      {
        this.m_Files = new FifaFile[nFiles];
      }
      else
      {
        int nfiles = this.m_NFiles;
        FifaFile[] fifaFileArray = (FifaFile[]) this.m_Files.Clone();
        this.m_Files = new FifaFile[nFiles];
        if (nFiles < this.m_NFiles)
          Array.Copy((Array) fifaFileArray, 0, (Array) this.m_Files, 0, nFiles);
        if (nFiles <= this.m_NFiles)
          return;
        Array.Copy((Array) fifaFileArray, 0, (Array) this.m_Files, 0, this.m_NFiles);
      }
    }

    private int ComputeHeaderSize()
    {
      int v = 16;
      for (int index = 0; index < this.m_NFiles; ++index)
        v = v + (this.m_Headers[index].Name.Length + 1) + 8;
      this.m_HeaderSize = v;
      if (this.m_EndSignature != null)
        this.m_HeaderSize += this.m_EndSignature.Length;
      return FifaUtil.RoundUp(v, this.m_Alignement);
    }

    public void Save()
    {
      BinaryReader r = (BinaryReader) null;
      BinaryWriter writer;
      if (this.NFiles == 0)
      {
        writer = this.GetWriter();
        writer.Write(0);
      }
      else
      {
        writer = this.GetWriter();
        r = this.GetReader();
        this.ComputeHeaderSize();
        writer.BaseStream.Position = (long) this.m_HeaderSize;
        for (int index = 0; index < this.m_NFiles; ++index)
        {
          if (this.m_Files[index] == null)
            this.m_Files[index] = new FifaFile(this.m_Headers[index], r);
          this.m_Headers[index].StartPosition = (uint) writer.BaseStream.Position;
          this.m_Headers[index].Name = this.m_Files[index].Name;
          this.m_Files[index].Save(writer);
          this.m_Headers[index].Size = !this.m_Files[index].IsToCompress ? this.m_Files[index].UncompressedSize : this.m_Files[index].CompressedSize;
          int num = FifaUtil.RoundUp((int) writer.BaseStream.Position, this.m_Alignement);
          writer.BaseStream.Position = (long) num;
        }
        this.m_TotalFileSize = (int) writer.BaseStream.Position;
        writer.Seek(0, SeekOrigin.Begin);
        writer.Write('B');
        writer.Write('I');
        writer.Write('G');
        writer.Write('4');
        writer.Write(this.m_TotalFileSize);
        writer.Write(FifaUtil.SwapEndian(this.m_NFiles));
        writer.Write(FifaUtil.SwapEndian(this.m_HeaderSize));
        for (int index = 0; index < this.m_NFiles; ++index)
          this.m_Headers[index].Save(writer);
        if (this.m_EndSignature != null)
          writer.Write(this.m_EndSignature);
      }
      this.ReleaseReader(r);
      this.ReleaseWriter(writer);
      if (this.Archive == null)
      {
        if (!this.IsInMemory)
          return;
        if (File.Exists(this.PhysicalName) && (File.GetAttributes(this.PhysicalName) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
          File.SetAttributes(this.PhysicalName, FileAttributes.Archive);
        FileStream fileStream = new FileStream(this.PhysicalName, FileMode.Create, FileAccess.Write);
        BinaryWriter binaryWriter = new BinaryWriter((Stream) fileStream);
        this.Save((Stream) fileStream);
        fileStream.Close();
      }
      else
        this.Archive.Save();
    }

    public void Sort()
    {
      string[] strArray1 = new string[this.m_NFiles];
      string[] strArray2 = new string[this.m_NFiles];
      for (int index = 0; index < this.m_NFiles; ++index)
      {
        strArray1[index] = this.Files[index].Name;
        strArray2[index] = this.Files[index].Name;
      }
      Array.Sort((Array) strArray1, (Array) this.m_Files, (IComparer) FifaBigFile.s_StringComparer);
    }

    public bool Delete(int index)
    {
      if (index >= this.m_NFiles)
        return false;
      --this.m_NFiles;
      for (int index1 = index; index1 < this.m_NFiles; ++index1)
        this.m_Files[index1] = this.m_Files[index1 + 1];
      for (int index1 = index; index1 < this.m_NFiles; ++index1)
        this.m_Headers[index1] = this.m_Headers[index1 + 1];
      return true;
    }

    public bool Delete(string fileName)
    {
      int archivedFileIndex = this.GetArchivedFileIndex(fileName, true);
      return archivedFileIndex >= 0 && this.Delete(archivedFileIndex);
    }

    public bool Delete(FifaFile fifaFile)
    {
      return this.Delete(fifaFile.Name);
    }

    public int Delete(string[] fileNames)
    {
      int num = 0;
      for (int index = 0; index < fileNames.Length; ++index)
      {
        if (this.Delete(fileNames[index]))
          ++num;
      }
      return num;
    }

    public void Rename(string originalName, string newName)
    {
      this.GetArchivedFile(originalName, true)?.Rename(newName);
    }

    public FifaFile GetFirstDds()
    {
      for (int index = 0; index < this.m_NFiles; ++index)
      {
        if (this.m_Files[index] == null)
        {
          this.LoadArchivedFiles();
          break;
        }
      }
      for (int index = 0; index < this.m_NFiles; ++index)
      {
        if (this.m_Files[index].IsDds())
          return this.m_Files[index];
      }
      return (FifaFile) null;
    }

    public class StringComparer : IComparer
    {
      int IComparer.Compare(object x, object y)
      {
        return string.Compare((string) x, (string) y, StringComparison.Ordinal);
      }
    }
  }
}
