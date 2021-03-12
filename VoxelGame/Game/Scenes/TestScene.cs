using Leopotam.Ecs;
using OpenTK.Mathematics;
using System;
using VoxelGame.Engine.ECS.Components;
using VoxelGame.Engine.ECS.Systems;
using VoxelGame.Engine.ECS.Systems.RenderPipeline;
using VoxelGame.Engine.Graphics.Buffers;
using VoxelGame.Engine.Graphics.Geometry;
using VoxelGame.Engine.Graphics.Textures;
using VoxelGame.Engine.Scenes;
using VoxelGame.Game.Materials;

namespace VoxelGame.Game.Scenes
{
    class TestScene : Scene
    {
        public override void BuildEntitis()
        {
            var en = EcsWorld.NewEntity();
            ref Transform t = ref en.Get<Transform>();
            t.Position = new Vector3(1);
            ref MeshRenderer r = ref en.Get<MeshRenderer>();
            r.Material = new StandartMaterial() { Main = Scene.Content.Textures.Find<Texture2D>("tenor") };
            r.Mesh = new Mesh(OpenTK.Graphics.OpenGL.BufferUsageHint.StaticDraw);
            r.Mesh.Positions.AddRange(new[]
            {
                new Vector3(0,0,0),
                new Vector3(1,0,0),
                new Vector3(1,1,0),
            });
            r.Mesh.Normals.AddRange(new[]
            {
                new Vector3(0,0,1),
                new Vector3(0,0,1),
                new Vector3(0,0,1),
            });
            r.Mesh.UVs.AddRange(new[]
            {
                new Vector2(0,0),
                new Vector2(1,0),
                new Vector2(1,1),
            });
            r.Mesh.Indices.AddRange(new uint[]
            {
                0,1,2
            });
        }

        public override void ConfigureRenderPipeline(EcsSystems pipeline)
        {
#if DEBUG
            EcsWorld.AddDebugListener(new TestSceneDebugListener()); 
#endif
            pipeline.Add(new MeshRendererSystem());
        }

        public override void OnConfigureUpdate(EcsSystems systems)
        {
            systems.Add(new TransformSystem());
        }

        public override void OnLoadContent()
        {
            Content.Shaders.Load("Standart");
            Content.Textures.Load("tenor");
        }
    }
}
