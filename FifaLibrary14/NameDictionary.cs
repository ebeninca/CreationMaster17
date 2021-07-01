// Original code created by Rinaldo

using System.Collections.Generic;
using System.Text;

namespace FifaLibrary
{
  public class NameDictionary : Dictionary<int, string>
  {
    public NameDictionary(DbFile fifaDbFile)
    {
      this.Load(fifaDbFile.Table[TI.commentarynames]);
      this.FillFromPlayernames(fifaDbFile.Table[TI.playernames]);
    }

    public void Load(Table commentaryNamesTable)
    {
      this.Clear();
      for (int index = 0; index < commentaryNamesTable.NRecords; ++index)
      {
        Record record = commentaryNamesTable.Records[index];
        int key = record.IntField[FI.commentarynames_commentaryid];
        if (!this.ContainsKey(key))
        {
          string s = record.CompressedString[FI.commentarynames_commentarystring];
          string str = Encoding.ASCII.GetString(Encoding.GetEncoding("Cyrillic").GetBytes(s));
          if (str.Length > 0)
          {
            int num = (int) str.ToUpper()[0];
          }
          this.Add(key, s);
        }
      }
    }

    public void FillFromPlayernames(Table playernamesTable)
    {
      for (int index = 0; index < playernamesTable.NRecords; ++index)
      {
        Record record = playernamesTable.Records[index];
        int key = record.IntField[FI.playernames_commentaryid];
        if (key != 900000 && !this.ContainsKey(key))
        {
          string str = Encoding.ASCII.GetString(Encoding.GetEncoding("Cyrillic").GetBytes(record.CompressedString[FI.playernames_name]));
          if (str.Length > 0)
          {
            int num = (int) str.ToUpper()[0];
          }
          this.Add(key, str);
        }
      }
    }

    public void Save(DbFile fifaDbFile)
    {
      this.Save(fifaDbFile.Table[TI.commentarynames]);
    }

    public void Save(Table commentaryNamesTable)
    {
      commentaryNamesTable.ResizeRecords(this.Count);
      commentaryNamesTable.NValidRecords = this.Count;
      int index = 0;
      foreach (KeyValuePair<int, string> keyValuePair in (Dictionary<int, string>) this)
      {
        Record record = commentaryNamesTable.Records[index];
        ++index;
        string s = keyValuePair.Value;
        char ch = 'Z';
        string str = Encoding.ASCII.GetString(Encoding.GetEncoding("Cyrillic").GetBytes(s));
        if (str.Length > 0)
          ch = str.ToUpper()[0];
        record.IntField[FI.commentarynames_commentarystartingletter] = (int) ch - 65 + 1;
        record.IntField[FI.commentarynames_commentaryid] = keyValuePair.Key;
        record.IntField[FI.commentarynames_commentarypreview] = 1;
        record.CompressedString[FI.commentarynames_commentarystring] = s;
      }
    }
  }
}
