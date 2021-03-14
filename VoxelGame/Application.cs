using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using VoxelGame.Engine;
using VoxelGame.Engine.Graphics;
using VoxelGame.Engine.Graphics.Geometry;
using VoxelGame.Engine.Inputs;
using VoxelGame.Engine.Scenes;
using VoxelGame.Game.Scenes;

namespace VoxelGame
{
    class Application : GameWindow
    {
        public Application(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
            VSync = VSyncMode.Off;
            Input.KeyboardState = KeyboardState;
            Input.Mouse = MouseState;
            CursorGrabbed = true;
        }

        protected override void OnLoad()
        {
            SceneManager.Load(new TestScene());
            GL.ClearColor(new Color4(0.05f, 0.05f, 0.1f, 1.0f));
        }



        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            Time.DeltaTime = (float)args.Time;
            SceneManager.Current.DrawSystems();
            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, e.Width, e.Height);
            Screen.Width = e.Width;
            Screen.Height = e.Height;
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            Time.DrawDeltaTime = (float)args.Time;
            SceneManager.Current.UpdateSystems();
        }
    }
}
