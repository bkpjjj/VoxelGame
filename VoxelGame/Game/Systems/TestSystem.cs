using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;
using VoxelGame.Engine.Debug;
using VoxelGame.Engine.ECS;
using VoxelGame.Engine.ECS.Components;
using VoxelGame.Engine.ECS.Systems;
using VoxelGame.Engine.Graphics.Geometry;
using VoxelGame.Engine.Graphics.Textures;
using VoxelGame.Engine.Inputs;
using VoxelGame.Engine.Scenes;
using VoxelGame.Game.Components;
using VoxelGame.Game.Materials;

namespace VoxelGame.Game.Systems
{
    class TestSystem : ECSSystem
    {
        readonly IEnumerable<TestComponent> testComponents;
        public TestSystem(Context context) : base(context)
        {
            testComponents = context.GetComponents<TestComponent>();
        }

        public override void Draw(float dt)
        {
        }

        Random rand;

        public override void Init()
        {
            rand = new Random();
        }

        public override void Update(float dt)
        {

            foreach (TestComponent testComponent in testComponents)
            {
                Transform t = Context.GetComponent<Transform>(testComponent.EntityId);

                t.Rotation += Vector3.UnitX * 60f * dt;
            }

        }
    }
}
