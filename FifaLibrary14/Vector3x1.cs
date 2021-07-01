// Original code created by Rinaldo

namespace FifaLibrary
{
  public class Vector3x1
  {
    private float x;
    private float y;
    private float z;

    public float X
    {
      set
      {
        this.x = value;
      }
      get
      {
        return this.x;
      }
    }

    public float Y
    {
      set
      {
        this.y = value;
      }
      get
      {
        return this.y;
      }
    }

    public float Z
    {
      set
      {
        this.z = value;
      }
      get
      {
        return this.z;
      }
    }

    public Vector3x1(float c0, float c1, float c2)
    {
      this.x = c0;
      this.y = c1;
      this.z = c2;
    }

    public Vector3x1(int c0, int c1, int c2)
    {
      this.x = (float) c0;
      this.y = (float) c1;
      this.z = (float) c2;
    }

    public Vector3x1()
    {
      this.x = 0.0f;
      this.y = 0.0f;
      this.z = 0.0f;
    }
  }
}
