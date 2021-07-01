// Original code created by Rinaldo

using System;
using System.IO;

namespace FifaLibrary
{
  public class BhFile
  {
    private int m_TotalFileSize;
    private int m_NFiles;
    private BhFileReference[] m_BhFileReference;
    private string m_BhName;
    private int m_TotalBigFileSize;

    public int NFiles
    {
      get
      {
        return this.m_NFiles;
      }
    }

    private bool Load(string fileName)
    {
      if (!File.Exists(fileName))
        return false;
      this.m_BhName = fileName;
      FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
      BinaryReader r = new BinaryReader((Stream) fileStream);
      char[] chArray = r.ReadChars(4);
      if (chArray[0] != 'V' || chArray[1] != 'i' || (chArray[2] != 'V' || chArray[3] != '4'))
      {
        r.Close();
        fileStream.Close();
        return false;
      }
      this.m_TotalFileSize = r.ReadInt32();
      this.m_NFiles = FifaUtil.SwapEndian(r.ReadInt32());
      FifaUtil.SwapEndian(r.ReadInt32());
      this.m_BhFileReference = new BhFileReference[this.m_NFiles];
      for (int index = 0; index < this.m_NFiles; ++index)
      {
        this.m_BhFileReference[index] = new BhFileReference();
        this.m_BhFileReference[index].Load(r);
      }
      if (r.BaseStream.Position <= r.BaseStream.Length - 4L)
        this.m_TotalBigFileSize = FifaUtil.SwapEndian(r.ReadInt32());
      r.Close();
      fileStream.Close();
      return true;
    }

    public bool Load(FifaBigFile bigFile, bool hideExternalFiles)
    {
      string str;
      if (FifaEnvironment.Year == 14)
      {
        int num = bigFile.PhysicalName.IndexOf("\\Game\\", 0, StringComparison.InvariantCultureIgnoreCase);
        str = num < 0 ? Path.GetDirectoryName(bigFile.PhysicalName) + "\\" : bigFile.PhysicalName.Substring(0, num + 6);
      }
      else
      {
        int num = bigFile.PhysicalName.IndexOf("\\FIFA 15\\", 0, StringComparison.InvariantCultureIgnoreCase);
        str = num < 0 ? Path.GetDirectoryName(bigFile.PhysicalName) + "\\" : bigFile.PhysicalName.Substring(0, num + 9);
      }
      this.m_BhName = Path.GetDirectoryName(bigFile.PhysicalName) + "\\" + Path.GetFileNameWithoutExtension(bigFile.PhysicalName) + ".bh";
      this.m_NFiles = bigFile.NFiles;
      this.m_TotalFileSize = !this.m_BhName.Contains("FIFA 11") ? 16 + this.m_NFiles * 20 : 16 + (this.m_NFiles + 1) * 20;
      this.m_BhFileReference = new BhFileReference[this.m_NFiles];
      this.m_TotalBigFileSize = bigFile.UncompressedSize;
      for (int fileIndex = 0; fileIndex < this.m_NFiles; ++fileIndex)
      {
        uint startPosition = bigFile.Headers[fileIndex].StartPosition;
        int size = bigFile.Headers[fileIndex].Size;
        if (bigFile.Files[fileIndex] == null)
          bigFile.LoadArchivedFile(fileIndex);
        int uncompressedSize = bigFile.Files[fileIndex].CompressionMode != ECompressionMode.Compressed_10FB ? 0 : bigFile.Files[fileIndex].UncompressedSize;
        string name = bigFile.Headers[fileIndex].Name;
        this.m_BhFileReference[fileIndex] = new BhFileReference(startPosition, size, uncompressedSize, name);
        if (hideExternalFiles && File.Exists(str + name))
          this.m_BhFileReference[fileIndex].Hide();
      }
      return true;
    }

    public bool Hide(string fileName)
    {
      return this.Hide(this.GetArchivedFileIndex(fileName));
    }

    public bool Hide(int fileIndex)
    {
      if (fileIndex < 0 || fileIndex >= this.m_NFiles)
        return false;
      this.m_BhFileReference[fileIndex].Hide();
      return true;
    }

    public bool IsHidden(int fileIndex)
    {
      return fileIndex >= 0 && fileIndex < this.m_NFiles && this.m_BhFileReference[fileIndex].IsHidden();
    }

    public bool IsHidden(string fileName)
    {
      return this.IsHidden(this.GetArchivedFileIndex(fileName));
    }

    public bool Restore(string fileName, int fileIndex)
    {
      if (fileIndex < 0 || fileIndex >= this.m_NFiles)
        return false;
      this.m_BhFileReference[fileIndex].Restore(fileName);
      return true;
    }

    public BhFile(FifaBigFile bigFile, bool hideExternalFiles)
    {
      this.Load(bigFile, hideExternalFiles);
    }

    public BhFile(string fileName)
    {
      if (this.Load(fileName))
        this.m_BhName = fileName;
      else
        this.Reset();
    }

    private void Reset()
    {
      this.m_TotalFileSize = 0;
      this.m_NFiles = 0;
      this.m_BhFileReference = (BhFileReference[]) null;
      this.m_BhName = (string) null;
      this.m_TotalBigFileSize = 0;
    }

    public static void Regenerate(FifaBigFile bigFile, bool hideExternalFiles)
    {
      new BhFile(bigFile, hideExternalFiles).Save();
    }

    public static void Regenerate(string bigFileName, bool hideExternalFiles)
    {
      FifaBigFile bigFile = new FifaBigFile(bigFileName);
      if (bigFile == null)
        return;
      bigFile.LoadArchivedFiles();
      BhFile.Regenerate(bigFile, hideExternalFiles);
    }

    public bool Save()
    {
      string bhName = this.m_BhName;
      if (this.m_BhName == null)
        return false;
      if (File.Exists(bhName) && (File.GetAttributes(bhName) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
        File.SetAttributes(bhName, FileAttributes.Archive);
      FileStream fileStream = new FileStream(bhName, FileMode.Create, FileAccess.Write);
      BinaryWriter w = new BinaryWriter((Stream) fileStream);
      if (this.m_NFiles == 0)
      {
        w.Write((byte) 0);
      }
      else
      {
        w.Write((byte) 86);
        w.Write((byte) 105);
        w.Write((byte) 86);
        w.Write((byte) 52);
        w.Write(this.m_TotalFileSize);
        w.Write(FifaUtil.SwapEndian(this.m_NFiles));
        w.Write(FifaUtil.SwapEndian(this.m_TotalFileSize));
        for (int index = 0; index < this.m_NFiles; ++index)
          this.m_BhFileReference[index].Save(w);
      }
      w.Close();
      fileStream.Close();
      return true;
    }

    private bool SaveEmptyReference(BinaryWriter w)
    {
      for (int index = 0; index < 4; ++index)
        w.Write(0);
      return true;
    }

    public int GetArchivedFileIndex(ulong hash)
    {
      for (int index = 0; index < this.m_NFiles; ++index)
      {
        if ((long) this.m_BhFileReference[index].Hash == (long) hash)
          return index;
      }
      return -1;
    }

    public int GetArchivedFileIndex(string fileName)
    {
      return this.GetArchivedFileIndex(FifaUtil.ComputeBhHash(fileName));
    }

    public ulong GetHash(int fileIndex)
    {
      return fileIndex < this.m_NFiles ? this.m_BhFileReference[fileIndex].Hash : 0UL;
    }

    public bool IsArchivedFilePresent(string fileName)
    {
      return this.GetArchivedFileIndex(FifaUtil.ComputeBhHash(fileName)) >= 0;
    }

    public bool IsArchivedFilePresent(ulong hash)
    {
      return this.GetArchivedFileIndex(hash) >= 0;
    }

    public bool Delete(int index)
    {
      if (index >= this.m_NFiles)
        return false;
      --this.m_NFiles;
      for (int index1 = index; index1 < this.m_NFiles; ++index1)
        this.m_BhFileReference[index1] = this.m_BhFileReference[index1 + 1];
      this.m_TotalFileSize -= 20;
      return true;
    }
  }
}
