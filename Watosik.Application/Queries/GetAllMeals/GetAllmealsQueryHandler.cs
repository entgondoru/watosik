using AutoMapper;
using MediatR;
using Watosik.Application.DataTransferObjects;
using Watosik.Application.Queries.GetAllDocuments;
using Watosik.Domain.Interfaces;

namespace Watosik.Application.Queries.GetAllPhoneBookContacts
{
    public class GetAllmealsQueryHandler : IRequestHandler<GetAllmealsQuery, IEnumerable<mealDto>>
    {
        private readonly ImealRepository _mealRepository;
        private readonly IMapper _mapper;

        public GetAllmealsQueryHandler(ImealRepository mealRepository, IMapper mapper) 
        {
            _mealRepository = mealRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<mealDto>> Handle(GetAllmealsQuery request, CancellationToken cancellationToken)
        {
            var meals = await _mealRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<mealDto>>(meals);
            return dtos;
        }
    }
}