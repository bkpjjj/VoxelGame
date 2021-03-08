using System;
using System.Collections.Generic;
using System.Text;
using VoxelGame.Engine.ECS;
using VoxelGame.Engine.ECS.Systems;
using VoxelGame.Engine.Resources;

namespace VoxelGame.Engine.Scenes
{
    abstract class Scene
    {
        public static AssetPool Content { get; private set; } = new AssetPool();
        public Context Context { get; private set; } = new Context();
        public abstract void OnLoadContent();
        public abstract void OnConfigure();
        public abstract void BuildEntitis();
        public void Load()
        {
            OnLoadContent();
            OnConfigure();
            BuildEntitis();
            InitSystems();
        }
        public void InitSystems()
        {
            foreach (ECSSystem system in Context.GetSystems())
            {
                system.Init();
            }
        }
        public void UpdateSystems(float dt)
        {
            foreach (ECSSystem system in Context.GetSystems())
            {
                system.Update(dt);
            }
        }
        public void DrawSystems(float dt)
        {
            foreach (ECSSystem system in Context.GetSystems())
            {
                system.Draw(dt);
            }
        }
    }
}
