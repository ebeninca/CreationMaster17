// Original code created by Rinaldo

using System;

namespace FifaLibrary
{
  public class Formation : IdObject
  {
    private PlayingRole[] m_PlayingRoles = new PlayingRole[11];
    private Team m_Team;
    private string m_formationname;
    private string m_formationfullname;
    private int m_teamid;
    private int m_relativeformationid;
    private int m_formations_issweeper;
    private int m_offensiverating;
    private int m_formationfullnameid;
    private float m_defenders;
    private float m_midfielders;
    private float m_attackers;

    public PlayingRole[] PlayingRoles
    {
      get
      {
        return this.m_PlayingRoles;
      }
      set
      {
        this.m_PlayingRoles = value;
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
        if (this.m_Team != null)
          this.m_teamid = this.m_Team.Id;
        else
          this.m_teamid = -1;
      }
    }

    public string formationname
    {
      get
      {
        return this.m_formationname;
      }
      set
      {
        this.m_formationname = value;
      }
    }

    public string formationfullname
    {
      get
      {
        return this.m_formationfullname;
      }
      set
      {
        this.m_formationfullname = value;
      }
    }

    public int teamid
    {
      get
      {
        return this.m_teamid;
      }
      set
      {
        this.m_teamid = value;
      }
    }

    public int relativeformationid
    {
      get
      {
        return this.m_relativeformationid;
      }
      set
      {
        this.m_relativeformationid = value;
      }
    }

    public int formations_issweeper
    {
      get
      {
        return this.m_formations_issweeper;
      }
      set
      {
        this.m_formations_issweeper = value;
      }
    }

    public int offensiverating
    {
      get
      {
        return this.m_offensiverating;
      }
      set
      {
        this.m_offensiverating = value;
      }
    }

    public int formationfullnameid
    {
      get
      {
        return this.m_formationfullnameid;
      }
      set
      {
        this.m_formationfullnameid = value;
      }
    }

    public float defenders
    {
      get
      {
        return this.m_defenders;
      }
      set
      {
        this.m_defenders = value;
      }
    }

    public float midfielders
    {
      get
      {
        return this.m_midfielders;
      }
      set
      {
        this.m_midfielders = value;
      }
    }

    public float attackers
    {
      get
      {
        return this.m_attackers;
      }
      set
      {
        this.m_attackers = value;
      }
    }

    public bool IsGeneric()
    {
      return this.m_teamid == -1;
    }

    public string Name
    {
      get
      {
        return this.m_formationname;
      }
      set
      {
        if (value != null)
          this.m_formationname = value;
        else
          this.m_formationname = string.Empty;
      }
    }

    public override string ToString()
    {
      return this.m_teamid > 0 && this.m_Team != null ? this.m_Team.DatabaseName + " " + this.m_formationfullname : this.m_formationfullname;
    }

    public string DatabaseString()
    {
      return this.ToString();
    }

    public Formation(int formationid)
      : base(formationid)
    {
      this.Id = formationid;
      this.InitNewFormation();
    }

    public bool ReInitialize(Formation formation)
    {
      if (formation == null)
        return false;
      this.m_formationname = formation.m_formationname;
      this.m_formationfullname = formation.m_formationfullname;
      this.m_relativeformationid = formation.m_relativeformationid;
      this.m_formations_issweeper = formation.m_formations_issweeper;
      this.m_offensiverating = formation.m_offensiverating;
      this.m_formationfullnameid = formation.m_formationfullnameid;
      this.m_defenders = formation.m_defenders;
      this.m_midfielders = formation.m_midfielders;
      this.m_attackers = formation.m_attackers;
      for (int index = 0; index < 11; ++index)
        this.m_PlayingRoles[index].ReInitialize(formation.m_PlayingRoles[index]);
      return true;
    }

    public void LinkTeam(TeamList teamList)
    {
      if (teamList == null)
        return;
      this.m_Team = (Team) teamList.SearchId(this.m_teamid);
    }

    private void InitNewFormation()
    {
      this.m_formationname = "4-4-2";
      this.m_formationfullname = string.Empty;
      this.m_teamid = -1;
      this.m_relativeformationid = 24;
      this.m_formations_issweeper = 0;
      this.m_offensiverating = 1;
      this.m_formationfullnameid = -1;
      this.m_defenders = 4f;
      this.m_midfielders = 4f;
      this.m_attackers = 2f;
      this.m_PlayingRoles[0] = new PlayingRole((Role) FifaEnvironment.Roles[0]);
      this.m_PlayingRoles[1] = new PlayingRole((Role) FifaEnvironment.Roles[3]);
      this.m_PlayingRoles[2] = new PlayingRole((Role) FifaEnvironment.Roles[4]);
      this.m_PlayingRoles[3] = new PlayingRole((Role) FifaEnvironment.Roles[6]);
      this.m_PlayingRoles[4] = new PlayingRole((Role) FifaEnvironment.Roles[7]);
      this.m_PlayingRoles[5] = new PlayingRole((Role) FifaEnvironment.Roles[12]);
      this.m_PlayingRoles[6] = new PlayingRole((Role) FifaEnvironment.Roles[13]);
      this.m_PlayingRoles[7] = new PlayingRole((Role) FifaEnvironment.Roles[15]);
      this.m_PlayingRoles[8] = new PlayingRole((Role) FifaEnvironment.Roles[16]);
      this.m_PlayingRoles[9] = new PlayingRole((Role) FifaEnvironment.Roles[24]);
      this.m_PlayingRoles[10] = new PlayingRole((Role) FifaEnvironment.Roles[26]);
    }

    public Formation(Record r)
      : base(r.IntField[FI.formations_formationid])
    {
      this.Load(r);
    }

    public override IdObject Clone(int newId)
    {
      Formation formation = (Formation) base.Clone(newId);
      formation.m_PlayingRoles = new PlayingRole[11];
      for (int index = 0; index < 11; ++index)
      {
        int id = this.m_PlayingRoles[index].Id;
        PlayingRole playingRole = (PlayingRole) this.m_PlayingRoles[index].Clone(id);
        formation.m_PlayingRoles[index] = playingRole;
      }
      formation.m_formationname = "=" + formation.m_formationname;
      formation.m_Team = (Team) null;
      return (IdObject) formation;
    }

    public void Load(Record r)
    {
      this.m_formationname = r.StringField[FI.formations_formationname];
      this.m_teamid = r.IntField[FI.formations_teamid];
      if (FI.formations_relativeformationid >= 0)
        this.m_relativeformationid = r.IntField[FI.formations_relativeformationid];
      if (FI.formations_issweeper >= 0)
        this.m_formations_issweeper = r.IntField[FI.formations_issweeper];
      this.m_offensiverating = r.IntField[FI.formations_offensiverating];
      this.m_formationfullnameid = r.IntField[FI.formations_formationfullnameid];
      this.m_defenders = r.FloatField[FI.formations_defenders];
      this.m_midfielders = r.FloatField[FI.formations_midfielders];
      this.m_attackers = r.FloatField[FI.formations_attackers];
      this.m_PlayingRoles[0] = new PlayingRole(r, 0, FI.formations_position0);
      this.m_PlayingRoles[1] = new PlayingRole(r, 1, FI.formations_position1);
      this.m_PlayingRoles[2] = new PlayingRole(r, 2, FI.formations_position2);
      this.m_PlayingRoles[3] = new PlayingRole(r, 3, FI.formations_position3);
      this.m_PlayingRoles[4] = new PlayingRole(r, 4, FI.formations_position4);
      this.m_PlayingRoles[5] = new PlayingRole(r, 5, FI.formations_position5);
      this.m_PlayingRoles[6] = new PlayingRole(r, 6, FI.formations_position6);
      this.m_PlayingRoles[7] = new PlayingRole(r, 7, FI.formations_position7);
      this.m_PlayingRoles[8] = new PlayingRole(r, 8, FI.formations_position8);
      this.m_PlayingRoles[9] = new PlayingRole(r, 9, FI.formations_position9);
      this.m_PlayingRoles[10] = new PlayingRole(r, 10, FI.formations_position10);
      if (this.m_formationfullnameid != -1)
      {
        if (FifaEnvironment.Language != null)
          this.m_formationfullname = FifaEnvironment.Language.GetFormationString(this.m_formationfullnameid);
      }
      else
        this.m_formationfullname = this.m_formationname;
      if (this.m_formationfullname != null && !(this.m_formationfullname == string.Empty))
        return;
      this.m_formationfullname = this.m_formationname;
    }

    public void Save(Record r)
    {
      r.IntField[FI.formations_formationid] = this.Id;
      r.StringField[FI.formations_formationname] = this.m_formationname;
      r.IntField[FI.formations_formationfullnameid] = this.m_formationfullnameid;
      r.IntField[FI.formations_teamid] = this.m_Team == null ? -1 : this.m_Team.Id;
      if (FI.formations_relativeformationid >= 0)
        r.IntField[FI.formations_relativeformationid] = this.m_relativeformationid;
      if (FI.formations_issweeper >= 0)
        r.IntField[FI.formations_issweeper] = this.m_formations_issweeper;
      r.IntField[FI.formations_offensiverating] = this.m_offensiverating;
      r.FloatField[FI.formations_defenders] = this.m_defenders;
      r.FloatField[FI.formations_midfielders] = this.m_midfielders;
      r.FloatField[FI.formations_attackers] = this.m_attackers;
      r.IntField[FI.formations_attackingrole_0] = 3;
      r.IntField[FI.formations_attackingrole_1] = 3;
      r.IntField[FI.formations_attackingrole_2] = 3;
      r.IntField[FI.formations_attackingrole_3] = 3;
      r.IntField[FI.formations_attackingrole_4] = 3;
      r.IntField[FI.formations_attackingrole_5] = 3;
      r.IntField[FI.formations_attackingrole_6] = 3;
      r.IntField[FI.formations_attackingrole_7] = 3;
      r.IntField[FI.formations_attackingrole_8] = 3;
      r.IntField[FI.formations_attackingrole_9] = 3;
      r.IntField[FI.formations_attackingrole_10] = 3;
      r.IntField[FI.formations_defensiverole_0] = 3;
      r.IntField[FI.formations_defensiverole_1] = 3;
      r.IntField[FI.formations_defensiverole_2] = 3;
      r.IntField[FI.formations_defensiverole_3] = 3;
      r.IntField[FI.formations_defensiverole_4] = 3;
      r.IntField[FI.formations_defensiverole_5] = 3;
      r.IntField[FI.formations_defensiverole_6] = 3;
      r.IntField[FI.formations_defensiverole_7] = 3;
      r.IntField[FI.formations_defensiverole_8] = 3;
      r.IntField[FI.formations_defensiverole_9] = 3;
      r.IntField[FI.formations_defensiverole_10] = 3;
      for (int i = 0; i < 11; ++i)
        this.m_PlayingRoles[i].Save(r, i);
      this.SaveLanguage();
    }

    public void SaveLanguage()
    {
      if (this.m_formationfullnameid == -1 || FifaEnvironment.Language == null)
        return;
      FifaEnvironment.Language.SetFormationString(this.m_formationfullnameid, this.m_formationfullname);
    }

    public static string RoleToString(ERole role)
    {
      return FifaEnvironment.Language != null ? FifaEnvironment.Language.GetRoleLongString((int) role) : string.Empty;
    }

    public int ComputeDistance(Formation formation)
    {
      int num = 0;
      for (int index = 0; index < 11; ++index)
        num += Math.Abs(this.m_PlayingRoles[index].Role.RoleId - formation.PlayingRoles[index].Role.RoleId);
      return num;
    }

    public int ComputeSimilarity(Formation formation)
    {
      int num = 0;
      int[] numArray = new int[11];
      bool[] flagArray = new bool[11];
      for (int index = 0; index < 11; ++index)
      {
        numArray[index] = 1;
        flagArray[index] = false;
      }
      for (int index1 = 0; index1 < 11; ++index1)
      {
        numArray[index1] = 1;
        for (int index2 = 0; index2 < 11; ++index2)
        {
          if (this.m_PlayingRoles[index1].Role.RoleId == formation.PlayingRoles[index2].Role.RoleId)
          {
            numArray[index1] = 0;
            flagArray[index2] = true;
            break;
          }
        }
      }
      for (int index1 = 0; index1 < 11; ++index1)
      {
        if (numArray[index1] != 0)
        {
          for (int index2 = 0; index2 < 11; ++index2)
          {
            if (!flagArray[index2])
            {
              flagArray[index2] = true;
              num += Math.Abs(this.m_PlayingRoles[index1].Role.RoleId - formation.PlayingRoles[index2].Role.RoleId);
            }
          }
        }
      }
      return num;
    }

    public void LinkTeam(Team team)
    {
      if (team == null || this.Id > 800)
        return;
      this.m_Team = team;
      this.Name = team.TeamNameFull;
    }

    public void LinkRoles(RoleList roleList)
    {
      for (int index = 0; index < 11; ++index)
        this.m_PlayingRoles[index].LinkRole(roleList);
    }

    public bool IsRoleUsed(ERole eRole)
    {
      for (int index = 0; index < 11; ++index)
      {
        if (this.m_PlayingRoles[index].Role.RoleId == eRole)
          return true;
      }
      return false;
    }
  }
}
