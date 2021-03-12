using OpenTK.Graphics.OpenGL;

namespace VoxelGame.Engine.Graphics.Buffers
{
    class VertexBuffer : Buffer
    {
        public int ComponentSize { get; private set; }
        public VertexBuffer(int componentSize, BufferUsageHint hint = BufferUsageHint.StaticDraw) : base(BufferTarget.ArrayBuffer, hint)
        {
            ComponentSize = componentSize;
        }
    }
}
