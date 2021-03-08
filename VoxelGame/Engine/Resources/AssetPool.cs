using System;
using System.Collections.Generic;
using System.Text;
using VoxelGame.Engine.Debug;

namespace VoxelGame.Engine.Resources
{
    class AssetPool
    {
        public string Root { get; private set; } = "Content";
        public ShaderResource Shaders { get; private set; }
        public TextureResources Textures { get; private set; }

        public AssetPool()
        {
            Shaders = new ShaderResource(this);
            Textures = new TextureResources(this);
        }
    }
}
