// Original code created by Rinaldo

using System;
using System.Collections;
using System.Data;
using System.IO;

namespace FifaLibrary
{
  public class TableDescriptor
  {
    private static FieldComparer s_FieldComparer = new FieldComparer();
    private char[] m_ShortName;
    private uint m_NBitRecords;
    private int m_NFields;
    private FieldDescriptor[] m_FieldDescriptors;
    private HuffmannTree m_HuffmannTree;
    private static DataSet s_DescriptorDataSet;
    private string m_TableName;
    private string m_TableShortName;
    private int m_RecordSize;
    private int m_NKeyFields;
    private int[] m_KeyIndex;
    private int m_NFloatFields;
    private int m_NStringFields;
    private int m_NCompressedStringFields;
    private int m_NIntFields;
    private int[] m_MinValues;
    private int[] m_MaxValues;

    public char[] ShortName
    {
      get
      {
        return this.m_ShortName;
      }
      set
      {
        this.m_ShortName = value;
      }
    }

    public uint NBitRecords
    {
      get
      {
        return this.m_NBitRecords;
      }
      set
      {
        this.m_NBitRecords = value;
      }
    }

    public int NFields
    {
      get
      {
        return this.m_NFields;
      }
      set
      {
        this.m_NFields = value;
      }
    }

    public FieldDescriptor[] FieldDescriptors
    {
      get
      {
        return this.m_FieldDescriptors;
      }
      set
      {
        this.m_FieldDescriptors = value;
      }
    }

    public HuffmannTree HuffmannTree
    {
      get
      {
        return this.m_HuffmannTree;
      }
      set
      {
        this.m_HuffmannTree = value;
      }
    }

    public static DataSet DescriptorDataSet
    {
      get
      {
        return TableDescriptor.s_DescriptorDataSet;
      }
      set
      {
        TableDescriptor.s_DescriptorDataSet = value;
      }
    }

    public string TableName
    {
      get
      {
        return this.m_TableName;
      }
      set
      {
        this.m_TableName = value;
      }
    }

    public string TableShortName
    {
      get
      {
        return this.m_TableShortName;
      }
      set
      {
        this.m_TableShortName = value;
      }
    }

    public int RecordSize
    {
      get
      {
        return this.m_RecordSize;
      }
      set
      {
        this.m_RecordSize = value;
      }
    }

    public int NKeyFields
    {
      get
      {
        return this.m_NKeyFields;
      }
      set
      {
        this.m_NKeyFields = value;
      }
    }

    public int[] KeyIndex
    {
      get
      {
        return this.m_KeyIndex;
      }
      set
      {
        this.m_KeyIndex = value;
      }
    }

    public int NFloatFields
    {
      get
      {
        return this.m_NFloatFields;
      }
    }

    public int NStringFields
    {
      get
      {
        return this.m_NStringFields;
      }
    }

    public int NCompressedStringFields
    {
      get
      {
        return this.m_NCompressedStringFields;
      }
    }

    public int NIntFields
    {
      get
      {
        return this.m_NIntFields;
      }
    }

    public int[] MinValues
    {
      get
      {
        return this.m_MinValues;
      }
    }

    public int[] MaxValues
    {
      get
      {
        return this.m_MaxValues;
      }
    }

    public void SortFields()
    {
      if (this.m_FieldDescriptors == null || this.m_FieldDescriptors.Length < 2)
        return;
      Array.Sort((Array) this.m_FieldDescriptors, (IComparer) TableDescriptor.s_FieldComparer);
    }

    public void LoadTableName(DbReader r)
    {
      this.m_ShortName = r.ReadChars(4);
      this.m_TableShortName = new string(this.m_ShortName);
      this.AssignXmlTableName();
    }

    public void LoadFieldDescriptors(DbReader r)
    {
      this.m_FieldDescriptors = new FieldDescriptor[this.m_NFields];
      this.m_NKeyFields = 0;
      this.m_NFloatFields = 0;
      this.m_NIntFields = 0;
      this.m_NStringFields = 0;
      this.m_NCompressedStringFields = 0;
      this.m_MinValues = new int[this.m_NFields];
      this.m_MaxValues = new int[this.m_NFields];
      this.m_KeyIndex = new int[4];
      for (int index = 0; index < this.m_NFields; ++index)
      {
        this.m_FieldDescriptors[index] = new FieldDescriptor(this);
        this.m_FieldDescriptors[index].Load(r);
        this.m_FieldDescriptors[index].OrderInTheTable = index;
        this.m_FieldDescriptors[index].AssignXmlDescriptor(TableDescriptor.s_DescriptorDataSet);
        switch (this.m_FieldDescriptors[index].FieldType)
        {
          case FieldDescriptor.EFieldTypes.String:
            this.m_FieldDescriptors[index].TypeIndex = this.m_NStringFields;
            ++this.m_NStringFields;
            break;
          case FieldDescriptor.EFieldTypes.Integer:
            this.m_FieldDescriptors[index].TypeIndex = this.m_NIntFields;
            this.m_MinValues[this.m_NIntFields] = this.m_FieldDescriptors[index].RangeLow;
            this.m_MaxValues[this.m_NIntFields] = this.m_FieldDescriptors[index].RangeHigh;
            ++this.m_NIntFields;
            break;
          case FieldDescriptor.EFieldTypes.Float:
            this.m_FieldDescriptors[index].TypeIndex = this.m_NFloatFields;
            ++this.m_NFloatFields;
            break;
          case FieldDescriptor.EFieldTypes.ShortCompressedString:
          case FieldDescriptor.EFieldTypes.LongCompressedString:
            this.m_FieldDescriptors[index].TypeIndex = this.m_NCompressedStringFields;
            ++this.m_NCompressedStringFields;
            break;
        }
      }
      this.AssignXmlTableIndex();
    }

    public void SaveFieldDescriptors(BinaryWriter w)
    {
      for (int index1 = 0; index1 < this.m_NFields; ++index1)
      {
        for (int index2 = 0; index2 < this.m_NFields; ++index2)
        {
          if (this.m_FieldDescriptors[index2].OrderInTheTable == index1)
          {
            this.m_FieldDescriptors[index2].Save(w);
            break;
          }
        }
      }
    }

    private void AssignXmlTableName()
    {
      if (TableDescriptor.s_DescriptorDataSet == null)
        return;
      int count = TableDescriptor.s_DescriptorDataSet.Tables["table"].Rows.Count;
      for (int index = 0; index < count; ++index)
      {
        DataRow row = TableDescriptor.s_DescriptorDataSet.Tables["table"].Rows[index];
        if ((string) row["shortname"] == this.m_TableShortName)
        {
          this.m_TableName = (string) row["name"];
          break;
        }
      }
    }

    private void AssignXmlTableIndex()
    {
      if (TableDescriptor.s_DescriptorDataSet == null)
        return;
      int count1 = TableDescriptor.s_DescriptorDataSet.Tables["index"].Rows.Count;
      int count2 = TableDescriptor.s_DescriptorDataSet.Tables["indexfield"].Rows.Count;
      for (int index1 = 0; index1 < count1; ++index1)
      {
        DataRow row1 = TableDescriptor.s_DescriptorDataSet.Tables["index"].Rows[index1];
        if ((string) row1["tableshortname"] == this.m_TableShortName)
        {
          int num1 = (int) row1.ItemArray[0];
          for (int index2 = 0; index2 < count2; ++index2)
          {
            DataRow row2 = TableDescriptor.s_DescriptorDataSet.Tables["indexfield"].Rows[index2];
            if ((int) row2[2] == num1)
            {
              string str = (string) row2[0];
              int num2 = 0;
              for (int index3 = 0; index3 < this.m_NFields; ++index3)
              {
                if (this.m_FieldDescriptors[index3].FieldShortName == str)
                {
                  this.m_KeyIndex[this.m_NKeyFields++] = num2;
                  break;
                }
                if (this.m_FieldDescriptors[index3].FieldType == FieldDescriptor.EFieldTypes.Integer)
                  ++num2;
              }
            }
          }
          break;
        }
      }
    }

    public FieldDescriptor GetFieldDescriptor(string longName)
    {
      for (int index = 0; index < this.m_NFields; ++index)
      {
        if (this.m_FieldDescriptors[index].FieldName == longName)
          return this.m_FieldDescriptors[index];
      }
      return (FieldDescriptor) null;
    }

    public int GetFieldIndex(string fieldName)
    {
      for (int index = 0; index < this.m_NFields; ++index)
      {
        if (fieldName == this.FieldDescriptors[index].FieldName)
          return this.FieldDescriptors[index].TypeIndex;
      }
      return -1;
    }

    public void RecalculateFieldOffset()
    {
      int[] numArray = new int[this.NFields];
      int index1 = 0;
      uint num1 = 0;
      do
      {
        uint num2 = this.m_NBitRecords;
        for (int index2 = 0; index2 < this.NFields; ++index2)
        {
          if ((long) this.FieldDescriptors[index2].BitOffset >= (long) num1 && (long) this.FieldDescriptors[index2].BitOffset < (long) num2)
          {
            numArray[index1] = index2;
            num2 = (uint) this.FieldDescriptors[index2].BitOffset;
          }
        }
        num1 = num2 + 1U;
        ++index1;
      }
      while (index1 < this.NFields);
      uint num3 = 0;
      for (int index2 = 0; index2 < this.NFields; ++index2)
      {
        switch (this.FieldDescriptors[numArray[index2]].FieldType)
        {
          case FieldDescriptor.EFieldTypes.String:
            if (num3 % 8U != 0U)
            {
              num3 = (uint) ((int) num3 + 7 & -8);
              break;
            }
            break;
          case FieldDescriptor.EFieldTypes.Float:
          case FieldDescriptor.EFieldTypes.ShortCompressedString:
          case FieldDescriptor.EFieldTypes.LongCompressedString:
            if (num3 % 32U != 0U)
            {
              num3 = (uint) ((int) num3 + 31 & -32);
              break;
            }
            break;
        }
        this.FieldDescriptors[numArray[index2]].BitOffset = (int) num3;
        switch (this.FieldDescriptors[numArray[index2]].FieldType)
        {
          case FieldDescriptor.EFieldTypes.String:
          case FieldDescriptor.EFieldTypes.Integer:
            num3 += (uint) this.FieldDescriptors[numArray[index2]].Depth;
            break;
          case FieldDescriptor.EFieldTypes.Float:
          case FieldDescriptor.EFieldTypes.ShortCompressedString:
          case FieldDescriptor.EFieldTypes.LongCompressedString:
            num3 += 32U;
            break;
        }
      }
      int num4 = (int) ((num3 + 7U) / 8U);
      if (num4 <= this.m_RecordSize)
        return;
      this.m_RecordSize = (num4 + 3) / 4 * 4;
      this.m_NBitRecords = (uint) (this.m_RecordSize * 8 - 1);
    }
  }
}
