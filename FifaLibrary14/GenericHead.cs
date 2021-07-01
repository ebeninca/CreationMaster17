// Original code created by Rinaldo

using System;
using System.Drawing;

namespace FifaLibrary
{
  public static class GenericHead
  {
    public static int[] c_LowHair = new int[112]
    {
      0,
      1,
      9,
      2,
      3,
      6,
      4,
      4,
      8,
      8,
      13,
      7,
      8,
      13,
      5,
      8,
      9,
      9,
      10,
      9,
      5,
      9,
      9,
      9,
      9,
      1,
      0,
      10,
      1,
      9,
      9,
      9,
      13,
      6,
      13,
      14,
      12,
      1,
      9,
      9,
      1,
      1,
      10,
      1,
      8,
      9,
      1,
      9,
      4,
      5,
      16,
      2,
      2,
      4,
      9,
      12,
      12,
      9,
      9,
      14,
      11,
      10,
      14,
      10,
      10,
      1,
      14,
      14,
      13,
      14,
      11,
      1,
      1,
      13,
      9,
      9,
      3,
      9,
      9,
      5,
      6,
      13,
      9,
      9,
      3,
      14,
      9,
      13,
      11,
      14,
      9,
      8,
      9,
      9,
      11,
      14,
      2,
      9,
      14,
      8,
      9,
      9,
      9,
      8,
      14,
      9,
      9,
      9,
      12,
      7,
      1,
      9
    };
    public static Color[] c_FacialHairColorPalette = new Color[7]
    {
      Color.FromArgb(48, 36, 32),
      Color.FromArgb(160, 140, 112),
      Color.FromArgb(72, 52, 40),
      Color.FromArgb(184, 161, 130),
      Color.FromArgb(144, 108, 80),
      Color.FromArgb(112, 96, 72),
      Color.FromArgb(136, 84, 56)
    };
    public static int[] c_CaucasicModels = new int[66]
    {
      0,
      1,
      2,
      3,
      4,
      5,
      6,
      7,
      8,
      9,
      10,
      11,
      12,
      13,
      14,
      15,
      16,
      17,
      18,
      19,
      20,
      21,
      22,
      23,
      24,
      25,
      2000,
      2001,
      2002,
      2003,
      2004,
      2005,
      2006,
      2007,
      2008,
      2009,
      2010,
      2011,
      2012,
      2013,
      2014,
      2015,
      2016,
      2017,
      2019,
      2020,
      2021,
      2022,
      2023,
      2024,
      2025,
      2026,
      2027,
      2028,
      2029,
      2030,
      3500,
      3501,
      3502,
      3503,
      3504,
      3505,
      4000,
      4001,
      4002,
      4003
    };
    public static int[] c_AsiaticModels = new int[33]
    {
      500,
      501,
      502,
      503,
      504,
      505,
      506,
      507,
      508,
      509,
      510,
      511,
      512,
      513,
      514,
      515,
      516,
      517,
      518,
      519,
      520,
      521,
      522,
      523,
      524,
      525,
      526,
      527,
      528,
      529,
      530,
      531,
      532
    };
    public static int[] c_AfricanModels = new int[42]
    {
      1000,
      1001,
      1002,
      1003,
      1004,
      1005,
      1006,
      1007,
      1008,
      1009,
      1010,
      1011,
      1012,
      1013,
      1014,
      1015,
      1016,
      1017,
      1018,
      1019,
      1020,
      1021,
      1022,
      1023,
      1024,
      1025,
      1026,
      1027,
      3000,
      3001,
      3002,
      3003,
      3004,
      3005,
      4500,
      4501,
      4502,
      4525,
      5000,
      5001,
      5002,
      5003
    };
    public static int[] c_LatinModels = new int[48]
    {
      1500,
      1501,
      1502,
      1503,
      1504,
      1505,
      1506,
      1507,
      1508,
      1509,
      1510,
      1511,
      1512,
      1513,
      1514,
      1515,
      1516,
      1517,
      1518,
      1519,
      1520,
      1521,
      1522,
      1523,
      1524,
      1525,
      1526,
      1527,
      1528,
      2500,
      2501,
      2502,
      2503,
      2504,
      2505,
      2506,
      2507,
      2508,
      2509,
      2510,
      2511,
      2512,
      2513,
      2514,
      2515,
      2516,
      2517,
      2518
    };
    public static int[] c_ShavenModels = new int[7]
    {
      0,
      25,
      1,
      43,
      41,
      46,
      120
    };
    public static int[] c_VeryShortModels = new int[15]
    {
      26,
      29,
      47,
      72,
      92,
      16,
      28,
      31,
      37,
      40,
      45,
      65,
      77,
      90,
      117
    };
    public static int[] c_ShortModels = new int[28]
    {
      2,
      21,
      22,
      30,
      38,
      54,
      57,
      70,
      75,
      78,
      82,
      97,
      101,
      102,
      104,
      105,
      106,
      107,
      108,
      111,
      112,
      113,
      115,
      114,
      118,
      121,
      122,
      124
    };
    public static int[] c_ModernModels = new int[14]
    {
      17,
      18,
      19,
      24,
      39,
      60,
      61,
      63,
      64,
      86,
      88,
      89,
      94,
      123
    };
    public static int[] c_MediumModels = new int[30]
    {
      36,
      74,
      13,
      35,
      42,
      59,
      69,
      73,
      85,
      93,
      32,
      66,
      67,
      68,
      14,
      20,
      23,
      58,
      62,
      83,
      95,
      22,
      52,
      87,
      98,
      99,
      100,
      103,
      116,
      119
    };
    public static int[] c_LongModels = new int[15]
    {
      8,
      9,
      15,
      44,
      84,
      34,
      10,
      33,
      12,
      80,
      11,
      51,
      79,
      53,
      7
    };
    public static int[] c_AfroModels = new int[9]
    {
      71,
      4,
      27,
      5,
      6,
      96,
      3,
      109,
      110
    };
    public static int[] c_HeadbendModels = new int[7]
    {
      55,
      56,
      76,
      81,
      49,
      91,
      48
    };
    private static Random m_Randomizer = new Random();

    public static int GetModelId(GenericHead.EHeadModelSet modelSet, int index)
    {
      switch (modelSet)
      {
        case GenericHead.EHeadModelSet.African:
          if (index < GenericHead.c_AfricanModels.Length)
            return GenericHead.c_AfricanModels[index];
          break;
        case GenericHead.EHeadModelSet.Asiatic:
          if (index < GenericHead.c_AsiaticModels.Length)
            return GenericHead.c_AsiaticModels[index];
          break;
        case GenericHead.EHeadModelSet.Caucasic:
          if (index < GenericHead.c_CaucasicModels.Length)
            return GenericHead.c_CaucasicModels[index];
          break;
        case GenericHead.EHeadModelSet.Latin:
          if (index < GenericHead.c_LatinModels.Length)
            return GenericHead.c_LatinModels[index];
          break;
      }
      return -1;
    }

    public static GenericHead.EHeadModelSet GetModelSet(int modelId)
    {
      for (int index = 0; index < GenericHead.c_CaucasicModels.Length; ++index)
      {
        if (modelId == GenericHead.c_CaucasicModels[index])
          return GenericHead.EHeadModelSet.Caucasic;
      }
      for (int index = 0; index < GenericHead.c_LatinModels.Length; ++index)
      {
        if (modelId == GenericHead.c_LatinModels[index])
          return GenericHead.EHeadModelSet.Latin;
      }
      for (int index = 0; index < GenericHead.c_AfricanModels.Length; ++index)
      {
        if (modelId == GenericHead.c_AfricanModels[index])
          return GenericHead.EHeadModelSet.African;
      }
      for (int index = 0; index < GenericHead.c_AsiaticModels.Length; ++index)
      {
        if (modelId == GenericHead.c_AsiaticModels[index])
          return GenericHead.EHeadModelSet.Asiatic;
      }
      return GenericHead.EHeadModelSet.Unknown;
    }

    public static int GetModelSetIndex(GenericHead.EHeadModelSet modelSet, int modelId)
    {
      switch (modelSet)
      {
        case GenericHead.EHeadModelSet.African:
          for (int index = 0; index < GenericHead.c_AfricanModels.Length; ++index)
          {
            if (modelId == GenericHead.c_AfricanModels[index])
              return index;
          }
          break;
        case GenericHead.EHeadModelSet.Asiatic:
          for (int index = 0; index < GenericHead.c_AsiaticModels.Length; ++index)
          {
            if (modelId == GenericHead.c_AsiaticModels[index])
              return index;
          }
          break;
        case GenericHead.EHeadModelSet.Caucasic:
          for (int index = 0; index < GenericHead.c_CaucasicModels.Length; ++index)
          {
            if (modelId == GenericHead.c_CaucasicModels[index])
              return index;
          }
          break;
        case GenericHead.EHeadModelSet.Latin:
          for (int index = 0; index < GenericHead.c_LatinModels.Length; ++index)
          {
            if (modelId == GenericHead.c_LatinModels[index])
              return index;
          }
          break;
      }
      return -1;
    }

    public static int GetHairModelId(GenericHead.EHairModelSet modelSet, int index)
    {
      switch (modelSet)
      {
        case GenericHead.EHairModelSet.Shaven:
          if (index < GenericHead.c_ShavenModels.Length)
            return GenericHead.c_ShavenModels[index];
          break;
        case GenericHead.EHairModelSet.VeryShort:
          if (index < GenericHead.c_VeryShortModels.Length)
            return GenericHead.c_VeryShortModels[index];
          break;
        case GenericHead.EHairModelSet.Short:
          if (index < GenericHead.c_ShortModels.Length)
            return GenericHead.c_ShortModels[index];
          break;
        case GenericHead.EHairModelSet.Modern:
          if (index < GenericHead.c_ModernModels.Length)
            return GenericHead.c_ModernModels[index];
          break;
        case GenericHead.EHairModelSet.Medium:
          if (index < GenericHead.c_MediumModels.Length)
            return GenericHead.c_MediumModels[index];
          break;
        case GenericHead.EHairModelSet.Long:
          if (index < GenericHead.c_LongModels.Length)
            return GenericHead.c_LongModels[index];
          break;
        case GenericHead.EHairModelSet.Afro:
          if (index < GenericHead.c_AfroModels.Length)
            return GenericHead.c_AfroModels[index];
          break;
        case GenericHead.EHairModelSet.Headbend:
          if (index < GenericHead.c_HeadbendModels.Length)
            return GenericHead.c_HeadbendModels[index];
          break;
      }
      return -1;
    }

    public static GenericHead.EHairModelSet GetHairModelSet(int modelId)
    {
      for (int index = 0; index < GenericHead.c_ShavenModels.Length; ++index)
      {
        if (modelId == GenericHead.c_ShavenModels[index])
          return GenericHead.EHairModelSet.Shaven;
      }
      for (int index = 0; index < GenericHead.c_VeryShortModels.Length; ++index)
      {
        if (modelId == GenericHead.c_VeryShortModels[index])
          return GenericHead.EHairModelSet.VeryShort;
      }
      for (int index = 0; index < GenericHead.c_ShortModels.Length; ++index)
      {
        if (modelId == GenericHead.c_ShortModels[index])
          return GenericHead.EHairModelSet.Short;
      }
      for (int index = 0; index < GenericHead.c_ModernModels.Length; ++index)
      {
        if (modelId == GenericHead.c_ModernModels[index])
          return GenericHead.EHairModelSet.Modern;
      }
      for (int index = 0; index < GenericHead.c_MediumModels.Length; ++index)
      {
        if (modelId == GenericHead.c_MediumModels[index])
          return GenericHead.EHairModelSet.Medium;
      }
      for (int index = 0; index < GenericHead.c_LongModels.Length; ++index)
      {
        if (modelId == GenericHead.c_LongModels[index])
          return GenericHead.EHairModelSet.Long;
      }
      for (int index = 0; index < GenericHead.c_AfroModels.Length; ++index)
      {
        if (modelId == GenericHead.c_AfroModels[index])
          return GenericHead.EHairModelSet.Afro;
      }
      for (int index = 0; index < GenericHead.c_HeadbendModels.Length; ++index)
      {
        if (modelId == GenericHead.c_HeadbendModels[index])
          return GenericHead.EHairModelSet.Headbend;
      }
      return GenericHead.EHairModelSet.Shaven;
    }

    public static int GetHairModelSetIndex(GenericHead.EHairModelSet modelSet, int modelId)
    {
      switch (modelSet)
      {
        case GenericHead.EHairModelSet.Shaven:
          for (int index = 0; index < GenericHead.c_ShavenModels.Length; ++index)
          {
            if (modelId == GenericHead.c_ShavenModels[index])
              return index;
          }
          break;
        case GenericHead.EHairModelSet.VeryShort:
          for (int index = 0; index < GenericHead.c_VeryShortModels.Length; ++index)
          {
            if (modelId == GenericHead.c_VeryShortModels[index])
              return index;
          }
          break;
        case GenericHead.EHairModelSet.Short:
          for (int index = 0; index < GenericHead.c_ShortModels.Length; ++index)
          {
            if (modelId == GenericHead.c_ShortModels[index])
              return index;
          }
          break;
        case GenericHead.EHairModelSet.Modern:
          for (int index = 0; index < GenericHead.c_ModernModels.Length; ++index)
          {
            if (modelId == GenericHead.c_ModernModels[index])
              return index;
          }
          break;
        case GenericHead.EHairModelSet.Medium:
          for (int index = 0; index < GenericHead.c_MediumModels.Length; ++index)
          {
            if (modelId == GenericHead.c_MediumModels[index])
              return index;
          }
          break;
        case GenericHead.EHairModelSet.Long:
          for (int index = 0; index < GenericHead.c_LongModels.Length; ++index)
          {
            if (modelId == GenericHead.c_LongModels[index])
              return index;
          }
          break;
        case GenericHead.EHairModelSet.Afro:
          for (int index = 0; index < GenericHead.c_AfroModels.Length; ++index)
          {
            if (modelId == GenericHead.c_AfroModels[index])
              return index;
          }
          break;
        case GenericHead.EHairModelSet.Headbend:
          for (int index = 0; index < GenericHead.c_HeadbendModels.Length; ++index)
          {
            if (modelId == GenericHead.c_HeadbendModels[index])
              return index;
          }
          break;
      }
      return -1;
    }

    public static int RandomizeModel(GenericHead.EHeadModelSet modelSet)
    {
      switch (modelSet)
      {
        case GenericHead.EHeadModelSet.African:
          return GenericHead.c_AfricanModels[GenericHead.m_Randomizer.Next(GenericHead.c_AfricanModels.Length)];
        case GenericHead.EHeadModelSet.Asiatic:
          return GenericHead.c_AsiaticModels[GenericHead.m_Randomizer.Next(GenericHead.c_AsiaticModels.Length)];
        case GenericHead.EHeadModelSet.Caucasic:
          return GenericHead.c_CaucasicModels[GenericHead.m_Randomizer.Next(GenericHead.c_CaucasicModels.Length)];
        case GenericHead.EHeadModelSet.Latin:
          return GenericHead.c_LatinModels[GenericHead.m_Randomizer.Next(GenericHead.c_LatinModels.Length)];
        default:
          return 1;
      }
    }

    public enum EHeadModelSet
    {
      Unknown,
      African,
      Asiatic,
      Caucasic,
      Latin,
    }

    public enum EHairModelSet
    {
      Shaven,
      VeryShort,
      Short,
      Modern,
      Medium,
      Long,
      Afro,
      Headbend,
    }
  }
}
