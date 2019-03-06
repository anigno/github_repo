using System;
using System.Collections.Generic;

namespace AnignoraMediaManager.Data
{
    public class DailyVolumeChanges
    {
        public List<VolumeChange> VolumeChanges { get; set; }
        public DayOfWeek Day { get; set; }
    }
}