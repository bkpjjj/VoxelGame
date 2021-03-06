using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoxelGame.Engine.Graphics.Buffers
{
    sealed class ElementBuffer
    {
        public int Id { get; private set; }
        public ElementBuffer()
        {
            Id = GL.GenBuffer();
        }

        ~ElementBuffer()
        {
            GL.DeleteBuffer(Id);
        }

        public void Bind() => GL.BindBuffer(BufferTarget.ElementArrayBuffer, Id);
        public void Unbind() => GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        public void SetData(float[] buffer)
        {
            Bind();
            GL.BufferData(BufferTarget.ElementArrayBuffer, sizeof(float) * buffer.Length, buffer, BufferUsageHint.DynamicDraw);
            Unbind();
        }
    }
}
