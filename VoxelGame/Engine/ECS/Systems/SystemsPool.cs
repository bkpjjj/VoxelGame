using System;
using System.Collections.Generic;
using System.Text;

namespace VoxelGame.Engine.ECS.Systems
{
    class SystemsPool
    {
        readonly Dictionary<Type,ECSSystem> systems = new Dictionary<Type, ECSSystem>();

        public void AddSystem<T>(Context context) where T : ECSSystem
        {
            ECSSystem system = Activator.CreateInstance(typeof(T), context) as T;
            systems.Add(typeof(T), system);
        }

        public IEnumerable<ECSSystem> GetSystems() => systems.Values;

        public T GetSystem<T>() where T : ECSSystem
        {
            return systems[typeof(T)] as T;
        }
    }
}
