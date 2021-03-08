using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;
using VoxelGame.Engine.ECS.Components;
using VoxelGame.Engine.ECS.Systems;
using VoxelGame.Engine.Graphics;
using VoxelGame.Engine.Graphics.Buffers;
using VoxelGame.Engine.Graphics.Geometry;
using VoxelGame.Engine.Graphics.Textures;
using VoxelGame.Engine.Scenes;
using VoxelGame.Game.Components;
using VoxelGame.Game.Materials;
using VoxelGame.Game.Systems;

namespace VoxelGame.Game.Scenes
{
    class TestScene : Scene
    {
        Random rand = new Random();
        public override void BuildEntitis()
        {
            /*var depth = Context.EntitiesPool.CreateEntity();
            Context.AddComponent<Transform>(depth.Id);
            var depth_cam = Context.AddComponent<Camera>(depth.Id);
            depth_cam.FrameBuffer = new FrameBuffer(Screen.Width, Screen.Height, OpenTK.Graphics.OpenGL.FramebufferAttachment.DepthAttachment);
            */
            var dp = Context.EntitiesPool.CreateEntity();
            var dp_t = Context.AddComponent<Transform>(dp.Id);
            var depth = Context.AddComponent<Camera>(dp.Id);
            depth.FrameBuffer = new FrameBuffer(1280, 720, OpenTK.Graphics.OpenGL.FramebufferAttachment.ColorAttachment0);
            

            var cam = Context.EntitiesPool.CreateEntity();
            Context.AddComponent<Camera>(cam.Id);//.FrameBuffer = new FrameBuffer(1280,720, OpenTK.Graphics.OpenGL.FramebufferAttachment.ColorAttachment0);
            var c_t = Context.AddComponent<Transform>(cam.Id);
            c_t.Position = new Vector3(0, 1, 2);
            c_t.Rotation = Vector3.UnitX * 180f;
            Context.AddComponent<Moveble>(cam.Id);
            Context.AddComponent<CameraView>(cam.Id);
            var cam_r = Context.AddComponent<MeshRenderer>(cam.Id);
            var cam_m = new StandartMaterial();
            cam_m.Main = Content.Textures.Find<Texture2D>("tenor");
            cam_r.Material = cam_m;
            cam_r.Mesh = new Mesh(OpenTK.Graphics.OpenGL.BufferUsageHint.StaticDraw);
            cam_r.Mesh.Positions.AddRange(new[]
            {
                new Vector3(-1,-1,0),
                new Vector3(1,-1,0),
                new Vector3(1,1,0),
                new Vector3(-1,1,0),
            });
            cam_r.Mesh.Normals.AddRange(new[]
            {
                new Vector3(0,0,1),
                new Vector3(0,0,1),
                new Vector3(0,0,1),
                new Vector3(0,0,1),
            });

            cam_r.Mesh.UVs.AddRange(new[]
            {
                new Vector2(0,0),
                new Vector2(1,0),
                new Vector2(1,1),
                new Vector2(0,1),
            });

            cam_r.Mesh.Indices.AddRange(new uint[]
            {
                0,1,2,
                2,3,0
            });


            var en = Context.EntitiesPool.CreateEntity();
            var t = Context.AddComponent<Transform>(en.Id);
            t.Position = Vector3.UnitY;
            t.Rotation = Vector3.UnitX * 180f;
            dp_t.SetParent(t);
            //Context.AddComponent<TestComponent>(en.Id);
            //t.Rotation += new Vector3(rand.Next(-20, 20), rand.Next(-20, 20), rand.Next(-20, 20));
            var r = Context.AddComponent<MeshRenderer>(en.Id);
            var mat = new TestMat();
            r.Material = mat;
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
            var floor = Context.EntitiesPool.CreateEntity();
            Context.AddComponent<Transform>(floor.Id).Scale = new Vector3(100,1,100);
            var floor_rend = Context.AddComponent<MeshRenderer>(floor.Id);
            floor_rend.Material = new StandartMaterial() { Main = Content.Textures.Find<Texture2D>("grass") };
            floor_rend.Mesh = new Mesh(OpenTK.Graphics.OpenGL.BufferUsageHint.StaticDraw);
            floor_rend.Mesh.Positions.AddRange(new[] {
                new Vector3(-1,0,-1),
                new Vector3( 1,0,-1),
                new Vector3( 1,0, 1),
                new Vector3(-1,0, 1),
            });
            floor_rend.Mesh.Normals.AddRange(new[] {
                new Vector3(0,1,0),
                new Vector3(0,1,0),
                new Vector3(0,1,0),
                new Vector3(0,1,0),
            });

            floor_rend.Mesh.UVs.AddRange(new[]
            {
                new Vector2(0 ,   0),
                new Vector2(100,  0),
                new Vector2(100,100),
                new Vector2(100,  0),
            });
            floor_rend.Mesh.Indices.AddRange(new uint[]
            {
                0,1,2,
                2,3,0
            });
        }


        public override void OnConfigure()
        {
            Context.AddComponentsPool<MeshRenderer>();
            Context.AddComponentsPool<Transform>();
            Context.AddComponentsPool<TestComponent>();
            Context.AddComponentsPool<Moveble>();
            Context.AddComponentsPool<CameraView>();
            Context.AddComponentsPool<Camera>();
            Context.AddSystem<TransformSystem>();
            Context.AddSystem<CameraSystem>();
            Context.AddSystem<CameraViewSystem>();
            Context.AddSystem<MoveSystem>();
            Context.AddSystem<DrawSystem>();
            Context.AddSystem<TestSystem>();
        }

        public override void OnLoadContent()
        {
            Content.Shaders.Load("Standart");
            Content.Textures.Load("tenor");
            Content.Textures.Load("grass");
        }
    }
}
