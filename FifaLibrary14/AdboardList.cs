// Original code created by Rinaldo

namespace FifaLibrary
{
  public class AdboardList : IdArrayList
  {
    public AdboardList()
      : base(typeof (Adboard))
    {
    }

    public AdboardList(DbFile fifaDb, FifaFat fatFile)
      : base(typeof (Adboard))
    {
      this.Load(fifaDb, fatFile);
    }

    public void Load(DbFile fifaDb, FifaFat fatFile)
    {
      TableDescriptor tableDescriptor = fifaDb.Table[TI.teams].TableDescriptor;
      this.MinId = tableDescriptor.MinValues[FI.teams_adboardid];
      this.MaxId = tableDescriptor.MaxValues[FI.teams_adboardid];
      this.Clear();
      for (int minId = this.MinId; minId <= this.MaxId; ++minId)
      {
        string fileName = Adboard.AdboardFileName(minId);
        if (fatFile.IsArchivedFilePresent(fileName) || fatFile.IsPhisycalFilePresent(fileName))
          this.Add((object) new Adboard(minId));
      }
    }
  }
}
