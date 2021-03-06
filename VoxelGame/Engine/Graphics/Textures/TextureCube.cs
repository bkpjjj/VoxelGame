using System;
using System.Collections.Generic;
using System.Text;

namespace VoxelGame.Engine.Graphics.Textures
{
    class TextureCube : Texture
    {
        public TextureCube(string name) : base(name)
        {
            Target = OpenTK.Graphics.OpenGL.TextureTarget.TextureCubeMap;
        }
    }
}
