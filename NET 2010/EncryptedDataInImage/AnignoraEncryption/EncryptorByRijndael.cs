using System.IO;
using System.Security.Cryptography;

namespace AnignoraEncryption
{
    public class EncryptorByRijndael
    {
		#region Fields (1) 

        private static readonly byte[] s_salt = new byte[] { 0x26, 0xdc, 0xff, 0x00, 0xad, 0xed, 0x7a, 0xee, 0xc5, 0xfe, 0x07, 0xaf, 0x4d, 0x08, 0x22, 0x3c };

		#endregion Fields 

		#region Methods (2) 

		// Public Methods (2) 

        public static byte[] DecryptBytes(byte[] p_encryptedBytes, string p_key)
        {
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(p_key, s_salt);
            rijndaelManaged.Key = pdb.GetBytes(32);
            rijndaelManaged.IV = pdb.GetBytes(16); 

            using (var stream = new MemoryStream())
            using (var decryptor = rijndaelManaged.CreateDecryptor())
            using (var encrypt = new CryptoStream(stream, decryptor, CryptoStreamMode.Write))
            {
                encrypt.Write(p_encryptedBytes, 0, p_encryptedBytes.Length);
                encrypt.FlushFinalBlock();
                return stream.ToArray();
            }
        }

        public static byte[] EncryptBytes(byte[] p_bytes, string p_key)
        {
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(p_key, s_salt);
            rijndaelManaged.Key = pdb.GetBytes(32);
            rijndaelManaged.IV = pdb.GetBytes(16); 
            using (var stream = new MemoryStream())
            using (var encryptor = rijndaelManaged.CreateEncryptor())
            using (var encrypt = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
            {
                encrypt.Write(p_bytes, 0, p_bytes.Length);
                encrypt.FlushFinalBlock();
                return stream.ToArray();
            }
        }

		#endregion Methods 
    }
}
