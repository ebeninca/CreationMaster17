// Original code created by Rinaldo

using System.Collections;

namespace FifaLibrary
{
  public class StadiumList : IdArrayList
  {
    public StadiumList()
      : base(typeof (Stadium))
    {
    }

    public StadiumList(DbFile fifaDbFile)
      : base(typeof (Stadium))
    {
      this.Load(fifaDbFile);
    }

    public void Load(DbFile fifaDbFile)
    {
      Table table = FifaEnvironment.FifaDb.Table[TI.teamstadiumlinks];
      int minValue = table.TableDescriptor.MinValues[FI.teamstadiumlinks_stadiumid];
      int maxValue = table.TableDescriptor.MaxValues[FI.teamstadiumlinks_stadiumid];
      this.Load(FifaEnvironment.FifaDb.Table[TI.stadiums], minValue, maxValue);
    }

    public void Load(Table t, int minId, int maxId)
    {
      this.MinId = minId;
      this.MaxId = maxId;
      this.Clear();
      for (int index = 0; index < t.NRecords; ++index)
        this.Add((object) new Stadium(t.Records[index]));
      this.SortId();
    }

    public void LinkTeam(TeamList teamList)
    {
      foreach (Stadium stadium in (ArrayList) this)
        stadium.LinkTeam(teamList);
    }

    public void LinkCountry(CountryList countryList)
    {
      foreach (Stadium stadium in (ArrayList) this)
        stadium.LinkCountry(countryList);
    }

    public void Save(DbFile fifaDbFile)
    {
      Table table = fifaDbFile.Table[TI.stadiums];
      table.ResizeRecords(this.Count);
      int index = 0;
      foreach (Stadium stadium in (ArrayList) this)
      {
        Record record = table.Records[index];
        ++index;
        stadium.SaveStadium(record);
        stadium.SaveLangTable();
      }
    }

    public void DeleteStadium(Stadium stadium)
    {
      this.RemoveId((IdObject) stadium);
    }

    public Stadium FitStadium(string name, int id)
    {
      foreach (Stadium stadium in (ArrayList) this)
      {
        if (stadium.name == name || stadium.LocalName == name)
          return stadium;
      }
      return (Stadium) null;
    }

    public override IdArrayList Filter(IdObject filter)
    {
      StadiumList stadiumList = new StadiumList();
      if (filter == null)
        return (IdArrayList) this;
      if (!(filter.GetType().Name == "Country"))
        return (IdArrayList) this;
      Country country = (Country) filter;
      for (int index = 0; index < this.Count; ++index)
      {
        Stadium stadium = (Stadium) this[index];
        if (stadium.Country == country)
          stadiumList.Add((object) stadium);
      }
      return (IdArrayList) stadiumList;
    }
  }
}
