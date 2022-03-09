using System;
using AnignoraDataTypes.Configurations;

namespace AnignoraMediaManager.Data
{
    public class MediaManagerData : IConfiguration
    {
        public DailyVolumeChanges[] DailyVolumeChanges { get; set; }

        public MediaManagerData()
        {
            DailyVolumeChanges=new DailyVolumeChanges[7];
            for (int i = 0; i < DailyVolumeChanges.Length; i++)
            {
                DailyVolumeChanges[i] = new DailyVolumeChanges();
            }
        }

        public void SetDefaults()
        {
            
        }
    }
}