using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoxelGame.Engine.ECS.Components
{
    struct BoxCollider
    {
        public bool isCollide;
        public bool isStatic;
        public Box3 Shape;
    }
}
