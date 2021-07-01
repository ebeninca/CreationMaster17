// Original code created by Rinaldo

using System.Drawing;

namespace FifaLibrary
{
  public class Shoes : IdObject
  {
    private static Color[] c_ShoesColor = new Color[16]
    {
      Color.FromArgb((int) byte.MaxValue, 20, 20, 20),
      Color.FromArgb((int) byte.MaxValue, 50, 34, 105),
      Color.FromArgb((int) byte.MaxValue, 1, 32, 87),
      Color.FromArgb((int) byte.MaxValue, 8, 77, 158),
      Color.FromArgb((int) byte.MaxValue, 1, 159, 224),
      Color.FromArgb((int) byte.MaxValue, 0, 177, 17),
      Color.FromArgb((int) byte.MaxValue, 120, 200, 25),
      Color.FromArgb((int) byte.MaxValue, 250, 245, 10),
      Color.FromArgb((int) byte.MaxValue, 250, 240, 0),
      Color.FromArgb((int) byte.MaxValue, 236, 86, 1),
      Color.FromArgb((int) byte.MaxValue, 227, 1, 103),
      Color.FromArgb((int) byte.MaxValue, 177, 11, 35),
      Color.FromArgb((int) byte.MaxValue, 112, 37, 42),
      Color.FromArgb((int) byte.MaxValue, 146, 114, 63),
      Color.FromArgb((int) byte.MaxValue, 160, 160, 160),
      Color.FromArgb((int) byte.MaxValue, 235, 235, 235)
    };
    private bool m_HasName;
    private string m_LanguageName;
    private int m_shoecolor1;
    private int m_shoecolor2;
    private int m_shoedesign;
    private int m_powid;
    private bool m_IsAdidas;
    private bool m_IsAvailableinStore;
    private bool m_IsEmbargoed;
    private bool m_IsLegacy;
    private bool m_IsLicensed;
    private bool m_IsLocked;

    public static Color GetGenericColor(int colorId)
    {
      return colorId >= 0 && colorId <= 15 ? Shoes.c_ShoesColor[colorId] : Color.FromArgb(0, 0, 0, 0);
    }

    public static Color[] ShoesColorPalette
    {
      get
      {
        return Shoes.c_ShoesColor;
      }
    }

    public bool HasName
    {
      get
      {
        return this.m_HasName;
      }
      set
      {
        this.m_HasName = value;
      }
    }

    public string Name
    {
      get
      {
        return this.m_LanguageName;
      }
      set
      {
        this.m_LanguageName = value;
        FifaEnvironment.Language.SetShoesName(this.Id, this.m_LanguageName);
        this.m_HasName = true;
      }
    }

    public int shoecolor1
    {
      get
      {
        return this.m_shoecolor1;
      }
      set
      {
        this.m_shoecolor1 = value;
      }
    }

    public int shoecolor2
    {
      get
      {
        return this.m_shoecolor2;
      }
      set
      {
        this.m_shoecolor2 = value;
      }
    }

    public int shoedesign
    {
      get
      {
        return this.m_shoedesign;
      }
      set
      {
        this.m_shoedesign = value;
      }
    }

    public int powid
    {
      get
      {
        return this.m_powid;
      }
      set
      {
        this.m_powid = value;
      }
    }

    public bool IsAdidas
    {
      get
      {
        return this.m_IsAdidas;
      }
      set
      {
        this.m_IsAdidas = value;
      }
    }

    public bool IsAvailableinStore
    {
      get
      {
        return this.m_IsAvailableinStore;
      }
      set
      {
        this.m_IsAvailableinStore = value;
      }
    }

    public bool IsEmbargoed
    {
      get
      {
        return this.m_IsEmbargoed;
      }
      set
      {
        this.m_IsEmbargoed = value;
      }
    }

    public bool IsLegacy
    {
      get
      {
        return this.m_IsLegacy;
      }
      set
      {
        this.m_IsLegacy = value;
      }
    }

    public bool IsLicensed
    {
      get
      {
        return this.m_IsLicensed;
      }
      set
      {
        this.m_IsLicensed = value;
      }
    }

    public bool IsLocked
    {
      get
      {
        return this.m_IsLocked;
      }
      set
      {
        this.m_IsLocked = value;
      }
    }

    public Shoes(Record r)
      : base(r.IntField[FI.playerboots_shoetype])
    {
      this.m_LanguageName = FifaEnvironment.Language.GetShoesName(this.Id);
      this.m_HasName = this.m_LanguageName != null;
      if (!this.m_HasName)
        this.m_LanguageName = "Shoes n. " + FifaUtil.PadBlanks(this.Id.ToString(), 3);
      this.m_shoecolor1 = r.GetAndCheckIntField(FI.playerboots_shoecolor1);
      this.m_shoecolor2 = r.GetAndCheckIntField(FI.playerboots_shoecolor2);
      this.m_shoedesign = r.GetAndCheckIntField(FI.playerboots_shoedesign);
      this.m_IsAdidas = r.IntField[FI.playerboots_isadidas] > 0;
      this.m_IsAvailableinStore = r.IntField[FI.playerboots_isavailableinstore] > 0;
      this.m_IsEmbargoed = r.IntField[FI.playerboots_isembargoed] > 0;
      this.m_IsLegacy = r.IntField[FI.playerboots_islegacy] > 0;
      this.m_IsLicensed = r.IntField[FI.playerboots_islicensed] > 0;
      this.m_IsLocked = r.IntField[FI.playerboots_islocked] > 0;
      this.m_powid = r.GetAndCheckIntField(FI.playerboots_powid);
    }

    public Shoes(int shoesId)
      : base(shoesId)
    {
      this.m_LanguageName = FifaEnvironment.Language.GetShoesName(this.Id);
      this.m_HasName = this.m_LanguageName != null;
      if (!this.m_HasName)
        this.m_LanguageName = "Shoes n. " + FifaUtil.PadBlanks(this.Id.ToString(), 3);
      this.m_shoecolor1 = 30;
      this.m_shoecolor2 = 31;
      this.m_shoedesign = 0;
      this.m_IsAdidas = false;
      this.m_IsAvailableinStore = false;
      this.m_IsEmbargoed = false;
      this.m_IsLegacy = false;
      this.m_IsLicensed = false;
      this.m_IsLocked = false;
      this.m_powid = -1;
    }

    public void SaveShoes(Record r)
    {
      r.IntField[FI.playerboots_shoetype] = this.Id;
      r.IntField[FI.playerboots_shoecolor1] = this.m_shoecolor1;
      r.IntField[FI.playerboots_shoecolor2] = this.m_shoecolor2;
      r.IntField[FI.playerboots_shoedesign] = this.m_shoedesign;
      r.IntField[FI.playerboots_isadidas] = this.m_IsAdidas ? 1 : 0;
      r.IntField[FI.playerboots_isavailableinstore] = this.m_IsAvailableinStore ? 1 : 0;
      r.IntField[FI.playerboots_isembargoed] = 0;
      r.IntField[FI.playerboots_islegacy] = 0;
      r.IntField[FI.playerboots_islicensed] = 1;
      r.IntField[FI.playerboots_islocked] = 0;
      r.IntField[FI.playerboots_powid] = -1;
    }

    public override IdObject Clone(int newId)
    {
      Shoes shoes = (Shoes) base.Clone(newId);
      if (shoes != null)
      {
        string str = FifaUtil.PadBlanks(this.Id.ToString(), 3);
        shoes.Name = "Shoes n. " + str;
        FifaEnvironment.CloneIntoZdata(Shoes.ShoesTexturesFileName(this.Id, 0), Shoes.ShoesTexturesFileName(newId, 0));
        FifaEnvironment.CloneIntoZdata(Shoes.ShoesModelFileName(this.Id), Shoes.ShoesModelFileName(newId));
      }
      return (IdObject) shoes;
    }

    public override string ToString()
    {
      return this.m_LanguageName;
    }

    public static string ShoesTexturesFileName(int shoesBrand, int shoesDesign)
    {
      return "data/sceneassets/shoe/shoe_" + shoesBrand.ToString() + "_" + shoesDesign.ToString() + "_textures.rx3";
    }

    public static string ShoesModelFileName(int shoesBrand)
    {
      return "data/sceneassets/shoe/shoe_" + shoesBrand.ToString() + ".rx3";
    }

    public static Bitmap GetShoesColorTexture(int shoesBrand, int shoesDesign)
    {
      return FifaEnvironment.GetBmpFromRx3(Shoes.ShoesTexturesFileName(shoesBrand, shoesDesign));
    }

    public static Bitmap[] GetShoesTextures(int shoesBrand, int shoesDesign)
    {
      return FifaEnvironment.GetBmpsFromRx3(Shoes.ShoesTexturesFileName(shoesBrand, shoesDesign));
    }

    public static bool ImportShoesTextures(int shoesBrand, int shoesColor, string rx3FileName)
    {
      return Shoes.SetShoesTextures(shoesBrand, shoesColor, rx3FileName);
    }

    public static bool ExportShoesTextures(int shoesBrand, int shoesColor, string exportDir)
    {
      return FifaEnvironment.ExportFileFromZdata(Shoes.ShoesTexturesFileName(shoesBrand, shoesColor), exportDir);
    }

    public static Rx3File GetShoesModel(int shoesBrand)
    {
      return FifaEnvironment.GetRx3FromZdata(Shoes.ShoesModelFileName(shoesBrand));
    }

    public static string ShoeTemplateFilename()
    {
      return FifaEnvironment.Year == 14 ? "data/sceneassets/shoe/2014_shoe_#_%_textures.rx3" : "data/sceneassets/shoe/shoe_#_%_textures.rx3";
    }

    public static bool SetShoesTextures(int shoesBrand, int shoesDesign, Bitmap[] bitmaps)
    {
      Shoes.ShoesTexturesFileName(shoesBrand, shoesDesign);
      return FifaEnvironment.ImportBmpsIntoZdata(Shoes.ShoeTemplateFilename(), new int[2]
      {
        shoesBrand,
        shoesDesign
      }, bitmaps, ECompressionMode.Chunkzip);
    }

    public static bool SetShoesTextures(int shoesBrand, int shoesDesign, string rx3FileName)
    {
      string archivedName = Shoes.ShoesTexturesFileName(shoesBrand, shoesDesign);
      return FifaEnvironment.ImportFileIntoZdataAs(rx3FileName, archivedName, false, ECompressionMode.Chunkzip);
    }

    public static bool SetShoesModel(int shoesBrand, string rx3FileName)
    {
      string archivedName = Shoes.ShoesModelFileName(shoesBrand);
      return FifaEnvironment.ImportFileIntoZdataAs(rx3FileName, archivedName, false, ECompressionMode.Chunkzip);
    }

    public static bool ExportShoesModel(int shoesBrand, string exportDir)
    {
      return FifaEnvironment.ExportFileFromZdata(Shoes.ShoesModelFileName(shoesBrand), exportDir);
    }

    public static bool DeleteShoes(int shoesBrand, int shoesColor)
    {
      FifaEnvironment.DeleteFromZdata(Shoes.ShoesTexturesFileName(shoesBrand, shoesColor));
      FifaEnvironment.DeleteFromZdata(Shoes.ShoesModelFileName(shoesBrand));
      return true;
    }

    public static bool DeleteShoesTextures(int shoesBrand, int shoesColor)
    {
      FifaEnvironment.DeleteFromZdata(Shoes.ShoesTexturesFileName(shoesBrand, shoesColor));
      return true;
    }

    public static bool DeleteShoesModel(int shoesBrand)
    {
      FifaEnvironment.DeleteFromZdata(Shoes.ShoesModelFileName(shoesBrand));
      return true;
    }
  }
}
