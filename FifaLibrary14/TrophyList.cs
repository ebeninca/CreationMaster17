// Original code created by Rinaldo

using System.Collections;

namespace FifaLibrary
{
  public class TrophyList : IdArrayList
  {
    public TrophyList()
      : base(typeof (Trophy))
    {
    }

    public void LinkLeague(LeagueList leagueList)
    {
      foreach (Compobj compobj in (ArrayList) this)
        compobj.LinkLeague(leagueList);
    }
  }
}
