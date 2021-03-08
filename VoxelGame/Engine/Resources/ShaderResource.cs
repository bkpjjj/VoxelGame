using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using VoxelGame.Engine.Graphics.Shaders;

namespace VoxelGame.Engine.Resources
{
    class ShaderResource : Resource<Shader>
    {
        const string VERT_EXT = ".vert";
        const string FRAG_EXT = ".frag";
        const string GEOM_EXT = ".geom";
        public ShaderResource(AssetPool assetPool) : base(assetPool)
        {
            Directiory = "/Shaders/";
        }

        public override void Load(string name)
        {
            string vertPath = Root + Directiory + name + VERT_EXT;
            string fragPath = Root + Directiory + name + FRAG_EXT;
            string geomPath = Root + Directiory + name + GEOM_EXT;

            Shader shader = new Shader(name);

            string vertCode = File.ReadAllText(vertPath);
            string fragCode = File.ReadAllText(fragPath);
            string geom = null;
            if (File.Exists(geomPath))
                geom = File.ReadAllText(geom);

            shader.Load(vertCode, fragCode, geom);

            Resources.Add(name, shader);

            base.Load(name);
        }
    }
}
