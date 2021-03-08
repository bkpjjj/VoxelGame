using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;
using VoxelGame.Engine.Graphics;
using VoxelGame.Engine.Graphics.Buffers;

namespace VoxelGame.Engine.ECS.Components
{
    class Camera : Component
    {
        public Camera(int entityId) : base(entityId)
        {
        }

        public float FOV { get; set; } = MathHelper.DegreesToRadians(60);
        public float Width => Screen.Width;
        public float Height => Screen.Height;
        public float Near { get; set; } = 0.03f;
        public float Far { get; set; } = 1000.0f;
        public Matrix4 View { get; set; }
        public Matrix4 Projection { get; set; }
        public FrameBuffer FrameBuffer { get; set; } = null;
    }
}
