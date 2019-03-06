using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DivesManager.Data
{
    public class DiveData
    {
        public int Dive1RestingTime = 0;
        public int Dive1Depth = 0;
        public int Dive1Time = 0;
        public int Dive2RestingTime = 0;
        public int Dive2Depth = 0;
        public int Dive2Time = 0;
        public int Dive3RestingTime = 0;
        public int Dive3Depth = 0;
        public int Dive3Time = 0;
        public string DiveName = "New dive" + DateTime.Now.ToShortDateString();
        public DateTime DiveDateTime = DateTime.Now;
        public string DivePlace = "New place";
        public int DiveWeight = 0;
        public int DiveSuit = 0;
         
    }
}
