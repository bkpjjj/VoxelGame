using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using VoxelGame.Engine.Debug;
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
            VSync = VSyncMode.On;
            Input.KeyboardState = KeyboardState;
            Input.Mouse = MouseState;
            CursorGrabbed = true;
        }

        protected override void OnLoad()
        {
            SceneManager.Load(new TestScene());
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            SceneManager.Current.DrawSystems((float)args.Time);

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
            SceneManager.Current.UpdateSystems((float)args.Time);
            Title = "Title Fps:" + (1f / args.Time).ToString("0000") + " Update:" + args.Time.ToString("0.0000 ms");
        }
    }
}
