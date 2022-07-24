namespace VectorMath.Math;

public class Matrix3
{
    public static Matrix3 Identity = new Matrix3(
        1, 0, 0,
        0, 1, 0,
        0, 0, 1);

    public static Matrix3 Zeros = new Matrix3(0);

    public float M11 { get; set; }
    public float M12 { get; set; }
    public float M13 { get; set; }
    public float M21 { get; set; }
    public float M22 { get; set; }
    public float M23 { get; set; }
    public float M31 { get; set; }
    public float M32 { get; set; }
    public float M33 { get; set; }

    public Matrix3(float m11, float m12, float m13, float m21, float m22, float m23, float m31, float m32, float m33)
    {
        M11 = m11;
        M12 = m12;
        M13 = m13;
        M21 = m21;
        M22 = m22;
        M23 = m23;
        M31 = m31;
        M32 = m32;
        M33 = m33;
    }

    public Matrix3(float value)
    {
        M11 = value;
        M12 = value;
        M13 = value;
        M21 = value;
        M22 = value;
        M23 = value;
        M31 = value;
        M32 = value;
        M33 = value;
    }

    public Matrix3(Matrix3 matrix3)
    {
        M11 = matrix3.M11;
        M12 = matrix3.M12;
        M13 = matrix3.M13;
        M21 = matrix3.M21;
        M22 = matrix3.M22;
        M23 = matrix3.M23;
        M31 = matrix3.M31;
        M32 = matrix3.M32;
        M33 = matrix3.M33;
    }

    public override string ToString()
    {
        return
            "{" +
            $"[{M11}, {M12}, {M13}]\n[{M21}, {M22}, {M23}]\n[{M31}, {M32}, {M33}]" +
            "}";
    }

    public static Matrix3 CreateScale(Vector3 v)
    {
        var m = Identity;
        m.M11 = v.X;
        m.M22 = v.Y;
        m.M33 = v.Z;

        return m;
    }

    public Matrix3 Scale(Vector3 v)
    {
        return this * CreateScale(v);
    }

    public static Matrix3 CreateRotationX(float radians)
    {
        return new Matrix3(
            1, 0, 0,
            0, MathF.Cos(radians), -MathF.Sin(radians),
            0, MathF.Sin(radians), MathF.Cos(radians));
    }

    public Matrix3 RotateX(float radians)
    {
        return this * CreateRotationX(radians);
    }

    public static Matrix3 CreateRotationY(float radians)
    {
        return new Matrix3(
            MathF.Cos(radians), 0, MathF.Sin(radians),
            0, 1, 0,
            -MathF.Sin(radians), 0, MathF.Cos(radians));
    }

    public Matrix3 RotateY(float radians)
    {
        return this * CreateRotationY(radians);
    }

    public static Matrix3 CreateRotationZ(float radians)
    {
        return new Matrix3(
            MathF.Cos(radians), -MathF.Sin(radians), 0,
            MathF.Sin(radians), MathF.Cos(radians), 0,
            0, 0, 1);
    }

    public Matrix3 RotateZ(float radians)
    {
        return this * CreateRotationZ(radians);
    }

    public static Matrix3 CreateEuler(float pitch, float yaw, float roll)
    {
        var x = CreateRotationX(pitch);
        var y = CreateRotationY(yaw);
        var z = CreateRotationZ(roll);

        return z * y * x;
    }

    public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
    {
        return new Matrix3(
            lhs.M11 * rhs.M11 + lhs.M12 * rhs.M21 + lhs.M13 * rhs.M31,
            lhs.M11 * rhs.M12 + lhs.M12 * rhs.M22 + lhs.M13 * rhs.M32,
            lhs.M11 * rhs.M13 + lhs.M12 * rhs.M23 + lhs.M13 * rhs.M33,
            lhs.M21 * rhs.M11 + lhs.M22 * rhs.M21 + lhs.M23 * rhs.M31,
            lhs.M21 * rhs.M12 + lhs.M22 * rhs.M22 + lhs.M23 * rhs.M32,
            lhs.M21 * rhs.M13 + lhs.M22 * rhs.M23 + lhs.M23 * rhs.M33,
            lhs.M31 * rhs.M11 + lhs.M32 * rhs.M21 + lhs.M33 * rhs.M31,
            lhs.M31 * rhs.M12 + lhs.M32 * rhs.M22 + lhs.M33 * rhs.M32,
            lhs.M31 * rhs.M13 + lhs.M32 * rhs.M23 + lhs.M33 * rhs.M33);
    }

    public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
    {
        return new Vector3(
            lhs.M11 * rhs.X + lhs.M12 * rhs.Y + lhs.M13 * rhs.Z,
            lhs.M21 * rhs.X + lhs.M22 * rhs.Y + lhs.M23 * rhs.Z,
            lhs.M31 * rhs.X + lhs.M32 * rhs.Y + lhs.M33 * rhs.Z);
    }
}