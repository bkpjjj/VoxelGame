using Leopotam.Ecs;
using VoxelGame.Engine.Resources;

namespace VoxelGame.Engine.Scenes
{
    abstract class Scene
    {
        protected EcsWorld EcsWorld { get; set; }
        private EcsSystems ecsupdateSystems;
        private EcsSystems renderPipeline;

        protected Scene()
        {
            EcsWorld = new EcsWorld();
            ecsupdateSystems = new EcsSystems(EcsWorld);
            renderPipeline = new EcsSystems(EcsWorld);
        }

        public static AssetPool Content { get; private set; } = new AssetPool();
        public abstract void OnLoadContent();
        public abstract void OnConfigureUpdate(EcsSystems systems);
        public abstract void ConfigureRenderPipeline(EcsSystems pipeline);
        public abstract void BuildEntitis();
        public void Load()
        {
            OnLoadContent();
            OnConfigureUpdate(ecsupdateSystems);
            ConfigureRenderPipeline(renderPipeline);
            ProcessInjects();
            BuildEntitis();
            InitSystems();
        }

        private void ProcessInjects()
        {
            ecsupdateSystems.ProcessInjects();
            renderPipeline.ProcessInjects();
        }

        public void InitSystems()
        {
            ecsupdateSystems.Init();
            renderPipeline.Init();
        }
        public void UpdateSystems()
        {
            ecsupdateSystems.Run();
        }
        public void DrawSystems()
        {
            renderPipeline.Run();
        }
        public void Destroy()
        {
            ecsupdateSystems.Destroy();
            renderPipeline.Destroy();
        }
    }
}
