using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watosik.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Watosik.Domain.Interfaces;
using Watosik.Infrastructure.Repositories;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Watosik.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DataBase");

            /*Database Context*/
            //Phonebook
            services.AddDbContext<phone_book_contactDbContext>(options => options.UseMySql(
                connectionString, ServerVersion.AutoDetect(connectionString)));
            services.AddScoped<Iphone_book_contactRepository, phone_book_contactRepository>();

            //Documents
            services.AddDbContext<documentDbContext>(options => options.UseMySql(
                 connectionString, ServerVersion.AutoDetect(connectionString)));
            services.AddScoped<IdocumentRepository, documentRepository>();

            //Meal
            services.AddDbContext<mealDbContext>(options => options.UseMySql(
                 connectionString, ServerVersion.AutoDetect(connectionString)));
            services.AddScoped<ImealRepository, mealRepository>();

            //Register Meals - jadłospis
            services.AddDbContext<register_mealsDbContext>(options => options.UseMySql(
                connectionString, ServerVersion.AutoDetect(connectionString)));
            services.AddScoped<Iregister_mealsRepository, register_mealsRepository>();

            services.AddHttpClient<IWeatherAPIClient, WeatherAPIClient>();

        }

    }
}
