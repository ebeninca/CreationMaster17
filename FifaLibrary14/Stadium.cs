// Original code created by Rinaldo

using System.Drawing;
using System.IO;

namespace FifaLibrary
{
  public class Stadium : IdObject
  {
    private int[] m_timeofday = new int[4];
    private int[] m_todweather = new int[4];
    private string m_name;
    private int m_countrycode;
    private Country m_Country;
    private int m_policetypecode;
    private int m_sectionfacedbydefault;
    private int m_hometeamid;
    private Team m_HomeTeam;
    private int m_capacity;
    private int m_yearbuilt;
    private int m_seatcolor;
    private int m_stadiumtype;
    private int m_stadiumgoalnetstyle;
    private int m_stadiumgloalnetdepth;
    private int m_stadiumgoalnetlength;
    private int m_stadiumgoalnetwidth;
    private int m_stadiummowpattern_code;
    private int m_stadiumpitchlength;
    private int m_stadiumpitchwidth;
    private int m_adboardendlinedistance;
    private int m_adboardsidelinedistance;
    private int m_adboardtype;
    private int m_dlc;
    private int m_stadiumgoalnettype;
    private int m_stadiumgoalnetpattern;
    private int m_stadiumgoalnettension;
    private int m_cameraheight;
    private int m_camerazoom;
    private string m_LocalName;
    private int m_managerhometopleftx;
    private int m_managerhometoplefty;
    private int m_managerhomebotrightx;
    private int m_managerhomebotrighty;
    private int m_managerawaytoplefty;
    private int m_managerawaytopleftx;
    private int m_managerawaybotrightx;
    private int m_managerawaybotrighty;
    private int m_subshometopleftx;
    private int m_subshometoplefty;
    private int m_subshomebotrightx;
    private int m_subshomebotrighty;
    private int m_subsawaytopleftx;
    private int m_subsawaytoplefty;
    private int m_subsawaybotrightx;
    private int m_subsawaybotrighty;
    private int m_upgradetier;
    private int m_upgradestyle;
    private int m_iseditable;
    private int m_isdynamic;
    private int m_genericrank;

    public string name
    {
      get
      {
        return this.m_name;
      }
      set
      {
        this.m_name = value;
      }
    }

    public int countrycode
    {
      get
      {
        return this.m_countrycode;
      }
      set
      {
        this.m_countrycode = value;
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
        this.m_Country = value;
        if (this.m_Country != null)
          this.m_countrycode = this.m_Country.Id;
        else
          this.m_countrycode = 0;
      }
    }

    public int policetypecode
    {
      get
      {
        return this.m_policetypecode;
      }
      set
      {
        this.m_policetypecode = value;
      }
    }

    public int sectionfacedbydefault
    {
      get
      {
        return this.m_sectionfacedbydefault;
      }
      set
      {
        this.m_sectionfacedbydefault = value;
      }
    }

    public int hometeamid
    {
      get
      {
        return this.m_hometeamid;
      }
      set
      {
        this.m_hometeamid = value;
      }
    }

    public Team HomeTeam
    {
      get
      {
        return this.m_HomeTeam;
      }
      set
      {
        this.m_HomeTeam = value;
        if (this.m_HomeTeam != null)
          this.m_hometeamid = this.m_HomeTeam.Id;
        else
          this.m_hometeamid = 0;
      }
    }

    public int capacity
    {
      get
      {
        return this.m_capacity;
      }
      set
      {
        this.m_capacity = value;
      }
    }

    public int yearbuilt
    {
      get
      {
        return this.m_yearbuilt;
      }
      set
      {
        this.m_yearbuilt = value;
      }
    }

    public int seatcolor
    {
      get
      {
        return this.m_seatcolor;
      }
      set
      {
        this.m_seatcolor = value;
      }
    }

    public int stadiumtype
    {
      get
      {
        return this.m_stadiumtype;
      }
      set
      {
        this.m_stadiumtype = value;
      }
    }

    public int NetColor
    {
      get
      {
        return this.m_stadiumgoalnetstyle;
      }
      set
      {
        this.m_stadiumgoalnetstyle = value;
      }
    }

    public bool IsDeepNet
    {
      get
      {
        return this.m_stadiumgloalnetdepth == 320;
      }
      set
      {
        this.m_stadiumgloalnetdepth = value ? 320 : 229;
      }
    }

    public int MowingPatternId
    {
      get
      {
        return this.m_stadiummowpattern_code;
      }
      set
      {
        this.m_stadiummowpattern_code = value;
      }
    }

    public int adboardendlinedistance
    {
      get
      {
        return this.m_adboardendlinedistance;
      }
      set
      {
        this.m_adboardendlinedistance = value;
      }
    }

    public int adboardsidelinedistance
    {
      get
      {
        return this.m_adboardsidelinedistance;
      }
      set
      {
        this.m_adboardsidelinedistance = value;
      }
    }

    public int adboardtype
    {
      get
      {
        return this.m_adboardtype;
      }
      set
      {
        this.m_adboardtype = value;
      }
    }

    public bool HasCloudyDay()
    {
      for (int index = 0; index < 4; ++index)
      {
        if (this.m_timeofday[index] == 0)
          return true;
      }
      return false;
    }

    public void SetCloudyDay(bool enable)
    {
      this.SetTimeOfDay(enable, this.HasSunnyDay(), this.HasNight(), this.HasSunset());
    }

    public void SetSunnyDay(bool enable)
    {
      this.SetTimeOfDay(this.HasCloudyDay(), enable, this.HasNight(), this.HasSunset());
    }

    public void SetNight(bool enable)
    {
      this.SetTimeOfDay(this.HasCloudyDay(), this.HasSunnyDay(), enable, this.HasSunset());
    }

    public void SetSunset(bool enable)
    {
      this.SetTimeOfDay(this.HasCloudyDay(), this.HasSunnyDay(), this.HasNight(), enable);
    }

    private void SetTimeOfDay(bool hasCloudyDay, bool hasSunnyDay, bool hasNight, bool hasSunset)
    {
      int num = this.GetWeather();
      if (num == 2)
        num = 3;
      int index1 = 0;
      if (hasCloudyDay)
      {
        this.m_timeofday[index1] = 0;
        this.m_todweather[index1] = num;
        ++index1;
      }
      if (hasSunnyDay)
      {
        this.m_timeofday[index1] = 1;
        this.m_todweather[index1] = 0;
        ++index1;
      }
      if (hasNight)
      {
        this.m_timeofday[index1] = 3;
        this.m_todweather[index1] = num;
        ++index1;
      }
      if (hasSunset)
      {
        this.m_timeofday[index1] = 4;
        this.m_todweather[index1] = 0;
        ++index1;
      }
      for (int index2 = index1; index2 < 4; ++index2)
      {
        this.m_timeofday[index2] = 5;
        this.m_todweather[index2] = 0;
      }
    }

    public bool HasSunnyDay()
    {
      for (int index = 0; index < 4; ++index)
      {
        if (this.m_timeofday[index] == 1)
          return true;
      }
      return false;
    }

    public bool HasNight()
    {
      for (int index = 0; index < 4; ++index)
      {
        if (this.m_timeofday[index] == 3)
          return true;
      }
      return false;
    }

    public bool HasSunset()
    {
      for (int index = 0; index < 4; ++index)
      {
        if (this.m_timeofday[index] == 4)
          return true;
      }
      return false;
    }

    public int GetWeather()
    {
      int num = 0;
      for (int index = 0; index < 4; ++index)
      {
        if (this.m_todweather[index] != 5 && this.m_todweather[index] > num)
          num = this.m_todweather[index];
      }
      if (num == 3)
        num = 2;
      return num;
    }

    public void SetWeather(int weather)
    {
      if (weather == 2)
        weather = 3;
      for (int index = 0; index < 4; ++index)
        this.m_todweather[index] = this.m_timeofday[index] == 1 || this.m_timeofday[index] == 3 ? weather : 0;
    }

    public int stadiumgoalnettype
    {
      get
      {
        return this.m_stadiumgoalnettype;
      }
      set
      {
        this.m_stadiumgoalnettype = value;
      }
    }

    public int stadiumgoalnetpattern
    {
      get
      {
        return this.m_stadiumgoalnetpattern;
      }
      set
      {
        this.m_stadiumgoalnetpattern = value;
      }
    }

    public int stadiumgoalnettension
    {
      get
      {
        return this.m_stadiumgoalnettension;
      }
      set
      {
        this.m_stadiumgoalnettension = value;
      }
    }

    public int cameraheight
    {
      get
      {
        return this.m_cameraheight;
      }
      set
      {
        this.m_cameraheight = value;
      }
    }

    public int camerazoom
    {
      get
      {
        return this.m_camerazoom;
      }
      set
      {
        this.m_camerazoom = value;
      }
    }

    public string LocalName
    {
      get
      {
        return this.m_LocalName;
      }
      set
      {
        this.m_LocalName = value;
      }
    }

    public Stadium(int stadiumid)
      : base(stadiumid)
    {
      this.m_name = "Stadium " + stadiumid.ToString();
      this.m_LocalName = this.m_name;
      this.m_seatcolor = 1;
      this.m_yearbuilt = 1950;
      this.m_countrycode = 0;
      this.m_policetypecode = 1;
      this.m_sectionfacedbydefault = 0;
      this.m_hometeamid = 0;
      this.m_capacity = 10000;
      this.m_stadiumtype = 0;
      this.m_stadiumgoalnetstyle = 0;
      this.m_stadiumgoalnetpattern = 0;
      this.m_stadiumgloalnetdepth = 229;
      this.m_stadiumgoalnetlength = 250;
      this.m_stadiumgoalnetwidth = 744;
      this.m_stadiummowpattern_code = 0;
      this.m_stadiumpitchlength = 10500;
      this.m_stadiumpitchwidth = 6800;
      this.m_adboardendlinedistance = 500;
      this.m_adboardsidelinedistance = 500;
      this.m_adboardtype = 0;
      for (int index = 0; index < 4; ++index)
      {
        this.m_timeofday[index] = 0;
        this.m_todweather[index] = 0;
      }
      this.m_dlc = 0;
      this.m_stadiumgoalnettype = 0;
      this.m_stadiumgoalnettension = 0;
      this.m_cameraheight = 15;
      this.m_camerazoom = 9;
      this.m_genericrank = -1;
    }

    public Stadium(Record r)
      : base(r.IntField[FI.stadiums_stadiumid])
    {
      this.Load(r);
    }

    public void LinkCountry(CountryList countryList)
    {
      if (countryList == null)
        return;
      if (this.m_countrycode == 0)
      {
        this.m_Country = (Country) null;
      }
      else
      {
        this.m_Country = (Country) countryList.SearchId(this.m_countrycode);
        if (this.m_Country == null)
          this.m_countrycode = 0;
        else
          this.m_countrycode = this.m_Country.Id;
      }
    }

    public void Load(Record r)
    {
      this.m_name = r.StringField[FI.stadiums_name];
      this.m_countrycode = r.GetAndCheckIntField(FI.stadiums_countrycode);
      this.m_hometeamid = r.GetAndCheckIntField(FI.stadiums_hometeamid);
      this.m_HomeTeam = (Team) null;
      this.m_capacity = r.GetAndCheckIntField(FI.stadiums_capacity);
      this.m_policetypecode = r.GetAndCheckIntField(FI.stadiums_policetypecode);
      this.m_seatcolor = r.GetAndCheckIntField(FI.stadiums_seatcolor);
      this.m_sectionfacedbydefault = r.GetAndCheckIntField(FI.stadiums_sectionfacedbydefault);
      this.m_stadiumgoalnetstyle = r.GetAndCheckIntField(FI.stadiums_stadiumgoalnetstyle);
      this.m_stadiumgloalnetdepth = r.GetAndCheckIntField(FI.stadiums_stadiumgloalnetdepth);
      this.m_stadiumgoalnetlength = r.GetAndCheckIntField(FI.stadiums_stadiumgoalnetlength);
      this.m_stadiumgoalnetwidth = r.GetAndCheckIntField(FI.stadiums_stadiumgoalnetwidth);
      this.m_stadiummowpattern_code = r.GetAndCheckIntField(FI.stadiums_stadiummowpattern_code);
      this.m_stadiumpitchlength = r.GetAndCheckIntField(FI.stadiums_stadiumpitchlength);
      this.m_stadiumpitchwidth = r.GetAndCheckIntField(FI.stadiums_stadiumpitchwidth);
      this.m_adboardendlinedistance = r.GetAndCheckIntField(FI.stadiums_adboardendlinedistance);
      this.m_adboardsidelinedistance = r.GetAndCheckIntField(FI.stadiums_adboardsidelinedistance);
      this.m_timeofday[0] = r.GetAndCheckIntField(FI.stadiums_timeofday1);
      this.m_timeofday[1] = r.GetAndCheckIntField(FI.stadiums_timeofday2);
      this.m_timeofday[2] = r.GetAndCheckIntField(FI.stadiums_timeofday3);
      this.m_timeofday[3] = r.GetAndCheckIntField(FI.stadiums_timeofday4);
      this.m_todweather[0] = r.GetAndCheckIntField(FI.stadiums_tod1weather);
      this.m_todweather[1] = r.GetAndCheckIntField(FI.stadiums_tod2weather);
      this.m_todweather[2] = r.GetAndCheckIntField(FI.stadiums_tod3weather);
      this.m_todweather[3] = r.GetAndCheckIntField(FI.stadiums_tod4weather);
      this.m_dlc = r.GetAndCheckIntField(FI.stadiums_dlc);
      this.m_stadiumgoalnettype = r.GetAndCheckIntField(FI.stadiums_stadiumgoalnettype);
      if (FI.stadiums_stadiumgoalnetpattern >= 0)
        this.m_stadiumgoalnetpattern = r.GetAndCheckIntField(FI.stadiums_stadiumgoalnetpattern);
      this.m_stadiumgoalnettension = r.GetAndCheckIntField(FI.stadiums_stadiumgoalnettension);
      this.m_cameraheight = r.GetAndCheckIntField(FI.stadiums_cameraheight);
      this.m_camerazoom = r.GetAndCheckIntField(FI.stadiums_camerazoom);
      this.m_stadiumtype = r.GetAndCheckIntField(FI.stadiums_stadiumtype);
      if (this.m_stadiumtype > 1)
        this.m_stadiumtype = 1;
      this.m_yearbuilt = r.GetAndCheckIntField(FI.stadiums_yearbuilt);
      this.m_LocalName = FifaEnvironment.Language == null ? string.Empty : FifaEnvironment.Language.GetStadiumName(this.Id);
      if (FI.stadiums_managerhometopleftx >= 0)
        this.m_managerhometopleftx = r.GetAndCheckIntField(FI.stadiums_managerhometopleftx);
      if (FI.stadiums_managerhometoplefty >= 0)
        this.m_managerhometoplefty = r.GetAndCheckIntField(FI.stadiums_managerhometoplefty);
      if (FI.stadiums_managerhomebotrightx >= 0)
        this.m_managerhomebotrightx = r.GetAndCheckIntField(FI.stadiums_managerhomebotrightx);
      if (FI.stadiums_managerhomebotrighty >= 0)
        this.m_managerhomebotrighty = r.GetAndCheckIntField(FI.stadiums_managerhomebotrighty);
      if (FI.stadiums_managerawaytoplefty >= 0)
        this.m_managerawaytoplefty = r.GetAndCheckIntField(FI.stadiums_managerawaytoplefty);
      if (FI.stadiums_managerawaytopleftx >= 0)
        this.m_managerawaytopleftx = r.GetAndCheckIntField(FI.stadiums_managerawaytopleftx);
      if (FI.stadiums_managerawaybotrightx >= 0)
        this.m_managerawaybotrightx = r.GetAndCheckIntField(FI.stadiums_managerawaybotrightx);
      if (FI.stadiums_managerawaybotrighty >= 0)
        this.m_managerawaybotrighty = r.GetAndCheckIntField(FI.stadiums_managerawaybotrighty);
      if (FI.stadiums_subshometopleftx >= 0)
        this.m_subshometopleftx = r.GetAndCheckIntField(FI.stadiums_subshometopleftx);
      if (FI.stadiums_subshometoplefty >= 0)
        this.m_subshometoplefty = r.GetAndCheckIntField(FI.stadiums_subshometoplefty);
      if (FI.stadiums_subshomebotrightx >= 0)
        this.m_subshomebotrightx = r.GetAndCheckIntField(FI.stadiums_subshomebotrightx);
      if (FI.stadiums_subshomebotrighty >= 0)
        this.m_subshomebotrighty = r.GetAndCheckIntField(FI.stadiums_subshomebotrighty);
      if (FI.stadiums_subsawaytopleftx >= 0)
        this.m_subsawaytopleftx = r.GetAndCheckIntField(FI.stadiums_subsawaytopleftx);
      if (FI.stadiums_subsawaytoplefty >= 0)
        this.m_subsawaytoplefty = r.GetAndCheckIntField(FI.stadiums_subsawaytoplefty);
      if (FI.stadiums_subsawaybotrightx >= 0)
        this.m_subsawaybotrightx = r.GetAndCheckIntField(FI.stadiums_subsawaybotrightx);
      if (FI.stadiums_subsawaybotrighty >= 0)
        this.m_subsawaybotrighty = r.GetAndCheckIntField(FI.stadiums_subsawaybotrighty);
      this.m_upgradetier = r.GetAndCheckIntField(FI.stadiums_upgradetier);
      this.m_upgradestyle = r.GetAndCheckIntField(FI.stadiums_upgradestyle);
      this.m_iseditable = r.GetAndCheckIntField(FI.stadiums_iseditable);
      this.m_isdynamic = r.GetAndCheckIntField(FI.stadiums_isdynamic);
      this.m_genericrank = r.GetAndCheckIntField(FI.stadiums_genericrank);
    }

    public override string ToString()
    {
      return this.m_name != null && this.m_name != string.Empty ? this.m_name : "Stadium n. " + this.Id.ToString();
    }

    public string DatabaseString()
    {
      return this.m_name;
    }

    public void LinkTeam(TeamList teamList)
    {
      if (teamList == null)
        return;
      this.m_HomeTeam = (Team) teamList.SearchId(this.m_hometeamid);
    }

    public override IdObject Clone(int stadiumid)
    {
      Stadium stadium = (Stadium) base.Clone(stadiumid);
      stadium.m_name = "Stadium " + stadiumid.ToString();
      stadium.m_LocalName = stadium.m_name;
      this.CloneModel(stadiumid);
      this.ClonePreview(stadiumid, 0);
      this.ClonePreview(stadiumid, 1);
      this.ClonePreview(stadiumid, 3);
      this.ClonePreview(stadiumid, 4);
      if (this.HasSunnyDay())
      {
        this.CloneContainer(stadiumid, 1);
        this.CloneCrowd(stadiumid, 1);
      }
      if (this.HasNight())
      {
        this.CloneContainer(stadiumid, 3);
        this.CloneCrowd(stadiumid, 3);
      }
      this.CloneGlares(stadiumid);
      return (IdObject) stadium;
    }

    private void CloneContainer(int newId, int timeofday)
    {
      FifaEnvironment.CloneIntoZdata(this.TexturesFileName(timeofday), Stadium.TexturesFileName(newId, timeofday));
    }

    private void ClonePreview(int newId, int timeofday)
    {
      FifaEnvironment.CloneIntoZdata(Stadium.PreviewBigFileName(this.Id, timeofday), Stadium.PreviewBigFileName(newId, timeofday));
      FifaEnvironment.CloneIntoZdata(Stadium.PreviewLargeBigFileName(this.Id, timeofday), Stadium.PreviewLargeBigFileName(newId, timeofday));
    }

    private void CloneModel(int newId)
    {
      FifaEnvironment.CloneIntoZdata(Stadium.ModelFileName(this.Id), Stadium.ModelFileName(newId));
    }

    public Bitmap GetNet()
    {
      return Net.GetNet(this.m_stadiumgoalnetstyle);
    }

    public bool SetNet(Bitmap bitmap)
    {
      return Net.SetNet(this.m_stadiumgoalnetstyle, bitmap);
    }

    public bool SetNet(string rx3FileName)
    {
      return Net.SetNet(this.m_stadiumgoalnetstyle, rx3FileName);
    }

    public bool DeleteNet()
    {
      return Net.DeleteNet(this.m_stadiumgoalnetstyle);
    }

    public Bitmap GetPolice()
    {
      return this.m_policetypecode == 0 ? (Bitmap) null : Police.GetPolice(this.m_policetypecode, 0);
    }

    public bool SetPolice(Bitmap bitmap)
    {
      if (this.m_policetypecode == 0)
        return false;
      return Police.SetPolice(this.m_policetypecode, 0, bitmap) && Police.SetPolice(this.m_policetypecode, 1, bitmap);
    }

    public bool DeletePolice()
    {
      if (this.m_policetypecode == 0)
        return false;
      return Police.DeletePolice(this.m_policetypecode, 0) && Police.DeletePolice(this.m_policetypecode, 1);
    }

    public Bitmap GetMowingPattern()
    {
      return MowingPattern.GetMowingPattern(this.m_stadiummowpattern_code);
    }

    public bool SetMowingPattern(Bitmap bitmap)
    {
      return MowingPattern.SetMowingPattern(this.m_stadiummowpattern_code, bitmap);
    }

    public bool SetMowingPattern(string rx3FileName)
    {
      return MowingPattern.SetMowingPattern(this.m_stadiummowpattern_code, rx3FileName);
    }

    public bool DeleteMowingPattern()
    {
      return MowingPattern.DeleteMowingPattern(this.m_stadiummowpattern_code);
    }

    public void SaveStadium(Record r)
    {
      r.IntField[FI.stadiums_stadiumid] = this.Id;
      r.StringField[FI.stadiums_name] = this.m_name;
      r.IntField[FI.stadiums_countrycode] = this.m_countrycode;
      r.IntField[FI.stadiums_hometeamid] = this.m_hometeamid;
      r.IntField[FI.stadiums_capacity] = this.m_capacity;
      r.IntField[FI.stadiums_policetypecode] = this.m_policetypecode;
      r.IntField[FI.stadiums_seatcolor] = this.m_seatcolor;
      r.IntField[FI.stadiums_sectionfacedbydefault] = this.m_sectionfacedbydefault;
      r.IntField[FI.stadiums_stadiumgoalnetstyle] = this.m_stadiumgoalnetstyle;
      r.IntField[FI.stadiums_stadiumgloalnetdepth] = this.m_stadiumgloalnetdepth;
      r.IntField[FI.stadiums_stadiumgoalnetlength] = this.m_stadiumgoalnetlength;
      r.IntField[FI.stadiums_stadiumgoalnetwidth] = this.m_stadiumgoalnetwidth;
      r.IntField[FI.stadiums_stadiummowpattern_code] = this.m_stadiummowpattern_code;
      r.IntField[FI.stadiums_stadiumpitchlength] = this.m_stadiumpitchlength;
      r.IntField[FI.stadiums_stadiumpitchwidth] = this.m_stadiumpitchwidth;
      r.IntField[FI.stadiums_adboardendlinedistance] = this.m_adboardendlinedistance;
      r.IntField[FI.stadiums_adboardsidelinedistance] = this.m_adboardsidelinedistance;
      r.IntField[FI.stadiums_timeofday1] = this.m_timeofday[0];
      r.IntField[FI.stadiums_timeofday2] = this.m_timeofday[1];
      r.IntField[FI.stadiums_timeofday3] = this.m_timeofday[2];
      r.IntField[FI.stadiums_timeofday4] = this.m_timeofday[3];
      r.IntField[FI.stadiums_tod1weather] = this.m_todweather[0];
      r.IntField[FI.stadiums_tod2weather] = this.m_todweather[1];
      r.IntField[FI.stadiums_tod3weather] = this.m_todweather[2];
      r.IntField[FI.stadiums_tod4weather] = this.m_todweather[3];
      r.IntField[FI.stadiums_dlc] = this.m_dlc;
      r.IntField[FI.stadiums_stadiumtype] = this.m_stadiumtype;
      r.IntField[FI.stadiums_yearbuilt] = this.m_yearbuilt;
      r.IntField[FI.stadiums_stadiumgoalnettype] = this.m_stadiumgoalnettype;
      if (FI.stadiums_stadiumgoalnetpattern >= 0)
        r.IntField[FI.stadiums_stadiumgoalnetpattern] = this.m_stadiumgoalnetpattern;
      r.IntField[FI.stadiums_stadiumgoalnettension] = this.m_stadiumgoalnettension;
      r.IntField[FI.stadiums_cameraheight] = this.m_cameraheight;
      r.IntField[FI.stadiums_camerazoom] = this.m_camerazoom;
      if (FI.stadiums_managerhometopleftx >= 0)
        r.IntField[FI.stadiums_managerhometopleftx] = this.m_managerhometopleftx;
      if (FI.stadiums_managerhometoplefty >= 0)
        r.IntField[FI.stadiums_managerhometoplefty] = this.m_managerhometoplefty;
      if (FI.stadiums_managerhomebotrightx >= 0)
        r.IntField[FI.stadiums_managerhomebotrightx] = this.m_managerhomebotrightx;
      if (FI.stadiums_managerhomebotrighty >= 0)
        r.IntField[FI.stadiums_managerhomebotrighty] = this.m_managerhomebotrighty;
      if (FI.stadiums_managerawaytoplefty >= 0)
        r.IntField[FI.stadiums_managerawaytoplefty] = this.m_managerawaytoplefty;
      if (FI.stadiums_managerawaytopleftx >= 0)
        r.IntField[FI.stadiums_managerawaytopleftx] = this.m_managerawaytopleftx;
      if (FI.stadiums_managerawaybotrightx >= 0)
        r.IntField[FI.stadiums_managerawaybotrightx] = this.m_managerawaybotrightx;
      if (FI.stadiums_managerawaybotrighty >= 0)
        r.IntField[FI.stadiums_managerawaybotrighty] = this.m_managerawaybotrighty;
      if (FI.stadiums_subshometopleftx >= 0)
        r.IntField[FI.stadiums_subshometopleftx] = this.m_subshometopleftx;
      if (FI.stadiums_subshometoplefty >= 0)
        r.IntField[FI.stadiums_subshometoplefty] = this.m_subshometoplefty;
      if (FI.stadiums_subshomebotrightx >= 0)
        r.IntField[FI.stadiums_subshomebotrightx] = this.m_subshomebotrightx;
      if (FI.stadiums_subshomebotrighty >= 0)
        r.IntField[FI.stadiums_subshomebotrighty] = this.m_subshomebotrighty;
      if (FI.stadiums_subsawaytopleftx >= 0)
        r.IntField[FI.stadiums_subsawaytopleftx] = this.m_subsawaytopleftx;
      if (FI.stadiums_subsawaytoplefty >= 0)
        r.IntField[FI.stadiums_subsawaytoplefty] = this.m_subsawaytoplefty;
      if (FI.stadiums_subsawaybotrightx >= 0)
        r.IntField[FI.stadiums_subsawaybotrightx] = this.m_subsawaybotrightx;
      if (FI.stadiums_subsawaybotrighty >= 0)
        r.IntField[FI.stadiums_subsawaybotrighty] = this.m_subsawaybotrighty;
      r.IntField[FI.stadiums_upgradetier] = this.m_upgradetier;
      r.IntField[FI.stadiums_upgradestyle] = this.m_upgradestyle;
      r.IntField[FI.stadiums_iseditable] = this.m_iseditable;
      r.IntField[FI.stadiums_isdynamic] = this.m_isdynamic;
      r.IntField[FI.stadiums_genericrank] = this.m_genericrank;
      if (FifaEnvironment.Language == null)
        return;
      FifaEnvironment.Language.SetStadiumName(this.Id, this.m_LocalName);
    }

    public void SaveLangTable()
    {
      if (FifaEnvironment.Language == null)
        return;
      FifaEnvironment.Language.SetStadiumName(this.Id, this.m_LocalName);
    }

    public static string PreviewBigFileName(int stadiumid, int timeofday)
    {
      return "data/ui/artassets/stadium/stadium_" + stadiumid.ToString() + "_" + timeofday.ToString() + ".big";
    }

    public string PreviewBigFileName(int timeofday)
    {
      return "data/ui/artassets/stadium/stadium_" + this.Id.ToString() + "_" + timeofday.ToString() + ".big";
    }

    public string PreviewTemplateFileName()
    {
      return FifaEnvironment.Year == 14 ? "data/ui/artassets/stadium/2014_stadium_#_%.big" : "data/ui/artassets/stadium/stadium_#_%.big";
    }

    public string PreviewDdsFileName()
    {
      return "2";
    }

    public Bitmap GetPreview(int timeofday)
    {
      return FifaEnvironment.GetArtasset(this.PreviewBigFileName(timeofday));
    }

    public bool SetPreview(int timeofday, Bitmap bitmap)
    {
      return FifaEnvironment.SetArtasset(this.PreviewTemplateFileName(), this.PreviewDdsFileName(), new int[2]
      {
        this.Id,
        timeofday
      }, bitmap);
    }

    public bool DeletePreview(int timeofday)
    {
      return FifaEnvironment.DeleteFromZdata(this.PreviewBigFileName(timeofday));
    }

    private void CloneTimeOfDayPreview(int newTimeOfDay, int timeofday)
    {
      FifaEnvironment.CloneIntoZdata(this.PreviewBigFileName(timeofday), this.PreviewBigFileName(newTimeOfDay));
    }

    public static string PreviewLargeBigFileName(int stadiumid, int timeofday)
    {
      return "data/ui/artassets/stadiumsbig/st_" + stadiumid.ToString() + "_" + timeofday.ToString() + ".big";
    }

    public string PreviewLargeBigFileName(int timeofday)
    {
      return "data/ui/artassets/stadiumsbig/st_" + this.Id.ToString() + "_" + timeofday.ToString() + ".big";
    }

    public string PreviewLargeTemplateFileName()
    {
      return FifaEnvironment.Year == 14 ? "data/ui/artassets/stadiumsbig/2014_st_#_%.big" : "data/ui/artassets/stadiumsbig/st_#_%.big";
    }

    public string PreviewLargeDdsFileName()
    {
      return "2";
    }

    public Bitmap GetPreviewLarge(int timeofday)
    {
      return FifaEnvironment.GetArtasset(this.PreviewLargeBigFileName(timeofday));
    }

    public bool SetPreviewLarge(int timeofday, Bitmap bitmap)
    {
      return FifaEnvironment.SetArtasset(this.PreviewLargeTemplateFileName(), this.PreviewLargeDdsFileName(), new int[2]
      {
        this.Id,
        timeofday
      }, bitmap);
    }

    public bool DeletePreviewLarge(int timeofday)
    {
      return FifaEnvironment.DeleteFromZdata(this.PreviewLargeBigFileName(timeofday));
    }

    private void CloneTimeOfDayPreviewLarge(int newTimeOfDay, int timeofday)
    {
      FifaEnvironment.CloneIntoZdata(this.PreviewLargeBigFileName(timeofday), this.PreviewLargeBigFileName(newTimeOfDay));
    }

    public static string TexturesFileName(int stadiumid, int timeofday)
    {
      return "data/sceneassets/stadium/stadium_" + stadiumid.ToString() + "_" + timeofday.ToString() + "_textures.rx3";
    }

    public string TexturesFileName(int timeofday)
    {
      return "data/sceneassets/stadium/stadium_" + this.Id.ToString() + "_" + timeofday.ToString() + "_textures.rx3";
    }

    public string TexturesTemplateFileName()
    {
      return "data/sceneassets/stadium/stadium_#_%_textures.rx3";
    }

    public Bitmap[] GetTextures(int timeofday)
    {
      return FifaEnvironment.GetBmpsFromRx3(this.TexturesFileName(timeofday));
    }

    public bool SetTextures(int timeofday, Bitmap[] bitmaps)
    {
      return FifaEnvironment.ImportBmpsIntoStadium(this.TexturesFileName(timeofday), bitmaps);
    }

    public bool SetTextures(int timeofday, string rx3FileName)
    {
      return FifaEnvironment.ImportFileIntoZdataAs(rx3FileName, this.TexturesFileName(timeofday), false, ECompressionMode.Chunkzip);
    }

    public bool DeleteContainer(int timeofday)
    {
      return FifaEnvironment.DeleteFromZdata(this.TexturesFileName(timeofday));
    }

    public static string ModelFileName(int stadiumid)
    {
      return "data/sceneassets/stadium/stadium_" + stadiumid.ToString() + ".rx3";
    }

    public string ModelFileName()
    {
      return "data/sceneassets/stadium/stadium_" + this.Id.ToString() + ".rx3";
    }

    public string ModelTemplateFileName()
    {
      return "data/sceneassets/stadium/stadium_#.rx3";
    }

    public Rx3File GetModel()
    {
      return FifaEnvironment.GetRx3FromZdata(this.ModelFileName());
    }

    public bool SetModel(string rx3FileName)
    {
      return FifaEnvironment.ImportFileIntoZdataAs(rx3FileName, this.ModelFileName(), false, ECompressionMode.Chunkzip);
    }

    public bool DeleteModel(int timeofday)
    {
      return FifaEnvironment.DeleteFromZdata(this.ModelFileName());
    }

    public static string CrowdFileName(int stadiumid, int timeofday)
    {
      return "data/sceneassets/crowdplacement/crowd_" + stadiumid.ToString() + "_" + timeofday.ToString() + ".dat";
    }

    public string CrowdFileName(int timeofday)
    {
      return "data/sceneassets/crowdplacement/crowd_" + this.Id.ToString() + "_" + timeofday.ToString() + ".dat";
    }

    public bool CloneCrowd(int newId, int timeofday)
    {
      return FifaEnvironment.CloneIntoZdata(this.CrowdFileName(timeofday), Stadium.CrowdFileName(newId, timeofday));
    }

    public bool SetCrowd(int timeofday, string datFileName)
    {
      return FifaEnvironment.ImportFileIntoZdataAs(datFileName, this.CrowdFileName(timeofday), false, ECompressionMode.Chunkzip);
    }

    public void CloneTimeOfDayCrowd(int newTimeOfDay, int timeofday)
    {
      FifaEnvironment.CloneIntoZdata(this.CrowdFileName(timeofday), this.CrowdFileName(newTimeOfDay));
    }

    public static string[] GlaresLightFileNames(int stadiumid)
    {
      string[] strArray;
      if (FifaEnvironment.Year == 14)
        strArray = new string[8]
        {
          "data/sceneassets/fx/glares_" + stadiumid.ToString() + "_0.lnx",
          "data/sceneassets/fx/glares_" + stadiumid.ToString() + "_0.rx3",
          "data/sceneassets/fx/glares_" + stadiumid.ToString() + "_1.lnx",
          "data/sceneassets/fx/glares_" + stadiumid.ToString() + "_1.rx3",
          "data/sceneassets/fx/glares_" + stadiumid.ToString() + "_3.lnx",
          "data/sceneassets/fx/glares_" + stadiumid.ToString() + "_3.rx3",
          "data/sceneassets/fx/glares_" + stadiumid.ToString() + "_4.lnx",
          "data/sceneassets/fx/glares_" + stadiumid.ToString() + "_4.rx3"
        };
      else
        strArray = new string[1]
        {
          "data/bcdata/camera/bcgameplay_" + stadiumid.ToString() + ".dat"
        };
      return strArray;
    }

    public string[] GlaresLightFileNames()
    {
      return Stadium.GlaresLightFileNames(this.Id);
    }

    public bool CloneGlares(int newId)
    {
      string[] strArray1 = Stadium.GlaresLightFileNames(this.Id);
      string[] strArray2 = Stadium.GlaresLightFileNames(newId);
      bool flag = true;
      if (strArray1.Length != strArray2.Length)
        return false;
      for (int index = 0; index < strArray1.Length; ++index)
        flag = flag && FifaEnvironment.CloneIntoZdata(strArray1[index], strArray2[index]);
      return flag;
    }

    public bool SetGlaresLight(string[] sourceFileNames)
    {
      string[] strArray = Stadium.GlaresLightFileNames(this.Id);
      bool flag = true;
      if (sourceFileNames.Length != strArray.Length)
        return false;
      for (int index = 0; index < sourceFileNames.Length; ++index)
        flag = File.Exists(sourceFileNames[index]) && (flag && FifaEnvironment.ImportFileIntoZdataAs(sourceFileNames[index], strArray[index], false, ECompressionMode.Chunkzip));
      return flag;
    }

    public enum ETimeOfDay
    {
      Cloudy = 0,
      Sunny = 1,
      Night = 3,
      Sunset = 4,
    }

    public enum EWeather
    {
      Dry = 0,
      CanRain = 1,
      CanSnow = 3,
    }
  }
}
