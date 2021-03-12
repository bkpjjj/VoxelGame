using VoxelGame.Engine.Graphics.Materials;
using VoxelGame.Engine.Graphics.Textures;
using VoxelGame.Engine.Scenes;

namespace VoxelGame.Game.Materials
{
    class StandartMaterial : Material
    {
        public Texture2D Main { get; set; }
        public StandartMaterial() : base()
        {
            Shader = Scene.Content.Shaders["Standart"];
        }

        public override void LoadParams()
        {
            Main.Use(OpenTK.Graphics.OpenGL.TextureUnit.Texture0);
        }
    }
}
