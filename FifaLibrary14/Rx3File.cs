// Original code created by Rinaldo

using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace FifaLibrary
{
    public class Rx3File
    {
        private float[] m_Positions = new float[32];
        private int m_Rx3bPosition;
        private Rx3Header m_Rx3Header;
        private bool m_SwapEndian;
        private bool m_IsFifa12;
        private string m_FileName;
        private int m_AlfaFlag;
        private Rx3FileDescriptor[] m_Rx3FileDescriptors;
        private Rx3Signatures m_Rx3Signatures;
        private Rx3ImageDirectory m_Rx3ImageDirectory;
        private Rx3ModelDirectory m_Rx3ModelDirectory;
        private Rx3Image[] m_Rx3Images;
        private Rx3IndexArray[] m_Rx3IndexArrays;
        private Rx3VertexArray[] m_Rx3VertexArrays;
        private Rx3VertexFormat[] m_Rx3VertexFormats;
        public float[] Positions
        {
            get
            {
                return this.m_Positions;
            }
            set
            {
                this.m_Positions = value;
            }
        }

        public bool SwapEndian
        {
            get
            {
                return this.m_SwapEndian;
            }
        }

        public bool IsFifa12
        {
            get
            {
                return this.m_IsFifa12;
            }
        }

        public bool IsFifa11
        {
            get
            {
                return !this.m_IsFifa12;
            }
        }

        public string FileName
        {
            get
            {
                return this.m_FileName;
            }
        }

        public int HairAlfaFlag
        {
            get
            {
                return this.m_AlfaFlag;
            }
        }

        public Rx3Signatures Signatures
        {
            get
            {
                return this.m_Rx3Signatures;
            }
            set
            {
                this.m_Rx3Signatures = value;
            }
        }

        public Rx3ImageDirectory Rx3ImageDirectory
        {
            get
            {
                return this.m_Rx3ImageDirectory;
            }
            set
            {
                this.m_Rx3ImageDirectory = value;
            }
        }

        public Rx3ModelDirectory Rx3ModelDirectory
        {
            get
            {
                return this.m_Rx3ModelDirectory;
            }
            set
            {
                this.m_Rx3ModelDirectory = value;
            }
        }

        public Rx3Image[] Images
        {
            get
            {
                return this.m_Rx3Images;
            }
            set
            {
                this.m_Rx3Images = value;
            }
        }

        public Rx3IndexArray[] Rx3IndexArrays
        {
            get
            {
                return this.m_Rx3IndexArrays;
            }
        }

        public Rx3VertexArray[] Rx3VertexArrays
        {
            get
            {
                return this.m_Rx3VertexArrays;
            }
        }

        public Rx3VertexFormat[] Rx3VertexFormats
        {
            get
            {
                return this.m_Rx3VertexFormats;
            }
        }

        public bool Load(FifaFile fifaFile)
        {
            if (fifaFile.IsCompressed)
                fifaFile.Decompress();
            BinaryReader reader = fifaFile.GetReader();
            bool flag = this.Load(reader);
            fifaFile.ReleaseReader(reader);
            return flag;
        }

        public bool Load(string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader r = new BinaryReader((Stream)fileStream);
            bool flag = this.Load(r);
            fileStream.Close();
            r.Close();
            this.m_FileName = fileName;
            return flag;
        }

        public bool Save(string fileName, bool saveBitmaps, bool saveVertex)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);
            BinaryWriter w = new BinaryWriter((Stream)fileStream);
            bool flag = this.Save(w, saveBitmaps, saveVertex);
            fileStream.Close();
            w.Close();
            this.m_FileName = fileName;
            return flag;
        }

        public virtual bool Load(BinaryReader r)
        {
            string str = new string(r.ReadChars(4));
            if (str == "RX3b")
            {
                this.m_IsFifa12 = true;
                this.m_SwapEndian = true;
                r.BaseStream.Position -= 4L;
            }
            else if (str == "RX3l")
            {
                this.m_IsFifa12 = true;
                this.m_SwapEndian = false;
                r.BaseStream.Position -= 4L;
            }
            else
            {
                this.m_IsFifa12 = false;
                this.m_SwapEndian = true;
                r.BaseStream.Position = 68L;
                this.m_Rx3bPosition = FifaUtil.SwapEndian(r.ReadInt32());
                r.BaseStream.Position = (long)this.m_Rx3bPosition;
            }
            this.m_Rx3Header = new Rx3Header(r, this.m_SwapEndian);
            if (this.m_Rx3Header.NFiles == 0)
                return false;
            this.m_Rx3FileDescriptors = new Rx3FileDescriptor[this.m_Rx3Header.NFiles];
            for (int index = 0; index < this.m_Rx3Header.NFiles; ++index)
                this.m_Rx3FileDescriptors[index] = new Rx3FileDescriptor(r, this.m_SwapEndian);
            int numTextures = 0;
            int numIndexBuffers = 0;
            int numVertexBuffers = 0;
            int numVertexFormats = 0;
            for (int index2 = 0; index2 < this.m_Rx3Header.NFiles; ++index2)
            {
                r.BaseStream.Position = (long)this.m_Rx3FileDescriptors[index2].Offset;
                switch (this.m_Rx3FileDescriptors[index2].Signature)
                {
                    case 5798132:
                        this.m_Rx3IndexArrays[numIndexBuffers++] = new Rx3IndexArray(r, this.m_SwapEndian);
                        continue;
                    case 5798561:
                        this.m_Rx3VertexArrays[numVertexBuffers] = new Rx3VertexArray(r, this.m_SwapEndian, m_Rx3VertexFormats[numVertexBuffers]);
                        numVertexBuffers++;
                        continue;
                    case 3263271920:
                        this.m_Rx3VertexFormats[numVertexFormats++] = new Rx3VertexFormat(r, this.m_SwapEndian);
                        continue;
                    case 123459928:
                    case 230948820:
                    case 255353250:
                    case 685399266:
                    case 2116321516:
                    case 3566041216:
                    case 3751472158:
                    case 4185470741:
                        continue;
                    case 582139446:
                        this.m_Rx3ModelDirectory = new Rx3ModelDirectory(r, this.m_SwapEndian);
                        this.m_Rx3IndexArrays = new Rx3IndexArray[this.m_Rx3ModelDirectory.NFiles];
                        this.m_Rx3VertexArrays = new Rx3VertexArray[this.m_Rx3ModelDirectory.NFiles];
                        this.m_Rx3VertexFormats = new Rx3VertexFormat[this.m_Rx3ModelDirectory.NFiles];
                        continue;
                    case 1285267122:
                        r.ReadBytes(20);
                        this.m_AlfaFlag = (int)r.ReadByte();
                        continue;
                    case 1808827868:
                        this.m_Rx3ImageDirectory = new Rx3ImageDirectory(r, this.m_SwapEndian);
                        this.m_Rx3Images = new Rx3Image[this.m_Rx3ImageDirectory.NFiles];
                        continue;
                    case 2047566042:
                        this.m_Rx3Images[numTextures++] = new Rx3Image(r, this.m_SwapEndian);
                        continue;
                    case 4116388378:
                        this.LoadPositions(r);
                        continue;
                    default:
                        return false;
                }
            }
            return true;
        }

        private void LoadPositions(BinaryReader r)
        {
            if (this.m_SwapEndian)
            {
                r.ReadBytes(29);
                this.m_Positions[0] = FifaUtil.SwapAndConvertToFloat(r);
                this.m_Positions[1] = FifaUtil.SwapAndConvertToFloat(r);
                this.m_Positions[2] = FifaUtil.SwapAndConvertToFloat(r);
                this.m_Positions[3] = FifaUtil.SwapAndConvertToFloat(r);
                r.ReadBytes(11);
                this.m_Positions[4] = FifaUtil.SwapAndConvertToFloat(r);
                this.m_Positions[5] = FifaUtil.SwapAndConvertToFloat(r);
                this.m_Positions[6] = FifaUtil.SwapAndConvertToFloat(r);
                this.m_Positions[7] = FifaUtil.SwapAndConvertToFloat(r);
                r.ReadBytes(12);
                this.m_Positions[8] = FifaUtil.SwapAndConvertToFloat(r);
                this.m_Positions[9] = FifaUtil.SwapAndConvertToFloat(r);
                this.m_Positions[10] = FifaUtil.SwapAndConvertToFloat(r);
                this.m_Positions[11] = FifaUtil.SwapAndConvertToFloat(r);
                r.ReadBytes(5);
                this.m_Positions[12] = FifaUtil.SwapAndConvertToFloat(r);
                this.m_Positions[13] = FifaUtil.SwapAndConvertToFloat(r);
                this.m_Positions[14] = FifaUtil.SwapAndConvertToFloat(r);
                this.m_Positions[15] = FifaUtil.SwapAndConvertToFloat(r);
                r.ReadBytes(15);
                this.m_Positions[16] = FifaUtil.SwapAndConvertToFloat(r);
                this.m_Positions[17] = FifaUtil.SwapAndConvertToFloat(r);
                this.m_Positions[18] = FifaUtil.SwapAndConvertToFloat(r);
                this.m_Positions[19] = FifaUtil.SwapAndConvertToFloat(r);
                r.ReadBytes(16);
                this.m_Positions[20] = FifaUtil.SwapAndConvertToFloat(r);
                this.m_Positions[21] = FifaUtil.SwapAndConvertToFloat(r);
                this.m_Positions[22] = FifaUtil.SwapAndConvertToFloat(r);
                this.m_Positions[23] = FifaUtil.SwapAndConvertToFloat(r);
                r.ReadBytes(13);
                this.m_Positions[24] = FifaUtil.SwapAndConvertToFloat(r);
                this.m_Positions[25] = FifaUtil.SwapAndConvertToFloat(r);
                this.m_Positions[26] = FifaUtil.SwapAndConvertToFloat(r);
                this.m_Positions[27] = FifaUtil.SwapAndConvertToFloat(r);
                r.ReadBytes(7);
                this.m_Positions[28] = FifaUtil.SwapAndConvertToFloat(r);
                this.m_Positions[29] = FifaUtil.SwapAndConvertToFloat(r);
                this.m_Positions[30] = FifaUtil.SwapAndConvertToFloat(r);
                this.m_Positions[31] = FifaUtil.SwapAndConvertToFloat(r);
            }
            else
            {
                r.ReadBytes(29);
                this.m_Positions[0] = r.ReadSingle();
                this.m_Positions[1] = r.ReadSingle();
                this.m_Positions[2] = r.ReadSingle();
                this.m_Positions[3] = r.ReadSingle();
                r.ReadBytes(11);
                this.m_Positions[4] = r.ReadSingle();
                this.m_Positions[5] = r.ReadSingle();
                this.m_Positions[6] = r.ReadSingle();
                this.m_Positions[7] = r.ReadSingle();
                r.ReadBytes(12);
                this.m_Positions[8] = r.ReadSingle();
                this.m_Positions[9] = r.ReadSingle();
                this.m_Positions[10] = r.ReadSingle();
                this.m_Positions[11] = r.ReadSingle();
                r.ReadBytes(5);
                this.m_Positions[12] = r.ReadSingle();
                this.m_Positions[13] = r.ReadSingle();
                this.m_Positions[14] = r.ReadSingle();
                this.m_Positions[15] = r.ReadSingle();
                r.ReadBytes(15);
                this.m_Positions[16] = r.ReadSingle();
                this.m_Positions[17] = r.ReadSingle();
                this.m_Positions[18] = r.ReadSingle();
                this.m_Positions[19] = r.ReadSingle();
                r.ReadBytes(16);
                this.m_Positions[20] = r.ReadSingle();
                this.m_Positions[21] = r.ReadSingle();
                this.m_Positions[22] = r.ReadSingle();
                this.m_Positions[23] = r.ReadSingle();
                r.ReadBytes(13);
                this.m_Positions[24] = r.ReadSingle();
                this.m_Positions[25] = r.ReadSingle();
                this.m_Positions[26] = r.ReadSingle();
                this.m_Positions[27] = r.ReadSingle();
                r.ReadBytes(7);
                this.m_Positions[28] = r.ReadSingle();
                this.m_Positions[29] = r.ReadSingle();
                this.m_Positions[30] = r.ReadSingle();
                this.m_Positions[31] = r.ReadSingle();
            }
        }

        private void SavePositions(BinaryWriter w)
        {
            if (this.m_SwapEndian)
            {
                w.Seek(29, SeekOrigin.Current);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[0]);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[1]);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[2]);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[3]);
                w.Seek(11, SeekOrigin.Current);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[4]);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[5]);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[6]);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[7]);
                w.Seek(12, SeekOrigin.Current);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[8]);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[9]);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[10]);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[11]);
                w.Seek(5, SeekOrigin.Current);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[12]);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[13]);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[14]);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[15]);
                w.Seek(15, SeekOrigin.Current);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[16]);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[17]);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[18]);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[19]);
                w.Seek(16, SeekOrigin.Current);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[20]);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[21]);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[22]);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[23]);
                w.Seek(13, SeekOrigin.Current);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[24]);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[25]);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[26]);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[27]);
                w.Seek(7, SeekOrigin.Current);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[28]);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[29]);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[30]);
                FifaUtil.SwapAndWriteFloat(w, this.m_Positions[31]);
            }
            else
            {
                w.Seek(29, SeekOrigin.Current);
                w.Write(this.m_Positions[0]);
                w.Write(this.m_Positions[1]);
                w.Write(this.m_Positions[2]);
                w.Write(this.m_Positions[3]);
                w.Seek(11, SeekOrigin.Current);
                w.Write(this.m_Positions[4]);
                w.Write(this.m_Positions[5]);
                w.Write(this.m_Positions[6]);
                w.Write(this.m_Positions[7]);
                w.Seek(12, SeekOrigin.Current);
                w.Write(this.m_Positions[8]);
                w.Write(this.m_Positions[9]);
                w.Write(this.m_Positions[10]);
                w.Write(this.m_Positions[11]);
                w.Seek(5, SeekOrigin.Current);
                w.Write(this.m_Positions[12]);
                w.Write(this.m_Positions[13]);
                w.Write(this.m_Positions[14]);
                w.Write(this.m_Positions[15]);
                w.Seek(15, SeekOrigin.Current);
                w.Write(this.m_Positions[16]);
                w.Write(this.m_Positions[17]);
                w.Write(this.m_Positions[18]);
                w.Write(this.m_Positions[19]);
                w.Seek(16, SeekOrigin.Current);
                w.Write(this.m_Positions[20]);
                w.Write(this.m_Positions[21]);
                w.Write(this.m_Positions[22]);
                w.Write(this.m_Positions[23]);
                w.Seek(13, SeekOrigin.Current);
                w.Write(this.m_Positions[24]);
                w.Write(this.m_Positions[25]);
                w.Write(this.m_Positions[26]);
                w.Write(this.m_Positions[27]);
                w.Seek(7, SeekOrigin.Current);
                w.Write(this.m_Positions[28]);
                w.Write(this.m_Positions[29]);
                w.Write(this.m_Positions[30]);
                w.Write(this.m_Positions[31]);
            }
        }

        public virtual bool Save(BinaryWriter w, bool saveBitmaps, bool saveVertex)
        {
            if (this.m_Rx3Signatures != null)
                this.m_Rx3Signatures.Save(w);
            w.BaseStream.Position = (long)this.m_Rx3bPosition;
            this.m_Rx3Header.Save(w);
            for (int index = 0; index < this.m_Rx3Header.NFiles; ++index)
                this.m_Rx3FileDescriptors[index].Save(w);
            int numTextures = 0;
            int numVertexBuffers = 0;
            int numIndexBuffers = 0;
            for (int index2 = 0; index2 < this.m_Rx3Header.NFiles; ++index2)
            {
                w.BaseStream.Position = (long)this.m_Rx3FileDescriptors[index2].Offset;
                switch (this.m_Rx3FileDescriptors[index2].Signature)
                {
                    case 5798132:
                        if (saveVertex)
                        {
                            this.m_Rx3IndexArrays[numIndexBuffers++].Save(w);
                            break;
                        }
                        break;
                    case 5798561:
                        if (saveVertex)
                        {
                            this.m_Rx3VertexArrays[numVertexBuffers].Save(w, m_Rx3VertexFormats[numVertexBuffers]);
                            numVertexBuffers++;
                            break;
                        }
                        break;
                    case 2047566042:
                        if (saveBitmaps)
                        {
                            this.m_Rx3Images[numTextures++].Save(w);
                            break;
                        }
                        break;
                    case 4116388378:
                        this.SavePositions(w);
                        break;
                }
            }
            return true;
        }

        public Bitmap[] GetBitmaps()
        {
            Bitmap[] bitmapArray = new Bitmap[this.m_Rx3Images.Length];
            for (int index = 0; index < this.m_Rx3Images.Length; ++index)
                bitmapArray[index] = this.m_Rx3Images[index].GetBitmap();
            return bitmapArray;
        }

        public bool ReplaceBitmaps(Bitmap[] bitmaps)
        {
            bool flag1 = true;
            int num = bitmaps.Length < this.m_Rx3Images.Length ? bitmaps.Length : this.m_Rx3Images.Length;
            for (int index = 0; index < num; ++index)
            {
                if (bitmaps[index] != null)
                {
                    bool flag2 = this.m_Rx3Images[index].SetBitmap(bitmaps[index]);
                    flag1 = flag1 && flag2;
                }
            }
            return flag1;
        }

        public bool CreateXFiles(string baseFileName)
        {
            if (this.m_Rx3IndexArrays.Length == 0)
                return false;
            for (int index = 0; index < this.m_Rx3IndexArrays.Length; ++index)
            {
                /*Model3D model3D = new Model3D();
                model3D.Initialize(this.m_Rx3IndexArrays[index], this.m_Rx3VertexArrays[index]);
                string path = baseFileName + index.ToString() + ".X";
                Application.CurrentCulture = new CultureInfo("en-us");
                FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
                StreamWriter w = new StreamWriter((Stream)fileStream);
                w.WriteLine("xof 0303txt 0032");
                model3D.SaveXFile(w);
                w.Close();
                fileStream.Close();*/
            }
            return true;
        }

        public bool ConvertKitFrom11(Rx3File sourceRx3File)
        {
            return !this.IsFifa11 && !sourceRx3File.IsFifa12;
        }

        public bool ConvertKitFrom12(Rx3File sourceRx3File)
        {
            return !this.IsFifa12 && !sourceRx3File.IsFifa11;
        }

        public bool ConvertKit(Rx3File sourceRx3File)
        {
            return this.IsFifa12 ? this.ConvertKitFrom11(sourceRx3File) : this.ConvertKitFrom12(sourceRx3File);
        }
    }
}
