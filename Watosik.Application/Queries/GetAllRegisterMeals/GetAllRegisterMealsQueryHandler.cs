using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watosik.Application.DataTransferObjects;
using Watosik.Domain;
using Watosik.Domain.Interfaces;

namespace Watosik.Application.Queries.GetAllRegisterMeals
{
    public class GetAllRegisterMealsQueryHandler : IRequestHandler<GetAllRegisterMealsQuery, IEnumerable<register_mealsDTO>>
    {
        private readonly Iregister_mealsRepository _Repository;
        private readonly IMapper _mapper;
        public GetAllRegisterMealsQueryHandler(Iregister_mealsRepository Repo, IMapper mapper) 
        {
            _Repository = Repo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<register_mealsDTO>> Handle(GetAllRegisterMealsQuery request, CancellationToken cancellationToken)
        {
            var jadlospis = await _Repository.GetAll();
            var dtos = _mapper.Map<IEnumerable<register_mealsDTO>>(jadlospis);
            return dtos;
        }
    }
}
