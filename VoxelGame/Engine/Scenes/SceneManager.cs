using System;
using System.Collections.Generic;
using System.Text;

namespace VoxelGame.Engine.Scenes
{
    class SceneManager
    {
        public static Scene Current { get; private set; }

        public static void Load(Scene scene)
        {
            Current = scene;
            Current.Load();
        }
    }
}
