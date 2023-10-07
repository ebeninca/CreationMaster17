// Original code created by Rinaldo

using System;
using System.Collections;
using System.Drawing;

namespace FifaLibrary
{
  public class Country : IdObject
  {
    private int m_ChantRegionIndex;
    private int m_PALanguageIndex;
    private string m_ISOCountryCode;
    private int m_CrowdBedsRegionIndex;
    private int m_WhistlesRegionIndex;
    private int m_AmbienceRegionIndex;
    private int m_HecklesRegionIndex;
    private int m_ReactionsRegionIndex;
    private int m_PlayerCallPatchBankIndex;
    private int m_TeamCanWhistleIndex;
    private string m_nationname;
    public int m_confederation;
    private int m_ContinentalCupTarget;
    private int m_WorldCupTarget;
    public int m_Level;
    public bool m_top_tier;
    private int m_nationstartingfirstletter;
    private string m_DefaultCommLang;
    private string m_LanguageName;
    private string m_LanguageShortName;
    private string m_LanguageAbbreviation;
    private Team m_NationalTeam;
    private int m_NationalTeamId;

    public int ChantRegionIndex
    {
      get
      {
        return this.m_ChantRegionIndex;
      }
      set
      {
        this.m_ChantRegionIndex = value;
      }
    }

    public int PALanguageIndex
    {
      get
      {
        return this.m_PALanguageIndex;
      }
      set
      {
        this.m_PALanguageIndex = value;
      }
    }

    public string ISOCountryCode
    {
      get
      {
        return this.m_ISOCountryCode;
      }
      set
      {
        this.m_ISOCountryCode = value;
      }
    }

    public int CrowdBedsRegionIndex
    {
      get
      {
        return this.m_CrowdBedsRegionIndex;
      }
      set
      {
        this.m_CrowdBedsRegionIndex = value;
      }
    }

    public int WhistlesRegionIndex
    {
      get
      {
        return this.m_WhistlesRegionIndex;
      }
      set
      {
        this.m_WhistlesRegionIndex = value;
      }
    }

    public int AmbienceRegionIndex
    {
      get
      {
        return this.m_AmbienceRegionIndex;
      }
      set
      {
        this.m_AmbienceRegionIndex = value;
      }
    }

    public int HecklesRegionIndex
    {
      get
      {
        return this.m_HecklesRegionIndex;
      }
      set
      {
        this.m_HecklesRegionIndex = value;
      }
    }

    public int ReactionsRegionIndex
    {
      get
      {
        return this.m_ReactionsRegionIndex;
      }
      set
      {
        this.m_ReactionsRegionIndex = value;
      }
    }

    public int PlayerCallPatchBankIndex
    {
      get
      {
        return this.m_PlayerCallPatchBankIndex;
      }
      set
      {
        this.m_PlayerCallPatchBankIndex = value;
      }
    }

    public int TeamCanWhistleIndex
    {
      get
      {
        return this.m_TeamCanWhistleIndex;
      }
      set
      {
        this.m_TeamCanWhistleIndex = value;
      }
    }

    public string DatabaseName
    {
      get
      {
        return this.m_nationname;
      }
      set
      {
        this.m_nationname = value;
      }
    }

    public int Confederation
    {
      get
      {
        return this.m_confederation;
      }
      set
      {
        this.m_confederation = value;
      }
    }

    public int ContinentalCupTarget
    {
      get
      {
        return this.m_ContinentalCupTarget;
      }
      set
      {
        this.m_ContinentalCupTarget = value;
      }
    }

    public int WorldCupTarget
    {
      get
      {
        return this.m_WorldCupTarget;
      }
      set
      {
        this.m_WorldCupTarget = value;
      }
    }

    public int Level
    {
      get
      {
        return this.m_Level;
      }
      set
      {
        this.m_Level = value;
      }
    }

    public bool Top_tier
    {
      get
      {
        return this.m_top_tier;
      }
      set
      {
        this.m_top_tier = value;
      }
    }

    public string DefaultCommLang
    {
      get
      {
        return this.m_DefaultCommLang;
      }
      set
      {
        this.m_DefaultCommLang = value;
      }
    }

    public string LanguageName
    {
      get
      {
        return this.m_LanguageName;
      }
      set
      {
        this.m_LanguageName = value;
      }
    }

    public string LanguageShortName
    {
      get
      {
        return this.m_LanguageShortName;
      }
      set
      {
        this.m_LanguageShortName = value;
      }
    }

    public string LanguageAbbreviation
    {
      get
      {
        return this.m_LanguageAbbreviation;
      }
      set
      {
        this.m_LanguageAbbreviation = value;
      }
    }

    public Team NationalTeam
    {
      get
      {
        return this.m_NationalTeam;
      }
      set
      {
        this.m_NationalTeam = value;
        if (this.m_NationalTeam != null)
          this.m_NationalTeamId = this.m_NationalTeam.Id;
        else
          this.m_NationalTeamId = -1;
      }
    }

    public int NationalTeamId
    {
      get
      {
        return this.m_NationalTeamId;
      }
      set
      {
        this.m_NationalTeamId = value;
      }
    }

    public Country(int countryid)
      : base(countryid)
    {
      this.m_nationname = "Country " + countryid.ToString();
      this.m_LanguageName = this.m_nationname;
      this.m_LanguageShortName = this.m_nationname;
      this.m_LanguageAbbreviation = "XXX";
      this.m_confederation = 0;
      this.m_top_tier = false;
      this.m_nationstartingfirstletter = 1;
      this.m_NationalTeamId = -1;
      this.m_NationalTeam = (Team)null;
      this.m_WorldCupTarget = 0;
      this.m_ContinentalCupTarget = 0;
      this.m_Level = 7;
      this.m_ChantRegionIndex = 1;
      this.m_PALanguageIndex = 0;
      this.m_ISOCountryCode = "XX";
      this.m_CrowdBedsRegionIndex = 0;
      this.m_WhistlesRegionIndex = 0;
      this.m_AmbienceRegionIndex = 0;
      this.m_PlayerCallPatchBankIndex = 0;
      this.m_HecklesRegionIndex = 0;
      this.m_TeamCanWhistleIndex = 0;
      this.m_ReactionsRegionIndex = 0;
    }

    public Country(Record r)
      : base(r.IntField[FI.nations_nationid])
    {
      this.m_WorldCupTarget = 0;
      this.m_ContinentalCupTarget = 0;
      this.m_Level = 7;
      this.Load(r);
    }

    public void Load(Record r)
    {
      this.Id = r.GetAndCheckIntField(FI.nations_nationid);
      this.m_nationname = r.StringField[FI.nations_nationname];
      this.m_ISOCountryCode = r.StringField[FI.nations_isocountrycode];
      this.m_confederation = r.GetAndCheckIntField(FI.nations_confederation) - 1;
      this.m_top_tier = r.GetAndCheckIntField(FI.nations_top_tier) != 0;
      this.m_nationstartingfirstletter = r.GetAndCheckIntField(FI.nations_nationstartingfirstletter);
      if (FifaEnvironment.Language != null)
      {
        this.m_LanguageName = FifaEnvironment.Language.GetCountryString(this.Id, Language.ECountryStringType.Full);
        this.m_LanguageShortName = FifaEnvironment.Language.GetCountryString(this.Id, Language.ECountryStringType.Abbr15);
        this.m_LanguageAbbreviation = FifaEnvironment.Language.GetCountryString(this.Id, Language.ECountryStringType.Abbr3);
      }
      else
      {
        this.m_LanguageName = string.Empty;
        this.m_LanguageShortName = string.Empty;
        this.m_LanguageAbbreviation = string.Empty;
      }
      if (this.m_LanguageName == null)
        this.m_LanguageName = this.m_nationname;
      //this.m_NationalTeamId = r.GetAndCheckIntField(FI.nations_teamid);
    }

    public void FillFromAudionation(Record r)
    {
      this.m_ChantRegionIndex = r.GetAndCheckIntField(FI.audionation_ChantRegionIndex);
      this.m_PALanguageIndex = r.GetAndCheckIntField(FI.audionation_PALanguageIndex);
      this.m_DefaultCommLang = r.StringField[FI.audionation_DefaultCommLang];
      this.m_CrowdBedsRegionIndex = r.GetAndCheckIntField(FI.audionation_CrowdBedsRegionIndex);
      this.m_WhistlesRegionIndex = r.GetAndCheckIntField(FI.audionation_WhistlesRegionIndex);
      this.m_AmbienceRegionIndex = r.GetAndCheckIntField(FI.audionation_AmbienceRegionIndex);
      this.m_PlayerCallPatchBankIndex = r.GetAndCheckIntField(FI.audionation_PlayerCallPatchBankIndex);
      this.m_HecklesRegionIndex = r.GetAndCheckIntField(FI.audionation_HecklesRegionIndex);
      this.m_TeamCanWhistleIndex = r.GetAndCheckIntField(FI.audionation_TeamCanWhistleIndex);
      this.m_ReactionsRegionIndex = r.GetAndCheckIntField(FI.audionation_ReactionsRegionIndex);
    }

    public void SaveAudionation(Record r)
    {
      r.IntField[FI.audionation_nationid] = this.Id;
      r.IntField[FI.audionation_ChantRegionIndex] = this.m_ChantRegionIndex;
      r.StringField[FI.audionation_DefaultCommLang] = this.m_DefaultCommLang;
      r.IntField[FI.audionation_PALanguageIndex] = this.m_PALanguageIndex;
      r.IntField[FI.audionation_CrowdBedsRegionIndex] = this.m_CrowdBedsRegionIndex;
      r.IntField[FI.audionation_WhistlesRegionIndex] = this.m_WhistlesRegionIndex;
      r.IntField[FI.audionation_AmbienceRegionIndex] = this.m_AmbienceRegionIndex;
      r.IntField[FI.audionation_PlayerCallPatchBankIndex] = this.m_PlayerCallPatchBankIndex;
      r.IntField[FI.audionation_HecklesRegionIndex] = this.m_HecklesRegionIndex;
      r.IntField[FI.audionation_TeamCanWhistleIndex] = this.m_TeamCanWhistleIndex;
      r.IntField[FI.audionation_ReactionsRegionIndex] = this.m_ReactionsRegionIndex;
    }

    public void LinkTeam(TeamList teamList)
    {
      if (teamList == null)
        return;
      this.m_NationalTeam = (Team)teamList.SearchId(this.m_NationalTeamId);
      //Team nationalTeam = this.m_NationalTeam;
    }

    public void SetNationalTeam(Team nationalTeam, int nationalTeamId)
    {
      if (nationalTeam != null)
        nationalTeamId = nationalTeam.Id;
      if (nationalTeamId <= 0)
        nationalTeam = (Team)null;
      Team nationalTeam1 = this.m_NationalTeam;
      int nationalTeamId1 = this.m_NationalTeamId;
      if (nationalTeam1 != null)
        nationalTeam1.NationalTeam = false;
      this.m_NationalTeam = nationalTeam;
      this.m_NationalTeamId = nationalTeamId;
      if (this.m_NationalTeam == null)
        return;
      this.m_NationalTeam.Country = this;
      this.m_NationalTeam.NationalTeam = true;
    }

    public void SaveCountry(Record r)
    {
      r.IntField[FI.nations_nationid] = this.Id;
      r.StringField[FI.nations_nationname] = this.m_nationname;
      r.StringField[FI.nations_isocountrycode] = this.m_ISOCountryCode;
      r.IntField[FI.nations_confederation] = this.m_confederation + 1;
      r.IntField[FI.nations_top_tier] = this.m_top_tier ? 1 : 0;
      r.IntField[FI.nations_nationstartingfirstletter] = this.m_nationstartingfirstletter;
      //r.IntField[FI.nations_teamid] = this.m_NationalTeamId;
    }

    public void SaveLangTable()
    {
      if (FifaEnvironment.Language == null)
        return;
      FifaEnvironment.Language.SetCountryString(this.Id, Language.ECountryStringType.Full, this.m_LanguageName);
      FifaEnvironment.Language.SetCountryString(this.Id, Language.ECountryStringType.Abbr15, this.m_LanguageShortName);
      FifaEnvironment.Language.SetCountryString(this.Id, Language.ECountryStringType.Abbr3, this.m_LanguageAbbreviation);
    }

    public override string ToString()
    {
      if (this.m_LanguageName != null && this.m_LanguageName != string.Empty)
        return this.m_LanguageName;
      return this.m_nationname != null ? this.m_nationname : string.Empty;
    }

    public string DatabaseString()
    {
      return this.m_nationname;
    }

    public string FlagBigFileName()
    {
      return Country.FlagBigFileName(this.Id);
    }

    public static string FlagTemplateBigFileName()
    {
      return FifaEnvironment.Year == 14 ? "data/ui/artassets/countryflags/2014_f_#.big" : "data/ui/artassets/countryflags/f_#.big";
    }

    public static string FlagTemplateDdsName()
    {
      return "2";
    }

    public static string FlagBigFileName(int id)
    {
      return "data/ui/artassets/countryflags/f_" + id.ToString() + ".big";
    }

    public Bitmap GetFlag()
    {
      return FifaEnvironment.GetArtasset(Country.FlagBigFileName(this.Id));
    }

    public bool SetFlag(Bitmap bitmap)
    {
      return FifaEnvironment.SetArtasset(Country.FlagTemplateBigFileName(), Country.FlagTemplateDdsName(), this.Id, bitmap);
    }

    public bool DeleteFlag()
    {
      return FifaEnvironment.DeleteFromZdata(this.FlagBigFileName());
    }

    public string Flag512TemplateFileName()
    {
      return "data/ui/imgassets/flags512x512/f_#.dds";
    }

    public string Flag512DdsFileName()
    {
      return "data/ui/imgassets/flags512x512/f_" + this.Id.ToString() + ".dds";
    }

    public static string Flag512DdsFileName(int id)
    {
      return "data/ui/imgassets/flags512x512/f_" + id.ToString() + ".dds";
    }

    public Bitmap GetFlag512()
    {
      return FifaEnvironment.GetDdsArtasset(this.Flag512DdsFileName());
    }

    public bool SetFlag512(Bitmap bitmap)
    {
      return FifaEnvironment.SetDdsArtasset(this.Flag512TemplateFileName(), this.Id, bitmap);
    }

    public bool DeleteFlag512()
    {
      return FifaEnvironment.DeleteFromZdata(this.Flag512DdsFileName());
    }

    public string MiniFlagBigFileName()
    {
      return Country.MiniFlagBigFileName(this.Id);
    }

    public static string MiniFlagTemplateBigFileName()
    {
      return FifaEnvironment.Year == 14 ? "data/ui/artassets/miniflags/2014_flag_#.big" : "data/ui/artassets/miniflags/flag_#.big";
    }

    public static string MiniFlagTemplateDdsName()
    {
      return "208";
    }

    public static string MiniFlagBigFileName(int id)
    {
      return "data/ui/artassets/miniflags/flag_" + id.ToString() + ".big";
    }

    public Bitmap GetMiniFlag()
    {
      return FifaEnvironment.GetArtasset(Country.MiniFlagBigFileName(this.Id));
    }

    public bool SetMiniFlag(Bitmap bitmap)
    {
      return FifaEnvironment.SetArtasset(Country.MiniFlagTemplateBigFileName(), Country.MiniFlagTemplateDdsName(), this.Id, bitmap);
    }

    public bool DeleteMiniFlag()
    {
      return FifaEnvironment.DeleteFromZdata(this.MiniFlagBigFileName());
    }

    public bool Fit(string lowerName, int id)
    {
      return this.m_nationname != null && this.m_nationname.ToLower() == lowerName || this.m_LanguageName != null && this.m_LanguageName.ToLower() == lowerName;
    }

    public string ShapeFileName()
    {
      return Country.ShapeFileName(this.Id);
    }

    public static string ShapeFileName(int countryid)
    {
      return "data/ui/imgassets/tiles/careerhub/countryshapes/c" + countryid.ToString() + ".dds";
    }

    public string ShapeTemplateFileName()
    {
      return "data/ui/imgassets/tiles/careerhub/countryshapes/c#.dds";
    }

    public Bitmap GetShape()
    {
      return FifaEnvironment.GetDdsArtasset(this.ShapeFileName());
    }

    public static Bitmap GetShape(int countryId)
    {
      return FifaEnvironment.GetDdsArtasset(Country.ShapeFileName(countryId));
    }

    public bool SetShape(Bitmap bitmap)
    {
      return FifaEnvironment.SetDdsArtasset(this.ShapeTemplateFileName(), this.Id, bitmap);
    }

    public bool DeleteShape()
    {
      return FifaEnvironment.DeleteFromZdata(this.ShapeFileName());
    }

    public enum EConfederation
    {
      None = 1,
      Europe = 2,
      Africa = 3,
      South_America = 4,
      Asia = 5,
      Oceania = 6,
      North_America = 7,
    }
  }
}
