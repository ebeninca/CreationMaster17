// Original code created by Rinaldo

using System;
using System.Data;
using System.Globalization;
using System.IO;

namespace FifaLibrary
{
  public class Record
  {
    private int[] m_CompressedStringOffset;
    private int[] m_CompressedStringFieldIndex;
    private string[] m_CompressedString;
    private static int m_HuffmannTreeSize;
    private int[] m_KeyField;
    private float[] m_FloatField;
    private int[] m_PtrToStringField;
    private int[] m_IntField;
    private TableDescriptor m_TableDescriptor;
    private string[] m_StringField;

    public int[] CompressedStringOffset
    {
      get
      {
        return this.m_CompressedStringOffset;
      }
      set
      {
        this.m_CompressedStringOffset = value;
      }
    }

    public int[] CompressedStringFieldIndex
    {
      get
      {
        return this.m_CompressedStringFieldIndex;
      }
      set
      {
        this.m_CompressedStringFieldIndex = value;
      }
    }

    public string[] CompressedString
    {
      get
      {
        return this.m_CompressedString;
      }
      set
      {
        this.m_CompressedString = value;
      }
    }

    public static int HuffmannTreeSize
    {
      get
      {
        return Record.m_HuffmannTreeSize;
      }
      set
      {
        Record.m_HuffmannTreeSize = value;
      }
    }

    public int GetIntField(string fieldName)
    {
      for (int index = 0; index < this.TableDescriptor.NFields; ++index)
      {
        if (this.TableDescriptor.FieldDescriptors[index].FieldName == fieldName)
          return this.m_IntField[this.TableDescriptor.FieldDescriptors[index].TypeIndex];
      }
      return 0;
    }

    public bool SetField(string fieldName, int value)
    {
      for (int index = 0; index < this.TableDescriptor.NFields; ++index)
      {
        if (this.TableDescriptor.FieldDescriptors[index].FieldName == fieldName)
        {
          this.m_IntField[this.TableDescriptor.FieldDescriptors[index].TypeIndex] = value;
          return true;
        }
      }
      return false;
    }

    public float GetFloatField(string fieldName)
    {
      for (int index = 0; index < this.TableDescriptor.NFields; ++index)
      {
        if (this.TableDescriptor.FieldDescriptors[index].FieldName == fieldName)
          return this.m_FloatField[this.TableDescriptor.FieldDescriptors[index].TypeIndex];
      }
      return float.NaN;
    }

    public bool SetField(string fieldName, float value)
    {
      for (int index = 0; index < this.TableDescriptor.NFields; ++index)
      {
        if (this.TableDescriptor.FieldDescriptors[index].FieldName == fieldName)
        {
          this.m_FloatField[this.TableDescriptor.FieldDescriptors[index].TypeIndex] = value;
          return true;
        }
      }
      return false;
    }

    public string GetStringField(string fieldName)
    {
      for (int index = 0; index < this.TableDescriptor.NFields; ++index)
      {
        if (this.TableDescriptor.FieldDescriptors[index].FieldName == fieldName)
          return this.TableDescriptor.FieldDescriptors[index].FieldType == FieldDescriptor.EFieldTypes.String ? this.m_StringField[this.TableDescriptor.FieldDescriptors[index].TypeIndex] : this.m_CompressedString[this.TableDescriptor.FieldDescriptors[index].TypeIndex];
      }
      return string.Empty;
    }

    public bool SetField(string fieldName, string value)
    {
      for (int index = 0; index < this.TableDescriptor.NFields; ++index)
      {
        if (this.TableDescriptor.FieldDescriptors[index].FieldName == fieldName)
        {
          if (this.TableDescriptor.FieldDescriptors[index].FieldType == FieldDescriptor.EFieldTypes.String)
            this.m_StringField[this.TableDescriptor.FieldDescriptors[index].TypeIndex] = value;
          else
            this.m_CompressedString[this.TableDescriptor.FieldDescriptors[index].TypeIndex] = value;
          return true;
        }
      }
      return false;
    }

    public int[] KeyField
    {
      get
      {
        return this.m_KeyField;
      }
      set
      {
        this.m_KeyField = value;
      }
    }

    public float[] FloatField
    {
      get
      {
        return this.m_FloatField;
      }
      set
      {
        this.m_FloatField = value;
      }
    }

    public int[] PtrToStringField
    {
      get
      {
        return this.m_PtrToStringField;
      }
      set
      {
        this.m_PtrToStringField = value;
      }
    }

    public int[] IntField
    {
      get
      {
        return this.m_IntField;
      }
      set
      {
        this.m_IntField = value;
      }
    }

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

    public string[] StringField
    {
      get
      {
        return this.m_StringField;
      }
      set
      {
        this.m_StringField = value;
      }
    }

    public Record(TableDescriptor tableDescriptor)
    {
      this.m_TableDescriptor = tableDescriptor;
      if (this.m_TableDescriptor.NKeyFields > 0)
        this.m_KeyField = new int[this.m_TableDescriptor.NKeyFields];
      if (this.m_TableDescriptor.NFloatFields > 0)
        this.m_FloatField = new float[this.m_TableDescriptor.NFloatFields];
      if (this.m_TableDescriptor.NStringFields > 0)
      {
        this.m_PtrToStringField = new int[this.m_TableDescriptor.NStringFields];
        this.m_StringField = new string[this.m_TableDescriptor.NStringFields];
      }
      if (this.m_TableDescriptor.NCompressedStringFields > 0)
      {
        this.m_CompressedStringOffset = new int[this.m_TableDescriptor.NCompressedStringFields];
        this.m_CompressedString = new string[this.m_TableDescriptor.NCompressedStringFields];
        this.m_CompressedStringFieldIndex = new int[this.m_TableDescriptor.NCompressedStringFields];
      }
      if (this.m_TableDescriptor.NIntFields <= 0)
        return;
      this.m_IntField = new int[this.m_TableDescriptor.NIntFields];
    }

    public void LoadKeyFields(DbReader r)
    {
      if (this.m_TableDescriptor.NKeyFields <= 0)
        return;
      for (int index = 0; index < this.m_TableDescriptor.NKeyFields; ++index)
        this.m_KeyField[index] = r.ReadInt32();
    }

    public void LoadFloatFields(DbReader r)
    {
      if (this.m_TableDescriptor.NFloatFields <= 0)
        return;
      for (int index = 0; index < this.m_TableDescriptor.NFloatFields; ++index)
        this.m_FloatField[index] = r.ReadSingle();
    }

    public void LoadStringFields(DbReader r)
    {
      if (this.m_TableDescriptor.NStringFields <= 0)
        return;
      for (int index = 0; index < this.m_TableDescriptor.NStringFields; ++index)
      {
        this.m_PtrToStringField[index] = r.ReadInt32();
        this.m_StringField[index] = FifaUtil.ReadString((BinaryReader) r, this.m_PtrToStringField[index]);
      }
    }

    public bool LoadIntFields(DbReader r)
    {
      int num1 = 0;
      byte num2 = 0;
      bool flag = true;
      int num3 = 0;
      for (int index1 = 0; index1 < this.m_TableDescriptor.NIntFields; ++index1)
      {
        int bitUsed = FifaUtil.ComputeBitUsed((uint) (this.m_TableDescriptor.MaxValues[index1] - this.m_TableDescriptor.MinValues[index1]));
        if (bitUsed == 32)
        {
          this.m_IntField[index1] = r.ReadInt32();
        }
        else
        {
          int num4 = 0;
          for (uint index2 = 0; (long) index2 < (long) bitUsed; ++index2)
          {
            if (num1 == 0)
            {
              num2 = r.ReadByte();
              num1 = 8;
              ++num3;
            }
            num4 *= 2;
            if (((int) num2 & 1 << num1 - 1) != 0)
              ++num4;
            --num1;
          }
          this.m_IntField[index1] = num4 + this.m_TableDescriptor.MinValues[index1];
          int num5 = this.m_IntField[index1] <= this.m_TableDescriptor.MaxValues[index1] ? 1 : 0;
        }
      }
      return flag;
    }

    public bool LoadCompressedStrings(DbReader r)
    {
      long position = r.BaseStream.Position;
      for (int index1 = 0; index1 < this.m_TableDescriptor.NCompressedStringFields; ++index1)
      {
        int index2 = this.m_CompressedStringFieldIndex[index1];
        short num = 0;
        if (this.m_CompressedStringOffset[index1] != -1)
        {
          r.BaseStream.Position = position + (long) this.m_CompressedStringOffset[index1];
          switch (this.m_TableDescriptor.FieldDescriptors[index2].FieldType)
          {
            case FieldDescriptor.EFieldTypes.ShortCompressedString:
              num = (short) r.ReadByte();
              break;
            case FieldDescriptor.EFieldTypes.LongCompressedString:
              num = FifaUtil.SwapEndian(r.ReadInt16());
              break;
          }
        }
        this.m_CompressedString[index1] = this.m_TableDescriptor.HuffmannTree.ReadString(r, (int) num);
      }
      return true;
    }

    public bool Load(DbReader r)
    {
      long position = r.BaseStream.Position;
      int recordSize = this.m_TableDescriptor.RecordSize;
      for (int index = 0; index < this.m_TableDescriptor.NFields; ++index)
      {
        int num1 = this.m_TableDescriptor.FieldDescriptors[index].BitOffset / 8;
        int typeIndex = this.m_TableDescriptor.FieldDescriptors[index].TypeIndex;
        switch (this.m_TableDescriptor.FieldDescriptors[index].FieldType)
        {
          case FieldDescriptor.EFieldTypes.String:
            r.Align(position + (long) num1);
            int length = this.m_TableDescriptor.FieldDescriptors[index].Depth / 8;
            this.m_StringField[typeIndex] = FifaUtil.ReadNullPaddedString((BinaryReader) r, length);
            break;
          case FieldDescriptor.EFieldTypes.Integer:
            this.m_IntField[typeIndex] = r.PopInteger(this.m_TableDescriptor.FieldDescriptors[index]);
            break;
          case FieldDescriptor.EFieldTypes.Float:
            r.Align(position + (long) num1);
            this.m_FloatField[typeIndex] = r.ReadSingle();
            break;
          case FieldDescriptor.EFieldTypes.ShortCompressedString:
          case FieldDescriptor.EFieldTypes.LongCompressedString:
            r.Align(position + (long) num1);
            int num2 = this.m_TableDescriptor.FieldDescriptors[index].Depth / 8;
            int num3 = r.ReadInt32();
            this.m_CompressedStringOffset[typeIndex] = num3;
            this.m_CompressedStringFieldIndex[typeIndex] = index;
            if (num3 != -1 && num3 < Record.m_HuffmannTreeSize)
              Record.m_HuffmannTreeSize = num3;
            if (index < this.m_TableDescriptor.NFields - 1 && this.m_TableDescriptor.FieldDescriptors[index + 1].BitOffset != 32)
            {
              r.Align(position + (long) (this.m_TableDescriptor.FieldDescriptors[index + 1].BitOffset / 8));
              break;
            }
            break;
        }
      }
      r.Align(position + (long) recordSize);
      return true;
    }

    public void Fill(DbWriter w)
    {
      for (int index = 0; index < this.m_TableDescriptor.RecordSize; ++index)
        w.Write((byte) 205);
    }

    public int Save(DbWriter w, long compressedStringBasePosition, int compressedStringOffset)
    {
      long position1 = w.BaseStream.Position;
      long position2 = position1 + (long) this.m_TableDescriptor.RecordSize;
      int recordSize = this.m_TableDescriptor.RecordSize;
      for (int index = 0; index < this.m_TableDescriptor.NFields; ++index)
      {
        int num = this.m_TableDescriptor.FieldDescriptors[index].BitOffset / 8;
        int typeIndex = this.m_TableDescriptor.FieldDescriptors[index].TypeIndex;
        switch (this.m_TableDescriptor.FieldDescriptors[index].FieldType)
        {
          case FieldDescriptor.EFieldTypes.String:
            w.WritePendingByte();
            w.BaseStream.Position = position1 + (long) num;
            int length = this.m_TableDescriptor.FieldDescriptors[index].Depth / 8;
            FifaUtil.WriteNullPaddedString((BinaryWriter) w, this.m_StringField[typeIndex], length);
            break;
          case FieldDescriptor.EFieldTypes.Integer:
            w.PushInteger(this.m_IntField[typeIndex], this.m_TableDescriptor.FieldDescriptors[index]);
            break;
          case FieldDescriptor.EFieldTypes.Float:
            w.WritePendingByte();
            w.BaseStream.Position = position1 + (long) num;
            w.Write(this.m_FloatField[typeIndex]);
            break;
          case FieldDescriptor.EFieldTypes.ShortCompressedString:
            w.WritePendingByte();
            w.BaseStream.Position = position1 + (long) num;
            if (this.m_CompressedString[typeIndex] == string.Empty)
              w.Write(-1);
            else
              w.Write(compressedStringOffset);
            w.BaseStream.Position = compressedStringBasePosition + (long) compressedStringOffset;
            compressedStringOffset += this.m_TableDescriptor.HuffmannTree.WriteString((BinaryWriter) w, this.m_CompressedString[typeIndex], false);
            w.BaseStream.Position = position1 + (long) num + 4L;
            break;
          case FieldDescriptor.EFieldTypes.LongCompressedString:
            w.WritePendingByte();
            w.BaseStream.Position = position1 + (long) num;
            if (this.m_CompressedString[typeIndex] == string.Empty)
              w.Write(-1);
            else
              w.Write(compressedStringOffset);
            w.BaseStream.Position = compressedStringBasePosition + (long) compressedStringOffset;
            compressedStringOffset += this.m_TableDescriptor.HuffmannTree.WriteString((BinaryWriter) w, this.m_CompressedString[typeIndex], true);
            w.BaseStream.Position = position1 + (long) num + 4L;
            break;
        }
      }
      w.WritePendingByte();
      w.Align(position2);
      return compressedStringOffset;
    }

    public void SaveKeyFields(BinaryWriter w)
    {
      if (this.m_TableDescriptor.NKeyFields <= 0)
        return;
      for (int index = 0; index < this.m_TableDescriptor.NKeyFields; ++index)
        w.Write(this.m_KeyField[index]);
    }

    public void SaveFloatFields(BinaryWriter w)
    {
      if (this.m_TableDescriptor.NFloatFields <= 0)
        return;
      for (int index = 0; index < this.m_TableDescriptor.NFloatFields; ++index)
        w.Write(this.m_FloatField[index]);
    }

    public void SaveIntFields(BinaryWriter w)
    {
      if (this.m_TableDescriptor.NIntFields <= 0)
        return;
      int num1 = 8;
      byte num2 = 0;
      for (int index1 = 0; index1 < this.m_TableDescriptor.NIntFields; ++index1)
      {
        int bitUsed = FifaUtil.ComputeBitUsed((uint) (this.m_TableDescriptor.MaxValues[index1] - this.m_TableDescriptor.MinValues[index1]));
        if (bitUsed == 32)
        {
          w.Write(this.m_IntField[index1]);
        }
        else
        {
          int num3 = this.m_IntField[index1] - this.m_TableDescriptor.MinValues[index1];
          for (int index2 = bitUsed - 1; index2 >= 0; --index2)
          {
            num2 *= (byte) 2;
            if ((num3 & 1 << index2) != 0)
              ++num2;
            --num1;
            if (num1 == 0)
            {
              w.Write(num2);
              num1 = 8;
              num2 = (byte) 0;
            }
          }
        }
      }
      if (num1 == 8)
        return;
      byte num4 = (byte) ((uint) num2 << num1);
      w.Write(num4);
    }

    public object[] ConvertToDataRow()
    {
      object[] objArray = new object[this.m_TableDescriptor.NFields];
      for (int index = 0; index < this.m_TableDescriptor.NFields; ++index)
      {
        int typeIndex = this.m_TableDescriptor.FieldDescriptors[index].TypeIndex;
        switch (this.m_TableDescriptor.FieldDescriptors[index].FieldType)
        {
          case FieldDescriptor.EFieldTypes.String:
            objArray[index] = (object) this.m_StringField[typeIndex];
            break;
          case FieldDescriptor.EFieldTypes.Integer:
            objArray[index] = (object) this.m_IntField[typeIndex];
            break;
          case FieldDescriptor.EFieldTypes.Float:
            objArray[index] = (object) this.m_FloatField[typeIndex];
            break;
          case FieldDescriptor.EFieldTypes.ShortCompressedString:
          case FieldDescriptor.EFieldTypes.LongCompressedString:
            objArray[index] = (object) this.m_CompressedString[typeIndex];
            break;
        }
      }
      return objArray;
    }

    public void ConvertFromDataRow(DataRow dataRow)
    {
label_12:
      for (int index1 = 0; index1 < dataRow.Table.Columns.Count; ++index1)
      {
        string columnName = dataRow.Table.Columns[index1].ColumnName;
        for (int index2 = 0; index2 < this.m_TableDescriptor.FieldDescriptors.Length; ++index2)
        {
          if (this.m_TableDescriptor.FieldDescriptors[index2].FieldName == columnName)
          {
            int typeIndex = this.m_TableDescriptor.FieldDescriptors[index2].TypeIndex;
            switch (this.m_TableDescriptor.FieldDescriptors[index2].FieldType)
            {
              case FieldDescriptor.EFieldTypes.String:
                this.m_StringField[typeIndex] = Convert.ToString(dataRow.ItemArray[index1]);
                goto label_12;
              case FieldDescriptor.EFieldTypes.Integer:
                int int32 = Convert.ToInt32(dataRow.ItemArray[index1]);
                this.m_IntField[typeIndex] = int32;
                goto label_12;
              case FieldDescriptor.EFieldTypes.Float:
                this.m_FloatField[typeIndex] = Convert.ToSingle(dataRow.ItemArray[index1], (IFormatProvider) NumberFormatInfo.InvariantInfo);
                goto label_12;
              case FieldDescriptor.EFieldTypes.ShortCompressedString:
              case FieldDescriptor.EFieldTypes.LongCompressedString:
                this.m_CompressedString[typeIndex] = Convert.ToString(dataRow.ItemArray[index1]);
                goto label_12;
              default:
                goto label_12;
            }
          }
        }
      }
    }

    public bool IsEmptyDataRow(DataRow dataRow)
    {
      int nkeyFields = this.m_TableDescriptor.NKeyFields;
      int nstringFields = this.m_TableDescriptor.NStringFields;
      int nfloatFields = this.m_TableDescriptor.NFloatFields;
      int nintFields = this.m_TableDescriptor.NIntFields;
      int num = nkeyFields + nstringFields + nfloatFields + nintFields;
      int index1 = 0;
      for (int index2 = 0; index2 < nkeyFields; ++index2)
      {
        this.m_KeyField[index2] = Convert.ToInt32(dataRow.ItemArray[index1++]);
        if (this.m_KeyField[index2] != 0)
          return false;
      }
      for (int index2 = 0; index2 < nfloatFields; ++index2)
      {
        this.m_FloatField[index2] = (float) Convert.ToDouble(dataRow.ItemArray[index1++]);
        if ((double) this.m_FloatField[index2] != 0.0)
          return false;
      }
      for (int index2 = 0; index2 < nstringFields; ++index2)
      {
        if (dataRow.ItemArray[index1] == DBNull.Value)
        {
          this.m_StringField[index2] = string.Empty;
          ++index1;
        }
        else
          this.m_StringField[index2] = (string) dataRow.ItemArray[index1++];
        if (!string.IsNullOrEmpty(this.m_StringField[index2]))
          return false;
      }
      for (int index2 = 0; index2 < nintFields; ++index2)
      {
        if (index1 < dataRow.ItemArray.Length)
        {
          this.m_IntField[index2] = Convert.ToInt32(dataRow.ItemArray[index1++]);
          if (this.m_IntField[index2] != 0)
            return false;
        }
      }
      return true;
    }

    public int GetAndCheckIntField(int index)
    {
      if (index < 0 || index >= this.m_IntField.Length)
        return 0;
      int num = this.m_IntField[index];
      if (this.m_TableDescriptor.MinValues[index] > this.m_TableDescriptor.MaxValues[index])
        return num;
      if (num < this.m_TableDescriptor.MinValues[index])
        return this.m_TableDescriptor.MinValues[index];
      return num > this.m_TableDescriptor.MaxValues[index] ? this.m_TableDescriptor.MaxValues[index] : num;
    }

    public string GetAndCheckStringField(int index)
    {
      return index < 0 || index >= this.m_StringField.Length ? (string) null : this.m_StringField[index];
    }

    public int GetAndCheckExtendedIntField(int index)
    {
      if (index < 0 || index >= this.m_IntField.Length)
        return 0;
      int num1 = this.m_IntField[index];
      if (this.m_TableDescriptor.MinValues[index] > this.m_TableDescriptor.MaxValues[index])
        return num1;
      int minValue = this.m_TableDescriptor.MinValues[index];
      int num2 = this.m_TableDescriptor.MaxValues[index];
      uint range = (uint) (num2 - minValue);
      if (range != 0U)
      {
        int bitUsed = FifaUtil.ComputeBitUsed(range);
        num2 = minValue + (1 << bitUsed) - 1;
      }
      if (num1 < minValue)
        return minValue;
      return num1 > num2 ? num2 : num1;
    }
  }
}
