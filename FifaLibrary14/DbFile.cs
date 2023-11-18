// Original code created by Rinaldo

using System.Data;
using System.IO;
using System.Windows.Forms;

namespace FifaLibrary
{
    public class DbFile
    {
        protected char[] m_Signature;
        protected int m_FileLength;
        private long m_SignaturePosition;
        private uint m_CrcHeader;
        private long m_CrcHeaderPosition;
        private uint m_CrcShortNames;
        private long m_CrcShortNamesPosition;
        private uint[] m_TableOffset;
        private FifaLibrary.Table[] m_Table;
        protected int m_NTables;
        private ToolStripProgressBar m_ProgressBar;
        protected string m_FileName;
        protected string m_XmlFileName;
        protected DataSet m_DescriptorDataSet;
        private bool m_NeedToSaveXmlFile;
        protected FifaPlatform m_Platform;

        public FifaLibrary.Table[] Table
        {
            get
            {
                return this.m_Table;
            }
            set
            {
                this.m_Table = value;
            }
        }

        public int NTables
        {
            get
            {
                return this.m_NTables;
            }
        }

        public ToolStripProgressBar ProgressBar
        {
            set
            {
                this.m_ProgressBar = value;
            }
        }

        public string FileName
        {
            get
            {
                return this.m_FileName;
            }
        }

        public string XmlFileName
        {
            get
            {
                return this.m_XmlFileName;
            }
        }

        public DataSet DescriptorDataSet
        {
            get
            {
                return this.m_DescriptorDataSet;
            }
            set
            {
                this.m_DescriptorDataSet = value;
            }
        }

        public FifaPlatform Platform
        {
            get
            {
                return this.m_Platform;
            }
            set
            {
                this.m_Platform = value;
            }
        }

        public DbFile()
        {
            this.m_FileName = (string)null;
            this.m_XmlFileName = (string)null;
            this.m_DescriptorDataSet = (DataSet)null;
            this.m_Platform = FifaPlatform.PC;
        }

        public DbFile(string dbFileName, string xmlFileName, ToolStripProgressBar toolStripProgressBar)
        {
            this.m_ProgressBar = toolStripProgressBar;
            this.m_FileName = dbFileName;
            this.m_XmlFileName = xmlFileName;
            this.m_DescriptorDataSet = (DataSet)null;
            this.m_Platform = FifaPlatform.PC;
            this.Load();
        }

        public DbFile(string dbFileName, string xmlFileName)
        {
            this.m_ProgressBar = (ToolStripProgressBar)null;
            this.m_FileName = dbFileName;
            this.m_XmlFileName = xmlFileName;
            this.m_DescriptorDataSet = (DataSet)null;
            this.m_Platform = FifaPlatform.PC;
            this.Load();
        }

        public void ComputeAllCrc(DbReader r, DbWriter w)
        {
            long signaturePosition = this.m_SignaturePosition;
            int count1 = (int)(this.m_CrcHeaderPosition - signaturePosition);
            this.ComputeAndWriteCrc(r, w, signaturePosition, count1);
            long offset1 = signaturePosition + (long)(count1 + 4);
            int count2 = (int)(this.m_CrcShortNamesPosition - offset1);
            this.ComputeAndWriteCrc(r, w, offset1, count2);
            for (int index = 0; index < this.m_NTables; ++index)
            {
                long offset2 = offset1 + (long)(count2 + 4);
                int count3 = (int)(this.m_Table[index].CrcTableHeaderPosition - offset2);
                this.ComputeAndWriteCrc(r, w, offset2, count3);
                offset1 = offset2 + (long)(count3 + 4);
                count2 = (int)(this.m_Table[index].CrcRecordsPosition - offset1);
                this.ComputeAndWriteCrc(r, w, offset1, count2);
            }
        }

        public bool ComputeAllCrc()
        {
            if (!File.Exists(this.m_FileName))
                return false;
            FileStream fileStream = new FileStream(this.m_FileName, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            DbWriter w = new DbWriter((Stream)fileStream, this.m_Platform);
            DbReader r = new DbReader((Stream)fileStream, this.m_Platform);
            this.ComputeAllCrc(r, w);
            r.Close();
            w.Close();
            fileStream.Close();
            return true;
        }

        public int ComputeAndWriteCrc(DbReader r, DbWriter w, long offset, int count)
        {
            byte[] numArray = new byte[count];
            r.BaseStream.Seek(offset, SeekOrigin.Begin);
            int crcDb11 = FifaUtil.ComputeCrcDb11(r.ReadBytes(count));
            w.Write(crcDb11);
            return crcDb11;
        }

        public bool LoadDb(string fileName)
        {
            if (!File.Exists(fileName))
                return false;
            this.m_FileName = fileName;
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            DbReader r = new DbReader((Stream)fileStream, FifaPlatform.PC);
            bool flag = this.LoadDb(r, false);
            r.Close();
            fileStream.Close();
            return flag;
        }

        public bool LoadDb(DbReader r, bool skipData)
        {
            bool flag1 = false;
            if (skipData)
            {
                for (; r.BaseStream.Position <= r.BaseStream.Length - 4L; r.BaseStream.Position -= 3L)
                {
                    if (r.ReadUInt32() == 134234692U)
                    {
                        flag1 = true;
                        r.BaseStream.Position -= 4L;
                        break;
                    }
                }
                if (!flag1)
                    return false;
            }
            bool flag2 = true;
            this.m_SignaturePosition = r.BaseStream.Position;
            this.m_Signature = r.ReadChars(8);
            if (this.m_Signature[0] != 'D' || this.m_Signature[1] != 'B' || (this.m_Signature[2] != char.MinValue || this.m_Signature[3] != '\b') || (this.m_Signature[5] != char.MinValue || this.m_Signature[6] != char.MinValue || this.m_Signature[7] != char.MinValue))
                return false;
            if (this.m_Signature[4] == char.MinValue)
            {
                this.m_Platform = FifaPlatform.PC;
                r.Platform = this.m_Platform;
            }
            else
            {
                if (this.m_Signature[4] != '\x0001')
                    return false;
                this.m_Platform = FifaPlatform.XBox;
                r.Platform = this.m_Platform;
            }
            this.m_FileLength = r.ReadInt32();
            if ((long)this.m_FileLength > r.BaseStream.Length)
                return false;
            r.ReadInt32();
            this.m_NTables = r.ReadInt32();
            this.m_TableOffset = new uint[this.m_NTables];
            TableDescriptor.DescriptorDataSet = this.m_DescriptorDataSet;
            this.m_Table = new FifaLibrary.Table[this.m_NTables];
            if (this.m_ProgressBar != null)
                this.m_ProgressBar.Maximum = this.m_NTables;
            this.m_CrcHeaderPosition = r.BaseStream.Position;
            this.m_CrcHeader = r.ReadUInt32();
            for (int index = 0; index < this.m_NTables; ++index)
            {
                this.m_Table[index] = new FifaLibrary.Table();
                this.m_Table[index].LoadTableName(r);
                this.m_TableOffset[index] = r.ReadUInt32();
            }
            this.m_CrcShortNamesPosition = r.BaseStream.Position;
            this.m_CrcShortNames = r.ReadUInt32();
            long position = r.BaseStream.Position;
            for (int index = 0; index < this.m_NTables; ++index)
            {
                if (this.m_ProgressBar != null)
                    this.m_ProgressBar.Value = index;
                this.m_Table[index].Load(r, position + (long)this.m_TableOffset[index]);
            }
            if (this.m_ProgressBar != null)
                this.m_ProgressBar.Value = 0;
            return flag2;
        }

        public bool LoadDb()
        {
            return this.m_FileName != null && this.LoadDb(this.m_FileName);
        }

        public bool LoadXml(string xmlFileName)
        {
            if (!File.Exists(xmlFileName))
                return false;
            this.m_XmlFileName = xmlFileName;
            this.m_NeedToSaveXmlFile = false;
            this.m_DescriptorDataSet = new DataSet("XML_Descriptor");
            int num = (int)this.m_DescriptorDataSet.ReadXml(this.m_XmlFileName);
            return true;
        }

        public bool LoadXml()
        {
            return this.m_XmlFileName != null && this.LoadXml(this.m_XmlFileName);
        }

        public bool Load()
        {
            return this.LoadXml() && this.LoadDb();
        }

        public bool SaveDb(string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
            DbWriter w = new DbWriter((Stream)fileStream, this.m_Platform);
            this.SaveDb(w);
            w.Close();
            fileStream.Close();
            this.ComputeAllCrc();
            return true;
        }

        public bool SaveDb(DbWriter w)
        {
            if (this.m_ProgressBar != null)
                this.m_ProgressBar.Maximum = this.m_NTables;
            w.Write(this.m_Signature);
            long position1 = w.BaseStream.Position;
            w.Write(-1L);
            w.Write(this.m_NTables);
            this.m_CrcHeaderPosition = w.BaseStream.Position;
            w.Write(-1);
            long num = w.BaseStream.Position + 4L;
            for (int index = 0; index < this.m_NTables; ++index)
            {
                w.Write(this.m_Table[index].TableDescriptor.ShortName);
                w.Write(-1);
            }
            this.m_CrcShortNamesPosition = w.BaseStream.Position;
            w.Write(-1);
            long position2 = w.BaseStream.Position;
            for (int index = 0; index < this.m_NTables; ++index)
            {
                if (this.m_ProgressBar != null)
                    this.m_ProgressBar.Value = index;
                this.m_TableOffset[index] = (uint)(w.BaseStream.Position - position2);
                this.m_Table[index].Save(w);
            }
            this.m_FileLength = (int)(w.BaseStream.Position - this.m_SignaturePosition);
            w.BaseStream.Position = position1;
            w.Write(this.m_FileLength);
            w.Write(0);
            w.BaseStream.Position = num;
            for (int index = 0; index < this.m_NTables; ++index)
            {
                w.Write(this.m_TableOffset[index]);
                w.BaseStream.Position += 4L;
            }
            w.Seek(0, SeekOrigin.End);
            if (this.m_ProgressBar != null)
                this.m_ProgressBar.Value = 0;
            return true;
        }

        public bool SaveXml(string xmlFileName)
        {
            if (this.m_NeedToSaveXmlFile)
            {
                File.Copy(xmlFileName, xmlFileName + ".bak", true);
                this.m_DescriptorDataSet.WriteXml(xmlFileName, XmlWriteMode.IgnoreSchema);
            }
            this.m_NeedToSaveXmlFile = false;
            return true;
        }

        public bool SaveXml()
        {
            return this.m_XmlFileName != null && this.SaveXml(this.m_XmlFileName);
        }

        public bool SaveDb()
        {
            return this.m_FileName != null && this.SaveDb(this.m_FileName);
        }

        public void Document()
        {
            if (this.m_FileName == null)
                return;
            FileStream fileStream = new FileStream(Path.GetFullPath(this.m_FileName).Replace(".db", ".txt"), FileMode.Create);
            StreamWriter streamWriter = new StreamWriter((Stream)fileStream);
            for (int index = 0; index < this.m_NTables; ++index)
            {
                string tableName = this.m_Table[index].TableDescriptor.TableName;
                streamWriter.WriteLine("static private string t_" + tableName + " = \"" + tableName + "\";");
            }
            for (int index = 0; index < this.m_NTables; ++index)
            {
                string tableName = this.m_Table[index].TableDescriptor.TableName;
                streamWriter.WriteLine("static public int " + tableName + ";");
            }
            for (int index = 0; index < this.m_NTables; ++index)
            {
                string tableName = this.m_Table[index].TableDescriptor.TableName;
                streamWriter.WriteLine(tableName + " = fifaDbFile.GetTableIndex(t_" + tableName + ");");
            }
            for (int index1 = 0; index1 < this.m_NTables; ++index1)
            {
                string tableName = this.m_Table[index1].TableDescriptor.TableName;
                for (int index2 = 0; index2 < this.m_Table[index1].TableDescriptor.NFields; ++index2)
                {
                    string fieldName = this.m_Table[index1].TableDescriptor.FieldDescriptors[index2].FieldName;
                    int fieldType = (int)this.m_Table[index1].TableDescriptor.FieldDescriptors[index2].FieldType;
                    streamWriter.WriteLine("public static int " + tableName + "_" + fieldName + " = -1;");
                }
            }
            for (int index1 = 0; index1 < this.m_NTables; ++index1)
            {
                string tableName = this.m_Table[index1].TableDescriptor.TableName;
                for (int index2 = 0; index2 < this.m_Table[index1].TableDescriptor.NFields; ++index2)
                {
                    string fieldName = this.m_Table[index1].TableDescriptor.FieldDescriptors[index2].FieldName;
                    FieldDescriptor.EFieldTypes fieldType = this.m_Table[index1].TableDescriptor.FieldDescriptors[index2].FieldType;
                    int typeIndex = this.m_Table[index1].TableDescriptor.FieldDescriptors[index2].TypeIndex;
                    streamWriter.WriteLine(tableName + "_" + fieldName + " = " + typeIndex.ToString() + "; //" + fieldType.ToString());
                }
            }
            streamWriter.Close();
            fileStream.Close();
        }

        public DataSet ConvertToDataSet()
        {
            if (this.m_NTables == 0)
                return (DataSet)null;
            if (this.m_ProgressBar != null)
                this.m_ProgressBar.Maximum = this.m_NTables;
            DataSet dataSet = new DataSet();
            for (int index = 0; index < this.m_NTables; ++index)
            {
                if (this.m_ProgressBar != null)
                    this.m_ProgressBar.Value = index;
                dataSet.Tables.Add(this.Table[index].ConvertToDataTable());
            }
            if (this.m_ProgressBar != null)
                this.m_ProgressBar.Value = 0;
            return dataSet;
        }

        public void ConvertFromDataSet(DataSet dataSet)
        {
            if (this.m_ProgressBar != null)
                this.m_ProgressBar.Maximum = this.m_NTables;
            for (int index = 0; index < this.m_NTables; ++index)
            {
                if (this.m_ProgressBar != null)
                    this.m_ProgressBar.Value = index;
                this.Table[index].ConvertFromDataTable(dataSet.Tables[index]);
            }
            if (this.m_ProgressBar == null)
                return;
            this.m_ProgressBar.Value = 0;
        }

        public int GetTableIndex(string tableName)
        {
            for (int index = 0; index < this.NTables; ++index)
            {
                if (this.Table[index].TableDescriptor.TableName == tableName)
                    return index;
            }
            return -1;
        }

        public bool Expand()
        {
            bool flag1 = true;
            bool flag2 = this.ExpandTableField("playernames", "nameid", 16);
            bool flag3 = flag1 && !flag2;
            this.RecalculateFieldOffset("playernames");
            bool flag4 = this.ExpandTableField("career_lastnames", "lastname", 16);
            bool flag5 = flag3 && !flag4;
            this.RecalculateFieldOffset("career_lastnames");
            bool flag6 = this.ExpandTableField("career_firstnames", "firstname", 16);
            bool flag7 = flag5 && !flag6;
            this.RecalculateFieldOffset("career_firstnames");
            bool flag8 = this.ExpandTableField("career_commonnames", "firstname", 16);
            bool flag9 = flag7 && !flag8;
            bool flag10 = this.ExpandTableField("career_lastnames", "lastname", 16);
            bool flag11 = flag9 && !flag10;
            this.RecalculateFieldOffset("career_commonnames");
            bool flag12 = this.ExpandTableField("trainingteamplayernames", "nameid", 16);
            bool flag13 = flag11 && !flag12;
            this.RecalculateFieldOffset("trainingteamplayernames");
            bool flag14 = this.ExpandTableField("players", "firstnameid", 16);
            bool flag15 = flag13 && !flag14;
            bool flag16 = this.ExpandTableField("players", "lastnameid", 16);
            bool flag17 = flag15 && !flag16;
            bool flag18 = this.ExpandTableField("players", "commonnameid", 16);
            bool flag19 = flag17 && !flag18;
            bool flag20 = this.ExpandTableField("players", "playerjerseynameid", 16);
            bool flag21 = flag19 && !flag20;
            this.RecalculateFieldOffset("players");
            bool flag22 = this.ExpandTableField("trainingteamplayernames", "firstnameid", 16);
            bool flag23 = flag21 && !flag22;
            bool flag24 = this.ExpandTableField("trainingteamplayernames", "lastnameid", 16);
            bool flag25 = flag23 && !flag24;
            bool flag26 = this.ExpandTableField("trainingteamplayernames", "commonnameid", 16);
            bool flag27 = flag25 && !flag26;
            bool flag28 = this.ExpandTableField("trainingteamplayernames", "playerjerseynameid", 16);
            bool flag29 = flag27 && !flag28;
            this.RecalculateFieldOffset("trainingteamplayernames");
            bool flag30 = this.ExpandTableField("referee", "refereeid", 10);
            bool flag31 = flag29 && !flag30;
            this.RecalculateFieldOffset("referee");
            bool flag32 = this.ExpandTableField("leaguerefereelinks", "refereeid", 10);
            bool flag33 = flag31 && !flag32;
            this.RecalculateFieldOffset("leaguerefereelinks");
            this.m_NeedToSaveXmlFile = true;
            return flag33;
        }

        private bool ExpandTableField(string tableName, string fieldName, int nBits)
        {
            FifaLibrary.Table table = this.GetTable(tableName);
            return table != null && table.ExpandField(fieldName, nBits);
        }

        private bool ExpandTableField(string tableName, string fieldName, int nBits, int minValue)
        {
            FifaLibrary.Table table = this.GetTable(tableName);
            return table != null && table.ExpandField(fieldName, nBits, minValue);
        }

        private bool RecalculateFieldOffset(string tableName)
        {
            FifaLibrary.Table table = this.GetTable(tableName);
            if (table == null)
                return false;
            table.TableDescriptor.RecalculateFieldOffset();
            return true;
        }

        public FifaLibrary.Table GetTable(string longName)
        {
            for (int index = 0; index < this.m_NTables; ++index)
            {
                if (this.m_Table[index].TableDescriptor.TableName == longName)
                    return this.m_Table[index];
            }
            return (FifaLibrary.Table)null;
        }
    }
}
