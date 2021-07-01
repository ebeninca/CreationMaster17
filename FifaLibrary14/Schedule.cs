// Original code created by Rinaldo

using System;
using System.IO;

namespace FifaLibrary
{
  public class Schedule
  {
    public static DateTime s_BaseDate = new DateTime(2012, 12, 30, 0, 0, 0);
    private Stage m_Stage;
    private Group m_Group;
    private int m_Leg;
    private int m_MinGames;
    private int m_MaxGames;
    private int m_Time;
    private int m_Day;
    private int m_Year;

    public int Leg
    {
      get
      {
        return this.m_Leg;
      }
      set
      {
        this.m_Leg = value;
      }
    }

    public int MinGames
    {
      get
      {
        return this.m_MinGames;
      }
      set
      {
        this.m_MinGames = value;
      }
    }

    public int MaxGames
    {
      get
      {
        return this.m_MaxGames;
      }
      set
      {
        this.m_MaxGames = value;
      }
    }

    public int Time
    {
      get
      {
        return this.m_Time;
      }
      set
      {
        this.m_Time = value;
      }
    }

    public int TimeIndex
    {
      get
      {
        return (this.m_Time / 100 - 12) * 4 + this.m_Time % 100 / 15;
      }
      set
      {
        this.m_Time = value / 4 * 100 + 1200;
        this.m_Time += value % 4 * 15;
      }
    }

    public int Day
    {
      get
      {
        return this.m_Day;
      }
      set
      {
        this.m_Day = value;
      }
    }

    public int Year
    {
      get
      {
        return this.m_Year;
      }
    }

    public DateTime Date
    {
      get
      {
        TimeSpan timeSpan = new TimeSpan(this.m_Day, this.m_Time / 100, this.m_Time % 100, 0);
        if (this.m_Day < 0)
          return Schedule.s_BaseDate;
        DateTime dateTime = Schedule.s_BaseDate.Add(timeSpan);
        dateTime.AddHours((double) (this.m_Time / 100));
        dateTime.AddMinutes((double) (this.m_Time % 100));
        return dateTime;
      }
      set
      {
        this.m_Day = (value - Schedule.s_BaseDate).Days;
      }
    }

    public DateTime ConvertToDate(int gregorian)
    {
      DateTime baseDate = Schedule.s_BaseDate;
      return gregorian < 0 ? baseDate : baseDate.AddDays((double) gregorian);
    }

    public int ConvertFromDate(DateTime date)
    {
      DateTime baseDate = Schedule.s_BaseDate;
      return (date - baseDate).Days;
    }

    public Schedule(Stage stage, int day, int leg, int minGames, int maxGames, int time)
    {
      this.m_Stage = stage;
      this.m_Leg = leg;
      this.m_MinGames = minGames;
      this.m_MaxGames = maxGames;
      this.m_Time = time;
      this.m_Day = day;
      this.m_Year = 2012;
      string property = stage.Settings.GetProperty("schedule_year_start", 0, out bool _);
      if (property == null)
        return;
      this.m_Year = Convert.ToInt32(property);
    }

    public Schedule(Group group, int day, int leg, int minGames, int maxGames, int time)
    {
      this.m_Group = group;
      this.m_Leg = leg;
      this.m_MinGames = minGames;
      this.m_MaxGames = maxGames;
      this.m_Time = time;
      this.m_Day = day;
      this.m_Year = 2012;
      string property = group.Settings.GetProperty("schedule_year_start", 0, out bool _);
      if (property == null)
        return;
      this.m_Year = Convert.ToInt32(property);
    }

    public Schedule(Schedule srcSchedule)
    {
      this.m_Day = srcSchedule.m_Day;
      this.m_Leg = srcSchedule.m_Leg;
      this.m_MinGames = srcSchedule.m_MinGames;
      this.m_MaxGames = srcSchedule.m_MaxGames;
      this.m_Time = srcSchedule.m_Time;
      this.m_Group = srcSchedule.m_Group;
      this.m_Stage = srcSchedule.m_Stage;
      this.m_Year = srcSchedule.m_Year;
    }

    public bool SaveToSchedule(StreamWriter w)
    {
      if (w == null)
        return false;
      string str1;
      if (this.m_Group != null)
      {
        str1 = this.m_Group.Id.ToString() + ",";
      }
      else
      {
        if (this.m_Stage == null)
          return false;
        str1 = this.m_Stage.Id.ToString() + ",";
      }
      string str2 = str1 + this.m_Day.ToString() + "," + this.m_Leg.ToString() + "," + this.m_MinGames.ToString() + "," + this.m_MaxGames.ToString() + "," + this.m_Time.ToString();
      w.WriteLine(str2);
      return true;
    }
  }
}
