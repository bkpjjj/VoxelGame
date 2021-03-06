using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoxelGame.Engine.Graphics
{
    class Mesh
    {
        public List<Vector3> Position { get; set; } = new List<Vector3>();
        public List<Vector3> Normals { get; set; } = new List<Vector3>();
        public List<Color4> Colors { get; set; } = new List<Color4>();
        public List<Vector2> UVs { get; set; } = new List<Vector2>();
        public List<uint> Indices { get; set; } = new List<uint>();


    }
}
