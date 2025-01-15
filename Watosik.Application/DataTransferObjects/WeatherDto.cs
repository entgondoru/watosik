using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watosik.Application.DataTransferObjects
{
    public class WeatherDto
    {
        public MainInfo Main { get; set; }
        public WeatherDescription[] Weather { get; set; }
    }

    public class MainInfo
    {
        public float Temp { get; set; }
        public int Humidity { get; set; }
        public float Feels_Like { get; set; }
        public float Temp_Min { get; set; }
        public float Temp_Max { get; set; }
        public int Pressure { get; set; }
    }

    public class WeatherDescription
    {
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

}
