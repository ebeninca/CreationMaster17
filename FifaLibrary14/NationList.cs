// Original code created by Rinaldo

using System.Collections;

namespace FifaLibrary
{
  public class NationList : IdArrayList
  {
    public NationList()
      : base(typeof (Nation))
    {
    }

    public void LinkCountry(CountryList countryList)
    {
      foreach (Compobj compobj in (ArrayList) this)
        compobj.LinkCountry(countryList);
    }
  }
}
