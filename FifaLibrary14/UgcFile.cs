// Original code created by Rinaldo

using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace FifaLibrary
{
  public class UgcFile
  {
    private int m_NFiles = -1;
    private UgcDirEntry[] m_UgcDir;
    private BinaryReader m_BinaryReader;

    public int NFiles
    {
      get
      {
        return this.m_NFiles;
      }
    }

    public UgcDirEntry[] UgcDir
    {
      get
      {
        return this.m_UgcDir;
      }
    }

    public UgcFile(string fileName)
    {
      this.Load(fileName);
    }

    public bool Load(string fileName)
    {
      FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
      if (fileStream == null)
        return false;
      BinaryReader r = new BinaryReader((Stream) fileStream);
      this.m_BinaryReader = r;
      return r != null && this.Load(r);
    }

    public bool Load(BinaryReader r)
    {
      r.BaseStream.Position = 0L;
      r.ReadBytes(56);
      this.m_NFiles = r.ReadInt32() + 1;
      this.m_UgcDir = new UgcDirEntry[this.m_NFiles];
      r.ReadInt32();
      for (int index = 0; index < this.m_NFiles; ++index)
        this.m_UgcDir[index] = new UgcDirEntry(r);
      return true;
    }

    public bool Extract(int fileIndex, string outputFolder)
    {
      if (fileIndex < 0 || fileIndex >= this.m_NFiles)
        return false;
      this.m_BinaryReader.BaseStream.Position = (long) (this.m_UgcDir[fileIndex].Offset + 44U);
      if (this.m_UgcDir[fileIndex].FileName == null || this.m_UgcDir[fileIndex].FileName == string.Empty)
        return false;
      string outputFileName = outputFolder + "\\" + this.m_UgcDir[fileIndex].ToString();
      return this.m_UgcDir[fileIndex].IsPng() ? this.ExtractPng(this.m_BinaryReader, outputFileName) : this.ExtractDb(this.m_BinaryReader, outputFileName);
    }

    public bool ExtractPng(BinaryReader r, string outputFileName)
    {
      byte[] numArray = new byte[8];
      int index = 0;
      numArray[0] = (byte) 73;
      numArray[1] = (byte) 69;
      numArray[2] = (byte) 78;
      numArray[3] = (byte) 68;
      numArray[4] = (byte) 174;
      numArray[5] = (byte) 66;
      numArray[6] = (byte) 96;
      numArray[7] = (byte) 130;
      FileStream fileStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write);
      if (fileStream == null)
        return false;
      BinaryWriter binaryWriter = new BinaryWriter((Stream) fileStream);
      if (binaryWriter == null)
        return false;
      do
      {
        byte num = r.ReadByte();
        if ((int) num == (int) numArray[index])
          ++index;
        else
          index = 0;
        binaryWriter.Write(num);
      }
      while (index != numArray.Length);
      fileStream.Close();
      binaryWriter.Close();
      return true;
    }

    public bool ExtractDb(BinaryReader r, string outputFileName)
    {
      FileStream fileStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write);
      if (fileStream == null)
        return false;
      BinaryWriter binaryWriter = new BinaryWriter((Stream) fileStream);
      if (binaryWriter == null)
        return false;
      binaryWriter.Write(r.ReadBytes(8));
      int num1 = r.ReadInt32();
      binaryWriter.Write(num1);
      int num2 = num1 - 12;
      for (int index = 0; index < num2; ++index)
      {
        byte num3 = r.ReadByte();
        binaryWriter.Write(num3);
      }
      fileStream.Close();
      binaryWriter.Close();
      return true;
    }

    public void ImportKitGraphics(string xmlFileName, ToolStripStatusLabel statusBar)
    {
      DbFile dbFile = new DbFile(FifaEnvironment.TempFolder + "\\" + this.m_UgcDir[0].ToString(), xmlFileName);
      Table table1 = dbFile.GetTable("teams");
      dbFile.GetTable("cz_leagues");
      Table table2 = dbFile.GetTable("cz_teamkits");
      Table table3 = dbFile.GetTable("cz_teams");
      Team[] teamArray = new Team[table1.NValidRecords];
      for (int index1 = 0; index1 < table1.NValidRecords; ++index1)
      {
        Record record1 = table1.Records[index1];
        record1.GetAndCheckIntField(FI.teams_assetid);
        int andCheckIntField1 = record1.GetAndCheckIntField(FI.teams_teamid);
        Team team = FifaEnvironment.Teams.FitTeam(record1.StringField[FI.teams_teamname], 0);
        if (team != null)
        {
          if (statusBar != null)
          {
            statusBar.Text = "Importing Team: " + team.DatabaseName;
            statusBar.Owner.Refresh();
          }
          teamArray[index1] = team;
          Bitmap bitmap = (Bitmap) null;
          Bitmap srcBitmap = (Bitmap) null;
          for (int index2 = 0; index2 < table3.NValidRecords; ++index2)
          {
            Record record2 = table3.Records[index2];
            if (record2.GetAndCheckIntField(FI.cz_teams_teamid) == andCheckIntField1)
            {
              int andCheckIntField2 = record2.GetAndCheckIntField(FI.cz_teams_hascrestimage);
              int andCheckIntField3 = record2.GetAndCheckIntField(FI.cz_teams_hassponsorimage);
              string str1 = FifaEnvironment.TempFolder + "\\" + andCheckIntField2.ToString() + ".png";
              if (File.Exists(str1))
                bitmap = new Bitmap(str1);
              string str2 = FifaEnvironment.TempFolder + "\\" + andCheckIntField3.ToString() + ".png";
              if (File.Exists(str2))
              {
                srcBitmap = new Bitmap(str2);
                break;
              }
              break;
            }
          }
          int assetid = teamArray[index1].assetid;
          for (int index2 = 0; index2 < table2.NValidRecords; ++index2)
          {
            Record record2 = table2.Records[index2];
            int andCheckIntField2 = record2.GetAndCheckIntField(FI.cz_teamkits_kitid);
            int andCheckIntField3 = record2.GetAndCheckIntField(FI.cz_teamkits_teamid);
            int andCheckIntField4 = record2.GetAndCheckIntField(FI.cz_teamkits_kittypeid);
            string fileName = Kit.KitTextureFileName(andCheckIntField2, 0, 0);
            if (andCheckIntField1 == andCheckIntField3)
            {
              Kit kit1 = FifaEnvironment.Kits.GetKit(team.Id, andCheckIntField4);
              if (kit1 == null)
              {
                kit1 = new Kit(FifaEnvironment.Kits.GetNewId(), team.Id, andCheckIntField4);
                FifaEnvironment.Kits.Add((object) kit1);
                kit1.LinkTeam(FifaEnvironment.Teams);
              }
              kit1.jerseyBackName = record2.IntField[FI.cz_teamkits_jerseybacknameplacementcode] != 0;
              kit1.jerseyNameFontCase = record2.IntField[FI.cz_teamkits_jerseybacknamefontcase];
              kit1.jerseyNameFont = record2.IntField[FI.cz_teamkits_jerseynamefonttype];
              int red = record2.IntField[FI.cz_teamkits_jerseynamecolorr];
              int green = record2.IntField[FI.cz_teamkits_jerseynamecolorg];
              int blue = record2.IntField[FI.cz_teamkits_jerseynamecolorb];
              kit1.JerseyNameColor = Color.FromArgb((int) byte.MaxValue, red, green, blue);
              kit1.jerseyNameLayout = record2.IntField[FI.cz_teamkits_jerseynamelayouttype];
              kit1.jerseyNumberFont = record2.IntField[FI.cz_teamkits_numberfonttype];
              kit1.jerseyNumberColor = record2.IntField[FI.cz_teamkits_numbercolor];
              kit1.shortsNumberColor = record2.IntField[FI.cz_teamkits_shortsnumbercolor];
              kit1.shortsNumberFont = record2.IntField[FI.cz_teamkits_shortsnumberfonttype];
              kit1.shortsNumber = true;
              kit1.jerseyCollar = 0;
              Color color1_1 = Color.FromArgb((int) byte.MaxValue, record2.IntField[FI.cz_teamkits_jerseycolorprimr], record2.IntField[FI.cz_teamkits_jerseycolorprimg], record2.IntField[FI.cz_teamkits_jerseycolorprimb]);
              Color color2_1 = Color.FromArgb((int) byte.MaxValue, record2.IntField[FI.cz_teamkits_jerseycolorsecr], record2.IntField[FI.cz_teamkits_jerseycolorsecg], record2.IntField[FI.cz_teamkits_jerseycolorsecb]);
              Color color3_1 = Color.FromArgb((int) byte.MaxValue, record2.IntField[FI.cz_teamkits_jerseycolortertr], record2.IntField[FI.cz_teamkits_jerseycolortertg], record2.IntField[FI.cz_teamkits_jerseycolortertb]);
              Color color1_2 = Color.FromArgb((int) byte.MaxValue, record2.IntField[FI.cz_teamkits_shortcolorprimr], record2.IntField[FI.cz_teamkits_shortcolorprimg], record2.IntField[FI.cz_teamkits_shortcolorprimb]);
              Color color2_2 = Color.FromArgb((int) byte.MaxValue, record2.IntField[FI.cz_teamkits_shortcolorsecr], record2.IntField[FI.cz_teamkits_shortcolorsecg], record2.IntField[FI.cz_teamkits_shortcolorsecb]);
              Color color3_2 = Color.FromArgb((int) byte.MaxValue, record2.IntField[FI.cz_teamkits_shortcolortertr], record2.IntField[FI.cz_teamkits_shortcolortertg], record2.IntField[FI.cz_teamkits_shortcolortertb]);
              Color color1_3 = Color.FromArgb((int) byte.MaxValue, record2.IntField[FI.cz_teamkits_sockscolorprimr], record2.IntField[FI.cz_teamkits_sockscolorprimg], record2.IntField[FI.cz_teamkits_sockscolorprimb]);
              Color color2_3 = Color.FromArgb((int) byte.MaxValue, record2.IntField[FI.cz_teamkits_sockscolorsecr], record2.IntField[FI.cz_teamkits_sockscolorsecg], record2.IntField[FI.cz_teamkits_sockscolorsecb]);
              Color color3_3 = Color.FromArgb((int) byte.MaxValue, record2.IntField[FI.cz_teamkits_sockscolortertr], record2.IntField[FI.cz_teamkits_sockscolortertg], record2.IntField[FI.cz_teamkits_sockscolortertb]);
              Color color = Color.FromArgb((int) byte.MaxValue, record2.IntField[FI.cz_teamkits_sponsorcolourr], record2.IntField[FI.cz_teamkits_sponsorcolourg], record2.IntField[FI.cz_teamkits_sponsorcolourb]);
              float num1 = record2.FloatField[FI.cz_teamkits_hotspotjerseyfrontsponsorl];
              float num2 = record2.FloatField[FI.cz_teamkits_hotspotjerseyfrontsponsorr];
              float num3 = record2.FloatField[FI.cz_teamkits_hotspotjerseyfrontsponsort];
              float num4 = record2.FloatField[FI.cz_teamkits_hotspotjerseyfrontsponsorb];
              Kit.KitTextureFileName(team.Id, andCheckIntField4, 0);
              Kit kit2 = FifaEnvironment.Kits.GetKit(andCheckIntField2, 0);
              if (kit2 != null)
                kit1.jerseyCollar = kit2.jerseyCollar;
              if (kit2 != null)
              {
                Bitmap miniKit = kit2.GetMiniKit(0);
                string rx3FileName = FifaEnvironment.TempFolder + "\\" + fileName;
                FifaEnvironment.ExportFileFromZdata(fileName, FifaEnvironment.TempFolder);
                kit1.ImportKitTextures(rx3FileName);
                Bitmap[] kitTextures = kit1.GetKitTextures();
                kitTextures[0] = bitmap == null ? (Bitmap) null : (Bitmap) bitmap.Clone();
                GraphicUtil.ColorizeRGB(kitTextures[1], color1_1, color2_1, color3_1, 0, 1024);
                if (miniKit != null)
                {
                  GraphicUtil.PrepareToColorize(miniKit, 25, 231);
                  GraphicUtil.ColorizeRGB(miniKit, color1_1, color2_1, color3_1, 25, 231);
                }
                if (srcBitmap != null && kitTextures[1] != null)
                {
                  Bitmap upperBitmap = color.R != (byte) 225 || color.G != (byte) 225 || color.B != (byte) 225 ? GraphicUtil.ColorizeWhite(srcBitmap, color) : srcBitmap;
                  int x = (int) ((double) num1 * 1024.0);
                  int y = (int) ((double) num3 * 1024.0);
                  int width = (int) ((double) num2 * 1024.0) - x;
                  int height = (int) ((double) num4 * 1024.0) - y;
                  Rectangle destRectangle = new Rectangle(x, y, width, height);
                  kitTextures[1] = GraphicUtil.Overlap(kitTextures[1], upperBitmap, destRectangle);
                }
                GraphicUtil.ColorizeRGB(kitTextures[3], color1_3, color2_3, color3_3, 0, 194);
                GraphicUtil.ColorizeRGB(kitTextures[3], color1_2, color2_2, color3_2, 194, 512);
                kit1.SetKitTextures(kitTextures);
                if (miniKit != null)
                  kit1.SetMiniKit(miniKit);
              }
            }
          }
        }
      }
      if (statusBar == null)
        return;
      statusBar.Text = "Importing complete";
      statusBar.Owner.Refresh();
    }

    public void Import(string xmlFileName, bool useGraphics, ToolStripStatusLabel statusBar)
    {
      DbFile dbFile = new DbFile(FifaEnvironment.TempFolder + "\\" + this.m_UgcDir[0].ToString(), xmlFileName);
      Table table1 = dbFile.GetTable("leagueteamlinks");
      Table table2 = dbFile.GetTable("leagues");
      Table table3 = dbFile.GetTable("stadiumassignments");
      Table table4 = dbFile.GetTable("teamstadiumlinks");
      Table table5 = dbFile.GetTable("teamplayerlinks");
      Table table6 = dbFile.GetTable("formations");
      Table table7 = dbFile.GetTable("teams");
      Table table8 = dbFile.GetTable("editedplayernames");
      Table table9 = dbFile.GetTable("players");
      dbFile.GetTable("cz_leagues");
      Table table10 = dbFile.GetTable("cz_teamkits");
      Table table11 = dbFile.GetTable("cz_teams");
      Table table12 = dbFile.GetTable("cz_players");
      Table table13 = dbFile.GetTable("cz_assets");
      League[] leagueArray = new League[table2.NValidRecords];
      Team[] teamArray = new Team[table7.NValidRecords];
      Player[] playerArray = new Player[table9.NValidRecords];
      if (statusBar != null)
      {
        statusBar.Text = "Importing ...";
        statusBar.Owner.Refresh();
      }
      int[] numArray = new int[256];
      for (int index = 0; index < 256; ++index)
        numArray[index] = 0;
      for (int index = 0; index < table9.NValidRecords; ++index)
      {
        Record record = table9.Records[index];
        ++numArray[record.IntField[FI.players_nationality]];
      }
      int num1 = 0;
      int countryid = 216;
      for (int index = 0; index < 256; ++index)
      {
        if (numArray[index] > num1)
        {
          num1 = numArray[index];
          countryid = index;
        }
      }
      Country country = FifaEnvironment.Countries.SearchCountry(countryid);
      int minId1 = 400;
      for (int index1 = 0; index1 < table2.NValidRecords; ++index1)
      {
        League league = FifaEnvironment.Leagues.FitLeague(table2.Records[index1].StringField[FI.leagues_leaguename], 0);
        int andCheckIntField = table2.Records[index1].GetAndCheckIntField(FI.leagues_leagueid);
        if (league != null && country.Id != 216 && league.Country != country)
          league = (League) null;
        bool flag;
        if (league == null)
        {
          minId1 = FifaEnvironment.Leagues.GetNextId(minId1);
          league = new League(table2.Records[index1]);
          flag = false;
        }
        else
        {
          league.RemoveAllTeams();
          flag = true;
          leagueArray[andCheckIntField - 385] = league;
        }
        if (league.Id >= 385 && league.Id <= 389)
        {
          leagueArray[league.Id - 385] = league;
          league.Id = minId1;
          league.ShortName = league.leaguename.Length <= 15 ? league.leaguename : league.leaguename.Substring(0, 15);
          league.LongName = league.leaguename;
          league.Country = country;
          if (!flag)
            FifaEnvironment.Leagues.InsertId((IdObject) league);
          if (useGraphics)
          {
            for (int index2 = 0; index2 < table13.NValidRecords; ++index2)
            {
              Record record = table13.Records[index2];
              if (record.GetAndCheckIntField(FI.cz_assets_dbid) == 385 + index1)
              {
                string str = FifaEnvironment.TempFolder + "\\" + record.GetAndCheckIntField(FI.cz_assets_crestid).ToString() + ".png";
                if (File.Exists(str))
                {
                  Bitmap srcBitmap = new Bitmap(str);
                  Bitmap bitmap1 = new Bitmap(256, 256, PixelFormat.Format32bppPArgb);
                  Bitmap bitmap2 = new Bitmap(256, 256, PixelFormat.Format32bppPArgb);
                  Bitmap bitmap3 = new Bitmap(256, 64, PixelFormat.Format32bppPArgb);
                  Rectangle srcRect = new Rectangle(0, 0, 128, 128);
                  Rectangle destRect1 = new Rectangle(32, 32, 192, 192);
                  Rectangle destRect2 = new Rectangle(25, 0, 150, 150);
                  Rectangle destRect3 = new Rectangle(145, 4, 56, 56);
                  GraphicUtil.RemapRectangle(srcBitmap, srcRect, bitmap1, destRect1);
                  GraphicUtil.RemapRectangle(srcBitmap, srcRect, bitmap2, destRect2);
                  GraphicUtil.RemapRectangle(srcBitmap, srcRect, bitmap3, destRect3);
                  leagueArray[index1].SetAnimLogo(bitmap1);
                  leagueArray[index1].SetAnimLogoDark(bitmap1);
                  leagueArray[index1].SetSmallLogo(bitmap2);
                  leagueArray[index1].SetSmallLogoDark(bitmap2);
                  leagueArray[index1].SetTinyLogo(bitmap3);
                  leagueArray[index1].SetTinyLogoDark(bitmap3);
                  break;
                }
              }
            }
          }
        }
      }
      int minId2 = 130010;
      for (int index1 = 0; index1 < table7.NValidRecords; ++index1)
      {
        Record record1 = table7.Records[index1];
        int andCheckIntField1 = record1.GetAndCheckIntField(FI.teams_assetid);
        int andCheckIntField2 = record1.GetAndCheckIntField(FI.teams_teamid);
        Team team = (Team) null;
        bool flag = false;
        if (andCheckIntField1 != 33554432)
        {
          team = (Team) FifaEnvironment.Teams.SearchId(andCheckIntField1);
          if (team != null)
          {
            team.Roster.ResetToEmpty();
            flag = true;
          }
        }
        if (team == null)
        {
          team = FifaEnvironment.Teams.FitTeam(record1.StringField[FI.teams_teamname], 0);
          if (team != null && country.Id != 216 && team.Country != country)
            team = (Team) null;
          team?.Roster.ResetToEmpty();
          flag = team != null;
        }
        if (team == null)
        {
          minId2 = FifaEnvironment.Teams.GetNextId(minId2);
          team = new Team(table7.Records[index1]);
          team.Id = minId2;
          team.Country = country;
          FifaEnvironment.Teams.InsertId((IdObject) team);
        }
        if (statusBar != null)
        {
          statusBar.Text = "Importing Team: " + team.DatabaseName;
          statusBar.Owner.Refresh();
        }
        teamArray[index1] = team;
        team.assetid = andCheckIntField2;
        team.TeamNameFull = team.DatabaseName;
        team.TeamNameAbbr15 = team.DatabaseName.Length <= 15 ? team.DatabaseName : team.DatabaseName.Substring(0, 15);
        team.TeamNameAbbr10 = team.DatabaseName.Length <= 10 ? team.DatabaseName : team.DatabaseName.Substring(0, 10);
        if (!flag)
        {
          int assetid = teamArray[index1].assetid;
          Bitmap srcBitmap1 = (Bitmap) null;
          Bitmap srcBitmap2 = (Bitmap) null;
          if (useGraphics)
          {
            for (int index2 = 0; index2 < table11.NValidRecords; ++index2)
            {
              Record record2 = table11.Records[index2];
              if (record2.GetAndCheckIntField(FI.cz_teams_teamid) == assetid)
              {
                int andCheckIntField3 = record2.GetAndCheckIntField(FI.cz_teams_hascrestimage);
                int andCheckIntField4 = record2.GetAndCheckIntField(FI.cz_teams_hassponsorimage);
                string str1 = FifaEnvironment.TempFolder + "\\" + andCheckIntField3.ToString() + ".png";
                if (File.Exists(str1))
                {
                  srcBitmap1 = new Bitmap(str1);
                  Rectangle srcRect = new Rectangle(0, 0, 128, 128);
                  Bitmap destBitmap1 = new Bitmap(256, 256, PixelFormat.Format32bppPArgb);
                  Bitmap destBitmap2 = new Bitmap(128, 128, PixelFormat.Format32bppPArgb);
                  Bitmap bitmap1 = new Bitmap(256, 256, PixelFormat.Format32bppPArgb);
                  Bitmap bitmap2 = new Bitmap(64, 64, PixelFormat.Format32bppPArgb);
                  Bitmap bitmap3 = new Bitmap(32, 32, PixelFormat.Format32bppPArgb);
                  Bitmap bitmap4 = new Bitmap(16, 16, PixelFormat.Format32bppPArgb);
                  Rectangle destRect1 = new Rectangle(0, 0, 150, 150);
                  Rectangle destRect2 = new Rectangle(0, 0, 102, 102);
                  Rectangle destRect3 = new Rectangle(0, 0, 256, 256);
                  Rectangle destRect4 = new Rectangle(0, 0, 50, 50);
                  Rectangle destRect5 = new Rectangle(0, 0, 32, 32);
                  Rectangle destRect6 = new Rectangle(0, 0, 16, 16);
                  GraphicUtil.RemapRectangle(srcBitmap1, srcRect, destBitmap1, destRect1);
                  GraphicUtil.RemapRectangle(srcBitmap1, srcRect, destBitmap2, destRect2);
                  GraphicUtil.RemapRectangle(srcBitmap1, srcRect, bitmap1, destRect3);
                  GraphicUtil.RemapRectangle(srcBitmap1, srcRect, bitmap2, destRect4);
                  GraphicUtil.RemapRectangle(srcBitmap1, srcRect, bitmap3, destRect5);
                  GraphicUtil.RemapRectangle(srcBitmap1, srcRect, bitmap4, destRect6);
                  teamArray[index1].SetCrest(bitmap1);
                  teamArray[index1].SetCrest16(bitmap4);
                  teamArray[index1].SetCrest32(bitmap3);
                  teamArray[index1].SetCrest50(bitmap2);
                  teamArray[index1].SetCrestDark(bitmap1);
                  teamArray[index1].SetCrest16Dark(bitmap4);
                  teamArray[index1].SetCrest32Dark(bitmap3);
                  teamArray[index1].SetCrest50Dark(bitmap2);
                }
                string str2 = FifaEnvironment.TempFolder + "\\" + andCheckIntField4.ToString() + ".png";
                if (File.Exists(str2))
                {
                  srcBitmap2 = new Bitmap(str2);
                  break;
                }
                break;
              }
            }
          }
          for (int index2 = 0; index2 < table10.NValidRecords; ++index2)
          {
            Record record2 = table10.Records[index2];
            int andCheckIntField3 = record2.GetAndCheckIntField(FI.cz_teamkits_kitid);
            int andCheckIntField4 = record2.GetAndCheckIntField(FI.cz_teamkits_teamid);
            int andCheckIntField5 = record2.GetAndCheckIntField(FI.cz_teamkits_kittypeid);
            string fileName = Kit.KitTextureFileName(andCheckIntField3, 0, 0);
            if (team.assetid == andCheckIntField4)
            {
              Kit kit1 = new Kit(FifaEnvironment.Kits.GetNewId(), team.Id, andCheckIntField5);
              FifaEnvironment.Kits.Add((object) kit1);
              kit1.LinkTeam(FifaEnvironment.Teams);
              kit1.jerseyBackName = record2.IntField[FI.cz_teamkits_jerseybacknameplacementcode] != 0;
              kit1.jerseyNameFontCase = record2.IntField[FI.cz_teamkits_jerseybacknamefontcase];
              kit1.jerseyNameFont = record2.IntField[FI.cz_teamkits_jerseynamefonttype];
              int red = record2.IntField[FI.cz_teamkits_jerseynamecolorr];
              int green = record2.IntField[FI.cz_teamkits_jerseynamecolorg];
              int blue = record2.IntField[FI.cz_teamkits_jerseynamecolorb];
              kit1.JerseyNameColor = Color.FromArgb((int) byte.MaxValue, red, green, blue);
              kit1.jerseyNameLayout = record2.IntField[FI.cz_teamkits_jerseynamelayouttype];
              kit1.jerseyNumberFont = record2.IntField[FI.cz_teamkits_numberfonttype];
              kit1.jerseyNumberColor = record2.IntField[FI.cz_teamkits_numbercolor];
              kit1.shortsNumberColor = record2.IntField[FI.cz_teamkits_shortsnumbercolor];
              kit1.shortsNumberFont = record2.IntField[FI.cz_teamkits_shortsnumberfonttype];
              kit1.shortsNumber = true;
              kit1.jerseyCollar = 0;
              Color color1_1 = Color.FromArgb((int) byte.MaxValue, record2.IntField[FI.cz_teamkits_jerseycolorprimr], record2.IntField[FI.cz_teamkits_jerseycolorprimg], record2.IntField[FI.cz_teamkits_jerseycolorprimb]);
              kit1.TeamColor1 = color1_1;
              Color color2_1 = Color.FromArgb((int) byte.MaxValue, record2.IntField[FI.cz_teamkits_jerseycolorsecr], record2.IntField[FI.cz_teamkits_jerseycolorsecg], record2.IntField[FI.cz_teamkits_jerseycolorsecb]);
              kit1.TeamColor2 = color2_1;
              Color color3_1 = Color.FromArgb((int) byte.MaxValue, record2.IntField[FI.cz_teamkits_jerseycolortertr], record2.IntField[FI.cz_teamkits_jerseycolortertg], record2.IntField[FI.cz_teamkits_jerseycolortertb]);
              kit1.TeamColor3 = color3_1;
              Color color1_2 = Color.FromArgb((int) byte.MaxValue, record2.IntField[FI.cz_teamkits_shortcolorprimr], record2.IntField[FI.cz_teamkits_shortcolorprimg], record2.IntField[FI.cz_teamkits_shortcolorprimb]);
              Color color2_2 = Color.FromArgb((int) byte.MaxValue, record2.IntField[FI.cz_teamkits_shortcolorsecr], record2.IntField[FI.cz_teamkits_shortcolorsecg], record2.IntField[FI.cz_teamkits_shortcolorsecb]);
              Color color3_2 = Color.FromArgb((int) byte.MaxValue, record2.IntField[FI.cz_teamkits_shortcolortertr], record2.IntField[FI.cz_teamkits_shortcolortertg], record2.IntField[FI.cz_teamkits_shortcolortertb]);
              Color color1_3 = Color.FromArgb((int) byte.MaxValue, record2.IntField[FI.cz_teamkits_sockscolorprimr], record2.IntField[FI.cz_teamkits_sockscolorprimg], record2.IntField[FI.cz_teamkits_sockscolorprimb]);
              Color color2_3 = Color.FromArgb((int) byte.MaxValue, record2.IntField[FI.cz_teamkits_sockscolorsecr], record2.IntField[FI.cz_teamkits_sockscolorsecg], record2.IntField[FI.cz_teamkits_sockscolorsecb]);
              Color color3_3 = Color.FromArgb((int) byte.MaxValue, record2.IntField[FI.cz_teamkits_sockscolortertr], record2.IntField[FI.cz_teamkits_sockscolortertg], record2.IntField[FI.cz_teamkits_sockscolortertb]);
              Color color = Color.FromArgb((int) byte.MaxValue, record2.IntField[FI.cz_teamkits_sponsorcolourr], record2.IntField[FI.cz_teamkits_sponsorcolourg], record2.IntField[FI.cz_teamkits_sponsorcolourb]);
              float num2 = record2.FloatField[FI.cz_teamkits_hotspotjerseyfrontsponsorl];
              float num3 = record2.FloatField[FI.cz_teamkits_hotspotjerseyfrontsponsorr];
              float num4 = record2.FloatField[FI.cz_teamkits_hotspotjerseyfrontsponsort];
              float num5 = record2.FloatField[FI.cz_teamkits_hotspotjerseyfrontsponsorb];
              Kit.KitTextureFileName(team.Id, andCheckIntField5, 0);
              Kit kit2 = FifaEnvironment.Kits.GetKit(andCheckIntField3, 0);
              if (kit2 != null)
                kit1.jerseyCollar = kit2.jerseyCollar;
              if (useGraphics && kit2 != null)
              {
                Bitmap miniKit = kit2.GetMiniKit(0);
                string rx3FileName = FifaEnvironment.TempFolder + "\\" + fileName;
                FifaEnvironment.ExportFileFromZdata(fileName, FifaEnvironment.TempFolder);
                kit1.ImportKitTextures(rx3FileName);
                Bitmap[] kitTextures = kit1.GetKitTextures();
                kitTextures[0] = srcBitmap1 == null ? (Bitmap) null : (Bitmap) srcBitmap1.Clone();
                GraphicUtil.ColorizeRGB(kitTextures[1], color1_1, color2_1, color3_1, 0, 1024);
                if (miniKit != null)
                {
                  GraphicUtil.PrepareToColorize(miniKit, 25, 231);
                  GraphicUtil.ColorizeRGB(miniKit, color1_1, color2_1, color3_1, 25, 231);
                }
                if (srcBitmap2 != null && kitTextures[1] != null)
                {
                  Bitmap upperBitmap = color.R != (byte) 225 || color.G != (byte) 225 || color.B != (byte) 225 ? GraphicUtil.ColorizeWhite(srcBitmap2, color) : srcBitmap2;
                  int x = (int) ((double) num2 * 1024.0);
                  int y = (int) ((double) num4 * 1024.0);
                  int width = (int) ((double) num3 * 1024.0) - x;
                  int height = (int) ((double) num5 * 1024.0) - y;
                  Rectangle destRectangle = new Rectangle(x, y, width, height);
                  kitTextures[1] = GraphicUtil.Overlap(kitTextures[1], upperBitmap, destRectangle);
                }
                GraphicUtil.ColorizeRGB(kitTextures[3], color1_3, color2_3, color3_3, 0, 194);
                GraphicUtil.ColorizeRGB(kitTextures[3], color1_2, color2_2, color3_2, 194, 512);
                kit1.SetKitTextures(kitTextures);
                if (miniKit != null)
                  kit1.SetMiniKit(miniKit);
              }
            }
          }
        }
      }
      for (int index1 = 0; index1 < teamArray.Length; ++index1)
      {
        for (int index2 = 0; index2 < teamArray.Length; ++index2)
        {
          if (teamArray[index1].rivalteam == teamArray[index2].assetid)
          {
            teamArray[index1].RivalTeam = teamArray[index2];
            break;
          }
        }
        if (teamArray[index1].RivalTeam == null)
          teamArray[index1].RivalTeam = (Team) FifaEnvironment.Teams.SearchId(teamArray[index1].rivalteam);
        if (teamArray[index1].RivalTeam == null)
          teamArray[index1].RivalTeam = teamArray[0];
      }
      for (int index1 = 0; index1 < table3.NValidRecords; ++index1)
      {
        Record record = table3.Records[index1];
        int andCheckIntField = record.GetAndCheckIntField(FI.stadiumassignments_teamid);
        for (int index2 = 0; index2 < teamArray.Length; ++index2)
        {
          if (teamArray[index2].assetid == andCheckIntField)
          {
            teamArray[index2].stadiumcustomname = record.GetAndCheckStringField(FI.stadiumassignments_stadiumcustomname);
            break;
          }
        }
      }
      for (int index1 = 0; index1 < table4.NValidRecords; ++index1)
      {
        Record record = table4.Records[index1];
        int andCheckIntField = record.GetAndCheckIntField(FI.teamstadiumlinks_teamid);
        for (int index2 = 0; index2 < teamArray.Length; ++index2)
        {
          if (teamArray[index2].assetid == andCheckIntField)
          {
            teamArray[index2].stadiumid = record.GetAndCheckIntField(FI.teamstadiumlinks_stadiumid);
            teamArray[index2].LinkStadium(FifaEnvironment.Stadiums);
            break;
          }
        }
      }
      for (int index1 = 0; index1 < table11.NValidRecords; ++index1)
      {
        Record record = table11.Records[index1];
        int andCheckIntField = record.GetAndCheckIntField(FI.cz_teams_teamid);
        for (int index2 = 0; index2 < teamArray.Length; ++index2)
        {
          if (teamArray[index2].assetid == andCheckIntField)
          {
            teamArray[index2].TeamNameAbbr3 = record.GetAndCheckStringField(FI.cz_teams_teamabbrev3);
            break;
          }
        }
      }
      for (int index1 = 0; index1 < table6.NValidRecords; ++index1)
      {
        Record record = table6.Records[index1];
        Formation formation1 = new Formation(record);
        Formation formation2 = FifaEnvironment.GenericFormations.GetExactFormation(formation1);
        if (formation2 == null)
        {
          int newId = FifaEnvironment.Formations.GetNewId();
          formation1.Id = newId;
          formation1.teamid = -1;
          FifaEnvironment.Formations.InsertId((IdObject) formation1);
          FifaEnvironment.GenericFormations.InsertId((IdObject) formation1);
          formation2 = formation1;
        }
        int andCheckIntField = record.GetAndCheckIntField(FI.formations_teamid);
        for (int index2 = 0; index2 < teamArray.Length; ++index2)
        {
          if (teamArray[index2].assetid == andCheckIntField)
          {
            teamArray[index2].Formation = formation2;
            teamArray[index2].formationid = formation2.Id;
            break;
          }
        }
      }
      statusBar.Text = "Importing Players ...";
      int minId3 = 230000;
      for (int index1 = 0; index1 < table9.NValidRecords; ++index1)
      {
        Record record1 = table9.Records[index1];
        int andCheckIntField = record1.GetAndCheckIntField(FI.players_playerid);
        int id = 0;
        for (int index2 = 0; index2 < table12.NValidRecords; ++index2)
        {
          Record record2 = table12.Records[index2];
          if (record2.GetAndCheckIntField(FI.cz_players_playerid) == andCheckIntField)
          {
            id = record2.GetAndCheckIntField(FI.cz_players_assetid);
            break;
          }
        }
        Player player = (Player) null;
        bool flag = false;
        if (id != 0)
        {
          player = (Player) FifaEnvironment.Players.SearchId(id);
          if (player != null)
            flag = true;
        }
        if (player == null)
        {
          DateTime date = FifaUtil.ConvertToDate(record1.GetAndCheckIntField(FI.players_birthdate));
          string firstname = (string) null;
          string lastname = (string) null;
          string str1 = (string) null;
          string str2 = (string) null;
          for (int index2 = 0; index2 < table8.NValidRecords; ++index2)
          {
            Record record2 = table8.Records[index2];
            if (record2.IntField[FI.editedplayernames_playerid] == andCheckIntField)
            {
              firstname = record2.GetAndCheckStringField(FI.editedplayernames_firstname);
              lastname = record2.GetAndCheckStringField(FI.editedplayernames_surname);
              str1 = record2.GetAndCheckStringField(FI.editedplayernames_commonname);
              if (str1.Contains(lastname))
                str1 = (string) null;
              str2 = record2.GetAndCheckStringField(FI.editedplayernames_playerjerseyname);
              if (str2 != lastname && str2.Contains(lastname))
              {
                str2 = lastname;
                break;
              }
              break;
            }
          }
          player = FifaEnvironment.Players.FitPlayer(firstname, lastname, date);
          if (player == null)
          {
            if (id != 0)
            {
              player = new Player(table9.Records[index1]);
              player.Id = id;
            }
            else
            {
              minId3 = FifaEnvironment.Players.GetNextId(minId3);
              player = new Player(table9.Records[index1]);
              player.Id = minId3;
            }
            player.firstname = firstname;
            player.lastname = lastname;
            player.commonname = str1;
            player.playerjerseyname = str2;
            FifaEnvironment.Players.InsertId((IdObject) player);
            player.LinkCountry(FifaEnvironment.Countries);
          }
        }
        if (flag)
        {
          foreach (Team playingForTeam in (ArrayList) player.m_PlayingForTeams)
          {
            if (playingForTeam.Id == 111592)
            {
              player.NotPlayFor(playingForTeam);
              break;
            }
          }
        }
        playerArray[index1] = player;
        player.m_assetid = andCheckIntField;
      }
      for (int index1 = 0; index1 < table1.NValidRecords; ++index1)
      {
        Record record = table1.Records[index1];
        int andCheckIntField1 = record.GetAndCheckIntField(FI.leagueteamlinks_leagueid);
        int andCheckIntField2 = record.GetAndCheckIntField(FI.leagueteamlinks_teamid);
        League league = (League) null;
        switch (andCheckIntField1)
        {
          case 384:
            league = League.GetDefaultLeague();
            break;
          case 385:
          case 386:
          case 387:
          case 388:
          case 389:
            league = leagueArray[andCheckIntField1 - 385];
            break;
        }
        if (league != null)
        {
          for (int index2 = 0; index2 < teamArray.Length; ++index2)
          {
            if (teamArray[index2].assetid == andCheckIntField2)
            {
              league.AddTeam(teamArray[index2]);
              break;
            }
          }
        }
      }
      for (int index1 = 0; index1 < table5.NValidRecords; ++index1)
      {
        Record record = table5.Records[index1];
        int andCheckIntField1 = record.GetAndCheckIntField(FI.teamplayerlinks_playerid);
        int andCheckIntField2 = record.GetAndCheckIntField(FI.teamplayerlinks_teamid);
        for (int index2 = 0; index2 < playerArray.Length; ++index2)
        {
          if (playerArray[index2].m_assetid == andCheckIntField1)
          {
            for (int index3 = 0; index3 < teamArray.Length; ++index3)
            {
              if (teamArray[index3].assetid == andCheckIntField2)
              {
                playerArray[index2].PlayFor(teamArray[index3]);
                TeamPlayer teamPlayer = new TeamPlayer(record, playerArray[index2], teamArray[index3]);
                teamArray[index3].Roster.Add((object) teamPlayer);
                if (teamArray[index3].captainid == playerArray[index2].m_assetid)
                {
                  teamArray[index3].PlayerCaptain = playerArray[index2];
                  teamArray[index3].captainid = playerArray[index2].Id;
                }
                if (teamArray[index3].freekicktakerid == playerArray[index2].m_assetid)
                {
                  teamArray[index3].PlayerFreeKick = playerArray[index2];
                  teamArray[index3].freekicktakerid = playerArray[index2].Id;
                }
                if (teamArray[index3].leftcornerkicktakerid == playerArray[index2].m_assetid)
                {
                  teamArray[index3].PlayerLeftCorner = playerArray[index2];
                  teamArray[index3].leftcornerkicktakerid = playerArray[index2].Id;
                }
                if (teamArray[index3].longkicktakerid == playerArray[index2].m_assetid)
                {
                  teamArray[index3].PlayerLongKick = playerArray[index2];
                  teamArray[index3].longkicktakerid = playerArray[index2].Id;
                }
                if (teamArray[index3].penaltytakerid == playerArray[index2].m_assetid)
                {
                  teamArray[index3].PlayerPenalty = playerArray[index2];
                  teamArray[index3].penaltytakerid = playerArray[index2].Id;
                }
                if (teamArray[index3].rightcornerkicktakerid == playerArray[index2].m_assetid)
                {
                  teamArray[index3].PlayerRightCorner = playerArray[index2];
                  teamArray[index3].rightcornerkicktakerid = playerArray[index2].Id;
                  break;
                }
                break;
              }
            }
            break;
          }
        }
      }
      for (int index = 0; index < playerArray.Length; ++index)
        playerArray[index].m_assetid = playerArray[index].Id;
      for (int index = 0; index < teamArray.Length; ++index)
        teamArray[index].assetid = teamArray[index].Id;
      if (statusBar == null)
        return;
      statusBar.Text = "Importing complete";
      statusBar.Owner.Refresh();
    }

    public void ImportPlayers(string xmlFileName, bool useGraphics, ToolStripStatusLabel statusBar)
    {
      DbFile dbFile = new DbFile(FifaEnvironment.TempFolder + "\\" + this.m_UgcDir[0].ToString(), xmlFileName);
      Table table1 = dbFile.GetTable("editedplayernames");
      Table table2 = dbFile.GetTable("players");
      Table table3 = dbFile.GetTable("cz_players");
      dbFile.GetTable("cz_assets");
      Player[] playerArray = new Player[table2.NValidRecords];
      if (statusBar != null)
      {
        statusBar.Text = "Importing ...";
        statusBar.Owner.Refresh();
      }
      int[] numArray = new int[256];
      for (int index = 0; index < 256; ++index)
        numArray[index] = 0;
      for (int index = 0; index < table2.NValidRecords; ++index)
      {
        Record record = table2.Records[index];
        ++numArray[record.IntField[FI.players_nationality]];
      }
      int num = 0;
      int countryid = 216;
      for (int index = 0; index < 256; ++index)
      {
        if (numArray[index] > num)
        {
          num = numArray[index];
          countryid = index;
        }
      }
      FifaEnvironment.Countries.SearchCountry(countryid);
      statusBar.Text = "Importing Players ...";
      int minId = 230000;
      for (int index1 = 0; index1 < table2.NValidRecords; ++index1)
      {
        Record record1 = table2.Records[index1];
        int andCheckIntField = record1.GetAndCheckIntField(FI.players_playerid);
        int id = 0;
        for (int index2 = 0; index2 < table3.NValidRecords; ++index2)
        {
          Record record2 = table3.Records[index2];
          if (record2.GetAndCheckIntField(FI.cz_players_playerid) == andCheckIntField)
          {
            id = record2.GetAndCheckIntField(FI.cz_players_assetid);
            break;
          }
        }
        Player player = (Player) null;
        if (id != 0)
          player = (Player) FifaEnvironment.Players.SearchId(id);
        if (player == null)
        {
          DateTime date = FifaUtil.ConvertToDate(record1.GetAndCheckIntField(FI.players_birthdate));
          string firstname = (string) null;
          string lastname = (string) null;
          string str1 = (string) null;
          string str2 = (string) null;
          for (int index2 = 0; index2 < table1.NValidRecords; ++index2)
          {
            Record record2 = table1.Records[index2];
            if (record2.IntField[FI.editedplayernames_playerid] == andCheckIntField)
            {
              firstname = record2.GetAndCheckStringField(FI.editedplayernames_firstname);
              lastname = record2.GetAndCheckStringField(FI.editedplayernames_surname);
              str1 = record2.GetAndCheckStringField(FI.editedplayernames_commonname);
              if (str1.Contains(lastname))
                str1 = (string) null;
              str2 = record2.GetAndCheckStringField(FI.editedplayernames_playerjerseyname);
              if (str2 != lastname && str2.Contains(lastname))
              {
                str2 = lastname;
                break;
              }
              break;
            }
          }
          player = FifaEnvironment.Players.FitPlayer(firstname, lastname, date);
          if (player == null)
          {
            if (id != 0)
            {
              player = new Player(table2.Records[index1]);
              player.Id = id;
            }
            else
            {
              minId = FifaEnvironment.Players.GetNextId(minId);
              player = new Player(table2.Records[index1]);
              player.Id = minId;
            }
            player.firstname = firstname;
            player.lastname = lastname;
            player.commonname = str1;
            player.playerjerseyname = str2;
            FifaEnvironment.Players.InsertId((IdObject) player);
            player.LinkCountry(FifaEnvironment.Countries);
          }
        }
        playerArray[index1] = player;
        player.m_assetid = andCheckIntField;
      }
      for (int index = 0; index < playerArray.Length; ++index)
        playerArray[index].m_assetid = playerArray[index].Id;
      if (statusBar == null)
        return;
      statusBar.Text = "Importing complete";
      statusBar.Owner.Refresh();
    }

    public void UpdateRosters(
      string xmlFileName,
      bool useKitGraphics,
      ToolStripStatusLabel statusBar)
    {
      DbFile dbFile = new DbFile(FifaEnvironment.TempFolder + "\\" + this.m_UgcDir[0].ToString(), xmlFileName);
      dbFile.GetTable("leagueteamlinks");
      Table table1 = dbFile.GetTable("leagues");
      dbFile.GetTable("stadiumassignments");
      dbFile.GetTable("teamstadiumlinks");
      Table table2 = dbFile.GetTable("teamplayerlinks");
      Table table3 = dbFile.GetTable("formations");
      Table table4 = dbFile.GetTable("teams");
      Table table5 = dbFile.GetTable("editedplayernames");
      Table table6 = dbFile.GetTable("players");
      dbFile.GetTable("cz_leagues");
      dbFile.GetTable("cz_teamkits");
      dbFile.GetTable("cz_teams");
      Table table7 = dbFile.GetTable("cz_players");
      dbFile.GetTable("cz_assets");
      int nvalidRecords = table1.NValidRecords;
      Team[] teamArray = new Team[table4.NValidRecords];
      Player[] playerArray = new Player[table6.NValidRecords];
      if (statusBar != null)
      {
        statusBar.Text = "Updating ...";
        statusBar.Owner.Refresh();
      }
      int[] numArray = new int[256];
      for (int index = 0; index < 256; ++index)
        numArray[index] = 0;
      for (int index = 0; index < table6.NValidRecords; ++index)
      {
        Record record = table6.Records[index];
        ++numArray[record.IntField[FI.players_nationality]];
      }
      int num1 = 0;
      int countryid = 216;
      for (int index = 0; index < 256; ++index)
      {
        if (numArray[index] > num1)
        {
          num1 = numArray[index];
          countryid = index;
        }
      }
      Country country = FifaEnvironment.Countries.SearchCountry(countryid);
      int num2 = 0;
      for (int index = 0; index < table4.NValidRecords; ++index)
      {
        Record record = table4.Records[index];
        int andCheckIntField1 = record.GetAndCheckIntField(FI.teams_assetid);
        int andCheckIntField2 = record.GetAndCheckIntField(FI.teams_teamid);
        Team team = (Team) null;
        if (andCheckIntField1 != 33554432)
        {
          team = (Team) FifaEnvironment.Teams.SearchId(andCheckIntField1);
          team?.Roster.ResetToEmpty();
        }
        if (team == null)
        {
          team = FifaEnvironment.Teams.FitTeam(record.StringField[FI.teams_teamname], 0);
          if (team != null && country.Id != 216 && team.Country != country)
            team = (Team) null;
          team?.Roster.ResetToEmpty();
        }
        if (team != null)
        {
          teamArray[num2++] = team;
          team.assetid = andCheckIntField2;
        }
      }
      for (int index1 = 0; index1 < table3.NValidRecords; ++index1)
      {
        Record record = table3.Records[index1];
        int andCheckIntField = record.GetAndCheckIntField(FI.formations_teamid);
        for (int index2 = 0; index2 < num2; ++index2)
        {
          if (teamArray[index2].assetid == andCheckIntField)
          {
            Formation formation1 = new Formation(record);
            Formation formation2 = FifaEnvironment.GenericFormations.GetExactFormation(formation1);
            if (formation2 == null)
            {
              int newId = FifaEnvironment.Formations.GetNewId();
              formation1.Id = newId;
              formation1.teamid = -1;
              FifaEnvironment.Formations.InsertId((IdObject) formation1);
              FifaEnvironment.GenericFormations.InsertId((IdObject) formation1);
              formation2 = formation1;
            }
            teamArray[index2].Formation = formation2;
            teamArray[index2].formationid = formation2.Id;
            break;
          }
        }
      }
      statusBar.Text = "Updating Players ...";
      int minId = 230000;
      int num3 = 0;
      for (int index1 = 0; index1 < table6.NValidRecords; ++index1)
      {
        Record record1 = table6.Records[index1];
        int andCheckIntField1 = record1.GetAndCheckIntField(FI.players_playerid);
        bool flag = false;
        for (int index2 = 0; index2 < table2.NValidRecords; ++index2)
        {
          Record record2 = table2.Records[index2];
          if (andCheckIntField1 == record2.GetAndCheckIntField(FI.teamplayerlinks_playerid))
          {
            int andCheckIntField2 = record2.GetAndCheckIntField(FI.teamplayerlinks_teamid);
            for (int index3 = 0; index3 < num2; ++index3)
            {
              if (teamArray[index3].assetid == andCheckIntField2)
              {
                flag = true;
                break;
              }
            }
            break;
          }
        }
        if (flag)
        {
          DateTime date = FifaUtil.ConvertToDate(record1.GetAndCheckIntField(FI.players_birthdate));
          string firstname = (string) null;
          string lastname = (string) null;
          string str1 = (string) null;
          string str2 = (string) null;
          int id = 0;
          for (int index2 = 0; index2 < table7.NValidRecords; ++index2)
          {
            Record record2 = table7.Records[index2];
            if (record2.GetAndCheckIntField(FI.cz_players_playerid) == andCheckIntField1)
            {
              id = record2.GetAndCheckIntField(FI.cz_players_assetid);
              break;
            }
          }
          Player player = (Player) null;
          if (id != 0)
            player = (Player) FifaEnvironment.Players.SearchId(id);
          if (player == null)
          {
            for (int index2 = 0; index2 < table5.NValidRecords; ++index2)
            {
              Record record2 = table5.Records[index2];
              if (record2.IntField[FI.editedplayernames_playerid] == andCheckIntField1)
              {
                firstname = record2.GetAndCheckStringField(FI.editedplayernames_firstname);
                lastname = record2.GetAndCheckStringField(FI.editedplayernames_surname);
                str1 = record2.GetAndCheckStringField(FI.editedplayernames_commonname);
                if (str1.Contains(lastname))
                  str1 = (string) null;
                str2 = record2.GetAndCheckStringField(FI.editedplayernames_playerjerseyname);
                if (str2 != lastname && str2.Contains(lastname))
                {
                  str2 = lastname;
                  break;
                }
                break;
              }
            }
            player = FifaEnvironment.Players.FitPlayer(firstname, lastname, date);
            if (player == null)
            {
              minId = FifaEnvironment.Players.GetNextId(minId);
              player = new Player(table6.Records[index1]);
              player.Id = minId;
              player.firstname = firstname;
              player.lastname = lastname;
              player.commonname = str1;
              player.playerjerseyname = str2;
              FifaEnvironment.Players.InsertId((IdObject) player);
              player.LinkCountry(FifaEnvironment.Countries);
            }
          }
          playerArray[num3++] = player;
          player.m_assetid = andCheckIntField1;
        }
      }
      for (int index1 = 0; index1 < table2.NValidRecords; ++index1)
      {
        Record record = table2.Records[index1];
        int andCheckIntField1 = record.GetAndCheckIntField(FI.teamplayerlinks_playerid);
        int andCheckIntField2 = record.GetAndCheckIntField(FI.teamplayerlinks_teamid);
        for (int index2 = 0; index2 < num3; ++index2)
        {
          if (playerArray[index2].m_assetid == andCheckIntField1)
          {
            for (int index3 = 0; index3 < num2; ++index3)
            {
              if (teamArray[index3].assetid == andCheckIntField2)
              {
                playerArray[index2].PlayFor(teamArray[index3]);
                TeamPlayer teamPlayer = new TeamPlayer(record, playerArray[index2], teamArray[index3]);
                teamArray[index3].Roster.Add((object) teamPlayer);
                if (teamArray[index3].captainid == playerArray[index2].m_assetid)
                {
                  teamArray[index3].PlayerCaptain = playerArray[index2];
                  teamArray[index3].captainid = playerArray[index2].Id;
                }
                if (teamArray[index3].freekicktakerid == playerArray[index2].m_assetid)
                {
                  teamArray[index3].PlayerFreeKick = playerArray[index2];
                  teamArray[index3].freekicktakerid = playerArray[index2].Id;
                }
                if (teamArray[index3].leftfreekicktakerid == playerArray[index2].m_assetid)
                {
                  teamArray[index3].PlayerLeftFreeKick = playerArray[index2];
                  teamArray[index3].leftfreekicktakerid = playerArray[index2].Id;
                }
                if (teamArray[index3].rightfreekicktakerid == playerArray[index2].m_assetid)
                {
                  teamArray[index3].PlayerRightFreeKick = playerArray[index2];
                  teamArray[index3].rightfreekicktakerid = playerArray[index2].Id;
                }
                if (teamArray[index3].leftcornerkicktakerid == playerArray[index2].m_assetid)
                {
                  teamArray[index3].PlayerLeftCorner = playerArray[index2];
                  teamArray[index3].leftcornerkicktakerid = playerArray[index2].Id;
                }
                if (teamArray[index3].longkicktakerid == playerArray[index2].m_assetid)
                {
                  teamArray[index3].PlayerLongKick = playerArray[index2];
                  teamArray[index3].longkicktakerid = playerArray[index2].Id;
                }
                if (teamArray[index3].penaltytakerid == playerArray[index2].m_assetid)
                {
                  teamArray[index3].PlayerPenalty = playerArray[index2];
                  teamArray[index3].penaltytakerid = playerArray[index2].Id;
                }
                if (teamArray[index3].rightcornerkicktakerid == playerArray[index2].m_assetid)
                {
                  teamArray[index3].PlayerRightCorner = playerArray[index2];
                  teamArray[index3].rightcornerkicktakerid = playerArray[index2].Id;
                  break;
                }
                break;
              }
            }
            break;
          }
        }
      }
      for (int index = 0; index < playerArray.Length; ++index)
        playerArray[index].m_assetid = playerArray[index].Id;
      for (int index = 0; index < teamArray.Length; ++index)
        teamArray[index].assetid = teamArray[index].Id;
      if (statusBar == null)
        return;
      statusBar.Text = "Update complete";
      statusBar.Owner.Refresh();
    }
  }
}
