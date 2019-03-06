using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace AnignoraEncryption
{
    public class InImageIncryptor
    {
        public static Bitmap MergeDataToBitmap(Bitmap p_bitmap, byte[] p_bytes)
        {
            Bitmap bitmap = p_bitmap.Clone(new Rectangle(0, 0, p_bitmap.Width, p_bitmap.Height), PixelFormat.Format24bppRgb);
            if (p_bitmap.Width /2* p_bitmap.Height/2 < p_bytes.Length) throw new Exception("Image is not big enough for the given buffer");
            Random rnd = new Random(DateTime.Now.Millisecond);
            Color sizeColor = Color.FromArgb(p_bytes.Length);
            bitmap.SetPixel(0, 0, sizeColor);

            int index = 0;
            for (int y = 1; y < bitmap.Height - 2; y += 2)
                for (int x = 1; x < bitmap.Width; x += 2)
                {
                    byte data;
                    if (index >= p_bytes.Length)
                    {
                        data = (byte)rnd.Next(255);
                    }
                    else
                    {
                        data = p_bytes[index++];
                    }
                    Color c = bitmap.GetPixel(x, y);
                    Color c2 = bitmap.GetPixel(x, y + 1);
                    byte b = c.B;
                    byte a = c.A;
                    int d0 = data / 16;
                    int d1 = data % 16;
                    byte r = (byte)(d0 + c2.R);
                    byte g = (byte)(d1 + c2.G);
                    Color cNew = Color.FromArgb(a, r, g, b);
                    bitmap.SetPixel(x, y, cNew);
                }
            return bitmap;
        }

        public static byte[] ExtractDataFromBitmap(Bitmap p_bitmap)
        {
            Color sizeColor = p_bitmap.GetPixel(0, 0);
            sizeColor = Color.FromArgb(0, sizeColor.R, sizeColor.G, sizeColor.B);
            int length = sizeColor.ToArgb();
            byte[] bytes = new byte[length];
            int index = 0;
            for (int y = 1; y < p_bitmap.Height - 2; y += 2)
                for (int x = 1; x < p_bitmap.Width; x += 2)
                {
                    Color c = p_bitmap.GetPixel(x, y);
                    Color c2 = p_bitmap.GetPixel(x, y + 1);
                    int d0 = c.R - c2.R;
                    int d1 = c.G - c2.G;
                    byte data = (byte)(d0 * 16 + d1);
                    bytes[index++] = data;
                    if (index >= length) return bytes;
                }
            return bytes;
        }
    }
}
