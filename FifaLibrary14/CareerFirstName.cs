// Original code created by Rinaldo

namespace FifaLibrary
{
  public class CareerFirstName : IdObject
  {
    private string m_Text;
    private int m_firstname;
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

    public int firstname
    {
      get
      {
        return this.m_firstname;
      }
      set
      {
        this.m_firstname = value;
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
        return CareerFirstName.s_PlayerNames;
      }
      set
      {
        CareerFirstName.s_PlayerNames = value;
      }
    }

    public CareerFirstName(Record r)
      : base(r.IntField[FI.career_firstnames_firstnameid])
    {
      this.Load(r);
    }

    public void Load(Record r)
    {
      this.m_firstname = r.IntField[FI.career_firstnames_firstname];
      this.m_groupid = r.IntField[FI.career_firstnames_groupid];
      if (CareerFirstName.s_PlayerNames != null && CareerFirstName.s_PlayerNames.TryGetValue(this.m_firstname, out this.m_Text, true))
        return;
      this.m_Text = string.Empty;
    }

    public void Save(Record r)
    {
      string name = (string) null;
      CareerFirstName.s_PlayerNames.TryGetValue(this.m_firstname, out name, true);
      if (name != this.m_Text)
        this.m_firstname = CareerFirstName.s_PlayerNames.GetKey(this.m_Text);
      r.IntField[FI.career_firstnames_firstnameid] = this.Id;
      r.IntField[FI.career_firstnames_firstname] = this.m_firstname;
      r.IntField[FI.career_firstnames_groupid] = this.m_groupid;
    }
  }
}
