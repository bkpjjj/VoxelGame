using Leopotam.Ecs;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;
using VoxelGame.Engine.ECS.Components;
using VoxelGame.Engine.Inputs;

namespace VoxelGame.Game.Systems
{
    class CameraViewSystem : IEcsRunSystem
    {
        private EcsFilter<Camera, Transform> _filter = null;

        float prFov = 0;
        float pow = 0;
        public void Run()
        {
            foreach (int i in _filter)
            {
                ref Transform t = ref _filter.Get2(i);
                ref Camera c = ref _filter.Get1(i);

                if(!Input.Mouse.WasButtonDown(OpenTK.Windowing.GraphicsLibraryFramework.MouseButton.Button2))
                {
                    prFov = c.FOV;
                    pow = 1;
                }

                if(Input.Mouse.IsButtonDown(OpenTK.Windowing.GraphicsLibraryFramework.MouseButton.Button2))
                {
                    pow += 0.01f;
                    pow = MathHelper.Min(pow, 2f);
                    c.FOV -= (float)MathHelper.Pow(MathHelper.DegreesToRadians(1), pow);
                    c.FOV = MathHelper.Max(c.FOV, 0.5f);
                }
                else
                {
                    c.FOV = prFov;
                }

                t.Rotation += new Vector3(Input.MouseDelta * 0.25f);
                t.Rotation = Vector3.Clamp(t.Rotation, new Vector3(-360, -60, 0), new Vector3(360, 60, 0));
            }
        }
    }
}
