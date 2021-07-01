// Original code created by Rinaldo

using System.Collections;

namespace FifaLibrary
{
  public class CountryList : IdArrayList
  {
    public CountryList()
      : base(typeof (Country))
    {
    }

    public CountryList(DbFile fifaDbFile)
      : base(typeof (Country))
    {
      this.Load(fifaDbFile);
    }

    public void Load(DbFile fifaDbFile)
    {
      Table table = FifaEnvironment.FifaDb.Table[TI.nations];
      int minValue = table.TableDescriptor.MinValues[FI.nations_nationid];
      int maxValue = table.TableDescriptor.MaxValues[FI.nations_nationid];
      this.Load(FifaEnvironment.FifaDb.Table[TI.nations], minValue, maxValue);
    }

    public void Load(Table t, int minId, int maxId)
    {
      this.MinId = minId;
      this.MaxId = maxId;
      Country[] countryArray = new Country[t.NRecords];
      this.Clear();
      for (int index = 0; index < t.NRecords; ++index)
        countryArray[index] = new Country(t.Records[index]);
      this.AddRange((ICollection) countryArray);
      this.SortId();
    }

    public void DeleteCountry(Country country)
    {
      this.RemoveId((IdObject) country);
    }

    public Country SearchCountry(int countryid)
    {
      return (Country) this.SearchId(countryid);
    }

    public Country SearchNationalTeamId(int nationalTeamId)
    {
      if (nationalTeamId == 3145)
        return (Country) this.SearchId(34);
      if (nationalTeamId == 1800)
        return (Country) null;
      for (int index = 0; index < this.Count; ++index)
      {
        Country country = (Country) this[index];
        if (nationalTeamId == country.NationalTeamId)
          return country;
      }
      return (Country) null;
    }

    public void Save(DbFile fifaDbFile)
    {
      Table table = fifaDbFile.Table[TI.nations];
      table.ResizeRecords(this.Count);
      int index = 0;
      foreach (Country country in (ArrayList) this)
      {
        Record record = table.Records[index];
        country.SaveCountry(record);
        country.SaveLangTable();
        ++index;
      }
    }

    public void FillFromAudionation(Table t)
    {
      for (int index = 0; index < t.NRecords; ++index)
      {
        Country country = (Country) this.SearchId(t.Records[index].IntField[FI.audionation_nationid]);
      }
    }

    public Country FitCountry(string name, int id)
    {
      string lower = name.ToLower();
      foreach (Country country in (ArrayList) this)
      {
        if (country.Fit(lower, id))
          return country;
      }
      return (Country) null;
    }

    public void LinkTeam(TeamList teamList)
    {
      foreach (Country country in (ArrayList) this)
        country.LinkTeam(teamList);
    }
  }
}
