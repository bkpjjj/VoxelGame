using System;
using System.Collections.Generic;
using System.Text;

namespace VoxelGame.Engine.ECS.Entities
{
    sealed class Entity
    {
        public int Id { get; private set; }

        public Entity(int id)
        {
            Id = id;
        }
    }
}
