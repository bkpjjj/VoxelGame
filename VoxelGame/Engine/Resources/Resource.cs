using System.Collections.Generic;
using VoxelGame.Engine.Debugging;

namespace VoxelGame.Engine.Resources
{
    abstract class Resource<T>
    {
        public string Root { get; set; }
        public string Directiory { get; set; }
        protected Dictionary<string, T> Resources { get; private set; } = new Dictionary<string, T>();

        protected Resource(AssetPool assetPool)
        {
            Root = assetPool.Root;
        }

        public virtual void Load(string name)
        {
            Debug.Info($"Resource Loaded: {name}", this);
        }

        public T Find(string name) => Resources[name];

        public T this[string name]
        {
            get
            {
                return Find(name);
            }
        }
    }
}
