// Original code created by Rinaldo

using System.Collections;

namespace FifaLibrary
{
  public class CareerLastNameList : IdArrayList
  {
    public CareerLastNameList(DbFile fifaDbFile)
      : base(typeof (CareerLastName))
    {
      this.Load(fifaDbFile);
    }

    public CareerLastNameList(Table careerLastNamesTable, PlayerNames playerNames)
      : base(typeof (CareerLastName))
    {
      this.Load(careerLastNamesTable);
    }

    public void Load(DbFile fifaDbFile)
    {
      this.Load(fifaDbFile.Table[TI.career_lastnames]);
    }

    public void Load(Table table)
    {
      this.MinId = table.TableDescriptor.MinValues[FI.career_lastnames_lastnameid];
      this.MaxId = table.TableDescriptor.MaxValues[FI.career_lastnames_lastnameid];
      CareerLastName[] careerLastNameArray = new CareerLastName[table.NRecords];
      this.Clear();
      for (int index = 0; index < table.NRecords; ++index)
        careerLastNameArray[index] = new CareerLastName(table.Records[index]);
      this.AddRange((ICollection) careerLastNameArray);
      this.SortId();
    }

    public void Save(DbFile fifaDbFile)
    {
      Table table = fifaDbFile.Table[TI.career_lastnames];
      table.ResizeRecords(this.Count);
      int index = 0;
      foreach (CareerLastName careerLastName in (ArrayList) this)
      {
        Record record = table.Records[index];
        ++index;
        careerLastName.Save(record);
      }
    }
  }
}
