namespace VectorMath.Math.Vector;

public class Vector4
{
    public static Vector4 UnitX => new Vector4(1, 0, 0, 0);
    public static Vector4 UnitY => new Vector4(0, 1, 0, 0);
    public static Vector4 UnitZ => new Vector4(0, 0, 1, 0);
    public static Vector4 UnitW => new Vector4(0, 0, 0, 1);
    
    public static Vector4 Zero => new Vector4(0, 0, 0, 0);

    public static Vector4 One => new Vector4(1, 1, 1, 1);

    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
    public float W { get; set; }
    
    public float SqrMagnitude => X * X + Y * Y + Z * Z + W * W;

    public float Magnitude => MathF.Sqrt(SqrMagnitude);
    
    public Vector4 Normalized
    {
        get
        {
            if (SqrMagnitude > 1e-5)
            {
                return this / Magnitude;
            }

            return One;
        }
    }

    public Vector4(float x, float y, float z, float w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public Vector4 Add(Vector4 other)
    {
        return new Vector4(X + other.X, Y + other.Y, Z + other.Z, W + other.W);
    }

    public Vector4 Subtract(Vector4 other)
    {
        return new Vector4(X - other.X, Y - other.Y, Z - other.Z, W - other.W);
    }

    public Vector4 Scale(float scalar)
    {
        return new Vector4(X * scalar, Y * scalar, Z * scalar, W * scalar);
    }

    public float Dot(Vector4 other)
    {
        return X * other.X + Y * other.Y + Z * other.Z + W * other.W;
    }

    public void Normalize()
    {
        var normalized = Normalized;
        X = normalized.X;
        Y = normalized.Y;
        Z = normalized.Z;
        W = normalized.W;
    }

    public static Vector4 operator +(Vector4 vector, Vector4 other)
    {
        return vector.Add(other);
    }

    public static Vector4 operator -(Vector4 vector, Vector4 other)
    {
        return vector.Subtract(other);
    }

    public static Vector4 operator *(Vector4 vector, float scalar)
    {
        return vector.Scale(scalar);
    }

    public static Vector4 operator /(Vector4 vector, float scalar)
    {
        return vector.Scale(1f / scalar);
    }

    public override string ToString()
    {
        return $"({X}, {Y}, {Z}, {W})";
    }
}