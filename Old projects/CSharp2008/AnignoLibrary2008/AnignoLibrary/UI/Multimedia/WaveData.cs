using System.IO;
using System;

namespace AnignoLibrary.UI.Multimedia
{
    /// <summary>
    /// Wave audio file data extractor for Wav 8000/8/1
    /// </summary>
    public class WaveData
    {

		#region Fields (8) 


        private byte[] mWaveAudioData;
        private sbyte[] mWaveForm;

        private readonly string mWaveFile;

        private int mWaveDataLength;
        private int mFileLength;
        private int mSamplerate;

        private short mBitsPerSample;
        private short mChannels;

		#endregion Fields 

		#region Constructors (1) 

        public WaveData(string waveFile)
        {
            mWaveFile = waveFile;
            ReadWavData();
        }

		#endregion Constructors 

		#region Read only Properties (6) 

        public short BitsPerSample
        {
            get { return mBitsPerSample; }
        }

        public short Channels
        {
            get { return mChannels; }
        }

        public int FileLength
        {
            get { return mFileLength; }
        }

        public int Samplerate
        {
            get { return mSamplerate; }
        }

        public byte[] WaveAudioData
        {
            get { return mWaveAudioData; }
        }

        public int WaveDataLength
        {
            get { return mWaveDataLength; }
        }

		#endregion Read only Properties 

		#region Static Methods (1) 

        public static byte[] GetSubBuffer(byte[] bytes, int start, int end,int lengthOfResult)
        {
            byte[] ret=new byte[lengthOfResult];
            int step = (end - start + 1) / lengthOfResult;
            for (int a = 0; a < bytes.Length; a += step)
            {
                for (int b = 0; b < step; b++)
                {
                    ret[a / step] = Math.Max(ret[a / step], (byte)Math.Abs(bytes[a + b]-128));
                }
            }
            return ret;
        }

   
        #endregion Static Methods 

		#region Private Methods (1) 

        private void ReadWavData()
        {
            FileStream fs = new FileStream(mWaveFile, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            //Read wave audio parameters
            mFileLength = (int)fs.Length - 8;
            fs.Position = 22;
            mChannels = br.ReadInt16();
            if(mChannels!=1)throw new Exception("Channels must be 1");
            fs.Position = 24;
            mSamplerate = br.ReadInt32();
            if (mSamplerate != 8000) throw new Exception("Sample rate must be 8000");
            fs.Position = 34;
            mBitsPerSample = br.ReadInt16();
            if (mBitsPerSample != 8) throw new Exception("BitsPerSample must be 8");
            mWaveDataLength = (int)fs.Length - 44;
            //Read wave audio data
            mWaveAudioData = new byte[fs.Length - 44];
            fs.Position = 44;
            fs.Read(WaveAudioData, 0, WaveAudioData.Length);
            fs.Close();
            br.Close();
            fs.Close();
        }

		#endregion Private Methods 

		#region Public Methods (1) 

        public sbyte[] GetWaveForm(float startSecond, float EndSecond,int returnBufferLength )
        {
            int start = (int)(startSecond * 8000);
            int end = start + (int)(EndSecond * 8000);
            sbyte[] ret=new sbyte[returnBufferLength];
            int samplesPerRet=(end-start+1)/(int)returnBufferLength;
            return null;
        }

		#endregion Public Methods 

    }
}