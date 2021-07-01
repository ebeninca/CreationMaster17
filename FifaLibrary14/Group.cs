// Original code created by Rinaldo

using System.IO;

namespace FifaLibrary
{
  public class Group : Compobj
  {
    private GroupList m_SubGroups;
    private ScheduleArray m_Schedule;
    private int m_NSchedule;
    private RankList m_Ranks;
    private string m_ConventionalDescription;
    private string m_LanguageName;
    public Task[] m_StartTask;
    public int m_NStartTasks;
    public Task[] m_EndTask;
    public int m_NEndTasks;

    public override string ToString()
    {
      if (this.m_LanguageName != null && this.m_LanguageName != string.Empty)
        return this.m_LanguageName;
      return this.Description != null && this.Description != string.Empty && this.Description != " " ? (this.Description.StartsWith("FCE_") ? this.Description.Substring(4).Replace('_', ' ') : this.Description.Replace('_', ' ')) : this.TypeString;
    }

    public Stage ParentStage
    {
      get
      {
        if (this.ParentObj.IsStage())
          return (Stage) this.ParentObj;
        return this.ParentObj.IsGroup() && this.ParentObj.ParentObj.IsStage() ? (Stage) this.ParentObj.ParentObj : (Stage) null;
      }
    }

    public Trophy ParentTrophy
    {
      get
      {
        return this.ParentStage.ParentObj.IsTrophy() ? (Trophy) this.ParentStage.ParentObj : (Trophy) null;
      }
    }

    public GroupList SubGroups
    {
      get
      {
        return this.m_SubGroups;
      }
    }

    public ScheduleArray Schedules
    {
      get
      {
        return this.m_Schedule;
      }
      set
      {
        this.m_Schedule = value;
      }
    }

    public int NSchedule
    {
      get
      {
        return this.m_Schedule.Count;
      }
    }

    public RankList Ranks
    {
      get
      {
        return this.m_Ranks;
      }
    }

    public string LanguageName
    {
      get
      {
        return this.m_LanguageName;
      }
      set
      {
        this.m_LanguageName = value;
      }
    }

    public Group(int id, string typeString, string description, Compobj parentObj)
      : base(id, 5, typeString, description, parentObj)
    {
      this.m_ConventionalDescription = description;
      this.m_Ranks = new RankList();
      this.m_Ranks.Add((object) new Rank(this, 0));
      this.m_Groups = new GroupList();
    }

    public void AddSchedule(Schedule schedule)
    {
      if (this.m_Schedule == null)
      {
        this.m_Schedule = new ScheduleArray(256);
        this.m_NSchedule = 0;
      }
      this.m_Schedule.AddSchedule(schedule);
    }

    public Schedule[] GetLegSchedule(int legId)
    {
      return this.m_Schedule == null ? (Schedule[]) null : this.m_Schedule.GetLegSchedule(legId);
    }

    public Schedule[] GetLastLegSchedule()
    {
      return this.m_Schedule == null ? (Schedule[]) null : this.m_Schedule.GetLastLegSchedule();
    }

    public bool RemoveLastLeg()
    {
      return this.m_Schedule != null && this.m_Schedule.RemoveLastLeg();
    }

    public Schedule AppendLeg(int dayDelay)
    {
      if (this.m_Schedule == null)
        this.m_Schedule = new ScheduleArray(8);
      return this.m_Schedule.AppendLeg((Compobj) this, dayDelay);
    }

    public void CloneSchedule(Schedule originalSchedule, int timeDelay)
    {
      if (this.m_Schedule == null)
        return;
      this.m_Schedule.CloneSchedule(originalSchedule, timeDelay);
    }

    public void DeleteSchedule(Schedule originalSchedule)
    {
      if (this.m_Schedule == null)
        return;
      this.m_Schedule.DeleteSchedule(originalSchedule);
    }

    public override bool SaveToStandings(StreamWriter w)
    {
      for (int index = 1; index < this.m_Ranks.Count; ++index)
      {
        string str = this.Id.ToString() + "," + (((IdObject) this.m_Ranks[index]).Id - 1).ToString();
        w.WriteLine(str);
      }
      return true;
    }

    public override bool SaveToAdvancement(StreamWriter w)
    {
      for (int index = 1; index < this.m_Ranks.Count; ++index)
      {
        Rank rank = (Rank) this.m_Ranks[index];
        if (rank.MoveFrom != null)
        {
          string str = rank.MoveFrom.Group.Id.ToString() + "," + rank.MoveFrom.Id.ToString() + "," + this.Id.ToString() + "," + rank.Id.ToString();
          w.WriteLine(str);
        }
      }
      return true;
    }

    public override bool SaveToSchedule(StreamWriter w)
    {
      return this.m_Schedule != null && this.m_Schedule.SaveToSchedule(w);
    }

    public override void LinkCompetitions()
    {
      for (int index = 0; index < this.m_NStartTasks; ++index)
        this.m_StartTask[index].LinkGroup(this);
      for (int index = 0; index < this.m_NEndTasks; ++index)
        this.m_EndTask[index].LinkGroup(this);
    }

    public override bool SaveToTasks(StreamWriter w)
    {
      if (w == null || this.ParentTrophy == null)
        return false;
      for (int index = 0; index < this.m_NStartTasks; ++index)
        this.m_StartTask[index].SaveToTasks(w);
      for (int index = 0; index < this.m_NEndTasks; ++index)
        this.m_EndTask[index].SaveToTasks(w);
      return true;
    }

    public override bool FillFromLanguage()
    {
      if (FifaEnvironment.Language != null)
      {
        if (this.m_ConventionalDescription != null && this.m_ConventionalDescription != string.Empty && this.m_ConventionalDescription != " ")
        {
          this.m_LanguageName = FifaEnvironment.Language.GetString(this.m_ConventionalDescription);
          if (this.m_LanguageName == null)
            this.m_LanguageName = this.m_ConventionalDescription;
        }
      }
      else
        this.m_LanguageName = string.Empty;
      return true;
    }

    public override bool SaveToLanguage()
    {
      if (FifaEnvironment.Language == null)
        return false;
      FifaEnvironment.Language.SetString(this.m_ConventionalDescription, this.m_LanguageName);
      return true;
    }

    public bool AddRank()
    {
      Rank rank = new Rank(this, this.m_Ranks.Count);
      if (rank == null)
        return false;
      this.m_Ranks.Add((object) rank);
      return true;
    }

    public bool RemoveRank()
    {
      if (this.m_Ranks.Count < 1)
        return false;
      this.m_Ranks.Remove((object) (Rank) this.m_Ranks[this.m_Ranks.Count - 1]);
      return true;
    }

    public bool RemoveAllRanks()
    {
      int count = this.m_Ranks.Count;
      for (int index = 0; index < count; ++index)
        this.RemoveRank();
      return true;
    }

    public override void Normalize()
    {
      Stage stage = (Stage) null;
      if (this.Settings.Advance_pointskeep != -1)
      {
        if (this.ParentObj.IsStage())
          stage = (Stage) this.ParentObj;
        if (stage.Settings.Advance_pointskeep == -1)
          stage.Settings.Advance_pointskeep = this.Settings.Advance_pointskeep;
        this.Settings.Advance_pointskeep = -1;
      }
      if (this.Settings.m_advance_pointskeeppercentage != -1)
      {
        if (this.ParentObj.IsStage())
          stage = (Stage) this.ParentObj;
        if (stage.Settings.m_advance_pointskeeppercentage == -1)
          stage.Settings.m_advance_pointskeeppercentage = this.Settings.m_advance_pointskeeppercentage;
        this.Settings.m_advance_pointskeeppercentage = -1;
      }
      if (this.Settings.Advance_standingsrank != -1)
      {
        if (this.ParentObj.IsStage())
          stage = (Stage) this.ParentObj;
        if (stage.Settings.Advance_standingsrank == -1)
          stage.Settings.Advance_standingsrank = this.Settings.Advance_standingsrank;
        this.Settings.Advance_standingsrank = -1;
      }
      if (this.Settings.m_info_prize_money != -1)
      {
        if (this.ParentObj.IsStage())
          stage = (Stage) this.ParentObj;
        if (stage.Settings.m_info_prize_money == -1)
          stage.Settings.m_info_prize_money = this.Settings.m_info_prize_money;
        this.Settings.m_info_prize_money = -1;
      }
      if (this.Settings.m_match_stadium != null && this.Settings.m_match_stadium.Length > 0)
      {
        if (this.ParentObj.IsStage())
          stage = (Stage) this.ParentObj;
        if (stage.Settings.m_match_stadium == null || stage.Settings.m_match_stadium.Length == 0)
        {
          stage.Settings.m_match_stadium = new int[12];
          for (int index = 0; index < stage.Settings.m_match_stadium.Length; ++index)
            stage.Settings.m_match_stadium[index] = -1;
          for (int index = 0; index < this.Settings.m_match_stadium.Length; ++index)
            stage.Settings.m_match_stadium[index] = this.Settings.m_match_stadium[index];
        }
        for (int index = 0; index < this.Settings.m_match_stadium.Length; ++index)
          this.Settings.m_match_stadium[index] = -1;
      }
      if (this.Settings.m_StandingsSort != -1)
      {
        if (this.ParentObj.IsStage())
          stage = (Stage) this.ParentObj;
        if (stage.Settings.m_StandingsSort == -1)
          stage.Settings.m_StandingsSort = this.Settings.m_StandingsSort;
        this.Settings.m_StandingsSort = -1;
      }
      if (!this.ParentObj.IsStage())
        return;
      Stage parentObj = (Stage) this.ParentObj;
      for (int index = 0; index < this.m_NEndTasks; ++index)
      {
        if (this.m_EndTask[index].Action == "UpdateLeagueTable")
        {
          parentObj.AddTask(this.m_EndTask[index]);
          this.RemoveTask(this.m_EndTask[index].When, index);
          break;
        }
      }
    }

    public bool RemoveAllSchedules()
    {
      if (this.m_Schedule == null)
        return false;
      this.m_Schedule.Clear();
      return true;
    }

    public bool AddTask(Task action)
    {
      if (action.When == "start")
      {
        if (this.m_NStartTasks == 0)
          this.m_StartTask = new Task[32];
        if (this.m_NStartTasks >= this.m_StartTask.Length)
          return false;
        this.m_StartTask[this.m_NStartTasks] = action;
        ++this.m_NStartTasks;
        return true;
      }
      if (!(action.When == "end"))
        return false;
      if (this.m_NEndTasks == 0)
        this.m_EndTask = new Task[24];
      if (this.m_NEndTasks >= this.m_EndTask.Length)
        return false;
      this.m_EndTask[this.m_NEndTasks] = action;
      ++this.m_NEndTasks;
      return true;
    }

    public bool RemoveLastTask(string when)
    {
      if (when == "start")
      {
        if (this.m_NStartTasks <= 0)
          return false;
        --this.m_NStartTasks;
        this.m_StartTask[this.m_NStartTasks] = (Task) null;
        return true;
      }
      if (!(when == "end") || this.m_NEndTasks <= 0)
        return false;
      --this.m_NEndTasks;
      this.m_EndTask[this.m_NEndTasks] = (Task) null;
      return true;
    }

    public int SearchTaskIndex(string when, string action, int par1, int par2, int par3)
    {
      if (when == "start")
      {
        for (int index = 0; index < this.m_NStartTasks; ++index)
        {
          if ((action == null || this.m_StartTask[index].Action == action) && (par1 < 0 || this.m_StartTask[index].Parameter1 == par1) && ((par2 < 0 || this.m_StartTask[index].Parameter2 == par2) && (par3 < 0 || this.m_StartTask[index].Parameter3 == par3)))
            return index;
        }
      }
      else if (when == "end")
      {
        for (int index = 0; index < this.m_NEndTasks; ++index)
        {
          if ((action == null || this.m_EndTask[index].Action == action) && (par1 < 0 || this.m_EndTask[index].Parameter1 == par1) && ((par2 < 0 || this.m_EndTask[index].Parameter2 == par2) && (par3 < 0 || this.m_EndTask[index].Parameter3 == par3)))
            return index;
        }
      }
      return -1;
    }

    public Task SearchTask(string when, string action, int par1, int par2, int par3)
    {
      int index = this.SearchTaskIndex(when, action, par1, par2, par3);
      return index >= 0 ? this.GetTask(when, index) : (Task) null;
    }

    public bool RemoveTask(string when, int index)
    {
      if (when == "start")
      {
        if (index < this.m_NStartTasks)
        {
          --this.m_NStartTasks;
          for (int index1 = index; index1 < this.m_NStartTasks; ++index1)
            this.m_StartTask[index1] = this.m_StartTask[index1 + 1];
          return true;
        }
      }
      else if (index < this.m_NEndTasks)
      {
        --this.m_NEndTasks;
        for (int index1 = index; index1 < this.m_NEndTasks; ++index1)
          this.m_EndTask[index1] = this.m_EndTask[index1 + 1];
        return true;
      }
      return false;
    }

    public bool RemoveTask(string when, string action, int par1, int par2, int par3)
    {
      int index = this.SearchTaskIndex(when, action, par1, par2, par3);
      return index >= 0 && this.RemoveTask(when, index);
    }

    public bool ReplaceTask(Task task, int index)
    {
      if (task.When == "start")
      {
        if (index < this.m_NStartTasks)
        {
          this.m_StartTask[index] = task;
          return true;
        }
      }
      else if (index < this.m_NEndTasks)
      {
        this.m_EndTask[index] = task;
        return true;
      }
      return false;
    }

    public Task GetTask(string when, int index)
    {
      if (when == "start")
      {
        if (index < this.m_NStartTasks)
          return this.m_StartTask[index];
      }
      else if (index < this.m_NEndTasks)
        return this.m_EndTask[index];
      return (Task) null;
    }

    public void CopyTasks(Group newGroup, League targetLeague)
    {
      for (int index = 0; index < this.m_NStartTasks; ++index)
        newGroup.AddTask(this.m_StartTask[index].CopyTask((Compobj) newGroup, targetLeague));
      for (int index = 0; index < this.m_NEndTasks; ++index)
        newGroup.AddTask(this.m_EndTask[index].CopyTask((Compobj) newGroup, targetLeague));
    }
  }
}
