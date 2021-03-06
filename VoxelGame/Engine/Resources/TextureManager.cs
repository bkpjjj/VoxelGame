using System;
using System.Collections.Generic;
using System.Text;
using VoxelGame.Engine.Graphics.Textures;

namespace VoxelGame.Engine.Resources
{
    class TextureManager : ResourceManager<Texture>
    {
        public T Find<T>(string name) where T : Texture
        {
            return base.Find(name) as T;
        }
    }
}
