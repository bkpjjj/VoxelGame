using Leopotam.Ecs;
using VoxelGame.Engine.Resources;

namespace VoxelGame.Engine.Scenes
{
    abstract class Scene
    {
        protected EcsWorld EcsWorld { get; set; }
        private EcsSystems ecsupdateSystems;
        private EcsSystems ecsdrawSystems;

        protected Scene()
        {
            EcsWorld = new EcsWorld();
            ecsupdateSystems = new EcsSystems(EcsWorld);
            ecsdrawSystems = new EcsSystems(EcsWorld);
        }

        public static AssetPool Content { get; private set; } = new AssetPool();
        public abstract void OnLoadContent();
        public abstract void OnConfigureUpdate(EcsSystems systems);
        public abstract void OnConfigureDraw(EcsSystems systems);
        public abstract void BuildEntitis();
        public void Load()
        {
            OnLoadContent();
            OnConfigureUpdate(ecsupdateSystems);
            OnConfigureDraw(ecsupdateSystems);
            BuildEntitis();
            InitSystems();
        }
        public void InitSystems()
        {
            ecsupdateSystems.Init();
            ecsdrawSystems.Init();
        }
        public void UpdateSystems()
        {
            ecsupdateSystems.Run();
        }
        public void DrawSystems()
        {
            ecsdrawSystems.Run();
        }
    }
}
