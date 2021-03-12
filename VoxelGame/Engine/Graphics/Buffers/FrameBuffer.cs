using OpenTK.Graphics.OpenGL;
using System;
using VoxelGame.Engine.Debugging;
using VoxelGame.Engine.Graphics.Textures;

namespace VoxelGame.Engine.Graphics.Buffers
{
    class FrameBuffer
    {
        public int Id { get; private set; }
        public Texture2D Texture { get; set; }

        public FrameBuffer(int width, int height, FramebufferAttachment attachment)
        {
            Id = GL.GenFramebuffer();
            Bind();

            int id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, id);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, width, height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, IntPtr.Zero);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.FramebufferTexture2D(FramebufferTarget.Framebuffer, FramebufferAttachment.ColorAttachment0, TextureTarget.Texture2D, id, 0);

            int rb = GL.GenRenderbuffer();
            GL.BindRenderbuffer(RenderbufferTarget.Renderbuffer, rb);
            GL.RenderbufferStorage(RenderbufferTarget.Renderbuffer, RenderbufferStorage.Depth24Stencil8, width, height);
            GL.BindRenderbuffer(RenderbufferTarget.Renderbuffer, 0);
            GL.FramebufferRenderbuffer(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthStencilAttachment, RenderbufferTarget.Renderbuffer, rb);

            var status = GL.CheckFramebufferStatus(FramebufferTarget.Framebuffer);
            if (status != FramebufferErrorCode.FramebufferComplete)
            {
                Debug.Warn(status.ToString(), this);
            }

            Unbind();
        }

        public void Bind() => GL.BindFramebuffer(FramebufferTarget.Framebuffer, Id);
        public void Unbind() => GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);

        public void Resize(int width, int height) => Texture.Resize(width, height);
    }
}
