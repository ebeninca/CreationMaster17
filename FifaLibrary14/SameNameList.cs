// Original code created by Rinaldo

namespace FifaLibrary
{
  public class SameNameList : IdArrayList
  {
    public SameNameList()
      : base(typeof (SameName))
    {
      this.Clear();
      this.Add((object) new SameName());
    }
  }
}
