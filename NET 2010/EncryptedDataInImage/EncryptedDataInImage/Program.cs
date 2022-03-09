using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AnignoraEncryption;

namespace EncryptedDataInImage
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "jkwhdfsiuyfiu43rwhfeuisdkljgfuweirgsdbfiu lwklhef uyq43whgehfy 23wgtbrxyng4whcyre364ydunrxgyu43jgrf6n423yucgtrx3yu4ewjn";
            byte[] b0 = Encoding.ASCII.GetBytes(text);
            const string key = "123";
            byte[] b1=EncryptorByRijndael.EncryptBytes(b0, key);
            byte[] b2 = EncryptorByRijndael.DecryptBytes(b1, key);
            string s=Encoding.ASCII.GetString(b2);
            if (text != s)
            {
            }
            const string FILENAME = @"Image01.bmp";
            const string ENC_PREFIX = @"ENC_";
            //const string SRC_PREFIX = @"SRC_";
            Bitmap bitmap = (Bitmap)Image.FromFile(FILENAME);

            //bitmap = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), PixelFormat.Format24bppRgb);
            //bitmap.Save(SRC_PREFIX + FILENAME, ImageFormat.Bmp);
            //bitmap = (Bitmap)Image.FromFile(SRC_PREFIX + FILENAME);

            byte[] buffer = createEncryptedData();

            Bitmap encBitmap=InImageIncryptor.MergeDataToBitmap(bitmap, buffer);
            encBitmap.Save(ENC_PREFIX + FILENAME, ImageFormat.Bmp);

            bitmap = (Bitmap)Image.FromFile(ENC_PREFIX + FILENAME);
            byte[] buffer2 = InImageIncryptor.ExtractDataFromBitmap(bitmap);


            for (int a = 0; a < buffer.Length; a++)
            {
                if (buffer[a] != buffer2[a])
                {
                }
            }
        }




        private static byte[] createEncryptedData()
        {
            byte[] buffer = new byte[1000000];
            for (int a = 0; a < buffer.Length; a++)
                buffer[a] = 0;
            Random rnd = new Random(DateTime.Now.Millisecond);
            //rnd.NextBytes(buffer);
            return buffer;
        }
    }
}
