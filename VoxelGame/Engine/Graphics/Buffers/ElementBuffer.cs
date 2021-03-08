using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoxelGame.Engine.Graphics.Buffers
{
    class ElementBuffer : Buffer
    {
        public ElementBuffer(BufferUsageHint hint = BufferUsageHint.StaticDraw) : base(BufferTarget.ElementArrayBuffer, hint)
        {
        }
    }
}
