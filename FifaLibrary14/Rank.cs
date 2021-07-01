// Original code created by Rinaldo

namespace FifaLibrary
{
  public class Rank : IdObject
  {
    private Group m_Group;
    private Rank m_MoveFrom;
    private Rank m_MoveTo;

    public Group Group
    {
      get
      {
        return this.m_Group;
      }
      set
      {
        this.m_Group = value;
      }
    }

    public Rank MoveFrom
    {
      get
      {
        return this.m_MoveFrom;
      }
      set
      {
        this.m_MoveFrom = value;
      }
    }

    public Rank MoveTo
    {
      get
      {
        return this.m_MoveTo;
      }
      set
      {
        this.m_MoveTo = value;
      }
    }

    public Rank(Group group, int orderId)
    {
      this.Id = orderId;
      this.m_Group = group;
    }

    public override string ToString()
    {
      Stage parentStage = this.m_Group.ParentStage;
      Trophy trophy = parentStage.Trophy;
      string str;
      if (this.Id != 0)
        str = "Team n." + this.Id.ToString() + " of " + parentStage.ToString() + " / " + this.m_Group.ToString() + " of " + trophy.ToString();
      else
        str = "A team from " + parentStage.ToString() + " / " + this.m_Group.ToString() + " of " + trophy.ToString();
      return str;
    }

    public string GetFromRankString()
    {
      if (this.m_MoveFrom == null || this.m_MoveFrom.Group == null)
        return "To be defined";
      if (!FifaEnvironment.CompetitionObjects.Contains((object) this.m_MoveFrom.Group))
      {
        this.m_MoveFrom = (Rank) null;
        return "To be defined";
      }
      if (this.m_MoveTo != null && !FifaEnvironment.CompetitionObjects.Contains((object) this.m_MoveTo.Group))
        this.m_MoveTo = (Rank) null;
      string str;
      if (this.m_Group.ParentStage.Trophy.Id != this.m_MoveFrom.Group.ParentStage.Trophy.Id)
      {
        if (this.m_MoveFrom.Id != 0)
          str = "Team n." + this.m_MoveFrom.Id.ToString() + " of " + this.m_MoveFrom.Group.ParentStage.ToString() + " / " + this.m_MoveFrom.Group.ToString() + " of " + this.m_MoveFrom.Group.ParentStage.Trophy.ToString();
        else
          str = "A team from " + this.m_MoveFrom.Group.ParentStage.ToString() + " / " + this.m_MoveFrom.Group.ToString() + " of " + this.m_MoveFrom.Group.ParentStage.Trophy.ToString();
      }
      else if (this.m_MoveFrom.Id != 0)
        str = "Team n." + this.m_MoveFrom.Id.ToString() + " of " + this.m_MoveFrom.Group.ParentStage.ToString() + " / " + this.m_MoveFrom.Group.ToString();
      else
        str = "A team from " + this.m_MoveFrom.Group.ParentStage.ToString() + " / " + this.m_MoveFrom.Group.ToString();
      return str;
    }

    public string GetToRankString()
    {
      if (this.m_MoveTo == null)
        return "Undefined";
      string str;
      if (this.m_Group.ParentStage.Trophy.Id != this.m_MoveTo.Group.ParentStage.Trophy.Id)
      {
        if (this.m_MoveFrom.Id != 0)
          str = "Team n." + this.m_MoveTo.Id.ToString() + " fof " + this.m_MoveTo.Group.ParentStage.ToString() + " / " + this.m_MoveTo.Group.ToString() + " of " + this.m_MoveFrom.Group.ParentStage.Trophy.ToString();
        else
          str = "A team from " + this.m_MoveTo.Group.ParentStage.ToString() + " / " + this.m_MoveTo.Group.ToString() + " of " + this.m_MoveTo.Group.ParentStage.Trophy.ToString();
      }
      else if (this.m_MoveFrom.Id != 0)
        str = "Team n." + this.m_MoveTo.Id.ToString() + " of " + this.m_MoveTo.Group.ParentStage.ToString() + " / " + this.m_MoveTo.Group.ToString();
      else
        str = "A team from " + this.m_MoveTo.Group.ParentStage.ToString() + " / " + this.m_MoveTo.Group.ToString();
      return str;
    }
  }
}
