// Original code created by Rinaldo

using System;
using System.Drawing;

namespace FifaLibrary
{
    public class Referee : IdObject
    {
        private static int c_MaxNLeagues = 8;
        private static Random m_Randomizer = new Random();
        private int[] m_leagueids = new int[Referee.c_MaxNLeagues];
        private League[] m_Leagues = new League[Referee.c_MaxNLeagues];
        private int[] c_HairToFacial = new int[10]
        {
      1,
      0,
      1,
      0,
      1,
      3,
      2,
      4,
      3,
      3
        };
        private int[] c_RefereHair = new int[69]
        {
      0,
      1,
      2,
      8,
      13,
      14,
      16,
      19,
      20,
      21,
      22,
      23,
      24,
      25,
      26,
      28,
      29,
      30,
      31,
      32,
      35,
      36,
      37,
      38,
      40,
      41,
      43,
      45,
      46,
      47,
      54,
      57,
      58,
      59,
      62,
      64,
      65,
      66,
      67,
      69,
      70,
      72,
      73,
      74,
      75,
      77,
      78,
      82,
      83,
      85,
      86,
      87,
      88,
      89,
      90,
      92,
      93,
      95,
      98,
      99,
      100,
      101,
      102,
      103,
      104,
      105,
      106,
      107,
      108
        };
        private Bitmap m_EyesTextureBitmap;
        private Bitmap m_FaceTextureBitmap;
        private Bitmap m_HairColorTextureBitmap;
        private Bitmap m_HairAlfaTextureBitmap;
        private Rx3File m_HeadModelFile;
        private Rx3File m_HairModelFile;
        private string m_firstname;
        private string m_surname;
        private DateTime m_birthdate;
        public int m_refereeheadid_unused;
        public bool m_isinternationalreferee;
        private int m_nationalitycode;
        private Country m_Country;
        private int m_height;
        private int m_weight;
        private int m_eyecolorcode;
        private int m_eyebrowcode;
        private int m_stylecode;
        private int m_cardstrictness;
        private int m_foulstrictness;
        private int m_homecitycode;
        private int m_sockheightcode;
        private int m_haireffecttypecode;
        private int m_hairlinecode;
        private int m_hairpartcode;
        private int m_hairstateid;
        private int m_hairvariationid;
        private int m_sweatid;
        private int m_wrinkleid;
        private int m_proxyhaircolorid;
        private int m_proxyheadclass;
        private int m_isreal;
        private int m_bodytypecode;
        private int m_hairtypecode;
        private int m_headtypecode;
        private int m_headclasscode;
        private int m_haircolorcode;
        private int m_facialhairtypecode;
        private int m_facialhaircolorcode;
        private int m_sideburnscode;
        private int m_skintypecode;
        private int m_skintonecode;
        private int m_jerseysleevelengthcode;
        private int m_shoedesigncode;
        private int m_shoecolorcode1;
        private int m_shoecolorcode2;
        private int m_shoetypecode;

        public Bitmap EyesTextureBitmap
        {
            get
            {
                return this.m_EyesTextureBitmap;
            }
        }

        public Bitmap FaceTextureBitmap
        {
            get
            {
                return this.m_FaceTextureBitmap;
            }
        }

        public Bitmap HairColorTextureBitmap
        {
            get
            {
                return this.m_HairColorTextureBitmap;
            }
        }

        public Bitmap HairAlfaTextureBitmap
        {
            get
            {
                return this.m_HairAlfaTextureBitmap;
            }
        }

        public string firstname
        {
            get
            {
                return this.m_firstname;
            }
            set
            {
                this.m_firstname = value;
            }
        }

        public string surname
        {
            get
            {
                return this.m_surname;
            }
            set
            {
                this.m_surname = value;
            }
        }

        public DateTime birthdate
        {
            get
            {
                return this.m_birthdate;
            }
            set
            {
                this.m_birthdate = value;
            }
        }

        public int nationalitycode
        {
            get
            {
                return this.m_nationalitycode;
            }
            set
            {
                this.m_nationalitycode = value;
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
                if (this.m_Country == null)
                    return;
                this.m_nationalitycode = this.m_Country.Id;
            }
        }

        public int[] leagueids
        {
            get
            {
                return this.m_leagueids;
            }
            set
            {
                this.m_leagueids = value;
            }
        }

        public League[] Leagues
        {
            get
            {
                return this.m_Leagues;
            }
            set
            {
                this.m_Leagues = value;
            }
        }

        public void SetLeague(int id)
        {
            for (int index = 0; index < this.m_Leagues.Length; ++index)
            {
                if (this.m_leagueids[index] == id)
                    return;
            }
            for (int index = 0; index < this.m_Leagues.Length; ++index)
            {
                if (this.m_leagueids[index] == 0)
                {
                    this.m_leagueids[index] = id;
                    break;
                }
            }
        }

        public int CntLeagues()
        {
            int num = 0;
            for (int index = 0; index < this.m_Leagues.Length; ++index)
            {
                if (this.m_leagueids[index] != 0)
                    ++num;
            }
            return num;
        }

        public int GetMainLeague()
        {
            for (int index = 0; index < this.m_Leagues.Length; ++index)
            {
                if (this.m_leagueids[index] != 0)
                    return this.m_leagueids[index];
            }
            return 1;
        }

        public bool IsInLeague(League league)
        {
            for (int index = 0; index < this.m_Leagues.Length; ++index)
            {
                if (this.Leagues[index] == league)
                    return true;
            }
            return false;
        }

        public int height
        {
            get
            {
                return this.m_height;
            }
            set
            {
                this.m_height = value;
            }
        }

        public int weight
        {
            get
            {
                return this.m_weight;
            }
            set
            {
                this.m_weight = value;
            }
        }

        public int eyecolorcode
        {
            get
            {
                return this.m_eyecolorcode;
            }
            set
            {
                this.m_eyecolorcode = value;
                this.m_EyesTextureBitmap = (Bitmap)null;
            }
        }

        public int eyebrowcode
        {
            get
            {
                return this.m_eyebrowcode;
            }
            set
            {
                this.m_eyebrowcode = value;
                this.m_FaceTextureBitmap = (Bitmap)null;
            }
        }

        public int stylecode
        {
            get
            {
                return this.m_stylecode;
            }
            set
            {
                this.m_stylecode = value;
            }
        }

        public int cardstrictness
        {
            get
            {
                return this.m_cardstrictness;
            }
            set
            {
                this.m_cardstrictness = value;
            }
        }

        public int foulstrictness
        {
            get
            {
                return this.m_foulstrictness;
            }
            set
            {
                this.m_foulstrictness = value;
            }
        }

        public int bodytypecode
        {
            get
            {
                return this.m_bodytypecode;
            }
            set
            {
                this.m_bodytypecode = value;
            }
        }

        public int hairtypecode
        {
            get
            {
                return this.m_hairtypecode;
            }
            set
            {
                this.m_hairtypecode = value;
                this.m_HairModelFile = (Rx3File)null;
            }
        }

        public int headtypecode
        {
            get
            {
                return this.m_headtypecode;
            }
            set
            {
                this.m_headtypecode = value;
                this.m_HeadModelFile = (Rx3File)null;
            }
        }

        public int haircolorcode
        {
            get
            {
                return this.m_haircolorcode;
            }
            set
            {
                this.m_haircolorcode = value;
                this.m_HairColorTextureBitmap = (Bitmap)null;
                this.m_HairAlfaTextureBitmap = (Bitmap)null;
            }
        }

        public int facialhairtypecode
        {
            get
            {
                return this.m_facialhairtypecode;
            }
            set
            {
                this.m_facialhairtypecode = value;
                this.m_FaceTextureBitmap = (Bitmap)null;
            }
        }

        public int facialhaircolorcode
        {
            get
            {
                return this.m_facialhaircolorcode;
            }
            set
            {
                this.m_facialhaircolorcode = value;
                this.m_FaceTextureBitmap = (Bitmap)null;
            }
        }

        public int sideburnscode
        {
            get
            {
                return this.m_sideburnscode;
            }
            set
            {
                this.m_sideburnscode = value;
                this.m_FaceTextureBitmap = (Bitmap)null;
            }
        }

        public int skintypecode
        {
            get
            {
                return this.m_skintypecode;
            }
            set
            {
                this.m_skintypecode = value;
                this.m_FaceTextureBitmap = (Bitmap)null;
            }
        }

        public int skintonecode
        {
            get
            {
                return this.m_skintonecode;
            }
            set
            {
                this.m_skintonecode = value;
                this.m_FaceTextureBitmap = (Bitmap)null;
            }
        }

        public int jerseysleevelengthcode
        {
            get
            {
                return this.m_jerseysleevelengthcode;
            }
            set
            {
                this.m_jerseysleevelengthcode = value;
            }
        }

        public int shoedesigncode
        {
            get
            {
                return this.m_shoedesigncode;
            }
            set
            {
                this.m_shoedesigncode = value;
            }
        }

        public int shoecolorcode1
        {
            get
            {
                return this.m_shoecolorcode1;
            }
            set
            {
                this.m_shoecolorcode1 = value;
            }
        }

        public int shoecolorcode2
        {
            get
            {
                return this.m_shoecolorcode2;
            }
            set
            {
                this.m_shoecolorcode2 = value;
            }
        }

        public int shoetypecode
        {
            get
            {
                return this.m_shoetypecode;
            }
            set
            {
                this.m_shoetypecode = value;
            }
        }

        public Referee(Record r)
          : base(r.IntField[FI.referee_refereeid])
        {
            this.Load(r);
        }

        public Referee(int refereeid)
          : base(refereeid)
        {
            int newRefereeHeadId = FifaEnvironment.Referees.GetNewRefereeHeadId();
            this.m_refereeheadid_unused = newRefereeHeadId > -1000 ? -1000 : newRefereeHeadId;
            this.m_firstname = "";
            this.m_surname = "Referee " + this.Id.ToString();
            this.m_birthdate = new DateTime(1970, 6, 15);
            this.m_nationalitycode = 0;
            for (int index = 0; index < this.m_Leagues.Length; ++index)
            {
                this.m_leagueids[index] = 0;
                this.m_Leagues[index] = (League)null;
            }
            this.m_height = 180;
            this.m_weight = 75;
            this.m_bodytypecode = 1;
            this.m_shoedesigncode = 0;
            this.m_shoecolorcode1 = 30;
            this.m_shoecolorcode2 = 31;
            this.m_shoetypecode = 72;
            this.m_jerseysleevelengthcode = 0;
            this.m_eyecolorcode = 1;
            this.m_eyebrowcode = 0;
            this.m_facialhairtypecode = 0;
            this.m_facialhaircolorcode = 0;
            this.m_hairtypecode = 0;
            this.m_haircolorcode = 0;
            this.m_headtypecode = 1;
            this.m_headclasscode = 1;
            this.m_sideburnscode = 0;
            this.m_skintypecode = 0;
            this.m_skintonecode = 2;
            this.m_stylecode = 1;
            this.m_cardstrictness = 1;
            this.m_foulstrictness = 1;
            this.m_homecitycode = 5;
            this.m_sockheightcode = 0;
            this.m_haireffecttypecode = 0;
            this.m_hairlinecode = 0;
            this.m_hairpartcode = 0;
            this.m_hairstateid = 0;
            this.m_hairvariationid = 0;
            this.m_sweatid = 0;
            this.m_wrinkleid = 0;
            this.m_proxyhaircolorid = 1;
            this.m_proxyheadclass = 1;
            this.m_isreal = 0;
        }

        public void Load(Record r)
        {
            this.m_firstname = r.StringField[FI.referee_firstname];
            this.m_surname = r.StringField[FI.referee_surname];
            this.m_nationalitycode = r.GetAndCheckIntField(FI.referee_nationalitycode);
            this.SetLeague(r.GetAndCheckIntField(FI.referee_leagueid));
            DateTime dateTime = FifaUtil.ConvertToDate(r.GetAndCheckIntField(FI.referee_birthdate));
            if (dateTime.Year < 1900)
                dateTime = new DateTime(1980, 1, 1);
            this.m_birthdate = dateTime;
            this.m_height = r.GetAndCheckIntField(FI.referee_height);
            this.m_weight = r.GetAndCheckIntField(FI.referee_weight);
            this.m_bodytypecode = r.GetAndCheckIntField(FI.referee_bodytypecode) - 1;
            this.m_shoedesigncode = r.GetAndCheckIntField(FI.referee_shoedesigncode);
            this.m_shoecolorcode1 = r.GetAndCheckIntField(FI.referee_shoecolorcode1);
            this.m_shoecolorcode2 = r.GetAndCheckIntField(FI.referee_shoecolorcode2);
            this.m_shoetypecode = r.GetAndCheckIntField(FI.referee_shoetypecode);
            this.m_jerseysleevelengthcode = r.GetAndCheckIntField(FI.referee_jerseysleevelengthcode);
            this.m_eyecolorcode = r.GetAndCheckIntField(FI.referee_eyecolorcode);
            this.m_eyebrowcode = r.GetAndCheckIntField(FI.referee_eyebrowcode);
            this.m_facialhairtypecode = r.GetAndCheckIntField(FI.referee_facialhairtypecode);
            this.m_facialhaircolorcode = r.GetAndCheckIntField(FI.referee_facialhaircolorcode);
            this.m_hairtypecode = r.GetAndCheckIntField(FI.referee_hairtypecode);
            this.m_haircolorcode = r.GetAndCheckIntField(FI.referee_haircolorcode);
            this.m_headtypecode = r.GetAndCheckIntField(FI.referee_headtypecode);
            this.m_headclasscode = r.GetAndCheckIntField(FI.referee_headclasscode);
            this.m_sideburnscode = r.GetAndCheckIntField(FI.referee_sideburnscode);
            this.m_skintypecode = r.GetAndCheckIntField(FI.referee_skintypecode);
            this.m_skintonecode = r.GetAndCheckIntField(FI.referee_skintonecode);
            this.m_stylecode = r.GetAndCheckIntField(FI.referee_stylecode);
            this.m_cardstrictness = r.GetAndCheckIntField(FI.referee_cardstrictness);
            this.m_foulstrictness = r.GetAndCheckIntField(FI.referee_foulstrictness);
            this.m_homecitycode = r.GetAndCheckIntField(FI.referee_homecitycode);
            this.m_sockheightcode = r.GetAndCheckIntField(FI.referee_sockheightcode);
            this.m_haireffecttypecode = r.GetAndCheckIntField(FI.referee_haireffecttypecode);
            this.m_hairlinecode = r.GetAndCheckIntField(FI.referee_hairlinecode);
            this.m_hairpartcode = r.GetAndCheckIntField(FI.referee_hairpartcode);
            this.m_hairstateid = r.GetAndCheckIntField(FI.referee_hairstateid);
            this.m_hairvariationid = r.GetAndCheckIntField(FI.referee_hairvariationid);
            this.m_sweatid = r.GetAndCheckIntField(FI.referee_sweatid);
            this.m_wrinkleid = r.GetAndCheckIntField(FI.referee_wrinkleid);
            this.m_proxyhaircolorid = r.GetAndCheckIntField(FI.referee_proxyhaircolorid);
            this.m_proxyheadclass = r.GetAndCheckIntField(FI.referee_proxyheadclass);
            if (FI.referee_isreal < 0)
                return;
            this.m_isreal = r.GetAndCheckIntField(FI.referee_isreal);
        }

        public void FillFromLeagueRefereeLinks(Record r)
        {
            this.SetLeague(r.GetAndCheckIntField(FI.leaguerefereelinks_leagueid));
        }

        public override string ToString()
        {
            return this.m_surname + " " + this.m_firstname;
        }

        public string DatabaseString()
        {
            return this.ToString();
        }

        public void LinkCountry(CountryList countryList)
        {
            if (countryList == null)
                return;
            this.m_Country = (Country)countryList.SearchId(this.m_nationalitycode);
            if (this.m_Country != null)
                return;
            if (countryList.Count > 0)
            {
                this.m_Country = (Country)countryList[0];
                this.m_nationalitycode = this.m_Country.Id;
            }
            else
                this.m_nationalitycode = 0;
        }

        public void LinkLeague(LeagueList leagueList)
        {
            if (leagueList == null)
                return;
            for (int index = 0; index < this.m_Leagues.Length; ++index)
            {
                if (this.m_leagueids[index] != 0)
                {
                    this.m_Leagues[index] = (League)leagueList.SearchId(this.m_leagueids[index]);
                    if (this.m_Leagues[index] == null)
                    {
                        this.m_leagueids[index] = 0;
                        this.m_Leagues[index] = (League)null;
                    }
                }
            }
        }

        public string GenericHairModelFileName()
        {
            return "data/sceneassets/hair/hair_" + this.m_hairtypecode.ToString() + "_1_0.rx3";
        }

        public string GenericFaceTextureFileName()
        {
            return "data/sceneassets/faces/face_0_1_0_" + this.m_eyebrowcode.ToString() + "_" + this.m_sideburnscode.ToString() + "_" + this.m_facialhaircolorcode.ToString() + "_" + this.m_facialhairtypecode.ToString() + "_" + this.m_skintypecode.ToString() + "_" + this.m_skintonecode.ToString() + "_textures.rx3";
        }

        public string GenericHeadModelFileName()
        {
            return "data/sceneassets/heads/head_" + this.m_headtypecode.ToString() + "_1.rx3";
        }

        public override IdObject Clone(int refereeid)
        {
            Referee referee = (Referee)base.Clone(refereeid);
            if (referee == null)
                return (IdObject)null;
            referee.m_refereeheadid_unused = this.m_refereeheadid_unused;
            referee.m_firstname = "";
            referee.m_surname = "Referee " + referee.Id.ToString();
            return (IdObject)referee;
        }

        public void CleanFaceTexture()
        {
            if (this.m_FaceTextureBitmap != null)
                this.m_FaceTextureBitmap.Dispose();
            this.m_FaceTextureBitmap = (Bitmap)null;
        }

        public Bitmap GetFaceTexture()
        {
            if (this.m_FaceTextureBitmap != null)
                return this.m_FaceTextureBitmap;
            this.m_FaceTextureBitmap = FifaEnvironment.GetBmpFromRx3(this.GenericFaceTextureFileName(), 0);
            return this.m_FaceTextureBitmap;
        }

        public string GenericEyesTextureFileName()
        {
            return "data/sceneassets/heads/eyes_" + this.m_eyecolorcode.ToString() + "_1_textures.rx3";
        }

        public Bitmap GetEyesTexture()
        {
            if (this.m_EyesTextureBitmap != null)
                return this.m_EyesTextureBitmap;
            this.m_EyesTextureBitmap = FifaEnvironment.GetBmpFromRx3(this.GenericEyesTextureFileName(), 0);
            return this.m_EyesTextureBitmap;
        }

        public void CleanEyesTexture()
        {
            if (this.m_EyesTextureBitmap != null)
                this.m_EyesTextureBitmap.Dispose();
            this.m_EyesTextureBitmap = (Bitmap)null;
        }

        public string GenericHairColorTextureFileName()
        {
            return "data/sceneassets/hair/haircolour_" + this.m_hairtypecode.ToString() + "_0_" + this.m_haircolorcode.ToString() + "_0_1_textures.rx3";
        }

        public void CleanHairColorTexture()
        {
            if (this.m_HairColorTextureBitmap != null)
                this.m_HairColorTextureBitmap.Dispose();
            this.m_HairColorTextureBitmap = (Bitmap)null;
        }

        public Bitmap GetHairColorTexture()
        {
            if (this.m_HairColorTextureBitmap != null)
                return this.m_HairColorTextureBitmap;
            this.GetHairTextures();
            return this.m_HairColorTextureBitmap;
        }

        public string GenericHairTexturesFileName()
        {
            return "data/sceneassets/hair/hair_" + this.m_hairtypecode.ToString() + "_1_textures.rx3";
        }

        public Bitmap[] GetHairTextures()
        {
            if (this.m_HairAlfaTextureBitmap != null && this.m_HairColorTextureBitmap != null)
                return new Bitmap[2]
                {
          this.m_HairAlfaTextureBitmap,
          this.m_HairColorTextureBitmap
                };
            Bitmap[] bmpsFromRx3 = FifaEnvironment.GetBmpsFromRx3(this.GenericHairTexturesFileName());
            this.m_HairAlfaTextureBitmap = bmpsFromRx3[0];
            this.m_HairColorTextureBitmap = GraphicUtil.MultiplyColorToBitmap(bmpsFromRx3[1], Player.s_GenericColors[this.m_haircolorcode], 96);
            return bmpsFromRx3;
        }

        public void CleanHairAlfaTexture()
        {
            if (this.m_HairAlfaTextureBitmap != null)
                this.m_HairAlfaTextureBitmap.Dispose();
            this.m_HairAlfaTextureBitmap = (Bitmap)null;
        }

        public Bitmap GetHairAlfaTexture()
        {
            if (this.m_HairAlfaTextureBitmap != null)
                return this.m_HairAlfaTextureBitmap;
            this.GetHairTextures();
            return this.m_HairAlfaTextureBitmap;
        }

        public void CleanHairTextures()
        {
            this.CleanHairColorTexture();
            this.CleanHairAlfaTexture();
        }

        public string GenericHairAlfaTextureFileName()
        {
            return "data/sceneassets/hair/hair_" + this.m_hairtypecode.ToString() + "_0_1_textures.rx3";
        }

        public Rx3File GetHeadModel()
        {
            if (this.m_HeadModelFile != null)
                return this.m_HeadModelFile;
            this.m_HeadModelFile = FifaEnvironment.GetRx3FromZdata(this.GenericHeadModelFileName());
            return this.m_HeadModelFile;
        }

        public void CleanHeadModel()
        {
            this.m_HeadModelFile = (Rx3File)null;
        }

        public void CleanHead()
        {
            this.CleanFaceTexture();
            this.CleanEyesTexture();
            this.CleanHeadModel();
        }

        public Rx3File GetHairModel()
        {
            if (this.m_HairModelFile != null)
                return this.m_HairModelFile;
            Rx3VertexFormat.LoadingHairMesh = true;
            this.m_HairModelFile = FifaEnvironment.GetRx3FromZdata(this.GenericHairModelFileName());
            Rx3VertexFormat.LoadingHairMesh = false;
            return this.m_HairModelFile;
        }

        public void CleanHairModel()
        {
            this.m_HairModelFile = (Rx3File)null;
        }

        public void CleanHair()
        {
            this.CleanHairModel();
            this.CleanHairTextures();
        }

        public void CleanAllHead()
        {
            this.CleanHair();
            this.CleanHead();
        }

        public static string PhotoBigFileName(int refereeId)
        {
            return "data/ui/artassets/referee/ref_" + refereeId.ToString() + ".big";
        }

        public string PhotoBigFileName()
        {
            return Referee.PhotoBigFileName(this.Id);
        }

        public string PhotoTemplateFileName()
        {
            return "data/ui/artassets/referee/ref_#.big";
        }

        public string PhotoDdsFileName()
        {
            return "2";
        }

        public Bitmap GetPhoto()
        {
            return FifaEnvironment.GetArtasset(this.PhotoBigFileName());
        }

        public bool SetPhoto(Bitmap bitmap)
        {
            return FifaEnvironment.SetArtasset(this.PhotoTemplateFileName(), this.PhotoDdsFileName(), this.Id, bitmap);
        }

        public bool DeletePhoto()
        {
            return FifaEnvironment.DeleteFromZdata(this.PhotoBigFileName());
        }

        public void SaveReferee(Record r)
        {
            r.IntField[FI.referee_refereeid] = this.Id;
            r.IntField[FI.referee_birthdate] = FifaUtil.ConvertFromDate(this.m_birthdate);
            r.StringField[FI.referee_firstname] = this.m_firstname;
            r.StringField[FI.referee_surname] = this.m_surname;
            r.StringField[FI.referee_firstname] = this.m_firstname;
            r.StringField[FI.referee_surname] = this.m_surname;
            r.IntField[FI.referee_nationalitycode] = this.m_nationalitycode;
            r.IntField[FI.referee_leagueid] = this.GetMainLeague();
            r.IntField[FI.referee_height] = this.m_height;
            r.IntField[FI.referee_weight] = this.m_weight;
            r.IntField[FI.referee_bodytypecode] = this.m_bodytypecode + 1;
            r.IntField[FI.referee_shoedesigncode] = this.m_shoedesigncode;
            r.IntField[FI.referee_shoecolorcode1] = this.m_shoecolorcode1;
            r.IntField[FI.referee_shoecolorcode2] = this.m_shoecolorcode2;
            r.IntField[FI.referee_shoetypecode] = this.m_shoetypecode;
            r.IntField[FI.referee_jerseysleevelengthcode] = this.m_jerseysleevelengthcode;
            r.IntField[FI.referee_eyecolorcode] = this.m_eyecolorcode;
            r.IntField[FI.referee_eyebrowcode] = this.m_eyebrowcode;
            r.IntField[FI.referee_facialhairtypecode] = this.m_facialhairtypecode;
            r.IntField[FI.referee_facialhaircolorcode] = this.m_facialhaircolorcode;
            r.IntField[FI.referee_hairtypecode] = this.m_hairtypecode;
            r.IntField[FI.referee_haircolorcode] = this.m_haircolorcode;
            r.IntField[FI.referee_headtypecode] = this.m_headtypecode;
            r.IntField[FI.referee_headclasscode] = this.m_headclasscode;
            r.IntField[FI.referee_sideburnscode] = this.m_sideburnscode;
            r.IntField[FI.referee_skintypecode] = this.m_skintypecode;
            r.IntField[FI.referee_skintonecode] = this.m_skintonecode;
            r.IntField[FI.referee_stylecode] = this.m_stylecode;
            r.IntField[FI.referee_cardstrictness] = this.m_cardstrictness;
            r.IntField[FI.referee_foulstrictness] = this.m_foulstrictness;
            r.IntField[FI.referee_homecitycode] = this.m_homecitycode;
            r.IntField[FI.referee_sockheightcode] = this.m_sockheightcode;
            r.IntField[FI.referee_haireffecttypecode] = this.m_haireffecttypecode;
            r.IntField[FI.referee_hairlinecode] = this.m_hairlinecode;
            r.IntField[FI.referee_hairpartcode] = this.m_hairpartcode;
            r.IntField[FI.referee_hairstateid] = this.m_hairstateid;
            r.IntField[FI.referee_hairvariationid] = this.m_hairvariationid;
            r.IntField[FI.referee_sweatid] = this.m_sweatid;
            r.IntField[FI.referee_wrinkleid] = this.m_wrinkleid;
            r.IntField[FI.referee_proxyhaircolorid] = this.m_proxyhaircolorid;
            r.IntField[FI.referee_proxyheadclass] = this.m_proxyheadclass;
            if (FI.referee_isreal < 0)
                return;
            r.IntField[FI.referee_isreal] = this.m_isreal;
        }

        public void SaveLeagueRefereeLinks(Record r, int index)
        {
            r.IntField[FI.leaguerefereelinks_refereeid] = this.Id;
            r.IntField[FI.leaguerefereelinks_leagueid] = this.m_leagueids[index];
        }

        public void BuildHairPartsTextures()
        {
            if (this.m_HairColorTextureBitmap != null && this.m_HairAlfaTextureBitmap != null && (this.m_HairColorTextureBitmap != null && this.m_HairAlfaTextureBitmap != null))
            {
                GraphicUtil.GetAlfaFromChannel((Bitmap)this.m_HairColorTextureBitmap.Clone(), this.m_HairAlfaTextureBitmap, 2);
                GraphicUtil.GetAlfaFromChannel((Bitmap)this.m_HairColorTextureBitmap.Clone(), this.m_HairAlfaTextureBitmap, 1);
            }
        }

        public bool CreateHead3D(string xFileName)
        {
            this.BuildHairPartsTextures();
            Rx3File headModel = this.GetHeadModel();
            /*if (this.m_FaceTextureBitmap == null || headModel == null)
                return false;
            Model3D model3D1 = new Model3D(headModel.Rx3IndexArrays[0], headModel.Rx3VertexArrays[0], this.m_FaceTextureBitmap);
            if (this.m_EyesTextureBitmap == null || headModel == null)
                return false;
            Model3D model3D2 = new Model3D(headModel.Rx3IndexArrays[0], headModel.Rx3VertexArrays[0], this.m_EyesTextureBitmap);
            Rx3File hairModel = this.GetHairModel();
            if (this.m_FaceTextureBitmap == null || hairModel == null)
                return false;
            Model3D model3D3 = new Model3D(hairModel.Rx3IndexArrays[0], hairModel.Rx3VertexArrays[0], this.m_HairColorTextureBitmap);*/
            return true;
        }

        public void RandomizeCaucasianAppearance()
        {
            this.m_headtypecode = Referee.m_Randomizer.Next(1, 11) > 7 ? GenericHead.c_LatinModels[Referee.m_Randomizer.Next(0, GenericHead.c_LatinModels.Length)] : GenericHead.c_CaucasicModels[Referee.m_Randomizer.Next(0, GenericHead.c_CaucasicModels.Length)];
            this.m_hairtypecode = this.c_RefereHair[Referee.m_Randomizer.Next(0, this.c_RefereHair.Length)];
            this.m_haircolorcode = Referee.m_Randomizer.Next(0, 8);
            this.m_sideburnscode = Referee.m_Randomizer.Next(0, 2);
            this.m_skintonecode = Referee.m_Randomizer.Next(1, 5);
            if (this.m_skintonecode == 1)
                this.m_skintonecode = 2;
            if (this.m_skintonecode == 3)
                this.m_skintonecode = 2;
            this.m_skintypecode = 2;
            this.m_eyecolorcode = Referee.m_Randomizer.Next(1, 8);
            this.m_facialhairtypecode = Referee.m_Randomizer.Next(0, 10);
            if (this.m_facialhairtypecode == 2 || this.m_facialhairtypecode > 7)
                this.m_facialhairtypecode = 0;
            if (this.m_facialhairtypecode == 2)
                this.m_facialhairtypecode = 0;
            this.m_facialhaircolorcode = this.c_HairToFacial[this.m_haircolorcode];
        }

        public void RandomizeAsiaticAppearance()
        {
            this.m_headtypecode = Referee.m_Randomizer.Next(1, 11) > 9 ? GenericHead.c_CaucasicModels[Referee.m_Randomizer.Next(0, GenericHead.c_CaucasicModels.Length)] : GenericHead.c_AsiaticModels[Referee.m_Randomizer.Next(0, GenericHead.c_AsiaticModels.Length)];
            this.m_hairtypecode = this.c_RefereHair[Referee.m_Randomizer.Next(0, this.c_RefereHair.Length)];
            this.m_haircolorcode = Referee.m_Randomizer.Next(1, 6);
            if (this.m_haircolorcode == 2 || this.m_haircolorcode == 4)
                this.m_haircolorcode = 1;
            if (this.m_haircolorcode == 3)
                this.m_haircolorcode = 1;
            this.m_sideburnscode = Referee.m_Randomizer.Next(0, 2);
            this.m_skintonecode = Referee.m_Randomizer.Next(2, 7);
            if (this.m_skintonecode == 3)
                this.m_skintonecode = 4;
            this.m_skintypecode = 2;
            this.m_eyecolorcode = Referee.m_Randomizer.Next(3, 8);
            this.m_facialhairtypecode = Referee.m_Randomizer.Next(0, 10);
            if (this.m_facialhairtypecode == 2 || this.m_facialhairtypecode > 7)
                this.m_facialhairtypecode = 0;
            this.m_facialhaircolorcode = this.c_HairToFacial[this.m_haircolorcode];
        }

        public void RandomizeAfricanAppearance()
        {
            this.m_headtypecode = Referee.m_Randomizer.Next(1, 11) > 7 ? GenericHead.c_LatinModels[Referee.m_Randomizer.Next(0, GenericHead.c_LatinModels.Length)] : GenericHead.c_AfricanModels[Referee.m_Randomizer.Next(0, GenericHead.c_AfricanModels.Length)];
            this.m_hairtypecode = this.c_RefereHair[Referee.m_Randomizer.Next(0, this.c_RefereHair.Length)];
            this.m_haircolorcode = 1;
            this.m_sideburnscode = Referee.m_Randomizer.Next(0, 2);
            this.m_skintonecode = Referee.m_Randomizer.Next(6, 11);
            if (this.m_skintonecode == 7)
                this.m_skintonecode = 8;
            this.m_skintypecode = 2;
            this.m_eyecolorcode = Referee.m_Randomizer.Next(3, 5);
            this.m_facialhairtypecode = Referee.m_Randomizer.Next(0, 10);
            if (this.m_facialhairtypecode == 2 || this.m_facialhairtypecode > 7)
                this.m_facialhairtypecode = 0;
            if (this.m_facialhairtypecode == 2)
                this.m_facialhairtypecode = 0;
            this.m_facialhaircolorcode = this.c_HairToFacial[this.m_haircolorcode];
        }

        public void RandomizeLatinAppearance()
        {
            this.m_headtypecode = Referee.m_Randomizer.Next(1, 11) > 7 ? GenericHead.c_CaucasicModels[Referee.m_Randomizer.Next(0, GenericHead.c_CaucasicModels.Length)] : GenericHead.c_LatinModels[Referee.m_Randomizer.Next(0, GenericHead.c_LatinModels.Length)];
            this.m_hairtypecode = this.c_RefereHair[Referee.m_Randomizer.Next(0, this.c_RefereHair.Length)];
            this.m_haircolorcode = 1;
            this.m_sideburnscode = Referee.m_Randomizer.Next(0, 2);
            this.m_skintonecode = Referee.m_Randomizer.Next(4, 7);
            this.m_skintypecode = 2;
            this.m_eyecolorcode = Referee.m_Randomizer.Next(3, 8);
            this.m_facialhairtypecode = Referee.m_Randomizer.Next(0, 10);
            if (this.m_facialhairtypecode == 2 || this.m_facialhairtypecode > 7)
                this.m_facialhairtypecode = 0;
            if (this.m_facialhairtypecode == 2)
                this.m_facialhairtypecode = 0;
            this.m_facialhaircolorcode = this.c_HairToFacial[this.m_haircolorcode];
        }
    }
}
