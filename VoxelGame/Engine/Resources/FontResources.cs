using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using VoxelGame.Engine.Graphics.Text;
using Newtonsoft.Json;

namespace VoxelGame.Engine.Resources
{
    class FontResources : Resource<Font>
    {
        private AssetPool _pool;
        public FontResources(AssetPool assetPool) : base(assetPool)
        {
            Directiory = "/Fonts/";
            _pool = assetPool;
        }

        private const string EXT = ".fnt";

        public override void Load(string name)
        {
            string path = Root + Directiory + name + EXT;

            string json = File.ReadAllText(path);

            Font font = JsonConvert.DeserializeObject<Font>(json);

            Resources.Add(name, font);

            _pool.Textures.Load("Fonts/" + name);

            base.Load(name);
        }
    }
}
