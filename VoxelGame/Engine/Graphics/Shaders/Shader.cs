using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using VoxelGame.Engine.Debugging;
using VoxelGame.Engine.Graphics.Textures;

namespace VoxelGame.Engine.Graphics.Shaders
{
    class Shader
    {
        public int ID { get; private set; }

        public Shader(string name)
        {
            ID = GL.CreateProgram();
        }

        ~Shader()
        {
            GL.DeleteProgram(ID);
        }

        public void Load(string vert, string frag, string geom = null)
        {
            LoadShader(vert, ShaderType.VertexShader);
            LoadShader(frag, ShaderType.FragmentShader);
            if (geom != null)
                LoadShader(geom, ShaderType.GeometryShader);
            GL.LinkProgram(ID);
        }

        private void LoadShader(string code, ShaderType type)
        {
            int id = GL.CreateShader(type);
            GL.ShaderSource(id, code);
            GL.CompileShader(id);
            string info = GL.GetShaderInfoLog(id);
            if (!string.IsNullOrEmpty(info))
                Debug.Warn(info, this);
            GL.AttachShader(ID, id);
        }

        public void Use() => GL.UseProgram(ID);

        public void Reset() => GL.UseProgram(0);

        public void SetFloat(string p, float v)
        {
            var loc = GL.GetUniformLocation(ID, p);
            GL.Uniform1(loc, v);
        }

        public void SetVec2(string p, Vector2 v)
        {
            var loc = GL.GetUniformLocation(ID, p);
            GL.Uniform2(loc, v);
        }

        public void SetVec3(string p, Vector3 v)
        {
            var loc = GL.GetUniformLocation(ID, p);
            GL.Uniform3(loc, v);
        }

        public void SetVec4(string p, Vector4 v)
        {
            var loc = GL.GetUniformLocation(ID, p);
            GL.Uniform4(loc, v);
        }

        public void SetMat2(string p, Matrix2 v)
        {
            var loc = GL.GetUniformLocation(ID, p);
            GL.UniformMatrix2(loc, false, ref v);
        }

        public void SetMat3(string p, Matrix3 v)
        {
            var loc = GL.GetUniformLocation(ID, p);
            GL.UniformMatrix3(loc, false, ref v);
        }

        public void SetMat4(string p, Matrix4 v)
        {
            var loc = GL.GetUniformLocation(ID, p);
            GL.UniformMatrix4(loc, false, ref v);
        }

        public void SetTexture(Texture texture, TextureUnit unit)
        {
            if (texture == null) return;
            texture.Use(unit);
        }

        public void SetTexture(Texture texture, int unit)
        {
            if (texture == null) return;
            GL.ActiveTexture(TextureUnit.Texture0 + unit);
            GL.BindTexture(texture.Target, texture.Id);
        }
    }
}
