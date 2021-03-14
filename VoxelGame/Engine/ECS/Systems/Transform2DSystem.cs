using Leopotam.Ecs;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;
using VoxelGame.Engine.ECS.Components;

namespace VoxelGame.Engine.ECS.Systems
{
    class Transform2DSystem : IEcsRunSystem
    {
        public EcsWorld _world = null;
        public EcsFilter<Transform2D> _filter = null;

        private void BuildModel(ref Transform2D t)
        {
            //t.Model = Matrix2.CreateRotation(t.Rotation);
            t.Model = Matrix2.CreateScale(t.Scale);
        }
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref Transform2D c = ref _filter.Get1(i);
                BuildModel(ref c);
            }
        }
    }
}
