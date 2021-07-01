// Original code created by Rinaldo

namespace FifaLibrary
{
  public class GkGlovesList : IdArrayList
  {
    public GkGlovesList()
      : base(typeof (GkGloves))
    {
    }

    public GkGlovesList(DbFile fifaDb, FifaFat fatFile)
      : base(typeof (GkGloves))
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
        string fileName = GkGloves.GkGlovesTextureFileName(minId);
        if (fatFile.IsArchivedFilePresent(fileName) || fatFile.IsPhisycalFilePresent(fileName))
          this.InsertId((IdObject) new GkGloves(minId));
      }
    }
  }
}
