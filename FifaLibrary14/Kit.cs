// Original code created by Rinaldo

using System.Drawing;

namespace FifaLibrary
{
  public class Kit : IdObject
  {
    public static Bitmap s_JerseyWrinkle = (Bitmap) null;
    public static Bitmap s_ShortsWrinkle = (Bitmap) null;
    public static Model3D[] s_JerseyModel3D = new Model3D[16];
    public static Model3D s_ShortsModel3D = (Model3D) null;
    public static Model3D s_SocksModel3D = (Model3D) null;
    private static Bitmap s_JerseyShadow = (Bitmap) null;
    private static Bitmap s_ShortsShadow = (Bitmap) null;
    private float[] m_Positions = new float[32];
    private Bitmap[] m_KitTextures;
    private bool m_hasadvertisingkit;
    private bool m_jerseybacknameplacementcode;
    private bool m_jerseyfrontnumberplacementcode;
    private bool m_shortsnumberplacementcode;
    private int m_jerseycollargeometrytype;
    private int m_jerseybacknamefontcase;
    private int m_jerseynamefonttype;
    private int m_numberfonttype;
    private int m_numbercolor;
    private int m_shortsnumberfonttype;
    private int m_shortsnumbercolor;
    private int m_jerseynamecolorr;
    private int m_jerseynamecolorg;
    private int m_jerseynamecolorb;
    private Color m_JerseyNameColor;
    private int m_teamcolorprimr;
    private int m_teamcolorprimg;
    private int m_teamcolorprimb;
    private int m_teamcolorsecr;
    private int m_teamcolorsecg;
    private int m_teamcolorsecb;
    private int m_teamcolortertr;
    private int m_teamcolortertg;
    private int m_teamcolortertb;
    private Color m_TeamColor1;
    private Color m_TeamColor2;
    private Color m_TeamColor3;
    private int m_jerseynamelayouttype;
    private int m_isinheritbasedetailmap;
    private int m_jerseyshapestyle;
    private int m_jerseyrenderingdetailmaptype;
    private int m_renderingmaterialtype;
    private int m_shortsrenderingdetailmaptype;
    private int m_dlc;
    private bool m_jerseyfit;
    private int m_year;
    private int m_powid;
    private int m_islocked;
    private int m_teamid;
    private int m_kittype;
    private Team m_Team;

    public float[] Positions
    {
      get
      {
        return this.m_Positions;
      }
      set
      {
        this.m_Positions = value;
      }
    }

    public bool hasadvertisingkit
    {
      get
      {
        return this.m_hasadvertisingkit;
      }
      set
      {
        this.m_hasadvertisingkit = value;
      }
    }

    public bool jerseyBackName
    {
      get
      {
        return this.m_jerseybacknameplacementcode;
      }
      set
      {
        this.m_jerseybacknameplacementcode = value;
      }
    }

    public bool jerseyFrontNumber
    {
      get
      {
        return this.m_jerseyfrontnumberplacementcode;
      }
      set
      {
        this.m_jerseyfrontnumberplacementcode = value;
      }
    }

    public bool shortsNumber
    {
      get
      {
        return this.m_shortsnumberplacementcode;
      }
      set
      {
        this.m_shortsnumberplacementcode = value;
      }
    }

    public int jerseyCollar
    {
      get
      {
        return this.m_jerseycollargeometrytype;
      }
      set
      {
        this.m_jerseycollargeometrytype = value;
      }
    }

    public int jerseyNameFontCase
    {
      get
      {
        return this.m_jerseybacknamefontcase;
      }
      set
      {
        this.m_jerseybacknamefontcase = value;
      }
    }

    public int jerseyNameFont
    {
      get
      {
        return this.m_jerseynamefonttype;
      }
      set
      {
        this.m_jerseynamefonttype = value;
      }
    }

    public int jerseyNumberFont
    {
      get
      {
        return this.m_numberfonttype;
      }
      set
      {
        this.m_numberfonttype = value;
      }
    }

    public int jerseyNumberColor
    {
      get
      {
        return this.m_numbercolor;
      }
      set
      {
        this.m_numbercolor = value;
      }
    }

    public int shortsNumberFont
    {
      get
      {
        return this.m_shortsnumberfonttype;
      }
      set
      {
        this.m_shortsnumberfonttype = value;
      }
    }

    public int shortsNumberColor
    {
      get
      {
        return this.m_shortsnumbercolor;
      }
      set
      {
        this.m_shortsnumbercolor = value;
      }
    }

    public Color JerseyNameColor
    {
      get
      {
        return this.m_JerseyNameColor;
      }
      set
      {
        this.m_JerseyNameColor = value;
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

    public int jerseyNameLayout
    {
      get
      {
        return this.m_jerseynamelayouttype;
      }
      set
      {
        this.m_jerseynamelayouttype = value;
      }
    }

    public bool jerseyfit
    {
      get
      {
        return this.m_jerseyfit;
      }
      set
      {
        this.m_jerseyfit = value;
      }
    }

    public int year
    {
      get
      {
        return this.m_year;
      }
      set
      {
        this.m_year = value;
      }
    }

    public int teamid
    {
      get
      {
        return this.m_teamid;
      }
      set
      {
        this.m_teamid = value;
      }
    }

    public int kittype
    {
      get
      {
        return this.m_kittype;
      }
      set
      {
        this.m_kittype = value;
      }
    }

    public Team Team
    {
      get
      {
        return this.m_Team;
      }
      set
      {
        this.m_Team = value;
        if (this.m_Team == null)
          return;
        this.m_teamid = this.Team.Id;
      }
    }

    public Kit(int kitid, int teamid, int kittype)
    {
      this.m_teamid = teamid;
      this.m_kittype = kittype;
      this.Id = kitid;
      this.InitNewKit();
    }

    public Kit(int kitid)
    {
      this.m_teamid = 0;
      this.m_kittype = 0;
      this.Id = kitid;
      this.InitNewKit();
    }

    public Kit(Record r)
    {
      this.Load(r);
    }

    public static void Prepare3DModels()
    {
      if (Kit.s_JerseyWrinkle != null)
        return;
      Kit.s_JerseyWrinkle = new Bitmap(FifaEnvironment.LaunchDir + "\\Templates\\JerseyBump0.png");
      Kit.s_ShortsWrinkle = new Bitmap(FifaEnvironment.LaunchDir + "\\Templates\\ShortsBump.png");
      for (int index = 0; index < Kit.s_JerseyModel3D.Length; ++index)
      {
        Rx3File rx3FromZdata = FifaEnvironment.GetRx3FromZdata("data/sceneassets/body/jersey_1_" + index.ToString() + "_0_0_0_0.rx3");
        Kit.s_JerseyModel3D[index] = new Model3D(rx3FromZdata.Rx3IndexArrays[0], rx3FromZdata.Rx3VertexArrays[0], (Bitmap) null);
      }
      Rx3File rx3FromZdata1 = FifaEnvironment.GetRx3FromZdata("data/sceneassets/body/shorts_1_0.rx3");
      Kit.s_ShortsModel3D = new Model3D(rx3FromZdata1.Rx3IndexArrays[0], rx3FromZdata1.Rx3VertexArrays[0], (Bitmap) null);
      Rx3File rx3FromZdata2 = FifaEnvironment.GetRx3FromZdata("data/sceneassets/body/sock_1_0.rx3");
      Kit.s_SocksModel3D = new Model3D(rx3FromZdata2.Rx3IndexArrays[0], rx3FromZdata2.Rx3VertexArrays[0], (Bitmap) null);
    }

    public override string ToString()
    {
      string str1 = this.m_Team == null ? "Kit " + this.m_teamid.ToString() : this.m_Team.DatabaseName;
      string empty = string.Empty;
      string str2;
      switch (this.m_kittype)
      {
        case 0:
          str2 = " Home";
          break;
        case 1:
          str2 = " Away";
          break;
        case 2:
          str2 = " GK";
          break;
        case 3:
          str2 = " Third";
          break;
        case 5:
          str2 = " Referee";
          break;
        case 6:
          str2 = " Training";
          break;
        case 7:
          str2 = " Training";
          break;
        default:
          str2 = " Type" + this.m_kittype.ToString();
          break;
      }
      string str3 = str1 + str2;
      if (this.m_year != 0)
        str3 = str3 + " " + this.year.ToString();
      return str3 + " (" + this.Id.ToString() + ")";
    }

    public static int KitId(int teamid, int kittype)
    {
      return teamid * 10 + kittype;
    }

    public void InitNewKit()
    {
      this.m_hasadvertisingkit = true;
      this.m_jerseybacknameplacementcode = true;
      this.m_jerseyfrontnumberplacementcode = false;
      this.m_shortsnumberplacementcode = false;
      this.m_jerseycollargeometrytype = 0;
      this.m_jerseybacknamefontcase = 0;
      this.m_jerseynamefonttype = 0;
      this.m_numberfonttype = 0;
      this.m_numbercolor = 0;
      this.m_shortsnumberfonttype = 0;
      this.m_shortsnumbercolor = 0;
      this.m_jerseynamecolorr = 0;
      this.m_jerseynamecolorg = 0;
      this.m_jerseynamecolorb = 0;
      this.m_teamcolorprimr = 0;
      this.m_teamcolorprimg = 0;
      this.m_teamcolorprimb = 0;
      this.m_teamcolorsecr = 0;
      this.m_teamcolorsecg = 0;
      this.m_teamcolorsecb = 0;
      this.m_teamcolortertr = 0;
      this.m_teamcolortertg = 0;
      this.m_teamcolortertb = 0;
      this.m_isinheritbasedetailmap = 0;
      this.m_jerseyshapestyle = 0;
      this.m_jerseynamelayouttype = 0;
      this.m_jerseyrenderingdetailmaptype = 0;
      this.m_renderingmaterialtype = 0;
      this.m_shortsrenderingdetailmaptype = 0;
      this.m_dlc = 0;
      this.m_jerseyfit = false;
      this.m_year = 0;
      this.m_powid = -1;
      this.m_islocked = 0;
    }

    public bool CloneTextures(Kit clone)
    {
      if (clone == null)
        return false;
      clone.m_KitTextures = (Bitmap[]) null;
      FifaEnvironment.CloneIntoZdata(this.KitTextureFileName(), Kit.KitTextureFileName(clone.teamid, clone.kittype, 0));
      FifaEnvironment.CloneIntoZdata(this.MiniKitDdsFileName(), Kit.MiniKitDdsFileName(clone.teamid, clone.kittype, 0));
      return true;
    }

    public void Load(Record r)
    {
      this.Id = r.IntField[FI.teamkits_teamkitid];
      this.m_teamid = r.IntField[FI.teamkits_teamtechid];
      this.m_kittype = r.IntField[FI.teamkits_teamkittypetechid];
      if (this.m_kittype > 10)
        this.m_kittype = 10;
      this.m_hasadvertisingkit = r.IntField[FI.teamkits_hasadvertisingkit] != 0;
      this.m_jerseybacknameplacementcode = r.IntField[FI.teamkits_jerseybacknameplacementcode] != 0;
      this.m_jerseyfrontnumberplacementcode = r.IntField[FI.teamkits_jerseyfrontnumberplacementcode] != 0;
      this.m_shortsnumberplacementcode = r.IntField[FI.teamkits_shortsnumberplacementcode] != 0;
      this.m_jerseycollargeometrytype = r.IntField[FI.teamkits_jerseycollargeometrytype];
      this.m_jerseybacknamefontcase = r.IntField[FI.teamkits_jerseybacknamefontcase];
      this.m_jerseynamefonttype = r.IntField[FI.teamkits_jerseynamefonttype];
      this.m_numberfonttype = r.IntField[FI.teamkits_numberfonttype];
      //this.m_numbercolor = r.IntField[FI.teamkits_numbercolor];
      this.m_shortsnumberfonttype = r.IntField[FI.teamkits_shortsnumberfonttype];
      //this.m_shortsnumbercolor = r.IntField[FI.teamkits_shortsnumbercolor];
      this.m_jerseynamecolorr = r.IntField[FI.teamkits_jerseynamecolorr];
      this.m_jerseynamecolorg = r.IntField[FI.teamkits_jerseynamecolorg];
      this.m_jerseynamecolorb = r.IntField[FI.teamkits_jerseynamecolorb];
      this.m_JerseyNameColor = Color.FromArgb((int) byte.MaxValue, this.m_jerseynamecolorr, this.m_jerseynamecolorg, this.m_jerseynamecolorb);
      this.m_teamcolorprimr = r.IntField[FI.teamkits_teamcolorprimr];
      this.m_teamcolorprimg = r.IntField[FI.teamkits_teamcolorprimg];
      this.m_teamcolorprimb = r.IntField[FI.teamkits_teamcolorprimb];
      this.m_teamcolorsecr = r.IntField[FI.teamkits_teamcolorsecr];
      this.m_teamcolorsecg = r.IntField[FI.teamkits_teamcolorsecg];
      this.m_teamcolorsecb = r.IntField[FI.teamkits_teamcolorsecb];
      this.m_teamcolortertr = r.IntField[FI.teamkits_teamcolortertr];
      this.m_teamcolortertg = r.IntField[FI.teamkits_teamcolortertg];
      this.m_teamcolortertb = r.IntField[FI.teamkits_teamcolortertb];
      this.m_TeamColor1 = Color.FromArgb((int) byte.MaxValue, this.m_teamcolorprimr, this.m_teamcolorprimg, this.m_teamcolorprimb);
      this.m_TeamColor2 = Color.FromArgb((int) byte.MaxValue, this.m_teamcolorsecr, this.m_teamcolorsecg, this.m_teamcolorsecb);
      this.m_TeamColor3 = Color.FromArgb((int) byte.MaxValue, this.m_teamcolortertr, this.m_teamcolortertg, this.m_teamcolortertb);
      this.m_isinheritbasedetailmap = r.IntField[FI.teamkits_isinheritbasedetailmap];
      this.m_jerseyshapestyle = r.IntField[FI.teamkits_jerseyshapestyle];
      this.m_jerseynamelayouttype = r.IntField[FI.teamkits_jerseynamelayouttype];
      this.m_jerseyrenderingdetailmaptype = r.IntField[FI.teamkits_jerseyrenderingdetailmaptype];
      this.m_renderingmaterialtype = r.IntField[FI.teamkits_renderingmaterialtype];
      this.m_shortsrenderingdetailmaptype = r.IntField[FI.teamkits_shortsrenderingdetailmaptype];
      this.m_dlc = r.IntField[FI.teamkits_dlc];
      if (FI.teamkits_jerseyfit >= 0)
        this.m_jerseyfit = r.IntField[FI.teamkits_jerseyfit] != 0;
      this.m_year = r.IntField[FI.teamkits_year];
      this.m_powid = r.IntField[FI.teamkits_powid];
      this.m_islocked = r.IntField[FI.teamkits_islocked];
    }

    public void LinkTeam(TeamList kitList)
    {
      if (kitList == null)
        return;
      Team team = (Team) kitList.SearchId(this.m_teamid);
      if (team == null)
        return;
      this.m_Team = team;
    }

    public void SaveKit(Record r, int artificialKey)
    {
      r.IntField[FI.teamkits_teamkitid] = artificialKey;
      r.IntField[FI.teamkits_teamtechid] = this.m_teamid;
      r.IntField[FI.teamkits_teamkittypetechid] = this.m_kittype;
      r.IntField[FI.teamkits_hasadvertisingkit] = this.m_hasadvertisingkit ? 1 : 0;
      r.IntField[FI.teamkits_jerseybacknameplacementcode] = this.m_jerseybacknameplacementcode ? 1 : 0;
      r.IntField[FI.teamkits_jerseyfrontnumberplacementcode] = this.m_jerseyfrontnumberplacementcode ? 1 : 0;
      r.IntField[FI.teamkits_shortsnumberplacementcode] = this.m_shortsnumberplacementcode ? 1 : 0;
      r.IntField[FI.teamkits_jerseycollargeometrytype] = this.m_jerseycollargeometrytype;
      r.IntField[FI.teamkits_jerseybacknamefontcase] = this.m_jerseybacknamefontcase;
      r.IntField[FI.teamkits_jerseynamefonttype] = this.m_jerseynamefonttype;
      r.IntField[FI.teamkits_numberfonttype] = this.m_numberfonttype;
      //r.IntField[FI.teamkits_numbercolor] = this.m_numbercolor;
      r.IntField[FI.teamkits_shortsnumberfonttype] = this.m_shortsnumberfonttype;
      //r.IntField[FI.teamkits_shortsnumbercolor] = this.m_shortsnumbercolor;
      this.m_jerseynamecolorr = (int) this.m_JerseyNameColor.R;
      this.m_jerseynamecolorg = (int) this.m_JerseyNameColor.G;
      this.m_jerseynamecolorb = (int) this.m_JerseyNameColor.B;
      r.IntField[FI.teamkits_jerseynamecolorr] = this.m_jerseynamecolorr;
      r.IntField[FI.teamkits_jerseynamecolorg] = this.m_jerseynamecolorg;
      r.IntField[FI.teamkits_jerseynamecolorb] = this.m_jerseynamecolorb;
      this.m_teamcolorprimr = (int) this.m_TeamColor1.R;
      this.m_teamcolorprimg = (int) this.m_TeamColor1.G;
      this.m_teamcolorprimb = (int) this.m_TeamColor1.B;
      this.m_teamcolorsecr = (int) this.m_TeamColor2.R;
      this.m_teamcolorsecg = (int) this.m_TeamColor2.G;
      this.m_teamcolorsecb = (int) this.m_TeamColor2.B;
      this.m_teamcolortertr = (int) this.m_TeamColor3.R;
      this.m_teamcolortertg = (int) this.m_TeamColor3.G;
      this.m_teamcolortertb = (int) this.m_TeamColor3.B;
      r.IntField[FI.teamkits_teamcolorprimr] = this.m_teamcolorprimr;
      r.IntField[FI.teamkits_teamcolorprimg] = this.m_teamcolorprimg;
      r.IntField[FI.teamkits_teamcolorprimb] = this.m_teamcolorprimb;
      r.IntField[FI.teamkits_teamcolorsecr] = this.m_teamcolorsecr;
      r.IntField[FI.teamkits_teamcolorsecg] = this.m_teamcolorsecg;
      r.IntField[FI.teamkits_teamcolorsecb] = this.m_teamcolorsecb;
      r.IntField[FI.teamkits_teamcolortertr] = this.m_teamcolortertr;
      r.IntField[FI.teamkits_teamcolortertg] = this.m_teamcolortertg;
      r.IntField[FI.teamkits_teamcolortertb] = this.m_teamcolortertb;
      r.IntField[FI.teamkits_isinheritbasedetailmap] = this.m_isinheritbasedetailmap;
      r.IntField[FI.teamkits_jerseyshapestyle] = this.m_jerseyshapestyle;
      r.IntField[FI.teamkits_jerseynamelayouttype] = this.m_jerseynamelayouttype;
      r.IntField[FI.teamkits_jerseyrenderingdetailmaptype] = this.m_jerseyrenderingdetailmaptype;
      r.IntField[FI.teamkits_renderingmaterialtype] = this.m_renderingmaterialtype;
      r.IntField[FI.teamkits_shortsrenderingdetailmaptype] = this.m_shortsrenderingdetailmaptype;
      r.IntField[FI.teamkits_dlc] = this.m_dlc;
      if (FI.teamkits_jerseyfit >= 0)
        r.IntField[FI.teamkits_jerseyfit] = this.m_jerseyfit ? 1 : 0;
      r.IntField[FI.teamkits_year] = this.m_year;
      r.IntField[FI.teamkits_islocked] = 0;
      r.IntField[FI.teamkits_powid] = -1;
    }

    public string MiniKitDdsFileName()
    {
      return Kit.MiniKitDdsFileName(this.m_teamid, this.m_kittype, this.m_year);
    }

    public static string MiniKitDdsFileName(int teamid, int kittype, int year)
    {
      return "data/ui/imgassets/kits/j" + kittype.ToString() + "_" + teamid.ToString() + "_" + year.ToString() + ".dds";
    }

    public string MiniKitTemplateFileName()
    {
      return "data/ui/imgassets/kits/j#_%_0.dds";
    }

    public Bitmap GetMiniKit()
    {
      return FifaEnvironment.GetDdsArtasset(this.MiniKitDdsFileName());
    }

    public Bitmap GetMiniKit(int kitType)
    {
      return FifaEnvironment.GetDdsArtasset(Kit.MiniKitDdsFileName(this.m_teamid, kitType, 0));
    }

    public bool SetMiniKit(Bitmap bitmap)
    {
      int[] ids = new int[2]
      {
        this.m_kittype,
        this.m_teamid
      };
      string[] format = new string[2]
      {
        string.Empty,
        string.Empty
      };
      return FifaEnvironment.SetDdsArtasset(this.MiniKitTemplateFileName(), ids, bitmap, format);
    }

    public bool DeleteMiniKit()
    {
      return FifaEnvironment.DeleteFromZdata(this.MiniKitDdsFileName());
    }

    public string KitTextureFileName()
    {
      return Kit.KitTextureFileName(this.m_teamid, this.m_kittype, this.m_year);
    }

    public static string KitTextureFileName(int teamid, int kittype, int year)
    {
      return "data/sceneassets/kit/kit_" + teamid.ToString() + "_" + kittype.ToString() + "_" + year.ToString() + ".rx3";
    }

    public string KitTextureTemplateName()
    {
      return FifaEnvironment.Year == 14 ? "data\\sceneassets\\kit\\2014_kit_#_%_@.rx3" : "data\\sceneassets\\kit\\kit_#_%_@.rx3";
    }

    public Bitmap[] GetKitTextures()
    {
      if (this.m_KitTextures != null)
        return this.m_KitTextures;
      this.m_KitTextures = FifaEnvironment.GetKitFromRx3(this.KitTextureFileName(), out this.m_Positions);
      return this.m_KitTextures;
    }

    public bool SetKitTextures(Bitmap[] bitmaps)
    {
      this.m_KitTextures = bitmaps;
      return FifaEnvironment.ImportKitIntoZdata(this.KitTextureTemplateName(), new int[3]
      {
        this.m_teamid,
        this.m_kittype,
        this.m_year
      }, bitmaps, this.m_Positions);
    }

    public bool SetKitTextures(string rx3FileName)
    {
      bool flag = FifaEnvironment.ImportFileIntoZdataAs(rx3FileName, this.KitTextureFileName(), false, ECompressionMode.Chunkzip);
      if (flag)
      {
        this.m_KitTextures = (Bitmap[]) null;
        this.GetKitTextures();
      }
      return flag;
    }

    public bool DeleteKitTextures()
    {
      bool flag = FifaEnvironment.DeleteFromZdata(this.KitTextureFileName());
      if (flag)
        this.m_KitTextures = (Bitmap[]) null;
      return flag;
    }

    public bool ImportKitTextures(string rx3FileName)
    {
      return this.SetKitTextures(rx3FileName);
    }

    public bool ExportKitTextures(string exportDir)
    {
      return FifaEnvironment.ExportFileFromZdata(this.KitTextureFileName(), exportDir);
    }

    public Bitmap[] GetJerseyFont()
    {
      return NumberFont.GetNumberFont(this.m_numberfonttype, this.m_numbercolor);
    }

    public bool SetJerseyFont(Bitmap[] bitmaps)
    {
      return NumberFont.SetNumberFont(this.m_numberfonttype, this.m_numbercolor, bitmaps);
    }

    public bool SetJerseyFont(string rx3FileName)
    {
      return NumberFont.SetNumberFont(this.m_numberfonttype, this.m_numbercolor, rx3FileName);
    }

    public bool DeleteJerseyFont()
    {
      return NumberFont.Delete(this.m_numberfonttype, this.m_numbercolor);
    }

    public static Bitmap ApplyJerseyShadowedTexture(Bitmap originalTexture)
    {
      if (Kit.s_JerseyShadow == null)
        Kit.s_JerseyShadow = new Bitmap(FifaEnvironment.LaunchDir + "\\Templates\\JerseyShadow.png");
      return Kit.s_JerseyShadow == null ? originalTexture : GraphicUtil.EmbossBitmap(originalTexture, Kit.s_JerseyShadow);
    }

    public static Bitmap ApplyShortsShadowedTexture(Bitmap originalTexture)
    {
      if (Kit.s_ShortsShadow == null)
        Kit.s_ShortsShadow = new Bitmap(FifaEnvironment.LaunchDir + "\\Templates\\ShortsShadow.png");
      return Kit.s_ShortsShadow == null ? originalTexture : GraphicUtil.EmbossBitmap(originalTexture, Kit.s_ShortsShadow);
    }
  }
}
