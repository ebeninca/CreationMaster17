// Original code created by Rinaldo

using System.Drawing;

namespace FifaLibrary
{
  public class Ball : IdObject
  {
    private bool m_IsLicensed;
    private bool m_IsAvailable;
    private bool m_IsEmbargoed;
    private int m_powid;
    private string m_LanguageName;
    private bool m_IsGeneric;

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

    public bool IsAvailable
    {
      get
      {
        return this.m_IsAvailable;
      }
      set
      {
        this.m_IsAvailable = value;
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

    public string Name
    {
      get
      {
        return this.m_LanguageName;
      }
      set
      {
        this.m_LanguageName = value;
        FifaEnvironment.Language.SetBallName(this.Id, this.m_LanguageName, this.m_IsGeneric);
      }
    }

    public bool IsGeneric
    {
      get
      {
        return this.m_IsGeneric;
      }
      set
      {
        if (value != this.m_IsGeneric)
        {
          FifaEnvironment.Language.RemoveBallName(this.Id);
          FifaEnvironment.Language.SetBallName(this.Id, this.m_LanguageName, value);
        }
        this.m_IsGeneric = value;
      }
    }

    public Ball(int ballId)
      : base(ballId)
    {
      this.m_LanguageName = FifaEnvironment.Language.GetBallName(this.Id, out this.m_IsGeneric);
      if (this.m_LanguageName == null)
      {
        this.m_LanguageName = "Ball n." + this.Id.ToString();
        this.m_IsGeneric = false;
        FifaEnvironment.Language.SetBallName(this.Id, this.m_LanguageName, this.m_IsGeneric);
      }
      this.m_IsLicensed = false;
      this.m_IsAvailable = true;
      this.m_IsEmbargoed = false;
      this.m_powid = -1;
    }

    public Ball(Record r)
      : base(r.IntField[FI.teamballs_ballid])
    {
      this.m_LanguageName = FifaEnvironment.Language.GetBallName(this.Id, out this.m_IsGeneric);
      if (this.m_LanguageName == null)
      {
        this.m_LanguageName = "Ball n." + this.Id.ToString();
        this.m_IsGeneric = false;
        FifaEnvironment.Language.SetBallName(this.Id, this.m_LanguageName, this.m_IsGeneric);
      }
      this.m_IsLicensed = r.GetAndCheckIntField(FI.teamballs_islicensed) != 0;
      this.m_IsAvailable = r.GetAndCheckIntField(FI.teamballs_isavailableinstore) != 0;
      this.m_IsEmbargoed = r.GetAndCheckIntField(FI.teamballs_isembargoed) != 0;
      this.m_powid = r.GetAndCheckIntField(FI.teamballs_powid);
    }

    public void SaveBall(Record r)
    {
      r.IntField[FI.teamballs_ballid] = this.Id;
      r.IntField[FI.teamballs_islicensed] = this.m_IsLicensed ? 1 : 0;
      r.IntField[FI.teamballs_isavailableinstore] = this.m_IsAvailable ? 1 : 0;
      r.IntField[FI.teamballs_isembargoed] = 0;
      r.IntField[FI.teamballs_powid] = -1;
    }

    public override string ToString()
    {
      return this.m_LanguageName;
    }

    public static string[] BallTextureFileNameList(int ballId)
    {
      string BallPath = "Content/Character/ball/ball_" + ballId.ToString() + "/ball_" + ballId.ToString();
      return new string[] { BallPath + "_color.png", BallPath + "_coeff.png", BallPath + "_normal.png" };
    }

    public string BallTextureFileName()
    {
      return Ball.BallTextureFileNameList(this.Id)[0];
    }

    public static Bitmap GetBallTexture(int ballId)
    {
      return FifaEnvironment.GetBmpFromRx3(Ball.BallTextureFileNameList(ballId)[0], 0);
    }

    public Bitmap GetBallTexture()
    {
      return Ball.GetBallTexture(this.Id);
    }

    public static Bitmap[] GetBallTextures(int ballId)
    {
      return FifaEnvironment.GetBitmaps(Ball.BallTextureFileNameList(ballId));
    }

    public Bitmap[] GetBallTextures()
    {
      return Ball.GetBallTextures(this.Id);
    }

    public static string BallTextureTemplateFileName()
    {
      return "Content\\Character\\ball\\ball_#\ball_#_color.png";
    }

    public static bool SetBallTextures(int ballId, Bitmap[] bitmaps)
    {
      for (int index = 1; index < bitmaps.Length; ++index)
        bitmaps[index] = (Bitmap)null;
      return FifaEnvironment.ImportBmpsIntoZdata(Ball.BallTextureTemplateFileName(), ballId, bitmaps, ECompressionMode.Chunkzip);
    }

    public bool SetBallTextures(Bitmap[] bitmaps)
    {
      return Ball.SetBallTextures(this.Id, bitmaps);
    }

    public static bool SetBallTextures(int ballId, string rx3FileName)
    {
      return FifaEnvironment.ImportFileIntoZdataAs(rx3FileName, Ball.BallTextureFileNameList(ballId)[0], false, ECompressionMode.Chunkzip);
    }

    public bool SetBallTextures(string srcFileName)
    {
      return Ball.SetBallTextures(this.Id, srcFileName);
    }

    public bool DeleteBallTextures()
    {
      return FifaEnvironment.DeleteFromZdata(this.BallTextureFileName());
    }

    public static string BallPictureTemplateBigFileName()
    {
      return "data/ui/artassets/settingsimg/ball_#.big";
    }

    public static string BallPictureTemplateDdsName()
    {
      return "2";
    }

    public static string BallPictureBigFileName(int ballId)
    {
      return "data/ui/artassets/settingsimg/ball_" + ballId.ToString() + ".big";
    }

    public string BallPictureBigFileName()
    {
      return Ball.BallPictureBigFileName(this.Id);
    }

    public static Bitmap GetBallPicture(int ballId)
    {
      return FifaEnvironment.Year == 14 ? FifaEnvironment.GetArtasset(Ball.BallPictureBigFileName(ballId)) : FifaEnvironment.GetDdsArtasset(Ball.BallDdsFileName(ballId));
    }

    public Bitmap GetBallPicture()
    {
      return Ball.GetBallPicture(this.Id);
    }

    public bool DeleteBallPicture()
    {
      return FifaEnvironment.Year == 14 ? FifaEnvironment.DeleteFromZdata(this.BallPictureBigFileName()) : FifaEnvironment.DeleteFromZdata(this.BallDdsFileName());
    }

    public static bool SetBallPicture(int ballId, Bitmap bitmap)
    {
      if (bitmap == null)
        return false;
      return FifaEnvironment.Year == 14 ? FifaEnvironment.SetArtasset(Ball.BallPictureTemplateBigFileName(), Ball.BallPictureTemplateDdsName(), ballId, bitmap) : FifaEnvironment.SetDdsArtasset(Ball.BallDdsTemplateFileName(), ballId, bitmap);
    }

    public bool SetBallPicture(Bitmap bitmap)
    {
      return Ball.SetBallPicture(this.Id, bitmap);
    }

    public static string BallDdsFileName(int id)
    {
      return "data/ui/imgassets/settingsimg/ball_" + id.ToString() + ".dds";
    }

    public static string BallDdsTemplateFileName()
    {
      return "data/ui/imgassets/settingsimg/ball_#.dds";
    }

    public string BallDdsFileName()
    {
      return Ball.BallDdsFileName(this.Id);
    }

    public static string BallModelFileName(int ballId)
    {
      return "Content/Character/ball/ball_" + ballId.ToString() + "/ball_" + ballId.ToString() + ".rx3";
      //return "Content/Character/ball/ball_" + ballId.ToString() + "/ball_" + ballId.ToString() + "_mesh.fbx";
    }

    public string BallModelFileName()
    {
      return Ball.BallModelFileName(this.Id);
    }

    public static string BallModelTemplateFileName()
    {
      return "Content/Character/ball/ball_#/bal_#_color.png";
    }

    public static Rx3File GetBallModel(int ballId)
    {
      return FifaEnvironment.GetRx3FromZdata(Ball.BallModelFileName(ballId));
    }

    public Rx3File GetBallModel()
    {
      return Ball.GetBallModel(this.Id);
    }

    public static bool SetBallModel(int ballId, string rx3FileName)
    {
      return FifaEnvironment.ImportFileIntoZdataAs(rx3FileName, Ball.BallModelFileName(ballId), false, ECompressionMode.Chunkzip, (Rx3Signatures)null);
    }

    public bool SetBallModel(string srcFileName)
    {
      return Ball.SetBallModel(this.Id, srcFileName);
    }

    public bool DeleteBallModel()
    {
      return FifaEnvironment.DeleteFromZdata(this.BallModelFileName());
    }

    public bool DeleteBall()
    {
      this.DeleteBallTextures();
      this.DeleteBallModel();
      this.DeleteBallPicture();
      return true;
    }

    public override IdObject Clone(int newId)
    {
      Ball ball = (Ball)base.Clone(newId);
      if (ball != null)
      {
        ball.Name = "Ball n." + newId.ToString();
        FifaEnvironment.CloneIntoZdata(Ball.BallTextureFileNameList(this.Id)[0], Ball.BallTextureFileNameList(newId)[0]);
        FifaEnvironment.CloneIntoZdata(Ball.BallModelFileName(this.Id), Ball.BallModelFileName(newId));
        if (FifaEnvironment.Year == 14)
          FifaEnvironment.CloneIntoZdata(Ball.BallPictureBigFileName(this.Id), Ball.BallPictureBigFileName(newId));
        else
          FifaEnvironment.CloneIntoZdata(Ball.BallDdsFileName(this.Id), Ball.BallDdsFileName(newId));
      }
      return (IdObject)ball;
    }
  }
}
