// Original code created by Rinaldo

using System.Collections;

namespace FifaLibrary
{
  public class BallList : IdArrayList
  {
    public BallList()
      : base(typeof (Ball))
    {
    }

    public BallList(DbFile fifaDb, FifaFat fatFile)
      : base(typeof (Ball))
    {
      this.Load(fifaDb, fatFile);
    }

    public void Load(DbFile fifaDb, FifaFat fatFile)
    {
      Table table = fifaDb.Table[TI.teamballs];
      TableDescriptor tableDescriptor = table.TableDescriptor;
      int minValue = tableDescriptor.MinValues[FI.teamballs_ballid];
      int maxValue = tableDescriptor.MaxValues[FI.teamballs_ballid];
      this.Load(table, minValue, maxValue);
    }

    public void Load(Table table, int minId, int maxId)
    {
      this.MinId = minId;
      this.MaxId = maxId;
      Ball[] ballArray = new Ball[table.NRecords];
      this.Clear();
      for (int index = 0; index < table.NRecords; ++index)
        ballArray[index] = new Ball(table.Records[index]);
      this.AddRange((ICollection) ballArray);
      this.SortId();
    }

    public void Save(DbFile fifaDbFile)
    {
      Table table = fifaDbFile.Table[TI.teamballs];
      table.ResizeRecords(this.Count);
      int index = 0;
      foreach (Ball ball in (ArrayList) this)
      {
        Record record = table.Records[index];
        ++index;
        ball.SaveBall(record);
      }
    }
  }
}
