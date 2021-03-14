using Leopotam.Ecs;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoxelGame.Engine.ECS.Components
{
    struct Transform2D
    {
        public Vector2 Position;
        public float Rotation;
        public Vector2 Scale;

        public EcsEntity Parent;
        public Matrix2 Model;
    }
}
