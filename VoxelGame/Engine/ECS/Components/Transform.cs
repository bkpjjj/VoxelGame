using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;
using Leopotam.Ecs;

namespace VoxelGame.Engine.ECS.Components
{
    struct Transform
    {
        public Vector3 Position;
        public Vector3 Rotation;
        public Vector3 Scale;

        public EcsEntity Parent;
        public Matrix4 Model;
        public Matrix4 RotationMatrix;
    }
}
