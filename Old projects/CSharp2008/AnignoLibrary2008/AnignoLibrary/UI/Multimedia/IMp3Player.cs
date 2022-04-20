using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnignoLibrary.UI.Multimedia
{
    public abstract class IMp3Player
    {
        public abstract void Load(string file);
        public abstract void Play();
        public abstract void Stop();
        public abstract void Pause();
        public abstract void SetVolume(uint volumePercentage);
        public abstract void SetPan(int panePercentage);
        public abstract void SetPosition(uint positionSeconds);

        public abstract uint DurationSeconds { get; }
        public abstract uint CurrentPosition { get; }

        public void Fastforward(uint seconds)
        {
            if (CurrentPosition + seconds > DurationSeconds) return;
            SetPosition(CurrentPosition+seconds);
        }

        public void FastBackwards(uint seconds)
        {
            if (CurrentPosition < seconds)
            {
                SetPosition(0);
                return;
            }
            SetPosition(CurrentPosition-seconds);
        }

    }
}
