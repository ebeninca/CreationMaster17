// Original code created by Rinaldo

namespace FifaLibrary
{
  public class CareerLastName : IdObject
  {
    private string m_Text;
    private int m_lastname;
    private int m_groupid;
    private static PlayerNames s_PlayerNames;

    public string Text
    {
      get
      {
        return this.m_Text;
      }
      set
      {
        this.m_Text = value;
      }
    }

    public int lastname
    {
      get
      {
        return this.m_lastname;
      }
      set
      {
        this.m_lastname = value;
      }
    }

    public int groupid
    {
      get
      {
        return this.m_groupid;
      }
      set
      {
        this.m_groupid = value;
      }
    }

    public static PlayerNames PlayerNames
    {
      get
      {
        return CareerLastName.s_PlayerNames;
      }
      set
      {
        CareerLastName.s_PlayerNames = value;
      }
    }

    public CareerLastName(Record r)
      : base(r.IntField[FI.career_lastnames_lastnameid])
    {
      this.Load(r);
    }

    public void Load(Record r)
    {
      this.m_lastname = r.IntField[FI.career_lastnames_lastname];
      this.m_groupid = r.IntField[FI.career_firstnames_groupid];
      if (CareerLastName.s_PlayerNames != null && CareerLastName.s_PlayerNames.TryGetValue(this.m_lastname, out this.m_Text, true))
        return;
      this.m_Text = string.Empty;
    }

    public void Save(Record r)
    {
      string name = (string) null;
      CareerLastName.s_PlayerNames.TryGetValue(this.m_lastname, out name, true);
      if (name != this.m_Text)
        this.m_lastname = CareerLastName.s_PlayerNames.GetKey(this.m_Text);
      r.IntField[FI.career_lastnames_lastnameid] = this.Id;
      r.IntField[FI.career_lastnames_lastname] = this.m_lastname;
      r.IntField[FI.career_lastnames_groupid] = this.m_groupid;
    }
  }
}
