using OpenTK.Graphics.OpenGL;
using VoxelGame.Engine.Graphics.Materials;
using VoxelGame.Engine.Scenes;

namespace VoxelGame.Game.Materials
{
    class TestMat : Material
    {
        public TestMat()
        {
            Shader = Scene.Content.Shaders["Standart"];
        }

        public override void LoadParams()
        {
            GL.BindTexture(TextureTarget.Texture2D, 3);
            GL.ActiveTexture(TextureUnit.Texture0);
        }
    }
}
