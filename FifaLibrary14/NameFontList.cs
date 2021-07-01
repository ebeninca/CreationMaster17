// Original code created by Rinaldo

namespace FifaLibrary
{
  public class NameFontList : IdArrayList
  {
    public NameFontList()
      : base(typeof (NameFont))
    {
    }

    public NameFontList(DbFile fifaDb, FifaFat fatFile)
      : base(typeof (NameFont))
    {
      this.Load(fifaDb, fatFile);
    }

    public void Load(DbFile fifaDb, FifaFat fatFile)
    {
      TableDescriptor tableDescriptor = fifaDb.Table[TI.teamkits].TableDescriptor;
      this.MinId = tableDescriptor.MinValues[FI.teamkits_jerseynamefonttype];
      this.MaxId = tableDescriptor.MaxValues[FI.teamkits_jerseynamefonttype];
      this.Clear();
      for (int minId = this.MinId; minId <= this.MaxId; ++minId)
      {
        string fileName = NameFont.NameFontFileName(minId);
        if (fatFile.IsArchivedFilePresent(fileName) || fatFile.IsPhisycalFilePresent(fileName))
          this.Add((object) new NameFont(minId));
      }
    }
  }
}
