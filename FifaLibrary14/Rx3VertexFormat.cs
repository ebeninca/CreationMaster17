using System.IO;

namespace FifaLibrary
{
    public class Rx3VertexFormat
    {
        private string m_Raw;
        private int m_OffsetPos;
        private int m_OffsetUV;
        private bool m_PosCompressed;
        public static bool m_LoadingHairMesh;

        public string Raw
        {
            get
            {
                return this.m_Raw;
            }
        }

        public int OffsetPos
        {
            get
            {
                return this.m_OffsetPos;
            }
        }

        public int OffsetUV
        {
            get
            {
                return this.m_OffsetUV;
            }
        }

        public bool PosCompressed
        {
            get
            {
                return this.m_PosCompressed;
            }
        }

        public static bool LoadingHairMesh
        {
            get
            {
                return m_LoadingHairMesh;
            }
            set
            {
                m_LoadingHairMesh = value;
            }
        }

        public Rx3VertexFormat(BinaryReader r, bool swapEndian)
        {
            m_OffsetPos = -1;
            m_OffsetUV = -1;
            m_PosCompressed = false;
            r.ReadBytes(4);
            int formatSize = 0;
            if (swapEndian)
            {
                formatSize = FifaUtil.SwapEndian(r.ReadInt32());
            }
            else
            {
                formatSize = r.ReadInt32();
            }
            if (formatSize > 1)
            {
                r.ReadBytes(8);
                m_Raw = System.Text.Encoding.ASCII.GetString(r.ReadBytes(formatSize - 1));
                string[] elements = m_Raw.Split(' ');
                if (elements.Length > 0)
                {
                    string positionAttribute = "p0";
                    string texCoordAttribute = LoadingHairMesh ? "t1" : "t0";
                    bool foundPos = false;
                    bool foundTex = false;
                    for (int i = 0; i < elements.Length; i++)
                    {
                        string[] attributes = elements[i].Split(':');
                        if (attributes.Length == 3 || attributes.Length == 4 || attributes.Length == 5)
                        {
                            if (attributes[0] == positionAttribute)
                            {
                                if (attributes[attributes.Length - 1] == "3f32")
                                    m_OffsetPos = int.Parse(attributes[1], System.Globalization.NumberStyles.HexNumber);
                                else if (attributes[attributes.Length - 1] == "4f16")
                                {
                                    m_OffsetPos = int.Parse(attributes[1], System.Globalization.NumberStyles.HexNumber);
                                    m_PosCompressed = true;
                                }
                                foundPos = true;
                            }
                            else if (attributes[0] == texCoordAttribute)
                            {
                                if (attributes[attributes.Length - 1] == "2f16")
                                    m_OffsetUV = int.Parse(attributes[1], System.Globalization.NumberStyles.HexNumber);
                                foundTex = true;
                            }
                        }
                        if (foundPos && foundTex)
                            break;
                    }
                }
            }
        }
    }
}
