using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using VoxelGame.Engine.Debugging;

namespace VoxelGame
{
    class Program
    {
        static void Main(string[] args)
        {

            /*Console.WriteLine("Default");
            Util.Measure(() =>
            {
                for (int i = 0; i < 50_000_000; i++)
                {
                    Vector3 a = Vector3.UnitX;
                    Vector3 b = Vector3.UnitY;

                    Vector3 c = a * b;
                }
            });
            Console.WriteLine("JIT sse optimization");
            Util.Measure(() =>
            {
                for (int i = 0; i < 50_000_000; i++)
                {
                    Vector3 a = Vector3.UnitX;
                    Vector3 b = Vector3.UnitY;
                          
                    Vector3 c = Mul(a,b);
                }
            });
            Console.WriteLine("sse");
            Util.Measure(() =>
            {
                for (int i = 0; i < 50_000_000; i++)
                {
                    Vector3 a = Vector3.UnitX;
                    Vector3 b = Vector3.UnitY;
                    Vector3 c = MulSse(a, b);
                }
            });*/




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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Vector3 Mul(in Vector3 a,in Vector3 b)
        {
            return new Vector3(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Vector3 MulSse(in Vector3 a,in Vector3 b)
        {
            Vector128<float> va = Vector128.Create(a.X, a.Y, a.Z, 0f);
            Vector128<float> vb = Vector128.Create(b.X, b.Y, b.Z, 0f);
            Vector128<float> res = Sse.Multiply(va, vb);
            return new Vector3(res.GetElement(0), res.GetElement(1), res.GetElement(2));
        }
    }
}
