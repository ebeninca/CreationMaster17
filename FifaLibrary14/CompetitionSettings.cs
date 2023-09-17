// Original code created by Rinaldo

using System;
using System.IO;

namespace FifaLibrary
{
  public class CompetitionSettings
  {
    public int m_nation_id = -1;
    public int[] m_asset_id = new int[2];
    public int m_N_asset_id;
    public int m_rule_numsubsbench = -1;
    public int m_rule_numsubsmatch = -1;
    public int m_rule_suspension = -1;
    public int m_rule_numyellowstored = -1;
    public int m_rule_numgamesbanredmax = -1;
    public int m_rule_numgamesbanredmin = -1;
    public int m_rule_numgamesbandoubleyellowmax = -1;
    public int m_rule_numgamesbandoubleyellowmin = -1;
    public int m_rule_numgamesbanyellowsmax = -1;
    public int m_rule_numgamesbanyellowsmin = -1;
    public int m_standings_pointswin = -1;
    public int m_standings_pointsdraw = -1;
    public int m_standings_pointsloss = -1;
    public string[] m_standings_sort = new string[6];
    public int m_StandingsSort = -1;
    public int m_match_matchimportance = -1;
    public string[] m_match_endruleko1leg = new string[6];
    public int m_EndRuleKo1Leg = -1;
    public string[] m_match_endruleko2leg2 = new string[6];
    public int m_EndRuleKo2Leg2 = -1;
    public int m_info_prize_money = -1;
    public int m_info_prize_money_drop = -1;
    public int m_info_color_slot_champ = -1;
    public int[] m_info_color_slot_champ_cup = new int[4];
    public int[] m_info_color_slot_euro_league = new int[4];
    public int[] m_info_color_slot_promo = new int[4];
    public int[] m_info_color_slot_promo_poss = new int[4];
    public int[] m_info_color_slot_releg = new int[4];
    public int[] m_info_color_slot_releg_poss = new int[4];
    public int[] m_info_color_slot_adv_group = new int[8];
    //public int m_stage_info_color_slot_adv_group = -1;
    public int m_info_slot_champ = -1;
    public int[] m_info_slot_promo = new int[4];
    public int[] m_info_slot_promo_poss = new int[4];
    public int[] m_info_slot_releg = new int[4];
    public int[] m_info_slot_releg_poss = new int[4];
    public int m_info_league_promo = -1;
    public int m_info_league_releg = -1;
    public int[] m_info_special_team_id = new int[8];
    public int m_schedule_year_start = -1;
    public int m_schedule_year_offset = -1;
    public int m_schedule_friendlydaysbetweenmin = -1;
    public int m_schedule_friendlydaysbefore = -1;
    public int m_schedule_checkconflict = -1;
    private int m_schedule_compdependency = -1;
    private int m_schedule_forcecomp = -1;
    public int m_schedule_use_dates_comp = -1;
    private int m_schedule_internationaldependency = -1;
    public int m_schedule_matchreplay = -1;
    public int m_schedule_reversed = -1;
    public int m_schedule_year_real = -1;
    public int m_num_games = -1;
    private int m_advance_pointskeep = -1;
    public int m_advance_pointskeeppercentage = -1;
    public int m_advance_matchupkeep = -1;
    public int m_advance_random_draw_event = -1;
    public string m_match_canusefancards;
    public int m_advance_randomdraw = -1;
    public int m_advance_calccompavgs = -1;
    public int m_advance_maxteamsassoc = -1;
    public int m_advance_maxteamsgroup = -1;
    private int m_advance_maxteamsstageref = -1;
    private int m_advance_standingskeep = -1;
    private int m_advance_standingsagg = -1;
    public int m_advance_jleagueignorecheck = -1;
    private int m_advance_jleagueqtrsetup = -1;
    private int m_advance_standingsrank = -1;
    private int m_standings_checkrank = -1;
    public int m_advance_teamcompdependency = -1;
    private Compobj m_OwnerCompObj;
    public CompetitionSettings m_ParentSettings;
    public string m_comp_type;
    public string m_rule_bookings;
    public string m_rule_offsides;
    public string m_rule_injuries;
    public int m_N_standings_sort;
    private Stage m_StageAdvanceMaxteamsStageRef;
    private Stage m_StageAdvanceStandingsKeep;
    private Stage m_StageAdvanceStandingsAgg;
    private Stage m_StageAdvanceJLeagueQtrSetup;
    private Stage m_StageAdvanceStandingsRank;
    private Stage m_StageStandingsCheckRank;
    private Stage m_StageAdvancePointsKeep;
    public string m_match_stagetype;
    public string m_match_matchsituation;
    public string m_match_endruleleague;
    public int m_N_endruleko1leg;
    public string m_match_endruleko2leg1;
    public int m_N_endruleko2leg2;
    public string m_match_endrulefriendly;
    public string m_match_celebrationlevel;
    public int[] m_match_stadium;
    public int m_N_match_stadium;
    public int m_N_info_color_slot_champ_cup;
    public int m_N_info_color_slot_euro_league;
    public int m_N_info_color_slot_promo;
    public int m_N_info_color_slot_promo_poss;
    public int m_N_info_color_slot_releg;
    public int m_N_info_color_slot_releg_poss;
    public int m_N_info_color_slot_adv_group;
    public int m_N_info_slot_promo;
    public int m_N_info_slot_promo_poss;
    public int m_N_info_slot_releg;
    public int m_N_info_slot_releg_poss;
    public int m_N_info_special_team_id;
    public string m_schedule_seasonstartmonth;
    private Trophy m_TrophyCompdependency;
    private Trophy m_TrophyForcecomp;
    private League m_LeaguePromo;
    private League m_LeagueReleg;

    public void GetInfoColorSlotChampCup(out int min, out int max)
    {
      if (this.m_N_info_color_slot_champ_cup == 0)
      {
        min = -1;
        max = -1;
      }
      else
      {
        min = this.m_info_color_slot_champ_cup[0];
        max = this.m_info_color_slot_champ_cup[this.m_N_info_color_slot_champ_cup - 1];
        if (min <= max)
          return;
        int num = min;
        min = max;
        max = num;
      }
    }

    public bool SetInfoColorSlotChampCup(int min, int max)
    {
      if (min == -1 || max == -1 || min > max)
      {
        this.m_N_info_color_slot_champ_cup = 0;
        this.m_info_color_slot_champ_cup[0] = -1;
        return true;
      }
      for (int index = 0; index < this.m_info_color_slot_champ_cup.Length; ++index)
      {
        if (min + index <= max)
        {
          this.m_info_color_slot_champ_cup[index] = min + index;
          this.m_N_info_color_slot_champ_cup = index + 1;
        }
        else
          this.m_info_color_slot_champ_cup[index] = -1;
      }
      return true;
    }

    public void GetInfoColorSlotEuroLeague(out int min, out int max)
    {
      if (this.m_N_info_color_slot_euro_league == 0)
      {
        min = -1;
        max = -1;
      }
      else
      {
        min = this.m_info_color_slot_euro_league[0];
        max = this.m_info_color_slot_euro_league[this.m_N_info_color_slot_euro_league - 1];
        if (min <= max)
          return;
        int num = min;
        min = max;
        max = num;
      }
    }

    public bool SetInfoColorSlotEuroLeague(int min, int max)
    {
      if (min == -1 || max == -1 || min > max)
      {
        this.m_N_info_color_slot_euro_league = 0;
        this.m_info_color_slot_euro_league[0] = -1;
        return true;
      }
      for (int index = 0; index < this.m_info_color_slot_euro_league.Length; ++index)
      {
        if (min + index <= max)
        {
          this.m_info_color_slot_euro_league[index] = min + index;
          this.m_N_info_color_slot_euro_league = index + 1;
        }
        else
          this.m_info_color_slot_euro_league[index] = -1;
      }
      return true;
    }

    public void GetInfoColorSlotPromo(out int min, out int max)
    {
      if (this.m_N_info_color_slot_promo == 0)
      {
        min = -1;
        max = -1;
      }
      else
      {
        min = this.m_info_color_slot_promo[0];
        max = this.m_info_color_slot_promo[this.m_N_info_color_slot_promo - 1];
        if (min <= max)
          return;
        int num = min;
        min = max;
        max = num;
      }
    }

    public bool SetInfoColorSlotPromo(int min, int max)
    {
      if (min == -1 || max == -1 || min > max)
      {
        this.m_N_info_color_slot_promo = 0;
        this.m_info_color_slot_promo[0] = -1;
        return true;
      }
      for (int index = 0; index < this.m_info_color_slot_promo.Length; ++index)
      {
        if (min + index <= max)
        {
          this.m_info_color_slot_promo[index] = min + index;
          this.m_N_info_color_slot_promo = index + 1;
        }
        else
          this.m_info_color_slot_promo[index] = -1;
      }
      return true;
    }

    public void GetInfoColorSlotPromoPoss(out int min, out int max)
    {
      if (this.m_N_info_color_slot_promo_poss == 0)
      {
        min = -1;
        max = -1;
      }
      else
      {
        min = this.m_info_color_slot_promo_poss[0];
        max = this.m_info_color_slot_promo_poss[this.m_N_info_color_slot_promo_poss - 1];
        if (min <= max)
          return;
        int num = min;
        min = max;
        max = num;
      }
    }

    public bool SetInfoColorSlotPromoPoss(int min, int max)
    {
      if (min == -1 || max == -1 || min > max)
      {
        this.m_N_info_color_slot_promo_poss = 0;
        this.m_info_color_slot_promo_poss[0] = -1;
        return true;
      }
      for (int index = 0; index < this.m_info_color_slot_promo_poss.Length; ++index)
      {
        if (min + index <= max)
        {
          this.m_info_color_slot_promo_poss[index] = min + index;
          this.m_N_info_color_slot_promo_poss = index + 1;
        }
        else
          this.m_info_color_slot_promo_poss[index] = -1;
      }
      return true;
    }

    public void GetInfoColorSlotReleg(out int min, out int max)
    {
      if (this.m_N_info_color_slot_releg == 0)
      {
        min = -1;
        max = -1;
      }
      else
      {
        min = this.m_info_color_slot_releg[0];
        max = this.m_info_color_slot_releg[this.m_N_info_color_slot_releg - 1];
        if (min <= max)
          return;
        int num = min;
        min = max;
        max = num;
      }
    }

    public bool SetInfoColorSlotReleg(int min, int max)
    {
      if (min == -1 || max == -1 || min > max)
      {
        this.m_N_info_color_slot_releg = 0;
        this.m_info_color_slot_releg[0] = -1;
        return true;
      }
      for (int index = 0; index < this.m_info_color_slot_releg.Length; ++index)
      {
        if (min + index <= max)
        {
          this.m_info_color_slot_releg[index] = min + index;
          this.m_N_info_color_slot_releg = index + 1;
        }
        else
          this.m_info_color_slot_releg[index] = -1;
      }
      return true;
    }

    public void GetInfoColorSlotRelegPoss(out int min, out int max)
    {
      if (this.m_N_info_color_slot_releg_poss == 0)
      {
        min = -1;
        max = -1;
      }
      else
      {
        min = this.m_info_color_slot_releg_poss[0];
        max = this.m_info_color_slot_releg_poss[this.m_N_info_color_slot_releg_poss - 1];
        if (min <= max)
          return;
        int num = min;
        min = max;
        max = num;
      }
    }

    public bool SetInfoColorSlotRelegPoss(int min, int max)
    {
      if (min == -1 || max == -1 || min > max)
      {
        this.m_N_info_color_slot_releg_poss = 0;
        this.m_info_color_slot_releg_poss[0] = -1;
        return true;
      }
      for (int index = 0; index < this.m_info_color_slot_releg_poss.Length; ++index)
      {
        if (min + index <= max)
        {
          this.m_info_color_slot_releg_poss[index] = min + index;
          this.m_N_info_color_slot_releg_poss = index + 1;
        }
        else
          this.m_info_color_slot_releg_poss[index] = -1;
      }
      return true;
    }

    public void GetInfoColorSlotAdvGroup(out int min, out int max)
    {
      if (this.m_N_info_color_slot_adv_group == 0)
      {
        min = -1;
        max = -1;
      }
      else
      {
        min = this.m_info_color_slot_adv_group[0];
        max = this.m_info_color_slot_adv_group[this.m_N_info_color_slot_adv_group - 1];
        if (min <= max)
          return;
        int num = min;
        min = max;
        max = num;
      }
    }

    public bool SetInfoColorSlotAdvGroup(int min, int max)
    {
      if (min == -1 || max == -1 || min > max)
      {
        this.m_N_info_color_slot_adv_group = 0;
        this.m_info_color_slot_adv_group[0] = -1;
        return true;
      }
      for (int index = 0; index < this.m_info_color_slot_adv_group.Length; ++index)
      {
        if (min + index <= max)
        {
          this.m_info_color_slot_adv_group[index] = min + index;
          this.m_N_info_color_slot_adv_group = index + 1;
        }
        else
          this.m_info_color_slot_adv_group[index] = -1;
      }
      return true;
    }

    public void GetInfoSlotPromo(out int min, out int max)
    {
      if (this.m_N_info_slot_promo == 0)
      {
        min = -1;
        max = -1;
      }
      else
      {
        min = this.m_info_slot_promo[0];
        max = this.m_info_slot_promo[this.m_N_info_slot_promo - 1];
        if (min <= max)
          return;
        int num = min;
        min = max;
        max = num;
      }
    }

    public bool SetInfoSlotPromo(int min, int max)
    {
      if (min == -1 || max == -1 || min > max)
      {
        this.m_N_info_slot_promo = 0;
        this.m_info_slot_promo[0] = -1;
        return true;
      }
      for (int index = 0; index < this.m_info_slot_promo.Length; ++index)
      {
        if (min + index <= max)
        {
          this.m_info_slot_promo[index] = min + index;
          this.m_N_info_slot_promo = index + 1;
        }
        else
          this.m_info_slot_promo[index] = -1;
      }
      return true;
    }

    public void GetInfoSlotPromoPoss(out int min, out int max)
    {
      if (this.m_N_info_slot_promo_poss == 0)
      {
        min = -1;
        max = -1;
      }
      else
      {
        min = this.m_info_slot_promo_poss[0];
        max = this.m_info_slot_promo_poss[this.m_N_info_slot_promo_poss - 1];
        if (min <= max)
          return;
        int num = min;
        min = max;
        max = num;
      }
    }

    public bool SetInfoSlotPromoPoss(int min, int max)
    {
      if (min == -1 || max == -1 || min > max)
      {
        this.m_N_info_slot_promo_poss = 0;
        this.m_info_slot_promo_poss[0] = -1;
        return true;
      }
      for (int index = 0; index < this.m_info_slot_promo_poss.Length; ++index)
      {
        if (min + index <= max)
        {
          this.m_info_slot_promo_poss[index] = min + index;
          this.m_N_info_slot_promo_poss = index + 1;
        }
        else
          this.m_info_slot_promo_poss[index] = -1;
      }
      return true;
    }

    public void GetInfoSlotReleg(out int min, out int max)
    {
      if (this.m_N_info_slot_releg == 0)
      {
        min = -1;
        max = -1;
      }
      else
      {
        min = this.m_info_slot_releg[0];
        max = this.m_info_slot_releg[this.m_N_info_slot_releg - 1];
        if (min <= max)
          return;
        int num = min;
        min = max;
        max = num;
      }
    }

    public bool SetInfoSlotReleg(int min, int max)
    {
      if (min == -1 || max == -1 || min > max)
      {
        this.m_N_info_slot_releg = 0;
        this.m_info_slot_releg[0] = -1;
        return true;
      }
      for (int index = 0; index < this.m_info_slot_releg.Length; ++index)
      {
        if (min + index <= max)
        {
          this.m_info_slot_releg[index] = min + index;
          this.m_N_info_slot_releg = index + 1;
        }
        else
          this.m_info_slot_releg[index] = -1;
      }
      return true;
    }

    public void GetInfoSlotRelegPoss(out int min, out int max)
    {
      if (this.m_N_info_slot_releg_poss == 0)
      {
        min = -1;
        max = -1;
      }
      else
      {
        min = this.m_info_slot_releg_poss[0];
        max = this.m_info_slot_releg_poss[this.m_N_info_slot_releg_poss - 1];
        if (min <= max)
          return;
        int num = min;
        min = max;
        max = num;
      }
    }

    public bool SetInfoSlotRelegPoss(int min, int max)
    {
      if (min == -1 || max == -1 || min > max)
      {
        this.m_N_info_slot_releg_poss = 0;
        this.m_info_slot_releg_poss[0] = -1;
        return true;
      }
      for (int index = 0; index < this.m_info_slot_releg_poss.Length; ++index)
      {
        if (min + index <= max)
        {
          this.m_info_slot_releg_poss[index] = min + index;
          this.m_N_info_slot_releg_poss = index + 1;
        }
        else
          this.m_info_slot_releg_poss[index] = -1;
      }
      return true;
    }

    public bool SetAssetId(int pos, int val)
    {
      this.m_asset_id[pos] = val;
      this.m_N_asset_id = 0;
      foreach (int assetId in m_asset_id)
      {
        this.m_N_asset_id += (assetId > 0 ? 1 : 0);
      }
      return true;
    }

    public Trophy TrophyCompdependency
    {
      get
      {
        if (this.m_TrophyCompdependency == null && this.m_schedule_compdependency != -1)
          this.m_TrophyCompdependency = (Trophy)FifaEnvironment.CompetitionObjects.SearchId(this.m_schedule_compdependency);
        return this.m_TrophyCompdependency;
      }
      set
      {
        this.m_TrophyCompdependency = value;
        this.m_schedule_compdependency = this.m_TrophyCompdependency != null ? this.m_TrophyCompdependency.Id : -1;
      }
    }

    public Trophy TrophyForcecomp
    {
      get
      {
        if (this.m_TrophyForcecomp == null && this.m_schedule_forcecomp != -1)
          this.m_TrophyForcecomp = (Trophy)FifaEnvironment.CompetitionObjects.SearchId(this.m_schedule_forcecomp);
        return this.m_TrophyForcecomp;
      }
      set
      {
        this.m_TrophyForcecomp = value;
        this.m_schedule_forcecomp = this.m_TrophyForcecomp != null ? this.m_TrophyForcecomp.Id : -1;
      }
    }

    public int Advance_pointskeep
    {
      get
      {
        return this.m_advance_pointskeep;
      }
      set
      {
        this.m_advance_pointskeep = value;
        this.UpdateStageReferenceUsingId();
      }
    }

    public int Advance_maxteamsstageref
    {
      get
      {
        return this.m_advance_maxteamsstageref;
      }
      set
      {
        this.m_advance_maxteamsstageref = value;
        this.UpdateStageReferenceUsingId();
      }
    }

    public int Advance_standingskeep
    {
      get
      {
        return this.m_advance_standingskeep;
      }
      set
      {
        this.m_advance_standingskeep = value;
        this.UpdateStageReferenceUsingId();
      }
    }

    public int Advance_standingsagg
    {
      get
      {
        return this.m_advance_standingsagg;
      }
      set
      {
        this.m_advance_standingsagg = value;
        this.UpdateStageReferenceUsingId();
      }
    }

    public int Advance_jleagueignorecheck
    {
      get
      {
        return this.m_advance_jleagueignorecheck;
      }
      set
      {
        this.m_advance_jleagueignorecheck = value;
        this.UpdateStageReferenceUsingId();
      }
    }

    public int Advance_jleagueqtrsetup
    {
      get
      {
        return this.m_advance_jleagueqtrsetup;
      }
      set
      {
        this.m_advance_jleagueqtrsetup = value;
        this.UpdateStageReferenceUsingId();
      }
    }

    public int Advance_standingsrank
    {
      get
      {
        return this.m_advance_standingsrank;
      }
      set
      {
        this.m_advance_standingsrank = value;
        this.UpdateStageReferenceUsingId();
      }
    }

    public int Standings_checkrank
    {
      get
      {
        return this.m_standings_checkrank;
      }
      set
      {
        this.m_standings_checkrank = value;
        this.UpdateStageReferenceUsingId();
      }
    }

    public League LeaguePromo
    {
      get
      {
        return this.m_LeaguePromo;
      }
      set
      {
        this.m_LeaguePromo = value;
        this.m_info_league_promo = this.m_LeaguePromo != null ? this.m_LeaguePromo.Id : -1;
      }
    }

    public League LeagueReleg
    {
      get
      {
        return this.m_LeagueReleg;
      }
      set
      {
        this.m_LeagueReleg = value;
        this.m_info_league_releg = this.m_LeagueReleg != null ? this.m_LeagueReleg.Id : -1;
      }
    }

    public CompetitionSettings(Compobj compobj)
    {
      this.m_OwnerCompObj = compobj;
      if (compobj.ParentObj == null)
        return;
      this.m_ParentSettings = compobj.ParentObj.Settings;
    }

    public void SetProperty(string property, int index, string val)
    {
      if (index == 0)
        this.LoadProperty(property, val);
      else if (property == "match_endruleko1leg")
      {
        if (index >= this.m_match_endruleko1leg.Length)
          return;
        this.m_match_endruleko1leg[index] = val;
      }
      else if (property == "match_endruleko2leg2")
      {
        if (index >= this.m_match_endruleko2leg2.Length)
          return;
        this.m_match_endruleko2leg2[index] = val;
      }
      else if (property == "standings_sort")
      {
        if (index >= this.m_standings_sort.Length)
          return;
        this.m_standings_sort[index] = val;
      }
      else if (property == "info_slot_promo")
      {
        if (index >= this.m_info_slot_promo.Length)
          return;
        this.m_info_slot_promo[index] = Convert.ToInt32(val);
      }
      else if (property == "info_slot_promo_poss")
      {
        if (index >= this.m_info_slot_promo_poss.Length)
          return;
        this.m_info_slot_promo_poss[index] = Convert.ToInt32(val);
      }
      else if (property == "info_slot_releg")
      {
        if (index >= this.m_info_slot_releg.Length)
          return;
        this.m_info_slot_releg[index] = Convert.ToInt32(val);
      }
      else if (property == "info_slot_releg_poss")
      {
        if (index >= this.m_info_slot_releg_poss.Length)
          return;
        this.m_info_slot_releg_poss[index] = Convert.ToInt32(val);
      }
      else if (property == "info_color_slot_champ_cup")
      {
        if (index >= this.m_info_color_slot_champ_cup.Length)
          return;
        this.m_info_color_slot_champ_cup[index] = Convert.ToInt32(val);
      }
      else if (property == "info_color_slot_euro_league")
      {
        if (index >= this.m_info_color_slot_euro_league.Length)
          return;
        this.m_info_color_slot_euro_league[index] = Convert.ToInt32(val);
      }
      else if (property == "info_color_slot_promo")
      {
        if (index >= this.m_info_color_slot_promo.Length)
          return;
        this.m_info_color_slot_promo[index] = Convert.ToInt32(val);
      }
      else if (property == "info_color_slot_promo_poss")
      {
        if (index >= this.m_info_color_slot_promo_poss.Length)
          return;
        this.m_info_color_slot_promo_poss[index] = Convert.ToInt32(val);
      }
      else if (property == "info_color_slot_releg")
      {
        if (index >= this.m_info_color_slot_releg.Length)
          return;
        this.m_info_color_slot_releg[index] = Convert.ToInt32(val);
      }
      else if (property == "info_color_slot_releg_poss")
      {
        if (index >= this.m_info_color_slot_releg_poss.Length)
          return;
        this.m_info_color_slot_releg_poss[index] = Convert.ToInt32(val);
      }
      else if (property == "match_stadium")
      {
        if (this.m_match_stadium == null)
        {
          this.m_match_stadium = new int[12];
          for (int index1 = 0; index1 < this.m_match_stadium.Length; ++index1)
            this.m_match_stadium[index1] = -1;
        }
        if (index >= this.m_match_stadium.Length)
          return;
        this.m_match_stadium[index] = Convert.ToInt32(val);
      }
      else if (property == "info_color_slot_adv_group")
      {
        if (index >= this.m_info_color_slot_adv_group.Length)
          return;
        this.m_info_color_slot_adv_group[index] = Convert.ToInt32(val);
      }
      else
      {
        if (!(property == "info_special_team_id") || index >= this.m_info_special_team_id.Length)
          return;
        this.m_info_special_team_id[index] = Convert.ToInt32(val);
      }
    }

    public void UpdateIdUsingStageReference()
    {
      this.m_advance_maxteamsstageref = this.m_StageAdvanceMaxteamsStageRef != null ? this.m_StageAdvanceMaxteamsStageRef.Id : -1;
      this.m_advance_standingskeep = this.m_StageAdvanceStandingsKeep != null ? this.m_StageAdvanceStandingsKeep.Id : -1;
      this.m_advance_standingsagg = this.m_StageAdvanceStandingsAgg != null ? this.m_StageAdvanceStandingsAgg.Id : -1;
      this.m_advance_jleagueqtrsetup = this.m_StageAdvanceJLeagueQtrSetup != null ? this.m_StageAdvanceJLeagueQtrSetup.Id : -1;
      this.m_advance_standingsrank = this.m_StageAdvanceStandingsRank != null ? this.m_StageAdvanceStandingsRank.Id : -1;
      this.m_standings_checkrank = this.m_StageStandingsCheckRank != null ? this.m_StageStandingsCheckRank.Id : -1;
      this.m_advance_pointskeep = this.m_StageAdvancePointsKeep != null ? this.m_StageAdvancePointsKeep.Id : -1;
    }

    public void UpdateStageReferenceUsingId()
    {
      if (FifaEnvironment.CompetitionObjects == null)
        return;
      if (this.m_standings_checkrank == -1)
      {
        this.m_StageStandingsCheckRank = (Stage)null;
      }
      else
      {
        Compobj compobj = (Compobj)FifaEnvironment.CompetitionObjects.SearchId(this.m_standings_checkrank);
        this.m_StageStandingsCheckRank = compobj == null || !compobj.IsStage() ? (Stage)null : (Stage)compobj;
      }
      if (this.m_advance_standingsrank == -1)
      {
        this.m_StageAdvanceStandingsRank = (Stage)null;
      }
      else
      {
        Compobj compobj = (Compobj)FifaEnvironment.CompetitionObjects.SearchId(this.m_advance_standingsrank);
        this.m_StageAdvanceStandingsRank = compobj == null || !compobj.IsStage() ? (Stage)null : (Stage)compobj;
      }
      if (this.m_advance_standingskeep == -1)
      {
        this.m_StageAdvanceStandingsKeep = (Stage)null;
      }
      else
      {
        Compobj compobj = (Compobj)FifaEnvironment.CompetitionObjects.SearchId(this.m_advance_standingskeep);
        this.m_StageAdvanceStandingsKeep = compobj == null || !compobj.IsStage() ? (Stage)null : (Stage)compobj;
      }
      if (this.m_advance_standingsagg == -1)
      {
        this.m_StageAdvanceStandingsAgg = (Stage)null;
      }
      else
      {
        Compobj compobj = (Compobj)FifaEnvironment.CompetitionObjects.SearchId(this.m_advance_standingsagg);
        this.m_StageAdvanceStandingsAgg = compobj == null || !compobj.IsStage() ? (Stage)null : (Stage)compobj;
      }
      if (this.m_advance_jleagueqtrsetup == -1)
      {
        this.m_StageAdvanceJLeagueQtrSetup = (Stage)null;
      }
      else
      {
        Compobj compobj = (Compobj)FifaEnvironment.CompetitionObjects.SearchId(this.m_advance_jleagueqtrsetup);
        this.m_StageAdvanceJLeagueQtrSetup = compobj == null || !compobj.IsStage() ? (Stage)null : (Stage)compobj;
      }
      if (this.m_advance_pointskeep == -1)
      {
        this.m_StageAdvancePointsKeep = (Stage)null;
      }
      else
      {
        Compobj compobj = (Compobj)FifaEnvironment.CompetitionObjects.SearchId(this.m_advance_pointskeep);
        this.m_StageAdvancePointsKeep = compobj == null || !compobj.IsStage() ? (Stage)null : (Stage)compobj;
      }
      if (this.m_advance_maxteamsstageref == -1)
      {
        this.m_StageAdvanceMaxteamsStageRef = (Stage)null;
      }
      else
      {
        Compobj compobj = (Compobj)FifaEnvironment.CompetitionObjects.SearchId(this.m_advance_maxteamsstageref);
        if (compobj != null && compobj.IsStage())
          this.m_StageAdvanceMaxteamsStageRef = (Stage)compobj;
        else
          this.m_StageAdvanceMaxteamsStageRef = (Stage)null;
      }
    }

    public bool IsStringProperty(string property)
    {
      return property == "comp_type" || property == "rule_bookings" || (property == "rule_offsides" || property == "rule_injuries") || (property == "match_stagetype" || property == "match_matchsituation" || (property == "match_endruleleague" || property == "match_endruleko1leg")) || (property == "match_endruleko2leg1" || property == "match_endruleko2leg2" || (property == "match_endrulefriendly" || property == "standings_sort") || property == "schedule_seasonstartmonth");
    }

    public int IsMultipleProperty(string property)
    {
      if (property == "match_endruleko1leg")
        return this.m_match_endruleko1leg.Length;
      if (property == "match_endruleko2leg2")
        return this.m_match_endruleko2leg2.Length;
      if (property == "standings_sort")
        return this.m_standings_sort.Length;
      if (property == "info_slot_promo")
        return this.m_info_slot_promo.Length;
      if (property == "info_slot_promo_poss")
        return this.m_info_slot_promo_poss.Length;
      if (property == "info_slot_releg")
        return this.m_info_slot_releg.Length;
      if (property == "info_slot_releg_poss")
        return this.m_info_slot_releg_poss.Length;
      if (property == "info_color_slot_champ_cup")
        return this.m_info_color_slot_champ_cup.Length;
      if (property == "info_color_slot_euro_league")
        return this.m_info_color_slot_euro_league.Length;
      if (property == "info_color_slot_promo")
        return this.m_info_color_slot_promo.Length;
      if (property == "info_color_slot_promo_poss")
        return this.m_info_color_slot_promo_poss.Length;
      if (property == "info_color_slot_releg")
        return this.m_info_color_slot_releg.Length;
      if (property == "info_color_slot_releg_poss")
        return this.m_info_color_slot_releg_poss.Length;
      if (property == "match_stadium")
        return this.m_match_stadium.Length;
      if (property == "info_color_slot_adv_group")
        return this.m_info_color_slot_adv_group.Length;
      return property == "info_special_team_id" ? this.m_info_special_team_id.Length : 1;
    }

    public string GetProperty(string property, int index, out bool isSpecific)
    {
      string str = this.GetSpecificProperty(property, index);
      isSpecific = false;
      if (str != null && str != "-1")
      {
        isSpecific = true;
        return str;
      }
      if (this.m_ParentSettings != null)
        str = this.m_ParentSettings.GetProperty(property, index, out bool _);
      if (str == null)
        str = string.Empty;
      return str;
    }

    public void LoadProperty(string property, string val)
    {
      if (property == "comp_type")
        this.m_comp_type = val;
      else if (property == "rule_bookings")
        this.m_rule_bookings = val;
      else if (property == "rule_offsides")
        this.m_rule_offsides = val;
      else if (property == "rule_injuries")
        this.m_rule_injuries = val;
      else if (property == "rule_numsubsbench")
        this.m_rule_numsubsbench = Convert.ToInt32(val);
      else if (property == "rule_suspension")
        this.m_rule_suspension = Convert.ToInt32(val);
      else if (property == "rule_numyellowstored")
        this.m_rule_numyellowstored = Convert.ToInt32(val);
      else if (property == "rule_numgamesbanredmax")
        this.m_rule_numgamesbanredmax = Convert.ToInt32(val);
      else if (property == "rule_numgamesbanredmin")
        this.m_rule_numgamesbanredmin = Convert.ToInt32(val);
      else if (property == "rule_numgamesbandoubleyellowmax")
        this.m_rule_numgamesbandoubleyellowmax = Convert.ToInt32(val);
      else if (property == "rule_numgamesbandoubleyellowmin")
        this.m_rule_numgamesbandoubleyellowmin = Convert.ToInt32(val);
      else if (property == "rule_numgamesbanyellowsmax")
        this.m_rule_numgamesbanyellowsmax = Convert.ToInt32(val);
      else if (property == "rule_numgamesbanyellowsmin")
        this.m_rule_numgamesbanyellowsmin = Convert.ToInt32(val);
      else if (property == "standings_pointswin")
        this.m_standings_pointswin = Convert.ToInt32(val);
      else if (property == "standings_pointsdraw")
        this.m_standings_pointsdraw = Convert.ToInt32(val);
      else if (property == "standings_pointsloss")
        this.m_standings_pointsloss = Convert.ToInt32(val);
      else if (property == "match_matchimportance")
        this.m_match_matchimportance = Convert.ToInt32(val);
      else if (property == "match_stagetype")
        this.m_match_stagetype = val;
      else if (property == "match_matchsituation")
        this.m_match_matchsituation = val;
      else if (property == "nation_id")
        this.m_nation_id = Convert.ToInt32(val);
      else if (property == "asset_id")
      {
        if (this.m_asset_id == null)
          this.m_asset_id = new int[2];
        if (this.m_N_asset_id >= this.m_asset_id.Length)
          return;
        this.m_asset_id[this.m_N_asset_id] = Convert.ToInt32(val);
        ++this.m_N_asset_id;
      }
      else if (property == "match_endruleleague")
        this.m_match_endruleleague = val;
      else if (property == "match_endruleko1leg")
      {
        this.m_match_endruleko1leg[this.m_N_endruleko1leg] = val;
        ++this.m_N_endruleko1leg;
        this.m_EndRuleKo1Leg = CompetitionSettings.GetKo1Rule(this.m_match_endruleko1leg);
      }
      else if (property == "match_endruleko2leg1")
        this.m_match_endruleko2leg1 = val;
      else if (property == "match_endruleko2leg2")
      {
        this.m_match_endruleko2leg2[this.m_N_endruleko2leg2] = val;
        ++this.m_N_endruleko2leg2;
        this.m_EndRuleKo2Leg2 = CompetitionSettings.GetKo2Rule(this.m_match_endruleko2leg2);
      }
      else if (property == "match_endrulefriendly")
        this.m_match_endrulefriendly = val;
      else if (property == "match_celebrationlevel")
        this.m_match_celebrationlevel = val;
      else if (property == "info_prize_money")
        this.m_info_prize_money = Convert.ToInt32(val);
      else if (property == "info_prize_money_drop")
        this.m_info_prize_money_drop = Convert.ToInt32(val);
      else if (property == "standings_sort")
      {
        this.m_standings_sort[this.m_N_standings_sort] = val;
        ++this.m_N_standings_sort;
        this.m_StandingsSort = CompetitionSettings.GetStandingRule(this.m_standings_sort);
      }
      else if (property == "schedule_seasonstartmonth")
        this.m_schedule_seasonstartmonth = val;
      else if (property == "schedule_year_start")
        this.m_schedule_year_start = Convert.ToInt32(val);
      else if (property == "schedule_year_offset")
        this.m_schedule_year_offset = Convert.ToInt32(val);
      else if (property == "schedule_friendlydaysbetweenmin")
        this.m_schedule_friendlydaysbetweenmin = Convert.ToInt32(val);
      else if (property == "schedule_friendlydaysbefore")
        this.m_schedule_friendlydaysbefore = Convert.ToInt32(val);
      else if (property == "schedule_use_dates_comp")
        this.m_schedule_use_dates_comp = Convert.ToInt32(val);
      else if (property == "info_slot_champ")
        this.m_info_slot_champ = Convert.ToInt32(val);
      else if (property == "info_color_slot_champ")
        this.m_info_color_slot_champ = Convert.ToInt32(val);
      else if (property == "info_slot_promo")
      {
        if (this.m_info_slot_promo == null)
          this.m_info_slot_promo = new int[4];
        if (this.m_N_info_slot_promo >= this.m_info_slot_promo.Length)
          return;
        this.m_info_slot_promo[this.m_N_info_slot_promo] = Convert.ToInt32(val);
        ++this.m_N_info_slot_promo;
      }
      else if (property == "info_slot_promo_poss")
      {
        if (this.m_info_slot_promo_poss == null)
          this.m_info_slot_promo_poss = new int[4];
        if (this.m_N_info_slot_promo_poss >= this.m_info_slot_promo_poss.Length)
          return;
        this.m_info_slot_promo_poss[this.m_N_info_slot_promo_poss] = Convert.ToInt32(val);
        ++this.m_N_info_slot_promo_poss;
      }
      else if (property == "info_slot_releg")
      {
        if (this.m_info_slot_releg == null)
          this.m_info_slot_releg = new int[4];
        if (this.m_N_info_slot_releg >= this.m_info_slot_releg.Length)
          return;
        this.m_info_slot_releg[this.m_N_info_slot_releg] = Convert.ToInt32(val);
        ++this.m_N_info_slot_releg;
      }
      else if (property == "info_slot_releg_poss")
      {
        if (this.m_info_slot_releg_poss == null)
          this.m_info_slot_releg_poss = new int[4];
        if (this.m_N_info_slot_releg_poss >= this.m_info_slot_releg_poss.Length)
          return;
        this.m_info_slot_releg_poss[this.m_N_info_slot_releg_poss] = Convert.ToInt32(val);
        ++this.m_N_info_slot_releg_poss;
      }
      else if (property == "info_color_slot_champ_cup")
      {
        if (this.m_info_color_slot_champ_cup == null)
          this.m_info_color_slot_champ_cup = new int[3];
        if (this.m_N_info_color_slot_champ_cup >= this.m_info_color_slot_champ_cup.Length)
          return;
        this.m_info_color_slot_champ_cup[this.m_N_info_color_slot_champ_cup] = Convert.ToInt32(val);
        ++this.m_N_info_color_slot_champ_cup;
      }
      else if (property == "info_color_slot_euro_league")
      {
        if (this.m_info_color_slot_euro_league == null)
          this.m_info_color_slot_euro_league = new int[4];
        if (this.m_N_info_color_slot_euro_league >= this.m_info_color_slot_euro_league.Length)
          return;
        this.m_info_color_slot_euro_league[this.m_N_info_color_slot_euro_league] = Convert.ToInt32(val);
        ++this.m_N_info_color_slot_euro_league;
      }
      else if (property == "info_color_slot_promo")
      {
        if (this.m_info_color_slot_promo == null)
          this.m_info_color_slot_promo = new int[4];
        if (this.m_N_info_color_slot_promo >= this.m_info_color_slot_promo.Length)
          return;
        this.m_info_color_slot_promo[this.m_N_info_color_slot_promo] = Convert.ToInt32(val);
        ++this.m_N_info_color_slot_promo;
      }
      else if (property == "info_color_slot_promo_poss")
      {
        if (this.m_info_color_slot_promo_poss == null)
          this.m_info_color_slot_promo_poss = new int[4];
        if (this.m_N_info_color_slot_promo_poss >= this.m_info_color_slot_promo_poss.Length)
          return;
        this.m_info_color_slot_promo_poss[this.m_N_info_color_slot_promo_poss] = Convert.ToInt32(val);
        ++this.m_N_info_color_slot_promo_poss;
      }
      else if (property == "info_color_slot_releg")
      {
        if (this.m_info_color_slot_releg == null)
          this.m_info_color_slot_releg = new int[4];
        if (this.m_N_info_color_slot_releg >= this.m_info_color_slot_releg.Length)
          return;
        this.m_info_color_slot_releg[this.m_N_info_color_slot_releg] = Convert.ToInt32(val);
        ++this.m_N_info_color_slot_releg;
      }
      else if (property == "info_color_slot_releg_poss")
      {
        if (this.m_info_color_slot_releg_poss == null)
          this.m_info_color_slot_releg_poss = new int[4];
        if (this.m_N_info_color_slot_releg_poss >= this.m_info_color_slot_releg_poss.Length)
          return;
        this.m_info_color_slot_releg_poss[this.m_N_info_color_slot_releg_poss] = Convert.ToInt32(val);
        ++this.m_N_info_color_slot_releg_poss;
      }
      else if (property == "num_games")
        this.m_num_games = Convert.ToInt32(val);
      else if (property == "advance_pointskeep")
        this.m_advance_pointskeep = Convert.ToInt32(val);
      else if (property == "advance_pointskeeppercentage")
        this.m_advance_pointskeeppercentage = Convert.ToInt32(val);
      else if (property == "advance_matchupkeep")
        this.m_advance_matchupkeep = Convert.ToInt32(val);
      else if (property == "match_stadium")
      {
        if (this.m_match_stadium == null)
        {
          this.m_match_stadium = new int[12];
          for (int index = 0; index < this.m_match_stadium.Length; ++index)
            this.m_match_stadium[index] = -1;
          this.m_N_match_stadium = 0;
        }
        if (this.m_N_match_stadium >= this.m_match_stadium.Length)
          return;
        this.m_match_stadium[this.m_N_match_stadium] = Convert.ToInt32(val);
        ++this.m_N_match_stadium;
      }
      else if (property == "info_color_slot_adv_group")
      {
        //this.m_stage_info_color_slot_adv_group = Convert.ToInt32(val);
        if (this.m_info_color_slot_adv_group == null)
          this.m_info_color_slot_adv_group = new int[8];
        if (this.m_N_info_color_slot_adv_group >= this.m_info_color_slot_adv_group.Length)
          return;
        this.m_info_color_slot_adv_group[this.m_N_info_color_slot_adv_group] = Convert.ToInt32(val);
        ++this.m_N_info_color_slot_adv_group;
      }
      else if (property == "rule_numsubsmatch")
        this.m_rule_numsubsmatch = Convert.ToInt32(val);
      else if (property == "schedule_checkconflict")
        this.m_schedule_checkconflict = Convert.ToInt32(val);
      else if (property == "schedule_compdependency")
        this.m_schedule_compdependency = Convert.ToInt32(val);
      else if (property == "schedule_internationaldependency")
        this.m_schedule_internationaldependency = Convert.ToInt32(val);
      else if (property == "schedule_forcecomp")
        this.m_schedule_forcecomp = Convert.ToInt32(val);
      else if (property == "advance_teamcompdependency")
        this.m_advance_teamcompdependency = Convert.ToInt32(val);
      else if (property == "info_league_promo")
        this.m_info_league_promo = Convert.ToInt32(val);
      else if (property == "info_league_releg")
        this.m_info_league_releg = Convert.ToInt32(val);
      else if (property == "info_special_team_id" && this.m_N_info_special_team_id < this.m_info_special_team_id.Length)
      {
        this.m_info_special_team_id[this.m_N_info_special_team_id] = Convert.ToInt32(val);
        ++this.m_N_info_special_team_id;
      }
      else if (property == "advance_random_draw_event")
        this.m_advance_random_draw_event = Convert.ToInt32(val);
      else if (property == "match_canusefancards")
        this.m_match_canusefancards = val;
      else if (property == "advance_randomdraw")
        this.m_advance_randomdraw = Convert.ToInt32(val);
      else if (property == "advance_calccompavgs")
        this.m_advance_calccompavgs = Convert.ToInt32(val);
      else if (property == "advance_maxteamsassoc")
        this.m_advance_maxteamsassoc = Convert.ToInt32(val);
      else if (property == "advance_maxteamsgroup")
        this.m_advance_maxteamsgroup = Convert.ToInt32(val);
      else if (property == "advance_maxteamsstageref")
        this.Advance_maxteamsstageref = Convert.ToInt32(val);
      else if (property == "advance_standingskeep")
        this.Advance_standingskeep = Convert.ToInt32(val);
      else if (property == "advance_standingsagg")
        this.Advance_standingsagg = Convert.ToInt32(val);
      else if (property == "advance_jleague_ignore_check")
        this.Advance_jleagueignorecheck = Convert.ToInt32(val);
      else if (property == "advance_jleague_qtr_setup")
        this.Advance_jleagueqtrsetup = Convert.ToInt32(val);
      else if (property == "advance_standingsrank")
        this.Advance_standingsrank = Convert.ToInt32(val);
      else if (property == "schedule_matchreplay")
        this.m_schedule_matchreplay = Convert.ToInt32(val);
      else if (property == "schedule_reversed")
        this.m_schedule_reversed = Convert.ToInt32(val);
      else if (property == "schedule_year_real")
      {
        this.m_schedule_year_real = Convert.ToInt32(val);
      }
      else
      {
        if (!(property == "standings_checkrank"))
          return;
        this.Standings_checkrank = Convert.ToInt32(val);
      }
    }

    public string GetSpecificProperty(string property, int index)
    {
      if (property == "comp_type")
        return this.m_comp_type;
      if (property == "rule_bookings")
        return this.m_rule_bookings;
      if (property == "rule_offsides")
        return this.m_rule_offsides;
      if (property == "rule_injuries")
        return this.m_rule_injuries;
      if (property == "rule_numsubsbench")
        return this.m_rule_numsubsbench.ToString();
      if (property == "rule_numsubsmatch")
        return this.m_rule_numsubsmatch.ToString();
      if (property == "rule_suspension")
        return this.m_rule_suspension.ToString();
      if (property == "rule_numyellowstored")
        return this.m_rule_numyellowstored.ToString();
      if (property == "rule_numgamesbanredmax")
        return this.m_rule_numgamesbanredmax.ToString();
      if (property == "rule_numgamesbanredmin")
        return this.m_rule_numgamesbanredmin.ToString();
      if (property == "rule_numgamesbandoubleyellowmax")
        return this.m_rule_numgamesbandoubleyellowmax.ToString();
      if (property == "rule_numgamesbandoubleyellowmin")
        return this.m_rule_numgamesbandoubleyellowmin.ToString();
      if (property == "rule_numgamesbanyellowsmax")
        return this.m_rule_numgamesbanyellowsmax.ToString();
      if (property == "rule_numgamesbanyellowsmin")
        return this.m_rule_numgamesbanyellowsmin.ToString();
      if (property == "standings_pointswin")
        return this.m_standings_pointswin.ToString();
      if (property == "standings_pointsdraw")
        return this.m_standings_pointsdraw.ToString();
      if (property == "standings_pointsloss")
        return this.m_standings_pointsloss.ToString();
      if (property == "match_matchimportance")
        return this.m_match_matchimportance.ToString();
      if (property == "match_stagetype")
        return this.m_match_stagetype;
      if (property == "match_matchsituation")
        return this.m_match_matchsituation;
      if (property == "nation_id")
        return this.m_nation_id.ToString();
      if (property == "asset_id")
        return this.m_asset_id.ToString();
      if (property == "match_endruleleague")
        return this.m_match_endruleleague;
      if (property == "match_endruleko1leg")
        return this.m_match_endruleko1leg[this.m_N_endruleko1leg];
      if (property == "match_endruleko2leg1")
        return this.m_match_endruleko2leg1;
      if (property == "match_endruleko2leg2")
        return this.m_match_endruleko2leg2[index];
      if (property == "match_endrulefriendly")
        return this.m_match_endrulefriendly;
      if (property == "match_celebrationlevel")
        return this.m_match_celebrationlevel;
      if (property == "info_prize_money")
        return this.m_info_prize_money.ToString();
      if (property == "info_prize_money_drop")
        return this.m_info_prize_money_drop.ToString();
      if (property == "standings_sort")
        return this.m_standings_sort[index];
      if (property == "schedule_seasonstartmonth")
        return this.m_schedule_seasonstartmonth;
      if (property == "schedule_year_start")
        return this.m_schedule_year_start.ToString();
      if (property == "schedule_year_offset")
        return this.m_schedule_year_offset.ToString();
      if (property == "schedule_friendlydaysbetweenmin" || property == "schedule_friendlydaysbefore")
        return this.m_schedule_friendlydaysbetweenmin.ToString();
      if (property == "schedule_use_dates_comp")
        return this.m_schedule_use_dates_comp.ToString();
      if (property == "info_slot_champ")
        return this.m_info_slot_champ.ToString();
      if (property == "info_color_slot_champ")
        return this.m_info_color_slot_champ.ToString();
      if (property == "info_slot_promo")
      {
        if (this.m_N_info_slot_promo < this.m_info_slot_promo.Length)
          return this.m_info_slot_promo[index].ToString();
      }
      else if (property == "info_slot_promo_poss")
      {
        if (this.m_N_info_slot_promo_poss < this.m_info_slot_promo_poss.Length)
          return this.m_info_slot_promo_poss[index].ToString();
      }
      else if (property == "info_slot_releg")
      {
        if (this.m_N_info_slot_releg < this.m_info_slot_releg.Length)
          return this.m_info_slot_releg[index].ToString();
      }
      else if (property == "info_slot_releg_poss")
      {
        if (this.m_N_info_slot_releg_poss < this.m_info_slot_releg_poss.Length)
          return this.m_info_slot_releg_poss[index].ToString();
      }
      else if (property == "info_color_slot_champ_cup")
      {
        if (this.m_N_info_color_slot_champ_cup < this.m_info_color_slot_champ_cup.Length)
          return this.m_info_color_slot_champ_cup[index].ToString();
      }
      else if (property == "info_color_slot_euro_league")
      {
        if (this.m_N_info_color_slot_euro_league < this.m_info_color_slot_euro_league.Length)
          return this.m_info_color_slot_euro_league[index].ToString();
      }
      else if (property == "info_color_slot_promo")
      {
        if (this.m_N_info_color_slot_promo < this.m_info_color_slot_promo.Length)
          return this.m_info_color_slot_promo[index].ToString();
      }
      else if (property == "info_color_slot_promo_poss")
      {
        if (this.m_N_info_color_slot_promo_poss < this.m_info_color_slot_promo_poss.Length)
          return this.m_info_color_slot_promo_poss[index].ToString();
      }
      else if (property == "info_color_slot_releg")
      {
        if (this.m_N_info_color_slot_releg < this.m_info_color_slot_releg.Length)
          return this.m_info_color_slot_releg[index].ToString();
      }
      else if (property == "info_color_slot_releg_poss")
      {
        if (this.m_N_info_color_slot_releg_poss < this.m_info_color_slot_releg_poss.Length)
          return this.m_info_color_slot_releg_poss[index].ToString();
      }
      else
      {
        if (property == "num_games")
          return this.m_num_games.ToString();
        if (property == "advance_pointskeep")
          return this.m_advance_pointskeep.ToString();
        if (property == "advance_pointskeeppercentage")
          return this.m_advance_pointskeeppercentage.ToString();
        if (property == "advance_matchupkeep")
          return this.m_advance_matchupkeep.ToString();
        if (property == "match_stadium")
        {
          if (index < this.m_match_stadium.Length)
            return this.m_match_stadium[index].ToString();
        }
        else if (property == "info_color_slot_adv_group")
        {
          if (this.m_N_info_color_slot_adv_group < this.m_info_color_slot_adv_group.Length)
            return this.m_info_color_slot_adv_group[index].ToString();
        }
        else if (property == "advance_standingsrank")
          return this.m_advance_standingsrank.ToString();
      }
      if (property == "asset_id")
        return this.m_asset_id.ToString();
      if (property == "rule_numsubsmatch")
        return this.m_rule_numsubsmatch.ToString();
      if (property == "schedule_checkconflict")
        return this.m_schedule_checkconflict.ToString();
      if (property == "schedule_compdependency")
        return this.m_schedule_compdependency.ToString();
      if (property == "schedule_internationaldependency")
        return this.m_schedule_internationaldependency.ToString();
      if (property == "schedule_forcecomp")
        return this.m_schedule_forcecomp.ToString();
      if (property == "advance_teamcompdependency")
        return this.m_advance_teamcompdependency.ToString();
      if (property == "info_league_promo")
        return this.m_info_league_promo.ToString();
      if (property == "info_league_releg")
        return this.m_info_league_releg.ToString();
      if (property == "info_special_team_id")
        return this.m_info_special_team_id[index].ToString();
      if (property == "advance_random_draw_rvrny")
        return this.m_advance_random_draw_event.ToString();
      if (property == "match_canusefancards")
        return this.m_match_canusefancards.ToString();
      if (property == "advance_randomdraw")
        return this.m_advance_randomdraw.ToString();
      if (property == "advance_calccompavgs")
        return this.m_advance_calccompavgs.ToString();
      if (property == "advance_maxteamsassoc")
        return this.m_advance_maxteamsassoc.ToString();
      if (property == "advance_maxteamsgroup")
        return this.m_advance_maxteamsgroup.ToString();
      if (property == "advance_maxteamsstageref")
        return this.m_advance_maxteamsstageref.ToString();
      if (property == "advance_standingskeep")
        return this.m_advance_standingskeep.ToString();
      if (property == "advance_standingsagg")
        return this.m_advance_standingsagg.ToString();
      if (property == "advance_jleague_ignore_check")
        return this.m_advance_jleagueignorecheck.ToString();
      if (property == "advance_jleague_qtr_setup")
        return this.m_advance_jleagueqtrsetup.ToString();
      if (property == "advance_standingsrank")
        return this.m_advance_standingsrank.ToString();
      if (property == "schedule_matchreplay")
        return this.m_schedule_matchreplay.ToString();
      if (property == "schedule_reversed")
        return this.m_schedule_reversed.ToString();
      if (property == "schedule_year_real")
        return this.m_schedule_year_real.ToString();
      return property == "standings_checkrank" ? this.m_standings_checkrank.ToString() : (string)null;
    }

    public bool SaveToSettings(int id, StreamWriter w)
    {
      if (w == null)
        return false;
      for (int index = 0; index < this.m_N_asset_id; ++index)
      {
        string str = id.ToString() + ",asset_id," + (object)this.m_asset_id[index];
        w.WriteLine(str);
      }
      if (this.m_comp_type != null)
      {
        string str = id.ToString() + ",comp_type," + this.m_comp_type;
        w.WriteLine(str);
      }
      if (this.m_nation_id != -1)
      {
        string str = id.ToString() + ",nation_id," + (object)this.m_nation_id;
        w.WriteLine(str);
      }
      if (this.m_rule_bookings != null)
      {
        string str = id.ToString() + ",rule_bookings," + this.m_rule_bookings;
        w.WriteLine(str);
      }
      if (this.m_rule_offsides != null)
      {
        string str = id.ToString() + ",rule_offsides," + this.m_rule_offsides;
        w.WriteLine(str);
      }
      if (this.m_rule_injuries != null)
      {
        string str = id.ToString() + ",rule_injuries," + this.m_rule_injuries;
        w.WriteLine(str);
      }
      if (this.m_rule_numsubsbench != -1)
      {
        string str = id.ToString() + ",rule_numsubsbench," + (object)this.m_rule_numsubsbench;
        w.WriteLine(str);
      }
      if (this.m_rule_numsubsmatch != -1)
      {
        string str = id.ToString() + ",rule_numsubsmatch," + (object)this.m_rule_numsubsmatch;
        w.WriteLine(str);
      }
      if (this.m_rule_suspension != -1)
      {
        string str = id.ToString() + ",rule_suspension," + (object)this.m_rule_suspension;
        w.WriteLine(str);
      }
      if (this.m_rule_numyellowstored != -1)
      {
        string str = id.ToString() + ",rule_numyellowstored," + (object)this.m_rule_numyellowstored;
        w.WriteLine(str);
      }
      if (this.m_rule_numgamesbanredmax != -1)
      {
        string str = id.ToString() + ",rule_numgamesbanredmax," + (object)this.m_rule_numgamesbanredmax;
        w.WriteLine(str);
      }
      if (this.m_rule_numgamesbanredmin != -1)
      {
        string str = id.ToString() + ",rule_numgamesbanredmin," + (object)this.m_rule_numgamesbanredmin;
        w.WriteLine(str);
      }
      if (this.m_rule_numgamesbandoubleyellowmax != -1)
      {
        string str = id.ToString() + ",rule_numgamesbandoubleyellowmax," + (object)this.m_rule_numgamesbandoubleyellowmax;
        w.WriteLine(str);
      }
      if (this.m_rule_numgamesbandoubleyellowmin != -1)
      {
        string str = id.ToString() + ",rule_numgamesbandoubleyellowmin," + (object)this.m_rule_numgamesbandoubleyellowmin;
        w.WriteLine(str);
      }
      if (this.m_rule_numgamesbanyellowsmax != -1)
      {
        string str = id.ToString() + ",rule_numgamesbanyellowsmax," + (object)this.m_rule_numgamesbanyellowsmax;
        w.WriteLine(str);
      }
      if (this.m_rule_numgamesbanyellowsmin != -1)
      {
        string str = id.ToString() + ",rule_numgamesbanyellowsmin," + (object)this.m_rule_numgamesbanyellowsmin;
        w.WriteLine(str);
      }
      if (this.m_standings_pointswin != -1)
      {
        string str = id.ToString() + ",standings_pointswin," + (object)this.m_standings_pointswin;
        w.WriteLine(str);
      }
      if (this.m_standings_pointsdraw != -1)
      {
        string str = id.ToString() + ",standings_pointsdraw," + (object)this.m_standings_pointsdraw;
        w.WriteLine(str);
      }
      if (this.m_standings_pointsloss != -1)
      {
        string str = id.ToString() + ",standings_pointsloss," + (object)this.m_standings_pointsloss;
        w.WriteLine(str);
      }
      if (this.m_standings_checkrank != -1)
      {
        string str = id.ToString() + ",standings_checkrank," + (object)this.m_standings_checkrank;
        w.WriteLine(str);
      }
      if (this.m_schedule_seasonstartmonth != null)
      {
        string str = id.ToString() + ",schedule_seasonstartmonth," + this.m_schedule_seasonstartmonth;
        w.WriteLine(str);
      }
      if (this.m_schedule_year_start != -1)
      {
        string str = id.ToString() + ",schedule_year_start," + (object)this.m_schedule_year_start;
        w.WriteLine(str);
      }
      if (this.m_schedule_year_offset != -1)
      {
        string str = id.ToString() + ",schedule_year_offset," + (object)this.m_schedule_year_offset;
        w.WriteLine(str);
      }
      if (this.m_schedule_friendlydaysbetweenmin != -1)
      {
        string str = id.ToString() + ",schedule_friendlydaysbetweenmin," + (object)this.m_schedule_friendlydaysbetweenmin;
        w.WriteLine(str);
      }
      if (this.m_schedule_friendlydaysbefore != -1)
      {
        string str = id.ToString() + ",schedule_friendlydaysbefore," + (object)this.m_schedule_friendlydaysbefore;
        w.WriteLine(str);
      }
      if (this.m_schedule_internationaldependency != -1)
      {
        string str = id.ToString() + ",schedule_internationaldependency," + (object)this.m_schedule_internationaldependency;
        w.WriteLine(str);
      }
      if (this.m_schedule_use_dates_comp != -1)
      {
        int internationalFriendlyId = FifaEnvironment.CompetitionObjects.GetInternationalFriendlyId();
        if (internationalFriendlyId != -1)
        {
          string str = id.ToString() + ",schedule_use_dates_comp," + (object)internationalFriendlyId;
          w.WriteLine(str);
        }
      }
      if (this.m_schedule_checkconflict == 1)
      {
        string str = id.ToString() + ",schedule_checkconflict," + (object)this.m_schedule_checkconflict;
        w.WriteLine(str);
      }
      if (this.TrophyCompdependency != null)
      {
        string str = id.ToString() + ",schedule_compdependency," + (object)this.m_TrophyCompdependency.Id;
        w.WriteLine(str);
      }
      if (this.TrophyForcecomp != null)
      {
        string str = id.ToString() + ",schedule_forcecomp," + (object)this.m_TrophyForcecomp.Id;
        w.WriteLine(str);
      }
      if (this.m_schedule_matchreplay != -1)
      {
        string str = id.ToString() + ",schedule_matchreplay," + (object)this.m_schedule_matchreplay;
        w.WriteLine(str);
      }
      if (this.m_schedule_reversed != -1)
      {
        string str = id.ToString() + ",schedule_reversed," + (object)this.m_schedule_reversed;
        w.WriteLine(str);
      }
      if (this.m_schedule_year_real != -1)
      {
        string str = id.ToString() + ",schedule_year_real," + (object)this.m_schedule_year_real;
        w.WriteLine(str);
      }
      if (this.m_match_matchimportance != -1)
      {
        string str = id.ToString() + ",match_matchimportance," + (object)this.m_match_matchimportance;
        w.WriteLine(str);
      }
      if (this.m_match_stagetype != null)
      {
        if (this.m_match_matchsituation == "LEAGUE")
          return true;
        string str = id.ToString() + ",match_stagetype," + this.m_match_stagetype;
        w.WriteLine(str);
      }
      if (this.m_match_matchsituation != null)
      {
        string str = id.ToString() + ",match_matchsituation," + this.m_match_matchsituation;
        w.WriteLine(str);
      }
      if (this.m_match_endruleleague != null)
      {
        string str = id.ToString() + ",match_endruleleague," + this.m_match_endruleleague;
        w.WriteLine(str);
      }
      this.m_N_endruleko1leg = CompetitionSettings.SetKo1Rule(this.m_EndRuleKo1Leg, ref this.m_match_endruleko1leg);
      for (int index = 0; index < this.m_N_endruleko1leg; ++index)
      {
        string str = id.ToString() + ",match_endruleko1leg," + this.m_match_endruleko1leg[index];
        w.WriteLine(str);
      }
      if (this.m_match_endruleko2leg1 != null)
      {
        string str = id.ToString() + ",match_endruleko2leg1," + this.m_match_endruleko2leg1;
        w.WriteLine(str);
      }
      this.m_N_endruleko2leg2 = CompetitionSettings.SetKo2Rule(this.m_EndRuleKo2Leg2, ref this.m_match_endruleko2leg2);
      for (int index = 0; index < this.m_N_endruleko2leg2; ++index)
      {
        string str = id.ToString() + ",match_endruleko2leg2," + this.m_match_endruleko2leg2[index];
        w.WriteLine(str);
      }
      if (this.m_match_endrulefriendly != null)
      {
        string str = id.ToString() + ",match_endrulefriendly," + this.m_match_endrulefriendly;
        w.WriteLine(str);
      }
      if (this.m_match_celebrationlevel != null)
      {
        string str = id.ToString() + ",match_celebrationlevel," + this.m_match_celebrationlevel;
        w.WriteLine(str);
      }
      if (this.m_match_stadium != null)
      {
        for (int index = 0; index < this.m_match_stadium.Length; ++index)
        {
          if (this.m_match_stadium[index] >= 0)
          {
            string str = id.ToString() + ",match_stadium," + (object)this.m_match_stadium[index];
            w.WriteLine(str);
          }
        }
      }
      if (this.m_info_prize_money != -1)
      {
        string str = id.ToString() + ",info_prize_money," + (object)this.m_info_prize_money;
        w.WriteLine(str);
      }
      if (this.m_info_prize_money_drop != -1)
      {
        string str = id.ToString() + ",info_prize_money_drop," + (object)this.m_info_prize_money_drop;
        w.WriteLine(str);
      }
      this.m_N_standings_sort = CompetitionSettings.SetStandingRule(this.m_StandingsSort, ref this.m_standings_sort);
      for (int index = 0; index < this.m_N_standings_sort; ++index)
      {
        string str = id.ToString() + ",standings_sort," + this.m_standings_sort[index];
        w.WriteLine(str);
      }
      if (this.m_num_games != -1)
      {
        string str = id.ToString() + ",num_games," + (object)this.m_num_games;
        w.WriteLine(str);
      }
      if (this.m_info_color_slot_champ != -1)
      {
        string str = id.ToString() + ",info_color_slot_champ," + (object)this.m_info_color_slot_champ;
        w.WriteLine(str);
      }
      for (int index = 0; index < this.m_N_info_color_slot_champ_cup; ++index)
      {
        string str = id.ToString() + ",info_color_slot_champ_cup," + (object)this.m_info_color_slot_champ_cup[index];
        w.WriteLine(str);
      }
      for (int index = 0; index < this.m_N_info_color_slot_euro_league; ++index)
      {
        string str = id.ToString() + ",info_color_slot_euro_league," + (object)this.m_info_color_slot_euro_league[index];
        w.WriteLine(str);
      }
      for (int index = 0; index < this.m_N_info_color_slot_promo; ++index)
      {
        string str = id.ToString() + ",info_color_slot_promo," + (object)this.m_info_color_slot_promo[index];
        w.WriteLine(str);
      }
      for (int index = 0; index < this.m_N_info_color_slot_promo_poss; ++index)
      {
        string str = id.ToString() + ",info_color_slot_promo_poss," + (object)this.m_info_color_slot_promo_poss[index];
        w.WriteLine(str);
      }
      for (int index = 0; index < this.m_N_info_color_slot_releg; ++index)
      {
        string str = id.ToString() + ",info_color_slot_releg," + (object)this.m_info_color_slot_releg[index];
        w.WriteLine(str);
      }
      for (int index = 0; index < this.m_N_info_color_slot_releg_poss; ++index)
      {
        string str = id.ToString() + ",info_color_slot_releg_poss," + (object)this.m_info_color_slot_releg_poss[index];
        w.WriteLine(str);
      }
      for (int index = 0; index < this.m_N_info_color_slot_adv_group; ++index)
      {
        string str = id.ToString() + ",info_color_slot_adv_group," + (object)this.m_info_color_slot_adv_group[index];
        w.WriteLine(str);
      }
      if (this.m_info_slot_champ != -1)
      {
        string str = id.ToString() + ",info_slot_champ," + (object)this.m_info_slot_champ;
        w.WriteLine(str);
      }
      for (int index = 0; index < this.m_N_info_slot_promo; ++index)
      {
        string str = id.ToString() + ",info_slot_promo," + (object)this.m_info_slot_promo[index];
        w.WriteLine(str);
      }
      for (int index = 0; index < this.m_N_info_slot_promo_poss; ++index)
      {
        string str = id.ToString() + ",info_slot_promo_poss," + (object)this.m_info_slot_promo_poss[index];
        w.WriteLine(str);
      }
      for (int index = 0; index < this.m_N_info_slot_releg; ++index)
      {
        string str = id.ToString() + ",info_slot_releg," + (object)this.m_info_slot_releg[index];
        w.WriteLine(str);
      }
      for (int index = 0; index < this.m_N_info_slot_releg_poss; ++index)
      {
        string str = id.ToString() + ",info_slot_releg_poss," + (object)this.m_info_slot_releg_poss[index];
        w.WriteLine(str);
      }
      if (this.m_info_league_promo != -1)
      {
        string str = id.ToString() + ",info_league_promo," + (object)this.m_info_league_promo;
        w.WriteLine(str);
      }
      if (this.m_info_league_releg != -1)
      {
        string str = id.ToString() + ",info_league_releg," + (object)this.m_info_league_releg;
        w.WriteLine(str);
      }
      for (int index = 0; index < this.m_N_info_special_team_id; ++index)
      {
        if (this.m_info_special_team_id[index] >= 0)
        {
          string str = id.ToString() + ",info_special_team_id," + (object)this.m_info_special_team_id[index];
          w.WriteLine(str);
        }
      }
      if (this.m_advance_pointskeep != -1)
      {
        string str = id.ToString() + ",advance_pointskeep," + (object)this.m_advance_pointskeep;
        w.WriteLine(str);
      }
      if (this.m_advance_pointskeeppercentage != -1)
      {
        string str = id.ToString() + ",advance_pointskeeppercentage," + (object)this.m_advance_pointskeeppercentage;
        w.WriteLine(str);
      }
      if (this.m_advance_matchupkeep != -1)
      {
        string str = id.ToString() + ",advance_matchupkeep," + (object)this.m_advance_matchupkeep;
        w.WriteLine(str);
      }
      if (this.m_advance_standingsrank != -1)
      {
        string str = id.ToString() + ",advance_standingsrank," + (object)this.m_advance_standingsrank;
        w.WriteLine(str);
      }
      if (this.m_advance_random_draw_event != -1)
      {
        string str = id.ToString() + ",advance_random_draw_event," + (object)this.m_advance_random_draw_event;
        w.WriteLine(str);
      }
      if (this.m_match_canusefancards == "on")
      {
        string str = id.ToString() + ",match_canusefancards," + (object)this.m_match_canusefancards;
        w.WriteLine(str);
      }
      if (this.m_advance_randomdraw != -1)
      {
        string str = id.ToString() + ",advance_randomdraw," + (object)this.m_advance_randomdraw;
        w.WriteLine(str);
      }
      if (this.m_advance_maxteamsassoc != -1)
      {
        string str = id.ToString() + ",advance_maxteamsassoc," + (object)this.m_advance_maxteamsassoc;
        w.WriteLine(str);
      }
      if (this.m_advance_maxteamsgroup != -1)
      {
        string str = id.ToString() + ",advance_maxteamsgroup," + (object)this.m_advance_maxteamsgroup;
        w.WriteLine(str);
      }
      if (this.m_advance_maxteamsstageref != -1)
      {
        string str = id.ToString() + ",advance_maxteamsstageref," + (object)this.m_advance_maxteamsstageref;
        w.WriteLine(str);
      }
      if (this.m_advance_calccompavgs != -1)
      {
        string str = id.ToString() + ",advance_calccompavgs," + (object)this.m_advance_calccompavgs;
        w.WriteLine(str);
      }
      if (this.m_advance_standingskeep != -1)
      {
        string str = id.ToString() + ",advance_standingskeep," + (object)this.m_advance_standingskeep;
        w.WriteLine(str);
      }
      if (this.m_advance_standingsagg != -1)
      {
        string str = id.ToString() + ",advance_standingsagg," + (object)this.m_advance_standingsagg;
        w.WriteLine(str);
      }
      if (this.m_advance_jleagueignorecheck != -1)
      {
        string str = id.ToString() + ",advance_jleague_ignore_check," + (object)this.m_advance_jleagueignorecheck;
        w.WriteLine(str);
      }
      if (this.m_advance_jleagueqtrsetup != -1)
      {
        string str = id.ToString() + ",advance_jleague_qtr_setup," + (object)this.m_advance_jleagueqtrsetup;
        w.WriteLine(str);
      }
      if (this.m_advance_teamcompdependency != -1)
      {
        string str = id.ToString() + ",advance_teamcompdependency," + (object)this.m_advance_teamcompdependency;
        w.WriteLine(str);
      }
      return true;
    }

    public static int GetStandingRule(string[] rules)
    {
      if (rules == null)
        return -1;
      if (rules[0] == "POINTS")
      {
        if (rules[1] == "GOALDIFF")
          return rules[3] == "H2HPOINTS" ? 5 : 0;
        if (rules[1] == "WINS")
          return 1;
        return rules[1] == "H2HPOINTS" ? 2 : 0;
      }
      if (rules[0] == "TEAMRATING")
        return 3;
      return rules[0] == "PREVRANK" ? 4 : 0;
    }

    public static int SetStandingRule(int rulesId, ref string[] rules)
    {
      switch (rulesId)
      {
        case -1:
          return 0;
        case 1:
          rules[0] = "POINTS";
          rules[1] = "WINS";
          rules[2] = "GOALDIFF";
          rules[3] = "GOALSFOR";
          return 4;
        case 2:
          rules[0] = "POINTS";
          rules[1] = "H2HPOINTS";
          rules[3] = "H2HGOALDIFF";
          rules[3] = "H2HGOALSFOR";
          rules[4] = "GOALDIFF";
          rules[5] = "GOALSFOR";
          return 6;
        case 3:
          rules[0] = "TEAMRATING";
          return 1;
        case 4:
          rules[0] = "PREVRANK";
          return 1;
        case 5:
          rules[0] = "POINTS";
          rules[1] = "GOALDIFF";
          rules[2] = "GOALSFOR";
          rules[3] = "H2HPOINTS";
          return 4;
        default:
          rules[0] = "POINTS";
          rules[1] = "GOALDIFF";
          rules[2] = "GOALSFOR";
          rules[3] = "WINS";
          return 4;
      }
    }

    public static int GetKo1Rule(string[] rules)
    {
      if (rules == null)
        return -1;
      if (rules[0] == "ET")
      {
        if (rules[1] == "PENS")
          return 0;
      }
      else
      {
        if (rules[0] == "PENS")
          return 1;
        if (rules[0] == "END")
          return 2;
      }
      return -1;
    }

    public static int SetKo1Rule(int rulesId, ref string[] rules)
    {
      switch (rulesId)
      {
        case -1:
          return 0;
        case 1:
          rules[0] = "PENS";
          return 1;
        case 2:
          rules[0] = "END";
          return 1;
        default:
          rules[0] = "ET";
          rules[1] = "PENS";
          return 2;
      }
    }

    public static int GetKo2Rule(string[] rules)
    {
      if (rules == null || !(rules[0] == "AGG"))
        return -1;
      if (rules[1] == "AWAY")
        return 0;
      if (rules[1] == "ET")
        return 1;
      return rules[1] == "PENS" ? 2 : 3;
    }

    public static int SetKo2Rule(int rulesId, ref string[] rules)
    {
      switch (rulesId)
      {
        case -1:
          return 0;
        case 1:
          rules[0] = "AGG";
          rules[1] = "ET";
          rules[2] = "PENS";
          return 3;
        case 2:
          rules[0] = "AGG";
          rules[1] = "PENS";
          return 2;
        case 3:
          rules[0] = "AGG";
          return 1;
        default:
          rules[0] = "AGG";
          rules[1] = "AWAY";
          rules[2] = "ET";
          rules[3] = "ET_AWAY";
          rules[4] = "PENS";
          return 5;
      }
    }

    public void UnsetProperty(string property)
    {
      int num = this.IsMultipleProperty(property);
      if (num <= 1)
      {
        this.UnsetProperty(property, 0);
      }
      else
      {
        for (int index = 0; index < num; ++index)
          this.UnsetProperty(property, index);
      }
    }

    private void UnsetProperty(string property, int index)
    {
      if (this.IsStringProperty(property))
        this.SetProperty(property, index, (string)null);
      else
        this.SetProperty(property, index, "-1");
    }
  }
}
