// Original code created by Rinaldo

namespace FifaLibrary
{
  public class InitTeam : IdObject
  {
    private int m_teamid;
    private Team m_Team;

    public int teamid
    {
      get
      {
        return this.m_teamid;
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
        this.m_teamid = this.m_Team != null ? this.m_Team.Id : -1;
      }
    }

    public InitTeam(int orderId, int teamId)
    {
      this.Id = orderId;
      this.m_teamid = teamId;
    }

    public void LinkTeam(TeamList teamList)
    {
      if (teamList == null)
        return;
      this.m_Team = (Team) teamList.SearchId(this.m_teamid);
    }
  }
}
