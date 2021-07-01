﻿// Original code created by Rinaldo

using System.IO;

namespace FifaLibrary
{
  public class Nation : Compobj
  {
    private int[] m_DryProb = new int[12];
    private int[] m_RainProb = new int[12];
    private int[] m_SnowProb = new int[12];
    private int[] m_OvercastProb = new int[12];
    private int[] m_SunsetTime = new int[12];
    private int[] m_DarkTime = new int[12];
    private Country m_Country;

    public Country Country
    {
      get
      {
        return this.m_Country;
      }
      set
      {
        this.m_Country = value;
        this.Settings.m_nation_id = this.m_Country != null ? this.m_Country.Id : -1;
      }
    }

    public override void LinkCountry(CountryList countryList)
    {
      if (countryList == null)
        return;
      this.m_Country = (Country) countryList.SearchId(this.Settings.m_nation_id);
    }

    public int[] DryProb
    {
      get
      {
        return this.m_DryProb;
      }
      set
      {
        this.m_DryProb = value;
      }
    }

    public int[] RainProb
    {
      get
      {
        return this.m_RainProb;
      }
      set
      {
        this.m_RainProb = value;
      }
    }

    public int[] SnowProb
    {
      get
      {
        return this.m_SnowProb;
      }
      set
      {
        this.m_SnowProb = value;
      }
    }

    public int[] OvercastProb
    {
      get
      {
        return this.m_OvercastProb;
      }
      set
      {
        this.m_OvercastProb = value;
      }
    }

    public int[] SunsetTime
    {
      get
      {
        return this.m_SunsetTime;
      }
      set
      {
        this.m_SunsetTime = value;
      }
    }

    public int[] DarkTime
    {
      get
      {
        return this.m_DarkTime;
      }
      set
      {
        this.m_DarkTime = value;
      }
    }

    public Confederation Confederation
    {
      get
      {
        return this.ParentObj.TypeNumber == 1 ? (Confederation) this.ParentObj : (Confederation) null;
      }
    }

    public Nation(int id, string typeString, string description, Compobj parentObj)
      : base(id, 2, typeString, description, parentObj)
    {
      this.m_Trophies = new TrophyList();
    }

    public override bool SaveToWeather(StreamWriter w)
    {
      if (w == null)
        return false;
      for (int index = 0; index < 12; ++index)
      {
        if (this.m_DryProb[index] + this.m_RainProb[index] + this.m_SnowProb[index] == 100)
        {
          string str = this.Id.ToString() + "," + (index + 1).ToString() + "," + this.m_DryProb[index].ToString() + "," + this.m_RainProb[index].ToString() + "," + this.m_SnowProb[index].ToString() + "," + this.m_OvercastProb[index].ToString() + "," + this.m_SunsetTime[index].ToString() + "," + this.m_DarkTime[index].ToString();
          w.WriteLine(str);
        }
      }
      return true;
    }

    public bool RemoveTrophy()
    {
      if (this.m_Trophies.Count < 1)
        return false;
      Trophy trophy = (Trophy) this.m_Trophies[this.m_Trophies.Count - 1];
      this.m_Trophies.Remove((object) trophy);
      FifaEnvironment.CompetitionObjects.Remove((object) trophy);
      trophy.RemoveAllStages();
      return true;
    }

    public bool RemoveAllTrophies()
    {
      int count = this.m_Trophies.Count;
      for (int index = 0; index < count; ++index)
        this.RemoveTrophy();
      return true;
    }

    public override void Normalize()
    {
    }
  }
}
