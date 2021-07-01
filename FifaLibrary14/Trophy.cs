// Original code created by Rinaldo

using System.Collections;
using System.Drawing;
using System.IO;

namespace FifaLibrary
{
  public class Trophy : Compobj
  {
    private int m_ballid = -1;
    private InitTeam[] m_InitTeamArray = new InitTeam[24];
    public Task[] m_StartTask = new Task[24];
    public Task[] m_EndTask = new Task[24];
    private string m_ShortName;
    private string m_LongName;
    public int m_NStartTasks;
    public int m_NEndTasks;

    public override string ToString()
    {
      if (this.m_LongName != null && this.m_LongName != string.Empty)
        return this.m_LongName;
      return this.m_ShortName != null && this.m_ShortName != string.Empty ? this.m_ShortName : "Trophy n. " + this.Settings.m_asset_id.ToString();
    }

    public int ballid
    {
      get
      {
        return this.m_ballid;
      }
      set
      {
        this.m_ballid = value;
      }
    }

    public Nation Nation
    {
      get
      {
        return this.ParentObj.TypeNumber == 2 ? (Nation) this.ParentObj : (Nation) null;
      }
    }

    public Confederation Confederation
    {
      get
      {
        return this.ParentObj.TypeNumber == 1 ? (Confederation) this.ParentObj : (Confederation) null;
      }
    }

    public string ShortName
    {
      get
      {
        return this.m_ShortName;
      }
      set
      {
        this.m_ShortName = value;
      }
    }

    public bool SetLanguageName(string languageName)
    {
      if (FifaEnvironment.Language == null || this.Description == null)
        return false;
      FifaEnvironment.Language.SetString(this.Description, languageName);
      return true;
    }

    public string LongName
    {
      get
      {
        return this.m_LongName;
      }
      set
      {
        this.m_LongName = value;
      }
    }

    public override void LinkLeague(LeagueList leagueList)
    {
      if (leagueList == null)
        return;
      if (this.Settings.m_info_league_promo >= 0)
        this.Settings.LeaguePromo = (League) leagueList.SearchId(this.Settings.m_info_league_promo);
      else
        this.Settings.LeaguePromo = (League) null;
      if (this.Settings.m_info_league_releg >= 0)
        this.Settings.LeagueReleg = (League) leagueList.SearchId(this.Settings.m_info_league_releg);
      else
        this.Settings.LeagueReleg = (League) null;
    }

    public override void LinkTeam(TeamList teamList)
    {
      for (int index = 0; index < this.m_InitTeamArray.Length; ++index)
      {
        if (this.m_InitTeamArray[index] != null)
          this.m_InitTeamArray[index].LinkTeam(teamList);
      }
    }

    public InitTeam[] InitTeamArray
    {
      get
      {
        return this.m_InitTeamArray;
      }
      set
      {
        this.m_InitTeamArray = value;
      }
    }

    public Trophy(int id, string typeString, string description, Compobj parentObj)
      : base(id, 3, typeString, description, parentObj)
    {
      this.m_Stages = new StageList();
    }

    public void FillFromCompetition(Table t)
    {
      this.m_ballid = -1;
      for (int index = 0; index < t.NRecords; ++index)
      {
        Record record = t.Records[index];
        if (record.GetAndCheckIntField(FI.competition_competitionid) == this.Settings.m_asset_id)
        {
          this.m_ballid = record.GetAndCheckIntField(FI.competition_ballid);
          break;
        }
      }
    }

    public void SaveCompetition(Record r)
    {
      if (this.m_ballid < 0)
        return;
      r.IntField[FI.competition_competitionid] = this.Settings.m_asset_id;
      r.IntField[FI.competition_ballid] = this.m_ballid;
    }

    public override bool SaveToInitteams(StreamWriter w)
    {
      for (int index1 = 0; index1 < this.m_NEndTasks; ++index1)
      {
        Task task = this.m_EndTask[index1];
        if (task.Action == "UpdateTable")
        {
          int index2 = task.Parameter3 - 1;
          InitTeam initTeam = this.m_InitTeamArray[index2];
          if (initTeam != null)
          {
            string str;
            if (initTeam.teamid >= 0)
              str = this.Id.ToString() + "," + index2.ToString() + "," + initTeam.teamid.ToString();
            else
              str = this.Id.ToString() + "," + index2.ToString() + ",-1";
            w.WriteLine(str);
          }
        }
      }
      return true;
    }

    public override bool SaveToCompids(StreamWriter w)
    {
      if (w == null)
        return false;
      string str = this.Id.ToString();
      w.WriteLine(str);
      return true;
    }

    public override bool SaveToTasks(StreamWriter w)
    {
      if (w == null)
        return false;
      for (int index = 0; index < this.m_NStartTasks; ++index)
        this.m_StartTask[index].SaveToTasks(w);
      for (int index = 0; index < this.m_NEndTasks; ++index)
        this.m_EndTask[index].SaveToTasks(w);
      return true;
    }

    public static int AutoAsset()
    {
      for (int index = 1; index < 9999; ++index)
      {
        bool flag = false;
        foreach (Compobj competitionObject in (ArrayList) FifaEnvironment.CompetitionObjects)
        {
          if (competitionObject.Settings.m_asset_id == index)
          {
            flag = true;
            break;
          }
        }
        if (!flag)
        {
          foreach (IdObject league in (ArrayList) FifaEnvironment.Leagues)
          {
            if (league.Id == index)
            {
              flag = true;
              break;
            }
          }
          if (!flag)
            return index;
        }
      }
      return 0;
    }

    public override bool FillFromLanguage()
    {
      if (FifaEnvironment.Language != null)
      {
        this.m_ShortName = FifaEnvironment.Language.GetTournamentString(this.Settings.m_asset_id, Language.ETournamentStringType.Abbr15);
        this.m_LongName = FifaEnvironment.Language.GetTournamentString(this.Settings.m_asset_id, Language.ETournamentStringType.Full);
        if (this.m_LongName == null && this.m_ShortName == null)
          this.m_ShortName = FifaEnvironment.Language.GetString(this.Description);
        if (this.m_LongName == null)
          this.m_LongName = string.Empty;
        if (this.m_ShortName == null)
          this.m_ShortName = string.Empty;
        if (this.m_LongName == string.Empty)
          this.m_LongName = this.m_ShortName;
        if (this.m_ShortName == string.Empty)
          this.m_ShortName = this.m_LongName.Length <= 15 ? this.m_LongName : this.m_LongName.Substring(0, 15);
      }
      else
      {
        this.m_ShortName = string.Empty;
        this.m_LongName = string.Empty;
      }
      return true;
    }

    public override bool SaveToLanguage()
    {
      if (FifaEnvironment.Language == null)
        return false;
      FifaEnvironment.Language.SetTournamentString(this.Settings.m_asset_id, Language.ETournamentStringType.Abbr15, this.m_ShortName);
      FifaEnvironment.Language.SetTournamentString(this.Settings.m_asset_id, Language.ETournamentStringType.Full, this.m_LongName);
      return true;
    }

    public bool InsertStage(int stageIndex)
    {
      if (stageIndex > this.Stages.Count)
        return false;
      Stage stage = new Stage(FifaEnvironment.CompetitionObjects.GetNewId(), "S" + (stageIndex + 1).ToString(), "FCE_Setup_Stage", (Compobj) this);
      if (stage == null)
        return false;
      stage.Settings.m_match_stagetype = "SETUP";
      this.Stages.Insert(stageIndex, (object) stage);
      FifaEnvironment.CompetitionObjects.Add((object) stage);
      for (int index = 0; index < this.Stages.Count; ++index)
      {
        string str = "S" + (index + 1).ToString();
        ((Compobj) this.Stages[index]).TypeString = str;
      }
      return true;
    }

    public bool RemoveStage(Stage stage)
    {
      int stageIndex = this.Stages.IndexOf((object) stage);
      if (stageIndex < 0)
        return false;
      this.RemoveStage(stageIndex);
      return true;
    }

    public bool RemoveStage(int stageIndex)
    {
      if (stageIndex > this.Stages.Count)
        return false;
      Stage stage = (Stage) this.Stages[stageIndex];
      this.Stages.RemoveAt(stageIndex);
      FifaEnvironment.CompetitionObjects.RemoveId((IdObject) stage);
      for (int index = 0; index < this.Stages.Count; ++index)
      {
        string str = "S" + (index + 1).ToString();
        ((Compobj) this.Stages[index]).TypeString = str;
      }
      return true;
    }

    public bool AddStage()
    {
      Stage stage = new Stage(FifaEnvironment.CompetitionObjects.GetNewId(), "S" + (this.Stages.Count + 1).ToString(), string.Empty, (Compobj) this);
      if (stage == null)
        return false;
      this.Stages.Add((object) stage);
      FifaEnvironment.CompetitionObjects.Add((object) stage);
      return true;
    }

    public bool RemoveStage()
    {
      if (this.Stages.Count < 1)
        return false;
      Stage stage = (Stage) this.Stages[this.Stages.Count - 1];
      this.Stages.Remove((object) stage);
      FifaEnvironment.CompetitionObjects.Remove((object) stage);
      stage.RemoveAllGroups();
      return true;
    }

    public bool RemoveAllStages()
    {
      int count = this.Stages.Count;
      for (int index = 0; index < count; ++index)
        this.RemoveStage();
      return true;
    }

    public override void Normalize()
    {
      if (this.Settings.m_match_matchsituation != null)
      {
        foreach (Stage stage in (ArrayList) this.m_Stages)
        {
          if (stage.Settings.m_match_stagetype != "SETUP" && stage.Settings.m_match_matchsituation == null)
            stage.Settings.m_match_matchsituation = this.Settings.m_match_matchsituation;
        }
        this.Settings.m_match_matchsituation = (string) null;
      }
      if (this.Settings.m_N_endruleko1leg == 0)
        return;
      foreach (Stage stage in (ArrayList) this.m_Stages)
      {
        if (stage.Settings.m_match_stagetype != "SETUP")
        {
          for (int index = 0; index < this.Settings.m_N_endruleko1leg; ++index)
          {
            if (this.Settings.m_match_endruleko1leg[index] != null && stage.Settings.m_match_endruleko1leg[index] == null)
              stage.Settings.m_match_endruleko1leg[index] = this.Settings.m_match_endruleko1leg[index];
          }
        }
      }
      for (int index = 0; index < this.Settings.m_N_endruleko1leg; ++index)
        this.Settings.m_match_endruleko1leg[index] = (string) null;
      this.Settings.m_N_endruleko1leg = 0;
    }

    public void LinkTaskGroup()
    {
    }

    public override void LinkCompetitions()
    {
      Trophy trophyCompdependency = this.Settings.TrophyCompdependency;
      Trophy trophyForcecomp = this.Settings.TrophyForcecomp;
      for (int index = 0; index < this.m_NStartTasks; ++index)
        this.m_StartTask[index].LinkTrophy(this);
      for (int index = 0; index < this.m_NEndTasks; ++index)
        this.m_EndTask[index].LinkTrophy(this);
    }

    public bool AddTask(Task action)
    {
      if (action.When == "start")
      {
        if (this.m_NStartTasks == 0)
          this.m_StartTask = new Task[24];
        if (this.m_NStartTasks < this.m_StartTask.Length)
        {
          this.m_StartTask[this.m_NStartTasks] = action;
          ++this.m_NStartTasks;
          return true;
        }
      }
      else if (action.When == "end")
      {
        if (this.m_NEndTasks == 0)
          this.m_EndTask = new Task[24];
        if (this.m_NEndTasks < this.m_EndTask.Length)
        {
          this.m_EndTask[this.m_NEndTasks] = action;
          ++this.m_NEndTasks;
          return true;
        }
      }
      return false;
    }

    public bool RemoveLastTask(string when)
    {
      if (when == "start")
      {
        if (this.m_NStartTasks <= 0)
          return false;
        --this.m_NStartTasks;
        this.m_StartTask[this.m_NStartTasks] = (Task) null;
        return true;
      }
      if (!(when == "end") || this.m_NEndTasks <= 0)
        return false;
      --this.m_NEndTasks;
      this.m_EndTask[this.m_NEndTasks] = (Task) null;
      return true;
    }

    public int SearchTaskIndex(string when, string action, int par1, int par2, int par3)
    {
      if (when == "start")
      {
        for (int index = 0; index < this.m_NStartTasks; ++index)
        {
          if ((action == null || this.m_StartTask[index].Action == action) && (par1 < 0 || this.m_StartTask[index].Parameter1 == par1) && ((par2 < 0 || this.m_StartTask[index].Parameter2 == par2) && (par3 < 0 || this.m_StartTask[index].Parameter3 == par3)))
            return index;
        }
      }
      else if (when == "end")
      {
        for (int index = 0; index < this.m_NEndTasks; ++index)
        {
          if ((action == null || this.m_EndTask[index].Action == action) && (par1 < 0 || this.m_EndTask[index].Parameter1 == par1) && ((par2 < 0 || this.m_EndTask[index].Parameter2 == par2) && (par3 < 0 || this.m_EndTask[index].Parameter3 == par3)))
            return index;
        }
      }
      return -1;
    }

    public Task SearchTask(string when, string action, int par1, int par2, int par3)
    {
      int index = this.SearchTaskIndex(when, action, par1, par2, par3);
      return index >= 0 ? this.GetTask(when, index) : (Task) null;
    }

    public bool RemoveTask(string when, int index)
    {
      if (when == "start")
      {
        if (index < this.m_NStartTasks)
        {
          --this.m_NStartTasks;
          for (int index1 = index; index1 < this.m_NStartTasks; ++index1)
            this.m_StartTask[index1] = this.m_StartTask[index1 + 1];
          return true;
        }
      }
      else if (index < this.m_NEndTasks)
      {
        --this.m_NEndTasks;
        for (int index1 = index; index1 < this.m_NEndTasks; ++index1)
          this.m_EndTask[index1] = this.m_EndTask[index1 + 1];
        return true;
      }
      return false;
    }

    public bool RemoveTask(string when, string action, int par1, int par2, int par3)
    {
      int index = this.SearchTaskIndex(when, action, par1, par2, par3);
      return index >= 0 && this.RemoveTask(when, index);
    }

    public bool RemoveTask(Task task)
    {
      return this.RemoveTask(task.When, task.Action, task.Parameter1, task.Parameter2, task.Parameter3);
    }

    public bool ReplaceTask(Task task, int index)
    {
      if (task.When == "start")
      {
        if (index < this.m_NStartTasks)
        {
          this.m_StartTask[index] = task;
          return true;
        }
      }
      else if (index < this.m_NEndTasks)
      {
        this.m_EndTask[index] = task;
        return true;
      }
      return false;
    }

    public bool ReplaceTask(Task currentTask, Task newTask)
    {
      int index = this.SearchTaskIndex(currentTask.When, currentTask.Action, currentTask.Parameter1, currentTask.Parameter2, currentTask.Parameter3);
      return index >= 0 && this.ReplaceTask(newTask, index);
    }

    public Task GetTask(string when, int index)
    {
      if (when == "start")
      {
        if (index < this.m_NStartTasks)
          return this.m_StartTask[index];
      }
      else if (index < this.m_NEndTasks)
        return this.m_EndTask[index];
      return (Task) null;
    }

    public void CopyTasks(Trophy newTrophy, League targetLeague)
    {
      for (int index = 0; index < this.m_NStartTasks; ++index)
        newTrophy.AddTask(this.m_StartTask[index].CopyTask((Compobj) newTrophy, targetLeague));
      for (int index = 0; index < this.m_NEndTasks; ++index)
        newTrophy.AddTask(this.m_EndTask[index].CopyTask((Compobj) newTrophy, targetLeague));
    }

    public static string TrophyDdsFileName(int id)
    {
      return "data/ui/imgassets/trophy/t" + id.ToString() + ".dds";
    }

    public string TrophyTemplateFileName()
    {
      return "data/ui/imgassets/trophy/t#.dds";
    }

    public string TrophyDdsFileName()
    {
      return Trophy.TrophyDdsFileName(this.Settings.m_asset_id);
    }

    public Bitmap GetTrophy()
    {
      return FifaEnvironment.GetDdsArtasset(this.TrophyDdsFileName());
    }

    public bool SetTrophy(Bitmap bitmap)
    {
      return bitmap != null && FifaEnvironment.SetDdsArtasset(this.TrophyTemplateFileName(), this.Settings.m_asset_id, bitmap);
    }

    public bool DeleteTrophy()
    {
      return FifaEnvironment.DeleteFromZdata(this.TrophyDdsFileName());
    }

    public static string TrophyDdsFileName256(int id)
    {
      return "data/ui/imgassets/trophy256x256/t" + id.ToString() + ".dds";
    }

    public string TrophyTemplateFileName256()
    {
      return "data/ui/imgassets/trophy256x256/t#.dds";
    }

    public string TrophyDdsFileName256()
    {
      return Trophy.TrophyDdsFileName256(this.Settings.m_asset_id);
    }

    public Bitmap GetTrophy256()
    {
      return FifaEnvironment.GetDdsArtasset(this.TrophyDdsFileName256());
    }

    public bool SetTrophy256(Bitmap bitmap)
    {
      return bitmap != null && FifaEnvironment.SetDdsArtasset(this.TrophyTemplateFileName256(), this.Settings.m_asset_id, bitmap);
    }

    public bool DeleteTrophy256()
    {
      return FifaEnvironment.DeleteFromZdata(this.TrophyDdsFileName256());
    }

    public static string TrophyDdsFileName128(int id)
    {
      return "data/ui/imgassets/trophy128x128/t" + id.ToString() + ".dds";
    }

    public string TrophyTemplateFileName128()
    {
      return "data/ui/imgassets/trophy128x128/t#.dds";
    }

    public string TrophyDdsFileName128()
    {
      return Trophy.TrophyDdsFileName128(this.Settings.m_asset_id);
    }

    public Bitmap GetTrophy128()
    {
      return FifaEnvironment.GetDdsArtasset(this.TrophyDdsFileName128());
    }

    public bool SetTrophy128(Bitmap bitmap)
    {
      return bitmap != null && FifaEnvironment.SetDdsArtasset(this.TrophyTemplateFileName128(), this.Settings.m_asset_id, bitmap);
    }

    public bool DeleteTrophy128()
    {
      return FifaEnvironment.DeleteFromZdata(this.TrophyDdsFileName128());
    }

    public static string TexturesFileName(int id)
    {
      return "data/sceneassets/trophy/trophy_" + id.ToString() + "_textures.rx3";
    }

    public string TexturesFileName()
    {
      return Trophy.TexturesFileName(this.Settings.m_asset_id);
    }

    public string TexturesTemplateFileName()
    {
      return "data/sceneassets/trophy/trophy_#_textures.rx3";
    }

    public Bitmap[] GetTextures()
    {
      return FifaEnvironment.GetBmpsFromRx3(this.TexturesFileName());
    }

    public bool SetTextures(Bitmap[] bitmaps)
    {
      return bitmaps != null && FifaEnvironment.ImportBmpsIntoZdata(this.TexturesTemplateFileName(), this.Settings.m_asset_id, bitmaps, ECompressionMode.Chunkzip2);
    }

    public bool SetTextures(string rx3FileName)
    {
      return rx3FileName != null && FifaEnvironment.ImportFileIntoZdataAs(rx3FileName, this.TexturesFileName(), false, ECompressionMode.Chunkzip);
    }

    public bool DeleteContainer(int timeofday)
    {
      return FifaEnvironment.DeleteFromZdata(this.TexturesFileName());
    }

    public static string ModelFileName(int trophyId)
    {
      return "data/sceneassets/trophy/trophy_" + trophyId.ToString() + ".rx3";
    }

    public string ModelFileName()
    {
      return Trophy.ModelFileName(this.Settings.m_asset_id);
    }

    public string ModelTemplateFileName()
    {
      return "data/sceneassets/trophy/trophy_#.rx3";
    }

    public Rx3File GetModel()
    {
      return FifaEnvironment.GetRx3FromZdata(this.ModelFileName());
    }

    public string ExportModelFile()
    {
      return FifaEnvironment.ExportFileFromZdata(this.ModelFileName(), FifaEnvironment.ExportFolder) ? FifaEnvironment.ExportFolder + "\\" + this.ModelFileName() : (string) null;
    }

    public bool SetModel(string rx3FileName)
    {
      return rx3FileName != null && FifaEnvironment.ImportFileIntoZdataAs(rx3FileName, this.ModelFileName(), false, ECompressionMode.Chunkzip);
    }

    public bool DeleteModel()
    {
      return FifaEnvironment.DeleteFromZdata(this.ModelFileName());
    }
  }
}
