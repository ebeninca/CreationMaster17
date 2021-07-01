// Original code created by Rinaldo

using System.Collections;

namespace FifaLibrary
{
  public class ScheduleComparer : IComparer
  {
    int IComparer.Compare(object x, object y)
    {
      Schedule schedule1 = (Schedule) x;
      Schedule schedule2 = (Schedule) y;
      return schedule1.Day != schedule2.Day ? schedule1.Day - schedule2.Day : schedule1.Time - schedule2.Time;
    }
  }
}
