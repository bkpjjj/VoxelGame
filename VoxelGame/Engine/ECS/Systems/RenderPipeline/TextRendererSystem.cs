using Leopotam.Ecs;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;
using VoxelGame.Engine.ECS.Components;
using static VoxelGame.Engine.Graphics.Text.Font;

namespace VoxelGame.Engine.ECS.Systems.RenderPipeline
{
    class TextRendererSystem : IEcsRunSystem,IEcsInitSystem
    {
        public EcsFilter<TextRenderer, Transform2D> _filter = null;
        public EcsFilter<Camera> _cameras = null;

        public void BuildMesh(ref TextRenderer r)
        {
            r.Mesh.Positions.Clear();
            r.Mesh.UVs.Clear();

            uint index = 0;
            float advance = 0;
            foreach (char c in r.Text)
            {
                r.Font.Characters.TryGetValue(c, out FontData data);

                float originX = data.OriginX / (float)r.Font.Width;
                float originY = data.OriginY / (float)r.Font.Height;
                float x = data.X;
                float y = data.Y;
                float width = data.Width;
                float height = data.Height;

                r.Mesh.Positions.AddRange(new[]
                {
                    new Vector2(advance - (data.Width / (float)r.Font.Width) + originX, -(data.Height / (float)r.Font.Height) + originY),
                    new Vector2(advance + (data.Width / (float)r.Font.Width) + originX, -(data.Height / (float)r.Font.Height) + originY),
                    new Vector2(advance + (data.Width / (float)r.Font.Width) + originX, (data.Height / (float)r.Font.Height) + originY),
                    new Vector2(advance + (data.Width / (float)r.Font.Width) + originX, (data.Height / (float)r.Font.Height) + originY),
                    new Vector2(advance - (data.Width / (float)r.Font.Width) + originX, (data.Height / (float)r.Font.Height) + originY),
                    new Vector2(advance - (data.Width / (float)r.Font.Width) + originX, -(data.Height / (float)r.Font.Height) + originY),
                });

                r.Mesh.UVs.AddRange(new[]
                {
                    new Vector2((x        ) / r.Font.Width,1.0f - ((y + height) / r.Font.Height)),
                    new Vector2((x + width) / r.Font.Width,1.0f - ((y + height) / r.Font.Height)),
                    new Vector2((x + width) / r.Font.Width,1.0f - (y + 0     )  / r.Font.Height),
                    new Vector2((x + width) / r.Font.Width,1.0f - (y + 0     )  / r.Font.Height),
                    new Vector2((x        ) / r.Font.Width,1.0f - (y + 0     )  / r.Font.Height),
                    new Vector2((x        ) / r.Font.Width,1.0f - ((y + height) / r.Font.Height)),
                });

                advance += data.Advance * 2f / r.Font.Width;
                index++;
            }

            r.Mesh.Upload();
        }

        public void Init()
        {
            foreach (var i in _filter)
            {
                ref TextRenderer r = ref _filter.Get1(i);
                r.Mesh = new Graphics.Geometry.UIMesh();
            }
        }

        public void Run()
        {
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            foreach (int camera_id in _cameras)
            {
                ref Camera camera = ref _cameras.Get1(camera_id);

                foreach (int i in _filter)
                {
                    ref TextRenderer renderer = ref _filter.Get1(i);
                    ref Transform2D transform = ref _filter.Get2(i);

                    BuildMesh(ref renderer);

                    renderer.Material.Shader.Use();
                    renderer.Material.Shader.SetMat2("MODEL", ref transform.Model);
                    renderer.Material.Shader.SetMat4("OTHRO", ref camera.Othro);
                    renderer.Material.Shader.SetVec2("POS", transform.Position);
                    renderer.Material.LoadParams();

                    renderer.Mesh.VertexArray.Bind();
                    GL.DrawArrays(PrimitiveType.Triangles, 0, renderer.Mesh.Positions.Count);
                    renderer.Mesh.VertexArray.Unbind();

                    renderer.Material.Shader.Reset();
                }
            }
            GL.Disable(EnableCap.Blend);
        }
    }
}
