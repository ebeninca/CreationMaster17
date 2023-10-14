// Original code created by Rinaldo

//using Microsoft.DirectX.Direct3D;
using System.IO;

namespace FifaLibrary
{
    public class Rx3VertexArray
    {
        private int m_Size;
        private int m_nVertex;
        private int m_VertexSize;
        private int m_Unknown;
        private Rx3Vertex[] m_Vertex;
        private bool m_SwapEndian;

        public int nVertex
        {
            get
            {
                return this.m_nVertex;
            }
        }

        public int VertexSize
        {
            get
            {
                return this.m_VertexSize;
            }
        }

        public Rx3Vertex[] Vertexes
        {
            get
            {
                return this.m_Vertex;
            }
        }

        public Rx3VertexArray(BinaryReader r, bool swapEndian, Rx3VertexFormat format)
        {
            this.m_SwapEndian = swapEndian;
            this.Load(r, format);
        }

        public bool Load(BinaryReader r, Rx3VertexFormat format)
        {
            if (this.m_SwapEndian)
            {
                this.m_Size = FifaUtil.SwapEndian(r.ReadInt32());
                this.m_nVertex = FifaUtil.SwapEndian(r.ReadInt32());
                this.m_VertexSize = FifaUtil.SwapEndian(r.ReadInt32());
                this.m_Unknown = r.ReadInt32();
                this.m_Vertex = new Rx3Vertex[this.m_nVertex];
                for (int index = 0; index < this.m_nVertex; ++index)
                    this.m_Vertex[index] = new Rx3Vertex(r, this.m_VertexSize, format);
            }
            else
            {
                this.m_Size = r.ReadInt32();
                this.m_nVertex = r.ReadInt32();
                this.m_VertexSize = r.ReadInt32();
                this.m_Unknown = r.ReadInt32();
                this.m_Vertex = new Rx3Vertex[this.m_nVertex];
                for (int index = 0; index < this.m_nVertex; ++index)
                    this.m_Vertex[index] = new Rx3Vertex(r, this.m_VertexSize, format);
            }
            return true;
        }

        public bool Save(BinaryWriter w, Rx3VertexFormat format)
        {
            if (this.m_SwapEndian)
            {
                w.Write(FifaUtil.SwapEndian(this.m_Size));
                w.Write(FifaUtil.SwapEndian(this.m_nVertex));
                w.Write(FifaUtil.SwapEndian(this.m_VertexSize));
                w.Write(this.m_Unknown);
                for (int index = 0; index < this.m_nVertex; ++index)
                    this.m_Vertex[index].Save(w, format);
            }
            else
            {
                w.Write(this.m_Size);
                w.Write(this.m_nVertex);
                w.Write(this.m_VertexSize);
                w.Write(this.m_Unknown);
                for (int index = 0; index < this.m_nVertex; ++index)
                    this.m_Vertex[index].Save(w, format);
            }
            return true;
        }

        /*public bool SetVertex(CustomVertex.PositionNormalTextured[] newVertexes)
        {
            if (this.m_nVertex != newVertexes.Length)
                return false;
            for (int index = 0; index < this.m_nVertex; ++index)
            {
                this.m_Vertex[index].X = newVertexes[index].X;
                this.m_Vertex[index].Y = newVertexes[index].Y;
                this.m_Vertex[index].Z = newVertexes[index].Z;
            }
            return true;
        }*/
    }
}
