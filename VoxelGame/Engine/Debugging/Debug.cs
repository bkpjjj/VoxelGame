using System;
using System.Collections.Generic;
using System.Text;

namespace VoxelGame.Engine.Debugging
{
    static class Debug
    {
        public static void Info(string message, object sender) => Msg(ConsoleColor.White, "info", sender, message);
        public static void Warn(string message, object sender) => Msg(ConsoleColor.DarkYellow, "warn", sender, message);
        public static void Err(string message, object sender) => Msg(ConsoleColor.DarkRed, "err", sender, message);
        public static void Msg(ConsoleColor color, string type, object sender, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"[{DateTime.Now.ToShortTimeString()}][{type}][{sender}] {message}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
