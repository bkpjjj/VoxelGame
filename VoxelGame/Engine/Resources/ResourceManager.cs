using System;
using System.Collections.Generic;
using System.Text;

namespace VoxelGame.Engine.Resources
{
    class ResourceManager<T>
    {
        public Dictionary<string, T> Resources { get; set; } = new Dictionary<string, T>();

        public T Find(string name) => Resources[name];

        public void Add(string name,T resource)
        {
            Resources.Add(name, resource);
        }

        public void Unload(string name)
        {
            Resources.Remove(name);
        }
    }
}
