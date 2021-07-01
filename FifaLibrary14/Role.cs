// Original code created by Rinaldo

using System;
using System.Drawing;

namespace FifaLibrary
{
  public class Role : IdObject
  {
    private int m_Xmin;
    private int m_Xmax;
    private int m_Ymin;
    private int m_Ymax;

    public ERole RoleId
    {
      get
      {
        return (ERole) this.Id;
      }
      set
      {
        this.Id = (int) value;
      }
    }

    public int Xmin
    {
      get
      {
        return this.m_Xmin;
      }
      set
      {
        this.m_Xmin = value;
      }
    }

    public int Xmax
    {
      get
      {
        return this.m_Xmax;
      }
      set
      {
        this.m_Xmax = value;
      }
    }

    public int Ymin
    {
      get
      {
        return this.m_Ymin;
      }
      set
      {
        this.m_Ymin = value;
      }
    }

    public int Ymax
    {
      get
      {
        return this.m_Ymax;
      }
      set
      {
        this.m_Ymax = value;
      }
    }

    public Role(ERole eRole)
      : base((int) eRole)
    {
    }

    public Role(int roleId)
      : base(roleId)
    {
    }

    public override string ToString()
    {
      string str = string.Empty;
      if (FifaEnvironment.Language != null)
        str = FifaEnvironment.Language.GetRoleShortString(this.Id) + " - ";
      switch (this.RoleId)
      {
        case ERole.Goalkeeper:
          return str + "Goalkeeper";
        case ERole.Sweeper:
          return str + "Sweeper";
        case ERole.Right_Wing_Back:
          return str + "Right Wing Back";
        case ERole.Right_Back:
          return str + "Right Back";
        case ERole.Right_Central_Back:
          return str + "Right Central Back";
        case ERole.Central_Back:
          return str + "Central Back";
        case ERole.Left_Central_Back:
          return str + "Left Central Back";
        case ERole.Left_Back:
          return str + "Left Back";
        case ERole.Left_Wing_Back:
          return str + "Left Wing Back";
        case ERole.Right_Defensive_Midfielder:
          return str + "Right Defensive Midfielder";
        case ERole.Central_Defensive_Midfielder:
          return str + "Central Defensive Midfielder";
        case ERole.Left_Defensive_Midfielder:
          return str + "Left Defensive Midfielder";
        case ERole.Right_Midfielder:
          return str + "Right Midfielder";
        case ERole.Right_Central_Midfielder:
          return str + "Right Central Midfielder";
        case ERole.Central_Midfielder:
          return str + "Central Midfielder";
        case ERole.Left_Central_Midfielder:
          return str + "Left Central Midfielder";
        case ERole.Left_Midfielder:
          return str + "Left Midfielder";
        case ERole.Right_Advanced_Midfielder:
          return str + "Right Advanced Midfielder";
        case ERole.Central_Advanced_Midfielder:
          return str + "Central Advanced Midfielder";
        case ERole.Left_Advanced_Midfielder:
          return str + "Left Advanced Midfielder";
        case ERole.Right_Forward:
          return str + "Right Forward";
        case ERole.Central_Forward:
          return str + "Central Forward";
        case ERole.Left_Forward:
          return str + "Left Forward";
        case ERole.Right_Wing:
          return str + "Right Wing";
        case ERole.Right_Striker:
          return str + "Right Striker";
        case ERole.Central_Striker:
          return str + "Central Striker";
        case ERole.Left_Striker:
          return str + "Left Striker";
        case ERole.Left_Wing:
          return str + "Left Wing";
        case ERole.Substitute:
          return str + "Substitute";
        case ERole.Tribune:
          return str + "Tribune";
        default:
          return string.Empty;
      }
    }

    public string ToShortString()
    {
      return FifaEnvironment.Language != null ? FifaEnvironment.Language.GetRoleShortString(this.Id) : string.Empty;
    }

    public string ToLongString()
    {
      return FifaEnvironment.Language != null ? FifaEnvironment.Language.GetRoleLongString(this.Id) : string.Empty;
    }

    public void SetShortString(string shortName)
    {
      if (FifaEnvironment.Language == null)
        return;
      FifaEnvironment.Language.SetRoleShortString(this.Id, shortName);
    }

    public Role(Record r)
      : base(r.IntField[FI.fieldpositionboundingboxes_positionid])
    {
      this.Load(r);
    }

    public void Load(Record r)
    {
      float val1_1 = r.FloatField[FI.fieldpositionboundingboxes_pointx0];
      float val2_1 = r.FloatField[FI.fieldpositionboundingboxes_pointx1];
      float val1_2 = r.FloatField[FI.fieldpositionboundingboxes_pointx2];
      float val2_2 = r.FloatField[FI.fieldpositionboundingboxes_pointx3];
      float val1_3 = r.FloatField[FI.fieldpositionboundingboxes_pointy0];
      float val2_3 = r.FloatField[FI.fieldpositionboundingboxes_pointy1];
      float val1_4 = r.FloatField[FI.fieldpositionboundingboxes_pointy2];
      float val2_4 = r.FloatField[FI.fieldpositionboundingboxes_pointy3];
      this.m_Xmin = Convert.ToInt32(Math.Min(Math.Min(val1_1, val2_1), Math.Min(val1_2, val2_2)) * 100f);
      this.m_Xmax = Convert.ToInt32(Math.Max(Math.Max(val1_1, val2_1), Math.Max(val1_2, val2_2)) * 100f);
      this.m_Ymin = Convert.ToInt32(Math.Min(Math.Min(val1_3, val2_3), Math.Min(val1_4, val2_4)) * 100f);
      this.m_Ymax = Convert.ToInt32(Math.Max(Math.Max(val1_3, val2_3), Math.Max(val1_4, val2_4)) * 100f);
    }

    public void Save(Record r)
    {
      r.IntField[FI.fieldpositionboundingboxes_positionid] = this.Id;
      r.FloatField[FI.fieldpositionboundingboxes_pointx0] = (float) this.m_Xmin / 100f;
      r.FloatField[FI.fieldpositionboundingboxes_pointy0] = (float) this.m_Ymin / 100f;
      r.FloatField[FI.fieldpositionboundingboxes_pointx1] = (float) this.m_Xmin / 100f;
      r.FloatField[FI.fieldpositionboundingboxes_pointy1] = (float) this.m_Ymax / 100f;
      r.FloatField[FI.fieldpositionboundingboxes_pointx2] = (float) this.m_Xmax / 100f;
      r.FloatField[FI.fieldpositionboundingboxes_pointy2] = (float) this.m_Ymax / 100f;
      r.FloatField[FI.fieldpositionboundingboxes_pointx3] = (float) this.m_Xmax / 100f;
      r.FloatField[FI.fieldpositionboundingboxes_pointy3] = (float) this.m_Ymin / 100f;
    }

    public Point GetCenter()
    {
      return new Point((this.m_Xmax + this.m_Xmin) / 2, (this.m_Ymax + this.m_Ymin) / 2);
    }
  }
}
