using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Text;
using VoxelGame.Engine.Graphics.Textures;

namespace VoxelGame.Engine.Graphics.Buffers
{
    sealed class FrameBuffer
    {
        public int Id { get; private set; }

        public Texture2D Texture { get; private set; }

        public FrameBuffer(string name, int width, int height, FramebufferAttachment attachment)
        {
            Id = GL.GenFramebuffer();
            Texture = new Texture2D(name);
            Texture.CreateEmpty(width, height);
            Texture.Bind();
            GL.FramebufferTexture2D(FramebufferTarget.Framebuffer, attachment, TextureTarget.Texture2D, Texture.Id, 0);
            Texture.Unbind();
        }

        ~FrameBuffer()
        {
            GL.DeleteFramebuffer(Id);
        }
        
        public void Bind() => GL.BindFramebuffer(FramebufferTarget.Framebuffer, Id);
        public void Unbind() => GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
        
        public void Resize(int width, int height)
        {
            Texture.Resize(width, height);
        }
    }
}
