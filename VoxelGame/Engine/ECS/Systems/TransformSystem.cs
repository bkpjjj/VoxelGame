using Leopotam.Ecs;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VoxelGame.Engine.ECS.Components;

namespace VoxelGame.Engine.ECS.Systems
{
    class TransformSystem : IEcsRunSystem
    {
        public EcsWorld _world = null;
        public EcsFilter<Transform> _filter = null;

        public Queue<Thread> threads = new Queue<Thread>();
        public int thread_count = 1;

        private void BuildRotation(ref Transform t)
        {
            t.RotationMatrix = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(t.Rotation.Z));
            t.RotationMatrix *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(t.Rotation.Y));
            t.RotationMatrix *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(t.Rotation.X));
        }
        private void BuildModel(ref Transform t)
        {
            t.Model = t.RotationMatrix;
            t.Model = Matrix4.CreateScale(t.Scale);
            t.Model *= Matrix4.CreateTranslation(t.Position);
        }
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref Transform c = ref _filter.Get1(i);
                BuildRotation(ref c);
                BuildModel(ref c);
            }
        }
    }
}
