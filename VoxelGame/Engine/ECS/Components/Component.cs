using System;
using System.Collections.Generic;
using System.Text;
using VoxelGame.Engine.Graphics.Geometry;
using VoxelGame.Engine.Graphics.Materials;

namespace VoxelGame.Engine.ECS.Components
{
    abstract class Component
    {
        public int EntityId { get; private set; }
        public bool isActive { get; set; } = true;

        protected Component(int entityId)
        {
            EntityId = entityId;
        }


    }
}
