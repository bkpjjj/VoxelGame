using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace VoxelGame.Engine.ECS.Entities
{
    class EntitiesPool
    {
        static int id = 0;
        readonly List<Entity> entities = new List<Entity>();
        public int Count => entities.Count;
        public Entity CreateEntity()
        {
            Entity entity = new Entity(id++);
            entities.Add(entity);
            return entity;
        }

        public IEnumerable<Entity> GetEntities() => entities;

        public Entity GetEntity(int entityId) => entities.First(x => x.Id == entityId);
    }
}
