using OpenTK.Graphics.OpenGL;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using VoxelGame.Engine.Graphics.Textures;

namespace VoxelGame.Engine.Resources
{
    class TextureResources : Resource<Texture>
    {
        public TextureResources(AssetPool assetPool) : base(assetPool)
        {
            Directiory = "/Textures/";
        }
        const string ext = ".png";
        public override void Load(string name)
        {
            string texPath = Root + Directiory + name + ext;
            Image<Rgba32> image = (Image<Rgba32>)Image.Load(texPath);
            image.Mutate(x => x.Flip(FlipMode.Vertical));

            image.TryGetSinglePixelSpan(out Span<Rgba32> span);

            byte[] buffer = MemoryMarshal.Cast<Rgba32, byte>(span).ToArray();

            Texture2D texture = new Texture2D(PixelInternalFormat.Rgba, PixelFormat.Rgba);
            texture.Load(image.Width, image.Height, buffer);

            Resources.Add(name, texture);
            base.Load(name);
        }

        public T Find<T>(string name) where T : Texture
        {
            return Find(name) as T;
        }
    }
}
