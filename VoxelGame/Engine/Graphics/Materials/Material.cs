using VoxelGame.Engine.Graphics.Shaders;

namespace VoxelGame.Engine.Graphics.Materials
{
    abstract class Material
    {
        public Shader Shader { get; set; }
        public int RenderQueue { get; set; } = 2000;
        public abstract void LoadParams();

        protected Material()
        {

        }
    }
}
