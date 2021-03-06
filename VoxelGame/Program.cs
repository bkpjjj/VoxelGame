using OpenTK.Windowing.Desktop;
using System;

namespace VoxelGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWindowSettings gameWindowSettings = GameWindowSettings.Default;
            NativeWindowSettings nativeWindowSettings = NativeWindowSettings.Default;
            nativeWindowSettings.Size = new OpenTK.Mathematics.Vector2i(1280, 720);
            nativeWindowSettings.NumberOfSamples = 4;

            using (Application app = new Application(gameWindowSettings, nativeWindowSettings))
            {
                app.Run();
            }
        }
    }
}
