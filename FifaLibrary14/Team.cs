// Original code created by Rinaldo

using System.Collections;
using System.Drawing;

namespace FifaLibrary
{
  public class Team : IdObject
  {
    private static int[] c_TopLeaguesId = new int[6]
    {
      13,
      16,
      19,
      31,
      53,
      341
    };
    private int m_balltype = 1;
    private int m_adboardid = 1;
    private int m_stadiumid = 1;
    private Roster m_Roster = new Roster(32);
    public KitList m_KitList = new KitList();
    private int[] m_teamkitidList = new int[10]
    {
      -1,
      -1,
      -1,
      -1,
      -1,
      -1,
      -1,
      -1,
      -1,
      -1
    };
    private bool m_ImpatientBoard;
    private bool m_LoyalBoard;
    private bool m_SquadRotation;
    private bool m_ConsistentLineup;
    private bool m_SwitchWingers;
    private bool m_CenterBacksSplit;
    private bool m_DefendLead;
    private bool m_KeepUpPressure;
    private bool m_MoreAttackingAtHome;
    private bool m_ShortOutBack;
    private Ball m_Ball;
    private bool m_HasSpecificAdboard;
    private Stadium m_Stadium;
    private int m_rivalteam;
    private Team m_RivalTeam;
    private int m_formationid;
    private Formation m_Formation;
    private int m_captainid;
    private int m_penaltytakerid;
    private int m_leftfreekicktakerid;
    private int m_rightfreekicktakerid;
    private int m_freekicktakerid;
    private int m_longkicktakerid;
    private int m_leftcornerkicktakerid;
    private int m_rightcornerkicktakerid;
    public Player PlayerCaptain;
    public Player PlayerPenalty;
    public Player PlayerFreeKick;
    public Player PlayerLeftFreeKick;
    public Player PlayerRightFreeKick;
    public Player PlayerLongKick;
    public Player PlayerLeftCorner;
    public Player PlayerRightCorner;
    private string m_TeamNameFull;
    private string m_TeamNameAbbr15;
    private string m_TeamNameAbbr10;
    private string m_TeamNameAbbr3;
    private string m_TeamNameAbbr7;
    private string m_teamname;
    private int m_jerseytype;
    private int m_fancrowdhairskintexturecode;
    private int m_stafftracksuitcolorcode;
    private int m_physioid_primary;
    private int m_physioid_secondary;
    private int m_teamcolor1r;
    private int m_teamcolor1g;
    private int m_teamcolor1b;
    private Color m_TeamColor1;
    private Color m_TeamColor2;
    private Color m_TeamColor3;
    private int m_teamcolor2r;
    private int m_teamcolor2g;
    private int m_teamcolor2b;
    private int m_teamcolor3r;
    private int m_teamcolor3g;
    private int m_teamcolor3b;
    private int m_form;
    private int m_managerid;
    private int m_latitude;
    private int m_longitude;
    private int m_bodytypeid;
    private int m_suitvariationid;
    private int m_suittypeid;
    private int m_personalityid;
    private int m_busdribbling;
    private int m_trait1;
    private int m_utcoffset;
    private int m_ethnicity;
    private int m_powid;
    public bool m_genericbanner;
    private int m_assetid;
    private int m_transferbudget;
    private int m_internationalprestige;
    private int m_domesticprestige;
    private int m_numtransfersin;
    private string m_stadiumcustomname;
    private string m_ManagerFirstName;
    private string m_ManagerSurname;
    private int m_busbuildupspeed;
    private int m_buspassing;
    private int m_buspositioning;
    private int m_ccpassing;
    private int m_cccrossing;
    private int m_ccshooting;
    private int m_ccpositioning;
    private int m_defmentality;
    private int m_defaggression;
    private int m_defteamwidth;
    private int m_defdefenderline;
    private int m_genericint2;
    private int m_genericint1;
    private int m_midfieldrating;
    private int m_defenserating;
    private int m_attackrating;
    private int m_overallrating;
    private int m_matchdayoverallrating;
    private int m_matchdaydefenserating;
    private int m_matchdaymidfieldrating;
    private int m_matchdayattackrating;
    private int m_countryid_IfNationalTeam;
    public int m_countryid_IfRowTeam;
    private Country m_Country;
    private int m_leagueid;
    private League m_League;
    private int m_prevleagueid;
    private League m_PrevLeague;
    private bool m_champion;
    private int m_previousyeartableposition;
    private int m_currenttableposition;
    private int m_teamshortform;
    private int m_teamlongform;
    private int m_teamform;
    private bool m_hasachievedobjective;
    private bool m_yettowin;
    private bool m_unbeatenallcomps;
    private bool m_unbeatenaway;
    private bool m_unbeatenhome;
    private bool m_unbeatenleague;
    private int m_highestpossible;
    private int m_highestprobable;
    private int m_nummatchesplayed;
    private int m_gapresult;
    private int m_grouping;
    private int m_objective;
    private int m_actualvsexpectations;
    private int m_lastgameresult;
    private int m_homega;
    private int m_homegf;
    private int m_points;
    private int m_awayga;
    private int m_secondarytable;
    private int m_homewins;
    private int m_awaywins;
    private int m_homelosses;
    private int m_awaylosses;
    private int m_awaydraws;
    private int m_homedraws;

    public bool IsInTopLeague()
    {
      if (this.m_League == null)
        return false;
      for (int index = 0; index < Team.c_TopLeaguesId.Length; ++index)
      {
        if (this.m_League.Id == Team.c_TopLeaguesId[index])
          return true;
      }
      return false;
    }

    public bool ImpatientBoard
    {
      get
      {
        return this.m_ImpatientBoard;
      }
      set
      {
        this.m_ImpatientBoard = value;
      }
    }

    public bool LoyalBoard
    {
      get
      {
        return this.m_LoyalBoard;
      }
      set
      {
        this.m_LoyalBoard = value;
      }
    }

    public bool SquadRotation
    {
      get
      {
        return this.m_SquadRotation;
      }
      set
      {
        this.m_SquadRotation = value;
      }
    }

    public bool ConsistentLineup
    {
      get
      {
        return this.m_ConsistentLineup;
      }
      set
      {
        this.m_ConsistentLineup = value;
      }
    }

    public bool SwitchWingers
    {
      get
      {
        return this.m_SwitchWingers;
      }
      set
      {
        this.m_SwitchWingers = value;
      }
    }

    public bool CenterBacksSplit
    {
      get
      {
        return this.m_CenterBacksSplit;
      }
      set
      {
        this.m_CenterBacksSplit = value;
      }
    }

    public bool DefendLead
    {
      get
      {
        return this.m_DefendLead;
      }
      set
      {
        this.m_DefendLead = value;
      }
    }

    public bool KeepUpPressure
    {
      get
      {
        return this.m_KeepUpPressure;
      }
      set
      {
        this.m_KeepUpPressure = value;
      }
    }

    public bool MoreAttackingAtHome
    {
      get
      {
        return this.m_MoreAttackingAtHome;
      }
      set
      {
        this.m_MoreAttackingAtHome = value;
      }
    }

    public bool ShortOutBack
    {
      get
      {
        return this.m_ShortOutBack;
      }
      set
      {
        this.m_ShortOutBack = value;
      }
    }

    public int balltype
    {
      get
      {
        return this.m_balltype;
      }
      set
      {
        this.m_balltype = value;
      }
    }

    public int adboardid
    {
      get
      {
        return this.m_adboardid;
      }
      set
      {
        this.m_adboardid = value;
      }
    }

    public bool HasSpecifiAdboard
    {
      get
      {
        return this.m_HasSpecificAdboard;
      }
      set
      {
        this.m_HasSpecificAdboard = value;
      }
    }

    public Bitmap GetAdboard()
    {
      Bitmap adboard = Adboard.GetAdboard(1000000 + this.Id);
      if (adboard == null)
      {
        adboard = Adboard.GetAdboard(this.adboardid);
        this.m_HasSpecificAdboard = false;
      }
      else
        this.m_HasSpecificAdboard = true;
      return adboard;
    }

    public bool SetAdboard(Bitmap bitmap)
    {
      return this.m_HasSpecificAdboard ? Adboard.SetAdboard(1000000 + this.Id, bitmap) : Adboard.SetAdboard(this.adboardid, bitmap);
    }

    public bool CreateSpecificAdboard()
    {
      int adboardId = 1000000 + this.Id;
      Bitmap adboard = Adboard.GetAdboard(this.adboardid);
      for (int index = 0; index < 20 && adboard == null; ++index)
        adboard = Adboard.GetAdboard(this.adboardid);
      this.m_HasSpecificAdboard = true;
      return Adboard.SetAdboard(adboardId, adboard);
    }

    public bool DeleteSpecificAdboard()
    {
      int adboardId = 1000000 + this.Id;
      this.m_HasSpecificAdboard = false;
      return Adboard.DeleteAdboard(adboardId);
    }

    public int stadiumid
    {
      get
      {
        return this.m_stadiumid;
      }
      set
      {
        this.m_stadiumid = value;
      }
    }

    public Stadium Stadium
    {
      get
      {
        return this.m_Stadium;
      }
      set
      {
        this.m_Stadium = value;
        if (this.m_Stadium == null)
          return;
        this.m_stadiumid = this.m_Stadium.Id;
      }
    }

    public int rivalteam
    {
      get
      {
        return this.m_rivalteam;
      }
      set
      {
        this.m_rivalteam = value;
      }
    }

    public Team RivalTeam
    {
      get
      {
        return this.m_RivalTeam;
      }
      set
      {
        this.m_RivalTeam = value;
        if (this.m_RivalTeam == null)
          return;
        this.m_rivalteam = this.m_RivalTeam.Id;
      }
    }

    public int formationid
    {
      get
      {
        return this.m_formationid;
      }
      set
      {
        this.m_formationid = value;
      }
    }

    public Formation Formation
    {
      get
      {
        return this.m_Formation;
      }
      set
      {
        this.m_Formation = value;
        if (this.m_Formation == null)
          return;
        this.m_formationid = this.m_Formation.Id;
      }
    }

    public int captainid
    {
      get
      {
        return this.m_captainid;
      }
      set
      {
        this.m_captainid = value;
      }
    }

    public int penaltytakerid
    {
      get
      {
        return this.m_penaltytakerid;
      }
      set
      {
        this.m_penaltytakerid = value;
      }
    }

    public int leftfreekicktakerid
    {
      get
      {
        return this.m_leftfreekicktakerid;
      }
      set
      {
        this.m_leftfreekicktakerid = value;
      }
    }

    public int rightfreekicktakerid
    {
      get
      {
        return this.m_rightfreekicktakerid;
      }
      set
      {
        this.m_rightfreekicktakerid = value;
      }
    }

    public int freekicktakerid
    {
      get
      {
        return this.m_freekicktakerid;
      }
      set
      {
        this.m_freekicktakerid = value;
      }
    }

    public int longkicktakerid
    {
      get
      {
        return this.m_longkicktakerid;
      }
      set
      {
        this.m_longkicktakerid = value;
      }
    }

    public int leftcornerkicktakerid
    {
      get
      {
        return this.m_leftcornerkicktakerid;
      }
      set
      {
        this.m_leftcornerkicktakerid = value;
      }
    }

    public int rightcornerkicktakerid
    {
      get
      {
        return this.m_rightcornerkicktakerid;
      }
      set
      {
        this.m_rightcornerkicktakerid = value;
      }
    }

    public string TeamNameFull
    {
      get
      {
        return this.m_TeamNameFull;
      }
      set
      {
        this.m_TeamNameFull = value;
      }
    }

    public string TeamNameAbbr15
    {
      get
      {
        return this.m_TeamNameAbbr15;
      }
      set
      {
        this.m_TeamNameAbbr15 = value;
      }
    }

    public string TeamNameAbbr10
    {
      get
      {
        return this.m_TeamNameAbbr10;
      }
      set
      {
        this.m_TeamNameAbbr10 = value;
      }
    }

    public string TeamNameAbbr3
    {
      get
      {
        return this.m_TeamNameAbbr3;
      }
      set
      {
        this.m_TeamNameAbbr3 = value;
      }
    }

    public string TeamNameAbbr7
    {
      get
      {
        return this.m_TeamNameAbbr7;
      }
      set
      {
        this.m_TeamNameAbbr7 = value;
      }
    }

    public string DatabaseName
    {
      get
      {
        return this.m_teamname;
      }
      set
      {
        this.m_teamname = value;
      }
    }

    public int jerseytype
    {
      get
      {
        return this.m_jerseytype;
      }
      set
      {
        this.m_jerseytype = value;
      }
    }

    public int stafftracksuitcolorcode
    {
      get
      {
        return this.m_stafftracksuitcolorcode;
      }
      set
      {
        this.m_stafftracksuitcolorcode = value;
      }
    }

    public Color TeamColor1
    {
      get
      {
        return this.m_TeamColor1;
      }
      set
      {
        this.m_TeamColor1 = value;
      }
    }

    public Color TeamColor2
    {
      get
      {
        return this.m_TeamColor2;
      }
      set
      {
        this.m_TeamColor2 = value;
      }
    }

    public Color TeamColor3
    {
      get
      {
        return this.m_TeamColor3;
      }
      set
      {
        this.m_TeamColor3 = value;
      }
    }

    public int managerid
    {
      get
      {
        return this.m_managerid;
      }
      set
      {
        this.m_managerid = value;
      }
    }

    public int latitude
    {
      get
      {
        return this.m_latitude;
      }
      set
      {
        this.m_latitude = value;
      }
    }

    public int longitude
    {
      get
      {
        return this.m_longitude;
      }
      set
      {
        this.m_longitude = value;
      }
    }

    public int bodytypeid
    {
      get
      {
        return this.m_bodytypeid;
      }
      set
      {
        this.m_bodytypeid = value;
      }
    }

    public int suitvariationid
    {
      get
      {
        return this.m_suitvariationid;
      }
      set
      {
        this.m_suitvariationid = value;
      }
    }

    public int suittypeid
    {
      get
      {
        return this.m_suittypeid;
      }
      set
      {
        this.m_suittypeid = value;
      }
    }

    public int personalityid
    {
      get
      {
        return this.m_personalityid;
      }
      set
      {
        this.m_personalityid = value;
      }
    }

    public int busdribbling
    {
      get
      {
        return this.m_busdribbling;
      }
      set
      {
        this.m_busdribbling = value;
      }
    }

    public int trait1
    {
      get
      {
        return this.m_trait1;
      }
      set
      {
        this.m_trait1 = value;
      }
    }

    public int utcoffset
    {
      get
      {
        return this.m_utcoffset;
      }
      set
      {
        this.m_utcoffset = value;
      }
    }

    public int ethnicity
    {
      get
      {
        return this.m_ethnicity;
      }
      set
      {
        this.m_ethnicity = value;
      }
    }

    public int assetid
    {
      get
      {
        return this.m_assetid;
      }
      set
      {
        this.m_assetid = value;
      }
    }

    public int transferbudget
    {
      get
      {
        return this.m_transferbudget;
      }
      set
      {
        this.m_transferbudget = value;
      }
    }

    public int internationalprestige
    {
      get
      {
        return this.m_internationalprestige;
      }
      set
      {
        this.m_internationalprestige = value;
      }
    }

    public int domesticprestige
    {
      get
      {
        return this.m_domesticprestige;
      }
      set
      {
        this.m_domesticprestige = value;
      }
    }

    public string stadiumcustomname
    {
      get
      {
        return this.m_stadiumcustomname;
      }
      set
      {
        this.m_stadiumcustomname = value;
      }
    }

    public string ManagerFirstName
    {
      get
      {
        return this.m_ManagerFirstName;
      }
      set
      {
        this.m_ManagerFirstName = value;
      }
    }

    public string ManagerSurname
    {
      get
      {
        return this.m_ManagerSurname;
      }
      set
      {
        this.m_ManagerSurname = value;
      }
    }

    public int busbuildupspeed
    {
      get
      {
        return this.m_busbuildupspeed;
      }
      set
      {
        this.m_busbuildupspeed = value;
      }
    }

    public int buspassing
    {
      get
      {
        return this.m_buspassing;
      }
      set
      {
        this.m_buspassing = value;
      }
    }

    public int buspositioning
    {
      get
      {
        return this.m_buspositioning;
      }
      set
      {
        this.m_buspositioning = value;
      }
    }

    public int ccpassing
    {
      get
      {
        return this.m_ccpassing;
      }
      set
      {
        this.m_ccpassing = value;
      }
    }

    public int cccrossing
    {
      get
      {
        return this.m_cccrossing;
      }
      set
      {
        this.m_cccrossing = value;
      }
    }

    public int ccshooting
    {
      get
      {
        return this.m_ccshooting;
      }
      set
      {
        this.m_ccshooting = value;
      }
    }

    public int ccpositioning
    {
      get
      {
        return this.m_ccpositioning;
      }
      set
      {
        this.m_ccpositioning = value;
      }
    }

    public int defmentality
    {
      get
      {
        return this.m_defmentality;
      }
      set
      {
        this.m_defmentality = value;
      }
    }

    public int defaggression
    {
      get
      {
        return this.m_defaggression;
      }
      set
      {
        this.m_defaggression = value;
      }
    }

    public int defteamwidth
    {
      get
      {
        return this.m_defteamwidth;
      }
      set
      {
        this.m_defteamwidth = value;
      }
    }

    public int defdefenderline
    {
      get
      {
        return this.m_defdefenderline;
      }
      set
      {
        this.m_defdefenderline = value;
      }
    }

    public int midfieldrating
    {
      get
      {
        return this.m_midfieldrating;
      }
      set
      {
        this.m_midfieldrating = value;
      }
    }

    public int defenserating
    {
      get
      {
        return this.m_defenserating;
      }
      set
      {
        this.m_defenserating = value;
      }
    }

    public int attackrating
    {
      get
      {
        return this.m_attackrating;
      }
      set
      {
        this.m_attackrating = value;
      }
    }

    public int overallrating
    {
      get
      {
        return this.m_overallrating;
      }
      set
      {
        this.m_overallrating = value;
      }
    }

    public int matchdayoverallrating
    {
      get
      {
        return this.m_matchdayoverallrating;
      }
      set
      {
        this.m_matchdayoverallrating = value;
      }
    }

    public int matchdaydefenserating
    {
      get
      {
        return this.m_matchdaydefenserating;
      }
      set
      {
        this.m_matchdaydefenserating = value;
      }
    }

    public int matchdaymidfieldrating
    {
      get
      {
        return this.m_matchdaymidfieldrating;
      }
      set
      {
        this.m_matchdaymidfieldrating = value;
      }
    }

    public int matchdayattackrating
    {
      get
      {
        return this.m_matchdayattackrating;
      }
      set
      {
        this.m_matchdayattackrating = value;
      }
    }

    public int countryid_IfNationalTeam
    {
      get
      {
        return this.m_countryid_IfNationalTeam;
      }
      set
      {
        this.m_countryid_IfNationalTeam = value;
      }
    }

    

    public Roster Roster
    {
      get
      {
        return this.m_Roster;
      }
    }

    public Country Country
    {
      get
      {
        return this.m_Country;
      }
      set
      {
        if (this.IsNationalTeam)
        {
          if (this.m_Country == value)
            return;
          if (this.m_Country != null)
            this.m_Country.NationalTeam = (Team) null;
        }
        if (value != null)
        {
          this.m_Country = value;
          this.m_countryid_IfRowTeam = this.m_Country.Id;
        }
        else
        {
          this.m_Country = value;
          this.m_countryid_IfRowTeam = 0;
        }
      }
    }

    public void SetAsNationalTeam(Country country)
    {
      this.m_Country = country;
      this.m_countryid_IfNationalTeam = country.Id;
      this.m_countryid_IfRowTeam = 0;
    }

    public void UnsetAsNationalTeam(int nationalTeamId)
    {
      this.m_countryid_IfRowTeam = this.m_countryid_IfNationalTeam;
      this.m_countryid_IfNationalTeam = 0;
    }

    public bool IsNationalTeam
    {
      get
      { 
        return this.m_countryid_IfNationalTeam != 0;
      }
    }

    public bool IsClub()
    {
      return !this.IsNationalTeam && this.Id != 111072 && (this.Id != 111205 && this.Id != 112190) && this.Id != 111596 && this.Id != 111592;
    }

    public League League
    {
      get
      {
        return this.m_League;
      }
      set
      {
        if (value == null)
        {
          this.m_League = League.GetDefaultLeague();
          this.m_leagueid = League.GetDefaultLeagueId();
        }
        else
        {
          this.m_League = value;
          this.m_leagueid = this.m_League.Id;
        }
      }
    }

    public League PrevLeague
    {
      get
      {
        return this.m_PrevLeague;
      }
      set
      {
        if (value == null)
        {
          this.m_PrevLeague = (League) null;
          this.m_prevleagueid = 0;
        }
        else
        {
          this.m_PrevLeague = value;
          this.m_prevleagueid = this.m_PrevLeague.Id;
        }
      }
    }

    public bool IsChampion
    {
      get
      {
        return this.m_champion;
      }
      set
      {
        this.m_champion = value;
      }
    }

    public int previousyeartableposition
    {
      get
      {
        return this.m_previousyeartableposition;
      }
      set
      {
        this.m_previousyeartableposition = value;
      }
    }

    public int currenttableposition
    {
      get
      {
        return this.m_currenttableposition;
      }
      set
      {
        this.m_currenttableposition = value;
      }
    }

    public int teamshortform
    {
      get
      {
        return this.m_teamshortform;
      }
      set
      {
        this.m_teamshortform = value;
      }
    }

    public int teamlongform
    {
      get
      {
        return this.m_teamlongform;
      }
      set
      {
        this.m_teamlongform = value;
      }
    }

    public int teamform
    {
      get
      {
        return this.m_teamform;
      }
      set
      {
        this.m_teamform = value;
      }
    }

    public bool hasachievedobjective
    {
      get
      {
        return this.m_hasachievedobjective;
      }
      set
      {
        this.m_hasachievedobjective = value;
      }
    }

    public bool yettowin
    {
      get
      {
        return this.m_yettowin;
      }
      set
      {
        this.m_yettowin = value;
      }
    }

    public bool unbeatenallcomps
    {
      get
      {
        return this.m_unbeatenallcomps;
      }
      set
      {
        this.m_unbeatenallcomps = value;
      }
    }

    public bool unbeatenaway
    {
      get
      {
        return this.m_unbeatenaway;
      }
      set
      {
        this.m_unbeatenaway = value;
      }
    }

    public bool unbeatenhome
    {
      get
      {
        return this.m_unbeatenhome;
      }
      set
      {
        this.m_unbeatenhome = value;
      }
    }

    public bool unbeatenleague
    {
      get
      {
        return this.m_unbeatenleague;
      }
      set
      {
        this.m_unbeatenleague = value;
      }
    }

    public int highestpossible
    {
      get
      {
        return this.m_highestpossible;
      }
      set
      {
        this.m_highestpossible = value;
      }
    }

    public int highestprobable
    {
      get
      {
        return this.m_highestprobable;
      }
      set
      {
        this.m_highestprobable = value;
      }
    }

    public int nummatchesplayed
    {
      get
      {
        return this.m_nummatchesplayed;
      }
      set
      {
        this.m_nummatchesplayed = value;
      }
    }

    public int gapresult
    {
      get
      {
        return this.m_gapresult;
      }
      set
      {
        this.m_gapresult = value;
      }
    }

    public int grouping
    {
      get
      {
        return this.m_grouping;
      }
      set
      {
        this.m_grouping = value;
      }
    }

    public int objective
    {
      get
      {
        return this.m_objective;
      }
      set
      {
        this.m_objective = value;
      }
    }

    public int actualvsexpectations
    {
      get
      {
        return this.m_actualvsexpectations;
      }
      set
      {
        this.m_actualvsexpectations = value;
      }
    }

    public int lastgameresult
    {
      get
      {
        return this.m_lastgameresult;
      }
      set
      {
        this.m_lastgameresult = value;
      }
    }

    public int homega
    {
      get
      {
        return this.m_homega;
      }
      set
      {
        this.m_homega = value;
      }
    }

    public int homegf
    {
      get
      {
        return this.m_homegf;
      }
      set
      {
        this.m_homegf = value;
      }
    }

    public int points
    {
      get
      {
        return this.m_points;
      }
      set
      {
        this.m_points = value;
      }
    }

    public int awayga
    {
      get
      {
        return this.m_awayga;
      }
      set
      {
        this.m_awayga = value;
      }
    }

    public int secondarytable
    {
      get
      {
        return this.m_secondarytable;
      }
      set
      {
        this.m_secondarytable = value;
      }
    }

    public int homewins
    {
      get
      {
        return this.m_homewins;
      }
      set
      {
        this.m_homewins = value;
      }
    }

    public int awaywins
    {
      get
      {
        return this.m_awaywins;
      }
      set
      {
        this.m_awaywins = value;
      }
    }

    public int homelosses
    {
      get
      {
        return this.m_homelosses;
      }
      set
      {
        this.m_homelosses = value;
      }
    }

    public int awaylosses
    {
      get
      {
        return this.m_awaylosses;
      }
      set
      {
        this.m_awaylosses = value;
      }
    }

    public int awaydraws
    {
      get
      {
        return this.m_awaydraws;
      }
      set
      {
        this.m_awaydraws = value;
      }
    }

    public int homedraws
    {
      get
      {
        return this.m_homedraws;
      }
      set
      {
        this.m_homedraws = value;
      }
    }

    public override string ToString()
    {
      if (this.m_TeamNameFull != null && this.m_TeamNameFull != string.Empty)
        return this.m_TeamNameFull;
      if (this.m_teamname == null)
        return string.Empty;
      this.m_TeamNameFull = this.m_teamname;
      return this.m_teamname;
    }

    public Team(Record recTeams)
      : base(recTeams.IntField[FI.teams_teamid])
    {
      this.Load(recTeams);
    }

    public Team(int teamId)
    {
      this.Id = teamId;
      this.m_assetid = teamId;
      this.m_TeamNameFull = "Team " + teamId.ToString();
      this.InitNewTeam();
    }

    public void InitNewTeam()
    {
      this.m_TeamNameAbbr10 = this.m_TeamNameFull.Length > 10 ? this.m_TeamNameFull.Substring(0, 10) : this.m_TeamNameFull;
      this.m_TeamNameAbbr15 = this.m_TeamNameAbbr10;
      this.m_TeamNameAbbr7 = this.m_TeamNameFull.Length > 7 ? this.m_TeamNameFull.Substring(0, 7) : this.m_TeamNameFull;
      this.m_TeamNameAbbr3 = "XYZ";
      this.m_teamname = this.m_TeamNameFull;
      this.m_balltype = 1;
      this.m_adboardid = 1;
      this.m_Stadium = (Stadium) null;
      this.m_stadiumid = 0;
      this.m_genericbanner = false;
      this.m_jerseytype = 1;
      this.m_physioid_primary = 1;
      this.m_physioid_secondary = 2;
      this.m_teamcolor1r = (int) byte.MaxValue;
      this.m_teamcolor1g = (int) byte.MaxValue;
      this.m_teamcolor1b = (int) byte.MaxValue;
      this.m_teamcolor2r = 0;
      this.m_teamcolor2g = 0;
      this.m_teamcolor2b = 0;
      this.m_teamcolor3r = 128;
      this.m_teamcolor3g = 128;
      this.m_teamcolor3b = 128;
      this.m_TeamColor1 = Color.FromArgb((int) byte.MaxValue, this.m_teamcolor1r, this.m_teamcolor1g, this.m_teamcolor1b);
      this.m_TeamColor2 = Color.FromArgb((int) byte.MaxValue, this.m_teamcolor2r, this.m_teamcolor2g, this.m_teamcolor2b);
      this.m_TeamColor3 = Color.FromArgb((int) byte.MaxValue, this.m_teamcolor3r, this.m_teamcolor3g, this.m_teamcolor3b);
      this.m_form = 0;
      this.m_managerid = 8105;
      this.m_stadiumcustomname = (string) null;
      this.m_ManagerSurname = (string) null;
      this.m_ManagerFirstName = (string) null;
      this.m_fancrowdhairskintexturecode = 0;
      this.m_stafftracksuitcolorcode = 0;
      for (int index = 0; index < 10; ++index)
        this.m_teamkitidList[index] = -1;
      this.m_RivalTeam = (Team) null;
      this.m_rivalteam = 1;
      this.m_assetid = this.Id;
      this.m_transferbudget = 1000000;
      this.m_internationalprestige = 10;
      this.m_domesticprestige = 10;
      this.m_formationid = 0;
      this.m_busbuildupspeed = 50;
      this.m_buspassing = 50;
      this.m_buspositioning = 0;
      this.m_ccpassing = 50;
      this.m_cccrossing = 50;
      this.m_ccshooting = 50;
      this.m_ccpositioning = 0;
      this.m_defmentality = 50;
      this.m_defaggression = 50;
      this.m_defteamwidth = 50;
      this.m_defdefenderline = 0;
      this.m_captainid = 1;
      this.m_penaltytakerid = 1;
      this.m_freekicktakerid = 1;
      this.m_leftfreekicktakerid = 1;
      this.m_rightfreekicktakerid = 1;
      this.m_longkicktakerid = 1;
      this.m_leftcornerkicktakerid = 1;
      this.m_rightcornerkicktakerid = 1;
      this.PlayerCaptain = (Player) null;
      this.PlayerPenalty = (Player) null;
      this.PlayerFreeKick = (Player) null;
      this.PlayerLongKick = (Player) null;
      this.PlayerLeftCorner = (Player) null;
      this.PlayerRightCorner = (Player) null;
      this.m_numtransfersin = 0;
      this.m_genericint2 = -1;
      this.m_genericint1 = -1;
      this.m_latitude = 0;
      this.m_longitude = 0;
      this.m_utcoffset = 0;
      this.m_powid = -1;
      this.m_midfieldrating = 50;
      this.m_defenserating = 50;
      this.m_attackrating = 50;
      this.m_overallrating = 50;
      this.m_matchdayoverallrating = 50;
      this.m_matchdaydefenserating = 50;
      this.m_matchdaymidfieldrating = 50;
      this.m_matchdayattackrating = 50;
      this.m_suitvariationid = 0;
      this.m_suittypeid = 0;
      this.m_bodytypeid = 1;
      this.m_ethnicity = 2;
      this.m_personalityid = 0;
      this.m_countryid_IfNationalTeam = 0;
      this.m_Country = (Country) null;
      this.m_leagueid = 0;
      this.m_League = (League) null;
      this.m_prevleagueid = 0;
      this.m_PrevLeague = (League) null;
      this.m_champion = false;
      this.m_previousyeartableposition = 1;
      this.m_currenttableposition = 1;
      this.m_teamshortform = 50;
      this.m_teamlongform = 50;
      this.m_teamform = 0;
      this.m_hasachievedobjective = false;
      this.m_yettowin = false;
      this.m_unbeatenallcomps = false;
      this.m_unbeatenaway = false;
      this.m_unbeatenhome = false;
      this.m_unbeatenleague = false;
      this.m_highestpossible = 0;
      this.m_highestprobable = 0;
      this.m_nummatchesplayed = 0;
      this.m_gapresult = 0;
      this.m_grouping = 0;
      this.m_objective = 0;
      this.m_actualvsexpectations = 0;
      this.m_lastgameresult = 0;
      this.m_busdribbling = 50;
      this.m_trait1 = 0;
      this.m_ImpatientBoard = false;
      this.m_LoyalBoard = false;
      this.m_SquadRotation = false;
      this.m_ConsistentLineup = false;
      this.m_SwitchWingers = false;
      this.m_CenterBacksSplit = false;
      this.m_DefendLead = false;
      this.m_KeepUpPressure = false;
      this.m_MoreAttackingAtHome = false;
      this.m_ShortOutBack = false;
      this.m_homega = 0;
      this.m_homegf = 0;
      this.m_points = 0;
      this.m_awayga = 0;
      this.m_secondarytable = 0;
      this.m_homewins = 0;
      this.m_awaywins = 0;
      this.m_homelosses = 0;
      this.m_awaylosses = 0;
      this.m_awaydraws = 0;
      this.m_homedraws = 0;
    }

    public void Load(Record r)
    {
      this.m_assetid = this.Id;
      this.m_teamname = r.StringField[FI.teams_teamname];
      this.m_transferbudget = r.GetAndCheckIntField(FI.teams_transferbudget);
      this.m_domesticprestige = r.GetAndCheckIntField(FI.teams_domesticprestige);
      this.m_internationalprestige = r.GetAndCheckIntField(FI.teams_internationalprestige);
      this.m_rivalteam = r.GetAndCheckIntField(FI.teams_rivalteam);
      this.m_captainid = r.GetAndCheckIntField(FI.teams_captainid);
      this.m_penaltytakerid = r.GetAndCheckIntField(FI.teams_penaltytakerid);
      this.m_freekicktakerid = r.GetAndCheckIntField(FI.teams_freekicktakerid);
      if (FI.teams_leftfreekicktakerid >= 0)
        this.m_leftfreekicktakerid = r.GetAndCheckIntField(FI.teams_leftfreekicktakerid);
      if (FI.teams_rightfreekicktakerid >= 0)
        this.m_rightfreekicktakerid = r.GetAndCheckIntField(FI.teams_rightfreekicktakerid);
      this.m_longkicktakerid = r.GetAndCheckIntField(FI.teams_longkicktakerid);
      this.m_leftcornerkicktakerid = r.GetAndCheckIntField(FI.teams_leftcornerkicktakerid);
      this.m_rightcornerkicktakerid = r.GetAndCheckIntField(FI.teams_rightcornerkicktakerid);
      this.m_adboardid = r.GetAndCheckIntField(FI.teams_adboardid);
      this.m_balltype = r.GetAndCheckIntField(FI.teams_balltype);
      this.m_genericbanner = r.GetAndCheckIntField(FI.teams_genericbanner) != 0;
      this.m_jerseytype = r.GetAndCheckIntField(FI.teams_jerseytype);
      this.m_fancrowdhairskintexturecode = r.GetAndCheckIntField(FI.teams_fancrowdhairskintexturecode);
      this.m_stafftracksuitcolorcode = r.GetAndCheckIntField(FI.teams_stafftracksuitcolorcode);
      this.m_busbuildupspeed = r.GetAndCheckIntField(FI.teams_busbuildupspeed);
      this.m_buspassing = r.GetAndCheckIntField(FI.teams_buspassing);
      if (FifaEnvironment.Year == 14)
      {
        this.m_buspositioning = r.GetAndCheckIntField(FI.teams_buspositioning) - 1;
        this.m_ccpositioning = r.GetAndCheckIntField(FI.teams_ccpositioning) - 1;
        this.m_defdefenderline = r.GetAndCheckIntField(FI.teams_defdefenderline) - 1;
      }
      else
      {
        this.m_buspositioning = r.GetAndCheckIntField(FI.teams_buspositioning);
        this.m_ccpositioning = r.GetAndCheckIntField(FI.teams_ccpositioning);
        this.m_defdefenderline = r.GetAndCheckIntField(FI.teams_defdefenderline);
      }
      this.m_busdribbling = r.GetAndCheckIntField(FI.teams_busdribbling);
      this.m_cccrossing = r.GetAndCheckIntField(FI.teams_cccrossing);
      this.m_ccpassing = r.GetAndCheckIntField(FI.teams_ccpassing);
      this.m_ccshooting = r.GetAndCheckIntField(FI.teams_ccshooting);
      this.m_defmentality = r.GetAndCheckIntField(FI.teams_defmentality);
      this.m_defaggression = r.GetAndCheckIntField(FI.teams_defaggression);
      this.m_defteamwidth = r.GetAndCheckIntField(FI.teams_defteamwidth);
      this.m_physioid_primary = r.GetAndCheckIntField(FI.teams_physioid_primary);
      this.m_physioid_secondary = r.GetAndCheckIntField(FI.teams_physioid_secondary);
      this.m_teamcolor1r = r.GetAndCheckIntField(FI.teams_teamcolor1r);
      this.m_teamcolor1g = r.GetAndCheckIntField(FI.teams_teamcolor1g);
      this.m_teamcolor1b = r.GetAndCheckIntField(FI.teams_teamcolor1b);
      this.m_teamcolor2r = r.GetAndCheckIntField(FI.teams_teamcolor2r);
      this.m_teamcolor2g = r.GetAndCheckIntField(FI.teams_teamcolor2g);
      this.m_teamcolor2b = r.GetAndCheckIntField(FI.teams_teamcolor2b);
      this.m_teamcolor3r = r.GetAndCheckIntField(FI.teams_teamcolor3r);
      this.m_teamcolor3g = r.GetAndCheckIntField(FI.teams_teamcolor3g);
      this.m_teamcolor3b = r.GetAndCheckIntField(FI.teams_teamcolor3b);
      this.m_TeamColor1 = Color.FromArgb((int) byte.MaxValue, this.m_teamcolor1r, this.m_teamcolor1g, this.m_teamcolor1b);
      this.m_TeamColor2 = Color.FromArgb((int) byte.MaxValue, this.m_teamcolor2r, this.m_teamcolor2g, this.m_teamcolor2b);
      this.m_TeamColor3 = Color.FromArgb((int) byte.MaxValue, this.m_teamcolor3r, this.m_teamcolor3g, this.m_teamcolor3b);
      this.m_form = r.GetAndCheckIntField(FI.teams_form);
      this.m_latitude = r.GetAndCheckIntField(FI.teams_latitude);
      this.m_longitude = r.GetAndCheckIntField(FI.teams_longitude);
      this.m_utcoffset = r.GetAndCheckIntField(FI.teams_utcoffset);
      this.m_powid = r.GetAndCheckIntField(FI.teams_powid);
      this.m_midfieldrating = r.GetAndCheckIntField(FI.teams_midfieldrating);
      this.m_defenserating = r.GetAndCheckIntField(FI.teams_defenserating);
      this.m_attackrating = r.GetAndCheckIntField(FI.teams_attackrating);
      this.m_overallrating = r.GetAndCheckIntField(FI.teams_overallrating);
      this.m_matchdayoverallrating = r.GetAndCheckIntField(FI.teams_matchdayoverallrating);
      this.m_matchdaydefenserating = r.GetAndCheckIntField(FI.teams_matchdaydefenserating);
      this.m_matchdaymidfieldrating = r.GetAndCheckIntField(FI.teams_matchdaymidfieldrating);
      this.m_matchdayattackrating = r.GetAndCheckIntField(FI.teams_matchdayattackrating);
      this.m_suitvariationid = r.GetAndCheckIntField(FI.teams_suitvariationid);
      this.m_suittypeid = r.GetAndCheckIntField(FI.teams_suittypeid);
      this.m_bodytypeid = r.GetAndCheckIntField(FI.teams_bodytypeid);
      this.m_ethnicity = r.GetAndCheckIntField(FI.teams_ethnicity);
      this.m_personalityid = r.GetAndCheckIntField(FI.teams_personalityid);
      this.m_trait1 = r.GetAndCheckIntField(FI.teams_trait1);
      this.m_ImpatientBoard = (this.m_trait1 & 1) != 0;
      this.m_LoyalBoard = (this.m_trait1 & 2) != 0;
      this.m_SquadRotation = (this.m_trait1 & 4) != 0;
      this.m_ConsistentLineup = (this.m_trait1 & 8) != 0;
      this.m_SwitchWingers = (this.m_trait1 & 16) != 0;
      this.m_CenterBacksSplit = (this.m_trait1 & 32) != 0;
      this.m_DefendLead = (this.m_trait1 & 64) != 0;
      this.m_KeepUpPressure = (this.m_trait1 & 128) != 0;
      this.m_MoreAttackingAtHome = (this.m_trait1 & 256) != 0;
      this.m_ShortOutBack = (this.m_trait1 & 512) != 0;
      this.m_numtransfersin = r.GetAndCheckIntField(FI.teams_numtransfersin);
      this.m_genericint2 = r.GetAndCheckIntField(FI.teams_genericint1);
      this.m_genericint1 = r.GetAndCheckIntField(FI.teams_genericint2);
      if (FifaEnvironment.Language != null)
      {
        this.m_TeamNameFull = FifaEnvironment.Language.GetTeamString(this.Id, Language.ETeamStringType.Full);
        this.m_TeamNameAbbr15 = FifaEnvironment.Language.GetTeamString(this.Id, Language.ETeamStringType.Abbr15);
        this.m_TeamNameAbbr10 = FifaEnvironment.Language.GetTeamString(this.Id, Language.ETeamStringType.Abbr10);
        this.m_TeamNameAbbr3 = FifaEnvironment.Language.GetTeamString(this.Id, Language.ETeamStringType.Abbr3);
        this.m_TeamNameAbbr7 = FifaEnvironment.Language.GetTeamString(this.Id, Language.ETeamStringType.Abbr7);
        if (this.m_TeamNameFull != null && !(this.m_TeamNameFull == string.Empty))
          return;
        this.m_TeamNameFull = this.m_TeamNameAbbr10;
      }
      else
      {
        this.m_TeamNameFull = string.Empty;
        this.m_TeamNameAbbr15 = string.Empty;
        this.m_TeamNameAbbr3 = string.Empty;
        this.m_TeamNameAbbr7 = string.Empty;
        this.m_TeamNameAbbr10 = string.Empty;
      }
    }

    public void FillFromStadiumAssignments(Record r)
    {
      this.m_stadiumcustomname = r.StringField[FI.stadiumassignments_stadiumcustomname];
    }

    public void FillFromManager(Record r)
    {
      this.m_ManagerFirstName = r.StringField[FI.manager_firstname];
      this.m_ManagerSurname = r.StringField[FI.manager_surname];
    }

    public void FillFromTeamStadiumLinks(Record r)
    {
      this.m_stadiumid = r.GetAndCheckIntField(FI.teamstadiumlinks_stadiumid);
    }

    public void FillFromTeamkits(Record r)
    {
      int andCheckIntField = r.GetAndCheckIntField(FI.teamkits_teamkittypetechid);
      if (andCheckIntField >= this.m_teamkitidList.Length || r.GetAndCheckIntField(FI.teamkits_year) != 0)
        return;
      this.m_teamkitidList[andCheckIntField] = r.GetAndCheckIntField(FI.teamkits_teamkitid);
    }

    public void FillFromFormations(Record r)
    {
      this.m_formationid = r.GetAndCheckIntField(FI.formations_formationid);
    }

    public void FillFromTeamFormationLinks(Record r)
    {
      this.m_formationid = r.GetAndCheckIntField(FI.teamformationteamstylelinks_formationid);
    }

    public void FillFromCountry(Country country)
    {
      this.m_countryid_IfNationalTeam = country.NationalTeamId;
      this.m_Country = country;
    }

    public void FillFromNations(Record r)
    {
      this.m_countryid_IfNationalTeam = r.GetAndCheckIntField(FI.nations_nationid);
    }

    public void FillFromLeagueTeamLinks(Record r)
    {
      this.m_leagueid = r.GetAndCheckIntField(FI.leagueteamlinks_leagueid);
      this.m_prevleagueid = r.GetAndCheckIntField(FI.leagueteamlinks_prevleagueid);
      this.m_champion = r.GetAndCheckIntField(FI.leagueteamlinks_champion) != 0;
      this.m_previousyeartableposition = r.GetAndCheckIntField(FI.leagueteamlinks_previousyeartableposition);
      this.m_currenttableposition = r.GetAndCheckIntField(FI.leagueteamlinks_currenttableposition);
      this.m_teamshortform = r.GetAndCheckIntField(FI.leagueteamlinks_teamshortform);
      this.m_teamlongform = r.GetAndCheckIntField(FI.leagueteamlinks_teamlongform);
      this.m_teamform = r.GetAndCheckIntField(FI.leagueteamlinks_teamform);
      this.m_hasachievedobjective = r.GetAndCheckIntField(FI.leagueteamlinks_hasachievedobjective) != 0;
      this.m_yettowin = r.GetAndCheckIntField(FI.leagueteamlinks_yettowin) != 0;
      this.m_unbeatenallcomps = r.GetAndCheckIntField(FI.leagueteamlinks_unbeatenallcomps) != 0;
      this.m_unbeatenaway = r.GetAndCheckIntField(FI.leagueteamlinks_unbeatenaway) != 0;
      this.m_unbeatenhome = r.GetAndCheckIntField(FI.leagueteamlinks_unbeatenhome) != 0;
      this.m_unbeatenleague = r.GetAndCheckIntField(FI.leagueteamlinks_unbeatenleague) != 0;
      this.m_highestpossible = r.GetAndCheckIntField(FI.leagueteamlinks_highestpossible);
      this.m_highestprobable = r.GetAndCheckIntField(FI.leagueteamlinks_highestprobable);
      this.m_nummatchesplayed = r.GetAndCheckIntField(FI.leagueteamlinks_nummatchesplayed);
      this.m_gapresult = r.GetAndCheckIntField(FI.leagueteamlinks_gapresult);
      this.m_grouping = r.GetAndCheckIntField(FI.leagueteamlinks_grouping);
      this.m_objective = r.GetAndCheckIntField(FI.leagueteamlinks_objective);
      this.m_actualvsexpectations = r.GetAndCheckIntField(FI.leagueteamlinks_actualvsexpectations);
      this.m_lastgameresult = r.GetAndCheckIntField(FI.leagueteamlinks_lastgameresult);
      this.m_homega = r.GetAndCheckIntField(FI.leagueteamlinks_homega);
      this.m_homegf = r.GetAndCheckIntField(FI.leagueteamlinks_homegf);
      this.m_points = r.GetAndCheckIntField(FI.leagueteamlinks_points);
      this.m_awayga = r.GetAndCheckIntField(FI.leagueteamlinks_awayga);
      this.m_secondarytable = r.GetAndCheckIntField(FI.leagueteamlinks_secondarytable);
      this.m_homewins = r.GetAndCheckIntField(FI.leagueteamlinks_homewins);
      this.m_awaywins = r.GetAndCheckIntField(FI.leagueteamlinks_awaywins);
      this.m_homelosses = r.GetAndCheckIntField(FI.leagueteamlinks_homelosses);
      this.m_awaylosses = r.GetAndCheckIntField(FI.leagueteamlinks_awaylosses);
      this.m_awaydraws = r.GetAndCheckIntField(FI.leagueteamlinks_awaydraws);
      this.m_homedraws = r.GetAndCheckIntField(FI.leagueteamlinks_homedraws);
    }

    public void FillFromRowTeamNationLinks(Record r)
    {
      this.m_countryid_IfRowTeam = r.GetAndCheckIntField(FI.rowteamnationlinks_nationid);
    }

    public void LinkBall(BallList ballList)
    {
      if (ballList == null)
        return;
      this.m_Ball = (Ball) ballList.SearchId(this.m_balltype);
    }

    public void LinkKits(KitList kitList)
    {
      if (kitList == null)
        return;
      for (int index = 0; index < this.m_teamkitidList.Length; ++index)
      {
        if (this.m_teamkitidList[index] >= 0)
          this.m_KitList.Add((object) (Kit) kitList.SearchId(this.m_teamkitidList[index]));
      }
    }

    public void LinkStadium(StadiumList stadiumList)
    {
      if (stadiumList == null)
        return;
      this.m_Stadium = (Stadium) stadiumList.SearchId(this.m_stadiumid);
    }

    public void LinkTeam(TeamList teamList)
    {
      if (teamList == null)
        return;
      this.m_RivalTeam = (Team) teamList.SearchId(this.m_rivalteam);
    }

    public void LinkCountry(CountryList countryList)
    {
      if (countryList == null)
        return;
      if (this.m_countryid_IfNationalTeam == 0)
      {
        if (this.m_countryid_IfRowTeam != 0)
        {
          this.m_Country = (Country) countryList.SearchId(this.m_countryid_IfRowTeam);
        }
        else
        {
          if (this.m_League == null || this.m_League.Country == null)
            return;
          this.m_Country = this.m_League.Country;
          this.m_countryid_IfRowTeam = this.m_League.Country.Id;
        }
      }
      //else
      //  this.m_Country = (Country) countryList.SearchId(this.m_countryid_IfNationalTeam);
    }

    public void LinkFormation(FormationList formationList)
    {
      if (formationList == null)
        return;
      this.m_Formation = (Formation) formationList.SearchId(this.m_formationid);
    }

    public void LinkPlayer(PlayerList playerList)
    {
      if (playerList == null)
        return;
      this.PlayerCaptain = (Player) playerList.SearchId(this.m_captainid);
      this.PlayerFreeKick = (Player) playerList.SearchId(this.m_freekicktakerid);
      this.PlayerLeftFreeKick = (Player) playerList.SearchId(this.m_leftfreekicktakerid);
      this.PlayerRightFreeKick = (Player) playerList.SearchId(this.m_rightfreekicktakerid);
      this.PlayerLongKick = (Player) playerList.SearchId(this.m_longkicktakerid);
      this.PlayerPenalty = (Player) playerList.SearchId(this.m_penaltytakerid);
      this.PlayerLeftCorner = (Player) playerList.SearchId(this.m_leftcornerkicktakerid);
      this.PlayerRightCorner = (Player) playerList.SearchId(this.m_rightcornerkicktakerid);
    }

    public void LinkLeague(LeagueList leagueList)
    {
      if (leagueList == null)
        return;
      this.m_League = (League) leagueList.SearchId(this.m_leagueid);
      this.m_PrevLeague = (League) leagueList.SearchId(this.m_prevleagueid);
    }

    public bool IsPlayingInLeague(League league)
    {
      return this.m_leagueid == league.Id;
    }

    public void SaveTeam(Record r)
    {
      r.IntField[FI.teams_teamid] = this.Id;
      r.StringField[FI.teams_teamname] = this.m_teamname;
      r.IntField[FI.teams_balltype] = this.m_balltype;
      r.IntField[FI.teams_adboardid] = this.m_adboardid;
      r.IntField[FI.teams_genericbanner] = this.m_genericbanner ? 1 : 0;
      r.IntField[FI.teams_jerseytype] = this.m_jerseytype;
      r.IntField[FI.teams_stafftracksuitcolorcode] = this.m_stafftracksuitcolorcode;
      r.IntField[FI.teams_fancrowdhairskintexturecode] = this.m_fancrowdhairskintexturecode;
      r.IntField[FI.teams_physioid_primary] = this.m_physioid_primary;
      r.IntField[FI.teams_physioid_secondary] = this.m_physioid_secondary;
      this.m_teamcolor1r = (int) this.m_TeamColor1.R;
      this.m_teamcolor1g = (int) this.m_TeamColor1.G;
      this.m_teamcolor1b = (int) this.m_TeamColor1.B;
      this.m_teamcolor2r = (int) this.m_TeamColor2.R;
      this.m_teamcolor2g = (int) this.m_TeamColor2.G;
      this.m_teamcolor2b = (int) this.m_TeamColor2.B;
      this.m_teamcolor3r = (int) this.m_TeamColor3.R;
      this.m_teamcolor3g = (int) this.m_TeamColor3.G;
      this.m_teamcolor3b = (int) this.m_TeamColor3.B;
      r.IntField[FI.teams_teamcolor1r] = this.m_teamcolor1r;
      r.IntField[FI.teams_teamcolor1g] = this.m_teamcolor1g;
      r.IntField[FI.teams_teamcolor1b] = this.m_teamcolor1b;
      r.IntField[FI.teams_teamcolor2r] = this.m_teamcolor2r;
      r.IntField[FI.teams_teamcolor2g] = this.m_teamcolor2g;
      r.IntField[FI.teams_teamcolor2b] = this.m_teamcolor2b;
      r.IntField[FI.teams_teamcolor3r] = this.m_teamcolor3r;
      r.IntField[FI.teams_teamcolor3g] = this.m_teamcolor3g;
      r.IntField[FI.teams_teamcolor3b] = this.m_teamcolor3b;
      r.IntField[FI.teams_form] = this.m_form;
      r.IntField[FI.teams_numtransfersin] = this.m_numtransfersin;
      r.IntField[FI.teams_genericint1] = this.m_genericint1;
      r.IntField[FI.teams_genericint2] = this.m_genericint2;
      r.IntField[FI.teams_rivalteam] = this.m_rivalteam;
      r.IntField[FI.teams_assetid] = this.m_assetid;
      r.IntField[FI.teams_transferbudget] = this.m_transferbudget;
      r.IntField[FI.teams_internationalprestige] = this.m_internationalprestige;
      r.IntField[FI.teams_domesticprestige] = this.m_domesticprestige;
      //r.IntField[FI.teams_busbuildupspeed] = this.m_busbuildupspeed;
      //r.IntField[FI.teams_buspassing] = this.m_buspassing;
      if (FifaEnvironment.Year == 14)
      {
        r.IntField[FI.teams_buspositioning] = this.m_buspositioning + 1;
        r.IntField[FI.teams_ccpositioning] = this.m_ccpositioning + 1;
        r.IntField[FI.teams_defdefenderline] = this.m_defdefenderline + 1;
      }
      else
      {
        r.IntField[FI.teams_buspositioning] = this.m_buspositioning;
        r.IntField[FI.teams_ccpositioning] = this.m_ccpositioning;
        r.IntField[FI.teams_defdefenderline] = this.m_defdefenderline;
      }
      r.IntField[FI.teams_busdribbling] = this.m_busdribbling;
      r.IntField[FI.teams_ccpassing] = this.m_ccpassing;
      r.IntField[FI.teams_cccrossing] = this.m_cccrossing;
      r.IntField[FI.teams_ccshooting] = this.m_ccshooting;
      //r.IntField[FI.teams_defmentality] = this.m_defmentality;
      r.IntField[FI.teams_defaggression] = this.m_defaggression;
      r.IntField[FI.teams_defteamwidth] = this.m_defteamwidth;
      r.IntField[FI.teams_captainid] = this.m_captainid;
      r.IntField[FI.teams_penaltytakerid] = this.m_penaltytakerid;
      r.IntField[FI.teams_freekicktakerid] = this.m_freekicktakerid;
      if (FI.teams_leftfreekicktakerid >= 0)
        r.IntField[FI.teams_leftfreekicktakerid] = this.m_leftfreekicktakerid;
      if (FI.teams_rightfreekicktakerid >= 0)
        r.IntField[FI.teams_rightfreekicktakerid] = this.m_rightfreekicktakerid;
      r.IntField[FI.teams_longkicktakerid] = this.m_longkicktakerid;
      r.IntField[FI.teams_leftcornerkicktakerid] = this.m_leftcornerkicktakerid;
      r.IntField[FI.teams_rightcornerkicktakerid] = this.m_rightcornerkicktakerid;
      r.IntField[FI.teams_latitude] = this.m_latitude;
      r.IntField[FI.teams_longitude] = this.m_longitude;
      r.IntField[FI.teams_utcoffset] = this.m_utcoffset;
      r.IntField[FI.teams_powid] = this.m_powid;
      r.IntField[FI.teams_midfieldrating] = this.m_midfieldrating;
      r.IntField[FI.teams_defenserating] = this.m_defenserating;
      r.IntField[FI.teams_attackrating] = this.m_attackrating;
      r.IntField[FI.teams_overallrating] = this.m_overallrating;
      r.IntField[FI.teams_matchdayoverallrating] = this.m_matchdayoverallrating;
      r.IntField[FI.teams_matchdaydefenserating] = this.m_matchdaydefenserating;
      r.IntField[FI.teams_matchdaymidfieldrating] = this.m_matchdaymidfieldrating;
      r.IntField[FI.teams_matchdayattackrating] = this.m_matchdayattackrating;
      r.IntField[FI.teams_suitvariationid] = this.m_suitvariationid;
      r.IntField[FI.teams_suittypeid] = this.m_suittypeid;
      r.IntField[FI.teams_bodytypeid] = this.m_bodytypeid;
      r.IntField[FI.teams_ethnicity] = this.m_ethnicity;
      r.IntField[FI.teams_personalityid] = this.m_personalityid;
      this.m_trait1 = 0;
      this.m_trait1 |= this.m_ImpatientBoard ? 1 : 0;
      this.m_trait1 |= this.m_LoyalBoard ? 2 : 0;
      this.m_trait1 |= this.m_SquadRotation ? 4 : 0;
      this.m_trait1 |= this.m_ConsistentLineup ? 8 : 0;
      this.m_trait1 |= this.m_SwitchWingers ? 16 : 0;
      this.m_trait1 |= this.m_CenterBacksSplit ? 32 : 0;
      this.m_trait1 |= this.m_DefendLead ? 64 : 0;
      this.m_trait1 |= this.m_KeepUpPressure ? 128 : 0;
      this.m_trait1 |= this.m_MoreAttackingAtHome ? 256 : 0;
      this.m_trait1 |= this.m_ShortOutBack ? 512 : 0;
      r.IntField[FI.teams_trait1] = this.m_trait1;
    }

    public void SaveTeamStadiumLinks(Record r)
    {
      r.IntField[FI.teamstadiumlinks_teamid] = this.Id;
      r.IntField[FI.teamstadiumlinks_stadiumid] = this.m_stadiumid;
    }

    public void SaveDefaultTeamSheet(Record r)
    {
    }

    public void SaveDefaultTeamData(Record r)
    {
      if (r == null)
        return;
      r.IntField[FI.defaultteamdata_teamid] = this.Id;
      r.IntField[FI.defaultteamdata_tacticid] = 0;
      //r.IntField[FI.defaultteamdata_busbuildupspeed] = this.m_busbuildupspeed;
      r.IntField[FI.defaultteamdata_busdribbling] = this.m_busdribbling;
      //r.IntField[FI.defaultteamdata_buspassing] = this.m_buspassing;
      r.IntField[FI.defaultteamdata_buspositioning] = this.m_buspositioning;
      r.IntField[FI.defaultteamdata_cccrossing] = this.m_cccrossing;
      r.IntField[FI.defaultteamdata_ccpassing] = this.m_ccpassing;
      r.IntField[FI.defaultteamdata_ccpositioning] = this.m_ccpositioning;
      r.IntField[FI.defaultteamdata_ccshooting] = this.m_ccshooting;
      r.IntField[FI.defaultteamdata_defaggression] = this.m_defaggression;
      //r.IntField[FI.defaultteamdata_defdefenderline] = this.m_defdefenderline;
      //r.IntField[FI.defaultteamdata_defmentality] = this.m_defmentality;
      r.IntField[FI.defaultteamdata_defteamwidth] = this.m_defteamwidth;
      if (this.m_Formation == null)
        return;
      r.FloatField[FI.defaultteamdata_offset0x] = (float) this.m_Formation.PlayingRoles[0].OffsetX / 100f;
      r.FloatField[FI.defaultteamdata_offset0y] = (float) this.m_Formation.PlayingRoles[0].OffsetY / 100f;
      //r.IntField[FI.defaultteamdata_playerinstruction0] = this.m_Formation.PlayingRoles[0].PlayerInstruction;
      r.IntField[FI.defaultteamdata_position0] = this.m_Formation.PlayingRoles[0].Role.Id;
      r.FloatField[FI.defaultteamdata_offset1x] = (float) this.m_Formation.PlayingRoles[1].OffsetX / 100f;
      r.FloatField[FI.defaultteamdata_offset1y] = (float) this.m_Formation.PlayingRoles[1].OffsetY / 100f;
      //r.IntField[FI.defaultteamdata_playerinstruction1] = this.m_Formation.PlayingRoles[1].PlayerInstruction;
      r.IntField[FI.defaultteamdata_position1] = this.m_Formation.PlayingRoles[1].Role.Id;
      r.FloatField[FI.defaultteamdata_offset2x] = (float) this.m_Formation.PlayingRoles[2].OffsetX / 100f;
      r.FloatField[FI.defaultteamdata_offset2y] = (float) this.m_Formation.PlayingRoles[2].OffsetY / 100f;
      //r.IntField[FI.defaultteamdata_playerinstruction2] = this.m_Formation.PlayingRoles[2].PlayerInstruction;
      r.IntField[FI.defaultteamdata_position2] = this.m_Formation.PlayingRoles[2].Role.Id;
      r.FloatField[FI.defaultteamdata_offset3x] = (float) this.m_Formation.PlayingRoles[3].OffsetX / 100f;
      r.FloatField[FI.defaultteamdata_offset3y] = (float) this.m_Formation.PlayingRoles[3].OffsetY / 100f;
      //r.IntField[FI.defaultteamdata_playerinstruction3] = this.m_Formation.PlayingRoles[3].PlayerInstruction;
      r.IntField[FI.defaultteamdata_position3] = this.m_Formation.PlayingRoles[3].Role.Id;
      r.FloatField[FI.defaultteamdata_offset4x] = (float) this.m_Formation.PlayingRoles[4].OffsetX / 100f;
      r.FloatField[FI.defaultteamdata_offset4y] = (float) this.m_Formation.PlayingRoles[4].OffsetY / 100f;
      //r.IntField[FI.defaultteamdata_playerinstruction4] = this.m_Formation.PlayingRoles[4].PlayerInstruction;
      r.IntField[FI.defaultteamdata_position4] = this.m_Formation.PlayingRoles[4].Role.Id;
      r.FloatField[FI.defaultteamdata_offset5x] = (float) this.m_Formation.PlayingRoles[5].OffsetX / 100f;
      r.FloatField[FI.defaultteamdata_offset5y] = (float) this.m_Formation.PlayingRoles[5].OffsetY / 100f;
      //r.IntField[FI.defaultteamdata_playerinstruction5] = this.m_Formation.PlayingRoles[5].PlayerInstruction;
      r.IntField[FI.defaultteamdata_position5] = this.m_Formation.PlayingRoles[5].Role.Id;
      r.FloatField[FI.defaultteamdata_offset6x] = (float) this.m_Formation.PlayingRoles[6].OffsetX / 100f;
      r.FloatField[FI.defaultteamdata_offset6y] = (float) this.m_Formation.PlayingRoles[6].OffsetY / 100f;
      //r.IntField[FI.defaultteamdata_playerinstruction6] = this.m_Formation.PlayingRoles[6].PlayerInstruction;
      r.IntField[FI.defaultteamdata_position6] = this.m_Formation.PlayingRoles[6].Role.Id;
      r.FloatField[FI.defaultteamdata_offset7x] = (float) this.m_Formation.PlayingRoles[7].OffsetX / 100f;
      r.FloatField[FI.defaultteamdata_offset7y] = (float) this.m_Formation.PlayingRoles[7].OffsetY / 100f;
      //r.IntField[FI.defaultteamdata_playerinstruction7] = this.m_Formation.PlayingRoles[7].PlayerInstruction;
      r.IntField[FI.defaultteamdata_position7] = this.m_Formation.PlayingRoles[7].Role.Id;
      r.FloatField[FI.defaultteamdata_offset8x] = (float) this.m_Formation.PlayingRoles[8].OffsetX / 100f;
      r.FloatField[FI.defaultteamdata_offset8y] = (float) this.m_Formation.PlayingRoles[8].OffsetY / 100f;
      //r.IntField[FI.defaultteamdata_playerinstruction8] = this.m_Formation.PlayingRoles[8].PlayerInstruction;
      r.IntField[FI.defaultteamdata_position8] = this.m_Formation.PlayingRoles[8].Role.Id;
      r.FloatField[FI.defaultteamdata_offset9x] = (float) this.m_Formation.PlayingRoles[9].OffsetX / 100f;
      r.FloatField[FI.defaultteamdata_offset9y] = (float) this.m_Formation.PlayingRoles[9].OffsetY / 100f;
      //r.IntField[FI.defaultteamdata_playerinstruction9] = this.m_Formation.PlayingRoles[9].PlayerInstruction;
      r.IntField[FI.defaultteamdata_position9] = this.m_Formation.PlayingRoles[9].Role.Id;
      r.FloatField[FI.defaultteamdata_offset10x] = (float) this.m_Formation.PlayingRoles[10].OffsetX / 100f;
      r.FloatField[FI.defaultteamdata_offset10y] = (float) this.m_Formation.PlayingRoles[10].OffsetY / 100f;
      //r.IntField[FI.defaultteamdata_playerinstruction10] = this.m_Formation.PlayingRoles[10].PlayerInstruction;
      r.IntField[FI.defaultteamdata_position10] = this.m_Formation.PlayingRoles[10].Role.Id;
    }

    public void SaveDefaultTeamsheets(Record r)
    {
      if (r == null)
        return;
      r.IntField[FI.default_teamsheets_teamid] = this.Id;
      r.IntField[FI.default_teamsheets_tacticid] = 0;
      //r.IntField[FI.default_teamsheets_busbuildupspeed] = this.m_busbuildupspeed;
      r.IntField[FI.default_teamsheets_busdribbling] = this.m_busdribbling;
      //r.IntField[FI.default_teamsheets_buspassing] = this.m_buspassing;
      r.IntField[FI.default_teamsheets_buspositioning] = this.m_buspositioning;
      r.IntField[FI.default_teamsheets_cccrossing] = this.m_cccrossing;
      r.IntField[FI.default_teamsheets_ccpassing] = this.m_ccpassing;
      r.IntField[FI.default_teamsheets_ccpositioning] = this.m_ccpositioning;
      r.IntField[FI.default_teamsheets_ccshooting] = this.m_ccshooting;
      r.IntField[FI.default_teamsheets_defaggression] = this.m_defaggression;
      r.IntField[FI.default_teamsheets_defdefenderline] = this.m_defdefenderline;
      //r.IntField[FI.default_teamsheets_defmentality] = this.m_defmentality;
      r.IntField[FI.default_teamsheets_defteamwidth] = this.m_defteamwidth;
      if (this.m_Formation != null)
      {
        r.FloatField[FI.default_teamsheets_offset0x] = (float) this.m_Formation.PlayingRoles[0].OffsetX / 100f;
        r.FloatField[FI.default_teamsheets_offset0y] = (float) this.m_Formation.PlayingRoles[0].OffsetY / 100f;
        //r.IntField[FI.default_teamsheets_playerinstruction0] = this.m_Formation.PlayingRoles[0].PlayerInstruction;
        r.IntField[FI.default_teamsheets_position0] = this.m_Formation.PlayingRoles[0].Role.Id;
        r.FloatField[FI.default_teamsheets_offset1x] = (float) this.m_Formation.PlayingRoles[1].OffsetX / 100f;
        r.FloatField[FI.default_teamsheets_offset1y] = (float) this.m_Formation.PlayingRoles[1].OffsetY / 100f;
        //r.IntField[FI.default_teamsheets_playerinstruction1] = this.m_Formation.PlayingRoles[1].PlayerInstruction;
        r.IntField[FI.default_teamsheets_position1] = this.m_Formation.PlayingRoles[1].Role.Id;
        r.FloatField[FI.default_teamsheets_offset2x] = (float) this.m_Formation.PlayingRoles[2].OffsetX / 100f;
        r.FloatField[FI.default_teamsheets_offset2y] = (float) this.m_Formation.PlayingRoles[2].OffsetY / 100f;
        //r.IntField[FI.default_teamsheets_playerinstruction2] = this.m_Formation.PlayingRoles[2].PlayerInstruction;
        r.IntField[FI.default_teamsheets_position2] = this.m_Formation.PlayingRoles[2].Role.Id;
        r.FloatField[FI.default_teamsheets_offset3x] = (float) this.m_Formation.PlayingRoles[3].OffsetX / 100f;
        r.FloatField[FI.default_teamsheets_offset3y] = (float) this.m_Formation.PlayingRoles[3].OffsetY / 100f;
        //r.IntField[FI.default_teamsheets_playerinstruction3] = this.m_Formation.PlayingRoles[3].PlayerInstruction;
        r.IntField[FI.default_teamsheets_position3] = this.m_Formation.PlayingRoles[3].Role.Id;
        r.FloatField[FI.default_teamsheets_offset4x] = (float) this.m_Formation.PlayingRoles[4].OffsetX / 100f;
        r.FloatField[FI.default_teamsheets_offset4y] = (float) this.m_Formation.PlayingRoles[4].OffsetY / 100f;
        //r.IntField[FI.default_teamsheets_playerinstruction4] = this.m_Formation.PlayingRoles[4].PlayerInstruction;
        r.IntField[FI.default_teamsheets_position4] = this.m_Formation.PlayingRoles[4].Role.Id;
        r.FloatField[FI.default_teamsheets_offset5x] = (float) this.m_Formation.PlayingRoles[5].OffsetX / 100f;
        r.FloatField[FI.default_teamsheets_offset5y] = (float) this.m_Formation.PlayingRoles[5].OffsetY / 100f;
        //r.IntField[FI.default_teamsheets_playerinstruction5] = this.m_Formation.PlayingRoles[5].PlayerInstruction;
        r.IntField[FI.default_teamsheets_position5] = this.m_Formation.PlayingRoles[5].Role.Id;
        r.FloatField[FI.default_teamsheets_offset6x] = (float) this.m_Formation.PlayingRoles[6].OffsetX / 100f;
        r.FloatField[FI.default_teamsheets_offset6y] = (float) this.m_Formation.PlayingRoles[6].OffsetY / 100f;
        //r.IntField[FI.default_teamsheets_playerinstruction6] = this.m_Formation.PlayingRoles[6].PlayerInstruction;
        r.IntField[FI.default_teamsheets_position6] = this.m_Formation.PlayingRoles[6].Role.Id;
        r.FloatField[FI.default_teamsheets_offset7x] = (float) this.m_Formation.PlayingRoles[7].OffsetX / 100f;
        r.FloatField[FI.default_teamsheets_offset7y] = (float) this.m_Formation.PlayingRoles[7].OffsetY / 100f;
        //r.IntField[FI.default_teamsheets_playerinstruction7] = this.m_Formation.PlayingRoles[7].PlayerInstruction;
        r.IntField[FI.default_teamsheets_position7] = this.m_Formation.PlayingRoles[7].Role.Id;
        r.FloatField[FI.default_teamsheets_offset8x] = (float) this.m_Formation.PlayingRoles[8].OffsetX / 100f;
        r.FloatField[FI.default_teamsheets_offset8y] = (float) this.m_Formation.PlayingRoles[8].OffsetY / 100f;
        //r.IntField[FI.default_teamsheets_playerinstruction8] = this.m_Formation.PlayingRoles[8].PlayerInstruction;
        r.IntField[FI.default_teamsheets_position8] = this.m_Formation.PlayingRoles[8].Role.Id;
        r.FloatField[FI.default_teamsheets_offset9x] = (float) this.m_Formation.PlayingRoles[9].OffsetX / 100f;
        r.FloatField[FI.default_teamsheets_offset9y] = (float) this.m_Formation.PlayingRoles[9].OffsetY / 100f;
        //r.IntField[FI.default_teamsheets_playerinstruction9] = this.m_Formation.PlayingRoles[9].PlayerInstruction;
        r.IntField[FI.default_teamsheets_position9] = this.m_Formation.PlayingRoles[9].Role.Id;
        r.FloatField[FI.default_teamsheets_offset10x] = (float) this.m_Formation.PlayingRoles[10].OffsetX / 100f;
        r.FloatField[FI.default_teamsheets_offset10y] = (float) this.m_Formation.PlayingRoles[10].OffsetY / 100f;
        //r.IntField[FI.default_teamsheets_playerinstruction10] = this.m_Formation.PlayingRoles[10].PlayerInstruction;
        r.IntField[FI.default_teamsheets_position10] = this.m_Formation.PlayingRoles[10].Role.Id;
      }
      r.IntField[FI.default_teamsheets_captainid] = this.m_captainid;
      r.IntField[FI.default_teamsheets_freekicktakerid] = this.m_freekicktakerid;
      r.IntField[FI.default_teamsheets_leftcornerkicktakerid] = this.m_leftcornerkicktakerid;
      r.IntField[FI.default_teamsheets_leftfreekicktakerid] = this.m_leftfreekicktakerid;
      r.IntField[FI.default_teamsheets_longkicktakerid] = this.m_longkicktakerid;
      r.IntField[FI.default_teamsheets_penaltytakerid] = this.m_penaltytakerid;
      r.IntField[FI.default_teamsheets_rightcornerkicktakerid] = this.m_rightcornerkicktakerid;
      r.IntField[FI.default_teamsheets_rightfreekicktakerid] = this.m_rightfreekicktakerid;
      int[] numArray = new int[42]
      {
        FI.default_teamsheets_playerid0,
        FI.default_teamsheets_playerid1,
        FI.default_teamsheets_playerid2,
        FI.default_teamsheets_playerid3,
        FI.default_teamsheets_playerid4,
        FI.default_teamsheets_playerid5,
        FI.default_teamsheets_playerid6,
        FI.default_teamsheets_playerid7,
        FI.default_teamsheets_playerid8,
        FI.default_teamsheets_playerid9,
        FI.default_teamsheets_playerid10,
        FI.default_teamsheets_playerid11,
        FI.default_teamsheets_playerid12,
        FI.default_teamsheets_playerid13,
        FI.default_teamsheets_playerid14,
        FI.default_teamsheets_playerid15,
        FI.default_teamsheets_playerid16,
        FI.default_teamsheets_playerid17,
        FI.default_teamsheets_playerid18,
        FI.default_teamsheets_playerid19,
        FI.default_teamsheets_playerid20,
        FI.default_teamsheets_playerid21,
        FI.default_teamsheets_playerid22,
        FI.default_teamsheets_playerid23,
        FI.default_teamsheets_playerid24,
        FI.default_teamsheets_playerid25,
        FI.default_teamsheets_playerid26,
        FI.default_teamsheets_playerid27,
        FI.default_teamsheets_playerid28,
        FI.default_teamsheets_playerid29,
        FI.default_teamsheets_playerid30,
        FI.default_teamsheets_playerid31,
        FI.default_teamsheets_playerid32,
        FI.default_teamsheets_playerid33,
        FI.default_teamsheets_playerid34,
        FI.default_teamsheets_playerid35,
        FI.default_teamsheets_playerid36,
        FI.default_teamsheets_playerid37,
        FI.default_teamsheets_playerid38,
        FI.default_teamsheets_playerid39,
        FI.default_teamsheets_playerid40,
        FI.default_teamsheets_playerid41
      };
      for (int index = 0; index < numArray.Length; ++index)
      {
        TeamPlayer teamPlayer = (TeamPlayer) null;
        if (index < this.m_Roster.Count)
          teamPlayer = (TeamPlayer) this.m_Roster[index];
        r.IntField[numArray[index]] = teamPlayer == null || teamPlayer.Player == null ? -1 : teamPlayer.Player.Id;
      }
    }

    public void SaveLangTable()
    {
      if (FifaEnvironment.Language == null)
        return;
      FifaEnvironment.Language.SetTeamString(this.Id, Language.ETeamStringType.Full, this.m_TeamNameFull);
      FifaEnvironment.Language.SetTeamString(this.Id, Language.ETeamStringType.Abbr15, this.m_TeamNameAbbr15);
      FifaEnvironment.Language.SetTeamString(this.Id, Language.ETeamStringType.Abbr10, this.m_TeamNameAbbr10);
      FifaEnvironment.Language.SetTeamString(this.Id, Language.ETeamStringType.Abbr7, this.m_TeamNameAbbr7);
      FifaEnvironment.Language.SetTeamString(this.Id, Language.ETeamStringType.Abbr3, this.m_TeamNameAbbr3);
    }

    public void SaveTeamCountry(Record r)
    {
    }

    public void SaveStadiumAssignment(Record r)
    {
      r.IntField[FI.stadiumassignments_teamid] = this.Id;
      r.StringField[FI.stadiumassignments_stadiumcustomname] = this.m_stadiumcustomname;
    }

    public void SaveManager(Record r)
    {
      r.IntField[FI.manager_teamid] = this.Id;
      r.StringField[FI.manager_firstname] = this.m_ManagerFirstName;
      r.StringField[FI.manager_surname] = this.m_ManagerSurname;
    }

    public void SaveTeamFormationLinks(Record r)
    {
      r.IntField[FI.teamformationteamstylelinks_teamid] = this.Id;
      r.IntField[FI.teamformationteamstylelinks_formationid] = this.m_formationid;
      r.IntField[FI.teamformationteamstylelinks_teamstyleid] = 0;
      r.IntField[FI.teamformationteamstylelinks_cddl] = 0;
    }

    public void SaveRowTeamNationLinks(Record r)
    {
      r.IntField[FI.rowteamnationlinks_teamid] = this.Id;
      if (this.m_Country == null)
        return;
      r.IntField[FI.rowteamnationlinks_nationid] = this.m_Country.Id;
    }

    public string CrestTemplateFileName()
    {
      return FifaEnvironment.Year == 14 ? "data/ui/imgassets/crest/l#.dds" : "data/ui/imgassets/crest/light/l#.dds";
    }

    public string CrestDdsFileName()
    {
      return Team.CrestDdsFileName(this.Id);
    }

    public static string CrestDdsFileName(int id)
    {
      return Team.CrestDdsFileName(id, FifaEnvironment.Year);
    }

    public static string CrestDdsFileName(int id, int year)
    {
      return year == 14 ? "data/ui/imgassets/crest/l" + id.ToString() + ".dds" : "data/ui/imgassets/crest/light/l" + id.ToString() + ".dds";
    }

    public string CrestTemplateFileNameDark()
    {
      return "data/ui/imgassets/crest/dark/l#.dds";
    }

    public string CrestDdsFileNameDark()
    {
      return "data/ui/imgassets/crest/dark/l" + this.Id.ToString() + ".dds";
    }

    public static string CrestDdsFileNameDark(int id)
    {
      return "data/ui/imgassets/crest/dark/l" + id.ToString() + ".dds";
    }

    public string Crest50TemplateFileName()
    {
      return FifaEnvironment.Year == 14 ? "data/ui/imgassets/crest50x50/l#.dds" : "data/ui/imgassets/crest50x50/light/l#.dds";
    }

    public static string Crest50DdsFileName(int id)
    {
      return Team.Crest50DdsFileName(id, FifaEnvironment.Year);
    }

    public static string Crest50DdsFileName(int id, int year)
    {
      return year == 14 ? "data/ui/imgassets/crest50x50/l" + id.ToString() + ".dds" : "data/ui/imgassets/crest50x50/light/l" + id.ToString() + ".dds";
    }

    public string Crest50DdsFileName()
    {
      return Team.Crest50DdsFileName(this.Id);
    }

    public string Crest50TemplateFileNameDark()
    {
      return "data/ui/imgassets/crest50x50/dark/l#.dds";
    }

    public string Crest50DdsFileNameDark()
    {
      return "data/ui/imgassets/crest50x50/dark/l" + this.Id.ToString() + ".dds";
    }

    public static string Crest50DdsFileNameDark(int id)
    {
      return "data/ui/imgassets/crest50x50/dark/l" + id.ToString() + ".dds";
    }

    public string Crest32TemplateFileName()
    {
      return FifaEnvironment.Year == 14 ? "data/ui/imgassets/crest32x32/l#.dds" : "data/ui/imgassets/crest32x32/light/l#.dds";
    }

    public string Crest32DdsFileName()
    {
      return Team.Crest32DdsFileName(this.Id);
    }

    public static string Crest32DdsFileName(int id)
    {
      return Team.Crest32DdsFileName(id, FifaEnvironment.Year);
    }

    public static string Crest32DdsFileName(int id, int year)
    {
      return year == 14 ? "data/ui/imgassets/crest32x32/l" + id.ToString() + ".dds" : "data/ui/imgassets/crest32x32/light/l" + id.ToString() + ".dds";
    }

    public string Crest32TemplateFileNameDark()
    {
      return "data/ui/imgassets/crest32x32/dark/l#.dds";
    }

    public string Crest32DdsFileNameDark()
    {
      return "data/ui/imgassets/crest32x32/dark/l" + this.Id.ToString() + ".dds";
    }

    public static string Crest32DdsFileNameDark(int id)
    {
      return "data/ui/imgassets/crest32x32/dark/l" + id.ToString() + ".dds";
    }

    public string Crest16TemplateFileName()
    {
      return FifaEnvironment.Year == 14 ? "data/ui/imgassets/crest16x16/l#.dds" : "data/ui/imgassets/crest16x16/light/l#.dds";
    }

    public string Crest16DdsFileName()
    {
      return Team.Crest16DdsFileName(this.Id);
    }

    public static string Crest16DdsFileName(int id)
    {
      return Team.Crest16DdsFileName(id, FifaEnvironment.Year);
    }

    public static string Crest16DdsFileName(int id, int year)
    {
      return year == 14 ? "data/ui/imgassets/crest16x16/l" + id.ToString() + ".dds" : "data/ui/imgassets/crest16x16/light/l" + id.ToString() + ".dds";
    }

    public string Crest16TemplateFileNameDark()
    {
      return "data/ui/imgassets/crest16x16/dark/l#.dds";
    }

    public string Crest16DdsFileNameDark()
    {
      return "data/ui/imgassets/crest16x16/dark/l" + this.Id.ToString() + ".dds";
    }

    public static string Crest16DdsFileNameDark(int id)
    {
      return "data/ui/imgassets/crest16x16/dark/l" + id.ToString() + ".dds";
    }

    public Bitmap GetCrest()
    {
      return FifaEnvironment.GetDdsArtasset(this.CrestDdsFileName());
    }

    public bool SetCrest(Bitmap bitmap)
    {
      return FifaEnvironment.SetDdsArtasset(this.CrestTemplateFileName(), this.Id, bitmap);
    }

    public bool DeleteCrest()
    {
      return FifaEnvironment.DeleteFromZdata(this.CrestDdsFileName());
    }

    public Bitmap GetCrest50()
    {
      return FifaEnvironment.GetDdsArtasset(this.Crest50DdsFileName());
    }

    public bool SetCrest50(Bitmap bitmap)
    {
      return FifaEnvironment.SetDdsArtasset(this.Crest50TemplateFileName(), this.Id, bitmap);
    }

    public bool DeleteCrest50()
    {
      return FifaEnvironment.DeleteFromZdata(this.Crest50DdsFileName());
    }

    public Bitmap GetCrest32()
    {
      return FifaEnvironment.GetDdsArtasset(this.Crest32DdsFileName());
    }

    public bool SetCrest32(Bitmap bitmap)
    {
      return FifaEnvironment.SetDdsArtasset(this.Crest32TemplateFileName(), this.Id, bitmap);
    }

    public bool DeleteCrest32()
    {
      return FifaEnvironment.DeleteFromZdata(this.Crest32DdsFileName());
    }

    public Bitmap GetCrest16()
    {
      return FifaEnvironment.GetDdsArtasset(this.Crest16DdsFileName());
    }

    public bool SetCrest16(Bitmap bitmap)
    {
      return FifaEnvironment.SetDdsArtasset(this.Crest16TemplateFileName(), this.Id, bitmap);
    }

    public bool DeleteCrest16()
    {
      return FifaEnvironment.DeleteFromZdata(this.Crest16DdsFileName());
    }

    public Bitmap GetCrestDark()
    {
      return FifaEnvironment.GetDdsArtasset(this.CrestDdsFileNameDark());
    }

    public bool SetCrestDark(Bitmap bitmap)
    {
      return FifaEnvironment.SetDdsArtasset(this.CrestTemplateFileNameDark(), this.Id, bitmap);
    }

    public bool DeleteCrestDark()
    {
      return FifaEnvironment.DeleteFromZdata(this.CrestDdsFileNameDark());
    }

    public Bitmap GetCrest50Dark()
    {
      return FifaEnvironment.GetDdsArtasset(this.Crest50DdsFileNameDark());
    }

    public bool SetCrest50Dark(Bitmap bitmap)
    {
      return FifaEnvironment.SetDdsArtasset(this.Crest50TemplateFileNameDark(), this.Id, bitmap);
    }

    public bool DeleteCrest50Dark()
    {
      return FifaEnvironment.DeleteFromZdata(this.Crest50DdsFileNameDark());
    }

    public Bitmap GetCrest32Dark()
    {
      return FifaEnvironment.GetDdsArtasset(this.Crest32DdsFileNameDark());
    }

    public bool SetCrest32Dark(Bitmap bitmap)
    {
      return FifaEnvironment.SetDdsArtasset(this.Crest32TemplateFileNameDark(), this.Id, bitmap);
    }

    public bool DeleteCrest32Dark()
    {
      return FifaEnvironment.DeleteFromZdata(this.Crest32DdsFileNameDark());
    }

    public Bitmap GetCrest16Dark()
    {
      return FifaEnvironment.GetDdsArtasset(this.Crest16DdsFileNameDark());
    }

    public bool SetCrest16Dark(Bitmap bitmap)
    {
      return FifaEnvironment.SetDdsArtasset(this.Crest16TemplateFileNameDark(), this.Id, bitmap);
    }

    public bool DeleteCrest16Dark()
    {
      return FifaEnvironment.DeleteFromZdata(this.Crest16DdsFileNameDark());
    }

    public string BannerFileName()
    {
      return "data/sceneassets/banner/banner_" + this.Id.ToString() + ".rx3";
    }

    public static string BannerFileName(int id)
    {
      return "data/sceneassets/banner/banner_" + id.ToString() + ".rx3";
    }

    public string BannerTemplateFileName()
    {
      return "data/sceneassets/banner/banner_#.rx3";
    }

    public Bitmap GetBanner()
    {
      return FifaEnvironment.GetBmpFromRx3(this.BannerFileName());
    }

    public bool SetBanner(Bitmap bitmap)
    {
      return FifaEnvironment.ImportBmpsIntoZdata(this.BannerTemplateFileName(), this.Id, bitmap, ECompressionMode.Chunkzip);
    }

    public bool SetBanner(string rx3FileName)
    {
      return FifaEnvironment.ImportFileIntoZdataAs(rx3FileName, this.BannerFileName(), false, ECompressionMode.Chunkzip);
    }

    public bool DeleteBanner()
    {
      return FifaEnvironment.DeleteFromZdata(this.BannerFileName());
    }

    public static string GenericFlagFileName(int style)
    {
      return "data/sceneassets/flag/gf" + style.ToString() + ".png";
    }

    public string FlagFileName()
    {
      return "data/sceneassets/flag/flag_" + this.Id.ToString() + ".rx3";
    }

    public static string FlagFileName(int id)
    {
      return "data/sceneassets/flag/flag_" + id.ToString() + ".rx3";
    }

    public string FlagTemplateFileName()
    {
      return "data/sceneassets/flag/flag_#.rx3";
    }

    private Rx3Signatures FlagsSignature()
    {
      return new Rx3Signatures(350544, 22, new string[4]
      {
        "flag_" + this.Id.ToString() + "_0",
        "flag_" + this.Id.ToString() + "_1",
        "flag_" + this.Id.ToString() + "_2",
        "flag_" + this.Id.ToString() + "_3"
      });
    }

    public Bitmap[] GetFlags()
    {
      return FifaEnvironment.GetBmpsFromRx3(this.FlagFileName());
    }

    public bool SetFlags(Bitmap[] bitmaps)
    {
      return FifaEnvironment.ImportBmpsIntoZdata(this.FlagTemplateFileName(), this.Id, bitmaps, ECompressionMode.Chunkzip, this.FlagsSignature());
    }

    public bool DeleteFlag()
    {
      return FifaEnvironment.DeleteFromZdata(this.FlagFileName());
    }

    public bool SetFlags(string rx3FileName)
    {
      string archivedName = this.FlagFileName();
      return FifaEnvironment.ImportFileIntoZdataAs(rx3FileName, archivedName, false, ECompressionMode.Chunkzip);
    }

    public bool ExportFlags(string exportFolder)
    {
      return FifaEnvironment.ExportFileFromZdata(this.FlagFileName(), exportFolder);
    }

    public void RemoveTeamPlayer(TeamPlayer teamPlayer)
    {
      this.m_Roster.Remove((object) teamPlayer);
      teamPlayer.Player.NotPlayFor(this);
      if (teamPlayer.position < 28)
      {
        this.AssignRoleToSubstitute((ERole) teamPlayer.position);
        this.AssignBench();
      }
      else if (teamPlayer.position == 28)
        this.AssignBench();
      if (this.PlayerCaptain == teamPlayer.Player)
        this.AssignCaptain();
      if (this.PlayerLeftFreeKick == teamPlayer.Player || this.PlayerRightFreeKick == teamPlayer.Player || this.PlayerFreeKick == teamPlayer.Player)
        this.AssignFreeKick();
      if (this.PlayerPenalty == teamPlayer.Player)
        this.AssignPenalty();
      if (this.PlayerLeftCorner == teamPlayer.Player)
        this.AssignLeftCorner();
      if (this.PlayerRightCorner != teamPlayer.Player)
        return;
      this.AssignRightCorner();
    }

    public void RemoveTeamPlayer(Player player)
    {
      TeamPlayer teamPlayer = this.m_Roster.SearchTeamPlayer(player);
      if (teamPlayer == null)
        return;
      this.RemoveTeamPlayer(teamPlayer);
    }

    public void AssignRoles()
    {
      this.AssignRoles(this.m_Formation);
    }

    public void AssignRoles(Formation formation)
    {
      Roster roster = new Roster(32);
      ERole[] availableRoles = new ERole[11];
      int nRoles = 11;
      for (int index = 0; index < 11; ++index)
        availableRoles[index] = formation.PlayingRoles[index].Role.RoleId;
      for (int index1 = 0; index1 < 7; ++index1)
      {
        TeamPlayer bestPlayer = this.m_Roster.GetBestPlayer();
        if (bestPlayer != null)
        {
          ERole erole = bestPlayer.Player.ChooseRole(availableRoles, nRoles);
          bestPlayer.position = (int) erole;
          roster.Add((object) bestPlayer);
          this.m_Roster.Remove((object) bestPlayer);
          for (int index2 = 0; index2 < nRoles; ++index2)
          {
            if (erole == availableRoles[index2])
            {
              for (int index3 = index2; index3 < nRoles - 1; ++index3)
                availableRoles[index3] = availableRoles[index3 + 1];
              --nRoles;
            }
          }
        }
        else
          break;
      }
      for (int index = 0; index < nRoles; ++index)
      {
        ERole requestedRole = availableRoles[index];
        TeamPlayer roleBestPlayer = this.m_Roster.GetRoleBestPlayer(requestedRole);
        if (roleBestPlayer != null)
        {
          roleBestPlayer.position = (int) requestedRole;
          roster.Add((object) roleBestPlayer);
          this.m_Roster.Remove((object) roleBestPlayer);
        }
        else
          break;
      }
      for (int index = 0; index < 7; ++index)
      {
        TeamPlayer bestPlayer = this.m_Roster.GetBestPlayer();
        if (bestPlayer != null)
        {
          bestPlayer.position = 28;
          roster.Add((object) bestPlayer);
          this.m_Roster.Remove((object) bestPlayer);
        }
        else
          break;
      }
      for (int index = 0; index < 14; ++index)
      {
        TeamPlayer bestPlayer = this.m_Roster.GetBestPlayer();
        if (bestPlayer != null)
        {
          bestPlayer.position = 29;
          roster.Add((object) bestPlayer);
          this.m_Roster.Remove((object) bestPlayer);
        }
        else
          break;
      }
      foreach (TeamPlayer teamPlayer in (ArrayList) roster)
        this.m_Roster.Add((object) teamPlayer);
    }

    public void AssignTitolarToRoles(Formation formation)
    {
      Roster roster = new Roster(32);
      ERole[] availableRoles = new ERole[11];
      int nRoles = 11;
      for (int index = 0; index < 11; ++index)
        availableRoles[index] = formation.PlayingRoles[index].Role.RoleId;
      for (int index1 = 0; index1 < 11; ++index1)
      {
        TeamPlayer bestTitolar = this.m_Roster.GetBestTitolar();
        if (bestTitolar != null)
        {
          ERole erole = bestTitolar.Player.ChooseRole(availableRoles, nRoles);
          bestTitolar.position = (int) erole;
          roster.Add((object) bestTitolar);
          this.m_Roster.Remove((object) bestTitolar);
          for (int index2 = 0; index2 < nRoles; ++index2)
          {
            if (erole == availableRoles[index2])
            {
              for (int index3 = index2; index3 < nRoles - 1; ++index3)
                availableRoles[index3] = availableRoles[index3 + 1];
              --nRoles;
            }
          }
        }
        else
          break;
      }
      foreach (TeamPlayer teamPlayer in (ArrayList) roster)
        this.m_Roster.Add((object) teamPlayer);
    }

    public void AssignRoleToSubstitute(ERole role)
    {
      int num = -1;
      TeamPlayer teamPlayer1 = (TeamPlayer) null;
      foreach (TeamPlayer teamPlayer2 in (ArrayList) this.m_Roster)
      {
        if (teamPlayer2.position >= 28)
        {
          int rolePerformance = teamPlayer2.Player.GetRolePerformance(role);
          if (rolePerformance > num)
          {
            num = rolePerformance;
            teamPlayer1 = teamPlayer2;
          }
        }
      }
      if (teamPlayer1 == null)
        return;
      teamPlayer1.position = (int) role;
    }

    public void AssignBench()
    {
      int num = 0;
      foreach (TeamPlayer teamPlayer in (ArrayList) this.m_Roster)
      {
        if (teamPlayer.position == 28)
          ++num;
      }
      for (int index = num; index < 7; ++index)
      {
        foreach (TeamPlayer teamPlayer in (ArrayList) this.m_Roster)
        {
          if (teamPlayer.position == 29)
          {
            teamPlayer.position = 28;
            break;
          }
        }
      }
    }

    public void AssignCaptain()
    {
      int num = -1;
      TeamPlayer teamPlayer1 = (TeamPlayer) null;
      foreach (TeamPlayer teamPlayer2 in (ArrayList) this.m_Roster)
      {
        if (teamPlayer2.position < 28)
        {
          int meanAttributes = teamPlayer2.Player.ComputeMeanAttributes(5);
          if (meanAttributes >= num)
          {
            teamPlayer1 = teamPlayer2;
            num = meanAttributes;
          }
        }
      }
      if (teamPlayer1 == null)
        return;
      this.PlayerCaptain = teamPlayer1.Player;
      this.m_captainid = this.PlayerCaptain.Id;
    }

    public void AssignPenalty()
    {
      int num = -1;
      TeamPlayer teamPlayer1 = (TeamPlayer) null;
      foreach (TeamPlayer teamPlayer2 in (ArrayList) this.m_Roster)
      {
        if (teamPlayer2.position < 28)
        {
          int meanAttributes = teamPlayer2.Player.ComputeMeanAttributes(3);
          if (meanAttributes >= num)
          {
            teamPlayer1 = teamPlayer2;
            num = meanAttributes;
          }
        }
      }
      if (teamPlayer1 == null)
        return;
      this.PlayerPenalty = teamPlayer1.Player;
      this.m_penaltytakerid = this.PlayerCaptain.Id;
    }

    public void AssignFreeKick()
    {
      int num1 = -1;
      int num2 = -1;
      TeamPlayer teamPlayer1 = (TeamPlayer) null;
      TeamPlayer teamPlayer2 = (TeamPlayer) null;
      foreach (TeamPlayer teamPlayer3 in (ArrayList) this.m_Roster)
      {
        if (teamPlayer3.position < 28)
        {
          int freekickaccuracy = teamPlayer3.Player.freekickaccuracy;
          if (freekickaccuracy >= num1)
          {
            teamPlayer1 = teamPlayer3;
            num1 = freekickaccuracy;
          }
          int num3 = teamPlayer3.Player.freekickaccuracy + teamPlayer3.Player.longshots;
          if (num3 >= num2)
          {
            teamPlayer2 = teamPlayer3;
            num2 = num3;
          }
        }
      }
      if (teamPlayer1 != null)
      {
        this.PlayerFreeKick = teamPlayer1.Player;
        this.PlayerLeftFreeKick = teamPlayer1.Player;
        this.PlayerRightFreeKick = teamPlayer1.Player;
        this.m_freekicktakerid = this.PlayerFreeKick.Id;
        this.m_leftfreekicktakerid = this.PlayerFreeKick.Id;
        this.m_rightfreekicktakerid = this.PlayerFreeKick.Id;
      }
      if (teamPlayer2 == null)
        return;
      this.PlayerLongKick = teamPlayer1.Player;
      this.m_longkicktakerid = this.PlayerFreeKick.Id;
    }

    public void AssignLeftCorner()
    {
      int num = -1;
      TeamPlayer teamPlayer1 = (TeamPlayer) null;
      foreach (TeamPlayer teamPlayer2 in (ArrayList) this.m_Roster)
      {
        if (teamPlayer2.position < 28)
        {
          int crossing = teamPlayer2.Player.crossing;
          if (crossing >= num)
          {
            teamPlayer1 = teamPlayer2;
            num = crossing;
          }
        }
      }
      if (teamPlayer1 == null)
        return;
      this.PlayerLeftCorner = teamPlayer1.Player;
      this.m_leftcornerkicktakerid = this.PlayerLeftCorner.Id;
    }

    public void AssignRightCorner()
    {
      int num = -1;
      TeamPlayer teamPlayer1 = (TeamPlayer) null;
      foreach (TeamPlayer teamPlayer2 in (ArrayList) this.m_Roster)
      {
        if (teamPlayer2.position < 28)
        {
          int crossing = teamPlayer2.Player.crossing;
          if (crossing >= num)
          {
            teamPlayer1 = teamPlayer2;
            num = crossing;
          }
        }
      }
      if (teamPlayer1 == null)
        return;
      this.PlayerRightCorner = teamPlayer1.Player;
      this.m_rightcornerkicktakerid = this.PlayerRightCorner.Id;
    }

    public void AddTeamPlayer(TeamPlayer teamPlayer)
    {
      teamPlayer.position = 29;
      teamPlayer.m_jerseynumber = this.m_Roster.GetFreeNumber();
      teamPlayer.Team = this;
      this.m_Roster.Add((object) teamPlayer);
      teamPlayer.Player.PlayFor(this);
    }

    public void AddTeamPlayer(Player player)
    {
      this.AddTeamPlayer(new TeamPlayer(player));
    }

    public Kit GetKit(int kitType)
    {
      return this.m_KitList.GetKit(this.Id, kitType);
    }
  }
}
