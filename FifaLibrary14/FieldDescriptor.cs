// Original code created by Rinaldo

using System;
using System.Data;
using System.IO;

namespace FifaLibrary
{
  public class FieldDescriptor
  {
    private DataRow m_XmlDataRow;
    private TableDescriptor m_TableDescriptor;
    private FieldDescriptor.EFieldTypes m_FieldType;
    private int m_BitOffset;
    private byte[] m_ShortName;
    private int m_Depth;
    private int m_Mask;
    private string m_FieldShortName;
    private string m_FieldName;
    private int m_RangeLow;
    private int m_RangeHigh;
    private int m_TypeIndex;
    private int m_OrderInTheTable;

    public TableDescriptor TableDescriptor
    {
      get
      {
        return this.m_TableDescriptor;
      }
      set
      {
        this.m_TableDescriptor = value;
      }
    }

    public FieldDescriptor.EFieldTypes FieldType
    {
      get
      {
        return this.m_FieldType;
      }
      set
      {
        this.m_FieldType = value;
      }
    }

    public int BitOffset
    {
      get
      {
        return this.m_BitOffset;
      }
      set
      {
        this.m_BitOffset = value;
      }
    }

    public FieldDescriptor(TableDescriptor tableDescriptor)
    {
      this.m_TableDescriptor = tableDescriptor;
    }

    public int Depth
    {
      get
      {
        return this.m_Depth;
      }
      set
      {
        this.m_Depth = value;
        this.m_Mask = (int) ((1L << this.m_Depth) - 1L);
      }
    }

    public int Mask
    {
      get
      {
        return this.m_Mask;
      }
    }

    public string FieldShortName
    {
      get
      {
        return this.m_FieldShortName;
      }
      set
      {
        this.m_FieldShortName = value;
      }
    }

    public string FieldName
    {
      get
      {
        return this.m_FieldName;
      }
      set
      {
        this.m_FieldName = value;
      }
    }

    public int RangeLow
    {
      get
      {
        return this.m_RangeLow;
      }
      set
      {
        this.m_RangeLow = value;
      }
    }

    public int RangeHigh
    {
      get
      {
        return this.m_RangeHigh;
      }
    }

    public int TypeIndex
    {
      get
      {
        return this.m_TypeIndex;
      }
      set
      {
        this.m_TypeIndex = value;
      }
    }

    public int OrderInTheTable
    {
      get
      {
        return this.m_OrderInTheTable;
      }
      set
      {
        this.m_OrderInTheTable = value;
      }
    }

    public void Load(DbReader r)
    {
      this.m_FieldType = (FieldDescriptor.EFieldTypes) r.ReadInt32();
      this.m_BitOffset = r.ReadInt32();
      this.m_ShortName = r.ReadBytes(4);
      this.m_Depth = r.ReadInt32();
      this.m_FieldShortName = FifaUtil.ConvertBytesToString(this.m_ShortName);
      this.m_FieldName = this.m_FieldShortName;
    }

    public void Save(BinaryWriter w)
    {
      w.Write((int) this.m_FieldType);
      w.Write(this.m_BitOffset);
      w.Write(this.m_ShortName);
      w.Write(this.m_Depth);
    }

    public void AssignXmlDescriptor(DataSet descriptorDataSet)
    {
      if (descriptorDataSet == null)
        return;
      int count = descriptorDataSet.Tables["field"].Rows.Count;
      for (int index1 = 0; index1 < count; ++index1)
      {
        DataRow row = descriptorDataSet.Tables["field"].Rows[index1];
        if (this.m_FieldShortName == (string) row["shortname"])
        {
          int index2 = (int) row["fields_Id"];
          int index3 = (int) descriptorDataSet.Tables["fields"].Rows[index2]["table_Id"];
          if ((string) descriptorDataSet.Tables["table"].Rows[index3]["shortname"] == this.m_TableDescriptor.TableShortName)
          {
            this.m_FieldName = (string) row["name"];
            this.m_RangeLow = Convert.ToInt32((string) row["rangelow"]);
            this.m_RangeHigh = Convert.ToInt32((string) row["rangehigh"]);
            this.m_XmlDataRow = row;
            break;
          }
        }
      }
    }

    public bool Expand(int depth)
    {
      if (depth < this.m_Depth)
        return false;
      if (depth > this.m_Depth)
      {
        this.m_Depth = depth;
        this.m_XmlDataRow[nameof (depth)] = (object) this.m_Depth.ToString();
      }
      this.m_RangeHigh = this.m_RangeLow + (1 << this.m_Depth) - 1;
      this.m_XmlDataRow["rangehigh"] = (object) this.m_RangeHigh.ToString();
      return true;
    }

    public bool Expand(int depth, int minValue)
    {
      this.m_RangeLow = minValue;
      this.m_XmlDataRow["rangelow"] = (object) this.m_RangeLow.ToString();
      return this.Expand(depth);
    }

    public enum EFieldTypes
    {
      String = 0,
      Integer = 3,
      Float = 4,
      ShortCompressedString = 13, // 0x0000000D
      LongCompressedString = 14, // 0x0000000E
    }
  }
}
