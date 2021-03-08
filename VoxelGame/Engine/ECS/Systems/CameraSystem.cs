using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;
using VoxelGame.Engine.ECS.Components;

namespace VoxelGame.Engine.ECS.Systems
{
    class CameraSystem : ECSSystem
    {
        IEnumerable<Camera> cameras;

        public CameraSystem(Context context) : base(context)
        {
            cameras = Context.GetComponents<Camera>();
        }

        public override void Draw(float dt)
        {
        }

        public override void Init()
        {
        }

        private Matrix4 BuildProjMatrix(Camera cam)
        {
            return Matrix4.CreatePerspectiveFieldOfView(cam.FOV, (float)cam.Width / cam.Height, cam.Near, cam.Far);
        }
        private Matrix4 BuildViewMatrix(Transform transform)
        {
            Matrix4 x = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(-transform.Rotation.Y));
            Matrix4 y = Matrix4.CreateRotationY(MathHelper.DegreesToRadians(-transform.Rotation.X));

            Matrix4 t = Matrix4.CreateTranslation(-transform.Position);
            return t * y * x;
        }
        public override void Update(float dt)
        {
            foreach (Camera camera in cameras)
            {
                camera.Projection = BuildProjMatrix(camera);
                camera.View = BuildViewMatrix(Context.GetComponent<Transform>(camera.EntityId));
            }
        }
    }
}
