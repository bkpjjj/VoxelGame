using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;
using VoxelGame.Engine.ECS.Components;

namespace VoxelGame.Engine.ECS.Systems
{
    class TransformSystem : ECSSystem
    {
        IEnumerable<Transform> transforms;
        public TransformSystem(Context context) : base(context)
        {
            transforms = context.GetComponents<Transform>();
        }
        private Matrix4 BuildRotation(Transform t)
        {
            Matrix4 rotation = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(t.Rotation.Z + t.LocalPosition.Z));
            rotation *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(t.Rotation.Y + t.LocalRotation.Z));
            rotation *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(t.Rotation.X + t.LocalRotation.X));
            return rotation;
        }
        private Matrix4 BuildModel(Transform t)
        {
            Matrix4 model = Matrix4.CreateTranslation(t.LocalPosition);
            model *= t.RotationMatrix;
            model *= Matrix4.CreateScale(t.Scale * t.LocalScale);
            model *= Matrix4.CreateTranslation(t.Position);
            return model;
        }
        public override void Draw(float dt)
        {
        }

        public override void Init()
        {
        }

        public override void Update(float dt)
        {
            foreach (Transform t in transforms)
            {
                t.RotationMatrix = BuildRotation(t);
                t.Model = BuildModel(t);
                UpdateChildPosition(t);
            }
        }

        private static void UpdateChildPosition(Transform transform)
        {
            foreach (var child in transform.GetChilds())
            {
                child.Position = transform.Position;
                child.Rotation = transform.Rotation;
                child.Scale = transform.Scale;
            }
        }
    }
}
