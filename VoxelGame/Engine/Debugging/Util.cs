using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Runtime.CompilerServices;

namespace VoxelGame.Engine.Debugging
{
    static class Util
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Measure(Action a)
        {
            Stopwatch sw = new Stopwatch();

            long avg = 0;
            for (int i = 0; i < 10; i++)
            {
                sw.Restart();
                sw.Start();

                a();

                sw.Stop();
                avg += sw.ElapsedMilliseconds;
                Console.WriteLine($"[Try:{i}]"+sw.ElapsedMilliseconds.ToString("0 ms"));
            }
            avg /= 10;
            Console.WriteLine($"[Avg]" + avg.ToString("0 ms"));
        }
    }
}
