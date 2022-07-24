using VectorMath.Math.Vector;

namespace VectorMath.Math.Matrix;

public class Matrix4
{
    public static Matrix4 Identity = new Matrix4(
        1, 0, 0, 0,
        0, 1, 0, 0,
        0, 0, 1, 0,
        0, 0, 0, 1);

    public static Matrix4 Zeros = new Matrix4(0);

    public float M11 { get; set; }
    public float M12 { get; set; }
    public float M13 { get; set; }
    public float M14 { get; set; }
    public float M21 { get; set; }
    public float M22 { get; set; }
    public float M23 { get; set; }
    public float M24 { get; set; }
    public float M31 { get; set; }
    public float M32 { get; set; }
    public float M33 { get; set; }
    public float M34 { get; set; }
    public float M41 { get; set; }
    public float M42 { get; set; }
    public float M43 { get; set; }
    public float M44 { get; set; }


    public Matrix4(
        float m11, float m12, float m13, float m14,
        float m21, float m22, float m23, float m24,
        float m31, float m32, float m33, float m34,
        float m41, float m42, float m43, float m44)
    {
        M11 = m11;
        M12 = m12;
        M13 = m13;
        M14 = m14;
        M21 = m21;
        M22 = m22;
        M23 = m23;
        M24 = m24;
        M31 = m31;
        M32 = m32;
        M33 = m33;
        M34 = m34;
        M41 = m41;
        M42 = m42;
        M43 = m43;
        M44 = m44;
    }

    public Matrix4(float value)
    {
        M11 = value;
        M12 = value;
        M13 = value;
        M14 = value;
        M21 = value;
        M22 = value;
        M23 = value;
        M24 = value;
        M31 = value;
        M32 = value;
        M33 = value;
        M34 = value;
        M41 = value;
        M42 = value;
        M43 = value;
        M44 = value;
    }

    public Matrix4(Matrix4 matrix4)
    {
        M11 = matrix4.M11;
        M12 = matrix4.M12;
        M13 = matrix4.M13;
        M14 = matrix4.M14;
        M21 = matrix4.M21;
        M22 = matrix4.M22;
        M23 = matrix4.M23;
        M24 = matrix4.M24;
        M31 = matrix4.M31;
        M32 = matrix4.M32;
        M33 = matrix4.M33;
        M34 = matrix4.M34;
        M41 = matrix4.M41;
        M42 = matrix4.M42;
        M43 = matrix4.M43;
        M44 = matrix4.M44;
    }

    public override string ToString()
    {
        return
            "{" +
            $"[{M11}, {M12}, {M13}, {M14}]\n[{M21}, {M22}, {M23}, {M24}]\n[{M31}, {M32}, {M33}, {M34}]\n[{M41}, {M42}, {M43}, {M44}]" +
            "}";
    }

    public static Matrix4 CreateTranslate(Vector3 delta)
    {
        var m = Identity;
        m.M14 = delta.X;
        m.M24 = delta.Y;
        m.M34 = delta.Z;

        return m;
    }

    public Matrix4 Translate(Vector3 delta)
    {
        return this * CreateTranslate(delta);
    }

    public static Matrix4 CreateScale(Vector3 factor)
    {
        var m = Zeros;
        m.M11 = factor.X;
        m.M22 = factor.Y;
        m.M33 = factor.Z;
        m.M44 = 1;

        return m;
    }

    public Matrix4 Scale(Vector3 factor)
    {
        return this * CreateScale(factor);
    }

    public static Matrix4 CreateRotationX(float radians)
    {
        return new Matrix4(
            1, 0, 0, 0,
            0, MathF.Cos(radians), -MathF.Sin(radians), 0,
            0, MathF.Sin(radians), MathF.Cos(radians), 0,
            0, 0, 0, 1);
    }

    public Matrix4 RotateX(float radians)
    {
        return this * CreateRotationX(radians);
    }

    public static Matrix4 CreateRotationY(float radians)
    {
        return new Matrix4(
            MathF.Cos(radians), 0, MathF.Sin(radians), 0,
            0, 1, 0, 0,
            -MathF.Sin(radians), 0, MathF.Cos(radians), 0,
            0, 0, 0, 1);
    }

    public Matrix4 RotateY(float radians)
    {
        return this * CreateRotationY(radians);
    }

    public static Matrix4 CreateRotationZ(float radians)
    {
        return new Matrix4(
            MathF.Cos(radians), -MathF.Sin(radians), 0, 0,
            MathF.Sin(radians), MathF.Cos(radians), 0, 0,
            0, 0, 1, 0,
            0, 0, 0, 1);
    }

    public Matrix4 RotateZ(float radians)
    {
        return this * CreateRotationZ(radians);
    }

    public static Matrix4 CreateEuler(float pitch, float yaw, float roll)
    {
        var x = CreateRotationX(pitch);
        var y = CreateRotationY(yaw);
        var z = CreateRotationZ(roll);

        return z * y * x;
    }

    public static Matrix4 CreatePerspectiveProjection(float fov, float aspectRatio, float zNear, float zFar)
    {
        var tan = MathF.Tan(fov * 0.5f * MathF.PI / 180);

        return new Matrix4(
            1 / (tan * aspectRatio), 0, 0, 0,
            0, 1 / tan, 0, 0,
            0, 0, -zFar / (zFar - zNear), -1,
            0, 0, -(zFar * zNear) / (zFar - zNear), 0);
    }

    public static Matrix4 CreateScreenSpaceMatrix(float width, float height)
    {
        return new Matrix4(
            -0.5f * width, 0, 0, 0.5f * width,
            0, -0.5f * height, 0, 0.5f * height,
            0, 0, 1, 0,
            0, 0, 0, 1);
    }

    public static Matrix4 CreateLookAtViewMatrix(Vector3 position, Vector3 lookAt, Vector3 up)
    {
        var z = (position - lookAt).Normalized; // The "forward" vector.
        var x = up.Cross(z).Normalized; // The "right" vector.
        var y = z.Cross(x); // The "up" vector.
        return new Matrix4(
            x.X, x.Y, x.Z, -x.Dot(position),
            y.X, y.Y, y.Z, -y.Dot(position),
            z.X, z.Y, z.Z, -z.Dot(position),
            0, 0, 0, 1);
    }

    public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
    {
        return new Matrix4(
            lhs.M11 * rhs.M11 + lhs.M12 * rhs.M21 + lhs.M13 * rhs.M31,
            lhs.M11 * rhs.M12 + lhs.M12 * rhs.M22 + lhs.M13 * rhs.M32,
            lhs.M11 * rhs.M13 + lhs.M12 * rhs.M23 + lhs.M13 * rhs.M33,
            lhs.M11 * rhs.M14 + lhs.M12 * rhs.M24 + lhs.M13 * rhs.M34,
            
            lhs.M21 * rhs.M11 + lhs.M22 * rhs.M21 + lhs.M23 * rhs.M31,
            lhs.M21 * rhs.M12 + lhs.M22 * rhs.M22 + lhs.M23 * rhs.M32,
            lhs.M21 * rhs.M13 + lhs.M22 * rhs.M23 + lhs.M23 * rhs.M33,
            lhs.M21 * rhs.M14 + lhs.M22 * rhs.M24 + lhs.M23 * rhs.M34,
            
            lhs.M31 * rhs.M11 + lhs.M32 * rhs.M21 + lhs.M33 * rhs.M31,
            lhs.M31 * rhs.M12 + lhs.M32 * rhs.M22 + lhs.M33 * rhs.M32,
            lhs.M31 * rhs.M13 + lhs.M32 * rhs.M23 + lhs.M33 * rhs.M33,
            lhs.M31 * rhs.M14 + lhs.M32 * rhs.M24 + lhs.M33 * rhs.M34,
            
            lhs.M41 * rhs.M11 + lhs.M42 * rhs.M21 + lhs.M43 * rhs.M31,
            lhs.M41 * rhs.M12 + lhs.M42 * rhs.M22 + lhs.M43 * rhs.M32,
            lhs.M41 * rhs.M13 + lhs.M42 * rhs.M23 + lhs.M43 * rhs.M33,
            lhs.M41 * rhs.M14 + lhs.M42 * rhs.M24 + lhs.M43 * rhs.M34);
    }

    public static Vector4 operator *(Matrix4 lhs, Vector4 rhs)
    {
        return new Vector4(
            lhs.M11 * rhs.X + lhs.M12 * rhs.Y + lhs.M13 * rhs.Z,
            lhs.M21 * rhs.X + lhs.M22 * rhs.Y + lhs.M23 * rhs.Z,
            lhs.M31 * rhs.X + lhs.M32 * rhs.Y + lhs.M33 * rhs.Z,
            lhs.M41 * rhs.X + lhs.M42 * rhs.Y + lhs.M43 * rhs.Z);
    }
}