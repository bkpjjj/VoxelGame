using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoxelGame.Engine.Graphics.Buffers
{
    sealed class VertexBuffer
    {
        public int Id { get; private set; }
        public int ComponentSize { get; private set; }

        public VertexBuffer()
        {
            Id = GL.GenBuffer();
        }

        ~VertexBuffer()
        {
            GL.DeleteBuffer(Id);
        }

        public void Bind() => GL.BindBuffer(BufferTarget.ArrayBuffer, Id);
        public void Unbind() => GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        public void SetData(float[] buffer)
        {
            Bind();
            GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * buffer.Length, buffer, BufferUsageHint.DynamicDraw);
            Unbind();
        }
    }
}
