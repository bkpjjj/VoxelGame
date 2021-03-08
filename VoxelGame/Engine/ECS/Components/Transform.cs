using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoxelGame.Engine.ECS.Components
{
    class Transform : Component
    {
        public Transform(int entityId) : base(entityId)
        {
        }

        public Vector3 Position { get; set; }
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
        public Vector3 Scale { get; set; } = Vector3.One;
        public Vector3 LocalPosition { get; set; }
        private Vector3 localrotation;
        public Vector3 LocalRotation
        {
            get => localrotation;
            set
            {
                localrotation.X = value.X % 360.0f;
                localrotation.Y = value.Y % 360.0f;
                localrotation.Z = value.Z % 360.0f;
            }
        }
        public Vector3 LocalScale { get; set; } = Vector3.One;
        public Matrix4 Model { get; set; }
        public Matrix4 RotationMatrix { get; set; }
        private List<Transform> childs = new List<Transform>();

        public void SetParent(Transform p)
        {
            p.AddChild(this);
        }

        public void AddChild(Transform c)
        {
            childs.Add(c);
        }

        public void TranslateTowards(Vector3 pos)
        {
            Position += Vector3.TransformPosition(pos, RotationMatrix);
        }

        public IEnumerable<Transform> GetChilds()
        {
            return childs;
        }
    }
}
