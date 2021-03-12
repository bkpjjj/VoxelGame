using OpenTK.Graphics.OpenGL;

namespace VoxelGame.Engine.Graphics.Textures
{
    abstract class Texture
    {
        public int Id { get; private set; }
        public TextureTarget Target { get; private set; }
        public Texture(TextureTarget target)
        {
            Target = target;
            Id = GL.GenTexture();
        }
        public void Bind() => GL.BindTexture(Target, Id);
        public void Unbind() => GL.BindTexture(Target, 0);
        public void Use(TextureUnit unit)
        {
            GL.ActiveTexture(unit);
            Bind();
        }
    }
}
