using System;
using System.Collections.Generic;
using System.Text;
using VoxelGame.Engine.Graphics.Geometry;
using VoxelGame.Engine.Graphics.Materials;
using VoxelGame.Engine.Graphics.Text;

namespace VoxelGame.Engine.ECS.Components
{
    struct TextRenderer
    {
        public string Text;
        public UIMesh Mesh;
        public Font Font;
        public Material Material;
    }
}
