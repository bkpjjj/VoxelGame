using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoxelGame.Engine.ECS.Components
{
    struct Camera
    {
        public float FOV;
        public float Near;
        public float Far;
        public Matrix4 View;
        public Matrix4 Projection;
        public Matrix4 Othro;
    }
}
