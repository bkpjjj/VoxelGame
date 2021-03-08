using System;
using System.Collections.Generic;
using System.Text;
using VoxelGame.Engine.ECS.Components;

namespace VoxelGame.Game.Components
{
    class TestComponent : Component
    {
        public TestComponent(int entityId) : base(entityId)
        {
        }
    }
}
