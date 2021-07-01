// Original code created by Rinaldo

using System;
using System.Collections;

namespace FifaLibrary
{
  public class KitList : IdArrayList
  {
    public KitList()
      : base(typeof (Kit))
    {
    }

    public KitList(Type type)
      : base(type)
    {
    }

    public KitList(DbFile fifaDbFile)
      : base(typeof (Kit))
    {
      this.Load(fifaDbFile);
    }

    public void Load(DbFile fifaDbFile)
    {
      Table t = fifaDbFile.Table[TI.teamkits];
      int minValue = t.TableDescriptor.MinValues[FI.teamkits_teamkitid];
      int maxValue = t.TableDescriptor.MaxValues[FI.teamkits_teamkitid];
      this.Load(t, minValue, maxValue);
    }

    public void Load(Table t, int minId, int maxId)
    {
      this.MinId = minId;
      this.MaxId = maxId;
      this.Clear();
      for (int index = 0; index < t.NRecords; ++index)
      {
        Kit kit = new Kit(t.Records[index]);
        bool flag = false;
        while (this.SearchId((IdObject) kit) != null)
        {
          --kit.Id;
          flag = true;
        }
        this.Add((object) kit);
        if (flag)
          this.SortId();
      }
      this.SortId();
    }

    public void Save(DbFile fifaDbFile)
    {
      Table table = fifaDbFile.Table[TI.teamkits];
      table.ResizeRecords(this.Count);
      int index = 0;
      int artificialKey = 0;
      foreach (Kit kit in (ArrayList) this)
      {
        kit.SaveKit(table.Records[index], artificialKey);
        ++index;
        ++artificialKey;
      }
    }

    public void LinkTeam(TeamList teamList)
    {
      foreach (Kit kit in (ArrayList) this)
        kit.LinkTeam(teamList);
    }

    public bool IsJerseyFontUsed(int jerseyFontId)
    {
      foreach (Kit kit in (ArrayList) this)
      {
        if (kit.jerseyNumberFont == jerseyFontId)
          return true;
      }
      return false;
    }

    public Kit GetKit(int teamId, int kitType)
    {
      foreach (Kit kit in (ArrayList) this)
      {
        if (kit.teamid == teamId && kit.kittype == kitType)
          return kit;
      }
      return (Kit) null;
    }

    public override IdArrayList Filter(IdObject filter)
    {
      if (filter == null)
        return (IdArrayList) this;
      KitList kitList = new KitList();
      if (filter.GetType().Name == "Team")
      {
        Team team = (Team) filter;
        if (team != null)
        {
          for (int index = 0; index < this.Count; ++index)
          {
            Kit kit = (Kit) this[index];
            if (kit.Team == team)
              kitList.Add((object) kit);
          }
        }
        return (IdArrayList) kitList;
      }
      if (filter.GetType().Name == "Country")
      {
        Country country = (Country) filter;
        for (int index = 0; index < this.Count; ++index)
        {
          Kit kit = (Kit) this[index];
          if (kit.Team != null && kit.Team.Country == country)
            kitList.Add((object) kit);
        }
        return (IdArrayList) kitList;
      }
      if (!(filter.GetType().Name == "League"))
        return (IdArrayList) this;
      League league = (League) filter;
      for (int index = 0; index < this.Count; ++index)
      {
        Kit kit = (Kit) this[index];
        if (kit.Team != null && kit.Team.League == league)
          kitList.Add((object) kit);
      }
      return (IdArrayList) kitList;
    }

    public bool Exists(int teamid, int kittype)
    {
      foreach (Kit kit in (ArrayList) this)
      {
        if (kit.teamid == teamid && kit.kittype == kittype)
          return true;
      }
      return false;
    }

    public void DeleteKit(Kit kit)
    {
      this.RemoveId((IdObject) kit);
    }

    public Kit FitKit(string name, int id)
    {
      name = name.Substring(0, name.IndexOf('('));
      int num1 = id / 10;
      int num2 = id - num1 * 10;
      foreach (Kit kit in (ArrayList) this)
      {
        if (kit.teamid == num1 && kit.kittype == num2)
          return kit;
        string str = kit.ToString();
        if (str.Substring(0, str.IndexOf('(')) == name)
          return kit;
      }
      return (Kit) null;
    }
  }
}
