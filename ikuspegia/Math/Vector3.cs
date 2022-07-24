namespace VectorMath.Math;

public class Vector3
{
    public static Vector3 UnitX => new Vector3(1, 0, 0);
    public static Vector3 UnitY => new Vector3(0, 1, 0);
    public static Vector3 UnitZ => new Vector3(0, 0, 1);

    public static Vector3 Zero => new Vector3(0, 0, 0);

    public static Vector3 One => new Vector3(1, 1, 1);

    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public float Magnitude => MathF.Sqrt(SqrMagnitude);

    public float SqrMagnitude => X * X + Y * Y + Z * Z;

    public Vector3 Normalized
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

    public Vector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public Vector3 Add(Vector3 other)
    {
        return new Vector3(X + other.X, Y + other.Y, Z + other.Z);
    }

    public Vector3 Subtract(Vector3 other)
    {
        return new Vector3(X - other.X, Y - other.Y, Z - other.Z);
    }

    public Vector3 Scale(float scalar)
    {
        return new Vector3(X * scalar, Y * scalar, Z * scalar);
    }

    public float Dot(Vector3 other)
    {
        return X * other.X + Y * other.Y + Z * other.Z;
    }

    public Vector3 Cross(Vector3 other)
    {
        var cx = (Y * other.Z) - (Z * other.Y);
        var cy = (Z * other.X) - (Z * other.Z);
        var cz = (X * other.Y) - (Y * other.X);

        return new Vector3(cx, cy, cz);
    }

    public void Normalize()
    {
        var normalized = Normalized;
        X = normalized.X;
        Y = normalized.Y;
        Z = normalized.Z;
    }

    public float Distance(Vector3 other)
    {
        var diff = this.Subtract(other);
        return MathF.Sqrt(diff.X * diff.X + diff.Y * diff.Y + diff.Z * diff.Z);
    }

    public float GetAngle(Vector3 other)
    {
        var a = this.Normalized;
        var b = other.Normalized;
        return MathF.Acos(a.Dot(b));
    }


    public static Vector3 operator +(Vector3 vector, Vector3 other)
    {
        return vector.Add(other);
    }

    public static Vector3 operator -(Vector3 vector, Vector3 other)
    {
        return vector.Subtract(other);
    }

    public static Vector3 operator *(Vector3 vector, float scalar)
    {
        return vector.Scale(scalar);
    }

    public static Vector3 operator /(Vector3 vector, float scalar)
    {
        return vector.Scale(1f / scalar);
    }

    public override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }
}