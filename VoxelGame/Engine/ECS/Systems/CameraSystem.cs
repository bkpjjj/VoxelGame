using Leopotam.Ecs;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;
using VoxelGame.Engine.ECS.Components;
using VoxelGame.Engine.Graphics;

namespace VoxelGame.Engine.ECS.Systems
{
    class CameraSystem : IEcsRunSystem
    {
        public EcsFilter<Camera,Transform> _filter = null;
        private void BuildProjMatrix(ref Camera cam)
        {
             cam.Projection = Matrix4.CreatePerspectiveFieldOfView(cam.FOV, (float)Screen.Width / Screen.Height, cam.Near, cam.Far);
        }
        private void BuildOthroMatrix(ref Camera cam)
        {
            cam.Othro = Matrix4.CreateOrthographicOffCenter(0f, 1f, 0f, 1f, -5f, 5f);
        }
        private void BuildViewMatrix(ref Camera cam,ref Transform transform)
        {
            Matrix4 x = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(-transform.Rotation.Y));
            Matrix4 y = Matrix4.CreateRotationY(MathHelper.DegreesToRadians(-transform.Rotation.X));

            Matrix4 t = Matrix4.CreateTranslation(-transform.Position);
            cam.View = t * y * x;
        }
        public void Run()
        {
            foreach (int i in _filter)
            {
                ref Camera cam = ref _filter.Get1(i);
                ref Transform t = ref _filter.Get2(i);
                BuildProjMatrix(ref cam);
                BuildViewMatrix(ref cam, ref t);
                BuildOthroMatrix(ref cam);
            }
        }
    }
}
