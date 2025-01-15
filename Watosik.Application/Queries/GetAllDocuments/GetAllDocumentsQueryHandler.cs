using AutoMapper;
using MediatR;
using Watosik.Application.DataTransferObjects;
using Watosik.Application.Queries.GetAllDocuments;
using Watosik.Domain.Interfaces;

namespace Watosik.Application.Queries.GetAllPhoneBookContacts
{
    public class GetAllDocumentsQueryHandler : IRequestHandler<GetAllDocumentsQuery, IEnumerable<documentDto>>
    {
        private readonly IdocumentRepository _documentRepository;
        private readonly IMapper _mapper;

        public GetAllDocumentsQueryHandler(IdocumentRepository documentRepository, IMapper mapper) 
        {
            _documentRepository = documentRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<documentDto>> Handle(GetAllDocumentsQuery request, CancellationToken cancellationToken)
        {
            var documents = await _documentRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<documentDto>>(documents);
            return dtos;
        }
    }
}