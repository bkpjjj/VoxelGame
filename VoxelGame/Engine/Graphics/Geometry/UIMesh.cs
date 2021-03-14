using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using VoxelGame.Engine.Graphics.Buffers;

namespace VoxelGame.Engine.Graphics.Geometry
{
    class UIMesh
    {
        public List<Vector2> Positions { get; private set; } = new List<Vector2>();
        public List<Vector2> UVs { get; private set; } = new List<Vector2>();
        public VertexArray VertexArray { get; private set; }
        public UIMesh()
        {
            VertexArray = new VertexArray(OpenTK.Graphics.OpenGL.BufferUsageHint.DynamicDraw);
            VertexArray.AddVertexBuffer(2);
            VertexArray.AddVertexBuffer(2);
            VertexArray.Init();
        }
        public void Upload()
        {
            var positions = MemoryMarshal.Cast<Vector2, float>(Positions.ToArray()).ToArray();
            VertexArray.VertexBuffers[0].SetData(positions);

            var uvs = MemoryMarshal.Cast<Vector2, float>(UVs.ToArray()).ToArray();
            VertexArray.VertexBuffers[1].SetData(uvs);
        }
    }
}
