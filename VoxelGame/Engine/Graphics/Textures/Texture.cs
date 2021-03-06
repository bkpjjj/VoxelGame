using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoxelGame.Engine.Graphics.Textures
{
    abstract class Texture
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public TextureTarget Target { get; protected set; }
        public Texture(string name)
        {
            Name = name;
            Id = GL.GenTexture();
        }

        public void Bind() => GL.BindTexture(Target, Id);
        public void Unbind() => GL.BindTexture(Target, 0);
    }
}
