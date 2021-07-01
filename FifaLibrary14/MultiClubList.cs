// Original code created by Rinaldo

namespace FifaLibrary
{
  public class MultiClubList : IdArrayList
  {
    public MultiClubList()
      : base(typeof (MultiClub))
    {
      this.Clear();
      this.Add((object) new MultiClub());
    }
  }
}
