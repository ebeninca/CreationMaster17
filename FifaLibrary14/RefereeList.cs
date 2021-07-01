// Original code created by Rinaldo

using System.Collections;

namespace FifaLibrary
{
  public class RefereeList : IdArrayList
  {
    public static KitList s_RefereeKits;

    public RefereeList()
      : base(typeof (Referee))
    {
    }

    public RefereeList(DbFile fifaDbFile)
      : base(typeof (Referee))
    {
      this.Load(fifaDbFile);
    }

    public void Load(DbFile fifaDbFile)
    {
      int minValue = FifaEnvironment.FifaDb.Table[TI.referee].TableDescriptor.MinValues[FI.referee_refereeid];
      int maxValue = FifaEnvironment.FifaDb.Table[TI.referee].TableDescriptor.MaxValues[FI.referee_refereeid];
      this.Load(fifaDbFile.Table[TI.referee], minValue, maxValue);
      this.FillFromLeagueRefereeLinks(fifaDbFile.Table[TI.leaguerefereelinks]);
    }

    public void Load(Table t, int minId, int maxId)
    {
      this.MinId = minId;
      this.MaxId = maxId;
      this.Clear();
      for (int index = 0; index < t.NRecords; ++index)
        this.Add((object) new Referee(t.Records[index]));
      this.SortId();
    }

    public void FillFromLeagueRefereeLinks(Table t)
    {
      for (int index = 0; index < t.NRecords; ++index)
      {
        Record record = t.Records[index];
        ((Referee) this.SearchId(record.IntField[FI.leaguerefereelinks_refereeid]))?.FillFromLeagueRefereeLinks(record);
      }
    }

    public void Save(DbFile fifaDbFile)
    {
      Table table1 = fifaDbFile.Table[TI.referee];
      table1.ResizeRecords(this.Count);
      Table table2 = fifaDbFile.Table[TI.leaguerefereelinks];
      int nRecords = 0;
      int index1 = 0;
      foreach (Referee referee in (ArrayList) this)
      {
        Record record = table1.Records[index1];
        referee.SaveReferee(record);
        ++index1;
        nRecords += referee.CntLeagues();
      }
      table2.ResizeRecords(nRecords);
      int index2 = 0;
      foreach (Referee referee in (ArrayList) this)
      {
        for (int index3 = 0; index3 < referee.Leagues.Length; ++index3)
        {
          if (referee.Leagues[index3] != null)
          {
            Record record = table2.Records[index2];
            referee.SaveLeagueRefereeLinks(record, index3);
            ++index2;
          }
        }
      }
    }

    public int GetNewRefereeHeadId()
    {
      int num = 0;
      int minValue = FifaEnvironment.FifaDb.Table[TI.referee].TableDescriptor.MinValues[FI.referee_refereeid];
      for (int maxValue = FifaEnvironment.FifaDb.Table[TI.referee].TableDescriptor.MaxValues[FI.referee_refereeid]; maxValue >= minValue; --maxValue)
      {
        bool flag = false;
        foreach (Referee referee in (ArrayList) this)
        {
          if (maxValue == referee.Id)
          {
            flag = true;
            break;
          }
        }
        if (!flag)
        {
          num = maxValue;
          break;
        }
      }
      return num;
    }

    public Referee FitReferee(string name, int id)
    {
      foreach (Referee referee in (ArrayList) this)
      {
        if (referee.ToString() == name)
          return referee;
      }
      return (Referee) null;
    }

    public void DeleteReferee(Referee referee)
    {
      this.RemoveId((IdObject) referee);
    }

    public void LinkCountry(CountryList countryList)
    {
      foreach (Referee referee in (ArrayList) this)
        referee.LinkCountry(countryList);
    }

    public void LinkLeague(LeagueList leagueList)
    {
      foreach (Referee referee in (ArrayList) this)
        referee.LinkLeague(leagueList);
    }

    public override IdArrayList Filter(IdObject filter)
    {
      if (filter == null)
        return (IdArrayList) this;
      RefereeList refereeList = new RefereeList();
      if (filter.GetType().Name == "Country")
      {
        Country country = (Country) filter;
        for (int index = 0; index < this.Count; ++index)
        {
          Referee referee = (Referee) this[index];
          if (referee.Country == country)
            refereeList.Add((object) referee);
        }
        return (IdArrayList) refereeList;
      }
      if (!(filter.GetType().Name == "League"))
        return (IdArrayList) this;
      League league = (League) filter;
      for (int index = 0; index < this.Count; ++index)
      {
        Referee referee = (Referee) this[index];
        if (referee.IsInLeague(league))
          refereeList.Add((object) referee);
      }
      return (IdArrayList) refereeList;
    }
  }
}
