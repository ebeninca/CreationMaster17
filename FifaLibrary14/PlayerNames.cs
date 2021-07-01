// Original code created by Rinaldo

using System.Collections;

namespace FifaLibrary
{
  public class PlayerNames : IdArrayList
  {
    private static char[] c_NoLetters = new char[4]
    {
      ' ',
      '.',
      '-',
      '\''
    };

    public PlayerNames(DbFile fifaDbFile)
      : base(typeof (PlayerName))
    {
      this.Load(fifaDbFile);
    }

    public PlayerNames(Table playerNamesTable)
      : base(typeof (PlayerName))
    {
      int minId = 0;
      int maxValue = playerNamesTable.TableDescriptor.MaxValues[FI.playernames_nameid];
      if (maxValue < (int) short.MaxValue)
        maxValue = (int) short.MaxValue;
      this.Load(playerNamesTable, minId, maxValue);
    }

    public PlayerNames()
      : base(typeof (PlayerName))
    {
    }

    public void Load(DbFile fifaDbFile)
    {
      Table table = fifaDbFile.Table[TI.playernames];
      int minId = 0;
      int maxValue = table.TableDescriptor.MaxValues[FI.playernames_nameid];
      if (maxValue < (int) short.MaxValue)
        maxValue = (int) short.MaxValue;
      this.Load(table, minId, maxValue);
    }

    public void Load(Table table, int minId, int maxId)
    {
      this.MinId = minId;
      this.MaxId = maxId;
      PlayerName[] playerNameArray = new PlayerName[table.NRecords];
      this.Clear();
      for (int index = 0; index < table.NRecords; ++index)
      {
        playerNameArray[index] = new PlayerName(table.Records[index]);
        string str = PlayerNames.Normalize(playerNameArray[index].Text);
        if (playerNameArray[index].Text != str)
          playerNameArray[index].Text = str;
      }
      this.AddRange((ICollection) playerNameArray);
      this.SortId();
    }

    public void Save(DbFile fifaDbFile)
    {
      Table table = fifaDbFile.Table[TI.playernames];
      table.ResizeRecords(this.Count);
      int nRecords = 0;
      foreach (PlayerName playerName in (ArrayList) this)
      {
        if (playerName.IsUsed || playerName.IsOriginal)
        {
          Record record = table.Records[nRecords];
          ++nRecords;
          playerName.SavePlayerName(record);
        }
      }
      table.ResizeRecords(nRecords);
    }

    public bool TryGetValue(int id, out string name, bool isUsed)
    {
      PlayerName playerName = (PlayerName) this.SearchId(id);
      if (playerName != null)
      {
        name = playerName.Text;
        playerName.IsUsed = isUsed;
        return true;
      }
      name = (string) null;
      return false;
    }

    public bool TryGetValue(int id, out string name, out int commentaryid, bool isUsed)
    {
      PlayerName playerName = (PlayerName) this.SearchId(id);
      if (playerName != null)
      {
        name = playerName.Text;
        commentaryid = playerName.CommentaryId;
        playerName.IsUsed = isUsed;
        return true;
      }
      name = (string) null;
      commentaryid = 900000;
      return false;
    }

    public bool SetCommentaryId(int nameid, int commentaryid)
    {
      PlayerName playerName = (PlayerName) this.SearchId(nameid);
      if (playerName == null)
        return false;
      playerName.CommentaryId = commentaryid;
      return true;
    }

    public void ClearUsedFlags()
    {
      foreach (PlayerName playerName in (ArrayList) this)
        playerName.IsUsed = false;
    }

    public void SetUsedFlags()
    {
      foreach (PlayerName playerName in (ArrayList) this)
        playerName.IsUsed = true;
    }

    public int GetCommentaryIdFromName(string text)
    {
      string str = PlayerNames.Normalize(text);
      foreach (PlayerName playerName in (ArrayList) this)
      {
        if (playerName.Text == str)
          return playerName.CommentaryId;
      }
      return 900000;
    }

    public PlayerName SearchName(string text)
    {
      foreach (PlayerName playerName in (ArrayList) this)
      {
        if (playerName.Text == text)
          return playerName;
      }
      return (PlayerName) null;
    }

    public int GetKey(string text, int commentaryId)
    {
      string text1 = PlayerNames.Normalize(text);
      foreach (PlayerName playerName in (ArrayList) this)
      {
        if (playerName.Text == text1)
        {
          playerName.IsUsed = true;
          if (playerName.CommentaryId != commentaryId && commentaryId >= 0)
            playerName.CommentaryId = commentaryId;
          return playerName.Id;
        }
      }
      int newId = this.GetNewId();
      if (newId < 0)
        return 0;
      this.InsertId((IdObject) new PlayerName(newId, text1, true)
      {
        CommentaryId = (commentaryId < 0 ? 900000 : commentaryId)
      });
      return newId;
    }

    public int GetKey(string text)
    {
      string text1 = PlayerNames.Normalize(text);
      foreach (PlayerName playerName in (ArrayList) this)
      {
        if (playerName.Text == text1)
        {
          playerName.IsUsed = true;
          return playerName.Id;
        }
      }
      int newId = this.GetNewId();
      if (newId < 0)
        return 0;
      this.InsertId((IdObject) new PlayerName(newId, text1, true));
      return newId;
    }

    public static string Normalize(string text)
    {
      if (text == null)
        return string.Empty;
      if (text.Length <= 0)
        return text;
      string str = text;
      if (str == str.ToUpper() && str.IndexOfAny(PlayerNames.c_NoLetters) < 0 && str.Length > 3)
        str = str.Substring(0, 1).ToUpper() + str.Substring(1, str.Length - 1).ToLower();
      if (str.Length == 0)
        return string.Empty;
      if (str == str.ToLower())
        str = str.Substring(0, 1).ToUpper() + str.Substring(1, str.Length - 1);
      return str;
    }
  }
}
