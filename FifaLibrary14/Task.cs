// Original code created by Rinaldo

using System.IO;

namespace FifaLibrary
{
  public class Task
  {
    private string m_When;
    private string m_Action;
    private EQualifyingRule m_Rule;
    private int m_TargetCompObjId;
    private int m_Parameter1;
    private int m_Parameter2;
    private int m_Parameter3;
    private Group m_Group;
    private Stage m_Stage;
    private Trophy m_Trophy;
    private Trophy m_Trophy1;
    private Trophy m_Trophy2;
    private League m_League;
    private Team m_Team;

    public string When
    {
      get
      {
        return this.m_When;
      }
      set
      {
        this.m_When = value;
      }
    }

    public string Action
    {
      get
      {
        return this.m_Action;
      }
      set
      {
        this.m_Action = value;
      }
    }

    public EQualifyingRule Rule
    {
      get
      {
        return this.m_Rule;
      }
      set
      {
        this.m_Rule = value;
        this.m_Action = this.m_Rule.ToString();
      }
    }

    public int GroupId
    {
      get
      {
        return this.m_TargetCompObjId;
      }
    }

    public int Parameter1
    {
      get
      {
        return this.m_Parameter1;
      }
      set
      {
        this.m_Parameter1 = value;
      }
    }

    public int Parameter2
    {
      get
      {
        return this.m_Parameter2;
      }
      set
      {
        this.m_Parameter2 = value;
      }
    }

    public int Parameter3
    {
      get
      {
        return this.m_Parameter3;
      }
      set
      {
        this.m_Parameter3 = value;
      }
    }

    public Group Group
    {
      get
      {
        return this.m_Group;
      }
      set
      {
        this.m_Group = value;
        this.m_TargetCompObjId = this.m_Group.Id;
      }
    }

    public Stage Stage
    {
      get
      {
        return this.m_Stage;
      }
      set
      {
        this.m_Stage = value;
        this.m_TargetCompObjId = this.m_Stage.Id;
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
        this.m_TargetCompObjId = this.m_Trophy.Id;
      }
    }

    public Trophy Trophy1
    {
      get
      {
        return this.m_Trophy1;
      }
      set
      {
        this.m_Trophy1 = value;
      }
    }

    public Trophy Trophy2
    {
      get
      {
        return this.m_Trophy2;
      }
      set
      {
        this.m_Trophy2 = value;
      }
    }

    public League League
    {
      get
      {
        return this.m_League;
      }
      set
      {
        this.m_League = value;
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

    public Task(string when, string action, int targetCompObjId, int par1, int par2, int par3)
    {
      this.m_When = when;
      this.m_Action = action;
      this.m_TargetCompObjId = targetCompObjId;
      this.m_Parameter1 = par1;
      this.m_Parameter2 = par2;
      this.m_Parameter3 = par3;
    }

    public Task(Task currentTask)
    {
      this.m_When = currentTask.m_When;
      this.m_Action = currentTask.m_Action;
      this.m_TargetCompObjId = currentTask.m_TargetCompObjId;
      this.m_Parameter1 = currentTask.m_Parameter1;
      this.m_Parameter2 = currentTask.m_Parameter2;
      this.m_Parameter3 = currentTask.m_Parameter3;
    }

    public void LinkCompetitions(Compobj ownerCompobj)
    {
      if (ownerCompobj.IsGroup())
        this.LinkGroup((Group) ownerCompobj);
      else if (ownerCompobj.IsStage())
      {
        this.LinkStage((Stage) ownerCompobj);
      }
      else
      {
        if (!ownerCompobj.IsTrophy())
          return;
        this.LinkTrophy((Trophy) ownerCompobj);
      }
    }

    public void LinkGroup(Group ownerGroup)
    {
      this.m_Group = ownerGroup;
      this.m_TargetCompObjId = ownerGroup.Id;
      if (this.m_Action == "FillFromCompTable")
      {
        this.m_Rule = EQualifyingRule.FillFromCompTable;
        Compobj compobj = (Compobj) FifaEnvironment.CompetitionObjects.SearchId(this.m_Parameter1);
        this.m_Trophy1 = compobj == null || !compobj.IsTrophy() ? (Trophy) null : (Trophy) compobj;
        this.m_Trophy2 = (Trophy) null;
        this.m_League = (League) null;
        this.m_Team = (Team) null;
      }
      else if (this.m_Action == "FillFromCompTableBackup")
      {
        this.m_Rule = EQualifyingRule.FillFromCompTableBackup;
        Compobj compobj1 = (Compobj) FifaEnvironment.CompetitionObjects.SearchId(this.m_Parameter1);
        this.m_Trophy1 = compobj1 == null || !compobj1.IsTrophy() ? (Trophy) null : (Trophy) compobj1;
        Compobj compobj2 = (Compobj) FifaEnvironment.CompetitionObjects.SearchId(this.m_Parameter2);
        this.m_Trophy2 = compobj2 == null || !compobj2.IsTrophy() ? (Trophy) null : (Trophy) compobj2;
        this.m_League = (League) null;
        this.m_Team = (Team) null;
      }
      else if (this.m_Action == "FillFromCompTableBackupLeague")
      {
        this.m_Rule = EQualifyingRule.FillFromCompTableBackupLeague;
        Compobj compobj = (Compobj) FifaEnvironment.CompetitionObjects.SearchId(this.m_Parameter1);
        if (compobj != null && compobj.IsTrophy())
          this.m_Trophy1 = (Trophy) compobj;
        this.m_Trophy2 = (Trophy) null;
        this.m_League = (League) FifaEnvironment.Leagues.SearchId(this.m_Parameter2);
        this.m_Team = (Team) null;
      }
      else if (this.m_Action == "FillFromLeague")
      {
        this.m_Rule = EQualifyingRule.FillFromLeague;
        this.m_Trophy1 = (Trophy) null;
        this.m_Trophy2 = (Trophy) null;
        this.m_League = (League) FifaEnvironment.Leagues.SearchId(this.m_Parameter1);
        this.m_Team = (Team) null;
      }
      else if (this.m_Action == "FillFromLeagueMaxFromCountry")
      {
        this.m_Rule = EQualifyingRule.FillFromLeagueMaxFromCountry;
        this.m_Trophy1 = (Trophy) null;
        this.m_Trophy2 = (Trophy) null;
        this.m_League = (League) FifaEnvironment.Leagues.SearchId(this.m_Parameter1);
        this.m_Team = (Team) null;
      }
      else if (this.m_Action == "FillChampionsCup")
      {
        this.m_Rule = EQualifyingRule.FillChampionsCup;
        this.m_Trophy1 = (Trophy) null;
        this.m_Trophy2 = (Trophy) null;
        this.m_League = (League) FifaEnvironment.Leagues.SearchId(this.m_Parameter1);
        this.m_Team = (Team) null;
      }
      else if (this.m_Action == "FillFromSpecialTeams")
      {
        this.m_Rule = EQualifyingRule.FillFromSpecialTeams;
        this.m_Trophy1 = (Trophy) null;
        this.m_Trophy2 = (Trophy) null;
        this.m_League = (League) null;
        this.m_Team = (Team) null;
      }
      else if (this.m_Action == "FillEuroLeagueWinnerPlayoff")
      {
        this.m_Rule = EQualifyingRule.FillEuroLeagueWinnerPlayoff;
        this.m_Trophy1 = (Trophy) null;
        this.m_Trophy2 = (Trophy) null;
        this.m_League = (League) null;
        this.m_Team = (Team) null;
      }
      else if (this.m_Action == "FillEuroLeagueWinnerGroupStage")
      {
        this.m_Rule = EQualifyingRule.FillEuroLeagueWinnerGroupStage;
        this.m_Trophy1 = (Trophy) null;
        this.m_Trophy2 = (Trophy) null;
        this.m_League = (League) null;
        this.m_Team = (Team) null;
      }
      else if (this.m_Action == "FillWithTeam")
      {
        this.m_Rule = EQualifyingRule.FillWithTeam;
        this.m_Trophy1 = (Trophy) null;
        this.m_Trophy2 = (Trophy) null;
        this.m_League = (League) null;
        this.m_Team = (Team) FifaEnvironment.Teams.SearchId(this.m_Parameter2);
      }
      else
      {
        if (!(this.m_Action == "FillFromLeagueInOrder"))
          return;
        this.m_Rule = EQualifyingRule.FillFromLeagueInOrder;
        this.m_Trophy1 = (Trophy) null;
        this.m_Trophy2 = (Trophy) null;
        this.m_League = (League) FifaEnvironment.Leagues.SearchId(this.m_Parameter1);
        this.m_Team = (Team) null;
      }
    }

    public void LinkStage(Stage ownerStage)
    {
      this.m_Stage = ownerStage;
      this.m_TargetCompObjId = ownerStage.Id;
      if (this.m_Action == "UpdateLeagueTable")
      {
        this.m_Rule = EQualifyingRule.NoRule;
        this.m_Trophy1 = (Trophy) null;
        this.m_Trophy2 = (Trophy) null;
        this.m_League = (League) FifaEnvironment.Leagues.SearchId(this.m_Parameter1);
        this.m_Team = (Team) null;
      }
      else if (this.m_Action == "UpdateLeagueStats")
      {
        this.m_Rule = EQualifyingRule.NoRule;
        this.m_Trophy1 = (Trophy) null;
        this.m_Trophy2 = (Trophy) null;
        this.m_League = (League) FifaEnvironment.Leagues.SearchId(this.m_Parameter1);
        this.m_Team = (Team) null;
      }
      else
      {
        if (!(this.m_Action == "ClearLeagueStats"))
          return;
        this.m_Rule = EQualifyingRule.NoRule;
        this.m_Trophy1 = (Trophy) null;
        this.m_Trophy2 = (Trophy) null;
        this.m_League = (League) FifaEnvironment.Leagues.SearchId(this.m_Parameter1);
        this.m_Team = (Team) null;
      }
    }

    public void LinkTrophy(Trophy ownerTrophy)
    {
      this.m_Trophy = ownerTrophy;
      this.m_TargetCompObjId = ownerTrophy.Id;
      if (!(this.m_Action == "UpdateTable"))
        return;
      this.m_Rule = EQualifyingRule.NoRule;
      this.m_Trophy1 = (Trophy) null;
      this.m_Trophy2 = (Trophy) null;
      this.m_League = (League) null;
      this.m_Team = (Team) null;
      Compobj compobj = (Compobj) FifaEnvironment.CompetitionObjects.SearchId(this.m_Parameter1);
      if (compobj == null || !compobj.IsGroup())
        return;
      this.m_Group = (Group) FifaEnvironment.CompetitionObjects.SearchId(this.m_Parameter1);
    }

    public override string ToString()
    {
      string str = "To be defined";
      if (this.m_Action == "UpdateTable")
      {
        if (this.m_Group != null)
          str = "Team n." + this.m_Parameter2.ToString() + " of " + this.m_Group.ParentStage.ToString() + " - " + this.m_Group.ToString();
      }
      else if (this.m_Action == "ClearLeagueStats")
      {
        if (this.m_League != null)
          str = "Clear Stats of league: " + this.m_League.ToString();
      }
      else if (this.m_Action == "UpdateLeagueTable")
      {
        if (this.m_League != null)
          str = "Update Table of league: " + this.m_League.ToString();
      }
      else if (this.m_Action == "UpdateLeagueStats")
      {
        if (this.m_League != null)
          str = "Update Stats of league: " + this.m_League.ToString();
      }
      else
      {
        switch (this.m_Rule)
        {
          case EQualifyingRule.FillFromLeague:
            if (this.m_League != null)
            {
              str = "Get teams from league: " + this.m_League.ToString();
              this.m_Parameter1 = this.m_League.Id;
              break;
            }
            break;
          case EQualifyingRule.FillFromLeagueInOrder:
            if (this.m_League != null)
            {
              str = "Get teams in order from league: " + this.m_League.ToString();
              this.m_Parameter1 = this.m_League.Id;
              break;
            }
            break;
          case EQualifyingRule.FillFromCompTable:
            if (this.m_Trophy1 != null)
            {
              str = this.m_Parameter2 != 1 ? "Get best " + this.m_Parameter2.ToString() + " teams of " + this.m_Trophy1.ToString() : "Get winner of " + this.m_Trophy1.ToString();
              this.m_Parameter1 = this.m_Trophy1.Id;
              break;
            }
            break;
          case EQualifyingRule.FillFromCompTableBackup:
            if (this.m_Trophy1 != null && this.m_Trophy2 != null)
            {
              str = "Get winner of " + this.m_Trophy1.ToString() + " or a team from " + this.m_Trophy2.ToString();
              this.m_Parameter1 = this.m_Trophy1.Id;
              this.m_Parameter2 = this.m_Trophy2.Id;
              break;
            }
            break;
          case EQualifyingRule.FillFromCompTableBackupLeague:
            if (this.m_Trophy1 != null && this.m_League != null)
            {
              str = "Get winner of " + this.m_Trophy1.ToString() + " or a team from league: " + this.m_League.ToString();
              this.m_Parameter1 = this.m_Trophy1.Id;
              this.m_Parameter2 = this.m_League.Id;
              break;
            }
            break;
          case EQualifyingRule.FillFromLeagueMaxFromCountry:
            if (this.m_League != null)
            {
              str = "Get up to " + this.m_Parameter2.ToString() + " team(s) from league: " + this.m_League.ToString() + " (max " + this.m_Parameter3.ToString() + ")";
              this.m_Parameter1 = this.m_League.Id;
              break;
            }
            break;
          case EQualifyingRule.FillChampionsCup:
            if (this.m_League != null)
            {
              str = "Get up to " + this.m_Parameter2.ToString() + " team(s) from league: " + this.m_League.ToString() + " (max " + this.m_Parameter3.ToString() + ") for Champions Cup";
              this.m_Parameter1 = this.m_League.Id;
              break;
            }
            break;
          case EQualifyingRule.FillFromSpecialTeams:
            str = "Get " + this.m_Parameter1.ToString() + " team(s) from Special Teams Group";
            break;
          case EQualifyingRule.FillEuroLeagueWinnerGroupStage:
            str = "Get winner of Euro League Group Stage";
            break;
          case EQualifyingRule.FillEuroLeagueWinnerPlayoff:
            str = "Get winner of Euro League Playoff";
            break;
          case EQualifyingRule.FillWithTeam:
            if (this.m_Team != null)
            {
              str = "Get Specific Team: " + this.m_Team.ToString();
              if (this.m_Parameter1 != 0)
                str = str + " at position " + this.m_Parameter1.ToString();
              this.m_Parameter2 = this.m_Team.Id;
              break;
            }
            break;
        }
      }
      return str;
    }

    public bool SaveToTasks(StreamWriter w)
    {
      if (w == null)
        return false;
      string str = (string) null;
      if (this.m_When == "start")
      {
        if (this.m_Group != null)
          str = this.m_Group.ParentTrophy.Id.ToString() + ",start," + this.m_Action + "," + this.m_Group.Id.ToString() + ",";
        else if (this.m_Stage != null)
          str = this.m_Stage.Trophy.Id.ToString() + ",start," + this.m_Action + "," + this.m_Stage.Id.ToString() + ",";
        if (this.m_Action == "FillFromCompTable")
          str = str + (this.m_Trophy1 != null ? this.m_Trophy1.Id.ToString() : this.m_Parameter1.ToString()) + "," + this.m_Parameter2.ToString() + "," + this.m_Parameter3.ToString();
        else if (this.m_Action == "FillFromCompTableBackup")
          str = str + (this.m_Trophy1 != null ? this.m_Trophy1.Id.ToString() : this.m_Parameter1.ToString()) + "," + (this.m_Trophy2 != null ? this.m_Trophy2.Id.ToString() : this.m_Parameter2.ToString()) + "," + this.m_Parameter3.ToString();
        else if (this.m_Action == "FillFromCompTableBackupLeague")
          str = str + (this.m_Trophy1 != null ? this.m_Trophy1.Id.ToString() : this.m_Parameter1.ToString()) + "," + (this.m_League != null ? this.m_League.Id.ToString() : this.m_Parameter2.ToString()) + "," + this.m_Parameter3.ToString();
        else if (this.m_Action == "FillFromLeague")
          str = str + (this.m_League != null ? this.m_League.Id.ToString() : this.m_Parameter1.ToString()) + "," + this.m_Parameter2.ToString() + "," + this.m_Parameter3.ToString();
        else if (this.m_Action == "FillFromLeagueMaxFromCountry" || this.m_Action == "FillChampionsCup")
          str = str + (this.m_League != null ? this.m_League.Id.ToString() : this.m_Parameter1.ToString()) + "," + this.m_Parameter2.ToString() + "," + this.m_Parameter3.ToString();
        else if (this.m_Action == "FillFromSpecialTeams")
          str = str + this.m_Parameter1.ToString() + "," + this.m_Parameter2.ToString() + "," + this.m_Parameter3.ToString();
        else if (this.m_Action == "FillEuroLeagueWinnerPlayoff" || this.m_Action == "FillEuroLeagueWinnerGroupStage")
          str = str + this.m_Parameter1.ToString() + "," + this.m_Parameter2.ToString() + "," + this.m_Parameter3.ToString();
        else if (this.m_Action == "FillWithTeam")
          str = str + this.m_Parameter1.ToString() + "," + (this.m_Team != null ? this.m_Team.Id.ToString() : this.m_Parameter2.ToString()) + "," + this.m_Parameter3.ToString();
        else if (this.m_Action == "FillFromLeagueInOrder")
          str = str + (this.m_League != null ? this.m_League.Id.ToString() : this.m_Parameter1.ToString()) + "," + this.m_Parameter2.ToString() + "," + this.m_Parameter3.ToString();
        else if (this.m_Action == "ClearLeagueStats")
          str = str + (this.m_League != null ? this.m_League.Id.ToString() : this.m_Parameter1.ToString()) + "," + this.m_Parameter2.ToString() + "," + this.m_Parameter3.ToString();
      }
      else if (this.m_Action == "UpdateTable")
      {
        if (this.m_Trophy != null && this.m_Group != null)
        {
          str = this.m_Trophy.Id.ToString() + ",end," + this.m_Action + "," + this.m_Trophy.Id.ToString() + "," + this.m_Group.Id.ToString() + "," + this.m_Parameter2.ToString() + "," + this.m_Parameter3.ToString();
        }
        else
        {
          int num1 = (int) FifaEnvironment.UserMessages.ShowMessage(14999, "Debug Trap: Task::SaveToTasks()");
        }
      }
      else if (this.m_Action == "UpdateLeagueTable")
      {
        if (this.m_Stage != null)
        {
          if (this.m_League != null)
            str = this.m_Stage.Trophy.Id.ToString() + ",end," + this.m_Action + "," + this.m_Stage.Id.ToString() + "," + this.m_League.Id.ToString() + "," + this.m_Parameter2.ToString() + "," + this.m_Parameter3.ToString();
          else
            str = this.m_Stage.Trophy.Id.ToString() + ",end," + this.m_Action + "," + this.m_Stage.Id.ToString() + "," + this.m_Parameter1.ToString() + "," + this.m_Parameter2.ToString() + "," + this.m_Parameter3.ToString();
        }
        else if (this.m_Group != null && this.m_League != null)
        {
          str = this.m_Group.ParentTrophy.Id.ToString() + ",end," + this.m_Action + "," + this.m_Group.ParentStage.Id.ToString() + "," + this.m_League.Id.ToString() + "," + this.m_Parameter2.ToString() + "," + this.m_Parameter3.ToString();
        }
        else
        {
          int num2 = (int) FifaEnvironment.UserMessages.ShowMessage(14999, "Debug Trap: Task::SaveToTasks()");
        }
      }
      else if (this.m_Action == "UpdateLeagueStats")
      {
        if (this.m_Stage != null && this.m_League != null)
        {
          str = this.m_Stage.Trophy.Id.ToString() + ",end," + this.m_Action + "," + this.m_Stage.Id.ToString() + "," + this.m_League.Id.ToString() + "," + this.m_Parameter2.ToString() + "," + this.m_Parameter3.ToString();
        }
        else
        {
          int num3 = (int) FifaEnvironment.UserMessages.ShowMessage(14999, "Debug Trap: Task::SaveToTasks()");
        }
      }
      else
      {
        int num4 = (int) FifaEnvironment.UserMessages.ShowMessage(14999, "Debug Trap: Task::SaveToTasks()");
      }
      w.WriteLine(str);
      return true;
    }

    public Task CopyTask(Compobj newTargetObj, League targetLeague)
    {
      Task task = new Task(this);
      task.m_TargetCompObjId = newTargetObj.Id;
      if (!(this.m_Action == "FillFromCompTable") && !(this.m_Action == "FillFromCompTableBackup"))
      {
        if (this.m_Action == "FillFromCompTableBackupLeague")
        {
          if (targetLeague != null)
            task.Parameter2 = targetLeague.Id;
        }
        else if (this.m_Action == "FillFromLeague")
        {
          if (targetLeague != null)
            task.Parameter1 = targetLeague.Id;
        }
        else if (this.m_Action == "FillFromLeagueMaxFromCountry" || this.m_Action == "FillChampionsCup")
        {
          if (targetLeague != null)
            task.Parameter1 = targetLeague.Id;
        }
        else if (!(this.m_Action == "FillFromSpecialTeams") && !(this.m_Action == "FillWithTeam") && !(this.m_Action == "FillEuroLeagueWinnerPlayoff") && !(this.m_Action == "FillEuroLeagueWinnerGroupStage"))
        {
          if (this.m_Action == "FillFromLeagueInOrder")
          {
            if (targetLeague != null)
              task.Parameter1 = targetLeague.Id;
          }
          else if (this.m_Action == "UpdateLeagueTable")
          {
            if (targetLeague != null)
              task.Parameter1 = targetLeague.Id;
          }
          else if (this.m_Action == "UpdateLeagueStats")
          {
            if (targetLeague != null)
              task.Parameter1 = targetLeague.Id;
          }
          else if (this.m_Action == "ClearLeagueStats")
          {
            if (targetLeague != null)
              task.Parameter1 = targetLeague.Id;
          }
          else if (this.m_Action == "UpdateTable")
            task.Parameter1 = this.Parameter1 + task.m_TargetCompObjId - this.m_TargetCompObjId;
        }
      }
      if (newTargetObj.IsTrophy())
        task.LinkTrophy((Trophy) newTargetObj);
      else if (newTargetObj.IsStage())
        task.LinkStage((Stage) newTargetObj);
      else if (newTargetObj.IsGroup())
        task.LinkGroup((Group) newTargetObj);
      return task;
    }
  }
}
