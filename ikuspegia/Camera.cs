using VectorMath.Math;
using VectorMath.Math.Matrix;
using VectorMath.Math.Vector;

namespace VectorMath;

public class Camera
{
    public Vector2 Size { get; }

    public Vector3 Position { get; }

    public Vector3 LookAt { get; }

    public Matrix4 Projection { get; }

    public Matrix4 View { get; }
    
    public Camera(int width, int height, Vector3 position, Vector3 lookAt, float fov, float zNear, float zFar)
    {
        Size = new Vector2(width, height);
        Position = position;
        LookAt = lookAt;

        var screenSpace = Matrix4.CreateScreenSpaceMatrix(width, height);
        var perspectiveProjection = Matrix4.CreatePerspectiveProjection(fov, (float)width / height, zNear, zFar);
        Projection = screenSpace * perspectiveProjection;
        
        View = Matrix4.CreateLookAtViewMatrix(position, lookAt, Vector3.UnitY);
    }
    
}