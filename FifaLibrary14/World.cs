// Original code created by Rinaldo

using System.IO;

namespace FifaLibrary
{
  public class World : Compobj
  {
    private int[] m_ClearProb = new int[12];
    private int[] m_HazyProb = new int[12];
    private int[] m_CloudyProb = new int[12];
    private int[] m_OvercastProb = new int[12];
    private int[] m_FoggyProb = new int[12];
    private int[] m_RainProb = new int[12];
    private int[] m_ShowersProb = new int[12];
    private int[] m_FlurriesProb = new int[12];
    private int[] m_SnowProb = new int[12];
    private int[] m_SunsetTime = new int[12];
    private int[] m_DarkTime = new int[12];

    public World(int id, string typeString, string description)
      : base(id, 0, typeString, description, (Compobj)null)
    {
      this.m_Confederations = new ConfederationList();
      this.m_Trophies = new TrophyList();
    }

    public int[] ClearProb
    {
      get
      {
        return this.m_ClearProb;
      }
      set
      {
        this.m_ClearProb = value;
      }
    }

    public int[] HazyProb
    {
      get
      {
        return this.m_HazyProb;
      }
      set
      {
        this.m_HazyProb = value;
      }
    }

    public int[] CloudyProb
    {
      get
      {
        return this.m_CloudyProb;
      }
      set
      {
        this.m_CloudyProb = value;
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

    public int[] FoggyProb
    {
      get
      {
        return this.m_FoggyProb;
      }
      set
      {
        this.m_FoggyProb = value;
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

    public int[] ShowersProb
    {
      get
      {
        return this.m_ShowersProb;
      }
      set
      {
        this.m_ShowersProb = value;
      }
    }

    public int[] FlurriesProb
    {
      get
      {
        return this.m_FlurriesProb;
      }
      set
      {
        this.m_FlurriesProb = value;
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

    public override bool SaveToWeather(StreamWriter w)
    {
      if (w == null)
        return false;
      for (int index = 0; index < 12; ++index)
      {
        if (this.m_ClearProb[index] + this.m_HazyProb[index] + this.m_CloudyProb[index] + this.m_OvercastProb[index] + this.m_FoggyProb[index] + this.m_RainProb[index] + this.m_ShowersProb[index] + this.m_FlurriesProb[index] + this.m_SnowProb[index] == 100)
        {
          string str = this.Id.ToString() + "," + (index + 1).ToString() + "," + this.m_ClearProb[index].ToString() + "," + this.m_HazyProb[index].ToString() + "," + this.m_CloudyProb[index].ToString() + "," + this.m_OvercastProb[index].ToString() + "," + this.m_FoggyProb[index].ToString() + "," + this.m_RainProb[index].ToString() + "," + this.m_ShowersProb[index].ToString() + "," + this.m_FlurriesProb[index].ToString() + "," + this.m_SnowProb[index].ToString() + "," + this.m_SunsetTime[index].ToString() + "," + this.m_DarkTime[index].ToString();
          w.WriteLine(str);
        }
      }
      return true;
    }
  }
}
