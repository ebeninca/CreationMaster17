// Original code created by Rinaldo

using System.Collections;

namespace FifaLibrary
{
  public class CareerCommonNameList : IdArrayList
  {
    public CareerCommonNameList(DbFile fifaDbFile)
      : base(typeof (CareerCommonName))
    {
      this.Load(fifaDbFile);
    }

    public CareerCommonNameList(Table careerCommonNamesTable)
      : base(typeof (CareerCommonName))
    {
      this.Load(careerCommonNamesTable);
    }

    public void Load(DbFile fifaDbFile)
    {
      this.Load(fifaDbFile.Table[TI.career_commonnames]);
    }

    public void Load(Table table)
    {
      this.MinId = table.TableDescriptor.MinValues[FI.career_commonnames_commonnameid];
      this.MaxId = table.TableDescriptor.MaxValues[FI.career_commonnames_commonnameid];
      CareerCommonName[] careerCommonNameArray = new CareerCommonName[table.NRecords];
      this.Clear();
      for (int index = 0; index < table.NRecords; ++index)
        careerCommonNameArray[index] = new CareerCommonName(table.Records[index]);
      this.AddRange((ICollection) careerCommonNameArray);
      this.SortId();
    }

    public void Save(DbFile fifaDbFile)
    {
      Table table = fifaDbFile.Table[TI.career_commonnames];
      table.ResizeRecords(this.Count);
      int index = 0;
      foreach (CareerCommonName careerCommonName in (ArrayList) this)
      {
        Record record = table.Records[index];
        ++index;
        careerCommonName.Save(record);
      }
    }
  }
}
