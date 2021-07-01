// Original code created by Rinaldo

using System;
using System.Collections;
using System.Text;

namespace FifaLibrary
{
  public class PlayerList : IdArrayList
  {
    public PlayerList(Type type)
      : base(type)
    {
    }

    public PlayerList(DbFile fifaDbFile)
      : base(typeof (Player))
    {
      this.Load(fifaDbFile);
    }

    public PlayerList()
      : base(typeof (Player))
    {
    }

    public void Load(DbFile fifaDbFile)
    {
      Table table = FifaEnvironment.FifaDb.Table[TI.players];
      int minId = 50000;
      int maxValue = table.TableDescriptor.MaxValues[FI.players_playerid];
      this.Load(table, minId, maxValue);
      this.FillFromPlayerloans(fifaDbFile.Table[TI.playerloans]);
      this.FillFromPreviousTeam(fifaDbFile.Table[TI.previousteam]);
    }

    public void FillFromPreviousTeam(Table t)
    {
      for (int index = 0; index < t.NValidRecords; ++index)
      {
        Record record = t.Records[index];
        ((Player) this.SearchId(record.IntField[FI.previousteam_playerid]))?.FillFromPreviousTeam(record);
      }
    }

    public void FillFromPlayerloans(Table t)
    {
      for (int index = 0; index < t.NValidRecords; ++index)
      {
        Record record = t.Records[index];
        ((Player) this.SearchId(record.IntField[FI.playerloans_playerid]))?.FillFromPlayerloans(record);
      }
    }

    public void FillFromEditedPlayerNames(Table t)
    {
      for (int index = 0; index < t.NRecords; ++index)
      {
        Record record = t.Records[index];
        ((Player) this.SearchId(record.IntField[FI.editedplayernames_playerid]))?.FillFromEditedPlayerNames(record);
      }
    }

    public void Load(Table table, int minId, int maxId)
    {
      this.MinId = minId;
      this.MaxId = maxId;
      Player[] playerArray = new Player[table.NRecords];
      this.Clear();
      for (int index = 0; index < table.NRecords; ++index)
        playerArray[index] = new Player(table.Records[index]);
      this.AddRange((ICollection) playerArray);
      this.SortId();
    }

    public Player FitPlayer(Player player)
    {
      foreach (Player player1 in (ArrayList) this)
      {
        if (player1.lastname == player.lastname)
        {
          if (player.firstname != null && player.firstname != "")
          {
            if (player1.firstname == player.firstname)
              return player1;
          }
          else if (player1.Id == player.Id)
            return player1;
        }
      }
      return (Player) null;
    }

    public Player FitPlayer(string name, int id)
    {
      foreach (Player player in (ArrayList) this)
      {
        if (player.ToString() == name)
          return player;
      }
      return (Player) null;
    }

    public Player FitPlayer(string firstname, string lastname, DateTime birthdate)
    {
      firstname = Encoding.ASCII.GetString(Encoding.GetEncoding("Cyrillic").GetBytes(firstname));
      lastname = Encoding.ASCII.GetString(Encoding.GetEncoding("Cyrillic").GetBytes(lastname));
      foreach (Player player in (ArrayList) this)
      {
        if (birthdate.Date == player.birthdate.Date)
        {
          string str1 = Encoding.ASCII.GetString(Encoding.GetEncoding("Cyrillic").GetBytes(player.firstname));
          string str2 = Encoding.ASCII.GetString(Encoding.GetEncoding("Cyrillic").GetBytes(player.lastname));
          if (firstname == str1 && lastname == str2)
            return player;
        }
      }
      return (Player) null;
    }

    public PlayerList GetFreeAgent()
    {
      PlayerList playerList = new PlayerList();
      for (int index = 0; index < this.Count; ++index)
      {
        Player player = (Player) this[index];
        if (player.IsFreeAgent())
          playerList.Add((object) player);
      }
      return playerList;
    }

    public void Save(DbFile fifaDbFile)
    {
      Table table1 = fifaDbFile.Table[TI.players];
      table1.ResizeRecords(this.Count);
      Table table2 = fifaDbFile.Table[TI.playerloans];
      Table table3 = fifaDbFile.Table[TI.previousteam];
      int index1 = 0;
      int nRecords1 = 0;
      int nRecords2 = 0;
      foreach (Player player in (ArrayList) this)
      {
        Record record = table1.Records[index1];
        if (player.m_assetid != 0)
        {
          ++index1;
          player.SavePlayer(record);
          if (player.IsLoaned)
            ++nRecords1;
          if (player.PreviousTeam != null)
            ++nRecords2;
        }
      }
      table2.ResizeRecords(nRecords1);
      table3.ResizeRecords(nRecords2);
      int index2 = 0;
      int index3 = 0;
      foreach (Player player in (ArrayList) this)
      {
        if (player.IsLoaned)
        {
          Record record = table2.Records[index2];
          ++index2;
          player.SavePlayerloans(record);
        }
        if (player.PreviousTeam != null)
        {
          Record record = table3.Records[index3];
          ++index3;
          player.SavePreviousTeam(record);
        }
      }
    }

    public ArrayList FindMissedFiles()
    {
      ArrayList arrayList = new ArrayList();
      foreach (Player player in (ArrayList) this)
      {
        if (player.HasSpecificHeadModel)
        {
          if (!FifaEnvironment.FifaFat.IsArchivedFilePresent(player.SpecificFaceTextureFileName()))
            arrayList.Add((object) ("Face #" + player.Id.ToString() + " used by player " + player.ToString() + "\r\n"));
          if (!FifaEnvironment.FifaFat.IsArchivedFilePresent(player.SpecificHairTexturesFileName()))
            arrayList.Add((object) ("Hair Textures #" + player.Id.ToString() + " used by player " + player.ToString() + "\r\n"));
        }
      }
      return arrayList;
    }

    public override IdArrayList Filter(IdObject filter)
    {
      if (filter == null)
        return (IdArrayList) this;
      PlayerList playerList = new PlayerList();
      if (filter.GetType().Name == "SameName")
      {
        for (int index1 = 0; index1 < this.Count; ++index1)
        {
          Player player1 = (Player) this[index1];
          for (int index2 = index1 + 1; index2 < this.Count; ++index2)
          {
            Player player2 = (Player) this[index2];
            if (player1.firstnameid == player2.firstnameid && player1.lastnameid == player2.lastnameid)
            {
              playerList.Add((object) player1);
              playerList.Add((object) player2);
            }
          }
        }
        return (IdArrayList) playerList;
      }
      if (filter.GetType().Name == "FreeAgent")
      {
        for (int index = 0; index < this.Count; ++index)
        {
          Player player = (Player) this[index];
          if (player.IsFreeAgent())
            playerList.Add((object) player);
        }
        return (IdArrayList) playerList;
      }
      if (filter.GetType().Name == "Team" || filter.GetType().Name == "CareerTeam")
      {
        Team team = (Team) filter;
        if (team != null)
        {
          for (int index = 0; index < this.Count; ++index)
          {
            Player player = (Player) this[index];
            if (player.IsPlayingFor(team))
              playerList.Add((object) player);
          }
        }
        return (IdArrayList) playerList;
      }
      if (filter.GetType().Name == "MultiClub")
      {
        for (int index = 0; index < this.Count; ++index)
        {
          Player player = (Player) this[index];
          if (player.IsMultiClub())
            playerList.Add((object) player);
        }
        return (IdArrayList) playerList;
      }
      if (filter.GetType().Name == "Country")
      {
        Country country = (Country) filter;
        for (int index = 0; index < this.Count; ++index)
        {
          Player player = (Player) this[index];
          if (player.Country == country)
            playerList.Add((object) player);
        }
        return (IdArrayList) playerList;
      }
      if (filter.GetType().Name == "Role")
      {
        Role role = (Role) filter;
        for (int index = 0; index < this.Count; ++index)
        {
          Player player = (Player) this[index];
          if (player.preferredposition1 == role.Id)
            playerList.Add((object) player);
        }
        return (IdArrayList) playerList;
      }
      if (!(filter.GetType().Name == "SpecificHead"))
        return (IdArrayList) this;
      for (int index = 0; index < this.Count; ++index)
      {
        Player player = (Player) this[index];
        if (player.HasSpecificHeadModel)
          playerList.Add((object) player);
      }
      return (IdArrayList) playerList;
    }

    public override IdArrayList Filter(IdObject filter, bool excludeYoung)
    {
      PlayerList playerList1 = (PlayerList) this.Filter(filter);
      PlayerList playerList2 = new PlayerList();
      foreach (Player player in (ArrayList) playerList1)
      {
        if (player.Id < 400000 || !excludeYoung)
          playerList2.Add((object) player);
      }
      return (IdArrayList) playerList2;
    }

    public bool DeletePlayer(Player player)
    {
      return this.RemoveId((IdObject) player);
    }

    public void LinkCountry(CountryList countryList)
    {
      foreach (Player player in (ArrayList) this)
        player.LinkCountry(countryList);
    }

    public void LinkTeam(TeamList teamList)
    {
      foreach (Player player in (ArrayList) this)
        player.LinkTeam(teamList);
    }

    public int SetGenericAudio(string lastname, int commentaryid)
    {
      int num = 0;
      foreach (Player player in (ArrayList) this)
      {
        if (player.audioname == lastname)
        {
          player.commentaryid = commentaryid;
          ++num;
        }
      }
      return num;
    }

    public class FreeAgent : IdObject
    {
      public override string ToString()
      {
        return "Free Agents";
      }
    }

    public class FreeAgentList : IdArrayList
    {
      public FreeAgentList()
        : base(typeof (PlayerList.FreeAgent))
      {
        this.Clear();
        this.Add((object) new PlayerList.FreeAgent());
      }
    }

    public class MultiClub : IdObject
    {
      public override string ToString()
      {
        return "Multi Clubs";
      }
    }

    public class MultiClubList : IdArrayList
    {
      public MultiClubList()
        : base(typeof (PlayerList.MultiClub))
      {
        this.Clear();
        this.Add((object) new PlayerList.MultiClub());
      }
    }

    public class SpecificHead : IdObject
    {
      public override string ToString()
      {
        return "Specific Head";
      }
    }

    public class SpecificHeadList : IdArrayList
    {
      public SpecificHeadList()
        : base(typeof (PlayerList.SpecificHead))
      {
        this.Clear();
        this.Add((object) new PlayerList.SpecificHead());
      }
    }
  }
}
