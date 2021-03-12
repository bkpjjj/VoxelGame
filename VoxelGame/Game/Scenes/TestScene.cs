using Leopotam.Ecs;
using OpenTK.Mathematics;
using System;
using VoxelGame.Engine.Graphics.Buffers;
using VoxelGame.Engine.Graphics.Geometry;
using VoxelGame.Engine.Graphics.Textures;
using VoxelGame.Engine.Scenes;
using VoxelGame.Game.Materials;

namespace VoxelGame.Game.Scenes
{
    class TestScene : Scene
    {
        Random rand = new Random();
        public override void BuildEntitis()
        {
            
        }

        public override void OnConfigureDraw(EcsSystems systems)
        {
        }

        public override void OnConfigureUpdate(EcsSystems systems)
        {
        }

        public override void OnLoadContent()
        {
            Content.Shaders.Load("Standart");
            Content.Textures.Load("tenor");
            Content.Textures.Load("grass");
        }
    }
}
