// Original code created by Rinaldo

using System.Collections.Generic;

namespace FifaLibrary
{
  public class Language : Dictionary<int, string>
  {
    private Dictionary<int, string> m_Conventional;
    private Table m_LangTable;

    public Language(Table langTable)
    {
      this.m_LangTable = langTable;
      this.m_Conventional = new Dictionary<int, string>();
      this.Load(this.m_LangTable);
    }

    public void Load(Table langTable)
    {
      this.Clear();
      this.m_Conventional.Clear();
      for (int index = 0; index < langTable.NRecords; ++index)
      {
        Record record = langTable.Records[index];
        int key = record.IntField[FI.language_hashid];
        if (!this.ContainsKey(key))
        {
          string str1 = record.CompressedString[FI.language_sourcetext];
          this.Add(key, str1);
          string str2 = record.CompressedString[FI.language_stringid];
          this.m_Conventional.Add(key, str2);
        }
      }
    }

    public void Save(Table langTable)
    {
      langTable.ResizeRecords(this.Count);
      langTable.NValidRecords = this.Count;
      int index = 0;
      foreach (KeyValuePair<int, string> keyValuePair in (Dictionary<int, string>) this)
      {
        Record record = langTable.Records[index];
        ++index;
        record.IntField[FI.language_hashid] = keyValuePair.Key;
        string empty;
        if (!this.m_Conventional.TryGetValue(keyValuePair.Key, out empty))
          empty = string.Empty;
        record.CompressedString[FI.language_sourcetext] = keyValuePair.Value == null ? string.Empty : keyValuePair.Value;
        record.CompressedString[FI.language_stringid] = empty;
      }
    }

    public uint GetTournamentHash(int assetId, Language.ETournamentStringType stringType)
    {
      return FifaUtil.ComputeLanguageHash(this.GetTournamentConventionalString(assetId, stringType));
    }

    public string GetTournamentConventionalString(
      int assetId,
      Language.ETournamentStringType stringType)
    {
      string str;
      switch (stringType)
      {
        case Language.ETournamentStringType.Full:
          str = "TrophyName_";
          break;
        case Language.ETournamentStringType.Abbr15:
          str = "TrophyName_Abbr15_";
          break;
        default:
          return (string) null;
      }
      return str + assetId.ToString();
    }

    public string GetTournamentString(int assetId, Language.ETournamentStringType stringType)
    {
      string conventionalString = this.GetTournamentConventionalString(assetId, stringType);
      return conventionalString == null ? string.Empty : this.GetString(conventionalString);
    }

    public void SetTournamentString(
      int assetId,
      Language.ETournamentStringType stringType,
      string name)
    {
      string conventionalString = this.GetTournamentConventionalString(assetId, stringType);
      if (conventionalString == null)
        return;
      this.SetString(conventionalString, name);
    }

    public void RemoveTournamentString(int assetId, Language.ETournamentStringType stringType)
    {
      string conventionalString = this.GetTournamentConventionalString(assetId, stringType);
      if (conventionalString == null)
        return;
      this.RemoveString(conventionalString);
    }

    public uint GetFormationtHash(int formationFullNameId)
    {
      return FifaUtil.ComputeLanguageHash(this.GetFormationConventionalString(formationFullNameId));
    }

    public string GetFormationConventionalString(int formationFullNameId)
    {
      return "Formation_FullName_" + formationFullNameId.ToString();
    }

    public string GetFormationString(int formationFullNameId)
    {
      if (formationFullNameId < 0)
        return (string) null;
      string conventionalString = this.GetFormationConventionalString(formationFullNameId);
      return conventionalString == null ? string.Empty : this.GetString(conventionalString);
    }

    public void SetFormationString(int formationFullNameId, string name)
    {
      string conventionalString = this.GetFormationConventionalString(formationFullNameId);
      if (conventionalString == null)
        return;
      this.SetString(conventionalString, name);
    }

    public void RemoveFormationString(int assetId)
    {
      string conventionalString = this.GetFormationConventionalString(assetId);
      if (conventionalString == null)
        return;
      this.RemoveString(conventionalString);
    }

    public uint GetLeagueHash(int assetId, Language.ELeagueStringType stringType)
    {
      return FifaUtil.ComputeLanguageHash(this.GetLeagueConventionalString(assetId, stringType));
    }

    private string GetLeagueConventionalString(int assetId, Language.ELeagueStringType stringType)
    {
      string str;
      switch (stringType)
      {
        case Language.ELeagueStringType.Full:
          str = "LeagueName_";
          break;
        case Language.ELeagueStringType.Abbr15:
          str = "LeagueName_Abbr15_";
          break;
        default:
          return (string) null;
      }
      return str + assetId.ToString();
    }

    public string GetLeagueString(int assetId, Language.ELeagueStringType stringType)
    {
      string conventionalString = this.GetLeagueConventionalString(assetId, stringType);
      return conventionalString == null ? string.Empty : this.GetString(conventionalString);
    }

    public void SetLeagueString(int assetId, Language.ELeagueStringType stringType, string name)
    {
      string conventionalString = this.GetLeagueConventionalString(assetId, stringType);
      if (conventionalString == null)
        return;
      this.SetString(conventionalString, name);
    }

    public void RemoveLeagueString(int assetId, Language.ELeagueStringType stringType)
    {
      string conventionalString = this.GetLeagueConventionalString(assetId, stringType);
      if (conventionalString == null)
        return;
      this.RemoveString(conventionalString);
    }

    public uint GetStadiumHash(int id)
    {
      return FifaUtil.ComputeLanguageHash(this.GetStadiumConventionalString(id));
    }

    private string GetStadiumConventionalString(int stadiumId)
    {
      return "StadiumName_" + stadiumId.ToString();
    }

    public string GetStadiumName(int stadiumId)
    {
      return this.GetString(this.GetStadiumConventionalString(stadiumId));
    }

    public void SetStadiumName(int stadiumId, string stadiumName)
    {
      this.SetString(this.GetStadiumConventionalString(stadiumId), stadiumName);
    }

    public void RemoveStadiumName(int stadiumId)
    {
      this.RemoveString(this.GetStadiumConventionalString(stadiumId));
    }

    public uint GetBallHash(int id)
    {
      return FifaUtil.ComputeLanguageHash(this.GetBallConventionalString(id, true));
    }

    private string GetBallConventionalString(int ballId, bool isGeneric)
    {
      return !isGeneric ? "BallName_" + ballId.ToString() : "ballname_" + ballId.ToString();
    }

    public string GetBallName(int ballId, out bool isGeneric)
    {
      string conventionalString1 = this.GetBallConventionalString(ballId, true);
      int languageHash = (int) FifaUtil.ComputeLanguageHash(conventionalString1);
      string str = this.GetString(languageHash);
      string conventionalString2 = this.GetConventionalString(languageHash);
      isGeneric = conventionalString2 == conventionalString1;
      return str;
    }

    public void SetBallName(int ballId, string ballName, bool isGeneric)
    {
      this.SetString(this.GetBallConventionalString(ballId, isGeneric), ballName);
    }

    public void RemoveBallName(int ballId)
    {
      this.RemoveString(this.GetBallConventionalString(ballId, true));
    }

    public uint GetShoesHash(int id)
    {
      return FifaUtil.ComputeLanguageHash(this.GetShoesConventionalString(id));
    }

    private string GetShoesConventionalString(int ShoesId)
    {
      return "CreatePlayerBoot_" + ShoesId.ToString();
    }

    public string GetShoesName(int ShoesId)
    {
      return this.GetString((int) FifaUtil.ComputeLanguageHash(this.GetShoesConventionalString(ShoesId)));
    }

    public void SetShoesName(int ShoesId, string ShoesName)
    {
      this.SetString(this.GetShoesConventionalString(ShoesId), ShoesName);
    }

    public void RemoveShoesName(int ShoesId)
    {
      this.RemoveString(this.GetShoesConventionalString(ShoesId));
    }

    public uint GetCountryHash(int countryId, Language.ECountryStringType stringType)
    {
      return FifaUtil.ComputeLanguageHash(this.GetCountryConventionalString(countryId, stringType));
    }

    public string GetCountryConventionalString(
      int countryId,
      Language.ECountryStringType stringType)
    {
      switch (stringType)
      {
        case Language.ECountryStringType.Full:
          return "NationName_" + countryId.ToString();
        case Language.ECountryStringType.Abbr3:
          return "nationname_abbr3_" + countryId.ToString();
        case Language.ECountryStringType.Abbr15:
          return "NationName_" + countryId.ToString() + "_abbr_15";
        case Language.ECountryStringType.Abbr2:
          return "nationname_abbr2_" + countryId.ToString();
        default:
          return (string) null;
      }
    }

    public string GetCountryString(int countryId, Language.ECountryStringType stringType)
    {
      return this.GetString(this.GetCountryConventionalString(countryId, stringType));
    }

    public void SetCountryString(
      int countryId,
      Language.ECountryStringType stringType,
      string countryName)
    {
      this.SetString(this.GetCountryConventionalString(countryId, stringType), countryName);
    }

    public void RemoveCountryStrings(int countryId)
    {
      this.RemoveString(this.GetCountryConventionalString(countryId, Language.ECountryStringType.Abbr15));
      this.RemoveString(this.GetCountryConventionalString(countryId, Language.ECountryStringType.Abbr3));
      this.RemoveString(this.GetCountryConventionalString(countryId, Language.ECountryStringType.Full));
      this.RemoveString(this.GetCountryConventionalString(countryId, Language.ECountryStringType.Abbr2));
    }

    public void RemoveCountryString(int countryId, Language.ECountryStringType stringType)
    {
      this.RemoveString(this.GetCountryConventionalString(countryId, stringType));
    }

    private string GetRoleLongConventionalString(int roleId)
    {
      return "SoccerFormationPosFull_" + roleId.ToString();
    }

    private string GetRoleShortConventionalString(int roleId)
    {
      string str = "SoccerFormationPos_Abbr4_";
      switch (roleId)
      {
        case 0:
          return str + "GK";
        case 1:
          return str + "SW";
        case 2:
          return str + "RWB";
        case 3:
          return str + "RB";
        case 4:
          return str + "RCB";
        case 5:
          return str + "CB";
        case 6:
          return str + "LCB";
        case 7:
          return str + "LB";
        case 8:
          return str + "LWB";
        case 9:
          return str + "RDM";
        case 10:
          return str + "CDM";
        case 11:
          return str + "LDM";
        case 12:
          return str + "RM";
        case 13:
          return str + "RCM";
        case 14:
          return str + "CM";
        case 15:
          return str + "LCM";
        case 16:
          return str + "LM";
        case 17:
          return str + "RAM";
        case 18:
          return str + "CAM";
        case 19:
          return str + "LAM";
        case 20:
          return str + "RF";
        case 21:
          return str + "CF";
        case 22:
          return str + "LF";
        case 23:
          return str + "RW";
        case 24:
          return str + "RS";
        case 25:
          return str + "ST";
        case 26:
          return str + "LS";
        case 27:
          return str + "LW";
        default:
          return (string) null;
      }
    }

    public string GetRoleShortString(int roleId)
    {
      string stringConventional;
      switch (roleId)
      {
        case 28:
          stringConventional = "Substitute";
          break;
        case 29:
          stringConventional = "Reserve";
          break;
        default:
          stringConventional = this.GetRoleShortConventionalString(roleId);
          break;
      }
      string str = this.GetString(stringConventional);
      if (str == null || str == string.Empty)
        str = stringConventional;
      return str;
    }

    public void SetRoleShortString(int roleId, string roleShortName)
    {
      this.SetString(this.GetRoleShortConventionalString(roleId), roleShortName);
    }

    public string GetRoleLongString(int roleId)
    {
      return this.GetString(this.GetRoleLongConventionalString(roleId));
    }

    public void SetRoleLongString(int roleId, string roleLongName)
    {
      this.SetString(this.GetRoleLongConventionalString(roleId), roleLongName);
    }

    public uint GetSponsorDescriptionHash(int id)
    {
      return FifaUtil.ComputeLanguageHash(this.GetSponsorDescrConventionalString(id));
    }

    public uint GetSponsorNameHash(int id)
    {
      return FifaUtil.ComputeLanguageHash(this.GetSponsorNameConventionalString(id));
    }

    private string GetSponsorNameConventionalString(int sponsorId)
    {
      return "mm_Sponsor" + sponsorId.ToString();
    }

    private string GetSponsorDescrConventionalString(int sponsorId)
    {
      return "mm_SponsorBio" + sponsorId.ToString();
    }

    public string GetSponsorName(int sponsorId)
    {
      return this.GetString(this.GetSponsorNameConventionalString(sponsorId));
    }

    public string GetSponsorDescription(int sponsorId)
    {
      return this.GetString(this.GetSponsorDescrConventionalString(sponsorId));
    }

    public void SetSponsorName(int sponsorId, string sponsorName)
    {
      this.SetString(this.GetSponsorNameConventionalString(sponsorId), sponsorName);
    }

    public void SetSponsorDescription(int sponsorId, string sponsorDesc)
    {
      this.SetString(this.GetSponsorDescrConventionalString(sponsorId), sponsorDesc);
    }

    public void RemoveSponsorName(int sponsorId)
    {
      this.RemoveString(this.GetSponsorNameConventionalString(sponsorId));
    }

    public void RemoveSponsorDescription(int sponsorId)
    {
      this.RemoveString(this.GetSponsorDescrConventionalString(sponsorId));
    }

    public uint GetTeamHash(int teamId, Language.ETeamStringType stringType)
    {
      return FifaUtil.ComputeLanguageHash(this.GetTeamConventionalString(teamId, stringType));
    }

    public string GetTeamConventionalString(int teamId, Language.ETeamStringType stringType)
    {
      string str;
      switch (stringType)
      {
        case Language.ETeamStringType.Full:
          str = "TeamName_";
          break;
        case Language.ETeamStringType.Abbr3:
          str = "TeamName_Abbr3_";
          break;
        case Language.ETeamStringType.Abbr10:
          str = "TeamName_Abbr10_";
          break;
        case Language.ETeamStringType.Abbr15:
          str = "TeamName_Abbr15_";
          break;
        case Language.ETeamStringType.Abbr7:
          str = "TeamName_Abbr7_";
          break;
        default:
          return (string) null;
      }
      return str + teamId.ToString();
    }

    public string GetTeamString(int teamId, Language.ETeamStringType stringType)
    {
      return this.GetString(this.GetTeamConventionalString(teamId, stringType));
    }

    public void SetTeamString(int teamId, Language.ETeamStringType stringType, string teamName)
    {
      this.SetString(this.GetTeamConventionalString(teamId, stringType), teamName);
    }

    public void RemoveTeamStrings(int teamId)
    {
      this.RemoveString(this.GetTeamConventionalString(teamId, Language.ETeamStringType.Abbr10));
      this.RemoveString(this.GetTeamConventionalString(teamId, Language.ETeamStringType.Abbr15));
      this.RemoveString(this.GetTeamConventionalString(teamId, Language.ETeamStringType.Abbr3));
      this.RemoveString(this.GetTeamConventionalString(teamId, Language.ETeamStringType.Abbr7));
      this.RemoveString(this.GetTeamConventionalString(teamId, Language.ETeamStringType.Full));
    }

    public void RemoveTeamString(int teamId, Language.ETeamStringType stringType)
    {
      this.RemoveString(this.GetTeamConventionalString(teamId, Language.ETeamStringType.Abbr10));
    }

    public string GetString(int key)
    {
      string str;
      return this.TryGetValue(key, out str) ? str : (string) null;
    }

    public string GetConventionalString(int key)
    {
      string str;
      return this.m_Conventional.TryGetValue(key, out str) ? str : (string) null;
    }

    public string GetString(string stringConventional)
    {
      string str;
      return this.TryGetValue((int) FifaUtil.ComputeLanguageHash(stringConventional), out str) ? str : (string) null;
    }

    public void SetString(string stringConventional, string stringValue)
    {
      this.SetString((int) FifaUtil.ComputeLanguageHash(stringConventional), stringConventional, stringValue);
    }

    public void SetString(int key, string stringConventional, string stringValue)
    {
      if (this.ContainsKey(key))
        this.Remove(key);
      this.Add(key, stringValue);
      if (this.m_Conventional.ContainsKey(key))
        this.m_Conventional.Remove(key);
      this.m_Conventional.Add(key, stringConventional);
    }

    public void RemoveString(int key)
    {
      if (this.ContainsKey(key))
        this.Remove(key);
      if (!this.m_Conventional.ContainsKey(key))
        return;
      this.m_Conventional.Remove(key);
    }

    public void RemoveString(string stringConventional)
    {
      this.RemoveString((int) FifaUtil.ComputeLanguageHash(stringConventional));
    }

    public enum ETournamentStringType
    {
      Full,
      Abbr15,
    }

    public enum ELeagueStringType
    {
      Full,
      Abbr15,
    }

    public enum ECountryStringType
    {
      Full,
      Abbr3,
      Abbr15,
      Abbr2,
    }

    public enum ETeamStringType
    {
      Full,
      Abbr3,
      Abbr10,
      Abbr15,
      Abbr7,
    }
  }
}
