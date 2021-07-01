// Original code created by Rinaldo

using System.Collections;

namespace FifaLibrary
{
  public class CareerFirstNameList : IdArrayList
  {
    public CareerFirstNameList(DbFile fifaDbFile)
      : base(typeof (CareerFirstName))
    {
      this.Load(fifaDbFile);
    }

    public CareerFirstNameList(Table careerFirstNamesTable)
      : base(typeof (CareerFirstName))
    {
      this.Load(careerFirstNamesTable);
    }

    public void Load(DbFile fifaDbFile)
    {
      this.Load(fifaDbFile.Table[TI.career_firstnames]);
    }

    public void Load(Table table)
    {
      this.MinId = table.TableDescriptor.MinValues[FI.career_firstnames_firstnameid];
      this.MaxId = table.TableDescriptor.MaxValues[FI.career_firstnames_firstnameid];
      CareerFirstName[] careerFirstNameArray = new CareerFirstName[table.NRecords];
      this.Clear();
      for (int index = 0; index < table.NRecords; ++index)
        careerFirstNameArray[index] = new CareerFirstName(table.Records[index]);
      this.AddRange((ICollection) careerFirstNameArray);
      this.SortId();
    }

    public void Save(DbFile fifaDbFile)
    {
      Table table = fifaDbFile.Table[TI.career_firstnames];
      table.ResizeRecords(this.Count);
      int index = 0;
      foreach (CareerFirstName careerFirstName in (ArrayList) this)
      {
        Record record = table.Records[index];
        ++index;
        careerFirstName.Save(record);
      }
    }
  }
}
