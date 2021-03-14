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
using VoxelGame.Game.Components;
using VoxelGame.Game.Materials;
using VoxelGame.Game.Systems;
using Newtonsoft.Json;
using VoxelGame.Engine.Debugging;

namespace VoxelGame.Game.Scenes
{
    class TestScene : Scene
    {
        public override void BuildEntitis()
        {
            var cam_en = EcsWorld.NewEntity();
            cam_en.Get<Movable>();
            cam_en.Get<CameraView>();
            cam_en.Get<Transform>();
            ref Camera cam = ref cam_en.Get<Camera>();
            cam.FOV = MathHelper.DegreesToRadians(60);
            cam.Near = 0.03f;
            cam.Far = 1000f;

            var en = EcsWorld.NewEntity();
            ref Transform t = ref en.Get<Transform>();
            t.Position = new Vector3(0f,1f,-1f);
            t.Scale = Vector3.One;
            ref MeshRenderer r = ref en.Get<MeshRenderer>();
            r.Material = new StandartMaterial() { Main = Scene.Content.Textures.Find<Texture2D>("tenor") };
            r.Mesh = new Mesh(OpenTK.Graphics.OpenGL.BufferUsageHint.StaticDraw);
            r.Mesh.Positions.AddRange(new[]
            {
                new Vector3(-1,-1,0),
                new Vector3(1,-1,0),
                new Vector3(1,1,0),
                new Vector3(-1,1,0),
            });
            r.Mesh.Normals.AddRange(new[]
            {
                new Vector3(0,0,1),
                new Vector3(0,0,1),
                new Vector3(0,0,1),
                new Vector3(0,0,1),
            });

            r.Mesh.UVs.AddRange(new[]
            {
                new Vector2(0,0),
                new Vector2(1,0),
                new Vector2(1,1),
                new Vector2(0,1),
            });

            r.Mesh.Indices.AddRange(new uint[]
            {
                0,1,2,
                2,3,0
            });

            //Floor
            var floor_en = EcsWorld.NewEntity();
            ref Transform floor_t = ref floor_en.Get<Transform>();
            floor_t.Position = new Vector3(0f, 0f, 0f);
            floor_t.Scale = Vector3.One * 100f;
            ref MeshRenderer floor_r = ref floor_en.Get<MeshRenderer>();
            floor_r.Material = new StandartMaterial() { Main = Scene.Content.Textures.Find<Texture2D>("grass") };
            floor_r.Mesh = new Mesh(OpenTK.Graphics.OpenGL.BufferUsageHint.StaticDraw);
            floor_r.Mesh.Positions.AddRange(new[]
            {
                new Vector3(-1,0,-1),
                new Vector3( 1,0,-1),
                new Vector3( 1,0, 1),
                new Vector3(-1,0, 1),
            });
            floor_r.Mesh.Normals.AddRange(new[]
            {
                new Vector3(0,0,1),
                new Vector3(0,0,1),
                new Vector3(0,0,1),
                new Vector3(0,0,1),
            });

            floor_r.Mesh.UVs.AddRange(new[]
            {
                new Vector2(0,0),
                new Vector2(100,0),
                new Vector2(100,100),
                new Vector2(0,100),
            });

            floor_r.Mesh.Indices.AddRange(new uint[]
            {
                0,1,2,
                2,3,0
            });
            //

            var text_en = EcsWorld.NewEntity();
            ref Transform2D tr = ref text_en.Get<Transform2D>();
            tr.Scale = Vector2.One * 0.2f;
            ref TextRenderer text = ref text_en.Get<TextRenderer>();
            text.Text = "";
            text.Font = Content.Fonts.Find("Arial");
            text.Material = new FontMaterial() { Font = Content.Textures.Find<Texture2D>("Fonts/Arial") };
            text_en.Get<FpsShowComponent>();
        }

        public override void ConfigureRenderPipeline(EcsSystems pipeline)
        {
#if DEBUG
            EcsWorld.AddDebugListener(new TestSceneDebugListener()); 
#endif
            pipeline.Add(new MeshRendererSystem());
            pipeline.Add(new TextRendererSystem());
        }

        public override void OnConfigureUpdate(EcsSystems systems)
        {
            systems.Add(new TransformSystem());
            systems.Add(new Transform2DSystem());
            systems.Add(new CameraSystem());
            systems.Add(new MoveSystem());
            systems.Add(new CameraViewSystem());
            systems.Add(new FpsShowSystem());
        }

        public override void OnLoadContent()
        {
            Content.Shaders.Load("Standart");
            Content.Shaders.Load("Font");
            Content.Textures.Load("tenor");
            Content.Textures.Load("grass");
            Content.Fonts.Load("Arial");
        }
    }
}
