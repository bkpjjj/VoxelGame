using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace VoxelGame.Engine.Inputs
{
    static class Input
    {
        public static KeyboardState KeyboardState { get; set; }
        public static MouseState Mouse { get; set; }
        public static Vector2 MousePosition => Mouse.Position;
        public static Vector2 MouseDelta => -Mouse.Delta;

        public static bool CursorGrabbed { get; internal set; }
        public static bool CursorVisible { get; internal set; }
    }
}
