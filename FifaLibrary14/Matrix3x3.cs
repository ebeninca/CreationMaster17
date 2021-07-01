// Original code created by Rinaldo

namespace FifaLibrary
{
  public class Matrix3x3
  {
    private float a;
    private float b;
    private float c;
    private float d;
    private float e;
    private float f;
    private float g;
    private float h;
    private float i;
    private float m_Determinant;

    public float Determinant
    {
      get
      {
        return this.m_Determinant;
      }
    }

    public Matrix3x3(
      float c00,
      float c01,
      float c02,
      float c10,
      float c11,
      float c12,
      float c20,
      float c21,
      float c22)
    {
      this.a = c00;
      this.b = c01;
      this.c = c02;
      this.d = c10;
      this.e = c11;
      this.f = c12;
      this.g = c20;
      this.h = c21;
      this.i = c22;
    }

    public Matrix3x3(
      int c00,
      int c01,
      int c02,
      int c10,
      int c11,
      int c12,
      int c20,
      int c21,
      int c22)
    {
      this.a = (float) c00;
      this.b = (float) c01;
      this.c = (float) c02;
      this.d = (float) c10;
      this.e = (float) c11;
      this.f = (float) c12;
      this.g = (float) c20;
      this.h = (float) c21;
      this.i = (float) c22;
    }

    public float ComputeDeterminant()
    {
      this.m_Determinant = (float) ((double) this.a * ((double) this.e * (double) this.i - (double) this.f * (double) this.h) - (double) this.b * ((double) this.i * (double) this.d - (double) this.f * (double) this.g) + (double) this.c * ((double) this.d * (double) this.h - (double) this.e * (double) this.g));
      return this.m_Determinant;
    }

    public Matrix3x3 Invert()
    {
      double determinant = (double) this.ComputeDeterminant();
      return (double) this.m_Determinant != 0.0 ? new Matrix3x3((float) ((double) this.e * (double) this.i - (double) this.f * (double) this.h) / this.m_Determinant, (float) ((double) this.f * (double) this.g - (double) this.d * (double) this.i) / this.m_Determinant, (float) ((double) this.d * (double) this.h - (double) this.e * (double) this.g) / this.m_Determinant, (float) ((double) this.c * (double) this.h - (double) this.b * (double) this.i) / this.m_Determinant, (float) ((double) this.a * (double) this.i - (double) this.c * (double) this.g) / this.m_Determinant, (float) ((double) this.b * (double) this.g - (double) this.a * (double) this.h) / this.m_Determinant, (float) ((double) this.b * (double) this.f - (double) this.c * (double) this.e) / this.m_Determinant, (float) ((double) this.c * (double) this.d - (double) this.a * (double) this.f) / this.m_Determinant, (float) ((double) this.a * (double) this.e - (double) this.b * (double) this.d) / this.m_Determinant) : (Matrix3x3) null;
    }

    public Vector3x1 PostMultiply(Vector3x1 v)
    {
      return new Vector3x1((float) ((double) this.a * (double) v.X + (double) this.b * (double) v.Y + (double) this.c * (double) v.Z), (float) ((double) this.d * (double) v.X + (double) this.e * (double) v.Y + (double) this.f * (double) v.Z), (float) ((double) this.g * (double) v.X + (double) this.h * (double) v.Y + (double) this.i * (double) v.Z));
    }

    public Vector3x1 PreMultiply(Vector3x1 v)
    {
      return new Vector3x1((float) ((double) this.a * (double) v.X + (double) this.d * (double) v.Y + (double) this.g * (double) v.Z), (float) ((double) this.b * (double) v.X + (double) this.e * (double) v.Y + (double) this.h * (double) v.Z), (float) ((double) this.c * (double) v.X + (double) this.f * (double) v.Y + (double) this.i * (double) v.Z));
    }
  }
}
