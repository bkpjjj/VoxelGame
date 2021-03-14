using System;
using System.Collections.Generic;
using System.Text;
using VoxelGame.Engine.Graphics.Materials;
using VoxelGame.Engine.Graphics.Textures;
using VoxelGame.Engine.Scenes;

namespace VoxelGame.Game.Materials
{
    class FontMaterial : Material
    {
        public Texture2D Font { get; set; }
        public FontMaterial()
        {
            Shader = Scene.Content.Shaders.Find("Font");
        }

        public override void LoadParams()
        {
            Font.Use(OpenTK.Graphics.OpenGL.TextureUnit.Texture0);
        }
    }
}
