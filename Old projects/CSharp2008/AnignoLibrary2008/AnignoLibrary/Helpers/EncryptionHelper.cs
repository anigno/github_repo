﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AnignoLibrary.Helpers
{
    public class EncryptionHelper
    {
		#region (------  Static Fields  ------)

        private static readonly MD5 md5Hasher = MD5.Create();

		#endregion (------  Static Fields  ------)

		#region (------  Static Methods  ------)

        public static bool BytesCompare(byte[] b1, byte[] b2)
        {
            if (b1.Length != b2.Length) return false;
            if (b1.Length == 0) return false;
            for (int a = 0; a < b1.Length; a++)
            {
                if (b1[a] != b2[a]) return false;
            }
            return true;
        }

        public static string DecryptString(string InputText, string Password)
        {
            try
            {
                RijndaelManaged RijndaelCipher = new RijndaelManaged();
                byte[] EncryptedData = Convert.FromBase64String(InputText);
                byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
                PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
                // Create a decryptor from the existing SecretKey bytes.
                ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
                MemoryStream memoryStream = new MemoryStream(EncryptedData);
                // Create a CryptoStream. (always use Read mode for decryption).
                CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);
                // Since at this point we don't know what the size of decrypted data
                // will be, allocate the buffer long enough to hold EncryptedData;
                // DecryptedData is never longer than EncryptedData.
                byte[] PlainText = new byte[EncryptedData.Length];
                // Start decrypting.
                int DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);
                memoryStream.Close();
                cryptoStream.Close();
                // Convert decrypted data into a string. 
                string DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount);
                // Return decrypted string.   
                return DecryptedData;
            }
            catch (Exception ex)
            {
                return "Decryption error: " + ex.Message;
            }
        }

        public static string EncryptString(string InputText, string Password)
        {
            // We are now going to create an instance of the 
            // Rihndael class.  
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            // First we need to turn the input strings into a byte array.
            byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(InputText);
            // We are using salt to make it harder to guess our key
            // using a dictionary attack.
            byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
            // The (Secret Key) will be generated from the specified 
            // password and salt.
            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
            // Create a encryptor from the existing SecretKey bytes.
            // We use 32 bytes for the secret key 
            // (the default Rijndael key length is 256 bit = 32 bytes) and
            // then 16 bytes for the IV (initialization vector),
            // (the default Rijndael IV length is 128 bit = 16 bytes)
            ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
            // Create a MemoryStream that is going to hold the encrypted bytes 
            MemoryStream memoryStream = new MemoryStream();
            // Create a CryptoStream through which we are going to be processing our data. 
            // CryptoStreamMode.Write means that we are going to be writing data 
            // to the stream and the output will be written in the MemoryStream
            // we have provided. (always use write mode for encryption)
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
            // Start the encryption process.
            cryptoStream.Write(PlainText, 0, PlainText.Length);
            // Finish encrypting.
            cryptoStream.FlushFinalBlock();
            // Convert our encrypted data from a memoryStream into a byte array.
            byte[] CipherBytes = memoryStream.ToArray();
            // Close both streams.
            memoryStream.Close();
            cryptoStream.Close();
            // Convert encrypted data into a base64-encoded string.
            // A common mistake would be to use an Encoding class for that. 
            // It does not work, because not all byte values can be
            // represented by characters. We are going to be using Base64 encoding
            // That is designed exactly for what we are trying to do. 
            string EncryptedData = Convert.ToBase64String(CipherBytes);
            // Return encrypted string.
            return EncryptedData;
        }

        public static byte[] GetMd5Hash(string s)
        {
            try
            {
                byte[] bytes = Encoding.Default.GetBytes(s);
                return md5Hasher.ComputeHash(bytes);
            }
            catch
            {
                return null;
            }
        }

        public static byte[] GetMd5Hash(byte[] bytes)
        {
            try
            {
                return md5Hasher.ComputeHash(bytes);
            }
            catch
            {
                return null;
            }
        }

        public static bool VerifyMd5Hash(byte[] bytes, byte[] md5Hash)
        {
            byte[] hash = GetMd5Hash(bytes);
            return BytesCompare(md5Hash, hash);
        }

		#endregion (------  Static Methods  ------)
    }
}