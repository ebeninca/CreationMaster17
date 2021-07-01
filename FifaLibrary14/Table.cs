// Original code created by Rinaldo

using System;
using System.Collections;
using System.Data;
using System.IO;

namespace FifaLibrary
{
  public class Table
  {
    private static RecordComparer s_RecordComparer = new RecordComparer();
    private int m_Unknown00;
    private uint m_CompressedStringLength;
    private int m_Unknown14;
    private int m_Unknown1C;
    private uint m_CrcTableHeader;
    private long m_CrcTableHeaderPosition;
    private uint m_CrcRecords;
    private long m_CrcRecordsPosition;
    private int m_NRecords;
    private int m_NValidRecords;
    protected Record[] m_Records;
    private TableDescriptor m_TableDescriptor;

    public int Unknown00
    {
      get
      {
        return this.m_Unknown00;
      }
      set
      {
        this.m_Unknown00 = value;
      }
    }

    public uint CompressedStringLength
    {
      get
      {
        return this.m_CompressedStringLength;
      }
      set
      {
        this.m_CompressedStringLength = value;
      }
    }

    public int Unknown14
    {
      get
      {
        return this.m_Unknown14;
      }
      set
      {
        this.m_Unknown14 = value;
      }
    }

    public int Unknown1C
    {
      get
      {
        return this.m_Unknown1C;
      }
      set
      {
        this.m_Unknown1C = value;
      }
    }

    public uint CrcTableHeader
    {
      get
      {
        return this.m_CrcTableHeader;
      }
      set
      {
        this.m_CrcTableHeader = value;
      }
    }

    public long CrcTableHeaderPosition
    {
      get
      {
        return this.m_CrcTableHeaderPosition;
      }
      set
      {
        this.m_CrcTableHeaderPosition = value;
      }
    }

    public uint CrcRecords
    {
      get
      {
        return this.m_CrcRecords;
      }
      set
      {
        this.m_CrcRecords = value;
      }
    }

    public long CrcRecordsPosition
    {
      get
      {
        return this.m_CrcRecordsPosition;
      }
      set
      {
        this.m_CrcRecordsPosition = value;
      }
    }

    public int NRecords
    {
      get
      {
        return this.m_NRecords;
      }
      set
      {
        this.m_NRecords = value;
      }
    }

    public int NValidRecords
    {
      get
      {
        return this.m_NValidRecords;
      }
      set
      {
        this.m_NValidRecords = value;
      }
    }

    public Record[] Records
    {
      get
      {
        return this.m_Records;
      }
      set
      {
        this.m_Records = value;
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

    public Table()
    {
      this.m_TableDescriptor = new TableDescriptor();
    }

    public Table(TableDescriptor tableDescriptor)
    {
      this.m_TableDescriptor = tableDescriptor;
    }

    public void LoadTableName(DbReader r)
    {
      this.m_TableDescriptor.LoadTableName(r);
    }

    public bool Load(DbReader r, long offset)
    {
      bool flag1 = true;
      r.BaseStream.Position = offset;
      this.m_Unknown00 = r.ReadInt32();
      this.m_TableDescriptor.RecordSize = r.ReadInt32();
      this.m_TableDescriptor.NBitRecords = r.ReadUInt32();
      this.m_CompressedStringLength = r.ReadUInt32();
      this.m_NRecords = (int) r.ReadUInt16();
      this.m_NValidRecords = (int) r.ReadUInt16();
      this.m_Unknown14 = r.ReadInt32();
      this.m_TableDescriptor.NFields = (int) r.ReadByte();
      r.ReadBytes(3);
      this.m_Unknown1C = r.ReadInt32();
      this.m_CrcTableHeaderPosition = r.BaseStream.Position;
      this.m_CrcTableHeader = r.ReadUInt32();
      this.m_TableDescriptor.LoadFieldDescriptors(r);
      this.m_TableDescriptor.SortFields();
      if (this.m_NRecords > 0)
      {
        this.m_Records = new Record[this.m_NRecords];
        Record.HuffmannTreeSize = int.MaxValue;
        for (int index = 0; index < this.m_NRecords; ++index)
        {
          this.m_Records[index] = new Record(this.m_TableDescriptor);
          bool flag2 = this.m_Records[index].Load(r);
          flag1 = flag1 && flag2;
        }
        if (this.m_TableDescriptor.NCompressedStringFields > 0)
        {
          long position = r.BaseStream.Position;
          this.m_TableDescriptor.HuffmannTree = new HuffmannTree(Record.HuffmannTreeSize / 4);
          this.m_TableDescriptor.HuffmannTree.Load(r);
          for (int index = 0; index < this.m_NRecords; ++index)
          {
            r.BaseStream.Position = position;
            this.m_Records[index].LoadCompressedStrings(r);
          }
          r.BaseStream.Position = (long) this.m_CompressedStringLength + position;
        }
      }
      this.m_CrcRecordsPosition = r.BaseStream.Position;
      this.m_CrcRecords = r.ReadUInt32();
      return flag1;
    }

    public void Save(DbWriter w)
    {
      w.Write(this.m_Unknown00);
      w.Write(this.m_TableDescriptor.RecordSize);
      w.Write(this.m_TableDescriptor.NBitRecords);
      long position = w.BaseStream.Position;
      if (this.m_TableDescriptor.NCompressedStringFields == 0)
        w.Write(0);
      else
        w.Write(-1);
      w.Write((ushort) this.m_NRecords);
      w.Write((ushort) this.m_NValidRecords);
      w.Write(this.m_Unknown14);
      w.Write((byte) this.m_TableDescriptor.NFields);
      w.Write((byte) 0);
      w.Write((short) 0);
      w.Write(this.m_Unknown1C);
      this.m_CrcTableHeaderPosition = w.BaseStream.Position;
      w.Write(-1);
      this.m_TableDescriptor.SaveFieldDescriptors((BinaryWriter) w);
      long compressedStringBasePosition = w.BaseStream.Position + (long) (this.m_NRecords * this.m_TableDescriptor.RecordSize);
      int num1 = 0;
      if (this.m_TableDescriptor.HuffmannTree != null)
        num1 = this.m_TableDescriptor.HuffmannTree.Size;
      if (this.m_NRecords > 0)
      {
        for (int index = 0; index < this.m_NValidRecords; ++index)
          num1 = this.m_Records[index].Save(w, compressedStringBasePosition, num1);
        for (int nvalidRecords = this.m_NValidRecords; nvalidRecords < this.m_NRecords; ++nvalidRecords)
          this.m_Records[nvalidRecords].Fill(w);
        if (this.m_TableDescriptor.HuffmannTree != null)
        {
          w.BaseStream.Position = position;
          this.m_CompressedStringLength = (uint) num1;
          w.Write(num1);
          w.BaseStream.Position = compressedStringBasePosition;
          this.m_TableDescriptor.HuffmannTree.Save((BinaryWriter) w);
        }
        int num2 = FifaUtil.RoundUp(num1, 8);
        this.m_CrcRecordsPosition = compressedStringBasePosition + (long) num2;
        w.BaseStream.Position = this.m_CrcRecordsPosition;
        w.Write(-1);
      }
      else
      {
        this.m_CrcRecordsPosition = w.BaseStream.Position;
        w.Write(-1);
      }
    }

    public void SortByKeys()
    {
      if (this.m_TableDescriptor.KeyIndex.Length == 0 || this.m_NRecords < 2)
        return;
      Array.Sort((Array) this.m_Records, (IComparer) Table.s_RecordComparer);
    }

    public void SortByKeys(int keyIndex)
    {
      if (this.m_TableDescriptor.KeyIndex.Length == 0)
        return;
      int num = this.m_TableDescriptor.KeyIndex[0];
      this.m_TableDescriptor.KeyIndex[0] = keyIndex;
      if (this.m_TableDescriptor.NKeyFields == 0)
        this.m_TableDescriptor.NKeyFields = 1;
      if (this.m_NRecords >= 2)
        Array.Sort((Array) this.m_Records, (IComparer) Table.s_RecordComparer);
      this.m_TableDescriptor.KeyIndex[0] = num;
    }

    public Record SearchByKeys(Record r)
    {
      if (this.m_Records == null || r == null)
        return (Record) null;
      int index = Array.BinarySearch((Array) this.m_Records, (object) r, (IComparer) Table.s_RecordComparer);
      return index >= 0 ? this.m_Records[index] : (Record) null;
    }

    public string SearchStringByKey(int key)
    {
      Record record = new Record(this.m_TableDescriptor);
      record.KeyField[0] = key;
      int index = Array.BinarySearch((Array) this.m_Records, (object) record, (IComparer) Table.s_RecordComparer);
      return index >= 0 ? this.m_Records[index].StringField[0] : (string) null;
    }

    public void ExchangeRecords(int i, int j)
    {
      Record record1 = new Record(this.m_TableDescriptor);
      Record record2 = this.m_Records[i];
      this.m_Records[i] = this.m_Records[j];
      this.m_Records[j] = record2;
    }

    public Record[] ResizeRecords(int nRecords)
    {
      int num = 0;
      if (this.m_Records != null)
      {
        num = this.m_Records.Length;
        Array.Resize<Record>(ref this.m_Records, nRecords);
      }
      else
        this.m_Records = new Record[nRecords];
      if (num < nRecords)
      {
        for (int index = num; index < nRecords; ++index)
          this.m_Records[index] = new Record(this.m_TableDescriptor);
      }
      this.m_NRecords = nRecords;
      this.m_NValidRecords = nRecords;
      return this.m_Records;
    }

    public bool ExpandField(string fieldName, int nBits)
    {
      FieldDescriptor fieldDescriptor = this.m_TableDescriptor.GetFieldDescriptor(fieldName);
      return fieldDescriptor != null && fieldDescriptor.Expand(nBits);
    }

    public bool ExpandField(string fieldName, int nBits, int minValue)
    {
      FieldDescriptor fieldDescriptor = this.m_TableDescriptor.GetFieldDescriptor(fieldName);
      return fieldDescriptor != null && fieldDescriptor.Expand(nBits, minValue);
    }

    public DataTable ConvertToDataTable()
    {
      DataTable emptyDataTable = this.CreateEmptyDataTable();
      for (int index = 0; index < this.m_NRecords; ++index)
        emptyDataTable.Rows.Add(this.Records[index].ConvertToDataRow());
      return emptyDataTable;
    }

    public DataTable ConvertToDataTable(int[] keys, string fieldName)
    {
      DataTable emptyDataTable = this.CreateEmptyDataTable();
      int fieldIndex = this.m_TableDescriptor.GetFieldIndex(fieldName);
      Array.Sort<int>(keys);
      this.SortByKeys(fieldIndex);
      int num = 0;
      int index1 = num;
      int index2 = 0;
      while (index2 < keys.Length && index1 < this.m_NRecords)
      {
        for (index1 = num; index1 < this.m_NRecords; ++index1)
        {
          if (this.Records[index1].IntField[fieldIndex] >= keys[index2])
          {
            if (this.Records[index1].IntField[fieldIndex] == keys[index2])
            {
              emptyDataTable.Rows.Add(this.Records[index1].ConvertToDataRow());
              num = index1 + 1;
              break;
            }
            num = index1;
            ++index2;
            break;
          }
        }
      }
      return emptyDataTable;
    }

    public DataTable ConvertToDataTableUsingRtsg(int[] keys, string fieldName)
    {
      DataTable emptyDataTable = this.CreateEmptyDataTable();
      int fieldIndex = this.m_TableDescriptor.GetFieldIndex(fieldName);
      Array.Sort<int>(keys);
      for (int index1 = 0; index1 < this.m_NRecords; ++index1)
      {
        int num = this.Records[index1].IntField[fieldIndex] >> 20 & 4095;
        for (int index2 = 0; index2 < keys.Length; ++index2)
        {
          if (keys[index2] == num)
          {
            emptyDataTable.Rows.Add(this.Records[index1].ConvertToDataRow());
            break;
          }
        }
      }
      return emptyDataTable;
    }

    public DataTable ConvertToDataTableUsingIntField(int[] keys, int intFieldIndex)
    {
      DataTable emptyDataTable = this.CreateEmptyDataTable();
      Array.Sort<int>(keys);
      for (int index1 = 0; index1 < this.m_NRecords; ++index1)
      {
        for (int index2 = 0; index2 < keys.Length; ++index2)
        {
          if (keys[index2] == this.Records[index1].IntField[intFieldIndex])
          {
            emptyDataTable.Rows.Add(this.Records[index1].ConvertToDataRow());
            break;
          }
        }
      }
      return emptyDataTable;
    }

    public DataTable CreateEmptyDataTable()
    {
      int num1 = 0;
      float num2 = 1f;
      string str = "string";
      Type type1 = num1.GetType();
      Type type2 = num2.GetType();
      Type type3 = str.GetType();
      DataTable dataTable = new DataTable(this.m_TableDescriptor.TableName);
      for (int index = 0; index < this.m_TableDescriptor.NFields; ++index)
      {
        switch (this.m_TableDescriptor.FieldDescriptors[index].FieldType)
        {
          case FieldDescriptor.EFieldTypes.String:
            dataTable.Columns.Add(this.TableDescriptor.FieldDescriptors[index].FieldName, type3);
            break;
          case FieldDescriptor.EFieldTypes.Integer:
            dataTable.Columns.Add(this.TableDescriptor.FieldDescriptors[index].FieldName, type1);
            break;
          case FieldDescriptor.EFieldTypes.Float:
            dataTable.Columns.Add(this.TableDescriptor.FieldDescriptors[index].FieldName, type2);
            break;
          case FieldDescriptor.EFieldTypes.ShortCompressedString:
            dataTable.Columns.Add(this.TableDescriptor.FieldDescriptors[index].FieldName, type3);
            break;
          case FieldDescriptor.EFieldTypes.LongCompressedString:
            dataTable.Columns.Add(this.TableDescriptor.FieldDescriptors[index].FieldName, type3);
            break;
        }
      }
      return dataTable;
    }

    public void ConvertFromDataTable(DataTable dataTable)
    {
      this.m_NRecords = dataTable.Rows.Count;
      this.m_NValidRecords = this.m_NRecords;
      if (this.Records != null)
      {
        this.ResizeRecords(this.m_NRecords);
      }
      else
      {
        this.Records = new Record[this.m_NRecords];
        for (int index = 0; index < this.m_NRecords; ++index)
          this.Records[index] = new Record(this.m_TableDescriptor);
      }
      for (int index = 0; index < this.m_NRecords; ++index)
        this.Records[index].ConvertFromDataRow(dataTable.Rows[index]);
    }
  }
}
