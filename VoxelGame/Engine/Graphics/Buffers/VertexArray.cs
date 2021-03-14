using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;

namespace VoxelGame.Engine.Graphics.Buffers
{
    class VertexArray
    {
        public int Id { get; private set; }
        public List<VertexBuffer> VertexBuffers { get; private set; }
        public ElementBuffer ElementBuffer { get; private set; }
        public BufferUsageHint Hint { get; private set; }
        public VertexArray(BufferUsageHint hint)
        {
            Hint = hint;
            VertexBuffers = new List<VertexBuffer>();
            Id = GL.GenVertexArray();
        }
        ~VertexArray()
        {
            GL.DeleteVertexArray(Id);
        }
        public void AddVertexBuffer(int componentSize)
        {
            VertexBuffers.Add(new VertexBuffer(componentSize, Hint));
        }
        public void AddElementBuffer()
        {
            ElementBuffer = new ElementBuffer(Hint);
        }
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

            ElementBuffer?.Bind();

            Unbind();
        }
        public void Bind()
        {
            GL.BindVertexArray(Id);
        }

        public void Unbind()
        {
            GL.BindVertexArray(0);
        }
    }
}
