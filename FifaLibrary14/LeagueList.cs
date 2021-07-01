// Original code created by Rinaldo

using System.Collections;

namespace FifaLibrary
{
  public class LeagueList : IdArrayList
  {
    public LeagueList()
      : base(typeof (League))
    {
    }

    public LeagueList(DbFile fifaDbFile)
      : base(typeof (League))
    {
      this.Load(fifaDbFile);
    }

    public void Load(DbFile fifaDbFile)
    {
      Table table = FifaEnvironment.FifaDb.Table[TI.leagues];
      int minId = 1;
      int maxId = 2028;
      this.Load(FifaEnvironment.FifaDb.Table[TI.leagues], minId, maxId);
      this.FillFromBoardOutcomes(fifaDbFile.Table[TI.career_boardoutcomes]);
    }

    public void Load(Table t, int minId, int maxId)
    {
      this.MinId = minId;
      this.MaxId = maxId;
      this.Clear();
      for (int index = 0; index < t.NRecords; ++index)
        this.Add((object) new League(t.Records[index]));
      this.SortId();
    }

    public void FillFromBoardOutcomes(Table t)
    {
      for (int index = 0; index < t.NRecords; ++index)
      {
        Record record = t.Records[index];
        ((League) this.SearchId(record.IntField[FI.career_boardoutcomes_leagueid]))?.FillFromBoardOutcomes(record);
      }
    }

    public League AddNewLeague()
    {
      int newId = Trophy.AutoAsset();
      return newId < 0 ? (League) null : (League) this.CreateNewId(newId);
    }

    public void DeleteLeague(League league)
    {
      this.RemoveId((IdObject) league);
    }

    public void FillFromLeagueTeamLinks(DbFile fifaDbFile)
    {
      if (FifaEnvironment.Teams == null)
        return;
      this.FillFromLeagueTeamLinks(fifaDbFile.Table[TI.leagueteamlinks]);
    }

    public void FillFromLeagueTeamLinks(Table leagueteamlinksTable)
    {
      if (FifaEnvironment.Teams == null)
        return;
      Table table = leagueteamlinksTable;
      for (int index = 0; index < table.NRecords; ++index)
      {
        Record record = table.Records[index];
        int num1 = record.IntField[FI.leagueteamlinks_teamid];
        int num2 = record.IntField[FI.leagueteamlinks_leagueid];
        Team team = (Team) FifaEnvironment.Teams.SearchId(num1);
        if (team == null)
        {
          int num3 = (int) FifaEnvironment.UserMessages.ShowMessage(5022, num1);
        }
        else
        {
          League league = (League) this.SearchId(num2);
          if (league == null)
          {
            int num4 = (int) FifaEnvironment.UserMessages.ShowMessage(5023, num2);
          }
          else
          {
            league.LinkTeam(team);
            team.League = league;
          }
        }
      }
    }

    public League SearchLeague(int leagueid)
    {
      return (League) this.SearchId(leagueid);
    }

    public void Save(DbFile fifaDbFile)
    {
      Table table1 = fifaDbFile.Table[TI.leagues];
      Table table2 = fifaDbFile.Table[TI.leagueteamlinks];
      Table table3 = fifaDbFile.Table[TI.career_boardoutcomes];
      table1.ResizeRecords(this.Count);
      int nRecords1 = 0;
      int index1 = 0;
      int nRecords2 = 0;
      foreach (League league in (ArrayList) this)
      {
        Record record = table1.Records[index1];
        ++index1;
        league.SaveLeague(record);
        nRecords1 += league.PlayingTeams.Count;
        if (league.boardoutcomes[0] != 0)
          ++nRecords2;
      }
      table2.ResizeRecords(nRecords1);
      table3.ResizeRecords(nRecords2);
      int artificialkey = 0;
      int index2 = 0;
      int index3 = 0;
      foreach (League league in (ArrayList) this)
      {
        foreach (Team playingTeam in (ArrayList) league.PlayingTeams)
        {
          Record record = table2.Records[index2];
          league.SaveTeamLink(record, playingTeam, artificialkey);
          ++artificialkey;
          ++index2;
        }
        if (league.boardoutcomes[0] != 0)
        {
          Record record = table3.Records[index3];
          league.SaveBoardOutcomes(record);
          ++index3;
        }
      }
      foreach (League league in (ArrayList) this)
      {
        int id = league.Id;
        if (FifaEnvironment.Language != null)
        {
          FifaEnvironment.Language.SetLeagueString(id, Language.ELeagueStringType.Abbr15, league.ShortName);
          FifaEnvironment.Language.SetLeagueString(id, Language.ELeagueStringType.Full, league.LongName);
        }
      }
    }

    public League FitLeague(string name, int id)
    {
      foreach (League league in (ArrayList) this)
      {
        if (league.leaguename == name || league.ShortName == name || league.LongName == name)
          return league;
      }
      return (League) null;
    }

    public override IdArrayList Filter(IdObject filter)
    {
      if (filter == null)
        return (IdArrayList) this;
      LeagueList leagueList = new LeagueList();
      if (!(filter.GetType().Name == "Country"))
        return (IdArrayList) this;
      Country country = (Country) filter;
      for (int index = 0; index < this.Count; ++index)
      {
        League league = (League) this[index];
        if (league.Country == country)
          leagueList.Add((object) league);
      }
      return (IdArrayList) leagueList;
    }

    public void LinkCountry(CountryList countryList)
    {
      foreach (League league in (ArrayList) this)
        league.LinkCountry(countryList);
    }

    public void LinkBall(BallList ballList)
    {
      if (ballList == null)
        return;
      foreach (Team team in (ArrayList) this)
        team.LinkBall(ballList);
    }
  }
}
