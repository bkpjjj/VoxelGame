using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace VoxelGame.Engine.Graphics.Text
{
    class Font
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("sizw")]
        public int Size { get; set; }
        [JsonProperty("bold")]
        public bool Bold { get; set; }
        [JsonProperty("italic")]
        public bool Italic { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
        [JsonProperty("characters")]
        public Dictionary<char,FontData> Characters { get; set; }
        public struct FontData
        {
            [JsonProperty("x")]
            public int X { get; set; }
            [JsonProperty("y")]
            public int Y { get; set; }
            [JsonProperty("width")]
            public int Width { get; set; }
            [JsonProperty("height")]
            public int Height { get; set; }
            [JsonProperty("originX")]
            public int OriginX { get; set; }
            [JsonProperty("originY")]
            public int OriginY { get; set; }
            [JsonProperty("advance")]
            public int Advance { get; set; }
        }
    }
}
