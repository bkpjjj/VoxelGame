using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
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
    class MoveSystem : ECSSystem
    {
        IEnumerable<Moveble> movebles;
        public MoveSystem(Context context) : base(context)
        {
            movebles = Context.GetComponents<Moveble>();
        }

        public override void Draw(float dt)
        {
        }

        public override void Init()
        {
        }

        public Vector3 TranslateTowards(Transform t,Vector3 pos)
        {
            return Vector3.TransformPosition(pos, t.RotationMatrix);
        }

        public override void Update(float dt)
        {
            foreach (Moveble moveble in movebles)
            {
                if (!moveble.isActive)
                    continue;

                Transform t = Context.GetComponent<Transform>(moveble.EntityId);

                if (Input.KeyboardState.IsKeyDown(Keys.A))
                {
                    t.Position -= TranslateTowards(t,Vector3.UnitX * dt);
                }
                if (Input.KeyboardState.IsKeyDown(Keys.D))
                {
                    t.Position += TranslateTowards(t, Vector3.UnitX * dt);
                }
                if (Input.KeyboardState.IsKeyDown(Keys.W))
                {
                    t.Position -= TranslateTowards(t, Vector3.UnitZ * dt);
                }
                if (Input.KeyboardState.IsKeyDown(Keys.S))
                {
                    t.Position += TranslateTowards(t, Vector3.UnitZ * dt);
                }
            }
        }
    }
}
