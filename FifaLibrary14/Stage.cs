// Original code created by Rinaldo

using System.Collections;
using System.IO;

namespace FifaLibrary
{
  public class Stage : Compobj
  {
    private ScheduleArray m_Schedule;
    private int m_NSchedule;
    private string m_ConventionalDescription;
    private Task[] m_StartTask;
    private int m_NStartTasks;
    private Task[] m_EndTask;
    private int m_NEndTasks;

    public override string ToString()
    {
      string languageName = this.GetLanguageName();
      if (languageName != null && languageName != string.Empty)
        return languageName;
      return this.Description != null && this.Description != string.Empty && this.Description != " " ? (this.Description.StartsWith("FCE_") ? this.Description.Substring(4).Replace('_', ' ') : this.Description.Replace('_', ' ')) : this.TypeString;
    }

    public Trophy Trophy
    {
      get
      {
        return this.ParentObj.TypeNumber == 3 ? (Trophy) this.ParentObj : (Trophy) null;
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

    public string ConventionalDescription
    {
      get
      {
        return this.m_ConventionalDescription;
      }
      set
      {
        this.m_ConventionalDescription = value;
      }
    }

    public Stage(int id, string typeString, string description, Compobj parentObj)
      : base(id, 4, typeString, description, parentObj)
    {
      this.m_Groups = new GroupList();
    }

    public override void LinkCompetitions()
    {
      this.Settings.UpdateStageReferenceUsingId();
      for (int index = 0; index < this.m_NStartTasks; ++index)
        this.m_StartTask[index].LinkStage(this);
      for (int index = 0; index < this.m_NEndTasks; ++index)
        this.m_EndTask[index].LinkStage(this);
    }

    public void AddSchedule(Schedule schedule)
    {
      if (this.m_Schedule == null)
        this.m_Schedule = new ScheduleArray(256);
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
        this.m_Schedule = new ScheduleArray(48);
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

    public override bool SaveToSchedule(StreamWriter w)
    {
      return this.m_Schedule != null && this.m_Schedule.SaveToSchedule(w);
    }

    public string GetLanguageName()
    {
      return FifaEnvironment.Language != null && this.Description != null ? FifaEnvironment.Language.GetString(this.Description) ?? string.Empty : string.Empty;
    }

    public bool SetLanguageName(string languageName)
    {
      if (FifaEnvironment.Language == null || this.Description == null)
        return false;
      FifaEnvironment.Language.SetString(this.Description, languageName);
      return true;
    }

    public bool InsertGroup(int groupIndex)
    {
      if (groupIndex > this.Groups.Count)
        return false;
      Group group = new Group(FifaEnvironment.CompetitionObjects.GetNewId(), "G" + (groupIndex + 1).ToString(), " ", (Compobj) this);
      if (group == null)
        return false;
      this.Groups.Insert(groupIndex, (object) group);
      FifaEnvironment.CompetitionObjects.Add((object) group);
      for (int index = 0; index < this.Groups.Count; ++index)
      {
        string str = "G" + (index + 1).ToString();
        ((Compobj) this.Groups[index]).TypeString = str;
      }
      return true;
    }

    public bool RemoveGroup(Group group)
    {
      int groupIndex = this.Groups.IndexOf((object) group);
      if (groupIndex < 0)
        return false;
      this.RemoveGroup(groupIndex);
      return true;
    }

    public bool RemoveGroup(int groupIndex)
    {
      if (groupIndex > this.Groups.Count)
        return false;
      Group group = (Group) this.Groups[groupIndex];
      this.Groups.RemoveAt(groupIndex);
      FifaEnvironment.CompetitionObjects.RemoveId((IdObject) group);
      for (int index = 0; index < this.Groups.Count; ++index)
      {
        string str = "G" + (index + 1).ToString();
        ((Compobj) this.Groups[index]).TypeString = str;
      }
      return true;
    }

    public bool RemoveAllGroups()
    {
      int count = this.Groups.Count;
      for (int index = 0; index < count; ++index)
        this.RemoveGroup(0);
      return true;
    }

    public bool RemoveAllSchedules()
    {
      if (this.m_Schedule == null)
        return false;
      this.m_Schedule.Clear();
      return true;
    }

    public new void LinkStadium(StadiumList stadiumList)
    {
    }

    public override void Normalize()
    {
      if (this.Settings.m_match_matchimportance != -1 && this.Trophy != null)
      {
        if (this.Trophy.Settings.m_match_matchimportance == -1)
          this.Trophy.Settings.m_match_matchimportance = this.Settings.m_match_matchimportance;
        this.Settings.m_match_matchimportance = -1;
      }
      if (this.Settings.m_N_info_color_slot_adv_group != 0 && this.Groups != null)
      {
        foreach (Group group in (ArrayList) this.Groups)
        {
          if (group.Settings.m_N_info_color_slot_adv_group == 0)
          {
            group.Settings.m_info_color_slot_adv_group = new int[8];
            for (int index = 0; index < this.Settings.m_N_info_color_slot_adv_group; ++index)
              group.Settings.m_info_color_slot_adv_group[index] = this.Settings.m_info_color_slot_adv_group[index];
            group.Settings.m_N_info_color_slot_adv_group = this.Settings.m_N_info_color_slot_adv_group;
          }
        }
        this.Settings.m_N_info_color_slot_adv_group = 0;
      }
      if (this.Settings.m_match_stagetype == null)
        this.Settings.m_match_stagetype = "LEAGUE";
      if (this.Settings.m_match_stagetype != "SETUP" && this.Settings.m_match_matchsituation == null)
        this.Settings.m_match_matchsituation = "LEAGUE";
      if (this.Settings.m_num_games == -1)
        return;
      foreach (Group group in (ArrayList) this.Groups)
      {
        if (group.Settings.m_num_games == -1)
          group.Settings.m_num_games = this.Settings.m_num_games;
      }
      this.Settings.m_num_games = -1;
    }

    public bool AddTask(Task action)
    {
      if (action.When == "start")
      {
        if (this.m_NStartTasks == 0)
          this.m_StartTask = new Task[24];
        if (this.m_NStartTasks < this.m_StartTask.Length)
        {
          this.m_StartTask[this.m_NStartTasks] = action;
          ++this.m_NStartTasks;
          return true;
        }
      }
      else if (action.When == "end")
      {
        if (this.m_NEndTasks == 0)
          this.m_EndTask = new Task[24];
        if (this.m_NEndTasks < this.m_EndTask.Length)
        {
          this.m_EndTask[this.m_NEndTasks] = action;
          ++this.m_NEndTasks;
          return true;
        }
      }
      return false;
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

    public void CopyTasks(Stage newStage, League targetLeague)
    {
      for (int index = 0; index < this.m_NStartTasks; ++index)
        newStage.AddTask(this.m_StartTask[index].CopyTask((Compobj) newStage, targetLeague));
      for (int index = 0; index < this.m_NEndTasks; ++index)
        newStage.AddTask(this.m_EndTask[index].CopyTask((Compobj) newStage, targetLeague));
    }

    public override bool SaveToTasks(StreamWriter w)
    {
      if (w == null || this.Trophy == null)
        return false;
      for (int index = 0; index < this.m_NStartTasks; ++index)
        this.m_StartTask[index].SaveToTasks(w);
      for (int index = 0; index < this.m_NEndTasks; ++index)
        this.m_EndTask[index].SaveToTasks(w);
      return true;
    }
  }
}
