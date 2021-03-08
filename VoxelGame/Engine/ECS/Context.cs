using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VoxelGame.Engine.ECS.Components;
using VoxelGame.Engine.ECS.Entities;
using VoxelGame.Engine.ECS.Systems;

namespace VoxelGame.Engine.ECS
{
    class Context
    {
        readonly Dictionary<Type, ComponentMapper> componentsPool = new Dictionary<Type, ComponentMapper>();
        public EntitiesPool EntitiesPool { get; private set; } = new EntitiesPool();
        readonly SystemsPool systemsPool = new SystemsPool();

        public void AddSystem<T>() where T : ECSSystem
        {
            systemsPool.AddSystem<T>(this);
        }

        public T GetSystem<T>() where T : ECSSystem
        {
            return systemsPool.GetSystem<T>();
        }

        public IEnumerable<ECSSystem> GetSystems() => systemsPool.GetSystems();

        public void AddComponentsPool<T>() where T : Component
        {
            componentsPool.Add(typeof(T), new ComponentsPool<T>());
        }

        public T GetComponent<T>(int entityId) where T : Component
        {
            return (componentsPool[typeof(T)] as ComponentsPool<T>).GetComponent(entityId);
        }

        public T AddComponent<T>(int entityId) where T : Component
        {
            return (componentsPool[typeof(T)] as ComponentsPool<T>).AddComponent(entityId);
        }

        public void RemoveComponent<T>(int entityId) where T : Component
        {
            (componentsPool[typeof(T)] as ComponentsPool<T>).RemoveComponent(entityId);
        }

        public IEnumerable<T> GetComponents<T>() where T : Component
        {
            return (componentsPool[typeof(T)] as ComponentsPool<T>).GetComponents();
        }
    }
}
