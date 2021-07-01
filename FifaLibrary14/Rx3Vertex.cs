// Original code created by Rinaldo

using System.IO;

namespace FifaLibrary
{
    public class Rx3Vertex
    {
        private int m_VertexSize;
        private float m_X;
        private float m_Y;
        private float m_Z;
        private float m_U;
        private float m_V;

        public float X
        {
            get
            {
                return this.m_X;
            }
            set
            {
                this.m_X = value;
            }
        }

        public float Y
        {
            get
            {
                return this.m_Y;
            }
            set
            {
                this.m_Y = value;
            }
        }

        public float Z
        {
            get
            {
                return this.m_Z;
            }
            set
            {
                this.m_Z = value;
            }
        }

        public float U
        {
            get
            {
                return this.m_U;
            }
            set
            {
                this.m_U = value;
            }
        }

        public float V
        {
            get
            {
                return this.m_V;
            }
            set
            {
                this.m_V = value;
            }
        }

        public Rx3Vertex(BinaryReader r, int vertexSize, Rx3VertexFormat format)
        {
            long vertOffset = r.BaseStream.Position;
            m_VertexSize = vertexSize;
            if (format.OffsetPos != -1)
            {
                r.BaseStream.Position = vertOffset + format.OffsetPos;
                if (format.PosCompressed)
                {
                    m_X = -FifaUtil.ConvertToFloat(r.ReadInt16());
                    m_Y = FifaUtil.ConvertToFloat(r.ReadInt16());
                    m_Z = FifaUtil.ConvertToFloat(r.ReadInt16());
                }
                else
                {
                    m_X = -r.ReadSingle();
                    m_Y = r.ReadSingle();
                    m_Z = r.ReadSingle();
                }
            }
            else
                m_X = m_Y = m_Z = 0.0f;
            if (format.OffsetUV != -1)
            {
                r.BaseStream.Position = vertOffset + format.OffsetUV;
                m_U = FifaUtil.ConvertToFloat(r.ReadInt16());
                m_V = FifaUtil.ConvertToFloat(r.ReadInt16());
            }
            else
                m_U = m_V = 0.0f;
            r.BaseStream.Position = vertOffset + vertexSize;
        }

        public bool Save(BinaryWriter w, Rx3VertexFormat format)
        {
            if (format.OffsetPos != -1)
            {
                w.Seek(format.OffsetPos, SeekOrigin.Current);
                if (format.PosCompressed)
                {
                    w.Write(FifaUtil.ConvertFloat16ToShort(-m_X));
                    w.Write(FifaUtil.ConvertFloat16ToShort(m_Y));
                    w.Write(FifaUtil.ConvertFloat16ToShort(m_Z));
                    w.Seek(m_VertexSize - (format.OffsetPos + 6), SeekOrigin.Current);
                }
                else
                {
                    w.Write(-m_X);
                    w.Write(m_Y);
                    w.Write(m_Z);
                    w.Seek(m_VertexSize - (format.OffsetPos + 12), SeekOrigin.Current);
                }
            }
            else
                w.Seek(m_VertexSize, SeekOrigin.Current);
            return true;
        }
    }
}
