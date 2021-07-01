// Original code created by Rinaldo

namespace FifaLibrary
{
  public class Confederation : Compobj
  {
    private World m_World;

    public World World
    {
      get
      {
        return this.m_World;
      }
      set
      {
        this.m_World = value;
      }
    }

    public Confederation(int id, string typeString, string description, Compobj parentObj)
      : base(id, 1, typeString, description, parentObj)
    {
      this.m_Nations = new NationList();
      this.m_Trophies = new TrophyList();
    }

    public bool AddTrophy(int assetId)
    {
      if (assetId >= 1000)
        return false;
      int count = this.Trophies.Count;
      Trophy trophy = new Trophy(FifaEnvironment.CompetitionObjects.GetNewId(), "C" + assetId.ToString(), "TrophyName_Abbr15_" + assetId.ToString(), (Compobj) this);
      if (trophy == null)
        return false;
      this.Trophies.Add((object) trophy);
      FifaEnvironment.CompetitionObjects.Add((object) trophy);
      trophy.AddStage();
      return true;
    }

    public bool RemoveTrophy(int trophyId)
    {
      if (this.m_Trophies.Count < 1)
        return false;
      Trophy trophy = (Trophy) FifaEnvironment.CompetitionObjects.SearchId(trophyId);
      if (trophy == null)
        return false;
      this.m_Trophies.Remove((object) trophy);
      FifaEnvironment.CompetitionObjects.Remove((object) trophy);
      trophy.RemoveAllStages();
      return true;
    }

    public bool AddNation(Country country)
    {
      int count = this.Nations.Count;
      Nation nation = new Nation(FifaEnvironment.CompetitionObjects.GetNewId(), country.DatabaseName.Substring(0, 4), "NationName_" + country.Id.ToString(), (Compobj) this);
      if (nation == null)
        return false;
      this.Nations.Add((object) nation);
      FifaEnvironment.CompetitionObjects.Add((object) nation);
      return true;
    }

    public bool RemoveNation()
    {
      if (this.m_Nations.Count < 1)
        return false;
      Nation nation = (Nation) this.m_Nations[this.m_Nations.Count - 1];
      this.m_Nations.Remove((object) nation);
      FifaEnvironment.CompetitionObjects.Remove((object) nation);
      nation.RemoveAllTrophies();
      return true;
    }

    public bool RemoveAllNations()
    {
      int count = this.m_Nations.Count;
      for (int index = 0; index < count; ++index)
        this.RemoveNation();
      return true;
    }

    public override void Normalize()
    {
    }
  }
}
