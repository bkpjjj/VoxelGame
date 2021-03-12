using Leopotam.Ecs;
using System;
using System.Collections.Generic;
using System.Text;
using VoxelGame.Engine.Debugging;

namespace VoxelGame.Game.Scenes
{
#if DEBUG
    class TestSceneDebugListener : IEcsWorldDebugListener
    {
        public void OnComponentListChanged(EcsEntity entity)
        {
            Debug.Info(entity.ToString(), this);
        }

        public void OnEntityCreated(EcsEntity entity)
        {
            Debug.Info(entity.ToString(), this);
        }

        public void OnEntityDestroyed(EcsEntity entity)
        {
            Debug.Info(entity.ToString(), this);
        }

        public void OnFilterCreated(EcsFilter filter)
        {
            Debug.Info(filter.ToString(), this);
        }

        public void OnWorldDestroyed(EcsWorld world)
        {
        }
    }
#endif
}
