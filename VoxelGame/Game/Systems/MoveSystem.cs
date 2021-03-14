using Leopotam.Ecs;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Text;
using VoxelGame.Engine;
using VoxelGame.Engine.Debugging;
using VoxelGame.Engine.ECS.Components;
using VoxelGame.Engine.Inputs;
using VoxelGame.Game.Components;

namespace VoxelGame.Game.Systems
{
    class MoveSystem : IEcsRunSystem
    {
        EcsFilter<Transform, Movable> _filter = null;
        public Vector3 TranslateTowards(in Transform t, Vector3 pos)
        {
            return Vector3.TransformPosition(pos, t.RotationMatrix);
        }

        float speedMul = 1f;

        public void Run()
        {
            speedMul = 1f;

            foreach (int i in _filter)
            {
                ref Transform t = ref _filter.Get1(i);

                if (Input.KeyboardState.IsKeyDown(Keys.LeftShift))
                    speedMul *= 5;
                if (Input.KeyboardState.IsKeyDown(Keys.A))
                {
                    t.Position -= TranslateTowards(t, Vector3.UnitX * speedMul * Time.DeltaTime);
                }
                if (Input.KeyboardState.IsKeyDown(Keys.D))
                {
                    t.Position += TranslateTowards(t, Vector3.UnitX * speedMul * Time.DeltaTime);
                }
                if (Input.KeyboardState.IsKeyDown(Keys.W))
                {
                    t.Position -= TranslateTowards(t, Vector3.UnitZ * speedMul * Time.DeltaTime);
                }
                if (Input.KeyboardState.IsKeyDown(Keys.S))
                {
                    t.Position += TranslateTowards(t, Vector3.UnitZ * speedMul * Time.DeltaTime);
                }
            }
        }
    }
}
