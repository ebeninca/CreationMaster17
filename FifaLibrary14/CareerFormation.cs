// Original code created by Rinaldo

namespace FifaLibrary
{
  public class CareerFormation : Formation
  {
    private bool m_IsInCareer;

    public bool IsInCareer
    {
      set
      {
        this.m_IsInCareer = value;
      }
      get
      {
        return this.m_IsInCareer;
      }
    }

    public CareerFormation(Record r)
      : base(r)
    {
    }

    public CareerFormation(int formationid)
      : base(formationid)
    {
    }
  }
}
