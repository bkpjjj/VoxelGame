using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VoxelGame.Engine.ECS.Components;
using VoxelGame.Engine.Graphics.Geometry;

namespace VoxelGame.Engine.ECS.Systems
{
    class DrawSystem : ECSSystem
    {
        IEnumerable<MeshRenderer> meshRenderers;
        IEnumerable<Camera> cameras;
        public DrawSystem(Context context) : base(context)
        {
            meshRenderers = Context.GetComponents<MeshRenderer>();
            cameras = Context.GetComponents<Camera>();
        }

        public override void Draw(float dt)
        {
            foreach (Camera camera in cameras)
            {
                if (!camera.isActive)
                    continue;

                if (camera.FrameBuffer != null)
                {
                    camera.FrameBuffer.Bind();
                }

                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                foreach (MeshRenderer renderer in meshRenderers)
                {
                    if (!renderer.isActive)
                        continue;

                    Transform t = Context.GetComponent<Transform>(renderer.EntityId);

                    renderer.Material.Shader.Use();
                    renderer.Material.Shader.SetMat4("MODEL", t.Model);
                    renderer.Material.Shader.SetMat4("PROJ", camera.Projection);
                    renderer.Material.Shader.SetMat4("VIEW", camera.View);
                    renderer.Material.LoadParams();
                    renderer.Mesh.VertexArray.Bind();
                    GL.DrawElements(PrimitiveType.Triangles, renderer.Mesh.Indices.Count, DrawElementsType.UnsignedInt, 0);
                    renderer.Mesh.VertexArray.Unbind();
                    renderer.Material.Shader.Reset();
                }

                if (camera.FrameBuffer != null)
                {
                    camera.FrameBuffer.Unbind();
                }
            }
        }

        public override void Init()
        {
            //meshRenderers = meshRenderers.OrderByDescending(
            //        x =>
            //        {
            //            var t = Context.GetComponent<Transform>(x.EntityId);
            //            var ct = Context.GetComponent<Transform>(0);
            //            return Vector3.Distance(t.Position, ct.Position);
            //        }
            //);

            /*foreach (Camera camera in cameras)
            {
                meshRenderers = meshRenderers.OrderByDescending(x =>
                {
                    var t = Context.GetComponent<Transform>(x.EntityId);
                    var ct = Context.GetComponent<Transform>(camera.EntityId);
                    return Vector3.Distance(t.Position, ct.Position);
                });
            }*/

            foreach (MeshRenderer renderer in meshRenderers)
            {
                renderer.Mesh.Upload();
            }
            //GL.ClearColor(new Color4(0.05f, 0.05f, 0.01f, 1.0f));
            GL.ClearColor(new Color4(0.65f, 0.62f, 1f, 1.0f));
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
        }

        public override void Update(float dt)
        {
        }
    }
}
