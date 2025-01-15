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
    public class documentMappingProfile : Profile 
    {
        public documentMappingProfile()
        {
            CreateMap<documentDto, document>();
            CreateMap<document, documentDto>();
        }
    }
}
