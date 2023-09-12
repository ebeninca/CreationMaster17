// Original code created by Rinaldo

using System;
using System.Collections;
using System.IO;

namespace FifaLibrary
{
  public class CompobjList : IdArrayList
  {
    private static string[] s_FileNames = new string[10];
    public static ArrayList s_Descriptions = new ArrayList();

    public CompobjList()
      : base(typeof(Compobj))
    {
      this.MinId = 0;
      this.MaxId = 99999;
    }

    public CompobjList(string path, DbFile dbFile)
      : base(typeof(Compobj))
    {
      this.MinId = 0;
      this.MaxId = 99999;
      this.Load(path, dbFile);
    }

    public static string[] GetFileNames()
    {
      CompobjList.s_FileNames[0] = "dlc/dlc_footballcompeng/dlc/footballcompeng/data/compdata/compobj.txt";
      CompobjList.s_FileNames[1] = "dlc/dlc_footballcompeng/dlc/footballcompeng/data/compdata/settings.txt";
      CompobjList.s_FileNames[2] = "dlc/dlc_footballcompeng/dlc/footballcompeng/data/compdata/standings.txt";
      CompobjList.s_FileNames[3] = "dlc/dlc_footballcompeng/dlc/footballcompeng/data/compdata/advancement.txt";
      CompobjList.s_FileNames[4] = "dlc/dlc_footballcompeng/dlc/footballcompeng/data/compdata/schedule.txt";
      CompobjList.s_FileNames[5] = "dlc/dlc_footballcompeng/dlc/footballcompeng/data/compdata/weather.txt";
      CompobjList.s_FileNames[6] = "dlc/dlc_footballcompeng/dlc/footballcompeng/data/compdata/tasks.txt";
      CompobjList.s_FileNames[7] = "dlc/dlc_footballcompeng/dlc/footballcompeng/data/compdata/initteams.txt";
      CompobjList.s_FileNames[8] = "dlc/dlc_footballcompeng/dlc/footballcompeng/data/compdata/compids.txt";
      CompobjList.s_FileNames[9] = "dlc/dlc_footballcompeng/dlc/footballcompeng/data/internationals.txt";
      return CompobjList.s_FileNames;
    }

    public TrophyList Trophies
    {
      get
      {
        TrophyList trophyList = new TrophyList();
        foreach (Compobj compobj in (ArrayList)this)
        {
          if (compobj.IsTrophy())
            trophyList.Add((object)compobj);
        }
        return trophyList;
      }
    }

    public void Load(string path, DbFile fifaDbFile)
    {
      this.Clear();
      if (!File.Exists(path + CompobjList.s_FileNames[0]))
      {
        FifaEnvironment.FifaFat.RestoreFile(CompobjList.s_FileNames[0]);
        FifaEnvironment.FifaFat.ExtractFile(CompobjList.s_FileNames[0]);
      }
      if (File.Exists(path + CompobjList.s_FileNames[0]))
        this.LoadFromCompobj(path + CompobjList.s_FileNames[0]);
      if (!File.Exists(path + CompobjList.s_FileNames[1]))
      {
        FifaEnvironment.FifaFat.RestoreFile(CompobjList.s_FileNames[1]);
        FifaEnvironment.FifaFat.ExtractFile(CompobjList.s_FileNames[1]);
      }
      if (File.Exists(path + CompobjList.s_FileNames[1]))
        this.LoadFromSettings(path + CompobjList.s_FileNames[1]);
      if (!File.Exists(path + CompobjList.s_FileNames[2]))
      {
        FifaEnvironment.FifaFat.RestoreFile(CompobjList.s_FileNames[2]);
        FifaEnvironment.FifaFat.ExtractFile(CompobjList.s_FileNames[2]);
      }
      if (File.Exists(path + CompobjList.s_FileNames[2]))
        this.LoadFromStandings(path + CompobjList.s_FileNames[2]);
      if (!File.Exists(path + CompobjList.s_FileNames[3]))
      {
        FifaEnvironment.FifaFat.RestoreFile(CompobjList.s_FileNames[3]);
        FifaEnvironment.FifaFat.ExtractFile(CompobjList.s_FileNames[3]);
      }
      if (File.Exists(path + CompobjList.s_FileNames[3]))
        this.LoadFromAdvancement(path + CompobjList.s_FileNames[3]);
      if (!File.Exists(path + CompobjList.s_FileNames[4]))
      {
        FifaEnvironment.FifaFat.RestoreFile(CompobjList.s_FileNames[4]);
        FifaEnvironment.FifaFat.ExtractFile(CompobjList.s_FileNames[4]);
      }
      if (File.Exists(path + CompobjList.s_FileNames[4]))
        this.LoadFromSchedule(path + CompobjList.s_FileNames[4]);
      if (!File.Exists(path + CompobjList.s_FileNames[5]))
      {
        FifaEnvironment.FifaFat.RestoreFile(CompobjList.s_FileNames[5]);
        FifaEnvironment.FifaFat.ExtractFile(CompobjList.s_FileNames[5]);
      }
      if (File.Exists(path + CompobjList.s_FileNames[5]))
        this.LoadFromWeather(path + CompobjList.s_FileNames[5]);
      if (!File.Exists(path + CompobjList.s_FileNames[6]))
      {
        FifaEnvironment.FifaFat.RestoreFile(CompobjList.s_FileNames[6]);
        FifaEnvironment.FifaFat.ExtractFile(CompobjList.s_FileNames[6]);
      }
      if (File.Exists(path + CompobjList.s_FileNames[6]))
        this.LoadFromTasks(path + CompobjList.s_FileNames[6]);
      if (!File.Exists(path + CompobjList.s_FileNames[7]))
      {
        FifaEnvironment.FifaFat.RestoreFile(CompobjList.s_FileNames[7]);
        FifaEnvironment.FifaFat.ExtractFile(CompobjList.s_FileNames[7]);
      }
      if (File.Exists(path + CompobjList.s_FileNames[7]))
        this.LoadFromInitteams(path + CompobjList.s_FileNames[7]);
      if (!File.Exists(path + CompobjList.s_FileNames[9]))
      {
        FifaEnvironment.FifaFat.RestoreFile(CompobjList.s_FileNames[9]);
        FifaEnvironment.FifaFat.ExtractFile(CompobjList.s_FileNames[9]);
      }
      if (File.Exists(path + CompobjList.s_FileNames[9]))
        this.LoadFromInternationals(path + CompobjList.s_FileNames[9]);
      this.FillFromLanguage();
      this.FillFromCompetition(fifaDbFile.Table[TI.competition]);
      this.Normalize();
      this.CollectDescriptions();
    }

    private bool LoadFromCompobj(string fileName)
    {
      if (!File.Exists(fileName))
        return false;
      StreamReader streamReader = new StreamReader(fileName);
      if (streamReader == null)
        return false;
      char[] chArray = new char[1] { ',' };
      string str;
      while ((str = streamReader.ReadLine()) != null)
      {
        string[] strArray = str.Split(chArray);
        if (strArray.Length == 5)
        {
          int int32_1 = Convert.ToInt32(strArray[0]);
          int int32_2 = Convert.ToInt32(strArray[1]);
          string typeString = strArray[2];
          string description = strArray[3];
          int int32_3 = Convert.ToInt32(strArray[4]);
          Compobj parentObj = (Compobj)null;
          if (int32_3 >= 0)
          {
            parentObj = (Compobj)this.SearchId(int32_3);
            if (parentObj == null)
              continue;
          }
          Compobj childObject = (Compobj)null;
          switch (int32_2)
          {
            case 0:
              this.InsertId((IdObject)new World(int32_1, typeString, description));
              break;
            case 1:
              childObject = (Compobj)new Confederation(int32_1, typeString, description, parentObj);
              this.InsertId((IdObject)childObject);
              break;
            case 2:
              childObject = (Compobj)new Nation(int32_1, typeString, description, parentObj);
              this.InsertId((IdObject)childObject);
              break;
            case 3:
              childObject = (Compobj)new Trophy(int32_1, typeString, description, parentObj);
              this.InsertId((IdObject)childObject);
              break;
            case 4:
              childObject = (Compobj)new Stage(int32_1, typeString, description, parentObj);
              this.InsertId((IdObject)childObject);
              break;
            case 5:
              childObject = (Compobj)new Group(int32_1, typeString, description, parentObj);
              this.InsertId((IdObject)childObject);
              break;
          }
          parentObj?.AddChild(childObject);
        }
      }
      streamReader.Close();
      return true;
    }

    private bool LoadFromSettings(string fileName)
    {
      StreamReader streamReader = new StreamReader(fileName);
      if (streamReader == null)
        return false;
      char[] chArray = new char[1];
      char[] charArray = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
      chArray[0] = ',';
      string str1;
      while ((str1 = streamReader.ReadLine()) != null)
      {
        string[] strArray = str1.Split(chArray);
        if (strArray.Length == 3)
        {
          int int32 = Convert.ToInt32(strArray[0]);
          string str2 = strArray[1];
          strArray[2].IndexOfAny(charArray);
          ((Compobj)this.SearchId(int32))?.SetProperty(strArray[1], strArray[2]);
        }
      }
      streamReader.Close();
      return true;
    }

    private bool LoadFromStandings(string fileName)
    {
      StreamReader streamReader = new StreamReader(fileName);
      if (streamReader == null)
        return false;
      char[] chArray = new char[1] { ',' };
      string str;
      while ((str = streamReader.ReadLine()) != null)
      {
        string[] strArray = str.Split(chArray);
        if (strArray.Length == 2)
        {
          int int32_1 = Convert.ToInt32(strArray[0]);
          int int32_2 = Convert.ToInt32(strArray[1]);
          Compobj compobj = (Compobj)this.SearchId(int32_1);
          if (compobj.IsGroup())
          {
            Group group = (Group)compobj;
            if (group != null)
            {
              Rank rank = new Rank(group, int32_2 + 1);
              group.Ranks.Add((object)rank);
            }
          }
        }
      }
      streamReader.Close();
      return true;
    }

    private bool LoadFromSchedule(string fileName)
    {
      StreamReader streamReader = new StreamReader(fileName);
      if (streamReader == null)
        return false;
      char[] chArray = new char[1] { ',' };
      string str;
      while ((str = streamReader.ReadLine()) != null)
      {
        string[] strArray = str.Split(chArray);
        if (strArray.Length == 6)
        {
          int int32_1 = Convert.ToInt32(strArray[0]);
          int int32_2 = Convert.ToInt32(strArray[1]);
          int int32_3 = Convert.ToInt32(strArray[2]);
          int int32_4 = Convert.ToInt32(strArray[3]);
          int int32_5 = Convert.ToInt32(strArray[4]);
          int int32_6 = Convert.ToInt32(strArray[5]);
          Compobj compobj = (Compobj)this.SearchId(int32_1);
          if (compobj != null)
          {
            if (compobj.IsStage())
            {
              Stage stage = (Stage)this.SearchId(int32_1);
              if (stage != null)
              {
                Schedule schedule = new Schedule(stage, int32_2, int32_3, int32_4, int32_5, int32_6);
                stage.AddSchedule(schedule);
              }
            }
            else if (compobj.IsGroup())
            {
              Group group = (Group)this.SearchId(int32_1);
              if (group != null)
              {
                Schedule schedule = new Schedule(group, int32_2, int32_3, int32_4, int32_5, int32_6);
                group.AddSchedule(schedule);
              }
            }
          }
        }
      }
      streamReader.Close();
      return true;
    }

    private bool LoadFromWeather(string fileName)
    {
      StreamReader streamReader = new StreamReader(fileName);
      if (streamReader == null)
        return false;
      char[] chArray = new char[1] { ',' };
      string str;
      while ((str = streamReader.ReadLine()) != null)
      {
        string[] strArray = str.Split(chArray);
        if (strArray.Length == 13)
        {
          int int32_1 = Convert.ToInt32(strArray[0]);
          int int32_2 = Convert.ToInt32(strArray[1]);
          int int32_3 = Convert.ToInt32(strArray[2]);
          int int32_4 = Convert.ToInt32(strArray[3]);
          int int32_5 = Convert.ToInt32(strArray[4]);
          int int32_6 = Convert.ToInt32(strArray[5]);
          int int32_7 = Convert.ToInt32(strArray[6]);
          int int32_8 = Convert.ToInt32(strArray[7]);
          int int32_9 = Convert.ToInt32(strArray[8]);
          int int32_10 = Convert.ToInt32(strArray[9]);
          int int32_11 = Convert.ToInt32(strArray[10]);
          int int32_12 = Convert.ToInt32(strArray[11]);
          int int32_13 = Convert.ToInt32(strArray[12]);

          Compobj compobj = (Compobj)this.SearchId(int32_1);
          if (compobj != null)
          {
            if (compobj.IsNation())
            {
              Nation nation = (Nation)this.SearchId(int32_1);
              if (nation != null && int32_2 >= 1 && int32_2 <= 12)
              {
                int index = int32_2 - 1;
                nation.ClearProb[index] = int32_3;
                nation.HazyProb[index] = int32_4;
                nation.CloudyProb[index] = int32_5;
                nation.OvercastProb[index] = int32_6;
                nation.FoggyProb[index] = int32_7;
                nation.RainProb[index] = int32_8;
                nation.ShowersProb[index] = int32_9;
                nation.FlurriesProb[index] = int32_10;
                nation.SnowProb[index] = int32_11;
                nation.SunsetTime[index] = int32_12;
                nation.DarkTime[index] = int32_13;
              }
            }
            else if (compobj.IsWorld())
            {
              World world = (World)this.SearchId(int32_1);
              if (world != null && int32_2 >= 1 && int32_2 <= 12)
              {
                int index = int32_2 - 1;
                world.ClearProb[index] = int32_3;
                world.HazyProb[index] = int32_4;
                world.CloudyProb[index] = int32_5;
                world.OvercastProb[index] = int32_6;
                world.FoggyProb[index] = int32_7;
                world.RainProb[index] = int32_8;
                world.ShowersProb[index] = int32_9;
                world.FlurriesProb[index] = int32_10;
                world.SnowProb[index] = int32_11;
                world.SunsetTime[index] = int32_12;
                world.DarkTime[index] = int32_13;
              }
            }
          }
        }
      }
      streamReader.Close();
      return true;
    }

    private bool LoadFromTasks(string fileName)
    {
      StreamReader streamReader = new StreamReader(fileName);
      if (streamReader == null)
        return false;
      char[] chArray = new char[1] { ',' };
      string str;
      while ((str = streamReader.ReadLine()) != null)
      {
        string[] strArray = str.Split(chArray);
        if (strArray.Length == 7)
        {
          int int32_1 = Convert.ToInt32(strArray[0]);
          string when = strArray[1];
          string action1 = strArray[2];
          int int32_2 = Convert.ToInt32(strArray[3]);
          int int32_3 = Convert.ToInt32(strArray[4]);
          int int32_4 = Convert.ToInt32(strArray[5]);
          int int32_5 = Convert.ToInt32(strArray[6]);
          Compobj compobj1 = (Compobj)this.SearchId(int32_1);
          if (compobj1.IsTrophy() && (Trophy)compobj1 != null)
          {
            Task action2 = new Task(when, action1, int32_2, int32_3, int32_4, int32_5);
            Compobj compobj2 = (Compobj)this.SearchId(int32_2);
            if (compobj2.IsGroup())
              ((Group)compobj2).AddTask(action2);
            else if (compobj2.IsStage())
              ((Stage)compobj2).AddTask(action2);
            else if (compobj2.IsTrophy())
              ((Trophy)compobj2)?.AddTask(action2);
          }
        }
      }
      streamReader.Close();
      return true;
    }

    private bool LoadFromInitteams(string fileName)
    {
      StreamReader streamReader = new StreamReader(fileName);
      if (streamReader == null)
        return false;
      char[] chArray = new char[1] { ',' };
      string str;
      while ((str = streamReader.ReadLine()) != null)
      {
        string[] strArray = str.Split(chArray);
        if (strArray.Length == 3)
        {
          int int32_1 = Convert.ToInt32(strArray[0]);
          int int32_2 = Convert.ToInt32(strArray[1]);
          int int32_3 = Convert.ToInt32(strArray[2]);
          Compobj compobj = (Compobj)this.SearchId(int32_1);
          if (compobj.IsTrophy())
          {
            Trophy trophy = (Trophy)compobj;
            if (trophy != null)
            {
              InitTeam initTeam = new InitTeam(int32_2, int32_3);
              trophy.InitTeamArray[int32_2] = initTeam;
            }
          }
        }
      }
      streamReader.Close();
      return true;
    }

    private bool LoadFromAdvancement(string fileName)
    {
      StreamReader streamReader = new StreamReader(fileName);
      if (streamReader == null)
        return false;
      char[] chArray = new char[1] { ',' };
      string str;
      while ((str = streamReader.ReadLine()) != null)
      {
        string[] strArray = str.Split(chArray);
        if (strArray.Length == 4)
        {
          int int32_1 = Convert.ToInt32(strArray[0]);
          int int32_2 = Convert.ToInt32(strArray[1]);
          int int32_3 = Convert.ToInt32(strArray[2]);
          int int32_4 = Convert.ToInt32(strArray[3]);
          Group group1 = (Group)this.SearchId(int32_1);
          Group group2 = (Group)this.SearchId(int32_3);
          if (group1 != null && group2 != null)
          {
            Rank rank1 = (Rank)group1.Ranks.SearchId(int32_2);
            Rank rank2 = (Rank)group2.Ranks.SearchId(int32_4);
            if (rank1 != null && rank2 != null)
            {
              if (rank1.Id != 0)
                rank1.MoveTo = rank2;
              rank2.MoveFrom = rank1;
            }
          }
        }
      }
      streamReader.Close();
      return true;
    }

    private bool LoadFromInternationals(string fileName)
    {
      bool flag = false;
      StreamReader streamReader = new StreamReader(fileName);
      if (streamReader == null)
        return false;
      char[] chArray = new char[3] { ',', '[', ']' };
      string str1;
      while ((str1 = streamReader.ReadLine()) != null)
      {
        string[] strArray = str1.Split(chArray);
        if (strArray.Length == 3)
          flag = strArray[1] == "TIER_AND_OBJECTIVES";
        else if (flag && strArray.Length == 8)
        {
          int int32_1 = Convert.ToInt32(strArray[0]);
          int int32_2 = Convert.ToInt32(strArray[1]);
          Convert.ToInt32(strArray[2]);
          Convert.ToInt32(strArray[3]);
          string str2 = strArray[5];
          string str3 = strArray[7];
          Country country = FifaEnvironment.Countries.SearchCountry(int32_2);
          if (country != null)
          {
            if (str2 == "N/A")
              country.WorldCupTarget = 0;
            else if (str2 == "WIN")
              country.WorldCupTarget = 1;
            else if (str2 == "FINAL")
              country.WorldCupTarget = 2;
            else if (str2 == "SEMI")
              country.WorldCupTarget = 3;
            else if (str2 == "QUARTER")
              country.WorldCupTarget = 4;
            else if (str2 == "KNOCKOUT")
              country.WorldCupTarget = 5;
            else if (str2 == "QUALIFY")
              country.WorldCupTarget = 6;
            if (str3 == "N/A")
              country.ContinentalCupTarget = 0;
            else if (str3 == "WIN")
              country.ContinentalCupTarget = 1;
            else if (str2 == "FINAL")
              country.WorldCupTarget = 2;
            else if (str3 == "SEMI")
              country.ContinentalCupTarget = 3;
            else if (str3 == "QUARTER")
              country.ContinentalCupTarget = 4;
            else if (str3 == "KNOCKOUT")
              country.ContinentalCupTarget = 5;
            else if (str3 == "QUALIFY")
              country.ContinentalCupTarget = 6;
            country.Level = int32_1;
          }
        }
      }
      streamReader.Close();
      return true;
    }

    private bool FillFromLanguage()
    {
      foreach (Compobj compobj in (ArrayList)this)
        compobj.FillFromLanguage();
      return true;
    }

    public bool FillFromCompetition(Table t)
    {
      foreach (Compobj compobj in (ArrayList)this)
      {
        if (compobj.IsTrophy())
          ((Trophy)compobj).FillFromCompetition(t);
      }
      return true;
    }

    private bool SaveToLanguage()
    {
      foreach (Compobj compobj in (ArrayList)this)
        compobj.SaveToLanguage();
      return true;
    }

    private bool SaveToCompetition(Table t)
    {
      int nRecords = 0;
      foreach (Compobj compobj in (ArrayList)this)
      {
        if (compobj.IsTrophy() && ((Trophy)compobj).ballid >= 0)
          ++nRecords;
      }
      t.ResizeRecords(nRecords);
      int index = 0;
      foreach (Compobj compobj in (ArrayList)this)
      {
        if (compobj.IsTrophy())
        {
          Trophy trophy = (Trophy)compobj;
          if (trophy.ballid >= 0)
          {
            Record record = t.Records[index];
            trophy.SaveCompetition(record);
            ++index;
          }
        }
      }
      t.SortByKeys();
      return true;
    }

    public string[] GetFceDescriptors()
    {
      int length = 0;
      string[] strArray1 = new string[256];
      if (FifaEnvironment.LangDb == null)
        return (string[])null;
      Table table = FifaEnvironment.LangDb.Table[0];
      if (table == null)
        return (string[])null;
      for (int index = 0; index < table.NRecords; ++index)
      {
        string str = table.Records[index].CompressedString[FI.language_stringid];
        if (str.StartsWith("FCE_") && length < strArray1.Length)
          strArray1[length++] = str;
      }
      string[] strArray2 = new string[length];
      for (int index = 0; index < length; ++index)
        strArray2[index] = strArray1[index];
      return strArray2;
    }

    private void CollectDescriptions()
    {
      CompobjList.s_Descriptions.Clear();
      string[] fceDescriptors = this.GetFceDescriptors();
      CompobjList.s_Descriptions.AddRange((ICollection)fceDescriptors);
      foreach (Compobj compobj in (ArrayList)this)
      {
        if (compobj.IsStage() && !compobj.Description.StartsWith("FCE_") && !CompobjList.s_Descriptions.Contains((object)compobj.Description))
          CompobjList.s_Descriptions.Add((object)compobj.Description);
      }
      CompobjList.s_Descriptions.Sort();
    }

    public World World
    {
      get
      {
        foreach (Compobj compobj in (ArrayList)this)
        {
          if (compobj.IsWorld())
            return (World)compobj;
        }
        return (World)null;
      }
    }

    public void Save(string path, DbFile fifaDbFile)
    {
      this.Renumber();
      this.SaveToCompobj(path + "\\dlc\\dlc_FootballCompEng\\dlc\\FootballCompEng\\data\\compdata\\compobj.txt");
      this.SaveToCompids(path + "\\dlc\\dlc_FootballCompEng\\dlc\\FootballCompEng\\data\\compdata\\compids.txt");
      this.SaveToSettings(path + "\\dlc\\dlc_FootballCompEng\\dlc\\FootballCompEng\\data\\compdata\\settings.txt");
      this.SaveToStandings(path + "\\dlc\\dlc_FootballCompEng\\dlc\\FootballCompEng\\data\\compdata\\standings.txt");
      this.SaveToAdvancement(path + "\\dlc\\dlc_FootballCompEng\\dlc\\FootballCompEng\\data\\compdata\\advancement.txt");
      this.SaveToSchedule(path + "\\dlc\\dlc_FootballCompEng\\dlc\\FootballCompEng\\data\\compdata\\schedule.txt");
      this.SaveToWeather(path + "\\dlc\\dlc_FootballCompEng\\dlc\\FootballCompEng\\data\\compdata\\weather.txt");
      this.SaveToTasks(path + "\\dlc\\dlc_FootballCompEng\\dlc\\FootballCompEng\\data\\compdata\\tasks.txt");
      this.SaveToInitteams(path + "\\dlc\\dlc_FootballCompEng\\dlc\\FootballCompEng\\data\\compdata\\initteams.txt");
      this.SaveToInternationals(path + "\\dlc\\dlc_FootballCompEng\\dlc\\FootballCompEng\\data\\internationals.txt");
      this.SaveToLanguage();
      this.SaveToCompetition(fifaDbFile.Table[TI.competition]);
    }

    public int Renumber()
    {
      return this.World != null ? this.World.Renumber(0) : 0;
    }

    private bool SaveToCompobj(string fileName)
    {
      if (this.World == null)
        return false;
      File.Copy(fileName, fileName + ".bak", true);
      StreamWriter w = new StreamWriter(fileName, false);
      if (w == null)
        return false;
      this.World.SaveRecursivelyToCompobj(w);
      w.Close();
      return true;
    }

    private bool SaveToCompids(string fileName)
    {
      if (this.World == null || !File.Exists(fileName))
        return false;
      File.Copy(fileName, fileName + ".bak", true);
      StreamWriter w = new StreamWriter(fileName, false);
      if (w == null)
        return false;
      this.World.SaveRecursivelyToCompids(w);
      w.Close();
      return true;
    }

    private bool SaveToSettings(string fileName)
    {
      if (this.World == null)
        return false;
      File.Copy(fileName, fileName + ".bak", true);
      StreamWriter w = new StreamWriter(fileName, false);
      if (w == null)
        return false;
      this.World.SaveRecursivelyToSettings(w);
      w.Close();
      return true;
    }

    private bool SaveToStandings(string fileName)
    {
      if (this.World == null)
        return false;
      File.Copy(fileName, fileName + ".bak", true);
      StreamWriter w = new StreamWriter(fileName, false);
      if (w == null)
        return false;
      this.World.SaveRecursivelyToStandings(w);
      w.Close();
      return true;
    }

    private bool SaveToAdvancement(string fileName)
    {
      if (this.World == null)
        return false;
      File.Copy(fileName, fileName + ".bak", true);
      StreamWriter w = new StreamWriter(fileName, false);
      if (w == null)
        return false;
      this.World.SaveRecursivelyToAdvancement(w);
      w.Close();
      return true;
    }

    private bool SaveToSchedule(string fileName)
    {
      if (this.World == null)
        return false;
      File.Copy(fileName, fileName + ".bak", true);
      StreamWriter w = new StreamWriter(fileName, false);
      if (w == null)
        return false;
      this.World.SaveRecursivelyToSchedule(w);
      w.Close();
      return true;
    }

    private bool SaveToWeather(string fileName)
    {
      if (this.World == null)
        return false;
      File.Copy(fileName, fileName + ".bak", true);
      StreamWriter w = new StreamWriter(fileName, false);
      if (w == null)
        return false;
      this.World.SaveRecursivelyToWeather(w);
      w.Close();
      return true;
    }

    private bool SaveToInitteams(string fileName)
    {
      if (this.World == null)
        return false;
      File.Copy(fileName, fileName + ".bak", true);
      StreamWriter w = new StreamWriter(fileName, false);
      if (w == null)
        return false;
      this.World.SaveRecursivelyToInitteams(w);
      w.Close();
      return true;
    }

    private bool SaveToInternationals(string fileName)
    {
      int num1 = 0;
      char[] chArray = new char[3] { ',', '[', ']' };
      if (!File.Exists(fileName))
        return false;
      File.Copy(fileName, fileName + ".bak", true);
      StreamReader streamReader = new StreamReader(fileName + ".bak");
      if (streamReader == null)
        return false;
      StreamWriter streamWriter = new StreamWriter(fileName, false);
      if (streamWriter == null)
        return false;
      string str1;
      while ((str1 = streamReader.ReadLine()) != null)
      {
        string[] strArray = str1.Split(chArray);
        if (strArray.Length == 3)
        {
          if (strArray[1] == "TIER_AND_OBJECTIVES")
          {
            streamWriter.WriteLine(str1);
            num1 = 1;
            IEnumerator enumerator = FifaEnvironment.Countries.GetEnumerator();
            try
            {
              while (enumerator.MoveNext())
              {
                Country current = (Country)enumerator.Current;
                if (current.NationalTeam != null)
                {
                  int level = current.Level;
                  int id1 = current.Id;
                  int id2 = current.NationalTeam.Id;
                  int num2 = current.Confederation + 1;
                  string str2 = this.CupTarget(current.WorldCupTarget);
                  string str3 = this.CupTarget(current.ContinentalCupTarget);
                  string str4 = level.ToString() + "," + id1.ToString() + "," + id2.ToString() + "," + num2.ToString() + "," + str2 + "," + str2 + "," + str3 + "," + str3;
                  streamWriter.WriteLine(str4);
                }
              }
              continue;
            }
            finally
            {
              if (enumerator is IDisposable disposable)
                disposable.Dispose();
            }
          }
          else if (num1 == 1)
          {
            streamWriter.WriteLine();
            num1 = 2;
          }
        }
        if (num1 != 1)
          streamWriter.WriteLine(str1);
      }
      streamReader.Close();
      streamWriter.Close();
      return true;
    }

    private string CupTarget(int index)
    {
      switch (index)
      {
        case 1:
          return "WIN";
        case 2:
          return "FINAL";
        case 3:
          return "SEMI";
        case 4:
          return "QUARTER";
        case 5:
          return "KNOCKOUT";
        case 6:
          return "QUALIFY";
        default:
          return "N/A";
      }
    }

    private bool SaveToTasks(string fileName)
    {
      if (this.World == null)
        return false;
      File.Copy(fileName, fileName + ".bak", true);
      StreamWriter w = new StreamWriter(fileName, false);
      if (w == null)
        return false;
      this.World.SaveRecursivelyToTasks(w);
      w.Close();
      return true;
    }

    public void Link()
    {
      foreach (Compobj compobj in (ArrayList)this)
      {
        if (compobj.IsTrophy())
        {
          compobj.LinkLeague(FifaEnvironment.Leagues);
          compobj.LinkTeam(FifaEnvironment.Teams);
          compobj.LinkCompetitions();
        }
        if (compobj.IsNation())
          compobj.LinkCountry(FifaEnvironment.Countries);
        if (compobj.IsStage())
        {
          compobj.LinkStadium(FifaEnvironment.Stadiums);
          compobj.LinkCompetitions();
        }
        if (compobj.IsGroup())
          compobj.LinkCompetitions();
      }
    }

    private void Normalize()
    {
      foreach (Compobj compobj in (ArrayList)this)
        compobj.Normalize();
    }

    public Trophy SearchTrophy(int assetId)
    {
      foreach (Compobj compobj in (ArrayList)this)
      {
        if (compobj.IsTrophy() && compobj.Settings.m_asset_id == assetId)
          return (Trophy)compobj;
      }
      return (Trophy)null;
    }

    public int GetInternationalFriendlyId()
    {
      foreach (Trophy trophy in (ArrayList)this.Trophies)
      {
        if (trophy.Settings.m_comp_type == "INTERFRIENDLY")
          return trophy.Id;
      }
      return -1;
    }
  }
}
