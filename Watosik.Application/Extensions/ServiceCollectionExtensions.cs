using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Watosik.Application.Mappings;
using Watosik.Application.Queries.GetAllPhoneBookContacts;
using Watosik.Domain.Interfaces;
using System.Net.Http;
using Watosik.Application.Queries.CalculatePoints;
using Watosik.Application.Queries.GetAllRegisterMeals;

namespace Watosik.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetAllPhoneBookContactsQuery));

            services.AddAutoMapper(typeof(phone_book_contactMappingProfile));
            services.AddAutoMapper(typeof(documentMappingProfile));
            services.AddAutoMapper(typeof(mealMappingProfile));
            services.AddMediatR(typeof(CalculatePointsQuery).Assembly);

        }
    }
}
