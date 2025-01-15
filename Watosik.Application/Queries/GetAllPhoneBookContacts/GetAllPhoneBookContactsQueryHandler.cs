using AutoMapper;
using MediatR;
using Watosik.Application.DataTransferObjects;
using Watosik.Domain.Interfaces;

namespace Watosik.Application.Queries.GetAllPhoneBookContacts
{
    public class GetAllPhoneBookContactsQueryHandler : IRequestHandler<GetAllPhoneBookContactsQuery, IEnumerable<phone_book_contactDto>>
    {
        private readonly Iphone_book_contactRepository _phoneBookRepository;
        private readonly IMapper _mapper;

        public GetAllPhoneBookContactsQueryHandler(Iphone_book_contactRepository phoneBookRepository, IMapper mapper) 
        {
            _phoneBookRepository = phoneBookRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<phone_book_contactDto>> Handle(GetAllPhoneBookContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _phoneBookRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<phone_book_contactDto>>(contacts);
            return dtos;
        }
    }
}