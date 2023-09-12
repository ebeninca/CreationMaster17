// Original code created by Rinaldo

namespace FifaLibrary
{
  public class NumberFontList : IdArrayList
  {
    public NumberFontList()
      : base(typeof (NumberFont))
    {
    }

    public NumberFontList(DbFile fifaDb, FifaFat fatFile)
      : base(typeof (NumberFont))
    {
      this.Load(fifaDb, fatFile);
    }

    public void Load(DbFile fifaDb, FifaFat fatFile)
    {
      TableDescriptor tableDescriptor = fifaDb.Table[TI.teamkits].TableDescriptor;
      int num1 = 1;
      int maxValue = tableDescriptor.MaxValues[FI.teamkits_numberfonttype];
      int num2 = 0;
      int num3 = 19;
      this.MinId = num1 * (num3 + 1) + num2;
      this.MaxId = maxValue * (num3 + 1) + num3;
      this.Clear();
      for (int styleId = num1; styleId <= maxValue; ++styleId)
      {
        for (int colorId = num2; colorId <= num3; ++colorId)
        {
          string fileName = NumberFont.NumberFontFileName(styleId, colorId);
          if (fatFile.IsArchivedFilePresent(fileName) || fatFile.IsPhisycalFilePresent(fileName))
            this.Add((object) new NumberFont(styleId * (num3 + 1) + colorId));
        }
      }
    }

    public new NumberFont CreateNewId(int color)
    {
      int fontId = -1;
      for (int id = 20 + color % 20; id <= this.MaxId; id += 20)
      {
        if (this.SearchId(id) == null)
        {
          fontId = id;
          break;
        }
      }
      if (fontId < 0)
        return (NumberFont) null;
      NumberFont numberFont = new NumberFont(fontId);
      this.InsertId((IdObject) numberFont);
      return numberFont;
    }
  }
}
