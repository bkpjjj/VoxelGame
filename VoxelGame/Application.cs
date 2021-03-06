using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoxelGame
{
    class Application : GameWindow
    {
        public Application(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
        }
    }
}
