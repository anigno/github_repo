using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DivesManager.Data
{
    public class DataCollection
    {
        public List<DiveData> Dives = new List<DiveData>();
        public string TextPadString = "";
        public List<ClubData> ClubDataList = new List<ClubData>();
        public string Key = string.Empty;
    }
}
