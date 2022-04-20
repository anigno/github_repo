using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.AudioVideoPlayback;

namespace AnignoLibrary.UI.Multimedia
{
    public class Mp3PlayerDirectX :IMp3Player
    {
        private Audio _audioPlayer=null;


        public override void Load(string file)
        {
            throw new System.NotImplementedException();
        }

        public override void Play()
        {
            throw new System.NotImplementedException();
        }

        public override void Stop()
        {
            throw new System.NotImplementedException();
        }

        public override void Pause()
        {
            throw new System.NotImplementedException();
        }

        public override void SetVolume(uint volumePercentage)
        {
            throw new System.NotImplementedException();
        }

        public override void SetPan(int panePercentage)
        {
            throw new System.NotImplementedException();
        }

        public override void SetPosition(uint positionSeconds)
        {
            throw new System.NotImplementedException();
        }

        public override uint DurationSeconds
        {
            get { throw new System.NotImplementedException(); }
        }

        public override uint CurrentPosition
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
