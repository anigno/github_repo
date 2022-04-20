using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AnignoLibrary.UI.Multimedia.Mp3Players.irrKlangMp3PlayerControls
{
    public class ISoundEngineEx :ISoundEngine
    {
        public string EngineDescriptor { get; set; }

        public ISoundEngineEx(string descriptor, string deviceId)
            : base(SoundOutputDriver.AutoDetect, SoundEngineOptionFlag.DefaultOptions, deviceId)
        {
            EngineDescriptor = descriptor;
        }
    }
}