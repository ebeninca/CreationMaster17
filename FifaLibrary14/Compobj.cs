// Original code created by Rinaldo

using System.Collections;
using System.IO;

namespace FifaLibrary
{
  public class Compobj : IdObject
  {
    private Compobj m_ParentObj;
    protected ConfederationList m_Confederations;
    protected NationList m_Nations;
    protected TrophyList m_Trophies;
    protected StageList m_Stages;
    protected GroupList m_Groups;
    private int m_TypeNumber;
    private string m_TypeString;
    private string m_Description;
    private CompetitionSettings m_CompetitionSettings;

    public override string ToString()
    {
      return this.m_TypeString;
    }

    public Compobj ParentObj
    {
      get
      {
        return this.m_ParentObj;
      }
      set
      {
        this.m_ParentObj = value;
      }
    }

    public ConfederationList Confederations
    {
      get
      {
        return this.m_Confederations;
      }
    }

    public NationList Nations
    {
      get
      {
        return this.m_Nations;
      }
    }

    public TrophyList Trophies
    {
      get
      {
        return this.m_Trophies;
      }
    }

    public StageList Stages
    {
      get
      {
        return this.m_Stages;
      }
    }

    public GroupList Groups
    {
      get
      {
        return this.m_Groups;
      }
    }

    public int TypeNumber
    {
      get
      {
        return this.m_TypeNumber;
      }
      set
      {
        this.m_TypeNumber = value;
      }
    }

    public string TypeString
    {
      get
      {
        return this.m_TypeString;
      }
      set
      {
        this.m_TypeString = value;
      }
    }

    public bool IsWorld()
    {
      return this.m_TypeNumber == 0;
    }

    public bool IsConfederation()
    {
      return this.m_TypeNumber == 1;
    }

    public bool IsNation()
    {
      return this.m_TypeNumber == 2;
    }

    public bool IsTrophy()
    {
      return this.m_TypeNumber == 3;
    }

    public bool IsStage()
    {
      return this.m_TypeNumber == 4;
    }

    public bool IsGroup()
    {
      return this.m_TypeNumber == 5;
    }

    public string Description
    {
      get
      {
        return this.m_Description;
      }
      set
      {
        this.m_Description = value;
      }
    }

    public CompetitionSettings Settings
    {
      get
      {
        return this.m_CompetitionSettings;
      }
      set
      {
        this.m_CompetitionSettings = value;
      }
    }

    public Compobj(
      int id,
      int typeNumber,
      string typeString,
      string description,
      Compobj parentObj)
      : base(id)
    {
      this.m_TypeString = typeString;
      this.m_TypeNumber = typeNumber;
      this.m_Description = description;
      this.m_ParentObj = parentObj;
      this.m_CompetitionSettings = new CompetitionSettings(this);
    }

    public bool AddChild(Compobj childObject)
    {
      switch (childObject.TypeNumber)
      {
        case 1:
          this.m_Confederations.InsertId((IdObject) childObject);
          break;
        case 2:
          this.m_Nations.InsertId((IdObject) childObject);
          break;
        case 3:
          this.m_Trophies.InsertId((IdObject) childObject);
          break;
        case 4:
          this.m_Stages.InsertId((IdObject) childObject);
          break;
        case 5:
          this.m_Groups.InsertId((IdObject) childObject);
          break;
      }
      return true;
    }

    public void SetProperty(string property, string val)
    {
      this.m_CompetitionSettings.LoadProperty(property, val);
    }

    public int Renumber(int id)
    {
      this.Id = id;
      ++id;
      if (this.m_Trophies != null)
      {
        foreach (Trophy trophy in (ArrayList) this.m_Trophies)
        {
          if (!trophy.Settings.m_comp_type.Contains("FRIENDLY"))
            id = trophy.Renumber(id);
        }
      }
      if (this.m_Confederations != null)
      {
        foreach (Compobj confederation in (ArrayList) this.m_Confederations)
          id = confederation.Renumber(id);
      }
      if (this.m_Nations != null)
      {
        foreach (Nation nation in (ArrayList) this.m_Nations)
        {
          id = nation.Renumber(id);
          nation.Settings.m_rule_suspension = nation.Id;
        }
      }
      if (this.m_Stages != null)
      {
        foreach (Stage stage in (ArrayList) this.m_Stages)
        {
          id = stage.Renumber(id);
          stage.Settings.UpdateIdUsingStageReference();
        }
      }
      if (this.m_Groups != null)
      {
        foreach (Compobj group in (ArrayList) this.m_Groups)
          id = group.Renumber(id);
      }
      if (this.m_Trophies != null)
      {
        foreach (Trophy trophy in (ArrayList) this.m_Trophies)
        {
          if (trophy.Settings.m_comp_type.Contains("FRIENDLY"))
            id = trophy.Renumber(id);
        }
      }
      return id;
    }

    public bool SaveToCompobj(StreamWriter w)
    {
      string str = this.Id.ToString() + "," + (object) this.m_TypeNumber + "," + this.m_TypeString + "," + this.m_Description + "," + (object) (this.ParentObj != null ? this.ParentObj.Id : -1);
      w.WriteLine(str);
      return true;
    }

    public bool SaveRecursivelyToCompobj(StreamWriter w)
    {
      this.SaveToCompobj(w);
      if (this.m_Trophies != null)
      {
        foreach (Trophy trophy in (ArrayList) this.m_Trophies)
        {
          if (!trophy.Settings.m_comp_type.Contains("FRIENDLY"))
            trophy.SaveRecursivelyToCompobj(w);
        }
      }
      if (this.m_Confederations != null)
      {
        foreach (Compobj confederation in (ArrayList) this.m_Confederations)
          confederation.SaveRecursivelyToCompobj(w);
      }
      if (this.m_Nations != null)
      {
        foreach (Compobj nation in (ArrayList) this.m_Nations)
          nation.SaveRecursivelyToCompobj(w);
      }
      if (this.m_Stages != null)
      {
        foreach (Compobj stage in (ArrayList) this.m_Stages)
          stage.SaveRecursivelyToCompobj(w);
      }
      if (this.m_Groups != null)
      {
        foreach (Compobj group in (ArrayList) this.m_Groups)
          group.SaveRecursivelyToCompobj(w);
      }
      if (this.m_Trophies != null)
      {
        foreach (Trophy trophy in (ArrayList) this.m_Trophies)
        {
          if (trophy.Settings.m_comp_type.Contains("FRIENDLY"))
            trophy.SaveRecursivelyToCompobj(w);
        }
      }
      return true;
    }

    public virtual bool SaveToCompids(StreamWriter w)
    {
      return false;
    }

    public bool SaveRecursivelyToCompids(StreamWriter w)
    {
      this.SaveToCompids(w);
      if (this.m_Trophies != null)
      {
        foreach (Trophy trophy in (ArrayList) this.m_Trophies)
        {
          if (!trophy.Settings.m_comp_type.Contains("FRIENDLY"))
            trophy.SaveRecursivelyToCompids(w);
        }
      }
      if (this.m_Confederations != null)
      {
        foreach (Compobj confederation in (ArrayList) this.m_Confederations)
          confederation.SaveRecursivelyToCompids(w);
      }
      if (this.m_Nations != null)
      {
        foreach (Compobj nation in (ArrayList) this.m_Nations)
          nation.SaveRecursivelyToCompids(w);
      }
      if (this.m_Trophies != null)
      {
        foreach (Trophy trophy in (ArrayList) this.m_Trophies)
        {
          if (trophy.Settings.m_comp_type.Contains("FRIENDLY"))
            trophy.SaveRecursivelyToCompids(w);
        }
      }
      return true;
    }

    public bool SaveToSettings(StreamWriter w)
    {
      if (w == null)
        return false;
      this.m_CompetitionSettings.SaveToSettings(this.Id, w);
      return true;
    }

    public bool SaveRecursivelyToSettings(StreamWriter w)
    {
      this.SaveToSettings(w);
      if (this.m_Trophies != null)
      {
        foreach (Trophy trophy in (ArrayList) this.m_Trophies)
        {
          if (!trophy.Settings.m_comp_type.Contains("FRIENDLY"))
            trophy.SaveRecursivelyToSettings(w);
        }
      }
      if (this.m_Confederations != null)
      {
        foreach (Compobj confederation in (ArrayList) this.m_Confederations)
          confederation.SaveRecursivelyToSettings(w);
      }
      if (this.m_Nations != null)
      {
        foreach (Compobj nation in (ArrayList) this.m_Nations)
          nation.SaveRecursivelyToSettings(w);
      }
      if (this.m_Stages != null)
      {
        foreach (Compobj stage in (ArrayList) this.m_Stages)
          stage.SaveRecursivelyToSettings(w);
      }
      if (this.m_Groups != null)
      {
        foreach (Compobj group in (ArrayList) this.m_Groups)
          group.SaveRecursivelyToSettings(w);
      }
      if (this.m_Trophies != null)
      {
        foreach (Trophy trophy in (ArrayList) this.m_Trophies)
        {
          if (trophy.Settings.m_comp_type.Contains("FRIENDLY"))
            trophy.SaveRecursivelyToSettings(w);
        }
      }
      return true;
    }

    public virtual bool SaveToStandings(StreamWriter w)
    {
      return false;
    }

    public bool SaveRecursivelyToStandings(StreamWriter w)
    {
      this.SaveToStandings(w);
      if (this.m_Trophies != null)
      {
        foreach (Trophy trophy in (ArrayList) this.m_Trophies)
        {
          if (!trophy.Settings.m_comp_type.Contains("FRIENDLY"))
            trophy.SaveRecursivelyToStandings(w);
        }
      }
      if (this.m_Confederations != null)
      {
        foreach (Compobj confederation in (ArrayList) this.m_Confederations)
          confederation.SaveRecursivelyToStandings(w);
      }
      if (this.m_Nations != null)
      {
        foreach (Compobj nation in (ArrayList) this.m_Nations)
          nation.SaveRecursivelyToStandings(w);
      }
      if (this.m_Stages != null)
      {
        foreach (Compobj stage in (ArrayList) this.m_Stages)
          stage.SaveRecursivelyToStandings(w);
      }
      if (this.m_Groups != null)
      {
        foreach (Compobj group in (ArrayList) this.m_Groups)
          group.SaveRecursivelyToStandings(w);
      }
      if (this.m_Trophies != null)
      {
        foreach (Trophy trophy in (ArrayList) this.m_Trophies)
        {
          if (trophy.Settings.m_comp_type.Contains("FRIENDLY"))
            trophy.SaveRecursivelyToStandings(w);
        }
      }
      return true;
    }

    public virtual bool SaveToTasks(StreamWriter w)
    {
      return false;
    }

    public bool SaveRecursivelyToTasks(StreamWriter w)
    {
      this.SaveToTasks(w);
      if (this.m_Trophies != null)
      {
        foreach (Trophy trophy in (ArrayList) this.m_Trophies)
        {
          if (!trophy.Settings.m_comp_type.Contains("FRIENDLY"))
            trophy.SaveRecursivelyToTasks(w);
        }
      }
      if (this.m_Confederations != null)
      {
        foreach (Compobj confederation in (ArrayList) this.m_Confederations)
          confederation.SaveRecursivelyToTasks(w);
      }
      if (this.m_Nations != null)
      {
        foreach (Compobj nation in (ArrayList) this.m_Nations)
          nation.SaveRecursivelyToTasks(w);
      }
      if (this.m_Stages != null)
      {
        foreach (Compobj stage in (ArrayList) this.m_Stages)
          stage.SaveRecursivelyToTasks(w);
      }
      if (this.m_Groups != null)
      {
        foreach (Compobj group in (ArrayList) this.m_Groups)
          group.SaveRecursivelyToTasks(w);
      }
      if (this.m_Trophies != null)
      {
        foreach (Trophy trophy in (ArrayList) this.m_Trophies)
        {
          if (trophy.Settings.m_comp_type.Contains("FRIENDLY"))
            trophy.SaveRecursivelyToTasks(w);
        }
      }
      return true;
    }

    public virtual bool SaveToAdvancement(StreamWriter w)
    {
      return false;
    }

    public bool SaveRecursivelyToAdvancement(StreamWriter w)
    {
      this.SaveToAdvancement(w);
      if (this.m_Trophies != null)
      {
        foreach (Trophy trophy in (ArrayList) this.m_Trophies)
        {
          if (!trophy.Settings.m_comp_type.Contains("FRIENDLY"))
            trophy.SaveRecursivelyToAdvancement(w);
        }
      }
      if (this.m_Confederations != null)
      {
        foreach (Compobj confederation in (ArrayList) this.m_Confederations)
          confederation.SaveRecursivelyToAdvancement(w);
      }
      if (this.m_Nations != null)
      {
        foreach (Compobj nation in (ArrayList) this.m_Nations)
          nation.SaveRecursivelyToAdvancement(w);
      }
      if (this.m_Stages != null)
      {
        foreach (Compobj stage in (ArrayList) this.m_Stages)
          stage.SaveRecursivelyToAdvancement(w);
      }
      if (this.m_Groups != null)
      {
        foreach (Compobj group in (ArrayList) this.m_Groups)
          group.SaveRecursivelyToAdvancement(w);
      }
      if (this.m_Trophies != null)
      {
        foreach (Trophy trophy in (ArrayList) this.m_Trophies)
        {
          if (trophy.Settings.m_comp_type.Contains("FRIENDLY"))
            trophy.SaveRecursivelyToAdvancement(w);
        }
      }
      return true;
    }

    public virtual bool SaveToSchedule(StreamWriter w)
    {
      return false;
    }

    public bool SaveRecursivelyToSchedule(StreamWriter w)
    {
      this.SaveToSchedule(w);
      if (this.m_Trophies != null)
      {
        foreach (Trophy trophy in (ArrayList) this.m_Trophies)
        {
          if (!trophy.Settings.m_comp_type.Contains("FRIENDLY"))
            trophy.SaveRecursivelyToSchedule(w);
        }
      }
      if (this.m_Confederations != null)
      {
        foreach (Compobj confederation in (ArrayList) this.m_Confederations)
          confederation.SaveRecursivelyToSchedule(w);
      }
      if (this.m_Nations != null)
      {
        foreach (Compobj nation in (ArrayList) this.m_Nations)
          nation.SaveRecursivelyToSchedule(w);
      }
      if (this.m_Stages != null)
      {
        foreach (Compobj stage in (ArrayList) this.m_Stages)
          stage.SaveRecursivelyToSchedule(w);
      }
      if (this.m_Groups != null)
      {
        foreach (Compobj group in (ArrayList) this.m_Groups)
          group.SaveRecursivelyToSchedule(w);
      }
      if (this.m_Trophies != null)
      {
        foreach (Trophy trophy in (ArrayList) this.m_Trophies)
        {
          if (trophy.Settings.m_comp_type.Contains("FRIENDLY"))
            trophy.SaveRecursivelyToSchedule(w);
        }
      }
      return true;
    }

    public virtual bool SaveToWeather(StreamWriter w)
    {
      return false;
    }

    public bool SaveRecursivelyToWeather(StreamWriter w)
    {
      this.SaveToWeather(w);
      if (this.m_Trophies != null)
      {
        foreach (Trophy trophy in (ArrayList) this.m_Trophies)
        {
          if (!trophy.Settings.m_comp_type.Contains("FRIENDLY"))
            trophy.SaveRecursivelyToWeather(w);
        }
      }
      if (this.m_Confederations != null)
      {
        foreach (Compobj confederation in (ArrayList) this.m_Confederations)
          confederation.SaveRecursivelyToWeather(w);
      }
      if (this.m_Nations != null)
      {
        foreach (Compobj nation in (ArrayList) this.m_Nations)
          nation.SaveRecursivelyToWeather(w);
      }
      if (this.m_Stages != null)
      {
        foreach (Compobj stage in (ArrayList) this.m_Stages)
          stage.SaveRecursivelyToWeather(w);
      }
      if (this.m_Groups != null)
      {
        foreach (Compobj group in (ArrayList) this.m_Groups)
          group.SaveRecursivelyToWeather(w);
      }
      if (this.m_Trophies != null)
      {
        foreach (Trophy trophy in (ArrayList) this.m_Trophies)
        {
          if (trophy.Settings.m_comp_type.Contains("FRIENDLY"))
            trophy.SaveRecursivelyToWeather(w);
        }
      }
      return true;
    }

    public virtual bool SaveToInitteams(StreamWriter w)
    {
      return false;
    }

    public bool SaveRecursivelyToInitteams(StreamWriter w)
    {
      this.SaveToInitteams(w);
      if (this.m_Trophies != null)
      {
        foreach (Trophy trophy in (ArrayList) this.m_Trophies)
        {
          if (!trophy.Settings.m_comp_type.Contains("FRIENDLY"))
            trophy.SaveRecursivelyToInitteams(w);
        }
      }
      if (this.m_Confederations != null)
      {
        foreach (Compobj confederation in (ArrayList) this.m_Confederations)
          confederation.SaveRecursivelyToInitteams(w);
      }
      if (this.m_Nations != null)
      {
        foreach (Compobj nation in (ArrayList) this.m_Nations)
          nation.SaveRecursivelyToInitteams(w);
      }
      if (this.m_Stages != null)
      {
        foreach (Compobj stage in (ArrayList) this.m_Stages)
          stage.SaveRecursivelyToInitteams(w);
      }
      if (this.m_Groups != null)
      {
        foreach (Compobj group in (ArrayList) this.m_Groups)
          group.SaveRecursivelyToInitteams(w);
      }
      if (this.m_Trophies != null)
      {
        foreach (Trophy trophy in (ArrayList) this.m_Trophies)
        {
          if (trophy.Settings.m_comp_type.Contains("FRIENDLY"))
            trophy.SaveRecursivelyToInitteams(w);
        }
      }
      return true;
    }

    public virtual bool FillFromLanguage()
    {
      return false;
    }

    public virtual bool SaveToLanguage()
    {
      return false;
    }

    public virtual void LinkLeague(LeagueList leagueList)
    {
    }

    public virtual void LinkTeam(TeamList teamList)
    {
    }

    public virtual void LinkCountry(CountryList countryList)
    {
    }

    public virtual void LinkStadium(StadiumList countryList)
    {
    }

    public virtual void LinkCompetitions()
    {
    }

    public virtual void Normalize()
    {
    }
  }
}
