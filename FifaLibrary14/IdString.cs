// Original code created by Rinaldo

namespace FifaLibrary
{
  public class IdString : IdObject
  {
    private string m_String;

    public string String
    {
      get
      {
        return this.String;
      }
      set
      {
        this.String = value;
      }
    }

    public IdString(int id)
      : base(id)
    {
    }

    public IdString(int id, string value)
      : base(id)
    {
      this.m_String = value;
    }

    public override string ToString()
    {
      return this.m_String;
    }
  }
}
