using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watosik.Domain.Entities;
using Watosik.Domain.Interfaces;

namespace Watosik.Application.Queries.GetWeather
{
    public class GetWeatherQueryHandler : IRequestHandler<GetWeatherQuery, Weather>
    {
        private readonly IWeatherAPIClient _weatherApiClient;

        public GetWeatherQueryHandler(IWeatherAPIClient weatherApiClient)
        {
            _weatherApiClient = weatherApiClient;
        }

        public async Task<Weather> Handle(GetWeatherQuery request, CancellationToken cancellationToken)
        {
            return await _weatherApiClient.GetWeatherAsync(request.City);
        }
    }
}
