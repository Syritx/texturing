using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Texture.Launcher
{
    public class Launcher : GameWindow
    {

        int texture;
        static double yOffset = 0;
        static double size = .2;

        double[] coords = {
            -size, .3+yOffset,
             size, .3+yOffset,
             size,-.3+yOffset,
            -size,-.3+yOffset
        };
        public Launcher(int width, int height)
            : base(width, height, GraphicsMode.Default, "2030 Dystopia - Launcher") {

            Run(60);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            #region TITLE_SCREEN

            GL.BindTexture(TextureTarget.Texture2D, texture);
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(1.0, 1.0, 1.0);

            GL.TexCoord2(coords[0], coords[1]);
            GL.Vertex2(coords[0], coords[1]);

            GL.TexCoord2(coords[2], coords[3]);
            GL.Vertex2(coords[2], coords[3]);

            GL.TexCoord2(coords[4], coords[5]);
            GL.Vertex2(coords[4], coords[5]);

            GL.TexCoord2(coords[6], coords[7]);
            GL.Vertex2(coords[6], coords[7]);

            GL.End();

            #endregion

            SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0, 0, 0, 0);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Texture2D);

            texture = ImageLoader.loadImage("TESTIMAGE.png");

            base.OnLoad(e);
        }
    }
}
