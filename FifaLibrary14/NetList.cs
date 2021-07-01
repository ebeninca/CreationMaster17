// Original code created by Rinaldo

namespace FifaLibrary
{
  public class NetList : IdArrayList
  {
    public NetList()
      : base(typeof (Net))
    {
    }

    public NetList(DbFile fifaDb, FifaFat fatFile)
      : base(typeof (Net))
    {
      this.Load(fifaDb, fatFile);
    }

    public void Load(DbFile fifaDb, FifaFat fatFile)
    {
      TableDescriptor tableDescriptor = fifaDb.Table[TI.stadiums].TableDescriptor;
      this.MinId = tableDescriptor.MinValues[FI.stadiums_stadiumgoalnetstyle];
      this.MaxId = tableDescriptor.MaxValues[FI.stadiums_stadiumgoalnetstyle];
      this.Clear();
      for (int minId = this.MinId; minId <= this.MaxId; ++minId)
      {
        string fileName = Net.NetFileName(minId);
        if (fatFile.IsArchivedFilePresent(fileName) || fatFile.IsPhisycalFilePresent(fileName))
          this.Add((object) new Net(minId));
      }
    }
  }
}
