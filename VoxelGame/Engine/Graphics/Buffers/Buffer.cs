using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using VoxelGame.Engine.Debug;

namespace VoxelGame.Engine.Graphics.Buffers
{
    abstract class Buffer
    {
        public int Id { get; private set; }
        public BufferTarget Target { get; private set; }
        public BufferUsageHint Hint { get; set; }

        public Buffer(BufferTarget target, BufferUsageHint hint = BufferUsageHint.StaticDraw)
        {
            Target = target;
            Hint = hint;
            Id = GL.GenBuffer();
        }

        ~Buffer()
        {
            GL.DeleteBuffer(Id);
        }
        public void Bind()
        {
            GL.BindBuffer(Target, Id);
        }
        public void Unbind()
        {
            GL.BindBuffer(Target, 0);
        }

        public void SetData<T>(T[] data) where T : struct
        {
            Bind();
            GL.BufferData(Target, Unsafe.SizeOf<T>() * data.Length, data, Hint);
            Unbind();
        }
    }
}
