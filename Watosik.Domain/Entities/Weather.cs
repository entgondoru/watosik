using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watosik.Domain.Entities
{
    public class Weather
    {
        public float Temperature { get; private set; }
        public int Humidity { get; private set; }
        public string Description { get; private set; }

        public Weather(float temperature, int humidity, string description)
        {
            Temperature = temperature;
            Humidity = humidity;
            Description = description;
        }
    }
}
