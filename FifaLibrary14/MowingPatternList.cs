// Original code created by Rinaldo

namespace FifaLibrary
{
  public class MowingPatternList : IdArrayList
  {
    public MowingPatternList()
      : base(typeof (MowingPattern))
    {
    }

    public MowingPatternList(DbFile fifaDb, FifaFat fatFile)
      : base(typeof (MowingPattern))
    {
      this.Load(fifaDb, fatFile);
    }

    public void Load(DbFile fifaDb, FifaFat fatFile)
    {
      TableDescriptor tableDescriptor = fifaDb.Table[TI.stadiums].TableDescriptor;
      this.MinId = tableDescriptor.MinValues[FI.stadiums_stadiummowpattern_code];
      this.MaxId = tableDescriptor.MaxValues[FI.stadiums_stadiummowpattern_code];
      this.Clear();
      for (int minId = this.MinId; minId <= this.MaxId; ++minId)
      {
        string fileName = MowingPattern.MowingPatternFileName(minId);
        if (fatFile.IsArchivedFilePresent(fileName) || fatFile.IsPhisycalFilePresent(fileName))
          this.Add((object) new MowingPattern(minId));
      }
    }
  }
}
