using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace VoxelGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWindowSettings gameWindowSettings = GameWindowSettings.Default;
            NativeWindowSettings nativeWindowSettings = NativeWindowSettings.Default;
            nativeWindowSettings.APIVersion = new Version(3, 3);
            nativeWindowSettings.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
            nativeWindowSettings.Size = new OpenTK.Mathematics.Vector2i(1280, 720);
            nativeWindowSettings.NumberOfSamples = 4;
            nativeWindowSettings.Profile = OpenTK.Windowing.Common.ContextProfile.Core;

            using (Application app = new Application(gameWindowSettings, nativeWindowSettings))
            {
                app.Run();
            }
        }
    }
}
