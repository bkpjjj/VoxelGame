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
        private Vector3 rotation;
        public Vector3 Rotation
        {
            get => rotation;
            set
            {
                rotation.X = value.X % 360.0f;
                rotation.Y = value.Y % 360.0f;
                rotation.Z = value.Z % 360.0f;
            }
        }
        public Vector3 Scale;

        public EcsEntity Parent;
        public Matrix4 Model;
        public Matrix4 RotationMatrix;
    }
}
