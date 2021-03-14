using Leopotam.Ecs;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;
using VoxelGame.Engine.ECS.Components;
using VoxelGame.Engine.Graphics.Geometry;
using VoxelGame.Engine.Graphics.Textures;
using VoxelGame.Engine.Scenes;
using VoxelGame.Game.Materials;

namespace VoxelGame.Engine.ECS.Systems.RenderPipeline
{
    class MeshRendererSystem : IEcsRunSystem, IEcsInitSystem
    {
        EcsFilter<MeshRenderer,Transform> _filter = null;
        EcsFilter<Camera> _cameras = null;

        public void Init()
        {
            foreach (int i in _filter)
            {
                ref MeshRenderer renderer = ref _filter.Get1(i);
                renderer.Mesh.Upload();
            }
        }

        public void Run()
        {
            GL.Enable(EnableCap.DepthTest);
            foreach (var c in _cameras)
            {
                ref Camera cam = ref _cameras.Get1(c);

                foreach (int i in _filter)
                {
                    ref MeshRenderer renderer = ref _filter.Get1(i);
                    ref Transform transform = ref _filter.Get2(i);

                    renderer.Material.Shader.Use();
                    renderer.Material.Shader.SetMat4("MODEL", ref transform.Model);
                    renderer.Material.Shader.SetMat4("PROJ", ref cam.Projection);
                    renderer.Material.Shader.SetMat4("VIEW", ref cam.View);
                    renderer.Material.LoadParams();

                    renderer.Mesh.VertexArray.Bind();
                    GL.DrawElements(PrimitiveType.Triangles, renderer.Mesh.Indices.Count, DrawElementsType.UnsignedInt, 0);
                    renderer.Mesh.VertexArray.Unbind();

                    renderer.Material.Shader.Reset();
                } 
            }
            GL.Disable(EnableCap.DepthTest);
        }
    }
}
