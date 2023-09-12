// Original code created by Rinaldo

using Microsoft.DirectX.Direct3D;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace FifaLibrary
{
    public class Player : IdObject
    {
        private static int[,] c_RolesMap = new int[28, 28]
        {
      {
        100,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0
      },
      {
        0,
        100,
        30,
        85,
        90,
        95,
        90,
        85,
        80,
        50,
        50,
        50,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5
      },
      {
        0,
        50,
        100,
        80,
        70,
        50,
        50,
        50,
        75,
        5,
        5,
        5,
        50,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5
      },
      {
        0,
        80,
        50,
        100,
        95,
        90,
        85,
        80,
        50,
        50,
        50,
        30,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5
      },
      {
        0,
        85,
        40,
        95,
        100,
        95,
        90,
        85,
        50,
        50,
        50,
        30,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5
      },
      {
        0,
        90,
        30,
        90,
        95,
        100,
        95,
        90,
        30,
        50,
        50,
        50,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5
      },
      {
        0,
        85,
        20,
        85,
        90,
        95,
        100,
        95,
        60,
        30,
        30,
        50,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5
      },
      {
        0,
        80,
        20,
        80,
        85,
        90,
        95,
        100,
        70,
        30,
        30,
        50,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5
      },
      {
        0,
        50,
        75,
        70,
        50,
        50,
        70,
        80,
        100,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        50,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5
      },
      {
        0,
        5,
        20,
        15,
        10,
        5,
        5,
        5,
        5,
        100,
        90,
        85,
        90,
        85,
        80,
        75,
        70,
        25,
        25,
        25,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5
      },
      {
        0,
        5,
        10,
        15,
        20,
        10,
        5,
        5,
        5,
        95,
        100,
        95,
        80,
        85,
        90,
        85,
        80,
        25,
        25,
        25,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5
      },
      {
        0,
        5,
        5,
        5,
        10,
        15,
        20,
        15,
        10,
        85,
        90,
        100,
        70,
        75,
        80,
        95,
        90,
        25,
        25,
        25,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5
      },
      {
        0,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        85,
        70,
        60,
        100,
        95,
        90,
        85,
        80,
        90,
        70,
        70,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5
      },
      {
        0,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        90,
        70,
        60,
        95,
        100,
        95,
        90,
        85,
        85,
        80,
        75,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5
      },
      {
        0,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        80,
        90,
        80,
        90,
        95,
        100,
        95,
        90,
        80,
        90,
        80,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5
      },
      {
        0,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        60,
        80,
        90,
        85,
        90,
        95,
        100,
        95,
        75,
        80,
        85,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5
      },
      {
        0,
        5,
        40,
        5,
        5,
        5,
        5,
        30,
        70,
        60,
        70,
        80,
        80,
        85,
        90,
        95,
        100,
        70,
        70,
        90,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5
      },
      {
        0,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        25,
        25,
        25,
        75,
        80,
        75,
        70,
        65,
        100,
        95,
        90,
        90,
        85,
        80,
        60,
        20,
        20,
        20,
        20
      },
      {
        0,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        25,
        25,
        25,
        70,
        75,
        80,
        75,
        70,
        95,
        100,
        95,
        85,
        90,
        85,
        20,
        20,
        30,
        20,
        20
      },
      {
        0,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        25,
        25,
        25,
        65,
        70,
        75,
        80,
        75,
        90,
        95,
        100,
        80,
        85,
        90,
        20,
        20,
        20,
        20,
        60
      },
      {
        0,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        15,
        10,
        5,
        10,
        15,
        55,
        55,
        50,
        100,
        95,
        90,
        70,
        100,
        95,
        90,
        55
      },
      {
        0,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        15,
        10,
        5,
        10,
        15,
        50,
        60,
        50,
        95,
        100,
        95,
        50,
        95,
        100,
        95,
        50
      },
      {
        0,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        15,
        10,
        5,
        10,
        15,
        50,
        55,
        55,
        90,
        95,
        100,
        55,
        90,
        95,
        100,
        70
      },
      {
        0,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        50,
        10,
        5,
        10,
        15,
        60,
        40,
        40,
        60,
        50,
        50,
        100,
        90,
        80,
        85,
        95
      },
      {
        0,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        15,
        10,
        5,
        10,
        15,
        40,
        40,
        40,
        50,
        50,
        50,
        70,
        100,
        95,
        95,
        70
      },
      {
        0,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        15,
        10,
        5,
        10,
        15,
        40,
        40,
        40,
        50,
        50,
        50,
        60,
        95,
        100,
        95,
        60
      },
      {
        0,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        15,
        10,
        5,
        10,
        15,
        40,
        40,
        40,
        50,
        50,
        50,
        70,
        95,
        95,
        100,
        70
      },
      {
        0,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        5,
        15,
        10,
        5,
        10,
        50,
        40,
        40,
        60,
        50,
        50,
        60,
        95,
        85,
        80,
        90,
        100
      }
        };
        private static int[] c_GenericModels = new int[147]
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
      2012,
      2013,
      2014,
      3500,
      3501,
      3502,
      3503,
      3504,
      3505,
      4000,
      4001,
      4002,
      4003,
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
      3000,
      3001,
      3002,
      3003,
      3004,
      3005,
      4500,
      4501,
      4502,
      5000,
      5001,
      5002,
      5003
        };
        private static int[,] c_Attributes = new int[28, 4]
        {
      {
        99,
        20,
        20,
        20
      },
      {
        20,
        99,
        70,
        50
      },
      {
        20,
        90,
        70,
        50
      },
      {
        20,
        95,
        75,
        50
      },
      {
        20,
        99,
        75,
        50
      },
      {
        20,
        99,
        75,
        50
      },
      {
        20,
        99,
        75,
        50
      },
      {
        20,
        95,
        75,
        50
      },
      {
        20,
        90,
        70,
        50
      },
      {
        20,
        90,
        90,
        70
      },
      {
        20,
        90,
        90,
        70
      },
      {
        20,
        90,
        90,
        70
      },
      {
        20,
        75,
        99,
        85
      },
      {
        20,
        75,
        99,
        85
      },
      {
        20,
        75,
        99,
        85
      },
      {
        20,
        75,
        99,
        85
      },
      {
        20,
        75,
        99,
        85
      },
      {
        20,
        50,
        99,
        90
      },
      {
        20,
        50,
        99,
        90
      },
      {
        20,
        50,
        99,
        90
      },
      {
        20,
        50,
        80,
        99
      },
      {
        20,
        50,
        80,
        99
      },
      {
        20,
        50,
        80,
        99
      },
      {
        20,
        70,
        90,
        95
      },
      {
        20,
        50,
        80,
        99
      },
      {
        20,
        50,
        80,
        99
      },
      {
        20,
        50,
        80,
        99
      },
      {
        20,
        70,
        90,
        95
      }
        };
        public static Color[] s_GenericColors = new Color[13]
        {
      Color.FromArgb(180, 156, 114),
      Color.FromArgb(20, 20, 20),
      Color.FromArgb(135, 126, 100),
      Color.FromArgb(42, 35, 24),
      Color.FromArgb(168, 160, 128),
      Color.FromArgb(111, 91, 69),
      Color.FromArgb(75, 63, 49),
      Color.FromArgb(120, 85, 58),
      Color.FromArgb(160, 162, 155),
      Color.FromArgb(110, 115, 121),
      Color.FromArgb(77, 115, 70),
      Color.FromArgb(51, 80, 126),
      Color.FromArgb(110, 40, 30)
        };
        private static Random m_Randomizer = new Random();
        private static PlayerNames s_PlayerNames = (PlayerNames)null;
        public static Model3D s_Model3DHead = (Model3D)null;
        public static Model3D s_Model3DEyes = (Model3D)null;
        public static Model3D s_Model3DHairPart4 = (Model3D)null;
        public static Model3D s_Model3DHairPart5 = (Model3D)null;
        private static int[] s_MeanLevels = new int[7]
        {
      52,
      59,
      66,
      72,
      77,
      82,
      88
        };
        public TeamList m_PlayingForTeams = new TeamList();
        private Bitmap m_EyesTextureBitmap;
        private Bitmap[] m_FaceTextureBitmaps;
        private Bitmap m_HairColorTextureBitmap;
        private Bitmap m_HairAlfaTextureBitmap;
        private Rx3File m_HeadModelFile;
        private Rx3File m_HairModelFile;
        public bool m_HasSpecificPhoto;
        public int m_assetid;
        private string m_firstname;
        private string m_lastname;
        private string m_audioname;
        private int m_commentaryid;
        public string m_commonname;
        public string m_playerjerseyname;
        private int m_firstnameid;
        private int m_lastnameid;
        private int m_commonnameid;
        private int m_playerjerseynameid;
        private DateTime m_birthdate;
        public DateTime m_playerjointeamdate;
        private int m_contractvaliduntil;
        private int m_height;
        private int m_weight;
        private int m_nationality;
        private Country m_Country;
        private int m_eyecolorcode;
        private int m_eyebrowcode;
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
        private int m_jerseystylecode;
        private int m_hasseasonaljersey;
        private int m_animfreekickstartposcode;
        private int m_animpenaltieskickstylecode;
        private int m_animpenaltiesmotionstylecode;
        private int m_animpenaltiesstartposcode;
        private int m_accessorycode1;
        private int m_accessorycolourcode1;
        private int m_accessorycode2;
        private int m_accessorycolourcode2;
        private int m_accessorycode3;
        private int m_accessorycolourcode3;
        private int m_accessorycode4;
        private int m_accessorycolourcode4;
        private int m_shoetypecode;
        private int m_shoedesigncode;
        private int m_shoecolorcode1;
        private int m_shoecolorcode2;
        private int m_preferredposition1;
        private int m_preferredposition2;
        private int m_preferredposition3;
        private int m_preferredposition4;
        private int m_preferredfoot;
        private int m_weakfootabilitytypecode;
        private int m_acceleration;
        private int m_aggression;
        private int m_gkglovetypecode;
        private int m_agility;
        private int m_balance;
        private int m_gkkicking;
        private int m_gkkickstyle;
        private int m_jumping;
        private int m_penalties;
        private int m_vision;
        private int m_volleys;
        private int m_skillmoves;
        private int m_usercaneditname;
        private int m_sprintspeed;
        private int m_stamina;
        private int m_strength;
        private int m_marking;
        private int m_standingtackle;
        private int m_slidingtackle;
        private int m_ballcontrol;
        private int m_dribbling;
        private int m_crossing;
        private int m_headingaccuracy;
        private int m_shortpassing;
        private int m_longpassing;
        private int m_longshots;
        private int m_finishing;
        private int m_shotpower;
        private int m_reactions;
        private int m_gkreflexes;
        private int m_gkhandling;
        private int m_gkdiving;
        private int m_gkpositioning;
        private int m_freekickaccuracy;
        private int m_potential;
        private int m_positioning;
        private int m_overallrating;
        private bool m_Inflexible;
        private bool m_GkOneOnOne;
        private bool m_CrowdFavorite;
        private bool m_SecondWind;
        private bool m_AcrobaticClearance;
        private bool m_Longthrows;
        private bool m_PowerfulFreeKicks;
        private bool m_Diver;
        private bool m_InjuryFree;
        private bool m_InjuryProne;
        private bool m_AvoidsWeakFoot;
        private bool m_Divesintotackles;
        private bool m_BeatDefensiveLine;
        private bool m_Selfish;
        private bool m_Leadership;
        private bool m_ArguesWithOfficials;
        private bool m_Earlycrosser;
        private bool m_FinesseShot;
        private bool m_Flair;
        private bool m_LongPasser;
        private bool m_LongShotTaker;
        private bool m_Technicaldribbler;
        private bool m_Playmaker;
        private bool m_Pushesupforcorners;
        private bool m_Puncher;
        private bool m_GkLongThrower;
        private bool m_PowerHeader;
        private bool m_GiantThrow;
        private bool m_OutsideFootShot;
        private bool m_SwervePasser;
        private bool m_HighClubIdentification;
        private bool m_TeamPlayer;
        private bool m_FancyFeet;
        private bool m_FancyPasses;
        private bool m_FancyFlicks;
        private bool m_StutterPenalty;
        private bool m_ChipperPenalty;
        private bool m_BycicleKick;
        private bool m_DivingHeader;
        private bool m_DrivenPass;
        private bool m_GkFlatKick;
        private int m_curve;
        private int m_internationalrep;
        private int m_finishingcode1;
        private int m_finishingcode2;
        private int m_runningcode1;
        private int m_runningcode2;
        private int m_gksavetype;
        private int m_faceposercode;
        private int m_isretiring;
        private int m_socklengthcode;
        private int m_hashighqualityhead;
        private int m_attackingworkrate;
        private int m_defensiveworkrate;
        private bool m_shortstyle;
        private int m_interceptions;
        private bool m_jerseyfit;
        private int m_teamidloanedfrom;
        private Team m_TeamLoanedFrom;
        private int m_previousteamid;
        private Team m_PreviousTeam;
        public bool m_IsLoaned;
        private DateTime m_loandateend;

        public static PlayerNames PlayerNames
        {
            get
            {
                return Player.s_PlayerNames;
            }
            set
            {
                Player.s_PlayerNames = value;
            }
        }

        public bool HasSpecificHeadModel
        {
            get
            {
                return this.m_headclasscode == 0;
            }
        }

        public Bitmap EyesTextureBitmap
        {
            get
            {
                return this.m_EyesTextureBitmap;
            }
        }

        public Bitmap[] FaceTextureBitmap
        {
            get
            {
                return this.m_FaceTextureBitmaps;
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

        public Team IsInTopLeague()
        {
            return this.m_PlayingForTeams.IsInTopLeague();
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

        public string lastname
        {
            get
            {
                return this.m_lastname;
            }
            set
            {
                this.m_lastname = value;
            }
        }

        public string audioname
        {
            get
            {
                return this.m_audioname;
            }
            set
            {
                this.m_audioname = value;
            }
        }

        public int commentaryid
        {
            get
            {
                return this.m_commentaryid;
            }
            set
            {
                this.m_commentaryid = value;
            }
        }

        public string Name
        {
            get
            {
                return this.m_commonname != null && this.m_commonname != string.Empty ? this.m_commonname : this.m_lastname;
            }
        }

        public string commonname
        {
            get
            {
                return this.m_commonname;
            }
            set
            {
                this.m_commonname = value;
            }
        }

        public string playerjerseyname
        {
            get
            {
                return this.m_playerjerseyname;
            }
            set
            {
                this.m_playerjerseyname = value;
            }
        }

        public int firstnameid
        {
            get
            {
                return this.m_firstnameid;
            }
            set
            {
                this.m_firstnameid = value;
            }
        }

        public int lastnameid
        {
            get
            {
                return this.m_lastnameid;
            }
            set
            {
                this.m_lastnameid = value;
            }
        }

        public int commonnameid
        {
            get
            {
                return this.m_commonnameid;
            }
            set
            {
                this.m_commonnameid = value;
            }
        }

        public int playerjerseynameid
        {
            get
            {
                return this.m_playerjerseynameid;
            }
            set
            {
                this.m_playerjerseynameid = value;
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

        public DateTime joindate
        {
            get
            {
                return this.m_playerjointeamdate;
            }
            set
            {
                this.m_playerjointeamdate = value;
            }
        }

        public int contractvaliduntil
        {
            get
            {
                return this.m_contractvaliduntil;
            }
            set
            {
                this.m_contractvaliduntil = value;
            }
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

        public int nationality
        {
            get
            {
                return this.m_nationality;
            }
            set
            {
                this.m_nationality = value;
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
                    this.m_nationality = this.Country.Id;
                else
                    this.m_nationality = 0;
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
                this.m_FaceTextureBitmaps = (Bitmap[])null;
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

        public int headclasscode
        {
            get
            {
                return this.m_headclasscode;
            }
            set
            {
                this.m_headclasscode = value;
                this.m_HairAlfaTextureBitmap = (Bitmap)null;
                this.m_HairColorTextureBitmap = (Bitmap)null;
                this.m_FaceTextureBitmaps = (Bitmap[])null;
                this.m_EyesTextureBitmap = (Bitmap)null;
                this.m_HeadModelFile = (Rx3File)null;
                this.m_HairModelFile = (Rx3File)null;
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
                this.m_FaceTextureBitmaps = (Bitmap[])null;
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
                this.m_FaceTextureBitmaps = (Bitmap[])null;
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
                this.m_FaceTextureBitmaps = (Bitmap[])null;
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
                this.m_FaceTextureBitmaps = (Bitmap[])null;
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
                this.m_FaceTextureBitmaps = (Bitmap[])null;
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

        public int jerseystylecode
        {
            get
            {
                return this.m_jerseystylecode;
            }
            set
            {
                this.m_jerseystylecode = value;
            }
        }

        public int hasseasonaljersey
        {
            get
            {
                return this.m_hasseasonaljersey;
            }
            set
            {
                this.m_hasseasonaljersey = value;
            }
        }

        public int animfreekickstartposcode
        {
            get
            {
                return this.m_animfreekickstartposcode;
            }
            set
            {
                this.m_animfreekickstartposcode = value;
            }
        }

        public int animpenaltieskickstylecode
        {
            get
            {
                return this.m_animpenaltieskickstylecode;
            }
            set
            {
                this.m_animpenaltieskickstylecode = value;
            }
        }

        public int animpenaltiesmotionstylecode
        {
            get
            {
                return this.m_animpenaltiesmotionstylecode;
            }
            set
            {
                this.m_animpenaltiesmotionstylecode = value;
            }
        }

        public int animpenaltiesstartposcode
        {
            get
            {
                return this.m_animpenaltiesstartposcode;
            }
            set
            {
                this.m_animpenaltiesstartposcode = value;
            }
        }

        public int accessorycode1
        {
            get
            {
                return this.m_accessorycode1;
            }
            set
            {
                this.m_accessorycode1 = value;
            }
        }

        public int accessorycolourcode1
        {
            get
            {
                return this.m_accessorycolourcode1;
            }
            set
            {
                this.m_accessorycolourcode1 = value;
            }
        }

        public int accessorycode2
        {
            get
            {
                return this.m_accessorycode2;
            }
            set
            {
                this.m_accessorycode2 = value;
            }
        }

        public int accessorycolourcode2
        {
            get
            {
                return this.m_accessorycolourcode2;
            }
            set
            {
                this.m_accessorycolourcode2 = value;
            }
        }

        public int accessorycode3
        {
            get
            {
                return this.m_accessorycode3;
            }
            set
            {
                this.m_accessorycode3 = value;
            }
        }

        public int accessorycolourcode3
        {
            get
            {
                return this.m_accessorycolourcode3;
            }
            set
            {
                this.m_accessorycolourcode3 = value;
            }
        }

        public int accessorycode4
        {
            get
            {
                return this.m_accessorycode4;
            }
            set
            {
                this.m_accessorycode4 = value;
            }
        }

        public int accessorycolourcode4
        {
            get
            {
                return this.m_accessorycolourcode4;
            }
            set
            {
                this.m_accessorycolourcode4 = value;
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

        public int preferredposition1
        {
            get
            {
                return this.m_preferredposition1;
            }
            set
            {
                this.m_preferredposition1 = value;
            }
        }

        public int preferredposition2
        {
            get
            {
                return this.m_preferredposition2;
            }
            set
            {
                this.m_preferredposition2 = value;
            }
        }

        public int preferredposition3
        {
            get
            {
                return this.m_preferredposition3;
            }
            set
            {
                this.m_preferredposition3 = value;
            }
        }

        public int preferredposition4
        {
            get
            {
                return this.m_preferredposition4;
            }
            set
            {
                this.m_preferredposition4 = value;
            }
        }

        public int preferredfoot
        {
            get
            {
                return this.m_preferredfoot;
            }
            set
            {
                this.m_preferredfoot = value;
            }
        }

        public int weakfootabilitytypecode
        {
            get
            {
                return this.m_weakfootabilitytypecode - 1;
            }
            set
            {
                this.m_weakfootabilitytypecode = value + 1;
            }
        }

        public int acceleration
        {
            get
            {
                return this.m_acceleration;
            }
            set
            {
                this.m_acceleration = value;
            }
        }

        public int aggression
        {
            get
            {
                return this.m_aggression;
            }
            set
            {
                this.m_aggression = value;
            }
        }

        public int gkglovetypecode
        {
            get
            {
                return this.m_gkglovetypecode;
            }
            set
            {
                this.m_gkglovetypecode = value;
            }
        }

        public int agility
        {
            get
            {
                return this.m_agility;
            }
            set
            {
                this.m_agility = value;
            }
        }

        public int balance
        {
            get
            {
                return this.m_balance;
            }
            set
            {
                this.m_balance = value;
            }
        }

        public int gkkicking
        {
            get
            {
                return this.m_gkkicking;
            }
            set
            {
                this.m_gkkicking = value;
            }
        }

        public int gkkickstyle
        {
            get
            {
                return this.m_gkkickstyle;
            }
            set
            {
                this.m_gkkickstyle = value;
            }
        }

        public int jumping
        {
            get
            {
                return this.m_jumping;
            }
            set
            {
                this.m_jumping = value;
            }
        }

        public int penalties
        {
            get
            {
                return this.m_penalties;
            }
            set
            {
                this.m_penalties = value;
            }
        }

        public int vision
        {
            get
            {
                return this.m_vision;
            }
            set
            {
                this.m_vision = value;
            }
        }

        public int volleys
        {
            get
            {
                return this.m_volleys;
            }
            set
            {
                this.m_volleys = value;
            }
        }

        public int skillmoves
        {
            get
            {
                return this.m_skillmoves;
            }
            set
            {
                this.m_skillmoves = value;
            }
        }

        public int usercaneditname
        {
            get
            {
                return this.m_usercaneditname;
            }
            set
            {
                this.m_usercaneditname = value;
            }
        }

        public int sprintspeed
        {
            get
            {
                return this.m_sprintspeed;
            }
            set
            {
                this.m_sprintspeed = value;
            }
        }

        public int stamina
        {
            get
            {
                return this.m_stamina;
            }
            set
            {
                this.m_stamina = value;
            }
        }

        public int strength
        {
            get
            {
                return this.m_strength;
            }
            set
            {
                this.m_strength = value;
            }
        }

        public int marking
        {
            get
            {
                return this.m_marking;
            }
            set
            {
                this.m_marking = value;
            }
        }

        public int standingtackle
        {
            get
            {
                return this.m_standingtackle;
            }
            set
            {
                this.m_standingtackle = value;
            }
        }

        public int slidingtackle
        {
            get
            {
                return this.m_slidingtackle;
            }
            set
            {
                this.m_slidingtackle = value;
            }
        }

        public int ballcontrol
        {
            get
            {
                return this.m_ballcontrol;
            }
            set
            {
                this.m_ballcontrol = value;
            }
        }

        public int dribbling
        {
            get
            {
                return this.m_dribbling;
            }
            set
            {
                this.m_dribbling = value;
            }
        }

        public int crossing
        {
            get
            {
                return this.m_crossing;
            }
            set
            {
                this.m_crossing = value;
            }
        }

        public int headingaccuracy
        {
            get
            {
                return this.m_headingaccuracy;
            }
            set
            {
                this.m_headingaccuracy = value;
            }
        }

        public int shortpassing
        {
            get
            {
                return this.m_shortpassing;
            }
            set
            {
                this.m_shortpassing = value;
            }
        }

        public int longpassing
        {
            get
            {
                return this.m_longpassing;
            }
            set
            {
                this.m_longpassing = value;
            }
        }

        public int longshots
        {
            get
            {
                return this.m_longshots;
            }
            set
            {
                this.m_longshots = value;
            }
        }

        public int finishing
        {
            get
            {
                return this.m_finishing;
            }
            set
            {
                this.m_finishing = value;
            }
        }

        public int shotpower
        {
            get
            {
                return this.m_shotpower;
            }
            set
            {
                this.m_shotpower = value;
            }
        }

        public int reactions
        {
            get
            {
                return this.m_reactions;
            }
            set
            {
                this.m_reactions = value;
            }
        }

        public int gkreflexes
        {
            get
            {
                return this.m_gkreflexes;
            }
            set
            {
                this.m_gkreflexes = value;
            }
        }

        public int gkhandling
        {
            get
            {
                return this.m_gkhandling;
            }
            set
            {
                this.m_gkhandling = value;
            }
        }

        public int gkdiving
        {
            get
            {
                return this.m_gkdiving;
            }
            set
            {
                this.m_gkdiving = value;
            }
        }

        public int gkpositioning
        {
            get
            {
                return this.m_gkpositioning;
            }
            set
            {
                this.m_gkpositioning = value;
            }
        }

        public int freekickaccuracy
        {
            get
            {
                return this.m_freekickaccuracy;
            }
            set
            {
                this.m_freekickaccuracy = value;
            }
        }

        public int potential
        {
            get
            {
                return this.m_potential;
            }
            set
            {
                this.m_potential = value;
            }
        }

        public int positioning
        {
            get
            {
                return this.m_positioning;
            }
            set
            {
                this.m_positioning = value;
            }
        }

        public int overallrating
        {
            get
            {
                return this.m_overallrating;
            }
            set
            {
                this.m_overallrating = value;
            }
        }

        public bool Inflexible
        {
            get
            {
                return this.m_Inflexible;
            }
            set
            {
                this.m_Inflexible = value;
            }
        }

        public bool GkOneOnOne
        {
            get
            {
                return this.m_GkOneOnOne;
            }
            set
            {
                this.m_GkOneOnOne = value;
            }
        }

        public bool CrowdFavorite
        {
            get
            {
                return this.m_CrowdFavorite;
            }
            set
            {
                this.m_CrowdFavorite = value;
            }
        }

        public bool SecondWind
        {
            get
            {
                return this.m_SecondWind;
            }
            set
            {
                this.m_SecondWind = value;
            }
        }

        public bool AcrobaticClearance
        {
            get
            {
                return this.m_AcrobaticClearance;
            }
            set
            {
                this.m_AcrobaticClearance = value;
            }
        }

        public bool Longthrows
        {
            get
            {
                return this.m_Longthrows;
            }
            set
            {
                this.m_Longthrows = value;
            }
        }

        public bool PowerfulFreeKicks
        {
            get
            {
                return this.m_PowerfulFreeKicks;
            }
            set
            {
                this.m_PowerfulFreeKicks = value;
            }
        }

        public bool Diver
        {
            get
            {
                return this.m_Diver;
            }
            set
            {
                this.m_Diver = value;
            }
        }

        public bool InjuryFree
        {
            get
            {
                return this.m_InjuryFree;
            }
            set
            {
                this.m_InjuryFree = value;
            }
        }

        public bool InjuryProne
        {
            get
            {
                return this.m_InjuryProne;
            }
            set
            {
                this.m_InjuryProne = value;
            }
        }

        public bool AvoidsWeakFoot
        {
            get
            {
                return this.m_AvoidsWeakFoot;
            }
            set
            {
                this.m_AvoidsWeakFoot = value;
            }
        }

        public bool Divesintotackles
        {
            get
            {
                return this.m_Divesintotackles;
            }
            set
            {
                this.m_Divesintotackles = value;
            }
        }

        public bool BeatDefensiveLine
        {
            get
            {
                return this.m_BeatDefensiveLine;
            }
            set
            {
                this.m_BeatDefensiveLine = value;
            }
        }

        public bool Selfish
        {
            get
            {
                return this.m_Selfish;
            }
            set
            {
                this.m_Selfish = value;
            }
        }

        public bool Leadership
        {
            get
            {
                return this.m_Leadership;
            }
            set
            {
                this.m_Leadership = value;
            }
        }

        public bool ArguesWithOfficials
        {
            get
            {
                return this.m_ArguesWithOfficials;
            }
            set
            {
                this.m_ArguesWithOfficials = value;
            }
        }

        public bool Earlycrosser
        {
            get
            {
                return this.m_Earlycrosser;
            }
            set
            {
                this.m_Earlycrosser = value;
            }
        }

        public bool FinesseShot
        {
            get
            {
                return this.m_FinesseShot;
            }
            set
            {
                this.m_FinesseShot = value;
            }
        }

        public bool Flair
        {
            get
            {
                return this.m_Flair;
            }
            set
            {
                this.m_Flair = value;
            }
        }

        public bool LongPasser
        {
            get
            {
                return this.m_LongPasser;
            }
            set
            {
                this.m_LongPasser = value;
            }
        }

        public bool LongShotTaker
        {
            get
            {
                return this.m_LongShotTaker;
            }
            set
            {
                this.m_LongShotTaker = value;
            }
        }

        public bool Technicaldribbler
        {
            get
            {
                return this.m_Technicaldribbler;
            }
            set
            {
                this.m_Technicaldribbler = value;
            }
        }

        public bool Playmaker
        {
            get
            {
                return this.m_Playmaker;
            }
            set
            {
                this.m_Playmaker = value;
            }
        }

        public bool Pushesupforcorners
        {
            get
            {
                return this.m_Pushesupforcorners;
            }
            set
            {
                this.m_Pushesupforcorners = value;
            }
        }

        public bool Puncher
        {
            get
            {
                return this.m_Puncher;
            }
            set
            {
                this.m_Puncher = value;
            }
        }

        public bool GkLongThrower
        {
            get
            {
                return this.m_GkLongThrower;
            }
            set
            {
                this.m_GkLongThrower = value;
            }
        }

        public bool PowerHeader
        {
            get
            {
                return this.m_PowerHeader;
            }
            set
            {
                this.m_PowerHeader = value;
            }
        }

        public bool GiantThrow
        {
            get
            {
                return this.m_GiantThrow;
            }
            set
            {
                this.m_GiantThrow = value;
            }
        }

        public bool OutsideFootShot
        {
            get
            {
                return this.m_OutsideFootShot;
            }
            set
            {
                this.m_OutsideFootShot = value;
            }
        }

        public bool SwervePasser
        {
            get
            {
                return this.m_SwervePasser;
            }
            set
            {
                this.m_SwervePasser = value;
            }
        }

        public bool HighClubIdentification
        {
            get
            {
                return this.m_HighClubIdentification;
            }
            set
            {
                this.m_HighClubIdentification = value;
            }
        }

        public bool TeamPlayer
        {
            get
            {
                return this.m_TeamPlayer;
            }
            set
            {
                this.m_TeamPlayer = value;
            }
        }

        public bool FancyFeet
        {
            get
            {
                return this.m_FancyFeet;
            }
            set
            {
                this.m_FancyFeet = value;
            }
        }

        public bool FancyPasses
        {
            get
            {
                return this.m_FancyPasses;
            }
            set
            {
                this.m_FancyPasses = value;
            }
        }

        public bool FancyFlicks
        {
            get
            {
                return this.m_FancyFlicks;
            }
            set
            {
                this.m_FancyFlicks = value;
            }
        }

        public bool StutterPenalty
        {
            get
            {
                return this.m_StutterPenalty;
            }
            set
            {
                this.m_StutterPenalty = value;
            }
        }

        public bool ChipperPenalty
        {
            get
            {
                return this.m_ChipperPenalty;
            }
            set
            {
                this.m_ChipperPenalty = value;
            }
        }

        public bool BycicleKick
        {
            get
            {
                return this.m_BycicleKick;
            }
            set
            {
                this.m_BycicleKick = value;
            }
        }

        public bool DivingHeader
        {
            get
            {
                return this.m_DivingHeader;
            }
            set
            {
                this.m_DivingHeader = value;
            }
        }

        public bool DrivenPass
        {
            get
            {
                return this.m_DrivenPass;
            }
            set
            {
                this.m_DrivenPass = value;
            }
        }

        public bool GkFlatKick
        {
            get
            {
                return this.m_GkFlatKick;
            }
            set
            {
                this.m_GkFlatKick = value;
            }
        }

        public int curve
        {
            get
            {
                return this.m_curve;
            }
            set
            {
                this.m_curve = value;
            }
        }

        public int internationalrep
        {
            get
            {
                return this.m_internationalrep;
            }
            set
            {
                this.m_internationalrep = value;
            }
        }

        public int finishingcode1
        {
            get
            {
                return this.m_finishingcode1;
            }
            set
            {
                this.m_finishingcode1 = value;
            }
        }

        public int finishingcode2
        {
            get
            {
                return this.m_finishingcode2;
            }
            set
            {
                this.m_finishingcode2 = value;
            }
        }

        public int runningcode1
        {
            get
            {
                return this.m_runningcode1;
            }
            set
            {
                this.m_runningcode1 = value;
            }
        }

        public int runningcode2
        {
            get
            {
                return this.m_runningcode2;
            }
            set
            {
                this.m_runningcode2 = value;
            }
        }

        public int gksavetype
        {
            get
            {
                return this.m_gksavetype;
            }
            set
            {
                this.m_gksavetype = value;
            }
        }

        public int faceposercode
        {
            get
            {
                return this.m_faceposercode;
            }
            set
            {
                this.m_faceposercode = value;
            }
        }

        public int isretiring
        {
            get
            {
                return this.m_isretiring;
            }
            set
            {
                this.m_isretiring = value;
            }
        }

        public int socklengthcode
        {
            get
            {
                return this.m_socklengthcode;
            }
            set
            {
                this.m_socklengthcode = value;
            }
        }

        public int hashighqualityhead
        {
            get
            {
                return this.m_hashighqualityhead;
            }
            set
            {
                this.m_hashighqualityhead = value;
            }
        }

        public int attackingworkrate
        {
            get
            {
                return this.m_attackingworkrate;
            }
            set
            {
                this.m_attackingworkrate = value;
            }
        }

        public int defensiveworkrate
        {
            get
            {
                return this.m_defensiveworkrate;
            }
            set
            {
                this.m_defensiveworkrate = value;
            }
        }

        public bool TrainingPants
        {
            get
            {
                return this.m_shortstyle;
            }
            set
            {
                this.m_shortstyle = value;
            }
        }

        public int interceptions
        {
            get
            {
                return this.m_interceptions;
            }
            set
            {
                this.m_interceptions = value;
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

        public Team TeamLoanedFrom
        {
            get
            {
                return this.m_TeamLoanedFrom;
            }
            set
            {
                this.m_TeamLoanedFrom = value;
                this.m_teamidloanedfrom = this.m_TeamLoanedFrom != null ? this.m_TeamLoanedFrom.Id : 0;
            }
        }

        public Team PreviousTeam
        {
            get
            {
                return this.m_PreviousTeam;
            }
            set
            {
                this.m_PreviousTeam = value;
                this.m_previousteamid = this.m_PreviousTeam != null ? this.m_PreviousTeam.Id : 0;
            }
        }

        public bool IsLoaned
        {
            get
            {
                return this.m_teamidloanedfrom != 0;
            }
            set
            {
                if (value)
                {
                    if (this.m_TeamLoanedFrom == null)
                        this.TeamLoanedFrom = (Team)FifaEnvironment.Teams[0];
                    else
                        this.m_teamidloanedfrom = this.TeamLoanedFrom.Id;
                }
                else
                    this.m_teamidloanedfrom = 0;
            }
        }

        public DateTime loandateend
        {
            get
            {
                return this.m_loandateend;
            }
            set
            {
                this.m_loandateend = value;
            }
        }

        public override string ToString()
        {
            if (this.m_commonname != null && this.m_commonname != string.Empty)
                return this.m_commonname;
            return this.m_firstname != null && this.m_firstname != string.Empty ? this.m_lastname + " " + this.m_firstname : this.m_lastname + " [" + this.Id.ToString() + "]";
        }

        public string DatabaseString()
        {
            return this.ToString();
        }

        public Player(Record r)
          : base(r.IntField[FI.players_playerid])
        {
            this.Load(r);
        }

        public void UpdateNamesAndCommentary()
        {
            this.m_commentaryid = 900000;
            if (!Player.PlayerNames.TryGetValue(this.m_firstnameid, out this.m_firstname, true))
                this.m_firstname = string.Empty;
            int commentaryid1;
            if (!Player.PlayerNames.TryGetValue(this.m_lastnameid, out this.m_lastname, out commentaryid1, true))
                this.m_lastname = string.Empty;
            int commentaryid2;
            if (!Player.PlayerNames.TryGetValue(this.m_commonnameid, out this.m_commonname, out commentaryid2, true))
                this.m_commonname = string.Empty;
            if (this.m_commonname != string.Empty)
            {
                this.m_commentaryid = commentaryid2;
                this.m_audioname = this.m_commonname;
            }
            else if (this.m_lastname != string.Empty)
            {
                this.m_commentaryid = commentaryid1;
                this.m_audioname = this.m_lastname;
            }
            else
            {
                this.m_commentaryid = 900000;
                this.m_audioname = string.Empty;
            }
            if (Player.PlayerNames.TryGetValue(this.m_playerjerseynameid, out this.m_playerjerseyname, true))
                return;
            this.m_playerjerseyname = string.Empty;
        }

        public void Load(Record r)
        {
            this.m_headclasscode = r.GetAndCheckIntField(FI.players_headclasscode);
            this.m_firstnameid = r.IntField[FI.players_firstnameid];
            this.m_lastnameid = r.IntField[FI.players_lastnameid];
            this.m_commonnameid = r.IntField[FI.players_commonnameid];
            this.m_playerjerseynameid = r.IntField[FI.players_playerjerseynameid];
            this.UpdateNamesAndCommentary();
            DateTime dateTime = FifaUtil.ConvertToDate(r.GetAndCheckIntField(FI.players_birthdate));
            if (dateTime.Year < 1900)
                dateTime = new DateTime(1980, 1, 1);
            this.m_birthdate = dateTime;
            this.m_playerjointeamdate = FifaUtil.ConvertToDate(r.GetAndCheckIntField(FI.players_playerjointeamdate));
            this.m_contractvaliduntil = r.GetAndCheckIntField(FI.players_contractvaliduntil);
            this.m_height = r.GetAndCheckIntField(FI.players_height);
            this.m_weight = r.GetAndCheckIntField(FI.players_weight);
            this.m_preferredposition1 = r.GetAndCheckIntField(FI.players_preferredposition1);
            this.m_preferredposition2 = r.GetAndCheckIntField(FI.players_preferredposition2);
            this.m_preferredposition3 = r.GetAndCheckIntField(FI.players_preferredposition3);
            this.m_preferredposition4 = r.GetAndCheckIntField(FI.players_preferredposition4);
            this.m_preferredfoot = r.GetAndCheckIntField(FI.players_preferredfoot) - 1;
            this.m_bodytypecode = r.GetAndCheckIntField(FI.players_bodytypecode) - 1;
            this.m_shoecolorcode1 = r.GetAndCheckIntField(FI.players_shoecolorcode1);
            this.m_shoetypecode = r.GetAndCheckIntField(FI.players_shoetypecode);
            this.m_jerseysleevelengthcode = r.GetAndCheckIntField(FI.players_jerseysleevelengthcode);
            this.m_eyecolorcode = r.GetAndCheckIntField(FI.players_eyecolorcode);
            this.m_eyebrowcode = r.GetAndCheckIntField(FI.players_eyebrowcode);
            this.m_facialhairtypecode = r.GetAndCheckIntField(FI.players_facialhairtypecode);
            this.m_facialhaircolorcode = r.GetAndCheckIntField(FI.players_facialhaircolorcode);
            this.m_hairtypecode = r.GetAndCheckIntField(FI.players_hairtypecode);
            this.m_haircolorcode = r.GetAndCheckIntField(FI.players_haircolorcode);
            this.m_headtypecode = r.GetAndCheckIntField(FI.players_headtypecode);
            this.m_sideburnscode = r.GetAndCheckIntField(FI.players_sideburnscode);
            this.m_skintypecode = r.GetAndCheckIntField(FI.players_skintypecode);
            this.m_skintonecode = r.GetAndCheckIntField(FI.players_skintonecode);
            this.m_overallrating = r.GetAndCheckIntField(FI.players_overallrating);
            this.m_jerseystylecode = r.GetAndCheckIntField(FI.players_jerseystylecode);
            this.m_hasseasonaljersey = r.GetAndCheckIntField(FI.players_hasseasonaljersey);
            this.m_animfreekickstartposcode = r.GetAndCheckIntField(FI.players_animfreekickstartposcode);
            this.m_animpenaltieskickstylecode = r.GetAndCheckIntField(FI.players_animpenaltieskickstylecode);
            this.m_animpenaltiesmotionstylecode = r.GetAndCheckIntField(FI.players_animpenaltiesmotionstylecode);
            this.m_animpenaltiesstartposcode = r.GetAndCheckIntField(FI.players_animpenaltiesstartposcode);
            this.m_accessorycode1 = r.GetAndCheckIntField(FI.players_accessorycode1);
            this.m_accessorycolourcode1 = r.GetAndCheckIntField(FI.players_accessorycolourcode1);
            this.m_accessorycode2 = r.GetAndCheckIntField(FI.players_accessorycode2);
            this.m_accessorycolourcode2 = r.GetAndCheckIntField(FI.players_accessorycolourcode2);
            this.m_accessorycode3 = r.GetAndCheckIntField(FI.players_accessorycode3);
            this.m_accessorycolourcode3 = r.GetAndCheckIntField(FI.players_accessorycolourcode3);
            this.m_accessorycode4 = r.GetAndCheckIntField(FI.players_accessorycode4);
            this.m_accessorycolourcode4 = r.GetAndCheckIntField(FI.players_accessorycolourcode4);
            this.m_acceleration = r.GetAndCheckIntField(FI.players_acceleration);
            this.m_aggression = r.GetAndCheckIntField(FI.players_aggression);
            this.m_ballcontrol = r.GetAndCheckIntField(FI.players_ballcontrol);
            this.m_crossing = r.GetAndCheckIntField(FI.players_crossing);
            this.m_dribbling = r.GetAndCheckIntField(FI.players_dribbling);
            this.m_finishing = r.GetAndCheckIntField(FI.players_finishing);
            this.m_freekickaccuracy = r.GetAndCheckIntField(FI.players_freekickaccuracy);
            this.m_headingaccuracy = r.GetAndCheckIntField(FI.players_headingaccuracy);
            this.m_longpassing = r.GetAndCheckIntField(FI.players_longpassing);
            this.m_longshots = r.GetAndCheckIntField(FI.players_longshots);
            this.m_marking = r.GetAndCheckIntField(FI.players_marking);
            this.m_positioning = r.GetAndCheckIntField(FI.players_positioning);
            this.m_potential = r.GetAndCheckIntField(FI.players_potential);
            this.m_reactions = r.GetAndCheckIntField(FI.players_reactions);
            this.m_shortpassing = r.GetAndCheckIntField(FI.players_shortpassing);
            this.m_shotpower = r.GetAndCheckIntField(FI.players_shotpower);
            this.m_sprintspeed = r.GetAndCheckIntField(FI.players_sprintspeed);
            this.m_stamina = r.GetAndCheckIntField(FI.players_stamina);
            this.m_strength = r.GetAndCheckIntField(FI.players_strength);
            this.m_standingtackle = r.GetAndCheckIntField(FI.players_standingtackle);
            this.m_slidingtackle = r.GetAndCheckIntField(FI.players_slidingtackle);
            this.m_gkdiving = r.GetAndCheckIntField(FI.players_gkdiving);
            this.m_gkpositioning = r.GetAndCheckIntField(FI.players_gkpositioning);
            this.m_gkhandling = r.GetAndCheckIntField(FI.players_gkhandling);
            this.m_gkreflexes = r.GetAndCheckIntField(FI.players_gkreflexes);
            this.m_gkglovetypecode = r.GetAndCheckIntField(FI.players_gkglovetypecode);
            this.m_agility = r.GetAndCheckIntField(FI.players_agility);
            this.m_balance = r.GetAndCheckIntField(FI.players_balance);
            this.m_gkkicking = r.GetAndCheckIntField(FI.players_gkkicking);
            this.m_gkkickstyle = r.GetAndCheckIntField(FI.players_gkkickstyle);
            this.m_jumping = r.GetAndCheckIntField(FI.players_jumping);
            this.m_penalties = r.GetAndCheckIntField(FI.players_penalties);
            this.m_vision = r.GetAndCheckIntField(FI.players_vision);
            this.m_volleys = r.GetAndCheckIntField(FI.players_volleys);
            this.m_skillmoves = r.GetAndCheckIntField(FI.players_skillmoves);
            this.m_usercaneditname = r.GetAndCheckIntField(FI.players_usercaneditname);
            this.m_finishingcode1 = r.GetAndCheckIntField(FI.players_finishingcode1);
            this.m_finishingcode2 = r.GetAndCheckIntField(FI.players_finishingcode2);
            this.m_runningcode1 = r.GetAndCheckIntField(FI.players_runningcode1);
            this.m_runningcode2 = r.GetAndCheckIntField(FI.players_runningcode2);
            this.m_gksavetype = r.GetAndCheckIntField(FI.players_gksavetype);
            this.m_faceposercode = r.GetAndCheckIntField(FI.players_faceposercode);
            this.m_isretiring = r.GetAndCheckIntField(FI.players_isretiring);
            this.m_socklengthcode = r.GetAndCheckIntField(FI.players_socklengthcode);
            this.m_hashighqualityhead = r.GetAndCheckIntField(FI.players_hashighqualityhead);
            this.m_attackingworkrate = r.GetAndCheckIntField(FI.players_attackingworkrate);
            this.m_defensiveworkrate = r.GetAndCheckIntField(FI.players_defensiveworkrate);
            this.m_shortstyle = r.GetAndCheckIntField(FI.players_shortstyle) != 0;
            int andCheckIntField1 = r.GetAndCheckIntField(FI.players_trait1);
            this.m_Inflexible = (andCheckIntField1 & 1) != 0;
            this.m_Longthrows = (andCheckIntField1 & 2) != 0;
            this.m_PowerfulFreeKicks = (andCheckIntField1 & 4) != 0;
            this.m_Diver = (andCheckIntField1 & 8) != 0;
            this.m_InjuryProne = (andCheckIntField1 & 16) != 0;
            this.m_InjuryFree = (andCheckIntField1 & 32) != 0;
            this.m_AvoidsWeakFoot = (andCheckIntField1 & 64) != 0;
            this.m_Divesintotackles = (andCheckIntField1 & 128) != 0;
            this.m_BeatDefensiveLine = (andCheckIntField1 & 256) != 0;
            this.m_Selfish = (andCheckIntField1 & 512) != 0;
            this.m_Leadership = (andCheckIntField1 & 1024) != 0;
            this.m_ArguesWithOfficials = (andCheckIntField1 & 2048) != 0;
            this.m_Earlycrosser = (andCheckIntField1 & 4096) != 0;
            this.m_FinesseShot = (andCheckIntField1 & 8192) != 0;
            this.m_Flair = (andCheckIntField1 & 16384) != 0;
            this.m_LongPasser = (andCheckIntField1 & 32768) != 0;
            this.m_LongShotTaker = (andCheckIntField1 & 65536) != 0;
            this.m_Technicaldribbler = (andCheckIntField1 & 131072) != 0;
            this.m_Playmaker = (andCheckIntField1 & 262144) != 0;
            this.m_Pushesupforcorners = (andCheckIntField1 & 524288) != 0;
            this.m_Puncher = (andCheckIntField1 & 1048576) != 0;
            this.m_GkLongThrower = (andCheckIntField1 & 2097152) != 0;
            this.m_PowerHeader = (andCheckIntField1 & 4194304) != 0;
            this.m_GkOneOnOne = (andCheckIntField1 & 8388608) != 0;
            this.m_GiantThrow = (andCheckIntField1 & 16777216) != 0;
            this.m_OutsideFootShot = (andCheckIntField1 & 33554432) != 0;
            this.m_CrowdFavorite = (andCheckIntField1 & 67108864) != 0;
            this.m_SwervePasser = (andCheckIntField1 & 134217728) != 0;
            this.m_SecondWind = (andCheckIntField1 & 268435456) != 0;
            this.m_AcrobaticClearance = (andCheckIntField1 & 536870912) != 0;
            int andCheckIntField2 = r.GetAndCheckIntField(FI.players_trait2);
            this.m_FancyFeet = (andCheckIntField2 & 1) != 0;
            this.m_FancyPasses = (andCheckIntField2 & 2) != 0;
            this.m_FancyFlicks = (andCheckIntField2 & 4) != 0;
            this.m_StutterPenalty = (andCheckIntField2 & 8) != 0;
            this.m_ChipperPenalty = (andCheckIntField2 & 16) != 0;
            this.m_BycicleKick = (andCheckIntField2 & 32) != 0;
            this.m_DivingHeader = (andCheckIntField2 & 64) != 0;
            this.m_DrivenPass = (andCheckIntField2 & 128) != 0;
            this.m_GkFlatKick = (andCheckIntField2 & 256) != 0;
            this.m_HighClubIdentification = (andCheckIntField2 & 512) != 0;
            this.m_TeamPlayer = (andCheckIntField2 & 1024) != 0;
            this.m_assetid = this.Id;
            this.m_nationality = r.GetAndCheckIntField(FI.players_nationality);
            this.m_weakfootabilitytypecode = r.GetAndCheckIntField(FI.players_weakfootabilitytypecode);
            this.m_curve = r.GetAndCheckIntField(FI.players_curve);
            this.m_internationalrep = r.GetAndCheckIntField(FI.players_internationalrep) - 1;
            this.m_interceptions = r.GetAndCheckIntField(FI.players_interceptions);
            this.m_shoecolorcode2 = r.GetAndCheckIntField(FI.players_shoecolorcode2);
            this.m_jerseyfit = r.GetAndCheckIntField(FI.players_jerseyfit) != 0;
            this.m_shoedesigncode = r.GetAndCheckIntField(FI.players_shoedesigncode);
        }

        public void FillFromPlayerloans(Record r)
        {
            this.m_teamidloanedfrom = r.GetAndCheckIntField(FI.playerloans_teamidloanedfrom);
            this.m_loandateend = FifaUtil.ConvertToDate(r.GetAndCheckIntField(FI.playerloans_loandateend));
            this.m_IsLoaned = true;
        }

        public void FillFromPreviousTeam(Record r)
        {
            this.m_previousteamid = r.GetAndCheckIntField(FI.previousteam_previousteamid);
        }

        public void FillFromEditedPlayerNames(Record r)
        {
            this.m_firstname = r.GetAndCheckStringField(FI.editedplayernames_firstname);
            this.m_lastname = r.GetAndCheckStringField(FI.editedplayernames_surname);
            this.m_commonname = r.GetAndCheckStringField(FI.editedplayernames_commonname);
            this.m_playerjerseyname = r.GetAndCheckStringField(FI.editedplayernames_playerjerseyname);
            this.m_IsLoaned = true;
        }

        public void SavePlayerloans(Record r)
        {
            r.IntField[FI.playerloans_playerid] = this.Id;
            r.IntField[FI.playerloans_teamidloanedfrom] = this.m_teamidloanedfrom;
            r.IntField[FI.playerloans_loandateend] = FifaUtil.ConvertFromDate(this.m_loandateend);
        }

        public void SavePreviousTeam(Record r)
        {
            r.IntField[FI.previousteam_playerid] = this.Id;
            r.IntField[FI.previousteam_previousteamid] = this.m_previousteamid;
        }

        public void LinkCountry(CountryList countryList)
        {
            if (countryList == null)
                return;
            this.m_Country = (Country)countryList.SearchId(this.m_nationality);
            if (this.m_Country != null)
                return;
            if (countryList.Count > 0)
            {
                this.m_Country = (Country)countryList[0];
                this.m_nationality = this.m_Country.Id;
            }
            else
                this.m_nationality = 0;
        }

        public void LinkTeam(TeamList teamList)
        {
            if (teamList == null)
                return;
            if (this.m_teamidloanedfrom != 0)
            {
                this.m_TeamLoanedFrom = (Team)teamList.SearchId(this.m_teamidloanedfrom);
                if (this.m_TeamLoanedFrom == null)
                    this.m_teamidloanedfrom = 0;
            }
            if (this.m_previousteamid == 0)
                return;
            this.m_PreviousTeam = (Team)teamList.SearchId(this.m_previousteamid);
            if (this.m_PreviousTeam != null)
                return;
            this.m_previousteamid = 0;
        }

        public void SearchCountry()
        {
            if (FifaEnvironment.Countries == null)
            {
                this.m_Country = (Country)null;
            }
            else
            {
                this.m_Country = (Country)FifaEnvironment.Countries.SearchId(this.m_nationality);
                if (this.m_Country != null)
                    return;
                if (FifaEnvironment.Countries.Count > 0)
                {
                    this.m_Country = (Country)FifaEnvironment.Countries[0];
                    this.m_nationality = this.m_Country.Id;
                }
                else
                    this.m_nationality = 0;
            }
        }

        public void SearchWouldTeams()
        {
        }

        public void InitNewPlayer()
        {
            this.m_firstname = string.Empty;
            this.m_lastname = "New Player";
            this.m_commentaryid = 900000;
            this.m_commonname = string.Empty;
            this.m_playerjerseyname = "New Player";
            this.m_playerjerseynameid = 0;
            this.m_firstnameid = 0;
            this.m_commonnameid = 0;
            this.m_lastnameid = 0;
            this.m_birthdate = new DateTime(1980, 6, 15);
            this.m_playerjointeamdate = new DateTime(2010, 1, 1);
            this.m_contractvaliduntil = 2015;
            this.m_height = 180;
            this.m_weight = 80;
            this.m_preferredposition1 = 0;
            this.m_preferredposition2 = -1;
            this.m_preferredposition3 = -1;
            this.m_preferredposition4 = -1;
            this.m_preferredfoot = 0;
            this.m_jerseysleevelengthcode = 0;
            this.m_jerseystylecode = 0;
            this.m_hasseasonaljersey = 0;
            this.m_animfreekickstartposcode = 0;
            this.m_animpenaltieskickstylecode = 0;
            this.m_animpenaltiesmotionstylecode = 0;
            this.m_animpenaltiesstartposcode = 0;
            this.m_accessorycode1 = 0;
            this.m_accessorycolourcode1 = 1;
            this.m_accessorycode2 = 0;
            this.m_accessorycolourcode2 = 1;
            this.m_accessorycode3 = 0;
            this.m_accessorycolourcode3 = 1;
            this.m_accessorycode4 = 0;
            this.m_accessorycolourcode4 = 1;
            this.m_acceleration = 50;
            this.m_aggression = 50;
            this.m_sprintspeed = 50;
            this.m_stamina = 50;
            this.m_strength = 50;
            this.m_marking = 50;
            this.m_standingtackle = 50;
            this.m_slidingtackle = 50;
            this.m_ballcontrol = 50;
            this.m_dribbling = 50;
            this.m_crossing = 50;
            this.m_headingaccuracy = 50;
            this.m_shortpassing = 50;
            this.m_longpassing = 50;
            this.m_longshots = 50;
            this.m_finishing = 50;
            this.m_shotpower = 50;
            this.m_reactions = 50;
            this.m_gkreflexes = 50;
            this.m_gkglovetypecode = 0;
            this.m_agility = 50;
            this.m_balance = 50;
            this.m_gkkicking = 50;
            this.m_gkkickstyle = 0;
            this.m_jumping = 50;
            this.m_penalties = 50;
            this.m_vision = 50;
            this.m_volleys = 50;
            this.m_skillmoves = 0;
            this.m_usercaneditname = 0;
            this.m_gkhandling = 50;
            this.m_gkdiving = 50;
            this.m_gkpositioning = 50;
            this.m_freekickaccuracy = 50;
            this.m_positioning = 50;
            this.m_InjuryFree = false;
            this.m_HighClubIdentification = false;
            this.m_TeamPlayer = false;
            this.m_Leadership = false;
            this.m_ArguesWithOfficials = false;
            this.m_AvoidsWeakFoot = false;
            this.m_InjuryProne = false;
            this.m_Puncher = false;
            this.m_Pushesupforcorners = false;
            this.m_Technicaldribbler = false;
            this.m_Selfish = false;
            this.m_Playmaker = false;
            this.m_Diver = false;
            this.m_Divesintotackles = false;
            this.m_LongShotTaker = false;
            this.m_Earlycrosser = false;
            this.m_Inflexible = false;
            this.m_GkOneOnOne = false;
            this.m_Longthrows = false;
            this.m_OutsideFootShot = false;
            this.m_LongPasser = false;
            this.m_GiantThrow = false;
            this.m_Flair = false;
            this.m_PowerfulFreeKicks = false;
            this.m_FinesseShot = false;
            this.m_PowerHeader = false;
            this.m_SwervePasser = false;
            this.m_BeatDefensiveLine = false;
            this.m_GkLongThrower = false;
            this.m_CrowdFavorite = false;
            this.m_SecondWind = false;
            this.m_AcrobaticClearance = false;
            this.m_FancyFeet = false;
            this.m_FancyPasses = false;
            this.m_FancyFlicks = false;
            this.m_StutterPenalty = false;
            this.m_ChipperPenalty = false;
            this.m_BycicleKick = false;
            this.m_DivingHeader = false;
            this.m_DrivenPass = false;
            this.m_GkFlatKick = false;
            this.m_assetid = this.Id;
            this.m_potential = 50;
            this.m_nationality = 0;
            this.SearchCountry();
            this.m_bodytypecode = 1;
            this.m_weakfootabilitytypecode = 3;
            this.m_curve = 50;
            this.m_internationalrep = 2;
            this.m_eyecolorcode = 1;
            this.m_eyebrowcode = 0;
            this.m_hairtypecode = 1;
            this.m_headtypecode = 1;
            this.m_headclasscode = 1;
            this.m_haircolorcode = 1;
            this.m_facialhairtypecode = 0;
            this.m_facialhaircolorcode = 0;
            this.m_sideburnscode = 1;
            this.m_skintypecode = 0;
            this.m_skintonecode = 2;
            this.m_shoecolorcode1 = 1;
            this.m_shoetypecode = 0;
            this.m_overallrating = 50;
            this.m_finishingcode1 = 0;
            this.m_finishingcode2 = 0;
            this.m_runningcode1 = 0;
            this.m_runningcode2 = 0;
            this.m_gksavetype = 0;
            this.m_faceposercode = 0;
            this.m_isretiring = 0;
            this.m_socklengthcode = 0;
            this.m_hashighqualityhead = 0;
            this.m_attackingworkrate = 0;
            this.m_defensiveworkrate = 0;
            this.m_shortstyle = false;
            this.m_interceptions = 50;
            this.m_shoecolorcode2 = 31;
            this.m_jerseyfit = false;
            this.m_shoedesigncode = 0;
        }

        public Player(int playerId)
          : base(playerId)
        {
            this.Id = playerId;
            this.InitNewPlayer();
        }

        public override IdObject Clone(int playerid)
        {
            Player player = (Player)base.Clone(playerid);
            player.m_lastname = "Player " + player.Id.ToString();
            player.m_commentaryid = player.m_commentaryid;
            player.m_firstname = string.Empty;
            player.m_assetid = playerid;
            player.m_PlayingForTeams = new TeamList();
            player.m_HasSpecificPhoto = false;
            player.GetPhoto();
            player.m_HeadModelFile = (Rx3File)null;
            player.m_HairModelFile = (Rx3File)null;
            player.GetHeadModel();
            player.m_FaceTextureBitmaps = (Bitmap[])null;
            player.GetFaceTextures();
            player.m_HairColorTextureBitmap = (Bitmap)null;
            player.m_HairAlfaTextureBitmap = (Bitmap)null;
            player.GetHairTextures();
            return (IdObject)player;
        }

        public Player Copy(Player clone)
        {
            clone.m_birthdate = this.m_birthdate;
            clone.m_playerjointeamdate = this.m_playerjointeamdate;
            clone.m_contractvaliduntil = this.m_contractvaliduntil;
            clone.m_nationality = this.m_nationality;
            clone.m_Country = this.m_Country;
            clone.m_height = this.m_height;
            clone.m_weight = this.m_weight;
            clone.m_bodytypecode = this.m_bodytypecode;
            clone.m_jerseysleevelengthcode = this.m_jerseysleevelengthcode;
            clone.m_jerseystylecode = this.m_jerseystylecode;
            clone.m_hasseasonaljersey = this.m_hasseasonaljersey;
            clone.m_animfreekickstartposcode = this.m_animfreekickstartposcode;
            clone.m_animpenaltieskickstylecode = this.m_animpenaltieskickstylecode;
            clone.m_animpenaltiesmotionstylecode = this.m_animpenaltiesmotionstylecode;
            clone.m_animpenaltiesstartposcode = this.m_animpenaltiesstartposcode;
            clone.m_accessorycode1 = this.m_accessorycode1;
            clone.m_accessorycolourcode1 = this.m_accessorycolourcode1;
            clone.m_accessorycode2 = this.m_accessorycode2;
            clone.m_accessorycolourcode2 = this.m_accessorycolourcode2;
            clone.m_accessorycode3 = this.m_accessorycode3;
            clone.m_accessorycolourcode3 = this.m_accessorycolourcode3;
            clone.m_accessorycode4 = this.m_accessorycode4;
            clone.m_accessorycolourcode4 = this.m_accessorycolourcode4;
            clone.m_preferredposition1 = this.m_preferredposition1;
            clone.m_preferredposition2 = this.m_preferredposition2;
            clone.m_preferredposition3 = this.m_preferredposition3;
            clone.m_preferredposition4 = this.m_preferredposition4;
            clone.m_preferredfoot = this.m_preferredfoot;
            clone.m_weakfootabilitytypecode = this.m_weakfootabilitytypecode;
            clone.m_acceleration = this.m_acceleration;
            clone.m_aggression = this.m_aggression;
            clone.m_sprintspeed = this.m_sprintspeed;
            clone.m_stamina = this.m_stamina;
            clone.m_strength = this.m_strength;
            clone.m_marking = this.m_marking;
            clone.m_interceptions = this.m_interceptions;
            clone.m_standingtackle = this.m_standingtackle;
            clone.m_slidingtackle = this.m_slidingtackle;
            clone.m_ballcontrol = this.m_ballcontrol;
            clone.m_dribbling = this.m_dribbling;
            clone.m_crossing = this.m_crossing;
            clone.m_headingaccuracy = this.m_headingaccuracy;
            clone.m_shortpassing = this.m_shortpassing;
            clone.m_longpassing = this.m_longpassing;
            clone.m_longshots = this.m_longshots;
            clone.m_finishing = this.m_finishing;
            clone.m_shotpower = this.m_shotpower;
            clone.m_reactions = this.m_reactions;
            clone.m_gkreflexes = this.m_gkreflexes;
            clone.m_gkglovetypecode = this.m_gkglovetypecode;
            clone.m_agility = this.m_agility;
            clone.m_balance = this.m_balance;
            clone.m_gkkicking = this.m_gkkicking;
            clone.m_gkkickstyle = this.m_gkkickstyle;
            clone.m_jumping = this.m_jumping;
            clone.m_penalties = this.m_penalties;
            clone.m_vision = this.m_vision;
            clone.m_volleys = this.m_volleys;
            clone.m_skillmoves = this.m_skillmoves;
            clone.m_usercaneditname = this.m_usercaneditname;
            clone.m_gkhandling = this.m_gkhandling;
            clone.m_gkdiving = this.m_gkdiving;
            clone.m_gkpositioning = this.m_gkpositioning;
            clone.m_positioning = this.m_positioning;
            clone.m_freekickaccuracy = this.m_freekickaccuracy;
            clone.m_potential = this.m_potential;
            clone.m_InjuryFree = this.m_InjuryFree;
            clone.m_HighClubIdentification = this.m_HighClubIdentification;
            clone.m_TeamPlayer = this.m_TeamPlayer;
            clone.m_Leadership = this.m_Leadership;
            clone.m_ArguesWithOfficials = this.m_ArguesWithOfficials;
            clone.m_AvoidsWeakFoot = this.m_AvoidsWeakFoot;
            clone.m_InjuryProne = this.m_InjuryProne;
            clone.m_Puncher = this.m_Puncher;
            clone.m_Pushesupforcorners = this.m_Pushesupforcorners;
            clone.m_Technicaldribbler = this.m_Technicaldribbler;
            clone.m_Selfish = this.m_Selfish;
            clone.m_Playmaker = this.m_Playmaker;
            clone.m_Diver = this.m_Diver;
            clone.m_Divesintotackles = this.m_Divesintotackles;
            clone.m_LongShotTaker = this.m_LongShotTaker;
            clone.m_Earlycrosser = this.m_Earlycrosser;
            clone.m_Inflexible = this.m_Inflexible;
            clone.m_GkOneOnOne = this.m_GkOneOnOne;
            clone.m_Longthrows = this.m_Longthrows;
            clone.m_OutsideFootShot = this.m_OutsideFootShot;
            clone.m_LongPasser = this.m_LongPasser;
            clone.m_GiantThrow = this.m_GiantThrow;
            clone.m_Flair = this.m_Flair;
            clone.m_PowerfulFreeKicks = this.m_PowerfulFreeKicks;
            clone.m_FinesseShot = this.m_FinesseShot;
            clone.m_PowerHeader = this.m_PowerHeader;
            clone.m_SwervePasser = this.m_SwervePasser;
            clone.m_BeatDefensiveLine = this.m_BeatDefensiveLine;
            clone.m_GkLongThrower = this.m_GkLongThrower;
            clone.m_FancyFeet = this.m_FancyFeet;
            clone.m_FancyPasses = this.m_FancyPasses;
            clone.m_FancyFlicks = this.m_FancyFlicks;
            clone.m_StutterPenalty = this.m_StutterPenalty;
            clone.m_ChipperPenalty = this.m_ChipperPenalty;
            clone.m_BycicleKick = this.m_BycicleKick;
            clone.m_DivingHeader = this.m_DivingHeader;
            clone.m_DrivenPass = this.m_DrivenPass;
            clone.m_GkFlatKick = this.m_GkFlatKick;
            clone.m_curve = this.m_curve;
            clone.m_internationalrep = this.m_internationalrep + 1;
            clone.m_eyecolorcode = this.m_eyecolorcode;
            clone.m_eyebrowcode = this.m_eyebrowcode;
            clone.m_hairtypecode = this.m_hairtypecode;
            clone.m_headtypecode = this.m_headtypecode;
            clone.m_headclasscode = 1;
            clone.m_haircolorcode = this.m_haircolorcode;
            clone.m_facialhairtypecode = this.m_facialhairtypecode;
            clone.m_facialhaircolorcode = this.m_facialhaircolorcode;
            clone.m_sideburnscode = this.m_sideburnscode;
            clone.m_skintypecode = this.m_skintypecode;
            clone.m_skintonecode = this.m_skintonecode;
            clone.m_shoecolorcode1 = this.m_shoecolorcode1;
            clone.m_shoecolorcode2 = this.m_shoecolorcode2;
            clone.m_shoetypecode = this.m_shoetypecode;
            clone.m_shoedesigncode = this.m_shoedesigncode;
            clone.m_overallrating = this.m_overallrating;
            clone.m_HasSpecificPhoto = false;
            return clone;
        }

        public string SpecificFaceTextureFileName()
        {
            return Player.SpecificFaceTextureFileName(this.Id);
        }

        public static string SpecificFaceTextureFileName(int id)
        {
            return "data/sceneassets/faces/face_" + id.ToString() + "_0_0_0_0_0_0_0_0_textures.rx3";
        }

        public string GenericFaceTextureFileName()
        {
            return "data/sceneassets/faces/face_0_1_0_" + this.m_eyebrowcode.ToString() + "_" + this.m_sideburnscode.ToString() + "_" + this.m_facialhaircolorcode.ToString() + "_" + this.m_facialhairtypecode.ToString() + "_" + this.m_skintypecode.ToString() + "_" + this.m_skintonecode.ToString() + "_textures.rx3";
        }

        public string SpecificFaceTextureTemplateName()
        {
            return FifaEnvironment.Year == 14 ? "data/sceneassets/faces/2014_face_#_0_0_0_0_0_0_0_0_textures.rx3" : "data/sceneassets/faces/face_#_0_0_0_0_0_0_0_0_textures.rx3";
        }

        public string GenericHeadModelFileName()
        {
            return "data/sceneassets/heads/head_" + this.m_headtypecode.ToString() + "_1.rx3";
        }

        public string GenericHeadModelTemplateName()
        {
            return "data/sceneassets/heads/head_#_1.rx3";
        }

        public string SpecificHeadModelFileName()
        {
            return Player.SpecificHeadModelFileName(this.Id);
        }

        public static string SpecificHeadModelFileName(int id)
        {
            return "data/sceneassets/heads/head_" + id.ToString() + "_0.rx3";
        }

        public string GenericHairModelFileName()
        {
            return this.GenericHairModelFileName(this.m_hairtypecode);
        }

        public string GenericHairModelFileName(int hairtypecode)
        {
            return "data/sceneassets/hair/hair_" + hairtypecode.ToString() + "_1_0.rx3";
        }

        public static string GenericHairLodModelFileName(int hairtypecode)
        {
            return "data/sceneassets/hairlod/hairlod_" + hairtypecode.ToString() + "_1_0.rx3";
        }

        public string GenericHairLodModelFileName()
        {
            return Player.GenericHairLodModelFileName(this.m_hairtypecode);
        }

        public static string SpecificHairLodModelFileName(int id)
        {
            return "data/sceneassets/hairlod/hairlod_" + id.ToString() + "_0_0.rx3";
        }

        public string SpecificHairLodModelFileName()
        {
            return Player.SpecificHairLodModelFileName(this.Id);
        }

        public string GenericHairModelTemplateName()
        {
            return "data/sceneassets/hair/hair_#_1_0.rx3";
        }

        public string SpecificHairModelFileName()
        {
            return Player.SpecificHairModelFileName(this.Id);
        }

        public static string SpecificHairModelFileName(int id)
        {
            return "data/sceneassets/hair/hair_" + id.ToString() + "_0_0.rx3";
        }

        public string HeadModelFileName()
        {
            return this.headclasscode == 0 ? this.SpecificHeadModelFileName() : this.GenericHeadModelFileName();
        }

        public string HairModelFileName()
        {
            return this.headclasscode == 0 ? this.SpecificHairModelFileName() : this.GenericHairModelFileName();
        }

        public string HairLodModelFileName()
        {
            return this.headclasscode == 0 ? this.SpecificHairLodModelFileName() : this.GenericHairLodModelFileName();
        }

        public string FaceTextureFileName()
        {
            return this.HasSpecificHeadModel ? this.SpecificFaceTextureFileName() : this.GenericFaceTextureFileName();
        }

        public string SpecificEyesTextureFileName()
        {
            return FifaEnvironment.Year == 14 ? Player.SpecificEyesTextureFileName(this.Id) : (string)null;
        }

        public static string SpecificEyesTextureFileName(int id)
        {
            return "data/sceneassets/heads/eyes_" + id.ToString() + "_0_textures.rx3";
        }

        public string SpecificEyesTextureTemplateName()
        {
            return "data/sceneassets/heads/eyes_#_0_textures.rx3";
        }

        public string GenericEyesTextureFileName()
        {
            return "data/sceneassets/heads/eyes_" + this.m_eyecolorcode.ToString() + "_1_textures.rx3";
        }

        public string SkinTextureTemplateName()
        {
            return "data/sceneassets/body/skin_#_textures.rx3";
        }

        public string SkinTextureFileName()
        {
            return "data/sceneassets/body/skin_" + this.m_skintonecode.ToString() + "_textures.rx3";
        }

        public string SpecificPhotoTemplateFileName()
        {
            return "data/ui/imgassets/heads/p#.dds";
        }

        public string SpecificPhotoDdsFileName()
        {
            return "data/ui/imgassets/heads/p" + this.Id.ToString() + ".dds";
        }

        public static string SpecificPhotoDdsFileName(int id)
        {
            return "data/ui/imgassets/heads/p" + id.ToString() + ".dds";
        }

        public bool IsPlayingFor(Team team)
        {
            if (this.m_PlayingForTeams == null)
                return false;
            foreach (Team playingForTeam in (ArrayList)this.m_PlayingForTeams)
            {
                if (playingForTeam == team)
                    return true;
            }
            return false;
        }

        public void PlayFor(Team team)
        {
            if (this.m_PlayingForTeams == null)
                this.m_PlayingForTeams = new TeamList();
            foreach (Team playingForTeam in (ArrayList)this.m_PlayingForTeams)
            {
                if (playingForTeam == team)
                    return;
            }
            this.m_PlayingForTeams.Add((object)team);
        }

        public void NotPlayFor(Team team)
        {
            if (this.m_PlayingForTeams == null)
                return;
            foreach (Team playingForTeam in (ArrayList)this.m_PlayingForTeams)
            {
                if (playingForTeam == team)
                {
                    this.m_PlayingForTeams.Remove((object)team);
                    break;
                }
            }
        }

        public bool IsFreeAgent()
        {
            int num = 0;
            if (this.m_PlayingForTeams != null)
            {
                foreach (Team playingForTeam in (ArrayList)this.m_PlayingForTeams)
                {
                    if (playingForTeam.IsClub())
                        ++num;
                }
            }
            return num == 0;
        }

        public bool IsMultiClub()
        {
            int num = 0;
            if (this.m_PlayingForTeams != null)
            {
                foreach (Team playingForTeam in (ArrayList)this.m_PlayingForTeams)
                {
                    if (playingForTeam.IsClub())
                        ++num;
                }
            }
            return num > 1;
        }

        public Bitmap GetPhoto()
        {
            Bitmap bitmap = FifaEnvironment.Get2dHead(this.SpecificPhotoDdsFileName());
            this.m_HasSpecificPhoto = bitmap != null;
            return bitmap;
        }

        public bool SetPhoto(Bitmap bitmap)
        {
            return FifaEnvironment.Set2dHead(this.SpecificPhotoTemplateFileName(), this.Id, bitmap);
        }

        public bool DeletePhoto()
        {
            return FifaEnvironment.Delete2dHead(this.SpecificPhotoDdsFileName());
        }

        private void ChangeHairColor(Bitmap bitmap, int color)
        {
            int num1 = 128;
            int num2 = 128;
            int num3 = 128;
            switch (color)
            {
                case 1:
                    num1 = 64;
                    num2 = 64;
                    num3 = 64;
                    break;
                case 2:
                    num1 = 92;
                    num2 = 92;
                    num3 = 92;
                    break;
                case 3:
                    return;
                case 4:
                    num1 = 160;
                    num2 = 180;
                    num3 = 128;
                    break;
                case 5:
                    num1 = 170;
                    num2 = 128;
                    num3 = 128;
                    break;
                case 6:
                    num1 = 192;
                    num2 = 256;
                    num3 = 256;
                    break;
                case 7:
                    num1 = 128;
                    num2 = 150;
                    num3 = 150;
                    break;
            }
            for (int x = 0; x < 128; ++x)
            {
                for (int y = 0; y < 128; ++y)
                {
                    Color pixel = bitmap.GetPixel(x, y);
                    if (pixel.R != (byte)128 || pixel.G != (byte)128 || pixel.B != (byte)128)
                    {
                        int red = (int)pixel.R * num1 / 128;
                        int green = (int)pixel.G * num2 / 128;
                        int blue = (int)pixel.B * num3 / 128;
                        if (red > (int)byte.MaxValue)
                            red = (int)byte.MaxValue;
                        if (green > (int)byte.MaxValue)
                            green = (int)byte.MaxValue;
                        if (blue > (int)byte.MaxValue)
                            blue = (int)byte.MaxValue;
                        if (color == 6)
                            red = green = blue;
                        bitmap.SetPixel(x, y, Color.FromArgb((int)byte.MaxValue, red, green, blue));
                    }
                }
            }
        }

        private void OverlapBitmaps(Bitmap lowerBitmap, Bitmap upperBitmap)
        {
            for (int x = 0; x < 128; ++x)
            {
                for (int y = 0; y < 128; ++y)
                {
                    Color pixel = upperBitmap.GetPixel(x, y);
                    if (pixel.R != (byte)128 || pixel.G != (byte)128 || pixel.B != (byte)128)
                        lowerBitmap.SetPixel(x, y, pixel);
                }
            }
        }

        public void ChangeId()
        {
            this.m_assetid = this.Id;
            this.headclasscode = FifaEnvironment.IsFilePresent(this.SpecificHeadModelFileName()) ? 0 : 1;
            this.m_FaceTextureBitmaps = (Bitmap[])null;
            this.m_HairColorTextureBitmap = (Bitmap)null;
            this.m_HairAlfaTextureBitmap = (Bitmap)null;
            this.m_HeadModelFile = (Rx3File)null;
        }

        public void CleanFaceTextures()
        {
            if (this.m_FaceTextureBitmaps != null)
            {
                for (int index = 0; index < this.m_FaceTextureBitmaps.Length; ++index)
                    this.m_FaceTextureBitmaps[index].Dispose();
            }
            this.m_FaceTextureBitmaps = (Bitmap[])null;
        }

        public Bitmap GetFaceTexture()
        {
            if (this.m_FaceTextureBitmaps != null)
                return this.m_FaceTextureBitmaps[0];
            this.GetFaceTextures();
            return this.m_FaceTextureBitmaps != null ? this.m_FaceTextureBitmaps[0] : (Bitmap)null;
        }

        public static int GetFaceTexturesNumber()
        {
            return FifaEnvironment.Year == 14 ? 1 : 2;
        }

        public Bitmap[] GetFaceTextures()
        {
            if (this.m_FaceTextureBitmaps != null)
                return this.m_FaceTextureBitmaps;
            this.m_FaceTextureBitmaps = !this.HasSpecificHeadModel ? FifaEnvironment.GetBmpsFromRx3(this.GenericFaceTextureFileName()) : FifaEnvironment.GetBmpsFromRx3(this.SpecificFaceTextureFileName());
            return this.m_FaceTextureBitmaps;
        }

        public bool SetFaceTexture(Bitmap bitmap)
        {
            if (!this.HasSpecificHeadModel)
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(5038);
                return false;
            }
            this.CleanFaceTextures();
            return FifaEnvironment.ImportBmpsIntoZdata(this.SpecificFaceTextureTemplateName(), this.Id, bitmap, ECompressionMode.Chunkzip, (Rx3Signatures)null);
        }

        public bool SetFaceTextures(Bitmap[] bitmaps)
        {
            if (!this.HasSpecificHeadModel)
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(5038);
                this.CleanFaceTextures();
                return false;
            }
            this.CleanFaceTextures();
            return FifaEnvironment.ImportBmpsIntoZdata(this.SpecificFaceTextureTemplateName(), this.Id, bitmaps, ECompressionMode.Chunkzip2);
        }

        public bool SetFaceTextures(string rx3FileName)
        {
            if (!this.HasSpecificHeadModel)
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(5038);
                return false;
            }
            this.CleanFaceTextures();
            return FifaEnvironment.ImportFileIntoZdataAs(rx3FileName, this.SpecificFaceTextureFileName(), false, ECompressionMode.Chunkzip, (Rx3Signatures)null);
        }

        public bool DeleteFaceTexture()
        {
            if (!this.HasSpecificHeadModel)
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(5039);
                return false;
            }
            bool flag = FifaEnvironment.DeleteFromZdata(this.FaceTextureFileName());
            if (flag)
                this.m_FaceTextureBitmaps = (Bitmap[])null;
            return flag;
        }

        public bool SetSkinTextures(Bitmap bitmap)
        {
            if (this.m_skintonecode >= 10)
                return FifaEnvironment.ImportBmpsIntoZdata(this.SkinTextureTemplateName(), this.m_skintonecode, bitmap, ECompressionMode.Chunkzip, this.SkinSignature());
            int num = (int)FifaEnvironment.UserMessages.ShowMessage(5063);
            return false;
        }

        public Bitmap GetSkinTexture()
        {
            return FifaEnvironment.GetBmpFromRx3(this.SkinTextureFileName(), 0);
        }

        public bool DeleteSkinTexture()
        {
            if (this.m_skintonecode >= 10)
                return FifaEnvironment.DeleteFromZdata(this.SkinTextureFileName());
            int num = (int)FifaEnvironment.UserMessages.ShowMessage(5063);
            return false;
        }

        private Rx3Signatures SkinSignature()
        {
            return new Rx3Signatures(175072, 24, new string[1]
            {
        "body_" + this.m_skintonecode.ToString() + "_cm.Raster"
            });
        }

        public Bitmap GetEyesTexture()
        {
            if (this.m_EyesTextureBitmap != null)
                return this.m_EyesTextureBitmap;
            this.m_EyesTextureBitmap = FifaEnvironment.GetBmpFromRx3(!this.HasSpecificHeadModel ? this.GenericEyesTextureFileName() : (FifaEnvironment.Year != 14 ? this.GenericEyesTextureFileName() : this.SpecificEyesTextureFileName()), 0);
            return this.m_EyesTextureBitmap;
        }

        private Rx3Signatures EyesSignature()
        {
            return new Rx3Signatures(11200, 24, new string[1]
            {
        "eyes_" + this.Id.ToString() + "_0_cm.Raster"
            });
        }

        public bool SetEyesTextures(Bitmap bitmap)
        {
            if (FifaEnvironment.Year != 14)
                return false;
            if (!this.HasSpecificHeadModel)
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(5038);
                return false;
            }
            this.CleanEyesTexture();
            return FifaEnvironment.ImportBmpsIntoZdata(this.SpecificEyesTextureTemplateName(), this.Id, bitmap, ECompressionMode.Chunkzip, this.EyesSignature());
        }

        public bool SetEyesTextures(string rx3FileName)
        {
            if (FifaEnvironment.Year != 14)
                return false;
            if (!this.HasSpecificHeadModel)
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(5038);
                return false;
            }
            this.CleanEyesTexture();
            return FifaEnvironment.ImportFileIntoZdataAs(rx3FileName, this.SpecificEyesTextureFileName(), false, ECompressionMode.Chunkzip, this.EyesSignature());
        }

        public void CleanEyesTexture()
        {
            Bitmap eyesTextureBitmap = this.m_EyesTextureBitmap;
            this.m_EyesTextureBitmap = (Bitmap)null;
        }

        public bool DeleteEyesTexture()
        {
            if (!this.HasSpecificHeadModel)
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(5039);
                return false;
            }
            bool flag = FifaEnvironment.DeleteFromZdata(this.SpecificEyesTextureFileName());
            if (flag)
                this.m_EyesTextureBitmap = (Bitmap)null;
            return flag;
        }

        public string HairTexturesFileName()
        {
            return this.m_headclasscode == 0 ? this.SpecificHairTexturesFileName() : this.GenericHairTexturesFileName();
        }

        public string SpecificHairTexturesFileName()
        {
            return Player.SpecificHairTexturesFileName(this.Id);
        }

        public static string SpecificHairTexturesFileName(int id)
        {
            return "data/sceneassets/hair/hair_" + id.ToString() + "_0_textures.rx3";
        }

        public string GenericHairTexturesFileName()
        {
            return "data/sceneassets/hair/hair_" + this.m_hairtypecode.ToString() + "_1_textures.rx3";
        }

        public string HairTexturesTemplateName()
        {
            return FifaEnvironment.Year == 14 ? "data/sceneassets/hair/2014_hair_#_0_textures.rx3" : "data/sceneassets/hair/hair_#_0_textures.rx3";
        }

        public void CleanHairTextures()
        {
            if (this.m_HairAlfaTextureBitmap != null)
                this.m_HairAlfaTextureBitmap.Dispose();
            this.m_HairAlfaTextureBitmap = (Bitmap)null;
            if (this.m_HairColorTextureBitmap != null)
                this.m_HairColorTextureBitmap.Dispose();
            this.m_HairColorTextureBitmap = (Bitmap)null;
        }

        public Bitmap GetGenericHairColorTexture()
        {
            if (!this.HasSpecificHeadModel)
                return this.m_HairColorTextureBitmap;
            Bitmap[] bmpsFromRx3 = FifaEnvironment.GetBmpsFromRx3(this.GenericHairTexturesFileName());
            return bmpsFromRx3 != null ? GraphicUtil.MultiplyColorToBitmap(bmpsFromRx3[1], Player.s_GenericColors[this.m_haircolorcode], 96) : (Bitmap)null;
        }

        public Bitmap[] GetHairTextures()
        {
            if (this.m_HairAlfaTextureBitmap != null && this.m_HairColorTextureBitmap != null)
                return new Bitmap[2]
                {
          this.m_HairAlfaTextureBitmap,
          this.m_HairColorTextureBitmap
                };
            Bitmap[] bmpsFromRx3;
            if (this.HasSpecificHeadModel)
            {
                bmpsFromRx3 = FifaEnvironment.GetBmpsFromRx3(this.SpecificHairTexturesFileName());
                if (bmpsFromRx3 != null)
                {
                    this.m_HairAlfaTextureBitmap = bmpsFromRx3[0];
                    this.m_HairColorTextureBitmap = bmpsFromRx3[1];
                }
                else
                {
                    this.m_HairAlfaTextureBitmap = (Bitmap)null;
                    this.m_HairColorTextureBitmap = (Bitmap)null;
                }
            }
            else
            {
                bmpsFromRx3 = FifaEnvironment.GetBmpsFromRx3(this.GenericHairTexturesFileName());
                if (bmpsFromRx3 != null)
                {
                    this.m_HairAlfaTextureBitmap = bmpsFromRx3[0];
                    this.m_HairColorTextureBitmap = GraphicUtil.MultiplyColorToBitmap(bmpsFromRx3[1], Player.s_GenericColors[this.m_haircolorcode], 96);
                }
                else
                    this.m_HairColorTextureBitmap = (Bitmap)null;
            }
            return bmpsFromRx3;
        }

        public bool SetHairTextures(Bitmap[] bitmaps)
        {
            if (this.HasSpecificHeadModel)
                return FifaEnvironment.ImportBmpsIntoZdata(this.HairTexturesTemplateName(), this.Id, bitmaps, ECompressionMode.Chunkzip2);
            int num = (int)FifaEnvironment.UserMessages.ShowMessage(5038);
            return false;
        }

        public bool SetHairTextures(string rx3FileName)
        {
            return FifaEnvironment.ImportFileIntoZdataAs(rx3FileName, this.SpecificHairTexturesFileName(), false, ECompressionMode.Chunkzip2);
        }

        public bool DeleteHairTextures()
        {
            if (!this.HasSpecificHeadModel)
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(5039);
                return false;
            }
            bool flag = FifaEnvironment.DeleteFromZdata(this.HairTexturesFileName());
            if (flag)
            {
                this.m_HairColorTextureBitmap = (Bitmap)null;
                this.m_HairAlfaTextureBitmap = (Bitmap)null;
            }
            return flag;
        }

        public Bitmap GetHairColorTexture()
        {
            if (this.m_HairColorTextureBitmap != null)
                return this.m_HairColorTextureBitmap;
            this.GetHairTextures();
            return this.m_HairColorTextureBitmap;
        }

        public Bitmap GetHairAlfaTexture()
        {
            if (this.m_HairAlfaTextureBitmap != null)
                return this.m_HairAlfaTextureBitmap;
            this.GetHairTextures();
            return this.m_HairAlfaTextureBitmap;
        }

        public Rx3File GetHeadModel()
        {
            if (this.m_HeadModelFile != null)
                return this.m_HeadModelFile;
            this.m_HeadModelFile = this.m_headclasscode != 0 ? FifaEnvironment.GetRx3FromZdata(this.GenericHeadModelFileName()) : FifaEnvironment.GetRx3FromZdata(this.SpecificHeadModelFileName());
            return this.m_HeadModelFile;
        }

        public bool SetHeadModel(string rx3FileName)
        {
            if (!this.HasSpecificHeadModel)
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(5062);
                return false;
            }
            rx3FileName = this.ConvertHeadModel(rx3FileName);
            bool flag = FifaEnvironment.ImportFileIntoZdataAs(rx3FileName, this.SpecificHeadModelFileName(), false, ECompressionMode.Chunkzip);
            if (flag)
                this.m_HeadModelFile = FifaEnvironment.GetRx3FromZdata(this.SpecificHeadModelFileName());
            return flag;
        }

        private string ConvertHeadModel(string rx3FileName)
        {
            Rx3File rx3File = new Rx3File();
            rx3File.Load(rx3FileName);
            if (rx3File.Rx3VertexArrays.Length > 0)
            {
                if (rx3File.Rx3VertexArrays[0].VertexSize == 32)
                {
                    if (FifaEnvironment.Year != 14)
                    {
                        string baseFileName = FifaEnvironment.LaunchDir + "\\Templates\\data\\sceneassets\\heads\\head_15_1.rx3";
                        string targetFileName = FifaEnvironment.LaunchDir + "\\Templates\\data\\sceneassets\\heads\\head_15_0.rx3";
                        this.ImportHeadModelFromOtherFifa(rx3File, baseFileName, targetFileName, 2.8f);
                        return targetFileName;
                    }
                }
                else if (rx3File.Rx3VertexArrays[0].VertexSize == 48 && FifaEnvironment.Year == 14)
                {
                    string baseFileName = FifaEnvironment.LaunchDir + "\\Templates\\data\\sceneassets\\heads\\head_14_1.rx3";
                    string targetFileName = FifaEnvironment.LaunchDir + "\\Templates\\data\\sceneassets\\heads\\head_14_0.rx3";
                    this.ImportHeadModelFromOtherFifa(rx3File, baseFileName, targetFileName, -2.8f);
                    return targetFileName;
                }
            }
            return rx3FileName;
        }

        private void ImportHeadModelFromOtherFifa(
          Rx3File rx3File,
          string baseFileName,
          string targetFileName,
          float offset)
        {
            File.Copy(baseFileName, targetFileName, true);
            Rx3File rx3File1 = new Rx3File();
            rx3File1.Load(targetFileName);
            for (int index1 = 0; index1 < rx3File1.Rx3VertexArrays.Length; ++index1)
            {
                for (int index2 = 0; index2 < rx3File.Rx3VertexArrays.Length; ++index2)
                {
                    if (rx3File1.Rx3VertexArrays[index1].nVertex == 3157 && rx3File.Rx3VertexArrays[index2].nVertex == 3157)
                    {
                        for (int index3 = 0; index3 < rx3File1.Rx3VertexArrays[index1].nVertex; ++index3)
                        {
                            float num1 = float.MaxValue;
                            int index4 = -1;
                            for (int index5 = 0; index5 < rx3File1.Rx3VertexArrays[index1].nVertex; ++index5)
                            {
                                float num2 = (float)(((double)rx3File1.Rx3VertexArrays[index1].Vertexes[index3].U - (double)rx3File.Rx3VertexArrays[index2].Vertexes[index5].U) * ((double)rx3File1.Rx3VertexArrays[index1].Vertexes[index3].U - (double)rx3File.Rx3VertexArrays[index2].Vertexes[index5].U) + ((double)rx3File1.Rx3VertexArrays[index1].Vertexes[index3].V - (double)rx3File.Rx3VertexArrays[index2].Vertexes[index5].V) * ((double)rx3File1.Rx3VertexArrays[index1].Vertexes[index3].V - (double)rx3File.Rx3VertexArrays[index2].Vertexes[index5].V));
                                if ((double)num2 < (double)num1)
                                {
                                    num1 = num2;
                                    index4 = index5;
                                }
                            }
                            if (index4 != -1)
                            {
                                rx3File1.Rx3VertexArrays[index1].Vertexes[index3].X = rx3File.Rx3VertexArrays[index2].Vertexes[index4].X;
                                rx3File1.Rx3VertexArrays[index1].Vertexes[index3].Y = rx3File.Rx3VertexArrays[index2].Vertexes[index4].Y;
                                rx3File1.Rx3VertexArrays[index1].Vertexes[index3].Z = rx3File.Rx3VertexArrays[index2].Vertexes[index4].Z + offset;
                            }
                        }
                    }
                    else if (rx3File1.Rx3VertexArrays[index1].nVertex == 132 && rx3File.Rx3VertexArrays[index2].nVertex == 132)
                    {
                        for (int index3 = 0; index3 < rx3File1.Rx3VertexArrays[index1].nVertex; ++index3)
                        {
                            float num1 = float.MaxValue;
                            int index4 = -1;
                            for (int index5 = 0; index5 < rx3File1.Rx3VertexArrays[index1].nVertex; ++index5)
                            {
                                if ((double)rx3File1.Rx3VertexArrays[index1].Vertexes[index3].X * (double)rx3File.Rx3VertexArrays[index2].Vertexes[index5].X > 0.0)
                                {
                                    float num2 = (float)(((double)rx3File1.Rx3VertexArrays[index1].Vertexes[index3].U - (double)rx3File.Rx3VertexArrays[index2].Vertexes[index5].U) * ((double)rx3File1.Rx3VertexArrays[index1].Vertexes[index3].U - (double)rx3File.Rx3VertexArrays[index2].Vertexes[index5].U) + ((double)rx3File1.Rx3VertexArrays[index1].Vertexes[index3].V - (double)rx3File.Rx3VertexArrays[index2].Vertexes[index5].V) * ((double)rx3File1.Rx3VertexArrays[index1].Vertexes[index3].V - (double)rx3File.Rx3VertexArrays[index2].Vertexes[index5].V));
                                    if ((double)num2 < (double)num1)
                                    {
                                        num1 = num2;
                                        index4 = index5;
                                    }
                                }
                            }
                            if (index4 != -1)
                            {
                                rx3File1.Rx3VertexArrays[index1].Vertexes[index3].X = rx3File.Rx3VertexArrays[index2].Vertexes[index4].X;
                                rx3File1.Rx3VertexArrays[index1].Vertexes[index3].Y = rx3File.Rx3VertexArrays[index2].Vertexes[index4].Y;
                                rx3File1.Rx3VertexArrays[index1].Vertexes[index3].Z = rx3File.Rx3VertexArrays[index2].Vertexes[index4].Z + offset;
                            }
                        }
                    }
                }
            }
            rx3File1.Save(targetFileName, false, true);
        }

        public bool DeleteHeadModel()
        {
            if (!this.HasSpecificHeadModel)
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(5062);
                return false;
            }
            bool flag = FifaEnvironment.DeleteFromZdata(this.SpecificHeadModelFileName());
            if (flag)
                this.m_HeadModelFile = (Rx3File)null;
            return flag;
        }

        public void CleanHeadModel()
        {
            this.m_HeadModelFile = (Rx3File)null;
        }

        public void CleanHead()
        {
            this.CleanFaceTextures();
            this.CleanEyesTexture();
            this.CleanHeadModel();
        }

        public Rx3File GetHairModel()
        {
            if (this.m_HairModelFile != null)
                return this.m_HairModelFile;
            Rx3VertexFormat.LoadingHairMesh = true;
            this.m_HairModelFile = this.m_headclasscode != 0 ? FifaEnvironment.GetRx3FromZdata(this.GenericHairModelFileName()) : FifaEnvironment.GetRx3FromZdata(this.SpecificHairModelFileName());
            Rx3VertexFormat.LoadingHairMesh = false;
            return this.m_HairModelFile;
        }

        public bool SetHairLodModel(string rx3FileName)
        {
            if (!this.HasSpecificHeadModel)
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(5062);
                return false;
            }
            return FifaEnvironment.ImportFileIntoZdataAs(rx3FileName, this.SpecificHairLodModelFileName(), false, ECompressionMode.Chunkzip);
        }

        public bool SetHairModel(string rx3FileName)
        {
            if (!this.HasSpecificHeadModel)
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(5062);
                return false;
            }
            bool flag = FifaEnvironment.ImportFileIntoZdataAs(rx3FileName, this.SpecificHairModelFileName(), false, ECompressionMode.Chunkzip);
            if (flag)
                this.m_HairModelFile = FifaEnvironment.GetRx3FromZdata(this.SpecificHairModelFileName());
            return flag;
        }

        public bool UpdateHairVertex(
          CustomVertex.PositionNormalTextured[] newVertex4,
          CustomVertex.PositionNormalTextured[] newVertex5)
        {
            if (!this.HasSpecificHeadModel)
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(5062);
                return false;
            }
            FifaEnvironment.FifaFat.ExtractFile(this.SpecificHairModelFileName());
            Rx3VertexFormat.LoadingHairMesh = true;
            this.m_HairModelFile = new Rx3File();
            this.m_HairModelFile.Load(FifaEnvironment.GameDir + this.SpecificHairModelFileName());
            Rx3VertexFormat.LoadingHairMesh = false;
            if (this.m_HairModelFile.Rx3VertexArrays == null)
                return false;
            if (newVertex4 != null && this.m_HairModelFile.Rx3VertexArrays.Length >= 1 && this.m_HairModelFile.Rx3VertexArrays[0] != null)
                this.m_HairModelFile.Rx3VertexArrays[0].SetVertex(newVertex4);
            if (newVertex5 != null && this.m_HairModelFile.Rx3VertexArrays.Length >= 2 && this.m_HairModelFile.Rx3VertexArrays[1] != null)
                this.m_HairModelFile.Rx3VertexArrays[1].SetVertex(newVertex5);
            this.m_HairModelFile.Save(FifaEnvironment.GameDir + this.SpecificHairModelFileName(), false, true);
            return true;
        }

        public bool DeleteHairModel()
        {
            if (!this.HasSpecificHeadModel)
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(5062);
                return false;
            }
            bool flag = FifaEnvironment.DeleteFromZdata(this.SpecificHairModelFileName());
            if (flag)
                this.m_HairModelFile = (Rx3File)null;
            return flag;
        }

        public bool DeleteHairLodModel()
        {
            if (this.HasSpecificHeadModel)
                return FifaEnvironment.DeleteFromZdata(this.SpecificHairLodModelFileName());
            int num = (int)FifaEnvironment.UserMessages.ShowMessage(5062);
            return false;
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

        public bool SetHairTextures(Bitmap colorBitmap, Bitmap alfaBitmap)
        {
            if (!this.HasSpecificHeadModel)
            {
                int num = (int)FifaEnvironment.UserMessages.ShowMessage(5038);
                return false;
            }
            return this.SetHairTextures(new Bitmap[2]
            {
        alfaBitmap,
        colorBitmap
            });
        }

        public void SavePlayer(Record r)
        {
            string name1 = (string)null;
            Player.s_PlayerNames.TryGetValue(this.m_firstnameid, out name1, true);
            if (name1 != this.m_firstname)
                this.m_firstnameid = Player.s_PlayerNames.GetKey(this.m_firstname);
            string name2 = (string)null;
            Player.s_PlayerNames.TryGetValue(this.m_lastnameid, out name2, true);
            if (name2 != this.m_lastname)
                this.m_lastnameid = Player.s_PlayerNames.GetKey(this.m_lastname, this.m_commentaryid);
            string name3 = (string)null;
            Player.s_PlayerNames.TryGetValue(this.m_commonnameid, out name3, true);
            if (name3 != this.m_commonname)
                this.m_commonnameid = Player.s_PlayerNames.GetKey(this.m_commonname);
            if (this.m_commentaryid > 900000)
            {
                if (this.m_audioname == this.m_commonname)
                    Player.s_PlayerNames.SetCommentaryId(this.m_commonnameid, this.m_commentaryid);
                else if (this.m_audioname == this.m_lastname)
                    Player.s_PlayerNames.SetCommentaryId(this.m_lastnameid, this.m_commentaryid);
            }
            string name4 = (string)null;
            Player.s_PlayerNames.TryGetValue(this.m_playerjerseynameid, out name4, true);
            if (name4 != this.m_playerjerseyname)
                this.m_playerjerseynameid = Player.s_PlayerNames.GetKey(this.m_playerjerseyname);
            r.IntField[FI.players_playerid] = this.Id;
            r.IntField[FI.players_firstnameid] = this.m_firstnameid;
            r.IntField[FI.players_lastnameid] = this.m_lastnameid;
            r.IntField[FI.players_commonnameid] = this.m_commonnameid;
            r.IntField[FI.players_playerjerseynameid] = this.m_playerjerseynameid;
            r.IntField[FI.players_birthdate] = FifaUtil.ConvertFromDate(this.m_birthdate);
            r.IntField[FI.players_playerjointeamdate] = FifaUtil.ConvertFromDate(this.m_playerjointeamdate);
            r.IntField[FI.players_contractvaliduntil] = this.m_contractvaliduntil;
            r.IntField[FI.players_height] = this.m_height;
            r.IntField[FI.players_weight] = this.m_weight;
            r.IntField[FI.players_preferredposition1] = this.m_preferredposition1;
            r.IntField[FI.players_preferredposition2] = this.m_preferredposition2;
            r.IntField[FI.players_preferredposition3] = this.m_preferredposition3;
            r.IntField[FI.players_preferredposition4] = this.m_preferredposition4;
            r.IntField[FI.players_preferredfoot] = this.m_preferredfoot + 1;
            r.IntField[FI.players_jerseysleevelengthcode] = this.m_jerseysleevelengthcode;
            r.IntField[FI.players_jerseystylecode] = this.m_jerseystylecode;
            r.IntField[FI.players_hasseasonaljersey] = this.m_hasseasonaljersey;
            r.IntField[FI.players_animfreekickstartposcode] = this.m_animfreekickstartposcode;
            r.IntField[FI.players_animpenaltieskickstylecode] = this.m_animpenaltieskickstylecode;
            r.IntField[FI.players_animpenaltiesmotionstylecode] = this.m_animpenaltiesmotionstylecode;
            r.IntField[FI.players_animpenaltiesstartposcode] = this.m_animpenaltiesstartposcode;
            r.IntField[FI.players_accessorycode1] = this.m_accessorycode1;
            r.IntField[FI.players_accessorycolourcode1] = this.m_accessorycolourcode1;
            r.IntField[FI.players_accessorycode2] = this.m_accessorycode2;
            r.IntField[FI.players_accessorycolourcode2] = this.m_accessorycolourcode2;
            r.IntField[FI.players_accessorycode3] = this.m_accessorycode3;
            r.IntField[FI.players_accessorycolourcode3] = this.m_accessorycolourcode3;
            r.IntField[FI.players_accessorycode4] = this.m_accessorycode4;
            r.IntField[FI.players_accessorycolourcode4] = this.m_accessorycolourcode4;
            r.IntField[FI.players_acceleration] = this.m_acceleration;
            r.IntField[FI.players_aggression] = this.m_aggression;
            r.IntField[FI.players_sprintspeed] = this.m_sprintspeed;
            r.IntField[FI.players_stamina] = this.m_stamina;
            r.IntField[FI.players_strength] = this.m_strength;
            r.IntField[FI.players_marking] = this.m_marking;
            r.IntField[FI.players_standingtackle] = this.m_standingtackle;
            r.IntField[FI.players_slidingtackle] = this.m_slidingtackle;
            r.IntField[FI.players_ballcontrol] = this.m_ballcontrol;
            r.IntField[FI.players_dribbling] = this.m_dribbling;
            r.IntField[FI.players_crossing] = this.m_crossing;
            r.IntField[FI.players_headingaccuracy] = this.m_headingaccuracy;
            r.IntField[FI.players_shortpassing] = this.m_shortpassing;
            r.IntField[FI.players_longpassing] = this.m_longpassing;
            r.IntField[FI.players_longshots] = this.m_longshots;
            r.IntField[FI.players_finishing] = this.m_finishing;
            r.IntField[FI.players_shotpower] = this.m_shotpower;
            r.IntField[FI.players_reactions] = this.m_reactions;
            r.IntField[FI.players_gkreflexes] = this.m_gkreflexes;
            r.IntField[FI.players_gkglovetypecode] = this.m_gkglovetypecode;
            r.IntField[FI.players_agility] = this.m_agility;
            r.IntField[FI.players_balance] = this.m_balance;
            r.IntField[FI.players_gkkicking] = this.m_gkkicking;
            r.IntField[FI.players_gkkickstyle] = this.m_gkkickstyle;
            r.IntField[FI.players_jumping] = this.m_jumping;
            r.IntField[FI.players_penalties] = this.m_penalties;
            r.IntField[FI.players_vision] = this.m_vision;
            r.IntField[FI.players_volleys] = this.m_volleys;
            r.IntField[FI.players_skillmoves] = this.m_skillmoves;
            r.IntField[FI.players_usercaneditname] = this.m_usercaneditname;
            r.IntField[FI.players_gkhandling] = this.m_gkhandling;
            r.IntField[FI.players_gkdiving] = this.m_gkdiving;
            r.IntField[FI.players_gkpositioning] = this.m_gkpositioning;
            r.IntField[FI.players_positioning] = this.m_positioning;
            r.IntField[FI.players_potential] = this.m_potential;
            r.IntField[FI.players_freekickaccuracy] = this.m_freekickaccuracy;
            r.IntField[FI.players_nationality] = this.m_nationality;
            r.IntField[FI.players_finishingcode1] = this.m_finishingcode1;
            r.IntField[FI.players_finishingcode2] = this.m_finishingcode2;
            r.IntField[FI.players_runningcode1] = this.m_runningcode1;
            r.IntField[FI.players_runningcode2] = this.m_runningcode2;
            r.IntField[FI.players_gksavetype] = this.m_gksavetype;
            //r.IntField[FI.players_faceposercode] = this.m_faceposercode;
            r.IntField[FI.players_isretiring] = this.m_isretiring;
            r.IntField[FI.players_socklengthcode] = this.m_socklengthcode;
            r.IntField[FI.players_hashighqualityhead] = this.m_hashighqualityhead;
            r.IntField[FI.players_attackingworkrate] = this.m_attackingworkrate;
            r.IntField[FI.players_defensiveworkrate] = this.m_defensiveworkrate;
            r.IntField[FI.players_shortstyle] = this.m_shortstyle ? 1 : 0;
            int num1 = 0 | (this.m_Inflexible ? 1 : 0) | (this.m_Longthrows ? 2 : 0) | (this.m_PowerfulFreeKicks ? 4 : 0) | (this.m_Diver ? 8 : 0) | (this.m_InjuryProne ? 16 : 0) | (this.m_InjuryFree ? 32 : 0) | (this.m_AvoidsWeakFoot ? 64 : 0) | (this.m_Divesintotackles ? 128 : 0) | (this.m_BeatDefensiveLine ? 256 : 0) | (this.m_Selfish ? 512 : 0) | (this.m_Leadership ? 1024 : 0) | (this.m_ArguesWithOfficials ? 2048 : 0) | (this.m_Earlycrosser ? 4096 : 0) | (this.m_FinesseShot ? 8192 : 0) | (this.m_Flair ? 16384 : 0) | (this.m_LongPasser ? 32768 : 0) | (this.m_LongShotTaker ? 65536 : 0) | (this.m_Technicaldribbler ? 131072 : 0) | (this.m_Playmaker ? 262144 : 0) | (this.m_Pushesupforcorners ? 524288 : 0) | (this.m_Puncher ? 1048576 : 0) | (this.m_GkLongThrower ? 2097152 : 0) | (this.m_PowerHeader ? 4194304 : 0) | (this.m_GkOneOnOne ? 8388608 : 0) | (this.m_GiantThrow ? 16777216 : 0) | (this.m_OutsideFootShot ? 33554432 : 0) | (this.m_CrowdFavorite ? 67108864 : 0) | (this.m_SwervePasser ? 134217728 : 0) | (this.m_SecondWind ? 268435456 : 0) | (this.m_AcrobaticClearance ? 536870912 : 0);
            int num2 = num1 | (r.IntField[FI.players_trait1] = num1);
            int num3 = 0 | (this.m_FancyFeet ? 1 : 0) | (this.m_FancyPasses ? 2 : 0) | (this.m_FancyFlicks ? 4 : 0) | (this.m_StutterPenalty ? 8 : 0) | (this.m_ChipperPenalty ? 16 : 0) | (this.m_BycicleKick ? 32 : 0) | (this.m_DivingHeader ? 64 : 0) | (this.m_DrivenPass ? 128 : 0) | (this.m_GkFlatKick ? 256 : 0) | (this.m_HighClubIdentification ? 512 : 0) | (this.m_TeamPlayer ? 1024 : 0);
            r.IntField[FI.players_trait2] = num3;
            r.IntField[FI.players_bodytypecode] = this.m_bodytypecode + 1;
            r.IntField[FI.players_weakfootabilitytypecode] = this.m_weakfootabilitytypecode;
            r.IntField[FI.players_curve] = this.m_curve;
            r.IntField[FI.players_internationalrep] = this.m_internationalrep + 1;
            r.IntField[FI.players_eyecolorcode] = this.m_eyecolorcode;
            r.IntField[FI.players_eyebrowcode] = this.m_eyebrowcode;
            r.IntField[FI.players_hairtypecode] = this.m_hairtypecode;
            r.IntField[FI.players_headtypecode] = this.m_headtypecode;
            r.IntField[FI.players_headclasscode] = this.m_headclasscode;
            r.IntField[FI.players_haircolorcode] = this.m_haircolorcode;
            r.IntField[FI.players_facialhairtypecode] = this.m_facialhairtypecode;
            r.IntField[FI.players_facialhaircolorcode] = this.m_facialhaircolorcode;
            r.IntField[FI.players_sideburnscode] = this.m_sideburnscode;
            r.IntField[FI.players_skintypecode] = this.m_skintypecode;
            r.IntField[FI.players_skintonecode] = this.m_skintonecode;
            r.IntField[FI.players_shoecolorcode1] = this.m_shoecolorcode1;
            r.IntField[FI.players_shoetypecode] = this.m_shoetypecode;
            r.IntField[FI.players_overallrating] = this.m_overallrating;
            r.IntField[FI.players_interceptions] = this.m_interceptions;
            r.IntField[FI.players_shoecolorcode2] = this.m_shoecolorcode2;
            r.IntField[FI.players_jerseyfit] = this.m_jerseyfit ? 1 : 0;
            r.IntField[FI.players_shoedesigncode] = this.m_shoedesigncode;
        }

        public void RandomizeAttributes(int level)
        {
            int meanLevel = Player.s_MeanLevels[level];
            int preferredposition1 = this.m_preferredposition1;
            int num1 = FifaUtil.Limit(Player.c_Attributes[preferredposition1, 0] * meanLevel / 100, 11, 90);
            int num2 = FifaUtil.Limit(Player.c_Attributes[preferredposition1, 1] * meanLevel / 100, 11, 90);
            int num3 = FifaUtil.Limit(Player.c_Attributes[preferredposition1, 2] * meanLevel / 100, 11, 90);
            int num4 = FifaUtil.Limit(Player.c_Attributes[preferredposition1, 3] * meanLevel / 100, 11, 90);
            this.m_gkreflexes = Player.m_Randomizer.Next(num1 - 10, num1 + 10);
            this.m_gkdiving = Player.m_Randomizer.Next(num1 - 10, num1 + 10);
            this.m_gkpositioning = Player.m_Randomizer.Next(num1 - 10, num1 + 10);
            this.m_gkhandling = Player.m_Randomizer.Next(num1 - 10, num1 + 10);
            this.m_gkkicking = Player.m_Randomizer.Next(num1 - 10, num1 + 10);
            int num5 = 20 + level * 8 + (this.m_height - 175) * 2;
            if (num5 > 90)
                num5 = 90;
            if (num5 < 20)
                num5 = 20;
            this.m_headingaccuracy = Player.m_Randomizer.Next(num5 - 10, num5 + 10);
            this.m_marking = Player.m_Randomizer.Next(num2 - 7, num2 + 7);
            this.m_interceptions = Player.m_Randomizer.Next(num2 - 7, num2 + 7);
            this.m_standingtackle = Player.m_Randomizer.Next(num2 - 7, num2 + 7);
            this.m_slidingtackle = Player.m_Randomizer.Next(num2 - 7, num2 + 7);
            this.m_aggression = Player.m_Randomizer.Next(num2 - 10, num2 + 10);
            this.m_shortpassing = Player.m_Randomizer.Next(num3 - 7, num3 + 7);
            this.m_longpassing = Player.m_Randomizer.Next(num3 - 7, num3 + 7);
            this.m_crossing = Player.m_Randomizer.Next(num3 - 7, num3 + 7);
            this.m_ballcontrol = Player.m_Randomizer.Next(num3 - 7, num3 + 7);
            this.m_vision = Player.m_Randomizer.Next(num3 - 10, num3 + 10);
            this.m_weakfootabilitytypecode = Player.m_Randomizer.Next(1, 6);
            this.m_curve = Player.m_Randomizer.Next(num3 - 10, num3 + 10);
            this.m_finishing = Player.m_Randomizer.Next(num4 - 7, num4 + 7);
            this.m_shotpower = Player.m_Randomizer.Next(num4 - 10, num4 + 10);
            this.m_longshots = Player.m_Randomizer.Next(num4 - 10, num4 + 10);
            this.m_dribbling = Player.m_Randomizer.Next(num4 - 7, num4 + 7);
            this.m_volleys = Player.m_Randomizer.Next(num4 - 10, num4 + 10);
            this.m_penalties = Player.m_Randomizer.Next(num4 - 10, num4 + 10);
            this.m_positioning = Player.m_Randomizer.Next(num4 - 10, num4 + 10);
            int num6 = 37 + level * 8;
            this.m_acceleration = Player.m_Randomizer.Next(num6 - 10, num6 + 10);
            this.m_sprintspeed = Player.m_Randomizer.Next(num6 - 10, num6 + 10);
            this.m_stamina = Player.m_Randomizer.Next(num6 - 10, num6 + 10);
            this.m_strength = Player.m_Randomizer.Next(num6 - 10, num6 + 10);
            this.m_potential = Player.m_Randomizer.Next(num6 - 10, num6 + 10);
            this.m_freekickaccuracy = Player.m_Randomizer.Next(num6 - 10, num6 + 10);
            this.m_reactions = Player.m_Randomizer.Next(num6 - 10, num6 + 10);
            this.m_agility = Player.m_Randomizer.Next(num6 - 10, num6 + 10);
            this.m_balance = Player.m_Randomizer.Next(num6 - 10, num6 + 10);
            this.m_jumping = Player.m_Randomizer.Next(num6 - 10, num6 + 10);
            this.m_InjuryFree = Player.m_Randomizer.Next(0, 100) <= 5;
            this.m_InjuryProne = !this.m_InjuryFree && Player.m_Randomizer.Next(0, 100) <= 5;
            if (level >= 4)
                this.m_Leadership = Player.m_Randomizer.Next(0, 100) <= 5;
            this.m_ArguesWithOfficials = Player.m_Randomizer.Next(0, 100) <= 5;
            this.m_AvoidsWeakFoot = Player.m_Randomizer.Next(0, 100) <= 5;
            if (this.m_preferredposition1 == 0)
            {
                this.m_Pushesupforcorners = Player.m_Randomizer.Next(0, 100) <= 5;
                this.m_Puncher = Player.m_Randomizer.Next(0, 100) <= 5;
                this.m_GkLongThrower = Player.m_Randomizer.Next(0, 100) <= 5;
                this.m_gksavetype = Player.m_Randomizer.Next(0, 100) <= 20 ? 1 : 0;
                this.m_GkOneOnOne = Player.m_Randomizer.Next(0, 100) <= 5;
            }
            else
            {
                if (num4 >= 75)
                    this.m_Selfish = Player.m_Randomizer.Next(0, 100) <= 5;
                this.m_Playmaker = num3 >= 70 && Player.m_Randomizer.Next(0, 100) <= 5;
                this.m_Diver = Player.m_Randomizer.Next(0, 100) <= 5;
                if (preferredposition1 < 12)
                    this.m_Divesintotackles = Player.m_Randomizer.Next(0, 100) <= 5;
                this.m_LongShotTaker = Player.m_Randomizer.Next(0, 100) <= 5;
                this.m_Earlycrosser = Player.m_Randomizer.Next(0, 100) <= 5;
                this.m_LongPasser = Player.m_Randomizer.Next(0, 100) <= 5;
                this.m_Longthrows = Player.m_Randomizer.Next(0, 100) <= 2;
                this.m_Inflexible = Player.m_Randomizer.Next(0, 100) <= 2;
                if (this.m_dribbling > 75)
                    this.m_Technicaldribbler = Player.m_Randomizer.Next(0, 100) <= this.m_dribbling - 70;
                if (this.m_curve > 75)
                    this.m_OutsideFootShot = Player.m_Randomizer.Next(0, 100) <= this.m_curve - 70;
                if (num3 >= 80 || num4 >= 85)
                {
                    this.m_Flair = Player.m_Randomizer.Next(0, 100) <= 10;
                    this.m_FinesseShot = Player.m_Randomizer.Next(0, 100) <= 10;
                }
                this.m_PowerfulFreeKicks = Player.m_Randomizer.Next(0, 100) <= 5;
                if ((double)this.m_height > 1.85)
                    this.m_PowerHeader = Player.m_Randomizer.Next(0, 100) <= this.m_height - 180;
                this.m_BeatDefensiveLine = Player.m_Randomizer.Next(0, 100) <= 5;
            }
            this.m_animfreekickstartposcode = Player.m_Randomizer.Next(0, 10);
            this.m_animpenaltieskickstylecode = Player.m_Randomizer.Next(0, 3);
            this.m_animpenaltiesmotionstylecode = Player.m_Randomizer.Next(0, 7);
            this.m_animpenaltiesstartposcode = Player.m_Randomizer.Next(0, 9);
            int num7 = level - 1;
            this.m_internationalrep = num7 < 1 ? 1 : num7;
            this.m_overallrating = this.GetAverageRoleAttribute();
        }

        public void RandomizeIdentity()
        {
            this.m_height = Player.m_Randomizer.Next(165, 196);
            this.m_bodytypecode = Player.m_Randomizer.Next(0, 3);
            this.m_weight = this.m_height - 110 + this.m_bodytypecode * 5 + Player.m_Randomizer.Next(0, 5);
            this.m_preferredfoot = Player.m_Randomizer.Next(0, 100) < 10 ? 1 : 0;
            this.m_weakfootabilitytypecode = Player.m_Randomizer.Next(1, 6);
            this.m_jerseysleevelengthcode = Player.m_Randomizer.Next(0, 100) < 5 ? 1 : 0;
            this.m_jerseystylecode = Player.m_Randomizer.Next(0, 100) < 10 ? 1 : 0;
            this.m_hasseasonaljersey = Player.m_Randomizer.Next(0, 100) < 40 ? 1 : 0;
            this.m_birthdate = new DateTime(1974, 1, 1) + new TimeSpan(Player.m_Randomizer.Next(1, 7665), 0, 0, 0);
        }

        public void RandomizeCaucasianAppearance()
        {
            int[] numArray = new int[10]
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
            this.m_headtypecode = Player.m_Randomizer.Next(1, 11) > 7 ? GenericHead.c_LatinModels[Player.m_Randomizer.Next(0, GenericHead.c_LatinModels.Length)] : GenericHead.c_CaucasicModels[Player.m_Randomizer.Next(0, GenericHead.c_CaucasicModels.Length)];
            this.m_hairtypecode = Player.m_Randomizer.Next(0, 109);
            this.m_haircolorcode = Player.m_Randomizer.Next(0, 8);
            this.m_sideburnscode = Player.m_Randomizer.Next(0, 2);
            this.m_skintonecode = Player.m_Randomizer.Next(1, 5);
            if (this.m_skintonecode == 1)
                this.m_skintonecode = 2;
            if (this.m_skintonecode == 3)
                this.m_skintonecode = 2;
            this.m_skintypecode = Player.m_Randomizer.Next(0, 3);
            this.m_eyecolorcode = Player.m_Randomizer.Next(1, 8);
            this.m_facialhairtypecode = Player.m_Randomizer.Next(0, 10);
            if (this.m_facialhairtypecode == 2 || this.m_facialhairtypecode > 7)
                this.m_facialhairtypecode = 0;
            this.m_facialhaircolorcode = numArray[this.m_haircolorcode];
        }

        public void RandomizeAsiaticAppearance()
        {
            int[] numArray = new int[10]
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
            this.m_headtypecode = Player.m_Randomizer.Next(1, 11) > 9 ? GenericHead.c_CaucasicModels[Player.m_Randomizer.Next(0, GenericHead.c_CaucasicModels.Length)] : GenericHead.c_AsiaticModels[Player.m_Randomizer.Next(0, GenericHead.c_AsiaticModels.Length)];
            this.m_hairtypecode = Player.m_Randomizer.Next(0, 109);
            this.m_haircolorcode = Player.m_Randomizer.Next(1, 6);
            if (this.m_haircolorcode == 3)
                this.m_haircolorcode = 1;
            this.m_sideburnscode = Player.m_Randomizer.Next(0, 2);
            this.m_skintonecode = Player.m_Randomizer.Next(3, 7);
            if (this.m_skintonecode == 3)
                this.m_skintonecode = 4;
            this.m_skintypecode = Player.m_Randomizer.Next(0, 3);
            this.m_eyecolorcode = Player.m_Randomizer.Next(3, 8);
            this.m_facialhairtypecode = Player.m_Randomizer.Next(0, 10);
            if (this.m_facialhairtypecode == 2 || this.m_facialhairtypecode > 7)
                this.m_facialhairtypecode = 0;
            this.m_facialhaircolorcode = numArray[this.m_haircolorcode];
        }

        public void RandomizeAfricanAppearance()
        {
            int[] numArray = new int[10]
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
            this.m_headtypecode = Player.m_Randomizer.Next(1, 11) > 7 ? GenericHead.c_LatinModels[Player.m_Randomizer.Next(0, GenericHead.c_LatinModels.Length)] : GenericHead.c_AfricanModels[Player.m_Randomizer.Next(0, GenericHead.c_AfricanModels.Length)];
            this.m_hairtypecode = Player.m_Randomizer.Next(0, 109);
            this.m_haircolorcode = 1;
            this.m_sideburnscode = Player.m_Randomizer.Next(0, 2);
            this.m_skintonecode = Player.m_Randomizer.Next(6, 11);
            if (this.m_skintonecode == 7)
                this.m_skintonecode = 8;
            this.m_skintypecode = Player.m_Randomizer.Next(0, 3);
            this.m_eyecolorcode = Player.m_Randomizer.Next(3, 5);
            this.m_facialhairtypecode = Player.m_Randomizer.Next(0, 5);
            if (this.m_facialhairtypecode == 2 || this.m_facialhairtypecode > 7)
                this.m_facialhairtypecode = 0;
            this.m_facialhaircolorcode = numArray[this.m_haircolorcode];
        }

        public void RandomizeLatinAppearance()
        {
            int[] numArray = new int[10]
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
            this.m_headtypecode = Player.m_Randomizer.Next(1, 11) > 7 ? GenericHead.c_CaucasicModels[Player.m_Randomizer.Next(0, GenericHead.c_CaucasicModels.Length)] : GenericHead.c_LatinModels[Player.m_Randomizer.Next(0, GenericHead.c_LatinModels.Length)];
            this.m_hairtypecode = Player.m_Randomizer.Next(0, 112);
            this.m_haircolorcode = 1;
            this.m_sideburnscode = Player.m_Randomizer.Next(0, 2);
            this.m_skintonecode = Player.m_Randomizer.Next(4, 7);
            this.m_skintypecode = Player.m_Randomizer.Next(0, 3);
            this.m_eyecolorcode = Player.m_Randomizer.Next(3, 8);
            this.m_facialhairtypecode = Player.m_Randomizer.Next(0, 10);
            if (this.m_facialhairtypecode == 2 || this.m_facialhairtypecode > 7)
                this.m_facialhairtypecode = 0;
            this.m_facialhaircolorcode = numArray[this.m_haircolorcode];
        }

        public int ComputeMeanAttributes(int type)
        {
            switch (type)
            {
                case 0:
                    return (this.m_gkpositioning + this.m_gkdiving + this.m_gkreflexes + this.m_gkhandling + this.m_gkkicking) / 5;
                case 1:
                    return (this.m_aggression + this.m_standingtackle + this.m_slidingtackle + this.m_marking + this.m_interceptions) / 5;
                case 2:
                    return (this.m_crossing + this.m_shortpassing + this.m_longpassing + this.m_ballcontrol + this.m_vision + this.m_curve) / 6;
                case 3:
                    return (this.m_finishing + this.m_shotpower + this.m_longshots + this.m_dribbling + this.m_headingaccuracy + this.m_volleys) / 6;
                case 4:
                    return (this.m_acceleration + this.m_sprintspeed + this.m_stamina + this.m_strength + this.m_agility + this.m_jumping + this.m_reactions + this.m_balance) / 8;
                case 5:
                    return (this.m_potential + this.m_positioning) / 2;
                case 6:
                    return (this.m_freekickaccuracy + this.m_penalties) / 2;
                default:
                    return 0;
            }
        }

        public int GetAverageRoleAttribute()
        {
            int num;
            switch (this.m_preferredposition1)
            {
                case 0:
                    num = (this.m_gkreflexes * 22 + this.m_gkhandling * 22 + this.m_gkdiving * 24 + this.m_gkpositioning * 22 + this.m_gkkicking * 4 + this.m_reactions * 6 + 50) / 100;
                    if (num > 99)
                    {
                        num = 99;
                        break;
                    }
                    break;
                case 1:
                    num = (this.m_interceptions * 20 + this.m_standingtackle * 14 + this.m_marking * 12 + this.m_slidingtackle * 12 + this.m_headingaccuracy * 8 + this.m_ballcontrol * 7 + this.m_shortpassing * 6 + this.m_reactions * 6 + this.m_vision * 6 + this.m_longpassing * 5 + this.m_aggression * 4 + 50) / 100;
                    if (num > 99)
                    {
                        num = 99;
                        break;
                    }
                    break;
                case 2:
                case 8:
                    num = (this.m_standingtackle * 11 + this.m_slidingtackle * 10 + this.m_crossing * 10 + this.m_shortpassing * 10 + this.m_ballcontrol * 10 + this.m_interceptions * 10 + this.m_marking * 9 + this.m_stamina * 8 + this.m_reactions * 8 + this.m_dribbling * 7 + this.m_sprintspeed * 4 + this.m_agility * 3 + 50) / 100;
                    if (num > 99)
                    {
                        num = 99;
                        break;
                    }
                    break;
                case 3:
                case 7:
                    num = (this.m_slidingtackle * 13 + this.m_standingtackle * 12 + this.m_interceptions * 12 + this.m_marking * 10 + this.m_stamina * 8 + this.m_reactions * 8 + this.m_crossing * 7 + this.m_headingaccuracy * 7 + this.m_ballcontrol * 7 + this.m_shortpassing * 6 + this.m_sprintspeed * 5 + this.m_aggression * 5 + 50) / 100;
                    if (num > 99)
                    {
                        num = 99;
                        break;
                    }
                    break;
                case 4:
                case 5:
                case 6:
                    num = (this.m_marking * 15 + this.m_standingtackle * 15 + this.m_slidingtackle * 15 + this.m_headingaccuracy * 10 + this.m_strength * 10 + this.m_aggression * 8 + this.m_interceptions * 8 + this.m_shortpassing * 5 + this.m_ballcontrol * 5 + this.m_reactions * 5 + this.m_jumping * 4 + 50) / 100;
                    if (num > 99)
                    {
                        num = 99;
                        break;
                    }
                    break;
                case 9:
                case 10:
                case 11:
                    num = (this.m_shortpassing * 13 + this.m_interceptions * 13 + this.m_longpassing * 11 + this.m_marking * 10 + this.m_standingtackle * 10 + this.m_ballcontrol * 9 + this.m_reactions * 9 + this.m_vision * 8 + this.m_stamina * 6 + this.m_strength * 6 + this.m_aggression * 5 + 50) / 100;
                    if (num > 99)
                    {
                        num = 99;
                        break;
                    }
                    break;
                case 12:
                case 16:
                    num = (this.m_crossing * 14 + this.m_dribbling * 14 + this.m_ballcontrol * 12 + this.m_shortpassing * 12 + this.m_longpassing * 8 + this.m_vision * 8 + this.m_reactions * 7 + this.m_positioning * 7 + this.m_acceleration * 5 + this.m_sprintspeed * 5 + this.m_stamina * 5 + this.m_agility * 3 + 50) / 100;
                    if (num > 99)
                    {
                        num = 99;
                        break;
                    }
                    break;
                case 13:
                case 14:
                case 15:
                    num = (this.m_shortpassing * 15 + this.m_longpassing * 13 + this.m_vision * 12 + this.m_ballcontrol * 10 + this.m_dribbling * 9 + this.m_reactions * 8 + this.m_interceptions * 8 + this.m_positioning * 8 + this.m_standingtackle * 6 + this.m_stamina * 6 + this.m_longshots * 5 + 50) / 100;
                    if (num > 99)
                    {
                        num = 99;
                        break;
                    }
                    break;
                case 17:
                case 18:
                case 19:
                    num = (this.m_shortpassing * 16 + this.m_vision * 16 + this.m_ballcontrol * 13 + this.m_positioning * 12 + this.m_dribbling * 11 + this.m_reactions * 8 + this.m_longshots * 6 + this.m_finishing * 5 + this.m_shotpower * 5 + this.m_acceleration * 4 + this.m_agility * 4 + 50) / 100;
                    if (num > 99)
                    {
                        num = 99;
                        break;
                    }
                    break;
                case 20:
                case 21:
                case 22:
                    num = (this.m_finishing * 12 + this.m_positioning * 12 + this.m_dribbling * 11 + this.m_ballcontrol * 11 + this.m_shotpower * 10 + this.m_longshots * 10 + this.m_reactions * 10 + this.m_shortpassing * 6 + this.m_headingaccuracy * 5 + this.m_vision * 5 + this.m_acceleration * 4 + this.m_sprintspeed * 4 + 50) / 100;
                    if (num > 99)
                    {
                        num = 99;
                        break;
                    }
                    break;
                case 23:
                case 27:
                    num = (this.m_crossing * 16 + this.m_dribbling * 16 + this.m_ballcontrol * 13 + this.m_shortpassing * 10 + this.m_positioning * 9 + this.m_acceleration * 6 + this.m_sprintspeed * 6 + this.m_reactions * 6 + this.m_agility * 5 + this.m_vision * 5 + this.m_finishing * 4 + this.m_longshots * 4 + 50) / 100;
                    if (num > 99)
                    {
                        num = 99;
                        break;
                    }
                    break;
                case 24:
                case 25:
                case 26:
                    num = (this.m_finishing * 20 + this.m_positioning * 12 + this.m_headingaccuracy * 10 + this.m_shotpower * 10 + this.m_reactions * 10 + this.m_dribbling * 8 + this.m_ballcontrol * 8 + this.m_volleys * 5 + this.m_longshots * 5 + this.m_acceleration * 5 + this.m_sprintspeed * 4 + this.m_strength * 3 + 50) / 100;
                    if (num > 99)
                    {
                        num = 99;
                        break;
                    }
                    break;
                default:
                    return 0;
            }
            switch (this.m_internationalrep + 1)
            {
                case 3:
                    if (num > 50)
                    {
                        ++num;
                        break;
                    }
                    break;
                case 4:
                    if (num > 68)
                    {
                        num += 2;
                        break;
                    }
                    if (num > 34)
                    {
                        ++num;
                        break;
                    }
                    break;
                case 5:
                    if (num > 77)
                    {
                        num += 3;
                        break;
                    }
                    if (num > 51)
                    {
                        num += 2;
                        break;
                    }
                    if (num > 25)
                    {
                        ++num;
                        break;
                    }
                    break;
            }
            return num;
        }

        public int GetRolePerformance(ERole requestedRole)
        {
            int preferredposition1 = this.m_preferredposition1;
            return this.GetAverageRoleAttribute() * Player.c_RolesMap[preferredposition1, (int)requestedRole] / 100;
        }

        public ERole ChooseRole(ERole[] availableRoles, int nRoles)
        {
            ERole erole = ERole.Tribune;
            int num = -1;
            for (int index = 0; index < nRoles; ++index)
            {
                int rolePerformance = this.GetRolePerformance(availableRoles[index]);
                if (rolePerformance > num)
                {
                    erole = availableRoles[index];
                    num = rolePerformance;
                }
            }
            return this.m_preferredposition1 == 0 && erole != ERole.Goalkeeper || this.m_preferredposition1 != 0 && erole == ERole.Goalkeeper ? ERole.Tribune : erole;
        }

        public string GetRoleAcronym()
        {
            return FifaEnvironment.Language != null ? FifaEnvironment.Language.GetRoleShortString(this.m_preferredposition1) : string.Empty;
        }

        public string GetRoleString()
        {
            return FifaEnvironment.Language != null ? FifaEnvironment.Language.GetRoleLongString(this.m_preferredposition1) : string.Empty;
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
            if (this.m_FaceTextureBitmaps == null || headModel == null)
                return false;
            Model3D model3D1 = new Model3D(headModel.Rx3IndexArrays[0], headModel.Rx3VertexArrays[0], this.m_FaceTextureBitmaps[0]);
            if (this.m_EyesTextureBitmap == null || headModel == null)
                return false;
            Model3D model3D2 = new Model3D(headModel.Rx3IndexArrays[0], headModel.Rx3VertexArrays[0], this.m_EyesTextureBitmap);
            Rx3File hairModel = this.GetHairModel();
            if (this.m_FaceTextureBitmaps == null || hairModel == null)
                return false;
            Model3D model3D3 = new Model3D(hairModel.Rx3IndexArrays[0], hairModel.Rx3VertexArrays[0], this.m_HairColorTextureBitmap);
            return true;
        }

        public void ChangeSkills(int delta)
        {
            this.m_acceleration = this.ChangeSkill(this.m_acceleration, delta);
            this.m_aggression = this.ChangeSkill(this.m_aggression, delta);
            this.m_agility = this.ChangeSkill(this.m_agility, delta);
            this.m_balance = this.ChangeSkill(this.m_balance, delta);
            this.m_ballcontrol = this.ChangeSkill(this.m_ballcontrol, delta);
            this.m_crossing = this.ChangeSkill(this.m_crossing, delta);
            this.m_curve = this.ChangeSkill(this.m_curve, delta);
            this.m_dribbling = this.ChangeSkill(this.m_dribbling, delta);
            this.m_finishing = this.ChangeSkill(this.m_finishing, delta);
            this.m_freekickaccuracy = this.ChangeSkill(this.m_freekickaccuracy, delta);
            this.m_gkdiving = this.ChangeSkill(this.m_gkdiving, delta);
            this.m_gkhandling = this.ChangeSkill(this.m_gkhandling, delta);
            this.m_gkkicking = this.ChangeSkill(this.m_gkkicking, delta);
            this.m_gkpositioning = this.ChangeSkill(this.m_gkpositioning, delta);
            this.m_gkreflexes = this.ChangeSkill(this.m_gkreflexes, delta);
            this.m_interceptions = this.ChangeSkill(this.m_interceptions, delta);
            this.m_jumping = this.ChangeSkill(this.m_jumping, delta);
            this.m_longpassing = this.ChangeSkill(this.m_longpassing, delta);
            this.m_longshots = this.ChangeSkill(this.m_longshots, delta);
            this.m_marking = this.ChangeSkill(this.m_marking, delta);
            this.m_overallrating = this.ChangeSkill(this.m_overallrating, delta);
            this.m_penalties = this.ChangeSkill(this.m_penalties, delta);
            this.m_positioning = this.ChangeSkill(this.m_positioning, delta);
            this.m_potential = this.ChangeSkill(this.m_potential, delta);
            this.m_reactions = this.ChangeSkill(this.m_reactions, delta);
            this.m_shortpassing = this.ChangeSkill(this.m_shortpassing, delta);
            this.m_shotpower = this.ChangeSkill(this.m_shotpower, delta);
            this.m_sprintspeed = this.ChangeSkill(this.m_sprintspeed, delta);
            this.m_stamina = this.ChangeSkill(this.m_stamina, delta);
            this.m_standingtackle = this.ChangeSkill(this.m_standingtackle, delta);
            this.m_strength = this.ChangeSkill(this.m_strength, delta);
            this.m_vision = this.ChangeSkill(this.m_vision, delta);
            this.m_volleys = this.ChangeSkill(this.m_volleys, delta);
        }

        private int ChangeSkill(int skillValue, int delta)
        {
            if (skillValue + delta < 10)
                return 10;
            return skillValue + delta > 99 ? 99 : skillValue + delta;
        }

        public void UpdatePlayername(Table dcplayernamesTable, Table originalPlayernamesTable)
        {
            this.firstname = this.firstnameid < 29000 ? this.GetPlayerName(originalPlayernamesTable, this.firstnameid) : this.GetDcPlayername(dcplayernamesTable, this.firstnameid);
            this.lastname = this.lastnameid < 29000 ? this.GetPlayerName(originalPlayernamesTable, this.lastnameid) : this.GetDcPlayername(dcplayernamesTable, this.lastnameid);
            this.commonname = this.commonnameid < 29000 ? this.GetPlayerName(originalPlayernamesTable, this.commonnameid) : this.GetDcPlayername(dcplayernamesTable, this.commonnameid);
            if (this.playerjerseynameid >= 29000)
                this.playerjerseyname = this.GetDcPlayername(dcplayernamesTable, this.playerjerseynameid);
            else
                this.playerjerseyname = this.GetPlayerName(originalPlayernamesTable, this.playerjerseynameid);
        }

        private string GetDcPlayername(Table dcplayernamesTable, int nameId)
        {
            if (nameId >= 29000)
            {
                for (int index = 0; index < dcplayernamesTable.NValidRecords; ++index)
                {
                    Record record = dcplayernamesTable.Records[index];
                    if (nameId == record.IntField[FI.dcplayernames_nameid])
                        return record.StringField[FI.dcplayernames_name];
                }
            }
            return string.Empty;
        }

        private string GetPlayerName(Table playernamesTable, int nameId)
        {
            if (nameId < 29000)
            {
                for (int index = 0; index < playernamesTable.NValidRecords; ++index)
                {
                    Record record = playernamesTable.Records[index];
                    if (nameId == record.IntField[FI.playernames_nameid])
                        return record.CompressedString[FI.playernames_name];
                }
            }
            return string.Empty;
        }

        public void ConvertFaceTexturesFrom14To15()
        {
            if (this.m_headclasscode == 1)
                return;
            this.GetFaceTextures();
            if (this.m_FaceTextureBitmaps[0].Width == 1024 && this.m_FaceTextureBitmaps[0].Height == 1024 && this.m_FaceTextureBitmaps.Length == 2)
                return;
            this.SetFaceTextures(new Bitmap[2]
            {
        this.m_FaceTextureBitmaps[0].Width != 1024 || this.m_FaceTextureBitmaps[0].Height != 1024 ? GraphicUtil.ResizeBitmap(this.m_FaceTextureBitmaps[0], 1024, 1024, InterpolationMode.HighQualityBicubic) : (Bitmap) this.m_FaceTextureBitmaps[0].Clone(),
        this.m_FaceTextureBitmaps.Length == 2 ? (Bitmap) this.m_FaceTextureBitmaps[1].Clone() : new Bitmap(1024, 1024, PixelFormat.Format32bppArgb)
            });
        }

        public void ConvertFaceTexturesFrom15To14()
        {
            if (this.m_headclasscode == 1)
                return;
            if (this.GetEyesTexture() == null)
                this.SetEyesTextures(FifaEnvironment.GetBmpFromRx3(this.GenericEyesTextureFileName(), 0));
            this.GetFaceTextures();
            if (this.m_FaceTextureBitmaps[0].Width == 512 && this.m_FaceTextureBitmaps[0].Height == 512)
                return;
            this.SetFaceTextures(new Bitmap[1]
            {
        GraphicUtil.ResizeBitmap(this.m_FaceTextureBitmaps[0], 512, 512, InterpolationMode.HighQualityBicubic)
            });
        }
    }
}
