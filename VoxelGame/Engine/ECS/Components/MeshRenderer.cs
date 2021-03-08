using System;
using System.Collections.Generic;
using System.Text;
using VoxelGame.Engine.Graphics.Geometry;
using VoxelGame.Engine.Graphics.Materials;

namespace VoxelGame.Engine.ECS.Components
{
    class MeshRenderer : Component
    {
        public MeshRenderer(int entityId) : base(entityId)
        {
        }
        public Mesh Mesh { get; set; }
        public Material Material { get; set; }
    }
}
