// Original code created by Rinaldo

namespace FifaLibrary
{
  public class GlovesList : IdArrayList
  {
    public GlovesList(DbFile fifaDb, FifaFat fatFile)
      : base(typeof (MowingPattern))
    {
      this.Load(fifaDb, fatFile);
    }

    public void Load(DbFile fifaDb, FifaFat fatFile)
    {
      TableDescriptor tableDescriptor = fifaDb.Table[TI.players].TableDescriptor;
      this.MinId = tableDescriptor.MinValues[FI.players_gkglovetypecode];
      this.MaxId = tableDescriptor.MaxValues[FI.players_gkglovetypecode];
      this.Clear();
      for (int minId = this.MinId; minId <= this.MaxId; ++minId)
      {
        string fileName = Gloves.GlovesFileName(minId);
        if (fatFile.IsArchivedFilePresent(fileName) || fatFile.IsPhisycalFilePresent(fileName))
          this.Add((object) new Gloves(minId));
      }
    }
  }
}
