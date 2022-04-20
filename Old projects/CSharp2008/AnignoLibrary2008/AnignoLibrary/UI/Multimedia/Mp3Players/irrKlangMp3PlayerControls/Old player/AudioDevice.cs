using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace AnignoLibrary.UI.Multimedia.Mp3Players.irrKlangMp3PlayerControl
{
    public class AudioDevice
    {

		#region (------  Static Fields  ------)

        private static readonly List<AudioDevice> _audioDevices=new List<AudioDevice>();
        private static readonly ISoundDeviceList _soundDeviceList = new ISoundDeviceList(SoundDeviceListType.PlaybackDevice);

		#endregion (------  Static Fields  ------)

		#region (------  Fields  ------)


        private string _deviceId;
        private string _deviceDescription;

		#endregion (------  Fields  ------)

		#region (------  Static Constructor  ------)

        static AudioDevice()
        {
            //Create AudioDevices list
            for(int a=0;a<_soundDeviceList.DeviceCount;a++)
            {
                AudioDevice device=new AudioDevice {
                    _deviceId = _soundDeviceList.getDeviceDescription(a),
                    _deviceDescription = _soundDeviceList.getDeviceID(a)};
                _audioDevices.Add(device);
            }
        }

		#endregion (------  Static Constructor  ------)

		#region (------  Read only Properties  ------)

        public static ReadOnlyCollection<AudioDevice> AudioDevices
        {
            get { return _audioDevices.AsReadOnly(); }
        }

        public string DeviceDescription
        {
            get { return _deviceDescription; }
        }

        public string DeviceId
        {
            get { return _deviceId; }
        }

		#endregion (------  Read only Properties  ------)

    }
}
