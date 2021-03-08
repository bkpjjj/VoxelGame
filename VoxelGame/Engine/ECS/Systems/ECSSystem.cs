using System;
using System.Collections.Generic;
using System.Text;

namespace VoxelGame.Engine.ECS.Systems
{
    abstract class ECSSystem
    {
        public Context Context { get; private set; }
        public abstract void Init();
        public abstract void Update(float dt);
        public abstract void Draw(float dt);

        protected ECSSystem(Context context)
        {
            Context = context;
        }
    }
}
