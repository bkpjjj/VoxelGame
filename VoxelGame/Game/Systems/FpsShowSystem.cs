using Leopotam.Ecs;
using System;
using System.Collections.Generic;
using System.Text;
using VoxelGame.Engine;
using VoxelGame.Engine.ECS.Components;
using VoxelGame.Game.Components;

namespace VoxelGame.Game.Systems
{
    class FpsShowSystem : IEcsRunSystem
    {
        private EcsFilter<FpsShowComponent, TextRenderer> _filter = null;
        public void Run()
        {
            foreach (int i in _filter)
            {
                ref TextRenderer r = ref _filter.Get2(i);

                r.Text = " Fps:" + (1f / Time.DeltaTime).ToString("0000") + " Update:" + Time.DeltaTime.ToString("0.0000 ms");
            }
        }
    }
}
