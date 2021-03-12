using OpenTK.Graphics.OpenGL;
using System;

namespace VoxelGame.Engine.Graphics.Textures
{
    class Texture2D : Texture
    {
        public PixelInternalFormat InternalFormat { get; private set; }
        public PixelFormat PixelFormat { get; private set; }
        public Texture2D(PixelInternalFormat internalFormat, PixelFormat pixelFormat) : base(TextureTarget.Texture2D)
        {
            InternalFormat = internalFormat;
            PixelFormat = pixelFormat;
        }

        public void Load<T>(int width, int height, T[] data) where T : struct
        {
            Bind();
            GL.TexImage2D(Target, 0, InternalFormat, width, height, 0, PixelFormat, PixelType.UnsignedByte, data);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
            Unbind();
        }

        public void Load(int width, int height, IntPtr data)
        {
            Bind();
            GL.TexImage2D(Target, 0, InternalFormat, width, height, 0, PixelFormat, PixelType.UnsignedByte, data);
            Unbind();
        }

        public void CreateEmpty(int width, int height)
        {
            Load(width, height, IntPtr.Zero);
        }

        public void Resize(int width, int height) => CreateEmpty(width, height);
    }
}
