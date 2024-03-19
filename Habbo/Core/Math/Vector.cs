namespace Habbo.Core.Math
{
  public class Vector
  {
    public int X;
    public int Y;
    public double Z;

    public Vector(int x = 0, int y = 0, double z = 0.0)
    {
      X = x;
      Y = y;
      Z = z;
    }

    public bool Equal(int x, int y, double z)
    {
      return X == x && Y == y && Z == z;
    }

    public bool Equal(int x, int y)
    {
      return X == x && Y == y;
    }

    public bool Equal(Vector vec)
    {
      return X == vec.X && Y == vec.Y && Z == vec.Z;
    }

    public void Set(int x, int y, double z)
    {
      this.X = x;
      this.Y = y;
      this.Z = z;
    }

  }
}
