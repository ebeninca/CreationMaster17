// Original code created by Rinaldo

using System.Collections;

namespace FifaLibrary
{
  public class InitTeamList : IdArrayList
  {
    public InitTeamList()
      : base(typeof (InitTeam))
    {
    }

    public void LinkTeam(TeamList teamList)
    {
      foreach (InitTeam initTeam in (ArrayList) this)
        initTeam.LinkTeam(teamList);
    }
  }
}
