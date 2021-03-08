using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;
using VoxelGame.Engine.ECS;
using VoxelGame.Engine.ECS.Components;
using VoxelGame.Engine.ECS.Systems;
using VoxelGame.Engine.Inputs;
using VoxelGame.Game.Components;

namespace VoxelGame.Game.Systems
{
    class CameraViewSystem : ECSSystem
    {
        IEnumerable<CameraView> cameraViews;
        public CameraViewSystem(Context context) : base(context)
        {
            cameraViews = Context.GetComponents<CameraView>();
        }

        public override void Draw(float dt)
        {
        }

        public override void Init()
        {
        }

        public override void Update(float dt)
        {
            foreach (CameraView cameraView in cameraViews)
            {
                if (!cameraView.isActive)
                    continue;

                Transform t = Context.GetComponent<Transform>(cameraView.EntityId);

                t.Rotation += new Vector3(Input.MouseDelta * 0.25f);
                t.Rotation = Vector3.Clamp(t.Rotation, new Vector3(-360, -60, 0), new Vector3(360, 60, 0));
            }
        }
    }
}
