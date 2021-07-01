// Original code created by Rinaldo

namespace FifaLibrary
{
  public class CareerCommonName : IdObject
  {
    private string m_Text1;
    private string m_Text2;
    private int m_firstname;
    private int m_lastname;
    private int m_groupid;
    private static PlayerNames s_PlayerNames;

    public string Text1
    {
      get
      {
        return this.m_Text1;
      }
      set
      {
        this.m_Text1 = value;
      }
    }

    public string Text2
    {
      get
      {
        return this.m_Text2;
      }
      set
      {
        this.m_Text2 = value;
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
        return CareerCommonName.s_PlayerNames;
      }
      set
      {
        CareerCommonName.s_PlayerNames = value;
      }
    }

    public CareerCommonName(Record r)
      : base(r.IntField[FI.career_commonnames_commonnameid])
    {
      this.Load(r);
    }

    public void Load(Record r)
    {
      this.m_firstname = r.IntField[FI.career_commonnames_firstname];
      this.m_lastname = r.IntField[FI.career_commonnames_lastname];
      this.m_groupid = r.IntField[FI.career_commonnames_groupid];
      if (CareerCommonName.s_PlayerNames == null || !CareerCommonName.s_PlayerNames.TryGetValue(this.m_firstname, out this.m_Text1, true))
        this.m_Text1 = string.Empty;
      if (CareerCommonName.s_PlayerNames != null && CareerCommonName.s_PlayerNames.TryGetValue(this.m_lastname, out this.m_Text2, true))
        return;
      this.m_Text2 = string.Empty;
    }

    public void Save(Record r)
    {
      string name = (string) null;
      CareerCommonName.s_PlayerNames.TryGetValue(this.m_firstname, out name, true);
      if (name != this.m_Text1)
        this.m_firstname = CareerCommonName.s_PlayerNames.GetKey(this.m_Text1);
      CareerCommonName.s_PlayerNames.TryGetValue(this.m_lastname, out name, true);
      if (name != this.m_Text2)
        this.m_lastname = CareerCommonName.s_PlayerNames.GetKey(this.m_Text2);
      r.IntField[FI.career_commonnames_commonnameid] = this.Id;
      r.IntField[FI.career_commonnames_firstname] = this.m_firstname;
      r.IntField[FI.career_commonnames_lastname] = this.m_lastname;
      r.IntField[FI.career_commonnames_groupid] = this.m_groupid;
    }
  }
}
