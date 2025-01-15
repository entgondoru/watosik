using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watosik.Domain.Entities;

namespace Watosik.Domain.Interfaces
{
    public interface IWeatherAPIClient
    {
        Task<Weather> GetWeatherAsync(string city);
    }
}
