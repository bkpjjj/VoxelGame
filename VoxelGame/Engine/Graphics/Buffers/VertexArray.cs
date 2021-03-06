using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoxelGame.Engine.Graphics.Buffers
{
    class VertexArray
    {
        public int Id { get; private set; }

        public List<VertexBuffer> VertexBuffers { get; private set; } = new List<VertexBuffer>();
        public ElementBuffer ElementBuffer { get; private set; } = new ElementBuffer();

        public VertexArray()
        {
            Id = GL.GenVertexArray();
        }

        ~VertexArray()
        {
            GL.DeleteVertexArray(Id);
        }

        public void Bind() => GL.BindVertexArray(Id);
        public void Unbind() => GL.BindVertexArray(0);

        public void Init()
        {
            Bind();

            int index = 0;
            foreach (VertexBuffer buffer in VertexBuffers)
            {
                buffer.Bind();
                GL.VertexAttribPointer(index, buffer.ComponentSize, VertexAttribPointerType.Float, false, 0, 0);
                GL.EnableVertexAttribArray(index++);
                buffer.Unbind();
            }

            ElementBuffer.Bind();

            Unbind();
        }
    }
}
