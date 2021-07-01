// Original code created by Rinaldo

using System.Drawing;

namespace FifaLibrary
{
  public class PlayingRole : IdObject
  {
    private static int[] c_DefaultInstrucion = new int[30]
    {
      0,
      16,
      8,
      8,
      16,
      16,
      16,
      8,
      8,
      320,
      320,
      320,
      2394112,
      134220032,
      134220032,
      134220032,
      2394112,
      134252544,
      134252544,
      134252544,
      294920,
      294920,
      294920,
      2394112,
      294920,
      294920,
      294920,
      2394112,
      0,
      0
    };
    public static int[] c_InstrucionNumber = new int[30]
    {
      0,
      1,
      1,
      1,
      1,
      1,
      1,
      1,
      1,
      2,
      2,
      2,
      4,
      3,
      3,
      3,
      4,
      3,
      3,
      3,
      3,
      3,
      3,
      4,
      3,
      3,
      3,
      4,
      0,
      0
    };
    public static int[,] c_InstrucionSetSelection = new int[30, 5]
    {
      {
        -1,
        -1,
        -1,
        -1,
        -1
      },
      {
        2,
        -1,
        -1,
        -1,
        -1
      },
      {
        0,
        -1,
        -1,
        -1,
        -1
      },
      {
        1,
        -1,
        -1,
        -1,
        -1
      },
      {
        2,
        -1,
        -1,
        -1,
        -1
      },
      {
        2,
        -1,
        -1,
        -1,
        -1
      },
      {
        2,
        -1,
        -1,
        -1,
        -1
      },
      {
        1,
        -1,
        -1,
        -1,
        -1
      },
      {
        0,
        -1,
        -1,
        -1,
        -1
      },
      {
        4,
        3,
        -1,
        -1,
        -1
      },
      {
        4,
        3,
        -1,
        -1,
        -1
      },
      {
        4,
        3,
        -1,
        -1,
        -1
      },
      {
        6,
        5,
        7,
        8,
        9
      },
      {
        3,
        5,
        9,
        -1,
        -1
      },
      {
        3,
        5,
        9,
        -1,
        -1
      },
      {
        3,
        5,
        9,
        -1,
        -1
      },
      {
        6,
        5,
        7,
        8,
        9
      },
      {
        6,
        5,
        9,
        -1,
        -1
      },
      {
        6,
        5,
        9,
        -1,
        -1
      },
      {
        6,
        5,
        9,
        -1,
        -1
      },
      {
        12,
        10,
        11,
        -1,
        -1
      },
      {
        12,
        10,
        11,
        -1,
        -1
      },
      {
        12,
        10,
        11,
        -1,
        -1
      },
      {
        6,
        5,
        7,
        8,
        -1
      },
      {
        12,
        10,
        11,
        -1,
        -1
      },
      {
        12,
        10,
        11,
        -1,
        -1
      },
      {
        12,
        10,
        11,
        -1,
        -1
      },
      {
        6,
        5,
        7,
        8,
        -1
      },
      {
        -1,
        -1,
        -1,
        -1,
        -1
      },
      {
        -1,
        -1,
        -1,
        -1,
        -1
      }
    };
    public static int[][] c_InstrucionSet = new int[13][]
    {
      new int[2]{ 2, 3 },
      new int[3]{ 2, 3, 4 },
      new int[3]{ 0, 1, 4 },
      new int[3]{ 4, 8, 9 },
      new int[3]{ 5, 6, 7 },
      new int[3]{ 10, 11, 12 },
      new int[3]{ 14, 15, 16 },
      new int[3]{ 17, 18, 19 },
      new int[3]{ 20, 21, 22 },
      new int[2]{ 13, 27 },
      new int[3]{ 18, 24, 25 },
      new int[3]{ 3, 20, 26 },
      new int[3]{ 5, 15, 23 }
    };
    public static string[] c_InstructionDescription = new string[28]
    {
      "Occasionally make forward runs when the opportunity arises",
      "Go up front in the last few minutes of a match if losing",
      "Make forward runs as much as possible",
      "Occasionally make forward runs when the opportunity arises",
      "Never make forward runs while on attack",
      "Split the opposition and cut out the passing lanes",
      "Keep your shape and stay in position to defend",
      "Mark up tight and stick with your opponent",
      "Occasionally make forward runs when the opportunity arises",
      "Join the attack and make runs beyond the striker(s)",
      "Make runs into the penalty area in crossing situations",
      "Run into the penalty area or stay on the edge in crossing situations",
      "Stay on the edge of the penalty area in crossing situations",
      "Take a free role and roam the attacking third",
      "Always try to track back and support the defence",
      "Come back to support the defence when needed",
      "Do not come back to support the defence",
      "Make cutting runs to the inside from out wide",
      "Stay wide or cut inside depending on the situation",
      "Always try to stay wide and close to the line",
      "Make forward runs in behind the defence",
      "Make forward runs or come short depending on the situation",
      "Come short and ask for the ball to feet",
      "Apply pressure on the back line",
      "Make runs to wide areas of the pitch",
      "Stay in central areas of the pitch",
      "Back into an opponent and ask for the ball to feet",
      "Stay in your formation position when attacking"
    };
    public static string[] c_InstructionCaption = new string[28]
    {
      "Join The Attack",
      "Play As Striker",
      "Always Overlap",
      "Balanced Attack",
      "Stay Back While Attacking",
      "Cut Passing Lanes",
      "Balanced Defense",
      "Man Mark",
      "Balanced Attack",
      "Get Forward",
      "Get Into The Box For Cross",
      "Balanced Crossing Runs",
      "Stay On Edge Of Box For Cross",
      "Free Roam",
      "Come Back On Defence",
      "Basic Defence Support",
      "Stay Forward",
      "Cut Inside",
      "Balanced Width",
      "Stay Wide",
      "Get In Behind",
      "Balanced Support",
      "Come Short",
      "Press Back Line",
      "Drift Wide",
      "Stay Central",
      "Target Man",
      "Stick To Position"
    };
    private int m_RoleId;
    private Role m_Role;
    public int m_OffsetX;
    public int m_OffsetY;
    private EPlayingDirection m_OffDirection;
    private EPlayingIntensity m_OffIntensity;
    private EPlayingDirection m_DefDirection;
    private EPlayingIntensity m_DefIntensity;
    private int m_PlayerInstruction;

    public Role Role
    {
      get
      {
        return this.m_Role;
      }
      set
      {
        this.m_Role = value;
        this.Id = this.m_Role.Id;
      }
    }

    public static int GetDefaultInstruction(int roleid)
    {
      return roleid >= 0 && roleid < PlayingRole.c_DefaultInstrucion.Length ? PlayingRole.c_DefaultInstrucion[roleid] : 0;
    }

    public int OffsetX
    {
      get
      {
        return this.m_OffsetX;
      }
      set
      {
        this.m_OffsetX = value;
      }
    }

    public int OffsetY
    {
      get
      {
        return this.m_OffsetY;
      }
      set
      {
        this.m_OffsetY = value;
      }
    }

    public EPlayingDirection OffDirection0
    {
      get
      {
        return this.m_OffDirection;
      }
      set
      {
        this.m_OffDirection = value;
      }
    }

    public EPlayingIntensity OffIntensity
    {
      get
      {
        return this.m_OffIntensity;
      }
      set
      {
        this.m_OffIntensity = value;
      }
    }

    public EPlayingDirection DefDirection0
    {
      get
      {
        return this.m_DefDirection;
      }
      set
      {
        this.m_DefDirection = value;
      }
    }

    public EPlayingIntensity DefIntensity
    {
      get
      {
        return this.m_DefIntensity;
      }
      set
      {
        this.m_DefIntensity = value;
      }
    }

    public int PlayerInstruction
    {
      get
      {
        return this.m_PlayerInstruction;
      }
      set
      {
        this.m_PlayerInstruction = value;
      }
    }

    public PlayingRole(Record r, int roleOrder, int fieldIndex)
      : base(r.GetAndCheckIntField(fieldIndex))
    {
      this.Load(r, roleOrder);
    }

    public PlayingRole(Role role)
      : base(role.Id)
    {
      Point center = role.GetCenter();
      this.m_Role = role;
      this.m_OffsetX = center.X;
      this.m_OffsetY = center.Y;
      this.m_OffDirection = EPlayingDirection.Standing;
      this.m_OffIntensity = EPlayingIntensity.Normal;
      this.m_DefDirection = EPlayingDirection.Standing;
      this.m_DefIntensity = EPlayingIntensity.Normal;
      this.m_PlayerInstruction = PlayingRole.c_DefaultInstrucion[(int) role.RoleId];
    }

    public bool ReInitialize(PlayingRole playingRole)
    {
      if (playingRole == null)
        return false;
      this.m_Role = playingRole.Role;
      this.m_RoleId = playingRole.m_RoleId;
      this.m_OffsetX = playingRole.m_OffsetX;
      this.m_OffsetY = playingRole.m_OffsetY;
      this.m_OffDirection = playingRole.m_OffDirection;
      this.m_OffIntensity = playingRole.m_OffIntensity;
      this.m_DefDirection = playingRole.m_DefDirection;
      this.m_DefIntensity = playingRole.m_DefIntensity;
      this.m_PlayerInstruction = playingRole.m_PlayerInstruction;
      return true;
    }

    public override string ToString()
    {
      return this.Role.ToString();
    }

    public void LinkRole(RoleList roleList)
    {
      this.m_Role = (Role) roleList.SearchId(this.m_RoleId);
    }

    public void Load(Record r, int i)
    {
      this.Id = i;
      switch (i)
      {
        case 0:
          this.m_RoleId = r.GetAndCheckIntField(FI.formations_position0);
          this.m_OffsetX = (int) ((double) r.FloatField[FI.formations_offset0x] * 100.0);
          this.m_OffsetY = (int) ((double) r.FloatField[FI.formations_offset0y] * 100.0);
          this.m_OffDirection = (EPlayingDirection) r.GetAndCheckIntField(FI.formations_attackingdirection_0);
          this.m_OffIntensity = (EPlayingIntensity) r.GetAndCheckIntField(FI.formations_attackingrole_0);
          this.m_DefDirection = (EPlayingDirection) r.GetAndCheckIntField(FI.formations_defensivedirection_0);
          this.m_DefIntensity = (EPlayingIntensity) r.GetAndCheckIntField(FI.formations_defensiverole_0);
          if (FI.formations_playerinstruction0 >= 0)
          {
            this.m_PlayerInstruction = r.GetAndCheckIntField(FI.formations_playerinstruction0);
            break;
          }
          break;
        case 1:
          this.m_RoleId = r.GetAndCheckIntField(FI.formations_position1);
          this.m_OffsetX = (int) ((double) r.FloatField[FI.formations_offset1x] * 100.0);
          this.m_OffsetY = (int) ((double) r.FloatField[FI.formations_offset1y] * 100.0);
          this.m_OffDirection = (EPlayingDirection) r.GetAndCheckIntField(FI.formations_attackingdirection_1);
          this.m_OffIntensity = (EPlayingIntensity) r.GetAndCheckIntField(FI.formations_attackingrole_1);
          this.m_DefDirection = (EPlayingDirection) r.GetAndCheckIntField(FI.formations_defensivedirection_1);
          this.m_DefIntensity = (EPlayingIntensity) r.GetAndCheckIntField(FI.formations_defensiverole_1);
          if (FI.formations_playerinstruction1 >= 0)
          {
            this.m_PlayerInstruction = r.GetAndCheckIntField(FI.formations_playerinstruction1);
            break;
          }
          break;
        case 2:
          this.m_RoleId = r.GetAndCheckIntField(FI.formations_position2);
          this.m_OffsetX = (int) ((double) r.FloatField[FI.formations_offset2x] * 100.0);
          this.m_OffsetY = (int) ((double) r.FloatField[FI.formations_offset2y] * 100.0);
          this.m_OffDirection = (EPlayingDirection) r.GetAndCheckIntField(FI.formations_attackingdirection_2);
          this.m_OffIntensity = (EPlayingIntensity) r.GetAndCheckIntField(FI.formations_attackingrole_2);
          this.m_DefDirection = (EPlayingDirection) r.GetAndCheckIntField(FI.formations_defensivedirection_2);
          this.m_DefIntensity = (EPlayingIntensity) r.GetAndCheckIntField(FI.formations_defensiverole_2);
          if (FI.formations_playerinstruction2 >= 0)
          {
            this.m_PlayerInstruction = r.GetAndCheckIntField(FI.formations_playerinstruction2);
            break;
          }
          break;
        case 3:
          this.m_RoleId = r.GetAndCheckIntField(FI.formations_position3);
          this.m_OffsetX = (int) ((double) r.FloatField[FI.formations_offset3x] * 100.0);
          this.m_OffsetY = (int) ((double) r.FloatField[FI.formations_offset3y] * 100.0);
          this.m_OffDirection = (EPlayingDirection) r.GetAndCheckIntField(FI.formations_attackingdirection_3);
          this.m_OffIntensity = (EPlayingIntensity) r.GetAndCheckIntField(FI.formations_attackingrole_3);
          this.m_DefDirection = (EPlayingDirection) r.GetAndCheckIntField(FI.formations_defensivedirection_3);
          this.m_DefIntensity = (EPlayingIntensity) r.GetAndCheckIntField(FI.formations_defensiverole_3);
          if (FI.formations_playerinstruction3 >= 0)
          {
            this.m_PlayerInstruction = r.GetAndCheckIntField(FI.formations_playerinstruction3);
            break;
          }
          break;
        case 4:
          this.m_RoleId = r.GetAndCheckIntField(FI.formations_position4);
          this.m_OffsetX = (int) ((double) r.FloatField[FI.formations_offset4x] * 100.0);
          this.m_OffsetY = (int) ((double) r.FloatField[FI.formations_offset4y] * 100.0);
          this.m_OffDirection = (EPlayingDirection) r.GetAndCheckIntField(FI.formations_attackingdirection_4);
          this.m_OffIntensity = (EPlayingIntensity) r.GetAndCheckIntField(FI.formations_attackingrole_4);
          this.m_DefDirection = (EPlayingDirection) r.GetAndCheckIntField(FI.formations_defensivedirection_4);
          this.m_DefIntensity = (EPlayingIntensity) r.GetAndCheckIntField(FI.formations_defensiverole_4);
          if (FI.formations_playerinstruction4 >= 0)
          {
            this.m_PlayerInstruction = r.GetAndCheckIntField(FI.formations_playerinstruction4);
            break;
          }
          break;
        case 5:
          this.m_RoleId = r.GetAndCheckIntField(FI.formations_position5);
          this.m_OffsetX = (int) ((double) r.FloatField[FI.formations_offset5x] * 100.0);
          this.m_OffsetY = (int) ((double) r.FloatField[FI.formations_offset5y] * 100.0);
          this.m_OffDirection = (EPlayingDirection) r.GetAndCheckIntField(FI.formations_attackingdirection_5);
          this.m_OffIntensity = (EPlayingIntensity) r.GetAndCheckIntField(FI.formations_attackingrole_5);
          this.m_DefDirection = (EPlayingDirection) r.GetAndCheckIntField(FI.formations_defensivedirection_5);
          this.m_DefIntensity = (EPlayingIntensity) r.GetAndCheckIntField(FI.formations_defensiverole_5);
          if (FI.formations_playerinstruction5 >= 0)
          {
            this.m_PlayerInstruction = r.GetAndCheckIntField(FI.formations_playerinstruction5);
            break;
          }
          break;
        case 6:
          this.m_RoleId = r.GetAndCheckIntField(FI.formations_position6);
          this.m_OffsetX = (int) ((double) r.FloatField[FI.formations_offset6x] * 100.0);
          this.m_OffsetY = (int) ((double) r.FloatField[FI.formations_offset6y] * 100.0);
          this.m_OffDirection = (EPlayingDirection) r.GetAndCheckIntField(FI.formations_attackingdirection_6);
          this.m_OffIntensity = (EPlayingIntensity) r.GetAndCheckIntField(FI.formations_attackingrole_6);
          this.m_DefDirection = (EPlayingDirection) r.GetAndCheckIntField(FI.formations_defensivedirection_6);
          this.m_DefIntensity = (EPlayingIntensity) r.GetAndCheckIntField(FI.formations_defensiverole_6);
          if (FI.formations_playerinstruction6 >= 0)
          {
            this.m_PlayerInstruction = r.GetAndCheckIntField(FI.formations_playerinstruction6);
            break;
          }
          break;
        case 7:
          this.m_RoleId = r.GetAndCheckIntField(FI.formations_position7);
          this.m_OffsetX = (int) ((double) r.FloatField[FI.formations_offset7x] * 100.0);
          this.m_OffsetY = (int) ((double) r.FloatField[FI.formations_offset7y] * 100.0);
          this.m_OffDirection = (EPlayingDirection) r.GetAndCheckIntField(FI.formations_attackingdirection_7);
          this.m_OffIntensity = (EPlayingIntensity) r.GetAndCheckIntField(FI.formations_attackingrole_7);
          this.m_DefDirection = (EPlayingDirection) r.GetAndCheckIntField(FI.formations_defensivedirection_7);
          this.m_DefIntensity = (EPlayingIntensity) r.GetAndCheckIntField(FI.formations_defensiverole_7);
          if (FI.formations_playerinstruction7 >= 0)
          {
            this.m_PlayerInstruction = r.GetAndCheckIntField(FI.formations_playerinstruction7);
            break;
          }
          break;
        case 8:
          this.m_RoleId = r.GetAndCheckIntField(FI.formations_position8);
          this.m_OffsetX = (int) ((double) r.FloatField[FI.formations_offset8x] * 100.0);
          this.m_OffsetY = (int) ((double) r.FloatField[FI.formations_offset8y] * 100.0);
          this.m_OffDirection = (EPlayingDirection) r.GetAndCheckIntField(FI.formations_attackingdirection_8);
          this.m_OffIntensity = (EPlayingIntensity) r.GetAndCheckIntField(FI.formations_attackingrole_8);
          this.m_DefDirection = (EPlayingDirection) r.GetAndCheckIntField(FI.formations_defensivedirection_8);
          this.m_DefIntensity = (EPlayingIntensity) r.GetAndCheckIntField(FI.formations_defensiverole_8);
          if (FI.formations_playerinstruction8 >= 0)
          {
            this.m_PlayerInstruction = r.GetAndCheckIntField(FI.formations_playerinstruction8);
            break;
          }
          break;
        case 9:
          this.m_RoleId = r.GetAndCheckIntField(FI.formations_position9);
          this.m_OffsetX = (int) ((double) r.FloatField[FI.formations_offset9x] * 100.0);
          this.m_OffsetY = (int) ((double) r.FloatField[FI.formations_offset9y] * 100.0);
          this.m_OffDirection = (EPlayingDirection) r.GetAndCheckIntField(FI.formations_attackingdirection_9);
          this.m_OffIntensity = (EPlayingIntensity) r.GetAndCheckIntField(FI.formations_attackingrole_9);
          this.m_DefDirection = (EPlayingDirection) r.GetAndCheckIntField(FI.formations_defensivedirection_9);
          this.m_DefIntensity = (EPlayingIntensity) r.GetAndCheckIntField(FI.formations_defensiverole_9);
          if (FI.formations_playerinstruction9 >= 0)
          {
            this.m_PlayerInstruction = r.GetAndCheckIntField(FI.formations_playerinstruction9);
            break;
          }
          break;
        case 10:
          this.m_RoleId = r.GetAndCheckIntField(FI.formations_position10);
          this.m_OffsetX = (int) ((double) r.FloatField[FI.formations_offset10x] * 100.0);
          this.m_OffsetY = (int) ((double) r.FloatField[FI.formations_offset10y] * 100.0);
          this.m_OffDirection = (EPlayingDirection) r.GetAndCheckIntField(FI.formations_attackingdirection_10);
          this.m_OffIntensity = (EPlayingIntensity) r.GetAndCheckIntField(FI.formations_attackingrole_10);
          this.m_DefDirection = (EPlayingDirection) r.GetAndCheckIntField(FI.formations_defensivedirection_10);
          this.m_DefIntensity = (EPlayingIntensity) r.GetAndCheckIntField(FI.formations_defensiverole_10);
          if (FI.formations_playerinstruction10 >= 0)
          {
            this.m_PlayerInstruction = r.GetAndCheckIntField(FI.formations_playerinstruction10);
            break;
          }
          break;
      }
      this.LinkRole(FifaEnvironment.Roles);
    }

    public void Save(Record r, int i)
    {
      switch (i)
      {
        case 0:
          r.IntField[FI.formations_position0] = this.m_Role.Id;
          r.FloatField[FI.formations_offset0x] = (float) this.m_OffsetX / 100f;
          r.FloatField[FI.formations_offset0y] = (float) this.m_OffsetY / 100f;
          r.IntField[FI.formations_attackingdirection_0] = (int) this.m_OffDirection;
          r.IntField[FI.formations_defensivedirection_0] = (int) this.m_DefDirection;
          r.IntField[FI.formations_attackingrole_0] = (int) this.m_OffIntensity;
          r.IntField[FI.formations_defensiverole_0] = (int) this.m_DefIntensity;
          if (FI.formations_playerinstruction0 < 0)
            break;
          r.IntField[FI.formations_playerinstruction0] = this.m_PlayerInstruction;
          break;
        case 1:
          r.IntField[FI.formations_position1] = this.m_Role.Id;
          r.FloatField[FI.formations_offset1x] = (float) this.m_OffsetX / 100f;
          r.FloatField[FI.formations_offset1y] = (float) this.m_OffsetY / 100f;
          r.IntField[FI.formations_attackingdirection_1] = (int) this.m_OffDirection;
          r.IntField[FI.formations_defensivedirection_1] = (int) this.m_DefDirection;
          r.IntField[FI.formations_attackingrole_1] = (int) this.m_OffIntensity;
          r.IntField[FI.formations_defensiverole_1] = (int) this.m_DefIntensity;
          if (FI.formations_playerinstruction1 < 0)
            break;
          r.IntField[FI.formations_playerinstruction1] = this.m_PlayerInstruction;
          break;
        case 2:
          r.IntField[FI.formations_position2] = this.m_Role.Id;
          r.FloatField[FI.formations_offset2x] = (float) this.m_OffsetX / 100f;
          r.FloatField[FI.formations_offset2y] = (float) this.m_OffsetY / 100f;
          r.IntField[FI.formations_attackingdirection_2] = (int) this.m_OffDirection;
          r.IntField[FI.formations_defensivedirection_2] = (int) this.m_DefDirection;
          r.IntField[FI.formations_attackingrole_2] = (int) this.m_OffIntensity;
          r.IntField[FI.formations_defensiverole_2] = (int) this.m_DefIntensity;
          if (FI.formations_playerinstruction2 < 0)
            break;
          r.IntField[FI.formations_playerinstruction2] = this.m_PlayerInstruction;
          break;
        case 3:
          r.IntField[FI.formations_position3] = this.m_Role.Id;
          r.FloatField[FI.formations_offset3x] = (float) this.m_OffsetX / 100f;
          r.FloatField[FI.formations_offset3y] = (float) this.m_OffsetY / 100f;
          r.IntField[FI.formations_attackingdirection_3] = (int) this.m_OffDirection;
          r.IntField[FI.formations_defensivedirection_3] = (int) this.m_DefDirection;
          r.IntField[FI.formations_attackingrole_3] = (int) this.m_OffIntensity;
          r.IntField[FI.formations_defensiverole_3] = (int) this.m_DefIntensity;
          if (FI.formations_playerinstruction3 < 0)
            break;
          r.IntField[FI.formations_playerinstruction3] = this.m_PlayerInstruction;
          break;
        case 4:
          r.IntField[FI.formations_position4] = this.m_Role.Id;
          r.FloatField[FI.formations_offset4x] = (float) this.m_OffsetX / 100f;
          r.FloatField[FI.formations_offset4y] = (float) this.m_OffsetY / 100f;
          r.IntField[FI.formations_attackingdirection_4] = (int) this.m_OffDirection;
          r.IntField[FI.formations_defensivedirection_4] = (int) this.m_DefDirection;
          r.IntField[FI.formations_attackingrole_4] = (int) this.m_OffIntensity;
          r.IntField[FI.formations_defensiverole_4] = (int) this.m_DefIntensity;
          if (FI.formations_playerinstruction4 < 0)
            break;
          r.IntField[FI.formations_playerinstruction4] = this.m_PlayerInstruction;
          break;
        case 5:
          r.IntField[FI.formations_position5] = this.m_Role.Id;
          r.FloatField[FI.formations_offset5x] = (float) this.m_OffsetX / 100f;
          r.FloatField[FI.formations_offset5y] = (float) this.m_OffsetY / 100f;
          r.IntField[FI.formations_attackingdirection_5] = (int) this.m_OffDirection;
          r.IntField[FI.formations_defensivedirection_5] = (int) this.m_DefDirection;
          r.IntField[FI.formations_attackingrole_5] = (int) this.m_OffIntensity;
          r.IntField[FI.formations_defensiverole_5] = (int) this.m_DefIntensity;
          if (FI.formations_playerinstruction5 < 0)
            break;
          r.IntField[FI.formations_playerinstruction5] = this.m_PlayerInstruction;
          break;
        case 6:
          r.IntField[FI.formations_position6] = this.m_Role.Id;
          r.FloatField[FI.formations_offset6x] = (float) this.m_OffsetX / 100f;
          r.FloatField[FI.formations_offset6y] = (float) this.m_OffsetY / 100f;
          r.IntField[FI.formations_attackingdirection_6] = (int) this.m_OffDirection;
          r.IntField[FI.formations_defensivedirection_6] = (int) this.m_DefDirection;
          r.IntField[FI.formations_attackingrole_6] = (int) this.m_OffIntensity;
          r.IntField[FI.formations_defensiverole_6] = (int) this.m_DefIntensity;
          if (FI.formations_playerinstruction6 < 0)
            break;
          r.IntField[FI.formations_playerinstruction6] = this.m_PlayerInstruction;
          break;
        case 7:
          r.IntField[FI.formations_position7] = this.m_Role.Id;
          r.FloatField[FI.formations_offset7x] = (float) this.m_OffsetX / 100f;
          r.FloatField[FI.formations_offset7y] = (float) this.m_OffsetY / 100f;
          r.IntField[FI.formations_attackingdirection_7] = (int) this.m_OffDirection;
          r.IntField[FI.formations_defensivedirection_7] = (int) this.m_DefDirection;
          r.IntField[FI.formations_attackingrole_7] = (int) this.m_OffIntensity;
          r.IntField[FI.formations_defensiverole_7] = (int) this.m_DefIntensity;
          if (FI.formations_playerinstruction7 < 0)
            break;
          r.IntField[FI.formations_playerinstruction7] = this.m_PlayerInstruction;
          break;
        case 8:
          r.IntField[FI.formations_position8] = this.m_Role.Id;
          r.FloatField[FI.formations_offset8x] = (float) this.m_OffsetX / 100f;
          r.FloatField[FI.formations_offset8y] = (float) this.m_OffsetY / 100f;
          r.IntField[FI.formations_attackingdirection_8] = (int) this.m_OffDirection;
          r.IntField[FI.formations_defensivedirection_8] = (int) this.m_DefDirection;
          r.IntField[FI.formations_attackingrole_8] = (int) this.m_OffIntensity;
          r.IntField[FI.formations_defensiverole_8] = (int) this.m_DefIntensity;
          if (FI.formations_playerinstruction8 < 0)
            break;
          r.IntField[FI.formations_playerinstruction8] = this.m_PlayerInstruction;
          break;
        case 9:
          r.IntField[FI.formations_position9] = this.m_Role.Id;
          r.FloatField[FI.formations_offset9x] = (float) this.m_OffsetX / 100f;
          r.FloatField[FI.formations_offset9y] = (float) this.m_OffsetY / 100f;
          r.IntField[FI.formations_attackingdirection_9] = (int) this.m_OffDirection;
          r.IntField[FI.formations_defensivedirection_9] = (int) this.m_DefDirection;
          r.IntField[FI.formations_attackingrole_9] = (int) this.m_OffIntensity;
          r.IntField[FI.formations_defensiverole_9] = (int) this.m_DefIntensity;
          if (FI.formations_playerinstruction0 < 9)
            break;
          r.IntField[FI.formations_playerinstruction9] = this.m_PlayerInstruction;
          break;
        case 10:
          r.IntField[FI.formations_position10] = this.m_Role.Id;
          r.FloatField[FI.formations_offset10x] = (float) this.m_OffsetX / 100f;
          r.FloatField[FI.formations_offset10y] = (float) this.m_OffsetY / 100f;
          r.IntField[FI.formations_attackingdirection_10] = (int) this.m_OffDirection;
          r.IntField[FI.formations_defensivedirection_10] = (int) this.m_DefDirection;
          r.IntField[FI.formations_attackingrole_10] = (int) this.m_OffIntensity;
          r.IntField[FI.formations_defensiverole_10] = (int) this.m_DefIntensity;
          if (FI.formations_playerinstruction0 < 10)
            break;
          r.IntField[FI.formations_playerinstruction10] = this.m_PlayerInstruction;
          break;
      }
    }
  }
}
