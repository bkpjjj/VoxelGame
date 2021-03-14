using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using VoxelGame.Engine.Graphics.Buffers;

namespace VoxelGame.Engine.Graphics.Geometry
{
    class Mesh
    {
        public List<Vector3> Positions { get; private set; } = new List<Vector3>();
        public List<Vector3> Normals { get; private set; } = new List<Vector3>();
        public List<Color4> Colors { get; private set; } = new List<Color4>();
        public List<Vector2> UVs { get; private set; } = new List<Vector2>();
        public List<uint> Indices { get; private set; } = new List<uint>();
        public VertexArray VertexArray { get; private set; }
        public Mesh(BufferUsageHint hint)
        {
            VertexArray = new VertexArray(hint);
            VertexArray.AddElementBuffer();
            VertexArray.AddVertexBuffer(3);
            VertexArray.AddVertexBuffer(3);
            VertexArray.AddVertexBuffer(4);
            VertexArray.AddVertexBuffer(2);
            VertexArray.Init();
        }
        public void Upload()
        {
            var positions = MemoryMarshal.Cast<Vector3, float>(Positions.ToArray()).ToArray();
            VertexArray.VertexBuffers[0].SetData(positions);

            var normals = MemoryMarshal.Cast<Vector3, float>(Normals.ToArray()).ToArray();
            VertexArray.VertexBuffers[1].SetData(normals);

            var colors = MemoryMarshal.Cast<Color4, float>(Colors.ToArray()).ToArray();
            VertexArray.VertexBuffers[2].SetData(colors);

            var uvs = MemoryMarshal.Cast<Vector2, float>(UVs.ToArray()).ToArray();
            VertexArray.VertexBuffers[3].SetData(uvs);

            VertexArray.ElementBuffer.SetData(Indices.ToArray());
        }
    }
}
