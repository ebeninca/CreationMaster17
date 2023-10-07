// Original code created by Rinaldo

using System.Collections;
using System.Drawing;

namespace FifaLibrary
{
  public class League : IdObject
  {
    private int[] m_boardoutcomes = new int[5];
    private TeamList m_PlayingTeams = new TeamList();
    private string m_leaguename;
    private int m_level;
    private int m_countryid;
    private Country m_Country;
    private bool m_iswithintransferwindow;
    private int m_leaguetimeslice;
    private string m_ShortName;
    private string m_LongName;
    private Trophy m_Trophy;

    public string leaguename
    {
      get
      {
        return this.m_leaguename;
      }
      set
      {
        this.m_leaguename = value;
      }
    }

    public int level
    {
      get
      {
        return this.m_level;
      }
      set
      {
        this.m_level = value;
      }
    }

    public int countryid
    {
      get
      {
        return this.m_countryid;
      }
      set
      {
        this.m_countryid = value;
      }
    }

    public Country Country
    {
      get
      {
        return this.m_Country;
      }
      set
      {
        this.m_Country = value;
        if (this.m_Country != null)
          this.m_countryid = this.m_Country.Id;
        else
          this.m_countryid = 0;
      }
    }

    public int[] boardoutcomes
    {
      get
      {
        return this.m_boardoutcomes;
      }
      set
      {
        this.m_boardoutcomes = value;
      }
    }

    public bool iswithintransferwindow
    {
      get
      {
        return this.m_iswithintransferwindow;
      }
      set
      {
        this.m_iswithintransferwindow = value;
      }
    }

    public int leaguetimeslice
    {
      get
      {
        return this.leaguetimeslice;
      }
      set
      {
        this.leaguetimeslice = value;
      }
    }

    public string ShortName
    {
      get
      {
        return this.m_ShortName;
      }
      set
      {
        this.m_ShortName = value;
      }
    }

    public string LongName
    {
      get
      {
        return this.m_LongName;
      }
      set
      {
        this.m_LongName = value;
      }
    }

    public TeamList PlayingTeams
    {
      get
      {
        return this.m_PlayingTeams;
      }
      set
      {
        this.m_PlayingTeams = value;
      }
    }

    public Trophy Trophy
    {
      get
      {
        return this.m_Trophy;
      }
      set
      {
        this.m_Trophy = value;
      }
    }

    public override string ToString()
    {
      if (this.m_ShortName != null && this.m_ShortName != string.Empty)
        return this.m_ShortName;
      return this.m_leaguename != null ? this.m_leaguename : string.Empty;
    }

    public string DatabaseString()
    {
      return this.m_leaguename;
    }

    public League(int leagueid)
      : base(leagueid)
    {
      this.Id = leagueid;
      this.m_leaguename = "New League";
      this.m_level = 1;
      this.m_countryid = 0;
      this.LinkCountry(FifaEnvironment.Countries);
      this.m_iswithintransferwindow = false;
      this.m_leaguetimeslice = 0;
      this.m_ShortName = "Short League Name";
      this.m_LongName = "Long League Name";
      this.m_boardoutcomes[0] = 0;
      this.m_boardoutcomes[1] = 0;
      this.m_boardoutcomes[2] = 0;
      this.m_boardoutcomes[3] = 0;
      this.m_boardoutcomes[4] = 0;
    }

    public League(Record r)
      : base(r.IntField[FI.leagues_leagueid])
    {
      this.Load(r);
      this.FillFromLanguage();
    }

    public void Load(Record r)
    {
      this.m_leaguename = r.StringField[FI.leagues_leaguename];
      this.m_level = r.GetAndCheckIntField(FI.leagues_level);
      this.m_countryid = r.GetAndCheckIntField(FI.leagues_countryid);
      this.m_iswithintransferwindow = r.GetAndCheckIntField(FI.leagues_iswithintransferwindow) != 0;
      this.m_leaguetimeslice = r.GetAndCheckIntField(FI.leagues_leaguetimeslice);
    }

    public static League GetDefaultLeague()
    {
      return FifaEnvironment.Leagues.SearchLeague(76);
    }

    public static int GetDefaultLeagueId()
    {
      return 76;
    }

    public void LinkTeam(int teamid)
    {
      if (FifaEnvironment.Teams == null)
        return;
      Team team = (Team) FifaEnvironment.Teams.SearchId(teamid);
      if (team == null)
      {
        int num = (int) FifaEnvironment.UserMessages.ShowMessage(5022, teamid);
      }
      else
        this.m_PlayingTeams.Add((object) team);
    }

    public void LinkTeam(Team team)
    {
      if (team == null)
      {
        int num = (int) FifaEnvironment.UserMessages.ShowMessage(5022, team.Id);
      }
      else
        this.m_PlayingTeams.Add((object) team);
    }

    public void LinkCountry(CountryList countryList)
    {
      if (countryList == null)
        return;
      this.m_Country = (Country) countryList.SearchId(this.m_countryid);
    }

    public void FillFromLanguage()
    {
      if (FifaEnvironment.Language != null)
      {
        this.m_ShortName = FifaEnvironment.Language.GetLeagueString(this.Id, Language.ELeagueStringType.Abbr15);
        this.m_LongName = FifaEnvironment.Language.GetLeagueString(this.Id, Language.ELeagueStringType.Full);
        if (this.m_LongName != null && !(this.m_LongName == string.Empty))
          return;
        this.m_LongName = this.m_ShortName;
      }
      else
      {
        this.m_ShortName = string.Empty;
        this.m_LongName = string.Empty;
        if (this.m_LongName != null && !(this.m_LongName == string.Empty))
          return;
        this.m_LongName = this.m_ShortName;
      }
    }

    public void FillFromBoardOutcomes(Record r)
    {
      this.m_boardoutcomes[0] = r.GetAndCheckIntField(FI.career_boardoutcomes_outcome1);
      this.m_boardoutcomes[1] = r.GetAndCheckIntField(FI.career_boardoutcomes_outcome2);
      this.m_boardoutcomes[2] = r.GetAndCheckIntField(FI.career_boardoutcomes_outcome3);
      this.m_boardoutcomes[3] = r.GetAndCheckIntField(FI.career_boardoutcomes_outcome4);
      this.m_boardoutcomes[4] = r.GetAndCheckIntField(FI.career_boardoutcomes_outcome5);
    }

    public void SaveBoardOutcomes(Record r)
    {
      r.IntField[FI.career_boardoutcomes_leagueid] = this.Id;
      r.IntField[FI.career_boardoutcomes_outcome1] = this.m_boardoutcomes[0];
      r.IntField[FI.career_boardoutcomes_outcome2] = this.m_boardoutcomes[1];
      r.IntField[FI.career_boardoutcomes_outcome3] = this.m_boardoutcomes[2];
      r.IntField[FI.career_boardoutcomes_outcome4] = this.m_boardoutcomes[3];
      r.IntField[FI.career_boardoutcomes_outcome5] = this.m_boardoutcomes[4];
    }

    public void AddTeam(Team team)
    {
      if (team == null)
        return;
      if (team.League != null && team.League != this)
        team.League.RemoveTeam(team);
      this.m_PlayingTeams.InsertId((IdObject) team);
      team.League = this;
      team.PrevLeague = this;
      team.currenttableposition = this.m_PlayingTeams.Count;
      team.previousyeartableposition = this.m_PlayingTeams.Count;
    }

    public void RemoveTeam(Team team)
    {
      if (team == null)
        return;
      if (team.League == this)
        team.League = (League) null;
      this.m_PlayingTeams.RemoveId((IdObject) team);
    }

    public void RemoveAllTeams()
    {
      while (this.m_PlayingTeams.Count > 0)
        this.RemoveTeam((Team) this.m_PlayingTeams[0]);
    }

    public static string ReplayLogoTextureFileName(int id)
    {
      return "data/sceneassets/leaguelogo/leaguelogo_" + id.ToString() + "_textures.rx3";
    }

    public string ReplayLogoTextureFileName()
    {
      return League.ReplayLogoTextureFileName(this.Id);
    }

    public string ReplayLogoTexturesTemplateFileName()
    {
      return "data/sceneassets/leaguelogo/leaguelogo_#_textures.rx3";
    }

    public static Bitmap[] GetReplayLogoTextures(int leagueId)
    {
      return FifaEnvironment.GetBmpsFromRx3(League.ReplayLogoTextureFileName(leagueId));
    }

    public Bitmap[] GetReplayLogoTextures()
    {
      return FifaEnvironment.GetBmpsFromRx3(this.ReplayLogoTextureFileName());
    }

    public bool SetReplayLogoTextures(Bitmap[] bitmaps)
    {
      return FifaEnvironment.ImportBmpsIntoZdata(this.ReplayLogoTexturesTemplateFileName(), this.Id, bitmaps, ECompressionMode.Chunkzip2);
    }

    public bool DeleteReplayLogoTextures()
    {
      return FifaEnvironment.DeleteFromZdata(this.ReplayLogoTextureFileName());
    }

    public static string ReplayLogoModelFileName(int id)
    {
      return "data/sceneassets/leaguelogo/leaguelogo_" + id.ToString() + ".rx3";
    }

    public string ReplayLogoModelTemplateFileName()
    {
      return "data/sceneassets/leaguelogo/leaguelogo_#.rx3";
    }

    public string ReplayLogoModelFileName()
    {
      return League.ReplayLogoModelFileName(this.Id);
    }

    public Rx3File GetReplayLogoModel()
    {
      return FifaEnvironment.GetRx3FromZdata(this.ReplayLogoModelFileName());
    }

    public static Rx3File GetReplayLogoModel(int id)
    {
      return FifaEnvironment.GetRx3FromZdata(League.ReplayLogoModelFileName(id));
    }

    public bool SetReplayLogoModel(string rx3FileName)
    {
      return FifaEnvironment.ImportFileIntoZdataAs(rx3FileName, this.ReplayLogoModelFileName(), false, ECompressionMode.Chunkzip2);
    }

    public bool DeleteReplayLogoModel()
    {
      return FifaEnvironment.DeleteFromZdata(this.ReplayLogoModelFileName());
    }

    public bool IsReplayLogoPatched()
    {
      bool flag = FifaEnvironment.IsPatched(this.ReplayLogoTextureFileName());
      return FifaEnvironment.IsPatched(this.ReplayLogoTextureFileName()) || flag;
    }

    public bool CreateReplayLogoPatch()
    {
      bool flag = FifaEnvironment.ImportFileIntoZdataAs(FifaEnvironment.LaunchDir + "\\Templates\\" + this.ReplayLogoTexturesTemplateFileName(), this.ReplayLogoTextureFileName(), false, ECompressionMode.None);
      return FifaEnvironment.ImportFileIntoZdataAs(FifaEnvironment.LaunchDir + "\\Templates\\" + this.ReplayLogoModelTemplateFileName(), this.ReplayLogoModelFileName(), false, ECompressionMode.None) && flag;
    }

    public bool RemoveReplayLogoPatch()
    {
      bool flag = FifaEnvironment.DeleteFromZdata(this.ReplayLogoTextureFileName());
      return FifaEnvironment.DeleteFromZdata(this.ReplayLogoModelFileName()) && flag;
    }

    public static string AnimLogoDdsFileName(int id, int year)
    {
      return year == 14 ? "data/ui/imgassets/league/l" + id.ToString() + ".dds" : "data/ui/imgassets/league/light/l" + id.ToString() + ".dds";
    }

    public static string AnimLogoDdsFileName(int id)
    {
      return League.AnimLogoDdsFileName(id, FifaEnvironment.Year);
    }

    public string AnimLogoTemplateFileName()
    {
      return FifaEnvironment.Year == 14 ? "data/ui/imgassets/league/l#.dds" : "data/ui/imgassets/league/light/l#.dds";
    }

    public string AnimLogoDdsFileName()
    {
      return League.AnimLogoDdsFileName(this.Id);
    }

    public Bitmap GetAnimLogo()
    {
      return FifaEnvironment.GetDdsArtasset(this.AnimLogoDdsFileName());
    }

    public bool SetAnimLogo(Bitmap bitmap)
    {
      return bitmap != null && FifaEnvironment.SetDdsArtasset(this.AnimLogoTemplateFileName(), this.Id, bitmap);
    }

    public bool DeleteAnimLogo()
    {
      return FifaEnvironment.DeleteFromZdata(this.AnimLogoDdsFileName());
    }

    public static string AnimLogoDarkDdsFileName(int id)
    {
      return "data/ui/imgassets/league/dark/l" + id.ToString() + ".dds";
    }

    public string AnimLogoDarkTemplateFileName()
    {
      return "data/ui/imgassets/league/dark/l#.dds";
    }

    public string AnimLogoDarkDdsFileName()
    {
      return League.AnimLogoDarkDdsFileName(this.Id);
    }

    public Bitmap GetAnimLogoDark()
    {
      return FifaEnvironment.GetDdsArtasset(this.AnimLogoDarkDdsFileName());
    }

    public bool SetAnimLogoDark(Bitmap bitmap)
    {
      return bitmap != null && FifaEnvironment.SetDdsArtasset(this.AnimLogoDarkTemplateFileName(), this.Id, bitmap);
    }

    public bool DeleteAnimLogoDark()
    {
      return FifaEnvironment.DeleteFromZdata(this.AnimLogoDarkDdsFileName());
    }

    public static string Logo512x128DdsFileName(int id)
    {
      return FifaEnvironment.Year == 14 ? (string) null : "data/ui/imgassets/league512x128/light/l" + id.ToString() + ".dds";
    }

    public string Logo512x128TemplateFileName()
    {
      return FifaEnvironment.Year == 14 ? (string) null : "data/ui/imgassets/league512x128/light/l#.dds";
    }

    public string Logo512x128DdsFileName()
    {
      return League.Logo512x128DdsFileName(this.Id);
    }

    public Bitmap GetLogo512x128()
    {
      return FifaEnvironment.GetDdsArtasset(this.Logo512x128DdsFileName());
    }

    public bool SetLogo512x128(Bitmap bitmap)
    {
      return bitmap != null && FifaEnvironment.SetDdsArtasset(this.Logo512x128TemplateFileName(), this.Id, bitmap);
    }

    public bool DeleteLogo512x128()
    {
      return FifaEnvironment.DeleteFromZdata(this.Logo512x128DdsFileName());
    }

    public static string Logo512x128DarkDdsFileName(int id)
    {
      return FifaEnvironment.Year == 14 ? (string) null : "data/ui/imgassets/league512x128/dark/l" + id.ToString() + ".dds";
    }

    public string Logo512x128DarkTemplateFileName()
    {
      return FifaEnvironment.Year == 14 ? (string) null : "data/ui/imgassets/league512x128/dark/l#.dds";
    }

    public string Logo512x128DarkDdsFileName()
    {
      return League.Logo512x128DarkDdsFileName(this.Id);
    }

    public Bitmap GetLogo512x128Dark()
    {
      return FifaEnvironment.GetDdsArtasset(this.Logo512x128DarkDdsFileName());
    }

    public bool SetLogo512x128Dark(Bitmap bitmap)
    {
      return bitmap != null && FifaEnvironment.SetDdsArtasset(this.Logo512x128DarkTemplateFileName(), this.Id, bitmap);
    }

    public bool DeleteLogo512x128Dark()
    {
      return FifaEnvironment.DeleteFromZdata(this.Logo512x128DarkDdsFileName());
    }

    public static string TinyLogoDdsFileName(int id, int year)
    {
      return year == 14 ? "data/ui/imgassets/leaguelogos_tiny/l" + id.ToString() + ".dds" : "data/ui/imgassets/leaguelogos_tiny/light/l" + id.ToString() + ".dds";
    }

    public static string TinyLogoDdsFileName(int id)
    {
      return League.TinyLogoDdsFileName(id, FifaEnvironment.Year);
    }

    public string TinyLogoTemplateFileName()
    {
      return FifaEnvironment.Year == 14 ? "data/ui/imgassets/leaguelogos_tiny/l#.dds" : "data/ui/imgassets/leaguelogos_tiny/light/l#.dds";
    }

    public string TinyLogoDdsFileName()
    {
      return League.TinyLogoDdsFileName(this.Id);
    }

    public Bitmap GetTinyLogo()
    {
      return FifaEnvironment.GetDdsArtasset(this.TinyLogoDdsFileName());
    }

    public bool SetTinyLogo(Bitmap bitmap)
    {
      return bitmap != null && FifaEnvironment.SetDdsArtasset(this.TinyLogoTemplateFileName(), this.Id, bitmap);
    }

    public bool DeleteTinyLogo()
    {
      return FifaEnvironment.DeleteFromZdata(this.TinyLogoDdsFileName());
    }

    public static string TinyLogoDarkDdsFileName(int id)
    {
      return "data/ui/imgassets/leaguelogos_tiny/dark/l" + id.ToString() + ".dds";
    }

    public string TinyLogoDarkTemplateFileName()
    {
      return "data/ui/imgassets/leaguelogos_tiny/dark/l#.dds";
    }

    public string TinyLogoDarkDdsFileName()
    {
      return League.TinyLogoDarkDdsFileName(this.Id);
    }

    public Bitmap GetTinyLogoDark()
    {
      return FifaEnvironment.GetDdsArtasset(this.TinyLogoDarkDdsFileName());
    }

    public bool SetTinyLogoDark(Bitmap bitmap)
    {
      return bitmap != null && FifaEnvironment.SetDdsArtasset(this.TinyLogoDarkTemplateFileName(), this.Id, bitmap);
    }

    public bool DeleteTinyLogoDark()
    {
      return FifaEnvironment.DeleteFromZdata(this.TinyLogoDarkDdsFileName());
    }

    public static string SmallLogoDdsFileName(int id)
    {
      return FifaEnvironment.Year == 14 ? "data/ui/imgassets/leaguelogos_sm/l" + id.ToString() + ".dds" : (string) null;
    }

    public string SmallLogoTemplateFileName()
    {
      return FifaEnvironment.Year == 14 ? "data/ui/imgassets/leaguelogos_sm/l#.dds" : (string) null;
    }

    public string SmallLogoDdsFileName()
    {
      return League.SmallLogoDdsFileName(this.Id);
    }

    public Bitmap GetSmallLogo()
    {
      return FifaEnvironment.GetDdsArtasset(this.SmallLogoDdsFileName());
    }

    public bool SetSmallLogo(Bitmap bitmap)
    {
      return bitmap != null && FifaEnvironment.SetDdsArtasset(this.SmallLogoTemplateFileName(), this.Id, bitmap);
    }

    public bool DeleteSmallLogo()
    {
      return FifaEnvironment.DeleteFromZdata(this.SmallLogoDdsFileName());
    }

    public static string SmallLogoDarkDdsFileName(int id)
    {
      return "data/ui/imgassets/leaguelogos_sm/dark/l" + id.ToString() + ".dds";
    }

    public string SmallLogoDarkTemplateFileName()
    {
      return "data/ui/imgassets/leaguelogos_sm/dark/l#.dds";
    }

    public string SmallLogoDarkDdsFileName()
    {
      return League.SmallLogoDarkDdsFileName(this.Id);
    }

    public Bitmap GetSmallLogoDark()
    {
      return FifaEnvironment.GetDdsArtasset(this.SmallLogoDarkDdsFileName());
    }

    public bool SetSmallLogoDark(Bitmap bitmap)
    {
      return bitmap != null && FifaEnvironment.SetDdsArtasset(this.SmallLogoDarkTemplateFileName(), this.Id, bitmap);
    }

    public bool DeleteSmallLogoDark()
    {
      return FifaEnvironment.DeleteFromZdata(this.SmallLogoDarkDdsFileName());
    }

    public void SaveLeague(Record r)
    {
      r.IntField[FI.leagues_leagueid] = this.Id;
      r.StringField[FI.leagues_leaguename] = this.m_leaguename;
      r.IntField[FI.leagues_level] = this.m_level;
      r.IntField[FI.leagues_countryid] = this.m_countryid;
      r.IntField[FI.leagues_leaguetimeslice] = this.m_leaguetimeslice;
      r.IntField[FI.leagues_iswithintransferwindow] = this.m_iswithintransferwindow ? 1 : 0;
    }

    public void SaveTeamLink(Record r, Team team, int artificialkey)
    {
      r.IntField[FI.leagueteamlinks_artificialkey] = artificialkey;
      r.IntField[FI.leagueteamlinks_leagueid] = this.Id;
      r.IntField[FI.leagueteamlinks_teamid] = team.Id;
      if (team.PrevLeague != null)
      {
        r.IntField[FI.leagueteamlinks_prevleagueid] = team.PrevLeague.Id;
        r.IntField[FI.leagueteamlinks_champion] = team.IsChampion ? 1 : 0;
      }
      else
      {
        r.IntField[FI.leagueteamlinks_prevleagueid] = this.Id;
        r.IntField[FI.leagueteamlinks_champion] = 0;
      }
      r.IntField[FI.leagueteamlinks_previousyeartableposition] = team.previousyeartableposition;
      r.IntField[FI.leagueteamlinks_currenttableposition] = team.currenttableposition;
      r.IntField[FI.leagueteamlinks_teamshortform] = team.teamshortform;
      r.IntField[FI.leagueteamlinks_teamlongform] = team.teamlongform;
      r.IntField[FI.leagueteamlinks_teamform] = team.teamform;
      r.IntField[FI.leagueteamlinks_hasachievedobjective] = team.hasachievedobjective ? 1 : 0;
      r.IntField[FI.leagueteamlinks_yettowin] = team.yettowin ? 1 : 0;
      r.IntField[FI.leagueteamlinks_unbeatenallcomps] = team.unbeatenallcomps ? 1 : 0;
      r.IntField[FI.leagueteamlinks_unbeatenaway] = team.unbeatenaway ? 1 : 0;
      r.IntField[FI.leagueteamlinks_unbeatenhome] = team.unbeatenhome ? 1 : 0;
      r.IntField[FI.leagueteamlinks_unbeatenleague] = team.unbeatenleague ? 1 : 0;
      r.IntField[FI.leagueteamlinks_highestpossible] = team.highestpossible;
      r.IntField[FI.leagueteamlinks_highestprobable] = team.highestprobable;
      r.IntField[FI.leagueteamlinks_nummatchesplayed] = team.nummatchesplayed;
      //r.IntField[FI.leagueteamlinks_gapresult] = team.gapresult;
      r.IntField[FI.leagueteamlinks_grouping] = team.grouping;
      r.IntField[FI.leagueteamlinks_objective] = team.objective;
      r.IntField[FI.leagueteamlinks_actualvsexpectations] = team.actualvsexpectations;
      r.IntField[FI.leagueteamlinks_lastgameresult] = team.lastgameresult;
      r.IntField[FI.leagueteamlinks_homega] = team.homega;
      r.IntField[FI.leagueteamlinks_homegf] = team.homegf;
      r.IntField[FI.leagueteamlinks_points] = team.points;
      r.IntField[FI.leagueteamlinks_awayga] = team.awayga;
      r.IntField[FI.leagueteamlinks_homewins] = team.secondarytable;
      r.IntField[FI.leagueteamlinks_homewins] = team.homewins;
      r.IntField[FI.leagueteamlinks_awaywins] = team.awaywins;
      r.IntField[FI.leagueteamlinks_homelosses] = team.homelosses;
      r.IntField[FI.leagueteamlinks_awaylosses] = team.awaylosses;
      r.IntField[FI.leagueteamlinks_awaydraws] = team.awaydraws;
      r.IntField[FI.leagueteamlinks_homedraws] = team.homedraws;
    }

    public void SynchronizeLeague()
    {
    }

    public bool ContainsNationalTeams()
    {
      foreach (Team playingTeam in (ArrayList) this.m_PlayingTeams)
      {
        if (playingTeam.NationalTeam)
          return true;
      }
      return false;
    }
  }
}
