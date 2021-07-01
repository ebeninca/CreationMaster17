// Original code created by Rinaldo

using System.Collections;

namespace FifaLibrary
{
  public class ShoesList : IdArrayList
  {
    private bool m_HasGenericShoes;

    public ShoesList(DbFile fifaDb, FifaFat fatFile)
      : base(typeof (Shoes))
    {
      this.Load(fifaDb, fatFile);
    }

    public void Load(DbFile fifaDb, FifaFat fatFile)
    {
      Table table = fifaDb.Table[TI.playerboots];
      TableDescriptor tableDescriptor = table.TableDescriptor;
      int minValue = tableDescriptor.MinValues[FI.playerboots_shoetype];
      int maxValue = tableDescriptor.MaxValues[FI.playerboots_shoetype];
      this.Load(table, minValue, maxValue);
    }

    public void Load(Table table, int minId, int maxId)
    {
      this.MinId = minId;
      this.MaxId = maxId;
      this.m_HasGenericShoes = false;
      Shoes[] shoesArray1 = new Shoes[table.NRecords];
      this.Clear();
      int length = 0;
      for (int index = 0; index < table.NRecords; ++index)
      {
        Shoes shoes = new Shoes(table.Records[index]);
        if (shoes.Id != 0 || !this.m_HasGenericShoes)
        {
          shoesArray1[length++] = shoes;
          if (shoes.Id == 0)
            this.m_HasGenericShoes = true;
        }
      }
      Shoes[] shoesArray2 = new Shoes[length];
      for (int index = 0; index < length; ++index)
        shoesArray2[index] = shoesArray1[index];
      this.AddRange((ICollection) shoesArray2);
      this.SortId();
    }

    public void Save(DbFile fifaDbFile)
    {
      Table table = fifaDbFile.Table[TI.playerboots];
      table.ResizeRecords(this.Count);
      int index = 0;
      foreach (Shoes shoes in (ArrayList) this)
      {
        Record record = table.Records[index];
        ++index;
        shoes.SaveShoes(record);
      }
    }
  }
}
