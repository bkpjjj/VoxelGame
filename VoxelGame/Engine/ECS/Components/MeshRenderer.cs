using System;
using System.Collections.Generic;
using System.Text;
using VoxelGame.Engine.Graphics.Geometry;
using VoxelGame.Engine.Graphics.Materials;

namespace VoxelGame.Engine.ECS.Components
{
    struct MeshRenderer
    {
        public Mesh Mesh;
        public Material Material;
    }
}
