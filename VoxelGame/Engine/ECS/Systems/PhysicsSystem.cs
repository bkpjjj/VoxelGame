using Leopotam.Ecs;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;
using VoxelGame.Engine.Debugging;
using VoxelGame.Engine.ECS.Components;

namespace VoxelGame.Engine.ECS.Systems
{
    class PhysicsSystem : IEcsRunSystem
    {
        EcsFilter<BoxCollider, Transform> _filter;
        public void Run()
        {
            foreach (int i in _filter)
            {
                ref BoxCollider box = ref _filter.Get1(i);
                ref Transform t = ref _filter.Get2(i);

                box.Shape.Center = t.Position;

                //Debug.Info(box.Shape.ToString(),this);
            }

            foreach (int i in _filter)
            {
                ref BoxCollider box = ref _filter.Get1(i);
                ref Transform t = ref _filter.Get2(i);

                foreach (int j in _filter)
                {
                    if (i == j)
                        continue;

                    ref BoxCollider other = ref _filter.Get1(j);
                    ref Transform o_t = ref _filter.Get2(j);

                    if (box.Shape.Contains(other.Shape))
                    {
                        box.isCollide = true;
                        //Debug.Info(point.ToString(), this);

                        if (!box.isStatic)
                            t.Position += (t.Position - o_t.Position) * Time.DeltaTime;
                    }
                    else
                    {
                        box.isCollide = false;
                    }
                }
            }
        }
    }
}
