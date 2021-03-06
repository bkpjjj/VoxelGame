using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Text;
using VoxelGame.Engine.Resources;

namespace VoxelGame.Engine.Graphics.Textures
{
    class Texture2D : Texture
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Texture2D(string name) : base(name)
        {
            Target = TextureTarget.Texture2D;
            Assets.TextureManager.Add(name, this);
        }

        ~Texture2D()
        {
            Assets.TextureManager.Unload(Name);
            GL.DeleteTexture(Id);
        }

        public void CreateEmpty(int width, int height)
        {
            Create(width, height, IntPtr.Zero);
        }

        public void Create(int width, int height, IntPtr data)
        {
            Width = width;
            Height = height;
            Bind();
            GL.TexImage2D(Target, 0, PixelInternalFormat.Rgba, Width, Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, data);
            Unbind();
        }

        public void Resize(int width, int height)
        {
            CreateEmpty(width, height);
        }
    }
}
