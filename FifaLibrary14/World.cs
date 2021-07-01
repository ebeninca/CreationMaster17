// Original code created by Rinaldo

using System.IO;

namespace FifaLibrary
{
  public class World : Compobj
  {
    private int[] m_DryProb = new int[12];
    private int[] m_RainProb = new int[12];
    private int[] m_SnowProb = new int[12];
    private int[] m_OvercastProb = new int[12];
    private int[] m_SunsetTime = new int[12];
    private int[] m_DarkTime = new int[12];

    public World(int id, string typeString, string description)
      : base(id, 0, typeString, description, (Compobj) null)
    {
      this.m_Confederations = new ConfederationList();
      this.m_Trophies = new TrophyList();
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
  }
}
