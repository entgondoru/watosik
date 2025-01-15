using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watosik.Domain.Entities;

namespace Watosik.Application.Queries.GetWeather
{
    public class GetWeatherQuery : IRequest<Weather>
    {
        public string City { get; set; }

        public GetWeatherQuery(string city)
        {
            City = city;
        }
    }
}
