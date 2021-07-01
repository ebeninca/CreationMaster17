// Original code created by Rinaldo

using System.Collections;
using System.IO;

namespace FifaLibrary
{
  public class ScheduleArray : ArrayList
  {
    private static ScheduleComparer m_Comparer = new ScheduleComparer();
    private Schedule[] m_Schedules;
    private int m_NSchedules;

    public Schedule[] Schedules
    {
      get
      {
        return this.m_Schedules;
      }
      set
      {
        this.m_Schedules = value;
      }
    }

    public int NSchedules
    {
      get
      {
        return this.m_NSchedules;
      }
      set
      {
        this.m_NSchedules = value;
      }
    }

    public ScheduleArray(int length)
    {
      this.m_NSchedules = 0;
    }

    public Schedule[] GetLegSchedule(int legId)
    {
      int length = 0;
      foreach (Schedule schedule in (ArrayList) this)
      {
        if (schedule.Leg == legId)
          ++length;
      }
      if (length == 0)
        return (Schedule[]) null;
      Schedule[] scheduleArray = new Schedule[length];
      int num = 0;
      foreach (Schedule schedule in (ArrayList) this)
      {
        if (schedule.Leg == legId)
          scheduleArray[num++] = schedule;
      }
      return scheduleArray;
    }

    public void RenumberLegs()
    {
      this.Sort((IComparer) ScheduleArray.m_Comparer);
      int num1 = 0;
      int num2 = 0;
      foreach (Schedule schedule in (ArrayList) this)
      {
        int leg = schedule.Leg;
        if (num2 != leg)
        {
          num2 = leg;
          ++num1;
        }
        schedule.Leg = num1;
      }
    }

    public Schedule DuplicatetLeg(int legId, int dayDelay)
    {
      Schedule[] legSchedule = this.GetLegSchedule(legId);
      if (legSchedule == null)
        return (Schedule) null;
      int num1 = -1;
      int num2 = 0;
      for (int index = 0; index < this.Count; ++index)
      {
        if (((Schedule) this[index]).Leg == legId)
        {
          if (num1 < 0)
            num1 = index;
          ++num2;
        }
      }
      if (num2 == 0)
        return (Schedule) null;
      int index1 = num1 + num2;
      Schedule schedule = (Schedule) null;
      for (int index2 = legSchedule.Length - 1; index2 >= 0; --index2)
      {
        schedule = new Schedule(legSchedule[index2]);
        schedule.Day += dayDelay;
        this.Insert(index1, (object) schedule);
      }
      for (int index2 = index1; index2 < this.Count; ++index2)
        ++((Schedule) this[index2]).Leg;
      return schedule;
    }

    public bool RemoveLeg(int legId)
    {
      int index1 = -1;
      int count = 0;
      for (int index2 = 0; index2 < this.Count; ++index2)
      {
        if (((Schedule) this[index2]).Leg == legId)
        {
          if (index1 < 0)
            index1 = index2;
          ++count;
        }
      }
      if (count <= 0)
        return false;
      this.RemoveRange(index1, count);
      for (int index2 = index1; index2 < this.Count; ++index2)
        --((Schedule) this[index2]).Leg;
      return true;
    }

    public bool AddScheduleToLeg(Schedule schedule)
    {
      int num1 = -1;
      int num2 = 0;
      for (int index = 0; index < this.Count; ++index)
      {
        if (((Schedule) this[index]).Leg == schedule.Leg)
        {
          if (num1 < 0)
            num1 = index;
          ++num2;
        }
      }
      if (num2 <= 0)
        return false;
      this.Insert(num1 + num2, (object) schedule);
      return true;
    }

    public bool DeleteSchedule(Schedule schedule)
    {
      for (int index = 0; index < this.Count; ++index)
      {
        Schedule schedule1 = (Schedule) this[index];
        if (schedule1.Leg == schedule.Leg && schedule1.Day == schedule.Day && (schedule1.Time == schedule.Time && schedule1.MinGames == schedule.MinGames) && schedule1.MaxGames == schedule.MaxGames)
        {
          bool flag = true;
          if (index > 0)
          {
            Schedule schedule2 = (Schedule) this[index - 1];
            if (schedule.Leg == schedule2.Leg)
              flag = false;
          }
          if (index < this.Count - 1)
          {
            Schedule schedule2 = (Schedule) this[index + 1];
            if (schedule.Leg == schedule2.Leg)
              flag = false;
          }
          if (flag)
            this.RemoveLeg(schedule.Leg);
          else
            this.RemoveAt(index);
          return true;
        }
      }
      return false;
    }

    public void AddSchedule(Schedule schedule)
    {
      this.Add((object) schedule);
    }

    public Schedule[] GetLastLegSchedule()
    {
      return this.Count <= 0 ? (Schedule[]) null : this.GetLegSchedule(((Schedule) this[this.Count - 1]).Leg);
    }

    public bool RemoveLastLeg()
    {
      return this.Count > 0 && this.RemoveLeg(((Schedule) this[this.Count - 1]).Leg);
    }

    public Schedule AppendLeg(Compobj compobj, int dayDelay)
    {
      if (this.Count <= 0)
      {
        if (compobj.IsGroup())
        {
          Schedule schedule = new Schedule((Group) compobj, 215, 1, 1, 1, 1500);
          this.AddSchedule(schedule);
          return schedule;
        }
        if (!compobj.IsStage())
          return (Schedule) null;
        Schedule schedule1 = new Schedule((Stage) compobj, 215, 1, 1, 1, 1500);
        this.AddSchedule(schedule1);
        return schedule1;
      }
      Schedule[] lastLegSchedule = this.GetLastLegSchedule();
      Schedule schedule2 = (Schedule) null;
      for (int index = 0; index < lastLegSchedule.Length; ++index)
      {
        schedule2 = new Schedule(lastLegSchedule[index]);
        ++schedule2.Leg;
        schedule2.Day += dayDelay;
        this.AddSchedule(schedule2);
      }
      return schedule2;
    }

    public void CloneSchedule(Schedule originalSchedule, int timeDelay)
    {
      Schedule schedule = new Schedule(originalSchedule);
      schedule.Time += timeDelay;
      this.AddScheduleToLeg(schedule);
    }

    public bool SaveToSchedule(StreamWriter w)
    {
      foreach (Schedule schedule in (ArrayList) this)
        schedule.SaveToSchedule(w);
      return true;
    }
  }
}
