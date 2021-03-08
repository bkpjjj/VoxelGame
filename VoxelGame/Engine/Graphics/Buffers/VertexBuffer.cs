using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
using System.Text;

namespace VoxelGame.Engine.Graphics.Buffers
{
    class VertexBuffer : Buffer
    {
        public int ComponentSize { get; private set; }
        public VertexBuffer(int componentSize,BufferUsageHint hint = BufferUsageHint.StaticDraw) : base(BufferTarget.ArrayBuffer, hint)
        {
            ComponentSize = componentSize;
        }
    }
}
