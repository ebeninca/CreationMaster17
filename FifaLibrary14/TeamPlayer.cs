// Original code created by Rinaldo

namespace FifaLibrary
{
  public class TeamPlayer
  {
    public int m_jerseynumber;
    private int m_position;
    private Player m_Player;
    private Team m_Team;
    private int m_leaguegoals;
    private bool m_isamongtopscorers;
    private int m_yellows;
    private int m_reds;
    private bool m_isamongtopscorersinteam;
    private int m_injury;
    private int m_leagueappearances;
    private bool m_istopscorer;
    private int m_form;
    private int m_prevform;

    public int jerseynumber
    {
      get
      {
        return this.m_jerseynumber;
      }
      set
      {
        this.m_jerseynumber = value;
      }
    }

    public int position
    {
      get
      {
        return this.m_position;
      }
      set
      {
        this.m_position = value;
      }
    }

    public Player Player
    {
      get
      {
        return this.m_Player;
      }
      set
      {
        this.m_Player = value;
      }
    }

    public Team Team
    {
      get
      {
        return this.m_Team;
      }
      set
      {
        this.m_Team = value;
      }
    }

    public TeamPlayer(Record r, Player player, Team team)
    {
      this.m_jerseynumber = r.GetAndCheckIntField(FI.teamplayerlinks_jerseynumber);
      this.m_position = r.GetAndCheckIntField(FI.teamplayerlinks_position);
      this.m_Player = player;
      this.m_Team = team;
      this.m_leaguegoals = r.GetAndCheckIntField(FI.teamplayerlinks_leaguegoals);
      this.m_leagueappearances = r.GetAndCheckIntField(FI.teamplayerlinks_leagueappearances);
      this.m_prevform = r.GetAndCheckIntField(FI.teamplayerlinks_prevform);
      this.m_form = r.GetAndCheckIntField(FI.teamplayerlinks_form);
      this.m_isamongtopscorers = r.GetAndCheckIntField(FI.teamplayerlinks_isamongtopscorers) != 0;
      this.m_isamongtopscorersinteam = r.GetAndCheckIntField(FI.teamplayerlinks_isamongtopscorersinteam) != 0;
      this.m_istopscorer = r.GetAndCheckIntField(FI.teamplayerlinks_istopscorer) != 0;
      this.m_injury = r.GetAndCheckIntField(FI.teamplayerlinks_injury);
      this.m_yellows = r.GetAndCheckIntField(FI.teamplayerlinks_yellows);
      this.m_reds = r.GetAndCheckIntField(FI.teamplayerlinks_reds);
    }

    public TeamPlayer(Player player)
    {
      this.m_jerseynumber = 99;
      this.m_position = player.preferredposition1;
      this.m_Player = player;
      this.m_leaguegoals = 0;
      this.m_isamongtopscorers = false;
      this.m_isamongtopscorersinteam = false;
      this.m_istopscorer = false;
      this.m_yellows = 0;
      this.m_reds = 0;
      this.m_injury = 0;
      this.m_leagueappearances = 0;
      this.m_form = 3;
      this.m_prevform = 3;
    }

    public TeamPlayer(ERole role)
    {
      this.m_jerseynumber = 0;
      this.m_position = (int) role;
      this.m_Player = (Player) null;
      this.m_Team = (Team) null;
      this.m_leaguegoals = 0;
      this.m_isamongtopscorers = false;
      this.m_isamongtopscorersinteam = false;
      this.m_istopscorer = false;
      this.m_yellows = 0;
      this.m_reds = 0;
      this.m_injury = 0;
      this.m_leagueappearances = 0;
      this.m_form = 3;
      this.m_prevform = 3;
    }

    public void Save(Record r, int artificialkey)
    {
      if (this.m_Player == null || this.m_Team == null)
        return;
      r.IntField[FI.teamplayerlinks_artificialkey] = artificialkey;
      r.IntField[FI.teamplayerlinks_teamid] = this.m_Team.Id;
      r.IntField[FI.teamplayerlinks_playerid] = this.m_Player.Id;
      r.IntField[FI.teamplayerlinks_jerseynumber] = this.m_jerseynumber;
      r.IntField[FI.teamplayerlinks_position] = this.m_position;
      r.IntField[FI.teamplayerlinks_leaguegoals] = this.m_leaguegoals = r.GetAndCheckIntField(FI.teamplayerlinks_leaguegoals);
      r.IntField[FI.teamplayerlinks_leagueappearances] = this.m_leagueappearances = r.GetAndCheckIntField(FI.teamplayerlinks_leagueappearances);
      r.IntField[FI.teamplayerlinks_prevform] = this.m_prevform = r.GetAndCheckIntField(FI.teamplayerlinks_prevform);
      r.IntField[FI.teamplayerlinks_form] = this.m_form = r.GetAndCheckIntField(FI.teamplayerlinks_form);
      r.IntField[FI.teamplayerlinks_isamongtopscorers] = this.m_isamongtopscorers ? 1 : 0;
      r.IntField[FI.teamplayerlinks_isamongtopscorersinteam] = this.m_isamongtopscorersinteam ? 1 : 0;
      r.IntField[FI.teamplayerlinks_istopscorer] = this.m_istopscorer ? 1 : 0;
      r.IntField[FI.teamplayerlinks_injury] = this.m_injury;
      r.IntField[FI.teamplayerlinks_yellows] = this.m_yellows;
      r.IntField[FI.teamplayerlinks_reds] = this.m_reds;
    }

    public override string ToString()
    {
      return this.m_jerseynumber.ToString() + " " + (this.m_Player != null ? this.m_Player.ToString() : string.Empty);
    }

    public int AssignFreeNumber(int guessNumber)
    {
      int jerseynumber = this.m_jerseynumber;
      int step = guessNumber > jerseynumber ? 1 : -1;
      this.m_jerseynumber = this.RecursiveNumber(jerseynumber, step);
      return this.m_jerseynumber;
    }

    private int RecursiveNumber(int number, int step)
    {
      if (this.m_Team.Roster.IsNumberFree(number))
        return number;
      switch (number)
      {
        case 1:
          number = 99;
          break;
        case 99:
          number = 1;
          break;
        default:
          number += step;
          break;
      }
      return this.RecursiveNumber(number, step);
    }
  }
}
