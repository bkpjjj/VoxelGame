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
        EcsWorld _world = null;
        EcsFilter<MeshRenderer,Transform> _filter = null;

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
            foreach (int i in _filter)
            {
                ref MeshRenderer renderer = ref _filter.Get1(i);
                ref Transform transform = ref _filter.Get2(i);

                renderer.Material.Shader.Use();

                renderer.Mesh.VertexArray.Bind();
                GL.DrawElements(PrimitiveType.Triangles, renderer.Mesh.Indices.Count, DrawElementsType.UnsignedInt, 0);
                renderer.Mesh.VertexArray.Unbind();

                renderer.Material.Shader.Reset();
            }
        }
    }
}
