using System;
using System.Collections.Generic;
using System.Text;

namespace VHSApi.Web.Entity 
{

    public class Status
    {

        public string Vin { get; set; }
        public int BatteryLevel { get; set; }
        public int TripMeter { get; set; }
        public bool LockStatus { get; set; }
        public bool AlarmStatus { get; set; }
        public string TirePressure { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class Journal
    {
        public string Vin { get; set; }
        public DateTime StartingTime { get; set; }
        public int TripMeter { get; set; }
        public DateTime StoppingTime { get; set; }
        public int PowerConsumption { get; set; }
        public int AverageConsumption { get; set; }
        public int AverageSpeed { get; set; }
    }




};

