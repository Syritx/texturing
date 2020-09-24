using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using OpenTK.Graphics.OpenGL;

namespace Texture.Launcher
{
    public class ImageLoader
    {
        public ImageLoader()
        {
        }

        public static int loadImage(string path)
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + "/" + path))
            {
                throw new FileNotFoundException("File not found at "+ Directory.GetCurrentDirectory() + "/" + path);
            }

            int id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, id);

            Bitmap bmp = new Bitmap(Directory.GetCurrentDirectory() + "/" + path);
            BitmapData dat = bmp.LockBits(
                new Rectangle(0,0,bmp.Width,bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb
            );

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, dat.Width, dat.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, dat.Scan0);
            bmp.UnlockBits(dat);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Clamp);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Clamp);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureWrapMode.MirroredRepeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureWrapMode.MirroredRepeat);

            return id;
        }
    }
}
