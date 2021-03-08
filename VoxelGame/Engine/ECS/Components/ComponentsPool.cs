using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace VoxelGame.Engine.ECS.Components
{
    abstract class ComponentMapper {}

    class ComponentsPool<T> : ComponentMapper where T : Component
    {
        readonly Dictionary<int, T> components = new Dictionary<int, T>();

        public T GetComponent(int entityId) 
        {
            return components[entityId] as T;
        }

        public T AddComponent(int entityId) 
        {
            T component = Activator.CreateInstance(typeof(T), entityId) as T;
            components.Add(entityId, component);
            return component;
        }

        public void RemoveComponent(int entityId)
        {
            components.Remove(entityId);
        }

        public IEnumerable<T> GetComponents()
        {
            return components.Values;
        }
    }
}
