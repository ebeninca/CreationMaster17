// Original code created by Rinaldo

using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace FifaLibrary
{
  public class FifaFat
  {
    private BhFile[] m_BhFiles = new BhFile[100];
    private FifaBigFile[] m_BigFiles = new FifaBigFile[100];
    private bool[] m_NeedToSaveBig = new bool[100];
    private string[] m_BigFileNames = new string[100];
    private string[] m_BhFileNames = new string[100];
    private int m_MinZdata = 8;
    private int m_DeafultDataIndex = -1;
    private ToolStripProgressBar m_ProgressBar;
    private string m_GamePath;
    private int m_NBigFiles;
    private FifaFat.EFifaFatSaveOption m_SaveOption;

    public ToolStripProgressBar ProgressBar
    {
      set
      {
        this.m_ProgressBar = value;
      }
    }

    public string GamePath
    {
      get
      {
        return this.m_GamePath;
      }
    }

    public BhFile GetBhFile(int index)
    {
      return index < 0 || index >= this.m_NBigFiles ? (BhFile) null : this.m_BhFiles[index];
    }

    public FifaBigFile GetBigFile(int index)
    {
      if (index < 0 || index >= this.m_NBigFiles)
        return (FifaBigFile) null;
      if (this.m_BigFiles[index] != null)
        return this.m_BigFiles[index];
      this.m_BigFiles[index] = new FifaBigFile(this.m_BigFileNames[index]);
      return this.m_BigFiles[index];
    }

    public int NBigFiles
    {
      get
      {
        return this.m_NBigFiles;
      }
    }

    public FifaFat.EFifaFatSaveOption SaveOption
    {
      get
      {
        return this.m_SaveOption;
      }
      set
      {
        this.m_SaveOption = value;
      }
    }

    public int Min_Zdata
    {
      get
      {
        return this.m_MinZdata;
      }
      set
      {
        this.m_MinZdata = value;
      }
    }

    public static FifaFat Create(string gamePath)
    {
      if (!Directory.Exists(gamePath))
        return (FifaFat) null;
      FifaFat fifaFat = new FifaFat();
      fifaFat.m_GamePath = gamePath;
      fifaFat.Load();
      fifaFat.m_SaveOption = FifaFat.EFifaFatSaveOption.SaveAlways;
      return fifaFat;
    }

    private void LoadBigFromFolder(string folder)
    {
      if (!Directory.Exists(folder))
        return;
      string[] files = Directory.GetFiles(folder, "*.big");
      if (files == null)
        return;
      foreach (string path in files)
      {
        string str1 = path;
        string str2 = folder + Path.GetFileNameWithoutExtension(path) + ".bh";
        if (File.Exists(str1))
        {
          this.m_BigFileNames[this.m_NBigFiles] = str1;
          this.m_BhFileNames[this.m_NBigFiles] = str2;
          if (File.Exists(str2))
          {
            this.m_BhFiles[this.m_NBigFiles] = new BhFile(str2);
          }
          else
          {
            this.m_BigFiles[this.m_NBigFiles] = new FifaBigFile(str1);
            if (this.m_BhFiles[this.m_NBigFiles] == null)
            {
              this.m_BigFiles[this.m_NBigFiles].LoadArchivedFiles();
              this.m_BhFiles[this.m_NBigFiles] = new BhFile(this.m_BigFiles[this.m_NBigFiles], true);
            }
          }
          ++this.m_NBigFiles;
        }
      }
    }

    private void Load()
    {
      this.m_NBigFiles = 0;
      this.LoadBigFromFolder(this.m_GamePath);
      this.LoadBigFromFolder(this.m_GamePath + "data\\ui\\imgAssets\\heads\\");
    }

    public void Save()
    {
      for (int index = 0; index <= this.m_NBigFiles; ++index)
      {
        if (this.m_NeedToSaveBig[index])
          this.GetBigFile(index).Save();
        if (this.m_BhFiles[index] != null)
          this.m_BhFiles[index].Save();
      }
    }

    public void RegenerateAllBh(bool hideExternalFiles)
    {
      if (this.m_ProgressBar != null)
      {
        this.m_ProgressBar.Maximum = this.m_NBigFiles;
        this.m_ProgressBar.Value = 0;
      }
      for (int index = 0; index < this.m_NBigFiles; ++index)
      {
        string bigFileNameByIndex = this.GetBigFileNameByIndex(index);
        if (File.Exists(bigFileNameByIndex))
        {
          BhFile.Regenerate(bigFileNameByIndex, hideExternalFiles);
          if (this.m_ProgressBar != null)
            this.m_ProgressBar.Value = index;
        }
      }
      if (this.m_ProgressBar != null)
        this.m_ProgressBar.Value = 0;
      this.Load();
    }

    public bool IsArchivedFilePresent(string fileName)
    {
      return this.GetArchivingBhFileIndex(fileName) >= 0;
    }

    public bool IsPhisycalFilePresent(string fileName)
    {
      return File.Exists(this.m_GamePath + fileName);
    }

    public bool IsHeadFilePresent(string fileName)
    {
      for (int index = this.m_NBigFiles - 1; index >= 0; --index)
      {
        if (this.m_BhFileNames[index].Contains("heads") && this.m_BhFiles[index].GetArchivedFileIndex(fileName) >= 0)
          return true;
      }
      return false;
    }

    public string GetBigFileNameByIndex(int index)
    {
      return index < this.m_NBigFiles ? this.m_BigFileNames[index] : (string) null;
    }

    public string GetBhFileName(int bigIndex)
    {
      return this.m_GamePath + "data" + bigIndex.ToString() + ".bh";
    }

    public string GetBigFileName(int bigIndex)
    {
      return this.m_GamePath + "data" + bigIndex.ToString() + ".big";
    }

    public static string GetBhFileName(int bigIndex, string rootPath)
    {
      return rootPath + "data" + bigIndex.ToString() + ".bh";
    }

    public static string GetBigFileName(int bigIndex, string rootPath)
    {
      return rootPath + "\\Game\\data" + bigIndex.ToString() + ".big";
    }

    public FifaFile GetArchivedFile(string fileName)
    {
      ulong bhHash = FifaUtil.ComputeBhHash(fileName);
      for (int index = this.m_NBigFiles - 1; index >= 0; --index)
      {
        if (this.m_BhFiles[index] != null)
        {
          int archivedFileIndex = this.m_BhFiles[index].GetArchivedFileIndex(bhHash);
          if (archivedFileIndex >= 0)
            return this.GetBigFile(index).GetArchivedFile(archivedFileIndex);
        }
      }
      return (FifaFile) null;
    }

    public bool DeleteFile(string fileName)
    {
      int archivingBhFileIndex = this.GetArchivingBhFileIndex(fileName);
      if (archivingBhFileIndex < 0)
        return false;
      int archivedFileIndex = this.m_BhFiles[archivingBhFileIndex].GetArchivedFileIndex(fileName);
      if (archivedFileIndex < 0)
        return false;
      this.GetBigFile(archivingBhFileIndex).Delete(archivedFileIndex);
      this.m_BhFiles[archivingBhFileIndex].Delete(archivedFileIndex);
      if (this.m_SaveOption == FifaFat.EFifaFatSaveOption.SaveAlways)
      {
        this.GetBigFile(archivingBhFileIndex).Save();
        this.m_BhFiles[archivingBhFileIndex].Save();
      }
      else
        this.m_NeedToSaveBig[archivingBhFileIndex] = true;
      return true;
    }

    public bool HideFile(string fileName)
    {
      int archivingBhFileIndex = this.GetArchivingBhFileIndex(fileName);
      if (archivingBhFileIndex < 0)
        return false;
      int archivedFileIndex = this.m_BhFiles[archivingBhFileIndex].GetArchivedFileIndex(fileName);
      return this.m_BhFiles[archivingBhFileIndex].Hide(archivedFileIndex);
    }

    public bool RestoreFile(string fileName)
    {
      int fileIndex;
      int archivingBigFileIndex = this.GetArchivingBigFileIndex(fileName, out fileIndex);
      return archivingBigFileIndex >= 0 && this.m_BhFiles[archivingBigFileIndex].Restore(fileName, fileIndex);
    }

    public bool ExportFile(string fileName, string exportDir)
    {
      int archivingBhFileIndex = this.GetArchivingBhFileIndex(fileName);
      if (archivingBhFileIndex < 0)
        return false;
      int archivedFileIndex = this.m_BhFiles[archivingBhFileIndex].GetArchivedFileIndex(fileName);
      return this.GetBigFile(archivingBhFileIndex).Export(archivedFileIndex, exportDir);
    }

    public bool ExportFile(string fileName)
    {
      return this.ExportFile(fileName, this.m_GamePath);
    }

    public bool ExtractFile(string fileName)
    {
      int archivingBhFileIndex = this.GetArchivingBhFileIndex(fileName);
      if (archivingBhFileIndex < 0)
        return false;
      int archivedFileIndex = this.m_BhFiles[archivingBhFileIndex].GetArchivedFileIndex(fileName);
      bool flag = this.GetBigFile(archivingBhFileIndex).Export(archivedFileIndex, this.m_GamePath);
      if (flag)
        flag = this.m_BhFiles[archivingBhFileIndex].Hide(archivedFileIndex);
      return flag;
    }

    public bool ImportFileAs(
      string fileName,
      string archivedName,
      bool delete,
      ECompressionMode compressionMode)
    {
      delete = delete && !fileName.Contains("#");
      archivedName = archivedName.Replace('\\', '/');
      int index = this.m_DeafultDataIndex;
      if (index < 0)
      {
        index = this.GetArchivingBhFileIndex(archivedName);
        if (index < 0)
          index = this.GetAvailableBigFileIndex();
      }
      if (index < 0)
        return false;
      this.GetBigFile(index).ImportFileAs(fileName, archivedName, compressionMode);
      if (this.m_SaveOption == FifaFat.EFifaFatSaveOption.SaveAlways)
      {
        this.GetBigFile(index).Save();
        this.m_BhFiles[index] = new BhFile(this.GetBigFile(index), true);
        this.m_BhFiles[index].Save();
      }
      else
      {
        this.m_BhFiles[index] = new BhFile(this.GetBigFile(index), true);
        this.m_NeedToSaveBig[index] = true;
      }
      if (delete)
        File.Delete(fileName);
      return true;
    }

    public bool ImportFile(string fileName, bool delete, ECompressionMode compressionMode)
    {
      string fileName1 = Path.GetFileName(fileName);
      return this.ImportFileAs(fileName, fileName1, delete, compressionMode);
    }

    public ECompressionMode GetCompressionMode(string fileName)
    {
      FifaFile archivedFile = this.GetArchivedFile(fileName);
      return archivedFile == null ? ECompressionMode.None : archivedFile.CompressionMode;
    }

    private FifaBigFile GetArchivingBigFile(string fileName)
    {
      int archivingBhFileIndex = this.GetArchivingBhFileIndex(fileName);
      return archivingBhFileIndex >= 0 ? this.GetBigFile(archivingBhFileIndex) : (FifaBigFile) null;
    }

    private int GetArchivingBhFileIndex(string fileName)
    {
      ulong bhHash = FifaUtil.ComputeBhHash(fileName);
      for (int index = this.m_NBigFiles - 1; index >= 0; --index)
      {
        if (this.m_BhFiles[index] != null && this.m_BhFiles[index].IsArchivedFilePresent(bhHash))
          return index;
      }
      return -1;
    }

    private int GetArchivingBigFileIndex(string fileName, out int fileIndex)
    {
      fileIndex = -1;
      for (int index = this.m_NBigFiles - 1; index >= 0; --index)
      {
        fileIndex = this.GetBigFile(index).GetArchivedFileIndex(fileName, true);
        if (fileIndex >= 0)
          return index;
      }
      return -1;
    }

    private FifaBigFile GetAvailableBigFile()
    {
      int availableBigFileIndex = this.GetAvailableBigFileIndex();
      return availableBigFileIndex < 0 ? (FifaBigFile) null : this.GetBigFile(availableBigFileIndex);
    }

    private int GetAvailableBigFileIndex()
    {
      for (int minZdata = this.m_MinZdata; minZdata < 100; ++minZdata)
      {
        if (this.m_BigFiles[minZdata] != null)
        {
          if (this.m_BigFiles[minZdata].NFiles < 500)
            return minZdata;
        }
        else
        {
          this.CreateNewBigFile(minZdata);
          return minZdata;
        }
      }
      return -1;
    }

    public void CreateNewBigFile(int index)
    {
      string bigFileName = this.GetBigFileName(index);
      FileStream fileStream = new FileStream(bigFileName, FileMode.Create, FileAccess.Write);
      fileStream.WriteByte((byte) 0);
      fileStream.Close();
      this.m_BigFiles[index] = new FifaBigFile(bigFileName);
      this.m_BhFiles[index] = new BhFile(this.m_BigFiles[index], false);
      this.m_NeedToSaveBig[index] = false;
      if (index <= this.m_NBigFiles)
        return;
      this.m_NBigFiles = index;
    }

    public void ResetDefaultZdata()
    {
      this.m_DeafultDataIndex = -1;
    }

    public ArrayList FindDuplicatedFiles()
    {
      ArrayList arrayList = new ArrayList();
      if (this.m_ProgressBar != null)
        this.m_ProgressBar.Maximum = 100;
      int num = 0;
      for (int bigIndex1 = 0; bigIndex1 < 100; ++bigIndex1)
      {
        if (this.m_ProgressBar != null)
          this.m_ProgressBar.Value = bigIndex1;
        if (this.m_BhFiles[bigIndex1] != null)
        {
          for (int fileIndex = 0; fileIndex < this.m_BhFiles[bigIndex1].NFiles; ++fileIndex)
          {
            ulong hash = this.m_BhFiles[bigIndex1].GetHash(fileIndex);
            for (int bigIndex2 = bigIndex1 + 1; bigIndex2 < 100; ++bigIndex2)
            {
              if (this.m_BhFiles[bigIndex2] != null && this.m_BhFiles[bigIndex2].GetArchivedFileIndex(hash) >= 0)
              {
                ++num;
                FifaBigFile fifaBigFile = new FifaBigFile(this.GetBigFileName(bigIndex1));
                string str = fifaBigFile.Files[fileIndex].Name + " is duplicated in " + fifaBigFile.Name + " and " + Path.GetFileName(this.GetBigFileName(bigIndex2)) + "\r\n";
                arrayList.Add((object) str);
              }
            }
          }
        }
      }
      if (this.m_ProgressBar != null)
        this.m_ProgressBar.Value = 0;
      if (num == 0)
        arrayList.Add((object) "No duplicated files found.");
      else
        arrayList.Add((object) (num.ToString() + " duplicated files found."));
      return arrayList;
    }

    public enum EFifaFatSaveOption
    {
      SaveAlways,
      SaveOnCommand,
    }
  }
}
