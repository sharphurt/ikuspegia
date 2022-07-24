namespace VectorMath.Math.Vector;

public class Vector2
{
    public static Vector2 UnitX => new Vector2(1, 0);
    public static Vector2 UnitY => new Vector2(0, 1);

    public static Vector2 Zero => new Vector2(0, 0);

    public float X { get; set; }
    public float Y { get; set; }

    public float SqrMagnitude => X * X + Y * Y;

    public float Magnitude => MathF.Sqrt(SqrMagnitude);

    public Vector2 Normalized
    {
        get
        {
            if (SqrMagnitude > 1e-5)
            {
                return this / Magnitude;
            }

            return Zero;
        }
    }

    public Vector2(float x, float y)
    {
        X = x;
        Y = y;
    }

    public Vector2 Add(Vector2 other)
    {
        return new Vector2(X + other.X, Y + other.Y);
    }

    public Vector2 Subtract(Vector2 other)
    {
        return new Vector2(X - other.X, Y - other.Y);
    }

    public Vector2 Scale(float scalar)
    {
        return new Vector2(X * scalar, Y * scalar);
    }

    public float Dot(Vector2 other)
    {
        return X * other.X + Y * other.Y;
    }

    public void Normalize()
    {
        var normalized = Normalized;
        X = normalized.X;
        Y = normalized.Y;
    }

    public float Distance(Vector2 other)
    {
        var diff = this.Subtract(other);
        return MathF.Sqrt(diff.X * diff.X + diff.Y * diff.Y);
    }

    public static Vector2 operator +(Vector2 vector, Vector2 other)
    {
        return vector.Add(other);
    }

    public static Vector2 operator -(Vector2 vector, Vector2 other)
    {
        return vector.Subtract(other);
    }

    public static Vector2 operator *(Vector2 vector, float scalar)
    {
        return vector.Scale(scalar);
    }

    public static Vector2 operator /(Vector2 vector, float scalar)
    {
        return vector.Scale(1f / scalar);
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}