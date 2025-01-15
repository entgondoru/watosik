using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watosik.Application.DataTransferObjects;
using Watosik.Domain;

namespace Watosik.Application.Mappings
{
    public class register_mealsMappingProfile : Profile
    {
        public register_mealsMappingProfile() 
        {
            CreateMap<register_mealsDTO,register_meals>();
            CreateMap<register_meals,register_mealsDTO>();
        }   
    }
}
