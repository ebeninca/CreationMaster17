// Original code created by Rinaldo

namespace FifaLibrary
{
  public class FreeAgentList : IdArrayList
  {
    public FreeAgentList()
      : base(typeof (FreeAgent))
    {
      this.Clear();
      this.Add((object) new FreeAgent());
    }
  }
}
