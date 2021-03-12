using OpenTK.Graphics.OpenGL;

namespace VoxelGame.Engine.Graphics.Buffers
{
    class ElementBuffer : Buffer
    {
        public ElementBuffer(BufferUsageHint hint = BufferUsageHint.StaticDraw) : base(BufferTarget.ElementArrayBuffer, hint)
        {
        }
    }
}
