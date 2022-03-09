using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AnignoraDataTypes.CommonTypes;
using AnignoraDataTypes.Configurations;
using AnignoraMediaManager.Data;

namespace AnignoraMediaManager
{
    public class MediaManager
    {
        private readonly ConfiguratorXml<MediaManagerData> m_configurator;
        private Timer m_playingTimer;

        public MediaManager()
        {
            m_configurator = new ConfiguratorXml<MediaManagerData>("AnignoraMediaManager.XML");
            m_configurator.Load();
            m_playingTimer=new Timer(playingTimerCallback);

        }

        public void AddVolumeChange(DayOfWeek p_day,Time p_time,int p_volume)
        {
            VolumeChange volumeChange = new VolumeChange(){TimeStart = p_time,Volume = p_volume};
            m_configurator.Configuration.DailyVolumeChanges[(int) p_day].VolumeChanges.Add(volumeChange);
            m_configurator.Save();
        }

        public void RemoveVolumeChange(int p_id)
        {

        }

        private void playingTimerCallback(object p_state)
        {
            throw new NotImplementedException();
        }
    }
}
