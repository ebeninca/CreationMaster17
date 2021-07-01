// Original code created by Rinaldo

namespace FifaLibrary
{
  public class SpecificHeadList : IdArrayList
  {
    public SpecificHeadList()
      : base(typeof (SpecificHead))
    {
      this.Clear();
      this.Add((object) new SpecificHead());
    }
  }
}
