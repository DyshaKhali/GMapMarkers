using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMapMarkers
{
    public class MarkerD
    {
        public string MarkerName { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public MarkerD(string markerName, double longitude, double latitude)
        {
            MarkerName = markerName;
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
