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
    public class phone_book_contactMappingProfile : Profile 
    {
        public phone_book_contactMappingProfile()
        {
            CreateMap<phone_book_contactDto, phone_book_contact>();
            CreateMap<phone_book_contact, phone_book_contactDto>();
        }
    }
}
